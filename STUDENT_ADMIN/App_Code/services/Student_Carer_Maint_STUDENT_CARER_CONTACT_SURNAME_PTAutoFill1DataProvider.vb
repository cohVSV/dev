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

Namespace DECV_PROD2007.services.Student_Carer_Maint_STUDENT_CARER_CONTACT_SURNAME_PTAutoFill1 'Namespace @1-3CDD7F72

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

'Grid STUDENT_CARER_CONTACT1 Item Class @2-F1CDC056
Public Class STUDENT_CARER_CONTACT1Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public CARER_ID As FloatField
    Public TITLE As TextField
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public RELATIONSHIP As TextField
    Public HOME_PHONE As TextField
    Public WORK_PHONE As TextField
    Public MOBILE As TextField
    Public EMAIL As TextField
    Public Sub New()
    CARER_ID = New FloatField("", Nothing)
    TITLE = New TextField("", Nothing)
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    RELATIONSHIP = New TextField("", Nothing)
    HOME_PHONE = New TextField("", Nothing)
    WORK_PHONE = New TextField("", Nothing)
    MOBILE = New TextField("", Nothing)
    EMAIL = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "CARER_ID"
                    Return Me.CARER_ID
                Case "TITLE"
                    Return Me.TITLE
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "RELATIONSHIP"
                    Return Me.RELATIONSHIP
                Case "HOME_PHONE"
                    Return Me.HOME_PHONE
                Case "WORK_PHONE"
                    Return Me.WORK_PHONE
                Case "MOBILE"
                    Return Me.MOBILE
                Case "EMAIL"
                    Return Me.EMAIL
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "CARER_ID"
                    Me.CARER_ID = CType(Value,FloatField)
                Case "TITLE"
                    Me.TITLE = CType(Value,TextField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "RELATIONSHIP"
                    Me.RELATIONSHIP = CType(Value,TextField)
                Case "HOME_PHONE"
                    Me.HOME_PHONE = CType(Value,TextField)
                Case "WORK_PHONE"
                    Me.WORK_PHONE = CType(Value,TextField)
                Case "MOBILE"
                    Me.MOBILE = CType(Value,TextField)
                Case "EMAIL"
                    Me.EMAIL = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STUDENT_CARER_CONTACT1 Item Class

'Grid STUDENT_CARER_CONTACT1 Data Provider Class Header @2-6E6284C0
Public Class STUDENT_CARER_CONTACT1DataProvider
Inherits GridDataProviderBase
'End Grid STUDENT_CARER_CONTACT1 Data Provider Class Header

'Grid STUDENT_CARER_CONTACT1 Data Provider Class Variables @2-22320688

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
    Public Expr146  As TextParameter
    Public Urlkeyword  As TextParameter
'End Grid STUDENT_CARER_CONTACT1 Data Provider Class Variables

'Grid STUDENT_CARER_CONTACT1 Data Provider Class GetResultSet Method @2-A458E44D

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} CARER_ID, TITLE, SURNAME, FIRST_NAME, " & vbCrLf & _
          "RELATIONSHIP, HOME_PHONE, WORK_PHONE, MOBILE, " & vbCrLf & _
          "EMAIL " & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT {SQL_Where} {SQL_OrderBy}", New String(){"expr146","And","keyword156"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT", New String(){"expr146","And","keyword156"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid STUDENT_CARER_CONTACT1 Data Provider Class GetResultSet Method

'Grid STUDENT_CARER_CONTACT1 Data Provider Class GetResultSet Method @2-F66EA6DA
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STUDENT_CARER_CONTACT1Item()
'End Grid STUDENT_CARER_CONTACT1 Data Provider Class GetResultSet Method

'Before build Select @2-4F654F94
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("expr146",Expr146, "","RELATIONSHIP",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("keyword156",Urlkeyword, "","CARER_ID",Condition.Equal,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-D71C6FAD
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STUDENT_CARER_CONTACT1Item
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

'After execute Select @2-B169A5C1
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENT_CARER_CONTACT1Item(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-37257ED9
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_CARER_CONTACT1Item = New STUDENT_CARER_CONTACT1Item()
                item.CARER_ID.SetValue(dr(i)("CARER_ID"),"")
                item.TITLE.SetValue(dr(i)("TITLE"),"")
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.RELATIONSHIP.SetValue(dr(i)("RELATIONSHIP"),"")
                item.HOME_PHONE.SetValue(dr(i)("HOME_PHONE"),"")
                item.WORK_PHONE.SetValue(dr(i)("WORK_PHONE"),"")
                item.MOBILE.SetValue(dr(i)("MOBILE"),"")
                item.EMAIL.SetValue(dr(i)("EMAIL"),"")
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

