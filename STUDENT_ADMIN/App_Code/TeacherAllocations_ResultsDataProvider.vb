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

Namespace DECV_PROD2007.TeacherAllocations_Results 'Namespace @1-8C179141

'Page Data Class @1-F380E5EC
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public lblDEBUG As TextField
    Public Sub New()
        Link1 = New TextField("",Nothing)
        Link1HrefParameters = New LinkParameterCollection()
        lblDEBUG = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Link1.SetValue(DBUtility.GetInitialValue("Link1"))
        item.lblDEBUG.SetValue(DBUtility.GetInitialValue("lblDEBUG"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Link1"
                    Return Link1
                Case "lblDEBUG"
                    Return lblDEBUG
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link1"
                    Link1 = CType(value, TextField)
                Case "lblDEBUG"
                    lblDEBUG = CType(value, TextField)
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

'Record UpdateForm Item Class @57-0F891831
Public Class UpdateFormItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public lblSubjectID As TextField
    Public lblSubjectTitle As TextField
    Public lblEnrolmentYear As TextField
    Public lblTeacherID As TextField
    Public lblSemester As TextField
    Public lblOrderBy As TextField
    Public listTeacher As TextField
    Public listTeacherItems As ItemCollection
    Public listappearsVASS As TextField
    Public listappearsVASSItems As ItemCollection
    Public listInterimResult As TextField
    Public listInterimResultItems As ItemCollection
    Public listFinalResult As TextField
    Public listFinalResultItems As ItemCollection
    Public hidden_LAST_ALTERED_BY As TextField
    Public lblSelections As TextField
    Public Sub New()
    lblSubjectID = New TextField("", Nothing)
    lblSubjectTitle = New TextField("", Nothing)
    lblEnrolmentYear = New TextField("", Nothing)
    lblTeacherID = New TextField("", Nothing)
    lblSemester = New TextField("", Nothing)
    lblOrderBy = New TextField("", Nothing)
    listTeacher = New TextField("", Nothing)
    listTeacherItems = New ItemCollection()
    listappearsVASS = New TextField("", 0)
    listappearsVASSItems = New ItemCollection()
    listInterimResult = New TextField("", Nothing)
    listInterimResultItems = New ItemCollection()
    listFinalResult = New TextField("", Nothing)
    listFinalResultItems = New ItemCollection()
    hidden_LAST_ALTERED_BY = New TextField("", Nothing)
    lblSelections = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As UpdateFormItem
        Dim item As UpdateFormItem = New UpdateFormItem()
        If Not IsNothing(DBUtility.GetInitialValue("lblSubjectID")) Then
        item.lblSubjectID.SetValue(DBUtility.GetInitialValue("lblSubjectID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblSubjectTitle")) Then
        item.lblSubjectTitle.SetValue(DBUtility.GetInitialValue("lblSubjectTitle"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblEnrolmentYear")) Then
        item.lblEnrolmentYear.SetValue(DBUtility.GetInitialValue("lblEnrolmentYear"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblTeacherID")) Then
        item.lblTeacherID.SetValue(DBUtility.GetInitialValue("lblTeacherID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblSemester")) Then
        item.lblSemester.SetValue(DBUtility.GetInitialValue("lblSemester"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblOrderBy")) Then
        item.lblOrderBy.SetValue(DBUtility.GetInitialValue("lblOrderBy"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("listTeacher")) Then
        item.listTeacher.SetValue(DBUtility.GetInitialValue("listTeacher"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("button_DoTeacher")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("listappearsVASS")) Then
        item.listappearsVASS.SetValue(DBUtility.GetInitialValue("listappearsVASS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("button_DoChangeOnvASS")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("listInterimResult")) Then
        item.listInterimResult.SetValue(DBUtility.GetInitialValue("listInterimResult"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("button_DoChangeInterimResult")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("listFinalResult")) Then
        item.listFinalResult.SetValue(DBUtility.GetInitialValue("listFinalResult"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("button_DoChangeFinalResult")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY")) Then
        item.hidden_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblSelections")) Then
        item.lblSelections.SetValue(DBUtility.GetInitialValue("lblSelections"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("button_DoTeacherSST")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "lblSubjectID"
                    Return lblSubjectID
                Case "lblSubjectTitle"
                    Return lblSubjectTitle
                Case "lblEnrolmentYear"
                    Return lblEnrolmentYear
                Case "lblTeacherID"
                    Return lblTeacherID
                Case "lblSemester"
                    Return lblSemester
                Case "lblOrderBy"
                    Return lblOrderBy
                Case "listTeacher"
                    Return listTeacher
                Case "listappearsVASS"
                    Return listappearsVASS
                Case "listInterimResult"
                    Return listInterimResult
                Case "listFinalResult"
                    Return listFinalResult
                Case "hidden_LAST_ALTERED_BY"
                    Return hidden_LAST_ALTERED_BY
                Case "lblSelections"
                    Return lblSelections
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblSubjectID"
                    lblSubjectID = CType(value, TextField)
                Case "lblSubjectTitle"
                    lblSubjectTitle = CType(value, TextField)
                Case "lblEnrolmentYear"
                    lblEnrolmentYear = CType(value, TextField)
                Case "lblTeacherID"
                    lblTeacherID = CType(value, TextField)
                Case "lblSemester"
                    lblSemester = CType(value, TextField)
                Case "lblOrderBy"
                    lblOrderBy = CType(value, TextField)
                Case "listTeacher"
                    listTeacher = CType(value, TextField)
                Case "listappearsVASS"
                    listappearsVASS = CType(value, TextField)
                Case "listInterimResult"
                    listInterimResult = CType(value, TextField)
                Case "listFinalResult"
                    listFinalResult = CType(value, TextField)
                Case "hidden_LAST_ALTERED_BY"
                    hidden_LAST_ALTERED_BY = CType(value, TextField)
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

'Record UpdateForm Data Provider Class Variables @57-26589FB3
    Protected listTeacherDataCommand As DataCommand=new TableCommand("SELECT staff_ID, " & vbCrLf & _
          "staffname " & vbCrLf & _
          "FROM View_StaffList_Active_Inactive {SQL_Where} {SQL_OrderBy}", New String(){"expr155","And","expr156","And","expr157"},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected listInterimResultDataCommand As DataCommand=new SqlCommand("select PROGRESS_CODE, PROGRESS_CODE+' '+rtrim(PROGRESS_CODE_TITLE) as description" & vbCrLf & _
          "from PROGRESS_CODE" & vbCrLf & _
          "where STATUS=1 and PROGRESS_CODE_TITLE not like '%Final%'",Settings.connDECVPRODSQL2005DataAccessObject)
    Protected listFinalResultDataCommand As DataCommand=new SqlCommand("select PROGRESS_CODE, PROGRESS_CODE+' '+rtrim(PROGRESS_CODE_TITLE) as description" & vbCrLf & _
          "from PROGRESS_CODE" & vbCrLf & _
          "where STATUS=1 and PROGRESS_CODE_TITLE not like '%Interim%'",Settings.connDECVPRODSQL2005DataAccessObject)
    Public Urls_SUBJECT_ID As IntegerParameter
    Protected item As UpdateFormItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record UpdateForm Data Provider Class Variables

'Record UpdateForm Data Provider Class Constructor @57-36376330

    Public Sub New()
        Select_=new SqlCommand("SELECT SUBJECT_TITLE " & vbCrLf & _
          "FROM SUBJECT" & vbCrLf & _
          "WHERE SUBJECT_ID = {s_SUBJECT_ID} ",Settings.connDECVPRODSQL2005DataAccessObject)
        Update=new SqlCommand("",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record UpdateForm Data Provider Class Constructor

'Record UpdateForm Data Provider Class LoadParams Method @57-B45586B2

    Protected Function LoadParams() As Boolean
        Return True
    End Function
'End Record UpdateForm Data Provider Class LoadParams Method

'Record UpdateForm Data Provider Class CheckUnique Method @57-5227C1D2

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As UpdateFormItem) As Boolean
        Return True
    End Function
'End Record UpdateForm Data Provider Class CheckUnique Method

'Record UpdateForm Data Provider Class PrepareUpdate Method @57-0A131024

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
'End Record UpdateForm Data Provider Class PrepareUpdate Method

'Record UpdateForm Data Provider Class PrepareUpdate Method tail @57-E31F8E2A
    End Sub
'End Record UpdateForm Data Provider Class PrepareUpdate Method tail

'Record UpdateForm Data Provider Class Update Method @57-F51BE98A

    Public Function UpdateItem(ByVal item As UpdateFormItem) As Integer
        Me.item = item
'End Record UpdateForm Data Provider Class Update Method

'Record UpdateForm BeforeBuildUpdate @57-AD037AB7
        Update.Parameters.Clear()
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
            result = ExecuteUpdate()
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record UpdateForm BeforeBuildUpdate

'Record UpdateForm AfterExecuteUpdate @57-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record UpdateForm AfterExecuteUpdate

'Record UpdateForm Data Provider Class GetResultSet Method @57-9C02F596

    Public Sub FillItem(ByVal item As UpdateFormItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record UpdateForm Data Provider Class GetResultSet Method

'Record UpdateForm BeforeBuildSelect @57-B96CBCCC
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("s_SUBJECT_ID",Urls_SUBJECT_ID, "")
        IsInsertMode = (IsNothing(Urls_SUBJECT_ID))
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record UpdateForm BeforeBuildSelect

'Record UpdateForm BeforeExecuteSelect @57-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record UpdateForm BeforeExecuteSelect

'Record UpdateForm AfterExecuteSelect @57-B7E710D0
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.lblSubjectTitle.SetValue(dr(i)("SUBJECT_TITLE"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record UpdateForm AfterExecuteSelect

'ListBox listTeacher Initialize Data Source @58-57F8C83F
        listTeacherDataCommand.Dao._optimized = False
        Dim listTeachertableIndex As Integer = 0
        listTeacherDataCommand.OrderBy = "STAFF_ID"
        listTeacherDataCommand.Parameters.Clear()
        listTeacherDataCommand.Parameters.Add("expr155","(TEACHER_FLAG=1)")
        listTeacherDataCommand.Parameters.Add("expr156","(STATUS=1)")
        listTeacherDataCommand.Parameters.Add("expr157","((STAFF_ID not in ('N-A', 'NO_SST', 'UNASSIGN')) and (STAFF_ID not like 'NSUBMIT%'))")
'End ListBox listTeacher Initialize Data Source

'ListBox listTeacher BeforeExecuteSelect @58-07CC3333
        Try
            ListBoxSource=listTeacherDataCommand.Execute().Tables(listTeachertableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox listTeacher BeforeExecuteSelect

'ListBox listTeacher AfterExecuteSelect @58-4318AD96
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("STAFF_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("staffname")
            item.listTeacherItems.Add(Key, Val)
        Next
'End ListBox listTeacher AfterExecuteSelect

'ListBox listappearsVASS AfterExecuteSelect @60-9D55704A
        
item.listappearsVASSItems.Add("0","No")
item.listappearsVASSItems.Add("1","Yes")
'End ListBox listappearsVASS AfterExecuteSelect

'ListBox listInterimResult Initialize Data Source @59-A34570E7
        listInterimResultDataCommand.Dao._optimized = False
        Dim listInterimResulttableIndex As Integer = 0
        listInterimResultDataCommand.OrderBy = ""
        listInterimResultDataCommand.Parameters.Clear()
'End ListBox listInterimResult Initialize Data Source

'ListBox listInterimResult BeforeExecuteSelect @59-34A045A3
        Try
            ListBoxSource=listInterimResultDataCommand.Execute().Tables(listInterimResulttableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox listInterimResult BeforeExecuteSelect

'ListBox listInterimResult AfterExecuteSelect @59-16C64077
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("PROGRESS_CODE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("description")
            item.listInterimResultItems.Add(Key, Val)
        Next
'End ListBox listInterimResult AfterExecuteSelect

'ListBox listFinalResult Initialize Data Source @63-6B7A5C33
        listFinalResultDataCommand.Dao._optimized = False
        Dim listFinalResulttableIndex As Integer = 0
        listFinalResultDataCommand.OrderBy = ""
        listFinalResultDataCommand.Parameters.Clear()
'End ListBox listFinalResult Initialize Data Source

'ListBox listFinalResult BeforeExecuteSelect @63-0DD07DB3
        Try
            ListBoxSource=listFinalResultDataCommand.Execute().Tables(listFinalResulttableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox listFinalResult BeforeExecuteSelect

'ListBox listFinalResult AfterExecuteSelect @63-C25A33EC
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("PROGRESS_CODE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("description")
            item.listFinalResultItems.Add(Key, Val)
        Next
'End ListBox listFinalResult AfterExecuteSelect

'Record UpdateForm AfterExecuteSelect tail @57-E31F8E2A
    End Sub
'End Record UpdateForm AfterExecuteSelect tail

'Record UpdateForm Data Provider Class @57-A61BA892
End Class

'End Record UpdateForm Data Provider Class

'Grid GridStudentList Item Class @2-8D5762B4
Public Class GridStudentListItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STUD_SUB_INTERIM_STUD_SUB_TotalRecords As TextField
    Public cbox As BooleanField
    Public cboxCheckedValue As BooleanField
    Public cboxUncheckedValue As BooleanField
    Public STUDENT_SUBJECT_STUDENT_ID As FloatField
    Public STUDENT_ID As TextField
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public SEMESTER As TextField
    Public SUBJ_ENROL_STATUS As TextField
    Public INTERIM_PROGRESS_CODE As TextField
    Public FINAL_PROGRESS_CODE As TextField
    Public STAFF_ID As TextField
    Public APPEARS_ON_VASS As BooleanField
    Public ATTENDING_SCHOOL_NAME As TextField
    Public Sub New()
    STUD_SUB_INTERIM_STUD_SUB_TotalRecords = New TextField("", Nothing)
    cbox = New BooleanField(Settings.BoolFormat, false)
    cboxCheckedValue = New BooleanField(Settings.BoolFormat, true)
    cboxUncheckedValue = New BooleanField(Settings.BoolFormat, false)
    STUDENT_SUBJECT_STUDENT_ID = New FloatField("", Nothing)
    STUDENT_ID = New TextField("", Nothing)
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    SEMESTER = New TextField("", Nothing)
    SUBJ_ENROL_STATUS = New TextField("", Nothing)
    INTERIM_PROGRESS_CODE = New TextField("", Nothing)
    FINAL_PROGRESS_CODE = New TextField("", Nothing)
    STAFF_ID = New TextField("", Nothing)
    APPEARS_ON_VASS = New BooleanField(Settings.BoolFormat, Nothing)
    ATTENDING_SCHOOL_NAME = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STUD_SUB_INTERIM_STUD_SUB_TotalRecords"
                    Return Me.STUD_SUB_INTERIM_STUD_SUB_TotalRecords
                Case "cbox"
                    Return Me.cbox
                Case "STUDENT_SUBJECT_STUDENT_ID"
                    Return Me.STUDENT_SUBJECT_STUDENT_ID
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "SEMESTER"
                    Return Me.SEMESTER
                Case "SUBJ_ENROL_STATUS"
                    Return Me.SUBJ_ENROL_STATUS
                Case "INTERIM_PROGRESS_CODE"
                    Return Me.INTERIM_PROGRESS_CODE
                Case "FINAL_PROGRESS_CODE"
                    Return Me.FINAL_PROGRESS_CODE
                Case "STAFF_ID"
                    Return Me.STAFF_ID
                Case "APPEARS_ON_VASS"
                    Return Me.APPEARS_ON_VASS
                Case "ATTENDING_SCHOOL_NAME"
                    Return Me.ATTENDING_SCHOOL_NAME
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
                Case "STUDENT_SUBJECT_STUDENT_ID"
                    Me.STUDENT_SUBJECT_STUDENT_ID = CType(Value,FloatField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,TextField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "SEMESTER"
                    Me.SEMESTER = CType(Value,TextField)
                Case "SUBJ_ENROL_STATUS"
                    Me.SUBJ_ENROL_STATUS = CType(Value,TextField)
                Case "INTERIM_PROGRESS_CODE"
                    Me.INTERIM_PROGRESS_CODE = CType(Value,TextField)
                Case "FINAL_PROGRESS_CODE"
                    Me.FINAL_PROGRESS_CODE = CType(Value,TextField)
                Case "STAFF_ID"
                    Me.STAFF_ID = CType(Value,TextField)
                Case "APPEARS_ON_VASS"
                    Me.APPEARS_ON_VASS = CType(Value,BooleanField)
                Case "ATTENDING_SCHOOL_NAME"
                    Me.ATTENDING_SCHOOL_NAME = CType(Value,TextField)
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

'Grid GridStudentList Data Provider Class Variables @2-8E8895B4

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_SUBJECT_STUDENT_ID
        Sorter_SURNAME
        Sorter_FIRST_NAME
        Sorter_SUBJ_ENROL_STATUS
        Sorter_STAFF_ID
        Sorter_ATTENDING_SCHOOL_NAME
    End Enum

    Private SortFieldsNames As String() = New String() {"","STUDENT_SUBJECT.STUDENT_ID","SURNAME","FIRST_NAME","SUBJ_ENROL_STATUS","STAFF_ID","ATTENDING_SCHOOL_NAME"}
    Private SortFieldsNamesDesc As String() = New string() {"","STUDENT_SUBJECT.STUDENT_ID DESC","SURNAME DESC","FIRST_NAME DESC","SUBJ_ENROL_STATUS DESC","STAFF_ID DESC","ATTENDING_SCHOOL_NAME DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 80
    Public PageNumber As Integer = 1
    Public Urls_SUBJECT_ID  As IntegerParameter
    Public Urls_ENROLMENT_YEAR  As FloatParameter
    Public Urls_STAFF_ID  As TextParameter
    Public Urls_SEMESTER  As TextParameter
    Public Urls_SUBJ_ENROL_STATUS  As TextParameter
    Public Urls_APPEARS_ON_VASS  As TextParameter
'End Grid GridStudentList Data Provider Class Variables

'Grid GridStudentList Data Provider Class GetResultSet Method @2-0AF96918

    Public Sub New()
        Select_=new SqlCommand("SELECT STUDENT_SUBJECT.STUDENT_ID AS STUDENT_SUBJECT_STUDENT_ID, STAFF_ID, SEMESTER, SUBJ_" & _
          "ENROL_STATUS, APPEARS_ON_VASS, INTERIM_PROGRESS_CODE," & vbCrLf & _
          "FINAL_PROGRESS_CODE, SURNAME, FIRST_NAME , rtrim(SCHOOL_NAME) as ATTENDING_SCHOOL_NAME" & vbCrLf & _
          "FROM (((STUDENT_SUBJECT INNER JOIN STUD_SUB_INTERIM ON" & vbCrLf & _
          "STUDENT_SUBJECT.STUDENT_ID = STUD_SUB_INTERIM.STUDENT_ID AND STUDENT_SUBJECT.ENROLMENT_YEA" & _
          "R = STUD_SUB_INTERIM.ENROLMENT_YEAR AND STUDENT_SUBJECT.SUBJECT_ID = STUD_SUB_INTERIM.SUBJ" & _
          "ECT_ID) " & vbCrLf & _
          "	INNER JOIN STUD_SUBJ_FINAL ON STUDENT_SUBJECT.STUDENT_ID = STUD_SUBJ_FINAL.STUDENT_ID AND" & _
          " STUDENT_SUBJECT.ENROLMENT_YEAR = STUD_SUBJ_FINAL.ENROLMENT_YEAR AND STUDENT_SUBJECT.SUBJE" & _
          "CT_ID = STUD_SUBJ_FINAL.SUBJECT_ID) " & vbCrLf & _
          "	INNER JOIN STUDENT ON STUDENT_SUBJECT.STUDENT_ID = STUDENT.STUDENT_ID)" & vbCrLf & _
          "	join SCHOOL on STUDENT.ATTENDING_SCHOOL_ID = SCHOOL.SCHOOL_ID" & vbCrLf & _
          "WHERE STUDENT_SUBJECT.SUBJECT_ID = {s_SUBJECT_ID}" & vbCrLf & _
          "AND STUDENT_SUBJECT.ENROLMENT_YEAR = {s_ENROLMENT_YEAR}" & vbCrLf & _
          "AND STUDENT_SUBJECT.STAFF_ID LIKE '%{s_STAFF_ID}%'" & vbCrLf & _
          "AND STUDENT_SUBJECT.SEMESTER LIKE '%{s_SEMESTER}%'" & vbCrLf & _
          "AND STUDENT_SUBJECT.SUBJ_ENROL_STATUS LIKE '{s_SUBJ_ENROL_STATUS}'" & vbCrLf & _
          "AND STUDENT_SUBJECT.APPEARS_ON_VASS in ({s_APPEARS_ON_VASS})",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (SELECT STUDENT_SUBJECT.STUDENT_ID AS STUDENT_SUBJECT_STUDENT_ID, STA" & _
          "FF_ID, SEMESTER, SUBJ_ENROL_STATUS, APPEARS_ON_VASS, INTERIM_PROGRESS_CODE," & vbCrLf & _
          "FINAL_PROGRESS_CODE, SURNAME, FIRST_NAME , rtrim(SCHOOL_NAME) as ATTENDING_SCHOOL_NAME" & vbCrLf & _
          "FROM (((STUDENT_SUBJECT INNER JOIN STUD_SUB_INTERIM ON" & vbCrLf & _
          "STUDENT_SUBJECT.STUDENT_ID = STUD_SUB_INTERIM.STUDENT_ID AND STUDENT_SUBJECT.ENROLMENT_YEA" & _
          "R = STUD_SUB_INTERIM.ENROLMENT_YEAR AND STUDENT_SUBJECT.SUBJECT_ID = STUD_SUB_INTERIM.SUBJ" & _
          "ECT_ID) " & vbCrLf & _
          "	INNER JOIN STUD_SUBJ_FINAL ON STUDENT_SUBJECT.STUDENT_ID = STUD_SUBJ_FINAL.STUDENT_ID AND" & _
          " STUDENT_SUBJECT.ENROLMENT_YEAR = STUD_SUBJ_FINAL.ENROLMENT_YEAR AND STUDENT_SUBJECT.SUBJE" & _
          "CT_ID = STUD_SUBJ_FINAL.SUBJECT_ID) " & vbCrLf & _
          "	INNER JOIN STUDENT ON STUDENT_SUBJECT.STUDENT_ID = STUDENT.STUDENT_ID)" & vbCrLf & _
          "	join SCHOOL on STUDENT.ATTENDING_SCHOOL_ID = SCHOOL.SCHOOL_ID" & vbCrLf & _
          "WHERE STUDENT_SUBJECT.SUBJECT_ID = {s_SUBJECT_ID}" & vbCrLf & _
          "AND STUDENT_SUBJECT.ENROLMENT_YEAR = {s_ENROLMENT_YEAR}" & vbCrLf & _
          "AND STUDENT_SUBJECT.STAFF_ID LIKE '%{s_STAFF_ID}%'" & vbCrLf & _
          "AND STUDENT_SUBJECT.SEMESTER LIKE '%{s_SEMESTER}%'" & vbCrLf & _
          "AND STUDENT_SUBJECT.SUBJ_ENROL_STATUS LIKE '{s_SUBJ_ENROL_STATUS}'" & vbCrLf & _
          "AND STUDENT_SUBJECT.APPEARS_ON_VASS in ({s_APPEARS_ON_VASS})) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid GridStudentList Data Provider Class GetResultSet Method

'Grid GridStudentList Data Provider Class GetResultSet Method @2-9F93D720
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As GridStudentListItem()
'End Grid GridStudentList Data Provider Class GetResultSet Method

'Before build Select @2-C9D901D7
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("s_SUBJECT_ID",Urls_SUBJECT_ID, "")
        CType(Select_,SqlCommand).AddParameter("s_ENROLMENT_YEAR",Urls_ENROLMENT_YEAR, "")
        CType(Select_,SqlCommand).AddParameter("s_STAFF_ID",Urls_STAFF_ID, "")
        CType(Select_,SqlCommand).AddParameter("s_SEMESTER",Urls_SEMESTER, "")
        CType(Select_,SqlCommand).AddParameter("s_SUBJ_ENROL_STATUS",Urls_SUBJ_ENROL_STATUS, "")
        CType(Select_,SqlCommand).AddParameter("s_APPEARS_ON_VASS",Urls_APPEARS_ON_VASS, "")
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

'After execute Select tail @2-0E8CEAEA
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as GridStudentListItem = New GridStudentListItem()
                item.STUDENT_SUBJECT_STUDENT_ID.SetValue(dr(i)("STUDENT_SUBJECT_STUDENT_ID"),"")
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_SUBJECT_STUDENT_ID"),"")
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.SEMESTER.SetValue(dr(i)("SEMESTER"),"")
                item.SUBJ_ENROL_STATUS.SetValue(dr(i)("SUBJ_ENROL_STATUS"),"")
                item.INTERIM_PROGRESS_CODE.SetValue(dr(i)("INTERIM_PROGRESS_CODE"),"")
                item.FINAL_PROGRESS_CODE.SetValue(dr(i)("FINAL_PROGRESS_CODE"),"")
                item.STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
                item.APPEARS_ON_VASS.SetValue(dr(i)("APPEARS_ON_VASS"),Select_.BoolFormat)
                item.ATTENDING_SCHOOL_NAME.SetValue(dr(i)("ATTENDING_SCHOOL_NAME"),"")
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

