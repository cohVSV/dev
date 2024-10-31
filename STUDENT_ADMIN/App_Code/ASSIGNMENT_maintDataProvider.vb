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

Namespace DECV_PROD2007.ASSIGNMENT_maint 'Namespace @1-49643D26

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

'Record Assignment_maint Item Class @3-AB51F947
Public Class Assignment_maintItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public lblSubjectID As TextField
    Public lblSubjectName As TextField
    Public txtASSIGNMENT_ID As IntegerField
    Public txtASSIGNMENT_DESCRIPTION As TextField
    Public radioSTATUS As BooleanField
    Public radioSTATUSItems As ItemCollection
    Public lblLAST_ALTERED_BY As TextField
    Public lblLAST_ALTERED_DATE As DateField
    Public hidden_SUBJECT_ID As TextField
    Public hidden_LAST_ALTERED_BY As TextField
    Public hidden_LAST_ALTERED_DATE As DateField
    Public Sub New()
    lblSubjectID = New TextField("", Nothing)
    lblSubjectName = New TextField("", Nothing)
    txtASSIGNMENT_ID = New IntegerField("", Nothing)
    txtASSIGNMENT_DESCRIPTION = New TextField("", Nothing)
    radioSTATUS = New BooleanField(Settings.BoolFormat, "Yes")
    radioSTATUSItems = New ItemCollection()
    lblLAST_ALTERED_BY = New TextField("", Nothing)
    lblLAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    hidden_SUBJECT_ID = New TextField("", Nothing)
    hidden_LAST_ALTERED_BY = New TextField("", Nothing)
    hidden_LAST_ALTERED_DATE = New DateField(Settings.DateFormat, DateTime.Now)
    End Sub

    Public Shared Function CreateFromHttpRequest() As Assignment_maintItem
        Dim item As Assignment_maintItem = New Assignment_maintItem()
        If Not IsNothing(DBUtility.GetInitialValue("lblSubjectID")) Then
        item.lblSubjectID.SetValue(DBUtility.GetInitialValue("lblSubjectID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblSubjectName")) Then
        item.lblSubjectName.SetValue(DBUtility.GetInitialValue("lblSubjectName"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("txtASSIGNMENT_ID")) Then
        item.txtASSIGNMENT_ID.SetValue(DBUtility.GetInitialValue("txtASSIGNMENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("txtASSIGNMENT_DESCRIPTION")) Then
        item.txtASSIGNMENT_DESCRIPTION.SetValue(DBUtility.GetInitialValue("txtASSIGNMENT_DESCRIPTION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("radioSTATUS")) Then
        item.radioSTATUS.SetValue(DBUtility.GetInitialValue("radioSTATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblLAST_ALTERED_BY")) Then
        item.lblLAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("lblLAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblLAST_ALTERED_DATE")) Then
        item.lblLAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("lblLAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_SUBJECT_ID")) Then
        item.hidden_SUBJECT_ID.SetValue(DBUtility.GetInitialValue("hidden_SUBJECT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY")) Then
        item.hidden_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_DATE")) Then
        item.hidden_LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_DATE"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "lblSubjectID"
                    Return lblSubjectID
                Case "lblSubjectName"
                    Return lblSubjectName
                Case "txtASSIGNMENT_ID"
                    Return txtASSIGNMENT_ID
                Case "txtASSIGNMENT_DESCRIPTION"
                    Return txtASSIGNMENT_DESCRIPTION
                Case "radioSTATUS"
                    Return radioSTATUS
                Case "lblLAST_ALTERED_BY"
                    Return lblLAST_ALTERED_BY
                Case "lblLAST_ALTERED_DATE"
                    Return lblLAST_ALTERED_DATE
                Case "hidden_SUBJECT_ID"
                    Return hidden_SUBJECT_ID
                Case "hidden_LAST_ALTERED_BY"
                    Return hidden_LAST_ALTERED_BY
                Case "hidden_LAST_ALTERED_DATE"
                    Return hidden_LAST_ALTERED_DATE
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblSubjectID"
                    lblSubjectID = CType(value, TextField)
                Case "lblSubjectName"
                    lblSubjectName = CType(value, TextField)
                Case "txtASSIGNMENT_ID"
                    txtASSIGNMENT_ID = CType(value, IntegerField)
                Case "txtASSIGNMENT_DESCRIPTION"
                    txtASSIGNMENT_DESCRIPTION = CType(value, TextField)
                Case "radioSTATUS"
                    radioSTATUS = CType(value, BooleanField)
                Case "lblLAST_ALTERED_BY"
                    lblLAST_ALTERED_BY = CType(value, TextField)
                Case "lblLAST_ALTERED_DATE"
                    lblLAST_ALTERED_DATE = CType(value, DateField)
                Case "hidden_SUBJECT_ID"
                    hidden_SUBJECT_ID = CType(value, TextField)
                Case "hidden_LAST_ALTERED_BY"
                    hidden_LAST_ALTERED_BY = CType(value, TextField)
                Case "hidden_LAST_ALTERED_DATE"
                    hidden_LAST_ALTERED_DATE = CType(value, DateField)
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

    Public Sub Validate(ByVal provider As Assignment_maintDataProvider)
'End Record Assignment_maint Item Class

'txtASSIGNMENT_ID validate @4-A7C71897
        If IsNothing(txtASSIGNMENT_ID.Value) OrElse txtASSIGNMENT_ID.Value.ToString() ="" Then
            errors.Add("txtASSIGNMENT_ID",String.Format(Resources.strings.CCS_RequiredField,"Assignment ID"))
        End If
'End txtASSIGNMENT_ID validate

'radioSTATUS validate @23-EC5D02A7
        If IsNothing(radioSTATUS.Value) OrElse radioSTATUS.Value.ToString() ="" Then
            errors.Add("radioSTATUS",String.Format(Resources.strings.CCS_RequiredField,"Status"))
        End If
'End radioSTATUS validate

'Record Assignment_maint Item Class tail @3-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record Assignment_maint Item Class tail

'Record Assignment_maint Data Provider Class @3-3E72D628
Public Class Assignment_maintDataProvider
Inherits RecordDataProviderBase
'End Record Assignment_maint Data Provider Class

'Record Assignment_maint Data Provider Class Variables @3-BDCB8D4D
    Public UrlASSIGNMENT_ID As IntegerParameter
    Public UrlSUBJECT_ID As TextParameter
    Public Ctrlhidden_SUBJECT_ID As IntegerParameter
    Public CtrltxtASSIGNMENT_ID As IntegerParameter
    Public CtrltxtASSIGNMENT_DESCRIPTION As TextParameter
    Public CtrlradioSTATUS As BooleanParameter
    Public Ctrlhidden_LAST_ALTERED_BY As TextParameter
    Public Ctrlhidden_LAST_ALTERED_DATE As DateParameter
    Protected item As Assignment_maintItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record Assignment_maint Data Provider Class Variables

'Record Assignment_maint Data Provider Class Constructor @3-92791A22

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM ASSIGNMENT {SQL_Where} {SQL_OrderBy}", New String(){"SUBJECT_ID30","And","ASSIGNMENT_ID31"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record Assignment_maint Data Provider Class Constructor

'Record Assignment_maint Data Provider Class LoadParams Method @3-2FC11D3D

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSUBJECT_ID) Or IsNothing(UrlASSIGNMENT_ID))
    End Function
'End Record Assignment_maint Data Provider Class LoadParams Method

'Record Assignment_maint Data Provider Class CheckUnique Method @3-14B26BD0

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As Assignment_maintItem) As Boolean
        Return True
    End Function
