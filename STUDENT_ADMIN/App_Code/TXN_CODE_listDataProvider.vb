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

Namespace DECV_PROD2007.TXN_CODE_list 'Namespace @1-88108F06

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

'Grid TXN_CODE Item Class @34-A1902ABF
Public Class TXN_CODEItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public TXN_CODE_Insert As TextField
    Public TXN_CODE_InsertHref As Object
    Public TXN_CODE_InsertHrefParameters As LinkParameterCollection
    Public Detail As TextField
    Public DetailHref As Object
    Public DetailHrefParameters As LinkParameterCollection
    Public TXN_CODE1 As TextField
    Public TXN_TYPE As TextField
    Public CR_DR_FLAG As TextField
    Public DESCRIPTION As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    TXN_CODE_Insert = New TextField("",Nothing)
    TXN_CODE_InsertHrefParameters = New LinkParameterCollection()
    Detail = New TextField("",Nothing)
    DetailHrefParameters = New LinkParameterCollection()
    TXN_CODE1 = New TextField("", Nothing)
    TXN_TYPE = New TextField("", Nothing)
    CR_DR_FLAG = New TextField("", Nothing)
    DESCRIPTION = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "TXN_CODE_Insert"
                    Return Me.TXN_CODE_Insert
                Case "Detail"
                    Return Me.Detail
                Case "TXN_CODE1"
                    Return Me.TXN_CODE1
                Case "TXN_TYPE"
                    Return Me.TXN_TYPE
                Case "CR_DR_FLAG"
                    Return Me.CR_DR_FLAG
                Case "DESCRIPTION"
                    Return Me.DESCRIPTION
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
                Case "TXN_CODE_Insert"
                    Me.TXN_CODE_Insert = CType(Value,TextField)
                Case "Detail"
                    Me.Detail = CType(Value,TextField)
                Case "TXN_CODE1"
                    Me.TXN_CODE1 = CType(Value,TextField)
                Case "TXN_TYPE"
                    Me.TXN_TYPE = CType(Value,TextField)
                Case "CR_DR_FLAG"
                    Me.CR_DR_FLAG = CType(Value,TextField)
                Case "DESCRIPTION"
                    Me.DESCRIPTION = CType(Value,TextField)
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
'End Grid TXN_CODE Item Class

'Grid TXN_CODE Data Provider Class Header @34-1B828872
Public Class TXN_CODEDataProvider
Inherits GridDataProviderBase
'End Grid TXN_CODE Data Provider Class Header

'Grid TXN_CODE Data Provider Class Variables @34-FC3B041D

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_TXN_CODE
        Sorter_TXN_TYPE
        Sorter_CR_DR_FLAG
        Sorter_DESCRIPTION
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE
    End Enum

    Private SortFieldsNames As String() = New String() {"","TXN_CODE","TXN_TYPE","CR_DR_FLAG","DESCRIPTION","LAST_ALTERED_BY","LAST_ALTERED_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"","TXN_CODE DESC","TXN_TYPE DESC","CR_DR_FLAG DESC","DESCRIPTION DESC","LAST_ALTERED_BY DESC","LAST_ALTERED_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 20
    Public PageNumber As Integer = 1
'End Grid TXN_CODE Data Provider Class Variables

'Grid TXN_CODE Data Provider Class GetResultSet Method @34-54CAA6E3

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} TXN_CODE, TXN_TYPE, CR_DR_FLAG, DESCRIPTION, " & vbCrLf & _
          "LAST_ALTERED_BY, LAST_ALTERED_DATE " & vbCrLf & _
          "FROM TXN_CODE {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM TXN_CODE", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid TXN_CODE Data Provider Class GetResultSet Method

'Grid TXN_CODE Data Provider Class GetResultSet Method @34-D9C0073D
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As TXN_CODEItem()
'End Grid TXN_CODE Data Provider Class GetResultSet Method

'Before build Select @34-3C363B34
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @34-F5833492
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As TXN_CODEItem
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

'After execute Select @34-0216F164
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New TXN_CODEItem(dr.Count-1) {}
'End After execute Select

'After execute Select @34-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @34-A70D8893
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as TXN_CODEItem = New TXN_CODEItem()
                item.TXN_CODE_InsertHref = "TXN_CODE_list.aspx"
                item.DetailHref = "TXN_CODE_list.aspx"
                item.DetailHrefParameters.Add("TXN_CODE",System.Web.HttpUtility.UrlEncode(dr(i)("TXN_CODE").ToString()))
                item.TXN_CODE1.SetValue(dr(i)("TXN_CODE"),"")
                item.TXN_TYPE.SetValue(dr(i)("TXN_TYPE"),"")
                item.CR_DR_FLAG.SetValue(dr(i)("CR_DR_FLAG"),"")
                item.DESCRIPTION.SetValue(dr(i)("DESCRIPTION"),"")
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

