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

Namespace DECV_PROD2007.KEY_LEARNING_AR_maint 'Namespace @1-D71543C1

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

'Record KEY_LEARNING_AREA Item Class @2-54FA6E30
Public Class KEY_LEARNING_AREAItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public KEY_LEARNING_AREA As TextField
    Public STATUS As BooleanField
    Public STATUSCheckedValue As BooleanField
    Public STATUSUncheckedValue As BooleanField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    KEY_LEARNING_AREA = New TextField("", Nothing)
    STATUS = New BooleanField(Settings.BoolFormat, False)
    STATUSCheckedValue = New BooleanField(Settings.BoolFormat, True)
    STATUSUncheckedValue = New BooleanField(Settings.BoolFormat, False)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As KEY_LEARNING_AREAItem
        Dim item As KEY_LEARNING_AREAItem = New KEY_LEARNING_AREAItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("KEY_LEARNING_AREA")) Then
        item.KEY_LEARNING_AREA.SetValue(DBUtility.GetInitialValue("KEY_LEARNING_AREA"))
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
                Case "KEY_LEARNING_AREA"
                    Return KEY_LEARNING_AREA
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
                Case "KEY_LEARNING_AREA"
                    KEY_LEARNING_AREA = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As KEY_LEARNING_AREADataProvider)
'End Record KEY_LEARNING_AREA Item Class

'KEY_LEARNING_AREA validate @7-5256830B
        If IsNothing(KEY_LEARNING_AREA.Value) OrElse KEY_LEARNING_AREA.Value.ToString() ="" Then
            errors.Add("KEY_LEARNING_AREA",String.Format(Resources.strings.CCS_RequiredField,"KEY LEARNING AREA"))
        End If
'End KEY_LEARNING_AREA validate

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

'Record KEY_LEARNING_AREA Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record KEY_LEARNING_AREA Item Class tail

'Record KEY_LEARNING_AREA Data Provider Class @2-D67E5014
Public Class KEY_LEARNING_AREADataProvider
Inherits RecordDataProviderBase
'End Record KEY_LEARNING_AREA Data Provider Class

'Record KEY_LEARNING_AREA Data Provider Class Variables @2-0106742F
    Public UrlKLA_ID As FloatParameter
    Protected item As KEY_LEARNING_AREAItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record KEY_LEARNING_AREA Data Provider Class Variables

'Record KEY_LEARNING_AREA Data Provider Class Constructor @2-5D9E30D5

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM KEY_LEARNING_AREA {SQL_Where} {SQL_OrderBy}", New String(){"KLA_ID6"},Settings.connDECVPRODSQL2005DataAccessObject )
        Delete=new TableCommand("DELETE FROM KEY_LEARNING_AREA", New String(){"KLA_ID6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
        Select_.OrderBy=""
    End Sub
'End Record KEY_LEARNING_AREA Data Provider Class Constructor

'Record KEY_LEARNING_AREA Data Provider Class LoadParams Method @2-6E6E811D

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlKLA_ID))
    End Function
'End Record KEY_LEARNING_AREA Data Provider Class LoadParams Method

'Record KEY_LEARNING_AREA Data Provider Class CheckUnique Method @2-F692AA38

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As KEY_LEARNING_AREAItem) As Boolean
        Return True
    End Function
'End Record KEY_LEARNING_AREA Data Provider Class CheckUnique Method

'Record KEY_LEARNING_AREA Data Provider Class PrepareInsert Method @2-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record KEY_LEARNING_AREA Data Provider Class PrepareInsert Method

'Record KEY_LEARNING_AREA Data Provider Class PrepareInsert Method tail @2-E31F8E2A
    End Sub
'End Record KEY_LEARNING_AREA Data Provider Class PrepareInsert Method tail

