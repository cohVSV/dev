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

Namespace DECV_PROD2007.VSREnrolment 'Namespace @1-5272238C

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

'Record viewVSNSearch Item Class @2-8FF9B023
Public Class viewVSNSearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_SURNAME As TextField
    Public s_STUDENT_ID As TextField
    Public s_ENROLMENT_YEAR As IntegerField
    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public s_STUDENT_VSN As TextField
    Public Sub New()
    s_SURNAME = New TextField("", Nothing)
    s_STUDENT_ID = New TextField("", Nothing)
    s_ENROLMENT_YEAR = New IntegerField("", year(now()))
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    s_STUDENT_VSN = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As viewVSNSearchItem
        Dim item As viewVSNSearchItem = New viewVSNSearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("s_SURNAME")) Then
        item.s_SURNAME.SetValue(DBUtility.GetInitialValue("s_SURNAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_STUDENT_ID")) Then
        item.s_STUDENT_ID.SetValue(DBUtility.GetInitialValue("s_STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_ENROLMENT_YEAR")) Then
        item.s_ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("s_ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_STUDENT_VSN")) Then
        item.s_STUDENT_VSN.SetValue(DBUtility.GetInitialValue("s_STUDENT_VSN"))
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
                Case "s_STUDENT_VSN"
                    Return s_STUDENT_VSN
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_SURNAME"
                    s_SURNAME = CType(value, TextField)
                Case "s_STUDENT_ID"
                    s_STUDENT_ID = CType(value, TextField)
                Case "s_ENROLMENT_YEAR"
                    s_ENROLMENT_YEAR = CType(value, IntegerField)
                Case "ClearParameters"
                    ClearParameters = CType(value, TextField)
                Case "s_STUDENT_VSN"
                    s_STUDENT_VSN = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As viewVSNSearchDataProvider)
'End Record viewVSNSearch Item Class

'Record viewVSNSearch Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record viewVSNSearch Item Class tail

'Record viewVSNSearch Data Provider Class @2-1C6EBABC
Public Class viewVSNSearchDataProvider
Inherits RecordDataProviderBase
'End Record viewVSNSearch Data Provider Class

'Record viewVSNSearch Data Provider Class Variables @2-F2059775
    Protected item As viewVSNSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record viewVSNSearch Data Provider Class Variables

