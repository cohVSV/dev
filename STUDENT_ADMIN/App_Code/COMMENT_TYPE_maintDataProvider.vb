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

Namespace DECV_PROD2007.COMMENT_TYPE_maint 'Namespace @1-E267AC9D

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

'Grid COMMENT_TYPE Item Class @5-09B6A501
Public Class COMMENT_TYPEItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public COMMENT_TYPE_Insert As TextField
    Public COMMENT_TYPE_InsertHref As Object
    Public COMMENT_TYPE_InsertHrefParameters As LinkParameterCollection
    Public Detail As TextField
    Public DetailHref As Object
    Public DetailHrefParameters As LinkParameterCollection
    Public COMMENT_TYPE1 As TextField
    Public COMMENT_DESCRIPTION As TextField
    Public STATUS As IntegerField
    Public PUBLIC_FLAG As IntegerField
    Public SPECIAL_FLAG As IntegerField
    Public COMMENT_HELP As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    COMMENT_TYPE_Insert = New TextField("",Nothing)
    COMMENT_TYPE_InsertHrefParameters = New LinkParameterCollection()
    Detail = New TextField("",Nothing)
    DetailHrefParameters = New LinkParameterCollection()
    COMMENT_TYPE1 = New TextField("", Nothing)
    COMMENT_DESCRIPTION = New TextField("", Nothing)
    STATUS = New IntegerField("", Nothing)
    PUBLIC_FLAG = New IntegerField("", Nothing)
    SPECIAL_FLAG = New IntegerField("", Nothing)
    COMMENT_HELP = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "COMMENT_TYPE_Insert"
                    Return Me.COMMENT_TYPE_Insert
                Case "Detail"
                    Return Me.Detail
                Case "COMMENT_TYPE1"
                    Return Me.COMMENT_TYPE1
                Case "COMMENT_DESCRIPTION"
                    Return Me.COMMENT_DESCRIPTION
                Case "STATUS"
                    Return Me.STATUS
                Case "PUBLIC_FLAG"
                    Return Me.PUBLIC_FLAG
                Case "SPECIAL_FLAG"
                    Return Me.SPECIAL_FLAG
                Case "COMMENT_HELP"
                    Return Me.COMMENT_HELP
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "COMMENT_TYPE_Insert"
                    Me.COMMENT_TYPE_Insert = CType(Value,TextField)
                Case "Detail"
                    Me.Detail = CType(Value,TextField)
                Case "COMMENT_TYPE1"
                    Me.COMMENT_TYPE1 = CType(Value,TextField)
                Case "COMMENT_DESCRIPTION"
                    Me.COMMENT_DESCRIPTION = CType(Value,TextField)
                Case "STATUS"
                    Me.STATUS = CType(Value,IntegerField)
                Case "PUBLIC_FLAG"
                    Me.PUBLIC_FLAG = CType(Value,IntegerField)
                Case "SPECIAL_FLAG"
                    Me.SPECIAL_FLAG = CType(Value,IntegerField)
                Case "COMMENT_HELP"
                    Me.COMMENT_HELP = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid COMMENT_TYPE Item Class

'Grid COMMENT_TYPE Data Provider Class Header @5-71D8B63B
Public Class COMMENT_TYPEDataProvider
Inherits GridDataProviderBase
'End Grid COMMENT_TYPE Data Provider Class Header

