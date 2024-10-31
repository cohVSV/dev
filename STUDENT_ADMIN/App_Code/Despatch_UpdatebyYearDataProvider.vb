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

Namespace DECV_PROD2007.Despatch_UpdatebyYear 'Namespace @1-CC8ED6E9

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

'Record SUBJECTSearch Item Class @8-E47466C5
Public Class SUBJECTSearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_YEAR_LEVEL As IntegerField
    Public s_YEAR_LEVELItems As ItemCollection
    Public Sub New()
    s_YEAR_LEVEL = New IntegerField("", Nothing)
    s_YEAR_LEVELItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As SUBJECTSearchItem
        Dim item As SUBJECTSearchItem = New SUBJECTSearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("s_YEAR_LEVEL")) Then
        item.s_YEAR_LEVEL.SetValue(DBUtility.GetInitialValue("s_YEAR_LEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_YEAR_LEVEL"
                    Return s_YEAR_LEVEL
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_YEAR_LEVEL"
                    s_YEAR_LEVEL = CType(value, IntegerField)
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

    Public Sub Validate(ByVal provider As SUBJECTSearchDataProvider)
'End Record SUBJECTSearch Item Class

'Record SUBJECTSearch Item Class tail @8-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record SUBJECTSearch Item Class tail

'Record SUBJECTSearch Data Provider Class @8-A1051136
Public Class SUBJECTSearchDataProvider
Inherits RecordDataProviderBase
'End Record SUBJECTSearch Data Provider Class

'Record SUBJECTSearch Data Provider Class Variables @8-82293503
    Protected s_YEAR_LEVELDataCommand As DataCommand=new SqlCommand("select distinct YEAR_LEVEL" & vbCrLf & _
          "from SUBJECT" & vbCrLf & _
          "where CAMPUS_CODE = 'D' and STATUS = 1",Settings.connDECVPRODSQL2005DataAccessObject)
    Protected item As SUBJECTSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record SUBJECTSearch Data Provider Class Variables

'Record SUBJECTSearch Data Provider Class GetResultSet Method @8-B9833B10

    Public Sub FillItem(ByVal item As SUBJECTSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record SUBJECTSearch Data Provider Class GetResultSet Method

'Record SUBJECTSearch BeforeBuildSelect @8-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record SUBJECTSearch BeforeBuildSelect

'Record SUBJECTSearch AfterExecuteSelect @8-83591636
        End If
            IsInsertMode = True
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record SUBJECTSearch AfterExecuteSelect

'ListBox s_YEAR_LEVEL Initialize Data Source @10-791531ED
        s_YEAR_LEVELDataCommand.Dao._optimized = False
        Dim s_YEAR_LEVELtableIndex As Integer = 0
        s_YEAR_LEVELDataCommand.OrderBy = ""
        s_YEAR_LEVELDataCommand.Parameters.Clear()
'End ListBox s_YEAR_LEVEL Initialize Data Source

'ListBox s_YEAR_LEVEL BeforeExecuteSelect @10-5D4F2240
        Try
            ListBoxSource=s_YEAR_LEVELDataCommand.Execute().Tables(s_YEAR_LEVELtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox s_YEAR_LEVEL BeforeExecuteSelect

'ListBox s_YEAR_LEVEL AfterExecuteSelect @10-898855A0
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New IntegerField("", ListBoxSource(j)("YEAR_LEVEL"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("YEAR_LEVEL")
            item.s_YEAR_LEVELItems.Add(Key, Val)
        Next
'End ListBox s_YEAR_LEVEL AfterExecuteSelect

'Record SUBJECTSearch AfterExecuteSelect tail @8-E31F8E2A
    End Sub
'End Record SUBJECTSearch AfterExecuteSelect tail

'Record SUBJECTSearch Data Provider Class @8-A61BA892
End Class

'End Record SUBJECTSearch Data Provider Class

'Record UpdateForm Item Class @53-A1E9157E
Public Class UpdateFormItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public lblYearLevel2 As TextField
    Public despatchdate As DateField
    Public book_range_from As IntegerField
    Public book_range_to As IntegerField
    Public semester_1 As BooleanField
    Public semester_1CheckedValue As BooleanField
    Public semester_1UncheckedValue As BooleanField
    Public semester_2 As BooleanField
    Public semester_2CheckedValue As BooleanField
    Public semester_2UncheckedValue As BooleanField
    Public semester_both As BooleanField
    Public semester_bothCheckedValue As BooleanField
    Public semester_bothUncheckedValue As BooleanField
    Public lblSelections As TextField
    Public Sub New()
    lblYearLevel2 = New TextField("", Nothing)
    despatchdate = New DateField("dd\/MM\/yyyy", now())
    book_range_from = New IntegerField("", Nothing)
    book_range_to = New IntegerField("", Nothing)
    semester_1 = New BooleanField(Settings.BoolFormat, false)
    semester_1CheckedValue = New BooleanField(Settings.BoolFormat, true)
    semester_1UncheckedValue = New BooleanField(Settings.BoolFormat, false)
    semester_2 = New BooleanField(Settings.BoolFormat, false)
    semester_2CheckedValue = New BooleanField(Settings.BoolFormat, true)
    semester_2UncheckedValue = New BooleanField(Settings.BoolFormat, false)
    semester_both = New BooleanField(Settings.BoolFormat, false)
    semester_bothCheckedValue = New BooleanField(Settings.BoolFormat, true)
    semester_bothUncheckedValue = New BooleanField(Settings.BoolFormat, false)
    lblSelections = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As UpdateFormItem
        Dim item As UpdateFormItem = New UpdateFormItem()
        If Not IsNothing(DBUtility.GetInitialValue("lblYearLevel2")) Then
        item.lblYearLevel2.SetValue(DBUtility.GetInitialValue("lblYearLevel2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("despatchdate")) Then
        item.despatchdate.SetValue(DBUtility.GetInitialValue("despatchdate"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("book_range_from")) Then
        item.book_range_from.SetValue(DBUtility.GetInitialValue("book_range_from"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("book_range_to")) Then
        item.book_range_to.SetValue(DBUtility.GetInitialValue("book_range_to"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("semester_1")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("semester_1")) Then
            item.semester_1.Value = item.semester_1CheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("semester_2")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("semester_2")) Then
            item.semester_2.Value = item.semester_2CheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("semester_both")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("semester_both")) Then
            item.semester_both.Value = item.semester_bothCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoUpdate")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblSelections")) Then
        item.lblSelections.SetValue(DBUtility.GetInitialValue("lblSelections"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "lblYearLevel2"
                    Return lblYearLevel2
                Case "despatchdate"
                    Return despatchdate
                Case "book_range_from"
                    Return book_range_from
                Case "book_range_to"
                    Return book_range_to
                Case "semester_1"
                    Return semester_1
                Case "semester_2"
                    Return semester_2
                Case "semester_both"
                    Return semester_both
                Case "lblSelections"
                    Return lblSelections
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblYearLevel2"
                    lblYearLevel2 = CType(value, TextField)
                Case "despatchdate"
                    despatchdate = CType(value, DateField)
                Case "book_range_from"
                    book_range_from = CType(value, IntegerField)
                Case "book_range_to"
                    book_range_to = CType(value, IntegerField)
                Case "semester_1"
                    semester_1 = CType(value, BooleanField)
                Case "semester_2"
                    semester_2 = CType(value, BooleanField)
                Case "semester_both"
                    semester_both = CType(value, BooleanField)
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

'despatchdate validate @46-D6B02C93
        If IsNothing(despatchdate.Value) OrElse despatchdate.Value.ToString() ="" Then
            errors.Add("despatchdate",String.Format(Resources.strings.CCS_RequiredField,"Despatch Date"))
        End If
'End despatchdate validate

'book_range_from validate @47-8EACADD0
        If IsNothing(book_range_from.Value) OrElse book_range_from.Value.ToString() ="" Then
            errors.Add("book_range_from",String.Format(Resources.strings.CCS_RequiredField,"Book Range From"))
        End If
        If (Not IsNothing(book_range_from.Value)) And (Not book_range_from.value <= book_range_to.value) Then
            errors.Add("book_range_from","[To Book Range] must not be less than [From Book] Range")
        End If
'End book_range_from validate

'book_range_to validate @48-3FE4114A
        If IsNothing(book_range_to.Value) OrElse book_range_to.Value.ToString() ="" Then
            errors.Add("book_range_to",String.Format(Resources.strings.CCS_RequiredField,"Book Range To"))
        End If
'End book_range_to validate

'Record UpdateForm Event OnValidate. Action Custom Code @55-73254650
    ' -------------------------
    'ERA: better handling of multi select checkbox
	If ((semester_1.value = false) AND (semester_2.value = false) AND (semester_both.value = false)) Then
		errors.Add("semester_both","At least one Semester checkbox must be ticked.")
    End If
    ' -------------------------
'End Record UpdateForm Event OnValidate. Action Custom Code

'Record UpdateForm Item Class tail @53-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record UpdateForm Item Class tail

'Record UpdateForm Data Provider Class @53-4ED18962
Public Class UpdateFormDataProvider
Inherits RecordDataProviderBase
'End Record UpdateForm Data Provider Class

'Record UpdateForm Data Provider Class Variables @53-11BE28A5
    Protected item As UpdateFormItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record UpdateForm Data Provider Class Variables

'Record UpdateForm Data Provider Class GetResultSet Method @53-6AD78FCC

    Public Sub FillItem(ByVal item As UpdateFormItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record UpdateForm Data Provider Class GetResultSet Method

'Record UpdateForm BeforeBuildSelect @53-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record UpdateForm BeforeBuildSelect

'Record UpdateForm AfterExecuteSelect @53-79426A21
        End If
            IsInsertMode = True
'End Record UpdateForm AfterExecuteSelect

'Record UpdateForm AfterExecuteSelect tail @53-E31F8E2A
    End Sub
'End Record UpdateForm AfterExecuteSelect tail

'Record UpdateForm Data Provider Class @53-A61BA892
End Class

'End Record UpdateForm Data Provider Class

'Grid SUBJECT Item Class @3-68021591
Public Class SUBJECTItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public lblYearLevel As TextField
    Public SUBJECT_TotalRecords As TextField
    Public cbox As TextField
    Public cboxCheckedValue As TextField
    Public cboxUncheckedValue As TextField
    Public SUBJECT_ID As IntegerField
    Public SUBJECT_TITLE As TextField
    Public DEFAULT_SEMESTER As TextField
    Public Sub New()
    lblYearLevel = New TextField("", Nothing)
    SUBJECT_TotalRecords = New TextField("", Nothing)
    cbox = New TextField("", "ON")
    cboxCheckedValue = New TextField("", "ON")
    cboxUncheckedValue = New TextField("", "OFF")
    SUBJECT_ID = New IntegerField("", Nothing)
    SUBJECT_TITLE = New TextField("", Nothing)
    DEFAULT_SEMESTER = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "lblYearLevel"
                    Return Me.lblYearLevel
                Case "SUBJECT_TotalRecords"
                    Return Me.SUBJECT_TotalRecords
                Case "cbox"
                    Return Me.cbox
                Case "SUBJECT_ID"
                    Return Me.SUBJECT_ID
                Case "SUBJECT_TITLE"
                    Return Me.SUBJECT_TITLE
                Case "DEFAULT_SEMESTER"
                    Return Me.DEFAULT_SEMESTER
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblYearLevel"
                    Me.lblYearLevel = CType(Value,TextField)
                Case "SUBJECT_TotalRecords"
                    Me.SUBJECT_TotalRecords = CType(Value,TextField)
                Case "cbox"
                    Me.cbox = CType(Value,TextField)
                Case "SUBJECT_ID"
                    Me.SUBJECT_ID = CType(Value,IntegerField)
                Case "SUBJECT_TITLE"
                    Me.SUBJECT_TITLE = CType(Value,TextField)
                Case "DEFAULT_SEMESTER"
                    Me.DEFAULT_SEMESTER = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid SUBJECT Item Class

'Grid SUBJECT Data Provider Class Header @3-0DD17C44
Public Class SUBJECTDataProvider
Inherits GridDataProviderBase
'End Grid SUBJECT Data Provider Class Header

'Grid SUBJECT Data Provider Class Variables @3-94D274A8

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {"SUBJECT_ID"}
    Private SortFieldsNamesDesc As String() = New string() {"SUBJECT_ID"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 80
    Public PageNumber As Integer = 1
    Public Urls_YEAR_LEVEL  As IntegerParameter
'End Grid SUBJECT Data Provider Class Variables

'Grid SUBJECT Data Provider Class GetResultSet Method @3-1A70C163

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM SUBJECT {SQL_Where} {SQL_OrderBy}", New String(){"expr5","And","expr6","And","s_YEAR_LEVEL13"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM SUBJECT", New String(){"expr5","And","expr6","And","s_YEAR_LEVEL13"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid SUBJECT Data Provider Class GetResultSet Method

'Grid SUBJECT Data Provider Class GetResultSet Method @3-40D1E8E8
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As SUBJECTItem()
'End Grid SUBJECT Data Provider Class GetResultSet Method

'Before build Select @3-44F2D304
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_YEAR_LEVEL13",Urls_YEAR_LEVEL, "","YEAR_LEVEL",Condition.Equal,False)
        Select_.Parameters.Add("expr5","(STATUS = 1)")
        Select_.Parameters.Add("expr6","(CAMPUS_CODE='D')")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @3-C3D26DF9
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As SUBJECTItem
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

'After execute Select @3-A15FCA2A
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New SUBJECTItem(dr.Count-1) {}
'End After execute Select

'After execute Select @3-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @3-926E5A0D
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as SUBJECTItem = New SUBJECTItem()
                item.SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
                item.SUBJECT_TITLE.SetValue(dr(i)("SUBJECT_TITLE"),"")
                item.DEFAULT_SEMESTER.SetValue(dr(i)("DEFAULT_SEMESTER"),"")
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

