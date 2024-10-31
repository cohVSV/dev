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

Namespace DECV_PROD2007.SCHOOL_list 'Namespace @1-FB143B6E

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

'Record SCHOOLSearch Item Class @67-0AE0A48A
Public Class SCHOOLSearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_keyword As TextField
    Public lbSCHOOL_TYPE As TextField
    Public lbSCHOOL_TYPEItems As ItemCollection
    Public Sub New()
    s_keyword = New TextField("", Nothing)
    lbSCHOOL_TYPE = New TextField("", "")
    lbSCHOOL_TYPEItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As SCHOOLSearchItem
        Dim item As SCHOOLSearchItem = New SCHOOLSearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("s_keyword")) Then
        item.s_keyword.SetValue(DBUtility.GetInitialValue("s_keyword"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbSCHOOL_TYPE")) Then
        item.lbSCHOOL_TYPE.SetValue(DBUtility.GetInitialValue("lbSCHOOL_TYPE"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_keyword"
                    Return s_keyword
                Case "lbSCHOOL_TYPE"
                    Return lbSCHOOL_TYPE
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_keyword"
                    s_keyword = CType(value, TextField)
                Case "lbSCHOOL_TYPE"
                    lbSCHOOL_TYPE = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As SCHOOLSearchDataProvider)
'End Record SCHOOLSearch Item Class

'Record SCHOOLSearch Item Class tail @67-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record SCHOOLSearch Item Class tail

'Record SCHOOLSearch Data Provider Class @67-7B5819F0
Public Class SCHOOLSearchDataProvider
Inherits RecordDataProviderBase
'End Record SCHOOLSearch Data Provider Class

'Record SCHOOLSearch Data Provider Class Variables @67-12B9C143
    Protected lbSCHOOL_TYPEDataCommand As DataCommand=new TableCommand("SELECT SCHOOL_TYPE_CODE, " & vbCrLf & _
          "SCHOOL_TYPE_DESCRIPTION " & vbCrLf & _
          "FROM SCHOOL_TYPE {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected item As SCHOOLSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record SCHOOLSearch Data Provider Class Variables

'Record SCHOOLSearch Data Provider Class GetResultSet Method @67-094F59DC

    Public Sub FillItem(ByVal item As SCHOOLSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record SCHOOLSearch Data Provider Class GetResultSet Method

'Record SCHOOLSearch BeforeBuildSelect @67-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record SCHOOLSearch BeforeBuildSelect

'Record SCHOOLSearch AfterExecuteSelect @67-83591636
        End If
            IsInsertMode = True
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record SCHOOLSearch AfterExecuteSelect

'ListBox lbSCHOOL_TYPE Initialize Data Source @91-0098848A
        lbSCHOOL_TYPEDataCommand.Dao._optimized = False
        Dim lbSCHOOL_TYPEtableIndex As Integer = 0
        lbSCHOOL_TYPEDataCommand.OrderBy = "SCHOOL_TYPE_CODE"
        lbSCHOOL_TYPEDataCommand.Parameters.Clear()
'End ListBox lbSCHOOL_TYPE Initialize Data Source

'ListBox lbSCHOOL_TYPE BeforeExecuteSelect @91-1B2BB541
        Try
            ListBoxSource=lbSCHOOL_TYPEDataCommand.Execute().Tables(lbSCHOOL_TYPEtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox lbSCHOOL_TYPE BeforeExecuteSelect

'ListBox lbSCHOOL_TYPE AfterExecuteSelect @91-B56506F7
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("SCHOOL_TYPE_CODE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("SCHOOL_TYPE_DESCRIPTION")
            item.lbSCHOOL_TYPEItems.Add(Key, Val)
        Next
'End ListBox lbSCHOOL_TYPE AfterExecuteSelect

'Record SCHOOLSearch AfterExecuteSelect tail @67-E31F8E2A
    End Sub
'End Record SCHOOLSearch AfterExecuteSelect tail

'Record SCHOOLSearch Data Provider Class @67-A61BA892
End Class

'End Record SCHOOLSearch Data Provider Class

'Grid SCHOOL Item Class @66-76EC1F05
Public Class SCHOOLItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public SCHOOL_ID As FloatField
    Public SCHOOL_IDHref As Object
    Public SCHOOL_IDHrefParameters As LinkParameterCollection
    Public SCHOOL_NAME As TextField
    Public REGION_ID As FloatField
    Public METRO_CATEGORY As BooleanField
    Public STATUS As BooleanField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public link_AnotherNewSchool As TextField
    Public link_AnotherNewSchoolHref As Object
    Public link_AnotherNewSchoolHrefParameters As LinkParameterCollection
    Public link_NewSchool As TextField
    Public link_NewSchoolHref As Object
    Public link_NewSchoolHrefParameters As LinkParameterCollection
    Public SCHOOL_TYPE_CODE As TextField
    Public Sub New()
    SCHOOL_ID = New FloatField("0.00",Nothing)
    SCHOOL_IDHrefParameters = New LinkParameterCollection()
    SCHOOL_NAME = New TextField("", Nothing)
    REGION_ID = New FloatField("", Nothing)
    METRO_CATEGORY = New BooleanField(Settings.BoolFormat, Nothing)
    STATUS = New BooleanField(Settings.BoolFormat, Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    link_AnotherNewSchool = New TextField("",Nothing)
    link_AnotherNewSchoolHrefParameters = New LinkParameterCollection()
    link_NewSchool = New TextField("",Nothing)
    link_NewSchoolHrefParameters = New LinkParameterCollection()
    SCHOOL_TYPE_CODE = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "SCHOOL_ID"
                    Return Me.SCHOOL_ID
                Case "SCHOOL_NAME"
                    Return Me.SCHOOL_NAME
                Case "REGION_ID"
                    Return Me.REGION_ID
                Case "METRO_CATEGORY"
                    Return Me.METRO_CATEGORY
                Case "STATUS"
                    Return Me.STATUS
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "link_AnotherNewSchool"
                    Return Me.link_AnotherNewSchool
                Case "link_NewSchool"
                    Return Me.link_NewSchool
                Case "SCHOOL_TYPE_CODE"
                    Return Me.SCHOOL_TYPE_CODE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SCHOOL_ID"
                    Me.SCHOOL_ID = CType(Value,FloatField)
                Case "SCHOOL_NAME"
                    Me.SCHOOL_NAME = CType(Value,TextField)
                Case "REGION_ID"
                    Me.REGION_ID = CType(Value,FloatField)
                Case "METRO_CATEGORY"
                    Me.METRO_CATEGORY = CType(Value,BooleanField)
                Case "STATUS"
                    Me.STATUS = CType(Value,BooleanField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "link_AnotherNewSchool"
                    Me.link_AnotherNewSchool = CType(Value,TextField)
                Case "link_NewSchool"
                    Me.link_NewSchool = CType(Value,TextField)
                Case "SCHOOL_TYPE_CODE"
                    Me.SCHOOL_TYPE_CODE = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid SCHOOL Item Class

'Grid SCHOOL Data Provider Class Header @66-AED79F2B
Public Class SCHOOLDataProvider
Inherits GridDataProviderBase
'End Grid SCHOOL Data Provider Class Header

'Grid SCHOOL Data Provider Class Variables @66-B20D42D3

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_SCHOOL_ID
        Sorter_SCHOOL_NAME
        Sorter_REGION_ID
        Sorter_METRO_CATEGORY
        Sorter_STATUS
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE
    End Enum

    Private SortFieldsNames As String() = New String() {"SCHOOL_NAME","SCHOOL_ID","SCHOOL_NAME","REGION_ID","METRO_CATEGORY","STATUS","LAST_ALTERED_BY","LAST_ALTERED_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"SCHOOL_NAME","SCHOOL_ID DESC","SCHOOL_NAME DESC","REGION_ID DESC","METRO_CATEGORY DESC","STATUS DESC","LAST_ALTERED_BY DESC","LAST_ALTERED_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 20
    Public PageNumber As Integer = 1
    Public Urls_keyword  As TextParameter
    Public UrllbSCHOOL_TYPE  As TextParameter
'End Grid SCHOOL Data Provider Class Variables

'Grid SCHOOL Data Provider Class GetResultSet Method @66-51F460FB

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM SCHOOL {SQL_Where} {SQL_OrderBy}", New String(){"(","s_keyword104","Or","s_keyword105","Or","s_keyword106",")","And","lbSCHOOL_TYPE107"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM SCHOOL", New String(){"(","s_keyword104","Or","s_keyword105","Or","s_keyword106",")","And","lbSCHOOL_TYPE107"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid SCHOOL Data Provider Class GetResultSet Method

'Grid SCHOOL Data Provider Class GetResultSet Method @66-87B1CE2C
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As SCHOOLItem()
'End Grid SCHOOL Data Provider Class GetResultSet Method

'Before build Select @66-C480EE9A
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_keyword104",Urls_keyword, "","SCHOOL_ID",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword105",Urls_keyword, "","REGION_ID",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword106",Urls_keyword, "","SCHOOL_NAME",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("lbSCHOOL_TYPE107",UrllbSCHOOL_TYPE, "","SCHOOL_TYPE_CODE",Condition.Equal,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @66-B3CC5F90
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

'After execute Select @66-573BD7AF
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New SCHOOLItem(dr.Count-1) {}
'End After execute Select

'After execute Select @66-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @66-AAABED1C
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as SCHOOLItem = New SCHOOLItem()
                item.SCHOOL_ID.SetValue(dr(i)("SCHOOL_ID"),"")
                item.SCHOOL_IDHref = "SCHOOL_maint.aspx"
                item.SCHOOL_IDHrefParameters.Add("SCHOOL_ID",System.Web.HttpUtility.UrlEncode(dr(i)("SCHOOL_ID").ToString()))
                item.SCHOOL_NAME.SetValue(dr(i)("SCHOOL_NAME"),"")
                item.REGION_ID.SetValue(dr(i)("REGION_ID"),"")
                item.METRO_CATEGORY.SetValue(dr(i)("METRO_CATEGORY"),Select_.BoolFormat)
                item.STATUS.SetValue(dr(i)("STATUS"),Select_.BoolFormat)
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.link_AnotherNewSchoolHref = "SCHOOL_maint.aspx"
                item.link_NewSchoolHref = "SCHOOL_maint.aspx"
                item.SCHOOL_TYPE_CODE.SetValue(dr(i)("SCHOOL_TYPE_CODE"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @66-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

