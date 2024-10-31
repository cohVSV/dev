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

Namespace DECV_PROD2007.FutureEnrol_StudentMaintain 'Namespace @1-DFE5374F

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

'Record STUDENT Item Class @3-B14281FA
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
    Public hidden_DATE_STUDENTFOLDER_CREATED As DateField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public hidden_LAST_ALTERED_BY As TextField
    Public hidden_LAST_ALTERED_DATE As DateField
    Public STUDENT_EMAIL As TextField
    Public STUDENT_MOBILE As TextField
    Public Hidden_CURR_RESID_ADDRESS_ID As TextField
    Public listORG_SCHOOL_ID As TextField
    Public listORG_SCHOOL_IDItems As ItemCollection
    Public VCE_CANDIDATE_NUMBER As TextField
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
    ATTENDING_SCHOOL_ID = New FloatField("#0.00", 16261.00)
    lblAttendingSchoolName = New TextField("", Nothing)
    HOME_SCHOOL_ID = New FloatField("#0.00", 16261.00)
    lblHomeSchoolName = New TextField("", Nothing)
    CATEGORY_CODE = New TextField("", Nothing)
    SUBCATEGORY_CODE = New TextField("", Nothing)
    EnrolmentCategoryTemp = New TextField("", Nothing)
    hidden_old_ATTENDING_SCHOOL_ID = New FloatField("#0.00", Nothing)
    VSN = New TextField("", Nothing)
    PREFERRED_NAME = New TextField("", Nothing)
    ENROLLEDBEFORE = New TextField("", Nothing)
    hidden_DATE_STUDENTFOLDER_CREATED = New DateField("yyyy-MM-dd H\:mm", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    hidden_LAST_ALTERED_BY = New TextField("", DBUtility.UserID.ToUpper)
    hidden_LAST_ALTERED_DATE = New DateField("yyyy-MM-dd H\:mm", DateTime.Now)
    STUDENT_EMAIL = New TextField("", Nothing)
    STUDENT_MOBILE = New TextField("", Nothing)
    Hidden_CURR_RESID_ADDRESS_ID = New TextField("", Nothing)
    listORG_SCHOOL_ID = New TextField("", "0")
    listORG_SCHOOL_IDItems = New ItemCollection()
    VCE_CANDIDATE_NUMBER = New TextField("", Nothing)
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
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_DATE")) Then
        item.hidden_LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_DATE"))
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
        If Not IsNothing(DBUtility.GetInitialValue("listORG_SCHOOL_ID")) Then
        item.listORG_SCHOOL_ID.SetValue(DBUtility.GetInitialValue("listORG_SCHOOL_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("VCE_CANDIDATE_NUMBER")) Then
        item.VCE_CANDIDATE_NUMBER.SetValue(DBUtility.GetInitialValue("VCE_CANDIDATE_NUMBER"))
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
                Case "hidden_DATE_STUDENTFOLDER_CREATED"
                    Return hidden_DATE_STUDENTFOLDER_CREATED
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "hidden_LAST_ALTERED_BY"
                    Return hidden_LAST_ALTERED_BY
                Case "hidden_LAST_ALTERED_DATE"
                    Return hidden_LAST_ALTERED_DATE
                Case "STUDENT_EMAIL"
                    Return STUDENT_EMAIL
                Case "STUDENT_MOBILE"
                    Return STUDENT_MOBILE
                Case "Hidden_CURR_RESID_ADDRESS_ID"
                    Return Hidden_CURR_RESID_ADDRESS_ID
                Case "listORG_SCHOOL_ID"
                    Return listORG_SCHOOL_ID
                Case "VCE_CANDIDATE_NUMBER"
                    Return VCE_CANDIDATE_NUMBER
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
                Case "hidden_DATE_STUDENTFOLDER_CREATED"
                    hidden_DATE_STUDENTFOLDER_CREATED = CType(value, DateField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "hidden_LAST_ALTERED_BY"
                    hidden_LAST_ALTERED_BY = CType(value, TextField)
                Case "hidden_LAST_ALTERED_DATE"
                    hidden_LAST_ALTERED_DATE = CType(value, DateField)
                Case "STUDENT_EMAIL"
                    STUDENT_EMAIL = CType(value, TextField)
                Case "STUDENT_MOBILE"
                    STUDENT_MOBILE = CType(value, TextField)
                Case "Hidden_CURR_RESID_ADDRESS_ID"
                    Hidden_CURR_RESID_ADDRESS_ID = CType(value, TextField)
                Case "listORG_SCHOOL_ID"
                    listORG_SCHOOL_ID = CType(value, TextField)
                Case "VCE_CANDIDATE_NUMBER"
                    VCE_CANDIDATE_NUMBER = CType(value, TextField)
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

'SURNAME validate @5-F35C1CC1
        If IsNothing(SURNAME.Value) OrElse SURNAME.Value.ToString() ="" Then
            errors.Add("SURNAME",String.Format(Resources.strings.CCS_RequiredField,"SURNAME"))
        End If
'End SURNAME validate

'FIRST_NAME validate @7-EF10D039
        If IsNothing(FIRST_NAME.Value) OrElse FIRST_NAME.Value.ToString() ="" Then
            errors.Add("FIRST_NAME",String.Format(Resources.strings.CCS_RequiredField,"FIRST NAME"))
        End If
'End FIRST_NAME validate

'BIRTH_DATE validate @11-F7B1D9DB
        If IsNothing(BIRTH_DATE.Value) OrElse BIRTH_DATE.Value.ToString() ="" Then
            errors.Add("BIRTH_DATE",String.Format(Resources.strings.CCS_RequiredField,"BIRTH DATE"))
        End If
        If (Not IsNothing(BIRTH_DATE.Value)) And (Not (DateDiff(DateInterval.Month,(BIRTH_DATE.Value),Today()) > 60)) Then
            errors.Add("BIRTH_DATE","The Date of Birth must be at least 5 years ago.")
        End If
'End BIRTH_DATE validate

'TextBox BIRTH_DATE Event OnValidate. Action Custom Code @220-73254650
    ' -------------------------
    'Nov-2018|EA| also check for maximum of 99 years old
    If (Not IsNothing(BIRTH_DATE.Value)) And (Not (DateDiff(DateInterval.Year,(BIRTH_DATE.Value),Today()) < 99)) Then
            errors.Add("BIRTH_DATE","Check Date of Birth - appears to be over 99 years old!")
    End If
    ' -------------------------
'End TextBox BIRTH_DATE Event OnValidate. Action Custom Code

'SEX validate @13-A922A5B7
        If IsNothing(SEX.Value) OrElse SEX.Value.ToString() ="" Then
            errors.Add("SEX",String.Format(Resources.strings.CCS_RequiredField,"SEX"))
        End If
'End SEX validate

'ListBox_SubCategory validate @14-E175D8D5
        If IsNothing(ListBox_SubCategory.Value) OrElse ListBox_SubCategory.Value.ToString() ="" Then
            errors.Add("ListBox_SubCategory",String.Format(Resources.strings.CCS_RequiredField,"Category / SubCategory dropdown"))
        End If
'End ListBox_SubCategory validate

'TextBox ATTENDING_SCHOOL_ID Event OnValidate. Action Declare Variable @16-74945D1A
        Dim tmpATTENDINGCount As Int64 = -1
'End TextBox ATTENDING_SCHOOL_ID Event OnValidate. Action Declare Variable

'TextBox ATTENDING_SCHOOL_ID Event OnValidate. Action DLookup @17-38A93641
        tmpATTENDINGCount = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "count(SCHOOL_ID)" & " FROM " & "SCHOOL" & " WHERE " & "status=1 and school_type_code!='X' and SCHOOL_ID=" & ATTENDING_SCHOOL_ID.Value.ToString()))).Value, Int64)
'End TextBox ATTENDING_SCHOOL_ID Event OnValidate. Action DLookup

'TextBox ATTENDING_SCHOOL_ID Event OnValidate. Action Custom Code @18-73254650
    ' -------------------------
    'ERA: Aug 2008| if tmpATTENDINGCount <=0 then ATTENDING_SCHOOL_ID doesn't exist and raise error
	if tmpATTENDINGCount <=0 then
		errors.Add("ATTENDING_SCHOOL_ID",String.Format(Resources.strings.CCS_IncorrectValue,"ATTENDING SCHOOL ID"))
		errors.Add("ATTENDING_SCHOOL_ID","School ID is either inactive or not a valid school")
	end if

    ' -------------------------
'End TextBox ATTENDING_SCHOOL_ID Event OnValidate. Action Custom Code

'HOME_SCHOOL_ID validate @20-B37E3A03
        If IsNothing(HOME_SCHOOL_ID.Value) OrElse HOME_SCHOOL_ID.Value.ToString() ="" Then
            errors.Add("HOME_SCHOOL_ID",String.Format(Resources.strings.CCS_RequiredField,"HOME SCHOOL ID"))
        End If
