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

Namespace DECV_PROD2007.SCHOOL_ADDRESS_maint 'Namespace @1-DE74577D

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

'Record SCHOOLADDRESS Item Class @3-22220C0E
Public Class SCHOOLADDRESSItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ADDRESSEE As TextField
    Public AGENT As TextField
    Public ADDR1 As TextField
    Public ADDR2 As TextField
    Public SUBURB_TOWN As TextField
    Public POSTCODE As TextField
    Public PHONE_A As TextField
    Public FAX As TextField
    Public EMAIL_ADDRESS As TextField
    Public EMAIL_ADDRESS2 As TextField
    Public LAST_ALTERED_BY As TextField
    Public lblSCHOOLNAME As TextField
    Public lblSCHOOLNO As TextField
    Public STATE As TextField
    Public COUNTRY As TextField
    Public PHONE_B As TextField
    Public LAST_ALTERED_DATE As DateField
    Public linkSchoolMaint As TextField
    Public linkSchoolMaintHref As Object
    Public linkSchoolMaintHrefParameters As LinkParameterCollection
    Public lblADDRESS_ID As TextField
    Public Hidden_LAST_ALTERED_BY As TextField
    Public Hidden_LAST_ALTERED_DATE As DateField
    Public lblDebug As TextField
    Public HiddenSCHOOLNO As TextField
    Public Sub New()
    ADDRESSEE = New TextField("", Nothing)
    AGENT = New TextField("", Nothing)
    ADDR1 = New TextField("", Nothing)
    ADDR2 = New TextField("", Nothing)
    SUBURB_TOWN = New TextField("", Nothing)
    POSTCODE = New TextField("", Nothing)
    PHONE_A = New TextField("", Nothing)
    FAX = New TextField("", Nothing)
    EMAIL_ADDRESS = New TextField("", Nothing)
    EMAIL_ADDRESS2 = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    lblSCHOOLNAME = New TextField("", Nothing)
    lblSCHOOLNO = New TextField("", Nothing)
    STATE = New TextField("", Nothing)
    COUNTRY = New TextField("", Nothing)
    PHONE_B = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    linkSchoolMaint = New TextField("",Nothing)
    linkSchoolMaintHrefParameters = New LinkParameterCollection()
    lblADDRESS_ID = New TextField("", Nothing)
    Hidden_LAST_ALTERED_BY = New TextField("", DBUtility.UserLogin)
    Hidden_LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    lblDebug = New TextField("", Nothing)
    HiddenSCHOOLNO = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As SCHOOLADDRESSItem
        Dim item As SCHOOLADDRESSItem = New SCHOOLADDRESSItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ADDRESSEE")) Then
        item.ADDRESSEE.SetValue(DBUtility.GetInitialValue("ADDRESSEE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("AGENT")) Then
        item.AGENT.SetValue(DBUtility.GetInitialValue("AGENT"))
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
        If Not IsNothing(DBUtility.GetInitialValue("PHONE_A")) Then
        item.PHONE_A.SetValue(DBUtility.GetInitialValue("PHONE_A"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FAX")) Then
        item.FAX.SetValue(DBUtility.GetInitialValue("FAX"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EMAIL_ADDRESS")) Then
        item.EMAIL_ADDRESS.SetValue(DBUtility.GetInitialValue("EMAIL_ADDRESS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EMAIL_ADDRESS2")) Then
        item.EMAIL_ADDRESS2.SetValue(DBUtility.GetInitialValue("EMAIL_ADDRESS2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblSCHOOLNAME")) Then
        item.lblSCHOOLNAME.SetValue(DBUtility.GetInitialValue("lblSCHOOLNAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblSCHOOLNO")) Then
        item.lblSCHOOLNO.SetValue(DBUtility.GetInitialValue("lblSCHOOLNO"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STATE")) Then
        item.STATE.SetValue(DBUtility.GetInitialValue("STATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COUNTRY")) Then
        item.COUNTRY.SetValue(DBUtility.GetInitialValue("COUNTRY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PHONE_B")) Then
        item.PHONE_B.SetValue(DBUtility.GetInitialValue("PHONE_B"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("linkSchoolMaint")) Then
        item.linkSchoolMaint.SetValue(DBUtility.GetInitialValue("linkSchoolMaint"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblADDRESS_ID")) Then
        item.lblADDRESS_ID.SetValue(DBUtility.GetInitialValue("lblADDRESS_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_LAST_ALTERED_BY")) Then
        item.Hidden_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("Hidden_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_LAST_ALTERED_DATE")) Then
        item.Hidden_LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("Hidden_LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblDebug")) Then
        item.lblDebug.SetValue(DBUtility.GetInitialValue("lblDebug"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("HiddenSCHOOLNO")) Then
        item.HiddenSCHOOLNO.SetValue(DBUtility.GetInitialValue("HiddenSCHOOLNO"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "ADDRESSEE"
                    Return ADDRESSEE
                Case "AGENT"
                    Return AGENT
                Case "ADDR1"
                    Return ADDR1
                Case "ADDR2"
                    Return ADDR2
                Case "SUBURB_TOWN"
                    Return SUBURB_TOWN
                Case "POSTCODE"
                    Return POSTCODE
                Case "PHONE_A"
                    Return PHONE_A
                Case "FAX"
                    Return FAX
                Case "EMAIL_ADDRESS"
                    Return EMAIL_ADDRESS
                Case "EMAIL_ADDRESS2"
                    Return EMAIL_ADDRESS2
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "lblSCHOOLNAME"
                    Return lblSCHOOLNAME
                Case "lblSCHOOLNO"
                    Return lblSCHOOLNO
                Case "STATE"
                    Return STATE
                Case "COUNTRY"
                    Return COUNTRY
                Case "PHONE_B"
                    Return PHONE_B
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "linkSchoolMaint"
                    Return linkSchoolMaint
                Case "lblADDRESS_ID"
                    Return lblADDRESS_ID
                Case "Hidden_LAST_ALTERED_BY"
                    Return Hidden_LAST_ALTERED_BY
                Case "Hidden_LAST_ALTERED_DATE"
                    Return Hidden_LAST_ALTERED_DATE
                Case "lblDebug"
                    Return lblDebug
                Case "HiddenSCHOOLNO"
                    Return HiddenSCHOOLNO
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ADDRESSEE"
                    ADDRESSEE = CType(value, TextField)
                Case "AGENT"
                    AGENT = CType(value, TextField)
                Case "ADDR1"
                    ADDR1 = CType(value, TextField)
                Case "ADDR2"
                    ADDR2 = CType(value, TextField)
                Case "SUBURB_TOWN"
                    SUBURB_TOWN = CType(value, TextField)
                Case "POSTCODE"
                    POSTCODE = CType(value, TextField)
                Case "PHONE_A"
                    PHONE_A = CType(value, TextField)
                Case "FAX"
                    FAX = CType(value, TextField)
                Case "EMAIL_ADDRESS"
                    EMAIL_ADDRESS = CType(value, TextField)
                Case "EMAIL_ADDRESS2"
                    EMAIL_ADDRESS2 = CType(value, TextField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "lblSCHOOLNAME"
                    lblSCHOOLNAME = CType(value, TextField)
                Case "lblSCHOOLNO"
                    lblSCHOOLNO = CType(value, TextField)
                Case "STATE"
                    STATE = CType(value, TextField)
                Case "COUNTRY"
                    COUNTRY = CType(value, TextField)
                Case "PHONE_B"
                    PHONE_B = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "linkSchoolMaint"
                    linkSchoolMaint = CType(value, TextField)
                Case "lblADDRESS_ID"
                    lblADDRESS_ID = CType(value, TextField)
                Case "Hidden_LAST_ALTERED_BY"
                    Hidden_LAST_ALTERED_BY = CType(value, TextField)
                Case "Hidden_LAST_ALTERED_DATE"
                    Hidden_LAST_ALTERED_DATE = CType(value, DateField)
                Case "lblDebug"
                    lblDebug = CType(value, TextField)
                Case "HiddenSCHOOLNO"
                    HiddenSCHOOLNO = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As SCHOOLADDRESSDataProvider)
'End Record SCHOOLADDRESS Item Class

'ADDRESSEE validate @10-7F77186C
        If IsNothing(ADDRESSEE.Value) OrElse ADDRESSEE.Value.ToString() ="" Then
            errors.Add("ADDRESSEE",String.Format(Resources.strings.CCS_RequiredField,"ADDRESSEE"))
        End If
'End ADDRESSEE validate

'SUBURB_TOWN validate @14-0E7720D2
        If IsNothing(SUBURB_TOWN.Value) OrElse SUBURB_TOWN.Value.ToString() ="" Then
            errors.Add("SUBURB_TOWN",String.Format(Resources.strings.CCS_RequiredField,"SUBURB TOWN"))
        End If
'End SUBURB_TOWN validate

'COUNTRY validate @17-F62B2621
        If IsNothing(COUNTRY.Value) OrElse COUNTRY.Value.ToString() ="" Then
            errors.Add("COUNTRY",String.Format(Resources.strings.CCS_RequiredField,"COUNTRY"))
        End If
'End COUNTRY validate

'Record SCHOOLADDRESS Item Class tail @3-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record SCHOOLADDRESS Item Class tail

'Record SCHOOLADDRESS Data Provider Class @3-927AFEFE
Public Class SCHOOLADDRESSDataProvider
Inherits RecordDataProviderBase
'End Record SCHOOLADDRESS Data Provider Class

'Record SCHOOLADDRESS Data Provider Class Variables @3-3A6997BB
    Public UrlADDRESS_ID As FloatParameter
    Protected item As SCHOOLADDRESSItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record SCHOOLADDRESS Data Provider Class Variables

'Record SCHOOLADDRESS Data Provider Class Constructor @3-84794689

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM ADDRESS {SQL_Where} {SQL_OrderBy}", New String(){"ADDRESS_ID48"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record SCHOOLADDRESS Data Provider Class Constructor

'Record SCHOOLADDRESS Data Provider Class LoadParams Method @3-A125F737

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlADDRESS_ID))
    End Function
'End Record SCHOOLADDRESS Data Provider Class LoadParams Method

'Record SCHOOLADDRESS Data Provider Class CheckUnique Method @3-61FE456D

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As SCHOOLADDRESSItem) As Boolean
        Return True
    End Function
'End Record SCHOOLADDRESS Data Provider Class CheckUnique Method

'Record SCHOOLADDRESS Data Provider Class PrepareInsert Method @3-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record SCHOOLADDRESS Data Provider Class PrepareInsert Method

'Record SCHOOLADDRESS Data Provider Class PrepareInsert Method tail @3-E31F8E2A
    End Sub
'End Record SCHOOLADDRESS Data Provider Class PrepareInsert Method tail

'Record SCHOOLADDRESS Data Provider Class Insert Method @3-02788591

    Public Function InsertItem(ByVal item As SCHOOLADDRESSItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO ADDRESS({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record SCHOOLADDRESS Data Provider Class Insert Method

'Record SCHOOLADDRESS Build insert @3-44FCFEF4
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.ADDRESSEE.IsEmpty Then
        allEmptyFlag = item.ADDRESSEE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ADDRESSEE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ADDRESSEE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.AGENT.IsEmpty Then
        allEmptyFlag = item.AGENT.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "AGENT,"
        valuesList = valuesList & Insert.Dao.ToSql(item.AGENT.GetFormattedValue(""),FieldType._Text) & ","
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
        If Not item.PHONE_A.IsEmpty Then
        allEmptyFlag = item.PHONE_A.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PHONE_A,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PHONE_A.GetFormattedValue(""),FieldType._Text) & ","
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
        If Not item.EMAIL_ADDRESS2.IsEmpty Then
        allEmptyFlag = item.EMAIL_ADDRESS2.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "EMAIL_ADDRESS2,"
        valuesList = valuesList & Insert.Dao.ToSql(item.EMAIL_ADDRESS2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STATE.IsEmpty Then
        allEmptyFlag = item.STATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STATE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.COUNTRY.IsEmpty Then
        allEmptyFlag = item.COUNTRY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "COUNTRY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.COUNTRY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PHONE_B.IsEmpty Then
        allEmptyFlag = item.PHONE_B.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PHONE_B,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PHONE_B.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.Hidden_LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.Hidden_LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_LAST_ALTERED_DATE.GetFormattedValue("yyyy-MM-dd HH\:mm\:ss"),FieldType._Date) & ","
        End If
        If Not item.HiddenSCHOOLNO.IsEmpty Then
        allEmptyFlag = item.HiddenSCHOOLNO.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "[Barcode],"
        valuesList = valuesList & Insert.Dao.ToSql(item.HiddenSCHOOLNO.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record SCHOOLADDRESS Build insert

'DEL      ' -------------------------
'DEL      '1/Aug/2018|EA| repurpose the Address ID lookup to actually work instead of finding maybe the last or off-by-one address id
'DEL      tmpMaxAddressID = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT SCOPE_IDENTITY()"))).Value, Int64)
'DEL      ' -------------------------


'DEL      ' -------------------------
'DEL  	' 19-Mar-2009|EA| after a new Address is entered then also go back and update the Address_ID in the School record    	             
'DEL  	' do an update if the SCHOOL_ID and ADDRESS_ID are valid
'DEL  	' 12-Aug-2018|EA| rejigged to a) work and b) not need so many moving variables
'DEL  	 Dim tmpSCHOOLID As String = ""
'DEL       tmpSCHOOLID=item.HiddenSCHOOLNO.Value
'DEL  	
'DEL  		if (tmpSCHOOLID <> "") then 
'DEL    			Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
'DEL  			Dim Sql As String = ""
'DEL   			If NewDao.NativeConnection.State <> ConnectionState.Open Then
'DEL  	            NewDao.NativeConnection.Open()
'DEL  	            NewDao.DateFormat = "mdy"
'DEL  	        End If
'DEL  			'Sql = "update SCHOOL set ADDRESS_ID ="& NewDao.ToSql(tmpMaxAddressID,FieldType._Integer) &" where ADDRESS_ID is null and SCHOOL_ID = " & NewDao.ToSql(tmpSCHOOLID,FieldType._Float) &" "
'DEL  			Sql = "update sch set sch.address_id = ad.address_id " & _
'DEL  				 "from school sch inner join address ad on sch.school_id = ad.barcode  " & _
'DEL  				 " and sch.address_id is null and ad.LAST_ALTERED_DATE >= dateadd(minute, -1, getdate()) "
'DEL  
'DEL  			NewDao.RunSql(Sql)
'DEL   	           
'DEL    			'debug
'DEL  			'ErrorFlag = True
'DEL          End If
'DEL      ' -------------------------


'Record SCHOOLADDRESS AfterExecuteInsert @3-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record SCHOOLADDRESS AfterExecuteInsert

'Record SCHOOLADDRESS Data Provider Class PrepareUpdate Method @3-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record SCHOOLADDRESS Data Provider Class PrepareUpdate Method

'Record SCHOOLADDRESS Data Provider Class PrepareUpdate Method tail @3-E31F8E2A
    End Sub
'End Record SCHOOLADDRESS Data Provider Class PrepareUpdate Method tail

'Record SCHOOLADDRESS Data Provider Class Update Method @3-24E6239F

    Public Function UpdateItem(ByVal item As SCHOOLADDRESSItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE ADDRESS SET {Values}", New String(){"ADDRESS_ID48"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record SCHOOLADDRESS Data Provider Class Update Method

'Record SCHOOLADDRESS BeforeBuildUpdate @3-EE126D5D
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("ADDRESS_ID48",UrlADDRESS_ID, "","ADDRESS_ID",Condition.Equal,False)
        If Not item.ADDRESSEE.IsEmpty Then
        allEmptyFlag = item.ADDRESSEE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ADDRESSEE=" + Update.Dao.ToSql(item.ADDRESSEE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.AGENT.IsEmpty Then
        allEmptyFlag = item.AGENT.IsEmpty And allEmptyFlag
        valuesList = valuesList & "AGENT=" + Update.Dao.ToSql(item.AGENT.GetFormattedValue(""),FieldType._Text) & ","
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
        If Not item.PHONE_A.IsEmpty Then
        allEmptyFlag = item.PHONE_A.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PHONE_A=" + Update.Dao.ToSql(item.PHONE_A.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.FAX.IsEmpty Then
        allEmptyFlag = item.FAX.IsEmpty And allEmptyFlag
        valuesList = valuesList & "FAX=" + Update.Dao.ToSql(item.FAX.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.EMAIL_ADDRESS.IsEmpty Then
        allEmptyFlag = item.EMAIL_ADDRESS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "EMAIL_ADDRESS=" + Update.Dao.ToSql(item.EMAIL_ADDRESS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.EMAIL_ADDRESS2.IsEmpty Then
        allEmptyFlag = item.EMAIL_ADDRESS2.IsEmpty And allEmptyFlag
        valuesList = valuesList & "EMAIL_ADDRESS2=" + Update.Dao.ToSql(item.EMAIL_ADDRESS2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STATE.IsEmpty Then
        allEmptyFlag = item.STATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STATE=" + Update.Dao.ToSql(item.STATE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.COUNTRY.IsEmpty Then
        allEmptyFlag = item.COUNTRY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "COUNTRY=" + Update.Dao.ToSql(item.COUNTRY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PHONE_B.IsEmpty Then
        allEmptyFlag = item.PHONE_B.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PHONE_B=" + Update.Dao.ToSql(item.PHONE_B.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.Hidden_LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.Hidden_LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.Hidden_LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.Hidden_LAST_ALTERED_DATE.GetFormattedValue("yyyy-MM-dd HH\:mm\:ss"),FieldType._Date) & ","
        End If
        If Not item.HiddenSCHOOLNO.IsEmpty Then
        allEmptyFlag = item.HiddenSCHOOLNO.IsEmpty And allEmptyFlag
        valuesList = valuesList & "[Barcode]=" + Update.Dao.ToSql(item.HiddenSCHOOLNO.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record SCHOOLADDRESS BeforeBuildUpdate

'Record SCHOOLADDRESS AfterExecuteUpdate @3-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record SCHOOLADDRESS AfterExecuteUpdate

'Record SCHOOLADDRESS Data Provider Class GetResultSet Method @3-8321A087

    Public Sub FillItem(ByVal item As SCHOOLADDRESSItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record SCHOOLADDRESS Data Provider Class GetResultSet Method

'Record SCHOOLADDRESS BeforeBuildSelect @3-8BF86630
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("ADDRESS_ID48",UrlADDRESS_ID, "","ADDRESS_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record SCHOOLADDRESS BeforeBuildSelect

'Record SCHOOLADDRESS BeforeExecuteSelect @3-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record SCHOOLADDRESS BeforeExecuteSelect

'Record SCHOOLADDRESS AfterExecuteSelect @3-11830AFB
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.ADDRESSEE.SetValue(dr(i)("ADDRESSEE"),"")
            item.AGENT.SetValue(dr(i)("AGENT"),"")
            item.ADDR1.SetValue(dr(i)("ADDR1"),"")
            item.ADDR2.SetValue(dr(i)("ADDR2"),"")
            item.SUBURB_TOWN.SetValue(dr(i)("SUBURB_TOWN"),"")
            item.POSTCODE.SetValue(dr(i)("POSTCODE"),"")
            item.PHONE_A.SetValue(dr(i)("PHONE_A"),"")
            item.FAX.SetValue(dr(i)("FAX"),"")
            item.EMAIL_ADDRESS.SetValue(dr(i)("EMAIL_ADDRESS"),"")
            item.EMAIL_ADDRESS2.SetValue(dr(i)("EMAIL_ADDRESS2"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.STATE.SetValue(dr(i)("STATE"),"")
            item.COUNTRY.SetValue(dr(i)("COUNTRY"),"")
            item.PHONE_B.SetValue(dr(i)("PHONE_B"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.linkSchoolMaintHref = "SCHOOL_maint.aspx"
            item.lblADDRESS_ID.SetValue(dr(i)("ADDRESS_ID"),"")
            item.Hidden_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.Hidden_LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),"yyyy-MM-dd HH\:mm\:ss")
            item.HiddenSCHOOLNO.SetValue(dr(i)("Barcode"),"")
        Else
            IsInsertMode = True
        End If
'End Record SCHOOLADDRESS AfterExecuteSelect

'Record SCHOOLADDRESS AfterExecuteSelect tail @3-E31F8E2A
    End Sub
'End Record SCHOOLADDRESS AfterExecuteSelect tail

'Record SCHOOLADDRESS Data Provider Class @3-A61BA892
End Class

'End Record SCHOOLADDRESS Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

