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

Namespace DECV_PROD2007.StudentEnrolmentDetails_maintain 'Namespace @1-B3DCCE1A

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

'Record STUDENT_ENROLMENT Item Class @2-316C8450
Public Class STUDENT_ENROLMENTItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public PASTORAL_CARE_ID As TextField
    Public PASTORAL_CARE_IDItems As ItemCollection
    Public DOCS_LAST_REVIEWED_DATE As DateField
    Public NEW_DOCS_REQUIRED As BooleanField
    Public NEW_DOCS_REQUIREDItems As ItemCollection
    Public LAST_ALTERED_BY As TextField
    Public ajaxBusy As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Hidden_last_altered_by As TextField
    Public Hidden_last_altered_date As DateField
    Public YEAR_LEVEL_REPORTING As IntegerField
    Public YEAR_LEVEL_REPORTINGItems As ItemCollection
    Public hidden_yearlevel_original As TextField
    Public hidden_yearlevel_original1 As TextField
    Public Hidden_PASTORAL_CARE_ID As TextField
    Public PASTORAL_ALLOC_BY As TextField
    Public PASTORAL_ALLOC_DATE As DateField
    Public LAd_ALLOC_BY As TextField
    Public LAd_ALLOC_DATE As DateField
    Public ATAR_REQUIRED As TextField
    Public ATAR_REQUIREDItems As ItemCollection
    Public PRIVACY_PERMISSION As BooleanField
    Public PRIVACY_PERMISSIONItems As ItemCollection
    Public INTERVIEW_INTAKE_DONE As BooleanField
    Public INTERVIEW_INTAKE_DONEItems As ItemCollection
    Public RECEIPT_NO As TextField
    Public lbEXIT_DESTINATION As FloatField
    Public lbEXIT_DESTINATIONItems As ItemCollection
    Public WITHDRAWAL_REASON_ID As FloatField
    Public WITHDRAWAL_REASON_IDItems As ItemCollection
    Public list_Region As TextField
    Public list_RegionItems As ItemCollection
    Public region_approval_number As TextField
    Public ELIGIBLE_FOR_FUNDING As BooleanField
    Public ELIGIBLE_FOR_FUNDINGItems As ItemCollection
    Public PAID_ON_ENROLMENT As BooleanField
    Public PAID_ON_ENROLMENTItems As ItemCollection
    Public ELIGIBLE_FOR_DISCOUNT As BooleanField
    Public ELIGIBLE_FOR_DISCOUNTItems As ItemCollection
    Public ENROLMENT_YEAR As TextField
    Public YEAR_LEVEL As IntegerField
    Public YEAR_LEVELItems As ItemCollection
    Public ENROLMENT_STATUS As TextField
    Public ENROLMENT_STATUSItems As ItemCollection
    Public WITHDRAWAL_DATE As DateField
    Public ENROLMENT_DATE As DateField
    Public STUDENT_ID As FloatField
    Public PERSONAL_LEARNING_PLAN As TextField
    Public PERSONAL_LEARNING_PLANItems As ItemCollection
    Public Hidden_LearningPlan As TextField
    Public Hidden_EnrolmentStatus As TextField
    Public Hidden_Privacy As TextField
    Public SSG_FACILITATOR_ID As TextField
    Public SSG_FACILITATOR_IDItems As ItemCollection
    Public Sub New()
    PASTORAL_CARE_ID = New TextField("", Nothing)
    PASTORAL_CARE_IDItems = New ItemCollection()
    DOCS_LAST_REVIEWED_DATE = New DateField("dd\/MM\/yy", Nothing)
    NEW_DOCS_REQUIRED = New BooleanField(Settings.BoolFormat, Nothing)
    NEW_DOCS_REQUIREDItems = New ItemCollection()
    LAST_ALTERED_BY = New TextField("", Nothing)
    ajaxBusy = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    Hidden_last_altered_by = New TextField("", DBUtility.UserLogin.ToUpper)
    Hidden_last_altered_date = New DateField("yyyy-MM-dd H\:mm", DateTime.Now)
    YEAR_LEVEL_REPORTING = New IntegerField("", Nothing)
    YEAR_LEVEL_REPORTINGItems = New ItemCollection()
    hidden_yearlevel_original = New TextField("", Nothing)
    hidden_yearlevel_original1 = New TextField("", Nothing)
    Hidden_PASTORAL_CARE_ID = New TextField("", Nothing)
    PASTORAL_ALLOC_BY = New TextField("", Nothing)
    PASTORAL_ALLOC_DATE = New DateField("yyyy-MM-dd H\:mm", Nothing)
    LAd_ALLOC_BY = New TextField("", Nothing)
    LAd_ALLOC_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    ATAR_REQUIRED = New TextField("", "Y")
    ATAR_REQUIREDItems = New ItemCollection()
    PRIVACY_PERMISSION = New BooleanField(Settings.BoolFormat, Nothing)
    PRIVACY_PERMISSIONItems = New ItemCollection()
    INTERVIEW_INTAKE_DONE = New BooleanField(Settings.BoolFormat, Nothing)
    INTERVIEW_INTAKE_DONEItems = New ItemCollection()
    RECEIPT_NO = New TextField("", Nothing)
    lbEXIT_DESTINATION = New FloatField("", Nothing)
    lbEXIT_DESTINATIONItems = New ItemCollection()
    WITHDRAWAL_REASON_ID = New FloatField("", Nothing)
    WITHDRAWAL_REASON_IDItems = New ItemCollection()
    list_Region = New TextField("", Nothing)
    list_RegionItems = New ItemCollection()
    region_approval_number = New TextField("", Nothing)
    ELIGIBLE_FOR_FUNDING = New BooleanField(Settings.BoolFormat, Nothing)
    ELIGIBLE_FOR_FUNDINGItems = New ItemCollection()
    PAID_ON_ENROLMENT = New BooleanField(Settings.BoolFormat, Nothing)
    PAID_ON_ENROLMENTItems = New ItemCollection()
    ELIGIBLE_FOR_DISCOUNT = New BooleanField(Settings.BoolFormat, Nothing)
    ELIGIBLE_FOR_DISCOUNTItems = New ItemCollection()
    ENROLMENT_YEAR = New TextField("", Nothing)
    YEAR_LEVEL = New IntegerField("", Nothing)
    YEAR_LEVELItems = New ItemCollection()
    ENROLMENT_STATUS = New TextField("", Nothing)
    ENROLMENT_STATUSItems = New ItemCollection()
    WITHDRAWAL_DATE = New DateField("dd\/MM\/yy", Nothing)
    ENROLMENT_DATE = New DateField("dd\/MM\/yy", Nothing)
    STUDENT_ID = New FloatField("", Nothing)
    PERSONAL_LEARNING_PLAN = New TextField("", Nothing)
    PERSONAL_LEARNING_PLANItems = New ItemCollection()
    Hidden_LearningPlan = New TextField("", Nothing)
    Hidden_EnrolmentStatus = New TextField("", Nothing)
    Hidden_Privacy = New TextField("", Nothing)
    SSG_FACILITATOR_ID = New TextField("", Nothing)
    SSG_FACILITATOR_IDItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_ENROLMENTItem
        Dim item As STUDENT_ENROLMENTItem = New STUDENT_ENROLMENTItem()
        If Not IsNothing(DBUtility.GetInitialValue("PASTORAL_CARE_ID")) Then
        item.PASTORAL_CARE_ID.SetValue(DBUtility.GetInitialValue("PASTORAL_CARE_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DOCS_LAST_REVIEWED_DATE")) Then
        item.DOCS_LAST_REVIEWED_DATE.SetValue(DBUtility.GetInitialValue("DOCS_LAST_REVIEWED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("NEW_DOCS_REQUIRED")) Then
        item.NEW_DOCS_REQUIRED.SetValue(DBUtility.GetInitialValue("NEW_DOCS_REQUIRED"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ajaxBusy")) Then
        item.ajaxBusy.SetValue(DBUtility.GetInitialValue("ajaxBusy"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_last_altered_by")) Then
        item.Hidden_last_altered_by.SetValue(DBUtility.GetInitialValue("Hidden_last_altered_by"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_last_altered_date")) Then
        item.Hidden_last_altered_date.SetValue(DBUtility.GetInitialValue("Hidden_last_altered_date"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("YEAR_LEVEL_REPORTING")) Then
        item.YEAR_LEVEL_REPORTING.SetValue(DBUtility.GetInitialValue("YEAR_LEVEL_REPORTING"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_yearlevel_original")) Then
        item.hidden_yearlevel_original.SetValue(DBUtility.GetInitialValue("hidden_yearlevel_original"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_yearlevel_original1")) Then
        item.hidden_yearlevel_original1.SetValue(DBUtility.GetInitialValue("hidden_yearlevel_original1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_PASTORAL_CARE_ID")) Then
        item.Hidden_PASTORAL_CARE_ID.SetValue(DBUtility.GetInitialValue("Hidden_PASTORAL_CARE_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PASTORAL_ALLOC_BY")) Then
        item.PASTORAL_ALLOC_BY.SetValue(DBUtility.GetInitialValue("PASTORAL_ALLOC_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PASTORAL_ALLOC_DATE")) Then
        item.PASTORAL_ALLOC_DATE.SetValue(DBUtility.GetInitialValue("PASTORAL_ALLOC_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAd_ALLOC_BY")) Then
        item.LAd_ALLOC_BY.SetValue(DBUtility.GetInitialValue("LAd_ALLOC_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAd_ALLOC_DATE")) Then
        item.LAd_ALLOC_DATE.SetValue(DBUtility.GetInitialValue("LAd_ALLOC_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ATAR_REQUIRED")) Then
        item.ATAR_REQUIRED.SetValue(DBUtility.GetInitialValue("ATAR_REQUIRED"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRIVACY_PERMISSION")) Then
        item.PRIVACY_PERMISSION.SetValue(DBUtility.GetInitialValue("PRIVACY_PERMISSION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("INTERVIEW_INTAKE_DONE")) Then
        item.INTERVIEW_INTAKE_DONE.SetValue(DBUtility.GetInitialValue("INTERVIEW_INTAKE_DONE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RECEIPT_NO")) Then
        item.RECEIPT_NO.SetValue(DBUtility.GetInitialValue("RECEIPT_NO"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbEXIT_DESTINATION")) Then
        item.lbEXIT_DESTINATION.SetValue(DBUtility.GetInitialValue("lbEXIT_DESTINATION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("WITHDRAWAL_REASON_ID")) Then
        item.WITHDRAWAL_REASON_ID.SetValue(DBUtility.GetInitialValue("WITHDRAWAL_REASON_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("list_Region")) Then
        item.list_Region.SetValue(DBUtility.GetInitialValue("list_Region"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("region_approval_number")) Then
        item.region_approval_number.SetValue(DBUtility.GetInitialValue("region_approval_number"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ELIGIBLE_FOR_FUNDING")) Then
        item.ELIGIBLE_FOR_FUNDING.SetValue(DBUtility.GetInitialValue("ELIGIBLE_FOR_FUNDING"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PAID_ON_ENROLMENT")) Then
        item.PAID_ON_ENROLMENT.SetValue(DBUtility.GetInitialValue("PAID_ON_ENROLMENT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ELIGIBLE_FOR_DISCOUNT")) Then
        item.ELIGIBLE_FOR_DISCOUNT.SetValue(DBUtility.GetInitialValue("ELIGIBLE_FOR_DISCOUNT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_YEAR")) Then
        item.ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("YEAR_LEVEL")) Then
        item.YEAR_LEVEL.SetValue(DBUtility.GetInitialValue("YEAR_LEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_STATUS")) Then
        item.ENROLMENT_STATUS.SetValue(DBUtility.GetInitialValue("ENROLMENT_STATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DatePicker_WITHDRAWAL_DATE")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("WITHDRAWAL_DATE")) Then
        item.WITHDRAWAL_DATE.SetValue(DBUtility.GetInitialValue("WITHDRAWAL_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DatePicker_ENROLMENT_DATE")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_DATE")) Then
        item.ENROLMENT_DATE.SetValue(DBUtility.GetInitialValue("ENROLMENT_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PERSONAL_LEARNING_PLAN")) Then
        item.PERSONAL_LEARNING_PLAN.SetValue(DBUtility.GetInitialValue("PERSONAL_LEARNING_PLAN"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_LearningPlan")) Then
        item.Hidden_LearningPlan.SetValue(DBUtility.GetInitialValue("Hidden_LearningPlan"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_EnrolmentStatus")) Then
        item.Hidden_EnrolmentStatus.SetValue(DBUtility.GetInitialValue("Hidden_EnrolmentStatus"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_Privacy")) Then
        item.Hidden_Privacy.SetValue(DBUtility.GetInitialValue("Hidden_Privacy"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SSG_FACILITATOR_ID")) Then
        item.SSG_FACILITATOR_ID.SetValue(DBUtility.GetInitialValue("SSG_FACILITATOR_ID"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "PASTORAL_CARE_ID"
                    Return PASTORAL_CARE_ID
                Case "DOCS_LAST_REVIEWED_DATE"
                    Return DOCS_LAST_REVIEWED_DATE
                Case "NEW_DOCS_REQUIRED"
                    Return NEW_DOCS_REQUIRED
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "ajaxBusy"
                    Return ajaxBusy
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "Hidden_last_altered_by"
                    Return Hidden_last_altered_by
                Case "Hidden_last_altered_date"
                    Return Hidden_last_altered_date
                Case "YEAR_LEVEL_REPORTING"
                    Return YEAR_LEVEL_REPORTING
                Case "hidden_yearlevel_original"
                    Return hidden_yearlevel_original
                Case "hidden_yearlevel_original1"
                    Return hidden_yearlevel_original1
                Case "Hidden_PASTORAL_CARE_ID"
                    Return Hidden_PASTORAL_CARE_ID
                Case "PASTORAL_ALLOC_BY"
                    Return PASTORAL_ALLOC_BY
                Case "PASTORAL_ALLOC_DATE"
                    Return PASTORAL_ALLOC_DATE
                Case "LAd_ALLOC_BY"
                    Return LAd_ALLOC_BY
                Case "LAd_ALLOC_DATE"
                    Return LAd_ALLOC_DATE
                Case "ATAR_REQUIRED"
                    Return ATAR_REQUIRED
                Case "PRIVACY_PERMISSION"
                    Return PRIVACY_PERMISSION
                Case "INTERVIEW_INTAKE_DONE"
                    Return INTERVIEW_INTAKE_DONE
                Case "RECEIPT_NO"
                    Return RECEIPT_NO
                Case "lbEXIT_DESTINATION"
                    Return lbEXIT_DESTINATION
                Case "WITHDRAWAL_REASON_ID"
                    Return WITHDRAWAL_REASON_ID
                Case "list_Region"
                    Return list_Region
                Case "region_approval_number"
                    Return region_approval_number
                Case "ELIGIBLE_FOR_FUNDING"
                    Return ELIGIBLE_FOR_FUNDING
                Case "PAID_ON_ENROLMENT"
                    Return PAID_ON_ENROLMENT
                Case "ELIGIBLE_FOR_DISCOUNT"
                    Return ELIGIBLE_FOR_DISCOUNT
                Case "ENROLMENT_YEAR"
                    Return ENROLMENT_YEAR
                Case "YEAR_LEVEL"
                    Return YEAR_LEVEL
                Case "ENROLMENT_STATUS"
                    Return ENROLMENT_STATUS
                Case "WITHDRAWAL_DATE"
                    Return WITHDRAWAL_DATE
                Case "ENROLMENT_DATE"
                    Return ENROLMENT_DATE
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "PERSONAL_LEARNING_PLAN"
                    Return PERSONAL_LEARNING_PLAN
                Case "Hidden_LearningPlan"
                    Return Hidden_LearningPlan
                Case "Hidden_EnrolmentStatus"
                    Return Hidden_EnrolmentStatus
                Case "Hidden_Privacy"
                    Return Hidden_Privacy
                Case "SSG_FACILITATOR_ID"
                    Return SSG_FACILITATOR_ID
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "PASTORAL_CARE_ID"
                    PASTORAL_CARE_ID = CType(value, TextField)
                Case "DOCS_LAST_REVIEWED_DATE"
                    DOCS_LAST_REVIEWED_DATE = CType(value, DateField)
                Case "NEW_DOCS_REQUIRED"
                    NEW_DOCS_REQUIRED = CType(value, BooleanField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "ajaxBusy"
                    ajaxBusy = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "Hidden_last_altered_by"
                    Hidden_last_altered_by = CType(value, TextField)
                Case "Hidden_last_altered_date"
                    Hidden_last_altered_date = CType(value, DateField)
                Case "YEAR_LEVEL_REPORTING"
                    YEAR_LEVEL_REPORTING = CType(value, IntegerField)
                Case "hidden_yearlevel_original"
                    hidden_yearlevel_original = CType(value, TextField)
                Case "hidden_yearlevel_original1"
                    hidden_yearlevel_original1 = CType(value, TextField)
                Case "Hidden_PASTORAL_CARE_ID"
                    Hidden_PASTORAL_CARE_ID = CType(value, TextField)
                Case "PASTORAL_ALLOC_BY"
                    PASTORAL_ALLOC_BY = CType(value, TextField)
                Case "PASTORAL_ALLOC_DATE"
                    PASTORAL_ALLOC_DATE = CType(value, DateField)
                Case "LAd_ALLOC_BY"
                    LAd_ALLOC_BY = CType(value, TextField)
                Case "LAd_ALLOC_DATE"
                    LAd_ALLOC_DATE = CType(value, DateField)
                Case "ATAR_REQUIRED"
                    ATAR_REQUIRED = CType(value, TextField)
                Case "PRIVACY_PERMISSION"
                    PRIVACY_PERMISSION = CType(value, BooleanField)
                Case "INTERVIEW_INTAKE_DONE"
                    INTERVIEW_INTAKE_DONE = CType(value, BooleanField)
                Case "RECEIPT_NO"
                    RECEIPT_NO = CType(value, TextField)
                Case "lbEXIT_DESTINATION"
                    lbEXIT_DESTINATION = CType(value, FloatField)
                Case "WITHDRAWAL_REASON_ID"
                    WITHDRAWAL_REASON_ID = CType(value, FloatField)
                Case "list_Region"
                    list_Region = CType(value, TextField)
                Case "region_approval_number"
                    region_approval_number = CType(value, TextField)
                Case "ELIGIBLE_FOR_FUNDING"
                    ELIGIBLE_FOR_FUNDING = CType(value, BooleanField)
                Case "PAID_ON_ENROLMENT"
                    PAID_ON_ENROLMENT = CType(value, BooleanField)
                Case "ELIGIBLE_FOR_DISCOUNT"
                    ELIGIBLE_FOR_DISCOUNT = CType(value, BooleanField)
                Case "ENROLMENT_YEAR"
                    ENROLMENT_YEAR = CType(value, TextField)
                Case "YEAR_LEVEL"
                    YEAR_LEVEL = CType(value, IntegerField)
                Case "ENROLMENT_STATUS"
                    ENROLMENT_STATUS = CType(value, TextField)
                Case "WITHDRAWAL_DATE"
                    WITHDRAWAL_DATE = CType(value, DateField)
                Case "ENROLMENT_DATE"
                    ENROLMENT_DATE = CType(value, DateField)
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, FloatField)
                Case "PERSONAL_LEARNING_PLAN"
                    PERSONAL_LEARNING_PLAN = CType(value, TextField)
                Case "Hidden_LearningPlan"
                    Hidden_LearningPlan = CType(value, TextField)
                Case "Hidden_EnrolmentStatus"
                    Hidden_EnrolmentStatus = CType(value, TextField)
                Case "Hidden_Privacy"
                    Hidden_Privacy = CType(value, TextField)
                Case "SSG_FACILITATOR_ID"
                    SSG_FACILITATOR_ID = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STUDENT_ENROLMENTDataProvider)
'End Record STUDENT_ENROLMENT Item Class

'PRIVACY_PERMISSION validate @216-F632AB85
        If IsNothing(PRIVACY_PERMISSION.Value) OrElse PRIVACY_PERMISSION.Value.ToString() ="" Then
            errors.Add("PRIVACY_PERMISSION",String.Format(Resources.strings.CCS_RequiredField,"PRIVACY PERMISSION"))
        End If
'End PRIVACY_PERMISSION validate

'YEAR_LEVEL validate @14-30512612
        If IsNothing(YEAR_LEVEL.Value) OrElse YEAR_LEVEL.Value.ToString() ="" Then
            errors.Add("YEAR_LEVEL",String.Format(Resources.strings.CCS_RequiredField,"YEAR LEVEL"))
        End If
'End YEAR_LEVEL validate

'ENROLMENT_STATUS validate @12-5B7051E5
        If IsNothing(ENROLMENT_STATUS.Value) OrElse ENROLMENT_STATUS.Value.ToString() ="" Then
            errors.Add("ENROLMENT_STATUS",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT STATUS"))
        End If
'End ENROLMENT_STATUS validate

'ListBox ENROLMENT_STATUS Event OnValidate. Action Custom Code @396-73254650
    ' -------------------------
    '20-Feb-2020|EA| if N then force WD REason and WD Date
    If (ENROLMENT_STATUS.Value.ToString() ="N") Then
    	If IsNothing(WITHDRAWAL_REASON_ID.Value) OrElse WITHDRAWAL_REASON_ID.Value.ToString() ="" Then
            errors.Add("WITHDRAWAL_REASON_ID",String.Format("WITHDRAWAL REASON must be provided if ENROLMENT STATUS IS [Not Enrolled].","STUDENT_ENROLMENT"))
        End If
        If (IsNothing(WITHDRAWAL_DATE.Value) OrElse WITHDRAWAL_DATE.Value.ToString()="") And (WITHDRAWAL_REASON_ID.getformattedvalue()<>"")  Then
			errors.Add("WITHDRAWAL_DATE",String.Format("END DATE must be provided if WITHDRAWAL REASON is provided.","STUDENT_ENROLMENT"))
        End If
    Else
    	If IsNothing(WITHDRAWAL_REASON_ID.Value) OrElse WITHDRAWAL_REASON_ID.Value.ToString() ="" Then
    		'no op
    	Else
            errors.Add("WITHDRAWAL_REASON_ID",String.Format("WITHDRAWAL REASON must NOT be provided if ENROLMENT STATUS IS [Enrolled].","STUDENT_ENROLMENT"))
        End If
        If (IsNothing(WITHDRAWAL_DATE.Value) OrElse WITHDRAWAL_DATE.Value.ToString()="") Then
        	' no-op
        Else
			errors.Add("WITHDRAWAL_DATE",String.Format("END DATE must NOT be provided if WITHDRAWAL REASON is NOT provided.","STUDENT_ENROLMENT"))
        End If
    End If
    ' -------------------------
'End ListBox ENROLMENT_STATUS Event OnValidate. Action Custom Code

'TextBox WITHDRAWAL_DATE Event OnValidate. Action Custom Code @283-73254650
    ' -------------------------
    ' Write your own code here.
    ' -------------------------
'End TextBox WITHDRAWAL_DATE Event OnValidate. Action Custom Code

'ENROLMENT_DATE validate @8-F0770BE0
        If IsNothing(ENROLMENT_DATE.Value) OrElse ENROLMENT_DATE.Value.ToString() ="" Then
            errors.Add("ENROLMENT_DATE",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT DATE"))
        End If
'End ENROLMENT_DATE validate

'PERSONAL_LEARNING_PLAN validate @318-AD6DE967
        If IsNothing(PERSONAL_LEARNING_PLAN.Value) OrElse PERSONAL_LEARNING_PLAN.Value.ToString() ="" Then
            errors.Add("PERSONAL_LEARNING_PLAN",String.Format(Resources.strings.CCS_RequiredField,"Personal Learning Plan"))
        End If
'End PERSONAL_LEARNING_PLAN validate

'DEL      ' -------------------------
'DEL       ' ERA: 25-Aug-2008 if WITHDRAWAL_REASON_ID is not null then WITHDRAWAL_DATE must be provided
'DEL  		If (IsNothing(WITHDRAWAL_DATE.Value) OrElse WITHDRAWAL_DATE.Value.ToString()="") And (WITHDRAWAL_REASON_ID.getformattedvalue()<>"")  Then
'DEL              errors.Add("WITHDRAWAL_DATE",String.Format("END DATE must be provided if WITHDRAWAL REASON is provided.","STUDENT_ENROLMENT"))
'DEL          End If
'DEL  	 ' -------------------------

'Record STUDENT_ENROLMENT Event OnValidate. Action Custom Code @213-73254650
    ' -------------------------
    'ERA: 2010-06-04 - unfuddle #292 - set the YEAR_LEVEL_REPORTING = YEARL_LEVEL if the YLR is not set,
	'	and check if YLR <= YL as it should be
	'If IsNothing(YEAR_LEVEL_REPORTING.Value) OrElse YEAR_LEVEL_REPORTING.Value.ToString() ="" Then
	If IsNothing(YEAR_LEVEL_REPORTING.Value) OrElse YEAR_LEVEL_REPORTING.Value = -1 Then
		'set the value YLR = YL
        YEAR_LEVEL_REPORTING.Value = (New IntegerField("", YEAR_LEVEL.Value)).GetFormattedValue()
	elseif (YEAR_LEVEL.Value < YEAR_LEVEL_REPORTING.Value) then
		' check that YL >= YLR
		errors.Add("YEAR_LEVEL_REPORTING",String.Format("The REPORTING YEAR LEVEL must NOT be greater than the YEAR LEVEL" ,"REPORTING YEAR LEVEL"))
	elseif (Math.Abs(YEAR_LEVEL.Value - YEAR_LEVEL_REPORTING.Value) >2) then
		' check if difference is > 2 years
		errors.Add("YEAR_LEVEL_REPORTING",String.Format("The REPORTING YEAR LEVEL must not be more than 2 years away from YEAR LEVEL" ,"REPORTING YEAR LEVEL"))
	end if

    ' -------------------------
'End Record STUDENT_ENROLMENT Event OnValidate. Action Custom Code

'Record STUDENT_ENROLMENT Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_ENROLMENT Item Class tail

'Record STUDENT_ENROLMENT Data Provider Class @2-55469C34
Public Class STUDENT_ENROLMENTDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_ENROLMENT Data Provider Class

'Record STUDENT_ENROLMENT Data Provider Class Variables @2-824213A1
    Protected PASTORAL_CARE_IDDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM View_StaffList_Active_Inactive {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected lbEXIT_DESTINATIONDataCommand As DataCommand=new TableCommand("SELECT WD_DEST_ID, " & vbCrLf & _
          "EXIT_DESTINATION_DESCRIPTION " & vbCrLf & _
          "FROM WITHDRAWAL_EXIT_DESTINATION {SQL_Where} {SQL_OrderBy}", New String(){"expr181"},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected WITHDRAWAL_REASON_IDDataCommand As DataCommand=new TableCommand("SELECT WITHDRAWAL_REASON_ID, " & vbCrLf & _
          "WITHDRAWAL_REASON " & vbCrLf & _
          "FROM WITHDRAWAL_REASON {SQL_Where} {SQL_OrderBy}", New String(){"expr232"},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected list_RegionDataCommand As DataCommand=new TableCommand("SELECT REGION_ID, " & vbCrLf & _
          "rtrim(REGION_NAME) AS region_name_display " & vbCrLf & _
          "FROM REGION {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected SSG_FACILITATOR_IDDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM View_StaffList_Active_Inactive {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Public UrlSTUDENT_ID As FloatParameter
    Public UrlENROLMENT_YEAR As FloatParameter
    Protected item As STUDENT_ENROLMENTItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_ENROLMENT Data Provider Class Variables

'Record STUDENT_ENROLMENT Data Provider Class Constructor @2-D28BAC27

    Public Sub New()
        Select_=new TableCommand("SELECT STUDENT_ID AS STUDENT_ENROLMENT_STUDENT_ID, ENROLMENT_YEAR, CAMPUS, " & vbCrLf & _
          "YEAR_LEVEL, RECEIPT_NO, ENROLMENT_DATE, WITHDRAWAL_DATE," & vbCrLf & _
          "ENROLMENT_STATUS, " & vbCrLf & _
          "WITHDRAWAL_REASON_ID, ELIGIBLE_FOR_DISCOUNT, PAID_ON_ENROLMENT, ELIGIBLE_FOR_FUNDING, " & vbCrLf & _
          "DOCS_LAST_REVIEWED_DATE," & vbCrLf & _
          "NEW_DOCS_REQUIRED, " & vbCrLf & _
          "LAST_ALTERED_BY AS STUDENT_ENROLMENT_LAST_ALTERED_BY, " & vbCrLf & _
          "LAST_ALTERED_DATE AS STUDENT_ENROLMENT_LAST_ALTERED_DATE," & vbCrLf & _
          "PASTORAL_CARE_ID, ACER_Username, ACER_Password, REGION_APPROVAL_NUMBER, REGION_ID, " & vbCrLf & _
          "STUDENT_EMAIL, PARENT_EMAIL, WITHDRAWAL_EXIT_DESTINATION," & vbCrLf & _
          "INTAKE_INTERVIEW_DONE, " & vbCrLf & _
          "YEAR_LEVEL_REPORTING, PRIVACY_PERMISSION, ATAR_REQUIRED, PASTORAL_ALLOC_BY, " & vbCrLf & _
          "PASTORAL_ALLOC_DATE," & vbCrLf & _
          "LEARNING_PROGRAM, " & vbCrLf & _
          "SSG_FACILITATOR_ID " & vbCrLf & _
          "FROM STUDENT_ENROLMENT {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID402","And","ENROLMENT_YEAR403"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_ENROLMENT Data Provider Class Constructor

'Record STUDENT_ENROLMENT Data Provider Class LoadParams Method @2-79390024

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID) Or IsNothing(UrlENROLMENT_YEAR))
    End Function
'End Record STUDENT_ENROLMENT Data Provider Class LoadParams Method

'Record STUDENT_ENROLMENT Data Provider Class CheckUnique Method @2-BF72701B

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_ENROLMENTItem) As Boolean
        Return True
    End Function
'End Record STUDENT_ENROLMENT Data Provider Class CheckUnique Method

'Record STUDENT_ENROLMENT Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STUDENT_ENROLMENT Data Provider Class PrepareUpdate Method

'Record STUDENT_ENROLMENT Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record STUDENT_ENROLMENT Data Provider Class PrepareUpdate Method tail

'Record STUDENT_ENROLMENT Data Provider Class Update Method @2-D8A9BD99

    Public Function UpdateItem(ByVal item As STUDENT_ENROLMENTItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT_ENROLMENT SET {Values}", New String(){"STUDENT_ID402","And","ENROLMENT_YEAR403"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_ENROLMENT Data Provider Class Update Method

'Record STUDENT_ENROLMENT BeforeBuildUpdate @2-021E260A
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID402",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ENROLMENT_YEAR403",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        If Not item.PASTORAL_CARE_ID.IsEmpty Then
        allEmptyFlag = item.PASTORAL_CARE_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PASTORAL_CARE_ID=" + Update.Dao.ToSql(item.PASTORAL_CARE_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DOCS_LAST_REVIEWED_DATE.IsEmpty Then
        allEmptyFlag = item.DOCS_LAST_REVIEWED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DOCS_LAST_REVIEWED_DATE=" + Update.Dao.ToSql(item.DOCS_LAST_REVIEWED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.NEW_DOCS_REQUIRED.IsEmpty Then
        allEmptyFlag = item.NEW_DOCS_REQUIRED.IsEmpty And allEmptyFlag
        valuesList = valuesList & "NEW_DOCS_REQUIRED=" + Update.Dao.ToSql(item.NEW_DOCS_REQUIRED.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.Hidden_last_altered_by.IsEmpty Then
        allEmptyFlag = item.Hidden_last_altered_by.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.Hidden_last_altered_by.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_last_altered_date.IsEmpty Then
        allEmptyFlag = item.Hidden_last_altered_date.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.Hidden_last_altered_date.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.YEAR_LEVEL_REPORTING.IsEmpty Then
        allEmptyFlag = item.YEAR_LEVEL_REPORTING.IsEmpty And allEmptyFlag
        valuesList = valuesList & "YEAR_LEVEL_REPORTING=" + Update.Dao.ToSql(item.YEAR_LEVEL_REPORTING.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.PASTORAL_ALLOC_BY.IsEmpty Then
        allEmptyFlag = item.PASTORAL_ALLOC_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PASTORAL_ALLOC_BY=" + Update.Dao.ToSql(item.PASTORAL_ALLOC_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PASTORAL_ALLOC_DATE.IsEmpty Then
        allEmptyFlag = item.PASTORAL_ALLOC_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PASTORAL_ALLOC_DATE=" + Update.Dao.ToSql(item.PASTORAL_ALLOC_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.ATAR_REQUIRED.IsEmpty Then
        allEmptyFlag = item.ATAR_REQUIRED.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ATAR_REQUIRED=" + Update.Dao.ToSql(item.ATAR_REQUIRED.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PRIVACY_PERMISSION.IsEmpty Then
        allEmptyFlag = item.PRIVACY_PERMISSION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRIVACY_PERMISSION=" + Update.Dao.ToSql(item.PRIVACY_PERMISSION.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.INTERVIEW_INTAKE_DONE.IsEmpty Then
        allEmptyFlag = item.INTERVIEW_INTAKE_DONE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "INTAKE_INTERVIEW_DONE=" + Update.Dao.ToSql(item.INTERVIEW_INTAKE_DONE.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.RECEIPT_NO.IsEmpty Then
        allEmptyFlag = item.RECEIPT_NO.IsEmpty And allEmptyFlag
        valuesList = valuesList & "RECEIPT_NO=" + Update.Dao.ToSql(item.RECEIPT_NO.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.lbEXIT_DESTINATION.IsEmpty Then
        allEmptyFlag = item.lbEXIT_DESTINATION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "WITHDRAWAL_EXIT_DESTINATION=" + Update.Dao.ToSql(item.lbEXIT_DESTINATION.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.WITHDRAWAL_REASON_ID.IsEmpty Then
        allEmptyFlag = item.WITHDRAWAL_REASON_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "WITHDRAWAL_REASON_ID=" + Update.Dao.ToSql(item.WITHDRAWAL_REASON_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.list_Region.IsEmpty Then
        allEmptyFlag = item.list_Region.IsEmpty And allEmptyFlag
        valuesList = valuesList & "REGION_ID=" + Update.Dao.ToSql(item.list_Region.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.region_approval_number.IsEmpty Then
        allEmptyFlag = item.region_approval_number.IsEmpty And allEmptyFlag
        valuesList = valuesList & "REGION_APPROVAL_NUMBER=" + Update.Dao.ToSql(item.region_approval_number.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ELIGIBLE_FOR_FUNDING.IsEmpty Then
        allEmptyFlag = item.ELIGIBLE_FOR_FUNDING.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ELIGIBLE_FOR_FUNDING=" + Update.Dao.ToSql(item.ELIGIBLE_FOR_FUNDING.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.PAID_ON_ENROLMENT.IsEmpty Then
        allEmptyFlag = item.PAID_ON_ENROLMENT.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PAID_ON_ENROLMENT=" + Update.Dao.ToSql(item.PAID_ON_ENROLMENT.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.ELIGIBLE_FOR_DISCOUNT.IsEmpty Then
        allEmptyFlag = item.ELIGIBLE_FOR_DISCOUNT.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ELIGIBLE_FOR_DISCOUNT=" + Update.Dao.ToSql(item.ELIGIBLE_FOR_DISCOUNT.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.YEAR_LEVEL.IsEmpty Then
        allEmptyFlag = item.YEAR_LEVEL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "YEAR_LEVEL=" + Update.Dao.ToSql(item.YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.ENROLMENT_STATUS.IsEmpty Then
        allEmptyFlag = item.ENROLMENT_STATUS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ENROLMENT_STATUS=" + Update.Dao.ToSql(item.ENROLMENT_STATUS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.WITHDRAWAL_DATE.IsEmpty Then
        allEmptyFlag = item.WITHDRAWAL_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "WITHDRAWAL_DATE=" + Update.Dao.ToSql(item.WITHDRAWAL_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.ENROLMENT_DATE.IsEmpty Then
        allEmptyFlag = item.ENROLMENT_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ENROLMENT_DATE=" + Update.Dao.ToSql(item.ENROLMENT_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.PERSONAL_LEARNING_PLAN.IsEmpty Then
        allEmptyFlag = item.PERSONAL_LEARNING_PLAN.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LEARNING_PROGRAM=" + Update.Dao.ToSql(item.PERSONAL_LEARNING_PLAN.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SSG_FACILITATOR_ID.IsEmpty Then
        allEmptyFlag = item.SSG_FACILITATOR_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SSG_FACILITATOR_ID=" + Update.Dao.ToSql(item.SSG_FACILITATOR_ID.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STUDENT_ENROLMENT BeforeBuildUpdate

'Record STUDENT_ENROLMENT AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_ENROLMENT AfterExecuteUpdate

'Record STUDENT_ENROLMENT Data Provider Class GetResultSet Method @2-6E5BBB74

    Public Sub FillItem(ByVal item As STUDENT_ENROLMENTItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_ENROLMENT Data Provider Class GetResultSet Method

'Record STUDENT_ENROLMENT BeforeBuildSelect @2-D54311B9
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID402",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("ENROLMENT_YEAR403",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_ENROLMENT BeforeBuildSelect

'Record STUDENT_ENROLMENT BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_ENROLMENT BeforeExecuteSelect

'Record STUDENT_ENROLMENT AfterExecuteSelect @2-8827D5F1
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.PASTORAL_CARE_ID.SetValue(dr(i)("PASTORAL_CARE_ID"),"")
            item.DOCS_LAST_REVIEWED_DATE.SetValue(dr(i)("DOCS_LAST_REVIEWED_DATE"),Select_.DateFormat)
            item.NEW_DOCS_REQUIRED.SetValue(dr(i)("NEW_DOCS_REQUIRED"),Select_.BoolFormat)
            item.LAST_ALTERED_BY.SetValue(dr(i)("STUDENT_ENROLMENT_LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("STUDENT_ENROLMENT_LAST_ALTERED_DATE"),Select_.DateFormat)
            item.Hidden_last_altered_by.SetValue(dr(i)("STUDENT_ENROLMENT_LAST_ALTERED_BY"),"")
            item.Hidden_last_altered_date.SetValue(dr(i)("STUDENT_ENROLMENT_LAST_ALTERED_DATE"),Select_.DateFormat)
            item.YEAR_LEVEL_REPORTING.SetValue(dr(i)("YEAR_LEVEL_REPORTING"),"")
            item.PASTORAL_ALLOC_BY.SetValue(dr(i)("PASTORAL_ALLOC_BY"),"")
            item.PASTORAL_ALLOC_DATE.SetValue(dr(i)("PASTORAL_ALLOC_DATE"),Select_.DateFormat)
            item.LAd_ALLOC_BY.SetValue(dr(i)("PASTORAL_ALLOC_BY"),"")
            item.LAd_ALLOC_DATE.SetValue(dr(i)("PASTORAL_ALLOC_DATE"),Select_.DateFormat)
            item.ATAR_REQUIRED.SetValue(dr(i)("ATAR_REQUIRED"),"")
            item.PRIVACY_PERMISSION.SetValue(dr(i)("PRIVACY_PERMISSION"),Select_.BoolFormat)
            item.INTERVIEW_INTAKE_DONE.SetValue(dr(i)("INTAKE_INTERVIEW_DONE"),Select_.BoolFormat)
            item.RECEIPT_NO.SetValue(dr(i)("RECEIPT_NO"),"")
            item.lbEXIT_DESTINATION.SetValue(dr(i)("WITHDRAWAL_EXIT_DESTINATION"),"")
            item.WITHDRAWAL_REASON_ID.SetValue(dr(i)("WITHDRAWAL_REASON_ID"),"")
            item.list_Region.SetValue(dr(i)("REGION_ID"),"")
            item.region_approval_number.SetValue(dr(i)("REGION_APPROVAL_NUMBER"),"")
            item.ELIGIBLE_FOR_FUNDING.SetValue(dr(i)("ELIGIBLE_FOR_FUNDING"),Select_.BoolFormat)
            item.PAID_ON_ENROLMENT.SetValue(dr(i)("PAID_ON_ENROLMENT"),Select_.BoolFormat)
            item.ELIGIBLE_FOR_DISCOUNT.SetValue(dr(i)("ELIGIBLE_FOR_DISCOUNT"),Select_.BoolFormat)
            item.ENROLMENT_YEAR.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
            item.ENROLMENT_STATUS.SetValue(dr(i)("ENROLMENT_STATUS"),"")
            item.WITHDRAWAL_DATE.SetValue(dr(i)("WITHDRAWAL_DATE"),Select_.DateFormat)
            item.ENROLMENT_DATE.SetValue(dr(i)("ENROLMENT_DATE"),Select_.DateFormat)
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ENROLMENT_STUDENT_ID"),"")
            item.PERSONAL_LEARNING_PLAN.SetValue(dr(i)("LEARNING_PROGRAM"),"")
            item.SSG_FACILITATOR_ID.SetValue(dr(i)("SSG_FACILITATOR_ID"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record STUDENT_ENROLMENT AfterExecuteSelect

'ListBox PASTORAL_CARE_ID Initialize Data Source @54-6F1D4BDE
        PASTORAL_CARE_IDDataCommand.Dao._optimized = False
        Dim PASTORAL_CARE_IDtableIndex As Integer = 0
        PASTORAL_CARE_IDDataCommand.OrderBy = "status_type, staffname"
        PASTORAL_CARE_IDDataCommand.Parameters.Clear()
'End ListBox PASTORAL_CARE_ID Initialize Data Source

'ListBox PASTORAL_CARE_ID BeforeExecuteSelect @54-94F2041D
        Try
            ListBoxSource=PASTORAL_CARE_IDDataCommand.Execute().Tables(PASTORAL_CARE_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox PASTORAL_CARE_ID BeforeExecuteSelect

'ListBox PASTORAL_CARE_ID AfterExecuteSelect @54-1D8713F7
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("STAFF_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("staffname")
            item.PASTORAL_CARE_IDItems.Add(Key, Val)
        Next
'End ListBox PASTORAL_CARE_ID AfterExecuteSelect

'ListBox NEW_DOCS_REQUIRED AfterExecuteSelect @65-166C6FEE
        
item.NEW_DOCS_REQUIREDItems.Add("Yes","Yes")
item.NEW_DOCS_REQUIREDItems.Add("No","No")
'End ListBox NEW_DOCS_REQUIRED AfterExecuteSelect

'ListBox YEAR_LEVEL_REPORTING AfterExecuteSelect @208-21442E61
        
item.YEAR_LEVEL_REPORTINGItems.Add("0","0 - Prep")
item.YEAR_LEVEL_REPORTINGItems.Add("1","1")
item.YEAR_LEVEL_REPORTINGItems.Add("2","2")
item.YEAR_LEVEL_REPORTINGItems.Add("3","3")
item.YEAR_LEVEL_REPORTINGItems.Add("4","4")
item.YEAR_LEVEL_REPORTINGItems.Add("5","5")
item.YEAR_LEVEL_REPORTINGItems.Add("6","6")
item.YEAR_LEVEL_REPORTINGItems.Add("7","7")
item.YEAR_LEVEL_REPORTINGItems.Add("8","8")
item.YEAR_LEVEL_REPORTINGItems.Add("9","9")
item.YEAR_LEVEL_REPORTINGItems.Add("10","10")
item.YEAR_LEVEL_REPORTINGItems.Add("11","11")
item.YEAR_LEVEL_REPORTINGItems.Add("12","12")
item.YEAR_LEVEL_REPORTINGItems.Add("30","Home Schooled")
'End ListBox YEAR_LEVEL_REPORTING AfterExecuteSelect

'ListBox ATAR_REQUIRED AfterExecuteSelect @223-810759C1
        
item.ATAR_REQUIREDItems.Add("Y","Yes - ATAR Required")
item.ATAR_REQUIREDItems.Add("N","No - ATAR NOT Required")
'End ListBox ATAR_REQUIRED AfterExecuteSelect

'ListBox PRIVACY_PERMISSION AfterExecuteSelect @216-6EB535AA
        
item.PRIVACY_PERMISSIONItems.Add("Yes","Yes")
item.PRIVACY_PERMISSIONItems.Add("No","No")
'End ListBox PRIVACY_PERMISSION AfterExecuteSelect

'ListBox INTERVIEW_INTAKE_DONE AfterExecuteSelect @182-AE287513
        
item.INTERVIEW_INTAKE_DONEItems.Add("Yes","Yes")
item.INTERVIEW_INTAKE_DONEItems.Add("No","No")
'End ListBox INTERVIEW_INTAKE_DONE AfterExecuteSelect

'ListBox lbEXIT_DESTINATION Initialize Data Source @176-D369D5B8
        lbEXIT_DESTINATIONDataCommand.Dao._optimized = False
        Dim lbEXIT_DESTINATIONtableIndex As Integer = 0
        lbEXIT_DESTINATIONDataCommand.OrderBy = "DISPLAY_ORDER"
        lbEXIT_DESTINATIONDataCommand.Parameters.Clear()
        lbEXIT_DESTINATIONDataCommand.Parameters.Add("expr181","(DISPLAY_ORDER > 0)")
'End ListBox lbEXIT_DESTINATION Initialize Data Source

'ListBox lbEXIT_DESTINATION BeforeExecuteSelect @176-A836CBCE
        Try
            ListBoxSource=lbEXIT_DESTINATIONDataCommand.Execute().Tables(lbEXIT_DESTINATIONtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox lbEXIT_DESTINATION BeforeExecuteSelect

'ListBox lbEXIT_DESTINATION AfterExecuteSelect @176-12F2372D
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New FloatField("", ListBoxSource(j)("WD_DEST_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("EXIT_DESTINATION_DESCRIPTION")
            item.lbEXIT_DESTINATIONItems.Add(Key, Val)
        Next
'End ListBox lbEXIT_DESTINATION AfterExecuteSelect

'ListBox WITHDRAWAL_REASON_ID Initialize Data Source @13-C9CCD83A
        WITHDRAWAL_REASON_IDDataCommand.Dao._optimized = False
        Dim WITHDRAWAL_REASON_IDtableIndex As Integer = 0
        WITHDRAWAL_REASON_IDDataCommand.OrderBy = "WITHDRAWAL_REASON"
        WITHDRAWAL_REASON_IDDataCommand.Parameters.Clear()
        WITHDRAWAL_REASON_IDDataCommand.Parameters.Add("expr232","(STATUS = 1)")
'End ListBox WITHDRAWAL_REASON_ID Initialize Data Source

'ListBox WITHDRAWAL_REASON_ID BeforeExecuteSelect @13-AAF6FC16
        Try
            ListBoxSource=WITHDRAWAL_REASON_IDDataCommand.Execute().Tables(WITHDRAWAL_REASON_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox WITHDRAWAL_REASON_ID BeforeExecuteSelect

'ListBox WITHDRAWAL_REASON_ID AfterExecuteSelect @13-84798B21
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New FloatField("", ListBoxSource(j)("WITHDRAWAL_REASON_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("WITHDRAWAL_REASON")
            item.WITHDRAWAL_REASON_IDItems.Add(Key, Val)
        Next
'End ListBox WITHDRAWAL_REASON_ID AfterExecuteSelect

'ListBox list_Region Initialize Data Source @117-E62B32E4
        list_RegionDataCommand.Dao._optimized = False
        Dim list_RegiontableIndex As Integer = 0
        list_RegionDataCommand.OrderBy = "REGION_NAME"
        list_RegionDataCommand.Parameters.Clear()
'End ListBox list_Region Initialize Data Source

'ListBox list_Region BeforeExecuteSelect @117-EC026915
        Try
            ListBoxSource=list_RegionDataCommand.Execute().Tables(list_RegiontableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox list_Region BeforeExecuteSelect

'ListBox list_Region AfterExecuteSelect @117-AD4AC27B
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("REGION_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("region_name_display")
            item.list_RegionItems.Add(Key, Val)
        Next
'End ListBox list_Region AfterExecuteSelect

'ListBox ELIGIBLE_FOR_FUNDING AfterExecuteSelect @64-37B981B2
        
item.ELIGIBLE_FOR_FUNDINGItems.Add("Yes","Yes")
item.ELIGIBLE_FOR_FUNDINGItems.Add("No","No")
'End ListBox ELIGIBLE_FOR_FUNDING AfterExecuteSelect

'ListBox PAID_ON_ENROLMENT AfterExecuteSelect @62-C642CB4D
        
item.PAID_ON_ENROLMENTItems.Add("Yes","Yes")
item.PAID_ON_ENROLMENTItems.Add("No","No")
'End ListBox PAID_ON_ENROLMENT AfterExecuteSelect

'ListBox ELIGIBLE_FOR_DISCOUNT AfterExecuteSelect @59-B80B8A7D
        
item.ELIGIBLE_FOR_DISCOUNTItems.Add("Yes","Yes")
item.ELIGIBLE_FOR_DISCOUNTItems.Add("No","No")
'End ListBox ELIGIBLE_FOR_DISCOUNT AfterExecuteSelect

'ListBox YEAR_LEVEL AfterExecuteSelect @14-EB7813C0
        
item.YEAR_LEVELItems.Add("0","0 - Prep")
item.YEAR_LEVELItems.Add("1","1")
item.YEAR_LEVELItems.Add("2","2")
item.YEAR_LEVELItems.Add("3","3")
item.YEAR_LEVELItems.Add("4","4")
item.YEAR_LEVELItems.Add("5","5")
item.YEAR_LEVELItems.Add("6","6")
item.YEAR_LEVELItems.Add("7","7")
item.YEAR_LEVELItems.Add("8","8")
item.YEAR_LEVELItems.Add("9","9")
item.YEAR_LEVELItems.Add("10","10")
item.YEAR_LEVELItems.Add("11","11")
item.YEAR_LEVELItems.Add("12","12")
item.YEAR_LEVELItems.Add("30","Home Schooled")
'End ListBox YEAR_LEVEL AfterExecuteSelect

'ListBox ENROLMENT_STATUS AfterExecuteSelect @12-AD8965F8
        
item.ENROLMENT_STATUSItems.Add("E","Enrolled")
item.ENROLMENT_STATUSItems.Add("N","Not Enrolled")
item.ENROLMENT_STATUSItems.Add("F","Future Enrolment")
'End ListBox ENROLMENT_STATUS AfterExecuteSelect

'ListBox PERSONAL_LEARNING_PLAN AfterExecuteSelect @318-B46049B9
        
item.PERSONAL_LEARNING_PLANItems.Add("PLP","Personal Learning Plan (default)")
item.PERSONAL_LEARNING_PLANItems.Add("PLSP","Mandated IEP")
item.PERSONAL_LEARNING_PLANItems.Add("PEN","Mandated IEP Eligibility Pending Review")
'End ListBox PERSONAL_LEARNING_PLAN AfterExecuteSelect

'ListBox SSG_FACILITATOR_ID Initialize Data Source @399-8F3F7581
        SSG_FACILITATOR_IDDataCommand.Dao._optimized = False
        Dim SSG_FACILITATOR_IDtableIndex As Integer = 0
        SSG_FACILITATOR_IDDataCommand.OrderBy = "status_type, staffname"
        SSG_FACILITATOR_IDDataCommand.Parameters.Clear()
'End ListBox SSG_FACILITATOR_ID Initialize Data Source

'ListBox SSG_FACILITATOR_ID BeforeExecuteSelect @399-24947310
        Try
            ListBoxSource=SSG_FACILITATOR_IDDataCommand.Execute().Tables(SSG_FACILITATOR_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox SSG_FACILITATOR_ID BeforeExecuteSelect

'ListBox SSG_FACILITATOR_ID AfterExecuteSelect @399-587FF22D
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("STAFF_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("staffname")
            item.SSG_FACILITATOR_IDItems.Add(Key, Val)
        Next
'End ListBox SSG_FACILITATOR_ID AfterExecuteSelect

'Record STUDENT_ENROLMENT AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record STUDENT_ENROLMENT AfterExecuteSelect tail

'Record STUDENT_ENROLMENT Data Provider Class @2-A61BA892
End Class

'End Record STUDENT_ENROLMENT Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

