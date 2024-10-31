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

Namespace DECV_PROD2007.Student_Profile_PLSP 'Namespace @1-48F539BB

'Page Data Class @1-9DBCC9EC
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Link_Backtosummary As TextField
    Public Link_BacktosummaryHref As Object
    Public Link_BacktosummaryHrefParameters As LinkParameterCollection
    Public Sub New()
        Link_Backtosummary = New TextField("",Nothing)
        Link_BacktosummaryHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Link_Backtosummary.SetValue(DBUtility.GetInitialValue("Link_Backtosummary"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Link_Backtosummary"
                    Return Link_Backtosummary
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link_Backtosummary"
                    Link_Backtosummary = CType(value, TextField)
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

'Record STUDENT_PROFILE1 Item Class @3-C2F93E83
Public Class STUDENT_PROFILE1Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public STUDENT_ID As FloatField
    Public ENROLMENT_YEAR As FloatField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public LAUNCH_PAD_DONE As TextField
    Public LAUNCH_PAD_DONEItems As ItemCollection
    Public LAUNCH_PAD_DONE_DATE As DateField
    Public LEARNING_PROGRAM As TextField
    Public LEARNING_PROGRAM_DETAILS As TextField
    Public LEARNING_PROGRAM_CONSULT As TextField
    Public LEARNING_PROGRAM_CONSULTItems As ItemCollection
    Public SPECIAL_PROVISION_FLAG As TextField
    Public SPECIAL_PROVISION_FLAGItems As ItemCollection
    Public SPECIAL_PROVISION_DETAILS As TextField
    Public REVIEW_PROGRESS_END_SEM1 As TextField
    Public REVIEW_PROGRESS_END_SEM2 As TextField
    Public lblLearningProgram As TextField
    Public lblStudentID As TextField
    Public lblEnrolYear As TextField
    Public LAST_ALTERED_BY1 As TextField
    Public LAST_ALTERED_DATE1 As DateField
    Public hidden_LastUpdatedBy As TextField
    Public hidden_LastUpdatedWhen As DateField
    Public Hidden_LEARNING_PROGRAM_CONSULT As TextField
    Public ASSESS_ENGLANG_LP As TextField
    Public ASSESS_ENGLANG_RL As TextField
    Public ASSESS_MATH_LP As TextField
    Public ASSESS_MATH_RL As TextField
    Public ASSESS_PATSCIENCE_LP As TextField
    Public ASSESS_PATSCIENCE_RL As TextField
    Public error_AssessData As TextField
    Public error_LearnDetails As TextField
    Public error_LearnGoals As TextField
    Public error_SpecialProvision As TextField
    Public error_ProgressSem1 As TextField
    Public error_ProgressSem2 As TextField
    Public cbENROL_FILE_CHECKED As TextField
    Public cbENROL_FILE_CHECKEDCheckedValue As TextField
    Public cbENROL_FILE_CHECKEDUncheckedValue As TextField
    Public error_LPDone As TextField
    Public Sub New()
    STUDENT_ID = New FloatField("", Nothing)
    ENROLMENT_YEAR = New FloatField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    LAUNCH_PAD_DONE = New TextField("", Nothing)
    LAUNCH_PAD_DONEItems = New ItemCollection()
    LAUNCH_PAD_DONE_DATE = New DateField("d\/M\/yyyy", Nothing)
    LEARNING_PROGRAM = New TextField("", Nothing)
    LEARNING_PROGRAM_DETAILS = New TextField("", Nothing)
    LEARNING_PROGRAM_CONSULT = New TextField("", Nothing)
    LEARNING_PROGRAM_CONSULTItems = New ItemCollection()
    SPECIAL_PROVISION_FLAG = New TextField("", Nothing)
    SPECIAL_PROVISION_FLAGItems = New ItemCollection()
    SPECIAL_PROVISION_DETAILS = New TextField("", Nothing)
    REVIEW_PROGRESS_END_SEM1 = New TextField("", Nothing)
    REVIEW_PROGRESS_END_SEM2 = New TextField("", Nothing)
    lblLearningProgram = New TextField("", "not determined yet")
    lblStudentID = New TextField("", <font color='RED'>Not saved yet</font>)
    lblEnrolYear = New TextField("", Nothing)
    LAST_ALTERED_BY1 = New TextField("", Nothing)
    LAST_ALTERED_DATE1 = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    hidden_LastUpdatedBy = New TextField("", DBUtility.UserID.ToUpper)
    hidden_LastUpdatedWhen = New DateField("yyyy-MM-dd H\:mm", DateTime.Now)
    Hidden_LEARNING_PROGRAM_CONSULT = New TextField("", "0,")
    ASSESS_ENGLANG_LP = New TextField("", Nothing)
    ASSESS_ENGLANG_RL = New TextField("", Nothing)
    ASSESS_MATH_LP = New TextField("", Nothing)
    ASSESS_MATH_RL = New TextField("", Nothing)
    ASSESS_PATSCIENCE_LP = New TextField("", Nothing)
    ASSESS_PATSCIENCE_RL = New TextField("", Nothing)
    error_AssessData = New TextField("", Nothing)
    error_LearnDetails = New TextField("", Nothing)
    error_LearnGoals = New TextField("", Nothing)
    error_SpecialProvision = New TextField("", Nothing)
    error_ProgressSem1 = New TextField("", Nothing)
    error_ProgressSem2 = New TextField("", Nothing)
    cbENROL_FILE_CHECKED = New TextField("", "N")
    cbENROL_FILE_CHECKEDCheckedValue = New TextField("", "Y")
    cbENROL_FILE_CHECKEDUncheckedValue = New TextField("", "N")
    error_LPDone = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_PROFILE1Item
        Dim item As STUDENT_PROFILE1Item = New STUDENT_PROFILE1Item()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_YEAR")) Then
        item.ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAUNCH_PAD_DONE")) Then
        item.LAUNCH_PAD_DONE.SetValue(DBUtility.GetInitialValue("LAUNCH_PAD_DONE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAUNCH_PAD_DONE_DATE")) Then
        item.LAUNCH_PAD_DONE_DATE.SetValue(DBUtility.GetInitialValue("LAUNCH_PAD_DONE_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LEARNING_PROGRAM")) Then
        item.LEARNING_PROGRAM.SetValue(DBUtility.GetInitialValue("LEARNING_PROGRAM"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LEARNING_PROGRAM_DETAILS")) Then
        item.LEARNING_PROGRAM_DETAILS.SetValue(DBUtility.GetInitialValue("LEARNING_PROGRAM_DETAILS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LEARNING_PROGRAM_CONSULT")) Then
        item.LEARNING_PROGRAM_CONSULT.SetValue(DBUtility.GetInitialValue("LEARNING_PROGRAM_CONSULT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SPECIAL_PROVISION_FLAG")) Then
        item.SPECIAL_PROVISION_FLAG.SetValue(DBUtility.GetInitialValue("SPECIAL_PROVISION_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SPECIAL_PROVISION_DETAILS")) Then
        item.SPECIAL_PROVISION_DETAILS.SetValue(DBUtility.GetInitialValue("SPECIAL_PROVISION_DETAILS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("REVIEW_PROGRESS_END_SEM1")) Then
        item.REVIEW_PROGRESS_END_SEM1.SetValue(DBUtility.GetInitialValue("REVIEW_PROGRESS_END_SEM1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("REVIEW_PROGRESS_END_SEM2")) Then
        item.REVIEW_PROGRESS_END_SEM2.SetValue(DBUtility.GetInitialValue("REVIEW_PROGRESS_END_SEM2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblLearningProgram")) Then
        item.lblLearningProgram.SetValue(DBUtility.GetInitialValue("lblLearningProgram"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblStudentID")) Then
        item.lblStudentID.SetValue(DBUtility.GetInitialValue("lblStudentID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblEnrolYear")) Then
        item.lblEnrolYear.SetValue(DBUtility.GetInitialValue("lblEnrolYear"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY1")) Then
        item.LAST_ALTERED_BY1.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE1")) Then
        item.LAST_ALTERED_DATE1.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert2")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update2")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel2")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LastUpdatedBy")) Then
        item.hidden_LastUpdatedBy.SetValue(DBUtility.GetInitialValue("hidden_LastUpdatedBy"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LastUpdatedWhen")) Then
        item.hidden_LastUpdatedWhen.SetValue(DBUtility.GetInitialValue("hidden_LastUpdatedWhen"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_LEARNING_PROGRAM_CONSULT")) Then
        item.Hidden_LEARNING_PROGRAM_CONSULT.SetValue(DBUtility.GetInitialValue("Hidden_LEARNING_PROGRAM_CONSULT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ASSESS_ENGLANG_LP")) Then
        item.ASSESS_ENGLANG_LP.SetValue(DBUtility.GetInitialValue("ASSESS_ENGLANG_LP"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ASSESS_ENGLANG_RL")) Then
        item.ASSESS_ENGLANG_RL.SetValue(DBUtility.GetInitialValue("ASSESS_ENGLANG_RL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ASSESS_MATH_LP")) Then
        item.ASSESS_MATH_LP.SetValue(DBUtility.GetInitialValue("ASSESS_MATH_LP"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ASSESS_MATH_RL")) Then
        item.ASSESS_MATH_RL.SetValue(DBUtility.GetInitialValue("ASSESS_MATH_RL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ASSESS_PATSCIENCE_LP")) Then
        item.ASSESS_PATSCIENCE_LP.SetValue(DBUtility.GetInitialValue("ASSESS_PATSCIENCE_LP"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ASSESS_PATSCIENCE_RL")) Then
        item.ASSESS_PATSCIENCE_RL.SetValue(DBUtility.GetInitialValue("ASSESS_PATSCIENCE_RL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_AssessData")) Then
        item.error_AssessData.SetValue(DBUtility.GetInitialValue("error_AssessData"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_LearnDetails")) Then
        item.error_LearnDetails.SetValue(DBUtility.GetInitialValue("error_LearnDetails"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_LearnGoals")) Then
        item.error_LearnGoals.SetValue(DBUtility.GetInitialValue("error_LearnGoals"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_SpecialProvision")) Then
        item.error_SpecialProvision.SetValue(DBUtility.GetInitialValue("error_SpecialProvision"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_ProgressSem1")) Then
        item.error_ProgressSem1.SetValue(DBUtility.GetInitialValue("error_ProgressSem1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_ProgressSem2")) Then
        item.error_ProgressSem2.SetValue(DBUtility.GetInitialValue("error_ProgressSem2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("cbENROL_FILE_CHECKED")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("cbENROL_FILE_CHECKED")) Then
            item.cbENROL_FILE_CHECKED.Value = item.cbENROL_FILE_CHECKEDCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_LPDone")) Then
        item.error_LPDone.SetValue(DBUtility.GetInitialValue("error_LPDone"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "ENROLMENT_YEAR"
                    Return ENROLMENT_YEAR
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "LAUNCH_PAD_DONE"
                    Return LAUNCH_PAD_DONE
                Case "LAUNCH_PAD_DONE_DATE"
                    Return LAUNCH_PAD_DONE_DATE
                Case "LEARNING_PROGRAM"
                    Return LEARNING_PROGRAM
                Case "LEARNING_PROGRAM_DETAILS"
                    Return LEARNING_PROGRAM_DETAILS
                Case "LEARNING_PROGRAM_CONSULT"
                    Return LEARNING_PROGRAM_CONSULT
                Case "SPECIAL_PROVISION_FLAG"
                    Return SPECIAL_PROVISION_FLAG
                Case "SPECIAL_PROVISION_DETAILS"
                    Return SPECIAL_PROVISION_DETAILS
                Case "REVIEW_PROGRESS_END_SEM1"
                    Return REVIEW_PROGRESS_END_SEM1
                Case "REVIEW_PROGRESS_END_SEM2"
                    Return REVIEW_PROGRESS_END_SEM2
                Case "lblLearningProgram"
                    Return lblLearningProgram
                Case "lblStudentID"
                    Return lblStudentID
                Case "lblEnrolYear"
                    Return lblEnrolYear
                Case "LAST_ALTERED_BY1"
                    Return LAST_ALTERED_BY1
                Case "LAST_ALTERED_DATE1"
                    Return LAST_ALTERED_DATE1
                Case "hidden_LastUpdatedBy"
                    Return hidden_LastUpdatedBy
                Case "hidden_LastUpdatedWhen"
                    Return hidden_LastUpdatedWhen
                Case "Hidden_LEARNING_PROGRAM_CONSULT"
                    Return Hidden_LEARNING_PROGRAM_CONSULT
                Case "ASSESS_ENGLANG_LP"
                    Return ASSESS_ENGLANG_LP
                Case "ASSESS_ENGLANG_RL"
                    Return ASSESS_ENGLANG_RL
                Case "ASSESS_MATH_LP"
                    Return ASSESS_MATH_LP
                Case "ASSESS_MATH_RL"
                    Return ASSESS_MATH_RL
                Case "ASSESS_PATSCIENCE_LP"
                    Return ASSESS_PATSCIENCE_LP
                Case "ASSESS_PATSCIENCE_RL"
                    Return ASSESS_PATSCIENCE_RL
                Case "error_AssessData"
                    Return error_AssessData
                Case "error_LearnDetails"
                    Return error_LearnDetails
                Case "error_LearnGoals"
                    Return error_LearnGoals
                Case "error_SpecialProvision"
                    Return error_SpecialProvision
                Case "error_ProgressSem1"
                    Return error_ProgressSem1
                Case "error_ProgressSem2"
                    Return error_ProgressSem2
                Case "cbENROL_FILE_CHECKED"
                    Return cbENROL_FILE_CHECKED
                Case "error_LPDone"
                    Return error_LPDone
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, FloatField)
                Case "ENROLMENT_YEAR"
                    ENROLMENT_YEAR = CType(value, FloatField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "LAUNCH_PAD_DONE"
                    LAUNCH_PAD_DONE = CType(value, TextField)
                Case "LAUNCH_PAD_DONE_DATE"
                    LAUNCH_PAD_DONE_DATE = CType(value, DateField)
                Case "LEARNING_PROGRAM"
                    LEARNING_PROGRAM = CType(value, TextField)
                Case "LEARNING_PROGRAM_DETAILS"
                    LEARNING_PROGRAM_DETAILS = CType(value, TextField)
                Case "LEARNING_PROGRAM_CONSULT"
                    LEARNING_PROGRAM_CONSULT = CType(value, TextField)
                Case "SPECIAL_PROVISION_FLAG"
                    SPECIAL_PROVISION_FLAG = CType(value, TextField)
                Case "SPECIAL_PROVISION_DETAILS"
                    SPECIAL_PROVISION_DETAILS = CType(value, TextField)
                Case "REVIEW_PROGRESS_END_SEM1"
                    REVIEW_PROGRESS_END_SEM1 = CType(value, TextField)
                Case "REVIEW_PROGRESS_END_SEM2"
                    REVIEW_PROGRESS_END_SEM2 = CType(value, TextField)
                Case "lblLearningProgram"
                    lblLearningProgram = CType(value, TextField)
                Case "lblStudentID"
                    lblStudentID = CType(value, TextField)
                Case "lblEnrolYear"
                    lblEnrolYear = CType(value, TextField)
                Case "LAST_ALTERED_BY1"
                    LAST_ALTERED_BY1 = CType(value, TextField)
                Case "LAST_ALTERED_DATE1"
                    LAST_ALTERED_DATE1 = CType(value, DateField)
                Case "hidden_LastUpdatedBy"
                    hidden_LastUpdatedBy = CType(value, TextField)
                Case "hidden_LastUpdatedWhen"
                    hidden_LastUpdatedWhen = CType(value, DateField)
                Case "Hidden_LEARNING_PROGRAM_CONSULT"
                    Hidden_LEARNING_PROGRAM_CONSULT = CType(value, TextField)
                Case "ASSESS_ENGLANG_LP"
                    ASSESS_ENGLANG_LP = CType(value, TextField)
                Case "ASSESS_ENGLANG_RL"
                    ASSESS_ENGLANG_RL = CType(value, TextField)
                Case "ASSESS_MATH_LP"
                    ASSESS_MATH_LP = CType(value, TextField)
                Case "ASSESS_MATH_RL"
                    ASSESS_MATH_RL = CType(value, TextField)
                Case "ASSESS_PATSCIENCE_LP"
                    ASSESS_PATSCIENCE_LP = CType(value, TextField)
                Case "ASSESS_PATSCIENCE_RL"
                    ASSESS_PATSCIENCE_RL = CType(value, TextField)
                Case "error_AssessData"
                    error_AssessData = CType(value, TextField)
                Case "error_LearnDetails"
                    error_LearnDetails = CType(value, TextField)
                Case "error_LearnGoals"
                    error_LearnGoals = CType(value, TextField)
                Case "error_SpecialProvision"
                    error_SpecialProvision = CType(value, TextField)
                Case "error_ProgressSem1"
                    error_ProgressSem1 = CType(value, TextField)
                Case "error_ProgressSem2"
                    error_ProgressSem2 = CType(value, TextField)
                Case "cbENROL_FILE_CHECKED"
                    cbENROL_FILE_CHECKED = CType(value, TextField)
                Case "error_LPDone"
                    error_LPDone = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STUDENT_PROFILE1DataProvider)
'End Record STUDENT_PROFILE1 Item Class

'STUDENT_ID validate @9-6D9CF271
        If IsNothing(STUDENT_ID.Value) OrElse STUDENT_ID.Value.ToString() ="" Then
            errors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_RequiredField,"STUDENT ID"))
        End If
'End STUDENT_ID validate

'ENROLMENT_YEAR validate @10-2458998A
        If IsNothing(ENROLMENT_YEAR.Value) OrElse ENROLMENT_YEAR.Value.ToString() ="" Then
            errors.Add("ENROLMENT_YEAR",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT YEAR"))
        End If
'End ENROLMENT_YEAR validate

'TextArea LEARNING_PROGRAM_DETAILS Event OnValidate. Action Validate Maximum Length @161-E60A5C88
        If Not (LEARNING_PROGRAM_DETAILS.Value Is Nothing) AndAlso LEARNING_PROGRAM_DETAILS.Value.ToString().Length > 200 Then
            errors.Add("LEARNING_PROGRAM_DETAILS",String.Format("<span class='errormsg'> Input cannot exceed 200 characters</span>","LEARNING PROGRAM DETAILS","200"))
        End If
'End TextArea LEARNING_PROGRAM_DETAILS Event OnValidate. Action Validate Maximum Length

'TextArea SPECIAL_PROVISION_DETAILS Event OnValidate. Action Validate Maximum Length @163-01195E52
        If Not (SPECIAL_PROVISION_DETAILS.Value Is Nothing) AndAlso SPECIAL_PROVISION_DETAILS.Value.ToString().Length > 400 Then
            errors.Add("SPECIAL_PROVISION_DETAILS",String.Format("<span class='errormsg'> Input cannot exceed 400 characters</span>","SPECIAL PROVISION DETAILS","400"))
        End If
'End TextArea SPECIAL_PROVISION_DETAILS Event OnValidate. Action Validate Maximum Length

'TextArea REVIEW_PROGRESS_END_SEM1 Event OnValidate. Action Validate Maximum Length @168-B4D2E683
        If Not (REVIEW_PROGRESS_END_SEM1.Value Is Nothing) AndAlso REVIEW_PROGRESS_END_SEM1.Value.ToString().Length > 400 Then
            errors.Add("REVIEW_PROGRESS_END_SEM1",String.Format("<span class='errormsg'> Input cannot exceed 400 characters</span>","REVIEW PROGRESS END SEM1","400"))
        End If
'End TextArea REVIEW_PROGRESS_END_SEM1 Event OnValidate. Action Validate Maximum Length

'TextArea REVIEW_PROGRESS_END_SEM2 Event OnValidate. Action Validate Maximum Length @169-0D0F8261
        If Not (REVIEW_PROGRESS_END_SEM2.Value Is Nothing) AndAlso REVIEW_PROGRESS_END_SEM2.Value.ToString().Length > 400 Then
            errors.Add("REVIEW_PROGRESS_END_SEM2",String.Format("<span class='errormsg'> Input cannot exceed 400 characters</span>","REVIEW PROGRESS END SEM2","400"))
        End If
'End TextArea REVIEW_PROGRESS_END_SEM2 Event OnValidate. Action Validate Maximum Length

'Record STUDENT_PROFILE1 Event OnValidate. Action Custom Code @214-73254650
    ' -------------------------
      'Sept-2018|EA| if any Errors, then change text on main error BLAHBLAH
    If (errors.Count > 0) Then
    	errors.Add("Form",String.Format("Check errors! Scroll down {0} page to check for errors!","STUDENT_PROFILE1"))
    End If
    'errors.Add("STUDENT_PROFILE1",String.Format("Ummmm is this thing on?","STUDENT_PROFILE1"))
    ' -------------------------
'End Record STUDENT_PROFILE1 Event OnValidate. Action Custom Code

'Record STUDENT_PROFILE1 Item Class tail @3-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_PROFILE1 Item Class tail

'Record STUDENT_PROFILE1 Data Provider Class @3-541A4E75
Public Class STUDENT_PROFILE1DataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_PROFILE1 Data Provider Class

'Record STUDENT_PROFILE1 Data Provider Class Variables @3-4BE0A8E2
    Public UrlSTUDENT_ID As IntegerParameter
    Public UrlENROLMENT_YEAR As IntegerParameter
    Protected item As STUDENT_PROFILE1Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_PROFILE1 Data Provider Class Variables

'Record STUDENT_PROFILE1 Data Provider Class Constructor @3-A47F591C

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_PROFILE {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID206","And","ENROLMENT_YEAR207"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_PROFILE1 Data Provider Class Constructor

'Record STUDENT_PROFILE1 Data Provider Class LoadParams Method @3-79390024

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID) Or IsNothing(UrlENROLMENT_YEAR))
    End Function
'End Record STUDENT_PROFILE1 Data Provider Class LoadParams Method

'Record STUDENT_PROFILE1 Data Provider Class CheckUnique Method @3-3A6AF9CA

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_PROFILE1Item) As Boolean
        Return True
    End Function
'End Record STUDENT_PROFILE1 Data Provider Class CheckUnique Method

'Record STUDENT_PROFILE1 Data Provider Class PrepareInsert Method @3-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STUDENT_PROFILE1 Data Provider Class PrepareInsert Method

'Record STUDENT_PROFILE1 Data Provider Class PrepareInsert Method tail @3-E31F8E2A
    End Sub
'End Record STUDENT_PROFILE1 Data Provider Class PrepareInsert Method tail

'Record STUDENT_PROFILE1 Data Provider Class Insert Method @3-1E441B92

    Public Function InsertItem(ByVal item As STUDENT_PROFILE1Item) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO STUDENT_PROFILE({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_PROFILE1 Data Provider Class Insert Method

'Record STUDENT_PROFILE1 Build insert @3-3AD0C00A
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.STUDENT_ID.IsEmpty Then
        allEmptyFlag = item.STUDENT_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STUDENT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STUDENT_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.ENROLMENT_YEAR.IsEmpty Then
        allEmptyFlag = item.ENROLMENT_YEAR.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ENROLMENT_YEAR,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ENROLMENT_YEAR.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.LAUNCH_PAD_DONE.IsEmpty Then
        allEmptyFlag = item.LAUNCH_PAD_DONE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAUNCH_PAD_DONE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAUNCH_PAD_DONE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAUNCH_PAD_DONE_DATE.IsEmpty Then
        allEmptyFlag = item.LAUNCH_PAD_DONE_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAUNCH_PAD_DONE_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAUNCH_PAD_DONE_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.LEARNING_PROGRAM.IsEmpty Then
        allEmptyFlag = item.LEARNING_PROGRAM.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LEARNING_PROGRAM,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LEARNING_PROGRAM.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LEARNING_PROGRAM_DETAILS.IsEmpty Then
        allEmptyFlag = item.LEARNING_PROGRAM_DETAILS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LEARNING_PROGRAM_DETAILS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LEARNING_PROGRAM_DETAILS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SPECIAL_PROVISION_FLAG.IsEmpty Then
        allEmptyFlag = item.SPECIAL_PROVISION_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SPECIAL_PROVISION_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SPECIAL_PROVISION_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SPECIAL_PROVISION_DETAILS.IsEmpty Then
        allEmptyFlag = item.SPECIAL_PROVISION_DETAILS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SPECIAL_PROVISION_DETAILS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SPECIAL_PROVISION_DETAILS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.REVIEW_PROGRESS_END_SEM1.IsEmpty Then
        allEmptyFlag = item.REVIEW_PROGRESS_END_SEM1.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "REVIEW_PROGRESS_END_SEM1,"
        valuesList = valuesList & Insert.Dao.ToSql(item.REVIEW_PROGRESS_END_SEM1.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.REVIEW_PROGRESS_END_SEM2.IsEmpty Then
        allEmptyFlag = item.REVIEW_PROGRESS_END_SEM2.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "REVIEW_PROGRESS_END_SEM2,"
        valuesList = valuesList & Insert.Dao.ToSql(item.REVIEW_PROGRESS_END_SEM2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_LastUpdatedBy.IsEmpty Then
        allEmptyFlag = item.hidden_LastUpdatedBy.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.hidden_LastUpdatedBy.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_LastUpdatedWhen.IsEmpty Then
        allEmptyFlag = item.hidden_LastUpdatedWhen.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.hidden_LastUpdatedWhen.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.Hidden_LEARNING_PROGRAM_CONSULT.IsEmpty Then
        allEmptyFlag = item.Hidden_LEARNING_PROGRAM_CONSULT.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LEARNING_PROGRAM_CONSULT,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_LEARNING_PROGRAM_CONSULT.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_ENGLANG_LP.IsEmpty Then
        allEmptyFlag = item.ASSESS_ENGLANG_LP.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ASSESS_ENGLANG_LP,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ASSESS_ENGLANG_LP.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_ENGLANG_RL.IsEmpty Then
        allEmptyFlag = item.ASSESS_ENGLANG_RL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ASSESS_ENGLANG_RL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ASSESS_ENGLANG_RL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_MATH_LP.IsEmpty Then
        allEmptyFlag = item.ASSESS_MATH_LP.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ASSESS_MATH_LP,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ASSESS_MATH_LP.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_MATH_RL.IsEmpty Then
        allEmptyFlag = item.ASSESS_MATH_RL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ASSESS_MATH_RL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ASSESS_MATH_RL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_PATSCIENCE_LP.IsEmpty Then
        allEmptyFlag = item.ASSESS_PATSCIENCE_LP.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ASSESS_PATSCIENCE_LP,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ASSESS_PATSCIENCE_LP.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_PATSCIENCE_RL.IsEmpty Then
        allEmptyFlag = item.ASSESS_PATSCIENCE_RL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ASSESS_PATSCIENCE_RL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ASSESS_PATSCIENCE_RL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.cbENROL_FILE_CHECKED.IsEmpty Then
        allEmptyFlag = item.cbENROL_FILE_CHECKED.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ENROL_FILE_CHECKED,"
        valuesList = valuesList & Insert.Dao.ToSql(item.cbENROL_FILE_CHECKED.GetFormattedValue(""),FieldType._Text) & ","
        End If
		Insert.SqlQuery.Replace("{Fields}", fieldsList.TrimEnd(","C))
		Insert.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
             If Not allEmptyFlag Then result = ExecuteInsert()
        Catch ee As Exception
            E = ee
        Finally
'End Record STUDENT_PROFILE1 Build insert

'Record STUDENT_PROFILE1 AfterExecuteInsert @3-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_PROFILE1 AfterExecuteInsert

'Record STUDENT_PROFILE1 Data Provider Class PrepareUpdate Method @3-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STUDENT_PROFILE1 Data Provider Class PrepareUpdate Method

'Record STUDENT_PROFILE1 Data Provider Class PrepareUpdate Method tail @3-E31F8E2A
    End Sub
'End Record STUDENT_PROFILE1 Data Provider Class PrepareUpdate Method tail

'Record STUDENT_PROFILE1 Data Provider Class Update Method @3-F1B8AA58

    Public Function UpdateItem(ByVal item As STUDENT_PROFILE1Item) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT_PROFILE SET {Values}", New String(){"STUDENT_ID206","And","ENROLMENT_YEAR207"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_PROFILE1 Data Provider Class Update Method

'DEL      ' -------------------------
'DEL        'Sept-2018|EA| if any Errors, then change text on main error BLAHBLAH
'DEL      If (errors.Count > 0) Then
'DEL      	errors.Add("Form",String.Format("BeforeBuildUpdate - Check errors! Scroll down {0} page to check for errors!","STUDENT_PROFILE1"))
'DEL      End If
'DEL      ' -------------------------


'Record STUDENT_PROFILE1 BeforeBuildUpdate @3-102AC3F4
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID206",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ENROLMENT_YEAR207",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        If Not item.STUDENT_ID.IsEmpty Then
        allEmptyFlag = item.STUDENT_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STUDENT_ID=" + Update.Dao.ToSql(item.STUDENT_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.ENROLMENT_YEAR.IsEmpty Then
        allEmptyFlag = item.ENROLMENT_YEAR.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ENROLMENT_YEAR=" + Update.Dao.ToSql(item.ENROLMENT_YEAR.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.LAUNCH_PAD_DONE.IsEmpty Then
        allEmptyFlag = item.LAUNCH_PAD_DONE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAUNCH_PAD_DONE=" + Update.Dao.ToSql(item.LAUNCH_PAD_DONE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAUNCH_PAD_DONE_DATE.IsEmpty Then
        allEmptyFlag = item.LAUNCH_PAD_DONE_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAUNCH_PAD_DONE_DATE=" + Update.Dao.ToSql(item.LAUNCH_PAD_DONE_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.LEARNING_PROGRAM.IsEmpty Then
        allEmptyFlag = item.LEARNING_PROGRAM.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LEARNING_PROGRAM=" + Update.Dao.ToSql(item.LEARNING_PROGRAM.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LEARNING_PROGRAM_DETAILS.IsEmpty Then
        allEmptyFlag = item.LEARNING_PROGRAM_DETAILS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LEARNING_PROGRAM_DETAILS=" + Update.Dao.ToSql(item.LEARNING_PROGRAM_DETAILS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SPECIAL_PROVISION_FLAG.IsEmpty Then
        allEmptyFlag = item.SPECIAL_PROVISION_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SPECIAL_PROVISION_FLAG=" + Update.Dao.ToSql(item.SPECIAL_PROVISION_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SPECIAL_PROVISION_DETAILS.IsEmpty Then
        allEmptyFlag = item.SPECIAL_PROVISION_DETAILS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SPECIAL_PROVISION_DETAILS=" + Update.Dao.ToSql(item.SPECIAL_PROVISION_DETAILS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.REVIEW_PROGRESS_END_SEM1.IsEmpty Then
        allEmptyFlag = item.REVIEW_PROGRESS_END_SEM1.IsEmpty And allEmptyFlag
        valuesList = valuesList & "REVIEW_PROGRESS_END_SEM1=" + Update.Dao.ToSql(item.REVIEW_PROGRESS_END_SEM1.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.REVIEW_PROGRESS_END_SEM2.IsEmpty Then
        allEmptyFlag = item.REVIEW_PROGRESS_END_SEM2.IsEmpty And allEmptyFlag
        valuesList = valuesList & "REVIEW_PROGRESS_END_SEM2=" + Update.Dao.ToSql(item.REVIEW_PROGRESS_END_SEM2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_LastUpdatedBy.IsEmpty Then
        allEmptyFlag = item.hidden_LastUpdatedBy.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.hidden_LastUpdatedBy.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_LastUpdatedWhen.IsEmpty Then
        allEmptyFlag = item.hidden_LastUpdatedWhen.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.hidden_LastUpdatedWhen.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.Hidden_LEARNING_PROGRAM_CONSULT.IsEmpty Then
        allEmptyFlag = item.Hidden_LEARNING_PROGRAM_CONSULT.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LEARNING_PROGRAM_CONSULT=" + Update.Dao.ToSql(item.Hidden_LEARNING_PROGRAM_CONSULT.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_ENGLANG_LP.IsEmpty Then
        allEmptyFlag = item.ASSESS_ENGLANG_LP.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ASSESS_ENGLANG_LP=" + Update.Dao.ToSql(item.ASSESS_ENGLANG_LP.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_ENGLANG_RL.IsEmpty Then
        allEmptyFlag = item.ASSESS_ENGLANG_RL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ASSESS_ENGLANG_RL=" + Update.Dao.ToSql(item.ASSESS_ENGLANG_RL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_MATH_LP.IsEmpty Then
        allEmptyFlag = item.ASSESS_MATH_LP.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ASSESS_MATH_LP=" + Update.Dao.ToSql(item.ASSESS_MATH_LP.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_MATH_RL.IsEmpty Then
        allEmptyFlag = item.ASSESS_MATH_RL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ASSESS_MATH_RL=" + Update.Dao.ToSql(item.ASSESS_MATH_RL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_PATSCIENCE_LP.IsEmpty Then
        allEmptyFlag = item.ASSESS_PATSCIENCE_LP.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ASSESS_PATSCIENCE_LP=" + Update.Dao.ToSql(item.ASSESS_PATSCIENCE_LP.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_PATSCIENCE_RL.IsEmpty Then
        allEmptyFlag = item.ASSESS_PATSCIENCE_RL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ASSESS_PATSCIENCE_RL=" + Update.Dao.ToSql(item.ASSESS_PATSCIENCE_RL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.cbENROL_FILE_CHECKED.IsEmpty Then
        allEmptyFlag = item.cbENROL_FILE_CHECKED.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ENROL_FILE_CHECKED=" + Update.Dao.ToSql(item.cbENROL_FILE_CHECKED.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STUDENT_PROFILE1 BeforeBuildUpdate

'Record STUDENT_PROFILE1 AfterExecuteUpdate @3-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_PROFILE1 AfterExecuteUpdate

'Record STUDENT_PROFILE1 Data Provider Class GetResultSet Method @3-70A0AA4F

    Public Sub FillItem(ByVal item As STUDENT_PROFILE1Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_PROFILE1 Data Provider Class GetResultSet Method

'Record STUDENT_PROFILE1 BeforeBuildSelect @3-C7318EC1
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID206",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("ENROLMENT_YEAR207",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_PROFILE1 BeforeBuildSelect

'Record STUDENT_PROFILE1 BeforeExecuteSelect @3-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_PROFILE1 BeforeExecuteSelect

'Record STUDENT_PROFILE1 AfterExecuteSelect @3-F78C9FF7
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.ENROLMENT_YEAR.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.LAUNCH_PAD_DONE.SetValue(dr(i)("LAUNCH_PAD_DONE"),"")
            item.LAUNCH_PAD_DONE_DATE.SetValue(dr(i)("LAUNCH_PAD_DONE_DATE"),Select_.DateFormat)
            item.LEARNING_PROGRAM.SetValue(dr(i)("LEARNING_PROGRAM"),"")
            item.LEARNING_PROGRAM_DETAILS.SetValue(dr(i)("LEARNING_PROGRAM_DETAILS"),"")
            item.SPECIAL_PROVISION_FLAG.SetValue(dr(i)("SPECIAL_PROVISION_FLAG"),"")
            item.SPECIAL_PROVISION_DETAILS.SetValue(dr(i)("SPECIAL_PROVISION_DETAILS"),"")
            item.REVIEW_PROGRESS_END_SEM1.SetValue(dr(i)("REVIEW_PROGRESS_END_SEM1"),"")
            item.REVIEW_PROGRESS_END_SEM2.SetValue(dr(i)("REVIEW_PROGRESS_END_SEM2"),"")
            item.lblLearningProgram.SetValue(dr(i)("LEARNING_PROGRAM"),"")
            item.lblStudentID.SetValue(dr(i)("STUDENT_ID"),"")
            item.lblEnrolYear.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.LAST_ALTERED_BY1.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE1.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.hidden_LastUpdatedBy.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.hidden_LastUpdatedWhen.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.Hidden_LEARNING_PROGRAM_CONSULT.SetValue(dr(i)("LEARNING_PROGRAM_CONSULT"),"")
            item.ASSESS_ENGLANG_LP.SetValue(dr(i)("ASSESS_ENGLANG_LP"),"")
            item.ASSESS_ENGLANG_RL.SetValue(dr(i)("ASSESS_ENGLANG_RL"),"")
            item.ASSESS_MATH_LP.SetValue(dr(i)("ASSESS_MATH_LP"),"")
            item.ASSESS_MATH_RL.SetValue(dr(i)("ASSESS_MATH_RL"),"")
            item.ASSESS_PATSCIENCE_LP.SetValue(dr(i)("ASSESS_PATSCIENCE_LP"),"")
            item.ASSESS_PATSCIENCE_RL.SetValue(dr(i)("ASSESS_PATSCIENCE_RL"),"")
            item.cbENROL_FILE_CHECKED.SetValue(dr(i)("ENROL_FILE_CHECKED"),"")
        Else
            IsInsertMode = True
        End If
'End Record STUDENT_PROFILE1 AfterExecuteSelect

'ListBox LAUNCH_PAD_DONE AfterExecuteSelect @45-DE0E847B
        
item.LAUNCH_PAD_DONEItems.Add("Y","Yes")
item.LAUNCH_PAD_DONEItems.Add("N","No")
'End ListBox LAUNCH_PAD_DONE AfterExecuteSelect

'ListBox LEARNING_PROGRAM_CONSULT AfterExecuteSelect @49-6887ECAF
        
item.LEARNING_PROGRAM_CONSULTItems.Add("YearLevelCoord","Year Level Coordinator")
item.LEARNING_PROGRAM_CONSULTItems.Add("LeadingTeacher-StudentLearning","Leading Teacher - Student Learning")
item.LEARNING_PROGRAM_CONSULTItems.Add("StudentInclusion","Student Inclusion")
item.LEARNING_PROGRAM_CONSULTItems.Add("StudentWellbeing","Student Wellbeing")
'End ListBox LEARNING_PROGRAM_CONSULT AfterExecuteSelect

'ListBox SPECIAL_PROVISION_FLAG AfterExecuteSelect @51-F2D4EFA9
        
item.SPECIAL_PROVISION_FLAGItems.Add("Y","Yes")
item.SPECIAL_PROVISION_FLAGItems.Add("N","No")
'End ListBox SPECIAL_PROVISION_FLAG AfterExecuteSelect

'Record STUDENT_PROFILE1 AfterExecuteSelect tail @3-E31F8E2A
    End Sub
'End Record STUDENT_PROFILE1 AfterExecuteSelect tail

'Record STUDENT_PROFILE1 Data Provider Class @3-A61BA892
End Class

'End Record STUDENT_PROFILE1 Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

