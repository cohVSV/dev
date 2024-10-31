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

Namespace DECV_PROD2007.TeacherAllocations 'Namespace @1-22B4ACEA

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

'Record TeacherAllocations_Search Item Class @3-DE74AC3F
Public Class TeacherAllocations_SearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_SUBJECT_ID As IntegerField
    Public link_popupSubjectList As TextField
    Public link_popupSubjectListHref As Object
    Public link_popupSubjectListHrefParameters As LinkParameterCollection
    Public s_STAFF_ID As TextField
    Public s_STAFF_IDItems As ItemCollection
    Public s_SEMESTER As TextField
    Public s_SEMESTERItems As ItemCollection
    Public s_SUBJ_ENROL_STATUS As TextField
    Public s_SUBJ_ENROL_STATUSItems As ItemCollection
    Public s_APPEARS_ON_VASS As TextField
    Public s_APPEARS_ON_VASSItems As ItemCollection
    Public s_ENROLMENT_YEAR As FloatField
    Public Sub New()
    s_SUBJECT_ID = New IntegerField("", Nothing)
    link_popupSubjectList = New TextField("",Nothing)
    link_popupSubjectListHrefParameters = New LinkParameterCollection()
    s_STAFF_ID = New TextField("", Nothing)
    s_STAFF_IDItems = New ItemCollection()
    s_SEMESTER = New TextField("", "")
    s_SEMESTERItems = New ItemCollection()
    s_SUBJ_ENROL_STATUS = New TextField("", "[CEPD]")
    s_SUBJ_ENROL_STATUSItems = New ItemCollection()
    s_APPEARS_ON_VASS = New TextField("", "1,0")
    s_APPEARS_ON_VASSItems = New ItemCollection()
    s_ENROLMENT_YEAR = New FloatField("", Year(Today))
    End Sub

    Public Shared Function CreateFromHttpRequest() As TeacherAllocations_SearchItem
        Dim item As TeacherAllocations_SearchItem = New TeacherAllocations_SearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("s_SUBJECT_ID")) Then
        item.s_SUBJECT_ID.SetValue(DBUtility.GetInitialValue("s_SUBJECT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("link_popupSubjectList")) Then
        item.link_popupSubjectList.SetValue(DBUtility.GetInitialValue("link_popupSubjectList"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_STAFF_ID")) Then
        item.s_STAFF_ID.SetValue(DBUtility.GetInitialValue("s_STAFF_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_SEMESTER")) Then
        item.s_SEMESTER.SetValue(DBUtility.GetInitialValue("s_SEMESTER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_SUBJ_ENROL_STATUS")) Then
        item.s_SUBJ_ENROL_STATUS.SetValue(DBUtility.GetInitialValue("s_SUBJ_ENROL_STATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_APPEARS_ON_VASS")) Then
        item.s_APPEARS_ON_VASS.SetValue(DBUtility.GetInitialValue("s_APPEARS_ON_VASS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_ENROLMENT_YEAR")) Then
        item.s_ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("s_ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_SUBJECT_ID"
                    Return s_SUBJECT_ID
                Case "link_popupSubjectList"
                    Return link_popupSubjectList
                Case "s_STAFF_ID"
                    Return s_STAFF_ID
                Case "s_SEMESTER"
                    Return s_SEMESTER
                Case "s_SUBJ_ENROL_STATUS"
                    Return s_SUBJ_ENROL_STATUS
                Case "s_APPEARS_ON_VASS"
                    Return s_APPEARS_ON_VASS
                Case "s_ENROLMENT_YEAR"
                    Return s_ENROLMENT_YEAR
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_SUBJECT_ID"
                    s_SUBJECT_ID = CType(value, IntegerField)
                Case "link_popupSubjectList"
                    link_popupSubjectList = CType(value, TextField)
                Case "s_STAFF_ID"
                    s_STAFF_ID = CType(value, TextField)
                Case "s_SEMESTER"
                    s_SEMESTER = CType(value, TextField)
                Case "s_SUBJ_ENROL_STATUS"
                    s_SUBJ_ENROL_STATUS = CType(value, TextField)
                Case "s_APPEARS_ON_VASS"
                    s_APPEARS_ON_VASS = CType(value, TextField)
                Case "s_ENROLMENT_YEAR"
                    s_ENROLMENT_YEAR = CType(value, FloatField)
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

    Public Sub Validate(ByVal provider As TeacherAllocations_SearchDataProvider)
'End Record TeacherAllocations_Search Item Class

's_SUBJECT_ID validate @5-62A2FD7B
        If IsNothing(s_SUBJECT_ID.Value) OrElse s_SUBJECT_ID.Value.ToString() ="" Then
            errors.Add("s_SUBJECT_ID",String.Format(Resources.strings.CCS_RequiredField,"Subject ID"))
        End If
'End s_SUBJECT_ID validate

's_ENROLMENT_YEAR validate @10-43A9DC76
        If IsNothing(s_ENROLMENT_YEAR.Value) OrElse s_ENROLMENT_YEAR.Value.ToString() ="" Then
            errors.Add("s_ENROLMENT_YEAR",String.Format(Resources.strings.CCS_RequiredField,"Enrolment Year"))
        End If
'End s_ENROLMENT_YEAR validate

'Record TeacherAllocations_Search Item Class tail @3-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record TeacherAllocations_Search Item Class tail

'Record TeacherAllocations_Search Data Provider Class @3-A24580B6
Public Class TeacherAllocations_SearchDataProvider
Inherits RecordDataProviderBase
'End Record TeacherAllocations_Search Data Provider Class

'Record TeacherAllocations_Search Data Provider Class Variables @3-5C6470C7
    Protected s_STAFF_IDDataCommand As DataCommand=new TableCommand("SELECT staff_ID, " & vbCrLf & _
          "staffname " & vbCrLf & _
          "FROM View_StaffList_Active_Inactive {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected item As TeacherAllocations_SearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record TeacherAllocations_Search Data Provider Class Variables

'Record TeacherAllocations_Search Data Provider Class GetResultSet Method @3-E62E9C35

    Public Sub FillItem(ByVal item As TeacherAllocations_SearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record TeacherAllocations_Search Data Provider Class GetResultSet Method

'Record TeacherAllocations_Search BeforeBuildSelect @3-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record TeacherAllocations_Search BeforeBuildSelect

'Record TeacherAllocations_Search AfterExecuteSelect @3-83591636
        End If
            IsInsertMode = True
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record TeacherAllocations_Search AfterExecuteSelect

'ListBox s_STAFF_ID Initialize Data Source @6-9B36CFD1
        s_STAFF_IDDataCommand.Dao._optimized = False
        Dim s_STAFF_IDtableIndex As Integer = 0
        s_STAFF_IDDataCommand.OrderBy = "status_type, staff_ID"
        s_STAFF_IDDataCommand.Parameters.Clear()
'End ListBox s_STAFF_ID Initialize Data Source

'ListBox s_STAFF_ID BeforeExecuteSelect @6-DECFA859
        Try
            ListBoxSource=s_STAFF_IDDataCommand.Execute().Tables(s_STAFF_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox s_STAFF_ID BeforeExecuteSelect

'ListBox s_STAFF_ID AfterExecuteSelect @6-D61C394A
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("STAFF_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("staffname")
            item.s_STAFF_IDItems.Add(Key, Val)
        Next
'End ListBox s_STAFF_ID AfterExecuteSelect

'ListBox s_SEMESTER AfterExecuteSelect @7-7BABD35D
        
item.s_SEMESTERItems.Add("%25","")
item.s_SEMESTERItems.Add("1","1")
item.s_SEMESTERItems.Add("2","2")
item.s_SEMESTERItems.Add("B","Both")
'End ListBox s_SEMESTER AfterExecuteSelect

'ListBox s_SUBJ_ENROL_STATUS AfterExecuteSelect @8-D32A9F6B
        
item.s_SUBJ_ENROL_STATUSItems.Add("[CEPD]","Active Students")
item.s_SUBJ_ENROL_STATUSItems.Add("[CDEFPW]","All Students")
'End ListBox s_SUBJ_ENROL_STATUS AfterExecuteSelect

'ListBox s_APPEARS_ON_VASS AfterExecuteSelect @9-279B6180
        
item.s_APPEARS_ON_VASSItems.Add("1","Yes")
item.s_APPEARS_ON_VASSItems.Add("0","No")
item.s_APPEARS_ON_VASSItems.Add("1,0","All")
'End ListBox s_APPEARS_ON_VASS AfterExecuteSelect

'Record TeacherAllocations_Search AfterExecuteSelect tail @3-E31F8E2A
    End Sub
'End Record TeacherAllocations_Search AfterExecuteSelect tail

'Record TeacherAllocations_Search Data Provider Class @3-A61BA892
End Class

'End Record TeacherAllocations_Search Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

