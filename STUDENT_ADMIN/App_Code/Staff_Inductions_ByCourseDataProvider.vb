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

Namespace DECV_PROD2007.Staff_Inductions_ByCourse 'Namespace @1-8BAAC521

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

'Grid STAFF_INDUCTIONS_COURSES Item Class @3-E31EE231
Public Class STAFF_INDUCTIONS_COURSESItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STAFF_INDUCTIONS_COURSES_TotalRecords As TextField
    Public id As IntegerField
    Public idHref As Object
    Public idHrefParameters As LinkParameterCollection
    Public INDUCTION_TITLE As TextField
    Public STATUS As IntegerField
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public Sub New()
    STAFF_INDUCTIONS_COURSES_TotalRecords = New TextField("", Nothing)
    id = New IntegerField("",Nothing)
    idHrefParameters = New LinkParameterCollection()
    INDUCTION_TITLE = New TextField("", Nothing)
    STATUS = New IntegerField("", Nothing)
    Link1 = New TextField("",Nothing)
    Link1HrefParameters = New LinkParameterCollection()
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
                Case "STATUS"
                    Return Me.STATUS
                Case "Link1"
                    Return Me.Link1
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
                Case "STATUS"
                    Me.STATUS = CType(Value,IntegerField)
                Case "Link1"
                    Me.Link1 = CType(Value,TextField)
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

