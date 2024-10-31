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

Namespace DECV_PROD2007.popup_StudentSearch 'Namespace @1-A40F6DF6

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

'Record STUDENT_STUDENT_ENROLMENT Item Class @14-1A63FAE6
Public Class STUDENT_STUDENT_ENROLMENTItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_SURNAME As TextField
    Public Sub New()
    s_SURNAME = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_STUDENT_ENROLMENTItem
        Dim item As STUDENT_STUDENT_ENROLMENTItem = New STUDENT_STUDENT_ENROLMENTItem()
        If Not IsNothing(DBUtility.GetInitialValue("s_SURNAME")) Then
        item.s_SURNAME.SetValue(DBUtility.GetInitialValue("s_SURNAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_SURNAME"
                    Return s_SURNAME
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
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

    Public Sub Validate(ByVal provider As STUDENT_STUDENT_ENROLMENTDataProvider)
'End Record STUDENT_STUDENT_ENROLMENT Item Class

'Record STUDENT_STUDENT_ENROLMENT Item Class tail @14-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_STUDENT_ENROLMENT Item Class tail

'Record STUDENT_STUDENT_ENROLMENT Data Provider Class @14-0B15F394
Public Class STUDENT_STUDENT_ENROLMENTDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_STUDENT_ENROLMENT Data Provider Class

'Record STUDENT_STUDENT_ENROLMENT Data Provider Class Variables @14-EEFBB704
    Protected item As STUDENT_STUDENT_ENROLMENTItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_STUDENT_ENROLMENT Data Provider Class Variables

'Record STUDENT_STUDENT_ENROLMENT Data Provider Class GetResultSet Method @14-7F461A96

    Public Sub FillItem(ByVal item As STUDENT_STUDENT_ENROLMENTItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record STUDENT_STUDENT_ENROLMENT Data Provider Class GetResultSet Method

'Record STUDENT_STUDENT_ENROLMENT BeforeBuildSelect @14-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_STUDENT_ENROLMENT BeforeBuildSelect

'Record STUDENT_STUDENT_ENROLMENT AfterExecuteSelect @14-79426A21
        End If
            IsInsertMode = True
'End Record STUDENT_STUDENT_ENROLMENT AfterExecuteSelect

'Record STUDENT_STUDENT_ENROLMENT AfterExecuteSelect tail @14-E31F8E2A
    End Sub
'End Record STUDENT_STUDENT_ENROLMENT AfterExecuteSelect tail

'Record STUDENT_STUDENT_ENROLMENT Data Provider Class @14-A61BA892
End Class

'End Record STUDENT_STUDENT_ENROLMENT Data Provider Class

'Grid STUDENT_STUDENT_ENROLMENT1 Item Class @2-DBFC031A
Public Class STUDENT_STUDENT_ENROLMENT1Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STUDENT_STUDENT_ID As FloatField
    Public STUDENT_STUDENT_IDHref As Object
    Public STUDENT_STUDENT_IDHrefParameters As LinkParameterCollection
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public YEAR_LEVEL As IntegerField
    Public SEX As TextField
    Public ENROLMENT_YEAR As FloatField
    Public Sub New()
    STUDENT_STUDENT_ID = New FloatField("",Nothing)
    STUDENT_STUDENT_IDHrefParameters = New LinkParameterCollection()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    YEAR_LEVEL = New IntegerField("", Nothing)
    SEX = New TextField("", Nothing)
    ENROLMENT_YEAR = New FloatField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STUDENT_STUDENT_ID"
                    Return Me.STUDENT_STUDENT_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "YEAR_LEVEL"
                    Return Me.YEAR_LEVEL
                Case "SEX"
                    Return Me.SEX
                Case "ENROLMENT_YEAR"
                    Return Me.ENROLMENT_YEAR
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_STUDENT_ID"
                    Me.STUDENT_STUDENT_ID = CType(Value,FloatField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "YEAR_LEVEL"
                    Me.YEAR_LEVEL = CType(Value,IntegerField)
                Case "SEX"
                    Me.SEX = CType(Value,TextField)
                Case "ENROLMENT_YEAR"
                    Me.ENROLMENT_YEAR = CType(Value,FloatField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STUDENT_STUDENT_ENROLMENT1 Item Class

'Grid STUDENT_STUDENT_ENROLMENT1 Data Provider Class Header @2-3187D379
Public Class STUDENT_STUDENT_ENROLMENT1DataProvider
Inherits GridDataProviderBase
'End Grid STUDENT_STUDENT_ENROLMENT1 Data Provider Class Header

'Grid STUDENT_STUDENT_ENROLMENT1 Data Provider Class Variables @2-BF268F55

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_STUDENT_ID
        Sorter_SURNAME
        Sorter_FIRST_NAME
        Sorter_YEAR_LEVEL
        Sorter_SEX
        Sorter_ENROLMENT_YEAR
    End Enum

    Private SortFieldsNames As String() = New String() {"SURNAME","STUDENT.STUDENT_ID","SURNAME","FIRST_NAME","YEAR_LEVEL","SEX","ENROLMENT_YEAR"}
    Private SortFieldsNamesDesc As String() = New string() {"SURNAME","STUDENT.STUDENT_ID DESC","SURNAME DESC","FIRST_NAME DESC","YEAR_LEVEL DESC","SEX DESC","ENROLMENT_YEAR DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 80
    Public PageNumber As Integer = 1
    Public Urls_SURNAME  As TextParameter
'End Grid STUDENT_STUDENT_ENROLMENT1 Data Provider Class Variables

'Grid STUDENT_STUDENT_ENROLMENT1 Data Provider Class GetResultSet Method @2-F6262E51

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} STUDENT.STUDENT_ID AS STUDENT_STUDENT_ID, SURNAME, " & vbCrLf & _
          "FIRST_NAME, SEX, YEAR_LEVEL, " & vbCrLf & _
          "ENROLMENT_YEAR " & vbCrLf & _
          "FROM STUDENT INNER JOIN STUDENT_ENROLMENT ON" & vbCrLf & _
          "STUDENT.STUDENT_ID = STUDENT_ENROLMENT.STUDENT_ID {SQL_Where} {SQL_OrderBy}", New String(){"expr13","And","s_SURNAME17"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STUDENT INNER JOIN STUDENT_ENROLMENT ON" & vbCrLf & _
          "STUDENT.STUDENT_ID = STUDENT_ENROLMENT.STUDENT_ID", New String(){"expr13","And","s_SURNAME17"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid STUDENT_STUDENT_ENROLMENT1 Data Provider Class GetResultSet Method

'Grid STUDENT_STUDENT_ENROLMENT1 Data Provider Class GetResultSet Method @2-43C23643
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STUDENT_STUDENT_ENROLMENT1Item()
'End Grid STUDENT_STUDENT_ENROLMENT1 Data Provider Class GetResultSet Method

'Before build Select @2-09464E78
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_SURNAME17",Urls_SURNAME, "","STUDENT.SURNAME",Condition.Contains,False)
        Select_.Parameters.Add("expr13","(ENROLMENT_YEAR = year(getdate()))")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-E1239C81
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STUDENT_STUDENT_ENROLMENT1Item
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

'After execute Select @2-F677661D
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENT_STUDENT_ENROLMENT1Item(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-F100DDF9
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_STUDENT_ENROLMENT1Item = New STUDENT_STUDENT_ENROLMENT1Item()
                item.STUDENT_STUDENT_ID.SetValue(dr(i)("STUDENT_STUDENT_ID"),"")
                item.STUDENT_STUDENT_IDHref = ""
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
                item.SEX.SetValue(dr(i)("SEX"),"")
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

'Grid Data Provider tail @2-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

