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

Namespace DECV_PROD2007.StudentSubject_TeachersNotYetAllocated 'Namespace @1-F0CA9757

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

'EditableGrid view_Class_List Item Class @3-E8974CD4
Public Class view_Class_ListItem
    Public errors As NameValueCollection = New NameValueCollection()
    Public RowId As Integer
    Private _deleteAllowed As Boolean = False
    Private _isNew As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public view_Class_List_TotalRecords As TextField
    Public STUDENT_ID As FloatField
    Public STUDENT_IDHref As Object
    Public STUDENT_IDHrefParameters As LinkParameterCollection
    Public SURNAME As TextField
    Public SCHOOL_NAME As TextField
    Public SEMESTER As TextField
    Public STAFF_ID As TextField
    Public STAFF_IDItems As ItemCollection
    Public SUBJECT_TITLE As TextField
    Public SUBJ_ENROL_STATUS As TextField
    Public ENROLMENT_DATE As DateField
    Public FIRST_NAME As TextField
    Public SUBJECT_ABBREV As TextField
    Public SUBJECT_ABBREVHref As Object
    Public SUBJECT_ABBREVHrefParameters As LinkParameterCollection
    Public link_ShowCurrentEnrolment As TextField
    Public link_ShowCurrentEnrolmentHref As Object
    Public link_ShowCurrentEnrolmentHrefParameters As LinkParameterCollection
    Public lblWarnFull As TextField
    Public YEAR_LEVEL As TextField
    Public hidPreviousStaffID As TextField
    Public lblStudentSubjectTeacherListHeading As TextField
    Public Sub New()
    view_Class_List_TotalRecords = New TextField("", Nothing)
    STUDENT_ID = New FloatField("",Nothing)
    STUDENT_IDHrefParameters = New LinkParameterCollection()
    SURNAME = New TextField("", Nothing)
    SCHOOL_NAME = New TextField("", Nothing)
    SEMESTER = New TextField("", Nothing)
    STAFF_ID = New TextField("", Nothing)
    STAFF_IDItems = New ItemCollection()
    SUBJECT_TITLE = New TextField("", Nothing)
    SUBJ_ENROL_STATUS = New TextField("", Nothing)
    ENROLMENT_DATE = New DateField("dd MMM, yyyy h\:mm tt", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    SUBJECT_ABBREV = New TextField("",Nothing)
    SUBJECT_ABBREVHrefParameters = New LinkParameterCollection()
    link_ShowCurrentEnrolment = New TextField("",Nothing)
    link_ShowCurrentEnrolmentHrefParameters = New LinkParameterCollection()
    lblWarnFull = New TextField("", Nothing)
    YEAR_LEVEL = New TextField("", Nothing)
    hidPreviousStaffID = New TextField("", Nothing)
    lblStudentSubjectTeacherListHeading = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase
        Get
            Select fieldName
                Case "STUDENT_IDField"
                    Return Me.STUDENT_IDField
                Case "ENROLMENT_YEARField"
                    Return Me.ENROLMENT_YEARField
                Case "SUBJECT_IDField"
                    Return Me.SUBJECT_IDField
                Case "SEMESTERField"
                    Return Me.SEMESTERField
                Case "view_Class_List_TotalRecords"
                    Return Me.view_Class_List_TotalRecords
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "SCHOOL_NAME"
                    Return Me.SCHOOL_NAME
                Case "SEMESTER"
                    Return Me.SEMESTER
                Case "STAFF_ID"
                    Return Me.STAFF_ID
                Case "SUBJECT_TITLE"
                    Return Me.SUBJECT_TITLE
                Case "SUBJ_ENROL_STATUS"
                    Return Me.SUBJ_ENROL_STATUS
                Case "ENROLMENT_DATE"
                    Return Me.ENROLMENT_DATE
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "SUBJECT_ABBREV"
                    Return Me.SUBJECT_ABBREV
                Case "link_ShowCurrentEnrolment"
                    Return Me.link_ShowCurrentEnrolment
                Case "lblWarnFull"
                    Return Me.lblWarnFull
                Case "YEAR_LEVEL"
                    Return Me.YEAR_LEVEL
                Case "hidPreviousStaffID"
                    Return Me.hidPreviousStaffID
                Case "lblStudentSubjectTeacherListHeading"
                    Return Me.lblStudentSubjectTeacherListHeading
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_IDField"
                    Me.STUDENT_IDField = CType(Value,FloatField)
                Case "ENROLMENT_YEARField"
                    Me.ENROLMENT_YEARField = CType(Value,FloatField)
                Case "SUBJECT_IDField"
                    Me.SUBJECT_IDField = CType(Value,IntegerField)
                Case "SEMESTERField"
                    Me.SEMESTERField = CType(Value,TextField)
                Case "view_Class_List_TotalRecords"
                    Me.view_Class_List_TotalRecords = CType(Value,TextField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "SCHOOL_NAME"
                    Me.SCHOOL_NAME = CType(Value,TextField)
                Case "SEMESTER"
                    Me.SEMESTER = CType(Value,TextField)
                Case "STAFF_ID"
                    Me.STAFF_ID = CType(Value,TextField)
                Case "SUBJECT_TITLE"
                    Me.SUBJECT_TITLE = CType(Value,TextField)
                Case "SUBJ_ENROL_STATUS"
                    Me.SUBJ_ENROL_STATUS = CType(Value,TextField)
                Case "ENROLMENT_DATE"
                    Me.ENROLMENT_DATE = CType(Value,DateField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "SUBJECT_ABBREV"
                    Me.SUBJECT_ABBREV = CType(Value,TextField)
                Case "link_ShowCurrentEnrolment"
                    Me.link_ShowCurrentEnrolment = CType(Value,TextField)
                Case "lblWarnFull"
                    Me.lblWarnFull = CType(Value,TextField)
                Case "YEAR_LEVEL"
                    Me.YEAR_LEVEL = CType(Value,TextField)
                Case "hidPreviousStaffID"
                    Me.hidPreviousStaffID = CType(Value,TextField)
                Case "lblStudentSubjectTeacherListHeading"
                    Me.lblStudentSubjectTeacherListHeading = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public ReadOnly Property IsDeleteAllowed As Boolean
        Get
            Return  Not(IsEmptyItem) AndAlso _deleteAllowed
        End Get
    End Property

    Public Property IsNew As Boolean
        Get
            Return _isNew
        End Get
        Set
            _isNew = Value
        End Set
    End Property

    Public ReadOnly Property IsEmptyItem As Boolean
        Get
            Dim result As Boolean = True
            result = IsNothing(STAFF_ID.Value) And result
            result = IsNothing(hidPreviousStaffID.Value) And result
            Return result
        End Get
    End Property

    Public IsDeleted As Boolean = False
    Public IsUpdated As Boolean = False
    Public STUDENT_IDField As FloatField = New FloatField()
    Public ENROLMENT_YEARField As FloatField = New FloatField()
    Public SUBJECT_IDField As IntegerField = New IntegerField()
    Public SEMESTERField As TextField = New TextField()
    Public Function Validate(ByVal provider As view_Class_ListDataProvider) As Boolean
'End EditableGrid view_Class_List Item Class

'EditableGrid view_Class_List Item Class tail @3-11D8DCF0
        Return errors.Count = 0
    End Function
    Public RawData As DataRow = Nothing
End Class
'End EditableGrid view_Class_List Item Class tail

'EditableGrid view_Class_List Data Provider Class Header @3-04A8FCA9
Public Class view_Class_ListDataProvider
Inherits EditableGridDataProviderBase
'End EditableGrid view_Class_List Data Provider Class Header

'Grid view_Class_List Data Provider Class Variables @3-CE32B326

    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_ID
        Sorter_SURNAME
        Sorter_SCHOOL_NAME
        Sorter_SEMESTER
        Sorter_SUBJECT_TITLE
        Sorter_SUBJ_ENROL_STATUS
        Sorter_ENROLMENT_DATE
        SorterYEAR_LEVEL
    End Enum

    Private SortFieldsNames As String() = New String() {"   ss.ENROLMENT_DATE,   ss.STUDENT_ID","STUDENT_ID","SURNAME","SCHOOL_NAME","SEMESTER","SUBJECT_TITLE","SUBJ_ENROL_STATUS","ENROLMENT_DATE","YEAR_LEVEL"}
    Private SortFieldsNamesDesc As String() = New string() {"   ss.ENROLMENT_DATE,   ss.STUDENT_ID","STUDENT_ID DESC","SURNAME DESC","SCHOOL_NAME DESC","SEMESTER DESC","SUBJECT_TITLE DESC","SUBJ_ENROL_STATUS DESC","ENROLMENT_DATE DESC","YEAR_LEVEL DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 40
    Public PageNumber As Integer = 1
    Public Urls_SEMESTER  As TextParameter
    Public UrlradioYearLevel  As IntegerParameter
    Public Urls_SURNAME  As TextParameter
    Public UrlrbSearchType  As TextParameter
    Public UrlddlSubject  As IntegerParameter
    Public CtrlSTAFF_ID  As TextParameter
    Public Expr78  As TextParameter
    Public Expr79  As DateParameter
'End Grid view_Class_List Data Provider Class Variables

'EditableGrid view_Class_List Data Provider Class Constructor @3-9182D837

    Public Sub New()
        Select_=new SqlCommand("select TOP {SqlParam_endRecord} " & vbCrLf & _
          "   se.ENROLMENT_YEAR," & vbCrLf & _
          "   st.STUDENT_ID," & vbCrLf & _
          "   iif(nullif(st.PREFERRED_NAME, '') is null," & vbCrLf & _
          "      rtrim(st.FIRST_NAME)," & vbCrLf & _
          "      concat(rtrim(st.FIRST_NAME), ' (', st.PREFERRED_NAME, ')')) as FIRST_NAME," & vbCrLf & _
          "   rtrim(st.SURNAME) as SURNAME," & vbCrLf & _
          "   se.YEAR_LEVEL," & vbCrLf & _
          "   ss.SUBJECT_ID," & vbCrLf & _
          "   ss.SEMESTER," & vbCrLf & _
          "   rtrim(sbj.SUBJECT_TITLE) as SUBJECT_TITLE," & vbCrLf & _
          "   rtrim(sbj.SUBJECT_ABBREV) as SUBJECT_ABBREV," & vbCrLf & _
          "   ss.ENROLMENT_DATE," & vbCrLf & _
          "   ss.SUBJ_ENROL_STATUS," & vbCrLf & _
          "   rtrim(ss.STAFF_ID) as STAFF_ID," & vbCrLf & _
          "   rtrim(sch.SCHOOL_NAME) as SCHOOL_NAME" & vbCrLf & _
          " from" & vbCrLf & _
          "   dbo.STUDENT as st" & vbCrLf & _
          "   inner join dbo.STUDENT_ENROLMENT as se" & vbCrLf & _
          "      on (se.STUDENT_ID = st.STUDENT_ID)" & vbCrLf & _
          "   inner join dbo.STUDENT_SUBJECT as ss" & vbCrLf & _
          "      on (" & vbCrLf & _
          "            (ss.STUDENT_ID = se.STUDENT_ID)" & vbCrLf & _
          "            and (ss.ENROLMENT_YEAR = se.ENROLMENT_YEAR)" & vbCrLf & _
          "         )" & vbCrLf & _
          "   inner join dbo.SUBJECT as sbj" & vbCrLf & _
          "      on (sbj.SUBJECT_ID = ss.SUBJECT_ID)" & vbCrLf & _
          "   left join dbo.SCHOOL as sch" & vbCrLf & _
          "      on (sch.SCHOOL_ID = st.HOME_SCHOOL_ID)" & vbCrLf & _
          " where" & vbCrLf & _
          "   (se.ENROLMENT_YEAR = iif(month(getdate()) <> 12, year(getdate()), year(getdate()) + 1))" & vbCrLf & _
          "   and (ss.SUBJECT_ID between 100 and 899)" & vbCrLf & _
          "   and (sbj.YEAR_LEVEL between 7 and 12)" & vbCrLf & _
          "   and (ss.SEMESTER in ('B', '{s_SEMESTER}'))" & vbCrLf & _
          "   and (ss.SUBJ_ENROL_STATUS <> 'W')" & vbCrLf & _
          "   and" & vbCrLf & _
          "   (" & vbCrLf & _
          "      (" & vbCrLf & _
          "         ('{rbSearchType}' = 'U')" & vbCrLf & _
          "         and (ss.STAFF_ID = 'N-A')" & vbCrLf & _
          "         and (" & vbCrLf & _
          "                ({ddlSubject} = 0)" & vbCrLf & _
          "                or (ss.SUBJECT_ID = {ddlSubject})" & vbCrLf & _
          "             )" & vbCrLf & _
          "      )" & vbCrLf & _
          "      or" & vbCrLf & _
          "      (" & vbCrLf & _
          "         ('{rbSearchType}' = 'C')" & vbCrLf & _
          "         and (ss.SUBJECT_ID = {ddlSubject})" & vbCrLf & _
          "      )" & vbCrLf & _
          "   )" & vbCrLf & _
          "   and" & vbCrLf & _
          "   (" & vbCrLf & _
          "      ({radioYearLevel} = 0)" & vbCrLf & _
          "      or ({radioYearLevel} = se.YEAR_LEVEL)" & vbCrLf & _
          "   )" & vbCrLf & _
          "   and" & vbCrLf & _
          "   (" & vbCrLf & _
          "      (nullif('{s_SURNAME}', '') is null)" & vbCrLf & _
          "      or" & vbCrLf & _
          "      (" & vbCrLf & _
          "         (len('{s_SURNAME}') >= 2)" & vbCrLf & _
          "         and" & vbCrLf & _
          "         (" & vbCrLf & _
          "            (st.PREFERRED_NAME like '%{s_SURNAME}%')" & vbCrLf & _
          "            or (st.FIRST_NAME like '%{s_SURNAME}%')" & vbCrLf & _
          "            or (st.SURNAME like '%{s_SURNAME}%')" & vbCrLf & _
          "            or (sch.SCHOOL_NAME like '%{s_SURNAME}%')" & vbCrLf & _
          "         )" & vbCrLf & _
          "      )" & vbCrLf & _
          "   )" & vbCrLf & _
          " {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (select" & vbCrLf & _
          "   se.ENROLMENT_YEAR," & vbCrLf & _
          "   st.STUDENT_ID," & vbCrLf & _
          "   iif(nullif(st.PREFERRED_NAME, '') is null," & vbCrLf & _
          "      rtrim(st.FIRST_NAME)," & vbCrLf & _
          "      concat(rtrim(st.FIRST_NAME), ' (', st.PREFERRED_NAME, ')')) as FIRST_NAME," & vbCrLf & _
          "   rtrim(st.SURNAME) as SURNAME," & vbCrLf & _
          "   se.YEAR_LEVEL," & vbCrLf & _
          "   ss.SUBJECT_ID," & vbCrLf & _
          "   ss.SEMESTER," & vbCrLf & _
          "   rtrim(sbj.SUBJECT_TITLE) as SUBJECT_TITLE," & vbCrLf & _
          "   rtrim(sbj.SUBJECT_ABBREV) as SUBJECT_ABBREV," & vbCrLf & _
          "   ss.ENROLMENT_DATE," & vbCrLf & _
          "   ss.SUBJ_ENROL_STATUS," & vbCrLf & _
          "   rtrim(ss.STAFF_ID) as STAFF_ID," & vbCrLf & _
          "   rtrim(sch.SCHOOL_NAME) as SCHOOL_NAME" & vbCrLf & _
          " from" & vbCrLf & _
          "   dbo.STUDENT as st" & vbCrLf & _
          "   inner join dbo.STUDENT_ENROLMENT as se" & vbCrLf & _
          "      on (se.STUDENT_ID = st.STUDENT_ID)" & vbCrLf & _
          "   inner join dbo.STUDENT_SUBJECT as ss" & vbCrLf & _
          "      on (" & vbCrLf & _
          "            (ss.STUDENT_ID = se.STUDENT_ID)" & vbCrLf & _
          "            and (ss.ENROLMENT_YEAR = se.ENROLMENT_YEAR)" & vbCrLf & _
          "         )" & vbCrLf & _
          "   inner join dbo.SUBJECT as sbj" & vbCrLf & _
          "      on (sbj.SUBJECT_ID = ss.SUBJECT_ID)" & vbCrLf & _
          "   left join dbo.SCHOOL as sch" & vbCrLf & _
          "      on (sch.SCHOOL_ID = st.HOME_SCHOOL_ID)" & vbCrLf & _
          " where" & vbCrLf & _
          "   (se.ENROLMENT_YEAR = iif(month(getdate()) <> 12, year(getdate()), year(getdate()) + 1))" & vbCrLf & _
          "   and (ss.SUBJECT_ID between 100 and 899)" & vbCrLf & _
          "   and (sbj.YEAR_LEVEL between 7 and 12)" & vbCrLf & _
          "   and (ss.SEMESTER in ('B', '{s_SEMESTER}'))" & vbCrLf & _
          "   and (ss.SUBJ_ENROL_STATUS <> 'W')" & vbCrLf & _
          "   and" & vbCrLf & _
          "   (" & vbCrLf & _
          "      (" & vbCrLf & _
          "         ('{rbSearchType}' = 'U')" & vbCrLf & _
          "         and (ss.STAFF_ID = 'N-A')" & vbCrLf & _
          "         and (" & vbCrLf & _
          "                ({ddlSubject} = 0)" & vbCrLf & _
          "                or (ss.SUBJECT_ID = {ddlSubject})" & vbCrLf & _
          "             )" & vbCrLf & _
          "      )" & vbCrLf & _
          "      or" & vbCrLf & _
          "      (" & vbCrLf & _
          "         ('{rbSearchType}' = 'C')" & vbCrLf & _
          "         and (ss.SUBJECT_ID = {ddlSubject})" & vbCrLf & _
          "      )" & vbCrLf & _
          "   )" & vbCrLf & _
          "   and" & vbCrLf & _
          "   (" & vbCrLf & _
          "      ({radioYearLevel} = 0)" & vbCrLf & _
          "      or ({radioYearLevel} = se.YEAR_LEVEL)" & vbCrLf & _
          "   )" & vbCrLf & _
          "   and" & vbCrLf & _
          "   (" & vbCrLf & _
          "      (nullif('{s_SURNAME}', '') is null)" & vbCrLf & _
          "      or" & vbCrLf & _
          "      (" & vbCrLf & _
          "         (len('{s_SURNAME}') >= 2)" & vbCrLf & _
          "         and" & vbCrLf & _
          "         (" & vbCrLf & _
          "            (st.PREFERRED_NAME like '%{s_SURNAME}%')" & vbCrLf & _
          "            or (st.FIRST_NAME like '%{s_SURNAME}%')" & vbCrLf & _
          "            or (st.SURNAME like '%{s_SURNAME}%')" & vbCrLf & _
          "            or (sch.SCHOOL_NAME like '%{s_SURNAME}%')" & vbCrLf & _
          "         )" & vbCrLf & _
          "      )" & vbCrLf & _
          "   )) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End EditableGrid view_Class_List Data Provider Class Constructor

'Record view_Class_List Data Provider Class CheckUnique Method @3-1F1F948A

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As view_Class_ListItem) As Boolean
        Return True
    End Function
'End Record view_Class_List Data Provider Class CheckUnique Method

'EditableGrid view_Class_List Data Provider Class Update Method @3-140F74D7
    Protected Function UpdateItem(ByVal item As view_Class_ListItem) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        IsParametersPassed = Not(IsNothing(item.STUDENT_IDField) Or IsNothing(item.ENROLMENT_YEARField) Or IsNothing(item.SUBJECT_IDField) Or IsNothing(item.SEMESTERField))
        Dim Update As DataCommand=new TableCommand("UPDATE STUDENT_SUBJECT SET {Values}", New String(){"STUDENT_ID73","And","ENROLMENT_YEAR74","And","SUBJECT_ID75","And","SEMESTER76"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End EditableGrid view_Class_List Data Provider Class Update Method

'EditableGrid view_Class_List BeforeBuildUpdate @3-71A6C026
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID73",item.STUDENT_IDField, "","STUDENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ENROLMENT_YEAR74",item.ENROLMENT_YEARField, "","ENROLMENT_YEAR",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("SUBJECT_ID75",item.SUBJECT_IDField, "","SUBJECT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("SEMESTER76",item.SEMESTERField, "","SEMESTER",Condition.Equal,False)
        allEmptyFlag = item.STAFF_ID.IsEmpty And allEmptyFlag
        If Not item.STAFF_ID.IsEmpty Then
        If IsNothing(item.STAFF_ID.Value) Then
        valuesList = valuesList & "STAFF_ID=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "STAFF_ID=" & Update.Dao.ToSql(item.STAFF_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = (Expr78 Is Nothing) And allEmptyFlag
        If Not (Expr78 Is Nothing) Then
        If IsNothing(Expr78) Then
        valuesList = valuesList & "LAST_ALTERED_BY=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "LAST_ALTERED_BY=" & Update.Dao.ToSql(Expr78.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = (Expr79 Is Nothing) And allEmptyFlag
        If Not (Expr79 Is Nothing) Then
        If IsNothing(Expr79) Then
        valuesList = valuesList & "LAST_ALTERED_DATE=" & Update.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        valuesList = valuesList & "LAST_ALTERED_DATE=" & Update.Dao.ToSql(Expr79.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        End If
		Update.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
'End EditableGrid view_Class_List BeforeBuildUpdate

'EditableGrid view_Class_List Event BeforeExecuteUpdate. Action Custom Code @177-73254650
      ' 26 Nov 2021|RW| Skip the update altogether for the student-subject if the selected staff member is null, N-A, or hasn't changed.
      Dim previousStaffID = item.hidPreviousStaffID.Value?.ToString().Trim()
      Dim newStaffID = item.STAFF_ID.Value?.ToString().Trim()
      If (String.IsNullOrEmpty(newStaffID) OrElse
                       (newStaffID.Equals("N-A", StringComparison.CurrentCultureIgnoreCase)) OrElse
                       (newStaffID.Equals(previousStaffID, StringComparison.CurrentCultureIgnoreCase))) Then
         CmdExecution = False
      End If
'End EditableGrid view_Class_List Event BeforeExecuteUpdate. Action Custom Code

'EditableGrid view_Class_List Execute Update  @3-392E25E7
        Update.OpType = OperationType.Update
        Dim result As Object = 0
        Dim E As Exception = Nothing
        If CmdExecution Then
            If Not IsParametersPassed Then
                item.errors.Add("DataProvider",Resources.strings.CCS_CustomOperationError_MissingParameters)
                Return 0
            End If
            Try
                 If Not allEmptyFlag Then result = Update.ExecuteNonQuery()
            Catch e_ As Exception
                item.errors.Add("DataProvider",e_.Source + ":" + e_.Message)
            Finally
'End EditableGrid view_Class_List Execute Update 

'EditableGrid view_Class_List AfterExecuteUpdate @3-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid view_Class_List AfterExecuteUpdate

'Grid view_Class_List Data Provider Class GetResultSet Method @3-BD5E26F2
    Public Sub Update(Items As ArrayList, ops As FormSupportedOperations)
        Dim i As Integer
        For i = 0 To Items.Count - 1
            Dim op As EditableGridOperation = EditableGridOperation.Insert
            Dim isProcessed As Boolean = False
            Dim item As view_Class_ListItem = CType(Items(i), view_Class_ListItem)
'End Grid view_Class_List Data Provider Class GetResultSet Method

'EditableGrid view_Class_List Data Provider Class Update @3-B4FF46D4
            If Not item.IsUpdated Then
                If Not(item.IsEmptyItem) And ops.AllowUpdate And Not(isProcessed) Then
                    UpdateItem(item)
                    op = EditableGridOperation.Update
                End If
'End EditableGrid view_Class_List Data Provider Class Update

'EditableGrid view_Class_List Data Provider Class AfterUpdate @3-6CCB76B9
                If item.errors.Count = 0 Then item.IsUpdated = True
                OnItemUpdated(New ItemUpdatedEventArgs(op, item))
            End If
        Next i
    End Sub
'End EditableGrid view_Class_List Data Provider Class AfterUpdate

'EditableGrid view_Class_List Data Provider Class GetResultSet Method @3-3DD8571B
    Public Function GetResultSet(ByRef _pagesCount As Integer, ops As FormSupportedOperations) As view_Class_ListItem()
'End EditableGrid view_Class_List Data Provider Class GetResultSet Method

'Before build Select @3-FC2BD32C
        _pagesCount = 0
        Dim E as Exception = Nothing
        Dim j As Integer
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("s_SEMESTER",Urls_SEMESTER, "")
        CType(Select_,SqlCommand).AddParameter("radioYearLevel",UrlradioYearLevel, "")
        CType(Select_,SqlCommand).AddParameter("s_SURNAME",Urls_SURNAME, "")
        CType(Select_,SqlCommand).AddParameter("rbSearchType",UrlrbSearchType, "")
        CType(Select_,SqlCommand).AddParameter("ddlSubject",UrlddlSubject, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy = SortFieldsNames(CInt(SortField)).Trim
        Else
            Select_.OrderBy = SortFieldsNamesDesc(CInt(SortField)).Trim
        End If
    Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @3-939614DD
        Dim dr As DataRowCollection = Nothing
        Dim rowCount as Integer = 0
        Dim ds As DataSet = Nothing
        If ops.AllowRead Then
            _pagesCount=0
            Try
                If RecordsPerPage>0
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _pagesCount = ExecuteCount()
                    m_recordCount = _pagesCount
                    If _pagesCount Mod RecordsPerPage>0 Then
                        _pagesCount = (_pagesCount\RecordsPerPage)+1
                    Else
                        _pagesCount = _pagesCount\RecordsPerPage
                    End If
                Else
                ds=ExecuteSelect()
                If ds.Tables(tableIndex).Rows.Count<>0 Then 
                    _pagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @3-7EFB4924
                If Not IsNothing(E) Then Throw E
            End Try
            dr = ds.Tables(tableIndex).Rows
            rowCount = dr.Count
        End If
        Dim result(rowCount - 1) As view_Class_ListItem
'End After execute Select

'ListBox STAFF_ID AfterExecuteSelect @60-449637AA
    Dim STAFF_IDItems As ItemCollection = New ItemCollection()
    
STAFF_IDItems.Add("null","All is Nothing")
'End ListBox STAFF_ID AfterExecuteSelect

'After execute Select tail @3-1FDBF9DF
        Dim i as Integer
        For i = 0 To rowCount - 1
            Dim item as view_Class_ListItem = New view_Class_ListItem()
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.STUDENT_IDHref = "StudentSummary.aspx"
            item.STUDENT_IDHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
            item.STUDENT_IDHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
            item.SURNAME.SetValue(dr(i)("SURNAME"),"")
            item.SCHOOL_NAME.SetValue(dr(i)("SCHOOL_NAME"),"")
            item.SEMESTER.SetValue(dr(i)("SEMESTER"),"")
            item.STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
            item.STAFF_IDItems = CType(STAFF_IDItems.Clone(), ItemCollection)
            item.SUBJECT_TITLE.SetValue(dr(i)("SUBJECT_TITLE"),"")
            item.SUBJ_ENROL_STATUS.SetValue(dr(i)("SUBJ_ENROL_STATUS"),"")
            item.ENROLMENT_DATE.SetValue(dr(i)("ENROLMENT_DATE"),Select_.DateFormat)
            item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
            item.SUBJECT_ABBREV.SetValue(dr(i)("SUBJECT_ABBREV"),"")
            item.SUBJECT_ABBREVHref = "SUBJECT_maint.aspx"
            item.SUBJECT_ABBREVHrefParameters.Add("SUBJECT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("SUBJECT_ID").ToString()))
            item.link_ShowCurrentEnrolmentHref = "StudentSubject_TeacherStats.aspx"
            item.link_ShowCurrentEnrolmentHrefParameters.Add("SUBJECT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("SUBJECT_ID").ToString()))
            item.link_ShowCurrentEnrolmentHrefParameters.Add("SUBJECT_ABBREV",System.Web.HttpUtility.UrlEncode(dr(i)("SUBJECT_ABBREV").ToString()))
            item.link_ShowCurrentEnrolmentHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
            item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
            item.hidPreviousStaffID.SetValue(dr(i)("STAFF_ID"),"")
            item.STUDENT_IDField.SetValue(dr(i)("STUDENT_ID"),"")
            item.ENROLMENT_YEARField.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.SUBJECT_IDField.SetValue(dr(i)("SUBJECT_ID"),"")
            item.SEMESTERField.SetValue(dr(i)("SEMESTER"),"")
            item.RawData = dr(i)
            result(i)=item
        Next i
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @3-A61BA892
End Class
'End Grid Data Provider tail

'Record view_Class_ListSearch Item Class @25-0D3D195D
Public Class view_Class_ListSearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public s_SURNAME As TextField
    Public radioYearLevel As IntegerField
    Public radioYearLevelItems As ItemCollection
    Public rbSearchType As TextField
    Public rbSearchTypeItems As ItemCollection
    Public ddlSubject As IntegerField
    Public ddlSubjectItems As ItemCollection
    Public s_SEMESTER As TextField
    Public s_SEMESTERItems As ItemCollection
    Public Sub New()
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    s_SURNAME = New TextField("", Nothing)
    radioYearLevel = New IntegerField("", 0)
    radioYearLevelItems = New ItemCollection()
    rbSearchType = New TextField("", "U")
    rbSearchTypeItems = New ItemCollection()
    ddlSubject = New IntegerField("", 0)
    ddlSubjectItems = New ItemCollection()
    s_SEMESTER = New TextField("", If((Month(Now()) >= 6) AndAlso (Month(Now()) < 12), "2", "1"))
    s_SEMESTERItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As view_Class_ListSearchItem
        Dim item As view_Class_ListSearchItem = New view_Class_ListSearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_SURNAME")) Then
        item.s_SURNAME.SetValue(DBUtility.GetInitialValue("s_SURNAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("radioYearLevel")) Then
        item.radioYearLevel.SetValue(DBUtility.GetInitialValue("radioYearLevel"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("rbSearchType")) Then
        item.rbSearchType.SetValue(DBUtility.GetInitialValue("rbSearchType"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ddlSubject")) Then
        item.ddlSubject.SetValue(DBUtility.GetInitialValue("ddlSubject"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_SEMESTER")) Then
        item.s_SEMESTER.SetValue(DBUtility.GetInitialValue("s_SEMESTER"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "ClearParameters"
                    Return ClearParameters
                Case "s_SURNAME"
                    Return s_SURNAME
                Case "radioYearLevel"
                    Return radioYearLevel
                Case "rbSearchType"
                    Return rbSearchType
                Case "ddlSubject"
                    Return ddlSubject
                Case "s_SEMESTER"
                    Return s_SEMESTER
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ClearParameters"
                    ClearParameters = CType(value, TextField)
                Case "s_SURNAME"
                    s_SURNAME = CType(value, TextField)
                Case "radioYearLevel"
                    radioYearLevel = CType(value, IntegerField)
                Case "rbSearchType"
                    rbSearchType = CType(value, TextField)
                Case "ddlSubject"
                    ddlSubject = CType(value, IntegerField)
                Case "s_SEMESTER"
                    s_SEMESTER = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As view_Class_ListSearchDataProvider)
'End Record view_Class_ListSearch Item Class

'ddlSubject validate @170-846D3324
        If (Not IsNothing(ddlSubject.Value)) And (Not (rbSearchType.Value?.ToString().Equals("U") OrElse ((ddlSubject.Value IsNot Nothing) AndAlso (Not ddlSubject.Value?.ToString().Equals("0"))))) Then
            errors.Add("ddlSubject","A subject must be selected when searching for current student subject teacher allocations")
        End If
'End ddlSubject validate

'Record view_Class_ListSearch Item Class tail @25-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record view_Class_ListSearch Item Class tail

'Record view_Class_ListSearch Data Provider Class @25-FA23A6B6
Public Class view_Class_ListSearchDataProvider
Inherits RecordDataProviderBase
'End Record view_Class_ListSearch Data Provider Class

'Record view_Class_ListSearch Data Provider Class Variables @25-FE1B8F5C
    Protected ddlSubjectDataCommand As DataCommand=new SqlCommand("select 0 as SUBJECT_ID, 'All subjects' as subject_displaylabel, 0 as DisplayOrder" & vbCrLf & _
          "union" & vbCrLf & _
          "select" & vbCrLf & _
          "   SUBJECT_ID," & vbCrLf & _
          "   subject_displaylabel," & vbCrLf & _
          "   1" & vbCrLf & _
          " from" & vbCrLf & _
          "   dbo.view_ReportParams_Subjects" & vbCrLf & _
          " where" & vbCrLf & _
          "   (SUBJECT_ID between 100 and 899)" & vbCrLf & _
          "   and (YEAR_LEVEL between 7 and 12)" & vbCrLf & _
          " {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
    Protected item As view_Class_ListSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record view_Class_ListSearch Data Provider Class Variables

'Record view_Class_ListSearch Data Provider Class GetResultSet Method @25-7597B4E5

    Public Sub FillItem(ByVal item As view_Class_ListSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record view_Class_ListSearch Data Provider Class GetResultSet Method

'Record view_Class_ListSearch BeforeBuildSelect @25-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record view_Class_ListSearch BeforeBuildSelect

'Record view_Class_ListSearch AfterExecuteSelect @25-83591636
        End If
            IsInsertMode = True
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record view_Class_ListSearch AfterExecuteSelect

'ListBox radioYearLevel AfterExecuteSelect @145-1133342A
        
item.radioYearLevelItems.Add("0","All Years")
item.radioYearLevelItems.Add("7","Year 7")
item.radioYearLevelItems.Add("8","Year 8")
item.radioYearLevelItems.Add("9","Year 9")
item.radioYearLevelItems.Add("10","Year 10")
item.radioYearLevelItems.Add("11","Year 11 VCE")
item.radioYearLevelItems.Add("12","Year 12 VCE")
'End ListBox radioYearLevel AfterExecuteSelect

'ListBox rbSearchType AfterExecuteSelect @169-7102C57D
        
item.rbSearchTypeItems.Add("U","Unallocated student subject teachers<br/>")
item.rbSearchTypeItems.Add("C","Current allocations for a subject (must be selected below)")
'End ListBox rbSearchType AfterExecuteSelect

'ListBox ddlSubject Initialize Data Source @170-A91EAFC1
        ddlSubjectDataCommand.Dao._optimized = False
        Dim ddlSubjecttableIndex As Integer = 0
        ddlSubjectDataCommand.OrderBy = "   DisplayOrder,   subject_displaylabel"
        ddlSubjectDataCommand.Parameters.Clear()
'End ListBox ddlSubject Initialize Data Source

'ListBox ddlSubject BeforeExecuteSelect @170-9C5CCE96
        Try
            ListBoxSource=ddlSubjectDataCommand.Execute().Tables(ddlSubjecttableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox ddlSubject BeforeExecuteSelect

'ListBox ddlSubject AfterExecuteSelect @170-32132C25
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New IntegerField("", ListBoxSource(j)("SUBJECT_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("subject_displaylabel")
            item.ddlSubjectItems.Add(Key, Val)
        Next
'End ListBox ddlSubject AfterExecuteSelect

'ListBox s_SEMESTER AfterExecuteSelect @33-020DFD7B
        
item.s_SEMESTERItems.Add("1","1")
item.s_SEMESTERItems.Add("2","2")
'End ListBox s_SEMESTER AfterExecuteSelect

'Record view_Class_ListSearch AfterExecuteSelect tail @25-E31F8E2A
    End Sub
'End Record view_Class_ListSearch AfterExecuteSelect tail

'Record view_Class_ListSearch Data Provider Class @25-A61BA892
End Class

'End Record view_Class_ListSearch Data Provider Class

'Record ForceRun Item Class @163-BE2FD678
Public Class ForceRunItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public listBatchSize As IntegerField
    Public listBatchSizeItems As ItemCollection
    Public checkVCEOnly As BooleanField
    Public checkVCEOnlyCheckedValue As BooleanField
    Public checkVCEOnlyUncheckedValue As BooleanField
    Public Sub New()
    listBatchSize = New IntegerField("", 200)
    listBatchSizeItems = New ItemCollection()
    checkVCEOnly = New BooleanField(Settings.BoolFormat, 1)
    checkVCEOnlyCheckedValue = New BooleanField(Settings.BoolFormat, 1)
    checkVCEOnlyUncheckedValue = New BooleanField(Settings.BoolFormat, 0)
    End Sub

    Public Shared Function CreateFromHttpRequest() As ForceRunItem
        Dim item As ForceRunItem = New ForceRunItem()
        If Not IsNothing(DBUtility.GetInitialValue("listBatchSize")) Then
        item.listBatchSize.SetValue(DBUtility.GetInitialValue("listBatchSize"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("checkVCEOnly")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("checkVCEOnly")) Then
            item.checkVCEOnly.Value = item.checkVCEOnlyCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "listBatchSize"
                    Return listBatchSize
                Case "checkVCEOnly"
                    Return checkVCEOnly
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "listBatchSize"
                    listBatchSize = CType(value, IntegerField)
                Case "checkVCEOnly"
                    checkVCEOnly = CType(value, BooleanField)
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

    Public Sub Validate(ByVal provider As ForceRunDataProvider)
'End Record ForceRun Item Class

'listBatchSize validate @164-1434012D
        If IsNothing(listBatchSize.Value) OrElse listBatchSize.Value.ToString() ="" Then
            errors.Add("listBatchSize",String.Format(Resources.strings.CCS_RequiredField,"Batch Size"))
        End If
'End listBatchSize validate

'Record ForceRun Item Class tail @163-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record ForceRun Item Class tail

'Record ForceRun Data Provider Class @163-91354F0E
Public Class ForceRunDataProvider
Inherits RecordDataProviderBase
'End Record ForceRun Data Provider Class

'Record ForceRun Data Provider Class Variables @163-B8E270BE
    Public UrlRETURN_VALUE As IntegerParameter
    Public CtrllistBatchSize As IntegerParameter
    Public ExprKey80 As IntegerParameter
    Public CtrlcheckVCEOnly As IntegerParameter
    Protected item As ForceRunItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record ForceRun Data Provider Class Variables

'Record ForceRun Data Provider Class Constructor @163-C83DC7D9

    Public Sub New()
        Select_=new SqlCommand("select 1",Settings.connDECVPRODSQL2005DataAccessObject)
        Update=new SpCommand("spu_NewEnrol_SubjectTeacher_Allocation_GetStudents;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record ForceRun Data Provider Class Constructor

'Record ForceRun Data Provider Class LoadParams Method @163-B45586B2

    Protected Function LoadParams() As Boolean
        Return True
    End Function
'End Record ForceRun Data Provider Class LoadParams Method

'Record ForceRun Data Provider Class CheckUnique Method @163-31E6CB2D

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As ForceRunItem) As Boolean
        Return True
    End Function
'End Record ForceRun Data Provider Class CheckUnique Method

'Record ForceRun Data Provider Class PrepareUpdate Method @163-0A131024

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
'End Record ForceRun Data Provider Class PrepareUpdate Method

'Record ForceRun Data Provider Class PrepareUpdate Method tail @163-E31F8E2A
    End Sub
'End Record ForceRun Data Provider Class PrepareUpdate Method tail

'Record ForceRun Data Provider Class Update Method @163-58518C19

    Public Function UpdateItem(ByVal item As ForceRunItem) As Integer
        Me.item = item
'End Record ForceRun Data Provider Class Update Method

'Record ForceRun BeforeBuildUpdate @163-61381BBD
        Update.Parameters.Clear()
        CType(Update,SpCommand).AddParameter("@RETURN_VALUE",UrlRETURN_VALUE,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Update,SpCommand).AddParameter("@batchSize",item.listBatchSize,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@updateFlag",ExprKey80,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@VCEOnly",item.checkVCEOnly,ParameterType._Int,ParameterDirection.Input,0,0,10)
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
            result = ExecuteUpdate()
            UrlRETURN_VALUE = IntegerParameter.GetParam(CType(Update.Parameters("@RETURN_VALUE"),IDataParameter).Value)
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record ForceRun BeforeBuildUpdate

'Record ForceRun AfterExecuteUpdate @163-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record ForceRun AfterExecuteUpdate

'Record ForceRun Data Provider Class GetResultSet Method @163-940590DB

    Public Sub FillItem(ByVal item As ForceRunItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record ForceRun Data Provider Class GetResultSet Method

'Record ForceRun BeforeBuildSelect @163-52D4E93F
        Select_.Parameters.Clear()
        IsInsertMode = False
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record ForceRun BeforeBuildSelect

'Record ForceRun BeforeExecuteSelect @163-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record ForceRun BeforeExecuteSelect

'Record ForceRun AfterExecuteSelect @163-7B594618
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
        Else
            IsInsertMode = True
        End If
'End Record ForceRun AfterExecuteSelect

'ListBox listBatchSize AfterExecuteSelect @164-F060B8C3
        
item.listBatchSizeItems.Add("100","100")
item.listBatchSizeItems.Add("200","200")
item.listBatchSizeItems.Add("350","350")
item.listBatchSizeItems.Add("500","500")
'End ListBox listBatchSize AfterExecuteSelect

'Record ForceRun AfterExecuteSelect tail @163-E31F8E2A
    End Sub
'End Record ForceRun AfterExecuteSelect tail

'Record ForceRun Data Provider Class @163-A61BA892
End Class

'End Record ForceRun Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

