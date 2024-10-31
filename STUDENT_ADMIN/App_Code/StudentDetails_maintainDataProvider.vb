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

Namespace DECV_PROD2007.StudentDetails_maintain 'Namespace @1-65C4BA7C

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

'Record STUDENT Item Class @2-90476507
Public Class STUDENTItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public lblStudentID As TextField
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public MIDDLE_NAME As TextField
    Public BIRTH_DATE As DateField
    Public SEX As TextField
    Public SEXItems As ItemCollection
    Public ListBox_SubCategory As TextField
    Public ListBox_SubCategoryItems As ItemCollection
    Public ATTENDING_SCHOOL_ID As FloatField
    Public lblAttendingSchoolName As TextField
    Public HOME_SCHOOL_ID As FloatField
    Public lblHomeSchoolName As TextField
    Public CATEGORY_CODE As TextField
    Public SUBCATEGORY_CODE As TextField
    Public EnrolmentCategoryTemp As TextField
    Public hidden_old_ATTENDING_SCHOOL_ID As FloatField
    Public VSN As TextField
    Public PREFERRED_NAME As TextField
    Public ENROLLEDBEFORE As TextField
    Public link_showstudentfolder As TextField
    Public link_showstudentfolderHref As Object
    Public link_showstudentfolderHrefParameters As LinkParameterCollection
    Public hidden_DATE_STUDENTFOLDER_CREATED As DateField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public hidden_LAST_ALTERED_BY As TextField
    Public labelContactPCSupport As TextField
    Public hidden_LAST_ALTERED_DATE As DateField
    Public label_StudentFilesCreated As DateField
    Public list_REGION As TextField
    Public list_REGIONItems As ItemCollection
    Public VCE_CANDIDATE_NUMBER As TextField
    Public STUDENT_EMAIL As TextField
    Public STUDENT_MOBILE As TextField
    Public Hidden_CURR_RESID_ADDRESS_ID As TextField
    Public cbPORTAL_ACCESS As TextField
    Public cbPORTAL_ACCESSCheckedValue As TextField
    Public cbPORTAL_ACCESSUncheckedValue As TextField
    Public listORG_SCHOOL_ID As TextField
    Public listORG_SCHOOL_IDItems As ItemCollection
    Public SEX_SELF_DESCRIBED As TextField
    Public SEX_BIRTH As TextField
    Public SEX_BIRTHItems As ItemCollection
    Public PRONOUN_OTHER As TextField
    Public list_Pronoun As TextField
    Public list_PronounItems As ItemCollection
    Public Sub New()
    lblStudentID = New TextField("", Nothing)
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    MIDDLE_NAME = New TextField("", Nothing)
    BIRTH_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    SEX = New TextField("", Nothing)
    SEXItems = New ItemCollection()
    ListBox_SubCategory = New TextField("", Nothing)
    ListBox_SubCategoryItems = New ItemCollection()
    ATTENDING_SCHOOL_ID = New FloatField("#0.00", Nothing)
    lblAttendingSchoolName = New TextField("", Nothing)
    HOME_SCHOOL_ID = New FloatField("#0.00", Nothing)
    lblHomeSchoolName = New TextField("", Nothing)
    CATEGORY_CODE = New TextField("", Nothing)
    SUBCATEGORY_CODE = New TextField("", Nothing)
    EnrolmentCategoryTemp = New TextField("", Nothing)
    hidden_old_ATTENDING_SCHOOL_ID = New FloatField("#0.00", Nothing)
    VSN = New TextField("", Nothing)
    PREFERRED_NAME = New TextField("", Nothing)
    ENROLLEDBEFORE = New TextField("", Nothing)
    link_showstudentfolder = New TextField("",Nothing)
    link_showstudentfolderHrefParameters = New LinkParameterCollection()
    hidden_DATE_STUDENTFOLDER_CREATED = New DateField("yyyy-MM-dd H\:mm", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    hidden_LAST_ALTERED_BY = New TextField("", DBUtility.UserID.ToUpper)
    labelContactPCSupport = New TextField("", "<em>Contact PC Support for Student Files</em>")
    hidden_LAST_ALTERED_DATE = New DateField("yyyy-MM-dd H\:mm", DateTime.Now)
    label_StudentFilesCreated = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    list_REGION = New TextField("", Nothing)
    list_REGIONItems = New ItemCollection()
    VCE_CANDIDATE_NUMBER = New TextField("", Nothing)
    STUDENT_EMAIL = New TextField("", Nothing)
    STUDENT_MOBILE = New TextField("", Nothing)
    Hidden_CURR_RESID_ADDRESS_ID = New TextField("", Nothing)
    cbPORTAL_ACCESS = New TextField("", "Y")
    cbPORTAL_ACCESSCheckedValue = New TextField("", "Y")
    cbPORTAL_ACCESSUncheckedValue = New TextField("", "N")
    listORG_SCHOOL_ID = New TextField("", "0")
    listORG_SCHOOL_IDItems = New ItemCollection()
    SEX_SELF_DESCRIBED = New TextField("", Nothing)
    SEX_BIRTH = New TextField("", Nothing)
    SEX_BIRTHItems = New ItemCollection()
    PRONOUN_OTHER = New TextField("", Nothing)
    list_Pronoun = New TextField("", Nothing)
    list_PronounItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENTItem
        Dim item As STUDENTItem = New STUDENTItem()
        If Not IsNothing(DBUtility.GetInitialValue("lblStudentID")) Then
        item.lblStudentID.SetValue(DBUtility.GetInitialValue("lblStudentID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SURNAME")) Then
        item.SURNAME.SetValue(DBUtility.GetInitialValue("SURNAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FIRST_NAME")) Then
        item.FIRST_NAME.SetValue(DBUtility.GetInitialValue("FIRST_NAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MIDDLE_NAME")) Then
        item.MIDDLE_NAME.SetValue(DBUtility.GetInitialValue("MIDDLE_NAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("BIRTH_DATE")) Then
        item.BIRTH_DATE.SetValue(DBUtility.GetInitialValue("BIRTH_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DatePicker_BIRTH_DATE")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SEX")) Then
        item.SEX.SetValue(DBUtility.GetInitialValue("SEX"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ListBox_SubCategory")) Then
        item.ListBox_SubCategory.SetValue(DBUtility.GetInitialValue("ListBox_SubCategory"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ATTENDING_SCHOOL_ID")) Then
        item.ATTENDING_SCHOOL_ID.SetValue(DBUtility.GetInitialValue("ATTENDING_SCHOOL_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblAttendingSchoolName")) Then
        item.lblAttendingSchoolName.SetValue(DBUtility.GetInitialValue("lblAttendingSchoolName"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("HOME_SCHOOL_ID")) Then
        item.HOME_SCHOOL_ID.SetValue(DBUtility.GetInitialValue("HOME_SCHOOL_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblHomeSchoolName")) Then
        item.lblHomeSchoolName.SetValue(DBUtility.GetInitialValue("lblHomeSchoolName"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CATEGORY_CODE")) Then
        item.CATEGORY_CODE.SetValue(DBUtility.GetInitialValue("CATEGORY_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUBCATEGORY_CODE")) Then
        item.SUBCATEGORY_CODE.SetValue(DBUtility.GetInitialValue("SUBCATEGORY_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EnrolmentCategoryTemp")) Then
        item.EnrolmentCategoryTemp.SetValue(DBUtility.GetInitialValue("EnrolmentCategoryTemp"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_old_ATTENDING_SCHOOL_ID")) Then
        item.hidden_old_ATTENDING_SCHOOL_ID.SetValue(DBUtility.GetInitialValue("hidden_old_ATTENDING_SCHOOL_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("VSN")) Then
        item.VSN.SetValue(DBUtility.GetInitialValue("VSN"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PREFERRED_NAME")) Then
        item.PREFERRED_NAME.SetValue(DBUtility.GetInitialValue("PREFERRED_NAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLLEDBEFORE")) Then
        item.ENROLLEDBEFORE.SetValue(DBUtility.GetInitialValue("ENROLLEDBEFORE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("link_showstudentfolder")) Then
        item.link_showstudentfolder.SetValue(DBUtility.GetInitialValue("link_showstudentfolder"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_DATE_STUDENTFOLDER_CREATED")) Then
        item.hidden_DATE_STUDENTFOLDER_CREATED.SetValue(DBUtility.GetInitialValue("hidden_DATE_STUDENTFOLDER_CREATED"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY")) Then
        item.hidden_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("labelContactPCSupport")) Then
        item.labelContactPCSupport.SetValue(DBUtility.GetInitialValue("labelContactPCSupport"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_DATE")) Then
        item.hidden_LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_CreateStudentWorkFolder")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("label_StudentFilesCreated")) Then
        item.label_StudentFilesCreated.SetValue(DBUtility.GetInitialValue("label_StudentFilesCreated"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("list_REGION")) Then
        item.list_REGION.SetValue(DBUtility.GetInitialValue("list_REGION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("VCE_CANDIDATE_NUMBER")) Then
        item.VCE_CANDIDATE_NUMBER.SetValue(DBUtility.GetInitialValue("VCE_CANDIDATE_NUMBER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_EMAIL")) Then
        item.STUDENT_EMAIL.SetValue(DBUtility.GetInitialValue("STUDENT_EMAIL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_MOBILE")) Then
        item.STUDENT_MOBILE.SetValue(DBUtility.GetInitialValue("STUDENT_MOBILE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_CURR_RESID_ADDRESS_ID")) Then
        item.Hidden_CURR_RESID_ADDRESS_ID.SetValue(DBUtility.GetInitialValue("Hidden_CURR_RESID_ADDRESS_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("cbPORTAL_ACCESS")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("cbPORTAL_ACCESS")) Then
            item.cbPORTAL_ACCESS.Value = item.cbPORTAL_ACCESSCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("listORG_SCHOOL_ID")) Then
        item.listORG_SCHOOL_ID.SetValue(DBUtility.GetInitialValue("listORG_SCHOOL_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SEX_SELF_DESCRIBED")) Then
        item.SEX_SELF_DESCRIBED.SetValue(DBUtility.GetInitialValue("SEX_SELF_DESCRIBED"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SEX_BIRTH")) Then
        item.SEX_BIRTH.SetValue(DBUtility.GetInitialValue("SEX_BIRTH"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRONOUN_OTHER")) Then
        item.PRONOUN_OTHER.SetValue(DBUtility.GetInitialValue("PRONOUN_OTHER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("list_Pronoun")) Then
        item.list_Pronoun.SetValue(DBUtility.GetInitialValue("list_Pronoun"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "lblStudentID"
                    Return lblStudentID
                Case "SURNAME"
                    Return SURNAME
                Case "FIRST_NAME"
                    Return FIRST_NAME
                Case "MIDDLE_NAME"
                    Return MIDDLE_NAME
                Case "BIRTH_DATE"
                    Return BIRTH_DATE
                Case "SEX"
                    Return SEX
                Case "ListBox_SubCategory"
                    Return ListBox_SubCategory
                Case "ATTENDING_SCHOOL_ID"
                    Return ATTENDING_SCHOOL_ID
                Case "lblAttendingSchoolName"
                    Return lblAttendingSchoolName
                Case "HOME_SCHOOL_ID"
                    Return HOME_SCHOOL_ID
                Case "lblHomeSchoolName"
                    Return lblHomeSchoolName
                Case "CATEGORY_CODE"
                    Return CATEGORY_CODE
                Case "SUBCATEGORY_CODE"
                    Return SUBCATEGORY_CODE
                Case "EnrolmentCategoryTemp"
                    Return EnrolmentCategoryTemp
                Case "hidden_old_ATTENDING_SCHOOL_ID"
                    Return hidden_old_ATTENDING_SCHOOL_ID
                Case "VSN"
                    Return VSN
                Case "PREFERRED_NAME"
                    Return PREFERRED_NAME
                Case "ENROLLEDBEFORE"
                    Return ENROLLEDBEFORE
                Case "link_showstudentfolder"
                    Return link_showstudentfolder
                Case "hidden_DATE_STUDENTFOLDER_CREATED"
                    Return hidden_DATE_STUDENTFOLDER_CREATED
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "hidden_LAST_ALTERED_BY"
                    Return hidden_LAST_ALTERED_BY
                Case "labelContactPCSupport"
                    Return labelContactPCSupport
                Case "hidden_LAST_ALTERED_DATE"
                    Return hidden_LAST_ALTERED_DATE
                Case "label_StudentFilesCreated"
                    Return label_StudentFilesCreated
                Case "list_REGION"
                    Return list_REGION
                Case "VCE_CANDIDATE_NUMBER"
                    Return VCE_CANDIDATE_NUMBER
                Case "STUDENT_EMAIL"
                    Return STUDENT_EMAIL
                Case "STUDENT_MOBILE"
                    Return STUDENT_MOBILE
                Case "Hidden_CURR_RESID_ADDRESS_ID"
                    Return Hidden_CURR_RESID_ADDRESS_ID
                Case "cbPORTAL_ACCESS"
                    Return cbPORTAL_ACCESS
                Case "listORG_SCHOOL_ID"
                    Return listORG_SCHOOL_ID
                Case "SEX_SELF_DESCRIBED"
                    Return SEX_SELF_DESCRIBED
                Case "SEX_BIRTH"
                    Return SEX_BIRTH
                Case "PRONOUN_OTHER"
                    Return PRONOUN_OTHER
                Case "list_Pronoun"
                    Return list_Pronoun
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblStudentID"
                    lblStudentID = CType(value, TextField)
                Case "SURNAME"
                    SURNAME = CType(value, TextField)
                Case "FIRST_NAME"
                    FIRST_NAME = CType(value, TextField)
                Case "MIDDLE_NAME"
                    MIDDLE_NAME = CType(value, TextField)
                Case "BIRTH_DATE"
                    BIRTH_DATE = CType(value, DateField)
                Case "SEX"
                    SEX = CType(value, TextField)
                Case "ListBox_SubCategory"
                    ListBox_SubCategory = CType(value, TextField)
                Case "ATTENDING_SCHOOL_ID"
                    ATTENDING_SCHOOL_ID = CType(value, FloatField)
                Case "lblAttendingSchoolName"
                    lblAttendingSchoolName = CType(value, TextField)
                Case "HOME_SCHOOL_ID"
                    HOME_SCHOOL_ID = CType(value, FloatField)
                Case "lblHomeSchoolName"
                    lblHomeSchoolName = CType(value, TextField)
                Case "CATEGORY_CODE"
                    CATEGORY_CODE = CType(value, TextField)
                Case "SUBCATEGORY_CODE"
                    SUBCATEGORY_CODE = CType(value, TextField)
                Case "EnrolmentCategoryTemp"
                    EnrolmentCategoryTemp = CType(value, TextField)
                Case "hidden_old_ATTENDING_SCHOOL_ID"
                    hidden_old_ATTENDING_SCHOOL_ID = CType(value, FloatField)
                Case "VSN"
                    VSN = CType(value, TextField)
                Case "PREFERRED_NAME"
                    PREFERRED_NAME = CType(value, TextField)
                Case "ENROLLEDBEFORE"
                    ENROLLEDBEFORE = CType(value, TextField)
                Case "link_showstudentfolder"
                    link_showstudentfolder = CType(value, TextField)
                Case "hidden_DATE_STUDENTFOLDER_CREATED"
                    hidden_DATE_STUDENTFOLDER_CREATED = CType(value, DateField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "hidden_LAST_ALTERED_BY"
                    hidden_LAST_ALTERED_BY = CType(value, TextField)
                Case "labelContactPCSupport"
                    labelContactPCSupport = CType(value, TextField)
                Case "hidden_LAST_ALTERED_DATE"
                    hidden_LAST_ALTERED_DATE = CType(value, DateField)
                Case "label_StudentFilesCreated"
                    label_StudentFilesCreated = CType(value, DateField)
                Case "list_REGION"
                    list_REGION = CType(value, TextField)
                Case "VCE_CANDIDATE_NUMBER"
                    VCE_CANDIDATE_NUMBER = CType(value, TextField)
                Case "STUDENT_EMAIL"
                    STUDENT_EMAIL = CType(value, TextField)
                Case "STUDENT_MOBILE"
                    STUDENT_MOBILE = CType(value, TextField)
                Case "Hidden_CURR_RESID_ADDRESS_ID"
                    Hidden_CURR_RESID_ADDRESS_ID = CType(value, TextField)
                Case "cbPORTAL_ACCESS"
                    cbPORTAL_ACCESS = CType(value, TextField)
                Case "listORG_SCHOOL_ID"
                    listORG_SCHOOL_ID = CType(value, TextField)
                Case "SEX_SELF_DESCRIBED"
                    SEX_SELF_DESCRIBED = CType(value, TextField)
                Case "SEX_BIRTH"
                    SEX_BIRTH = CType(value, TextField)
                Case "PRONOUN_OTHER"
                    PRONOUN_OTHER = CType(value, TextField)
                Case "list_Pronoun"
                    list_Pronoun = CType(value, TextField)
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

'SURNAME validate @7-F35C1CC1
        If IsNothing(SURNAME.Value) OrElse SURNAME.Value.ToString() ="" Then
            errors.Add("SURNAME",String.Format(Resources.strings.CCS_RequiredField,"SURNAME"))
        End If
'End SURNAME validate

'FIRST_NAME validate @8-EF10D039
        If IsNothing(FIRST_NAME.Value) OrElse FIRST_NAME.Value.ToString() ="" Then
            errors.Add("FIRST_NAME",String.Format(Resources.strings.CCS_RequiredField,"FIRST NAME"))
        End If
'End FIRST_NAME validate

'BIRTH_DATE validate @10-F7B1D9DB
        If IsNothing(BIRTH_DATE.Value) OrElse BIRTH_DATE.Value.ToString() ="" Then
            errors.Add("BIRTH_DATE",String.Format(Resources.strings.CCS_RequiredField,"BIRTH DATE"))
        End If
        If (Not IsNothing(BIRTH_DATE.Value)) And (Not (DateDiff(DateInterval.Month,(BIRTH_DATE.Value),Today()) > 60)) Then
            errors.Add("BIRTH_DATE","The Date of Birth must be at least 5 years ago.")
        End If
'End BIRTH_DATE validate

'SEX validate @12-6CB9913B
        If IsNothing(SEX.Value) OrElse SEX.Value.ToString() ="" Then
            errors.Add("SEX",String.Format(Resources.strings.CCS_RequiredField,"SEX"))
        End If
        If (Not IsNothing(SEX.Value)) And (Not (((SEX.Value IsNot Nothing) AndAlso (Not SEX.Value.ToString().Equals("X"))) OrElse ((SEX_SELF_DESCRIBED.Value IsNot Nothing) AndAlso (SEX_SELF_DESCRIBED.Value.ToString().Trim().Length > 0)))) Then
            errors.Add("SEX","Self-described gender must be specified")
        End If
'End SEX validate

'ListBox_SubCategory validate @64-E175D8D5
        If IsNothing(ListBox_SubCategory.Value) OrElse ListBox_SubCategory.Value.ToString() ="" Then
            errors.Add("ListBox_SubCategory",String.Format(Resources.strings.CCS_RequiredField,"Category / SubCategory dropdown"))
        End If
'End ListBox_SubCategory validate

'TextBox ATTENDING_SCHOOL_ID Event OnValidate. Action Declare Variable @70-74945D1A
        Dim tmpATTENDINGCount As Int64 = -1
'End TextBox ATTENDING_SCHOOL_ID Event OnValidate. Action Declare Variable

'TextBox ATTENDING_SCHOOL_ID Event OnValidate. Action DLookup @68-38A93641
        tmpATTENDINGCount = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "count(SCHOOL_ID)" & " FROM " & "SCHOOL" & " WHERE " & "status=1 and school_type_code!='X' and SCHOOL_ID=" & ATTENDING_SCHOOL_ID.Value.ToString()))).Value, Int64)
'End TextBox ATTENDING_SCHOOL_ID Event OnValidate. Action DLookup

'TextBox ATTENDING_SCHOOL_ID Event OnValidate. Action Custom Code @69-73254650
    ' -------------------------
    'ERA: Aug 2008| if tmpATTENDINGCount <=0 then ATTENDING_SCHOOL_ID doesn't exist and raise error
	if tmpATTENDINGCount <=0 then
		errors.Add("ATTENDING_SCHOOL_ID",String.Format(Resources.strings.CCS_IncorrectValue,"ATTENDING SCHOOL ID"))
		errors.Add("ATTENDING_SCHOOL_ID","School ID is either inactive or not a valid school")
	end if

    ' -------------------------
'End TextBox ATTENDING_SCHOOL_ID Event OnValidate. Action Custom Code

'HOME_SCHOOL_ID validate @16-B37E3A03
        If IsNothing(HOME_SCHOOL_ID.Value) OrElse HOME_SCHOOL_ID.Value.ToString() ="" Then
            errors.Add("HOME_SCHOOL_ID",String.Format(Resources.strings.CCS_RequiredField,"HOME SCHOOL ID"))
        End If
'End HOME_SCHOOL_ID validate

'TextBox HOME_SCHOOL_ID Event OnValidate. Action Declare Variable @292-FEA0C570
        Dim tmpHOMECount As Int64 = -1
'End TextBox HOME_SCHOOL_ID Event OnValidate. Action Declare Variable

'TextBox HOME_SCHOOL_ID Event OnValidate. Action DLookup @293-617B1E4B
        tmpHOMECount = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "COUNT(*)" & " FROM " & "SCHOOL" & " WHERE " & "status=1 and school_type_code!='X' and SCHOOL_ID=" & HOME_SCHOOL_ID.Value.ToString()))).Value, Int64)
'End TextBox HOME_SCHOOL_ID Event OnValidate. Action DLookup

'TextBox HOME_SCHOOL_ID Event OnValidate. Action Custom Code @294-73254650
    ' -------------------------
	'ERA: Oct 2018| if tmpHOMECount <=0 then HOME_SCHOOL_ID doesn't exist and raise error
	if tmpHOMECount <=0 then
		errors.Add("HOME_SCHOOL_ID",String.Format(Resources.strings.CCS_IncorrectValue,"HOME_SCHOOL_ID"))
		errors.Add("HOME_SCHOOL_ID","School ID is either inactive or not a valid school")
	end if
    ' -------------------------
'End TextBox HOME_SCHOOL_ID Event OnValidate. Action Custom Code

'VCE_CANDIDATE_NUMBER validate @195-004018BF
		' -------------------------
		' 4-April-2011|EA| modified generated code to show put nicer message - must be unique in DB
        If (Not IsNothing(VCE_CANDIDATE_NUMBER)) And (Not provider.CheckUnique("VCE_CANDIDATE_NUMBER",Me)) Then
                errors.Add("VCE_CANDIDATE_NUMBER", String.Format("The VCE CANDIDATE NUMBER entered is already used by another Student.","VCE_CANDIDATE_NUMBER"))
        End If
        ' -------------------------
'End VCE_CANDIDATE_NUMBER validate

'TextBox VCE_CANDIDATE_NUMBER Event OnValidate. Action Regular Expression Validation @199-FFA45B11
        If Not (VCE_CANDIDATE_NUMBER.Value Is Nothing) Then
            Dim mask As Regex = New Regex("^\d{8}[a-zA-Z]$",RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            If Not(mask.Match(VCE_CANDIDATE_NUMBER.Value.ToString()).Success)
                errors.Add("VCE_CANDIDATE_NUMBER",String.Format("The VCE CANDIDATE NUMBER must be 8 digits then a letter (eg: 12345678A)","VCE_CANDIDATE_NUMBER"))
            End If
        End If
'End TextBox VCE_CANDIDATE_NUMBER Event OnValidate. Action Regular Expression Validation

'STUDENT_EMAIL validate @200-7C6E1912
        If IsNothing(STUDENT_EMAIL.Value) OrElse STUDENT_EMAIL.Value.ToString() ="" Then
            errors.Add("STUDENT_EMAIL",String.Format(Resources.strings.CCS_RequiredField,"STUDENT EMAIL ADDRESS"))
        End If
'End STUDENT_EMAIL validate

'TextBox STUDENT_EMAIL Event OnValidate. Action Regular Expression Validation @257-61FE2D0C
        If Not (STUDENT_EMAIL.Value Is Nothing) Then
            Dim mask As Regex = New Regex("^[\w\.\+-]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]+$",RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            If Not(mask.Match(STUDENT_EMAIL.Value.ToString()).Success)
                errors.Add("STUDENT_EMAIL",String.Format("The STUDENT Email Address is not a valid Email Address eg: bob.student@example.com","STUDENT EMAIL ADDRESS"))
            End If
        End If
'End TextBox STUDENT_EMAIL Event OnValidate. Action Regular Expression Validation

'TextBox STUDENT_MOBILE Event OnValidate. Action Regular Expression Validation @205-ABEE6F89
        If Not (STUDENT_MOBILE.Value Is Nothing) Then
            Dim mask As Regex = New Regex("(^04\d{2,3}[\s\-]{0,1}\d{3}[\s\-]{0,1}\d{3}$)|(^0011[\s\-]{0,1}[0-9]{7,12}$)",RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            If Not(mask.Match(STUDENT_MOBILE.Value.ToString()).Success)
                errors.Add("STUDENT_MOBILE",String.Format("STUDENT MOBILE Phone Number must be an Australian number, with numbers, spaces, or hyphens" & _
  " only. eg: 0412 345 678 or 0412-345-678, or International number starting with 0011...","STUDENT MOBILE"))
            End If
        End If
'End TextBox STUDENT_MOBILE Event OnValidate. Action Regular Expression Validation

'SEX_SELF_DESCRIBED validate @296-234041FC
        If (Not IsNothing(SEX_SELF_DESCRIBED.Value)) And (Not ((SEX.Value?.ToString().Equals("X")) OrElse (SEX_SELF_DESCRIBED.Value Is Nothing) OrElse (SEX_SELF_DESCRIBED.Value.ToString().Trim().Length = 0))) Then
            errors.Add("SEX_SELF_DESCRIBED","Self-described gender cannot be specified for male or female")
        End If
'End SEX_SELF_DESCRIBED validate

'RadioButton SEX_BIRTH Event OnValidate. Action Custom Code @356-73254650
		' 7 Oct 2021|RW| Validation to ensure that birth sex is captured when the student is a non-MF gender
        If ((SEX.Value?.ToString().Equals("X")) AndAlso (SEX_BIRTH.Value Is Nothing)) Then
            errors.Add("SEX_BIRTH", "Birth sex must be specified when Gender is self-described")
        End if
'End RadioButton SEX_BIRTH Event OnValidate. Action Custom Code

'PRONOUN_OTHER validate @358-D01A2FFD
		If list_Pronoun?.Value?.ToString().Equals("7") AndAlso String.IsNullOrWhiteSpace(PRONOUN_OTHER.Value)  Then
            errors.Add("PRONOUN_OTHER","Other pronouns must be specified when Other is selected")
        End If
'End PRONOUN_OTHER validate

'Record STUDENT Event OnValidate. Action Custom Code @190-73254650
    ' -------------------------
    '	'moved into a Custom Code section instead of amongst the BeforeUpdate where Vikas put it as it was mucking up the Codecharge Update code
		dim STUDENTVSN as string = VSN.getformattedvalue()

 			If STUDENTVSN <> "" Then
                'validate VSN Number with weight factor
                Dim arrVSN(8) As String
                Dim totalVSN As Integer
                Dim rmnder As Integer
                Dim wtFactor() As String = {"1", "4", "3", "7", "5", "8", "6", "9", "10"}

                For i As Integer = 0 To STUDENTVSN.length - 1
                    arrVSN(i) = Mid(STUDENTVSN, i + 1, 1)
                Next

                For i As Integer = 0 To 8
                    totalVSN = totalVSN + (CInt(arrVSN(i)) * CInt(wtFactor(i)))
                Next
                rmnder = totalVSN Mod 11
                If rmnder > 0 Then
					errors.Add("STUDENTVSN",String.Format(Resources.strings.CCS_IncorrectValue,"STUDENT VSN"))
                    'System.Web.UI.ClientScriptManager.RegisterStartupScript(Me.GetType, "error", "<script language='javascript'>alert('Invalid VSN Number')</script>")
                    'Exit Sub
					'
                    'Response.Write("Invalid VSN")
                End If
            End If
    ' -------------------------
'End Record STUDENT Event OnValidate. Action Custom Code


'Record STUDENT Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT Item Class tail

'Record STUDENT Data Provider Class @2-17C2BAE9
Public Class STUDENTDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT Data Provider Class

'Record STUDENT Data Provider Class Variables @2-E0000F8A
    Protected ListBox_SubCategoryDataCommand As DataCommand=new SqlCommand("select rtrim(SUBCATEGORY_FULL_TITLE) as SUBCATEGORY_FULL_TITLE from ENROLMENT_CATEGORY whe" & _
          "re STATUS=1 {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
    Protected list_REGIONDataCommand As DataCommand=new TableCommand("SELECT REGION_ID, REGION_NAME " & vbCrLf & _
          "FROM REGION {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected listORG_SCHOOL_IDDataCommand As DataCommand=new TableCommand("SELECT SCHOOL_ID, SCHOOL_NAME " & vbCrLf & _
          "FROM SCHOOL {SQL_Where} {SQL_OrderBy}", New String(){"expr260","And","expr261"},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected list_PronounDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM PRONOUN {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Public UrlSTUDENT_ID As FloatParameter
    Protected item As STUDENTItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT Data Provider Class Variables

'Record STUDENT Data Provider Class Constructor @2-5CCBF93A

    Public Sub New()
        Select_=new TableCommand("SELECT MIDDLE_NAME AS MIDDLE_NAME, STUDENT_ID, SURNAME AS SURNAME, " & vbCrLf & _
          "FIRST_NAME AS FIRST_NAME, BIRTH_DATE, SEX, CATEGORY_CODE, " & vbCrLf & _
          "SUBCATEGORY_CODE," & vbCrLf & _
          "ATTENDING_SCHOOL_ID, HOME_SCHOOL_ID, FULL_TIME, REGION, VSN, PREFERRED_NAME, ENROLLEDBEFOR" & _
          "E, " & vbCrLf & _
          "LAST_ALTERED_BY, LAST_ALTERED_DATE," & vbCrLf & _
          "DATE_STUDENTFOLDER_CREATED, VCE_CANDIDATE_NUMBER, " & vbCrLf & _
          "STUDENT_EMAIL, STUDENT_MOBILE, CURR_RESID_ADDRESS_ID, PORTAL_ACCESS, " & vbCrLf & _
          "ORGANISATION_SCHOOL_ID," & vbCrLf & _
          "SEX_SELF_DESCRIBED, SEX_BIRTH, PRONOUN_ID, " & vbCrLf & _
          "PRONOUN_OTHER " & vbCrLf & _
          "FROM STUDENT {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID360"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STUDENT Data Provider Class Constructor

'Record STUDENT Data Provider Class LoadParams Method @2-A977A0E9

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID))
    End Function
'End Record STUDENT Data Provider Class LoadParams Method

'Record STUDENT Data Provider Class CheckUnique Method @2-4E1D8561

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENTItem) As Boolean
        Dim Check As TableCommand = New TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STUDENT",New String(){"STUDENT_ID360"},Settings.connDECVPRODSQL2005DataAccessObject)
        Dim CheckWhere As String = ""
        Select Case ControlName
        Case "VCE_CANDIDATE_NUMBER"
            CheckWhere = "VCE_CANDIDATE_NUMBER=" & Check.Dao.ToSql(item.VCE_CANDIDATE_NUMBER.GetFormattedValue(""),FieldType._Text)
        End Select
        Check.Where = CheckWhere
        Check.Operation = "AND NOT"
        Check.Parameters.Clear()
        CType(Check,TableCommand).AddParameter("STUDENT_ID360",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        If Convert.ToInt32(Check.ExecuteScalar()) > 0 Then
            Return False
        End If
        Return True
    End Function
'End Record STUDENT Data Provider Class CheckUnique Method

'Record STUDENT Data Provider Class PrepareInsert Method @2-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STUDENT Data Provider Class PrepareInsert Method

'Record STUDENT Data Provider Class PrepareInsert Method tail @2-E31F8E2A
    End Sub
'End Record STUDENT Data Provider Class PrepareInsert Method tail

'Record STUDENT Data Provider Class Insert Method @2-D30B5F89

    Public Function InsertItem(ByVal item As STUDENTItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO STUDENT({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT Data Provider Class Insert Method

'Record STUDENT Build insert @2-588895E2
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.SURNAME.IsEmpty Then
        allEmptyFlag = item.SURNAME.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SURNAME,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SURNAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.FIRST_NAME.IsEmpty Then
        allEmptyFlag = item.FIRST_NAME.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "FIRST_NAME,"
        valuesList = valuesList & Insert.Dao.ToSql(item.FIRST_NAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.MIDDLE_NAME.IsEmpty Then
        allEmptyFlag = item.MIDDLE_NAME.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "MIDDLE_NAME,"
        valuesList = valuesList & Insert.Dao.ToSql(item.MIDDLE_NAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.BIRTH_DATE.IsEmpty Then
        allEmptyFlag = item.BIRTH_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "BIRTH_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.BIRTH_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.SEX.IsEmpty Then
        allEmptyFlag = item.SEX.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SEX,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SEX.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ATTENDING_SCHOOL_ID.IsEmpty Then
        allEmptyFlag = item.ATTENDING_SCHOOL_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ATTENDING_SCHOOL_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ATTENDING_SCHOOL_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.HOME_SCHOOL_ID.IsEmpty Then
        allEmptyFlag = item.HOME_SCHOOL_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "HOME_SCHOOL_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.HOME_SCHOOL_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.CATEGORY_CODE.IsEmpty Then
        allEmptyFlag = item.CATEGORY_CODE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CATEGORY_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CATEGORY_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUBCATEGORY_CODE.IsEmpty Then
        allEmptyFlag = item.SUBCATEGORY_CODE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUBCATEGORY_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUBCATEGORY_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.VSN.IsEmpty Then
        allEmptyFlag = item.VSN.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "VSN,"
        valuesList = valuesList & Insert.Dao.ToSql(item.VSN.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PREFERRED_NAME.IsEmpty Then
        allEmptyFlag = item.PREFERRED_NAME.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PREFERRED_NAME,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PREFERRED_NAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ENROLLEDBEFORE.IsEmpty Then
        allEmptyFlag = item.ENROLLEDBEFORE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ENROLLEDBEFORE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ENROLLEDBEFORE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_DATE_STUDENTFOLDER_CREATED.IsEmpty Then
        allEmptyFlag = item.hidden_DATE_STUDENTFOLDER_CREATED.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "DATE_STUDENTFOLDER_CREATED,"
        valuesList = valuesList & Insert.Dao.ToSql(item.hidden_DATE_STUDENTFOLDER_CREATED.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.hidden_LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.hidden_LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.hidden_LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.hidden_LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.hidden_LAST_ALTERED_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.list_REGION.IsEmpty Then
        allEmptyFlag = item.list_REGION.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "REGION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.list_REGION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.VCE_CANDIDATE_NUMBER.IsEmpty Then
        allEmptyFlag = item.VCE_CANDIDATE_NUMBER.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "VCE_CANDIDATE_NUMBER,"
        valuesList = valuesList & Insert.Dao.ToSql(item.VCE_CANDIDATE_NUMBER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STUDENT_EMAIL.IsEmpty Then
        allEmptyFlag = item.STUDENT_EMAIL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STUDENT_EMAIL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STUDENT_EMAIL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STUDENT_MOBILE.IsEmpty Then
        allEmptyFlag = item.STUDENT_MOBILE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STUDENT_MOBILE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STUDENT_MOBILE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_CURR_RESID_ADDRESS_ID.IsEmpty Then
        allEmptyFlag = item.Hidden_CURR_RESID_ADDRESS_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CURR_RESID_ADDRESS_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_CURR_RESID_ADDRESS_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.cbPORTAL_ACCESS.IsEmpty Then
        allEmptyFlag = item.cbPORTAL_ACCESS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PORTAL_ACCESS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.cbPORTAL_ACCESS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.listORG_SCHOOL_ID.IsEmpty Then
        allEmptyFlag = item.listORG_SCHOOL_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ORGANISATION_SCHOOL_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.listORG_SCHOOL_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SEX_SELF_DESCRIBED.IsEmpty Then
        allEmptyFlag = item.SEX_SELF_DESCRIBED.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SEX_SELF_DESCRIBED,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SEX_SELF_DESCRIBED.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SEX_BIRTH.IsEmpty Then
        allEmptyFlag = item.SEX_BIRTH.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SEX_BIRTH,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SEX_BIRTH.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PRONOUN_OTHER.IsEmpty Then
        allEmptyFlag = item.PRONOUN_OTHER.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PRONOUN_OTHER,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PRONOUN_OTHER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.list_Pronoun.IsEmpty Then
        allEmptyFlag = item.list_Pronoun.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PRONOUN_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.list_Pronoun.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STUDENT Build insert

'Record STUDENT Event AfterExecuteInsert. Action Custom Code @207-73254650
    ' -------------------------
    ' ERA: and automatically update the Current Resid Email Address and mobile
 	' 21 Jan 2021|RW| Add clause to prevent student emails (and phone!) from overwriting the school's, where the IDs are linked
 	'                 See SD IDs 28523 and 28540
	If Not item.Hidden_CURR_RESID_ADDRESS_ID.IsEmpty Then
		Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
  		Dim Sql As String = "UPDATE ADDRESS SET EMAIL_ADDRESS= "& NewDao.ToSql(item.STUDENT_EMAIL.GetFormattedValue(""),FieldType._Text) &", PHONE_B= "& NewDao.ToSql(item.STUDENT_MOBILE.GetFormattedValue(""),FieldType._Text) &" WHERE ADDRESS_ID = " & NewDao.ToSql(item.Hidden_CURR_RESID_ADDRESS_ID.GetFormattedValue(""),FieldType._Text) & " and not exists (select * from school as sch where (sch.ADDRESS_ID = ADDRESS.ADDRESS_ID));"
  		NewDao.RunSql(Sql)
	End If
    ' -------------------------
'End Record STUDENT Event AfterExecuteInsert. Action Custom Code

'Record STUDENT AfterExecuteInsert @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT AfterExecuteInsert

'Record STUDENT Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STUDENT Data Provider Class PrepareUpdate Method

'Record STUDENT Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record STUDENT Data Provider Class PrepareUpdate Method tail

'Record STUDENT Data Provider Class Update Method @2-DF1BF5CA

    Public Function UpdateItem(ByVal item As STUDENTItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT SET {Values}", New String(){"STUDENT_ID360"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT Data Provider Class Update Method

'LG|24/04/2023| Before updating, clear the "Other" field for pronouns, unless other is selected from dropdown
if item.list_Pronoun.Value <> "7"
	item.Pronoun_Other.SetValue(String.Empty)
end if

'Record STUDENT BeforeBuildUpdate @2-2D7D72AF
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID360",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        If Not item.SURNAME.IsEmpty Then
        allEmptyFlag = item.SURNAME.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SURNAME=" + Update.Dao.ToSql(item.SURNAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.FIRST_NAME.IsEmpty Then
        allEmptyFlag = item.FIRST_NAME.IsEmpty And allEmptyFlag
        valuesList = valuesList & "FIRST_NAME=" + Update.Dao.ToSql(item.FIRST_NAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.MIDDLE_NAME.IsEmpty Then
        allEmptyFlag = item.MIDDLE_NAME.IsEmpty And allEmptyFlag
        valuesList = valuesList & "MIDDLE_NAME=" + Update.Dao.ToSql(item.MIDDLE_NAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.BIRTH_DATE.IsEmpty Then
        allEmptyFlag = item.BIRTH_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "BIRTH_DATE=" + Update.Dao.ToSql(item.BIRTH_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.SEX.IsEmpty Then
        allEmptyFlag = item.SEX.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SEX=" + Update.Dao.ToSql(item.SEX.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ATTENDING_SCHOOL_ID.IsEmpty Then
        allEmptyFlag = item.ATTENDING_SCHOOL_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ATTENDING_SCHOOL_ID=" + Update.Dao.ToSql(item.ATTENDING_SCHOOL_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.HOME_SCHOOL_ID.IsEmpty Then
        allEmptyFlag = item.HOME_SCHOOL_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "HOME_SCHOOL_ID=" + Update.Dao.ToSql(item.HOME_SCHOOL_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.CATEGORY_CODE.IsEmpty Then
        allEmptyFlag = item.CATEGORY_CODE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CATEGORY_CODE=" + Update.Dao.ToSql(item.CATEGORY_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUBCATEGORY_CODE.IsEmpty Then
        allEmptyFlag = item.SUBCATEGORY_CODE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUBCATEGORY_CODE=" + Update.Dao.ToSql(item.SUBCATEGORY_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.VSN.IsEmpty Then
        allEmptyFlag = item.VSN.IsEmpty And allEmptyFlag
        valuesList = valuesList & "VSN=" + Update.Dao.ToSql(item.VSN.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PREFERRED_NAME.IsEmpty Then
        allEmptyFlag = item.PREFERRED_NAME.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PREFERRED_NAME=" + Update.Dao.ToSql(item.PREFERRED_NAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ENROLLEDBEFORE.IsEmpty Then
        allEmptyFlag = item.ENROLLEDBEFORE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ENROLLEDBEFORE=" + Update.Dao.ToSql(item.ENROLLEDBEFORE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_DATE_STUDENTFOLDER_CREATED.IsEmpty Then
        allEmptyFlag = item.hidden_DATE_STUDENTFOLDER_CREATED.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DATE_STUDENTFOLDER_CREATED=" + Update.Dao.ToSql(item.hidden_DATE_STUDENTFOLDER_CREATED.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.hidden_LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.hidden_LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.hidden_LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.hidden_LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.hidden_LAST_ALTERED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.list_REGION.IsEmpty Then
        allEmptyFlag = item.list_REGION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "REGION=" + Update.Dao.ToSql(item.list_REGION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.VCE_CANDIDATE_NUMBER.IsEmpty Then
        allEmptyFlag = item.VCE_CANDIDATE_NUMBER.IsEmpty And allEmptyFlag
        valuesList = valuesList & "VCE_CANDIDATE_NUMBER=" + Update.Dao.ToSql(item.VCE_CANDIDATE_NUMBER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STUDENT_EMAIL.IsEmpty Then
        allEmptyFlag = item.STUDENT_EMAIL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STUDENT_EMAIL=" + Update.Dao.ToSql(item.STUDENT_EMAIL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STUDENT_MOBILE.IsEmpty Then
        allEmptyFlag = item.STUDENT_MOBILE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STUDENT_MOBILE=" + Update.Dao.ToSql(item.STUDENT_MOBILE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_CURR_RESID_ADDRESS_ID.IsEmpty Then
        allEmptyFlag = item.Hidden_CURR_RESID_ADDRESS_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CURR_RESID_ADDRESS_ID=" + Update.Dao.ToSql(item.Hidden_CURR_RESID_ADDRESS_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.cbPORTAL_ACCESS.IsEmpty Then
        allEmptyFlag = item.cbPORTAL_ACCESS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PORTAL_ACCESS=" + Update.Dao.ToSql(item.cbPORTAL_ACCESS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.listORG_SCHOOL_ID.IsEmpty Then
        allEmptyFlag = item.listORG_SCHOOL_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ORGANISATION_SCHOOL_ID=" + Update.Dao.ToSql(item.listORG_SCHOOL_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SEX_SELF_DESCRIBED.IsEmpty Then
        allEmptyFlag = item.SEX_SELF_DESCRIBED.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SEX_SELF_DESCRIBED=" + Update.Dao.ToSql(item.SEX_SELF_DESCRIBED.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SEX_BIRTH.IsEmpty Then
        allEmptyFlag = item.SEX_BIRTH.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SEX_BIRTH=" + Update.Dao.ToSql(item.SEX_BIRTH.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PRONOUN_OTHER.IsEmpty Then
        allEmptyFlag = item.PRONOUN_OTHER.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRONOUN_OTHER=" + Update.Dao.ToSql(item.PRONOUN_OTHER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.list_Pronoun.IsEmpty Then
        allEmptyFlag = item.list_Pronoun.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRONOUN_ID=" + Update.Dao.ToSql(item.list_Pronoun.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STUDENT BeforeBuildUpdate

'Record STUDENT Event AfterExecuteUpdate. Action Custom Code @210-73254650
    ' -------------------------
 	' ERA: and automatically update the Current Resid Email Address and mobile
 	' 21 Jan 2021|RW| Add clause to prevent student emails (and phone!) from overwriting the school's, where the IDs are linked
 	'                 See SD IDs 28523 and 28540
	If Not item.Hidden_CURR_RESID_ADDRESS_ID.IsEmpty Then
		Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
  		Dim Sql As String = "UPDATE ADDRESS SET EMAIL_ADDRESS= "& NewDao.ToSql(item.STUDENT_EMAIL.GetFormattedValue(""),FieldType._Text) &", PHONE_B= "& NewDao.ToSql(item.STUDENT_MOBILE.GetFormattedValue(""),FieldType._Text) &" WHERE ADDRESS_ID = " & NewDao.ToSql(item.Hidden_CURR_RESID_ADDRESS_ID.GetFormattedValue(""),FieldType._Text) & " and not exists (select * from school as sch where (sch.ADDRESS_ID = ADDRESS.ADDRESS_ID));"
  		NewDao.RunSql(Sql)
	End If
    ' -------------------------
'End Record STUDENT Event AfterExecuteUpdate. Action Custom Code

                'Record STUDENT AfterExecuteUpdate @2-2FB4FB62
                If Not IsNothing(E) Then Throw E
            End Try
            Return CType(result, Integer)
    End Function
'End Record STUDENT AfterExecuteUpdate

'Record STUDENT Data Provider Class GetResultSet Method @2-BE21EA83

    Public Sub FillItem(ByVal item As STUDENTItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT Data Provider Class GetResultSet Method

'Record STUDENT BeforeBuildSelect @2-0E202180
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID360",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT BeforeBuildSelect

'Record STUDENT BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT BeforeExecuteSelect

'Record STUDENT AfterExecuteSelect @2-0C686916
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.lblStudentID.SetValue(dr(i)("STUDENT_ID"),"")
            item.SURNAME.SetValue(dr(i)("SURNAME"),"")
            item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
            item.MIDDLE_NAME.SetValue(dr(i)("MIDDLE_NAME"),"")
            item.BIRTH_DATE.SetValue(dr(i)("BIRTH_DATE"),Select_.DateFormat)
            item.SEX.SetValue(dr(i)("SEX"),"")
            item.ATTENDING_SCHOOL_ID.SetValue(dr(i)("ATTENDING_SCHOOL_ID"),"")
            item.HOME_SCHOOL_ID.SetValue(dr(i)("HOME_SCHOOL_ID"),"")
            item.CATEGORY_CODE.SetValue(dr(i)("CATEGORY_CODE"),"")
            item.SUBCATEGORY_CODE.SetValue(dr(i)("SUBCATEGORY_CODE"),"")
            item.VSN.SetValue(dr(i)("VSN"),"")
            item.PREFERRED_NAME.SetValue(dr(i)("PREFERRED_NAME"),"")
            item.ENROLLEDBEFORE.SetValue(dr(i)("ENROLLEDBEFORE"),"")
            item.link_showstudentfolderHref = ""
            item.hidden_DATE_STUDENTFOLDER_CREATED.SetValue(dr(i)("DATE_STUDENTFOLDER_CREATED"),Select_.DateFormat)
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.hidden_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.hidden_LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.label_StudentFilesCreated.SetValue(dr(i)("DATE_STUDENTFOLDER_CREATED"),Select_.DateFormat)
            item.list_REGION.SetValue(dr(i)("REGION"),"")
            item.VCE_CANDIDATE_NUMBER.SetValue(dr(i)("VCE_CANDIDATE_NUMBER"),"")
            item.STUDENT_EMAIL.SetValue(dr(i)("STUDENT_EMAIL"),"")
            item.STUDENT_MOBILE.SetValue(dr(i)("STUDENT_MOBILE"),"")
            item.Hidden_CURR_RESID_ADDRESS_ID.SetValue(dr(i)("CURR_RESID_ADDRESS_ID"),"")
            item.cbPORTAL_ACCESS.SetValue(dr(i)("PORTAL_ACCESS"),"")
            item.listORG_SCHOOL_ID.SetValue(dr(i)("ORGANISATION_SCHOOL_ID"),"")
            item.SEX_SELF_DESCRIBED.SetValue(dr(i)("SEX_SELF_DESCRIBED"),"")
            item.SEX_BIRTH.SetValue(dr(i)("SEX_BIRTH"),"")
            item.PRONOUN_OTHER.SetValue(dr(i)("PRONOUN_OTHER"),"")
            item.list_Pronoun.SetValue(dr(i)("PRONOUN_ID"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record STUDENT AfterExecuteSelect

'ListBox SEX AfterExecuteSelect @12-61AF9CE2
        
item.SEXItems.Add("F","Female")
item.SEXItems.Add("M","Male")
item.SEXItems.Add("X","Self-described")
'End ListBox SEX AfterExecuteSelect

'ListBox ListBox_SubCategory Initialize Data Source @64-EBEBFF52
        ListBox_SubCategoryDataCommand.Dao._optimized = False
        Dim ListBox_SubCategorytableIndex As Integer = 0
        ListBox_SubCategoryDataCommand.OrderBy = "rtrim(SUBCATEGORY_FULL_TITLE)"
        ListBox_SubCategoryDataCommand.Parameters.Clear()
'End ListBox ListBox_SubCategory Initialize Data Source

'ListBox ListBox_SubCategory BeforeExecuteSelect @64-3221252B
        Try
            ListBoxSource=ListBox_SubCategoryDataCommand.Execute().Tables(ListBox_SubCategorytableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox ListBox_SubCategory BeforeExecuteSelect

'ListBox ListBox_SubCategory AfterExecuteSelect @64-98DE4C77
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("SUBCATEGORY_FULL_TITLE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("SUBCATEGORY_FULL_TITLE")
            item.ListBox_SubCategoryItems.Add(Key, Val)
        Next
'End ListBox ListBox_SubCategory AfterExecuteSelect

'ListBox list_REGION Initialize Data Source @74-78135F8C
        list_REGIONDataCommand.Dao._optimized = False
        Dim list_REGIONtableIndex As Integer = 0
        list_REGIONDataCommand.OrderBy = "REGION_NAME"
        list_REGIONDataCommand.Parameters.Clear()
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

'ListBox listORG_SCHOOL_ID Initialize Data Source @258-C4B54AFD
        listORG_SCHOOL_IDDataCommand.Dao._optimized = False
        Dim listORG_SCHOOL_IDtableIndex As Integer = 0
        listORG_SCHOOL_IDDataCommand.OrderBy = "SCHOOL_NAME"
        listORG_SCHOOL_IDDataCommand.Parameters.Clear()
        listORG_SCHOOL_IDDataCommand.Parameters.Add("expr260","(status=1)")
        listORG_SCHOOL_IDDataCommand.Parameters.Add("expr261","(SCHOOL_TYPE_CODE ='X')")
'End ListBox listORG_SCHOOL_ID Initialize Data Source

'ListBox listORG_SCHOOL_ID BeforeExecuteSelect @258-F5E25BE2
        Try
            ListBoxSource=listORG_SCHOOL_IDDataCommand.Execute().Tables(listORG_SCHOOL_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox listORG_SCHOOL_ID BeforeExecuteSelect

'ListBox listORG_SCHOOL_ID AfterExecuteSelect @258-A91B30B5
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("SCHOOL_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("SCHOOL_NAME")
            item.listORG_SCHOOL_IDItems.Add(Key, Val)
        Next
'End ListBox listORG_SCHOOL_ID AfterExecuteSelect

'ListBox SEX_BIRTH AfterExecuteSelect @326-49E5FD0F
        
item.SEX_BIRTHItems.Add("F","Female")
item.SEX_BIRTHItems.Add("M","Male")
'End ListBox SEX_BIRTH AfterExecuteSelect

'ListBox list_Pronoun Initialize Data Source @357-A0F3AF6C
        list_PronounDataCommand.Dao._optimized = False
        Dim list_PronountableIndex As Integer = 0
        list_PronounDataCommand.OrderBy = ""
        list_PronounDataCommand.Parameters.Clear()
'End ListBox list_Pronoun Initialize Data Source

'ListBox list_Pronoun BeforeExecuteSelect @357-F21F06A7
        Try
            ListBoxSource=list_PronounDataCommand.Execute().Tables(list_PronountableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox list_Pronoun BeforeExecuteSelect

'ListBox list_Pronoun AfterExecuteSelect @357-48F7F5AD
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("PRONOUN_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("PRONOUN_NAME")
            item.list_PronounItems.Add(Key, Val)
        Next
'End ListBox list_Pronoun AfterExecuteSelect

'Record STUDENT AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record STUDENT AfterExecuteSelect tail

'Record STUDENT Data Provider Class @2-A61BA892
End Class

'End Record STUDENT Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

