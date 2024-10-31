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

Namespace DECV_PROD2007.Student_Carer_FamilyGrouping 'Namespace @1-FC855C02

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

'Record STUDENT_CARER_CONTACT3 Item Class @4-53075BF0
Public Class STUDENT_CARER_CONTACT3Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public RELATIONSHIP As TextField
    Public RELATIONSHIPItems As ItemCollection
    Public WORK_PHONE As TextField
    Public MOBILE As TextField
    Public EMAIL As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Hidden_STUDENT_ID As TextField
    Public Hidden_LAST_ALTERED_BY As TextField
    Public FIRST_NAME As TextField
    Public SURNAME As TextField
    Public HOME_PHONE As TextField
    Public Hidden_STUDENT_ID_OTHER As TextField
    Public Student_Firstname As TextField
    Public Student_Surname As TextField
    Public Dupe_CARER_ID As IntegerField
    Public Sub New()
    RELATIONSHIP = New TextField("", Nothing)
    RELATIONSHIPItems = New ItemCollection()
    WORK_PHONE = New TextField("", Nothing)
    MOBILE = New TextField("", Nothing)
    EMAIL = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    Hidden_STUDENT_ID = New TextField("", Nothing)
    Hidden_LAST_ALTERED_BY = New TextField("", DBUtility.UserLogin.ToUpper)
    FIRST_NAME = New TextField("", Nothing)
    SURNAME = New TextField("", Nothing)
    HOME_PHONE = New TextField("", Nothing)
    Hidden_STUDENT_ID_OTHER = New TextField("", Nothing)
    Student_Firstname = New TextField("", "No Carer Yet!")
    Student_Surname = New TextField("", "Search and add to family group")
    Dupe_CARER_ID = New IntegerField("", 0)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_CARER_CONTACT3Item
        Dim item As STUDENT_CARER_CONTACT3Item = New STUDENT_CARER_CONTACT3Item()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RELATIONSHIP")) Then
        item.RELATIONSHIP.SetValue(DBUtility.GetInitialValue("RELATIONSHIP"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("WORK_PHONE")) Then
        item.WORK_PHONE.SetValue(DBUtility.GetInitialValue("WORK_PHONE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MOBILE")) Then
        item.MOBILE.SetValue(DBUtility.GetInitialValue("MOBILE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EMAIL")) Then
        item.EMAIL.SetValue(DBUtility.GetInitialValue("EMAIL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_STUDENT_ID")) Then
        item.Hidden_STUDENT_ID.SetValue(DBUtility.GetInitialValue("Hidden_STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_LAST_ALTERED_BY")) Then
        item.Hidden_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("Hidden_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FIRST_NAME")) Then
        item.FIRST_NAME.SetValue(DBUtility.GetInitialValue("FIRST_NAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SURNAME")) Then
        item.SURNAME.SetValue(DBUtility.GetInitialValue("SURNAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("HOME_PHONE")) Then
        item.HOME_PHONE.SetValue(DBUtility.GetInitialValue("HOME_PHONE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_STUDENT_ID_OTHER")) Then
        item.Hidden_STUDENT_ID_OTHER.SetValue(DBUtility.GetInitialValue("Hidden_STUDENT_ID_OTHER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Student_Firstname")) Then
        item.Student_Firstname.SetValue(DBUtility.GetInitialValue("Student_Firstname"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Student_Surname")) Then
        item.Student_Surname.SetValue(DBUtility.GetInitialValue("Student_Surname"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Dupe_CARER_ID")) Then
        item.Dupe_CARER_ID.SetValue(DBUtility.GetInitialValue("Dupe_CARER_ID"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "RELATIONSHIP"
                    Return RELATIONSHIP
                Case "WORK_PHONE"
                    Return WORK_PHONE
                Case "MOBILE"
                    Return MOBILE
                Case "EMAIL"
                    Return EMAIL
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "Hidden_STUDENT_ID"
                    Return Hidden_STUDENT_ID
                Case "Hidden_LAST_ALTERED_BY"
                    Return Hidden_LAST_ALTERED_BY
                Case "FIRST_NAME"
                    Return FIRST_NAME
                Case "SURNAME"
                    Return SURNAME
                Case "HOME_PHONE"
                    Return HOME_PHONE
                Case "Hidden_STUDENT_ID_OTHER"
                    Return Hidden_STUDENT_ID_OTHER
                Case "Student_Firstname"
                    Return Student_Firstname
                Case "Student_Surname"
                    Return Student_Surname
                Case "Dupe_CARER_ID"
                    Return Dupe_CARER_ID
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "RELATIONSHIP"
                    RELATIONSHIP = CType(value, TextField)
                Case "WORK_PHONE"
                    WORK_PHONE = CType(value, TextField)
                Case "MOBILE"
                    MOBILE = CType(value, TextField)
                Case "EMAIL"
                    EMAIL = CType(value, TextField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "Hidden_STUDENT_ID"
                    Hidden_STUDENT_ID = CType(value, TextField)
                Case "Hidden_LAST_ALTERED_BY"
                    Hidden_LAST_ALTERED_BY = CType(value, TextField)
                Case "FIRST_NAME"
                    FIRST_NAME = CType(value, TextField)
                Case "SURNAME"
                    SURNAME = CType(value, TextField)
                Case "HOME_PHONE"
                    HOME_PHONE = CType(value, TextField)
                Case "Hidden_STUDENT_ID_OTHER"
                    Hidden_STUDENT_ID_OTHER = CType(value, TextField)
                Case "Student_Firstname"
                    Student_Firstname = CType(value, TextField)
                Case "Student_Surname"
                    Student_Surname = CType(value, TextField)
                Case "Dupe_CARER_ID"
                    Dupe_CARER_ID = CType(value, IntegerField)
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

    Public Sub Validate(ByVal provider As STUDENT_CARER_CONTACT3DataProvider)
'End Record STUDENT_CARER_CONTACT3 Item Class

'RELATIONSHIP validate @13-14A3EB67
        If IsNothing(RELATIONSHIP.Value) OrElse RELATIONSHIP.Value.ToString() ="" Then
            errors.Add("RELATIONSHIP",String.Format(Resources.strings.CCS_RequiredField,"RELATIONSHIP"))
        End If
'End RELATIONSHIP validate

'DEL      ' -------------------------
'DEL      'ERA: check that at least one of HOME, WORK, or MOBILE phone numbers are provided.
'DEL  	If ((HOME_PHONE.Value Is Nothing) OrElse HOME_PHONE.Value.ToString()="")  AND ((WORK_PHONE.Value Is Nothing) OrElse WORK_PHONE.Value.ToString()="") AND ((MOBILE.Value Is Nothing) OrElse MOBILE.Value.ToString()="")  Then
'DEL              errors.Add("STUDENT_CARER_CONTACT3",String.Format("At least ONE of HOME PHONE, WORK PHONE, or MOBILE is required.","STUDENT_CARER_CONTACT3"))
'DEL      End If
'DEL      ' -------------------------


'Record STUDENT_CARER_CONTACT3 Item Class tail @4-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_CARER_CONTACT3 Item Class tail

'Record STUDENT_CARER_CONTACT3 Data Provider Class @4-3734F3F4
Public Class STUDENT_CARER_CONTACT3DataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_CARER_CONTACT3 Data Provider Class

'Record STUDENT_CARER_CONTACT3 Data Provider Class Variables @4-B0533FEA
    Public UrlSTUDENT_ID As FloatParameter
    Public CtrlHidden_STUDENT_ID_OTHER As FloatParameter
    Public CtrlDupe_CARER_ID As IntegerParameter
    Protected item As STUDENT_CARER_CONTACT3Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_CARER_CONTACT3 Data Provider Class Variables

'Record STUDENT_CARER_CONTACT3 Data Provider Class Constructor @4-1A1A5A13

    Public Sub New()
        Select_=new TableCommand("SELECT rtrim(STUDENT.SURNAME) AS STUDENT_SURNAME, " & vbCrLf & _
          "rtrim(STUDENT.FIRST_NAME) AS STUDENT_FIRST_NAME, STUDENT_ID, " & vbCrLf & _
          "STUDENT_CARER_CONTACT.* " & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT INNER JOIN STUDENT ON" & vbCrLf & _
          "STUDENT_CARER_CONTACT.CARER_ID = STUDENT.CARER_ID_PARENT_A {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID251"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_CARER_CONTACT3 Data Provider Class Constructor

'Record STUDENT_CARER_CONTACT3 Data Provider Class LoadParams Method @4-A977A0E9

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID))
    End Function
'End Record STUDENT_CARER_CONTACT3 Data Provider Class LoadParams Method

'Record STUDENT_CARER_CONTACT3 Data Provider Class CheckUnique Method @4-EC92E8D7

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_CARER_CONTACT3Item) As Boolean
        Return True
    End Function
'End Record STUDENT_CARER_CONTACT3 Data Provider Class CheckUnique Method

'Record STUDENT_CARER_CONTACT3 Data Provider Class PrepareUpdate Method @4-30AC78A5

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = Not(IsNothing(item.Hidden_STUDENT_ID_OTHER))
'End Record STUDENT_CARER_CONTACT3 Data Provider Class PrepareUpdate Method

'Record STUDENT_CARER_CONTACT3 Data Provider Class PrepareUpdate Method tail @4-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT3 Data Provider Class PrepareUpdate Method tail

'Record STUDENT_CARER_CONTACT3 Data Provider Class Update Method @4-A998865D

    Public Function UpdateItem(ByVal item As STUDENT_CARER_CONTACT3Item) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT SET {Values}", New String(){"Hidden_STUDENT_ID_OTHER191"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_CARER_CONTACT3 Data Provider Class Update Method

'Record STUDENT_CARER_CONTACT3 BeforeBuildUpdate @4-7EFA15C9
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("Hidden_STUDENT_ID_OTHER191",item.Hidden_STUDENT_ID_OTHER, "","STUDENT_ID",Condition.Equal,False)
        allEmptyFlag = item.Dupe_CARER_ID.IsEmpty And allEmptyFlag
        If Not item.Dupe_CARER_ID.IsEmpty Then
        If IsNothing(item.Dupe_CARER_ID.Value) Then
        valuesList = valuesList & "CARER_ID_PARENT_A=" & Update.Dao.ToSql((0).ToString(),FieldType._Integer) & ","
        Else
        valuesList = valuesList & "CARER_ID_PARENT_A=" & Update.Dao.ToSql(item.Dupe_CARER_ID.GetFormattedValue(""),FieldType._Integer) & ","
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
'End Record STUDENT_CARER_CONTACT3 BeforeBuildUpdate

'Record STUDENT_CARER_CONTACT3 AfterExecuteUpdate @4-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_CARER_CONTACT3 AfterExecuteUpdate

'Record STUDENT_CARER_CONTACT3 Data Provider Class GetResultSet Method @4-B422D9D8

    Public Sub FillItem(ByVal item As STUDENT_CARER_CONTACT3Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_CARER_CONTACT3 Data Provider Class GetResultSet Method

'Record STUDENT_CARER_CONTACT3 BeforeBuildSelect @4-5CEC7513
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID251",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_CARER_CONTACT3 BeforeBuildSelect

'Record STUDENT_CARER_CONTACT3 BeforeExecuteSelect @4-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_CARER_CONTACT3 BeforeExecuteSelect

'Record STUDENT_CARER_CONTACT3 AfterExecuteSelect @4-F6A8DDC2
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.RELATIONSHIP.SetValue(dr(i)("RELATIONSHIP"),"")
            item.WORK_PHONE.SetValue(dr(i)("WORK_PHONE"),"")
            item.MOBILE.SetValue(dr(i)("MOBILE"),"")
            item.EMAIL.SetValue(dr(i)("EMAIL"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.Hidden_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
            item.SURNAME.SetValue(dr(i)("SURNAME"),"")
            item.HOME_PHONE.SetValue(dr(i)("HOME_PHONE"),"")
            item.Student_Firstname.SetValue(dr(i)("STUDENT_FIRST_NAME"),"")
            item.Student_Surname.SetValue(dr(i)("STUDENT_SURNAME"),"")
            item.Dupe_CARER_ID.SetValue(dr(i)("CARER_ID"),"")
        Else
            IsInsertMode = True
        End If
'End Record STUDENT_CARER_CONTACT3 AfterExecuteSelect

'ListBox RELATIONSHIP AfterExecuteSelect @13-D6CE2666
        
item.RELATIONSHIPItems.Add("PA","Parent")
item.RELATIONSHIPItems.Add("SP","Step-Parent")
item.RELATIONSHIPItems.Add("AP","Adoptive Parent")
item.RELATIONSHIPItems.Add("FP","Foster Parent")
item.RELATIONSHIPItems.Add("GP","Grand Parent")
item.RELATIONSHIPItems.Add("HF","Host Family")
item.RELATIONSHIPItems.Add("RE","Relative")
item.RELATIONSHIPItems.Add("FR","Friend")
item.RELATIONSHIPItems.Add("SE","Self")
item.RELATIONSHIPItems.Add("OT","Other")
'End ListBox RELATIONSHIP AfterExecuteSelect

'Record STUDENT_CARER_CONTACT3 AfterExecuteSelect tail @4-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT3 AfterExecuteSelect tail

'Record STUDENT_CARER_CONTACT3 Data Provider Class @4-A61BA892
End Class

'End Record STUDENT_CARER_CONTACT3 Data Provider Class

'Grid viewMaintainSearchRequest Item Class @61-766FD426
Public Class viewMaintainSearchRequestItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STUDENT_ID As FloatField
    Public STUDENT_IDHref As Object
    Public STUDENT_IDHrefParameters As LinkParameterCollection
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public YEAR_LEVEL As IntegerField
    Public ENROLMENT_STATUS As TextField
    Public PASTORAL_CARE_ID As TextField
    Public Sub New()
    STUDENT_ID = New FloatField("",Nothing)
    STUDENT_IDHrefParameters = New LinkParameterCollection()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    YEAR_LEVEL = New IntegerField("", Nothing)
    ENROLMENT_STATUS = New TextField("", Nothing)
    PASTORAL_CARE_ID = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "YEAR_LEVEL"
                    Return Me.YEAR_LEVEL
                Case "ENROLMENT_STATUS"
                    Return Me.ENROLMENT_STATUS
                Case "PASTORAL_CARE_ID"
                    Return Me.PASTORAL_CARE_ID
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "YEAR_LEVEL"
                    Me.YEAR_LEVEL = CType(Value,IntegerField)
                Case "ENROLMENT_STATUS"
                    Me.ENROLMENT_STATUS = CType(Value,TextField)
                Case "PASTORAL_CARE_ID"
                    Me.PASTORAL_CARE_ID = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid viewMaintainSearchRequest Item Class

'Grid viewMaintainSearchRequest Data Provider Class Header @61-044B34D7
Public Class viewMaintainSearchRequestDataProvider
Inherits GridDataProviderBase
'End Grid viewMaintainSearchRequest Data Provider Class Header

'Grid viewMaintainSearchRequest Data Provider Class Variables @61-99478238

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_ID
        Sorter_SURNAME
        Sorter_FIRST_NAME
        Sorter_YEAR_LEVEL
        Sorter_ENROLMENT_STATUS
        Sorter_PASTORAL_CARE_ID
    End Enum

    Private SortFieldsNames As String() = New String() {"","STUDENT_ID","SURNAME","FIRST_NAME","YEAR_LEVEL","ENROLMENT_STATUS","PASTORAL_CARE_ID"}
    Private SortFieldsNamesDesc As String() = New string() {"","STUDENT_ID DESC","SURNAME DESC","FIRST_NAME DESC","YEAR_LEVEL DESC","ENROLMENT_STATUS DESC","PASTORAL_CARE_ID DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 15
    Public PageNumber As Integer = 1
    Public Urls_SURNAME  As TextParameter
    Public Urls_STUDENT_ID  As FloatParameter
    Public UrlENROLMENT_YEAR  As FloatParameter
'End Grid viewMaintainSearchRequest Data Provider Class Variables

'Grid viewMaintainSearchRequest Data Provider Class GetResultSet Method @61-AF7BA425

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} STUDENT_ID, SURNAME, FIRST_NAME, YEAR_LEVEL, " & vbCrLf & _
          "ENROLMENT_STATUS, " & vbCrLf & _
          "PASTORAL_CARE_ID " & vbCrLf & _
          "FROM viewMaintainSearchRequest {SQL_Where} {SQL_OrderBy}", New String(){"(","s_SURNAME90","Or","s_STUDENT_ID91",")","And","ENROLMENT_YEAR92"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM viewMaintainSearchRequest", New String(){"(","s_SURNAME90","Or","s_STUDENT_ID91",")","And","ENROLMENT_YEAR92"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid viewMaintainSearchRequest Data Provider Class GetResultSet Method

'Grid viewMaintainSearchRequest Data Provider Class GetResultSet Method @61-963C1594
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As viewMaintainSearchRequestItem()
'End Grid viewMaintainSearchRequest Data Provider Class GetResultSet Method

'Before build Select @61-7C752A55
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_SURNAME90",Urls_SURNAME, "","SURNAME",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_STUDENT_ID91",Urls_STUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("ENROLMENT_YEAR92",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @61-F017887A
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As viewMaintainSearchRequestItem
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

'After execute Select @61-69B8AA1C
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New viewMaintainSearchRequestItem(dr.Count-1) {}
'End After execute Select

'After execute Select @61-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @61-19668AA0
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as viewMaintainSearchRequestItem = New viewMaintainSearchRequestItem()
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.STUDENT_IDHref = "Student_Carer_FamilyGrouping.aspx"
                item.STUDENT_IDHrefParameters.Add("STUDENT_ID_OTHER",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
                item.ENROLMENT_STATUS.SetValue(dr(i)("ENROLMENT_STATUS"),"")
                item.PASTORAL_CARE_ID.SetValue(dr(i)("PASTORAL_CARE_ID"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @61-A61BA892
End Class
'End Grid Data Provider tail

'Record viewMaintainSearchRequestSearch Item Class @78-9EE50995
Public Class viewMaintainSearchRequestSearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public s_SURNAME As TextField
    Public s_STUDENT_ID As FloatField
    Public Sub New()
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    s_SURNAME = New TextField("", Nothing)
    s_STUDENT_ID = New FloatField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As viewMaintainSearchRequestSearchItem
        Dim item As viewMaintainSearchRequestSearchItem = New viewMaintainSearchRequestSearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_SURNAME")) Then
        item.s_SURNAME.SetValue(DBUtility.GetInitialValue("s_SURNAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_STUDENT_ID")) Then
        item.s_STUDENT_ID.SetValue(DBUtility.GetInitialValue("s_STUDENT_ID"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "ClearParameters"
                    Return ClearParameters
                Case "s_SURNAME"
                    Return s_SURNAME
                Case "s_STUDENT_ID"
                    Return s_STUDENT_ID
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ClearParameters"
                    ClearParameters = CType(value, TextField)
                Case "s_SURNAME"
                    s_SURNAME = CType(value, TextField)
                Case "s_STUDENT_ID"
                    s_STUDENT_ID = CType(value, FloatField)
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

    Public Sub Validate(ByVal provider As viewMaintainSearchRequestSearchDataProvider)
'End Record viewMaintainSearchRequestSearch Item Class

'Record viewMaintainSearchRequestSearch Item Class tail @78-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record viewMaintainSearchRequestSearch Item Class tail

'Record viewMaintainSearchRequestSearch Data Provider Class @78-C603CE6E
Public Class viewMaintainSearchRequestSearchDataProvider
Inherits RecordDataProviderBase
'End Record viewMaintainSearchRequestSearch Data Provider Class

'Record viewMaintainSearchRequestSearch Data Provider Class Variables @78-A0C04C73
    Protected item As viewMaintainSearchRequestSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record viewMaintainSearchRequestSearch Data Provider Class Variables

'Record viewMaintainSearchRequestSearch Data Provider Class GetResultSet Method @78-676EE12A

    Public Sub FillItem(ByVal item As viewMaintainSearchRequestSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record viewMaintainSearchRequestSearch Data Provider Class GetResultSet Method

'Record viewMaintainSearchRequestSearch BeforeBuildSelect @78-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record viewMaintainSearchRequestSearch BeforeBuildSelect

'Record viewMaintainSearchRequestSearch AfterExecuteSelect @78-79426A21
        End If
            IsInsertMode = True
'End Record viewMaintainSearchRequestSearch AfterExecuteSelect

'Record viewMaintainSearchRequestSearch AfterExecuteSelect tail @78-E31F8E2A
    End Sub
'End Record viewMaintainSearchRequestSearch AfterExecuteSelect tail

'Record viewMaintainSearchRequestSearch Data Provider Class @78-A61BA892
End Class

'End Record viewMaintainSearchRequestSearch Data Provider Class

'Record STUDENT_CARER_CONTACT4 Item Class @99-7677749D
Public Class STUDENT_CARER_CONTACT4Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public RELATIONSHIP As TextField
    Public RELATIONSHIPItems As ItemCollection
    Public WORK_PHONE As TextField
    Public MOBILE As TextField
    Public EMAIL As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Hidden_STUDENT_ID As TextField
    Public Hidden_LAST_ALTERED_BY As TextField
    Public FIRST_NAME As TextField
    Public SURNAME As TextField
    Public HOME_PHONE As TextField
    Public Hidden_STUDENT_ID_OTHER As TextField
    Public Student_Firstname As TextField
    Public Student_Surname As TextField
    Public Dupe_CARER_ID As IntegerField
    Public lblNoCarer As TextField
    Public Sub New()
    RELATIONSHIP = New TextField("", Nothing)
    RELATIONSHIPItems = New ItemCollection()
    WORK_PHONE = New TextField("", Nothing)
    MOBILE = New TextField("", Nothing)
    EMAIL = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    Hidden_STUDENT_ID = New TextField("", Nothing)
    Hidden_LAST_ALTERED_BY = New TextField("", DBUtility.UserLogin.ToUpper)
    FIRST_NAME = New TextField("", Nothing)
    SURNAME = New TextField("", Nothing)
    HOME_PHONE = New TextField("", Nothing)
    Hidden_STUDENT_ID_OTHER = New TextField("", Nothing)
    Student_Firstname = New TextField("", Nothing)
    Student_Surname = New TextField("", Nothing)
    Dupe_CARER_ID = New IntegerField("", 0)
    lblNoCarer = New TextField("", "No Carer - <strong>Use main Student [Update] button</strong> if you<br> want to add Student to Family Group")
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_CARER_CONTACT4Item
        Dim item As STUDENT_CARER_CONTACT4Item = New STUDENT_CARER_CONTACT4Item()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RELATIONSHIP")) Then
        item.RELATIONSHIP.SetValue(DBUtility.GetInitialValue("RELATIONSHIP"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("WORK_PHONE")) Then
        item.WORK_PHONE.SetValue(DBUtility.GetInitialValue("WORK_PHONE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("MOBILE")) Then
        item.MOBILE.SetValue(DBUtility.GetInitialValue("MOBILE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EMAIL")) Then
        item.EMAIL.SetValue(DBUtility.GetInitialValue("EMAIL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_STUDENT_ID")) Then
        item.Hidden_STUDENT_ID.SetValue(DBUtility.GetInitialValue("Hidden_STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_LAST_ALTERED_BY")) Then
        item.Hidden_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("Hidden_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FIRST_NAME")) Then
        item.FIRST_NAME.SetValue(DBUtility.GetInitialValue("FIRST_NAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SURNAME")) Then
        item.SURNAME.SetValue(DBUtility.GetInitialValue("SURNAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("HOME_PHONE")) Then
        item.HOME_PHONE.SetValue(DBUtility.GetInitialValue("HOME_PHONE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_STUDENT_ID_OTHER")) Then
        item.Hidden_STUDENT_ID_OTHER.SetValue(DBUtility.GetInitialValue("Hidden_STUDENT_ID_OTHER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Student_Firstname")) Then
        item.Student_Firstname.SetValue(DBUtility.GetInitialValue("Student_Firstname"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Student_Surname")) Then
        item.Student_Surname.SetValue(DBUtility.GetInitialValue("Student_Surname"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Dupe_CARER_ID")) Then
        item.Dupe_CARER_ID.SetValue(DBUtility.GetInitialValue("Dupe_CARER_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblNoCarer")) Then
        item.lblNoCarer.SetValue(DBUtility.GetInitialValue("lblNoCarer"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "RELATIONSHIP"
                    Return RELATIONSHIP
                Case "WORK_PHONE"
                    Return WORK_PHONE
                Case "MOBILE"
                    Return MOBILE
                Case "EMAIL"
                    Return EMAIL
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "Hidden_STUDENT_ID"
                    Return Hidden_STUDENT_ID
                Case "Hidden_LAST_ALTERED_BY"
                    Return Hidden_LAST_ALTERED_BY
                Case "FIRST_NAME"
                    Return FIRST_NAME
                Case "SURNAME"
                    Return SURNAME
                Case "HOME_PHONE"
                    Return HOME_PHONE
                Case "Hidden_STUDENT_ID_OTHER"
                    Return Hidden_STUDENT_ID_OTHER
                Case "Student_Firstname"
                    Return Student_Firstname
                Case "Student_Surname"
                    Return Student_Surname
                Case "Dupe_CARER_ID"
                    Return Dupe_CARER_ID
                Case "lblNoCarer"
                    Return lblNoCarer
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "RELATIONSHIP"
                    RELATIONSHIP = CType(value, TextField)
                Case "WORK_PHONE"
                    WORK_PHONE = CType(value, TextField)
                Case "MOBILE"
                    MOBILE = CType(value, TextField)
                Case "EMAIL"
                    EMAIL = CType(value, TextField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "Hidden_STUDENT_ID"
                    Hidden_STUDENT_ID = CType(value, TextField)
                Case "Hidden_LAST_ALTERED_BY"
                    Hidden_LAST_ALTERED_BY = CType(value, TextField)
                Case "FIRST_NAME"
                    FIRST_NAME = CType(value, TextField)
                Case "SURNAME"
                    SURNAME = CType(value, TextField)
                Case "HOME_PHONE"
                    HOME_PHONE = CType(value, TextField)
                Case "Hidden_STUDENT_ID_OTHER"
                    Hidden_STUDENT_ID_OTHER = CType(value, TextField)
                Case "Student_Firstname"
                    Student_Firstname = CType(value, TextField)
                Case "Student_Surname"
                    Student_Surname = CType(value, TextField)
                Case "Dupe_CARER_ID"
                    Dupe_CARER_ID = CType(value, IntegerField)
                Case "lblNoCarer"
                    lblNoCarer = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STUDENT_CARER_CONTACT4DataProvider)
'End Record STUDENT_CARER_CONTACT4 Item Class

'RELATIONSHIP validate @106-14A3EB67
        If IsNothing(RELATIONSHIP.Value) OrElse RELATIONSHIP.Value.ToString() ="" Then
            errors.Add("RELATIONSHIP",String.Format(Resources.strings.CCS_RequiredField,"RELATIONSHIP"))
        End If
'End RELATIONSHIP validate

'DEL      ' -------------------------
'DEL      'ERA: check that at least one of HOME, WORK, or MOBILE phone numbers are provided.
'DEL  	If ((HOME_PHONE.Value Is Nothing) OrElse HOME_PHONE.Value.ToString()="")  AND ((WORK_PHONE.Value Is Nothing) OrElse WORK_PHONE.Value.ToString()="") AND ((MOBILE.Value Is Nothing) OrElse MOBILE.Value.ToString()="")  Then
'DEL              errors.Add("STUDENT_CARER_CONTACT3",String.Format("At least ONE of HOME PHONE, WORK PHONE, or MOBILE is required.","STUDENT_CARER_CONTACT3"))
'DEL      End If
'DEL      ' -------------------------

'Record STUDENT_CARER_CONTACT4 Item Class tail @99-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_CARER_CONTACT4 Item Class tail

'Record STUDENT_CARER_CONTACT4 Data Provider Class @99-393E3554
Public Class STUDENT_CARER_CONTACT4DataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_CARER_CONTACT4 Data Provider Class

'Record STUDENT_CARER_CONTACT4 Data Provider Class Variables @99-41FC59A0
    Public UrlSTUDENT_ID_OTHER As FloatParameter
    Public CtrlHidden_STUDENT_ID As FloatParameter
    Public CtrlDupe_CARER_ID As IntegerParameter
    Protected item As STUDENT_CARER_CONTACT4Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_CARER_CONTACT4 Data Provider Class Variables

'Record STUDENT_CARER_CONTACT4 Data Provider Class Constructor @99-9BDEADA8

    Public Sub New()
        Select_=new TableCommand("SELECT STUDENT_CARER_CONTACT.*, rtrim(STUDENT.SURNAME) AS STUDENT_SURNAME, " & vbCrLf & _
          "rtrim(STUDENT.FIRST_NAME) AS STUDENT_FIRST_NAME " & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT RIGHT JOIN STUDENT ON" & vbCrLf & _
          "STUDENT_CARER_CONTACT.CARER_ID = STUDENT.CARER_ID_PARENT_A {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID_OTHER274"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_CARER_CONTACT4 Data Provider Class Constructor

'Record STUDENT_CARER_CONTACT4 Data Provider Class LoadParams Method @99-BAAA0F59

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID_OTHER))
    End Function
'End Record STUDENT_CARER_CONTACT4 Data Provider Class LoadParams Method

'Record STUDENT_CARER_CONTACT4 Data Provider Class CheckUnique Method @99-B022CBBE

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_CARER_CONTACT4Item) As Boolean
        Return True
    End Function
'End Record STUDENT_CARER_CONTACT4 Data Provider Class CheckUnique Method

'Record STUDENT_CARER_CONTACT4 Data Provider Class PrepareUpdate Method @99-C705D8AE

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = Not(IsNothing(item.Hidden_STUDENT_ID))
'End Record STUDENT_CARER_CONTACT4 Data Provider Class PrepareUpdate Method

'Record STUDENT_CARER_CONTACT4 Data Provider Class PrepareUpdate Method tail @99-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT4 Data Provider Class PrepareUpdate Method tail

'Record STUDENT_CARER_CONTACT4 Data Provider Class Update Method @99-08DB5C9F

    Public Function UpdateItem(ByVal item As STUDENT_CARER_CONTACT4Item) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT SET {Values}", New String(){"Hidden_STUDENT_ID192"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_CARER_CONTACT4 Data Provider Class Update Method

'Record STUDENT_CARER_CONTACT4 BeforeBuildUpdate @99-EE3A9E50
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("Hidden_STUDENT_ID192",item.Hidden_STUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        allEmptyFlag = item.Dupe_CARER_ID.IsEmpty And allEmptyFlag
        If Not item.Dupe_CARER_ID.IsEmpty Then
        If IsNothing(item.Dupe_CARER_ID.Value) Then
        valuesList = valuesList & "CARER_ID_PARENT_A=" & Update.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        valuesList = valuesList & "CARER_ID_PARENT_A=" & Update.Dao.ToSql(item.Dupe_CARER_ID.GetFormattedValue(""),FieldType._Integer) & ","
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
'End Record STUDENT_CARER_CONTACT4 BeforeBuildUpdate

'Record STUDENT_CARER_CONTACT4 AfterExecuteUpdate @99-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_CARER_CONTACT4 AfterExecuteUpdate

'Record STUDENT_CARER_CONTACT4 Data Provider Class GetResultSet Method @99-7ADC7C73

    Public Sub FillItem(ByVal item As STUDENT_CARER_CONTACT4Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_CARER_CONTACT4 Data Provider Class GetResultSet Method

'Record STUDENT_CARER_CONTACT4 BeforeBuildSelect @99-DECB86B8
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID_OTHER274",UrlSTUDENT_ID_OTHER, "","STUDENT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_CARER_CONTACT4 BeforeBuildSelect

'Record STUDENT_CARER_CONTACT4 BeforeExecuteSelect @99-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_CARER_CONTACT4 BeforeExecuteSelect

'Record STUDENT_CARER_CONTACT4 AfterExecuteSelect @99-F6A8DDC2
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.RELATIONSHIP.SetValue(dr(i)("RELATIONSHIP"),"")
            item.WORK_PHONE.SetValue(dr(i)("WORK_PHONE"),"")
            item.MOBILE.SetValue(dr(i)("MOBILE"),"")
            item.EMAIL.SetValue(dr(i)("EMAIL"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.Hidden_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
            item.SURNAME.SetValue(dr(i)("SURNAME"),"")
            item.HOME_PHONE.SetValue(dr(i)("HOME_PHONE"),"")
            item.Student_Firstname.SetValue(dr(i)("STUDENT_FIRST_NAME"),"")
            item.Student_Surname.SetValue(dr(i)("STUDENT_SURNAME"),"")
            item.Dupe_CARER_ID.SetValue(dr(i)("CARER_ID"),"")
        Else
            IsInsertMode = True
        End If
'End Record STUDENT_CARER_CONTACT4 AfterExecuteSelect

'ListBox RELATIONSHIP AfterExecuteSelect @106-D6CE2666
        
item.RELATIONSHIPItems.Add("PA","Parent")
item.RELATIONSHIPItems.Add("SP","Step-Parent")
item.RELATIONSHIPItems.Add("AP","Adoptive Parent")
item.RELATIONSHIPItems.Add("FP","Foster Parent")
item.RELATIONSHIPItems.Add("GP","Grand Parent")
item.RELATIONSHIPItems.Add("HF","Host Family")
item.RELATIONSHIPItems.Add("RE","Relative")
item.RELATIONSHIPItems.Add("FR","Friend")
item.RELATIONSHIPItems.Add("SE","Self")
item.RELATIONSHIPItems.Add("OT","Other")
'End ListBox RELATIONSHIP AfterExecuteSelect

'Record STUDENT_CARER_CONTACT4 AfterExecuteSelect tail @99-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT4 AfterExecuteSelect tail

'Record STUDENT_CARER_CONTACT4 Data Provider Class @99-A61BA892
End Class

'End Record STUDENT_CARER_CONTACT4 Data Provider Class

'Grid Grid_FamilyGroup Item Class @256-FA51D384
Public Class Grid_FamilyGroupItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STUDENT_ID As FloatField
    Public STUDENT_IDHref As Object
    Public STUDENT_IDHrefParameters As LinkParameterCollection
    Public first_name As TextField
    Public surname As TextField
    Public last_enrol_year As FloatField
    Public Sub New()
    STUDENT_ID = New FloatField("",Nothing)
    STUDENT_IDHrefParameters = New LinkParameterCollection()
    first_name = New TextField("", Nothing)
    surname = New TextField("", Nothing)
    last_enrol_year = New FloatField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "first_name"
                    Return Me.first_name
                Case "surname"
                    Return Me.surname
                Case "last_enrol_year"
                    Return Me.last_enrol_year
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "first_name"
                    Me.first_name = CType(Value,TextField)
                Case "surname"
                    Me.surname = CType(Value,TextField)
                Case "last_enrol_year"
                    Me.last_enrol_year = CType(Value,FloatField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid Grid_FamilyGroup Item Class

'Grid Grid_FamilyGroup Data Provider Class Header @256-7B26D613
Public Class Grid_FamilyGroupDataProvider
Inherits GridDataProviderBase
'End Grid Grid_FamilyGroup Data Provider Class Header

'Grid Grid_FamilyGroup Data Provider Class Variables @256-B9638A4A

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {"surname, first_name"}
    Private SortFieldsNamesDesc As String() = New string() {"surname, first_name"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 20
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As IntegerParameter
'End Grid Grid_FamilyGroup Data Provider Class Variables

'Grid Grid_FamilyGroup Data Provider Class GetResultSet Method @256-D6FCAF55

    Public Sub New()
        Select_=new SqlCommand("select top 20 * " & vbCrLf & _
          "from view_FamilyGrouping" & vbCrLf & _
          "where student_id <> {STUDENT_ID}" & vbCrLf & _
          "and CARER_ID_PARENT_AB in (select CARER_ID_PARENT_AB from view_FamilyGrouping where Studen" & _
          "t_id = {STUDENT_ID}) {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (select top 20 * " & vbCrLf & _
          "from view_FamilyGrouping" & vbCrLf & _
          "where student_id <> {STUDENT_ID}" & vbCrLf & _
          "and CARER_ID_PARENT_AB in (select CARER_ID_PARENT_AB from view_FamilyGrouping where Studen" & _
          "t_id = {STUDENT_ID})) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid Grid_FamilyGroup Data Provider Class GetResultSet Method

'Grid Grid_FamilyGroup Data Provider Class GetResultSet Method @256-C24496AF
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As Grid_FamilyGroupItem()
'End Grid Grid_FamilyGroup Data Provider Class GetResultSet Method

'Before build Select @256-29E282D2
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("STUDENT_ID",UrlSTUDENT_ID, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @256-228044E3
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As Grid_FamilyGroupItem
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

'After execute Select @256-F46B69EB
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New Grid_FamilyGroupItem(dr.Count-1) {}
'End After execute Select

'After execute Select @256-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @256-271BC38D
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as Grid_FamilyGroupItem = New Grid_FamilyGroupItem()
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.STUDENT_IDHref = "StudentSummary.aspx"
                item.STUDENT_IDHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
                item.STUDENT_IDHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("last_enrol_year").ToString()))
                item.first_name.SetValue(dr(i)("first_name"),"")
                item.surname.SetValue(dr(i)("surname"),"")
                item.last_enrol_year.SetValue(dr(i)("last_enrol_year"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @256-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

