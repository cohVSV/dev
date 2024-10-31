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

Namespace DECV_PROD2007.MaintainSearchRequest_Primary 'Namespace @1-2DF64896

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

'Grid viewPrimaryTeacherSearchR1 Item Class @3-02AF142D
Public Class viewPrimaryTeacherSearchR1Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STUDENT_ID As FloatField
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public YEAR_LEVEL As IntegerField
    Public ENROLMENT_STATUS As TextField
    Public STAFF_ID As TextField
    Public PASTORAL_CARE_ID As TextField
    Public ENROLMENT_YEAR As FloatField
    Public Sub New()
    STUDENT_ID = New FloatField("", Nothing)
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    YEAR_LEVEL = New IntegerField("", Nothing)
    ENROLMENT_STATUS = New TextField("", Nothing)
    STAFF_ID = New TextField("", Nothing)
    PASTORAL_CARE_ID = New TextField("", Nothing)
    ENROLMENT_YEAR = New FloatField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
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
                Case "STAFF_ID"
                    Return Me.STAFF_ID
                Case "PASTORAL_CARE_ID"
                    Return Me.PASTORAL_CARE_ID
                Case "ENROLMENT_YEAR"
                    Return Me.ENROLMENT_YEAR
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
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
                Case "STAFF_ID"
                    Me.STAFF_ID = CType(Value,TextField)
                Case "PASTORAL_CARE_ID"
                    Me.PASTORAL_CARE_ID = CType(Value,TextField)
                Case "ENROLMENT_YEAR"
                    Me.ENROLMENT_YEAR = CType(Value,FloatField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid viewPrimaryTeacherSearchR1 Item Class

'Grid viewPrimaryTeacherSearchR1 Data Provider Class Header @3-B9D02888
Public Class viewPrimaryTeacherSearchR1DataProvider
Inherits GridDataProviderBase
'End Grid viewPrimaryTeacherSearchR1 Data Provider Class Header

'Grid viewPrimaryTeacherSearchR1 Data Provider Class Variables @3-B27E40C4

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_ID
        Sorter_SURNAME
        Sorter_FIRST_NAME
        Sorter_YEAR_LEVEL
        Sorter_ENROLMENT_STATUS
        Sorter_STAFF_ID
        Sorter_PASTORAL_CARE_ID
        Sorter_ENROLMENT_YEAR
    End Enum

    Private SortFieldsNames As String() = New String() {"STUDENT_ID, ENROLMENT_YEAR","STUDENT_ID","SURNAME","FIRST_NAME","YEAR_LEVEL","ENROLMENT_STATUS","STAFF_ID","PASTORAL_CARE_ID","ENROLMENT_YEAR"}
    Private SortFieldsNamesDesc As String() = New string() {"STUDENT_ID, ENROLMENT_YEAR","STUDENT_ID DESC","SURNAME DESC","FIRST_NAME DESC","YEAR_LEVEL DESC","ENROLMENT_STATUS DESC","STAFF_ID DESC","PASTORAL_CARE_ID DESC","ENROLMENT_YEAR DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 50
    Public PageNumber As Integer = 1
    Public Urls_SURNAME  As TextParameter
    Public Urls_STUDENT_ID  As FloatParameter
    Public Urls_ENROLMENT_YEAR  As FloatParameter
'End Grid viewPrimaryTeacherSearchR1 Data Provider Class Variables

'Grid viewPrimaryTeacherSearchR1 Data Provider Class GetResultSet Method @3-7DFDBD65

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM viewPrimaryTeacherSearchRequest {SQL_Where} {SQL_OrderBy}", New String(){"(","s_SURNAME10","Or","s_STUDENT_ID11",")","And","s_ENROLMENT_YEAR12"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM viewPrimaryTeacherSearchRequest", New String(){"(","s_SURNAME10","Or","s_STUDENT_ID11",")","And","s_ENROLMENT_YEAR12"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid viewPrimaryTeacherSearchR1 Data Provider Class GetResultSet Method

'Grid viewPrimaryTeacherSearchR1 Data Provider Class GetResultSet Method @3-096E23CF
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As viewPrimaryTeacherSearchR1Item()
'End Grid viewPrimaryTeacherSearchR1 Data Provider Class GetResultSet Method

'Before build Select @3-AEF4CBBD
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_SURNAME10",Urls_SURNAME, "","SURNAME",Condition.BeginsWith,False)
        CType(Select_,TableCommand).AddParameter("s_STUDENT_ID11",Urls_STUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("s_ENROLMENT_YEAR12",Urls_ENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @3-5E56CFD8
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As viewPrimaryTeacherSearchR1Item
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

'After execute Select @3-B4C34F33
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New viewPrimaryTeacherSearchR1Item(dr.Count-1) {}
'End After execute Select

'After execute Select @3-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @3-DA51ABC2
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as viewPrimaryTeacherSearchR1Item = New viewPrimaryTeacherSearchR1Item()
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
                item.ENROLMENT_STATUS.SetValue(dr(i)("ENROLMENT_STATUS"),"")
                item.STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
                item.PASTORAL_CARE_ID.SetValue(dr(i)("PASTORAL_CARE_ID"),"")
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

'Record viewPrimaryTeacherSearchR Item Class @4-F1D27BF5
Public Class viewPrimaryTeacherSearchRItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_SURNAME As TextField
    Public s_STUDENT_ID As FloatField
    Public s_ENROLMENT_YEAR As IntegerField
    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public Sub New()
    s_SURNAME = New TextField("", Nothing)
    s_STUDENT_ID = New FloatField("", Nothing)
    s_ENROLMENT_YEAR = New IntegerField("", Year(Now()))
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    Link1 = New TextField("",Nothing)
    Link1HrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As viewPrimaryTeacherSearchRItem
        Dim item As viewPrimaryTeacherSearchRItem = New viewPrimaryTeacherSearchRItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_SURNAME")) Then
        item.s_SURNAME.SetValue(DBUtility.GetInitialValue("s_SURNAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_STUDENT_ID")) Then
        item.s_STUDENT_ID.SetValue(DBUtility.GetInitialValue("s_STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_ENROLMENT_YEAR")) Then
        item.s_ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("s_ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link1")) Then
        item.Link1.SetValue(DBUtility.GetInitialValue("Link1"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_SURNAME"
                    Return s_SURNAME
                Case "s_STUDENT_ID"
                    Return s_STUDENT_ID
                Case "s_ENROLMENT_YEAR"
                    Return s_ENROLMENT_YEAR
                Case "ClearParameters"
                    Return ClearParameters
                Case "Link1"
                    Return Link1
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_SURNAME"
                    s_SURNAME = CType(value, TextField)
                Case "s_STUDENT_ID"
                    s_STUDENT_ID = CType(value, FloatField)
                Case "s_ENROLMENT_YEAR"
                    s_ENROLMENT_YEAR = CType(value, IntegerField)
                Case "ClearParameters"
                    ClearParameters = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As viewPrimaryTeacherSearchRDataProvider)
'End Record viewPrimaryTeacherSearchR Item Class

'Record viewPrimaryTeacherSearchR Item Class tail @4-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record viewPrimaryTeacherSearchR Item Class tail

'Record viewPrimaryTeacherSearchR Data Provider Class @4-C12766E5
Public Class viewPrimaryTeacherSearchRDataProvider
Inherits RecordDataProviderBase
'End Record viewPrimaryTeacherSearchR Data Provider Class

'Record viewPrimaryTeacherSearchR Data Provider Class Variables @4-27A9A081
    Protected item As viewPrimaryTeacherSearchRItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record viewPrimaryTeacherSearchR Data Provider Class Variables

'Record viewPrimaryTeacherSearchR Data Provider Class GetResultSet Method @4-CBC98B27

    Public Sub FillItem(ByVal item As viewPrimaryTeacherSearchRItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record viewPrimaryTeacherSearchR Data Provider Class GetResultSet Method

'Record viewPrimaryTeacherSearchR BeforeBuildSelect @4-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record viewPrimaryTeacherSearchR BeforeBuildSelect

'Record viewPrimaryTeacherSearchR AfterExecuteSelect @4-79426A21
        End If
            IsInsertMode = True
'End Record viewPrimaryTeacherSearchR AfterExecuteSelect

'Record viewPrimaryTeacherSearchR AfterExecuteSelect tail @4-E31F8E2A
    End Sub
'End Record viewPrimaryTeacherSearchR AfterExecuteSelect tail

'Record viewPrimaryTeacherSearchR Data Provider Class @4-A61BA892
End Class

'End Record viewPrimaryTeacherSearchR Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

