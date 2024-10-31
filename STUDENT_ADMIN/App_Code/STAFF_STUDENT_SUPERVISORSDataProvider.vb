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

Namespace DECV_PROD2007.STAFF_STUDENT_SUPERVISORS 'Namespace @1-4F516B54

'Page Data Class @1-D5367AEE
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public STAFF_STUDENT_SUPERVISORS_Insert As TextField
    Public STAFF_STUDENT_SUPERVISORS_InsertHref As Object
    Public STAFF_STUDENT_SUPERVISORS_InsertHrefParameters As LinkParameterCollection
    Public Sub New()
        STAFF_STUDENT_SUPERVISORS_Insert = New TextField("",Nothing)
        STAFF_STUDENT_SUPERVISORS_InsertHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.STAFF_STUDENT_SUPERVISORS_Insert.SetValue(DBUtility.GetInitialValue("STAFF_STUDENT_SUPERVISORS_Insert"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "STAFF_STUDENT_SUPERVISORS_Insert"
                    Return STAFF_STUDENT_SUPERVISORS_Insert
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STAFF_STUDENT_SUPERVISORS_Insert"
                    STAFF_STUDENT_SUPERVISORS_Insert = CType(value, TextField)
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

'Grid STAFF_STUDENT_SUPERVISORS Item Class @4-2B47C081
Public Class STAFF_STUDENT_SUPERVISORSItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STAFF_STUDENT_SUPERVISORS_Insert As TextField
    Public STAFF_STUDENT_SUPERVISORS_InsertHref As Object
    Public STAFF_STUDENT_SUPERVISORS_InsertHrefParameters As LinkParameterCollection
    Public STAFF_STUDENT_SUPERVISORS_TotalRecords As TextField
    Public Detail As TextField
    Public DetailHref As Object
    Public DetailHrefParameters As LinkParameterCollection
    Public YEAR_LEVEL As IntegerField
    Public SUPERVISOR_NAME As TextField
    Public SUPERVISOR_EMAIL As TextField
    Public SUPERVISOR_PHONE As TextField
    Public STATUS As IntegerField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    STAFF_STUDENT_SUPERVISORS_Insert = New TextField("",Nothing)
    STAFF_STUDENT_SUPERVISORS_InsertHrefParameters = New LinkParameterCollection()
    STAFF_STUDENT_SUPERVISORS_TotalRecords = New TextField("", Nothing)
    Detail = New TextField("",Nothing)
    DetailHrefParameters = New LinkParameterCollection()
    YEAR_LEVEL = New IntegerField("", Nothing)
    SUPERVISOR_NAME = New TextField("", Nothing)
    SUPERVISOR_EMAIL = New TextField("", Nothing)
    SUPERVISOR_PHONE = New TextField("", Nothing)
    STATUS = New IntegerField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STAFF_STUDENT_SUPERVISORS_Insert"
                    Return Me.STAFF_STUDENT_SUPERVISORS_Insert
                Case "STAFF_STUDENT_SUPERVISORS_TotalRecords"
                    Return Me.STAFF_STUDENT_SUPERVISORS_TotalRecords
                Case "Detail"
                    Return Me.Detail
                Case "YEAR_LEVEL"
                    Return Me.YEAR_LEVEL
                Case "SUPERVISOR_NAME"
                    Return Me.SUPERVISOR_NAME
                Case "SUPERVISOR_EMAIL"
                    Return Me.SUPERVISOR_EMAIL
                Case "SUPERVISOR_PHONE"
                    Return Me.SUPERVISOR_PHONE
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
                Case "STAFF_STUDENT_SUPERVISORS_Insert"
                    Me.STAFF_STUDENT_SUPERVISORS_Insert = CType(Value,TextField)
                Case "STAFF_STUDENT_SUPERVISORS_TotalRecords"
                    Me.STAFF_STUDENT_SUPERVISORS_TotalRecords = CType(Value,TextField)
                Case "Detail"
                    Me.Detail = CType(Value,TextField)
                Case "YEAR_LEVEL"
                    Me.YEAR_LEVEL = CType(Value,IntegerField)
                Case "SUPERVISOR_NAME"
                    Me.SUPERVISOR_NAME = CType(Value,TextField)
                Case "SUPERVISOR_EMAIL"
                    Me.SUPERVISOR_EMAIL = CType(Value,TextField)
                Case "SUPERVISOR_PHONE"
                    Me.SUPERVISOR_PHONE = CType(Value,TextField)
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
'End Grid STAFF_STUDENT_SUPERVISORS Item Class

'Grid STAFF_STUDENT_SUPERVISORS Data Provider Class Header @4-F8FE1470
Public Class STAFF_STUDENT_SUPERVISORSDataProvider
Inherits GridDataProviderBase
'End Grid STAFF_STUDENT_SUPERVISORS Data Provider Class Header

'Grid STAFF_STUDENT_SUPERVISORS Data Provider Class Variables @4-BA0092E6

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_YEAR_LEVEL
        Sorter_SUPERVISOR_NAME
        Sorter_SUPERVISOR_EMAIL
        Sorter_SUPERVISOR_PHONE
        Sorter_STATUS
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE
    End Enum

    Private SortFieldsNames As String() = New String() {"YEAR_LEVEL","YEAR_LEVEL","SUPERVISOR_NAME","SUPERVISOR_EMAIL","SUPERVISOR_PHONE","STATUS","LAST_ALTERED_BY","LAST_ALTERED_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"YEAR_LEVEL","YEAR_LEVEL DESC","SUPERVISOR_NAME DESC","SUPERVISOR_EMAIL DESC","SUPERVISOR_PHONE DESC","STATUS DESC","LAST_ALTERED_BY DESC","LAST_ALTERED_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 30
    Public PageNumber As Integer = 1
    Public Urls_keyword  As TextParameter
'End Grid STAFF_STUDENT_SUPERVISORS Data Provider Class Variables

'Grid STAFF_STUDENT_SUPERVISORS Data Provider Class GetResultSet Method @4-0BF45B73

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} id, YEAR_LEVEL, SUPERVISOR_NAME, SUPERVISOR_EMAIL, " & vbCrLf & _
          "SUPERVISOR_PHONE, STATUS, LAST_ALTERED_BY, " & vbCrLf & _
          "LAST_ALTERED_DATE " & vbCrLf & _
          "FROM STAFF_STUDENT_SUPERVISORS {SQL_Where} {SQL_OrderBy}", New String(){"(","s_keyword13","Or","s_keyword14","Or","s_keyword15",")"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STAFF_STUDENT_SUPERVISORS", New String(){"(","s_keyword13","Or","s_keyword14","Or","s_keyword15",")"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid STAFF_STUDENT_SUPERVISORS Data Provider Class GetResultSet Method

'Grid STAFF_STUDENT_SUPERVISORS Data Provider Class GetResultSet Method @4-7DE2B198
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STAFF_STUDENT_SUPERVISORSItem()
'End Grid STAFF_STUDENT_SUPERVISORS Data Provider Class GetResultSet Method

'Before build Select @4-95AAA3DD
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_keyword13",Urls_keyword, "","SUPERVISOR_NAME",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword14",Urls_keyword, "","SUPERVISOR_EMAIL",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword15",Urls_keyword, "","SUPERVISOR_PHONE",Condition.Contains,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @4-82CE79A6
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STAFF_STUDENT_SUPERVISORSItem
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

'After execute Select @4-D4AD8E9B
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STAFF_STUDENT_SUPERVISORSItem(dr.Count-1) {}
'End After execute Select

'After execute Select @4-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @4-6C1AC7DB
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STAFF_STUDENT_SUPERVISORSItem = New STAFF_STUDENT_SUPERVISORSItem()
                item.STAFF_STUDENT_SUPERVISORS_InsertHref = "STAFF_STUDENT_SUPERVISORS.aspx"
                item.DetailHref = "STAFF_STUDENT_SUPERVISORS.aspx"
                item.DetailHrefParameters.Add("id",System.Web.HttpUtility.UrlEncode(dr(i)("id").ToString()))
                item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
                item.SUPERVISOR_NAME.SetValue(dr(i)("SUPERVISOR_NAME"),"")
                item.SUPERVISOR_EMAIL.SetValue(dr(i)("SUPERVISOR_EMAIL"),"")
                item.SUPERVISOR_PHONE.SetValue(dr(i)("SUPERVISOR_PHONE"),"")
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

'Grid Data Provider tail @4-A61BA892
End Class
'End Grid Data Provider tail

'Record STAFF_STUDENT_SUPERVISORSSearch Item Class @5-62784256
Public Class STAFF_STUDENT_SUPERVISORSSearchItem
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

    Public Shared Function CreateFromHttpRequest() As STAFF_STUDENT_SUPERVISORSSearchItem
        Dim item As STAFF_STUDENT_SUPERVISORSSearchItem = New STAFF_STUDENT_SUPERVISORSSearchItem()
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

    Public Sub Validate(ByVal provider As STAFF_STUDENT_SUPERVISORSSearchDataProvider)
'End Record STAFF_STUDENT_SUPERVISORSSearch Item Class

'Record STAFF_STUDENT_SUPERVISORSSearch Item Class tail @5-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STAFF_STUDENT_SUPERVISORSSearch Item Class tail

'Record STAFF_STUDENT_SUPERVISORSSearch Data Provider Class @5-6EF526FD
Public Class STAFF_STUDENT_SUPERVISORSSearchDataProvider
Inherits RecordDataProviderBase
'End Record STAFF_STUDENT_SUPERVISORSSearch Data Provider Class

'Record STAFF_STUDENT_SUPERVISORSSearch Data Provider Class Variables @5-9463F5B1
    Protected item As STAFF_STUDENT_SUPERVISORSSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STAFF_STUDENT_SUPERVISORSSearch Data Provider Class Variables

'Record STAFF_STUDENT_SUPERVISORSSearch Data Provider Class GetResultSet Method @5-2BB0052B

    Public Sub FillItem(ByVal item As STAFF_STUDENT_SUPERVISORSSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record STAFF_STUDENT_SUPERVISORSSearch Data Provider Class GetResultSet Method

'Record STAFF_STUDENT_SUPERVISORSSearch BeforeBuildSelect @5-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STAFF_STUDENT_SUPERVISORSSearch BeforeBuildSelect

'Record STAFF_STUDENT_SUPERVISORSSearch AfterExecuteSelect @5-79426A21
        End If
            IsInsertMode = True
'End Record STAFF_STUDENT_SUPERVISORSSearch AfterExecuteSelect

'Record STAFF_STUDENT_SUPERVISORSSearch AfterExecuteSelect tail @5-E31F8E2A
    End Sub
'End Record STAFF_STUDENT_SUPERVISORSSearch AfterExecuteSelect tail

'Record STAFF_STUDENT_SUPERVISORSSearch Data Provider Class @5-A61BA892
End Class

'End Record STAFF_STUDENT_SUPERVISORSSearch Data Provider Class

'Record STAFF_STUDENT_SUPERVISORS1 Item Class @40-040C5E03
Public Class STAFF_STUDENT_SUPERVISORS1Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public YEAR_LEVEL As IntegerField
    Public YEAR_LEVELItems As ItemCollection
    Public SUPERVISOR_NAME As TextField
    Public SUPERVISOR_EMAIL As TextField
    Public SUPERVISOR_PHONE As TextField
    Public STATUS As IntegerField
    Public STATUSItems As ItemCollection
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Hidden_LAST_ALTERED_BY As TextField
    Public Hidden_LAST_ALTERED_DATE As TextField
    Public Sub New()
    YEAR_LEVEL = New IntegerField("", Nothing)
    YEAR_LEVELItems = New ItemCollection()
    SUPERVISOR_NAME = New TextField("", Nothing)
    SUPERVISOR_EMAIL = New TextField("", Nothing)
    SUPERVISOR_PHONE = New TextField("", Nothing)
    STATUS = New IntegerField("", 1)
    STATUSItems = New ItemCollection()
    LAST_ALTERED_BY = New TextField("", "unknown")
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    Hidden_LAST_ALTERED_BY = New TextField("", DBUtility.UserLogin)
    Hidden_LAST_ALTERED_DATE = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STAFF_STUDENT_SUPERVISORS1Item
        Dim item As STAFF_STUDENT_SUPERVISORS1Item = New STAFF_STUDENT_SUPERVISORS1Item()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("YEAR_LEVEL")) Then
        item.YEAR_LEVEL.SetValue(DBUtility.GetInitialValue("YEAR_LEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPERVISOR_NAME")) Then
        item.SUPERVISOR_NAME.SetValue(DBUtility.GetInitialValue("SUPERVISOR_NAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPERVISOR_EMAIL")) Then
        item.SUPERVISOR_EMAIL.SetValue(DBUtility.GetInitialValue("SUPERVISOR_EMAIL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPERVISOR_PHONE")) Then
        item.SUPERVISOR_PHONE.SetValue(DBUtility.GetInitialValue("SUPERVISOR_PHONE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STATUS")) Then
        item.STATUS.SetValue(DBUtility.GetInitialValue("STATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_LAST_ALTERED_BY")) Then
        item.Hidden_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("Hidden_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_LAST_ALTERED_DATE")) Then
        item.Hidden_LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("Hidden_LAST_ALTERED_DATE"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "YEAR_LEVEL"
                    Return YEAR_LEVEL
                Case "SUPERVISOR_NAME"
                    Return SUPERVISOR_NAME
                Case "SUPERVISOR_EMAIL"
                    Return SUPERVISOR_EMAIL
                Case "SUPERVISOR_PHONE"
                    Return SUPERVISOR_PHONE
                Case "STATUS"
                    Return STATUS
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "Hidden_LAST_ALTERED_BY"
                    Return Hidden_LAST_ALTERED_BY
                Case "Hidden_LAST_ALTERED_DATE"
                    Return Hidden_LAST_ALTERED_DATE
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "YEAR_LEVEL"
                    YEAR_LEVEL = CType(value, IntegerField)
                Case "SUPERVISOR_NAME"
                    SUPERVISOR_NAME = CType(value, TextField)
                Case "SUPERVISOR_EMAIL"
                    SUPERVISOR_EMAIL = CType(value, TextField)
                Case "SUPERVISOR_PHONE"
                    SUPERVISOR_PHONE = CType(value, TextField)
                Case "STATUS"
                    STATUS = CType(value, IntegerField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "Hidden_LAST_ALTERED_BY"
                    Hidden_LAST_ALTERED_BY = CType(value, TextField)
                Case "Hidden_LAST_ALTERED_DATE"
                    Hidden_LAST_ALTERED_DATE = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STAFF_STUDENT_SUPERVISORS1DataProvider)
'End Record STAFF_STUDENT_SUPERVISORS1 Item Class

'YEAR_LEVEL validate @47-30512612
        If IsNothing(YEAR_LEVEL.Value) OrElse YEAR_LEVEL.Value.ToString() ="" Then
            errors.Add("YEAR_LEVEL",String.Format(Resources.strings.CCS_RequiredField,"YEAR LEVEL"))
        End If
'End YEAR_LEVEL validate

'SUPERVISOR_NAME validate @48-44F2F035
        If IsNothing(SUPERVISOR_NAME.Value) OrElse SUPERVISOR_NAME.Value.ToString() ="" Then
            errors.Add("SUPERVISOR_NAME",String.Format(Resources.strings.CCS_RequiredField,"SUPERVISOR NAME"))
        End If
'End SUPERVISOR_NAME validate

'SUPERVISOR_EMAIL validate @49-F655F405
        If IsNothing(SUPERVISOR_EMAIL.Value) OrElse SUPERVISOR_EMAIL.Value.ToString() ="" Then
            errors.Add("SUPERVISOR_EMAIL",String.Format(Resources.strings.CCS_RequiredField,"SUPERVISOR EMAIL"))
        End If
'End SUPERVISOR_EMAIL validate

'SUPERVISOR_PHONE validate @50-1FC1C52C
        If IsNothing(SUPERVISOR_PHONE.Value) OrElse SUPERVISOR_PHONE.Value.ToString() ="" Then
            errors.Add("SUPERVISOR_PHONE",String.Format(Resources.strings.CCS_RequiredField,"SUPERVISOR PHONE"))
        End If
'End SUPERVISOR_PHONE validate

'STATUS validate @51-73C7378E
        If IsNothing(STATUS.Value) OrElse STATUS.Value.ToString() ="" Then
            errors.Add("STATUS",String.Format(Resources.strings.CCS_RequiredField,"STATUS"))
        End If
'End STATUS validate

'Record STAFF_STUDENT_SUPERVISORS1 Event OnValidate. Action Validate Email @59-4074ED92
        If Not(SUPERVISOR_EMAIL.Value Is Nothing) Then
            Dim mask As Regex = New Regex("^[\w\.-]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]+$",RegexOptions.IgnoreCase  Or RegexOptions.Multiline)
            If Not(mask.Match(SUPERVISOR_EMAIL.Value.ToString()).Success)
                errors.Add("SUPERVISOR_EMAIL",String.Format("Check that the Email address is valid - eg: 'bob@example.net.au'","STAFF_STUDENT_SUPERVISORS1"))
            End If
        End If
'End Record STAFF_STUDENT_SUPERVISORS1 Event OnValidate. Action Validate Email

'Record STAFF_STUDENT_SUPERVISORS1 Event OnValidate. Action Regular Expression Validation @60-77DEC175
        If Not (SUPERVISOR_PHONE.Value Is Nothing) Then
            Dim mask As Regex = New Regex("(^0[2|3|7|8]{1}[\s\-]{0,1}[0-9]{4}[\s\-]{0,1}[0-9]{4}$)|(^04\d{2,3}[\s\-]{0,1}\d{3}[\s\-]{" & _
"0,1}\d{3}$)",RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            If Not(mask.Match(SUPERVISOR_PHONE.Value.ToString()).Success)
                errors.Add("SUPERVISOR_PHONE",String.Format("Phone Number must be an Australian number, including Area Code, with numbers, spaces, or h" & _
  "yphens only. eg: 03 8480 5123 or 03-8480-5123","STAFF_STUDENT_SUPERVISORS1"))
            End If
        End If
'End Record STAFF_STUDENT_SUPERVISORS1 Event OnValidate. Action Regular Expression Validation

'Record STAFF_STUDENT_SUPERVISORS1 Item Class tail @40-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STAFF_STUDENT_SUPERVISORS1 Item Class tail

'Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class @40-2D630B2E
Public Class STAFF_STUDENT_SUPERVISORS1DataProvider
Inherits RecordDataProviderBase
'End Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class

'Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class Variables @40-F74CE93B
    Public Urlid As IntegerParameter
    Protected item As STAFF_STUDENT_SUPERVISORS1Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class Variables

'Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class Constructor @40-0AFB9CB9

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STAFF_STUDENT_SUPERVISORS {SQL_Where} {SQL_OrderBy}", New String(){"id46"},Settings.connDECVPRODSQL2005DataAccessObject )
        Delete=new TableCommand("DELETE FROM STAFF_STUDENT_SUPERVISORS", New String(){"id46"},Settings.connDECVPRODSQL2005DataAccessObject , true)
        Select_.OrderBy=""
    End Sub
'End Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class Constructor

'Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class LoadParams Method @40-296B5411

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(Urlid))
    End Function
'End Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class LoadParams Method

'Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class CheckUnique Method @40-D30833C1

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STAFF_STUDENT_SUPERVISORS1Item) As Boolean
        Return True
    End Function
'End Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class CheckUnique Method

'Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class PrepareInsert Method @40-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class PrepareInsert Method

'Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class PrepareInsert Method tail @40-E31F8E2A
    End Sub
'End Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class PrepareInsert Method tail

'Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class Insert Method @40-5C5629FB

    Public Function InsertItem(ByVal item As STAFF_STUDENT_SUPERVISORS1Item) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO STAFF_STUDENT_SUPERVISORS({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class Insert Method

'Record STAFF_STUDENT_SUPERVISORS1 Build insert @40-1FB7B35E
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.YEAR_LEVEL.IsEmpty Then
        allEmptyFlag = item.YEAR_LEVEL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "YEAR_LEVEL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.SUPERVISOR_NAME.IsEmpty Then
        allEmptyFlag = item.SUPERVISOR_NAME.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUPERVISOR_NAME,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUPERVISOR_NAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPERVISOR_EMAIL.IsEmpty Then
        allEmptyFlag = item.SUPERVISOR_EMAIL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUPERVISOR_EMAIL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUPERVISOR_EMAIL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPERVISOR_PHONE.IsEmpty Then
        allEmptyFlag = item.SUPERVISOR_PHONE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUPERVISOR_PHONE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUPERVISOR_PHONE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STATUS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STATUS.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.Hidden_LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.Hidden_LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.Hidden_LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_LAST_ALTERED_DATE.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STAFF_STUDENT_SUPERVISORS1 Build insert

'Record STAFF_STUDENT_SUPERVISORS1 AfterExecuteInsert @40-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STAFF_STUDENT_SUPERVISORS1 AfterExecuteInsert

'Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class PrepareUpdate Method @40-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class PrepareUpdate Method

'Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class PrepareUpdate Method tail @40-E31F8E2A
    End Sub
'End Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class PrepareUpdate Method tail

'Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class Update Method @40-B5A771BC

    Public Function UpdateItem(ByVal item As STAFF_STUDENT_SUPERVISORS1Item) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STAFF_STUDENT_SUPERVISORS SET {Values}", New String(){"id46"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class Update Method

'Record STAFF_STUDENT_SUPERVISORS1 BeforeBuildUpdate @40-4D47023E
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("id46",Urlid, "","id",Condition.Equal,False)
        If Not item.YEAR_LEVEL.IsEmpty Then
        allEmptyFlag = item.YEAR_LEVEL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "YEAR_LEVEL=" + Update.Dao.ToSql(item.YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.SUPERVISOR_NAME.IsEmpty Then
        allEmptyFlag = item.SUPERVISOR_NAME.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUPERVISOR_NAME=" + Update.Dao.ToSql(item.SUPERVISOR_NAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPERVISOR_EMAIL.IsEmpty Then
        allEmptyFlag = item.SUPERVISOR_EMAIL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUPERVISOR_EMAIL=" + Update.Dao.ToSql(item.SUPERVISOR_EMAIL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPERVISOR_PHONE.IsEmpty Then
        allEmptyFlag = item.SUPERVISOR_PHONE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUPERVISOR_PHONE=" + Update.Dao.ToSql(item.SUPERVISOR_PHONE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STATUS=" + Update.Dao.ToSql(item.STATUS.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.Hidden_LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.Hidden_LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.Hidden_LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.Hidden_LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.Hidden_LAST_ALTERED_DATE.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STAFF_STUDENT_SUPERVISORS1 BeforeBuildUpdate

'Record STAFF_STUDENT_SUPERVISORS1 AfterExecuteUpdate @40-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STAFF_STUDENT_SUPERVISORS1 AfterExecuteUpdate

'Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class PrepareDelete Method @40-F7361E57

    Protected Overrides Sub PrepareDelete()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class PrepareDelete Method

'Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class PrepareDelete Method tail @40-E31F8E2A
    End Sub
'End Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class PrepareDelete Method tail

'Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class Delete Method @40-35E14D45
    Public Function DeleteItem(ByVal item As STAFF_STUDENT_SUPERVISORS1Item) As Integer
        Me.item = item
'End Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class Delete Method

'Record STAFF_STUDENT_SUPERVISORS1 BeforeBuildDelete @40-FE487B09
        Delete.Parameters.Clear()
        CType(Delete,TableCommand).AddParameter("id46",Urlid, "","id",Condition.Equal,False)
        Delete.SqlQuery.Replace("{YEAR_LEVEL}",Delete.Dao.ToSql(item.YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer))
        Delete.SqlQuery.Replace("{SUPERVISOR_NAME}",Delete.Dao.ToSql(item.SUPERVISOR_NAME.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{SUPERVISOR_EMAIL}",Delete.Dao.ToSql(item.SUPERVISOR_EMAIL.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{SUPERVISOR_PHONE}",Delete.Dao.ToSql(item.SUPERVISOR_PHONE.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{STATUS}",Delete.Dao.ToSql(item.STATUS.GetFormattedValue(""),FieldType._Integer))
        Delete.SqlQuery.Replace("{Hidden_LAST_ALTERED_BY}",Delete.Dao.ToSql(item.Hidden_LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{Hidden_LAST_ALTERED_DATE}",Delete.Dao.ToSql(item.Hidden_LAST_ALTERED_DATE.GetFormattedValue(""),FieldType._Text))
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
            result = ExecuteDelete()
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record STAFF_STUDENT_SUPERVISORS1 BeforeBuildDelete

'Record STAFF_STUDENT_SUPERVISORS1 BeforeBuildDelete @40-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STAFF_STUDENT_SUPERVISORS1 BeforeBuildDelete

'Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class GetResultSet Method @40-F006392D

    Public Sub FillItem(ByVal item As STAFF_STUDENT_SUPERVISORS1Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class GetResultSet Method

'Record STAFF_STUDENT_SUPERVISORS1 BeforeBuildSelect @40-5FE81A0C
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("id46",Urlid, "","id",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STAFF_STUDENT_SUPERVISORS1 BeforeBuildSelect

'Record STAFF_STUDENT_SUPERVISORS1 BeforeExecuteSelect @40-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STAFF_STUDENT_SUPERVISORS1 BeforeExecuteSelect

'Record STAFF_STUDENT_SUPERVISORS1 AfterExecuteSelect @40-A093A35B
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
            item.SUPERVISOR_NAME.SetValue(dr(i)("SUPERVISOR_NAME"),"")
            item.SUPERVISOR_EMAIL.SetValue(dr(i)("SUPERVISOR_EMAIL"),"")
            item.SUPERVISOR_PHONE.SetValue(dr(i)("SUPERVISOR_PHONE"),"")
            item.STATUS.SetValue(dr(i)("STATUS"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.Hidden_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.Hidden_LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),"")
        Else
            IsInsertMode = True
        End If
'End Record STAFF_STUDENT_SUPERVISORS1 AfterExecuteSelect

'ListBox YEAR_LEVEL AfterExecuteSelect @47-E273DC42
        
item.YEAR_LEVELItems.Add("0","0 - Prep")
item.YEAR_LEVELItems.Add("1","1")
item.YEAR_LEVELItems.Add("2","2")
item.YEAR_LEVELItems.Add("3","3")
item.YEAR_LEVELItems.Add("4","4")
item.YEAR_LEVELItems.Add("5","5")
item.YEAR_LEVELItems.Add("6","6")
item.YEAR_LEVELItems.Add("7","7")
item.YEAR_LEVELItems.Add("8","8")
item.YEAR_LEVELItems.Add("9","9")
item.YEAR_LEVELItems.Add("10","10")
item.YEAR_LEVELItems.Add("11","11")
item.YEAR_LEVELItems.Add("12","12")
'End ListBox YEAR_LEVEL AfterExecuteSelect

'ListBox STATUS AfterExecuteSelect @51-BAC365F8
        
item.STATUSItems.Add("1","Active")
item.STATUSItems.Add("0","Inactive")
'End ListBox STATUS AfterExecuteSelect

'Record STAFF_STUDENT_SUPERVISORS1 AfterExecuteSelect tail @40-E31F8E2A
    End Sub
'End Record STAFF_STUDENT_SUPERVISORS1 AfterExecuteSelect tail

'Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class @40-A61BA892
End Class

'End Record STAFF_STUDENT_SUPERVISORS1 Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

