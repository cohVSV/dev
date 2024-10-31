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

Namespace DECV_PROD2007.Student_ClassList_Reports 'Namespace @1-73F3783D

'Page Data Class @1-44C25696
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public LinkExportToExcel As TextField
    Public LinkExportToExcelHref As Object
    Public LinkExportToExcelHrefParameters As LinkParameterCollection
    Public Link_ShowBulkComment As TextField
    Public Link_ShowBulkCommentHref As Object
    Public Link_ShowBulkCommentHrefParameters As LinkParameterCollection
    Public Sub New()
        LinkExportToExcel = New TextField("",Nothing)
        LinkExportToExcelHrefParameters = New LinkParameterCollection()
        Link_ShowBulkComment = New TextField("",Nothing)
        Link_ShowBulkCommentHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.LinkExportToExcel.SetValue(DBUtility.GetInitialValue("LinkExportToExcel"))
        item.Link_ShowBulkComment.SetValue(DBUtility.GetInitialValue("Link_ShowBulkComment"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "LinkExportToExcel"
                    Return LinkExportToExcel
                Case "Link_ShowBulkComment"
                    Return Link_ShowBulkComment
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "LinkExportToExcel"
                    LinkExportToExcel = CType(value, TextField)
                Case "Link_ShowBulkComment"
                    Link_ShowBulkComment = CType(value, TextField)
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

'Record CLASS_LIST_Panel Item Class @4-B8CF8DD3
Public Class CLASS_LIST_PanelItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public List_Subject_id As TextField
    Public List_Subject_idItems As ItemCollection
    Public List_SEMESTER As TextField
    Public List_SEMESTERItems As ItemCollection
    Public List_SUBJECT_ENROL_STATUS As TextField
    Public List_SUBJECT_ENROL_STATUSItems As ItemCollection
    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public Sub New()
    List_Subject_id = New TextField("", Nothing)
    List_Subject_idItems = New ItemCollection()
    List_SEMESTER = New TextField("", "[1,2,B]")
    List_SEMESTERItems = New ItemCollection()
    List_SUBJECT_ENROL_STATUS = New TextField("", "[C,D,E]")
    List_SUBJECT_ENROL_STATUSItems = New ItemCollection()
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As CLASS_LIST_PanelItem
        Dim item As CLASS_LIST_PanelItem = New CLASS_LIST_PanelItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("List_Subject_id")) Then
        item.List_Subject_id.SetValue(DBUtility.GetInitialValue("List_Subject_id"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("List_SEMESTER")) Then
        item.List_SEMESTER.SetValue(DBUtility.GetInitialValue("List_SEMESTER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("List_SUBJECT_ENROL_STATUS")) Then
        item.List_SUBJECT_ENROL_STATUS.SetValue(DBUtility.GetInitialValue("List_SUBJECT_ENROL_STATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "List_Subject_id"
                    Return List_Subject_id
                Case "List_SEMESTER"
                    Return List_SEMESTER
                Case "List_SUBJECT_ENROL_STATUS"
                    Return List_SUBJECT_ENROL_STATUS
                Case "ClearParameters"
                    Return ClearParameters
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "List_Subject_id"
                    List_Subject_id = CType(value, TextField)
                Case "List_SEMESTER"
                    List_SEMESTER = CType(value, TextField)
                Case "List_SUBJECT_ENROL_STATUS"
                    List_SUBJECT_ENROL_STATUS = CType(value, TextField)
                Case "ClearParameters"
                    ClearParameters = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As CLASS_LIST_PanelDataProvider)
'End Record CLASS_LIST_Panel Item Class

'List_Subject_id validate @62-A5821F82
        If IsNothing(List_Subject_id.Value) OrElse List_Subject_id.Value.ToString() ="" Then
            errors.Add("List_Subject_id",String.Format(Resources.strings.CCS_RequiredField,"SUBJECT"))
        End If
'End List_Subject_id validate

'List_SUBJECT_ENROL_STATUS validate @88-2F2DE119
        If IsNothing(List_SUBJECT_ENROL_STATUS.Value) OrElse List_SUBJECT_ENROL_STATUS.Value.ToString() ="" Then
            errors.Add("List_SUBJECT_ENROL_STATUS",String.Format(Resources.strings.CCS_RequiredField,"List_SUBJECT_ENROL_STATUS"))
        End If
'End List_SUBJECT_ENROL_STATUS validate

'Record CLASS_LIST_Panel Item Class tail @4-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record CLASS_LIST_Panel Item Class tail

'Record CLASS_LIST_Panel Data Provider Class @4-148E95F3
Public Class CLASS_LIST_PanelDataProvider
Inherits RecordDataProviderBase
'End Record CLASS_LIST_Panel Data Provider Class

'Record CLASS_LIST_Panel Data Provider Class Variables @4-4C00DD21
    Protected List_Subject_idDataCommand As DataCommand=new SqlCommand("SELECT distinct SUBJECT_TITLE, " & vbCrLf & _
          "SUBJECT.SUBJECT_ID AS SUBJECT_SUBJECT_ID, " & vbCrLf & _
          "SUBJECT_ABBREV, RTRIM(SUBJECT_TITLE) +' [' + SUBJECT_ABBREV + '] ' + ' (ID ' + CAST(SUBJEC" & _
          "T.SUBJECT_ID AS varchar(255)) + ')'  AS subject_displaylabel " & vbCrLf & _
          "FROM SUBJECT INNER JOIN STUDENT_SUBJECT ON" & vbCrLf & _
          "SUBJECT.SUBJECT_ID = STUDENT_SUBJECT.SUBJECT_ID" & vbCrLf & _
          "WHERE ( CAMPUS_CODE='D' )" & vbCrLf & _
          "AND ( status = 1 )" & vbCrLf & _
          "AND ( ENROLMENT_YEAR=year(getdate())  ) " & vbCrLf & _
          "AND ( STAFF_ID = '{STAFF_ID}')",Settings.connDECVPRODSQL2005DataAccessObject)
    Public Expr143 As TextParameter
    Protected item As CLASS_LIST_PanelItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record CLASS_LIST_Panel Data Provider Class Variables

'Record CLASS_LIST_Panel Data Provider Class GetResultSet Method @4-0D88DBEB

    Public Sub FillItem(ByVal item As CLASS_LIST_PanelItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record CLASS_LIST_Panel Data Provider Class GetResultSet Method

'Record CLASS_LIST_Panel BeforeBuildSelect @4-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record CLASS_LIST_Panel BeforeBuildSelect

'Record CLASS_LIST_Panel AfterExecuteSelect @4-83591636
        End If
            IsInsertMode = True
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record CLASS_LIST_Panel AfterExecuteSelect

'ListBox List_Subject_id Initialize Data Source @62-DBE0D29E
        List_Subject_idDataCommand.Dao._optimized = False
        Dim List_Subject_idtableIndex As Integer = 0
        List_Subject_idDataCommand.OrderBy = ""
        List_Subject_idDataCommand.Parameters.Clear()
        CType(List_Subject_idDataCommand,SqlCommand).AddParameter("STAFF_ID",Expr143, "")
'End ListBox List_Subject_id Initialize Data Source

'DEL      ' -------------------------
'DEL  		If (System.Web.HttpContext.Current.Request.QueryString("showall")="1") Then
'DEL  		' check for elevated
'DEL  			If (DBUtility.AuthorizeUser(New String(){"2","3","6","7","9"})) Then
'DEL  			' show all
'DEL  			else
'DEL  				CType(List_Subject_idDataCommand, SqlCommand).SqlQuery.Append(" AND STAFF_ID like '" & DBUtility.UserLogin.ToUpper & "%'")
'DEL  			end if
'DEL  		else
'DEL  			CType(List_Subject_idDataCommand, SqlCommand).SqlQuery.Append(" AND STAFF_ID like '" & DBUtility.UserLogin.ToUpper & "%'")
'DEL  		end if
'DEL  
'DEL  '    	If (DBUtility.AuthorizeUser(New String(){"2","3","6","7","9"})) Then
'DEL  '		else
'DEL  '			CType(List_Subject_idDataCommand, SqlCommand).SqlQuery.Append(" AND STAFF_ID like '" & DBUtility.UserLogin.ToUpper & "%'")
'DEL  '		end if
'DEL  
'DEL      ' -------------------------


'ListBox List_Subject_id BeforeExecuteSelect @62-BB071D13
        Try
            ListBoxSource=List_Subject_idDataCommand.Execute().Tables(List_Subject_idtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox List_Subject_id BeforeExecuteSelect

'ListBox List_Subject_id AfterExecuteSelect @62-59541883
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("SUBJECT_SUBJECT_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("subject_displaylabel")
            item.List_Subject_idItems.Add(Key, Val)
        Next
'End ListBox List_Subject_id AfterExecuteSelect

'ListBox List_SEMESTER AfterExecuteSelect @85-B4594B00
        
item.List_SEMESTERItems.Add("[1,2,B]","All Semesters")
item.List_SEMESTERItems.Add("[1,B]","1 AND B")
item.List_SEMESTERItems.Add("[2,B]","2 AND B")
item.List_SEMESTERItems.Add("[1]","1")
item.List_SEMESTERItems.Add("[2]","2")
item.List_SEMESTERItems.Add("[B]","B")
'End ListBox List_SEMESTER AfterExecuteSelect

'ListBox List_SUBJECT_ENROL_STATUS AfterExecuteSelect @88-D339B52D
        
item.List_SUBJECT_ENROL_STATUSItems.Add("[C,D,E]","CURRENT(C,D,E)")
item.List_SUBJECT_ENROL_STATUSItems.Add("[C,D,E,P]","CURRENT + PENDING (C,D,E,P)")
item.List_SUBJECT_ENROL_STATUSItems.Add("[C,D,E,F]","CURRENT + FINISHED (C,D,E,F)")
item.List_SUBJECT_ENROL_STATUSItems.Add("[F,W]","FINISHED + WITHDRAWN (F,W)")
item.List_SUBJECT_ENROL_STATUSItems.Add("[C,D,F,P]","NON-WITHDRAWN (C,D,F,P)")
item.List_SUBJECT_ENROL_STATUSItems.Add("[C,D,E,F,P,W]","All Status (C,D,E,F,P,W)")
'End ListBox List_SUBJECT_ENROL_STATUS AfterExecuteSelect

'Record CLASS_LIST_Panel AfterExecuteSelect tail @4-E31F8E2A
    End Sub
'End Record CLASS_LIST_Panel AfterExecuteSelect tail

'Record CLASS_LIST_Panel Data Provider Class @4-A61BA892
End Class

'End Record CLASS_LIST_Panel Data Provider Class

'Grid Students_Grid Item Class @25-1922565E
Public Class Students_GridItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public SCHOOL_NAME As TextField
    Public ATTENDING_SCHOOL_ID As TextField
    Public STAFF_ID As TextField
    Public SUBJECT_ABBREV As TextField
    Public SUBJECT_ID As IntegerField
    Public SUBJ_ENROL_STATUS As TextField
    Public SEMESTER As TextField
    Public STUDENT_ID As FloatField
    Public STUDENT_IDHref As Object
    Public STUDENT_IDHrefParameters As LinkParameterCollection
    Public ClippyLink1 As TextField
    Public ClippyLink1Href As Object
    Public ClippyLink1HrefParameters As LinkParameterCollection
    Public ENROLMENT_DATE As DateField
    Public Hidden_clipboardtext As TextField
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public label_ALERTS As TextField
    Public STUDENT_ClassList_TotalRecords As TextField
    Public lblCnt As IntegerField
    Public StandardLearningProgram As TextField
    Public CLASS_CODE As TextField
    Public Sub New()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    SCHOOL_NAME = New TextField("", Nothing)
    ATTENDING_SCHOOL_ID = New TextField("", Nothing)
    STAFF_ID = New TextField("", Nothing)
    SUBJECT_ABBREV = New TextField("", Nothing)
    SUBJECT_ID = New IntegerField("", Nothing)
    SUBJ_ENROL_STATUS = New TextField("", Nothing)
    SEMESTER = New TextField("", Nothing)
    STUDENT_ID = New FloatField("",Nothing)
    STUDENT_IDHrefParameters = New LinkParameterCollection()
    ClippyLink1 = New TextField("",Nothing)
    ClippyLink1HrefParameters = New LinkParameterCollection()
    ENROLMENT_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    Hidden_clipboardtext = New TextField("", Nothing)
    Link1 = New TextField("",Nothing)
    Link1HrefParameters = New LinkParameterCollection()
    label_ALERTS = New TextField("", "Bob")
    STUDENT_ClassList_TotalRecords = New TextField("", Nothing)
    lblCnt = New IntegerField("", Nothing)
    StandardLearningProgram = New TextField("", Nothing)
    CLASS_CODE = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "SCHOOL_NAME"
                    Return Me.SCHOOL_NAME
                Case "ATTENDING_SCHOOL_ID"
                    Return Me.ATTENDING_SCHOOL_ID
                Case "STAFF_ID"
                    Return Me.STAFF_ID
                Case "SUBJECT_ABBREV"
                    Return Me.SUBJECT_ABBREV
                Case "SUBJECT_ID"
                    Return Me.SUBJECT_ID
                Case "SUBJ_ENROL_STATUS"
                    Return Me.SUBJ_ENROL_STATUS
                Case "SEMESTER"
                    Return Me.SEMESTER
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "ClippyLink1"
                    Return Me.ClippyLink1
                Case "ENROLMENT_DATE"
                    Return Me.ENROLMENT_DATE
                Case "Hidden_clipboardtext"
                    Return Me.Hidden_clipboardtext
                Case "Link1"
                    Return Me.Link1
                Case "label_ALERTS"
                    Return Me.label_ALERTS
                Case "STUDENT_ClassList_TotalRecords"
                    Return Me.STUDENT_ClassList_TotalRecords
                Case "lblCnt"
                    Return Me.lblCnt
                Case "StandardLearningProgram"
                    Return Me.StandardLearningProgram
                Case "CLASS_CODE"
                    Return Me.CLASS_CODE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "SCHOOL_NAME"
                    Me.SCHOOL_NAME = CType(Value,TextField)
                Case "ATTENDING_SCHOOL_ID"
                    Me.ATTENDING_SCHOOL_ID = CType(Value,TextField)
                Case "STAFF_ID"
                    Me.STAFF_ID = CType(Value,TextField)
                Case "SUBJECT_ABBREV"
                    Me.SUBJECT_ABBREV = CType(Value,TextField)
                Case "SUBJECT_ID"
                    Me.SUBJECT_ID = CType(Value,IntegerField)
                Case "SUBJ_ENROL_STATUS"
                    Me.SUBJ_ENROL_STATUS = CType(Value,TextField)
                Case "SEMESTER"
                    Me.SEMESTER = CType(Value,TextField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "ClippyLink1"
                    Me.ClippyLink1 = CType(Value,TextField)
                Case "ENROLMENT_DATE"
                    Me.ENROLMENT_DATE = CType(Value,DateField)
                Case "Hidden_clipboardtext"
                    Me.Hidden_clipboardtext = CType(Value,TextField)
                Case "Link1"
                    Me.Link1 = CType(Value,TextField)
                Case "label_ALERTS"
                    Me.label_ALERTS = CType(Value,TextField)
                Case "STUDENT_ClassList_TotalRecords"
                    Me.STUDENT_ClassList_TotalRecords = CType(Value,TextField)
                Case "lblCnt"
                    Me.lblCnt = CType(Value,IntegerField)
                Case "StandardLearningProgram"
                    Me.StandardLearningProgram = CType(Value,TextField)
                Case "CLASS_CODE"
                    Me.CLASS_CODE = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid Students_Grid Item Class

'Grid Students_Grid Data Provider Class Header @25-48E2C817
Public Class Students_GridDataProvider
Inherits GridDataProviderBase
'End Grid Students_Grid Data Provider Class Header

'Grid Students_Grid Data Provider Class Variables @25-DDAC4B41

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_ID
        Sorter_SURNAME
        Sorter_FIRST_NAME
        Sorter_SCHOOL_NAME
        Sorter_ATTENDING_SCHOOL_ID
        Sorter_STAFF_ID
        Sorter_SUBJECT_ABBREV
        Sorter_SUBJECT_ID
        Sorter_SUBJ_ENROL_STATUS
        Sorter_SEMESTER
        Sorter_ENROLMENT_DATE
        Sorter_CLASS_CODE
    End Enum

    Private SortFieldsNames As String() = New String() {"","STUDENT_ID","SURNAME","FIRST_NAME","SCHOOL_NAME","SCHOOL_ID","STAFF_ID","SUBJECT_ABBREV","SUBJECT_ID","SUBJ_ENROL_STATUS","SEMESTER","ENROLMENT_DATE","CLASS_CODE"}
    Private SortFieldsNamesDesc As String() = New string() {"","STUDENT_ID DESC","SURNAME DESC","FIRST_NAME DESC","SCHOOL_NAME DESC","SCHOOL_ID DESC","STAFF_ID DESC","SUBJECT_ABBREV DESC","SUBJECT_ID DESC","SUBJ_ENROL_STATUS DESC","SEMESTER DESC","ENROLMENT_DATE DESC","CLASS_CODE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 100
    Public PageNumber As Integer = 1
    Public UrlList_Subject_id  As IntegerParameter
    Public UrlList_SEMESTER  As TextParameter
    Public UrlList_SUBJECT_ENROL_STATUS  As TextParameter
    Public Expr203  As TextParameter
'End Grid Students_Grid Data Provider Class Variables

'Grid Students_Grid Data Provider Class GetResultSet Method @25-0E31B4C2

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM view_Class_Contact_List_04022011 {SQL_Where} {SQL_OrderBy}", New String(){"expr199","And","List_Subject_id200","And","List_SEMESTER201","And","List_SUBJECT_ENROL_STATUS202","And","expr203"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM view_Class_Contact_List_04022011", New String(){"expr199","And","List_Subject_id200","And","List_SEMESTER201","And","List_SUBJECT_ENROL_STATUS202","And","expr203"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid Students_Grid Data Provider Class GetResultSet Method

'Grid Students_Grid Data Provider Class GetResultSet Method @25-B46BE413
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As Students_GridItem()
'End Grid Students_Grid Data Provider Class GetResultSet Method

'DEL      ' -------------------------
'DEL  	' ERA: set the Staff ID depending on security level
'DEL  	' 7-Feb-2011|EA| fix to change STAFF_ID to all, if right level, AND to include in SQL so conflict between WHERE and ORDER BY works
'DEL  		dim thisstaffid as string = ""
'DEL  	If (showallflag="1") Then
'DEL  
'DEL  		' check for elevated
'DEL  		If (DBUtility.AuthorizeUser(New String(){"2","3","6","7","9"})) Then
'DEL  			' show all
'DEL  			thisstaffid = ""
'DEL  		else
'DEL  			thisstaffid = DBUtility.UserLogin.ToUpper
'DEL  		end if
'DEL  	else
'DEL  		thisstaffid = DBUtility.UserLogin.ToUpper
'DEL  	end if
'DEL      ' -------------------------


'Before build Select @25-570F22A1
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("List_Subject_id200",UrlList_Subject_id, "","SUBJECT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("List_SEMESTER201",UrlList_SEMESTER, "","SEMESTER",Condition.BeginsWith,False)
        CType(Select_,TableCommand).AddParameter("List_SUBJECT_ENROL_STATUS202",UrlList_SUBJECT_ENROL_STATUS, "","SUBJ_ENROL_STATUS",Condition.BeginsWith,False)
        CType(Select_,TableCommand).AddParameter("expr203",Expr203, "","STAFF_ID",Condition.BeginsWith,False)
        Select_.Parameters.Add("expr199","(ENROLMENT_YEAR =year(getdate()))")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'DEL  
'DEL        ' -------------------------
'DEL     	' ERA: set the Staff ID depending on security level
'DEL  	' 2-Feb-2011|EA| and look for querystring showall=1
'DEL  
'DEL  	If (showallflag="1") Then
'DEL  		' check for elevated
'DEL  		If (DBUtility.AuthorizeUser(New String(){"2","3","6","7","9"})) Then
'DEL  			' show all
'DEL  		else
'DEL  			Select_.SqlQuery.Append(" AND STAFF_ID like '" & DBUtility.UserLogin.ToUpper & "%'")
'DEL  		end if
'DEL  	else
'DEL  		Select_.SqlQuery.Append(" AND STAFF_ID like '" & DBUtility.UserLogin.ToUpper & "%'")
'DEL  	end if
'DEL  
'DEL        ' -------------------------


'Execute Select @25-48CB26AA
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As Students_GridItem
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

'After execute Select @25-44B1AFE6
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New Students_GridItem(dr.Count-1) {}
'End After execute Select

'After execute Select @25-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @25-9F3660D0
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as Students_GridItem = New Students_GridItem()
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.SCHOOL_NAME.SetValue(dr(i)("SCHOOL_NAME"),"")
                item.ATTENDING_SCHOOL_ID.SetValue(dr(i)("SCHOOL_ID"),"")
                item.STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
                item.SUBJECT_ABBREV.SetValue(dr(i)("SUBJECT_ABBREV"),"")
                item.SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
                item.SUBJ_ENROL_STATUS.SetValue(dr(i)("SUBJ_ENROL_STATUS"),"")
                item.SEMESTER.SetValue(dr(i)("SEMESTER"),"")
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.STUDENT_IDHref = "StudentSummary.aspx"
                item.STUDENT_IDHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
                item.STUDENT_IDHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
                item.ClippyLink1Href = ""
                item.ENROLMENT_DATE.SetValue(dr(i)("ENROLMENT_DATE"),Select_.DateFormat)
                item.Link1Href = "Student_Comments_maintain.aspx"
                item.Link1HrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
                item.Link1HrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("ENROLMENT_YEAR").ToString()))
                item.StandardLearningProgram.SetValue(dr(i)("MODULE_CUSTOMPROGRAM_display"),"")
                item.CLASS_CODE.SetValue(dr(i)("CLASS_CODE"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @25-A61BA892
End Class
'End Grid Data Provider tail

'Record STUDENT_COMMENT Item Class @13-5421053C
Public Class STUDENT_COMMENTItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public COMMENT As TextField
    Public hidden_SUBJECT_ID As IntegerField
    Public hidden_ENROLSTATUS As TextField
    Public lbSpecialCommentType1 As TextField
    Public lbSpecialCommentType1Items As ItemCollection
    Public Hidden_SEMESTER As TextField
    Public Sub New()
    COMMENT = New TextField("", Nothing)
    hidden_SUBJECT_ID = New IntegerField("", Nothing)
    hidden_ENROLSTATUS = New TextField("", "[C,D,E]")
    lbSpecialCommentType1 = New TextField("", Nothing)
    lbSpecialCommentType1Items = New ItemCollection()
    Hidden_SEMESTER = New TextField("", "[1,2,B]")
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_COMMENTItem
        Dim item As STUDENT_COMMENTItem = New STUDENT_COMMENTItem()
        If Not IsNothing(DBUtility.GetInitialValue("COMMENT")) Then
        item.COMMENT.SetValue(DBUtility.GetInitialValue("COMMENT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_SUBJECT_ID")) Then
        item.hidden_SUBJECT_ID.SetValue(DBUtility.GetInitialValue("hidden_SUBJECT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_ENROLSTATUS")) Then
        item.hidden_ENROLSTATUS.SetValue(DBUtility.GetInitialValue("hidden_ENROLSTATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbSpecialCommentType1")) Then
        item.lbSpecialCommentType1.SetValue(DBUtility.GetInitialValue("lbSpecialCommentType1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_SEMESTER")) Then
        item.Hidden_SEMESTER.SetValue(DBUtility.GetInitialValue("Hidden_SEMESTER"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "COMMENT"
                    Return COMMENT
                Case "hidden_SUBJECT_ID"
                    Return hidden_SUBJECT_ID
                Case "hidden_ENROLSTATUS"
                    Return hidden_ENROLSTATUS
                Case "lbSpecialCommentType1"
                    Return lbSpecialCommentType1
                Case "Hidden_SEMESTER"
                    Return Hidden_SEMESTER
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "COMMENT"
                    COMMENT = CType(value, TextField)
                Case "hidden_SUBJECT_ID"
                    hidden_SUBJECT_ID = CType(value, IntegerField)
                Case "hidden_ENROLSTATUS"
                    hidden_ENROLSTATUS = CType(value, TextField)
                Case "lbSpecialCommentType1"
                    lbSpecialCommentType1 = CType(value, TextField)
                Case "Hidden_SEMESTER"
                    Hidden_SEMESTER = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STUDENT_COMMENTDataProvider)
'End Record STUDENT_COMMENT Item Class

'COMMENT validate @18-AF76D6FB
        If IsNothing(COMMENT.Value) OrElse COMMENT.Value.ToString() ="" Then
            errors.Add("COMMENT",String.Format(Resources.strings.CCS_RequiredField,"COMMENT"))
        End If
'End COMMENT validate

'lbSpecialCommentType1 validate @68-54AE4A18
        If IsNothing(lbSpecialCommentType1.Value) OrElse lbSpecialCommentType1.Value.ToString() ="" Then
            errors.Add("lbSpecialCommentType1",String.Format(Resources.strings.CCS_RequiredField,"Contact Type"))
        End If
'End lbSpecialCommentType1 validate

'Record STUDENT_COMMENT Event OnValidate. Action Validate Required Value @176-CB103C98
        If (hidden_SUBJECT_ID.Value Is Nothing) OrElse hidden_SUBJECT_ID.Value.ToString()="" Then
            errors.Add("hidden_SUBJECT_ID",String.Format("The Subject for this Class could not be found. Comments will NOT be added.","STUDENT_COMMENT"))
        End If
'End Record STUDENT_COMMENT Event OnValidate. Action Validate Required Value

'Record STUDENT_COMMENT Item Class tail @13-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_COMMENT Item Class tail

'Record STUDENT_COMMENT Data Provider Class @13-16077315
Public Class STUDENT_COMMENTDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_COMMENT Data Provider Class

'Record STUDENT_COMMENT Data Provider Class Variables @13-2D2572F2
    Public UrlCOMMENT_ID As IntegerParameter
    Public ExprKey189 As IntegerParameter
    Public Ctrlhidden_SUBJECT_ID As IntegerParameter
    Public Ctrlhidden_ENROLSTATUS As TextParameter
    Public CtrlHidden_SEMESTER As TextParameter
    Public CtrllbSpecialCommentType1 As TextParameter
    Public CtrlCOMMENT As TextParameter
    Public ExprKey195 As TextParameter
    Protected item As STUDENT_COMMENTItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_COMMENT Data Provider Class Variables

'Record STUDENT_COMMENT Data Provider Class Constructor @13-7DD568B3

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_COMMENT {SQL_Where} {SQL_OrderBy}", New String(){"COMMENT_ID16"},Settings.connDECVPRODSQL2005DataAccessObject )
        Insert=new SpCommand("spi_ins_ClassComments_multiple;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_COMMENT Data Provider Class Constructor

'Record STUDENT_COMMENT Data Provider Class LoadParams Method @13-176311CA

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlCOMMENT_ID))
    End Function
'End Record STUDENT_COMMENT Data Provider Class LoadParams Method

'Record STUDENT_COMMENT Data Provider Class CheckUnique Method @13-94B55604

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_COMMENTItem) As Boolean
        Return True
    End Function
'End Record STUDENT_COMMENT Data Provider Class CheckUnique Method

'Record STUDENT_COMMENT Data Provider Class PrepareInsert Method @13-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STUDENT_COMMENT Data Provider Class PrepareInsert Method

'Record STUDENT_COMMENT Data Provider Class PrepareInsert Method tail @13-E31F8E2A
    End Sub
'End Record STUDENT_COMMENT Data Provider Class PrepareInsert Method tail

'Record STUDENT_COMMENT Data Provider Class Insert Method @13-849D9399

    Public Function InsertItem(ByVal item As STUDENT_COMMENTItem) As Integer
        Me.item = item
'End Record STUDENT_COMMENT Data Provider Class Insert Method

'Record STUDENT_COMMENT Build insert @13-4277460B
        Insert.Parameters.Clear()
        CType(Insert,SpCommand).AddParameter("@RETURN_VALUE",ExprKey189,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Insert,SpCommand).AddParameter("@SubjectID",item.hidden_SUBJECT_ID,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Insert,SpCommand).AddParameter("@Enrolment",item.hidden_ENROLSTATUS,ParameterType._VarChar,ParameterDirection.Input,20,0,10)
        CType(Insert,SpCommand).AddParameter("@Semester",item.Hidden_SEMESTER,ParameterType._VarChar,ParameterDirection.Input,8,0,10)
        CType(Insert,SpCommand).AddParameter("@CommentType",item.lbSpecialCommentType1,ParameterType._VarChar,ParameterDirection.Input,20,0,10)
        CType(Insert,SpCommand).AddParameter("@CommentText",item.COMMENT,ParameterType._VarChar,ParameterDirection.Input,255,0,10)
        CType(Insert,SpCommand).AddParameter("@UserID",ExprKey195,ParameterType._VarChar,ParameterDirection.Input,8,0,10)
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
            result = ExecuteInsert()
            ExprKey189 = IntegerParameter.GetParam(CType(Insert.Parameters("@RETURN_VALUE"),IDataParameter).Value)
        Catch ee As Exception
            E = ee
        Finally
'End Record STUDENT_COMMENT Build insert

'Record STUDENT_COMMENT AfterExecuteInsert @13-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_COMMENT AfterExecuteInsert

'Record STUDENT_COMMENT Data Provider Class GetResultSet Method @13-8D4636B3

    Public Sub FillItem(ByVal item As STUDENT_COMMENTItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_COMMENT Data Provider Class GetResultSet Method

'Record STUDENT_COMMENT BeforeBuildSelect @13-3592F49E
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("COMMENT_ID16",UrlCOMMENT_ID, "","COMMENT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_COMMENT BeforeBuildSelect

'Record STUDENT_COMMENT BeforeExecuteSelect @13-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_COMMENT BeforeExecuteSelect

'Record STUDENT_COMMENT AfterExecuteSelect @13-30EEBEBB
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.COMMENT.SetValue(dr(i)("COMMENT"),"")
        Else
            IsInsertMode = True
        End If
'End Record STUDENT_COMMENT AfterExecuteSelect

'ListBox lbSpecialCommentType1 AfterExecuteSelect @68-C0438E7E
        
item.lbSpecialCommentType1Items.Add("CONTACT_PHONE","Telephone Contact")
item.lbSpecialCommentType1Items.Add("CONTACT_EMAIL","Email Contact")
item.lbSpecialCommentType1Items.Add("CONTACT_POST","Paper/Post Contact")
item.lbSpecialCommentType1Items.Add("CONTACT_VISIT","Visit to/by Student")
item.lbSpecialCommentType1Items.Add("CONTACT_OTHER","Other")
'End ListBox lbSpecialCommentType1 AfterExecuteSelect

'Record STUDENT_COMMENT AfterExecuteSelect tail @13-E31F8E2A
    End Sub
'End Record STUDENT_COMMENT AfterExecuteSelect tail

'Record STUDENT_COMMENT Data Provider Class @13-A61BA892
End Class

'End Record STUDENT_COMMENT Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

