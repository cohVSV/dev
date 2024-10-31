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

Namespace DECV_PROD2007.Student_CensusTAFE_maintain 'Namespace @1-FDC600AB

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

'Record STUDENT_CENSUS_DATA Item Class @2-15B8E841
Public Class STUDENT_CENSUS_DATAItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public STUDENT_ID As TextField
    Public PREVIOUS_SCHOOL_ID As FloatField
    Public DISABILITY_ID As FloatField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Hidden_last_altered_by As TextField
    Public Hidden_last_altered_date As DateField
    Public SCHOOL_NAME As TextField
    Public lblPREVIOUS_SCHOOL_NAME As TextField
    Public ajaxBusy As TextField
    Public DISABILITY_OTHER_TEXT As TextField
    Public RadioButton_EnglishProficiency As TextField
    Public RadioButton_EnglishProficiencyItems As ItemCollection
    Public DATE_LAST_ATTENDED_SCHOOL As DateField
    Public HIGHEST_SCHOOL_LEVEL As TextField
    Public HIGHEST_SCHOOL_LEVELItems As ItemCollection
    Public CheckBoxList_Disability As TextField
    Public CheckBoxList_DisabilityItems As ItemCollection
    Public RadioButton_Employment_Status As TextField
    Public RadioButton_Employment_StatusItems As ItemCollection
    Public RadioButton_Reason_for_Study As TextField
    Public RadioButton_Reason_for_StudyItems As ItemCollection
    Public CheckBoxList_PriorQualifications As TextField
    Public CheckBoxList_PriorQualificationsItems As ItemCollection
    Public PRIORQUALIFICATIONS_OTHER_TEXT As TextField
    Public lblCheckDisability As TextField
    Public Hidden_DisabilityList As TextField
    Public Hidden_PriorQualificationsList As TextField
    Public Link_gotoCensusPage As TextField
    Public Link_gotoCensusPageHref As Object
    Public Link_gotoCensusPageHrefParameters As LinkParameterCollection
    Public Sub New()
    STUDENT_ID = New TextField("", Nothing)
    PREVIOUS_SCHOOL_ID = New FloatField("", Nothing)
    DISABILITY_ID = New FloatField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    Hidden_last_altered_by = New TextField("", DBUtility.UserLogin.ToUpper)
    Hidden_last_altered_date = New DateField("yyyy-MM-dd H\:mm", DateTime.Now)
    SCHOOL_NAME = New TextField("", Nothing)
    lblPREVIOUS_SCHOOL_NAME = New TextField("", "unknown school name")
    ajaxBusy = New TextField("", Nothing)
    DISABILITY_OTHER_TEXT = New TextField("", Nothing)
    RadioButton_EnglishProficiency = New TextField("", Nothing)
    RadioButton_EnglishProficiencyItems = New ItemCollection()
    DATE_LAST_ATTENDED_SCHOOL = New DateField("dd\/MM\/yyyy", Nothing)
    HIGHEST_SCHOOL_LEVEL = New TextField("", "0")
    HIGHEST_SCHOOL_LEVELItems = New ItemCollection()
    CheckBoxList_Disability = New TextField("", Nothing)
    CheckBoxList_DisabilityItems = New ItemCollection()
    RadioButton_Employment_Status = New TextField("", Nothing)
    RadioButton_Employment_StatusItems = New ItemCollection()
    RadioButton_Reason_for_Study = New TextField("", Nothing)
    RadioButton_Reason_for_StudyItems = New ItemCollection()
    CheckBoxList_PriorQualifications = New TextField("", Nothing)
    CheckBoxList_PriorQualificationsItems = New ItemCollection()
    PRIORQUALIFICATIONS_OTHER_TEXT = New TextField("", Nothing)
    lblCheckDisability = New TextField("", Nothing)
    Hidden_DisabilityList = New TextField("", "0,")
    Hidden_PriorQualificationsList = New TextField("", "0,")
    Link_gotoCensusPage = New TextField("",Nothing)
    Link_gotoCensusPageHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_CENSUS_DATAItem
        Dim item As STUDENT_CENSUS_DATAItem = New STUDENT_CENSUS_DATAItem()
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PREVIOUS_SCHOOL_ID")) Then
        item.PREVIOUS_SCHOOL_ID.SetValue(DBUtility.GetInitialValue("PREVIOUS_SCHOOL_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DISABILITY_ID")) Then
        item.DISABILITY_ID.SetValue(DBUtility.GetInitialValue("DISABILITY_ID"))
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
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_last_altered_by")) Then
        item.Hidden_last_altered_by.SetValue(DBUtility.GetInitialValue("Hidden_last_altered_by"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_last_altered_date")) Then
        item.Hidden_last_altered_date.SetValue(DBUtility.GetInitialValue("Hidden_last_altered_date"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SCHOOL_NAME")) Then
        item.SCHOOL_NAME.SetValue(DBUtility.GetInitialValue("SCHOOL_NAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblPREVIOUS_SCHOOL_NAME")) Then
        item.lblPREVIOUS_SCHOOL_NAME.SetValue(DBUtility.GetInitialValue("lblPREVIOUS_SCHOOL_NAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ajaxBusy")) Then
        item.ajaxBusy.SetValue(DBUtility.GetInitialValue("ajaxBusy"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DISABILITY_OTHER_TEXT")) Then
        item.DISABILITY_OTHER_TEXT.SetValue(DBUtility.GetInitialValue("DISABILITY_OTHER_TEXT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RadioButton_EnglishProficiency")) Then
        item.RadioButton_EnglishProficiency.SetValue(DBUtility.GetInitialValue("RadioButton_EnglishProficiency"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DATE_LAST_ATTENDED_SCHOOL")) Then
        item.DATE_LAST_ATTENDED_SCHOOL.SetValue(DBUtility.GetInitialValue("DATE_LAST_ATTENDED_SCHOOL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("HIGHEST_SCHOOL_LEVEL")) Then
        item.HIGHEST_SCHOOL_LEVEL.SetValue(DBUtility.GetInitialValue("HIGHEST_SCHOOL_LEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CheckBoxList_Disability")) Then
        item.CheckBoxList_Disability.SetValue(DBUtility.GetInitialValue("CheckBoxList_Disability"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RadioButton_Employment_Status")) Then
        item.RadioButton_Employment_Status.SetValue(DBUtility.GetInitialValue("RadioButton_Employment_Status"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RadioButton_Reason_for_Study")) Then
        item.RadioButton_Reason_for_Study.SetValue(DBUtility.GetInitialValue("RadioButton_Reason_for_Study"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CheckBoxList_PriorQualifications")) Then
        item.CheckBoxList_PriorQualifications.SetValue(DBUtility.GetInitialValue("CheckBoxList_PriorQualifications"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRIORQUALIFICATIONS_OTHER_TEXT")) Then
        item.PRIORQUALIFICATIONS_OTHER_TEXT.SetValue(DBUtility.GetInitialValue("PRIORQUALIFICATIONS_OTHER_TEXT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblCheckDisability")) Then
        item.lblCheckDisability.SetValue(DBUtility.GetInitialValue("lblCheckDisability"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_DisabilityList")) Then
        item.Hidden_DisabilityList.SetValue(DBUtility.GetInitialValue("Hidden_DisabilityList"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_PriorQualificationsList")) Then
        item.Hidden_PriorQualificationsList.SetValue(DBUtility.GetInitialValue("Hidden_PriorQualificationsList"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link_gotoCensusPage")) Then
        item.Link_gotoCensusPage.SetValue(DBUtility.GetInitialValue("Link_gotoCensusPage"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "PREVIOUS_SCHOOL_ID"
                    Return PREVIOUS_SCHOOL_ID
                Case "DISABILITY_ID"
                    Return DISABILITY_ID
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "Hidden_last_altered_by"
                    Return Hidden_last_altered_by
                Case "Hidden_last_altered_date"
                    Return Hidden_last_altered_date
                Case "SCHOOL_NAME"
                    Return SCHOOL_NAME
                Case "lblPREVIOUS_SCHOOL_NAME"
                    Return lblPREVIOUS_SCHOOL_NAME
                Case "ajaxBusy"
                    Return ajaxBusy
                Case "DISABILITY_OTHER_TEXT"
                    Return DISABILITY_OTHER_TEXT
                Case "RadioButton_EnglishProficiency"
                    Return RadioButton_EnglishProficiency
                Case "DATE_LAST_ATTENDED_SCHOOL"
                    Return DATE_LAST_ATTENDED_SCHOOL
                Case "HIGHEST_SCHOOL_LEVEL"
                    Return HIGHEST_SCHOOL_LEVEL
                Case "CheckBoxList_Disability"
                    Return CheckBoxList_Disability
                Case "RadioButton_Employment_Status"
                    Return RadioButton_Employment_Status
                Case "RadioButton_Reason_for_Study"
                    Return RadioButton_Reason_for_Study
                Case "CheckBoxList_PriorQualifications"
                    Return CheckBoxList_PriorQualifications
                Case "PRIORQUALIFICATIONS_OTHER_TEXT"
                    Return PRIORQUALIFICATIONS_OTHER_TEXT
                Case "lblCheckDisability"
                    Return lblCheckDisability
                Case "Hidden_DisabilityList"
                    Return Hidden_DisabilityList
                Case "Hidden_PriorQualificationsList"
                    Return Hidden_PriorQualificationsList
                Case "Link_gotoCensusPage"
                    Return Link_gotoCensusPage
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, TextField)
                Case "PREVIOUS_SCHOOL_ID"
                    PREVIOUS_SCHOOL_ID = CType(value, FloatField)
                Case "DISABILITY_ID"
                    DISABILITY_ID = CType(value, FloatField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "Hidden_last_altered_by"
                    Hidden_last_altered_by = CType(value, TextField)
                Case "Hidden_last_altered_date"
                    Hidden_last_altered_date = CType(value, DateField)
                Case "SCHOOL_NAME"
                    SCHOOL_NAME = CType(value, TextField)
                Case "lblPREVIOUS_SCHOOL_NAME"
                    lblPREVIOUS_SCHOOL_NAME = CType(value, TextField)
                Case "ajaxBusy"
                    ajaxBusy = CType(value, TextField)
                Case "DISABILITY_OTHER_TEXT"
                    DISABILITY_OTHER_TEXT = CType(value, TextField)
                Case "RadioButton_EnglishProficiency"
                    RadioButton_EnglishProficiency = CType(value, TextField)
                Case "DATE_LAST_ATTENDED_SCHOOL"
                    DATE_LAST_ATTENDED_SCHOOL = CType(value, DateField)
                Case "HIGHEST_SCHOOL_LEVEL"
                    HIGHEST_SCHOOL_LEVEL = CType(value, TextField)
                Case "CheckBoxList_Disability"
                    CheckBoxList_Disability = CType(value, TextField)
                Case "RadioButton_Employment_Status"
                    RadioButton_Employment_Status = CType(value, TextField)
                Case "RadioButton_Reason_for_Study"
                    RadioButton_Reason_for_Study = CType(value, TextField)
                Case "CheckBoxList_PriorQualifications"
                    CheckBoxList_PriorQualifications = CType(value, TextField)
                Case "PRIORQUALIFICATIONS_OTHER_TEXT"
                    PRIORQUALIFICATIONS_OTHER_TEXT = CType(value, TextField)
                Case "lblCheckDisability"
                    lblCheckDisability = CType(value, TextField)
                Case "Hidden_DisabilityList"
                    Hidden_DisabilityList = CType(value, TextField)
                Case "Hidden_PriorQualificationsList"
                    Hidden_PriorQualificationsList = CType(value, TextField)
                Case "Link_gotoCensusPage"
                    Link_gotoCensusPage = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STUDENT_CENSUS_DATADataProvider)
'End Record STUDENT_CENSUS_DATA Item Class

'TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action Declare Variable @89-1C13A7EA
        Dim tmpSchoolCount As Int64 = -1
'End TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action Declare Variable

'TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action Declare Variable @93-57E881B3
        Dim tmpPrevSchoolID As String = ""
'End TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action Declare Variable

'TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action Custom Code @92-73254650
    ' -------------------------
    ' load up the previous school id
    If IsNothing(PREVIOUS_SCHOOL_ID.Value) OrElse PREVIOUS_SCHOOL_ID.Value.ToString() ="" Then
	    tmpPrevSchoolID = ""
	else
		tmpPrevSchoolID = PREVIOUS_SCHOOL_ID.Value.ToString()	' code generation doesn't like it for some reason, so done here manually.
	end if
	
	If (tmpPrevSchoolID <> "") Then
    ' -------------------------
'End TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action Custom Code

'TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action DLookup @88-A20D694F
        tmpSchoolCount = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "count(school_id)" & " FROM " & "SCHOOL" & " WHERE " & "SCHOOL_ID = " & tmpPrevSchoolID))).Value, Int64)
'End TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action DLookup

'TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action Custom Code @91-73254650
    ' -------------------------
    ' ERA: if the previous school id is entered then if there are no schools matching then raise an error
		If (tmpPrevSchoolID.ToString() <> "") and (tmpSchoolCount = 0) Then
            errors.Add("PREVIOUS_SCHOOL_ID", "There is no School for that PREVIOUS SCHOOL ID. Please check it, or leave it blank")
	   	End If

	End If	' DB lookup
    ' -------------------------
'End TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action Custom Code

'RadioButton_EnglishProficiency validate @102-C317BBC5
        If IsNothing(RadioButton_EnglishProficiency.Value) OrElse RadioButton_EnglishProficiency.Value.ToString() ="" Then
            errors.Add("RadioButton_EnglishProficiency",String.Format(Resources.strings.CCS_RequiredField,"ENGLISH PROFICIENCY"))
        End If
'End RadioButton_EnglishProficiency validate

'RadioButton_Reason_for_Study validate @108-FA60497A
        If IsNothing(RadioButton_Reason_for_Study.Value) OrElse RadioButton_Reason_for_Study.Value.ToString() ="" Then
            errors.Add("RadioButton_Reason_for_Study",String.Format(Resources.strings.CCS_RequiredField,"Reason for Study"))
        End If
'End RadioButton_Reason_for_Study validate

'Record STUDENT_CENSUS_DATA Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_CENSUS_DATA Item Class tail

'Record STUDENT_CENSUS_DATA Data Provider Class @2-ABF1C50C
Public Class STUDENT_CENSUS_DATADataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_CENSUS_DATA Data Provider Class

'Record STUDENT_CENSUS_DATA Data Provider Class Variables @2-67ADC9AD
    Public UrlSTUDENT_ID As FloatParameter
    Protected item As STUDENT_CENSUS_DATAItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_CENSUS_DATA Data Provider Class Variables

'Record STUDENT_CENSUS_DATA Data Provider Class Constructor @2-D2E2E80B

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_CENSUS_DATA {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID5"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_CENSUS_DATA Data Provider Class Constructor

'Record STUDENT_CENSUS_DATA Data Provider Class LoadParams Method @2-A977A0E9

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID))
    End Function
'End Record STUDENT_CENSUS_DATA Data Provider Class LoadParams Method

'Record STUDENT_CENSUS_DATA Data Provider Class CheckUnique Method @2-DD15ACA2

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_CENSUS_DATAItem) As Boolean
        Return True
    End Function
'End Record STUDENT_CENSUS_DATA Data Provider Class CheckUnique Method

'Record STUDENT_CENSUS_DATA Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STUDENT_CENSUS_DATA Data Provider Class PrepareUpdate Method

'Record STUDENT_CENSUS_DATA Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record STUDENT_CENSUS_DATA Data Provider Class PrepareUpdate Method tail

'Record STUDENT_CENSUS_DATA Data Provider Class Update Method @2-236DEF68

    Public Function UpdateItem(ByVal item As STUDENT_CENSUS_DATAItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT_CENSUS_DATA SET {Values}", New String(){"STUDENT_ID5"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_CENSUS_DATA Data Provider Class Update Method

'Record STUDENT_CENSUS_DATA BeforeBuildUpdate @2-A0D396B6
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID5",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        If Not item.PREVIOUS_SCHOOL_ID.IsEmpty Then
        allEmptyFlag = item.PREVIOUS_SCHOOL_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PREVIOUS_SCHOOL_ID=" + Update.Dao.ToSql(item.PREVIOUS_SCHOOL_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.DISABILITY_ID.IsEmpty Then
        allEmptyFlag = item.DISABILITY_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DISABILITY_ID=" + Update.Dao.ToSql(item.DISABILITY_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.Hidden_last_altered_by.IsEmpty Then
        allEmptyFlag = item.Hidden_last_altered_by.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.Hidden_last_altered_by.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_last_altered_date.IsEmpty Then
        allEmptyFlag = item.Hidden_last_altered_date.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.Hidden_last_altered_date.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.DISABILITY_OTHER_TEXT.IsEmpty Then
        allEmptyFlag = item.DISABILITY_OTHER_TEXT.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DISABILITY_OTHER_TEXT=" + Update.Dao.ToSql(item.DISABILITY_OTHER_TEXT.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RadioButton_EnglishProficiency.IsEmpty Then
        allEmptyFlag = item.RadioButton_EnglishProficiency.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ENGLISH_PROFICIENCY=" + Update.Dao.ToSql(item.RadioButton_EnglishProficiency.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DATE_LAST_ATTENDED_SCHOOL.IsEmpty Then
        allEmptyFlag = item.DATE_LAST_ATTENDED_SCHOOL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DATE_LAST_ATTENDED_SCHOOL=" + Update.Dao.ToSql(item.DATE_LAST_ATTENDED_SCHOOL.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.HIGHEST_SCHOOL_LEVEL.IsEmpty Then
        allEmptyFlag = item.HIGHEST_SCHOOL_LEVEL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "HIGHEST_SCHOOL_LEVEL=" + Update.Dao.ToSql(item.HIGHEST_SCHOOL_LEVEL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RadioButton_Employment_Status.IsEmpty Then
        allEmptyFlag = item.RadioButton_Employment_Status.IsEmpty And allEmptyFlag
        valuesList = valuesList & "EMPLOYMENT_STATUS=" + Update.Dao.ToSql(item.RadioButton_Employment_Status.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RadioButton_Reason_for_Study.IsEmpty Then
        allEmptyFlag = item.RadioButton_Reason_for_Study.IsEmpty And allEmptyFlag
        valuesList = valuesList & "REASON_FOR_STUDY=" + Update.Dao.ToSql(item.RadioButton_Reason_for_Study.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PRIORQUALIFICATIONS_OTHER_TEXT.IsEmpty Then
        allEmptyFlag = item.PRIORQUALIFICATIONS_OTHER_TEXT.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRIORQUALIFICATIONS_OTHER_TEXT=" + Update.Dao.ToSql(item.PRIORQUALIFICATIONS_OTHER_TEXT.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_DisabilityList.IsEmpty Then
        allEmptyFlag = item.Hidden_DisabilityList.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DISABILITY_CODES=" + Update.Dao.ToSql(item.Hidden_DisabilityList.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_PriorQualificationsList.IsEmpty Then
        allEmptyFlag = item.Hidden_PriorQualificationsList.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRIOR_QUALIFICATIONS=" + Update.Dao.ToSql(item.Hidden_PriorQualificationsList.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STUDENT_CENSUS_DATA BeforeBuildUpdate

'Record STUDENT_CENSUS_DATA AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_CENSUS_DATA AfterExecuteUpdate

'Record STUDENT_CENSUS_DATA Data Provider Class GetResultSet Method @2-C1EB0750

    Public Sub FillItem(ByVal item As STUDENT_CENSUS_DATAItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_CENSUS_DATA Data Provider Class GetResultSet Method

'Record STUDENT_CENSUS_DATA BeforeBuildSelect @2-21BE94D9
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID5",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_CENSUS_DATA BeforeBuildSelect

'Record STUDENT_CENSUS_DATA BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_CENSUS_DATA BeforeExecuteSelect

'Record STUDENT_CENSUS_DATA AfterExecuteSelect @2-381C8285
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.PREVIOUS_SCHOOL_ID.SetValue(dr(i)("PREVIOUS_SCHOOL_ID"),"")
            item.DISABILITY_ID.SetValue(dr(i)("DISABILITY_ID"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.Hidden_last_altered_by.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.Hidden_last_altered_date.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.DISABILITY_OTHER_TEXT.SetValue(dr(i)("DISABILITY_OTHER_TEXT"),"")
            item.RadioButton_EnglishProficiency.SetValue(dr(i)("ENGLISH_PROFICIENCY"),"")
            item.DATE_LAST_ATTENDED_SCHOOL.SetValue(dr(i)("DATE_LAST_ATTENDED_SCHOOL"),Select_.DateFormat)
            item.HIGHEST_SCHOOL_LEVEL.SetValue(dr(i)("HIGHEST_SCHOOL_LEVEL"),"")
            item.RadioButton_Employment_Status.SetValue(dr(i)("EMPLOYMENT_STATUS"),"")
            item.RadioButton_Reason_for_Study.SetValue(dr(i)("REASON_FOR_STUDY"),"")
            item.PRIORQUALIFICATIONS_OTHER_TEXT.SetValue(dr(i)("PRIORQUALIFICATIONS_OTHER_TEXT"),"")
            item.Hidden_DisabilityList.SetValue(dr(i)("DISABILITY_CODES"),"")
            item.Hidden_PriorQualificationsList.SetValue(dr(i)("PRIOR_QUALIFICATIONS"),"")
            item.Link_gotoCensusPageHref = "Student_Census_maintain.aspx"
        Else
            IsInsertMode = True
        End If
'End Record STUDENT_CENSUS_DATA AfterExecuteSelect

'ListBox RadioButton_EnglishProficiency AfterExecuteSelect @102-8DCE4D6B
        
item.RadioButton_EnglishProficiencyItems.Add("3","Very Well")
item.RadioButton_EnglishProficiencyItems.Add("2","Well")
item.RadioButton_EnglishProficiencyItems.Add("1","Not Well")
item.RadioButton_EnglishProficiencyItems.Add("0","Not at all")
'End ListBox RadioButton_EnglishProficiency AfterExecuteSelect

'ListBox HIGHEST_SCHOOL_LEVEL AfterExecuteSelect @104-B20F73B8
        
item.HIGHEST_SCHOOL_LEVELItems.Add("5","Year 12 or equivalent")
item.HIGHEST_SCHOOL_LEVELItems.Add("4","Year 11 or equivalent")
item.HIGHEST_SCHOOL_LEVELItems.Add("3","Year 10 or equivalent")
item.HIGHEST_SCHOOL_LEVELItems.Add("2","Year 9 or equivalent")
item.HIGHEST_SCHOOL_LEVELItems.Add("1","Year 8 or below")
item.HIGHEST_SCHOOL_LEVELItems.Add("0","Did not attend School")
'End ListBox HIGHEST_SCHOOL_LEVEL AfterExecuteSelect

'ListBox CheckBoxList_Disability AfterExecuteSelect @99-17DD6228
        
item.CheckBoxList_DisabilityItems.Add("11","Hearing/Deaf")
item.CheckBoxList_DisabilityItems.Add("12","Physical")
item.CheckBoxList_DisabilityItems.Add("13","Intellectual")
item.CheckBoxList_DisabilityItems.Add("14","Learning")
item.CheckBoxList_DisabilityItems.Add("15","Mental Illness")
item.CheckBoxList_DisabilityItems.Add("16","Acquired Brain Impairment")
item.CheckBoxList_DisabilityItems.Add("17","Vision")
item.CheckBoxList_DisabilityItems.Add("18","Medical Condition")
item.CheckBoxList_DisabilityItems.Add("19","Other (fill out below)")
item.CheckBoxList_DisabilityItems.Add("99","Not Specified")
'End ListBox CheckBoxList_Disability AfterExecuteSelect

'ListBox RadioButton_Employment_Status AfterExecuteSelect @106-D2C17E04
        
item.RadioButton_Employment_StatusItems.Add("1","Full time")
item.RadioButton_Employment_StatusItems.Add("2","Part time")
item.RadioButton_Employment_StatusItems.Add("3","Self employed")
item.RadioButton_Employment_StatusItems.Add("4","Employer")
item.RadioButton_Employment_StatusItems.Add("5","Employed")
item.RadioButton_Employment_StatusItems.Add("6","Unemployed - seeking full time")
item.RadioButton_Employment_StatusItems.Add("7","Unemployed - seeking part time")
item.RadioButton_Employment_StatusItems.Add("8","Not Employed - not seeking")
'End ListBox RadioButton_Employment_Status AfterExecuteSelect

'ListBox RadioButton_Reason_for_Study AfterExecuteSelect @108-E57DD2FC
        
item.RadioButton_Reason_for_StudyItems.Add("01","To get a job")
item.RadioButton_Reason_for_StudyItems.Add("02","To develop my existing business")
item.RadioButton_Reason_for_StudyItems.Add("03","To start my own business")
item.RadioButton_Reason_for_StudyItems.Add("04","To try for a different career")
item.RadioButton_Reason_for_StudyItems.Add("05","To get a better job or promotion")
item.RadioButton_Reason_for_StudyItems.Add("06","It was a requirement of my job")
item.RadioButton_Reason_for_StudyItems.Add("07","I wanted extra skills for my job")
item.RadioButton_Reason_for_StudyItems.Add("08","To get into another course of study")
item.RadioButton_Reason_for_StudyItems.Add("11","Other reasons")
item.RadioButton_Reason_for_StudyItems.Add("12","For personal interest or self-development")
item.RadioButton_Reason_for_StudyItems.Add("99","Not specified")
'End ListBox RadioButton_Reason_for_Study AfterExecuteSelect

'ListBox CheckBoxList_PriorQualifications AfterExecuteSelect @110-1ABF60EC
        
item.CheckBoxList_PriorQualificationsItems.Add("008","(008) Bachelor Degree or Higher Degree level")
item.CheckBoxList_PriorQualificationsItems.Add("410","(410) Advanced Diploma or Associate Degree level")
item.CheckBoxList_PriorQualificationsItems.Add("420","(420) Diploma Level")
item.CheckBoxList_PriorQualificationsItems.Add("511","(511) Certificate IV")
item.CheckBoxList_PriorQualificationsItems.Add("514","(514) Certificate III")
item.CheckBoxList_PriorQualificationsItems.Add("521","(521) Certificate II")
item.CheckBoxList_PriorQualificationsItems.Add("524","(524) Certificate I")
item.CheckBoxList_PriorQualificationsItems.Add("990","(990) Miscellaneous (fill out below)")
'End ListBox CheckBoxList_PriorQualifications AfterExecuteSelect

'Record STUDENT_CENSUS_DATA AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record STUDENT_CENSUS_DATA AfterExecuteSelect tail

'Record STUDENT_CENSUS_DATA Data Provider Class @2-A61BA892
End Class

'End Record STUDENT_CENSUS_DATA Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

