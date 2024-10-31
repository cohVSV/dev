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

Namespace DECV_PROD2007.ASSIGNMENT_list 'Namespace @1-F9F02EC8

'Page Data Class @1-1CA1EF9E
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public Sub New()
        Link1 = New TextField("",Nothing)
        Link1HrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Link1.SetValue(DBUtility.GetInitialValue("Link1"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Link1"
                    Return Link1
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link1"
                    Link1 = CType(value, TextField)
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

'Record ASSIGNMENTSearch Item Class @4-7AE91E10
Public Class ASSIGNMENTSearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_SUBJECT_ID As IntegerField
    Public Sub New()
    s_SUBJECT_ID = New IntegerField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As ASSIGNMENTSearchItem
        Dim item As ASSIGNMENTSearchItem = New ASSIGNMENTSearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("s_SUBJECT_ID")) Then
        item.s_SUBJECT_ID.SetValue(DBUtility.GetInitialValue("s_SUBJECT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_SUBJECT_ID"
                    Return s_SUBJECT_ID
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_SUBJECT_ID"
                    s_SUBJECT_ID = CType(value, IntegerField)
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

    Public Sub Validate(ByVal provider As ASSIGNMENTSearchDataProvider)
'End Record ASSIGNMENTSearch Item Class

'Record ASSIGNMENTSearch Item Class tail @4-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record ASSIGNMENTSearch Item Class tail

'Record ASSIGNMENTSearch Data Provider Class @4-33ABF586
Public Class ASSIGNMENTSearchDataProvider
Inherits RecordDataProviderBase
'End Record ASSIGNMENTSearch Data Provider Class

'Record ASSIGNMENTSearch Data Provider Class Variables @4-DC47B711
    Protected item As ASSIGNMENTSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record ASSIGNMENTSearch Data Provider Class Variables

'Record ASSIGNMENTSearch Data Provider Class GetResultSet Method @4-E0700EE0

    Public Sub FillItem(ByVal item As ASSIGNMENTSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record ASSIGNMENTSearch Data Provider Class GetResultSet Method

'Record ASSIGNMENTSearch BeforeBuildSelect @4-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record ASSIGNMENTSearch BeforeBuildSelect

'Record ASSIGNMENTSearch AfterExecuteSelect @4-79426A21
        End If
            IsInsertMode = True
'End Record ASSIGNMENTSearch AfterExecuteSelect

'Record ASSIGNMENTSearch AfterExecuteSelect tail @4-E31F8E2A
    End Sub
'End Record ASSIGNMENTSearch AfterExecuteSelect tail

'Record ASSIGNMENTSearch Data Provider Class @4-A61BA892
End Class

'End Record ASSIGNMENTSearch Data Provider Class

'Grid ASSIGNMENT Item Class @3-4A733476
Public Class ASSIGNMENTItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public ASSIGNMENT_TotalRecords As TextField
    Public lblSubjectID As TextField
    Public lblSubjectName As TextField
    Public ASSIGNMENT_ID As IntegerField
    Public ASSIGNMENT_IDHref As Object
    Public ASSIGNMENT_IDHrefParameters As LinkParameterCollection
    Public DESCRIPTION As TextField
    Public STATUS As BooleanField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public ARCHIVE As IntegerField
    Public Sub New()
    ASSIGNMENT_TotalRecords = New TextField("", Nothing)
    lblSubjectID = New TextField("", Nothing)
    lblSubjectName = New TextField("", Nothing)
    ASSIGNMENT_ID = New IntegerField("",Nothing)
    ASSIGNMENT_IDHrefParameters = New LinkParameterCollection()
    DESCRIPTION = New TextField("", Nothing)
    STATUS = New BooleanField(Settings.BoolFormat, Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    ARCHIVE = New IntegerField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "ASSIGNMENT_TotalRecords"
                    Return Me.ASSIGNMENT_TotalRecords
                Case "lblSubjectID"
                    Return Me.lblSubjectID
                Case "lblSubjectName"
                    Return Me.lblSubjectName
                Case "ASSIGNMENT_ID"
                    Return Me.ASSIGNMENT_ID
                Case "DESCRIPTION"
                    Return Me.DESCRIPTION
                Case "STATUS"
                    Return Me.STATUS
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "ARCHIVE"
                    Return Me.ARCHIVE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ASSIGNMENT_TotalRecords"
                    Me.ASSIGNMENT_TotalRecords = CType(Value,TextField)
                Case "lblSubjectID"
                    Me.lblSubjectID = CType(Value,TextField)
                Case "lblSubjectName"
                    Me.lblSubjectName = CType(Value,TextField)
                Case "ASSIGNMENT_ID"
                    Me.ASSIGNMENT_ID = CType(Value,IntegerField)
                Case "DESCRIPTION"
                    Me.DESCRIPTION = CType(Value,TextField)
                Case "STATUS"
                    Me.STATUS = CType(Value,BooleanField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "ARCHIVE"
                    Me.ARCHIVE = CType(Value,IntegerField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid ASSIGNMENT Item Class

'Grid ASSIGNMENT Data Provider Class Header @3-09B1602D
Public Class ASSIGNMENTDataProvider
Inherits GridDataProviderBase
'End Grid ASSIGNMENT Data Provider Class Header

'Grid ASSIGNMENT Data Provider Class Variables @3-A334FEEB

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {"ASSIGNMENT_ID"}
    Private SortFieldsNamesDesc As String() = New string() {"ASSIGNMENT_ID"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 80
    Public PageNumber As Integer = 1
    Public Urls_SUBJECT_ID  As IntegerParameter
'End Grid ASSIGNMENT Data Provider Class Variables

'Grid ASSIGNMENT Data Provider Class GetResultSet Method @3-1E972E03

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM ASSIGNMENT {SQL_Where} {SQL_OrderBy}", New String(){"s_SUBJECT_ID9"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM ASSIGNMENT", New String(){"s_SUBJECT_ID9"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid ASSIGNMENT Data Provider Class GetResultSet Method

'Grid ASSIGNMENT Data Provider Class GetResultSet Method @3-D50C3A10
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As ASSIGNMENTItem()
'End Grid ASSIGNMENT Data Provider Class GetResultSet Method

'Before build Select @3-B0FFCB7C
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_SUBJECT_ID9",Urls_SUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @3-E015FE08
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As ASSIGNMENTItem
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

'After execute Select @3-ED2AB6F0
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New ASSIGNMENTItem(dr.Count-1) {}
'End After execute Select

'After execute Select @3-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @3-390154A1
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as ASSIGNMENTItem = New ASSIGNMENTItem()
                item.ASSIGNMENT_ID.SetValue(dr(i)("ASSIGNMENT_ID"),"")
                item.ASSIGNMENT_IDHref = "ASSIGNMENT_maint.aspx"
                item.ASSIGNMENT_IDHrefParameters.Add("SUBJECT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("SUBJECT_ID").ToString()))
                item.ASSIGNMENT_IDHrefParameters.Add("ASSIGNMENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("ASSIGNMENT_ID").ToString()))
                item.DESCRIPTION.SetValue(dr(i)("DESCRIPTION"),"")
                item.STATUS.SetValue(dr(i)("STATUS"),Select_.BoolFormat)
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.ARCHIVE.SetValue(dr(i)("ARCHIVE"),"")
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

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

