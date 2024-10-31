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

Namespace DECV_PROD2007.Student_GreenLetters_maint 'Namespace @1-AC1F8100

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

'EditableGrid viewMaintainSearchRequest Item Class @3-C4316568
Public Class viewMaintainSearchRequestItem
    Public errors As NameValueCollection = New NameValueCollection()
    Public RowId As Integer
    Private _deleteAllowed As Boolean = False
    Private _isNew As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public viewMaintainSearchRequest_TotalRecords As TextField
    Public STUDENT_ID As FloatField
    Public STUDENT_IDHref As Object
    Public STUDENT_IDHrefParameters As LinkParameterCollection
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public YEAR_LEVEL As IntegerField
    Public PASTORAL_CARE_ID As TextField
    Public FIRST_ADDED_DATE As DateField
    Public GREEN_LETTER_SENT_FLAG As TextField
    Public GREEN_LETTER_SENT_FLAGItems As ItemCollection
    Public GREEN_LETTER_SENT_DATE As DateField
    Public AMBER_LETTER_SENT_FLAG As TextField
    Public AMBER_LETTER_SENT_FLAGItems As ItemCollection
    Public AMBER_LETTER_SENT_DATE As DateField
    Public RED_LETTER_SENT_FLAG As TextField
    Public RED_LETTER_SENT_FLAGItems As ItemCollection
    Public RED_LETTER_SENT_DATE As DateField
    Public LAST_ALTERED_BY As TextField
    Public CheckBox_Delete As BooleanField
    Public CheckBox_DeleteCheckedValue As BooleanField
    Public CheckBox_DeleteUncheckedValue As BooleanField
    Public hidden_DaysSince_Green As IntegerField
    Public hidden_DaysSince_Amber As IntegerField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    viewMaintainSearchRequest_TotalRecords = New TextField("", Nothing)
    STUDENT_ID = New FloatField("",Nothing)
    STUDENT_IDHrefParameters = New LinkParameterCollection()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    YEAR_LEVEL = New IntegerField("", Nothing)
    PASTORAL_CARE_ID = New TextField("", Nothing)
    FIRST_ADDED_DATE = New DateField("dd MMM yyyy", Nothing)
    GREEN_LETTER_SENT_FLAG = New TextField("", Nothing)
    GREEN_LETTER_SENT_FLAGItems = New ItemCollection()
    GREEN_LETTER_SENT_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    AMBER_LETTER_SENT_FLAG = New TextField("", Nothing)
    AMBER_LETTER_SENT_FLAGItems = New ItemCollection()
    AMBER_LETTER_SENT_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    RED_LETTER_SENT_FLAG = New TextField("", Nothing)
    RED_LETTER_SENT_FLAGItems = New ItemCollection()
    RED_LETTER_SENT_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    CheckBox_Delete = New BooleanField(Settings.BoolFormat, false)
    CheckBox_DeleteCheckedValue = New BooleanField(Settings.BoolFormat, true)
    CheckBox_DeleteUncheckedValue = New BooleanField(Settings.BoolFormat, false)
    hidden_DaysSince_Green = New IntegerField("", 0)
    hidden_DaysSince_Amber = New IntegerField("", 0)
    LAST_ALTERED_DATE = New DateField("dd MMM yyyy", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase
        Get
            Select fieldName
                Case "ENROLMENT_YEARField"
                    Return Me.ENROLMENT_YEARField
                Case "IDField"
                    Return Me.IDField
                Case "viewMaintainSearchRequest_TotalRecords"
                    Return Me.viewMaintainSearchRequest_TotalRecords
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "YEAR_LEVEL"
                    Return Me.YEAR_LEVEL
                Case "PASTORAL_CARE_ID"
                    Return Me.PASTORAL_CARE_ID
                Case "FIRST_ADDED_DATE"
                    Return Me.FIRST_ADDED_DATE
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
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "CheckBox_Delete"
                    Return Me.CheckBox_Delete
                Case "hidden_DaysSince_Green"
                    Return Me.hidden_DaysSince_Green
                Case "hidden_DaysSince_Amber"
                    Return Me.hidden_DaysSince_Amber
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ENROLMENT_YEARField"
                    Me.ENROLMENT_YEARField = CType(Value,FloatField)
                Case "IDField"
                    Me.IDField = CType(Value,IntegerField)
                Case "viewMaintainSearchRequest_TotalRecords"
                    Me.viewMaintainSearchRequest_TotalRecords = CType(Value,TextField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "YEAR_LEVEL"
                    Me.YEAR_LEVEL = CType(Value,IntegerField)
                Case "PASTORAL_CARE_ID"
                    Me.PASTORAL_CARE_ID = CType(Value,TextField)
                Case "FIRST_ADDED_DATE"
                    Me.FIRST_ADDED_DATE = CType(Value,DateField)
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
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "CheckBox_Delete"
                    Me.CheckBox_Delete = CType(Value,BooleanField)
                Case "hidden_DaysSince_Green"
                    Me.hidden_DaysSince_Green = CType(Value,IntegerField)
                Case "hidden_DaysSince_Amber"
                    Me.hidden_DaysSince_Amber = CType(Value,IntegerField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
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
            result = IsNothing(GREEN_LETTER_SENT_FLAG.Value) And result
            result = IsNothing(GREEN_LETTER_SENT_DATE.Value) And result
            result = IsNothing(AMBER_LETTER_SENT_FLAG.Value) And result
            result = IsNothing(AMBER_LETTER_SENT_DATE.Value) And result
            result = IsNothing(RED_LETTER_SENT_FLAG.Value) And result
            result = IsNothing(RED_LETTER_SENT_DATE.Value) And result
            result = IsNothing(CheckBox_Delete.Value) And result
            result = IsNothing(hidden_DaysSince_Green.Value) And result
            result = IsNothing(hidden_DaysSince_Amber.Value) And result
            Return result
        End Get
    End Property

    Public IsDeleted As Boolean = False
    Public IsUpdated As Boolean = False
    Public ENROLMENT_YEARField As FloatField = New FloatField()
    Public IDField As IntegerField = New IntegerField()
    Public Function Validate(ByVal provider As viewMaintainSearchRequestDataProvider) As Boolean
'End EditableGrid viewMaintainSearchRequest Item Class

'EditableGrid viewMaintainSearchRequest Item Class tail @3-11D8DCF0
        Return errors.Count = 0
    End Function
    Public RawData As DataRow = Nothing
End Class
'End EditableGrid viewMaintainSearchRequest Item Class tail

'EditableGrid viewMaintainSearchRequest Data Provider Class Header @3-38889471
Public Class viewMaintainSearchRequestDataProvider
Inherits EditableGridDataProviderBase
'End EditableGrid viewMaintainSearchRequest Data Provider Class Header

'Grid viewMaintainSearchRequest Data Provider Class Variables @3-0E68FDE4

    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_ID
        Sorter_SURNAME
        Sorter_FIRST_NAME
        Sorter_YEAR_LEVEL
        Sorter_PASTORAL_CARE_ID
        Sorter_FIRST_ADDED_DATE
        Sorter_GREEN_LETTER_SENT_FLAG
        Sorter_GREEN_LETTER_SENT_DATE
        Sorter_AMBER_LETTER_SENT_FLAG
        Sorter_AMBER_LETTER_SENT_DATE
        Sorter_RED_LETTER_SENT_FLAG
        Sorter_RED_LETTER_SENT_DATE
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE1
    End Enum

    Private SortFieldsNames As String() = New String() {"","STUDENT_ID","SURNAME","FIRST_NAME","YEAR_LEVEL","PASTORAL_CARE_ID","FIRST_ADDED_DATE","GREEN_LETTER_SENT_FLAG","GREEN_LETTER_SENT_DATE","AMBER_LETTER_SENT_FLAG","AMBER_LETTER_SENT_DATE","RED_LETTER_SENT_FLAG","RED_LETTER_SENT_DATE","LAST_ALTERED_BY","LAST_ALTERED_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"","STUDENT_ID DESC","SURNAME DESC","FIRST_NAME DESC","YEAR_LEVEL DESC","PASTORAL_CARE_ID DESC","FIRST_ADDED_DATE DESC","GREEN_LETTER_SENT_FLAG DESC","GREEN_LETTER_SENT_DATE DESC","AMBER_LETTER_SENT_FLAG DESC","AMBER_LETTER_SENT_DATE DESC","RED_LETTER_SENT_FLAG DESC","RED_LETTER_SENT_DATE DESC","LAST_ALTERED_BY DESC","LAST_ALTERED_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 20
    Public PageNumber As Integer = 1
    Public Urls_STAFF_ID  As TextParameter
    Public Urls_STUDENT_ID  As FloatParameter
    Public Urls_SUBSCHOOL  As TextParameter
    Public CtrlGREEN_LETTER_SENT_FLAG  As TextParameter
    Public CtrlGREEN_LETTER_SENT_DATE  As DateParameter
    Public CtrlAMBER_LETTER_SENT_FLAG  As TextParameter
    Public CtrlAMBER_LETTER_SENT_DATE  As DateParameter
    Public CtrlRED_LETTER_SENT_FLAG  As TextParameter
    Public CtrlRED_LETTER_SENT_DATE  As DateParameter
    Public Expr114  As TextParameter
    Public Expr117  As TextParameter
'End Grid viewMaintainSearchRequest Data Provider Class Variables

'EditableGrid viewMaintainSearchRequest Data Provider Class Constructor @3-5466365F

    Public Sub New()
        Select_=new SqlCommand("SELECT GREEN_AMBER_RED_LETTERS.*, SURNAME, FIRST_NAME, YEAR_LEVEL, PASTORAL_CARE_ID, dated" & _
          "iff(DAY, isnull(GREEN_AMBER_RED_LETTERS.GREEN_LETTER_SENT_DATE, getdate()), getdate()) AS " & _
          "DaysSince_Green," & vbCrLf & _
          "datediff(DAY, isnull(GREEN_AMBER_RED_LETTERS.AMBER_LETTER_SENT_DATE, getdate()), getdate()" & _
          ") AS DaysSince_Amber, datediff(DAY, isnull(FIRST_ADDED_DATE, getdate()), getdate()) AS Day" & _
          "sSince_Added " & vbCrLf & _
          "FROM viewMaintainSearchRequest_SupportTeacher INNER JOIN GREEN_AMBER_RED_LETTERS ON" & vbCrLf & _
          "viewMaintainSearchRequest_SupportTeacher.ENROLMENT_YEAR = GREEN_AMBER_RED_LETTERS.ENROLMEN" & _
          "T_YEAR AND viewMaintainSearchRequest_SupportTeacher.STUDENT_ID = GREEN_AMBER_RED_LETTERS.S" & _
          "TUDENT_ID" & vbCrLf & _
          "WHERE viewMaintainSearchRequest_SupportTeacher.PASTORAL_CARE_ID LIKE '%{s_STAFF_ID}%'" & vbCrLf & _
          "AND GREEN_AMBER_RED_LETTERS.STUDENT_ID = (case when {s_STUDENT_ID}=0 then GREEN_AMBER_RED_" & _
          "LETTERS.STUDENT_ID else {s_STUDENT_ID} end) " & vbCrLf & _
          "AND ( GREEN_AMBER_RED_LETTERS.ENROLMENT_YEAR = YEAR(GETDATE()) ) " & vbCrLf & _
          "and YEAR_LEVEL >= (case when '{s_SUBSCHOOL}'='F-9' then 0 else 10 end)" & vbCrLf & _
          "and YEAR_LEVEL <= (case when '{s_SUBSCHOOL}'='F-9' then 9 else 12 end)",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (SELECT GREEN_AMBER_RED_LETTERS.*, SURNAME, FIRST_NAME, YEAR_LEVEL, P" & _
          "ASTORAL_CARE_ID, datediff(DAY, isnull(GREEN_AMBER_RED_LETTERS.GREEN_LETTER_SENT_DATE, getd" & _
          "ate()), getdate()) AS DaysSince_Green," & vbCrLf & _
          "datediff(DAY, isnull(GREEN_AMBER_RED_LETTERS.AMBER_LETTER_SENT_DATE, getdate()), getdate()" & _
          ") AS DaysSince_Amber, datediff(DAY, isnull(FIRST_ADDED_DATE, getdate()), getdate()) AS Day" & _
          "sSince_Added " & vbCrLf & _
          "FROM viewMaintainSearchRequest_SupportTeacher INNER JOIN GREEN_AMBER_RED_LETTERS ON" & vbCrLf & _
          "viewMaintainSearchRequest_SupportTeacher.ENROLMENT_YEAR = GREEN_AMBER_RED_LETTERS.ENROLMEN" & _
          "T_YEAR AND viewMaintainSearchRequest_SupportTeacher.STUDENT_ID = GREEN_AMBER_RED_LETTERS.S" & _
          "TUDENT_ID" & vbCrLf & _
          "WHERE viewMaintainSearchRequest_SupportTeacher.PASTORAL_CARE_ID LIKE '%{s_STAFF_ID}%'" & vbCrLf & _
          "AND GREEN_AMBER_RED_LETTERS.STUDENT_ID = (case when {s_STUDENT_ID}=0 then GREEN_AMBER_RED_" & _
          "LETTERS.STUDENT_ID else {s_STUDENT_ID} end) " & vbCrLf & _
          "AND ( GREEN_AMBER_RED_LETTERS.ENROLMENT_YEAR = YEAR(GETDATE()) ) " & vbCrLf & _
          "and YEAR_LEVEL >= (case when '{s_SUBSCHOOL}'='F-9' then 0 else 10 end)" & vbCrLf & _
          "and YEAR_LEVEL <= (case when '{s_SUBSCHOOL}'='F-9' then 9 else 12 end)) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End EditableGrid viewMaintainSearchRequest Data Provider Class Constructor

'Record viewMaintainSearchRequest Data Provider Class CheckUnique Method @3-8B967AE8

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As viewMaintainSearchRequestItem) As Boolean
        Return True
    End Function
'End Record viewMaintainSearchRequest Data Provider Class CheckUnique Method

'EditableGrid viewMaintainSearchRequest Data Provider Class Update Method @3-DDA4BD61
    Protected Function UpdateItem(ByVal item As viewMaintainSearchRequestItem) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        IsParametersPassed = Not(IsNothing(item.ENROLMENT_YEARField) Or IsNothing(item.IDField))
        Dim Update As DataCommand=new TableCommand("UPDATE GREEN_AMBER_RED_LETTERS SET {Values}", New String(){"ENROLMENT_YEAR115","And","ID116"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End EditableGrid viewMaintainSearchRequest Data Provider Class Update Method

'EditableGrid viewMaintainSearchRequest BeforeBuildUpdate @3-E2443AED
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("ENROLMENT_YEAR115",item.ENROLMENT_YEARField, "","ENROLMENT_YEAR",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ID116",item.IDField, "","ID",Condition.Equal,False)
        allEmptyFlag = item.GREEN_LETTER_SENT_FLAG.IsEmpty And allEmptyFlag
        If IsNothing(item.GREEN_LETTER_SENT_FLAG.Value) Then
        valuesList = valuesList & "GREEN_LETTER_SENT_FLAG=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "GREEN_LETTER_SENT_FLAG=" & Update.Dao.ToSql(item.GREEN_LETTER_SENT_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        allEmptyFlag = item.GREEN_LETTER_SENT_DATE.IsEmpty And allEmptyFlag
        If IsNothing(item.GREEN_LETTER_SENT_DATE.Value) Then
        valuesList = valuesList & "GREEN_LETTER_SENT_DATE=" & Update.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        valuesList = valuesList & "GREEN_LETTER_SENT_DATE=" & Update.Dao.ToSql(item.GREEN_LETTER_SENT_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        allEmptyFlag = item.AMBER_LETTER_SENT_FLAG.IsEmpty And allEmptyFlag
        If IsNothing(item.AMBER_LETTER_SENT_FLAG.Value) Then
        valuesList = valuesList & "AMBER_LETTER_SENT_FLAG=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "AMBER_LETTER_SENT_FLAG=" & Update.Dao.ToSql(item.AMBER_LETTER_SENT_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        allEmptyFlag = item.AMBER_LETTER_SENT_DATE.IsEmpty And allEmptyFlag
        If IsNothing(item.AMBER_LETTER_SENT_DATE.Value) Then
        valuesList = valuesList & "AMBER_LETTER_SENT_DATE=" & Update.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        valuesList = valuesList & "AMBER_LETTER_SENT_DATE=" & Update.Dao.ToSql(item.AMBER_LETTER_SENT_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        allEmptyFlag = item.RED_LETTER_SENT_FLAG.IsEmpty And allEmptyFlag
        If IsNothing(item.RED_LETTER_SENT_FLAG.Value) Then
        valuesList = valuesList & "RED_LETTER_SENT_FLAG=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "RED_LETTER_SENT_FLAG=" & Update.Dao.ToSql(item.RED_LETTER_SENT_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        allEmptyFlag = item.RED_LETTER_SENT_DATE.IsEmpty And allEmptyFlag
        If IsNothing(item.RED_LETTER_SENT_DATE.Value) Then
        valuesList = valuesList & "RED_LETTER_SENT_DATE=" & Update.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        valuesList = valuesList & "RED_LETTER_SENT_DATE=" & Update.Dao.ToSql(item.RED_LETTER_SENT_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        allEmptyFlag = (Expr114 Is Nothing) And allEmptyFlag
        If Not (Expr114 Is Nothing) Then
        If IsNothing(Expr114) Then
        valuesList = valuesList & "LAST_ALTERED_DATE=" & Update.Dao.ToSql((NOW()).ToString(),FieldType._Text) & ","
        Else
        valuesList = valuesList & "LAST_ALTERED_DATE=" & Update.Dao.ToSql(Expr114.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = (Expr117 Is Nothing) And allEmptyFlag
        If Not (Expr117 Is Nothing) Then
        If IsNothing(Expr117) Then
        valuesList = valuesList & "LAST_ALTERED_BY=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "LAST_ALTERED_BY=" & Update.Dao.ToSql(Expr117.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
		Update.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
'End EditableGrid viewMaintainSearchRequest BeforeBuildUpdate

'EditableGrid viewMaintainSearchRequest Execute Update  @3-392E25E7
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
'End EditableGrid viewMaintainSearchRequest Execute Update 

'EditableGrid viewMaintainSearchRequest AfterExecuteUpdate @3-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid viewMaintainSearchRequest AfterExecuteUpdate

'Grid viewMaintainSearchRequest Data Provider Class GetResultSet Method @3-F96AA05E
    Public Sub Update(Items As ArrayList, ops As FormSupportedOperations)
        Dim i As Integer

         Dim blob = Newtonsoft.Json.JsonConvert.SerializeObject(Items)
         Diagnostics.Debug.WriteLine(blob)

        For i = 0 To Items.Count - 1
            Dim op As EditableGridOperation = EditableGridOperation.Insert
            Dim isProcessed As Boolean = False
            Dim item As viewMaintainSearchRequestItem = CType(Items(i), viewMaintainSearchRequestItem)
'End Grid viewMaintainSearchRequest Data Provider Class GetResultSet Method

'EditableGrid viewMaintainSearchRequest Data Provider Class Update @3-B4FF46D4
            If Not item.IsUpdated Then
                If Not(item.IsEmptyItem) And ops.AllowUpdate And Not(isProcessed) Then
                    UpdateItem(item)
                    op = EditableGridOperation.Update
                End If
'End EditableGrid viewMaintainSearchRequest Data Provider Class Update

               '2023-05-10|LG| after update, do a small insert into the STUDENT_COMMENT to show comment that letter has been added. Only add comment to items with rbGreenLetterSend = "I". Code charge saves every record when you edit a grid so be careful not to add the comment to all students.
               Try

                  if item.errors.Count = 0 AndAlso item.AMBER_LETTER_SENT_FLAG IsNot Nothing Then
                     System.Diagnostics.Debug.WriteLine("Amber changed")
                  End If

                    


                  Dim commentText As String' = $"TEST COMMENT FOR INSERTING GREEN LETTER"
                  If item.GREEN_LETTER_SENT_DATE.Value Is Nothing
                     Dim daysToAdd As Integer = (DayOfWeek.Thursday - Today.DayOfWeek) Mod 7
                     Dim nextThursday = Today.AddDays(daysToAdd)
                     commentText = $"Green letter requested on Manage Green Letters page. Letter scheduled to be sent on {nextThursday:dd/MM/yyyy}"
                  Else
                     commentText = $"Manual Green letter marked as sent on Manage Green Letters page. Letter was sent on: {item.GREEN_LETTER_SENT_DATE:dd/MM/yyyy} "
                  End If

                  commentText = "GAR ALTERED"

				      Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
				      Dim Sql As String = $"insert into STUDENT_COMMENT ([COMMENT_ID],[STUDENT_ID],[COMMENT],[LAST_ALTERED_BY],[LAST_ALTERED_DATE],[ACTIVE_STATUS],[COMMENT_TYPE]) SELECT (select (max(COMMENT_ID+1)) from STUDENT_COMMENT) , " & NewDao.ToSql(item.STUDENT_ID.Value, FieldType._Text, True) & ", "& NewDao.ToSql(commentText,FieldType._Text) & ", "& NewDao.ToSql(DBUtility.UserLogin.ToUpper,FieldType._Text, True) & ", getdate(), 'A', 'REGULAR'"
				      'NewDao.RunSql(Sql)
	               Catch ex As Exception
                     'LG|Basically a silent catch, I'm not sure how we handle errors here.
                     System.Diagnostics.Debug.WriteLine(ex.Message)
	            End Try

'EditableGrid viewMaintainSearchRequest Data Provider Class AfterUpdate @3-6CCB76B9
                If item.errors.Count = 0 Then item.IsUpdated = True
                OnItemUpdated(New ItemUpdatedEventArgs(op, item))
            End If
        Next i

         blob = Newtonsoft.Json.JsonConvert.SerializeObject(Items)
         Diagnostics.Debug.WriteLine(blob)
    End Sub
'End EditableGrid viewMaintainSearchRequest Data Provider Class AfterUpdate

'EditableGrid viewMaintainSearchRequest Data Provider Class GetResultSet Method @3-D6364CA2
    Public Function GetResultSet(ByRef _pagesCount As Integer, ops As FormSupportedOperations) As viewMaintainSearchRequestItem()
'End EditableGrid viewMaintainSearchRequest Data Provider Class GetResultSet Method

'Before build Select @3-DB0CABAC
        _pagesCount = 0
        Dim E as Exception = Nothing
        Dim j As Integer
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("s_STAFF_ID",Urls_STAFF_ID, "")
        CType(Select_,SqlCommand).AddParameter("s_STUDENT_ID",Urls_STUDENT_ID, "")
        CType(Select_,SqlCommand).AddParameter("s_SUBSCHOOL",Urls_SUBSCHOOL, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy = SortFieldsNames(CInt(SortField)).Trim
        Else
            Select_.OrderBy = SortFieldsNamesDesc(CInt(SortField)).Trim
        End If
    Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @3-939614DD
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

'After execute Select @3-E19E9823
                If Not IsNothing(E) Then Throw E
            End Try
            dr = ds.Tables(tableIndex).Rows
            rowCount = dr.Count
        End If
        Dim result(rowCount - 1) As viewMaintainSearchRequestItem
'End After execute Select

'ListBox GREEN_LETTER_SENT_FLAG AfterExecuteSelect @38-434EE978
    Dim GREEN_LETTER_SENT_FLAGItems As ItemCollection = New ItemCollection()
    
GREEN_LETTER_SENT_FLAGItems.Add("Y","<font color='green'>YES - Send</font>")
GREEN_LETTER_SENT_FLAGItems.Add("N","Do Not Send")
'End ListBox GREEN_LETTER_SENT_FLAG AfterExecuteSelect

'ListBox AMBER_LETTER_SENT_FLAG AfterExecuteSelect @41-C4AF4263
    Dim AMBER_LETTER_SENT_FLAGItems As ItemCollection = New ItemCollection()
    
AMBER_LETTER_SENT_FLAGItems.Add("Y","<font color='orange'>YES - Sent</font>")
AMBER_LETTER_SENT_FLAGItems.Add("N","Not sent")
'End ListBox AMBER_LETTER_SENT_FLAG AfterExecuteSelect

'ListBox RED_LETTER_SENT_FLAG AfterExecuteSelect @44-8D5AC636
    Dim RED_LETTER_SENT_FLAGItems As ItemCollection = New ItemCollection()
    
RED_LETTER_SENT_FLAGItems.Add("Y","<font color='red'>YES - Sent</font>")
RED_LETTER_SENT_FLAGItems.Add("N","Not sent")
'End ListBox RED_LETTER_SENT_FLAG AfterExecuteSelect

'After execute Select tail @3-5650593B
        Dim i as Integer
        For i = 0 To rowCount - 1
            Dim item as viewMaintainSearchRequestItem = New viewMaintainSearchRequestItem()
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.STUDENT_IDHref = "StudentSummary.aspx"
            item.STUDENT_IDHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
            item.STUDENT_IDHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
            item.SURNAME.SetValue(dr(i)("SURNAME"),"")
            item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
            item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
            item.PASTORAL_CARE_ID.SetValue(dr(i)("PASTORAL_CARE_ID"),"")
            item.FIRST_ADDED_DATE.SetValue(dr(i)("FIRST_ADDED_DATE"),Select_.DateFormat)
            item.GREEN_LETTER_SENT_FLAG.SetValue(dr(i)("GREEN_LETTER_SENT_FLAG"),"")
            item.GREEN_LETTER_SENT_FLAGItems = CType(GREEN_LETTER_SENT_FLAGItems.Clone(), ItemCollection)
            item.GREEN_LETTER_SENT_DATE.SetValue(dr(i)("GREEN_LETTER_SENT_DATE"),Select_.DateFormat)
            item.AMBER_LETTER_SENT_FLAG.SetValue(dr(i)("AMBER_LETTER_SENT_FLAG"),"")
            item.AMBER_LETTER_SENT_FLAGItems = CType(AMBER_LETTER_SENT_FLAGItems.Clone(), ItemCollection)
            item.AMBER_LETTER_SENT_DATE.SetValue(dr(i)("AMBER_LETTER_SENT_DATE"),Select_.DateFormat)
            item.RED_LETTER_SENT_FLAG.SetValue(dr(i)("RED_LETTER_SENT_FLAG"),"")
            item.RED_LETTER_SENT_FLAGItems = CType(RED_LETTER_SENT_FLAGItems.Clone(), ItemCollection)
            item.RED_LETTER_SENT_DATE.SetValue(dr(i)("RED_LETTER_SENT_DATE"),Select_.DateFormat)
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.hidden_DaysSince_Green.SetValue(dr(i)("DaysSince_Green"),"")
            item.hidden_DaysSince_Amber.SetValue(dr(i)("DaysSince_Amber"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.ENROLMENT_YEARField.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.IDField.SetValue(dr(i)("ID"),"")
            item.RawData = dr(i)
            result(i)=item
        Next i
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @3-A61BA892
End Class
'End Grid Data Provider tail

'Record GREEN_AMBER_RED_LETTERS_v Item Class @53-30E1FDF4
Public Class GREEN_AMBER_RED_LETTERS_vItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_STAFF_ID As TextField
    Public s_STAFF_IDItems As ItemCollection
    Public s_STUDENT_ID As FloatField
    Public s_SUBSCHOOL As TextField
    Public s_SUBSCHOOLItems As ItemCollection
    Public Sub New()
    s_STAFF_ID = New TextField("", Nothing)
    s_STAFF_IDItems = New ItemCollection()
    s_STUDENT_ID = New FloatField("", Nothing)
    s_SUBSCHOOL = New TextField("", "F-9")
    s_SUBSCHOOLItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As GREEN_AMBER_RED_LETTERS_vItem
        Dim item As GREEN_AMBER_RED_LETTERS_vItem = New GREEN_AMBER_RED_LETTERS_vItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_STAFF_ID")) Then
        item.s_STAFF_ID.SetValue(DBUtility.GetInitialValue("s_STAFF_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_STUDENT_ID")) Then
        item.s_STUDENT_ID.SetValue(DBUtility.GetInitialValue("s_STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_SUBSCHOOL")) Then
        item.s_SUBSCHOOL.SetValue(DBUtility.GetInitialValue("s_SUBSCHOOL"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_STAFF_ID"
                    Return s_STAFF_ID
                Case "s_STUDENT_ID"
                    Return s_STUDENT_ID
                Case "s_SUBSCHOOL"
                    Return s_SUBSCHOOL
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_STAFF_ID"
                    s_STAFF_ID = CType(value, TextField)
                Case "s_STUDENT_ID"
                    s_STUDENT_ID = CType(value, FloatField)
                Case "s_SUBSCHOOL"
                    s_SUBSCHOOL = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As GREEN_AMBER_RED_LETTERS_vDataProvider)
'End Record GREEN_AMBER_RED_LETTERS_v Item Class

'Record GREEN_AMBER_RED_LETTERS_v Item Class tail @53-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record GREEN_AMBER_RED_LETTERS_v Item Class tail

'Record GREEN_AMBER_RED_LETTERS_v Data Provider Class @53-539CFC31
Public Class GREEN_AMBER_RED_LETTERS_vDataProvider
Inherits RecordDataProviderBase
'End Record GREEN_AMBER_RED_LETTERS_v Data Provider Class

'Record GREEN_AMBER_RED_LETTERS_v Data Provider Class Variables @53-5D1E6A3A
    Protected s_STAFF_IDDataCommand As DataCommand=new TableCommand("SELECT staff_ID, " & vbCrLf & _
          "staffname " & vbCrLf & _
          "FROM View_StaffList_Active_Inactive {SQL_Where} {SQL_OrderBy}", New String(){"expr58"},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected item As GREEN_AMBER_RED_LETTERS_vItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record GREEN_AMBER_RED_LETTERS_v Data Provider Class Variables

'Record GREEN_AMBER_RED_LETTERS_v Data Provider Class GetResultSet Method @53-2DE5E934

    Public Sub FillItem(ByVal item As GREEN_AMBER_RED_LETTERS_vItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record GREEN_AMBER_RED_LETTERS_v Data Provider Class GetResultSet Method

'Record GREEN_AMBER_RED_LETTERS_v BeforeBuildSelect @53-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record GREEN_AMBER_RED_LETTERS_v BeforeBuildSelect

'Record GREEN_AMBER_RED_LETTERS_v AfterExecuteSelect @53-83591636
        End If
            IsInsertMode = True
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record GREEN_AMBER_RED_LETTERS_v AfterExecuteSelect

'ListBox s_STAFF_ID Initialize Data Source @55-BE2CFF72
        s_STAFF_IDDataCommand.Dao._optimized = False
        Dim s_STAFF_IDtableIndex As Integer = 0
        s_STAFF_IDDataCommand.OrderBy = "staffname"
        s_STAFF_IDDataCommand.Parameters.Clear()
        s_STAFF_IDDataCommand.Parameters.Add("expr58","(status = 1)")
'End ListBox s_STAFF_ID Initialize Data Source

'ListBox s_STAFF_ID BeforeExecuteSelect @55-DECFA859
        Try
            ListBoxSource=s_STAFF_IDDataCommand.Execute().Tables(s_STAFF_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox s_STAFF_ID BeforeExecuteSelect

'ListBox s_STAFF_ID AfterExecuteSelect @55-56753C2D
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("staff_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("staffname")
            item.s_STAFF_IDItems.Add(Key, Val)
        Next
'End ListBox s_STAFF_ID AfterExecuteSelect

'ListBox s_SUBSCHOOL AfterExecuteSelect @289-13025ED1
        
item.s_SUBSCHOOLItems.Add("F-9","F to Yr 9")
item.s_SUBSCHOOLItems.Add("VCE","Senior (10-11-12)")
'End ListBox s_SUBSCHOOL AfterExecuteSelect

'Record GREEN_AMBER_RED_LETTERS_v AfterExecuteSelect tail @53-E31F8E2A
    End Sub
'End Record GREEN_AMBER_RED_LETTERS_v AfterExecuteSelect tail

'Record GREEN_AMBER_RED_LETTERS_v Data Provider Class @53-A61BA892
End Class

'End Record GREEN_AMBER_RED_LETTERS_v Data Provider Class

'Record GREEN_AMBER_RED_LETTERS Item Class @177-8EDF3733
Public Class GREEN_AMBER_RED_LETTERSItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public STUDENT_ID As FloatField
    Public GREEN_LETTER_SENT_FLAG As TextField
    Public GREEN_LETTER_SENT_FLAGItems As ItemCollection
    Public GREEN_LETTER_SENT_DATE As DateField
    Public LAST_ALTERED_BY As TextField
    Public Sub New()
    STUDENT_ID = New FloatField("", Nothing)
    GREEN_LETTER_SENT_FLAG = New TextField("", Nothing)
    GREEN_LETTER_SENT_FLAGItems = New ItemCollection()
    GREEN_LETTER_SENT_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    LAST_ALTERED_BY = New TextField("", DBUtility.UserID.ToUpper)
    End Sub

    Public Shared Function CreateFromHttpRequest() As GREEN_AMBER_RED_LETTERSItem
        Dim item As GREEN_AMBER_RED_LETTERSItem = New GREEN_AMBER_RED_LETTERSItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("GREEN_LETTER_SENT_FLAG")) Then
        item.GREEN_LETTER_SENT_FLAG.SetValue(DBUtility.GetInitialValue("GREEN_LETTER_SENT_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("GREEN_LETTER_SENT_DATE")) Then
        item.GREEN_LETTER_SENT_DATE.SetValue(DBUtility.GetInitialValue("GREEN_LETTER_SENT_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DatePicker_GREEN_LETTER_SENT_DATE1")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "GREEN_LETTER_SENT_FLAG"
                    Return GREEN_LETTER_SENT_FLAG
                Case "GREEN_LETTER_SENT_DATE"
                    Return GREEN_LETTER_SENT_DATE
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, FloatField)
                Case "GREEN_LETTER_SENT_FLAG"
                    GREEN_LETTER_SENT_FLAG = CType(value, TextField)
                Case "GREEN_LETTER_SENT_DATE"
                    GREEN_LETTER_SENT_DATE = CType(value, DateField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As GREEN_AMBER_RED_LETTERSDataProvider)
'End Record GREEN_AMBER_RED_LETTERS Item Class

'STUDENT_ID validate @182-6D9CF271
        If IsNothing(STUDENT_ID.Value) OrElse STUDENT_ID.Value.ToString() ="" Then
            errors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_RequiredField,"STUDENT ID"))
        End If
'End STUDENT_ID validate

'Record GREEN_AMBER_RED_LETTERS Event OnValidate. Action Declare Variable @203-09865612
        Dim tmpSTUDENT_ID As String
'End Record GREEN_AMBER_RED_LETTERS Event OnValidate. Action Declare Variable

'Record GREEN_AMBER_RED_LETTERS Event OnValidate. Action Declare Variable @205-9B110FE5
        Dim tmpCountValid As Int64 = 0
'End Record GREEN_AMBER_RED_LETTERS Event OnValidate. Action Declare Variable

'Record GREEN_AMBER_RED_LETTERS Event OnValidate. Action Custom Code @204-73254650
    ' -------------------------
    '13-May-2015|EA| handle check for eligible students
    If (errors.Count = 0) Then
    	tmpSTUDENT_ID = STUDENT_ID.Value.ToString()
    ' -------------------------
'End Record GREEN_AMBER_RED_LETTERS Event OnValidate. Action Custom Code

'Record GREEN_AMBER_RED_LETTERS Event OnValidate. Action DLookup @199-6E38E75D
        tmpCountValid = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "count(*)" & " FROM " & "student_enrolment" & " WHERE " & "enrolment_year = year(getdate()) and year_level between 0 and 12 and enrolment_status='E' and student_id = "  &  tmpSTUDENT_ID))).Value, Int64)
'End Record GREEN_AMBER_RED_LETTERS Event OnValidate. Action DLookup

'Record GREEN_AMBER_RED_LETTERS Event OnValidate. Action Custom Code @202-73254650
    ' -------------------------
	    '13-May-2015|EA| check for any students:
	    '	if tmpCountValid = 1 then is Ok and can be added
	    '	if 0 then doesn't meet requirements to be added (Currently Enrolled, between Years 7-10)
	    '17-Mar-2016|EA| change to handle F-10 per Alira
	    If (tmpCountValid = 0) Then
	            errors.Add("STUDENT_ID","Student NOT eligible to be added (either Not Enrolled or not in Year levels F-10 or already in List)")
	    End If
    End If
    ' -------------------------
'End Record GREEN_AMBER_RED_LETTERS Event OnValidate. Action Custom Code

'Record GREEN_AMBER_RED_LETTERS Item Class tail @177-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record GREEN_AMBER_RED_LETTERS Item Class tail

'Record GREEN_AMBER_RED_LETTERS Data Provider Class @177-AB3821A5
Public Class GREEN_AMBER_RED_LETTERSDataProvider
Inherits RecordDataProviderBase
'End Record GREEN_AMBER_RED_LETTERS Data Provider Class

'Record GREEN_AMBER_RED_LETTERS Data Provider Class Variables @177-A5B8A44C
    Public UrlID As IntegerParameter
    Public CtrlSTUDENT_ID As TextParameter
    Public CtrlGREEN_LETTER_SENT_FLAG As TextParameter
    Public CtrlGREEN_LETTER_SENT_DATE As DateParameter
    Public CtrlLAST_ALTERED_BY As TextParameter
    Protected item As GREEN_AMBER_RED_LETTERSItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record GREEN_AMBER_RED_LETTERS Data Provider Class Variables

'Record GREEN_AMBER_RED_LETTERS Data Provider Class Constructor @177-04849825

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM GREEN_AMBER_RED_LETTERS {SQL_Where} {SQL_OrderBy}", New String(){"ID181"},Settings.connDECVPRODSQL2005DataAccessObject )
        Insert=new SqlCommand("INSERT into GREEN_AMBER_RED_LETTERS (STUDENT_ID, ENROLMENT_YEAR, GREEN_LETTER_SENT_FLAG, G" & _
          "REEN_LETTER_SENT_DATE,  LAST_ALTERED_BY, LAST_ALTERED_DATE, FIRST_ADDED_DATE)" & vbCrLf & _
          "SELECT student_id, year(getdate()), '{GREEN_LETTER_SENT_FLAG}', '{GREEN_LETTER_SENT_DATE}'" & _
          ", '{LAST_ALTERED_BY}' , getdate(), getdate()" & vbCrLf & _
          "FROM STUDENT_ENROLMENT" & vbCrLf & _
          "WHERE student_id = {STUDENT_ID} " & vbCrLf & _
          " AND enrolment_status = 'E'" & vbCrLf & _
          " AND enrolment_year = year(getdate())" & vbCrLf & _
          " AND student_id not in (select distinct student_id from GREEN_AMBER_RED_LETTERS where enro" & _
          "lment_year = year(getdate()))",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record GREEN_AMBER_RED_LETTERS Data Provider Class Constructor

'Record GREEN_AMBER_RED_LETTERS Data Provider Class LoadParams Method @177-6CCA1257

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlID))
    End Function
'End Record GREEN_AMBER_RED_LETTERS Data Provider Class LoadParams Method

'Record GREEN_AMBER_RED_LETTERS Data Provider Class CheckUnique Method @177-BF885F8A

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As GREEN_AMBER_RED_LETTERSItem) As Boolean
        Return True
    End Function
'End Record GREEN_AMBER_RED_LETTERS Data Provider Class CheckUnique Method

'Record GREEN_AMBER_RED_LETTERS Data Provider Class PrepareInsert Method @177-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record GREEN_AMBER_RED_LETTERS Data Provider Class PrepareInsert Method

'Record GREEN_AMBER_RED_LETTERS Data Provider Class PrepareInsert Method tail @177-E31F8E2A
    End Sub
'End Record GREEN_AMBER_RED_LETTERS Data Provider Class PrepareInsert Method tail

'Record GREEN_AMBER_RED_LETTERS Data Provider Class Insert Method @177-3CD561B3

    Public Function InsertItem(ByVal item As GREEN_AMBER_RED_LETTERSItem) As Integer
        Me.item = item
'End Record GREEN_AMBER_RED_LETTERS Data Provider Class Insert Method

'Record GREEN_AMBER_RED_LETTERS Build insert @177-067DE722
        Insert.Parameters.Clear()
        CType(Insert,SqlCommand).AddParameter("STUDENT_ID",item.STUDENT_ID, "")
        CType(Insert,SqlCommand).AddParameter("GREEN_LETTER_SENT_FLAG",item.GREEN_LETTER_SENT_FLAG, "")
        CType(Insert,SqlCommand).AddParameter("GREEN_LETTER_SENT_DATE",item.GREEN_LETTER_SENT_DATE, "yyyy-MM-dd HH\:mm\:ss")
        CType(Insert,SqlCommand).AddParameter("LAST_ALTERED_BY",item.LAST_ALTERED_BY, "")
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
            result = ExecuteInsert()
        Catch ee As Exception
            E = ee
        Finally
'End Record GREEN_AMBER_RED_LETTERS Build insert

         '2023-04-05|LG| after insert, do a small insert into the STUDENT_COMMENT to show comment that letter has been added. Only add comment to items with rbGreenLetterSend = "I". Code charge saves every record when you edit a grid so be careful not to add the comment to all students.
         If E Is Nothing
               Try
                  Dim commentText As String' = $"TEST COMMENT FOR INSERTING GREEN LETTER"
                  If item.GREEN_LETTER_SENT_DATE.Value Is Nothing
                     Dim daysToAdd As Integer = (DayOfWeek.Thursday - Today.DayOfWeek) Mod 7
                     Dim nextThursday = Today.AddDays(daysToAdd)
                     commentText = $"Green letter requested on Manage Green Letters page. Letter scheduled to be sent on {nextThursday:dd/MM/yyyy}"
                  Else
                     commentText = $"Manual Green letter marked as sent on Manage Green Letters page. Letter was sent on: {item.GREEN_LETTER_SENT_DATE:dd/MM/yyyy} "
                  End If

				      Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
				      Dim Sql As String = $"insert into STUDENT_COMMENT ([COMMENT_ID],[STUDENT_ID],[COMMENT],[LAST_ALTERED_BY],[LAST_ALTERED_DATE],[ACTIVE_STATUS],[COMMENT_TYPE]) SELECT (select (max(COMMENT_ID+1)) from STUDENT_COMMENT) , " & NewDao.ToSql(item.STUDENT_ID.Value, FieldType._Text, True) & ", "& NewDao.ToSql(commentText,FieldType._Text) & ", "& NewDao.ToSql(DBUtility.UserLogin.ToUpper,FieldType._Text, True) & ", getdate(), 'A', 'REGULAR'"
				      NewDao.RunSql(Sql)
	              Catch ex As Exception
                     'LG|Basically a silent catch, I'm not sure how we handle errors here.
                     System.Diagnostics.Debug.WriteLine(ex.Message)
	            End Try
         End If

'Record GREEN_AMBER_RED_LETTERS AfterExecuteInsert @177-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record GREEN_AMBER_RED_LETTERS AfterExecuteInsert

'Record GREEN_AMBER_RED_LETTERS Data Provider Class GetResultSet Method @177-74546657

    Public Sub FillItem(ByVal item As GREEN_AMBER_RED_LETTERSItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record GREEN_AMBER_RED_LETTERS Data Provider Class GetResultSet Method

'Record GREEN_AMBER_RED_LETTERS BeforeBuildSelect @177-FB89EF39
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("ID181",UrlID, "","ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record GREEN_AMBER_RED_LETTERS BeforeBuildSelect

'Record GREEN_AMBER_RED_LETTERS BeforeExecuteSelect @177-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record GREEN_AMBER_RED_LETTERS BeforeExecuteSelect

'Record GREEN_AMBER_RED_LETTERS AfterExecuteSelect @177-AB37C666
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.GREEN_LETTER_SENT_FLAG.SetValue(dr(i)("GREEN_LETTER_SENT_FLAG"),"")
            item.GREEN_LETTER_SENT_DATE.SetValue(dr(i)("GREEN_LETTER_SENT_DATE"),Select_.DateFormat)
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
        Else
            IsInsertMode = True
        End If
'End Record GREEN_AMBER_RED_LETTERS AfterExecuteSelect

'ListBox GREEN_LETTER_SENT_FLAG AfterExecuteSelect @184-588FCE6B
        
item.GREEN_LETTER_SENT_FLAGItems.Add("Y","<font color='green'>YES - Send</font>")
item.GREEN_LETTER_SENT_FLAGItems.Add("N","Do Not Send")
'End ListBox GREEN_LETTER_SENT_FLAG AfterExecuteSelect

'Record GREEN_AMBER_RED_LETTERS AfterExecuteSelect tail @177-E31F8E2A
    End Sub
'End Record GREEN_AMBER_RED_LETTERS AfterExecuteSelect tail

'Record GREEN_AMBER_RED_LETTERS Data Provider Class @177-A61BA892
End Class

'End Record GREEN_AMBER_RED_LETTERS Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

