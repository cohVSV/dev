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

Namespace DECV_PROD2007.StudentSubject_Details_maintain 'Namespace @1-4051995B

'Page Data Class @1-EA5FD4F6
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public linkSubjectList As TextField
    Public linkSubjectListHref As Object
    Public linkSubjectListHrefParameters As LinkParameterCollection
    Public lblSelections As TextField
    Public Sub New()
        linkSubjectList = New TextField("",Nothing)
        linkSubjectListHrefParameters = New LinkParameterCollection()
        lblSelections = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.linkSubjectList.SetValue(DBUtility.GetInitialValue("linkSubjectList"))
        item.lblSelections.SetValue(DBUtility.GetInitialValue("lblSelections"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "linkSubjectList"
                    Return linkSubjectList
                Case "lblSelections"
                    Return lblSelections
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "linkSubjectList"
                    linkSubjectList = CType(value, TextField)
                Case "lblSelections"
                    lblSelections = CType(value, TextField)
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

'Record viewStudentSummary_Subjec Item Class @4-4FBD7B5D
Public Class viewStudentSummary_SubjecItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public student_id As FloatField
    Public enrolment_year As FloatField
    Public SUBJECT_ID As IntegerField
    Public SUBJECT_TITLE As TextField
    Public SEMESTER As TextField
    Public SEMESTERItems As ItemCollection
    Public COURSE_DISTRIBUTION As TextField
    Public SUBJ_ENROL_STATUS As TextField
    Public SUBJ_ENROL_STATUSItems As ItemCollection
    Public enrolment_date As DateField
    Public withdrawal_date As DateField
    Public WITHDRAWAL_REASON_ID As IntegerField
    Public WITHDRAWAL_REASON_IDItems As ItemCollection
    Public NUM_ASSMT_SUBMISSIONS As IntegerField
    Public STAFF_ID As TextField
    Public STAFF_IDItems As ItemCollection
    Public FINAL_PROGRESS_CODE As TextField
    Public FINAL_PROGRESS_CODEItems As ItemCollection
    Public VBOS_REGISTERED As BooleanField
    Public VBOS_REGISTEREDItems As ItemCollection
    Public APPEARS_ON_VASS As BooleanField
    Public APPEARS_ON_VASSItems As ItemCollection
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public hidden_STUDENT_ID As FloatField
    Public hidden_ENROLMENT_YEAR As IntegerField
    Public hidden_SUBJECT_ID As IntegerField
    Public hidden_LAST_ALTERED_DATE As DateField
    Public hidden_LAST_ALTERED_BY As TextField
    Public lblSTAFF_ID As TextField
    Public lblDebug2 As TextField
    Public INTERIM_PROGRESS_CODE As TextField
    Public INTERIM_PROGRESS_CODEItems As ItemCollection
    Public EXTENSION_OF_VCE_UNIT As BooleanField
    Public EXTENSION_OF_VCE_UNITItems As ItemCollection
    Public NON_SUBMITTING_FLAG As IntegerField
    Public NON_SUBMITTING_FLAGItems As ItemCollection
    Public labelErrorStaffID As TextField
    Public Sub New()
    student_id = New FloatField("", Nothing)
    enrolment_year = New FloatField("", Nothing)
    SUBJECT_ID = New IntegerField("", Nothing)
    SUBJECT_TITLE = New TextField("", Nothing)
    SEMESTER = New TextField("", Nothing)
    SEMESTERItems = New ItemCollection()
    COURSE_DISTRIBUTION = New TextField("", Nothing)
    SUBJ_ENROL_STATUS = New TextField("", Nothing)
    SUBJ_ENROL_STATUSItems = New ItemCollection()
    enrolment_date = New DateField("dd\/MM\/yy", Nothing)
    withdrawal_date = New DateField("dd\/MM\/yy", Nothing)
    WITHDRAWAL_REASON_ID = New IntegerField("", Nothing)
    WITHDRAWAL_REASON_IDItems = New ItemCollection()
    NUM_ASSMT_SUBMISSIONS = New IntegerField("", Nothing)
    STAFF_ID = New TextField("", Nothing)
    STAFF_IDItems = New ItemCollection()
    FINAL_PROGRESS_CODE = New TextField("", Nothing)
    FINAL_PROGRESS_CODEItems = New ItemCollection()
    VBOS_REGISTERED = New BooleanField(Settings.BoolFormat, Nothing)
    VBOS_REGISTEREDItems = New ItemCollection()
    APPEARS_ON_VASS = New BooleanField(Settings.BoolFormat, Nothing)
    APPEARS_ON_VASSItems = New ItemCollection()
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    hidden_STUDENT_ID = New FloatField("", Nothing)
    hidden_ENROLMENT_YEAR = New IntegerField("", Nothing)
    hidden_SUBJECT_ID = New IntegerField("", Nothing)
    hidden_LAST_ALTERED_DATE = New DateField(Settings.DateFormat, DateTime.Now)
    hidden_LAST_ALTERED_BY = New TextField("", Nothing)
    lblSTAFF_ID = New TextField("", Nothing)
    lblDebug2 = New TextField("", Nothing)
    INTERIM_PROGRESS_CODE = New TextField("", Nothing)
    INTERIM_PROGRESS_CODEItems = New ItemCollection()
    EXTENSION_OF_VCE_UNIT = New BooleanField(Settings.BoolFormat, 0)
    EXTENSION_OF_VCE_UNITItems = New ItemCollection()
    NON_SUBMITTING_FLAG = New IntegerField("", 0)
    NON_SUBMITTING_FLAGItems = New ItemCollection()
    labelErrorStaffID = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As viewStudentSummary_SubjecItem
        Dim item As viewStudentSummary_SubjecItem = New viewStudentSummary_SubjecItem()
        If Not IsNothing(DBUtility.GetInitialValue("student_id")) Then
        item.student_id.SetValue(DBUtility.GetInitialValue("student_id"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("enrolment_year")) Then
        item.enrolment_year.SetValue(DBUtility.GetInitialValue("enrolment_year"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUBJECT_ID")) Then
        item.SUBJECT_ID.SetValue(DBUtility.GetInitialValue("SUBJECT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUBJECT_TITLE")) Then
        item.SUBJECT_TITLE.SetValue(DBUtility.GetInitialValue("SUBJECT_TITLE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SEMESTER")) Then
        item.SEMESTER.SetValue(DBUtility.GetInitialValue("SEMESTER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COURSE_DISTRIBUTION")) Then
        item.COURSE_DISTRIBUTION.SetValue(DBUtility.GetInitialValue("COURSE_DISTRIBUTION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUBJ_ENROL_STATUS")) Then
        item.SUBJ_ENROL_STATUS.SetValue(DBUtility.GetInitialValue("SUBJ_ENROL_STATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("enrolment_date")) Then
        item.enrolment_date.SetValue(DBUtility.GetInitialValue("enrolment_date"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("withdrawal_date")) Then
        item.withdrawal_date.SetValue(DBUtility.GetInitialValue("withdrawal_date"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("WITHDRAWAL_REASON_ID")) Then
        item.WITHDRAWAL_REASON_ID.SetValue(DBUtility.GetInitialValue("WITHDRAWAL_REASON_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("NUM_ASSMT_SUBMISSIONS")) Then
        item.NUM_ASSMT_SUBMISSIONS.SetValue(DBUtility.GetInitialValue("NUM_ASSMT_SUBMISSIONS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STAFF_ID")) Then
        item.STAFF_ID.SetValue(DBUtility.GetInitialValue("STAFF_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FINAL_PROGRESS_CODE")) Then
        item.FINAL_PROGRESS_CODE.SetValue(DBUtility.GetInitialValue("FINAL_PROGRESS_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("VBOS_REGISTERED")) Then
        item.VBOS_REGISTERED.SetValue(DBUtility.GetInitialValue("VBOS_REGISTERED"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("APPEARS_ON_VASS")) Then
        item.APPEARS_ON_VASS.SetValue(DBUtility.GetInitialValue("APPEARS_ON_VASS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_STUDENT_ID")) Then
        item.hidden_STUDENT_ID.SetValue(DBUtility.GetInitialValue("hidden_STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_ENROLMENT_YEAR")) Then
        item.hidden_ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("hidden_ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_SUBJECT_ID")) Then
        item.hidden_SUBJECT_ID.SetValue(DBUtility.GetInitialValue("hidden_SUBJECT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_DATE")) Then
        item.hidden_LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY")) Then
        item.hidden_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblSTAFF_ID")) Then
        item.lblSTAFF_ID.SetValue(DBUtility.GetInitialValue("lblSTAFF_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblDebug2")) Then
        item.lblDebug2.SetValue(DBUtility.GetInitialValue("lblDebug2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("INTERIM_PROGRESS_CODE")) Then
        item.INTERIM_PROGRESS_CODE.SetValue(DBUtility.GetInitialValue("INTERIM_PROGRESS_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EXTENSION_OF_VCE_UNIT")) Then
        item.EXTENSION_OF_VCE_UNIT.SetValue(DBUtility.GetInitialValue("EXTENSION_OF_VCE_UNIT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("NON_SUBMITTING_FLAG")) Then
        item.NON_SUBMITTING_FLAG.SetValue(DBUtility.GetInitialValue("NON_SUBMITTING_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("labelErrorStaffID")) Then
        item.labelErrorStaffID.SetValue(DBUtility.GetInitialValue("labelErrorStaffID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Extend")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "student_id"
                    Return student_id
                Case "enrolment_year"
                    Return enrolment_year
                Case "SUBJECT_ID"
                    Return SUBJECT_ID
                Case "SUBJECT_TITLE"
                    Return SUBJECT_TITLE
                Case "SEMESTER"
                    Return SEMESTER
                Case "COURSE_DISTRIBUTION"
                    Return COURSE_DISTRIBUTION
                Case "SUBJ_ENROL_STATUS"
                    Return SUBJ_ENROL_STATUS
                Case "enrolment_date"
                    Return enrolment_date
                Case "withdrawal_date"
                    Return withdrawal_date
                Case "WITHDRAWAL_REASON_ID"
                    Return WITHDRAWAL_REASON_ID
                Case "NUM_ASSMT_SUBMISSIONS"
                    Return NUM_ASSMT_SUBMISSIONS
                Case "STAFF_ID"
                    Return STAFF_ID
                Case "FINAL_PROGRESS_CODE"
                    Return FINAL_PROGRESS_CODE
                Case "VBOS_REGISTERED"
                    Return VBOS_REGISTERED
                Case "APPEARS_ON_VASS"
                    Return APPEARS_ON_VASS
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "hidden_STUDENT_ID"
                    Return hidden_STUDENT_ID
                Case "hidden_ENROLMENT_YEAR"
                    Return hidden_ENROLMENT_YEAR
                Case "hidden_SUBJECT_ID"
                    Return hidden_SUBJECT_ID
                Case "hidden_LAST_ALTERED_DATE"
                    Return hidden_LAST_ALTERED_DATE
                Case "hidden_LAST_ALTERED_BY"
                    Return hidden_LAST_ALTERED_BY
                Case "lblSTAFF_ID"
                    Return lblSTAFF_ID
                Case "lblDebug2"
                    Return lblDebug2
                Case "INTERIM_PROGRESS_CODE"
                    Return INTERIM_PROGRESS_CODE
                Case "EXTENSION_OF_VCE_UNIT"
                    Return EXTENSION_OF_VCE_UNIT
                Case "NON_SUBMITTING_FLAG"
                    Return NON_SUBMITTING_FLAG
                Case "labelErrorStaffID"
                    Return labelErrorStaffID
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "student_id"
                    student_id = CType(value, FloatField)
                Case "enrolment_year"
                    enrolment_year = CType(value, FloatField)
                Case "SUBJECT_ID"
                    SUBJECT_ID = CType(value, IntegerField)
                Case "SUBJECT_TITLE"
                    SUBJECT_TITLE = CType(value, TextField)
                Case "SEMESTER"
                    SEMESTER = CType(value, TextField)
                Case "COURSE_DISTRIBUTION"
                    COURSE_DISTRIBUTION = CType(value, TextField)
                Case "SUBJ_ENROL_STATUS"
                    SUBJ_ENROL_STATUS = CType(value, TextField)
                Case "enrolment_date"
                    enrolment_date = CType(value, DateField)
                Case "withdrawal_date"
                    withdrawal_date = CType(value, DateField)
                Case "WITHDRAWAL_REASON_ID"
                    WITHDRAWAL_REASON_ID = CType(value, IntegerField)
                Case "NUM_ASSMT_SUBMISSIONS"
                    NUM_ASSMT_SUBMISSIONS = CType(value, IntegerField)
                Case "STAFF_ID"
                    STAFF_ID = CType(value, TextField)
                Case "FINAL_PROGRESS_CODE"
                    FINAL_PROGRESS_CODE = CType(value, TextField)
                Case "VBOS_REGISTERED"
                    VBOS_REGISTERED = CType(value, BooleanField)
                Case "APPEARS_ON_VASS"
                    APPEARS_ON_VASS = CType(value, BooleanField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "hidden_STUDENT_ID"
                    hidden_STUDENT_ID = CType(value, FloatField)
                Case "hidden_ENROLMENT_YEAR"
                    hidden_ENROLMENT_YEAR = CType(value, IntegerField)
                Case "hidden_SUBJECT_ID"
                    hidden_SUBJECT_ID = CType(value, IntegerField)
                Case "hidden_LAST_ALTERED_DATE"
                    hidden_LAST_ALTERED_DATE = CType(value, DateField)
                Case "hidden_LAST_ALTERED_BY"
                    hidden_LAST_ALTERED_BY = CType(value, TextField)
                Case "lblSTAFF_ID"
                    lblSTAFF_ID = CType(value, TextField)
                Case "lblDebug2"
                    lblDebug2 = CType(value, TextField)
                Case "INTERIM_PROGRESS_CODE"
                    INTERIM_PROGRESS_CODE = CType(value, TextField)
                Case "EXTENSION_OF_VCE_UNIT"
                    EXTENSION_OF_VCE_UNIT = CType(value, BooleanField)
                Case "NON_SUBMITTING_FLAG"
                    NON_SUBMITTING_FLAG = CType(value, IntegerField)
                Case "labelErrorStaffID"
                    labelErrorStaffID = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As viewStudentSummary_SubjecDataProvider)
'End Record viewStudentSummary_Subjec Item Class

'SEMESTER validate @12-6C5B1447
        If IsNothing(SEMESTER.Value) OrElse SEMESTER.Value.ToString() ="" Then
            errors.Add("SEMESTER",String.Format(Resources.strings.CCS_RequiredField,"SEMESTER"))
        End If
'End SEMESTER validate

'SUBJ_ENROL_STATUS validate @14-3B8BBCCC
        If IsNothing(SUBJ_ENROL_STATUS.Value) OrElse SUBJ_ENROL_STATUS.Value.ToString() ="" Then
            errors.Add("SUBJ_ENROL_STATUS",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT STATUS"))
        End If
'End SUBJ_ENROL_STATUS validate

'enrolment_date validate @15-3DE404BE
        If IsNothing(enrolment_date.Value) OrElse enrolment_date.Value.ToString() ="" Then
            errors.Add("enrolment_date",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT DATE"))
        End If
'End enrolment_date validate

'TextBox withdrawal_date Event OnValidate. Action Custom Code @102-73254650
    ' -------------------------
	'ERA: 5/Sept/2008 - check if SUBJ_ENROL_STATUS listbox is a Withdrawn or Finished code (W or F) and force the END DATE to be include
        If (SUBJ_ENROL_STATUS.value.Contains("W") Or SUBJ_ENROL_STATUS.value.Contains("F")) Then
            If IsNothing(withdrawal_date.Value) OrElse withdrawal_date.Value.ToString() = "" Then
                errors.Add("WITHDRAWAL_DATE", String.Format("Enrolment Status of Withdrawn or Finished require an {0} to be entered.", "END DATE"))
            End If
        End If
    ' -------------------------
'End TextBox withdrawal_date Event OnValidate. Action Custom Code

'ListBox WITHDRAWAL_REASON_ID Event OnValidate. Action Custom Code @265-73254650
    ' -------------------------
    'ERA: 4-Feb-2015|EA| ensure the WD Reason is also set for WD
        If (SUBJ_ENROL_STATUS.value.Contains("W")) Then
    ' -------------------------
'End ListBox WITHDRAWAL_REASON_ID Event OnValidate. Action Custom Code

'ListBox WITHDRAWAL_REASON_ID Event OnValidate. Action Validate Required Value @264-6A3966DC
        If (WITHDRAWAL_REASON_ID.Value Is Nothing) OrElse WITHDRAWAL_REASON_ID.Value.ToString()="" Then
            errors.Add("WITHDRAWAL_REASON_ID",String.Format("WITHDRAWAL REASON is required if ENROLMENT STATUS is Withdrawn","WITHDRAWAL REASON"))
        End If
'End ListBox WITHDRAWAL_REASON_ID Event OnValidate. Action Validate Required Value

'ListBox WITHDRAWAL_REASON_ID Event OnValidate. Action Custom Code @266-73254650
    ' -------------------------
        End If
    ' -------------------------
'End ListBox WITHDRAWAL_REASON_ID Event OnValidate. Action Custom Code

'STAFF_ID validate @19-9BE36417
        If IsNothing(STAFF_ID.Value) OrElse STAFF_ID.Value.ToString() ="" Then
            errors.Add("STAFF_ID",String.Format(Resources.strings.CCS_RequiredField,"TEACHER"))
        End If
        If (Not IsNothing(STAFF_ID.Value)) And (Not STAFF_ID.Value.Contains("NSUBMIT") = FALSE) Then
            errors.Add("STAFF_ID","<font color='red'>Do not use NSUBMIT - use NON SUBMITTING? YES</font>")
        End If
'End STAFF_ID validate

'VBOS_REGISTERED validate @22-0C3DE712
        If IsNothing(VBOS_REGISTERED.Value) OrElse VBOS_REGISTERED.Value.ToString() ="" Then
            errors.Add("VBOS_REGISTERED",String.Format(Resources.strings.CCS_RequiredField,"VBOS REGISTERED"))
        End If
'End VBOS_REGISTERED validate

'APPEARS_ON_VASS validate @23-09F52AD3
        If IsNothing(APPEARS_ON_VASS.Value) OrElse APPEARS_ON_VASS.Value.ToString() ="" Then
            errors.Add("APPEARS_ON_VASS",String.Format(Resources.strings.CCS_RequiredField,"APPEARS ON VASS"))
        End If
'End APPEARS_ON_VASS validate

'EXTENSION_OF_VCE_UNIT validate @24-1186C05C
        If IsNothing(EXTENSION_OF_VCE_UNIT.Value) OrElse EXTENSION_OF_VCE_UNIT.Value.ToString() ="" Then
            errors.Add("EXTENSION_OF_VCE_UNIT",String.Format(Resources.strings.CCS_RequiredField,"EXTENSION OF VCE UNIT"))
        End If
'End EXTENSION_OF_VCE_UNIT validate

'Record viewStudentSummary_Subjec Item Class tail @4-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record viewStudentSummary_Subjec Item Class tail

'Record viewStudentSummary_Subjec Data Provider Class @4-C8562971
Public Class viewStudentSummary_SubjecDataProvider
Inherits RecordDataProviderBase
'End Record viewStudentSummary_Subjec Data Provider Class

'Record viewStudentSummary_Subjec Data Provider Class Variables @4-6550BAD2
    Protected WITHDRAWAL_REASON_IDDataCommand As DataCommand=new TableCommand("SELECT WITHDRAWAL_REASON_ID, " & vbCrLf & _
          "WITHDRAWAL_REASON " & vbCrLf & _
          "FROM WITHDRAWAL_REASON {SQL_Where} {SQL_OrderBy}", New String(){"expr223"},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected STAFF_IDDataCommand As DataCommand=new TableCommand("SELECT STAFF_ID " & vbCrLf & _
          "FROM STAFF {SQL_Where} {SQL_OrderBy}", New String(){"expr178","And","expr179"},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected FINAL_PROGRESS_CODEDataCommand As DataCommand=new SqlCommand("select PROGRESS_CODE, PROGRESS_CODE+' '+rtrim(PROGRESS_CODE_TITLE) as description" & vbCrLf & _
          "from PROGRESS_CODE" & vbCrLf & _
          "where STATUS=1 and PROGRESS_CODE_TITLE not like '%Interim%'",Settings.connDECVPRODSQL2005DataAccessObject)
    Protected INTERIM_PROGRESS_CODEDataCommand As DataCommand=new TableCommand("SELECT PROGRESS_CODE, " & vbCrLf & _
          "PROGRESS_CODE+' '+rtrim(PROGRESS_CODE_TITLE) AS description " & vbCrLf & _
          "FROM PROGRESS_CODE {SQL_Where} {SQL_OrderBy}", New String(){"expr31"},Settings.connDECVPRODSQL2005DataAccessObject )
    Public Urlstudent_id As FloatParameter
    Public Urlenrolment_year As FloatParameter
    Public UrlSUBJECT_ID As IntegerParameter
    Public ExprKey1 As IntegerParameter
    Public ExprKey4 As TextParameter
    Public Ctrlhidden_STUDENT_ID As FloatParameter
    Public Ctrlhidden_ENROLMENT_YEAR As FloatParameter
    Public Ctrlhidden_SUBJECT_ID As IntegerParameter
    Public CtrlSEMESTER As TextParameter
    Public CtrlSUBJ_ENROL_STATUS As TextParameter
    Public Ctrlenrolment_date As DateParameter
    Public Ctrlwithdrawal_date As DateParameter
    Public CtrlWITHDRAWAL_REASON_ID As FloatParameter
    Public CtrlSTAFF_ID As TextParameter
    Public CtrlVBOS_REGISTERED As BooleanParameter
    Public CtrlAPPEARS_ON_VASS As BooleanParameter
    Public CtrlEXTENSION_OF_VCE_UNIT As BooleanParameter
    Public Ctrlhidden_LAST_ALTERED_BY As TextParameter
    Public Ctrlhidden_LAST_ALTERED_DATE As DateParameter
    Public CtrlNON_SUBMITTING_FLAG As IntegerParameter
    Protected item As viewStudentSummary_SubjecItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record viewStudentSummary_Subjec Data Provider Class Variables

'Record viewStudentSummary_Subjec Data Provider Class Constructor @4-343F5300

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM viewStudentSummary_SubjectDetails {SQL_Where} {SQL_OrderBy}", New String(){"student_id312","And","enrolment_year313","And","SUBJECT_ID314"},Settings.connDECVPRODSQL2005DataAccessObject )
        Insert=new SpCommand("spu_ExtendStudentSubject;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record viewStudentSummary_Subjec Data Provider Class Constructor

'Record viewStudentSummary_Subjec Data Provider Class LoadParams Method @4-E4EC53EF

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(Urlstudent_id) Or IsNothing(Urlenrolment_year) Or IsNothing(UrlSUBJECT_ID))
    End Function
'End Record viewStudentSummary_Subjec Data Provider Class LoadParams Method

'Record viewStudentSummary_Subjec Data Provider Class CheckUnique Method @4-9C2641D2

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As viewStudentSummary_SubjecItem) As Boolean
        Return True
    End Function
'End Record viewStudentSummary_Subjec Data Provider Class CheckUnique Method

'Record viewStudentSummary_Subjec Data Provider Class PrepareInsert Method @4-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record viewStudentSummary_Subjec Data Provider Class PrepareInsert Method

'Record viewStudentSummary_Subjec Data Provider Class PrepareInsert Method tail @4-E31F8E2A
    End Sub
'End Record viewStudentSummary_Subjec Data Provider Class PrepareInsert Method tail

'Record viewStudentSummary_Subjec Data Provider Class Insert Method @4-0F035F51

    Public Function InsertItem(ByVal item As viewStudentSummary_SubjecItem) As Integer
        Me.item = item
'End Record viewStudentSummary_Subjec Data Provider Class Insert Method

'Record viewStudentSummary_Subjec Build insert @4-2F037AB3
        Insert.Parameters.Clear()
        CType(Insert,SpCommand).AddParameter("@RETURN_VALUE",ExprKey1,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Insert,SpCommand).AddParameter("@STUDENT_ID",item.hidden_STUDENT_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Insert,SpCommand).AddParameter("@SUBJECT_ID",item.hidden_SUBJECT_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Insert,SpCommand).AddParameter("@LAST_ALTERED_BY",ExprKey4,ParameterType._Char,ParameterDirection.Input,12,0,0)
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
            result = ExecuteInsert()
            ExprKey1 = IntegerParameter.GetParam(CType(Insert.Parameters("@RETURN_VALUE"),IDataParameter).Value)
        Catch ee As Exception
            E = ee
        Finally
'End Record viewStudentSummary_Subjec Build insert

'Record viewStudentSummary_Subjec AfterExecuteInsert @4-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record viewStudentSummary_Subjec AfterExecuteInsert

'Record viewStudentSummary_Subjec Data Provider Class PrepareUpdate Method @4-F8115C16

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = Not(IsNothing(item.hidden_STUDENT_ID) Or IsNothing(item.hidden_ENROLMENT_YEAR) Or IsNothing(item.hidden_SUBJECT_ID))
'End Record viewStudentSummary_Subjec Data Provider Class PrepareUpdate Method

'Record viewStudentSummary_Subjec Data Provider Class PrepareUpdate Method tail @4-E31F8E2A
    End Sub
'End Record viewStudentSummary_Subjec Data Provider Class PrepareUpdate Method tail

'Record viewStudentSummary_Subjec Data Provider Class Update Method @4-F3603696

    Public Function UpdateItem(ByVal item As viewStudentSummary_SubjecItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT_SUBJECT SET {Values}", New String(){"hidden_STUDENT_ID40","And","hidden_ENROLMENT_YEAR53","And","hidden_SUBJECT_ID83"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record viewStudentSummary_Subjec Data Provider Class Update Method

'Record viewStudentSummary_Subjec BeforeBuildUpdate @4-3E170711
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("hidden_STUDENT_ID40",item.hidden_STUDENT_ID, "","student_id",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("hidden_ENROLMENT_YEAR53",item.hidden_ENROLMENT_YEAR, "","enrolment_year",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("hidden_SUBJECT_ID83",item.hidden_SUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        allEmptyFlag = item.SEMESTER.IsEmpty And allEmptyFlag
        If Not item.SEMESTER.IsEmpty Then
        If IsNothing(item.SEMESTER.Value) Then
        valuesList = valuesList & "SEMESTER=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "SEMESTER=" & Update.Dao.ToSql(item.SEMESTER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.SUBJ_ENROL_STATUS.IsEmpty And allEmptyFlag
        If Not item.SUBJ_ENROL_STATUS.IsEmpty Then
        If IsNothing(item.SUBJ_ENROL_STATUS.Value) Then
        valuesList = valuesList & "SUBJ_ENROL_STATUS=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "SUBJ_ENROL_STATUS=" & Update.Dao.ToSql(item.SUBJ_ENROL_STATUS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.enrolment_date.IsEmpty And allEmptyFlag
        If Not item.enrolment_date.IsEmpty Then
        If IsNothing(item.enrolment_date.Value) Then
        valuesList = valuesList & "ENROLMENT_DATE=" & Update.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        valuesList = valuesList & "ENROLMENT_DATE=" & Update.Dao.ToSql(item.enrolment_date.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        End If
        allEmptyFlag = item.withdrawal_date.IsEmpty And allEmptyFlag
        If Not item.withdrawal_date.IsEmpty Then
        If IsNothing(item.withdrawal_date.Value) Then
        valuesList = valuesList & "WITHDRAWAL_DATE=" & Update.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        valuesList = valuesList & "WITHDRAWAL_DATE=" & Update.Dao.ToSql(item.withdrawal_date.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        End If
        allEmptyFlag = item.WITHDRAWAL_REASON_ID.IsEmpty And allEmptyFlag
        If Not item.WITHDRAWAL_REASON_ID.IsEmpty Then
        If IsNothing(item.WITHDRAWAL_REASON_ID.Value) Then
        valuesList = valuesList & "WITHDRAWAL_REASON_ID=" & Update.Dao.ToSql(Nothing,FieldType._Float) & ","
        Else
        valuesList = valuesList & "WITHDRAWAL_REASON_ID=" & Update.Dao.ToSql(item.WITHDRAWAL_REASON_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        End If
        allEmptyFlag = item.STAFF_ID.IsEmpty And allEmptyFlag
        If Not item.STAFF_ID.IsEmpty Then
        If IsNothing(item.STAFF_ID.Value) Then
        valuesList = valuesList & "STAFF_ID=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "STAFF_ID=" & Update.Dao.ToSql(item.STAFF_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.VBOS_REGISTERED.IsEmpty And allEmptyFlag
        If Not item.VBOS_REGISTERED.IsEmpty Then
        If IsNothing(item.VBOS_REGISTERED.Value) Then
        valuesList = valuesList & "VBOS_REGISTERED=" & Update.Dao.ToSql(Nothing,FieldType._Boolean) & ","
        Else
        valuesList = valuesList & "VBOS_REGISTERED=" & Update.Dao.ToSql(item.VBOS_REGISTERED.GetFormattedValue("1;0"),FieldType._Boolean) & ","
        End If
        End If
        allEmptyFlag = item.APPEARS_ON_VASS.IsEmpty And allEmptyFlag
        If Not item.APPEARS_ON_VASS.IsEmpty Then
        If IsNothing(item.APPEARS_ON_VASS.Value) Then
        valuesList = valuesList & "APPEARS_ON_VASS=" & Update.Dao.ToSql(Nothing,FieldType._Boolean) & ","
        Else
        valuesList = valuesList & "APPEARS_ON_VASS=" & Update.Dao.ToSql(item.APPEARS_ON_VASS.GetFormattedValue("1;0"),FieldType._Boolean) & ","
        End If
        End If
        allEmptyFlag = item.EXTENSION_OF_VCE_UNIT.IsEmpty And allEmptyFlag
        If Not item.EXTENSION_OF_VCE_UNIT.IsEmpty Then
        If IsNothing(item.EXTENSION_OF_VCE_UNIT.Value) Then
        valuesList = valuesList & "EXTENSION_OF_VCE_UNIT=" & Update.Dao.ToSql(Nothing,FieldType._Boolean) & ","
        Else
        valuesList = valuesList & "EXTENSION_OF_VCE_UNIT=" & Update.Dao.ToSql(item.EXTENSION_OF_VCE_UNIT.GetFormattedValue("1;0"),FieldType._Boolean) & ","
        End If
        End If
        allEmptyFlag = item.hidden_LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        If Not item.hidden_LAST_ALTERED_BY.IsEmpty Then
        If IsNothing(item.hidden_LAST_ALTERED_BY.Value) Then
        valuesList = valuesList & "LAST_ALTERED_BY=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "LAST_ALTERED_BY=" & Update.Dao.ToSql(item.hidden_LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.hidden_LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        If Not item.hidden_LAST_ALTERED_DATE.IsEmpty Then
        If IsNothing(item.hidden_LAST_ALTERED_DATE.Value) Then
        valuesList = valuesList & "LAST_ALTERED_DATE=" & Update.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        valuesList = valuesList & "LAST_ALTERED_DATE=" & Update.Dao.ToSql(item.hidden_LAST_ALTERED_DATE.GetFormattedValue("yyyy-MM-dd HH\:mm\:ss"),FieldType._Date) & ","
        End If
        End If
        allEmptyFlag = item.NON_SUBMITTING_FLAG.IsEmpty And allEmptyFlag
        If Not item.NON_SUBMITTING_FLAG.IsEmpty Then
        If IsNothing(item.NON_SUBMITTING_FLAG.Value) Then
        valuesList = valuesList & "NON_SUBMITTING_FLAG=" & Update.Dao.ToSql((0).ToString(),FieldType._Integer) & ","
        Else
        valuesList = valuesList & "NON_SUBMITTING_FLAG=" & Update.Dao.ToSql(item.NON_SUBMITTING_FLAG.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
		Update.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
             If Not allEmptyFlag Then result = ExecuteUpdate()
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record viewStudentSummary_Subjec BeforeBuildUpdate

'Record viewStudentSummary_Subjec Event AfterExecuteUpdate. Action Custom Code @59-73254650
    ' -------------------------
	' ERA: also do the update for the Interim Progress Code and the Final Progress Code
    ' INTERIM code first then FINAL 
    ' NOTE: confirmed with Jenny Ward that almost always only 'N', 'S', and 'J' INTERIM and FINAL Progress codes are used, although code does save other types

        Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
        Dim tmpUsername As String

        If (DBUtility.UserId.ToString() = "") Then
            tmpUsername = "'" & Left(DBUtility.UserId.ToString(), 8) & "'"
        Else
            tmpUsername = NewDao.ToSql(DBUtility.UserId.ToString(), FieldType._Text, True)
        End If

        Dim SqlupdateProj As String = ""
        SqlupdateProj += "update STUD_SUB_INTERIM "
        SqlupdateProj += " set INTERIM_PROGRESS_CODE=" & NewDao.ToSql(item.INTERIM_PROGRESS_CODE.GetFormattedValue(""), FieldType._Text) & " "
        SqlupdateProj += " , LAST_ALTERED_BY=" + tmpUsername + " , LAST_ALTERED_DATE=getdate() "
        SqlupdateProj += " where STUDENT_ID=" + NewDao.ToSql(Urlstudent_id.GetFormattedValue(""), FieldType._Float) + " and ENROLMENT_YEAR=" + NewDao.ToSql(Urlenrolment_year.GetFormattedValue(""), FieldType._Float) + " and SUBJECT_ID=" + NewDao.ToSql(UrlSUBJECT_ID.GetFormattedValue(""), FieldType._Integer) + " "

        NewDao.RunSql(SqlupdateProj)

        SqlupdateProj = "update STUD_SUBJ_FINAL "
        SqlupdateProj += " set FINAL_PROGRESS_CODE=" & NewDao.ToSql(item.FINAL_PROGRESS_CODE.GetFormattedValue(""), FieldType._Text) & " "
        SqlupdateProj += " , LAST_ALTERED_BY=" + tmpUsername + " , LAST_ALTERED_DATE=getdate() "
        SqlupdateProj += " where STUDENT_ID=" + NewDao.ToSql(Urlstudent_id.GetFormattedValue(""), FieldType._Float) + " and ENROLMENT_YEAR=" + NewDao.ToSql(Urlenrolment_year.GetFormattedValue(""), FieldType._Float) + " and SUBJECT_ID=" + NewDao.ToSql(UrlSUBJECT_ID.GetFormattedValue(""), FieldType._Integer) + " "

        NewDao.RunSql(SqlupdateProj)

    ' -------------------------
'End Record viewStudentSummary_Subjec Event AfterExecuteUpdate. Action Custom Code

'Record viewStudentSummary_Subjec AfterExecuteUpdate @4-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record viewStudentSummary_Subjec AfterExecuteUpdate

'Record viewStudentSummary_Subjec Data Provider Class GetResultSet Method @4-F416E391

    Public Sub FillItem(ByVal item As viewStudentSummary_SubjecItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record viewStudentSummary_Subjec Data Provider Class GetResultSet Method

'Record viewStudentSummary_Subjec BeforeBuildSelect @4-76FEBD0B
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("student_id312",Urlstudent_id, "","student_id",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("enrolment_year313",Urlenrolment_year, "","enrolment_year",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("SUBJECT_ID314",UrlSUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record viewStudentSummary_Subjec BeforeBuildSelect

'Record viewStudentSummary_Subjec BeforeExecuteSelect @4-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record viewStudentSummary_Subjec BeforeExecuteSelect

'Record viewStudentSummary_Subjec AfterExecuteSelect @4-A4F35F8A
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.student_id.SetValue(dr(i)("student_id"),"")
            item.enrolment_year.SetValue(dr(i)("enrolment_year"),"")
            item.SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
            item.SUBJECT_TITLE.SetValue(dr(i)("SUBJECT_TITLE"),"")
            item.SEMESTER.SetValue(dr(i)("SEMESTER"),"")
            item.COURSE_DISTRIBUTION.SetValue(dr(i)("COURSE_DISTRIBUTION"),"")
            item.SUBJ_ENROL_STATUS.SetValue(dr(i)("SUBJ_ENROL_STATUS"),"")
            item.enrolment_date.SetValue(dr(i)("enrolment_date"),Select_.DateFormat)
            item.withdrawal_date.SetValue(dr(i)("withdrawal_date"),Select_.DateFormat)
            item.WITHDRAWAL_REASON_ID.SetValue(dr(i)("WITHDRAWAL_REASON_ID"),"")
            item.NUM_ASSMT_SUBMISSIONS.SetValue(dr(i)("NUM_ASSMT_SUBMISSIONS"),"")
            item.STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
            item.FINAL_PROGRESS_CODE.SetValue(dr(i)("FINAL_PROGRESS_CODE"),"")
            item.VBOS_REGISTERED.SetValue(dr(i)("VBOS_REGISTERED"),Select_.BoolFormat)
            item.APPEARS_ON_VASS.SetValue(dr(i)("APPEARS_ON_VASS"),Select_.BoolFormat)
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.hidden_STUDENT_ID.SetValue(dr(i)("student_id"),"")
            item.hidden_ENROLMENT_YEAR.SetValue(dr(i)("enrolment_year"),"")
            item.hidden_SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
            item.hidden_LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.hidden_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.lblSTAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
            item.INTERIM_PROGRESS_CODE.SetValue(dr(i)("INTERIM_PROGRESS_CODE"),"")
            item.EXTENSION_OF_VCE_UNIT.SetValue(dr(i)("EXTENSION_OF_VCE_UNIT"),Select_.BoolFormat)
            item.NON_SUBMITTING_FLAG.SetValue(dr(i)("NON_SUBMITTING_FLAG"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record viewStudentSummary_Subjec AfterExecuteSelect

'ListBox SEMESTER AfterExecuteSelect @12-3EC507E8
        
item.SEMESTERItems.Add("1","1")
item.SEMESTERItems.Add("2","2")
item.SEMESTERItems.Add("B","Both")
'End ListBox SEMESTER AfterExecuteSelect

'ListBox SUBJ_ENROL_STATUS AfterExecuteSelect @14-D988A690
        
item.SUBJ_ENROL_STATUSItems.Add("C","Current")
item.SUBJ_ENROL_STATUSItems.Add("W","Withdrawn")
item.SUBJ_ENROL_STATUSItems.Add("F","Finished")
item.SUBJ_ENROL_STATUSItems.Add("E","Extended")
item.SUBJ_ENROL_STATUSItems.Add("D","Defaulting")
item.SUBJ_ENROL_STATUSItems.Add("P","Pending")
item.SUBJ_ENROL_STATUSItems.Add("T","Temporary")
'End ListBox SUBJ_ENROL_STATUS AfterExecuteSelect

'ListBox WITHDRAWAL_REASON_ID Initialize Data Source @17-E00282E8
        WITHDRAWAL_REASON_IDDataCommand.Dao._optimized = False
        Dim WITHDRAWAL_REASON_IDtableIndex As Integer = 0
        WITHDRAWAL_REASON_IDDataCommand.OrderBy = "WITHDRAWAL_REASON"
        WITHDRAWAL_REASON_IDDataCommand.Parameters.Clear()
        WITHDRAWAL_REASON_IDDataCommand.Parameters.Add("expr223","(STATUS=1)")
'End ListBox WITHDRAWAL_REASON_ID Initialize Data Source

'ListBox WITHDRAWAL_REASON_ID BeforeExecuteSelect @17-AAF6FC16
        Try
            ListBoxSource=WITHDRAWAL_REASON_IDDataCommand.Execute().Tables(WITHDRAWAL_REASON_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox WITHDRAWAL_REASON_ID BeforeExecuteSelect

'ListBox WITHDRAWAL_REASON_ID AfterExecuteSelect @17-4F98C69C
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New IntegerField("", ListBoxSource(j)("WITHDRAWAL_REASON_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("WITHDRAWAL_REASON")
            item.WITHDRAWAL_REASON_IDItems.Add(Key, Val)
        Next
'End ListBox WITHDRAWAL_REASON_ID AfterExecuteSelect

'ListBox STAFF_ID Initialize Data Source @19-FEBA430C
        STAFF_IDDataCommand.Dao._optimized = False
        Dim STAFF_IDtableIndex As Integer = 0
        STAFF_IDDataCommand.OrderBy = "STAFF_ID"
        STAFF_IDDataCommand.Parameters.Clear()
        STAFF_IDDataCommand.Parameters.Add("expr178","(STATUS=1)")
        STAFF_IDDataCommand.Parameters.Add("expr179","(TEACHER_FLAG=1)")
'End ListBox STAFF_ID Initialize Data Source

'ListBox STAFF_ID BeforeExecuteSelect @19-0F683DF6
        Try
            ListBoxSource=STAFF_IDDataCommand.Execute().Tables(STAFF_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox STAFF_ID BeforeExecuteSelect

'ListBox STAFF_ID AfterExecuteSelect @19-A4BD0C34
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("STAFF_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("STAFF_ID")
            item.STAFF_IDItems.Add(Key, Val)
        Next
'End ListBox STAFF_ID AfterExecuteSelect

'ListBox FINAL_PROGRESS_CODE Initialize Data Source @21-F43E2FCB
        FINAL_PROGRESS_CODEDataCommand.Dao._optimized = False
        Dim FINAL_PROGRESS_CODEtableIndex As Integer = 0
        FINAL_PROGRESS_CODEDataCommand.OrderBy = ""
        FINAL_PROGRESS_CODEDataCommand.Parameters.Clear()
'End ListBox FINAL_PROGRESS_CODE Initialize Data Source

'ListBox FINAL_PROGRESS_CODE BeforeExecuteSelect @21-C41A9877
        Try
            ListBoxSource=FINAL_PROGRESS_CODEDataCommand.Execute().Tables(FINAL_PROGRESS_CODEtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox FINAL_PROGRESS_CODE BeforeExecuteSelect

'ListBox FINAL_PROGRESS_CODE AfterExecuteSelect @21-904B4B53
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("PROGRESS_CODE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("description")
            item.FINAL_PROGRESS_CODEItems.Add(Key, Val)
        Next
'End ListBox FINAL_PROGRESS_CODE AfterExecuteSelect

'ListBox VBOS_REGISTERED AfterExecuteSelect @22-23C73FBE
        
item.VBOS_REGISTEREDItems.Add("Yes","Yes")
item.VBOS_REGISTEREDItems.Add("No","No")
'End ListBox VBOS_REGISTERED AfterExecuteSelect

'ListBox APPEARS_ON_VASS AfterExecuteSelect @23-23D9B7CF
        
item.APPEARS_ON_VASSItems.Add("Yes","Yes")
item.APPEARS_ON_VASSItems.Add("No","No")
'End ListBox APPEARS_ON_VASS AfterExecuteSelect

'ListBox INTERIM_PROGRESS_CODE Initialize Data Source @20-82B21FA0
        INTERIM_PROGRESS_CODEDataCommand.Dao._optimized = False
        Dim INTERIM_PROGRESS_CODEtableIndex As Integer = 0
        INTERIM_PROGRESS_CODEDataCommand.OrderBy = "PROGRESS_CODE"
        INTERIM_PROGRESS_CODEDataCommand.Parameters.Clear()
        INTERIM_PROGRESS_CODEDataCommand.Parameters.Add("expr31","(STATUS=1)")
'End ListBox INTERIM_PROGRESS_CODE Initialize Data Source

'ListBox INTERIM_PROGRESS_CODE BeforeExecuteSelect @20-1504F691
        Try
            ListBoxSource=INTERIM_PROGRESS_CODEDataCommand.Execute().Tables(INTERIM_PROGRESS_CODEtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox INTERIM_PROGRESS_CODE BeforeExecuteSelect

'ListBox INTERIM_PROGRESS_CODE AfterExecuteSelect @20-9E52971A
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("PROGRESS_CODE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("description")
            item.INTERIM_PROGRESS_CODEItems.Add(Key, Val)
        Next
'End ListBox INTERIM_PROGRESS_CODE AfterExecuteSelect

'ListBox EXTENSION_OF_VCE_UNIT AfterExecuteSelect @24-52383E7B
        
item.EXTENSION_OF_VCE_UNITItems.Add("Yes","Yes")
item.EXTENSION_OF_VCE_UNITItems.Add("No","No")
'End ListBox EXTENSION_OF_VCE_UNIT AfterExecuteSelect

'ListBox NON_SUBMITTING_FLAG AfterExecuteSelect @267-22731F94
        
item.NON_SUBMITTING_FLAGItems.Add("1","Yes (NSUBMIT)")
item.NON_SUBMITTING_FLAGItems.Add("0","No")
'End ListBox NON_SUBMITTING_FLAG AfterExecuteSelect

'Record viewStudentSummary_Subjec AfterExecuteSelect tail @4-E31F8E2A
    End Sub
'End Record viewStudentSummary_Subjec AfterExecuteSelect tail

'Record viewStudentSummary_Subjec Data Provider Class @4-A61BA892
End Class

'End Record viewStudentSummary_Subjec Data Provider Class

'Grid BOOK_DESPATCH Item Class @61-EA1F95FA
Public Class BOOK_DESPATCHItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public BOOK_ID As IntegerField
    Public DESPATCH_STATUS As TextField
    Public DESPATCH_STATUSItems As ItemCollection
    Public DESPATCH_DATE As DateField
    Public lblModule As TextField
    Public Sub New()
    BOOK_ID = New IntegerField("", Nothing)
    DESPATCH_STATUS = New TextField("", Nothing)
    DESPATCH_STATUSItems = New ItemCollection()
    DESPATCH_DATE = New DateField("dd\/MM\/yy", Nothing)
    lblModule = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "BOOK_ID"
                    Return Me.BOOK_ID
                Case "DESPATCH_STATUS"
                    Return Me.DESPATCH_STATUS
                Case "DESPATCH_DATE"
                    Return Me.DESPATCH_DATE
                Case "lblModule"
                    Return Me.lblModule
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "BOOK_ID"
                    Me.BOOK_ID = CType(Value,IntegerField)
                Case "DESPATCH_STATUS"
                    Me.DESPATCH_STATUS = CType(Value,TextField)
                Case "DESPATCH_DATE"
                    Me.DESPATCH_DATE = CType(Value,DateField)
                Case "lblModule"
                    Me.lblModule = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid BOOK_DESPATCH Item Class

'Grid BOOK_DESPATCH Data Provider Class Header @61-214B3430
Public Class BOOK_DESPATCHDataProvider
Inherits GridDataProviderBase
'End Grid BOOK_DESPATCH Data Provider Class Header

'Grid BOOK_DESPATCH Data Provider Class Variables @61-AB6260A8

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {"BOOK_ID"}
    Private SortFieldsNamesDesc As String() = New string() {"BOOK_ID"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 80
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As FloatParameter
    Public UrlENROLMENT_YEAR  As FloatParameter
    Public UrlSUBJECT_ID  As IntegerParameter
'End Grid BOOK_DESPATCH Data Provider Class Variables

'Grid BOOK_DESPATCH Data Provider Class GetResultSet Method @61-EDC56E01

    Public Sub New()
        Select_=new SqlCommand("select TOP {SqlParam_endRecord} bd.*, sub.default_semester" & vbCrLf & _
          "		, (case when (sub.sub_school='P-6' and sub.default_semester ='1') then char(64+bd.book_i" & _
          "d)" & vbCrLf & _
          "			when (sub.sub_school='P-6' and sub.default_semester ='2') then char(64+bd.book_id)" & vbCrLf & _
          "			when (sub.sub_school='7-8' and sub.default_semester ='1') then char(64+bd.book_id)" & vbCrLf & _
          "			when (sub.sub_school='7-8' and sub.default_semester ='2') then char(68+bd.book_id)" & vbCrLf & _
          "			when (sub.sub_school='9-10' and sub.default_semester ='1') then char(64+bd.book_id)" & vbCrLf & _
          "			when (sub.sub_school='9-10' and sub.default_semester ='2') then char(68+bd.book_id)" & vbCrLf & _
          "			else ''" & vbCrLf & _
          "			end ) as module_display" & vbCrLf & _
          "from book_despatch bd, subject sub, student_subject ss" & vbCrLf & _
          "WHERE bd.subject_id = sub.subject_id" & vbCrLf & _
          "and bd.SUBJECT_ID = ss.SUBJECT_ID and bd.ENROLMENT_YEAR = ss.ENROLMENT_YEAR and bd.STUDENT" & _
          "_ID = ss.STUDENT_ID" & vbCrLf & _
          "AND bd.STUDENT_ID = {STUDENT_ID}" & vbCrLf & _
          "AND bd.ENROLMENT_YEAR = {ENROLMENT_YEAR}" & vbCrLf & _
          "AND bd.SUBJECT_ID = {SUBJECT_ID}  {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (select bd.*, sub.default_semester" & vbCrLf & _
          "		, (case when (sub.sub_school='P-6' and sub.default_semester ='1') then char(64+bd.book_i" & _
          "d)" & vbCrLf & _
          "			when (sub.sub_school='P-6' and sub.default_semester ='2') then char(64+bd.book_id)" & vbCrLf & _
          "			when (sub.sub_school='7-8' and sub.default_semester ='1') then char(64+bd.book_id)" & vbCrLf & _
          "			when (sub.sub_school='7-8' and sub.default_semester ='2') then char(68+bd.book_id)" & vbCrLf & _
          "			when (sub.sub_school='9-10' and sub.default_semester ='1') then char(64+bd.book_id)" & vbCrLf & _
          "			when (sub.sub_school='9-10' and sub.default_semester ='2') then char(68+bd.book_id)" & vbCrLf & _
          "			else ''" & vbCrLf & _
          "			end ) as module_display" & vbCrLf & _
          "from book_despatch bd, subject sub, student_subject ss" & vbCrLf & _
          "WHERE bd.subject_id = sub.subject_id" & vbCrLf & _
          "and bd.SUBJECT_ID = ss.SUBJECT_ID and bd.ENROLMENT_YEAR = ss.ENROLMENT_YEAR and bd.STUDENT" & _
          "_ID = ss.STUDENT_ID" & vbCrLf & _
          "AND bd.STUDENT_ID = {STUDENT_ID}" & vbCrLf & _
          "AND bd.ENROLMENT_YEAR = {ENROLMENT_YEAR}" & vbCrLf & _
          "AND bd.SUBJECT_ID = {SUBJECT_ID}) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid BOOK_DESPATCH Data Provider Class GetResultSet Method

'Grid BOOK_DESPATCH Data Provider Class GetResultSet Method @61-15716396
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As BOOK_DESPATCHItem()
'End Grid BOOK_DESPATCH Data Provider Class GetResultSet Method

'Before build Select @61-13B5F457
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("STUDENT_ID",UrlSTUDENT_ID, "")
        CType(Select_,SqlCommand).AddParameter("ENROLMENT_YEAR",UrlENROLMENT_YEAR, "")
        CType(Select_,SqlCommand).AddParameter("SUBJECT_ID",UrlSUBJECT_ID, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @61-EC1B7F5F
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As BOOK_DESPATCHItem
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

'After execute Select @61-215C1084
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New BOOK_DESPATCHItem(dr.Count-1) {}
'End After execute Select

'After execute Select @61-79D6687E
            Dim j As Integer
'End After execute Select

'ListBox DESPATCH_STATUS AfterExecuteSelect @65-58FC0C23
            Dim DESPATCH_STATUSItems As ItemCollection = New ItemCollection()
            
DESPATCH_STATUSItems.Add("S","Sent")
DESPATCH_STATUSItems.Add("N","Not Req'd")
DESPATCH_STATUSItems.Add("T","To be Sent")
'End ListBox DESPATCH_STATUS AfterExecuteSelect

'After execute Select tail @61-9CE28EAD
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as BOOK_DESPATCHItem = New BOOK_DESPATCHItem()
                item.BOOK_ID.SetValue(dr(i)("BOOK_ID"),"")
                item.DESPATCH_STATUS.SetValue(dr(i)("DESPATCH_STATUS"),"")
                item.DESPATCH_STATUSItems = CType(DESPATCH_STATUSItems.Clone(), ItemCollection)
                item.DESPATCH_DATE.SetValue(dr(i)("DESPATCH_DATE"),Select_.DateFormat)
                item.lblModule.SetValue(dr(i)("module_display"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @61-A61BA892
End Class
'End Grid Data Provider tail

'Record STUDENT_SUBJECT Item Class @128-B5F3F781
Public Class STUDENT_SUBJECTItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ENROLMENT_YEAR As FloatField
    Public SUBJECT_ID As IntegerField
    Public SEMESTER As TextField
    Public MODULE_LAST_ALTERED_BY As TextField
    Public MODULE_LAST_ALTERED_DATE As DateField
    Public MODULE_CUSTOMPROGRAM As IntegerField
    Public MODULE_CUSTOMPROGRAMItems As ItemCollection
    Public MODULE_NEXTMODULE As TextField
    Public MODULE_NEXTMODULEItems As ItemCollection
    Public MODULE_LAST_ALTERED_BY1 As TextField
    Public MODULE_LAST_ALTERED_DATE1 As DateField
    Public Sub New()
    ENROLMENT_YEAR = New FloatField("", Nothing)
    SUBJECT_ID = New IntegerField("", Nothing)
    SEMESTER = New TextField("", Nothing)
    MODULE_LAST_ALTERED_BY = New TextField("", Nothing)
    MODULE_LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    MODULE_CUSTOMPROGRAM = New IntegerField("", 0)
    MODULE_CUSTOMPROGRAMItems = New ItemCollection()
    MODULE_NEXTMODULE = New TextField("", "")
    MODULE_NEXTMODULEItems = New ItemCollection()
    MODULE_LAST_ALTERED_BY1 = New TextField("", Nothing)
    MODULE_LAST_ALTERED_DATE1 = New DateField("dd\/MM\/yyyy", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_SUBJECTItem
        Dim item As STUDENT_SUBJECTItem = New STUDENT_SUBJECTItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_YEAR")) Then
        item.ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUBJECT_ID")) Then
        item.SUBJECT_ID.SetValue(DBUtility.GetInitialValue("SUBJECT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SEMESTER")) Then
        item.SEMESTER.SetValue(DBUtility.GetInitialValue("SEMESTER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MODULE_LAST_ALTERED_BY")) Then
        item.MODULE_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("MODULE_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MODULE_LAST_ALTERED_DATE")) Then
        item.MODULE_LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("MODULE_LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MODULE_CUSTOMPROGRAM")) Then
        item.MODULE_CUSTOMPROGRAM.SetValue(DBUtility.GetInitialValue("MODULE_CUSTOMPROGRAM"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MODULE_NEXTMODULE")) Then
        item.MODULE_NEXTMODULE.SetValue(DBUtility.GetInitialValue("MODULE_NEXTMODULE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MODULE_LAST_ALTERED_BY1")) Then
        item.MODULE_LAST_ALTERED_BY1.SetValue(DBUtility.GetInitialValue("MODULE_LAST_ALTERED_BY1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MODULE_LAST_ALTERED_DATE1")) Then
        item.MODULE_LAST_ALTERED_DATE1.SetValue(DBUtility.GetInitialValue("MODULE_LAST_ALTERED_DATE1"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "ENROLMENT_YEAR"
                    Return ENROLMENT_YEAR
                Case "SUBJECT_ID"
                    Return SUBJECT_ID
                Case "SEMESTER"
                    Return SEMESTER
                Case "MODULE_LAST_ALTERED_BY"
                    Return MODULE_LAST_ALTERED_BY
                Case "MODULE_LAST_ALTERED_DATE"
                    Return MODULE_LAST_ALTERED_DATE
                Case "MODULE_CUSTOMPROGRAM"
                    Return MODULE_CUSTOMPROGRAM
                Case "MODULE_NEXTMODULE"
                    Return MODULE_NEXTMODULE
                Case "MODULE_LAST_ALTERED_BY1"
                    Return MODULE_LAST_ALTERED_BY1
                Case "MODULE_LAST_ALTERED_DATE1"
                    Return MODULE_LAST_ALTERED_DATE1
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ENROLMENT_YEAR"
                    ENROLMENT_YEAR = CType(value, FloatField)
                Case "SUBJECT_ID"
                    SUBJECT_ID = CType(value, IntegerField)
                Case "SEMESTER"
                    SEMESTER = CType(value, TextField)
                Case "MODULE_LAST_ALTERED_BY"
                    MODULE_LAST_ALTERED_BY = CType(value, TextField)
                Case "MODULE_LAST_ALTERED_DATE"
                    MODULE_LAST_ALTERED_DATE = CType(value, DateField)
                Case "MODULE_CUSTOMPROGRAM"
                    MODULE_CUSTOMPROGRAM = CType(value, IntegerField)
                Case "MODULE_NEXTMODULE"
                    MODULE_NEXTMODULE = CType(value, TextField)
                Case "MODULE_LAST_ALTERED_BY1"
                    MODULE_LAST_ALTERED_BY1 = CType(value, TextField)
                Case "MODULE_LAST_ALTERED_DATE1"
                    MODULE_LAST_ALTERED_DATE1 = CType(value, DateField)
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

    Public Sub Validate(ByVal provider As STUDENT_SUBJECTDataProvider)
'End Record STUDENT_SUBJECT Item Class

'ENROLMENT_YEAR validate @132-2458998A
        If IsNothing(ENROLMENT_YEAR.Value) OrElse ENROLMENT_YEAR.Value.ToString() ="" Then
            errors.Add("ENROLMENT_YEAR",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT YEAR"))
        End If
'End ENROLMENT_YEAR validate

'SUBJECT_ID validate @133-22E3C20E
        If IsNothing(SUBJECT_ID.Value) OrElse SUBJECT_ID.Value.ToString() ="" Then
            errors.Add("SUBJECT_ID",String.Format(Resources.strings.CCS_RequiredField,"SUBJECT ID"))
        End If
'End SUBJECT_ID validate

'SEMESTER validate @134-6C5B1447
        If IsNothing(SEMESTER.Value) OrElse SEMESTER.Value.ToString() ="" Then
            errors.Add("SEMESTER",String.Format(Resources.strings.CCS_RequiredField,"SEMESTER"))
        End If
'End SEMESTER validate

'RadioButton MODULE_CUSTOMPROGRAM Event OnValidate. Action Custom Code @154-73254650
    ' -------------------------
	'ERA: 18-Feb-2013|EA| check if the Custom is blank, but Next Module is selected
	    If (IsNothing(MODULE_CUSTOMPROGRAM.Value) And (MODULE_NEXTMODULE.Value <> "")) Then
	        errors.Add("MODULE_CUSTOMPROGRAM", "Must select Custom Program 'YES' or 'No' if a Next Module")
	    End If
    ' -------------------------
'End RadioButton MODULE_CUSTOMPROGRAM Event OnValidate. Action Custom Code

'ListBox MODULE_NEXTMODULE Event OnValidate. Action Custom Code @139-73254650
    ' -------------------------
	'ERA: 14-Feb-2013|EA| check if the cbCustom is 1 then the Next Module must be selected
        If ((MODULE_CUSTOMPROGRAM.Value = 1) And (MODULE_NEXTMODULE.Value = "")) Then
            errors.Add("MODULE_NEXTMODULE", "Must select a Next Module if Custom Program is YES")
        End If
    ' -------------------------
'End ListBox MODULE_NEXTMODULE Event OnValidate. Action Custom Code

'Record STUDENT_SUBJECT Item Class tail @128-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_SUBJECT Item Class tail

'Record STUDENT_SUBJECT Data Provider Class @128-3A586EE0
Public Class STUDENT_SUBJECTDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_SUBJECT Data Provider Class

'Record STUDENT_SUBJECT Data Provider Class Variables @128-6C604B96
    Protected MODULE_NEXTMODULEDataCommand As DataCommand=new SqlCommand("select module_code, module_label" & vbCrLf & _
          "from ref_module_codes" & vbCrLf & _
          "where status = 1{SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
    Public UrlENROLMENT_YEAR As FloatParameter
    Public UrlSUBJECT_ID As IntegerParameter
    Public UrlSTUDENT_ID As FloatParameter
    Public CtrlENROLMENT_YEAR As FloatParameter
    Public CtrlSUBJECT_ID As IntegerParameter
    Public Expr146 As TextParameter
    Public Expr147 As DateParameter
    Public CtrlMODULE_CUSTOMPROGRAM As IntegerParameter
    Public CtrlMODULE_NEXTMODULE As TextParameter
    Protected item As STUDENT_SUBJECTItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_SUBJECT Data Provider Class Variables

'Record STUDENT_SUBJECT Data Provider Class Constructor @128-0A8BB12C

    Public Sub New()
        Select_=new TableCommand("SELECT STUDENT_ID, ENROLMENT_YEAR, SUBJECT_ID, SEMESTER, MODULE_LAST_ALTERED_DATE, " & vbCrLf & _
          "MODULE_LAST_ALTERED_BY, MODULE_NEXTMODULE, " & vbCrLf & _
          "MODULE_CUSTOMPROGRAM " & vbCrLf & _
          "FROM STUDENT_SUBJECT {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID131","And","ENROLMENT_YEAR156","And","SUBJECT_ID157"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_SUBJECT Data Provider Class Constructor

'Record STUDENT_SUBJECT Data Provider Class LoadParams Method @128-B291BB05

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID) Or IsNothing(UrlENROLMENT_YEAR) Or IsNothing(UrlSUBJECT_ID))
    End Function
'End Record STUDENT_SUBJECT Data Provider Class LoadParams Method

'Record STUDENT_SUBJECT Data Provider Class CheckUnique Method @128-7BD11615

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_SUBJECTItem) As Boolean
        Return True
    End Function
'End Record STUDENT_SUBJECT Data Provider Class CheckUnique Method

'Record STUDENT_SUBJECT Data Provider Class PrepareUpdate Method @128-9CA783D6

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = Not(IsNothing(UrlSTUDENT_ID) Or IsNothing(item.ENROLMENT_YEAR) Or IsNothing(item.SUBJECT_ID))
'End Record STUDENT_SUBJECT Data Provider Class PrepareUpdate Method

'Record STUDENT_SUBJECT Data Provider Class PrepareUpdate Method tail @128-E31F8E2A
    End Sub
'End Record STUDENT_SUBJECT Data Provider Class PrepareUpdate Method tail

'Record STUDENT_SUBJECT Data Provider Class Update Method @128-31214B75

    Public Function UpdateItem(ByVal item As STUDENT_SUBJECTItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT_SUBJECT SET {Values}", New String(){"STUDENT_ID142","And","ENROLMENT_YEAR150","And","SUBJECT_ID151"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_SUBJECT Data Provider Class Update Method

'Record STUDENT_SUBJECT BeforeBuildUpdate @128-1AD11891
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID142",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ENROLMENT_YEAR150",item.ENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("SUBJECT_ID151",item.SUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        allEmptyFlag = (Expr146 Is Nothing) And allEmptyFlag
        If Not (Expr146 Is Nothing) Then
        If IsNothing(Expr146) Then
        valuesList = valuesList & "MODULE_LAST_ALTERED_BY=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "MODULE_LAST_ALTERED_BY=" & Update.Dao.ToSql(Expr146.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = (Expr147 Is Nothing) And allEmptyFlag
        If Not (Expr147 Is Nothing) Then
        If IsNothing(Expr147) Then
        valuesList = valuesList & "MODULE_LAST_ALTERED_DATE=" & Update.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        valuesList = valuesList & "MODULE_LAST_ALTERED_DATE=" & Update.Dao.ToSql(Expr147.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        End If
        allEmptyFlag = item.MODULE_CUSTOMPROGRAM.IsEmpty And allEmptyFlag
        If Not item.MODULE_CUSTOMPROGRAM.IsEmpty Then
        If IsNothing(item.MODULE_CUSTOMPROGRAM.Value) Then
        valuesList = valuesList & "MODULE_CUSTOMPROGRAM=" & Update.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        valuesList = valuesList & "MODULE_CUSTOMPROGRAM=" & Update.Dao.ToSql(item.MODULE_CUSTOMPROGRAM.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.MODULE_NEXTMODULE.IsEmpty And allEmptyFlag
        If Not item.MODULE_NEXTMODULE.IsEmpty Then
        If IsNothing(item.MODULE_NEXTMODULE.Value) Then
        valuesList = valuesList & "MODULE_NEXTMODULE=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "MODULE_NEXTMODULE=" & Update.Dao.ToSql(item.MODULE_NEXTMODULE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
		Update.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
             If Not allEmptyFlag Then result = ExecuteUpdate()
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record STUDENT_SUBJECT BeforeBuildUpdate

'Record STUDENT_SUBJECT AfterExecuteUpdate @128-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_SUBJECT AfterExecuteUpdate

'Record STUDENT_SUBJECT Data Provider Class GetResultSet Method @128-8F9CC11E

    Public Sub FillItem(ByVal item As STUDENT_SUBJECTItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_SUBJECT Data Provider Class GetResultSet Method

'Record STUDENT_SUBJECT BeforeBuildSelect @128-BAE46C2A
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID131",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("ENROLMENT_YEAR156",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("SUBJECT_ID157",UrlSUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_SUBJECT BeforeBuildSelect

'Record STUDENT_SUBJECT BeforeExecuteSelect @128-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_SUBJECT BeforeExecuteSelect

'Record STUDENT_SUBJECT AfterExecuteSelect @128-43EF7389
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.ENROLMENT_YEAR.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
            item.SEMESTER.SetValue(dr(i)("SEMESTER"),"")
            item.MODULE_LAST_ALTERED_BY.SetValue(dr(i)("MODULE_LAST_ALTERED_BY"),"")
            item.MODULE_LAST_ALTERED_DATE.SetValue(dr(i)("MODULE_LAST_ALTERED_DATE"),Select_.DateFormat)
            item.MODULE_CUSTOMPROGRAM.SetValue(dr(i)("MODULE_CUSTOMPROGRAM"),"")
            item.MODULE_NEXTMODULE.SetValue(dr(i)("MODULE_NEXTMODULE"),"")
            item.MODULE_LAST_ALTERED_BY1.SetValue(dr(i)("MODULE_LAST_ALTERED_BY"),"")
            item.MODULE_LAST_ALTERED_DATE1.SetValue(dr(i)("MODULE_LAST_ALTERED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record STUDENT_SUBJECT AfterExecuteSelect

'ListBox MODULE_CUSTOMPROGRAM AfterExecuteSelect @135-7D156222
        
item.MODULE_CUSTOMPROGRAMItems.Add("0","No")
item.MODULE_CUSTOMPROGRAMItems.Add("1","<strong>YES!<strong>")
'End ListBox MODULE_CUSTOMPROGRAM AfterExecuteSelect

'ListBox MODULE_NEXTMODULE Initialize Data Source @136-BFB0A491
        MODULE_NEXTMODULEDataCommand.Dao._optimized = False
        Dim MODULE_NEXTMODULEtableIndex As Integer = 0
        MODULE_NEXTMODULEDataCommand.OrderBy = "module_label"
        MODULE_NEXTMODULEDataCommand.Parameters.Clear()
'End ListBox MODULE_NEXTMODULE Initialize Data Source

'ListBox MODULE_NEXTMODULE BeforeExecuteSelect @136-DAAA5A4E
        Try
            ListBoxSource=MODULE_NEXTMODULEDataCommand.Execute().Tables(MODULE_NEXTMODULEtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox MODULE_NEXTMODULE BeforeExecuteSelect

'ListBox MODULE_NEXTMODULE AfterExecuteSelect @136-A68F9C9B
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("module_code"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("module_label")
            item.MODULE_NEXTMODULEItems.Add(Key, Val)
        Next
'End ListBox MODULE_NEXTMODULE AfterExecuteSelect

'Record STUDENT_SUBJECT AfterExecuteSelect tail @128-E31F8E2A
    End Sub
'End Record STUDENT_SUBJECT AfterExecuteSelect tail

'Record STUDENT_SUBJECT Data Provider Class @128-A61BA892
End Class

'End Record STUDENT_SUBJECT Data Provider Class

'EditableGrid EditableGrid1 Item Class @231-AA55210C
Public Class EditableGrid1Item
    Public errors As NameValueCollection = New NameValueCollection()
    Public RowId As Integer
    Private _deleteAllowed As Boolean = False
    Private _isNew As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public BOOK_ID As IntegerField
    Public DESPATCH_STATUS As TextField
    Public DESPATCH_STATUSItems As ItemCollection
    Public DESPATCH_DATE As DateField
    Public lblBookID As IntegerField
    Public module_display As TextField
    Public Sub New()
    BOOK_ID = New IntegerField("", Nothing)
    DESPATCH_STATUS = New TextField("", Nothing)
    DESPATCH_STATUSItems = New ItemCollection()
    DESPATCH_DATE = New DateField("dd\/MM\/yy", Nothing)
    lblBookID = New IntegerField("", Nothing)
    module_display = New TextField("", Nothing)
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
                Case "BOOK_ID"
                    Return Me.BOOK_ID
                Case "DESPATCH_STATUS"
                    Return Me.DESPATCH_STATUS
                Case "DESPATCH_DATE"
                    Return Me.DESPATCH_DATE
                Case "lblBookID"
                    Return Me.lblBookID
                Case "module_display"
                    Return Me.module_display
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_IDField"
                    Me.STUDENT_IDField = CType(Value,FloatField)
                Case "ENROLMENT_YEARField"
                    Me.ENROLMENT_YEARField = CType(Value,IntegerField)
                Case "SUBJECT_IDField"
                    Me.SUBJECT_IDField = CType(Value,IntegerField)
                Case "BOOK_ID"
                    Me.BOOK_ID = CType(Value,IntegerField)
                Case "DESPATCH_STATUS"
                    Me.DESPATCH_STATUS = CType(Value,TextField)
                Case "DESPATCH_DATE"
                    Me.DESPATCH_DATE = CType(Value,DateField)
                Case "lblBookID"
                    Me.lblBookID = CType(Value,IntegerField)
                Case "module_display"
                    Me.module_display = CType(Value,TextField)
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
            result = IsNothing(BOOK_ID.Value) And result
            result = IsNothing(DESPATCH_STATUS.Value) And result
            result = IsNothing(DESPATCH_DATE.Value) And result
            Return result
        End Get
    End Property

    Public IsDeleted As Boolean = False
    Public IsUpdated As Boolean = False
    Public STUDENT_IDField As FloatField = New FloatField()
    Public ENROLMENT_YEARField As IntegerField = New IntegerField()
    Public SUBJECT_IDField As IntegerField = New IntegerField()
    Public Function Validate(ByVal provider As EditableGrid1DataProvider) As Boolean
'End EditableGrid EditableGrid1 Item Class

'BOOK_ID validate @236-45DA18B8
        If IsNothing(BOOK_ID.Value) OrElse BOOK_ID.Value.ToString() ="" Then
            errors.Add("BOOK_ID",String.Format(Resources.strings.CCS_RequiredField,"BOOK ID"))
        End If
'End BOOK_ID validate

'EditableGrid EditableGrid1 Item Class tail @231-11D8DCF0
        Return errors.Count = 0
    End Function
    Public RawData As DataRow = Nothing
End Class
'End EditableGrid EditableGrid1 Item Class tail

'EditableGrid EditableGrid1 Data Provider Class Header @231-1EA4F0E2
Public Class EditableGrid1DataProvider
Inherits EditableGridDataProviderBase
'End EditableGrid EditableGrid1 Data Provider Class Header

'Grid EditableGrid1 Data Provider Class Variables @231-9A947FA3

    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {"BOOK_ID"}
    Private SortFieldsNamesDesc As String() = New string() {"BOOK_ID"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 30
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As FloatParameter
    Public UrlENROLMENT_YEAR  As FloatParameter
    Public UrlSUBJECT_ID  As IntegerParameter
    Public CtrlBOOK_ID  As IntegerParameter
    Public CtrlDESPATCH_STATUS  As TextParameter
    Public CtrlDESPATCH_DATE  As DateParameter
'End Grid EditableGrid1 Data Provider Class Variables

'EditableGrid EditableGrid1 Data Provider Class Constructor @231-9F1A1D54

    Public Sub New()
        Select_=new SqlCommand("select TOP {SqlParam_endRecord} bd.*, sub.default_semester, ss.semester" & vbCrLf & _
          "		, (case when (sub.sub_school='P-6') then char(64+bd.book_id)" & vbCrLf & _
          "			when (sub.sub_school='P-6') then char(64+bd.book_id)" & vbCrLf & _
          "			when (sub.sub_school='7-8' and ss.semester ='1') then char(64+bd.book_id)" & vbCrLf & _
          "			when (sub.sub_school='7-8' and ss.SEMESTER ='2') then char(68+bd.book_id)" & vbCrLf & _
          "			when (sub.sub_school='9-10' and ss.SEMESTER ='1') then char(64+bd.book_id)" & vbCrLf & _
          "			when (sub.sub_school='9-10' and ss.SEMESTER ='2') then char(68+bd.book_id)" & vbCrLf & _
          "			else ''" & vbCrLf & _
          "			end ) as module_display" & vbCrLf & _
          "from book_despatch bd, subject sub, student_subject ss" & vbCrLf & _
          "WHERE bd.subject_id = sub.subject_id" & vbCrLf & _
          "and bd.SUBJECT_ID = ss.SUBJECT_ID and bd.ENROLMENT_YEAR = ss.ENROLMENT_YEAR and bd.STUDENT" & _
          "_ID = ss.STUDENT_ID" & vbCrLf & _
          "AND bd.STUDENT_ID = {STUDENT_ID}" & vbCrLf & _
          "AND bd.ENROLMENT_YEAR = {ENROLMENT_YEAR}" & vbCrLf & _
          "AND bd.SUBJECT_ID = {SUBJECT_ID} {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (select bd.*, sub.default_semester, ss.semester" & vbCrLf & _
          "		, (case when (sub.sub_school='P-6') then char(64+bd.book_id)" & vbCrLf & _
          "			when (sub.sub_school='P-6') then char(64+bd.book_id)" & vbCrLf & _
          "			when (sub.sub_school='7-8' and ss.semester ='1') then char(64+bd.book_id)" & vbCrLf & _
          "			when (sub.sub_school='7-8' and ss.SEMESTER ='2') then char(68+bd.book_id)" & vbCrLf & _
          "			when (sub.sub_school='9-10' and ss.SEMESTER ='1') then char(64+bd.book_id)" & vbCrLf & _
          "			when (sub.sub_school='9-10' and ss.SEMESTER ='2') then char(68+bd.book_id)" & vbCrLf & _
          "			else ''" & vbCrLf & _
          "			end ) as module_display" & vbCrLf & _
          "from book_despatch bd, subject sub, student_subject ss" & vbCrLf & _
          "WHERE bd.subject_id = sub.subject_id" & vbCrLf & _
          "and bd.SUBJECT_ID = ss.SUBJECT_ID and bd.ENROLMENT_YEAR = ss.ENROLMENT_YEAR and bd.STUDENT" & _
          "_ID = ss.STUDENT_ID" & vbCrLf & _
          "AND bd.STUDENT_ID = {STUDENT_ID}" & vbCrLf & _
          "AND bd.ENROLMENT_YEAR = {ENROLMENT_YEAR}" & vbCrLf & _
          "AND bd.SUBJECT_ID = {SUBJECT_ID}) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End EditableGrid EditableGrid1 Data Provider Class Constructor

'Record EditableGrid1 Data Provider Class CheckUnique Method @231-2BE65FEF

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As EditableGrid1Item) As Boolean
        Return True
    End Function
'End Record EditableGrid1 Data Provider Class CheckUnique Method

'EditableGrid EditableGrid1 Data Provider Class Update Method @231-CD90DBAF
    Protected Function UpdateItem(ByVal item As EditableGrid1Item) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        IsParametersPassed = Not(IsNothing(item.STUDENT_IDField) Or IsNothing(item.ENROLMENT_YEARField) Or IsNothing(item.SUBJECT_IDField) Or IsNothing(item.BOOK_ID))
        Dim Update As DataCommand=new TableCommand("UPDATE BOOK_DESPATCH SET DESPATCH_STATUS={DESPATCH_STATUS}, " & vbCrLf & _
          "DESPATCH_DATE={DESPATCH_DATE}", New String(){"STUDENT_ID253","And","ENROLMENT_YEAR254","And","SUBJECT_ID255","And","BOOK_ID256"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End EditableGrid EditableGrid1 Data Provider Class Update Method

'EditableGrid EditableGrid1 BeforeBuildUpdate @231-31680194
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID253",item.STUDENT_IDField, "","STUDENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ENROLMENT_YEAR254",item.ENROLMENT_YEARField, "","ENROLMENT_YEAR",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("SUBJECT_ID255",item.SUBJECT_IDField, "","SUBJECT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("BOOK_ID256",item.BOOK_ID, "","BOOK_ID",Condition.Equal,False)
        If item.DESPATCH_STATUS.Value Is Nothing Then
            Update.SqlQuery.Replace("{DESPATCH_STATUS}",Update.Dao.ToSql(Nothing,FieldType._Text))
        Else
            Update.SqlQuery.Replace("{DESPATCH_STATUS}",Update.Dao.ToSql(item.DESPATCH_STATUS.GetFormattedValue(""),FieldType._Text))
        End If
        If item.DESPATCH_DATE.Value Is Nothing Then
            Update.SqlQuery.Replace("{DESPATCH_DATE}",Update.Dao.ToSql(Nothing,FieldType._Date))
        Else
            Update.SqlQuery.Replace("{DESPATCH_DATE}",Update.Dao.ToSql(item.DESPATCH_DATE.GetFormattedValue("yyyy-MM-dd HH\:mm\:ss"),FieldType._Date))
        End If
'End EditableGrid EditableGrid1 BeforeBuildUpdate

'EditableGrid EditableGrid1 Execute Update  @231-24B27D7E
        Update.OpType = OperationType.Update
        Dim result As Object = 0
        Dim E As Exception = Nothing
        If CmdExecution Then
            If Not IsParametersPassed Then
                item.errors.Add("DataProvider",Resources.strings.CCS_CustomOperationError_MissingParameters)
                Return 0
            End If
            Try
                result = Update.ExecuteNonQuery()
            Catch e_ As Exception
                item.errors.Add("DataProvider",e_.Source + ":" + e_.Message)
            Finally
'End EditableGrid EditableGrid1 Execute Update 

'EditableGrid EditableGrid1 AfterExecuteUpdate @231-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid EditableGrid1 AfterExecuteUpdate

'Grid EditableGrid1 Data Provider Class GetResultSet Method @231-A3F93E1D
    Public Sub Update(Items As ArrayList, ops As FormSupportedOperations)
        Dim i As Integer
        For i = 0 To Items.Count - 1
            Dim op As EditableGridOperation = EditableGridOperation.Insert
            Dim isProcessed As Boolean = False
            Dim item As EditableGrid1Item = CType(Items(i), EditableGrid1Item)
'End Grid EditableGrid1 Data Provider Class GetResultSet Method

'EditableGrid EditableGrid1 Data Provider Class Update @231-B4FF46D4
            If Not item.IsUpdated Then
                If Not(item.IsEmptyItem) And ops.AllowUpdate And Not(isProcessed) Then
                    UpdateItem(item)
                    op = EditableGridOperation.Update
                End If
'End EditableGrid EditableGrid1 Data Provider Class Update

'EditableGrid EditableGrid1 Data Provider Class AfterUpdate @231-6CCB76B9
                If item.errors.Count = 0 Then item.IsUpdated = True
                OnItemUpdated(New ItemUpdatedEventArgs(op, item))
            End If
        Next i
    End Sub
'End EditableGrid EditableGrid1 Data Provider Class AfterUpdate

'EditableGrid EditableGrid1 Data Provider Class GetResultSet Method @231-741AC175
    Public Function GetResultSet(ByRef _pagesCount As Integer, ops As FormSupportedOperations) As EditableGrid1Item()
'End EditableGrid EditableGrid1 Data Provider Class GetResultSet Method

'Before build Select @231-8DF5D887
        _pagesCount = 0
        Dim E as Exception = Nothing
        Dim j As Integer
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("STUDENT_ID",UrlSTUDENT_ID, "")
        CType(Select_,SqlCommand).AddParameter("ENROLMENT_YEAR",UrlENROLMENT_YEAR, "")
        CType(Select_,SqlCommand).AddParameter("SUBJECT_ID",UrlSUBJECT_ID, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy = SortFieldsNames(CInt(SortField)).Trim
        Else
            Select_.OrderBy = SortFieldsNamesDesc(CInt(SortField)).Trim
        End If
    Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @231-939614DD
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

'After execute Select @231-F71D72AB
                If Not IsNothing(E) Then Throw E
            End Try
            dr = ds.Tables(tableIndex).Rows
            rowCount = dr.Count
        End If
        Dim result(rowCount - 1) As EditableGrid1Item
'End After execute Select

'ListBox DESPATCH_STATUS AfterExecuteSelect @238-58FC0C23
    Dim DESPATCH_STATUSItems As ItemCollection = New ItemCollection()
    
DESPATCH_STATUSItems.Add("S","Sent")
DESPATCH_STATUSItems.Add("N","Not Req'd")
DESPATCH_STATUSItems.Add("T","To be Sent")
'End ListBox DESPATCH_STATUS AfterExecuteSelect

'After execute Select tail @231-156E6E48
        Dim i as Integer
        For i = 0 To rowCount - 1
            Dim item as EditableGrid1Item = New EditableGrid1Item()
            item.BOOK_ID.SetValue(dr(i)("BOOK_ID"),"")
            item.DESPATCH_STATUS.SetValue(dr(i)("DESPATCH_STATUS"),"")
            item.DESPATCH_STATUSItems = CType(DESPATCH_STATUSItems.Clone(), ItemCollection)
            item.DESPATCH_DATE.SetValue(dr(i)("DESPATCH_DATE"),Select_.DateFormat)
            item.lblBookID.SetValue(dr(i)("BOOK_ID"),"")
            item.module_display.SetValue(dr(i)("module_display"),"")
            item.STUDENT_IDField.SetValue(dr(i)("STUDENT_ID"),"")
            item.ENROLMENT_YEARField.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.SUBJECT_IDField.SetValue(dr(i)("SUBJECT_ID"),"")
            item.RawData = dr(i)
            result(i)=item
        Next i
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @231-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

