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

Namespace DECV_PROD2007.PROGRESS_CODE_maint 'Namespace @1-3DC361EA

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

'Record PROGRESS_CODE Item Class @2-35C67D4D
Public Class PROGRESS_CODEItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public PROGRESS_CODE_TITLE As TextField
    Public STATUS As BooleanField
    Public STATUSCheckedValue As BooleanField
    Public STATUSUncheckedValue As BooleanField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    PROGRESS_CODE_TITLE = New TextField("", Nothing)
    STATUS = New BooleanField(Settings.BoolFormat, False)
    STATUSCheckedValue = New BooleanField(Settings.BoolFormat, True)
    STATUSUncheckedValue = New BooleanField(Settings.BoolFormat, False)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As PROGRESS_CODEItem
        Dim item As PROGRESS_CODEItem = New PROGRESS_CODEItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PROGRESS_CODE_TITLE")) Then
        item.PROGRESS_CODE_TITLE.SetValue(DBUtility.GetInitialValue("PROGRESS_CODE_TITLE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STATUS")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("STATUS")) Then
            item.STATUS.Value = item.STATUSCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "PROGRESS_CODE_TITLE"
                    Return PROGRESS_CODE_TITLE
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
                Case "PROGRESS_CODE_TITLE"
                    PROGRESS_CODE_TITLE = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As PROGRESS_CODEDataProvider)
'End Record PROGRESS_CODE Item Class

'PROGRESS_CODE_TITLE validate @7-9992CE44
        If IsNothing(PROGRESS_CODE_TITLE.Value) OrElse PROGRESS_CODE_TITLE.Value.ToString() ="" Then
            errors.Add("PROGRESS_CODE_TITLE",String.Format(Resources.strings.CCS_RequiredField,"TITLE"))
        End If
'End PROGRESS_CODE_TITLE validate

'STATUS validate @8-73C7378E
        If IsNothing(STATUS.Value) OrElse STATUS.Value.ToString() ="" Then
            errors.Add("STATUS",String.Format(Resources.strings.CCS_RequiredField,"STATUS"))
        End If
'End STATUS validate

'LAST_ALTERED_BY validate @9-256A6854
        If IsNothing(LAST_ALTERED_BY.Value) OrElse LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End LAST_ALTERED_BY validate

'LAST_ALTERED_DATE validate @10-C5989D76
        If IsNothing(LAST_ALTERED_DATE.Value) OrElse LAST_ALTERED_DATE.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED DATE"))
        End If
'End LAST_ALTERED_DATE validate

'Record PROGRESS_CODE Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record PROGRESS_CODE Item Class tail

'Record PROGRESS_CODE Data Provider Class @2-1F84E1D5
Public Class PROGRESS_CODEDataProvider
Inherits RecordDataProviderBase
'End Record PROGRESS_CODE Data Provider Class

'Record PROGRESS_CODE Data Provider Class Variables @2-41C8B67A
    Public UrlPROGRESS_CODE As TextParameter
    Protected item As PROGRESS_CODEItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record PROGRESS_CODE Data Provider Class Variables

'Record PROGRESS_CODE Data Provider Class Constructor @2-76039F13

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM PROGRESS_CODE {SQL_Where} {SQL_OrderBy}", New String(){"PROGRESS_CODE6"},Settings.connDECVPRODSQL2005DataAccessObject )
        Delete=new TableCommand("DELETE FROM PROGRESS_CODE", New String(){"PROGRESS_CODE6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
        Select_.OrderBy=""
    End Sub
'End Record PROGRESS_CODE Data Provider Class Constructor

'Record PROGRESS_CODE Data Provider Class LoadParams Method @2-A7AB2A06

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlPROGRESS_CODE))
    End Function
'End Record PROGRESS_CODE Data Provider Class LoadParams Method

'Record PROGRESS_CODE Data Provider Class CheckUnique Method @2-F7850A76

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As PROGRESS_CODEItem) As Boolean
        Return True
    End Function
'End Record PROGRESS_CODE Data Provider Class CheckUnique Method

'Record PROGRESS_CODE Data Provider Class PrepareInsert Method @2-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record PROGRESS_CODE Data Provider Class PrepareInsert Method

'Record PROGRESS_CODE Data Provider Class PrepareInsert Method tail @2-E31F8E2A
    End Sub
'End Record PROGRESS_CODE Data Provider Class PrepareInsert Method tail

