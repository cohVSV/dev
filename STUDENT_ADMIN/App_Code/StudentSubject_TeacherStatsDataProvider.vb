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

Namespace DECV_PROD2007.StudentSubject_TeacherStats 'Namespace @1-50F518C9

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

'Report rptTeacherAllocation Item Class @4-2C2302EA
Public Class rptTeacherAllocationItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public lblEnrolmentYear As TextField
    Public lblSubjectAbbreviation As TextField
    Public SEMESTER As TextField
    Public STAFF_ID As TextField
    Public SUBJECT_TIMEFRACTION As FloatField
    Public FTE_StudentMax As FloatField
    Public Current_Student_Count As IntegerField
    Public Percentage As FloatField
    Public TotalSum_SUBJECT_TIMEFRACTION As FloatField
    Public TotalSum_FTE_StudentMax As FloatField
    Public TotalSum_Current_Student_Count As IntegerField
    Public lblTotalAllocationPercentage As TextField
    Public Sub New()
    lblEnrolmentYear = New TextField("", Nothing)
    lblSubjectAbbreviation = New TextField("", Nothing)
    SEMESTER = New TextField("", Nothing)
    STAFF_ID = New TextField("", Nothing)
    SUBJECT_TIMEFRACTION = New FloatField("0.00", Nothing)
    FTE_StudentMax = New FloatField("0", Nothing)
    Current_Student_Count = New IntegerField("", Nothing)
    Percentage = New FloatField("0%", Nothing)
    TotalSum_SUBJECT_TIMEFRACTION = New FloatField("", Nothing)
    TotalSum_FTE_StudentMax = New FloatField("", Nothing)
    TotalSum_Current_Student_Count = New IntegerField("", Nothing)
    lblTotalAllocationPercentage = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "lblEnrolmentYear"
                    Return Me.lblEnrolmentYear
                Case "lblSubjectAbbreviation"
                    Return Me.lblSubjectAbbreviation
                Case "SEMESTER"
                    Return Me.SEMESTER
                Case "STAFF_ID"
                    Return Me.STAFF_ID
                Case "SUBJECT_TIMEFRACTION"
                    Return Me.SUBJECT_TIMEFRACTION
                Case "FTE_StudentMax"
                    Return Me.FTE_StudentMax
                Case "Current_Student_Count"
                    Return Me.Current_Student_Count
                Case "Percentage"
                    Return Me.Percentage
                Case "TotalSum_SUBJECT_TIMEFRACTION"
                    Return Me.TotalSum_SUBJECT_TIMEFRACTION
                Case "TotalSum_FTE_StudentMax"
                    Return Me.TotalSum_FTE_StudentMax
                Case "TotalSum_Current_Student_Count"
                    Return Me.TotalSum_Current_Student_Count
                Case "lblTotalAllocationPercentage"
                    Return Me.lblTotalAllocationPercentage
                Case "SEMESTERGroupField"
                    Return Me.SEMESTERGroupField
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblEnrolmentYear"
                    Me.lblEnrolmentYear = CType(Value,TextField)
                Case "lblSubjectAbbreviation"
                    Me.lblSubjectAbbreviation = CType(Value,TextField)
                Case "SEMESTER"
                    Me.SEMESTER = CType(Value,TextField)
                Case "STAFF_ID"
                    Me.STAFF_ID = CType(Value,TextField)
                Case "SUBJECT_TIMEFRACTION"
                    Me.SUBJECT_TIMEFRACTION = CType(Value,FloatField)
                Case "FTE_StudentMax"
                    Me.FTE_StudentMax = CType(Value,FloatField)
                Case "Current_Student_Count"
                    Me.Current_Student_Count = CType(Value,IntegerField)
                Case "Percentage"
                    Me.Percentage = CType(Value,FloatField)
                Case "TotalSum_SUBJECT_TIMEFRACTION"
                    Me.TotalSum_SUBJECT_TIMEFRACTION = CType(Value,FloatField)
                Case "TotalSum_FTE_StudentMax"
                    Me.TotalSum_FTE_StudentMax = CType(Value,FloatField)
                Case "TotalSum_Current_Student_Count"
                    Me.TotalSum_Current_Student_Count = CType(Value,IntegerField)
                Case "lblTotalAllocationPercentage"
                    Me.lblTotalAllocationPercentage = CType(Value,TextField)
                Case "SEMESTERGroupField"
                    Me.SEMESTERGroupField = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public SEMESTERGroupField As New TextField("", Nothing)
    Public RawData As DataRow = Nothing
End Class
'End Report rptTeacherAllocation Item Class

'Report rptTeacherAllocation Data Provider Class Header @4-BCD4C1A1
Public Class rptTeacherAllocationDataProvider
Inherits GridDataProviderBase
'End Report rptTeacherAllocation Data Provider Class Header

'Report rptTeacherAllocation Data Provider Class Variables @4-DED7EA36

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {"dummy clause to keep CodeCharge Studio happy "}
    Private SortFieldsNamesDesc As String() = New string() {"dummy clause to keep CodeCharge Studio happy "}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public Urlsubject_id  As TextParameter
    Public UrlENROLMENT_YEAR  As IntegerParameter
'End Report rptTeacherAllocation Data Provider Class Variables

