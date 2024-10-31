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

Namespace DECV_PROD2007.LANGUAGE_list 'Namespace @1-3864DF94

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

'Grid LANGUAGE Item Class @2-2962F06C
Public Class LANGUAGEItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public LANG_CODE As IntegerField
    Public LANG_CODEHref As Object
    Public LANG_CODEHrefParameters As LinkParameterCollection
    Public LANG_DESCRIPTION As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Alt_LANG_CODE As IntegerField
    Public Alt_LANG_CODEHref As Object
    Public Alt_LANG_CODEHrefParameters As LinkParameterCollection
    Public Alt_LANG_DESCRIPTION As TextField
    Public Alt_LAST_ALTERED_BY As TextField
    Public Alt_LAST_ALTERED_DATE As DateField
    Public LANGUAGE_Insert As TextField
    Public LANGUAGE_InsertHref As Object
    Public LANGUAGE_InsertHrefParameters As LinkParameterCollection
    Public Sub New()
    LANG_CODE = New IntegerField("",Nothing)
    LANG_CODEHrefParameters = New LinkParameterCollection()
    LANG_DESCRIPTION = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    Alt_LANG_CODE = New IntegerField("",Nothing)
    Alt_LANG_CODEHrefParameters = New LinkParameterCollection()
    Alt_LANG_DESCRIPTION = New TextField("", Nothing)
    Alt_LAST_ALTERED_BY = New TextField("", Nothing)
    Alt_LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    LANGUAGE_Insert = New TextField("",Nothing)
    LANGUAGE_InsertHrefParameters = New LinkParameterCollection()
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "LANG_CODE"
                    Return Me.LANG_CODE
                Case "LANG_DESCRIPTION"
                    Return Me.LANG_DESCRIPTION
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "Alt_LANG_CODE"
                    Return Me.Alt_LANG_CODE
                Case "Alt_LANG_DESCRIPTION"
                    Return Me.Alt_LANG_DESCRIPTION
                Case "Alt_LAST_ALTERED_BY"
                    Return Me.Alt_LAST_ALTERED_BY
                Case "Alt_LAST_ALTERED_DATE"
                    Return Me.Alt_LAST_ALTERED_DATE
                Case "LANGUAGE_Insert"
                    Return Me.LANGUAGE_Insert
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "LANG_CODE"
                    Me.LANG_CODE = CType(Value,IntegerField)
                Case "LANG_DESCRIPTION"
                    Me.LANG_DESCRIPTION = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "Alt_LANG_CODE"
                    Me.Alt_LANG_CODE = CType(Value,IntegerField)
                Case "Alt_LANG_DESCRIPTION"
                    Me.Alt_LANG_DESCRIPTION = CType(Value,TextField)
                Case "Alt_LAST_ALTERED_BY"
                    Me.Alt_LAST_ALTERED_BY = CType(Value,TextField)
                Case "Alt_LAST_ALTERED_DATE"
                    Me.Alt_LAST_ALTERED_DATE = CType(Value,DateField)
                Case "LANGUAGE_Insert"
                    Me.LANGUAGE_Insert = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid LANGUAGE Item Class

'Grid LANGUAGE Data Provider Class Header @2-C712353E
Public Class LANGUAGEDataProvider
Inherits GridDataProviderBase
'End Grid LANGUAGE Data Provider Class Header

