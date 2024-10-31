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

Namespace DECV_PROD2007.Student_VSN_History 'Namespace @1-1B9A654A

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

'DEL  Public Class viewVSNItem 
'DEL  Implements IDataItem
'DEL      Public errors As NameValueCollection = New NameValueCollection()
'DEL      Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'DEL      Public STUDENT_ID As FloatField
'DEL      Public STUDENT_IDHref As Object
'DEL      Public STUDENT_IDHrefParameters As LinkParameterCollection
'DEL      Public SURNAME As TextField
'DEL      Public FIRST_NAME As TextField
'DEL      Public YEAR_LEVEL As IntegerField
'DEL      Public ENROLMENT_STATUS As TextField
'DEL      Public ENROLMENT_YEAR As FloatField
'DEL      Public VSN As TextField
'DEL      Public VSREnrolled As TextField
'DEL      Public VSRVerified As TextField
'DEL      Public Sub New()
'DEL      STUDENT_ID = New FloatField("",Nothing)
'DEL      STUDENT_IDHrefParameters = New LinkParameterCollection()
'DEL      SURNAME = New TextField("", Nothing)
'DEL      FIRST_NAME = New TextField("", Nothing)
'DEL      YEAR_LEVEL = New IntegerField("", Nothing)
'DEL      ENROLMENT_STATUS = New TextField("", Nothing)
'DEL      ENROLMENT_YEAR = New FloatField("", Nothing)
'DEL              VSN = New TextField("", Nothing)
'DEL      VSREnrolled = New TextField("", Nothing)
'DEL      VSRVerified = New TextField("", Nothing)
'DEL      End Sub
'DEL      Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
'DEL          IDataItem.Field
'DEL          Get
'DEL              Select fieldName
'DEL                  Case "STUDENT_ID"
'DEL                      Return Me.STUDENT_ID
'DEL                  Case "SURNAME"
'DEL                      Return Me.SURNAME
'DEL                  Case "FIRST_NAME"
'DEL                      Return Me.FIRST_NAME
'DEL                  Case "YEAR_LEVEL"
'DEL                      Return Me.YEAR_LEVEL
'DEL                  Case "ENROLMENT_STATUS"
'DEL                      Return Me.ENROLMENT_STATUS
'DEL                  Case "ENROLMENT_YEAR"
'DEL                      Return Me.ENROLMENT_YEAR
'DEL                  Case "VSN"
'DEL                      Return Me.VSN
'DEL                  Case "VSREnrolled"
'DEL                      Return Me.VSREnrolled
'DEL                  Case "VSRVerified"
'DEL                      Return Me.VSRVerified
'DEL                  Case Else
'DEL                      Throw New ArgumentOutOfRangeException()
'DEL              End Select
'DEL          End Get
'DEL          Set (ByVal Value As FieldBase)
'DEL              Select fieldName
'DEL                  Case "STUDENT_ID"
'DEL                      Me.STUDENT_ID = CType(Value,FloatField)
'DEL                  Case "SURNAME"
'DEL                      Me.SURNAME = CType(Value,TextField)
'DEL                  Case "FIRST_NAME"
'DEL                      Me.FIRST_NAME = CType(Value,TextField)
'DEL                  Case "YEAR_LEVEL"
'DEL                      Me.YEAR_LEVEL = CType(Value,IntegerField)
'DEL                  Case "ENROLMENT_STATUS"
'DEL                      Me.ENROLMENT_STATUS = CType(Value,TextField)
'DEL                  Case "ENROLMENT_YEAR"
'DEL                      Me.ENROLMENT_YEAR = CType(Value,FloatField)
'DEL                  Case "VSN"
'DEL                      Me.VSN = CType(Value,TextField)
'DEL                  Case "VSREnrolled"
'DEL                      Me.VSREnrolled = CType(Value,TextField)
'DEL                  Case "VSRVerified"
'DEL                      Me.VSRVerified = CType(Value,TextField)
'DEL                  Case Else
'DEL                      Throw New ArgumentOutOfRangeException()
'DEL              End Select
'DEL          End Set
'DEL      End Property
'DEL  
'DEL      Public RawData As DataRow = Nothing
'DEL  End Class

'Record viewSearchVSNHistory Item Class @2-EAB5BD68
Public Class viewSearchVSNHistoryItem
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

    Public Shared Function CreateFromHttpRequest() As viewSearchVSNHistoryItem
        Dim item As viewSearchVSNHistoryItem = New viewSearchVSNHistoryItem()
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

    Public Sub Validate(ByVal provider As viewSearchVSNHistoryDataProvider)
