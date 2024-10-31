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

Namespace DECV_PROD2007.ENROL_CHECKLIST_maint 'Namespace @1-BAB6F809

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

'Record ENROL_CHECKLISTSearch Item Class @20-E21A3D28
Public Class ENROL_CHECKLISTSearchItem
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

    Public Shared Function CreateFromHttpRequest() As ENROL_CHECKLISTSearchItem
        Dim item As ENROL_CHECKLISTSearchItem = New ENROL_CHECKLISTSearchItem()
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

    Public Sub Validate(ByVal provider As ENROL_CHECKLISTSearchDataProvider)
'End Record ENROL_CHECKLISTSearch Item Class

'Record ENROL_CHECKLISTSearch Item Class tail @20-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record ENROL_CHECKLISTSearch Item Class tail

'Record ENROL_CHECKLISTSearch Data Provider Class @20-96532991
Public Class ENROL_CHECKLISTSearchDataProvider
Inherits RecordDataProviderBase
'End Record ENROL_CHECKLISTSearch Data Provider Class

'Record ENROL_CHECKLISTSearch Data Provider Class Variables @20-2A3D9761
    Protected item As ENROL_CHECKLISTSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record ENROL_CHECKLISTSearch Data Provider Class Variables

'Record ENROL_CHECKLISTSearch Data Provider Class GetResultSet Method @20-0D8B4F62

    Public Sub FillItem(ByVal item As ENROL_CHECKLISTSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record ENROL_CHECKLISTSearch Data Provider Class GetResultSet Method

'Record ENROL_CHECKLISTSearch BeforeBuildSelect @20-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record ENROL_CHECKLISTSearch BeforeBuildSelect

'Record ENROL_CHECKLISTSearch AfterExecuteSelect @20-79426A21
        End If
            IsInsertMode = True
'End Record ENROL_CHECKLISTSearch AfterExecuteSelect

'Record ENROL_CHECKLISTSearch AfterExecuteSelect tail @20-E31F8E2A
    End Sub
'End Record ENROL_CHECKLISTSearch AfterExecuteSelect tail

'Record ENROL_CHECKLISTSearch Data Provider Class @20-A61BA892
End Class

'End Record ENROL_CHECKLISTSearch Data Provider Class

'Grid ENROL_CHECKLIST Item Class @24-983EBFB3
Public Class ENROL_CHECKLISTItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public ENROL_CHECKLIST_Insert As TextField
    Public ENROL_CHECKLIST_InsertHref As Object
    Public ENROL_CHECKLIST_InsertHrefParameters As LinkParameterCollection
    Public ENROL_CHECKLIST_TotalRecords As TextField
    Public ID As IntegerField
    Public IDHref As Object
    Public IDHrefParameters As LinkParameterCollection
    Public DESCRIPTION As TextField
    Public CATEGORIES_REQUIRED As TextField
    Public ACTIVE As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    ENROL_CHECKLIST_Insert = New TextField("",Nothing)
    ENROL_CHECKLIST_InsertHrefParameters = New LinkParameterCollection()
    ENROL_CHECKLIST_TotalRecords = New TextField("", Nothing)
    ID = New IntegerField("",Nothing)
    IDHrefParameters = New LinkParameterCollection()
    DESCRIPTION = New TextField("", Nothing)
    CATEGORIES_REQUIRED = New TextField("", Nothing)
    ACTIVE = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "ENROL_CHECKLIST_Insert"
                    Return Me.ENROL_CHECKLIST_Insert
                Case "ENROL_CHECKLIST_TotalRecords"
                    Return Me.ENROL_CHECKLIST_TotalRecords
                Case "ID"
                    Return Me.ID
                Case "DESCRIPTION"
                    Return Me.DESCRIPTION
                Case "CATEGORIES_REQUIRED"
                    Return Me.CATEGORIES_REQUIRED
                Case "ACTIVE"
                    Return Me.ACTIVE
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
                Case "ENROL_CHECKLIST_Insert"
                    Me.ENROL_CHECKLIST_Insert = CType(Value,TextField)
                Case "ENROL_CHECKLIST_TotalRecords"
                    Me.ENROL_CHECKLIST_TotalRecords = CType(Value,TextField)
                Case "ID"
                    Me.ID = CType(Value,IntegerField)
                Case "DESCRIPTION"
                    Me.DESCRIPTION = CType(Value,TextField)
                Case "CATEGORIES_REQUIRED"
                    Me.CATEGORIES_REQUIRED = CType(Value,TextField)
                Case "ACTIVE"
                    Me.ACTIVE = CType(Value,TextField)
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
'End Grid ENROL_CHECKLIST Item Class

'Grid ENROL_CHECKLIST Data Provider Class Header @24-E052CFBE
Public Class ENROL_CHECKLISTDataProvider
Inherits GridDataProviderBase
'End Grid ENROL_CHECKLIST Data Provider Class Header

'Grid ENROL_CHECKLIST Data Provider Class Variables @24-81A33D46

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_ID
        Sorter_DESCRIPTION
        Sorter_CATEGORIES_REQUIRED
        Sorter_ACTIVE
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE
    End Enum

    Private SortFieldsNames As String() = New String() {"","ID","DESCRIPTION","CATEGORIES_REQUIRED","ACTIVE","LAST_ALTERED_BY","LAST_ALTERED_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"","ID DESC","DESCRIPTION DESC","CATEGORIES_REQUIRED DESC","ACTIVE DESC","LAST_ALTERED_BY DESC","LAST_ALTERED_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 20
    Public PageNumber As Integer = 1
    Public Urls_keyword  As TextParameter
'End Grid ENROL_CHECKLIST Data Provider Class Variables

'Grid ENROL_CHECKLIST Data Provider Class GetResultSet Method @24-0B7D9D73

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} ID, DESCRIPTION, CATEGORIES_REQUIRED, ACTIVE, " & vbCrLf & _
          "LAST_ALTERED_BY, LAST_ALTERED_DATE " & vbCrLf & _
          "FROM ENROL_CHECKLIST {SQL_Where} {SQL_OrderBy}", New String(){"s_keyword67","Or","s_keyword68"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM ENROL_CHECKLIST", New String(){"s_keyword67","Or","s_keyword68"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid ENROL_CHECKLIST Data Provider Class GetResultSet Method

'Grid ENROL_CHECKLIST Data Provider Class GetResultSet Method @24-C2489C1A
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As ENROL_CHECKLISTItem()
'End Grid ENROL_CHECKLIST Data Provider Class GetResultSet Method

'Before build Select @24-5A73D93B
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_keyword67",Urls_keyword, "","DESCRIPTION",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword68",Urls_keyword, "","CATEGORIES_REQUIRED",Condition.Contains,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @24-1D8C9D37
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As ENROL_CHECKLISTItem
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

'After execute Select @24-43CB1393
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New ENROL_CHECKLISTItem(dr.Count-1) {}
'End After execute Select

'After execute Select @24-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @24-106D59AC
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as ENROL_CHECKLISTItem = New ENROL_CHECKLISTItem()
                item.ENROL_CHECKLIST_InsertHref = "ENROL_CHECKLIST_maint.aspx"
                item.ID.SetValue(dr(i)("ID"),"")
                item.IDHref = ""
                item.IDHrefParameters.Add("ID",System.Web.HttpUtility.UrlEncode(dr(i)("ID").ToString()))
                item.DESCRIPTION.SetValue(dr(i)("DESCRIPTION"),"")
                item.CATEGORIES_REQUIRED.SetValue(dr(i)("CATEGORIES_REQUIRED"),"")
                item.ACTIVE.SetValue(dr(i)("ACTIVE"),"")
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

'Grid Data Provider tail @24-A61BA892
End Class
'End Grid Data Provider tail

'Record ENROL_CHECKLIST1 Item Class @53-6AD06B41
Public Class ENROL_CHECKLIST1Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public DESCRIPTION As TextField
    Public CATEGORIES_REQUIRED As TextField
    Public CATEGORIES_OPTIONAL As TextField
    Public CATEGORIES_NOTAPPLICABLE As TextField
    Public ACTIVE As TextField
    Public ACTIVEItems As ItemCollection
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public lblLastAlteredBy As TextField
    Public lblLastAlteredWhen As DateField
    Public Sub New()
    DESCRIPTION = New TextField("", Nothing)
    CATEGORIES_REQUIRED = New TextField("", Nothing)
    CATEGORIES_OPTIONAL = New TextField("", Nothing)
    CATEGORIES_NOTAPPLICABLE = New TextField("", Nothing)
    ACTIVE = New TextField("", "Y")
    ACTIVEItems = New ItemCollection()
    LAST_ALTERED_BY = New TextField("", DBUtility.UserLogin)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    lblLastAlteredBy = New TextField("", Nothing)
    lblLastAlteredWhen = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As ENROL_CHECKLIST1Item
        Dim item As ENROL_CHECKLIST1Item = New ENROL_CHECKLIST1Item()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DESCRIPTION")) Then
        item.DESCRIPTION.SetValue(DBUtility.GetInitialValue("DESCRIPTION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CATEGORIES_REQUIRED")) Then
        item.CATEGORIES_REQUIRED.SetValue(DBUtility.GetInitialValue("CATEGORIES_REQUIRED"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CATEGORIES_OPTIONAL")) Then
        item.CATEGORIES_OPTIONAL.SetValue(DBUtility.GetInitialValue("CATEGORIES_OPTIONAL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CATEGORIES_NOTAPPLICABLE")) Then
        item.CATEGORIES_NOTAPPLICABLE.SetValue(DBUtility.GetInitialValue("CATEGORIES_NOTAPPLICABLE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ACTIVE")) Then
        item.ACTIVE.SetValue(DBUtility.GetInitialValue("ACTIVE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblLastAlteredBy")) Then
        item.lblLastAlteredBy.SetValue(DBUtility.GetInitialValue("lblLastAlteredBy"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblLastAlteredWhen")) Then
        item.lblLastAlteredWhen.SetValue(DBUtility.GetInitialValue("lblLastAlteredWhen"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "DESCRIPTION"
                    Return DESCRIPTION
                Case "CATEGORIES_REQUIRED"
                    Return CATEGORIES_REQUIRED
                Case "CATEGORIES_OPTIONAL"
                    Return CATEGORIES_OPTIONAL
                Case "CATEGORIES_NOTAPPLICABLE"
                    Return CATEGORIES_NOTAPPLICABLE
                Case "ACTIVE"
                    Return ACTIVE
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "lblLastAlteredBy"
                    Return lblLastAlteredBy
                Case "lblLastAlteredWhen"
                    Return lblLastAlteredWhen
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "DESCRIPTION"
                    DESCRIPTION = CType(value, TextField)
                Case "CATEGORIES_REQUIRED"
                    CATEGORIES_REQUIRED = CType(value, TextField)
                Case "CATEGORIES_OPTIONAL"
                    CATEGORIES_OPTIONAL = CType(value, TextField)
                Case "CATEGORIES_NOTAPPLICABLE"
                    CATEGORIES_NOTAPPLICABLE = CType(value, TextField)
                Case "ACTIVE"
                    ACTIVE = CType(value, TextField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "lblLastAlteredBy"
                    lblLastAlteredBy = CType(value, TextField)
                Case "lblLastAlteredWhen"
                    lblLastAlteredWhen = CType(value, DateField)
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

    Public Sub Validate(ByVal provider As ENROL_CHECKLIST1DataProvider)
'End Record ENROL_CHECKLIST1 Item Class

'DESCRIPTION validate @59-2BEB15AA
        If IsNothing(DESCRIPTION.Value) OrElse DESCRIPTION.Value.ToString() ="" Then
            errors.Add("DESCRIPTION",String.Format(Resources.strings.CCS_RequiredField,"DESCRIPTION"))
        End If
'End DESCRIPTION validate

'ACTIVE validate @63-29B42AC4
        If IsNothing(ACTIVE.Value) OrElse ACTIVE.Value.ToString() ="" Then
            errors.Add("ACTIVE",String.Format(Resources.strings.CCS_RequiredField,"ACTIVE"))
        End If
'End ACTIVE validate

'LAST_ALTERED_BY validate @64-256A6854
        If IsNothing(LAST_ALTERED_BY.Value) OrElse LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End LAST_ALTERED_BY validate

'Record ENROL_CHECKLIST1 Item Class tail @53-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record ENROL_CHECKLIST1 Item Class tail

'Record ENROL_CHECKLIST1 Data Provider Class @53-0BFE436B
Public Class ENROL_CHECKLIST1DataProvider
Inherits RecordDataProviderBase
'End Record ENROL_CHECKLIST1 Data Provider Class

'Record ENROL_CHECKLIST1 Data Provider Class Variables @53-14718FE6
    Public UrlID As IntegerParameter
    Protected item As ENROL_CHECKLIST1Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record ENROL_CHECKLIST1 Data Provider Class Variables

'Record ENROL_CHECKLIST1 Data Provider Class Constructor @53-3CD78BF7

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM ENROL_CHECKLIST {SQL_Where} {SQL_OrderBy}", New String(){"ID58"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record ENROL_CHECKLIST1 Data Provider Class Constructor

'Record ENROL_CHECKLIST1 Data Provider Class LoadParams Method @53-6CCA1257

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlID))
    End Function
'End Record ENROL_CHECKLIST1 Data Provider Class LoadParams Method

'Record ENROL_CHECKLIST1 Data Provider Class CheckUnique Method @53-92D4C878

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As ENROL_CHECKLIST1Item) As Boolean
        Return True
    End Function
'End Record ENROL_CHECKLIST1 Data Provider Class CheckUnique Method

'Record ENROL_CHECKLIST1 Data Provider Class PrepareInsert Method @53-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record ENROL_CHECKLIST1 Data Provider Class PrepareInsert Method

'Record ENROL_CHECKLIST1 Data Provider Class PrepareInsert Method tail @53-E31F8E2A
    End Sub
'End Record ENROL_CHECKLIST1 Data Provider Class PrepareInsert Method tail

'Record ENROL_CHECKLIST1 Data Provider Class Insert Method @53-5703A02E

    Public Function InsertItem(ByVal item As ENROL_CHECKLIST1Item) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO ENROL_CHECKLIST({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record ENROL_CHECKLIST1 Data Provider Class Insert Method

'Record ENROL_CHECKLIST1 Build insert @53-78A8392D
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.DESCRIPTION.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "DESCRIPTION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CATEGORIES_REQUIRED.IsEmpty Then
        allEmptyFlag = item.CATEGORIES_REQUIRED.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CATEGORIES_REQUIRED,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CATEGORIES_REQUIRED.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CATEGORIES_OPTIONAL.IsEmpty Then
        allEmptyFlag = item.CATEGORIES_OPTIONAL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CATEGORIES_OPTIONAL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CATEGORIES_OPTIONAL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CATEGORIES_NOTAPPLICABLE.IsEmpty Then
        allEmptyFlag = item.CATEGORIES_NOTAPPLICABLE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CATEGORIES_NOTAPPLICABLE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CATEGORIES_NOTAPPLICABLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ACTIVE.IsEmpty Then
        allEmptyFlag = item.ACTIVE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ACTIVE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ACTIVE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue("yyyy-MM-dd HH\:mm\:ss"),FieldType._Date) & ","
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
'End Record ENROL_CHECKLIST1 Build insert

'Record ENROL_CHECKLIST1 AfterExecuteInsert @53-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record ENROL_CHECKLIST1 AfterExecuteInsert

'Record ENROL_CHECKLIST1 Data Provider Class PrepareUpdate Method @53-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record ENROL_CHECKLIST1 Data Provider Class PrepareUpdate Method

'Record ENROL_CHECKLIST1 Data Provider Class PrepareUpdate Method tail @53-E31F8E2A
    End Sub
'End Record ENROL_CHECKLIST1 Data Provider Class PrepareUpdate Method tail

'Record ENROL_CHECKLIST1 Data Provider Class Update Method @53-FE473238

    Public Function UpdateItem(ByVal item As ENROL_CHECKLIST1Item) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE ENROL_CHECKLIST SET {Values}", New String(){"ID58"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record ENROL_CHECKLIST1 Data Provider Class Update Method

'Record ENROL_CHECKLIST1 BeforeBuildUpdate @53-F5A14F70
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("ID58",UrlID, "","ID",Condition.Equal,False)
        If Not item.DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.DESCRIPTION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DESCRIPTION=" + Update.Dao.ToSql(item.DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CATEGORIES_REQUIRED.IsEmpty Then
        allEmptyFlag = item.CATEGORIES_REQUIRED.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CATEGORIES_REQUIRED=" + Update.Dao.ToSql(item.CATEGORIES_REQUIRED.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CATEGORIES_OPTIONAL.IsEmpty Then
        allEmptyFlag = item.CATEGORIES_OPTIONAL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CATEGORIES_OPTIONAL=" + Update.Dao.ToSql(item.CATEGORIES_OPTIONAL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CATEGORIES_NOTAPPLICABLE.IsEmpty Then
        allEmptyFlag = item.CATEGORIES_NOTAPPLICABLE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CATEGORIES_NOTAPPLICABLE=" + Update.Dao.ToSql(item.CATEGORIES_NOTAPPLICABLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ACTIVE.IsEmpty Then
        allEmptyFlag = item.ACTIVE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ACTIVE=" + Update.Dao.ToSql(item.ACTIVE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue("yyyy-MM-dd HH\:mm\:ss"),FieldType._Date) & ","
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
'End Record ENROL_CHECKLIST1 BeforeBuildUpdate

'Record ENROL_CHECKLIST1 AfterExecuteUpdate @53-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record ENROL_CHECKLIST1 AfterExecuteUpdate

'Record ENROL_CHECKLIST1 Data Provider Class GetResultSet Method @53-DC1E6F3F

    Public Sub FillItem(ByVal item As ENROL_CHECKLIST1Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record ENROL_CHECKLIST1 Data Provider Class GetResultSet Method

'Record ENROL_CHECKLIST1 BeforeBuildSelect @53-967EB6F0
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("ID58",UrlID, "","ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record ENROL_CHECKLIST1 BeforeBuildSelect

'Record ENROL_CHECKLIST1 BeforeExecuteSelect @53-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record ENROL_CHECKLIST1 BeforeExecuteSelect

'Record ENROL_CHECKLIST1 AfterExecuteSelect @53-CF8E2433
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.DESCRIPTION.SetValue(dr(i)("DESCRIPTION"),"")
            item.CATEGORIES_REQUIRED.SetValue(dr(i)("CATEGORIES_REQUIRED"),"")
            item.CATEGORIES_OPTIONAL.SetValue(dr(i)("CATEGORIES_OPTIONAL"),"")
            item.CATEGORIES_NOTAPPLICABLE.SetValue(dr(i)("CATEGORIES_NOTAPPLICABLE"),"")
            item.ACTIVE.SetValue(dr(i)("ACTIVE"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),"yyyy-MM-dd HH\:mm\:ss")
            item.lblLastAlteredBy.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.lblLastAlteredWhen.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
'End Record ENROL_CHECKLIST1 AfterExecuteSelect

'ListBox ACTIVE AfterExecuteSelect @63-642FE97B
        
item.ACTIVEItems.Add("Y","Yes (default)")
item.ACTIVEItems.Add("N","No")
'End ListBox ACTIVE AfterExecuteSelect

'Record ENROL_CHECKLIST1 AfterExecuteSelect tail @53-E31F8E2A
    End Sub
'End Record ENROL_CHECKLIST1 AfterExecuteSelect tail

'Record ENROL_CHECKLIST1 Data Provider Class @53-A61BA892
End Class

'End Record ENROL_CHECKLIST1 Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

