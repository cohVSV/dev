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

Namespace DECV_PROD2007.services.getStudentQuickContactDetails 'Namespace @1-FF31C0B8

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

'Grid sps_StudentQuickContactLo Item Class @2-AB8620D3
Public Class sps_StudentQuickContactLoItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public student_id As FloatField
    Public StudentName1 As TextField
    Public Sub New()
    student_id = New FloatField("", Nothing)
    StudentName1 = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "student_id"
                    Return Me.student_id
                Case "StudentName1"
                    Return Me.StudentName1
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "student_id"
                    Me.student_id = CType(Value,FloatField)
                Case "StudentName1"
                    Me.StudentName1 = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid sps_StudentQuickContactLo Item Class

'Grid sps_StudentQuickContactLo Data Provider Class Header @2-A003B6A9
Public Class sps_StudentQuickContactLoDataProvider
Inherits GridDataProviderBase
'End Grid sps_StudentQuickContactLo Data Provider Class Header

'Grid sps_StudentQuickContactLo Data Provider Class Variables @2-4B4D4DBD

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
    Public UrlRETURN_VALUE  As IntegerParameter
    Public Urlterm  As TextParameter
    Public Urlstaffid  As TextParameter
'End Grid sps_StudentQuickContactLo Data Provider Class Variables

'Grid sps_StudentQuickContactLo Data Provider Class GetResultSet Method @2-58187640

    Public Sub New()
        Select_=new SpCommand("sps_StudentQuickContactLookup;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SpCommand("",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid sps_StudentQuickContactLo Data Provider Class GetResultSet Method

'Grid sps_StudentQuickContactLo Data Provider Class GetResultSet Method @2-B291802C
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As sps_StudentQuickContactLoItem()
'End Grid sps_StudentQuickContactLo Data Provider Class GetResultSet Method

'Before build Select @2-30B42CFC
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SpCommand).AddParameter("@RETURN_VALUE",UrlRETURN_VALUE,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Select_,SpCommand).AddParameter("@term",Urlterm,ParameterType._VarChar,ParameterDirection.Input,20,0,10)
        CType(Select_,SpCommand).AddParameter("@staffid",Urlstaffid,ParameterType._VarChar,ParameterDirection.Input,10,0,10)
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-F35106F1
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As sps_StudentQuickContactLoItem
        If ops.AllowRead Then
            Try
                If RecordsPerPage > 0 Then
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage + 1)
                    If ds.Tables(tableIndex).Rows.Count > RecordsPerPage Then
                        _PagesCount = PageNumber + 1
                        ds.Tables(tableIndex).Rows.RemoveAt(ds.Tables(tableIndex).Rows.Count - 1)
                    Else
                        _PagesCount = PageNumber
                    End If
                    If ds.Tables(tableIndex).Rows.Count = 0 Then _pagesCount = 0
                    m_recordCount = -1
                Else
                    ds=ExecuteSelect()
                    If ds.Tables(tableIndex).Rows.Count<>0 Then 
                        _PagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                    End If
                End If
                UrlRETURN_VALUE = IntegerParameter.GetParam(CType(Select_.Parameters("@RETURN_VALUE"),IDataParameter).Value)
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @2-30A18ADE
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New sps_StudentQuickContactLoItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-666F937F
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as sps_StudentQuickContactLoItem = New sps_StudentQuickContactLoItem()
                item.student_id.SetValue(dr(i)("student_id"),"")
                item.StudentName1.SetValue(dr(i)("StudentName"),"")
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

