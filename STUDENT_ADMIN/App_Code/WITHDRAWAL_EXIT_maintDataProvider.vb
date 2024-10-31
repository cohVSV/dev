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

Namespace DECV_PROD2007.WITHDRAWAL_EXIT_maint 'Namespace @1-F90D6A05

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

'Record WITHDRAWAL_EXIT_DESTINATI Item Class @2-C98DD75F
Public Class WITHDRAWAL_EXIT_DESTINATIItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public EXIT_DESTINATION_DESCRIPTION As TextField
    Public DISPLAY_ORDER As IntegerField
    Public GROUPING As TextField
    Public GROUPINGItems As ItemCollection
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public lblLAST_ALTERED_BY As TextField
    Public lblLAST_ALTERED_DATE As DateField
    Public Sub New()
    EXIT_DESTINATION_DESCRIPTION = New TextField("", Nothing)
    DISPLAY_ORDER = New IntegerField("", Nothing)
    GROUPING = New TextField("", Nothing)
    GROUPINGItems = New ItemCollection()
    LAST_ALTERED_BY = New TextField("", DBUtility.UserLogin.ToUpper())
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    lblLAST_ALTERED_BY = New TextField("", "unknown")
    lblLAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    End Sub

    Public Shared Function CreateFromHttpRequest() As WITHDRAWAL_EXIT_DESTINATIItem
        Dim item As WITHDRAWAL_EXIT_DESTINATIItem = New WITHDRAWAL_EXIT_DESTINATIItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EXIT_DESTINATION_DESCRIPTION")) Then
        item.EXIT_DESTINATION_DESCRIPTION.SetValue(DBUtility.GetInitialValue("EXIT_DESTINATION_DESCRIPTION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DISPLAY_ORDER")) Then
        item.DISPLAY_ORDER.SetValue(DBUtility.GetInitialValue("DISPLAY_ORDER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("GROUPING")) Then
        item.GROUPING.SetValue(DBUtility.GetInitialValue("GROUPING"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblLAST_ALTERED_BY")) Then
        item.lblLAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("lblLAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblLAST_ALTERED_DATE")) Then
        item.lblLAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("lblLAST_ALTERED_DATE"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "EXIT_DESTINATION_DESCRIPTION"
                    Return EXIT_DESTINATION_DESCRIPTION
                Case "DISPLAY_ORDER"
                    Return DISPLAY_ORDER
                Case "GROUPING"
                    Return GROUPING
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "lblLAST_ALTERED_BY"
                    Return lblLAST_ALTERED_BY
                Case "lblLAST_ALTERED_DATE"
                    Return lblLAST_ALTERED_DATE
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "EXIT_DESTINATION_DESCRIPTION"
                    EXIT_DESTINATION_DESCRIPTION = CType(value, TextField)
                Case "DISPLAY_ORDER"
                    DISPLAY_ORDER = CType(value, IntegerField)
                Case "GROUPING"
                    GROUPING = CType(value, TextField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "lblLAST_ALTERED_BY"
                    lblLAST_ALTERED_BY = CType(value, TextField)
                Case "lblLAST_ALTERED_DATE"
                    lblLAST_ALTERED_DATE = CType(value, DateField)
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

    Public Sub Validate(ByVal provider As WITHDRAWAL_EXIT_DESTINATIDataProvider)
'End Record WITHDRAWAL_EXIT_DESTINATI Item Class

'EXIT_DESTINATION_DESCRIPTION validate @7-E6397535
        If IsNothing(EXIT_DESTINATION_DESCRIPTION.Value) OrElse EXIT_DESTINATION_DESCRIPTION.Value.ToString() ="" Then
            errors.Add("EXIT_DESTINATION_DESCRIPTION",String.Format(Resources.strings.CCS_RequiredField,"EXIT DESTINATION DESCRIPTION"))
        End If
'End EXIT_DESTINATION_DESCRIPTION validate

'DISPLAY_ORDER validate @8-DAAFE785
        If IsNothing(DISPLAY_ORDER.Value) OrElse DISPLAY_ORDER.Value.ToString() ="" Then
            errors.Add("DISPLAY_ORDER",String.Format(Resources.strings.CCS_RequiredField,"DISPLAY ORDER"))
        End If
'End DISPLAY_ORDER validate

'Record WITHDRAWAL_EXIT_DESTINATI Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record WITHDRAWAL_EXIT_DESTINATI Item Class tail

'Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class @2-8FD1708E
Public Class WITHDRAWAL_EXIT_DESTINATIDataProvider
Inherits RecordDataProviderBase
'End Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class

'Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class Variables @2-442E70AA
    Protected GROUPINGDataCommand As DataCommand=new SqlCommand("SELECT distinct GROUPING " & vbCrLf & _
          "FROM WITHDRAWAL_EXIT_DESTINATION  {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
    Public UrlWD_DEST_ID As FloatParameter
    Protected item As WITHDRAWAL_EXIT_DESTINATIItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class Variables

'Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class Constructor @2-0A45E52C

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM WITHDRAWAL_EXIT_DESTINATION {SQL_Where} {SQL_OrderBy}", New String(){"WD_DEST_ID6"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class Constructor

'Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class LoadParams Method @2-1CE2D0C3

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlWD_DEST_ID))
    End Function
'End Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class LoadParams Method

'Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class CheckUnique Method @2-7131BE21

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As WITHDRAWAL_EXIT_DESTINATIItem) As Boolean
        Return True
    End Function
'End Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class CheckUnique Method

'Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class PrepareInsert Method @2-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class PrepareInsert Method

'Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class PrepareInsert Method tail @2-E31F8E2A
    End Sub
'End Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class PrepareInsert Method tail

'Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class Insert Method @2-00638A98

    Public Function InsertItem(ByVal item As WITHDRAWAL_EXIT_DESTINATIItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO WITHDRAWAL_EXIT_DESTINATION({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class Insert Method

'Record WITHDRAWAL_EXIT_DESTINATI Build insert @2-A7DDC35A
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.EXIT_DESTINATION_DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.EXIT_DESTINATION_DESCRIPTION.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "EXIT_DESTINATION_DESCRIPTION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.EXIT_DESTINATION_DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DISPLAY_ORDER.IsEmpty Then
        allEmptyFlag = item.DISPLAY_ORDER.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "DISPLAY_ORDER,"
        valuesList = valuesList & Insert.Dao.ToSql(item.DISPLAY_ORDER.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.GROUPING.IsEmpty Then
        allEmptyFlag = item.GROUPING.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "GROUPING,"
        valuesList = valuesList & Insert.Dao.ToSql(item.GROUPING.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record WITHDRAWAL_EXIT_DESTINATI Build insert

'Record WITHDRAWAL_EXIT_DESTINATI AfterExecuteInsert @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record WITHDRAWAL_EXIT_DESTINATI AfterExecuteInsert

'Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class PrepareUpdate Method

'Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class PrepareUpdate Method tail

'Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class Update Method @2-9C3AF2AD

    Public Function UpdateItem(ByVal item As WITHDRAWAL_EXIT_DESTINATIItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE WITHDRAWAL_EXIT_DESTINATION SET {Values}", New String(){"WD_DEST_ID6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class Update Method

'Record WITHDRAWAL_EXIT_DESTINATI BeforeBuildUpdate @2-58C6004B
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("WD_DEST_ID6",UrlWD_DEST_ID, "","WD_DEST_ID",Condition.Equal,False)
        If Not item.EXIT_DESTINATION_DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.EXIT_DESTINATION_DESCRIPTION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "EXIT_DESTINATION_DESCRIPTION=" + Update.Dao.ToSql(item.EXIT_DESTINATION_DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DISPLAY_ORDER.IsEmpty Then
        allEmptyFlag = item.DISPLAY_ORDER.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DISPLAY_ORDER=" + Update.Dao.ToSql(item.DISPLAY_ORDER.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.GROUPING.IsEmpty Then
        allEmptyFlag = item.GROUPING.IsEmpty And allEmptyFlag
        valuesList = valuesList & "GROUPING=" + Update.Dao.ToSql(item.GROUPING.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record WITHDRAWAL_EXIT_DESTINATI BeforeBuildUpdate

'Record WITHDRAWAL_EXIT_DESTINATI AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record WITHDRAWAL_EXIT_DESTINATI AfterExecuteUpdate

'Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class GetResultSet Method @2-ED3D6CB7

    Public Sub FillItem(ByVal item As WITHDRAWAL_EXIT_DESTINATIItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class GetResultSet Method

'Record WITHDRAWAL_EXIT_DESTINATI BeforeBuildSelect @2-F76D4711
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("WD_DEST_ID6",UrlWD_DEST_ID, "","WD_DEST_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record WITHDRAWAL_EXIT_DESTINATI BeforeBuildSelect

'Record WITHDRAWAL_EXIT_DESTINATI BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record WITHDRAWAL_EXIT_DESTINATI BeforeExecuteSelect

'Record WITHDRAWAL_EXIT_DESTINATI AfterExecuteSelect @2-16B05147
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.EXIT_DESTINATION_DESCRIPTION.SetValue(dr(i)("EXIT_DESTINATION_DESCRIPTION"),"")
            item.DISPLAY_ORDER.SetValue(dr(i)("DISPLAY_ORDER"),"")
            item.GROUPING.SetValue(dr(i)("GROUPING"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.lblLAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.lblLAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record WITHDRAWAL_EXIT_DESTINATI AfterExecuteSelect

'ListBox GROUPING Initialize Data Source @9-9CAC2C29
        GROUPINGDataCommand.Dao._optimized = False
        Dim GROUPINGtableIndex As Integer = 0
        GROUPINGDataCommand.OrderBy = "GROUPING"
        GROUPINGDataCommand.Parameters.Clear()
'End ListBox GROUPING Initialize Data Source

'ListBox GROUPING BeforeExecuteSelect @9-9D31C3F1
        Try
            ListBoxSource=GROUPINGDataCommand.Execute().Tables(GROUPINGtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox GROUPING BeforeExecuteSelect

'ListBox GROUPING AfterExecuteSelect @9-B3CEE4DA
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("GROUPING"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("GROUPING")
            item.GROUPINGItems.Add(Key, Val)
        Next
'End ListBox GROUPING AfterExecuteSelect

'Record WITHDRAWAL_EXIT_DESTINATI AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record WITHDRAWAL_EXIT_DESTINATI AfterExecuteSelect tail

'Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class @2-A61BA892
End Class

'End Record WITHDRAWAL_EXIT_DESTINATI Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

