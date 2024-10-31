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

Namespace DECV_PROD2007.popup_SubjectList 'Namespace @1-696687C0

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

'Record SUBJECTSearch Item Class @10-E47466C5
Public Class SUBJECTSearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_YEAR_LEVEL As IntegerField
    Public s_YEAR_LEVELItems As ItemCollection
    Public Sub New()
    s_YEAR_LEVEL = New IntegerField("", Nothing)
    s_YEAR_LEVELItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As SUBJECTSearchItem
        Dim item As SUBJECTSearchItem = New SUBJECTSearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("s_YEAR_LEVEL")) Then
        item.s_YEAR_LEVEL.SetValue(DBUtility.GetInitialValue("s_YEAR_LEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_YEAR_LEVEL"
                    Return s_YEAR_LEVEL
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_YEAR_LEVEL"
                    s_YEAR_LEVEL = CType(value, IntegerField)
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

's_YEAR_LEVEL validate @12-D8969B14
        If IsNothing(s_YEAR_LEVEL.Value) OrElse s_YEAR_LEVEL.Value.ToString() ="" Then
            errors.Add("s_YEAR_LEVEL",String.Format(Resources.strings.CCS_RequiredField,"Year Level"))
        End If
'End s_YEAR_LEVEL validate

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

'ListBox s_YEAR_LEVEL AfterExecuteSelect @12-7EAD5B6B
        
item.s_YEAR_LEVELItems.Add("0","0 - Prep")
item.s_YEAR_LEVELItems.Add("1","1")
item.s_YEAR_LEVELItems.Add("2","2")
item.s_YEAR_LEVELItems.Add("3","3")
item.s_YEAR_LEVELItems.Add("4","4")
item.s_YEAR_LEVELItems.Add("5","5")
item.s_YEAR_LEVELItems.Add("6","6")
item.s_YEAR_LEVELItems.Add("7","7")
item.s_YEAR_LEVELItems.Add("8","8")
item.s_YEAR_LEVELItems.Add("9","9")
item.s_YEAR_LEVELItems.Add("10","10")
item.s_YEAR_LEVELItems.Add("11","11")
item.s_YEAR_LEVELItems.Add("12","12")
item.s_YEAR_LEVELItems.Add("30","Home Schooled")
'End ListBox s_YEAR_LEVEL AfterExecuteSelect

'Record SUBJECTSearch AfterExecuteSelect tail @10-E31F8E2A
    End Sub
'End Record SUBJECTSearch AfterExecuteSelect tail

'Record SUBJECTSearch Data Provider Class @10-A61BA892
End Class

'End Record SUBJECTSearch Data Provider Class

'Grid SUBJECT Item Class @2-EBEE76A7
Public Class SUBJECTItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public SUBJECT_ID As IntegerField
    Public SUBJECT_IDHref As Object
    Public SUBJECT_IDHrefParameters As LinkParameterCollection
    Public SUBJECT_TITLE As TextField
    Public Sub New()
    SUBJECT_ID = New IntegerField("",Nothing)
    SUBJECT_IDHrefParameters = New LinkParameterCollection()
    SUBJECT_TITLE = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "SUBJECT_ID"
                    Return Me.SUBJECT_ID
                Case "SUBJECT_TITLE"
                    Return Me.SUBJECT_TITLE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SUBJECT_ID"
                    Me.SUBJECT_ID = CType(Value,IntegerField)
                Case "SUBJECT_TITLE"
                    Me.SUBJECT_TITLE = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid SUBJECT Item Class

'Grid SUBJECT Data Provider Class Header @2-0DD17C44
Public Class SUBJECTDataProvider
Inherits GridDataProviderBase
'End Grid SUBJECT Data Provider Class Header

'Grid SUBJECT Data Provider Class Variables @2-C0BC6FC8

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_SUBJECT_ID
        Sorter_SUBJECT_TITLE
    End Enum

    Private SortFieldsNames As String() = New String() {"SUBJECT_ID","SUBJECT_ID","SUBJECT_TITLE"}
    Private SortFieldsNamesDesc As String() = New string() {"SUBJECT_ID","SUBJECT_ID DESC","SUBJECT_TITLE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 30
    Public PageNumber As Integer = 1
    Public UrlYEAR_LEVEL  As IntegerParameter
    Public Urls_YEAR_LEVEL  As IntegerParameter
'End Grid SUBJECT Data Provider Class Variables

'Grid SUBJECT Data Provider Class GetResultSet Method @2-283CE0FD

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} SUBJECT_ID, SUBJECT_TITLE, " & vbCrLf & _
          "YEAR_LEVEL " & vbCrLf & _
          "FROM SUBJECT {SQL_Where} {SQL_OrderBy}", New String(){"expr6","And","expr7","And","YEAR_LEVEL8","And","s_YEAR_LEVEL13"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM SUBJECT", New String(){"expr6","And","expr7","And","YEAR_LEVEL8","And","s_YEAR_LEVEL13"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid SUBJECT Data Provider Class GetResultSet Method

'Grid SUBJECT Data Provider Class GetResultSet Method @2-40D1E8E8
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As SUBJECTItem()
'End Grid SUBJECT Data Provider Class GetResultSet Method

'Before build Select @2-504566B5
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("YEAR_LEVEL8",UrlYEAR_LEVEL, "","YEAR_LEVEL",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("s_YEAR_LEVEL13",Urls_YEAR_LEVEL, "","YEAR_LEVEL",Condition.Equal,False)
        Select_.Parameters.Add("expr6","(STATUS = 1)")
        Select_.Parameters.Add("expr7","(CAMPUS_CODE = 'D')")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-C3D26DF9
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As SUBJECTItem
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

'After execute Select @2-A15FCA2A
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New SUBJECTItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-43B1821B
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as SUBJECTItem = New SUBJECTItem()
                item.SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
                item.SUBJECT_IDHref = ""
                item.SUBJECT_TITLE.SetValue(dr(i)("SUBJECT_TITLE"),"")
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