'Grid Data Provider tail @34-A61BA892
End Class
'End Grid Data Provider tail

'Record TXN_CODE1 Item Class @58-914F7D86
Public Class TXN_CODE1Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public TXN_CODE As TextField
    Public TXN_TYPE As TextField
    Public CR_DR_FLAG As TextField
    Public CR_DR_FLAGItems As ItemCollection
    Public DESCRIPTION As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    TXN_CODE = New TextField("", Nothing)
    TXN_TYPE = New TextField("", Nothing)
    CR_DR_FLAG = New TextField("", Nothing)
    CR_DR_FLAGItems = New ItemCollection()
    DESCRIPTION = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy", DateTime.Now)
    End Sub

    Public Shared Function CreateFromHttpRequest() As TXN_CODE1Item
        Dim item As TXN_CODE1Item = New TXN_CODE1Item()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("TXN_CODE")) Then
        item.TXN_CODE.SetValue(DBUtility.GetInitialValue("TXN_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("TXN_TYPE")) Then
        item.TXN_TYPE.SetValue(DBUtility.GetInitialValue("TXN_TYPE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CR_DR_FLAG")) Then
        item.CR_DR_FLAG.SetValue(DBUtility.GetInitialValue("CR_DR_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DESCRIPTION")) Then
        item.DESCRIPTION.SetValue(DBUtility.GetInitialValue("DESCRIPTION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "TXN_CODE"
                    Return TXN_CODE
                Case "TXN_TYPE"
                    Return TXN_TYPE
                Case "CR_DR_FLAG"
                    Return CR_DR_FLAG
                Case "DESCRIPTION"
                    Return DESCRIPTION
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "TXN_CODE"
                    TXN_CODE = CType(value, TextField)
                Case "TXN_TYPE"
                    TXN_TYPE = CType(value, TextField)
                Case "CR_DR_FLAG"
                    CR_DR_FLAG = CType(value, TextField)
                Case "DESCRIPTION"
                    DESCRIPTION = CType(value, TextField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
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

    Public Sub Validate(ByVal provider As TXN_CODE1DataProvider)
'End Record TXN_CODE1 Item Class

'TXN_CODE validate @64-E64FE424
        If IsNothing(TXN_CODE.Value) OrElse TXN_CODE.Value.ToString() ="" Then
            errors.Add("TXN_CODE",String.Format(Resources.strings.CCS_RequiredField,"TXN CODE"))
        End If
'End TXN_CODE validate

'TXN_TYPE validate @65-2192D534
        If IsNothing(TXN_TYPE.Value) OrElse TXN_TYPE.Value.ToString() ="" Then
            errors.Add("TXN_TYPE",String.Format(Resources.strings.CCS_RequiredField,"TXN TYPE"))
        End If
'End TXN_TYPE validate

'CR_DR_FLAG validate @66-6D3AA75B
        If IsNothing(CR_DR_FLAG.Value) OrElse CR_DR_FLAG.Value.ToString() ="" Then
            errors.Add("CR_DR_FLAG",String.Format(Resources.strings.CCS_RequiredField,"CR DR FLAG"))
        End If
'End CR_DR_FLAG validate

'LAST_ALTERED_BY validate @68-256A6854
        If IsNothing(LAST_ALTERED_BY.Value) OrElse LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End LAST_ALTERED_BY validate

'LAST_ALTERED_DATE validate @69-C5989D76
        If IsNothing(LAST_ALTERED_DATE.Value) OrElse LAST_ALTERED_DATE.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED DATE"))
        End If
'End LAST_ALTERED_DATE validate

'Record TXN_CODE1 Item Class tail @58-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record TXN_CODE1 Item Class tail

'Record TXN_CODE1 Data Provider Class @58-AAA027A2
Public Class TXN_CODE1DataProvider
Inherits RecordDataProviderBase
'End Record TXN_CODE1 Data Provider Class

'Record TXN_CODE1 Data Provider Class Variables @58-A9663749
    Public UrlTXN_CODE As TextParameter
    Protected item As TXN_CODE1Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record TXN_CODE1 Data Provider Class Variables

'Record TXN_CODE1 Data Provider Class Constructor @58-7C1C7265

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM TXN_CODE {SQL_Where} {SQL_OrderBy}", New String(){"TXN_CODE63"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record TXN_CODE1 Data Provider Class Constructor

'Record TXN_CODE1 Data Provider Class LoadParams Method @58-C26959F8

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlTXN_CODE))
    End Function
'End Record TXN_CODE1 Data Provider Class LoadParams Method

'Record TXN_CODE1 Data Provider Class CheckUnique Method @58-51978CBD

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As TXN_CODE1Item) As Boolean
        Return True
    End Function
'End Record TXN_CODE1 Data Provider Class CheckUnique Method

'Record TXN_CODE1 Data Provider Class PrepareInsert Method @58-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record TXN_CODE1 Data Provider Class PrepareInsert Method

'Record TXN_CODE1 Data Provider Class PrepareInsert Method tail @58-E31F8E2A
    End Sub
'End Record TXN_CODE1 Data Provider Class PrepareInsert Method tail

'Record TXN_CODE1 Data Provider Class Insert Method @58-FDFC3E44

    Public Function InsertItem(ByVal item As TXN_CODE1Item) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO TXN_CODE({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record TXN_CODE1 Data Provider Class Insert Method

'Record TXN_CODE1 Build insert @58-D6CA541F
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.TXN_CODE.IsEmpty Then
        allEmptyFlag = item.TXN_CODE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "TXN_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.TXN_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.TXN_TYPE.IsEmpty Then
        allEmptyFlag = item.TXN_TYPE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "TXN_TYPE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.TXN_TYPE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CR_DR_FLAG.IsEmpty Then
        allEmptyFlag = item.CR_DR_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CR_DR_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CR_DR_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.DESCRIPTION.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "DESCRIPTION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
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
'End Record TXN_CODE1 Build insert

'Record TXN_CODE1 AfterExecuteInsert @58-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record TXN_CODE1 AfterExecuteInsert

'Record TXN_CODE1 Data Provider Class PrepareUpdate Method @58-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record TXN_CODE1 Data Provider Class PrepareUpdate Method

'Record TXN_CODE1 Data Provider Class PrepareUpdate Method tail @58-E31F8E2A
    End Sub
'End Record TXN_CODE1 Data Provider Class PrepareUpdate Method tail

'Record TXN_CODE1 Data Provider Class Update Method @58-9996411E

    Public Function UpdateItem(ByVal item As TXN_CODE1Item) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE TXN_CODE SET {Values}", New String(){"TXN_CODE63"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record TXN_CODE1 Data Provider Class Update Method

'Record TXN_CODE1 BeforeBuildUpdate @58-6B64CB63
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("TXN_CODE63",UrlTXN_CODE, "","TXN_CODE",Condition.Equal,False)
        If Not item.TXN_CODE.IsEmpty Then
        allEmptyFlag = item.TXN_CODE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "TXN_CODE=" + Update.Dao.ToSql(item.TXN_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.TXN_TYPE.IsEmpty Then
        allEmptyFlag = item.TXN_TYPE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "TXN_TYPE=" + Update.Dao.ToSql(item.TXN_TYPE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CR_DR_FLAG.IsEmpty Then
        allEmptyFlag = item.CR_DR_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CR_DR_FLAG=" + Update.Dao.ToSql(item.CR_DR_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.DESCRIPTION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DESCRIPTION=" + Update.Dao.ToSql(item.DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
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
'End Record TXN_CODE1 BeforeBuildUpdate

'Record TXN_CODE1 AfterExecuteUpdate @58-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record TXN_CODE1 AfterExecuteUpdate

'Record TXN_CODE1 Data Provider Class GetResultSet Method @58-B8ABB937

    Public Sub FillItem(ByVal item As TXN_CODE1Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record TXN_CODE1 Data Provider Class GetResultSet Method

'Record TXN_CODE1 BeforeBuildSelect @58-8D438695
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("TXN_CODE63",UrlTXN_CODE, "","TXN_CODE",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record TXN_CODE1 BeforeBuildSelect

'Record TXN_CODE1 BeforeExecuteSelect @58-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record TXN_CODE1 BeforeExecuteSelect

'Record TXN_CODE1 AfterExecuteSelect @58-FDC76B0F
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.TXN_CODE.SetValue(dr(i)("TXN_CODE"),"")
            item.TXN_TYPE.SetValue(dr(i)("TXN_TYPE"),"")
            item.CR_DR_FLAG.SetValue(dr(i)("CR_DR_FLAG"),"")
            item.DESCRIPTION.SetValue(dr(i)("DESCRIPTION"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
'End Record TXN_CODE1 AfterExecuteSelect

'ListBox CR_DR_FLAG AfterExecuteSelect @66-40EDC06F
        
item.CR_DR_FLAGItems.Add("C","CR")
item.CR_DR_FLAGItems.Add("D","DR")
'End ListBox CR_DR_FLAG AfterExecuteSelect

'Record TXN_CODE1 AfterExecuteSelect tail @58-E31F8E2A
    End Sub
'End Record TXN_CODE1 AfterExecuteSelect tail

'Record TXN_CODE1 Data Provider Class @58-A61BA892
End Class

'End Record TXN_CODE1 Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

