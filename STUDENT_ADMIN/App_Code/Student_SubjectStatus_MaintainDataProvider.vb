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

Namespace DECV_PROD2007.Student_SubjectStatus_Maintain 'Namespace @1-28174ECF

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

'Record Student_SubjectStatus_search Item Class @3-C0DE61F4
Public Class Student_SubjectStatus_searchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public s_STAFF_SUBJECT_ID As TextField
    Public s_STAFF_SUBJECT_IDItems As ItemCollection
    Public s_Staff_ID As TextField
    Public List_Staff_ID As TextField
    Public List_Staff_IDItems As ItemCollection
    Public hidden_Staff_id As TextField
    Public selected_STAFF_SUBJECT_ID As TextField
    Public selected_STAFF_SUBJECT_IDItems As ItemCollection
    Public s_DefaultingFlag As TextField
    Public s_DefaultingFlagItems As ItemCollection
    Public Sub New()
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    s_STAFF_SUBJECT_ID = New TextField("", Nothing)
    s_STAFF_SUBJECT_IDItems = New ItemCollection()
    s_Staff_ID = New TextField("", Nothing)
    List_Staff_ID = New TextField("", Nothing)
    List_Staff_IDItems = New ItemCollection()
    hidden_Staff_id = New TextField("", DBUtility.UserLogin.ToUpper)
    selected_STAFF_SUBJECT_ID = New TextField("", Nothing)
    selected_STAFF_SUBJECT_IDItems = New ItemCollection()
    s_DefaultingFlag = New TextField("", "[D]")
    s_DefaultingFlagItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As Student_SubjectStatus_searchItem
        Dim item As Student_SubjectStatus_searchItem = New Student_SubjectStatus_searchItem()
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_STAFF_SUBJECT_ID")) Then
        item.s_STAFF_SUBJECT_ID.SetValue(DBUtility.GetInitialValue("s_STAFF_SUBJECT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_Staff_ID")) Then
        item.s_Staff_ID.SetValue(DBUtility.GetInitialValue("s_Staff_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("List_Staff_ID")) Then
        item.List_Staff_ID.SetValue(DBUtility.GetInitialValue("List_Staff_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_Staff_id")) Then
        item.hidden_Staff_id.SetValue(DBUtility.GetInitialValue("hidden_Staff_id"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("selected_STAFF_SUBJECT_ID")) Then
        item.selected_STAFF_SUBJECT_ID.SetValue(DBUtility.GetInitialValue("selected_STAFF_SUBJECT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_DefaultingFlag")) Then
        item.s_DefaultingFlag.SetValue(DBUtility.GetInitialValue("s_DefaultingFlag"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "ClearParameters"
                    Return ClearParameters
                Case "s_STAFF_SUBJECT_ID"
                    Return s_STAFF_SUBJECT_ID
                Case "s_Staff_ID"
                    Return s_Staff_ID
                Case "List_Staff_ID"
                    Return List_Staff_ID
                Case "hidden_Staff_id"
                    Return hidden_Staff_id
                Case "selected_STAFF_SUBJECT_ID"
                    Return selected_STAFF_SUBJECT_ID
                Case "s_DefaultingFlag"
                    Return s_DefaultingFlag
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ClearParameters"
                    ClearParameters = CType(value, TextField)
                Case "s_STAFF_SUBJECT_ID"
                    s_STAFF_SUBJECT_ID = CType(value, TextField)
                Case "s_Staff_ID"
                    s_Staff_ID = CType(value, TextField)
                Case "List_Staff_ID"
                    List_Staff_ID = CType(value, TextField)
                Case "hidden_Staff_id"
                    hidden_Staff_id = CType(value, TextField)
                Case "selected_STAFF_SUBJECT_ID"
                    selected_STAFF_SUBJECT_ID = CType(value, TextField)
                Case "s_DefaultingFlag"
                    s_DefaultingFlag = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As Student_SubjectStatus_searchDataProvider)
'End Record Student_SubjectStatus_search Item Class

'Record Student_SubjectStatus_search Item Class tail @3-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record Student_SubjectStatus_search Item Class tail

'Record Student_SubjectStatus_search Data Provider Class @3-A259CD21
Public Class Student_SubjectStatus_searchDataProvider
Inherits RecordDataProviderBase
'End Record Student_SubjectStatus_search Data Provider Class

'Record Student_SubjectStatus_search Data Provider Class Variables @3-2E86C692
    Protected s_STAFF_SUBJECT_IDDataCommand As DataCommand=new SqlCommand("select * from view_ReportParams_Subjects" & vbCrLf & _
          "where subject_id in " & vbCrLf & _
          "(select subject_ID " & vbCrLf & _
          "from " & vbCrLf & _
          "student_subject where " & vbCrLf & _
          "SUBJ_ENROL_STATUS='D' " & vbCrLf & _
          " AND ENROLMENT_YEAR=year(getdate())" & vbCrLf & _
          " and staff_id='{hidden_Staff_id}'" & vbCrLf & _
          " ){SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
    Protected List_Staff_IDDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM View_StaffList_Active_Inactive {SQL_Where} {SQL_OrderBy}", New String(){"expr145"},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected selected_STAFF_SUBJECT_IDDataCommand As DataCommand=new SqlCommand("select * from view_ReportParams_Subjects" & vbCrLf & _
          "where subject_id in " & vbCrLf & _
          "(select subject_ID " & vbCrLf & _
          "from " & vbCrLf & _
          "student_subject where " & vbCrLf & _
          "SUBJ_ENROL_STATUS='D' " & vbCrLf & _
          " AND ENROLMENT_YEAR=year(getdate())" & vbCrLf & _
          " and staff_id='{hidden_Staff_id}'" & vbCrLf & _
          " ){SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
    Public Urlhidden_Staff_id As TextParameter
    Protected item As Student_SubjectStatus_searchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record Student_SubjectStatus_search Data Provider Class Variables

'Record Student_SubjectStatus_search Data Provider Class GetResultSet Method @3-06B7E8B9

    Public Sub FillItem(ByVal item As Student_SubjectStatus_searchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record Student_SubjectStatus_search Data Provider Class GetResultSet Method

'Record Student_SubjectStatus_search BeforeBuildSelect @3-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record Student_SubjectStatus_search BeforeBuildSelect

'Record Student_SubjectStatus_search AfterExecuteSelect @3-83591636
        End If
            IsInsertMode = True
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record Student_SubjectStatus_search AfterExecuteSelect

'ListBox s_STAFF_SUBJECT_ID Initialize Data Source @57-FABB9B63
        s_STAFF_SUBJECT_IDDataCommand.Dao._optimized = False
        Dim s_STAFF_SUBJECT_IDtableIndex As Integer = 0
        s_STAFF_SUBJECT_IDDataCommand.OrderBy = "SUBJECT_TITLE"
        s_STAFF_SUBJECT_IDDataCommand.Parameters.Clear()
        CType(s_STAFF_SUBJECT_IDDataCommand,SqlCommand).AddParameter("hidden_Staff_id",Urlhidden_Staff_id, "")
'End ListBox s_STAFF_SUBJECT_ID Initialize Data Source

'ListBox s_STAFF_SUBJECT_ID BeforeExecuteSelect @57-47E2625E
        Try
            ListBoxSource=s_STAFF_SUBJECT_IDDataCommand.Execute().Tables(s_STAFF_SUBJECT_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox s_STAFF_SUBJECT_ID BeforeExecuteSelect

'ListBox s_STAFF_SUBJECT_ID AfterExecuteSelect @57-84D93B92
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("SUBJECT_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("subject_displaylabel")
            item.s_STAFF_SUBJECT_IDItems.Add(Key, Val)
        Next
'End ListBox s_STAFF_SUBJECT_ID AfterExecuteSelect

'ListBox List_Staff_ID Initialize Data Source @80-B6E0DAD6
        List_Staff_IDDataCommand.Dao._optimized = False
        Dim List_Staff_IDtableIndex As Integer = 0
        List_Staff_IDDataCommand.OrderBy = "status_type"
        List_Staff_IDDataCommand.Parameters.Clear()
        List_Staff_IDDataCommand.Parameters.Add("expr145","(status = 1)")
'End ListBox List_Staff_ID Initialize Data Source

'ListBox List_Staff_ID BeforeExecuteSelect @80-001B6337
        Try
            ListBoxSource=List_Staff_IDDataCommand.Execute().Tables(List_Staff_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox List_Staff_ID BeforeExecuteSelect

'ListBox List_Staff_ID AfterExecuteSelect @80-51236CA6
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("staff_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("staffname")
            item.List_Staff_IDItems.Add(Key, Val)
        Next
'End ListBox List_Staff_ID AfterExecuteSelect

'ListBox selected_STAFF_SUBJECT_ID Initialize Data Source @110-A73FAA3C
        selected_STAFF_SUBJECT_IDDataCommand.Dao._optimized = False
        Dim selected_STAFF_SUBJECT_IDtableIndex As Integer = 0
        selected_STAFF_SUBJECT_IDDataCommand.OrderBy = "SUBJECT_TITLE"
        selected_STAFF_SUBJECT_IDDataCommand.Parameters.Clear()
        CType(selected_STAFF_SUBJECT_IDDataCommand,SqlCommand).AddParameter("hidden_Staff_id",Urlhidden_Staff_id, "")
'End ListBox selected_STAFF_SUBJECT_ID Initialize Data Source

'ListBox selected_STAFF_SUBJECT_ID BeforeExecuteSelect @110-0557E7D2
        Try
            ListBoxSource=selected_STAFF_SUBJECT_IDDataCommand.Execute().Tables(selected_STAFF_SUBJECT_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox selected_STAFF_SUBJECT_ID BeforeExecuteSelect

'ListBox selected_STAFF_SUBJECT_ID AfterExecuteSelect @110-D1E9EC88
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("SUBJECT_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("subject_displaylabel")
            item.selected_STAFF_SUBJECT_IDItems.Add(Key, Val)
        Next
'End ListBox selected_STAFF_SUBJECT_ID AfterExecuteSelect

'ListBox s_DefaultingFlag AfterExecuteSelect @139-61C56104
        
item.s_DefaultingFlagItems.Add("[D]","<strong>Defaulting Only</strong>")
item.s_DefaultingFlagItems.Add("[CD]","Current AND Defaulting")
'End ListBox s_DefaultingFlag AfterExecuteSelect

'Record Student_SubjectStatus_search AfterExecuteSelect tail @3-E31F8E2A
    End Sub
'End Record Student_SubjectStatus_search AfterExecuteSelect tail

'Record Student_SubjectStatus_search Data Provider Class @3-A61BA892
End Class

'End Record Student_SubjectStatus_search Data Provider Class

'EditableGrid Student_SubjectStatus_Result Item Class @13-0267FF8F
Public Class Student_SubjectStatus_ResultItem
    Public errors As NameValueCollection = New NameValueCollection()
    Public RowId As Integer
    Private _deleteAllowed As Boolean = False
    Private _isNew As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Student_SubjectStatus_TotalRecords As TextField
    Public SS_SUBJECT_ID As IntegerField
    Public SS_STUDENT_ID As FloatField
    Public SS_STUDENT_IDHref As Object
    Public SS_STUDENT_IDHrefParameters As LinkParameterCollection
    Public SUBJ_ENROL_STATUS As TextField
    Public NUM_OF_ASSIGNMENTS As IntegerField
    Public DEFAULTING_STATUS_ID As TextField
    Public DEFAULTING_STATUS_IDItems As ItemCollection
    Public lbl_StudentName As TextField
    Public Lbl_Warning_Letter As TextField
    Public Lbl_Warning_Sent_Date As DateField
    Public WARNING_LETTER_Id As TextField
    Public WARNING_LETTER_IdItems As ItemCollection
    Public WARNING_SENT_DATE As DateField
    Public lbl_StudentEmail As TextField
    Public lbl_StudentEmailHref As Object
    Public lbl_StudentEmailHrefParameters As LinkParameterCollection
    Public label_ALERTS As TextField
    Public lblDefaultingStatusDate As DateField
    Public Hidden_DefaultingStatus As TextField
    Public LIST_OF_ASSIGNMENTS As TextField
    Public DEFAULTING_STATUS_DATE As DateField
    Public Sub New()
    Student_SubjectStatus_TotalRecords = New TextField("", Nothing)
    SS_SUBJECT_ID = New IntegerField("", Nothing)
    SS_STUDENT_ID = New FloatField("",Nothing)
    SS_STUDENT_IDHrefParameters = New LinkParameterCollection()
    SUBJ_ENROL_STATUS = New TextField("", Nothing)
    NUM_OF_ASSIGNMENTS = New IntegerField("", Nothing)
    DEFAULTING_STATUS_ID = New TextField("", Nothing)
    DEFAULTING_STATUS_IDItems = New ItemCollection()
    lbl_StudentName = New TextField("", Nothing)
    Lbl_Warning_Letter = New TextField("", Nothing)
    Lbl_Warning_Sent_Date = New DateField("dd\/MM\/yyyy", Nothing)
    WARNING_LETTER_Id = New TextField("", Nothing)
    WARNING_LETTER_IdItems = New ItemCollection()
    WARNING_SENT_DATE = New DateField("dd\/MM\/yy", Nothing)
    lbl_StudentEmail = New TextField("",Nothing)
    lbl_StudentEmailHrefParameters = New LinkParameterCollection()
    label_ALERTS = New TextField("", "Bob")
    lblDefaultingStatusDate = New DateField("dd\/MM\/yyyy", Nothing)
    Hidden_DefaultingStatus = New TextField("", "")
    LIST_OF_ASSIGNMENTS = New TextField("", "<em>none</em>")
    DEFAULTING_STATUS_DATE = New DateField("dd\/MM\/yy", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase
        Get
            Select fieldName
                Case "STUDENT_IDField"
                    Return Me.STUDENT_IDField
                Case "SUBJECT_IDField"
                    Return Me.SUBJECT_IDField
                Case "Student_SubjectStatus_TotalRecords"
                    Return Me.Student_SubjectStatus_TotalRecords
                Case "SS_SUBJECT_ID"
                    Return Me.SS_SUBJECT_ID
                Case "SS_STUDENT_ID"
                    Return Me.SS_STUDENT_ID
                Case "SUBJ_ENROL_STATUS"
                    Return Me.SUBJ_ENROL_STATUS
                Case "NUM_OF_ASSIGNMENTS"
                    Return Me.NUM_OF_ASSIGNMENTS
                Case "DEFAULTING_STATUS_ID"
                    Return Me.DEFAULTING_STATUS_ID
                Case "lbl_StudentName"
                    Return Me.lbl_StudentName
                Case "Lbl_Warning_Letter"
                    Return Me.Lbl_Warning_Letter
                Case "Lbl_Warning_Sent_Date"
                    Return Me.Lbl_Warning_Sent_Date
                Case "WARNING_LETTER_Id"
                    Return Me.WARNING_LETTER_Id
                Case "WARNING_SENT_DATE"
                    Return Me.WARNING_SENT_DATE
                Case "lbl_StudentEmail"
                    Return Me.lbl_StudentEmail
                Case "label_ALERTS"
                    Return Me.label_ALERTS
                Case "lblDefaultingStatusDate"
                    Return Me.lblDefaultingStatusDate
                Case "Hidden_DefaultingStatus"
                    Return Me.Hidden_DefaultingStatus
                Case "LIST_OF_ASSIGNMENTS"
                    Return Me.LIST_OF_ASSIGNMENTS
                Case "DEFAULTING_STATUS_DATE"
                    Return Me.DEFAULTING_STATUS_DATE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_IDField"
                    Me.STUDENT_IDField = CType(Value,FloatField)
                Case "SUBJECT_IDField"
                    Me.SUBJECT_IDField = CType(Value,IntegerField)
                Case "Student_SubjectStatus_TotalRecords"
                    Me.Student_SubjectStatus_TotalRecords = CType(Value,TextField)
                Case "SS_SUBJECT_ID"
                    Me.SS_SUBJECT_ID = CType(Value,IntegerField)
                Case "SS_STUDENT_ID"
                    Me.SS_STUDENT_ID = CType(Value,FloatField)
                Case "SUBJ_ENROL_STATUS"
                    Me.SUBJ_ENROL_STATUS = CType(Value,TextField)
                Case "NUM_OF_ASSIGNMENTS"
                    Me.NUM_OF_ASSIGNMENTS = CType(Value,IntegerField)
                Case "DEFAULTING_STATUS_ID"
                    Me.DEFAULTING_STATUS_ID = CType(Value,TextField)
                Case "lbl_StudentName"
                    Me.lbl_StudentName = CType(Value,TextField)
                Case "Lbl_Warning_Letter"
                    Me.Lbl_Warning_Letter = CType(Value,TextField)
                Case "Lbl_Warning_Sent_Date"
                    Me.Lbl_Warning_Sent_Date = CType(Value,DateField)
                Case "WARNING_LETTER_Id"
                    Me.WARNING_LETTER_Id = CType(Value,TextField)
                Case "WARNING_SENT_DATE"
                    Me.WARNING_SENT_DATE = CType(Value,DateField)
                Case "lbl_StudentEmail"
                    Me.lbl_StudentEmail = CType(Value,TextField)
                Case "label_ALERTS"
                    Me.label_ALERTS = CType(Value,TextField)
                Case "lblDefaultingStatusDate"
                    Me.lblDefaultingStatusDate = CType(Value,DateField)
                Case "Hidden_DefaultingStatus"
                    Me.Hidden_DefaultingStatus = CType(Value,TextField)
                Case "LIST_OF_ASSIGNMENTS"
                    Me.LIST_OF_ASSIGNMENTS = CType(Value,TextField)
                Case "DEFAULTING_STATUS_DATE"
                    Me.DEFAULTING_STATUS_DATE = CType(Value,DateField)
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
            result = IsNothing(DEFAULTING_STATUS_ID.Value) And result
            result = IsNothing(WARNING_LETTER_Id.Value) And result
            result = IsNothing(WARNING_SENT_DATE.Value) And result
            result = IsNothing(Hidden_DefaultingStatus.Value) And result
            result = IsNothing(DEFAULTING_STATUS_DATE.Value) And result
            Return result
        End Get
    End Property

    Public IsDeleted As Boolean = False
    Public IsUpdated As Boolean = False
    Public STUDENT_IDField As FloatField = New FloatField()
    Public SUBJECT_IDField As IntegerField = New IntegerField()
    Public Function Validate(ByVal provider As Student_SubjectStatus_ResultDataProvider) As Boolean
'End EditableGrid Student_SubjectStatus_Result Item Class


'EditableGrid Student_SubjectStatus_Result Item Class tail @13-11D8DCF0
        Return errors.Count = 0
    End Function
    Public RawData As DataRow = Nothing
End Class
'End EditableGrid Student_SubjectStatus_Result Item Class tail

'EditableGrid Student_SubjectStatus_Result Data Provider Class Header @13-58BDAA5C
Public Class Student_SubjectStatus_ResultDataProvider
Inherits EditableGridDataProviderBase
'End EditableGrid Student_SubjectStatus_Result Data Provider Class Header

'Grid Student_SubjectStatus_Result Data Provider Class Variables @13-4B5AA840

    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_ASSIGNMENT_SUBMISSION_SUBJECT_ID
        Sorter_ASSIGNMENT_SUBMISSION_STUDENT_ID
        Sorter_SUBJ_ENROL_STATUS
        Sorter_ASSMT_SUBMISSIONS
        Sorter_WARNING_LETTER
        Sorter_Warning_Sent_Date
        Sorter_DEFAULTING_STATUS_DATE
        Sorter_DEFAULTING_STATUS
    End Enum

    Private SortFieldsNames As String() = New String() {"","SUBJECT_ID","STUDENT_ID","SUBJ_ENROL_STATUS","NUM_ASSMT_SUBMISSIONS","WARNING_LETTER","WARNING_SENT_DATE","DEFAULTING_STATUS_DATE","DEFAULTING_STATUS"}
    Private SortFieldsNamesDesc As String() = New string() {"","SUBJECT_ID DESC","STUDENT_ID DESC","SUBJ_ENROL_STATUS DESC","NUM_ASSMT_SUBMISSIONS DESC","WARNING_LETTER DESC","WARNING_SENT_DATE DESC","DEFAULTING_STATUS_DATE DESC","DEFAULTING_STATUS DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 50
    Public PageNumber As Integer = 1
    Public Urlhidden_Staff_id  As TextParameter
    Public Urls_DefaultingFlag  As TextParameter
    Public Urls_STAFF_SUBJECT_ID  As IntegerParameter
    Public Urlselected_STAFF_SUBJECT_ID  As IntegerParameter
    Public CtrlDEFAULTING_STATUS_ID  As TextParameter
    Public CtrlWARNING_LETTER_Id  As TextParameter
    Public CtrlWARNING_SENT_DATE  As DateParameter
    Public CtrlDEFAULTING_STATUS_DATE  As DateParameter
'End Grid Student_SubjectStatus_Result Data Provider Class Variables

'EditableGrid Student_SubjectStatus_Result Data Provider Class Constructor @13-C6652973

    Public Sub New()
        Select_=new SqlCommand("SELECT STUDENT_ID, SUBJECT_ID, SUBJ_ENROL_STATUS, NUM_ASSMT_SUBMISSIONS, DEFAULTING_STATUS" & _
          ", DEFAULTING_STATUS_DATE, WARNING_LETTER," & vbCrLf & _
          "WARNING_SENT_DATE " & vbCrLf & _
          "FROM STUDENT_SUBJECT" & vbCrLf & _
          "WHERE ( STUDENT_SUBJECT.ENROLMENT_YEAR=year(getdate()) )" & vbCrLf & _
          "AND STUDENT_SUBJECT.STAFF_ID = '{hidden_Staff_id}'" & vbCrLf & _
          "AND ( SUBJ_ENROL_STATUS LIKE '{s_DefaultingFlag}' )" & vbCrLf & _
          "AND ( STUDENT_SUBJECT.SUBJECT_ID = {s_STAFF_SUBJECT_ID} " & vbCrLf & _
          "OR SUBJECT_ID = {selected_STAFF_SUBJECT_ID} ) ",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (SELECT STUDENT_ID, SUBJECT_ID, SUBJ_ENROL_STATUS, NUM_ASSMT_SUBMISSI" & _
          "ONS, DEFAULTING_STATUS, DEFAULTING_STATUS_DATE, WARNING_LETTER," & vbCrLf & _
          "WARNING_SENT_DATE " & vbCrLf & _
          "FROM STUDENT_SUBJECT" & vbCrLf & _
          "WHERE ( STUDENT_SUBJECT.ENROLMENT_YEAR=year(getdate()) )" & vbCrLf & _
          "AND STUDENT_SUBJECT.STAFF_ID = '{hidden_Staff_id}'" & vbCrLf & _
          "AND ( SUBJ_ENROL_STATUS LIKE '{s_DefaultingFlag}' )" & vbCrLf & _
          "AND ( STUDENT_SUBJECT.SUBJECT_ID = {s_STAFF_SUBJECT_ID} " & vbCrLf & _
          "OR SUBJECT_ID = {selected_STAFF_SUBJECT_ID} ) ) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End EditableGrid Student_SubjectStatus_Result Data Provider Class Constructor

'Record Student_SubjectStatus_Result Data Provider Class CheckUnique Method @13-BE1C4EC9

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As Student_SubjectStatus_ResultItem) As Boolean
        Return True
    End Function
'End Record Student_SubjectStatus_Result Data Provider Class CheckUnique Method

'EditableGrid Student_SubjectStatus_Result Data Provider Class Update Method @13-D6DC6AC0
    Protected Function UpdateItem(ByVal item As Student_SubjectStatus_ResultItem) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        IsParametersPassed = Not(IsNothing(item.STUDENT_IDField) Or IsNothing(item.SUBJECT_IDField))
        Dim Update As DataCommand=new TableCommand("UPDATE STUDENT_SUBJECT SET DEFAULTING_STATUS={DEFAULTING_STATUS}, " & vbCrLf & _
          "WARNING_LETTER={WARNING_LETTER}, WARNING_SENT_DATE={WARNING_SENT_DATE}, " & vbCrLf & _
          "DEFAULTING_STATUS_DATE={DEFAULTING_STATUS_DATE}", New String(){"expr155","And","STUDENT_ID156","And","SUBJECT_ID157"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End EditableGrid Student_SubjectStatus_Result Data Provider Class Update Method

'EditableGrid Student_SubjectStatus_Result Event BeforeBuildUpdate. Action Custom Code @128-73254650
    ' -------------------------
    'ERA: 7-May-2012|EA| if the Defaulting Status (hidden) was blank, and the drop down is now non-blank, then
	' update the DEFAULTING_STATUS_DATE to today.
	' To be done.........


    ' -------------------------
'End EditableGrid Student_SubjectStatus_Result Event BeforeBuildUpdate. Action Custom Code

'EditableGrid Student_SubjectStatus_Result BeforeBuildUpdate @13-B44FD8B6
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID156",item.STUDENT_IDField, "","STUDENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("SUBJECT_ID157",item.SUBJECT_IDField, "","SUBJECT_ID",Condition.Equal,False)
        Update.Parameters.Add("expr155","(ENROLMENT_YEAR = YEAR(GETDATE()))")
        If item.DEFAULTING_STATUS_ID.Value Is Nothing Then
            Update.SqlQuery.Replace("{DEFAULTING_STATUS}",Update.Dao.ToSql(Nothing,FieldType._Text))
        Else
            Update.SqlQuery.Replace("{DEFAULTING_STATUS}",Update.Dao.ToSql(item.DEFAULTING_STATUS_ID.GetFormattedValue(""),FieldType._Text))
        End If
        If item.WARNING_LETTER_Id.Value Is Nothing Then
            Update.SqlQuery.Replace("{WARNING_LETTER}",Update.Dao.ToSql(Nothing,FieldType._Text))
        Else
            Update.SqlQuery.Replace("{WARNING_LETTER}",Update.Dao.ToSql(item.WARNING_LETTER_Id.GetFormattedValue(""),FieldType._Text))
        End If
        If item.WARNING_SENT_DATE.Value Is Nothing Then
            Update.SqlQuery.Replace("{WARNING_SENT_DATE}",Update.Dao.ToSql(Nothing,FieldType._Date))
        Else
            Update.SqlQuery.Replace("{WARNING_SENT_DATE}",Update.Dao.ToSql(item.WARNING_SENT_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date))
        End If
        If item.DEFAULTING_STATUS_DATE.Value Is Nothing Then
            Update.SqlQuery.Replace("{DEFAULTING_STATUS_DATE}",Update.Dao.ToSql(Nothing,FieldType._Date))
        Else
            Update.SqlQuery.Replace("{DEFAULTING_STATUS_DATE}",Update.Dao.ToSql(item.DEFAULTING_STATUS_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date))
        End If
'End EditableGrid Student_SubjectStatus_Result BeforeBuildUpdate

'EditableGrid Student_SubjectStatus_Result Execute Update  @13-24B27D7E
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
            Catch e_ As Exception
                item.errors.Add("DataProvider",e_.Source + ":" + e_.Message)
            Finally
'End EditableGrid Student_SubjectStatus_Result Execute Update 

'EditableGrid Student_SubjectStatus_Result AfterExecuteUpdate @13-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid Student_SubjectStatus_Result AfterExecuteUpdate

'Grid Student_SubjectStatus_Result Data Provider Class GetResultSet Method @13-6CF54B11
    Public Sub Update(Items As ArrayList, ops As FormSupportedOperations)
        Dim i As Integer
        For i = 0 To Items.Count - 1
            Dim op As EditableGridOperation = EditableGridOperation.Insert
            Dim isProcessed As Boolean = False
            Dim item As Student_SubjectStatus_ResultItem = CType(Items(i), Student_SubjectStatus_ResultItem)
'End Grid Student_SubjectStatus_Result Data Provider Class GetResultSet Method

'EditableGrid Student_SubjectStatus_Result Data Provider Class Update @13-B4FF46D4
            If Not item.IsUpdated Then
                If Not(item.IsEmptyItem) And ops.AllowUpdate And Not(isProcessed) Then
                    UpdateItem(item)
                    op = EditableGridOperation.Update
                End If
'End EditableGrid Student_SubjectStatus_Result Data Provider Class Update

'EditableGrid Student_SubjectStatus_Result Data Provider Class AfterUpdate @13-6CCB76B9
                If item.errors.Count = 0 Then item.IsUpdated = True
                OnItemUpdated(New ItemUpdatedEventArgs(op, item))
            End If
        Next i
    End Sub
'End EditableGrid Student_SubjectStatus_Result Data Provider Class AfterUpdate

'EditableGrid Student_SubjectStatus_Result Data Provider Class GetResultSet Method @13-414792E7
    Public Function GetResultSet(ByRef _pagesCount As Integer, ops As FormSupportedOperations) As Student_SubjectStatus_ResultItem()
'End EditableGrid Student_SubjectStatus_Result Data Provider Class GetResultSet Method

'Before build Select @13-278439AE
        _pagesCount = 0
        Dim E as Exception = Nothing
        Dim j As Integer
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("hidden_Staff_id",Urlhidden_Staff_id, "")
        CType(Select_,SqlCommand).AddParameter("s_DefaultingFlag",Urls_DefaultingFlag, "")
        CType(Select_,SqlCommand).AddParameter("s_STAFF_SUBJECT_ID",Urls_STAFF_SUBJECT_ID, "")
        CType(Select_,SqlCommand).AddParameter("selected_STAFF_SUBJECT_ID",Urlselected_STAFF_SUBJECT_ID, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy = SortFieldsNames(CInt(SortField)).Trim
        Else
            Select_.OrderBy = SortFieldsNamesDesc(CInt(SortField)).Trim
        End If
    Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @13-939614DD
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

'After execute Select @13-17FC8682
                If Not IsNothing(E) Then Throw E
            End Try
            dr = ds.Tables(tableIndex).Rows
            rowCount = dr.Count
        End If
        Dim result(rowCount - 1) As Student_SubjectStatus_ResultItem
'End After execute Select

'ListBox DEFAULTING_STATUS_ID AfterExecuteSelect @55-DF85CED9
    Dim DEFAULTING_STATUS_IDItems As ItemCollection = New ItemCollection()
    
DEFAULTING_STATUS_IDItems.Add("A","No - Do not Send")
DEFAULTING_STATUS_IDItems.Add("I","Yes - Send Warning")
'End ListBox DEFAULTING_STATUS_ID AfterExecuteSelect

'ListBox WARNING_LETTER_Id AfterExecuteSelect @87-66C86951
    Dim WARNING_LETTER_IdItems As ItemCollection = New ItemCollection()
    
WARNING_LETTER_IdItems.Add("Y","YES")
WARNING_LETTER_IdItems.Add("N","NO")
'End ListBox WARNING_LETTER_Id AfterExecuteSelect

'After execute Select tail @13-18D9F3F0
        Dim i as Integer
        For i = 0 To rowCount - 1
            Dim item as Student_SubjectStatus_ResultItem = New Student_SubjectStatus_ResultItem()
            item.SS_SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
            item.SS_STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.SS_STUDENT_IDHref = "StudentSummary.aspx"
            item.SS_STUDENT_IDHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
            item.SUBJ_ENROL_STATUS.SetValue(dr(i)("SUBJ_ENROL_STATUS"),"")
            item.NUM_OF_ASSIGNMENTS.SetValue(dr(i)("NUM_ASSMT_SUBMISSIONS"),"")
            item.DEFAULTING_STATUS_ID.SetValue(dr(i)("DEFAULTING_STATUS"),"")
            item.DEFAULTING_STATUS_IDItems = CType(DEFAULTING_STATUS_IDItems.Clone(), ItemCollection)
            item.Lbl_Warning_Letter.SetValue(dr(i)("WARNING_LETTER"),"")
            item.Lbl_Warning_Sent_Date.SetValue(dr(i)("WARNING_SENT_DATE"),Select_.DateFormat)
            item.WARNING_LETTER_Id.SetValue(dr(i)("WARNING_LETTER"),"")
            item.WARNING_LETTER_IdItems = CType(WARNING_LETTER_IdItems.Clone(), ItemCollection)
            item.WARNING_SENT_DATE.SetValue(dr(i)("WARNING_SENT_DATE"),Select_.DateFormat)
            item.lbl_StudentEmailHref = ""
            item.lblDefaultingStatusDate.SetValue(dr(i)("DEFAULTING_STATUS_DATE"),Select_.DateFormat)
            item.DEFAULTING_STATUS_DATE.SetValue(dr(i)("DEFAULTING_STATUS_DATE"),Select_.DateFormat)
            item.STUDENT_IDField.SetValue(dr(i)("STUDENT_ID"),"")
            item.SUBJECT_IDField.SetValue(dr(i)("SUBJECT_ID"),"")
            item.RawData = dr(i)
            result(i)=item
        Next i
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @13-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

