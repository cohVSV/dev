'Using Statements @1-ECBA6F53
Imports System
Imports System.Text
Imports System.Resources
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

Namespace DECV_PROD2007.WITHDRAWAL_REAS_maint 'Namespace @1-77B27089

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

'Record WITHDRAWAL_REASON Item Class @2-43793DC2
Public Class WITHDRAWAL_REASONItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public WITHDRAWAL_REASON As TextField
    Public STATUS As BooleanField
    Public STATUSCheckedValue As BooleanField
    Public STATUSUncheckedValue As BooleanField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    WITHDRAWAL_REASON = New TextField("", Nothing)
    STATUS = New BooleanField(Settings.BoolFormat, False)
    STATUSCheckedValue = New BooleanField(Settings.BoolFormat, True)
    STATUSUncheckedValue = New BooleanField(Settings.BoolFormat, False)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As WITHDRAWAL_REASONItem
        Dim item As WITHDRAWAL_REASONItem = New WITHDRAWAL_REASONItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("WITHDRAWAL_REASON")) Then
        item.WITHDRAWAL_REASON.SetValue(DBUtility.GetInitialValue("WITHDRAWAL_REASON"))
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
                Case "WITHDRAWAL_REASON"
                    Return WITHDRAWAL_REASON
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
                Case "WITHDRAWAL_REASON"
                    WITHDRAWAL_REASON = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As WITHDRAWAL_REASONDataProvider)
'End Record WITHDRAWAL_REASON Item Class

'WITHDRAWAL_REASON validate @7-38D319E5
        If IsNothing(WITHDRAWAL_REASON.Value) OrElse WITHDRAWAL_REASON.Value.ToString() ="" Then
            errors.Add("WITHDRAWAL_REASON",String.Format(Resources.strings.CCS_RequiredField,"WITHDRAWAL REASON"))
        End If
'End WITHDRAWAL_REASON validate

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

'Record WITHDRAWAL_REASON Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record WITHDRAWAL_REASON Item Class tail

'Record WITHDRAWAL_REASON Data Provider Class @2-0C3D3305
Public Class WITHDRAWAL_REASONDataProvider
Inherits RecordDataProviderBase
'End Record WITHDRAWAL_REASON Data Provider Class

'Record WITHDRAWAL_REASON Data Provider Class Variables @2-200770E6
    Public UrlWITHDRAWAL_REASON_ID As FloatParameter
    Protected item As WITHDRAWAL_REASONItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record WITHDRAWAL_REASON Data Provider Class Variables

'Record WITHDRAWAL_REASON Data Provider Class Constructor @2-986F6A79

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM WITHDRAWAL_REASON {SQL_Where} {SQL_OrderBy}", New String(){"WITHDRAWAL_REASON_ID6"},Settings.connDECVPRODSQL2005DataAccessObject )
        Delete=new TableCommand("DELETE FROM WITHDRAWAL_REASON", New String(){"WITHDRAWAL_REASON_ID6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
        Select_.OrderBy=""
    End Sub
'End Record WITHDRAWAL_REASON Data Provider Class Constructor

'Record WITHDRAWAL_REASON Data Provider Class LoadParams Method @2-FA3F3403

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlWITHDRAWAL_REASON_ID))
    End Function
'End Record WITHDRAWAL_REASON Data Provider Class LoadParams Method

'Record WITHDRAWAL_REASON Data Provider Class CheckUnique Method @2-54A2E752

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As WITHDRAWAL_REASONItem) As Boolean
        Return True
    End Function
'End Record WITHDRAWAL_REASON Data Provider Class CheckUnique Method

'Record WITHDRAWAL_REASON Data Provider Class PrepareInsert Method @2-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record WITHDRAWAL_REASON Data Provider Class PrepareInsert Method

'Record WITHDRAWAL_REASON Data Provider Class PrepareInsert Method tail @2-E31F8E2A
    End Sub
'End Record WITHDRAWAL_REASON Data Provider Class PrepareInsert Method tail

