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

Namespace DECV_PROD2007.FutureEnrol_searchlist 'Namespace @1-BE158E0C

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

'Grid STUDENT_ENROLMENT_STUDENT Item Class @3-496237BE
Public Class STUDENT_ENROLMENT_STUDENTItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STUDENT_ENROLMENT_STUDENT_TotalRecords As TextField
    Public STUDENT_STUDENT_ID As FloatField
    Public STUDENT_STUDENT_IDHref As Object
    Public STUDENT_STUDENT_IDHrefParameters As LinkParameterCollection
    Public FIRST_NAME As TextField
    Public SURNAME As TextField
    Public CATEGORY_CODE As TextField
    Public YEAR_LEVEL As IntegerField
    Public ENROLMENT_DATE As DateField
    Public ENROLMENT_YEAR As FloatField
    Public Sub New()
    STUDENT_ENROLMENT_STUDENT_TotalRecords = New TextField("", Nothing)
    STUDENT_STUDENT_ID = New FloatField("",Nothing)
    STUDENT_STUDENT_IDHrefParameters = New LinkParameterCollection()
    FIRST_NAME = New TextField("", Nothing)
    SURNAME = New TextField("", Nothing)
    CATEGORY_CODE = New TextField("", Nothing)
    YEAR_LEVEL = New IntegerField("", Nothing)
    ENROLMENT_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    ENROLMENT_YEAR = New FloatField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STUDENT_ENROLMENT_STUDENT_TotalRecords"
                    Return Me.STUDENT_ENROLMENT_STUDENT_TotalRecords
                Case "STUDENT_STUDENT_ID"
                    Return Me.STUDENT_STUDENT_ID
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "SURNAME"
                    Return Me.SURNAME
                Case "CATEGORY_CODE"
                    Return Me.CATEGORY_CODE
                Case "YEAR_LEVEL"
                    Return Me.YEAR_LEVEL
                Case "ENROLMENT_DATE"
                    Return Me.ENROLMENT_DATE
                Case "ENROLMENT_YEAR"
                    Return Me.ENROLMENT_YEAR
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_ENROLMENT_STUDENT_TotalRecords"
                    Me.STUDENT_ENROLMENT_STUDENT_TotalRecords = CType(Value,TextField)
                Case "STUDENT_STUDENT_ID"
                    Me.STUDENT_STUDENT_ID = CType(Value,FloatField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "CATEGORY_CODE"
                    Me.CATEGORY_CODE = CType(Value,TextField)
                Case "YEAR_LEVEL"
                    Me.YEAR_LEVEL = CType(Value,IntegerField)
                Case "ENROLMENT_DATE"
                    Me.ENROLMENT_DATE = CType(Value,DateField)
                Case "ENROLMENT_YEAR"
                    Me.ENROLMENT_YEAR = CType(Value,FloatField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STUDENT_ENROLMENT_STUDENT Item Class

'Grid STUDENT_ENROLMENT_STUDENT Data Provider Class Header @3-15719291
Public Class STUDENT_ENROLMENT_STUDENTDataProvider
Inherits GridDataProviderBase
'End Grid STUDENT_ENROLMENT_STUDENT Data Provider Class Header

'Grid STUDENT_ENROLMENT_STUDENT Data Provider Class Variables @3-13C9417D

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_STUDENT_ID
        Sorter_FIRST_NAME
        Sorter_SURNAME
        Sorter_CATEGORY_CODE
        Sorter_YEAR_LEVEL
        Sorter_ENROLMENT_DATE
        Sorter_ENROLMENT_YEAR
    End Enum

    Private SortFieldsNames As String() = New String() {"","STUDENT_STUDENT_ID","FIRST_NAME","SURNAME","CATEGORY_CODE","YEAR_LEVEL","ENROLMENT_DATE","ENROLMENT_YEAR"}
    Private SortFieldsNamesDesc As String() = New string() {"","STUDENT_STUDENT_ID DESC","FIRST_NAME DESC","SURNAME DESC","CATEGORY_CODE DESC","YEAR_LEVEL DESC","ENROLMENT_DATE DESC","ENROLMENT_YEAR DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 50
    Public PageNumber As Integer = 1
    Public Urls_STUDENT_ID  As FloatParameter
    Public Urls_SURNAME  As TextParameter
'End Grid STUDENT_ENROLMENT_STUDENT Data Provider Class Variables

'Grid STUDENT_ENROLMENT_STUDENT Data Provider Class GetResultSet Method @3-47301749

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} STUDENT.STUDENT_ID AS STUDENT_STUDENT_ID, SURNAME, " & vbCrLf & _
          "FIRST_NAME, CATEGORY_CODE, YEAR_LEVEL, ENROLMENT_DATE, " & vbCrLf & _
          "ENROLMENT_YEAR " & vbCrLf & _
          "FROM STUDENT INNER JOIN STUDENT_ENROLMENT ON" & vbCrLf & _
          "STUDENT.STUDENT_ID = STUDENT_ENROLMENT.STUDENT_ID {SQL_Where} {SQL_OrderBy}", New String(){"expr61","And","expr62","And","(","s_STUDENT_ID63","Or","s_SURNAME64","Or","s_SURNAME65",")"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STUDENT INNER JOIN STUDENT_ENROLMENT ON" & vbCrLf & _
          "STUDENT.STUDENT_ID = STUDENT_ENROLMENT.STUDENT_ID", New String(){"expr61","And","expr62","And","(","s_STUDENT_ID63","Or","s_SURNAME64","Or","s_SURNAME65",")"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid STUDENT_ENROLMENT_STUDENT Data Provider Class GetResultSet Method

'Grid STUDENT_ENROLMENT_STUDENT Data Provider Class GetResultSet Method @3-ECE8697F
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STUDENT_ENROLMENT_STUDENTItem()
'End Grid STUDENT_ENROLMENT_STUDENT Data Provider Class GetResultSet Method

'Before build Select @3-334FED31
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_STUDENT_ID63",Urls_STUDENT_ID, "","STUDENT.STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("s_SURNAME64",Urls_SURNAME, "","STUDENT.SURNAME",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_SURNAME65",Urls_SURNAME, "","FIRST_NAME",Condition.Contains,False)
        Select_.Parameters.Add("expr61","(ENROLMENT_STATUS='F')")
        Select_.Parameters.Add("expr62","(ENROLMENT_YEAR >= Year(getdate()))")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @3-E9DDC849
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STUDENT_ENROLMENT_STUDENTItem
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

'After execute Select @3-97F0ABB6
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENT_ENROLMENT_STUDENTItem(dr.Count-1) {}
'End After execute Select

'After execute Select @3-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @3-516DA3B1
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_ENROLMENT_STUDENTItem = New STUDENT_ENROLMENT_STUDENTItem()
                item.STUDENT_STUDENT_ID.SetValue(dr(i)("STUDENT_STUDENT_ID"),"")
                item.STUDENT_STUDENT_IDHref = "FutureEnrol_StudentMaintain.aspx"
                item.STUDENT_STUDENT_IDHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_STUDENT_ID").ToString()))
                item.STUDENT_STUDENT_IDHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.CATEGORY_CODE.SetValue(dr(i)("CATEGORY_CODE"),"")
                item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
                item.ENROLMENT_DATE.SetValue(dr(i)("ENROLMENT_DATE"),Select_.DateFormat)
                item.ENROLMENT_YEAR.SetValue(dr(i)("ENROLMENT_YEAR"),"")
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

'Record STUDENT_ENROLMENT_STUDENT1 Item Class @38-06A7888D
Public Class STUDENT_ENROLMENT_STUDENT1Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public s_STUDENT_ID As FloatField
    Public s_SURNAME As TextField
    Public Sub New()
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    s_STUDENT_ID = New FloatField("", Nothing)
    s_SURNAME = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_ENROLMENT_STUDENT1Item
        Dim item As STUDENT_ENROLMENT_STUDENT1Item = New STUDENT_ENROLMENT_STUDENT1Item()
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_STUDENT_ID")) Then
        item.s_STUDENT_ID.SetValue(DBUtility.GetInitialValue("s_STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_SURNAME")) Then
        item.s_SURNAME.SetValue(DBUtility.GetInitialValue("s_SURNAME"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "ClearParameters"
                    Return ClearParameters
                Case "s_STUDENT_ID"
                    Return s_STUDENT_ID
                Case "s_SURNAME"
                    Return s_SURNAME
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ClearParameters"
                    ClearParameters = CType(value, TextField)
                Case "s_STUDENT_ID"
                    s_STUDENT_ID = CType(value, FloatField)
                Case "s_SURNAME"
                    s_SURNAME = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STUDENT_ENROLMENT_STUDENT1DataProvider)
'End Record STUDENT_ENROLMENT_STUDENT1 Item Class

'Record STUDENT_ENROLMENT_STUDENT1 Item Class tail @38-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_ENROLMENT_STUDENT1 Item Class tail

'Record STUDENT_ENROLMENT_STUDENT1 Data Provider Class @38-959D1028
Public Class STUDENT_ENROLMENT_STUDENT1DataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_ENROLMENT_STUDENT1 Data Provider Class

'Record STUDENT_ENROLMENT_STUDENT1 Data Provider Class Variables @38-325D7479
    Protected item As STUDENT_ENROLMENT_STUDENT1Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_ENROLMENT_STUDENT1 Data Provider Class Variables

'Record STUDENT_ENROLMENT_STUDENT1 Data Provider Class GetResultSet Method @38-6E601C19

    Public Sub FillItem(ByVal item As STUDENT_ENROLMENT_STUDENT1Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record STUDENT_ENROLMENT_STUDENT1 Data Provider Class GetResultSet Method

'Record STUDENT_ENROLMENT_STUDENT1 BeforeBuildSelect @38-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_ENROLMENT_STUDENT1 BeforeBuildSelect

'Record STUDENT_ENROLMENT_STUDENT1 AfterExecuteSelect @38-79426A21
        End If
            IsInsertMode = True
'End Record STUDENT_ENROLMENT_STUDENT1 AfterExecuteSelect

'Record STUDENT_ENROLMENT_STUDENT1 AfterExecuteSelect tail @38-E31F8E2A
    End Sub
'End Record STUDENT_ENROLMENT_STUDENT1 AfterExecuteSelect tail

'Record STUDENT_ENROLMENT_STUDENT1 Data Provider Class @38-A61BA892
End Class

'End Record STUDENT_ENROLMENT_STUDENT1 Data Provider Class

'Record STUDENTSearch Item Class @10-4DAEB1A6
Public Class STUDENTSearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_SURNAME As TextField
    Public s_FIRST_NAME As TextField
    Public s_BIRTH_DATE As DateField
    Public s_ENROL_YEAR As IntegerField
    Public Hidden_NewStudentID As TextField
    Public Sub New()
    s_SURNAME = New TextField("", Nothing)
    s_FIRST_NAME = New TextField("", Nothing)
    s_BIRTH_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    s_ENROL_YEAR = New IntegerField("", Nothing)
    Hidden_NewStudentID = New TextField("", Nothing)
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
        If Not IsNothing(DBUtility.GetInitialValue("s_ENROL_YEAR")) Then
        item.s_ENROL_YEAR.SetValue(DBUtility.GetInitialValue("s_ENROL_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_NewStudentID")) Then
        item.Hidden_NewStudentID.SetValue(DBUtility.GetInitialValue("Hidden_NewStudentID"))
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
                Case "s_ENROL_YEAR"
                    Return s_ENROL_YEAR
                Case "Hidden_NewStudentID"
                    Return Hidden_NewStudentID
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
                Case "s_ENROL_YEAR"
                    s_ENROL_YEAR = CType(value, IntegerField)
                Case "Hidden_NewStudentID"
                    Hidden_NewStudentID = CType(value, TextField)
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

's_ENROL_YEAR validate @85-AEEE9C34
        If IsNothing(s_ENROL_YEAR.Value) OrElse s_ENROL_YEAR.Value.ToString() ="" Then
            errors.Add("s_ENROL_YEAR",String.Format(Resources.strings.CCS_RequiredField,"s_ENROL_YEAR"))
        End If
'End s_ENROL_YEAR validate

'Record STUDENTSearch Event OnValidate. Action Custom Code @79-73254650
    ' -------------------------
    ' ERA: if the Student ID is not there then check the SURNAME, Firstname, and DOB
	If (s_SURNAME.Value Is Nothing) OrElse s_SURNAME.Value.ToString()="" Then
            errors.Add("s_SURNAME",String.Format("Type a SURNAME.","Surname"))
    End If
	If (s_FIRST_NAME.Value Is Nothing) OrElse s_FIRST_NAME.Value.ToString()="" Then
            errors.Add("s_FIRST_NAME",String.Format("Type a FIRST NAME.","First Name"))
    End If
	If (s_BIRTH_DATE.Value Is Nothing) OrElse s_BIRTH_DATE.Value.ToString()="" Then
            errors.Add("s_BIRTH_DATE",String.Format("Type a BIRTH DATE.","Birth Date"))
    End If
    ' -------------------------
'End Record STUDENTSearch Event OnValidate. Action Custom Code

'Record STUDENTSearch Event OnValidate. Action Custom Code @83-73254650
    ' -------------------------
    'Nov-2018|EA| get student details and check if exists - if not, then will create record
    if errors.Count = 0 then
    	dim tmpSname as string = s_SURNAME.Value.ToString()
    	dim tmpFname as string = s_FIRST_NAME.Value.ToString()
    	dim tmpDOB as string = s_BIRTH_DATE.Value.ToString()
    	dim tmpWhere as string = "( SURNAME LIKE '%"+tmpSname+"%' AND FIRST_NAME LIKE '%"+tmpFname+"%' AND BIRTH_DATE = '"+tmpDOB+"' )"
    	dim tmpSTUDENTExists as integer  = 0
    ' -------------------------
'End Record STUDENTSearch Event OnValidate. Action Custom Code

'Record STUDENTSearch Event OnValidate. Action DLookup @80-081E695C
        tmpSTUDENTExists = CType((New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "count(*)" & " FROM " & "STUDENT" & " WHERE " & tmpWhere))).Value, String)
'End Record STUDENTSearch Event OnValidate. Action DLookup

'Record STUDENTSearch Event OnValidate. Action Custom Code @84-73254650
    ' -------------------------
    if tmpSTUDENTExists > 0 then
    	errors.Add("STUDENT", "This Student (or one Very Like them) already exists!")
    end if
    End If
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

'Record STUDENTSearch Data Provider Class Variables @10-CEF1C9E6
    Public Ctrls_SURNAME As TextParameter
    Public Ctrls_FIRST_NAME As TextParameter
    Public Ctrls_BIRTH_DATE As DateParameter
    Public Expr93 As TextParameter
    Public Expr94 As TextParameter
    Public Expr95 As TextParameter
    Public Expr96 As FloatParameter
    Public Expr97 As FloatParameter
    Public Expr98 As BooleanParameter
    Public Expr99 As BooleanParameter
    Public Expr100 As BooleanParameter
    Public Expr101 As TextParameter
    Public Expr102 As DateParameter
    Public Expr103 As TextParameter
    Public Expr104 As TextParameter
    Public Expr106 As FloatParameter
    Protected item As STUDENTSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENTSearch Data Provider Class Variables

'Record STUDENTSearch Data Provider Class Constructor @10-8E0C320C

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STUDENTSearch Data Provider Class Constructor

'Record STUDENTSearch Data Provider Class LoadParams Method @10-B45586B2

    Protected Function LoadParams() As Boolean
        Return True
    End Function
'End Record STUDENTSearch Data Provider Class LoadParams Method

'Record STUDENTSearch Data Provider Class CheckUnique Method @10-C34F04F7

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENTSearchItem) As Boolean
        Return True
    End Function
'End Record STUDENTSearch Data Provider Class CheckUnique Method

'Record STUDENTSearch Data Provider Class PrepareInsert Method @10-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STUDENTSearch Data Provider Class PrepareInsert Method

'Record STUDENTSearch Data Provider Class PrepareInsert Method tail @10-E31F8E2A
    End Sub
'End Record STUDENTSearch Data Provider Class PrepareInsert Method tail

'Record STUDENTSearch Data Provider Class Insert Method @10-A40C8045

    Public Function InsertItem(ByVal item As STUDENTSearchItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO STUDENT({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENTSearch Data Provider Class Insert Method

'Record STUDENTSearch Build insert @10-29482A9E
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        allEmptyFlag = item.s_SURNAME.IsEmpty And allEmptyFlag
        If Not item.s_SURNAME.IsEmpty Then
        If IsNothing(item.s_SURNAME.Value) Then
        fieldsList = fieldsList & "SURNAME,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "SURNAME,"
        valuesList = valuesList & Insert.Dao.ToSql(item.s_SURNAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.s_FIRST_NAME.IsEmpty And allEmptyFlag
        If Not item.s_FIRST_NAME.IsEmpty Then
        If IsNothing(item.s_FIRST_NAME.Value) Then
        fieldsList = fieldsList & "FIRST_NAME,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "FIRST_NAME,"
        valuesList = valuesList & Insert.Dao.ToSql(item.s_FIRST_NAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.s_BIRTH_DATE.IsEmpty And allEmptyFlag
        If Not item.s_BIRTH_DATE.IsEmpty Then
        If IsNothing(item.s_BIRTH_DATE.Value) Then
        fieldsList = fieldsList & "BIRTH_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        fieldsList = fieldsList & "BIRTH_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.s_BIRTH_DATE.GetFormattedValue("yyyy-MM-dd HH\:mm\:ss"),FieldType._Date) & ","
        End If
        End If
        allEmptyFlag = (Expr93 Is Nothing) And allEmptyFlag
        If Not (Expr93 Is Nothing) Then
        If IsNothing(Expr93) Then
        fieldsList = fieldsList & "SEX,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "SEX,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr93.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = (Expr94 Is Nothing) And allEmptyFlag
        If Not (Expr94 Is Nothing) Then
        If IsNothing(Expr94) Then
        fieldsList = fieldsList & "CATEGORY_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "CATEGORY_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr94.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = (Expr95 Is Nothing) And allEmptyFlag
        If Not (Expr95 Is Nothing) Then
        If IsNothing(Expr95) Then
        fieldsList = fieldsList & "SUBCATEGORY_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "SUBCATEGORY_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr95.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = (Expr96 Is Nothing) And allEmptyFlag
        If Not (Expr96 Is Nothing) Then
        If IsNothing(Expr96) Then
        fieldsList = fieldsList & "HOME_SCHOOL_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Float) & ","
        Else
        fieldsList = fieldsList & "HOME_SCHOOL_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr96.GetFormattedValue(""),FieldType._Float) & ","
        End If
        End If
        allEmptyFlag = (Expr97 Is Nothing) And allEmptyFlag
        If Not (Expr97 Is Nothing) Then
        If IsNothing(Expr97) Then
        fieldsList = fieldsList & "POSTAL_ADDRESS_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Float) & ","
        Else
        fieldsList = fieldsList & "POSTAL_ADDRESS_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr97.GetFormattedValue(""),FieldType._Float) & ","
        End If
        End If
        allEmptyFlag = (Expr98 Is Nothing) And allEmptyFlag
        If Not (Expr98 Is Nothing) Then
        If IsNothing(Expr98) Then
        fieldsList = fieldsList & "FULL_TIME,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Boolean) & ","
        Else
        fieldsList = fieldsList & "FULL_TIME,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr98.GetFormattedValue(Insert.BoolFormat),FieldType._Boolean) & ","
        End If
        End If
        allEmptyFlag = (Expr99 Is Nothing) And allEmptyFlag
        If Not (Expr99 Is Nothing) Then
        If IsNothing(Expr99) Then
        fieldsList = fieldsList & "OS_FULL_FEE_PAYING,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Boolean) & ","
        Else
        fieldsList = fieldsList & "OS_FULL_FEE_PAYING,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr99.GetFormattedValue(Insert.BoolFormat),FieldType._Boolean) & ","
        End If
        End If
        allEmptyFlag = (Expr100 Is Nothing) And allEmptyFlag
        If Not (Expr100 Is Nothing) Then
        If IsNothing(Expr100) Then
        fieldsList = fieldsList & "ADDRESS_REVIEW_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Boolean) & ","
        Else
        fieldsList = fieldsList & "ADDRESS_REVIEW_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr100.GetFormattedValue(Insert.BoolFormat),FieldType._Boolean) & ","
        End If
        End If
        allEmptyFlag = (Expr101 Is Nothing) And allEmptyFlag
        If Not (Expr101 Is Nothing) Then
        If IsNothing(Expr101) Then
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr101.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = (Expr102 Is Nothing) And allEmptyFlag
        If Not (Expr102 Is Nothing) Then
        If IsNothing(Expr102) Then
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr102.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        End If
        allEmptyFlag = (Expr103 Is Nothing) And allEmptyFlag
        If Not (Expr103 Is Nothing) Then
        If IsNothing(Expr103) Then
        fieldsList = fieldsList & "PORTAL_ACCESS,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "PORTAL_ACCESS,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr103.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = (Expr104 Is Nothing) And allEmptyFlag
        If Not (Expr104 Is Nothing) Then
        If IsNothing(Expr104) Then
        fieldsList = fieldsList & "ENROLLEDBEFORE,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "ENROLLEDBEFORE,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr104.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = (Expr106 Is Nothing) And allEmptyFlag
        If Not (Expr106 Is Nothing) Then
        If IsNothing(Expr106) Then
        fieldsList = fieldsList & "ATTENDING_SCHOOL_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Float) & ","
        Else
        fieldsList = fieldsList & "ATTENDING_SCHOOL_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr106.GetFormattedValue(""),FieldType._Float) & ","
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
'End Record STUDENTSearch Build insert

'Record STUDENTSearch Event AfterExecuteInsert. Action Custom Code @88-73254650
    ' -------------------------
    'STUDENTSearchData
    item.Hidden_NewStudentID.Value = CType((New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT IDENT_CURRENT('STUDENT')"))).Value, String)
    ' -------------------------
'End Record STUDENTSearch Event AfterExecuteInsert. Action Custom Code

    ' -------------------------
  	' Dec-2018|EA| if ExprKey1 =1 then Ok and get ExprKey8, if < 0 then error
  	'HttpContext.Current.Session("notifymessage") = ExprKey8
'  	if (ExprKey1.Value = 1) then
  		' should be student ID, so add parameters STUDENT_ID ExprKey8 and ENROLMENT_YEAR item.s_ENROL_YEAR to redirect
'  		System.Web.HttpContext.Current.Response.Write(ExprKey8.Value)
'  	else
  		' some error so show message as error
  		'result = 0
'  		System.Web.HttpContext.Current.Response.Write(ExprKey8.Value)
'  	end if
    ' -------------------------


'Record STUDENTSearch AfterExecuteInsert @10-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENTSearch AfterExecuteInsert

'Record STUDENTSearch Data Provider Class GetResultSet Method @10-E82B3386

    Public Sub FillItem(ByVal item As STUDENTSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENTSearch Data Provider Class GetResultSet Method

'Record STUDENTSearch BeforeBuildSelect @10-5D194071
        Select_.Parameters.Clear()
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENTSearch BeforeBuildSelect

'Record STUDENTSearch BeforeExecuteSelect @10-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENTSearch BeforeExecuteSelect

'Record STUDENTSearch AfterExecuteSelect @10-7B594618
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
        Else
            IsInsertMode = True
        End If
'End Record STUDENTSearch AfterExecuteSelect

'Record STUDENTSearch AfterExecuteSelect tail @10-E31F8E2A
    End Sub
'End Record STUDENTSearch AfterExecuteSelect tail

'Record STUDENTSearch Data Provider Class @10-A61BA892
End Class

'End Record STUDENTSearch Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