'Grid STAFF_INDUCTIONS_COURSES Data Provider Class Variables @3-6E7ACC24

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_id
        Sorter_INDUCTION_TITLE
        Sorter_STATUS
    End Enum

    Private SortFieldsNames As String() = New String() {"INDUCTION_TITLE","id","INDUCTION_TITLE","STATUS"}
    Private SortFieldsNamesDesc As String() = New string() {"INDUCTION_TITLE","id DESC","INDUCTION_TITLE DESC","STATUS DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 30
    Public PageNumber As Integer = 1
    Public Urls_keyword  As TextParameter
'End Grid STAFF_INDUCTIONS_COURSES Data Provider Class Variables

'Grid STAFF_INDUCTIONS_COURSES Data Provider Class GetResultSet Method @3-626D1DF1

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM STAFF_INDUCTIONS_COURSES {SQL_Where} {SQL_OrderBy}", New String(){"(","s_keyword10","Or","s_keyword11",")"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STAFF_INDUCTIONS_COURSES", New String(){"(","s_keyword10","Or","s_keyword11",")"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid STAFF_INDUCTIONS_COURSES Data Provider Class GetResultSet Method

'Grid STAFF_INDUCTIONS_COURSES Data Provider Class GetResultSet Method @3-07805B69
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STAFF_INDUCTIONS_COURSESItem()
'End Grid STAFF_INDUCTIONS_COURSES Data Provider Class GetResultSet Method

'Before build Select @3-4E468B4D
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_keyword10",Urls_keyword, "","INDUCTION_TITLE",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword11",Urls_keyword, "","INDUCTION_DESCRIPTION",Condition.Contains,False)
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

'After execute Select tail @3-7845625D
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STAFF_INDUCTIONS_COURSESItem = New STAFF_INDUCTIONS_COURSESItem()
                item.id.SetValue(dr(i)("id"),"")
                item.idHref = "Staff_Inductions_ByCourse.aspx"
                item.idHrefParameters.Add("ind_id",System.Web.HttpUtility.UrlEncode(dr(i)("id").ToString()))
                item.INDUCTION_TITLE.SetValue(dr(i)("INDUCTION_TITLE"),"")
                item.STATUS.SetValue(dr(i)("STATUS"),"")
                item.Link1Href = "Staff_Inductions_ByCourse.aspx"
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

'Record STAFF_INDUCTIONS_COURSESSearch Item Class @4-8E3D6129
Public Class STAFF_INDUCTIONS_COURSESSearchItem
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

    Public Shared Function CreateFromHttpRequest() As STAFF_INDUCTIONS_COURSESSearchItem
        Dim item As STAFF_INDUCTIONS_COURSESSearchItem = New STAFF_INDUCTIONS_COURSESSearchItem()
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

'Record STAFF_INDUCTIONS_COURSESSearch Data Provider Class GetResultSet Method @4-957400E9

    Public Sub FillItem(ByVal item As STAFF_INDUCTIONS_COURSESSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
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

'Record STAFF_INDUCTIONS_COURSESSearch AfterExecuteSelect tail @4-E31F8E2A
    End Sub
'End Record STAFF_INDUCTIONS_COURSESSearch AfterExecuteSelect tail

'Record STAFF_INDUCTIONS_COURSESSearch Data Provider Class @4-A61BA892
End Class

'End Record STAFF_INDUCTIONS_COURSESSearch Data Provider Class

'Record STAFF_INDUCTIONS_COURSES1 Item Class @21-E8FF09C9
Public Class STAFF_INDUCTIONS_COURSES1Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public INDUCTION_TITLE As TextField
    Public INDUCTION_DESCRIPTION As TextField
    Public STATUS As IntegerField
    Public STATUSItems As ItemCollection
    Public LAST_ALTERED_BY As TextField
    Public Hidden_last_altered_by As TextField
    Public Hidden_last_altered_date As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    INDUCTION_TITLE = New TextField("", Nothing)
    INDUCTION_DESCRIPTION = New TextField("", Nothing)
    STATUS = New IntegerField("", 1)
    STATUSItems = New ItemCollection()
    LAST_ALTERED_BY = New TextField("", Nothing)
    Hidden_last_altered_by = New TextField("", Nothing)
    Hidden_last_altered_date = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STAFF_INDUCTIONS_COURSES1Item
        Dim item As STAFF_INDUCTIONS_COURSES1Item = New STAFF_INDUCTIONS_COURSES1Item()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("INDUCTION_TITLE")) Then
        item.INDUCTION_TITLE.SetValue(DBUtility.GetInitialValue("INDUCTION_TITLE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("INDUCTION_DESCRIPTION")) Then
        item.INDUCTION_DESCRIPTION.SetValue(DBUtility.GetInitialValue("INDUCTION_DESCRIPTION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STATUS")) Then
        item.STATUS.SetValue(DBUtility.GetInitialValue("STATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_last_altered_by")) Then
        item.Hidden_last_altered_by.SetValue(DBUtility.GetInitialValue("Hidden_last_altered_by"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_last_altered_date")) Then
        item.Hidden_last_altered_date.SetValue(DBUtility.GetInitialValue("Hidden_last_altered_date"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "INDUCTION_TITLE"
                    Return INDUCTION_TITLE
                Case "INDUCTION_DESCRIPTION"
                    Return INDUCTION_DESCRIPTION
                Case "STATUS"
                    Return STATUS
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "Hidden_last_altered_by"
                    Return Hidden_last_altered_by
                Case "Hidden_last_altered_date"
                    Return Hidden_last_altered_date
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "INDUCTION_TITLE"
                    INDUCTION_TITLE = CType(value, TextField)
                Case "INDUCTION_DESCRIPTION"
                    INDUCTION_DESCRIPTION = CType(value, TextField)
                Case "STATUS"
                    STATUS = CType(value, IntegerField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "Hidden_last_altered_by"
                    Hidden_last_altered_by = CType(value, TextField)
                Case "Hidden_last_altered_date"
                    Hidden_last_altered_date = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
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

    Public Sub Validate(ByVal provider As STAFF_INDUCTIONS_COURSES1DataProvider)
'End Record STAFF_INDUCTIONS_COURSES1 Item Class

'INDUCTION_TITLE validate @26-605D9D90
        If IsNothing(INDUCTION_TITLE.Value) OrElse INDUCTION_TITLE.Value.ToString() ="" Then
            errors.Add("INDUCTION_TITLE",String.Format(Resources.strings.CCS_RequiredField,"INDUCTION TITLE"))
        End If
'End INDUCTION_TITLE validate

'INDUCTION_DESCRIPTION validate @27-BCA8FDAD
        If IsNothing(INDUCTION_DESCRIPTION.Value) OrElse INDUCTION_DESCRIPTION.Value.ToString() ="" Then
            errors.Add("INDUCTION_DESCRIPTION",String.Format(Resources.strings.CCS_RequiredField,"INDUCTION DESCRIPTION"))
        End If
'End INDUCTION_DESCRIPTION validate

'Record STAFF_INDUCTIONS_COURSES1 Item Class tail @21-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STAFF_INDUCTIONS_COURSES1 Item Class tail

'Record STAFF_INDUCTIONS_COURSES1 Data Provider Class @21-069175E6
Public Class STAFF_INDUCTIONS_COURSES1DataProvider
Inherits RecordDataProviderBase
'End Record STAFF_INDUCTIONS_COURSES1 Data Provider Class

'Record STAFF_INDUCTIONS_COURSES1 Data Provider Class Variables @21-4974A46C
    Public Urlind_id As IntegerParameter
    Protected item As STAFF_INDUCTIONS_COURSES1Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STAFF_INDUCTIONS_COURSES1 Data Provider Class Variables

'Record STAFF_INDUCTIONS_COURSES1 Data Provider Class Constructor @21-346BD733

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STAFF_INDUCTIONS_COURSES {SQL_Where} {SQL_OrderBy}", New String(){"ind_id25"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STAFF_INDUCTIONS_COURSES1 Data Provider Class Constructor

'Record STAFF_INDUCTIONS_COURSES1 Data Provider Class LoadParams Method @21-FB60BA7B

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(Urlind_id))
    End Function
'End Record STAFF_INDUCTIONS_COURSES1 Data Provider Class LoadParams Method

'Record STAFF_INDUCTIONS_COURSES1 Data Provider Class CheckUnique Method @21-BDD6DE67

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STAFF_INDUCTIONS_COURSES1Item) As Boolean
        Return True
    End Function
'End Record STAFF_INDUCTIONS_COURSES1 Data Provider Class CheckUnique Method

'Record STAFF_INDUCTIONS_COURSES1 Data Provider Class PrepareInsert Method @21-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STAFF_INDUCTIONS_COURSES1 Data Provider Class PrepareInsert Method

'Record STAFF_INDUCTIONS_COURSES1 Data Provider Class PrepareInsert Method tail @21-E31F8E2A
    End Sub
'End Record STAFF_INDUCTIONS_COURSES1 Data Provider Class PrepareInsert Method tail

'Record STAFF_INDUCTIONS_COURSES1 Data Provider Class Insert Method @21-DDA5E97F

    Public Function InsertItem(ByVal item As STAFF_INDUCTIONS_COURSES1Item) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO STAFF_INDUCTIONS_COURSES({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STAFF_INDUCTIONS_COURSES1 Data Provider Class Insert Method

'Record STAFF_INDUCTIONS_COURSES1 Build insert @21-93B09B31
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.INDUCTION_TITLE.IsEmpty Then
        allEmptyFlag = item.INDUCTION_TITLE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "INDUCTION_TITLE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.INDUCTION_TITLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.INDUCTION_DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.INDUCTION_DESCRIPTION.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "INDUCTION_DESCRIPTION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.INDUCTION_DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STATUS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STATUS.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.Hidden_last_altered_by.IsEmpty Then
        allEmptyFlag = item.Hidden_last_altered_by.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_last_altered_by.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_last_altered_date.IsEmpty Then
        allEmptyFlag = item.Hidden_last_altered_date.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_last_altered_date.GetFormattedValue(""),FieldType._Text) & ","
        End If
		Insert.SqlQuery.Replace("{Fields}", fieldsList.TrimEnd(","C))
		Insert.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
             If Not allEmptyFlag Then result = ExecuteInsert()
        Catch ee As Exception
            E = ee
        Finally
'End Record STAFF_INDUCTIONS_COURSES1 Build insert

'Record STAFF_INDUCTIONS_COURSES1 AfterExecuteInsert @21-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STAFF_INDUCTIONS_COURSES1 AfterExecuteInsert

'Record STAFF_INDUCTIONS_COURSES1 Data Provider Class PrepareUpdate Method @21-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STAFF_INDUCTIONS_COURSES1 Data Provider Class PrepareUpdate Method

'Record STAFF_INDUCTIONS_COURSES1 Data Provider Class PrepareUpdate Method tail @21-E31F8E2A
    End Sub
'End Record STAFF_INDUCTIONS_COURSES1 Data Provider Class PrepareUpdate Method tail

'Record STAFF_INDUCTIONS_COURSES1 Data Provider Class Update Method @21-480120D5

    Public Function UpdateItem(ByVal item As STAFF_INDUCTIONS_COURSES1Item) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STAFF_INDUCTIONS_COURSES SET {Values}", New String(){"ind_id25"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STAFF_INDUCTIONS_COURSES1 Data Provider Class Update Method

'Record STAFF_INDUCTIONS_COURSES1 BeforeBuildUpdate @21-910F7F0F
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("ind_id25",Urlind_id, "","id",Condition.Equal,False)
        If Not item.INDUCTION_TITLE.IsEmpty Then
        allEmptyFlag = item.INDUCTION_TITLE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "INDUCTION_TITLE=" + Update.Dao.ToSql(item.INDUCTION_TITLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.INDUCTION_DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.INDUCTION_DESCRIPTION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "INDUCTION_DESCRIPTION=" + Update.Dao.ToSql(item.INDUCTION_DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STATUS=" + Update.Dao.ToSql(item.STATUS.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.Hidden_last_altered_by.IsEmpty Then
        allEmptyFlag = item.Hidden_last_altered_by.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.Hidden_last_altered_by.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_last_altered_date.IsEmpty Then
        allEmptyFlag = item.Hidden_last_altered_date.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.Hidden_last_altered_date.GetFormattedValue(""),FieldType._Text) & ","
        End If
		Update.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
             If Not allEmptyFlag Then result = ExecuteUpdate()
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record STAFF_INDUCTIONS_COURSES1 BeforeBuildUpdate

'Record STAFF_INDUCTIONS_COURSES1 AfterExecuteUpdate @21-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STAFF_INDUCTIONS_COURSES1 AfterExecuteUpdate

'Record STAFF_INDUCTIONS_COURSES1 Data Provider Class GetResultSet Method @21-DC7B3655

    Public Sub FillItem(ByVal item As STAFF_INDUCTIONS_COURSES1Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STAFF_INDUCTIONS_COURSES1 Data Provider Class GetResultSet Method

'Record STAFF_INDUCTIONS_COURSES1 BeforeBuildSelect @21-02743185
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("ind_id25",Urlind_id, "","id",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STAFF_INDUCTIONS_COURSES1 BeforeBuildSelect

'Record STAFF_INDUCTIONS_COURSES1 BeforeExecuteSelect @21-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STAFF_INDUCTIONS_COURSES1 BeforeExecuteSelect

'Record STAFF_INDUCTIONS_COURSES1 AfterExecuteSelect @21-65701380
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.INDUCTION_TITLE.SetValue(dr(i)("INDUCTION_TITLE"),"")
            item.INDUCTION_DESCRIPTION.SetValue(dr(i)("INDUCTION_DESCRIPTION"),"")
            item.STATUS.SetValue(dr(i)("STATUS"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.Hidden_last_altered_by.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.Hidden_last_altered_date.SetValue(dr(i)("LAST_ALTERED_DATE"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
'End Record STAFF_INDUCTIONS_COURSES1 AfterExecuteSelect

'ListBox STATUS AfterExecuteSelect @28-BAC365F8
        
item.STATUSItems.Add("1","Active")
item.STATUSItems.Add("0","Inactive")
'End ListBox STATUS AfterExecuteSelect

'Record STAFF_INDUCTIONS_COURSES1 AfterExecuteSelect tail @21-E31F8E2A
    End Sub
'End Record STAFF_INDUCTIONS_COURSES1 AfterExecuteSelect tail

'Record STAFF_INDUCTIONS_COURSES1 Data Provider Class @21-A61BA892
End Class

'End Record STAFF_INDUCTIONS_COURSES1 Data Provider Class

'EditableGrid STAFF_INDUCTIONS_PROGRESS Item Class @36-89418C1E
Public Class STAFF_INDUCTIONS_PROGRESSItem
    Public errors As NameValueCollection = New NameValueCollection()
    Public RowId As Integer
    Private _deleteAllowed As Boolean = True
    Private _isNew As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STAFF_INDUCTIONS_PROGRESS_TotalRecords As TextField
    Public STAFF_ID As TextField
    Public STAFF_IDItems As ItemCollection
    Public STATUS As TextField
    Public STATUSItems As ItemCollection
    Public DATE_COMPLETED As DateField
    Public CheckBox_Delete As BooleanField
    Public CheckBox_DeleteCheckedValue As BooleanField
    Public CheckBox_DeleteUncheckedValue As BooleanField
    Public induction_id As IntegerField
    Public Sub New()
    STAFF_INDUCTIONS_PROGRESS_TotalRecords = New TextField("", Nothing)
    STAFF_ID = New TextField("", Nothing)
    STAFF_IDItems = New ItemCollection()
    STATUS = New TextField("", "INCOMPLETE")
    STATUSItems = New ItemCollection()
    DATE_COMPLETED = New DateField("dd\/MM\/yyyy", DateTime.Now)
    CheckBox_Delete = New BooleanField(Settings.BoolFormat, false)
    CheckBox_DeleteCheckedValue = New BooleanField(Settings.BoolFormat, true)
    CheckBox_DeleteUncheckedValue = New BooleanField(Settings.BoolFormat, false)
    induction_id = New IntegerField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase
        Get
            Select fieldName
                Case "STAFF_INDUCTIONS_PROGRESS_TotalRecords"
                    Return Me.STAFF_INDUCTIONS_PROGRESS_TotalRecords
                Case "STAFF_ID"
                    Return Me.STAFF_ID
                Case "STATUS"
                    Return Me.STATUS
                Case "DATE_COMPLETED"
                    Return Me.DATE_COMPLETED
                Case "CheckBox_Delete"
                    Return Me.CheckBox_Delete
                Case "induction_id"
                    Return Me.induction_id
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STAFF_INDUCTIONS_PROGRESS_TotalRecords"
                    Me.STAFF_INDUCTIONS_PROGRESS_TotalRecords = CType(Value,TextField)
                Case "STAFF_ID"
                    Me.STAFF_ID = CType(Value,TextField)
                Case "STATUS"
                    Me.STATUS = CType(Value,TextField)
                Case "DATE_COMPLETED"
                    Me.DATE_COMPLETED = CType(Value,DateField)
                Case "CheckBox_Delete"
                    Me.CheckBox_Delete = CType(Value,BooleanField)
                Case "induction_id"
                    Me.induction_id = CType(Value,IntegerField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public  Property IsDeleteAllowed As Boolean
        Get
            Return  Not(IsEmptyItem) AndAlso _deleteAllowed
        End Get
        Set
            _deleteAllowed = Value
        End Set
    End Property

    Public Property IsNew As Boolean
        Get
            Return _isNew
        End Get
        Set
            _isNew = Value
        End Set
    End Property

    Public ReadOnly Property IsEmptyItem As Boolean
        Get
            Dim result As Boolean = True
            result = IsNothing(STAFF_ID.Value) And result
            result = IsNothing(STATUS.Value) And result
            result = IsNothing(DATE_COMPLETED.Value) And result
            result = IsNothing(CheckBox_Delete.Value) And result
            result = IsNothing(induction_id.Value) And result
            Return result
        End Get
    End Property

    Public IsDeleted As Boolean = False
    Public IsUpdated As Boolean = False
    Public Function Validate(ByVal provider As STAFF_INDUCTIONS_PROGRESSDataProvider) As Boolean
'End EditableGrid STAFF_INDUCTIONS_PROGRESS Item Class

'STAFF_ID validate @47-9B655313
        If IsNothing(STAFF_ID.Value) OrElse STAFF_ID.Value.ToString() ="" Then
            errors.Add("STAFF_ID",String.Format(Resources.strings.CCS_RequiredField,"STAFF ID"))
        End If
'End STAFF_ID validate

'STATUS validate @48-73C7378E
        If IsNothing(STATUS.Value) OrElse STATUS.Value.ToString() ="" Then
            errors.Add("STATUS",String.Format(Resources.strings.CCS_RequiredField,"STATUS"))
        End If
'End STATUS validate

'DATE_COMPLETED validate @49-E6C2D16F
        If IsNothing(DATE_COMPLETED.Value) OrElse DATE_COMPLETED.Value.ToString() ="" Then
            errors.Add("DATE_COMPLETED",String.Format(Resources.strings.CCS_RequiredField,"DATE COMPLETED"))
        End If
        If (Not IsNothing(DATE_COMPLETED.Value)) And (Not DATE_COMPLETED.Value <= Today()) Then
            errors.Add("DATE_COMPLETED","The DATE COMPLETED cannot be in the future.")
        End If
'End DATE_COMPLETED validate

'EditableGrid STAFF_INDUCTIONS_PROGRESS Item Class tail @36-11D8DCF0
        Return errors.Count = 0
    End Function
    Public RawData As DataRow = Nothing
End Class
'End EditableGrid STAFF_INDUCTIONS_PROGRESS Item Class tail

'EditableGrid STAFF_INDUCTIONS_PROGRESS Data Provider Class Header @36-FC465BF4
Public Class STAFF_INDUCTIONS_PROGRESSDataProvider
Inherits EditableGridDataProviderBase
'End EditableGrid STAFF_INDUCTIONS_PROGRESS Data Provider Class Header

'Grid STAFF_INDUCTIONS_PROGRESS Data Provider Class Variables @36-B647112B

    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STAFF_ID
        Sorter_STATUS
        Sorter_DATE_COMPLETED
    End Enum

    Private SortFieldsNames As String() = New String() {"","STAFF_ID","STATUS","DATE_COMPLETED"}
    Private SortFieldsNamesDesc As String() = New string() {"","STAFF_ID DESC","STATUS DESC","DATE_COMPLETED DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 40
    Public PageNumber As Integer = 1
    Public EmptyRows As Integer = 1
    Public Urlind_id  As IntegerParameter
    Protected STAFF_IDDataCommand As DataCommand=new TableCommand("SELECT staff_ID, " & vbCrLf & _
          "staffname " & vbCrLf & _
          "FROM View_StaffList_Active_Inactive {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
'End Grid STAFF_INDUCTIONS_PROGRESS Data Provider Class Variables

'EditableGrid STAFF_INDUCTIONS_PROGRESS Data Provider Class Constructor @36-97ADA299

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM STAFF_INDUCTIONS_PROGRESS {SQL_Where} {SQL_OrderBy}", New String(){"ind_id56"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STAFF_INDUCTIONS_PROGRESS", New String(){"ind_id56"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End EditableGrid STAFF_INDUCTIONS_PROGRESS Data Provider Class Constructor

'Record STAFF_INDUCTIONS_PROGRESS Data Provider Class CheckUnique Method @36-EEE2CDA8

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STAFF_INDUCTIONS_PROGRESSItem) As Boolean
        Return True
    End Function
'End Record STAFF_INDUCTIONS_PROGRESS Data Provider Class CheckUnique Method

'Grid STAFF_INDUCTIONS_PROGRESS Data Provider Class Insert Method @36-2767C811
    Protected Function InsertItem(ByVal item As STAFF_INDUCTIONS_PROGRESSItem) As Integer
        Dim CmdExecution As Boolean = True
        Dim Insert As DataCommand=new TableCommand("INSERT INTO STAFF_INDUCTIONS_PROGRESS({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Grid STAFF_INDUCTIONS_PROGRESS Data Provider Class Insert Method

'EditableGrid STAFF_INDUCTIONS_PROGRESS Event BeforeBuildInsert. Action Custom Code @63-73254650
    ' -------------------------
    'ERA: Sept 2010
	'Update the hidden 'ind_id" field with the current induction id
	Dim Req As System.Web.HttpRequest  = System.Web.HttpContext.Current.Request
	If Not IsNothing(Req.QueryString("ind_id")) And (Req.QueryString("ind_id") <> "") Then
		item.induction_id.SetValue(Req.QueryString("ind_id"),"")
  	End If
    ' -------------------------
'End EditableGrid STAFF_INDUCTIONS_PROGRESS Event BeforeBuildInsert. Action Custom Code

'EditableGrid STAFF_INDUCTIONS_PROGRESS Build insert @36-250E2B09
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.STAFF_ID.IsEmpty Then
        allEmptyFlag = item.STAFF_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STAFF_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STAFF_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STATUS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STATUS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DATE_COMPLETED.IsEmpty Then
        allEmptyFlag = item.DATE_COMPLETED.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "DATE_COMPLETED,"
        valuesList = valuesList & Insert.Dao.ToSql(item.DATE_COMPLETED.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.induction_id.IsEmpty Then
        allEmptyFlag = item.induction_id.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "induction_id,"
        valuesList = valuesList & Insert.Dao.ToSql(item.induction_id.GetFormattedValue(""),FieldType._Integer) & ","
        End If
		Insert.SqlQuery.Replace("{Fields}", fieldsList.TrimEnd(","C))
		Insert.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
'End EditableGrid STAFF_INDUCTIONS_PROGRESS Build insert

'EditableGrid STAFF_INDUCTIONS_PROGRESS Data Provider Class ExecuteInsert @36-41C970ED
        Insert.OpType = OperationType.Insert
        Dim result As Object = 0
        Dim E As Exception = Nothing
        If CmdExecution Then
            Try
                 If Not allEmptyFlag Then result = Insert.ExecuteNonQuery()
            Catch e_ As Exception
                item.errors.Add("DataProvider",e_.Source + ":" + e_.Message)
            Finally
'End EditableGrid STAFF_INDUCTIONS_PROGRESS Data Provider Class ExecuteInsert

'EditableGrid STAFF_INDUCTIONS_PROGRESS AfterExecuteInsert @36-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid STAFF_INDUCTIONS_PROGRESS AfterExecuteInsert

'EditableGrid STAFF_INDUCTIONS_PROGRESS Data Provider Class Update Method @36-D3859A84
    Protected Function UpdateItem(ByVal item As STAFF_INDUCTIONS_PROGRESSItem) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        Dim Update As DataCommand=new TableCommand("UPDATE STAFF_INDUCTIONS_PROGRESS SET {Values}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End EditableGrid STAFF_INDUCTIONS_PROGRESS Data Provider Class Update Method

'EditableGrid STAFF_INDUCTIONS_PROGRESS BeforeBuildUpdate @36-06A4A554
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("ind_id56",Urlind_id, "","induction_id",Condition.Equal,False)
        If Not item.STAFF_ID.IsEmpty Then
        allEmptyFlag = item.STAFF_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STAFF_ID=" + Update.Dao.ToSql(item.STAFF_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STATUS=" + Update.Dao.ToSql(item.STATUS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DATE_COMPLETED.IsEmpty Then
        allEmptyFlag = item.DATE_COMPLETED.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DATE_COMPLETED=" + Update.Dao.ToSql(item.DATE_COMPLETED.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.induction_id.IsEmpty Then
        allEmptyFlag = item.induction_id.IsEmpty And allEmptyFlag
        valuesList = valuesList & "induction_id=" + Update.Dao.ToSql(item.induction_id.GetFormattedValue(""),FieldType._Integer) & ","
        End If
		Update.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
'End EditableGrid STAFF_INDUCTIONS_PROGRESS BeforeBuildUpdate

'EditableGrid STAFF_INDUCTIONS_PROGRESS Execute Update  @36-392E25E7
        Update.OpType = OperationType.Update
        Dim result As Object = 0
        Dim E As Exception = Nothing
        If CmdExecution Then
            If Not IsParametersPassed Then
                item.errors.Add("DataProvider",Resources.strings.CCS_CustomOperationError_MissingParameters)
                Return 0
            End If
            Try
                 If Not allEmptyFlag Then result = Update.ExecuteNonQuery()
            Catch e_ As Exception
                item.errors.Add("DataProvider",e_.Source + ":" + e_.Message)
            Finally
'End EditableGrid STAFF_INDUCTIONS_PROGRESS Execute Update 

'EditableGrid STAFF_INDUCTIONS_PROGRESS AfterExecuteUpdate @36-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid STAFF_INDUCTIONS_PROGRESS AfterExecuteUpdate

'Record STAFF_INDUCTIONS_PROGRESS Data Provider Class Delete Method @36-26E9A9C6
    Public Function DeleteItem(ByVal item As STAFF_INDUCTIONS_PROGRESSItem) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        Dim Delete As DataCommand=new TableCommand("DELETE FROM STAFF_INDUCTIONS_PROGRESS", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STAFF_INDUCTIONS_PROGRESS Data Provider Class Delete Method

'Record STAFF_INDUCTIONS_PROGRESS BeforeBuildDelete @36-636767CF
        Delete.Parameters.Clear()
        CType(Delete,TableCommand).AddParameter("ind_id56",Urlind_id, "","induction_id",Condition.Equal,False)
        Delete.SqlQuery.Replace("{STAFF_ID}",Delete.Dao.ToSql(item.STAFF_ID.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{STATUS}",Delete.Dao.ToSql(item.STATUS.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{DATE_COMPLETED}",Delete.Dao.ToSql(item.DATE_COMPLETED.GetFormattedValue(Delete.DateFormat),FieldType._Date))
        Delete.SqlQuery.Replace("{induction_id}",Delete.Dao.ToSql(item.induction_id.GetFormattedValue(""),FieldType._Integer))
'End Record STAFF_INDUCTIONS_PROGRESS BeforeBuildDelete

'EditableGrid STAFF_INDUCTIONS_PROGRESS Data Provider Class Execute Delete @36-124DEAF1
        Delete.OpType = OperationType.Delete
        Dim result As Object = 0
        Dim E As Exception = Nothing
        If CmdExecution Then
            If Not IsParametersPassed Then
                item.errors.Add("DataProvider",Resources.strings.CCS_CustomOperationError_MissingParameters)
                Return 0
            End If
            Try
                result = Delete.ExecuteNonQuery()
            Catch e_ As Exception
                item.errors.Add("DataProvider",e_.Source + ":" + e_.Message)
            Finally
'End EditableGrid STAFF_INDUCTIONS_PROGRESS Data Provider Class Execute Delete

'EditableGrid STAFF_INDUCTIONS_PROGRESS AfterExecuteDelete @36-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid STAFF_INDUCTIONS_PROGRESS AfterExecuteDelete

'Grid STAFF_INDUCTIONS_PROGRESS Data Provider Class GetResultSet Method @36-6F8EB56B
    Public Sub Update(Items As ArrayList, ops As FormSupportedOperations)
        Dim i As Integer
        For i = 0 To Items.Count - 1
            Dim op As EditableGridOperation = EditableGridOperation.Insert
            Dim isProcessed As Boolean = False
            Dim item As STAFF_INDUCTIONS_PROGRESSItem = CType(Items(i), STAFF_INDUCTIONS_PROGRESSItem)
'End Grid STAFF_INDUCTIONS_PROGRESS Data Provider Class GetResultSet Method

'EditableGrid STAFF_INDUCTIONS_PROGRESS Data Provider Class Update @36-EC7F15D7
            If Not item.IsUpdated Then
                If item.IsDeleted And ops.AllowDelete Then
                    DeleteItem(item)
                    op = EditableGridOperation.Delete
                    isProcessed = True
                End If
                If item.IsNew And Not(item.IsEmptyItem) And ops.AllowInsert And Not(isProcessed) Then
                    InsertItem(item)
                    op = EditableGridOperation.Insert
                    isProcessed = True
                End If
                If Not(item.IsEmptyItem) And ops.AllowUpdate And Not(isProcessed) Then
                    UpdateItem(item)
                    op = EditableGridOperation.Update
                End If
'End EditableGrid STAFF_INDUCTIONS_PROGRESS Data Provider Class Update

'EditableGrid STAFF_INDUCTIONS_PROGRESS Data Provider Class AfterUpdate @36-6CCB76B9
                If item.errors.Count = 0 Then item.IsUpdated = True
                OnItemUpdated(New ItemUpdatedEventArgs(op, item))
            End If
        Next i
    End Sub
'End EditableGrid STAFF_INDUCTIONS_PROGRESS Data Provider Class AfterUpdate

'EditableGrid STAFF_INDUCTIONS_PROGRESS Data Provider Class GetResultSet Method @36-5753910D
    Public Function GetResultSet(ByRef _pagesCount As Integer, ops As FormSupportedOperations) As STAFF_INDUCTIONS_PROGRESSItem()
'End EditableGrid STAFF_INDUCTIONS_PROGRESS Data Provider Class GetResultSet Method

'Before build Select @36-4B3C0C81
        _pagesCount = 0
        Dim E as Exception = Nothing
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("ind_id56",Urlind_id, "","induction_id",Condition.Equal,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy = SortFieldsNames(CInt(SortField)).Trim
        Else
            Select_.OrderBy = SortFieldsNamesDesc(CInt(SortField)).Trim
        End If
    Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @36-939614DD
        Dim dr As DataRowCollection = Nothing
        Dim rowCount as Integer = 0
        Dim ds As DataSet = Nothing
        If ops.AllowRead Then
            _pagesCount=0
            Try
                If RecordsPerPage>0
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _pagesCount = ExecuteCount()
                    m_recordCount = _pagesCount
                    If _pagesCount Mod RecordsPerPage>0 Then
                        _pagesCount = (_pagesCount\RecordsPerPage)+1
                    Else
                        _pagesCount = _pagesCount\RecordsPerPage
                    End If
                Else
                ds=ExecuteSelect()
                If ds.Tables(tableIndex).Rows.Count<>0 Then 
                    _pagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @36-EA838E38
                If Not IsNothing(E) Then Throw E
            End Try
            dr = ds.Tables(tableIndex).Rows
            rowCount = dr.Count
        End If
        if  Not ops.AllowInsert Then EmptyRows = 0
        Dim result(rowCount + EmptyRows - 1) As STAFF_INDUCTIONS_PROGRESSItem
'End After execute Select

'ListBox STAFF_ID Initialize Data Source @47-AC9FD4A7
    STAFF_IDDataCommand.Dao._optimized = False
    Dim STAFF_IDtableIndex As Integer = 0
    STAFF_IDDataCommand.OrderBy = "status desc, staffname"
    STAFF_IDDataCommand.Parameters.Clear()
'End ListBox STAFF_ID Initialize Data Source

'ListBox STAFF_ID BeforeExecuteSelect @47-0F683DF6
    Try
        ListBoxSource=STAFF_IDDataCommand.Execute().Tables(STAFF_IDtableIndex).Rows
    Catch ee as Exception 
        E=ee
    Finally
'End ListBox STAFF_ID BeforeExecuteSelect

'ListBox STAFF_ID AfterExecuteSelect @47-E17AA7D1
        If Not IsNothing(E) Then Throw E
    End Try
    Dim STAFF_IDItems As ItemCollection = New ItemCollection()
    For j=0 To ListBoxSource.Count-1 
        Dim Key As String = (New TextField("", ListBoxSource(j)("staff_ID"))).GetFormattedValue("")
        Dim Val As Object = ListBoxSource(j)("staffname")
        STAFF_IDItems.Add(Key, Val)
    Next
'End ListBox STAFF_ID AfterExecuteSelect

'ListBox STATUS AfterExecuteSelect @48-EB9B9D69
    Dim STATUSItems As ItemCollection = New ItemCollection()
    
STATUSItems.Add("INCOMPLETE","Not Completed")
STATUSItems.Add("COMPLETED","Completed")
STATUSItems.Add("NA","Not Required")
'End ListBox STATUS AfterExecuteSelect

'After execute Select tail @36-965149F9
        Dim i as Integer
        For i = 0 To rowCount - 1
            Dim item as STAFF_INDUCTIONS_PROGRESSItem = New STAFF_INDUCTIONS_PROGRESSItem()
            item.IsDeleteAllowed = ops.AllowDelete
            item.STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
            item.STAFF_IDItems = CType(STAFF_IDItems.Clone(), ItemCollection)
            item.STATUS.SetValue(dr(i)("STATUS"),"")
            item.STATUSItems = CType(STATUSItems.Clone(), ItemCollection)
            item.DATE_COMPLETED.SetValue(dr(i)("DATE_COMPLETED"),Select_.DateFormat)
            item.induction_id.SetValue(dr(i)("induction_id"),"")
            item.RawData = dr(i)
            result(i)=item
        Next i
        For i = rowCount To rowCount + EmptyRows - 1
            Dim item as STAFF_INDUCTIONS_PROGRESSItem = New STAFF_INDUCTIONS_PROGRESSItem()
            item.IsDeleteAllowed = ops.AllowDelete
            item.IsNew = True
            item.STAFF_IDItems = CType(STAFF_IDItems.Clone(), ItemCollection)
            item.STATUSItems = CType(STATUSItems.Clone(), ItemCollection)
            result(i) = item
        Next i
        If ops.AllowRead Then
            _isEmpty = IIf(dr.Count = 0, True, False)
        Else
            _isEmpty = True
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @36-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

