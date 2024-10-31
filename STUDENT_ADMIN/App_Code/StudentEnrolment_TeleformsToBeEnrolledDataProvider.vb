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

Namespace DECV_PROD2007.StudentEnrolment_TeleformsToBeEnrolled 'Namespace @1-1BF0C137

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

'EditableGrid NewEditableGrid1 Item Class @5-C31A2C3F
Public Class NewEditableGrid1Item
    Public errors As NameValueCollection = New NameValueCollection()
    Public RowId As Integer
    Private _deleteAllowed As Boolean = False
    Private _isNew As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public NewEditableGrid1_TotalRecords As TextField
    Public STUDENT_ID As FloatField
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public BIRTH_DATE As DateField
    Public CATEGORY_CODE As TextField
    Public LAST_ALTERED_DATE As DateField
    Public TELEFORM_STATUS As TextField
    Public TMP_STUDENT_ID As IntegerField
    Public SUBCATEGORY_CODE As TextField
    Public Sub New()
    NewEditableGrid1_TotalRecords = New TextField("", Nothing)
    STUDENT_ID = New FloatField("", Nothing)
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    BIRTH_DATE = New DateField(Settings.DateFormat, Nothing)
    CATEGORY_CODE = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    TELEFORM_STATUS = New TextField("", Nothing)
    TMP_STUDENT_ID = New IntegerField("", Nothing)
    SUBCATEGORY_CODE = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase
        Get
            Select fieldName
                Case "TMP_STUDENT_IDField"
                    Return Me.TMP_STUDENT_IDField
                Case "NewEditableGrid1_TotalRecords"
                    Return Me.NewEditableGrid1_TotalRecords
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "BIRTH_DATE"
                    Return Me.BIRTH_DATE
                Case "CATEGORY_CODE"
                    Return Me.CATEGORY_CODE
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "TELEFORM_STATUS"
                    Return Me.TELEFORM_STATUS
                Case "TMP_STUDENT_ID"
                    Return Me.TMP_STUDENT_ID
                Case "SUBCATEGORY_CODE"
                    Return Me.SUBCATEGORY_CODE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "TMP_STUDENT_IDField"
                    Me.TMP_STUDENT_IDField = CType(Value,FloatField)
                Case "NewEditableGrid1_TotalRecords"
                    Me.NewEditableGrid1_TotalRecords = CType(Value,TextField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "BIRTH_DATE"
                    Me.BIRTH_DATE = CType(Value,DateField)
                Case "CATEGORY_CODE"
                    Me.CATEGORY_CODE = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "TELEFORM_STATUS"
                    Me.TELEFORM_STATUS = CType(Value,TextField)
                Case "TMP_STUDENT_ID"
                    Me.TMP_STUDENT_ID = CType(Value,IntegerField)
                Case "SUBCATEGORY_CODE"
                    Me.SUBCATEGORY_CODE = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public ReadOnly Property IsDeleteAllowed As Boolean
        Get
            Return  Not(IsEmptyItem) AndAlso _deleteAllowed
        End Get
    End Property

    Public Property IsNew As Boolean
        Get
            Return _isNew
        End Get
        Set
            _isNew = Value
        End Set
    End Property

    Public ReadOnly Property IsEmptyItem As Boolean
        Get
            Dim result As Boolean = True
            result = IsNothing(TMP_STUDENT_ID.Value) And result
            result = IsNothing(TMP_STUDENT_IDField.Value) And result
            Return result
        End Get
    End Property

    Public IsDeleted As Boolean = False
    Public IsUpdated As Boolean = False
    Public TMP_STUDENT_IDField As FloatField = New FloatField()
    Public Function Validate(ByVal provider As NewEditableGrid1DataProvider) As Boolean
'End EditableGrid NewEditableGrid1 Item Class

'TMP_STUDENT_ID validate @34-6812030D
        If IsNothing(TMP_STUDENT_ID.Value) OrElse TMP_STUDENT_ID.Value.ToString() ="" Then
            errors.Add("TMP_STUDENT_ID",String.Format(Resources.strings.CCS_RequiredField,"ID"))
        End If
'End TMP_STUDENT_ID validate

'EditableGrid NewEditableGrid1 Item Class tail @5-11D8DCF0
        Return errors.Count = 0
    End Function
    Public RawData As DataRow = Nothing
End Class
'End EditableGrid NewEditableGrid1 Item Class tail

'EditableGrid NewEditableGrid1 Data Provider Class Header @5-61B169AB
Public Class NewEditableGrid1DataProvider
Inherits EditableGridDataProviderBase
'End EditableGrid NewEditableGrid1 Data Provider Class Header

'Grid NewEditableGrid1 Data Provider Class Variables @5-8EB525D3

    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {"LAST_ALTERED_DATE desc"}
    Private SortFieldsNamesDesc As String() = New string() {"LAST_ALTERED_DATE desc"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 40
    Public PageNumber As Integer = 1
    Public Urls_keyword  As TextParameter
    Public UrlRETURN_VALUE  As IntegerParameter
'End Grid NewEditableGrid1 Data Provider Class Variables

'EditableGrid NewEditableGrid1 Data Provider Class Constructor @5-06C003B9

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} isnull(STUDENT_ID,'New Student')  AS STUDENT_ID, " & vbCrLf & _
          "SURNAME, FIRST_NAME, BIRTH_DATE, CATEGORY_CODE, SUBCATEGORY_CODE, " & vbCrLf & _
          "LAST_ALTERED_DATE," & vbCrLf & _
          "TELEFORM_STATUS, " & vbCrLf & _
          "TMP_STUDENT_ID " & vbCrLf & _
          "FROM TMP_STUDENT {SQL_Where} {SQL_OrderBy}", New String(){"expr16","And","(","s_keyword24","Or","s_keyword25",")"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM TMP_STUDENT", New String(){"expr16","And","(","s_keyword24","Or","s_keyword25",")"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End EditableGrid NewEditableGrid1 Data Provider Class Constructor

'Record NewEditableGrid1 Data Provider Class CheckUnique Method @5-E65984F7

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As NewEditableGrid1Item) As Boolean
        Return True
    End Function
'End Record NewEditableGrid1 Data Provider Class CheckUnique Method

'EditableGrid NewEditableGrid1 Data Provider Class Update Method @5-CEE075DE
    Protected Function UpdateItem(ByVal item As NewEditableGrid1Item) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        Dim Update As DataCommand=new SpCommand("sp_cpyTMP_TABLE_TO_LIVE_Teleforms;1",Settings.connDECVPRODSQL2005DataAccessObject)
'End EditableGrid NewEditableGrid1 Data Provider Class Update Method

'EditableGrid NewEditableGrid1 BeforeBuildUpdate @5-EB0A17A2
        Update.Parameters.Clear()
        CType(Update,SpCommand).AddParameter("@RETURN_VALUE",UrlRETURN_VALUE,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Update,SpCommand).AddParameter("@TMP_STUDENT_ID",item.TMP_STUDENT_IDField,ParameterType._Numeric,ParameterDirection.Input,8,0,0)
'End EditableGrid NewEditableGrid1 BeforeBuildUpdate

'EditableGrid NewEditableGrid1 Execute Update  @5-9DFCE156
        Update.OpType = OperationType.Update
        Dim result As Object = 0
        Dim E As Exception = Nothing
        If CmdExecution Then
            If Not IsParametersPassed Then
                item.errors.Add("DataProvider",Resources.strings.CCS_CustomOperationError_MissingParameters)
                Return 0
            End If
            Try
                result = Update.ExecuteNonQuery()
                UrlRETURN_VALUE = IntegerParameter.GetParam(CType(Update.Parameters("@RETURN_VALUE"),IDataParameter).Value)
            Catch e_ As Exception
                item.errors.Add("DataProvider",e_.Source + ":" + e_.Message)
            Finally
'End EditableGrid NewEditableGrid1 Execute Update 

'EditableGrid NewEditableGrid1 AfterExecuteUpdate @5-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid NewEditableGrid1 AfterExecuteUpdate

'Grid NewEditableGrid1 Data Provider Class GetResultSet Method @5-2CD99D8D
    Public Sub Update(Items As ArrayList, ops As FormSupportedOperations)
        Dim i As Integer
        For i = 0 To Items.Count - 1
            Dim op As EditableGridOperation = EditableGridOperation.Insert
            Dim isProcessed As Boolean = False
            Dim item As NewEditableGrid1Item = CType(Items(i), NewEditableGrid1Item)
'End Grid NewEditableGrid1 Data Provider Class GetResultSet Method

'EditableGrid NewEditableGrid1 Data Provider Class Update @5-B4FF46D4
            If Not item.IsUpdated Then
                If Not(item.IsEmptyItem) And ops.AllowUpdate And Not(isProcessed) Then
                    UpdateItem(item)
                    op = EditableGridOperation.Update
                End If
'End EditableGrid NewEditableGrid1 Data Provider Class Update

'EditableGrid NewEditableGrid1 Data Provider Class AfterUpdate @5-6CCB76B9
                If item.errors.Count = 0 Then item.IsUpdated = True
                OnItemUpdated(New ItemUpdatedEventArgs(op, item))
            End If
        Next i
    End Sub
'End EditableGrid NewEditableGrid1 Data Provider Class AfterUpdate

'EditableGrid NewEditableGrid1 Data Provider Class GetResultSet Method @5-66C8CEE0
    Public Function GetResultSet(ByRef _pagesCount As Integer, ops As FormSupportedOperations) As NewEditableGrid1Item()
'End EditableGrid NewEditableGrid1 Data Provider Class GetResultSet Method

'Before build Select @5-036250D7
        _pagesCount = 0
        Dim E as Exception = Nothing
        Dim j As Integer
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_keyword24",Urls_keyword, "","SURNAME",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword25",Urls_keyword, "","FIRST_NAME",Condition.Contains,False)
        Select_.Parameters.Add("expr16","(LAST_ALTERED_BY='TELEFORM')")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy = SortFieldsNames(CInt(SortField)).Trim
        Else
            Select_.OrderBy = SortFieldsNamesDesc(CInt(SortField)).Trim
        End If
    Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @5-939614DD
        Dim dr As DataRowCollection = Nothing
        Dim rowCount as Integer = 0
        Dim ds As DataSet = Nothing
        If ops.AllowRead Then
            _pagesCount=0
            Try
                If RecordsPerPage>0
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _pagesCount = ExecuteCount()
                    m_recordCount = _pagesCount
                    If _pagesCount Mod RecordsPerPage>0 Then
                        _pagesCount = (_pagesCount\RecordsPerPage)+1
                    Else
                        _pagesCount = _pagesCount\RecordsPerPage
                    End If
                Else
                ds=ExecuteSelect()
                If ds.Tables(tableIndex).Rows.Count<>0 Then 
                    _pagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @5-254FEAB5
                If Not IsNothing(E) Then Throw E
            End Try
            dr = ds.Tables(tableIndex).Rows
            rowCount = dr.Count
        End If
        Dim result(rowCount - 1) As NewEditableGrid1Item
