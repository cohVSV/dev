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

Namespace DECV_PROD2007.LANGUAGE_maint 'Namespace @1-2B78B408

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

'Record LANGUAGE Item Class @2-384FD36F
Public Class LANGUAGEItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public LANG_DESCRIPTION As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public label_Last_altered_by As TextField
    Public label_last_altered_date As DateField
    Public LANG_CODE As IntegerField
    Public Sub New()
    LANG_DESCRIPTION = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", DBUtility.UserID.tostring())
    LAST_ALTERED_DATE = New DateField("G", DateTime.Now)
    label_Last_altered_by = New TextField("", Nothing)
    label_last_altered_date = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    LANG_CODE = New IntegerField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As LANGUAGEItem
        Dim item As LANGUAGEItem = New LANGUAGEItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LANG_DESCRIPTION")) Then
        item.LANG_DESCRIPTION.SetValue(DBUtility.GetInitialValue("LANG_DESCRIPTION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("label_Last_altered_by")) Then
        item.label_Last_altered_by.SetValue(DBUtility.GetInitialValue("label_Last_altered_by"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("label_last_altered_date")) Then
        item.label_last_altered_date.SetValue(DBUtility.GetInitialValue("label_last_altered_date"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LANG_CODE")) Then
        item.LANG_CODE.SetValue(DBUtility.GetInitialValue("LANG_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "LANG_DESCRIPTION"
                    Return LANG_DESCRIPTION
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "label_Last_altered_by"
                    Return label_Last_altered_by
                Case "label_last_altered_date"
                    Return label_last_altered_date
                Case "LANG_CODE"
                    Return LANG_CODE
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "LANG_DESCRIPTION"
                    LANG_DESCRIPTION = CType(value, TextField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "label_Last_altered_by"
                    label_Last_altered_by = CType(value, TextField)
                Case "label_last_altered_date"
                    label_last_altered_date = CType(value, DateField)
                Case "LANG_CODE"
                    LANG_CODE = CType(value, IntegerField)
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

    Public Sub Validate(ByVal provider As LANGUAGEDataProvider)
'End Record LANGUAGE Item Class

'LANG_DESCRIPTION validate @7-8EC0300F
        If IsNothing(LANG_DESCRIPTION.Value) OrElse LANG_DESCRIPTION.Value.ToString() ="" Then
            errors.Add("LANG_DESCRIPTION",String.Format(Resources.strings.CCS_RequiredField,"LANG DESCRIPTION"))
        End If
'End LANG_DESCRIPTION validate

'LAST_ALTERED_BY validate @8-256A6854
        If IsNothing(LAST_ALTERED_BY.Value) OrElse LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End LAST_ALTERED_BY validate

'LAST_ALTERED_DATE validate @9-C5989D76
        If IsNothing(LAST_ALTERED_DATE.Value) OrElse LAST_ALTERED_DATE.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED DATE"))
        End If
'End LAST_ALTERED_DATE validate

'LANG_CODE validate @16-AC101C3A
        If IsNothing(LANG_CODE.Value) OrElse LANG_CODE.Value.ToString() ="" Then
            errors.Add("LANG_CODE",String.Format(Resources.strings.CCS_RequiredField,"Language Code"))
        End If
        If (Not IsNothing(LANG_CODE)) And (Not provider.CheckUnique("LANG_CODE",Me)) Then
                errors.Add("LANG_CODE", String.Format(Resources.strings.CCS_UniqueValue,"Language Code"))
        End If
'End LANG_CODE validate

'Record LANGUAGE Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record LANGUAGE Item Class tail

'Record LANGUAGE Data Provider Class @2-8F4AF85B
Public Class LANGUAGEDataProvider
Inherits RecordDataProviderBase
'End Record LANGUAGE Data Provider Class

'Record LANGUAGE Data Provider Class Variables @2-80F4A72E
    Public UrlLANG_CODE As IntegerParameter
    Protected item As LANGUAGEItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record LANGUAGE Data Provider Class Variables

'Record LANGUAGE Data Provider Class Constructor @2-C0AC90D3

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM [LANGUAGE] {SQL_Where} {SQL_OrderBy}", New String(){"LANG_CODE6"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record LANGUAGE Data Provider Class Constructor

'Record LANGUAGE Data Provider Class LoadParams Method @2-5E9DD4DC

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlLANG_CODE))
    End Function
'End Record LANGUAGE Data Provider Class LoadParams Method

'Record LANGUAGE Data Provider Class CheckUnique Method @2-4394CA2C

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As LANGUAGEItem) As Boolean
        Dim Check As TableCommand = New TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM [LANGUAGE]",New String(){"LANG_CODE6"},Settings.connDECVPRODSQL2005DataAccessObject)
        Dim CheckWhere As String = ""
        Select Case ControlName
        Case "LANG_CODE"
            CheckWhere = "LANG_CODE=" & Check.Dao.ToSql(item.LANG_CODE.GetFormattedValue(""),FieldType._Integer)
        End Select
        Check.Where = CheckWhere
        Check.Operation = "AND NOT"
        Check.Parameters.Clear()
        CType(Check,TableCommand).AddParameter("LANG_CODE6",UrlLANG_CODE, "","LANG_CODE",Condition.Equal,False)
        If Convert.ToInt32(Check.ExecuteScalar()) > 0 Then
            Return False
        End If
        Return True
    End Function
'End Record LANGUAGE Data Provider Class CheckUnique Method

'Record LANGUAGE Data Provider Class PrepareInsert Method @2-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record LANGUAGE Data Provider Class PrepareInsert Method

'Record LANGUAGE Data Provider Class PrepareInsert Method tail @2-E31F8E2A
    End Sub
'End Record LANGUAGE Data Provider Class PrepareInsert Method tail

'Record LANGUAGE Data Provider Class Insert Method @2-C1CC7C21

    Public Function InsertItem(ByVal item As LANGUAGEItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO [LANGUAGE]({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record LANGUAGE Data Provider Class Insert Method

'Record LANGUAGE Build insert @2-FE030325
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.LANG_DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.LANG_DESCRIPTION.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LANG_DESCRIPTION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LANG_DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
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
        If Not item.LANG_CODE.IsEmpty Then
        allEmptyFlag = item.LANG_CODE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LANG_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LANG_CODE.GetFormattedValue(""),FieldType._Integer) & ","
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
'End Record LANGUAGE Build insert

'Record LANGUAGE AfterExecuteInsert @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record LANGUAGE AfterExecuteInsert

'Record LANGUAGE Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record LANGUAGE Data Provider Class PrepareUpdate Method

'Record LANGUAGE Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record LANGUAGE Data Provider Class PrepareUpdate Method tail

'Record LANGUAGE Data Provider Class Update Method @2-228E49C8

    Public Function UpdateItem(ByVal item As LANGUAGEItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE [LANGUAGE] SET {Values}", New String(){"LANG_CODE6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record LANGUAGE Data Provider Class Update Method

'Record LANGUAGE BeforeBuildUpdate @2-96895BC8
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("LANG_CODE6",UrlLANG_CODE, "","LANG_CODE",Condition.Equal,False)
        If Not item.LANG_DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.LANG_DESCRIPTION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LANG_DESCRIPTION=" + Update.Dao.ToSql(item.LANG_DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.LANG_CODE.IsEmpty Then
        allEmptyFlag = item.LANG_CODE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LANG_CODE=" + Update.Dao.ToSql(item.LANG_CODE.GetFormattedValue(""),FieldType._Integer) & ","
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
'End Record LANGUAGE BeforeBuildUpdate

'Record LANGUAGE AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record LANGUAGE AfterExecuteUpdate

'Record LANGUAGE Data Provider Class GetResultSet Method @2-9A9E547D

    Public Sub FillItem(ByVal item As LANGUAGEItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record LANGUAGE Data Provider Class GetResultSet Method

'Record LANGUAGE BeforeBuildSelect @2-3C5E97AE
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("LANG_CODE6",UrlLANG_CODE, "","LANG_CODE",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record LANGUAGE BeforeBuildSelect

'Record LANGUAGE BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record LANGUAGE BeforeExecuteSelect

'Record LANGUAGE AfterExecuteSelect @2-7F69E374
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.LANG_DESCRIPTION.SetValue(dr(i)("LANG_DESCRIPTION"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.label_Last_altered_by.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.label_last_altered_date.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.LANG_CODE.SetValue(dr(i)("LANG_CODE"),"")
        Else
            IsInsertMode = True
        End If
'End Record LANGUAGE AfterExecuteSelect

'Record LANGUAGE AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record LANGUAGE AfterExecuteSelect tail

'Record LANGUAGE Data Provider Class @2-A61BA892
End Class

'End Record LANGUAGE Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

