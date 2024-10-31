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

Namespace DECV_PROD2007.CONTRIBUTION_maint 'Namespace @1-8D65252F

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

'Record CONTRIBUTION Item Class @2-394250AF
Public Class CONTRIBUTIONItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public SCHOOL_TYPE_CODE As TextField
    Public SCHOOL_TYPE_CODEItems As ItemCollection
    Public CAMPUS_CODE As TextField
    Public CAMPUS_CODEItems As ItemCollection
    Public FROM_YEAR_LEVEL As IntegerField
    Public TO_YEAR_LEVEL As IntegerField
    Public PER_SUBJECT_FLAG As BooleanField
    Public PER_SUBJECT_FLAGCheckedValue As BooleanField
    Public PER_SUBJECT_FLAGUncheckedValue As BooleanField
    Public DEFAULT_CONTRIBUTION As SingleField
    Public DISCOUNT_AMOUNT As SingleField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public CATEGORY As TextField
    Public Sub New()
    SCHOOL_TYPE_CODE = New TextField("", Nothing)
    SCHOOL_TYPE_CODEItems = New ItemCollection()
    CAMPUS_CODE = New TextField("", Nothing)
    CAMPUS_CODEItems = New ItemCollection()
    FROM_YEAR_LEVEL = New IntegerField("", Nothing)
    TO_YEAR_LEVEL = New IntegerField("", Nothing)
    PER_SUBJECT_FLAG = New BooleanField(Settings.BoolFormat, False)
    PER_SUBJECT_FLAGCheckedValue = New BooleanField(Settings.BoolFormat, True)
    PER_SUBJECT_FLAGUncheckedValue = New BooleanField(Settings.BoolFormat, False)
    DEFAULT_CONTRIBUTION = New SingleField("", Nothing)
    DISCOUNT_AMOUNT = New SingleField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    CATEGORY = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As CONTRIBUTIONItem
        Dim item As CONTRIBUTIONItem = New CONTRIBUTIONItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SCHOOL_TYPE_CODE")) Then
        item.SCHOOL_TYPE_CODE.SetValue(DBUtility.GetInitialValue("SCHOOL_TYPE_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CAMPUS_CODE")) Then
        item.CAMPUS_CODE.SetValue(DBUtility.GetInitialValue("CAMPUS_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FROM_YEAR_LEVEL")) Then
        item.FROM_YEAR_LEVEL.SetValue(DBUtility.GetInitialValue("FROM_YEAR_LEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("TO_YEAR_LEVEL")) Then
        item.TO_YEAR_LEVEL.SetValue(DBUtility.GetInitialValue("TO_YEAR_LEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PER_SUBJECT_FLAG")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("PER_SUBJECT_FLAG")) Then
            item.PER_SUBJECT_FLAG.Value = item.PER_SUBJECT_FLAGCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DEFAULT_CONTRIBUTION")) Then
        item.DEFAULT_CONTRIBUTION.SetValue(DBUtility.GetInitialValue("DEFAULT_CONTRIBUTION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DISCOUNT_AMOUNT")) Then
        item.DISCOUNT_AMOUNT.SetValue(DBUtility.GetInitialValue("DISCOUNT_AMOUNT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Buttoncancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CATEGORY")) Then
        item.CATEGORY.SetValue(DBUtility.GetInitialValue("CATEGORY"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "SCHOOL_TYPE_CODE"
                    Return SCHOOL_TYPE_CODE
                Case "CAMPUS_CODE"
                    Return CAMPUS_CODE
                Case "FROM_YEAR_LEVEL"
                    Return FROM_YEAR_LEVEL
                Case "TO_YEAR_LEVEL"
                    Return TO_YEAR_LEVEL
                Case "PER_SUBJECT_FLAG"
                    Return PER_SUBJECT_FLAG
                Case "DEFAULT_CONTRIBUTION"
                    Return DEFAULT_CONTRIBUTION
                Case "DISCOUNT_AMOUNT"
                    Return DISCOUNT_AMOUNT
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "CATEGORY"
                    Return CATEGORY
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SCHOOL_TYPE_CODE"
                    SCHOOL_TYPE_CODE = CType(value, TextField)
                Case "CAMPUS_CODE"
                    CAMPUS_CODE = CType(value, TextField)
                Case "FROM_YEAR_LEVEL"
                    FROM_YEAR_LEVEL = CType(value, IntegerField)
                Case "TO_YEAR_LEVEL"
                    TO_YEAR_LEVEL = CType(value, IntegerField)
                Case "PER_SUBJECT_FLAG"
                    PER_SUBJECT_FLAG = CType(value, BooleanField)
                Case "DEFAULT_CONTRIBUTION"
                    DEFAULT_CONTRIBUTION = CType(value, SingleField)
                Case "DISCOUNT_AMOUNT"
                    DISCOUNT_AMOUNT = CType(value, SingleField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "CATEGORY"
                    CATEGORY = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As CONTRIBUTIONDataProvider)
'End Record CONTRIBUTION Item Class

'SCHOOL_TYPE_CODE validate @7-DC2704D6
        If IsNothing(SCHOOL_TYPE_CODE.Value) OrElse SCHOOL_TYPE_CODE.Value.ToString() ="" Then
            errors.Add("SCHOOL_TYPE_CODE",String.Format(Resources.strings.CCS_RequiredField,"SCHOOL TYPE CODE"))
        End If
'End SCHOOL_TYPE_CODE validate

'CAMPUS_CODE validate @8-E6F21D52
        If IsNothing(CAMPUS_CODE.Value) OrElse CAMPUS_CODE.Value.ToString() ="" Then
            errors.Add("CAMPUS_CODE",String.Format(Resources.strings.CCS_RequiredField,"CAMPUS CODE"))
        End If
'End CAMPUS_CODE validate

'FROM_YEAR_LEVEL validate @9-DBECF43B
        If IsNothing(FROM_YEAR_LEVEL.Value) OrElse FROM_YEAR_LEVEL.Value.ToString() ="" Then
            errors.Add("FROM_YEAR_LEVEL",String.Format(Resources.strings.CCS_RequiredField,"FROM YEAR LEVEL"))
        End If
'End FROM_YEAR_LEVEL validate

'TO_YEAR_LEVEL validate @10-5E29939C
        If IsNothing(TO_YEAR_LEVEL.Value) OrElse TO_YEAR_LEVEL.Value.ToString() ="" Then
            errors.Add("TO_YEAR_LEVEL",String.Format(Resources.strings.CCS_RequiredField,"TO YEAR LEVEL"))
        End If
'End TO_YEAR_LEVEL validate

'PER_SUBJECT_FLAG validate @11-5F833E4C
        If IsNothing(PER_SUBJECT_FLAG.Value) OrElse PER_SUBJECT_FLAG.Value.ToString() ="" Then
            errors.Add("PER_SUBJECT_FLAG",String.Format(Resources.strings.CCS_RequiredField,"PER SUBJECT FLAG"))
        End If
'End PER_SUBJECT_FLAG validate

'DEFAULT_CONTRIBUTION validate @12-DCD7F488
        If IsNothing(DEFAULT_CONTRIBUTION.Value) OrElse DEFAULT_CONTRIBUTION.Value.ToString() ="" Then
            errors.Add("DEFAULT_CONTRIBUTION",String.Format(Resources.strings.CCS_RequiredField,"DEFAULT CONTRIBUTION"))
        End If
'End DEFAULT_CONTRIBUTION validate

'DISCOUNT_AMOUNT validate @13-CD09D605
        If IsNothing(DISCOUNT_AMOUNT.Value) OrElse DISCOUNT_AMOUNT.Value.ToString() ="" Then
            errors.Add("DISCOUNT_AMOUNT",String.Format(Resources.strings.CCS_RequiredField,"DISCOUNT AMOUNT"))
        End If
'End DISCOUNT_AMOUNT validate

'LAST_ALTERED_BY validate @14-256A6854
        If IsNothing(LAST_ALTERED_BY.Value) OrElse LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End LAST_ALTERED_BY validate

'LAST_ALTERED_DATE validate @15-C5989D76
        If IsNothing(LAST_ALTERED_DATE.Value) OrElse LAST_ALTERED_DATE.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED DATE"))
        End If
'End LAST_ALTERED_DATE validate

'Record CONTRIBUTION Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record CONTRIBUTION Item Class tail

'Record CONTRIBUTION Data Provider Class @2-E3EE2031
Public Class CONTRIBUTIONDataProvider
Inherits RecordDataProviderBase
'End Record CONTRIBUTION Data Provider Class

'Record CONTRIBUTION Data Provider Class Variables @2-E2349B97
    Protected SCHOOL_TYPE_CODEDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM SCHOOL_TYPE {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected CAMPUS_CODEDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM CAMPUS {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Public UrlCATEGORY_CODE As TextParameter
    Public UrlSCHOOL_TYPE_CODE As TextParameter
    Public UrlCAMPUS_CODE As TextParameter
    Public UrlFROM_YEAR_LEVEL As IntegerParameter
    Public UrlTO_YEAR_LEVEL As IntegerParameter
    Protected item As CONTRIBUTIONItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record CONTRIBUTION Data Provider Class Variables

'Record CONTRIBUTION Data Provider Class Constructor @2-65894C5E

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM CONTRIBUTION {SQL_Where} {SQL_OrderBy}", New String(){"CATEGORY_CODE6","And","SCHOOL_TYPE_CODE22","And","CAMPUS_CODE23","And","FROM_YEAR_LEVEL24","And","TO_YEAR_LEVEL25"},Settings.connDECVPRODSQL2005DataAccessObject )
        Delete=new TableCommand("DELETE FROM CONTRIBUTION", New String(){"CATEGORY_CODE6","And","SCHOOL_TYPE_CODE22","And","CAMPUS_CODE23","And","FROM_YEAR_LEVEL24","And","TO_YEAR_LEVEL25"},Settings.connDECVPRODSQL2005DataAccessObject , true)
        Select_.OrderBy=""
    End Sub
'End Record CONTRIBUTION Data Provider Class Constructor

'Record CONTRIBUTION Data Provider Class LoadParams Method @2-3923BA0E

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlCATEGORY_CODE) Or IsNothing(UrlSCHOOL_TYPE_CODE) Or IsNothing(UrlCAMPUS_CODE) Or IsNothing(UrlFROM_YEAR_LEVEL) Or IsNothing(UrlTO_YEAR_LEVEL))
    End Function
'End Record CONTRIBUTION Data Provider Class LoadParams Method

'Record CONTRIBUTION Data Provider Class CheckUnique Method @2-8E97F4D9

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As CONTRIBUTIONItem) As Boolean
        Return True
    End Function
'End Record CONTRIBUTION Data Provider Class CheckUnique Method

'Record CONTRIBUTION Data Provider Class PrepareInsert Method @2-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record CONTRIBUTION Data Provider Class PrepareInsert Method

'Record CONTRIBUTION Data Provider Class PrepareInsert Method tail @2-E31F8E2A
    End Sub
'End Record CONTRIBUTION Data Provider Class PrepareInsert Method tail

'Record CONTRIBUTION Data Provider Class Insert Method @2-3FA3F6A7

    Public Function InsertItem(ByVal item As CONTRIBUTIONItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO CONTRIBUTION({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record CONTRIBUTION Data Provider Class Insert Method

'Record CONTRIBUTION Build insert @2-E7701412
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.SCHOOL_TYPE_CODE.IsEmpty Then
        allEmptyFlag = item.SCHOOL_TYPE_CODE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SCHOOL_TYPE_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SCHOOL_TYPE_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CAMPUS_CODE.IsEmpty Then
        allEmptyFlag = item.CAMPUS_CODE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CAMPUS_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CAMPUS_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.FROM_YEAR_LEVEL.IsEmpty Then
        allEmptyFlag = item.FROM_YEAR_LEVEL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "FROM_YEAR_LEVEL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.FROM_YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.TO_YEAR_LEVEL.IsEmpty Then
        allEmptyFlag = item.TO_YEAR_LEVEL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "TO_YEAR_LEVEL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.TO_YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.PER_SUBJECT_FLAG.IsEmpty Then
        allEmptyFlag = item.PER_SUBJECT_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PER_SUBJECT_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PER_SUBJECT_FLAG.GetFormattedValue(Insert.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.DEFAULT_CONTRIBUTION.IsEmpty Then
        allEmptyFlag = item.DEFAULT_CONTRIBUTION.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "DEFAULT_CONTRIBUTION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.DEFAULT_CONTRIBUTION.GetFormattedValue(""),FieldType._Single) & ","
        End If
        If Not item.DISCOUNT_AMOUNT.IsEmpty Then
        allEmptyFlag = item.DISCOUNT_AMOUNT.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "DISCOUNT_AMOUNT,"
        valuesList = valuesList & Insert.Dao.ToSql(item.DISCOUNT_AMOUNT.GetFormattedValue(""),FieldType._Single) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.CATEGORY.IsEmpty Then
        allEmptyFlag = item.CATEGORY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CATEGORY_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CATEGORY.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record CONTRIBUTION Build insert

'Record CONTRIBUTION AfterExecuteInsert @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record CONTRIBUTION AfterExecuteInsert

'Record CONTRIBUTION Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record CONTRIBUTION Data Provider Class PrepareUpdate Method

'Record CONTRIBUTION Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record CONTRIBUTION Data Provider Class PrepareUpdate Method tail

'Record CONTRIBUTION Data Provider Class Update Method @2-99A420CA

    Public Function UpdateItem(ByVal item As CONTRIBUTIONItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE CONTRIBUTION SET {Values}", New String(){"CATEGORY_CODE6","And","SCHOOL_TYPE_CODE22","And","CAMPUS_CODE23","And","FROM_YEAR_LEVEL24","And","TO_YEAR_LEVEL25"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record CONTRIBUTION Data Provider Class Update Method

'Record CONTRIBUTION BeforeBuildUpdate @2-FE479D5A
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("CATEGORY_CODE6",UrlCATEGORY_CODE, "","CATEGORY_CODE",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("SCHOOL_TYPE_CODE22",UrlSCHOOL_TYPE_CODE, "","SCHOOL_TYPE_CODE",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("CAMPUS_CODE23",UrlCAMPUS_CODE, "","CAMPUS_CODE",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("FROM_YEAR_LEVEL24",UrlFROM_YEAR_LEVEL, "","FROM_YEAR_LEVEL",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("TO_YEAR_LEVEL25",UrlTO_YEAR_LEVEL, "","TO_YEAR_LEVEL",Condition.Equal,False)
        If Not item.SCHOOL_TYPE_CODE.IsEmpty Then
        allEmptyFlag = item.SCHOOL_TYPE_CODE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SCHOOL_TYPE_CODE=" + Update.Dao.ToSql(item.SCHOOL_TYPE_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CAMPUS_CODE.IsEmpty Then
        allEmptyFlag = item.CAMPUS_CODE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CAMPUS_CODE=" + Update.Dao.ToSql(item.CAMPUS_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.FROM_YEAR_LEVEL.IsEmpty Then
        allEmptyFlag = item.FROM_YEAR_LEVEL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "FROM_YEAR_LEVEL=" + Update.Dao.ToSql(item.FROM_YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.TO_YEAR_LEVEL.IsEmpty Then
        allEmptyFlag = item.TO_YEAR_LEVEL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "TO_YEAR_LEVEL=" + Update.Dao.ToSql(item.TO_YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.PER_SUBJECT_FLAG.IsEmpty Then
        allEmptyFlag = item.PER_SUBJECT_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PER_SUBJECT_FLAG=" + Update.Dao.ToSql(item.PER_SUBJECT_FLAG.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.DEFAULT_CONTRIBUTION.IsEmpty Then
        allEmptyFlag = item.DEFAULT_CONTRIBUTION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DEFAULT_CONTRIBUTION=" + Update.Dao.ToSql(item.DEFAULT_CONTRIBUTION.GetFormattedValue(""),FieldType._Single) & ","
        End If
        If Not item.DISCOUNT_AMOUNT.IsEmpty Then
        allEmptyFlag = item.DISCOUNT_AMOUNT.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DISCOUNT_AMOUNT=" + Update.Dao.ToSql(item.DISCOUNT_AMOUNT.GetFormattedValue(""),FieldType._Single) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.CATEGORY.IsEmpty Then
        allEmptyFlag = item.CATEGORY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CATEGORY_CODE=" + Update.Dao.ToSql(item.CATEGORY.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record CONTRIBUTION BeforeBuildUpdate

'Record CONTRIBUTION AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record CONTRIBUTION AfterExecuteUpdate

'Record CONTRIBUTION Data Provider Class PrepareDelete Method @2-F7361E57

    Protected Overrides Sub PrepareDelete()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record CONTRIBUTION Data Provider Class PrepareDelete Method

'Record CONTRIBUTION Data Provider Class PrepareDelete Method tail @2-E31F8E2A
    End Sub
'End Record CONTRIBUTION Data Provider Class PrepareDelete Method tail

'Record CONTRIBUTION Data Provider Class Delete Method @2-37648242
    Public Function DeleteItem(ByVal item As CONTRIBUTIONItem) As Integer
        Me.item = item
'End Record CONTRIBUTION Data Provider Class Delete Method

'Record CONTRIBUTION BeforeBuildDelete @2-BD98D63C
        Delete.Parameters.Clear()
        CType(Delete,TableCommand).AddParameter("CATEGORY_CODE6",UrlCATEGORY_CODE, "","CATEGORY_CODE",Condition.Equal,False)
        CType(Delete,TableCommand).AddParameter("SCHOOL_TYPE_CODE22",UrlSCHOOL_TYPE_CODE, "","SCHOOL_TYPE_CODE",Condition.Equal,False)
        CType(Delete,TableCommand).AddParameter("CAMPUS_CODE23",UrlCAMPUS_CODE, "","CAMPUS_CODE",Condition.Equal,False)
        CType(Delete,TableCommand).AddParameter("FROM_YEAR_LEVEL24",UrlFROM_YEAR_LEVEL, "","FROM_YEAR_LEVEL",Condition.Equal,False)
        CType(Delete,TableCommand).AddParameter("TO_YEAR_LEVEL25",UrlTO_YEAR_LEVEL, "","TO_YEAR_LEVEL",Condition.Equal,False)
        Delete.SqlQuery.Replace("{SCHOOL_TYPE_CODE}",Delete.Dao.ToSql(item.SCHOOL_TYPE_CODE.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{CAMPUS_CODE}",Delete.Dao.ToSql(item.CAMPUS_CODE.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{FROM_YEAR_LEVEL}",Delete.Dao.ToSql(item.FROM_YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer))
        Delete.SqlQuery.Replace("{TO_YEAR_LEVEL}",Delete.Dao.ToSql(item.TO_YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer))
        Delete.SqlQuery.Replace("{PER_SUBJECT_FLAG}",Delete.Dao.ToSql(item.PER_SUBJECT_FLAG.GetFormattedValue(Delete.BoolFormat),FieldType._Boolean))
        Delete.SqlQuery.Replace("{DEFAULT_CONTRIBUTION}",Delete.Dao.ToSql(item.DEFAULT_CONTRIBUTION.GetFormattedValue(""),FieldType._Single))
        Delete.SqlQuery.Replace("{DISCOUNT_AMOUNT}",Delete.Dao.ToSql(item.DISCOUNT_AMOUNT.GetFormattedValue(""),FieldType._Single))
        Delete.SqlQuery.Replace("{LAST_ALTERED_BY}",Delete.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{LAST_ALTERED_DATE}",Delete.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Delete.DateFormat),FieldType._Date))
        Delete.SqlQuery.Replace("{CATEGORY}",Delete.Dao.ToSql(item.CATEGORY.GetFormattedValue(""),FieldType._Text))
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
            result = ExecuteDelete()
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record CONTRIBUTION BeforeBuildDelete

'Record CONTRIBUTION BeforeBuildDelete @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record CONTRIBUTION BeforeBuildDelete

'Record CONTRIBUTION Data Provider Class GetResultSet Method @2-2DD26360

    Public Sub FillItem(ByVal item As CONTRIBUTIONItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record CONTRIBUTION Data Provider Class GetResultSet Method

'Record CONTRIBUTION BeforeBuildSelect @2-2B35B1EB
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("CATEGORY_CODE6",UrlCATEGORY_CODE, "","CATEGORY_CODE",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("SCHOOL_TYPE_CODE22",UrlSCHOOL_TYPE_CODE, "","SCHOOL_TYPE_CODE",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("CAMPUS_CODE23",UrlCAMPUS_CODE, "","CAMPUS_CODE",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("FROM_YEAR_LEVEL24",UrlFROM_YEAR_LEVEL, "","FROM_YEAR_LEVEL",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("TO_YEAR_LEVEL25",UrlTO_YEAR_LEVEL, "","TO_YEAR_LEVEL",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record CONTRIBUTION BeforeBuildSelect

'Record CONTRIBUTION BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record CONTRIBUTION BeforeExecuteSelect

'Record CONTRIBUTION AfterExecuteSelect @2-5CDDA13E
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.SCHOOL_TYPE_CODE.SetValue(dr(i)("SCHOOL_TYPE_CODE"),"")
            item.CAMPUS_CODE.SetValue(dr(i)("CAMPUS_CODE"),"")
            item.FROM_YEAR_LEVEL.SetValue(dr(i)("FROM_YEAR_LEVEL"),"")
            item.TO_YEAR_LEVEL.SetValue(dr(i)("TO_YEAR_LEVEL"),"")
            item.PER_SUBJECT_FLAG.SetValue(dr(i)("PER_SUBJECT_FLAG"),Select_.BoolFormat)
            item.DEFAULT_CONTRIBUTION.SetValue(dr(i)("DEFAULT_CONTRIBUTION"),"")
            item.DISCOUNT_AMOUNT.SetValue(dr(i)("DISCOUNT_AMOUNT"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.CATEGORY.SetValue(dr(i)("CATEGORY_CODE"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record CONTRIBUTION AfterExecuteSelect

'ListBox SCHOOL_TYPE_CODE Initialize Data Source @7-D60251C7
        SCHOOL_TYPE_CODEDataCommand.Dao._optimized = False
        Dim SCHOOL_TYPE_CODEtableIndex As Integer = 0
        SCHOOL_TYPE_CODEDataCommand.OrderBy = ""
        SCHOOL_TYPE_CODEDataCommand.Parameters.Clear()
'End ListBox SCHOOL_TYPE_CODE Initialize Data Source

'ListBox SCHOOL_TYPE_CODE BeforeExecuteSelect @7-7A43048D
        Try
            ListBoxSource=SCHOOL_TYPE_CODEDataCommand.Execute().Tables(SCHOOL_TYPE_CODEtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox SCHOOL_TYPE_CODE BeforeExecuteSelect

'ListBox SCHOOL_TYPE_CODE AfterExecuteSelect @7-2939ECE8
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("SCHOOL_TYPE_CODE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("SCHOOL_TYPE_CODE")
            item.SCHOOL_TYPE_CODEItems.Add(Key, Val)
        Next
'End ListBox SCHOOL_TYPE_CODE AfterExecuteSelect

'ListBox CAMPUS_CODE Initialize Data Source @8-2596BCCA
        CAMPUS_CODEDataCommand.Dao._optimized = False
        Dim CAMPUS_CODEtableIndex As Integer = 0
        CAMPUS_CODEDataCommand.OrderBy = ""
        CAMPUS_CODEDataCommand.Parameters.Clear()
'End ListBox CAMPUS_CODE Initialize Data Source

'ListBox CAMPUS_CODE BeforeExecuteSelect @8-CEE820EC
        Try
            ListBoxSource=CAMPUS_CODEDataCommand.Execute().Tables(CAMPUS_CODEtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox CAMPUS_CODE BeforeExecuteSelect

'ListBox CAMPUS_CODE AfterExecuteSelect @8-F693D04B
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("CAMPUS_CODE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("CAMPUS_CODE")
            item.CAMPUS_CODEItems.Add(Key, Val)
        Next
'End ListBox CAMPUS_CODE AfterExecuteSelect

'Record CONTRIBUTION AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record CONTRIBUTION AfterExecuteSelect tail

'Record CONTRIBUTION Data Provider Class @2-A61BA892
End Class

'End Record CONTRIBUTION Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

