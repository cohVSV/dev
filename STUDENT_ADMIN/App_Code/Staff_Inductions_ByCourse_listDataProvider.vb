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

Namespace DECV_PROD2007.Staff_Inductions_ByCourse_list 'Namespace @1-A84709B5

'Page Data Class @1-70E1EB13
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Link_AddNEw As TextField
    Public Link_AddNEwHref As Object
    Public Link_AddNEwHrefParameters As LinkParameterCollection
    Public Sub New()
        Link_AddNEw = New TextField("",Nothing)
        Link_AddNEwHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Link_AddNEw.SetValue(DBUtility.GetInitialValue("Link_AddNEw"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Link_AddNEw"
                    Return Link_AddNEw
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link_AddNEw"
                    Link_AddNEw = CType(value, TextField)
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

'Grid STAFF_INDUCTIONS_COURSES Item Class @3-E32A0191
Public Class STAFF_INDUCTIONS_COURSESItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STAFF_INDUCTIONS_COURSES_TotalRecords As TextField
    Public id As IntegerField
    Public idHref As Object
    Public idHrefParameters As LinkParameterCollection
    Public INDUCTION_TITLE As TextField
    Public INDUCTION_TITLEHref As Object
    Public INDUCTION_TITLEHrefParameters As LinkParameterCollection
    Public INDUCTION_DESCRIPTION As TextField
    Public STATUS As IntegerField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    STAFF_INDUCTIONS_COURSES_TotalRecords = New TextField("", Nothing)
    id = New IntegerField("",Nothing)
    idHrefParameters = New LinkParameterCollection()
    INDUCTION_TITLE = New TextField("",Nothing)
    INDUCTION_TITLEHrefParameters = New LinkParameterCollection()
    INDUCTION_DESCRIPTION = New TextField("", Nothing)
    STATUS = New IntegerField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STAFF_INDUCTIONS_COURSES_TotalRecords"
                    Return Me.STAFF_INDUCTIONS_COURSES_TotalRecords
                Case "id"
                    Return Me.id
                Case "INDUCTION_TITLE"
                    Return Me.INDUCTION_TITLE
                Case "INDUCTION_DESCRIPTION"
                    Return Me.INDUCTION_DESCRIPTION
                Case "STATUS"
                    Return Me.STATUS
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STAFF_INDUCTIONS_COURSES_TotalRecords"
                    Me.STAFF_INDUCTIONS_COURSES_TotalRecords = CType(Value,TextField)
                Case "id"
                    Me.id = CType(Value,IntegerField)
                Case "INDUCTION_TITLE"
                    Me.INDUCTION_TITLE = CType(Value,TextField)
                Case "INDUCTION_DESCRIPTION"
                    Me.INDUCTION_DESCRIPTION = CType(Value,TextField)
                Case "STATUS"
                    Me.STATUS = CType(Value,IntegerField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STAFF_INDUCTIONS_COURSES Item Class

'Grid STAFF_INDUCTIONS_COURSES Data Provider Class Header @3-AE5CE310
Public Class STAFF_INDUCTIONS_COURSESDataProvider
Inherits GridDataProviderBase
'End Grid STAFF_INDUCTIONS_COURSES Data Provider Class Header

'Grid STAFF_INDUCTIONS_COURSES Data Provider Class Variables @3-F6E50BFB

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_INDUCTION_TITLE
        Sorter_INDUCTION_DESCRIPTION
        Sorter_STATUS
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE
    End Enum

    Private SortFieldsNames As String() = New String() {"","INDUCTION_TITLE","INDUCTION_DESCRIPTION","STATUS","LAST_ALTERED_BY","LAST_ALTERED_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"","INDUCTION_TITLE DESC","INDUCTION_DESCRIPTION DESC","STATUS DESC","LAST_ALTERED_BY DESC","LAST_ALTERED_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 30
    Public PageNumber As Integer = 1
    Public Urls_INDUCTION_TITLE  As TextParameter
    Public Urls_STATUS  As IntegerParameter
'End Grid STAFF_INDUCTIONS_COURSES Data Provider Class Variables

'Grid STAFF_INDUCTIONS_COURSES Data Provider Class GetResultSet Method @3-E50F789C

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM STAFF_INDUCTIONS_COURSES {SQL_Where} {SQL_OrderBy}", New String(){"(","s_INDUCTION_TITLE11","Or","s_INDUCTION_TITLE27",")","And","s_STATUS12"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STAFF_INDUCTIONS_COURSES", New String(){"(","s_INDUCTION_TITLE11","Or","s_INDUCTION_TITLE27",")","And","s_STATUS12"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid STAFF_INDUCTIONS_COURSES Data Provider Class GetResultSet Method

'Grid STAFF_INDUCTIONS_COURSES Data Provider Class GetResultSet Method @3-07805B69
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STAFF_INDUCTIONS_COURSESItem()
'End Grid STAFF_INDUCTIONS_COURSES Data Provider Class GetResultSet Method

'Before build Select @3-2DCA0AB4
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_INDUCTION_TITLE11",Urls_INDUCTION_TITLE, "","INDUCTION_TITLE",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_INDUCTION_TITLE27",Urls_INDUCTION_TITLE, "","INDUCTION_DESCRIPTION",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_STATUS12",Urls_STATUS, "","STATUS",Condition.Equal,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @3-92BB4A6F
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STAFF_INDUCTIONS_COURSESItem
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

'After execute Select @3-9C6FCB18
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STAFF_INDUCTIONS_COURSESItem(dr.Count-1) {}
'End After execute Select

'After execute Select @3-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @3-34289055
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STAFF_INDUCTIONS_COURSESItem = New STAFF_INDUCTIONS_COURSESItem()
                item.id.SetValue(dr(i)("id"),"")
                item.idHref = "Staff_Inductions_ByCourse_maint.aspx"
                item.idHrefParameters.Add("id",System.Web.HttpUtility.UrlEncode(dr(i)("id").ToString()))
                item.INDUCTION_TITLE.SetValue(dr(i)("INDUCTION_TITLE"),"")
                item.INDUCTION_TITLEHref = "Staff_Inductions_ByCourse_maint.aspx"
                item.INDUCTION_TITLEHrefParameters.Add("id",System.Web.HttpUtility.UrlEncode(dr(i)("id").ToString()))
                item.INDUCTION_DESCRIPTION.SetValue(dr(i)("INDUCTION_DESCRIPTION"),"")
                item.STATUS.SetValue(dr(i)("STATUS"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @3-A61BA892
End Class
'End Grid Data Provider tail

'Record STAFF_INDUCTIONS_COURSESSearch Item Class @4-5C27DE15
Public Class STAFF_INDUCTIONS_COURSESSearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public s_INDUCTION_TITLE As TextField
    Public s_STATUS As IntegerField
    Public s_STATUSItems As ItemCollection
    Public Sub New()
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    s_INDUCTION_TITLE = New TextField("", Nothing)
    s_STATUS = New IntegerField("", 1)
    s_STATUSItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As STAFF_INDUCTIONS_COURSESSearchItem
        Dim item As STAFF_INDUCTIONS_COURSESSearchItem = New STAFF_INDUCTIONS_COURSESSearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_INDUCTION_TITLE")) Then
        item.s_INDUCTION_TITLE.SetValue(DBUtility.GetInitialValue("s_INDUCTION_TITLE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_STATUS")) Then
        item.s_STATUS.SetValue(DBUtility.GetInitialValue("s_STATUS"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "ClearParameters"
                    Return ClearParameters
                Case "s_INDUCTION_TITLE"
                    Return s_INDUCTION_TITLE
                Case "s_STATUS"
                    Return s_STATUS
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ClearParameters"
                    ClearParameters = CType(value, TextField)
                Case "s_INDUCTION_TITLE"
                    s_INDUCTION_TITLE = CType(value, TextField)
                Case "s_STATUS"
                    s_STATUS = CType(value, IntegerField)
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

    Public Sub Validate(ByVal provider As STAFF_INDUCTIONS_COURSESSearchDataProvider)
'End Record STAFF_INDUCTIONS_COURSESSearch Item Class

'Record STAFF_INDUCTIONS_COURSESSearch Item Class tail @4-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STAFF_INDUCTIONS_COURSESSearch Item Class tail

'Record STAFF_INDUCTIONS_COURSESSearch Data Provider Class @4-FC40089F
Public Class STAFF_INDUCTIONS_COURSESSearchDataProvider
Inherits RecordDataProviderBase
'End Record STAFF_INDUCTIONS_COURSESSearch Data Provider Class

'Record STAFF_INDUCTIONS_COURSESSearch Data Provider Class Variables @4-7CD885D5
    Protected item As STAFF_INDUCTIONS_COURSESSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STAFF_INDUCTIONS_COURSESSearch Data Provider Class Variables

'Record STAFF_INDUCTIONS_COURSESSearch Data Provider Class GetResultSet Method @4-9076BA6B

    Public Sub FillItem(ByVal item As STAFF_INDUCTIONS_COURSESSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STAFF_INDUCTIONS_COURSESSearch Data Provider Class GetResultSet Method

'Record STAFF_INDUCTIONS_COURSESSearch BeforeBuildSelect @4-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STAFF_INDUCTIONS_COURSESSearch BeforeBuildSelect

'Record STAFF_INDUCTIONS_COURSESSearch AfterExecuteSelect @4-79426A21
        End If
            IsInsertMode = True
'End Record STAFF_INDUCTIONS_COURSESSearch AfterExecuteSelect

'ListBox s_STATUS AfterExecuteSelect @8-E95CD1E9
        
item.s_STATUSItems.Add("1","Active")
item.s_STATUSItems.Add("0","Inactive")
'End ListBox s_STATUS AfterExecuteSelect

'Record STAFF_INDUCTIONS_COURSESSearch AfterExecuteSelect tail @4-E31F8E2A
    End Sub
'End Record STAFF_INDUCTIONS_COURSESSearch AfterExecuteSelect tail

'Record STAFF_INDUCTIONS_COURSESSearch Data Provider Class @4-A61BA892
End Class

'End Record STAFF_INDUCTIONS_COURSESSearch Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

