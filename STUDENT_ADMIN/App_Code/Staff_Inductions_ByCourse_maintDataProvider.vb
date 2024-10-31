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

Namespace DECV_PROD2007.Staff_Inductions_ByCourse_maint 'Namespace @1-67818780

'Page Data Class @1-DC2D0F50
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public link_backtolist As TextField
    Public link_backtolistHref As Object
    Public link_backtolistHrefParameters As LinkParameterCollection
    Public Sub New()
        link_backtolist = New TextField("",Nothing)
        link_backtolistHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.link_backtolist.SetValue(DBUtility.GetInitialValue("link_backtolist"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "link_backtolist"
                    Return link_backtolist
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "link_backtolist"
                    link_backtolist = CType(value, TextField)
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

'Record STAFF_INDUCTIONS_COURSES Item Class @3-86C3EB41
Public Class STAFF_INDUCTIONS_COURSESItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public INDUCTION_TITLE As TextField
    Public INDUCTION_DESCRIPTION As TextField
    Public STATUS As IntegerField
    Public STATUSItems As ItemCollection
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public hidden_LAST_ALTERED_BY As TextField
    Public hidden_LAST_ALTERED_DATE As DateField
    Public Sub New()
    INDUCTION_TITLE = New TextField("", Nothing)
    INDUCTION_DESCRIPTION = New TextField("", Nothing)
    STATUS = New IntegerField("", Nothing)
    STATUSItems = New ItemCollection()
    LAST_ALTERED_BY = New TextField("", "unknown")
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    hidden_LAST_ALTERED_BY = New TextField("", Nothing)
    hidden_LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STAFF_INDUCTIONS_COURSESItem
        Dim item As STAFF_INDUCTIONS_COURSESItem = New STAFF_INDUCTIONS_COURSESItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("INDUCTION_TITLE")) Then
        item.INDUCTION_TITLE.SetValue(DBUtility.GetInitialValue("INDUCTION_TITLE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("INDUCTION_DESCRIPTION")) Then
        item.INDUCTION_DESCRIPTION.SetValue(DBUtility.GetInitialValue("INDUCTION_DESCRIPTION"))
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
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY")) Then
        item.hidden_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_DATE")) Then
        item.hidden_LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_DATE"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "INDUCTION_TITLE"
                    Return INDUCTION_TITLE
                Case "INDUCTION_DESCRIPTION"
                    Return INDUCTION_DESCRIPTION
                Case "STATUS"
                    Return STATUS
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "hidden_LAST_ALTERED_BY"
                    Return hidden_LAST_ALTERED_BY
                Case "hidden_LAST_ALTERED_DATE"
                    Return hidden_LAST_ALTERED_DATE
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "INDUCTION_TITLE"
                    INDUCTION_TITLE = CType(value, TextField)
                Case "INDUCTION_DESCRIPTION"
                    INDUCTION_DESCRIPTION = CType(value, TextField)
                Case "STATUS"
                    STATUS = CType(value, IntegerField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "hidden_LAST_ALTERED_BY"
                    hidden_LAST_ALTERED_BY = CType(value, TextField)
                Case "hidden_LAST_ALTERED_DATE"
                    hidden_LAST_ALTERED_DATE = CType(value, DateField)
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

    Public Sub Validate(ByVal provider As STAFF_INDUCTIONS_COURSESDataProvider)
'End Record STAFF_INDUCTIONS_COURSES Item Class

'Record STAFF_INDUCTIONS_COURSES Item Class tail @3-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STAFF_INDUCTIONS_COURSES Item Class tail

'Record STAFF_INDUCTIONS_COURSES Data Provider Class @3-EBFDEFD8
Public Class STAFF_INDUCTIONS_COURSESDataProvider
Inherits RecordDataProviderBase
'End Record STAFF_INDUCTIONS_COURSES Data Provider Class

'Record STAFF_INDUCTIONS_COURSES Data Provider Class Variables @3-76F9DF50
    Public Urlid As IntegerParameter
    Protected item As STAFF_INDUCTIONS_COURSESItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STAFF_INDUCTIONS_COURSES Data Provider Class Variables

'Record STAFF_INDUCTIONS_COURSES Data Provider Class Constructor @3-CE7FC8E3

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STAFF_INDUCTIONS_COURSES {SQL_Where} {SQL_OrderBy}", New String(){"id9"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STAFF_INDUCTIONS_COURSES Data Provider Class Constructor

'Record STAFF_INDUCTIONS_COURSES Data Provider Class LoadParams Method @3-296B5411

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(Urlid))
    End Function
'End Record STAFF_INDUCTIONS_COURSES Data Provider Class LoadParams Method

'Record STAFF_INDUCTIONS_COURSES Data Provider Class CheckUnique Method @3-8FD741EF

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STAFF_INDUCTIONS_COURSESItem) As Boolean
        Return True
    End Function
'End Record STAFF_INDUCTIONS_COURSES Data Provider Class CheckUnique Method

'Record STAFF_INDUCTIONS_COURSES Data Provider Class PrepareInsert Method @3-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STAFF_INDUCTIONS_COURSES Data Provider Class PrepareInsert Method

'Record STAFF_INDUCTIONS_COURSES Data Provider Class PrepareInsert Method tail @3-E31F8E2A
    End Sub
'End Record STAFF_INDUCTIONS_COURSES Data Provider Class PrepareInsert Method tail

'Record STAFF_INDUCTIONS_COURSES Data Provider Class Insert Method @3-3E7BFE02

    Public Function InsertItem(ByVal item As STAFF_INDUCTIONS_COURSESItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO STAFF_INDUCTIONS_COURSES({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STAFF_INDUCTIONS_COURSES Data Provider Class Insert Method

'Record STAFF_INDUCTIONS_COURSES Build insert @3-365E7197
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.INDUCTION_TITLE.IsEmpty Then
        allEmptyFlag = item.INDUCTION_TITLE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "INDUCTION_TITLE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.INDUCTION_TITLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.INDUCTION_DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.INDUCTION_DESCRIPTION.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "INDUCTION_DESCRIPTION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.INDUCTION_DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STATUS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STATUS.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.hidden_LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.hidden_LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.hidden_LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.hidden_LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.hidden_LAST_ALTERED_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
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
'End Record STAFF_INDUCTIONS_COURSES Build insert

'Record STAFF_INDUCTIONS_COURSES AfterExecuteInsert @3-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STAFF_INDUCTIONS_COURSES AfterExecuteInsert

'Record STAFF_INDUCTIONS_COURSES Data Provider Class PrepareUpdate Method @3-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STAFF_INDUCTIONS_COURSES Data Provider Class PrepareUpdate Method

'Record STAFF_INDUCTIONS_COURSES Data Provider Class PrepareUpdate Method tail @3-E31F8E2A
    End Sub
'End Record STAFF_INDUCTIONS_COURSES Data Provider Class PrepareUpdate Method tail

'Record STAFF_INDUCTIONS_COURSES Data Provider Class Update Method @3-CD90BE7F

    Public Function UpdateItem(ByVal item As STAFF_INDUCTIONS_COURSESItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STAFF_INDUCTIONS_COURSES SET {Values}", New String(){"id9"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STAFF_INDUCTIONS_COURSES Data Provider Class Update Method

'Record STAFF_INDUCTIONS_COURSES BeforeBuildUpdate @3-C1BFBDAB
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("id9",Urlid, "","id",Condition.Equal,False)
        If Not item.INDUCTION_TITLE.IsEmpty Then
        allEmptyFlag = item.INDUCTION_TITLE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "INDUCTION_TITLE=" + Update.Dao.ToSql(item.INDUCTION_TITLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.INDUCTION_DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.INDUCTION_DESCRIPTION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "INDUCTION_DESCRIPTION=" + Update.Dao.ToSql(item.INDUCTION_DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STATUS=" + Update.Dao.ToSql(item.STATUS.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.hidden_LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.hidden_LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.hidden_LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.hidden_LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.hidden_LAST_ALTERED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
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
'End Record STAFF_INDUCTIONS_COURSES BeforeBuildUpdate

'Record STAFF_INDUCTIONS_COURSES AfterExecuteUpdate @3-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STAFF_INDUCTIONS_COURSES AfterExecuteUpdate

'Record STAFF_INDUCTIONS_COURSES Data Provider Class GetResultSet Method @3-BB437E15

    Public Sub FillItem(ByVal item As STAFF_INDUCTIONS_COURSESItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STAFF_INDUCTIONS_COURSES Data Provider Class GetResultSet Method

'Record STAFF_INDUCTIONS_COURSES BeforeBuildSelect @3-C68E26B3
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("id9",Urlid, "","id",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STAFF_INDUCTIONS_COURSES BeforeBuildSelect

'Record STAFF_INDUCTIONS_COURSES BeforeExecuteSelect @3-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STAFF_INDUCTIONS_COURSES BeforeExecuteSelect

'Record STAFF_INDUCTIONS_COURSES AfterExecuteSelect @3-DE668D8A
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.INDUCTION_TITLE.SetValue(dr(i)("INDUCTION_TITLE"),"")
            item.INDUCTION_DESCRIPTION.SetValue(dr(i)("INDUCTION_DESCRIPTION"),"")
            item.STATUS.SetValue(dr(i)("STATUS"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.hidden_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.hidden_LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
'End Record STAFF_INDUCTIONS_COURSES AfterExecuteSelect

'ListBox STATUS AfterExecuteSelect @12-BAC365F8
        
item.STATUSItems.Add("1","Active")
item.STATUSItems.Add("0","Inactive")
'End ListBox STATUS AfterExecuteSelect

'Record STAFF_INDUCTIONS_COURSES AfterExecuteSelect tail @3-E31F8E2A
    End Sub
'End Record STAFF_INDUCTIONS_COURSES AfterExecuteSelect tail

'Record STAFF_INDUCTIONS_COURSES Data Provider Class @3-A61BA892
End Class

'End Record STAFF_INDUCTIONS_COURSES Data Provider Class

'Grid STAFF_INDUCTIONS_COURSES1 Item Class @21-7E72BBE6
Public Class STAFF_INDUCTIONS_COURSES1Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STAFF_INDUCTIONS_PROGRESS_STATUS As TextField
    Public DATE_COMPLETED As DateField
    Public staffname As TextField
    Public INDUCTION_TITLE As TextField
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public Sub New()
    STAFF_INDUCTIONS_PROGRESS_STATUS = New TextField("", Nothing)
    DATE_COMPLETED = New DateField("dd MMM yyyy", Nothing)
    staffname = New TextField("", Nothing)
    INDUCTION_TITLE = New TextField("", Nothing)
    Link1 = New TextField("",Nothing)
    Link1HrefParameters = New LinkParameterCollection()
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STAFF_INDUCTIONS_PROGRESS_STATUS"
                    Return Me.STAFF_INDUCTIONS_PROGRESS_STATUS
                Case "DATE_COMPLETED"
                    Return Me.DATE_COMPLETED
                Case "staffname"
                    Return Me.staffname
                Case "INDUCTION_TITLE"
                    Return Me.INDUCTION_TITLE
                Case "Link1"
                    Return Me.Link1
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STAFF_INDUCTIONS_PROGRESS_STATUS"
                    Me.STAFF_INDUCTIONS_PROGRESS_STATUS = CType(Value,TextField)
                Case "DATE_COMPLETED"
                    Me.DATE_COMPLETED = CType(Value,DateField)
                Case "staffname"
                    Me.staffname = CType(Value,TextField)
                Case "INDUCTION_TITLE"
                    Me.INDUCTION_TITLE = CType(Value,TextField)
                Case "Link1"
                    Me.Link1 = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STAFF_INDUCTIONS_COURSES1 Item Class

'Grid STAFF_INDUCTIONS_COURSES1 Data Provider Class Header @21-0C728173
Public Class STAFF_INDUCTIONS_COURSES1DataProvider
Inherits GridDataProviderBase
'End Grid STAFF_INDUCTIONS_COURSES1 Data Provider Class Header

'Grid STAFF_INDUCTIONS_COURSES1 Data Provider Class Variables @21-3B5675AD

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STAFF_INDUCTIONS_PROGRESS_STATUS
        Sorter_DATE_COMPLETED
        Sorter_staffname
        Sorter_INDUCTION_TITLE
    End Enum

    Private SortFieldsNames As String() = New String() {"DATE_COMPLETED desc","STAFF_INDUCTIONS_PROGRESS.STATUS","DATE_COMPLETED","staffname","INDUCTION_TITLE"}
    Private SortFieldsNamesDesc As String() = New string() {"DATE_COMPLETED desc","STAFF_INDUCTIONS_PROGRESS.STATUS DESC","DATE_COMPLETED DESC","staffname DESC","INDUCTION_TITLE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 30
    Public PageNumber As Integer = 1
    Public Urlid  As IntegerParameter
'End Grid STAFF_INDUCTIONS_COURSES1 Data Provider Class Variables

'Grid STAFF_INDUCTIONS_COURSES1 Data Provider Class GetResultSet Method @21-D1F68D01

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} staffname, " & vbCrLf & _
          "STAFF_INDUCTIONS_PROGRESS.STATUS AS STAFF_INDUCTIONS_PROGRESS_STATUS, DATE_COMPLETED, INDU" & _
          "CTION_TITLE, " & vbCrLf & _
          "View_StaffList_Active_Inactive.staff_ID AS View_StaffList_Active_Inactive_staff_ID," & vbCrLf & _
          "STAFF_INDUCTIONS_PROGRESS.id AS STAFF_INDUCTIONS_PROGRESS_id " & vbCrLf & _
          "FROM (STAFF_INDUCTIONS_PROGRESS INNER JOIN View_StaffList_Active_Inactive ON" & vbCrLf & _
          "STAFF_INDUCTIONS_PROGRESS.STAFF_ID = View_StaffList_Active_Inactive.staff_ID) INNER JOIN S" & _
          "TAFF_INDUCTIONS_COURSES ON" & vbCrLf & _
          "STAFF_INDUCTIONS_PROGRESS.induction_id = STAFF_INDUCTIONS_COURSES.id {SQL_Where} {SQL_Orde" & _
          "rBy}", New String(){"id52"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM (STAFF_INDUCTIONS_PROGRESS INNER JOIN View_StaffList_Active_Inactive ON" & vbCrLf & _
          "STAFF_INDUCTIONS_PROGRESS.STAFF_ID = View_StaffList_Active_Inactive.staff_ID) INNER JOIN S" & _
          "TAFF_INDUCTIONS_COURSES ON" & vbCrLf & _
          "STAFF_INDUCTIONS_PROGRESS.induction_id = STAFF_INDUCTIONS_COURSES.id", New String(){"id52"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid STAFF_INDUCTIONS_COURSES1 Data Provider Class GetResultSet Method

'Grid STAFF_INDUCTIONS_COURSES1 Data Provider Class GetResultSet Method @21-34C44CCE
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STAFF_INDUCTIONS_COURSES1Item()
'End Grid STAFF_INDUCTIONS_COURSES1 Data Provider Class GetResultSet Method

'Before build Select @21-F3260BF3
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("id52",Urlid, "","STAFF_INDUCTIONS_PROGRESS.induction_id",Condition.Equal,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @21-3F6787D5
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STAFF_INDUCTIONS_COURSES1Item
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

'After execute Select @21-75CE9DD7
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STAFF_INDUCTIONS_COURSES1Item(dr.Count-1) {}
'End After execute Select

'After execute Select @21-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @21-150E05FB
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STAFF_INDUCTIONS_COURSES1Item = New STAFF_INDUCTIONS_COURSES1Item()
                item.STAFF_INDUCTIONS_PROGRESS_STATUS.SetValue(dr(i)("STAFF_INDUCTIONS_PROGRESS_STATUS"),"")
                item.DATE_COMPLETED.SetValue(dr(i)("DATE_COMPLETED"),Select_.DateFormat)
                item.staffname.SetValue(dr(i)("staffname"),"")
                item.INDUCTION_TITLE.SetValue(dr(i)("INDUCTION_TITLE"),"")
                item.Link1.SetValue(dr(i)("STAFF_INDUCTIONS_PROGRESS_id"),"")
                item.Link1Href = "Staff_Inductions_ByStaff.aspx"
                item.Link1HrefParameters.Add("s_View_StaffList_Active_Inactive_staff_ID",System.Web.HttpUtility.UrlEncode(dr(i)("View_StaffList_Active_Inactive_staff_ID").ToString()))
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @21-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

