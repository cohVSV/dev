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

Namespace DECV_PROD2007.StudentAmendment 'Namespace @1-B9580602

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

'Record TeacherAllocations_Search Item Class @3-4D4FF9A5
Public Class TeacherAllocations_SearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_STUDENT_ID_lowest As IntegerField
    Public listRowsPerPage As IntegerField
    Public listRowsPerPageItems As ItemCollection
    Public s_YEAR_LEVEL As IntegerField
    Public s_YEAR_LEVELItems As ItemCollection
    Public s_SUBJ_ENROL_STATUS As TextField
    Public s_SUBJ_ENROL_STATUSItems As ItemCollection
    Public s_ENROLMENT_YEAR As FloatField
    Public Sub New()
    s_STUDENT_ID_lowest = New IntegerField("", Nothing)
    listRowsPerPage = New IntegerField("", 80)
    listRowsPerPageItems = New ItemCollection()
    s_YEAR_LEVEL = New IntegerField("", 99)
    s_YEAR_LEVELItems = New ItemCollection()
    s_SUBJ_ENROL_STATUS = New TextField("", "[CEPD]")
    s_SUBJ_ENROL_STATUSItems = New ItemCollection()
    s_ENROLMENT_YEAR = New FloatField("", Year(Today))
    End Sub

    Public Shared Function CreateFromHttpRequest() As TeacherAllocations_SearchItem
        Dim item As TeacherAllocations_SearchItem = New TeacherAllocations_SearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("s_STUDENT_ID_lowest")) Then
        item.s_STUDENT_ID_lowest.SetValue(DBUtility.GetInitialValue("s_STUDENT_ID_lowest"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("listRowsPerPage")) Then
        item.listRowsPerPage.SetValue(DBUtility.GetInitialValue("listRowsPerPage"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_YEAR_LEVEL")) Then
        item.s_YEAR_LEVEL.SetValue(DBUtility.GetInitialValue("s_YEAR_LEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_SUBJ_ENROL_STATUS")) Then
        item.s_SUBJ_ENROL_STATUS.SetValue(DBUtility.GetInitialValue("s_SUBJ_ENROL_STATUS"))
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
                Case "s_STUDENT_ID_lowest"
                    Return s_STUDENT_ID_lowest
                Case "listRowsPerPage"
                    Return listRowsPerPage
                Case "s_YEAR_LEVEL"
                    Return s_YEAR_LEVEL
                Case "s_SUBJ_ENROL_STATUS"
                    Return s_SUBJ_ENROL_STATUS
                Case "s_ENROLMENT_YEAR"
                    Return s_ENROLMENT_YEAR
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_STUDENT_ID_lowest"
                    s_STUDENT_ID_lowest = CType(value, IntegerField)
                Case "listRowsPerPage"
                    listRowsPerPage = CType(value, IntegerField)
                Case "s_YEAR_LEVEL"
                    s_YEAR_LEVEL = CType(value, IntegerField)
                Case "s_SUBJ_ENROL_STATUS"
                    s_SUBJ_ENROL_STATUS = CType(value, TextField)
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

's_STUDENT_ID_lowest validate @5-0939E65B
        If IsNothing(s_STUDENT_ID_lowest.Value) OrElse s_STUDENT_ID_lowest.Value.ToString() ="" Then
            errors.Add("s_STUDENT_ID_lowest",String.Format(Resources.strings.CCS_RequiredField,"lowest Student ID"))
        End If
'End s_STUDENT_ID_lowest validate

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

'Record TeacherAllocations_Search Data Provider Class Variables @3-5DBD6AA8
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

'Record TeacherAllocations_Search AfterExecuteSelect @3-79426A21
        End If
            IsInsertMode = True
'End Record TeacherAllocations_Search AfterExecuteSelect

'ListBox listRowsPerPage AfterExecuteSelect @16-2C72B1C6
        
item.listRowsPerPageItems.Add("10","10")
item.listRowsPerPageItems.Add("20","20")
item.listRowsPerPageItems.Add("80","80")
item.listRowsPerPageItems.Add("100","100")
item.listRowsPerPageItems.Add("200","200")
'End ListBox listRowsPerPage AfterExecuteSelect

'ListBox s_YEAR_LEVEL AfterExecuteSelect @6-F924C239
        
item.s_YEAR_LEVELItems.Add("99","All")
item.s_YEAR_LEVELItems.Add("0","0")
item.s_YEAR_LEVELItems.Add("1","1")
item.s_YEAR_LEVELItems.Add("2","2")
item.s_YEAR_LEVELItems.Add("3","3")
item.s_YEAR_LEVELItems.Add("4","4")
item.s_YEAR_LEVELItems.Add("5","5")
item.s_YEAR_LEVELItems.Add("6","6")
item.s_YEAR_LEVELItems.Add("7","7")
item.s_YEAR_LEVELItems.Add("8","8")
item.s_YEAR_LEVELItems.Add("9","9")
item.s_YEAR_LEVELItems.Add("10","10")
item.s_YEAR_LEVELItems.Add("11","11")
item.s_YEAR_LEVELItems.Add("12","12")
item.s_YEAR_LEVELItems.Add("30","Home Schooled")
'End ListBox s_YEAR_LEVEL AfterExecuteSelect

'ListBox s_SUBJ_ENROL_STATUS AfterExecuteSelect @8-8EC5DF8B
        
item.s_SUBJ_ENROL_STATUSItems.Add("[CEPD]","Active Students")
item.s_SUBJ_ENROL_STATUSItems.Add("[CEPDNF]","All Students")
'End ListBox s_SUBJ_ENROL_STATUS AfterExecuteSelect

'Record TeacherAllocations_Search AfterExecuteSelect tail @3-E31F8E2A
    End Sub
'End Record TeacherAllocations_Search AfterExecuteSelect tail

'Record TeacherAllocations_Search Data Provider Class @3-A61BA892
End Class

'End Record TeacherAllocations_Search Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

