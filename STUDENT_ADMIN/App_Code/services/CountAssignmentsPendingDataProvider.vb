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

Namespace DECV_PROD2007.services.CountAssignmentsPending 'Namespace @1-9DA69843

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

'Grid ASSIGNMENT_SUBMISSION Item Class @2-09077B67
Public Class ASSIGNMENT_SUBMISSIONItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STUDENT_ID As FloatField
    Public ENROLMENT_YEAR As FloatField
    Public SUBJECT_ID As IntegerField
    Public ASSIGNMENT_ID As IntegerField
    Public SUBMISSION_ID As IntegerField
    Public RECEIVED_DATE As DateField
    Public RETURNED_DATE As DateField
    Public STAFF_ID As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    STUDENT_ID = New FloatField("", Nothing)
    ENROLMENT_YEAR = New FloatField("", Nothing)
    SUBJECT_ID = New IntegerField("", Nothing)
    ASSIGNMENT_ID = New IntegerField("", Nothing)
    SUBMISSION_ID = New IntegerField("", Nothing)
    RECEIVED_DATE = New DateField(Settings.DateFormat, Nothing)
    RETURNED_DATE = New DateField(Settings.DateFormat, Nothing)
    STAFF_ID = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "ENROLMENT_YEAR"
                    Return Me.ENROLMENT_YEAR
                Case "SUBJECT_ID"
                    Return Me.SUBJECT_ID
                Case "ASSIGNMENT_ID"
                    Return Me.ASSIGNMENT_ID
                Case "SUBMISSION_ID"
                    Return Me.SUBMISSION_ID
                Case "RECEIVED_DATE"
                    Return Me.RECEIVED_DATE
                Case "RETURNED_DATE"
                    Return Me.RETURNED_DATE
                Case "STAFF_ID"
                    Return Me.STAFF_ID
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
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "ENROLMENT_YEAR"
                    Me.ENROLMENT_YEAR = CType(Value,FloatField)
                Case "SUBJECT_ID"
                    Me.SUBJECT_ID = CType(Value,IntegerField)
                Case "ASSIGNMENT_ID"
                    Me.ASSIGNMENT_ID = CType(Value,IntegerField)
                Case "SUBMISSION_ID"
                    Me.SUBMISSION_ID = CType(Value,IntegerField)
                Case "RECEIVED_DATE"
                    Me.RECEIVED_DATE = CType(Value,DateField)
                Case "RETURNED_DATE"
                    Me.RETURNED_DATE = CType(Value,DateField)
                Case "STAFF_ID"
                    Me.STAFF_ID = CType(Value,TextField)
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
'End Grid ASSIGNMENT_SUBMISSION Item Class

'Grid ASSIGNMENT_SUBMISSION Data Provider Class Header @2-F409A5E4
Public Class ASSIGNMENT_SUBMISSIONDataProvider
Inherits GridDataProviderBase
'End Grid ASSIGNMENT_SUBMISSION Data Provider Class Header

'Grid ASSIGNMENT_SUBMISSION Data Provider Class Variables @2-62AD82A7

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 50
    Public PageNumber As Integer = 1
    Public UrlSUBJECT_ID  As IntegerParameter
    Public UrlSTAFF_ID  As TextParameter
'End Grid ASSIGNMENT_SUBMISSION Data Provider Class Variables

'Grid ASSIGNMENT_SUBMISSION Data Provider Class GetResultSet Method @2-682A1F0F

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM ASSIGNMENT_SUBMISSION {SQL_Where} {SQL_OrderBy}", New String(){"expr285","And","SUBJECT_ID286","And","STAFF_ID297"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM ASSIGNMENT_SUBMISSION", New String(){"expr285","And","SUBJECT_ID286","And","STAFF_ID297"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid ASSIGNMENT_SUBMISSION Data Provider Class GetResultSet Method

'Grid ASSIGNMENT_SUBMISSION Data Provider Class GetResultSet Method @2-76C9B005
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As ASSIGNMENT_SUBMISSIONItem()
'End Grid ASSIGNMENT_SUBMISSION Data Provider Class GetResultSet Method

'Before build Select @2-C84AF717
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("SUBJECT_ID286",UrlSUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("STAFF_ID297",UrlSTAFF_ID, "","STAFF_ID",Condition.Equal,False)
        Select_.Parameters.Add("expr285","(ENROLMENT_YEAR=Year(getdate())-1)")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-31819A28
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As ASSIGNMENT_SUBMISSIONItem
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

'After execute Select @2-81C0F9BE
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New ASSIGNMENT_SUBMISSIONItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-8EA7B75E
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as ASSIGNMENT_SUBMISSIONItem = New ASSIGNMENT_SUBMISSIONItem()
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.ENROLMENT_YEAR.SetValue(dr(i)("ENROLMENT_YEAR"),"")
                item.SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
                item.ASSIGNMENT_ID.SetValue(dr(i)("ASSIGNMENT_ID"),"")
                item.SUBMISSION_ID.SetValue(dr(i)("SUBMISSION_ID"),"")
                item.RECEIVED_DATE.SetValue(dr(i)("RECEIVED_DATE"),Select_.DateFormat)
                item.RETURNED_DATE.SetValue(dr(i)("RETURNED_DATE"),Select_.DateFormat)
                item.STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
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

'Grid Data Provider tail @2-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

