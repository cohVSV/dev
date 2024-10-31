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

Namespace DECV_PROD2007.MaintainSearchRequest_Reception 'Namespace @1-22CC6F09

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

'Grid viewMaintainSearchRequest1 Item Class @3-4621B04D
Public Class viewMaintainSearchRequest1Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public viewMaintainSearchRequest1_TotalRecords As TextField
    Public STUDENT_ID As FloatField
    Public STUDENT_IDHref As Object
    Public STUDENT_IDHrefParameters As LinkParameterCollection
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public Postal_ADDR1 As TextField
    Public Postal_SUBURB_TOWN As TextField
    Public Postal_PHONE_A As TextField
    Public Postal_EMAIL_ADDRESS As TextField
    Public Curr_ADDR1 As TextField
    Public Curr_SUBURB_TOWN As TextField
    Public Curr_PHONE_A As TextField
    Public Curr_EMAIL_ADDRESS As TextField
    Public Postal_ADDR2 As TextField
    Public Postal_PHONE_B As TextField
    Public Postal_EMAIL_ADDRESS2 As TextField
    Public Curr_ADDR2 As TextField
    Public Curr_PHONE_B As TextField
    Public Curr_EMAIL_ADDRESS2 As TextField
    Public ENROLMENT_STATUS As TextField
    Public YEAR_LEVEL As TextField
    Public Postal_POSTCODE As TextField
    Public Curr_POSTCODE As TextField
    Public STUDENT_MOBILE As TextField
    Public STUDENT_EMAIL As TextField
    Public Sub New()
    viewMaintainSearchRequest1_TotalRecords = New TextField("", Nothing)
    STUDENT_ID = New FloatField("",Nothing)
    STUDENT_IDHrefParameters = New LinkParameterCollection()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    Postal_ADDR1 = New TextField("", Nothing)
    Postal_SUBURB_TOWN = New TextField("", Nothing)
    Postal_PHONE_A = New TextField("", Nothing)
    Postal_EMAIL_ADDRESS = New TextField("", Nothing)
    Curr_ADDR1 = New TextField("", Nothing)
    Curr_SUBURB_TOWN = New TextField("", Nothing)
    Curr_PHONE_A = New TextField("", Nothing)
    Curr_EMAIL_ADDRESS = New TextField("", Nothing)
    Postal_ADDR2 = New TextField("", Nothing)
    Postal_PHONE_B = New TextField("", Nothing)
    Postal_EMAIL_ADDRESS2 = New TextField("", Nothing)
    Curr_ADDR2 = New TextField("", Nothing)
    Curr_PHONE_B = New TextField("", Nothing)
    Curr_EMAIL_ADDRESS2 = New TextField("", Nothing)
    ENROLMENT_STATUS = New TextField("", Nothing)
    YEAR_LEVEL = New TextField("", Nothing)
    Postal_POSTCODE = New TextField("", Nothing)
    Curr_POSTCODE = New TextField("", Nothing)
    STUDENT_MOBILE = New TextField("", Nothing)
    STUDENT_EMAIL = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "viewMaintainSearchRequest1_TotalRecords"
                    Return Me.viewMaintainSearchRequest1_TotalRecords
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "Postal_ADDR1"
                    Return Me.Postal_ADDR1
                Case "Postal_SUBURB_TOWN"
                    Return Me.Postal_SUBURB_TOWN
                Case "Postal_PHONE_A"
                    Return Me.Postal_PHONE_A
                Case "Postal_EMAIL_ADDRESS"
                    Return Me.Postal_EMAIL_ADDRESS
                Case "Curr_ADDR1"
                    Return Me.Curr_ADDR1
                Case "Curr_SUBURB_TOWN"
                    Return Me.Curr_SUBURB_TOWN
                Case "Curr_PHONE_A"
                    Return Me.Curr_PHONE_A
                Case "Curr_EMAIL_ADDRESS"
                    Return Me.Curr_EMAIL_ADDRESS
                Case "Postal_ADDR2"
                    Return Me.Postal_ADDR2
                Case "Postal_PHONE_B"
                    Return Me.Postal_PHONE_B
                Case "Postal_EMAIL_ADDRESS2"
                    Return Me.Postal_EMAIL_ADDRESS2
                Case "Curr_ADDR2"
                    Return Me.Curr_ADDR2
                Case "Curr_PHONE_B"
                    Return Me.Curr_PHONE_B
                Case "Curr_EMAIL_ADDRESS2"
                    Return Me.Curr_EMAIL_ADDRESS2
                Case "ENROLMENT_STATUS"
                    Return Me.ENROLMENT_STATUS
                Case "YEAR_LEVEL"
                    Return Me.YEAR_LEVEL
                Case "Postal_POSTCODE"
                    Return Me.Postal_POSTCODE
                Case "Curr_POSTCODE"
                    Return Me.Curr_POSTCODE
                Case "STUDENT_MOBILE"
                    Return Me.STUDENT_MOBILE
                Case "STUDENT_EMAIL"
                    Return Me.STUDENT_EMAIL
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "viewMaintainSearchRequest1_TotalRecords"
                    Me.viewMaintainSearchRequest1_TotalRecords = CType(Value,TextField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "Postal_ADDR1"
                    Me.Postal_ADDR1 = CType(Value,TextField)
                Case "Postal_SUBURB_TOWN"
                    Me.Postal_SUBURB_TOWN = CType(Value,TextField)
                Case "Postal_PHONE_A"
                    Me.Postal_PHONE_A = CType(Value,TextField)
                Case "Postal_EMAIL_ADDRESS"
                    Me.Postal_EMAIL_ADDRESS = CType(Value,TextField)
                Case "Curr_ADDR1"
                    Me.Curr_ADDR1 = CType(Value,TextField)
                Case "Curr_SUBURB_TOWN"
                    Me.Curr_SUBURB_TOWN = CType(Value,TextField)
                Case "Curr_PHONE_A"
                    Me.Curr_PHONE_A = CType(Value,TextField)
                Case "Curr_EMAIL_ADDRESS"
                    Me.Curr_EMAIL_ADDRESS = CType(Value,TextField)
                Case "Postal_ADDR2"
                    Me.Postal_ADDR2 = CType(Value,TextField)
                Case "Postal_PHONE_B"
                    Me.Postal_PHONE_B = CType(Value,TextField)
                Case "Postal_EMAIL_ADDRESS2"
                    Me.Postal_EMAIL_ADDRESS2 = CType(Value,TextField)
                Case "Curr_ADDR2"
                    Me.Curr_ADDR2 = CType(Value,TextField)
                Case "Curr_PHONE_B"
                    Me.Curr_PHONE_B = CType(Value,TextField)
                Case "Curr_EMAIL_ADDRESS2"
                    Me.Curr_EMAIL_ADDRESS2 = CType(Value,TextField)
                Case "ENROLMENT_STATUS"
                    Me.ENROLMENT_STATUS = CType(Value,TextField)
                Case "YEAR_LEVEL"
                    Me.YEAR_LEVEL = CType(Value,TextField)
                Case "Postal_POSTCODE"
                    Me.Postal_POSTCODE = CType(Value,TextField)
                Case "Curr_POSTCODE"
                    Me.Curr_POSTCODE = CType(Value,TextField)
                Case "STUDENT_MOBILE"
                    Me.STUDENT_MOBILE = CType(Value,TextField)
                Case "STUDENT_EMAIL"
                    Me.STUDENT_EMAIL = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid viewMaintainSearchRequest1 Item Class

'Grid viewMaintainSearchRequest1 Data Provider Class Header @3-09D8C1B7
Public Class viewMaintainSearchRequest1DataProvider
Inherits GridDataProviderBase
'End Grid viewMaintainSearchRequest1 Data Provider Class Header

'Grid viewMaintainSearchRequest1 Data Provider Class Variables @3-A84F4191

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_ID
        Sorter_SURNAME
        Sorter_FIRST_NAME
        Sorter_Postal_ADDR1
        Sorter_Postal_SUBURB_TOWN
        Sorter_Postal_PHONE_A
        Sorter_Postal_EMAIL_ADDRESS
        Sorter_Curr_ADDR1
        Sorter_Curr_SUBURB_TOWN
        Sorter_Curr_PHONE_A
        Sorter_Curr_EMAIL_ADDRESS
    End Enum

    Private SortFieldsNames As String() = New String() {"","STUDENT_ID","SURNAME","FIRST_NAME","Postal_ADDR1","Postal_SUBURB_TOWN","Postal_PHONE_A","Postal_EMAIL_ADDRESS","Curr_ADDR1","Curr_SUBURB_TOWN","Curr_PHONE_A","Curr_EMAIL_ADDRESS"}
    Private SortFieldsNamesDesc As String() = New string() {"","STUDENT_ID DESC","SURNAME DESC","FIRST_NAME DESC","Postal_ADDR1 DESC","Postal_SUBURB_TOWN DESC","Postal_PHONE_A DESC","Postal_EMAIL_ADDRESS DESC","Curr_ADDR1 DESC","Curr_SUBURB_TOWN DESC","Curr_PHONE_A DESC","Curr_EMAIL_ADDRESS DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 50
    Public PageNumber As Integer = 1
    Public Urls_FIRST_NAME  As TextParameter
    Public Urls_Postal_ADDR1  As TextParameter
    Public Urls_Postal_PHONE_A  As TextParameter
    Public Urls_Postal_EMAIL_ADDRESS  As TextParameter
'End Grid viewMaintainSearchRequest1 Data Provider Class Variables

'Grid viewMaintainSearchRequest1 Data Provider Class GetResultSet Method @3-2BEB09B6

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM viewMaintainSearchRequest_Reception {SQL_Where} {SQL_OrderBy}", New String(){"s_FIRST_NAME117","And","(","s_Postal_ADDR1118","Or","s_Postal_ADDR1119","Or","s_Postal_ADDR1120","Or","s_Postal_ADDR1121","Or","s_Postal_ADDR1122","Or","s_Postal_ADDR1123","Or","s_Postal_ADDR1124","Or","s_Postal_ADDR1125",")","And","(","s_Postal_PHONE_A126","Or","s_Postal_PHONE_A127","Or","s_Postal_PHONE_A128","Or","s_Postal_PHONE_A129","Or","s_Postal_PHONE_A130",")","And","(","s_Postal_EMAIL_ADDRESS131","Or","s_Postal_EMAIL_ADDRESS132","Or","s_Postal_EMAIL_ADDRESS133","Or","s_Postal_EMAIL_ADDRESS134","Or","s_Postal_EMAIL_ADDRESS135",")"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM viewMaintainSearchRequest_Reception", New String(){"s_FIRST_NAME117","And","(","s_Postal_ADDR1118","Or","s_Postal_ADDR1119","Or","s_Postal_ADDR1120","Or","s_Postal_ADDR1121","Or","s_Postal_ADDR1122","Or","s_Postal_ADDR1123","Or","s_Postal_ADDR1124","Or","s_Postal_ADDR1125",")","And","(","s_Postal_PHONE_A126","Or","s_Postal_PHONE_A127","Or","s_Postal_PHONE_A128","Or","s_Postal_PHONE_A129","Or","s_Postal_PHONE_A130",")","And","(","s_Postal_EMAIL_ADDRESS131","Or","s_Postal_EMAIL_ADDRESS132","Or","s_Postal_EMAIL_ADDRESS133","Or","s_Postal_EMAIL_ADDRESS134","Or","s_Postal_EMAIL_ADDRESS135",")"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid viewMaintainSearchRequest1 Data Provider Class GetResultSet Method

'Grid viewMaintainSearchRequest1 Data Provider Class GetResultSet Method @3-F7597E21
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As viewMaintainSearchRequest1Item()
'End Grid viewMaintainSearchRequest1 Data Provider Class GetResultSet Method

'Before build Select @3-903317DB
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_FIRST_NAME117",Urls_FIRST_NAME, "","FIRST_NAME",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_Postal_ADDR1118",Urls_Postal_ADDR1, "","Postal_ADDR1",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_Postal_ADDR1119",Urls_Postal_ADDR1, "","Postal_ADDR2",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_Postal_ADDR1120",Urls_Postal_ADDR1, "","Postal_SUBURB_TOWN",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_Postal_ADDR1121",Urls_Postal_ADDR1, "","Postal_COUNTRY",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_Postal_ADDR1122",Urls_Postal_ADDR1, "","Curr_ADDR1",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_Postal_ADDR1123",Urls_Postal_ADDR1, "","Curr_ADDR2",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_Postal_ADDR1124",Urls_Postal_ADDR1, "","Curr_COUNTRY",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_Postal_ADDR1125",Urls_Postal_ADDR1, "","Curr_SUBURB_TOWN",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_Postal_PHONE_A126",Urls_Postal_PHONE_A, "","Postal_PHONE_A",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_Postal_PHONE_A127",Urls_Postal_PHONE_A, "","Postal_PHONE_B",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_Postal_PHONE_A128",Urls_Postal_PHONE_A, "","Curr_PHONE_A",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_Postal_PHONE_A129",Urls_Postal_PHONE_A, "","STUDENT_MOBILE",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_Postal_PHONE_A130",Urls_Postal_PHONE_A, "","Curr_PHONE_B",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_Postal_EMAIL_ADDRESS131",Urls_Postal_EMAIL_ADDRESS, "","Postal_EMAIL_ADDRESS",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_Postal_EMAIL_ADDRESS132",Urls_Postal_EMAIL_ADDRESS, "","Postal_EMAIL_ADDRESS2",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_Postal_EMAIL_ADDRESS133",Urls_Postal_EMAIL_ADDRESS, "","Curr_EMAIL_ADDRESS",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_Postal_EMAIL_ADDRESS134",Urls_Postal_EMAIL_ADDRESS, "","STUDENT_EMAIL",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_Postal_EMAIL_ADDRESS135",Urls_Postal_EMAIL_ADDRESS, "","Curr_EMAIL_ADDRESS2",Condition.Contains,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @3-52D8CFFC
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As viewMaintainSearchRequest1Item
        If ops.AllowRead Then
            Try
                If RecordsPerPage > 0 Then
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _PagesCount = ExecuteCount()
                    m_recordCount = _PagesCount
                    If _PagesCount Mod RecordsPerPage>0 Then
                        _PagesCount = (_PagesCount\RecordsPerPage)+1
                    Else
                        _PagesCount = _PagesCount\RecordsPerPage
                    End If
                Else
                    ds=ExecuteSelect()
                    If ds.Tables(tableIndex).Rows.Count<>0 Then 
                        _PagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                    End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @3-72568EAF
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New viewMaintainSearchRequest1Item(dr.Count-1) {}
'End After execute Select

'After execute Select @3-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @3-01442554
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as viewMaintainSearchRequest1Item = New viewMaintainSearchRequest1Item()
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.STUDENT_IDHref = "StudentSummary.aspx"
                item.STUDENT_IDHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.Postal_ADDR1.SetValue(dr(i)("Postal_ADDR1"),"")
                item.Postal_SUBURB_TOWN.SetValue(dr(i)("Postal_SUBURB_TOWN"),"")
                item.Postal_PHONE_A.SetValue(dr(i)("Postal_PHONE_A"),"")
                item.Postal_EMAIL_ADDRESS.SetValue(dr(i)("Postal_EMAIL_ADDRESS"),"")
                item.Curr_ADDR1.SetValue(dr(i)("Curr_ADDR1"),"")
                item.Curr_SUBURB_TOWN.SetValue(dr(i)("Curr_SUBURB_TOWN"),"")
                item.Curr_PHONE_A.SetValue(dr(i)("Curr_PHONE_A"),"")
                item.Curr_EMAIL_ADDRESS.SetValue(dr(i)("Curr_EMAIL_ADDRESS"),"")
                item.Postal_ADDR2.SetValue(dr(i)("Postal_ADDR2"),"")
                item.Postal_PHONE_B.SetValue(dr(i)("Postal_PHONE_B"),"")
                item.Postal_EMAIL_ADDRESS2.SetValue(dr(i)("Postal_EMAIL_ADDRESS2"),"")
                item.Curr_ADDR2.SetValue(dr(i)("Curr_ADDR2"),"")
                item.Curr_PHONE_B.SetValue(dr(i)("Curr_PHONE_B"),"")
                item.Curr_EMAIL_ADDRESS2.SetValue(dr(i)("Curr_EMAIL_ADDRESS2"),"")
                item.ENROLMENT_STATUS.SetValue(dr(i)("ENROLMENT_STATUS"),"")
                item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
                item.Postal_POSTCODE.SetValue(dr(i)("Postal_POSTCODE"),"")
                item.Curr_POSTCODE.SetValue(dr(i)("Curr_POSTCODE"),"")
                item.STUDENT_MOBILE.SetValue(dr(i)("STUDENT_MOBILE"),"")
                item.STUDENT_EMAIL.SetValue(dr(i)("STUDENT_EMAIL"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @3-A61BA892
End Class
'End Grid Data Provider tail

'Record viewMaintainSearchRequest Item Class @4-9BB65EB5
Public Class viewMaintainSearchRequestItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_FIRST_NAME As TextField
    Public s_Postal_ADDR1 As TextField
    Public s_Postal_PHONE_A As TextField
    Public s_Postal_EMAIL_ADDRESS As TextField
    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public Sub New()
    s_FIRST_NAME = New TextField("", Nothing)
    s_Postal_ADDR1 = New TextField("", Nothing)
    s_Postal_PHONE_A = New TextField("", Nothing)
    s_Postal_EMAIL_ADDRESS = New TextField("", Nothing)
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    Link1 = New TextField("",Nothing)
    Link1HrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As viewMaintainSearchRequestItem
        Dim item As viewMaintainSearchRequestItem = New viewMaintainSearchRequestItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_FIRST_NAME")) Then
        item.s_FIRST_NAME.SetValue(DBUtility.GetInitialValue("s_FIRST_NAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_Postal_ADDR1")) Then
        item.s_Postal_ADDR1.SetValue(DBUtility.GetInitialValue("s_Postal_ADDR1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_Postal_PHONE_A")) Then
        item.s_Postal_PHONE_A.SetValue(DBUtility.GetInitialValue("s_Postal_PHONE_A"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_Postal_EMAIL_ADDRESS")) Then
        item.s_Postal_EMAIL_ADDRESS.SetValue(DBUtility.GetInitialValue("s_Postal_EMAIL_ADDRESS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link1")) Then
        item.Link1.SetValue(DBUtility.GetInitialValue("Link1"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_FIRST_NAME"
                    Return s_FIRST_NAME
                Case "s_Postal_ADDR1"
                    Return s_Postal_ADDR1
                Case "s_Postal_PHONE_A"
                    Return s_Postal_PHONE_A
                Case "s_Postal_EMAIL_ADDRESS"
                    Return s_Postal_EMAIL_ADDRESS
                Case "ClearParameters"
                    Return ClearParameters
                Case "Link1"
                    Return Link1
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_FIRST_NAME"
                    s_FIRST_NAME = CType(value, TextField)
                Case "s_Postal_ADDR1"
                    s_Postal_ADDR1 = CType(value, TextField)
                Case "s_Postal_PHONE_A"
                    s_Postal_PHONE_A = CType(value, TextField)
                Case "s_Postal_EMAIL_ADDRESS"
                    s_Postal_EMAIL_ADDRESS = CType(value, TextField)
                Case "ClearParameters"
                    ClearParameters = CType(value, TextField)
                Case "Link1"
                    Link1 = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As viewMaintainSearchRequestDataProvider)
'End Record viewMaintainSearchRequest Item Class

'Record viewMaintainSearchRequest Item Class tail @4-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record viewMaintainSearchRequest Item Class tail

'Record viewMaintainSearchRequest Data Provider Class @4-77F14331
Public Class viewMaintainSearchRequestDataProvider
Inherits RecordDataProviderBase
'End Record viewMaintainSearchRequest Data Provider Class

'Record viewMaintainSearchRequest Data Provider Class Variables @4-5C619156
    Protected item As viewMaintainSearchRequestItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record viewMaintainSearchRequest Data Provider Class Variables

'Record viewMaintainSearchRequest Data Provider Class GetResultSet Method @4-D5AB571D

    Public Sub FillItem(ByVal item As viewMaintainSearchRequestItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record viewMaintainSearchRequest Data Provider Class GetResultSet Method

'Record viewMaintainSearchRequest BeforeBuildSelect @4-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record viewMaintainSearchRequest BeforeBuildSelect

'Record viewMaintainSearchRequest AfterExecuteSelect @4-79426A21
        End If
            IsInsertMode = True
'End Record viewMaintainSearchRequest AfterExecuteSelect

'Record viewMaintainSearchRequest AfterExecuteSelect tail @4-E31F8E2A
    End Sub
'End Record viewMaintainSearchRequest AfterExecuteSelect tail

'Record viewMaintainSearchRequest Data Provider Class @4-A61BA892
End Class

'End Record viewMaintainSearchRequest Data Provider Class

'Grid viewMaintainSearchRequest2 Item Class @86-0AD187D5
Public Class viewMaintainSearchRequest2Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STUDENT_ID As FloatField
    Public STUDENT_IDHref As Object
    Public STUDENT_IDHrefParameters As LinkParameterCollection
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public RELATIONSHIP As TextField
    Public HOME_PHONE As TextField
    Public WORK_PHONE As TextField
    Public MOBILE As TextField
    Public EMAIL As TextField
    Public Sub New()
    STUDENT_ID = New FloatField("",Nothing)
    STUDENT_IDHrefParameters = New LinkParameterCollection()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    RELATIONSHIP = New TextField("", Nothing)
    HOME_PHONE = New TextField("", Nothing)
    WORK_PHONE = New TextField("", Nothing)
    MOBILE = New TextField("", Nothing)
    EMAIL = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "RELATIONSHIP"
                    Return Me.RELATIONSHIP
                Case "HOME_PHONE"
                    Return Me.HOME_PHONE
                Case "WORK_PHONE"
                    Return Me.WORK_PHONE
                Case "MOBILE"
                    Return Me.MOBILE
                Case "EMAIL"
                    Return Me.EMAIL
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "RELATIONSHIP"
                    Me.RELATIONSHIP = CType(Value,TextField)
                Case "HOME_PHONE"
                    Me.HOME_PHONE = CType(Value,TextField)
                Case "WORK_PHONE"
                    Me.WORK_PHONE = CType(Value,TextField)
                Case "MOBILE"
                    Me.MOBILE = CType(Value,TextField)
                Case "EMAIL"
                    Me.EMAIL = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid viewMaintainSearchRequest2 Item Class

'Grid viewMaintainSearchRequest2 Data Provider Class Header @86-EA917615
Public Class viewMaintainSearchRequest2DataProvider
Inherits GridDataProviderBase
'End Grid viewMaintainSearchRequest2 Data Provider Class Header

'Grid viewMaintainSearchRequest2 Data Provider Class Variables @86-20D2713C

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_ID
        Sorter_SURNAME
        Sorter_FIRST_NAME
        Sorter_RELATIONSHIP
        Sorter_HOME_PHONE
        Sorter_WORK_PHONE
        Sorter_MOBILE
        Sorter_EMAIL
    End Enum

    Private SortFieldsNames As String() = New String() {"","STUDENT_ID","SURNAME","FIRST_NAME","RELATIONSHIP","HOME_PHONE","WORK_PHONE","MOBILE","EMAIL"}
    Private SortFieldsNamesDesc As String() = New string() {"","STUDENT_ID DESC","SURNAME DESC","FIRST_NAME DESC","RELATIONSHIP DESC","HOME_PHONE DESC","WORK_PHONE DESC","MOBILE DESC","EMAIL DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 50
    Public PageNumber As Integer = 1
    Public Urls_FIRST_NAME  As TextParameter
    Public Urls_POSTAL_PHONE_A  As TextParameter
    Public Urls_POSTAL_EMAIL_ADDRESS  As TextParameter
'End Grid viewMaintainSearchRequest2 Data Provider Class Variables

'Grid viewMaintainSearchRequest2 Data Provider Class GetResultSet Method @86-38E848C6

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM viewMaintainSearchRequest_Carers {SQL_Where} {SQL_OrderBy}", New String(){"s_FIRST_NAME107","And","(","s_POSTAL_PHONE_A108","Or","s_POSTAL_PHONE_A109","Or","s_POSTAL_PHONE_A110",")","And","s_POSTAL_EMAIL_ADDRESS111"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM viewMaintainSearchRequest_Carers", New String(){"s_FIRST_NAME107","And","(","s_POSTAL_PHONE_A108","Or","s_POSTAL_PHONE_A109","Or","s_POSTAL_PHONE_A110",")","And","s_POSTAL_EMAIL_ADDRESS111"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid viewMaintainSearchRequest2 Data Provider Class GetResultSet Method

'Grid viewMaintainSearchRequest2 Data Provider Class GetResultSet Method @86-C6B164BC
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As viewMaintainSearchRequest2Item()
'End Grid viewMaintainSearchRequest2 Data Provider Class GetResultSet Method

'Before build Select @86-9EA2DF15
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_FIRST_NAME107",Urls_FIRST_NAME, "","FIRST_NAME",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_POSTAL_PHONE_A108",Urls_POSTAL_PHONE_A, "","HOME_PHONE",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_POSTAL_PHONE_A109",Urls_POSTAL_PHONE_A, "","WORK_PHONE",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_POSTAL_PHONE_A110",Urls_POSTAL_PHONE_A, "","MOBILE",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_POSTAL_EMAIL_ADDRESS111",Urls_POSTAL_EMAIL_ADDRESS, "","EMAIL",Condition.Contains,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @86-3C9FAF61
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As viewMaintainSearchRequest2Item
        If ops.AllowRead Then
            Try
                If RecordsPerPage > 0 Then
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _PagesCount = ExecuteCount()
                    m_recordCount = _PagesCount
                    If _PagesCount Mod RecordsPerPage>0 Then
                        _PagesCount = (_PagesCount\RecordsPerPage)+1
                    Else
                        _PagesCount = _PagesCount\RecordsPerPage
                    End If
                Else
                    ds=ExecuteSelect()
                    If ds.Tables(tableIndex).Rows.Count<>0 Then 
                        _PagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                    End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @86-D1000806
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New viewMaintainSearchRequest2Item(dr.Count-1) {}
'End After execute Select

'After execute Select @86-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @86-46256727
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as viewMaintainSearchRequest2Item = New viewMaintainSearchRequest2Item()
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.STUDENT_IDHref = "StudentSummary.aspx"
                item.STUDENT_IDHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.RELATIONSHIP.SetValue(dr(i)("RELATIONSHIP"),"")
                item.HOME_PHONE.SetValue(dr(i)("HOME_PHONE"),"")
                item.WORK_PHONE.SetValue(dr(i)("WORK_PHONE"),"")
                item.MOBILE.SetValue(dr(i)("MOBILE"),"")
                item.EMAIL.SetValue(dr(i)("EMAIL"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @86-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

