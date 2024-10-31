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

Namespace DECV_PROD2007.Student_ClassList_Extender 'Namespace @1-8F3521FF

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

'Record CLASS_LIST_Panel Item Class @4-46435C6D
Public Class CLASS_LIST_PanelItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public List_Subject_id As TextField
    Public List_Subject_idItems As ItemCollection
    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public Sub New()
    List_Subject_id = New TextField("", Nothing)
    List_Subject_idItems = New ItemCollection()
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

'Record CLASS_LIST_Panel Item Class tail @4-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record CLASS_LIST_Panel Item Class tail

'Record CLASS_LIST_Panel Data Provider Class @4-148E95F3
Public Class CLASS_LIST_PanelDataProvider
Inherits RecordDataProviderBase
'End Record CLASS_LIST_Panel Data Provider Class

'Record CLASS_LIST_Panel Data Provider Class Variables @4-FC57FC3A
    Protected List_Subject_idDataCommand As DataCommand=new SqlCommand("SELECT distinct SUBJECT_TITLE, " & vbCrLf & _
          "SUBJECT.SUBJECT_ID AS SUBJECT_SUBJECT_ID, " & vbCrLf & _
          "SUBJECT_ABBREV, RTRIM(SUBJECT_TITLE) +' [' + SUBJECT_ABBREV + '] ' + ' (ID ' + CAST(SUBJEC" & _
          "T.SUBJECT_ID AS varchar(255)) + ')'  AS subject_displaylabel " & vbCrLf & _
          "FROM SUBJECT INNER JOIN STUDENT_SUBJECT ON" & vbCrLf & _
          "SUBJECT.SUBJECT_ID = STUDENT_SUBJECT.SUBJECT_ID" & vbCrLf & _
          "WHERE ( CAMPUS_CODE='D' )" & vbCrLf & _
          "AND ( status = 1 )" & vbCrLf & _
          "AND ( ENROLMENT_YEAR=year(getdate())  ) " & vbCrLf & _
          "AND ( STUDENT_SUBJECT.STAFF_ID = '{STAFF_ID}')" & vbCrLf & _
          "AND ( SUBJECT.EXTENDABLE_FLAG = 1)",Settings.connDECVPRODSQL2005DataAccessObject)
    Public Expr263 As TextParameter
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

'ListBox List_Subject_id Initialize Data Source @62-A7C06908
        List_Subject_idDataCommand.Dao._optimized = False
        Dim List_Subject_idtableIndex As Integer = 0
        List_Subject_idDataCommand.OrderBy = ""
        List_Subject_idDataCommand.Parameters.Clear()
        CType(List_Subject_idDataCommand,SqlCommand).AddParameter("STAFF_ID",Expr263, "")
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

'Record CLASS_LIST_Panel AfterExecuteSelect tail @4-E31F8E2A
    End Sub
'End Record CLASS_LIST_Panel AfterExecuteSelect tail

'Record CLASS_LIST_Panel Data Provider Class @4-A61BA892
End Class

'End Record CLASS_LIST_Panel Data Provider Class

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