'Grid COMMENT_TYPE Data Provider Class Variables @5-6C7B710B

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_COMMENT_TYPE
        Sorter_COMMENT_DESCRIPTION
        Sorter_STATUS
        Sorter_PUBLIC_FLAG
        Sorter_SPECIAL_FLAG
        Sorter_COMMENT_HELP
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE
    End Enum

    Private SortFieldsNames As String() = New String() {"","COMMENT_TYPE","COMMENT_DESCRIPTION","STATUS","PUBLIC_FLAG","SPECIAL_FLAG","COMMENT_HELP","LAST_ALTERED_BY","LAST_ALTERED_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"","COMMENT_TYPE DESC","COMMENT_DESCRIPTION DESC","STATUS DESC","PUBLIC_FLAG DESC","SPECIAL_FLAG DESC","COMMENT_HELP DESC","LAST_ALTERED_BY DESC","LAST_ALTERED_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 20
    Public PageNumber As Integer = 1
    Public Urls_keyword  As TextParameter
'End Grid COMMENT_TYPE Data Provider Class Variables

'Grid COMMENT_TYPE Data Provider Class GetResultSet Method @5-A62AC9AF

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} LAST_ALTERED_DATE, LAST_ALTERED_BY, COMMENT_HELP, " & vbCrLf & _
          "SPECIAL_FLAG, PUBLIC_FLAG, STATUS, COMMENT_DESCRIPTION, COMMENT_TYPE, " & vbCrLf & _
          "COMMENT_TYPE_ID " & vbCrLf & _
          "FROM COMMENT_TYPE {SQL_Where} {SQL_OrderBy}", New String(){"s_keyword11",")","Or","s_keyword10","Or","(","s_keyword9"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM COMMENT_TYPE", New String(){"s_keyword11",")","Or","s_keyword10","Or","(","s_keyword9"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid COMMENT_TYPE Data Provider Class GetResultSet Method

'Grid COMMENT_TYPE Data Provider Class GetResultSet Method @5-8A6A6572
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As COMMENT_TYPEItem()
'End Grid COMMENT_TYPE Data Provider Class GetResultSet Method

'Before build Select @5-283D211C
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_keyword11",Urls_keyword, "","COMMENT_HELP",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword10",Urls_keyword, "","COMMENT_DESCRIPTION",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword9",Urls_keyword, "","COMMENT_TYPE",Condition.Contains,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @5-C900920B
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As COMMENT_TYPEItem
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

'After execute Select @5-2BFD6180
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New COMMENT_TYPEItem(dr.Count-1) {}
'End After execute Select

'After execute Select @5-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @5-C4C06F37
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as COMMENT_TYPEItem = New COMMENT_TYPEItem()
                item.COMMENT_TYPE_InsertHref = "COMMENT_TYPE_maint.aspx"
                item.DetailHref = "COMMENT_TYPE_maint.aspx"
                item.DetailHrefParameters.Add("COMMENT_TYPE_ID",System.Web.HttpUtility.UrlEncode(dr(i)("COMMENT_TYPE_ID").ToString()))
                item.COMMENT_TYPE1.SetValue(dr(i)("COMMENT_TYPE"),"")
                item.COMMENT_DESCRIPTION.SetValue(dr(i)("COMMENT_DESCRIPTION"),"")
                item.STATUS.SetValue(dr(i)("STATUS"),"")
                item.PUBLIC_FLAG.SetValue(dr(i)("PUBLIC_FLAG"),"")
                item.SPECIAL_FLAG.SetValue(dr(i)("SPECIAL_FLAG"),"")
                item.COMMENT_HELP.SetValue(dr(i)("COMMENT_HELP"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
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

'Record COMMENT_TYPESearch Item Class @39-E7D80D58
Public Class COMMENT_TYPESearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public s_keyword As TextField
    Public Sub New()
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    s_keyword = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As COMMENT_TYPESearchItem
        Dim item As COMMENT_TYPESearchItem = New COMMENT_TYPESearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_keyword")) Then
        item.s_keyword.SetValue(DBUtility.GetInitialValue("s_keyword"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "ClearParameters"
                    Return ClearParameters
                Case "s_keyword"
                    Return s_keyword
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ClearParameters"
                    ClearParameters = CType(value, TextField)
                Case "s_keyword"
                    s_keyword = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As COMMENT_TYPESearchDataProvider)
'End Record COMMENT_TYPESearch Item Class

'Record COMMENT_TYPESearch Item Class tail @39-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record COMMENT_TYPESearch Item Class tail

'Record COMMENT_TYPESearch Data Provider Class @39-A7350EC9
Public Class COMMENT_TYPESearchDataProvider
Inherits RecordDataProviderBase
'End Record COMMENT_TYPESearch Data Provider Class

'Record COMMENT_TYPESearch Data Provider Class Variables @39-D058E41E
    Protected item As COMMENT_TYPESearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record COMMENT_TYPESearch Data Provider Class Variables

'Record COMMENT_TYPESearch Data Provider Class GetResultSet Method @39-AC92F438

    Public Sub FillItem(ByVal item As COMMENT_TYPESearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record COMMENT_TYPESearch Data Provider Class GetResultSet Method

'Record COMMENT_TYPESearch BeforeBuildSelect @39-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record COMMENT_TYPESearch BeforeBuildSelect

'Record COMMENT_TYPESearch AfterExecuteSelect @39-79426A21
        End If
            IsInsertMode = True
'End Record COMMENT_TYPESearch AfterExecuteSelect

'Record COMMENT_TYPESearch AfterExecuteSelect tail @39-E31F8E2A
    End Sub
'End Record COMMENT_TYPESearch AfterExecuteSelect tail

'Record COMMENT_TYPESearch Data Provider Class @39-A61BA892
End Class

'End Record COMMENT_TYPESearch Data Provider Class

'Record COMMENT_TYPE1 Item Class @44-6A113E68
Public Class COMMENT_TYPE1Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public COMMENT_TYPE2 As TextField
    Public COMMENT_DESCRIPTION As TextField
    Public PUBLIC_FLAG As IntegerField
    Public PUBLIC_FLAGItems As ItemCollection
    Public SPECIAL_FLAG As IntegerField
    Public SPECIAL_FLAGItems As ItemCollection
    Public STATUS As IntegerField
    Public STATUSItems As ItemCollection
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public COMMENT_HELP As TextField
    Public lblCOMMENT_TYPE As TextField
    Public Sub New()
    COMMENT_TYPE2 = New TextField("", Nothing)
    COMMENT_DESCRIPTION = New TextField("", Nothing)
    PUBLIC_FLAG = New IntegerField("", 0)
    PUBLIC_FLAGItems = New ItemCollection()
    SPECIAL_FLAG = New IntegerField("", 0)
    SPECIAL_FLAGItems = New ItemCollection()
    STATUS = New IntegerField("", 1)
    STATUSItems = New ItemCollection()
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    COMMENT_HELP = New TextField("", Nothing)
    lblCOMMENT_TYPE = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As COMMENT_TYPE1Item
        Dim item As COMMENT_TYPE1Item = New COMMENT_TYPE1Item()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COMMENT_TYPE2")) Then
        item.COMMENT_TYPE2.SetValue(DBUtility.GetInitialValue("COMMENT_TYPE2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COMMENT_DESCRIPTION")) Then
        item.COMMENT_DESCRIPTION.SetValue(DBUtility.GetInitialValue("COMMENT_DESCRIPTION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PUBLIC_FLAG")) Then
        item.PUBLIC_FLAG.SetValue(DBUtility.GetInitialValue("PUBLIC_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SPECIAL_FLAG")) Then
        item.SPECIAL_FLAG.SetValue(DBUtility.GetInitialValue("SPECIAL_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STATUS")) Then
        item.STATUS.SetValue(DBUtility.GetInitialValue("STATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COMMENT_HELP")) Then
        item.COMMENT_HELP.SetValue(DBUtility.GetInitialValue("COMMENT_HELP"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblCOMMENT_TYPE")) Then
        item.lblCOMMENT_TYPE.SetValue(DBUtility.GetInitialValue("lblCOMMENT_TYPE"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "COMMENT_TYPE2"
                    Return COMMENT_TYPE2
                Case "COMMENT_DESCRIPTION"
                    Return COMMENT_DESCRIPTION
                Case "PUBLIC_FLAG"
                    Return PUBLIC_FLAG
                Case "SPECIAL_FLAG"
                    Return SPECIAL_FLAG
                Case "STATUS"
                    Return STATUS
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "COMMENT_HELP"
                    Return COMMENT_HELP
                Case "lblCOMMENT_TYPE"
                    Return lblCOMMENT_TYPE
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "COMMENT_TYPE2"
                    COMMENT_TYPE2 = CType(value, TextField)
                Case "COMMENT_DESCRIPTION"
                    COMMENT_DESCRIPTION = CType(value, TextField)
                Case "PUBLIC_FLAG"
                    PUBLIC_FLAG = CType(value, IntegerField)
                Case "SPECIAL_FLAG"
                    SPECIAL_FLAG = CType(value, IntegerField)
                Case "STATUS"
                    STATUS = CType(value, IntegerField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "COMMENT_HELP"
                    COMMENT_HELP = CType(value, TextField)
                Case "lblCOMMENT_TYPE"
                    lblCOMMENT_TYPE = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As COMMENT_TYPE1DataProvider)
'End Record COMMENT_TYPE1 Item Class

'COMMENT_TYPE2 validate @50-567573EE
        If IsNothing(COMMENT_TYPE2.Value) OrElse COMMENT_TYPE2.Value.ToString() ="" Then
            errors.Add("COMMENT_TYPE2",String.Format(Resources.strings.CCS_RequiredField,"COMMENT TYPE"))
        End If
        If (Not IsNothing(COMMENT_TYPE2)) And (Not provider.CheckUnique("COMMENT_TYPE2",Me)) Then
                errors.Add("COMMENT_TYPE2", String.Format(Resources.strings.CCS_UniqueValue,"COMMENT TYPE"))
        End If
'End COMMENT_TYPE2 validate

'PUBLIC_FLAG validate @52-CED1650C
        If IsNothing(PUBLIC_FLAG.Value) OrElse PUBLIC_FLAG.Value.ToString() ="" Then
            errors.Add("PUBLIC_FLAG",String.Format(Resources.strings.CCS_RequiredField,"PUBLIC FLAG"))
        End If
'End PUBLIC_FLAG validate

'SPECIAL_FLAG validate @53-46EA79FB
        If IsNothing(SPECIAL_FLAG.Value) OrElse SPECIAL_FLAG.Value.ToString() ="" Then
            errors.Add("SPECIAL_FLAG",String.Format(Resources.strings.CCS_RequiredField,"SPECIAL FLAG"))
        End If
'End SPECIAL_FLAG validate

'STATUS validate @54-73C7378E
        If IsNothing(STATUS.Value) OrElse STATUS.Value.ToString() ="" Then
            errors.Add("STATUS",String.Format(Resources.strings.CCS_RequiredField,"STATUS"))
        End If
'End STATUS validate

'Record COMMENT_TYPE1 Item Class tail @44-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record COMMENT_TYPE1 Item Class tail

'Record COMMENT_TYPE1 Data Provider Class @44-1F903210
Public Class COMMENT_TYPE1DataProvider
Inherits RecordDataProviderBase
'End Record COMMENT_TYPE1 Data Provider Class

'Record COMMENT_TYPE1 Data Provider Class Variables @44-CF4CC27E
    Public UrlCOMMENT_TYPE_ID As IntegerParameter
    Protected item As COMMENT_TYPE1Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record COMMENT_TYPE1 Data Provider Class Variables

'Record COMMENT_TYPE1 Data Provider Class Constructor @44-B9A7BF63

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM COMMENT_TYPE {SQL_Where} {SQL_OrderBy}", New String(){"COMMENT_TYPE_ID49"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record COMMENT_TYPE1 Data Provider Class Constructor

'Record COMMENT_TYPE1 Data Provider Class LoadParams Method @44-914325DB

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlCOMMENT_TYPE_ID))
    End Function
'End Record COMMENT_TYPE1 Data Provider Class LoadParams Method

'Record COMMENT_TYPE1 Data Provider Class CheckUnique Method @44-A047E032

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As COMMENT_TYPE1Item) As Boolean
        Dim Check As TableCommand = New TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM COMMENT_TYPE",New String(){"COMMENT_TYPE_ID49"},Settings.connDECVPRODSQL2005DataAccessObject)
        Dim CheckWhere As String = ""
        Select Case ControlName
        Case "COMMENT_TYPE2"
            CheckWhere = "COMMENT_TYPE=" & Check.Dao.ToSql(item.COMMENT_TYPE2.GetFormattedValue(""),FieldType._Text)
        End Select
        Check.Where = CheckWhere
        Check.Operation = "AND NOT"
        Check.Parameters.Clear()
        CType(Check,TableCommand).AddParameter("COMMENT_TYPE_ID49",UrlCOMMENT_TYPE_ID, "","COMMENT_TYPE_ID",Condition.Equal,False)
        If Convert.ToInt32(Check.ExecuteScalar()) > 0 Then
            Return False
        End If
        Return True
    End Function
'End Record COMMENT_TYPE1 Data Provider Class CheckUnique Method

'Record COMMENT_TYPE1 Data Provider Class PrepareInsert Method @44-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record COMMENT_TYPE1 Data Provider Class PrepareInsert Method

'Record COMMENT_TYPE1 Data Provider Class PrepareInsert Method tail @44-E31F8E2A
    End Sub
'End Record COMMENT_TYPE1 Data Provider Class PrepareInsert Method tail

'Record COMMENT_TYPE1 Data Provider Class Insert Method @44-03A7A96A

    Public Function InsertItem(ByVal item As COMMENT_TYPE1Item) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO COMMENT_TYPE({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record COMMENT_TYPE1 Data Provider Class Insert Method

'Record COMMENT_TYPE1 Build insert @44-0FBF668D
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.COMMENT_TYPE2.IsEmpty Then
        allEmptyFlag = item.COMMENT_TYPE2.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "COMMENT_TYPE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.COMMENT_TYPE2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.COMMENT_DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.COMMENT_DESCRIPTION.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "COMMENT_DESCRIPTION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.COMMENT_DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PUBLIC_FLAG.IsEmpty Then
        allEmptyFlag = item.PUBLIC_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PUBLIC_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PUBLIC_FLAG.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.SPECIAL_FLAG.IsEmpty Then
        allEmptyFlag = item.SPECIAL_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SPECIAL_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SPECIAL_FLAG.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STATUS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STATUS.GetFormattedValue(""),FieldType._Integer) & ","
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
        If Not item.COMMENT_HELP.IsEmpty Then
        allEmptyFlag = item.COMMENT_HELP.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "COMMENT_HELP,"
        valuesList = valuesList & Insert.Dao.ToSql(item.COMMENT_HELP.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record COMMENT_TYPE1 Build insert

'Record COMMENT_TYPE1 AfterExecuteInsert @44-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record COMMENT_TYPE1 AfterExecuteInsert

'Record COMMENT_TYPE1 Data Provider Class PrepareUpdate Method @44-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record COMMENT_TYPE1 Data Provider Class PrepareUpdate Method

'Record COMMENT_TYPE1 Data Provider Class PrepareUpdate Method tail @44-E31F8E2A
    End Sub
'End Record COMMENT_TYPE1 Data Provider Class PrepareUpdate Method tail

'Record COMMENT_TYPE1 Data Provider Class Update Method @44-66BEE58A

    Public Function UpdateItem(ByVal item As COMMENT_TYPE1Item) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE COMMENT_TYPE SET {Values}", New String(){"COMMENT_TYPE_ID49"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record COMMENT_TYPE1 Data Provider Class Update Method

'Record COMMENT_TYPE1 BeforeBuildUpdate @44-14A75AD4
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("COMMENT_TYPE_ID49",UrlCOMMENT_TYPE_ID, "","COMMENT_TYPE_ID",Condition.Equal,False)
        If Not item.COMMENT_TYPE2.IsEmpty Then
        allEmptyFlag = item.COMMENT_TYPE2.IsEmpty And allEmptyFlag
        valuesList = valuesList & "COMMENT_TYPE=" + Update.Dao.ToSql(item.COMMENT_TYPE2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.COMMENT_DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.COMMENT_DESCRIPTION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "COMMENT_DESCRIPTION=" + Update.Dao.ToSql(item.COMMENT_DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PUBLIC_FLAG.IsEmpty Then
        allEmptyFlag = item.PUBLIC_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PUBLIC_FLAG=" + Update.Dao.ToSql(item.PUBLIC_FLAG.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.SPECIAL_FLAG.IsEmpty Then
        allEmptyFlag = item.SPECIAL_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SPECIAL_FLAG=" + Update.Dao.ToSql(item.SPECIAL_FLAG.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STATUS=" + Update.Dao.ToSql(item.STATUS.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue("yyyy-MM-dd HH\:mm\:ss"),FieldType._Date) & ","
        End If
        If Not item.COMMENT_HELP.IsEmpty Then
        allEmptyFlag = item.COMMENT_HELP.IsEmpty And allEmptyFlag
        valuesList = valuesList & "COMMENT_HELP=" + Update.Dao.ToSql(item.COMMENT_HELP.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record COMMENT_TYPE1 BeforeBuildUpdate

'Record COMMENT_TYPE1 AfterExecuteUpdate @44-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record COMMENT_TYPE1 AfterExecuteUpdate

'Record COMMENT_TYPE1 Data Provider Class GetResultSet Method @44-28A4D730

    Public Sub FillItem(ByVal item As COMMENT_TYPE1Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record COMMENT_TYPE1 Data Provider Class GetResultSet Method

'Record COMMENT_TYPE1 BeforeBuildSelect @44-97B1C695
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("COMMENT_TYPE_ID49",UrlCOMMENT_TYPE_ID, "","COMMENT_TYPE_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record COMMENT_TYPE1 BeforeBuildSelect

'Record COMMENT_TYPE1 BeforeExecuteSelect @44-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record COMMENT_TYPE1 BeforeExecuteSelect

'Record COMMENT_TYPE1 AfterExecuteSelect @44-A5EA0028
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.COMMENT_TYPE2.SetValue(dr(i)("COMMENT_TYPE"),"")
            item.COMMENT_DESCRIPTION.SetValue(dr(i)("COMMENT_DESCRIPTION"),"")
            item.PUBLIC_FLAG.SetValue(dr(i)("PUBLIC_FLAG"),"")
            item.SPECIAL_FLAG.SetValue(dr(i)("SPECIAL_FLAG"),"")
            item.STATUS.SetValue(dr(i)("STATUS"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),"yyyy-MM-dd HH\:mm\:ss")
            item.COMMENT_HELP.SetValue(dr(i)("COMMENT_HELP"),"")
            item.lblCOMMENT_TYPE.SetValue(dr(i)("COMMENT_TYPE"),"")
        Else
            IsInsertMode = True
        End If
'End Record COMMENT_TYPE1 AfterExecuteSelect

'ListBox PUBLIC_FLAG AfterExecuteSelect @52-3F4CD332
        
item.PUBLIC_FLAGItems.Add("1","Yes (Public)")
item.PUBLIC_FLAGItems.Add("0","No")
'End ListBox PUBLIC_FLAG AfterExecuteSelect

'ListBox SPECIAL_FLAG AfterExecuteSelect @53-87C848EC
        
item.SPECIAL_FLAGItems.Add("1","Yes (Non-Teachers)")
item.SPECIAL_FLAGItems.Add("0","No (Teachers)")
'End ListBox SPECIAL_FLAG AfterExecuteSelect

'ListBox STATUS AfterExecuteSelect @54-BAC365F8
        
item.STATUSItems.Add("1","Active")
item.STATUSItems.Add("0","Inactive")
'End ListBox STATUS AfterExecuteSelect

'Record COMMENT_TYPE1 AfterExecuteSelect tail @44-E31F8E2A
    End Sub
'End Record COMMENT_TYPE1 AfterExecuteSelect tail

'Record COMMENT_TYPE1 Data Provider Class @44-A61BA892
End Class

'End Record COMMENT_TYPE1 Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

