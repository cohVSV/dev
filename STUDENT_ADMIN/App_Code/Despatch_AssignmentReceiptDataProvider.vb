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

Namespace DECV_PROD2007.Despatch_AssignmentReceipt 'Namespace @1-8B814235

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

'Record AssignmentReceipt Item Class @3-CADBE9BB
Public Class AssignmentReceiptItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public StaffID As TextField
    Public StaffIDItems As ItemCollection
    Public studentid As TextField
    Public subjectid As TextField
    Public receiptdate As DateField
    Public ENrolmentYear As IntegerField
    Public link_popupStudentSearch As TextField
    Public link_popupStudentSearchHref As Object
    Public link_popupStudentSearchHrefParameters As LinkParameterCollection
    Public link_popupStudentSubjectSearch As TextField
    Public link_popupStudentSubjectSearchHref As Object
    Public link_popupStudentSubjectSearchHrefParameters As LinkParameterCollection
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public Sub New()
    StaffID = New TextField("", Nothing)
    StaffIDItems = New ItemCollection()
    studentid = New TextField("", Nothing)
    subjectid = New TextField("", Nothing)
    receiptdate = New DateField("dd\/MM\/yyyy", now())
    ENrolmentYear = New IntegerField("", year(now()))
    link_popupStudentSearch = New TextField("",Nothing)
    link_popupStudentSearchHrefParameters = New LinkParameterCollection()
    link_popupStudentSubjectSearch = New TextField("",Nothing)
    link_popupStudentSubjectSearchHrefParameters = New LinkParameterCollection()
    Link1 = New TextField("",Nothing)
    Link1HrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As AssignmentReceiptItem
        Dim item As AssignmentReceiptItem = New AssignmentReceiptItem()
        If Not IsNothing(DBUtility.GetInitialValue("StaffID")) Then
        item.StaffID.SetValue(DBUtility.GetInitialValue("StaffID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("studentid")) Then
        item.studentid.SetValue(DBUtility.GetInitialValue("studentid"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("subjectid")) Then
        item.subjectid.SetValue(DBUtility.GetInitialValue("subjectid"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("receiptdate")) Then
        item.receiptdate.SetValue(DBUtility.GetInitialValue("receiptdate"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENrolmentYear")) Then
        item.ENrolmentYear.SetValue(DBUtility.GetInitialValue("ENrolmentYear"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("link_popupStudentSearch")) Then
        item.link_popupStudentSearch.SetValue(DBUtility.GetInitialValue("link_popupStudentSearch"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("link_popupStudentSubjectSearch")) Then
        item.link_popupStudentSubjectSearch.SetValue(DBUtility.GetInitialValue("link_popupStudentSubjectSearch"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link1")) Then
        item.Link1.SetValue(DBUtility.GetInitialValue("Link1"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "StaffID"
                    Return StaffID
                Case "studentid"
                    Return studentid
                Case "subjectid"
                    Return subjectid
                Case "receiptdate"
                    Return receiptdate
                Case "ENrolmentYear"
                    Return ENrolmentYear
                Case "link_popupStudentSearch"
                    Return link_popupStudentSearch
                Case "link_popupStudentSubjectSearch"
                    Return link_popupStudentSubjectSearch
                Case "Link1"
                    Return Link1
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "StaffID"
                    StaffID = CType(value, TextField)
                Case "studentid"
                    studentid = CType(value, TextField)
                Case "subjectid"
                    subjectid = CType(value, TextField)
                Case "receiptdate"
                    receiptdate = CType(value, DateField)
                Case "ENrolmentYear"
                    ENrolmentYear = CType(value, IntegerField)
                Case "link_popupStudentSearch"
                    link_popupStudentSearch = CType(value, TextField)
                Case "link_popupStudentSubjectSearch"
                    link_popupStudentSubjectSearch = CType(value, TextField)
                Case "Link1"
                    Link1 = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As AssignmentReceiptDataProvider)
'End Record AssignmentReceipt Item Class

'DEL      ' -------------------------
'DEL      
'DEL      ' -------------------------


'Record AssignmentReceipt Event OnValidate. Action Custom Code @21-73254650
    ' -------------------------
    ' ERA: do form validation at once for checking if:
	'	1) StaffID exists
	'	2a) Subject ID exists
	'	2b) if this assignment id for this subject exists
	'	3) This combination of student/subject exists

	' only check these if the above fields are OK
		if (errors.Count =0) Then
				Dim intStaffCount As Int64 = -1
				Dim intSubjectCount As Int64 = -1
				Dim intAssignmentCount As Int64 = -1
				Dim intStudentSubjectCount As Int64 = -1
                Dim flagCheckStudentSubject As Boolean = false   'flag for checking Student AND Subject if the Student check and Subject Check are OK

   				Dim stringToSplit As String = ""
                Dim tmpSubject As String = ""
                Dim tmpAssignment As String = ""

                If Not (IsNothing(subjectid.Value) OrElse subjectid.Value.ToString() = "") Then
                    stringToSplit = subjectid.Value.ToString()
                    tmpSubject = (stringToSplit.Remove(stringToSplit.Length - 2, 2))
                    tmpAssignment = (stringToSplit.Substring(stringToSplit.Length - 2, 2))
                End If


                    '1) check staff	ID
					If not (IsNothing(staffid.Value) OrElse staffid.Value.ToString() ="")  Then
                	    intStaffCount = CType((New IntegerField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM STAFF WHERE STAFF_ID = '" & StaffID.Value.ToString() & "'"))).Value, Int64)
            	        If (intStaffCount <= 0) Then
        	                errors.Add("Form Validation", "This STAFF ID does not exist in the database")
    	                    flagCheckStudentSubject = False
						Else
                        	flagCheckStudentSubject = True
	                    End If
					end if

                    '2a) check if subject exists

                    If not (IsNothing(tmpSubject) OrElse tmpSubject ="")  Then
					    intAssignmentCount = CType((New IntegerField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM subject WHERE SUBJECT_ID= " & tmpSubject.ToString() & " AND STATUS =1"))).Value, Int64)
	                    If (intAssignmentCount <= 0) Then
    	                    errors.Add("Form Validation", "The entered SUBJECT ID (" & tmpSubject.ToString & ") does not exist.")
        	                flagCheckStudentSubject = False
            	        Else
							flagCheckStudentSubject = True
                	        '2b) check assignment exists for subject, now that Subject exists
                    	    intAssignmentCount = CType((New IntegerField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM assignment WHERE SUBJECT_ID= " & tmpSubject.ToString() & " AND ASSIGNMENT_ID= " & tmpAssignment.ToString() & " AND STATUS =1"))).Value, Int64)
                        	If (intAssignmentCount <= 0) Then
                            	errors.Add("Form Validation", "The entered ASSIGNMENT ID (" & tmpAssignment.ToString & ") does not exist for this SUBJECT.")
	                        End If
                    	End If
					else
						' if Subject is blank then don't even try to check subject/student combo
					 	flagCheckStudentSubject = False
					End If ' not (IsNothing(tmpSubject) OrElse tmpSubject ="")

                    '3) check student/subject combo exists if certain of the above haven't failed
                    If (flagCheckStudentSubject) and (not (IsNothing(studentid.Value) OrElse studentid.Value.ToString() =""))  Then
                        intStudentSubjectCount = CType((New IntegerField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM student_subject WHERE STAFF_ID = '" & StaffID.Value.ToString() & "' AND ENROLMENT_YEAR= " & ENrolmentYear.Value.ToString() & " AND STUDENT_ID= " & studentid.Value.ToString() & " AND SUBJECT_ID= " & tmpSubject.ToString() & " "))).Value, Int64)
                        If (intStudentSubjectCount <= 0) Then
                            errors.Add("Form Validation", "The entered STUDENT is not enrolled for this STAFF ID for this SUBJECT (" & tmpSubject.ToString & ").")
                        End If
                    End If


            End If  'errors.count=0
    ' -------------------------
'End Record AssignmentReceipt Event OnValidate. Action Custom Code

'Record AssignmentReceipt Item Class tail @3-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record AssignmentReceipt Item Class tail

'Record AssignmentReceipt Data Provider Class @3-7C3BCF9E
Public Class AssignmentReceiptDataProvider
Inherits RecordDataProviderBase
'End Record AssignmentReceipt Data Provider Class

'Record AssignmentReceipt Data Provider Class Variables @3-75B12F24
    Protected StaffIDDataCommand As DataCommand=new TableCommand("SELECT rtrim(STAFF_ID) AS STAFF_ID " & vbCrLf & _
          "FROM STAFF {SQL_Where} {SQL_OrderBy}", New String(){"expr13","And","expr14"},Settings.connDECVPRODSQL2005DataAccessObject )
    Public ExprKey12 As IntegerParameter
    Public Ctrlstudentid As FloatParameter
    Public CtrlENrolmentYear As FloatParameter
    Public Ctrlsubjectid As IntegerParameter
    Public ExprKey16 As IntegerParameter
    Protected item As AssignmentReceiptItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record AssignmentReceipt Data Provider Class Variables

'Record AssignmentReceipt Data Provider Class Constructor @3-81D590CB

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM ASSIGNMENT_SUBMISSION {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
        Insert=new SpCommand("sp_upd_assignment_submission;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record AssignmentReceipt Data Provider Class Constructor

'Record AssignmentReceipt Data Provider Class LoadParams Method @3-B45586B2

    Protected Function LoadParams() As Boolean
        Return True
    End Function
'End Record AssignmentReceipt Data Provider Class LoadParams Method

'Record AssignmentReceipt Data Provider Class CheckUnique Method @3-FC3E5C9C

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As AssignmentReceiptItem) As Boolean
        Return True
    End Function
'End Record AssignmentReceipt Data Provider Class CheckUnique Method

'Record AssignmentReceipt Data Provider Class PrepareInsert Method @3-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record AssignmentReceipt Data Provider Class PrepareInsert Method

'Record AssignmentReceipt Data Provider Class PrepareInsert Method tail @3-E31F8E2A
    End Sub
'End Record AssignmentReceipt Data Provider Class PrepareInsert Method tail

'Record AssignmentReceipt Data Provider Class Insert Method @3-48A31C9D

    Public Function InsertItem(ByVal item As AssignmentReceiptItem) As Integer
        Me.item = item
'End Record AssignmentReceipt Data Provider Class Insert Method

'Record AssignmentReceipt Event BeforeBuildInsert. Action Custom Code @29-73254650
    ' -------------------------
   'ERA: if the Assignment field is blank, then adjust the adjust the Assignment to be split out of the Subject ID
	' split out the subjectid into subject and assignment id
    Dim stringToSplit As String = item.subjectid.Value
    Dim stringAssID As String = stringToSplit.Substring(stringToSplit.Length - 2, 2)
    item.subjectid.SetValue(stringToSplit.Remove(stringToSplit.Length - 2, 2))
    ' CCS defined Expression so use it so save changing Insert parameters in next section
    ExprKey16 = IntegerParameter.GetParam(Int32.Parse(stringAssID), ParameterSourceType.Expression, "", Nothing, False)
    ' -------------------------
'End Record AssignmentReceipt Event BeforeBuildInsert. Action Custom Code


'Record AssignmentReceipt Build insert @3-B3BA1676
        Insert.Parameters.Clear()
        CType(Insert,SpCommand).AddParameter("@RETURN_VALUE",ExprKey12,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Insert,SpCommand).AddParameter("@pnStudentID",item.studentid,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Insert,SpCommand).AddParameter("@pnEnrolmentYear",item.ENrolmentYear,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Insert,SpCommand).AddParameter("@psiSubjectID",item.subjectid,ParameterType._SmallInt,ParameterDirection.Input,0,0,5)
        CType(Insert,SpCommand).AddParameter("@psiAssignmentID",ExprKey16,ParameterType._SmallInt,ParameterDirection.Input,0,0,5)
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
            result = ExecuteInsert()
            ExprKey12 = IntegerParameter.GetParam(CType(Insert.Parameters("@RETURN_VALUE"),IDataParameter).Value, CObj(0))
        Catch ee As Exception
            E = ee
        Finally
'End Record AssignmentReceipt Build insert

'Record AssignmentReceipt AfterExecuteInsert @3-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record AssignmentReceipt AfterExecuteInsert

'Record AssignmentReceipt Data Provider Class GetResultSet Method @3-5FFC2CB8

    Public Sub FillItem(ByVal item As AssignmentReceiptItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record AssignmentReceipt Data Provider Class GetResultSet Method

'Record AssignmentReceipt BeforeBuildSelect @3-5D194071
        Select_.Parameters.Clear()
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record AssignmentReceipt BeforeBuildSelect

'Record AssignmentReceipt BeforeExecuteSelect @3-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record AssignmentReceipt BeforeExecuteSelect

'Record AssignmentReceipt AfterExecuteSelect @3-ECAADB78
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.link_popupStudentSearchHref = "#"
            item.link_popupStudentSubjectSearchHref = "#"
            item.Link1Href = "Despatch_AssignmentReceipt.aspx"
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record AssignmentReceipt AfterExecuteSelect

'ListBox StaffID Initialize Data Source @4-0897B800
        StaffIDDataCommand.Dao._optimized = False
        Dim StaffIDtableIndex As Integer = 0
        StaffIDDataCommand.OrderBy = ""
        StaffIDDataCommand.Parameters.Clear()
        StaffIDDataCommand.Parameters.Add("expr13","(STATUS = 1)")
        StaffIDDataCommand.Parameters.Add("expr14","(TEACHER_FLAG = 1)")
'End ListBox StaffID Initialize Data Source

'ListBox StaffID BeforeExecuteSelect @4-89E1B41C
        Try
            ListBoxSource=StaffIDDataCommand.Execute().Tables(StaffIDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox StaffID BeforeExecuteSelect

'ListBox StaffID AfterExecuteSelect @4-5A9A5A75
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("STAFF_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("STAFF_ID")
            item.StaffIDItems.Add(Key, Val)
        Next
'End ListBox StaffID AfterExecuteSelect

'Record AssignmentReceipt AfterExecuteSelect tail @3-E31F8E2A
    End Sub
'End Record AssignmentReceipt AfterExecuteSelect tail

'Record AssignmentReceipt Data Provider Class @3-A61BA892
End Class

'End Record AssignmentReceipt Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

