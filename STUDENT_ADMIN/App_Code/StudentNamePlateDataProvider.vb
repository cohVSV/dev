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

Namespace DECV_PROD2007.StudentNamePlate 'Namespace @1-59EF69EE

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

'Report viewStudentSummary_Detail Item Class @2-250A04A9
Public Class viewStudentSummary_DetailItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public first_name As TextField
    Public surname As TextField
    Public STUDENT_ID As FloatField
    Public subcategory_full_title As TextField
    Public GENDER As TextField
    Public BIRTH_DATE As TextField
    Public AGE As TextField
    Public ENROLMENT_STATUS As TextField
    Public YEAR_LEVEL As IntegerField
    Public ATAR_REQUIRED As TextField
    Public lblATAR_REQUIRED As TextField
    Public Sub New()
    first_name = New TextField("", Nothing)
    surname = New TextField("", Nothing)
    STUDENT_ID = New FloatField("", Nothing)
    subcategory_full_title = New TextField("", Nothing)
    GENDER = New TextField("", Nothing)
    BIRTH_DATE = New TextField("dd/mm/yyyy", Nothing)
    AGE = New TextField("", Nothing)
    ENROLMENT_STATUS = New TextField("", Nothing)
    YEAR_LEVEL = New IntegerField("", Nothing)
    ATAR_REQUIRED = New TextField("", Nothing)
    lblATAR_REQUIRED = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "first_name"
                    Return Me.first_name
                Case "surname"
                    Return Me.surname
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "subcategory_full_title"
                    Return Me.subcategory_full_title
                Case "GENDER"
                    Return Me.GENDER
                Case "BIRTH_DATE"
                    Return Me.BIRTH_DATE
                Case "AGE"
                    Return Me.AGE
                Case "ENROLMENT_STATUS"
                    Return Me.ENROLMENT_STATUS
                Case "YEAR_LEVEL"
                    Return Me.YEAR_LEVEL
                Case "ATAR_REQUIRED"
                    Return Me.ATAR_REQUIRED
                Case "lblATAR_REQUIRED"
                    Return Me.lblATAR_REQUIRED
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "first_name"
                    Me.first_name = CType(Value,TextField)
                Case "surname"
                    Me.surname = CType(Value,TextField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "subcategory_full_title"
                    Me.subcategory_full_title = CType(Value,TextField)
                Case "GENDER"
                    Me.GENDER = CType(Value,TextField)
                Case "BIRTH_DATE"
                    Me.BIRTH_DATE = CType(Value,TextField)
                Case "AGE"
                    Me.AGE = CType(Value,TextField)
                Case "ENROLMENT_STATUS"
                    Me.ENROLMENT_STATUS = CType(Value,TextField)
                Case "YEAR_LEVEL"
                    Me.YEAR_LEVEL = CType(Value,IntegerField)
                Case "ATAR_REQUIRED"
                    Me.ATAR_REQUIRED = CType(Value,TextField)
                Case "lblATAR_REQUIRED"
                    Me.lblATAR_REQUIRED = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Report viewStudentSummary_Detail Item Class

'Report viewStudentSummary_Detail Data Provider Class Header @2-930AA5C9
Public Class viewStudentSummary_DetailDataProvider
Inherits GridDataProviderBase
'End Report viewStudentSummary_Detail Data Provider Class Header

'Report viewStudentSummary_Detail Data Provider Class Variables @2-249200FE

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public UrlSTUDENT_ID  As FloatParameter
    Public UrlENROLMENT_YEAR  As FloatParameter
'End Report viewStudentSummary_Detail Data Provider Class Variables

'Report viewStudentSummary_Detail Data Provider Class GetResultSet Method @2-EE516B72

    Public Sub New()
        Select_=new TableCommand("SELECT STUDENT_ID, surname, first_name, subcategory_full_title, ENROLMENT_STATUS, " & vbCrLf & _
          "YEAR_LEVEL, birth_date, SEX, Age, " & vbCrLf & _
          "ATAR_REQUIRED " & vbCrLf & _
          "FROM viewStudentSummary_Details {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID13","And","ENROLMENT_YEAR14"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Report viewStudentSummary_Detail Data Provider Class GetResultSet Method

'Report viewStudentSummary_Detail Data Provider Class GetResultSet Method @2-8BC857DD
    Public Function GetResultSet(ops As FormSupportedOperations) As viewStudentSummary_DetailItem()
'End Report viewStudentSummary_Detail Data Provider Class GetResultSet Method

'Before build Select @2-DFE3AC4D
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID13",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("ENROLMENT_YEAR14",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-40069841
        Dim ds As DataSet = Nothing
        Dim result(-1) As viewStudentSummary_DetailItem
        If ops.AllowRead Then
            Try
                    ds=ExecuteSelect()
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @2-B1FF7156
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New viewStudentSummary_DetailItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-F78DBF7C
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as viewStudentSummary_DetailItem = New viewStudentSummary_DetailItem()
                item.first_name.SetValue(dr(i)("first_name"),"")
                item.surname.SetValue(dr(i)("surname"),"")
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.subcategory_full_title.SetValue(dr(i)("subcategory_full_title"),"")
                item.GENDER.SetValue(dr(i)("SEX"),"")
                item.BIRTH_DATE.SetValue(dr(i)("birth_date"),"")
                item.AGE.SetValue(dr(i)("Age"),"")
                item.ENROLMENT_STATUS.SetValue(dr(i)("ENROLMENT_STATUS"),"")
                item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
                item.ATAR_REQUIRED.SetValue(dr(i)("ATAR_REQUIRED"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Return result 
    End Function
'End After execute Select tail

'Report Data Provider tail @2-A61BA892
End Class
'End Report Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

