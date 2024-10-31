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

Namespace DECV_PROD2007.GOVERNMENT_ALLO_maint 'Namespace @1-7A068540

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

'Record GOVERNMENT_ALLOWANCE Item Class @2-FBB173A2
Public Class GOVERNMENT_ALLOWANCEItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ALLOWANCE_TITLE As TextField
    Public ALLOWANCE_DESCRIPTION As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    ALLOWANCE_TITLE = New TextField("", Nothing)
    ALLOWANCE_DESCRIPTION = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As GOVERNMENT_ALLOWANCEItem
        Dim item As GOVERNMENT_ALLOWANCEItem = New GOVERNMENT_ALLOWANCEItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ALLOWANCE_TITLE")) Then
        item.ALLOWANCE_TITLE.SetValue(DBUtility.GetInitialValue("ALLOWANCE_TITLE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ALLOWANCE_DESCRIPTION")) Then
        item.ALLOWANCE_DESCRIPTION.SetValue(DBUtility.GetInitialValue("ALLOWANCE_DESCRIPTION"))
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
                Case "ALLOWANCE_TITLE"
                    Return ALLOWANCE_TITLE
                Case "ALLOWANCE_DESCRIPTION"
                    Return ALLOWANCE_DESCRIPTION
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
                Case "ALLOWANCE_TITLE"
                    ALLOWANCE_TITLE = CType(value, TextField)
                Case "ALLOWANCE_DESCRIPTION"
                    ALLOWANCE_DESCRIPTION = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As GOVERNMENT_ALLOWANCEDataProvider)
'End Record GOVERNMENT_ALLOWANCE Item Class

'ALLOWANCE_TITLE validate @7-21137655
        If IsNothing(ALLOWANCE_TITLE.Value) OrElse ALLOWANCE_TITLE.Value.ToString() ="" Then
            errors.Add("ALLOWANCE_TITLE",String.Format(Resources.strings.CCS_RequiredField,"ALLOWANCE TITLE"))
        End If
'End ALLOWANCE_TITLE validate

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

'Record GOVERNMENT_ALLOWANCE Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record GOVERNMENT_ALLOWANCE Item Class tail

'Record GOVERNMENT_ALLOWANCE Data Provider Class @2-C079A045
Public Class GOVERNMENT_ALLOWANCEDataProvider
Inherits RecordDataProviderBase
'End Record GOVERNMENT_ALLOWANCE Data Provider Class

'Record GOVERNMENT_ALLOWANCE Data Provider Class Variables @2-C169B861
    Public UrlALLOWANCE_CODE As IntegerParameter
    Protected item As GOVERNMENT_ALLOWANCEItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record GOVERNMENT_ALLOWANCE Data Provider Class Variables

'Record GOVERNMENT_ALLOWANCE Data Provider Class Constructor @2-1D46FA64

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM GOVERNMENT_ALLOWANCE {SQL_Where} {SQL_OrderBy}", New String(){"ALLOWANCE_CODE6"},Settings.connDECVPRODSQL2005DataAccessObject )
        Delete=new TableCommand("DELETE FROM GOVERNMENT_ALLOWANCE", New String(){"ALLOWANCE_CODE6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
        Select_.OrderBy=""
    End Sub
'End Record GOVERNMENT_ALLOWANCE Data Provider Class Constructor

'Record GOVERNMENT_ALLOWANCE Data Provider Class LoadParams Method @2-42F14551

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlALLOWANCE_CODE))
    End Function
'End Record GOVERNMENT_ALLOWANCE Data Provider Class LoadParams Method

'Record GOVERNMENT_ALLOWANCE Data Provider Class CheckUnique Method @2-0EED0E3A

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As GOVERNMENT_ALLOWANCEItem) As Boolean
        Return True
    End Function
'End Record GOVERNMENT_ALLOWANCE Data Provider Class CheckUnique Method

'Record GOVERNMENT_ALLOWANCE Data Provider Class PrepareInsert Method @2-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record GOVERNMENT_ALLOWANCE Data Provider Class PrepareInsert Method

'Record GOVERNMENT_ALLOWANCE Data Provider Class PrepareInsert Method tail @2-E31F8E2A
    End Sub
'End Record GOVERNMENT_ALLOWANCE Data Provider Class PrepareInsert Method tail

