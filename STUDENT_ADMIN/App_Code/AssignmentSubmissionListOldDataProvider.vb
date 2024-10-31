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

Namespace DECV_PROD2007.AssignmentSubmissionListOld 'Namespace @1-11EE52F8

'Page Data Class @1-00D755AD
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Link_Backtosummary As TextField
    Public Link_BacktosummaryHref As Object
    Public Link_BacktosummaryHrefParameters As LinkParameterCollection
    Public Link_BacktoPastoralList As TextField
    Public Link_BacktoPastoralListHref As Object
    Public Link_BacktoPastoralListHrefParameters As LinkParameterCollection
    Public link_Menu As TextField
    Public link_MenuHref As Object
    Public link_MenuHrefParameters As LinkParameterCollection
    Public Link_SearchRequest As TextField
    Public Link_SearchRequestHref As Object
    Public Link_SearchRequestHrefParameters As LinkParameterCollection
    Public link_Assignments As TextField
    Public link_AssignmentsHref As Object
    Public link_AssignmentsHrefParameters As LinkParameterCollection
    Public Link10 As TextField
    Public Link10Href As Object
    Public Link10HrefParameters As LinkParameterCollection
    Public Link6 As TextField
    Public Link6Href As Object
    Public Link6HrefParameters As LinkParameterCollection
    Public Link5 As TextField
    Public Link5Href As Object
    Public Link5HrefParameters As LinkParameterCollection
    Public Sub New()
        Link_Backtosummary = New TextField("",Nothing)
        Link_BacktosummaryHrefParameters = New LinkParameterCollection()
        Link_BacktoPastoralList = New TextField("",Nothing)
        Link_BacktoPastoralListHrefParameters = New LinkParameterCollection()
        link_Menu = New TextField("",Nothing)
        link_MenuHrefParameters = New LinkParameterCollection()
        Link_SearchRequest = New TextField("",Nothing)
        Link_SearchRequestHrefParameters = New LinkParameterCollection()
        link_Assignments = New TextField("",Nothing)
        link_AssignmentsHrefParameters = New LinkParameterCollection()
        Link10 = New TextField("",Nothing)
        Link10HrefParameters = New LinkParameterCollection()
        Link6 = New TextField("",Nothing)
        Link6HrefParameters = New LinkParameterCollection()
        Link5 = New TextField("",Nothing)
        Link5HrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Link_Backtosummary.SetValue(DBUtility.GetInitialValue("Link_Backtosummary"))
        item.Link_BacktoPastoralList.SetValue(DBUtility.GetInitialValue("Link_BacktoPastoralList"))
        item.link_Menu.SetValue(DBUtility.GetInitialValue("link_Menu"))
        item.Link_SearchRequest.SetValue(DBUtility.GetInitialValue("Link_SearchRequest"))
        item.link_Assignments.SetValue(DBUtility.GetInitialValue("link_Assignments"))
        item.Link10.SetValue(DBUtility.GetInitialValue("Link10"))
        item.Link6.SetValue(DBUtility.GetInitialValue("Link6"))
        item.Link5.SetValue(DBUtility.GetInitialValue("Link5"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Link_Backtosummary"
                    Return Link_Backtosummary
                Case "Link_BacktoPastoralList"
                    Return Link_BacktoPastoralList
                Case "link_Menu"
                    Return link_Menu
                Case "Link_SearchRequest"
                    Return Link_SearchRequest
                Case "link_Assignments"
                    Return link_Assignments
                Case "Link10"
                    Return Link10
                Case "Link6"
                    Return Link6
                Case "Link5"
                    Return Link5
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link_Backtosummary"
                    Link_Backtosummary = CType(value, TextField)
                Case "Link_BacktoPastoralList"
                    Link_BacktoPastoralList = CType(value, TextField)
                Case "link_Menu"
                    link_Menu = CType(value, TextField)
                Case "Link_SearchRequest"
                    Link_SearchRequest = CType(value, TextField)
                Case "link_Assignments"
                    link_Assignments = CType(value, TextField)
                Case "Link10"
                    Link10 = CType(value, TextField)
                Case "Link6"
                    Link6 = CType(value, TextField)
                Case "Link5"
                    Link5 = CType(value, TextField)
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

'Grid ASSIGNMENT_SUBMISSION_SUB Item Class @2-B1EFF9B1
Public Class ASSIGNMENT_SUBMISSION_SUBItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public lblStudent As TextField
    Public lblYear As TextField
    Public ASSIGNMENT_SUBMISSION_SUB_TotalRecords As TextField
    Public ASSIGNMENT_SUBMISSION_SUBJECT_ID As IntegerField
    Public ASSIGNMENT_ID As IntegerField
    Public SUBMISSION_ID As IntegerField
    Public SUBJECT_TITLE As TextField
    Public received_date As TextField
    Public returned_date As TextField
    Public STAFF_ID As TextField
    Public COMMENTS As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Link_ReturnAssignment As TextField
    Public Link_ReturnAssignmentHref As Object
    Public Link_ReturnAssignmentHrefParameters As LinkParameterCollection
    Public DESCRIPTION As TextField
    Public linkAddAssignment As TextField
    Public linkAddAssignmentHref As Object
    Public linkAddAssignmentHrefParameters As LinkParameterCollection
    Public Sub New()
    lblStudent = New TextField("", Nothing)
    lblYear = New TextField("", Nothing)
    ASSIGNMENT_SUBMISSION_SUB_TotalRecords = New TextField("", Nothing)
    ASSIGNMENT_SUBMISSION_SUBJECT_ID = New IntegerField("", Nothing)
    ASSIGNMENT_ID = New IntegerField("", Nothing)
    SUBMISSION_ID = New IntegerField("", Nothing)
    SUBJECT_TITLE = New TextField("", Nothing)
    received_date = New TextField("", Nothing)
    returned_date = New TextField("", Nothing)
    STAFF_ID = New TextField("", Nothing)
    COMMENTS = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    Link_ReturnAssignment = New TextField("",Nothing)
    Link_ReturnAssignmentHrefParameters = New LinkParameterCollection()
    DESCRIPTION = New TextField("", Nothing)
    linkAddAssignment = New TextField("",Nothing)
    linkAddAssignmentHrefParameters = New LinkParameterCollection()
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "lblStudent"
                    Return Me.lblStudent
                Case "lblYear"
                    Return Me.lblYear
                Case "ASSIGNMENT_SUBMISSION_SUB_TotalRecords"
                    Return Me.ASSIGNMENT_SUBMISSION_SUB_TotalRecords
                Case "ASSIGNMENT_SUBMISSION_SUBJECT_ID"
                    Return Me.ASSIGNMENT_SUBMISSION_SUBJECT_ID
                Case "ASSIGNMENT_ID"
                    Return Me.ASSIGNMENT_ID
                Case "SUBMISSION_ID"
                    Return Me.SUBMISSION_ID
                Case "SUBJECT_TITLE"
                    Return Me.SUBJECT_TITLE
                Case "received_date"
                    Return Me.received_date
                Case "returned_date"
                    Return Me.returned_date
                Case "STAFF_ID"
                    Return Me.STAFF_ID
                Case "COMMENTS"
                    Return Me.COMMENTS
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "Link_ReturnAssignment"
                    Return Me.Link_ReturnAssignment
                Case "DESCRIPTION"
                    Return Me.DESCRIPTION
                Case "linkAddAssignment"
                    Return Me.linkAddAssignment
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblStudent"
                    Me.lblStudent = CType(Value,TextField)
                Case "lblYear"
                    Me.lblYear = CType(Value,TextField)
                Case "ASSIGNMENT_SUBMISSION_SUB_TotalRecords"
                    Me.ASSIGNMENT_SUBMISSION_SUB_TotalRecords = CType(Value,TextField)
                Case "ASSIGNMENT_SUBMISSION_SUBJECT_ID"
                    Me.ASSIGNMENT_SUBMISSION_SUBJECT_ID = CType(Value,IntegerField)
                Case "ASSIGNMENT_ID"
                    Me.ASSIGNMENT_ID = CType(Value,IntegerField)
                Case "SUBMISSION_ID"
                    Me.SUBMISSION_ID = CType(Value,IntegerField)
                Case "SUBJECT_TITLE"
                    Me.SUBJECT_TITLE = CType(Value,TextField)
                Case "received_date"
                    Me.received_date = CType(Value,TextField)
                Case "returned_date"
                    Me.returned_date = CType(Value,TextField)
                Case "STAFF_ID"
                    Me.STAFF_ID = CType(Value,TextField)
                Case "COMMENTS"
                    Me.COMMENTS = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "Link_ReturnAssignment"
                    Me.Link_ReturnAssignment = CType(Value,TextField)
                Case "DESCRIPTION"
                    Me.DESCRIPTION = CType(Value,TextField)
                Case "linkAddAssignment"
                    Me.linkAddAssignment = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid ASSIGNMENT_SUBMISSION_SUB Item Class

'Grid ASSIGNMENT_SUBMISSION_SUB Data Provider Class Header @2-8767EB65
Public Class ASSIGNMENT_SUBMISSION_SUBDataProvider
Inherits GridDataProviderBase
'End Grid ASSIGNMENT_SUBMISSION_SUB Data Provider Class Header

'Grid ASSIGNMENT_SUBMISSION_SUB Data Provider Class Variables @2-0EDE0961

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_ASSIGNMENT_SUBMISSION_SUBJECT_ID
        Sorter_ASSIGNMENT_ID
        Sorter_SUBMISSION_ID
        Sorter_SUBJECT_TITLE
        Sorter_received_date
        Sorter_returned_date
        Sorter_STAFF_ID
        Sorter_COMMENTS
        Sorter_DESCRIPTION
    End Enum

    Private SortFieldsNames As String() = New String() {"ASSIGNMENT_SUBMISSION.SUBJECT_ID, ASSIGNMENT_SUBMISSION.ASSIGNMENT_ID, ASSIGNMENT_SUBMISSI" & _
"ON.SUBMISSION_ID","ASSIGNMENT_SUBMISSION.SUBJECT_ID","ASSIGNMENT_ID","SUBMISSION_ID","SUBJECT_TITLE","ASSIGNMENT_SUBMISSION.RECEIVED_DATE","ASSIGNMENT_SUBMISSION.returned_date","STAFF_ID","COMMENTS","DESCRIPTION"}
    Private SortFieldsNamesDesc As String() = New string() {"ASSIGNMENT_SUBMISSION.SUBJECT_ID, ASSIGNMENT_SUBMISSION.ASSIGNMENT_ID, ASSIGNMENT_SUBMISSI" & _
"ON.SUBMISSION_ID","ASSIGNMENT_SUBMISSION.SUBJECT_ID DESC","ASSIGNMENT_ID DESC","SUBMISSION_ID DESC","SUBJECT_TITLE DESC","ASSIGNMENT_SUBMISSION.RECEIVED_DATE DESC","ASSIGNMENT_SUBMISSION.returned_date DESC","STAFF_ID DESC","COMMENTS DESC","DESCRIPTION DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 80
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As FloatParameter
    Public UrlENROLMENT_YEAR  As FloatParameter
'End Grid ASSIGNMENT_SUBMISSION_SUB Data Provider Class Variables

'Grid ASSIGNMENT_SUBMISSION_SUB Data Provider Class GetResultSet Method @2-EE4E17AB

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} ASSIGNMENT_SUBMISSION.SUBJECT_ID AS ASSIGNMENT_SUBMISSION_" & _
          "SUBJECT_ID, " & vbCrLf & _
          "ASSIGNMENT_SUBMISSION.ASSIGNMENT_ID AS ASSIGNMENT_SUBMISSION_ASSIGNMENT_ID," & vbCrLf & _
          "SUBMISSION_ID, SUBJECT_TITLE, " & vbCrLf & _
          "isnull(convert(char(8),RECEIVED_DATE,3), ' ') AS received_date, isnull(convert(char(8),RET" & _
          "URNED_DATE,3), " & vbCrLf & _
          "' ') AS returned_date," & vbCrLf & _
          "STAFF_ID, COMMENTS, STUDENT_ID, ENROLMENT_YEAR, " & vbCrLf & _
          "ASSIGNMENT_SUBMISSION.LAST_ALTERED_BY AS ASSIGNMENT_SUBMISSION_LAST_ALTERED_BY," & vbCrLf & _
          "ASSIGNMENT_SUBMISSION.LAST_ALTERED_DATE AS ASSIGNMENT_SUBMISSION_LAST_ALTERED_DATE, DESCRI" & _
          "PTION " & vbCrLf & _
          "FROM (ASSIGNMENT_SUBMISSION INNER JOIN SUBJECT ON" & vbCrLf & _
          "ASSIGNMENT_SUBMISSION.SUBJECT_ID = SUBJECT.SUBJECT_ID) INNER JOIN ASSIGNMENT ON" & vbCrLf & _
          "ASSIGNMENT_SUBMISSION.ASSIGNMENT_ID = ASSIGNMENT.ASSIGNMENT_ID AND ASSIGNMENT_SUBMISSION.S" & _
          "UBJECT_ID = ASSIGNMENT.SUBJECT_ID {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID163","And","ENROLMENT_YEAR164"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM (ASSIGNMENT_SUBMISSION INNER JOIN SUBJECT ON" & vbCrLf & _
          "ASSIGNMENT_SUBMISSION.SUBJECT_ID = SUBJECT.SUBJECT_ID) INNER JOIN ASSIGNMENT ON" & vbCrLf & _
          "ASSIGNMENT_SUBMISSION.ASSIGNMENT_ID = ASSIGNMENT.ASSIGNMENT_ID AND ASSIGNMENT_SUBMISSION.S" & _
          "UBJECT_ID = ASSIGNMENT.SUBJECT_ID", New String(){"STUDENT_ID163","And","ENROLMENT_YEAR164"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid ASSIGNMENT_SUBMISSION_SUB Data Provider Class GetResultSet Method

'Grid ASSIGNMENT_SUBMISSION_SUB Data Provider Class GetResultSet Method @2-50B1D3FC
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As ASSIGNMENT_SUBMISSION_SUBItem()
'End Grid ASSIGNMENT_SUBMISSION_SUB Data Provider Class GetResultSet Method

'Before build Select @2-30678D9D
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID163",UrlSTUDENT_ID, "","ASSIGNMENT_SUBMISSION.STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("ENROLMENT_YEAR164",UrlENROLMENT_YEAR, "","ASSIGNMENT_SUBMISSION.ENROLMENT_YEAR",Condition.Equal,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-87DD614A
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As ASSIGNMENT_SUBMISSION_SUBItem
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

'After execute Select @2-D6DCAEAA
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New ASSIGNMENT_SUBMISSION_SUBItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-94E80B0E
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as ASSIGNMENT_SUBMISSION_SUBItem = New ASSIGNMENT_SUBMISSION_SUBItem()
                item.ASSIGNMENT_SUBMISSION_SUBJECT_ID.SetValue(dr(i)("ASSIGNMENT_SUBMISSION_SUBJECT_ID"),"")
                item.ASSIGNMENT_ID.SetValue(dr(i)("ASSIGNMENT_SUBMISSION_ASSIGNMENT_ID"),"")
                item.SUBMISSION_ID.SetValue(dr(i)("SUBMISSION_ID"),"")
                item.SUBJECT_TITLE.SetValue(dr(i)("SUBJECT_TITLE"),"")
                item.received_date.SetValue(dr(i)("received_date"),"")
                item.returned_date.SetValue(dr(i)("returned_date"),"")
                item.STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
                item.COMMENTS.SetValue(dr(i)("COMMENTS"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("ASSIGNMENT_SUBMISSION_LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("ASSIGNMENT_SUBMISSION_LAST_ALTERED_DATE"),Select_.DateFormat)
                item.Link_ReturnAssignmentHref = "AssignmentSubmissionListOld.aspx"
                item.Link_ReturnAssignmentHrefParameters.Add("SUBJECT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("ASSIGNMENT_SUBMISSION_SUBJECT_ID").ToString()))
                item.Link_ReturnAssignmentHrefParameters.Add("ASSIGNMENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("ASSIGNMENT_SUBMISSION_ASSIGNMENT_ID").ToString()))
                item.Link_ReturnAssignmentHrefParameters.Add("SUBMISSION_ID",System.Web.HttpUtility.UrlEncode(dr(i)("SUBMISSION_ID").ToString()))
                item.Link_ReturnAssignmentHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
                item.Link_ReturnAssignmentHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
                item.DESCRIPTION.SetValue(dr(i)("DESCRIPTION"),"")
                item.linkAddAssignmentHref = ""
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @2-A61BA892
End Class
'End Grid Data Provider tail

'Record ASSIGNMENT_SUBMISSION Item Class @66-94A68A38
Public Class ASSIGNMENT_SUBMISSIONItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public RECEIVED_DATE As DateField
    Public RETURNED_DATE As DateField
    Public STAFF_ID As TextField
    Public STAFF_IDItems As ItemCollection
    Public COMMENTS As TextField
    Public STUDENT_ID As FloatField
    Public ENROLMENT_YEAR As FloatField
    Public SUBJECT_ID As IntegerField
    Public ASSIGNMENT_ID As IntegerField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public lblAssignment As TextField
    Public lblSubmission As TextField
    Public lblDefaulted_Marker As TextField
    Public lblDefaulted_Returned As TextField
    Public lblRECEIVED_DATE As DateField
    Public Sub New()
    RECEIVED_DATE = New DateField(Settings.DateFormat, Nothing)
    RETURNED_DATE = New DateField("dd\/MM\/yyyy", Now())
    STAFF_ID = New TextField("", DBUtility.UserLogin.ToUpper())
    STAFF_IDItems = New ItemCollection()
    COMMENTS = New TextField("", Nothing)
    STUDENT_ID = New FloatField("", Nothing)
    ENROLMENT_YEAR = New FloatField("", Nothing)
    SUBJECT_ID = New IntegerField("", Nothing)
    ASSIGNMENT_ID = New IntegerField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    lblAssignment = New TextField("", Nothing)
    lblSubmission = New TextField("", Nothing)
    lblDefaulted_Marker = New TextField("", "<em>auto selected</em>")
    lblDefaulted_Returned = New TextField("", "<em>auto selected</em>")
    lblRECEIVED_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As ASSIGNMENT_SUBMISSIONItem
        Dim item As ASSIGNMENT_SUBMISSIONItem = New ASSIGNMENT_SUBMISSIONItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RECEIVED_DATE")) Then
        item.RECEIVED_DATE.SetValue(DBUtility.GetInitialValue("RECEIVED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RETURNED_DATE")) Then
        item.RETURNED_DATE.SetValue(DBUtility.GetInitialValue("RETURNED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DatePicker_RETURNED_DATE")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STAFF_ID")) Then
        item.STAFF_ID.SetValue(DBUtility.GetInitialValue("STAFF_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COMMENTS")) Then
        item.COMMENTS.SetValue(DBUtility.GetInitialValue("COMMENTS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_YEAR")) Then
        item.ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUBJECT_ID")) Then
        item.SUBJECT_ID.SetValue(DBUtility.GetInitialValue("SUBJECT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ASSIGNMENT_ID")) Then
        item.ASSIGNMENT_ID.SetValue(DBUtility.GetInitialValue("ASSIGNMENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblAssignment")) Then
        item.lblAssignment.SetValue(DBUtility.GetInitialValue("lblAssignment"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblSubmission")) Then
        item.lblSubmission.SetValue(DBUtility.GetInitialValue("lblSubmission"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblDefaulted_Marker")) Then
        item.lblDefaulted_Marker.SetValue(DBUtility.GetInitialValue("lblDefaulted_Marker"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblDefaulted_Returned")) Then
        item.lblDefaulted_Returned.SetValue(DBUtility.GetInitialValue("lblDefaulted_Returned"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblRECEIVED_DATE")) Then
        item.lblRECEIVED_DATE.SetValue(DBUtility.GetInitialValue("lblRECEIVED_DATE"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "RECEIVED_DATE"
                    Return RECEIVED_DATE
                Case "RETURNED_DATE"
                    Return RETURNED_DATE
                Case "STAFF_ID"
                    Return STAFF_ID
                Case "COMMENTS"
                    Return COMMENTS
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "ENROLMENT_YEAR"
                    Return ENROLMENT_YEAR
                Case "SUBJECT_ID"
                    Return SUBJECT_ID
                Case "ASSIGNMENT_ID"
                    Return ASSIGNMENT_ID
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "lblAssignment"
                    Return lblAssignment
                Case "lblSubmission"
                    Return lblSubmission
                Case "lblDefaulted_Marker"
                    Return lblDefaulted_Marker
                Case "lblDefaulted_Returned"
                    Return lblDefaulted_Returned
                Case "lblRECEIVED_DATE"
                    Return lblRECEIVED_DATE
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "RECEIVED_DATE"
                    RECEIVED_DATE = CType(value, DateField)
                Case "RETURNED_DATE"
                    RETURNED_DATE = CType(value, DateField)
                Case "STAFF_ID"
                    STAFF_ID = CType(value, TextField)
                Case "COMMENTS"
                    COMMENTS = CType(value, TextField)
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, FloatField)
                Case "ENROLMENT_YEAR"
                    ENROLMENT_YEAR = CType(value, FloatField)
                Case "SUBJECT_ID"
                    SUBJECT_ID = CType(value, IntegerField)
                Case "ASSIGNMENT_ID"
                    ASSIGNMENT_ID = CType(value, IntegerField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "lblAssignment"
                    lblAssignment = CType(value, TextField)
                Case "lblSubmission"
                    lblSubmission = CType(value, TextField)
                Case "lblDefaulted_Marker"
                    lblDefaulted_Marker = CType(value, TextField)
                Case "lblDefaulted_Returned"
                    lblDefaulted_Returned = CType(value, TextField)
                Case "lblRECEIVED_DATE"
                    lblRECEIVED_DATE = CType(value, DateField)
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

    Public Sub Validate(ByVal provider As ASSIGNMENT_SUBMISSIONDataProvider)
'End Record ASSIGNMENT_SUBMISSION Item Class

'RECEIVED_DATE validate @69-69E452D7
        If IsNothing(RECEIVED_DATE.Value) OrElse RECEIVED_DATE.Value.ToString() ="" Then
            errors.Add("RECEIVED_DATE",String.Format(Resources.strings.CCS_RequiredField,"RECEIVED DATE"))
        End If
'End RECEIVED_DATE validate

'RETURNED_DATE validate @70-9625EE37
        If IsNothing(RETURNED_DATE.Value) OrElse RETURNED_DATE.Value.ToString() ="" Then
            errors.Add("RETURNED_DATE",String.Format(Resources.strings.CCS_RequiredField,"RETURNED DATE"))
        End If
'End RETURNED_DATE validate

'TextBox RETURNED_DATE Event OnValidate. Action Custom Code @104-73254650
    ' -------------------------
    'ERA: 4-Apr-2011|EA| alter date validation so return date is between RECEIVED and Today as normal Input validation not liking compound validation
	dim date_stupidjanison as Date = "2011-12-30"
	 If (Not IsNothing(RETURNED_DATE.Value)) And ((DateTime.Compare(RETURNED_DATE.Value, RECEIVED_DATE.Value) < 0) OR RETURNED_DATE.Value > Date.Today()) AND (RECEIVED_DATE.Value <> date_stupidjanison) Then
		errors.Add("RETURNED_DATE","RETURNED DATE must be between RECEIVED DATE and Today.")
	End If
    ' -------------------------
'End TextBox RETURNED_DATE Event OnValidate. Action Custom Code

'STAFF_ID validate @72-E7FEBD6C
        If IsNothing(STAFF_ID.Value) OrElse STAFF_ID.Value.ToString() ="" Then
            errors.Add("STAFF_ID",String.Format(Resources.strings.CCS_RequiredField,"MARKER ID"))
        End If
'End STAFF_ID validate

'STUDENT_ID validate @77-6D9CF271
        If IsNothing(STUDENT_ID.Value) OrElse STUDENT_ID.Value.ToString() ="" Then
            errors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_RequiredField,"STUDENT ID"))
        End If
'End STUDENT_ID validate

'ENROLMENT_YEAR validate @78-2458998A
        If IsNothing(ENROLMENT_YEAR.Value) OrElse ENROLMENT_YEAR.Value.ToString() ="" Then
            errors.Add("ENROLMENT_YEAR",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT YEAR"))
        End If
'End ENROLMENT_YEAR validate

'SUBJECT_ID validate @79-22E3C20E
        If IsNothing(SUBJECT_ID.Value) OrElse SUBJECT_ID.Value.ToString() ="" Then
            errors.Add("SUBJECT_ID",String.Format(Resources.strings.CCS_RequiredField,"SUBJECT ID"))
        End If
'End SUBJECT_ID validate

'ASSIGNMENT_ID validate @80-4FFBE52B
        If IsNothing(ASSIGNMENT_ID.Value) OrElse ASSIGNMENT_ID.Value.ToString() ="" Then
            errors.Add("ASSIGNMENT_ID",String.Format(Resources.strings.CCS_RequiredField,"ASSIGNMENT ID"))
        End If
'End ASSIGNMENT_ID validate

'LAST_ALTERED_BY validate @81-256A6854
        If IsNothing(LAST_ALTERED_BY.Value) OrElse LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End LAST_ALTERED_BY validate

'LAST_ALTERED_DATE validate @82-C5989D76
        If IsNothing(LAST_ALTERED_DATE.Value) OrElse LAST_ALTERED_DATE.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED DATE"))
        End If
'End LAST_ALTERED_DATE validate

'Record ASSIGNMENT_SUBMISSION Item Class tail @66-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record ASSIGNMENT_SUBMISSION Item Class tail

'Record ASSIGNMENT_SUBMISSION Data Provider Class @66-04927591
Public Class ASSIGNMENT_SUBMISSIONDataProvider
Inherits RecordDataProviderBase
'End Record ASSIGNMENT_SUBMISSION Data Provider Class

'Record ASSIGNMENT_SUBMISSION Data Provider Class Variables @66-1CD739D6
    Protected STAFF_IDDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM View_StaffList_Active_Inactive {SQL_Where} {SQL_OrderBy}", New String(){"expr73","And","expr74"},Settings.connDECVPRODSQL2005DataAccessObject )
    Public UrlASSIGNMENT_ID As IntegerParameter
    Public UrlSTUDENT_ID As FloatParameter
    Public UrlENROLMENT_YEAR As FloatParameter
    Public UrlSUBJECT_ID As IntegerParameter
    Public UrlSUBMISSION_ID As IntegerParameter
    Protected item As ASSIGNMENT_SUBMISSIONItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record ASSIGNMENT_SUBMISSION Data Provider Class Variables

'Record ASSIGNMENT_SUBMISSION Data Provider Class Constructor @66-8226B0E4

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM ASSIGNMENT_SUBMISSION {SQL_Where} {SQL_OrderBy}", New String(){"ASSIGNMENT_ID85","And","STUDENT_ID86","And","ENROLMENT_YEAR87","And","SUBJECT_ID88","And","SUBMISSION_ID89"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record ASSIGNMENT_SUBMISSION Data Provider Class Constructor

'Record ASSIGNMENT_SUBMISSION Data Provider Class LoadParams Method @66-F485FC9D

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlASSIGNMENT_ID) Or IsNothing(UrlSTUDENT_ID) Or IsNothing(UrlENROLMENT_YEAR) Or IsNothing(UrlSUBJECT_ID) Or IsNothing(UrlSUBMISSION_ID))
    End Function
'End Record ASSIGNMENT_SUBMISSION Data Provider Class LoadParams Method

'Record ASSIGNMENT_SUBMISSION Data Provider Class CheckUnique Method @66-179154E6

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As ASSIGNMENT_SUBMISSIONItem) As Boolean
        Return True
    End Function
'End Record ASSIGNMENT_SUBMISSION Data Provider Class CheckUnique Method

'Record ASSIGNMENT_SUBMISSION Data Provider Class PrepareUpdate Method @66-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record ASSIGNMENT_SUBMISSION Data Provider Class PrepareUpdate Method

'Record ASSIGNMENT_SUBMISSION Data Provider Class PrepareUpdate Method tail @66-E31F8E2A
    End Sub
'End Record ASSIGNMENT_SUBMISSION Data Provider Class PrepareUpdate Method tail

'Record ASSIGNMENT_SUBMISSION Data Provider Class Update Method @66-D3D1AD51

    Public Function UpdateItem(ByVal item As ASSIGNMENT_SUBMISSIONItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE ASSIGNMENT_SUBMISSION SET {Values}", New String(){"ASSIGNMENT_ID85","And","STUDENT_ID86","And","ENROLMENT_YEAR87","And","SUBJECT_ID88","And","SUBMISSION_ID89"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record ASSIGNMENT_SUBMISSION Data Provider Class Update Method

'Record ASSIGNMENT_SUBMISSION BeforeBuildUpdate @66-9406AAE2
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("ASSIGNMENT_ID85",UrlASSIGNMENT_ID, "","ASSIGNMENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("STUDENT_ID86",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ENROLMENT_YEAR87",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("SUBJECT_ID88",UrlSUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("SUBMISSION_ID89",UrlSUBMISSION_ID, "","SUBMISSION_ID",Condition.Equal,False)
        If Not item.RECEIVED_DATE.IsEmpty Then
        allEmptyFlag = item.RECEIVED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "RECEIVED_DATE=" + Update.Dao.ToSql(item.RECEIVED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.RETURNED_DATE.IsEmpty Then
        allEmptyFlag = item.RETURNED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "RETURNED_DATE=" + Update.Dao.ToSql(item.RETURNED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.STAFF_ID.IsEmpty Then
        allEmptyFlag = item.STAFF_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STAFF_ID=" + Update.Dao.ToSql(item.STAFF_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.COMMENTS.IsEmpty Then
        allEmptyFlag = item.COMMENTS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "COMMENTS=" + Update.Dao.ToSql(item.COMMENTS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STUDENT_ID.IsEmpty Then
        allEmptyFlag = item.STUDENT_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STUDENT_ID=" + Update.Dao.ToSql(item.STUDENT_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.ENROLMENT_YEAR.IsEmpty Then
        allEmptyFlag = item.ENROLMENT_YEAR.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ENROLMENT_YEAR=" + Update.Dao.ToSql(item.ENROLMENT_YEAR.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.SUBJECT_ID.IsEmpty Then
        allEmptyFlag = item.SUBJECT_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUBJECT_ID=" + Update.Dao.ToSql(item.SUBJECT_ID.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.ASSIGNMENT_ID.IsEmpty Then
        allEmptyFlag = item.ASSIGNMENT_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ASSIGNMENT_ID=" + Update.Dao.ToSql(item.ASSIGNMENT_ID.GetFormattedValue(""),FieldType._Integer) & ","
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
'End Record ASSIGNMENT_SUBMISSION BeforeBuildUpdate

'Record ASSIGNMENT_SUBMISSION AfterExecuteUpdate @66-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record ASSIGNMENT_SUBMISSION AfterExecuteUpdate

'Record ASSIGNMENT_SUBMISSION Data Provider Class GetResultSet Method @66-47D66440

    Public Sub FillItem(ByVal item As ASSIGNMENT_SUBMISSIONItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record ASSIGNMENT_SUBMISSION Data Provider Class GetResultSet Method

'Record ASSIGNMENT_SUBMISSION BeforeBuildSelect @66-4816FC89
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("ASSIGNMENT_ID85",UrlASSIGNMENT_ID, "","ASSIGNMENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("STUDENT_ID86",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("ENROLMENT_YEAR87",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("SUBJECT_ID88",UrlSUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("SUBMISSION_ID89",UrlSUBMISSION_ID, "","SUBMISSION_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record ASSIGNMENT_SUBMISSION BeforeBuildSelect

'Record ASSIGNMENT_SUBMISSION BeforeExecuteSelect @66-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record ASSIGNMENT_SUBMISSION BeforeExecuteSelect

'Record ASSIGNMENT_SUBMISSION AfterExecuteSelect @66-3C066022
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.RECEIVED_DATE.SetValue(dr(i)("RECEIVED_DATE"),Select_.DateFormat)
            item.RETURNED_DATE.SetValue(dr(i)("RETURNED_DATE"),Select_.DateFormat)
            item.STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
            item.COMMENTS.SetValue(dr(i)("COMMENTS"),"")
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.ENROLMENT_YEAR.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
            item.ASSIGNMENT_ID.SetValue(dr(i)("ASSIGNMENT_ID"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.lblAssignment.SetValue(dr(i)("ASSIGNMENT_ID"),"")
            item.lblSubmission.SetValue(dr(i)("SUBMISSION_ID"),"")
            item.lblRECEIVED_DATE.SetValue(dr(i)("RECEIVED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record ASSIGNMENT_SUBMISSION AfterExecuteSelect

'ListBox STAFF_ID Initialize Data Source @72-CDF29D33
        STAFF_IDDataCommand.Dao._optimized = False
        Dim STAFF_IDtableIndex As Integer = 0
        STAFF_IDDataCommand.OrderBy = ""
        STAFF_IDDataCommand.Parameters.Clear()
        STAFF_IDDataCommand.Parameters.Add("expr73","(status = 1)")
        STAFF_IDDataCommand.Parameters.Add("expr74","(teacher_flag = 1)")
'End ListBox STAFF_ID Initialize Data Source

'ListBox STAFF_ID BeforeExecuteSelect @72-0F683DF6
        Try
            ListBoxSource=STAFF_IDDataCommand.Execute().Tables(STAFF_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox STAFF_ID BeforeExecuteSelect

'ListBox STAFF_ID AfterExecuteSelect @72-0FE625FB
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("staff_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("staffname")
            item.STAFF_IDItems.Add(Key, Val)
        Next
'End ListBox STAFF_ID AfterExecuteSelect

'Record ASSIGNMENT_SUBMISSION AfterExecuteSelect tail @66-E31F8E2A
    End Sub
'End Record ASSIGNMENT_SUBMISSION AfterExecuteSelect tail

'Record ASSIGNMENT_SUBMISSION Data Provider Class @66-A61BA892
End Class

'End Record ASSIGNMENT_SUBMISSION Data Provider Class

'Record RECEIVE_ASSIGNMENT Item Class @192-18ED7769
Public Class RECEIVE_ASSIGNMENTItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public STUDENT_ID As FloatField
    Public ENROLMENT_YEAR As FloatField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public listSUBJECTS As TextField
    Public listSUBJECTSItems As ItemCollection
    Public listASSIGNMENTS As TextField
    Public listASSIGNMENTSItems As ItemCollection
    Public ajaxBusy As TextField
    Public Sub New()
    STUDENT_ID = New FloatField("", Nothing)
    ENROLMENT_YEAR = New FloatField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    listSUBJECTS = New TextField("", Nothing)
    listSUBJECTSItems = New ItemCollection()
    listASSIGNMENTS = New TextField("", Nothing)
    listASSIGNMENTSItems = New ItemCollection()
    ajaxBusy = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As RECEIVE_ASSIGNMENTItem
        Dim item As RECEIVE_ASSIGNMENTItem = New RECEIVE_ASSIGNMENTItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_YEAR")) Then
        item.ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("listSUBJECTS")) Then
        item.listSUBJECTS.SetValue(DBUtility.GetInitialValue("listSUBJECTS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("listASSIGNMENTS")) Then
        item.listASSIGNMENTS.SetValue(DBUtility.GetInitialValue("listASSIGNMENTS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ajaxBusy")) Then
        item.ajaxBusy.SetValue(DBUtility.GetInitialValue("ajaxBusy"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "ENROLMENT_YEAR"
                    Return ENROLMENT_YEAR
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "listSUBJECTS"
                    Return listSUBJECTS
                Case "listASSIGNMENTS"
                    Return listASSIGNMENTS
                Case "ajaxBusy"
                    Return ajaxBusy
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, FloatField)
                Case "ENROLMENT_YEAR"
                    ENROLMENT_YEAR = CType(value, FloatField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "listSUBJECTS"
                    listSUBJECTS = CType(value, TextField)
                Case "listASSIGNMENTS"
                    listASSIGNMENTS = CType(value, TextField)
                Case "ajaxBusy"
                    ajaxBusy = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As RECEIVE_ASSIGNMENTDataProvider)
'End Record RECEIVE_ASSIGNMENT Item Class

'DEL      ' -------------------------
'DEL      'ERA: 4-Apr-2011|EA| alter date validation so return date is between RECEIVED and Today as normal Input validation not liking compound validation
'DEL  	dim date_stupidjanison as Date = "2011-12-30"
'DEL  	 If (Not IsNothing(RECEIVED_DATE.Value)) And (RECEIVED_DATE.Value > Date.Today()) Then
'DEL  		errors.Add("RECEIVED_DATE","RECEIVED DATE must be on or before Today.")
'DEL  	End If
'DEL      ' -------------------------


'STUDENT_ID validate @206-6D9CF271
        If IsNothing(STUDENT_ID.Value) OrElse STUDENT_ID.Value.ToString() ="" Then
            errors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_RequiredField,"STUDENT ID"))
        End If
'End STUDENT_ID validate

'ENROLMENT_YEAR validate @207-2458998A
        If IsNothing(ENROLMENT_YEAR.Value) OrElse ENROLMENT_YEAR.Value.ToString() ="" Then
            errors.Add("ENROLMENT_YEAR",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT YEAR"))
        End If
'End ENROLMENT_YEAR validate

'LAST_ALTERED_BY validate @210-256A6854
        If IsNothing(LAST_ALTERED_BY.Value) OrElse LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End LAST_ALTERED_BY validate

'LAST_ALTERED_DATE validate @211-C5989D76
        If IsNothing(LAST_ALTERED_DATE.Value) OrElse LAST_ALTERED_DATE.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED DATE"))
        End If
'End LAST_ALTERED_DATE validate

'listSUBJECTS validate @228-9E311ED3
        If IsNothing(listSUBJECTS.Value) OrElse listSUBJECTS.Value.ToString() ="" Then
            errors.Add("listSUBJECTS",String.Format(Resources.strings.CCS_RequiredField,"Student Subject"))
        End If
'End listSUBJECTS validate

'listASSIGNMENTS validate @234-556A95A4
        If IsNothing(listASSIGNMENTS.Value) OrElse listASSIGNMENTS.Value.ToString() ="" Then
            errors.Add("listASSIGNMENTS",String.Format(Resources.strings.CCS_RequiredField,"Assignment"))
        End If
'End listASSIGNMENTS validate

'Record RECEIVE_ASSIGNMENT Item Class tail @192-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record RECEIVE_ASSIGNMENT Item Class tail

'Record RECEIVE_ASSIGNMENT Data Provider Class @192-93BDF367
Public Class RECEIVE_ASSIGNMENTDataProvider
Inherits RecordDataProviderBase
'End Record RECEIVE_ASSIGNMENT Data Provider Class

'Record RECEIVE_ASSIGNMENT Data Provider Class Variables @192-66765A29
    Protected listSUBJECTSDataCommand As DataCommand=new SqlCommand("select * " & vbCrLf & _
          "from view_ReportParams_Subjects sub" & vbCrLf & _
          "where subject_id in (select subject_id from student_subject where student_id = {STUDENT_ID" & _
          "} and  enrolment_year = year(getdate()) and SUBJ_ENROL_STATUS not in ('W') ){SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
    Protected listASSIGNMENTSDataCommand As DataCommand=new TableCommand("SELECT SUBJECT_ID, ASSIGNMENT_ID, convert(varchar(4), " & vbCrLf & _
          "assignment_id) + ' ' + rtrim(isnull(DESCRIPTION,'')) AS displaytext " & vbCrLf & _
          "FROM ASSIGNMENT {SQL_Where} {SQL_OrderBy}", New String(){"expr303"},Settings.connDECVPRODSQL2005DataAccessObject )
    Public UrlASSIGNMENT_ID As IntegerParameter
    Public UrlENROLMENT_YEAR As FloatParameter
    Public UrlSUBJECT_ID As IntegerParameter
    Public UrlSUBMISSION_ID As IntegerParameter
    Public UrlRETURN_VALUE As IntegerParameter
    Public CtrlSTUDENT_ID As FloatParameter
    Public CtrlENROLMENT_YEAR As FloatParameter
    Public CtrllistSUBJECTS As IntegerParameter
    Public CtrllistASSIGNMENTS As IntegerParameter
    Public CtrlLAST_ALTERED_BY As TextParameter
    Public UrlSTUDENT_ID As TextParameter
    Protected item As RECEIVE_ASSIGNMENTItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record RECEIVE_ASSIGNMENT Data Provider Class Variables

'Record RECEIVE_ASSIGNMENT Data Provider Class Constructor @192-C3A2ADA8

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM ASSIGNMENT_SUBMISSION {SQL_Where} {SQL_OrderBy}", New String(){"ASSIGNMENT_ID220","And","STUDENT_ID221","And","ENROLMENT_YEAR222","And","SUBJECT_ID223","And","SUBMISSION_ID224"},Settings.connDECVPRODSQL2005DataAccessObject )
        Insert=new SpCommand("sp_upd_assignment_receipt;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record RECEIVE_ASSIGNMENT Data Provider Class Constructor

'Record RECEIVE_ASSIGNMENT Data Provider Class LoadParams Method @192-F485FC9D

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlASSIGNMENT_ID) Or IsNothing(UrlSTUDENT_ID) Or IsNothing(UrlENROLMENT_YEAR) Or IsNothing(UrlSUBJECT_ID) Or IsNothing(UrlSUBMISSION_ID))
    End Function
'End Record RECEIVE_ASSIGNMENT Data Provider Class LoadParams Method

'Record RECEIVE_ASSIGNMENT Data Provider Class CheckUnique Method @192-6F25C274

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As RECEIVE_ASSIGNMENTItem) As Boolean
        Return True
    End Function
'End Record RECEIVE_ASSIGNMENT Data Provider Class CheckUnique Method

'Record RECEIVE_ASSIGNMENT Data Provider Class PrepareInsert Method @192-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record RECEIVE_ASSIGNMENT Data Provider Class PrepareInsert Method

'Record RECEIVE_ASSIGNMENT Data Provider Class PrepareInsert Method tail @192-E31F8E2A
    End Sub
'End Record RECEIVE_ASSIGNMENT Data Provider Class PrepareInsert Method tail

'Record RECEIVE_ASSIGNMENT Data Provider Class Insert Method @192-8AFFBDE6

    Public Function InsertItem(ByVal item As RECEIVE_ASSIGNMENTItem) As Integer
        Me.item = item
'End Record RECEIVE_ASSIGNMENT Data Provider Class Insert Method

'Record RECEIVE_ASSIGNMENT Build insert @192-305EC880
        Insert.Parameters.Clear()
        CType(Insert,SpCommand).AddParameter("@RETURN_VALUE",UrlRETURN_VALUE,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Insert,SpCommand).AddParameter("@pnStudentID",item.STUDENT_ID,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Insert,SpCommand).AddParameter("@pnEnrolmentYear",item.ENROLMENT_YEAR,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Insert,SpCommand).AddParameter("@psiSubjectID",item.listSUBJECTS,ParameterType._SmallInt,ParameterDirection.Input,0,0,5)
        CType(Insert,SpCommand).AddParameter("@psiAssignmentID",item.listASSIGNMENTS,ParameterType._SmallInt,ParameterDirection.Input,0,0,5)
        CType(Insert,SpCommand).AddParameter("@last_altered_by",item.LAST_ALTERED_BY,ParameterType._Char,ParameterDirection.Input,8,0,0)
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
            result = ExecuteInsert()
            UrlRETURN_VALUE = IntegerParameter.GetParam(CType(Insert.Parameters("@RETURN_VALUE"),IDataParameter).Value)
        Catch ee As Exception
            E = ee
        Finally
'End Record RECEIVE_ASSIGNMENT Build insert

'Record RECEIVE_ASSIGNMENT AfterExecuteInsert @192-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record RECEIVE_ASSIGNMENT AfterExecuteInsert

'Record RECEIVE_ASSIGNMENT Data Provider Class GetResultSet Method @192-642EAAA6

    Public Sub FillItem(ByVal item As RECEIVE_ASSIGNMENTItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record RECEIVE_ASSIGNMENT Data Provider Class GetResultSet Method

'Record RECEIVE_ASSIGNMENT BeforeBuildSelect @192-907E2744
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("ASSIGNMENT_ID220",UrlASSIGNMENT_ID, "","ASSIGNMENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("STUDENT_ID221",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("ENROLMENT_YEAR222",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("SUBJECT_ID223",UrlSUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("SUBMISSION_ID224",UrlSUBMISSION_ID, "","SUBMISSION_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record RECEIVE_ASSIGNMENT BeforeBuildSelect

'Record RECEIVE_ASSIGNMENT BeforeExecuteSelect @192-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record RECEIVE_ASSIGNMENT BeforeExecuteSelect

'Record RECEIVE_ASSIGNMENT AfterExecuteSelect @192-1DB2C2F9
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.ENROLMENT_YEAR.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.listSUBJECTS.SetValue(dr(i)("SUBJECT_ID"),"")
            item.listASSIGNMENTS.SetValue(dr(i)("ASSIGNMENT_ID"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record RECEIVE_ASSIGNMENT AfterExecuteSelect

'ListBox listSUBJECTS Initialize Data Source @228-32C824C3
        listSUBJECTSDataCommand.Dao._optimized = False
        Dim listSUBJECTStableIndex As Integer = 0
        listSUBJECTSDataCommand.OrderBy = "SUBJECT_TITLE"
        listSUBJECTSDataCommand.Parameters.Clear()
        CType(listSUBJECTSDataCommand,SqlCommand).AddParameter("STUDENT_ID",UrlSTUDENT_ID, "")
'End ListBox listSUBJECTS Initialize Data Source

'ListBox listSUBJECTS BeforeExecuteSelect @228-5F392C50
        Try
            ListBoxSource=listSUBJECTSDataCommand.Execute().Tables(listSUBJECTStableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox listSUBJECTS BeforeExecuteSelect

'ListBox listSUBJECTS AfterExecuteSelect @228-777737EE
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("SUBJECT_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("subject_displaylabel")
            item.listSUBJECTSItems.Add(Key, Val)
        Next
'End ListBox listSUBJECTS AfterExecuteSelect

'ListBox listASSIGNMENTS Initialize Data Source @234-AD7DEBDB
        listASSIGNMENTSDataCommand.Dao._optimized = False
        Dim listASSIGNMENTStableIndex As Integer = 0
        listASSIGNMENTSDataCommand.OrderBy = "SUBJECT_ID, ASSIGNMENT_ID"
        listASSIGNMENTSDataCommand.Parameters.Clear()
        listASSIGNMENTSDataCommand.Parameters.Add("expr303","(STATUS = 1)")
'End ListBox listASSIGNMENTS Initialize Data Source

'ListBox listASSIGNMENTS BeforeExecuteSelect @234-70F65611
        Try
            ListBoxSource=listASSIGNMENTSDataCommand.Execute().Tables(listASSIGNMENTStableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox listASSIGNMENTS BeforeExecuteSelect

'ListBox listASSIGNMENTS AfterExecuteSelect @234-9629F3CD
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("ASSIGNMENT_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("displaytext")
            item.listASSIGNMENTSItems.Add(Key, Val)
        Next
'End ListBox listASSIGNMENTS AfterExecuteSelect

'Record RECEIVE_ASSIGNMENT AfterExecuteSelect tail @192-E31F8E2A
    End Sub
'End Record RECEIVE_ASSIGNMENT AfterExecuteSelect tail

'Record RECEIVE_ASSIGNMENT Data Provider Class @192-A61BA892
End Class

'End Record RECEIVE_ASSIGNMENT Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

