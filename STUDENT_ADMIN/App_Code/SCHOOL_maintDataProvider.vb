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

Namespace DECV_PROD2007.SCHOOL_maint 'Namespace @1-76D3DFEE

'Page Data Class @1-2CF8692B
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public linkSchoolList As TextField
    Public linkSchoolListHref As Object
    Public linkSchoolListHrefParameters As LinkParameterCollection
    Public Sub New()
        linkSchoolList = New TextField("",Nothing)
        linkSchoolListHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.linkSchoolList.SetValue(DBUtility.GetInitialValue("linkSchoolList"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "linkSchoolList"
                    Return linkSchoolList
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "linkSchoolList"
                    linkSchoolList = CType(value, TextField)
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

'Record SCHOOL Item Class @2-46A20D5D
Public Class SCHOOLItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public SCHOOL_NAME As TextField
    Public REGION_ID As FloatField
    Public REGION_IDItems As ItemCollection
    Public SCHOOL_TYPE_CODE As TextField
    Public SCHOOL_TYPE_CODEItems As ItemCollection
    Public PRINCIPAL As TextField
    Public VBOSNUMBER As FloatField
    Public METRO_CATEGORY As IntegerField
    Public METRO_CATEGORYItems As ItemCollection
    Public STATUS As BooleanField
    Public STATUSCheckedValue As BooleanField
    Public STATUSUncheckedValue As BooleanField
    Public ADDRESS_ID As FloatField
    Public ADDRESS_IDHref As Object
    Public ADDRESS_IDHrefParameters As LinkParameterCollection
    Public SCHOOL_ID As TextField
    Public lbl_SaveBeforeAddress As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public lbl_LAST_ALTERED_BY As TextField
    Public lbl_LAST_ALTERED_DATE As DateField
    Public SchoolID_view As FloatField
    Public Hidden_address_id As TextField
    Public lblAddressID As TextField
    Public lblDebug As TextField
    Public Sub New()
    SCHOOL_NAME = New TextField("", Nothing)
    REGION_ID = New FloatField("", Nothing)
    REGION_IDItems = New ItemCollection()
    SCHOOL_TYPE_CODE = New TextField("", Nothing)
    SCHOOL_TYPE_CODEItems = New ItemCollection()
    PRINCIPAL = New TextField("", Nothing)
    VBOSNUMBER = New FloatField("", Nothing)
    METRO_CATEGORY = New IntegerField("", 1)
    METRO_CATEGORYItems = New ItemCollection()
    STATUS = New BooleanField(Settings.BoolFormat, False)
    STATUSCheckedValue = New BooleanField(Settings.BoolFormat, True)
    STATUSUncheckedValue = New BooleanField(Settings.BoolFormat, False)
    ADDRESS_ID = New FloatField("",Nothing)
    ADDRESS_IDHrefParameters = New LinkParameterCollection()
    SCHOOL_ID = New TextField("", Nothing)
    lbl_SaveBeforeAddress = New TextField("", "<em>Add the School first, then Edit to add address.</em>")
    LAST_ALTERED_BY = New TextField("", DBUtility.UserLogin)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    lbl_LAST_ALTERED_BY = New TextField("", ucase(DBUtility.UserLogin))
    lbl_LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    SchoolID_view = New FloatField("0.00", Nothing)
    Hidden_address_id = New TextField("", Nothing)
    lblAddressID = New TextField("", Nothing)
    lblDebug = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As SCHOOLItem
        Dim item As SCHOOLItem = New SCHOOLItem()
        If Not IsNothing(DBUtility.GetInitialValue("SCHOOL_NAME")) Then
        item.SCHOOL_NAME.SetValue(DBUtility.GetInitialValue("SCHOOL_NAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("REGION_ID")) Then
        item.REGION_ID.SetValue(DBUtility.GetInitialValue("REGION_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SCHOOL_TYPE_CODE")) Then
        item.SCHOOL_TYPE_CODE.SetValue(DBUtility.GetInitialValue("SCHOOL_TYPE_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PRINCIPAL")) Then
        item.PRINCIPAL.SetValue(DBUtility.GetInitialValue("PRINCIPAL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("VBOSNUMBER")) Then
        item.VBOSNUMBER.SetValue(DBUtility.GetInitialValue("VBOSNUMBER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("METRO_CATEGORY")) Then
        item.METRO_CATEGORY.SetValue(DBUtility.GetInitialValue("METRO_CATEGORY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STATUS")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("STATUS")) Then
            item.STATUS.Value = item.STATUSCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ADDRESS_ID")) Then
        item.ADDRESS_ID.SetValue(DBUtility.GetInitialValue("ADDRESS_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SCHOOL_ID")) Then
        item.SCHOOL_ID.SetValue(DBUtility.GetInitialValue("SCHOOL_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbl_SaveBeforeAddress")) Then
        item.lbl_SaveBeforeAddress.SetValue(DBUtility.GetInitialValue("lbl_SaveBeforeAddress"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbl_LAST_ALTERED_BY")) Then
        item.lbl_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("lbl_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbl_LAST_ALTERED_DATE")) Then
        item.lbl_LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("lbl_LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SchoolID_view")) Then
        item.SchoolID_view.SetValue(DBUtility.GetInitialValue("SchoolID_view"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_address_id")) Then
        item.Hidden_address_id.SetValue(DBUtility.GetInitialValue("Hidden_address_id"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblAddressID")) Then
        item.lblAddressID.SetValue(DBUtility.GetInitialValue("lblAddressID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblDebug")) Then
        item.lblDebug.SetValue(DBUtility.GetInitialValue("lblDebug"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "SCHOOL_NAME"
                    Return SCHOOL_NAME
                Case "REGION_ID"
                    Return REGION_ID
                Case "SCHOOL_TYPE_CODE"
                    Return SCHOOL_TYPE_CODE
                Case "PRINCIPAL"
                    Return PRINCIPAL
                Case "VBOSNUMBER"
                    Return VBOSNUMBER
                Case "METRO_CATEGORY"
                    Return METRO_CATEGORY
                Case "STATUS"
                    Return STATUS
                Case "ADDRESS_ID"
                    Return ADDRESS_ID
                Case "SCHOOL_ID"
                    Return SCHOOL_ID
                Case "lbl_SaveBeforeAddress"
                    Return lbl_SaveBeforeAddress
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "lbl_LAST_ALTERED_BY"
                    Return lbl_LAST_ALTERED_BY
                Case "lbl_LAST_ALTERED_DATE"
                    Return lbl_LAST_ALTERED_DATE
                Case "SchoolID_view"
                    Return SchoolID_view
                Case "Hidden_address_id"
                    Return Hidden_address_id
                Case "lblAddressID"
                    Return lblAddressID
                Case "lblDebug"
                    Return lblDebug
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SCHOOL_NAME"
                    SCHOOL_NAME = CType(value, TextField)
                Case "REGION_ID"
                    REGION_ID = CType(value, FloatField)
                Case "SCHOOL_TYPE_CODE"
                    SCHOOL_TYPE_CODE = CType(value, TextField)
                Case "PRINCIPAL"
                    PRINCIPAL = CType(value, TextField)
                Case "VBOSNUMBER"
                    VBOSNUMBER = CType(value, FloatField)
                Case "METRO_CATEGORY"
                    METRO_CATEGORY = CType(value, IntegerField)
                Case "STATUS"
                    STATUS = CType(value, BooleanField)
                Case "ADDRESS_ID"
                    ADDRESS_ID = CType(value, FloatField)
                Case "SCHOOL_ID"
                    SCHOOL_ID = CType(value, TextField)
                Case "lbl_SaveBeforeAddress"
                    lbl_SaveBeforeAddress = CType(value, TextField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "lbl_LAST_ALTERED_BY"
                    lbl_LAST_ALTERED_BY = CType(value, TextField)
                Case "lbl_LAST_ALTERED_DATE"
                    lbl_LAST_ALTERED_DATE = CType(value, DateField)
                Case "SchoolID_view"
                    SchoolID_view = CType(value, FloatField)
                Case "Hidden_address_id"
                    Hidden_address_id = CType(value, TextField)
                Case "lblAddressID"
                    lblAddressID = CType(value, TextField)
                Case "lblDebug"
                    lblDebug = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As SCHOOLDataProvider)
'End Record SCHOOL Item Class

'SCHOOL_NAME validate @11-2855CD8D
        If IsNothing(SCHOOL_NAME.Value) OrElse SCHOOL_NAME.Value.ToString() ="" Then
            errors.Add("SCHOOL_NAME",String.Format(Resources.strings.CCS_RequiredField,"SCHOOL NAME"))
        End If
'End SCHOOL_NAME validate

'SCHOOL_TYPE_CODE validate @8-8CF97C9B
        If IsNothing(SCHOOL_TYPE_CODE.Value) OrElse SCHOOL_TYPE_CODE.Value.ToString() ="" Then
            errors.Add("SCHOOL_TYPE_CODE",String.Format(Resources.strings.CCS_RequiredField,"SCHOOL TYPE"))
        End If
'End SCHOOL_TYPE_CODE validate

'METRO_CATEGORY validate @13-2950CE02
        If IsNothing(METRO_CATEGORY.Value) OrElse METRO_CATEGORY.Value.ToString() ="" Then
            errors.Add("METRO_CATEGORY",String.Format(Resources.strings.CCS_RequiredField,"METRO CATEGORY"))
        End If
'End METRO_CATEGORY validate

'STATUS validate @14-73C7378E
        If IsNothing(STATUS.Value) OrElse STATUS.Value.ToString() ="" Then
            errors.Add("STATUS",String.Format(Resources.strings.CCS_RequiredField,"STATUS"))
        End If
'End STATUS validate

'SCHOOL_ID validate @23-EA874EA9
        If IsNothing(SCHOOL_ID.Value) OrElse SCHOOL_ID.Value.ToString() ="" Then
            errors.Add("SCHOOL_ID",String.Format(Resources.strings.CCS_RequiredField,"SCHOOL ID"))
        End If
        If (Not IsNothing(SCHOOL_ID)) And (Not provider.CheckUnique("SCHOOL_ID",Me)) Then
                errors.Add("SCHOOL_ID", String.Format(Resources.strings.CCS_UniqueValue,"SCHOOL ID"))
        End If
'End SCHOOL_ID validate

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

'Record SCHOOL Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record SCHOOL Item Class tail

'Record SCHOOL Data Provider Class @2-8EFC3D7C
Public Class SCHOOLDataProvider
Inherits RecordDataProviderBase
'End Record SCHOOL Data Provider Class

'Record SCHOOL Data Provider Class Variables @2-34615198
    Protected REGION_IDDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM REGION {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected SCHOOL_TYPE_CODEDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM SCHOOL_TYPE {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Public UrlSCHOOL_ID As FloatParameter
    Public CtrlSCHOOL_ID As TextParameter
    Protected item As SCHOOLItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record SCHOOL Data Provider Class Variables

'Record SCHOOL Data Provider Class Constructor @2-F31E3071

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM SCHOOL {SQL_Where} {SQL_OrderBy}", New String(){"SCHOOL_ID6"},Settings.connDECVPRODSQL2005DataAccessObject )
        Delete=new SqlCommand("UPDATE SCHOOL set status=0 where status=1 and SCHOOL_ID='{school_id}'",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record SCHOOL Data Provider Class Constructor

'Record SCHOOL Data Provider Class LoadParams Method @2-2DB1C5D9

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSCHOOL_ID))
    End Function
'End Record SCHOOL Data Provider Class LoadParams Method

'Record SCHOOL Data Provider Class CheckUnique Method @2-113BC98D

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As SCHOOLItem) As Boolean
        Dim Check As TableCommand = New TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM SCHOOL",New String(){"SCHOOL_ID6"},Settings.connDECVPRODSQL2005DataAccessObject)
        Dim CheckWhere As String = ""
        Select Case ControlName
        Case "SCHOOL_ID"
            CheckWhere = "SCHOOL_ID=" & Check.Dao.ToSql(item.SCHOOL_ID.GetFormattedValue(""),FieldType._Text)
        End Select
        Check.Where = CheckWhere
        Check.Operation = "AND NOT"
        Check.Parameters.Clear()
        CType(Check,TableCommand).AddParameter("SCHOOL_ID6",UrlSCHOOL_ID, "","SCHOOL_ID",Condition.Equal,False)
        If Convert.ToInt32(Check.ExecuteScalar()) > 0 Then
            Return False
        End If
        Return True
    End Function
'End Record SCHOOL Data Provider Class CheckUnique Method

'Record SCHOOL Data Provider Class PrepareInsert Method @2-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record SCHOOL Data Provider Class PrepareInsert Method

'Record SCHOOL Data Provider Class PrepareInsert Method tail @2-E31F8E2A
    End Sub
'End Record SCHOOL Data Provider Class PrepareInsert Method tail

'Record SCHOOL Data Provider Class Insert Method @2-48344DA4

    Public Function InsertItem(ByVal item As SCHOOLItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO SCHOOL({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record SCHOOL Data Provider Class Insert Method

'Record SCHOOL Build insert @2-1E4E43DE
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.SCHOOL_NAME.IsEmpty Then
        allEmptyFlag = item.SCHOOL_NAME.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SCHOOL_NAME,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SCHOOL_NAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.REGION_ID.IsEmpty Then
        allEmptyFlag = item.REGION_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "REGION_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.REGION_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.SCHOOL_TYPE_CODE.IsEmpty Then
        allEmptyFlag = item.SCHOOL_TYPE_CODE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SCHOOL_TYPE_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SCHOOL_TYPE_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PRINCIPAL.IsEmpty Then
        allEmptyFlag = item.PRINCIPAL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PRINCIPAL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PRINCIPAL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.VBOSNUMBER.IsEmpty Then
        allEmptyFlag = item.VBOSNUMBER.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "VBOSNUMBER,"
        valuesList = valuesList & Insert.Dao.ToSql(item.VBOSNUMBER.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.METRO_CATEGORY.IsEmpty Then
        allEmptyFlag = item.METRO_CATEGORY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "METRO_CATEGORY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.METRO_CATEGORY.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STATUS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STATUS.GetFormattedValue(Insert.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.SCHOOL_ID.IsEmpty Then
        allEmptyFlag = item.SCHOOL_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SCHOOL_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SCHOOL_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue("yyyy-MM-dd HH\:mm\:ss"),FieldType._Date) & ","
        End If
        If Not item.Hidden_address_id.IsEmpty Then
        allEmptyFlag = item.Hidden_address_id.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ADDRESS_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_address_id.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record SCHOOL Build insert

'Record SCHOOL AfterExecuteInsert @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record SCHOOL AfterExecuteInsert

'Record SCHOOL Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record SCHOOL Data Provider Class PrepareUpdate Method

'Record SCHOOL Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record SCHOOL Data Provider Class PrepareUpdate Method tail

'Record SCHOOL Data Provider Class Update Method @2-B989D8FB

    Public Function UpdateItem(ByVal item As SCHOOLItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE SCHOOL SET {Values}", New String(){"SCHOOL_ID6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record SCHOOL Data Provider Class Update Method

'Record SCHOOL BeforeBuildUpdate @2-B63A9CFC
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("SCHOOL_ID6",UrlSCHOOL_ID, "","SCHOOL_ID",Condition.Equal,False)
        If Not item.SCHOOL_NAME.IsEmpty Then
        allEmptyFlag = item.SCHOOL_NAME.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SCHOOL_NAME=" + Update.Dao.ToSql(item.SCHOOL_NAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.REGION_ID.IsEmpty Then
        allEmptyFlag = item.REGION_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "REGION_ID=" + Update.Dao.ToSql(item.REGION_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.SCHOOL_TYPE_CODE.IsEmpty Then
        allEmptyFlag = item.SCHOOL_TYPE_CODE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SCHOOL_TYPE_CODE=" + Update.Dao.ToSql(item.SCHOOL_TYPE_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PRINCIPAL.IsEmpty Then
        allEmptyFlag = item.PRINCIPAL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PRINCIPAL=" + Update.Dao.ToSql(item.PRINCIPAL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.VBOSNUMBER.IsEmpty Then
        allEmptyFlag = item.VBOSNUMBER.IsEmpty And allEmptyFlag
        valuesList = valuesList & "VBOSNUMBER=" + Update.Dao.ToSql(item.VBOSNUMBER.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.METRO_CATEGORY.IsEmpty Then
        allEmptyFlag = item.METRO_CATEGORY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "METRO_CATEGORY=" + Update.Dao.ToSql(item.METRO_CATEGORY.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STATUS=" + Update.Dao.ToSql(item.STATUS.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.SCHOOL_ID.IsEmpty Then
        allEmptyFlag = item.SCHOOL_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SCHOOL_ID=" + Update.Dao.ToSql(item.SCHOOL_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue("yyyy-MM-dd HH\:mm\:ss"),FieldType._Date) & ","
        End If
        If Not item.Hidden_address_id.IsEmpty Then
        allEmptyFlag = item.Hidden_address_id.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ADDRESS_ID=" + Update.Dao.ToSql(item.Hidden_address_id.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record SCHOOL BeforeBuildUpdate

'Record SCHOOL AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record SCHOOL AfterExecuteUpdate

'Record SCHOOL Data Provider Class PrepareDelete Method @2-3CDFF327

    Protected Overrides Sub PrepareDelete()
        CmdExecution = True
'End Record SCHOOL Data Provider Class PrepareDelete Method

'Record SCHOOL Data Provider Class PrepareDelete Method tail @2-E31F8E2A
    End Sub
'End Record SCHOOL Data Provider Class PrepareDelete Method tail

'Record SCHOOL Data Provider Class Delete Method @2-52E8F520
    Public Function DeleteItem(ByVal item As SCHOOLItem) As Integer
        Me.item = item
'End Record SCHOOL Data Provider Class Delete Method

'Record SCHOOL BeforeBuildDelete @2-CF4B4653
        Delete.Parameters.Clear()
        CType(Delete,SqlCommand).AddParameter("school_id",item.SCHOOL_ID, "")
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
'End Record SCHOOL BeforeBuildDelete

'Record SCHOOL BeforeBuildDelete @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record SCHOOL BeforeBuildDelete

'Record SCHOOL Data Provider Class GetResultSet Method @2-AAD3A055

    Public Sub FillItem(ByVal item As SCHOOLItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record SCHOOL Data Provider Class GetResultSet Method

'Record SCHOOL BeforeBuildSelect @2-C2E1B007
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("SCHOOL_ID6",UrlSCHOOL_ID, "","SCHOOL_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record SCHOOL BeforeBuildSelect

'Record SCHOOL BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record SCHOOL BeforeExecuteSelect

'Record SCHOOL AfterExecuteSelect @2-5043D09F
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.SCHOOL_NAME.SetValue(dr(i)("SCHOOL_NAME"),"")
            item.REGION_ID.SetValue(dr(i)("REGION_ID"),"")
            item.SCHOOL_TYPE_CODE.SetValue(dr(i)("SCHOOL_TYPE_CODE"),"")
            item.PRINCIPAL.SetValue(dr(i)("PRINCIPAL"),"")
            item.VBOSNUMBER.SetValue(dr(i)("VBOSNUMBER"),"")
            item.METRO_CATEGORY.SetValue(dr(i)("METRO_CATEGORY"),"")
            item.STATUS.SetValue(dr(i)("STATUS"),Select_.BoolFormat)
            item.ADDRESS_IDHref = "SCHOOL_ADDRESS_maint.aspx"
            item.ADDRESS_IDHrefParameters.Add("ADDRESS_ID",System.Web.HttpUtility.UrlEncode(dr(i)("ADDRESS_ID").ToString()))
            item.ADDRESS_IDHrefParameters.Add("SCHOOL_ID",System.Web.HttpUtility.UrlEncode(dr(i)("SCHOOL_ID").ToString()))
            item.SCHOOL_ID.SetValue(dr(i)("SCHOOL_ID"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),"yyyy-MM-dd HH\:mm\:ss")
            item.lbl_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.lbl_LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.SchoolID_view.SetValue(dr(i)("SCHOOL_ID"),"")
            item.Hidden_address_id.SetValue(dr(i)("ADDRESS_ID"),"")
            item.lblAddressID.SetValue(dr(i)("ADDRESS_ID"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record SCHOOL AfterExecuteSelect

'ListBox REGION_ID Initialize Data Source @7-11B82D28
        REGION_IDDataCommand.Dao._optimized = False
        Dim REGION_IDtableIndex As Integer = 0
        REGION_IDDataCommand.OrderBy = ""
        REGION_IDDataCommand.Parameters.Clear()
'End ListBox REGION_ID Initialize Data Source

'ListBox REGION_ID BeforeExecuteSelect @7-5F2DEF81
        Try
            ListBoxSource=REGION_IDDataCommand.Execute().Tables(REGION_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox REGION_ID BeforeExecuteSelect

'ListBox REGION_ID AfterExecuteSelect @7-8320F035
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New FloatField("", ListBoxSource(j)("REGION_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("REGION_NAME")
            item.REGION_IDItems.Add(Key, Val)
        Next
'End ListBox REGION_ID AfterExecuteSelect

'ListBox SCHOOL_TYPE_CODE Initialize Data Source @8-D60251C7
        SCHOOL_TYPE_CODEDataCommand.Dao._optimized = False
        Dim SCHOOL_TYPE_CODEtableIndex As Integer = 0
        SCHOOL_TYPE_CODEDataCommand.OrderBy = ""
        SCHOOL_TYPE_CODEDataCommand.Parameters.Clear()
'End ListBox SCHOOL_TYPE_CODE Initialize Data Source

'ListBox SCHOOL_TYPE_CODE BeforeExecuteSelect @8-7A43048D
        Try
            ListBoxSource=SCHOOL_TYPE_CODEDataCommand.Execute().Tables(SCHOOL_TYPE_CODEtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox SCHOOL_TYPE_CODE BeforeExecuteSelect

'ListBox SCHOOL_TYPE_CODE AfterExecuteSelect @8-FFC9830F
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("SCHOOL_TYPE_CODE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("SCHOOL_TYPE_DESCRIPTION")
            item.SCHOOL_TYPE_CODEItems.Add(Key, Val)
        Next
'End ListBox SCHOOL_TYPE_CODE AfterExecuteSelect

'ListBox METRO_CATEGORY AfterExecuteSelect @13-292BBF86
        
item.METRO_CATEGORYItems.Add("1","Metro")
item.METRO_CATEGORYItems.Add("0","Country")
'End ListBox METRO_CATEGORY AfterExecuteSelect

'Record SCHOOL AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record SCHOOL AfterExecuteSelect tail

'Record SCHOOL Data Provider Class @2-A61BA892
End Class

'End Record SCHOOL Data Provider Class

'Report ADDRESS_Postal Item Class @29-CEA15150
Public Class ADDRESS_PostalItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public ADDRESSEE As TextField
    Public AGENT As TextField
    Public ADDR1 As TextField
    Public ADDR2 As TextField
    Public SUBURB_TOWN As TextField
    Public STATE As TextField
    Public POSTCODE As TextField
    Public COUNTRY As TextField
    Public PHONE_A As TextField
    Public PHONE_B As TextField
    Public FAX As TextField
    Public EMAIL_ADDRESS As TextField
    Public EMAIL_ADDRESSHref As Object
    Public EMAIL_ADDRESSHrefParameters As LinkParameterCollection
    Public EMAIL_ADDRESS2 As TextField
    Public EMAIL_ADDRESS2Href As Object
    Public EMAIL_ADDRESS2HrefParameters As LinkParameterCollection
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public ADDRESS_ID As FloatField
    Public Sub New()
    ADDRESSEE = New TextField("", Nothing)
    AGENT = New TextField("", Nothing)
    ADDR1 = New TextField("", Nothing)
    ADDR2 = New TextField("", Nothing)
    SUBURB_TOWN = New TextField("", Nothing)
    STATE = New TextField("", Nothing)
    POSTCODE = New TextField("", Nothing)
    COUNTRY = New TextField("", Nothing)
    PHONE_A = New TextField("", Nothing)
    PHONE_B = New TextField("", Nothing)
    FAX = New TextField("", Nothing)
    EMAIL_ADDRESS = New TextField("",Nothing)
    EMAIL_ADDRESSHrefParameters = New LinkParameterCollection()
    EMAIL_ADDRESS2 = New TextField("",Nothing)
    EMAIL_ADDRESS2HrefParameters = New LinkParameterCollection()
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy H\:mm", Nothing)
    ADDRESS_ID = New FloatField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "ADDRESSEE"
                    Return Me.ADDRESSEE
                Case "AGENT"
                    Return Me.AGENT
                Case "ADDR1"
                    Return Me.ADDR1
                Case "ADDR2"
                    Return Me.ADDR2
                Case "SUBURB_TOWN"
                    Return Me.SUBURB_TOWN
                Case "STATE"
                    Return Me.STATE
                Case "POSTCODE"
                    Return Me.POSTCODE
                Case "COUNTRY"
                    Return Me.COUNTRY
                Case "PHONE_A"
                    Return Me.PHONE_A
                Case "PHONE_B"
                    Return Me.PHONE_B
                Case "FAX"
                    Return Me.FAX
                Case "EMAIL_ADDRESS"
                    Return Me.EMAIL_ADDRESS
                Case "EMAIL_ADDRESS2"
                    Return Me.EMAIL_ADDRESS2
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "ADDRESS_ID"
                    Return Me.ADDRESS_ID
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ADDRESSEE"
                    Me.ADDRESSEE = CType(Value,TextField)
                Case "AGENT"
                    Me.AGENT = CType(Value,TextField)
                Case "ADDR1"
                    Me.ADDR1 = CType(Value,TextField)
                Case "ADDR2"
                    Me.ADDR2 = CType(Value,TextField)
                Case "SUBURB_TOWN"
                    Me.SUBURB_TOWN = CType(Value,TextField)
                Case "STATE"
                    Me.STATE = CType(Value,TextField)
                Case "POSTCODE"
                    Me.POSTCODE = CType(Value,TextField)
                Case "COUNTRY"
                    Me.COUNTRY = CType(Value,TextField)
                Case "PHONE_A"
                    Me.PHONE_A = CType(Value,TextField)
                Case "PHONE_B"
                    Me.PHONE_B = CType(Value,TextField)
                Case "FAX"
                    Me.FAX = CType(Value,TextField)
                Case "EMAIL_ADDRESS"
                    Me.EMAIL_ADDRESS = CType(Value,TextField)
                Case "EMAIL_ADDRESS2"
                    Me.EMAIL_ADDRESS2 = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "ADDRESS_ID"
                    Me.ADDRESS_ID = CType(Value,FloatField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Report ADDRESS_Postal Item Class

'Report ADDRESS_Postal Data Provider Class Header @29-75A0F020
Public Class ADDRESS_PostalDataProvider
Inherits GridDataProviderBase
'End Report ADDRESS_Postal Data Provider Class Header

'Report ADDRESS_Postal Data Provider Class Variables @29-8422738A

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public Expr54  As FloatParameter
'End Report ADDRESS_Postal Data Provider Class Variables

'Report ADDRESS_Postal Data Provider Class GetResultSet Method @29-244CFCE2

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM ADDRESS {SQL_Where} {SQL_OrderBy}", New String(){"(","expr54",")"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Report ADDRESS_Postal Data Provider Class GetResultSet Method

'Report ADDRESS_Postal Data Provider Class GetResultSet Method @29-D5808DD3
    Public Function GetResultSet(ops As FormSupportedOperations) As ADDRESS_PostalItem()
'End Report ADDRESS_Postal Data Provider Class GetResultSet Method

'Before build Select @29-B24FE62D
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("expr54",Expr54, "","ADDRESS_ID",Condition.Equal,False)
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @29-D6E0CFE2
        Dim ds As DataSet = Nothing
        Dim result(-1) As ADDRESS_PostalItem
        If ops.AllowRead Then
            Try
                    ds=ExecuteSelect()
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @29-F13C0720
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New ADDRESS_PostalItem(dr.Count-1) {}
'End After execute Select

'After execute Select @29-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @29-57523BE8
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as ADDRESS_PostalItem = New ADDRESS_PostalItem()
                item.ADDRESSEE.SetValue(dr(i)("ADDRESSEE"),"")
                item.AGENT.SetValue(dr(i)("AGENT"),"")
                item.ADDR1.SetValue(dr(i)("ADDR1"),"")
                item.ADDR2.SetValue(dr(i)("ADDR2"),"")
                item.SUBURB_TOWN.SetValue(dr(i)("SUBURB_TOWN"),"")
                item.STATE.SetValue(dr(i)("STATE"),"")
                item.POSTCODE.SetValue(dr(i)("POSTCODE"),"")
                item.COUNTRY.SetValue(dr(i)("COUNTRY"),"")
                item.PHONE_A.SetValue(dr(i)("PHONE_A"),"")
                item.PHONE_B.SetValue(dr(i)("PHONE_B"),"")
                item.FAX.SetValue(dr(i)("FAX"),"")
                item.EMAIL_ADDRESS.SetValue(dr(i)("EMAIL_ADDRESS"),"")
                item.EMAIL_ADDRESSHref = dr(i)("EMAIL_ADDRESS")
                item.EMAIL_ADDRESS2.SetValue(dr(i)("EMAIL_ADDRESS2"),"")
                item.EMAIL_ADDRESS2Href = dr(i)("EMAIL_ADDRESS2")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.ADDRESS_ID.SetValue(dr(i)("ADDRESS_ID"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Return result 
    End Function
'End After execute Select tail

'Report Data Provider tail @29-A61BA892
End Class
'End Report Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