'Report rptTeacherAllocation Data Provider Class GetResultSet Method @4-3E5048C1

    Public Sub New()
        Select_=new SqlCommand("with" & vbCrLf & _
          "   TeacherSubjectTimeFraction as" & vbCrLf & _
          "      (" & vbCrLf & _
          "         select" & vbCrLf & _
          "            st.SUBJECT_ID," & vbCrLf & _
          "            rtrim(st.STAFF_ID) as STAFF_ID," & vbCrLf & _
          "            st.SUBJECT_TIMEFRACTION," & vbCrLf & _
          "            floor(sbj.ALLOCATE_STUDENTS_MAX * st.SUBJECT_TIMEFRACTION) as FTE_StudentMax" & vbCrLf & _
          "          from" & vbCrLf & _
          "            dbo.SUBJECT_TEACHER as st" & vbCrLf & _
          "            inner join dbo.SUBJECT as sbj" & vbCrLf & _
          "               on (sbj.SUBJECT_ID = st.SUBJECT_ID)" & vbCrLf & _
          "          where" & vbCrLf & _
          "            (st.SUBJECT_ID = {subject_id})" & vbCrLf & _
          "      )" & vbCrLf & _
          " select" & vbCrLf & _
          "    iif(vs.SemesterID is not null, vs.SEMESTER, '(No allocations)') as SEMESTER," & vbCrLf & _
          "    tstf.STAFF_ID," & vbCrLf & _
          "    tstf.SUBJECT_TIMEFRACTION," & vbCrLf & _
          "    tstf.FTE_StudentMax," & vbCrLf & _
          "    iif(vs.SemesterID is not null, count(ss.STUDENT_ID), null) as [Current Student Count]," & vbCrLf & _
          "    iif((vs.SemesterID is not null) and (tstf.FTE_StudentMax > 0), (count(ss.STUDENT_ID) /" & _
          " tstf.FTE_StudentMax), null) as Percentage" & vbCrLf & _
          "  from" & vbCrLf & _
          "    TeacherSubjectTimeFraction as tstf" & vbCrLf & _
          "    left join dbo.STUDENT_SUBJECT as ss" & vbCrLf & _
          "       on (" & vbCrLf & _
          "             (ss.ENROLMENT_YEAR = {ENROLMENT_YEAR})" & vbCrLf & _
          "             and (ss.SUBJECT_ID = tstf.SUBJECT_ID)" & vbCrLf & _
          "             and (ss.STAFF_ID = tstf.STAFF_ID)" & vbCrLf & _
          "             and" & vbCrLf & _
          "             (" & vbCrLf & _
          "                ss.NON_SUBMITTING_FLAG is null" & vbCrLf & _
          "                or ss.NON_SUBMITTING_FLAG = 0" & vbCrLf & _
          "             )" & vbCrLf & _
          "             and (ss.SUBJ_ENROL_STATUS in ('C', 'D', 'E', 'P'))" & vbCrLf & _
          "          )" & vbCrLf & _
          "    left join vwSemester as vs" & vbCrLf & _
          "       on (vs.SemesterID = ss.SEMESTER)" & vbCrLf & _
          "  group by" & vbCrLf & _
          "    vs.SemesterID," & vbCrLf & _
          "    vs.SEMESTER," & vbCrLf & _
          "    tstf.STAFF_ID," & vbCrLf & _
          "    tstf.SUBJECT_TIMEFRACTION," & vbCrLf & _
          "    tstf.FTE_StudentMax" & vbCrLf & _
          "  order by" & vbCrLf & _
          "    SEMESTER," & vbCrLf & _
          "    Percentage," & vbCrLf & _
          "    FTE_StudentMax" & vbCrLf & _
          "-- {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Report rptTeacherAllocation Data Provider Class GetResultSet Method

'Report rptTeacherAllocation Data Provider Class GetResultSet Method @4-9FCE31CE
    Public Function GetResultSet(ops As FormSupportedOperations) As rptTeacherAllocationItem()
'End Report rptTeacherAllocation Data Provider Class GetResultSet Method

'Before build Select @4-B40E446D
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("subject_id",Urlsubject_id, "")
        CType(Select_,SqlCommand).AddParameter("ENROLMENT_YEAR",UrlENROLMENT_YEAR, "")
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Select_.OrderBy = " asc" + IIf(Select_.OrderBy.Length>0, ",", "") + Select_.OrderBy
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @4-67381846
        Dim ds As DataSet = Nothing
        Dim result(-1) As rptTeacherAllocationItem
        If ops.AllowRead Then
            Try
                    ds=ExecuteSelect()
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @4-1464DFE9
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New rptTeacherAllocationItem(dr.Count-1) {}
'End After execute Select

'After execute Select @4-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @4-7887A3C3
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as rptTeacherAllocationItem = New rptTeacherAllocationItem()
                item.SEMESTER.SetValue(dr(i)("SEMESTER"),"")
                item.STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
                item.SUBJECT_TIMEFRACTION.SetValue(dr(i)("SUBJECT_TIMEFRACTION"),"")
                item.FTE_StudentMax.SetValue(dr(i)("FTE_StudentMax"),"")
                item.Current_Student_Count.SetValue(dr(i)("Current Student Count"),"")
                item.Percentage.SetValue(dr(i)("Percentage"),"")
                item.TotalSum_SUBJECT_TIMEFRACTION.SetValue(dr(i)("SUBJECT_TIMEFRACTION"),"")
                item.TotalSum_FTE_StudentMax.SetValue(dr(i)("FTE_StudentMax"),"")
                item.TotalSum_Current_Student_Count.SetValue(dr(i)("Current Student Count"),"")
                item.SEMESTERGroupField.SetValue(dr(i)("SEMESTER"))
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Return result 
    End Function
'End After execute Select tail

'Report Data Provider tail @4-A61BA892
End Class
'End Report Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

