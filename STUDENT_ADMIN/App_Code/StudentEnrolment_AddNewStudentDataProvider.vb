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

Namespace DECV_PROD2007.StudentEnrolment_AddNewStudent 'Namespace @1-F65D17CF

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

'Record STUDENT Item Class @2-3F03B07A
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
    Public EnrolYear As IntegerField
    Public ListBox_SubCategory As TextField
    Public ListBox_SubCategoryItems As ItemCollection
    Public ATTENDING_SCHOOL_ID As FloatField
    Public lblAttendingSchoolName As TextField
    Public HOME_SCHOOL_ID As FloatField
    Public lblHomeSchoolName As TextField
    Public CATEGORY_CODE As TextField
    Public SUBCATEGORY_CODE As TextField
    Public EnrolmentCategoryTemp As TextField
    Public lblErrorMessages As TextField
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
    EnrolYear = New IntegerField("", (IIF((month(now())>=9),(year(now())), (year(now())+1))))
    ListBox_SubCategory = New TextField("", Nothing)
    ListBox_SubCategoryItems = New ItemCollection()
    ATTENDING_SCHOOL_ID = New FloatField("", Nothing)
    lblAttendingSchoolName = New TextField("", Nothing)
    HOME_SCHOOL_ID = New FloatField("", Nothing)
    lblHomeSchoolName = New TextField("", Nothing)
    CATEGORY_CODE = New TextField("", Nothing)
    SUBCATEGORY_CODE = New TextField("", Nothing)
    EnrolmentCategoryTemp = New TextField("", Nothing)
    lblErrorMessages = New TextField("", Nothing)
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
        If Not IsNothing(DBUtility.GetInitialValue("DatePicker_BIRTH_DATE")) Then
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
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
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
        If Not IsNothing(DBUtility.GetInitialValue("lblErrorMessages")) Then
        item.lblErrorMessages.SetValue(DBUtility.GetInitialValue("lblErrorMessages"))
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
                Case "lblErrorMessages"
                    Return lblErrorMessages
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
                    EnrolYear = CType(value, IntegerField)
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
                Case "lblErrorMessages"
                    lblErrorMessages = CType(value, TextField)
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

'EnrolDate validate @80-B7BC220D
        If IsNothing(EnrolDate.Value) OrElse EnrolDate.Value.ToString() ="" Then
            errors.Add("EnrolDate",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT DATE"))
        End If
'End EnrolDate validate

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

'BIRTH_DATE validate @10-8E135C21
        If IsNothing(BIRTH_DATE.Value) OrElse BIRTH_DATE.Value.ToString() ="" Then
            errors.Add("BIRTH_DATE",String.Format(Resources.strings.CCS_RequiredField,"DATE OF BIRTH"))
        End If
'End BIRTH_DATE validate

'SEX validate @12-86834B54
        If IsNothing(SEX.Value) OrElse SEX.Value.ToString() ="" Then
            errors.Add("SEX",String.Format(Resources.strings.CCS_RequiredField,"GENDER"))
        End If
'End SEX validate

'listYearLevel validate @65-FDF68D2B
        If IsNothing(listYearLevel.Value) OrElse listYearLevel.Value.ToString() ="" Then
            errors.Add("listYearLevel",String.Format(Resources.strings.CCS_RequiredField,"YEAR LEVEL"))
        End If
'End listYearLevel validate

'ListBox_SubCategory validate @64-E175D8D5
        If IsNothing(ListBox_SubCategory.Value) OrElse ListBox_SubCategory.Value.ToString() ="" Then
            errors.Add("ListBox_SubCategory",String.Format(Resources.strings.CCS_RequiredField,"Category / SubCategory dropdown"))
        End If
'End ListBox_SubCategory validate

'HOME_SCHOOL_ID validate @16-B37E3A03
        If IsNothing(HOME_SCHOOL_ID.Value) OrElse HOME_SCHOOL_ID.Value.ToString() ="" Then
            errors.Add("HOME_SCHOOL_ID",String.Format(Resources.strings.CCS_RequiredField,"HOME SCHOOL ID"))
        End If
'End HOME_SCHOOL_ID validate

'Record STUDENT Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT Item Class tail

'Record STUDENT Data Provider Class @2-17C2BAE9
Public Class STUDENTDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT Data Provider Class

'Record STUDENT Data Provider Class Variables @2-BEC5F28A
    Protected ListBox_SubCategoryDataCommand As DataCommand=new SqlCommand("select rtrim(SUBCATEGORY_FULL_TITLE) as SUBCATEGORY_FULL_TITLE from ENROLMENT_CATEGORY whe" & _
          "re STATUS=1 {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
    Public Expr6 As FloatParameter
    Protected item As STUDENTItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT Data Provider Class Variables

'Record STUDENT Data Provider Class Constructor @2-A48D29D6

    Public Sub New()
        Select_=new TableCommand("SELECT MIDDLE_NAME AS MIDDLE_NAME, STUDENT_ID, SURNAME AS SURNAME, " & vbCrLf & _
          "FIRST_NAME AS FIRST_NAME, BIRTH_DATE, SEX, CATEGORY_CODE, " & vbCrLf & _
          "SUBCATEGORY_CODE," & vbCrLf & _
          "ATTENDING_SCHOOL_ID, HOME_SCHOOL_ID " & vbCrLf & _
          "FROM STUDENT {SQL_Where} {SQL_OrderBy}", New String(){"expr6"},Settings.connDECVPRODSQL2005DataAccessObject )
        Insert=new SpCommand("",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record STUDENT Data Provider Class Constructor

'Record STUDENT Data Provider Class LoadParams Method @2-28120C87

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(Expr6))
    End Function
'End Record STUDENT Data Provider Class LoadParams Method

'Record STUDENT Data Provider Class CheckUnique Method @2-05F73907

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENTItem) As Boolean
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

'Record STUDENT Data Provider Class Insert Method @2-EB7A4C0F

    Public Function InsertItem(ByVal item As STUDENTItem) As Integer
        Me.item = item
'End Record STUDENT Data Provider Class Insert Method

'Record STUDENT Build insert @2-663ABA39
        Insert.Parameters.Clear()
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
            result = ExecuteInsert()
        Catch ee As Exception
            E = ee
        Finally
'End Record STUDENT Build insert

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

'Record STUDENT Data Provider Class Update Method @2-0BA1E9BE

    Public Function UpdateItem(ByVal item As STUDENTItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT SET {Values}", New String(){"expr6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT Data Provider Class Update Method

'Record STUDENT BeforeBuildUpdate @2-11C51EA8
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("expr6",Expr6, "","STUDENT_ID",Condition.Equal,False)
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

'Record STUDENT BeforeBuildSelect @2-9011CFB4
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("expr6",Expr6, "","STUDENT_ID",Condition.Equal,False)
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

'Record STUDENT AfterExecuteSelect @2-B7930FC9
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
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record STUDENT AfterExecuteSelect

'ListBox SEX AfterExecuteSelect @12-17465C4F
        
item.SEXItems.Add("F","Female")
item.SEXItems.Add("M","Male")
'End ListBox SEX AfterExecuteSelect

'ListBox listYearLevel AfterExecuteSelect @65-71450532
        
item.listYearLevelItems.Add("0","0")
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
'End ListBox listYearLevel AfterExecuteSelect

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

'Record STUDENT AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record STUDENT AfterExecuteSelect tail

'Record STUDENT Data Provider Class @2-A61BA892
End Class

'End Record STUDENT Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

