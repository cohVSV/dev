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

Namespace DECV_PROD2007.REGION_maint 'Namespace @1-104D6AEC

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

'Record REGION Item Class @2-907A3637
Public Class REGIONItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public REGION_NAME As TextField
    Public PHONE As TextField
    Public FAX As TextField
    Public EMAIL_ADDRESS As TextField
    Public ADDR1 As TextField
    Public ADDR2 As TextField
    Public SUBURB_TOWN As TextField
    Public POSTCODE As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public RadioButtonStatus As TextField
    Public RadioButtonStatusItems As ItemCollection
    Public PARENT_REGION_ID As IntegerField
    Public PARENT_REGION_IDItems As ItemCollection
    Public REGION_ID As IntegerField
    Public lblREGION_ID As TextField
    Public label_Last_altered_by As TextField
    Public label_last_altered_date As DateField
    Public Sub New()
    REGION_NAME = New TextField("", Nothing)
    PHONE = New TextField("", Nothing)
    FAX = New TextField("", Nothing)
    EMAIL_ADDRESS = New TextField("", Nothing)
    ADDR1 = New TextField("", Nothing)
    ADDR2 = New TextField("", Nothing)
    SUBURB_TOWN = New TextField("", Nothing)
    POSTCODE = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", DBUtility.UserID.tostring())
    LAST_ALTERED_DATE = New DateField("G", DateTime.Now)
    RadioButtonStatus = New TextField("", 0)
    RadioButtonStatusItems = New ItemCollection()
    PARENT_REGION_ID = New IntegerField("", 0)
    PARENT_REGION_IDItems = New ItemCollection()
    REGION_ID = New IntegerField("", Nothing)
    lblREGION_ID = New TextField("", Nothing)
    label_Last_altered_by = New TextField("", Nothing)
    label_last_altered_date = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As REGIONItem
        Dim item As REGIONItem = New REGIONItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("REGION_NAME")) Then
        item.REGION_NAME.SetValue(DBUtility.GetInitialValue("REGION_NAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PHONE")) Then
        item.PHONE.SetValue(DBUtility.GetInitialValue("PHONE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FAX")) Then
        item.FAX.SetValue(DBUtility.GetInitialValue("FAX"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EMAIL_ADDRESS")) Then
        item.EMAIL_ADDRESS.SetValue(DBUtility.GetInitialValue("EMAIL_ADDRESS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ADDR1")) Then
        item.ADDR1.SetValue(DBUtility.GetInitialValue("ADDR1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ADDR2")) Then
        item.ADDR2.SetValue(DBUtility.GetInitialValue("ADDR2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUBURB_TOWN")) Then
        item.SUBURB_TOWN.SetValue(DBUtility.GetInitialValue("SUBURB_TOWN"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("POSTCODE")) Then
        item.POSTCODE.SetValue(DBUtility.GetInitialValue("POSTCODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RadioButtonStatus")) Then
        item.RadioButtonStatus.SetValue(DBUtility.GetInitialValue("RadioButtonStatus"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PARENT_REGION_ID")) Then
        item.PARENT_REGION_ID.SetValue(DBUtility.GetInitialValue("PARENT_REGION_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("REGION_ID")) Then
        item.REGION_ID.SetValue(DBUtility.GetInitialValue("REGION_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblREGION_ID")) Then
        item.lblREGION_ID.SetValue(DBUtility.GetInitialValue("lblREGION_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("label_Last_altered_by")) Then
        item.label_Last_altered_by.SetValue(DBUtility.GetInitialValue("label_Last_altered_by"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("label_last_altered_date")) Then
        item.label_last_altered_date.SetValue(DBUtility.GetInitialValue("label_last_altered_date"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "REGION_NAME"
                    Return REGION_NAME
                Case "PHONE"
                    Return PHONE
                Case "FAX"
                    Return FAX
                Case "EMAIL_ADDRESS"
                    Return EMAIL_ADDRESS
                Case "ADDR1"
                    Return ADDR1
                Case "ADDR2"
                    Return ADDR2
                Case "SUBURB_TOWN"
                    Return SUBURB_TOWN
                Case "POSTCODE"
                    Return POSTCODE
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "RadioButtonStatus"
                    Return RadioButtonStatus
                Case "PARENT_REGION_ID"
                    Return PARENT_REGION_ID
                Case "REGION_ID"
                    Return REGION_ID
                Case "lblREGION_ID"
                    Return lblREGION_ID
                Case "label_Last_altered_by"
                    Return label_Last_altered_by
                Case "label_last_altered_date"
                    Return label_last_altered_date
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "REGION_NAME"
                    REGION_NAME = CType(value, TextField)
                Case "PHONE"
                    PHONE = CType(value, TextField)
                Case "FAX"
                    FAX = CType(value, TextField)
                Case "EMAIL_ADDRESS"
                    EMAIL_ADDRESS = CType(value, TextField)
                Case "ADDR1"
                    ADDR1 = CType(value, TextField)
                Case "ADDR2"
                    ADDR2 = CType(value, TextField)
                Case "SUBURB_TOWN"
                    SUBURB_TOWN = CType(value, TextField)
                Case "POSTCODE"
                    POSTCODE = CType(value, TextField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "RadioButtonStatus"
                    RadioButtonStatus = CType(value, TextField)
                Case "PARENT_REGION_ID"
                    PARENT_REGION_ID = CType(value, IntegerField)
                Case "REGION_ID"
                    REGION_ID = CType(value, IntegerField)
                Case "lblREGION_ID"
                    lblREGION_ID = CType(value, TextField)
                Case "label_Last_altered_by"
                    label_Last_altered_by = CType(value, TextField)
                Case "label_last_altered_date"
                    label_last_altered_date = CType(value, DateField)
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

    Public Sub Validate(ByVal provider As REGIONDataProvider)
'End Record REGION Item Class

'REGION_NAME validate @7-7D89B335
        If IsNothing(REGION_NAME.Value) OrElse REGION_NAME.Value.ToString() ="" Then
            errors.Add("REGION_NAME",String.Format(Resources.strings.CCS_RequiredField,"NAME"))
        End If
'End REGION_NAME validate

'PHONE validate @8-C6763E94
        If IsNothing(PHONE.Value) OrElse PHONE.Value.ToString() ="" Then
            errors.Add("PHONE",String.Format(Resources.strings.CCS_RequiredField,"PHONE"))
        End If
'End PHONE validate

'ADDR1 validate @11-9D7862EC
        If IsNothing(ADDR1.Value) OrElse ADDR1.Value.ToString() ="" Then
            errors.Add("ADDR1",String.Format(Resources.strings.CCS_RequiredField,"ADDR1"))
        End If
'End ADDR1 validate

'SUBURB_TOWN validate @13-0E7720D2
        If IsNothing(SUBURB_TOWN.Value) OrElse SUBURB_TOWN.Value.ToString() ="" Then
            errors.Add("SUBURB_TOWN",String.Format(Resources.strings.CCS_RequiredField,"SUBURB TOWN"))
        End If
'End SUBURB_TOWN validate

'LAST_ALTERED_BY validate @15-256A6854
        If IsNothing(LAST_ALTERED_BY.Value) OrElse LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End LAST_ALTERED_BY validate

'LAST_ALTERED_DATE validate @16-C5989D76
        If IsNothing(LAST_ALTERED_DATE.Value) OrElse LAST_ALTERED_DATE.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED DATE"))
        End If
'End LAST_ALTERED_DATE validate

'RadioButtonStatus validate @23-93390C16
        If IsNothing(RadioButtonStatus.Value) OrElse RadioButtonStatus.Value.ToString() ="" Then
            errors.Add("RadioButtonStatus",String.Format(Resources.strings.CCS_RequiredField,"STATUS"))
        End If
'End RadioButtonStatus validate

'PARENT_REGION_ID validate @24-2C2FE474
        If IsNothing(PARENT_REGION_ID.Value) OrElse PARENT_REGION_ID.Value.ToString() ="" Then
            errors.Add("PARENT_REGION_ID",String.Format(Resources.strings.CCS_RequiredField,"PARENT_REGION_ID"))
        End If
'End PARENT_REGION_ID validate

'REGION_ID validate @25-81A7D81C
        If IsNothing(REGION_ID.Value) OrElse REGION_ID.Value.ToString() ="" Then
            errors.Add("REGION_ID",String.Format(Resources.strings.CCS_RequiredField,"Region ID"))
        End If
        If (Not IsNothing(REGION_ID)) And (Not provider.CheckUnique("REGION_ID",Me)) Then
                errors.Add("REGION_ID", String.Format(Resources.strings.CCS_UniqueValue,"Region ID"))
        End If
'End REGION_ID validate

'Record REGION Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record REGION Item Class tail

'Record REGION Data Provider Class @2-0238E8C1
Public Class REGIONDataProvider
Inherits RecordDataProviderBase
'End Record REGION Data Provider Class

'Record REGION Data Provider Class Variables @2-13ECBB83
    Protected PARENT_REGION_IDDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM REGION {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Public UrlREGION_ID As FloatParameter
    Protected item As REGIONItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record REGION Data Provider Class Variables

'Record REGION Data Provider Class Constructor @2-DC9326BF

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM REGION {SQL_Where} {SQL_OrderBy}", New String(){"REGION_ID6"},Settings.connDECVPRODSQL2005DataAccessObject )
        Delete=new TableCommand("DELETE FROM REGION", New String(){"REGION_ID6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
        Select_.OrderBy=""
    End Sub
'End Record REGION Data Provider Class Constructor

'Record REGION Data Provider Class LoadParams Method @2-F9DB4F2A

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlREGION_ID))
    End Function
'End Record REGION Data Provider Class LoadParams Method

'Record REGION Data Provider Class CheckUnique Method @2-5DF004C1

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As REGIONItem) As Boolean
        Dim Check As TableCommand = New TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM REGION",New String(){"REGION_ID6"},Settings.connDECVPRODSQL2005DataAccessObject)
        Dim CheckWhere As String = ""
        Select Case ControlName
        Case "REGION_ID"
            CheckWhere = "REGION_ID=" & Check.Dao.ToSql(item.REGION_ID.GetFormattedValue(""),FieldType._Integer)
        End Select
        Check.Where = CheckWhere
        Check.Operation = "AND NOT"
        Check.Parameters.Clear()
        CType(Check,TableCommand).AddParameter("REGION_ID6",UrlREGION_ID, "","REGION_ID",Condition.Equal,False)
        If Convert.ToInt32(Check.ExecuteScalar()) > 0 Then
            Return False
        End If
        Return True
    End Function
'End Record REGION Data Provider Class CheckUnique Method

'Record REGION Data Provider Class PrepareInsert Method @2-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record REGION Data Provider Class PrepareInsert Method

'Record REGION Data Provider Class PrepareInsert Method tail @2-E31F8E2A
    End Sub
'End Record REGION Data Provider Class PrepareInsert Method tail

'Record REGION Data Provider Class Insert Method @2-59291710

    Public Function InsertItem(ByVal item As REGIONItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO REGION({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record REGION Data Provider Class Insert Method

'Record REGION Build insert @2-3E2591B6
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.REGION_NAME.IsEmpty Then
        allEmptyFlag = item.REGION_NAME.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "REGION_NAME,"
        valuesList = valuesList & Insert.Dao.ToSql(item.REGION_NAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PHONE.IsEmpty Then
        allEmptyFlag = item.PHONE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PHONE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PHONE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.FAX.IsEmpty Then
        allEmptyFlag = item.FAX.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "FAX,"
        valuesList = valuesList & Insert.Dao.ToSql(item.FAX.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.EMAIL_ADDRESS.IsEmpty Then
        allEmptyFlag = item.EMAIL_ADDRESS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "EMAIL_ADDRESS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.EMAIL_ADDRESS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ADDR1.IsEmpty Then
        allEmptyFlag = item.ADDR1.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ADDR1,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ADDR1.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ADDR2.IsEmpty Then
        allEmptyFlag = item.ADDR2.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ADDR2,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ADDR2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUBURB_TOWN.IsEmpty Then
        allEmptyFlag = item.SUBURB_TOWN.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUBURB_TOWN,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUBURB_TOWN.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.POSTCODE.IsEmpty Then
        allEmptyFlag = item.POSTCODE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "POSTCODE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.POSTCODE.GetFormattedValue(""),FieldType._Text) & ","
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
        If Not item.RadioButtonStatus.IsEmpty Then
        allEmptyFlag = item.RadioButtonStatus.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STATUS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.RadioButtonStatus.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PARENT_REGION_ID.IsEmpty Then
        allEmptyFlag = item.PARENT_REGION_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PARENT_REGION_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PARENT_REGION_ID.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.REGION_ID.IsEmpty Then
        allEmptyFlag = item.REGION_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "REGION_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.REGION_ID.GetFormattedValue(""),FieldType._Integer) & ","
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
'End Record REGION Build insert

'Record REGION AfterExecuteInsert @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record REGION AfterExecuteInsert

'Record REGION Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record REGION Data Provider Class PrepareUpdate Method

'Record REGION Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record REGION Data Provider Class PrepareUpdate Method tail

'Record REGION Data Provider Class Update Method @2-7608F23A

    Public Function UpdateItem(ByVal item As REGIONItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE REGION SET {Values}", New String(){"REGION_ID6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record REGION Data Provider Class Update Method

'Record REGION BeforeBuildUpdate @2-B608BB92
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("REGION_ID6",UrlREGION_ID, "","REGION_ID",Condition.Equal,False)
        If Not item.REGION_NAME.IsEmpty Then
        allEmptyFlag = item.REGION_NAME.IsEmpty And allEmptyFlag
        valuesList = valuesList & "REGION_NAME=" + Update.Dao.ToSql(item.REGION_NAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PHONE.IsEmpty Then
        allEmptyFlag = item.PHONE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PHONE=" + Update.Dao.ToSql(item.PHONE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.FAX.IsEmpty Then
        allEmptyFlag = item.FAX.IsEmpty And allEmptyFlag
        valuesList = valuesList & "FAX=" + Update.Dao.ToSql(item.FAX.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.EMAIL_ADDRESS.IsEmpty Then
        allEmptyFlag = item.EMAIL_ADDRESS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "EMAIL_ADDRESS=" + Update.Dao.ToSql(item.EMAIL_ADDRESS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ADDR1.IsEmpty Then
        allEmptyFlag = item.ADDR1.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ADDR1=" + Update.Dao.ToSql(item.ADDR1.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ADDR2.IsEmpty Then
        allEmptyFlag = item.ADDR2.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ADDR2=" + Update.Dao.ToSql(item.ADDR2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUBURB_TOWN.IsEmpty Then
        allEmptyFlag = item.SUBURB_TOWN.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUBURB_TOWN=" + Update.Dao.ToSql(item.SUBURB_TOWN.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.POSTCODE.IsEmpty Then
        allEmptyFlag = item.POSTCODE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "POSTCODE=" + Update.Dao.ToSql(item.POSTCODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.RadioButtonStatus.IsEmpty Then
        allEmptyFlag = item.RadioButtonStatus.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STATUS=" + Update.Dao.ToSql(item.RadioButtonStatus.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PARENT_REGION_ID.IsEmpty Then
        allEmptyFlag = item.PARENT_REGION_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PARENT_REGION_ID=" + Update.Dao.ToSql(item.PARENT_REGION_ID.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.REGION_ID.IsEmpty Then
        allEmptyFlag = item.REGION_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "REGION_ID=" + Update.Dao.ToSql(item.REGION_ID.GetFormattedValue(""),FieldType._Integer) & ","
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
'End Record REGION BeforeBuildUpdate

'Record REGION AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record REGION AfterExecuteUpdate

'Record REGION Data Provider Class PrepareDelete Method @2-F7361E57

    Protected Overrides Sub PrepareDelete()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record REGION Data Provider Class PrepareDelete Method

'Record REGION Data Provider Class PrepareDelete Method tail @2-E31F8E2A
    End Sub
'End Record REGION Data Provider Class PrepareDelete Method tail

'Record REGION Data Provider Class Delete Method @2-444FD34E
    Public Function DeleteItem(ByVal item As REGIONItem) As Integer
        Me.item = item
'End Record REGION Data Provider Class Delete Method

'Record REGION BeforeBuildDelete @2-D8CF762B
        Delete.Parameters.Clear()
        CType(Delete,TableCommand).AddParameter("REGION_ID6",UrlREGION_ID, "","REGION_ID",Condition.Equal,False)
        Delete.SqlQuery.Replace("{REGION_NAME}",Delete.Dao.ToSql(item.REGION_NAME.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{PHONE}",Delete.Dao.ToSql(item.PHONE.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{FAX}",Delete.Dao.ToSql(item.FAX.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{EMAIL_ADDRESS}",Delete.Dao.ToSql(item.EMAIL_ADDRESS.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{ADDR1}",Delete.Dao.ToSql(item.ADDR1.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{ADDR2}",Delete.Dao.ToSql(item.ADDR2.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{SUBURB_TOWN}",Delete.Dao.ToSql(item.SUBURB_TOWN.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{POSTCODE}",Delete.Dao.ToSql(item.POSTCODE.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{LAST_ALTERED_BY}",Delete.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{LAST_ALTERED_DATE}",Delete.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Delete.DateFormat),FieldType._Date))
        Delete.SqlQuery.Replace("{RadioButtonStatus}",Delete.Dao.ToSql(item.RadioButtonStatus.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{PARENT_REGION_ID}",Delete.Dao.ToSql(item.PARENT_REGION_ID.GetFormattedValue(""),FieldType._Integer))
        Delete.SqlQuery.Replace("{REGION_ID}",Delete.Dao.ToSql(item.REGION_ID.GetFormattedValue(""),FieldType._Integer))
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
'End Record REGION BeforeBuildDelete

'Record REGION BeforeBuildDelete @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record REGION BeforeBuildDelete

'Record REGION Data Provider Class GetResultSet Method @2-259D2829

    Public Sub FillItem(ByVal item As REGIONItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record REGION Data Provider Class GetResultSet Method

'Record REGION BeforeBuildSelect @2-42F71863
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("REGION_ID6",UrlREGION_ID, "","REGION_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record REGION BeforeBuildSelect

'Record REGION BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record REGION BeforeExecuteSelect

'Record REGION AfterExecuteSelect @2-59980DBA
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.REGION_NAME.SetValue(dr(i)("REGION_NAME"),"")
            item.PHONE.SetValue(dr(i)("PHONE"),"")
            item.FAX.SetValue(dr(i)("FAX"),"")
            item.EMAIL_ADDRESS.SetValue(dr(i)("EMAIL_ADDRESS"),"")
            item.ADDR1.SetValue(dr(i)("ADDR1"),"")
            item.ADDR2.SetValue(dr(i)("ADDR2"),"")
            item.SUBURB_TOWN.SetValue(dr(i)("SUBURB_TOWN"),"")
            item.POSTCODE.SetValue(dr(i)("POSTCODE"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.RadioButtonStatus.SetValue(dr(i)("STATUS"),"")
            item.PARENT_REGION_ID.SetValue(dr(i)("PARENT_REGION_ID"),"")
            item.REGION_ID.SetValue(dr(i)("REGION_ID"),"")
            item.lblREGION_ID.SetValue(dr(i)("REGION_ID"),"")
            item.label_Last_altered_by.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.label_last_altered_date.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record REGION AfterExecuteSelect

'ListBox RadioButtonStatus AfterExecuteSelect @23-EB23F6F6
        
item.RadioButtonStatusItems.Add("1","Active")
item.RadioButtonStatusItems.Add("0","Inactive")
'End ListBox RadioButtonStatus AfterExecuteSelect

'ListBox PARENT_REGION_ID Initialize Data Source @24-6798D72C
        PARENT_REGION_IDDataCommand.Dao._optimized = False
        Dim PARENT_REGION_IDtableIndex As Integer = 0
        PARENT_REGION_IDDataCommand.OrderBy = ""
        PARENT_REGION_IDDataCommand.Parameters.Clear()
'End ListBox PARENT_REGION_ID Initialize Data Source

'ListBox PARENT_REGION_ID BeforeExecuteSelect @24-2E272E8D
        Try
            ListBoxSource=PARENT_REGION_IDDataCommand.Execute().Tables(PARENT_REGION_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox PARENT_REGION_ID BeforeExecuteSelect

'ListBox PARENT_REGION_ID AfterExecuteSelect @24-F40602D5
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New IntegerField("", ListBoxSource(j)("REGION_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("REGION_NAME")
            item.PARENT_REGION_IDItems.Add(Key, Val)
        Next
'End ListBox PARENT_REGION_ID AfterExecuteSelect

'Record REGION AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record REGION AfterExecuteSelect tail

'Record REGION Data Provider Class @2-A61BA892
End Class

'End Record REGION Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