'EditableGrid EditGrid_ExtendStudents Item Class @210-915B0F2F
Public Class EditGrid_ExtendStudentsItem
    Public errors As NameValueCollection = New NameValueCollection()
    Public RowId As Integer
    Private _deleteAllowed As Boolean = True
    Private _isNew As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STUDENT_ID As FloatField
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public SUBJ_ENROL_STATUS As TextField
    Public SEMESTER As TextField
    Public LAd As TextField
    Public CheckBox_Delete As BooleanField
    Public CheckBox_DeleteCheckedValue As BooleanField
    Public CheckBox_DeleteUncheckedValue As BooleanField
    Public lblCnt As IntegerField
    Public lblHintExtend As TextField
    Public lblHintPending As TextField
    Public Sub New()
    STUDENT_ID = New FloatField("", Nothing)
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    SUBJ_ENROL_STATUS = New TextField("", Nothing)
    SEMESTER = New TextField("", Nothing)
    LAd = New TextField("", Nothing)
    CheckBox_Delete = New BooleanField(Settings.BoolFormat, false)
    CheckBox_DeleteCheckedValue = New BooleanField(Settings.BoolFormat, true)
    CheckBox_DeleteUncheckedValue = New BooleanField(Settings.BoolFormat, false)
    lblCnt = New IntegerField("", Nothing)
    lblHintExtend = New TextField("", Nothing)
    lblHintPending = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase
        Get
            Select fieldName
                Case "SEMESTERField"
                    Return Me.SEMESTERField
                Case "STUDENT_IDField"
                    Return Me.STUDENT_IDField
                Case "SUBJECT_IDField"
                    Return Me.SUBJECT_IDField
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "SUBJ_ENROL_STATUS"
                    Return Me.SUBJ_ENROL_STATUS
                Case "SEMESTER"
                    Return Me.SEMESTER
                Case "LAd"
                    Return Me.LAd
                Case "CheckBox_Delete"
                    Return Me.CheckBox_Delete
                Case "lblCnt"
                    Return Me.lblCnt
                Case "lblHintExtend"
                    Return Me.lblHintExtend
                Case "lblHintPending"
                    Return Me.lblHintPending
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SEMESTERField"
                    Me.SEMESTERField = CType(Value,TextField)
                Case "STUDENT_IDField"
                    Me.STUDENT_IDField = CType(Value,IntegerField)
                Case "SUBJECT_IDField"
                    Me.SUBJECT_IDField = CType(Value,IntegerField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "SUBJ_ENROL_STATUS"
                    Me.SUBJ_ENROL_STATUS = CType(Value,TextField)
                Case "SEMESTER"
                    Me.SEMESTER = CType(Value,TextField)
                Case "LAd"
                    Me.LAd = CType(Value,TextField)
                Case "CheckBox_Delete"
                    Me.CheckBox_Delete = CType(Value,BooleanField)
                Case "lblCnt"
                    Me.lblCnt = CType(Value,IntegerField)
                Case "lblHintExtend"
                    Me.lblHintExtend = CType(Value,TextField)
                Case "lblHintPending"
                    Me.lblHintPending = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public  Property IsDeleteAllowed As Boolean
        Get
            Return  Not(IsEmptyItem) AndAlso _deleteAllowed
        End Get
        Set
            _deleteAllowed = Value
        End Set
    End Property

    Public Property IsNew As Boolean
        Get
            Return _isNew
        End Get
        Set
            _isNew = Value
        End Set
    End Property

    Public ReadOnly Property IsEmptyItem As Boolean
        Get
            Dim result As Boolean = True
            result = IsNothing(CheckBox_Delete.Value) And result
            result = IsNothing(SEMESTERField.Value) And result
            Return result
        End Get
    End Property

    Public IsDeleted As Boolean = False
    Public IsUpdated As Boolean = False
    Public SEMESTERField As TextField = New TextField()
    Public STUDENT_IDField As IntegerField = New IntegerField()
    Public SUBJECT_IDField As IntegerField = New IntegerField()
    Public Function Validate(ByVal provider As EditGrid_ExtendStudentsDataProvider) As Boolean
'End EditableGrid EditGrid_ExtendStudents Item Class

'EditableGrid EditGrid_ExtendStudents Item Class tail @210-11D8DCF0
        Return errors.Count = 0
    End Function
    Public RawData As DataRow = Nothing
End Class
'End EditableGrid EditGrid_ExtendStudents Item Class tail

'EditableGrid EditGrid_ExtendStudents Data Provider Class Header @210-EA47FA88
Public Class EditGrid_ExtendStudentsDataProvider
Inherits EditableGridDataProviderBase
'End EditableGrid EditGrid_ExtendStudents Data Provider Class Header

'Grid EditGrid_ExtendStudents Data Provider Class Variables @210-BB0BBD58

    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_STUDENT_ID
        Sorter_SURNAME
        Sorter_FIRST_NAME
        Sorter_SUBJ_ENROL_STATUS
        Sorter_SEMESTER
        Sorter_LAd
    End Enum

    Private SortFieldsNames As String() = New String() {"","STUDENT_ID","SURNAME","FIRST_NAME","SUBJ_ENROL_STATUS","SEMESTER","LAd"}
    Private SortFieldsNamesDesc As String() = New string() {"","STUDENT_ID DESC","SURNAME DESC","FIRST_NAME DESC","SUBJ_ENROL_STATUS DESC","SEMESTER DESC","LAd DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 120
    Public PageNumber As Integer = 1
    Public UrlList_Subject_id  As IntegerParameter
    Public Expr281  As TextParameter
    Public ExprKey4  As TextParameter
    Public ExprKey1  As IntegerParameter
'End Grid EditGrid_ExtendStudents Data Provider Class Variables

'EditableGrid EditGrid_ExtendStudents Data Provider Class Constructor @210-A3C16253

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} STUDENT_ID, SURNAME, FIRST_NAME, SUBJECT_ID, " & vbCrLf & _
          "SUBJ_ENROL_STATUS, SEMESTER, " & vbCrLf & _
          "LAd " & vbCrLf & _
          "FROM view_Class_Contact_List_04022011 {SQL_Where} {SQL_OrderBy}", New String(){"expr278","And","List_Subject_id279","And","expr280","And","expr281"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM view_Class_Contact_List_04022011", New String(){"expr278","And","List_Subject_id279","And","expr280","And","expr281"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End EditableGrid EditGrid_ExtendStudents Data Provider Class Constructor

'Record EditGrid_ExtendStudents Data Provider Class CheckUnique Method @210-5A9EBF44

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As EditGrid_ExtendStudentsItem) As Boolean
        Return True
    End Function
'End Record EditGrid_ExtendStudents Data Provider Class CheckUnique Method

'Record EditGrid_ExtendStudents Data Provider Class Delete Method @210-84F9E298
    Public Function DeleteItem(ByVal item As EditGrid_ExtendStudentsItem) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        Dim Delete As DataCommand=new SpCommand("spu_ExtendStudentSubject;1",Settings.connDECVPRODSQL2005DataAccessObject)
'End Record EditGrid_ExtendStudents Data Provider Class Delete Method

'Record EditGrid_ExtendStudents BeforeBuildDelete @210-B94F5BF0
        Delete.Parameters.Clear()
        CType(Delete,SpCommand).AddParameter("@STUDENT_ID",item.STUDENT_IDField,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Delete,SpCommand).AddParameter("@SUBJECT_ID",item.SUBJECT_IDField,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Delete,SpCommand).AddParameter("@LAST_ALTERED_BY",ExprKey4,ParameterType._Char,ParameterDirection.Input,12,0,0)
        CType(Delete,SpCommand).AddParameter("@RETURN_VALUE",ExprKey1,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
'End Record EditGrid_ExtendStudents BeforeBuildDelete

'EditableGrid EditGrid_ExtendStudents Data Provider Class Execute Delete @210-203E24E5
        Delete.OpType = OperationType.Delete
        Dim result As Object = 0
        Dim E As Exception = Nothing
        If CmdExecution Then
            If Not IsParametersPassed Then
                item.errors.Add("DataProvider",Resources.strings.CCS_CustomOperationError_MissingParameters)
                Return 0
            End If
            Try
                result = Delete.ExecuteNonQuery()
                ExprKey1 = IntegerParameter.GetParam(CType(Delete.Parameters("@RETURN_VALUE"),IDataParameter).Value)
            Catch e_ As Exception
                item.errors.Add("DataProvider",e_.Source + ":" + e_.Message)
            Finally
'End EditableGrid EditGrid_ExtendStudents Data Provider Class Execute Delete

'EditableGrid EditGrid_ExtendStudents AfterExecuteDelete @210-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid EditGrid_ExtendStudents AfterExecuteDelete

'Grid EditGrid_ExtendStudents Data Provider Class GetResultSet Method @210-AB0A4C0E
    Public Sub Update(Items As ArrayList, ops As FormSupportedOperations)
        Dim i As Integer
        For i = 0 To Items.Count - 1
            Dim op As EditableGridOperation = EditableGridOperation.Insert
            Dim isProcessed As Boolean = False
            Dim item As EditGrid_ExtendStudentsItem = CType(Items(i), EditGrid_ExtendStudentsItem)
'End Grid EditGrid_ExtendStudents Data Provider Class GetResultSet Method

'EditableGrid EditGrid_ExtendStudents Data Provider Class Update @210-98CD378D
            If Not item.IsUpdated Then
                If item.IsDeleted And ops.AllowDelete Then
                    DeleteItem(item)
                    op = EditableGridOperation.Delete
                    isProcessed = True
                End If
'End EditableGrid EditGrid_ExtendStudents Data Provider Class Update

'EditableGrid EditGrid_ExtendStudents Data Provider Class AfterUpdate @210-6CCB76B9
                If item.errors.Count = 0 Then item.IsUpdated = True
                OnItemUpdated(New ItemUpdatedEventArgs(op, item))
            End If
        Next i
    End Sub
'End EditableGrid EditGrid_ExtendStudents Data Provider Class AfterUpdate

'EditableGrid EditGrid_ExtendStudents Data Provider Class GetResultSet Method @210-7725E41D
    Public Function GetResultSet(ByRef _pagesCount As Integer, ops As FormSupportedOperations) As EditGrid_ExtendStudentsItem()
'End EditableGrid EditGrid_ExtendStudents Data Provider Class GetResultSet Method

'Before build Select @210-B770CEB1
        _pagesCount = 0
        Dim E as Exception = Nothing
        Dim j As Integer
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("List_Subject_id279",UrlList_Subject_id, "","SUBJECT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("expr281",Expr281, "","STAFF_ID",Condition.Equal,False)
        Select_.Parameters.Add("expr278","(ENROLMENT_YEAR=year(getdate()))")
        Select_.Parameters.Add("expr280","(SEMESTER ='1')")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy = SortFieldsNames(CInt(SortField)).Trim
        Else
            Select_.OrderBy = SortFieldsNamesDesc(CInt(SortField)).Trim
        End If
    Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @210-939614DD
        Dim dr As DataRowCollection = Nothing
        Dim rowCount as Integer = 0
        Dim ds As DataSet = Nothing
        If ops.AllowRead Then
            _pagesCount=0
            Try
                If RecordsPerPage>0
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _pagesCount = ExecuteCount()
                    m_recordCount = _pagesCount
                    If _pagesCount Mod RecordsPerPage>0 Then
                        _pagesCount = (_pagesCount\RecordsPerPage)+1
                    Else
                        _pagesCount = _pagesCount\RecordsPerPage
                    End If
                Else
                ds=ExecuteSelect()
                If ds.Tables(tableIndex).Rows.Count<>0 Then 
                    _pagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @210-AE4165D3
                If Not IsNothing(E) Then Throw E
            End Try
            dr = ds.Tables(tableIndex).Rows
            rowCount = dr.Count
        End If
        Dim result(rowCount - 1) As EditGrid_ExtendStudentsItem
'End After execute Select

'After execute Select tail @210-BBAF92D3
        Dim i as Integer
        For i = 0 To rowCount - 1
            Dim item as EditGrid_ExtendStudentsItem = New EditGrid_ExtendStudentsItem()
            item.IsDeleteAllowed = ops.AllowDelete
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.SURNAME.SetValue(dr(i)("SURNAME"),"")
            item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
            item.SUBJ_ENROL_STATUS.SetValue(dr(i)("SUBJ_ENROL_STATUS"),"")
            item.SEMESTER.SetValue(dr(i)("SEMESTER"),"")
            item.LAd.SetValue(dr(i)("LAd"),"")
            item.SEMESTERField.SetValue(dr(i)("SEMESTER"),"")
            item.STUDENT_IDField.SetValue(dr(i)("STUDENT_ID"),"")
            item.SUBJECT_IDField.SetValue(dr(i)("SUBJECT_ID"),"")
            item.RawData = dr(i)
            result(i)=item
        Next i
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @210-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

