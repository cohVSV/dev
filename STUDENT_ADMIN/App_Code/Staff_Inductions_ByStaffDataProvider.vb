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

Namespace DECV_PROD2007.Staff_Inductions_ByStaff 'Namespace @1-A4B3C417

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

'Grid STAFF_INDUCTIONS_COURSES1 Item Class @3-6234D271
Public Class STAFF_INDUCTIONS_COURSES1Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STAFF_INDUCTIONS_PROGRESS_STATUS As TextField
    Public DATE_COMPLETED As DateField
    Public staffname As TextField
    Public INDUCTION_TITLE As TextField
    Public linkNewInduction As TextField
    Public linkNewInductionHref As Object
    Public linkNewInductionHrefParameters As LinkParameterCollection
    Public linkNewInduction1 As TextField
    Public linkNewInduction1Href As Object
    Public linkNewInduction1HrefParameters As LinkParameterCollection
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public Sub New()
    STAFF_INDUCTIONS_PROGRESS_STATUS = New TextField("", Nothing)
    DATE_COMPLETED = New DateField("dd MMM yyyy", Nothing)
    staffname = New TextField("", Nothing)
    INDUCTION_TITLE = New TextField("", Nothing)
    linkNewInduction = New TextField("",Nothing)
    linkNewInductionHrefParameters = New LinkParameterCollection()
    linkNewInduction1 = New TextField("",Nothing)
    linkNewInduction1HrefParameters = New LinkParameterCollection()
    Link1 = New TextField("",Nothing)
    Link1HrefParameters = New LinkParameterCollection()
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STAFF_INDUCTIONS_PROGRESS_STATUS"
                    Return Me.STAFF_INDUCTIONS_PROGRESS_STATUS
                Case "DATE_COMPLETED"
                    Return Me.DATE_COMPLETED
                Case "staffname"
                    Return Me.staffname
                Case "INDUCTION_TITLE"
                    Return Me.INDUCTION_TITLE
                Case "linkNewInduction"
                    Return Me.linkNewInduction
                Case "linkNewInduction1"
                    Return Me.linkNewInduction1
                Case "Link1"
                    Return Me.Link1
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STAFF_INDUCTIONS_PROGRESS_STATUS"
                    Me.STAFF_INDUCTIONS_PROGRESS_STATUS = CType(Value,TextField)
                Case "DATE_COMPLETED"
                    Me.DATE_COMPLETED = CType(Value,DateField)
                Case "staffname"
                    Me.staffname = CType(Value,TextField)
                Case "INDUCTION_TITLE"
                    Me.INDUCTION_TITLE = CType(Value,TextField)
                Case "linkNewInduction"
                    Me.linkNewInduction = CType(Value,TextField)
                Case "linkNewInduction1"
                    Me.linkNewInduction1 = CType(Value,TextField)
                Case "Link1"
                    Me.Link1 = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STAFF_INDUCTIONS_COURSES1 Item Class

'Grid STAFF_INDUCTIONS_COURSES1 Data Provider Class Header @3-0C728173
Public Class STAFF_INDUCTIONS_COURSES1DataProvider
Inherits GridDataProviderBase
'End Grid STAFF_INDUCTIONS_COURSES1 Data Provider Class Header

