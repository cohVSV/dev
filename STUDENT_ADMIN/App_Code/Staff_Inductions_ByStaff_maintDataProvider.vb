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

Namespace DECV_PROD2007.Staff_Inductions_ByStaff_maint 'Namespace @1-96C25348

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

'Record STAFF_INDUCTIONS_PROGRESS Item Class @35-C0C0A831
Public Class STAFF_INDUCTIONS_PROGRESSItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public STAFF_INDUCTIONS_PROGRESS_STATUS As TextField
    Public STAFF_INDUCTIONS_PROGRESS_STATUSItems As ItemCollection
    Public DATE_COMPLETED As DateField
    Public Hidden_last_altered_by As TextField
    Public Hidden_last_altered_date As TextField
    Public Hidden_STAFF_ID As TextField
    Public lbl_STAFF_ID As TextField
    Public listbox_InductionCourses As TextField
    Public listbox_InductionCoursesItems As ItemCollection
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Link1_David As TextField
    Public Link1_DavidHref As Object
    Public Link1_DavidHrefParameters As LinkParameterCollection
    Public Sub New()
    STAFF_INDUCTIONS_PROGRESS_STATUS = New TextField("", Nothing)
    STAFF_INDUCTIONS_PROGRESS_STATUSItems = New ItemCollection()
    DATE_COMPLETED = New DateField(Settings.DateFormat, DateTime.Now)
    Hidden_last_altered_by = New TextField("", Nothing)
    Hidden_last_altered_date = New TextField("", Nothing)
    Hidden_STAFF_ID = New TextField("", Nothing)
    lbl_STAFF_ID = New TextField("", Nothing)
    listbox_InductionCourses = New TextField("", Nothing)
    listbox_InductionCoursesItems = New ItemCollection()
    LAST_ALTERED_BY = New TextField("", "unknown")
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    Link1_David = New TextField("",Nothing)
    Link1_DavidHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As STAFF_INDUCTIONS_PROGRESSItem
        Dim item As STAFF_INDUCTIONS_PROGRESSItem = New STAFF_INDUCTIONS_PROGRESSItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STAFF_INDUCTIONS_PROGRESS_STATUS")) Then
        item.STAFF_INDUCTIONS_PROGRESS_STATUS.SetValue(DBUtility.GetInitialValue("STAFF_INDUCTIONS_PROGRESS_STATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DATE_COMPLETED")) Then
        item.DATE_COMPLETED.SetValue(DBUtility.GetInitialValue("DATE_COMPLETED"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DatePicker_DATE_COMPLETED")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_last_altered_by")) Then
        item.Hidden_last_altered_by.SetValue(DBUtility.GetInitialValue("Hidden_last_altered_by"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_last_altered_date")) Then
        item.Hidden_last_altered_date.SetValue(DBUtility.GetInitialValue("Hidden_last_altered_date"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_STAFF_ID")) Then
        item.Hidden_STAFF_ID.SetValue(DBUtility.GetInitialValue("Hidden_STAFF_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbl_STAFF_ID")) Then
        item.lbl_STAFF_ID.SetValue(DBUtility.GetInitialValue("lbl_STAFF_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("listbox_InductionCourses")) Then
        item.listbox_InductionCourses.SetValue(DBUtility.GetInitialValue("listbox_InductionCourses"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link1_David")) Then
        item.Link1_David.SetValue(DBUtility.GetInitialValue("Link1_David"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "STAFF_INDUCTIONS_PROGRESS_STATUS"
                    Return STAFF_INDUCTIONS_PROGRESS_STATUS
                Case "DATE_COMPLETED"
                    Return DATE_COMPLETED
                Case "Hidden_last_altered_by"
                    Return Hidden_last_altered_by
                Case "Hidden_last_altered_date"
                    Return Hidden_last_altered_date
                Case "Hidden_STAFF_ID"
                    Return Hidden_STAFF_ID
                Case "lbl_STAFF_ID"
                    Return lbl_STAFF_ID
                Case "listbox_InductionCourses"
                    Return listbox_InductionCourses
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "Link1_David"
                    Return Link1_David
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STAFF_INDUCTIONS_PROGRESS_STATUS"
                    STAFF_INDUCTIONS_PROGRESS_STATUS = CType(value, TextField)
                Case "DATE_COMPLETED"
                    DATE_COMPLETED = CType(value, DateField)
                Case "Hidden_last_altered_by"
                    Hidden_last_altered_by = CType(value, TextField)
                Case "Hidden_last_altered_date"
                    Hidden_last_altered_date = CType(value, TextField)
                Case "Hidden_STAFF_ID"
                    Hidden_STAFF_ID = CType(value, TextField)
                Case "lbl_STAFF_ID"
                    lbl_STAFF_ID = CType(value, TextField)
                Case "listbox_InductionCourses"
                    listbox_InductionCourses = CType(value, TextField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "Link1_David"
                    Link1_David = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STAFF_INDUCTIONS_PROGRESSDataProvider)
'End Record STAFF_INDUCTIONS_PROGRESS Item Class

'STAFF_INDUCTIONS_PROGRESS_STATUS validate @42-5825C058
        If IsNothing(STAFF_INDUCTIONS_PROGRESS_STATUS.Value) OrElse STAFF_INDUCTIONS_PROGRESS_STATUS.Value.ToString() ="" Then
            errors.Add("STAFF_INDUCTIONS_PROGRESS_STATUS",String.Format(Resources.strings.CCS_RequiredField,"STATUS"))
        End If
'End STAFF_INDUCTIONS_PROGRESS_STATUS validate

'DATE_COMPLETED validate @43-EF844D27
        If IsNothing(DATE_COMPLETED.Value) OrElse DATE_COMPLETED.Value.ToString() ="" Then
            errors.Add("DATE_COMPLETED",String.Format(Resources.strings.CCS_RequiredField,"DATE COMPLETED"))
        End If
'End DATE_COMPLETED validate

'listbox_InductionCourses validate @109-5D128ECB
        If IsNothing(listbox_InductionCourses.Value) OrElse listbox_InductionCourses.Value.ToString() ="" Then
            errors.Add("listbox_InductionCourses",String.Format(Resources.strings.CCS_RequiredField,"INDUCTION"))
        End If
'End listbox_InductionCourses validate

'Record STAFF_INDUCTIONS_PROGRESS Item Class tail @35-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STAFF_INDUCTIONS_PROGRESS Item Class tail

'Record STAFF_INDUCTIONS_PROGRESS Data Provider Class @35-349F54BB
Public Class STAFF_INDUCTIONS_PROGRESSDataProvider
Inherits RecordDataProviderBase
'End Record STAFF_INDUCTIONS_PROGRESS Data Provider Class

'Record STAFF_INDUCTIONS_PROGRESS Data Provider Class Variables @35-B99D1FBF
    Protected listbox_InductionCoursesDataCommand As DataCommand=new SqlCommand("select id" & vbCrLf & _
          ", case when STATUS=1 then INDUCTION_TITLE" & vbCrLf & _
          "	else  INDUCTION_TITLE + ' (inactive)'" & vbCrLf & _
          "	end as [TITLE]" & vbCrLf & _
          "from STAFF_INDUCTIONS_COURSES {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
    Public UrlSTAFF_INDUCTIONS_PROGRESS_id As TextParameter
    Protected item As STAFF_INDUCTIONS_PROGRESSItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STAFF_INDUCTIONS_PROGRESS Data Provider Class Variables

'Record STAFF_INDUCTIONS_PROGRESS Data Provider Class Constructor @35-5C2EFFB9

    Public Sub New()
        Select_=new TableCommand("SELECT STAFF_INDUCTIONS_PROGRESS.LAST_ALTERED_BY AS STAFF_INDUCTIONS_PROGRESS_LAST_ALTERED" & _
          "_BY, " & vbCrLf & _
          "STAFF_INDUCTIONS_PROGRESS.LAST_ALTERED_DATE AS STAFF_INDUCTIONS_PROGRESS_LAST_ALTERED_DATE" & _
          "," & vbCrLf & _
          "DATE_COMPLETED, " & vbCrLf & _
          "STAFF_INDUCTIONS_PROGRESS.STATUS AS STAFF_INDUCTIONS_PROGRESS_STATUS, STAFF_ID, induction_" & _
          "id, " & vbCrLf & _
          "STAFF_INDUCTIONS_PROGRESS.id AS STAFF_INDUCTIONS_PROGRESS_id " & vbCrLf & _
          "FROM STAFF_INDUCTIONS_PROGRESS {SQL_Where} {SQL_OrderBy}", New String(){"STAFF_INDUCTIONS_PROGRESS_id41"},Settings.connDECVPRODSQL2005DataAccessObject )
        Delete=new TableCommand("DELETE FROM STAFF_INDUCTIONS_PROGRESS", New String(){"STAFF_INDUCTIONS_PROGRESS_id41"},Settings.connDECVPRODSQL2005DataAccessObject , true)
        Select_.OrderBy=""
    End Sub
'End Record STAFF_INDUCTIONS_PROGRESS Data Provider Class Constructor

'Record STAFF_INDUCTIONS_PROGRESS Data Provider Class LoadParams Method @35-0AD40AF5

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTAFF_INDUCTIONS_PROGRESS_id))
    End Function
'End Record STAFF_INDUCTIONS_PROGRESS Data Provider Class LoadParams Method

'Record STAFF_INDUCTIONS_PROGRESS Data Provider Class CheckUnique Method @35-EEE2CDA8

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STAFF_INDUCTIONS_PROGRESSItem) As Boolean
        Return True
    End Function
'End Record STAFF_INDUCTIONS_PROGRESS Data Provider Class CheckUnique Method

'Record STAFF_INDUCTIONS_PROGRESS Data Provider Class PrepareInsert Method @35-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STAFF_INDUCTIONS_PROGRESS Data Provider Class PrepareInsert Method

'Record STAFF_INDUCTIONS_PROGRESS Data Provider Class PrepareInsert Method tail @35-E31F8E2A
    End Sub
'End Record STAFF_INDUCTIONS_PROGRESS Data Provider Class PrepareInsert Method tail

'Record STAFF_INDUCTIONS_PROGRESS Data Provider Class Insert Method @35-908531E3

    Public Function InsertItem(ByVal item As STAFF_INDUCTIONS_PROGRESSItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO STAFF_INDUCTIONS_PROGRESS({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STAFF_INDUCTIONS_PROGRESS Data Provider Class Insert Method

'Record STAFF_INDUCTIONS_PROGRESS Build insert @35-573FAF1A
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.STAFF_INDUCTIONS_PROGRESS_STATUS.IsEmpty Then
        allEmptyFlag = item.STAFF_INDUCTIONS_PROGRESS_STATUS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STAFF_INDUCTIONS_PROGRESS.STATUS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STAFF_INDUCTIONS_PROGRESS_STATUS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DATE_COMPLETED.IsEmpty Then
        allEmptyFlag = item.DATE_COMPLETED.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "DATE_COMPLETED,"
        valuesList = valuesList & Insert.Dao.ToSql(item.DATE_COMPLETED.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.Hidden_last_altered_by.IsEmpty Then
        allEmptyFlag = item.Hidden_last_altered_by.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STAFF_INDUCTIONS_PROGRESS.LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_last_altered_by.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_last_altered_date.IsEmpty Then
        allEmptyFlag = item.Hidden_last_altered_date.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STAFF_INDUCTIONS_PROGRESS.LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_last_altered_date.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_STAFF_ID.IsEmpty Then
        allEmptyFlag = item.Hidden_STAFF_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STAFF_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_STAFF_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.listbox_InductionCourses.IsEmpty Then
        allEmptyFlag = item.listbox_InductionCourses.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "induction_id,"
        valuesList = valuesList & Insert.Dao.ToSql(item.listbox_InductionCourses.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STAFF_INDUCTIONS_PROGRESS Build insert

'Record STAFF_INDUCTIONS_PROGRESS AfterExecuteInsert @35-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STAFF_INDUCTIONS_PROGRESS AfterExecuteInsert

'Record STAFF_INDUCTIONS_PROGRESS Data Provider Class PrepareUpdate Method @35-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STAFF_INDUCTIONS_PROGRESS Data Provider Class PrepareUpdate Method

'Record STAFF_INDUCTIONS_PROGRESS Data Provider Class PrepareUpdate Method tail @35-E31F8E2A
    End Sub
'End Record STAFF_INDUCTIONS_PROGRESS Data Provider Class PrepareUpdate Method tail

'Record STAFF_INDUCTIONS_PROGRESS Data Provider Class Update Method @35-3DE734F2

    Public Function UpdateItem(ByVal item As STAFF_INDUCTIONS_PROGRESSItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STAFF_INDUCTIONS_PROGRESS SET {Values}", New String(){"STAFF_INDUCTIONS_PROGRESS_id41"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STAFF_INDUCTIONS_PROGRESS Data Provider Class Update Method

'Record STAFF_INDUCTIONS_PROGRESS BeforeBuildUpdate @35-42CC2AC4
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STAFF_INDUCTIONS_PROGRESS_id41",UrlSTAFF_INDUCTIONS_PROGRESS_id, "","id",Condition.Equal,False)
        If Not item.STAFF_INDUCTIONS_PROGRESS_STATUS.IsEmpty Then
        allEmptyFlag = item.STAFF_INDUCTIONS_PROGRESS_STATUS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STAFF_INDUCTIONS_PROGRESS.STATUS=" + Update.Dao.ToSql(item.STAFF_INDUCTIONS_PROGRESS_STATUS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.DATE_COMPLETED.IsEmpty Then
        allEmptyFlag = item.DATE_COMPLETED.IsEmpty And allEmptyFlag
        valuesList = valuesList & "DATE_COMPLETED=" + Update.Dao.ToSql(item.DATE_COMPLETED.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.Hidden_last_altered_by.IsEmpty Then
        allEmptyFlag = item.Hidden_last_altered_by.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STAFF_INDUCTIONS_PROGRESS.LAST_ALTERED_BY=" + Update.Dao.ToSql(item.Hidden_last_altered_by.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_last_altered_date.IsEmpty Then
        allEmptyFlag = item.Hidden_last_altered_date.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STAFF_INDUCTIONS_PROGRESS.LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.Hidden_last_altered_date.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_STAFF_ID.IsEmpty Then
        allEmptyFlag = item.Hidden_STAFF_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STAFF_ID=" + Update.Dao.ToSql(item.Hidden_STAFF_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.listbox_InductionCourses.IsEmpty Then
        allEmptyFlag = item.listbox_InductionCourses.IsEmpty And allEmptyFlag
        valuesList = valuesList & "induction_id=" + Update.Dao.ToSql(item.listbox_InductionCourses.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STAFF_INDUCTIONS_PROGRESS BeforeBuildUpdate

'Record STAFF_INDUCTIONS_PROGRESS AfterExecuteUpdate @35-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STAFF_INDUCTIONS_PROGRESS AfterExecuteUpdate

'Record STAFF_INDUCTIONS_PROGRESS Data Provider Class PrepareDelete Method @35-F7361E57

    Protected Overrides Sub PrepareDelete()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STAFF_INDUCTIONS_PROGRESS Data Provider Class PrepareDelete Method

'Record STAFF_INDUCTIONS_PROGRESS Data Provider Class PrepareDelete Method tail @35-E31F8E2A
    End Sub
'End Record STAFF_INDUCTIONS_PROGRESS Data Provider Class PrepareDelete Method tail

'Record STAFF_INDUCTIONS_PROGRESS Data Provider Class Delete Method @35-12EBA352
    Public Function DeleteItem(ByVal item As STAFF_INDUCTIONS_PROGRESSItem) As Integer
        Me.item = item
'End Record STAFF_INDUCTIONS_PROGRESS Data Provider Class Delete Method

'Record STAFF_INDUCTIONS_PROGRESS BeforeBuildDelete @35-F6FE8930
        Delete.Parameters.Clear()
        CType(Delete,TableCommand).AddParameter("STAFF_INDUCTIONS_PROGRESS_id41",UrlSTAFF_INDUCTIONS_PROGRESS_id, "","id",Condition.Equal,False)
        Delete.SqlQuery.Replace("{STAFF_INDUCTIONS_PROGRESS_STATUS}",Delete.Dao.ToSql(item.STAFF_INDUCTIONS_PROGRESS_STATUS.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{DATE_COMPLETED}",Delete.Dao.ToSql(item.DATE_COMPLETED.GetFormattedValue(Delete.DateFormat),FieldType._Date))
        Delete.SqlQuery.Replace("{Hidden_last_altered_by}",Delete.Dao.ToSql(item.Hidden_last_altered_by.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{Hidden_last_altered_date}",Delete.Dao.ToSql(item.Hidden_last_altered_date.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{Hidden_STAFF_ID}",Delete.Dao.ToSql(item.Hidden_STAFF_ID.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{listbox_InductionCourses}",Delete.Dao.ToSql(item.listbox_InductionCourses.GetFormattedValue(""),FieldType._Text))
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
'End Record STAFF_INDUCTIONS_PROGRESS BeforeBuildDelete

'Record STAFF_INDUCTIONS_PROGRESS BeforeBuildDelete @35-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STAFF_INDUCTIONS_PROGRESS BeforeBuildDelete

'Record STAFF_INDUCTIONS_PROGRESS Data Provider Class GetResultSet Method @35-1B6FBC71

    Public Sub FillItem(ByVal item As STAFF_INDUCTIONS_PROGRESSItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STAFF_INDUCTIONS_PROGRESS Data Provider Class GetResultSet Method

'Record STAFF_INDUCTIONS_PROGRESS BeforeBuildSelect @35-36E85A16
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STAFF_INDUCTIONS_PROGRESS_id41",UrlSTAFF_INDUCTIONS_PROGRESS_id, "","id",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STAFF_INDUCTIONS_PROGRESS BeforeBuildSelect

'Record STAFF_INDUCTIONS_PROGRESS BeforeExecuteSelect @35-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STAFF_INDUCTIONS_PROGRESS BeforeExecuteSelect

'Record STAFF_INDUCTIONS_PROGRESS AfterExecuteSelect @35-B5D70959
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.STAFF_INDUCTIONS_PROGRESS_STATUS.SetValue(dr(i)("STAFF_INDUCTIONS_PROGRESS_STATUS"),"")
            item.DATE_COMPLETED.SetValue(dr(i)("DATE_COMPLETED"),Select_.DateFormat)
            item.Hidden_last_altered_by.SetValue(dr(i)("STAFF_INDUCTIONS_PROGRESS_LAST_ALTERED_BY"),"")
            item.Hidden_last_altered_date.SetValue(dr(i)("STAFF_INDUCTIONS_PROGRESS_LAST_ALTERED_DATE"),"")
            item.Hidden_STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
            item.lbl_STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
            item.listbox_InductionCourses.SetValue(dr(i)("induction_id"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("STAFF_INDUCTIONS_PROGRESS_LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("STAFF_INDUCTIONS_PROGRESS_LAST_ALTERED_DATE"),Select_.DateFormat)
            item.Link1_DavidHref = "#"
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record STAFF_INDUCTIONS_PROGRESS AfterExecuteSelect

'ListBox STAFF_INDUCTIONS_PROGRESS_STATUS AfterExecuteSelect @42-E50BFB9F
        
item.STAFF_INDUCTIONS_PROGRESS_STATUSItems.Add("COMPLETED","Completed")
item.STAFF_INDUCTIONS_PROGRESS_STATUSItems.Add("NA","Not Required")
'End ListBox STAFF_INDUCTIONS_PROGRESS_STATUS AfterExecuteSelect

'ListBox listbox_InductionCourses Initialize Data Source @109-5816AC19
        listbox_InductionCoursesDataCommand.Dao._optimized = False
        Dim listbox_InductionCoursestableIndex As Integer = 0
        listbox_InductionCoursesDataCommand.OrderBy = "status desc, induction_title asc"
        listbox_InductionCoursesDataCommand.Parameters.Clear()
'End ListBox listbox_InductionCourses Initialize Data Source

'ListBox listbox_InductionCourses BeforeExecuteSelect @109-95253ED5
        Try
            ListBoxSource=listbox_InductionCoursesDataCommand.Execute().Tables(listbox_InductionCoursestableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox listbox_InductionCourses BeforeExecuteSelect

'ListBox listbox_InductionCourses AfterExecuteSelect @109-9638889A
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("id"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("TITLE")
            item.listbox_InductionCoursesItems.Add(Key, Val)
        Next
'End ListBox listbox_InductionCourses AfterExecuteSelect

'Record STAFF_INDUCTIONS_PROGRESS AfterExecuteSelect tail @35-E31F8E2A
    End Sub
'End Record STAFF_INDUCTIONS_PROGRESS AfterExecuteSelect tail

'Record STAFF_INDUCTIONS_PROGRESS Data Provider Class @35-A61BA892
End Class

'End Record STAFF_INDUCTIONS_PROGRESS Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