'End HOME_SCHOOL_ID validate

'TextBox HOME_SCHOOL_ID Event OnValidate. Action Declare Variable @21-FEA0C570
        Dim tmpHOMECount As Int64 = -1
'End TextBox HOME_SCHOOL_ID Event OnValidate. Action Declare Variable

'TextBox HOME_SCHOOL_ID Event OnValidate. Action DLookup @22-617B1E4B
        tmpHOMECount = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "COUNT(*)" & " FROM " & "SCHOOL" & " WHERE " & "status=1 and school_type_code!='X' and SCHOOL_ID=" & HOME_SCHOOL_ID.Value.ToString()))).Value, Int64)
'End TextBox HOME_SCHOOL_ID Event OnValidate. Action DLookup

'TextBox HOME_SCHOOL_ID Event OnValidate. Action Custom Code @23-73254650
    ' -------------------------
	'ERA: Oct 2018| if tmpHOMECount <=0 then HOME_SCHOOL_ID doesn't exist and raise error
	if tmpHOMECount <=0 then
		errors.Add("HOME_SCHOOL_ID",String.Format(Resources.strings.CCS_IncorrectValue,"HOME_SCHOOL_ID"))
		errors.Add("HOME_SCHOOL_ID","School ID is either inactive or not a valid school")
	end if
    ' -------------------------
'End TextBox HOME_SCHOOL_ID Event OnValidate. Action Custom Code

