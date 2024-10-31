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

Namespace DECV_PROD2007.Despatch_AssignmentReturn 'Namespace @1-B24195A7

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

'Record AssignmentReturns Item Class @3-C6232548
Public Class AssignmentReturnsItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public staffid As TextField
    Public studentid As TextField
    Public link_popupStudentSearch As TextField
    Public link_popupStudentSearchHref As Object
    Public link_popupStudentSearchHrefParameters As LinkParameterCollection
    Public subjectid As TextField
    Public link_popupStudentSubjectSearch As TextField
    Public link_popupStudentSubjectSearchHref As Object
    Public link_popupStudentSubjectSearchHrefParameters As LinkParameterCollection
    Public markerid As TextField
    Public lblReceiptDate As DateField
    Public ENrolmentYear As TextField
    Public Link_Clear As TextField
    Public Link_ClearHref As Object
    Public Link_ClearHrefParameters As LinkParameterCollection
    Public Sub New()
    staffid = New TextField("", Nothing)
    studentid = New TextField("", Nothing)
    link_popupStudentSearch = New TextField("",Nothing)
    link_popupStudentSearchHrefParameters = New LinkParameterCollection()
    subjectid = New TextField("", Nothing)
    link_popupStudentSubjectSearch = New TextField("",Nothing)
    link_popupStudentSubjectSearchHrefParameters = New LinkParameterCollection()
    markerid = New TextField("", Nothing)
    lblReceiptDate = New DateField("dd\/MM\/yy h\:mm tt", now())
    ENrolmentYear = New TextField("", year(now()))
    Link_Clear = New TextField("",Nothing)
    Link_ClearHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As AssignmentReturnsItem
        Dim item As AssignmentReturnsItem = New AssignmentReturnsItem()
        If Not IsNothing(DBUtility.GetInitialValue("staffid")) Then
        item.staffid.SetValue(DBUtility.GetInitialValue("staffid"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("studentid")) Then
        item.studentid.SetValue(DBUtility.GetInitialValue("studentid"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("link_popupStudentSearch")) Then
        item.link_popupStudentSearch.SetValue(DBUtility.GetInitialValue("link_popupStudentSearch"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("subjectid")) Then
        item.subjectid.SetValue(DBUtility.GetInitialValue("subjectid"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("link_popupStudentSubjectSearch")) Then
        item.link_popupStudentSubjectSearch.SetValue(DBUtility.GetInitialValue("link_popupStudentSubjectSearch"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("markerid")) Then
        item.markerid.SetValue(DBUtility.GetInitialValue("markerid"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblReceiptDate")) Then
        item.lblReceiptDate.SetValue(DBUtility.GetInitialValue("lblReceiptDate"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENrolmentYear")) Then
        item.ENrolmentYear.SetValue(DBUtility.GetInitialValue("ENrolmentYear"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link_Clear")) Then
        item.Link_Clear.SetValue(DBUtility.GetInitialValue("Link_Clear"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "staffid"
                    Return staffid
                Case "studentid"
                    Return studentid
                Case "link_popupStudentSearch"
                    Return link_popupStudentSearch
                Case "subjectid"
                    Return subjectid
                Case "link_popupStudentSubjectSearch"
                    Return link_popupStudentSubjectSearch
                Case "markerid"
                    Return markerid
                Case "lblReceiptDate"
                    Return lblReceiptDate
                Case "ENrolmentYear"
                    Return ENrolmentYear
                Case "Link_Clear"
                    Return Link_Clear
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "staffid"
                    staffid = CType(value, TextField)
                Case "studentid"
                    studentid = CType(value, TextField)
                Case "link_popupStudentSearch"
                    link_popupStudentSearch = CType(value, TextField)
                Case "subjectid"
                    subjectid = CType(value, TextField)
                Case "link_popupStudentSubjectSearch"
                    link_popupStudentSubjectSearch = CType(value, TextField)
                Case "markerid"
                    markerid = CType(value, TextField)
                Case "lblReceiptDate"
                    lblReceiptDate = CType(value, DateField)
                Case "ENrolmentYear"
                    ENrolmentYear = CType(value, TextField)
                Case "Link_Clear"
                    Link_Clear = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As AssignmentReturnsDataProvider)
'End Record AssignmentReturns Item Class

'staffid validate @4-785C9DB9
        If IsNothing(staffid.Value) OrElse staffid.Value.ToString() ="" Then
            errors.Add("staffid",String.Format(Resources.strings.CCS_RequiredField,"Staff ID"))
        End If
'End staffid validate

'studentid validate @5-33C8304A
        If IsNothing(studentid.Value) OrElse studentid.Value.ToString() ="" Then
            errors.Add("studentid",String.Format(Resources.strings.CCS_RequiredField,"Student ID"))
        End If
'End studentid validate

'subjectid validate @6-C2BEA08B
        If IsNothing(subjectid.Value) OrElse subjectid.Value.ToString() ="" Then
            errors.Add("subjectid",String.Format(Resources.strings.CCS_RequiredField,"Subject ID"))
        End If
'End subjectid validate

'markerid validate @8-E4F6659D
        If IsNothing(markerid.Value) OrElse markerid.Value.ToString() ="" Then
            errors.Add("markerid",String.Format(Resources.strings.CCS_RequiredField,"Marker ID"))
        End If
'End markerid validate

'Record AssignmentReturns Event OnValidate. Action Custom Code @15-73254650
    ' -------------------------
' ERA: do form validation at once for checking if:
	'	1) StaffID exists (for teacher and Marker)
	'	2) This combination of student/subject exists
	'	3) That there is actually a assignment to be returned for this student/subject/assignment combo
	' (based on v. similar code in Despatch_AssignmentReceipt.[Form].OnValidate
	
	' only check these if the above fields are OK
	if (errors.Count =0) Then

		Dim intStaffCount As Int64 = -1
		Dim intMarkerCount As Int64 = -1
		Dim intAssignmentCount As Int64 = -1
		Dim intStudentSubjectCount As Int64 = -1
		dim flagCheckStudentSubject as boolean = true		' used to flag if the Student+Subject combo should be checked - false if studetn OR subject validation fails

		'1) check staff id
		intStaffCount = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM STAFF WHERE STAFF_ID = '" & StaffID.value.ToString() &"'"))).Value, Int64)
		if (intStaffCount <=0) then
			errors.Add("Form Validation", "This STAFF ID does not exist in the database")
			flagCheckStudentSubject = false
		end if

		'SELECT count(*) FROM STUDENT_SUBJECT WHERE ENROLMENT_YEAR=(select max(enrolment_year) from student_subject) AND STUDENT_ID = '" & AssignmentReceiptstudentid.Text.ToString() & "'"))).Value, Int64


		'1) check  marker	
		intMarkerCount = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM STAFF WHERE STAFF_ID = '" & markerid.value.ToString() &"'"))).Value, Int64)
		if (intMarkerCount <=0) then
			errors.Add("Form Validation", "This MARKER ID does not exist in the database")
		end if




		'2) check student/subject combo exists 
		intStudentSubjectCount = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM student_subject WHERE STAFF_ID = '" & StaffID.value.ToString() &"' AND ENROLMENT_YEAR= " & ENrolmentYear.value.ToString() &" AND STUDENT_ID= " & studentid.value.ToString() &" AND SUBJECT_ID= " & subjectid.value.ToString() &" "))).Value, Int64)
		if (intStudentSubjectCount <=0) then
			errors.Add("Form Validation", "The entered STUDENT is not enrolled for this STAFF ID for this SUBJECT.")
		end if

		'3) check returned assignment exists for subject
		' this will be checked in the Save code, and if not exists, will be added and updated at same time, without message to user
		'intAssignmentCount = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM assignment_submission WHERE ENROLMENT_YEAR= " & ENROLMENT_YEAR.value.ToString() &" AND SUBJECT_ID= " & subjectid.value.ToString() &" AND ASSIGNMENT_ID= " & assignmentid.value.ToString() & " AND RETURNED_DATE is NULL"))).Value, Int64)
		'if (intAssignmentCount <=0) then
		'	errors.Add("Form Validation", "The entered ASSIGNMENT ID does not exists for RETURN - does not exist for this SUBJECT.")
		'end if
	end if 'errors.Count=0
    ' -------------------------
'End Record AssignmentReturns Event OnValidate. Action Custom Code

'Record AssignmentReturns Item Class tail @3-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record AssignmentReturns Item Class tail

'Record AssignmentReturns Data Provider Class @3-A46662E7
Public Class AssignmentReturnsDataProvider
Inherits RecordDataProviderBase
'End Record AssignmentReturns Data Provider Class

'Record AssignmentReturns Data Provider Class Variables @3-F3485DC7
    Public ExprKey12 As IntegerParameter
    Public Ctrlstudentid As FloatParameter
    Public CtrlENrolmentYear As FloatParameter
    Public Ctrlsubjectid As IntegerParameter
    Public ExprKey16 As IntegerParameter
    Public Ctrlmarkerid As TextParameter
    Protected item As AssignmentReturnsItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record AssignmentReturns Data Provider Class Variables

'Record AssignmentReturns Data Provider Class Constructor @3-956884D0

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM ASSIGNMENT_SUBMISSION {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
        Insert=new SpCommand("sp_upd_assignment_return;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record AssignmentReturns Data Provider Class Constructor

'Record AssignmentReturns Data Provider Class LoadParams Method @3-B45586B2

    Protected Function LoadParams() As Boolean
        Return True
    End Function
'End Record AssignmentReturns Data Provider Class LoadParams Method

'Record AssignmentReturns Data Provider Class CheckUnique Method @3-D881A6D5

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As AssignmentReturnsItem) As Boolean
        Return True
    End Function
'End Record AssignmentReturns Data Provider Class CheckUnique Method

'Record AssignmentReturns Data Provider Class PrepareInsert Method @3-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record AssignmentReturns Data Provider Class PrepareInsert Method

'Record AssignmentReturns Data Provider Class PrepareInsert Method tail @3-E31F8E2A
    End Sub
'End Record AssignmentReturns Data Provider Class PrepareInsert Method tail

'Record AssignmentReturns Data Provider Class Insert Method @3-B2036583

    Public Function InsertItem(ByVal item As AssignmentReturnsItem) As Integer
        Me.item = item
'End Record AssignmentReturns Data Provider Class Insert Method

'Record AssignmentReturns Event BeforeBuildInsert. Action Custom Code @23-73254650
    ' -------------------------
     'ERA: if the Assignment field is blank, then adjust the adjust the Assignment to be split out of the Subject ID
	' split out the subjectid into subject and assignment id
    Dim stringToSplit As String = item.subjectid.Value
    Dim stringAssID As String = stringToSplit.Substring(stringToSplit.Length - 2, 2)
    item.subjectid.SetValue(stringToSplit.Remove(stringToSplit.Length - 2, 2))
    ' CCS defined Expression so use it so save changing Insert parameters in next section
    ExprKey16 = IntegerParameter.GetParam(Int32.Parse(stringAssID), ParameterSourceType.Expression, "", Nothing, False)
    ' -------------------------
'End Record AssignmentReturns Event BeforeBuildInsert. Action Custom Code

'Record AssignmentReturns Build insert @3-C8DF9704
        Insert.Parameters.Clear()
        CType(Insert,SpCommand).AddParameter("@RETURN_VALUE",ExprKey12,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Insert,SpCommand).AddParameter("@pnStudentID",item.studentid,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Insert,SpCommand).AddParameter("@pnEnrolmentYear",item.ENrolmentYear,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Insert,SpCommand).AddParameter("@psiSubjectID",item.subjectid,ParameterType._SmallInt,ParameterDirection.Input,0,0,5)
        CType(Insert,SpCommand).AddParameter("@psiAssignmentID",ExprKey16,ParameterType._SmallInt,ParameterDirection.Input,0,0,5)
        CType(Insert,SpCommand).AddParameter("@pcStaffID",item.markerid,ParameterType._Char,ParameterDirection.Input,8,0,5)
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
            result = ExecuteInsert()
            ExprKey12 = IntegerParameter.GetParam(CType(Insert.Parameters("@RETURN_VALUE"),IDataParameter).Value, CObj(0))
        Catch ee As Exception
            E = ee
        Finally
'End Record AssignmentReturns Build insert

'Record AssignmentReturns AfterExecuteInsert @3-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record AssignmentReturns AfterExecuteInsert

'Record AssignmentReturns Data Provider Class GetResultSet Method @3-BDB51248

    Public Sub FillItem(ByVal item As AssignmentReturnsItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record AssignmentReturns Data Provider Class GetResultSet Method

'Record AssignmentReturns BeforeBuildSelect @3-5D194071
        Select_.Parameters.Clear()
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record AssignmentReturns BeforeBuildSelect

'Record AssignmentReturns BeforeExecuteSelect @3-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record AssignmentReturns BeforeExecuteSelect

'Record AssignmentReturns AfterExecuteSelect @3-E1A8386E
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.link_popupStudentSearchHref = "#"
            item.link_popupStudentSubjectSearchHref = "#"
            item.Link_ClearHref = "Despatch_AssignmentReturn.aspx"
        Else
            IsInsertMode = True
        End If
'End Record AssignmentReturns AfterExecuteSelect

'Record AssignmentReturns AfterExecuteSelect tail @3-E31F8E2A
    End Sub
'End Record AssignmentReturns AfterExecuteSelect tail

'Record AssignmentReturns Data Provider Class @3-A61BA892
End Class

'End Record AssignmentReturns Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