'End Record Assignment_maint Data Provider Class CheckUnique Method

'Record Assignment_maint Data Provider Class PrepareInsert Method @3-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record Assignment_maint Data Provider Class PrepareInsert Method

'Record Assignment_maint Data Provider Class PrepareInsert Method tail @3-E31F8E2A
    End Sub
'End Record Assignment_maint Data Provider Class PrepareInsert Method tail

'Record Assignment_maint Data Provider Class Insert Method @3-FD9506BD

    Public Function InsertItem(ByVal item As Assignment_maintItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO ASSIGNMENT({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record Assignment_maint Data Provider Class Insert Method

'Record Assignment_maint Build insert @3-8EE31916
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        allEmptyFlag = item.txtASSIGNMENT_ID.IsEmpty And allEmptyFlag
        If Not item.txtASSIGNMENT_ID.IsEmpty Then
        If IsNothing(item.txtASSIGNMENT_ID.Value) Then
        fieldsList = fieldsList & "ASSIGNMENT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        fieldsList = fieldsList & "ASSIGNMENT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.txtASSIGNMENT_ID.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.txtASSIGNMENT_DESCRIPTION.IsEmpty And allEmptyFlag
        If Not item.txtASSIGNMENT_DESCRIPTION.IsEmpty Then
        If IsNothing(item.txtASSIGNMENT_DESCRIPTION.Value) Then
        fieldsList = fieldsList & "DESCRIPTION,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "DESCRIPTION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.txtASSIGNMENT_DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.radioSTATUS.IsEmpty And allEmptyFlag
        If Not item.radioSTATUS.IsEmpty Then
        If IsNothing(item.radioSTATUS.Value) Then
        fieldsList = fieldsList & "STATUS,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Boolean) & ","
        Else
        fieldsList = fieldsList & "STATUS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.radioSTATUS.GetFormattedValue("1;0"),FieldType._Boolean) & ","
        End If
        End If
        allEmptyFlag = (UrlSUBJECT_ID Is Nothing) And allEmptyFlag
        If Not (UrlSUBJECT_ID Is Nothing) Then
        If IsNothing(UrlSUBJECT_ID) Then
        fieldsList = fieldsList & "SUBJECT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "SUBJECT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(UrlSUBJECT_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.hidden_LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        If Not item.hidden_LAST_ALTERED_BY.IsEmpty Then
        If IsNothing(item.hidden_LAST_ALTERED_BY.Value) Then
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.hidden_LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.hidden_LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        If Not item.hidden_LAST_ALTERED_DATE.IsEmpty Then
        If IsNothing(item.hidden_LAST_ALTERED_DATE.Value) Then
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.hidden_LAST_ALTERED_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
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
'End Record Assignment_maint Build insert

'Record Assignment_maint AfterExecuteInsert @3-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record Assignment_maint AfterExecuteInsert

'Record Assignment_maint Data Provider Class PrepareUpdate Method @3-B9C06FC5

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = Not(IsNothing(item.hidden_SUBJECT_ID) Or IsNothing(item.txtASSIGNMENT_ID))
'End Record Assignment_maint Data Provider Class PrepareUpdate Method

'Record Assignment_maint Data Provider Class PrepareUpdate Method tail @3-E31F8E2A
    End Sub
'End Record Assignment_maint Data Provider Class PrepareUpdate Method tail

'Record Assignment_maint Data Provider Class Update Method @3-D8B60C8B

    Public Function UpdateItem(ByVal item As Assignment_maintItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE ASSIGNMENT SET {Values}", New String(){"hidden_SUBJECT_ID25","And","txtASSIGNMENT_ID26"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record Assignment_maint Data Provider Class Update Method

'Record Assignment_maint BeforeBuildUpdate @3-0551D411
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("hidden_SUBJECT_ID25",item.hidden_SUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("txtASSIGNMENT_ID26",item.txtASSIGNMENT_ID, "","ASSIGNMENT_ID",Condition.Equal,False)
        allEmptyFlag = item.txtASSIGNMENT_ID.IsEmpty And allEmptyFlag
        If Not item.txtASSIGNMENT_ID.IsEmpty Then
        If IsNothing(item.txtASSIGNMENT_ID.Value) Then
        valuesList = valuesList & "ASSIGNMENT_ID=" & Update.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        valuesList = valuesList & "ASSIGNMENT_ID=" & Update.Dao.ToSql(item.txtASSIGNMENT_ID.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.txtASSIGNMENT_DESCRIPTION.IsEmpty And allEmptyFlag
        If Not item.txtASSIGNMENT_DESCRIPTION.IsEmpty Then
        If IsNothing(item.txtASSIGNMENT_DESCRIPTION.Value) Then
        valuesList = valuesList & "DESCRIPTION=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "DESCRIPTION=" & Update.Dao.ToSql(item.txtASSIGNMENT_DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.radioSTATUS.IsEmpty And allEmptyFlag
        If Not item.radioSTATUS.IsEmpty Then
        If IsNothing(item.radioSTATUS.Value) Then
        valuesList = valuesList & "STATUS=" & Update.Dao.ToSql(Nothing,FieldType._Boolean) & ","
        Else
        valuesList = valuesList & "STATUS=" & Update.Dao.ToSql(item.radioSTATUS.GetFormattedValue("1;0"),FieldType._Boolean) & ","
        End If
        End If
        allEmptyFlag = item.hidden_LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        If Not item.hidden_LAST_ALTERED_BY.IsEmpty Then
        If IsNothing(item.hidden_LAST_ALTERED_BY.Value) Then
        valuesList = valuesList & "LAST_ALTERED_BY=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "LAST_ALTERED_BY=" & Update.Dao.ToSql(item.hidden_LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.hidden_LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        If Not item.hidden_LAST_ALTERED_DATE.IsEmpty Then
        If IsNothing(item.hidden_LAST_ALTERED_DATE.Value) Then
        valuesList = valuesList & "LAST_ALTERED_DATE=" & Update.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        valuesList = valuesList & "LAST_ALTERED_DATE=" & Update.Dao.ToSql(item.hidden_LAST_ALTERED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
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
'End Record Assignment_maint BeforeBuildUpdate

'Record Assignment_maint AfterExecuteUpdate @3-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record Assignment_maint AfterExecuteUpdate

'Record Assignment_maint Data Provider Class GetResultSet Method @3-2174284E

    Public Sub FillItem(ByVal item As Assignment_maintItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record Assignment_maint Data Provider Class GetResultSet Method

'Record Assignment_maint BeforeBuildSelect @3-FF0F6F0E
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("SUBJECT_ID30",UrlSUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("ASSIGNMENT_ID31",UrlASSIGNMENT_ID, "","ASSIGNMENT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record Assignment_maint BeforeBuildSelect

'Record Assignment_maint BeforeExecuteSelect @3-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record Assignment_maint BeforeExecuteSelect

'Record Assignment_maint AfterExecuteSelect @3-9609A92D
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.txtASSIGNMENT_ID.SetValue(dr(i)("ASSIGNMENT_ID"),"")
            item.txtASSIGNMENT_DESCRIPTION.SetValue(dr(i)("DESCRIPTION"),"")
            item.radioSTATUS.SetValue(dr(i)("STATUS"),Select_.BoolFormat)
            item.lblLAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.lblLAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.hidden_SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
        Else
            IsInsertMode = True
        End If
'End Record Assignment_maint AfterExecuteSelect

'ListBox radioSTATUS AfterExecuteSelect @23-044FA8B3
        
item.radioSTATUSItems.Add("Yes","Active")
item.radioSTATUSItems.Add("No","Inactive")
'End ListBox radioSTATUS AfterExecuteSelect

'Record Assignment_maint AfterExecuteSelect tail @3-E31F8E2A
    End Sub
'End Record Assignment_maint AfterExecuteSelect tail

'Record Assignment_maint Data Provider Class @3-A61BA892
End Class

'End Record Assignment_maint Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

