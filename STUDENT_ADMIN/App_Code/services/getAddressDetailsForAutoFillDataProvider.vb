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

Namespace DECV_PROD2007.services.getAddressDetailsForAutoFill 'Namespace @1-311181A1

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

'Grid ADDRESS Item Class @2-3E966646
Public Class ADDRESSItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public ADDRESS_ID As FloatField
    Public ADDRESSEE As TextField
    Public AGENT As TextField
    Public ADDR1 As TextField
    Public ADDR2 As TextField
    Public SUBURB_TOWN As TextField
    Public POSTCODE As TextField
    Public STATE As TextField
    Public COUNTRY As TextField
    Public PHONE_A As TextField
    Public PHONE_B As TextField
    Public FAX As TextField
    Public EMAIL_ADDRESS As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public EMAIL_ADDRESS2 As TextField
    Public Sub New()
    ADDRESS_ID = New FloatField("", Nothing)
    ADDRESSEE = New TextField("", Nothing)
    AGENT = New TextField("", Nothing)
    ADDR1 = New TextField("", Nothing)
    ADDR2 = New TextField("", Nothing)
    SUBURB_TOWN = New TextField("", Nothing)
    POSTCODE = New TextField("", Nothing)
    STATE = New TextField("", Nothing)
    COUNTRY = New TextField("", Nothing)
    PHONE_A = New TextField("", Nothing)
    PHONE_B = New TextField("", Nothing)
    FAX = New TextField("", Nothing)
    EMAIL_ADDRESS = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    EMAIL_ADDRESS2 = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "ADDRESS_ID"
                    Return Me.ADDRESS_ID
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
                Case "POSTCODE"
                    Return Me.POSTCODE
                Case "STATE"
                    Return Me.STATE
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
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "EMAIL_ADDRESS2"
                    Return Me.EMAIL_ADDRESS2
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ADDRESS_ID"
                    Me.ADDRESS_ID = CType(Value,FloatField)
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
                Case "POSTCODE"
                    Me.POSTCODE = CType(Value,TextField)
                Case "STATE"
                    Me.STATE = CType(Value,TextField)
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
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "EMAIL_ADDRESS2"
                    Me.EMAIL_ADDRESS2 = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid ADDRESS Item Class

'Grid ADDRESS Data Provider Class Header @2-CCE7DC6E
Public Class ADDRESSDataProvider
Inherits GridDataProviderBase
'End Grid ADDRESS Data Provider Class Header

'Grid ADDRESS Data Provider Class Variables @2-FD44BBD6

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 10
    Public PageNumber As Integer = 1
    Public Urlkeyword  As FloatParameter
'End Grid ADDRESS Data Provider Class Variables

'Grid ADDRESS Data Provider Class GetResultSet Method @2-45567937

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM ADDRESS {SQL_Where} {SQL_OrderBy}", New String(){"keyword150"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM ADDRESS", New String(){"keyword150"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid ADDRESS Data Provider Class GetResultSet Method

'Grid ADDRESS Data Provider Class GetResultSet Method @2-66E75E10
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As ADDRESSItem()
'End Grid ADDRESS Data Provider Class GetResultSet Method

'Before build Select @2-3BB05091
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("keyword150",Urlkeyword, "","ADDRESS_ID",Condition.Equal,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-7BE436D7
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As ADDRESSItem
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

'After execute Select @2-C0E6EF56
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New ADDRESSItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-DE116D5E
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as ADDRESSItem = New ADDRESSItem()
                item.ADDRESS_ID.SetValue(dr(i)("ADDRESS_ID"),"")
                item.ADDRESSEE.SetValue(dr(i)("ADDRESSEE"),"")
                item.AGENT.SetValue(dr(i)("AGENT"),"")
                item.ADDR1.SetValue(dr(i)("ADDR1"),"")
                item.ADDR2.SetValue(dr(i)("ADDR2"),"")
                item.SUBURB_TOWN.SetValue(dr(i)("SUBURB_TOWN"),"")
                item.POSTCODE.SetValue(dr(i)("POSTCODE"),"")
                item.STATE.SetValue(dr(i)("STATE"),"")
                item.COUNTRY.SetValue(dr(i)("COUNTRY"),"")
                item.PHONE_A.SetValue(dr(i)("PHONE_A"),"")
                item.PHONE_B.SetValue(dr(i)("PHONE_B"),"")
                item.FAX.SetValue(dr(i)("FAX"),"")
                item.EMAIL_ADDRESS.SetValue(dr(i)("EMAIL_ADDRESS"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.EMAIL_ADDRESS2.SetValue(dr(i)("EMAIL_ADDRESS2"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @2-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