'End Record viewSearchVSNHistory Item Class

'Record viewSearchVSNHistory Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record viewSearchVSNHistory Item Class tail

'Record viewSearchVSNHistory Data Provider Class @2-602BA6D1
Public Class viewSearchVSNHistoryDataProvider
Inherits RecordDataProviderBase
'End Record viewSearchVSNHistory Data Provider Class

'Record viewSearchVSNHistory Data Provider Class Variables @2-9ECEB794
    Protected item As viewSearchVSNHistoryItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record viewSearchVSNHistory Data Provider Class Variables

'Record viewSearchVSNHistory Data Provider Class GetResultSet Method @2-0FFAB3BF

    Public Sub FillItem(ByVal item As viewSearchVSNHistoryItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record viewSearchVSNHistory Data Provider Class GetResultSet Method

'Record viewSearchVSNHistory BeforeBuildSelect @2-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record viewSearchVSNHistory BeforeBuildSelect

'Record viewSearchVSNHistory AfterExecuteSelect @2-79426A21
        End If
            IsInsertMode = True
'End Record viewSearchVSNHistory AfterExecuteSelect

'Record viewSearchVSNHistory AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record viewSearchVSNHistory AfterExecuteSelect tail

'Record viewSearchVSNHistory Data Provider Class @2-A61BA892
End Class

'End Record viewSearchVSNHistory Data Provider Class

'Grid viewVSNTransactions Item Class @11-2DE9C750
Public Class viewVSNTransactionsItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STUDENT_ID As TextField
    Public STUDENT_IDHref As Object
    Public STUDENT_IDHrefParameters As LinkParameterCollection
    Public LastName As TextField
    Public FIRSTNAME As TextField
    Public MiddleName As TextField
    Public BirthDate As TextField
        Public Sex As TextField
    Public VSN As TextField
    Public BatchID As TextField
    Public SeqNum As TextField
    Public Type As TextField
    Public Message As TextField
    Public VSRRegisterrationDate As TextField
    Public ExceptionID As TextField
    Public Sub New()
    STUDENT_ID = New TextField("",Nothing)
    STUDENT_IDHrefParameters = New LinkParameterCollection()
    LastName = New TextField("", Nothing)
    FIRSTNAME = New TextField("", Nothing)
    MiddleName = New TextField("", Nothing)
    BirthDate = New TextField("", Nothing)
            Sex = New TextField("", Nothing)
    VSN = New TextField("", Nothing)
    BatchID = New TextField("", Nothing)
    SeqNum = New TextField("", Nothing)
    Type = New TextField("", Nothing)
    Message = New TextField("", Nothing)
    VSRRegisterrationDate = New TextField("", Nothing)
    ExceptionID = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "LastName"
                    Return Me.LastName
                Case "FIRSTNAME"
                    Return Me.FIRSTNAME
                Case "MiddleName"
                    Return Me.MiddleName
                Case "BirthDate"
                    Return Me.BirthDate
                Case "Sex"
                    Return Me.Sex
                Case "VSN"
                    Return Me.VSN
                Case "BatchID"
                    Return Me.BatchID
                Case "SeqNum"
                    Return Me.SeqNum
                Case "Type"
                    Return Me.Type
                Case "Message"
                    Return Me.Message
                Case "VSRRegisterrationDate"
                    Return Me.VSRRegisterrationDate
                Case "ExceptionID"
                    Return Me.ExceptionID
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,TextField)
                Case "LastName"
                    Me.LastName = CType(Value,TextField)
                Case "FIRSTNAME"
                    Me.FIRSTNAME = CType(Value,TextField)
                Case "MiddleName"
                    Me.MiddleName = CType(Value,TextField)
                Case "BirthDate"
                    Me.BirthDate = CType(Value,TextField)
                Case "Sex"
                        Me.Sex = CType(Value, TextField)
                Case "VSN"
                    Me.VSN = CType(Value,TextField)
                Case "BatchID"
                    Me.BatchID = CType(Value,TextField)
                Case "SeqNum"
                    Me.SeqNum = CType(Value,TextField)
                Case "Type"
                    Me.Type = CType(Value,TextField)
                Case "Message"
                    Me.Message = CType(Value,TextField)
                Case "VSRRegisterrationDate"
                    Me.VSRRegisterrationDate = CType(Value,TextField)
                Case "ExceptionID"
                    Me.ExceptionID = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid viewVSNTransactions Item Class

'Grid viewVSNTransactions Data Provider Class Header @11-DA6E2F94
Public Class viewVSNTransactionsDataProvider
Inherits GridDataProviderBase
'End Grid viewVSNTransactions Data Provider Class Header

