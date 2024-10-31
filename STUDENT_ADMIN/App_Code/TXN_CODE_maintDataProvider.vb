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

Namespace DECV_PROD2007.TXN_CODE_maint 'Namespace @1-35C93230

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

'Record TXN_CODE Item Class @2-9CCC61D6
Public Class TXN_CODEItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public TXN_TYPE As TextField
    Public CR_DR_FLAG As TextField
    Public DESCRIPTION As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    TXN_TYPE = New TextField("", Nothing)
    CR_DR_FLAG = New TextField("", Nothing)
    DESCRIPTION = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As TXN_CODEItem
        Dim item As TXN_CODEItem = New TXN_CODEItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("TXN_TYPE")) Then
        item.TXN_TYPE.SetValue(DBUtility.GetInitialValue("TXN_TYPE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CR_DR_FLAG")) Then
        item.CR_DR_FLAG.SetValue(DBUtility.GetInitialValue("CR_DR_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DESCRIPTION")) Then
        item.DESCRIPTION.SetValue(DBUtility.GetInitialValue("DESCRIPTION"))
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
                Case "TXN_TYPE"
                    Return TXN_TYPE
                Case "CR_DR_FLAG"
                    Return CR_DR_FLAG
                Case "DESCRIPTION"
                    Return DESCRIPTION
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
                Case "TXN_TYPE"
                    TXN_TYPE = CType(value, TextField)
                Case "CR_DR_FLAG"
                    CR_DR_FLAG = CType(value, TextField)
                Case "DESCRIPTION"
                    DESCRIPTION = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As TXN_CODEDataProvider)
'End Record TXN_CODE Item Class

'TXN_TYPE validate @7-2192D534
        If IsNothing(TXN_TYPE.Value) OrElse TXN_TYPE.Value.ToString() ="" Then
            errors.Add("TXN_TYPE",String.Format(Resources.strings.CCS_RequiredField,"TXN TYPE"))
        End If
'End TXN_TYPE validate

'CR_DR_FLAG validate @8-6D3AA75B
        If IsNothing(CR_DR_FLAG.Value) OrElse CR_DR_FLAG.Value.ToString() ="" Then
            errors.Add("CR_DR_FLAG",String.Format(Resources.strings.CCS_RequiredField,"CR DR FLAG"))
        End If
'End CR_DR_FLAG validate

'LAST_ALTERED_BY validate @10-256A6854
        If IsNothing(LAST_ALTERED_BY.Value) OrElse LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End LAST_ALTERED_BY validate

'LAST_ALTERED_DATE validate @11-C5989D76
        If IsNothing(LAST_ALTERED_DATE.Value) OrElse LAST_ALTERED_DATE.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED DATE"))
        End If
'End LAST_ALTERED_DATE validate

'Record TXN_CODE Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record TXN_CODE Item Class tail

'Record TXN_CODE Data Provider Class @2-6656EBF3
Public Class TXN_CODEDataProvider
Inherits RecordDataProviderBase
'End Record TXN_CODE Data Provider Class

'Record TXN_CODE Data Provider Class Variables @2-0212CACD
    Public UrlTXN_CODE As TextParameter
    Protected item As TXN_CODEItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record TXN_CODE Data Provider Class Variables

'Record TXN_CODE Data Provider Class Constructor @2-002D0B53

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM TXN_CODE {SQL_Where} {SQL_OrderBy}", New String(){"TXN_CODE6"},Settings.connDECVPRODSQL2005DataAccessObject )
        Delete=new TableCommand("DELETE FROM TXN_CODE", New String(){"TXN_CODE6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
        Select_.OrderBy=""
    End Sub
'End Record TXN_CODE Data Provider Class Constructor

'Record TXN_CODE Data Provider Class LoadParams Method @2-C26959F8

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlTXN_CODE))
    End Function
'End Record TXN_CODE Data Provider Class LoadParams Method

'Record TXN_CODE Data Provider Class CheckUnique Method @2-AD77BD2E

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As TXN_CODEItem) As Boolean
        Return True
    End Function
'End Record TXN_CODE Data Provider Class CheckUnique Method

'Record TXN_CODE Data Provider Class PrepareInsert Method @2-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record TXN_CODE Data Provider Class PrepareInsert Method

'Record TXN_CODE Data Provider Class PrepareInsert Method tail @2-E31F8E2A
    End Sub
'End Record TXN_CODE Data Provider Class PrepareInsert Method tail