'Grid STAFF_INDUCTIONS_COURSES1 Data Provider Class Variables @3-598D4FFA

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STAFF_INDUCTIONS_PROGRESS_STATUS
        Sorter_DATE_COMPLETED
        Sorter_staffname
        Sorter_INDUCTION_TITLE
    End Enum

    Private SortFieldsNames As String() = New String() {"DATE_COMPLETED desc","STAFF_INDUCTIONS_PROGRESS.STATUS","DATE_COMPLETED","staffname","INDUCTION_TITLE"}
    Private SortFieldsNamesDesc As String() = New string() {"DATE_COMPLETED desc","STAFF_INDUCTIONS_PROGRESS.STATUS DESC","DATE_COMPLETED DESC","staffname DESC","INDUCTION_TITLE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 30
    Public PageNumber As Integer = 1
    Public Urls_View_StaffList_Active_Inactive_staff_ID  As TextParameter
'End Grid STAFF_INDUCTIONS_COURSES1 Data Provider Class Variables

'Grid STAFF_INDUCTIONS_COURSES1 Data Provider Class GetResultSet Method @3-A5B70C26

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} staffname, " & vbCrLf & _
          "STAFF_INDUCTIONS_PROGRESS.STATUS AS STAFF_INDUCTIONS_PROGRESS_STATUS, DATE_COMPLETED, INDU" & _
          "CTION_TITLE, " & vbCrLf & _
          "View_StaffList_Active_Inactive.staff_ID AS View_StaffList_Active_Inactive_staff_ID," & vbCrLf & _
          "STAFF_INDUCTIONS_PROGRESS.id AS STAFF_INDUCTIONS_PROGRESS_id " & vbCrLf & _
          "FROM (STAFF_INDUCTIONS_PROGRESS INNER JOIN View_StaffList_Active_Inactive ON" & vbCrLf & _
          "STAFF_INDUCTIONS_PROGRESS.STAFF_ID = View_StaffList_Active_Inactive.staff_ID) INNER JOIN S" & _
          "TAFF_INDUCTIONS_COURSES ON" & vbCrLf & _
          "STAFF_INDUCTIONS_PROGRESS.induction_id = STAFF_INDUCTIONS_COURSES.id {SQL_Where} {SQL_Orde" & _
          "rBy}", New String(){"s_View_StaffList_Active_Inactive_staff_ID22"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM (STAFF_INDUCTIONS_PROGRESS INNER JOIN View_StaffList_Active_Inactive ON" & vbCrLf & _
          "STAFF_INDUCTIONS_PROGRESS.STAFF_ID = View_StaffList_Active_Inactive.staff_ID) INNER JOIN S" & _
          "TAFF_INDUCTIONS_COURSES ON" & vbCrLf & _
          "STAFF_INDUCTIONS_PROGRESS.induction_id = STAFF_INDUCTIONS_COURSES.id", New String(){"s_View_StaffList_Active_Inactive_staff_ID22"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid STAFF_INDUCTIONS_COURSES1 Data Provider Class GetResultSet Method

'Grid STAFF_INDUCTIONS_COURSES1 Data Provider Class GetResultSet Method @3-34C44CCE
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STAFF_INDUCTIONS_COURSES1Item()
'End Grid STAFF_INDUCTIONS_COURSES1 Data Provider Class GetResultSet Method

'Before build Select @3-D526945B
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_View_StaffList_Active_Inactive_staff_ID22",Urls_View_StaffList_Active_Inactive_staff_ID, "","View_StaffList_Active_Inactive.staff_ID",Condition.Equal,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @3-3F6787D5
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STAFF_INDUCTIONS_COURSES1Item
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

'After execute Select @3-75CE9DD7
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STAFF_INDUCTIONS_COURSES1Item(dr.Count-1) {}
'End After execute Select

'After execute Select @3-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @3-BB80F7D1
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STAFF_INDUCTIONS_COURSES1Item = New STAFF_INDUCTIONS_COURSES1Item()
                item.STAFF_INDUCTIONS_PROGRESS_STATUS.SetValue(dr(i)("STAFF_INDUCTIONS_PROGRESS_STATUS"),"")
                item.DATE_COMPLETED.SetValue(dr(i)("DATE_COMPLETED"),Select_.DateFormat)
                item.staffname.SetValue(dr(i)("staffname"),"")
                item.INDUCTION_TITLE.SetValue(dr(i)("INDUCTION_TITLE"),"")
                item.linkNewInductionHref = "Staff_Inductions_ByStaff_maint.aspx"
                item.linkNewInduction1Href = "Staff_Inductions_ByStaff_maint.aspx"
                item.Link1.SetValue(dr(i)("STAFF_INDUCTIONS_PROGRESS_id"),"")
                item.Link1Href = "Staff_Inductions_ByStaff_maint.aspx"
                item.Link1HrefParameters.Add("STAFF_INDUCTIONS_PROGRESS_id",System.Web.HttpUtility.UrlEncode(dr(i)("STAFF_INDUCTIONS_PROGRESS_id").ToString()))
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

'Record STAFF_INDUCTIONS_COURSES Item Class @16-88D8A512
Public Class STAFF_INDUCTIONS_COURSESItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public s_View_StaffList_Active_Inactive_staff_ID As TextField
    Public s_View_StaffList_Active_Inactive_staff_IDItems As ItemCollection
    Public label_TeacherID As TextField
    Public Sub New()
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    s_View_StaffList_Active_Inactive_staff_ID = New TextField("", DBUtility.UserLogin.ToUpper())
    s_View_StaffList_Active_Inactive_staff_IDItems = New ItemCollection()
    label_TeacherID = New TextField("", DBUtility.UserLogin.ToUpper())
    End Sub

    Public Shared Function CreateFromHttpRequest() As STAFF_INDUCTIONS_COURSESItem
        Dim item As STAFF_INDUCTIONS_COURSESItem = New STAFF_INDUCTIONS_COURSESItem()
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_View_StaffList_Active_Inactive_staff_ID")) Then
        item.s_View_StaffList_Active_Inactive_staff_ID.SetValue(DBUtility.GetInitialValue("s_View_StaffList_Active_Inactive_staff_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("label_TeacherID")) Then
        item.label_TeacherID.SetValue(DBUtility.GetInitialValue("label_TeacherID"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "ClearParameters"
                    Return ClearParameters
                Case "s_View_StaffList_Active_Inactive_staff_ID"
                    Return s_View_StaffList_Active_Inactive_staff_ID
                Case "label_TeacherID"
                    Return label_TeacherID
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ClearParameters"
                    ClearParameters = CType(value, TextField)
                Case "s_View_StaffList_Active_Inactive_staff_ID"
                    s_View_StaffList_Active_Inactive_staff_ID = CType(value, TextField)
                Case "label_TeacherID"
                    label_TeacherID = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STAFF_INDUCTIONS_COURSESDataProvider)
'End Record STAFF_INDUCTIONS_COURSES Item Class

'Record STAFF_INDUCTIONS_COURSES Item Class tail @16-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STAFF_INDUCTIONS_COURSES Item Class tail

'Record STAFF_INDUCTIONS_COURSES Data Provider Class @16-EBFDEFD8
Public Class STAFF_INDUCTIONS_COURSESDataProvider
Inherits RecordDataProviderBase
'End Record STAFF_INDUCTIONS_COURSES Data Provider Class

'Record STAFF_INDUCTIONS_COURSES Data Provider Class Variables @16-9A69810D
    Protected s_View_StaffList_Active_Inactive_staff_IDDataCommand As DataCommand=new TableCommand("SELECT rtrim(staff_ID) AS staff_ID, " & vbCrLf & _
          "staffname " & vbCrLf & _
          "FROM View_StaffList_Active_Inactive {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected item As STAFF_INDUCTIONS_COURSESItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STAFF_INDUCTIONS_COURSES Data Provider Class Variables

'Record STAFF_INDUCTIONS_COURSES Data Provider Class GetResultSet Method @16-BB437E15

    Public Sub FillItem(ByVal item As STAFF_INDUCTIONS_COURSESItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STAFF_INDUCTIONS_COURSES Data Provider Class GetResultSet Method

'Record STAFF_INDUCTIONS_COURSES BeforeBuildSelect @16-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STAFF_INDUCTIONS_COURSES BeforeBuildSelect

'Record STAFF_INDUCTIONS_COURSES AfterExecuteSelect @16-83591636
        End If
            IsInsertMode = True
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record STAFF_INDUCTIONS_COURSES AfterExecuteSelect

'ListBox s_View_StaffList_Active_Inactive_staff_ID Initialize Data Source @19-5993FCCD
        s_View_StaffList_Active_Inactive_staff_IDDataCommand.Dao._optimized = False
        Dim s_View_StaffList_Active_Inactive_staff_IDtableIndex As Integer = 0
        s_View_StaffList_Active_Inactive_staff_IDDataCommand.OrderBy = "status desc, staffname"
        s_View_StaffList_Active_Inactive_staff_IDDataCommand.Parameters.Clear()
'End ListBox s_View_StaffList_Active_Inactive_staff_ID Initialize Data Source

'ListBox s_View_StaffList_Active_Inactive_staff_ID BeforeExecuteSelect @19-79AB00F5
        Try
            ListBoxSource=s_View_StaffList_Active_Inactive_staff_IDDataCommand.Execute().Tables(s_View_StaffList_Active_Inactive_staff_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox s_View_StaffList_Active_Inactive_staff_ID BeforeExecuteSelect

'ListBox s_View_StaffList_Active_Inactive_staff_ID AfterExecuteSelect @19-C36BF217
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("staff_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("staffname")
            item.s_View_StaffList_Active_Inactive_staff_IDItems.Add(Key, Val)
        Next
'End ListBox s_View_StaffList_Active_Inactive_staff_ID AfterExecuteSelect

'Record STAFF_INDUCTIONS_COURSES AfterExecuteSelect tail @16-E31F8E2A
    End Sub
'End Record STAFF_INDUCTIONS_COURSES AfterExecuteSelect tail

'Record STAFF_INDUCTIONS_COURSES Data Provider Class @16-A61BA892
End Class

'End Record STAFF_INDUCTIONS_COURSES Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

