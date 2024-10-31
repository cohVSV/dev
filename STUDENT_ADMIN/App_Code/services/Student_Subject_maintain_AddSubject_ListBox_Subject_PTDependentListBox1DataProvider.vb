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

Namespace DECV_PROD2007.services.Student_Subject_maintain_AddSubject_ListBox_Subject_PTDependentListBox1 'Namespace @1-F16BE63B

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

'Grid SUBJECT Item Class @2-8C4C0A2E
Public Class SUBJECTItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public SUBJECT_ID As IntegerField
    Public subject_displaytext As TextField
    Public Sub New()
    SUBJECT_ID = New IntegerField("", Nothing)
    subject_displaytext = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "SUBJECT_ID"
                    Return Me.SUBJECT_ID
                Case "subject_displaytext"
                    Return Me.subject_displaytext
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SUBJECT_ID"
                    Me.SUBJECT_ID = CType(Value,IntegerField)
                Case "subject_displaytext"
                    Me.subject_displaytext = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid SUBJECT Item Class

'Grid SUBJECT Data Provider Class Header @2-0DD17C44
Public Class SUBJECTDataProvider
Inherits GridDataProviderBase
'End Grid SUBJECT Data Provider Class Header

'Grid SUBJECT Data Provider Class Variables @2-2DBABCDC

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {"SUBJECT_TITLE, YEAR_LEVEL"}
    Private SortFieldsNamesDesc As String() = New string() {"SUBJECT_TITLE, YEAR_LEVEL"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 0
    Public PageNumber As Integer = 1
    Public Urlkeyword  As IntegerParameter
'End Grid SUBJECT Data Provider Class Variables

'Grid SUBJECT Data Provider Class GetResultSet Method @2-8EC89BB5

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} SUBJECT_ID, " & vbCrLf & _
          "rtrim(SUBJECT_TITLE) + ' (' + rtrim(SUBJECT_ABBREV) + ')  (' + rtrim(SUBJECT_ID) +')' AS s" & _
          "ubject_displaytext, " & vbCrLf & _
          "YEAR_LEVEL " & vbCrLf & _
          "FROM SUBJECT {SQL_Where} {SQL_OrderBy}", New String(){"expr128","And","expr129","And","keyword131"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM SUBJECT", New String(){"expr128","And","expr129","And","keyword131"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid SUBJECT Data Provider Class GetResultSet Method

'Grid SUBJECT Data Provider Class GetResultSet Method @2-40D1E8E8
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As SUBJECTItem()
'End Grid SUBJECT Data Provider Class GetResultSet Method

'Before build Select @2-9793B2F4
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("keyword131",Urlkeyword, "","YEAR_LEVEL",Condition.Equal,False)
        Select_.Parameters.Add("expr128","(CAMPUS_CODE = 'D')")
        Select_.Parameters.Add("expr129","(STATUS = 1)")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-C3D26DF9
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As SUBJECTItem
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

'After execute Select @2-A15FCA2A
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New SUBJECTItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-4EA41BCC
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as SUBJECTItem = New SUBJECTItem()
                item.SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
                item.subject_displaytext.SetValue(dr(i)("subject_displaytext"),"")
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

