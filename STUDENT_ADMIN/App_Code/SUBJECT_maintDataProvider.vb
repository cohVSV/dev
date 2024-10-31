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

Namespace DECV_PROD2007.SUBJECT_maint 'Namespace @1-9790DE0A

'Page Data Class @1-1CA1EF9E
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public Sub New()
        Link1 = New TextField("",Nothing)
        Link1HrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Link1.SetValue(DBUtility.GetInitialValue("Link1"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Link1"
                    Return Link1
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link1"
                    Link1 = CType(value, TextField)
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

'Record NewRecord1 Item Class @29-7C1B6775
Public Class NewRecord1Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public SUBJECT_ID As IntegerField
    Public SUBJECT_ABBREV As TextField
    Public SUBJECT_TITLE As TextField
    Public YEAR_LEVEL As IntegerField
    Public DEFAULT_SEMESTER As TextField
    Public DEFAULT_SEMESTERItems As ItemCollection
    Public DEFAULT_TEACHER_ID As TextField
    Public DEFAULT_TEACHER_IDItems As ItemCollection
    Public SUB_SCHOOL As TextField
    Public KLA_ID As FloatField
    Public KLA_IDItems As ItemCollection
    Public CSF_CLASS_LEVEL As IntegerField
    Public MAX_BOOKS As IntegerField
    Public cbx_COURSE_B As TextField
    Public cbx_COURSE_BCheckedValue As TextField
    Public cbx_COURSE_BUncheckedValue As TextField
    Public cbx_COURSE_C As TextField
    Public cbx_COURSE_CCheckedValue As TextField
    Public cbx_COURSE_CUncheckedValue As TextField
    Public cbx_COURSE_E As TextField
    Public cbx_COURSE_ECheckedValue As TextField
    Public cbx_COURSE_EUncheckedValue As TextField
    Public cbx_COURSE_I As TextField
    Public cbx_COURSE_ICheckedValue As TextField
    Public cbx_COURSE_IUncheckedValue As TextField
    Public DESCRIPTION_LINE1 As TextField
    Public DESCRIPTION_LINE2 As TextField
    Public STATUS As BooleanField
    Public STATUSItems As ItemCollection
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public hidden_VALID_COURSE_DISTRIBUTION As TextField
    Public hidden_LAST_ALTERED_BY As TextField
    Public hidden_LAST_ALTERED_DATE As DateField
    Public SUBJECT_TITLE_NEW As TextField
    Public CAMPUS_CODE As TextField
    Public CAMPUS_CODEItems As ItemCollection
    Public CORE_YEARLEVELS As TextField
    Public CORE_YEARLEVELSItems As ItemCollection
    Public rbCORE_SUBJECT_FLAG As TextField
    Public rbCORE_SUBJECT_FLAGItems As ItemCollection
    Public LINKED_SUBJECT_ID As IntegerField
    Public checkEXTENDABLE_SUBJECT As IntegerField
    Public checkEXTENDABLE_SUBJECTCheckedValue As IntegerField
    Public checkEXTENDABLE_SUBJECTUncheckedValue As IntegerField
    Public ALLOCATE_STUDENTS_MAX As IntegerField
    Public listParentGroupSubject As IntegerField
    Public listParentGroupSubjectItems As ItemCollection
    Public Sub New()
    SUBJECT_ID = New IntegerField("", Nothing)
    SUBJECT_ABBREV = New TextField("", Nothing)
    SUBJECT_TITLE = New TextField("", Nothing)
    YEAR_LEVEL = New IntegerField("", Nothing)
    DEFAULT_SEMESTER = New TextField("", Nothing)
    DEFAULT_SEMESTERItems = New ItemCollection()
    DEFAULT_TEACHER_ID = New TextField("", Nothing)
    DEFAULT_TEACHER_IDItems = New ItemCollection()
    SUB_SCHOOL = New TextField("", Nothing)
    KLA_ID = New FloatField("", Nothing)
    KLA_IDItems = New ItemCollection()
    CSF_CLASS_LEVEL = New IntegerField("", Nothing)
    MAX_BOOKS = New IntegerField("", Nothing)
    cbx_COURSE_B = New TextField("", "")
    cbx_COURSE_BCheckedValue = New TextField("", "B")
    cbx_COURSE_BUncheckedValue = New TextField("", "")
    cbx_COURSE_C = New TextField("", "")
    cbx_COURSE_CCheckedValue = New TextField("", "C")
    cbx_COURSE_CUncheckedValue = New TextField("", "")
    cbx_COURSE_E = New TextField("", "")
    cbx_COURSE_ECheckedValue = New TextField("", "E")
    cbx_COURSE_EUncheckedValue = New TextField("", "")
    cbx_COURSE_I = New TextField("", "")
    cbx_COURSE_ICheckedValue = New TextField("", "I")
    cbx_COURSE_IUncheckedValue = New TextField("", "")
    DESCRIPTION_LINE1 = New TextField("", Nothing)
    DESCRIPTION_LINE2 = New TextField("", Nothing)
    STATUS = New BooleanField(Settings.BoolFormat, Nothing)
    STATUSItems = New ItemCollection()
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    hidden_VALID_COURSE_DISTRIBUTION = New TextField("", "")
    hidden_LAST_ALTERED_BY = New TextField("", DBUtility.UserId.ToUpper)
    hidden_LAST_ALTERED_DATE = New DateField("yyyy-MM-dd H\:mm", DateTime.Now)
    SUBJECT_TITLE_NEW = New TextField("", Nothing)
    CAMPUS_CODE = New TextField("", "D")
    CAMPUS_CODEItems = New ItemCollection()
    CORE_YEARLEVELS = New TextField("", Nothing)
    CORE_YEARLEVELSItems = New ItemCollection()
    rbCORE_SUBJECT_FLAG = New TextField("", 0)
    rbCORE_SUBJECT_FLAGItems = New ItemCollection()
    LINKED_SUBJECT_ID = New IntegerField("", 0)
    checkEXTENDABLE_SUBJECT = New IntegerField("", 0)
    checkEXTENDABLE_SUBJECTCheckedValue = New IntegerField("", 1)
    checkEXTENDABLE_SUBJECTUncheckedValue = New IntegerField("", 0)
    ALLOCATE_STUDENTS_MAX = New IntegerField("0;(0)", 0)
    listParentGroupSubject = New IntegerField("", 0)
    listParentGroupSubjectItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As NewRecord1Item
        Dim item As NewRecord1Item = New NewRecord1Item()
        If Not IsNothing(DBUtility.GetInitialValue("SUBJECT_ID")) Then
        item.SUBJECT_ID.SetValue(DBUtility.GetInitialValue("SUBJECT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUBJECT_ABBREV")) Then
        item.SUBJECT_ABBREV.SetValue(DBUtility.GetInitialValue("SUBJECT_ABBREV"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUBJECT_TITLE")) Then
        item.SUBJECT_TITLE.SetValue(DBUtility.GetInitialValue("SUBJECT_TITLE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("YEAR_LEVEL")) Then
        item.YEAR_LEVEL.SetValue(DBUtility.GetInitialValue("YEAR_LEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DEFAULT_SEMESTER")) Then
        item.DEFAULT_SEMESTER.SetValue(DBUtility.GetInitialValue("DEFAULT_SEMESTER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DEFAULT_TEACHER_ID")) Then
        item.DEFAULT_TEACHER_ID.SetValue(DBUtility.GetInitialValue("DEFAULT_TEACHER_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUB_SCHOOL")) Then
        item.SUB_SCHOOL.SetValue(DBUtility.GetInitialValue("SUB_SCHOOL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("KLA_ID")) Then
        item.KLA_ID.SetValue(DBUtility.GetInitialValue("KLA_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CSF_CLASS_LEVEL")) Then
        item.CSF_CLASS_LEVEL.SetValue(DBUtility.GetInitialValue("CSF_CLASS_LEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MAX_BOOKS")) Then
        item.MAX_BOOKS.SetValue(DBUtility.GetInitialValue("MAX_BOOKS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("cbx_COURSE_B")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("cbx_COURSE_B")) Then
            item.cbx_COURSE_B.Value = item.cbx_COURSE_BCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("cbx_COURSE_C")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("cbx_COURSE_C")) Then
            item.cbx_COURSE_C.Value = item.cbx_COURSE_CCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("cbx_COURSE_E")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("cbx_COURSE_E")) Then
            item.cbx_COURSE_E.Value = item.cbx_COURSE_ECheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("cbx_COURSE_I")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("cbx_COURSE_I")) Then
            item.cbx_COURSE_I.Value = item.cbx_COURSE_ICheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DESCRIPTION_LINE1")) Then
        item.DESCRIPTION_LINE1.SetValue(DBUtility.GetInitialValue("DESCRIPTION_LINE1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DESCRIPTION_LINE2")) Then
        item.DESCRIPTION_LINE2.SetValue(DBUtility.GetInitialValue("DESCRIPTION_LINE2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STATUS")) Then
        item.STATUS.SetValue(DBUtility.GetInitialValue("STATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_VALID_COURSE_DISTRIBUTION")) Then
        item.hidden_VALID_COURSE_DISTRIBUTION.SetValue(DBUtility.GetInitialValue("hidden_VALID_COURSE_DISTRIBUTION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY")) Then
        item.hidden_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_DATE")) Then
        item.hidden_LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUBJECT_TITLE_NEW")) Then
        item.SUBJECT_TITLE_NEW.SetValue(DBUtility.GetInitialValue("SUBJECT_TITLE_NEW"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CAMPUS_CODE")) Then
        item.CAMPUS_CODE.SetValue(DBUtility.GetInitialValue("CAMPUS_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CORE_YEARLEVELS")) Then
        item.CORE_YEARLEVELS.SetValue(DBUtility.GetInitialValue("CORE_YEARLEVELS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("rbCORE_SUBJECT_FLAG")) Then
        item.rbCORE_SUBJECT_FLAG.SetValue(DBUtility.GetInitialValue("rbCORE_SUBJECT_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LINKED_SUBJECT_ID")) Then
        item.LINKED_SUBJECT_ID.SetValue(DBUtility.GetInitialValue("LINKED_SUBJECT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("checkEXTENDABLE_SUBJECT")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("checkEXTENDABLE_SUBJECT")) Then
            item.checkEXTENDABLE_SUBJECT.Value = item.checkEXTENDABLE_SUBJECTCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ALLOCATE_STUDENTS_MAX")) Then
        item.ALLOCATE_STUDENTS_MAX.SetValue(DBUtility.GetInitialValue("ALLOCATE_STUDENTS_MAX"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("listParentGroupSubject")) Then
        item.listParentGroupSubject.SetValue(DBUtility.GetInitialValue("listParentGroupSubject"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "SUBJECT_ID"
                    Return SUBJECT_ID
                Case "SUBJECT_ABBREV"
                    Return SUBJECT_ABBREV
                Case "SUBJECT_TITLE"
                    Return SUBJECT_TITLE
                Case "YEAR_LEVEL"
                    Return YEAR_LEVEL
                Case "DEFAULT_SEMESTER"
                    Return DEFAULT_SEMESTER
                Case "DEFAULT_TEACHER_ID"
                    Return DEFAULT_TEACHER_ID
                Case "SUB_SCHOOL"
                    Return SUB_SCHOOL
                Case "KLA_ID"
                    Return KLA_ID
                Case "CSF_CLASS_LEVEL"
                    Return CSF_CLASS_LEVEL
                Case "MAX_BOOKS"
                    Return MAX_BOOKS
                Case "cbx_COURSE_B"
                    Return cbx_COURSE_B
                Case "cbx_COURSE_C"
                    Return cbx_COURSE_C
                Case "cbx_COURSE_E"
                    Return cbx_COURSE_E
                Case "cbx_COURSE_I"
                    Return cbx_COURSE_I
                Case "DESCRIPTION_LINE1"
                    Return DESCRIPTION_LINE1
                Case "DESCRIPTION_LINE2"
                    Return DESCRIPTION_LINE2
                Case "STATUS"
                    Return STATUS
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "hidden_VALID_COURSE_DISTRIBUTION"
                    Return hidden_VALID_COURSE_DISTRIBUTION
                Case "hidden_LAST_ALTERED_BY"
                    Return hidden_LAST_ALTERED_BY
                Case "hidden_LAST_ALTERED_DATE"
                    Return hidden_LAST_ALTERED_DATE
                Case "SUBJECT_TITLE_NEW"
                    Return SUBJECT_TITLE_NEW
                Case "CAMPUS_CODE"
                    Return CAMPUS_CODE
                Case "CORE_YEARLEVELS"
                    Return CORE_YEARLEVELS
                Case "rbCORE_SUBJECT_FLAG"
                    Return rbCORE_SUBJECT_FLAG
                Case "LINKED_SUBJECT_ID"
                    Return LINKED_SUBJECT_ID
                Case "checkEXTENDABLE_SUBJECT"
                    Return checkEXTENDABLE_SUBJECT
                Case "ALLOCATE_STUDENTS_MAX"
                    Return ALLOCATE_STUDENTS_MAX
                Case "listParentGroupSubject"
                    Return listParentGroupSubject
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SUBJECT_ID"
                    SUBJECT_ID = CType(value, IntegerField)
                Case "SUBJECT_ABBREV"
                    SUBJECT_ABBREV = CType(value, TextField)
                Case "SUBJECT_TITLE"
                    SUBJECT_TITLE = CType(value, TextField)
                Case "YEAR_LEVEL"
                    YEAR_LEVEL = CType(value, IntegerField)
                Case "DEFAULT_SEMESTER"
                    DEFAULT_SEMESTER = CType(value, TextField)
                Case "DEFAULT_TEACHER_ID"
                    DEFAULT_TEACHER_ID = CType(value, TextField)
                Case "SUB_SCHOOL"
                    SUB_SCHOOL = CType(value, TextField)
                Case "KLA_ID"
                    KLA_ID = CType(value, FloatField)
                Case "CSF_CLASS_LEVEL"
                    CSF_CLASS_LEVEL = CType(value, IntegerField)
                Case "MAX_BOOKS"
                    MAX_BOOKS = CType(value, IntegerField)
                Case "cbx_COURSE_B"
                    cbx_COURSE_B = CType(value, TextField)
                Case "cbx_COURSE_C"
                    cbx_COURSE_C = CType(value, TextField)
                Case "cbx_COURSE_E"
                    cbx_COURSE_E = CType(value, TextField)
                Case "cbx_COURSE_I"
                    cbx_COURSE_I = CType(value, TextField)
                Case "DESCRIPTION_LINE1"
                    DESCRIPTION_LINE1 = CType(value, TextField)
                Case "DESCRIPTION_LINE2"
                    DESCRIPTION_LINE2 = CType(value, TextField)
                Case "STATUS"
                    STATUS = CType(value, BooleanField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "hidden_VALID_COURSE_DISTRIBUTION"
                    hidden_VALID_COURSE_DISTRIBUTION = CType(value, TextField)
                Case "hidden_LAST_ALTERED_BY"
                    hidden_LAST_ALTERED_BY = CType(value, TextField)
                Case "hidden_LAST_ALTERED_DATE"
                    hidden_LAST_ALTERED_DATE = CType(value, DateField)
                Case "SUBJECT_TITLE_NEW"
                    SUBJECT_TITLE_NEW = CType(value, TextField)
                Case "CAMPUS_CODE"
                    CAMPUS_CODE = CType(value, TextField)
                Case "CORE_YEARLEVELS"
                    CORE_YEARLEVELS = CType(value, TextField)
                Case "rbCORE_SUBJECT_FLAG"
                    rbCORE_SUBJECT_FLAG = CType(value, TextField)
                Case "LINKED_SUBJECT_ID"
                    LINKED_SUBJECT_ID = CType(value, IntegerField)
                Case "checkEXTENDABLE_SUBJECT"
                    checkEXTENDABLE_SUBJECT = CType(value, IntegerField)
                Case "ALLOCATE_STUDENTS_MAX"
                    ALLOCATE_STUDENTS_MAX = CType(value, IntegerField)
                Case "listParentGroupSubject"
                    listParentGroupSubject = CType(value, IntegerField)
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

    Public Sub Validate(ByVal provider As NewRecord1DataProvider)
'End Record NewRecord1 Item Class

'SUBJECT_ID validate @34-60379B03
        If IsNothing(SUBJECT_ID.Value) OrElse SUBJECT_ID.Value.ToString() ="" Then
            errors.Add("SUBJECT_ID",String.Format(Resources.strings.CCS_RequiredField,"SUBJECT ID"))
        End If
        If (Not IsNothing(SUBJECT_ID)) And (Not provider.CheckUnique("SUBJECT_ID",Me)) Then
                errors.Add("SUBJECT_ID", String.Format(Resources.strings.CCS_UniqueValue,"SUBJECT ID"))
        End If
'End SUBJECT_ID validate

'SUBJECT_ABBREV validate @35-EA96B3D5
        If IsNothing(SUBJECT_ABBREV.Value) OrElse SUBJECT_ABBREV.Value.ToString() ="" Then
            errors.Add("SUBJECT_ABBREV",String.Format(Resources.strings.CCS_RequiredField,"SUBJECT ABBREV"))
        End If
'End SUBJECT_ABBREV validate

'SUBJECT_TITLE validate @36-CB3907FA
        If IsNothing(SUBJECT_TITLE.Value) OrElse SUBJECT_TITLE.Value.ToString() ="" Then
            errors.Add("SUBJECT_TITLE",String.Format(Resources.strings.CCS_RequiredField,"SUBJECT TITLE"))
        End If
'End SUBJECT_TITLE validate

'YEAR_LEVEL validate @39-30512612
        If IsNothing(YEAR_LEVEL.Value) OrElse YEAR_LEVEL.Value.ToString() ="" Then
            errors.Add("YEAR_LEVEL",String.Format(Resources.strings.CCS_RequiredField,"YEAR LEVEL"))
        End If
'End YEAR_LEVEL validate

'DEFAULT_SEMESTER validate @40-2A647C58
        If IsNothing(DEFAULT_SEMESTER.Value) OrElse DEFAULT_SEMESTER.Value.ToString() ="" Then
            errors.Add("DEFAULT_SEMESTER",String.Format(Resources.strings.CCS_RequiredField,"DEFAULT SEMESTER"))
        End If
'End DEFAULT_SEMESTER validate

'DEFAULT_TEACHER_ID validate @38-ED271BDB
        If IsNothing(DEFAULT_TEACHER_ID.Value) OrElse DEFAULT_TEACHER_ID.Value.ToString() ="" Then
            errors.Add("DEFAULT_TEACHER_ID",String.Format(Resources.strings.CCS_RequiredField,"DEFAULT TEACHER ID"))
        End If
'End DEFAULT_TEACHER_ID validate

'KLA_ID validate @42-FC575AA4
        If IsNothing(KLA_ID.Value) OrElse KLA_ID.Value.ToString() ="" Then
            errors.Add("KLA_ID",String.Format(Resources.strings.CCS_RequiredField,"KLA ID"))
        End If
'End KLA_ID validate

'MAX_BOOKS validate @44-CC7DE464
        If IsNothing(MAX_BOOKS.Value) OrElse MAX_BOOKS.Value.ToString() ="" Then
            errors.Add("MAX_BOOKS",String.Format(Resources.strings.CCS_RequiredField,"MAX BOOKS"))
        End If
'End MAX_BOOKS validate

'STATUS validate @48-73C7378E
        If IsNothing(STATUS.Value) OrElse STATUS.Value.ToString() ="" Then
            errors.Add("STATUS",String.Format(Resources.strings.CCS_RequiredField,"STATUS"))
        End If
'End STATUS validate

'CAMPUS_CODE validate @37-E6F21D52
        If IsNothing(CAMPUS_CODE.Value) OrElse CAMPUS_CODE.Value.ToString() ="" Then
            errors.Add("CAMPUS_CODE",String.Format(Resources.strings.CCS_RequiredField,"CAMPUS CODE"))
        End If
'End CAMPUS_CODE validate

'ALLOCATE_STUDENTS_MAX validate @166-A8931725
        If IsNothing(ALLOCATE_STUDENTS_MAX.Value) OrElse ALLOCATE_STUDENTS_MAX.Value.ToString() ="" Then
            errors.Add("ALLOCATE_STUDENTS_MAX",String.Format(Resources.strings.CCS_RequiredField,"MAX STUDENT_ALLOCATION"))
        End If
'End ALLOCATE_STUDENTS_MAX validate

'listParentGroupSubject validate @173-5AD81362
        If IsNothing(listParentGroupSubject.Value) OrElse listParentGroupSubject.Value.ToString() ="" Then
            errors.Add("listParentGroupSubject",String.Format(Resources.strings.CCS_RequiredField,"Parent / Full Year Grouping"))
        End If
'End listParentGroupSubject validate

'Record NewRecord1 Item Class tail @29-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record NewRecord1 Item Class tail

'Record NewRecord1 Data Provider Class @29-BF438C52
Public Class NewRecord1DataProvider
Inherits RecordDataProviderBase
'End Record NewRecord1 Data Provider Class

'Record NewRecord1 Data Provider Class Variables @29-5369A867
    Protected DEFAULT_TEACHER_IDDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM View_StaffList_Active_Inactive {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected KLA_IDDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM KEY_LEARNING_AREA {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected listParentGroupSubjectDataCommand As DataCommand=new SqlCommand("SELECT '-1' as SUBJECT_ID, '- This is a Parent Group Subject -' as display_text" & vbCrLf & _
          "	union" & vbCrLf & _
          "SELECT SUBJECT_ID, rtrim(SUBJECT_ABBREV) + ' - ' + rtrim(SUBJECT_TITLE) as display_text" & vbCrLf & _
          "FROM SUBJECT " & vbCrLf & _
          "where status=1" & vbCrLf & _
          "and parent_subject_id = -1" & vbCrLf & _
          "and year_level between 7 and 10",Settings.connDECVPRODSQL2005DataAccessObject)
    Public Expr68 As TextParameter
    Public Expr69 As DateParameter
    Public UrlSUBJECT_ID As IntegerParameter
    Public CtrlSUBJECT_ID As IntegerParameter
    Public CtrlSUBJECT_ABBREV As TextParameter
    Public CtrlSUBJECT_TITLE As TextParameter
    Public CtrlCAMPUS_CODE As TextParameter
    Public CtrlYEAR_LEVEL As IntegerParameter
    Public CtrlDEFAULT_SEMESTER As TextParameter
    Public CtrlDEFAULT_TEACHER_ID As TextParameter
    Public CtrlSUB_SCHOOL As TextParameter
    Public CtrlKLA_ID As FloatParameter
    Public CtrlCSF_CLASS_LEVEL As IntegerParameter
    Public CtrlMAX_BOOKS As IntegerParameter
    Public CtrlDESCRIPTION_LINE1 As TextParameter
    Public CtrlDESCRIPTION_LINE2 As TextParameter
    Public CtrlSTATUS As BooleanParameter
    Public Expr86 As TextParameter
    Public Expr87 As DateParameter
    Public Ctrlhidden_VALID_COURSE_DISTRIBUTION As TextParameter
    Public CtrlSUBJECT_TITLE_NEW As TextParameter
    Public CtrlCORE_YEARLEVELS As TextParameter
    Public CtrlrbCORE_SUBJECT_FLAG As IntegerParameter
    Public CtrlLINKED_SUBJECT_ID As IntegerParameter
    Public CtrlcheckEXTENDABLE_SUBJECT As IntegerParameter
    Public CtrlALLOCATE_STUDENTS_MAX As IntegerParameter
    Public CtrllistParentGroupSubject As IntegerParameter
    Protected item As NewRecord1Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record NewRecord1 Data Provider Class Variables

'Record NewRecord1 Data Provider Class Constructor @29-1F37772D

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM SUBJECT {SQL_Where} {SQL_OrderBy}", New String(){"SUBJECT_ID168"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record NewRecord1 Data Provider Class Constructor

'Record NewRecord1 Data Provider Class LoadParams Method @29-760FD411

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSUBJECT_ID))
    End Function
'End Record NewRecord1 Data Provider Class LoadParams Method

'Record NewRecord1 Data Provider Class CheckUnique Method @29-BDB011A8

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As NewRecord1Item) As Boolean
        Dim Check As TableCommand = New TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM SUBJECT",New String(){"SUBJECT_ID168"},Settings.connDECVPRODSQL2005DataAccessObject)
        Dim CheckWhere As String = ""
        Select Case ControlName
        Case "SUBJECT_ID"
            CheckWhere = "SUBJECT_ID=" & Check.Dao.ToSql(item.SUBJECT_ID.GetFormattedValue(""),FieldType._Integer)
        End Select
        Check.Where = CheckWhere
        Check.Operation = "AND NOT"
        Check.Parameters.Clear()
        CType(Check,TableCommand).AddParameter("SUBJECT_ID168",UrlSUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        If Convert.ToInt32(Check.ExecuteScalar()) > 0 Then
            Return False
        End If
        Return True
    End Function
'End Record NewRecord1 Data Provider Class CheckUnique Method

'Record NewRecord1 Data Provider Class PrepareInsert Method @29-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record NewRecord1 Data Provider Class PrepareInsert Method

'Record NewRecord1 Data Provider Class PrepareInsert Method tail @29-E31F8E2A
    End Sub
'End Record NewRecord1 Data Provider Class PrepareInsert Method tail

'Record NewRecord1 Data Provider Class Insert Method @29-04B15620

    Public Function InsertItem(ByVal item As NewRecord1Item) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO SUBJECT({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record NewRecord1 Data Provider Class Insert Method

'Record NewRecord1 Event BeforeBuildInsert. Action Custom Code @94-73254650
    ' -------------------------
     'ERA: 23 June 2008 - re-combine the VALID_COURSE_DISTRIBUTION checkboxes into a single field
	item.hidden_valid_course_distribution.value=item.cbx_course_b.value & item.cbx_course_c.value & item.cbx_course_e.value & item.cbx_course_i.value & ""

            ' -------------------------
'End Record NewRecord1 Event BeforeBuildInsert. Action Custom Code

'Record NewRecord1 Build insert @29-A3450719
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        allEmptyFlag = item.SUBJECT_ID.IsEmpty And allEmptyFlag
        If Not item.SUBJECT_ID.IsEmpty Then
        If IsNothing(item.SUBJECT_ID.Value) Then
        fieldsList = fieldsList & "SUBJECT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        fieldsList = fieldsList & "SUBJECT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUBJECT_ID.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.SUBJECT_ABBREV.IsEmpty And allEmptyFlag
        If Not item.SUBJECT_ABBREV.IsEmpty Then
        If IsNothing(item.SUBJECT_ABBREV.Value) Then
        fieldsList = fieldsList & "SUBJECT_ABBREV,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "SUBJECT_ABBREV,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUBJECT_ABBREV.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.SUBJECT_TITLE.IsEmpty And allEmptyFlag
        If Not item.SUBJECT_TITLE.IsEmpty Then
        If IsNothing(item.SUBJECT_TITLE.Value) Then
        fieldsList = fieldsList & "SUBJECT_TITLE,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "SUBJECT_TITLE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUBJECT_TITLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.CAMPUS_CODE.IsEmpty And allEmptyFlag
        If Not item.CAMPUS_CODE.IsEmpty Then
        If IsNothing(item.CAMPUS_CODE.Value) Then
        fieldsList = fieldsList & "CAMPUS_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "CAMPUS_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CAMPUS_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.YEAR_LEVEL.IsEmpty And allEmptyFlag
        If Not item.YEAR_LEVEL.IsEmpty Then
        If IsNothing(item.YEAR_LEVEL.Value) Then
        fieldsList = fieldsList & "YEAR_LEVEL,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        fieldsList = fieldsList & "YEAR_LEVEL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.DEFAULT_SEMESTER.IsEmpty And allEmptyFlag
        If Not item.DEFAULT_SEMESTER.IsEmpty Then
        If IsNothing(item.DEFAULT_SEMESTER.Value) Then
        fieldsList = fieldsList & "DEFAULT_SEMESTER,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "DEFAULT_SEMESTER,"
        valuesList = valuesList & Insert.Dao.ToSql(item.DEFAULT_SEMESTER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.DEFAULT_TEACHER_ID.IsEmpty And allEmptyFlag
        If Not item.DEFAULT_TEACHER_ID.IsEmpty Then
        If IsNothing(item.DEFAULT_TEACHER_ID.Value) Then
        fieldsList = fieldsList & "DEFAULT_TEACHER_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "DEFAULT_TEACHER_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.DEFAULT_TEACHER_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.SUB_SCHOOL.IsEmpty And allEmptyFlag
        If Not item.SUB_SCHOOL.IsEmpty Then
        If IsNothing(item.SUB_SCHOOL.Value) Then
        fieldsList = fieldsList & "SUB_SCHOOL,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "SUB_SCHOOL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUB_SCHOOL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.KLA_ID.IsEmpty And allEmptyFlag
        If Not item.KLA_ID.IsEmpty Then
        If IsNothing(item.KLA_ID.Value) Then
        fieldsList = fieldsList & "KLA_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Float) & ","
        Else
        fieldsList = fieldsList & "KLA_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.KLA_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        End If
        allEmptyFlag = item.CSF_CLASS_LEVEL.IsEmpty And allEmptyFlag
        If Not item.CSF_CLASS_LEVEL.IsEmpty Then
        If IsNothing(item.CSF_CLASS_LEVEL.Value) Then
        fieldsList = fieldsList & "CSF_CLASS_LEVEL,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        fieldsList = fieldsList & "CSF_CLASS_LEVEL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CSF_CLASS_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.MAX_BOOKS.IsEmpty And allEmptyFlag
        If Not item.MAX_BOOKS.IsEmpty Then
        If IsNothing(item.MAX_BOOKS.Value) Then
        fieldsList = fieldsList & "MAX_BOOKS,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        fieldsList = fieldsList & "MAX_BOOKS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.MAX_BOOKS.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.DESCRIPTION_LINE1.IsEmpty And allEmptyFlag
        If Not item.DESCRIPTION_LINE1.IsEmpty Then
        If IsNothing(item.DESCRIPTION_LINE1.Value) Then
        fieldsList = fieldsList & "DESCRIPTION_LINE1,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "DESCRIPTION_LINE1,"
        valuesList = valuesList & Insert.Dao.ToSql(item.DESCRIPTION_LINE1.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.DESCRIPTION_LINE2.IsEmpty And allEmptyFlag
        If Not item.DESCRIPTION_LINE2.IsEmpty Then
        If IsNothing(item.DESCRIPTION_LINE2.Value) Then
        fieldsList = fieldsList & "DESCRIPTION_LINE2,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "DESCRIPTION_LINE2,"
        valuesList = valuesList & Insert.Dao.ToSql(item.DESCRIPTION_LINE2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        If Not item.STATUS.IsEmpty Then
        If IsNothing(item.STATUS.Value) Then
        fieldsList = fieldsList & "STATUS,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Boolean) & ","
        Else
        fieldsList = fieldsList & "STATUS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STATUS.GetFormattedValue(Insert.BoolFormat),FieldType._Boolean) & ","
        End If
        End If
        allEmptyFlag = (Expr68 Is Nothing) And allEmptyFlag
        If Not (Expr68 Is Nothing) Then
        If IsNothing(Expr68) Then
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(("unknown").ToString(),FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr68.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = (Expr69 Is Nothing) And allEmptyFlag
        If Not (Expr69 Is Nothing) Then
        If IsNothing(Expr69) Then
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr69.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        End If
        allEmptyFlag = item.hidden_VALID_COURSE_DISTRIBUTION.IsEmpty And allEmptyFlag
        If Not item.hidden_VALID_COURSE_DISTRIBUTION.IsEmpty Then
        If IsNothing(item.hidden_VALID_COURSE_DISTRIBUTION.Value) Then
        fieldsList = fieldsList & "VALID_COURSE_DISTRIBUTION,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "VALID_COURSE_DISTRIBUTION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.hidden_VALID_COURSE_DISTRIBUTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.SUBJECT_TITLE_NEW.IsEmpty And allEmptyFlag
        If Not item.SUBJECT_TITLE_NEW.IsEmpty Then
        If IsNothing(item.SUBJECT_TITLE_NEW.Value) Then
        fieldsList = fieldsList & "SUBJECT_TITLE_NEW,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "SUBJECT_TITLE_NEW,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUBJECT_TITLE_NEW.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.CORE_YEARLEVELS.IsEmpty And allEmptyFlag
        If Not item.CORE_YEARLEVELS.IsEmpty Then
        If IsNothing(item.CORE_YEARLEVELS.Value) Then
        fieldsList = fieldsList & "CORE_YEARLEVELS,"
        valuesList = valuesList & Insert.Dao.ToSql(("").ToString(),FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "CORE_YEARLEVELS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CORE_YEARLEVELS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.rbCORE_SUBJECT_FLAG.IsEmpty And allEmptyFlag
        If Not item.rbCORE_SUBJECT_FLAG.IsEmpty Then
        If IsNothing(item.rbCORE_SUBJECT_FLAG.Value) Then
        fieldsList = fieldsList & "CORE_SUBJECT_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql((0).ToString(),FieldType._Integer) & ","
        Else
        fieldsList = fieldsList & "CORE_SUBJECT_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.rbCORE_SUBJECT_FLAG.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.LINKED_SUBJECT_ID.IsEmpty And allEmptyFlag
        If Not item.LINKED_SUBJECT_ID.IsEmpty Then
        If IsNothing(item.LINKED_SUBJECT_ID.Value) Then
        fieldsList = fieldsList & "LINKED_SUBJECT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql((0).ToString(),FieldType._Integer) & ","
        Else
        fieldsList = fieldsList & "LINKED_SUBJECT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LINKED_SUBJECT_ID.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.checkEXTENDABLE_SUBJECT.IsEmpty And allEmptyFlag
        If Not item.checkEXTENDABLE_SUBJECT.IsEmpty Then
        If IsNothing(item.checkEXTENDABLE_SUBJECT.Value) Then
        fieldsList = fieldsList & "EXTENDABLE_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql((0).ToString(),FieldType._Integer) & ","
        Else
        fieldsList = fieldsList & "EXTENDABLE_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.checkEXTENDABLE_SUBJECT.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.ALLOCATE_STUDENTS_MAX.IsEmpty And allEmptyFlag
        If Not item.ALLOCATE_STUDENTS_MAX.IsEmpty Then
        If IsNothing(item.ALLOCATE_STUDENTS_MAX.Value) Then
        fieldsList = fieldsList & "ALLOCATE_STUDENTS_MAX,"
        valuesList = valuesList & Insert.Dao.ToSql((0).ToString(),FieldType._Integer) & ","
        Else
        fieldsList = fieldsList & "ALLOCATE_STUDENTS_MAX,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ALLOCATE_STUDENTS_MAX.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.listParentGroupSubject.IsEmpty And allEmptyFlag
        If Not item.listParentGroupSubject.IsEmpty Then
        If IsNothing(item.listParentGroupSubject.Value) Then
        fieldsList = fieldsList & "PARENT_SUBJECT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql((0).ToString(),FieldType._Integer) & ","
        Else
        fieldsList = fieldsList & "PARENT_SUBJECT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.listParentGroupSubject.GetFormattedValue(""),FieldType._Integer) & ","
        End If
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
'End Record NewRecord1 Build insert

'Record NewRecord1 AfterExecuteInsert @29-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record NewRecord1 AfterExecuteInsert

'Record NewRecord1 Data Provider Class PrepareUpdate Method @29-1723BE5E

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = Not(IsNothing(UrlSUBJECT_ID))
'End Record NewRecord1 Data Provider Class PrepareUpdate Method

'Record NewRecord1 Data Provider Class PrepareUpdate Method tail @29-E31F8E2A
    End Sub
'End Record NewRecord1 Data Provider Class PrepareUpdate Method tail

'Record NewRecord1 Data Provider Class Update Method @29-0F135CE9

    Public Function UpdateItem(ByVal item As NewRecord1Item) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE SUBJECT SET {Values}", New String(){"SUBJECT_ID71"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record NewRecord1 Data Provider Class Update Method

'Record NewRecord1 Event BeforeBuildUpdate. Action Custom Code @95-73254650
    ' -------------------------
   'ERA: 23 June 2008 - re-combine the VALID_COURSE_DISTRIBUTION checkboxes into a single field
	item.hidden_valid_course_distribution.value=item.cbx_course_b.value & item.cbx_course_c.value & item.cbx_course_e.value & item.cbx_course_i.value & ""
    ' -------------------------
'End Record NewRecord1 Event BeforeBuildUpdate. Action Custom Code

'Record NewRecord1 BeforeBuildUpdate @29-D30AFCEC
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("SUBJECT_ID71",UrlSUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        allEmptyFlag = item.SUBJECT_ID.IsEmpty And allEmptyFlag
        If Not item.SUBJECT_ID.IsEmpty Then
        If IsNothing(item.SUBJECT_ID.Value) Then
        valuesList = valuesList & "SUBJECT_ID=" & Update.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        valuesList = valuesList & "SUBJECT_ID=" & Update.Dao.ToSql(item.SUBJECT_ID.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.SUBJECT_ABBREV.IsEmpty And allEmptyFlag
        If Not item.SUBJECT_ABBREV.IsEmpty Then
        If IsNothing(item.SUBJECT_ABBREV.Value) Then
        valuesList = valuesList & "SUBJECT_ABBREV=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "SUBJECT_ABBREV=" & Update.Dao.ToSql(item.SUBJECT_ABBREV.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.SUBJECT_TITLE.IsEmpty And allEmptyFlag
        If Not item.SUBJECT_TITLE.IsEmpty Then
        If IsNothing(item.SUBJECT_TITLE.Value) Then
        valuesList = valuesList & "SUBJECT_TITLE=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "SUBJECT_TITLE=" & Update.Dao.ToSql(item.SUBJECT_TITLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.CAMPUS_CODE.IsEmpty And allEmptyFlag
        If Not item.CAMPUS_CODE.IsEmpty Then
        If IsNothing(item.CAMPUS_CODE.Value) Then
        valuesList = valuesList & "CAMPUS_CODE=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "CAMPUS_CODE=" & Update.Dao.ToSql(item.CAMPUS_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.YEAR_LEVEL.IsEmpty And allEmptyFlag
        If Not item.YEAR_LEVEL.IsEmpty Then
        If IsNothing(item.YEAR_LEVEL.Value) Then
        valuesList = valuesList & "YEAR_LEVEL=" & Update.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        valuesList = valuesList & "YEAR_LEVEL=" & Update.Dao.ToSql(item.YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.DEFAULT_SEMESTER.IsEmpty And allEmptyFlag
        If Not item.DEFAULT_SEMESTER.IsEmpty Then
        If IsNothing(item.DEFAULT_SEMESTER.Value) Then
        valuesList = valuesList & "DEFAULT_SEMESTER=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "DEFAULT_SEMESTER=" & Update.Dao.ToSql(item.DEFAULT_SEMESTER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.DEFAULT_TEACHER_ID.IsEmpty And allEmptyFlag
        If Not item.DEFAULT_TEACHER_ID.IsEmpty Then
        If IsNothing(item.DEFAULT_TEACHER_ID.Value) Then
        valuesList = valuesList & "DEFAULT_TEACHER_ID=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "DEFAULT_TEACHER_ID=" & Update.Dao.ToSql(item.DEFAULT_TEACHER_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.SUB_SCHOOL.IsEmpty And allEmptyFlag
        If Not item.SUB_SCHOOL.IsEmpty Then
        If IsNothing(item.SUB_SCHOOL.Value) Then
        valuesList = valuesList & "SUB_SCHOOL=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "SUB_SCHOOL=" & Update.Dao.ToSql(item.SUB_SCHOOL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.KLA_ID.IsEmpty And allEmptyFlag
        If Not item.KLA_ID.IsEmpty Then
        If IsNothing(item.KLA_ID.Value) Then
        valuesList = valuesList & "KLA_ID=" & Update.Dao.ToSql(Nothing,FieldType._Float) & ","
        Else
        valuesList = valuesList & "KLA_ID=" & Update.Dao.ToSql(item.KLA_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        End If
        allEmptyFlag = item.CSF_CLASS_LEVEL.IsEmpty And allEmptyFlag
        If Not item.CSF_CLASS_LEVEL.IsEmpty Then
        If IsNothing(item.CSF_CLASS_LEVEL.Value) Then
        valuesList = valuesList & "CSF_CLASS_LEVEL=" & Update.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        valuesList = valuesList & "CSF_CLASS_LEVEL=" & Update.Dao.ToSql(item.CSF_CLASS_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.MAX_BOOKS.IsEmpty And allEmptyFlag
        If Not item.MAX_BOOKS.IsEmpty Then
        If IsNothing(item.MAX_BOOKS.Value) Then
        valuesList = valuesList & "MAX_BOOKS=" & Update.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        valuesList = valuesList & "MAX_BOOKS=" & Update.Dao.ToSql(item.MAX_BOOKS.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.DESCRIPTION_LINE1.IsEmpty And allEmptyFlag
        If Not item.DESCRIPTION_LINE1.IsEmpty Then
        If IsNothing(item.DESCRIPTION_LINE1.Value) Then
        valuesList = valuesList & "DESCRIPTION_LINE1=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "DESCRIPTION_LINE1=" & Update.Dao.ToSql(item.DESCRIPTION_LINE1.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.DESCRIPTION_LINE2.IsEmpty And allEmptyFlag
        If Not item.DESCRIPTION_LINE2.IsEmpty Then
        If IsNothing(item.DESCRIPTION_LINE2.Value) Then
        valuesList = valuesList & "DESCRIPTION_LINE2=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "DESCRIPTION_LINE2=" & Update.Dao.ToSql(item.DESCRIPTION_LINE2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        If Not item.STATUS.IsEmpty Then
        If IsNothing(item.STATUS.Value) Then
        valuesList = valuesList & "STATUS=" & Update.Dao.ToSql(Nothing,FieldType._Boolean) & ","
        Else
        valuesList = valuesList & "STATUS=" & Update.Dao.ToSql(item.STATUS.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        End If
        allEmptyFlag = (Expr86 Is Nothing) And allEmptyFlag
        If Not (Expr86 Is Nothing) Then
        If IsNothing(Expr86) Then
        valuesList = valuesList & "LAST_ALTERED_BY=" & Update.Dao.ToSql(("unknown").ToString(),FieldType._Text) & ","
        Else
        valuesList = valuesList & "LAST_ALTERED_BY=" & Update.Dao.ToSql(Expr86.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = (Expr87 Is Nothing) And allEmptyFlag
        If Not (Expr87 Is Nothing) Then
        If IsNothing(Expr87) Then
        valuesList = valuesList & "LAST_ALTERED_DATE=" & Update.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        valuesList = valuesList & "LAST_ALTERED_DATE=" & Update.Dao.ToSql(Expr87.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        End If
        allEmptyFlag = item.hidden_VALID_COURSE_DISTRIBUTION.IsEmpty And allEmptyFlag
        If Not item.hidden_VALID_COURSE_DISTRIBUTION.IsEmpty Then
        If IsNothing(item.hidden_VALID_COURSE_DISTRIBUTION.Value) Then
        valuesList = valuesList & "VALID_COURSE_DISTRIBUTION=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "VALID_COURSE_DISTRIBUTION=" & Update.Dao.ToSql(item.hidden_VALID_COURSE_DISTRIBUTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.SUBJECT_TITLE_NEW.IsEmpty And allEmptyFlag
        If Not item.SUBJECT_TITLE_NEW.IsEmpty Then
        If IsNothing(item.SUBJECT_TITLE_NEW.Value) Then
        valuesList = valuesList & "SUBJECT_TITLE_NEW=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "SUBJECT_TITLE_NEW=" & Update.Dao.ToSql(item.SUBJECT_TITLE_NEW.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.CORE_YEARLEVELS.IsEmpty And allEmptyFlag
        If Not item.CORE_YEARLEVELS.IsEmpty Then
        If IsNothing(item.CORE_YEARLEVELS.Value) Then
        valuesList = valuesList & "CORE_YEARLEVELS=" & Update.Dao.ToSql(("").ToString(),FieldType._Text) & ","
        Else
        valuesList = valuesList & "CORE_YEARLEVELS=" & Update.Dao.ToSql(item.CORE_YEARLEVELS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.rbCORE_SUBJECT_FLAG.IsEmpty And allEmptyFlag
        If Not item.rbCORE_SUBJECT_FLAG.IsEmpty Then
        If IsNothing(item.rbCORE_SUBJECT_FLAG.Value) Then
        valuesList = valuesList & "CORE_SUBJECT_FLAG=" & Update.Dao.ToSql((0).ToString(),FieldType._Integer) & ","
        Else
        valuesList = valuesList & "CORE_SUBJECT_FLAG=" & Update.Dao.ToSql(item.rbCORE_SUBJECT_FLAG.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.LINKED_SUBJECT_ID.IsEmpty And allEmptyFlag
        If Not item.LINKED_SUBJECT_ID.IsEmpty Then
        If IsNothing(item.LINKED_SUBJECT_ID.Value) Then
        valuesList = valuesList & "LINKED_SUBJECT_ID=" & Update.Dao.ToSql((0).ToString(),FieldType._Integer) & ","
        Else
        valuesList = valuesList & "LINKED_SUBJECT_ID=" & Update.Dao.ToSql(item.LINKED_SUBJECT_ID.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.checkEXTENDABLE_SUBJECT.IsEmpty And allEmptyFlag
        If Not item.checkEXTENDABLE_SUBJECT.IsEmpty Then
        If IsNothing(item.checkEXTENDABLE_SUBJECT.Value) Then
        valuesList = valuesList & "EXTENDABLE_FLAG=" & Update.Dao.ToSql((0).ToString(),FieldType._Integer) & ","
        Else
        valuesList = valuesList & "EXTENDABLE_FLAG=" & Update.Dao.ToSql(item.checkEXTENDABLE_SUBJECT.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.ALLOCATE_STUDENTS_MAX.IsEmpty And allEmptyFlag
        If Not item.ALLOCATE_STUDENTS_MAX.IsEmpty Then
        If IsNothing(item.ALLOCATE_STUDENTS_MAX.Value) Then
        valuesList = valuesList & "ALLOCATE_STUDENTS_MAX=" & Update.Dao.ToSql((0).ToString(),FieldType._Integer) & ","
        Else
        valuesList = valuesList & "ALLOCATE_STUDENTS_MAX=" & Update.Dao.ToSql(item.ALLOCATE_STUDENTS_MAX.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.listParentGroupSubject.IsEmpty And allEmptyFlag
        If Not item.listParentGroupSubject.IsEmpty Then
        If IsNothing(item.listParentGroupSubject.Value) Then
        valuesList = valuesList & "PARENT_SUBJECT_ID=" & Update.Dao.ToSql((0).ToString(),FieldType._Integer) & ","
        Else
        valuesList = valuesList & "PARENT_SUBJECT_ID=" & Update.Dao.ToSql(item.listParentGroupSubject.GetFormattedValue(""),FieldType._Integer) & ","
        End If
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
'End Record NewRecord1 BeforeBuildUpdate

'Record NewRecord1 AfterExecuteUpdate @29-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record NewRecord1 AfterExecuteUpdate

'Record NewRecord1 Data Provider Class GetResultSet Method @29-A9FE94D9

    Public Sub FillItem(ByVal item As NewRecord1Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record NewRecord1 Data Provider Class GetResultSet Method

'Record NewRecord1 BeforeBuildSelect @29-BC3DEA5F
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("SUBJECT_ID168",UrlSUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record NewRecord1 BeforeBuildSelect

'Record NewRecord1 BeforeExecuteSelect @29-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record NewRecord1 BeforeExecuteSelect

'Record NewRecord1 AfterExecuteSelect @29-FB337EC0
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
            item.SUBJECT_ABBREV.SetValue(dr(i)("SUBJECT_ABBREV"),"")
            item.SUBJECT_TITLE.SetValue(dr(i)("SUBJECT_TITLE"),"")
            item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
            item.DEFAULT_SEMESTER.SetValue(dr(i)("DEFAULT_SEMESTER"),"")
            item.DEFAULT_TEACHER_ID.SetValue(dr(i)("DEFAULT_TEACHER_ID"),"")
            item.SUB_SCHOOL.SetValue(dr(i)("SUB_SCHOOL"),"")
            item.KLA_ID.SetValue(dr(i)("KLA_ID"),"")
            item.CSF_CLASS_LEVEL.SetValue(dr(i)("CSF_CLASS_LEVEL"),"")
            item.MAX_BOOKS.SetValue(dr(i)("MAX_BOOKS"),"")
            item.DESCRIPTION_LINE1.SetValue(dr(i)("DESCRIPTION_LINE1"),"")
            item.DESCRIPTION_LINE2.SetValue(dr(i)("DESCRIPTION_LINE2"),"")
            item.STATUS.SetValue(dr(i)("STATUS"),Select_.BoolFormat)
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.hidden_VALID_COURSE_DISTRIBUTION.SetValue(dr(i)("VALID_COURSE_DISTRIBUTION"),"")
            item.hidden_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.hidden_LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.SUBJECT_TITLE_NEW.SetValue(dr(i)("SUBJECT_TITLE_NEW"),"")
            item.CAMPUS_CODE.SetValue(dr(i)("CAMPUS_CODE"),"")
            item.CORE_YEARLEVELS.SetValue(dr(i)("CORE_YEARLEVELS"),"")
            item.rbCORE_SUBJECT_FLAG.SetValue(dr(i)("CORE_SUBJECT_FLAG"),"")
            item.LINKED_SUBJECT_ID.SetValue(dr(i)("LINKED_SUBJECT_ID"),"")
            item.checkEXTENDABLE_SUBJECT.SetValue(dr(i)("EXTENDABLE_FLAG"),"")
            item.ALLOCATE_STUDENTS_MAX.SetValue(dr(i)("ALLOCATE_STUDENTS_MAX"),"")
            item.listParentGroupSubject.SetValue(dr(i)("PARENT_SUBJECT_ID"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record NewRecord1 AfterExecuteSelect

'ListBox DEFAULT_SEMESTER AfterExecuteSelect @40-FE3AA611
        
item.DEFAULT_SEMESTERItems.Add("1","1")
item.DEFAULT_SEMESTERItems.Add("2","2")
item.DEFAULT_SEMESTERItems.Add("B","B")
'End ListBox DEFAULT_SEMESTER AfterExecuteSelect

'ListBox DEFAULT_TEACHER_ID Initialize Data Source @38-C4B47497
        DEFAULT_TEACHER_IDDataCommand.Dao._optimized = False
        Dim DEFAULT_TEACHER_IDtableIndex As Integer = 0
        DEFAULT_TEACHER_IDDataCommand.OrderBy = "status_type, staff_ID"
        DEFAULT_TEACHER_IDDataCommand.Parameters.Clear()
'End ListBox DEFAULT_TEACHER_ID Initialize Data Source

'ListBox DEFAULT_TEACHER_ID BeforeExecuteSelect @38-4A747ED8
        Try
            ListBoxSource=DEFAULT_TEACHER_IDDataCommand.Execute().Tables(DEFAULT_TEACHER_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox DEFAULT_TEACHER_ID BeforeExecuteSelect

'ListBox DEFAULT_TEACHER_ID AfterExecuteSelect @38-F3E2C8E2
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("staff_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("staffname")
            item.DEFAULT_TEACHER_IDItems.Add(Key, Val)
        Next
'End ListBox DEFAULT_TEACHER_ID AfterExecuteSelect

'ListBox KLA_ID Initialize Data Source @42-5840DC2C
        KLA_IDDataCommand.Dao._optimized = False
        Dim KLA_IDtableIndex As Integer = 0
        KLA_IDDataCommand.OrderBy = ""
        KLA_IDDataCommand.Parameters.Clear()
'End ListBox KLA_ID Initialize Data Source

'ListBox KLA_ID BeforeExecuteSelect @42-6F7DD353
        Try
            ListBoxSource=KLA_IDDataCommand.Execute().Tables(KLA_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox KLA_ID BeforeExecuteSelect

'ListBox KLA_ID AfterExecuteSelect @42-96D57492
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New FloatField("", ListBoxSource(j)("KLA_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("KEY_LEARNING_AREA")
            item.KLA_IDItems.Add(Key, Val)
        Next
'End ListBox KLA_ID AfterExecuteSelect

'ListBox STATUS AfterExecuteSelect @48-B2FF5B63
        
item.STATUSItems.Add("Yes","Active")
item.STATUSItems.Add("No","Inactive")
'End ListBox STATUS AfterExecuteSelect

'ListBox CAMPUS_CODE AfterExecuteSelect @37-8E29AB9C
        
item.CAMPUS_CODEItems.Add("D","VSV")
'End ListBox CAMPUS_CODE AfterExecuteSelect

'ListBox CORE_YEARLEVELS AfterExecuteSelect @148-FFDC4C4F
        
item.CORE_YEARLEVELSItems.Add("7","Year 7")
item.CORE_YEARLEVELSItems.Add("8","Year 8")
item.CORE_YEARLEVELSItems.Add("9","Year 9")
item.CORE_YEARLEVELSItems.Add("10","Year 10")
item.CORE_YEARLEVELSItems.Add("7-8","Years 7 & 8")
item.CORE_YEARLEVELSItems.Add("9-10","Years 9 & 10")
item.CORE_YEARLEVELSItems.Add("Elective","Elective")
'End ListBox CORE_YEARLEVELS AfterExecuteSelect

'ListBox rbCORE_SUBJECT_FLAG AfterExecuteSelect @156-BBEF060A
        
item.rbCORE_SUBJECT_FLAGItems.Add("1","CORE")
item.rbCORE_SUBJECT_FLAGItems.Add("0","NON-CORE")
'End ListBox rbCORE_SUBJECT_FLAG AfterExecuteSelect

'ListBox listParentGroupSubject Initialize Data Source @173-019DD779
        listParentGroupSubjectDataCommand.Dao._optimized = False
        Dim listParentGroupSubjecttableIndex As Integer = 0
        listParentGroupSubjectDataCommand.OrderBy = ""
        listParentGroupSubjectDataCommand.Parameters.Clear()
'End ListBox listParentGroupSubject Initialize Data Source

'ListBox listParentGroupSubject BeforeExecuteSelect @173-251BB48D
        Try
            ListBoxSource=listParentGroupSubjectDataCommand.Execute().Tables(listParentGroupSubjecttableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox listParentGroupSubject BeforeExecuteSelect

'ListBox listParentGroupSubject AfterExecuteSelect @173-11593FC3
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New IntegerField("", ListBoxSource(j)("SUBJECT_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("display_text")
            item.listParentGroupSubjectItems.Add(Key, Val)
        Next
'End ListBox listParentGroupSubject AfterExecuteSelect

'Record NewRecord1 AfterExecuteSelect tail @29-E31F8E2A
    End Sub
'End Record NewRecord1 AfterExecuteSelect tail

'Record NewRecord1 Data Provider Class @29-A61BA892
End Class

'End Record NewRecord1 Data Provider Class

'EditableGrid SUBJECT_TEACHER Item Class @96-49A3DC0B
Public Class SUBJECT_TEACHERItem
    Public errors As NameValueCollection = New NameValueCollection()
    Public RowId As Integer
    Private _deleteAllowed As Boolean = True
    Private _isNew As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STAFF_ID As TextField
    Public STAFF_IDItems As ItemCollection
    Public SUBJECT_TIMEFRACTION As FloatField
    Public ALLOCATABLE_FLAG As IntegerField
    Public ALLOCATABLE_FLAGItems As ItemCollection
    Public CheckBox_Delete As BooleanField
    Public CheckBox_DeleteCheckedValue As BooleanField
    Public CheckBox_DeleteUncheckedValue As BooleanField
    Public LAST_ALTERED_BY As TextField
    Public lblLAST_ALTERED_BY As TextField
    Public SUBJECT_ID As IntegerField
    Public lblLAST_ALTERED_DATE As DateField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    STAFF_ID = New TextField("", Nothing)
    STAFF_IDItems = New ItemCollection()
    SUBJECT_TIMEFRACTION = New FloatField("0.00", 0.00)
    ALLOCATABLE_FLAG = New IntegerField("", Nothing)
    ALLOCATABLE_FLAGItems = New ItemCollection()
    CheckBox_Delete = New BooleanField(Settings.BoolFormat, false)
    CheckBox_DeleteCheckedValue = New BooleanField(Settings.BoolFormat, true)
    CheckBox_DeleteUncheckedValue = New BooleanField(Settings.BoolFormat, false)
    LAST_ALTERED_BY = New TextField("", dbutility.userid.tostring)
    lblLAST_ALTERED_BY = New TextField("", Nothing)
    SUBJECT_ID = New IntegerField("", Nothing)
    lblLAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, DateTime.Now)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase
        Get
            Select fieldName
                Case "SUBJECT_IDField"
                    Return Me.SUBJECT_IDField
                Case "STAFF_IDField"
                    Return Me.STAFF_IDField
                Case "STAFF_ID"
                    Return Me.STAFF_ID
                Case "SUBJECT_TIMEFRACTION"
                    Return Me.SUBJECT_TIMEFRACTION
                Case "ALLOCATABLE_FLAG"
                    Return Me.ALLOCATABLE_FLAG
                Case "CheckBox_Delete"
                    Return Me.CheckBox_Delete
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "lblLAST_ALTERED_BY"
                    Return Me.lblLAST_ALTERED_BY
                Case "SUBJECT_ID"
                    Return Me.SUBJECT_ID
                Case "lblLAST_ALTERED_DATE"
                    Return Me.lblLAST_ALTERED_DATE
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SUBJECT_IDField"
                    Me.SUBJECT_IDField = CType(Value,IntegerField)
                Case "STAFF_IDField"
                    Me.STAFF_IDField = CType(Value,TextField)
                Case "STAFF_ID"
                    Me.STAFF_ID = CType(Value,TextField)
                Case "SUBJECT_TIMEFRACTION"
                    Me.SUBJECT_TIMEFRACTION = CType(Value,FloatField)
                Case "ALLOCATABLE_FLAG"
                    Me.ALLOCATABLE_FLAG = CType(Value,IntegerField)
                Case "CheckBox_Delete"
                    Me.CheckBox_Delete = CType(Value,BooleanField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "lblLAST_ALTERED_BY"
                    Me.lblLAST_ALTERED_BY = CType(Value,TextField)
                Case "SUBJECT_ID"
                    Me.SUBJECT_ID = CType(Value,IntegerField)
                Case "lblLAST_ALTERED_DATE"
                    Me.lblLAST_ALTERED_DATE = CType(Value,DateField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public  Property IsDeleteAllowed As Boolean
        Get
            Return  Not(IsEmptyItem) AndAlso _deleteAllowed
        End Get
        Set
            _deleteAllowed = Value
        End Set
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
            result = IsNothing(STAFF_ID.Value) And result
            result = IsNothing(SUBJECT_TIMEFRACTION.Value) And result
            result = IsNothing(ALLOCATABLE_FLAG.Value) And result
            result = IsNothing(CheckBox_Delete.Value) And result
            result = IsNothing(LAST_ALTERED_BY.Value) And result
            result = IsNothing(SUBJECT_ID.Value) And result
            result = IsNothing(LAST_ALTERED_DATE.Value) And result
            result = IsNothing(SUBJECT_IDField.Value) And result
            result = IsNothing(STAFF_IDField.Value) And result
            Return result
        End Get
    End Property

    Public IsDeleted As Boolean = False
    Public IsUpdated As Boolean = False
    Public SUBJECT_IDField As IntegerField = New IntegerField()
    Public STAFF_IDField As TextField = New TextField()
    Public Function Validate(ByVal provider As SUBJECT_TEACHERDataProvider) As Boolean
'End EditableGrid SUBJECT_TEACHER Item Class

'SUBJECT_TIMEFRACTION validate @112-07302C75
        If IsNothing(SUBJECT_TIMEFRACTION.Value) OrElse SUBJECT_TIMEFRACTION.Value.ToString() ="" Then
            errors.Add("SUBJECT_TIMEFRACTION",String.Format(Resources.strings.CCS_RequiredField,"SUBJECT TIMEFRACTION"))
        End If
'End SUBJECT_TIMEFRACTION validate

'TextBox SUBJECT_TIMEFRACTION Event OnValidate. Action Validate Maximum Value @132-14FA5199
        If Not (SUBJECT_TIMEFRACTION.Value Is Nothing) Then
            If Convert.ToDouble(SUBJECT_TIMEFRACTION.Value) > 1.1 Then
            errors.Add("SUBJECT_TIMEFRACTION",String.Format("Maximum SUBJECT TIME FRACTION is 1.1","SUBJECT TIMEFRACTION","1.1"))
            End If
        End If
'End TextBox SUBJECT_TIMEFRACTION Event OnValidate. Action Validate Maximum Value

'LAST_ALTERED_BY validate @114-256A6854
        If IsNothing(LAST_ALTERED_BY.Value) OrElse LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End LAST_ALTERED_BY validate

'SUBJECT_ID validate @110-22E3C20E
        If IsNothing(SUBJECT_ID.Value) OrElse SUBJECT_ID.Value.ToString() ="" Then
            errors.Add("SUBJECT_ID",String.Format(Resources.strings.CCS_RequiredField,"SUBJECT ID"))
        End If
'End SUBJECT_ID validate

'LAST_ALTERED_DATE validate @115-C5989D76
        If IsNothing(LAST_ALTERED_DATE.Value) OrElse LAST_ALTERED_DATE.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED DATE"))
        End If
'End LAST_ALTERED_DATE validate

'EditableGrid SUBJECT_TEACHER Item Class tail @96-11D8DCF0
        Return errors.Count = 0
    End Function
    Public RawData As DataRow = Nothing
End Class
'End EditableGrid SUBJECT_TEACHER Item Class tail

'EditableGrid SUBJECT_TEACHER Data Provider Class Header @96-E1B376CB
Public Class SUBJECT_TEACHERDataProvider
Inherits EditableGridDataProviderBase
'End EditableGrid SUBJECT_TEACHER Data Provider Class Header

'Grid SUBJECT_TEACHER Data Provider Class Variables @96-5EBD2229

    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 10
    Public PageNumber As Integer = 1
    Public EmptyRows As Integer = 1
    Public UrlSUBJECT_ID  As IntegerParameter
    Protected STAFF_IDDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM View_StaffList_Active_Inactive {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
'End Grid SUBJECT_TEACHER Data Provider Class Variables

'EditableGrid SUBJECT_TEACHER Data Provider Class Constructor @96-0CCC366F

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM SUBJECT_TEACHER {SQL_Where} {SQL_OrderBy}", New String(){"SUBJECT_ID107"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM SUBJECT_TEACHER", New String(){"SUBJECT_ID107"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End EditableGrid SUBJECT_TEACHER Data Provider Class Constructor

'Record SUBJECT_TEACHER Data Provider Class CheckUnique Method @96-CE9CF344

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As SUBJECT_TEACHERItem) As Boolean
        Return True
    End Function
'End Record SUBJECT_TEACHER Data Provider Class CheckUnique Method

'Grid SUBJECT_TEACHER Data Provider Class Insert Method @96-8735682B
    Protected Function InsertItem(ByVal item As SUBJECT_TEACHERItem) As Integer
        Dim CmdExecution As Boolean = True
        Dim Insert As DataCommand=new TableCommand("INSERT INTO SUBJECT_TEACHER({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Grid SUBJECT_TEACHER Data Provider Class Insert Method

'DEL      ' -------------------------
'DEL      'ERA: if the major fields are blank then don't do INSERT
'DEL      ' -------------------------


'EditableGrid SUBJECT_TEACHER Build insert @96-35DEDF35
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.STAFF_ID.IsEmpty Then
        allEmptyFlag = item.STAFF_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STAFF_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STAFF_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUBJECT_TIMEFRACTION.IsEmpty Then
        allEmptyFlag = item.SUBJECT_TIMEFRACTION.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUBJECT_TIMEFRACTION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUBJECT_TIMEFRACTION.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.ALLOCATABLE_FLAG.IsEmpty Then
        allEmptyFlag = item.ALLOCATABLE_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ALLOCATABLE_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ALLOCATABLE_FLAG.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUBJECT_ID.IsEmpty Then
        allEmptyFlag = item.SUBJECT_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUBJECT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUBJECT_ID.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
		Insert.SqlQuery.Replace("{Fields}", fieldsList.TrimEnd(","C))
		Insert.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
'End EditableGrid SUBJECT_TEACHER Build insert

'EditableGrid SUBJECT_TEACHER Event BeforeExecuteInsert. Action Custom Code @133-73254650
    ' -------------------------
	'ERA: redo check: if the STAFF ID field is blank then don't do INSERT
		If (item.STAFF_ID.IsEmpty or item.STAFF_ID.GetFormattedValue("")="") Then
			CmdExecution = false
		End if
    ' -------------------------
'End EditableGrid SUBJECT_TEACHER Event BeforeExecuteInsert. Action Custom Code

'EditableGrid SUBJECT_TEACHER Data Provider Class ExecuteInsert @96-41C970ED
        Insert.OpType = OperationType.Insert
        Dim result As Object = 0
        Dim E As Exception = Nothing
        If CmdExecution Then
            Try
                 If Not allEmptyFlag Then result = Insert.ExecuteNonQuery()
            Catch e_ As Exception
                item.errors.Add("DataProvider",e_.Source + ":" + e_.Message)
            Finally
'End EditableGrid SUBJECT_TEACHER Data Provider Class ExecuteInsert

'EditableGrid SUBJECT_TEACHER AfterExecuteInsert @96-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid SUBJECT_TEACHER AfterExecuteInsert

'EditableGrid SUBJECT_TEACHER Data Provider Class Update Method @96-4D2FBCAF
    Protected Function UpdateItem(ByVal item As SUBJECT_TEACHERItem) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        Dim Update As DataCommand=new TableCommand("UPDATE SUBJECT_TEACHER SET {Values}", New String(){"SUBJECT_ID108","And","STAFF_ID109"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End EditableGrid SUBJECT_TEACHER Data Provider Class Update Method

'EditableGrid SUBJECT_TEACHER BeforeBuildUpdate @96-DB4CFB1E
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("SUBJECT_ID107",UrlSUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        If Not item.STAFF_ID.IsEmpty Then
        allEmptyFlag = item.STAFF_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STAFF_ID=" + Update.Dao.ToSql(item.STAFF_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUBJECT_TIMEFRACTION.IsEmpty Then
        allEmptyFlag = item.SUBJECT_TIMEFRACTION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUBJECT_TIMEFRACTION=" + Update.Dao.ToSql(item.SUBJECT_TIMEFRACTION.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.ALLOCATABLE_FLAG.IsEmpty Then
        allEmptyFlag = item.ALLOCATABLE_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ALLOCATABLE_FLAG=" + Update.Dao.ToSql(item.ALLOCATABLE_FLAG.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUBJECT_ID.IsEmpty Then
        allEmptyFlag = item.SUBJECT_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUBJECT_ID=" + Update.Dao.ToSql(item.SUBJECT_ID.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
		Update.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
        Update.Parameters.Add("SUBJECT_ID108","SUBJECT_ID = " & Update.Dao.ToSql(item.SUBJECT_IDField.GetFormattedValue(""),FieldType._Integer))
        Update.Parameters.Add("STAFF_ID109","STAFF_ID = " & Update.Dao.ToSql(item.STAFF_IDField.GetFormattedValue(""),FieldType._Text))
'End EditableGrid SUBJECT_TEACHER BeforeBuildUpdate

'EditableGrid SUBJECT_TEACHER Event BeforeExecuteUpdate. Action Custom Code @134-73254650
    ' -------------------------
    'ERA: redo check: if the STAFF ID field is blank then don't do UPDATE
		If (item.STAFF_ID.IsEmpty or item.STAFF_ID.GetFormattedValue("")="") Then
			CmdExecution = false
		End if
    ' -------------------------
'End EditableGrid SUBJECT_TEACHER Event BeforeExecuteUpdate. Action Custom Code

'EditableGrid SUBJECT_TEACHER Execute Update  @96-392E25E7
        Update.OpType = OperationType.Update
        Dim result As Object = 0
        Dim E As Exception = Nothing
        If CmdExecution Then
            If Not IsParametersPassed Then
                item.errors.Add("DataProvider",Resources.strings.CCS_CustomOperationError_MissingParameters)
                Return 0
            End If
            Try
                 If Not allEmptyFlag Then result = Update.ExecuteNonQuery()
            Catch e_ As Exception
                item.errors.Add("DataProvider",e_.Source + ":" + e_.Message)
            Finally
'End EditableGrid SUBJECT_TEACHER Execute Update 

'EditableGrid SUBJECT_TEACHER AfterExecuteUpdate @96-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid SUBJECT_TEACHER AfterExecuteUpdate

'Record SUBJECT_TEACHER Data Provider Class Delete Method @96-64943ED3
    Public Function DeleteItem(ByVal item As SUBJECT_TEACHERItem) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        Dim Delete As DataCommand=new TableCommand("DELETE FROM SUBJECT_TEACHER", New String(){"SUBJECT_ID108","And","STAFF_ID109"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record SUBJECT_TEACHER Data Provider Class Delete Method

'Record SUBJECT_TEACHER BeforeBuildDelete @96-D5A63EEF
        Delete.Parameters.Clear()
        CType(Delete,TableCommand).AddParameter("SUBJECT_ID107",UrlSUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        Delete.SqlQuery.Replace("{STAFF_ID}",Delete.Dao.ToSql(item.STAFF_ID.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{SUBJECT_TIMEFRACTION}",Delete.Dao.ToSql(item.SUBJECT_TIMEFRACTION.GetFormattedValue(""),FieldType._Float))
        Delete.SqlQuery.Replace("{ALLOCATABLE_FLAG}",Delete.Dao.ToSql(item.ALLOCATABLE_FLAG.GetFormattedValue(""),FieldType._Integer))
        Delete.SqlQuery.Replace("{LAST_ALTERED_BY}",Delete.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{SUBJECT_ID}",Delete.Dao.ToSql(item.SUBJECT_ID.GetFormattedValue(""),FieldType._Integer))
        Delete.SqlQuery.Replace("{LAST_ALTERED_DATE}",Delete.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Delete.DateFormat),FieldType._Date))
        Delete.Parameters.Add("SUBJECT_ID108","SUBJECT_ID = " & Delete.Dao.ToSql(item.SUBJECT_IDField.GetFormattedValue(""),FieldType._Integer))
        Delete.Parameters.Add("STAFF_ID109","STAFF_ID = " & Delete.Dao.ToSql(item.STAFF_IDField.GetFormattedValue(""),FieldType._Text))
'End Record SUBJECT_TEACHER BeforeBuildDelete

'EditableGrid SUBJECT_TEACHER Data Provider Class Execute Delete @96-124DEAF1
        Delete.OpType = OperationType.Delete
        Dim result As Object = 0
        Dim E As Exception = Nothing
        If CmdExecution Then
            If Not IsParametersPassed Then
                item.errors.Add("DataProvider",Resources.strings.CCS_CustomOperationError_MissingParameters)
                Return 0
            End If
            Try
                result = Delete.ExecuteNonQuery()
            Catch e_ As Exception
                item.errors.Add("DataProvider",e_.Source + ":" + e_.Message)
            Finally
'End EditableGrid SUBJECT_TEACHER Data Provider Class Execute Delete

'EditableGrid SUBJECT_TEACHER AfterExecuteDelete @96-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid SUBJECT_TEACHER AfterExecuteDelete

'Grid SUBJECT_TEACHER Data Provider Class GetResultSet Method @96-57316F5F
    Public Sub Update(Items As ArrayList, ops As FormSupportedOperations)
        Dim i As Integer
        For i = 0 To Items.Count - 1
            Dim op As EditableGridOperation = EditableGridOperation.Insert
            Dim isProcessed As Boolean = False
            Dim item As SUBJECT_TEACHERItem = CType(Items(i), SUBJECT_TEACHERItem)
'End Grid SUBJECT_TEACHER Data Provider Class GetResultSet Method

'EditableGrid SUBJECT_TEACHER Data Provider Class Update @96-EC7F15D7
            If Not item.IsUpdated Then
                If item.IsDeleted And ops.AllowDelete Then
                    DeleteItem(item)
                    op = EditableGridOperation.Delete
                    isProcessed = True
                End If
                If item.IsNew And Not(item.IsEmptyItem) And ops.AllowInsert And Not(isProcessed) Then
                    InsertItem(item)
                    op = EditableGridOperation.Insert
                    isProcessed = True
                End If
                If Not(item.IsEmptyItem) And ops.AllowUpdate And Not(isProcessed) Then
                    UpdateItem(item)
                    op = EditableGridOperation.Update
                End If
'End EditableGrid SUBJECT_TEACHER Data Provider Class Update

'EditableGrid SUBJECT_TEACHER Data Provider Class AfterUpdate @96-6CCB76B9
                If item.errors.Count = 0 Then item.IsUpdated = True
                OnItemUpdated(New ItemUpdatedEventArgs(op, item))
            End If
        Next i
    End Sub
'End EditableGrid SUBJECT_TEACHER Data Provider Class AfterUpdate

'EditableGrid SUBJECT_TEACHER Data Provider Class GetResultSet Method @96-E602754C
    Public Function GetResultSet(ByRef _pagesCount As Integer, ops As FormSupportedOperations) As SUBJECT_TEACHERItem()
'End EditableGrid SUBJECT_TEACHER Data Provider Class GetResultSet Method

'Before build Select @96-0AA50C38
        _pagesCount = 0
        Dim E as Exception = Nothing
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("SUBJECT_ID107",UrlSUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy = SortFieldsNames(CInt(SortField)).Trim
        Else
            Select_.OrderBy = SortFieldsNamesDesc(CInt(SortField)).Trim
        End If
    Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @96-939614DD
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

'After execute Select @96-1D3FFB2C
                If Not IsNothing(E) Then Throw E
            End Try
            dr = ds.Tables(tableIndex).Rows
            rowCount = dr.Count
        End If
        if  Not ops.AllowInsert Then EmptyRows = 0
        Dim result(rowCount + EmptyRows - 1) As SUBJECT_TEACHERItem
'End After execute Select

'ListBox STAFF_ID Initialize Data Source @111-F40350B8
    STAFF_IDDataCommand.Dao._optimized = False
    Dim STAFF_IDtableIndex As Integer = 0
    STAFF_IDDataCommand.OrderBy = "status_type, staff_ID"
    STAFF_IDDataCommand.Parameters.Clear()
'End ListBox STAFF_ID Initialize Data Source

'ListBox STAFF_ID BeforeExecuteSelect @111-0F683DF6
    Try
        ListBoxSource=STAFF_IDDataCommand.Execute().Tables(STAFF_IDtableIndex).Rows
    Catch ee as Exception 
        E=ee
    Finally
'End ListBox STAFF_ID BeforeExecuteSelect

'ListBox STAFF_ID AfterExecuteSelect @111-E17AA7D1
        If Not IsNothing(E) Then Throw E
    End Try
    Dim STAFF_IDItems As ItemCollection = New ItemCollection()
    For j=0 To ListBoxSource.Count-1 
        Dim Key As String = (New TextField("", ListBoxSource(j)("staff_ID"))).GetFormattedValue("")
        Dim Val As Object = ListBoxSource(j)("staffname")
        STAFF_IDItems.Add(Key, Val)
    Next
'End ListBox STAFF_ID AfterExecuteSelect

'ListBox ALLOCATABLE_FLAG AfterExecuteSelect @113-D9E56B85
    Dim ALLOCATABLE_FLAGItems As ItemCollection = New ItemCollection()
    
ALLOCATABLE_FLAGItems.Add("1","Yes!")
ALLOCATABLE_FLAGItems.Add("0","NOT to this Teacher")
'End ListBox ALLOCATABLE_FLAG AfterExecuteSelect

'After execute Select tail @96-FF3C03A0
        Dim i as Integer
        For i = 0 To rowCount - 1
            Dim item as SUBJECT_TEACHERItem = New SUBJECT_TEACHERItem()
            item.IsDeleteAllowed = ops.AllowDelete
            item.STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
            item.STAFF_IDItems = CType(STAFF_IDItems.Clone(), ItemCollection)
            item.SUBJECT_TIMEFRACTION.SetValue(dr(i)("SUBJECT_TIMEFRACTION"),"")
            item.ALLOCATABLE_FLAG.SetValue(dr(i)("ALLOCATABLE_FLAG"),"")
            item.ALLOCATABLE_FLAGItems = CType(ALLOCATABLE_FLAGItems.Clone(), ItemCollection)
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.lblLAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
            item.lblLAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.SUBJECT_IDField.SetValue(dr(i)("SUBJECT_ID"),"")
            item.STAFF_IDField.SetValue(dr(i)("STAFF_ID"),"")
            item.RawData = dr(i)
            result(i)=item
        Next i
        For i = rowCount To rowCount + EmptyRows - 1
            Dim item as SUBJECT_TEACHERItem = New SUBJECT_TEACHERItem()
            item.IsDeleteAllowed = ops.AllowDelete
            item.IsNew = True
            item.STAFF_IDItems = CType(STAFF_IDItems.Clone(), ItemCollection)
            item.ALLOCATABLE_FLAGItems = CType(ALLOCATABLE_FLAGItems.Clone(), ItemCollection)
            result(i) = item
        Next i
        If ops.AllowRead Then
            _isEmpty = IIf(dr.Count = 0, True, False)
        Else
            _isEmpty = True
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @96-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

