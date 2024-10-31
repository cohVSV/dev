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

Namespace DECV_PROD2007.StudentAmendments_Results 'Namespace @1-AB35CC4E

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

'Record UpdateForm Item Class @57-E860863A
Public Class UpdateFormItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public lblStudentID As TextField
    Public lblEnrolmentYear As TextField
    Public lblRowsPerPage As TextField
    Public lblYearLevel As TextField
    Public listTeacher As TextField
    Public listTeacherItems As ItemCollection
    Public lblSelections As TextField
    Public Sub New()
    lblStudentID = New TextField("", Nothing)
    lblEnrolmentYear = New TextField("", Nothing)
    lblRowsPerPage = New TextField("", Nothing)
    lblYearLevel = New TextField("", Nothing)
    listTeacher = New TextField("", Nothing)
    listTeacherItems = New ItemCollection()
    lblSelections = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As UpdateFormItem
        Dim item As UpdateFormItem = New UpdateFormItem()
        If Not IsNothing(DBUtility.GetInitialValue("lblStudentID")) Then
        item.lblStudentID.SetValue(DBUtility.GetInitialValue("lblStudentID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblEnrolmentYear")) Then
        item.lblEnrolmentYear.SetValue(DBUtility.GetInitialValue("lblEnrolmentYear"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblRowsPerPage")) Then
        item.lblRowsPerPage.SetValue(DBUtility.GetInitialValue("lblRowsPerPage"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblYearLevel")) Then
        item.lblYearLevel.SetValue(DBUtility.GetInitialValue("lblYearLevel"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("listTeacher")) Then
        item.listTeacher.SetValue(DBUtility.GetInitialValue("listTeacher"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("button_DoTeacher")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblSelections")) Then
        item.lblSelections.SetValue(DBUtility.GetInitialValue("lblSelections"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "lblStudentID"
                    Return lblStudentID
                Case "lblEnrolmentYear"
                    Return lblEnrolmentYear
                Case "lblRowsPerPage"
                    Return lblRowsPerPage
                Case "lblYearLevel"
                    Return lblYearLevel
                Case "listTeacher"
                    Return listTeacher
                Case "lblSelections"
                    Return lblSelections
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblStudentID"
                    lblStudentID = CType(value, TextField)
                Case "lblEnrolmentYear"
                    lblEnrolmentYear = CType(value, TextField)
                Case "lblRowsPerPage"
                    lblRowsPerPage = CType(value, TextField)
                Case "lblYearLevel"
                    lblYearLevel = CType(value, TextField)
                Case "listTeacher"
                    listTeacher = CType(value, TextField)
                Case "lblSelections"
                    lblSelections = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As UpdateFormDataProvider)
'End Record UpdateForm Item Class

'Record UpdateForm Item Class tail @57-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record UpdateForm Item Class tail

'Record UpdateForm Data Provider Class @57-4ED18962
Public Class UpdateFormDataProvider
Inherits RecordDataProviderBase
'End Record UpdateForm Data Provider Class

'Record UpdateForm Data Provider Class Variables @57-B97FE7C3
    Protected listTeacherDataCommand As DataCommand=new TableCommand("SELECT staff_ID, " & vbCrLf & _
          "staffname " & vbCrLf & _
          "FROM View_StaffList_Active_Inactive {SQL_Where} {SQL_OrderBy}", New String(){"expr86","And","expr87"},Settings.connDECVPRODSQL2005DataAccessObject )
    Public Urls_SUBJECT_ID As IntegerParameter
    Protected item As UpdateFormItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record UpdateForm Data Provider Class Variables

'Record UpdateForm Data Provider Class GetResultSet Method @57-9C02F596

    Public Sub FillItem(ByVal item As UpdateFormItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record UpdateForm Data Provider Class GetResultSet Method

'Record UpdateForm BeforeBuildSelect @57-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record UpdateForm BeforeBuildSelect

'Record UpdateForm AfterExecuteSelect @57-83591636
        End If
            IsInsertMode = True
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record UpdateForm AfterExecuteSelect

'ListBox listTeacher Initialize Data Source @58-9BF7BE08
        listTeacherDataCommand.Dao._optimized = False
        Dim listTeachertableIndex As Integer = 0
        listTeacherDataCommand.OrderBy = "STAFF_ID"
        listTeacherDataCommand.Parameters.Clear()
        listTeacherDataCommand.Parameters.Add("expr86","(TEACHER_FLAG=1)")
        listTeacherDataCommand.Parameters.Add("expr87","(STATUS=1)")
'End ListBox listTeacher Initialize Data Source

'ListBox listTeacher BeforeExecuteSelect @58-07CC3333
        Try
            ListBoxSource=listTeacherDataCommand.Execute().Tables(listTeachertableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox listTeacher BeforeExecuteSelect

'ListBox listTeacher AfterExecuteSelect @58-904E3068
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("staff_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("staffname")
            item.listTeacherItems.Add(Key, Val)
        Next
'End ListBox listTeacher AfterExecuteSelect

'Record UpdateForm AfterExecuteSelect tail @57-E31F8E2A
    End Sub
'End Record UpdateForm AfterExecuteSelect tail

'Record UpdateForm Data Provider Class @57-A61BA892
End Class

'End Record UpdateForm Data Provider Class

'Grid GridStudentList Item Class @2-EBAB6BAB
Public Class GridStudentListItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STUD_SUB_INTERIM_STUD_SUB_TotalRecords As TextField
    Public cbox As BooleanField
    Public cboxCheckedValue As BooleanField
    Public cboxUncheckedValue As BooleanField
    Public STUDENT_ID As TextField
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public YEAR_LEVEL As TextField
    Public SUBJ_ENROL_STATUS As TextField
    Public STAFF_ID As TextField
    Public Sub New()
    STUD_SUB_INTERIM_STUD_SUB_TotalRecords = New TextField("", Nothing)
    cbox = New BooleanField(Settings.BoolFormat, false)
    cboxCheckedValue = New BooleanField(Settings.BoolFormat, true)
    cboxUncheckedValue = New BooleanField(Settings.BoolFormat, false)
    STUDENT_ID = New TextField("", Nothing)
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    YEAR_LEVEL = New TextField("", Nothing)
    SUBJ_ENROL_STATUS = New TextField("", Nothing)
    STAFF_ID = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STUD_SUB_INTERIM_STUD_SUB_TotalRecords"
                    Return Me.STUD_SUB_INTERIM_STUD_SUB_TotalRecords
                Case "cbox"
                    Return Me.cbox
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "YEAR_LEVEL"
                    Return Me.YEAR_LEVEL
                Case "SUBJ_ENROL_STATUS"
                    Return Me.SUBJ_ENROL_STATUS
                Case "STAFF_ID"
                    Return Me.STAFF_ID
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUD_SUB_INTERIM_STUD_SUB_TotalRecords"
                    Me.STUD_SUB_INTERIM_STUD_SUB_TotalRecords = CType(Value,TextField)
                Case "cbox"
                    Me.cbox = CType(Value,BooleanField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,TextField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "YEAR_LEVEL"
                    Me.YEAR_LEVEL = CType(Value,TextField)
                Case "SUBJ_ENROL_STATUS"
                    Me.SUBJ_ENROL_STATUS = CType(Value,TextField)
                Case "STAFF_ID"
                    Me.STAFF_ID = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid GridStudentList Item Class

'Grid GridStudentList Data Provider Class Header @2-D50EDC61
Public Class GridStudentListDataProvider
Inherits GridDataProviderBase
'End Grid GridStudentList Data Provider Class Header

'Grid GridStudentList Data Provider Class Variables @2-3F68C616

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_ID
        Sorter_SURNAME
        Sorter_FIRST_NAME
        Sorter_YEAR_LEVEL
        Sorter_SUBJ_ENROL_STATUS
        Sorter_STAFF_ID
    End Enum

    Private SortFieldsNames As String() = New String() {"a.STUDENT_ID","STUDENT_ID","SURNAME","FIRST_NAME","YEAR_LEVEL","ENROLMENT_STATUS","PASTORAL_CARE_ID"}
    Private SortFieldsNamesDesc As String() = New string() {"a.STUDENT_ID","STUDENT_ID DESC","SURNAME DESC","FIRST_NAME DESC","YEAR_LEVEL DESC","ENROLMENT_STATUS DESC","PASTORAL_CARE_ID DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 80
    Public PageNumber As Integer = 1
    Public Urls_STUDENT_ID_lowest  As IntegerParameter
    Public Urls_ENROLMENT_YEAR  As FloatParameter
    Public Urls_ENROL_STATUS  As TextParameter
    Public Urls_YEAR_LEVEL  As TextParameter
'End Grid GridStudentList Data Provider Class Variables

'Grid GridStudentList Data Provider Class GetResultSet Method @2-74503648

    Public Sub New()
        Select_=new SqlCommand("select TOP {SqlParam_endRecord} a.STUDENT_ID,b.SURNAME,b.FIRST_NAME,a.CAMPUS,a.YEAR_LEVEL," & _
          "a.ENROLMENT_STATUS,a.PASTORAL_CARE_ID " & vbCrLf & _
          "from STUDENT_ENROLMENT a, STUDENT b " & vbCrLf & _
          "where a.STUDENT_ID=b.STUDENT_ID " & vbCrLf & _
          "and a.STUDENT_ID>={s_STUDENT_ID}" & vbCrLf & _
          "and a.ENROLMENT_YEAR ={s_ENROLMENT_YEAR}" & vbCrLf & _
          "and a.YEAR_LEVEL = (case when ({s_YEAR_LEVEL}=99) then a.YEAR_LEVEL else {s_YEAR_LEVEL} en" & _
          "d ) " & vbCrLf & _
          "and a.ENROLMENT_STATUS like '{s_ENROL_STATUS}'" & vbCrLf & _
          "and a.CAMPUS = 'D' {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (select a.STUDENT_ID,b.SURNAME,b.FIRST_NAME,a.CAMPUS,a.YEAR_LEVEL,a.E" & _
          "NROLMENT_STATUS,a.PASTORAL_CARE_ID " & vbCrLf & _
          "from STUDENT_ENROLMENT a, STUDENT b " & vbCrLf & _
          "where a.STUDENT_ID=b.STUDENT_ID " & vbCrLf & _
          "and a.STUDENT_ID>={s_STUDENT_ID}" & vbCrLf & _
          "and a.ENROLMENT_YEAR ={s_ENROLMENT_YEAR}" & vbCrLf & _
          "and a.YEAR_LEVEL = (case when ({s_YEAR_LEVEL}=99) then a.YEAR_LEVEL else {s_YEAR_LEVEL} en" & _
          "d ) " & vbCrLf & _
          "and a.ENROLMENT_STATUS like '{s_ENROL_STATUS}'" & vbCrLf & _
          "and a.CAMPUS = 'D') cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid GridStudentList Data Provider Class GetResultSet Method

'Grid GridStudentList Data Provider Class GetResultSet Method @2-9F93D720
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As GridStudentListItem()
'End Grid GridStudentList Data Provider Class GetResultSet Method

'Before build Select @2-36F207F9
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("s_STUDENT_ID",Urls_STUDENT_ID_lowest, "")
        CType(Select_,SqlCommand).AddParameter("s_ENROLMENT_YEAR",Urls_ENROLMENT_YEAR, "")
        CType(Select_,SqlCommand).AddParameter("s_ENROL_STATUS",Urls_ENROL_STATUS, "")
        CType(Select_,SqlCommand).AddParameter("s_YEAR_LEVEL",Urls_YEAR_LEVEL, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-5D588829
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As GridStudentListItem
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

'After execute Select @2-6C5081C2
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New GridStudentListItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-92691377
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as GridStudentListItem = New GridStudentListItem()
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
                item.SUBJ_ENROL_STATUS.SetValue(dr(i)("ENROLMENT_STATUS"),"")
                item.STAFF_ID.SetValue(dr(i)("PASTORAL_CARE_ID"),"")
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