'TextBox STUDENT_EMAIL Event OnValidate. Action Regular Expression Validation @63-61FE2D0C
        If Not (STUDENT_EMAIL.Value Is Nothing) Then
            Dim mask As Regex = New Regex("^[\w\.\+-]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]+$",RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            If Not(mask.Match(STUDENT_EMAIL.Value.ToString()).Success)
                errors.Add("STUDENT_EMAIL",String.Format("The STUDENT Email Address is not a valid Email Address eg: bob.student@example.com","STUDENT EMAIL ADDRESS"))
            End If
        End If
'End TextBox STUDENT_EMAIL Event OnValidate. Action Regular Expression Validation

'TextBox STUDENT_MOBILE Event OnValidate. Action Regular Expression Validation @66-ABEE6F89
        If Not (STUDENT_MOBILE.Value Is Nothing) Then
            Dim mask As Regex = New Regex("(^04\d{2,3}[\s\-]{0,1}\d{3}[\s\-]{0,1}\d{3}$)|(^0011[\s\-]{0,1}[0-9]{7,12}$)",RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            If Not(mask.Match(STUDENT_MOBILE.Value.ToString()).Success)
                errors.Add("STUDENT_MOBILE",String.Format("STUDENT MOBILE Phone Number must be an Australian number, with numbers, spaces, or hyphens" & _
  " only. eg: 0412 345 678 or 0412-345-678, or International number starting with 0011...","STUDENT MOBILE"))
            End If
        End If
'End TextBox STUDENT_MOBILE Event OnValidate. Action Regular Expression Validation

'VCE_CANDIDATE_NUMBER validate @59-004018BF
        If (Not IsNothing(VCE_CANDIDATE_NUMBER)) And (Not provider.CheckUnique("VCE_CANDIDATE_NUMBER",Me)) Then
                errors.Add("VCE_CANDIDATE_NUMBER", String.Format(Resources.strings.CCS_UniqueValue,"VCE_CANDIDATE_NUMBER"))
        End If
'End VCE_CANDIDATE_NUMBER validate

'TextBox VCE_CANDIDATE_NUMBER Event OnValidate. Action Regular Expression Validation @133-65C823DF
        If Not (VCE_CANDIDATE_NUMBER.Value Is Nothing) Then
            Dim mask As Regex = New Regex("\d{8}[a-zA-Z]",RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            If Not(mask.Match(VCE_CANDIDATE_NUMBER.Value.ToString()).Success)
                errors.Add("VCE_CANDIDATE_NUMBER",String.Format("The VCE CANDIDATE NUMBER must be 8 digits then a letter (eg: 12345678A)","VCE_CANDIDATE_NUMBER"))
            End If
        End If
'End TextBox VCE_CANDIDATE_NUMBER Event OnValidate. Action Regular Expression Validation

'Record STUDENT Event OnValidate. Action Custom Code @90-73254650
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

'Record STUDENT Item Class tail @3-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT Item Class tail

'Record STUDENT Data Provider Class @3-17C2BAE9
Public Class STUDENTDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT Data Provider Class

'Record STUDENT Data Provider Class Variables @3-F3CC936B
    Protected ListBox_SubCategoryDataCommand As DataCommand=new SqlCommand("select rtrim(SUBCATEGORY_FULL_TITLE) as SUBCATEGORY_FULL_TITLE from ENROLMENT_CATEGORY whe" & _
          "re STATUS=1 {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
    Protected listORG_SCHOOL_IDDataCommand As DataCommand=new TableCommand("SELECT SCHOOL_ID, SCHOOL_NAME " & vbCrLf & _
          "FROM SCHOOL {SQL_Where} {SQL_OrderBy}", New String(){"expr71","And","expr72"},Settings.connDECVPRODSQL2005DataAccessObject )
    Public UrlSTUDENT_ID As FloatParameter
    Protected item As STUDENTItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT Data Provider Class Variables

'Record STUDENT Data Provider Class Constructor @3-54D7A99D

    Public Sub New()
        Select_=new TableCommand("SELECT MIDDLE_NAME AS MIDDLE_NAME, STUDENT_ID, SURNAME AS SURNAME, " & vbCrLf & _
          "FIRST_NAME AS FIRST_NAME, BIRTH_DATE, SEX, CATEGORY_CODE, " & vbCrLf & _
          "SUBCATEGORY_CODE," & vbCrLf & _
          "ATTENDING_SCHOOL_ID, HOME_SCHOOL_ID, FULL_TIME, REGION, VSN, PREFERRED_NAME, ENROLLEDBEFOR" & _
          "E, " & vbCrLf & _
          "LAST_ALTERED_BY, LAST_ALTERED_DATE," & vbCrLf & _
          "DATE_STUDENTFOLDER_CREATED, VCE_CANDIDATE_NUMBER, " & vbCrLf & _
          "STUDENT_EMAIL, STUDENT_MOBILE, CURR_RESID_ADDRESS_ID, PORTAL_ACCESS, " & vbCrLf & _
          "ORGANISATION_SCHOOL_ID " & vbCrLf & _
          "FROM STUDENT {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID222"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STUDENT Data Provider Class Constructor

'Record STUDENT Data Provider Class LoadParams Method @3-A977A0E9

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID))
    End Function
'End Record STUDENT Data Provider Class LoadParams Method

'Record STUDENT Data Provider Class CheckUnique Method @3-527CB857

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENTItem) As Boolean
        Dim Check As TableCommand = New TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STUDENT",New String(){"STUDENT_ID222"},Settings.connDECVPRODSQL2005DataAccessObject)
        Dim CheckWhere As String = ""
        Select Case ControlName
        Case "VCE_CANDIDATE_NUMBER"
            CheckWhere = "VCE_CANDIDATE_NUMBER=" & Check.Dao.ToSql(item.VCE_CANDIDATE_NUMBER.GetFormattedValue(""),FieldType._Text)
        End Select
        Check.Where = CheckWhere
        Check.Operation = "AND NOT"
        Check.Parameters.Clear()
        CType(Check,TableCommand).AddParameter("STUDENT_ID222",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        If Convert.ToInt32(Check.ExecuteScalar()) > 0 Then
            Return False
        End If
        Return True
    End Function
'End Record STUDENT Data Provider Class CheckUnique Method

'Record STUDENT Data Provider Class PrepareInsert Method @3-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STUDENT Data Provider Class PrepareInsert Method

'Record STUDENT Data Provider Class PrepareInsert Method tail @3-E31F8E2A
    End Sub
'End Record STUDENT Data Provider Class PrepareInsert Method tail

'Record STUDENT Data Provider Class Insert Method @3-D30B5F89

    Public Function InsertItem(ByVal item As STUDENTItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO STUDENT({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT Data Provider Class Insert Method

'Record STUDENT Build insert @3-D91975A2
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
        If Not item.listORG_SCHOOL_ID.IsEmpty Then
        allEmptyFlag = item.listORG_SCHOOL_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ORGANISATION_SCHOOL_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.listORG_SCHOOL_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.VCE_CANDIDATE_NUMBER.IsEmpty Then
        allEmptyFlag = item.VCE_CANDIDATE_NUMBER.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "VCE_CANDIDATE_NUMBER,"
        valuesList = valuesList & Insert.Dao.ToSql(item.VCE_CANDIDATE_NUMBER.GetFormattedValue(""),FieldType._Text) & ","
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

'Record STUDENT Event AfterExecuteInsert. Action Custom Code @91-73254650
    ' -------------------------
    ' ERA: and automatically update the Current Resid Email Address and mobile
	If Not item.Hidden_CURR_RESID_ADDRESS_ID.IsEmpty Then
		Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
  		Dim Sql As String = "UPDATE ADDRESS SET EMAIL_ADDRESS= "& NewDao.ToSql(item.STUDENT_EMAIL.GetFormattedValue(""),FieldType._Text) &", PHONE_B= "& NewDao.ToSql(item.STUDENT_MOBILE.GetFormattedValue(""),FieldType._Text) &" WHERE ADDRESS_ID = " & NewDao.ToSql(item.Hidden_CURR_RESID_ADDRESS_ID.GetFormattedValue(""),FieldType._Text) &" "
  		NewDao.RunSql(Sql)
	End If
    ' -------------------------
'End Record STUDENT Event AfterExecuteInsert. Action Custom Code

'Record STUDENT AfterExecuteInsert @3-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT AfterExecuteInsert

'Record STUDENT Data Provider Class PrepareUpdate Method @3-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STUDENT Data Provider Class PrepareUpdate Method

'Record STUDENT Data Provider Class PrepareUpdate Method tail @3-E31F8E2A
    End Sub
'End Record STUDENT Data Provider Class PrepareUpdate Method tail

'Record STUDENT Data Provider Class Update Method @3-49CB7931

    Public Function UpdateItem(ByVal item As STUDENTItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT SET {Values}", New String(){"STUDENT_ID222"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT Data Provider Class Update Method

'Record STUDENT BeforeBuildUpdate @3-E4CC7ED3
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID222",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
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
        If Not item.listORG_SCHOOL_ID.IsEmpty Then
        allEmptyFlag = item.listORG_SCHOOL_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ORGANISATION_SCHOOL_ID=" + Update.Dao.ToSql(item.listORG_SCHOOL_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.VCE_CANDIDATE_NUMBER.IsEmpty Then
        allEmptyFlag = item.VCE_CANDIDATE_NUMBER.IsEmpty And allEmptyFlag
        valuesList = valuesList & "VCE_CANDIDATE_NUMBER=" + Update.Dao.ToSql(item.VCE_CANDIDATE_NUMBER.GetFormattedValue(""),FieldType._Text) & ","
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

'DEL      ' -------------------------
'DEL   	' ERA: and automatically update the Current Resid Email Address and mobile
'DEL  	If Not item.Hidden_CURR_RESID_ADDRESS_ID.IsEmpty Then
'DEL  		Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
'DEL    		Dim Sql As String = "UPDATE ADDRESS SET EMAIL_ADDRESS= "& NewDao.ToSql(item.STUDENT_EMAIL.GetFormattedValue(""),FieldType._Text) &", PHONE_B= "& NewDao.ToSql(item.STUDENT_MOBILE.GetFormattedValue(""),FieldType._Text) &" WHERE ADDRESS_ID = " & NewDao.ToSql(item.Hidden_CURR_RESID_ADDRESS_ID.GetFormattedValue(""),FieldType._Text) &" "
'DEL    		NewDao.RunSql(Sql)
'DEL  	End If
'DEL      ' -------------------------


'Record STUDENT AfterExecuteUpdate @3-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT AfterExecuteUpdate

'Record STUDENT Data Provider Class GetResultSet Method @3-BE21EA83

    Public Sub FillItem(ByVal item As STUDENTItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT Data Provider Class GetResultSet Method

'Record STUDENT BeforeBuildSelect @3-3B5427D7
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID222",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT BeforeBuildSelect

'Record STUDENT BeforeExecuteSelect @3-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT BeforeExecuteSelect

'Record STUDENT AfterExecuteSelect @3-01B38253
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
            item.hidden_DATE_STUDENTFOLDER_CREATED.SetValue(dr(i)("DATE_STUDENTFOLDER_CREATED"),Select_.DateFormat)
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.hidden_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.hidden_LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.STUDENT_EMAIL.SetValue(dr(i)("STUDENT_EMAIL"),"")
            item.STUDENT_MOBILE.SetValue(dr(i)("STUDENT_MOBILE"),"")
            item.Hidden_CURR_RESID_ADDRESS_ID.SetValue(dr(i)("CURR_RESID_ADDRESS_ID"),"")
            item.listORG_SCHOOL_ID.SetValue(dr(i)("ORGANISATION_SCHOOL_ID"),"")
            item.VCE_CANDIDATE_NUMBER.SetValue(dr(i)("VCE_CANDIDATE_NUMBER"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record STUDENT AfterExecuteSelect

'ListBox SEX AfterExecuteSelect @13-17465C4F
        
item.SEXItems.Add("F","Female")
item.SEXItems.Add("M","Male")
'End ListBox SEX AfterExecuteSelect

'ListBox ListBox_SubCategory Initialize Data Source @14-EBEBFF52
        ListBox_SubCategoryDataCommand.Dao._optimized = False
        Dim ListBox_SubCategorytableIndex As Integer = 0
        ListBox_SubCategoryDataCommand.OrderBy = "rtrim(SUBCATEGORY_FULL_TITLE)"
        ListBox_SubCategoryDataCommand.Parameters.Clear()
'End ListBox ListBox_SubCategory Initialize Data Source

'ListBox ListBox_SubCategory BeforeExecuteSelect @14-3221252B
        Try
            ListBoxSource=ListBox_SubCategoryDataCommand.Execute().Tables(ListBox_SubCategorytableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox ListBox_SubCategory BeforeExecuteSelect

'ListBox ListBox_SubCategory AfterExecuteSelect @14-98DE4C77
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("SUBCATEGORY_FULL_TITLE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("SUBCATEGORY_FULL_TITLE")
            item.ListBox_SubCategoryItems.Add(Key, Val)
        Next
'End ListBox ListBox_SubCategory AfterExecuteSelect

'ListBox listORG_SCHOOL_ID Initialize Data Source @70-55F0FE7D
        listORG_SCHOOL_IDDataCommand.Dao._optimized = False
        Dim listORG_SCHOOL_IDtableIndex As Integer = 0
        listORG_SCHOOL_IDDataCommand.OrderBy = "SCHOOL_NAME"
        listORG_SCHOOL_IDDataCommand.Parameters.Clear()
        listORG_SCHOOL_IDDataCommand.Parameters.Add("expr71","(status=1)")
        listORG_SCHOOL_IDDataCommand.Parameters.Add("expr72","(SCHOOL_TYPE_CODE ='X')")
'End ListBox listORG_SCHOOL_ID Initialize Data Source

'ListBox listORG_SCHOOL_ID BeforeExecuteSelect @70-F5E25BE2
        Try
            ListBoxSource=listORG_SCHOOL_IDDataCommand.Execute().Tables(listORG_SCHOOL_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox listORG_SCHOOL_ID BeforeExecuteSelect

'ListBox listORG_SCHOOL_ID AfterExecuteSelect @70-A91B30B5
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("SCHOOL_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("SCHOOL_NAME")
            item.listORG_SCHOOL_IDItems.Add(Key, Val)
        Next
'End ListBox listORG_SCHOOL_ID AfterExecuteSelect

'Record STUDENT AfterExecuteSelect tail @3-E31F8E2A
    End Sub
'End Record STUDENT AfterExecuteSelect tail

'Record STUDENT Data Provider Class @3-A61BA892
End Class

'End Record STUDENT Data Provider Class

'Record STUDENT_ENROLMENT Item Class @134-185A6FBF
Public Class STUDENT_ENROLMENTItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public lblENROLMENT_YEAR As FloatField
    Public ENROLMENT_STATUS As TextField
    Public ENROLMENT_STATUSItems As ItemCollection
    Public ENROLMENT_DATE As DateField
    Public LAST_ALTERED_DATE As DateField
    Public LAST_ALTERED_BY As TextField
    Public YEAR_LEVEL As IntegerField
    Public YEAR_LEVELItems As ItemCollection
    Public LAST_ALTERED_BY1 As TextField
    Public LAST_ALTERED_DATE1 As DateField
    Public STUDENT_ID As TextField
    Public ENROLMENT_YEAR As TextField
    Public Sub New()
    lblENROLMENT_YEAR = New FloatField("", Nothing)
    ENROLMENT_STATUS = New TextField("", "F")
    ENROLMENT_STATUSItems = New ItemCollection()
    ENROLMENT_DATE = New DateField("dd\/MM\/yyyy", DateTime.Now)
    LAST_ALTERED_DATE = New DateField("yyyy-MM-dd H\:mm", DateTime.Now)
    LAST_ALTERED_BY = New TextField("", DBUtility.UserID.ToUpper)
    YEAR_LEVEL = New IntegerField("", Nothing)
    YEAR_LEVELItems = New ItemCollection()
    LAST_ALTERED_BY1 = New TextField("", Nothing)
    LAST_ALTERED_DATE1 = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    STUDENT_ID = New TextField("", Nothing)
    ENROLMENT_YEAR = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_ENROLMENTItem
        Dim item As STUDENT_ENROLMENTItem = New STUDENT_ENROLMENTItem()
        If Not IsNothing(DBUtility.GetInitialValue("lblENROLMENT_YEAR")) Then
        item.lblENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("lblENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_STATUS")) Then
        item.ENROLMENT_STATUS.SetValue(DBUtility.GetInitialValue("ENROLMENT_STATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_DATE")) Then
        item.ENROLMENT_DATE.SetValue(DBUtility.GetInitialValue("ENROLMENT_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("YEAR_LEVEL")) Then
        item.YEAR_LEVEL.SetValue(DBUtility.GetInitialValue("YEAR_LEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY1")) Then
        item.LAST_ALTERED_BY1.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE1")) Then
        item.LAST_ALTERED_DATE1.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Add")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_YEAR")) Then
        item.ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("ENROLMENT_YEAR"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "lblENROLMENT_YEAR"
                    Return lblENROLMENT_YEAR
                Case "ENROLMENT_STATUS"
                    Return ENROLMENT_STATUS
                Case "ENROLMENT_DATE"
                    Return ENROLMENT_DATE
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "YEAR_LEVEL"
                    Return YEAR_LEVEL
                Case "LAST_ALTERED_BY1"
                    Return LAST_ALTERED_BY1
                Case "LAST_ALTERED_DATE1"
                    Return LAST_ALTERED_DATE1
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "ENROLMENT_YEAR"
                    Return ENROLMENT_YEAR
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblENROLMENT_YEAR"
                    lblENROLMENT_YEAR = CType(value, FloatField)
                Case "ENROLMENT_STATUS"
                    ENROLMENT_STATUS = CType(value, TextField)
                Case "ENROLMENT_DATE"
                    ENROLMENT_DATE = CType(value, DateField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "YEAR_LEVEL"
                    YEAR_LEVEL = CType(value, IntegerField)
                Case "LAST_ALTERED_BY1"
                    LAST_ALTERED_BY1 = CType(value, TextField)
                Case "LAST_ALTERED_DATE1"
                    LAST_ALTERED_DATE1 = CType(value, DateField)
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, TextField)
                Case "ENROLMENT_YEAR"
                    ENROLMENT_YEAR = CType(value, TextField)
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

'ENROLMENT_STATUS validate @139-5B7051E5
        If IsNothing(ENROLMENT_STATUS.Value) OrElse ENROLMENT_STATUS.Value.ToString() ="" Then
            errors.Add("ENROLMENT_STATUS",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT STATUS"))
        End If
'End ENROLMENT_STATUS validate

'ENROLMENT_DATE validate @141-F0770BE0
        If IsNothing(ENROLMENT_DATE.Value) OrElse ENROLMENT_DATE.Value.ToString() ="" Then
            errors.Add("ENROLMENT_DATE",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT DATE"))
        End If
'End ENROLMENT_DATE validate

'LAST_ALTERED_DATE validate @144-C5989D76
        If IsNothing(LAST_ALTERED_DATE.Value) OrElse LAST_ALTERED_DATE.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED DATE"))
        End If
'End LAST_ALTERED_DATE validate

'LAST_ALTERED_BY validate @143-256A6854
        If IsNothing(LAST_ALTERED_BY.Value) OrElse LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End LAST_ALTERED_BY validate

'YEAR_LEVEL validate @140-30512612
        If IsNothing(YEAR_LEVEL.Value) OrElse YEAR_LEVEL.Value.ToString() ="" Then
            errors.Add("YEAR_LEVEL",String.Format(Resources.strings.CCS_RequiredField,"YEAR LEVEL"))
        End If
'End YEAR_LEVEL validate

'Record STUDENT_ENROLMENT Item Class tail @134-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_ENROLMENT Item Class tail

'Record STUDENT_ENROLMENT Data Provider Class @134-55469C34
Public Class STUDENT_ENROLMENTDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_ENROLMENT Data Provider Class

'Record STUDENT_ENROLMENT Data Provider Class Variables @134-ADBDFE91
    Public UrlSTUDENT_ID As TextParameter
    Public UrlENROLMENT_YEAR As FloatParameter
    Protected item As STUDENT_ENROLMENTItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_ENROLMENT Data Provider Class Variables

'Record STUDENT_ENROLMENT Data Provider Class Constructor @134-75FFDFC9

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_ENROLMENT {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID148","And","ENROLMENT_YEAR149"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_ENROLMENT Data Provider Class Constructor

'Record STUDENT_ENROLMENT Data Provider Class LoadParams Method @134-79390024

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID) Or IsNothing(UrlENROLMENT_YEAR))
    End Function
'End Record STUDENT_ENROLMENT Data Provider Class LoadParams Method

'Record STUDENT_ENROLMENT Data Provider Class CheckUnique Method @134-BF72701B

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_ENROLMENTItem) As Boolean
        Return True
    End Function
'End Record STUDENT_ENROLMENT Data Provider Class CheckUnique Method

'Record STUDENT_ENROLMENT Data Provider Class PrepareInsert Method @134-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STUDENT_ENROLMENT Data Provider Class PrepareInsert Method

'Record STUDENT_ENROLMENT Data Provider Class PrepareInsert Method tail @134-E31F8E2A
    End Sub
'End Record STUDENT_ENROLMENT Data Provider Class PrepareInsert Method tail

'Record STUDENT_ENROLMENT Data Provider Class Insert Method @134-2B0D7FC0

    Public Function InsertItem(ByVal item As STUDENT_ENROLMENTItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO STUDENT_ENROLMENT({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_ENROLMENT Data Provider Class Insert Method

'Record STUDENT_ENROLMENT Build insert @134-8C742738
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.ENROLMENT_STATUS.IsEmpty Then
        allEmptyFlag = item.ENROLMENT_STATUS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ENROLMENT_STATUS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ENROLMENT_STATUS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ENROLMENT_DATE.IsEmpty Then
        allEmptyFlag = item.ENROLMENT_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ENROLMENT_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ENROLMENT_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.YEAR_LEVEL.IsEmpty Then
        allEmptyFlag = item.YEAR_LEVEL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "YEAR_LEVEL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.STUDENT_ID.IsEmpty Then
        allEmptyFlag = item.STUDENT_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STUDENT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STUDENT_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ENROLMENT_YEAR.IsEmpty Then
        allEmptyFlag = item.ENROLMENT_YEAR.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ENROLMENT_YEAR,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ENROLMENT_YEAR.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STUDENT_ENROLMENT Build insert

'Record STUDENT_ENROLMENT AfterExecuteInsert @134-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_ENROLMENT AfterExecuteInsert

'Record STUDENT_ENROLMENT Data Provider Class PrepareUpdate Method @134-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STUDENT_ENROLMENT Data Provider Class PrepareUpdate Method

'Record STUDENT_ENROLMENT Data Provider Class PrepareUpdate Method tail @134-E31F8E2A
    End Sub
'End Record STUDENT_ENROLMENT Data Provider Class PrepareUpdate Method tail

'Record STUDENT_ENROLMENT Data Provider Class Update Method @134-DA01A052

    Public Function UpdateItem(ByVal item As STUDENT_ENROLMENTItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT_ENROLMENT SET {Values}", New String(){"STUDENT_ID148","And","ENROLMENT_YEAR149"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_ENROLMENT Data Provider Class Update Method

'Record STUDENT_ENROLMENT BeforeBuildUpdate @134-1CC0AA97
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID148",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ENROLMENT_YEAR149",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        If Not item.ENROLMENT_STATUS.IsEmpty Then
        allEmptyFlag = item.ENROLMENT_STATUS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ENROLMENT_STATUS=" + Update.Dao.ToSql(item.ENROLMENT_STATUS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ENROLMENT_DATE.IsEmpty Then
        allEmptyFlag = item.ENROLMENT_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ENROLMENT_DATE=" + Update.Dao.ToSql(item.ENROLMENT_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.YEAR_LEVEL.IsEmpty Then
        allEmptyFlag = item.YEAR_LEVEL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "YEAR_LEVEL=" + Update.Dao.ToSql(item.YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.STUDENT_ID.IsEmpty Then
        allEmptyFlag = item.STUDENT_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STUDENT_ID=" + Update.Dao.ToSql(item.STUDENT_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ENROLMENT_YEAR.IsEmpty Then
        allEmptyFlag = item.ENROLMENT_YEAR.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ENROLMENT_YEAR=" + Update.Dao.ToSql(item.ENROLMENT_YEAR.GetFormattedValue(""),FieldType._Text) & ","
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

'Record STUDENT_ENROLMENT AfterExecuteUpdate @134-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_ENROLMENT AfterExecuteUpdate

'Record STUDENT_ENROLMENT Data Provider Class GetResultSet Method @134-6E5BBB74

    Public Sub FillItem(ByVal item As STUDENT_ENROLMENTItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_ENROLMENT Data Provider Class GetResultSet Method

'Record STUDENT_ENROLMENT BeforeBuildSelect @134-5DE7CD97
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID148",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("ENROLMENT_YEAR149",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_ENROLMENT BeforeBuildSelect

'Record STUDENT_ENROLMENT BeforeExecuteSelect @134-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_ENROLMENT BeforeExecuteSelect

'Record STUDENT_ENROLMENT AfterExecuteSelect @134-44CCC1C1
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.lblENROLMENT_YEAR.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.ENROLMENT_STATUS.SetValue(dr(i)("ENROLMENT_STATUS"),"")
            item.ENROLMENT_DATE.SetValue(dr(i)("ENROLMENT_DATE"),Select_.DateFormat)
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
            item.LAST_ALTERED_BY1.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE1.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.ENROLMENT_YEAR.SetValue(dr(i)("ENROLMENT_YEAR"),"")
        Else
            IsInsertMode = True
        End If
'End Record STUDENT_ENROLMENT AfterExecuteSelect

'ListBox ENROLMENT_STATUS AfterExecuteSelect @139-AD8965F8
        
item.ENROLMENT_STATUSItems.Add("E","Enrolled")
item.ENROLMENT_STATUSItems.Add("N","Not Enrolled")
item.ENROLMENT_STATUSItems.Add("F","Future Enrolment")
'End ListBox ENROLMENT_STATUS AfterExecuteSelect

'ListBox YEAR_LEVEL AfterExecuteSelect @140-EB7813C0
        
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

'Record STUDENT_ENROLMENT AfterExecuteSelect tail @134-E31F8E2A
    End Sub
'End Record STUDENT_ENROLMENT AfterExecuteSelect tail

'Record STUDENT_ENROLMENT Data Provider Class @134-A61BA892
End Class

'End Record STUDENT_ENROLMENT Data Provider Class

'EditableGrid EditableGrid1 Item Class @184-3F524CA0
Public Class EditableGrid1Item
    Public errors As NameValueCollection = New NameValueCollection()
    Public RowId As Integer
    Private _deleteAllowed As Boolean = True
    Private _isNew As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public id As IntegerField
    Public description As TextField
    Public option_received As TextField
    Public option_receivedItems As ItemCollection
    Public notes_public As TextField
    Public last_altered_when As DateField
    Public CheckBox_Delete As BooleanField
    Public CheckBox_DeleteCheckedValue As BooleanField
    Public CheckBox_DeleteUncheckedValue As BooleanField
    Public lblWhen As DateField
    Public last_altered_by As TextField
    Public lblWho As TextField
    Public hidden_hashchanges As TextField
    Public Sub New()
    id = New IntegerField("", Nothing)
    description = New TextField("", Nothing)
    option_received = New TextField("", Nothing)
    option_receivedItems = New ItemCollection()
    notes_public = New TextField("", Nothing)
    last_altered_when = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    CheckBox_Delete = New BooleanField(Settings.BoolFormat, false)
    CheckBox_DeleteCheckedValue = New BooleanField(Settings.BoolFormat, true)
    CheckBox_DeleteUncheckedValue = New BooleanField(Settings.BoolFormat, false)
    lblWhen = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    last_altered_by = New TextField("", Nothing)
    lblWho = New TextField("", Nothing)
    hidden_hashchanges = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase
        Get
            Select fieldName
                Case "idField"
                    Return Me.idField
                Case "id"
                    Return Me.id
                Case "description"
                    Return Me.description
                Case "option_received"
                    Return Me.option_received
                Case "notes_public"
                    Return Me.notes_public
                Case "last_altered_when"
                    Return Me.last_altered_when
                Case "CheckBox_Delete"
                    Return Me.CheckBox_Delete
                Case "lblWhen"
                    Return Me.lblWhen
                Case "last_altered_by"
                    Return Me.last_altered_by
                Case "lblWho"
                    Return Me.lblWho
                Case "hidden_hashchanges"
                    Return Me.hidden_hashchanges
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "idField"
                    Me.idField = CType(Value,IntegerField)
                Case "id"
                    Me.id = CType(Value,IntegerField)
                Case "description"
                    Me.description = CType(Value,TextField)
                Case "option_received"
                    Me.option_received = CType(Value,TextField)
                Case "notes_public"
                    Me.notes_public = CType(Value,TextField)
                Case "last_altered_when"
                    Me.last_altered_when = CType(Value,DateField)
                Case "CheckBox_Delete"
                    Me.CheckBox_Delete = CType(Value,BooleanField)
                Case "lblWhen"
                    Me.lblWhen = CType(Value,DateField)
                Case "last_altered_by"
                    Me.last_altered_by = CType(Value,TextField)
                Case "lblWho"
                    Me.lblWho = CType(Value,TextField)
                Case "hidden_hashchanges"
                    Me.hidden_hashchanges = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public  Property IsDeleteAllowed As Boolean
        Get
            Return  Not(IsEmptyItem) AndAlso _deleteAllowed
        End Get
        Set
            _deleteAllowed = Value
        End Set
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
            result = IsNothing(option_received.Value) And result
            result = IsNothing(notes_public.Value) And result
            result = IsNothing(last_altered_when.Value) And result
            result = IsNothing(CheckBox_Delete.Value) And result
            result = IsNothing(last_altered_by.Value) And result
            result = IsNothing(hidden_hashchanges.Value) And result
            Return result
        End Get
    End Property

    Public IsDeleted As Boolean = False
    Public IsUpdated As Boolean = False
    Public idField As IntegerField = New IntegerField()
    Public Function Validate(ByVal provider As EditableGrid1DataProvider) As Boolean
'End EditableGrid EditableGrid1 Item Class

'EditableGrid EditableGrid1 Event OnValidateRow. Action Custom Code @214-73254650
    ' -------------------------
    'Nov-2018|EA| if No (N) selected, then must enter a Note
    Dim tmpOption as String = option_received.Value
    if (tmpOption="N" and notes_public.Value="") Then
    	errors.Add("option_received","Must enter a Note if Option is 'No'")
    end if
        
    ' -------------------------
'End EditableGrid EditableGrid1 Event OnValidateRow. Action Custom Code

'EditableGrid EditableGrid1 Item Class tail @184-11D8DCF0
        Return errors.Count = 0
    End Function
    Public RawData As DataRow = Nothing
End Class
'End EditableGrid EditableGrid1 Item Class tail

'EditableGrid EditableGrid1 Data Provider Class Header @184-1EA4F0E2
Public Class EditableGrid1DataProvider
Inherits EditableGridDataProviderBase
'End EditableGrid EditableGrid1 Data Provider Class Header

'Grid EditableGrid1 Data Provider Class Variables @184-55F76708

    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 25
    Public PageNumber As Integer = 1
    Public UrlENROLMENT_YEAR  As FloatParameter
    Public Ctrloption_received  As TextParameter
    Public Ctrlnotes_public  As TextParameter
    Public Expr203  As DateParameter
    Public Expr204  As TextParameter
    Public UrlSTUDENT_ID  As FloatParameter
'End Grid EditableGrid1 Data Provider Class Variables

'EditableGrid EditableGrid1 Data Provider Class Constructor @184-F3F1D66E

    Public Sub New()
        Select_=new SqlCommand("SELECT sck.id, ec.description, sck.option_received, sck.notes_public, sck.last_altered_whe" & _
          "n" & vbCrLf & _
          "		, sck.student_id, sck.last_altered_by" & vbCrLf & _
          " FROM STUDENT_ENROL_CHECKLIST SCK join ENROL_CHECKLIST EC" & vbCrLf & _
          "	on sck.enrol_checklist_id = ec.id" & vbCrLf & _
          "where sck.student_id = {STUDENT_ID} " & vbCrLf & _
          "	and sck.enrolment_year = {ENROLMENT_YEAR}",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (SELECT sck.id, ec.description, sck.option_received, sck.notes_public" & _
          ", sck.last_altered_when" & vbCrLf & _
          "		, sck.student_id, sck.last_altered_by" & vbCrLf & _
          " FROM STUDENT_ENROL_CHECKLIST SCK join ENROL_CHECKLIST EC" & vbCrLf & _
          "	on sck.enrol_checklist_id = ec.id" & vbCrLf & _
          "where sck.student_id = {STUDENT_ID} " & vbCrLf & _
          "	and sck.enrolment_year = {ENROLMENT_YEAR}) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End EditableGrid EditableGrid1 Data Provider Class Constructor

'Record EditableGrid1 Data Provider Class CheckUnique Method @184-2BE65FEF

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As EditableGrid1Item) As Boolean
        Return True
    End Function
'End Record EditableGrid1 Data Provider Class CheckUnique Method

'EditableGrid EditableGrid1 Data Provider Class Update Method @184-C169EC14
    Protected Function UpdateItem(ByVal item As EditableGrid1Item) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        IsParametersPassed = Not(IsNothing(UrlSTUDENT_ID) Or IsNothing(UrlENROLMENT_YEAR) Or IsNothing(item.idField))
        Dim Update As DataCommand=new TableCommand("UPDATE STUDENT_ENROL_CHECKLIST SET {Values}", New String(){"STUDENT_ID205","And","ENROLMENT_YEAR206","And","id207"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End EditableGrid EditableGrid1 Data Provider Class Update Method

'EditableGrid EditableGrid1 BeforeBuildUpdate @184-3534498F
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID205",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ENROLMENT_YEAR206",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("id207",item.idField, "","ID",Condition.Equal,False)
        allEmptyFlag = item.option_received.IsEmpty And allEmptyFlag
        If IsNothing(item.option_received.Value) Then
        valuesList = valuesList & "option_received=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "option_received=" & Update.Dao.ToSql(item.option_received.GetFormattedValue(""),FieldType._Text) & ","
        End If
        allEmptyFlag = item.notes_public.IsEmpty And allEmptyFlag
        If IsNothing(item.notes_public.Value) Then
        valuesList = valuesList & "notes_public=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "notes_public=" & Update.Dao.ToSql(item.notes_public.GetFormattedValue(""),FieldType._Text) & ","
        End If
        allEmptyFlag = (Expr203 Is Nothing) And allEmptyFlag
        If Not (Expr203 Is Nothing) Then
        If IsNothing(Expr203) Then
        valuesList = valuesList & "last_altered_when=" & Update.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        valuesList = valuesList & "last_altered_when=" & Update.Dao.ToSql(Expr203.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        End If
        allEmptyFlag = (Expr204 Is Nothing) And allEmptyFlag
        If Not (Expr204 Is Nothing) Then
        If IsNothing(Expr204) Then
        valuesList = valuesList & "last_altered_by=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "last_altered_by=" & Update.Dao.ToSql(Expr204.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
		Update.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
'End EditableGrid EditableGrid1 BeforeBuildUpdate

'EditableGrid EditableGrid1 Event BeforeExecuteUpdate. Action Custom Code @213-73254650
    ' -------------------------
    'Nov-2018|EA| make a simple string to compare to the hashchanges field, and if same them don't update
    
    dim tmpRowHash as String = "Blah"
    ' make the hash
    tmpRowHash = item.id.GetFormattedValue("") & item.option_received.GetFormattedValue("") & item.notes_public.GetFormattedValue("")
    'item.errors.Add("option_received",tmpRowHash)
    CmdExecution = false
    if (tmpRowHash <> item.hidden_hashchanges.value) Then
    	CmdExecution = true
    end if
    
    
    ' -------------------------
'End EditableGrid EditableGrid1 Event BeforeExecuteUpdate. Action Custom Code

'EditableGrid EditableGrid1 Execute Update  @184-392E25E7
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
'End EditableGrid EditableGrid1 Execute Update 

'EditableGrid EditableGrid1 AfterExecuteUpdate @184-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid EditableGrid1 AfterExecuteUpdate

'Record EditableGrid1 Data Provider Class Delete Method @184-B7D38C77
    Public Function DeleteItem(ByVal item As EditableGrid1Item) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        IsParametersPassed = Not(IsNothing(UrlSTUDENT_ID) Or IsNothing(item.idField))
        Dim Delete As DataCommand=new TableCommand("DELETE FROM STUDENT_ENROL_CHECKLIST", New String(){"STUDENT_ID211","And","id212"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record EditableGrid1 Data Provider Class Delete Method

'Record EditableGrid1 BeforeBuildDelete @184-1C440798
        Delete.Parameters.Clear()
        CType(Delete,TableCommand).AddParameter("STUDENT_ID211",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Delete,TableCommand).AddParameter("id212",item.idField, "","ID",Condition.Equal,False)
'End Record EditableGrid1 BeforeBuildDelete

'EditableGrid EditableGrid1 Data Provider Class Execute Delete @184-124DEAF1
        Delete.OpType = OperationType.Delete
        Dim result As Object = 0
        Dim E As Exception = Nothing
        If CmdExecution Then
            If Not IsParametersPassed Then
                item.errors.Add("DataProvider",Resources.strings.CCS_CustomOperationError_MissingParameters)
                Return 0
            End If
            Try
                result = Delete.ExecuteNonQuery()
            Catch e_ As Exception
                item.errors.Add("DataProvider",e_.Source + ":" + e_.Message)
            Finally
'End EditableGrid EditableGrid1 Data Provider Class Execute Delete

'EditableGrid EditableGrid1 AfterExecuteDelete @184-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid EditableGrid1 AfterExecuteDelete

'Grid EditableGrid1 Data Provider Class GetResultSet Method @184-A3F93E1D
    Public Sub Update(Items As ArrayList, ops As FormSupportedOperations)
        Dim i As Integer
        For i = 0 To Items.Count - 1
            Dim op As EditableGridOperation = EditableGridOperation.Insert
            Dim isProcessed As Boolean = False
            Dim item As EditableGrid1Item = CType(Items(i), EditableGrid1Item)
'End Grid EditableGrid1 Data Provider Class GetResultSet Method

'EditableGrid EditableGrid1 Data Provider Class Update @184-16326EAB
            If Not item.IsUpdated Then
                If item.IsDeleted And ops.AllowDelete Then
                    DeleteItem(item)
                    op = EditableGridOperation.Delete
                    isProcessed = True
                End If
                If Not(item.IsEmptyItem) And ops.AllowUpdate And Not(isProcessed) Then
                    UpdateItem(item)
                    op = EditableGridOperation.Update
                End If
'End EditableGrid EditableGrid1 Data Provider Class Update

'EditableGrid EditableGrid1 Data Provider Class AfterUpdate @184-6CCB76B9
                If item.errors.Count = 0 Then item.IsUpdated = True
                OnItemUpdated(New ItemUpdatedEventArgs(op, item))
            End If
        Next i
    End Sub
'End EditableGrid EditableGrid1 Data Provider Class AfterUpdate

'EditableGrid EditableGrid1 Data Provider Class GetResultSet Method @184-741AC175
    Public Function GetResultSet(ByRef _pagesCount As Integer, ops As FormSupportedOperations) As EditableGrid1Item()
'End EditableGrid EditableGrid1 Data Provider Class GetResultSet Method

'Before build Select @184-5C2404BD
        _pagesCount = 0
        Dim E as Exception = Nothing
        Dim j As Integer
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("STUDENT_ID",UrlSTUDENT_ID, "")
        CType(Select_,SqlCommand).AddParameter("ENROLMENT_YEAR",UrlENROLMENT_YEAR, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy = SortFieldsNames(CInt(SortField)).Trim
        Else
            Select_.OrderBy = SortFieldsNamesDesc(CInt(SortField)).Trim
        End If
    Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @184-939614DD
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

'After execute Select @184-F71D72AB
                If Not IsNothing(E) Then Throw E
            End Try
            dr = ds.Tables(tableIndex).Rows
            rowCount = dr.Count
        End If
        Dim result(rowCount - 1) As EditableGrid1Item
'End After execute Select

'ListBox option_received AfterExecuteSelect @190-D1EEF03C
    Dim option_receivedItems As ItemCollection = New ItemCollection()
    
option_receivedItems.Add("Y","Yes")
option_receivedItems.Add("N","No")
option_receivedItems.Add("W","Waiting")
option_receivedItems.Add("X","N/A")
'End ListBox option_received AfterExecuteSelect

'After execute Select tail @184-0B1FFA1C
        Dim i as Integer
        For i = 0 To rowCount - 1
            Dim item as EditableGrid1Item = New EditableGrid1Item()
            item.IsDeleteAllowed = ops.AllowDelete
            item.id.SetValue(dr(i)("id"),"")
            item.description.SetValue(dr(i)("description"),"")
            item.option_received.SetValue(dr(i)("option_received"),"")
            item.option_receivedItems = CType(option_receivedItems.Clone(), ItemCollection)
            item.notes_public.SetValue(dr(i)("notes_public"),"")
            item.last_altered_when.SetValue(dr(i)("last_altered_when"),Select_.DateFormat)
            item.lblWhen.SetValue(dr(i)("last_altered_when"),Select_.DateFormat)
            item.last_altered_by.SetValue(dr(i)("last_altered_by"),"")
            item.lblWho.SetValue(dr(i)("last_altered_by"),"")
            item.idField.SetValue(dr(i)("id"),"")
            item.RawData = dr(i)
            result(i)=item
        Next i
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @184-A61BA892
End Class
'End Grid Data Provider tail

'Record STUDENT_COMMENT Item Class @255-EC96F38A
Public Class STUDENT_COMMENTItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public lblSTUDENT_ID As TextField
    Public COMMENT As TextField
    Public STUDENT_ID As FloatField
    Public hidden_STATUS As TextField
    Public Hidden_CommentType As TextField
    Public lblCommentType As TextField
    Public lbSpecialCommentType As TextField
    Public lbSpecialCommentTypeItems As ItemCollection
    Public lbSpecialCommentType1 As TextField
    Public lbSpecialCommentType1Items As ItemCollection
    Public lbCannedResponses As TextField
    Public lbCannedResponsesItems As ItemCollection
    Public Sub New()
    lblSTUDENT_ID = New TextField("", Nothing)
    COMMENT = New TextField("", Nothing)
    STUDENT_ID = New FloatField("", Nothing)
    hidden_STATUS = New TextField("", "F")
    Hidden_CommentType = New TextField("", "REGULAR")
    lblCommentType = New TextField("", "SPECIAL COMMENT TYPE")
    lbSpecialCommentType = New TextField("", "")
    lbSpecialCommentTypeItems = New ItemCollection()
    lbSpecialCommentType1 = New TextField("", "0")
    lbSpecialCommentType1Items = New ItemCollection()
    lbCannedResponses = New TextField("", Nothing)
    lbCannedResponsesItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_COMMENTItem
        Dim item As STUDENT_COMMENTItem = New STUDENT_COMMENTItem()
        If Not IsNothing(DBUtility.GetInitialValue("lblSTUDENT_ID")) Then
        item.lblSTUDENT_ID.SetValue(DBUtility.GetInitialValue("lblSTUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COMMENT")) Then
        item.COMMENT.SetValue(DBUtility.GetInitialValue("COMMENT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_STATUS")) Then
        item.hidden_STATUS.SetValue(DBUtility.GetInitialValue("hidden_STATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_CommentType")) Then
        item.Hidden_CommentType.SetValue(DBUtility.GetInitialValue("Hidden_CommentType"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblCommentType")) Then
        item.lblCommentType.SetValue(DBUtility.GetInitialValue("lblCommentType"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbSpecialCommentType")) Then
        item.lbSpecialCommentType.SetValue(DBUtility.GetInitialValue("lbSpecialCommentType"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbSpecialCommentType1")) Then
        item.lbSpecialCommentType1.SetValue(DBUtility.GetInitialValue("lbSpecialCommentType1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbCannedResponses")) Then
        item.lbCannedResponses.SetValue(DBUtility.GetInitialValue("lbCannedResponses"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "lblSTUDENT_ID"
                    Return lblSTUDENT_ID
                Case "COMMENT"
                    Return COMMENT
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "hidden_STATUS"
                    Return hidden_STATUS
                Case "Hidden_CommentType"
                    Return Hidden_CommentType
                Case "lblCommentType"
                    Return lblCommentType
                Case "lbSpecialCommentType"
                    Return lbSpecialCommentType
                Case "lbSpecialCommentType1"
                    Return lbSpecialCommentType1
                Case "lbCannedResponses"
                    Return lbCannedResponses
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblSTUDENT_ID"
                    lblSTUDENT_ID = CType(value, TextField)
                Case "COMMENT"
                    COMMENT = CType(value, TextField)
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, FloatField)
                Case "hidden_STATUS"
                    hidden_STATUS = CType(value, TextField)
                Case "Hidden_CommentType"
                    Hidden_CommentType = CType(value, TextField)
                Case "lblCommentType"
                    lblCommentType = CType(value, TextField)
                Case "lbSpecialCommentType"
                    lbSpecialCommentType = CType(value, TextField)
                Case "lbSpecialCommentType1"
                    lbSpecialCommentType1 = CType(value, TextField)
                Case "lbCannedResponses"
                    lbCannedResponses = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STUDENT_COMMENTDataProvider)
'End Record STUDENT_COMMENT Item Class

'COMMENT validate @257-AF76D6FB
        If IsNothing(COMMENT.Value) OrElse COMMENT.Value.ToString() ="" Then
            errors.Add("COMMENT",String.Format(Resources.strings.CCS_RequiredField,"COMMENT"))
        End If
'End COMMENT validate

'STUDENT_ID validate @260-6D9CF271
        If IsNothing(STUDENT_ID.Value) OrElse STUDENT_ID.Value.ToString() ="" Then
            errors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_RequiredField,"STUDENT ID"))
        End If
'End STUDENT_ID validate

'lbSpecialCommentType1 validate @68-54AE4A18
        If IsNothing(lbSpecialCommentType1.Value) OrElse lbSpecialCommentType1.Value.ToString() ="" Then
            errors.Add("lbSpecialCommentType1",String.Format(Resources.strings.CCS_RequiredField,"Contact Type"))
        End If
'End lbSpecialCommentType1 validate

'Record STUDENT_COMMENT Event OnValidate. Action Custom Code @96-73254650
    ' -------------------------
    ' Write your own code here.
    ' -------------------------
'End Record STUDENT_COMMENT Event OnValidate. Action Custom Code

'Record STUDENT_COMMENT Item Class tail @255-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_COMMENT Item Class tail

'Record STUDENT_COMMENT Data Provider Class @255-16077315
Public Class STUDENT_COMMENTDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_COMMENT Data Provider Class

'Record STUDENT_COMMENT Data Provider Class Variables @255-65AB9189
    Protected lbSpecialCommentTypeDataCommand As DataCommand=new TableCommand("SELECT SPECIAL_FLAG, PUBLIC_FLAG, COMMENT_DESCRIPTION, " & vbCrLf & _
          "COMMENT_TYPE " & vbCrLf & _
          "FROM COMMENT_TYPE {SQL_Where} {SQL_OrderBy}", New String(){"expr118"},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected lbSpecialCommentType1DataCommand As DataCommand=new TableCommand("SELECT SPECIAL_FLAG, PUBLIC_FLAG, COMMENT_DESCRIPTION, " & vbCrLf & _
          "COMMENT_TYPE " & vbCrLf & _
          "FROM COMMENT_TYPE {SQL_Where} {SQL_OrderBy}", New String(){"expr269","And","expr270"},Settings.connDECVPRODSQL2005DataAccessObject )
    Public UrlCOMMENT_ID As IntegerParameter
    Public CtrlSTUDENT_ID As TextParameter
    Public CtrlCOMMENT As TextParameter
    Public Expr281 As TextParameter
    Public CtrlHidden_CommentType As TextParameter
    Protected item As STUDENT_COMMENTItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_COMMENT Data Provider Class Variables

'Record STUDENT_COMMENT Data Provider Class Constructor @255-BE4D0AEC

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_COMMENT {SQL_Where} {SQL_OrderBy}", New String(){"COMMENT_ID278"},Settings.connDECVPRODSQL2005DataAccessObject )
        Insert=new SqlCommand("insert into STUDENT_COMMENT ([COMMENT_ID],[STUDENT_ID],[COMMENT],[LAST_ALTERED_BY],[LAST_A" & _
          "LTERED_DATE],[ACTIVE_STATUS],[COMMENT_TYPE]) " & vbCrLf & _
          "select (select (max(COMMENT_ID+1)) from STUDENT_COMMENT) , {STUDENT_ID},'{COMMENTTEXT}',UP" & _
          "PER('{LAST_ALTERED_BY}'), getdate(),'F','{COMMENT_TYPE}'",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_COMMENT Data Provider Class Constructor

'Record STUDENT_COMMENT Data Provider Class LoadParams Method @255-176311CA

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlCOMMENT_ID))
    End Function
'End Record STUDENT_COMMENT Data Provider Class LoadParams Method

'Record STUDENT_COMMENT Data Provider Class CheckUnique Method @255-94B55604

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_COMMENTItem) As Boolean
        Return True
    End Function
'End Record STUDENT_COMMENT Data Provider Class CheckUnique Method

'Record STUDENT_COMMENT Data Provider Class PrepareInsert Method @255-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STUDENT_COMMENT Data Provider Class PrepareInsert Method

'Record STUDENT_COMMENT Data Provider Class PrepareInsert Method tail @255-E31F8E2A
    End Sub
'End Record STUDENT_COMMENT Data Provider Class PrepareInsert Method tail

'Record STUDENT_COMMENT Data Provider Class Insert Method @255-849D9399

    Public Function InsertItem(ByVal item As STUDENT_COMMENTItem) As Integer
        Me.item = item
'End Record STUDENT_COMMENT Data Provider Class Insert Method

'Record STUDENT_COMMENT Build insert @255-916B2292
        Insert.Parameters.Clear()
        CType(Insert,SqlCommand).AddParameter("STUDENT_ID",item.STUDENT_ID, "")
        CType(Insert,SqlCommand).AddParameter("COMMENTTEXT",item.COMMENT, "")
        CType(Insert,SqlCommand).AddParameter("LAST_ALTERED_BY",Expr281, "")
        CType(Insert,SqlCommand).AddParameter("COMMENT_TYPE",item.Hidden_CommentType, "")
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
            result = ExecuteInsert()
        Catch ee As Exception
            E = ee
        Finally
'End Record STUDENT_COMMENT Build insert

'Record STUDENT_COMMENT AfterExecuteInsert @255-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_COMMENT AfterExecuteInsert

'Record STUDENT_COMMENT Data Provider Class GetResultSet Method @255-8D4636B3

    Public Sub FillItem(ByVal item As STUDENT_COMMENTItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_COMMENT Data Provider Class GetResultSet Method

'Record STUDENT_COMMENT BeforeBuildSelect @255-A50C396A
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("COMMENT_ID278",UrlCOMMENT_ID, "","COMMENT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_COMMENT BeforeBuildSelect

'Record STUDENT_COMMENT BeforeExecuteSelect @255-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_COMMENT BeforeExecuteSelect

'Record STUDENT_COMMENT AfterExecuteSelect @255-F41E81CB
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.lblSTUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.COMMENT.SetValue(dr(i)("COMMENT"),"")
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.hidden_STATUS.SetValue(dr(i)("ACTIVE_STATUS"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record STUDENT_COMMENT AfterExecuteSelect

'ListBox lbSpecialCommentType Initialize Data Source @263-B4FC17B6
        lbSpecialCommentTypeDataCommand.Dao._optimized = False
        Dim lbSpecialCommentTypetableIndex As Integer = 0
        lbSpecialCommentTypeDataCommand.OrderBy = "PUBLIC_FLAG desc, COMMENT_TYPE_ID"
        lbSpecialCommentTypeDataCommand.Parameters.Clear()
        lbSpecialCommentTypeDataCommand.Parameters.Add("expr118","(STATUS = 1)")
'End ListBox lbSpecialCommentType Initialize Data Source

'ListBox lbSpecialCommentType BeforeExecuteSelect @263-39A15467
        Try
            ListBoxSource=lbSpecialCommentTypeDataCommand.Execute().Tables(lbSpecialCommentTypetableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox lbSpecialCommentType BeforeExecuteSelect

'ListBox lbSpecialCommentType AfterExecuteSelect @263-3ABAE121
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("COMMENT_TYPE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("COMMENT_DESCRIPTION")
            item.lbSpecialCommentTypeItems.Add(Key, Val)
        Next
'End ListBox lbSpecialCommentType AfterExecuteSelect

'ListBox lbSpecialCommentType1 Initialize Data Source @68-A96ED265
        lbSpecialCommentType1DataCommand.Dao._optimized = False
        Dim lbSpecialCommentType1tableIndex As Integer = 0
        lbSpecialCommentType1DataCommand.OrderBy = "PUBLIC_FLAG desc, COMMENT_TYPE_ID"
        lbSpecialCommentType1DataCommand.Parameters.Clear()
        lbSpecialCommentType1DataCommand.Parameters.Add("expr269","(SPECIAL_FLAG = 0)")
        lbSpecialCommentType1DataCommand.Parameters.Add("expr270","(STATUS = 1)")
'End ListBox lbSpecialCommentType1 Initialize Data Source

'ListBox lbSpecialCommentType1 BeforeExecuteSelect @68-E6D2AD27
        Try
            ListBoxSource=lbSpecialCommentType1DataCommand.Execute().Tables(lbSpecialCommentType1tableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox lbSpecialCommentType1 BeforeExecuteSelect

'ListBox lbSpecialCommentType1 Event AfterExecuteSelect. Action Custom Code @94-73254650
    ' -------------------------
    ' Write your own code here.
    ' -------------------------
'End ListBox lbSpecialCommentType1 Event AfterExecuteSelect. Action Custom Code

'ListBox lbSpecialCommentType1 AfterExecuteSelect @68-8F28B43F
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("COMMENT_TYPE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("COMMENT_DESCRIPTION")
            item.lbSpecialCommentType1Items.Add(Key, Val)
        Next
'End ListBox lbSpecialCommentType1 AfterExecuteSelect

'ListBox lbCannedResponses AfterExecuteSelect @97-8A69D4D7
        
item.lbCannedResponsesItems.Add("Message Left","Message Left")
item.lbCannedResponsesItems.Add("Emailed about outstanding work","Emailed about outstanding work")
item.lbCannedResponsesItems.Add("Tried calling, No answer","Tried calling, No answer")
item.lbCannedResponsesItems.Add("Email bounced back","Email bounced back")
item.lbCannedResponsesItems.Add("Lack of submissions discussed","Lack of submissions discussed")
item.lbCannedResponsesItems.Add("Work issues discussed","Work issues discussed")
item.lbCannedResponsesItems.Add("Change of subjects","Change of subjects")
item.lbCannedResponsesItems.Add("Amber letter sent","Amber letter sent")
item.lbCannedResponsesItems.Add("Red letter sent","Red letter sent")
item.lbCannedResponsesItems.Add("Student Contact Hour","Student Contact Hour")
'End ListBox lbCannedResponses AfterExecuteSelect

'Record STUDENT_COMMENT AfterExecuteSelect tail @255-E31F8E2A
    End Sub
'End Record STUDENT_COMMENT AfterExecuteSelect tail

'Record STUDENT_COMMENT Data Provider Class @255-A61BA892
End Class

'End Record STUDENT_COMMENT Data Provider Class

'Grid Grid_DisplayComments Item Class @288-3F7F2E3A
Public Class Grid_DisplayCommentsItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public COMMENT As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public COMMENT_TYPE As TextField
    Public link_editcomment As TextField
    Public link_editcommentHref As Object
    Public link_editcommentHrefParameters As LinkParameterCollection
    Public Sub New()
    COMMENT = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    COMMENT_TYPE = New TextField("", Nothing)
    link_editcomment = New TextField("",Nothing)
    link_editcommentHrefParameters = New LinkParameterCollection()
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "COMMENT"
                    Return Me.COMMENT
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "COMMENT_TYPE"
                    Return Me.COMMENT_TYPE
                Case "link_editcomment"
                    Return Me.link_editcomment
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "COMMENT"
                    Me.COMMENT = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "COMMENT_TYPE"
                    Me.COMMENT_TYPE = CType(Value,TextField)
                Case "link_editcomment"
                    Me.link_editcomment = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid Grid_DisplayComments Item Class

'Grid Grid_DisplayComments Data Provider Class Header @288-CB75F408
Public Class Grid_DisplayCommentsDataProvider
Inherits GridDataProviderBase
'End Grid Grid_DisplayComments Data Provider Class Header

'Grid Grid_DisplayComments Data Provider Class Variables @288-9DBBBA2D

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {"LAST_ALTERED_DATE desc"}
    Private SortFieldsNamesDesc As String() = New string() {"LAST_ALTERED_DATE desc"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 30
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As FloatParameter
'End Grid Grid_DisplayComments Data Provider Class Variables

'Grid Grid_DisplayComments Data Provider Class GetResultSet Method @288-EFFE7626

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM STUDENT_COMMENT {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID299","And","expr300","And","expr301"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STUDENT_COMMENT", New String(){"STUDENT_ID299","And","expr300","And","expr301"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid Grid_DisplayComments Data Provider Class GetResultSet Method

'Grid Grid_DisplayComments Data Provider Class GetResultSet Method @288-522E69D9
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As Grid_DisplayCommentsItem()
'End Grid Grid_DisplayComments Data Provider Class GetResultSet Method

'Before build Select @288-8A087342
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID299",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        Select_.Parameters.Add("expr300","(ACTIVE_STATUS = 'F')")
        Select_.Parameters.Add("expr301","(COMMENT_TYPE not like 'CONTACT%')")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @288-D27BF5A3
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As Grid_DisplayCommentsItem
        If ops.AllowRead Then
            Try
                If RecordsPerPage > 0 Then
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _PagesCount = ExecuteCount()
                    m_recordCount = _PagesCount
                    If _PagesCount Mod RecordsPerPage>0 Then
                        _PagesCount = (_PagesCount\RecordsPerPage)+1
                    Else
                        _PagesCount = _PagesCount\RecordsPerPage
                    End If
                Else
                    ds=ExecuteSelect()
                    If ds.Tables(tableIndex).Rows.Count<>0 Then 
                        _PagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                    End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @288-DF0D8388
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New Grid_DisplayCommentsItem(dr.Count-1) {}
'End After execute Select

'After execute Select @288-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @288-814327D3
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as Grid_DisplayCommentsItem = New Grid_DisplayCommentsItem()
                item.COMMENT.SetValue(dr(i)("COMMENT"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.COMMENT_TYPE.SetValue(dr(i)("COMMENT_TYPE"),"")
                item.link_editcommentHref = "Student_Comments_editown.aspx"
                item.link_editcommentHrefParameters.Add("COMMENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("COMMENT_ID").ToString()))
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @288-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