'Record viewVSNSearch Data Provider Class GetResultSet Method @2-4E92C180

    Public Sub FillItem(ByVal item As viewVSNSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record viewVSNSearch Data Provider Class GetResultSet Method

'Record viewVSNSearch BeforeBuildSelect @2-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record viewVSNSearch BeforeBuildSelect

'Record viewVSNSearch AfterExecuteSelect @2-79426A21
        End If
            IsInsertMode = True
'End Record viewVSNSearch AfterExecuteSelect

'Record viewVSNSearch AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record viewVSNSearch AfterExecuteSelect tail

'Record viewVSNSearch Data Provider Class @2-A61BA892
End Class

'End Record viewVSNSearch Data Provider Class

'Grid viewVSN Item Class @14-5DC2B090
Public Class viewVSNItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STUDENT_ID As FloatField
    Public STUDENT_IDHref As Object
    Public STUDENT_IDHrefParameters As LinkParameterCollection
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public YEAR_LEVEL As IntegerField
    Public ENROLMENT_STATUS As TextField
    Public ENROLMENT_YEAR As FloatField
    Public VSN As TextField
    Public VSREnrolled As TextField
    Public VSRVerified As TextField
    Public Sub New()
    STUDENT_ID = New FloatField("",Nothing)
    STUDENT_IDHrefParameters = New LinkParameterCollection()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    YEAR_LEVEL = New IntegerField("", Nothing)
    ENROLMENT_STATUS = New TextField("", Nothing)
    ENROLMENT_YEAR = New FloatField("", Nothing)
    VSN = New TextField("", Nothing)
    VSREnrolled = New TextField("", Nothing)
    VSRVerified = New TextField("", Nothing)
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
                Case "YEAR_LEVEL"
                    Return Me.YEAR_LEVEL
                Case "ENROLMENT_STATUS"
                    Return Me.ENROLMENT_STATUS
                Case "ENROLMENT_YEAR"
                    Return Me.ENROLMENT_YEAR
                Case "VSN"
                    Return Me.VSN
                Case "VSREnrolled"
                    Return Me.VSREnrolled
                Case "VSRVerified"
                    Return Me.VSRVerified
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
                Case "YEAR_LEVEL"
                    Me.YEAR_LEVEL = CType(Value,IntegerField)
                Case "ENROLMENT_STATUS"
                    Me.ENROLMENT_STATUS = CType(Value,TextField)
                Case "ENROLMENT_YEAR"
                    Me.ENROLMENT_YEAR = CType(Value,FloatField)
                Case "VSN"
                    Me.VSN = CType(Value,TextField)
                Case "VSREnrolled"
                    Me.VSREnrolled = CType(Value,TextField)
                Case "VSRVerified"
                    Me.VSRVerified = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid viewVSN Item Class

'Grid viewVSN Data Provider Class Header @14-7DB5C7B3
Public Class viewVSNDataProvider
Inherits GridDataProviderBase
'End Grid viewVSN Data Provider Class Header

'Grid viewVSN Data Provider Class Variables @14-36451E7C

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_ID
        Sorter_SURNAME
        Sorter_FIRST_NAME
        Sorter_YEAR_LEVEL
        Sorter_ENROLMENT_STATUS
        Sorter_ENROLMENT_YEAR
        Sorter_VSN1
        Sorter_VSREnrolled
        Sorter_VSRVerified
    End Enum

    Private SortFieldsNames As String() = New String() {"","STUDENT_ID","SURNAME","FIRST_NAME","YEAR_LEVEL","ENROLMENT_STATUS","ENROLMENT_YEAR","VSN","VSREnrolled","Verify"}
    Private SortFieldsNamesDesc As String() = New string() {"","STUDENT_ID DESC","SURNAME DESC","FIRST_NAME DESC","YEAR_LEVEL DESC","ENROLMENT_STATUS DESC","ENROLMENT_YEAR DESC","VSN DESC","VSREnrolled DESC","Verify DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 25
    Public PageNumber As Integer = 1
    Public Urls_Student_ID  As FloatParameter
    Public Urls_SURNAME  As TextParameter
    Public Urls_STUDENT_VSN  As TextParameter
    Public Urls_ENROLMENT_YEAR  As FloatParameter
'End Grid viewVSN Data Provider Class Variables

'Grid viewVSN Data Provider Class GetResultSet Method @14-97B15690

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM viewVSNSearch {SQL_Where} {SQL_OrderBy}", New String(){"(","s_Student_ID55","Or","s_SURNAME56","Or","s_STUDENT_VSN57",")","And","s_ENROLMENT_YEAR58"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM viewVSNSearch", New String(){"(","s_Student_ID55","Or","s_SURNAME56","Or","s_STUDENT_VSN57",")","And","s_ENROLMENT_YEAR58"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid viewVSN Data Provider Class GetResultSet Method

'Grid viewVSN Data Provider Class GetResultSet Method @14-E7517448
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As viewVSNItem()
'End Grid viewVSN Data Provider Class GetResultSet Method

'Before build Select @14-E1DAF911
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_Student_ID55",Urls_Student_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("s_SURNAME56",Urls_SURNAME, "","SURNAME",Condition.BeginsWith,False)
        CType(Select_,TableCommand).AddParameter("s_STUDENT_VSN57",Urls_STUDENT_VSN, "","VSN",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("s_ENROLMENT_YEAR58",Urls_ENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @14-01CD1C63
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As viewVSNItem
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

'After execute Select @14-6C64FB85
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New viewVSNItem(dr.Count-1) {}
'End After execute Select

'After execute Select @14-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @14-D24CF892
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as viewVSNItem = New viewVSNItem()
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.STUDENT_IDHref = "StudentSummary.aspx"
                item.STUDENT_IDHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
                item.STUDENT_IDHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
                item.ENROLMENT_STATUS.SetValue(dr(i)("ENROLMENT_STATUS"),"")
                item.ENROLMENT_YEAR.SetValue(dr(i)("ENROLMENT_YEAR"),"")
                item.VSN.SetValue(dr(i)("VSN"),"")
                item.VSREnrolled.SetValue(dr(i)("VSREnrolled"),"")
                item.VSRVerified.SetValue(dr(i)("Verify"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @14-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

