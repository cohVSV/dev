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

Namespace DECV_PROD2007.StudentEnrolment_AddSubjects 'Namespace @1-6BEA715E

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

'Grid SubjectList Item Class @3-D3298775
Public Class SubjectListItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public lbldisplay_STUDENTID As TextField
    Public lbldisplay_ENROL_YEAR As TextField
    Public lbldisplay_YEARLEVEL As TextField
    Public SUBJECT_ID As IntegerField
    Public SUBJECT_TITLE As TextField
    Public COURSE_DISTRIBUTION As TextField
    Public SEMESTER As TextField
    Public ENROL_DATE As TextField
    Public cbox As BooleanField
    Public cboxCheckedValue As BooleanField
    Public cboxUncheckedValue As BooleanField
    Public Sub New()
    lbldisplay_STUDENTID = New TextField("", Nothing)
    lbldisplay_ENROL_YEAR = New TextField("", Nothing)
    lbldisplay_YEARLEVEL = New TextField("", year(now()))
    SUBJECT_ID = New IntegerField("", Nothing)
    SUBJECT_TITLE = New TextField("", Nothing)
    COURSE_DISTRIBUTION = New TextField("", Nothing)
    SEMESTER = New TextField("", Nothing)
    ENROL_DATE = New TextField("", Nothing)
    cbox = New BooleanField(Settings.BoolFormat, False)
    cboxCheckedValue = New BooleanField(Settings.BoolFormat, True)
    cboxUncheckedValue = New BooleanField(Settings.BoolFormat, False)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "lbldisplay_STUDENTID"
                    Return Me.lbldisplay_STUDENTID
                Case "lbldisplay_ENROL_YEAR"
                    Return Me.lbldisplay_ENROL_YEAR
                Case "lbldisplay_YEARLEVEL"
                    Return Me.lbldisplay_YEARLEVEL
                Case "SUBJECT_ID"
                    Return Me.SUBJECT_ID
                Case "SUBJECT_TITLE"
                    Return Me.SUBJECT_TITLE
                Case "COURSE_DISTRIBUTION"
                    Return Me.COURSE_DISTRIBUTION
                Case "SEMESTER"
                    Return Me.SEMESTER
                Case "ENROL_DATE"
                    Return Me.ENROL_DATE
                Case "cbox"
                    Return Me.cbox
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lbldisplay_STUDENTID"
                    Me.lbldisplay_STUDENTID = CType(Value,TextField)
                Case "lbldisplay_ENROL_YEAR"
                    Me.lbldisplay_ENROL_YEAR = CType(Value,TextField)
                Case "lbldisplay_YEARLEVEL"
                    Me.lbldisplay_YEARLEVEL = CType(Value,TextField)
                Case "SUBJECT_ID"
                    Me.SUBJECT_ID = CType(Value,IntegerField)
                Case "SUBJECT_TITLE"
                    Me.SUBJECT_TITLE = CType(Value,TextField)
                Case "COURSE_DISTRIBUTION"
                    Me.COURSE_DISTRIBUTION = CType(Value,TextField)
                Case "SEMESTER"
                    Me.SEMESTER = CType(Value,TextField)
                Case "ENROL_DATE"
                    Me.ENROL_DATE = CType(Value,TextField)
                Case "cbox"
                    Me.cbox = CType(Value,BooleanField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid SubjectList Item Class

'Grid SubjectList Data Provider Class Header @3-8B910ACE
Public Class SubjectListDataProvider
Inherits GridDataProviderBase
'End Grid SubjectList Data Provider Class Header

'Grid SubjectList Data Provider Class Variables @3-268787AC

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 80
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As TextParameter
    Public UrlENROLMENT_YEAR  As TextParameter
'End Grid SubjectList Data Provider Class Variables

'Grid SubjectList Data Provider Class GetResultSet Method @3-D9F4967E

    Public Sub New()
        Select_=new SqlCommand("select A.SUBJECT_ID, B.SUBJECT_TITLE,A.COURSE_DISTRIBUTION, A.SEMESTER, " & vbCrLf & _
          "convert(char(8),A.ENROLMENT_DATE,3) as ENROL_DATE from TEMP_STUDENT_SUBJECT A, SUBJECT B " & vbCrLf & _
          "where A.SUBJECT_ID=B.SUBJECT_ID " & vbCrLf & _
          "and A.STUDENT_ID={STUDENT_ID}" & vbCrLf & _
          "and A.ENROLMENT_YEAR={ENROLMENT_YEAR}",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (select A.SUBJECT_ID, B.SUBJECT_TITLE,A.COURSE_DISTRIBUTION, A.SEMEST" & _
          "ER, " & vbCrLf & _
          "convert(char(8),A.ENROLMENT_DATE,3) as ENROL_DATE from TEMP_STUDENT_SUBJECT A, SUBJECT B " & vbCrLf & _
          "where A.SUBJECT_ID=B.SUBJECT_ID " & vbCrLf & _
          "and A.STUDENT_ID={STUDENT_ID}" & vbCrLf & _
          "and A.ENROLMENT_YEAR={ENROLMENT_YEAR}) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid SubjectList Data Provider Class GetResultSet Method

'Grid SubjectList Data Provider Class GetResultSet Method @3-A7CB912E
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As SubjectListItem()
'End Grid SubjectList Data Provider Class GetResultSet Method

'Before build Select @3-A84CD653
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("STUDENT_ID",UrlSTUDENT_ID, "")
        CType(Select_,SqlCommand).AddParameter("ENROLMENT_YEAR",UrlENROLMENT_YEAR, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @3-55E1DABA
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As SubjectListItem
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

'After execute Select @3-FDAA9FE5
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New SubjectListItem(dr.Count-1) {}
'End After execute Select

'After execute Select @3-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @3-271909D0
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as SubjectListItem = New SubjectListItem()
                item.SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
                item.SUBJECT_TITLE.SetValue(dr(i)("SUBJECT_TITLE"),"")
                item.COURSE_DISTRIBUTION.SetValue(dr(i)("COURSE_DISTRIBUTION"),"")
                item.SEMESTER.SetValue(dr(i)("SEMESTER"),"")
                item.ENROL_DATE.SetValue(dr(i)("ENROL_DATE"),"")
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

'Record AddNewSubject Item Class @11-7D263F80
Public Class AddNewSubjectItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_SUBJECT_ID As TextField
    Public lbladdSUBJECT_TITLE As TextField
    Public addCOURSE_DISTRIBUTION As TextField
    Public addCOURSE_DISTRIBUTIONItems As ItemCollection
    Public addSEMESTER As TextField
    Public addSEMESTERItems As ItemCollection
    Public addENROL_DATE As TextField
    Public hidden_STUDENT_ID As TextField
    Public hidden_ENROLMENT_YEAR As TextField
    Public hidden_YEARLEVEL As TextField
    Public lblMessages As TextField
    Public Sub New()
    s_SUBJECT_ID = New TextField("", Nothing)
    lbladdSUBJECT_TITLE = New TextField("", "none")
    addCOURSE_DISTRIBUTION = New TextField("", "B")
    addCOURSE_DISTRIBUTIONItems = New ItemCollection()
    addSEMESTER = New TextField("", Nothing)
    addSEMESTERItems = New ItemCollection()
    addENROL_DATE = New TextField("dd/mm/yyyy", now())
    hidden_STUDENT_ID = New TextField("", Nothing)
    hidden_ENROLMENT_YEAR = New TextField("", Nothing)
    hidden_YEARLEVEL = New TextField("", Nothing)
    lblMessages = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As AddNewSubjectItem
        Dim item As AddNewSubjectItem = New AddNewSubjectItem()
        If Not IsNothing(DBUtility.GetInitialValue("s_SUBJECT_ID")) Then
        item.s_SUBJECT_ID.SetValue(DBUtility.GetInitialValue("s_SUBJECT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbladdSUBJECT_TITLE")) Then
        item.lbladdSUBJECT_TITLE.SetValue(DBUtility.GetInitialValue("lbladdSUBJECT_TITLE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("addCOURSE_DISTRIBUTION")) Then
        item.addCOURSE_DISTRIBUTION.SetValue(DBUtility.GetInitialValue("addCOURSE_DISTRIBUTION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("addSEMESTER")) Then
        item.addSEMESTER.SetValue(DBUtility.GetInitialValue("addSEMESTER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("addENROL_DATE")) Then
        item.addENROL_DATE.SetValue(DBUtility.GetInitialValue("addENROL_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoAdd")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoDelete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_STUDENT_ID")) Then
        item.hidden_STUDENT_ID.SetValue(DBUtility.GetInitialValue("hidden_STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_ENROLMENT_YEAR")) Then
        item.hidden_ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("hidden_ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_YEARLEVEL")) Then
        item.hidden_YEARLEVEL.SetValue(DBUtility.GetInitialValue("hidden_YEARLEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblMessages")) Then
        item.lblMessages.SetValue(DBUtility.GetInitialValue("lblMessages"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_SUBJECT_ID"
                    Return s_SUBJECT_ID
                Case "lbladdSUBJECT_TITLE"
                    Return lbladdSUBJECT_TITLE
                Case "addCOURSE_DISTRIBUTION"
                    Return addCOURSE_DISTRIBUTION
                Case "addSEMESTER"
                    Return addSEMESTER
                Case "addENROL_DATE"
                    Return addENROL_DATE
                Case "hidden_STUDENT_ID"
                    Return hidden_STUDENT_ID
                Case "hidden_ENROLMENT_YEAR"
                    Return hidden_ENROLMENT_YEAR
                Case "hidden_YEARLEVEL"
                    Return hidden_YEARLEVEL
                Case "lblMessages"
                    Return lblMessages
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_SUBJECT_ID"
                    s_SUBJECT_ID = CType(value, TextField)
                Case "lbladdSUBJECT_TITLE"
                    lbladdSUBJECT_TITLE = CType(value, TextField)
                Case "addCOURSE_DISTRIBUTION"
                    addCOURSE_DISTRIBUTION = CType(value, TextField)
                Case "addSEMESTER"
                    addSEMESTER = CType(value, TextField)
                Case "addENROL_DATE"
                    addENROL_DATE = CType(value, TextField)
                Case "hidden_STUDENT_ID"
                    hidden_STUDENT_ID = CType(value, TextField)
                Case "hidden_ENROLMENT_YEAR"
                    hidden_ENROLMENT_YEAR = CType(value, TextField)
                Case "hidden_YEARLEVEL"
                    hidden_YEARLEVEL = CType(value, TextField)
                Case "lblMessages"
                    lblMessages = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As AddNewSubjectDataProvider)
'End Record AddNewSubject Item Class

's_SUBJECT_ID validate @12-1DEFDF9A
        If IsNothing(s_SUBJECT_ID.Value) OrElse s_SUBJECT_ID.Value.ToString() ="" Then
            errors.Add("s_SUBJECT_ID",String.Format(Resources.strings.CCS_RequiredField,"SUBJECT ID"))
        End If
'End s_SUBJECT_ID validate

'addSEMESTER validate @14-0B688BFD
        If IsNothing(addSEMESTER.Value) OrElse addSEMESTER.Value.ToString() ="" Then
            errors.Add("addSEMESTER",String.Format(Resources.strings.CCS_RequiredField,"addSEMESTER"))
        End If
'End addSEMESTER validate

'addENROL_DATE validate @15-ECFF38FA
        If IsNothing(addENROL_DATE.Value) OrElse addENROL_DATE.Value.ToString() ="" Then
            errors.Add("addENROL_DATE",String.Format(Resources.strings.CCS_RequiredField,"addENROL_DATE"))
        End If
'End addENROL_DATE validate

'Record AddNewSubject Item Class tail @11-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record AddNewSubject Item Class tail

'Record AddNewSubject Data Provider Class @11-451F92C4
Public Class AddNewSubjectDataProvider
Inherits RecordDataProviderBase
'End Record AddNewSubject Data Provider Class

'Record AddNewSubject Data Provider Class Variables @11-6B5D9068
    Protected item As AddNewSubjectItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record AddNewSubject Data Provider Class Variables

'Record AddNewSubject Data Provider Class GetResultSet Method @11-A5E32F3D

    Public Sub FillItem(ByVal item As AddNewSubjectItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record AddNewSubject Data Provider Class GetResultSet Method

'Record AddNewSubject BeforeBuildSelect @11-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record AddNewSubject BeforeBuildSelect

'Record AddNewSubject AfterExecuteSelect @11-79426A21
        End If
            IsInsertMode = True
'End Record AddNewSubject AfterExecuteSelect

'ListBox addCOURSE_DISTRIBUTION AfterExecuteSelect @13-0CF26319
        
item.addCOURSE_DISTRIBUTIONItems.Add("B","Book")
item.addCOURSE_DISTRIBUTIONItems.Add("C","CD")
item.addCOURSE_DISTRIBUTIONItems.Add("E","E-mail")
item.addCOURSE_DISTRIBUTIONItems.Add("I","Internet")
'End ListBox addCOURSE_DISTRIBUTION AfterExecuteSelect

'ListBox addSEMESTER AfterExecuteSelect @14-9D443F35
        
item.addSEMESTERItems.Add("1","1")
item.addSEMESTERItems.Add("2","2")
item.addSEMESTERItems.Add("B","Both")
'End ListBox addSEMESTER AfterExecuteSelect

'Record AddNewSubject AfterExecuteSelect tail @11-E31F8E2A
    End Sub
'End Record AddNewSubject AfterExecuteSelect tail

'Record AddNewSubject Data Provider Class @11-A61BA892
End Class

'End Record AddNewSubject Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

