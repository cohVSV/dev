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

Namespace DECV_PROD2007.PastoralTeacher_StudentList 'Namespace @1-43F91F7E

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

'EditableGrid viewMaintainSearchRequest1 Item Class @51-66B9B41B
Public Class viewMaintainSearchRequest1Item
    Public errors As NameValueCollection = New NameValueCollection()
    Public RowId As Integer
    Private _deleteAllowed As Boolean = False
    Private _isNew As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public viewMaintainSearchRequest1_TotalRecords As TextField
    Public STUDENT_ID As FloatField
    Public STUDENT_IDHref As Object
    Public STUDENT_IDHrefParameters As LinkParameterCollection
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public YEAR_LEVEL As IntegerField
    Public ENROLMENT_STATUS As TextField
    Public lblPastoralID As TextField
    Public link_IntakeDone As TextField
    Public link_IntakeDoneHref As Object
    Public link_IntakeDoneHrefParameters As LinkParameterCollection
    Public link_PathwaysDone As TextField
    Public link_PathwaysDoneHref As Object
    Public link_PathwaysDoneHrefParameters As LinkParameterCollection
    Public ENROLMENT_DATE As DateField
    Public lblNewStudent As TextField
    Public hidden_days_since_enrolment As IntegerField
    Public rbGreenLetterSend As TextField
    Public rbGreenLetterSendItems As ItemCollection
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public lblGreenLetter As TextField
    Public GREEN_LETTER_SENT_FLAG As TextField
    Public GREEN_LETTER_SENT_DATE As DateField
    Public AMBER_LETTER_SENT_FLAG As TextField
    Public AMBER_LETTER_SENT_DATE As DateField
    Public RED_LETTER_SENT_FLAG As TextField
    Public RED_LETTER_SENT_DATE As DateField
    Public MandatedCohort As TextField
    Public LearningPlan As TextField
    Public Sub New()
    viewMaintainSearchRequest1_TotalRecords = New TextField("", Nothing)
    STUDENT_ID = New FloatField("",Nothing)
    STUDENT_IDHrefParameters = New LinkParameterCollection()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    YEAR_LEVEL = New IntegerField("", Nothing)
    ENROLMENT_STATUS = New TextField("", Nothing)
    lblPastoralID = New TextField("", Nothing)
    link_IntakeDone = New TextField("",Nothing)
    link_IntakeDoneHrefParameters = New LinkParameterCollection()
    link_PathwaysDone = New TextField("",Nothing)
    link_PathwaysDoneHrefParameters = New LinkParameterCollection()
    ENROLMENT_DATE = New DateField("dd MMM yyyy", Nothing)
    lblNewStudent = New TextField("", Nothing)
    hidden_days_since_enrolment = New IntegerField("", Nothing)
    rbGreenLetterSend = New TextField("", "N")
    rbGreenLetterSendItems = New ItemCollection()
    Link1 = New TextField("",Nothing)
    Link1HrefParameters = New LinkParameterCollection()
    lblGreenLetter = New TextField("", "<font color='green'>Done!</font>")
    GREEN_LETTER_SENT_FLAG = New TextField("", Nothing)
    GREEN_LETTER_SENT_DATE = New DateField("dd MMM yy", Nothing)
    AMBER_LETTER_SENT_FLAG = New TextField("", Nothing)
    AMBER_LETTER_SENT_DATE = New DateField("dd MMM yy", Nothing)
    RED_LETTER_SENT_FLAG = New TextField("", Nothing)
    RED_LETTER_SENT_DATE = New DateField("dd MMM yy", Nothing)
    MandatedCohort = New TextField("", Nothing)
    LearningPlan = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase
        Get
            Select fieldName
                Case "ENROLMENT_YEARField"
                    Return Me.ENROLMENT_YEARField
                Case "STUDENT_IDField"
                    Return Me.STUDENT_IDField
                Case "viewMaintainSearchRequest1_TotalRecords"
                    Return Me.viewMaintainSearchRequest1_TotalRecords
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "YEAR_LEVEL"
                    Return Me.YEAR_LEVEL
                Case "ENROLMENT_STATUS"
                    Return Me.ENROLMENT_STATUS
                Case "lblPastoralID"
                    Return Me.lblPastoralID
                Case "link_IntakeDone"
                    Return Me.link_IntakeDone
                Case "link_PathwaysDone"
                    Return Me.link_PathwaysDone
                Case "ENROLMENT_DATE"
                    Return Me.ENROLMENT_DATE
                Case "lblNewStudent"
                    Return Me.lblNewStudent
                Case "hidden_days_since_enrolment"
                    Return Me.hidden_days_since_enrolment
                Case "rbGreenLetterSend"
                    Return Me.rbGreenLetterSend
                Case "Link1"
                    Return Me.Link1
                Case "lblGreenLetter"
                    Return Me.lblGreenLetter
                Case "GREEN_LETTER_SENT_FLAG"
                    Return Me.GREEN_LETTER_SENT_FLAG
                Case "GREEN_LETTER_SENT_DATE"
                    Return Me.GREEN_LETTER_SENT_DATE
                Case "AMBER_LETTER_SENT_FLAG"
                    Return Me.AMBER_LETTER_SENT_FLAG
                Case "AMBER_LETTER_SENT_DATE"
                    Return Me.AMBER_LETTER_SENT_DATE
                Case "RED_LETTER_SENT_FLAG"
                    Return Me.RED_LETTER_SENT_FLAG
                Case "RED_LETTER_SENT_DATE"
                    Return Me.RED_LETTER_SENT_DATE
                Case "MandatedCohort"
                    Return Me.MandatedCohort
                Case "LearningPlan"
                    Return Me.LearningPlan
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ENROLMENT_YEARField"
                    Me.ENROLMENT_YEARField = CType(Value,FloatField)
                Case "STUDENT_IDField"
                    Me.STUDENT_IDField = CType(Value,IntegerField)
                Case "viewMaintainSearchRequest1_TotalRecords"
                    Me.viewMaintainSearchRequest1_TotalRecords = CType(Value,TextField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "YEAR_LEVEL"
                    Me.YEAR_LEVEL = CType(Value,IntegerField)
                Case "ENROLMENT_STATUS"
                    Me.ENROLMENT_STATUS = CType(Value,TextField)
                Case "lblPastoralID"
                    Me.lblPastoralID = CType(Value,TextField)
                Case "link_IntakeDone"
                    Me.link_IntakeDone = CType(Value,TextField)
                Case "link_PathwaysDone"
                    Me.link_PathwaysDone = CType(Value,TextField)
                Case "ENROLMENT_DATE"
                    Me.ENROLMENT_DATE = CType(Value,DateField)
                Case "lblNewStudent"
                    Me.lblNewStudent = CType(Value,TextField)
                Case "hidden_days_since_enrolment"
                    Me.hidden_days_since_enrolment = CType(Value,IntegerField)
                Case "rbGreenLetterSend"
                    Me.rbGreenLetterSend = CType(Value,TextField)
                Case "Link1"
                    Me.Link1 = CType(Value,TextField)
                Case "lblGreenLetter"
                    Me.lblGreenLetter = CType(Value,TextField)
                Case "GREEN_LETTER_SENT_FLAG"
                    Me.GREEN_LETTER_SENT_FLAG = CType(Value,TextField)
                Case "GREEN_LETTER_SENT_DATE"
                    Me.GREEN_LETTER_SENT_DATE = CType(Value,DateField)
                Case "AMBER_LETTER_SENT_FLAG"
                    Me.AMBER_LETTER_SENT_FLAG = CType(Value,TextField)
                Case "AMBER_LETTER_SENT_DATE"
                    Me.AMBER_LETTER_SENT_DATE = CType(Value,DateField)
                Case "RED_LETTER_SENT_FLAG"
                    Me.RED_LETTER_SENT_FLAG = CType(Value,TextField)
                Case "RED_LETTER_SENT_DATE"
                    Me.RED_LETTER_SENT_DATE = CType(Value,DateField)
                Case "MandatedCohort"
                    Me.MandatedCohort = CType(Value,TextField)
                Case "LearningPlan"
                    Me.LearningPlan = CType(Value,TextField)
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
            result = IsNothing(hidden_days_since_enrolment.Value) And result
            result = IsNothing(rbGreenLetterSend.Value) And result
            Return result
        End Get
    End Property

    Public IsDeleted As Boolean = False
    Public IsUpdated As Boolean = False
    Public ENROLMENT_YEARField As FloatField = New FloatField()
    Public STUDENT_IDField As IntegerField = New IntegerField()
    Public Function Validate(ByVal provider As viewMaintainSearchRequest1DataProvider) As Boolean
'End EditableGrid viewMaintainSearchRequest1 Item Class

'EditableGrid viewMaintainSearchRequest1 Item Class tail @51-11D8DCF0
        Return errors.Count = 0
    End Function
    Public RawData As DataRow = Nothing
End Class
'End EditableGrid viewMaintainSearchRequest1 Item Class tail

'EditableGrid viewMaintainSearchRequest1 Data Provider Class Header @51-BD4781E8
Public Class viewMaintainSearchRequest1DataProvider
Inherits EditableGridDataProviderBase
'End EditableGrid viewMaintainSearchRequest1 Data Provider Class Header

'Grid viewMaintainSearchRequest1 Data Provider Class Variables @51-A757B88D

    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_ID
        Sorter_SURNAME
        Sorter_FIRST_NAME
        Sorter_YEAR_LEVEL
        Sorter_ENROLMENT_STATUS
        Sorter_ENROLMENT_DATE
    End Enum

    Private SortFieldsNames As String() = New String() {"","STUDENT_ID","SURNAME","FIRST_NAME","YEAR_LEVEL","ENROLMENT_STATUS","ENROLMENT_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"","STUDENT_ID DESC","SURNAME DESC","FIRST_NAME DESC","YEAR_LEVEL DESC","ENROLMENT_STATUS DESC","ENROLMENT_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 100
    Public PageNumber As Integer = 1
    Public CtrlrbGreenLetterSend  As TextParameter
    Public Expr134  As DateParameter
    Public UrlRETURN_VALUE  As IntegerParameter
    Public SesUserId  As TextParameter
'End Grid viewMaintainSearchRequest1 Data Provider Class Variables

'EditableGrid viewMaintainSearchRequest1 Data Provider Class Constructor @51-AEE5B4BC

    Public Sub New()
        Select_=new SqlCommand("select" & vbCrLf & _
          "   subq.*," & vbCrLf & _
          "   concat(subq.PSDFunded, subq.NCCDFunded, subq.HouseholdStatus, subq.ATSIStatus, subq.You" & _
          "thJustice, subq.AcademicLag) as MandatedCohort" & vbCrLf & _
          " from" & vbCrLf & _
          " (" & vbCrLf & _
          "    select" & vbCrLf & _
          "       st.*," & vbCrLf & _
          "       iif((smd.PSD_FUNDING_ASSESSED = 1)" & vbCrLf & _
          "                   or (smd.PSD_FUNDING_ELIGIBLE = 1)" & vbCrLf & _
          "                   or (smd.PSD_FUNDING_LEVEL is not null)" & vbCrLf & _
          "                   or (len(smd.PSD_FUNDING_CATEGORY) > 2)" & vbCrLf & _
          "                   or (smd.RECEIVED_SUPPORT_PROGRAMS_SERVICES like '%,PSD%')," & vbCrLf & _
          "       'PSD Funded; '," & vbCrLf & _
          "       '') as PSDFunded," & vbCrLf & _
          "       iif((smd.NCCD_FUNDING_APPROVED = 1)" & vbCrLf & _
          "                   or (smd.NCCD_FUNDING_CATEGORY is not null)" & vbCrLf & _
          "                   or (smd.NCCD_FUNDING_LEVEL is not null), 'NCCD Funded; ', '') as NCCDFu" & _
          "nded," & vbCrLf & _
          "       iif(scd.HOUSEHOLD_STATUS in (3, 6, 7), concat(vhs.HouseholdStatusDisplayText, '; ')" & _
          ", '') as HouseholdStatus," & vbCrLf & _
          "       iif(scd.KOORITORRESFLAG in ('K', 'B', 'T'), 'Indigenous; ', '') as ATSIStatus," & vbCrLf & _
          "       iif(scd.YOUTH_JUSTICE_INVOLVEMENT = 1, 'Youth Justice; ', '') as YouthJustice," & vbCrLf & _
          "       iif(eas.AcademicLag = 'true', 'Assessed as two years or more below expected level; " & _
          "', '') as AcademicLag" & vbCrLf & _
          "     from" & vbCrLf & _
          "       dbo.viewMaintainSearchRequest_SupportTeacher as st" & vbCrLf & _
          "       left join dbo.EARLY_ASSESSMENT_STUDENT as eas" & vbCrLf & _
          "          on (" & vbCrLf & _
          "                (eas.STUDENT_ID = st.STUDENT_ID)" & vbCrLf & _
          "                and (eas.ENROLMENT_YEAR = st.ENROLMENT_YEAR)" & vbCrLf & _
          "             )" & vbCrLf & _
          "       left join dbo.STUDENT_CENSUS_DATA as scd" & vbCrLf & _
          "          on (scd.STUDENT_ID = st.STUDENT_ID)" & vbCrLf & _
          "       left join dbo.STUDENT_MEDICAL_DETAILS as smd" & vbCrLf & _
          "          on (smd.STUDENT_ID = st.STUDENT_ID)" & vbCrLf & _
          "       left join dbo.vwHouseholdStatus as vhs" & vbCrLf & _
          "          on (vhs.HouseholdStatusValue = scd.HOUSEHOLD_STATUS)" & vbCrLf & _
          "     where" & vbCrLf & _
          "       st.ENROLMENT_STATUS = 'E'" & vbCrLf & _
          "       and st.PASTORAL_CARE_ID = '{UserId}'" & vbCrLf & _
          "       and (st.ENROLMENT_YEAR = year(getdate()))" & vbCrLf & _
          " ) as subq",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (select" & vbCrLf & _
          "   subq.*," & vbCrLf & _
          "   concat(subq.PSDFunded, subq.NCCDFunded, subq.HouseholdStatus, subq.ATSIStatus, subq.You" & _
          "thJustice, subq.AcademicLag) as MandatedCohort" & vbCrLf & _
          " from" & vbCrLf & _
          " (" & vbCrLf & _
          "    select" & vbCrLf & _
          "       st.*," & vbCrLf & _
          "       iif((smd.PSD_FUNDING_ASSESSED = 1)" & vbCrLf & _
          "                   or (smd.PSD_FUNDING_ELIGIBLE = 1)" & vbCrLf & _
          "                   or (smd.PSD_FUNDING_LEVEL is not null)" & vbCrLf & _
          "                   or (len(smd.PSD_FUNDING_CATEGORY) > 2)" & vbCrLf & _
          "                   or (smd.RECEIVED_SUPPORT_PROGRAMS_SERVICES like '%,PSD%')," & vbCrLf & _
          "       'PSD Funded; '," & vbCrLf & _
          "       '') as PSDFunded," & vbCrLf & _
          "       iif((smd.NCCD_FUNDING_APPROVED = 1)" & vbCrLf & _
          "                   or (smd.NCCD_FUNDING_CATEGORY is not null)" & vbCrLf & _
          "                   or (smd.NCCD_FUNDING_LEVEL is not null), 'NCCD Funded; ', '') as NCCDFu" & _
          "nded," & vbCrLf & _
          "       iif(scd.HOUSEHOLD_STATUS in (3, 6, 7), concat(vhs.HouseholdStatusDisplayText, '; ')" & _
          ", '') as HouseholdStatus," & vbCrLf & _
          "       iif(scd.KOORITORRESFLAG in ('K', 'B', 'T'), 'Indigenous; ', '') as ATSIStatus," & vbCrLf & _
          "       iif(scd.YOUTH_JUSTICE_INVOLVEMENT = 1, 'Youth Justice; ', '') as YouthJustice," & vbCrLf & _
          "       iif(eas.AcademicLag = 'true', 'Assessed as two years or more below expected level; " & _
          "', '') as AcademicLag" & vbCrLf & _
          "     from" & vbCrLf & _
          "       dbo.viewMaintainSearchRequest_SupportTeacher as st" & vbCrLf & _
          "       left join dbo.EARLY_ASSESSMENT_STUDENT as eas" & vbCrLf & _
          "          on (" & vbCrLf & _
          "                (eas.STUDENT_ID = st.STUDENT_ID)" & vbCrLf & _
          "                and (eas.ENROLMENT_YEAR = st.ENROLMENT_YEAR)" & vbCrLf & _
          "             )" & vbCrLf & _
          "       left join dbo.STUDENT_CENSUS_DATA as scd" & vbCrLf & _
          "          on (scd.STUDENT_ID = st.STUDENT_ID)" & vbCrLf & _
          "       left join dbo.STUDENT_MEDICAL_DETAILS as smd" & vbCrLf & _
          "          on (smd.STUDENT_ID = st.STUDENT_ID)" & vbCrLf & _
          "       left join dbo.vwHouseholdStatus as vhs" & vbCrLf & _
          "          on (vhs.HouseholdStatusValue = scd.HOUSEHOLD_STATUS)" & vbCrLf & _
          "     where" & vbCrLf & _
          "       st.ENROLMENT_STATUS = 'E'" & vbCrLf & _
          "       and st.PASTORAL_CARE_ID = '{UserId}'" & vbCrLf & _
          "       and (st.ENROLMENT_YEAR = year(getdate()))" & vbCrLf & _
          " ) as subq) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End EditableGrid viewMaintainSearchRequest1 Data Provider Class Constructor

'Record viewMaintainSearchRequest1 Data Provider Class CheckUnique Method @51-23B60AFF

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As viewMaintainSearchRequest1Item) As Boolean
        Return True
    End Function
'End Record viewMaintainSearchRequest1 Data Provider Class CheckUnique Method

'EditableGrid viewMaintainSearchRequest1 Data Provider Class Update Method @51-9DCC223B
    Protected Function UpdateItem(ByVal item As viewMaintainSearchRequest1Item) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        IsParametersPassed = Not(IsNothing(item.STUDENT_IDField) Or IsNothing(item.ENROLMENT_YEARField))
        Dim Update As DataCommand=new TableCommand("UPDATE STUDENT_SUBJECT SET {Values}", New String(){"STUDENT_ID129","And","expr130","And","ENROLMENT_YEAR131","And","expr132"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End EditableGrid viewMaintainSearchRequest1 Data Provider Class Update Method

'EditableGrid viewMaintainSearchRequest1 BeforeBuildUpdate @51-0F41DF6C
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID129",item.STUDENT_IDField, "","STUDENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ENROLMENT_YEAR131",item.ENROLMENT_YEARField, "","ENROLMENT_YEAR",Condition.Equal,False)
        Update.Parameters.Add("expr130","(SUBJ_ENROL_STATUS in ('D','C'))")
        Update.Parameters.Add("expr132","(SUBJECT_ID not in (select vis.IntroductorySubjectID from dbo.vwIntroductorySubject as vis where (vis.IntroductorySubjectStatus = 1)) )")
        allEmptyFlag = item.rbGreenLetterSend.IsEmpty And allEmptyFlag
        If Not item.rbGreenLetterSend.IsEmpty Then
        If IsNothing(item.rbGreenLetterSend.Value) Then
        valuesList = valuesList & "DEFAULTING_STATUS=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "DEFAULTING_STATUS=" & Update.Dao.ToSql(item.rbGreenLetterSend.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = (Expr134 Is Nothing) And allEmptyFlag
        If Not (Expr134 Is Nothing) Then
        If IsNothing(Expr134) Then
        valuesList = valuesList & "DEFAULTING_STATUS_DATE=" & Update.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        valuesList = valuesList & "DEFAULTING_STATUS_DATE=" & Update.Dao.ToSql(Expr134.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        End If
		Update.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
'End EditableGrid viewMaintainSearchRequest1 BeforeBuildUpdate

'EditableGrid viewMaintainSearchRequest1 Event BeforeExecuteUpdate. Action Custom Code @135-73254650
    ' -------------------------
    'ERA: 22-March-2013|EA| handle non-values of rbGreenLetterSend - don't update record if nothing chosen)
		If (item.rbGreenLetterSend.Value = "" or IsNothing(item.rbGreenLetterSend.Value)) Then
			CmdExecution = false
		end if
    ' -------------------------
'End EditableGrid viewMaintainSearchRequest1 Event BeforeExecuteUpdate. Action Custom Code

'EditableGrid viewMaintainSearchRequest1 Execute Update  @51-392E25E7
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
'End EditableGrid viewMaintainSearchRequest1 Execute Update 

'EditableGrid viewMaintainSearchRequest1 AfterExecuteUpdate @51-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid viewMaintainSearchRequest1 AfterExecuteUpdate

'Grid viewMaintainSearchRequest1 Data Provider Class GetResultSet Method @51-7DC81634
    Public Sub Update(Items As ArrayList, ops As FormSupportedOperations)
        Dim i As Integer
        For i = 0 To Items.Count - 1
            Dim op As EditableGridOperation = EditableGridOperation.Insert
            Dim isProcessed As Boolean = False
            Dim item As viewMaintainSearchRequest1Item = CType(Items(i), viewMaintainSearchRequest1Item)
'End Grid viewMaintainSearchRequest1 Data Provider Class GetResultSet Method

'EditableGrid viewMaintainSearchRequest1 Data Provider Class Update @51-B4FF46D4
            If Not item.IsUpdated Then
                If Not(item.IsEmptyItem) And ops.AllowUpdate And Not(isProcessed) Then
                    UpdateItem(item)
                    op = EditableGridOperation.Update
                End If
'End EditableGrid viewMaintainSearchRequest1 Data Provider Class Update
            '2023-04-03|LG| after insert, do a small insert into the STUDENT_COMMENT to show comment that letter has been scheduled. Only add comment to items with rbGreenLetterSend = "I". Code charge saves every record when you edit a grid so be careful not to add the comment to all students.
			'2023-05-08|LG| modified to include comments for students who have been marked as No Letter
			If item.errors.Count = 0 AndAlso item.rbGreenLetterSend IsNot Nothing AndAlso (item.rbGreenLetterSend.Value = "I" Or item.rbGreenLetterSend.Value = "A"  ) Then
			      Try
                  Dim daysToAdd As Integer = (DayOfWeek.Thursday - Today.DayOfWeek + 7) Mod 7
                  Dim nextThursday = Today.AddDays(daysToAdd)

                  Dim commentText As String = if(item.rbGreenLetterSend.Value = "I",  $"Green letter requested by Learning Advisor. Letter scheduled to be sent on {nextThursday:dd/MM/yyyy}", "Green letter will NOT be sent. Student was marked as 'No Letter' on Advisory Group page by subject teacher.")
				      Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject

				      Dim Sql As String = $"insert into STUDENT_COMMENT ([COMMENT_ID],[STUDENT_ID],[COMMENT],[LAST_ALTERED_BY],[LAST_ALTERED_DATE],[ACTIVE_STATUS],[COMMENT_TYPE]) SELECT (select (max(COMMENT_ID+1)) from STUDENT_COMMENT) , " & NewDao.ToSql(item.STUDENT_ID.Value, FieldType._Text, True) & ", "& NewDao.ToSql(commentText,FieldType._Text) & ", "& NewDao.ToSql(DBUtility.UserLogin.ToUpper,FieldType._Text, True) & ", getdate(), 'A', 'REGULAR'"
				      NewDao.RunSql(Sql)
	              Catch ex As Exception
                     'LG|Basically a silent catch, I'm not sure how we handle errors here.
                     System.Diagnostics.Debug.WriteLine(ex.Message)
	              End Try
            End If
'EditableGrid viewMaintainSearchRequest1 Data Provider Class AfterUpdate @51-6CCB76B9
                If item.errors.Count = 0 Then item.IsUpdated = True
                OnItemUpdated(New ItemUpdatedEventArgs(op, item))
            End If
        Next i
    End Sub
'End EditableGrid viewMaintainSearchRequest1 Data Provider Class AfterUpdate

'EditableGrid viewMaintainSearchRequest1 Data Provider Class GetResultSet Method @51-38A3E1E1
    Public Function GetResultSet(ByRef _pagesCount As Integer, ops As FormSupportedOperations) As viewMaintainSearchRequest1Item()
'End EditableGrid viewMaintainSearchRequest1 Data Provider Class GetResultSet Method

'Before build Select @51-2F01C10A
        _pagesCount = 0
        Dim E as Exception = Nothing
        Dim j As Integer
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("UserId",SesUserId, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy = SortFieldsNames(CInt(SortField)).Trim
        Else
            Select_.OrderBy = SortFieldsNamesDesc(CInt(SortField)).Trim
        End If
    Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @51-939614DD
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

'After execute Select @51-5D59D5BF
                If Not IsNothing(E) Then Throw E
            End Try
            dr = ds.Tables(tableIndex).Rows
            rowCount = dr.Count
        End If
        Dim result(rowCount - 1) As viewMaintainSearchRequest1Item
'End After execute Select

'ListBox rbGreenLetterSend AfterExecuteSelect @114-AAE7AFE6
    Dim rbGreenLetterSendItems As ItemCollection = New ItemCollection()
    
rbGreenLetterSendItems.Add("I","Yes - Send")
rbGreenLetterSendItems.Add("A","No letter")
'End ListBox rbGreenLetterSend AfterExecuteSelect

'After execute Select tail @51-A91FE85F
        Dim i as Integer
        For i = 0 To rowCount - 1
            Dim item as viewMaintainSearchRequest1Item = New viewMaintainSearchRequest1Item()
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.STUDENT_IDHref = "Student_Comments_maintain.aspx"
            item.STUDENT_IDHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
            item.STUDENT_IDHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
            item.SURNAME.SetValue(dr(i)("SURNAME"),"")
            item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
            item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
            item.ENROLMENT_STATUS.SetValue(dr(i)("ENROLMENT_STATUS"),"")
            item.link_IntakeDone.SetValue(dr(i)("IntakeInterviewDisplay"),"")
            item.link_IntakeDoneHref = "Student_Comments_maintain.aspx"
            item.link_IntakeDoneHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
            item.link_IntakeDoneHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
            item.link_PathwaysDone.SetValue(dr(i)("PathwayProfileDisplay"),"")
            item.link_PathwaysDoneHref = "Student_Comments_maintain.aspx"
            item.link_PathwaysDoneHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
            item.link_PathwaysDoneHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
            item.ENROLMENT_DATE.SetValue(dr(i)("ENROLMENT_DATE"),Select_.DateFormat)
            item.hidden_days_since_enrolment.SetValue(dr(i)("days_since_enrolment"),"")
            item.rbGreenLetterSendItems = CType(rbGreenLetterSendItems.Clone(), ItemCollection)
            item.Link1Href = "StudentSummary.aspx"
            item.Link1HrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
            item.Link1HrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
            item.GREEN_LETTER_SENT_FLAG.SetValue(dr(i)("GREEN_LETTER_SENT_FLAG"),"")
            item.GREEN_LETTER_SENT_DATE.SetValue(dr(i)("GREEN_LETTER_SENT_DATE"),Select_.DateFormat)
            item.AMBER_LETTER_SENT_FLAG.SetValue(dr(i)("AMBER_LETTER_SENT_FLAG"),"")
            item.AMBER_LETTER_SENT_DATE.SetValue(dr(i)("AMBER_LETTER_SENT_DATE"),Select_.DateFormat)
            item.RED_LETTER_SENT_FLAG.SetValue(dr(i)("RED_LETTER_SENT_FLAG"),"")
            item.RED_LETTER_SENT_DATE.SetValue(dr(i)("RED_LETTER_SENT_DATE"),Select_.DateFormat)
            item.MandatedCohort.SetValue(dr(i)("MandatedCohort"),"")
            item.LearningPlan.SetValue(dr(i)("LEARNING_PROGRAM"),"")
            item.ENROLMENT_YEARField.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.STUDENT_IDField.SetValue(dr(i)("STUDENT_ID"),"")
            item.RawData = dr(i)
            result(i)=item
        Next i
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @51-A61BA892
End Class
'End Grid Data Provider tail

'EditableGrid viewMaintainSearchRequest2 Item Class @161-73BEE305
Public Class viewMaintainSearchRequest2Item
    Public errors As NameValueCollection = New NameValueCollection()
    Public RowId As Integer
    Private _deleteAllowed As Boolean = False
    Private _isNew As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public viewMaintainSearchRequest1_TotalRecords As TextField
    Public STUDENT_ID As FloatField
    Public STUDENT_IDHref As Object
    Public STUDENT_IDHrefParameters As LinkParameterCollection
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public YEAR_LEVEL As IntegerField
    Public ENROLMENT_STATUS As TextField
    Public lblPastoralID As TextField
    Public link_IntakeDone As TextField
    Public link_IntakeDoneHref As Object
    Public link_IntakeDoneHrefParameters As LinkParameterCollection
    Public link_PathwaysDone As TextField
    Public link_PathwaysDoneHref As Object
    Public link_PathwaysDoneHrefParameters As LinkParameterCollection
    Public ENROLMENT_DATE As DateField
    Public lblNewStudent As TextField
    Public hidden_days_since_enrolment As IntegerField
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public LAD As TextField
    Public CATEGORY_CODE As TextField
    Public rbGreenLetterSend As TextField
    Public rbGreenLetterSendItems As ItemCollection
    Public lblGreenLetter As TextField
    Public GREEN_LETTER_SENT_FLAG As TextField
    Public GREEN_LETTER_SENT_DATE As DateField
    Public AMBER_LETTER_SENT_FLAG As TextField
    Public AMBER_LETTER_SENT_DATE As DateField
    Public RED_LETTER_SENT_FLAG As TextField
    Public RED_LETTER_SENT_DATE As DateField
    Public MandatedCohort As TextField
    Public LearningPlan As TextField
    Public Sub New()
    viewMaintainSearchRequest1_TotalRecords = New TextField("", Nothing)
    STUDENT_ID = New FloatField("",Nothing)
    STUDENT_IDHrefParameters = New LinkParameterCollection()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    YEAR_LEVEL = New IntegerField("", Nothing)
    ENROLMENT_STATUS = New TextField("", Nothing)
    lblPastoralID = New TextField("", Nothing)
    link_IntakeDone = New TextField("",Nothing)
    link_IntakeDoneHrefParameters = New LinkParameterCollection()
    link_PathwaysDone = New TextField("",Nothing)
    link_PathwaysDoneHrefParameters = New LinkParameterCollection()
    ENROLMENT_DATE = New DateField("dd MMM yyyy", Nothing)
    lblNewStudent = New TextField("", Nothing)
    hidden_days_since_enrolment = New IntegerField("", Nothing)
    Link1 = New TextField("",Nothing)
    Link1HrefParameters = New LinkParameterCollection()
    LAD = New TextField("", Nothing)
    CATEGORY_CODE = New TextField("", Nothing)
    rbGreenLetterSend = New TextField("", "N")
    rbGreenLetterSendItems = New ItemCollection()
    lblGreenLetter = New TextField("", "<font color='green'>Done!</font>")
    GREEN_LETTER_SENT_FLAG = New TextField("", Nothing)
    GREEN_LETTER_SENT_DATE = New DateField("dd MMM yy", Nothing)
    AMBER_LETTER_SENT_FLAG = New TextField("", Nothing)
    AMBER_LETTER_SENT_DATE = New DateField("dd MMM yy", Nothing)
    RED_LETTER_SENT_FLAG = New TextField("", Nothing)
    RED_LETTER_SENT_DATE = New DateField("dd MMM yy", Nothing)
    MandatedCohort = New TextField("", Nothing)
    LearningPlan = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase
        Get
            Select fieldName
                Case "ENROLMENT_YEARField"
                    Return Me.ENROLMENT_YEARField
                Case "STUDENT_IDField"
                    Return Me.STUDENT_IDField
                Case "viewMaintainSearchRequest1_TotalRecords"
                    Return Me.viewMaintainSearchRequest1_TotalRecords
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "YEAR_LEVEL"
                    Return Me.YEAR_LEVEL
                Case "ENROLMENT_STATUS"
                    Return Me.ENROLMENT_STATUS
                Case "lblPastoralID"
                    Return Me.lblPastoralID
                Case "link_IntakeDone"
                    Return Me.link_IntakeDone
                Case "link_PathwaysDone"
                    Return Me.link_PathwaysDone
                Case "ENROLMENT_DATE"
                    Return Me.ENROLMENT_DATE
                Case "lblNewStudent"
                    Return Me.lblNewStudent
                Case "hidden_days_since_enrolment"
                    Return Me.hidden_days_since_enrolment
                Case "Link1"
                    Return Me.Link1
                Case "LAD"
                    Return Me.LAD
                Case "CATEGORY_CODE"
                    Return Me.CATEGORY_CODE
                Case "rbGreenLetterSend"
                    Return Me.rbGreenLetterSend
                Case "lblGreenLetter"
                    Return Me.lblGreenLetter
                Case "GREEN_LETTER_SENT_FLAG"
                    Return Me.GREEN_LETTER_SENT_FLAG
                Case "GREEN_LETTER_SENT_DATE"
                    Return Me.GREEN_LETTER_SENT_DATE
                Case "AMBER_LETTER_SENT_FLAG"
                    Return Me.AMBER_LETTER_SENT_FLAG
                Case "AMBER_LETTER_SENT_DATE"
                    Return Me.AMBER_LETTER_SENT_DATE
                Case "RED_LETTER_SENT_FLAG"
                    Return Me.RED_LETTER_SENT_FLAG
                Case "RED_LETTER_SENT_DATE"
                    Return Me.RED_LETTER_SENT_DATE
                Case "MandatedCohort"
                    Return Me.MandatedCohort
                Case "LearningPlan"
                    Return Me.LearningPlan
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ENROLMENT_YEARField"
                    Me.ENROLMENT_YEARField = CType(Value,FloatField)
                Case "STUDENT_IDField"
                    Me.STUDENT_IDField = CType(Value,IntegerField)
                Case "viewMaintainSearchRequest1_TotalRecords"
                    Me.viewMaintainSearchRequest1_TotalRecords = CType(Value,TextField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "YEAR_LEVEL"
                    Me.YEAR_LEVEL = CType(Value,IntegerField)
                Case "ENROLMENT_STATUS"
                    Me.ENROLMENT_STATUS = CType(Value,TextField)
                Case "lblPastoralID"
                    Me.lblPastoralID = CType(Value,TextField)
                Case "link_IntakeDone"
                    Me.link_IntakeDone = CType(Value,TextField)
                Case "link_PathwaysDone"
                    Me.link_PathwaysDone = CType(Value,TextField)
                Case "ENROLMENT_DATE"
                    Me.ENROLMENT_DATE = CType(Value,DateField)
                Case "lblNewStudent"
                    Me.lblNewStudent = CType(Value,TextField)
                Case "hidden_days_since_enrolment"
                    Me.hidden_days_since_enrolment = CType(Value,IntegerField)
                Case "Link1"
                    Me.Link1 = CType(Value,TextField)
                Case "LAD"
                    Me.LAD = CType(Value,TextField)
                Case "CATEGORY_CODE"
                    Me.CATEGORY_CODE = CType(Value,TextField)
                Case "rbGreenLetterSend"
                    Me.rbGreenLetterSend = CType(Value,TextField)
                Case "lblGreenLetter"
                    Me.lblGreenLetter = CType(Value,TextField)
                Case "GREEN_LETTER_SENT_FLAG"
                    Me.GREEN_LETTER_SENT_FLAG = CType(Value,TextField)
                Case "GREEN_LETTER_SENT_DATE"
                    Me.GREEN_LETTER_SENT_DATE = CType(Value,DateField)
                Case "AMBER_LETTER_SENT_FLAG"
                    Me.AMBER_LETTER_SENT_FLAG = CType(Value,TextField)
                Case "AMBER_LETTER_SENT_DATE"
                    Me.AMBER_LETTER_SENT_DATE = CType(Value,DateField)
                Case "RED_LETTER_SENT_FLAG"
                    Me.RED_LETTER_SENT_FLAG = CType(Value,TextField)
                Case "RED_LETTER_SENT_DATE"
                    Me.RED_LETTER_SENT_DATE = CType(Value,DateField)
                Case "MandatedCohort"
                    Me.MandatedCohort = CType(Value,TextField)
                Case "LearningPlan"
                    Me.LearningPlan = CType(Value,TextField)
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
            result = IsNothing(hidden_days_since_enrolment.Value) And result
            result = IsNothing(rbGreenLetterSend.Value) And result
            Return result
        End Get
    End Property

    Public IsDeleted As Boolean = False
    Public IsUpdated As Boolean = False
    Public ENROLMENT_YEARField As FloatField = New FloatField()
    Public STUDENT_IDField As IntegerField = New IntegerField()
    Public Function Validate(ByVal provider As viewMaintainSearchRequest2DataProvider) As Boolean
'End EditableGrid viewMaintainSearchRequest2 Item Class

'EditableGrid viewMaintainSearchRequest2 Item Class tail @161-11D8DCF0
        Return errors.Count = 0
    End Function
    Public RawData As DataRow = Nothing
End Class
'End EditableGrid viewMaintainSearchRequest2 Item Class tail

'EditableGrid viewMaintainSearchRequest2 Data Provider Class Header @161-F7DEF69C
Public Class viewMaintainSearchRequest2DataProvider
Inherits EditableGridDataProviderBase
'End EditableGrid viewMaintainSearchRequest2 Data Provider Class Header

'Grid viewMaintainSearchRequest2 Data Provider Class Variables @161-39A3E4C7

    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_ID
        Sorter_SURNAME
        Sorter_FIRST_NAME
        Sorter_YEAR_LEVEL
        Sorter_ENROLMENT_STATUS
        Sorter_ENROLMENT_DATE
        Sorter_LADID
        Sorter_CATEGORY_CODE
    End Enum

    Private SortFieldsNames As String() = New String() {"","STUDENT_ID","SURNAME","FIRST_NAME","YEAR_LEVEL","ENROLMENT_STATUS","ENROLMENT_DATE","PASTORAL_CARE_ID","CATEGORY_CODE"}
    Private SortFieldsNamesDesc As String() = New string() {"","STUDENT_ID DESC","SURNAME DESC","FIRST_NAME DESC","YEAR_LEVEL DESC","ENROLMENT_STATUS DESC","ENROLMENT_DATE DESC","PASTORAL_CARE_ID DESC","CATEGORY_CODE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 100
    Public PageNumber As Integer = 1
    Public CtrlrbGreenLetterSend  As TextParameter
    Public Expr234  As DateParameter
    Public UrlRETURN_VALUE  As IntegerParameter
    Public SesUserId  As TextParameter
'End Grid viewMaintainSearchRequest2 Data Provider Class Variables

'EditableGrid viewMaintainSearchRequest2 Data Provider Class Constructor @161-204F0EAB

    Public Sub New()
        Select_=new SqlCommand("select" & vbCrLf & _
          "   subq.*," & vbCrLf & _
          "   concat(subq.PSDFunded, subq.NCCDFunded, subq.HouseholdStatus, subq.ATSIStatus, subq.You" & _
          "thJustice, subq.AcademicLag) as MandatedCohort" & vbCrLf & _
          " from" & vbCrLf & _
          " (" & vbCrLf & _
          "    select" & vbCrLf & _
          "       vw.*," & vbCrLf & _
          "       iif((smd.PSD_FUNDING_ASSESSED = 1)" & vbCrLf & _
          "                   or (smd.PSD_FUNDING_ELIGIBLE = 1)" & vbCrLf & _
          "                   or (smd.PSD_FUNDING_LEVEL is not null)" & vbCrLf & _
          "                   or (len(smd.PSD_FUNDING_CATEGORY) > 2)" & vbCrLf & _
          "                   or (smd.RECEIVED_SUPPORT_PROGRAMS_SERVICES like '%,PSD%')," & vbCrLf & _
          "       'PSD Funded; '," & vbCrLf & _
          "       '') as PSDFunded," & vbCrLf & _
          "       iif((smd.NCCD_FUNDING_APPROVED = 1)" & vbCrLf & _
          "                   or (smd.NCCD_FUNDING_CATEGORY is not null)" & vbCrLf & _
          "                   or (smd.NCCD_FUNDING_LEVEL is not null), 'NCCD Funded; ', '') as NCCDFu" & _
          "nded," & vbCrLf & _
          "       iif(scd.HOUSEHOLD_STATUS in (3, 6, 7), concat(vhs.HouseholdStatusDisplayText, '; ')" & _
          ", '') as HouseholdStatus," & vbCrLf & _
          "       iif(scd.KOORITORRESFLAG in ('K', 'B', 'T'), 'Indigenous; ', '') as ATSIStatus," & vbCrLf & _
          "       iif(scd.YOUTH_JUSTICE_INVOLVEMENT = 1, 'Youth Justice; ', '') as YouthJustice," & vbCrLf & _
          "       iif(eas.AcademicLag = 1, 'Assessed as two years or more below expected level; ', ''" & _
          ") as AcademicLag" & vbCrLf & _
          "     from" & vbCrLf & _
          "       dbo.viewMaintainSearchRequest_SupportTeacher as vw" & vbCrLf & _
          "       left join dbo.EARLY_ASSESSMENT_STUDENT as eas" & vbCrLf & _
          "          on (" & vbCrLf & _
          "                (eas.STUDENT_ID = vw.STUDENT_ID)" & vbCrLf & _
          "                and (eas.ENROLMENT_YEAR = vw.ENROLMENT_YEAR)" & vbCrLf & _
          "             )" & vbCrLf & _
          "       left join dbo.STUDENT_CENSUS_DATA as scd" & vbCrLf & _
          "          on (scd.STUDENT_ID = vw.STUDENT_ID)" & vbCrLf & _
          "       left join dbo.STUDENT_MEDICAL_DETAILS as smd" & vbCrLf & _
          "          on (smd.STUDENT_ID = vw.STUDENT_ID)" & vbCrLf & _
          "       left join dbo.vwHouseholdStatus as vhs" & vbCrLf & _
          "          on (vhs.HouseholdStatusValue = scd.HOUSEHOLD_STATUS)" & vbCrLf & _
          "     where" & vbCrLf & _
          "       (vw.ENROLMENT_YEAR = year(getdate()))" & vbCrLf & _
          "       and (vw.ENROLMENT_STATUS = 'E')" & vbCrLf & _
          "       and (vw.PASTORAL_CARE_ID = 'NO_SST')" & vbCrLf & _
          "       and exists" & vbCrLf & _
          "     (" & vbCrLf & _
          "        select" & vbCrLf & _
          "           *" & vbCrLf & _
          "         from" & vbCrLf & _
          "           dbo.STUDENT_SUBJECT as ss" & vbCrLf & _
          "         where" & vbCrLf & _
          "           (ss.STUDENT_ID = vw.STUDENT_ID)" & vbCrLf & _
          "           and (ss.ENROLMENT_YEAR = vw.ENROLMENT_YEAR)" & vbCrLf & _
          "           and (ss.SEMESTER in ('B', iif(month(getdate()) < 6, '1', '2')))" & vbCrLf & _
          "           and (ss.SUBJ_ENROL_STATUS in ('C', 'P', 'D'))" & vbCrLf & _
          "           and (ss.SUBJECT_ID < 900)" & vbCrLf & _
          "           and (ss.STAFF_ID = '{UserId}')" & vbCrLf & _
          "     )" & vbCrLf & _
          " ) as subq",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (select" & vbCrLf & _
          "   subq.*," & vbCrLf & _
          "   concat(subq.PSDFunded, subq.NCCDFunded, subq.HouseholdStatus, subq.ATSIStatus, subq.You" & _
          "thJustice, subq.AcademicLag) as MandatedCohort" & vbCrLf & _
          " from" & vbCrLf & _
          " (" & vbCrLf & _
          "    select" & vbCrLf & _
          "       vw.*," & vbCrLf & _
          "       iif((smd.PSD_FUNDING_ASSESSED = 1)" & vbCrLf & _
          "                   or (smd.PSD_FUNDING_ELIGIBLE = 1)" & vbCrLf & _
          "                   or (smd.PSD_FUNDING_LEVEL is not null)" & vbCrLf & _
          "                   or (len(smd.PSD_FUNDING_CATEGORY) > 2)" & vbCrLf & _
          "                   or (smd.RECEIVED_SUPPORT_PROGRAMS_SERVICES like '%,PSD%')," & vbCrLf & _
          "       'PSD Funded; '," & vbCrLf & _
          "       '') as PSDFunded," & vbCrLf & _
          "       iif((smd.NCCD_FUNDING_APPROVED = 1)" & vbCrLf & _
          "                   or (smd.NCCD_FUNDING_CATEGORY is not null)" & vbCrLf & _
          "                   or (smd.NCCD_FUNDING_LEVEL is not null), 'NCCD Funded; ', '') as NCCDFu" & _
          "nded," & vbCrLf & _
          "       iif(scd.HOUSEHOLD_STATUS in (3, 6, 7), concat(vhs.HouseholdStatusDisplayText, '; ')" & _
          ", '') as HouseholdStatus," & vbCrLf & _
          "       iif(scd.KOORITORRESFLAG in ('K', 'B', 'T'), 'Indigenous; ', '') as ATSIStatus," & vbCrLf & _
          "       iif(scd.YOUTH_JUSTICE_INVOLVEMENT = 1, 'Youth Justice; ', '') as YouthJustice," & vbCrLf & _
          "       iif(eas.AcademicLag = 1, 'Assessed as two years or more below expected level; ', ''" & _
          ") as AcademicLag" & vbCrLf & _
          "     from" & vbCrLf & _
          "       dbo.viewMaintainSearchRequest_SupportTeacher as vw" & vbCrLf & _
          "       left join dbo.EARLY_ASSESSMENT_STUDENT as eas" & vbCrLf & _
          "          on (" & vbCrLf & _
          "                (eas.STUDENT_ID = vw.STUDENT_ID)" & vbCrLf & _
          "                and (eas.ENROLMENT_YEAR = vw.ENROLMENT_YEAR)" & vbCrLf & _
          "             )" & vbCrLf & _
          "       left join dbo.STUDENT_CENSUS_DATA as scd" & vbCrLf & _
          "          on (scd.STUDENT_ID = vw.STUDENT_ID)" & vbCrLf & _
          "       left join dbo.STUDENT_MEDICAL_DETAILS as smd" & vbCrLf & _
          "          on (smd.STUDENT_ID = vw.STUDENT_ID)" & vbCrLf & _
          "       left join dbo.vwHouseholdStatus as vhs" & vbCrLf & _
          "          on (vhs.HouseholdStatusValue = scd.HOUSEHOLD_STATUS)" & vbCrLf & _
          "     where" & vbCrLf & _
          "       (vw.ENROLMENT_YEAR = year(getdate()))" & vbCrLf & _
          "       and (vw.ENROLMENT_STATUS = 'E')" & vbCrLf & _
          "       and (vw.PASTORAL_CARE_ID = 'NO_SST')" & vbCrLf & _
          "       and exists" & vbCrLf & _
          "     (" & vbCrLf & _
          "        select" & vbCrLf & _
          "           *" & vbCrLf & _
          "         from" & vbCrLf & _
          "           dbo.STUDENT_SUBJECT as ss" & vbCrLf & _
          "         where" & vbCrLf & _
          "           (ss.STUDENT_ID = vw.STUDENT_ID)" & vbCrLf & _
          "           and (ss.ENROLMENT_YEAR = vw.ENROLMENT_YEAR)" & vbCrLf & _
          "           and (ss.SEMESTER in ('B', iif(month(getdate()) < 6, '1', '2')))" & vbCrLf & _
          "           and (ss.SUBJ_ENROL_STATUS in ('C', 'P', 'D'))" & vbCrLf & _
          "           and (ss.SUBJECT_ID < 900)" & vbCrLf & _
          "           and (ss.STAFF_ID = '{UserId}')" & vbCrLf & _
          "     )" & vbCrLf & _
          " ) as subq) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End EditableGrid viewMaintainSearchRequest2 Data Provider Class Constructor

'Record viewMaintainSearchRequest2 Data Provider Class CheckUnique Method @161-47567101

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As viewMaintainSearchRequest2Item) As Boolean
        Return True
    End Function
'End Record viewMaintainSearchRequest2 Data Provider Class CheckUnique Method

'EditableGrid viewMaintainSearchRequest2 Data Provider Class Update Method @161-4FB41EDF
    Protected Function UpdateItem(ByVal item As viewMaintainSearchRequest2Item) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        IsParametersPassed = Not(IsNothing(item.STUDENT_IDField) Or IsNothing(item.ENROLMENT_YEARField))
        Dim Update As DataCommand=new TableCommand("UPDATE student_subject SET {Values}", New String(){"STUDENT_ID229","And","expr230","And","ENROLMENT_YEAR231","And","expr232"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End EditableGrid viewMaintainSearchRequest2 Data Provider Class Update Method

'EditableGrid viewMaintainSearchRequest2 BeforeBuildUpdate @161-596AB211
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID229",item.STUDENT_IDField, "","STUDENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ENROLMENT_YEAR231",item.ENROLMENT_YEARField, "","ENROLMENT_YEAR",Condition.Equal,False)
        Update.Parameters.Add("expr230","(SUBJ_ENROL_STATUS in ('C','D'))")
        Update.Parameters.Add("expr232","(SUBJECT_ID not in (select vis.IntroductorySubjectID from dbo.vwIntroductorySubject as vis where (vis.IntroductorySubjectStatus = 1)) )")
        allEmptyFlag = item.rbGreenLetterSend.IsEmpty And allEmptyFlag
        If Not item.rbGreenLetterSend.IsEmpty Then
        If IsNothing(item.rbGreenLetterSend.Value) Then
        valuesList = valuesList & "DEFAULTING_STATUS=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "DEFAULTING_STATUS=" & Update.Dao.ToSql(item.rbGreenLetterSend.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = (Expr234 Is Nothing) And allEmptyFlag
        If Not (Expr234 Is Nothing) Then
        If IsNothing(Expr234) Then
        valuesList = valuesList & "DEFAULTING_STATUS_DATE=" & Update.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        valuesList = valuesList & "DEFAULTING_STATUS_DATE=" & Update.Dao.ToSql(Expr234.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        End If
		Update.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
'End EditableGrid viewMaintainSearchRequest2 BeforeBuildUpdate


'EditableGrid viewMaintainSearchRequest2 Event BeforeExecuteUpdate. Action Custom Code @281-73254650
      ' -------------------------
       'ERA: 16-July-2017|EA| handle non-values of rbGreenLetterSend - don't update record if nothing chosen)
  		If (item.rbGreenLetterSend.Value = "" or IsNothing(item.rbGreenLetterSend.Value)) Then
  			CmdExecution = false
  		end if
      ' -------------------------
'End EditableGrid viewMaintainSearchRequest2 Event BeforeExecuteUpdate. Action Custom Code

'EditableGrid viewMaintainSearchRequest2 Execute Update  @161-392E25E7
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
'End EditableGrid viewMaintainSearchRequest2 Execute Update 

'EditableGrid viewMaintainSearchRequest2 AfterExecuteUpdate @161-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid viewMaintainSearchRequest2 AfterExecuteUpdate

'Grid viewMaintainSearchRequest2 Data Provider Class GetResultSet Method @161-4109608D
    Public Sub Update(Items As ArrayList, ops As FormSupportedOperations)
        Dim i As Integer
        For i = 0 To Items.Count - 1
            Dim op As EditableGridOperation = EditableGridOperation.Insert
            Dim isProcessed As Boolean = False
            Dim item As viewMaintainSearchRequest2Item = CType(Items(i), viewMaintainSearchRequest2Item)
'End Grid viewMaintainSearchRequest2 Data Provider Class GetResultSet Method

'EditableGrid viewMaintainSearchRequest2 Data Provider Class Update @161-B4FF46D4
            If Not item.IsUpdated Then
                If Not(item.IsEmptyItem) And ops.AllowUpdate And Not(isProcessed) Then
                    UpdateItem(item)
                    op = EditableGridOperation.Update
                End If
'End EditableGrid viewMaintainSearchRequest2 Data Provider Class Update
            '2023-05-08|LG| after insert, do a small insert into the STUDENT_COMMENT to show comment that letter has been scheduled or marked as no. Only add comment to items with rbGreenLetterSend = "I"/"A". Code charge saves every record when you edit a grid so be careful not to add the comment to all students.
            'This functionality was added earlier for LAD students and now works for SST anwell

			If item.errors.Count = 0 AndAlso item.rbGreenLetterSend IsNot Nothing AndAlso (item.rbGreenLetterSend.Value = "I" Or item.rbGreenLetterSend.Value = "A"  ) Then
			      Try
                  Dim daysToAdd As Integer = (DayOfWeek.Thursday - Today.DayOfWeek + 7) Mod 7
                  Dim nextThursday = Today.AddDays(daysToAdd)

                  Dim commentText As String = if(item.rbGreenLetterSend.Value = "I",  $"Green letter requested by subject teacher. Letter scheduled to be sent on {nextThursday:dd/MM/yyyy}", "Green letter will NOT be sent. Student was marked as 'No Letter' on Advisory Group page by subject teacher.")
				      Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject

				      Dim Sql As String = $"insert into STUDENT_COMMENT ([COMMENT_ID],[STUDENT_ID],[COMMENT],[LAST_ALTERED_BY],[LAST_ALTERED_DATE],[ACTIVE_STATUS],[COMMENT_TYPE]) SELECT (select (max(COMMENT_ID+1)) from STUDENT_COMMENT) , " & NewDao.ToSql(item.STUDENT_ID.Value, FieldType._Text, True) & ", "& NewDao.ToSql(commentText,FieldType._Text) & ", "& NewDao.ToSql(DBUtility.UserLogin.ToUpper,FieldType._Text, True) & ", getdate(), 'A', 'REGULAR'"
				      NewDao.RunSql(Sql)
	              Catch ex As Exception
                     'LG|Basically a silent catch, I'm not sure how we handle errors here.
                     System.Diagnostics.Debug.WriteLine(ex.Message)
	              End Try
            End If
'EditableGrid viewMaintainSearchRequest2 Data Provider Class AfterUpdate @161-6CCB76B9
                If item.errors.Count = 0 Then item.IsUpdated = True
                OnItemUpdated(New ItemUpdatedEventArgs(op, item))
            End If
        Next i
    End Sub
'End EditableGrid viewMaintainSearchRequest2 Data Provider Class AfterUpdate

'EditableGrid viewMaintainSearchRequest2 Data Provider Class GetResultSet Method @161-094BFB7C
    Public Function GetResultSet(ByRef _pagesCount As Integer, ops As FormSupportedOperations) As viewMaintainSearchRequest2Item()
'End EditableGrid viewMaintainSearchRequest2 Data Provider Class GetResultSet Method

'Before build Select @161-2F01C10A
        _pagesCount = 0
        Dim E as Exception = Nothing
        Dim j As Integer
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("UserId",SesUserId, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy = SortFieldsNames(CInt(SortField)).Trim
        Else
            Select_.OrderBy = SortFieldsNamesDesc(CInt(SortField)).Trim
        End If
    Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @161-939614DD
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

'After execute Select @161-1AF9AF6F
                If Not IsNothing(E) Then Throw E
            End Try
            dr = ds.Tables(tableIndex).Rows
            rowCount = dr.Count
        End If
        Dim result(rowCount - 1) As viewMaintainSearchRequest2Item
'End After execute Select

'ListBox rbGreenLetterSend AfterExecuteSelect @258-AAE7AFE6
    Dim rbGreenLetterSendItems As ItemCollection = New ItemCollection()
    
rbGreenLetterSendItems.Add("I","Yes - Send")
rbGreenLetterSendItems.Add("A","No letter")
'End ListBox rbGreenLetterSend AfterExecuteSelect

'After execute Select tail @161-2C50B015
        Dim i as Integer
        For i = 0 To rowCount - 1
            Dim item as viewMaintainSearchRequest2Item = New viewMaintainSearchRequest2Item()
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.STUDENT_IDHref = "Student_Comments_maintain.aspx"
            item.STUDENT_IDHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
            item.STUDENT_IDHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
            item.SURNAME.SetValue(dr(i)("SURNAME"),"")
            item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
            item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
            item.ENROLMENT_STATUS.SetValue(dr(i)("ENROLMENT_STATUS"),"")
            item.link_IntakeDone.SetValue(dr(i)("IntakeInterviewDisplay"),"")
            item.link_IntakeDoneHref = "Student_Comments_maintain.aspx"
            item.link_IntakeDoneHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
            item.link_IntakeDoneHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
            item.link_PathwaysDone.SetValue(dr(i)("PathwayProfileDisplay"),"")
            item.link_PathwaysDoneHref = "Student_Comments_maintain.aspx"
            item.link_PathwaysDoneHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
            item.link_PathwaysDoneHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
            item.ENROLMENT_DATE.SetValue(dr(i)("ENROLMENT_DATE"),Select_.DateFormat)
            item.hidden_days_since_enrolment.SetValue(dr(i)("days_since_enrolment"),"")
            item.Link1Href = "StudentSummary.aspx"
            item.Link1HrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
            item.Link1HrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
            item.LAD.SetValue(dr(i)("PASTORAL_CARE_ID"),"")
            item.CATEGORY_CODE.SetValue(dr(i)("CATEGORY_CODE"),"")
            item.rbGreenLetterSendItems = CType(rbGreenLetterSendItems.Clone(), ItemCollection)
            item.GREEN_LETTER_SENT_FLAG.SetValue(dr(i)("GREEN_LETTER_SENT_FLAG"),"")
            item.GREEN_LETTER_SENT_DATE.SetValue(dr(i)("GREEN_LETTER_SENT_DATE"),Select_.DateFormat)
            item.AMBER_LETTER_SENT_FLAG.SetValue(dr(i)("AMBER_LETTER_SENT_FLAG"),"")
            item.AMBER_LETTER_SENT_DATE.SetValue(dr(i)("AMBER_LETTER_SENT_DATE"),Select_.DateFormat)
            item.RED_LETTER_SENT_FLAG.SetValue(dr(i)("RED_LETTER_SENT_FLAG"),"")
            item.RED_LETTER_SENT_DATE.SetValue(dr(i)("RED_LETTER_SENT_DATE"),Select_.DateFormat)
            item.MandatedCohort.SetValue(dr(i)("MandatedCohort"),"")
            item.LearningPlan.SetValue(dr(i)("LEARNING_PROGRAM"),"")
            item.ENROLMENT_YEARField.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.STUDENT_IDField.SetValue(dr(i)("STUDENT_ID"),"")
            item.RawData = dr(i)
            result(i)=item
        Next i
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @161-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

