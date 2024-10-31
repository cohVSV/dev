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

Namespace DECV_PROD2007.Student_Address_panels_maintain 'Namespace @1-9416EEF5

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

'Record ADDRESS2 Item Class @220-B7DCF10C
Public Class ADDRESS2Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ADDRESSEE As TextField
    Public AGENT As TextField
    Public ADDR1 As TextField
    Public ADDR2 As TextField
    Public SUBURB_TOWN As TextField
    Public PHONE_A As TextField
    Public FAX As TextField
    Public EMAIL_ADDRESS As TextField
    Public EMAIL_ADDRESSHref As Object
    Public EMAIL_ADDRESSHrefParameters As LinkParameterCollection
    Public EMAIL_ADDRESS2 As TextField
    Public EMAIL_ADDRESS2Href As Object
    Public EMAIL_ADDRESS2HrefParameters As LinkParameterCollection
    Public LAST_ALTERED_BY As TextField
    Public STATE As TextField
    Public POSTCODE As TextField
    Public COUNTRY As TextField
    Public PHONE_B As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Link_EditOrigSAC As TextField
    Public Link_EditOrigSACHref As Object
    Public Link_EditOrigSACHrefParameters As LinkParameterCollection
    Public lblAddressID As IntegerField
    Public Link_carer1 As TextField
    Public Link_carer1Href As Object
    Public Link_carer1HrefParameters As LinkParameterCollection
    Public Sub New()
    ADDRESSEE = New TextField("", Nothing)
    AGENT = New TextField("", Nothing)
    ADDR1 = New TextField("", Nothing)
    ADDR2 = New TextField("", Nothing)
    SUBURB_TOWN = New TextField("", Nothing)
    PHONE_A = New TextField("", Nothing)
    FAX = New TextField("", Nothing)
    EMAIL_ADDRESS = New TextField("",Nothing)
    EMAIL_ADDRESSHrefParameters = New LinkParameterCollection()
    EMAIL_ADDRESS2 = New TextField("",Nothing)
    EMAIL_ADDRESS2HrefParameters = New LinkParameterCollection()
    LAST_ALTERED_BY = New TextField("", Nothing)
    STATE = New TextField("", Nothing)
    POSTCODE = New TextField("", Nothing)
    COUNTRY = New TextField("", Nothing)
    PHONE_B = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    Link_EditOrigSAC = New TextField("",Nothing)
    Link_EditOrigSACHrefParameters = New LinkParameterCollection()
    lblAddressID = New IntegerField("", Nothing)
    Link_carer1 = New TextField("",Nothing)
    Link_carer1HrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As ADDRESS2Item
        Dim item As ADDRESS2Item = New ADDRESS2Item()
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
        If Not IsNothing(DBUtility.GetInitialValue("STATE")) Then
        item.STATE.SetValue(DBUtility.GetInitialValue("STATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("POSTCODE")) Then
        item.POSTCODE.SetValue(DBUtility.GetInitialValue("POSTCODE"))
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
        If Not IsNothing(DBUtility.GetInitialValue("Link_EditOrigSAC")) Then
        item.Link_EditOrigSAC.SetValue(DBUtility.GetInitialValue("Link_EditOrigSAC"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblAddressID")) Then
        item.lblAddressID.SetValue(DBUtility.GetInitialValue("lblAddressID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link_carer1")) Then
        item.Link_carer1.SetValue(DBUtility.GetInitialValue("Link_carer1"))
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
                Case "STATE"
                    Return STATE
                Case "POSTCODE"
                    Return POSTCODE
                Case "COUNTRY"
                    Return COUNTRY
                Case "PHONE_B"
                    Return PHONE_B
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "Link_EditOrigSAC"
                    Return Link_EditOrigSAC
                Case "lblAddressID"
                    Return lblAddressID
                Case "Link_carer1"
                    Return Link_carer1
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
                Case "STATE"
                    STATE = CType(value, TextField)
                Case "POSTCODE"
                    POSTCODE = CType(value, TextField)
                Case "COUNTRY"
                    COUNTRY = CType(value, TextField)
                Case "PHONE_B"
                    PHONE_B = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "Link_EditOrigSAC"
                    Link_EditOrigSAC = CType(value, TextField)
                Case "lblAddressID"
                    lblAddressID = CType(value, IntegerField)
                Case "Link_carer1"
                    Link_carer1 = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As ADDRESS2DataProvider)
'End Record ADDRESS2 Item Class

'Record ADDRESS2 Item Class tail @220-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record ADDRESS2 Item Class tail

'Record ADDRESS2 Data Provider Class @220-95A76BEB
Public Class ADDRESS2DataProvider
Inherits RecordDataProviderBase
'End Record ADDRESS2 Data Provider Class

'Record ADDRESS2 Data Provider Class Variables @220-AC3949F6
    Public Expr238 As FloatParameter
    Protected item As ADDRESS2Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record ADDRESS2 Data Provider Class Variables

'Record ADDRESS2 Data Provider Class Constructor @220-E18AF12E

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM ADDRESS {SQL_Where} {SQL_OrderBy}", New String(){"expr238"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record ADDRESS2 Data Provider Class Constructor

'Record ADDRESS2 Data Provider Class LoadParams Method @220-4C856732

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(Expr238))
    End Function
'End Record ADDRESS2 Data Provider Class LoadParams Method

'Record ADDRESS2 Data Provider Class CheckUnique Method @220-B3C4BBDF

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As ADDRESS2Item) As Boolean
        Return True
    End Function
'End Record ADDRESS2 Data Provider Class CheckUnique Method

'Record ADDRESS2 Data Provider Class GetResultSet Method @220-E3B0BA2B

    Public Sub FillItem(ByVal item As ADDRESS2Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record ADDRESS2 Data Provider Class GetResultSet Method

'Record ADDRESS2 BeforeBuildSelect @220-EBCD72D3
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("expr238",Expr238, "","ADDRESS_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record ADDRESS2 BeforeBuildSelect

'Record ADDRESS2 BeforeExecuteSelect @220-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record ADDRESS2 BeforeExecuteSelect

'Record ADDRESS2 AfterExecuteSelect @220-EFE6AB7D
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
            item.PHONE_A.SetValue(dr(i)("PHONE_A"),"")
            item.FAX.SetValue(dr(i)("FAX"),"")
            item.EMAIL_ADDRESS.SetValue(dr(i)("EMAIL_ADDRESS"),"")
            item.EMAIL_ADDRESSHref = dr(i)("EMAIL_ADDRESS")
            item.EMAIL_ADDRESS2.SetValue(dr(i)("EMAIL_ADDRESS2"),"")
            item.EMAIL_ADDRESS2Href = dr(i)("EMAIL_ADDRESS2")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.STATE.SetValue(dr(i)("STATE"),"")
            item.POSTCODE.SetValue(dr(i)("POSTCODE"),"")
            item.COUNTRY.SetValue(dr(i)("COUNTRY"),"")
            item.PHONE_B.SetValue(dr(i)("PHONE_B"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.Link_EditOrigSACHref = "Student_Address_panels_maintain.aspx"
            item.lblAddressID.SetValue(dr(i)("ADDRESS_ID"),"")
            item.Link_carer1Href = "Student_Carer_maintainext.aspx"
        Else
            IsInsertMode = True
        End If
'End Record ADDRESS2 AfterExecuteSelect

'Record ADDRESS2 AfterExecuteSelect tail @220-E31F8E2A
    End Sub
'End Record ADDRESS2 AfterExecuteSelect tail

'Record ADDRESS2 Data Provider Class @220-A61BA892
End Class

'End Record ADDRESS2 Data Provider Class

'Record EditAddress2 Item Class @241-48DE91E5
Public Class EditAddress2Item
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
    Public LAST_ALTERED_DATE As DateField
    Public STATE As TextField
    Public COUNTRY As TextField
    Public PHONE_B As TextField
    Public lblAddressID As IntegerField
    Public hidden_ADDRESS_ID As TextField
    Public Link_carer1 As TextField
    Public Link_carer1Href As Object
    Public Link_carer1HrefParameters As LinkParameterCollection
    Public Link_carer2 As TextField
    Public Link_carer2Href As Object
    Public Link_carer2HrefParameters As LinkParameterCollection
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
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    STATE = New TextField("", Nothing)
    COUNTRY = New TextField("", Nothing)
    PHONE_B = New TextField("", Nothing)
    lblAddressID = New IntegerField("", Nothing)
    hidden_ADDRESS_ID = New TextField("", Nothing)
    Link_carer1 = New TextField("",Nothing)
    Link_carer1HrefParameters = New LinkParameterCollection()
    Link_carer2 = New TextField("",Nothing)
    Link_carer2HrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As EditAddress2Item
        Dim item As EditAddress2Item = New EditAddress2Item()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
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
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
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
        If Not IsNothing(DBUtility.GetInitialValue("lblAddressID")) Then
        item.lblAddressID.SetValue(DBUtility.GetInitialValue("lblAddressID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_ADDRESS_ID")) Then
        item.hidden_ADDRESS_ID.SetValue(DBUtility.GetInitialValue("hidden_ADDRESS_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link_carer1")) Then
        item.Link_carer1.SetValue(DBUtility.GetInitialValue("Link_carer1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link_carer2")) Then
        item.Link_carer2.SetValue(DBUtility.GetInitialValue("Link_carer2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
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
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "STATE"
                    Return STATE
                Case "COUNTRY"
                    Return COUNTRY
                Case "PHONE_B"
                    Return PHONE_B
                Case "lblAddressID"
                    Return lblAddressID
                Case "hidden_ADDRESS_ID"
                    Return hidden_ADDRESS_ID
                Case "Link_carer1"
                    Return Link_carer1
                Case "Link_carer2"
                    Return Link_carer2
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
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "STATE"
                    STATE = CType(value, TextField)
                Case "COUNTRY"
                    COUNTRY = CType(value, TextField)
                Case "PHONE_B"
                    PHONE_B = CType(value, TextField)
                Case "lblAddressID"
                    lblAddressID = CType(value, IntegerField)
                Case "hidden_ADDRESS_ID"
                    hidden_ADDRESS_ID = CType(value, TextField)
                Case "Link_carer1"
                    Link_carer1 = CType(value, TextField)
                Case "Link_carer2"
                    Link_carer2 = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As EditAddress2DataProvider)
'End Record EditAddress2 Item Class

'Record EditAddress2 Event OnValidate. Action Custom Code @449-73254650
    ' -------------------------
    ' '2-Mar-2009|EA| to validate emails, trim off spaces first....
		'EMAIL_ADDRESS.Value = trim(EMAIL_ADDRESS.Value)
		'EMAIL_ADDRESS2.Value = trim(EMAIL_ADDRESS2.Value)
    ' -------------------------
'End Record EditAddress2 Event OnValidate. Action Custom Code

'Record EditAddress2 Event OnValidate. Action Validate Required Value @450-F6BBAA99
        If (ADDRESSEE.Value Is Nothing) OrElse ADDRESSEE.Value.ToString()="" Then
            errors.Add("ADDRESSEE",String.Format("The value in field ADDRESSEE is required.","EditAddress2"))
        End If
'End Record EditAddress2 Event OnValidate. Action Validate Required Value

'Record EditAddress2 Event OnValidate. Action Validate Required Value @451-C6AF379D
        If (SUBURB_TOWN.Value Is Nothing) OrElse SUBURB_TOWN.Value.ToString()="" Then
            errors.Add("SUBURB_TOWN",String.Format("The value in field EMAIL SUBURB / TOWN is required.","EditAddress2"))
        End If
'End Record EditAddress2 Event OnValidate. Action Validate Required Value

'Record EditAddress2 Event OnValidate. Action Validate Required Value @452-6A42E703
        If (COUNTRY.Value Is Nothing) OrElse COUNTRY.Value.ToString()="" Then
            errors.Add("COUNTRY",String.Format("The value in field COUNTRY is required","EditAddress2"))
        End If
'End Record EditAddress2 Event OnValidate. Action Validate Required Value

'Record EditAddress2 Item Class tail @241-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record EditAddress2 Item Class tail

'Record EditAddress2 Data Provider Class @241-7C228318
Public Class EditAddress2DataProvider
Inherits RecordDataProviderBase
'End Record EditAddress2 Data Provider Class

'Record EditAddress2 Data Provider Class Variables @241-33AC7B0D
    Public Expr261 As FloatParameter
    Public ExprKey434 As IntegerParameter
    Public ExprKey435 As IntegerParameter
    Public UrlRETURN_VALUE As IntegerParameter
    Public ExprKey447 As IntegerParameter
    Public ExprKey448 As IntegerParameter
    Public CtrlADDRESSEE As TextParameter
    Public CtrlAGENT As TextParameter
    Public CtrlADDR1 As TextParameter
    Public CtrlADDR2 As TextParameter
    Public CtrlSUBURB_TOWN As TextParameter
    Public CtrlPOSTCODE As TextParameter
    Public CtrlSTATE As TextParameter
    Public CtrlCOUNTRY As TextParameter
    Public CtrlPHONE_A As TextParameter
    Public CtrlPHONE_B As TextParameter
    Public CtrlFAX As TextParameter
    Public CtrlEMAIL_ADDRESS As TextParameter
    Public CtrlEMAIL_ADDRESS2 As TextParameter
    Public SesUserID As TextParameter
    Public UrlSTUDENT_ID As TextParameter
    Public Ctrlhidden_ADDRESS_ID As TextParameter
    Protected item As EditAddress2Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record EditAddress2 Data Provider Class Variables

'Record EditAddress2 Data Provider Class Constructor @241-45E37D88

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM ADDRESS {SQL_Where} {SQL_OrderBy}", New String(){"expr261"},Settings.connDECVPRODSQL2005DataAccessObject )
        Insert=new SpCommand("spu_UpdateStudentAddress_Originalpanel;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Update=new SpCommand("spu_UpdateStudentAddress_Originalpanel;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Delete=new SqlCommand("update STUDENT set orig_resid_address_id = NULL where STUDENT_ID = {urlSTUDENT_ID} and ori" & _
          "g_resid_address_id = {hidADDRESS_ID}",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record EditAddress2 Data Provider Class Constructor

'Record EditAddress2 Data Provider Class LoadParams Method @241-D15426F9

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(Expr261))
    End Function
'End Record EditAddress2 Data Provider Class LoadParams Method

'Record EditAddress2 Data Provider Class CheckUnique Method @241-62F2B2B9

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As EditAddress2Item) As Boolean
        Return True
    End Function
'End Record EditAddress2 Data Provider Class CheckUnique Method

'Record EditAddress2 Data Provider Class PrepareInsert Method @241-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record EditAddress2 Data Provider Class PrepareInsert Method

'Record EditAddress2 Data Provider Class PrepareInsert Method tail @241-E31F8E2A
    End Sub
'End Record EditAddress2 Data Provider Class PrepareInsert Method tail

'Record EditAddress2 Data Provider Class Insert Method @241-28B65D6D

    Public Function InsertItem(ByVal item As EditAddress2Item) As Integer
        Me.item = item
'End Record EditAddress2 Data Provider Class Insert Method

'Record EditAddress2 Build insert @241-BD93A875
        Insert.Parameters.Clear()
        CType(Insert,SpCommand).AddParameter("@RETURN_VALUE",UrlRETURN_VALUE,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Insert,SpCommand).AddParameter("@STUDENT_ID",UrlSTUDENT_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Insert,SpCommand).AddParameter("@this_ADDRESS_ID",item.hidden_ADDRESS_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Insert,SpCommand).AddParameter("@SCHOOL_ADDRESS_ID",ExprKey434,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Insert,SpCommand).AddParameter("@flag_same_as",ExprKey435,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Insert,SpCommand).AddParameter("@ADDRESSEE",item.ADDRESSEE,ParameterType._Char,ParameterDirection.Input,60,0,10)
        CType(Insert,SpCommand).AddParameter("@AGENT",item.AGENT,ParameterType._Char,ParameterDirection.Input,60,0,10)
        CType(Insert,SpCommand).AddParameter("@ADDR1",item.ADDR1,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Insert,SpCommand).AddParameter("@ADDR2",item.ADDR2,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Insert,SpCommand).AddParameter("@SUBURB_TOWN",item.SUBURB_TOWN,ParameterType._Char,ParameterDirection.Input,30,0,10)
        CType(Insert,SpCommand).AddParameter("@POSTCODE",item.POSTCODE,ParameterType._Char,ParameterDirection.Input,10,0,10)
        CType(Insert,SpCommand).AddParameter("@STATE",item.STATE,ParameterType._Char,ParameterDirection.Input,20,0,10)
        CType(Insert,SpCommand).AddParameter("@COUNTRY",item.COUNTRY,ParameterType._Char,ParameterDirection.Input,20,0,10)
        CType(Insert,SpCommand).AddParameter("@PHONE_A",item.PHONE_A,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Insert,SpCommand).AddParameter("@PHONE_B",item.PHONE_B,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Insert,SpCommand).AddParameter("@FAX",item.FAX,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Insert,SpCommand).AddParameter("@EMAIL_ADDRESS",item.EMAIL_ADDRESS,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Insert,SpCommand).AddParameter("@EMAIL_ADDRESS2",item.EMAIL_ADDRESS2,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Insert,SpCommand).AddParameter("@LAST_ALTERED_BY",SesUserID,ParameterType._Char,ParameterDirection.Input,8,0,10)
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
            result = ExecuteInsert()
            UrlRETURN_VALUE = IntegerParameter.GetParam(CType(Insert.Parameters("@RETURN_VALUE"),IDataParameter).Value)
        Catch ee As Exception
            E = ee
        Finally
'End Record EditAddress2 Build insert

'Record EditAddress2 AfterExecuteInsert @241-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record EditAddress2 AfterExecuteInsert

'Record EditAddress2 Data Provider Class PrepareUpdate Method @241-0A131024

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
'End Record EditAddress2 Data Provider Class PrepareUpdate Method

'Record EditAddress2 Data Provider Class PrepareUpdate Method tail @241-E31F8E2A
    End Sub
'End Record EditAddress2 Data Provider Class PrepareUpdate Method tail

'Record EditAddress2 Data Provider Class Update Method @241-2432C452

    Public Function UpdateItem(ByVal item As EditAddress2Item) As Integer
        Me.item = item
'End Record EditAddress2 Data Provider Class Update Method

'Record EditAddress2 BeforeBuildUpdate @241-CB9B4B94
        Update.Parameters.Clear()
        CType(Update,SpCommand).AddParameter("@RETURN_VALUE",UrlRETURN_VALUE,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Update,SpCommand).AddParameter("@STUDENT_ID",UrlSTUDENT_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@this_ADDRESS_ID",item.hidden_ADDRESS_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@SCHOOL_ADDRESS_ID",ExprKey447,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@flag_same_as",ExprKey448,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@ADDRESSEE",item.ADDRESSEE,ParameterType._Char,ParameterDirection.Input,60,0,10)
        CType(Update,SpCommand).AddParameter("@AGENT",item.AGENT,ParameterType._Char,ParameterDirection.Input,60,0,10)
        CType(Update,SpCommand).AddParameter("@ADDR1",item.ADDR1,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@ADDR2",item.ADDR2,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@SUBURB_TOWN",item.SUBURB_TOWN,ParameterType._Char,ParameterDirection.Input,30,0,10)
        CType(Update,SpCommand).AddParameter("@POSTCODE",item.POSTCODE,ParameterType._Char,ParameterDirection.Input,10,0,10)
        CType(Update,SpCommand).AddParameter("@STATE",item.STATE,ParameterType._Char,ParameterDirection.Input,20,0,10)
        CType(Update,SpCommand).AddParameter("@COUNTRY",item.COUNTRY,ParameterType._Char,ParameterDirection.Input,20,0,10)
        CType(Update,SpCommand).AddParameter("@PHONE_A",item.PHONE_A,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Update,SpCommand).AddParameter("@PHONE_B",item.PHONE_B,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Update,SpCommand).AddParameter("@FAX",item.FAX,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Update,SpCommand).AddParameter("@EMAIL_ADDRESS",item.EMAIL_ADDRESS,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@EMAIL_ADDRESS2",item.EMAIL_ADDRESS2,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@LAST_ALTERED_BY",SesUserID,ParameterType._Char,ParameterDirection.Input,8,0,10)
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
            result = ExecuteUpdate()
            UrlRETURN_VALUE = IntegerParameter.GetParam(CType(Update.Parameters("@RETURN_VALUE"),IDataParameter).Value)
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record EditAddress2 BeforeBuildUpdate

'Record EditAddress2 AfterExecuteUpdate @241-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record EditAddress2 AfterExecuteUpdate

'Record EditAddress2 Data Provider Class PrepareDelete Method @241-3CDFF327

    Protected Overrides Sub PrepareDelete()
        CmdExecution = True
'End Record EditAddress2 Data Provider Class PrepareDelete Method

'Record EditAddress2 Data Provider Class PrepareDelete Method tail @241-E31F8E2A
    End Sub
'End Record EditAddress2 Data Provider Class PrepareDelete Method tail

'Record EditAddress2 Data Provider Class Delete Method @241-99BAF10C
    Public Function DeleteItem(ByVal item As EditAddress2Item) As Integer
        Me.item = item
'End Record EditAddress2 Data Provider Class Delete Method

'Record EditAddress2 BeforeBuildDelete @241-CE192513
        Delete.Parameters.Clear()
        CType(Delete,SqlCommand).AddParameter("urlSTUDENT_ID",UrlSTUDENT_ID, "")
        CType(Delete,SqlCommand).AddParameter("hidADDRESS_ID",item.hidden_ADDRESS_ID, "")
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
'End Record EditAddress2 BeforeBuildDelete

'Record EditAddress2 BeforeBuildDelete @241-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record EditAddress2 BeforeBuildDelete

'Record EditAddress2 Data Provider Class GetResultSet Method @241-568A8FC3

    Public Sub FillItem(ByVal item As EditAddress2Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record EditAddress2 Data Provider Class GetResultSet Method

'Record EditAddress2 BeforeBuildSelect @241-16150FA7
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("expr261",Expr261, "","ADDRESS_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record EditAddress2 BeforeBuildSelect

'Record EditAddress2 BeforeExecuteSelect @241-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record EditAddress2 BeforeExecuteSelect

'Record EditAddress2 AfterExecuteSelect @241-3F9F5A85
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
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.STATE.SetValue(dr(i)("STATE"),"")
            item.COUNTRY.SetValue(dr(i)("COUNTRY"),"")
            item.PHONE_B.SetValue(dr(i)("PHONE_B"),"")
            item.lblAddressID.SetValue(dr(i)("ADDRESS_ID"),"")
            item.Link_carer1Href = "Student_Carer_maintainext.aspx"
            item.Link_carer2Href = "Student_Carer_maintainext.aspx"
        Else
            IsInsertMode = True
        End If
'End Record EditAddress2 AfterExecuteSelect

'Record EditAddress2 AfterExecuteSelect tail @241-E31F8E2A
    End Sub
'End Record EditAddress2 AfterExecuteSelect tail

'Record EditAddress2 Data Provider Class @241-A61BA892
End Class

'End Record EditAddress2 Data Provider Class

'Record ADDRESS Item Class @31-BB429351
Public Class ADDRESSItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ADDRESSEE As TextField
    Public AGENT As TextField
    Public ADDR1 As TextField
    Public ADDR2 As TextField
    Public SUBURB_TOWN As TextField
    Public PHONE_A As TextField
    Public FAX As TextField
    Public EMAIL_ADDRESS As TextField
    Public EMAIL_ADDRESSHref As Object
    Public EMAIL_ADDRESSHrefParameters As LinkParameterCollection
    Public EMAIL_ADDRESS2 As TextField
    Public EMAIL_ADDRESS2Href As Object
    Public EMAIL_ADDRESS2HrefParameters As LinkParameterCollection
    Public LAST_ALTERED_BY As TextField
    Public STATE As TextField
    Public POSTCODE As TextField
    Public COUNTRY As TextField
    Public PHONE_B As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Link_EditPostal As TextField
    Public Link_EditPostalHref As Object
    Public Link_EditPostalHrefParameters As LinkParameterCollection
    Public lblAddressID As IntegerField
    Public Link_carer1 As TextField
    Public Link_carer1Href As Object
    Public Link_carer1HrefParameters As LinkParameterCollection
    Public lblEmailType As TextField
    Public Sub New()
    ADDRESSEE = New TextField("", Nothing)
    AGENT = New TextField("", Nothing)
    ADDR1 = New TextField("", Nothing)
    ADDR2 = New TextField("", Nothing)
    SUBURB_TOWN = New TextField("", Nothing)
    PHONE_A = New TextField("", Nothing)
    FAX = New TextField("", Nothing)
    EMAIL_ADDRESS = New TextField("",Nothing)
    EMAIL_ADDRESSHrefParameters = New LinkParameterCollection()
    EMAIL_ADDRESS2 = New TextField("",Nothing)
    EMAIL_ADDRESS2HrefParameters = New LinkParameterCollection()
    LAST_ALTERED_BY = New TextField("", Nothing)
    STATE = New TextField("", Nothing)
    POSTCODE = New TextField("", Nothing)
    COUNTRY = New TextField("", Nothing)
    PHONE_B = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    Link_EditPostal = New TextField("",Nothing)
    Link_EditPostalHrefParameters = New LinkParameterCollection()
    lblAddressID = New IntegerField("", Nothing)
    Link_carer1 = New TextField("",Nothing)
    Link_carer1HrefParameters = New LinkParameterCollection()
    lblEmailType = New TextField("", "STUDENT")
    End Sub

    Public Shared Function CreateFromHttpRequest() As ADDRESSItem
        Dim item As ADDRESSItem = New ADDRESSItem()
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
        If Not IsNothing(DBUtility.GetInitialValue("STATE")) Then
        item.STATE.SetValue(DBUtility.GetInitialValue("STATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("POSTCODE")) Then
        item.POSTCODE.SetValue(DBUtility.GetInitialValue("POSTCODE"))
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
        If Not IsNothing(DBUtility.GetInitialValue("Link_EditPostal")) Then
        item.Link_EditPostal.SetValue(DBUtility.GetInitialValue("Link_EditPostal"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblAddressID")) Then
        item.lblAddressID.SetValue(DBUtility.GetInitialValue("lblAddressID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link_carer1")) Then
        item.Link_carer1.SetValue(DBUtility.GetInitialValue("Link_carer1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblEmailType")) Then
        item.lblEmailType.SetValue(DBUtility.GetInitialValue("lblEmailType"))
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
                Case "STATE"
                    Return STATE
                Case "POSTCODE"
                    Return POSTCODE
                Case "COUNTRY"
                    Return COUNTRY
                Case "PHONE_B"
                    Return PHONE_B
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "Link_EditPostal"
                    Return Link_EditPostal
                Case "lblAddressID"
                    Return lblAddressID
                Case "Link_carer1"
                    Return Link_carer1
                Case "lblEmailType"
                    Return lblEmailType
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
                Case "STATE"
                    STATE = CType(value, TextField)
                Case "POSTCODE"
                    POSTCODE = CType(value, TextField)
                Case "COUNTRY"
                    COUNTRY = CType(value, TextField)
                Case "PHONE_B"
                    PHONE_B = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "Link_EditPostal"
                    Link_EditPostal = CType(value, TextField)
                Case "lblAddressID"
                    lblAddressID = CType(value, IntegerField)
                Case "Link_carer1"
                    Link_carer1 = CType(value, TextField)
                Case "lblEmailType"
                    lblEmailType = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As ADDRESSDataProvider)
'End Record ADDRESS Item Class

'Record ADDRESS Item Class tail @31-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record ADDRESS Item Class tail

'Record ADDRESS Data Provider Class @31-EC27F426
Public Class ADDRESSDataProvider
Inherits RecordDataProviderBase
'End Record ADDRESS Data Provider Class

'Record ADDRESS Data Provider Class Variables @31-C0D34BC6
    Public Expr146 As FloatParameter
    Protected item As ADDRESSItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record ADDRESS Data Provider Class Variables

'Record ADDRESS Data Provider Class Constructor @31-69F82819

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM ADDRESS {SQL_Where} {SQL_OrderBy}", New String(){"expr146"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record ADDRESS Data Provider Class Constructor

'Record ADDRESS Data Provider Class LoadParams Method @31-35D7895A

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(Expr146))
    End Function
'End Record ADDRESS Data Provider Class LoadParams Method

'Record ADDRESS Data Provider Class CheckUnique Method @31-CDE9F5FE

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As ADDRESSItem) As Boolean
        Return True
    End Function
'End Record ADDRESS Data Provider Class CheckUnique Method

'Record ADDRESS Data Provider Class GetResultSet Method @31-93521980

    Public Sub FillItem(ByVal item As ADDRESSItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record ADDRESS Data Provider Class GetResultSet Method

'Record ADDRESS BeforeBuildSelect @31-9B49F8ED
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("expr146",Expr146, "","ADDRESS_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record ADDRESS BeforeBuildSelect

'Record ADDRESS BeforeExecuteSelect @31-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record ADDRESS BeforeExecuteSelect

'Record ADDRESS AfterExecuteSelect @31-9EDAAFF4
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
            item.PHONE_A.SetValue(dr(i)("PHONE_A"),"")
            item.FAX.SetValue(dr(i)("FAX"),"")
            item.EMAIL_ADDRESS.SetValue(dr(i)("EMAIL_ADDRESS"),"")
            item.EMAIL_ADDRESSHref = dr(i)("EMAIL_ADDRESS")
            item.EMAIL_ADDRESS2.SetValue(dr(i)("EMAIL_ADDRESS2"),"")
            item.EMAIL_ADDRESS2Href = dr(i)("EMAIL_ADDRESS2")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.STATE.SetValue(dr(i)("STATE"),"")
            item.POSTCODE.SetValue(dr(i)("POSTCODE"),"")
            item.COUNTRY.SetValue(dr(i)("COUNTRY"),"")
            item.PHONE_B.SetValue(dr(i)("PHONE_B"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.Link_EditPostalHref = "Student_Address_panels_maintain.aspx"
            item.lblAddressID.SetValue(dr(i)("ADDRESS_ID"),"")
            item.Link_carer1Href = "Student_Carer_maintainext.aspx"
        Else
            IsInsertMode = True
        End If
'End Record ADDRESS AfterExecuteSelect

'Record ADDRESS AfterExecuteSelect tail @31-E31F8E2A
    End Sub
'End Record ADDRESS AfterExecuteSelect tail

'Record ADDRESS Data Provider Class @31-A61BA892
End Class

'End Record ADDRESS Data Provider Class

'Record EditAddress Item Class @10-97DDC69F
Public Class EditAddressItem
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
    Public LAST_ALTERED_DATE As DateField
    Public STATE As TextField
    Public COUNTRY As TextField
    Public PHONE_B As TextField
    Public lblAddressID As IntegerField
    Public cbox_same_as_school As IntegerField
    Public cbox_same_as_schoolCheckedValue As IntegerField
    Public cbox_same_as_schoolUncheckedValue As IntegerField
    Public hidden_SCHOOL_ADDRESS_ID As TextField
    Public hidden_flag_same_as As IntegerField
    Public Hidden_AddressHash As TextField
    Public Link_carer1 As TextField
    Public Link_carer1Href As Object
    Public Link_carer1HrefParameters As LinkParameterCollection
    Public hidden_ADDRESS_ID As TextField
    Public lblChangeAttendingSchool As TextField
    Public hidden_CURRENT_ADDRESS_ID As TextField
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
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    STATE = New TextField("", Nothing)
    COUNTRY = New TextField("", Nothing)
    PHONE_B = New TextField("", Nothing)
    lblAddressID = New IntegerField("", Nothing)
    cbox_same_as_school = New IntegerField("", 0)
    cbox_same_as_schoolCheckedValue = New IntegerField("", 1)
    cbox_same_as_schoolUncheckedValue = New IntegerField("", 0)
    hidden_SCHOOL_ADDRESS_ID = New TextField("", Nothing)
    hidden_flag_same_as = New IntegerField("", 0)
    Hidden_AddressHash = New TextField("", Nothing)
    Link_carer1 = New TextField("",Nothing)
    Link_carer1HrefParameters = New LinkParameterCollection()
    hidden_ADDRESS_ID = New TextField("", Nothing)
    lblChangeAttendingSchool = New TextField("", "After Change to School:")
    hidden_CURRENT_ADDRESS_ID = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As EditAddressItem
        Dim item As EditAddressItem = New EditAddressItem()
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
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
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
        If Not IsNothing(DBUtility.GetInitialValue("lblAddressID")) Then
        item.lblAddressID.SetValue(DBUtility.GetInitialValue("lblAddressID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("cbox_same_as_school")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("cbox_same_as_school")) Then
            item.cbox_same_as_school.Value = item.cbox_same_as_schoolCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_SCHOOL_ADDRESS_ID")) Then
        item.hidden_SCHOOL_ADDRESS_ID.SetValue(DBUtility.GetInitialValue("hidden_SCHOOL_ADDRESS_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_flag_same_as")) Then
        item.hidden_flag_same_as.SetValue(DBUtility.GetInitialValue("hidden_flag_same_as"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_AddressHash")) Then
        item.Hidden_AddressHash.SetValue(DBUtility.GetInitialValue("Hidden_AddressHash"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link_carer1")) Then
        item.Link_carer1.SetValue(DBUtility.GetInitialValue("Link_carer1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_ADDRESS_ID")) Then
        item.hidden_ADDRESS_ID.SetValue(DBUtility.GetInitialValue("hidden_ADDRESS_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblChangeAttendingSchool")) Then
        item.lblChangeAttendingSchool.SetValue(DBUtility.GetInitialValue("lblChangeAttendingSchool"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_CURRENT_ADDRESS_ID")) Then
        item.hidden_CURRENT_ADDRESS_ID.SetValue(DBUtility.GetInitialValue("hidden_CURRENT_ADDRESS_ID"))
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
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "STATE"
                    Return STATE
                Case "COUNTRY"
                    Return COUNTRY
                Case "PHONE_B"
                    Return PHONE_B
                Case "lblAddressID"
                    Return lblAddressID
                Case "cbox_same_as_school"
                    Return cbox_same_as_school
                Case "hidden_SCHOOL_ADDRESS_ID"
                    Return hidden_SCHOOL_ADDRESS_ID
                Case "hidden_flag_same_as"
                    Return hidden_flag_same_as
                Case "Hidden_AddressHash"
                    Return Hidden_AddressHash
                Case "Link_carer1"
                    Return Link_carer1
                Case "hidden_ADDRESS_ID"
                    Return hidden_ADDRESS_ID
                Case "lblChangeAttendingSchool"
                    Return lblChangeAttendingSchool
                Case "hidden_CURRENT_ADDRESS_ID"
                    Return hidden_CURRENT_ADDRESS_ID
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
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "STATE"
                    STATE = CType(value, TextField)
                Case "COUNTRY"
                    COUNTRY = CType(value, TextField)
                Case "PHONE_B"
                    PHONE_B = CType(value, TextField)
                Case "lblAddressID"
                    lblAddressID = CType(value, IntegerField)
                Case "cbox_same_as_school"
                    cbox_same_as_school = CType(value, IntegerField)
                Case "hidden_SCHOOL_ADDRESS_ID"
                    hidden_SCHOOL_ADDRESS_ID = CType(value, TextField)
                Case "hidden_flag_same_as"
                    hidden_flag_same_as = CType(value, IntegerField)
                Case "Hidden_AddressHash"
                    Hidden_AddressHash = CType(value, TextField)
                Case "Link_carer1"
                    Link_carer1 = CType(value, TextField)
                Case "hidden_ADDRESS_ID"
                    hidden_ADDRESS_ID = CType(value, TextField)
                Case "lblChangeAttendingSchool"
                    lblChangeAttendingSchool = CType(value, TextField)
                Case "hidden_CURRENT_ADDRESS_ID"
                    hidden_CURRENT_ADDRESS_ID = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As EditAddressDataProvider)
'End Record EditAddress Item Class

'Record EditAddress Event OnValidate. Action Custom Code @350-73254650
    ' -------------------------
    ' ERA: if checkbox same as school ticked then don't validate
	'if not (cbox_same_as_school.value.equals(cbox_same_as_schoolcheckedvalue.value)) then
	if (cbox_same_as_school.Value = (cbox_same_as_schooluncheckedvalue.Value))

		'2-Mar-2009|EA| to validate emails, trim off spaces first....
		' but then it doesn't always work as the trimmed spaces-only doesn't match 'nothing' so the validation fails even through it is blank
		'EMAIL_ADDRESS.Value = trim(EMAIL_ADDRESS.Value)
		'EMAIL_ADDRESS2.Value = trim(EMAIL_ADDRESS2.Value)
		
	'item.cbox_same_as_school.Value = (item.cbox_same_as_schoolCheckedValue.Value)
	'EditAddresscbox_same_as_school.Checked = True
    ' -------------------------
'End Record EditAddress Event OnValidate. Action Custom Code

'Record EditAddress Event OnValidate. Action Validate Required Value @347-FC7A46AC
        If (ADDRESSEE.Value Is Nothing) OrElse ADDRESSEE.Value.ToString()="" Then
            errors.Add("ADDRESSEE",String.Format("The value in field ADDRESSEE is required;","EditAddress"))
        End If
'End Record EditAddress Event OnValidate. Action Validate Required Value

'Record EditAddress Event OnValidate. Action Validate Required Value @348-1B6B5635
        If (SUBURB_TOWN.Value Is Nothing) OrElse SUBURB_TOWN.Value.ToString()="" Then
            errors.Add("SUBURB_TOWN",String.Format("The value in field SUBURB / TOWN is required;","EditAddress"))
        End If
'End Record EditAddress Event OnValidate. Action Validate Required Value

'Record EditAddress Event OnValidate. Action Validate Required Value @349-2E8CB493
        If (COUNTRY.Value Is Nothing) OrElse COUNTRY.Value.ToString()="" Then
            errors.Add("COUNTRY",String.Format("The value in field COUNTRY is required;","EditAddress"))
        End If
'End Record EditAddress Event OnValidate. Action Validate Required Value

'Record EditAddress Event OnValidate. Action Custom Code @351-73254650
    ' -------------------------
    ' ERA: end group validation
	end if
    ' -------------------------
'End Record EditAddress Event OnValidate. Action Custom Code

'Record EditAddress Item Class tail @10-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record EditAddress Item Class tail

'Record EditAddress Data Provider Class @10-0A6A3220
Public Class EditAddressDataProvider
Inherits RecordDataProviderBase
'End Record EditAddress Data Provider Class

'Record EditAddress Data Provider Class Variables @10-A602BD78
    Public Expr171 As FloatParameter
    Public ExprKey377 As IntegerParameter
    Public Ctrlcbox_same_as_school As IntegerParameter
    Public ExprKey454 As IntegerParameter
    Public UrlSTUDENT_ID As IntegerParameter
    Public Ctrlhidden_ADDRESS_ID As IntegerParameter
    Public Ctrlhidden_SCHOOL_ADDRESS_ID As IntegerParameter
    Public Ctrlhidden_flag_same_as As IntegerParameter
    Public CtrlADDRESSEE As TextParameter
    Public CtrlAGENT As TextParameter
    Public CtrlADDR1 As TextParameter
    Public CtrlADDR2 As TextParameter
    Public CtrlSUBURB_TOWN As TextParameter
    Public CtrlPOSTCODE As TextParameter
    Public CtrlSTATE As TextParameter
    Public CtrlCOUNTRY As TextParameter
    Public CtrlPHONE_A As TextParameter
    Public CtrlPHONE_B As TextParameter
    Public CtrlFAX As TextParameter
    Public CtrlEMAIL_ADDRESS As TextParameter
    Public CtrlEMAIL_ADDRESS2 As TextParameter
    Public SesUserID As TextParameter
    Protected item As EditAddressItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record EditAddress Data Provider Class Variables

'Record EditAddress Data Provider Class Constructor @10-FB2C33BC

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM ADDRESS {SQL_Where} {SQL_OrderBy}", New String(){"expr171"},Settings.connDECVPRODSQL2005DataAccessObject )
        Insert=new SpCommand("spu_UpdateStudentAddress_Postalpanel;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Update=new SpCommand("spu_UpdateStudentAddress_Postalpanel;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record EditAddress Data Provider Class Constructor

'Record EditAddress Data Provider Class LoadParams Method @10-416749E3

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(Expr171))
    End Function
'End Record EditAddress Data Provider Class LoadParams Method

'Record EditAddress Data Provider Class CheckUnique Method @10-4087625A

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As EditAddressItem) As Boolean
        Return True
    End Function
'End Record EditAddress Data Provider Class CheckUnique Method

'Record EditAddress Data Provider Class PrepareInsert Method @10-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record EditAddress Data Provider Class PrepareInsert Method

'Record EditAddress Data Provider Class PrepareInsert Method tail @10-E31F8E2A
    End Sub
'End Record EditAddress Data Provider Class PrepareInsert Method tail

'Record EditAddress Data Provider Class Insert Method @10-19059A2C

    Public Function InsertItem(ByVal item As EditAddressItem) As Integer
        Me.item = item
'End Record EditAddress Data Provider Class Insert Method

'Record EditAddress Build insert @10-B5FE3480
        Insert.Parameters.Clear()
        CType(Insert,SpCommand).AddParameter("@RETURN_VALUE",ExprKey377,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Insert,SpCommand).AddParameter("@STUDENT_ID",UrlSTUDENT_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Insert,SpCommand).AddParameter("@this_ADDRESS_ID",item.hidden_ADDRESS_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Insert,SpCommand).AddParameter("@SCHOOL_ADDRESS_ID",item.hidden_SCHOOL_ADDRESS_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Insert,SpCommand).AddParameter("@flag_same_as",item.cbox_same_as_school,ParameterType._Int,ParameterDirection.Input,3,0,10)
        CType(Insert,SpCommand).AddParameter("@ADDRESSEE",item.ADDRESSEE,ParameterType._Char,ParameterDirection.Input,60,0,10)
        CType(Insert,SpCommand).AddParameter("@AGENT",item.AGENT,ParameterType._Char,ParameterDirection.Input,60,0,10)
        CType(Insert,SpCommand).AddParameter("@ADDR1",item.ADDR1,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Insert,SpCommand).AddParameter("@ADDR2",item.ADDR2,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Insert,SpCommand).AddParameter("@SUBURB_TOWN",item.SUBURB_TOWN,ParameterType._Char,ParameterDirection.Input,30,0,10)
        CType(Insert,SpCommand).AddParameter("@POSTCODE",item.POSTCODE,ParameterType._Char,ParameterDirection.Input,10,0,10)
        CType(Insert,SpCommand).AddParameter("@STATE",item.STATE,ParameterType._Char,ParameterDirection.Input,20,0,10)
        CType(Insert,SpCommand).AddParameter("@COUNTRY",item.COUNTRY,ParameterType._Char,ParameterDirection.Input,20,0,10)
        CType(Insert,SpCommand).AddParameter("@PHONE_A",item.PHONE_A,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Insert,SpCommand).AddParameter("@PHONE_B",item.PHONE_B,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Insert,SpCommand).AddParameter("@FAX",item.FAX,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Insert,SpCommand).AddParameter("@EMAIL_ADDRESS",item.EMAIL_ADDRESS,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Insert,SpCommand).AddParameter("@EMAIL_ADDRESS2",item.EMAIL_ADDRESS2,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Insert,SpCommand).AddParameter("@LAST_ALTERED_BY",SesUserID,ParameterType._Char,ParameterDirection.Input,8,0,10)
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
            result = ExecuteInsert()
            ExprKey377 = IntegerParameter.GetParam(CType(Insert.Parameters("@RETURN_VALUE"),IDataParameter).Value)
        Catch ee As Exception
            E = ee
        Finally
'End Record EditAddress Build insert

'Record EditAddress AfterExecuteInsert @10-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record EditAddress AfterExecuteInsert

'Record EditAddress Data Provider Class PrepareUpdate Method @10-0A131024

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
'End Record EditAddress Data Provider Class PrepareUpdate Method

'Record EditAddress Data Provider Class PrepareUpdate Method tail @10-E31F8E2A
    End Sub
'End Record EditAddress Data Provider Class PrepareUpdate Method tail

'Record EditAddress Data Provider Class Update Method @10-2B879DE7

    Public Function UpdateItem(ByVal item As EditAddressItem) As Integer
        Me.item = item
'End Record EditAddress Data Provider Class Update Method

'Record EditAddress BeforeBuildUpdate @10-4DE2808D
        Update.Parameters.Clear()
        CType(Update,SpCommand).AddParameter("@RETURN_VALUE",ExprKey454,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Update,SpCommand).AddParameter("@STUDENT_ID",UrlSTUDENT_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@this_ADDRESS_ID",item.hidden_ADDRESS_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@SCHOOL_ADDRESS_ID",item.hidden_SCHOOL_ADDRESS_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@flag_same_as",item.hidden_flag_same_as,ParameterType._Int,ParameterDirection.Input,3,0,10)
        CType(Update,SpCommand).AddParameter("@ADDRESSEE",item.ADDRESSEE,ParameterType._Char,ParameterDirection.Input,60,0,10)
        CType(Update,SpCommand).AddParameter("@AGENT",item.AGENT,ParameterType._Char,ParameterDirection.Input,60,0,10)
        CType(Update,SpCommand).AddParameter("@ADDR1",item.ADDR1,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@ADDR2",item.ADDR2,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@SUBURB_TOWN",item.SUBURB_TOWN,ParameterType._Char,ParameterDirection.Input,30,0,10)
        CType(Update,SpCommand).AddParameter("@POSTCODE",item.POSTCODE,ParameterType._Char,ParameterDirection.Input,10,0,10)
        CType(Update,SpCommand).AddParameter("@STATE",item.STATE,ParameterType._Char,ParameterDirection.Input,20,0,10)
        CType(Update,SpCommand).AddParameter("@COUNTRY",item.COUNTRY,ParameterType._Char,ParameterDirection.Input,20,0,10)
        CType(Update,SpCommand).AddParameter("@PHONE_A",item.PHONE_A,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Update,SpCommand).AddParameter("@PHONE_B",item.PHONE_B,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Update,SpCommand).AddParameter("@FAX",item.FAX,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Update,SpCommand).AddParameter("@EMAIL_ADDRESS",item.EMAIL_ADDRESS,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@EMAIL_ADDRESS2",item.EMAIL_ADDRESS2,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@LAST_ALTERED_BY",SesUserID,ParameterType._Char,ParameterDirection.Input,8,0,10)
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
            result = ExecuteUpdate()
            ExprKey454 = IntegerParameter.GetParam(CType(Update.Parameters("@RETURN_VALUE"),IDataParameter).Value)
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record EditAddress BeforeBuildUpdate

'Record EditAddress AfterExecuteUpdate @10-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record EditAddress AfterExecuteUpdate

'Record EditAddress Data Provider Class GetResultSet Method @10-79A8C03D

    Public Sub FillItem(ByVal item As EditAddressItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record EditAddress Data Provider Class GetResultSet Method

'Record EditAddress BeforeBuildSelect @10-792ED1FE
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("expr171",Expr171, "","ADDRESS_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record EditAddress BeforeBuildSelect

'Record EditAddress BeforeExecuteSelect @10-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record EditAddress BeforeExecuteSelect

'Record EditAddress AfterExecuteSelect @10-DBBEEE85
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
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.STATE.SetValue(dr(i)("STATE"),"")
            item.COUNTRY.SetValue(dr(i)("COUNTRY"),"")
            item.PHONE_B.SetValue(dr(i)("PHONE_B"),"")
            item.lblAddressID.SetValue(dr(i)("ADDRESS_ID"),"")
            item.Link_carer1Href = "Student_Carer_maintainext.aspx"
        Else
            IsInsertMode = True
        End If
'End Record EditAddress AfterExecuteSelect

'Record EditAddress AfterExecuteSelect tail @10-E31F8E2A
    End Sub
'End Record EditAddress AfterExecuteSelect tail

'Record EditAddress Data Provider Class @10-A61BA892
End Class

'End Record EditAddress Data Provider Class

'Record EditAddress1 Item Class @195-5D8EA33A
Public Class EditAddress1Item
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
    Public LAST_ALTERED_DATE As DateField
    Public STATE As TextField
    Public COUNTRY As TextField
    Public PHONE_B As TextField
    Public lblAddressID As IntegerField
    Public cbox_same_as_postal As IntegerField
    Public cbox_same_as_postalCheckedValue As IntegerField
    Public cbox_same_as_postalUncheckedValue As IntegerField
    Public hidden_postal_ADDRESS_ID As TextField
    Public hidden_ADDRESS_ID As TextField
    Public hidden_flag_same_as As IntegerField
    Public Link_carer1 As TextField
    Public Link_carer1Href As Object
    Public Link_carer1HrefParameters As LinkParameterCollection
    Public Link_carer2 As TextField
    Public Link_carer2Href As Object
    Public Link_carer2HrefParameters As LinkParameterCollection
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
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    STATE = New TextField("", Nothing)
    COUNTRY = New TextField("", Nothing)
    PHONE_B = New TextField("", Nothing)
    lblAddressID = New IntegerField("", Nothing)
    cbox_same_as_postal = New IntegerField("", 0)
    cbox_same_as_postalCheckedValue = New IntegerField("", 1)
    cbox_same_as_postalUncheckedValue = New IntegerField("", 0)
    hidden_postal_ADDRESS_ID = New TextField("", Nothing)
    hidden_ADDRESS_ID = New TextField("", Nothing)
    hidden_flag_same_as = New IntegerField("", 0)
    Link_carer1 = New TextField("",Nothing)
    Link_carer1HrefParameters = New LinkParameterCollection()
    Link_carer2 = New TextField("",Nothing)
    Link_carer2HrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As EditAddress1Item
        Dim item As EditAddress1Item = New EditAddress1Item()
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
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
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
        If Not IsNothing(DBUtility.GetInitialValue("lblAddressID")) Then
        item.lblAddressID.SetValue(DBUtility.GetInitialValue("lblAddressID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("cbox_same_as_postal")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("cbox_same_as_postal")) Then
            item.cbox_same_as_postal.Value = item.cbox_same_as_postalCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_postal_ADDRESS_ID")) Then
        item.hidden_postal_ADDRESS_ID.SetValue(DBUtility.GetInitialValue("hidden_postal_ADDRESS_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_ADDRESS_ID")) Then
        item.hidden_ADDRESS_ID.SetValue(DBUtility.GetInitialValue("hidden_ADDRESS_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_flag_same_as")) Then
        item.hidden_flag_same_as.SetValue(DBUtility.GetInitialValue("hidden_flag_same_as"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link_carer1")) Then
        item.Link_carer1.SetValue(DBUtility.GetInitialValue("Link_carer1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link_carer2")) Then
        item.Link_carer2.SetValue(DBUtility.GetInitialValue("Link_carer2"))
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
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "STATE"
                    Return STATE
                Case "COUNTRY"
                    Return COUNTRY
                Case "PHONE_B"
                    Return PHONE_B
                Case "lblAddressID"
                    Return lblAddressID
                Case "cbox_same_as_postal"
                    Return cbox_same_as_postal
                Case "hidden_postal_ADDRESS_ID"
                    Return hidden_postal_ADDRESS_ID
                Case "hidden_ADDRESS_ID"
                    Return hidden_ADDRESS_ID
                Case "hidden_flag_same_as"
                    Return hidden_flag_same_as
                Case "Link_carer1"
                    Return Link_carer1
                Case "Link_carer2"
                    Return Link_carer2
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
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "STATE"
                    STATE = CType(value, TextField)
                Case "COUNTRY"
                    COUNTRY = CType(value, TextField)
                Case "PHONE_B"
                    PHONE_B = CType(value, TextField)
                Case "lblAddressID"
                    lblAddressID = CType(value, IntegerField)
                Case "cbox_same_as_postal"
                    cbox_same_as_postal = CType(value, IntegerField)
                Case "hidden_postal_ADDRESS_ID"
                    hidden_postal_ADDRESS_ID = CType(value, TextField)
                Case "hidden_ADDRESS_ID"
                    hidden_ADDRESS_ID = CType(value, TextField)
                Case "hidden_flag_same_as"
                    hidden_flag_same_as = CType(value, IntegerField)
                Case "Link_carer1"
                    Link_carer1 = CType(value, TextField)
                Case "Link_carer2"
                    Link_carer2 = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As EditAddress1DataProvider)
'End Record EditAddress1 Item Class

'Record EditAddress1 Event OnValidate. Action Custom Code @352-73254650
    ' -------------------------
    ' ERA: if checbox not checked then validate
	'if not (cbox_same_as_postal.equals(true)) then
	if (cbox_same_as_postal.Value = (cbox_same_as_postaluncheckedvalue.Value))
		'2-Mar-2009|EA| to validate emails, trim off spaces first....
		'EMAIL_ADDRESS.Value = EMAIL_ADDRESS.Value.Trim()
		'EMAIL_ADDRESS2.Value = EMAIL_ADDRESS2.Value.Trim()
    ' -------------------------
'End Record EditAddress1 Event OnValidate. Action Custom Code

'Record EditAddress1 Event OnValidate. Action Validate Required Value @353-E57B0009
        If (ADDRESSEE.Value Is Nothing) OrElse ADDRESSEE.Value.ToString()="" Then
            errors.Add("ADDRESSEE",String.Format("The value in field ADDRESSEE is required","EditAddress1"))
        End If
'End Record EditAddress1 Event OnValidate. Action Validate Required Value

'Record EditAddress1 Event OnValidate. Action Validate Required Value @354-6C4F3AF9
        If (SUBURB_TOWN.Value Is Nothing) OrElse SUBURB_TOWN.Value.ToString()="" Then
            errors.Add("SUBURB_TOWN",String.Format("The value in field SUBURB / TOWN is required","EditAddress1"))
        End If
'End Record EditAddress1 Event OnValidate. Action Validate Required Value

'Record EditAddress1 Event OnValidate. Action Validate Required Value @355-53CFDBC6
        If (COUNTRY.Value Is Nothing) OrElse COUNTRY.Value.ToString()="" Then
            errors.Add("COUNTRY",String.Format("The value in field COUNTRY is required","EditAddress1"))
        End If
'End Record EditAddress1 Event OnValidate. Action Validate Required Value

'Record EditAddress1 Event OnValidate. Action Custom Code @356-73254650
    ' -------------------------
    ' ERA: end group validation
	end if
    ' -------------------------
'End Record EditAddress1 Event OnValidate. Action Custom Code

'Record EditAddress1 Item Class tail @195-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record EditAddress1 Item Class tail

'Record EditAddress1 Data Provider Class @195-B5169815
Public Class EditAddress1DataProvider
Inherits RecordDataProviderBase
'End Record EditAddress1 Data Provider Class

'Record EditAddress1 Data Provider Class Variables @195-73FAF193
    Public Expr215 As FloatParameter
    Public UrlRETURN_VALUE As IntegerParameter
    Public Ctrlcbox_same_as_postal As IntegerParameter
    Public ExprKey418 As IntegerParameter
    Public UrlSTUDENT_ID As IntegerParameter
    Public Ctrlhidden_ADDRESS_ID As IntegerParameter
    Public Ctrlhidden_postal_ADDRESS_ID As IntegerParameter
    Public Ctrlhidden_flag_same_as As IntegerParameter
    Public CtrlADDRESSEE As TextParameter
    Public CtrlAGENT As TextParameter
    Public CtrlADDR1 As TextParameter
    Public CtrlADDR2 As TextParameter
    Public CtrlSUBURB_TOWN As TextParameter
    Public CtrlPOSTCODE As TextParameter
    Public CtrlSTATE As TextParameter
    Public CtrlCOUNTRY As TextParameter
    Public CtrlPHONE_A As TextParameter
    Public CtrlPHONE_B As TextParameter
    Public CtrlFAX As TextParameter
    Public CtrlEMAIL_ADDRESS As TextParameter
    Public CtrlEMAIL_ADDRESS2 As TextParameter
    Public SesUserID As TextParameter
    Protected item As EditAddress1Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record EditAddress1 Data Provider Class Variables

'Record EditAddress1 Data Provider Class Constructor @195-78FA728C

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM ADDRESS {SQL_Where} {SQL_OrderBy}", New String(){"expr215"},Settings.connDECVPRODSQL2005DataAccessObject )
        Insert=new SpCommand("spu_UpdateStudentAddress_Currentpanel;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Update=new SpCommand("spu_UpdateStudentAddress_Currentpanel;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record EditAddress1 Data Provider Class Constructor

'Record EditAddress1 Data Provider Class LoadParams Method @195-53F9A6F8

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(Expr215))
    End Function
'End Record EditAddress1 Data Provider Class LoadParams Method

'Record EditAddress1 Data Provider Class CheckUnique Method @195-0612C947

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As EditAddress1Item) As Boolean
        Return True
    End Function
'End Record EditAddress1 Data Provider Class CheckUnique Method

'Record EditAddress1 Data Provider Class PrepareInsert Method @195-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record EditAddress1 Data Provider Class PrepareInsert Method

'Record EditAddress1 Data Provider Class PrepareInsert Method tail @195-E31F8E2A
    End Sub
'End Record EditAddress1 Data Provider Class PrepareInsert Method tail

'Record EditAddress1 Data Provider Class Insert Method @195-9B2270AE

    Public Function InsertItem(ByVal item As EditAddress1Item) As Integer
        Me.item = item
'End Record EditAddress1 Data Provider Class Insert Method

'Record EditAddress1 Build insert @195-6A66F8DF
        Insert.Parameters.Clear()
        CType(Insert,SpCommand).AddParameter("@RETURN_VALUE",UrlRETURN_VALUE,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Insert,SpCommand).AddParameter("@STUDENT_ID",UrlSTUDENT_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Insert,SpCommand).AddParameter("@this_ADDRESS_ID",item.hidden_ADDRESS_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Insert,SpCommand).AddParameter("@SCHOOL_ADDRESS_ID",item.hidden_postal_ADDRESS_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Insert,SpCommand).AddParameter("@flag_same_as",item.cbox_same_as_postal,ParameterType._Int,ParameterDirection.Input,3,0,10)
        CType(Insert,SpCommand).AddParameter("@ADDRESSEE",item.ADDRESSEE,ParameterType._Char,ParameterDirection.Input,60,0,10)
        CType(Insert,SpCommand).AddParameter("@AGENT",item.AGENT,ParameterType._Char,ParameterDirection.Input,60,0,10)
        CType(Insert,SpCommand).AddParameter("@ADDR1",item.ADDR1,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Insert,SpCommand).AddParameter("@ADDR2",item.ADDR2,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Insert,SpCommand).AddParameter("@SUBURB_TOWN",item.SUBURB_TOWN,ParameterType._Char,ParameterDirection.Input,30,0,10)
        CType(Insert,SpCommand).AddParameter("@POSTCODE",item.POSTCODE,ParameterType._Char,ParameterDirection.Input,10,0,10)
        CType(Insert,SpCommand).AddParameter("@STATE",item.STATE,ParameterType._Char,ParameterDirection.Input,20,0,10)
        CType(Insert,SpCommand).AddParameter("@COUNTRY",item.COUNTRY,ParameterType._Char,ParameterDirection.Input,20,0,10)
        CType(Insert,SpCommand).AddParameter("@PHONE_A",item.PHONE_A,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Insert,SpCommand).AddParameter("@PHONE_B",item.PHONE_B,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Insert,SpCommand).AddParameter("@FAX",item.FAX,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Insert,SpCommand).AddParameter("@EMAIL_ADDRESS",item.EMAIL_ADDRESS,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Insert,SpCommand).AddParameter("@EMAIL_ADDRESS2",item.EMAIL_ADDRESS2,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Insert,SpCommand).AddParameter("@LAST_ALTERED_BY",SesUserID,ParameterType._Char,ParameterDirection.Input,8,0,10)
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
            result = ExecuteInsert()
            UrlRETURN_VALUE = IntegerParameter.GetParam(CType(Insert.Parameters("@RETURN_VALUE"),IDataParameter).Value)
        Catch ee As Exception
            E = ee
        Finally
'End Record EditAddress1 Build insert

'Record EditAddress1 AfterExecuteInsert @195-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record EditAddress1 AfterExecuteInsert

'Record EditAddress1 Data Provider Class PrepareUpdate Method @195-0A131024

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
'End Record EditAddress1 Data Provider Class PrepareUpdate Method

'Record EditAddress1 Data Provider Class PrepareUpdate Method tail @195-E31F8E2A
    End Sub
'End Record EditAddress1 Data Provider Class PrepareUpdate Method tail

'Record EditAddress1 Data Provider Class Update Method @195-97A6E991

    Public Function UpdateItem(ByVal item As EditAddress1Item) As Integer
        Me.item = item
'End Record EditAddress1 Data Provider Class Update Method

'Record EditAddress1 Event BeforeBuildUpdate. Action Custom Code @444-73254650
    ' -------------------------
     ' ERA: convert the 'on' or 'off' default settings of checkbox to 1/0
	'EditAddress1Errors.Add("1aCheckbox","1aCheckbox:" & item.cbox_same_as_postal.value.tostring())
	'EditAddress1Errors.Add("1bCheckbox","1bCheckbox:" & EditAddress1cbox_same_as_postal.Checked.tostring())
	
	'if (EditAddress1cbox_same_as_postal.Checked = true) then
	'if (item.cbox_same_as_postalcheckedvalue.equals(item.cbox_same_as_postal.value)) then
		'item.cbox_same_as_school.setvalue("true")
	'	ExprKey422.setvalue(1)
	'else
	'	'item.cbox_same_as_school.setvalue("false")
	'	ExprKey422.setvalue(0)
	'end if

	'let's get a confirmation of the checkbox value
	'EditAddress1Errors.Add("2Checkbox","2Checkbox:" & item.cbox_same_as_postal.getformattedvalue())
	'EditAddress1Errors.Add("2bCheckbox","2bCheckbox:" & ExprKey422.getformattedvalue())
    ' -------------------------
'End Record EditAddress1 Event BeforeBuildUpdate. Action Custom Code

'Record EditAddress1 BeforeBuildUpdate @195-A18E8DAD
        Update.Parameters.Clear()
        CType(Update,SpCommand).AddParameter("@RETURN_VALUE",ExprKey418,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Update,SpCommand).AddParameter("@STUDENT_ID",UrlSTUDENT_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@this_ADDRESS_ID",item.hidden_ADDRESS_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@SCHOOL_ADDRESS_ID",item.hidden_postal_ADDRESS_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@flag_same_as",item.hidden_flag_same_as,ParameterType._Int,ParameterDirection.Input,3,0,10)
        CType(Update,SpCommand).AddParameter("@ADDRESSEE",item.ADDRESSEE,ParameterType._Char,ParameterDirection.Input,60,0,10)
        CType(Update,SpCommand).AddParameter("@AGENT",item.AGENT,ParameterType._Char,ParameterDirection.Input,60,0,10)
        CType(Update,SpCommand).AddParameter("@ADDR1",item.ADDR1,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@ADDR2",item.ADDR2,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@SUBURB_TOWN",item.SUBURB_TOWN,ParameterType._Char,ParameterDirection.Input,30,0,10)
        CType(Update,SpCommand).AddParameter("@POSTCODE",item.POSTCODE,ParameterType._Char,ParameterDirection.Input,10,0,10)
        CType(Update,SpCommand).AddParameter("@STATE",item.STATE,ParameterType._Char,ParameterDirection.Input,20,0,10)
        CType(Update,SpCommand).AddParameter("@COUNTRY",item.COUNTRY,ParameterType._Char,ParameterDirection.Input,20,0,10)
        CType(Update,SpCommand).AddParameter("@PHONE_A",item.PHONE_A,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Update,SpCommand).AddParameter("@PHONE_B",item.PHONE_B,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Update,SpCommand).AddParameter("@FAX",item.FAX,ParameterType._Char,ParameterDirection.Input,15,0,10)
        CType(Update,SpCommand).AddParameter("@EMAIL_ADDRESS",item.EMAIL_ADDRESS,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@EMAIL_ADDRESS2",item.EMAIL_ADDRESS2,ParameterType._Char,ParameterDirection.Input,50,0,10)
        CType(Update,SpCommand).AddParameter("@LAST_ALTERED_BY",SesUserID,ParameterType._Char,ParameterDirection.Input,8,0,10)
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
            result = ExecuteUpdate()
            ExprKey418 = IntegerParameter.GetParam(CType(Update.Parameters("@RETURN_VALUE"),IDataParameter).Value)
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record EditAddress1 BeforeBuildUpdate

'Record EditAddress1 AfterExecuteUpdate @195-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record EditAddress1 AfterExecuteUpdate

'Record EditAddress1 Data Provider Class GetResultSet Method @195-E90C7511

    Public Sub FillItem(ByVal item As EditAddress1Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record EditAddress1 Data Provider Class GetResultSet Method

'Record EditAddress1 BeforeBuildSelect @195-29B8407D
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("expr215",Expr215, "","ADDRESS_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record EditAddress1 BeforeBuildSelect

'Record EditAddress1 BeforeExecuteSelect @195-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record EditAddress1 BeforeExecuteSelect

'Record EditAddress1 AfterExecuteSelect @195-F614F12C
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
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.STATE.SetValue(dr(i)("STATE"),"")
            item.COUNTRY.SetValue(dr(i)("COUNTRY"),"")
            item.PHONE_B.SetValue(dr(i)("PHONE_B"),"")
            item.lblAddressID.SetValue(dr(i)("ADDRESS_ID"),"")
            item.Link_carer1Href = "Student_Carer_maintainext.aspx"
            item.Link_carer2Href = "StudentDetails_maintain.aspx"
        Else
            IsInsertMode = True
        End If
'End Record EditAddress1 AfterExecuteSelect

'Record EditAddress1 AfterExecuteSelect tail @195-E31F8E2A
    End Sub
'End Record EditAddress1 AfterExecuteSelect tail

'Record EditAddress1 Data Provider Class @195-A61BA892
End Class

'End Record EditAddress1 Data Provider Class

'Record ADDRESS1 Item Class @174-18A6B232
Public Class ADDRESS1Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ADDRESSEE As TextField
    Public AGENT As TextField
    Public ADDR1 As TextField
    Public ADDR2 As TextField
    Public SUBURB_TOWN As TextField
    Public PHONE_A As TextField
    Public FAX As TextField
    Public EMAIL_ADDRESS As TextField
    Public EMAIL_ADDRESSHref As Object
    Public EMAIL_ADDRESSHrefParameters As LinkParameterCollection
    Public EMAIL_ADDRESS2 As TextField
    Public EMAIL_ADDRESS2Href As Object
    Public EMAIL_ADDRESS2HrefParameters As LinkParameterCollection
    Public LAST_ALTERED_BY As TextField
    Public STATE As TextField
    Public POSTCODE As TextField
    Public COUNTRY As TextField
    Public PHONE_B As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Link_EditCurrent As TextField
    Public Link_EditCurrentHref As Object
    Public Link_EditCurrentHrefParameters As LinkParameterCollection
    Public lblAddressID As IntegerField
    Public Link_carer1 As TextField
    Public Link_carer1Href As Object
    Public Link_carer1HrefParameters As LinkParameterCollection
    Public Link_carer2 As TextField
    Public Link_carer2Href As Object
    Public Link_carer2HrefParameters As LinkParameterCollection
    Public Sub New()
    ADDRESSEE = New TextField("", Nothing)
    AGENT = New TextField("", Nothing)
    ADDR1 = New TextField("", Nothing)
    ADDR2 = New TextField("", Nothing)
    SUBURB_TOWN = New TextField("", Nothing)
    PHONE_A = New TextField("", Nothing)
    FAX = New TextField("", Nothing)
    EMAIL_ADDRESS = New TextField("",Nothing)
    EMAIL_ADDRESSHrefParameters = New LinkParameterCollection()
    EMAIL_ADDRESS2 = New TextField("",Nothing)
    EMAIL_ADDRESS2HrefParameters = New LinkParameterCollection()
    LAST_ALTERED_BY = New TextField("", Nothing)
    STATE = New TextField("", Nothing)
    POSTCODE = New TextField("", Nothing)
    COUNTRY = New TextField("", Nothing)
    PHONE_B = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    Link_EditCurrent = New TextField("",Nothing)
    Link_EditCurrentHrefParameters = New LinkParameterCollection()
    lblAddressID = New IntegerField("", Nothing)
    Link_carer1 = New TextField("",Nothing)
    Link_carer1HrefParameters = New LinkParameterCollection()
    Link_carer2 = New TextField("",Nothing)
    Link_carer2HrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As ADDRESS1Item
        Dim item As ADDRESS1Item = New ADDRESS1Item()
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
        If Not IsNothing(DBUtility.GetInitialValue("STATE")) Then
        item.STATE.SetValue(DBUtility.GetInitialValue("STATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("POSTCODE")) Then
        item.POSTCODE.SetValue(DBUtility.GetInitialValue("POSTCODE"))
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
        If Not IsNothing(DBUtility.GetInitialValue("Link_EditCurrent")) Then
        item.Link_EditCurrent.SetValue(DBUtility.GetInitialValue("Link_EditCurrent"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblAddressID")) Then
        item.lblAddressID.SetValue(DBUtility.GetInitialValue("lblAddressID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link_carer1")) Then
        item.Link_carer1.SetValue(DBUtility.GetInitialValue("Link_carer1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link_carer2")) Then
        item.Link_carer2.SetValue(DBUtility.GetInitialValue("Link_carer2"))
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
                Case "STATE"
                    Return STATE
                Case "POSTCODE"
                    Return POSTCODE
                Case "COUNTRY"
                    Return COUNTRY
                Case "PHONE_B"
                    Return PHONE_B
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "Link_EditCurrent"
                    Return Link_EditCurrent
                Case "lblAddressID"
                    Return lblAddressID
                Case "Link_carer1"
                    Return Link_carer1
                Case "Link_carer2"
                    Return Link_carer2
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
                Case "STATE"
                    STATE = CType(value, TextField)
                Case "POSTCODE"
                    POSTCODE = CType(value, TextField)
                Case "COUNTRY"
                    COUNTRY = CType(value, TextField)
                Case "PHONE_B"
                    PHONE_B = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "Link_EditCurrent"
                    Link_EditCurrent = CType(value, TextField)
                Case "lblAddressID"
                    lblAddressID = CType(value, IntegerField)
                Case "Link_carer1"
                    Link_carer1 = CType(value, TextField)
                Case "Link_carer2"
                    Link_carer2 = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As ADDRESS1DataProvider)
'End Record ADDRESS1 Item Class

'Record ADDRESS1 Item Class tail @174-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record ADDRESS1 Item Class tail

'Record ADDRESS1 Data Provider Class @174-5C9370E6
Public Class ADDRESS1DataProvider
Inherits RecordDataProviderBase
'End Record ADDRESS1 Data Provider Class

'Record ADDRESS1 Data Provider Class Variables @174-73C3A5A1
    Public Expr192 As FloatParameter
    Protected item As ADDRESS1Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record ADDRESS1 Data Provider Class Variables

'Record ADDRESS1 Data Provider Class Constructor @174-9B022FCA

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM ADDRESS {SQL_Where} {SQL_OrderBy}", New String(){"expr192"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record ADDRESS1 Data Provider Class Constructor

'Record ADDRESS1 Data Provider Class LoadParams Method @174-D075744D

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(Expr192))
    End Function
'End Record ADDRESS1 Data Provider Class LoadParams Method

'Record ADDRESS1 Data Provider Class CheckUnique Method @174-D724C021

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As ADDRESS1Item) As Boolean
        Return True
    End Function
'End Record ADDRESS1 Data Provider Class CheckUnique Method

'Record ADDRESS1 Data Provider Class GetResultSet Method @174-5C3640F9

    Public Sub FillItem(ByVal item As ADDRESS1Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record ADDRESS1 Data Provider Class GetResultSet Method

'Record ADDRESS1 BeforeBuildSelect @174-423DB884
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("expr192",Expr192, "","ADDRESS_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record ADDRESS1 BeforeBuildSelect

'Record ADDRESS1 BeforeExecuteSelect @174-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record ADDRESS1 BeforeExecuteSelect

'Record ADDRESS1 AfterExecuteSelect @174-60E213E8
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
            item.PHONE_A.SetValue(dr(i)("PHONE_A"),"")
            item.FAX.SetValue(dr(i)("FAX"),"")
            item.EMAIL_ADDRESS.SetValue(dr(i)("EMAIL_ADDRESS"),"")
            item.EMAIL_ADDRESSHref = dr(i)("EMAIL_ADDRESS")
            item.EMAIL_ADDRESS2.SetValue(dr(i)("EMAIL_ADDRESS2"),"")
            item.EMAIL_ADDRESS2Href = dr(i)("EMAIL_ADDRESS2")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.STATE.SetValue(dr(i)("STATE"),"")
            item.POSTCODE.SetValue(dr(i)("POSTCODE"),"")
            item.COUNTRY.SetValue(dr(i)("COUNTRY"),"")
            item.PHONE_B.SetValue(dr(i)("PHONE_B"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.Link_EditCurrentHref = "Student_Address_panels_maintain.aspx"
            item.lblAddressID.SetValue(dr(i)("ADDRESS_ID"),"")
            item.Link_carer1Href = "Student_Carer_maintainext.aspx"
            item.Link_carer2Href = "StudentDetails_maintain.aspx"
        Else
            IsInsertMode = True
        End If
'End Record ADDRESS1 AfterExecuteSelect

'Record ADDRESS1 AfterExecuteSelect tail @174-E31F8E2A
    End Sub
'End Record ADDRESS1 AfterExecuteSelect tail

'Record ADDRESS1 Data Provider Class @174-A61BA892
End Class

'End Record ADDRESS1 Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

