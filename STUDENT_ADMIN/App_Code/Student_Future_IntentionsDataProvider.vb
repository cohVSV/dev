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

Namespace DECV_PROD2007.Student_Future_Intentions 'Namespace @1-3AEF8BD5

'Page Data Class @1-C7555605
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Link_Backtosummary As TextField
    Public Link_BacktosummaryHref As Object
    Public Link_BacktosummaryHrefParameters As LinkParameterCollection
    Public Link_BacktoPastoralList As TextField
    Public Link_BacktoPastoralListHref As Object
    Public Link_BacktoPastoralListHrefParameters As LinkParameterCollection
    Public Sub New()
        Link_Backtosummary = New TextField("",Nothing)
        Link_BacktosummaryHrefParameters = New LinkParameterCollection()
        Link_BacktoPastoralList = New TextField("",Nothing)
        Link_BacktoPastoralListHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Link_Backtosummary.SetValue(DBUtility.GetInitialValue("Link_Backtosummary"))
        item.Link_BacktoPastoralList.SetValue(DBUtility.GetInitialValue("Link_BacktoPastoralList"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Link_Backtosummary"
                    Return Link_Backtosummary
                Case "Link_BacktoPastoralList"
                    Return Link_BacktoPastoralList
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link_Backtosummary"
                    Link_Backtosummary = CType(value, TextField)
                Case "Link_BacktoPastoralList"
                    Link_BacktoPastoralList = CType(value, TextField)
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

'Record STUDENT_FUTURE_INTENTIONS Item Class @3-3B7F1B43
Public Class STUDENT_FUTURE_INTENTIONSItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public SCHOOL_NAME As TextField
    Public EMPLOYER_DETAIL As TextField
    Public RE_ENROLMENT_FLAG As TextField
    Public RE_ENROLMENT_FLAGItems As ItemCollection
    Public NEW_SCHOOL_FLAG As TextField
    Public NEW_SCHOOL_FLAGItems As ItemCollection
    Public LEAVING_FLAG As TextField
    Public LEAVING_FLAGItems As ItemCollection
    Public SEEKING_WORK_FLAG As TextField
    Public SEEKING_WORK_FLAGItems As ItemCollection
    Public EMPLOYMENT_FLAG As TextField
    Public EMPLOYMENT_FLAGItems As ItemCollection
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public STUDENT_ID As TextField
    Public ENROLMENT_YEAR As TextField
    Public Hidden_lastalteredby As TextField
    Public Hidden_lastaltered_date As DateField
    Public Hidden_student_id As TextField
    Public Hidden_enrolmentyear As TextField
    Public Sub New()
    SCHOOL_NAME = New TextField("", Nothing)
    EMPLOYER_DETAIL = New TextField("", Nothing)
    RE_ENROLMENT_FLAG = New TextField("", Nothing)
    RE_ENROLMENT_FLAGItems = New ItemCollection()
    NEW_SCHOOL_FLAG = New TextField("", Nothing)
    NEW_SCHOOL_FLAGItems = New ItemCollection()
    LEAVING_FLAG = New TextField("", Nothing)
    LEAVING_FLAGItems = New ItemCollection()
    SEEKING_WORK_FLAG = New TextField("", Nothing)
    SEEKING_WORK_FLAGItems = New ItemCollection()
    EMPLOYMENT_FLAG = New TextField("", Nothing)
    EMPLOYMENT_FLAGItems = New ItemCollection()
    LAST_ALTERED_BY = New TextField("", DBUtility.UserLogin.ToUpper())
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    STUDENT_ID = New TextField("", Nothing)
    ENROLMENT_YEAR = New TextField("", Nothing)
    Hidden_lastalteredby = New TextField("", DBUtility.UserLogin.ToUpper)
    Hidden_lastaltered_date = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    Hidden_student_id = New TextField("", Nothing)
    Hidden_enrolmentyear = New TextField("", Year(Today))
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_FUTURE_INTENTIONSItem
        Dim item As STUDENT_FUTURE_INTENTIONSItem = New STUDENT_FUTURE_INTENTIONSItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SCHOOL_NAME")) Then
        item.SCHOOL_NAME.SetValue(DBUtility.GetInitialValue("SCHOOL_NAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EMPLOYER_DETAIL")) Then
        item.EMPLOYER_DETAIL.SetValue(DBUtility.GetInitialValue("EMPLOYER_DETAIL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RE_ENROLMENT_FLAG")) Then
        item.RE_ENROLMENT_FLAG.SetValue(DBUtility.GetInitialValue("RE_ENROLMENT_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("NEW_SCHOOL_FLAG")) Then
        item.NEW_SCHOOL_FLAG.SetValue(DBUtility.GetInitialValue("NEW_SCHOOL_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LEAVING_FLAG")) Then
        item.LEAVING_FLAG.SetValue(DBUtility.GetInitialValue("LEAVING_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SEEKING_WORK_FLAG")) Then
        item.SEEKING_WORK_FLAG.SetValue(DBUtility.GetInitialValue("SEEKING_WORK_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EMPLOYMENT_FLAG")) Then
        item.EMPLOYMENT_FLAG.SetValue(DBUtility.GetInitialValue("EMPLOYMENT_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_YEAR")) Then
        item.ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_lastalteredby")) Then
        item.Hidden_lastalteredby.SetValue(DBUtility.GetInitialValue("Hidden_lastalteredby"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_lastaltered_date")) Then
        item.Hidden_lastaltered_date.SetValue(DBUtility.GetInitialValue("Hidden_lastaltered_date"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_student_id")) Then
        item.Hidden_student_id.SetValue(DBUtility.GetInitialValue("Hidden_student_id"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_enrolmentyear")) Then
        item.Hidden_enrolmentyear.SetValue(DBUtility.GetInitialValue("Hidden_enrolmentyear"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "SCHOOL_NAME"
                    Return SCHOOL_NAME
                Case "EMPLOYER_DETAIL"
                    Return EMPLOYER_DETAIL
                Case "RE_ENROLMENT_FLAG"
                    Return RE_ENROLMENT_FLAG
                Case "NEW_SCHOOL_FLAG"
                    Return NEW_SCHOOL_FLAG
                Case "LEAVING_FLAG"
                    Return LEAVING_FLAG
                Case "SEEKING_WORK_FLAG"
                    Return SEEKING_WORK_FLAG
                Case "EMPLOYMENT_FLAG"
                    Return EMPLOYMENT_FLAG
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "ENROLMENT_YEAR"
                    Return ENROLMENT_YEAR
                Case "Hidden_lastalteredby"
                    Return Hidden_lastalteredby
                Case "Hidden_lastaltered_date"
                    Return Hidden_lastaltered_date
                Case "Hidden_student_id"
                    Return Hidden_student_id
                Case "Hidden_enrolmentyear"
                    Return Hidden_enrolmentyear
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SCHOOL_NAME"
                    SCHOOL_NAME = CType(value, TextField)
                Case "EMPLOYER_DETAIL"
                    EMPLOYER_DETAIL = CType(value, TextField)
                Case "RE_ENROLMENT_FLAG"
                    RE_ENROLMENT_FLAG = CType(value, TextField)
                Case "NEW_SCHOOL_FLAG"
                    NEW_SCHOOL_FLAG = CType(value, TextField)
                Case "LEAVING_FLAG"
                    LEAVING_FLAG = CType(value, TextField)
                Case "SEEKING_WORK_FLAG"
                    SEEKING_WORK_FLAG = CType(value, TextField)
                Case "EMPLOYMENT_FLAG"
                    EMPLOYMENT_FLAG = CType(value, TextField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, TextField)
                Case "ENROLMENT_YEAR"
                    ENROLMENT_YEAR = CType(value, TextField)
                Case "Hidden_lastalteredby"
                    Hidden_lastalteredby = CType(value, TextField)
                Case "Hidden_lastaltered_date"
                    Hidden_lastaltered_date = CType(value, DateField)
                Case "Hidden_student_id"
                    Hidden_student_id = CType(value, TextField)
                Case "Hidden_enrolmentyear"
                    Hidden_enrolmentyear = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STUDENT_FUTURE_INTENTIONSDataProvider)
'End Record STUDENT_FUTURE_INTENTIONS Item Class

'RE_ENROLMENT_FLAG validate @20-DD2CB0F4
        If IsNothing(RE_ENROLMENT_FLAG.Value) OrElse RE_ENROLMENT_FLAG.Value.ToString() ="" Then
            errors.Add("RE_ENROLMENT_FLAG",String.Format(Resources.strings.CCS_RequiredField,"RE-ENROL AT VSV"))
        End If
'End RE_ENROLMENT_FLAG validate

'NEW_SCHOOL_FLAG validate @21-08F104DC
        If IsNothing(NEW_SCHOOL_FLAG.Value) OrElse NEW_SCHOOL_FLAG.Value.ToString() ="" Then
            errors.Add("NEW_SCHOOL_FLAG",String.Format(Resources.strings.CCS_RequiredField,"ENROL OTHER SCHOOL or INSTITUTION"))
        End If
'End NEW_SCHOOL_FLAG validate

'LEAVING_FLAG validate @22-3C533013
        If IsNothing(LEAVING_FLAG.Value) OrElse LEAVING_FLAG.Value.ToString() ="" Then
            errors.Add("LEAVING_FLAG",String.Format(Resources.strings.CCS_RequiredField,"LEAVING SCHOOL"))
        End If
'End LEAVING_FLAG validate

'SEEKING_WORK_FLAG validate @23-16045B0B
        If IsNothing(SEEKING_WORK_FLAG.Value) OrElse SEEKING_WORK_FLAG.Value.ToString() ="" Then
            errors.Add("SEEKING_WORK_FLAG",String.Format(Resources.strings.CCS_RequiredField,"SEEKING FULL-TIME WORK"))
        End If
'End SEEKING_WORK_FLAG validate

'EMPLOYMENT_FLAG validate @24-7604BB86
        If IsNothing(EMPLOYMENT_FLAG.Value) OrElse EMPLOYMENT_FLAG.Value.ToString() ="" Then
            errors.Add("EMPLOYMENT_FLAG",String.Format(Resources.strings.CCS_RequiredField,"ENGAGED IN FULL TIME EMPLOYMENT"))
        End If
'End EMPLOYMENT_FLAG validate

'Hidden_student_id validate @34-167D2D48
        If IsNothing(Hidden_student_id.Value) OrElse Hidden_student_id.Value.ToString() ="" Then
            errors.Add("Hidden_student_id",String.Format(Resources.strings.CCS_RequiredField,"STUDENT ID"))
        End If
'End Hidden_student_id validate

'Record STUDENT_FUTURE_INTENTIONS Item Class tail @3-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_FUTURE_INTENTIONS Item Class tail

'Record STUDENT_FUTURE_INTENTIONS Data Provider Class @3-35572221
Public Class STUDENT_FUTURE_INTENTIONSDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_FUTURE_INTENTIONS Data Provider Class

'Record STUDENT_FUTURE_INTENTIONS Data Provider Class Variables @3-FCF9A568
    Public UrlSTUDENT_ID As FloatParameter
    Public UrlENROLMENT_YEAR As FloatParameter
    Protected item As STUDENT_FUTURE_INTENTIONSItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_FUTURE_INTENTIONS Data Provider Class Variables

'Record STUDENT_FUTURE_INTENTIONS Data Provider Class Constructor @3-7E3F49B4

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_FUTURE_INTENTIONS {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID6","And","ENROLMENT_YEAR39"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_FUTURE_INTENTIONS Data Provider Class Constructor

'Record STUDENT_FUTURE_INTENTIONS Data Provider Class LoadParams Method @3-79390024

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID) Or IsNothing(UrlENROLMENT_YEAR))
    End Function
'End Record STUDENT_FUTURE_INTENTIONS Data Provider Class LoadParams Method

'Record STUDENT_FUTURE_INTENTIONS Data Provider Class CheckUnique Method @3-CAC4F960

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_FUTURE_INTENTIONSItem) As Boolean
        Return True
    End Function
'End Record STUDENT_FUTURE_INTENTIONS Data Provider Class CheckUnique Method

'Record STUDENT_FUTURE_INTENTIONS Data Provider Class PrepareInsert Method @3-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STUDENT_FUTURE_INTENTIONS Data Provider Class PrepareInsert Method

'Record STUDENT_FUTURE_INTENTIONS Data Provider Class PrepareInsert Method tail @3-E31F8E2A
    End Sub
'End Record STUDENT_FUTURE_INTENTIONS Data Provider Class PrepareInsert Method tail

'Record STUDENT_FUTURE_INTENTIONS Data Provider Class Insert Method @3-EF88E7A1

    Public Function InsertItem(ByVal item As STUDENT_FUTURE_INTENTIONSItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO STUDENT_FUTURE_INTENTIONS({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_FUTURE_INTENTIONS Data Provider Class Insert Method

'Record STUDENT_FUTURE_INTENTIONS Build insert @3-9361B968
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.SCHOOL_NAME.IsEmpty Then
        allEmptyFlag = item.SCHOOL_NAME.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SCHOOL_NAME,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SCHOOL_NAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.EMPLOYER_DETAIL.IsEmpty Then
        allEmptyFlag = item.EMPLOYER_DETAIL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "EMPLOYER_DETAIL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.EMPLOYER_DETAIL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RE_ENROLMENT_FLAG.IsEmpty Then
        allEmptyFlag = item.RE_ENROLMENT_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "RE_ENROLMENT_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.RE_ENROLMENT_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.NEW_SCHOOL_FLAG.IsEmpty Then
        allEmptyFlag = item.NEW_SCHOOL_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "NEW_SCHOOL_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.NEW_SCHOOL_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LEAVING_FLAG.IsEmpty Then
        allEmptyFlag = item.LEAVING_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LEAVING_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LEAVING_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SEEKING_WORK_FLAG.IsEmpty Then
        allEmptyFlag = item.SEEKING_WORK_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SEEKING_WORK_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SEEKING_WORK_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.EMPLOYMENT_FLAG.IsEmpty Then
        allEmptyFlag = item.EMPLOYMENT_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "EMPLOYMENT_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.EMPLOYMENT_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_lastalteredby.IsEmpty Then
        allEmptyFlag = item.Hidden_lastalteredby.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_lastalteredby.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_lastaltered_date.IsEmpty Then
        allEmptyFlag = item.Hidden_lastaltered_date.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_lastaltered_date.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.Hidden_student_id.IsEmpty Then
        allEmptyFlag = item.Hidden_student_id.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STUDENT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_student_id.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_enrolmentyear.IsEmpty Then
        allEmptyFlag = item.Hidden_enrolmentyear.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ENROLMENT_YEAR,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_enrolmentyear.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STUDENT_FUTURE_INTENTIONS Build insert

'Record STUDENT_FUTURE_INTENTIONS AfterExecuteInsert @3-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_FUTURE_INTENTIONS AfterExecuteInsert

'Record STUDENT_FUTURE_INTENTIONS Data Provider Class PrepareUpdate Method @3-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STUDENT_FUTURE_INTENTIONS Data Provider Class PrepareUpdate Method

'Record STUDENT_FUTURE_INTENTIONS Data Provider Class PrepareUpdate Method tail @3-E31F8E2A
    End Sub
'End Record STUDENT_FUTURE_INTENTIONS Data Provider Class PrepareUpdate Method tail

'Record STUDENT_FUTURE_INTENTIONS Data Provider Class Update Method @3-2193CC26

    Public Function UpdateItem(ByVal item As STUDENT_FUTURE_INTENTIONSItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT_FUTURE_INTENTIONS SET {Values}", New String(){"STUDENT_ID6","And","ENROLMENT_YEAR39"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_FUTURE_INTENTIONS Data Provider Class Update Method

'Record STUDENT_FUTURE_INTENTIONS BeforeBuildUpdate @3-CF4CBA38
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID6",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ENROLMENT_YEAR39",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        If Not item.SCHOOL_NAME.IsEmpty Then
        allEmptyFlag = item.SCHOOL_NAME.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SCHOOL_NAME=" + Update.Dao.ToSql(item.SCHOOL_NAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.EMPLOYER_DETAIL.IsEmpty Then
        allEmptyFlag = item.EMPLOYER_DETAIL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "EMPLOYER_DETAIL=" + Update.Dao.ToSql(item.EMPLOYER_DETAIL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RE_ENROLMENT_FLAG.IsEmpty Then
        allEmptyFlag = item.RE_ENROLMENT_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "RE_ENROLMENT_FLAG=" + Update.Dao.ToSql(item.RE_ENROLMENT_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.NEW_SCHOOL_FLAG.IsEmpty Then
        allEmptyFlag = item.NEW_SCHOOL_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "NEW_SCHOOL_FLAG=" + Update.Dao.ToSql(item.NEW_SCHOOL_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LEAVING_FLAG.IsEmpty Then
        allEmptyFlag = item.LEAVING_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LEAVING_FLAG=" + Update.Dao.ToSql(item.LEAVING_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SEEKING_WORK_FLAG.IsEmpty Then
        allEmptyFlag = item.SEEKING_WORK_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SEEKING_WORK_FLAG=" + Update.Dao.ToSql(item.SEEKING_WORK_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.EMPLOYMENT_FLAG.IsEmpty Then
        allEmptyFlag = item.EMPLOYMENT_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "EMPLOYMENT_FLAG=" + Update.Dao.ToSql(item.EMPLOYMENT_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_lastalteredby.IsEmpty Then
        allEmptyFlag = item.Hidden_lastalteredby.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.Hidden_lastalteredby.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_lastaltered_date.IsEmpty Then
        allEmptyFlag = item.Hidden_lastaltered_date.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.Hidden_lastaltered_date.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.Hidden_student_id.IsEmpty Then
        allEmptyFlag = item.Hidden_student_id.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STUDENT_ID=" + Update.Dao.ToSql(item.Hidden_student_id.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_enrolmentyear.IsEmpty Then
        allEmptyFlag = item.Hidden_enrolmentyear.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ENROLMENT_YEAR=" + Update.Dao.ToSql(item.Hidden_enrolmentyear.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STUDENT_FUTURE_INTENTIONS BeforeBuildUpdate

'Record STUDENT_FUTURE_INTENTIONS AfterExecuteUpdate @3-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_FUTURE_INTENTIONS AfterExecuteUpdate

'Record STUDENT_FUTURE_INTENTIONS Data Provider Class GetResultSet Method @3-365F1E0E

    Public Sub FillItem(ByVal item As STUDENT_FUTURE_INTENTIONSItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_FUTURE_INTENTIONS Data Provider Class GetResultSet Method

'Record STUDENT_FUTURE_INTENTIONS BeforeBuildSelect @3-85D4319F
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID6",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("ENROLMENT_YEAR39",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_FUTURE_INTENTIONS BeforeBuildSelect

'Record STUDENT_FUTURE_INTENTIONS BeforeExecuteSelect @3-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_FUTURE_INTENTIONS BeforeExecuteSelect

'Record STUDENT_FUTURE_INTENTIONS AfterExecuteSelect @3-4B0BD340
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.SCHOOL_NAME.SetValue(dr(i)("SCHOOL_NAME"),"")
            item.EMPLOYER_DETAIL.SetValue(dr(i)("EMPLOYER_DETAIL"),"")
            item.RE_ENROLMENT_FLAG.SetValue(dr(i)("RE_ENROLMENT_FLAG"),"")
            item.NEW_SCHOOL_FLAG.SetValue(dr(i)("NEW_SCHOOL_FLAG"),"")
            item.LEAVING_FLAG.SetValue(dr(i)("LEAVING_FLAG"),"")
            item.SEEKING_WORK_FLAG.SetValue(dr(i)("SEEKING_WORK_FLAG"),"")
            item.EMPLOYMENT_FLAG.SetValue(dr(i)("EMPLOYMENT_FLAG"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.ENROLMENT_YEAR.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.Hidden_lastalteredby.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.Hidden_lastaltered_date.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.Hidden_student_id.SetValue(dr(i)("STUDENT_ID"),"")
            item.Hidden_enrolmentyear.SetValue(dr(i)("ENROLMENT_YEAR"),"")
        Else
            IsInsertMode = True
        End If
'End Record STUDENT_FUTURE_INTENTIONS AfterExecuteSelect

'ListBox RE_ENROLMENT_FLAG AfterExecuteSelect @20-3911CBF3
        
item.RE_ENROLMENT_FLAGItems.Add("Y","Yes")
item.RE_ENROLMENT_FLAGItems.Add("N","No")
item.RE_ENROLMENT_FLAGItems.Add("U","Unknown")
'End ListBox RE_ENROLMENT_FLAG AfterExecuteSelect

'ListBox NEW_SCHOOL_FLAG AfterExecuteSelect @21-C6811E15
        
item.NEW_SCHOOL_FLAGItems.Add("Y","Yes")
item.NEW_SCHOOL_FLAGItems.Add("N","No")
item.NEW_SCHOOL_FLAGItems.Add("U","Unknown")
'End ListBox NEW_SCHOOL_FLAG AfterExecuteSelect

'ListBox LEAVING_FLAG AfterExecuteSelect @22-7B30587C
        
item.LEAVING_FLAGItems.Add("Y","Yes")
item.LEAVING_FLAGItems.Add("N","No")
item.LEAVING_FLAGItems.Add("U","Unknown")
'End ListBox LEAVING_FLAG AfterExecuteSelect

'ListBox SEEKING_WORK_FLAG AfterExecuteSelect @23-BD1D06D0
        
item.SEEKING_WORK_FLAGItems.Add("Y","Yes")
item.SEEKING_WORK_FLAGItems.Add("N","No")
item.SEEKING_WORK_FLAGItems.Add("U","Unknown")
'End ListBox SEEKING_WORK_FLAG AfterExecuteSelect

'ListBox EMPLOYMENT_FLAG AfterExecuteSelect @24-F3935B1D
        
item.EMPLOYMENT_FLAGItems.Add("Y","Yes")
item.EMPLOYMENT_FLAGItems.Add("N","No")
item.EMPLOYMENT_FLAGItems.Add("U","Unknown")
'End ListBox EMPLOYMENT_FLAG AfterExecuteSelect

'Record STUDENT_FUTURE_INTENTIONS AfterExecuteSelect tail @3-E31F8E2A
    End Sub
'End Record STUDENT_FUTURE_INTENTIONS AfterExecuteSelect tail

'Record STUDENT_FUTURE_INTENTIONS Data Provider Class @3-A61BA892
End Class

'End Record STUDENT_FUTURE_INTENTIONS Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

