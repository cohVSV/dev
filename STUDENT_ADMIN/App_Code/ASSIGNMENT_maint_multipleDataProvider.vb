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

Namespace DECV_PROD2007.ASSIGNMENT_maint_multiple 'Namespace @1-93FAB6B3

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

'EditableGrid ASSIGNMENT Item Class @3-E9F24860
Public Class ASSIGNMENTItem
    Public errors As NameValueCollection = New NameValueCollection()
    Public RowId As Integer
    Private _deleteAllowed As Boolean = False
    Private _isNew As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public ASSIGNMENT_TotalRecords As TextField
    Public SUBJECT_ID As IntegerField
    Public ASSIGNMENT_ID As IntegerField
    Public DESCRIPTION As TextField
    Public STATUS As BooleanField
    Public STATUSItems As ItemCollection
    Public LAST_ALTERED_DATE As DateField
    Public LAST_ALTERED_BY As TextField
    Public Hidden_LAST_ALTERED_BY As TextField
    Public Hidden_LAST_ALTERED_DATE As TextField
    Public RadioButtonSpecialType As TextField
    Public RadioButtonSpecialTypeItems As ItemCollection
    Public Sub New()
    ASSIGNMENT_TotalRecords = New TextField("", Nothing)
    SUBJECT_ID = New IntegerField("", Nothing)
    ASSIGNMENT_ID = New IntegerField("", Nothing)
    DESCRIPTION = New TextField("", Nothing)
    STATUS = New BooleanField(Settings.BoolFormat, "Yes")
    STATUSItems = New ItemCollection()
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    Hidden_LAST_ALTERED_BY = New TextField("", Nothing)
    Hidden_LAST_ALTERED_DATE = New TextField("", Nothing)
    RadioButtonSpecialType = New TextField("", "")
    RadioButtonSpecialTypeItems = New ItemCollection()
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase
        Get
            Select fieldName
                Case "ASSIGNMENT_IDField"
                    Return Me.ASSIGNMENT_IDField
                Case "SUBJECT_IDField"
                    Return Me.SUBJECT_IDField
                Case "ASSIGNMENT_TotalRecords"
                    Return Me.ASSIGNMENT_TotalRecords
                Case "SUBJECT_ID"
                    Return Me.SUBJECT_ID
                Case "ASSIGNMENT_ID"
                    Return Me.ASSIGNMENT_ID
                Case "DESCRIPTION"
                    Return Me.DESCRIPTION
                Case "STATUS"
                    Return Me.STATUS
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "Hidden_LAST_ALTERED_BY"
                    Return Me.Hidden_LAST_ALTERED_BY
                Case "Hidden_LAST_ALTERED_DATE"
                    Return Me.Hidden_LAST_ALTERED_DATE
                Case "RadioButtonSpecialType"
                    Return Me.RadioButtonSpecialType
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ASSIGNMENT_IDField"
                    Me.ASSIGNMENT_IDField = CType(Value,IntegerField)
                Case "SUBJECT_IDField"
                    Me.SUBJECT_IDField = CType(Value,IntegerField)
                Case "ASSIGNMENT_TotalRecords"
                    Me.ASSIGNMENT_TotalRecords = CType(Value,TextField)
                Case "SUBJECT_ID"
                    Me.SUBJECT_ID = CType(Value,IntegerField)
                Case "ASSIGNMENT_ID"
                    Me.ASSIGNMENT_ID = CType(Value,IntegerField)
                Case "DESCRIPTION"
                    Me.DESCRIPTION = CType(Value,TextField)
                Case "STATUS"
                    Me.STATUS = CType(Value,BooleanField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "Hidden_LAST_ALTERED_BY"
                    Me.Hidden_LAST_ALTERED_BY = CType(Value,TextField)
                Case "Hidden_LAST_ALTERED_DATE"
                    Me.Hidden_LAST_ALTERED_DATE = CType(Value,TextField)
                Case "RadioButtonSpecialType"
                    Me.RadioButtonSpecialType = CType(Value,TextField)
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
            result = IsNothing(DESCRIPTION.Value) And result
            result = IsNothing(STATUS.Value) And result
            result = IsNothing(Hidden_LAST_ALTERED_BY.Value) And result
            result = IsNothing(Hidden_LAST_ALTERED_DATE.Value) And result
            result = IsNothing(RadioButtonSpecialType.Value) And result
            result = IsNothing(ASSIGNMENT_IDField.Value) And result
            Return result
        End Get
    End Property

    Public IsDeleted As Boolean = False
    Public IsUpdated As Boolean = False
    Public ASSIGNMENT_IDField As IntegerField = New IntegerField()
    Public SUBJECT_IDField As IntegerField = New IntegerField()
    Public Function Validate(ByVal provider As ASSIGNMENTDataProvider) As Boolean
'End EditableGrid ASSIGNMENT Item Class

'STATUS validate @29-73C7378E
        If IsNothing(STATUS.Value) OrElse STATUS.Value.ToString() ="" Then
            errors.Add("STATUS",String.Format(Resources.strings.CCS_RequiredField,"STATUS"))
        End If
'End STATUS validate

'EditableGrid ASSIGNMENT Item Class tail @3-11D8DCF0
        Return errors.Count = 0
    End Function
    Public RawData As DataRow = Nothing
End Class
'End EditableGrid ASSIGNMENT Item Class tail

'EditableGrid ASSIGNMENT Data Provider Class Header @3-CD20AF99
Public Class ASSIGNMENTDataProvider
Inherits EditableGridDataProviderBase
'End EditableGrid ASSIGNMENT Data Provider Class Header

'Grid ASSIGNMENT Data Provider Class Variables @3-DBA91727

    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_SUBJECT_ID
        Sorter_ASSIGNMENT_ID
        Sorter_DESCRIPTION
        Sorter_STATUS
        Sorter_LAST_ALTERED_DATE
        Sorter_SpecialType
    End Enum

    Private SortFieldsNames As String() = New String() {"ASSIGNMENT_ID","SUBJECT_ID","ASSIGNMENT_ID","DESCRIPTION","STATUS","LAST_ALTERED_DATE","SPECIAL_TYPE"}
    Private SortFieldsNamesDesc As String() = New string() {"ASSIGNMENT_ID","SUBJECT_ID DESC","ASSIGNMENT_ID DESC","DESCRIPTION DESC","STATUS DESC","LAST_ALTERED_DATE DESC","SPECIAL_TYPE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 50
    Public PageNumber As Integer = 1
    Public Urls_SUBJECT_ID  As IntegerParameter
    Public Urls_SUBJECT_ID_list  As IntegerParameter
    Public Urls_DESCRIPTION  As TextParameter
    Public CtrlDESCRIPTION  As TextParameter
    Public CtrlSTATUS  As BooleanParameter
    Public Expr65  As TextParameter
    Public Expr66  As TextParameter
    Public CtrlRadioButtonSpecialType  As TextParameter
'End Grid ASSIGNMENT Data Provider Class Variables

'EditableGrid ASSIGNMENT Data Provider Class Constructor @3-7A3B000C

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} SUBJECT_ID, ASSIGNMENT_ID, " & vbCrLf & _
          "RTRIM(DESCRIPTION) AS DESCRIPTION, STATUS, LAST_ALTERED_BY, LAST_ALTERED_DATE, ARCHIVE, " & vbCrLf & _
          "SPECIAL_TYPE " & vbCrLf & _
          "FROM ASSIGNMENT {SQL_Where} {SQL_OrderBy}", New String(){"(","s_SUBJECT_ID128","Or","s_SUBJECT_ID_list129",")","And","s_DESCRIPTION130"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM ASSIGNMENT", New String(){"(","s_SUBJECT_ID128","Or","s_SUBJECT_ID_list129",")","And","s_DESCRIPTION130"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End EditableGrid ASSIGNMENT Data Provider Class Constructor

'Record ASSIGNMENT Data Provider Class CheckUnique Method @3-DD038E3E

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As ASSIGNMENTItem) As Boolean
        Return True
    End Function
'End Record ASSIGNMENT Data Provider Class CheckUnique Method

'EditableGrid ASSIGNMENT Data Provider Class Update Method @3-79A3D2D1
    Protected Function UpdateItem(ByVal item As ASSIGNMENTItem) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        IsParametersPassed = Not(IsNothing(item.ASSIGNMENT_IDField) Or IsNothing(item.SUBJECT_IDField))
        Dim Update As DataCommand=new TableCommand("UPDATE ASSIGNMENT SET {Values}", New String(){"ASSIGNMENT_ID55","And","SUBJECT_ID56"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End EditableGrid ASSIGNMENT Data Provider Class Update Method

'EditableGrid ASSIGNMENT BeforeBuildUpdate @3-6DB6CCD6
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("ASSIGNMENT_ID55",item.ASSIGNMENT_IDField, "","ASSIGNMENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("SUBJECT_ID56",item.SUBJECT_IDField, "","SUBJECT_ID",Condition.Equal,False)
        allEmptyFlag = item.DESCRIPTION.IsEmpty And allEmptyFlag
        If Not item.DESCRIPTION.IsEmpty Then
        If IsNothing(item.DESCRIPTION.Value) Then
        valuesList = valuesList & "DESCRIPTION=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "DESCRIPTION=" & Update.Dao.ToSql(item.DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        If IsNothing(item.STATUS.Value) Then
        valuesList = valuesList & "STATUS=" & Update.Dao.ToSql(Nothing,FieldType._Boolean) & ","
        Else
        valuesList = valuesList & "STATUS=" & Update.Dao.ToSql(item.STATUS.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        allEmptyFlag = (Expr65 Is Nothing) And allEmptyFlag
        If Not (Expr65 Is Nothing) Then
        If IsNothing(Expr65) Then
        valuesList = valuesList & "LAST_ALTERED_BY=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "LAST_ALTERED_BY=" & Update.Dao.ToSql(Expr65.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = (Expr66 Is Nothing) And allEmptyFlag
        If Not (Expr66 Is Nothing) Then
        If IsNothing(Expr66) Then
        valuesList = valuesList & "LAST_ALTERED_DATE=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "LAST_ALTERED_DATE=" & Update.Dao.ToSql(Expr66.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.RadioButtonSpecialType.IsEmpty And allEmptyFlag
        If Not item.RadioButtonSpecialType.IsEmpty Then
        If IsNothing(item.RadioButtonSpecialType.Value) Then
        valuesList = valuesList & "SPECIAL_TYPE=" & Update.Dao.ToSql(("").ToString(),FieldType._Text) & ","
        Else
        valuesList = valuesList & "SPECIAL_TYPE=" & Update.Dao.ToSql(item.RadioButtonSpecialType.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
		Update.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
'End EditableGrid ASSIGNMENT BeforeBuildUpdate

'EditableGrid ASSIGNMENT Execute Update  @3-392E25E7
        Update.OpType = OperationType.Update
        Dim result As Object = 0
        Dim E As Exception = Nothing
        If CmdExecution Then
            If Not IsParametersPassed Then
                item.errors.Add("DataProvider",Resources.strings.CCS_CustomOperationError_MissingParameters)
                Return 0
            End If
            Try
                 If Not allEmptyFlag Then result = Update.ExecuteNonQuery()
            Catch e_ As Exception
                item.errors.Add("DataProvider",e_.Source + ":" + e_.Message)
            Finally
'End EditableGrid ASSIGNMENT Execute Update 

'EditableGrid ASSIGNMENT AfterExecuteUpdate @3-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid ASSIGNMENT AfterExecuteUpdate

'Grid ASSIGNMENT Data Provider Class GetResultSet Method @3-F2414EC9
    Public Sub Update(Items As ArrayList, ops As FormSupportedOperations)
        Dim i As Integer
        For i = 0 To Items.Count - 1
            Dim op As EditableGridOperation = EditableGridOperation.Insert
            Dim isProcessed As Boolean = False
            Dim item As ASSIGNMENTItem = CType(Items(i), ASSIGNMENTItem)
'End Grid ASSIGNMENT Data Provider Class GetResultSet Method

'EditableGrid ASSIGNMENT Data Provider Class Update @3-B4FF46D4
            If Not item.IsUpdated Then
                If Not(item.IsEmptyItem) And ops.AllowUpdate And Not(isProcessed) Then
                    UpdateItem(item)
                    op = EditableGridOperation.Update
                End If
'End EditableGrid ASSIGNMENT Data Provider Class Update

'EditableGrid ASSIGNMENT Data Provider Class AfterUpdate @3-6CCB76B9
                If item.errors.Count = 0 Then item.IsUpdated = True
                OnItemUpdated(New ItemUpdatedEventArgs(op, item))
            End If
        Next i
    End Sub
'End EditableGrid ASSIGNMENT Data Provider Class AfterUpdate

'EditableGrid ASSIGNMENT Data Provider Class GetResultSet Method @3-7C3BEDCB
    Public Function GetResultSet(ByRef _pagesCount As Integer, ops As FormSupportedOperations) As ASSIGNMENTItem()
'End EditableGrid ASSIGNMENT Data Provider Class GetResultSet Method

'Before build Select @3-D8F8165E
        _pagesCount = 0
        Dim E as Exception = Nothing
        Dim j As Integer
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_SUBJECT_ID128",Urls_SUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("s_SUBJECT_ID_list129",Urls_SUBJECT_ID_list, "","SUBJECT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("s_DESCRIPTION130",Urls_DESCRIPTION, "","DESCRIPTION",Condition.Contains,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy = SortFieldsNames(CInt(SortField)).Trim
        Else
            Select_.OrderBy = SortFieldsNamesDesc(CInt(SortField)).Trim
        End If
    Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @3-939614DD
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

'After execute Select @3-ED8EBC6C
                If Not IsNothing(E) Then Throw E
            End Try
            dr = ds.Tables(tableIndex).Rows
            rowCount = dr.Count
        End If
        Dim result(rowCount - 1) As ASSIGNMENTItem
'End After execute Select

'ListBox STATUS AfterExecuteSelect @29-6D659A9B
    Dim STATUSItems As ItemCollection = New ItemCollection()
    
STATUSItems.Add("Yes","Active")
STATUSItems.Add("No","Inactive")
'End ListBox STATUS AfterExecuteSelect

'ListBox RadioButtonSpecialType AfterExecuteSelect @124-A97CED19
    Dim RadioButtonSpecialTypeItems As ItemCollection = New ItemCollection()
    
RadioButtonSpecialTypeItems.Add("","No")
RadioButtonSpecialTypeItems.Add("Y","Yes")
'End ListBox RadioButtonSpecialType AfterExecuteSelect

'After execute Select tail @3-14DAB2B3
        Dim i as Integer
        For i = 0 To rowCount - 1
            Dim item as ASSIGNMENTItem = New ASSIGNMENTItem()
            item.SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
            item.ASSIGNMENT_ID.SetValue(dr(i)("ASSIGNMENT_ID"),"")
            item.DESCRIPTION.SetValue(dr(i)("DESCRIPTION"),"")
            item.STATUS.SetValue(dr(i)("STATUS"),Select_.BoolFormat)
            item.STATUSItems = CType(STATUSItems.Clone(), ItemCollection)
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.Hidden_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.Hidden_LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),"")
            item.RadioButtonSpecialType.SetValue(dr(i)("SPECIAL_TYPE"),"")
            item.RadioButtonSpecialTypeItems = CType(RadioButtonSpecialTypeItems.Clone(), ItemCollection)
            item.ASSIGNMENT_IDField.SetValue(dr(i)("ASSIGNMENT_ID"),"")
            item.SUBJECT_IDField.SetValue(dr(i)("SUBJECT_ID"),"")
            item.RawData = dr(i)
            result(i)=item
        Next i
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @3-A61BA892
End Class
'End Grid Data Provider tail

'Record ASSIGNMENTSearch Item Class @37-ECBABE7A
Public Class ASSIGNMENTSearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_SUBJECT_ID As IntegerField
    Public s_DESCRIPTION As TextField
    Public s_SUBJECT_ID_list As IntegerField
    Public s_SUBJECT_ID_listItems As ItemCollection
    Public Sub New()
    s_SUBJECT_ID = New IntegerField("", Nothing)
    s_DESCRIPTION = New TextField("", Nothing)
    s_SUBJECT_ID_list = New IntegerField("", Nothing)
    s_SUBJECT_ID_listItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As ASSIGNMENTSearchItem
        Dim item As ASSIGNMENTSearchItem = New ASSIGNMENTSearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_SUBJECT_ID")) Then
        item.s_SUBJECT_ID.SetValue(DBUtility.GetInitialValue("s_SUBJECT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_DESCRIPTION")) Then
        item.s_DESCRIPTION.SetValue(DBUtility.GetInitialValue("s_DESCRIPTION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_SUBJECT_ID_list")) Then
        item.s_SUBJECT_ID_list.SetValue(DBUtility.GetInitialValue("s_SUBJECT_ID_list"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_SUBJECT_ID"
                    Return s_SUBJECT_ID
                Case "s_DESCRIPTION"
                    Return s_DESCRIPTION
                Case "s_SUBJECT_ID_list"
                    Return s_SUBJECT_ID_list
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_SUBJECT_ID"
                    s_SUBJECT_ID = CType(value, IntegerField)
                Case "s_DESCRIPTION"
                    s_DESCRIPTION = CType(value, TextField)
                Case "s_SUBJECT_ID_list"
                    s_SUBJECT_ID_list = CType(value, IntegerField)
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

    Public Sub Validate(ByVal provider As ASSIGNMENTSearchDataProvider)
'End Record ASSIGNMENTSearch Item Class

'Record ASSIGNMENTSearch Item Class tail @37-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record ASSIGNMENTSearch Item Class tail

'Record ASSIGNMENTSearch Data Provider Class @37-33ABF586
Public Class ASSIGNMENTSearchDataProvider
Inherits RecordDataProviderBase
'End Record ASSIGNMENTSearch Data Provider Class

'Record ASSIGNMENTSearch Data Provider Class Variables @37-1BBBBA08
    Protected s_SUBJECT_ID_listDataCommand As DataCommand=new SqlCommand("select * from view_ReportParams_Subjects {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
    Protected item As ASSIGNMENTSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record ASSIGNMENTSearch Data Provider Class Variables

'Record ASSIGNMENTSearch Data Provider Class GetResultSet Method @37-36BFE085

    Public Sub FillItem(ByVal item As ASSIGNMENTSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record ASSIGNMENTSearch Data Provider Class GetResultSet Method

'Record ASSIGNMENTSearch BeforeBuildSelect @37-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record ASSIGNMENTSearch BeforeBuildSelect

'Record ASSIGNMENTSearch AfterExecuteSelect @37-83591636
        End If
            IsInsertMode = True
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record ASSIGNMENTSearch AfterExecuteSelect

'ListBox s_SUBJECT_ID_list Initialize Data Source @69-DA3B4E22
        s_SUBJECT_ID_listDataCommand.Dao._optimized = False
        Dim s_SUBJECT_ID_listtableIndex As Integer = 0
        s_SUBJECT_ID_listDataCommand.OrderBy = "SUBJECT_TITLE"
        s_SUBJECT_ID_listDataCommand.Parameters.Clear()
'End ListBox s_SUBJECT_ID_list Initialize Data Source

'ListBox s_SUBJECT_ID_list BeforeExecuteSelect @69-CE4AD00A
        Try
            ListBoxSource=s_SUBJECT_ID_listDataCommand.Execute().Tables(s_SUBJECT_ID_listtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox s_SUBJECT_ID_list BeforeExecuteSelect

'ListBox s_SUBJECT_ID_list AfterExecuteSelect @69-AD50AB04
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New IntegerField("", ListBoxSource(j)("SUBJECT_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("subject_displaylabel")
            item.s_SUBJECT_ID_listItems.Add(Key, Val)
        Next
'End ListBox s_SUBJECT_ID_list AfterExecuteSelect

'Record ASSIGNMENTSearch AfterExecuteSelect tail @37-E31F8E2A
    End Sub
'End Record ASSIGNMENTSearch AfterExecuteSelect tail

'Record ASSIGNMENTSearch Data Provider Class @37-A61BA892
End Class

'End Record ASSIGNMENTSearch Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

