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

Namespace DECV_PROD2007.Staff_LAdAllocation_maint 'Namespace @1-27B9FC2B

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

'EditableGrid ManageLADs Item Class @3-72AC0AE1
Public Class ManageLADsItem
    Public errors As NameValueCollection = New NameValueCollection()
    Public RowId As Integer
    Private _deleteAllowed As Boolean = True
    Private _isNew As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public FIRSTNAME As TextField
    Public SURNAME As TextField
    Public lblLastUpdated As DateField
    Public LAD_MAX_ALLOC As IntegerField
    Public checkDelete As BooleanField
    Public checkDeleteCheckedValue As BooleanField
    Public checkDeleteUncheckedValue As BooleanField
    Public lblStaffID As TextField
    Public TotalRecords As TextField
    Public radioYEAR_LEVEL As TextField
    Public radioYEAR_LEVELItems As ItemCollection
    Public Sub New()
    FIRSTNAME = New TextField("", Nothing)
    SURNAME = New TextField("", Nothing)
    lblLastUpdated = New DateField("d MMM yyyy h\:mm tt", Nothing)
    LAD_MAX_ALLOC = New IntegerField("0;(0)", 12)
    checkDelete = New BooleanField(Settings.BoolFormat, False)
    checkDeleteCheckedValue = New BooleanField(Settings.BoolFormat, True)
    checkDeleteUncheckedValue = New BooleanField(Settings.BoolFormat, False)
    lblStaffID = New TextField("", "unknown")
    TotalRecords = New TextField("", Nothing)
    radioYEAR_LEVEL = New TextField("", 0)
    radioYEAR_LEVELItems = New ItemCollection()
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase
        Get
            Select fieldName
                Case "STAFF_IDField"
                    Return Me.STAFF_IDField
                Case "idField"
                    Return Me.idField
                Case "FIRSTNAME"
                    Return Me.FIRSTNAME
                Case "SURNAME"
                    Return Me.SURNAME
                Case "lblLastUpdated"
                    Return Me.lblLastUpdated
                Case "LAD_MAX_ALLOC"
                    Return Me.LAD_MAX_ALLOC
                Case "checkDelete"
                    Return Me.checkDelete
                Case "lblStaffID"
                    Return Me.lblStaffID
                Case "TotalRecords"
                    Return Me.TotalRecords
                Case "radioYEAR_LEVEL"
                    Return Me.radioYEAR_LEVEL
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STAFF_IDField"
                    Me.STAFF_IDField = CType(Value,TextField)
                Case "idField"
                    Me.idField = CType(Value,IntegerField)
                Case "FIRSTNAME"
                    Me.FIRSTNAME = CType(Value,TextField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "lblLastUpdated"
                    Me.lblLastUpdated = CType(Value,DateField)
                Case "LAD_MAX_ALLOC"
                    Me.LAD_MAX_ALLOC = CType(Value,IntegerField)
                Case "checkDelete"
                    Me.checkDelete = CType(Value,BooleanField)
                Case "lblStaffID"
                    Me.lblStaffID = CType(Value,TextField)
                Case "TotalRecords"
                    Me.TotalRecords = CType(Value,TextField)
                Case "radioYEAR_LEVEL"
                    Me.radioYEAR_LEVEL = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public  Property IsDeleteAllowed As Boolean
        Get
            Return  Not(IsEmptyItem) AndAlso _deleteAllowed
        End Get
        Set
            _deleteAllowed = Value
        End Set
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
            result = IsNothing(LAD_MAX_ALLOC.Value) And result
            result = IsNothing(checkDelete.Value) And result
            result = IsNothing(radioYEAR_LEVEL.Value) And result
            Return result
        End Get
    End Property

    Public IsDeleted As Boolean = False
    Public IsUpdated As Boolean = False
    Public STAFF_IDField As TextField = New TextField()
    Public idField As IntegerField = New IntegerField()
    Public Function Validate(ByVal provider As ManageLADsDataProvider) As Boolean
'End EditableGrid ManageLADs Item Class

'LAD_MAX_ALLOC validate @344-07463F7F
        If IsNothing(LAD_MAX_ALLOC.Value) OrElse LAD_MAX_ALLOC.Value.ToString() ="" Then
            errors.Add("LAD_MAX_ALLOC",String.Format(Resources.strings.CCS_RequiredField,"Max. Students"))
        End If
'End LAD_MAX_ALLOC validate

'TextBox LAD_MAX_ALLOC Event OnValidate. Action Validate Minimum Value @345-33C1F29E
        If Not (LAD_MAX_ALLOC.Value Is Nothing) Then
            If Convert.ToDouble(LAD_MAX_ALLOC.Value) < 0 Then
            errors.Add("LAD_MAX_ALLOC",String.Format("Maximum Students must be 0 or greater","Max. Students","0"))
            End If
        End If
'End TextBox LAD_MAX_ALLOC Event OnValidate. Action Validate Minimum Value

'TextBox LAD_MAX_ALLOC Event OnValidate. Action Validate Maximum Value @346-ECDCD8A7
        If Not (LAD_MAX_ALLOC.Value Is Nothing) Then
            If Convert.ToDouble(LAD_MAX_ALLOC.Value) > 28 Then
            errors.Add("LAD_MAX_ALLOC",String.Format("Maximum Students must not exceed 28","Max. Students","28"))
            End If
        End If
'End TextBox LAD_MAX_ALLOC Event OnValidate. Action Validate Maximum Value

'radioYEAR_LEVEL validate @562-17B0D920
        If IsNothing(radioYEAR_LEVEL.Value) OrElse radioYEAR_LEVEL.Value.ToString() ="" Then
            errors.Add("radioYEAR_LEVEL",String.Format(Resources.strings.CCS_RequiredField,"Year Level"))
        End If
'End radioYEAR_LEVEL validate

'EditableGrid ManageLADs Item Class tail @3-11D8DCF0
        Return errors.Count = 0
    End Function
    Public RawData As DataRow = Nothing
End Class
'End EditableGrid ManageLADs Item Class tail

'EditableGrid ManageLADs Data Provider Class Header @3-16FAB9ED
Public Class ManageLADsDataProvider
Inherits EditableGridDataProviderBase
'End EditableGrid ManageLADs Data Provider Class Header

'Grid ManageLADs Data Provider Class Variables @3-FF719CA6

    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_SCAFFOLD_COURSEDEV_UPDATED
    End Enum

    Private SortFieldsNames As String() = New String() {"SURNAME","STAFF_LAD_ALLOCATION.LAST_ALTERED_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"SURNAME","STAFF_LAD_ALLOCATION.LAST_ALTERED_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 40
    Public PageNumber As Integer = 1
    Public Urls_keyword  As TextParameter
    Public UrlrbShow  As IntegerParameter
    Public Expr398  As DateParameter
    Public CtrlLAD_MAX_ALLOC  As IntegerParameter
    Public Expr497  As TextParameter
    Public CtrlradioYEAR_LEVEL  As IntegerParameter
'End Grid ManageLADs Data Provider Class Variables

'EditableGrid ManageLADs Data Provider Class Constructor @3-08643E8B

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} LAD_MAX_ALLOC, " & vbCrLf & _
          "STAFF_LAD_ALLOCATION.LAST_ALTERED_DATE AS STAFF_LAD_ALLOCATION_LAST_ALTERED_DATE, " & vbCrLf & _
          "rtrim(SURNAME) AS STAFF_SURNAME," & vbCrLf & _
          "rtrim(FIRSTNAME) AS STAFF_FIRSTNAME, STAFF_LAD_ALLOCATION.STAFF_ID, YEAR_LEVEL, " & vbCrLf & _
          "id " & vbCrLf & _
          "FROM STAFF INNER JOIN STAFF_LAD_ALLOCATION ON" & vbCrLf & _
          "STAFF.STAFF_ID = STAFF_LAD_ALLOCATION.STAFF_ID {SQL_Where} {SQL_OrderBy}", New String(){"(","(","s_keyword617","Or","s_keyword618","Or","s_keyword619",")",")","And","rbShow620"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STAFF INNER JOIN STAFF_LAD_ALLOCATION ON" & vbCrLf & _
          "STAFF.STAFF_ID = STAFF_LAD_ALLOCATION.STAFF_ID", New String(){"(","(","s_keyword617","Or","s_keyword618","Or","s_keyword619",")",")","And","rbShow620"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End EditableGrid ManageLADs Data Provider Class Constructor

'Record ManageLADs Data Provider Class CheckUnique Method @3-A26DBD7E

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As ManageLADsItem) As Boolean
        Return True
    End Function
'End Record ManageLADs Data Provider Class CheckUnique Method

'EditableGrid ManageLADs Data Provider Class Update Method @3-75D8D970
    Protected Function UpdateItem(ByVal item As ManageLADsItem) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        IsParametersPassed = Not(IsNothing(item.STAFF_IDField) Or IsNothing(item.idField))
        Dim Update As DataCommand=new TableCommand("UPDATE STAFF_LAD_ALLOCATION SET {Values}", New String(){"STAFF_ID204","And","id613"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End EditableGrid ManageLADs Data Provider Class Update Method

'EditableGrid ManageLADs BeforeBuildUpdate @3-588644C0
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STAFF_ID204",item.STAFF_IDField, "","STAFF_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("id613",item.idField, "","id",Condition.Equal,False)
        allEmptyFlag = (Expr398 Is Nothing) And allEmptyFlag
        If Not (Expr398 Is Nothing) Then
        If IsNothing(Expr398) Then
        valuesList = valuesList & "LAST_ALTERED_DATE=" & Update.Dao.ToSql((NOW()).ToString(),FieldType._Date) & ","
        Else
        valuesList = valuesList & "LAST_ALTERED_DATE=" & Update.Dao.ToSql(Expr398.GetFormattedValue("yyyy-MM-dd HH\:mm\:ss"),FieldType._Date) & ","
        End If
        End If
        allEmptyFlag = item.LAD_MAX_ALLOC.IsEmpty And allEmptyFlag
        If Not item.LAD_MAX_ALLOC.IsEmpty Then
        If IsNothing(item.LAD_MAX_ALLOC.Value) Then
        valuesList = valuesList & "LAD_MAX_ALLOC=" & Update.Dao.ToSql((0).ToString(),FieldType._Integer) & ","
        Else
        valuesList = valuesList & "LAD_MAX_ALLOC=" & Update.Dao.ToSql(item.LAD_MAX_ALLOC.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = (Expr497 Is Nothing) And allEmptyFlag
        If Not (Expr497 Is Nothing) Then
        If IsNothing(Expr497) Then
        valuesList = valuesList & "LAST_ALTERED_BY=" & Update.Dao.ToSql(("unknown").ToString(),FieldType._Text) & ","
        Else
        valuesList = valuesList & "LAST_ALTERED_BY=" & Update.Dao.ToSql(Expr497.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.radioYEAR_LEVEL.IsEmpty And allEmptyFlag
        If Not item.radioYEAR_LEVEL.IsEmpty Then
        If IsNothing(item.radioYEAR_LEVEL.Value) Then
        valuesList = valuesList & "YEAR_LEVEL=" & Update.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        valuesList = valuesList & "YEAR_LEVEL=" & Update.Dao.ToSql(item.radioYEAR_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
		Update.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
'End EditableGrid ManageLADs BeforeBuildUpdate

'EditableGrid ManageLADs Execute Update  @3-392E25E7
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
'End EditableGrid ManageLADs Execute Update 

'EditableGrid ManageLADs AfterExecuteUpdate @3-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid ManageLADs AfterExecuteUpdate

'Record ManageLADs Data Provider Class Delete Method @3-0AF22631
    Public Function DeleteItem(ByVal item As ManageLADsItem) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        IsParametersPassed = Not(IsNothing(item.STAFF_IDField) Or IsNothing(item.idField))
        Dim Delete As DataCommand=new TableCommand("DELETE FROM STAFF_LAD_ALLOCATION", New String(){"STAFF_ID430","And","id629"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record ManageLADs Data Provider Class Delete Method

'Record ManageLADs BeforeBuildDelete @3-A8B49DA8
        Delete.Parameters.Clear()
        CType(Delete,TableCommand).AddParameter("STAFF_ID430",item.STAFF_IDField, "","STAFF_ID",Condition.Equal,False)
        CType(Delete,TableCommand).AddParameter("id629",item.idField, "","id",Condition.Equal,False)
'End Record ManageLADs BeforeBuildDelete

'EditableGrid ManageLADs Data Provider Class Execute Delete @3-124DEAF1
        Delete.OpType = OperationType.Delete
        Dim result As Object = 0
        Dim E As Exception = Nothing
        If CmdExecution Then
            If Not IsParametersPassed Then
                item.errors.Add("DataProvider",Resources.strings.CCS_CustomOperationError_MissingParameters)
                Return 0
            End If
            Try
                result = Delete.ExecuteNonQuery()
            Catch e_ As Exception
                item.errors.Add("DataProvider",e_.Source + ":" + e_.Message)
            Finally
'End EditableGrid ManageLADs Data Provider Class Execute Delete

'EditableGrid ManageLADs AfterExecuteDelete @3-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid ManageLADs AfterExecuteDelete

'Grid ManageLADs Data Provider Class GetResultSet Method @3-C0C373AA
    Public Sub Update(Items As ArrayList, ops As FormSupportedOperations)
        Dim i As Integer
        For i = 0 To Items.Count - 1
            Dim op As EditableGridOperation = EditableGridOperation.Insert
            Dim isProcessed As Boolean = False
            Dim item As ManageLADsItem = CType(Items(i), ManageLADsItem)
'End Grid ManageLADs Data Provider Class GetResultSet Method

'EditableGrid ManageLADs Data Provider Class Update @3-16326EAB
            If Not item.IsUpdated Then
                If item.IsDeleted And ops.AllowDelete Then
                    DeleteItem(item)
                    op = EditableGridOperation.Delete
                    isProcessed = True
                End If
                If Not(item.IsEmptyItem) And ops.AllowUpdate And Not(isProcessed) Then
                    UpdateItem(item)
                    op = EditableGridOperation.Update
                End If
'End EditableGrid ManageLADs Data Provider Class Update

'EditableGrid ManageLADs Data Provider Class AfterUpdate @3-6CCB76B9
                If item.errors.Count = 0 Then item.IsUpdated = True
                OnItemUpdated(New ItemUpdatedEventArgs(op, item))
            End If
        Next i
    End Sub
'End EditableGrid ManageLADs Data Provider Class AfterUpdate

'EditableGrid ManageLADs Data Provider Class GetResultSet Method @3-DE1170B7
    Public Function GetResultSet(ByRef _pagesCount As Integer, ops As FormSupportedOperations) As ManageLADsItem()
'End EditableGrid ManageLADs Data Provider Class GetResultSet Method

'Before build Select @3-20E07C5D
        _pagesCount = 0
        Dim E as Exception = Nothing
        Dim j As Integer
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_keyword617",Urls_keyword, "","STAFF.SURNAME",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword618",Urls_keyword, "","STAFF_LAD_ALLOCATION.STAFF_ID",Condition.BeginsWith,False)
        CType(Select_,TableCommand).AddParameter("s_keyword619",Urls_keyword, "","STAFF.FIRSTNAME",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("rbShow620",UrlrbShow, "","LAD_MAX_ALLOC",Condition.GreaterThan,False)
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

'After execute Select @3-B3E1C70C
                If Not IsNothing(E) Then Throw E
            End Try
            dr = ds.Tables(tableIndex).Rows
            rowCount = dr.Count
        End If
        Dim result(rowCount - 1) As ManageLADsItem
'End After execute Select

'ListBox radioYEAR_LEVEL AfterExecuteSelect @562-63A1970D
    Dim radioYEAR_LEVELItems As ItemCollection = New ItemCollection()
    
radioYEAR_LEVELItems.Add("11","Yr 11")
radioYEAR_LEVELItems.Add("12","Yr 12")
'End ListBox radioYEAR_LEVEL AfterExecuteSelect

'After execute Select tail @3-80505859
        Dim i as Integer
        For i = 0 To rowCount - 1
            Dim item as ManageLADsItem = New ManageLADsItem()
            item.IsDeleteAllowed = ops.AllowDelete
            item.FIRSTNAME.SetValue(dr(i)("STAFF_FIRSTNAME"),"")
            item.SURNAME.SetValue(dr(i)("STAFF_SURNAME"),"")
            item.lblLastUpdated.SetValue(dr(i)("STAFF_LAD_ALLOCATION_LAST_ALTERED_DATE"),Select_.DateFormat)
            item.LAD_MAX_ALLOC.SetValue(dr(i)("LAD_MAX_ALLOC"),"")
            item.lblStaffID.SetValue(dr(i)("STAFF_ID"),"")
            item.radioYEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
            item.radioYEAR_LEVELItems = CType(radioYEAR_LEVELItems.Clone(), ItemCollection)
            item.STAFF_IDField.SetValue(dr(i)("STAFF_ID"),"")
            item.idField.SetValue(dr(i)("id"),"")
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

'Record SUBJECT_SUBJECT_TEACHER Item Class @40-A6325111
Public Class SUBJECT_SUBJECT_TEACHERItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public s_keyword As TextField
    Public rbConfirm As IntegerField
    Public rbConfirmItems As ItemCollection
    Public lblConfirmError As TextField
    Public rbShow As IntegerField
    Public rbShowItems As ItemCollection
    Public maxstudents As IntegerField
    Public Sub New()
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    s_keyword = New TextField("", Nothing)
    rbConfirm = New IntegerField("", 0)
    rbConfirmItems = New ItemCollection()
    lblConfirmError = New TextField("", Nothing)
    rbShow = New IntegerField("", 0)
    rbShowItems = New ItemCollection()
    maxstudents = New IntegerField("", 12)
    End Sub

    Public Shared Function CreateFromHttpRequest() As SUBJECT_SUBJECT_TEACHERItem
        Dim item As SUBJECT_SUBJECT_TEACHERItem = New SUBJECT_SUBJECT_TEACHERItem()
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_keyword")) Then
        item.s_keyword.SetValue(DBUtility.GetInitialValue("s_keyword"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ButtonResetLAdsMax")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("rbConfirm")) Then
        item.rbConfirm.SetValue(DBUtility.GetInitialValue("rbConfirm"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblConfirmError")) Then
        item.lblConfirmError.SetValue(DBUtility.GetInitialValue("lblConfirmError"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("rbShow")) Then
        item.rbShow.SetValue(DBUtility.GetInitialValue("rbShow"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("maxstudents")) Then
        item.maxstudents.SetValue(DBUtility.GetInitialValue("maxstudents"))
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
                Case "rbConfirm"
                    Return rbConfirm
                Case "lblConfirmError"
                    Return lblConfirmError
                Case "rbShow"
                    Return rbShow
                Case "maxstudents"
                    Return maxstudents
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
                Case "rbConfirm"
                    rbConfirm = CType(value, IntegerField)
                Case "lblConfirmError"
                    lblConfirmError = CType(value, TextField)
                Case "rbShow"
                    rbShow = CType(value, IntegerField)
                Case "maxstudents"
                    maxstudents = CType(value, IntegerField)
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

    Public Sub Validate(ByVal provider As SUBJECT_SUBJECT_TEACHERDataProvider)
'End Record SUBJECT_SUBJECT_TEACHER Item Class

'rbConfirm validate @392-14C54645
        If IsNothing(rbConfirm.Value) OrElse rbConfirm.Value.ToString() ="" Then
            errors.Add("rbConfirm",String.Format(Resources.strings.CCS_RequiredField,"Confirm Reset"))
        End If
'End rbConfirm validate

'RadioButton rbConfirm Event OnValidate. Action Validate Minimum Value @393-3E27FC80
        If Not (rbConfirm.Value Is Nothing) Then
            If Convert.ToDouble(rbConfirm.Value) < 1 Then
            errors.Add("rbConfirm",String.Format("Must select 'Yes' to confirm Reset","Confirm Reset","1"))
            End If
        End If
'End RadioButton rbConfirm Event OnValidate. Action Validate Minimum Value

'maxstudents validate @432-7FB09A5D
        If IsNothing(maxstudents.Value) OrElse maxstudents.Value.ToString() ="" Then
            errors.Add("maxstudents",String.Format(Resources.strings.CCS_RequiredField,"Reset Max Students"))
        End If
'End maxstudents validate

'Record SUBJECT_SUBJECT_TEACHER Item Class tail @40-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record SUBJECT_SUBJECT_TEACHER Item Class tail

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class @40-0446A6B3
Public Class SUBJECT_SUBJECT_TEACHERDataProvider
Inherits RecordDataProviderBase
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class Variables @40-32635BE3
    Public Ctrlmaxstudents As IntegerParameter
    Protected item As SUBJECT_SUBJECT_TEACHERItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class Variables

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class Constructor @40-E0ECD229

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STAFF_LAD_ALLOCATION {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
        Delete=new SqlCommand("UPDATE STAFF_LAD_ALLOCATION " & vbCrLf & _
          "SET LAD_MAX_ALLOC = {maxstudents}",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class Constructor

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class LoadParams Method @40-B45586B2

    Protected Function LoadParams() As Boolean
        Return True
    End Function
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class LoadParams Method

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class CheckUnique Method @40-524FBB55

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As SUBJECT_SUBJECT_TEACHERItem) As Boolean
        Return True
    End Function
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class CheckUnique Method

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class PrepareDelete Method @40-3CDFF327

    Protected Overrides Sub PrepareDelete()
        CmdExecution = True
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class PrepareDelete Method

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class PrepareDelete Method tail @40-E31F8E2A
    End Sub
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class PrepareDelete Method tail

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class Delete Method @40-5B4A7E9D
    Public Function DeleteItem(ByVal item As SUBJECT_SUBJECT_TEACHERItem) As Integer
        Me.item = item
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class Delete Method

'Record SUBJECT_SUBJECT_TEACHER BeforeBuildDelete @40-57ED20FE
        Delete.Parameters.Clear()
        CType(Delete,SqlCommand).AddParameter("maxstudents",item.maxstudents, "")
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
            result = ExecuteDelete()
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record SUBJECT_SUBJECT_TEACHER BeforeBuildDelete

'Record SUBJECT_SUBJECT_TEACHER BeforeBuildDelete @40-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record SUBJECT_SUBJECT_TEACHER BeforeBuildDelete

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class GetResultSet Method @40-2D3F5E0B

    Public Sub FillItem(ByVal item As SUBJECT_SUBJECT_TEACHERItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class GetResultSet Method

'Record SUBJECT_SUBJECT_TEACHER BeforeBuildSelect @40-5D194071
        Select_.Parameters.Clear()
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record SUBJECT_SUBJECT_TEACHER BeforeBuildSelect

'Record SUBJECT_SUBJECT_TEACHER BeforeExecuteSelect @40-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record SUBJECT_SUBJECT_TEACHER BeforeExecuteSelect

'Record SUBJECT_SUBJECT_TEACHER AfterExecuteSelect @40-F5073A40
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.ClearParametersHref = "Staff_LAdAllocation_maint.aspx"
        Else
            IsInsertMode = True
        End If
'End Record SUBJECT_SUBJECT_TEACHER AfterExecuteSelect

'ListBox rbConfirm AfterExecuteSelect @392-AC940DA7
        
item.rbConfirmItems.Add("0","<font color=#00FF00>No reset</font>")
item.rbConfirmItems.Add("1","<font color=#FF0000>Yes (Reset)</font>")
'End ListBox rbConfirm AfterExecuteSelect

'ListBox rbShow AfterExecuteSelect @400-8493E63D
        
item.rbShowItems.Add("0","Active LAds (Max > 0)")
item.rbShowItems.Add("-1","All LADs")
'End ListBox rbShow AfterExecuteSelect

'Record SUBJECT_SUBJECT_TEACHER AfterExecuteSelect tail @40-E31F8E2A
    End Sub
'End Record SUBJECT_SUBJECT_TEACHER AfterExecuteSelect tail

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class @40-A61BA892
End Class

'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class

'Record SUBJECT_TEACHER Item Class @93-28E091B0
Public Class SUBJECT_TEACHERItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public STAFF_ID As TextField
    Public STAFF_IDItems As ItemCollection
    Public LAD_MAX_ALLOC As IntegerField
    Public radioYEAR_LEVEL As TextField
    Public radioYEAR_LEVELItems As ItemCollection
    Public Sub New()
    STAFF_ID = New TextField("", Nothing)
    STAFF_IDItems = New ItemCollection()
    LAD_MAX_ALLOC = New IntegerField("0;(0)", 12)
    radioYEAR_LEVEL = New TextField("", 0)
    radioYEAR_LEVELItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As SUBJECT_TEACHERItem
        Dim item As SUBJECT_TEACHERItem = New SUBJECT_TEACHERItem()
        If Not IsNothing(DBUtility.GetInitialValue("STAFF_ID")) Then
        item.STAFF_ID.SetValue(DBUtility.GetInitialValue("STAFF_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAD_MAX_ALLOC")) Then
        item.LAD_MAX_ALLOC.SetValue(DBUtility.GetInitialValue("LAD_MAX_ALLOC"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("buttonAdd")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("radioYEAR_LEVEL")) Then
        item.radioYEAR_LEVEL.SetValue(DBUtility.GetInitialValue("radioYEAR_LEVEL"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "STAFF_ID"
                    Return STAFF_ID
                Case "LAD_MAX_ALLOC"
                    Return LAD_MAX_ALLOC
                Case "radioYEAR_LEVEL"
                    Return radioYEAR_LEVEL
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STAFF_ID"
                    STAFF_ID = CType(value, TextField)
                Case "LAD_MAX_ALLOC"
                    LAD_MAX_ALLOC = CType(value, IntegerField)
                Case "radioYEAR_LEVEL"
                    radioYEAR_LEVEL = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As SUBJECT_TEACHERDataProvider)
'End Record SUBJECT_TEACHER Item Class

'STAFF_ID validate @101-90ED86B5
        If IsNothing(STAFF_ID.Value) OrElse STAFF_ID.Value.ToString() ="" Then
            errors.Add("STAFF_ID",String.Format(Resources.strings.CCS_RequiredField,"Learning Advisor Name"))
        End If
'End STAFF_ID validate

'LAD_MAX_ALLOC validate @347-07463F7F
        If IsNothing(LAD_MAX_ALLOC.Value) OrElse LAD_MAX_ALLOC.Value.ToString() ="" Then
            errors.Add("LAD_MAX_ALLOC",String.Format(Resources.strings.CCS_RequiredField,"Max. Students"))
        End If
'End LAD_MAX_ALLOC validate

'TextBox LAD_MAX_ALLOC Event OnValidate. Action Validate Minimum Value @348-33C1F29E
        If Not (LAD_MAX_ALLOC.Value Is Nothing) Then
            If Convert.ToDouble(LAD_MAX_ALLOC.Value) < 0 Then
            errors.Add("LAD_MAX_ALLOC",String.Format("Maximum Students must be 0 or greater","Max. Students","0"))
            End If
        End If
'End TextBox LAD_MAX_ALLOC Event OnValidate. Action Validate Minimum Value

'TextBox LAD_MAX_ALLOC Event OnValidate. Action Validate Maximum Value @349-ECDCD8A7
        If Not (LAD_MAX_ALLOC.Value Is Nothing) Then
            If Convert.ToDouble(LAD_MAX_ALLOC.Value) > 28 Then
            errors.Add("LAD_MAX_ALLOC",String.Format("Maximum Students must not exceed 28","Max. Students","28"))
            End If
        End If
'End TextBox LAD_MAX_ALLOC Event OnValidate. Action Validate Maximum Value

'radioYEAR_LEVEL validate @561-17B0D920
        If IsNothing(radioYEAR_LEVEL.Value) OrElse radioYEAR_LEVEL.Value.ToString() ="" Then
            errors.Add("radioYEAR_LEVEL",String.Format(Resources.strings.CCS_RequiredField,"Year Level"))
        End If
'End radioYEAR_LEVEL validate

'Record SUBJECT_TEACHER Item Class tail @93-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record SUBJECT_TEACHER Item Class tail

'Record SUBJECT_TEACHER Data Provider Class @93-73BC2482
Public Class SUBJECT_TEACHERDataProvider
Inherits RecordDataProviderBase
'End Record SUBJECT_TEACHER Data Provider Class

'Record SUBJECT_TEACHER Data Provider Class Variables @93-49DBF8BC
    Protected STAFF_IDDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM View_StaffList_Active_Inactive {SQL_Where} {SQL_OrderBy}", New String(){"expr219"},Settings.connDECVPRODSQL2005DataAccessObject )
    Public CtrlSTAFF_ID As TextParameter
    Public Expr200 As TextParameter
    Public Expr201 As DateParameter
    Public CtrlLAD_MAX_ALLOC As IntegerParameter
    Public CtrlradioYEAR_LEVEL As IntegerParameter
    Protected item As SUBJECT_TEACHERItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record SUBJECT_TEACHER Data Provider Class Variables

'Record SUBJECT_TEACHER Data Provider Class Constructor @93-DF384763

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STAFF_LAD_ALLOCATION {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record SUBJECT_TEACHER Data Provider Class Constructor

'Record SUBJECT_TEACHER Data Provider Class LoadParams Method @93-B45586B2

    Protected Function LoadParams() As Boolean
        Return True
    End Function
'End Record SUBJECT_TEACHER Data Provider Class LoadParams Method

'Record SUBJECT_TEACHER Data Provider Class CheckUnique Method @93-CE9CF344

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As SUBJECT_TEACHERItem) As Boolean
        Return True
    End Function
'End Record SUBJECT_TEACHER Data Provider Class CheckUnique Method

'Record SUBJECT_TEACHER Data Provider Class PrepareInsert Method @93-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record SUBJECT_TEACHER Data Provider Class PrepareInsert Method

'Record SUBJECT_TEACHER Data Provider Class PrepareInsert Method tail @93-E31F8E2A
    End Sub
'End Record SUBJECT_TEACHER Data Provider Class PrepareInsert Method tail

'Record SUBJECT_TEACHER Data Provider Class Insert Method @93-982CC77E

    Public Function InsertItem(ByVal item As SUBJECT_TEACHERItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO STAFF_LAD_ALLOCATION({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record SUBJECT_TEACHER Data Provider Class Insert Method

'Record SUBJECT_TEACHER Build insert @93-14434516
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        allEmptyFlag = item.STAFF_ID.IsEmpty And allEmptyFlag
        If Not item.STAFF_ID.IsEmpty Then
        If IsNothing(item.STAFF_ID.Value) Then
        fieldsList = fieldsList & "STAFF_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "STAFF_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STAFF_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = (Expr200 Is Nothing) And allEmptyFlag
        If Not (Expr200 Is Nothing) Then
        If IsNothing(Expr200) Then
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(("unknown").ToString(),FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr200.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = (Expr201 Is Nothing) And allEmptyFlag
        If Not (Expr201 Is Nothing) Then
        If IsNothing(Expr201) Then
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr201.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        End If
        allEmptyFlag = item.LAD_MAX_ALLOC.IsEmpty And allEmptyFlag
        If Not item.LAD_MAX_ALLOC.IsEmpty Then
        If IsNothing(item.LAD_MAX_ALLOC.Value) Then
        fieldsList = fieldsList & "LAD_MAX_ALLOC,"
        valuesList = valuesList & Insert.Dao.ToSql((12).ToString(),FieldType._Integer) & ","
        Else
        fieldsList = fieldsList & "LAD_MAX_ALLOC,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAD_MAX_ALLOC.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.radioYEAR_LEVEL.IsEmpty And allEmptyFlag
        If Not item.radioYEAR_LEVEL.IsEmpty Then
        If IsNothing(item.radioYEAR_LEVEL.Value) Then
        fieldsList = fieldsList & "YEAR_LEVEL,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        fieldsList = fieldsList & "YEAR_LEVEL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.radioYEAR_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
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
'End Record SUBJECT_TEACHER Build insert

'Record SUBJECT_TEACHER AfterExecuteInsert @93-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record SUBJECT_TEACHER AfterExecuteInsert

'Record SUBJECT_TEACHER Data Provider Class GetResultSet Method @93-CCB2B35A

    Public Sub FillItem(ByVal item As SUBJECT_TEACHERItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record SUBJECT_TEACHER Data Provider Class GetResultSet Method

'Record SUBJECT_TEACHER BeforeBuildSelect @93-5D194071
        Select_.Parameters.Clear()
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record SUBJECT_TEACHER BeforeBuildSelect

'Record SUBJECT_TEACHER BeforeExecuteSelect @93-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record SUBJECT_TEACHER BeforeExecuteSelect

'Record SUBJECT_TEACHER AfterExecuteSelect @93-280853E9
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
            item.LAD_MAX_ALLOC.SetValue(dr(i)("LAD_MAX_ALLOC"),"")
            item.radioYEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record SUBJECT_TEACHER AfterExecuteSelect

'ListBox STAFF_ID Initialize Data Source @101-AFF30C3C
        STAFF_IDDataCommand.Dao._optimized = False
        Dim STAFF_IDtableIndex As Integer = 0
        STAFF_IDDataCommand.OrderBy = ""
        STAFF_IDDataCommand.Parameters.Clear()
        STAFF_IDDataCommand.Parameters.Add("expr219","(status = 1)")
'End ListBox STAFF_ID Initialize Data Source

'ListBox STAFF_ID BeforeExecuteSelect @101-0F683DF6
        Try
            ListBoxSource=STAFF_IDDataCommand.Execute().Tables(STAFF_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox STAFF_ID BeforeExecuteSelect

'ListBox STAFF_ID AfterExecuteSelect @101-0FE625FB
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("staff_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("staffname")
            item.STAFF_IDItems.Add(Key, Val)
        Next
'End ListBox STAFF_ID AfterExecuteSelect

'ListBox radioYEAR_LEVEL AfterExecuteSelect @561-DDEF74A7
        
item.radioYEAR_LEVELItems.Add("11","Yr 11")
item.radioYEAR_LEVELItems.Add("12","Yr 12")
'End ListBox radioYEAR_LEVEL AfterExecuteSelect

'Record SUBJECT_TEACHER AfterExecuteSelect tail @93-E31F8E2A
    End Sub
'End Record SUBJECT_TEACHER AfterExecuteSelect tail

'Record SUBJECT_TEACHER Data Provider Class @93-A61BA892
End Class

'End Record SUBJECT_TEACHER Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

