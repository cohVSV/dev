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

Namespace DECV_PROD2007.services.StudentEnrolment_AddNewYear_STUDENT_inputREgionID_PTAutoFill1 'Namespace @1-73A4F02C

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

'Grid tblRegionEnrolments Item Class @2-BD6AEF80
Public Class tblRegionEnrolmentsItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public id As IntegerField
    Public FirstName As TextField
    Public Surname As TextField
    Public DateBirth As DateField
    Public Sex As TextField
    Public YearLevel As TextField
    Public lookupid As TextField
    Public EnrolNotes As TextField
    Public EnrolCategory As TextField
    Public ApprovalPeriod As TextField
    Public SchoolID As TextField
    Public Sub New()
    id = New IntegerField("", Nothing)
    FirstName = New TextField("", Nothing)
    Surname = New TextField("", Nothing)
    DateBirth = New DateField(Settings.DateFormat, Nothing)
    Sex = New TextField("", Nothing)
    YearLevel = New TextField("", Nothing)
    lookupid = New TextField("", Nothing)
    EnrolNotes = New TextField("", Nothing)
    EnrolCategory = New TextField("", Nothing)
    ApprovalPeriod = New TextField("", Nothing)
    SchoolID = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "id"
                    Return Me.id
                Case "FirstName"
                    Return Me.FirstName
                Case "Surname"
                    Return Me.Surname
                Case "DateBirth"
                    Return Me.DateBirth
                Case "Sex"
                    Return Me.Sex
                Case "YearLevel"
                    Return Me.YearLevel
                Case "lookupid"
                    Return Me.lookupid
                Case "EnrolNotes"
                    Return Me.EnrolNotes
                Case "EnrolCategory"
                    Return Me.EnrolCategory
                Case "ApprovalPeriod"
                    Return Me.ApprovalPeriod
                Case "SchoolID"
                    Return Me.SchoolID
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "id"
                    Me.id = CType(Value,IntegerField)
                Case "FirstName"
                    Me.FirstName = CType(Value,TextField)
                Case "Surname"
                    Me.Surname = CType(Value,TextField)
                Case "DateBirth"
                    Me.DateBirth = CType(Value,DateField)
                Case "Sex"
                    Me.Sex = CType(Value,TextField)
                Case "YearLevel"
                    Me.YearLevel = CType(Value,TextField)
                Case "lookupid"
                    Me.lookupid = CType(Value,TextField)
                Case "EnrolNotes"
                    Me.EnrolNotes = CType(Value,TextField)
                Case "EnrolCategory"
                    Me.EnrolCategory = CType(Value,TextField)
                Case "ApprovalPeriod"
                    Me.ApprovalPeriod = CType(Value,TextField)
                Case "SchoolID"
                    Me.SchoolID = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid tblRegionEnrolments Item Class

'Grid tblRegionEnrolments Data Provider Class Header @2-2F4899C8
Public Class tblRegionEnrolmentsDataProvider
Inherits GridDataProviderBase
'End Grid tblRegionEnrolments Data Provider Class Header

'Grid tblRegionEnrolments Data Provider Class Variables @2-8289BC84

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
    Public Urlkeyword  As IntegerParameter
'End Grid tblRegionEnrolments Data Provider Class Variables

'Grid tblRegionEnrolments Data Provider Class GetResultSet Method @2-D63EE5D7

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} lookupid, ApprovalPeriod, SchoolID, EnrolCategory, " & vbCrLf & _
          "YearLevel, Sex, DateBirth, Surname, FirstName, id, " & vbCrLf & _
          "Notes " & vbCrLf & _
          "FROM tblRegionEnrolments {SQL_Where} {SQL_OrderBy}", New String(){"keyword139"},Settings.connDECVPROD_RegionEnrolmentsDataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM tblRegionEnrolments", New String(){"keyword139"},Settings.connDECVPROD_RegionEnrolmentsDataAccessObject , true)
    End Sub
'End Grid tblRegionEnrolments Data Provider Class GetResultSet Method

'Grid tblRegionEnrolments Data Provider Class GetResultSet Method @2-39974223
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As tblRegionEnrolmentsItem()
'End Grid tblRegionEnrolments Data Provider Class GetResultSet Method

'Before build Select @2-F0EBF280
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("keyword139",Urlkeyword, "","id",Condition.Equal,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-F8183A59
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As tblRegionEnrolmentsItem
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

'After execute Select @2-EE7654ED
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New tblRegionEnrolmentsItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-CD01BA5A
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as tblRegionEnrolmentsItem = New tblRegionEnrolmentsItem()
                item.id.SetValue(dr(i)("id"),"")
                item.FirstName.SetValue(dr(i)("FirstName"),"")
                item.Surname.SetValue(dr(i)("Surname"),"")
                item.DateBirth.SetValue(dr(i)("DateBirth"),Select_.DateFormat)
                item.Sex.SetValue(dr(i)("Sex"),"")
                item.YearLevel.SetValue(dr(i)("YearLevel"),"")
                item.lookupid.SetValue(dr(i)("lookupid"),"")
                item.EnrolNotes.SetValue(dr(i)("Notes"),"")
                item.EnrolCategory.SetValue(dr(i)("EnrolCategory"),"")
                item.ApprovalPeriod.SetValue(dr(i)("ApprovalPeriod"),"")
                item.SchoolID.SetValue(dr(i)("SchoolID"),"")
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

