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

Namespace DECV_PROD2007.Student_Subject_maintain 'Namespace @1-A87903AA

'Page Data Class @1-7BD909E8
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public lblModified As TextField
    Public Sub New()
        lblModified = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.lblModified.SetValue(DBUtility.GetInitialValue("lblModified"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "lblModified"
                    Return lblModified
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblModified"
                    lblModified = CType(value, TextField)
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

'Record AddSubject Item Class @28-639C982B
Public Class AddSubjectItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public subject_id As IntegerField
    Public semester As TextField
    Public semesterItems As ItemCollection
    Public subj_enrol_date As DateField
    Public hidden_STUDENT_ID As TextField
    Public hidden_ENROLMENT_YEAR As TextField
    Public lblMessage As TextField
    Public ListBox_SubjectYearLevel As TextField
    Public ListBox_SubjectYearLevelItems As ItemCollection
    Public ListBox_Subject As TextField
    Public ListBox_SubjectItems As ItemCollection
    Public course_distribution As TextField
    Public Hidden_CustomProgram As IntegerField
    Public Sub New()
    subject_id = New IntegerField("", Nothing)
    semester = New TextField("", Nothing)
    semesterItems = New ItemCollection()
    subj_enrol_date = New DateField("dd\/MM\/yyyy", now())
    hidden_STUDENT_ID = New TextField("", Nothing)
    hidden_ENROLMENT_YEAR = New TextField("", Nothing)
    lblMessage = New TextField("", Nothing)
    ListBox_SubjectYearLevel = New TextField("", Nothing)
    ListBox_SubjectYearLevelItems = New ItemCollection()
    ListBox_Subject = New TextField("", Nothing)
    ListBox_SubjectItems = New ItemCollection()
    course_distribution = New TextField("", "B")
    Hidden_CustomProgram = New IntegerField("", 0)
    End Sub

    Public Shared Function CreateFromHttpRequest() As AddSubjectItem
        Dim item As AddSubjectItem = New AddSubjectItem()
        If Not IsNothing(DBUtility.GetInitialValue("subject_id")) Then
        item.subject_id.SetValue(DBUtility.GetInitialValue("subject_id"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("semester")) Then
        item.semester.SetValue(DBUtility.GetInitialValue("semester"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("subj_enrol_date")) Then
        item.subj_enrol_date.SetValue(DBUtility.GetInitialValue("subj_enrol_date"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ButtonAdd")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_STUDENT_ID")) Then
        item.hidden_STUDENT_ID.SetValue(DBUtility.GetInitialValue("hidden_STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_ENROLMENT_YEAR")) Then
        item.hidden_ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("hidden_ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblMessage")) Then
        item.lblMessage.SetValue(DBUtility.GetInitialValue("lblMessage"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ListBox_SubjectYearLevel")) Then
        item.ListBox_SubjectYearLevel.SetValue(DBUtility.GetInitialValue("ListBox_SubjectYearLevel"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ListBox_Subject")) Then
        item.ListBox_Subject.SetValue(DBUtility.GetInitialValue("ListBox_Subject"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("course_distribution")) Then
        item.course_distribution.SetValue(DBUtility.GetInitialValue("course_distribution"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_CustomProgram")) Then
        item.Hidden_CustomProgram.SetValue(DBUtility.GetInitialValue("Hidden_CustomProgram"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "subject_id"
                    Return subject_id
                Case "semester"
                    Return semester
                Case "subj_enrol_date"
                    Return subj_enrol_date
                Case "hidden_STUDENT_ID"
                    Return hidden_STUDENT_ID
                Case "hidden_ENROLMENT_YEAR"
                    Return hidden_ENROLMENT_YEAR
                Case "lblMessage"
                    Return lblMessage
                Case "ListBox_SubjectYearLevel"
                    Return ListBox_SubjectYearLevel
                Case "ListBox_Subject"
                    Return ListBox_Subject
                Case "course_distribution"
                    Return course_distribution
                Case "Hidden_CustomProgram"
                    Return Hidden_CustomProgram
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "subject_id"
                    subject_id = CType(value, IntegerField)
                Case "semester"
                    semester = CType(value, TextField)
                Case "subj_enrol_date"
                    subj_enrol_date = CType(value, DateField)
                Case "hidden_STUDENT_ID"
                    hidden_STUDENT_ID = CType(value, TextField)
                Case "hidden_ENROLMENT_YEAR"
                    hidden_ENROLMENT_YEAR = CType(value, TextField)
                Case "lblMessage"
                    lblMessage = CType(value, TextField)
                Case "ListBox_SubjectYearLevel"
                    ListBox_SubjectYearLevel = CType(value, TextField)
                Case "ListBox_Subject"
                    ListBox_Subject = CType(value, TextField)
                Case "course_distribution"
                    course_distribution = CType(value, TextField)
                Case "Hidden_CustomProgram"
                    Hidden_CustomProgram = CType(value, IntegerField)
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

    Public Sub Validate(ByVal provider As AddSubjectDataProvider)
'End Record AddSubject Item Class

'subject_id validate @32-B26F25F1
        If IsNothing(subject_id.Value) OrElse subject_id.Value.ToString() ="" Then
            errors.Add("subject_id",String.Format(Resources.strings.CCS_RequiredField,"Subject ID"))
        End If
'End subject_id validate

'semester validate @33-340F9BA3
        If IsNothing(semester.Value) OrElse semester.Value.ToString() ="" Then
            errors.Add("semester",String.Format(Resources.strings.CCS_RequiredField,"Semester"))
        End If
'End semester validate

'subj_enrol_date validate @29-6650381D
        If IsNothing(subj_enrol_date.Value) OrElse subj_enrol_date.Value.ToString() ="" Then
            errors.Add("subj_enrol_date",String.Format(Resources.strings.CCS_RequiredField,"Enrolment Date"))
        End If
'End subj_enrol_date validate

'hidden_STUDENT_ID validate @36-3C803710
        If IsNothing(hidden_STUDENT_ID.Value) OrElse hidden_STUDENT_ID.Value.ToString() ="" Then
            errors.Add("hidden_STUDENT_ID",String.Format(Resources.strings.CCS_RequiredField,"Student ID"))
        End If
'End hidden_STUDENT_ID validate

'hidden_ENROLMENT_YEAR validate @37-5A8C789A
        If IsNothing(hidden_ENROLMENT_YEAR.Value) OrElse hidden_ENROLMENT_YEAR.Value.ToString() ="" Then
            errors.Add("hidden_ENROLMENT_YEAR",String.Format(Resources.strings.CCS_RequiredField,"Enrolment Year"))
        End If
'End hidden_ENROLMENT_YEAR validate

'course_distribution validate @31-5C0D970B
        If IsNothing(course_distribution.Value) OrElse course_distribution.Value.ToString() ="" Then
            errors.Add("course_distribution",String.Format(Resources.strings.CCS_RequiredField,"Course Distribution"))
        End If
'End course_distribution validate

'Record AddSubject Event OnValidate. Action Custom Code @34-73254650
    ' -------------------------
  ' -------------------------
    ' ERA: do form validation at once for checking if:
	'	1) Selected Subject exists and is active
	'	2) This combination of student/subject DOES NOT exist
	'	3) the selected Course Distro is valid for this subject
	'	4) check the subjects match the subschool (primary subject id <= 100 etc)
	'		1-Nov-2012|EA| adjust 'in-sub-school' checking per Launchpad and DL
	' (based on v. similar code in Despatch_AssignmentReceipt.[Form].OnValidate)
	' 14-Mar-2013|EA| changes requested per Custom Learning Program:
	'	1) remove validation of subject/year level subschool check
	'	2) added 'bulk No CLP' update like SS Teacher
	'	3) remove valid course distro as no longer required

	
	
	' only check these if the above fields are OK
	if (errors.Count =0) Then

		Dim intStaffCount As Int64 = 0
		Dim intStudentSubjectCount As Int64 = 0
		Dim intCourseDistroCount As Int64 = 0
		Dim intYearLevel As Int64 = -1

		'1)  Selected Subject exists and is active	
		intStaffCount = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("select count(*) from SUBJECT where STATUS=1 AND SUBJECT_ID=" & subject_id.Value.ToString() ))).Value, Int64)
		if (intStaffCount = 0) then
			errors.Add("Form Validation", "Subject ID "& subject_id.getformattedvalue() &" : Incorrect Subject ID or Subject is not active ")
		end if
	
		'2) check student/subject combo NOT exists 
		intStudentSubjectCount = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM student_subject WHERE ENROLMENT_YEAR= " & hidden_ENROLMENT_YEAR.value.ToString() &" AND STUDENT_ID= " & hidden_STUDENT_ID.value.ToString() &" AND SUBJECT_ID= " & subject_id.value.ToString() &" "))).Value, Int64)
		if (intStudentSubjectCount <>0) then
			errors.Add("Form Validation", "Subject ID "& subject_id.getformattedvalue() &" has already been enrolled in by this Student ")
		end if

		'3) valid course distro
		'ERA: 28-Nov-2013|EA| remove this check as all will be 'Book' and we don't really care anyway
		'intCourseDistroCount = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM SUBJECT WHERE SUBJECT_ID= " & subject_id.value.ToString() & " AND VALID_COURSE_DISTRIBUTION like ('%"& course_distribution.value.ToString() & "%')"))).Value, Int64)
		'if (intCourseDistroCount = 0) then
		'	errors.Add("Form Validation", "Subject ID "& subject_id.getformattedvalue() &" : has invalid Course Distribution ")
		'end if

		'4) check subjects far outside yearlevel or sub-school
		' 24-Feb-2011|EA|  added per Matt Aumann's request, as fast typists may process partial subjects, and will be useful when data entry people who don't know the subject codes are doing this.
		'1-Nov-2012|EA| per Matt, if subject is Launchpad (921,922,923) or Discovery Learning (931,932,933) then disable subject_id check 
		'	so Years 0-6 can get Subject ID > 100. Ie, first check for subject_id
		'14-Mar-2013|EA| remove this check as no longer needed
		'if (subject_id.Value < 900) then 
		'	intYearLevel = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT YEAR_LEVEL FROM STUDENT_ENROLMENT WHERE STUDENT_ID = " & hidden_STUDENT_ID.getformattedvalue()  & " AND ENROLMENT_YEAR= " & hidden_ENROLMENT_YEAR.getformattedvalue()&" " ))).Value, Int64)
		'	if (intYearLevel >=0 and intYearLevel <= 6 and subject_id.Value >=100) or (intYearLevel >=7 and intYearLevel <= 12 and subject_id.Value < 100) then
		'		errors.Add("Form Validation", "Subject ID "& subject_id.getformattedvalue() &" is not valid for Year Level " & intYearLevel.tostring() & "")
		'	end if
		'end if	'subject.value < 900

	end if 'errors.Count=0
    ' -------------------------
'End Record AddSubject Event OnValidate. Action Custom Code

'Record AddSubject Event OnValidate. Action Custom Code @282-73254650
    ' -------------------------
    '16-Dec-2016|EA| check if Subject Year Level matches Student Year Level (unfuddle #776)
    ' using SQL: select count(*) from student_enrolment se, subject sub
	' 				where se.year_level = sub.year_level and sub.status = 1 and se.enrolment_status = 'E'
	'				and se.enrolment_year = 2016 and se.student_id = 56794 and sub.subject_id = 305
	if (errors.Count =0) Then
		
		Dim intCLPYearMatchCount As Int64 = 1	' assume correct
		
		'2) check student/subject combo NOT exists 
'29-Jan-2017|EA| hide until working properly
'		intCLPYearMatchCount = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM student_enrolment se, subject sub WHERE se.year_level = sub.year_level and sub.status = 1 and se.enrolment_status = 'E' AND se.ENROLMENT_YEAR= " & hidden_ENROLMENT_YEAR.value.ToString() &" AND se.STUDENT_ID= " & hidden_STUDENT_ID.value.ToString() &" AND sub.SUBJECT_ID= " & subject_id.value.ToString() &" "))).Value, Int64)
'		if (intCLPYearMatchCount = 0 ) then
'			' put a javscript popup and change the value of Hidden_CustomProgram to 1
'			Page.ClientScript.RegisterStartupScript(Me.GetType(), "CustomProgramCheck", _
'			"alert(document.forms[0]['TextBox1'].focus();", True)<br />
'		end if
		
	End If
    ' -------------------------
'End Record AddSubject Event OnValidate. Action Custom Code

'Record AddSubject Item Class tail @28-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record AddSubject Item Class tail

'Record AddSubject Data Provider Class @28-946DFFA7
Public Class AddSubjectDataProvider
Inherits RecordDataProviderBase
'End Record AddSubject Data Provider Class

'Record AddSubject Data Provider Class Variables @28-0A5E13AC
    Protected item As AddSubjectItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record AddSubject Data Provider Class Variables

'Record AddSubject Data Provider Class GetResultSet Method @28-04B6FF98

    Public Sub FillItem(ByVal item As AddSubjectItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record AddSubject Data Provider Class GetResultSet Method

'Record AddSubject BeforeBuildSelect @28-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record AddSubject BeforeBuildSelect

'Record AddSubject AfterExecuteSelect @28-79426A21
        End If
            IsInsertMode = True
'End Record AddSubject AfterExecuteSelect

'ListBox semester AfterExecuteSelect @33-70DF9492
        
item.semesterItems.Add("1","1")
item.semesterItems.Add("2","2")
item.semesterItems.Add("B","Both")
'End ListBox semester AfterExecuteSelect

'ListBox ListBox_SubjectYearLevel AfterExecuteSelect @115-F910AD29
        
item.ListBox_SubjectYearLevelItems.Add("","All Subjects")
item.ListBox_SubjectYearLevelItems.Add("0","0 - Prep")
item.ListBox_SubjectYearLevelItems.Add("1","1")
item.ListBox_SubjectYearLevelItems.Add("2","2")
item.ListBox_SubjectYearLevelItems.Add("3","3")
item.ListBox_SubjectYearLevelItems.Add("4","4")
item.ListBox_SubjectYearLevelItems.Add("5","5")
item.ListBox_SubjectYearLevelItems.Add("6","6")
item.ListBox_SubjectYearLevelItems.Add("7","7")
item.ListBox_SubjectYearLevelItems.Add("8","8")
item.ListBox_SubjectYearLevelItems.Add("9","9")
item.ListBox_SubjectYearLevelItems.Add("10","10")
item.ListBox_SubjectYearLevelItems.Add("11","11")
item.ListBox_SubjectYearLevelItems.Add("12","12")
item.ListBox_SubjectYearLevelItems.Add("30","Home Schooled")
'End ListBox ListBox_SubjectYearLevel AfterExecuteSelect

'Record AddSubject AfterExecuteSelect tail @28-E31F8E2A
    End Sub
'End Record AddSubject AfterExecuteSelect tail

'Record AddSubject Data Provider Class @28-A61BA892
End Class

'End Record AddSubject Data Provider Class

'Record PrimarySubjectM3 Item Class @66-DE1954F3
Public Class PrimarySubjectM3Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public Grade As TextField
    Public GradeItems As ItemCollection
    Public EnrolDate As DateField
    Public hidden_STUDENT_ID As TextField
    Public hidden_ENROLMENT_YEAR As TextField
    Public Grade1 As TextField
    Public Grade1Items As ItemCollection
    Public Grade2 As TextField
    Public Grade2Items As ItemCollection
    Public Grade3 As TextField
    Public Grade3Items As ItemCollection
    Public EnrolDate1 As DateField
    Public EnrolDate2 As DateField
    Public EnrolDate3 As DateField
    Public EnrolDate4 As DateField
    Public Grade4 As TextField
    Public Grade4Items As ItemCollection
    Public Grade5 As TextField
    Public Grade5Items As ItemCollection
    Public Grade6 As TextField
    Public Grade6Items As ItemCollection
    Public Grade7 As TextField
    Public Grade7Items As ItemCollection
    Public Grade8 As TextField
    Public Grade8Items As ItemCollection
    Public Grade9 As TextField
    Public Grade9Items As ItemCollection
    Public Grade10 As TextField
    Public Grade10Items As ItemCollection
    Public Grade11 As TextField
    Public Grade11Items As ItemCollection
    Public Grade12 As TextField
    Public Grade12Items As ItemCollection
    Public Sub New()
    Grade = New TextField("", Nothing)
    GradeItems = New ItemCollection()
    EnrolDate = New DateField("dd\/MM\/yyyy", Now())
    hidden_STUDENT_ID = New TextField("", Nothing)
    hidden_ENROLMENT_YEAR = New TextField("", Nothing)
    Grade1 = New TextField("", 0)
    Grade1Items = New ItemCollection()
    Grade2 = New TextField("", 0)
    Grade2Items = New ItemCollection()
    Grade3 = New TextField("", 0)
    Grade3Items = New ItemCollection()
    EnrolDate1 = New DateField("dd\/MM\/yyyy", Now())
    EnrolDate2 = New DateField("dd\/MM\/yyyy", Now())
    EnrolDate3 = New DateField("dd\/MM\/yyyy", Now())
    EnrolDate4 = New DateField("dd\/MM\/yyyy", Now())
    Grade4 = New TextField("", 0)
    Grade4Items = New ItemCollection()
    Grade5 = New TextField("", 0)
    Grade5Items = New ItemCollection()
    Grade6 = New TextField("", 0)
    Grade6Items = New ItemCollection()
    Grade7 = New TextField("", 0)
    Grade7Items = New ItemCollection()
    Grade8 = New TextField("", 0)
    Grade8Items = New ItemCollection()
    Grade9 = New TextField("", 0)
    Grade9Items = New ItemCollection()
    Grade10 = New TextField("", 0)
    Grade10Items = New ItemCollection()
    Grade11 = New TextField("", 0)
    Grade11Items = New ItemCollection()
    Grade12 = New TextField("", 0)
    Grade12Items = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PrimarySubjectM3Item
        Dim item As PrimarySubjectM3Item = New PrimarySubjectM3Item()
        If Not IsNothing(DBUtility.GetInitialValue("Grade")) Then
        item.Grade.SetValue(DBUtility.GetInitialValue("Grade"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EnrolDate")) Then
        item.EnrolDate.SetValue(DBUtility.GetInitialValue("EnrolDate"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_STUDENT_ID")) Then
        item.hidden_STUDENT_ID.SetValue(DBUtility.GetInitialValue("hidden_STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_ENROLMENT_YEAR")) Then
        item.hidden_ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("hidden_ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Grade1")) Then
        item.Grade1.SetValue(DBUtility.GetInitialValue("Grade1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Grade2")) Then
        item.Grade2.SetValue(DBUtility.GetInitialValue("Grade2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Grade3")) Then
        item.Grade3.SetValue(DBUtility.GetInitialValue("Grade3"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EnrolDate1")) Then
        item.EnrolDate1.SetValue(DBUtility.GetInitialValue("EnrolDate1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EnrolDate2")) Then
        item.EnrolDate2.SetValue(DBUtility.GetInitialValue("EnrolDate2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EnrolDate3")) Then
        item.EnrolDate3.SetValue(DBUtility.GetInitialValue("EnrolDate3"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EnrolDate4")) Then
        item.EnrolDate4.SetValue(DBUtility.GetInitialValue("EnrolDate4"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Grade4")) Then
        item.Grade4.SetValue(DBUtility.GetInitialValue("Grade4"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Grade5")) Then
        item.Grade5.SetValue(DBUtility.GetInitialValue("Grade5"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Grade6")) Then
        item.Grade6.SetValue(DBUtility.GetInitialValue("Grade6"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Grade7")) Then
        item.Grade7.SetValue(DBUtility.GetInitialValue("Grade7"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Grade8")) Then
        item.Grade8.SetValue(DBUtility.GetInitialValue("Grade8"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Grade9")) Then
        item.Grade9.SetValue(DBUtility.GetInitialValue("Grade9"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Grade10")) Then
        item.Grade10.SetValue(DBUtility.GetInitialValue("Grade10"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Grade11")) Then
        item.Grade11.SetValue(DBUtility.GetInitialValue("Grade11"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Grade12")) Then
        item.Grade12.SetValue(DBUtility.GetInitialValue("Grade12"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Grade"
                    Return Grade
                Case "EnrolDate"
                    Return EnrolDate
                Case "hidden_STUDENT_ID"
                    Return hidden_STUDENT_ID
                Case "hidden_ENROLMENT_YEAR"
                    Return hidden_ENROLMENT_YEAR
                Case "Grade1"
                    Return Grade1
                Case "Grade2"
                    Return Grade2
                Case "Grade3"
                    Return Grade3
                Case "EnrolDate1"
                    Return EnrolDate1
                Case "EnrolDate2"
                    Return EnrolDate2
                Case "EnrolDate3"
                    Return EnrolDate3
                Case "EnrolDate4"
                    Return EnrolDate4
                Case "Grade4"
                    Return Grade4
                Case "Grade5"
                    Return Grade5
                Case "Grade6"
                    Return Grade6
                Case "Grade7"
                    Return Grade7
                Case "Grade8"
                    Return Grade8
                Case "Grade9"
                    Return Grade9
                Case "Grade10"
                    Return Grade10
                Case "Grade11"
                    Return Grade11
                Case "Grade12"
                    Return Grade12
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Grade"
                    Grade = CType(value, TextField)
                Case "EnrolDate"
                    EnrolDate = CType(value, DateField)
                Case "hidden_STUDENT_ID"
                    hidden_STUDENT_ID = CType(value, TextField)
                Case "hidden_ENROLMENT_YEAR"
                    hidden_ENROLMENT_YEAR = CType(value, TextField)
                Case "Grade1"
                    Grade1 = CType(value, TextField)
                Case "Grade2"
                    Grade2 = CType(value, TextField)
                Case "Grade3"
                    Grade3 = CType(value, TextField)
                Case "EnrolDate1"
                    EnrolDate1 = CType(value, DateField)
                Case "EnrolDate2"
                    EnrolDate2 = CType(value, DateField)
                Case "EnrolDate3"
                    EnrolDate3 = CType(value, DateField)
                Case "EnrolDate4"
                    EnrolDate4 = CType(value, DateField)
                Case "Grade4"
                    Grade4 = CType(value, TextField)
                Case "Grade5"
                    Grade5 = CType(value, TextField)
                Case "Grade6"
                    Grade6 = CType(value, TextField)
                Case "Grade7"
                    Grade7 = CType(value, TextField)
                Case "Grade8"
                    Grade8 = CType(value, TextField)
                Case "Grade9"
                    Grade9 = CType(value, TextField)
                Case "Grade10"
                    Grade10 = CType(value, TextField)
                Case "Grade11"
                    Grade11 = CType(value, TextField)
                Case "Grade12"
                    Grade12 = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As PrimarySubjectM3DataProvider)
'End Record PrimarySubjectM3 Item Class

'Grade validate @67-40EEB5FE
        If IsNothing(Grade.Value) OrElse Grade.Value.ToString() ="" Then
            errors.Add("Grade",String.Format(Resources.strings.CCS_RequiredField,"Primary Year Level"))
        End If
'End Grade validate

'EnrolDate validate @69-9FC6FA3D
        If IsNothing(EnrolDate.Value) OrElse EnrolDate.Value.ToString() ="" Then
            errors.Add("EnrolDate",String.Format(Resources.strings.CCS_RequiredField,"Enrol Date - Primary Year"))
        End If
'End EnrolDate validate

'hidden_STUDENT_ID validate @84-3C803710
        If IsNothing(hidden_STUDENT_ID.Value) OrElse hidden_STUDENT_ID.Value.ToString() ="" Then
            errors.Add("hidden_STUDENT_ID",String.Format(Resources.strings.CCS_RequiredField,"Student ID"))
        End If
'End hidden_STUDENT_ID validate

'hidden_ENROLMENT_YEAR validate @85-5A8C789A
        If IsNothing(hidden_ENROLMENT_YEAR.Value) OrElse hidden_ENROLMENT_YEAR.Value.ToString() ="" Then
            errors.Add("hidden_ENROLMENT_YEAR",String.Format(Resources.strings.CCS_RequiredField,"Enrolment Year"))
        End If
'End hidden_ENROLMENT_YEAR validate

'Grade1 validate @88-61EC42E6
        If IsNothing(Grade1.Value) OrElse Grade1.Value.ToString() ="" Then
            errors.Add("Grade1",String.Format(Resources.strings.CCS_RequiredField,"Grade Level - English Semester 1"))
        End If
'End Grade1 validate

'Grade2 validate @90-CBEBF36E
        If IsNothing(Grade2.Value) OrElse Grade2.Value.ToString() ="" Then
            errors.Add("Grade2",String.Format(Resources.strings.CCS_RequiredField,"Grade Level - English Semester 2"))
        End If
'End Grade2 validate

'Grade3 validate @92-F98C27A8
        If IsNothing(Grade3.Value) OrElse Grade3.Value.ToString() ="" Then
            errors.Add("Grade3",String.Format(Resources.strings.CCS_RequiredField,"Grade Level - Maths Semester 1"))
        End If
'End Grade3 validate

'EnrolDate1 validate @98-B8B8D2FA
        If IsNothing(EnrolDate1.Value) OrElse EnrolDate1.Value.ToString() ="" Then
            errors.Add("EnrolDate1",String.Format(Resources.strings.CCS_RequiredField,"Enrol Date - English"))
        End If
'End EnrolDate1 validate

'EnrolDate2 validate @99-A88743B5
        If IsNothing(EnrolDate2.Value) OrElse EnrolDate2.Value.ToString() ="" Then
            errors.Add("EnrolDate2",String.Format(Resources.strings.CCS_RequiredField,"Enrol Date - English"))
        End If
'End EnrolDate2 validate

'EnrolDate3 validate @100-50873BD4
        If IsNothing(EnrolDate3.Value) OrElse EnrolDate3.Value.ToString() ="" Then
            errors.Add("EnrolDate3",String.Format(Resources.strings.CCS_RequiredField,"Enrol Date - Maths"))
        End If
'End EnrolDate3 validate

'EnrolDate4 validate @101-384966F5
        If IsNothing(EnrolDate4.Value) OrElse EnrolDate4.Value.ToString() ="" Then
            errors.Add("EnrolDate4",String.Format(Resources.strings.CCS_RequiredField,"Enrol Date - Maths"))
        End If
'End EnrolDate4 validate

'Grade4 validate @102-39164F0F
        If IsNothing(Grade4.Value) OrElse Grade4.Value.ToString() ="" Then
            errors.Add("Grade4",String.Format(Resources.strings.CCS_RequiredField,"Grade Level - Maths Semester 2"))
        End If
'End Grade4 validate

'Grade5 validate @262-5C6197E0
        If IsNothing(Grade5.Value) OrElse Grade5.Value.ToString() ="" Then
            errors.Add("Grade5",String.Format(Resources.strings.CCS_RequiredField,"Integrated - Sem 1"))
        End If
'End Grade5 validate

'Grade6 validate @263-B8F4BB90
        If IsNothing(Grade6.Value) OrElse Grade6.Value.ToString() ="" Then
            errors.Add("Grade6",String.Format(Resources.strings.CCS_RequiredField,"Integrated - Sem 2"))
        End If
'End Grade6 validate

'Grade7 validate @266-C535FD7F
        If IsNothing(Grade7.Value) OrElse Grade7.Value.ToString() ="" Then
            errors.Add("Grade7",String.Format(Resources.strings.CCS_RequiredField,"Humanities - Sem 1"))
        End If
'End Grade7 validate

'Grade8 validate @268-E3229F59
        If IsNothing(Grade8.Value) OrElse Grade8.Value.ToString() ="" Then
            errors.Add("Grade8",String.Format(Resources.strings.CCS_RequiredField,"Humanities - Sem 2"))
        End If
'End Grade8 validate

'Grade9 validate @270-593F68E0
        If IsNothing(Grade9.Value) OrElse Grade9.Value.ToString() ="" Then
            errors.Add("Grade9",String.Format(Resources.strings.CCS_RequiredField,"Science - Sem 1"))
        End If
'End Grade9 validate

'Grade10 validate @272-EB5F65D4
        If IsNothing(Grade10.Value) OrElse Grade10.Value.ToString() ="" Then
            errors.Add("Grade10",String.Format(Resources.strings.CCS_RequiredField,"Science - Sem 2"))
        End If
'End Grade10 validate

'Grade11 validate @274-1DCCC24D
        If IsNothing(Grade11.Value) OrElse Grade11.Value.ToString() ="" Then
            errors.Add("Grade11",String.Format(Resources.strings.CCS_RequiredField,"Health (HPE) - Sem 1"))
        End If
'End Grade11 validate

'Grade12 validate @276-CD651162
        If IsNothing(Grade12.Value) OrElse Grade12.Value.ToString() ="" Then
            errors.Add("Grade12",String.Format(Resources.strings.CCS_RequiredField,"Health (HPE) - Sem 2"))
        End If
'End Grade12 validate

'Record PrimarySubjectM3 Item Class tail @66-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record PrimarySubjectM3 Item Class tail

'Record PrimarySubjectM3 Data Provider Class @66-7E36089B
Public Class PrimarySubjectM3DataProvider
Inherits RecordDataProviderBase
'End Record PrimarySubjectM3 Data Provider Class

'Record PrimarySubjectM3 Data Provider Class Variables @66-FC118ECE
    Public UrlRETURN_VALUE As IntegerParameter
    Public Ctrlhidden_STUDENT_ID As IntegerParameter
    Public Ctrlhidden_ENROLMENT_YEAR As IntegerParameter
    Public CtrlGrade As IntegerParameter
    Public ExprKey158 As TextParameter
    Public CtrlEnrolDate As DateParameter
    Public CtrlGrade1 As IntegerParameter
    Public ExprKey161 As TextParameter
    Public CtrlEnrolDate1 As DateParameter
    Public CtrlGrade3 As IntegerParameter
    Public ExprKey164 As TextParameter
    Public CtrlEnrolDate3 As DateParameter
    Public CtrlGrade2 As IntegerParameter
    Public ExprKey167 As TextParameter
    Public CtrlEnrolDate2 As DateParameter
    Public CtrlGrade4 As IntegerParameter
    Public ExprKey170 As TextParameter
    Public CtrlEnrolDate4 As DateParameter
    Public ExprKey172 As TextParameter
    Protected item As PrimarySubjectM3Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record PrimarySubjectM3 Data Provider Class Variables

'Record PrimarySubjectM3 Data Provider Class Constructor @66-4C128EED

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_SUBJECT {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
        Insert=new SpCommand("spi_ins_PrimarySubjects_multiple;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record PrimarySubjectM3 Data Provider Class Constructor

'Record PrimarySubjectM3 Data Provider Class LoadParams Method @66-B45586B2

    Protected Function LoadParams() As Boolean
        Return True
    End Function
'End Record PrimarySubjectM3 Data Provider Class LoadParams Method

'Record PrimarySubjectM3 Data Provider Class CheckUnique Method @66-3E7F7FCD

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As PrimarySubjectM3Item) As Boolean
        Return True
    End Function
'End Record PrimarySubjectM3 Data Provider Class CheckUnique Method

'Record PrimarySubjectM3 Data Provider Class PrepareInsert Method @66-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record PrimarySubjectM3 Data Provider Class PrepareInsert Method

'Record PrimarySubjectM3 Data Provider Class PrepareInsert Method tail @66-E31F8E2A
    End Sub
'End Record PrimarySubjectM3 Data Provider Class PrepareInsert Method tail

'Record PrimarySubjectM3 Data Provider Class Insert Method @66-A1E6DD20

    Public Function InsertItem(ByVal item As PrimarySubjectM3Item) As Integer
        Me.item = item
'End Record PrimarySubjectM3 Data Provider Class Insert Method

'Record PrimarySubjectM3 Build insert @66-EE96CCF1
        Insert.Parameters.Clear()
        CType(Insert,SpCommand).AddParameter("@RETURN_VALUE",UrlRETURN_VALUE,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Insert,SpCommand).AddParameter("@StudentID",item.hidden_STUDENT_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Insert,SpCommand).AddParameter("@EnrolmentYear",item.hidden_ENROLMENT_YEAR,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Insert,SpCommand).AddParameter("@YEARLEVEL_SubjectID",item.Grade,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Insert,SpCommand).AddParameter("@YEARLEVEL_Distribution",ExprKey158,ParameterType._Char,ParameterDirection.Input,1,0,10)
        CType(Insert,SpCommand).AddParameter("@YEARLEVEL_EnrolDate",item.EnrolDate,ParameterType._Date,ParameterDirection.Input,10,0,10)
        CType(Insert,SpCommand).AddParameter("@Sem1Eng_SubjectID",item.Grade1,ParameterType._Int,ParameterDirection.Input,10,0,10)
        CType(Insert,SpCommand).AddParameter("@Sem1Eng_Distribution",ExprKey161,ParameterType._Char,ParameterDirection.Input,1,0,10)
        CType(Insert,SpCommand).AddParameter("@Sem1Eng_EnrolDate",item.EnrolDate1,ParameterType._Date,ParameterDirection.Input,10,0,10)
        CType(Insert,SpCommand).AddParameter("@Sem1Math_SubjectID",item.Grade3,ParameterType._Int,ParameterDirection.Input,10,0,10)
        CType(Insert,SpCommand).AddParameter("@Sem1Math_Distribution",ExprKey164,ParameterType._Char,ParameterDirection.Input,1,0,10)
        CType(Insert,SpCommand).AddParameter("@Sem1Math_EnrolDate",item.EnrolDate3,ParameterType._Date,ParameterDirection.Input,10,0,10)
        CType(Insert,SpCommand).AddParameter("@Sem2Eng_SubjectID",item.Grade2,ParameterType._Int,ParameterDirection.Input,10,0,10)
        CType(Insert,SpCommand).AddParameter("@Sem2Eng_Distribution",ExprKey167,ParameterType._Char,ParameterDirection.Input,1,0,10)
        CType(Insert,SpCommand).AddParameter("@Sem2Eng_EnrolDate",item.EnrolDate2,ParameterType._Date,ParameterDirection.Input,10,0,10)
        CType(Insert,SpCommand).AddParameter("@Sem2Math_SubjectID",item.Grade4,ParameterType._Int,ParameterDirection.Input,10,0,10)
        CType(Insert,SpCommand).AddParameter("@Sem2Math_Distribution",ExprKey170,ParameterType._Char,ParameterDirection.Input,1,0,10)
        CType(Insert,SpCommand).AddParameter("@Sem2Math_EnrolDate",item.EnrolDate4,ParameterType._Date,ParameterDirection.Input,10,0,10)
        CType(Insert,SpCommand).AddParameter("@UserID",ExprKey172,ParameterType._Char,ParameterDirection.Input,8,0,10)
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
            result = ExecuteInsert()
            UrlRETURN_VALUE = IntegerParameter.GetParam(CType(Insert.Parameters("@RETURN_VALUE"),IDataParameter).Value)
        Catch ee As Exception
            E = ee
        Finally
'End Record PrimarySubjectM3 Build insert

'Record PrimarySubjectM3 AfterExecuteInsert @66-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record PrimarySubjectM3 AfterExecuteInsert

'Record PrimarySubjectM3 Data Provider Class GetResultSet Method @66-79D02BAE

    Public Sub FillItem(ByVal item As PrimarySubjectM3Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record PrimarySubjectM3 Data Provider Class GetResultSet Method

'Record PrimarySubjectM3 BeforeBuildSelect @66-5D194071
        Select_.Parameters.Clear()
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record PrimarySubjectM3 BeforeBuildSelect

'Record PrimarySubjectM3 BeforeExecuteSelect @66-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record PrimarySubjectM3 BeforeExecuteSelect

'Record PrimarySubjectM3 AfterExecuteSelect @66-7B594618
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
        Else
            IsInsertMode = True
        End If
'End Record PrimarySubjectM3 AfterExecuteSelect

'ListBox Grade AfterExecuteSelect @67-3C771A8C
        
item.GradeItems.Add("1","PREP")
item.GradeItems.Add("15","YEAR 1")
item.GradeItems.Add("29","YEAR 2")
item.GradeItems.Add("39","YEAR 3")
item.GradeItems.Add("49","YEAR 4")
item.GradeItems.Add("59","YEAR 5")
item.GradeItems.Add("69","YEAR 6")
'End ListBox Grade AfterExecuteSelect

'ListBox Grade1 AfterExecuteSelect @88-0ADD909F
        
item.Grade1Items.Add("2","<span style=""BACKGROUND: orange;PADDING:3px"">F (A/B-G/H)</span>")
item.Grade1Items.Add("12","<span style=""BACKGROUND: #B166B3;PADDING:3px"">1 (A/B-G/H)</span>")
item.Grade1Items.Add("22","<span style=""BACKGROUND: pink;PADDING:3px"">2 (A/B-G/H)</span>")
item.Grade1Items.Add("33","<span style=""BACKGROUND: gold;PADDING:3px"">3 (A-H)</span>")
item.Grade1Items.Add("44","<span style=""BACKGROUND: lightgreen;PADDING:3px"">4 (A-H)</span>")
item.Grade1Items.Add("52","<span style=""BACKGROUND: lightblue;PADDING:3px"">5 (A-H)</span>")
item.Grade1Items.Add("61","<span style=""BACKGROUND: tomato;PADDING:3px"">6 (A-H)</span>")
item.Grade1Items.Add("0","None")
'End ListBox Grade1 AfterExecuteSelect

'ListBox Grade2 AfterExecuteSelect @90-CCCAD75E
        
item.Grade2Items.Add("3","<span style=""BACKGROUND: orange;PADDING:3px"">F (I/J-Q/R)</span>")
item.Grade2Items.Add("13","<span style=""BACKGROUND: #B166B3;PADDING:3px"">1 (I/J-Q/R)</span>")
item.Grade2Items.Add("23","<span style=""BACKGROUND: pink;PADDING:3px"">2 (I/J-Q/R)</span>")
item.Grade2Items.Add("34","<span style=""BACKGROUND: gold;PADDING:3px"">3 (I-P)</span>")
item.Grade2Items.Add("45","<span style=""BACKGROUND: lightgreen;PADDING:3px"">4 (I-P)</span>")
item.Grade2Items.Add("53","<span style=""BACKGROUND: lightblue;PADDING:3px"">5 (I-P)</span>")
item.Grade2Items.Add("62","<span style=""BACKGROUND: tomato;PADDING:3px"">6 (I-P)</span>")
item.Grade2Items.Add("0","None")
'End ListBox Grade2 AfterExecuteSelect

'ListBox Grade3 AfterExecuteSelect @92-76C8F50D
        
item.Grade3Items.Add("4","<span style=""BACKGROUND: orange;PADDING:3px"">F (A/B-G/H)</span>")
item.Grade3Items.Add("16","<span style=""BACKGROUND: #B166B3;PADDING:3px"">1 (A/B-G/H)</span>")
item.Grade3Items.Add("26","<span style=""BACKGROUND: pink;PADDING:3px"">2 (A/B-G/H)</span>")
item.Grade3Items.Add("36","<span style=""BACKGROUND: gold;PADDING:3px"">3 (A-H)</span>")
item.Grade3Items.Add("46","<span style=""BACKGROUND: lightgreen;PADDING:3px"">4 (A-H)</span>")
item.Grade3Items.Add("54","<span style=""BACKGROUND: lightblue;PADDING:3px"">5 (A-H)</span>")
item.Grade3Items.Add("64","<span style=""BACKGROUND: tomato;PADDING:3px"">6 (A-H)</span>")
item.Grade3Items.Add("0","None")
'End ListBox Grade3 AfterExecuteSelect

'ListBox Grade4 AfterExecuteSelect @102-B8F9B86E
        
item.Grade4Items.Add("5","<span style=""BACKGROUND: orange;PADDING:3px"">F (I/J-Q/R)</span>")
item.Grade4Items.Add("17","<span style=""BACKGROUND: #B166B3;PADDING:3px"">1 (I/J-Q/R)</span>")
item.Grade4Items.Add("27","<span style=""BACKGROUND: pink;PADDING:3px"">2 (I/J-Q/R)</span>")
item.Grade4Items.Add("37","<span style=""BACKGROUND: gold;PADDING:3px"">3 (I-P)</span>")
item.Grade4Items.Add("47","<span style=""BACKGROUND: lightgreen;PADDING:3px"">4 (I-P)</span>")
item.Grade4Items.Add("56","<span style=""BACKGROUND: lightblue;PADDING:3px"">5 (I-P)</span>")
item.Grade4Items.Add("66","<span style=""BACKGROUND: tomato;PADDING:3px"">6 (I-P)</span>")
item.Grade4Items.Add("0","None")
'End ListBox Grade4 AfterExecuteSelect

'ListBox Grade5 AfterExecuteSelect @262-B5F2B3A5
        
item.Grade5Items.Add("6","<span style=""BACKGROUND: orange;PADDING:3px"">F (A/B-G/H)</span>")
item.Grade5Items.Add("14","<span style=""BACKGROUND: #B166B3;PADDING:3px"">1 (A/B-G/H)</span>")
item.Grade5Items.Add("20","<span style=""BACKGROUND: pink;PADDING:3px"">2 (A/B-G/H)</span>")
item.Grade5Items.Add("0","None")
'End ListBox Grade5 AfterExecuteSelect

'ListBox Grade6 AfterExecuteSelect @263-33D585A1
        
item.Grade6Items.Add("7","<span style=""BACKGROUND: orange;PADDING:3px"">F (I/J-Q/R)</span>")
item.Grade6Items.Add("19","<span style=""BACKGROUND: #B166B3;PADDING:3px"">1 (I/J-Q/R)</span>")
item.Grade6Items.Add("24","<span style=""BACKGROUND: pink;PADDING:3px"">2 (I/J-Q/R)</span>")
item.Grade6Items.Add("0","None")
'End ListBox Grade6 AfterExecuteSelect

'ListBox Grade7 AfterExecuteSelect @266-6391EBE7
        
item.Grade7Items.Add("30","<span style=""BACKGROUND: gold;PADDING:3px"">3 (A/B-G/H)</span>")
item.Grade7Items.Add("40","<span style=""BACKGROUND: lightgreen;PADDING:3px"">4 (A/B-G/H)</span>")
item.Grade7Items.Add("51","<span style=""BACKGROUND: lightblue;PADDING:3px"">5 (A/B-G/H)</span>")
item.Grade7Items.Add("60","<span style=""BACKGROUND: tomato;PADDING:3px"">6 (A/B-G/H)</span>")
item.Grade7Items.Add("0","None")
'End ListBox Grade7 AfterExecuteSelect

'ListBox Grade8 AfterExecuteSelect @268-59A5D367
        
item.Grade8Items.Add("38","<span style=""BACKGROUND: gold;PADDING:3px"">3 (I/J-Q/R)</span>")
item.Grade8Items.Add("141","<span style=""BACKGROUND: lightgreen;PADDING:3px"">4 (I/J-Q/R)</span>")
item.Grade8Items.Add("151","<span style=""BACKGROUND: lightblue;PADDING:3px"">5 (I/J-Q/R)</span>")
item.Grade8Items.Add("160","<span style=""BACKGROUND: tomato;PADDING:3px"">6 (I/J-Q/R)</span>")
item.Grade8Items.Add("0","None")
'End ListBox Grade8 AfterExecuteSelect

'ListBox Grade9 AfterExecuteSelect @270-11E5B100
        
item.Grade9Items.Add("70","<span style=""BACKGROUND: gold;PADDING:3px"">3 (A/B-G/H)</span>")
item.Grade9Items.Add("43","<span style=""BACKGROUND: lightgreen;PADDING:3px"">4 (A/B-G/H)</span>")
item.Grade9Items.Add("57","<span style=""BACKGROUND: lightblue;PADDING:3px"">5 (A/B-G/H)</span>")
item.Grade9Items.Add("67","<span style=""BACKGROUND: tomato;PADDING:3px"">6 (A/B-G/H)</span>")
item.Grade9Items.Add("0","None")
'End ListBox Grade9 AfterExecuteSelect

'ListBox Grade10 AfterExecuteSelect @272-F826AC41
        
item.Grade10Items.Add("71","<span style=""BACKGROUND: gold;PADDING:3px"">3 (I/J-Q/R)</span>")
item.Grade10Items.Add("48","<span style=""BACKGROUND: lightgreen;PADDING:3px"">4 (I/J-Q/R)</span>")
item.Grade10Items.Add("157","<span style=""BACKGROUND: lightblue;PADDING:3px"">5 (I/J-Q/R)</span>")
item.Grade10Items.Add("167","<span style=""BACKGROUND: tomato;PADDING:3px"">6 (I/J-Q/R)</span>")
item.Grade10Items.Add("0","None")
'End ListBox Grade10 AfterExecuteSelect

'ListBox Grade11 AfterExecuteSelect @274-14396B94
        
item.Grade11Items.Add("72","<span style=""BACKGROUND: gold;PADDING:3px"">3 (A/B-G/H)</span>")
item.Grade11Items.Add("142","<span style=""BACKGROUND: lightgreen;PADDING:3px"">4 (A/B-G/H)</span>")
item.Grade11Items.Add("82","<span style=""BACKGROUND: lightblue;PADDING:3px"">5 (A/B-G/H)</span>")
item.Grade11Items.Add("162","<span style=""BACKGROUND: tomato;PADDING:3px"">6 (A/B-G/H)</span>")
item.Grade11Items.Add("0","None")
'End ListBox Grade11 AfterExecuteSelect

'ListBox Grade12 AfterExecuteSelect @276-62CCE713
        
item.Grade12Items.Add("74","<span style=""BACKGROUND: gold;PADDING:3px"">3 (I/J-Q/R)</span>")
item.Grade12Items.Add("144","<span style=""BACKGROUND: lightgreen;PADDING:3px"">4 (I/J-Q/R)</span>")
item.Grade12Items.Add("84","<span style=""BACKGROUND: lightblue;PADDING:3px"">5 (I/J-Q/R)</span>")
item.Grade12Items.Add("164","<span style=""BACKGROUND: tomato;PADDING:3px"">6 (I/J-Q/R)</span>")
item.Grade12Items.Add("0","None")
'End ListBox Grade12 AfterExecuteSelect

'Record PrimarySubjectM3 AfterExecuteSelect tail @66-E31F8E2A
    End Sub
'End Record PrimarySubjectM3 AfterExecuteSelect tail

'Record PrimarySubjectM3 Data Provider Class @66-A61BA892
End Class

'End Record PrimarySubjectM3 Data Provider Class

'Record STUDENT Item Class @232-2502D91D
Public Class STUDENTItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public Sub New()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENTItem
        Dim item As STUDENTItem = New STUDENTItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SURNAME")) Then
        item.SURNAME.SetValue(DBUtility.GetInitialValue("SURNAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FIRST_NAME")) Then
        item.FIRST_NAME.SetValue(DBUtility.GetInitialValue("FIRST_NAME"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "SURNAME"
                    Return SURNAME
                Case "FIRST_NAME"
                    Return FIRST_NAME
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SURNAME"
                    SURNAME = CType(value, TextField)
                Case "FIRST_NAME"
                    FIRST_NAME = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STUDENTDataProvider)
'End Record STUDENT Item Class

'Record STUDENT Item Class tail @232-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT Item Class tail

'Record STUDENT Data Provider Class @232-17C2BAE9
Public Class STUDENTDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT Data Provider Class

'Record STUDENT Data Provider Class Variables @232-7A1E4578
    Public UrlRETURN_VALUE As IntegerParameter
    Public UrlSTUDENT_ID As IntegerParameter
    Public SesUserId As TextParameter
    Protected item As STUDENTItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT Data Provider Class Variables

'Record STUDENT Data Provider Class Constructor @232-E0FC89F2

    Public Sub New()
        Select_=new TableCommand("SELECT rtrim(SURNAME) AS SURNAME, STUDENT_ID, " & vbCrLf & _
          "rtrim(FIRST_NAME) AS FIRST_NAME " & vbCrLf & _
          "FROM STUDENT {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID244"},Settings.connDECVPRODSQL2005DataAccessObject )
        Update=new SpCommand("spu_SSTeacher_StudentsNoCLP;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record STUDENT Data Provider Class Constructor

'Record STUDENT Data Provider Class LoadParams Method @232-A977A0E9

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID))
    End Function
'End Record STUDENT Data Provider Class LoadParams Method

'Record STUDENT Data Provider Class CheckUnique Method @232-05F73907

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENTItem) As Boolean
        Return True
    End Function
'End Record STUDENT Data Provider Class CheckUnique Method

'Record STUDENT Data Provider Class PrepareUpdate Method @232-0A131024

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
'End Record STUDENT Data Provider Class PrepareUpdate Method

'Record STUDENT Data Provider Class PrepareUpdate Method tail @232-E31F8E2A
    End Sub
'End Record STUDENT Data Provider Class PrepareUpdate Method tail

'Record STUDENT Data Provider Class Update Method @232-D36572CB

    Public Function UpdateItem(ByVal item As STUDENTItem) As Integer
        Me.item = item
'End Record STUDENT Data Provider Class Update Method

'Record STUDENT BeforeBuildUpdate @232-85724956
        Update.Parameters.Clear()
        CType(Update,SpCommand).AddParameter("@RETURN_VALUE",UrlRETURN_VALUE,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Update,SpCommand).AddParameter("@student_id",UrlSTUDENT_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@staff_id",SesUserId,ParameterType._Char,ParameterDirection.Input,20,0,0)
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
'End Record STUDENT BeforeBuildUpdate

'Record STUDENT AfterExecuteUpdate @232-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT AfterExecuteUpdate

'Record STUDENT Data Provider Class GetResultSet Method @232-BE21EA83

    Public Sub FillItem(ByVal item As STUDENTItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT Data Provider Class GetResultSet Method

'Record STUDENT BeforeBuildSelect @232-96D2105E
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID244",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT BeforeBuildSelect

'Record STUDENT BeforeExecuteSelect @232-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT BeforeExecuteSelect

'Record STUDENT AfterExecuteSelect @232-F4DE24E8
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.SURNAME.SetValue(dr(i)("SURNAME"),"")
            item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
        Else
            IsInsertMode = True
        End If
'End Record STUDENT AfterExecuteSelect

'Record STUDENT AfterExecuteSelect tail @232-E31F8E2A
    End Sub
'End Record STUDENT AfterExecuteSelect tail

'Record STUDENT Data Provider Class @232-A61BA892
End Class

'End Record STUDENT Data Provider Class

'EditableGrid CORESUBJECTS Item Class @283-32A84E20
Public Class CORESUBJECTSItem
    Public errors As NameValueCollection = New NameValueCollection()
    Public RowId As Integer
    Private _deleteAllowed As Boolean = True
    Private _isNew As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public SUBJECT_ID As IntegerField
    Public SUBJECT_ABBREV As TextField
    Public SUBJECT_TITLE As TextField
    Public YEAR_LEVEL As IntegerField
    Public CORE_YEARLEVELS As TextField
    Public DEFAULT_SEMESTER As TextField
    Public DEFAULT_SEMESTERItems As ItemCollection
    Public CheckBox_Delete As IntegerField
    Public CheckBox_DeleteCheckedValue As IntegerField
    Public CheckBox_DeleteUncheckedValue As IntegerField
    Public lblClass As TextField
    Public Sub New()
    SUBJECT_ID = New IntegerField("", Nothing)
    SUBJECT_ABBREV = New TextField("", Nothing)
    SUBJECT_TITLE = New TextField("", Nothing)
    YEAR_LEVEL = New IntegerField("", Nothing)
    CORE_YEARLEVELS = New TextField("", Nothing)
    DEFAULT_SEMESTER = New TextField("", Nothing)
    DEFAULT_SEMESTERItems = New ItemCollection()
    CheckBox_Delete = New IntegerField("", 0)
    CheckBox_DeleteCheckedValue = New IntegerField("", 1)
    CheckBox_DeleteUncheckedValue = New IntegerField("", 0)
    lblClass = New TextField("", "Row")
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase
        Get
            Select fieldName
                Case "SUBJECT_IDField"
                    Return Me.SUBJECT_IDField
                Case "SUBJECT_ID"
                    Return Me.SUBJECT_ID
                Case "SUBJECT_ABBREV"
                    Return Me.SUBJECT_ABBREV
                Case "SUBJECT_TITLE"
                    Return Me.SUBJECT_TITLE
                Case "YEAR_LEVEL"
                    Return Me.YEAR_LEVEL
                Case "CORE_YEARLEVELS"
                    Return Me.CORE_YEARLEVELS
                Case "DEFAULT_SEMESTER"
                    Return Me.DEFAULT_SEMESTER
                Case "CheckBox_Delete"
                    Return Me.CheckBox_Delete
                Case "lblClass"
                    Return Me.lblClass
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SUBJECT_IDField"
                    Me.SUBJECT_IDField = CType(Value,IntegerField)
                Case "SUBJECT_ID"
                    Me.SUBJECT_ID = CType(Value,IntegerField)
                Case "SUBJECT_ABBREV"
                    Me.SUBJECT_ABBREV = CType(Value,TextField)
                Case "SUBJECT_TITLE"
                    Me.SUBJECT_TITLE = CType(Value,TextField)
                Case "YEAR_LEVEL"
                    Me.YEAR_LEVEL = CType(Value,IntegerField)
                Case "CORE_YEARLEVELS"
                    Me.CORE_YEARLEVELS = CType(Value,TextField)
                Case "DEFAULT_SEMESTER"
                    Me.DEFAULT_SEMESTER = CType(Value,TextField)
                Case "CheckBox_Delete"
                    Me.CheckBox_Delete = CType(Value,IntegerField)
                Case "lblClass"
                    Me.lblClass = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public  Property IsDeleteAllowed As Boolean
        Get
            Return  Not(IsEmptyItem) AndAlso _deleteAllowed
        End Get
        Set
            _deleteAllowed = Value
        End Set
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
            result = IsNothing(DEFAULT_SEMESTER.Value) And result
            result = IsNothing(CheckBox_Delete.Value) And result
            Return result
        End Get
    End Property

    Public IsDeleted As Boolean = False
    Public IsUpdated As Boolean = False
    Public SUBJECT_IDField As IntegerField = New IntegerField()
    Public Function Validate(ByVal provider As CORESUBJECTSDataProvider) As Boolean
'End EditableGrid CORESUBJECTS Item Class

'EditableGrid CORESUBJECTS Item Class tail @283-11D8DCF0
        Return errors.Count = 0
    End Function
    Public RawData As DataRow = Nothing
End Class
'End EditableGrid CORESUBJECTS Item Class tail

'EditableGrid CORESUBJECTS Data Provider Class Header @283-1F7A4DDD
Public Class CORESUBJECTSDataProvider
Inherits EditableGridDataProviderBase
'End EditableGrid CORESUBJECTS Data Provider Class Header

'Grid CORESUBJECTS Data Provider Class Variables @283-584DB5C3

    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {"   GroupDisplayOrder,   SUBJECT_ABBREV"}
    Private SortFieldsNamesDesc As String() = New string() {"   GroupDisplayOrder,   SUBJECT_ABBREV"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 30
    Public PageNumber As Integer = 1
    Public ExprKey176  As IntegerParameter
    Public UrlSTUDENT_ID  As IntegerParameter
    Public UrlENROLMENT_YEAR  As IntegerParameter
    Public CtrlDEFAULT_SEMESTER  As TextParameter
    Public SesUserID  As TextParameter
    Public ExprKey182  As IntegerParameter
'End Grid CORESUBJECTS Data Provider Class Variables

'EditableGrid CORESUBJECTS Data Provider Class Constructor @283-DD54FDA0

    Public Sub New()
        Select_=new SqlCommand("select" & vbCrLf & _
          "   SUBJECT_ID," & vbCrLf & _
          "   SUBJECT_ABBREV," & vbCrLf & _
          "   SUBJECT_TITLE," & vbCrLf & _
          "   YEAR_LEVEL," & vbCrLf & _
          "   CORE_YEARLEVELS," & vbCrLf & _
          "   SUB_SCHOOL," & vbCrLf & _
          "   DEFAULT_SEMESTER," & vbCrLf & _
          "   1 as autotick," & vbCrLf & _
          "   (case" & vbCrLf & _
          "       when PARENT_SUBJECT_ID < 0 then 'Row GroupParent'" & vbCrLf & _
          "       when PARENT_SUBJECT_ID > 0 then 'AltRow GroupChild'" & vbCrLf & _
          "       else 'Row'" & vbCrLf & _
          "    end" & vbCrLf & _
          "   ) as grouprowtype," & vbCrLf & _
          "   0 as GroupDisplayOrder" & vbCrLf & _
          " from" & vbCrLf & _
          "   dbo.SUBJECT" & vbCrLf & _
          " where" & vbCrLf & _
          "   STATUS = 1" & vbCrLf & _
          "   and CORE_YEARLEVELS like" & vbCrLf & _
          "   (" & vbCrLf & _
          "      select" & vbCrLf & _
          "         '%' + convert(varchar(2), YEAR_LEVEL) + '%'" & vbCrLf & _
          "       from" & vbCrLf & _
          "         dbo.STUDENT_ENROLMENT" & vbCrLf & _
          "       where" & vbCrLf & _
          "         ENROLMENT_YEAR = {ENROLMENT_YEAR}" & vbCrLf & _
          "         and STUDENT_ID = {STUDENT_ID}" & vbCrLf & _
          "   )" & vbCrLf & _
          "   and SUBJECT_ID not in" & vbCrLf & _
          "       (" & vbCrLf & _
          "          select vss.SupportSubjectID from dbo.vwSupportSubject as vss" & vbCrLf & _
          "       )" & vbCrLf & _
          "union" & vbCrLf & _
          "select 0, null, 'Electives', null, null, null, null, null, 'Row GroupParent', 1" & vbCrLf & _
          "union" & vbCrLf & _
          "select" & vbCrLf & _
          "   SUBJECT_ID," & vbCrLf & _
          "   SUBJECT_ABBREV," & vbCrLf & _
          "   SUBJECT_TITLE," & vbCrLf & _
          "   YEAR_LEVEL," & vbCrLf & _
          "   CORE_YEARLEVELS," & vbCrLf & _
          "   SUB_SCHOOL," & vbCrLf & _
          "   DEFAULT_SEMESTER," & vbCrLf & _
          "   0," & vbCrLf & _
          "   'Row'," & vbCrLf & _
          "   2" & vbCrLf & _
          " from" & vbCrLf & _
          "   dbo.SUBJECT" & vbCrLf & _
          " where" & vbCrLf & _
          "   STATUS = 1" & vbCrLf & _
          "   and CORE_YEARLEVELS = 'Elective'" & vbCrLf & _
          "   and SUB_SCHOOL like" & vbCrLf & _
          "   (" & vbCrLf & _
          "      select" & vbCrLf & _
          "         '%' + convert(varchar(2), YEAR_LEVEL) + '%'" & vbCrLf & _
          "       from" & vbCrLf & _
          "         dbo.STUDENT_ENROLMENT" & vbCrLf & _
          "       where" & vbCrLf & _
          "         ENROLMENT_YEAR = {ENROLMENT_YEAR}" & vbCrLf & _
          "         and STUDENT_ID = {STUDENT_ID}" & vbCrLf & _
          "   )" & vbCrLf & _
          "union" & vbCrLf & _
          "select 0, null, 'Support Subjects', null, null, null, null, null, 'Row GroupParent', 3" & vbCrLf & _
          "union" & vbCrLf & _
          "select" & vbCrLf & _
          "   sbj.SUBJECT_ID," & vbCrLf & _
          "   sbj.SUBJECT_ABBREV," & vbCrLf & _
          "   sbj.SUBJECT_TITLE," & vbCrLf & _
          "   sbj.YEAR_LEVEL," & vbCrLf & _
          "   sbj.CORE_YEARLEVELS," & vbCrLf & _
          "   sbj.SUB_SCHOOL," & vbCrLf & _
          "   sbj.DEFAULT_SEMESTER," & vbCrLf & _
          "   0," & vbCrLf & _
          "   'Row'," & vbCrLf & _
          "   4" & vbCrLf & _
          " from" & vbCrLf & _
          "   dbo.vwSupportSubject as vss" & vbCrLf & _
          "   inner join dbo.SUBJECT as sbj" & vbCrLf & _
          "      on (sbj.SUBJECT_ID = vss.SupportSubjectID)" & vbCrLf & _
          " where" & vbCrLf & _
          "   sbj.YEAR_LEVEL =" & vbCrLf & _
          " (" & vbCrLf & _
          "    select se.YEAR_LEVEL from dbo.STUDENT_ENROLMENT as se where (se.ENROLMENT_YEAR = {ENRO" & _
          "LMENT_YEAR}) and (se.STUDENT_ID = {STUDENT_ID})" & vbCrLf & _
          " )" & vbCrLf & _
          " {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (select" & vbCrLf & _
          "   SUBJECT_ID," & vbCrLf & _
          "   SUBJECT_ABBREV," & vbCrLf & _
          "   SUBJECT_TITLE," & vbCrLf & _
          "   YEAR_LEVEL," & vbCrLf & _
          "   CORE_YEARLEVELS," & vbCrLf & _
          "   SUB_SCHOOL," & vbCrLf & _
          "   DEFAULT_SEMESTER," & vbCrLf & _
          "   1 as autotick," & vbCrLf & _
          "   (case" & vbCrLf & _
          "       when PARENT_SUBJECT_ID < 0 then 'Row GroupParent'" & vbCrLf & _
          "       when PARENT_SUBJECT_ID > 0 then 'AltRow GroupChild'" & vbCrLf & _
          "       else 'Row'" & vbCrLf & _
          "    end" & vbCrLf & _
          "   ) as grouprowtype," & vbCrLf & _
          "   0 as GroupDisplayOrder" & vbCrLf & _
          " from" & vbCrLf & _
          "   dbo.SUBJECT" & vbCrLf & _
          " where" & vbCrLf & _
          "   STATUS = 1" & vbCrLf & _
          "   and CORE_YEARLEVELS like" & vbCrLf & _
          "   (" & vbCrLf & _
          "      select" & vbCrLf & _
          "         '%' + convert(varchar(2), YEAR_LEVEL) + '%'" & vbCrLf & _
          "       from" & vbCrLf & _
          "         dbo.STUDENT_ENROLMENT" & vbCrLf & _
          "       where" & vbCrLf & _
          "         ENROLMENT_YEAR = {ENROLMENT_YEAR}" & vbCrLf & _
          "         and STUDENT_ID = {STUDENT_ID}" & vbCrLf & _
          "   )" & vbCrLf & _
          "   and SUBJECT_ID not in" & vbCrLf & _
          "       (" & vbCrLf & _
          "          select vss.SupportSubjectID from dbo.vwSupportSubject as vss" & vbCrLf & _
          "       )" & vbCrLf & _
          "union" & vbCrLf & _
          "select 0, null, 'Electives', null, null, null, null, null, 'Row GroupParent', 1" & vbCrLf & _
          "union" & vbCrLf & _
          "select" & vbCrLf & _
          "   SUBJECT_ID," & vbCrLf & _
          "   SUBJECT_ABBREV," & vbCrLf & _
          "   SUBJECT_TITLE," & vbCrLf & _
          "   YEAR_LEVEL," & vbCrLf & _
          "   CORE_YEARLEVELS," & vbCrLf & _
          "   SUB_SCHOOL," & vbCrLf & _
          "   DEFAULT_SEMESTER," & vbCrLf & _
          "   0," & vbCrLf & _
          "   'Row'," & vbCrLf & _
          "   2" & vbCrLf & _
          " from" & vbCrLf & _
          "   dbo.SUBJECT" & vbCrLf & _
          " where" & vbCrLf & _
          "   STATUS = 1" & vbCrLf & _
          "   and CORE_YEARLEVELS = 'Elective'" & vbCrLf & _
          "   and SUB_SCHOOL like" & vbCrLf & _
          "   (" & vbCrLf & _
          "      select" & vbCrLf & _
          "         '%' + convert(varchar(2), YEAR_LEVEL) + '%'" & vbCrLf & _
          "       from" & vbCrLf & _
          "         dbo.STUDENT_ENROLMENT" & vbCrLf & _
          "       where" & vbCrLf & _
          "         ENROLMENT_YEAR = {ENROLMENT_YEAR}" & vbCrLf & _
          "         and STUDENT_ID = {STUDENT_ID}" & vbCrLf & _
          "   )" & vbCrLf & _
          "union" & vbCrLf & _
          "select 0, null, 'Support Subjects', null, null, null, null, null, 'Row GroupParent', 3" & vbCrLf & _
          "union" & vbCrLf & _
          "select" & vbCrLf & _
          "   sbj.SUBJECT_ID," & vbCrLf & _
          "   sbj.SUBJECT_ABBREV," & vbCrLf & _
          "   sbj.SUBJECT_TITLE," & vbCrLf & _
          "   sbj.YEAR_LEVEL," & vbCrLf & _
          "   sbj.CORE_YEARLEVELS," & vbCrLf & _
          "   sbj.SUB_SCHOOL," & vbCrLf & _
          "   sbj.DEFAULT_SEMESTER," & vbCrLf & _
          "   0," & vbCrLf & _
          "   'Row'," & vbCrLf & _
          "   4" & vbCrLf & _
          " from" & vbCrLf & _
          "   dbo.vwSupportSubject as vss" & vbCrLf & _
          "   inner join dbo.SUBJECT as sbj" & vbCrLf & _
          "      on (sbj.SUBJECT_ID = vss.SupportSubjectID)" & vbCrLf & _
          " where" & vbCrLf & _
          "   sbj.YEAR_LEVEL =" & vbCrLf & _
          " (" & vbCrLf & _
          "    select se.YEAR_LEVEL from dbo.STUDENT_ENROLMENT as se where (se.ENROLMENT_YEAR = {ENRO" & _
          "LMENT_YEAR}) and (se.STUDENT_ID = {STUDENT_ID})" & vbCrLf & _
          " )) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End EditableGrid CORESUBJECTS Data Provider Class Constructor

'Record CORESUBJECTS Data Provider Class CheckUnique Method @283-BF28E832

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As CORESUBJECTSItem) As Boolean
        Return True
    End Function
'End Record CORESUBJECTS Data Provider Class CheckUnique Method

'Record CORESUBJECTS Data Provider Class Delete Method @283-D4E8F41C
    Public Function DeleteItem(ByVal item As CORESUBJECTSItem) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        Dim Delete As DataCommand=new SpCommand("spi_AddStudentSubject;1",Settings.connDECVPRODSQL2005DataAccessObject)
'End Record CORESUBJECTS Data Provider Class Delete Method

'EditableGrid CORESUBJECTS Event BeforeBuildDelete. Action Custom Code @300-73254650
    ' -------------------------
  '3-Mar-2017|EA| force check if 'Enrol' (Delete) ticked, that Semester is there
    if (item.IsDeleted = True) Then
     if (item.DEFAULT_SEMESTER.Value="") then
           item.errors.Add("DEFAULT_SEMESTER",String.Format("Semester must be selected if 'Enrol' is ticked","CORESUBJECTS"))
     end if
    End if
    ' -------------------------
'End EditableGrid CORESUBJECTS Event BeforeBuildDelete. Action Custom Code

'Record CORESUBJECTS BeforeBuildDelete @283-7E8B12E0
        Delete.Parameters.Clear()
        CType(Delete,SpCommand).AddParameter("@RETURN_VALUE",ExprKey176,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Delete,SpCommand).AddParameter("@StudentID",UrlSTUDENT_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Delete,SpCommand).AddParameter("@EnrolmentYear",UrlENROLMENT_YEAR,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Delete,SpCommand).AddParameter("@SubjectID",item.SUBJECT_IDField,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Delete,SpCommand).AddParameter("@Semester",item.DEFAULT_SEMESTER,ParameterType._Char,ParameterDirection.Input,1,0,0)
        CType(Delete,SpCommand).AddParameter("@UserID",SesUserID,ParameterType._Char,ParameterDirection.Input,8,0,0)
        CType(Delete,SpCommand).AddParameter("@update",ExprKey182,ParameterType._Int,ParameterDirection.Input,0,0,10)
'End Record CORESUBJECTS BeforeBuildDelete

'EditableGrid CORESUBJECTS Data Provider Class Execute Delete @283-333D0AE2
        Delete.OpType = OperationType.Delete
        Dim result As Object = 0
        Dim E As Exception = Nothing
        If CmdExecution Then
            If Not IsParametersPassed Then
                item.errors.Add("DataProvider",Resources.strings.CCS_CustomOperationError_MissingParameters)
                Return 0
            End If
            Try
                result = Delete.ExecuteNonQuery()
                ExprKey176 = IntegerParameter.GetParam(CType(Delete.Parameters("@RETURN_VALUE"),IDataParameter).Value)
            Catch e_ As Exception
                item.errors.Add("DataProvider",e_.Source + ":" + e_.Message)
            Finally
'End EditableGrid CORESUBJECTS Data Provider Class Execute Delete

'EditableGrid CORESUBJECTS AfterExecuteDelete @283-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid CORESUBJECTS AfterExecuteDelete

'Grid CORESUBJECTS Data Provider Class GetResultSet Method @283-BBE28909
    Public Sub Update(Items As ArrayList, ops As FormSupportedOperations)
        Dim i As Integer
        For i = 0 To Items.Count - 1
            Dim op As EditableGridOperation = EditableGridOperation.Insert
            Dim isProcessed As Boolean = False
            Dim item As CORESUBJECTSItem = CType(Items(i), CORESUBJECTSItem)
'End Grid CORESUBJECTS Data Provider Class GetResultSet Method

'EditableGrid CORESUBJECTS Data Provider Class Update @283-98CD378D
            If Not item.IsUpdated Then
                If item.IsDeleted And ops.AllowDelete Then
                    DeleteItem(item)
                    op = EditableGridOperation.Delete
                    isProcessed = True
                End If
'End EditableGrid CORESUBJECTS Data Provider Class Update

'EditableGrid CORESUBJECTS Data Provider Class AfterUpdate @283-6CCB76B9
                If item.errors.Count = 0 Then item.IsUpdated = True
                OnItemUpdated(New ItemUpdatedEventArgs(op, item))
            End If
        Next i
    End Sub
'End EditableGrid CORESUBJECTS Data Provider Class AfterUpdate

'EditableGrid CORESUBJECTS Data Provider Class GetResultSet Method @283-D7A9C9C4
    Public Function GetResultSet(ByRef _pagesCount As Integer, ops As FormSupportedOperations) As CORESUBJECTSItem()
'End EditableGrid CORESUBJECTS Data Provider Class GetResultSet Method

'Before build Select @283-6141B53F
        _pagesCount = 0
        Dim E as Exception = Nothing
        Dim j As Integer
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("ENROLMENT_YEAR",UrlENROLMENT_YEAR, "")
        CType(Select_,SqlCommand).AddParameter("STUDENT_ID",UrlSTUDENT_ID, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy = SortFieldsNames(CInt(SortField)).Trim
        Else
            Select_.OrderBy = SortFieldsNamesDesc(CInt(SortField)).Trim
        End If
    Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @283-939614DD
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

'After execute Select @283-869F3851
                If Not IsNothing(E) Then Throw E
            End Try
            dr = ds.Tables(tableIndex).Rows
            rowCount = dr.Count
        End If
        Dim result(rowCount - 1) As CORESUBJECTSItem
'End After execute Select

'ListBox DEFAULT_SEMESTER AfterExecuteSelect @292-0A69F9F2
    Dim DEFAULT_SEMESTERItems As ItemCollection = New ItemCollection()
    
DEFAULT_SEMESTERItems.Add("1","Sem 1")
DEFAULT_SEMESTERItems.Add("2","Sem 2")
'End ListBox DEFAULT_SEMESTER AfterExecuteSelect

'After execute Select tail @283-8DEBB5CC
        Dim i as Integer
        For i = 0 To rowCount - 1
            Dim item as CORESUBJECTSItem = New CORESUBJECTSItem()
            item.IsDeleteAllowed = ops.AllowDelete
            item.SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
            item.SUBJECT_ABBREV.SetValue(dr(i)("SUBJECT_ABBREV"),"")
            item.SUBJECT_TITLE.SetValue(dr(i)("SUBJECT_TITLE"),"")
            item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
            item.CORE_YEARLEVELS.SetValue(dr(i)("CORE_YEARLEVELS"),"")
            item.DEFAULT_SEMESTER.SetValue(dr(i)("DEFAULT_SEMESTER"),"")
            item.DEFAULT_SEMESTERItems = CType(DEFAULT_SEMESTERItems.Clone(), ItemCollection)
            item.CheckBox_Delete.SetValue(dr(i)("autotick"),"")
            item.lblClass.SetValue(dr(i)("grouprowtype"),"")
            item.SUBJECT_IDField.SetValue(dr(i)("SUBJECT_ID"),"")
            item.RawData = dr(i)
            result(i)=item
        Next i
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @283-A61BA892
End Class
'End Grid Data Provider tail

'Grid NewGrid1 Item Class @3-DD74D708
Public Class NewGrid1Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public lblSTUDENT_ID As TextField
    Public lblENROLMENT_YEAR As TextField
    Public NewGrid1_TotalRecords As TextField
    Public SUBJECT_ID As IntegerField
    Public SUBJECT_IDHref As Object
    Public SUBJECT_IDHrefParameters As LinkParameterCollection
    Public SUBJECT_TITLE As TextField
    Public Course_Distribution As TextField
    Public SEMESTER As TextField
    Public SUBJ_ENROL_STATUS As TextField
    Public Enrolment_Date As TextField
    Public End_Date As TextField
    Public CUSTOM_LP_display As TextField
    Public NEXT_MODULE As TextField
    Public TeacherID As TextField
    Public NON_SUBMITTING_FLAG_display As TextField
    Public SUBJECT_ABBREV As TextField
    Public lblClass As TextField
    Public Sub New()
    lblSTUDENT_ID = New TextField("", Nothing)
    lblENROLMENT_YEAR = New TextField("", Nothing)
    NewGrid1_TotalRecords = New TextField("", Nothing)
    SUBJECT_ID = New IntegerField("",Nothing)
    SUBJECT_IDHrefParameters = New LinkParameterCollection()
    SUBJECT_TITLE = New TextField("", Nothing)
    Course_Distribution = New TextField("", Nothing)
    SEMESTER = New TextField("", Nothing)
    SUBJ_ENROL_STATUS = New TextField("", Nothing)
    Enrolment_Date = New TextField("", Nothing)
    End_Date = New TextField("", Nothing)
    CUSTOM_LP_display = New TextField("", Nothing)
    NEXT_MODULE = New TextField("", Nothing)
    TeacherID = New TextField("", Nothing)
    NON_SUBMITTING_FLAG_display = New TextField("", Nothing)
    SUBJECT_ABBREV = New TextField("", Nothing)
    lblClass = New TextField("", "Row")
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "lblSTUDENT_ID"
                    Return Me.lblSTUDENT_ID
                Case "lblENROLMENT_YEAR"
                    Return Me.lblENROLMENT_YEAR
                Case "NewGrid1_TotalRecords"
                    Return Me.NewGrid1_TotalRecords
                Case "SUBJECT_ID"
                    Return Me.SUBJECT_ID
                Case "SUBJECT_TITLE"
                    Return Me.SUBJECT_TITLE
                Case "Course_Distribution"
                    Return Me.Course_Distribution
                Case "SEMESTER"
                    Return Me.SEMESTER
                Case "SUBJ_ENROL_STATUS"
                    Return Me.SUBJ_ENROL_STATUS
                Case "Enrolment_Date"
                    Return Me.Enrolment_Date
                Case "End_Date"
                    Return Me.End_Date
                Case "CUSTOM_LP_display"
                    Return Me.CUSTOM_LP_display
                Case "NEXT_MODULE"
                    Return Me.NEXT_MODULE
                Case "TeacherID"
                    Return Me.TeacherID
                Case "NON_SUBMITTING_FLAG_display"
                    Return Me.NON_SUBMITTING_FLAG_display
                Case "SUBJECT_ABBREV"
                    Return Me.SUBJECT_ABBREV
                Case "lblClass"
                    Return Me.lblClass
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblSTUDENT_ID"
                    Me.lblSTUDENT_ID = CType(Value,TextField)
                Case "lblENROLMENT_YEAR"
                    Me.lblENROLMENT_YEAR = CType(Value,TextField)
                Case "NewGrid1_TotalRecords"
                    Me.NewGrid1_TotalRecords = CType(Value,TextField)
                Case "SUBJECT_ID"
                    Me.SUBJECT_ID = CType(Value,IntegerField)
                Case "SUBJECT_TITLE"
                    Me.SUBJECT_TITLE = CType(Value,TextField)
                Case "Course_Distribution"
                    Me.Course_Distribution = CType(Value,TextField)
                Case "SEMESTER"
                    Me.SEMESTER = CType(Value,TextField)
                Case "SUBJ_ENROL_STATUS"
                    Me.SUBJ_ENROL_STATUS = CType(Value,TextField)
                Case "Enrolment_Date"
                    Me.Enrolment_Date = CType(Value,TextField)
                Case "End_Date"
                    Me.End_Date = CType(Value,TextField)
                Case "CUSTOM_LP_display"
                    Me.CUSTOM_LP_display = CType(Value,TextField)
                Case "NEXT_MODULE"
                    Me.NEXT_MODULE = CType(Value,TextField)
                Case "TeacherID"
                    Me.TeacherID = CType(Value,TextField)
                Case "NON_SUBMITTING_FLAG_display"
                    Me.NON_SUBMITTING_FLAG_display = CType(Value,TextField)
                Case "SUBJECT_ABBREV"
                    Me.SUBJECT_ABBREV = CType(Value,TextField)
                Case "lblClass"
                    Me.lblClass = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid NewGrid1 Item Class

'Grid NewGrid1 Data Provider Class Header @3-C1D578D2
Public Class NewGrid1DataProvider
Inherits GridDataProviderBase
'End Grid NewGrid1 Data Provider Class Header

'Grid NewGrid1 Data Provider Class Variables @3-73517D7D

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_SUBJ_ENROL_STATUS
        Sorter_Enrolment_Date
        Sorter_End_Date
    End Enum

    Private SortFieldsNames As String() = New String() {"1,2,4","SUBJ_ENROL_STATUS","Enrolment_Date","End_Date"}
    Private SortFieldsNamesDesc As String() = New string() {"1,2,4","SUBJ_ENROL_STATUS DESC","Enrolment_Date DESC","End_Date DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 80
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As TextParameter
    Public UrlENROLMENT_YEAR  As TextParameter
'End Grid NewGrid1 Data Provider Class Variables

'Grid NewGrid1 Data Provider Class GetResultSet Method @3-8509461C

    Public Sub New()
        Select_=new SqlCommand("select TOP {SqlParam_endRecord} " & vbCrLf & _
          " --21-Nov-2018|EA| include Grouping for Full Year subjects for display mainly" & vbCrLf & _
          "	(case when b.parent_subject_id < 0 then b.subject_id" & vbCrLf & _
          "		when b.parent_subject_id > 0 then b.parent_subject_id" & vbCrLf & _
          "		else 999 end) as grouping" & vbCrLf & _
          ", b.parent_subject_id" & vbCrLf & _
          ", (case when b.parent_subject_id < 0 then 'Row GroupParent'" & vbCrLf & _
          "		when b.parent_subject_id > 0 then 'AltRow GroupChild'" & vbCrLf & _
          "		else 'Row' end) as grouprowtype" & vbCrLf & _
          ", A.SUBJECT_ID, b.subject_abbrev, B.SUBJECT_TITLE" & vbCrLf & _
          "-- , (case A.COURSE_DISTRIBUTION when 'B' then 'Book' when 'I' then 'Internet' when 'C' th" & _
          "en 'CD' when 'E' then 'E-mail' else 'Unknown' end) as [Course_Distribution]" & vbCrLf & _
          ", 'LMS' as [Course_Distribution]" & vbCrLf & _
          ", A.SEMESTER" & vbCrLf & _
          ", A.SUBJ_ENROL_STATUS + (CASE WHEN EXTENSION_OF_VCE_UNIT = 1 THEN ' Extended' ELSE '' END)" & _
          " AS SUBJ_ENROL_STATUS" & vbCrLf & _
          ", isnull(convert(char(8),A.ENROLMENT_DATE,3),'') as [Enrolment_Date]" & vbCrLf & _
          ", isnull(convert(char(8),A.WITHDRAWAL_DATE,3),'') as [End_Date]" & vbCrLf & _
          " --14-Feb-2013|EA new modules fields" & vbCrLf & _
          " --13-Feb-2014|EA| change No CLP to 'Standard Learning Program, similar to viewStudentSumm" & _
          "ary_SubjectList (unfuddle #579)" & vbCrLf & _
          ", a.MODULE_CUSTOMPROGRAM, a.MODULE_NEXTMODULE, a.MODULE_LAST_ALTERED_BY, a.MODULE_LAST_ALT" & _
          "ERED_DATE" & vbCrLf & _
          "--13-Feb-2014|EA| adjust display to show SLP (unfuddle #579)" & vbCrLf & _
          ", (case a.MODULE_CUSTOMPROGRAM WHEN '1' THEN 'Custom//Modified' WHEN '0' THEN 'Standard Le" & _
          "arning Program' else 'unknown' end ) as MODULE_CUSTOMPROGRAM_display" & vbCrLf & _
          "--12-Mar-2015|EA| adjust display to show Non-Submitting (unfuddle #690)" & vbCrLf & _
          ", (case a.NON_SUBMITTING_FLAG WHEN '1' THEN 'Non-Submitting' ELSE '' end ) as NON_SUBMITTI" & _
          "NG_FLAG_display" & vbCrLf & _
          ", a.staff_id, a.student_id" & vbCrLf & _
          "from (STUDENT_SUBJECT A join SUBJECT B on A.SUBJECT_ID=B.SUBJECT_ID )" & vbCrLf & _
          "	left join subject BB on b.parent_subject_id = BB.SUBJECT_ID " & vbCrLf & _
          "where A.STUDENT_ID={STUDENT_ID}" & vbCrLf & _
          "and A.ENROLMENT_YEAR = {ENROLMENT_YEAR} {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (select" & vbCrLf & _
          " --21-Nov-2018|EA| include Grouping for Full Year subjects for display mainly" & vbCrLf & _
          "	(case when b.parent_subject_id < 0 then b.subject_id" & vbCrLf & _
          "		when b.parent_subject_id > 0 then b.parent_subject_id" & vbCrLf & _
          "		else 999 end) as grouping" & vbCrLf & _
          ", b.parent_subject_id" & vbCrLf & _
          ", (case when b.parent_subject_id < 0 then 'Row GroupParent'" & vbCrLf & _
          "		when b.parent_subject_id > 0 then 'AltRow GroupChild'" & vbCrLf & _
          "		else 'Row' end) as grouprowtype" & vbCrLf & _
          ", A.SUBJECT_ID, b.subject_abbrev, B.SUBJECT_TITLE" & vbCrLf & _
          "-- , (case A.COURSE_DISTRIBUTION when 'B' then 'Book' when 'I' then 'Internet' when 'C' th" & _
          "en 'CD' when 'E' then 'E-mail' else 'Unknown' end) as [Course_Distribution]" & vbCrLf & _
          ", 'LMS' as [Course_Distribution]" & vbCrLf & _
          ", A.SEMESTER" & vbCrLf & _
          ", A.SUBJ_ENROL_STATUS + (CASE WHEN EXTENSION_OF_VCE_UNIT = 1 THEN ' Extended' ELSE '' END)" & _
          " AS SUBJ_ENROL_STATUS" & vbCrLf & _
          ", isnull(convert(char(8),A.ENROLMENT_DATE,3),'') as [Enrolment_Date]" & vbCrLf & _
          ", isnull(convert(char(8),A.WITHDRAWAL_DATE,3),'') as [End_Date]" & vbCrLf & _
          " --14-Feb-2013|EA new modules fields" & vbCrLf & _
          " --13-Feb-2014|EA| change No CLP to 'Standard Learning Program, similar to viewStudentSumm" & _
          "ary_SubjectList (unfuddle #579)" & vbCrLf & _
          ", a.MODULE_CUSTOMPROGRAM, a.MODULE_NEXTMODULE, a.MODULE_LAST_ALTERED_BY, a.MODULE_LAST_ALT" & _
          "ERED_DATE" & vbCrLf & _
          "--13-Feb-2014|EA| adjust display to show SLP (unfuddle #579)" & vbCrLf & _
          ", (case a.MODULE_CUSTOMPROGRAM WHEN '1' THEN 'Custom//Modified' WHEN '0' THEN 'Standard Le" & _
          "arning Program' else 'unknown' end ) as MODULE_CUSTOMPROGRAM_display" & vbCrLf & _
          "--12-Mar-2015|EA| adjust display to show Non-Submitting (unfuddle #690)" & vbCrLf & _
          ", (case a.NON_SUBMITTING_FLAG WHEN '1' THEN 'Non-Submitting' ELSE '' end ) as NON_SUBMITTI" & _
          "NG_FLAG_display" & vbCrLf & _
          ", a.staff_id, a.student_id" & vbCrLf & _
          "from (STUDENT_SUBJECT A join SUBJECT B on A.SUBJECT_ID=B.SUBJECT_ID )" & vbCrLf & _
          "	left join subject BB on b.parent_subject_id = BB.SUBJECT_ID " & vbCrLf & _
          "where A.STUDENT_ID={STUDENT_ID}" & vbCrLf & _
          "and A.ENROLMENT_YEAR = {ENROLMENT_YEAR}) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid NewGrid1 Data Provider Class GetResultSet Method

'Grid NewGrid1 Data Provider Class GetResultSet Method @3-272EC1C1
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As NewGrid1Item()
'End Grid NewGrid1 Data Provider Class GetResultSet Method

'Before build Select @3-A84CD653
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("STUDENT_ID",UrlSTUDENT_ID, "")
        CType(Select_,SqlCommand).AddParameter("ENROLMENT_YEAR",UrlENROLMENT_YEAR, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @3-5BE95E2C
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As NewGrid1Item
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

'After execute Select @3-7D929108
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New NewGrid1Item(dr.Count-1) {}
'End After execute Select

'After execute Select @3-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @3-8E7D8C1A
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as NewGrid1Item = New NewGrid1Item()
                item.SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
                item.SUBJECT_IDHref = "StudentSubject_Details_maintain.aspx"
                item.SUBJECT_IDHrefParameters.Add("SUBJECT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("SUBJECT_ID").ToString()))
                item.SUBJECT_TITLE.SetValue(dr(i)("SUBJECT_TITLE"),"")
                item.Course_Distribution.SetValue(dr(i)("Course_Distribution"),"")
                item.SEMESTER.SetValue(dr(i)("SEMESTER"),"")
                item.SUBJ_ENROL_STATUS.SetValue(dr(i)("SUBJ_ENROL_STATUS"),"")
                item.Enrolment_Date.SetValue(dr(i)("Enrolment_Date"),"")
                item.End_Date.SetValue(dr(i)("End_Date"),"")
                item.CUSTOM_LP_display.SetValue(dr(i)("MODULE_CUSTOMPROGRAM_display"),"")
                item.NEXT_MODULE.SetValue(dr(i)("MODULE_NEXTMODULE"),"")
                item.TeacherID.SetValue(dr(i)("staff_id"),"")
                item.NON_SUBMITTING_FLAG_display.SetValue(dr(i)("NON_SUBMITTING_FLAG_display"),"")
                item.SUBJECT_ABBREV.SetValue(dr(i)("subject_abbrev"),"")
                item.lblClass.SetValue(dr(i)("grouprowtype"),"")
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

'DEL      ' -------------------------
'DEL      '9-Feb-2017|EA| force check if 'Enrol' (Delete) ticked, that Semester is there
'DEL      if (item.IsDeleted = True) Then
'DEL      	if (item.DEFAULT_SEMESTER.Value="") then
'DEL             item.errors.Add("DEFAULT_SEMESTER",String.Format("Semester must be selected if 'Enrol' is ticked","CORESUBJECTS"))
'DEL             'item.errors.Add("DEFAULT_SEMESTER",String.Format(";Checked value " & item.IsDeleted & " ", "CORESUBJECTS"))	
'DEL             'item.errors.Add("DEFAULT_SEMESTER",String.Format(";Semester [" & item.DEFAULT_SEMESTER.Value & "]","CORESUBJECTS"))	
'DEL      	end if
'DEL      End if
'DEL      ' -------------------------

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

