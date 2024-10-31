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

Namespace DECV_PROD2007.services.Student_ClassList_Export 'Namespace @1-71C4C79C

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

'Grid view_Class_Contact_List_0 Item Class @2-34DF0DE2
Public Class view_Class_Contact_List_0Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STUDENT_ID As IntegerField
    Public Alert As TextField
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public LAd As TextField
    Public PHONE1 As TextField
    Public EMAIL1 As TextField
    Public PHONE2 As TextField
    Public EMAIL2 As TextField
    Public SUBJECT_ABBREV As TextField
    Public SUBJ_ENROL_STATUS As TextField
    Public SCHOOL_NAME As TextField
    Public SCHOOL_SUPERVISOR_NAME As TextField
    Public SCHOOL_SUPERVISOR_PHONE As TextField
    Public SCHOOL_SUPERVISOR_EMAIL As TextField
    Public STAFF_ID As TextField
    Public PARENT_A_NAME As TextField
    Public PARENT_A_MOBILE As TextField
    Public PARENT_A_HOMEPHONE As TextField
    Public PARENT_A_EMAIL As TextField
    Public ENROLMENT_DATE As DateField
    Public YEAR_LEVEL As IntegerField
    Public Sub New()
    STUDENT_ID = New IntegerField("0", Nothing)
    Alert = New TextField("", Nothing)
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    LAd = New TextField("", Nothing)
    PHONE1 = New TextField("", Nothing)
    EMAIL1 = New TextField("", Nothing)
    PHONE2 = New TextField("", Nothing)
    EMAIL2 = New TextField("", Nothing)
    SUBJECT_ABBREV = New TextField("", Nothing)
    SUBJ_ENROL_STATUS = New TextField("", Nothing)
    SCHOOL_NAME = New TextField("", Nothing)
    SCHOOL_SUPERVISOR_NAME = New TextField("", Nothing)
    SCHOOL_SUPERVISOR_PHONE = New TextField("", Nothing)
    SCHOOL_SUPERVISOR_EMAIL = New TextField("", Nothing)
    STAFF_ID = New TextField("", Nothing)
    PARENT_A_NAME = New TextField("", Nothing)
    PARENT_A_MOBILE = New TextField("", Nothing)
    PARENT_A_HOMEPHONE = New TextField("", Nothing)
    PARENT_A_EMAIL = New TextField("", Nothing)
    ENROLMENT_DATE = New DateField(Settings.DateFormat, Nothing)
    YEAR_LEVEL = New IntegerField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "Alert"
                    Return Me.Alert
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "LAd"
                    Return Me.LAd
                Case "PHONE1"
                    Return Me.PHONE1
                Case "EMAIL1"
                    Return Me.EMAIL1
                Case "PHONE2"
                    Return Me.PHONE2
                Case "EMAIL2"
                    Return Me.EMAIL2
                Case "SUBJECT_ABBREV"
                    Return Me.SUBJECT_ABBREV
                Case "SUBJ_ENROL_STATUS"
                    Return Me.SUBJ_ENROL_STATUS
                Case "SCHOOL_NAME"
                    Return Me.SCHOOL_NAME
                Case "SCHOOL_SUPERVISOR_NAME"
                    Return Me.SCHOOL_SUPERVISOR_NAME
                Case "SCHOOL_SUPERVISOR_PHONE"
                    Return Me.SCHOOL_SUPERVISOR_PHONE
                Case "SCHOOL_SUPERVISOR_EMAIL"
                    Return Me.SCHOOL_SUPERVISOR_EMAIL
                Case "STAFF_ID"
                    Return Me.STAFF_ID
                Case "PARENT_A_NAME"
                    Return Me.PARENT_A_NAME
                Case "PARENT_A_MOBILE"
                    Return Me.PARENT_A_MOBILE
                Case "PARENT_A_HOMEPHONE"
                    Return Me.PARENT_A_HOMEPHONE
                Case "PARENT_A_EMAIL"
                    Return Me.PARENT_A_EMAIL
                Case "ENROLMENT_DATE"
                    Return Me.ENROLMENT_DATE
                Case "YEAR_LEVEL"
                    Return Me.YEAR_LEVEL
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,IntegerField)
                Case "Alert"
                    Me.Alert = CType(Value,TextField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "LAd"
                    Me.LAd = CType(Value,TextField)
                Case "PHONE1"
                    Me.PHONE1 = CType(Value,TextField)
                Case "EMAIL1"
                    Me.EMAIL1 = CType(Value,TextField)
                Case "PHONE2"
                    Me.PHONE2 = CType(Value,TextField)
                Case "EMAIL2"
                    Me.EMAIL2 = CType(Value,TextField)
                Case "SUBJECT_ABBREV"
                    Me.SUBJECT_ABBREV = CType(Value,TextField)
                Case "SUBJ_ENROL_STATUS"
                    Me.SUBJ_ENROL_STATUS = CType(Value,TextField)
                Case "SCHOOL_NAME"
                    Me.SCHOOL_NAME = CType(Value,TextField)
                Case "SCHOOL_SUPERVISOR_NAME"
                    Me.SCHOOL_SUPERVISOR_NAME = CType(Value,TextField)
                Case "SCHOOL_SUPERVISOR_PHONE"
                    Me.SCHOOL_SUPERVISOR_PHONE = CType(Value,TextField)
                Case "SCHOOL_SUPERVISOR_EMAIL"
                    Me.SCHOOL_SUPERVISOR_EMAIL = CType(Value,TextField)
                Case "STAFF_ID"
                    Me.STAFF_ID = CType(Value,TextField)
                Case "PARENT_A_NAME"
                    Me.PARENT_A_NAME = CType(Value,TextField)
                Case "PARENT_A_MOBILE"
                    Me.PARENT_A_MOBILE = CType(Value,TextField)
                Case "PARENT_A_HOMEPHONE"
                    Me.PARENT_A_HOMEPHONE = CType(Value,TextField)
                Case "PARENT_A_EMAIL"
                    Me.PARENT_A_EMAIL = CType(Value,TextField)
                Case "ENROLMENT_DATE"
                    Me.ENROLMENT_DATE = CType(Value,DateField)
                Case "YEAR_LEVEL"
                    Me.YEAR_LEVEL = CType(Value,IntegerField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid view_Class_Contact_List_0 Item Class

'Grid view_Class_Contact_List_0 Data Provider Class Header @2-FFBADAEB
Public Class view_Class_Contact_List_0DataProvider
Inherits GridDataProviderBase
'End Grid view_Class_Contact_List_0 Data Provider Class Header

'Grid view_Class_Contact_List_0 Data Provider Class Variables @2-53B9A9EE

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 10
    Public PageNumber As Integer = 1
'End Grid view_Class_Contact_List_0 Data Provider Class Variables

'Grid view_Class_Contact_List_0 Data Provider Class GetResultSet Method @2-D76DAAB5

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM view_Class_Contact_List_04022011 {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM view_Class_Contact_List_04022011", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid view_Class_Contact_List_0 Data Provider Class GetResultSet Method

'Grid view_Class_Contact_List_0 Data Provider Class GetResultSet Method @2-737805CE
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As view_Class_Contact_List_0Item()
'End Grid view_Class_Contact_List_0 Data Provider Class GetResultSet Method

'Before build Select @2-3C363B34
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-2BC2946A
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As view_Class_Contact_List_0Item
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

'After execute Select @2-F6F2BFC4
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New view_Class_Contact_List_0Item(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-BB3C8374
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as view_Class_Contact_List_0Item = New view_Class_Contact_List_0Item()
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.Alert.SetValue(dr(i)("Alert"),"")
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.LAd.SetValue(dr(i)("LAd"),"")
                item.PHONE1.SetValue(dr(i)("PHONE1"),"")
                item.EMAIL1.SetValue(dr(i)("EMAIL1"),"")
                item.PHONE2.SetValue(dr(i)("PHONE2"),"")
                item.EMAIL2.SetValue(dr(i)("EMAIL2"),"")
                item.SUBJECT_ABBREV.SetValue(dr(i)("SUBJECT_ABBREV"),"")
                item.SUBJ_ENROL_STATUS.SetValue(dr(i)("SUBJ_ENROL_STATUS"),"")
                item.SCHOOL_NAME.SetValue(dr(i)("SCHOOL_NAME"),"")
                item.SCHOOL_SUPERVISOR_NAME.SetValue(dr(i)("SCHOOL_SUPERVISOR_NAME"),"")
                item.SCHOOL_SUPERVISOR_PHONE.SetValue(dr(i)("SCHOOL_SUPERVISOR_PHONE"),"")
                item.SCHOOL_SUPERVISOR_EMAIL.SetValue(dr(i)("SCHOOL_SUPERVISOR_EMAIL"),"")
                item.STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
                item.PARENT_A_NAME.SetValue(dr(i)("PARENT_A_NAME"),"")
                item.PARENT_A_MOBILE.SetValue(dr(i)("PARENT_A_MOBILE"),"")
                item.PARENT_A_HOMEPHONE.SetValue(dr(i)("PARENT_A_HOMEPHONE"),"")
                item.PARENT_A_EMAIL.SetValue(dr(i)("PARENT_A_EMAIL"),"")
                item.ENROLMENT_DATE.SetValue(dr(i)("ENROLMENT_DATE"),Select_.DateFormat)
                item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
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

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