'Record TXN_CODE Data Provider Class Insert Method @2-9A3B7516

    Public Function InsertItem(ByVal item As TXN_CODEItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO TXN_CODE({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record TXN_CODE Data Provider Class Insert Method

'Record TXN_CODE Build insert @2-A7ABA332
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.TXN_TYPE.IsEmpty Then
        allEmptyFlag = item.TXN_TYPE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "TXN_TYPE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.TXN_TYPE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CR_DR_FLAG.IsEmpty Then
        allEmptyFlag = item.CR_DR_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CR_DR_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CR_DR_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.DESCRIPTION.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "DESCRIPTION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record TXN_CODE Build insert

'Record TXN_CODE AfterExecuteInsert @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record TXN_CODE AfterExecuteInsert

'Record TXN_CODE Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record TXN_CODE Data Provider Class PrepareUpdate Method

'Record TXN_CODE Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record TXN_CODE Data Provider Class PrepareUpdate Method tail

'Record TXN_CODE Data Provider Class Update Method @2-10F3221A

    Public Function UpdateItem(ByVal item As TXN_CODEItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE TXN_CODE SET {Values}", New String(){"TXN_CODE6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record TXN_CODE Data Provider Class Update Method

'Record TXN_CODE BeforeBuildUpdate @2-3122FD4B
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("TXN_CODE6",UrlTXN_CODE, "","TXN_CODE",Condition.Equal,False)
        If Not item.TXN_TYPE.IsEmpty Then
        allEmptyFlag = item.TXN_TYPE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "TXN_TYPE=" + Update.Dao.ToSql(item.TXN_TYPE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CR_DR_FLAG.IsEmpty Then
        allEmptyFlag = item.CR_DR_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CR_DR_FLAG=" + Update.Dao.ToSql(item.CR_DR_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.DESCRIPTION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DESCRIPTION=" + Update.Dao.ToSql(item.DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record TXN_CODE BeforeBuildUpdate

'Record TXN_CODE AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record TXN_CODE AfterExecuteUpdate

'Record TXN_CODE Data Provider Class PrepareDelete Method @2-F7361E57

    Protected Overrides Sub PrepareDelete()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record TXN_CODE Data Provider Class PrepareDelete Method

'Record TXN_CODE Data Provider Class PrepareDelete Method tail @2-E31F8E2A
    End Sub
'End Record TXN_CODE Data Provider Class PrepareDelete Method tail

'Record TXN_CODE Data Provider Class Delete Method @2-55562B08
    Public Function DeleteItem(ByVal item As TXN_CODEItem) As Integer
        Me.item = item
'End Record TXN_CODE Data Provider Class Delete Method

'Record TXN_CODE BeforeBuildDelete @2-03E1A505
        Delete.Parameters.Clear()
        CType(Delete,TableCommand).AddParameter("TXN_CODE6",UrlTXN_CODE, "","TXN_CODE",Condition.Equal,False)
        Delete.SqlQuery.Replace("{TXN_TYPE}",Delete.Dao.ToSql(item.TXN_TYPE.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{CR_DR_FLAG}",Delete.Dao.ToSql(item.CR_DR_FLAG.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{DESCRIPTION}",Delete.Dao.ToSql(item.DESCRIPTION.GetFormattedValue(""),FieldType._Text))
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
'End Record TXN_CODE BeforeBuildDelete

'Record TXN_CODE BeforeBuildDelete @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record TXN_CODE BeforeBuildDelete

'Record TXN_CODE Data Provider Class GetResultSet Method @2-0064DC0C

    Public Sub FillItem(ByVal item As TXN_CODEItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record TXN_CODE Data Provider Class GetResultSet Method

'Record TXN_CODE BeforeBuildSelect @2-C3845AA1
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("TXN_CODE6",UrlTXN_CODE, "","TXN_CODE",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record TXN_CODE BeforeBuildSelect

'Record TXN_CODE BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record TXN_CODE BeforeExecuteSelect

'Record TXN_CODE AfterExecuteSelect @2-9041CF5E
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.TXN_TYPE.SetValue(dr(i)("TXN_TYPE"),"")
            item.CR_DR_FLAG.SetValue(dr(i)("CR_DR_FLAG"),"")
            item.DESCRIPTION.SetValue(dr(i)("DESCRIPTION"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
'End Record TXN_CODE AfterExecuteSelect

'Record TXN_CODE AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record TXN_CODE AfterExecuteSelect tail

'Record TXN_CODE Data Provider Class @2-A61BA892
End Class

'End Record TXN_CODE Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

