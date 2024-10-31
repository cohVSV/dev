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

Namespace DECV_PROD2007.StudentEnrolment_InitialCheck 'Namespace @1-7114D028

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

'Record STUDENTSearch Item Class @10-66957511
Public Class STUDENTSearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_SURNAME As TextField
    Public s_FIRST_NAME As TextField
    Public s_BIRTH_DATE As DateField
    Public s_STUDENT_ID As TextField
    Public s_Email As TextField
    Public Sub New()
    s_SURNAME = New TextField("", Nothing)
    s_FIRST_NAME = New TextField("", Nothing)
    s_BIRTH_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    s_STUDENT_ID = New TextField("", Nothing)
    s_Email = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENTSearchItem
        Dim item As STUDENTSearchItem = New STUDENTSearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("s_SURNAME")) Then
        item.s_SURNAME.SetValue(DBUtility.GetInitialValue("s_SURNAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_FIRST_NAME")) Then
        item.s_FIRST_NAME.SetValue(DBUtility.GetInitialValue("s_FIRST_NAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_BIRTH_DATE")) Then
        item.s_BIRTH_DATE.SetValue(DBUtility.GetInitialValue("s_BIRTH_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_STUDENT_ID")) Then
        item.s_STUDENT_ID.SetValue(DBUtility.GetInitialValue("s_STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_Email")) Then
        item.s_Email.SetValue(DBUtility.GetInitialValue("s_Email"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_SURNAME"
                    Return s_SURNAME
                Case "s_FIRST_NAME"
                    Return s_FIRST_NAME
                Case "s_BIRTH_DATE"
                    Return s_BIRTH_DATE
                Case "s_STUDENT_ID"
                    Return s_STUDENT_ID
                Case "s_Email"
                    Return s_Email
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_SURNAME"
                    s_SURNAME = CType(value, TextField)
                Case "s_FIRST_NAME"
                    s_FIRST_NAME = CType(value, TextField)
                Case "s_BIRTH_DATE"
                    s_BIRTH_DATE = CType(value, DateField)
                Case "s_STUDENT_ID"
                    s_STUDENT_ID = CType(value, TextField)
                Case "s_Email"
                    s_Email = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STUDENTSearchDataProvider)
'End Record STUDENTSearch Item Class

'Record STUDENTSearch Event OnValidate. Action Custom Code @40-73254650
    ' -------------------------
    ' ERA: if the Student ID is not there then check the SURNAME, Firstname, and DOB
	 If (s_STUDENT_ID.Value Is Nothing) OrElse s_STUDENT_ID.Value.ToString()="" Then
		If (s_SURNAME.Value Is Nothing) OrElse s_SURNAME.Value.ToString()="" Then
            errors.Add("s_SURNAME",String.Format("Type a SURNAME if no Student ID is entered.","Surname"))
        End If
		If (s_FIRST_NAME.Value Is Nothing) OrElse s_FIRST_NAME.Value.ToString()="" Then
            errors.Add("s_FIRST_NAME",String.Format("Type a FIRST NAME if no Student ID is entered.","First Name"))
        End If
		 If (s_BIRTH_DATE.Value Is Nothing) OrElse s_BIRTH_DATE.Value.ToString()="" Then
            errors.Add("s_BIRTH_DATE",String.Format("Type a BIRTH DATE if no Student ID is entered.","Birth Date"))
        End If
		If  (((s_SURNAME.Value Is Nothing) OrElse s_SURNAME.Value.ToString()="") AND ((s_FIRST_NAME.Value Is Nothing) OrElse s_FIRST_NAME.Value.ToString()="") AND ((s_BIRTH_DATE.Value Is Nothing) OrElse s_BIRTH_DATE.Value.ToString()="")) Then
			If (s_STUDENT_ID.Value Is Nothing) OrElse s_STUDENT_ID.Value.ToString()="" Then
            	errors.Add("s_STUDENT_ID",String.Format("Type a STUDENT ID if no other details are entered.","Student ID"))
			End If
		End if
		If (s_Email.Value Is Nothing) OrElse s_Email.Value.ToString()="" Then
            errors.Add("s_Email",String.Format("Type an email if no Student ID is entered.","Email"))
        End If
	End if
    ' -------------------------
'End Record STUDENTSearch Event OnValidate. Action Custom Code

'Record STUDENTSearch Item Class tail @10-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENTSearch Item Class tail

'Record STUDENTSearch Data Provider Class @10-D703FE6F
Public Class STUDENTSearchDataProvider
Inherits RecordDataProviderBase
'End Record STUDENTSearch Data Provider Class

'Record STUDENTSearch Data Provider Class Variables @10-C5ABAA20
    Protected item As STUDENTSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENTSearch Data Provider Class Variables

'Record STUDENTSearch Data Provider Class GetResultSet Method @10-5D9B1AD8

    Public Sub FillItem(ByVal item As STUDENTSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record STUDENTSearch Data Provider Class GetResultSet Method

'Record STUDENTSearch BeforeBuildSelect @10-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENTSearch BeforeBuildSelect

'Record STUDENTSearch AfterExecuteSelect @10-79426A21
        End If
            IsInsertMode = True
'End Record STUDENTSearch AfterExecuteSelect

'Record STUDENTSearch AfterExecuteSelect tail @10-E31F8E2A
    End Sub
'End Record STUDENTSearch AfterExecuteSelect tail

'Record STUDENTSearch Data Provider Class @10-A61BA892
End Class

'End Record STUDENTSearch Data Provider Class

'Grid STUDENT Item Class @3-96DC7471
Public Class STUDENTItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public STUDENT_ID As FloatField
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public BIRTH_DATE As DateField
    Public SEX As TextField
    Public link_AddNewStudent As TextField
    Public link_AddNewStudentHref As Object
    Public link_AddNewStudentHrefParameters As LinkParameterCollection
    Public lblWarningExistingStudent As TextField
    Public PREFERRED_NAME As TextField
    Public EMAIL As TextField
    Public Label1 As TextField
    Public link_AddNewStudent1 As TextField
    Public link_AddNewStudent1Href As Object
    Public link_AddNewStudent1HrefParameters As LinkParameterCollection
    Public Sub New()
    Link1 = New TextField("",Nothing)
    Link1HrefParameters = New LinkParameterCollection()
    STUDENT_ID = New FloatField("", Nothing)
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    BIRTH_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    SEX = New TextField("", Nothing)
    link_AddNewStudent = New TextField("",Nothing)
    link_AddNewStudentHrefParameters = New LinkParameterCollection()
    lblWarningExistingStudent = New TextField("", "You are trying to enter a student who has the same first name, last name, and date of birth as a past student. If this is really a different person and they need to be entered please contact PC Support to enter them as a new student. Otherwise please add a new year to the student below.")
    PREFERRED_NAME = New TextField("", Nothing)
    EMAIL = New TextField("", Nothing)
    Label1 = New TextField("", "Possible match found. Please check carefully if this is a returning student who has changed their email or a new student with the same name.")
    link_AddNewStudent1 = New TextField("",Nothing)
    link_AddNewStudent1HrefParameters = New LinkParameterCollection()
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "Link1"
                    Return Me.Link1
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "BIRTH_DATE"
                    Return Me.BIRTH_DATE
                Case "SEX"
                    Return Me.SEX
                Case "link_AddNewStudent"
                    Return Me.link_AddNewStudent
                Case "lblWarningExistingStudent"
                    Return Me.lblWarningExistingStudent
                Case "PREFERRED_NAME"
                    Return Me.PREFERRED_NAME
                Case "EMAIL"
                    Return Me.EMAIL
                Case "Label1"
                    Return Me.Label1
                Case "link_AddNewStudent1"
                    Return Me.link_AddNewStudent1
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link1"
                    Me.Link1 = CType(Value,TextField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "BIRTH_DATE"
                    Me.BIRTH_DATE = CType(Value,DateField)
                Case "SEX"
                    Me.SEX = CType(Value,TextField)
                Case "link_AddNewStudent"
                    Me.link_AddNewStudent = CType(Value,TextField)
                Case "lblWarningExistingStudent"
                    Me.lblWarningExistingStudent = CType(Value,TextField)
                Case "PREFERRED_NAME"
                    Me.PREFERRED_NAME = CType(Value,TextField)
                Case "EMAIL"
                    Me.EMAIL = CType(Value,TextField)
                Case "Label1"
                    Me.Label1 = CType(Value,TextField)
                Case "link_AddNewStudent1"
                    Me.link_AddNewStudent1 = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STUDENT Item Class

'Grid STUDENT Data Provider Class Header @3-A0C36CC0
Public Class STUDENTDataProvider
Inherits GridDataProviderBase
'End Grid STUDENT Data Provider Class Header

'Grid STUDENT Data Provider Class Variables @3-934A9E67

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 40
    Public PageNumber As Integer = 1
    Public Urls_SURNAME  As TextParameter
    Public Urls_FIRST_NAME  As TextParameter
    Public Urls_BIRTH_DATE  As DateParameter
    Public Urls_STUDENT_ID  As FloatParameter
    Public Urls_Email  As TextParameter
'End Grid STUDENT Data Provider Class Variables

'Grid STUDENT Data Provider Class GetResultSet Method @3-C2062A3B

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} STUDENT_ID, SURNAME, FIRST_NAME, BIRTH_DATE, SEX, " & vbCrLf & _
          "PREFERRED_NAME, STUDENT_EMAIL " & vbCrLf & _
          "FROM STUDENT {SQL_Where} {SQL_OrderBy}", New String(){"(","s_SURNAME196","And","(","s_FIRST_NAME197","Or","s_FIRST_NAME198",")","And","s_BIRTH_DATE199",")","Or","s_STUDENT_ID200","Or","s_Email201"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STUDENT", New String(){"(","s_SURNAME196","And","(","s_FIRST_NAME197","Or","s_FIRST_NAME198",")","And","s_BIRTH_DATE199",")","Or","s_STUDENT_ID200","Or","s_Email201"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid STUDENT Data Provider Class GetResultSet Method

'Grid STUDENT Data Provider Class GetResultSet Method @3-D97550AD
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STUDENTItem()
'End Grid STUDENT Data Provider Class GetResultSet Method

'Before build Select @3-C1C88D73
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_SURNAME196",Urls_SURNAME, "","SURNAME",Condition.Contains,True)
        CType(Select_,TableCommand).AddParameter("s_FIRST_NAME197",Urls_FIRST_NAME, "","FIRST_NAME",Condition.Contains,True)
        CType(Select_,TableCommand).AddParameter("s_FIRST_NAME198",Urls_FIRST_NAME, "","PREFERRED_NAME",Condition.BeginsWith,True)
        CType(Select_,TableCommand).AddParameter("s_BIRTH_DATE199",Urls_BIRTH_DATE, Select_.DateFormat,"BIRTH_DATE",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("s_STUDENT_ID200",Urls_STUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("s_Email201",Urls_Email, "","STUDENT_EMAIL",Condition.Contains,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @3-3D736C2C
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STUDENTItem
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

'After execute Select @3-2A52CBC2
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENTItem(dr.Count-1) {}
'End After execute Select

'After execute Select @3-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @3-2B39EBEE
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENTItem = New STUDENTItem()
                item.Link1Href = "StudentEnrolment_AddNewYear.aspx"
                item.Link1HrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.BIRTH_DATE.SetValue(dr(i)("BIRTH_DATE"),Select_.DateFormat)
                item.SEX.SetValue(dr(i)("SEX"),"")
                item.link_AddNewStudentHref = "StudentEnrolment_DetailsWizard.aspx"
                item.PREFERRED_NAME.SetValue(dr(i)("PREFERRED_NAME"),"")
                item.EMAIL.SetValue(dr(i)("STUDENT_EMAIL"),"")
                item.link_AddNewStudent1Href = "StudentEnrolment_DetailsWizard.aspx"
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @3-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

