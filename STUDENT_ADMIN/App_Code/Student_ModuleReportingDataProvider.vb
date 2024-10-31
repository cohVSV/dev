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

Namespace DECV_PROD2007.Student_ModuleReporting 'Namespace @1-21B735DB

'Page Data Class @1-BC8BFFD1
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

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
    Public Link_Backtosummary As TextField
    Public Link_BacktosummaryHref As Object
    Public Link_BacktosummaryHrefParameters As LinkParameterCollection
    Public Link_BacktoPastoralList As TextField
    Public Link_BacktoPastoralListHref As Object
    Public Link_BacktoPastoralListHrefParameters As LinkParameterCollection
    Public linkExternalReport As TextField
    Public linkExternalReportHref As Object
    Public linkExternalReportHrefParameters As LinkParameterCollection
    Public Sub New()
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
        Link_Backtosummary = New TextField("",Nothing)
        Link_BacktosummaryHrefParameters = New LinkParameterCollection()
        Link_BacktoPastoralList = New TextField("",Nothing)
        Link_BacktoPastoralListHrefParameters = New LinkParameterCollection()
        linkExternalReport = New TextField("",Nothing)
        linkExternalReportHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.link_Menu.SetValue(DBUtility.GetInitialValue("link_Menu"))
        item.Link_SearchRequest.SetValue(DBUtility.GetInitialValue("Link_SearchRequest"))
        item.link_Assignments.SetValue(DBUtility.GetInitialValue("link_Assignments"))
        item.Link10.SetValue(DBUtility.GetInitialValue("Link10"))
        item.Link6.SetValue(DBUtility.GetInitialValue("Link6"))
        item.Link5.SetValue(DBUtility.GetInitialValue("Link5"))
        item.Link_Backtosummary.SetValue(DBUtility.GetInitialValue("Link_Backtosummary"))
        item.Link_BacktoPastoralList.SetValue(DBUtility.GetInitialValue("Link_BacktoPastoralList"))
        item.linkExternalReport.SetValue(DBUtility.GetInitialValue("linkExternalReport"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
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
                Case "Link_Backtosummary"
                    Return Link_Backtosummary
                Case "Link_BacktoPastoralList"
                    Return Link_BacktoPastoralList
                Case "linkExternalReport"
                    Return linkExternalReport
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
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
                Case "Link_Backtosummary"
                    Link_Backtosummary = CType(value, TextField)
                Case "Link_BacktoPastoralList"
                    Link_BacktoPastoralList = CType(value, TextField)
                Case "linkExternalReport"
                    linkExternalReport = CType(value, TextField)
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

'Report SCAFFOLD_MODULE_GRADE_SCA Item Class @23-E16E3333
Public Class SCAFFOLD_MODULE_GRADE_SCAItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public SCAFFOLD_USER_student_id As TextField
    Public SCAFFOLD_USER_student_firstname As TextField
    Public SCAFFOLD_USER_student_lastname As TextField
    Public shortname As TextField
    Public fullname As TextField
    Public name As TextField
    Public nameHref As Object
    Public nameHrefParameters As LinkParameterCollection
    Public dategraded As DateField
    Public str_long_grade As TextField
    Public str_feedback As TextField
    Public firstname As TextField
    Public lastname As TextField
    Public lblgradestyle As TextField
    Public essentialquestion As TextField
    Public linkExternalReport As TextField
    Public linkExternalReportHref As Object
    Public linkExternalReportHrefParameters As LinkParameterCollection
    Public Sub New()
    SCAFFOLD_USER_student_id = New TextField("", Nothing)
    SCAFFOLD_USER_student_firstname = New TextField("", Nothing)
    SCAFFOLD_USER_student_lastname = New TextField("", Nothing)
    shortname = New TextField("", Nothing)
    fullname = New TextField("", Nothing)
    name = New TextField("",Nothing)
    nameHrefParameters = New LinkParameterCollection()
    dategraded = New DateField("d\/MM\/yyyy h\:mm tt", Nothing)
    str_long_grade = New TextField("", Nothing)
    str_feedback = New TextField("", Nothing)
    firstname = New TextField("", Nothing)
    lastname = New TextField("", Nothing)
    lblgradestyle = New TextField("", Nothing)
    essentialquestion = New TextField("", Nothing)
    linkExternalReport = New TextField("",Nothing)
    linkExternalReportHrefParameters = New LinkParameterCollection()
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "SCAFFOLD_USER_student_id"
                    Return Me.SCAFFOLD_USER_student_id
                Case "SCAFFOLD_USER_student_firstname"
                    Return Me.SCAFFOLD_USER_student_firstname
                Case "SCAFFOLD_USER_student_lastname"
                    Return Me.SCAFFOLD_USER_student_lastname
                Case "shortname"
                    Return Me.shortname
                Case "fullname"
                    Return Me.fullname
                Case "name"
                    Return Me.name
                Case "dategraded"
                    Return Me.dategraded
                Case "str_long_grade"
                    Return Me.str_long_grade
                Case "str_feedback"
                    Return Me.str_feedback
                Case "firstname"
                    Return Me.firstname
                Case "lastname"
                    Return Me.lastname
                Case "lblgradestyle"
                    Return Me.lblgradestyle
                Case "essentialquestion"
                    Return Me.essentialquestion
                Case "linkExternalReport"
                    Return Me.linkExternalReport
                Case "SCAFFOLD_USER_student_idGroupField"
                    Return Me.SCAFFOLD_USER_student_idGroupField
                Case "shortnameGroupField"
                    Return Me.shortnameGroupField
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SCAFFOLD_USER_student_id"
                    Me.SCAFFOLD_USER_student_id = CType(Value,TextField)
                Case "SCAFFOLD_USER_student_firstname"
                    Me.SCAFFOLD_USER_student_firstname = CType(Value,TextField)
                Case "SCAFFOLD_USER_student_lastname"
                    Me.SCAFFOLD_USER_student_lastname = CType(Value,TextField)
                Case "shortname"
                    Me.shortname = CType(Value,TextField)
                Case "fullname"
                    Me.fullname = CType(Value,TextField)
                Case "name"
                    Me.name = CType(Value,TextField)
                Case "dategraded"
                    Me.dategraded = CType(Value,DateField)
                Case "str_long_grade"
                    Me.str_long_grade = CType(Value,TextField)
                Case "str_feedback"
                    Me.str_feedback = CType(Value,TextField)
                Case "firstname"
                    Me.firstname = CType(Value,TextField)
                Case "lastname"
                    Me.lastname = CType(Value,TextField)
                Case "lblgradestyle"
                    Me.lblgradestyle = CType(Value,TextField)
                Case "essentialquestion"
                    Me.essentialquestion = CType(Value,TextField)
                Case "linkExternalReport"
                    Me.linkExternalReport = CType(Value,TextField)
                Case "SCAFFOLD_USER_student_idGroupField"
                    Me.SCAFFOLD_USER_student_idGroupField = CType(Value,TextField)
                Case "shortnameGroupField"
                    Me.shortnameGroupField = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public SCAFFOLD_USER_student_idGroupField As New TextField("", Nothing)
    Public shortnameGroupField As New TextField("", Nothing)
    Public RawData As DataRow = Nothing
End Class
'End Report SCAFFOLD_MODULE_GRADE_SCA Item Class

'Report SCAFFOLD_MODULE_GRADE_SCA Data Provider Class Header @23-201DD928
Public Class SCAFFOLD_MODULE_GRADE_SCADataProvider
Inherits GridDataProviderBase
'End Report SCAFFOLD_MODULE_GRADE_SCA Data Provider Class Header

'Report SCAFFOLD_MODULE_GRADE_SCA Data Provider Class Variables @23-AAC3BDAC

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public UrlSTUDENT_ID  As TextParameter
'End Report SCAFFOLD_MODULE_GRADE_SCA Data Provider Class Variables

'Report SCAFFOLD_MODULE_GRADE_SCA Data Provider Class GetResultSet Method @23-7F10DF91

    Public Sub New()
        Select_=new SqlCommand("SELECT * " & vbCrLf & _
          "FROM view_Student_ModuleReporting" & vbCrLf & _
          "WHERE SCAFFOLD_USER_student_student_id = '{STUDENT_ID}' ",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Report SCAFFOLD_MODULE_GRADE_SCA Data Provider Class GetResultSet Method

'Report SCAFFOLD_MODULE_GRADE_SCA Data Provider Class GetResultSet Method @23-6CA45863
    Public Function GetResultSet(ops As FormSupportedOperations) As SCAFFOLD_MODULE_GRADE_SCAItem()
'End Report SCAFFOLD_MODULE_GRADE_SCA Data Provider Class GetResultSet Method

'Before build Select @23-67DC87D2
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("STUDENT_ID",UrlSTUDENT_ID, "")
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Select_.OrderBy = "view_Student_ModuleReporting.SCAFFOLD_USER_student_student_id asc,view_Student_ModuleReporting.shortname asc" + IIf(Select_.OrderBy.Length>0, ",", "") + Select_.OrderBy
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @23-55FFB542
        Dim ds As DataSet = Nothing
        Dim result(-1) As SCAFFOLD_MODULE_GRADE_SCAItem
        If ops.AllowRead Then
            Try
                    ds=ExecuteSelect()
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @23-2A5407B6
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New SCAFFOLD_MODULE_GRADE_SCAItem(dr.Count-1) {}
'End After execute Select

'After execute Select @23-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @23-5A593D1D
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as SCAFFOLD_MODULE_GRADE_SCAItem = New SCAFFOLD_MODULE_GRADE_SCAItem()
                item.SCAFFOLD_USER_student_id.SetValue(dr(i)("SCAFFOLD_USER_student_student_id"),"")
                item.SCAFFOLD_USER_student_firstname.SetValue(dr(i)("SCAFFOLD_USER_student_firstname"),"")
                item.SCAFFOLD_USER_student_lastname.SetValue(dr(i)("SCAFFOLD_USER_student_lastname"),"")
                item.shortname.SetValue(dr(i)("shortname"),"")
                item.fullname.SetValue(dr(i)("fullname"),"")
                item.name.SetValue(dr(i)("name"),"")
                item.nameHref = "https://lms.decvonline.vic.edu.au/mod/assign/view.php"
                item.nameHrefParameters.Add("id",System.Web.HttpUtility.UrlEncode(dr(i)("activityid").ToString()))
                item.dategraded.SetValue(dr(i)("dategraded"),Select_.DateFormat)
                item.str_long_grade.SetValue(dr(i)("str_long_grade"),"")
                item.str_feedback.SetValue(dr(i)("str_feedback"),"")
                item.firstname.SetValue(dr(i)("SCAFFOLD_USER_firstname"),"")
                item.lastname.SetValue(dr(i)("SCAFFOLD_USER_lastname"),"")
                item.lblgradestyle.SetValue(dr(i)("str_long_grade"),"")
                item.essentialquestion.SetValue(dr(i)("QUESTION_TEXT"),"")
                item.linkExternalReportHref = "http://intranet/ReportServer?/Staff+Reports/Module+Reporting&rs:Command=Render&"
                item.SCAFFOLD_USER_student_idGroupField.SetValue(dr(i)("SCAFFOLD_USER_student_student_id"))
                item.shortnameGroupField.SetValue(dr(i)("shortname"))
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Return result 
    End Function
'End After execute Select tail

'Report Data Provider tail @23-A61BA892
End Class
'End Report Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

