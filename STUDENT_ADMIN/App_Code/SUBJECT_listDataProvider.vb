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

Namespace DECV_PROD2007.SUBJECT_list 'Namespace @1-B68DC725

'Page Data Class @1-1CA1EF9E
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public Sub New()
        Link1 = New TextField("",Nothing)
        Link1HrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Link1.SetValue(DBUtility.GetInitialValue("Link1"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Link1"
                    Return Link1
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link1"
                    Link1 = CType(value, TextField)
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

'Grid SUBJECT Item Class @6-12FE32AA
Public Class SUBJECTItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public SUBJECT_ID As IntegerField
    Public SUBJECT_IDHref As Object
    Public SUBJECT_IDHrefParameters As LinkParameterCollection
    Public SUBJECT_ABBREV As TextField
    Public SUBJECT_TITLE As TextField
    Public STATUS As BooleanField
    Public Alt_SUBJECT_ID As IntegerField
    Public Alt_SUBJECT_IDHref As Object
    Public Alt_SUBJECT_IDHrefParameters As LinkParameterCollection
    Public Alt_SUBJECT_ABBREV As TextField
    Public Alt_SUBJECT_TITLE As TextField
    Public Alt_STATUS As BooleanField
    Public SUBJECT_Insert As TextField
    Public SUBJECT_InsertHref As Object
    Public SUBJECT_InsertHrefParameters As LinkParameterCollection
    Public YEAR_LEVEL As TextField
    Public PARENT_SUBJECT_ID As TextField
    Public YEAR_LEVEL1 As TextField
    Public PARENT_SUBJECT_ID1 As TextField
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public Link2 As TextField
    Public Link2Href As Object
    Public Link2HrefParameters As LinkParameterCollection
    Public CORE_YEARLEVELS As TextField
    Public CORE_YEARLEVELS1 As TextField
    Public ALLOCATE_STUDENTS_MAX As TextField
    Public ALLOCATE_STUDENTS_MAX1 As TextField
    Public Sub New()
    SUBJECT_ID = New IntegerField("",Nothing)
    SUBJECT_IDHrefParameters = New LinkParameterCollection()
    SUBJECT_ABBREV = New TextField("", Nothing)
    SUBJECT_TITLE = New TextField("", Nothing)
    STATUS = New BooleanField(Settings.BoolFormat, Nothing)
    Alt_SUBJECT_ID = New IntegerField("",Nothing)
    Alt_SUBJECT_IDHrefParameters = New LinkParameterCollection()
    Alt_SUBJECT_ABBREV = New TextField("", Nothing)
    Alt_SUBJECT_TITLE = New TextField("", Nothing)
    Alt_STATUS = New BooleanField(Settings.BoolFormat, Nothing)
    SUBJECT_Insert = New TextField("",Nothing)
    SUBJECT_InsertHrefParameters = New LinkParameterCollection()
    YEAR_LEVEL = New TextField("", Nothing)
    PARENT_SUBJECT_ID = New TextField("", Nothing)
    YEAR_LEVEL1 = New TextField("", Nothing)
    PARENT_SUBJECT_ID1 = New TextField("", Nothing)
    Link1 = New TextField("",Nothing)
    Link1HrefParameters = New LinkParameterCollection()
    Link2 = New TextField("",Nothing)
    Link2HrefParameters = New LinkParameterCollection()
    CORE_YEARLEVELS = New TextField("", Nothing)
    CORE_YEARLEVELS1 = New TextField("", Nothing)
    ALLOCATE_STUDENTS_MAX = New TextField("", Nothing)
    ALLOCATE_STUDENTS_MAX1 = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "SUBJECT_ID"
                    Return Me.SUBJECT_ID
                Case "SUBJECT_ABBREV"
                    Return Me.SUBJECT_ABBREV
                Case "SUBJECT_TITLE"
                    Return Me.SUBJECT_TITLE
                Case "STATUS"
                    Return Me.STATUS
                Case "Alt_SUBJECT_ID"
                    Return Me.Alt_SUBJECT_ID
                Case "Alt_SUBJECT_ABBREV"
                    Return Me.Alt_SUBJECT_ABBREV
                Case "Alt_SUBJECT_TITLE"
                    Return Me.Alt_SUBJECT_TITLE
                Case "Alt_STATUS"
                    Return Me.Alt_STATUS
                Case "SUBJECT_Insert"
                    Return Me.SUBJECT_Insert
                Case "YEAR_LEVEL"
                    Return Me.YEAR_LEVEL
                Case "PARENT_SUBJECT_ID"
                    Return Me.PARENT_SUBJECT_ID
                Case "YEAR_LEVEL1"
                    Return Me.YEAR_LEVEL1
                Case "PARENT_SUBJECT_ID1"
                    Return Me.PARENT_SUBJECT_ID1
                Case "Link1"
                    Return Me.Link1
                Case "Link2"
                    Return Me.Link2
                Case "CORE_YEARLEVELS"
                    Return Me.CORE_YEARLEVELS
                Case "CORE_YEARLEVELS1"
                    Return Me.CORE_YEARLEVELS1
                Case "ALLOCATE_STUDENTS_MAX"
                    Return Me.ALLOCATE_STUDENTS_MAX
                Case "ALLOCATE_STUDENTS_MAX1"
                    Return Me.ALLOCATE_STUDENTS_MAX1
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SUBJECT_ID"
                    Me.SUBJECT_ID = CType(Value,IntegerField)
                Case "SUBJECT_ABBREV"
                    Me.SUBJECT_ABBREV = CType(Value,TextField)
                Case "SUBJECT_TITLE"
                    Me.SUBJECT_TITLE = CType(Value,TextField)
                Case "STATUS"
                    Me.STATUS = CType(Value,BooleanField)
                Case "Alt_SUBJECT_ID"
                    Me.Alt_SUBJECT_ID = CType(Value,IntegerField)
                Case "Alt_SUBJECT_ABBREV"
                    Me.Alt_SUBJECT_ABBREV = CType(Value,TextField)
                Case "Alt_SUBJECT_TITLE"
                    Me.Alt_SUBJECT_TITLE = CType(Value,TextField)
                Case "Alt_STATUS"
                    Me.Alt_STATUS = CType(Value,BooleanField)
                Case "SUBJECT_Insert"
                    Me.SUBJECT_Insert = CType(Value,TextField)
                Case "YEAR_LEVEL"
                    Me.YEAR_LEVEL = CType(Value,TextField)
                Case "PARENT_SUBJECT_ID"
                    Me.PARENT_SUBJECT_ID = CType(Value,TextField)
                Case "YEAR_LEVEL1"
                    Me.YEAR_LEVEL1 = CType(Value,TextField)
                Case "PARENT_SUBJECT_ID1"
                    Me.PARENT_SUBJECT_ID1 = CType(Value,TextField)
                Case "Link1"
                    Me.Link1 = CType(Value,TextField)
                Case "Link2"
                    Me.Link2 = CType(Value,TextField)
                Case "CORE_YEARLEVELS"
                    Me.CORE_YEARLEVELS = CType(Value,TextField)
                Case "CORE_YEARLEVELS1"
                    Me.CORE_YEARLEVELS1 = CType(Value,TextField)
                Case "ALLOCATE_STUDENTS_MAX"
                    Me.ALLOCATE_STUDENTS_MAX = CType(Value,TextField)
                Case "ALLOCATE_STUDENTS_MAX1"
                    Me.ALLOCATE_STUDENTS_MAX1 = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid SUBJECT Item Class

'Grid SUBJECT Data Provider Class Header @6-0DD17C44
Public Class SUBJECTDataProvider
Inherits GridDataProviderBase
'End Grid SUBJECT Data Provider Class Header

'Grid SUBJECT Data Provider Class Variables @6-B36F6592

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_SUBJECT_ID
        Sorter_SUBJECT_ABBREV
        Sorter_SUBJECT_TITLE
        Sorter_STATUS
        Sorter_Yearlevel
        Sorter_DefaultTeacherID
        SorterCore
        Sorter_ALLOCATE_STUDENTS_MAX
    End Enum

    Private SortFieldsNames As String() = New String() {"","SUBJECT_ID","SUBJECT_ABBREV","SUBJECT_TITLE","STATUS","YEAR_LEVEL","DEFAULT_TEACHER_ID","CORE_YEARLEVELS","ALLOCATE_STUDENTS_MAX"}
    Private SortFieldsNamesDesc As String() = New string() {"","SUBJECT_ID DESC","SUBJECT_ABBREV DESC","SUBJECT_TITLE DESC","STATUS DESC","YEAR_LEVEL DESC","DEFAULT_TEACHER_ID DESC","CORE_YEARLEVELS DESC","ALLOCATE_STUDENTS_MAX DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 50
    Public PageNumber As Integer = 1
    Public Urls_yearlevel  As IntegerParameter
    Public Urls_subject_id  As IntegerParameter
    Public Urls_keyword  As TextParameter
    Public Urls_status  As IntegerParameter
'End Grid SUBJECT Data Provider Class Variables

'Grid SUBJECT Data Provider Class GetResultSet Method @6-1A8D8B08

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} SUBJECT_ID, SUBJECT_ABBREV, SUBJECT_TITLE, STATUS, " & vbCrLf & _
          "DEFAULT_TEACHER_ID, YEAR_LEVEL, LAST_ALTERED_BY, LAST_ALTERED_DATE, " & vbCrLf & _
          "CORE_YEARLEVELS," & vbCrLf & _
          "ALLOCATE_STUDENTS_MAX, " & vbCrLf & _
          "PARENT_SUBJECT_ID " & vbCrLf & _
          "FROM SUBJECT {SQL_Where} {SQL_OrderBy}", New String(){"(","s_yearlevel227","Or","(","s_keyword228","Or","s_subject_id229","Or","s_keyword230","Or","s_keyword231",")",")","And","s_status232"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM SUBJECT", New String(){"(","s_yearlevel227","Or","(","s_keyword228","Or","s_subject_id229","Or","s_keyword230","Or","s_keyword231",")",")","And","s_status232"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid SUBJECT Data Provider Class GetResultSet Method

'Grid SUBJECT Data Provider Class GetResultSet Method @6-40D1E8E8
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As SUBJECTItem()
'End Grid SUBJECT Data Provider Class GetResultSet Method

'Grid SUBJECT Event BeforeBuildSelect. Action Advanced Search @47-0B6BF48C
        Select_.Parameters.Clear()
        DBUtility.ManageAdvancedSearch(Select_, _ 
	                                   New String() {"SUBJECT_ID","SUBJECT_ABBREV","SUBJECT_TITLE","YEAR_LEVEL"}, _
	                                   System.Web.HttpContext.Current.Request("searchConditions"), _
	                                   System.Web.HttpContext.Current.Request("s_keyword"))
        CType(Count, TableCommand).WhereTemplate = CType(Select_, TableCommand).WhereTemplate
'End Grid SUBJECT Event BeforeBuildSelect. Action Advanced Search

'Before build Select @6-B9FB18FE
        Dim E as Exception = Nothing
        CType(Select_,TableCommand).AddParameter("s_yearlevel227",Urls_yearlevel, "","YEAR_LEVEL",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("s_keyword228",Urls_keyword, "","SUBJECT_ABBREV",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_subject_id229",Urls_subject_id, "","SUBJECT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("s_keyword230",Urls_keyword, "","SUBJECT_TITLE_NEW",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword231",Urls_keyword, "","SUBJECT_TITLE",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_status232",Urls_status, "","STATUS",Condition.Equal,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @6-C3D26DF9
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

'After execute Select @6-A15FCA2A
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New SUBJECTItem(dr.Count-1) {}
'End After execute Select

'After execute Select @6-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @6-6030B959
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as SUBJECTItem = New SUBJECTItem()
                item.SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
                item.SUBJECT_IDHref = "SUBJECT_maint.aspx"
                item.SUBJECT_IDHrefParameters.Add("SUBJECT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("SUBJECT_ID").ToString()))
                item.SUBJECT_ABBREV.SetValue(dr(i)("SUBJECT_ABBREV"),"")
                item.SUBJECT_TITLE.SetValue(dr(i)("SUBJECT_TITLE"),"")
                item.STATUS.SetValue(dr(i)("STATUS"),Select_.BoolFormat)
                item.Alt_SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
                item.Alt_SUBJECT_IDHref = "SUBJECT_maint.aspx"
                item.Alt_SUBJECT_IDHrefParameters.Add("SUBJECT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("SUBJECT_ID").ToString()))
                item.Alt_SUBJECT_ABBREV.SetValue(dr(i)("SUBJECT_ABBREV"),"")
                item.Alt_SUBJECT_TITLE.SetValue(dr(i)("SUBJECT_TITLE"),"")
                item.Alt_STATUS.SetValue(dr(i)("STATUS"),Select_.BoolFormat)
                item.SUBJECT_InsertHref = "SUBJECT_maint.aspx"
                item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
                item.PARENT_SUBJECT_ID.SetValue(dr(i)("PARENT_SUBJECT_ID"),"")
                item.YEAR_LEVEL1.SetValue(dr(i)("YEAR_LEVEL"),"")
                item.PARENT_SUBJECT_ID1.SetValue(dr(i)("PARENT_SUBJECT_ID"),"")
                item.Link1Href = "StudentSubject_TeacherStats.aspx"
                item.Link1HrefParameters.Add("SUBJECT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("SUBJECT_ID").ToString()))
                item.Link1HrefParameters.Add("SUBJECT_ABBREV",System.Web.HttpUtility.UrlEncode(dr(i)("SUBJECT_ABBREV").ToString()))
                item.Link2Href = "StudentSubject_TeacherStats.aspx"
                item.Link2HrefParameters.Add("SUBJECT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("SUBJECT_ID").ToString()))
                item.Link2HrefParameters.Add("SUBJECT_ABBREV",System.Web.HttpUtility.UrlEncode(dr(i)("SUBJECT_ABBREV").ToString()))
                item.CORE_YEARLEVELS.SetValue(dr(i)("CORE_YEARLEVELS"),"")
                item.CORE_YEARLEVELS1.SetValue(dr(i)("CORE_YEARLEVELS"),"")
                item.ALLOCATE_STUDENTS_MAX.SetValue(dr(i)("ALLOCATE_STUDENTS_MAX"),"")
                item.ALLOCATE_STUDENTS_MAX1.SetValue(dr(i)("ALLOCATE_STUDENTS_MAX"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @6-A61BA892
End Class
'End Grid Data Provider tail

'Record SUBJECT1 Item Class @41-BB1F4307
Public Class SUBJECT1Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public s_keyword As TextField
    Public s_yearlevel As TextField
    Public s_yearlevelItems As ItemCollection
    Public s_status As IntegerField
    Public s_statusItems As ItemCollection
    Public s_subject_id As TextField
    Public Sub New()
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    s_keyword = New TextField("", Nothing)
    s_yearlevel = New TextField("", Nothing)
    s_yearlevelItems = New ItemCollection()
    s_status = New IntegerField("", 1)
    s_statusItems = New ItemCollection()
    s_subject_id = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As SUBJECT1Item
        Dim item As SUBJECT1Item = New SUBJECT1Item()
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_keyword")) Then
        item.s_keyword.SetValue(DBUtility.GetInitialValue("s_keyword"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_yearlevel")) Then
        item.s_yearlevel.SetValue(DBUtility.GetInitialValue("s_yearlevel"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_status")) Then
        item.s_status.SetValue(DBUtility.GetInitialValue("s_status"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_subject_id")) Then
        item.s_subject_id.SetValue(DBUtility.GetInitialValue("s_subject_id"))
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
                Case "s_yearlevel"
                    Return s_yearlevel
                Case "s_status"
                    Return s_status
                Case "s_subject_id"
                    Return s_subject_id
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
                Case "s_yearlevel"
                    s_yearlevel = CType(value, TextField)
                Case "s_status"
                    s_status = CType(value, IntegerField)
                Case "s_subject_id"
                    s_subject_id = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As SUBJECT1DataProvider)
'End Record SUBJECT1 Item Class

'Record SUBJECT1 Item Class tail @41-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record SUBJECT1 Item Class tail

'Record SUBJECT1 Data Provider Class @41-08F49A61
Public Class SUBJECT1DataProvider
Inherits RecordDataProviderBase
'End Record SUBJECT1 Data Provider Class

'Record SUBJECT1 Data Provider Class Variables @41-68AAFDF1
    Protected item As SUBJECT1Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record SUBJECT1 Data Provider Class Variables

'Record SUBJECT1 Data Provider Class GetResultSet Method @41-A144EE06

    Public Sub FillItem(ByVal item As SUBJECT1Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record SUBJECT1 Data Provider Class GetResultSet Method

'Record SUBJECT1 BeforeBuildSelect @41-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record SUBJECT1 BeforeBuildSelect

'Record SUBJECT1 AfterExecuteSelect @41-79426A21
        End If
            IsInsertMode = True
'End Record SUBJECT1 AfterExecuteSelect

'ListBox s_yearlevel AfterExecuteSelect @48-69450170
        
item.s_yearlevelItems.Add("0","0 - Prep")
item.s_yearlevelItems.Add("1","1")
item.s_yearlevelItems.Add("2","2")
item.s_yearlevelItems.Add("3","3")
item.s_yearlevelItems.Add("4","4")
item.s_yearlevelItems.Add("5","5")
item.s_yearlevelItems.Add("6","6")
item.s_yearlevelItems.Add("7","7")
item.s_yearlevelItems.Add("8","8")
item.s_yearlevelItems.Add("9","9")
item.s_yearlevelItems.Add("10","10")
item.s_yearlevelItems.Add("11","11")
item.s_yearlevelItems.Add("12","12")
item.s_yearlevelItems.Add("30","Home Schooled")
'End ListBox s_yearlevel AfterExecuteSelect

'ListBox s_status AfterExecuteSelect @58-67CB6CBB
        
item.s_statusItems.Add("1","Active")
item.s_statusItems.Add("0","Inactive")
'End ListBox s_status AfterExecuteSelect

'Record SUBJECT1 AfterExecuteSelect tail @41-E31F8E2A
    End Sub
'End Record SUBJECT1 AfterExecuteSelect tail

'Record SUBJECT1 Data Provider Class @41-A61BA892
End Class

'End Record SUBJECT1 Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

