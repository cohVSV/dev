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

Namespace DECV_PROD2007.STAFF_maint 'Namespace @1-4BB7664E

'Page Data Class @1-1CA1EF9E
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public Sub New()
        Link1 = New TextField("",Nothing)
        Link1HrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Link1.SetValue(DBUtility.GetInitialValue("Link1"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Link1"
                    Return Link1
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link1"
                    Link1 = CType(value, TextField)
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

'Record STAFF Item Class @2-420BDB60
Public Class STAFFItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public StaffID As TextField
    Public StaffID_view As TextField
    Public SALUTATION As TextField
    Public SURNAME As TextField
    Public FIRSTNAME As TextField
    Public MIDDLENAME As TextField
    Public TEACHER_FLAG As BooleanField
    Public TEACHER_FLAGCheckedValue As BooleanField
    Public TEACHER_FLAGUncheckedValue As BooleanField
    Public STATUS As BooleanField
    Public STATUSCheckedValue As BooleanField
    Public STATUSUncheckedValue As BooleanField
    Public GROUP_ID As FloatField
    Public GROUP_IDItems As ItemCollection
    Public lblLAST_ALTERED_BY As TextField
    Public lblLAST_ALTERED_DATE As DateField
    Public CAMPUS_CODE As TextField
    Public hidden_LAST_ALTERED_BY As TextField
    Public hidden_LAST_ALTERED_DATE As DateField
    Public LoginID As TextField
    Public lblLoginID As TextField
    Public Hidden_LOGIN_ID As TextField
    Public CheckboxList_SECURITY_FUNCTIONS As TextField
    Public CheckboxList_SECURITY_FUNCTIONSItems As ItemCollection
    Public Hidden_SECURITY_FUNCTIONS As TextField
    Public Sub New()
    StaffID = New TextField("", Nothing)
    StaffID_view = New TextField("", Nothing)
    SALUTATION = New TextField("", Nothing)
    SURNAME = New TextField("", Nothing)
    FIRSTNAME = New TextField("", Nothing)
    MIDDLENAME = New TextField("", Nothing)
    TEACHER_FLAG = New BooleanField(Settings.BoolFormat, False)
    TEACHER_FLAGCheckedValue = New BooleanField(Settings.BoolFormat, True)
    TEACHER_FLAGUncheckedValue = New BooleanField(Settings.BoolFormat, False)
    STATUS = New BooleanField(Settings.BoolFormat, False)
    STATUSCheckedValue = New BooleanField(Settings.BoolFormat, True)
    STATUSUncheckedValue = New BooleanField(Settings.BoolFormat, False)
    GROUP_ID = New FloatField("", Nothing)
    GROUP_IDItems = New ItemCollection()
    lblLAST_ALTERED_BY = New TextField("", DBUtility.UserLogin.ToUpper())
    lblLAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    CAMPUS_CODE = New TextField("", Resources.strings.Text1)
    hidden_LAST_ALTERED_BY = New TextField("", DBUtility.UserLogin.ToUpper())
    hidden_LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    LoginID = New TextField("", Nothing)
    lblLoginID = New TextField("", "LOGIN ID:")
    Hidden_LOGIN_ID = New TextField("", Nothing)
    CheckboxList_SECURITY_FUNCTIONS = New TextField("", Nothing)
    CheckboxList_SECURITY_FUNCTIONSItems = New ItemCollection()
    Hidden_SECURITY_FUNCTIONS = New TextField("", "Z")
    End Sub

    Public Shared Function CreateFromHttpRequest() As STAFFItem
        Dim item As STAFFItem = New STAFFItem()
        If Not IsNothing(DBUtility.GetInitialValue("StaffID")) Then
        item.StaffID.SetValue(DBUtility.GetInitialValue("StaffID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("StaffID_view")) Then
        item.StaffID_view.SetValue(DBUtility.GetInitialValue("StaffID_view"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SALUTATION")) Then
        item.SALUTATION.SetValue(DBUtility.GetInitialValue("SALUTATION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SURNAME")) Then
        item.SURNAME.SetValue(DBUtility.GetInitialValue("SURNAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FIRSTNAME")) Then
        item.FIRSTNAME.SetValue(DBUtility.GetInitialValue("FIRSTNAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MIDDLENAME")) Then
        item.MIDDLENAME.SetValue(DBUtility.GetInitialValue("MIDDLENAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("TEACHER_FLAG")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("TEACHER_FLAG")) Then
            item.TEACHER_FLAG.Value = item.TEACHER_FLAGCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STATUS")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("STATUS")) Then
            item.STATUS.Value = item.STATUSCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("GROUP_ID")) Then
        item.GROUP_ID.SetValue(DBUtility.GetInitialValue("GROUP_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblLAST_ALTERED_BY")) Then
        item.lblLAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("lblLAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblLAST_ALTERED_DATE")) Then
        item.lblLAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("lblLAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CAMPUS_CODE")) Then
        item.CAMPUS_CODE.SetValue(DBUtility.GetInitialValue("CAMPUS_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY")) Then
        item.hidden_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_DATE")) Then
        item.hidden_LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LoginID")) Then
        item.LoginID.SetValue(DBUtility.GetInitialValue("LoginID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblLoginID")) Then
        item.lblLoginID.SetValue(DBUtility.GetInitialValue("lblLoginID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_LOGIN_ID")) Then
        item.Hidden_LOGIN_ID.SetValue(DBUtility.GetInitialValue("Hidden_LOGIN_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CheckboxList_SECURITY_FUNCTIONS")) Then
        item.CheckboxList_SECURITY_FUNCTIONS.SetValue(DBUtility.GetInitialValue("CheckboxList_SECURITY_FUNCTIONS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_SECURITY_FUNCTIONS")) Then
        item.Hidden_SECURITY_FUNCTIONS.SetValue(DBUtility.GetInitialValue("Hidden_SECURITY_FUNCTIONS"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "StaffID"
                    Return StaffID
                Case "StaffID_view"
                    Return StaffID_view
                Case "SALUTATION"
                    Return SALUTATION
                Case "SURNAME"
                    Return SURNAME
                Case "FIRSTNAME"
                    Return FIRSTNAME
                Case "MIDDLENAME"
                    Return MIDDLENAME
                Case "TEACHER_FLAG"
                    Return TEACHER_FLAG
                Case "STATUS"
                    Return STATUS
                Case "GROUP_ID"
                    Return GROUP_ID
                Case "lblLAST_ALTERED_BY"
                    Return lblLAST_ALTERED_BY
                Case "lblLAST_ALTERED_DATE"
                    Return lblLAST_ALTERED_DATE
                Case "CAMPUS_CODE"
                    Return CAMPUS_CODE
                Case "hidden_LAST_ALTERED_BY"
                    Return hidden_LAST_ALTERED_BY
                Case "hidden_LAST_ALTERED_DATE"
                    Return hidden_LAST_ALTERED_DATE
                Case "LoginID"
                    Return LoginID
                Case "lblLoginID"
                    Return lblLoginID
                Case "Hidden_LOGIN_ID"
                    Return Hidden_LOGIN_ID
                Case "CheckboxList_SECURITY_FUNCTIONS"
                    Return CheckboxList_SECURITY_FUNCTIONS
                Case "Hidden_SECURITY_FUNCTIONS"
                    Return Hidden_SECURITY_FUNCTIONS
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "StaffID"
                    StaffID = CType(value, TextField)
                Case "StaffID_view"
                    StaffID_view = CType(value, TextField)
                Case "SALUTATION"
                    SALUTATION = CType(value, TextField)
                Case "SURNAME"
                    SURNAME = CType(value, TextField)
                Case "FIRSTNAME"
                    FIRSTNAME = CType(value, TextField)
                Case "MIDDLENAME"
                    MIDDLENAME = CType(value, TextField)
                Case "TEACHER_FLAG"
                    TEACHER_FLAG = CType(value, BooleanField)
                Case "STATUS"
                    STATUS = CType(value, BooleanField)
                Case "GROUP_ID"
                    GROUP_ID = CType(value, FloatField)
                Case "lblLAST_ALTERED_BY"
                    lblLAST_ALTERED_BY = CType(value, TextField)
                Case "lblLAST_ALTERED_DATE"
                    lblLAST_ALTERED_DATE = CType(value, DateField)
                Case "CAMPUS_CODE"
                    CAMPUS_CODE = CType(value, TextField)
                Case "hidden_LAST_ALTERED_BY"
                    hidden_LAST_ALTERED_BY = CType(value, TextField)
                Case "hidden_LAST_ALTERED_DATE"
                    hidden_LAST_ALTERED_DATE = CType(value, DateField)
                Case "LoginID"
                    LoginID = CType(value, TextField)
                Case "lblLoginID"
                    lblLoginID = CType(value, TextField)
                Case "Hidden_LOGIN_ID"
                    Hidden_LOGIN_ID = CType(value, TextField)
                Case "CheckboxList_SECURITY_FUNCTIONS"
                    CheckboxList_SECURITY_FUNCTIONS = CType(value, TextField)
                Case "Hidden_SECURITY_FUNCTIONS"
                    Hidden_SECURITY_FUNCTIONS = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STAFFDataProvider)
'End Record STAFF Item Class

'StaffID validate @20-C197579F
        If IsNothing(StaffID.Value) OrElse StaffID.Value.ToString() ="" Then
            errors.Add("StaffID",String.Format(Resources.strings.CCS_RequiredField,"STAFF ID"))
        End If
        If (Not IsNothing(StaffID)) And (Not provider.CheckUnique("StaffID",Me)) Then
                errors.Add("StaffID", String.Format(Resources.strings.CCS_UniqueValue,"STAFF ID"))
        End If
'End StaffID validate

'SURNAME validate @9-F35C1CC1
        If IsNothing(SURNAME.Value) OrElse SURNAME.Value.ToString() ="" Then
            errors.Add("SURNAME",String.Format(Resources.strings.CCS_RequiredField,"SURNAME"))
        End If
'End SURNAME validate

'FIRSTNAME validate @10-857A4237
        If IsNothing(FIRSTNAME.Value) OrElse FIRSTNAME.Value.ToString() ="" Then
            errors.Add("FIRSTNAME",String.Format(Resources.strings.CCS_RequiredField,"FIRSTNAME"))
        End If
'End FIRSTNAME validate

'TEACHER_FLAG validate @12-DA1D2DE0
        If IsNothing(TEACHER_FLAG.Value) OrElse TEACHER_FLAG.Value.ToString() ="" Then
            errors.Add("TEACHER_FLAG",String.Format(Resources.strings.CCS_RequiredField,"TEACHER FLAG"))
        End If
'End TEACHER_FLAG validate

'STATUS validate @15-73C7378E
        If IsNothing(STATUS.Value) OrElse STATUS.Value.ToString() ="" Then
            errors.Add("STATUS",String.Format(Resources.strings.CCS_RequiredField,"STATUS"))
        End If
'End STATUS validate

'CAMPUS_CODE validate @7-E6F21D52
        If IsNothing(CAMPUS_CODE.Value) OrElse CAMPUS_CODE.Value.ToString() ="" Then
            errors.Add("CAMPUS_CODE",String.Format(Resources.strings.CCS_RequiredField,"CAMPUS CODE"))
        End If
'End CAMPUS_CODE validate

'DEL      ' -------------------------
'DEL     'ERA: 9-Apr-2010|EA| required if not hidden
'DEL  	If (LoginID.visible = true) Then
'DEL  		' check exists 
'DEL  		If IsNothing(LoginID.Value) OrElse LoginID.Value.ToString() ="" Then
'DEL              errors.Add("LoginID",String.Format(Resources.strings.CCS_RequiredField,"LOGIN ID"))
'DEL          End If
'DEL  		' check Unique
'DEL  		If (Not IsNothing(LoginID)) And (Not provider.CheckUnique("LoginID",Me)) Then
'DEL                  errors.Add("LoginID", String.Format(Resources.strings.CCS_UniqueValue,"LOGIN ID"))
'DEL          End If
'DEL  	
'DEL  	end if
'DEL      ' -------------------------


'Record STAFF Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STAFF Item Class tail

'Record STAFF Data Provider Class @2-8E9C8F9C
Public Class STAFFDataProvider
Inherits RecordDataProviderBase
'End Record STAFF Data Provider Class

'Record STAFF Data Provider Class Variables @2-B2636660
    Protected GROUP_IDDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM SECURITY_GROUP {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected CheckboxList_SECURITY_FUNCTIONSDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM SECURITY_FUNCTION {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Public UrlSTAFF_ID As TextParameter
    Protected item As STAFFItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STAFF Data Provider Class Variables

'Record STAFF Data Provider Class Constructor @2-0394FD37

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STAFF {SQL_Where} {SQL_OrderBy}", New String(){"STAFF_ID47"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STAFF Data Provider Class Constructor

'Record STAFF Data Provider Class LoadParams Method @2-9E0F7118

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTAFF_ID))
    End Function
'End Record STAFF Data Provider Class LoadParams Method

'Record STAFF Data Provider Class CheckUnique Method @2-45AFEC78

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STAFFItem) As Boolean
        Dim Check As TableCommand = New TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STAFF",New String(){"STAFF_ID47"},Settings.connDECVPRODSQL2005DataAccessObject)
        Dim CheckWhere As String = ""
        Select Case ControlName
        Case "StaffID"
            CheckWhere = "STAFF_ID=" & Check.Dao.ToSql(item.StaffID.GetFormattedValue(""),FieldType._Text)
        End Select
        Check.Where = CheckWhere
        Check.Operation = "AND NOT"
        Check.Parameters.Clear()
        CType(Check,TableCommand).AddParameter("STAFF_ID47",UrlSTAFF_ID, "","STAFF_ID",Condition.Equal,False)
        If Convert.ToInt32(Check.ExecuteScalar()) > 0 Then
            Return False
        End If
        Return True
    End Function
'End Record STAFF Data Provider Class CheckUnique Method

'Record STAFF Data Provider Class PrepareInsert Method @2-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STAFF Data Provider Class PrepareInsert Method

'Record STAFF Data Provider Class PrepareInsert Method tail @2-E31F8E2A
    End Sub
'End Record STAFF Data Provider Class PrepareInsert Method tail

'Record STAFF Data Provider Class Insert Method @2-A3E70FFB

    Public Function InsertItem(ByVal item As STAFFItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO STAFF({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STAFF Data Provider Class Insert Method

'DEL      ' -------------------------
'DEL      'ERA: 1-Apr-2010|EA|for Insert then simply grab STAFFStaffID and use in LOGIN_ID field
'DEL  	'item.loginid.value = item.staffid.getformattedvalue()
'DEL  	'item.loginid.setvalue(item.staffid.getformattedvalue())
'DEL      ' -------------------------

'Record STAFF Build insert @2-49D9D6A8
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.StaffID.IsEmpty Then
        allEmptyFlag = item.StaffID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STAFF_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.StaffID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SALUTATION.IsEmpty Then
        allEmptyFlag = item.SALUTATION.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SALUTATION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SALUTATION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SURNAME.IsEmpty Then
        allEmptyFlag = item.SURNAME.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SURNAME,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SURNAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.FIRSTNAME.IsEmpty Then
        allEmptyFlag = item.FIRSTNAME.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "FIRSTNAME,"
        valuesList = valuesList & Insert.Dao.ToSql(item.FIRSTNAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.MIDDLENAME.IsEmpty Then
        allEmptyFlag = item.MIDDLENAME.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "MIDDLENAME,"
        valuesList = valuesList & Insert.Dao.ToSql(item.MIDDLENAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.TEACHER_FLAG.IsEmpty Then
        allEmptyFlag = item.TEACHER_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "TEACHER_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.TEACHER_FLAG.GetFormattedValue(Insert.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STATUS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STATUS.GetFormattedValue(Insert.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.GROUP_ID.IsEmpty Then
        allEmptyFlag = item.GROUP_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "GROUP_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.GROUP_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.CAMPUS_CODE.IsEmpty Then
        allEmptyFlag = item.CAMPUS_CODE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CAMPUS_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CAMPUS_CODE.GetFormattedValue(""),FieldType._Text) & ","
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
        If Not item.LoginID.IsEmpty Then
        allEmptyFlag = item.LoginID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LOGIN_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LoginID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_LOGIN_ID.IsEmpty Then
        allEmptyFlag = item.Hidden_LOGIN_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LOGIN_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_LOGIN_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_SECURITY_FUNCTIONS.IsEmpty Then
        allEmptyFlag = item.Hidden_SECURITY_FUNCTIONS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SECURITY_FUNCTIONS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_SECURITY_FUNCTIONS.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STAFF Build insert

'Record STAFF AfterExecuteInsert @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STAFF AfterExecuteInsert

'Record STAFF Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STAFF Data Provider Class PrepareUpdate Method

'Record STAFF Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record STAFF Data Provider Class PrepareUpdate Method tail

'Record STAFF Data Provider Class Update Method @2-DF077992

    Public Function UpdateItem(ByVal item As STAFFItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STAFF SET {Values}", New String(){"STAFF_ID47"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STAFF Data Provider Class Update Method

'Record STAFF BeforeBuildUpdate @2-3032E50F
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STAFF_ID47",UrlSTAFF_ID, "","STAFF_ID",Condition.Equal,False)
        If Not item.StaffID.IsEmpty Then
        allEmptyFlag = item.StaffID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STAFF_ID=" + Update.Dao.ToSql(item.StaffID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SALUTATION.IsEmpty Then
        allEmptyFlag = item.SALUTATION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SALUTATION=" + Update.Dao.ToSql(item.SALUTATION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SURNAME.IsEmpty Then
        allEmptyFlag = item.SURNAME.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SURNAME=" + Update.Dao.ToSql(item.SURNAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.FIRSTNAME.IsEmpty Then
        allEmptyFlag = item.FIRSTNAME.IsEmpty And allEmptyFlag
        valuesList = valuesList & "FIRSTNAME=" + Update.Dao.ToSql(item.FIRSTNAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.MIDDLENAME.IsEmpty Then
        allEmptyFlag = item.MIDDLENAME.IsEmpty And allEmptyFlag
        valuesList = valuesList & "MIDDLENAME=" + Update.Dao.ToSql(item.MIDDLENAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.TEACHER_FLAG.IsEmpty Then
        allEmptyFlag = item.TEACHER_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "TEACHER_FLAG=" + Update.Dao.ToSql(item.TEACHER_FLAG.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STATUS=" + Update.Dao.ToSql(item.STATUS.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.GROUP_ID.IsEmpty Then
        allEmptyFlag = item.GROUP_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "GROUP_ID=" + Update.Dao.ToSql(item.GROUP_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.CAMPUS_CODE.IsEmpty Then
        allEmptyFlag = item.CAMPUS_CODE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CAMPUS_CODE=" + Update.Dao.ToSql(item.CAMPUS_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.hidden_LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.hidden_LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.hidden_LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.hidden_LAST_ALTERED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.LoginID.IsEmpty Then
        allEmptyFlag = item.LoginID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LOGIN_ID=" + Update.Dao.ToSql(item.LoginID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_LOGIN_ID.IsEmpty Then
        allEmptyFlag = item.Hidden_LOGIN_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LOGIN_ID=" + Update.Dao.ToSql(item.Hidden_LOGIN_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_SECURITY_FUNCTIONS.IsEmpty Then
        allEmptyFlag = item.Hidden_SECURITY_FUNCTIONS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SECURITY_FUNCTIONS=" + Update.Dao.ToSql(item.Hidden_SECURITY_FUNCTIONS.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STAFF BeforeBuildUpdate

'Record STAFF AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STAFF AfterExecuteUpdate

'Record STAFF Data Provider Class GetResultSet Method @2-2D00C7DE

    Public Sub FillItem(ByVal item As STAFFItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STAFF Data Provider Class GetResultSet Method

'Record STAFF BeforeBuildSelect @2-B56CAAB1
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STAFF_ID47",UrlSTAFF_ID, "","STAFF_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STAFF BeforeBuildSelect

'Record STAFF BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STAFF BeforeExecuteSelect

'Record STAFF AfterExecuteSelect @2-1A811AFD
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.StaffID.SetValue(dr(i)("STAFF_ID"),"")
            item.StaffID_view.SetValue(dr(i)("STAFF_ID"),"")
            item.SALUTATION.SetValue(dr(i)("SALUTATION"),"")
            item.SURNAME.SetValue(dr(i)("SURNAME"),"")
            item.FIRSTNAME.SetValue(dr(i)("FIRSTNAME"),"")
            item.MIDDLENAME.SetValue(dr(i)("MIDDLENAME"),"")
            item.TEACHER_FLAG.SetValue(dr(i)("TEACHER_FLAG"),Select_.BoolFormat)
            item.STATUS.SetValue(dr(i)("STATUS"),Select_.BoolFormat)
            item.GROUP_ID.SetValue(dr(i)("GROUP_ID"),"")
            item.lblLAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.lblLAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.CAMPUS_CODE.SetValue(dr(i)("CAMPUS_CODE"),"")
            item.hidden_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.hidden_LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.LoginID.SetValue(dr(i)("LOGIN_ID"),"")
            item.Hidden_LOGIN_ID.SetValue(dr(i)("LOGIN_ID"),"")
            item.Hidden_SECURITY_FUNCTIONS.SetValue(dr(i)("SECURITY_FUNCTIONS"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record STAFF AfterExecuteSelect

'ListBox GROUP_ID Initialize Data Source @13-BDCD094A
        GROUP_IDDataCommand.Dao._optimized = False
        Dim GROUP_IDtableIndex As Integer = 0
        GROUP_IDDataCommand.OrderBy = ""
        GROUP_IDDataCommand.Parameters.Clear()
'End ListBox GROUP_ID Initialize Data Source

'ListBox GROUP_ID BeforeExecuteSelect @13-EECFE88C
        Try
            ListBoxSource=GROUP_IDDataCommand.Execute().Tables(GROUP_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox GROUP_ID BeforeExecuteSelect

'ListBox GROUP_ID AfterExecuteSelect @13-5DE25080
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New FloatField("", ListBoxSource(j)("GROUP_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("GROUP_NAME")
            item.GROUP_IDItems.Add(Key, Val)
        Next
'End ListBox GROUP_ID AfterExecuteSelect

'ListBox CheckboxList_SECURITY_FUNCTIONS Initialize Data Source @45-97AE0F42
        CheckboxList_SECURITY_FUNCTIONSDataCommand.Dao._optimized = False
        Dim CheckboxList_SECURITY_FUNCTIONStableIndex As Integer = 0
        CheckboxList_SECURITY_FUNCTIONSDataCommand.OrderBy = ""
        CheckboxList_SECURITY_FUNCTIONSDataCommand.Parameters.Clear()
'End ListBox CheckboxList_SECURITY_FUNCTIONS Initialize Data Source

'ListBox CheckboxList_SECURITY_FUNCTIONS BeforeExecuteSelect @45-0D090AA1
        Try
            ListBoxSource=CheckboxList_SECURITY_FUNCTIONSDataCommand.Execute().Tables(CheckboxList_SECURITY_FUNCTIONStableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox CheckboxList_SECURITY_FUNCTIONS BeforeExecuteSelect

'ListBox CheckboxList_SECURITY_FUNCTIONS AfterExecuteSelect @45-902F2151
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("FUNCTION_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("FUNCTION_TITLE")
            item.CheckboxList_SECURITY_FUNCTIONSItems.Add(Key, Val)
        Next
'End ListBox CheckboxList_SECURITY_FUNCTIONS AfterExecuteSelect

'Record STAFF AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record STAFF AfterExecuteSelect tail

'Record STAFF Data Provider Class @2-A61BA892
End Class

'End Record STAFF Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

