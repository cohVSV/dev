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

Namespace DECV_PROD2007.FTE_RULES_list 'Namespace @1-DA7F71D4

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

'Grid FTE_RULES Item Class @2-7A837511
Public Class FTE_RULESItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public FTE_RULES_Insert As TextField
    Public FTE_RULES_InsertHref As Object
    Public FTE_RULES_InsertHrefParameters As LinkParameterCollection
    Public FROM_YEAR_LEVEL As IntegerField
    Public FROM_YEAR_LEVELHref As Object
    Public FROM_YEAR_LEVELHrefParameters As LinkParameterCollection
    Public TO_YEAR_LEVEL As IntegerField
    Public UNIT As IntegerField
    Public FTE As FloatField
    Public FULLTIME_FLAG As BooleanField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Alt_FROM_YEAR_LEVEL As IntegerField
    Public Alt_FROM_YEAR_LEVELHref As Object
    Public Alt_FROM_YEAR_LEVELHrefParameters As LinkParameterCollection
    Public Alt_TO_YEAR_LEVEL As IntegerField
    Public Alt_UNIT As IntegerField
    Public Alt_FTE As FloatField
    Public Alt_FULLTIME_FLAG As BooleanField
    Public Alt_LAST_ALTERED_BY As TextField
    Public Alt_LAST_ALTERED_DATE As DateField
    Public Sub New()
    FTE_RULES_Insert = New TextField("",Nothing)
    FTE_RULES_InsertHrefParameters = New LinkParameterCollection()
    FROM_YEAR_LEVEL = New IntegerField("",Nothing)
    FROM_YEAR_LEVELHrefParameters = New LinkParameterCollection()
    TO_YEAR_LEVEL = New IntegerField("", Nothing)
    UNIT = New IntegerField("", Nothing)
    FTE = New FloatField("", Nothing)
    FULLTIME_FLAG = New BooleanField(Settings.BoolFormat, Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    Alt_FROM_YEAR_LEVEL = New IntegerField("",Nothing)
    Alt_FROM_YEAR_LEVELHrefParameters = New LinkParameterCollection()
    Alt_TO_YEAR_LEVEL = New IntegerField("", Nothing)
    Alt_UNIT = New IntegerField("", Nothing)
    Alt_FTE = New FloatField("", Nothing)
    Alt_FULLTIME_FLAG = New BooleanField(Settings.BoolFormat, Nothing)
    Alt_LAST_ALTERED_BY = New TextField("", Nothing)
    Alt_LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "FTE_RULES_Insert"
                    Return Me.FTE_RULES_Insert
                Case "FROM_YEAR_LEVEL"
                    Return Me.FROM_YEAR_LEVEL
                Case "TO_YEAR_LEVEL"
                    Return Me.TO_YEAR_LEVEL
                Case "UNIT"
                    Return Me.UNIT
                Case "FTE"
                    Return Me.FTE
                Case "FULLTIME_FLAG"
                    Return Me.FULLTIME_FLAG
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "Alt_FROM_YEAR_LEVEL"
                    Return Me.Alt_FROM_YEAR_LEVEL
                Case "Alt_TO_YEAR_LEVEL"
                    Return Me.Alt_TO_YEAR_LEVEL
                Case "Alt_UNIT"
                    Return Me.Alt_UNIT
                Case "Alt_FTE"
                    Return Me.Alt_FTE
                Case "Alt_FULLTIME_FLAG"
                    Return Me.Alt_FULLTIME_FLAG
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
                Case "FTE_RULES_Insert"
                    Me.FTE_RULES_Insert = CType(Value,TextField)
                Case "FROM_YEAR_LEVEL"
                    Me.FROM_YEAR_LEVEL = CType(Value,IntegerField)
                Case "TO_YEAR_LEVEL"
                    Me.TO_YEAR_LEVEL = CType(Value,IntegerField)
                Case "UNIT"
                    Me.UNIT = CType(Value,IntegerField)
                Case "FTE"
                    Me.FTE = CType(Value,FloatField)
                Case "FULLTIME_FLAG"
                    Me.FULLTIME_FLAG = CType(Value,BooleanField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "Alt_FROM_YEAR_LEVEL"
                    Me.Alt_FROM_YEAR_LEVEL = CType(Value,IntegerField)
                Case "Alt_TO_YEAR_LEVEL"
                    Me.Alt_TO_YEAR_LEVEL = CType(Value,IntegerField)
                Case "Alt_UNIT"
                    Me.Alt_UNIT = CType(Value,IntegerField)
                Case "Alt_FTE"
                    Me.Alt_FTE = CType(Value,FloatField)
                Case "Alt_FULLTIME_FLAG"
                    Me.Alt_FULLTIME_FLAG = CType(Value,BooleanField)
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
'End Grid FTE_RULES Item Class

'Grid FTE_RULES Data Provider Class Header @2-A4B2FCDF
Public Class FTE_RULESDataProvider
Inherits GridDataProviderBase
'End Grid FTE_RULES Data Provider Class Header

'Grid FTE_RULES Data Provider Class Variables @2-22AD3AD0

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_FROM_YEAR_LEVEL
        Sorter_TO_YEAR_LEVEL
        Sorter_UNIT
        Sorter_FTE
        Sorter_FULLTIME_FLAG
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE
    End Enum

    Private SortFieldsNames As String() = New String() {"","FROM_YEAR_LEVEL","TO_YEAR_LEVEL","UNIT","FTE","FULLTIME_FLAG","LAST_ALTERED_BY","LAST_ALTERED_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"","FROM_YEAR_LEVEL DESC","TO_YEAR_LEVEL DESC","UNIT DESC","FTE DESC","FULLTIME_FLAG DESC","LAST_ALTERED_BY DESC","LAST_ALTERED_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 20
    Public PageNumber As Integer = 1
'End Grid FTE_RULES Data Provider Class Variables

'Grid FTE_RULES Data Provider Class GetResultSet Method @2-848199C0

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} FROM_YEAR_LEVEL, TO_YEAR_LEVEL, UNIT, FTE, " & vbCrLf & _
          "FULLTIME_FLAG, LAST_ALTERED_BY, " & vbCrLf & _
          "LAST_ALTERED_DATE " & vbCrLf & _
          "FROM FTE_RULES {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM FTE_RULES", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid FTE_RULES Data Provider Class GetResultSet Method

'Grid FTE_RULES Data Provider Class GetResultSet Method @2-81C16CD1
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As FTE_RULESItem()
'End Grid FTE_RULES Data Provider Class GetResultSet Method

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

'Execute Select @2-37BE04E5
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As FTE_RULESItem
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

'After execute Select @2-57FB8649
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New FTE_RULESItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-4849F9A5
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as FTE_RULESItem = New FTE_RULESItem()
                item.FTE_RULES_InsertHref = "FTE_RULES_maint.aspx"
                item.FROM_YEAR_LEVEL.SetValue(dr(i)("FROM_YEAR_LEVEL"),"")
                item.FROM_YEAR_LEVELHref = "FTE_RULES_maint.aspx"
                item.FROM_YEAR_LEVELHrefParameters.Add("UNIT",System.Web.HttpUtility.UrlEncode(dr(i)("UNIT").ToString()))
                item.TO_YEAR_LEVEL.SetValue(dr(i)("TO_YEAR_LEVEL"),"")
                item.UNIT.SetValue(dr(i)("UNIT"),"")
                item.FTE.SetValue(dr(i)("FTE"),"")
                item.FULLTIME_FLAG.SetValue(dr(i)("FULLTIME_FLAG"),Select_.BoolFormat)
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.Alt_FROM_YEAR_LEVEL.SetValue(dr(i)("FROM_YEAR_LEVEL"),"")
                item.Alt_FROM_YEAR_LEVELHref = "FTE_RULES_maint.aspx"
                item.Alt_FROM_YEAR_LEVELHrefParameters.Add("UNIT",System.Web.HttpUtility.UrlEncode(dr(i)("UNIT").ToString()))
                item.Alt_TO_YEAR_LEVEL.SetValue(dr(i)("TO_YEAR_LEVEL"),"")
                item.Alt_UNIT.SetValue(dr(i)("UNIT"),"")
                item.Alt_FTE.SetValue(dr(i)("FTE"),"")
                item.Alt_FULLTIME_FLAG.SetValue(dr(i)("FULLTIME_FLAG"),Select_.BoolFormat)
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