'Record PROGRESS_CODE Data Provider Class Insert Method @2-09889763

    Public Function InsertItem(ByVal item As PROGRESS_CODEItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO PROGRESS_CODE({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record PROGRESS_CODE Data Provider Class Insert Method

'Record PROGRESS_CODE Build insert @2-EB11F2C1
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.PROGRESS_CODE_TITLE.IsEmpty Then
        allEmptyFlag = item.PROGRESS_CODE_TITLE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PROGRESS_CODE_TITLE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PROGRESS_CODE_TITLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STATUS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STATUS.GetFormattedValue(Insert.BoolFormat),FieldType._Boolean) & ","
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
		Insert.SqlQuery.Replace("{Fields}", fieldsList.TrimEnd(","C))
		Insert.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
             If Not allEmptyFlag Then result = ExecuteInsert()
        Catch ee As Exception
            E = ee
        Finally
'End Record PROGRESS_CODE Build insert

'Record PROGRESS_CODE AfterExecuteInsert @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record PROGRESS_CODE AfterExecuteInsert

'Record PROGRESS_CODE Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record PROGRESS_CODE Data Provider Class PrepareUpdate Method

'Record PROGRESS_CODE Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record PROGRESS_CODE Data Provider Class PrepareUpdate Method tail

'Record PROGRESS_CODE Data Provider Class Update Method @2-998E8C94

    Public Function UpdateItem(ByVal item As PROGRESS_CODEItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE PROGRESS_CODE SET {Values}", New String(){"PROGRESS_CODE6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record PROGRESS_CODE Data Provider Class Update Method

'Record PROGRESS_CODE BeforeBuildUpdate @2-78ACDBE9
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("PROGRESS_CODE6",UrlPROGRESS_CODE, "","PROGRESS_CODE",Condition.Equal,False)
        If Not item.PROGRESS_CODE_TITLE.IsEmpty Then
        allEmptyFlag = item.PROGRESS_CODE_TITLE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PROGRESS_CODE_TITLE=" + Update.Dao.ToSql(item.PROGRESS_CODE_TITLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STATUS=" + Update.Dao.ToSql(item.STATUS.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
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
'End Record PROGRESS_CODE BeforeBuildUpdate

'Record PROGRESS_CODE AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record PROGRESS_CODE AfterExecuteUpdate

'Record PROGRESS_CODE Data Provider Class PrepareDelete Method @2-F7361E57

    Protected Overrides Sub PrepareDelete()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record PROGRESS_CODE Data Provider Class PrepareDelete Method

'Record PROGRESS_CODE Data Provider Class PrepareDelete Method tail @2-E31F8E2A
    End Sub
'End Record PROGRESS_CODE Data Provider Class PrepareDelete Method tail

'Record PROGRESS_CODE Data Provider Class Delete Method @2-C0962E2B
    Public Function DeleteItem(ByVal item As PROGRESS_CODEItem) As Integer
        Me.item = item
'End Record PROGRESS_CODE Data Provider Class Delete Method

'Record PROGRESS_CODE BeforeBuildDelete @2-0E5B63EA
        Delete.Parameters.Clear()
        CType(Delete,TableCommand).AddParameter("PROGRESS_CODE6",UrlPROGRESS_CODE, "","PROGRESS_CODE",Condition.Equal,False)
        Delete.SqlQuery.Replace("{PROGRESS_CODE_TITLE}",Delete.Dao.ToSql(item.PROGRESS_CODE_TITLE.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{STATUS}",Delete.Dao.ToSql(item.STATUS.GetFormattedValue(Delete.BoolFormat),FieldType._Boolean))
        Delete.SqlQuery.Replace("{LAST_ALTERED_BY}",Delete.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{LAST_ALTERED_DATE}",Delete.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Delete.DateFormat),FieldType._Date))
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
'End Record PROGRESS_CODE BeforeBuildDelete

'Record PROGRESS_CODE BeforeBuildDelete @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record PROGRESS_CODE BeforeBuildDelete

'Record PROGRESS_CODE Data Provider Class GetResultSet Method @2-8AA75CEE

    Public Sub FillItem(ByVal item As PROGRESS_CODEItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record PROGRESS_CODE Data Provider Class GetResultSet Method

'Record PROGRESS_CODE BeforeBuildSelect @2-861C2DED
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("PROGRESS_CODE6",UrlPROGRESS_CODE, "","PROGRESS_CODE",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record PROGRESS_CODE BeforeBuildSelect

'Record PROGRESS_CODE BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record PROGRESS_CODE BeforeExecuteSelect

'Record PROGRESS_CODE AfterExecuteSelect @2-BE848ED3
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.PROGRESS_CODE_TITLE.SetValue(dr(i)("PROGRESS_CODE_TITLE"),"")
            item.STATUS.SetValue(dr(i)("STATUS"),Select_.BoolFormat)
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
'End Record PROGRESS_CODE AfterExecuteSelect

'Record PROGRESS_CODE AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record PROGRESS_CODE AfterExecuteSelect tail

'Record PROGRESS_CODE Data Provider Class @2-A61BA892
End Class

'End Record PROGRESS_CODE Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

