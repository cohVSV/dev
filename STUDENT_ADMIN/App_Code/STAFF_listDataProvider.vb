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

Namespace DECV_PROD2007.STAFF_list 'Namespace @1-47384C0B

'Page Data Class @1-E2383BD0
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Link_AddNew As TextField
    Public Link_AddNewHref As Object
    Public Link_AddNewHrefParameters As LinkParameterCollection
    Public Sub New()
        Link_AddNew = New TextField("",Nothing)
        Link_AddNewHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Link_AddNew.SetValue(DBUtility.GetInitialValue("Link_AddNew"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Link_AddNew"
                    Return Link_AddNew
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link_AddNew"
                    Link_AddNew = CType(value, TextField)
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

'Record STAFFSearch Item Class @2-0C075CFC
Public Class STAFFSearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_keyword As TextField
    Public rbStatus As TextField
    Public rbStatusItems As ItemCollection
    Public Sub New()
    s_keyword = New TextField("", Nothing)
    rbStatus = New TextField("", "[1]")
    rbStatusItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As STAFFSearchItem
        Dim item As STAFFSearchItem = New STAFFSearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_keyword")) Then
        item.s_keyword.SetValue(DBUtility.GetInitialValue("s_keyword"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("rbStatus")) Then
        item.rbStatus.SetValue(DBUtility.GetInitialValue("rbStatus"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_keyword"
                    Return s_keyword
                Case "rbStatus"
                    Return rbStatus
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_keyword"
                    s_keyword = CType(value, TextField)
                Case "rbStatus"
                    rbStatus = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STAFFSearchDataProvider)
'End Record STAFFSearch Item Class

'Record STAFFSearch Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STAFFSearch Item Class tail

'Record STAFFSearch Data Provider Class @2-3C3DAE05
Public Class STAFFSearchDataProvider
Inherits RecordDataProviderBase
'End Record STAFFSearch Data Provider Class

'Record STAFFSearch Data Provider Class Variables @2-06BC70C6
    Protected item As STAFFSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STAFFSearch Data Provider Class Variables

'Record STAFFSearch Data Provider Class GetResultSet Method @2-86B10DE8

    Public Sub FillItem(ByVal item As STAFFSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STAFFSearch Data Provider Class GetResultSet Method

'Record STAFFSearch BeforeBuildSelect @2-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STAFFSearch BeforeBuildSelect

'Record STAFFSearch AfterExecuteSelect @2-79426A21
        End If
            IsInsertMode = True
'End Record STAFFSearch AfterExecuteSelect

'ListBox rbStatus AfterExecuteSelect @74-4E42D61D
        
item.rbStatusItems.Add("[1]","Yes")
item.rbStatusItems.Add("[1,0]","All")
'End ListBox rbStatus AfterExecuteSelect

'Record STAFFSearch AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record STAFFSearch AfterExecuteSelect tail

'Record STAFFSearch Data Provider Class @2-A61BA892
End Class

'End Record STAFFSearch Data Provider Class

'Grid STAFF Item Class @5-920519F6
Public Class STAFFItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STAFF_Insert As TextField
    Public STAFF_InsertHref As Object
    Public STAFF_InsertHrefParameters As LinkParameterCollection
    Public STAFF_ID As TextField
    Public STAFF_IDHref As Object
    Public STAFF_IDHrefParameters As LinkParameterCollection
    Public SURNAME As TextField
    Public FIRSTNAME As TextField
    Public TEACHER_FLAG As BooleanField
    Public GROUP_NAME As TextField
    Public STATUS As BooleanField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Alt_STAFF_ID As TextField
    Public Alt_STAFF_IDHref As Object
    Public Alt_STAFF_IDHrefParameters As LinkParameterCollection
    Public Alt_SURNAME As TextField
    Public Alt_FIRSTNAME As TextField
    Public Alt_TEACHER_FLAG As BooleanField
    Public Alt_GROUP_NAME As TextField
    Public Alt_STATUS As BooleanField
    Public Alt_LAST_ALTERED_BY As TextField
    Public Alt_LAST_ALTERED_DATE As DateField
    Public Sub New()
    STAFF_Insert = New TextField("",Nothing)
    STAFF_InsertHrefParameters = New LinkParameterCollection()
    STAFF_ID = New TextField("",Nothing)
    STAFF_IDHrefParameters = New LinkParameterCollection()
    SURNAME = New TextField("", Nothing)
    FIRSTNAME = New TextField("", Nothing)
    TEACHER_FLAG = New BooleanField(Settings.BoolFormat, Nothing)
    GROUP_NAME = New TextField("", Nothing)
    STATUS = New BooleanField(Settings.BoolFormat, Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    Alt_STAFF_ID = New TextField("",Nothing)
    Alt_STAFF_IDHrefParameters = New LinkParameterCollection()
    Alt_SURNAME = New TextField("", Nothing)
    Alt_FIRSTNAME = New TextField("", Nothing)
    Alt_TEACHER_FLAG = New BooleanField(Settings.BoolFormat, Nothing)
    Alt_GROUP_NAME = New TextField("", Nothing)
    Alt_STATUS = New BooleanField(Settings.BoolFormat, Nothing)
    Alt_LAST_ALTERED_BY = New TextField("", Nothing)
    Alt_LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STAFF_Insert"
                    Return Me.STAFF_Insert
                Case "STAFF_ID"
                    Return Me.STAFF_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRSTNAME"
                    Return Me.FIRSTNAME
                Case "TEACHER_FLAG"
                    Return Me.TEACHER_FLAG
                Case "GROUP_NAME"
                    Return Me.GROUP_NAME
                Case "STATUS"
                    Return Me.STATUS
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "Alt_STAFF_ID"
                    Return Me.Alt_STAFF_ID
                Case "Alt_SURNAME"
                    Return Me.Alt_SURNAME
                Case "Alt_FIRSTNAME"
                    Return Me.Alt_FIRSTNAME
                Case "Alt_TEACHER_FLAG"
                    Return Me.Alt_TEACHER_FLAG
                Case "Alt_GROUP_NAME"
                    Return Me.Alt_GROUP_NAME
                Case "Alt_STATUS"
                    Return Me.Alt_STATUS
                Case "Alt_LAST_ALTERED_BY"
                    Return Me.Alt_LAST_ALTERED_BY
                Case "Alt_LAST_ALTERED_DATE"
                    Return Me.Alt_LAST_ALTERED_DATE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STAFF_Insert"
                    Me.STAFF_Insert = CType(Value,TextField)
                Case "STAFF_ID"
                    Me.STAFF_ID = CType(Value,TextField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRSTNAME"
                    Me.FIRSTNAME = CType(Value,TextField)
                Case "TEACHER_FLAG"
                    Me.TEACHER_FLAG = CType(Value,BooleanField)
                Case "GROUP_NAME"
                    Me.GROUP_NAME = CType(Value,TextField)
                Case "STATUS"
                    Me.STATUS = CType(Value,BooleanField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "Alt_STAFF_ID"
                    Me.Alt_STAFF_ID = CType(Value,TextField)
                Case "Alt_SURNAME"
                    Me.Alt_SURNAME = CType(Value,TextField)
                Case "Alt_FIRSTNAME"
                    Me.Alt_FIRSTNAME = CType(Value,TextField)
                Case "Alt_TEACHER_FLAG"
                    Me.Alt_TEACHER_FLAG = CType(Value,BooleanField)
                Case "Alt_GROUP_NAME"
                    Me.Alt_GROUP_NAME = CType(Value,TextField)
                Case "Alt_STATUS"
                    Me.Alt_STATUS = CType(Value,BooleanField)
                Case "Alt_LAST_ALTERED_BY"
                    Me.Alt_LAST_ALTERED_BY = CType(Value,TextField)
                Case "Alt_LAST_ALTERED_DATE"
                    Me.Alt_LAST_ALTERED_DATE = CType(Value,DateField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STAFF Item Class

'Grid STAFF Data Provider Class Header @5-ACB94AB4
Public Class STAFFDataProvider
Inherits GridDataProviderBase
'End Grid STAFF Data Provider Class Header

'Grid STAFF Data Provider Class Variables @5-6E969D0B

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STAFF_ID
        Sorter_SURNAME
        Sorter_FIRSTNAME
        Sorter_TEACHER_FLAG
        Sorter_GROUP_NAME
        Sorter_STATUS
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE
    End Enum

    Private SortFieldsNames As String() = New String() {"","STAFF_ID","SURNAME","FIRSTNAME","TEACHER_FLAG","GROUP_NAME","STATUS","STAFF.LAST_ALTERED_BY","STAFF.LAST_ALTERED_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"","STAFF_ID DESC","SURNAME DESC","FIRSTNAME DESC","TEACHER_FLAG DESC","GROUP_NAME DESC","STATUS DESC","STAFF.LAST_ALTERED_BY DESC","STAFF.LAST_ALTERED_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 50
    Public PageNumber As Integer = 1
    Public Urls_keyword  As TextParameter
    Public UrlrbStatus  As TextParameter
'End Grid STAFF Data Provider Class Variables

'Grid STAFF Data Provider Class GetResultSet Method @5-52BF2A10

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} STAFF.STAFF_ID, STAFF.SALUTATION, STAFF.SURNAME, " & vbCrLf & _
          "STAFF.FIRSTNAME, STAFF.MIDDLENAME, STAFF.TEACHER_FLAG, " & vbCrLf & _
          "SECURITY_GROUP.GROUP_NAME," & vbCrLf & _
          "STAFF.STATUS, STAFF.LAST_ALTERED_BY AS STAFF_LAST_ALTERED_BY, " & vbCrLf & _
          "STAFF.LAST_ALTERED_DATE AS STAFF_LAST_ALTERED_DATE, " & vbCrLf & _
          "LOGIN_ID " & vbCrLf & _
          "FROM STAFF LEFT JOIN SECURITY_GROUP ON" & vbCrLf & _
          "STAFF.GROUP_ID = SECURITY_GROUP.GROUP_ID {SQL_Where} {SQL_OrderBy}", New String(){"(","s_keyword85","Or","s_keyword86","Or","s_keyword87","Or","s_keyword88",")","And","rbStatus89"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STAFF LEFT JOIN SECURITY_GROUP ON" & vbCrLf & _
          "STAFF.GROUP_ID = SECURITY_GROUP.GROUP_ID", New String(){"(","s_keyword85","Or","s_keyword86","Or","s_keyword87","Or","s_keyword88",")","And","rbStatus89"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid STAFF Data Provider Class GetResultSet Method

'Grid STAFF Data Provider Class GetResultSet Method @5-40C2FBBC
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STAFFItem()
'End Grid STAFF Data Provider Class GetResultSet Method

'Before build Select @5-4AF4ED68
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_keyword85",Urls_keyword, "","STAFF.STAFF_ID",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword86",Urls_keyword, "","STAFF.LOGIN_ID",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword87",Urls_keyword, "","STAFF.SURNAME",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword88",Urls_keyword, "","STAFF.FIRSTNAME",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("rbStatus89",UrlrbStatus, "","STAFF.STATUS",Condition.BeginsWith,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @5-5F3B13C5
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STAFFItem
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

'After execute Select @5-0109DFCD
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STAFFItem(dr.Count-1) {}
'End After execute Select

'After execute Select @5-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @5-2EB774A0
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STAFFItem = New STAFFItem()
                item.STAFF_InsertHref = "STAFF_maint.aspx"
                item.STAFF_ID.SetValue(dr(i)("LOGIN_ID"),"")
                item.STAFF_IDHref = "STAFF_maint.aspx"
                item.STAFF_IDHrefParameters.Add("STAFF_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STAFF_ID").ToString()))
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRSTNAME.SetValue(dr(i)("FIRSTNAME"),"")
                item.TEACHER_FLAG.SetValue(dr(i)("TEACHER_FLAG"),Select_.BoolFormat)
                item.GROUP_NAME.SetValue(dr(i)("GROUP_NAME"),"")
                item.STATUS.SetValue(dr(i)("STATUS"),Select_.BoolFormat)
                item.LAST_ALTERED_BY.SetValue(dr(i)("STAFF_LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("STAFF_LAST_ALTERED_DATE"),Select_.DateFormat)
                item.Alt_STAFF_ID.SetValue(dr(i)("LOGIN_ID"),"")
                item.Alt_STAFF_IDHref = "STAFF_maint.aspx"
                item.Alt_STAFF_IDHrefParameters.Add("STAFF_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STAFF_ID").ToString()))
                item.Alt_SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.Alt_FIRSTNAME.SetValue(dr(i)("FIRSTNAME"),"")
                item.Alt_TEACHER_FLAG.SetValue(dr(i)("TEACHER_FLAG"),Select_.BoolFormat)
                item.Alt_GROUP_NAME.SetValue(dr(i)("GROUP_NAME"),"")
                item.Alt_STATUS.SetValue(dr(i)("STATUS"),Select_.BoolFormat)
                item.Alt_LAST_ALTERED_BY.SetValue(dr(i)("STAFF_LAST_ALTERED_BY"),"")
                item.Alt_LAST_ALTERED_DATE.SetValue(dr(i)("STAFF_LAST_ALTERED_DATE"),Select_.DateFormat)
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @5-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

