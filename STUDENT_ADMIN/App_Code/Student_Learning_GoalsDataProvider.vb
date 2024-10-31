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

Namespace DECV_PROD2007.Student_Learning_Goals 'Namespace @1-1CFB2AE7

'Page Data Class @1-9DBCC9EC
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Link_Backtosummary As TextField
    Public Link_BacktosummaryHref As Object
    Public Link_BacktosummaryHrefParameters As LinkParameterCollection
    Public Sub New()
        Link_Backtosummary = New TextField("",Nothing)
        Link_BacktosummaryHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Link_Backtosummary.SetValue(DBUtility.GetInitialValue("Link_Backtosummary"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Link_Backtosummary"
                    Return Link_Backtosummary
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link_Backtosummary"
                    Link_Backtosummary = CType(value, TextField)
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
'DEL      ' load up the previous school id
'DEL      If IsNothing(PREVIOUS_SCHOOL_ID.Value) OrElse PREVIOUS_SCHOOL_ID.Value.ToString() ="" Then
'DEL  	    tmpPrevSchoolID = ""
'DEL  	else
'DEL  		tmpPrevSchoolID = PREVIOUS_SCHOOL_ID.Value.ToString()	' code generation doesn't like it for some reason, so done here manually.
'DEL  	end if
'DEL  	
'DEL  	If (tmpPrevSchoolID <> "") Then
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL      ' ERA: if the previous school id is entered then if there are no schools matching then raise an error
'DEL  		If (tmpPrevSchoolID.ToString() <> "") and (tmpSchoolCount = 0) Then
'DEL              errors.Add("PREVIOUS_SCHOOL_ID", "There is no School for that PREVIOUS SCHOOL ID. Please check it, or leave it blank")
'DEL  	   	End If
'DEL  
'DEL  	End If	' DB lookup
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL      'Sept-2018|EA| if any Errors, then change text on main error BLAHBLAH
'DEL      If (errors.Count > 0) Then
'DEL      	errors.Add("Form",String.Format("Check errors! Scroll down page to check for errors!"))
'DEL      End If
'DEL      ' -------------------------

'Grid STUDENT_LEARNING_GOALS1 Item Class @166-6D2BD361
Public Class STUDENT_LEARNING_GOALS1Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STUDENT_LEARNING_GOALS1_Insert As TextField
    Public STUDENT_LEARNING_GOALS1_InsertHref As Object
    Public STUDENT_LEARNING_GOALS1_InsertHrefParameters As LinkParameterCollection
    Public Detail As TextField
    Public DetailHref As Object
    Public DetailHrefParameters As LinkParameterCollection
    Public GOAL_TITLE As TextField
    Public GOAL_CATEGORY As TextField
    Public GOAL_BY_DATE As DateField
    Public GOAL_RESULT As TextField
    Public LAST_ALTERED_DATE As DateField
    Public CREATED_DATETIME As DateField
    Public GOAL_DETAIL As TextField
    Public LAST_ALTERED_BY As TextField
    Public Sub New()
    STUDENT_LEARNING_GOALS1_Insert = New TextField("",Nothing)
    STUDENT_LEARNING_GOALS1_InsertHrefParameters = New LinkParameterCollection()
    Detail = New TextField("",Nothing)
    DetailHrefParameters = New LinkParameterCollection()
    GOAL_TITLE = New TextField("", Nothing)
    GOAL_CATEGORY = New TextField("", Nothing)
    GOAL_BY_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    GOAL_RESULT = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    CREATED_DATETIME = New DateField("dd\/MM\/yyyy", Nothing)
    GOAL_DETAIL = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STUDENT_LEARNING_GOALS1_Insert"
                    Return Me.STUDENT_LEARNING_GOALS1_Insert
                Case "Detail"
                    Return Me.Detail
                Case "GOAL_TITLE"
                    Return Me.GOAL_TITLE
                Case "GOAL_CATEGORY"
                    Return Me.GOAL_CATEGORY
                Case "GOAL_BY_DATE"
                    Return Me.GOAL_BY_DATE
                Case "GOAL_RESULT"
                    Return Me.GOAL_RESULT
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "CREATED_DATETIME"
                    Return Me.CREATED_DATETIME
                Case "GOAL_DETAIL"
                    Return Me.GOAL_DETAIL
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_LEARNING_GOALS1_Insert"
                    Me.STUDENT_LEARNING_GOALS1_Insert = CType(Value,TextField)
                Case "Detail"
                    Me.Detail = CType(Value,TextField)
                Case "GOAL_TITLE"
                    Me.GOAL_TITLE = CType(Value,TextField)
                Case "GOAL_CATEGORY"
                    Me.GOAL_CATEGORY = CType(Value,TextField)
                Case "GOAL_BY_DATE"
                    Me.GOAL_BY_DATE = CType(Value,DateField)
                Case "GOAL_RESULT"
                    Me.GOAL_RESULT = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "CREATED_DATETIME"
                    Me.CREATED_DATETIME = CType(Value,DateField)
                Case "GOAL_DETAIL"
                    Me.GOAL_DETAIL = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STUDENT_LEARNING_GOALS1 Item Class

'Grid STUDENT_LEARNING_GOALS1 Data Provider Class Header @166-80765FD7
Public Class STUDENT_LEARNING_GOALS1DataProvider
Inherits GridDataProviderBase
'End Grid STUDENT_LEARNING_GOALS1 Data Provider Class Header

'Grid STUDENT_LEARNING_GOALS1 Data Provider Class Variables @166-37965B42

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_GOAL_TITLE
        Sorter_GOAL_CATEGORY
        Sorter_GOAL_BY_DATE
        Sorter_GOAL_RESULT
        Sorter_LAST_ALTERED_DATE
        Sorter_CREATED_DATETIME
    End Enum

    Private SortFieldsNames As String() = New String() {"","GOAL_TITLE","GOAL_CATEGORY","GOAL_BY_DATE","GOAL_RESULT","LAST_ALTERED_DATE","CREATED_DATETIME"}
    Private SortFieldsNamesDesc As String() = New string() {"","GOAL_TITLE DESC","GOAL_CATEGORY DESC","GOAL_BY_DATE DESC","GOAL_RESULT DESC","LAST_ALTERED_DATE DESC","CREATED_DATETIME DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 40
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As IntegerParameter
    Public UrlENROLMENT_YEAR  As IntegerParameter
'End Grid STUDENT_LEARNING_GOALS1 Data Provider Class Variables

'Grid STUDENT_LEARNING_GOALS1 Data Provider Class GetResultSet Method @166-979D6C16

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} LEARNING_GOAL_ID, GOAL_TITLE, GOAL_CATEGORY, " & vbCrLf & _
          "GOAL_BY_DATE, GOAL_DETAIL, GOAL_RESULT, RESULT_NOTES, LAST_ALTERED_BY, " & vbCrLf & _
          "LAST_ALTERED_DATE," & vbCrLf & _
          "STUDENT_ID, ENROLMENT_YEAR, " & vbCrLf & _
          "CREATED_DATETIME " & vbCrLf & _
          "FROM STUDENT_LEARNING_GOALS {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID301","And","ENROLMENT_YEAR302"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STUDENT_LEARNING_GOALS", New String(){"STUDENT_ID301","And","ENROLMENT_YEAR302"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid STUDENT_LEARNING_GOALS1 Data Provider Class GetResultSet Method

'Grid STUDENT_LEARNING_GOALS1 Data Provider Class GetResultSet Method @166-22D6F906
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STUDENT_LEARNING_GOALS1Item()
'End Grid STUDENT_LEARNING_GOALS1 Data Provider Class GetResultSet Method

'Before build Select @166-B718DAF6
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID301",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("ENROLMENT_YEAR302",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @166-4209D585
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STUDENT_LEARNING_GOALS1Item
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

'After execute Select @166-442FC3C2
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENT_LEARNING_GOALS1Item(dr.Count-1) {}
'End After execute Select

'After execute Select @166-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @166-349A9AD5
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_LEARNING_GOALS1Item = New STUDENT_LEARNING_GOALS1Item()
                item.STUDENT_LEARNING_GOALS1_InsertHref = "Student_Learning_Goals.aspx"
                item.DetailHref = "Student_Learning_Goals.aspx"
                item.DetailHrefParameters.Add("LEARNING_GOAL_ID",System.Web.HttpUtility.UrlEncode(dr(i)("LEARNING_GOAL_ID").ToString()))
                item.GOAL_TITLE.SetValue(dr(i)("GOAL_TITLE"),"")
                item.GOAL_CATEGORY.SetValue(dr(i)("GOAL_CATEGORY"),"")
                item.GOAL_BY_DATE.SetValue(dr(i)("GOAL_BY_DATE"),Select_.DateFormat)
                item.GOAL_RESULT.SetValue(dr(i)("GOAL_RESULT"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.CREATED_DATETIME.SetValue(dr(i)("CREATED_DATETIME"),Select_.DateFormat)
                item.GOAL_DETAIL.SetValue(dr(i)("GOAL_DETAIL"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @166-A61BA892
End Class
'End Grid Data Provider tail

'Record STUDENT_LEARNING_GOALS2 Item Class @209-F3C5B251
Public Class STUDENT_LEARNING_GOALS2Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public GOAL_TITLE As TextField
    Public STUDENT_ID As FloatField
    Public ENROLMENT_YEAR As FloatField
    Public CREATED_DATETIME As DateField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public GOAL_BY_DATE As DateField
    Public GOAL_CATEGORY As TextField
    Public GOAL_CATEGORYItems As ItemCollection
    Public GOAL_DETAIL As TextField
    Public GOAL_RESULT As TextField
    Public GOAL_RESULTItems As ItemCollection
    Public RESULT_NOTES As TextField
    Public lblLAST_ALTERED_BY As TextField
    Public lblLAST_ALTERED_DATE As DateField
    Public Sub New()
    GOAL_TITLE = New TextField("", Nothing)
    STUDENT_ID = New FloatField("", Nothing)
    ENROLMENT_YEAR = New FloatField("", Nothing)
    CREATED_DATETIME = New DateField("yyyy-MM-dd H\:mm", DateTime.Now)
    LAST_ALTERED_BY = New TextField("", DBUtility.UserLogin.ToUpper)
    LAST_ALTERED_DATE = New DateField("yyyy-MM-dd H\:mm", DateTime.Now)
    GOAL_BY_DATE = New DateField("d\/M\/yyyy", Nothing)
    GOAL_CATEGORY = New TextField("", Nothing)
    GOAL_CATEGORYItems = New ItemCollection()
    GOAL_DETAIL = New TextField("", Nothing)
    GOAL_RESULT = New TextField("", "Unknown")
    GOAL_RESULTItems = New ItemCollection()
    RESULT_NOTES = New TextField("", Nothing)
    lblLAST_ALTERED_BY = New TextField("", Nothing)
    lblLAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_LEARNING_GOALS2Item
        Dim item As STUDENT_LEARNING_GOALS2Item = New STUDENT_LEARNING_GOALS2Item()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("GOAL_TITLE")) Then
        item.GOAL_TITLE.SetValue(DBUtility.GetInitialValue("GOAL_TITLE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_YEAR")) Then
        item.ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CREATED_DATETIME")) Then
        item.CREATED_DATETIME.SetValue(DBUtility.GetInitialValue("CREATED_DATETIME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("GOAL_BY_DATE")) Then
        item.GOAL_BY_DATE.SetValue(DBUtility.GetInitialValue("GOAL_BY_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("GOAL_CATEGORY")) Then
        item.GOAL_CATEGORY.SetValue(DBUtility.GetInitialValue("GOAL_CATEGORY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("GOAL_DETAIL")) Then
        item.GOAL_DETAIL.SetValue(DBUtility.GetInitialValue("GOAL_DETAIL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("GOAL_RESULT")) Then
        item.GOAL_RESULT.SetValue(DBUtility.GetInitialValue("GOAL_RESULT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RESULT_NOTES")) Then
        item.RESULT_NOTES.SetValue(DBUtility.GetInitialValue("RESULT_NOTES"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblLAST_ALTERED_BY")) Then
        item.lblLAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("lblLAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblLAST_ALTERED_DATE")) Then
        item.lblLAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("lblLAST_ALTERED_DATE"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "GOAL_TITLE"
                    Return GOAL_TITLE
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "ENROLMENT_YEAR"
                    Return ENROLMENT_YEAR
                Case "CREATED_DATETIME"
                    Return CREATED_DATETIME
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "GOAL_BY_DATE"
                    Return GOAL_BY_DATE
                Case "GOAL_CATEGORY"
                    Return GOAL_CATEGORY
                Case "GOAL_DETAIL"
                    Return GOAL_DETAIL
                Case "GOAL_RESULT"
                    Return GOAL_RESULT
                Case "RESULT_NOTES"
                    Return RESULT_NOTES
                Case "lblLAST_ALTERED_BY"
                    Return lblLAST_ALTERED_BY
                Case "lblLAST_ALTERED_DATE"
                    Return lblLAST_ALTERED_DATE
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "GOAL_TITLE"
                    GOAL_TITLE = CType(value, TextField)
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, FloatField)
                Case "ENROLMENT_YEAR"
                    ENROLMENT_YEAR = CType(value, FloatField)
                Case "CREATED_DATETIME"
                    CREATED_DATETIME = CType(value, DateField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "GOAL_BY_DATE"
                    GOAL_BY_DATE = CType(value, DateField)
                Case "GOAL_CATEGORY"
                    GOAL_CATEGORY = CType(value, TextField)
                Case "GOAL_DETAIL"
                    GOAL_DETAIL = CType(value, TextField)
                Case "GOAL_RESULT"
                    GOAL_RESULT = CType(value, TextField)
                Case "RESULT_NOTES"
                    RESULT_NOTES = CType(value, TextField)
                Case "lblLAST_ALTERED_BY"
                    lblLAST_ALTERED_BY = CType(value, TextField)
                Case "lblLAST_ALTERED_DATE"
                    lblLAST_ALTERED_DATE = CType(value, DateField)
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

    Public Sub Validate(ByVal provider As STUDENT_LEARNING_GOALS2DataProvider)
'End Record STUDENT_LEARNING_GOALS2 Item Class

'GOAL_TITLE validate @217-EBC79FB1
        If IsNothing(GOAL_TITLE.Value) OrElse GOAL_TITLE.Value.ToString() ="" Then
            errors.Add("GOAL_TITLE",String.Format(Resources.strings.CCS_RequiredField,"GOAL TITLE"))
        End If
'End GOAL_TITLE validate

'STUDENT_ID validate @224-6D9CF271
        If IsNothing(STUDENT_ID.Value) OrElse STUDENT_ID.Value.ToString() ="" Then
            errors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_RequiredField,"STUDENT ID"))
        End If
'End STUDENT_ID validate

'ENROLMENT_YEAR validate @225-2458998A
        If IsNothing(ENROLMENT_YEAR.Value) OrElse ENROLMENT_YEAR.Value.ToString() ="" Then
            errors.Add("ENROLMENT_YEAR",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT YEAR"))
        End If
'End ENROLMENT_YEAR validate

'CREATED_DATETIME validate @226-BD0CB2E4
        If IsNothing(CREATED_DATETIME.Value) OrElse CREATED_DATETIME.Value.ToString() ="" Then
            errors.Add("CREATED_DATETIME",String.Format(Resources.strings.CCS_RequiredField,"CREATED DATETIME"))
        End If
'End CREATED_DATETIME validate

'LAST_ALTERED_BY validate @227-256A6854
        If IsNothing(LAST_ALTERED_BY.Value) OrElse LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End LAST_ALTERED_BY validate

'LAST_ALTERED_DATE validate @228-C5989D76
        If IsNothing(LAST_ALTERED_DATE.Value) OrElse LAST_ALTERED_DATE.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED DATE"))
        End If
'End LAST_ALTERED_DATE validate

'GOAL_BY_DATE validate @219-B5E7A696
        If IsNothing(GOAL_BY_DATE.Value) OrElse GOAL_BY_DATE.Value.ToString() ="" Then
            errors.Add("GOAL_BY_DATE",String.Format(Resources.strings.CCS_RequiredField,"GOAL BY DATE"))
        End If
'End GOAL_BY_DATE validate

'GOAL_CATEGORY validate @218-806A3FA6
        If IsNothing(GOAL_CATEGORY.Value) OrElse GOAL_CATEGORY.Value.ToString() ="" Then
            errors.Add("GOAL_CATEGORY",String.Format(Resources.strings.CCS_RequiredField,"GOAL CATEGORY"))
        End If
'End GOAL_CATEGORY validate

'GOAL_RESULT validate @222-508BE044
        If IsNothing(GOAL_RESULT.Value) OrElse GOAL_RESULT.Value.ToString() ="" Then
            errors.Add("GOAL_RESULT",String.Format(Resources.strings.CCS_RequiredField,"GOAL RESULT"))
        End If
'End GOAL_RESULT validate

'Record STUDENT_LEARNING_GOALS2 Item Class tail @209-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_LEARNING_GOALS2 Item Class tail

'Record STUDENT_LEARNING_GOALS2 Data Provider Class @209-64A564D1
Public Class STUDENT_LEARNING_GOALS2DataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_LEARNING_GOALS2 Data Provider Class

'Record STUDENT_LEARNING_GOALS2 Data Provider Class Variables @209-17453A1E
    Public UrlLEARNING_GOAL_ID As IntegerParameter
    Public UrlSTUDENT_ID As IntegerParameter
    Protected item As STUDENT_LEARNING_GOALS2Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_LEARNING_GOALS2 Data Provider Class Variables

'Record STUDENT_LEARNING_GOALS2 Data Provider Class Constructor @209-8E44170B

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_LEARNING_GOALS {SQL_Where} {SQL_OrderBy}", New String(){"LEARNING_GOAL_ID317","And","STUDENT_ID318"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_LEARNING_GOALS2 Data Provider Class Constructor

'Record STUDENT_LEARNING_GOALS2 Data Provider Class LoadParams Method @209-B8495E38

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlLEARNING_GOAL_ID) Or IsNothing(UrlSTUDENT_ID))
    End Function
'End Record STUDENT_LEARNING_GOALS2 Data Provider Class LoadParams Method

'Record STUDENT_LEARNING_GOALS2 Data Provider Class CheckUnique Method @209-74A4A867

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_LEARNING_GOALS2Item) As Boolean
        Return True
    End Function
'End Record STUDENT_LEARNING_GOALS2 Data Provider Class CheckUnique Method

'Record STUDENT_LEARNING_GOALS2 Data Provider Class PrepareInsert Method @209-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STUDENT_LEARNING_GOALS2 Data Provider Class PrepareInsert Method

'Record STUDENT_LEARNING_GOALS2 Data Provider Class PrepareInsert Method tail @209-E31F8E2A
    End Sub
'End Record STUDENT_LEARNING_GOALS2 Data Provider Class PrepareInsert Method tail

'Record STUDENT_LEARNING_GOALS2 Data Provider Class Insert Method @209-E3AF25AE

    Public Function InsertItem(ByVal item As STUDENT_LEARNING_GOALS2Item) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO STUDENT_LEARNING_GOALS({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_LEARNING_GOALS2 Data Provider Class Insert Method

'Record STUDENT_LEARNING_GOALS2 Build insert @209-452549D1
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.GOAL_TITLE.IsEmpty Then
        allEmptyFlag = item.GOAL_TITLE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "GOAL_TITLE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.GOAL_TITLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STUDENT_ID.IsEmpty Then
        allEmptyFlag = item.STUDENT_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STUDENT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STUDENT_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.ENROLMENT_YEAR.IsEmpty Then
        allEmptyFlag = item.ENROLMENT_YEAR.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ENROLMENT_YEAR,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ENROLMENT_YEAR.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.CREATED_DATETIME.IsEmpty Then
        allEmptyFlag = item.CREATED_DATETIME.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CREATED_DATETIME,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CREATED_DATETIME.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.GOAL_BY_DATE.IsEmpty Then
        allEmptyFlag = item.GOAL_BY_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "GOAL_BY_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.GOAL_BY_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.GOAL_CATEGORY.IsEmpty Then
        allEmptyFlag = item.GOAL_CATEGORY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "GOAL_CATEGORY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.GOAL_CATEGORY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.GOAL_DETAIL.IsEmpty Then
        allEmptyFlag = item.GOAL_DETAIL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "GOAL_DETAIL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.GOAL_DETAIL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.GOAL_RESULT.IsEmpty Then
        allEmptyFlag = item.GOAL_RESULT.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "GOAL_RESULT,"
        valuesList = valuesList & Insert.Dao.ToSql(item.GOAL_RESULT.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RESULT_NOTES.IsEmpty Then
        allEmptyFlag = item.RESULT_NOTES.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "RESULT_NOTES,"
        valuesList = valuesList & Insert.Dao.ToSql(item.RESULT_NOTES.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STUDENT_LEARNING_GOALS2 Build insert

'Record STUDENT_LEARNING_GOALS2 AfterExecuteInsert @209-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_LEARNING_GOALS2 AfterExecuteInsert

'Record STUDENT_LEARNING_GOALS2 Data Provider Class PrepareUpdate Method @209-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STUDENT_LEARNING_GOALS2 Data Provider Class PrepareUpdate Method

'Record STUDENT_LEARNING_GOALS2 Data Provider Class PrepareUpdate Method tail @209-E31F8E2A
    End Sub
'End Record STUDENT_LEARNING_GOALS2 Data Provider Class PrepareUpdate Method tail

'Record STUDENT_LEARNING_GOALS2 Data Provider Class Update Method @209-57404B19

    Public Function UpdateItem(ByVal item As STUDENT_LEARNING_GOALS2Item) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT_LEARNING_GOALS SET {Values}", New String(){"LEARNING_GOAL_ID317","And","STUDENT_ID318"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_LEARNING_GOALS2 Data Provider Class Update Method

'Record STUDENT_LEARNING_GOALS2 BeforeBuildUpdate @209-143AFB98
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("LEARNING_GOAL_ID317",UrlLEARNING_GOAL_ID, "","LEARNING_GOAL_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("STUDENT_ID318",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        If Not item.GOAL_TITLE.IsEmpty Then
        allEmptyFlag = item.GOAL_TITLE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "GOAL_TITLE=" + Update.Dao.ToSql(item.GOAL_TITLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STUDENT_ID.IsEmpty Then
        allEmptyFlag = item.STUDENT_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STUDENT_ID=" + Update.Dao.ToSql(item.STUDENT_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.ENROLMENT_YEAR.IsEmpty Then
        allEmptyFlag = item.ENROLMENT_YEAR.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ENROLMENT_YEAR=" + Update.Dao.ToSql(item.ENROLMENT_YEAR.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.CREATED_DATETIME.IsEmpty Then
        allEmptyFlag = item.CREATED_DATETIME.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CREATED_DATETIME=" + Update.Dao.ToSql(item.CREATED_DATETIME.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.GOAL_BY_DATE.IsEmpty Then
        allEmptyFlag = item.GOAL_BY_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "GOAL_BY_DATE=" + Update.Dao.ToSql(item.GOAL_BY_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.GOAL_CATEGORY.IsEmpty Then
        allEmptyFlag = item.GOAL_CATEGORY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "GOAL_CATEGORY=" + Update.Dao.ToSql(item.GOAL_CATEGORY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.GOAL_DETAIL.IsEmpty Then
        allEmptyFlag = item.GOAL_DETAIL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "GOAL_DETAIL=" + Update.Dao.ToSql(item.GOAL_DETAIL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.GOAL_RESULT.IsEmpty Then
        allEmptyFlag = item.GOAL_RESULT.IsEmpty And allEmptyFlag
        valuesList = valuesList & "GOAL_RESULT=" + Update.Dao.ToSql(item.GOAL_RESULT.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RESULT_NOTES.IsEmpty Then
        allEmptyFlag = item.RESULT_NOTES.IsEmpty And allEmptyFlag
        valuesList = valuesList & "RESULT_NOTES=" + Update.Dao.ToSql(item.RESULT_NOTES.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STUDENT_LEARNING_GOALS2 BeforeBuildUpdate

'Record STUDENT_LEARNING_GOALS2 AfterExecuteUpdate @209-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_LEARNING_GOALS2 AfterExecuteUpdate

'Record STUDENT_LEARNING_GOALS2 Data Provider Class GetResultSet Method @209-7A539A44

    Public Sub FillItem(ByVal item As STUDENT_LEARNING_GOALS2Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_LEARNING_GOALS2 Data Provider Class GetResultSet Method

'Record STUDENT_LEARNING_GOALS2 BeforeBuildSelect @209-DBE48601
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("LEARNING_GOAL_ID317",UrlLEARNING_GOAL_ID, "","LEARNING_GOAL_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("STUDENT_ID318",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_LEARNING_GOALS2 BeforeBuildSelect

'Record STUDENT_LEARNING_GOALS2 BeforeExecuteSelect @209-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_LEARNING_GOALS2 BeforeExecuteSelect

'Record STUDENT_LEARNING_GOALS2 AfterExecuteSelect @209-E5D04635
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.GOAL_TITLE.SetValue(dr(i)("GOAL_TITLE"),"")
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.ENROLMENT_YEAR.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.CREATED_DATETIME.SetValue(dr(i)("CREATED_DATETIME"),Select_.DateFormat)
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.GOAL_BY_DATE.SetValue(dr(i)("GOAL_BY_DATE"),Select_.DateFormat)
            item.GOAL_CATEGORY.SetValue(dr(i)("GOAL_CATEGORY"),"")
            item.GOAL_DETAIL.SetValue(dr(i)("GOAL_DETAIL"),"")
            item.GOAL_RESULT.SetValue(dr(i)("GOAL_RESULT"),"")
            item.RESULT_NOTES.SetValue(dr(i)("RESULT_NOTES"),"")
            item.lblLAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.lblLAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
'End Record STUDENT_LEARNING_GOALS2 AfterExecuteSelect

'ListBox GOAL_CATEGORY AfterExecuteSelect @218-CA65EC37
        
item.GOAL_CATEGORYItems.Add("Learning/achievement","Learning/achievement ")
item.GOAL_CATEGORYItems.Add("Personal/social","Personal/social ")
item.GOAL_CATEGORYItems.Add("Engagement","Engagement ")
item.GOAL_CATEGORYItems.Add("Pathways/transitions","Pathways/transitions ")
item.GOAL_CATEGORYItems.Add("Literacy","Literacy ")
item.GOAL_CATEGORYItems.Add("Numeracy","Numeracy ")
item.GOAL_CATEGORYItems.Add("Subject specific","Subject specific")
'End ListBox GOAL_CATEGORY AfterExecuteSelect

'ListBox GOAL_RESULT AfterExecuteSelect @222-B8E59D5E
        
item.GOAL_RESULTItems.Add("Unknown","Unknown")
item.GOAL_RESULTItems.Add("Completed","Completed ")
item.GOAL_RESULTItems.Add("Great Effort","Great Effort ")
item.GOAL_RESULTItems.Add("Mostly","Mostly ")
item.GOAL_RESULTItems.Add("Partly","Partly ")
item.GOAL_RESULTItems.Add("60-90% Complete","60-90% Complete ")
item.GOAL_RESULTItems.Add("30-60% Complete","30-60% Complete ")
item.GOAL_RESULTItems.Add("0-30% Complete","0-30% Complete ")
item.GOAL_RESULTItems.Add("Incomplete","Incomplete")
'End ListBox GOAL_RESULT AfterExecuteSelect

'Record STUDENT_LEARNING_GOALS2 AfterExecuteSelect tail @209-E31F8E2A
    End Sub
'End Record STUDENT_LEARNING_GOALS2 AfterExecuteSelect tail

'Record STUDENT_LEARNING_GOALS2 Data Provider Class @209-A61BA892
End Class

'End Record STUDENT_LEARNING_GOALS2 Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

