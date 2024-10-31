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

Namespace DECV_PROD2007.REF_MODULE_CODES 'Namespace @1-33F3CD35

'Page Data Class @1-0D8A08C7
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public REF_MODULE_CODES1_Insert As TextField
    Public REF_MODULE_CODES1_InsertHref As Object
    Public REF_MODULE_CODES1_InsertHrefParameters As LinkParameterCollection
    Public Sub New()
        REF_MODULE_CODES1_Insert = New TextField("",Nothing)
        REF_MODULE_CODES1_InsertHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.REF_MODULE_CODES1_Insert.SetValue(DBUtility.GetInitialValue("REF_MODULE_CODES1_Insert"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "REF_MODULE_CODES1_Insert"
                    Return REF_MODULE_CODES1_Insert
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "REF_MODULE_CODES1_Insert"
                    REF_MODULE_CODES1_Insert = CType(value, TextField)
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

'Grid REF_MODULE_CODES1 Item Class @9-8669A58A
Public Class REF_MODULE_CODES1Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public REF_MODULE_CODES1_Insert As TextField
    Public REF_MODULE_CODES1_InsertHref As Object
    Public REF_MODULE_CODES1_InsertHrefParameters As LinkParameterCollection
    Public REF_MODULE_CODES1_TotalRecords As TextField
    Public Detail As TextField
    Public DetailHref As Object
    Public DetailHrefParameters As LinkParameterCollection
    Public MODULE_CODE As TextField
    Public MODULE_LABEL As TextField
    Public SEMESTER As IntegerField
    Public PRIMARY_FLAG As IntegerField
    Public STATUS As IntegerField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    REF_MODULE_CODES1_Insert = New TextField("",Nothing)
    REF_MODULE_CODES1_InsertHrefParameters = New LinkParameterCollection()
    REF_MODULE_CODES1_TotalRecords = New TextField("", Nothing)
    Detail = New TextField("",Nothing)
    DetailHrefParameters = New LinkParameterCollection()
    MODULE_CODE = New TextField("", Nothing)
    MODULE_LABEL = New TextField("", Nothing)
    SEMESTER = New IntegerField("", Nothing)
    PRIMARY_FLAG = New IntegerField("", Nothing)
    STATUS = New IntegerField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "REF_MODULE_CODES1_Insert"
                    Return Me.REF_MODULE_CODES1_Insert
                Case "REF_MODULE_CODES1_TotalRecords"
                    Return Me.REF_MODULE_CODES1_TotalRecords
                Case "Detail"
                    Return Me.Detail
                Case "MODULE_CODE"
                    Return Me.MODULE_CODE
                Case "MODULE_LABEL"
                    Return Me.MODULE_LABEL
                Case "SEMESTER"
                    Return Me.SEMESTER
                Case "PRIMARY_FLAG"
                    Return Me.PRIMARY_FLAG
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
                Case "REF_MODULE_CODES1_Insert"
                    Me.REF_MODULE_CODES1_Insert = CType(Value,TextField)
                Case "REF_MODULE_CODES1_TotalRecords"
                    Me.REF_MODULE_CODES1_TotalRecords = CType(Value,TextField)
                Case "Detail"
                    Me.Detail = CType(Value,TextField)
                Case "MODULE_CODE"
                    Me.MODULE_CODE = CType(Value,TextField)
                Case "MODULE_LABEL"
                    Me.MODULE_LABEL = CType(Value,TextField)
                Case "SEMESTER"
                    Me.SEMESTER = CType(Value,IntegerField)
                Case "PRIMARY_FLAG"
                    Me.PRIMARY_FLAG = CType(Value,IntegerField)
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
'End Grid REF_MODULE_CODES1 Item Class

'Grid REF_MODULE_CODES1 Data Provider Class Header @9-DFD2C459
Public Class REF_MODULE_CODES1DataProvider
Inherits GridDataProviderBase
'End Grid REF_MODULE_CODES1 Data Provider Class Header

'Grid REF_MODULE_CODES1 Data Provider Class Variables @9-CB51D53C

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_MODULE_CODE
        Sorter_MODULE_LABEL
        Sorter_SEMESTER
        Sorter_PRIMARY_FLAG
        Sorter_STATUS
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE
    End Enum

    Private SortFieldsNames As String() = New String() {"MODULE_CODE","MODULE_CODE","MODULE_LABEL","SEMESTER","PRIMARY_FLAG","STATUS","LAST_ALTERED_BY","LAST_ALTERED_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"MODULE_CODE","MODULE_CODE DESC","MODULE_LABEL DESC","SEMESTER DESC","PRIMARY_FLAG DESC","STATUS DESC","LAST_ALTERED_BY DESC","LAST_ALTERED_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 40
    Public PageNumber As Integer = 1
    Public Urls_keyword  As TextParameter
'End Grid REF_MODULE_CODES1 Data Provider Class Variables

'Grid REF_MODULE_CODES1 Data Provider Class GetResultSet Method @9-B43E5187

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} MODULE_CODE, MODULE_LABEL, SEMESTER, PRIMARY_FLAG, " & vbCrLf & _
          "STATUS, LAST_ALTERED_BY, " & vbCrLf & _
          "LAST_ALTERED_DATE " & vbCrLf & _
          "FROM REF_MODULE_CODES {SQL_Where} {SQL_OrderBy}", New String(){"(","s_keyword30","Or","s_keyword31",")"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM REF_MODULE_CODES", New String(){"(","s_keyword30","Or","s_keyword31",")"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid REF_MODULE_CODES1 Data Provider Class GetResultSet Method

'Grid REF_MODULE_CODES1 Data Provider Class GetResultSet Method @9-89EADCA2
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As REF_MODULE_CODES1Item()
'End Grid REF_MODULE_CODES1 Data Provider Class GetResultSet Method

'Before build Select @9-EED97CD3
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_keyword30",Urls_keyword, "","MODULE_CODE",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword31",Urls_keyword, "","MODULE_LABEL",Condition.Contains,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @9-5F3801B6
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As REF_MODULE_CODES1Item
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

'After execute Select @9-B10DD62F
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New REF_MODULE_CODES1Item(dr.Count-1) {}
'End After execute Select

'After execute Select @9-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @9-94090A70
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as REF_MODULE_CODES1Item = New REF_MODULE_CODES1Item()
                item.REF_MODULE_CODES1_InsertHref = "REF_MODULE_CODES.aspx"
                item.DetailHref = "REF_MODULE_CODES.aspx"
                item.DetailHrefParameters.Add("MODULE_CODE",System.Web.HttpUtility.UrlEncode(dr(i)("MODULE_CODE").ToString()))
                item.MODULE_CODE.SetValue(dr(i)("MODULE_CODE"),"")
                item.MODULE_LABEL.SetValue(dr(i)("MODULE_LABEL"),"")
                item.SEMESTER.SetValue(dr(i)("SEMESTER"),"")
                item.PRIMARY_FLAG.SetValue(dr(i)("PRIMARY_FLAG"),"")
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

'Grid Data Provider tail @9-A61BA892
End Class
'End Grid Data Provider tail

'Record REF_MODULE_CODESSearch Item Class @40-CCCB073D
Public Class REF_MODULE_CODESSearchItem
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

    Public Shared Function CreateFromHttpRequest() As REF_MODULE_CODESSearchItem
        Dim item As REF_MODULE_CODESSearchItem = New REF_MODULE_CODESSearchItem()
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

    Public Sub Validate(ByVal provider As REF_MODULE_CODESSearchDataProvider)
'End Record REF_MODULE_CODESSearch Item Class

'Record REF_MODULE_CODESSearch Item Class tail @40-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record REF_MODULE_CODESSearch Item Class tail

'Record REF_MODULE_CODESSearch Data Provider Class @40-8CDE7C73
Public Class REF_MODULE_CODESSearchDataProvider
Inherits RecordDataProviderBase
'End Record REF_MODULE_CODESSearch Data Provider Class

'Record REF_MODULE_CODESSearch Data Provider Class Variables @40-C416B099
    Protected item As REF_MODULE_CODESSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record REF_MODULE_CODESSearch Data Provider Class Variables

'Record REF_MODULE_CODESSearch Data Provider Class GetResultSet Method @40-80FED683

    Public Sub FillItem(ByVal item As REF_MODULE_CODESSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record REF_MODULE_CODESSearch Data Provider Class GetResultSet Method

'Record REF_MODULE_CODESSearch BeforeBuildSelect @40-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record REF_MODULE_CODESSearch BeforeBuildSelect

'Record REF_MODULE_CODESSearch AfterExecuteSelect @40-79426A21
        End If
            IsInsertMode = True
'End Record REF_MODULE_CODESSearch AfterExecuteSelect

'Record REF_MODULE_CODESSearch AfterExecuteSelect tail @40-E31F8E2A
    End Sub
'End Record REF_MODULE_CODESSearch AfterExecuteSelect tail

'Record REF_MODULE_CODESSearch Data Provider Class @40-A61BA892
End Class

'End Record REF_MODULE_CODESSearch Data Provider Class

'Record REF_MODULE_CODES2 Item Class @45-9E19FA55
Public Class REF_MODULE_CODES2Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public MODULE_CODE As TextField
    Public MODULE_LABEL As TextField
    Public PRIMARY_FLAG As IntegerField
    Public PRIMARY_FLAGItems As ItemCollection
    Public STATUS As IntegerField
    Public STATUSItems As ItemCollection
    Public SEMESTER As IntegerField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public lblMODULE_CODE As TextField
    Public Sub New()
    MODULE_CODE = New TextField("", Nothing)
    MODULE_LABEL = New TextField("", Nothing)
    PRIMARY_FLAG = New IntegerField("", Nothing)
    PRIMARY_FLAGItems = New ItemCollection()
    STATUS = New IntegerField("", Nothing)
    STATUSItems = New ItemCollection()
    SEMESTER = New IntegerField("", 0)
    LAST_ALTERED_BY = New TextField("", DBUtility.UserId.ToUpper())
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy", DateTime.Now)
    lblMODULE_CODE = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As REF_MODULE_CODES2Item
        Dim item As REF_MODULE_CODES2Item = New REF_MODULE_CODES2Item()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MODULE_CODE")) Then
        item.MODULE_CODE.SetValue(DBUtility.GetInitialValue("MODULE_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MODULE_LABEL")) Then
        item.MODULE_LABEL.SetValue(DBUtility.GetInitialValue("MODULE_LABEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRIMARY_FLAG")) Then
        item.PRIMARY_FLAG.SetValue(DBUtility.GetInitialValue("PRIMARY_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STATUS")) Then
        item.STATUS.SetValue(DBUtility.GetInitialValue("STATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SEMESTER")) Then
        item.SEMESTER.SetValue(DBUtility.GetInitialValue("SEMESTER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblMODULE_CODE")) Then
        item.lblMODULE_CODE.SetValue(DBUtility.GetInitialValue("lblMODULE_CODE"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "MODULE_CODE"
                    Return MODULE_CODE
                Case "MODULE_LABEL"
                    Return MODULE_LABEL
                Case "PRIMARY_FLAG"
                    Return PRIMARY_FLAG
                Case "STATUS"
                    Return STATUS
                Case "SEMESTER"
                    Return SEMESTER
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "lblMODULE_CODE"
                    Return lblMODULE_CODE
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "MODULE_CODE"
                    MODULE_CODE = CType(value, TextField)
                Case "MODULE_LABEL"
                    MODULE_LABEL = CType(value, TextField)
                Case "PRIMARY_FLAG"
                    PRIMARY_FLAG = CType(value, IntegerField)
                Case "STATUS"
                    STATUS = CType(value, IntegerField)
                Case "SEMESTER"
                    SEMESTER = CType(value, IntegerField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "lblMODULE_CODE"
                    lblMODULE_CODE = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As REF_MODULE_CODES2DataProvider)
'End Record REF_MODULE_CODES2 Item Class

'MODULE_CODE validate @49-E5CE2EEE
        If IsNothing(MODULE_CODE.Value) OrElse MODULE_CODE.Value.ToString() ="" Then
            errors.Add("MODULE_CODE",String.Format(Resources.strings.CCS_RequiredField,"MODULE CODE"))
        End If
        If (Not IsNothing(MODULE_CODE)) And (Not provider.CheckUnique("MODULE_CODE",Me)) Then
                errors.Add("MODULE_CODE", String.Format(Resources.strings.CCS_UniqueValue,"MODULE CODE"))
        End If
'End MODULE_CODE validate

'PRIMARY_FLAG validate @51-6E6FB64F
        If IsNothing(PRIMARY_FLAG.Value) OrElse PRIMARY_FLAG.Value.ToString() ="" Then
            errors.Add("PRIMARY_FLAG",String.Format(Resources.strings.CCS_RequiredField,"PRIMARY FLAG"))
        End If
'End PRIMARY_FLAG validate

'STATUS validate @52-73C7378E
        If IsNothing(STATUS.Value) OrElse STATUS.Value.ToString() ="" Then
            errors.Add("STATUS",String.Format(Resources.strings.CCS_RequiredField,"STATUS"))
        End If
'End STATUS validate

'SEMESTER validate @53-6C5B1447
        If IsNothing(SEMESTER.Value) OrElse SEMESTER.Value.ToString() ="" Then
            errors.Add("SEMESTER",String.Format(Resources.strings.CCS_RequiredField,"SEMESTER"))
        End If
'End SEMESTER validate

'LAST_ALTERED_BY validate @54-256A6854
        If IsNothing(LAST_ALTERED_BY.Value) OrElse LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End LAST_ALTERED_BY validate

'Record REF_MODULE_CODES2 Item Class tail @45-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record REF_MODULE_CODES2 Item Class tail

'Record REF_MODULE_CODES2 Data Provider Class @45-A678C47C
Public Class REF_MODULE_CODES2DataProvider
Inherits RecordDataProviderBase
'End Record REF_MODULE_CODES2 Data Provider Class

'Record REF_MODULE_CODES2 Data Provider Class Variables @45-F26AC557
    Public UrlMODULE_CODE As TextParameter
    Protected item As REF_MODULE_CODES2Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record REF_MODULE_CODES2 Data Provider Class Variables

'Record REF_MODULE_CODES2 Data Provider Class Constructor @45-439EDA3B

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM REF_MODULE_CODES {SQL_Where} {SQL_OrderBy}", New String(){"MODULE_CODE61"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record REF_MODULE_CODES2 Data Provider Class Constructor

'Record REF_MODULE_CODES2 Data Provider Class LoadParams Method @45-F56F4A02

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlMODULE_CODE))
    End Function
'End Record REF_MODULE_CODES2 Data Provider Class LoadParams Method

'Record REF_MODULE_CODES2 Data Provider Class CheckUnique Method @45-3BE415E8

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As REF_MODULE_CODES2Item) As Boolean
        Dim Check As TableCommand = New TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM REF_MODULE_CODES",New String(){"MODULE_CODE61"},Settings.connDECVPRODSQL2005DataAccessObject)
        Dim CheckWhere As String = ""
        Select Case ControlName
        Case "MODULE_CODE"
            CheckWhere = "MODULE_CODE=" & Check.Dao.ToSql(item.MODULE_CODE.GetFormattedValue(""),FieldType._Text)
        End Select
        Check.Where = CheckWhere
        Check.Operation = "AND NOT"
        Check.Parameters.Clear()
        CType(Check,TableCommand).AddParameter("MODULE_CODE61",UrlMODULE_CODE, "","MODULE_CODE",Condition.Equal,False)
        If Convert.ToInt32(Check.ExecuteScalar()) > 0 Then
            Return False
        End If
        Return True
    End Function
'End Record REF_MODULE_CODES2 Data Provider Class CheckUnique Method

'Record REF_MODULE_CODES2 Data Provider Class PrepareInsert Method @45-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record REF_MODULE_CODES2 Data Provider Class PrepareInsert Method

'Record REF_MODULE_CODES2 Data Provider Class PrepareInsert Method tail @45-E31F8E2A
    End Sub
'End Record REF_MODULE_CODES2 Data Provider Class PrepareInsert Method tail

'Record REF_MODULE_CODES2 Data Provider Class Insert Method @45-AD68C916

    Public Function InsertItem(ByVal item As REF_MODULE_CODES2Item) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO REF_MODULE_CODES({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record REF_MODULE_CODES2 Data Provider Class Insert Method

'Record REF_MODULE_CODES2 Build insert @45-C40B9AE2
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.MODULE_CODE.IsEmpty Then
        allEmptyFlag = item.MODULE_CODE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "MODULE_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.MODULE_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.MODULE_LABEL.IsEmpty Then
        allEmptyFlag = item.MODULE_LABEL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "MODULE_LABEL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.MODULE_LABEL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PRIMARY_FLAG.IsEmpty Then
        allEmptyFlag = item.PRIMARY_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PRIMARY_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PRIMARY_FLAG.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STATUS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STATUS.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.SEMESTER.IsEmpty Then
        allEmptyFlag = item.SEMESTER.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SEMESTER,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SEMESTER.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
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
'End Record REF_MODULE_CODES2 Build insert

'Record REF_MODULE_CODES2 AfterExecuteInsert @45-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record REF_MODULE_CODES2 AfterExecuteInsert

'Record REF_MODULE_CODES2 Data Provider Class PrepareUpdate Method @45-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record REF_MODULE_CODES2 Data Provider Class PrepareUpdate Method

'Record REF_MODULE_CODES2 Data Provider Class PrepareUpdate Method tail @45-E31F8E2A
    End Sub
'End Record REF_MODULE_CODES2 Data Provider Class PrepareUpdate Method tail

'Record REF_MODULE_CODES2 Data Provider Class Update Method @45-621293E0

    Public Function UpdateItem(ByVal item As REF_MODULE_CODES2Item) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE REF_MODULE_CODES SET {Values}", New String(){"MODULE_CODE61"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record REF_MODULE_CODES2 Data Provider Class Update Method

'Record REF_MODULE_CODES2 BeforeBuildUpdate @45-F8D5F35F
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("MODULE_CODE61",UrlMODULE_CODE, "","MODULE_CODE",Condition.Equal,False)
        If Not item.MODULE_CODE.IsEmpty Then
        allEmptyFlag = item.MODULE_CODE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "MODULE_CODE=" + Update.Dao.ToSql(item.MODULE_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.MODULE_LABEL.IsEmpty Then
        allEmptyFlag = item.MODULE_LABEL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "MODULE_LABEL=" + Update.Dao.ToSql(item.MODULE_LABEL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PRIMARY_FLAG.IsEmpty Then
        allEmptyFlag = item.PRIMARY_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRIMARY_FLAG=" + Update.Dao.ToSql(item.PRIMARY_FLAG.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STATUS=" + Update.Dao.ToSql(item.STATUS.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.SEMESTER.IsEmpty Then
        allEmptyFlag = item.SEMESTER.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SEMESTER=" + Update.Dao.ToSql(item.SEMESTER.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
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
'End Record REF_MODULE_CODES2 BeforeBuildUpdate

'Record REF_MODULE_CODES2 AfterExecuteUpdate @45-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record REF_MODULE_CODES2 AfterExecuteUpdate

'Record REF_MODULE_CODES2 Data Provider Class GetResultSet Method @45-1EB7372D

    Public Sub FillItem(ByVal item As REF_MODULE_CODES2Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record REF_MODULE_CODES2 Data Provider Class GetResultSet Method

'Record REF_MODULE_CODES2 BeforeBuildSelect @45-4321FE45
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("MODULE_CODE61",UrlMODULE_CODE, "","MODULE_CODE",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record REF_MODULE_CODES2 BeforeBuildSelect

'Record REF_MODULE_CODES2 BeforeExecuteSelect @45-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record REF_MODULE_CODES2 BeforeExecuteSelect

'Record REF_MODULE_CODES2 AfterExecuteSelect @45-02E425B9
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.MODULE_CODE.SetValue(dr(i)("MODULE_CODE"),"")
            item.MODULE_LABEL.SetValue(dr(i)("MODULE_LABEL"),"")
            item.PRIMARY_FLAG.SetValue(dr(i)("PRIMARY_FLAG"),"")
            item.STATUS.SetValue(dr(i)("STATUS"),"")
            item.SEMESTER.SetValue(dr(i)("SEMESTER"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.lblMODULE_CODE.SetValue(dr(i)("MODULE_CODE"),"")
        Else
            IsInsertMode = True
        End If
'End Record REF_MODULE_CODES2 AfterExecuteSelect

'ListBox PRIMARY_FLAG AfterExecuteSelect @51-E1979166
        
item.PRIMARY_FLAGItems.Add("1","Primary (F-6)")
item.PRIMARY_FLAGItems.Add("0","7-12")
'End ListBox PRIMARY_FLAG AfterExecuteSelect

'ListBox STATUS AfterExecuteSelect @52-E9F8E40E
        
item.STATUSItems.Add("1","Active")
item.STATUSItems.Add("0","Inactive/Hidden")
'End ListBox STATUS AfterExecuteSelect

'Record REF_MODULE_CODES2 AfterExecuteSelect tail @45-E31F8E2A
    End Sub
'End Record REF_MODULE_CODES2 AfterExecuteSelect tail

'Record REF_MODULE_CODES2 Data Provider Class @45-A61BA892
End Class

'End Record REF_MODULE_CODES2 Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

