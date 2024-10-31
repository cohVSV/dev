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

Namespace DECV_PROD2007.COUNTRY_OF_BIRT_maint 'Namespace @1-3A298D3E

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

'Record COUNTRY_OF_BIRTH Item Class @2-116DBC4D
Public Class COUNTRY_OF_BIRTHItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public COUNTRY_NAME As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    COUNTRY_NAME = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As COUNTRY_OF_BIRTHItem
        Dim item As COUNTRY_OF_BIRTHItem = New COUNTRY_OF_BIRTHItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COUNTRY_NAME")) Then
        item.COUNTRY_NAME.SetValue(DBUtility.GetInitialValue("COUNTRY_NAME"))
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
                Case "COUNTRY_NAME"
                    Return COUNTRY_NAME
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
                Case "COUNTRY_NAME"
                    COUNTRY_NAME = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As COUNTRY_OF_BIRTHDataProvider)
'End Record COUNTRY_OF_BIRTH Item Class

'COUNTRY_NAME validate @7-F2385116
        If IsNothing(COUNTRY_NAME.Value) OrElse COUNTRY_NAME.Value.ToString() ="" Then
            errors.Add("COUNTRY_NAME",String.Format(Resources.strings.CCS_RequiredField,"COUNTRY NAME"))
        End If
'End COUNTRY_NAME validate

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

'Record COUNTRY_OF_BIRTH Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record COUNTRY_OF_BIRTH Item Class tail

'Record COUNTRY_OF_BIRTH Data Provider Class @2-6F382CF1
Public Class COUNTRY_OF_BIRTHDataProvider
Inherits RecordDataProviderBase
'End Record COUNTRY_OF_BIRTH Data Provider Class

'Record COUNTRY_OF_BIRTH Data Provider Class Variables @2-FEF0E8E6
    Public UrlCOUNTRY_ID As IntegerParameter
    Protected item As COUNTRY_OF_BIRTHItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record COUNTRY_OF_BIRTH Data Provider Class Variables

'Record COUNTRY_OF_BIRTH Data Provider Class Constructor @2-130DA4A9

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM COUNTRY_OF_BIRTH {SQL_Where} {SQL_OrderBy}", New String(){"COUNTRY_ID6"},Settings.connDECVPRODSQL2005DataAccessObject )
        Delete=new TableCommand("DELETE FROM COUNTRY_OF_BIRTH", New String(){"COUNTRY_ID6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
        Select_.OrderBy=""
    End Sub
'End Record COUNTRY_OF_BIRTH Data Provider Class Constructor

'Record COUNTRY_OF_BIRTH Data Provider Class LoadParams Method @2-32987AC8

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlCOUNTRY_ID))
    End Function
'End Record COUNTRY_OF_BIRTH Data Provider Class LoadParams Method

'Record COUNTRY_OF_BIRTH Data Provider Class CheckUnique Method @2-DC866546

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As COUNTRY_OF_BIRTHItem) As Boolean
        Return True
    End Function
'End Record COUNTRY_OF_BIRTH Data Provider Class CheckUnique Method

'Record COUNTRY_OF_BIRTH Data Provider Class PrepareInsert Method @2-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record COUNTRY_OF_BIRTH Data Provider Class PrepareInsert Method

'Record COUNTRY_OF_BIRTH Data Provider Class PrepareInsert Method tail @2-E31F8E2A
    End Sub
'End Record COUNTRY_OF_BIRTH Data Provider Class PrepareInsert Method tail