'Record WITHDRAWAL_REASON Data Provider Class Insert Method @2-D691AF5D

    Public Function InsertItem(ByVal item As WITHDRAWAL_REASONItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO WITHDRAWAL_REASON({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record WITHDRAWAL_REASON Data Provider Class Insert Method

'Record WITHDRAWAL_REASON Build insert @2-AB377DB2
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.WITHDRAWAL_REASON.IsEmpty Then
        allEmptyFlag = item.WITHDRAWAL_REASON.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "WITHDRAWAL_REASON,"
        valuesList = valuesList & Insert.Dao.ToSql(item.WITHDRAWAL_REASON.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record WITHDRAWAL_REASON Build insert

'Record WITHDRAWAL_REASON AfterExecuteInsert @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record WITHDRAWAL_REASON AfterExecuteInsert

'Record WITHDRAWAL_REASON Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record WITHDRAWAL_REASON Data Provider Class PrepareUpdate Method

'Record WITHDRAWAL_REASON Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record WITHDRAWAL_REASON Data Provider Class PrepareUpdate Method tail

'Record WITHDRAWAL_REASON Data Provider Class Update Method @2-226C2F7F

    Public Function UpdateItem(ByVal item As WITHDRAWAL_REASONItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE WITHDRAWAL_REASON SET {Values}", New String(){"WITHDRAWAL_REASON_ID6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record WITHDRAWAL_REASON Data Provider Class Update Method

'Record WITHDRAWAL_REASON BeforeBuildUpdate @2-9C4EBE1F
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("WITHDRAWAL_REASON_ID6",UrlWITHDRAWAL_REASON_ID, "","WITHDRAWAL_REASON_ID",Condition.Equal,False)
        If Not item.WITHDRAWAL_REASON.IsEmpty Then
        allEmptyFlag = item.WITHDRAWAL_REASON.IsEmpty And allEmptyFlag
        valuesList = valuesList & "WITHDRAWAL_REASON=" + Update.Dao.ToSql(item.WITHDRAWAL_REASON.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record WITHDRAWAL_REASON BeforeBuildUpdate

'Record WITHDRAWAL_REASON AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record WITHDRAWAL_REASON AfterExecuteUpdate

'Record WITHDRAWAL_REASON Data Provider Class PrepareDelete Method @2-F7361E57

    Protected Overrides Sub PrepareDelete()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record WITHDRAWAL_REASON Data Provider Class PrepareDelete Method

'Record WITHDRAWAL_REASON Data Provider Class PrepareDelete Method tail @2-E31F8E2A
    End Sub
'End Record WITHDRAWAL_REASON Data Provider Class PrepareDelete Method tail

'Record WITHDRAWAL_REASON Data Provider Class Delete Method @2-AF56531D
    Public Function DeleteItem(ByVal item As WITHDRAWAL_REASONItem) As Integer
        Me.item = item
'End Record WITHDRAWAL_REASON Data Provider Class Delete Method

'Record WITHDRAWAL_REASON BeforeBuildDelete @2-CD883862
        Delete.Parameters.Clear()
        CType(Delete,TableCommand).AddParameter("WITHDRAWAL_REASON_ID6",UrlWITHDRAWAL_REASON_ID, "","WITHDRAWAL_REASON_ID",Condition.Equal,False)
        Delete.SqlQuery.Replace("{WITHDRAWAL_REASON}",Delete.Dao.ToSql(item.WITHDRAWAL_REASON.GetFormattedValue(""),FieldType._Text))
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
'End Record WITHDRAWAL_REASON BeforeBuildDelete

'Record WITHDRAWAL_REASON BeforeBuildDelete @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record WITHDRAWAL_REASON BeforeBuildDelete

'Record WITHDRAWAL_REASON Data Provider Class GetResultSet Method @2-54419112

    Public Sub FillItem(ByVal item As WITHDRAWAL_REASONItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record WITHDRAWAL_REASON Data Provider Class GetResultSet Method

'Record WITHDRAWAL_REASON BeforeBuildSelect @2-44862B5F
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("WITHDRAWAL_REASON_ID6",UrlWITHDRAWAL_REASON_ID, "","WITHDRAWAL_REASON_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record WITHDRAWAL_REASON BeforeBuildSelect

'Record WITHDRAWAL_REASON BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record WITHDRAWAL_REASON BeforeExecuteSelect

'Record WITHDRAWAL_REASON AfterExecuteSelect @2-D724C2A9
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.WITHDRAWAL_REASON.SetValue(dr(i)("WITHDRAWAL_REASON"),"")
            item.STATUS.SetValue(dr(i)("STATUS"),Select_.BoolFormat)
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
'End Record WITHDRAWAL_REASON AfterExecuteSelect

'Record WITHDRAWAL_REASON AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record WITHDRAWAL_REASON AfterExecuteSelect tail

'Record WITHDRAWAL_REASON Data Provider Class @2-A61BA892
End Class

'End Record WITHDRAWAL_REASON Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