'Grid LANGUAGE Data Provider Class Variables @2-AB31E693

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_LANG_CODE
        Sorter_LANG_DESCRIPTION
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE
    End Enum

    Private SortFieldsNames As String() = New String() {"LANG_CODE","LANG_CODE","LANG_DESCRIPTION","LAST_ALTERED_BY","LAST_ALTERED_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"LANG_CODE","LANG_CODE DESC","LANG_DESCRIPTION DESC","LAST_ALTERED_BY DESC","LAST_ALTERED_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 20
    Public PageNumber As Integer = 1
    Public Urls_keyword  As TextParameter
'End Grid LANGUAGE Data Provider Class Variables

'Grid LANGUAGE Data Provider Class GetResultSet Method @2-8DD4FA58

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM [LANGUAGE] {SQL_Where} {SQL_OrderBy}", New String(){"s_keyword35"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM [LANGUAGE]", New String(){"s_keyword35"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid LANGUAGE Data Provider Class GetResultSet Method

'Grid LANGUAGE Data Provider Class GetResultSet Method @2-C7718105
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As LANGUAGEItem()
'End Grid LANGUAGE Data Provider Class GetResultSet Method

'Grid LANGUAGE Event BeforeBuildSelect. Action Advanced Search @32-1C0F8AAD
        Select_.Parameters.Clear()
        DBUtility.ManageAdvancedSearch(Select_, _ 
	                                   New String() {"LANG_CODE","LANG_DESCRIPTION"}, _
	                                   System.Web.HttpContext.Current.Request("searchConditions"), _
	                                   System.Web.HttpContext.Current.Request("s_keyword"))
        CType(Count, TableCommand).WhereTemplate = CType(Select_, TableCommand).WhereTemplate
'End Grid LANGUAGE Event BeforeBuildSelect. Action Advanced Search

'Before build Select @2-A64BA124
        Dim E as Exception = Nothing
        CType(Select_,TableCommand).AddParameter("s_keyword35",Urls_keyword, "","LANG_DESCRIPTION",Condition.Contains,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-38D90261
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As LANGUAGEItem
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

'After execute Select @2-8A5137A6
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New LANGUAGEItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-36CD987C
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as LANGUAGEItem = New LANGUAGEItem()
                item.LANG_CODE.SetValue(dr(i)("LANG_CODE"),"")
                item.LANG_CODEHref = "LANGUAGE_maint.aspx"
                item.LANG_CODEHrefParameters.Add("LANG_CODE",System.Web.HttpUtility.UrlEncode(dr(i)("LANG_CODE").ToString()))
                item.LANG_DESCRIPTION.SetValue(dr(i)("LANG_DESCRIPTION"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.Alt_LANG_CODE.SetValue(dr(i)("LANG_CODE"),"")
                item.Alt_LANG_CODEHref = "LANGUAGE_maint.aspx"
                item.Alt_LANG_CODEHrefParameters.Add("LANG_CODE",System.Web.HttpUtility.UrlEncode(dr(i)("LANG_CODE").ToString()))
                item.Alt_LANG_DESCRIPTION.SetValue(dr(i)("LANG_DESCRIPTION"),"")
                item.Alt_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.Alt_LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.LANGUAGE_InsertHref = "LANGUAGE_maint.aspx"
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

'Record LANGUAGE1 Item Class @27-886F1624
Public Class LANGUAGE1Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public s_keyword As TextField
    Public Sub New()
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    s_keyword = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As LANGUAGE1Item
        Dim item As LANGUAGE1Item = New LANGUAGE1Item()
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
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
                Case "ClearParameters"
                    Return ClearParameters
                Case "s_keyword"
                    Return s_keyword
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ClearParameters"
                    ClearParameters = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As LANGUAGE1DataProvider)
'End Record LANGUAGE1 Item Class

'Record LANGUAGE1 Item Class tail @27-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record LANGUAGE1 Item Class tail

'Record LANGUAGE1 Data Provider Class @27-7244106B
Public Class LANGUAGE1DataProvider
Inherits RecordDataProviderBase
'End Record LANGUAGE1 Data Provider Class

'Record LANGUAGE1 Data Provider Class Variables @27-53CD2220
    Protected item As LANGUAGE1Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record LANGUAGE1 Data Provider Class Variables

'Record LANGUAGE1 Data Provider Class GetResultSet Method @27-A5B0D646

    Public Sub FillItem(ByVal item As LANGUAGE1Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record LANGUAGE1 Data Provider Class GetResultSet Method

'Record LANGUAGE1 BeforeBuildSelect @27-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record LANGUAGE1 BeforeBuildSelect

'Record LANGUAGE1 AfterExecuteSelect @27-79426A21
        End If
            IsInsertMode = True
'End Record LANGUAGE1 AfterExecuteSelect

'Record LANGUAGE1 AfterExecuteSelect tail @27-E31F8E2A
    End Sub
'End Record LANGUAGE1 AfterExecuteSelect tail

'Record LANGUAGE1 Data Provider Class @27-A61BA892
End Class

'End Record LANGUAGE1 Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