'Record COUNTRY_OF_BIRTH Data Provider Class Insert Method @2-57FC620A

    Public Function InsertItem(ByVal item As COUNTRY_OF_BIRTHItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO COUNTRY_OF_BIRTH({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record COUNTRY_OF_BIRTH Data Provider Class Insert Method

'Record COUNTRY_OF_BIRTH Build insert @2-1A831ACF
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.COUNTRY_NAME.IsEmpty Then
        allEmptyFlag = item.COUNTRY_NAME.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "COUNTRY_NAME,"
        valuesList = valuesList & Insert.Dao.ToSql(item.COUNTRY_NAME.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record COUNTRY_OF_BIRTH Build insert

'Record COUNTRY_OF_BIRTH AfterExecuteInsert @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record COUNTRY_OF_BIRTH AfterExecuteInsert

'Record COUNTRY_OF_BIRTH Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record COUNTRY_OF_BIRTH Data Provider Class PrepareUpdate Method

'Record COUNTRY_OF_BIRTH Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record COUNTRY_OF_BIRTH Data Provider Class PrepareUpdate Method tail

'Record COUNTRY_OF_BIRTH Data Provider Class Update Method @2-B4FC0F03

    Public Function UpdateItem(ByVal item As COUNTRY_OF_BIRTHItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE COUNTRY_OF_BIRTH SET {Values}", New String(){"COUNTRY_ID6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record COUNTRY_OF_BIRTH Data Provider Class Update Method

'Record COUNTRY_OF_BIRTH BeforeBuildUpdate @2-06A870E9
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("COUNTRY_ID6",UrlCOUNTRY_ID, "","COUNTRY_ID",Condition.Equal,False)
        If Not item.COUNTRY_NAME.IsEmpty Then
        allEmptyFlag = item.COUNTRY_NAME.IsEmpty And allEmptyFlag
        valuesList = valuesList & "COUNTRY_NAME=" + Update.Dao.ToSql(item.COUNTRY_NAME.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record COUNTRY_OF_BIRTH BeforeBuildUpdate

'Record COUNTRY_OF_BIRTH AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record COUNTRY_OF_BIRTH AfterExecuteUpdate

'Record COUNTRY_OF_BIRTH Data Provider Class PrepareDelete Method @2-F7361E57

    Protected Overrides Sub PrepareDelete()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record COUNTRY_OF_BIRTH Data Provider Class PrepareDelete Method

'Record COUNTRY_OF_BIRTH Data Provider Class PrepareDelete Method tail @2-E31F8E2A
    End Sub
'End Record COUNTRY_OF_BIRTH Data Provider Class PrepareDelete Method tail

'Record COUNTRY_OF_BIRTH Data Provider Class Delete Method @2-4205BF38
    Public Function DeleteItem(ByVal item As COUNTRY_OF_BIRTHItem) As Integer
        Me.item = item
'End Record COUNTRY_OF_BIRTH Data Provider Class Delete Method

'Record COUNTRY_OF_BIRTH BeforeBuildDelete @2-C9B72170
        Delete.Parameters.Clear()
        CType(Delete,TableCommand).AddParameter("COUNTRY_ID6",UrlCOUNTRY_ID, "","COUNTRY_ID",Condition.Equal,False)
        Delete.SqlQuery.Replace("{COUNTRY_NAME}",Delete.Dao.ToSql(item.COUNTRY_NAME.GetFormattedValue(""),FieldType._Text))
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
'End Record COUNTRY_OF_BIRTH BeforeBuildDelete

'Record COUNTRY_OF_BIRTH BeforeBuildDelete @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record COUNTRY_OF_BIRTH BeforeBuildDelete

'Record COUNTRY_OF_BIRTH Data Provider Class GetResultSet Method @2-633B216E

    Public Sub FillItem(ByVal item As COUNTRY_OF_BIRTHItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record COUNTRY_OF_BIRTH Data Provider Class GetResultSet Method

'Record COUNTRY_OF_BIRTH BeforeBuildSelect @2-0B1E9DD0
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("COUNTRY_ID6",UrlCOUNTRY_ID, "","COUNTRY_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record COUNTRY_OF_BIRTH BeforeBuildSelect

'Record COUNTRY_OF_BIRTH BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record COUNTRY_OF_BIRTH BeforeExecuteSelect

'Record COUNTRY_OF_BIRTH AfterExecuteSelect @2-B36B6677
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.COUNTRY_NAME.SetValue(dr(i)("COUNTRY_NAME"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
'End Record COUNTRY_OF_BIRTH AfterExecuteSelect

'Record COUNTRY_OF_BIRTH AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record COUNTRY_OF_BIRTH AfterExecuteSelect tail

'Record COUNTRY_OF_BIRTH Data Provider Class @2-A61BA892
End Class

'End Record COUNTRY_OF_BIRTH Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