'End After execute Select

'After execute Select tail @5-4F0D6826
        Dim i as Integer
        For i = 0 To rowCount - 1
            Dim item as NewEditableGrid1Item = New NewEditableGrid1Item()
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.SURNAME.SetValue(dr(i)("SURNAME"),"")
            item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
            item.BIRTH_DATE.SetValue(dr(i)("BIRTH_DATE"),Select_.DateFormat)
            item.CATEGORY_CODE.SetValue(dr(i)("CATEGORY_CODE"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.TELEFORM_STATUS.SetValue(dr(i)("TELEFORM_STATUS"),"")
            item.TMP_STUDENT_ID.SetValue(dr(i)("TMP_STUDENT_ID"),"")
            item.SUBCATEGORY_CODE.SetValue(dr(i)("SUBCATEGORY_CODE"),"")
            item.TMP_STUDENT_IDField.SetValue(dr(i)("TMP_STUDENT_ID"),"")
            item.RawData = dr(i)
            result(i)=item
        Next i
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @5-A61BA892
End Class
'End Grid Data Provider tail

'Record TMP_STUDENTSearch Item Class @18-B9818119
Public Class TMP_STUDENTSearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_keyword As TextField
    Public Sub New()
    s_keyword = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As TMP_STUDENTSearchItem
        Dim item As TMP_STUDENTSearchItem = New TMP_STUDENTSearchItem()
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
                Case "s_keyword"
                    Return s_keyword
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
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

    Public Sub Validate(ByVal provider As TMP_STUDENTSearchDataProvider)
'End Record TMP_STUDENTSearch Item Class

'Record TMP_STUDENTSearch Item Class tail @18-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record TMP_STUDENTSearch Item Class tail

'Record TMP_STUDENTSearch Data Provider Class @18-B039586B
Public Class TMP_STUDENTSearchDataProvider
Inherits RecordDataProviderBase
'End Record TMP_STUDENTSearch Data Provider Class

'Record TMP_STUDENTSearch Data Provider Class Variables @18-FB34C5FF
    Protected item As TMP_STUDENTSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record TMP_STUDENTSearch Data Provider Class Variables

'Record TMP_STUDENTSearch Data Provider Class GetResultSet Method @18-6AC48A8E

    Public Sub FillItem(ByVal item As TMP_STUDENTSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record TMP_STUDENTSearch Data Provider Class GetResultSet Method

'Record TMP_STUDENTSearch BeforeBuildSelect @18-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record TMP_STUDENTSearch BeforeBuildSelect

'Record TMP_STUDENTSearch AfterExecuteSelect @18-79426A21
        End If
            IsInsertMode = True
'End Record TMP_STUDENTSearch AfterExecuteSelect

'Record TMP_STUDENTSearch AfterExecuteSelect tail @18-E31F8E2A
    End Sub
'End Record TMP_STUDENTSearch AfterExecuteSelect tail

'Record TMP_STUDENTSearch Data Provider Class @18-A61BA892
End Class

'End Record TMP_STUDENTSearch Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2



