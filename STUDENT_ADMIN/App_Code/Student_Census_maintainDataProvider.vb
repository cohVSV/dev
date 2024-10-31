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

Namespace DECV_PROD2007.Student_Census_maintain 'Namespace @1-9C5EB2CF

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

'Record STUDENT_CENSUS_DATA Item Class @2-A8A9CD3B
Public Class STUDENT_CENSUS_DATAItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public STUDENT_ID As TextField
    Public COUNTRY_OF_BIRTH As IntegerField
    Public COUNTRY_OF_BIRTHItems As ItemCollection
    Public MOTHERS_COB As IntegerField
    Public MOTHERS_COBItems As ItemCollection
    Public DATE_STARTED_IN_AUST As DateField
    Public FIRST_HOME_LANGUAGE As IntegerField
    Public FIRST_HOME_LANGUAGEItems As ItemCollection
    Public OTHER_HOME_LANGUAGE As IntegerField
    Public OTHER_HOME_LANGUAGEItems As ItemCollection
    Public MOTHER_LANGUAGE As IntegerField
    Public MOTHER_LANGUAGEItems As ItemCollection
    Public MOTHER_EDUCATION_SCHOOL As TextField
    Public MOTHER_EDUCATION_SCHOOLItems As ItemCollection
    Public MOTHER_EDUCATION_NONSCHOOL As TextField
    Public MOTHER_EDUCATION_NONSCHOOLItems As ItemCollection
    Public MOTHER_OCCUPATIONGROUP As TextField
    Public MOTHER_OCCUPATIONGROUPItems As ItemCollection
    Public ALLOWANCE_CODE As IntegerField
    Public ALLOWANCE_CODEItems As ItemCollection
    Public KOORITORRESFLAG As TextField
    Public KOORITORRESFLAGItems As ItemCollection
    Public RESIDENTIAL_STATUS As TextField
    Public RESIDENTIAL_STATUSItems As ItemCollection
    Public DATE_ARRIVED_IN_AUST As DateField
    Public VISA_SUB_CLASS As FloatField
    Public VISA_STATISTICAL_CODE As TextField
    Public PREVIOUS_SCHOOL_ID As FloatField
    Public FAMILY_OSG As FloatField
    Public FAMILY_OSGItems As ItemCollection
    Public HOUSEHOLD_STATUS As FloatField
    Public HOUSEHOLD_STATUSItems As ItemCollection
    Public DISABILITY_ID As FloatField
    Public REPEATING_YEAR As BooleanField
    Public REPEATING_YEARItems As ItemCollection
    Public OTHER_SCHOOL_TF As FloatField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Hidden_last_altered_by As TextField
    Public Hidden_last_altered_date As DateField
    Public FATHER_LANGUAGE As IntegerField
    Public FATHER_LANGUAGEItems As ItemCollection
    Public FATHERS_COB As IntegerField
    Public FATHERS_COBItems As ItemCollection
    Public FATHER_EDUCATION_SCHOOL As TextField
    Public FATHER_EDUCATION_SCHOOLItems As ItemCollection
    Public FATHER_EDUCATION_NONSCHOOL As TextField
    Public FATHER_EDUCATION_NONSCHOOLItems As ItemCollection
    Public FATHER_OCCUPATIONGROUP As TextField
    Public FATHER_OCCUPATIONGROUPItems As ItemCollection
    Public SCHOOL_NAME As TextField
    Public lblPREVIOUS_SCHOOL_NAME As TextField
    Public ajaxBusy As TextField
    Public DATE_LAST_ATTENDED_SCHOOL As DateField
    Public Link_gotoTAFECensusPage As TextField
    Public Link_gotoTAFECensusPageHref As Object
    Public Link_gotoTAFECensusPageHrefParameters As LinkParameterCollection
    Public Hidden_household_status As TextField
    Public ResidentialStatusErrormessage As TextField
    Public Hidden_KoorieTorresFlag As TextField
    Public CRIS_ID As TextField
    Public YOUTH_JUSTICE_INVOLVEMENT As BooleanField
    Public YOUTH_JUSTICE_INVOLVEMENTItems As ItemCollection
    Public YOUTH_JUSTICE_INVOLVEMENT_DETAILS As TextField
    Public Hidden_YouthJusticeInvolvementFlag As BooleanField
    Public Sub New()
    STUDENT_ID = New TextField("", Nothing)
    COUNTRY_OF_BIRTH = New IntegerField("", Nothing)
    COUNTRY_OF_BIRTHItems = New ItemCollection()
    MOTHERS_COB = New IntegerField("", Nothing)
    MOTHERS_COBItems = New ItemCollection()
    DATE_STARTED_IN_AUST = New DateField("d\/M\/yyyy", Nothing)
    FIRST_HOME_LANGUAGE = New IntegerField("", Nothing)
    FIRST_HOME_LANGUAGEItems = New ItemCollection()
    OTHER_HOME_LANGUAGE = New IntegerField("", Nothing)
    OTHER_HOME_LANGUAGEItems = New ItemCollection()
    MOTHER_LANGUAGE = New IntegerField("", Nothing)
    MOTHER_LANGUAGEItems = New ItemCollection()
    MOTHER_EDUCATION_SCHOOL = New TextField("", "0")
    MOTHER_EDUCATION_SCHOOLItems = New ItemCollection()
    MOTHER_EDUCATION_NONSCHOOL = New TextField("", "0")
    MOTHER_EDUCATION_NONSCHOOLItems = New ItemCollection()
    MOTHER_OCCUPATIONGROUP = New TextField("", "U")
    MOTHER_OCCUPATIONGROUPItems = New ItemCollection()
    ALLOWANCE_CODE = New IntegerField("", Nothing)
    ALLOWANCE_CODEItems = New ItemCollection()
    KOORITORRESFLAG = New TextField("", "N")
    KOORITORRESFLAGItems = New ItemCollection()
    RESIDENTIAL_STATUS = New TextField("", Nothing)
    RESIDENTIAL_STATUSItems = New ItemCollection()
    DATE_ARRIVED_IN_AUST = New DateField("d\/M\/yyyy", Nothing)
    VISA_SUB_CLASS = New FloatField("", Nothing)
    VISA_STATISTICAL_CODE = New TextField("""", Nothing)
    PREVIOUS_SCHOOL_ID = New FloatField("", Nothing)
    FAMILY_OSG = New FloatField("", Nothing)
    FAMILY_OSGItems = New ItemCollection()
    HOUSEHOLD_STATUS = New FloatField("", Nothing)
    HOUSEHOLD_STATUSItems = New ItemCollection()
    DISABILITY_ID = New FloatField("", Nothing)
    REPEATING_YEAR = New BooleanField(Settings.BoolFormat, "No")
    REPEATING_YEARItems = New ItemCollection()
    OTHER_SCHOOL_TF = New FloatField("", "0.0")
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    Hidden_last_altered_by = New TextField("", DBUtility.UserLogin.ToUpper)
    Hidden_last_altered_date = New DateField("yyyy-MM-dd H\:mm", DateTime.Now)
    FATHER_LANGUAGE = New IntegerField("", Nothing)
    FATHER_LANGUAGEItems = New ItemCollection()
    FATHERS_COB = New IntegerField("", Nothing)
    FATHERS_COBItems = New ItemCollection()
    FATHER_EDUCATION_SCHOOL = New TextField("", "0")
    FATHER_EDUCATION_SCHOOLItems = New ItemCollection()
    FATHER_EDUCATION_NONSCHOOL = New TextField("", Nothing)
    FATHER_EDUCATION_NONSCHOOLItems = New ItemCollection()
    FATHER_OCCUPATIONGROUP = New TextField("", "U")
    FATHER_OCCUPATIONGROUPItems = New ItemCollection()
    SCHOOL_NAME = New TextField("", Nothing)
    lblPREVIOUS_SCHOOL_NAME = New TextField("", "unknown school name")
    ajaxBusy = New TextField("", Nothing)
    DATE_LAST_ATTENDED_SCHOOL = New DateField("d\/M\/yyyy", Nothing)
    Link_gotoTAFECensusPage = New TextField("",Nothing)
    Link_gotoTAFECensusPageHrefParameters = New LinkParameterCollection()
    Hidden_household_status = New TextField("", Nothing)
    ResidentialStatusErrormessage = New TextField("", Nothing)
    Hidden_KoorieTorresFlag = New TextField("", "N")
    CRIS_ID = New TextField("", Nothing)
    YOUTH_JUSTICE_INVOLVEMENT = New BooleanField(Settings.BoolFormat, Nothing)
    YOUTH_JUSTICE_INVOLVEMENTItems = New ItemCollection()
    YOUTH_JUSTICE_INVOLVEMENT_DETAILS = New TextField("", Nothing)
    Hidden_YouthJusticeInvolvementFlag = New BooleanField(Settings.BoolFormat, "N")
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_CENSUS_DATAItem
        Dim item As STUDENT_CENSUS_DATAItem = New STUDENT_CENSUS_DATAItem()
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COUNTRY_OF_BIRTH")) Then
        item.COUNTRY_OF_BIRTH.SetValue(DBUtility.GetInitialValue("COUNTRY_OF_BIRTH"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MOTHERS_COB")) Then
        item.MOTHERS_COB.SetValue(DBUtility.GetInitialValue("MOTHERS_COB"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DATE_STARTED_IN_AUST")) Then
        item.DATE_STARTED_IN_AUST.SetValue(DBUtility.GetInitialValue("DATE_STARTED_IN_AUST"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DatePicker_DATE_STARTED_IN_AUST")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FIRST_HOME_LANGUAGE")) Then
        item.FIRST_HOME_LANGUAGE.SetValue(DBUtility.GetInitialValue("FIRST_HOME_LANGUAGE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("OTHER_HOME_LANGUAGE")) Then
        item.OTHER_HOME_LANGUAGE.SetValue(DBUtility.GetInitialValue("OTHER_HOME_LANGUAGE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MOTHER_LANGUAGE")) Then
        item.MOTHER_LANGUAGE.SetValue(DBUtility.GetInitialValue("MOTHER_LANGUAGE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MOTHER_EDUCATION_SCHOOL")) Then
        item.MOTHER_EDUCATION_SCHOOL.SetValue(DBUtility.GetInitialValue("MOTHER_EDUCATION_SCHOOL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MOTHER_EDUCATION_NONSCHOOL")) Then
        item.MOTHER_EDUCATION_NONSCHOOL.SetValue(DBUtility.GetInitialValue("MOTHER_EDUCATION_NONSCHOOL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MOTHER_OCCUPATIONGROUP")) Then
        item.MOTHER_OCCUPATIONGROUP.SetValue(DBUtility.GetInitialValue("MOTHER_OCCUPATIONGROUP"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ALLOWANCE_CODE")) Then
        item.ALLOWANCE_CODE.SetValue(DBUtility.GetInitialValue("ALLOWANCE_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("KOORITORRESFLAG")) Then
        item.KOORITORRESFLAG.SetValue(DBUtility.GetInitialValue("KOORITORRESFLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RESIDENTIAL_STATUS")) Then
        item.RESIDENTIAL_STATUS.SetValue(DBUtility.GetInitialValue("RESIDENTIAL_STATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DATE_ARRIVED_IN_AUST")) Then
        item.DATE_ARRIVED_IN_AUST.SetValue(DBUtility.GetInitialValue("DATE_ARRIVED_IN_AUST"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DatePicker_DATE_ARRIVED_IN_AUST")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("VISA_SUB_CLASS")) Then
        item.VISA_SUB_CLASS.SetValue(DBUtility.GetInitialValue("VISA_SUB_CLASS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("VISA_STATISTICAL_CODE")) Then
        item.VISA_STATISTICAL_CODE.SetValue(DBUtility.GetInitialValue("VISA_STATISTICAL_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PREVIOUS_SCHOOL_ID")) Then
        item.PREVIOUS_SCHOOL_ID.SetValue(DBUtility.GetInitialValue("PREVIOUS_SCHOOL_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FAMILY_OSG")) Then
        item.FAMILY_OSG.SetValue(DBUtility.GetInitialValue("FAMILY_OSG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("HOUSEHOLD_STATUS")) Then
        item.HOUSEHOLD_STATUS.SetValue(DBUtility.GetInitialValue("HOUSEHOLD_STATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DISABILITY_ID")) Then
        item.DISABILITY_ID.SetValue(DBUtility.GetInitialValue("DISABILITY_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("REPEATING_YEAR")) Then
        item.REPEATING_YEAR.SetValue(DBUtility.GetInitialValue("REPEATING_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("OTHER_SCHOOL_TF")) Then
        item.OTHER_SCHOOL_TF.SetValue(DBUtility.GetInitialValue("OTHER_SCHOOL_TF"))
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
        If Not IsNothing(DBUtility.GetInitialValue("FATHER_LANGUAGE")) Then
        item.FATHER_LANGUAGE.SetValue(DBUtility.GetInitialValue("FATHER_LANGUAGE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FATHERS_COB")) Then
        item.FATHERS_COB.SetValue(DBUtility.GetInitialValue("FATHERS_COB"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FATHER_EDUCATION_SCHOOL")) Then
        item.FATHER_EDUCATION_SCHOOL.SetValue(DBUtility.GetInitialValue("FATHER_EDUCATION_SCHOOL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FATHER_EDUCATION_NONSCHOOL")) Then
        item.FATHER_EDUCATION_NONSCHOOL.SetValue(DBUtility.GetInitialValue("FATHER_EDUCATION_NONSCHOOL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FATHER_OCCUPATIONGROUP")) Then
        item.FATHER_OCCUPATIONGROUP.SetValue(DBUtility.GetInitialValue("FATHER_OCCUPATIONGROUP"))
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
        If Not IsNothing(DBUtility.GetInitialValue("DATE_LAST_ATTENDED_SCHOOL")) Then
        item.DATE_LAST_ATTENDED_SCHOOL.SetValue(DBUtility.GetInitialValue("DATE_LAST_ATTENDED_SCHOOL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link_gotoTAFECensusPage")) Then
        item.Link_gotoTAFECensusPage.SetValue(DBUtility.GetInitialValue("Link_gotoTAFECensusPage"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_household_status")) Then
        item.Hidden_household_status.SetValue(DBUtility.GetInitialValue("Hidden_household_status"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ResidentialStatusErrormessage")) Then
        item.ResidentialStatusErrormessage.SetValue(DBUtility.GetInitialValue("ResidentialStatusErrormessage"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_KoorieTorresFlag")) Then
        item.Hidden_KoorieTorresFlag.SetValue(DBUtility.GetInitialValue("Hidden_KoorieTorresFlag"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CRIS_ID")) Then
        item.CRIS_ID.SetValue(DBUtility.GetInitialValue("CRIS_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("YOUTH_JUSTICE_INVOLVEMENT")) Then
        item.YOUTH_JUSTICE_INVOLVEMENT.SetValue(DBUtility.GetInitialValue("YOUTH_JUSTICE_INVOLVEMENT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("YOUTH_JUSTICE_INVOLVEMENT_DETAILS")) Then
        item.YOUTH_JUSTICE_INVOLVEMENT_DETAILS.SetValue(DBUtility.GetInitialValue("YOUTH_JUSTICE_INVOLVEMENT_DETAILS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_YouthJusticeInvolvementFlag")) Then
        item.Hidden_YouthJusticeInvolvementFlag.SetValue(DBUtility.GetInitialValue("Hidden_YouthJusticeInvolvementFlag"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "COUNTRY_OF_BIRTH"
                    Return COUNTRY_OF_BIRTH
                Case "MOTHERS_COB"
                    Return MOTHERS_COB
                Case "DATE_STARTED_IN_AUST"
                    Return DATE_STARTED_IN_AUST
                Case "FIRST_HOME_LANGUAGE"
                    Return FIRST_HOME_LANGUAGE
                Case "OTHER_HOME_LANGUAGE"
                    Return OTHER_HOME_LANGUAGE
                Case "MOTHER_LANGUAGE"
                    Return MOTHER_LANGUAGE
                Case "MOTHER_EDUCATION_SCHOOL"
                    Return MOTHER_EDUCATION_SCHOOL
                Case "MOTHER_EDUCATION_NONSCHOOL"
                    Return MOTHER_EDUCATION_NONSCHOOL
                Case "MOTHER_OCCUPATIONGROUP"
                    Return MOTHER_OCCUPATIONGROUP
                Case "ALLOWANCE_CODE"
                    Return ALLOWANCE_CODE
                Case "KOORITORRESFLAG"
                    Return KOORITORRESFLAG
                Case "RESIDENTIAL_STATUS"
                    Return RESIDENTIAL_STATUS
                Case "DATE_ARRIVED_IN_AUST"
                    Return DATE_ARRIVED_IN_AUST
                Case "VISA_SUB_CLASS"
                    Return VISA_SUB_CLASS
                Case "VISA_STATISTICAL_CODE"
                    Return VISA_STATISTICAL_CODE
                Case "PREVIOUS_SCHOOL_ID"
                    Return PREVIOUS_SCHOOL_ID
                Case "FAMILY_OSG"
                    Return FAMILY_OSG
                Case "HOUSEHOLD_STATUS"
                    Return HOUSEHOLD_STATUS
                Case "DISABILITY_ID"
                    Return DISABILITY_ID
                Case "REPEATING_YEAR"
                    Return REPEATING_YEAR
                Case "OTHER_SCHOOL_TF"
                    Return OTHER_SCHOOL_TF
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "Hidden_last_altered_by"
                    Return Hidden_last_altered_by
                Case "Hidden_last_altered_date"
                    Return Hidden_last_altered_date
                Case "FATHER_LANGUAGE"
                    Return FATHER_LANGUAGE
                Case "FATHERS_COB"
                    Return FATHERS_COB
                Case "FATHER_EDUCATION_SCHOOL"
                    Return FATHER_EDUCATION_SCHOOL
                Case "FATHER_EDUCATION_NONSCHOOL"
                    Return FATHER_EDUCATION_NONSCHOOL
                Case "FATHER_OCCUPATIONGROUP"
                    Return FATHER_OCCUPATIONGROUP
                Case "SCHOOL_NAME"
                    Return SCHOOL_NAME
                Case "lblPREVIOUS_SCHOOL_NAME"
                    Return lblPREVIOUS_SCHOOL_NAME
                Case "ajaxBusy"
                    Return ajaxBusy
                Case "DATE_LAST_ATTENDED_SCHOOL"
                    Return DATE_LAST_ATTENDED_SCHOOL
                Case "Link_gotoTAFECensusPage"
                    Return Link_gotoTAFECensusPage
                Case "Hidden_household_status"
                    Return Hidden_household_status
                Case "ResidentialStatusErrormessage"
                    Return ResidentialStatusErrormessage
                Case "Hidden_KoorieTorresFlag"
                    Return Hidden_KoorieTorresFlag
                Case "CRIS_ID"
                    Return CRIS_ID
                Case "YOUTH_JUSTICE_INVOLVEMENT"
                    Return YOUTH_JUSTICE_INVOLVEMENT
                Case "YOUTH_JUSTICE_INVOLVEMENT_DETAILS"
                    Return YOUTH_JUSTICE_INVOLVEMENT_DETAILS
                Case "Hidden_YouthJusticeInvolvementFlag"
                    Return Hidden_YouthJusticeInvolvementFlag
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, TextField)
                Case "COUNTRY_OF_BIRTH"
                    COUNTRY_OF_BIRTH = CType(value, IntegerField)
                Case "MOTHERS_COB"
                    MOTHERS_COB = CType(value, IntegerField)
                Case "DATE_STARTED_IN_AUST"
                    DATE_STARTED_IN_AUST = CType(value, DateField)
                Case "FIRST_HOME_LANGUAGE"
                    FIRST_HOME_LANGUAGE = CType(value, IntegerField)
                Case "OTHER_HOME_LANGUAGE"
                    OTHER_HOME_LANGUAGE = CType(value, IntegerField)
                Case "MOTHER_LANGUAGE"
                    MOTHER_LANGUAGE = CType(value, IntegerField)
                Case "MOTHER_EDUCATION_SCHOOL"
                    MOTHER_EDUCATION_SCHOOL = CType(value, TextField)
                Case "MOTHER_EDUCATION_NONSCHOOL"
                    MOTHER_EDUCATION_NONSCHOOL = CType(value, TextField)
                Case "MOTHER_OCCUPATIONGROUP"
                    MOTHER_OCCUPATIONGROUP = CType(value, TextField)
                Case "ALLOWANCE_CODE"
                    ALLOWANCE_CODE = CType(value, IntegerField)
                Case "KOORITORRESFLAG"
                    KOORITORRESFLAG = CType(value, TextField)
                Case "RESIDENTIAL_STATUS"
                    RESIDENTIAL_STATUS = CType(value, TextField)
                Case "DATE_ARRIVED_IN_AUST"
                    DATE_ARRIVED_IN_AUST = CType(value, DateField)
                Case "VISA_SUB_CLASS"
                    VISA_SUB_CLASS = CType(value, FloatField)
                Case "VISA_STATISTICAL_CODE"
                    VISA_STATISTICAL_CODE = CType(value, TextField)
                Case "PREVIOUS_SCHOOL_ID"
                    PREVIOUS_SCHOOL_ID = CType(value, FloatField)
                Case "FAMILY_OSG"
                    FAMILY_OSG = CType(value, FloatField)
                Case "HOUSEHOLD_STATUS"
                    HOUSEHOLD_STATUS = CType(value, FloatField)
                Case "DISABILITY_ID"
                    DISABILITY_ID = CType(value, FloatField)
                Case "REPEATING_YEAR"
                    REPEATING_YEAR = CType(value, BooleanField)
                Case "OTHER_SCHOOL_TF"
                    OTHER_SCHOOL_TF = CType(value, FloatField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "Hidden_last_altered_by"
                    Hidden_last_altered_by = CType(value, TextField)
                Case "Hidden_last_altered_date"
                    Hidden_last_altered_date = CType(value, DateField)
                Case "FATHER_LANGUAGE"
                    FATHER_LANGUAGE = CType(value, IntegerField)
                Case "FATHERS_COB"
                    FATHERS_COB = CType(value, IntegerField)
                Case "FATHER_EDUCATION_SCHOOL"
                    FATHER_EDUCATION_SCHOOL = CType(value, TextField)
                Case "FATHER_EDUCATION_NONSCHOOL"
                    FATHER_EDUCATION_NONSCHOOL = CType(value, TextField)
                Case "FATHER_OCCUPATIONGROUP"
                    FATHER_OCCUPATIONGROUP = CType(value, TextField)
                Case "SCHOOL_NAME"
                    SCHOOL_NAME = CType(value, TextField)
                Case "lblPREVIOUS_SCHOOL_NAME"
                    lblPREVIOUS_SCHOOL_NAME = CType(value, TextField)
                Case "ajaxBusy"
                    ajaxBusy = CType(value, TextField)
                Case "DATE_LAST_ATTENDED_SCHOOL"
                    DATE_LAST_ATTENDED_SCHOOL = CType(value, DateField)
                Case "Link_gotoTAFECensusPage"
                    Link_gotoTAFECensusPage = CType(value, TextField)
                Case "Hidden_household_status"
                    Hidden_household_status = CType(value, TextField)
                Case "ResidentialStatusErrormessage"
                    ResidentialStatusErrormessage = CType(value, TextField)
                Case "Hidden_KoorieTorresFlag"
                    Hidden_KoorieTorresFlag = CType(value, TextField)
                Case "CRIS_ID"
                    CRIS_ID = CType(value, TextField)
                Case "YOUTH_JUSTICE_INVOLVEMENT"
                    YOUTH_JUSTICE_INVOLVEMENT = CType(value, BooleanField)
                Case "YOUTH_JUSTICE_INVOLVEMENT_DETAILS"
                    YOUTH_JUSTICE_INVOLVEMENT_DETAILS = CType(value, TextField)
                Case "Hidden_YouthJusticeInvolvementFlag"
                    Hidden_YouthJusticeInvolvementFlag = CType(value, BooleanField)
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

'ALLOWANCE_CODE validate @21-4C9D9437
        If IsNothing(ALLOWANCE_CODE.Value) OrElse ALLOWANCE_CODE.Value.ToString() ="" Then
            errors.Add("ALLOWANCE_CODE",String.Format(Resources.strings.CCS_RequiredField,"ALLOWANCE CODE"))
        End If
'End ALLOWANCE_CODE validate

'KOORITORRESFLAG validate @22-01737187
        If IsNothing(KOORITORRESFLAG.Value) OrElse KOORITORRESFLAG.Value.ToString() ="" Then
            errors.Add("KOORITORRESFLAG",String.Format(Resources.strings.CCS_RequiredField,"ABORIGINAL / KOORI / TORRES"))
        End If
'End KOORITORRESFLAG validate

'RadioButton RESIDENTIAL_STATUS Event OnValidate. Action Custom Code @123-73254650
    ' -------------------------
    ' 4-Mar-2016|EA| Residential status for 'Temporary' must have the Visa Codes and Dates in Aust filled out.
    if (RESIDENTIAL_STATUS.Value = "T") then
    	
     	If (VISA_SUB_CLASS.Value Is Nothing) OrElse VISA_SUB_CLASS.Value.ToString()="" Then
            errors.Add("VISA_SUB_CLASS",String.Format("VISA SUB CLASS required for Temporary Residential Status","Student VISA SUB CLASS"))
     	End If
     	
     	If (VISA_STATISTICAL_CODE.Value Is Nothing) OrElse VISA_STATISTICAL_CODE.Value.ToString()="" Then
            errors.Add("VISA_STATISTICAL_CODE",String.Format("VISA STATISTICAL CODE required for Temporary Residential Status","Student VISA STATISTICAL CODE"))
     	End If
     	
     	If (DATE_STARTED_IN_AUST.Value Is Nothing) OrElse DATE_STARTED_IN_AUST.Value.ToString()="" Then
            errors.Add("DATE_STARTED_IN_AUST",String.Format("DATE STARTED IN AUST required for Temporary Residential Status","Student DATE STARTED IN AUST"))
     	End If
     	
     	If (DATE_ARRIVED_IN_AUST.Value Is Nothing) OrElse DATE_ARRIVED_IN_AUST.Value.ToString()="" Then
            errors.Add("DATE_ARRIVED_IN_AUST",String.Format("DATE ARRIVED IN AUST required for Temporary Residential Status","Student DATE ARRIVED IN AUST"))
     	End If     	
     	
    end if 
    ' -------------------------
'End RadioButton RESIDENTIAL_STATUS Event OnValidate. Action Custom Code

'PREVIOUS_SCHOOL_ID validate @28-91F9E2BD
        If IsNothing(PREVIOUS_SCHOOL_ID.Value) OrElse PREVIOUS_SCHOOL_ID.Value.ToString() ="" Then
            errors.Add("PREVIOUS_SCHOOL_ID",String.Format(Resources.strings.CCS_RequiredField,"PREVIOUS SCHOOL ID"))
        End If
'End PREVIOUS_SCHOOL_ID validate

'TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action Declare Variable @89-1C13A7EA
        Dim tmpSchoolCount As Int64 = -1
'End TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action Declare Variable

'TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action Declare Variable @93-57E881B3
        Dim tmpPrevSchoolID As String = ""
'End TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action Declare Variable

'TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action Custom Code @92-73254650
    ' -------------------------
	If IsNothing(PREVIOUS_SCHOOL_ID.Value) OrElse PREVIOUS_SCHOOL_ID.Value.ToString() ="" Then
	    tmpPrevSchoolID = ""
	else
		tmpPrevSchoolID = PREVIOUS_SCHOOL_ID.Value.ToString()	' code generation doesn't like it for some reason, so done here manually.
	end if
	
	If (tmpPrevSchoolID <> "") Then
    ' -------------------------
'End TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action Custom Code

'TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action DLookup @88-2F7BDE48
        tmpSchoolCount = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "count(school_id)" & " FROM " & "SCHOOL" & " WHERE " & "SCHOOL_ID <> '16261.00' AND SCHOOL_ID = " & tmpPrevSchoolID))).Value, Int64)
'End TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action DLookup

'TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action Custom Code @91-73254650
    ' -------------------------
	    ' ERA: if the previous school id is entered then if there are no schools matching then raise an error
		If (tmpPrevSchoolID.ToString() <> "") and (tmpSchoolCount = 0) Then
	            errors.Add("PREVIOUS_SCHOOL_ID", "There is no School for that PREVIOUS SCHOOL ID. Please check! (cannot be VSV)")
    	End If
		' ERA: Oct-2019 for 2020 - check if VSV
		If (tmpPrevSchoolID.ToString() = "16261.00") Then
	            errors.Add("PREVIOUS_SCHOOL_ID", "Cannot use VSV (or DECV) as Previous School (16261.00)")
    	End If


	End If	' DB lookup
    ' -------------------------
'End TextBox PREVIOUS_SCHOOL_ID Event OnValidate. Action Custom Code

'REPEATING_YEAR validate @32-681619FE
        If IsNothing(REPEATING_YEAR.Value) OrElse REPEATING_YEAR.Value.ToString() ="" Then
            errors.Add("REPEATING_YEAR",String.Format(Resources.strings.CCS_RequiredField,"REPEATING YEAR"))
        End If
'End REPEATING_YEAR validate

'OTHER_SCHOOL_TF validate @33-CBC1E92D
        If IsNothing(OTHER_SCHOOL_TF.Value) OrElse OTHER_SCHOOL_TF.Value.ToString() ="" Then
            errors.Add("OTHER_SCHOOL_TF",String.Format(Resources.strings.CCS_RequiredField,"OTHER SCHOOL TIME FRACTION"))
        End If
'End OTHER_SCHOOL_TF validate

'Record STUDENT_CENSUS_DATA Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_CENSUS_DATA Item Class tail

'Record STUDENT_CENSUS_DATA Data Provider Class @2-ABF1C50C
Public Class STUDENT_CENSUS_DATADataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_CENSUS_DATA Data Provider Class

'Record STUDENT_CENSUS_DATA Data Provider Class Variables @2-286E645D
    Protected COUNTRY_OF_BIRTHDataCommand As DataCommand=new TableCommand("SELECT COUNTRY_ID, COUNTRY_NAME " & vbCrLf & _
          "FROM COUNTRY_OF_BIRTH {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected MOTHERS_COBDataCommand As DataCommand=new TableCommand("SELECT COUNTRY_ID, COUNTRY_NAME " & vbCrLf & _
          "FROM COUNTRY_OF_BIRTH {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected FIRST_HOME_LANGUAGEDataCommand As DataCommand=new TableCommand("SELECT vwLanguage.LANG_CODE, " & vbCrLf & _
          "vwLanguage.LANG_DESCRIPTION " & vbCrLf & _
          "FROM vwLanguage {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected OTHER_HOME_LANGUAGEDataCommand As DataCommand=new TableCommand("SELECT vwLanguage.LANG_CODE, " & vbCrLf & _
          "vwLanguage.LANG_DESCRIPTION " & vbCrLf & _
          "FROM vwLanguage {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected MOTHER_LANGUAGEDataCommand As DataCommand=new TableCommand("SELECT vwLanguage.LANG_CODE, " & vbCrLf & _
          "vwLanguage.LANG_DESCRIPTION " & vbCrLf & _
          "FROM vwLanguage {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected ALLOWANCE_CODEDataCommand As DataCommand=new TableCommand("SELECT ALLOWANCE_CODE, " & vbCrLf & _
          "ALLOWANCE_TITLE " & vbCrLf & _
          "FROM GOVERNMENT_ALLOWANCE {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected FATHER_LANGUAGEDataCommand As DataCommand=new TableCommand("SELECT vwLanguage.LANG_CODE, " & vbCrLf & _
          "vwLanguage.LANG_DESCRIPTION " & vbCrLf & _
          "FROM vwLanguage {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected FATHERS_COBDataCommand As DataCommand=new TableCommand("SELECT COUNTRY_ID, COUNTRY_NAME " & vbCrLf & _
          "FROM COUNTRY_OF_BIRTH {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
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

'Record STUDENT_CENSUS_DATA BeforeBuildUpdate @2-BEA8794A
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID5",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        If Not item.COUNTRY_OF_BIRTH.IsEmpty Then
        allEmptyFlag = item.COUNTRY_OF_BIRTH.IsEmpty And allEmptyFlag
        valuesList = valuesList & "COUNTRY_OF_BIRTH=" + Update.Dao.ToSql(item.COUNTRY_OF_BIRTH.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.MOTHERS_COB.IsEmpty Then
        allEmptyFlag = item.MOTHERS_COB.IsEmpty And allEmptyFlag
        valuesList = valuesList & "MOTHERS_COB=" + Update.Dao.ToSql(item.MOTHERS_COB.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.DATE_STARTED_IN_AUST.IsEmpty Then
        allEmptyFlag = item.DATE_STARTED_IN_AUST.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DATE_STARTED_IN_AUST=" + Update.Dao.ToSql(item.DATE_STARTED_IN_AUST.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.FIRST_HOME_LANGUAGE.IsEmpty Then
        allEmptyFlag = item.FIRST_HOME_LANGUAGE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "FIRST_HOME_LANGUAGE=" + Update.Dao.ToSql(item.FIRST_HOME_LANGUAGE.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.OTHER_HOME_LANGUAGE.IsEmpty Then
        allEmptyFlag = item.OTHER_HOME_LANGUAGE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "OTHER_HOME_LANGUAGE=" + Update.Dao.ToSql(item.OTHER_HOME_LANGUAGE.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.MOTHER_LANGUAGE.IsEmpty Then
        allEmptyFlag = item.MOTHER_LANGUAGE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "MOTHER_LANGUAGE=" + Update.Dao.ToSql(item.MOTHER_LANGUAGE.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.MOTHER_EDUCATION_SCHOOL.IsEmpty Then
        allEmptyFlag = item.MOTHER_EDUCATION_SCHOOL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "MOTHER_EDUCATION_SCHOOL=" + Update.Dao.ToSql(item.MOTHER_EDUCATION_SCHOOL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.MOTHER_EDUCATION_NONSCHOOL.IsEmpty Then
        allEmptyFlag = item.MOTHER_EDUCATION_NONSCHOOL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "MOTHER_EDUCATION_NONSCHOOL=" + Update.Dao.ToSql(item.MOTHER_EDUCATION_NONSCHOOL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.MOTHER_OCCUPATIONGROUP.IsEmpty Then
        allEmptyFlag = item.MOTHER_OCCUPATIONGROUP.IsEmpty And allEmptyFlag
        valuesList = valuesList & "MOTHER_OCCUPATIONGROUP=" + Update.Dao.ToSql(item.MOTHER_OCCUPATIONGROUP.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ALLOWANCE_CODE.IsEmpty Then
        allEmptyFlag = item.ALLOWANCE_CODE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ALLOWANCE_CODE=" + Update.Dao.ToSql(item.ALLOWANCE_CODE.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.KOORITORRESFLAG.IsEmpty Then
        allEmptyFlag = item.KOORITORRESFLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "KOORITORRESFLAG=" + Update.Dao.ToSql(item.KOORITORRESFLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RESIDENTIAL_STATUS.IsEmpty Then
        allEmptyFlag = item.RESIDENTIAL_STATUS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "RESIDENTIAL_STATUS=" + Update.Dao.ToSql(item.RESIDENTIAL_STATUS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DATE_ARRIVED_IN_AUST.IsEmpty Then
        allEmptyFlag = item.DATE_ARRIVED_IN_AUST.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DATE_ARRIVED_IN_AUST=" + Update.Dao.ToSql(item.DATE_ARRIVED_IN_AUST.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.VISA_SUB_CLASS.IsEmpty Then
        allEmptyFlag = item.VISA_SUB_CLASS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "VISA_SUB_CLASS=" + Update.Dao.ToSql(item.VISA_SUB_CLASS.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.VISA_STATISTICAL_CODE.IsEmpty Then
        allEmptyFlag = item.VISA_STATISTICAL_CODE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "VISA_STATISTICAL_CODE=" + Update.Dao.ToSql(item.VISA_STATISTICAL_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PREVIOUS_SCHOOL_ID.IsEmpty Then
        allEmptyFlag = item.PREVIOUS_SCHOOL_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PREVIOUS_SCHOOL_ID=" + Update.Dao.ToSql(item.PREVIOUS_SCHOOL_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.FAMILY_OSG.IsEmpty Then
        allEmptyFlag = item.FAMILY_OSG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "FAMILY_OSG=" + Update.Dao.ToSql(item.FAMILY_OSG.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.HOUSEHOLD_STATUS.IsEmpty Then
        allEmptyFlag = item.HOUSEHOLD_STATUS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "HOUSEHOLD_STATUS=" + Update.Dao.ToSql(item.HOUSEHOLD_STATUS.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.DISABILITY_ID.IsEmpty Then
        allEmptyFlag = item.DISABILITY_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DISABILITY_ID=" + Update.Dao.ToSql(item.DISABILITY_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.REPEATING_YEAR.IsEmpty Then
        allEmptyFlag = item.REPEATING_YEAR.IsEmpty And allEmptyFlag
        valuesList = valuesList & "REPEATING_YEAR=" + Update.Dao.ToSql(item.REPEATING_YEAR.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.OTHER_SCHOOL_TF.IsEmpty Then
        allEmptyFlag = item.OTHER_SCHOOL_TF.IsEmpty And allEmptyFlag
        valuesList = valuesList & "OTHER_SCHOOL_TF=" + Update.Dao.ToSql(item.OTHER_SCHOOL_TF.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.Hidden_last_altered_by.IsEmpty Then
        allEmptyFlag = item.Hidden_last_altered_by.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.Hidden_last_altered_by.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_last_altered_date.IsEmpty Then
        allEmptyFlag = item.Hidden_last_altered_date.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.Hidden_last_altered_date.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.FATHER_LANGUAGE.IsEmpty Then
        allEmptyFlag = item.FATHER_LANGUAGE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "FATHER_LANGUAGE=" + Update.Dao.ToSql(item.FATHER_LANGUAGE.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.FATHERS_COB.IsEmpty Then
        allEmptyFlag = item.FATHERS_COB.IsEmpty And allEmptyFlag
        valuesList = valuesList & "FATHERS_COB=" + Update.Dao.ToSql(item.FATHERS_COB.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.FATHER_EDUCATION_SCHOOL.IsEmpty Then
        allEmptyFlag = item.FATHER_EDUCATION_SCHOOL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "FATHER_EDUCATION_SCHOOL=" + Update.Dao.ToSql(item.FATHER_EDUCATION_SCHOOL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.FATHER_EDUCATION_NONSCHOOL.IsEmpty Then
        allEmptyFlag = item.FATHER_EDUCATION_NONSCHOOL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "FATHER_EDUCATION_NONSCHOOL=" + Update.Dao.ToSql(item.FATHER_EDUCATION_NONSCHOOL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.FATHER_OCCUPATIONGROUP.IsEmpty Then
        allEmptyFlag = item.FATHER_OCCUPATIONGROUP.IsEmpty And allEmptyFlag
        valuesList = valuesList & "FATHER_OCCUPATIONGROUP=" + Update.Dao.ToSql(item.FATHER_OCCUPATIONGROUP.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DATE_LAST_ATTENDED_SCHOOL.IsEmpty Then
        allEmptyFlag = item.DATE_LAST_ATTENDED_SCHOOL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DATE_LAST_ATTENDED_SCHOOL=" + Update.Dao.ToSql(item.DATE_LAST_ATTENDED_SCHOOL.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.CRIS_ID.IsEmpty Then
        allEmptyFlag = item.CRIS_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CRIS_ID=" + Update.Dao.ToSql(item.CRIS_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.YOUTH_JUSTICE_INVOLVEMENT.IsEmpty Then
        allEmptyFlag = item.YOUTH_JUSTICE_INVOLVEMENT.IsEmpty And allEmptyFlag
        valuesList = valuesList & "YOUTH_JUSTICE_INVOLVEMENT=" + Update.Dao.ToSql(item.YOUTH_JUSTICE_INVOLVEMENT.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.YOUTH_JUSTICE_INVOLVEMENT_DETAILS.IsEmpty Then
        allEmptyFlag = item.YOUTH_JUSTICE_INVOLVEMENT_DETAILS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "YOUTH_JUSTICE_INVOLVEMENT_DETAILS=" + Update.Dao.ToSql(item.YOUTH_JUSTICE_INVOLVEMENT_DETAILS.GetFormattedValue(""),FieldType._Text) & ","
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

'Record STUDENT_CENSUS_DATA AfterExecuteSelect @2-9E186842
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.COUNTRY_OF_BIRTH.SetValue(dr(i)("COUNTRY_OF_BIRTH"),"")
            item.MOTHERS_COB.SetValue(dr(i)("MOTHERS_COB"),"")
            item.DATE_STARTED_IN_AUST.SetValue(dr(i)("DATE_STARTED_IN_AUST"),Select_.DateFormat)
            item.FIRST_HOME_LANGUAGE.SetValue(dr(i)("FIRST_HOME_LANGUAGE"),"")
            item.OTHER_HOME_LANGUAGE.SetValue(dr(i)("OTHER_HOME_LANGUAGE"),"")
            item.MOTHER_LANGUAGE.SetValue(dr(i)("MOTHER_LANGUAGE"),"")
            item.MOTHER_EDUCATION_SCHOOL.SetValue(dr(i)("MOTHER_EDUCATION_SCHOOL"),"")
            item.MOTHER_EDUCATION_NONSCHOOL.SetValue(dr(i)("MOTHER_EDUCATION_NONSCHOOL"),"")
            item.MOTHER_OCCUPATIONGROUP.SetValue(dr(i)("MOTHER_OCCUPATIONGROUP"),"")
            item.ALLOWANCE_CODE.SetValue(dr(i)("ALLOWANCE_CODE"),"")
            item.KOORITORRESFLAG.SetValue(dr(i)("KOORITORRESFLAG"),"")
            item.RESIDENTIAL_STATUS.SetValue(dr(i)("RESIDENTIAL_STATUS"),"")
            item.DATE_ARRIVED_IN_AUST.SetValue(dr(i)("DATE_ARRIVED_IN_AUST"),Select_.DateFormat)
            item.VISA_SUB_CLASS.SetValue(dr(i)("VISA_SUB_CLASS"),"")
            item.VISA_STATISTICAL_CODE.SetValue(dr(i)("VISA_STATISTICAL_CODE"),"")
            item.PREVIOUS_SCHOOL_ID.SetValue(dr(i)("PREVIOUS_SCHOOL_ID"),"")
            item.FAMILY_OSG.SetValue(dr(i)("FAMILY_OSG"),"")
            item.HOUSEHOLD_STATUS.SetValue(dr(i)("HOUSEHOLD_STATUS"),"")
            item.DISABILITY_ID.SetValue(dr(i)("DISABILITY_ID"),"")
            item.REPEATING_YEAR.SetValue(dr(i)("REPEATING_YEAR"),Select_.BoolFormat)
            item.OTHER_SCHOOL_TF.SetValue(dr(i)("OTHER_SCHOOL_TF"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.Hidden_last_altered_by.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.Hidden_last_altered_date.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.FATHER_LANGUAGE.SetValue(dr(i)("FATHER_LANGUAGE"),"")
            item.FATHERS_COB.SetValue(dr(i)("FATHERS_COB"),"")
            item.FATHER_EDUCATION_SCHOOL.SetValue(dr(i)("FATHER_EDUCATION_SCHOOL"),"")
            item.FATHER_EDUCATION_NONSCHOOL.SetValue(dr(i)("FATHER_EDUCATION_NONSCHOOL"),"")
            item.FATHER_OCCUPATIONGROUP.SetValue(dr(i)("FATHER_OCCUPATIONGROUP"),"")
            item.DATE_LAST_ATTENDED_SCHOOL.SetValue(dr(i)("DATE_LAST_ATTENDED_SCHOOL"),Select_.DateFormat)
            item.Link_gotoTAFECensusPageHref = "Student_CensusTAFE_maintain.aspx"
            item.CRIS_ID.SetValue(dr(i)("CRIS_ID"),"")
            item.YOUTH_JUSTICE_INVOLVEMENT.SetValue(dr(i)("YOUTH_JUSTICE_INVOLVEMENT"),Select_.BoolFormat)
            item.YOUTH_JUSTICE_INVOLVEMENT_DETAILS.SetValue(dr(i)("YOUTH_JUSTICE_INVOLVEMENT_DETAILS"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record STUDENT_CENSUS_DATA AfterExecuteSelect

'ListBox COUNTRY_OF_BIRTH Initialize Data Source @6-06EFAC5B
        COUNTRY_OF_BIRTHDataCommand.Dao._optimized = False
        Dim COUNTRY_OF_BIRTHtableIndex As Integer = 0
        COUNTRY_OF_BIRTHDataCommand.OrderBy = "COUNTRY_NAME"
        COUNTRY_OF_BIRTHDataCommand.Parameters.Clear()
'End ListBox COUNTRY_OF_BIRTH Initialize Data Source

'ListBox COUNTRY_OF_BIRTH BeforeExecuteSelect @6-91D0248F
        Try
            ListBoxSource=COUNTRY_OF_BIRTHDataCommand.Execute().Tables(COUNTRY_OF_BIRTHtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox COUNTRY_OF_BIRTH BeforeExecuteSelect

'ListBox COUNTRY_OF_BIRTH AfterExecuteSelect @6-90CB2490
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New IntegerField("", ListBoxSource(j)("COUNTRY_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("COUNTRY_NAME")
            item.COUNTRY_OF_BIRTHItems.Add(Key, Val)
        Next
'End ListBox COUNTRY_OF_BIRTH AfterExecuteSelect

'ListBox MOTHERS_COB Initialize Data Source @7-3CA19604
        MOTHERS_COBDataCommand.Dao._optimized = False
        Dim MOTHERS_COBtableIndex As Integer = 0
        MOTHERS_COBDataCommand.OrderBy = "COUNTRY_NAME"
        MOTHERS_COBDataCommand.Parameters.Clear()
'End ListBox MOTHERS_COB Initialize Data Source

'ListBox MOTHERS_COB BeforeExecuteSelect @7-9B65AB3F
        Try
            ListBoxSource=MOTHERS_COBDataCommand.Execute().Tables(MOTHERS_COBtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox MOTHERS_COB BeforeExecuteSelect

'ListBox MOTHERS_COB AfterExecuteSelect @7-0EB3CC7A
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New IntegerField("", ListBoxSource(j)("COUNTRY_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("COUNTRY_NAME")
            item.MOTHERS_COBItems.Add(Key, Val)
        Next
'End ListBox MOTHERS_COB AfterExecuteSelect

'ListBox FIRST_HOME_LANGUAGE Initialize Data Source @11-C358008E
        FIRST_HOME_LANGUAGEDataCommand.Dao._optimized = False
        Dim FIRST_HOME_LANGUAGEtableIndex As Integer = 0
        FIRST_HOME_LANGUAGEDataCommand.OrderBy = "IsEnglishLanguage desc, IsSpecialLanguage desc, IsObsoleteLanguage, LANG_DESCRIPTION"
        FIRST_HOME_LANGUAGEDataCommand.Parameters.Clear()
'End ListBox FIRST_HOME_LANGUAGE Initialize Data Source

'ListBox FIRST_HOME_LANGUAGE BeforeExecuteSelect @11-424B0157
        Try
            ListBoxSource=FIRST_HOME_LANGUAGEDataCommand.Execute().Tables(FIRST_HOME_LANGUAGEtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox FIRST_HOME_LANGUAGE BeforeExecuteSelect

'ListBox FIRST_HOME_LANGUAGE AfterExecuteSelect @11-0769E614
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New IntegerField("", ListBoxSource(j)("LANG_CODE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("LANG_DESCRIPTION")
            item.FIRST_HOME_LANGUAGEItems.Add(Key, Val)
        Next
'End ListBox FIRST_HOME_LANGUAGE AfterExecuteSelect

'ListBox OTHER_HOME_LANGUAGE Initialize Data Source @12-8ED7F32C
        OTHER_HOME_LANGUAGEDataCommand.Dao._optimized = False
        Dim OTHER_HOME_LANGUAGEtableIndex As Integer = 0
        OTHER_HOME_LANGUAGEDataCommand.OrderBy = "IsEnglishLanguage desc, IsSpecialLanguage desc, IsObsoleteLanguage, LANG_DESCRIPTION"
        OTHER_HOME_LANGUAGEDataCommand.Parameters.Clear()
'End ListBox OTHER_HOME_LANGUAGE Initialize Data Source

'ListBox OTHER_HOME_LANGUAGE BeforeExecuteSelect @12-7342A801
        Try
            ListBoxSource=OTHER_HOME_LANGUAGEDataCommand.Execute().Tables(OTHER_HOME_LANGUAGEtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox OTHER_HOME_LANGUAGE BeforeExecuteSelect

'ListBox OTHER_HOME_LANGUAGE AfterExecuteSelect @12-1E88DB8C
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New IntegerField("", ListBoxSource(j)("LANG_CODE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("LANG_DESCRIPTION")
            item.OTHER_HOME_LANGUAGEItems.Add(Key, Val)
        Next
'End ListBox OTHER_HOME_LANGUAGE AfterExecuteSelect

'ListBox MOTHER_LANGUAGE Initialize Data Source @13-0757DC9B
        MOTHER_LANGUAGEDataCommand.Dao._optimized = False
        Dim MOTHER_LANGUAGEtableIndex As Integer = 0
        MOTHER_LANGUAGEDataCommand.OrderBy = "IsEnglishLanguage desc, IsSpecialLanguage desc, IsObsoleteLanguage, LANG_DESCRIPTION"
        MOTHER_LANGUAGEDataCommand.Parameters.Clear()
'End ListBox MOTHER_LANGUAGE Initialize Data Source

'ListBox MOTHER_LANGUAGE BeforeExecuteSelect @13-467D521B
        Try
            ListBoxSource=MOTHER_LANGUAGEDataCommand.Execute().Tables(MOTHER_LANGUAGEtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox MOTHER_LANGUAGE BeforeExecuteSelect

'ListBox MOTHER_LANGUAGE AfterExecuteSelect @13-9BD2C34D
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New IntegerField("", ListBoxSource(j)("LANG_CODE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("LANG_DESCRIPTION")
            item.MOTHER_LANGUAGEItems.Add(Key, Val)
        Next
'End ListBox MOTHER_LANGUAGE AfterExecuteSelect

'ListBox MOTHER_EDUCATION_SCHOOL AfterExecuteSelect @14-1FB964FF
        
item.MOTHER_EDUCATION_SCHOOLItems.Add("0","UNKNOWN")
item.MOTHER_EDUCATION_SCHOOLItems.Add("4","Year 12 or equivalent")
item.MOTHER_EDUCATION_SCHOOLItems.Add("3","Year 11 or equivalent")
item.MOTHER_EDUCATION_SCHOOLItems.Add("2","Year 10 or equivalent")
item.MOTHER_EDUCATION_SCHOOLItems.Add("1","Year 9 or equivalent or below")
'End ListBox MOTHER_EDUCATION_SCHOOL AfterExecuteSelect

'ListBox MOTHER_EDUCATION_NONSCHOOL AfterExecuteSelect @15-F17A4919
        
item.MOTHER_EDUCATION_NONSCHOOLItems.Add("0","UNKNOWN")
item.MOTHER_EDUCATION_NONSCHOOLItems.Add("7","Bachelor degree or above")
item.MOTHER_EDUCATION_NONSCHOOLItems.Add("6","Advanced Diploma/Diploma")
item.MOTHER_EDUCATION_NONSCHOOLItems.Add("5","Certificate I to IV (incl. Trade Cert)")
item.MOTHER_EDUCATION_NONSCHOOLItems.Add("8","No non-school qualification")
'End ListBox MOTHER_EDUCATION_NONSCHOOL AfterExecuteSelect

'ListBox MOTHER_OCCUPATIONGROUP AfterExecuteSelect @16-AB475947
        
item.MOTHER_OCCUPATIONGROUPItems.Add("U","UNKNOWN")
item.MOTHER_OCCUPATIONGROUPItems.Add("A","A - Senior Management, Qualified Professionals")
item.MOTHER_OCCUPATIONGROUPItems.Add("B","B - Other Management, Arts/Media/Sports, Other Professionals")
item.MOTHER_OCCUPATIONGROUPItems.Add("C","C - Trades, Clerks, Skilled Office, Sales and Service")
item.MOTHER_OCCUPATIONGROUPItems.Add("D","D - Machine Operators, Hospitality, Asistants, Labourers")
item.MOTHER_OCCUPATIONGROUPItems.Add("N","N - No paid work in last 12 months")
'End ListBox MOTHER_OCCUPATIONGROUP AfterExecuteSelect

'ListBox ALLOWANCE_CODE Initialize Data Source @21-0D47D028
        ALLOWANCE_CODEDataCommand.Dao._optimized = False
        Dim ALLOWANCE_CODEtableIndex As Integer = 0
        ALLOWANCE_CODEDataCommand.OrderBy = "ALLOWANCE_CODE"
        ALLOWANCE_CODEDataCommand.Parameters.Clear()
'End ListBox ALLOWANCE_CODE Initialize Data Source

'ListBox ALLOWANCE_CODE BeforeExecuteSelect @21-B97324EC
        Try
            ListBoxSource=ALLOWANCE_CODEDataCommand.Execute().Tables(ALLOWANCE_CODEtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox ALLOWANCE_CODE BeforeExecuteSelect

'ListBox ALLOWANCE_CODE AfterExecuteSelect @21-050D8286
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New IntegerField("", ListBoxSource(j)("ALLOWANCE_CODE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("ALLOWANCE_TITLE")
            item.ALLOWANCE_CODEItems.Add(Key, Val)
        Next
'End ListBox ALLOWANCE_CODE AfterExecuteSelect

'ListBox KOORITORRESFLAG AfterExecuteSelect @22-C82F700C
        
item.KOORITORRESFLAGItems.Add("N","NONE")
item.KOORITORRESFLAGItems.Add("K","KOORI / ABORIGINAL")
item.KOORITORRESFLAGItems.Add("T","TORRES STRAIT ISLANDER")
item.KOORITORRESFLAGItems.Add("B","BOTH KOORI AND TORRES")
'End ListBox KOORITORRESFLAG AfterExecuteSelect

'ListBox RESIDENTIAL_STATUS AfterExecuteSelect @23-2B047CCA
        
item.RESIDENTIAL_STATUSItems.Add("P","Permanent")
item.RESIDENTIAL_STATUSItems.Add("T","Temporary")
'End ListBox RESIDENTIAL_STATUS AfterExecuteSelect

'ListBox FAMILY_OSG AfterExecuteSelect @29-0921F112
        
item.FAMILY_OSGItems.Add("","")
item.FAMILY_OSGItems.Add("1","1")
item.FAMILY_OSGItems.Add("2","2")
item.FAMILY_OSGItems.Add("3","3")
item.FAMILY_OSGItems.Add("4","4")
item.FAMILY_OSGItems.Add("5","5")
'End ListBox FAMILY_OSG AfterExecuteSelect

'ListBox HOUSEHOLD_STATUS AfterExecuteSelect @30-13787544
        
item.HOUSEHOLD_STATUSItems.Add("","UNKNOWN")
item.HOUSEHOLD_STATUSItems.Add("1","At home with TWO parents/guardians")
item.HOUSEHOLD_STATUSItems.Add("2","At home with One parent/guardian")
item.HOUSEHOLD_STATUSItems.Add("3","Out of Home Care - Informal")
item.HOUSEHOLD_STATUSItems.Add("4","Homeless Youth")
item.HOUSEHOLD_STATUSItems.Add("5","Independent")
item.HOUSEHOLD_STATUSItems.Add("6","Out of Home Care - Statutory/Court-ordered")
item.HOUSEHOLD_STATUSItems.Add("7","Out of Home Care - Permanent Care")
'End ListBox HOUSEHOLD_STATUS AfterExecuteSelect

'ListBox REPEATING_YEAR AfterExecuteSelect @32-4C3F4333
        
item.REPEATING_YEARItems.Add("Yes","Yes")
item.REPEATING_YEARItems.Add("No","No")
'End ListBox REPEATING_YEAR AfterExecuteSelect

'ListBox FATHER_LANGUAGE Initialize Data Source @17-9D5DDD79
        FATHER_LANGUAGEDataCommand.Dao._optimized = False
        Dim FATHER_LANGUAGEtableIndex As Integer = 0
        FATHER_LANGUAGEDataCommand.OrderBy = "IsEnglishLanguage desc, IsSpecialLanguage desc, IsObsoleteLanguage, LANG_DESCRIPTION"
        FATHER_LANGUAGEDataCommand.Parameters.Clear()
'End ListBox FATHER_LANGUAGE Initialize Data Source

'ListBox FATHER_LANGUAGE BeforeExecuteSelect @17-76398126
        Try
            ListBoxSource=FATHER_LANGUAGEDataCommand.Execute().Tables(FATHER_LANGUAGEtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox FATHER_LANGUAGE BeforeExecuteSelect

'ListBox FATHER_LANGUAGE AfterExecuteSelect @17-A4751781
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New IntegerField("", ListBoxSource(j)("LANG_CODE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("LANG_DESCRIPTION")
            item.FATHER_LANGUAGEItems.Add(Key, Val)
        Next
'End ListBox FATHER_LANGUAGE AfterExecuteSelect

'ListBox FATHERS_COB Initialize Data Source @8-C1343BE3
        FATHERS_COBDataCommand.Dao._optimized = False
        Dim FATHERS_COBtableIndex As Integer = 0
        FATHERS_COBDataCommand.OrderBy = "COUNTRY_NAME"
        FATHERS_COBDataCommand.Parameters.Clear()
'End ListBox FATHERS_COB Initialize Data Source

'ListBox FATHERS_COB BeforeExecuteSelect @8-A923D646
        Try
            ListBoxSource=FATHERS_COBDataCommand.Execute().Tables(FATHERS_COBtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox FATHERS_COB BeforeExecuteSelect

'ListBox FATHERS_COB AfterExecuteSelect @8-931ADFDD
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New IntegerField("", ListBoxSource(j)("COUNTRY_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("COUNTRY_NAME")
            item.FATHERS_COBItems.Add(Key, Val)
        Next
'End ListBox FATHERS_COB AfterExecuteSelect

'ListBox FATHER_EDUCATION_SCHOOL AfterExecuteSelect @18-3DD20405
        
item.FATHER_EDUCATION_SCHOOLItems.Add("0","UNKNOWN")
item.FATHER_EDUCATION_SCHOOLItems.Add("4","Year 12 or equivalent")
item.FATHER_EDUCATION_SCHOOLItems.Add("3","Year 11 or equivalent")
item.FATHER_EDUCATION_SCHOOLItems.Add("2","Year 10 or equivalent")
item.FATHER_EDUCATION_SCHOOLItems.Add("1","Year 9 or equivalent or below")
'End ListBox FATHER_EDUCATION_SCHOOL AfterExecuteSelect

'ListBox FATHER_EDUCATION_NONSCHOOL AfterExecuteSelect @19-0C97C698
        
item.FATHER_EDUCATION_NONSCHOOLItems.Add("0","UNKNOWN")
item.FATHER_EDUCATION_NONSCHOOLItems.Add("7","Bachelor degree or above")
item.FATHER_EDUCATION_NONSCHOOLItems.Add("6","Advanced Diploma/Diploma")
item.FATHER_EDUCATION_NONSCHOOLItems.Add("5","Certificate I to IV (incl. Trade Cert)")
item.FATHER_EDUCATION_NONSCHOOLItems.Add("8","No non-school qualification")
'End ListBox FATHER_EDUCATION_NONSCHOOL AfterExecuteSelect

'ListBox FATHER_OCCUPATIONGROUP AfterExecuteSelect @20-355E2782
        
item.FATHER_OCCUPATIONGROUPItems.Add("U","UNKNOWN")
item.FATHER_OCCUPATIONGROUPItems.Add("A","A - Senior Management, Qualified Professionals")
item.FATHER_OCCUPATIONGROUPItems.Add("B","B - Other Management, Arts/Media/Sports, Other Professionals")
item.FATHER_OCCUPATIONGROUPItems.Add("C","C - Trades, Clerks, Skilled Office, Sales and Service")
item.FATHER_OCCUPATIONGROUPItems.Add("D","D - Machine Operators, Hospitality, Asistants, Labourers")
item.FATHER_OCCUPATIONGROUPItems.Add("N","N - No paid work in last 12 months")
'End ListBox FATHER_OCCUPATIONGROUP AfterExecuteSelect

'ListBox YOUTH_JUSTICE_INVOLVEMENT AfterExecuteSelect @189-9233F212
        
item.YOUTH_JUSTICE_INVOLVEMENTItems.Add("No","No")
item.YOUTH_JUSTICE_INVOLVEMENTItems.Add("Yes","Yes")
'End ListBox YOUTH_JUSTICE_INVOLVEMENT AfterExecuteSelect

'Record STUDENT_CENSUS_DATA AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record STUDENT_CENSUS_DATA AfterExecuteSelect tail

'Record STUDENT_CENSUS_DATA Data Provider Class @2-A61BA892
End Class

'End Record STUDENT_CENSUS_DATA Data Provider Class

'Record STUDENT_CENSUS_DATA1 Item Class @133-FCEFDB6B
Public Class STUDENT_CENSUS_DATA1Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public STUDENT_ID As FloatField
    Public RESTRICT_ACCESS_ATRISK As BooleanField
    Public RESTRICT_ACCESS_ATRISKItems As ItemCollection
    Public RESTRICT_ACCESS_ATRISK_DESCRIPTION As TextField
    Public RESTRICT_ACCESS_ALERT As BooleanField
    Public RESTRICT_ACCESS_ALERTItems As ItemCollection
    Public RESTRICT_ACCESS_ALERT_RECEIVED As BooleanField
    Public RESTRICT_ACCESS_ALERT_RECEIVEDItems As ItemCollection
    Public RESTRICT_ACCESS_TYPE As TextField
    Public RESTRICT_ACCESS_TYPEItems As ItemCollection
    Public RESTRICT_ACCESS_DESCRIPTION As TextField
    Public RESTRICT_ACTIVITY_ALERT As BooleanField
    Public RESTRICT_ACTIVITY_ALERTItems As ItemCollection
    Public RESTRICT_ACTIVITY_DESCRIPTION As TextField
    Public Sub New()
    STUDENT_ID = New FloatField("", Nothing)
    RESTRICT_ACCESS_ATRISK = New BooleanField(Settings.BoolFormat, Nothing)
    RESTRICT_ACCESS_ATRISKItems = New ItemCollection()
    RESTRICT_ACCESS_ATRISK_DESCRIPTION = New TextField("", Nothing)
    RESTRICT_ACCESS_ALERT = New BooleanField(Settings.BoolFormat, Nothing)
    RESTRICT_ACCESS_ALERTItems = New ItemCollection()
    RESTRICT_ACCESS_ALERT_RECEIVED = New BooleanField(Settings.BoolFormat, Nothing)
    RESTRICT_ACCESS_ALERT_RECEIVEDItems = New ItemCollection()
    RESTRICT_ACCESS_TYPE = New TextField("", Nothing)
    RESTRICT_ACCESS_TYPEItems = New ItemCollection()
    RESTRICT_ACCESS_DESCRIPTION = New TextField("", Nothing)
    RESTRICT_ACTIVITY_ALERT = New BooleanField(Settings.BoolFormat, Nothing)
    RESTRICT_ACTIVITY_ALERTItems = New ItemCollection()
    RESTRICT_ACTIVITY_DESCRIPTION = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_CENSUS_DATA1Item
        Dim item As STUDENT_CENSUS_DATA1Item = New STUDENT_CENSUS_DATA1Item()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RESTRICT_ACCESS_ATRISK")) Then
        item.RESTRICT_ACCESS_ATRISK.SetValue(DBUtility.GetInitialValue("RESTRICT_ACCESS_ATRISK"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RESTRICT_ACCESS_ATRISK_DESCRIPTION")) Then
        item.RESTRICT_ACCESS_ATRISK_DESCRIPTION.SetValue(DBUtility.GetInitialValue("RESTRICT_ACCESS_ATRISK_DESCRIPTION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RESTRICT_ACCESS_ALERT")) Then
        item.RESTRICT_ACCESS_ALERT.SetValue(DBUtility.GetInitialValue("RESTRICT_ACCESS_ALERT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RESTRICT_ACCESS_ALERT_RECEIVED")) Then
        item.RESTRICT_ACCESS_ALERT_RECEIVED.SetValue(DBUtility.GetInitialValue("RESTRICT_ACCESS_ALERT_RECEIVED"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RESTRICT_ACCESS_TYPE")) Then
        item.RESTRICT_ACCESS_TYPE.SetValue(DBUtility.GetInitialValue("RESTRICT_ACCESS_TYPE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RESTRICT_ACCESS_DESCRIPTION")) Then
        item.RESTRICT_ACCESS_DESCRIPTION.SetValue(DBUtility.GetInitialValue("RESTRICT_ACCESS_DESCRIPTION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RESTRICT_ACTIVITY_ALERT")) Then
        item.RESTRICT_ACTIVITY_ALERT.SetValue(DBUtility.GetInitialValue("RESTRICT_ACTIVITY_ALERT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RESTRICT_ACTIVITY_DESCRIPTION")) Then
        item.RESTRICT_ACTIVITY_DESCRIPTION.SetValue(DBUtility.GetInitialValue("RESTRICT_ACTIVITY_DESCRIPTION"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "RESTRICT_ACCESS_ATRISK"
                    Return RESTRICT_ACCESS_ATRISK
                Case "RESTRICT_ACCESS_ATRISK_DESCRIPTION"
                    Return RESTRICT_ACCESS_ATRISK_DESCRIPTION
                Case "RESTRICT_ACCESS_ALERT"
                    Return RESTRICT_ACCESS_ALERT
                Case "RESTRICT_ACCESS_ALERT_RECEIVED"
                    Return RESTRICT_ACCESS_ALERT_RECEIVED
                Case "RESTRICT_ACCESS_TYPE"
                    Return RESTRICT_ACCESS_TYPE
                Case "RESTRICT_ACCESS_DESCRIPTION"
                    Return RESTRICT_ACCESS_DESCRIPTION
                Case "RESTRICT_ACTIVITY_ALERT"
                    Return RESTRICT_ACTIVITY_ALERT
                Case "RESTRICT_ACTIVITY_DESCRIPTION"
                    Return RESTRICT_ACTIVITY_DESCRIPTION
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, FloatField)
                Case "RESTRICT_ACCESS_ATRISK"
                    RESTRICT_ACCESS_ATRISK = CType(value, BooleanField)
                Case "RESTRICT_ACCESS_ATRISK_DESCRIPTION"
                    RESTRICT_ACCESS_ATRISK_DESCRIPTION = CType(value, TextField)
                Case "RESTRICT_ACCESS_ALERT"
                    RESTRICT_ACCESS_ALERT = CType(value, BooleanField)
                Case "RESTRICT_ACCESS_ALERT_RECEIVED"
                    RESTRICT_ACCESS_ALERT_RECEIVED = CType(value, BooleanField)
                Case "RESTRICT_ACCESS_TYPE"
                    RESTRICT_ACCESS_TYPE = CType(value, TextField)
                Case "RESTRICT_ACCESS_DESCRIPTION"
                    RESTRICT_ACCESS_DESCRIPTION = CType(value, TextField)
                Case "RESTRICT_ACTIVITY_ALERT"
                    RESTRICT_ACTIVITY_ALERT = CType(value, BooleanField)
                Case "RESTRICT_ACTIVITY_DESCRIPTION"
                    RESTRICT_ACTIVITY_DESCRIPTION = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STUDENT_CENSUS_DATA1DataProvider)
'End Record STUDENT_CENSUS_DATA1 Item Class

'RESTRICT_ACCESS_ATRISK validate @140-08C58CF0
        If IsNothing(RESTRICT_ACCESS_ATRISK.Value) OrElse RESTRICT_ACCESS_ATRISK.Value.ToString() ="" Then
            errors.Add("RESTRICT_ACCESS_ATRISK",String.Format(Resources.strings.CCS_RequiredField,"Is the Student AT RISK?"))
        End If
'End RESTRICT_ACCESS_ATRISK validate

'TextArea RESTRICT_ACCESS_ATRISK_DESCRIPTION Event OnValidate. Action Custom Code @150-73254650
    ' -------------------------
    'Nov-2019|EA| require if At Risk is Yes
    If (IsNothing(RESTRICT_ACCESS_ATRISK_DESCRIPTION.Value)) And (RESTRICT_ACCESS_ATRISK.Value = True) Then
            errors.Add("RESTRICT_ACCESS_ATRISK_DESCRIPTION","Please enter AT RISK Restriction if student AT RISK is [Yes]")
    End If
    ' -------------------------
'End TextArea RESTRICT_ACCESS_ATRISK_DESCRIPTION Event OnValidate. Action Custom Code

'RESTRICT_ACCESS_ALERT validate @142-C371470E
        If IsNothing(RESTRICT_ACCESS_ALERT.Value) OrElse RESTRICT_ACCESS_ALERT.Value.ToString() ="" Then
            errors.Add("RESTRICT_ACCESS_ALERT",String.Format(Resources.strings.CCS_RequiredField,"Is there an ACCESS ALERT for the student?"))
        End If
'End RESTRICT_ACCESS_ALERT validate

'RadioButton RESTRICT_ACCESS_TYPE Event OnValidate. Action Custom Code @151-73254650
    ' -------------------------
    'Nov-2019|EA| require if Access Type is Yes
    If (IsNothing(RESTRICT_ACCESS_TYPE.Value)) And (RESTRICT_ACCESS_ALERT.Value = True) Then
            errors.Add("RESTRICT_ACCESS_TYPE","Select ACCESS TYPE if student ACCESS ALERT is [Yes]")
    End If
    If (RESTRICT_ACCESS_TYPE.Value.ToString() = "None") And (RESTRICT_ACCESS_ALERT.Value = True) Then
            errors.Add("RESTRICT_ACCESS_TYPE","Select ACCESS TYPE (other than [None]) if student ACCESS ALERT is [Yes]")
    End If
    If (RESTRICT_ACCESS_TYPE.Value.ToString() = "Other") And (IsNothing(RESTRICT_ACCESS_DESCRIPTION.Value)) Then
            errors.Add("RESTRICT_ACCESS_DESCRIPTION","Please enter ACCESS DESCRIPTION if student ACCESS TYPE is [Other]")
    End If
    ' -------------------------
'End RadioButton RESTRICT_ACCESS_TYPE Event OnValidate. Action Custom Code

'RESTRICT_ACTIVITY_ALERT validate @146-B516B25A
        If IsNothing(RESTRICT_ACTIVITY_ALERT.Value) OrElse RESTRICT_ACTIVITY_ALERT.Value.ToString() ="" Then
            errors.Add("RESTRICT_ACTIVITY_ALERT",String.Format(Resources.strings.CCS_RequiredField,"Is there an ACTIVITY ALERT for the Student?"))
        End If
'End RESTRICT_ACTIVITY_ALERT validate

'TextArea RESTRICT_ACTIVITY_DESCRIPTION Event OnValidate. Action Custom Code @152-73254650
    ' -------------------------
    'Nov-2019|EA| require if Access Type is Yes
	If (IsNothing(RESTRICT_ACTIVITY_DESCRIPTION.Value)) And (RESTRICT_ACTIVITY_ALERT.Value = True) Then
		errors.Add("RESTRICT_ACTIVITY_DESCRIPTION","Please enter ACTIVITY Restriction if student ACTIVITY ALERT is [Yes]")
	End If
    ' -------------------------
'End TextArea RESTRICT_ACTIVITY_DESCRIPTION Event OnValidate. Action Custom Code

'Record STUDENT_CENSUS_DATA1 Item Class tail @133-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_CENSUS_DATA1 Item Class tail

'Record STUDENT_CENSUS_DATA1 Data Provider Class @133-876F6F01
Public Class STUDENT_CENSUS_DATA1DataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_CENSUS_DATA1 Data Provider Class

'Record STUDENT_CENSUS_DATA1 Data Provider Class Variables @133-3B6F459A
    Public UrlSTUDENT_ID As TextParameter
    Protected item As STUDENT_CENSUS_DATA1Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_CENSUS_DATA1 Data Provider Class Variables

'Record STUDENT_CENSUS_DATA1 Data Provider Class Constructor @133-C95482E0

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_CENSUS_DATA {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID137"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_CENSUS_DATA1 Data Provider Class Constructor

'Record STUDENT_CENSUS_DATA1 Data Provider Class LoadParams Method @133-A977A0E9

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID))
    End Function
'End Record STUDENT_CENSUS_DATA1 Data Provider Class LoadParams Method

'Record STUDENT_CENSUS_DATA1 Data Provider Class CheckUnique Method @133-B5E921A7

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_CENSUS_DATA1Item) As Boolean
        Return True
    End Function
'End Record STUDENT_CENSUS_DATA1 Data Provider Class CheckUnique Method

'Record STUDENT_CENSUS_DATA1 Data Provider Class PrepareUpdate Method @133-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STUDENT_CENSUS_DATA1 Data Provider Class PrepareUpdate Method

'Record STUDENT_CENSUS_DATA1 Data Provider Class PrepareUpdate Method tail @133-E31F8E2A
    End Sub
'End Record STUDENT_CENSUS_DATA1 Data Provider Class PrepareUpdate Method tail

'Record STUDENT_CENSUS_DATA1 Data Provider Class Update Method @133-EB0DF7DF

    Public Function UpdateItem(ByVal item As STUDENT_CENSUS_DATA1Item) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT_CENSUS_DATA SET {Values}", New String(){"STUDENT_ID137"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_CENSUS_DATA1 Data Provider Class Update Method

'Record STUDENT_CENSUS_DATA1 BeforeBuildUpdate @133-9E15D43F
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID137",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        If Not item.RESTRICT_ACCESS_ATRISK.IsEmpty Then
        allEmptyFlag = item.RESTRICT_ACCESS_ATRISK.IsEmpty And allEmptyFlag
        valuesList = valuesList & "RESTRICT_ACCESS_ATRISK=" + Update.Dao.ToSql(item.RESTRICT_ACCESS_ATRISK.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.RESTRICT_ACCESS_ATRISK_DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.RESTRICT_ACCESS_ATRISK_DESCRIPTION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "RESTRICT_ACCESS_ATRISK_DESCRIPTION=" + Update.Dao.ToSql(item.RESTRICT_ACCESS_ATRISK_DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RESTRICT_ACCESS_ALERT.IsEmpty Then
        allEmptyFlag = item.RESTRICT_ACCESS_ALERT.IsEmpty And allEmptyFlag
        valuesList = valuesList & "RESTRICT_ACCESS_ALERT=" + Update.Dao.ToSql(item.RESTRICT_ACCESS_ALERT.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.RESTRICT_ACCESS_ALERT_RECEIVED.IsEmpty Then
        allEmptyFlag = item.RESTRICT_ACCESS_ALERT_RECEIVED.IsEmpty And allEmptyFlag
        valuesList = valuesList & "RESTRICT_ACCESS_ALERT_RECEIVED=" + Update.Dao.ToSql(item.RESTRICT_ACCESS_ALERT_RECEIVED.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.RESTRICT_ACCESS_TYPE.IsEmpty Then
        allEmptyFlag = item.RESTRICT_ACCESS_TYPE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "RESTRICT_ACCESS_TYPE=" + Update.Dao.ToSql(item.RESTRICT_ACCESS_TYPE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RESTRICT_ACCESS_DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.RESTRICT_ACCESS_DESCRIPTION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "RESTRICT_ACCESS_DESCRIPTION=" + Update.Dao.ToSql(item.RESTRICT_ACCESS_DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RESTRICT_ACTIVITY_ALERT.IsEmpty Then
        allEmptyFlag = item.RESTRICT_ACTIVITY_ALERT.IsEmpty And allEmptyFlag
        valuesList = valuesList & "RESTRICT_ACTIVITY_ALERT=" + Update.Dao.ToSql(item.RESTRICT_ACTIVITY_ALERT.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.RESTRICT_ACTIVITY_DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.RESTRICT_ACTIVITY_DESCRIPTION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "RESTRICT_ACTIVITY_DESCRIPTION=" + Update.Dao.ToSql(item.RESTRICT_ACTIVITY_DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STUDENT_CENSUS_DATA1 BeforeBuildUpdate

'Record STUDENT_CENSUS_DATA1 AfterExecuteUpdate @133-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_CENSUS_DATA1 AfterExecuteUpdate

'Record STUDENT_CENSUS_DATA1 Data Provider Class GetResultSet Method @133-DAB72B33

    Public Sub FillItem(ByVal item As STUDENT_CENSUS_DATA1Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_CENSUS_DATA1 Data Provider Class GetResultSet Method

'Record STUDENT_CENSUS_DATA1 BeforeBuildSelect @133-0FE708FB
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID137",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_CENSUS_DATA1 BeforeBuildSelect

'Record STUDENT_CENSUS_DATA1 BeforeExecuteSelect @133-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_CENSUS_DATA1 BeforeExecuteSelect

'Record STUDENT_CENSUS_DATA1 AfterExecuteSelect @133-9DF74B19
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.RESTRICT_ACCESS_ATRISK.SetValue(dr(i)("RESTRICT_ACCESS_ATRISK"),Select_.BoolFormat)
            item.RESTRICT_ACCESS_ATRISK_DESCRIPTION.SetValue(dr(i)("RESTRICT_ACCESS_ATRISK_DESCRIPTION"),"")
            item.RESTRICT_ACCESS_ALERT.SetValue(dr(i)("RESTRICT_ACCESS_ALERT"),Select_.BoolFormat)
            item.RESTRICT_ACCESS_ALERT_RECEIVED.SetValue(dr(i)("RESTRICT_ACCESS_ALERT_RECEIVED"),Select_.BoolFormat)
            item.RESTRICT_ACCESS_TYPE.SetValue(dr(i)("RESTRICT_ACCESS_TYPE"),"")
            item.RESTRICT_ACCESS_DESCRIPTION.SetValue(dr(i)("RESTRICT_ACCESS_DESCRIPTION"),"")
            item.RESTRICT_ACTIVITY_ALERT.SetValue(dr(i)("RESTRICT_ACTIVITY_ALERT"),Select_.BoolFormat)
            item.RESTRICT_ACTIVITY_DESCRIPTION.SetValue(dr(i)("RESTRICT_ACTIVITY_DESCRIPTION"),"")
        Else
            IsInsertMode = True
        End If
'End Record STUDENT_CENSUS_DATA1 AfterExecuteSelect

'ListBox RESTRICT_ACCESS_ATRISK AfterExecuteSelect @140-8C8D6540
        
item.RESTRICT_ACCESS_ATRISKItems.Add("No","No")
item.RESTRICT_ACCESS_ATRISKItems.Add("Yes","Yes")
'End ListBox RESTRICT_ACCESS_ATRISK AfterExecuteSelect

'ListBox RESTRICT_ACCESS_ALERT AfterExecuteSelect @142-817C4E54
        
item.RESTRICT_ACCESS_ALERTItems.Add("No","No")
item.RESTRICT_ACCESS_ALERTItems.Add("Yes","Yes")
'End ListBox RESTRICT_ACCESS_ALERT AfterExecuteSelect

'ListBox RESTRICT_ACCESS_ALERT_RECEIVED AfterExecuteSelect @143-472C550E
        
item.RESTRICT_ACCESS_ALERT_RECEIVEDItems.Add("No","No")
item.RESTRICT_ACCESS_ALERT_RECEIVEDItems.Add("Yes","Yes")
'End ListBox RESTRICT_ACCESS_ALERT_RECEIVED AfterExecuteSelect

'ListBox RESTRICT_ACCESS_TYPE AfterExecuteSelect @144-BCF2331D
        
item.RESTRICT_ACCESS_TYPEItems.Add("Parenting Order","Parenting Order")
item.RESTRICT_ACCESS_TYPEItems.Add("Parenting Plan","Parenting Plan")
item.RESTRICT_ACCESS_TYPEItems.Add("Intervention Order","Intervention Order")
item.RESTRICT_ACCESS_TYPEItems.Add("Protection Order","Protection Order")
item.RESTRICT_ACCESS_TYPEItems.Add("Informal Carer Stat Dec","Informal Carer Stat Dec")
item.RESTRICT_ACCESS_TYPEItems.Add("DHHS Authorisation","DHHS Authorisation")
item.RESTRICT_ACCESS_TYPEItems.Add("Witness Protection Program Order","Witness Protection Program Order")
item.RESTRICT_ACCESS_TYPEItems.Add("Other","Other")
item.RESTRICT_ACCESS_TYPEItems.Add("None","None")
'End ListBox RESTRICT_ACCESS_TYPE AfterExecuteSelect

'ListBox RESTRICT_ACTIVITY_ALERT AfterExecuteSelect @146-599F8041
        
item.RESTRICT_ACTIVITY_ALERTItems.Add("No","No")
item.RESTRICT_ACTIVITY_ALERTItems.Add("Yes","Yes")
'End ListBox RESTRICT_ACTIVITY_ALERT AfterExecuteSelect

'Record STUDENT_CENSUS_DATA1 AfterExecuteSelect tail @133-E31F8E2A
    End Sub
'End Record STUDENT_CENSUS_DATA1 AfterExecuteSelect tail

'Record STUDENT_CENSUS_DATA1 Data Provider Class @133-A61BA892
End Class

'End Record STUDENT_CENSUS_DATA1 Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

