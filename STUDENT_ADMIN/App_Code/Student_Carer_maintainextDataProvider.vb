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

Namespace DECV_PROD2007.Student_Carer_maintainext 'Namespace @1-59A439EF

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

'Grid STUDENT_CARER_CONTACT Item Class @3-3B98F51D
Public Class STUDENT_CARER_CONTACTItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public CARER_ID As FloatField
    Public TITLE As TextField
    Public RELATIONSHIP As TextField
    Public RELATIONSHIPItems As ItemCollection
    Public HOME_PHONE As TextField
    Public WORK_PHONE As TextField
    Public MOBILE As TextField
    Public EMAIL As TextField
    Public EMAILHref As Object
    Public EMAILHrefParameters As LinkParameterCollection
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public link_AddParent As TextField
    Public link_AddParentHref As Object
    Public link_AddParentHrefParameters As LinkParameterCollection
    Public Link_EditParentA As TextField
    Public Link_EditParentAHref As Object
    Public Link_EditParentAHrefParameters As LinkParameterCollection
    Public linkFamilyGroup As TextField
    Public linkFamilyGroupHref As Object
    Public linkFamilyGroupHrefParameters As LinkParameterCollection
    Public PORTAL_LAST_LOGIN_DATE As DateField
    Public Sub New()
    CARER_ID = New FloatField("", Nothing)
    TITLE = New TextField("", Nothing)
    RELATIONSHIP = New TextField("", Nothing)
    RELATIONSHIPItems = New ItemCollection()
    HOME_PHONE = New TextField("", Nothing)
    WORK_PHONE = New TextField("", Nothing)
    MOBILE = New TextField("", Nothing)
    EMAIL = New TextField("",Nothing)
    EMAILHrefParameters = New LinkParameterCollection()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    link_AddParent = New TextField("",Nothing)
    link_AddParentHrefParameters = New LinkParameterCollection()
    Link_EditParentA = New TextField("",Nothing)
    Link_EditParentAHrefParameters = New LinkParameterCollection()
    linkFamilyGroup = New TextField("",Nothing)
    linkFamilyGroupHrefParameters = New LinkParameterCollection()
    PORTAL_LAST_LOGIN_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "CARER_ID"
                    Return Me.CARER_ID
                Case "TITLE"
                    Return Me.TITLE
                Case "RELATIONSHIP"
                    Return Me.RELATIONSHIP
                Case "HOME_PHONE"
                    Return Me.HOME_PHONE
                Case "WORK_PHONE"
                    Return Me.WORK_PHONE
                Case "MOBILE"
                    Return Me.MOBILE
                Case "EMAIL"
                    Return Me.EMAIL
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "link_AddParent"
                    Return Me.link_AddParent
                Case "Link_EditParentA"
                    Return Me.Link_EditParentA
                Case "linkFamilyGroup"
                    Return Me.linkFamilyGroup
                Case "PORTAL_LAST_LOGIN_DATE"
                    Return Me.PORTAL_LAST_LOGIN_DATE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "CARER_ID"
                    Me.CARER_ID = CType(Value,FloatField)
                Case "TITLE"
                    Me.TITLE = CType(Value,TextField)
                Case "RELATIONSHIP"
                    Me.RELATIONSHIP = CType(Value,TextField)
                Case "HOME_PHONE"
                    Me.HOME_PHONE = CType(Value,TextField)
                Case "WORK_PHONE"
                    Me.WORK_PHONE = CType(Value,TextField)
                Case "MOBILE"
                    Me.MOBILE = CType(Value,TextField)
                Case "EMAIL"
                    Me.EMAIL = CType(Value,TextField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "link_AddParent"
                    Me.link_AddParent = CType(Value,TextField)
                Case "Link_EditParentA"
                    Me.Link_EditParentA = CType(Value,TextField)
                Case "linkFamilyGroup"
                    Me.linkFamilyGroup = CType(Value,TextField)
                Case "PORTAL_LAST_LOGIN_DATE"
                    Me.PORTAL_LAST_LOGIN_DATE = CType(Value,DateField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STUDENT_CARER_CONTACT Item Class

'Grid STUDENT_CARER_CONTACT Data Provider Class Header @3-63448F4C
Public Class STUDENT_CARER_CONTACTDataProvider
Inherits GridDataProviderBase
'End Grid STUDENT_CARER_CONTACT Data Provider Class Header

'Grid STUDENT_CARER_CONTACT Data Provider Class Variables @3-BC41727F

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {"CARER_ID"}
    Private SortFieldsNamesDesc As String() = New string() {"CARER_ID"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 1
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As TextParameter
'End Grid STUDENT_CARER_CONTACT Data Provider Class Variables

'Grid STUDENT_CARER_CONTACT Data Provider Class GetResultSet Method @3-1A07C845

    Public Sub New()
        Select_=new SqlCommand("SELECT top 1 *" & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT" & vbCrLf & _
          "WHERE ( RELATIONSHIP <> 'SS' ) " & vbCrLf & _
          "AND ( CARER_ID = (SELECT CARER_ID_PARENT_A from STUDENT WHERE STUDENT_ID = {STUDENT_ID})) " & _
          "{SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (SELECT top 1 *" & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT" & vbCrLf & _
          "WHERE ( RELATIONSHIP <> 'SS' ) " & vbCrLf & _
          "AND ( CARER_ID = (SELECT CARER_ID_PARENT_A from STUDENT WHERE STUDENT_ID = {STUDENT_ID})))" & _
          " cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid STUDENT_CARER_CONTACT Data Provider Class GetResultSet Method

'Grid STUDENT_CARER_CONTACT Data Provider Class GetResultSet Method @3-7A95E8D5
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STUDENT_CARER_CONTACTItem()
'End Grid STUDENT_CARER_CONTACT Data Provider Class GetResultSet Method

'Before build Select @3-29E282D2
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

'Execute Select @3-51870128
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STUDENT_CARER_CONTACTItem
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

'After execute Select @3-5A1D65E1
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENT_CARER_CONTACTItem(dr.Count-1) {}
'End After execute Select

'After execute Select @3-79D6687E
            Dim j As Integer
'End After execute Select

'ListBox RELATIONSHIP AfterExecuteSelect @8-FE0A4158
            Dim RELATIONSHIPItems As ItemCollection = New ItemCollection()
            
RELATIONSHIPItems.Add("PA","Parent")
RELATIONSHIPItems.Add("SP","Step-Parent")
RELATIONSHIPItems.Add("AP","Adoptive Parent")
RELATIONSHIPItems.Add("FP","Foster Parent")
RELATIONSHIPItems.Add("GP","Grand Parent")
RELATIONSHIPItems.Add("HF","Host Family")
RELATIONSHIPItems.Add("RE","Relative")
RELATIONSHIPItems.Add("FR","Friend")
RELATIONSHIPItems.Add("SE","Self")
RELATIONSHIPItems.Add("OT","Other")
'End ListBox RELATIONSHIP AfterExecuteSelect

'After execute Select tail @3-08E76F2F
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_CARER_CONTACTItem = New STUDENT_CARER_CONTACTItem()
                item.CARER_ID.SetValue(dr(i)("CARER_ID"),"")
                item.TITLE.SetValue(dr(i)("TITLE"),"")
                item.RELATIONSHIP.SetValue(dr(i)("RELATIONSHIP"),"")
                item.RELATIONSHIPItems = CType(RELATIONSHIPItems.Clone(), ItemCollection)
                item.HOME_PHONE.SetValue(dr(i)("HOME_PHONE"),"")
                item.WORK_PHONE.SetValue(dr(i)("WORK_PHONE"),"")
                item.MOBILE.SetValue(dr(i)("MOBILE"),"")
                item.EMAIL.SetValue(dr(i)("EMAIL"),"")
                item.EMAILHref = dr(i)("EMAIL")
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.link_AddParentHref = "Student_Carer_maintainext.aspx"
                item.Link_EditParentAHref = "Student_Carer_maintainext.aspx"
                item.Link_EditParentAHrefParameters.Add("CARER_ID",System.Web.HttpUtility.UrlEncode(dr(i)("CARER_ID").ToString()))
                item.linkFamilyGroupHref = "Student_Carer_FamilyGrouping.aspx"
                item.PORTAL_LAST_LOGIN_DATE.SetValue(dr(i)("PORTAL_LAST_LOGIN_DATE"),Select_.DateFormat)
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

'Grid STUDENT_CARER_CONTACT1 Item Class @13-FCBC440A
Public Class STUDENT_CARER_CONTACT1Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public CARER_ID As FloatField
    Public TITLE As TextField
    Public HOME_PHONE As TextField
    Public WORK_PHONE As TextField
    Public MOBILE As TextField
    Public EMAIL As TextField
    Public EMAILHref As Object
    Public EMAILHrefParameters As LinkParameterCollection
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public link_AddParent As TextField
    Public link_AddParentHref As Object
    Public link_AddParentHrefParameters As LinkParameterCollection
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public RELATIONSHIP As TextField
    Public RELATIONSHIPItems As ItemCollection
    Public PORTAL_LAST_LOGIN_DATE As DateField
    Public Sub New()
    CARER_ID = New FloatField("", Nothing)
    TITLE = New TextField("", Nothing)
    HOME_PHONE = New TextField("", Nothing)
    WORK_PHONE = New TextField("", Nothing)
    MOBILE = New TextField("", Nothing)
    EMAIL = New TextField("",Nothing)
    EMAILHrefParameters = New LinkParameterCollection()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    link_AddParent = New TextField("",Nothing)
    link_AddParentHrefParameters = New LinkParameterCollection()
    Link1 = New TextField("",Nothing)
    Link1HrefParameters = New LinkParameterCollection()
    RELATIONSHIP = New TextField("", Nothing)
    RELATIONSHIPItems = New ItemCollection()
    PORTAL_LAST_LOGIN_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "CARER_ID"
                    Return Me.CARER_ID
                Case "TITLE"
                    Return Me.TITLE
                Case "HOME_PHONE"
                    Return Me.HOME_PHONE
                Case "WORK_PHONE"
                    Return Me.WORK_PHONE
                Case "MOBILE"
                    Return Me.MOBILE
                Case "EMAIL"
                    Return Me.EMAIL
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "link_AddParent"
                    Return Me.link_AddParent
                Case "Link1"
                    Return Me.Link1
                Case "RELATIONSHIP"
                    Return Me.RELATIONSHIP
                Case "PORTAL_LAST_LOGIN_DATE"
                    Return Me.PORTAL_LAST_LOGIN_DATE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "CARER_ID"
                    Me.CARER_ID = CType(Value,FloatField)
                Case "TITLE"
                    Me.TITLE = CType(Value,TextField)
                Case "HOME_PHONE"
                    Me.HOME_PHONE = CType(Value,TextField)
                Case "WORK_PHONE"
                    Me.WORK_PHONE = CType(Value,TextField)
                Case "MOBILE"
                    Me.MOBILE = CType(Value,TextField)
                Case "EMAIL"
                    Me.EMAIL = CType(Value,TextField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "link_AddParent"
                    Me.link_AddParent = CType(Value,TextField)
                Case "Link1"
                    Me.Link1 = CType(Value,TextField)
                Case "RELATIONSHIP"
                    Me.RELATIONSHIP = CType(Value,TextField)
                Case "PORTAL_LAST_LOGIN_DATE"
                    Me.PORTAL_LAST_LOGIN_DATE = CType(Value,DateField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STUDENT_CARER_CONTACT1 Item Class

'Grid STUDENT_CARER_CONTACT1 Data Provider Class Header @13-6E6284C0
Public Class STUDENT_CARER_CONTACT1DataProvider
Inherits GridDataProviderBase
'End Grid STUDENT_CARER_CONTACT1 Data Provider Class Header

'Grid STUDENT_CARER_CONTACT1 Data Provider Class Variables @13-5896B171

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 1
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As TextParameter
'End Grid STUDENT_CARER_CONTACT1 Data Provider Class Variables

'Grid STUDENT_CARER_CONTACT1 Data Provider Class GetResultSet Method @13-C37BBEA9

    Public Sub New()
        Select_=new SqlCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT" & vbCrLf & _
          "WHERE ( RELATIONSHIP <> 'SS' ) " & vbCrLf & _
          "AND ( CARER_ID = (SELECT CARER_ID_PARENT_B from STUDENT WHERE STUDENT_ID = {STUDENT_ID} ))",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (SELECT * " & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT" & vbCrLf & _
          "WHERE ( RELATIONSHIP <> 'SS' ) " & vbCrLf & _
          "AND ( CARER_ID = (SELECT CARER_ID_PARENT_B from STUDENT WHERE STUDENT_ID = {STUDENT_ID} ))" & _
          ") cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid STUDENT_CARER_CONTACT1 Data Provider Class GetResultSet Method

'Grid STUDENT_CARER_CONTACT1 Data Provider Class GetResultSet Method @13-F66EA6DA
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STUDENT_CARER_CONTACT1Item()
'End Grid STUDENT_CARER_CONTACT1 Data Provider Class GetResultSet Method

'Before build Select @13-29E282D2
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

'Execute Select @13-D71C6FAD
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STUDENT_CARER_CONTACT1Item
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

'After execute Select @13-B169A5C1
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENT_CARER_CONTACT1Item(dr.Count-1) {}
'End After execute Select

'After execute Select @13-79D6687E
            Dim j As Integer
'End After execute Select

'ListBox RELATIONSHIP AfterExecuteSelect @236-FE0A4158
            Dim RELATIONSHIPItems As ItemCollection = New ItemCollection()
            
RELATIONSHIPItems.Add("PA","Parent")
RELATIONSHIPItems.Add("SP","Step-Parent")
RELATIONSHIPItems.Add("AP","Adoptive Parent")
RELATIONSHIPItems.Add("FP","Foster Parent")
RELATIONSHIPItems.Add("GP","Grand Parent")
RELATIONSHIPItems.Add("HF","Host Family")
RELATIONSHIPItems.Add("RE","Relative")
RELATIONSHIPItems.Add("FR","Friend")
RELATIONSHIPItems.Add("SE","Self")
RELATIONSHIPItems.Add("OT","Other")
'End ListBox RELATIONSHIP AfterExecuteSelect

'After execute Select tail @13-1176FF33
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_CARER_CONTACT1Item = New STUDENT_CARER_CONTACT1Item()
                item.CARER_ID.SetValue(dr(i)("CARER_ID"),"")
                item.TITLE.SetValue(dr(i)("TITLE"),"")
                item.HOME_PHONE.SetValue(dr(i)("HOME_PHONE"),"")
                item.WORK_PHONE.SetValue(dr(i)("WORK_PHONE"),"")
                item.MOBILE.SetValue(dr(i)("MOBILE"),"")
                item.EMAIL.SetValue(dr(i)("EMAIL"),"")
                item.EMAILHref = dr(i)("EMAIL")
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.link_AddParentHref = "Student_Carer_maintainext.aspx"
                item.Link1Href = "Student_Carer_maintainext.aspx"
                item.Link1HrefParameters.Add("CARER_ID",System.Web.HttpUtility.UrlEncode(dr(i)("CARER_ID").ToString()))
                item.RELATIONSHIP.SetValue(dr(i)("RELATIONSHIP"),"")
                item.RELATIONSHIPItems = CType(RELATIONSHIPItems.Clone(), ItemCollection)
                item.PORTAL_LAST_LOGIN_DATE.SetValue(dr(i)("PORTAL_LAST_LOGIN_DATE"),Select_.DateFormat)
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @13-A61BA892
End Class
'End Grid Data Provider tail

'Grid STUDENT_CARER_CONTACT2 Item Class @23-1EEBE3DD
Public Class STUDENT_CARER_CONTACT2Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public CARER_ID As FloatField
    Public TITLE As TextField
    Public WORK_PHONE As TextField
    Public MOBILE As TextField
    Public EMAIL As TextField
    Public EMAILHref As Object
    Public EMAILHrefParameters As LinkParameterCollection
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public link_AddParent As TextField
    Public link_AddParentHref As Object
    Public link_AddParentHrefParameters As LinkParameterCollection
    Public Link_EditSupervisor As TextField
    Public Link_EditSupervisorHref As Object
    Public Link_EditSupervisorHrefParameters As LinkParameterCollection
    Public LinkAddSupervisor2 As TextField
    Public LinkAddSupervisor2Href As Object
    Public LinkAddSupervisor2HrefParameters As LinkParameterCollection
    Public SUPERVISOR_POSITION_OTHER As TextField
    Public SUPERVISOR_POSITION As TextField
    Public PORTAL_LAST_LOGIN_DATE As DateField
    Public lblSupervisor As TextField
    Public Supervisortype As TextField
    Public Sub New()
    CARER_ID = New FloatField("", Nothing)
    TITLE = New TextField("", Nothing)
    WORK_PHONE = New TextField("", Nothing)
    MOBILE = New TextField("", Nothing)
    EMAIL = New TextField("",Nothing)
    EMAILHrefParameters = New LinkParameterCollection()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    link_AddParent = New TextField("",Nothing)
    link_AddParentHrefParameters = New LinkParameterCollection()
    Link_EditSupervisor = New TextField("",Nothing)
    Link_EditSupervisorHrefParameters = New LinkParameterCollection()
    LinkAddSupervisor2 = New TextField("",Nothing)
    LinkAddSupervisor2HrefParameters = New LinkParameterCollection()
    SUPERVISOR_POSITION_OTHER = New TextField("", Nothing)
    SUPERVISOR_POSITION = New TextField("", Nothing)
    PORTAL_LAST_LOGIN_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    lblSupervisor = New TextField("", "School Supervisor")
    Supervisortype = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "CARER_ID"
                    Return Me.CARER_ID
                Case "TITLE"
                    Return Me.TITLE
                Case "WORK_PHONE"
                    Return Me.WORK_PHONE
                Case "MOBILE"
                    Return Me.MOBILE
                Case "EMAIL"
                    Return Me.EMAIL
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "link_AddParent"
                    Return Me.link_AddParent
                Case "Link_EditSupervisor"
                    Return Me.Link_EditSupervisor
                Case "LinkAddSupervisor2"
                    Return Me.LinkAddSupervisor2
                Case "SUPERVISOR_POSITION_OTHER"
                    Return Me.SUPERVISOR_POSITION_OTHER
                Case "SUPERVISOR_POSITION"
                    Return Me.SUPERVISOR_POSITION
                Case "PORTAL_LAST_LOGIN_DATE"
                    Return Me.PORTAL_LAST_LOGIN_DATE
                Case "lblSupervisor"
                    Return Me.lblSupervisor
                Case "Supervisortype"
                    Return Me.Supervisortype
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "CARER_ID"
                    Me.CARER_ID = CType(Value,FloatField)
                Case "TITLE"
                    Me.TITLE = CType(Value,TextField)
                Case "WORK_PHONE"
                    Me.WORK_PHONE = CType(Value,TextField)
                Case "MOBILE"
                    Me.MOBILE = CType(Value,TextField)
                Case "EMAIL"
                    Me.EMAIL = CType(Value,TextField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "link_AddParent"
                    Me.link_AddParent = CType(Value,TextField)
                Case "Link_EditSupervisor"
                    Me.Link_EditSupervisor = CType(Value,TextField)
                Case "LinkAddSupervisor2"
                    Me.LinkAddSupervisor2 = CType(Value,TextField)
                Case "SUPERVISOR_POSITION_OTHER"
                    Me.SUPERVISOR_POSITION_OTHER = CType(Value,TextField)
                Case "SUPERVISOR_POSITION"
                    Me.SUPERVISOR_POSITION = CType(Value,TextField)
                Case "PORTAL_LAST_LOGIN_DATE"
                    Me.PORTAL_LAST_LOGIN_DATE = CType(Value,DateField)
                Case "lblSupervisor"
                    Me.lblSupervisor = CType(Value,TextField)
                Case "Supervisortype"
                    Me.Supervisortype = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STUDENT_CARER_CONTACT2 Item Class

'Grid STUDENT_CARER_CONTACT2 Data Provider Class Header @23-8D2B3362
Public Class STUDENT_CARER_CONTACT2DataProvider
Inherits GridDataProviderBase
'End Grid STUDENT_CARER_CONTACT2 Data Provider Class Header

'Grid STUDENT_CARER_CONTACT2 Data Provider Class Variables @23-B2C7BBBE

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 1
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As TextParameter
    Public UrlENROLMENT_YEAR  As TextParameter
'End Grid STUDENT_CARER_CONTACT2 Data Provider Class Variables

'Grid STUDENT_CARER_CONTACT2 Data Provider Class GetResultSet Method @23-3E3CBF39

    Public Sub New()
        Select_=new SqlCommand("SELECT * , dbo.CarerTypeLabel(Relationship) as Supervisortype" & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT" & vbCrLf & _
          "WHERE ( RELATIONSHIP in ('SS','XS','XA','XB' )) " & vbCrLf & _
          "AND ( CARER_ID = (SELECT CARER_ID_SCHOOL_SUPERVISOR from STUDENT_ENROLMENT WHERE STUDENT_I" & _
          "D = {STUDENT_ID} AND ENROLMENT_YEAR = {ENROLMENT_YEAR}))",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (SELECT * , dbo.CarerTypeLabel(Relationship) as Supervisortype" & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT" & vbCrLf & _
          "WHERE ( RELATIONSHIP in ('SS','XS','XA','XB' )) " & vbCrLf & _
          "AND ( CARER_ID = (SELECT CARER_ID_SCHOOL_SUPERVISOR from STUDENT_ENROLMENT WHERE STUDENT_I" & _
          "D = {STUDENT_ID} AND ENROLMENT_YEAR = {ENROLMENT_YEAR}))) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid STUDENT_CARER_CONTACT2 Data Provider Class GetResultSet Method

'Grid STUDENT_CARER_CONTACT2 Data Provider Class GetResultSet Method @23-C786BC47
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STUDENT_CARER_CONTACT2Item()
'End Grid STUDENT_CARER_CONTACT2 Data Provider Class GetResultSet Method

'Before build Select @23-A84CD653
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

'Execute Select @23-B95B0F30
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STUDENT_CARER_CONTACT2Item
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

'After execute Select @23-123F2368
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENT_CARER_CONTACT2Item(dr.Count-1) {}
'End After execute Select

'After execute Select @23-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @23-767E33E3
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_CARER_CONTACT2Item = New STUDENT_CARER_CONTACT2Item()
                item.CARER_ID.SetValue(dr(i)("CARER_ID"),"")
                item.TITLE.SetValue(dr(i)("TITLE"),"")
                item.WORK_PHONE.SetValue(dr(i)("WORK_PHONE"),"")
                item.MOBILE.SetValue(dr(i)("MOBILE"),"")
                item.EMAIL.SetValue(dr(i)("EMAIL"),"")
                item.EMAILHref = dr(i)("EMAIL")
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.link_AddParentHref = "Student_Carer_maintainext.aspx"
                item.Link_EditSupervisorHref = "Student_Carer_maintainext.aspx"
                item.Link_EditSupervisorHrefParameters.Add("CARER_ID",System.Web.HttpUtility.UrlEncode(dr(i)("CARER_ID").ToString()))
                item.LinkAddSupervisor2Href = "Student_Carer_maintainext.aspx"
                item.SUPERVISOR_POSITION_OTHER.SetValue(dr(i)("SUPERVISOR_POSITION_OTHER"),"")
                item.SUPERVISOR_POSITION.SetValue(dr(i)("SUPERVISOR_POSITION"),"")
                item.PORTAL_LAST_LOGIN_DATE.SetValue(dr(i)("PORTAL_LAST_LOGIN_DATE"),Select_.DateFormat)
                item.lblSupervisor.SetValue(dr(i)("Supervisortype"),"")
                item.Supervisortype.SetValue(dr(i)("Supervisortype"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @23-A61BA892
End Class
'End Grid Data Provider tail

'Record STUDENT_CARER_CONTACT3 Item Class @33-FE16CCB5
Public Class STUDENT_CARER_CONTACT3Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public TITLE As TextField
    Public TITLEItems As ItemCollection
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public RELATIONSHIP As TextField
    Public RELATIONSHIPItems As ItemCollection
    Public HOME_PHONE As TextField
    Public WORK_PHONE As TextField
    Public MOBILE As TextField
    Public EMAIL As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Hidden_STUDENT_ID As TextField
    Public Hidden_LAST_ALTERED_BY As TextField
    Public lblCARER_ID As TextField
    Public Hidden_CarerId As TextField
    Public Hidden_DuperCarer As IntegerField
    Public Sub New()
    TITLE = New TextField("", Nothing)
    TITLEItems = New ItemCollection()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    RELATIONSHIP = New TextField("", Nothing)
    RELATIONSHIPItems = New ItemCollection()
    HOME_PHONE = New TextField("", Nothing)
    WORK_PHONE = New TextField("", Nothing)
    MOBILE = New TextField("", Nothing)
    EMAIL = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    Hidden_STUDENT_ID = New TextField("", Nothing)
    Hidden_LAST_ALTERED_BY = New TextField("", DBUtility.UserLogin.ToUpper)
    lblCARER_ID = New TextField("", Nothing)
    Hidden_CarerId = New TextField("", Nothing)
    Hidden_DuperCarer = New IntegerField("", 0)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_CARER_CONTACT3Item
        Dim item As STUDENT_CARER_CONTACT3Item = New STUDENT_CARER_CONTACT3Item()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
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
        If Not IsNothing(DBUtility.GetInitialValue("RELATIONSHIP")) Then
        item.RELATIONSHIP.SetValue(DBUtility.GetInitialValue("RELATIONSHIP"))
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
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_STUDENT_ID")) Then
        item.Hidden_STUDENT_ID.SetValue(DBUtility.GetInitialValue("Hidden_STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_LAST_ALTERED_BY")) Then
        item.Hidden_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("Hidden_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblCARER_ID")) Then
        item.lblCARER_ID.SetValue(DBUtility.GetInitialValue("lblCARER_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_CarerId")) Then
        item.Hidden_CarerId.SetValue(DBUtility.GetInitialValue("Hidden_CarerId"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_DuperCarer")) Then
        item.Hidden_DuperCarer.SetValue(DBUtility.GetInitialValue("Hidden_DuperCarer"))
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
                Case "RELATIONSHIP"
                    Return RELATIONSHIP
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
                Case "Hidden_STUDENT_ID"
                    Return Hidden_STUDENT_ID
                Case "Hidden_LAST_ALTERED_BY"
                    Return Hidden_LAST_ALTERED_BY
                Case "lblCARER_ID"
                    Return lblCARER_ID
                Case "Hidden_CarerId"
                    Return Hidden_CarerId
                Case "Hidden_DuperCarer"
                    Return Hidden_DuperCarer
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
                Case "RELATIONSHIP"
                    RELATIONSHIP = CType(value, TextField)
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
                Case "Hidden_STUDENT_ID"
                    Hidden_STUDENT_ID = CType(value, TextField)
                Case "Hidden_LAST_ALTERED_BY"
                    Hidden_LAST_ALTERED_BY = CType(value, TextField)
                Case "lblCARER_ID"
                    lblCARER_ID = CType(value, TextField)
                Case "Hidden_CarerId"
                    Hidden_CarerId = CType(value, TextField)
                Case "Hidden_DuperCarer"
                    Hidden_DuperCarer = CType(value, IntegerField)
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

'SURNAME validate @41-977B5F4F
        If IsNothing(SURNAME.Value) OrElse SURNAME.Value.ToString() ="" Then
            errors.Add("SURNAME",String.Format(Resources.strings.CCS_RequiredField,"SURNAME / FAMILY"))
        End If
'End SURNAME validate

'FIRST_NAME validate @42-EF10D039
        If IsNothing(FIRST_NAME.Value) OrElse FIRST_NAME.Value.ToString() ="" Then
            errors.Add("FIRST_NAME",String.Format(Resources.strings.CCS_RequiredField,"FIRST NAME"))
        End If
'End FIRST_NAME validate

'RELATIONSHIP validate @43-14A3EB67
        If IsNothing(RELATIONSHIP.Value) OrElse RELATIONSHIP.Value.ToString() ="" Then
            errors.Add("RELATIONSHIP",String.Format(Resources.strings.CCS_RequiredField,"RELATIONSHIP"))
        End If
'End RELATIONSHIP validate

'TextBox EMAIL Event OnValidate. Action Regular Expression Validation @538-EEA5F657
        If Not (EMAIL.Value Is Nothing) Then
            Dim mask As Regex = New Regex("^[\w\.\+-]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]+$",RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            If Not(mask.Match(EMAIL.Value.ToString()).Success)
                errors.Add("EMAIL",String.Format("The Carer Email Address is not a valid Email Address eg: bob.student@example.com","EMAIL"))
            End If
        End If
'End TextBox EMAIL Event OnValidate. Action Regular Expression Validation

'Record STUDENT_CARER_CONTACT3 Event OnValidate. Action Declare Variable @293-1DBD40C7
        Dim tmpExistingCarer As Int64 = 0
'End Record STUDENT_CARER_CONTACT3 Event OnValidate. Action Declare Variable

'Record STUDENT_CARER_CONTACT3 Event OnValidate. Action Custom Code @169-73254650
    ' -------------------------
    'ERA: check that at least one of HOME, WORK, or MOBILE phone numbers are provided.
	If ((HOME_PHONE.Value Is Nothing) OrElse HOME_PHONE.Value.ToString()="")  AND ((WORK_PHONE.Value Is Nothing) OrElse WORK_PHONE.Value.ToString()="") AND ((MOBILE.Value Is Nothing) OrElse MOBILE.Value.ToString()="")  Then
            errors.Add("STUDENT_CARER_CONTACT3",String.Format("At least ONE of HOME PHONE, WORK PHONE, or MOBILE is required.","STUDENT_CARER_CONTACT3"))
	End If
	
	If Hidden_CarerId.Value <> "" Then 
	'25/10/2016|LN|Added conditional for existing CarerID not provided as it is a new Parent.
	'24-Nov-2016|EA| change validation to ignore older carer ID not attached to current students
	'9-Feb-2017|EA| apostrophe breaks it - change to robust checking
	Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
	Dim tmpSQLCheckCarer as String
	tmpSQLCheckCarer = "SELECT count(*) FROM STUDENT_CARER_CONTACT SCC, STUDENT ST, STUDENT_ENROLMENT SE " & _
						" WHERE scc.carer_id = st.carer_id_parent_a and se.student_id = st.student_id " & _
						" AND se.enrolment_status = 'E' and se.enrolment_year >= YEAR(GETDATE()) " & _
						" AND scc.SURNAME=" & NewDao.ToSql(SURNAME.Value,FieldType._Text) & _
						" AND scc.EMAIL = "& NewDao.ToSql(EMAIL.Value,FieldType._Text) & _
						" AND scc.CARER_ID != " & NewDao.ToSql(Hidden_CarerId.Value,FieldType._Integer) & ""

    ' -------------------------
'End Record STUDENT_CARER_CONTACT3 Event OnValidate. Action Custom Code

'DEL          'tmpExistingCarer = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & tmpSQLCheckCarer & " FROM " & "STUDENT_CARER_CONTACT" & " WHERE " & "SURNAME='" & SURNAME.Value & "' AND EMAIL = '"& EMAIL.Value &"' AND CARER_ID != " & Hidden_CarerId.Value &""))).Value, Int64)


'Record STUDENT_CARER_CONTACT3 Event OnValidate. Action Custom Code @295-73254650
		tmpExistingCarer = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar(tmpSQLCheckCarer))).Value, Int64)
    ' -------------------------
	End If	' end 25 Oct 2016
	
    '20-Feb-2014|EA| add check using above few lines to check if existing Carer (same Email and Surname) is in carer list
    ' 21-Aug-2018|EA| change error message to get search first
    if tmpExistingCarer > 0 then
    	errors.Add("STUDENT_CARER_CONTACT3",String.Format("Possible Duplicate Carer exists (same Surname and Email address). Use the 'Search First' to find existing Carer and Link to that one.","STUDENT_CARER_CONTACT3"))
    	'17-Nov-2016|EA| add if checked then allow
    end if
    ' -------------------------
'End Record STUDENT_CARER_CONTACT3 Event OnValidate. Action Custom Code

'Record STUDENT_CARER_CONTACT3 Item Class tail @33-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_CARER_CONTACT3 Item Class tail

'Record STUDENT_CARER_CONTACT3 Data Provider Class @33-3734F3F4
Public Class STUDENT_CARER_CONTACT3DataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_CARER_CONTACT3 Data Provider Class

'Record STUDENT_CARER_CONTACT3 Data Provider Class Variables @33-DA3A3035
    Public UrlRETURN_VALUE As IntegerParameter
    Public UrlCARER_ID As FloatParameter
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
    Public CtrlHidden_LAST_ALTERED_BY As TextParameter
    Public CtrlHidden_STUDENT_ID As TextParameter
    Public CtrlHidden_CarerId As TextParameter
    Protected item As STUDENT_CARER_CONTACT3Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_CARER_CONTACT3 Data Provider Class Variables

'Record STUDENT_CARER_CONTACT3 Data Provider Class Constructor @33-62C5B76F

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT {SQL_Where} {SQL_OrderBy}", New String(){"CARER_ID39"},Settings.connDECVPRODSQL2005DataAccessObject )
        Insert=new SpCommand("USP_Student_CARER_CONTACT_ADD_UPDATE;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Update=new SpCommand("USP_Student_CARER_CONTACT_ADD_UPDATE;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Delete=new SqlCommand("UPDATE STUDENT" & vbCrLf & _
          "SET CARER_ID_PARENT_B = NULL" & vbCrLf & _
          "WHERE STUDENT_ID = {student_id}" & vbCrLf & _
          "AND CARER_ID_PARENT_B = {carer_id}",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_CARER_CONTACT3 Data Provider Class Constructor

'Record STUDENT_CARER_CONTACT3 Data Provider Class LoadParams Method @33-206CC6BD

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlCARER_ID))
    End Function
'End Record STUDENT_CARER_CONTACT3 Data Provider Class LoadParams Method

'Record STUDENT_CARER_CONTACT3 Data Provider Class CheckUnique Method @33-EC92E8D7

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_CARER_CONTACT3Item) As Boolean
        Return True
    End Function
'End Record STUDENT_CARER_CONTACT3 Data Provider Class CheckUnique Method

'Record STUDENT_CARER_CONTACT3 Data Provider Class PrepareInsert Method @33-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STUDENT_CARER_CONTACT3 Data Provider Class PrepareInsert Method

'Record STUDENT_CARER_CONTACT3 Data Provider Class PrepareInsert Method tail @33-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT3 Data Provider Class PrepareInsert Method tail

'Record STUDENT_CARER_CONTACT3 Data Provider Class Insert Method @33-770A397E

    Public Function InsertItem(ByVal item As STUDENT_CARER_CONTACT3Item) As Integer
        Me.item = item
'End Record STUDENT_CARER_CONTACT3 Data Provider Class Insert Method

'Record STUDENT_CARER_CONTACT3 Build insert @33-4C3C6D73
        Insert.Parameters.Clear()
        CType(Insert,SpCommand).AddParameter("@RETURN_VALUE",UrlRETURN_VALUE,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Insert,SpCommand).AddParameter("@Contact_ID",UrlCARER_ID,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
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
        CType(Insert,SpCommand).AddParameter("@Last_Altered_By",item.Hidden_LAST_ALTERED_BY,ParameterType._VarChar,ParameterDirection.Input,8,0,18)
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
            result = ExecuteInsert()
            UrlRETURN_VALUE = IntegerParameter.GetParam(CType(Insert.Parameters("@RETURN_VALUE"),IDataParameter).Value)
        Catch ee As Exception
            E = ee
        Finally
'End Record STUDENT_CARER_CONTACT3 Build insert

'Record STUDENT_CARER_CONTACT3 AfterExecuteInsert @33-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_CARER_CONTACT3 AfterExecuteInsert

'Record STUDENT_CARER_CONTACT3 Data Provider Class PrepareUpdate Method @33-0A131024

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
'End Record STUDENT_CARER_CONTACT3 Data Provider Class PrepareUpdate Method

'Record STUDENT_CARER_CONTACT3 Data Provider Class PrepareUpdate Method tail @33-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT3 Data Provider Class PrepareUpdate Method tail

'Record STUDENT_CARER_CONTACT3 Data Provider Class Update Method @33-9815F5FA

    Public Function UpdateItem(ByVal item As STUDENT_CARER_CONTACT3Item) As Integer
        Me.item = item
'End Record STUDENT_CARER_CONTACT3 Data Provider Class Update Method

'Record STUDENT_CARER_CONTACT3 BeforeBuildUpdate @33-809FE986
        Update.Parameters.Clear()
        CType(Update,SpCommand).AddParameter("@RETURN_VALUE",UrlRETURN_VALUE,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Update,SpCommand).AddParameter("@Contact_ID",UrlCARER_ID,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
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
        CType(Update,SpCommand).AddParameter("@Last_Altered_By",item.Hidden_LAST_ALTERED_BY,ParameterType._VarChar,ParameterDirection.Input,8,0,18)
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
'End Record STUDENT_CARER_CONTACT3 BeforeBuildUpdate

'Record STUDENT_CARER_CONTACT3 AfterExecuteUpdate @33-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_CARER_CONTACT3 AfterExecuteUpdate

'Record STUDENT_CARER_CONTACT3 Data Provider Class PrepareDelete Method @33-3CDFF327

    Protected Overrides Sub PrepareDelete()
        CmdExecution = True
'End Record STUDENT_CARER_CONTACT3 Data Provider Class PrepareDelete Method

'Record STUDENT_CARER_CONTACT3 Data Provider Class PrepareDelete Method tail @33-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT3 Data Provider Class PrepareDelete Method tail

'Record STUDENT_CARER_CONTACT3 Data Provider Class Delete Method @33-9A127693
    Public Function DeleteItem(ByVal item As STUDENT_CARER_CONTACT3Item) As Integer
        Me.item = item
'End Record STUDENT_CARER_CONTACT3 Data Provider Class Delete Method

'Record STUDENT_CARER_CONTACT3 BeforeBuildDelete @33-F1C7D943
        Delete.Parameters.Clear()
        CType(Delete,SqlCommand).AddParameter("student_id",item.Hidden_STUDENT_ID, "")
        CType(Delete,SqlCommand).AddParameter("carer_id",item.Hidden_CarerId, "")
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
            result = ExecuteDelete()
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record STUDENT_CARER_CONTACT3 BeforeBuildDelete

'Record STUDENT_CARER_CONTACT3 BeforeBuildDelete @33-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_CARER_CONTACT3 BeforeBuildDelete

'Record STUDENT_CARER_CONTACT3 Data Provider Class GetResultSet Method @33-B422D9D8

    Public Sub FillItem(ByVal item As STUDENT_CARER_CONTACT3Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_CARER_CONTACT3 Data Provider Class GetResultSet Method

'Record STUDENT_CARER_CONTACT3 BeforeBuildSelect @33-931F5BAA
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("CARER_ID39",UrlCARER_ID, "","CARER_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_CARER_CONTACT3 BeforeBuildSelect

'Record STUDENT_CARER_CONTACT3 BeforeExecuteSelect @33-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_CARER_CONTACT3 BeforeExecuteSelect

'Record STUDENT_CARER_CONTACT3 AfterExecuteSelect @33-BF98C006
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.TITLE.SetValue(dr(i)("TITLE"),"")
            item.SURNAME.SetValue(dr(i)("SURNAME"),"")
            item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
            item.RELATIONSHIP.SetValue(dr(i)("RELATIONSHIP"),"")
            item.HOME_PHONE.SetValue(dr(i)("HOME_PHONE"),"")
            item.WORK_PHONE.SetValue(dr(i)("WORK_PHONE"),"")
            item.MOBILE.SetValue(dr(i)("MOBILE"),"")
            item.EMAIL.SetValue(dr(i)("EMAIL"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.Hidden_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.lblCARER_ID.SetValue(dr(i)("CARER_ID"),"")
            item.Hidden_CarerId.SetValue(dr(i)("CARER_ID"),"")
        Else
            IsInsertMode = True
        End If
'End Record STUDENT_CARER_CONTACT3 AfterExecuteSelect

'ListBox TITLE AfterExecuteSelect @40-8A33E418
        
item.TITLEItems.Add("MR","Mr")
item.TITLEItems.Add("MRS","Mrs")
item.TITLEItems.Add("Miss","Miss")
item.TITLEItems.Add("Ms","Ms")
item.TITLEItems.Add("Dr","Doctor")
'End ListBox TITLE AfterExecuteSelect

'ListBox RELATIONSHIP AfterExecuteSelect @43-D6CE2666
        
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

'Record STUDENT_CARER_CONTACT3 AfterExecuteSelect tail @33-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT3 AfterExecuteSelect tail

'Record STUDENT_CARER_CONTACT3 Data Provider Class @33-A61BA892
End Class

'End Record STUDENT_CARER_CONTACT3 Data Provider Class

'Record STUDENT_CARER_CONTACT4 Item Class @103-EEE9B0AF
Public Class STUDENT_CARER_CONTACT4Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public TITLE As TextField
    Public TITLEItems As ItemCollection
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public WORK_PHONE As TextField
    Public MOBILE As TextField
    Public EMAIL As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Hidden_LAST_ALTERED_BY As TextField
    Public Hidden_NewCarerID As IntegerField
    Public SUPERVISOR_POSITION As TextField
    Public SUPERVISOR_POSITIONItems As ItemCollection
    Public SUPERVISOR_POSITION_OTHER As TextField
    Public RELATIONSHIP As TextField
    Public RELATIONSHIPItems As ItemCollection
    Public Sub New()
    TITLE = New TextField("", Nothing)
    TITLEItems = New ItemCollection()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    WORK_PHONE = New TextField("", Nothing)
    MOBILE = New TextField("", Nothing)
    EMAIL = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    Hidden_LAST_ALTERED_BY = New TextField("", DBUtility.UserLogin.ToUpper)
    Hidden_NewCarerID = New IntegerField("", 0)
    SUPERVISOR_POSITION = New TextField("", Nothing)
    SUPERVISOR_POSITIONItems = New ItemCollection()
    SUPERVISOR_POSITION_OTHER = New TextField("", Nothing)
    RELATIONSHIP = New TextField("", "SS")
    RELATIONSHIPItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_CARER_CONTACT4Item
        Dim item As STUDENT_CARER_CONTACT4Item = New STUDENT_CARER_CONTACT4Item()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
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
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_LAST_ALTERED_BY")) Then
        item.Hidden_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("Hidden_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_NewCarerID")) Then
        item.Hidden_NewCarerID.SetValue(DBUtility.GetInitialValue("Hidden_NewCarerID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPERVISOR_POSITION")) Then
        item.SUPERVISOR_POSITION.SetValue(DBUtility.GetInitialValue("SUPERVISOR_POSITION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPERVISOR_POSITION_OTHER")) Then
        item.SUPERVISOR_POSITION_OTHER.SetValue(DBUtility.GetInitialValue("SUPERVISOR_POSITION_OTHER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RELATIONSHIP")) Then
        item.RELATIONSHIP.SetValue(DBUtility.GetInitialValue("RELATIONSHIP"))
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
                Case "Hidden_LAST_ALTERED_BY"
                    Return Hidden_LAST_ALTERED_BY
                Case "Hidden_NewCarerID"
                    Return Hidden_NewCarerID
                Case "SUPERVISOR_POSITION"
                    Return SUPERVISOR_POSITION
                Case "SUPERVISOR_POSITION_OTHER"
                    Return SUPERVISOR_POSITION_OTHER
                Case "RELATIONSHIP"
                    Return RELATIONSHIP
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
                Case "Hidden_LAST_ALTERED_BY"
                    Hidden_LAST_ALTERED_BY = CType(value, TextField)
                Case "Hidden_NewCarerID"
                    Hidden_NewCarerID = CType(value, IntegerField)
                Case "SUPERVISOR_POSITION"
                    SUPERVISOR_POSITION = CType(value, TextField)
                Case "SUPERVISOR_POSITION_OTHER"
                    SUPERVISOR_POSITION_OTHER = CType(value, TextField)
                Case "RELATIONSHIP"
                    RELATIONSHIP = CType(value, TextField)
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

'SURNAME validate @111-F35C1CC1
        If IsNothing(SURNAME.Value) OrElse SURNAME.Value.ToString() ="" Then
            errors.Add("SURNAME",String.Format(Resources.strings.CCS_RequiredField,"SURNAME"))
        End If
'End SURNAME validate

'FIRST_NAME validate @112-EF10D039
        If IsNothing(FIRST_NAME.Value) OrElse FIRST_NAME.Value.ToString() ="" Then
            errors.Add("FIRST_NAME",String.Format(Resources.strings.CCS_RequiredField,"FIRST NAME"))
        End If
'End FIRST_NAME validate

'TextBox WORK_PHONE Event OnValidate. Action Regular Expression Validation @134-FB93DB42
        If Not (WORK_PHONE.Value Is Nothing) Then
            Dim mask As Regex = New Regex("(^0[2|3|7|8]{1}[\s\-]{0,1}[0-9]{4}[\s\-]{0,1}[0-9]{4}$)|(^04\d{2,3}[\s\-]{0,1}\d{3}[\s\-]{" & _
"0,1}\d{3}$)",RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            If Not(mask.Match(WORK_PHONE.Value.ToString()).Success)
                errors.Add("WORK_PHONE",String.Format("WORK Phone Number must be an Australian number, including Area Code, with numbers, spaces," & _
  " or hyphens only. eg: 03 8480 5123 or 03-8480-5123 or 0412 345 678.","WORK PHONE"))
            End If
        End If
'End TextBox WORK_PHONE Event OnValidate. Action Regular Expression Validation

'TextBox MOBILE Event OnValidate. Action Regular Expression Validation @135-6EB9AE3A
        If Not (MOBILE.Value Is Nothing) Then
            Dim mask As Regex = New Regex("(^04\d{2,3}[\s\-]{0,1}\d{3}[\s\-]{0,1}\d{3}$)",RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            If Not(mask.Match(MOBILE.Value.ToString()).Success)
                errors.Add("MOBILE",String.Format("MOBILE Phone Number must be an Australian number, including Area Code, with numbers, space" & _
  "s, or hyphens only. eg: 03 8480 5123 or 03-8480-5123 or 0412 345 678.","MOBILE"))
            End If
        End If
'End TextBox MOBILE Event OnValidate. Action Regular Expression Validation

'TextBox EMAIL Event OnValidate. Action Regular Expression Validation @539-A9001789
        If Not (EMAIL.Value Is Nothing) Then
            Dim mask As Regex = New Regex("^[\w\.\+-]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]+$",RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            If Not(mask.Match(EMAIL.Value.ToString()).Success)
                errors.Add("EMAIL",String.Format("The Supervisor Email Address is not a valid Email Address eg: bob.supervisor@school.edu.au","EMAIL"))
            End If
        End If
'End TextBox EMAIL Event OnValidate. Action Regular Expression Validation

'RELATIONSHIP validate @118-BBBBA371
        If IsNothing(RELATIONSHIP.Value) OrElse RELATIONSHIP.Value.ToString() ="" Then
            errors.Add("RELATIONSHIP",String.Format(Resources.strings.CCS_RequiredField,"Supervisor Type"))
        End If
'End RELATIONSHIP validate

'Record STUDENT_CARER_CONTACT4 Item Class tail @103-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_CARER_CONTACT4 Item Class tail

'Record STUDENT_CARER_CONTACT4 Data Provider Class @103-393E3554
Public Class STUDENT_CARER_CONTACT4DataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_CARER_CONTACT4 Data Provider Class

'Record STUDENT_CARER_CONTACT4 Data Provider Class Variables @103-B93F0574
    Public ExprKey243 As TextParameter
    Public UrlRETURN_VALUE As IntegerParameter
    Public UrlCARER_ID As FloatParameter
    Public UrlStudent_ID As FloatParameter
    Public UrlENROLMENT_YEAR As FloatParameter
    Public CtrlTITLE As TextParameter
    Public CtrlSURNAME As TextParameter
    Public CtrlFIRST_NAME As TextParameter
    Public CtrlRELATIONSHIP As TextParameter
    Public ExprKey248 As TextParameter
    Public CtrlWORK_PHONE As TextParameter
    Public CtrlMOBILE As TextParameter
    Public CtrlEMAIL As TextParameter
    Public CtrlHidden_LAST_ALTERED_BY As TextParameter
    Public CtrlSUPERVISOR_POSITION As TextParameter
    Public CtrlSUPERVISOR_POSITION_OTHER As TextParameter
    Public CtrlHidden_NewCarerID As IntegerParameter
    Protected item As STUDENT_CARER_CONTACT4Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_CARER_CONTACT4 Data Provider Class Variables

'Record STUDENT_CARER_CONTACT4 Data Provider Class Constructor @103-C8C1748A

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT {SQL_Where} {SQL_OrderBy}", New String(){"CARER_ID379"},Settings.connDECVPRODSQL2005DataAccessObject )
        Insert=new SpCommand("USP_Student_CARER_CONTACT_ADD_UPDATE;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Update=new SpCommand("USP_Student_CARER_CONTACT_ADD_UPDATE;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_CARER_CONTACT4 Data Provider Class Constructor

'Record STUDENT_CARER_CONTACT4 Data Provider Class LoadParams Method @103-206CC6BD

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlCARER_ID))
    End Function
'End Record STUDENT_CARER_CONTACT4 Data Provider Class LoadParams Method

'Record STUDENT_CARER_CONTACT4 Data Provider Class CheckUnique Method @103-B022CBBE

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_CARER_CONTACT4Item) As Boolean
        Return True
    End Function
'End Record STUDENT_CARER_CONTACT4 Data Provider Class CheckUnique Method

'Record STUDENT_CARER_CONTACT4 Data Provider Class PrepareInsert Method @103-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STUDENT_CARER_CONTACT4 Data Provider Class PrepareInsert Method

'Record STUDENT_CARER_CONTACT4 Data Provider Class PrepareInsert Method tail @103-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT4 Data Provider Class PrepareInsert Method tail

'Record STUDENT_CARER_CONTACT4 Data Provider Class Insert Method @103-A5DF7FF8

    Public Function InsertItem(ByVal item As STUDENT_CARER_CONTACT4Item) As Integer
        Me.item = item
'End Record STUDENT_CARER_CONTACT4 Data Provider Class Insert Method

'Record STUDENT_CARER_CONTACT4 Build insert @103-7C358458
        Insert.Parameters.Clear()
        CType(Insert,SpCommand).AddParameter("@RETURN_VALUE",UrlRETURN_VALUE,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Insert,SpCommand).AddParameter("@Contact_ID",UrlCARER_ID,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Insert,SpCommand).AddParameter("@Student_ID",UrlStudent_ID,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Insert,SpCommand).AddParameter("@EnrolmentYear",UrlENROLMENT_YEAR,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Insert,SpCommand).AddParameter("@Title",item.TITLE,ParameterType._VarChar,ParameterDirection.Input,10,0,18)
        CType(Insert,SpCommand).AddParameter("@Surname",item.SURNAME,ParameterType._VarChar,ParameterDirection.Input,30,0,18)
        CType(Insert,SpCommand).AddParameter("@FirstName",item.FIRST_NAME,ParameterType._VarChar,ParameterDirection.Input,30,0,18)
        CType(Insert,SpCommand).AddParameter("@Relation",item.RELATIONSHIP,ParameterType._VarChar,ParameterDirection.Input,2,0,18)
        CType(Insert,SpCommand).AddParameter("@Home_Phone",ExprKey243,ParameterType._VarChar,ParameterDirection.Input,20,0,18)
        CType(Insert,SpCommand).AddParameter("@Work_Phone",item.WORK_PHONE,ParameterType._VarChar,ParameterDirection.Input,20,0,18)
        CType(Insert,SpCommand).AddParameter("@Mobile",item.MOBILE,ParameterType._VarChar,ParameterDirection.Input,20,0,18)
        CType(Insert,SpCommand).AddParameter("@Email",item.EMAIL,ParameterType._VarChar,ParameterDirection.Input,250,0,18)
        CType(Insert,SpCommand).AddParameter("@Last_Altered_By",item.Hidden_LAST_ALTERED_BY,ParameterType._VarChar,ParameterDirection.Input,8,0,18)
        CType(Insert,SpCommand).AddParameter("@SupervisorPosition",item.SUPERVISOR_POSITION,ParameterType._VarChar,ParameterDirection.Input,50,0,0)
        CType(Insert,SpCommand).AddParameter("@SupervisorPositionOther",item.SUPERVISOR_POSITION_OTHER,ParameterType._VarChar,ParameterDirection.Input,50,0,0)
        CType(Insert,SpCommand).AddParameter("@NewCarerID",item.Hidden_NewCarerID,ParameterType._Int,ParameterDirection.Input,0,0,0)
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
            result = ExecuteInsert()
            UrlRETURN_VALUE = IntegerParameter.GetParam(CType(Insert.Parameters("@RETURN_VALUE"),IDataParameter).Value)
        Catch ee As Exception
            E = ee
        Finally
'End Record STUDENT_CARER_CONTACT4 Build insert

'Record STUDENT_CARER_CONTACT4 AfterExecuteInsert @103-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_CARER_CONTACT4 AfterExecuteInsert

'Record STUDENT_CARER_CONTACT4 Data Provider Class PrepareUpdate Method @103-0A131024

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
'End Record STUDENT_CARER_CONTACT4 Data Provider Class PrepareUpdate Method

'Record STUDENT_CARER_CONTACT4 Data Provider Class PrepareUpdate Method tail @103-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT4 Data Provider Class PrepareUpdate Method tail

'Record STUDENT_CARER_CONTACT4 Data Provider Class Update Method @103-4AC0B37C

    Public Function UpdateItem(ByVal item As STUDENT_CARER_CONTACT4Item) As Integer
        Me.item = item
'End Record STUDENT_CARER_CONTACT4 Data Provider Class Update Method

'Record STUDENT_CARER_CONTACT4 BeforeBuildUpdate @103-8FE24518
        Update.Parameters.Clear()
        CType(Update,SpCommand).AddParameter("@RETURN_VALUE",UrlRETURN_VALUE,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Update,SpCommand).AddParameter("@Contact_ID",UrlCARER_ID,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Update,SpCommand).AddParameter("@Student_ID",UrlStudent_ID,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Update,SpCommand).AddParameter("@EnrolmentYear",UrlENROLMENT_YEAR,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Update,SpCommand).AddParameter("@Title",item.TITLE,ParameterType._VarChar,ParameterDirection.Input,10,0,18)
        CType(Update,SpCommand).AddParameter("@Surname",item.SURNAME,ParameterType._VarChar,ParameterDirection.Input,30,0,18)
        CType(Update,SpCommand).AddParameter("@FirstName",item.FIRST_NAME,ParameterType._VarChar,ParameterDirection.Input,30,0,18)
        CType(Update,SpCommand).AddParameter("@Relation",item.RELATIONSHIP,ParameterType._VarChar,ParameterDirection.Input,2,0,18)
        CType(Update,SpCommand).AddParameter("@Home_Phone",ExprKey248,ParameterType._VarChar,ParameterDirection.Input,20,0,18)
        CType(Update,SpCommand).AddParameter("@Work_Phone",item.WORK_PHONE,ParameterType._VarChar,ParameterDirection.Input,20,0,18)
        CType(Update,SpCommand).AddParameter("@Mobile",item.MOBILE,ParameterType._VarChar,ParameterDirection.Input,20,0,18)
        CType(Update,SpCommand).AddParameter("@Email",item.EMAIL,ParameterType._VarChar,ParameterDirection.Input,250,0,18)
        CType(Update,SpCommand).AddParameter("@Last_Altered_By",item.Hidden_LAST_ALTERED_BY,ParameterType._VarChar,ParameterDirection.Input,8,0,18)
        CType(Update,SpCommand).AddParameter("@SupervisorPosition",item.SUPERVISOR_POSITION,ParameterType._VarChar,ParameterDirection.Input,50,0,0)
        CType(Update,SpCommand).AddParameter("@SupervisorPositionOther",item.SUPERVISOR_POSITION_OTHER,ParameterType._VarChar,ParameterDirection.Input,50,0,0)
        CType(Update,SpCommand).AddParameter("@NewCarerID",item.Hidden_NewCarerID,ParameterType._Int,ParameterDirection.Input,0,0,0)
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
'End Record STUDENT_CARER_CONTACT4 BeforeBuildUpdate

'Record STUDENT_CARER_CONTACT4 AfterExecuteUpdate @103-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_CARER_CONTACT4 AfterExecuteUpdate

'Record STUDENT_CARER_CONTACT4 Data Provider Class GetResultSet Method @103-7ADC7C73

    Public Sub FillItem(ByVal item As STUDENT_CARER_CONTACT4Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_CARER_CONTACT4 Data Provider Class GetResultSet Method

'Record STUDENT_CARER_CONTACT4 BeforeBuildSelect @103-7743687D
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("CARER_ID379",UrlCARER_ID, "","CARER_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_CARER_CONTACT4 BeforeBuildSelect

'Record STUDENT_CARER_CONTACT4 BeforeExecuteSelect @103-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_CARER_CONTACT4 BeforeExecuteSelect

'Record STUDENT_CARER_CONTACT4 AfterExecuteSelect @103-B37E6FAF
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.TITLE.SetValue(dr(i)("TITLE"),"")
            item.SURNAME.SetValue(dr(i)("SURNAME"),"")
            item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
            item.WORK_PHONE.SetValue(dr(i)("WORK_PHONE"),"")
            item.MOBILE.SetValue(dr(i)("MOBILE"),"")
            item.EMAIL.SetValue(dr(i)("EMAIL"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.Hidden_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.SUPERVISOR_POSITION.SetValue(dr(i)("SUPERVISOR_POSITION"),"")
            item.SUPERVISOR_POSITION_OTHER.SetValue(dr(i)("SUPERVISOR_POSITION_OTHER"),"")
            item.RELATIONSHIP.SetValue(dr(i)("RELATIONSHIP"),"")
        Else
            IsInsertMode = True
        End If
'End Record STUDENT_CARER_CONTACT4 AfterExecuteSelect

'ListBox TITLE AfterExecuteSelect @110-8A33E418
        
item.TITLEItems.Add("MR","Mr")
item.TITLEItems.Add("MRS","Mrs")
item.TITLEItems.Add("Miss","Miss")
item.TITLEItems.Add("Ms","Ms")
item.TITLEItems.Add("Dr","Doctor")
'End ListBox TITLE AfterExecuteSelect

'ListBox SUPERVISOR_POSITION AfterExecuteSelect @376-A1753A29
        
item.SUPERVISOR_POSITIONItems.Add("Year Level Coordinator","Year Level Coordinator")
item.SUPERVISOR_POSITIONItems.Add("Sub School Leader","Sub School Leader")
item.SUPERVISOR_POSITIONItems.Add("Principal","Principal")
item.SUPERVISOR_POSITIONItems.Add("Assistant Principal","Assistant Principal")
item.SUPERVISOR_POSITIONItems.Add("Librarian","Librarian")
item.SUPERVISOR_POSITIONItems.Add("Teacher","Teacher")
item.SUPERVISOR_POSITIONItems.Add("Admin staff","Admin staff")
item.SUPERVISOR_POSITIONItems.Add("Other","Other - enter below")
'End ListBox SUPERVISOR_POSITION AfterExecuteSelect

'ListBox RELATIONSHIP AfterExecuteSelect @118-A1B9246E
        
item.RELATIONSHIPItems.Add("SS","School Supervisor")
item.RELATIONSHIPItems.Add("XS","Sports Supervisor")
item.RELATIONSHIPItems.Add("XA","Agency Supervisor")
'End ListBox RELATIONSHIP AfterExecuteSelect

'Record STUDENT_CARER_CONTACT4 AfterExecuteSelect tail @103-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT4 AfterExecuteSelect tail

'Record STUDENT_CARER_CONTACT4 Data Provider Class @103-A61BA892
End Class

'End Record STUDENT_CARER_CONTACT4 Data Provider Class

'Record ListSchoolSupervisors Item Class @196-4D1E7B26
Public Class ListSchoolSupervisorsItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public carer_id_SS As TextField
    Public carer_id_SSItems As ItemCollection
    Public Sub New()
    carer_id_SS = New TextField("", Nothing)
    carer_id_SSItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As ListSchoolSupervisorsItem
        Dim item As ListSchoolSupervisorsItem = New ListSchoolSupervisorsItem()
        If Not IsNothing(DBUtility.GetInitialValue("carer_id_SS")) Then
        item.carer_id_SS.SetValue(DBUtility.GetInitialValue("carer_id_SS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "carer_id_SS"
                    Return carer_id_SS
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "carer_id_SS"
                    carer_id_SS = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As ListSchoolSupervisorsDataProvider)
'End Record ListSchoolSupervisors Item Class

'Record ListSchoolSupervisors Event OnValidate. Action Validate Required Value @217-59EE1D0F
        If (carer_id_SS.Value Is Nothing) OrElse carer_id_SS.Value.ToString()="" Then
            errors.Add("carer_id_SS",String.Format("Please select a School Supervisor from the list below, then click [Use Selected Supervisor" & _
  "].","ListSchoolSupervisors"))
        End If
'End Record ListSchoolSupervisors Event OnValidate. Action Validate Required Value

'Record ListSchoolSupervisors Item Class tail @196-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record ListSchoolSupervisors Item Class tail

'Record ListSchoolSupervisors Data Provider Class @196-1742CEEB
Public Class ListSchoolSupervisorsDataProvider
Inherits RecordDataProviderBase
'End Record ListSchoolSupervisors Data Provider Class

'Record ListSchoolSupervisors Data Provider Class Variables @196-5F4E6789
    Protected carer_id_SSDataCommand As DataCommand=new SqlCommand("/*April-2018|EA| Altered to add HOME school check as well esp. for Shared enrolments  " & vbCrLf & _
          "Aug-2018 use span to layout better and add Portal login" & vbCrLf & _
          "Oct-2018 add organistion_school_id selection" & vbCrLf & _
          "Dec-2018 fix Organisations returning 0 and getting too many results */" & vbCrLf & _
          "SELECT CARER_ID, '<span class=""radioLabel""><span class=""wide"">'+ (isnull(TITLE,'') + '" & _
          " ' + FIRST_NAME + ' ' + SURNAME + '</span><span>' +isnull(SUPERVISOR_POSITION,'-')+'</span" & _
          "><span>Ph: ' +isnull(WORK_PHONE,'none') + '</span><span>Mob: ' +isnull(MOBILE,'none') + '<" & _
          "/span><span class=""wide"">Email: ' +isnull(EMAIL,'none')+'</span><span>Portal Login: '+is" & _
          "null(convert(varchar(11), PORTAL_LAST_LOGIN_DATE, 113),'never')+'</span></span>') as displ" & _
          "aytext" & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT WHERE ( RELATIONSHIP in ('SS','XA','XS','XB') ) and CARER_ID in" & _
          " (SELECT distinct CARER_ID_SCHOOL_SUPERVISOR FROM [viewMaintainSearchRequest_Schools] wher" & _
          "e CARER_ID_SCHOOL_SUPERVISOR is not null" & vbCrLf & _
          "and (ATTENDING_SCHOOL_ID = (select distinct top 1 ATTENDING_SCHOOL_ID from [viewMaintainSe" & _
          "archRequest_Schools] where ATTENDING_SCHOOL_ID <> '16261.00' and STUDENT_ID =  {STUDENT_ID" & _
          "})" & vbCrLf & _
          "or HOME_SCHOOL_ID = (select distinct top 1 HOME_SCHOOL_ID from [viewMaintainSearchRequest_" & _
          "Schools] where HOME_SCHOOL_ID <> '16261.00' and STUDENT_ID = {STUDENT_ID} )" & vbCrLf & _
          "or ORGANISATION_SCHOOL_ID = (select distinct top 1 ORGANISATION_SCHOOL_ID from [viewMainta" & _
          "inSearchRequest_Schools] where ORGANISATION_SCHOOL_ID is not null and ORGANISATION_SCHOOL_" & _
          "ID <> '0' and STUDENT_ID = {STUDENT_ID} )" & vbCrLf & _
          "))" & vbCrLf & _
          "union" & vbCrLf & _
          "SELECT 0, '<span class=""radioLabel""><span class=""fullwidth"">None - remove Supervisor f" & _
          "rom this Student</span></span>'" & vbCrLf & _
          "",Settings.connDECVPRODSQL2005DataAccessObject)
    Public UrlENROLMENT_YEAR As FloatParameter
    Public UrlSTUDENT_ID As TextParameter
    Protected item As ListSchoolSupervisorsItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record ListSchoolSupervisors Data Provider Class Variables

'Record ListSchoolSupervisors Data Provider Class Constructor @196-71E76AF0

    Public Sub New()
        Select_=new TableCommand("SELECT CARER_ID_SCHOOL_SUPERVISOR " & vbCrLf & _
          "FROM STUDENT_ENROLMENT {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID204","And","ENROLMENT_YEAR205"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record ListSchoolSupervisors Data Provider Class Constructor

'Record ListSchoolSupervisors Data Provider Class LoadParams Method @196-79390024

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID) Or IsNothing(UrlENROLMENT_YEAR))
    End Function
'End Record ListSchoolSupervisors Data Provider Class LoadParams Method

'Record ListSchoolSupervisors Data Provider Class CheckUnique Method @196-1D4347C1

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As ListSchoolSupervisorsItem) As Boolean
        Return True
    End Function
'End Record ListSchoolSupervisors Data Provider Class CheckUnique Method

'Record ListSchoolSupervisors Data Provider Class PrepareUpdate Method @196-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record ListSchoolSupervisors Data Provider Class PrepareUpdate Method

'Record ListSchoolSupervisors Data Provider Class PrepareUpdate Method tail @196-E31F8E2A
    End Sub
'End Record ListSchoolSupervisors Data Provider Class PrepareUpdate Method tail

'Record ListSchoolSupervisors Data Provider Class Update Method @196-2B5E9ABF

    Public Function UpdateItem(ByVal item As ListSchoolSupervisorsItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT_ENROLMENT SET {Values}", New String(){"STUDENT_ID204","And","ENROLMENT_YEAR205"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record ListSchoolSupervisors Data Provider Class Update Method

'Record ListSchoolSupervisors BeforeBuildUpdate @196-37E80711
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID204",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ENROLMENT_YEAR205",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        If Not item.carer_id_SS.IsEmpty Then
        allEmptyFlag = item.carer_id_SS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CARER_ID_SCHOOL_SUPERVISOR=" + Update.Dao.ToSql(item.carer_id_SS.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record ListSchoolSupervisors BeforeBuildUpdate

'Record ListSchoolSupervisors AfterExecuteUpdate @196-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record ListSchoolSupervisors AfterExecuteUpdate

'Record ListSchoolSupervisors Data Provider Class GetResultSet Method @196-C1A26AC1

    Public Sub FillItem(ByVal item As ListSchoolSupervisorsItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record ListSchoolSupervisors Data Provider Class GetResultSet Method

'Record ListSchoolSupervisors BeforeBuildSelect @196-5052E67B
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID204",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("ENROLMENT_YEAR205",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record ListSchoolSupervisors BeforeBuildSelect

'Record ListSchoolSupervisors BeforeExecuteSelect @196-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record ListSchoolSupervisors BeforeExecuteSelect

'Record ListSchoolSupervisors AfterExecuteSelect @196-B4F6493A
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.carer_id_SS.SetValue(dr(i)("CARER_ID_SCHOOL_SUPERVISOR"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record ListSchoolSupervisors AfterExecuteSelect

'ListBox carer_id_SS Initialize Data Source @197-3295A944
        carer_id_SSDataCommand.Dao._optimized = False
        Dim carer_id_SStableIndex As Integer = 0
        carer_id_SSDataCommand.OrderBy = ""
        carer_id_SSDataCommand.Parameters.Clear()
        CType(carer_id_SSDataCommand,SqlCommand).AddParameter("STUDENT_ID",UrlSTUDENT_ID, "")
'End ListBox carer_id_SS Initialize Data Source

'ListBox carer_id_SS BeforeExecuteSelect @197-1BB69B5D
        Try
            ListBoxSource=carer_id_SSDataCommand.Execute().Tables(carer_id_SStableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox carer_id_SS BeforeExecuteSelect

'ListBox carer_id_SS AfterExecuteSelect @197-D97F1EE2
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("CARER_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("displaytext")
            item.carer_id_SSItems.Add(Key, Val)
        Next
'End ListBox carer_id_SS AfterExecuteSelect

'Record ListSchoolSupervisors AfterExecuteSelect tail @196-E31F8E2A
    End Sub
'End Record ListSchoolSupervisors AfterExecuteSelect tail

'Record ListSchoolSupervisors Data Provider Class @196-A61BA892
End Class

'End Record ListSchoolSupervisors Data Provider Class

'Grid STUDENT_CARER_CONTACT5 Item Class @398-0F8AE2D6
Public Class STUDENT_CARER_CONTACT5Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Detail As TextField
    Public DetailHref As Object
    Public DetailHrefParameters As LinkParameterCollection
    Public CARER_ID As FloatField
    Public TITLE As TextField
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public HOME_PHONE As TextField
    Public MOBILE As TextField
    Public EMAIL As TextField
    Public PORTAL_LAST_LOGIN_DATE As DateField
    Public WORK_PHONE As TextField
    Public RELATIONSHIP As TextField
    Public Sub New()
    Detail = New TextField("",Nothing)
    DetailHrefParameters = New LinkParameterCollection()
    CARER_ID = New FloatField("", Nothing)
    TITLE = New TextField("", Nothing)
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    HOME_PHONE = New TextField("", Nothing)
    MOBILE = New TextField("", Nothing)
    EMAIL = New TextField("", Nothing)
    PORTAL_LAST_LOGIN_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    WORK_PHONE = New TextField("", Nothing)
    RELATIONSHIP = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "Detail"
                    Return Me.Detail
                Case "CARER_ID"
                    Return Me.CARER_ID
                Case "TITLE"
                    Return Me.TITLE
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "HOME_PHONE"
                    Return Me.HOME_PHONE
                Case "MOBILE"
                    Return Me.MOBILE
                Case "EMAIL"
                    Return Me.EMAIL
                Case "PORTAL_LAST_LOGIN_DATE"
                    Return Me.PORTAL_LAST_LOGIN_DATE
                Case "WORK_PHONE"
                    Return Me.WORK_PHONE
                Case "RELATIONSHIP"
                    Return Me.RELATIONSHIP
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Detail"
                    Me.Detail = CType(Value,TextField)
                Case "CARER_ID"
                    Me.CARER_ID = CType(Value,FloatField)
                Case "TITLE"
                    Me.TITLE = CType(Value,TextField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "HOME_PHONE"
                    Me.HOME_PHONE = CType(Value,TextField)
                Case "MOBILE"
                    Me.MOBILE = CType(Value,TextField)
                Case "EMAIL"
                    Me.EMAIL = CType(Value,TextField)
                Case "PORTAL_LAST_LOGIN_DATE"
                    Me.PORTAL_LAST_LOGIN_DATE = CType(Value,DateField)
                Case "WORK_PHONE"
                    Me.WORK_PHONE = CType(Value,TextField)
                Case "RELATIONSHIP"
                    Me.RELATIONSHIP = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STUDENT_CARER_CONTACT5 Item Class

'Grid STUDENT_CARER_CONTACT5 Data Provider Class Header @398-78DECAC6
Public Class STUDENT_CARER_CONTACT5DataProvider
Inherits GridDataProviderBase
'End Grid STUDENT_CARER_CONTACT5 Data Provider Class Header

'Grid STUDENT_CARER_CONTACT5 Data Provider Class Variables @398-8237EFC3

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_CARER_ID
        Sorter_TITLE
        Sorter_SURNAME
        Sorter_FIRST_NAME
        Sorter_HOME_PHONE
        Sorter_MOBILE
        Sorter_EMAIL
        Sorter_PORTAL_LAST_LOGIN_DATE
    End Enum

    Private SortFieldsNames As String() = New String() {"","CARER_ID","TITLE","SURNAME","FIRST_NAME","HOME_PHONE","MOBILE","EMAIL","PORTAL_LAST_LOGIN_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"","CARER_ID DESC","TITLE DESC","SURNAME DESC","FIRST_NAME DESC","HOME_PHONE DESC","MOBILE DESC","EMAIL DESC","PORTAL_LAST_LOGIN_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 10
    Public PageNumber As Integer = 1
    Public Urls_SURNAME  As TextParameter
    Public Urls_FIRST_NAME  As TextParameter
    Public Urls_EMAIL  As TextParameter
'End Grid STUDENT_CARER_CONTACT5 Data Provider Class Variables

'Grid STUDENT_CARER_CONTACT5 Data Provider Class GetResultSet Method @398-1AA66EB8

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} CARER_ID, TITLE, SURNAME, FIRST_NAME, " & vbCrLf & _
          "RELATIONSHIP, HOME_PHONE, WORK_PHONE, MOBILE, EMAIL, " & vbCrLf & _
          "PORTAL_LAST_LOGIN_DATE " & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT {SQL_Where} {SQL_OrderBy}", New String(){"s_SURNAME419","And","s_FIRST_NAME420","And","s_EMAIL421"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT", New String(){"s_SURNAME419","And","s_FIRST_NAME420","And","s_EMAIL421"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid STUDENT_CARER_CONTACT5 Data Provider Class GetResultSet Method

'Grid STUDENT_CARER_CONTACT5 Data Provider Class GetResultSet Method @398-022182C9
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STUDENT_CARER_CONTACT5Item()
'End Grid STUDENT_CARER_CONTACT5 Data Provider Class GetResultSet Method

'Before build Select @398-B9383B2D
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_SURNAME419",Urls_SURNAME, "","SURNAME",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_FIRST_NAME420",Urls_FIRST_NAME, "","FIRST_NAME",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_EMAIL421",Urls_EMAIL, "","EMAIL",Condition.Contains,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @398-40171181
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STUDENT_CARER_CONTACT5Item
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

'After execute Select @398-5801A823
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENT_CARER_CONTACT5Item(dr.Count-1) {}
'End After execute Select

'After execute Select @398-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @398-AF7FC605
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_CARER_CONTACT5Item = New STUDENT_CARER_CONTACT5Item()
                item.DetailHref = "Student_Carer_maintainext.aspx"
                item.DetailHrefParameters.Add("linkCarerID",System.Web.HttpUtility.UrlEncode(dr(i)("CARER_ID").ToString()))
                item.CARER_ID.SetValue(dr(i)("CARER_ID"),"")
                item.TITLE.SetValue(dr(i)("TITLE"),"")
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.HOME_PHONE.SetValue(dr(i)("HOME_PHONE"),"")
                item.MOBILE.SetValue(dr(i)("MOBILE"),"")
                item.EMAIL.SetValue(dr(i)("EMAIL"),"")
                item.PORTAL_LAST_LOGIN_DATE.SetValue(dr(i)("PORTAL_LAST_LOGIN_DATE"),Select_.DateFormat)
                item.WORK_PHONE.SetValue(dr(i)("WORK_PHONE"),"")
                item.RELATIONSHIP.SetValue(dr(i)("RELATIONSHIP"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @398-A61BA892
End Class
'End Grid Data Provider tail

'Record STUDENT_CARER_CONTACTSearch Item Class @434-BC34C5DA
Public Class STUDENT_CARER_CONTACTSearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public s_SURNAME As TextField
    Public s_FIRST_NAME As TextField
    Public s_EMAIL As TextField
    Public Sub New()
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    s_SURNAME = New TextField("", Nothing)
    s_FIRST_NAME = New TextField("", Nothing)
    s_EMAIL = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_CARER_CONTACTSearchItem
        Dim item As STUDENT_CARER_CONTACTSearchItem = New STUDENT_CARER_CONTACTSearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_SURNAME")) Then
        item.s_SURNAME.SetValue(DBUtility.GetInitialValue("s_SURNAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_FIRST_NAME")) Then
        item.s_FIRST_NAME.SetValue(DBUtility.GetInitialValue("s_FIRST_NAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_EMAIL")) Then
        item.s_EMAIL.SetValue(DBUtility.GetInitialValue("s_EMAIL"))
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
                Case "s_FIRST_NAME"
                    Return s_FIRST_NAME
                Case "s_EMAIL"
                    Return s_EMAIL
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
                Case "s_FIRST_NAME"
                    s_FIRST_NAME = CType(value, TextField)
                Case "s_EMAIL"
                    s_EMAIL = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STUDENT_CARER_CONTACTSearchDataProvider)
'End Record STUDENT_CARER_CONTACTSearch Item Class

'Record STUDENT_CARER_CONTACTSearch Item Class tail @434-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_CARER_CONTACTSearch Item Class tail

'Record STUDENT_CARER_CONTACTSearch Data Provider Class @434-4CDF641B
Public Class STUDENT_CARER_CONTACTSearchDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_CARER_CONTACTSearch Data Provider Class

'Record STUDENT_CARER_CONTACTSearch Data Provider Class Variables @434-E90D4DF7
    Protected item As STUDENT_CARER_CONTACTSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_CARER_CONTACTSearch Data Provider Class Variables

'Record STUDENT_CARER_CONTACTSearch Data Provider Class GetResultSet Method @434-DC863DF9

    Public Sub FillItem(ByVal item As STUDENT_CARER_CONTACTSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record STUDENT_CARER_CONTACTSearch Data Provider Class GetResultSet Method

'Record STUDENT_CARER_CONTACTSearch BeforeBuildSelect @434-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_CARER_CONTACTSearch BeforeBuildSelect

'Record STUDENT_CARER_CONTACTSearch AfterExecuteSelect @434-79426A21
        End If
            IsInsertMode = True
'End Record STUDENT_CARER_CONTACTSearch AfterExecuteSelect

'Record STUDENT_CARER_CONTACTSearch AfterExecuteSelect tail @434-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACTSearch AfterExecuteSelect tail

'Record STUDENT_CARER_CONTACTSearch Data Provider Class @434-A61BA892
End Class

'End Record STUDENT_CARER_CONTACTSearch Data Provider Class

'Record STUDENT_CARER_CONTACT6 Item Class @441-4E5DB2C9
Public Class STUDENT_CARER_CONTACT6Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public FIRST_NAME As TextField
    Public EMAIL As TextField
    Public SURNAME As TextField
    Public radioCarerType As TextField
    Public radioCarerTypeItems As ItemCollection
    Public Sub New()
    FIRST_NAME = New TextField("", Nothing)
    EMAIL = New TextField("", Nothing)
    SURNAME = New TextField("", Nothing)
    radioCarerType = New TextField("", "A")
    radioCarerTypeItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_CARER_CONTACT6Item
        Dim item As STUDENT_CARER_CONTACT6Item = New STUDENT_CARER_CONTACT6Item()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FIRST_NAME")) Then
        item.FIRST_NAME.SetValue(DBUtility.GetInitialValue("FIRST_NAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EMAIL")) Then
        item.EMAIL.SetValue(DBUtility.GetInitialValue("EMAIL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SURNAME")) Then
        item.SURNAME.SetValue(DBUtility.GetInitialValue("SURNAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_LinkParent")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("radioCarerType")) Then
        item.radioCarerType.SetValue(DBUtility.GetInitialValue("radioCarerType"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "FIRST_NAME"
                    Return FIRST_NAME
                Case "EMAIL"
                    Return EMAIL
                Case "SURNAME"
                    Return SURNAME
                Case "radioCarerType"
                    Return radioCarerType
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "FIRST_NAME"
                    FIRST_NAME = CType(value, TextField)
                Case "EMAIL"
                    EMAIL = CType(value, TextField)
                Case "SURNAME"
                    SURNAME = CType(value, TextField)
                Case "radioCarerType"
                    radioCarerType = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STUDENT_CARER_CONTACT6DataProvider)
'End Record STUDENT_CARER_CONTACT6 Item Class

'EMAIL validate @447-BCA17D88
        If IsNothing(EMAIL.Value) OrElse EMAIL.Value.ToString() ="" Then
            errors.Add("EMAIL",String.Format(Resources.strings.CCS_RequiredField,"EMAIL"))
        End If
'End EMAIL validate

'radioCarerType validate @563-0B9CE541
        If IsNothing(radioCarerType.Value) OrElse radioCarerType.Value.ToString() ="" Then
            errors.Add("radioCarerType",String.Format(Resources.strings.CCS_RequiredField,"Link to Carer"))
        End If
'End radioCarerType validate

'Record STUDENT_CARER_CONTACT6 Item Class tail @441-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_CARER_CONTACT6 Item Class tail

'Record STUDENT_CARER_CONTACT6 Data Provider Class @441-B719D8A2
Public Class STUDENT_CARER_CONTACT6DataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_CARER_CONTACT6 Data Provider Class

'Record STUDENT_CARER_CONTACT6 Data Provider Class Variables @441-F92D61A6
    Public UrlENROLMENT_YEAR As IntegerParameter
    Public CtrlEMAIL As TextParameter
    Public UrllinkCarerID As IntegerParameter
    Public UrlSTUDENT_ID As IntegerParameter
    Public CtrlradioCarerType As TextParameter
    Protected item As STUDENT_CARER_CONTACT6Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_CARER_CONTACT6 Data Provider Class Variables

'Record STUDENT_CARER_CONTACT6 Data Provider Class Constructor @441-2804AD77

    Public Sub New()
        Select_=new TableCommand("SELECT CARER_ID, SURNAME, FIRST_NAME, RELATIONSHIP, " & vbCrLf & _
          "EMAIL " & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT {SQL_Where} {SQL_OrderBy}", New String(){"linkCarerID526"},Settings.connDECVPRODSQL2005DataAccessObject )
        Delete=new SqlCommand("UPDATE STUDENT " & vbCrLf & _
          "SET CARER_ID_PARENT_{rCarerAB} = {CARER_ID}" & vbCrLf & _
          "WHERE STUDENT_ID = {STUDENT_ID}",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_CARER_CONTACT6 Data Provider Class Constructor

'Record STUDENT_CARER_CONTACT6 Data Provider Class LoadParams Method @441-78868444

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrllinkCarerID))
    End Function
'End Record STUDENT_CARER_CONTACT6 Data Provider Class LoadParams Method

'Record STUDENT_CARER_CONTACT6 Data Provider Class CheckUnique Method @441-41B264D5

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_CARER_CONTACT6Item) As Boolean
        Return True
    End Function
'End Record STUDENT_CARER_CONTACT6 Data Provider Class CheckUnique Method

'Record STUDENT_CARER_CONTACT6 Data Provider Class PrepareUpdate Method @441-A4162338

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = Not(IsNothing(UrllinkCarerID))
'End Record STUDENT_CARER_CONTACT6 Data Provider Class PrepareUpdate Method

'Record STUDENT_CARER_CONTACT6 Data Provider Class PrepareUpdate Method tail @441-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT6 Data Provider Class PrepareUpdate Method tail

'Record STUDENT_CARER_CONTACT6 Data Provider Class Update Method @441-342B41DE

    Public Function UpdateItem(ByVal item As STUDENT_CARER_CONTACT6Item) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT_CARER_CONTACT SET {Values}", New String(){"linkCarerID454"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_CARER_CONTACT6 Data Provider Class Update Method

'Record STUDENT_CARER_CONTACT6 BeforeBuildUpdate @441-48870B5A
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("linkCarerID454",UrllinkCarerID, "","CARER_ID",Condition.Equal,False)
        allEmptyFlag = item.EMAIL.IsEmpty And allEmptyFlag
        If Not item.EMAIL.IsEmpty Then
        If IsNothing(item.EMAIL.Value) Then
        valuesList = valuesList & "EMAIL=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "EMAIL=" & Update.Dao.ToSql(item.EMAIL.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STUDENT_CARER_CONTACT6 BeforeBuildUpdate

'Record STUDENT_CARER_CONTACT6 AfterExecuteUpdate @441-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_CARER_CONTACT6 AfterExecuteUpdate

'Record STUDENT_CARER_CONTACT6 Data Provider Class PrepareDelete Method @441-3CDFF327

    Protected Overrides Sub PrepareDelete()
        CmdExecution = True
'End Record STUDENT_CARER_CONTACT6 Data Provider Class PrepareDelete Method

'Record STUDENT_CARER_CONTACT6 Data Provider Class PrepareDelete Method tail @441-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT6 Data Provider Class PrepareDelete Method tail

'Record STUDENT_CARER_CONTACT6 Data Provider Class Delete Method @441-95DF0697
    Public Function DeleteItem(ByVal item As STUDENT_CARER_CONTACT6Item) As Integer
        Me.item = item
'End Record STUDENT_CARER_CONTACT6 Data Provider Class Delete Method

'Record STUDENT_CARER_CONTACT6 BeforeBuildDelete @441-98C32C8C
        Delete.Parameters.Clear()
        CType(Delete,SqlCommand).AddParameter("CARER_ID",UrllinkCarerID, "")
        CType(Delete,SqlCommand).AddParameter("STUDENT_ID",UrlSTUDENT_ID, "")
        CType(Delete,SqlCommand).AddParameter("rCarerAB",item.radioCarerType, "")
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
            result = ExecuteDelete()
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record STUDENT_CARER_CONTACT6 BeforeBuildDelete

'Record STUDENT_CARER_CONTACT6 BeforeBuildDelete @441-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_CARER_CONTACT6 BeforeBuildDelete

'Record STUDENT_CARER_CONTACT6 Data Provider Class GetResultSet Method @441-AFD8D0EF

    Public Sub FillItem(ByVal item As STUDENT_CARER_CONTACT6Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_CARER_CONTACT6 Data Provider Class GetResultSet Method

'Record STUDENT_CARER_CONTACT6 BeforeBuildSelect @441-F71598FD
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("linkCarerID526",UrllinkCarerID, "","CARER_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_CARER_CONTACT6 BeforeBuildSelect

'Record STUDENT_CARER_CONTACT6 BeforeExecuteSelect @441-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_CARER_CONTACT6 BeforeExecuteSelect

'Record STUDENT_CARER_CONTACT6 AfterExecuteSelect @441-BF3C0FAF
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
            item.EMAIL.SetValue(dr(i)("EMAIL"),"")
            item.SURNAME.SetValue(dr(i)("SURNAME"),"")
        Else
            IsInsertMode = True
        End If
'End Record STUDENT_CARER_CONTACT6 AfterExecuteSelect

'ListBox radioCarerType AfterExecuteSelect @563-4C734BF3
        
item.radioCarerTypeItems.Add("A","Primary / Carer A")
item.radioCarerTypeItems.Add("B","Carer B")
'End ListBox radioCarerType AfterExecuteSelect

'Record STUDENT_CARER_CONTACT6 AfterExecuteSelect tail @441-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT6 AfterExecuteSelect tail

'Record STUDENT_CARER_CONTACT6 Data Provider Class @441-A61BA892
End Class

'End Record STUDENT_CARER_CONTACT6 Data Provider Class

'Grid STUDENT_CARER_CONTACT7 Item Class @571-8EE064A0
Public Class STUDENT_CARER_CONTACT7Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public CARER_ID As FloatField
    Public SURNAME As TextField
    Public HOME_PHONE As TextField
    Public MOBILE As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public SUPERVISOR_POSITION_OTHER As TextField
    Public FIRST_NAME As TextField
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public Link2 As TextField
    Public Link2Href As Object
    Public Link2HrefParameters As LinkParameterCollection
    Public Sub New()
    CARER_ID = New FloatField("", Nothing)
    SURNAME = New TextField("", Nothing)
    HOME_PHONE = New TextField("", Nothing)
    MOBILE = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    SUPERVISOR_POSITION_OTHER = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    Link1 = New TextField("",Nothing)
    Link1HrefParameters = New LinkParameterCollection()
    Link2 = New TextField("",Nothing)
    Link2HrefParameters = New LinkParameterCollection()
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "CARER_ID"
                    Return Me.CARER_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "HOME_PHONE"
                    Return Me.HOME_PHONE
                Case "MOBILE"
                    Return Me.MOBILE
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "SUPERVISOR_POSITION_OTHER"
                    Return Me.SUPERVISOR_POSITION_OTHER
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "Link1"
                    Return Me.Link1
                Case "Link2"
                    Return Me.Link2
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "CARER_ID"
                    Me.CARER_ID = CType(Value,FloatField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "HOME_PHONE"
                    Me.HOME_PHONE = CType(Value,TextField)
                Case "MOBILE"
                    Me.MOBILE = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "SUPERVISOR_POSITION_OTHER"
                    Me.SUPERVISOR_POSITION_OTHER = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "Link1"
                    Me.Link1 = CType(Value,TextField)
                Case "Link2"
                    Me.Link2 = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STUDENT_CARER_CONTACT7 Item Class

'Grid STUDENT_CARER_CONTACT7 Data Provider Class Header @571-7380EDC5
Public Class STUDENT_CARER_CONTACT7DataProvider
Inherits GridDataProviderBase
'End Grid STUDENT_CARER_CONTACT7 Data Provider Class Header

'Grid STUDENT_CARER_CONTACT7 Data Provider Class Variables @571-5EC52E22

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 10
    Public PageNumber As Integer = 1
    Public UrlStudent_ID  As IntegerParameter
'End Grid STUDENT_CARER_CONTACT7 Data Provider Class Variables

'Grid STUDENT_CARER_CONTACT7 Data Provider Class GetResultSet Method @571-6CC85D1B

    Public Sub New()
        Select_=new SqlCommand(" SELECT top 1 ec.SUPERVISOR_POSITION_OTHER, ec.LAST_ALTERED_DATE, ec.LAST_ALTERED_BY, MOBI" & _
          "LE, HOME_PHONE, ec.FIRST_NAME, ec.SURNAME, CARER_ID " & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT ec" & vbCrLf & _
          "	join student s on s.CARER_ID_EMERGENCY_CONTACT_1 = ec.CARER_ID" & vbCrLf & _
          "where ec.relationship = 'EC'" & vbCrLf & _
          "	and s.STUDENT_ID = {Student_ID}",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM ( SELECT top 1 ec.SUPERVISOR_POSITION_OTHER, ec.LAST_ALTERED_DATE, ec" & _
          ".LAST_ALTERED_BY, MOBILE, HOME_PHONE, ec.FIRST_NAME, ec.SURNAME, CARER_ID " & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT ec" & vbCrLf & _
          "	join student s on s.CARER_ID_EMERGENCY_CONTACT_1 = ec.CARER_ID" & vbCrLf & _
          "where ec.relationship = 'EC'" & vbCrLf & _
          "	and s.STUDENT_ID = {Student_ID}) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid STUDENT_CARER_CONTACT7 Data Provider Class GetResultSet Method

'Grid STUDENT_CARER_CONTACT7 Data Provider Class GetResultSet Method @571-95BE93E0
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STUDENT_CARER_CONTACT7Item()
'End Grid STUDENT_CARER_CONTACT7 Data Provider Class GetResultSet Method

'Before build Select @571-DB6EBA68
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("Student_ID",UrlStudent_ID, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @571-0B92AE97
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STUDENT_CARER_CONTACT7Item
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

'After execute Select @571-2CB5AED2
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENT_CARER_CONTACT7Item(dr.Count-1) {}
'End After execute Select

'After execute Select @571-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @571-683D4BFC
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_CARER_CONTACT7Item = New STUDENT_CARER_CONTACT7Item()
                item.CARER_ID.SetValue(dr(i)("CARER_ID"),"")
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.HOME_PHONE.SetValue(dr(i)("HOME_PHONE"),"")
                item.MOBILE.SetValue(dr(i)("MOBILE"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.SUPERVISOR_POSITION_OTHER.SetValue(dr(i)("SUPERVISOR_POSITION_OTHER"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.Link1Href = ""
                item.Link2Href = ""
                item.Link2HrefParameters.Add("CARER_ID",System.Web.HttpUtility.UrlEncode(dr(i)("CARER_ID").ToString()))
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @571-A61BA892
End Class
'End Grid Data Provider tail

'Grid STUDENT_CARER_CONTACT8 Item Class @590-9DE69E23
Public Class STUDENT_CARER_CONTACT8Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public CARER_ID As FloatField
    Public SURNAME As TextField
    Public HOME_PHONE As TextField
    Public MOBILE As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public SUPERVISOR_POSITION_OTHER As TextField
    Public FIRST_NAME As TextField
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public Link2 As TextField
    Public Link2Href As Object
    Public Link2HrefParameters As LinkParameterCollection
    Public Sub New()
    CARER_ID = New FloatField("", Nothing)
    SURNAME = New TextField("", Nothing)
    HOME_PHONE = New TextField("", Nothing)
    MOBILE = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    SUPERVISOR_POSITION_OTHER = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    Link1 = New TextField("",Nothing)
    Link1HrefParameters = New LinkParameterCollection()
    Link2 = New TextField("",Nothing)
    Link2HrefParameters = New LinkParameterCollection()
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "CARER_ID"
                    Return Me.CARER_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "HOME_PHONE"
                    Return Me.HOME_PHONE
                Case "MOBILE"
                    Return Me.MOBILE
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "SUPERVISOR_POSITION_OTHER"
                    Return Me.SUPERVISOR_POSITION_OTHER
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "Link1"
                    Return Me.Link1
                Case "Link2"
                    Return Me.Link2
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "CARER_ID"
                    Me.CARER_ID = CType(Value,FloatField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "HOME_PHONE"
                    Me.HOME_PHONE = CType(Value,TextField)
                Case "MOBILE"
                    Me.MOBILE = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "SUPERVISOR_POSITION_OTHER"
                    Me.SUPERVISOR_POSITION_OTHER = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "Link1"
                    Me.Link1 = CType(Value,TextField)
                Case "Link2"
                    Me.Link2 = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STUDENT_CARER_CONTACT8 Item Class

'Grid STUDENT_CARER_CONTACT8 Data Provider Class Header @590-AB0D886D
Public Class STUDENT_CARER_CONTACT8DataProvider
Inherits GridDataProviderBase
'End Grid STUDENT_CARER_CONTACT8 Data Provider Class Header

'Grid STUDENT_CARER_CONTACT8 Data Provider Class Variables @590-1B29808B

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 10
    Public PageNumber As Integer = 1
    Public UrlStudent_ID  As TextParameter
'End Grid STUDENT_CARER_CONTACT8 Data Provider Class Variables

'Grid STUDENT_CARER_CONTACT8 Data Provider Class GetResultSet Method @590-1D7B5868

    Public Sub New()
        Select_=new SqlCommand(" SELECT top 1 ec.SUPERVISOR_POSITION_OTHER, ec.LAST_ALTERED_DATE, ec.LAST_ALTERED_BY, MOBI" & _
          "LE, HOME_PHONE, ec.FIRST_NAME, ec.SURNAME, CARER_ID " & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT ec" & vbCrLf & _
          "	join student s on s.CARER_ID_EMERGENCY_CONTACT_2 = ec.CARER_ID" & vbCrLf & _
          "where ec.relationship = 'EC'" & vbCrLf & _
          "	and s.STUDENT_ID = {Student_ID}",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM ( SELECT top 1 ec.SUPERVISOR_POSITION_OTHER, ec.LAST_ALTERED_DATE, ec" & _
          ".LAST_ALTERED_BY, MOBILE, HOME_PHONE, ec.FIRST_NAME, ec.SURNAME, CARER_ID " & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT ec" & vbCrLf & _
          "	join student s on s.CARER_ID_EMERGENCY_CONTACT_2 = ec.CARER_ID" & vbCrLf & _
          "where ec.relationship = 'EC'" & vbCrLf & _
          "	and s.STUDENT_ID = {Student_ID}) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid STUDENT_CARER_CONTACT8 Data Provider Class GetResultSet Method

'Grid STUDENT_CARER_CONTACT8 Data Provider Class GetResultSet Method @590-63F6E309
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STUDENT_CARER_CONTACT8Item()
'End Grid STUDENT_CARER_CONTACT8 Data Provider Class GetResultSet Method

'Before build Select @590-DB6EBA68
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("Student_ID",UrlStudent_ID, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @590-07B94A3F
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STUDENT_CARER_CONTACT8Item
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

'After execute Select @590-6F2A381C
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENT_CARER_CONTACT8Item(dr.Count-1) {}
'End After execute Select

'After execute Select @590-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @590-187DF2A9
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_CARER_CONTACT8Item = New STUDENT_CARER_CONTACT8Item()
                item.CARER_ID.SetValue(dr(i)("CARER_ID"),"")
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.HOME_PHONE.SetValue(dr(i)("HOME_PHONE"),"")
                item.MOBILE.SetValue(dr(i)("MOBILE"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.SUPERVISOR_POSITION_OTHER.SetValue(dr(i)("SUPERVISOR_POSITION_OTHER"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.Link1Href = ""
                item.Link1HrefParameters.Add("CARER_ID",System.Web.HttpUtility.UrlEncode(dr(i)("CARER_ID").ToString()))
                item.Link2Href = ""
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @590-A61BA892
End Class
'End Grid Data Provider tail

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Item Class @654-FD548807
Public Class STUDENT_CARER_CONTACT_EMERGENCY_EDITItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public FIRST_NAME As TextField
    Public SURNAME As TextField
    Public HOME_PHONE As TextField
    Public MOBILE As TextField
    Public SUPERVISOR_POSITION_OTHER As TextField
    Public Hidden_LAST_ALTERED_BY As TextField
    Public Sub New()
    FIRST_NAME = New TextField("", Nothing)
    SURNAME = New TextField("", Nothing)
    HOME_PHONE = New TextField("", Nothing)
    MOBILE = New TextField("", Nothing)
    SUPERVISOR_POSITION_OTHER = New TextField("", Nothing)
    Hidden_LAST_ALTERED_BY = New TextField("", DBUtility.UserLogin.ToUpper)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_CARER_CONTACT_EMERGENCY_EDITItem
        Dim item As STUDENT_CARER_CONTACT_EMERGENCY_EDITItem = New STUDENT_CARER_CONTACT_EMERGENCY_EDITItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
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
        If Not IsNothing(DBUtility.GetInitialValue("MOBILE")) Then
        item.MOBILE.SetValue(DBUtility.GetInitialValue("MOBILE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPERVISOR_POSITION_OTHER")) Then
        item.SUPERVISOR_POSITION_OTHER.SetValue(DBUtility.GetInitialValue("SUPERVISOR_POSITION_OTHER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_LAST_ALTERED_BY")) Then
        item.Hidden_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("Hidden_LAST_ALTERED_BY"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "FIRST_NAME"
                    Return FIRST_NAME
                Case "SURNAME"
                    Return SURNAME
                Case "HOME_PHONE"
                    Return HOME_PHONE
                Case "MOBILE"
                    Return MOBILE
                Case "SUPERVISOR_POSITION_OTHER"
                    Return SUPERVISOR_POSITION_OTHER
                Case "Hidden_LAST_ALTERED_BY"
                    Return Hidden_LAST_ALTERED_BY
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "FIRST_NAME"
                    FIRST_NAME = CType(value, TextField)
                Case "SURNAME"
                    SURNAME = CType(value, TextField)
                Case "HOME_PHONE"
                    HOME_PHONE = CType(value, TextField)
                Case "MOBILE"
                    MOBILE = CType(value, TextField)
                Case "SUPERVISOR_POSITION_OTHER"
                    SUPERVISOR_POSITION_OTHER = CType(value, TextField)
                Case "Hidden_LAST_ALTERED_BY"
                    Hidden_LAST_ALTERED_BY = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STUDENT_CARER_CONTACT_EMERGENCY_EDITDataProvider)
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Item Class

'FIRST_NAME validate @661-EF10D039
        If IsNothing(FIRST_NAME.Value) OrElse FIRST_NAME.Value.ToString() ="" Then
            errors.Add("FIRST_NAME",String.Format(Resources.strings.CCS_RequiredField,"FIRST NAME"))
        End If
'End FIRST_NAME validate

'SURNAME validate @662-F35C1CC1
        If IsNothing(SURNAME.Value) OrElse SURNAME.Value.ToString() ="" Then
            errors.Add("SURNAME",String.Format(Resources.strings.CCS_RequiredField,"SURNAME"))
        End If
'End SURNAME validate

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Item Class tail @654-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Item Class tail

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class @654-9C688415
Public Class STUDENT_CARER_CONTACT_EMERGENCY_EDITDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class Variables @654-1D6E0C99
    Public UrlContact_ID As FloatParameter
    Public ExprKey424 As TextParameter
    Public ExprKey427 As TextParameter
    Public ExprKey429 As TextParameter
    Public UrlMobile As TextParameter
    Public ExprKey431 As TextParameter
    Public ExprKey433 As TextParameter
    Public ExprKey435 As IntegerParameter
    Public UrlRETURN_VALUE As IntegerParameter
    Public UrlCARER_ID As FloatParameter
    Public UrlStudent_ID As FloatParameter
    Public UrlEnrolmentYear As FloatParameter
    Public ExprKey440 As TextParameter
    Public CtrlSURNAME As TextParameter
    Public CtrlFIRST_NAME As TextParameter
    Public ExprKey443 As TextParameter
    Public CtrlHOME_PHONE As TextParameter
    Public ExprKey445 As TextParameter
    Public CtrlMOBILE As TextParameter
    Public ExprKey447 As TextParameter
    Public CtrlHidden_LAST_ALTERED_BY As TextParameter
    Public ExprKey449 As TextParameter
    Public CtrlSUPERVISOR_POSITION_OTHER As TextParameter
    Public UrlNewCarerID As IntegerParameter
    Protected item As STUDENT_CARER_CONTACT_EMERGENCY_EDITItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class Variables

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class Constructor @654-8976E47B

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT {SQL_Where} {SQL_OrderBy}", New String(){"CARER_ID660"},Settings.connDECVPRODSQL2005DataAccessObject )
        Insert=new SpCommand("USP_Student_CARER_CONTACT_ADD_UPDATE;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Update=new SpCommand("USP_Student_CARER_CONTACT_ADD_UPDATE;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Delete=new TableCommand("DELETE FROM STUDENT_CARER_CONTACT", New String(){"CARER_ID660"},Settings.connDECVPRODSQL2005DataAccessObject , true)
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class Constructor

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class LoadParams Method @654-206CC6BD

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlCARER_ID))
    End Function
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class LoadParams Method

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class CheckUnique Method @654-EE7047BC

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_CARER_CONTACT_EMERGENCY_EDITItem) As Boolean
        Return True
    End Function
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class CheckUnique Method

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class PrepareInsert Method @654-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class PrepareInsert Method

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class PrepareInsert Method tail @654-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class PrepareInsert Method tail

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class Insert Method @654-15628DD7

    Public Function InsertItem(ByVal item As STUDENT_CARER_CONTACT_EMERGENCY_EDITItem) As Integer
        Me.item = item
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class Insert Method

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Build insert @654-B4104DB2
        Insert.Parameters.Clear()
        CType(Insert,SpCommand).AddParameter("@RETURN_VALUE",UrlRETURN_VALUE,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Insert,SpCommand).AddParameter("@Contact_ID",UrlContact_ID,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Insert,SpCommand).AddParameter("@Student_ID",UrlStudent_ID,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Insert,SpCommand).AddParameter("@EnrolmentYear",UrlEnrolmentYear,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Insert,SpCommand).AddParameter("@Title",ExprKey424,ParameterType._Char,ParameterDirection.Input,10,0,0)
        CType(Insert,SpCommand).AddParameter("@Surname",item.SURNAME,ParameterType._Char,ParameterDirection.Input,30,0,0)
        CType(Insert,SpCommand).AddParameter("@FirstName",item.FIRST_NAME,ParameterType._Char,ParameterDirection.Input,30,0,0)
        CType(Insert,SpCommand).AddParameter("@Relation",ExprKey427,ParameterType._Char,ParameterDirection.Input,2,0,0)
        CType(Insert,SpCommand).AddParameter("@Home_Phone",item.HOME_PHONE,ParameterType._Char,ParameterDirection.Input,20,0,0)
        CType(Insert,SpCommand).AddParameter("@Work_Phone",ExprKey429,ParameterType._Char,ParameterDirection.Input,20,0,0)
        CType(Insert,SpCommand).AddParameter("@Mobile",UrlMobile,ParameterType._Char,ParameterDirection.Input,20,0,0)
        CType(Insert,SpCommand).AddParameter("@Email",ExprKey431,ParameterType._Char,ParameterDirection.Input,250,0,0)
        CType(Insert,SpCommand).AddParameter("@Last_Altered_By",item.Hidden_LAST_ALTERED_BY,ParameterType._Char,ParameterDirection.Input,8,0,0)
        CType(Insert,SpCommand).AddParameter("@SupervisorPosition",ExprKey433,ParameterType._Char,ParameterDirection.Input,50,0,0)
        CType(Insert,SpCommand).AddParameter("@SupervisorPositionOther",item.SUPERVISOR_POSITION_OTHER,ParameterType._Char,ParameterDirection.Input,50,0,0)
        CType(Insert,SpCommand).AddParameter("@NewCarerID",ExprKey435,ParameterType._Int,ParameterDirection.Input,0,0,10)
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
            result = ExecuteInsert()
            UrlRETURN_VALUE = IntegerParameter.GetParam(CType(Insert.Parameters("@RETURN_VALUE"),IDataParameter).Value)
        Catch ee As Exception
            E = ee
        Finally
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Build insert

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT AfterExecuteInsert @654-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT AfterExecuteInsert

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class PrepareUpdate Method @654-0A131024

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class PrepareUpdate Method

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class PrepareUpdate Method tail @654-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class PrepareUpdate Method tail

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class Update Method @654-C2A1C585

    Public Function UpdateItem(ByVal item As STUDENT_CARER_CONTACT_EMERGENCY_EDITItem) As Integer
        Me.item = item
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class Update Method

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT BeforeBuildUpdate @654-0B1AD6BD
        Update.Parameters.Clear()
        CType(Update,SpCommand).AddParameter("@RETURN_VALUE",UrlRETURN_VALUE,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Update,SpCommand).AddParameter("@Contact_ID",UrlCARER_ID,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Update,SpCommand).AddParameter("@Student_ID",UrlStudent_ID,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Update,SpCommand).AddParameter("@EnrolmentYear",UrlEnrolmentYear,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Update,SpCommand).AddParameter("@Title",ExprKey440,ParameterType._Char,ParameterDirection.Input,10,0,0)
        CType(Update,SpCommand).AddParameter("@Surname",item.SURNAME,ParameterType._Char,ParameterDirection.Input,30,0,0)
        CType(Update,SpCommand).AddParameter("@FirstName",item.FIRST_NAME,ParameterType._Char,ParameterDirection.Input,30,0,0)
        CType(Update,SpCommand).AddParameter("@Relation",ExprKey443,ParameterType._Char,ParameterDirection.Input,2,0,0)
        CType(Update,SpCommand).AddParameter("@Home_Phone",item.HOME_PHONE,ParameterType._Char,ParameterDirection.Input,20,0,0)
        CType(Update,SpCommand).AddParameter("@Work_Phone",ExprKey445,ParameterType._Char,ParameterDirection.Input,20,0,0)
        CType(Update,SpCommand).AddParameter("@Mobile",item.MOBILE,ParameterType._Char,ParameterDirection.Input,20,0,0)
        CType(Update,SpCommand).AddParameter("@Email",ExprKey447,ParameterType._Char,ParameterDirection.Input,250,0,0)
        CType(Update,SpCommand).AddParameter("@Last_Altered_By",item.Hidden_LAST_ALTERED_BY,ParameterType._Char,ParameterDirection.Input,8,0,0)
        CType(Update,SpCommand).AddParameter("@SupervisorPosition",ExprKey449,ParameterType._Char,ParameterDirection.Input,50,0,0)
        CType(Update,SpCommand).AddParameter("@SupervisorPositionOther",item.SUPERVISOR_POSITION_OTHER,ParameterType._Char,ParameterDirection.Input,50,0,0)
        CType(Update,SpCommand).AddParameter("@NewCarerID",UrlNewCarerID,ParameterType._Int,ParameterDirection.Input,0,0,10)
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
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT BeforeBuildUpdate

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT AfterExecuteUpdate @654-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT AfterExecuteUpdate

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class PrepareDelete Method @654-F7361E57

    Protected Overrides Sub PrepareDelete()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class PrepareDelete Method

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class PrepareDelete Method tail @654-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class PrepareDelete Method tail

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class Delete Method @654-D17EAC7B
    Public Function DeleteItem(ByVal item As STUDENT_CARER_CONTACT_EMERGENCY_EDITItem) As Integer
        Me.item = item
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class Delete Method

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT BeforeBuildDelete @654-E16F985E
        Delete.Parameters.Clear()
        CType(Delete,TableCommand).AddParameter("CARER_ID660",UrlCARER_ID, "","CARER_ID",Condition.Equal,False)
        Delete.SqlQuery.Replace("{FIRST_NAME}",Delete.Dao.ToSql(item.FIRST_NAME.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{SURNAME}",Delete.Dao.ToSql(item.SURNAME.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{HOME_PHONE}",Delete.Dao.ToSql(item.HOME_PHONE.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{MOBILE}",Delete.Dao.ToSql(item.MOBILE.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{SUPERVISOR_POSITION_OTHER}",Delete.Dao.ToSql(item.SUPERVISOR_POSITION_OTHER.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{Hidden_LAST_ALTERED_BY}",Delete.Dao.ToSql(item.Hidden_LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text))
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
            result = ExecuteDelete()
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT BeforeBuildDelete

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT BeforeBuildDelete @654-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT BeforeBuildDelete

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class GetResultSet Method @654-C8534130

    Public Sub FillItem(ByVal item As STUDENT_CARER_CONTACT_EMERGENCY_EDITItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class GetResultSet Method

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT BeforeBuildSelect @654-A5E9DA9D
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("CARER_ID660",UrlCARER_ID, "","CARER_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT BeforeBuildSelect

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT BeforeExecuteSelect @654-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT BeforeExecuteSelect

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT AfterExecuteSelect @654-03391831
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
            item.SURNAME.SetValue(dr(i)("SURNAME"),"")
            item.HOME_PHONE.SetValue(dr(i)("HOME_PHONE"),"")
            item.MOBILE.SetValue(dr(i)("MOBILE"),"")
            item.SUPERVISOR_POSITION_OTHER.SetValue(dr(i)("SUPERVISOR_POSITION_OTHER"),"")
            item.Hidden_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
        Else
            IsInsertMode = True
        End If
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT AfterExecuteSelect

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT AfterExecuteSelect tail @654-E31F8E2A
    End Sub
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT AfterExecuteSelect tail

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class @654-A61BA892
End Class

'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