'Record KEY_LEARNING_AREA Data Provider Class Insert Method @2-FEB4A205

    Public Function InsertItem(ByVal item As KEY_LEARNING_AREAItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO KEY_LEARNING_AREA({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record KEY_LEARNING_AREA Data Provider Class Insert Method

'Record KEY_LEARNING_AREA Build insert @2-08FC05B4
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.KEY_LEARNING_AREA.IsEmpty Then
        allEmptyFlag = item.KEY_LEARNING_AREA.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "KEY_LEARNING_AREA,"
        valuesList = valuesList & Insert.Dao.ToSql(item.KEY_LEARNING_AREA.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record KEY_LEARNING_AREA Build insert

'Record KEY_LEARNING_AREA AfterExecuteInsert @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record KEY_LEARNING_AREA AfterExecuteInsert

'Record KEY_LEARNING_AREA Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record KEY_LEARNING_AREA Data Provider Class PrepareUpdate Method

'Record KEY_LEARNING_AREA Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record KEY_LEARNING_AREA Data Provider Class PrepareUpdate Method tail

'Record KEY_LEARNING_AREA Data Provider Class Update Method @2-61280D2C

    Public Function UpdateItem(ByVal item As KEY_LEARNING_AREAItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE KEY_LEARNING_AREA SET {Values}", New String(){"KLA_ID6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record KEY_LEARNING_AREA Data Provider Class Update Method

'Record KEY_LEARNING_AREA BeforeBuildUpdate @2-32BAF54E
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("KLA_ID6",UrlKLA_ID, "","KLA_ID",Condition.Equal,False)
        If Not item.KEY_LEARNING_AREA.IsEmpty Then
        allEmptyFlag = item.KEY_LEARNING_AREA.IsEmpty And allEmptyFlag
        valuesList = valuesList & "KEY_LEARNING_AREA=" + Update.Dao.ToSql(item.KEY_LEARNING_AREA.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record KEY_LEARNING_AREA BeforeBuildUpdate

'Record KEY_LEARNING_AREA AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record KEY_LEARNING_AREA AfterExecuteUpdate

'Record KEY_LEARNING_AREA Data Provider Class PrepareDelete Method @2-F7361E57

    Protected Overrides Sub PrepareDelete()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record KEY_LEARNING_AREA Data Provider Class PrepareDelete Method

'Record KEY_LEARNING_AREA Data Provider Class PrepareDelete Method tail @2-E31F8E2A
    End Sub
'End Record KEY_LEARNING_AREA Data Provider Class PrepareDelete Method tail

'Record KEY_LEARNING_AREA Data Provider Class Delete Method @2-49267923
    Public Function DeleteItem(ByVal item As KEY_LEARNING_AREAItem) As Integer
        Me.item = item
'End Record KEY_LEARNING_AREA Data Provider Class Delete Method

'Record KEY_LEARNING_AREA BeforeBuildDelete @2-FB8D06CE
        Delete.Parameters.Clear()
        CType(Delete,TableCommand).AddParameter("KLA_ID6",UrlKLA_ID, "","KLA_ID",Condition.Equal,False)
        Delete.SqlQuery.Replace("{KEY_LEARNING_AREA}",Delete.Dao.ToSql(item.KEY_LEARNING_AREA.GetFormattedValue(""),FieldType._Text))
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
'End Record KEY_LEARNING_AREA BeforeBuildDelete

'Record KEY_LEARNING_AREA BeforeBuildDelete @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record KEY_LEARNING_AREA BeforeBuildDelete

'Record KEY_LEARNING_AREA Data Provider Class GetResultSet Method @2-BA7588D2

    Public Sub FillItem(ByVal item As KEY_LEARNING_AREAItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record KEY_LEARNING_AREA Data Provider Class GetResultSet Method

'Record KEY_LEARNING_AREA BeforeBuildSelect @2-167FC38C
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("KLA_ID6",UrlKLA_ID, "","KLA_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record KEY_LEARNING_AREA BeforeBuildSelect

'Record KEY_LEARNING_AREA BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record KEY_LEARNING_AREA BeforeExecuteSelect

'Record KEY_LEARNING_AREA AfterExecuteSelect @2-9A3AB5DB
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.KEY_LEARNING_AREA.SetValue(dr(i)("KEY_LEARNING_AREA"),"")
            item.STATUS.SetValue(dr(i)("STATUS"),Select_.BoolFormat)
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
'End Record KEY_LEARNING_AREA AfterExecuteSelect

'Record KEY_LEARNING_AREA AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record KEY_LEARNING_AREA AfterExecuteSelect tail

'Record KEY_LEARNING_AREA Data Provider Class @2-A61BA892
End Class

'End Record KEY_LEARNING_AREA Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

