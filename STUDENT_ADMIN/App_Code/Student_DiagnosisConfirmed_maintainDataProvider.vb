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

Namespace DECV_PROD2007.Student_DiagnosisConfirmed_maintain 'Namespace @1-6FBCFF09

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

'Record STUDENT_DIAGNOSIS_DATA Item Class @2-8C3167DA
Public Class STUDENT_DIAGNOSIS_DATAItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public STUDENT_ID As TextField
    Public WELLBEING_COMMENTS As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Hidden_last_altered_date As DateField
    Public STUDENT_INCLUSION_OTHER As TextField
    Public RadioButton_ReferredBy As TextField
    Public RadioButton_ReferredByItems As ItemCollection
    Public SUPPORT_AT_ENROLMENT_TYPE As TextField
    Public SUPPORT_AT_ENROLMENT_TYPEItems As ItemCollection
    Public CheckBoxList_Wellbeing As TextField
    Public CheckBoxList_WellbeingItems As ItemCollection
    Public RadioButton_Reactivation As TextField
    Public RadioButton_ReactivationItems As ItemCollection
    Public RadioButton_Previous_Enrol As TextField
    Public RadioButton_Previous_EnrolItems As ItemCollection
    Public CheckBoxList_Inclusion As TextField
    Public CheckBoxList_InclusionItems As ItemCollection
    Public STUDENT_WELLBEING_OTHER As TextField
    Public Hidden_WellbeingList As TextField
    Public Hidden_InclusionList As TextField
    Public list_REGION As TextField
    Public list_REGIONItems As ItemCollection
    Public RadioButton_Support As TextField
    Public RadioButton_SupportItems As ItemCollection
    Public Hidden_SupportList As TextField
    Public Hidden_enrolyear As FloatField
    Public Hidden_StudentId As FloatField
    Public Hidden_last_altered_by As TextField
    Public ENROLMENT_YEAR As TextField
    Public RadioButton_Referral As TextField
    Public RadioButton_ReferralItems As ItemCollection
    Public RadioButton_Inclusion As TextField
    Public RadioButton_InclusionItems As ItemCollection
    Public RadioButton_Wellbeing As TextField
    Public RadioButton_WellbeingItems As ItemCollection
    Public Sub New()
    STUDENT_ID = New TextField("", Nothing)
    WELLBEING_COMMENTS = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    Hidden_last_altered_date = New DateField("yyyy-MM-dd H\:mm", DateTime.Now)
    STUDENT_INCLUSION_OTHER = New TextField("", Nothing)
    RadioButton_ReferredBy = New TextField("", Nothing)
    RadioButton_ReferredByItems = New ItemCollection()
    SUPPORT_AT_ENROLMENT_TYPE = New TextField("", "0")
    SUPPORT_AT_ENROLMENT_TYPEItems = New ItemCollection()
    CheckBoxList_Wellbeing = New TextField("", Nothing)
    CheckBoxList_WellbeingItems = New ItemCollection()
    RadioButton_Reactivation = New TextField("", "N")
    RadioButton_ReactivationItems = New ItemCollection()
    RadioButton_Previous_Enrol = New TextField("", "N")
    RadioButton_Previous_EnrolItems = New ItemCollection()
    CheckBoxList_Inclusion = New TextField("", Nothing)
    CheckBoxList_InclusionItems = New ItemCollection()
    STUDENT_WELLBEING_OTHER = New TextField("", Nothing)
    Hidden_WellbeingList = New TextField("", "0,")
    Hidden_InclusionList = New TextField("", "0,")
    list_REGION = New TextField("", Nothing)
    list_REGIONItems = New ItemCollection()
    RadioButton_Support = New TextField("", "N")
    RadioButton_SupportItems = New ItemCollection()
    Hidden_SupportList = New TextField("", "0,")
    Hidden_enrolyear = New FloatField("", Year(Now()))
    Hidden_StudentId = New FloatField("", Nothing)
    Hidden_last_altered_by = New TextField("", DBUtility.UserLogin.ToUpper)
    ENROLMENT_YEAR = New TextField("", Nothing)
    RadioButton_Referral = New TextField("", "N")
    RadioButton_ReferralItems = New ItemCollection()
    RadioButton_Inclusion = New TextField("", "N")
    RadioButton_InclusionItems = New ItemCollection()
    RadioButton_Wellbeing = New TextField("", "N")
    RadioButton_WellbeingItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_DIAGNOSIS_DATAItem
        Dim item As STUDENT_DIAGNOSIS_DATAItem = New STUDENT_DIAGNOSIS_DATAItem()
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("WELLBEING_COMMENTS")) Then
        item.WELLBEING_COMMENTS.SetValue(DBUtility.GetInitialValue("WELLBEING_COMMENTS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_last_altered_date")) Then
        item.Hidden_last_altered_date.SetValue(DBUtility.GetInitialValue("Hidden_last_altered_date"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_INCLUSION_OTHER")) Then
        item.STUDENT_INCLUSION_OTHER.SetValue(DBUtility.GetInitialValue("STUDENT_INCLUSION_OTHER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RadioButton_ReferredBy")) Then
        item.RadioButton_ReferredBy.SetValue(DBUtility.GetInitialValue("RadioButton_ReferredBy"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPPORT_AT_ENROLMENT_TYPE")) Then
        item.SUPPORT_AT_ENROLMENT_TYPE.SetValue(DBUtility.GetInitialValue("SUPPORT_AT_ENROLMENT_TYPE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CheckBoxList_Wellbeing")) Then
        item.CheckBoxList_Wellbeing.SetValue(DBUtility.GetInitialValue("CheckBoxList_Wellbeing"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RadioButton_Reactivation")) Then
        item.RadioButton_Reactivation.SetValue(DBUtility.GetInitialValue("RadioButton_Reactivation"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RadioButton_Previous_Enrol")) Then
        item.RadioButton_Previous_Enrol.SetValue(DBUtility.GetInitialValue("RadioButton_Previous_Enrol"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CheckBoxList_Inclusion")) Then
        item.CheckBoxList_Inclusion.SetValue(DBUtility.GetInitialValue("CheckBoxList_Inclusion"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_WELLBEING_OTHER")) Then
        item.STUDENT_WELLBEING_OTHER.SetValue(DBUtility.GetInitialValue("STUDENT_WELLBEING_OTHER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_WellbeingList")) Then
        item.Hidden_WellbeingList.SetValue(DBUtility.GetInitialValue("Hidden_WellbeingList"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_InclusionList")) Then
        item.Hidden_InclusionList.SetValue(DBUtility.GetInitialValue("Hidden_InclusionList"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("list_REGION")) Then
        item.list_REGION.SetValue(DBUtility.GetInitialValue("list_REGION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RadioButton_Support")) Then
        item.RadioButton_Support.SetValue(DBUtility.GetInitialValue("RadioButton_Support"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_SupportList")) Then
        item.Hidden_SupportList.SetValue(DBUtility.GetInitialValue("Hidden_SupportList"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_enrolyear")) Then
        item.Hidden_enrolyear.SetValue(DBUtility.GetInitialValue("Hidden_enrolyear"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_StudentId")) Then
        item.Hidden_StudentId.SetValue(DBUtility.GetInitialValue("Hidden_StudentId"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_last_altered_by")) Then
        item.Hidden_last_altered_by.SetValue(DBUtility.GetInitialValue("Hidden_last_altered_by"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_YEAR")) Then
        item.ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RadioButton_Referral")) Then
        item.RadioButton_Referral.SetValue(DBUtility.GetInitialValue("RadioButton_Referral"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RadioButton_Inclusion")) Then
        item.RadioButton_Inclusion.SetValue(DBUtility.GetInitialValue("RadioButton_Inclusion"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RadioButton_Wellbeing")) Then
        item.RadioButton_Wellbeing.SetValue(DBUtility.GetInitialValue("RadioButton_Wellbeing"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "WELLBEING_COMMENTS"
                    Return WELLBEING_COMMENTS
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "Hidden_last_altered_date"
                    Return Hidden_last_altered_date
                Case "STUDENT_INCLUSION_OTHER"
                    Return STUDENT_INCLUSION_OTHER
                Case "RadioButton_ReferredBy"
                    Return RadioButton_ReferredBy
                Case "SUPPORT_AT_ENROLMENT_TYPE"
                    Return SUPPORT_AT_ENROLMENT_TYPE
                Case "CheckBoxList_Wellbeing"
                    Return CheckBoxList_Wellbeing
                Case "RadioButton_Reactivation"
                    Return RadioButton_Reactivation
                Case "RadioButton_Previous_Enrol"
                    Return RadioButton_Previous_Enrol
                Case "CheckBoxList_Inclusion"
                    Return CheckBoxList_Inclusion
                Case "STUDENT_WELLBEING_OTHER"
                    Return STUDENT_WELLBEING_OTHER
                Case "Hidden_WellbeingList"
                    Return Hidden_WellbeingList
                Case "Hidden_InclusionList"
                    Return Hidden_InclusionList
                Case "list_REGION"
                    Return list_REGION
                Case "RadioButton_Support"
                    Return RadioButton_Support
                Case "Hidden_SupportList"
                    Return Hidden_SupportList
                Case "Hidden_enrolyear"
                    Return Hidden_enrolyear
                Case "Hidden_StudentId"
                    Return Hidden_StudentId
                Case "Hidden_last_altered_by"
                    Return Hidden_last_altered_by
                Case "ENROLMENT_YEAR"
                    Return ENROLMENT_YEAR
                Case "RadioButton_Referral"
                    Return RadioButton_Referral
                Case "RadioButton_Inclusion"
                    Return RadioButton_Inclusion
                Case "RadioButton_Wellbeing"
                    Return RadioButton_Wellbeing
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, TextField)
                Case "WELLBEING_COMMENTS"
                    WELLBEING_COMMENTS = CType(value, TextField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "Hidden_last_altered_date"
                    Hidden_last_altered_date = CType(value, DateField)
                Case "STUDENT_INCLUSION_OTHER"
                    STUDENT_INCLUSION_OTHER = CType(value, TextField)
                Case "RadioButton_ReferredBy"
                    RadioButton_ReferredBy = CType(value, TextField)
                Case "SUPPORT_AT_ENROLMENT_TYPE"
                    SUPPORT_AT_ENROLMENT_TYPE = CType(value, TextField)
                Case "CheckBoxList_Wellbeing"
                    CheckBoxList_Wellbeing = CType(value, TextField)
                Case "RadioButton_Reactivation"
                    RadioButton_Reactivation = CType(value, TextField)
                Case "RadioButton_Previous_Enrol"
                    RadioButton_Previous_Enrol = CType(value, TextField)
                Case "CheckBoxList_Inclusion"
                    CheckBoxList_Inclusion = CType(value, TextField)
                Case "STUDENT_WELLBEING_OTHER"
                    STUDENT_WELLBEING_OTHER = CType(value, TextField)
                Case "Hidden_WellbeingList"
                    Hidden_WellbeingList = CType(value, TextField)
                Case "Hidden_InclusionList"
                    Hidden_InclusionList = CType(value, TextField)
                Case "list_REGION"
                    list_REGION = CType(value, TextField)
                Case "RadioButton_Support"
                    RadioButton_Support = CType(value, TextField)
                Case "Hidden_SupportList"
                    Hidden_SupportList = CType(value, TextField)
                Case "Hidden_enrolyear"
                    Hidden_enrolyear = CType(value, FloatField)
                Case "Hidden_StudentId"
                    Hidden_StudentId = CType(value, FloatField)
                Case "Hidden_last_altered_by"
                    Hidden_last_altered_by = CType(value, TextField)
                Case "ENROLMENT_YEAR"
                    ENROLMENT_YEAR = CType(value, TextField)
                Case "RadioButton_Referral"
                    RadioButton_Referral = CType(value, TextField)
                Case "RadioButton_Inclusion"
                    RadioButton_Inclusion = CType(value, TextField)
                Case "RadioButton_Wellbeing"
                    RadioButton_Wellbeing = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STUDENT_DIAGNOSIS_DATADataProvider)
'End Record STUDENT_DIAGNOSIS_DATA Item Class

'DEL      ' -------------------------
'DEL      ' load up the previous school id
'DEL      If IsNothing(PREVIOUS_SCHOOL_ID.Value) OrElse PREVIOUS_SCHOOL_ID.Value.ToString() ="" Then
'DEL  	    tmpPrevSchoolID = ""
'DEL  	else
'DEL  		tmpPrevSchoolID = PREVIOUS_SCHOOL_ID.Value.ToString()	' code generation doesn't like it for some reason, so done here manually.
'DEL  	end if
'DEL  	
'DEL  	If (tmpPrevSchoolID <> "") Then
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL      ' ERA: if the previous school id is entered then if there are no schools matching then raise an error
'DEL  		If (tmpPrevSchoolID.ToString() <> "") and (tmpSchoolCount = 0) Then
'DEL              errors.Add("PREVIOUS_SCHOOL_ID", "There is no School for that PREVIOUS SCHOOL ID. Please check it, or leave it blank")
'DEL  	   	End If
'DEL  
'DEL  	End If	' DB lookup
'DEL      ' -------------------------

'RadioButton_ReferredBy validate @102-2A7DED4E
        If IsNothing(RadioButton_ReferredBy.Value) OrElse RadioButton_ReferredBy.Value.ToString() ="" Then
            errors.Add("RadioButton_ReferredBy",String.Format(Resources.strings.CCS_RequiredField,"Referred By"))
        End If
'End RadioButton_ReferredBy validate

'RadioButton_Previous_Enrol validate @108-A25ED4C3
        If IsNothing(RadioButton_Previous_Enrol.Value) OrElse RadioButton_Previous_Enrol.Value.ToString() ="" Then
            errors.Add("RadioButton_Previous_Enrol",String.Format(Resources.strings.CCS_RequiredField,"Reason for Study"))
        End If
'End RadioButton_Previous_Enrol validate

'Hidden_StudentId validate @140-80C88ABC
        If IsNothing(Hidden_StudentId.Value) OrElse Hidden_StudentId.Value.ToString() ="" Then
            errors.Add("Hidden_StudentId",String.Format(Resources.strings.CCS_RequiredField,"Hidden_StudentId"))
        End If
'End Hidden_StudentId validate

'Record STUDENT_DIAGNOSIS_DATA Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_DIAGNOSIS_DATA Item Class tail

'Record STUDENT_DIAGNOSIS_DATA Data Provider Class @2-367C1997
Public Class STUDENT_DIAGNOSIS_DATADataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_DIAGNOSIS_DATA Data Provider Class

'Record STUDENT_DIAGNOSIS_DATA Data Provider Class Variables @2-92A4E56F
    Protected list_REGIONDataCommand As DataCommand=new TableCommand("SELECT REGION_ID, REGION_NAME " & vbCrLf & _
          "FROM REGION {SQL_Where} {SQL_OrderBy}", New String(){"expr192"},Settings.connDECVPRODSQL2005DataAccessObject )
    Public UrlSTUDENT_ID As FloatParameter
    Public UrlENROLMENT_YEAR As FloatParameter
    Protected item As STUDENT_DIAGNOSIS_DATAItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_DIAGNOSIS_DATA Data Provider Class Variables

'Record STUDENT_DIAGNOSIS_DATA Data Provider Class Constructor @2-99FD4DB4

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_DIAGNOSIS_CONFIRMED {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID236","And","ENROLMENT_YEAR237"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_DIAGNOSIS_DATA Data Provider Class Constructor

'Record STUDENT_DIAGNOSIS_DATA Data Provider Class LoadParams Method @2-79390024

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID) Or IsNothing(UrlENROLMENT_YEAR))
    End Function
'End Record STUDENT_DIAGNOSIS_DATA Data Provider Class LoadParams Method

'Record STUDENT_DIAGNOSIS_DATA Data Provider Class CheckUnique Method @2-FA306C09

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_DIAGNOSIS_DATAItem) As Boolean
        Return True
    End Function
'End Record STUDENT_DIAGNOSIS_DATA Data Provider Class CheckUnique Method

'Record STUDENT_DIAGNOSIS_DATA Data Provider Class PrepareInsert Method @2-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STUDENT_DIAGNOSIS_DATA Data Provider Class PrepareInsert Method

'Record STUDENT_DIAGNOSIS_DATA Data Provider Class PrepareInsert Method tail @2-E31F8E2A
    End Sub
'End Record STUDENT_DIAGNOSIS_DATA Data Provider Class PrepareInsert Method tail

'Record STUDENT_DIAGNOSIS_DATA Data Provider Class Insert Method @2-FFC0C948

    Public Function InsertItem(ByVal item As STUDENT_DIAGNOSIS_DATAItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO STUDENT_DIAGNOSIS_CONFIRMED({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_DIAGNOSIS_DATA Data Provider Class Insert Method

'Record STUDENT_DIAGNOSIS_DATA Build insert @2-A5342D75
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.WELLBEING_COMMENTS.IsEmpty Then
        allEmptyFlag = item.WELLBEING_COMMENTS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "WELLBEING_COMMENTS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.WELLBEING_COMMENTS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_last_altered_date.IsEmpty Then
        allEmptyFlag = item.Hidden_last_altered_date.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_last_altered_date.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.STUDENT_INCLUSION_OTHER.IsEmpty Then
        allEmptyFlag = item.STUDENT_INCLUSION_OTHER.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STUDENT_INCLUSION_OTHER,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STUDENT_INCLUSION_OTHER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RadioButton_ReferredBy.IsEmpty Then
        allEmptyFlag = item.RadioButton_ReferredBy.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "REFERRED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.RadioButton_ReferredBy.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RadioButton_Reactivation.IsEmpty Then
        allEmptyFlag = item.RadioButton_Reactivation.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "REACTIVATION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.RadioButton_Reactivation.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RadioButton_Previous_Enrol.IsEmpty Then
        allEmptyFlag = item.RadioButton_Previous_Enrol.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PREVIOUS_ENROLMENT,"
        valuesList = valuesList & Insert.Dao.ToSql(item.RadioButton_Previous_Enrol.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STUDENT_WELLBEING_OTHER.IsEmpty Then
        allEmptyFlag = item.STUDENT_WELLBEING_OTHER.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STUDENT_WELLBEING_OTHER,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STUDENT_WELLBEING_OTHER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_WellbeingList.IsEmpty Then
        allEmptyFlag = item.Hidden_WellbeingList.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STUDENT_WELLBEING,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_WellbeingList.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_InclusionList.IsEmpty Then
        allEmptyFlag = item.Hidden_InclusionList.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STUDENT_INCLUSION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_InclusionList.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.list_REGION.IsEmpty Then
        allEmptyFlag = item.list_REGION.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "REGION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.list_REGION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RadioButton_Support.IsEmpty Then
        allEmptyFlag = item.RadioButton_Support.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUPPORT_AT_ENROLMENT,"
        valuesList = valuesList & Insert.Dao.ToSql(item.RadioButton_Support.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_SupportList.IsEmpty Then
        allEmptyFlag = item.Hidden_SupportList.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUPPORT_AT_ENROLMENT_TYPE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_SupportList.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_enrolyear.IsEmpty Then
        allEmptyFlag = item.Hidden_enrolyear.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ENROLMENT_YEAR,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_enrolyear.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.Hidden_StudentId.IsEmpty Then
        allEmptyFlag = item.Hidden_StudentId.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STUDENT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_StudentId.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.Hidden_last_altered_by.IsEmpty Then
        allEmptyFlag = item.Hidden_last_altered_by.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_last_altered_by.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RadioButton_Referral.IsEmpty Then
        allEmptyFlag = item.RadioButton_Referral.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "REFERRAL_AT_ENROLMENT,"
        valuesList = valuesList & Insert.Dao.ToSql(item.RadioButton_Referral.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RadioButton_Inclusion.IsEmpty Then
        allEmptyFlag = item.RadioButton_Inclusion.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "KNOWN_INCLUSION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.RadioButton_Inclusion.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RadioButton_Wellbeing.IsEmpty Then
        allEmptyFlag = item.RadioButton_Wellbeing.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "KNOWN_WELLBEING,"
        valuesList = valuesList & Insert.Dao.ToSql(item.RadioButton_Wellbeing.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STUDENT_DIAGNOSIS_DATA Build insert

'Record STUDENT_DIAGNOSIS_DATA AfterExecuteInsert @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_DIAGNOSIS_DATA AfterExecuteInsert

'Record STUDENT_DIAGNOSIS_DATA Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STUDENT_DIAGNOSIS_DATA Data Provider Class PrepareUpdate Method

'Record STUDENT_DIAGNOSIS_DATA Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record STUDENT_DIAGNOSIS_DATA Data Provider Class PrepareUpdate Method tail

'Record STUDENT_DIAGNOSIS_DATA Data Provider Class Update Method @2-B407807B

    Public Function UpdateItem(ByVal item As STUDENT_DIAGNOSIS_DATAItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT_DIAGNOSIS_CONFIRMED SET {Values}", New String(){"STUDENT_ID236","And","ENROLMENT_YEAR237"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_DIAGNOSIS_DATA Data Provider Class Update Method

'Record STUDENT_DIAGNOSIS_DATA BeforeBuildUpdate @2-60C6DE93
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID236",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ENROLMENT_YEAR237",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        If Not item.WELLBEING_COMMENTS.IsEmpty Then
        allEmptyFlag = item.WELLBEING_COMMENTS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "WELLBEING_COMMENTS=" + Update.Dao.ToSql(item.WELLBEING_COMMENTS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_last_altered_date.IsEmpty Then
        allEmptyFlag = item.Hidden_last_altered_date.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.Hidden_last_altered_date.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.STUDENT_INCLUSION_OTHER.IsEmpty Then
        allEmptyFlag = item.STUDENT_INCLUSION_OTHER.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STUDENT_INCLUSION_OTHER=" + Update.Dao.ToSql(item.STUDENT_INCLUSION_OTHER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RadioButton_ReferredBy.IsEmpty Then
        allEmptyFlag = item.RadioButton_ReferredBy.IsEmpty And allEmptyFlag
        valuesList = valuesList & "REFERRED_BY=" + Update.Dao.ToSql(item.RadioButton_ReferredBy.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RadioButton_Reactivation.IsEmpty Then
        allEmptyFlag = item.RadioButton_Reactivation.IsEmpty And allEmptyFlag
        valuesList = valuesList & "REACTIVATION=" + Update.Dao.ToSql(item.RadioButton_Reactivation.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RadioButton_Previous_Enrol.IsEmpty Then
        allEmptyFlag = item.RadioButton_Previous_Enrol.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PREVIOUS_ENROLMENT=" + Update.Dao.ToSql(item.RadioButton_Previous_Enrol.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STUDENT_WELLBEING_OTHER.IsEmpty Then
        allEmptyFlag = item.STUDENT_WELLBEING_OTHER.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STUDENT_WELLBEING_OTHER=" + Update.Dao.ToSql(item.STUDENT_WELLBEING_OTHER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_WellbeingList.IsEmpty Then
        allEmptyFlag = item.Hidden_WellbeingList.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STUDENT_WELLBEING=" + Update.Dao.ToSql(item.Hidden_WellbeingList.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_InclusionList.IsEmpty Then
        allEmptyFlag = item.Hidden_InclusionList.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STUDENT_INCLUSION=" + Update.Dao.ToSql(item.Hidden_InclusionList.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.list_REGION.IsEmpty Then
        allEmptyFlag = item.list_REGION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "REGION=" + Update.Dao.ToSql(item.list_REGION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RadioButton_Support.IsEmpty Then
        allEmptyFlag = item.RadioButton_Support.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUPPORT_AT_ENROLMENT=" + Update.Dao.ToSql(item.RadioButton_Support.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_SupportList.IsEmpty Then
        allEmptyFlag = item.Hidden_SupportList.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUPPORT_AT_ENROLMENT_TYPE=" + Update.Dao.ToSql(item.Hidden_SupportList.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_enrolyear.IsEmpty Then
        allEmptyFlag = item.Hidden_enrolyear.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ENROLMENT_YEAR=" + Update.Dao.ToSql(item.Hidden_enrolyear.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.Hidden_StudentId.IsEmpty Then
        allEmptyFlag = item.Hidden_StudentId.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STUDENT_ID=" + Update.Dao.ToSql(item.Hidden_StudentId.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.Hidden_last_altered_by.IsEmpty Then
        allEmptyFlag = item.Hidden_last_altered_by.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.Hidden_last_altered_by.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RadioButton_Referral.IsEmpty Then
        allEmptyFlag = item.RadioButton_Referral.IsEmpty And allEmptyFlag
        valuesList = valuesList & "REFERRAL_AT_ENROLMENT=" + Update.Dao.ToSql(item.RadioButton_Referral.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RadioButton_Inclusion.IsEmpty Then
        allEmptyFlag = item.RadioButton_Inclusion.IsEmpty And allEmptyFlag
        valuesList = valuesList & "KNOWN_INCLUSION=" + Update.Dao.ToSql(item.RadioButton_Inclusion.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RadioButton_Wellbeing.IsEmpty Then
        allEmptyFlag = item.RadioButton_Wellbeing.IsEmpty And allEmptyFlag
        valuesList = valuesList & "KNOWN_WELLBEING=" + Update.Dao.ToSql(item.RadioButton_Wellbeing.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STUDENT_DIAGNOSIS_DATA BeforeBuildUpdate

'Record STUDENT_DIAGNOSIS_DATA AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_DIAGNOSIS_DATA AfterExecuteUpdate

'Record STUDENT_DIAGNOSIS_DATA Data Provider Class GetResultSet Method @2-CC3324C9

    Public Sub FillItem(ByVal item As STUDENT_DIAGNOSIS_DATAItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_DIAGNOSIS_DATA Data Provider Class GetResultSet Method

'Record STUDENT_DIAGNOSIS_DATA BeforeBuildSelect @2-F9832BC6
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID236",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("ENROLMENT_YEAR237",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_DIAGNOSIS_DATA BeforeBuildSelect

'Record STUDENT_DIAGNOSIS_DATA BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_DIAGNOSIS_DATA BeforeExecuteSelect

'Record STUDENT_DIAGNOSIS_DATA AfterExecuteSelect @2-C0E4F62E
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.WELLBEING_COMMENTS.SetValue(dr(i)("WELLBEING_COMMENTS"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.Hidden_last_altered_date.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.STUDENT_INCLUSION_OTHER.SetValue(dr(i)("STUDENT_INCLUSION_OTHER"),"")
            item.RadioButton_ReferredBy.SetValue(dr(i)("REFERRED_BY"),"")
            item.RadioButton_Reactivation.SetValue(dr(i)("REACTIVATION"),"")
            item.RadioButton_Previous_Enrol.SetValue(dr(i)("PREVIOUS_ENROLMENT"),"")
            item.STUDENT_WELLBEING_OTHER.SetValue(dr(i)("STUDENT_WELLBEING_OTHER"),"")
            item.Hidden_WellbeingList.SetValue(dr(i)("STUDENT_WELLBEING"),"")
            item.Hidden_InclusionList.SetValue(dr(i)("STUDENT_INCLUSION"),"")
            item.list_REGION.SetValue(dr(i)("REGION"),"")
            item.RadioButton_Support.SetValue(dr(i)("SUPPORT_AT_ENROLMENT"),"")
            item.Hidden_SupportList.SetValue(dr(i)("SUPPORT_AT_ENROLMENT_TYPE"),"")
            item.Hidden_enrolyear.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.Hidden_StudentId.SetValue(dr(i)("STUDENT_ID"),"")
            item.Hidden_last_altered_by.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.ENROLMENT_YEAR.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.RadioButton_Referral.SetValue(dr(i)("REFERRAL_AT_ENROLMENT"),"")
            item.RadioButton_Inclusion.SetValue(dr(i)("KNOWN_INCLUSION"),"")
            item.RadioButton_Wellbeing.SetValue(dr(i)("KNOWN_WELLBEING"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record STUDENT_DIAGNOSIS_DATA AfterExecuteSelect

'ListBox RadioButton_ReferredBy AfterExecuteSelect @102-B521469E
        
item.RadioButton_ReferredByItems.Add("Student Support Teacher","Learning Advisor")
item.RadioButton_ReferredByItems.Add(" Wellbeing team member","Wellbeing team member")
item.RadioButton_ReferredByItems.Add(" Year Level Coordinator","Year Level Coordinator")
item.RadioButton_ReferredByItems.Add(" Subject Teacher","Subject Teacher")
item.RadioButton_ReferredByItems.Add(" Enrolment Advisor","Enrolment Advisor")
item.RadioButton_ReferredByItems.Add(" Leading Teacher","Leading Teacher")
item.RadioButton_ReferredByItems.Add("Enrolment Alert","Enrolment Alert")
'End ListBox RadioButton_ReferredBy AfterExecuteSelect

'ListBox SUPPORT_AT_ENROLMENT_TYPE AfterExecuteSelect @104-DB31F34B
        
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("CAMHS Psychiatrist","CAMHS Psychiatrist")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("headspace Psychiatrist","headspace Psychiatrist")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("RCH Psychiatrist","RCH Psychiatrist")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("RCH Paediatrician","RCH Paediatrician")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("RCH clinician","RCH clinician")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("Community Mental Health Service","Community Mental Health Service")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("General Practitioner","General Practitioner")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("DHHS Child First","DHHS Child First")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("Community Health Service","Community Health Service")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("Alternative Education Setting","Alternative Education Setting")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("CAMHS clinician","CAMHS clinician")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("headspace clinician","headspace clinician")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("Private Psychologist","Private Psychologist")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("Speech Therapist","Speech Therapist")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("DHHS Child Protection","DHHS Child Protection")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("Community Family Support Service","Community Family Support Service")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("Private Psychiatrist","Private Psychiatrist")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("Occupational Therapist","Occupational Therapist")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("Out of Home Care","Out of Home Care")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("Psychologist/psychiatrist","<span class='deprecated'>Psychologist/psychiatrist</span>")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("GP","<span class='deprecated'>GP</span>")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("Agency","<span class='deprecated'>Agency</span>")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("DHS","<span class='deprecated'>DHS</span>")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("Speech Pathologist","<span class='deprecated'>Speech Pathologist</span>")
item.SUPPORT_AT_ENROLMENT_TYPEItems.Add("Physical Therapy","<span class='deprecated'>Physical Therapy</span>")
'End ListBox SUPPORT_AT_ENROLMENT_TYPE AfterExecuteSelect

'ListBox CheckBoxList_Wellbeing AfterExecuteSelect @99-1B329669
        
item.CheckBoxList_WellbeingItems.Add("Anxiety","Anxiety")
item.CheckBoxList_WellbeingItems.Add("Depression","Depression")
item.CheckBoxList_WellbeingItems.Add("Trauma","Trauma")
item.CheckBoxList_WellbeingItems.Add("Family Complexity","Family Complexity")
item.CheckBoxList_WellbeingItems.Add("Family breakdown","Family breakdown")
item.CheckBoxList_WellbeingItems.Add("Family illness","Family illness")
item.CheckBoxList_WellbeingItems.Add("Domestic Violence","Domestic Violence")
item.CheckBoxList_WellbeingItems.Add("Self-harming","Self-harming")
item.CheckBoxList_WellbeingItems.Add("Social Phobia","Social Phobia")
item.CheckBoxList_WellbeingItems.Add("Bullying","Bullying")
item.CheckBoxList_WellbeingItems.Add("ADHD","ADHD")
item.CheckBoxList_WellbeingItems.Add("Transgender","Transgender")
item.CheckBoxList_WellbeingItems.Add("Suicidal thoughts / attempts","Suicidal thoughts / attempts")
item.CheckBoxList_WellbeingItems.Add("School refuser","School refuser")
item.CheckBoxList_WellbeingItems.Add("Behavioural Issues (incl ODD)","Behavioural Issues (incl ODD)")
item.CheckBoxList_WellbeingItems.Add("OCD","OCD")
item.CheckBoxList_WellbeingItems.Add("Eating Disorder","Eating Disorder")
item.CheckBoxList_WellbeingItems.Add("Sleep Disorder","Sleep Disorder")
item.CheckBoxList_WellbeingItems.Add("Substance use","Substance use")
item.CheckBoxList_WellbeingItems.Add("Behavioural Issues","<span class='deprecated'>Behavioural Issues</span>")
item.CheckBoxList_WellbeingItems.Add("Cyberbullying","<span class='deprecated'>Cyberbullying</span>")
item.CheckBoxList_WellbeingItems.Add("PTSD","<span class='deprecated'>PTSD</span>")
item.CheckBoxList_WellbeingItems.Add("ODD","<span class='deprecated'>ODD</span>")
item.CheckBoxList_WellbeingItems.Add("Borderline PD","<span class='deprecated'>Borderline PD</span>")
item.CheckBoxList_WellbeingItems.Add("Conduct Disorder","<span class='deprecated'>Conduct Disorder</span>")
'End ListBox CheckBoxList_Wellbeing AfterExecuteSelect

'ListBox RadioButton_Reactivation AfterExecuteSelect @106-43F5603B
        
item.RadioButton_ReactivationItems.Add("Y","Yes")
item.RadioButton_ReactivationItems.Add("N","No")
'End ListBox RadioButton_Reactivation AfterExecuteSelect

'ListBox RadioButton_Previous_Enrol AfterExecuteSelect @108-5A2DA73B
        
item.RadioButton_Previous_EnrolItems.Add("Y","Yes")
item.RadioButton_Previous_EnrolItems.Add("N","No")
'End ListBox RadioButton_Previous_Enrol AfterExecuteSelect

'ListBox CheckBoxList_Inclusion AfterExecuteSelect @110-4066644B
        
item.CheckBoxList_InclusionItems.Add("Cognitive Impairment - ASD","Cognitive Impairment - ASD")
item.CheckBoxList_InclusionItems.Add("Physical Disability (short-term)","Physical Disability (short-term)")
item.CheckBoxList_InclusionItems.Add("Physical Impairment - CFS/ME","Physical Impairment - CFS/ME")
item.CheckBoxList_InclusionItems.Add("Cognitive Impairment - Learning difficulty","Cognitive Impairment - Learning difficulty")
item.CheckBoxList_InclusionItems.Add("Cognitive Impairment - Intellectual Disability","Cognitive Impairment - Intellectual Disability")
item.CheckBoxList_InclusionItems.Add("Auditory processing disorder","Auditory processing disorder")
item.CheckBoxList_InclusionItems.Add("Gifted and Talented","Gifted and Talented")
item.CheckBoxList_InclusionItems.Add("Physical Disability (long-term)","Physical Disability (long-term)")
item.CheckBoxList_InclusionItems.Add("Language Learning Disorder / dyslexia","Language Learning Disorder / dyslexia")
item.CheckBoxList_InclusionItems.Add("Learning Disorder - handwriting","Learning Disorder - handwriting")
item.CheckBoxList_InclusionItems.Add("Sensory Impairment - Vision","Sensory Impairment - Vision")
item.CheckBoxList_InclusionItems.Add("Sensory Impairment - Hearing","Sensory Impairment - Hearing")
item.CheckBoxList_InclusionItems.Add("Sensory difficulties","Sensory difficulties")
item.CheckBoxList_InclusionItems.Add("Physical Impairment - Physical illness (Short-term)","<span class='deprecated'>Physical Impairment - Physical illness (Short-term)</span>")
item.CheckBoxList_InclusionItems.Add("Physical Impairment - Physical illness (Long-term)","<span class='deprecated'>Physical Impairment - Physical illness (Long-term)</span>")
item.CheckBoxList_InclusionItems.Add("Cognitive Impairment - Learning Disability","<span class='deprecated'>Cognitive Impairment - Learning Disability</span>")
item.CheckBoxList_InclusionItems.Add("Cognitive Impairment - Language Disorder","<span class='deprecated'>Cognitive Impairment - Language Disorder</span>")
'End ListBox CheckBoxList_Inclusion AfterExecuteSelect

'ListBox list_REGION Initialize Data Source @74-2652DD44
        list_REGIONDataCommand.Dao._optimized = False
        Dim list_REGIONtableIndex As Integer = 0
        list_REGIONDataCommand.OrderBy = "REGION_NAME"
        list_REGIONDataCommand.Parameters.Clear()
        list_REGIONDataCommand.Parameters.Add("expr192","(STATUS =1)")
'End ListBox list_REGION Initialize Data Source

'ListBox list_REGION BeforeExecuteSelect @74-A0AFD9C2
        Try
            ListBoxSource=list_REGIONDataCommand.Execute().Tables(list_REGIONtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox list_REGION BeforeExecuteSelect

'ListBox list_REGION AfterExecuteSelect @74-5C68C591
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("REGION_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("REGION_NAME")
            item.list_REGIONItems.Add(Key, Val)
        Next
'End ListBox list_REGION AfterExecuteSelect

'ListBox RadioButton_Support AfterExecuteSelect @132-2A65543C
        
item.RadioButton_SupportItems.Add("Y","Yes")
item.RadioButton_SupportItems.Add("N","No")
'End ListBox RadioButton_Support AfterExecuteSelect

'ListBox RadioButton_Referral AfterExecuteSelect @170-6A12177D
        
item.RadioButton_ReferralItems.Add("Y","Yes")
item.RadioButton_ReferralItems.Add("N","No")
'End ListBox RadioButton_Referral AfterExecuteSelect

'ListBox RadioButton_Inclusion AfterExecuteSelect @177-EA4D3447
        
item.RadioButton_InclusionItems.Add("Y","Yes")
item.RadioButton_InclusionItems.Add("N","No")
'End ListBox RadioButton_Inclusion AfterExecuteSelect

'ListBox RadioButton_Wellbeing AfterExecuteSelect @179-1142CC7D
        
item.RadioButton_WellbeingItems.Add("Y","Yes")
item.RadioButton_WellbeingItems.Add("N","No")
'End ListBox RadioButton_Wellbeing AfterExecuteSelect

'Record STUDENT_DIAGNOSIS_DATA AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record STUDENT_DIAGNOSIS_DATA AfterExecuteSelect tail

'Record STUDENT_DIAGNOSIS_DATA Data Provider Class @2-A61BA892
End Class

'End Record STUDENT_DIAGNOSIS_DATA Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

