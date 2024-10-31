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

Namespace DECV_PROD2007.popup_StudentSubjectSearch 'Namespace @1-FBBB71AD

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

'Record STUDENT_SUBJECT_SUBJECT Item Class @19-F6E2D8C4
Public Class STUDENT_SUBJECT_SUBJECTItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_STUDENT_ID As FloatField
    Public Sub New()
    s_STUDENT_ID = New FloatField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_SUBJECT_SUBJECTItem
        Dim item As STUDENT_SUBJECT_SUBJECTItem = New STUDENT_SUBJECT_SUBJECTItem()
        If Not IsNothing(DBUtility.GetInitialValue("s_STUDENT_ID")) Then
        item.s_STUDENT_ID.SetValue(DBUtility.GetInitialValue("s_STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_STUDENT_ID"
                    Return s_STUDENT_ID
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_STUDENT_ID"
                    s_STUDENT_ID = CType(value, FloatField)
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

    Public Sub Validate(ByVal provider As STUDENT_SUBJECT_SUBJECTDataProvider)
'End Record STUDENT_SUBJECT_SUBJECT Item Class

'Record STUDENT_SUBJECT_SUBJECT Item Class tail @19-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_SUBJECT_SUBJECT Item Class tail

'Record STUDENT_SUBJECT_SUBJECT Data Provider Class @19-FF378C0D
Public Class STUDENT_SUBJECT_SUBJECTDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_SUBJECT_SUBJECT Data Provider Class

'Record STUDENT_SUBJECT_SUBJECT Data Provider Class Variables @19-2C17B0BF
    Protected item As STUDENT_SUBJECT_SUBJECTItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_SUBJECT_SUBJECT Data Provider Class Variables

'Record STUDENT_SUBJECT_SUBJECT Data Provider Class GetResultSet Method @19-274B138D

    Public Sub FillItem(ByVal item As STUDENT_SUBJECT_SUBJECTItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record STUDENT_SUBJECT_SUBJECT Data Provider Class GetResultSet Method

'Record STUDENT_SUBJECT_SUBJECT BeforeBuildSelect @19-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_SUBJECT_SUBJECT BeforeBuildSelect

'Record STUDENT_SUBJECT_SUBJECT AfterExecuteSelect @19-79426A21
        End If
            IsInsertMode = True
'End Record STUDENT_SUBJECT_SUBJECT AfterExecuteSelect

'Record STUDENT_SUBJECT_SUBJECT AfterExecuteSelect tail @19-E31F8E2A
    End Sub
'End Record STUDENT_SUBJECT_SUBJECT AfterExecuteSelect tail

'Record STUDENT_SUBJECT_SUBJECT Data Provider Class @19-A61BA892
End Class

'End Record STUDENT_SUBJECT_SUBJECT Data Provider Class

'Grid STUDENT_SUBJECT_SUBJECT1 Item Class @2-B5BB0C1C
Public Class STUDENT_SUBJECT_SUBJECT1Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STUDENT_SUBJECT_SUBJECT_ID As IntegerField
    Public STUDENT_SUBJECT_SUBJECT_IDHref As Object
    Public STUDENT_SUBJECT_SUBJECT_IDHrefParameters As LinkParameterCollection
    Public SUBJECT_ABBREV As TextField
    Public SUBJECT_TITLE As TextField
    Public SEMESTER As TextField
    Public YEAR_LEVEL As IntegerField
    Public SUBJ_ENROL_STATUS As TextField
    Public STAFF_ID As TextField
    Public ENROLMENT_DATE As DateField
    Public WITHDRAWAL_DATE As DateField
    Public ENROLMENT_YEAR As FloatField
    Public Sub New()
    STUDENT_SUBJECT_SUBJECT_ID = New IntegerField("",Nothing)
    STUDENT_SUBJECT_SUBJECT_IDHrefParameters = New LinkParameterCollection()
    SUBJECT_ABBREV = New TextField("", Nothing)
    SUBJECT_TITLE = New TextField("", Nothing)
    SEMESTER = New TextField("", Nothing)
    YEAR_LEVEL = New IntegerField("", Nothing)
    SUBJ_ENROL_STATUS = New TextField("", Nothing)
    STAFF_ID = New TextField("", Nothing)
    ENROLMENT_DATE = New DateField(Settings.DateFormat, Nothing)
    WITHDRAWAL_DATE = New DateField(Settings.DateFormat, Nothing)
    ENROLMENT_YEAR = New FloatField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STUDENT_SUBJECT_SUBJECT_ID"
                    Return Me.STUDENT_SUBJECT_SUBJECT_ID
                Case "SUBJECT_ABBREV"
                    Return Me.SUBJECT_ABBREV
                Case "SUBJECT_TITLE"
                    Return Me.SUBJECT_TITLE
                Case "SEMESTER"
                    Return Me.SEMESTER
                Case "YEAR_LEVEL"
                    Return Me.YEAR_LEVEL
                Case "SUBJ_ENROL_STATUS"
                    Return Me.SUBJ_ENROL_STATUS
                Case "STAFF_ID"
                    Return Me.STAFF_ID
                Case "ENROLMENT_DATE"
                    Return Me.ENROLMENT_DATE
                Case "WITHDRAWAL_DATE"
                    Return Me.WITHDRAWAL_DATE
                Case "ENROLMENT_YEAR"
                    Return Me.ENROLMENT_YEAR
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_SUBJECT_SUBJECT_ID"
                    Me.STUDENT_SUBJECT_SUBJECT_ID = CType(Value,IntegerField)
                Case "SUBJECT_ABBREV"
                    Me.SUBJECT_ABBREV = CType(Value,TextField)
                Case "SUBJECT_TITLE"
                    Me.SUBJECT_TITLE = CType(Value,TextField)
                Case "SEMESTER"
                    Me.SEMESTER = CType(Value,TextField)
                Case "YEAR_LEVEL"
                    Me.YEAR_LEVEL = CType(Value,IntegerField)
                Case "SUBJ_ENROL_STATUS"
                    Me.SUBJ_ENROL_STATUS = CType(Value,TextField)
                Case "STAFF_ID"
                    Me.STAFF_ID = CType(Value,TextField)
                Case "ENROLMENT_DATE"
                    Me.ENROLMENT_DATE = CType(Value,DateField)
                Case "WITHDRAWAL_DATE"
                    Me.WITHDRAWAL_DATE = CType(Value,DateField)
                Case "ENROLMENT_YEAR"
                    Me.ENROLMENT_YEAR = CType(Value,FloatField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STUDENT_SUBJECT_SUBJECT1 Item Class

'Grid STUDENT_SUBJECT_SUBJECT1 Data Provider Class Header @2-C74D1B6F
Public Class STUDENT_SUBJECT_SUBJECT1DataProvider
Inherits GridDataProviderBase
'End Grid STUDENT_SUBJECT_SUBJECT1 Data Provider Class Header

'Grid STUDENT_SUBJECT_SUBJECT1 Data Provider Class Variables @2-BC67BB6C

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_SUBJECT_SUBJECT_ID
        Sorter_SUBJECT_ABBREV
        Sorter_SUBJECT_TITLE
        Sorter_SEMESTER
        Sorter_YEAR_LEVEL
        Sorter_SUBJ_ENROL_STATUS
        Sorter_STAFF_ID
        Sorter_ENROLMENT_DATE
        Sorter_WITHDRAWAL_DATE
        Sorter_ENROLMENT_YEAR
    End Enum

    Private SortFieldsNames As String() = New String() {"STUDENT_SUBJECT.SUBJECT_ID","STUDENT_SUBJECT.SUBJECT_ID","SUBJECT_ABBREV","SUBJECT_TITLE","SEMESTER","YEAR_LEVEL","SUBJ_ENROL_STATUS","STAFF_ID","ENROLMENT_DATE","WITHDRAWAL_DATE","ENROLMENT_YEAR"}
    Private SortFieldsNamesDesc As String() = New string() {"STUDENT_SUBJECT.SUBJECT_ID","STUDENT_SUBJECT.SUBJECT_ID DESC","SUBJECT_ABBREV DESC","SUBJECT_TITLE DESC","SEMESTER DESC","YEAR_LEVEL DESC","SUBJ_ENROL_STATUS DESC","STAFF_ID DESC","ENROLMENT_DATE DESC","WITHDRAWAL_DATE DESC","ENROLMENT_YEAR DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 80
    Public PageNumber As Integer = 1
    Public Urls_STUDENT_ID  As FloatParameter
'End Grid STUDENT_SUBJECT_SUBJECT1 Data Provider Class Variables

'Grid STUDENT_SUBJECT_SUBJECT1 Data Provider Class GetResultSet Method @2-990E6842

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} STUDENT_ID, ENROLMENT_YEAR, " & vbCrLf & _
          "STUDENT_SUBJECT.SUBJECT_ID AS STUDENT_SUBJECT_SUBJECT_ID, STAFF_ID, SEMESTER, ENROLMENT_DA" & _
          "TE, " & vbCrLf & _
          "WITHDRAWAL_DATE," & vbCrLf & _
          "SUBJ_ENROL_STATUS, SUBJECT_ABBREV, SUBJECT_TITLE, " & vbCrLf & _
          "YEAR_LEVEL " & vbCrLf & _
          "FROM STUDENT_SUBJECT INNER JOIN SUBJECT ON" & vbCrLf & _
          "STUDENT_SUBJECT.SUBJECT_ID = SUBJECT.SUBJECT_ID {SQL_Where} {SQL_OrderBy}", New String(){"expr6","And","s_STUDENT_ID22"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STUDENT_SUBJECT INNER JOIN SUBJECT ON" & vbCrLf & _
          "STUDENT_SUBJECT.SUBJECT_ID = SUBJECT.SUBJECT_ID", New String(){"expr6","And","s_STUDENT_ID22"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid STUDENT_SUBJECT_SUBJECT1 Data Provider Class GetResultSet Method

'Grid STUDENT_SUBJECT_SUBJECT1 Data Provider Class GetResultSet Method @2-BF55F532
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STUDENT_SUBJECT_SUBJECT1Item()
'End Grid STUDENT_SUBJECT_SUBJECT1 Data Provider Class GetResultSet Method

'Before build Select @2-0156CD57
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_STUDENT_ID22",Urls_STUDENT_ID, "","STUDENT_SUBJECT.STUDENT_ID",Condition.Equal,False)
        Select_.Parameters.Add("expr6","(ENROLMENT_YEAR = year(getdate()))")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-C16F2798
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STUDENT_SUBJECT_SUBJECT1Item
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

'After execute Select @2-380982DC
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENT_SUBJECT_SUBJECT1Item(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-D101A2D0
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_SUBJECT_SUBJECT1Item = New STUDENT_SUBJECT_SUBJECT1Item()
                item.STUDENT_SUBJECT_SUBJECT_ID.SetValue(dr(i)("STUDENT_SUBJECT_SUBJECT_ID"),"")
                item.STUDENT_SUBJECT_SUBJECT_IDHref = ""
                item.SUBJECT_ABBREV.SetValue(dr(i)("SUBJECT_ABBREV"),"")
                item.SUBJECT_TITLE.SetValue(dr(i)("SUBJECT_TITLE"),"")
                item.SEMESTER.SetValue(dr(i)("SEMESTER"),"")
                item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
                item.SUBJ_ENROL_STATUS.SetValue(dr(i)("SUBJ_ENROL_STATUS"),"")
                item.STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
                item.ENROLMENT_DATE.SetValue(dr(i)("ENROLMENT_DATE"),Select_.DateFormat)
                item.WITHDRAWAL_DATE.SetValue(dr(i)("WITHDRAWAL_DATE"),Select_.DateFormat)
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

'Grid Data Provider tail @2-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

