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

Namespace DECV_PROD2007.SUBJECT_maint_bak 'Namespace @1-A87F4933

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

'Record SUBJECT Item Class @2-6AB18087
Public Class SUBJECTItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public txtNewSubjectID As TextField
    Public lblSubjectID As TextField
    Public SUBJECT_ABBREV As TextField
    Public SUBJECT_TITLE As TextField
    Public CAMPUS_CODE As TextField
    Public CAMPUS_CODEItems As ItemCollection
    Public YEAR_LEVEL As IntegerField
    Public DEFAULT_SEMESTER As TextField
    Public DEFAULT_TEACHER_ID As TextField
    Public DEFAULT_TEACHER_IDItems As ItemCollection
    Public SUB_SCHOOL As TextField
    Public KLA_ID As FloatField
    Public KLA_IDItems As ItemCollection
    Public CSF_CLASS_LEVEL As IntegerField
    Public MAX_BOOKS As IntegerField
    Public VALID_COURSE_DISTRIBUTION As TextField
    Public VALID_COURSE_DISTRIBUTIONItems As ItemCollection
    Public DESCRIPTION_LINE1 As TextField
    Public DESCRIPTION_LINE2 As TextField
    Public STATUS As BooleanField
    Public STATUSItems As ItemCollection
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    txtNewSubjectID = New TextField("", Nothing)
    lblSubjectID = New TextField("", Nothing)
    SUBJECT_ABBREV = New TextField("", Nothing)
    SUBJECT_TITLE = New TextField("", Nothing)
    CAMPUS_CODE = New TextField("", Nothing)
    CAMPUS_CODEItems = New ItemCollection()
    YEAR_LEVEL = New IntegerField("", Nothing)
    DEFAULT_SEMESTER = New TextField("", Nothing)
    DEFAULT_TEACHER_ID = New TextField("", Nothing)
    DEFAULT_TEACHER_IDItems = New ItemCollection()
    SUB_SCHOOL = New TextField("", Nothing)
    KLA_ID = New FloatField("", Nothing)
    KLA_IDItems = New ItemCollection()
    CSF_CLASS_LEVEL = New IntegerField("", Nothing)
    MAX_BOOKS = New IntegerField("", Nothing)
    VALID_COURSE_DISTRIBUTION = New TextField("", Nothing)
    VALID_COURSE_DISTRIBUTIONItems = New ItemCollection()
    DESCRIPTION_LINE1 = New TextField("", Nothing)
    DESCRIPTION_LINE2 = New TextField("", Nothing)
    STATUS = New BooleanField(Settings.BoolFormat, Nothing)
    STATUSItems = New ItemCollection()
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As SUBJECTItem
        Dim item As SUBJECTItem = New SUBJECTItem()
        If Not IsNothing(DBUtility.GetInitialValue("txtNewSubjectID")) Then
        item.txtNewSubjectID.SetValue(DBUtility.GetInitialValue("txtNewSubjectID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblSubjectID")) Then
        item.lblSubjectID.SetValue(DBUtility.GetInitialValue("lblSubjectID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUBJECT_ABBREV")) Then
        item.SUBJECT_ABBREV.SetValue(DBUtility.GetInitialValue("SUBJECT_ABBREV"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUBJECT_TITLE")) Then
        item.SUBJECT_TITLE.SetValue(DBUtility.GetInitialValue("SUBJECT_TITLE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CAMPUS_CODE")) Then
        item.CAMPUS_CODE.SetValue(DBUtility.GetInitialValue("CAMPUS_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("YEAR_LEVEL")) Then
        item.YEAR_LEVEL.SetValue(DBUtility.GetInitialValue("YEAR_LEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DEFAULT_SEMESTER")) Then
        item.DEFAULT_SEMESTER.SetValue(DBUtility.GetInitialValue("DEFAULT_SEMESTER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DEFAULT_TEACHER_ID")) Then
        item.DEFAULT_TEACHER_ID.SetValue(DBUtility.GetInitialValue("DEFAULT_TEACHER_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUB_SCHOOL")) Then
        item.SUB_SCHOOL.SetValue(DBUtility.GetInitialValue("SUB_SCHOOL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("KLA_ID")) Then
        item.KLA_ID.SetValue(DBUtility.GetInitialValue("KLA_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CSF_CLASS_LEVEL")) Then
        item.CSF_CLASS_LEVEL.SetValue(DBUtility.GetInitialValue("CSF_CLASS_LEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MAX_BOOKS")) Then
        item.MAX_BOOKS.SetValue(DBUtility.GetInitialValue("MAX_BOOKS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("VALID_COURSE_DISTRIBUTION")) Then
        item.VALID_COURSE_DISTRIBUTION.SetValue(DBUtility.GetInitialValue("VALID_COURSE_DISTRIBUTION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DESCRIPTION_LINE1")) Then
        item.DESCRIPTION_LINE1.SetValue(DBUtility.GetInitialValue("DESCRIPTION_LINE1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DESCRIPTION_LINE2")) Then
        item.DESCRIPTION_LINE2.SetValue(DBUtility.GetInitialValue("DESCRIPTION_LINE2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STATUS")) Then
        item.STATUS.SetValue(DBUtility.GetInitialValue("STATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "txtNewSubjectID"
                    Return txtNewSubjectID
                Case "lblSubjectID"
                    Return lblSubjectID
                Case "SUBJECT_ABBREV"
                    Return SUBJECT_ABBREV
                Case "SUBJECT_TITLE"
                    Return SUBJECT_TITLE
                Case "CAMPUS_CODE"
                    Return CAMPUS_CODE
                Case "YEAR_LEVEL"
                    Return YEAR_LEVEL
                Case "DEFAULT_SEMESTER"
                    Return DEFAULT_SEMESTER
                Case "DEFAULT_TEACHER_ID"
                    Return DEFAULT_TEACHER_ID
                Case "SUB_SCHOOL"
                    Return SUB_SCHOOL
                Case "KLA_ID"
                    Return KLA_ID
                Case "CSF_CLASS_LEVEL"
                    Return CSF_CLASS_LEVEL
                Case "MAX_BOOKS"
                    Return MAX_BOOKS
                Case "VALID_COURSE_DISTRIBUTION"
                    Return VALID_COURSE_DISTRIBUTION
                Case "DESCRIPTION_LINE1"
                    Return DESCRIPTION_LINE1
                Case "DESCRIPTION_LINE2"
                    Return DESCRIPTION_LINE2
                Case "STATUS"
                    Return STATUS
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "txtNewSubjectID"
                    txtNewSubjectID = CType(value, TextField)
                Case "lblSubjectID"
                    lblSubjectID = CType(value, TextField)
                Case "SUBJECT_ABBREV"
                    SUBJECT_ABBREV = CType(value, TextField)
                Case "SUBJECT_TITLE"
                    SUBJECT_TITLE = CType(value, TextField)
                Case "CAMPUS_CODE"
                    CAMPUS_CODE = CType(value, TextField)
                Case "YEAR_LEVEL"
                    YEAR_LEVEL = CType(value, IntegerField)
                Case "DEFAULT_SEMESTER"
                    DEFAULT_SEMESTER = CType(value, TextField)
                Case "DEFAULT_TEACHER_ID"
                    DEFAULT_TEACHER_ID = CType(value, TextField)
                Case "SUB_SCHOOL"
                    SUB_SCHOOL = CType(value, TextField)
                Case "KLA_ID"
                    KLA_ID = CType(value, FloatField)
                Case "CSF_CLASS_LEVEL"
                    CSF_CLASS_LEVEL = CType(value, IntegerField)
                Case "MAX_BOOKS"
                    MAX_BOOKS = CType(value, IntegerField)
                Case "VALID_COURSE_DISTRIBUTION"
                    VALID_COURSE_DISTRIBUTION = CType(value, TextField)
                Case "DESCRIPTION_LINE1"
                    DESCRIPTION_LINE1 = CType(value, TextField)
                Case "DESCRIPTION_LINE2"
                    DESCRIPTION_LINE2 = CType(value, TextField)
                Case "STATUS"
                    STATUS = CType(value, BooleanField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
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

    Public Sub Validate(ByVal provider As SUBJECTDataProvider)
'End Record SUBJECT Item Class

'txtNewSubjectID validate @26-023AC1C6
        If (Not IsNothing(txtNewSubjectID)) And (Not provider.CheckUnique("txtNewSubjectID",Me)) Then
                errors.Add("txtNewSubjectID", String.Format(Resources.strings.CCS_UniqueValue,"Subject ID"))
        End If
'End txtNewSubjectID validate

'SUBJECT_ABBREV validate @7-E56D9B97
        If IsNothing(SUBJECT_ABBREV.Value) OrElse SUBJECT_ABBREV.Value.ToString() ="" Then
            errors.Add("SUBJECT_ABBREV",String.Format(Resources.strings.CCS_RequiredField,"ABBREV"))
        End If
'End SUBJECT_ABBREV validate

'SUBJECT_TITLE validate @8-FEC3B7A8
        If IsNothing(SUBJECT_TITLE.Value) OrElse SUBJECT_TITLE.Value.ToString() ="" Then
            errors.Add("SUBJECT_TITLE",String.Format(Resources.strings.CCS_RequiredField,"TITLE"))
        End If
'End SUBJECT_TITLE validate

'CAMPUS_CODE validate @9-E6F21D52
        If IsNothing(CAMPUS_CODE.Value) OrElse CAMPUS_CODE.Value.ToString() ="" Then
            errors.Add("CAMPUS_CODE",String.Format(Resources.strings.CCS_RequiredField,"CAMPUS CODE"))
        End If
'End CAMPUS_CODE validate

'YEAR_LEVEL validate @10-30512612
        If IsNothing(YEAR_LEVEL.Value) OrElse YEAR_LEVEL.Value.ToString() ="" Then
            errors.Add("YEAR_LEVEL",String.Format(Resources.strings.CCS_RequiredField,"YEAR LEVEL"))
        End If
'End YEAR_LEVEL validate

'DEFAULT_SEMESTER validate @11-2A647C58
        If IsNothing(DEFAULT_SEMESTER.Value) OrElse DEFAULT_SEMESTER.Value.ToString() ="" Then
            errors.Add("DEFAULT_SEMESTER",String.Format(Resources.strings.CCS_RequiredField,"DEFAULT SEMESTER"))
        End If
'End DEFAULT_SEMESTER validate

'DEFAULT_TEACHER_ID validate @12-ED271BDB
        If IsNothing(DEFAULT_TEACHER_ID.Value) OrElse DEFAULT_TEACHER_ID.Value.ToString() ="" Then
            errors.Add("DEFAULT_TEACHER_ID",String.Format(Resources.strings.CCS_RequiredField,"DEFAULT TEACHER ID"))
        End If
'End DEFAULT_TEACHER_ID validate

'KLA_ID validate @14-FC575AA4
        If IsNothing(KLA_ID.Value) OrElse KLA_ID.Value.ToString() ="" Then
            errors.Add("KLA_ID",String.Format(Resources.strings.CCS_RequiredField,"KLA ID"))
        End If
'End KLA_ID validate

'MAX_BOOKS validate @16-CC7DE464
        If IsNothing(MAX_BOOKS.Value) OrElse MAX_BOOKS.Value.ToString() ="" Then
            errors.Add("MAX_BOOKS",String.Format(Resources.strings.CCS_RequiredField,"MAX BOOKS"))
        End If
'End MAX_BOOKS validate

'STATUS validate @20-73C7378E
        If IsNothing(STATUS.Value) OrElse STATUS.Value.ToString() ="" Then
            errors.Add("STATUS",String.Format(Resources.strings.CCS_RequiredField,"STATUS"))
        End If
'End STATUS validate

'Record SUBJECT Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record SUBJECT Item Class tail

'Record SUBJECT Data Provider Class @2-559A5AD0
Public Class SUBJECTDataProvider
Inherits RecordDataProviderBase
'End Record SUBJECT Data Provider Class

'Record SUBJECT Data Provider Class Variables @2-19A8D2F0
    Protected CAMPUS_CODEDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM CAMPUS {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected DEFAULT_TEACHER_IDDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STAFF {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected KLA_IDDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM KEY_LEARNING_AREA {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Public UrlSUBJECT_ID As IntegerParameter
    Protected item As SUBJECTItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record SUBJECT Data Provider Class Variables

'Record SUBJECT Data Provider Class Constructor @2-E0DD76BC

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM SUBJECT {SQL_Where} {SQL_OrderBy}", New String(){"SUBJECT_ID6"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record SUBJECT Data Provider Class Constructor

'Record SUBJECT Data Provider Class LoadParams Method @2-760FD411

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSUBJECT_ID))
    End Function
'End Record SUBJECT Data Provider Class LoadParams Method

'Record SUBJECT Data Provider Class CheckUnique Method @2-D6059621

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As SUBJECTItem) As Boolean
        Dim Check As TableCommand = New TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM SUBJECT",New String(){"SUBJECT_ID6"},Settings.connDECVPRODSQL2005DataAccessObject)
        Dim CheckWhere As String = ""
        Select Case ControlName
        Case "txtNewSubjectID"
            CheckWhere = "SUBJECT_ID=" & Check.Dao.ToSql(item.txtNewSubjectID.GetFormattedValue(""),FieldType._Text)
        End Select
        Check.Where = CheckWhere
        Check.Operation = "AND NOT"
        Check.Parameters.Clear()
        CType(Check,TableCommand).AddParameter("SUBJECT_ID6",UrlSUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        If Convert.ToInt32(Check.ExecuteScalar()) > 0 Then
            Return False
        End If
        Return True
    End Function
'End Record SUBJECT Data Provider Class CheckUnique Method

'Record SUBJECT Data Provider Class PrepareInsert Method @2-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record SUBJECT Data Provider Class PrepareInsert Method

'Record SUBJECT Data Provider Class PrepareInsert Method tail @2-E31F8E2A
    End Sub
'End Record SUBJECT Data Provider Class PrepareInsert Method tail

'Record SUBJECT Data Provider Class Insert Method @2-CEB9A2DB

    Public Function InsertItem(ByVal item As SUBJECTItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO SUBJECT({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record SUBJECT Data Provider Class Insert Method

'Record SUBJECT Build insert @2-79850DAE
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.txtNewSubjectID.IsEmpty Then
        allEmptyFlag = item.txtNewSubjectID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUBJECT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.txtNewSubjectID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUBJECT_ABBREV.IsEmpty Then
        allEmptyFlag = item.SUBJECT_ABBREV.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUBJECT_ABBREV,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUBJECT_ABBREV.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUBJECT_TITLE.IsEmpty Then
        allEmptyFlag = item.SUBJECT_TITLE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUBJECT_TITLE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUBJECT_TITLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CAMPUS_CODE.IsEmpty Then
        allEmptyFlag = item.CAMPUS_CODE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CAMPUS_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CAMPUS_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.YEAR_LEVEL.IsEmpty Then
        allEmptyFlag = item.YEAR_LEVEL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "YEAR_LEVEL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.DEFAULT_SEMESTER.IsEmpty Then
        allEmptyFlag = item.DEFAULT_SEMESTER.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "DEFAULT_SEMESTER,"
        valuesList = valuesList & Insert.Dao.ToSql(item.DEFAULT_SEMESTER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DEFAULT_TEACHER_ID.IsEmpty Then
        allEmptyFlag = item.DEFAULT_TEACHER_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "DEFAULT_TEACHER_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.DEFAULT_TEACHER_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUB_SCHOOL.IsEmpty Then
        allEmptyFlag = item.SUB_SCHOOL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUB_SCHOOL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUB_SCHOOL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.KLA_ID.IsEmpty Then
        allEmptyFlag = item.KLA_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "KLA_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.KLA_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.CSF_CLASS_LEVEL.IsEmpty Then
        allEmptyFlag = item.CSF_CLASS_LEVEL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CSF_CLASS_LEVEL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CSF_CLASS_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.MAX_BOOKS.IsEmpty Then
        allEmptyFlag = item.MAX_BOOKS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "MAX_BOOKS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.MAX_BOOKS.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.VALID_COURSE_DISTRIBUTION.IsEmpty Then
        allEmptyFlag = item.VALID_COURSE_DISTRIBUTION.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "VALID_COURSE_DISTRIBUTION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.VALID_COURSE_DISTRIBUTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DESCRIPTION_LINE1.IsEmpty Then
        allEmptyFlag = item.DESCRIPTION_LINE1.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "DESCRIPTION_LINE1,"
        valuesList = valuesList & Insert.Dao.ToSql(item.DESCRIPTION_LINE1.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DESCRIPTION_LINE2.IsEmpty Then
        allEmptyFlag = item.DESCRIPTION_LINE2.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "DESCRIPTION_LINE2,"
        valuesList = valuesList & Insert.Dao.ToSql(item.DESCRIPTION_LINE2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STATUS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STATUS.GetFormattedValue(Insert.BoolFormat),FieldType._Boolean) & ","
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
'End Record SUBJECT Build insert

'Record SUBJECT AfterExecuteInsert @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record SUBJECT AfterExecuteInsert

'Record SUBJECT Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record SUBJECT Data Provider Class PrepareUpdate Method

'Record SUBJECT Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record SUBJECT Data Provider Class PrepareUpdate Method tail

'Record SUBJECT Data Provider Class Update Method @2-3B1EB30E

    Public Function UpdateItem(ByVal item As SUBJECTItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE SUBJECT SET {Values}", New String(){"SUBJECT_ID6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record SUBJECT Data Provider Class Update Method

'Record SUBJECT BeforeBuildUpdate @2-8C861C98
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("SUBJECT_ID6",UrlSUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        If Not item.txtNewSubjectID.IsEmpty Then
        allEmptyFlag = item.txtNewSubjectID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUBJECT_ID=" + Update.Dao.ToSql(item.txtNewSubjectID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUBJECT_ABBREV.IsEmpty Then
        allEmptyFlag = item.SUBJECT_ABBREV.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUBJECT_ABBREV=" + Update.Dao.ToSql(item.SUBJECT_ABBREV.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUBJECT_TITLE.IsEmpty Then
        allEmptyFlag = item.SUBJECT_TITLE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUBJECT_TITLE=" + Update.Dao.ToSql(item.SUBJECT_TITLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CAMPUS_CODE.IsEmpty Then
        allEmptyFlag = item.CAMPUS_CODE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CAMPUS_CODE=" + Update.Dao.ToSql(item.CAMPUS_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.YEAR_LEVEL.IsEmpty Then
        allEmptyFlag = item.YEAR_LEVEL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "YEAR_LEVEL=" + Update.Dao.ToSql(item.YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.DEFAULT_SEMESTER.IsEmpty Then
        allEmptyFlag = item.DEFAULT_SEMESTER.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DEFAULT_SEMESTER=" + Update.Dao.ToSql(item.DEFAULT_SEMESTER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DEFAULT_TEACHER_ID.IsEmpty Then
        allEmptyFlag = item.DEFAULT_TEACHER_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DEFAULT_TEACHER_ID=" + Update.Dao.ToSql(item.DEFAULT_TEACHER_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUB_SCHOOL.IsEmpty Then
        allEmptyFlag = item.SUB_SCHOOL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUB_SCHOOL=" + Update.Dao.ToSql(item.SUB_SCHOOL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.KLA_ID.IsEmpty Then
        allEmptyFlag = item.KLA_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "KLA_ID=" + Update.Dao.ToSql(item.KLA_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.CSF_CLASS_LEVEL.IsEmpty Then
        allEmptyFlag = item.CSF_CLASS_LEVEL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CSF_CLASS_LEVEL=" + Update.Dao.ToSql(item.CSF_CLASS_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.MAX_BOOKS.IsEmpty Then
        allEmptyFlag = item.MAX_BOOKS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "MAX_BOOKS=" + Update.Dao.ToSql(item.MAX_BOOKS.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.VALID_COURSE_DISTRIBUTION.IsEmpty Then
        allEmptyFlag = item.VALID_COURSE_DISTRIBUTION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "VALID_COURSE_DISTRIBUTION=" + Update.Dao.ToSql(item.VALID_COURSE_DISTRIBUTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DESCRIPTION_LINE1.IsEmpty Then
        allEmptyFlag = item.DESCRIPTION_LINE1.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DESCRIPTION_LINE1=" + Update.Dao.ToSql(item.DESCRIPTION_LINE1.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DESCRIPTION_LINE2.IsEmpty Then
        allEmptyFlag = item.DESCRIPTION_LINE2.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DESCRIPTION_LINE2=" + Update.Dao.ToSql(item.DESCRIPTION_LINE2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STATUS=" + Update.Dao.ToSql(item.STATUS.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
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
'End Record SUBJECT BeforeBuildUpdate

'Record SUBJECT AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record SUBJECT AfterExecuteUpdate

'Record SUBJECT Data Provider Class GetResultSet Method @2-83059C9A

    Public Sub FillItem(ByVal item As SUBJECTItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record SUBJECT Data Provider Class GetResultSet Method

'Record SUBJECT BeforeBuildSelect @2-D0C1F01C
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("SUBJECT_ID6",UrlSUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record SUBJECT BeforeBuildSelect

'Record SUBJECT BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record SUBJECT BeforeExecuteSelect

'Record SUBJECT AfterExecuteSelect @2-6377FB27
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.txtNewSubjectID.SetValue(dr(i)("SUBJECT_ID"),"")
            item.lblSubjectID.SetValue(dr(i)("SUBJECT_ID"),"")
            item.SUBJECT_ABBREV.SetValue(dr(i)("SUBJECT_ABBREV"),"")
            item.SUBJECT_TITLE.SetValue(dr(i)("SUBJECT_TITLE"),"")
            item.CAMPUS_CODE.SetValue(dr(i)("CAMPUS_CODE"),"")
            item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
            item.DEFAULT_SEMESTER.SetValue(dr(i)("DEFAULT_SEMESTER"),"")
            item.DEFAULT_TEACHER_ID.SetValue(dr(i)("DEFAULT_TEACHER_ID"),"")
            item.SUB_SCHOOL.SetValue(dr(i)("SUB_SCHOOL"),"")
            item.KLA_ID.SetValue(dr(i)("KLA_ID"),"")
            item.CSF_CLASS_LEVEL.SetValue(dr(i)("CSF_CLASS_LEVEL"),"")
            item.MAX_BOOKS.SetValue(dr(i)("MAX_BOOKS"),"")
            item.VALID_COURSE_DISTRIBUTION.SetValue(dr(i)("VALID_COURSE_DISTRIBUTION"),"")
            item.DESCRIPTION_LINE1.SetValue(dr(i)("DESCRIPTION_LINE1"),"")
            item.DESCRIPTION_LINE2.SetValue(dr(i)("DESCRIPTION_LINE2"),"")
            item.STATUS.SetValue(dr(i)("STATUS"),Select_.BoolFormat)
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record SUBJECT AfterExecuteSelect

'ListBox CAMPUS_CODE Initialize Data Source @9-2596BCCA
        CAMPUS_CODEDataCommand.Dao._optimized = False
        Dim CAMPUS_CODEtableIndex As Integer = 0
        CAMPUS_CODEDataCommand.OrderBy = ""
        CAMPUS_CODEDataCommand.Parameters.Clear()
'End ListBox CAMPUS_CODE Initialize Data Source

'ListBox CAMPUS_CODE BeforeExecuteSelect @9-CEE820EC
        Try
            ListBoxSource=CAMPUS_CODEDataCommand.Execute().Tables(CAMPUS_CODEtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox CAMPUS_CODE BeforeExecuteSelect

'ListBox CAMPUS_CODE AfterExecuteSelect @9-F693D04B
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("CAMPUS_CODE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("CAMPUS_CODE")
            item.CAMPUS_CODEItems.Add(Key, Val)
        Next
'End ListBox CAMPUS_CODE AfterExecuteSelect

'ListBox DEFAULT_TEACHER_ID Initialize Data Source @12-ABFDE8C1
        DEFAULT_TEACHER_IDDataCommand.Dao._optimized = False
        Dim DEFAULT_TEACHER_IDtableIndex As Integer = 0
        DEFAULT_TEACHER_IDDataCommand.OrderBy = ""
        DEFAULT_TEACHER_IDDataCommand.Parameters.Clear()
'End ListBox DEFAULT_TEACHER_ID Initialize Data Source

'ListBox DEFAULT_TEACHER_ID BeforeExecuteSelect @12-4A747ED8
        Try
            ListBoxSource=DEFAULT_TEACHER_IDDataCommand.Execute().Tables(DEFAULT_TEACHER_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox DEFAULT_TEACHER_ID BeforeExecuteSelect

'ListBox DEFAULT_TEACHER_ID AfterExecuteSelect @12-19E4C132
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("STAFF_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("STAFF_ID")
            item.DEFAULT_TEACHER_IDItems.Add(Key, Val)
        Next
'End ListBox DEFAULT_TEACHER_ID AfterExecuteSelect

'ListBox KLA_ID Initialize Data Source @14-5840DC2C
        KLA_IDDataCommand.Dao._optimized = False
        Dim KLA_IDtableIndex As Integer = 0
        KLA_IDDataCommand.OrderBy = ""
        KLA_IDDataCommand.Parameters.Clear()
'End ListBox KLA_ID Initialize Data Source

'ListBox KLA_ID BeforeExecuteSelect @14-6F7DD353
        Try
            ListBoxSource=KLA_IDDataCommand.Execute().Tables(KLA_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox KLA_ID BeforeExecuteSelect

'ListBox KLA_ID AfterExecuteSelect @14-96D57492
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New FloatField("", ListBoxSource(j)("KLA_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("KEY_LEARNING_AREA")
            item.KLA_IDItems.Add(Key, Val)
        Next
'End ListBox KLA_ID AfterExecuteSelect

'ListBox VALID_COURSE_DISTRIBUTION AfterExecuteSelect @17-66A09160
        
item.VALID_COURSE_DISTRIBUTIONItems.Add("B","Book")
item.VALID_COURSE_DISTRIBUTIONItems.Add("C","CD")
item.VALID_COURSE_DISTRIBUTIONItems.Add("E","Email")
item.VALID_COURSE_DISTRIBUTIONItems.Add("I","Internet")
'End ListBox VALID_COURSE_DISTRIBUTION AfterExecuteSelect

'ListBox STATUS AfterExecuteSelect @20-BAC365F8
        
item.STATUSItems.Add("1","Active")
item.STATUSItems.Add("0","Inactive")
'End ListBox STATUS AfterExecuteSelect

'Record SUBJECT AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record SUBJECT AfterExecuteSelect tail

'Record SUBJECT Data Provider Class @2-A61BA892
End Class

'End Record SUBJECT Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

