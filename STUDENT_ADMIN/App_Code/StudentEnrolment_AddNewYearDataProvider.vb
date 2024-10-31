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

Namespace DECV_PROD2007.StudentEnrolment_AddNewYear 'Namespace @1-1A5EAD9A

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

'Record STUDENT Item Class @2-CF4272D5
Public Class STUDENTItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public lblStudentID As TextField
    Public EnrolDate As DateField
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public MIDDLE_NAME As TextField
    Public BIRTH_DATE As DateField
    Public SEX As TextField
    Public SEXItems As ItemCollection
    Public listYearLevel As TextField
    Public listYearLevelItems As ItemCollection
    Public EnrolYear As TextField
    Public category As TextField
    Public subcategory As TextField
    Public ATTENDING_SCHOOL_ID As FloatField
    Public lblAttendingSchoolName As TextField
    Public HOME_SCHOOL_ID As FloatField
    Public lblHomeSchoolName As TextField
    Public hidden_STUDENT_ID As TextField
    Public hidden_LAST_ALTERED_BY As TextField
    Public lblErrorMessages As TextField
    Public inputREgionID As IntegerField
    Public PRIVACY_PERMISSION As BooleanField
    Public PRIVACY_PERMISSIONItems As ItemCollection
    Public SEX_SELF_DESCRIBED As TextField
    Public Sub New()
    lblStudentID = New TextField("", Nothing)
    EnrolDate = New DateField("dd\/MM\/yyyy", now())
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    MIDDLE_NAME = New TextField("", Nothing)
    BIRTH_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    SEX = New TextField("", Nothing)
    SEXItems = New ItemCollection()
    listYearLevel = New TextField("", Nothing)
    listYearLevelItems = New ItemCollection()
    EnrolYear = New TextField("", (IIF((month(now())<=9),(year(now())), (year(now())+1))))
    category = New TextField("", Nothing)
    subcategory = New TextField("", Nothing)
    ATTENDING_SCHOOL_ID = New FloatField("", Nothing)
    lblAttendingSchoolName = New TextField("", Nothing)
    HOME_SCHOOL_ID = New FloatField("", Nothing)
    lblHomeSchoolName = New TextField("", Nothing)
    hidden_STUDENT_ID = New TextField("", Nothing)
    hidden_LAST_ALTERED_BY = New TextField("", DBUtility.UserLogin.ToUpper)
    lblErrorMessages = New TextField("", Nothing)
    inputREgionID = New IntegerField("", 0)
    PRIVACY_PERMISSION = New BooleanField(Settings.BoolFormat, Nothing)
    PRIVACY_PERMISSIONItems = New ItemCollection()
    SEX_SELF_DESCRIBED = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENTItem
        Dim item As STUDENTItem = New STUDENTItem()
        If Not IsNothing(DBUtility.GetInitialValue("lblStudentID")) Then
        item.lblStudentID.SetValue(DBUtility.GetInitialValue("lblStudentID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EnrolDate")) Then
        item.EnrolDate.SetValue(DBUtility.GetInitialValue("EnrolDate"))
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
        If Not IsNothing(DBUtility.GetInitialValue("SEX")) Then
        item.SEX.SetValue(DBUtility.GetInitialValue("SEX"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("listYearLevel")) Then
        item.listYearLevel.SetValue(DBUtility.GetInitialValue("listYearLevel"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EnrolYear")) Then
        item.EnrolYear.SetValue(DBUtility.GetInitialValue("EnrolYear"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("category")) Then
        item.category.SetValue(DBUtility.GetInitialValue("category"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("subcategory")) Then
        item.subcategory.SetValue(DBUtility.GetInitialValue("subcategory"))
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
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_STUDENT_ID")) Then
        item.hidden_STUDENT_ID.SetValue(DBUtility.GetInitialValue("hidden_STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY")) Then
        item.hidden_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblErrorMessages")) Then
        item.lblErrorMessages.SetValue(DBUtility.GetInitialValue("lblErrorMessages"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("inputREgionID")) Then
        item.inputREgionID.SetValue(DBUtility.GetInitialValue("inputREgionID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRIVACY_PERMISSION")) Then
        item.PRIVACY_PERMISSION.SetValue(DBUtility.GetInitialValue("PRIVACY_PERMISSION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SEX_SELF_DESCRIBED")) Then
        item.SEX_SELF_DESCRIBED.SetValue(DBUtility.GetInitialValue("SEX_SELF_DESCRIBED"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "lblStudentID"
                    Return lblStudentID
                Case "EnrolDate"
                    Return EnrolDate
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
                Case "listYearLevel"
                    Return listYearLevel
                Case "EnrolYear"
                    Return EnrolYear
                Case "category"
                    Return category
                Case "subcategory"
                    Return subcategory
                Case "ATTENDING_SCHOOL_ID"
                    Return ATTENDING_SCHOOL_ID
                Case "lblAttendingSchoolName"
                    Return lblAttendingSchoolName
                Case "HOME_SCHOOL_ID"
                    Return HOME_SCHOOL_ID
                Case "lblHomeSchoolName"
                    Return lblHomeSchoolName
                Case "hidden_STUDENT_ID"
                    Return hidden_STUDENT_ID
                Case "hidden_LAST_ALTERED_BY"
                    Return hidden_LAST_ALTERED_BY
                Case "lblErrorMessages"
                    Return lblErrorMessages
                Case "inputREgionID"
                    Return inputREgionID
                Case "PRIVACY_PERMISSION"
                    Return PRIVACY_PERMISSION
                Case "SEX_SELF_DESCRIBED"
                    Return SEX_SELF_DESCRIBED
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblStudentID"
                    lblStudentID = CType(value, TextField)
                Case "EnrolDate"
                    EnrolDate = CType(value, DateField)
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
                Case "listYearLevel"
                    listYearLevel = CType(value, TextField)
                Case "EnrolYear"
                    EnrolYear = CType(value, TextField)
                Case "category"
                    category = CType(value, TextField)
                Case "subcategory"
                    subcategory = CType(value, TextField)
                Case "ATTENDING_SCHOOL_ID"
                    ATTENDING_SCHOOL_ID = CType(value, FloatField)
                Case "lblAttendingSchoolName"
                    lblAttendingSchoolName = CType(value, TextField)
                Case "HOME_SCHOOL_ID"
                    HOME_SCHOOL_ID = CType(value, FloatField)
                Case "lblHomeSchoolName"
                    lblHomeSchoolName = CType(value, TextField)
                Case "hidden_STUDENT_ID"
                    hidden_STUDENT_ID = CType(value, TextField)
                Case "hidden_LAST_ALTERED_BY"
                    hidden_LAST_ALTERED_BY = CType(value, TextField)
                Case "lblErrorMessages"
                    lblErrorMessages = CType(value, TextField)
                Case "inputREgionID"
                    inputREgionID = CType(value, IntegerField)
                Case "PRIVACY_PERMISSION"
                    PRIVACY_PERMISSION = CType(value, BooleanField)
                Case "SEX_SELF_DESCRIBED"
                    SEX_SELF_DESCRIBED = CType(value, TextField)
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

'EnrolDate validate @79-B7BC220D
        If IsNothing(EnrolDate.Value) OrElse EnrolDate.Value.ToString() ="" Then
            errors.Add("EnrolDate",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT DATE"))
        End If
'End EnrolDate validate

'listYearLevel validate @65-FDF68D2B
        If IsNothing(listYearLevel.Value) OrElse listYearLevel.Value.ToString() ="" Then
            errors.Add("listYearLevel",String.Format(Resources.strings.CCS_RequiredField,"YEAR LEVEL"))
        End If
'End listYearLevel validate

'EnrolYear validate @80-FFC0582F
        If IsNothing(EnrolYear.Value) OrElse EnrolYear.Value.ToString() ="" Then
            errors.Add("EnrolYear",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT YEAR"))
        End If
'End EnrolYear validate

'inputREgionID validate @102-32D55D13
        If IsNothing(inputREgionID.Value) OrElse inputREgionID.Value.ToString() ="" Then
            errors.Add("inputREgionID",String.Format(Resources.strings.CCS_RequiredField,"REGION APPROVAL CODE"))
        End If
'End inputREgionID validate

'PRIVACY_PERMISSION validate @182-F632AB85
        If IsNothing(PRIVACY_PERMISSION.Value) OrElse PRIVACY_PERMISSION.Value.ToString() ="" Then
            errors.Add("PRIVACY_PERMISSION",String.Format(Resources.strings.CCS_RequiredField,"PRIVACY PERMISSION"))
        End If
'End PRIVACY_PERMISSION validate

'Record STUDENT Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT Item Class tail

'Record STUDENT Data Provider Class @2-17C2BAE9
Public Class STUDENTDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT Data Provider Class

'Record STUDENT Data Provider Class Variables @2-AE90F17C
    Public UrlSTUDENT_ID As FloatParameter
    Public Ctrlhidden_STUDENT_ID As TextParameter
    Public CtrlEnrolYear As IntegerParameter
    Public CtrllistYearLevel As IntegerParameter
    Public Ctrlhidden_LAST_ALTERED_BY As TextParameter
    Public CtrlinputREgionID As TextParameter
    Public CtrlPRIVACY_PERMISSION As BooleanParameter
    Protected item As STUDENTItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT Data Provider Class Variables

'Record STUDENT Data Provider Class Constructor @2-555379EB

    Public Sub New()
        Select_=new TableCommand("SELECT MIDDLE_NAME AS MIDDLE_NAME, STUDENT_ID, SURNAME AS SURNAME, " & vbCrLf & _
          "FIRST_NAME AS FIRST_NAME, BIRTH_DATE, SEX, CATEGORY_CODE, " & vbCrLf & _
          "SUBCATEGORY_CODE," & vbCrLf & _
          "ATTENDING_SCHOOL_ID, HOME_SCHOOL_ID, SEX_SELF_DESCRIBED " & vbCrLf & _
          "FROM STUDENT {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID187"},Settings.connDECVPRODSQL2005DataAccessObject )
        Update=new SqlCommand("insert STUDENT_ENROLMENT (STUDENT_ID,ENROLMENT_YEAR,CAMPUS,YEAR_LEVEL,RECEIPT_NO,ENROLMENT" & _
          "_DATE,ENROLMENT_STATUS,ELIGIBLE_FOR_DISCOUNT,PAID_ON_ENROLMENT " & vbCrLf & _
          ",ELIGIBLE_FOR_FUNDING,DECV_BALANCE,DOCS_LAST_REVIEWED_DATE,NEW_DOCS_REQUIRED,VSL_BALANCE,S" & _
          "UB_SCHOOL,PASTORAL_CARE_ID,LAST_ALTERED_BY,LAST_ALTERED_DATE, REGION_APPROVAL_NUMBER, PRIV" & _
          "ACY_PERMISSION)" & vbCrLf & _
          "values({STUDENT_ID},{txtEnrolYear},'D',{listYearLevel},'',getdate() ,'E',0,0,1,0,getdate()" & _
          ",0,0,'','N-A','{UserLogin}', getdate(), {RegionApprovalNumber},{PRIVACY_PERMISSION})",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record STUDENT Data Provider Class Constructor

'Record STUDENT Data Provider Class LoadParams Method @2-A977A0E9

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID))
    End Function
'End Record STUDENT Data Provider Class LoadParams Method

'Record STUDENT Data Provider Class CheckUnique Method @2-05F73907

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENTItem) As Boolean
        Return True
    End Function
'End Record STUDENT Data Provider Class CheckUnique Method

'Record STUDENT Data Provider Class PrepareUpdate Method @2-0A131024

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
'End Record STUDENT Data Provider Class PrepareUpdate Method

'Record STUDENT Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record STUDENT Data Provider Class PrepareUpdate Method tail

'Record STUDENT Data Provider Class Update Method @2-D36572CB

    Public Function UpdateItem(ByVal item As STUDENTItem) As Integer
        Me.item = item
'End Record STUDENT Data Provider Class Update Method

'Record STUDENT BeforeBuildUpdate @2-88CAA733
        Update.Parameters.Clear()
        CType(Update,SqlCommand).AddParameter("STUDENT_ID",item.hidden_STUDENT_ID, "")
        CType(Update,SqlCommand).AddParameter("txtEnrolYear",item.EnrolYear, "")
        CType(Update,SqlCommand).AddParameter("listYearLevel",item.listYearLevel, "")
        CType(Update,SqlCommand).AddParameter("UserLogin",item.hidden_LAST_ALTERED_BY, "")
        CType(Update,SqlCommand).AddParameter("RegionApprovalNumber",item.inputREgionID, "")
        CType(Update,SqlCommand).AddParameter("PRIVACY_PERMISSION",item.PRIVACY_PERMISSION, Update.BoolFormat)
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
            result = ExecuteUpdate()
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record STUDENT BeforeBuildUpdate

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

'Record STUDENT BeforeBuildSelect @2-34408D62
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID187",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
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

'Record STUDENT AfterExecuteSelect @2-33F8B751
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
            item.category.SetValue(dr(i)("CATEGORY_CODE"),"")
            item.subcategory.SetValue(dr(i)("SUBCATEGORY_CODE"),"")
            item.ATTENDING_SCHOOL_ID.SetValue(dr(i)("ATTENDING_SCHOOL_ID"),"")
            item.HOME_SCHOOL_ID.SetValue(dr(i)("HOME_SCHOOL_ID"),"")
            item.hidden_STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.SEX_SELF_DESCRIBED.SetValue(dr(i)("SEX_SELF_DESCRIBED"),"")
        Else
            IsInsertMode = True
        End If
'End Record STUDENT AfterExecuteSelect

'ListBox SEX AfterExecuteSelect @12-61AF9CE2
        
item.SEXItems.Add("F","Female")
item.SEXItems.Add("M","Male")
item.SEXItems.Add("X","Self-described")
'End ListBox SEX AfterExecuteSelect

'ListBox listYearLevel AfterExecuteSelect @65-F74C6521
        
item.listYearLevelItems.Add("0","0 - Prep")
item.listYearLevelItems.Add("1","1")
item.listYearLevelItems.Add("2","2")
item.listYearLevelItems.Add("3","3")
item.listYearLevelItems.Add("4","4")
item.listYearLevelItems.Add("5","5")
item.listYearLevelItems.Add("6","6")
item.listYearLevelItems.Add("7","7")
item.listYearLevelItems.Add("8","8")
item.listYearLevelItems.Add("9","9")
item.listYearLevelItems.Add("10","10")
item.listYearLevelItems.Add("11","11")
item.listYearLevelItems.Add("12","12")
item.listYearLevelItems.Add("30","Home Schooled")
'End ListBox listYearLevel AfterExecuteSelect

'ListBox PRIVACY_PERMISSION AfterExecuteSelect @182-6EB535AA
        
item.PRIVACY_PERMISSIONItems.Add("Yes","Yes")
item.PRIVACY_PERMISSIONItems.Add("No","No")
'End ListBox PRIVACY_PERMISSION AfterExecuteSelect

'Record STUDENT AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record STUDENT AfterExecuteSelect tail

'Record STUDENT Data Provider Class @2-A61BA892
End Class

'End Record STUDENT Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

