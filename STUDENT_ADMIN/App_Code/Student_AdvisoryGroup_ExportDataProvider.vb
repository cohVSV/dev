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

Namespace DECV_PROD2007.Student_AdvisoryGroup_Export 'Namespace @1-C3932ED2

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

'DEL      ' -------------------------
'DEL      	If (DBUtility.AuthorizeUser(New String(){"2","3","6","7","9"})) Then
'DEL  		else
'DEL  				    CType(List_Subject_idDataCommand, SqlCommand).SqlQuery.Append(" AND STAFF_ID like '" & DBUtility.UserLogin.ToUpper & "%'")
'DEL  		end if
'DEL      ' -------------------------

'Grid Students_Grid Item Class @25-38300EF8
Public Class Students_GridItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public SCHOOL_NAME As TextField
    Public STUDENT_ID As FloatField
    Public STUDENT_IDHref As Object
    Public STUDENT_IDHrefParameters As LinkParameterCollection
    Public QuickContact As FloatField
    Public QuickContactHref As Object
    Public QuickContactHrefParameters As LinkParameterCollection
    Public Contacts As FloatField
    Public ContactsHref As Object
    Public ContactsHrefParameters As LinkParameterCollection
    Public PHONE1 As TextField
    Public EMAIL1 As TextField
    Public EMAIL1Href As Object
    Public EMAIL1HrefParameters As LinkParameterCollection
    Public EMAIL2 As TextField
    Public EMAIL2Href As Object
    Public EMAIL2HrefParameters As LinkParameterCollection
    Public PHONE2 As TextField
    Public SUBJECT_ABBREV As TextField
    Public STAFF_ID As TextField
    Public label_ALERTS As TextField
    Public SCHOOL_SUPER_NAME As TextField
    Public SCHOOL_SUPER_PHONE As TextField
    Public SCHOOL_SUPER_EMAIL As TextField
    Public SCHOOL_SUPER_EMAILHref As Object
    Public SCHOOL_SUPER_EMAILHrefParameters As LinkParameterCollection
    Public PARENT_NAME As TextField
    Public PARENT_MOBILE As TextField
    Public PARENT_PHONE As TextField
    Public PARENT_EMAIL As TextField
    Public PARENT_EMAILHref As Object
    Public PARENT_EMAILHrefParameters As LinkParameterCollection
    Public ENROLMENT_DATE As DateField
    Public LAD As TextField
    Public Sub New()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    SCHOOL_NAME = New TextField("", Nothing)
    STUDENT_ID = New FloatField("",Nothing)
    STUDENT_IDHrefParameters = New LinkParameterCollection()
    QuickContact = New FloatField("",Nothing)
    QuickContactHrefParameters = New LinkParameterCollection()
    Contacts = New FloatField("",Nothing)
    ContactsHrefParameters = New LinkParameterCollection()
    PHONE1 = New TextField("", Nothing)
    EMAIL1 = New TextField("",Nothing)
    EMAIL1HrefParameters = New LinkParameterCollection()
    EMAIL2 = New TextField("",Nothing)
    EMAIL2HrefParameters = New LinkParameterCollection()
    PHONE2 = New TextField("", Nothing)
    SUBJECT_ABBREV = New TextField("", Nothing)
    STAFF_ID = New TextField("", Nothing)
    label_ALERTS = New TextField("", Nothing)
    SCHOOL_SUPER_NAME = New TextField("", Nothing)
    SCHOOL_SUPER_PHONE = New TextField("", Nothing)
    SCHOOL_SUPER_EMAIL = New TextField("",Nothing)
    SCHOOL_SUPER_EMAILHrefParameters = New LinkParameterCollection()
    PARENT_NAME = New TextField("", Nothing)
    PARENT_MOBILE = New TextField("", Nothing)
    PARENT_PHONE = New TextField("", Nothing)
    PARENT_EMAIL = New TextField("",Nothing)
    PARENT_EMAILHrefParameters = New LinkParameterCollection()
    ENROLMENT_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    LAD = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "SCHOOL_NAME"
                    Return Me.SCHOOL_NAME
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "QuickContact"
                    Return Me.QuickContact
                Case "Contacts"
                    Return Me.Contacts
                Case "PHONE1"
                    Return Me.PHONE1
                Case "EMAIL1"
                    Return Me.EMAIL1
                Case "EMAIL2"
                    Return Me.EMAIL2
                Case "PHONE2"
                    Return Me.PHONE2
                Case "SUBJECT_ABBREV"
                    Return Me.SUBJECT_ABBREV
                Case "STAFF_ID"
                    Return Me.STAFF_ID
                Case "label_ALERTS"
                    Return Me.label_ALERTS
                Case "SCHOOL_SUPER_NAME"
                    Return Me.SCHOOL_SUPER_NAME
                Case "SCHOOL_SUPER_PHONE"
                    Return Me.SCHOOL_SUPER_PHONE
                Case "SCHOOL_SUPER_EMAIL"
                    Return Me.SCHOOL_SUPER_EMAIL
                Case "PARENT_NAME"
                    Return Me.PARENT_NAME
                Case "PARENT_MOBILE"
                    Return Me.PARENT_MOBILE
                Case "PARENT_PHONE"
                    Return Me.PARENT_PHONE
                Case "PARENT_EMAIL"
                    Return Me.PARENT_EMAIL
                Case "ENROLMENT_DATE"
                    Return Me.ENROLMENT_DATE
                Case "LAD"
                    Return Me.LAD
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "SCHOOL_NAME"
                    Me.SCHOOL_NAME = CType(Value,TextField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "QuickContact"
                    Me.QuickContact = CType(Value,FloatField)
                Case "Contacts"
                    Me.Contacts = CType(Value,FloatField)
                Case "PHONE1"
                    Me.PHONE1 = CType(Value,TextField)
                Case "EMAIL1"
                    Me.EMAIL1 = CType(Value,TextField)
                Case "EMAIL2"
                    Me.EMAIL2 = CType(Value,TextField)
                Case "PHONE2"
                    Me.PHONE2 = CType(Value,TextField)
                Case "SUBJECT_ABBREV"
                    Me.SUBJECT_ABBREV = CType(Value,TextField)
                Case "STAFF_ID"
                    Me.STAFF_ID = CType(Value,TextField)
                Case "label_ALERTS"
                    Me.label_ALERTS = CType(Value,TextField)
                Case "SCHOOL_SUPER_NAME"
                    Me.SCHOOL_SUPER_NAME = CType(Value,TextField)
                Case "SCHOOL_SUPER_PHONE"
                    Me.SCHOOL_SUPER_PHONE = CType(Value,TextField)
                Case "SCHOOL_SUPER_EMAIL"
                    Me.SCHOOL_SUPER_EMAIL = CType(Value,TextField)
                Case "PARENT_NAME"
                    Me.PARENT_NAME = CType(Value,TextField)
                Case "PARENT_MOBILE"
                    Me.PARENT_MOBILE = CType(Value,TextField)
                Case "PARENT_PHONE"
                    Me.PARENT_PHONE = CType(Value,TextField)
                Case "PARENT_EMAIL"
                    Me.PARENT_EMAIL = CType(Value,TextField)
                Case "ENROLMENT_DATE"
                    Me.ENROLMENT_DATE = CType(Value,DateField)
                Case "LAD"
                    Me.LAD = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid Students_Grid Item Class

'Grid Students_Grid Data Provider Class Header @25-48E2C817
Public Class Students_GridDataProvider
Inherits GridDataProviderBase
'End Grid Students_Grid Data Provider Class Header

'Grid Students_Grid Data Provider Class Variables @25-9173D6E1

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 100
    Public PageNumber As Integer = 1
    Public Expr160  As TextParameter
'End Grid Students_Grid Data Provider Class Variables

'Grid Students_Grid Data Provider Class GetResultSet Method @25-D9D8B779

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM view_Class_Contact_List_04022011 {SQL_Where} {SQL_OrderBy}", New String(){"expr158","And","expr159","And","expr160"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM view_Class_Contact_List_04022011", New String(){"expr158","And","expr159","And","expr160"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid Students_Grid Data Provider Class GetResultSet Method

'Grid Students_Grid Data Provider Class GetResultSet Method @25-B46BE413
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As Students_GridItem()
'End Grid Students_Grid Data Provider Class GetResultSet Method

'DEL      ' -------------------------
'DEL  	if Semester_Enrolment_SearchSubj_Enrol_Status_Checked.Value <>"" Then
'DEL        Expr78=Semester_Enrolment_SearchSubj_Enrol_Status_Checked.Value
'DEL  	else
'DEL  	  Expr78=""
'DEL  	 end if 	
'DEL      ' -------------------------


'Before build Select @25-CEC4A684
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("expr160",Expr160, "","LAd",Condition.Equal,False)
        Select_.Parameters.Add("expr158","(ENROLMENT_YEAR =year(getdate()))")
        Select_.Parameters.Add("expr159","(SUBJECT_ID in (921,922,923,924))")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Grid Students_Grid Event BeforeExecuteSelect. Action Declare Variable @138-918DE68D
        Dim showallflag As String = ""
'End Grid Students_Grid Event BeforeExecuteSelect. Action Declare Variable

'Grid Students_Grid Event BeforeExecuteSelect. Action Retrieve Value for Variable @137-6E280C70
        showallflag = System.Web.HttpContext.Current.Request.QueryString("showall")
'End Grid Students_Grid Event BeforeExecuteSelect. Action Retrieve Value for Variable

'Grid Students_Grid Event BeforeExecuteSelect. Action Custom Code @135-73254650
    ' -------------------------
 	' ERA: set the Staff ID depending on security level
 	' 9-Mar-2018|EA not needed for this export
'
'	If (showallflag="1") Then
'		' check for elevated
'		If (DBUtility.AuthorizeUser(New String(){"2","3","6","7","9"})) Then
'			' show all
'		else
'			Select_.SqlQuery.Append(" AND STAFF_ID like '" & DBUtility.UserLogin.ToUpper & "%'")
'		end if
'	else
'		Select_.SqlQuery.Append(" AND STAFF_ID like '" & DBUtility.UserLogin.ToUpper & "%'")
'	end if

    ' -------------------------
'End Grid Students_Grid Event BeforeExecuteSelect. Action Custom Code

'Execute Select @25-48CB26AA
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As Students_GridItem
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

'After execute Select @25-44B1AFE6
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New Students_GridItem(dr.Count-1) {}
'End After execute Select

'After execute Select @25-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @25-3B145E0F
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as Students_GridItem = New Students_GridItem()
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.SCHOOL_NAME.SetValue(dr(i)("SCHOOL_NAME"),"")
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.STUDENT_IDHref = "StudentSummary.aspx"
                item.STUDENT_IDHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
                item.STUDENT_IDHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
                item.QuickContact.SetValue(dr(i)("STUDENT_ID"),"")
                item.QuickContactHref = "WinLogin/StudentContactQuickEntry.aspx"
                item.QuickContactHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
                item.Contacts.SetValue(dr(i)("STUDENT_ID"),"")
                item.ContactsHref = "Student_Comments_maintain.aspx"
                item.ContactsHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
                item.ContactsHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
                item.PHONE1.SetValue(dr(i)("PHONE1"),"")
                item.EMAIL1.SetValue(dr(i)("EMAIL1"),"")
                item.EMAIL1Href = dr(i)("EMAIL1")
                item.EMAIL2.SetValue(dr(i)("EMAIL2"),"")
                item.EMAIL2Href = dr(i)("EMAIL2")
                item.PHONE2.SetValue(dr(i)("PHONE2"),"")
                item.SUBJECT_ABBREV.SetValue(dr(i)("SUBJECT_ABBREV"),"")
                item.STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
                item.SCHOOL_SUPER_NAME.SetValue(dr(i)("SCHOOL_SUPERVISOR_NAME"),"")
                item.SCHOOL_SUPER_PHONE.SetValue(dr(i)("SCHOOL_SUPERVISOR_PHONE"),"")
                item.SCHOOL_SUPER_EMAIL.SetValue(dr(i)("SCHOOL_SUPERVISOR_EMAIL"),"")
                item.SCHOOL_SUPER_EMAILHref = dr(i)("SCHOOL_SUPERVISOR_EMAIL")
                item.PARENT_NAME.SetValue(dr(i)("PARENT_A_NAME"),"")
                item.PARENT_MOBILE.SetValue(dr(i)("PARENT_A_MOBILE"),"")
                item.PARENT_PHONE.SetValue(dr(i)("PARENT_A_HOMEPHONE"),"")
                item.PARENT_EMAIL.SetValue(dr(i)("PARENT_A_EMAIL"),"")
                item.PARENT_EMAILHref = dr(i)("PARENT_A_EMAIL")
                item.ENROLMENT_DATE.SetValue(dr(i)("ENROLMENT_DATE"),Select_.DateFormat)
                item.LAD.SetValue(dr(i)("LAd"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @25-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

