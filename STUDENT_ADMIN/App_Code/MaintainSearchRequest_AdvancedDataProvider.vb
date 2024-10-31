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

Namespace DECV_PROD2007.MaintainSearchRequest_Advanced 'Namespace @1-A103CBB7

'Page Data Class @1-4CFBDA71
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public LinkExportToExcel As TextField
    Public LinkExportToExcelHref As Object
    Public LinkExportToExcelHrefParameters As LinkParameterCollection
    Public Sub New()
        LinkExportToExcel = New TextField("",Nothing)
        LinkExportToExcelHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.LinkExportToExcel.SetValue(DBUtility.GetInitialValue("LinkExportToExcel"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "LinkExportToExcel"
                    Return LinkExportToExcel
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "LinkExportToExcel"
                    LinkExportToExcel = CType(value, TextField)
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

'Grid viewMaintainSearchRequest1 Item Class @3-0254B1A8
Public Class viewMaintainSearchRequest1Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public viewMaintainSearchRequest1_TotalRecords As TextField
    Public STUDENT_ID As FloatField
    Public STUDENT_IDHref As Object
    Public STUDENT_IDHrefParameters As LinkParameterCollection
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public YEAR_LEVEL As IntegerField
    Public ENROLMENT_STATUS As TextField
    Public ENROLMENT_DATE As DateField
    Public HOME_SCHOOL_ID As TextField
    Public ATTENDING_SCHOOL_ID As TextField
    Public ENROLMENT_YEAR As FloatField
    Public Sub New()
    viewMaintainSearchRequest1_TotalRecords = New TextField("", Nothing)
    STUDENT_ID = New FloatField("",Nothing)
    STUDENT_IDHrefParameters = New LinkParameterCollection()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    YEAR_LEVEL = New IntegerField("", Nothing)
    ENROLMENT_STATUS = New TextField("", Nothing)
    ENROLMENT_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    HOME_SCHOOL_ID = New TextField("", Nothing)
    ATTENDING_SCHOOL_ID = New TextField("", Nothing)
    ENROLMENT_YEAR = New FloatField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "viewMaintainSearchRequest1_TotalRecords"
                    Return Me.viewMaintainSearchRequest1_TotalRecords
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "YEAR_LEVEL"
                    Return Me.YEAR_LEVEL
                Case "ENROLMENT_STATUS"
                    Return Me.ENROLMENT_STATUS
                Case "ENROLMENT_DATE"
                    Return Me.ENROLMENT_DATE
                Case "HOME_SCHOOL_ID"
                    Return Me.HOME_SCHOOL_ID
                Case "ATTENDING_SCHOOL_ID"
                    Return Me.ATTENDING_SCHOOL_ID
                Case "ENROLMENT_YEAR"
                    Return Me.ENROLMENT_YEAR
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "viewMaintainSearchRequest1_TotalRecords"
                    Me.viewMaintainSearchRequest1_TotalRecords = CType(Value,TextField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "YEAR_LEVEL"
                    Me.YEAR_LEVEL = CType(Value,IntegerField)
                Case "ENROLMENT_STATUS"
                    Me.ENROLMENT_STATUS = CType(Value,TextField)
                Case "ENROLMENT_DATE"
                    Me.ENROLMENT_DATE = CType(Value,DateField)
                Case "HOME_SCHOOL_ID"
                    Me.HOME_SCHOOL_ID = CType(Value,TextField)
                Case "ATTENDING_SCHOOL_ID"
                    Me.ATTENDING_SCHOOL_ID = CType(Value,TextField)
                Case "ENROLMENT_YEAR"
                    Me.ENROLMENT_YEAR = CType(Value,FloatField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid viewMaintainSearchRequest1 Item Class

'Grid viewMaintainSearchRequest1 Data Provider Class Header @3-09D8C1B7
Public Class viewMaintainSearchRequest1DataProvider
Inherits GridDataProviderBase
'End Grid viewMaintainSearchRequest1 Data Provider Class Header

'Grid viewMaintainSearchRequest1 Data Provider Class Variables @3-ABB976C5

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_ID
        Sorter_SURNAME
        Sorter_FIRST_NAME
        Sorter_YEAR_LEVEL
        Sorter_ENROLMENT_STATUS
        Sorter_ENROLMENT_DATE
        Sorter_HOME_SCHOOL_ID
        Sorter_ATTENDING_SCHOOL_ID
        Sorter_ENROLMENT_YEAR
    End Enum

    Private SortFieldsNames As String() = New String() {"STUDENT_ID","STUDENT_ID","SURNAME","FIRST_NAME","YEAR_LEVEL","ENROLMENT_STATUS","ENROLMENT_DATE","HOME_SCHOOL_ID","ATTENDING_SCHOOL_ID","ENROLMENT_YEAR"}
    Private SortFieldsNamesDesc As String() = New string() {"STUDENT_ID","STUDENT_ID DESC","SURNAME DESC","FIRST_NAME DESC","YEAR_LEVEL DESC","ENROLMENT_STATUS DESC","ENROLMENT_DATE DESC","HOME_SCHOOL_ID DESC","ATTENDING_SCHOOL_ID DESC","ENROLMENT_YEAR DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 500
    Public PageNumber As Integer = 1
    Public Urls_HOME_SCHOOL_ID  As TextParameter
    Public Urls_ENROLMENT_YEAR  As FloatParameter
'End Grid viewMaintainSearchRequest1 Data Provider Class Variables

'Grid viewMaintainSearchRequest1 Data Provider Class GetResultSet Method @3-531CC8BB

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM viewMaintainSearchRequest_Schools {SQL_Where} {SQL_OrderBy}", New String(){"(","s_HOME_SCHOOL_ID81","Or","s_HOME_SCHOOL_ID82",")","And","s_ENROLMENT_YEAR83","And","expr84"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM viewMaintainSearchRequest_Schools", New String(){"(","s_HOME_SCHOOL_ID81","Or","s_HOME_SCHOOL_ID82",")","And","s_ENROLMENT_YEAR83","And","expr84"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid viewMaintainSearchRequest1 Data Provider Class GetResultSet Method

'Grid viewMaintainSearchRequest1 Data Provider Class GetResultSet Method @3-F7597E21
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As viewMaintainSearchRequest1Item()
'End Grid viewMaintainSearchRequest1 Data Provider Class GetResultSet Method

'Before build Select @3-448B223E
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_HOME_SCHOOL_ID81",Urls_HOME_SCHOOL_ID, "","ATTENDING_SCHOOL_ID",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_HOME_SCHOOL_ID82",Urls_HOME_SCHOOL_ID, "","ORGANISATION_SCHOOL_ID",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_ENROLMENT_YEAR83",Urls_ENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        Select_.Parameters.Add("expr84","(ENROLMENT_STATUS in ('E', 'N', 'F'))")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @3-52D8CFFC
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As viewMaintainSearchRequest1Item
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

'After execute Select @3-72568EAF
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New viewMaintainSearchRequest1Item(dr.Count-1) {}
'End After execute Select

'After execute Select @3-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @3-86A183D3
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as viewMaintainSearchRequest1Item = New viewMaintainSearchRequest1Item()
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.STUDENT_IDHref = "StudentSummary.aspx"
                item.STUDENT_IDHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
                item.STUDENT_IDHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
                item.ENROLMENT_STATUS.SetValue(dr(i)("ENROLMENT_STATUS"),"")
                item.ENROLMENT_DATE.SetValue(dr(i)("ENROLMENT_DATE"),Select_.DateFormat)
                item.HOME_SCHOOL_ID.SetValue(dr(i)("HOME_SCHOOL_ID"),"")
                item.ATTENDING_SCHOOL_ID.SetValue(dr(i)("ATTENDING_SCHOOL_ID"),"")
                item.ENROLMENT_YEAR.SetValue(dr(i)("ENROLMENT_YEAR"),"")
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

'Record viewMaintainSearchRequest Item Class @4-3EC83DFC
Public Class viewMaintainSearchRequestItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_HOME_SCHOOL_ID As TextField
    Public s_ENROLMENT_YEAR As FloatField
    Public s_SCHOOLNAME As TextField
    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public hidden_auto As TextField
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public Sub New()
    s_HOME_SCHOOL_ID = New TextField("", Nothing)
    s_ENROLMENT_YEAR = New FloatField("", Year(Date.Today))
    s_SCHOOLNAME = New TextField("", Nothing)
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    hidden_auto = New TextField("", Nothing)
    Link1 = New TextField("",Nothing)
    Link1HrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As viewMaintainSearchRequestItem
        Dim item As viewMaintainSearchRequestItem = New viewMaintainSearchRequestItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_HOME_SCHOOL_ID")) Then
        item.s_HOME_SCHOOL_ID.SetValue(DBUtility.GetInitialValue("s_HOME_SCHOOL_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_ENROLMENT_YEAR")) Then
        item.s_ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("s_ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_SCHOOLNAME")) Then
        item.s_SCHOOLNAME.SetValue(DBUtility.GetInitialValue("s_SCHOOLNAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_auto")) Then
        item.hidden_auto.SetValue(DBUtility.GetInitialValue("hidden_auto"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link1")) Then
        item.Link1.SetValue(DBUtility.GetInitialValue("Link1"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_HOME_SCHOOL_ID"
                    Return s_HOME_SCHOOL_ID
                Case "s_ENROLMENT_YEAR"
                    Return s_ENROLMENT_YEAR
                Case "s_SCHOOLNAME"
                    Return s_SCHOOLNAME
                Case "ClearParameters"
                    Return ClearParameters
                Case "hidden_auto"
                    Return hidden_auto
                Case "Link1"
                    Return Link1
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_HOME_SCHOOL_ID"
                    s_HOME_SCHOOL_ID = CType(value, TextField)
                Case "s_ENROLMENT_YEAR"
                    s_ENROLMENT_YEAR = CType(value, FloatField)
                Case "s_SCHOOLNAME"
                    s_SCHOOLNAME = CType(value, TextField)
                Case "ClearParameters"
                    ClearParameters = CType(value, TextField)
                Case "hidden_auto"
                    hidden_auto = CType(value, TextField)
                Case "Link1"
                    Link1 = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As viewMaintainSearchRequestDataProvider)
'End Record viewMaintainSearchRequest Item Class

's_HOME_SCHOOL_ID validate @7-9FE9ECF7
        If IsNothing(s_HOME_SCHOOL_ID.Value) OrElse s_HOME_SCHOOL_ID.Value.ToString() ="" Then
            errors.Add("s_HOME_SCHOOL_ID",String.Format(Resources.strings.CCS_RequiredField,"HOME SCHOOL ID"))
        End If
'End s_HOME_SCHOOL_ID validate

's_ENROLMENT_YEAR validate @8-A6E408C9
        If IsNothing(s_ENROLMENT_YEAR.Value) OrElse s_ENROLMENT_YEAR.Value.ToString() ="" Then
            errors.Add("s_ENROLMENT_YEAR",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT YEAR"))
        End If
'End s_ENROLMENT_YEAR validate

'Record viewMaintainSearchRequest Item Class tail @4-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record viewMaintainSearchRequest Item Class tail

'Record viewMaintainSearchRequest Data Provider Class @4-77F14331
Public Class viewMaintainSearchRequestDataProvider
Inherits RecordDataProviderBase
'End Record viewMaintainSearchRequest Data Provider Class

'Record viewMaintainSearchRequest Data Provider Class Variables @4-5C619156
    Protected item As viewMaintainSearchRequestItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record viewMaintainSearchRequest Data Provider Class Variables

'Record viewMaintainSearchRequest Data Provider Class GetResultSet Method @4-D5AB571D

    Public Sub FillItem(ByVal item As viewMaintainSearchRequestItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record viewMaintainSearchRequest Data Provider Class GetResultSet Method

'Record viewMaintainSearchRequest BeforeBuildSelect @4-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record viewMaintainSearchRequest BeforeBuildSelect

'Record viewMaintainSearchRequest AfterExecuteSelect @4-79426A21
        End If
            IsInsertMode = True
'End Record viewMaintainSearchRequest AfterExecuteSelect

'Record viewMaintainSearchRequest AfterExecuteSelect tail @4-E31F8E2A
    End Sub
'End Record viewMaintainSearchRequest AfterExecuteSelect tail

'Record viewMaintainSearchRequest Data Provider Class @4-A61BA892
End Class

'End Record viewMaintainSearchRequest Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

