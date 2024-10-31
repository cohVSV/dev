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

Namespace DECV_PROD2007.CONTRIBUTION_list 'Namespace @1-99A29F31

'Page Data Class @1-EDB66B56
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Contrib_insert As TextField
    Public Contrib_insertHref As Object
    Public Contrib_insertHrefParameters As LinkParameterCollection
    Public Sub New()
        Contrib_insert = New TextField("",Nothing)
        Contrib_insertHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Contrib_insert.SetValue(DBUtility.GetInitialValue("Contrib_insert"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Contrib_insert"
                    Return Contrib_insert
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Contrib_insert"
                    Contrib_insert = CType(value, TextField)
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

'Grid CONTRIBUTION Item Class @2-B76FF3EB
Public Class CONTRIBUTIONItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public CONTRIBUTION_Insert As TextField
    Public CONTRIBUTION_InsertHref As Object
    Public CONTRIBUTION_InsertHrefParameters As LinkParameterCollection
    Public CATEGORY_CODE As TextField
    Public CATEGORY_CODEHref As Object
    Public CATEGORY_CODEHrefParameters As LinkParameterCollection
    Public SCHOOL_TYPE_CODE1 As TextField
    Public CAMPUS_CODE1 As TextField
    Public FROM_YEAR_LEVEL As IntegerField
    Public TO_YEAR_LEVEL As IntegerField
    Public PER_SUBJECT_FLAG As BooleanField
    Public DEFAULT_CONTRIBUTION As SingleField
    Public DISCOUNT_AMOUNT As SingleField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Alt_CATEGORY_CODE As TextField
    Public Alt_CATEGORY_CODEHref As Object
    Public Alt_CATEGORY_CODEHrefParameters As LinkParameterCollection
    Public Alt_SCHOOL_TYPE_CODE1 As TextField
    Public Alt_CAMPUS_CODE1 As TextField
    Public Alt_FROM_YEAR_LEVEL As IntegerField
    Public Alt_TO_YEAR_LEVEL As IntegerField
    Public Alt_PER_SUBJECT_FLAG As BooleanField
    Public Alt_DEFAULT_CONTRIBUTION As SingleField
    Public Alt_DISCOUNT_AMOUNT As SingleField
    Public Alt_LAST_ALTERED_BY As TextField
    Public Alt_LAST_ALTERED_DATE As DateField
    Public Sub New()
    CONTRIBUTION_Insert = New TextField("",Nothing)
    CONTRIBUTION_InsertHrefParameters = New LinkParameterCollection()
    CATEGORY_CODE = New TextField("",Nothing)
    CATEGORY_CODEHrefParameters = New LinkParameterCollection()
    SCHOOL_TYPE_CODE1 = New TextField("", Nothing)
    CAMPUS_CODE1 = New TextField("", Nothing)
    FROM_YEAR_LEVEL = New IntegerField("", Nothing)
    TO_YEAR_LEVEL = New IntegerField("", Nothing)
    PER_SUBJECT_FLAG = New BooleanField(Settings.BoolFormat, Nothing)
    DEFAULT_CONTRIBUTION = New SingleField("$0.00", Nothing)
    DISCOUNT_AMOUNT = New SingleField("$0.00", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    Alt_CATEGORY_CODE = New TextField("",Nothing)
    Alt_CATEGORY_CODEHrefParameters = New LinkParameterCollection()
    Alt_SCHOOL_TYPE_CODE1 = New TextField("", Nothing)
    Alt_CAMPUS_CODE1 = New TextField("", Nothing)
    Alt_FROM_YEAR_LEVEL = New IntegerField("", Nothing)
    Alt_TO_YEAR_LEVEL = New IntegerField("", Nothing)
    Alt_PER_SUBJECT_FLAG = New BooleanField(Settings.BoolFormat, Nothing)
    Alt_DEFAULT_CONTRIBUTION = New SingleField("$0.00", Nothing)
    Alt_DISCOUNT_AMOUNT = New SingleField("$0.00", Nothing)
    Alt_LAST_ALTERED_BY = New TextField("", Nothing)
    Alt_LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "CONTRIBUTION_Insert"
                    Return Me.CONTRIBUTION_Insert
                Case "CATEGORY_CODE"
                    Return Me.CATEGORY_CODE
                Case "SCHOOL_TYPE_CODE1"
                    Return Me.SCHOOL_TYPE_CODE1
                Case "CAMPUS_CODE1"
                    Return Me.CAMPUS_CODE1
                Case "FROM_YEAR_LEVEL"
                    Return Me.FROM_YEAR_LEVEL
                Case "TO_YEAR_LEVEL"
                    Return Me.TO_YEAR_LEVEL
                Case "PER_SUBJECT_FLAG"
                    Return Me.PER_SUBJECT_FLAG
                Case "DEFAULT_CONTRIBUTION"
                    Return Me.DEFAULT_CONTRIBUTION
                Case "DISCOUNT_AMOUNT"
                    Return Me.DISCOUNT_AMOUNT
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "Alt_CATEGORY_CODE"
                    Return Me.Alt_CATEGORY_CODE
                Case "Alt_SCHOOL_TYPE_CODE1"
                    Return Me.Alt_SCHOOL_TYPE_CODE1
                Case "Alt_CAMPUS_CODE1"
                    Return Me.Alt_CAMPUS_CODE1
                Case "Alt_FROM_YEAR_LEVEL"
                    Return Me.Alt_FROM_YEAR_LEVEL
                Case "Alt_TO_YEAR_LEVEL"
                    Return Me.Alt_TO_YEAR_LEVEL
                Case "Alt_PER_SUBJECT_FLAG"
                    Return Me.Alt_PER_SUBJECT_FLAG
                Case "Alt_DEFAULT_CONTRIBUTION"
                    Return Me.Alt_DEFAULT_CONTRIBUTION
                Case "Alt_DISCOUNT_AMOUNT"
                    Return Me.Alt_DISCOUNT_AMOUNT
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
                Case "CONTRIBUTION_Insert"
                    Me.CONTRIBUTION_Insert = CType(Value,TextField)
                Case "CATEGORY_CODE"
                    Me.CATEGORY_CODE = CType(Value,TextField)
                Case "SCHOOL_TYPE_CODE1"
                    Me.SCHOOL_TYPE_CODE1 = CType(Value,TextField)
                Case "CAMPUS_CODE1"
                    Me.CAMPUS_CODE1 = CType(Value,TextField)
                Case "FROM_YEAR_LEVEL"
                    Me.FROM_YEAR_LEVEL = CType(Value,IntegerField)
                Case "TO_YEAR_LEVEL"
                    Me.TO_YEAR_LEVEL = CType(Value,IntegerField)
                Case "PER_SUBJECT_FLAG"
                    Me.PER_SUBJECT_FLAG = CType(Value,BooleanField)
                Case "DEFAULT_CONTRIBUTION"
                    Me.DEFAULT_CONTRIBUTION = CType(Value,SingleField)
                Case "DISCOUNT_AMOUNT"
                    Me.DISCOUNT_AMOUNT = CType(Value,SingleField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "Alt_CATEGORY_CODE"
                    Me.Alt_CATEGORY_CODE = CType(Value,TextField)
                Case "Alt_SCHOOL_TYPE_CODE1"
                    Me.Alt_SCHOOL_TYPE_CODE1 = CType(Value,TextField)
                Case "Alt_CAMPUS_CODE1"
                    Me.Alt_CAMPUS_CODE1 = CType(Value,TextField)
                Case "Alt_FROM_YEAR_LEVEL"
                    Me.Alt_FROM_YEAR_LEVEL = CType(Value,IntegerField)
                Case "Alt_TO_YEAR_LEVEL"
                    Me.Alt_TO_YEAR_LEVEL = CType(Value,IntegerField)
                Case "Alt_PER_SUBJECT_FLAG"
                    Me.Alt_PER_SUBJECT_FLAG = CType(Value,BooleanField)
                Case "Alt_DEFAULT_CONTRIBUTION"
                    Me.Alt_DEFAULT_CONTRIBUTION = CType(Value,SingleField)
                Case "Alt_DISCOUNT_AMOUNT"
                    Me.Alt_DISCOUNT_AMOUNT = CType(Value,SingleField)
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
'End Grid CONTRIBUTION Item Class

'Grid CONTRIBUTION Data Provider Class Header @2-EDE4131D
Public Class CONTRIBUTIONDataProvider
Inherits GridDataProviderBase
'End Grid CONTRIBUTION Data Provider Class Header

'Grid CONTRIBUTION Data Provider Class Variables @2-F0A4C6CE

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_CATEGORY_CODE
        Sorter_SCHOOL_TYPE_CODE1
        Sorter_CAMPUS_CODE1
        Sorter_FROM_YEAR_LEVEL
        Sorter_TO_YEAR_LEVEL
        Sorter_PER_SUBJECT_FLAG
        Sorter_DEFAULT_CONTRIBUTION
        Sorter_DISCOUNT_AMOUNT
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE
    End Enum

    Private SortFieldsNames As String() = New String() {"CATEGORY_CODE","CATEGORY_CODE","SCHOOL_TYPE.SCHOOL_TYPE_CODE","CAMPUS.CAMPUS_CODE","FROM_YEAR_LEVEL","TO_YEAR_LEVEL","PER_SUBJECT_FLAG","DEFAULT_CONTRIBUTION","DISCOUNT_AMOUNT","CONTRIBUTION.LAST_ALTERED_BY","CONTRIBUTION.LAST_ALTERED_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"CATEGORY_CODE","CATEGORY_CODE DESC","SCHOOL_TYPE.SCHOOL_TYPE_CODE DESC","CAMPUS.CAMPUS_CODE DESC","FROM_YEAR_LEVEL DESC","TO_YEAR_LEVEL DESC","PER_SUBJECT_FLAG DESC","DEFAULT_CONTRIBUTION DESC","DISCOUNT_AMOUNT DESC","CONTRIBUTION.LAST_ALTERED_BY DESC","CONTRIBUTION.LAST_ALTERED_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 30
    Public PageNumber As Integer = 1
    Public Urls_CATEGORY_CODE  As TextParameter
    Public Urls_CAMPUS_CODE  As TextParameter
'End Grid CONTRIBUTION Data Provider Class Variables

'Grid CONTRIBUTION Data Provider Class GetResultSet Method @2-70CE5B14

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} CONTRIBUTION.CATEGORY_CODE, " & vbCrLf & _
          "CONTRIBUTION.FROM_YEAR_LEVEL, CONTRIBUTION.TO_YEAR_LEVEL, CONTRIBUTION.PER_SUBJECT_FLAG, " & vbCrLf & _
          "CONTRIBUTION.DEFAULT_CONTRIBUTION," & vbCrLf & _
          "CONTRIBUTION.DISCOUNT_AMOUNT, " & vbCrLf & _
          "CONTRIBUTION.LAST_ALTERED_BY AS CONTRIBUTION_LAST_ALTERED_BY, " & vbCrLf & _
          "CONTRIBUTION.LAST_ALTERED_DATE AS CONTRIBUTION_LAST_ALTERED_DATE," & vbCrLf & _
          "SCHOOL_TYPE_CODE, " & vbCrLf & _
          "CAMPUS_CODE " & vbCrLf & _
          "FROM CONTRIBUTION {SQL_Where} {SQL_OrderBy}", New String(){"s_CATEGORY_CODE59","And","s_CAMPUS_CODE60"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM CONTRIBUTION", New String(){"s_CATEGORY_CODE59","And","s_CAMPUS_CODE60"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid CONTRIBUTION Data Provider Class GetResultSet Method

'Grid CONTRIBUTION Data Provider Class GetResultSet Method @2-E568ECC0
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As CONTRIBUTIONItem()
'End Grid CONTRIBUTION Data Provider Class GetResultSet Method

'Before build Select @2-56829E3F
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_CATEGORY_CODE59",Urls_CATEGORY_CODE, "","CATEGORY_CODE",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_CAMPUS_CODE60",Urls_CAMPUS_CODE, "","CAMPUS_CODE",Condition.Contains,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-D998B9CA
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As CONTRIBUTIONItem
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

'After execute Select @2-38AB33A9
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New CONTRIBUTIONItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-77AA0100
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as CONTRIBUTIONItem = New CONTRIBUTIONItem()
                item.CONTRIBUTION_InsertHref = "CONTRIBUTION_maint.aspx"
                item.CATEGORY_CODE.SetValue(dr(i)("CATEGORY_CODE"),"")
                item.CATEGORY_CODEHref = "CONTRIBUTION_maint.aspx"
                item.CATEGORY_CODEHrefParameters.Add("CATEGORY_CODE",System.Web.HttpUtility.UrlEncode(dr(i)("CATEGORY_CODE").ToString()))
                item.CATEGORY_CODEHrefParameters.Add("SCHOOL_TYPE_CODE",System.Web.HttpUtility.UrlEncode(dr(i)("SCHOOL_TYPE_CODE").ToString()))
                item.CATEGORY_CODEHrefParameters.Add("FROM_YEAR_LEVEL",System.Web.HttpUtility.UrlEncode(dr(i)("FROM_YEAR_LEVEL").ToString()))
                item.CATEGORY_CODEHrefParameters.Add("TO_YEAR_LEVEL",System.Web.HttpUtility.UrlEncode(dr(i)("TO_YEAR_LEVEL").ToString()))
                item.CATEGORY_CODEHrefParameters.Add("CAMPUS_CODE",System.Web.HttpUtility.UrlEncode(dr(i)("CAMPUS_CODE").ToString()))
                item.SCHOOL_TYPE_CODE1.SetValue(dr(i)("SCHOOL_TYPE_CODE"),"")
                item.CAMPUS_CODE1.SetValue(dr(i)("CAMPUS_CODE"),"")
                item.FROM_YEAR_LEVEL.SetValue(dr(i)("FROM_YEAR_LEVEL"),"")
                item.TO_YEAR_LEVEL.SetValue(dr(i)("TO_YEAR_LEVEL"),"")
                item.PER_SUBJECT_FLAG.SetValue(dr(i)("PER_SUBJECT_FLAG"),Select_.BoolFormat)
                item.DEFAULT_CONTRIBUTION.SetValue(dr(i)("DEFAULT_CONTRIBUTION"),"")
                item.DISCOUNT_AMOUNT.SetValue(dr(i)("DISCOUNT_AMOUNT"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("CONTRIBUTION_LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("CONTRIBUTION_LAST_ALTERED_DATE"),Select_.DateFormat)
                item.Alt_CATEGORY_CODE.SetValue(dr(i)("CATEGORY_CODE"),"")
                item.Alt_CATEGORY_CODEHref = "CONTRIBUTION_maint.aspx"
                item.Alt_CATEGORY_CODEHrefParameters.Add("CATEGORY_CODE",System.Web.HttpUtility.UrlEncode(dr(i)("CATEGORY_CODE").ToString()))
                item.Alt_CATEGORY_CODEHrefParameters.Add("SCHOOL_TYPE_CODE",System.Web.HttpUtility.UrlEncode(dr(i)("SCHOOL_TYPE_CODE").ToString()))
                item.Alt_CATEGORY_CODEHrefParameters.Add("CAMPUS_CODE",System.Web.HttpUtility.UrlEncode(dr(i)("CAMPUS_CODE").ToString()))
                item.Alt_CATEGORY_CODEHrefParameters.Add("FROM_YEAR_LEVEL",System.Web.HttpUtility.UrlEncode(dr(i)("FROM_YEAR_LEVEL").ToString()))
                item.Alt_CATEGORY_CODEHrefParameters.Add("TO_YEAR_LEVEL",System.Web.HttpUtility.UrlEncode(dr(i)("TO_YEAR_LEVEL").ToString()))
                item.Alt_SCHOOL_TYPE_CODE1.SetValue(dr(i)("SCHOOL_TYPE_CODE"),"")
                item.Alt_CAMPUS_CODE1.SetValue(dr(i)("CAMPUS_CODE"),"")
                item.Alt_FROM_YEAR_LEVEL.SetValue(dr(i)("FROM_YEAR_LEVEL"),"")
                item.Alt_TO_YEAR_LEVEL.SetValue(dr(i)("TO_YEAR_LEVEL"),"")
                item.Alt_PER_SUBJECT_FLAG.SetValue(dr(i)("PER_SUBJECT_FLAG"),Select_.BoolFormat)
                item.Alt_DEFAULT_CONTRIBUTION.SetValue(dr(i)("DEFAULT_CONTRIBUTION"),"")
                item.Alt_DISCOUNT_AMOUNT.SetValue(dr(i)("DISCOUNT_AMOUNT"),"")
                item.Alt_LAST_ALTERED_BY.SetValue(dr(i)("CONTRIBUTION_LAST_ALTERED_BY"),"")
                item.Alt_LAST_ALTERED_DATE.SetValue(dr(i)("CONTRIBUTION_LAST_ALTERED_DATE"),Select_.DateFormat)
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

'Record CONTRIBUTION1 Item Class @57-56614417
Public Class CONTRIBUTION1Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_CATEGORY_CODE As TextField
    Public s_CAMPUS_CODE As TextField
    Public s_CAMPUS_CODEItems As ItemCollection
    Public Sub New()
    s_CATEGORY_CODE = New TextField("", Nothing)
    s_CAMPUS_CODE = New TextField("", "[D]")
    s_CAMPUS_CODEItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As CONTRIBUTION1Item
        Dim item As CONTRIBUTION1Item = New CONTRIBUTION1Item()
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_CATEGORY_CODE")) Then
        item.s_CATEGORY_CODE.SetValue(DBUtility.GetInitialValue("s_CATEGORY_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_CAMPUS_CODE")) Then
        item.s_CAMPUS_CODE.SetValue(DBUtility.GetInitialValue("s_CAMPUS_CODE"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_CATEGORY_CODE"
                    Return s_CATEGORY_CODE
                Case "s_CAMPUS_CODE"
                    Return s_CAMPUS_CODE
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_CATEGORY_CODE"
                    s_CATEGORY_CODE = CType(value, TextField)
                Case "s_CAMPUS_CODE"
                    s_CAMPUS_CODE = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As CONTRIBUTION1DataProvider)
'End Record CONTRIBUTION1 Item Class

'Record CONTRIBUTION1 Item Class tail @57-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record CONTRIBUTION1 Item Class tail

'Record CONTRIBUTION1 Data Provider Class @57-DF4F3CF5
Public Class CONTRIBUTION1DataProvider
Inherits RecordDataProviderBase
'End Record CONTRIBUTION1 Data Provider Class

'Record CONTRIBUTION1 Data Provider Class Variables @57-7D214578
    Protected item As CONTRIBUTION1Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record CONTRIBUTION1 Data Provider Class Variables

'Record CONTRIBUTION1 Data Provider Class GetResultSet Method @57-FC8222FB

    Public Sub FillItem(ByVal item As CONTRIBUTION1Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record CONTRIBUTION1 Data Provider Class GetResultSet Method

'Record CONTRIBUTION1 BeforeBuildSelect @57-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record CONTRIBUTION1 BeforeBuildSelect

'Record CONTRIBUTION1 AfterExecuteSelect @57-79426A21
        End If
            IsInsertMode = True
'End Record CONTRIBUTION1 AfterExecuteSelect

'ListBox s_CAMPUS_CODE AfterExecuteSelect @62-2D27C628
        
item.s_CAMPUS_CODEItems.Add("[D]","VSV")
item.s_CAMPUS_CODEItems.Add("[D,V]","All")
'End ListBox s_CAMPUS_CODE AfterExecuteSelect

'Record CONTRIBUTION1 AfterExecuteSelect tail @57-E31F8E2A
    End Sub
'End Record CONTRIBUTION1 AfterExecuteSelect tail

'Record CONTRIBUTION1 Data Provider Class @57-A61BA892
End Class

'End Record CONTRIBUTION1 Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