'Record GOVERNMENT_ALLOWANCE Data Provider Class Insert Method @2-32FCC7AB

    Public Function InsertItem(ByVal item As GOVERNMENT_ALLOWANCEItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO GOVERNMENT_ALLOWANCE({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record GOVERNMENT_ALLOWANCE Data Provider Class Insert Method

'Record GOVERNMENT_ALLOWANCE Build insert @2-C5C8BF11
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.ALLOWANCE_TITLE.IsEmpty Then
        allEmptyFlag = item.ALLOWANCE_TITLE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ALLOWANCE_TITLE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ALLOWANCE_TITLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ALLOWANCE_DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.ALLOWANCE_DESCRIPTION.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ALLOWANCE_DESCRIPTION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ALLOWANCE_DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record GOVERNMENT_ALLOWANCE Build insert

'Record GOVERNMENT_ALLOWANCE AfterExecuteInsert @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record GOVERNMENT_ALLOWANCE AfterExecuteInsert

'Record GOVERNMENT_ALLOWANCE Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record GOVERNMENT_ALLOWANCE Data Provider Class PrepareUpdate Method

'Record GOVERNMENT_ALLOWANCE Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record GOVERNMENT_ALLOWANCE Data Provider Class PrepareUpdate Method tail

'Record GOVERNMENT_ALLOWANCE Data Provider Class Update Method @2-45B9A6DD

    Public Function UpdateItem(ByVal item As GOVERNMENT_ALLOWANCEItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE GOVERNMENT_ALLOWANCE SET {Values}", New String(){"ALLOWANCE_CODE6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record GOVERNMENT_ALLOWANCE Data Provider Class Update Method

'Record GOVERNMENT_ALLOWANCE BeforeBuildUpdate @2-FB72140F
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("ALLOWANCE_CODE6",UrlALLOWANCE_CODE, "","ALLOWANCE_CODE",Condition.Equal,False)
        If Not item.ALLOWANCE_TITLE.IsEmpty Then
        allEmptyFlag = item.ALLOWANCE_TITLE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ALLOWANCE_TITLE=" + Update.Dao.ToSql(item.ALLOWANCE_TITLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ALLOWANCE_DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.ALLOWANCE_DESCRIPTION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ALLOWANCE_DESCRIPTION=" + Update.Dao.ToSql(item.ALLOWANCE_DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record GOVERNMENT_ALLOWANCE BeforeBuildUpdate

'Record GOVERNMENT_ALLOWANCE AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record GOVERNMENT_ALLOWANCE AfterExecuteUpdate

'Record GOVERNMENT_ALLOWANCE Data Provider Class PrepareDelete Method @2-F7361E57

    Protected Overrides Sub PrepareDelete()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record GOVERNMENT_ALLOWANCE Data Provider Class PrepareDelete Method

'Record GOVERNMENT_ALLOWANCE Data Provider Class PrepareDelete Method tail @2-E31F8E2A
    End Sub
'End Record GOVERNMENT_ALLOWANCE Data Provider Class PrepareDelete Method tail

'Record GOVERNMENT_ALLOWANCE Data Provider Class Delete Method @2-77DBDCEE
    Public Function DeleteItem(ByVal item As GOVERNMENT_ALLOWANCEItem) As Integer
        Me.item = item
'End Record GOVERNMENT_ALLOWANCE Data Provider Class Delete Method

'Record GOVERNMENT_ALLOWANCE BeforeBuildDelete @2-8D6F5F16
        Delete.Parameters.Clear()
        CType(Delete,TableCommand).AddParameter("ALLOWANCE_CODE6",UrlALLOWANCE_CODE, "","ALLOWANCE_CODE",Condition.Equal,False)
        Delete.SqlQuery.Replace("{ALLOWANCE_TITLE}",Delete.Dao.ToSql(item.ALLOWANCE_TITLE.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{ALLOWANCE_DESCRIPTION}",Delete.Dao.ToSql(item.ALLOWANCE_DESCRIPTION.GetFormattedValue(""),FieldType._Text))
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
'End Record GOVERNMENT_ALLOWANCE BeforeBuildDelete

'Record GOVERNMENT_ALLOWANCE BeforeBuildDelete @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record GOVERNMENT_ALLOWANCE BeforeBuildDelete

'Record GOVERNMENT_ALLOWANCE Data Provider Class GetResultSet Method @2-FC450545

    Public Sub FillItem(ByVal item As GOVERNMENT_ALLOWANCEItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record GOVERNMENT_ALLOWANCE Data Provider Class GetResultSet Method

'Record GOVERNMENT_ALLOWANCE BeforeBuildSelect @2-DFAB664B
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("ALLOWANCE_CODE6",UrlALLOWANCE_CODE, "","ALLOWANCE_CODE",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record GOVERNMENT_ALLOWANCE BeforeBuildSelect

'Record GOVERNMENT_ALLOWANCE BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record GOVERNMENT_ALLOWANCE BeforeExecuteSelect

'Record GOVERNMENT_ALLOWANCE AfterExecuteSelect @2-8D15638F
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.ALLOWANCE_TITLE.SetValue(dr(i)("ALLOWANCE_TITLE"),"")
            item.ALLOWANCE_DESCRIPTION.SetValue(dr(i)("ALLOWANCE_DESCRIPTION"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
'End Record GOVERNMENT_ALLOWANCE AfterExecuteSelect

'Record GOVERNMENT_ALLOWANCE AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record GOVERNMENT_ALLOWANCE AfterExecuteSelect tail

'Record GOVERNMENT_ALLOWANCE Data Provider Class @2-A61BA892
End Class

'End Record GOVERNMENT_ALLOWANCE Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

