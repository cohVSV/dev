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

Namespace DECV_PROD2007.Teleforms_Enrolments 'Namespace @1-9A8AF919

'Page Data Class @1-D1124464
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public lblDEBUG As TextField
    Public Sub New()
        lblDEBUG = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.lblDEBUG.SetValue(DBUtility.GetInitialValue("lblDEBUG"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "lblDEBUG"
                    Return lblDEBUG
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblDEBUG"
                    lblDEBUG = CType(value, TextField)
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

'Record UpdateForm Item Class @57-DAE6A5E2
Public Class UpdateFormItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public hidden_LAST_ALTERED_BY As TextField
    Public lblSelections As TextField
    Public Sub New()
    hidden_LAST_ALTERED_BY = New TextField("", Nothing)
    lblSelections = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As UpdateFormItem
        Dim item As UpdateFormItem = New UpdateFormItem()
        If Not IsNothing(DBUtility.GetInitialValue("button_DoDelete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY")) Then
        item.hidden_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblSelections")) Then
        item.lblSelections.SetValue(DBUtility.GetInitialValue("lblSelections"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("button_DoEnrolment")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "hidden_LAST_ALTERED_BY"
                    Return hidden_LAST_ALTERED_BY
                Case "lblSelections"
                    Return lblSelections
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "hidden_LAST_ALTERED_BY"
                    hidden_LAST_ALTERED_BY = CType(value, TextField)
                Case "lblSelections"
                    lblSelections = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As UpdateFormDataProvider)
'End Record UpdateForm Item Class

'Record UpdateForm Item Class tail @57-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record UpdateForm Item Class tail

'Record UpdateForm Data Provider Class @57-4ED18962
Public Class UpdateFormDataProvider
Inherits RecordDataProviderBase
'End Record UpdateForm Data Provider Class

'Record UpdateForm Data Provider Class Variables @57-11BE28A5
    Protected item As UpdateFormItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record UpdateForm Data Provider Class Variables

'Record UpdateForm Data Provider Class GetResultSet Method @57-6AD78FCC

    Public Sub FillItem(ByVal item As UpdateFormItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record UpdateForm Data Provider Class GetResultSet Method

'Record UpdateForm BeforeBuildSelect @57-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record UpdateForm BeforeBuildSelect

'Record UpdateForm AfterExecuteSelect @57-79426A21
        End If
            IsInsertMode = True
'End Record UpdateForm AfterExecuteSelect

'Record UpdateForm AfterExecuteSelect tail @57-E31F8E2A
    End Sub
'End Record UpdateForm AfterExecuteSelect tail

'Record UpdateForm Data Provider Class @57-A61BA892
End Class

'End Record UpdateForm Data Provider Class

'Grid GridStudentList Item Class @2-CADA6A23
Public Class GridStudentListItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STUD_SUB_INTERIM_STUD_SUB_TotalRecords As TextField
    Public cbox As BooleanField
    Public cboxCheckedValue As BooleanField
    Public cboxUncheckedValue As BooleanField
    Public STUDENT_SUBJECT_STUDENT_ID As FloatField
    Public STUDENT_ID As TextField
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public BIRTH_DATE As DateField
    Public LAST_ALTERED_DATE As DateField
    Public TELEFORM_STATUS As TextField
    Public CATEGORY_CODE As TextField
    Public hidden_TMP_STUDENT_ID As TextField
    Public Sub New()
    STUD_SUB_INTERIM_STUD_SUB_TotalRecords = New TextField("", Nothing)
    cbox = New BooleanField(Settings.BoolFormat, false)
    cboxCheckedValue = New BooleanField(Settings.BoolFormat, true)
    cboxUncheckedValue = New BooleanField(Settings.BoolFormat, false)
    STUDENT_SUBJECT_STUDENT_ID = New FloatField("", Nothing)
    STUDENT_ID = New TextField("", Nothing)
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    BIRTH_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy H\:mm", Nothing)
    TELEFORM_STATUS = New TextField("", Nothing)
    CATEGORY_CODE = New TextField("", Nothing)
    hidden_TMP_STUDENT_ID = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STUD_SUB_INTERIM_STUD_SUB_TotalRecords"
                    Return Me.STUD_SUB_INTERIM_STUD_SUB_TotalRecords
                Case "cbox"
                    Return Me.cbox
                Case "STUDENT_SUBJECT_STUDENT_ID"
                    Return Me.STUDENT_SUBJECT_STUDENT_ID
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "BIRTH_DATE"
                    Return Me.BIRTH_DATE
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "TELEFORM_STATUS"
                    Return Me.TELEFORM_STATUS
                Case "CATEGORY_CODE"
                    Return Me.CATEGORY_CODE
                Case "hidden_TMP_STUDENT_ID"
                    Return Me.hidden_TMP_STUDENT_ID
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUD_SUB_INTERIM_STUD_SUB_TotalRecords"
                    Me.STUD_SUB_INTERIM_STUD_SUB_TotalRecords = CType(Value,TextField)
                Case "cbox"
                    Me.cbox = CType(Value,BooleanField)
                Case "STUDENT_SUBJECT_STUDENT_ID"
                    Me.STUDENT_SUBJECT_STUDENT_ID = CType(Value,FloatField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,TextField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "BIRTH_DATE"
                    Me.BIRTH_DATE = CType(Value,DateField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "TELEFORM_STATUS"
                    Me.TELEFORM_STATUS = CType(Value,TextField)
                Case "CATEGORY_CODE"
                    Me.CATEGORY_CODE = CType(Value,TextField)
                Case "hidden_TMP_STUDENT_ID"
                    Me.hidden_TMP_STUDENT_ID = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid GridStudentList Item Class

'Grid GridStudentList Data Provider Class Header @2-D50EDC61
Public Class GridStudentListDataProvider
Inherits GridDataProviderBase
'End Grid GridStudentList Data Provider Class Header

'Grid GridStudentList Data Provider Class Variables @2-91466CF4

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_SUBJECT_STUDENT_ID
        Sorter_SURNAME
        Sorter_FIRST_NAME
    End Enum

    Private SortFieldsNames As String() = New String() {"LAST_ALTERED_DATE desc","STUDENT_SUBJECT.STUDENT_ID","SURNAME","FIRST_NAME"}
    Private SortFieldsNamesDesc As String() = New string() {"LAST_ALTERED_DATE desc","STUDENT_SUBJECT.STUDENT_ID DESC","SURNAME DESC","FIRST_NAME DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 80
    Public PageNumber As Integer = 1
'End Grid GridStudentList Data Provider Class Variables

'Grid GridStudentList Data Provider Class GetResultSet Method @2-28DF51A3

    Public Sub New()
        Select_=new SqlCommand("SELECT TOP {SqlParam_endRecord} STUDENT_ID AS Student_id, rtrim(SURNAME) AS surname, rtrim" & _
          "(FIRST_NAME) AS first_name, BIRTH_DATE, CATEGORY_CODE, SUBCATEGORY_CODE," & vbCrLf & _
          "LAST_ALTERED_DATE, TMP_STUDENT_ID, TELEFORM_STATUS " & vbCrLf & _
          "FROM TMP_STUDENT" & vbCrLf & _
          "WHERE last_altered_by ='TELEFORM'" & vbCrLf & _
          "and ((TELEFORM_STATUS like 'UNENROLLED%') or (TELEFORM_STATUS='ENROLLED' and last_altered_" & _
          "date >=  dateadd(dd,-4,getdate()))) {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (SELECT STUDENT_ID AS Student_id, rtrim(SURNAME) AS surname, rtrim(FI" & _
          "RST_NAME) AS first_name, BIRTH_DATE, CATEGORY_CODE, SUBCATEGORY_CODE," & vbCrLf & _
          "LAST_ALTERED_DATE, TMP_STUDENT_ID, TELEFORM_STATUS " & vbCrLf & _
          "FROM TMP_STUDENT" & vbCrLf & _
          "WHERE last_altered_by ='TELEFORM'" & vbCrLf & _
          "and ((TELEFORM_STATUS like 'UNENROLLED%') or (TELEFORM_STATUS='ENROLLED' and last_altered_" & _
          "date >=  dateadd(dd,-4,getdate())))) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid GridStudentList Data Provider Class GetResultSet Method

'Grid GridStudentList Data Provider Class GetResultSet Method @2-9F93D720
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As GridStudentListItem()
'End Grid GridStudentList Data Provider Class GetResultSet Method

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

'Execute Select @2-5D588829
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As GridStudentListItem
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

'After execute Select @2-6C5081C2
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New GridStudentListItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-11CCD76F
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as GridStudentListItem = New GridStudentListItem()
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.BIRTH_DATE.SetValue(dr(i)("BIRTH_DATE"),Select_.DateFormat)
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.TELEFORM_STATUS.SetValue(dr(i)("TELEFORM_STATUS"),"")
                item.CATEGORY_CODE.SetValue(dr(i)("CATEGORY_CODE"),"")
                item.hidden_TMP_STUDENT_ID.SetValue(dr(i)("TMP_STUDENT_ID"),"")
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

