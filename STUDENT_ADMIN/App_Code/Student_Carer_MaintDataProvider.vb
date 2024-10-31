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

Namespace DECV_PROD2007.Student_Carer_Maint 'Namespace @1-4F98C101

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

'Grid Grid1 Item Class @4-63ED0BC8
Public Class Grid1Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Grid1_AddCarer As TextField
    Public Grid1_AddCarerHref As Object
    Public Grid1_AddCarerHrefParameters As LinkParameterCollection
    Public Detail As TextField
    Public DetailHref As Object
    Public DetailHrefParameters As LinkParameterCollection
    Public TITLE As TextField
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public HOME_PHONE As TextField
    Public WORK_PHONE As TextField
    Public MOBILE As TextField
    Public EMAIL As TextField
    Public RELATIONSHIP As TextField
    Public Grid1_AddSuperVisor As TextField
    Public Grid1_AddSuperVisorHref As Object
    Public Grid1_AddSuperVisorHrefParameters As LinkParameterCollection
    Public Sub New()
    Grid1_AddCarer = New TextField("",Nothing)
    Grid1_AddCarerHrefParameters = New LinkParameterCollection()
    Detail = New TextField("",Nothing)
    DetailHrefParameters = New LinkParameterCollection()
    TITLE = New TextField("", Nothing)
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    HOME_PHONE = New TextField("", Nothing)
    WORK_PHONE = New TextField("", Nothing)
    MOBILE = New TextField("", Nothing)
    EMAIL = New TextField("", Nothing)
    RELATIONSHIP = New TextField("", Nothing)
    Grid1_AddSuperVisor = New TextField("",Nothing)
    Grid1_AddSuperVisorHrefParameters = New LinkParameterCollection()
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "Grid1_AddCarer"
                    Return Me.Grid1_AddCarer
                Case "Detail"
                    Return Me.Detail
                Case "TITLE"
                    Return Me.TITLE
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "HOME_PHONE"
                    Return Me.HOME_PHONE
                Case "WORK_PHONE"
                    Return Me.WORK_PHONE
                Case "MOBILE"
                    Return Me.MOBILE
                Case "EMAIL"
                    Return Me.EMAIL
                Case "RELATIONSHIP"
                    Return Me.RELATIONSHIP
                Case "Grid1_AddSuperVisor"
                    Return Me.Grid1_AddSuperVisor
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Grid1_AddCarer"
                    Me.Grid1_AddCarer = CType(Value,TextField)
                Case "Detail"
                    Me.Detail = CType(Value,TextField)
                Case "TITLE"
                    Me.TITLE = CType(Value,TextField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "HOME_PHONE"
                    Me.HOME_PHONE = CType(Value,TextField)
                Case "WORK_PHONE"
                    Me.WORK_PHONE = CType(Value,TextField)
                Case "MOBILE"
                    Me.MOBILE = CType(Value,TextField)
                Case "EMAIL"
                    Me.EMAIL = CType(Value,TextField)
                Case "RELATIONSHIP"
                    Me.RELATIONSHIP = CType(Value,TextField)
                Case "Grid1_AddSuperVisor"
                    Me.Grid1_AddSuperVisor = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid Grid1 Item Class

'Grid Grid1 Data Provider Class Header @4-006C0918
Public Class Grid1DataProvider
Inherits GridDataProviderBase
'End Grid Grid1 Data Provider Class Header

'Grid Grid1 Data Provider Class Variables @4-4EF13EA5

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_TITLE
        Sorter_SURNAME
        Sorter_FIRST_NAME
        Sorter_HOME_PHONE
        Sorter_WORK_PHONE
        Sorter_MOBILE
        Sorter_EMAIL
        Sorter_RELATIONSHIP
    End Enum

    Private SortFieldsNames As String() = New String() {"","TITLE","SURNAME","FIRST_NAME","HOME_PHONE","WORK_PHONE","MOBILE","EMAIL","RELATIONSHIP"}
    Private SortFieldsNamesDesc As String() = New string() {"","TITLE DESC","SURNAME DESC","FIRST_NAME DESC","HOME_PHONE DESC","WORK_PHONE DESC","MOBILE DESC","EMAIL DESC","RELATIONSHIP DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 10
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As FloatParameter
    Public UrlENROLMENT_YEAR  As TextParameter
'End Grid Grid1 Data Provider Class Variables

'Grid Grid1 Data Provider Class GetResultSet Method @4-0960D883

    Public Sub New()
        Select_=new SqlCommand("select CARER_ID, TITLE, SURNAME, FIRST_NAME, RELATIONSHIP, HOME_PHONE, WORK_PHONE, MOBILE," & _
          " EMAIL, LAST_ALTERED_BY, LAST_ALTERED_DATE from STUDENT_CARER_CONTACT where carer_id in (" & vbCrLf & _
          "select Parent1 FROM STUDENT WHERE STUDENT_ID={STUDENT_ID}" & vbCrLf & _
          "union " & vbCrLf & _
          "select Parent2 FROM STUDENT  WHERE STUDENT_ID={STUDENT_ID}" & vbCrLf & _
          "union" & vbCrLf & _
          "select SCHOOL_SUPERVISOR_NAME FROM STUDENT_ENROLMENT  WHERE STUDENT_ID={STUDENT_ID} and EN" & _
          "ROLMENT_YEAR={ENROLMENT_YEAR}" & vbCrLf & _
          ")",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (select CARER_ID, TITLE, SURNAME, FIRST_NAME, RELATIONSHIP, HOME_PHON" & _
          "E, WORK_PHONE, MOBILE, EMAIL, LAST_ALTERED_BY, LAST_ALTERED_DATE from STUDENT_CARER_CONTAC" & _
          "T where carer_id in (" & vbCrLf & _
          "select Parent1 FROM STUDENT WHERE STUDENT_ID={STUDENT_ID}" & vbCrLf & _
          "union " & vbCrLf & _
          "select Parent2 FROM STUDENT  WHERE STUDENT_ID={STUDENT_ID}" & vbCrLf & _
          "union" & vbCrLf & _
          "select SCHOOL_SUPERVISOR_NAME FROM STUDENT_ENROLMENT  WHERE STUDENT_ID={STUDENT_ID} and EN" & _
          "ROLMENT_YEAR={ENROLMENT_YEAR}" & vbCrLf & _
          ")) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid Grid1 Data Provider Class GetResultSet Method

'Grid Grid1 Data Provider Class GetResultSet Method @4-B71B9457
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As Grid1Item()
'End Grid Grid1 Data Provider Class GetResultSet Method

'Before build Select @4-A84CD653
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

'Execute Select @4-736390FB
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As Grid1Item
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

'After execute Select @4-AAB11005
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New Grid1Item(dr.Count-1) {}
'End After execute Select

'After execute Select @4-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @4-3BA76274
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as Grid1Item = New Grid1Item()
                item.Grid1_AddCarerHref = "Student_Carer_Maint.aspx"
                item.DetailHref = "Student_Carer_Maint.aspx"
                item.DetailHrefParameters.Add("CARER_ID",System.Web.HttpUtility.UrlEncode(dr(i)("CARER_ID").ToString()))
                item.TITLE.SetValue(dr(i)("TITLE"),"")
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.HOME_PHONE.SetValue(dr(i)("HOME_PHONE"),"")
                item.WORK_PHONE.SetValue(dr(i)("WORK_PHONE"),"")
                item.MOBILE.SetValue(dr(i)("MOBILE"),"")
                item.EMAIL.SetValue(dr(i)("EMAIL"),"")
                item.RELATIONSHIP.SetValue(dr(i)("RELATIONSHIP"),"")
                item.Grid1_AddSuperVisorHref = "Student_Carer_Maint.aspx"
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @4-A61BA892
End Class
'End Grid Data Provider tail

'Record STUDENT_CARER_CONTACT Item Class @31-ADED1BEA
Public Class STUDENT_CARER_CONTACTItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public TITLE As TextField
    Public TITLEItems As ItemCollection
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public HOME_PHONE As TextField
    Public WORK_PHONE As TextField
    Public MOBILE As TextField
    Public EMAIL As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public RELATIONSHIP As TextField
    Public RELATIONSHIPItems As ItemCollection
    Public Label_MESSAGE As TextField
    Public Hidden_Surname As TextField
    Public Hidden_Carer_ID As TextField
    Public Sub New()
    TITLE = New TextField("", Nothing)
    TITLEItems = New ItemCollection()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    HOME_PHONE = New TextField("", Nothing)
    WORK_PHONE = New TextField("", Nothing)
    MOBILE = New TextField("", Nothing)
    EMAIL = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", DBUTILITY.USERID)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    RELATIONSHIP = New TextField("", Nothing)
    RELATIONSHIPItems = New ItemCollection()
    Label_MESSAGE = New TextField("", "CARER")
    Hidden_Surname = New TextField("", Nothing)
    Hidden_Carer_ID = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_CARER_CONTACTItem
        Dim item As STUDENT_CARER_CONTACTItem = New STUDENT_CARER_CONTACTItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("TITLE")) Then
        item.TITLE.SetValue(DBUtility.GetInitialValue("TITLE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SURNAME")) Then
        item.SURNAME.SetValue(DBUtility.GetInitialValue("SURNAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FIRST_NAME")) Then
        item.FIRST_NAME.SetValue(DBUtility.GetInitialValue("FIRST_NAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("HOME_PHONE")) Then
        item.HOME_PHONE.SetValue(DBUtility.GetInitialValue("HOME_PHONE"))
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
        If Not IsNothing(DBUtility.GetInitialValue("RELATIONSHIP")) Then
        item.RELATIONSHIP.SetValue(DBUtility.GetInitialValue("RELATIONSHIP"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Label_MESSAGE")) Then
        item.Label_MESSAGE.SetValue(DBUtility.GetInitialValue("Label_MESSAGE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_Surname")) Then
        item.Hidden_Surname.SetValue(DBUtility.GetInitialValue("Hidden_Surname"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_Carer_ID")) Then
        item.Hidden_Carer_ID.SetValue(DBUtility.GetInitialValue("Hidden_Carer_ID"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "TITLE"
                    Return TITLE
                Case "SURNAME"
                    Return SURNAME
                Case "FIRST_NAME"
                    Return FIRST_NAME
                Case "HOME_PHONE"
                    Return HOME_PHONE
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
                Case "RELATIONSHIP"
                    Return RELATIONSHIP
                Case "Label_MESSAGE"
                    Return Label_MESSAGE
                Case "Hidden_Surname"
                    Return Hidden_Surname
                Case "Hidden_Carer_ID"
                    Return Hidden_Carer_ID
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "TITLE"
                    TITLE = CType(value, TextField)
                Case "SURNAME"
                    SURNAME = CType(value, TextField)
                Case "FIRST_NAME"
                    FIRST_NAME = CType(value, TextField)
                Case "HOME_PHONE"
                    HOME_PHONE = CType(value, TextField)
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
                Case "RELATIONSHIP"
                    RELATIONSHIP = CType(value, TextField)
                Case "Label_MESSAGE"
                    Label_MESSAGE = CType(value, TextField)
                Case "Hidden_Surname"
                    Hidden_Surname = CType(value, TextField)
                Case "Hidden_Carer_ID"
                    Hidden_Carer_ID = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STUDENT_CARER_CONTACTDataProvider)
'End Record STUDENT_CARER_CONTACT Item Class

'SURNAME validate @37-F35C1CC1
        If IsNothing(SURNAME.Value) OrElse SURNAME.Value.ToString() ="" Then
            errors.Add("SURNAME",String.Format(Resources.strings.CCS_RequiredField,"SURNAME"))
        End If
'End SURNAME validate

'FIRST_NAME validate @38-EF10D039
        If IsNothing(FIRST_NAME.Value) OrElse FIRST_NAME.Value.ToString() ="" Then
            errors.Add("FIRST_NAME",String.Format(Resources.strings.CCS_RequiredField,"FIRST NAME"))
        End If
'End FIRST_NAME validate

'LAST_ALTERED_BY validate @44-256A6854
        If IsNothing(LAST_ALTERED_BY.Value) OrElse LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End LAST_ALTERED_BY validate

'LAST_ALTERED_DATE validate @45-C5989D76
        If IsNothing(LAST_ALTERED_DATE.Value) OrElse LAST_ALTERED_DATE.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED DATE"))
        End If
'End LAST_ALTERED_DATE validate

'RELATIONSHIP validate @70-14A3EB67
        If IsNothing(RELATIONSHIP.Value) OrElse RELATIONSHIP.Value.ToString() ="" Then
            errors.Add("RELATIONSHIP",String.Format(Resources.strings.CCS_RequiredField,"RELATIONSHIP"))
        End If
'End RELATIONSHIP validate

'Record STUDENT_CARER_CONTACT Item Class tail @31-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_CARER_CONTACT Item Class tail

'Record STUDENT_CARER_CONTACT Data Provider Class @31-B9F71DEB
Public Class STUDENT_CARER_CONTACTDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_CARER_CONTACT Data Provider Class

'Record STUDENT_CARER_CONTACT Data Provider Class Variables @31-C683B14F
    Public UrlCARER_ID As FloatParameter
    Public UrlRETURN_VALUE As IntegerParameter
    Public CtrlHidden_Carer_ID As FloatParameter
    Public UrlStudent_ID As FloatParameter
    Public UrlENROLMENT_YEAR As FloatParameter
    Public CtrlTITLE As TextParameter
    Public CtrlSURNAME As TextParameter
    Public CtrlFIRST_NAME As TextParameter
    Public CtrlRELATIONSHIP As TextParameter
    Public CtrlHOME_PHONE As TextParameter
    Public CtrlWORK_PHONE As TextParameter
    Public CtrlMOBILE As TextParameter
    Public CtrlEMAIL As TextParameter
    Public CtrlLAST_ALTERED_BY As TextParameter
    Protected item As STUDENT_CARER_CONTACTItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_CARER_CONTACT Data Provider Class Variables

'Record STUDENT_CARER_CONTACT Data Provider Class Constructor @31-64BD4AD8

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT {SQL_Where} {SQL_OrderBy}", New String(){"CARER_ID35"},Settings.connDECVPRODSQL2005DataAccessObject )
        Insert=new SpCommand("USP_Student_CARER_CONTACT_ADD_UPDATE;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Update=new SpCommand("USP_Student_CARER_CONTACT_ADD_UPDATE;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_CARER_CONTACT Data Provider Class Constructor

'Record STUDENT_CARER_CONTACT Data Provider Class LoadParams Method @31-206CC6BD

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlCARER_ID))
    End Function
'End Record STUDENT_CARER_CONTACT Data Provider Class LoadParams Method

'Record STUDENT_CARER_CONTACT Data Provider Class CheckUnique Method @31-51ACE20F

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_CARER_CONTACTItem) As Boolean
        Return True
    End Function
'End Record STUDENT_CARER_CONTACT Data Provider Class CheckUnique Method

'Record STUDENT_CARER_CONTACT Data Provider Class PrepareInsert Method @31-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STUDENT_CARER_CONTACT Data Provider Class PrepareInsert Method

'Record STUDENT_CARER_CONTACT Data Provider Class PrepareInsert Method tail @31-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT Data Provider Class PrepareInsert Method tail

'Record STUDENT_CARER_CONTACT Data Provider Class Insert Method @31-47F42782

    Public Function InsertItem(ByVal item As STUDENT_CARER_CONTACTItem) As Integer
        Me.item = item
'End Record STUDENT_CARER_CONTACT Data Provider Class Insert Method

'Record STUDENT_CARER_CONTACT Build insert @31-72AB4D2B
        Insert.Parameters.Clear()
        CType(Insert,SpCommand).AddParameter("@RETURN_VALUE",UrlRETURN_VALUE,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Insert,SpCommand).AddParameter("@Contact_ID",item.Hidden_Carer_ID,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Insert,SpCommand).AddParameter("@Student_ID",UrlStudent_ID,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Insert,SpCommand).AddParameter("@EnrolmentYear",UrlENROLMENT_YEAR,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Insert,SpCommand).AddParameter("@Title",item.TITLE,ParameterType._VarChar,ParameterDirection.Input,10,0,18)
        CType(Insert,SpCommand).AddParameter("@Surname",item.SURNAME,ParameterType._VarChar,ParameterDirection.Input,30,0,18)
        CType(Insert,SpCommand).AddParameter("@FirstName",item.FIRST_NAME,ParameterType._VarChar,ParameterDirection.Input,30,0,18)
        CType(Insert,SpCommand).AddParameter("@Relation",item.RELATIONSHIP,ParameterType._VarChar,ParameterDirection.Input,2,0,18)
        CType(Insert,SpCommand).AddParameter("@Home_Phone",item.HOME_PHONE,ParameterType._VarChar,ParameterDirection.Input,20,0,18)
        CType(Insert,SpCommand).AddParameter("@Work_Phone",item.WORK_PHONE,ParameterType._VarChar,ParameterDirection.Input,20,0,18)
        CType(Insert,SpCommand).AddParameter("@Mobile",item.MOBILE,ParameterType._VarChar,ParameterDirection.Input,20,0,18)
        CType(Insert,SpCommand).AddParameter("@Email",item.EMAIL,ParameterType._VarChar,ParameterDirection.Input,250,0,18)
        CType(Insert,SpCommand).AddParameter("@Last_Altered_By",item.LAST_ALTERED_BY,ParameterType._Char,ParameterDirection.Input,8,0,18)
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
            result = ExecuteInsert()
            UrlRETURN_VALUE = IntegerParameter.GetParam(CType(Insert.Parameters("@RETURN_VALUE"),IDataParameter).Value)
        Catch ee As Exception
            E = ee
        Finally
'End Record STUDENT_CARER_CONTACT Build insert

'Record STUDENT_CARER_CONTACT AfterExecuteInsert @31-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_CARER_CONTACT AfterExecuteInsert

'Record STUDENT_CARER_CONTACT Data Provider Class PrepareUpdate Method @31-0A131024

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
'End Record STUDENT_CARER_CONTACT Data Provider Class PrepareUpdate Method

'Record STUDENT_CARER_CONTACT Data Provider Class PrepareUpdate Method tail @31-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT Data Provider Class PrepareUpdate Method tail

'Record STUDENT_CARER_CONTACT Data Provider Class Update Method @31-8D2889C1

    Public Function UpdateItem(ByVal item As STUDENT_CARER_CONTACTItem) As Integer
        Me.item = item
'End Record STUDENT_CARER_CONTACT Data Provider Class Update Method

'Record STUDENT_CARER_CONTACT BeforeBuildUpdate @31-D463760B
        Update.Parameters.Clear()
        CType(Update,SpCommand).AddParameter("@RETURN_VALUE",UrlRETURN_VALUE,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Update,SpCommand).AddParameter("@Contact_ID",item.Hidden_Carer_ID,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Update,SpCommand).AddParameter("@Student_ID",UrlStudent_ID,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Update,SpCommand).AddParameter("@EnrolmentYear",UrlENROLMENT_YEAR,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Update,SpCommand).AddParameter("@Title",item.TITLE,ParameterType._VarChar,ParameterDirection.Input,10,0,18)
        CType(Update,SpCommand).AddParameter("@Surname",item.SURNAME,ParameterType._VarChar,ParameterDirection.Input,30,0,18)
        CType(Update,SpCommand).AddParameter("@FirstName",item.FIRST_NAME,ParameterType._VarChar,ParameterDirection.Input,30,0,18)
        CType(Update,SpCommand).AddParameter("@Relation",item.RELATIONSHIP,ParameterType._VarChar,ParameterDirection.Input,2,0,18)
        CType(Update,SpCommand).AddParameter("@Home_Phone",item.HOME_PHONE,ParameterType._VarChar,ParameterDirection.Input,20,0,18)
        CType(Update,SpCommand).AddParameter("@Work_Phone",item.WORK_PHONE,ParameterType._VarChar,ParameterDirection.Input,20,0,18)
        CType(Update,SpCommand).AddParameter("@Mobile",item.MOBILE,ParameterType._VarChar,ParameterDirection.Input,20,0,18)
        CType(Update,SpCommand).AddParameter("@Email",item.EMAIL,ParameterType._VarChar,ParameterDirection.Input,250,0,18)
        CType(Update,SpCommand).AddParameter("@Last_Altered_By",item.LAST_ALTERED_BY,ParameterType._Char,ParameterDirection.Input,8,0,18)
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
            result = ExecuteUpdate()
            UrlRETURN_VALUE = IntegerParameter.GetParam(CType(Update.Parameters("@RETURN_VALUE"),IDataParameter).Value)
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record STUDENT_CARER_CONTACT BeforeBuildUpdate

'Record STUDENT_CARER_CONTACT AfterExecuteUpdate @31-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_CARER_CONTACT AfterExecuteUpdate

'Record STUDENT_CARER_CONTACT Data Provider Class GetResultSet Method @31-5BF273E5

    Public Sub FillItem(ByVal item As STUDENT_CARER_CONTACTItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_CARER_CONTACT Data Provider Class GetResultSet Method

'Record STUDENT_CARER_CONTACT BeforeBuildSelect @31-E5BAB19A
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("CARER_ID35",UrlCARER_ID, "","CARER_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_CARER_CONTACT BeforeBuildSelect

'Record STUDENT_CARER_CONTACT BeforeExecuteSelect @31-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_CARER_CONTACT BeforeExecuteSelect

'Record STUDENT_CARER_CONTACT AfterExecuteSelect @31-62C07285
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.TITLE.SetValue(dr(i)("TITLE"),"")
            item.SURNAME.SetValue(dr(i)("SURNAME"),"")
            item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
            item.HOME_PHONE.SetValue(dr(i)("HOME_PHONE"),"")
            item.WORK_PHONE.SetValue(dr(i)("WORK_PHONE"),"")
            item.MOBILE.SetValue(dr(i)("MOBILE"),"")
            item.EMAIL.SetValue(dr(i)("EMAIL"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.RELATIONSHIP.SetValue(dr(i)("RELATIONSHIP"),"")
        Else
            IsInsertMode = True
        End If
'End Record STUDENT_CARER_CONTACT AfterExecuteSelect

'ListBox TITLE AfterExecuteSelect @36-94456D11
        
item.TITLEItems.Add("MR","Mr")
item.TITLEItems.Add("MRS","Mrs")
item.TITLEItems.Add("Miss","Miss")
item.TITLEItems.Add("Ms","Ms")
'End ListBox TITLE AfterExecuteSelect

'ListBox RELATIONSHIP AfterExecuteSelect @70-627D3262
        
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
item.RELATIONSHIPItems.Add("SS","School Supervisor")
'End ListBox RELATIONSHIP AfterExecuteSelect

'Record STUDENT_CARER_CONTACT AfterExecuteSelect tail @31-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT AfterExecuteSelect tail

'Record STUDENT_CARER_CONTACT Data Provider Class @31-A61BA892
End Class

'End Record STUDENT_CARER_CONTACT Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

