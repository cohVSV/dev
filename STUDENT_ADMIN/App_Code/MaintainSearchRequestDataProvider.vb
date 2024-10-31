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

Namespace DECV_PROD2007.MaintainSearchRequest 'Namespace @1-74A53512

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

'Record viewMaintainSearchRequestSearch Item Class @5-8FC393B7
Public Class viewMaintainSearchRequestSearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_SURNAME As TextField
    Public s_STUDENT_ID As FloatField
    Public s_ENROLMENT_YEAR As IntegerField
    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public Link2 As TextField
    Public Link2Href As Object
    Public Link2HrefParameters As LinkParameterCollection
    Public Sub New()
    s_SURNAME = New TextField("", Nothing)
    s_STUDENT_ID = New FloatField("", Nothing)
    s_ENROLMENT_YEAR = New IntegerField("", Year(Date.Today))
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    Link1 = New TextField("",Nothing)
    Link1HrefParameters = New LinkParameterCollection()
    Link2 = New TextField("",Nothing)
    Link2HrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As viewMaintainSearchRequestSearchItem
        Dim item As viewMaintainSearchRequestSearchItem = New viewMaintainSearchRequestSearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("s_SURNAME")) Then
        item.s_SURNAME.SetValue(DBUtility.GetInitialValue("s_SURNAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_STUDENT_ID")) Then
        item.s_STUDENT_ID.SetValue(DBUtility.GetInitialValue("s_STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_ENROLMENT_YEAR")) Then
        item.s_ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("s_ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoAddEnrolYearSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link1")) Then
        item.Link1.SetValue(DBUtility.GetInitialValue("Link1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link2")) Then
        item.Link2.SetValue(DBUtility.GetInitialValue("Link2"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_SURNAME"
                    Return s_SURNAME
                Case "s_STUDENT_ID"
                    Return s_STUDENT_ID
                Case "s_ENROLMENT_YEAR"
                    Return s_ENROLMENT_YEAR
                Case "ClearParameters"
                    Return ClearParameters
                Case "Link1"
                    Return Link1
                Case "Link2"
                    Return Link2
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_SURNAME"
                    s_SURNAME = CType(value, TextField)
                Case "s_STUDENT_ID"
                    s_STUDENT_ID = CType(value, FloatField)
                Case "s_ENROLMENT_YEAR"
                    s_ENROLMENT_YEAR = CType(value, IntegerField)
                Case "ClearParameters"
                    ClearParameters = CType(value, TextField)
                Case "Link1"
                    Link1 = CType(value, TextField)
                Case "Link2"
                    Link2 = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As viewMaintainSearchRequestSearchDataProvider)
'End Record viewMaintainSearchRequestSearch Item Class

'Record viewMaintainSearchRequestSearch Item Class tail @5-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record viewMaintainSearchRequestSearch Item Class tail

'Record viewMaintainSearchRequestSearch Data Provider Class @5-C603CE6E
Public Class viewMaintainSearchRequestSearchDataProvider
Inherits RecordDataProviderBase
'End Record viewMaintainSearchRequestSearch Data Provider Class

'Record viewMaintainSearchRequestSearch Data Provider Class Variables @5-A0C04C73
    Protected item As viewMaintainSearchRequestSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record viewMaintainSearchRequestSearch Data Provider Class Variables

'Record viewMaintainSearchRequestSearch Data Provider Class GetResultSet Method @5-676EE12A

    Public Sub FillItem(ByVal item As viewMaintainSearchRequestSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record viewMaintainSearchRequestSearch Data Provider Class GetResultSet Method

'Record viewMaintainSearchRequestSearch BeforeBuildSelect @5-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record viewMaintainSearchRequestSearch BeforeBuildSelect

'Record viewMaintainSearchRequestSearch AfterExecuteSelect @5-79426A21
        End If
            IsInsertMode = True
'End Record viewMaintainSearchRequestSearch AfterExecuteSelect

'Record viewMaintainSearchRequestSearch AfterExecuteSelect tail @5-E31F8E2A
    End Sub
'End Record viewMaintainSearchRequestSearch AfterExecuteSelect tail

'Record viewMaintainSearchRequestSearch Data Provider Class @5-A61BA892
End Class

'End Record viewMaintainSearchRequestSearch Data Provider Class

'Grid viewMaintainSearchRequest Item Class @3-6B66CBC1
Public Class viewMaintainSearchRequestItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STUDENT_ID As FloatField
    Public STUDENT_IDHref As Object
    Public STUDENT_IDHrefParameters As LinkParameterCollection
    Public RECEIPT_NO As TextField
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public YEAR_LEVEL As IntegerField
    Public ENROLMENT_STATUS As TextField
    Public ENROLMENT_YEAR As FloatField
    Public Sub New()
    STUDENT_ID = New FloatField("",Nothing)
    STUDENT_IDHrefParameters = New LinkParameterCollection()
    RECEIPT_NO = New TextField("", Nothing)
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    YEAR_LEVEL = New IntegerField("", Nothing)
    ENROLMENT_STATUS = New TextField("", Nothing)
    ENROLMENT_YEAR = New FloatField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "RECEIPT_NO"
                    Return Me.RECEIPT_NO
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "YEAR_LEVEL"
                    Return Me.YEAR_LEVEL
                Case "ENROLMENT_STATUS"
                    Return Me.ENROLMENT_STATUS
                Case "ENROLMENT_YEAR"
                    Return Me.ENROLMENT_YEAR
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "RECEIPT_NO"
                    Me.RECEIPT_NO = CType(Value,TextField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "YEAR_LEVEL"
                    Me.YEAR_LEVEL = CType(Value,IntegerField)
                Case "ENROLMENT_STATUS"
                    Me.ENROLMENT_STATUS = CType(Value,TextField)
                Case "ENROLMENT_YEAR"
                    Me.ENROLMENT_YEAR = CType(Value,FloatField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid viewMaintainSearchRequest Item Class

'Grid viewMaintainSearchRequest Data Provider Class Header @3-044B34D7
Public Class viewMaintainSearchRequestDataProvider
Inherits GridDataProviderBase
'End Grid viewMaintainSearchRequest Data Provider Class Header

'Grid viewMaintainSearchRequest Data Provider Class Variables @3-35691089

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_ID
        Sorter_RECEIPT_NO
        Sorter_SURNAME
        Sorter_FIRST_NAME
        Sorter_YEAR_LEVEL
        Sorter_ENROLMENT_STATUS
        Sorter_ENROLMENT_YEAR
    End Enum

    Private SortFieldsNames As String() = New String() {"","STUDENT_ID","RECEIPT_NO","SURNAME","FIRST_NAME","YEAR_LEVEL","ENROLMENT_STATUS","ENROLMENT_YEAR"}
    Private SortFieldsNamesDesc As String() = New string() {"","STUDENT_ID DESC","RECEIPT_NO DESC","SURNAME DESC","FIRST_NAME DESC","YEAR_LEVEL DESC","ENROLMENT_STATUS DESC","ENROLMENT_YEAR DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 25
    Public PageNumber As Integer = 1
    Public Urls_SURNAME  As TextParameter
    Public Urls_STUDENT_ID  As FloatParameter
    Public Urls_ENROLMENT_YEAR  As FloatParameter
'End Grid viewMaintainSearchRequest Data Provider Class Variables

'Grid viewMaintainSearchRequest Data Provider Class GetResultSet Method @3-529D3C20

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM viewMaintainSearchRequest {SQL_Where} {SQL_OrderBy}", New String(){"(","s_SURNAME50","Or","s_STUDENT_ID51",")","And","s_ENROLMENT_YEAR52","And","expr53"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM viewMaintainSearchRequest", New String(){"(","s_SURNAME50","Or","s_STUDENT_ID51",")","And","s_ENROLMENT_YEAR52","And","expr53"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid viewMaintainSearchRequest Data Provider Class GetResultSet Method

'Grid viewMaintainSearchRequest Data Provider Class GetResultSet Method @3-963C1594
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As viewMaintainSearchRequestItem()
'End Grid viewMaintainSearchRequest Data Provider Class GetResultSet Method

'Before build Select @3-6887EB9F
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_SURNAME50",Urls_SURNAME, "","SURNAME",Condition.BeginsWith,False)
        CType(Select_,TableCommand).AddParameter("s_STUDENT_ID51",Urls_STUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("s_ENROLMENT_YEAR52",Urls_ENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        Select_.Parameters.Add("expr53","(ENROLMENT_STATUS in ('E', 'N', 'F'))")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @3-F017887A
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As viewMaintainSearchRequestItem
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

'DEL      ' -------------------------
'DEL      ' Write your own code here.
'DEL  	'' ERA: 28-Feb-2011|EA| if the returned count = exactly 1 then set redirect to the student ID
'DEL  '	if (ds.Tables(0).Rows.Count = 1 and skippy = "1") then
'DEL  '		' get the details and construct a slightly new redirect url
'DEL  '		dim myRedirectUrl as string
'DEL  '		Dim item as viewMaintainSearchRequestItem = New viewMaintainSearchRequestItem()
'DEL  '		myRedirectUrl = "StudentSummary.aspx?STUDENT_ID=" & (System.Web.HttpUtility.UrlEncode(Urls_STUDENT_ID.ToString())) & "&ENROLMENT_YEAR=" & (System.Web.HttpUtility.UrlEncode(Urls_ENROLMENT_YEAR.ToString()))
'DEL  '
'DEL  '		Response.Redirect(myRedirectUrl)
'DEL  '	end if
'DEL      ' -------------------------


'After execute Select @3-69B8AA1C
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New viewMaintainSearchRequestItem(dr.Count-1) {}
'End After execute Select

'After execute Select @3-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @3-6C21F330
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as viewMaintainSearchRequestItem = New viewMaintainSearchRequestItem()
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.STUDENT_IDHref = "StudentSummary.aspx"
                item.STUDENT_IDHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
                item.STUDENT_IDHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
                item.RECEIPT_NO.SetValue(dr(i)("RECEIPT_NO"),"")
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
                item.ENROLMENT_STATUS.SetValue(dr(i)("ENROLMENT_STATUS"),"")
                item.ENROLMENT_YEAR.SetValue(dr(i)("ENROLMENT_YEAR"),"")
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

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