'Grid viewVSNTransactions Data Provider Class Variables @11-97971B6D

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_ID
        Sorter_LastName
        Sorter_FIRSTNAME
        Sorter_MiddleName
        Sorter_BirthDate
        Sorter_Gender
        Sorter_VSN1
        Sorter_BatchID
        Sorter_SequenceNo
        Sorter_Type
        Sorter_Message
        Sorter_ExceptionID
        Sorter_VSRRegisterrationDate
    End Enum

    Private SortFieldsNames As String() = New String() {"","Student_ID","LastName","FirstName","MiddleName","DOB","Gender","VSN","BatchID","SequenceNumber","Type","Message","ExceptionID","VSRRegisterrationDate"}
    Private SortFieldsNamesDesc As String() = New string() {"","Student_ID DESC","LastName DESC","FirstName DESC","MiddleName DESC","DOB DESC","Gender DESC","VSN DESC","BatchID DESC","SequenceNumber DESC","Type DESC","Message DESC","ExceptionID DESC","VSRRegisterrationDate DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 25
    Public PageNumber As Integer = 1
    Public Urls_ENROLMENT_YEAR  As FloatParameter
    Public Urls_STUDENT_ID  As FloatParameter
    Public Urls_SURNAME  As TextParameter
    Public Urls_STUDENT_VSN  As TextParameter
'End Grid viewVSNTransactions Data Provider Class Variables

'Grid viewVSNTransactions Data Provider Class GetResultSet Method @11-CC18E988

    Public Sub New()
            Select_ = New TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
              "FROM view_StudentVSNHistory {SQL_Where} {SQL_OrderBy}", New String() {"(", "s_STUDENT_ID43", "Or", "s_SURNAME44", "Or", "s_STUDENT_VSN45", ")", "And", "s_ENROLMENT_YEAR46"}, Settings.connDECVPRODSQL2005DataAccessObject)
            Count = New TableCommand("SELECT COUNT(*)" & vbCrLf & _
              "FROM view_StudentVSNHistory", New String() {"(", "s_STUDENT_ID43", "Or", "s_SURNAME44", "Or", "s_STUDENT_VSN45", ")", "And", "s_ENROLMENT_YEAR46"}, Settings.connDECVPRODSQL2005DataAccessObject, True)
    End Sub
'End Grid viewVSNTransactions Data Provider Class GetResultSet Method

'Grid viewVSNTransactions Data Provider Class GetResultSet Method @11-EBEE65A1
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As viewVSNTransactionsItem()
'End Grid viewVSNTransactions Data Provider Class GetResultSet Method

'Before build Select @11-01332DEB
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_STUDENT_ID43",Urls_STUDENT_ID, "","Student_ID",Condition.Equal,False)
            CType(Select_, TableCommand).AddParameter("s_SURNAME44", Urls_SURNAME, "", "LastName", Condition.BeginsWith, False)
        CType(Select_,TableCommand).AddParameter("s_STUDENT_VSN45",Urls_STUDENT_VSN, "","VSN",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("s_ENROLMENT_YEAR46",Urls_ENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @11-D192DA92
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As viewVSNTransactionsItem
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

'After execute Select @11-FD80F82B
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New viewVSNTransactionsItem(dr.Count-1) {}
'End After execute Select

'After execute Select @11-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @11-F8E16218
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as viewVSNTransactionsItem = New viewVSNTransactionsItem()
                item.STUDENT_ID.SetValue(dr(i)("Student_ID"),"")
                item.STUDENT_IDHref = "StudentSummary.aspx"
                item.STUDENT_IDHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
                item.STUDENT_IDHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
                item.LastName.SetValue(dr(i)("LastName"),"")
                item.FIRSTNAME.SetValue(dr(i)("FirstName"),"")
                item.MiddleName.SetValue(dr(i)("MiddleName"),"")
                item.BirthDate.SetValue(dr(i)("DOB"),"")
                item.VSN.SetValue(dr(i)("VSN"),"")
                item.BatchID.SetValue(dr(i)("BatchID"),"")
                item.SeqNum.SetValue(dr(i)("SequenceNumber"),"")
                item.Type.SetValue(dr(i)("Type"),"")
                item.Message.SetValue(dr(i)("Message"),"")
                item.VSRRegisterrationDate.SetValue(dr(i)("VSRRegisterrationDate"),"")
                item.ExceptionID.SetValue(dr(i)("ExceptionID"),"")
                item.Sex.SetValue(dr(i)("Gender"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @11-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

