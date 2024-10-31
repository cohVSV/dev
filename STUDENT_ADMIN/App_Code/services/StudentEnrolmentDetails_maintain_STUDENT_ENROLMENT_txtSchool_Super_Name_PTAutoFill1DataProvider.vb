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

Namespace DECV_PROD2007.services.StudentEnrolmentDetails_maintain_STUDENT_ENROLMENT_txtSchool_Super_Name_PTAutoFill1 'Namespace @1-75D6E4A3

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

'Grid SELECT_distinct_SCHOOL_SU Item Class @2-A6C4D959
Public Class SELECT_distinct_SCHOOL_SUItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public SCHOOL_SUPERVISOR_NAME As TextField
    Public SCHOOL_SUPERVISOR_PHONE As TextField
    Public SCHOOL_SUPERVISOR_EMAIL As TextField
    Public Sub New()
    SCHOOL_SUPERVISOR_NAME = New TextField("", Nothing)
    SCHOOL_SUPERVISOR_PHONE = New TextField("", Nothing)
    SCHOOL_SUPERVISOR_EMAIL = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "SCHOOL_SUPERVISOR_NAME"
                    Return Me.SCHOOL_SUPERVISOR_NAME
                Case "SCHOOL_SUPERVISOR_PHONE"
                    Return Me.SCHOOL_SUPERVISOR_PHONE
                Case "SCHOOL_SUPERVISOR_EMAIL"
                    Return Me.SCHOOL_SUPERVISOR_EMAIL
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SCHOOL_SUPERVISOR_NAME"
                    Me.SCHOOL_SUPERVISOR_NAME = CType(Value,TextField)
                Case "SCHOOL_SUPERVISOR_PHONE"
                    Me.SCHOOL_SUPERVISOR_PHONE = CType(Value,TextField)
                Case "SCHOOL_SUPERVISOR_EMAIL"
                    Me.SCHOOL_SUPERVISOR_EMAIL = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid SELECT_distinct_SCHOOL_SU Item Class

'Grid SELECT_distinct_SCHOOL_SU Data Provider Class Header @2-B011F2A4
Public Class SELECT_distinct_SCHOOL_SUDataProvider
Inherits GridDataProviderBase
'End Grid SELECT_distinct_SCHOOL_SU Data Provider Class Header

'Grid SELECT_distinct_SCHOOL_SU Data Provider Class Variables @2-53B9A9EE

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 10
    Public PageNumber As Integer = 1
'End Grid SELECT_distinct_SCHOOL_SU Data Provider Class Variables

'Grid SELECT_distinct_SCHOOL_SU Data Provider Class GetResultSet Method @2-C873CFBC

    Public Sub New()
        Select_=new SqlCommand("SELECT distinct SCHOOL_SUPERVISOR_NAME, isnull(SCHOOL_SUPERVISOR_PHONE,'') as SCHOOL_SUPER" & _
          "VISOR_PHONE, isnull(SCHOOL_SUPERVISOR_EMAIL,'') as SCHOOL_SUPERVISOR_EMAIL" & vbCrLf & _
          "FROM STUDENT_ENROLMENT " & vbCrLf & _
          "",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (SELECT distinct SCHOOL_SUPERVISOR_NAME, isnull(SCHOOL_SUPERVISOR_PHO" & _
          "NE,'') as SCHOOL_SUPERVISOR_PHONE, isnull(SCHOOL_SUPERVISOR_EMAIL,'') as SCHOOL_SUPERVISOR" & _
          "_EMAIL" & vbCrLf & _
          "FROM STUDENT_ENROLMENT " & vbCrLf & _
          ") cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid SELECT_distinct_SCHOOL_SU Data Provider Class GetResultSet Method

'Grid SELECT_distinct_SCHOOL_SU Data Provider Class GetResultSet Method @2-BE815D40
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As SELECT_distinct_SCHOOL_SUItem()
'End Grid SELECT_distinct_SCHOOL_SU Data Provider Class GetResultSet Method

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

'Execute Select @2-BE51D4B1
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As SELECT_distinct_SCHOOL_SUItem
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

'After execute Select @2-18A87C17
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New SELECT_distinct_SCHOOL_SUItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-E14D0BDE
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as SELECT_distinct_SCHOOL_SUItem = New SELECT_distinct_SCHOOL_SUItem()
                item.SCHOOL_SUPERVISOR_NAME.SetValue(dr(i)("SCHOOL_SUPERVISOR_NAME"),"")
                item.SCHOOL_SUPERVISOR_PHONE.SetValue(dr(i)("SCHOOL_SUPERVISOR_PHONE"),"")
                item.SCHOOL_SUPERVISOR_EMAIL.SetValue(dr(i)("SCHOOL_SUPERVISOR_EMAIL"),"")
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

