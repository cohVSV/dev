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

Namespace DECV_PROD2007.Subject_Withdrawals 'Namespace @1-89A85C03

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

'Record SUBJECTSearch Item Class @8-99B63412
Public Class SUBJECTSearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_STUDENT_ID As TextField
    Public s_ENROL_YEAR As TextField
    Public Sub New()
    s_STUDENT_ID = New TextField("", Nothing)
    s_ENROL_YEAR = New TextField("", year(now()))
    End Sub

    Public Shared Function CreateFromHttpRequest() As SUBJECTSearchItem
        Dim item As SUBJECTSearchItem = New SUBJECTSearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("s_STUDENT_ID")) Then
        item.s_STUDENT_ID.SetValue(DBUtility.GetInitialValue("s_STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_ENROL_YEAR")) Then
        item.s_ENROL_YEAR.SetValue(DBUtility.GetInitialValue("s_ENROL_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_STUDENT_ID"
                    Return s_STUDENT_ID
                Case "s_ENROL_YEAR"
                    Return s_ENROL_YEAR
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_STUDENT_ID"
                    s_STUDENT_ID = CType(value, TextField)
                Case "s_ENROL_YEAR"
                    s_ENROL_YEAR = CType(value, TextField)
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

'Record SUBJECTSearch Data Provider Class Variables @8-F4199C7D
    Protected item As SUBJECTSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record SUBJECTSearch Data Provider Class Variables

'Record SUBJECTSearch Data Provider Class GetResultSet Method @8-71390615

    Public Sub FillItem(ByVal item As SUBJECTSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record SUBJECTSearch Data Provider Class GetResultSet Method

'Record SUBJECTSearch BeforeBuildSelect @8-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record SUBJECTSearch BeforeBuildSelect

'Record SUBJECTSearch AfterExecuteSelect @8-79426A21
        End If
            IsInsertMode = True
'End Record SUBJECTSearch AfterExecuteSelect

'Record SUBJECTSearch AfterExecuteSelect tail @8-E31F8E2A
    End Sub
'End Record SUBJECTSearch AfterExecuteSelect tail

'Record SUBJECTSearch Data Provider Class @8-A61BA892
End Class

'End Record SUBJECTSearch Data Provider Class

'Record UpdateForm Item Class @53-10310868
Public Class UpdateFormItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public lblStudentID As TextField
    Public lblFirstname As TextField
    Public lblSurname As TextField
    Public lblEnrolYear As TextField
    Public withdrawaldate As DateField
    Public listReasonOff As TextField
    Public listReasonOffItems As ItemCollection
    Public listSub_Enrol_Status As TextField
    Public listSub_Enrol_StatusItems As ItemCollection
    Public lblYearLevel As TextField
    Public listNonSubmitReason As TextField
    Public listNonSubmitReasonItems As ItemCollection
    Public lblSSTeacherID As TextField
    Public coord_comment As TextField
    Public lblSelections As TextField
    Public linkEarlyExit As TextField
    Public linkEarlyExitHref As Object
    Public linkEarlyExitHrefParameters As LinkParameterCollection
    Public Sub New()
    lblStudentID = New TextField("", Nothing)
    lblFirstname = New TextField("", Nothing)
    lblSurname = New TextField("", Nothing)
    lblEnrolYear = New TextField("", Nothing)
    withdrawaldate = New DateField("dd\/MM\/yyyy", now())
    listReasonOff = New TextField("", Nothing)
    listReasonOffItems = New ItemCollection()
    listSub_Enrol_Status = New TextField("", "W")
    listSub_Enrol_StatusItems = New ItemCollection()
    lblYearLevel = New TextField("", Nothing)
    listNonSubmitReason = New TextField("", Nothing)
    listNonSubmitReasonItems = New ItemCollection()
    lblSSTeacherID = New TextField("", Nothing)
    coord_comment = New TextField("", Nothing)
    lblSelections = New TextField("", Nothing)
    linkEarlyExit = New TextField("",Nothing)
    linkEarlyExitHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As UpdateFormItem
        Dim item As UpdateFormItem = New UpdateFormItem()
        If Not IsNothing(DBUtility.GetInitialValue("lblStudentID")) Then
        item.lblStudentID.SetValue(DBUtility.GetInitialValue("lblStudentID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblFirstname")) Then
        item.lblFirstname.SetValue(DBUtility.GetInitialValue("lblFirstname"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblSurname")) Then
        item.lblSurname.SetValue(DBUtility.GetInitialValue("lblSurname"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblEnrolYear")) Then
        item.lblEnrolYear.SetValue(DBUtility.GetInitialValue("lblEnrolYear"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("withdrawaldate")) Then
        item.withdrawaldate.SetValue(DBUtility.GetInitialValue("withdrawaldate"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("listReasonOff")) Then
        item.listReasonOff.SetValue(DBUtility.GetInitialValue("listReasonOff"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("listSub_Enrol_Status")) Then
        item.listSub_Enrol_Status.SetValue(DBUtility.GetInitialValue("listSub_Enrol_Status"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoUpdate")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoUpdate1")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblYearLevel")) Then
        item.lblYearLevel.SetValue(DBUtility.GetInitialValue("lblYearLevel"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("listNonSubmitReason")) Then
        item.listNonSubmitReason.SetValue(DBUtility.GetInitialValue("listNonSubmitReason"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblSSTeacherID")) Then
        item.lblSSTeacherID.SetValue(DBUtility.GetInitialValue("lblSSTeacherID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("coord_comment")) Then
        item.coord_comment.SetValue(DBUtility.GetInitialValue("coord_comment"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblSelections")) Then
        item.lblSelections.SetValue(DBUtility.GetInitialValue("lblSelections"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("linkEarlyExit")) Then
        item.linkEarlyExit.SetValue(DBUtility.GetInitialValue("linkEarlyExit"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "lblStudentID"
                    Return lblStudentID
                Case "lblFirstname"
                    Return lblFirstname
                Case "lblSurname"
                    Return lblSurname
                Case "lblEnrolYear"
                    Return lblEnrolYear
                Case "withdrawaldate"
                    Return withdrawaldate
                Case "listReasonOff"
                    Return listReasonOff
                Case "listSub_Enrol_Status"
                    Return listSub_Enrol_Status
                Case "lblYearLevel"
                    Return lblYearLevel
                Case "listNonSubmitReason"
                    Return listNonSubmitReason
                Case "lblSSTeacherID"
                    Return lblSSTeacherID
                Case "coord_comment"
                    Return coord_comment
                Case "lblSelections"
                    Return lblSelections
                Case "linkEarlyExit"
                    Return linkEarlyExit
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblStudentID"
                    lblStudentID = CType(value, TextField)
                Case "lblFirstname"
                    lblFirstname = CType(value, TextField)
                Case "lblSurname"
                    lblSurname = CType(value, TextField)
                Case "lblEnrolYear"
                    lblEnrolYear = CType(value, TextField)
                Case "withdrawaldate"
                    withdrawaldate = CType(value, DateField)
                Case "listReasonOff"
                    listReasonOff = CType(value, TextField)
                Case "listSub_Enrol_Status"
                    listSub_Enrol_Status = CType(value, TextField)
                Case "lblYearLevel"
                    lblYearLevel = CType(value, TextField)
                Case "listNonSubmitReason"
                    listNonSubmitReason = CType(value, TextField)
                Case "lblSSTeacherID"
                    lblSSTeacherID = CType(value, TextField)
                Case "coord_comment"
                    coord_comment = CType(value, TextField)
                Case "lblSelections"
                    lblSelections = CType(value, TextField)
                Case "linkEarlyExit"
                    linkEarlyExit = CType(value, TextField)
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

'withdrawaldate validate @46-56D56D7D
        If IsNothing(withdrawaldate.Value) OrElse withdrawaldate.Value.ToString() ="" Then
            errors.Add("withdrawaldate",String.Format(Resources.strings.CCS_RequiredField,"Withdrawal Date"))
        End If
'End withdrawaldate validate

'listReasonOff validate @70-C9A3B119
        If IsNothing(listReasonOff.Value) OrElse listReasonOff.Value.ToString() ="" Then
            errors.Add("listReasonOff",String.Format(Resources.strings.CCS_RequiredField,"Reason Off"))
        End If
'End listReasonOff validate

'DEL      ' -------------------------
'DEL      'ERA: better handling of multi select checkbox
'DEL  	If ((semester_1.value = false) AND (semester_2.value = false) AND (semester_both.value = false)) Then
'DEL  		errors.Add("semester_both","At least one Semester checkbox must be ticked.")
'DEL      End If
'DEL      ' -------------------------


'Record UpdateForm Item Class tail @53-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record UpdateForm Item Class tail

'Record UpdateForm Data Provider Class @53-4ED18962
Public Class UpdateFormDataProvider
Inherits RecordDataProviderBase
'End Record UpdateForm Data Provider Class

'Record UpdateForm Data Provider Class Variables @53-33078F53
    Protected listReasonOffDataCommand As DataCommand=new TableCommand("SELECT WITHDRAWAL_REASON_ID, " & vbCrLf & _
          "WITHDRAWAL_REASON " & vbCrLf & _
          "FROM WITHDRAWAL_REASON {SQL_Where} {SQL_OrderBy}", New String(){"expr96"},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected listNonSubmitReasonDataCommand As DataCommand=new SqlCommand("select 'Awaiting Apprenticeship/Traineeship' as [displaylabel], '' + rtrim(a.FIRST_NAME) +" & _
          " ' has been placed in NONSUBMIT. He/she is currently awaiting to begin an apprenticeship/t" & _
          "raineeship. SS teacher was ' + b.pastoral_care_id  as [value]" & vbCrLf & _
          "from STUDENT a, STUDENT_ENROLMENT b where a.STUDENT_ID={s_STUDENT_ID} and ENROLMENT_YEAR={" & _
          "s_ENROL_YEAR} and a.STUDENT_ID=b.STUDENT_ID" & vbCrLf & _
          "union" & vbCrLf & _
          "select 'Awaiting VRQA registration' as [displaylabel], 'Awaiting VRQA registration' as [va" & _
          "lue]" & vbCrLf & _
          "from STUDENT a, STUDENT_ENROLMENT b where a.STUDENT_ID={s_STUDENT_ID} and ENROLMENT_YEAR={" & _
          "s_ENROL_YEAR} and a.STUDENT_ID=b.STUDENT_ID" & vbCrLf & _
          "union" & vbCrLf & _
          "select 'Medical' as [displaylabel], 'Due to medical circumstances, ' + rtrim(a.FIRST_NAME)" & _
          " + ' has been placed in NONSUBMIT. Current medical documentation supporting this has been " & _
          "received and placed in student file. SS teacher was ' + b.pastoral_care_id  as [value]" & vbCrLf & _
          "from STUDENT a, STUDENT_ENROLMENT b where a.STUDENT_ID={s_STUDENT_ID} and ENROLMENT_YEAR={" & _
          "s_ENROL_YEAR} and a.STUDENT_ID=b.STUDENT_ID" & vbCrLf & _
          "union" & vbCrLf & _
          "select 'School Refuser' as [displaylabel], '' + rtrim(a.FIRST_NAME) + ' has been placed in" & _
          " NONSUBMIT due to their refusal of participating in their Learning Program and/or any stra" & _
          "tegies established for their engagement. SS teacher was ' + b.pastoral_care_id  as [value]" & vbCrLf & _
          "from STUDENT a, STUDENT_ENROLMENT b where a.STUDENT_ID={s_STUDENT_ID} and ENROLMENT_YEAR={" & _
          "s_ENROL_YEAR} and a.STUDENT_ID=b.STUDENT_ID" & vbCrLf & _
          "union" & vbCrLf & _
          "select 'SMAP' as [displaylabel], rtrim(a.FIRST_NAME) + ' Placed in NONSUBMIT and made a re" & _
          "ferral to pathways and transitions as a result of the SMAPs process, as to date has submit" & _
          "ted an insufficient amount of work. SS teacher was ' + b.pastoral_care_id as [value]" & vbCrLf & _
          "from STUDENT a, STUDENT_ENROLMENT b where a.STUDENT_ID={s_STUDENT_ID} and ENROLMENT_YEAR={" & _
          "s_ENROL_YEAR} and a.STUDENT_ID=b.STUDENT_ID" & vbCrLf & _
          "union" & vbCrLf & _
          "select 'Wellbeing recommendation' as [displaylabel], 'Due to recommendation from Wellbeing" & _
          " Caseworker, ' +  rtrim(a.FIRST_NAME) + ' has been placed in NONSUBMIT. SS teacher was ' +" & _
          " b.pastoral_care_id as [value]" & vbCrLf & _
          "from STUDENT a, STUDENT_ENROLMENT b where a.STUDENT_ID={s_STUDENT_ID} and ENROLMENT_YEAR={" & _
          "s_ENROL_YEAR} and a.STUDENT_ID=b.STUDENT_ID" & vbCrLf & _
          "" & vbCrLf & _
          "" & vbCrLf & _
          "" & vbCrLf & _
          " ",Settings.connDECVPRODSQL2005DataAccessObject)
    Public Urls_STUDENT_ID As IntegerParameter
    Public Urls_ENROL_YEAR As IntegerParameter
    Protected item As UpdateFormItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record UpdateForm Data Provider Class Variables

'Record UpdateForm Data Provider Class Constructor @53-2B084F8E

    Public Sub New()
        Select_=new SqlCommand("select rtrim(a.SURNAME) as SURNAME" & vbCrLf & _
          ",rtrim(a.FIRST_NAME) as FIRSTNAME" & vbCrLf & _
          ",b.CAMPUS, b.ENROLMENT_YEAR, a.STUDENT_ID" & vbCrLf & _
          ", b.year_level, b.pastoral_care_id" & vbCrLf & _
          "from STUDENT a, STUDENT_ENROLMENT b " & vbCrLf & _
          "where a.STUDENT_ID={s_STUDENT_ID}" & vbCrLf & _
          "and ENROLMENT_YEAR={s_ENROL_YEAR}" & vbCrLf & _
          " and a.STUDENT_ID=b.STUDENT_ID",Settings.connDECVPRODSQL2005DataAccessObject)
        Update=new SqlCommand("",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record UpdateForm Data Provider Class Constructor

'Record UpdateForm Data Provider Class LoadParams Method @53-B45586B2

    Protected Function LoadParams() As Boolean
        Return True
    End Function
'End Record UpdateForm Data Provider Class LoadParams Method

'Record UpdateForm Data Provider Class CheckUnique Method @53-5227C1D2

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As UpdateFormItem) As Boolean
        Return True
    End Function
'End Record UpdateForm Data Provider Class CheckUnique Method

'Record UpdateForm Data Provider Class PrepareUpdate Method @53-0A131024

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
'End Record UpdateForm Data Provider Class PrepareUpdate Method

'Record UpdateForm Data Provider Class PrepareUpdate Method tail @53-E31F8E2A
    End Sub
'End Record UpdateForm Data Provider Class PrepareUpdate Method tail

'Record UpdateForm Data Provider Class Update Method @53-F51BE98A

    Public Function UpdateItem(ByVal item As UpdateFormItem) As Integer
        Me.item = item
'End Record UpdateForm Data Provider Class Update Method

'Record UpdateForm BeforeBuildUpdate @53-AD037AB7
        Update.Parameters.Clear()
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
            result = ExecuteUpdate()
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record UpdateForm BeforeBuildUpdate

'Record UpdateForm AfterExecuteUpdate @53-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record UpdateForm AfterExecuteUpdate

'Record UpdateForm Data Provider Class GetResultSet Method @53-9C02F596

    Public Sub FillItem(ByVal item As UpdateFormItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record UpdateForm Data Provider Class GetResultSet Method

'Record UpdateForm BeforeBuildSelect @53-19A5BE0E
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("s_STUDENT_ID",Urls_STUDENT_ID, "")
        CType(Select_,SqlCommand).AddParameter("s_ENROL_YEAR",Urls_ENROL_YEAR, "")
        IsInsertMode = (IsNothing(Urls_STUDENT_ID) Or IsNothing(Urls_ENROL_YEAR))
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record UpdateForm BeforeBuildSelect

'Record UpdateForm BeforeExecuteSelect @53-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record UpdateForm BeforeExecuteSelect

'Record UpdateForm AfterExecuteSelect @53-AE57196F
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.lblStudentID.SetValue(dr(i)("STUDENT_ID"),"")
            item.lblFirstname.SetValue(dr(i)("FIRSTNAME"),"")
            item.lblSurname.SetValue(dr(i)("SURNAME"),"")
            item.lblEnrolYear.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.lblYearLevel.SetValue(dr(i)("year_level"),"")
            item.lblSSTeacherID.SetValue(dr(i)("pastoral_care_id"),"")
            item.linkEarlyExitHref = ""
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record UpdateForm AfterExecuteSelect

'ListBox listReasonOff Initialize Data Source @70-AEEE657D
        listReasonOffDataCommand.Dao._optimized = False
        Dim listReasonOfftableIndex As Integer = 0
        listReasonOffDataCommand.OrderBy = "WITHDRAWAL_REASON"
        listReasonOffDataCommand.Parameters.Clear()
        listReasonOffDataCommand.Parameters.Add("expr96","(STATUS = 1)")
'End ListBox listReasonOff Initialize Data Source

'ListBox listReasonOff BeforeExecuteSelect @70-62F32301
        Try
            ListBoxSource=listReasonOffDataCommand.Execute().Tables(listReasonOfftableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox listReasonOff BeforeExecuteSelect

'ListBox listReasonOff AfterExecuteSelect @70-5337A69A
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("WITHDRAWAL_REASON_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("WITHDRAWAL_REASON")
            item.listReasonOffItems.Add(Key, Val)
        Next
'End ListBox listReasonOff AfterExecuteSelect

'ListBox listSub_Enrol_Status AfterExecuteSelect @71-17D51016
        
item.listSub_Enrol_StatusItems.Add("C","Current")
item.listSub_Enrol_StatusItems.Add("W","Withdrawn")
item.listSub_Enrol_StatusItems.Add("F","Finished")
item.listSub_Enrol_StatusItems.Add("E","Extending")
item.listSub_Enrol_StatusItems.Add("D","Defaulting")
item.listSub_Enrol_StatusItems.Add("P","Pending")
'End ListBox listSub_Enrol_Status AfterExecuteSelect

'ListBox listNonSubmitReason Initialize Data Source @82-BA9D1C56
        listNonSubmitReasonDataCommand.Dao._optimized = False
        Dim listNonSubmitReasontableIndex As Integer = 0
        listNonSubmitReasonDataCommand.OrderBy = ""
        listNonSubmitReasonDataCommand.Parameters.Clear()
        CType(listNonSubmitReasonDataCommand,SqlCommand).AddParameter("s_STUDENT_ID",Urls_STUDENT_ID, "")
        CType(listNonSubmitReasonDataCommand,SqlCommand).AddParameter("s_ENROL_YEAR",Urls_ENROL_YEAR, "")
'End ListBox listNonSubmitReason Initialize Data Source

'ListBox listNonSubmitReason BeforeExecuteSelect @82-65E2667B
        Try
            ListBoxSource=listNonSubmitReasonDataCommand.Execute().Tables(listNonSubmitReasontableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox listNonSubmitReason BeforeExecuteSelect

'ListBox listNonSubmitReason AfterExecuteSelect @82-F2E9526F
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("value"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("displaylabel")
            item.listNonSubmitReasonItems.Add(Key, Val)
        Next
'End ListBox listNonSubmitReason AfterExecuteSelect

'Record UpdateForm AfterExecuteSelect tail @53-E31F8E2A
    End Sub
'End Record UpdateForm AfterExecuteSelect tail

'Record UpdateForm Data Provider Class @53-A61BA892
End Class

'End Record UpdateForm Data Provider Class

'Grid SUBJECT Item Class @3-13944C3F
Public Class SUBJECTItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public SUBJECT_TotalRecords As TextField
    Public cbox As TextField
    Public cboxCheckedValue As TextField
    Public cboxUncheckedValue As TextField
    Public SUBJECT_ID As IntegerField
    Public STATUS As TextField
    Public SUBJECT_TITLE As TextField
    Public SEMESTER As TextField
    Public STAFF_ID As TextField
    Public NON_SUBMIT As TextField
    Public Sub New()
    SUBJECT_TotalRecords = New TextField("", Nothing)
    cbox = New TextField("", "OFF")
    cboxCheckedValue = New TextField("", "ON")
    cboxUncheckedValue = New TextField("", "OFF")
    SUBJECT_ID = New IntegerField("", Nothing)
    STATUS = New TextField("", Nothing)
    SUBJECT_TITLE = New TextField("", Nothing)
    SEMESTER = New TextField("", Nothing)
    STAFF_ID = New TextField("", Nothing)
    NON_SUBMIT = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "SUBJECT_TotalRecords"
                    Return Me.SUBJECT_TotalRecords
                Case "cbox"
                    Return Me.cbox
                Case "SUBJECT_ID"
                    Return Me.SUBJECT_ID
                Case "STATUS"
                    Return Me.STATUS
                Case "SUBJECT_TITLE"
                    Return Me.SUBJECT_TITLE
                Case "SEMESTER"
                    Return Me.SEMESTER
                Case "STAFF_ID"
                    Return Me.STAFF_ID
                Case "NON_SUBMIT"
                    Return Me.NON_SUBMIT
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SUBJECT_TotalRecords"
                    Me.SUBJECT_TotalRecords = CType(Value,TextField)
                Case "cbox"
                    Me.cbox = CType(Value,TextField)
                Case "SUBJECT_ID"
                    Me.SUBJECT_ID = CType(Value,IntegerField)
                Case "STATUS"
                    Me.STATUS = CType(Value,TextField)
                Case "SUBJECT_TITLE"
                    Me.SUBJECT_TITLE = CType(Value,TextField)
                Case "SEMESTER"
                    Me.SEMESTER = CType(Value,TextField)
                Case "STAFF_ID"
                    Me.STAFF_ID = CType(Value,TextField)
                Case "NON_SUBMIT"
                    Me.NON_SUBMIT = CType(Value,TextField)
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

'Grid SUBJECT Data Provider Class Variables @3-E20874A2

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {"B.CAMPUS_CODE,A.SUBJECT_ID"}
    Private SortFieldsNamesDesc As String() = New string() {"B.CAMPUS_CODE,A.SUBJECT_ID"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 80
    Public PageNumber As Integer = 1
    Public Urls_STUDENT_ID  As TextParameter
    Public Urls_ENROL_YEAR  As TextParameter
'End Grid SUBJECT Data Provider Class Variables

'Grid SUBJECT Data Provider Class GetResultSet Method @3-94C71A8B

    Public Sub New()
        Select_=new SqlCommand("select TOP {SqlParam_endRecord} B.CAMPUS_CODE, A.SUBJECT_ID, A.SUBJ_ENROL_STATUS, B.SUBJEC" & _
          "T_TITLE, A.SEMESTER , A.STAFF_ID" & vbCrLf & _
          "	, A.NON_SUBMITTING_FLAG" & vbCrLf & _
          "	, (case when A.NON_SUBMITTING_FLAG = 1 then 'Non-Submitting' else '' end) as NON_SUBMITTI" & _
          "NG_FLAG_display" & vbCrLf & _
          "from STUDENT_SUBJECT A, SUBJECT B " & vbCrLf & _
          "where A.SUBJECT_ID = B.SUBJECT_ID and " & vbCrLf & _
          "A.STUDENT_ID = {s_STUDENT_ID} and " & vbCrLf & _
          "A.ENROLMENT_YEAR = {s_ENROL_YEAR} {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (select B.CAMPUS_CODE, A.SUBJECT_ID, A.SUBJ_ENROL_STATUS, B.SUBJECT_T" & _
          "ITLE, A.SEMESTER , A.STAFF_ID" & vbCrLf & _
          "	, A.NON_SUBMITTING_FLAG" & vbCrLf & _
          "	, (case when A.NON_SUBMITTING_FLAG = 1 then 'Non-Submitting' else '' end) as NON_SUBMITTI" & _
          "NG_FLAG_display" & vbCrLf & _
          "from STUDENT_SUBJECT A, SUBJECT B " & vbCrLf & _
          "where A.SUBJECT_ID = B.SUBJECT_ID and " & vbCrLf & _
          "A.STUDENT_ID = {s_STUDENT_ID} and " & vbCrLf & _
          "A.ENROLMENT_YEAR = {s_ENROL_YEAR}) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid SUBJECT Data Provider Class GetResultSet Method

'Grid SUBJECT Data Provider Class GetResultSet Method @3-40D1E8E8
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As SUBJECTItem()
'End Grid SUBJECT Data Provider Class GetResultSet Method

'Before build Select @3-D235817A
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("s_STUDENT_ID",Urls_STUDENT_ID, "")
        CType(Select_,SqlCommand).AddParameter("s_ENROL_YEAR",Urls_ENROL_YEAR, "")
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

'After execute Select tail @3-CBAD05F9
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as SUBJECTItem = New SUBJECTItem()
                item.SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
                item.STATUS.SetValue(dr(i)("SUBJ_ENROL_STATUS"),"")
                item.SUBJECT_TITLE.SetValue(dr(i)("SUBJECT_TITLE"),"")
                item.SEMESTER.SetValue(dr(i)("SEMESTER"),"")
                item.STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
                item.NON_SUBMIT.SetValue(dr(i)("NON_SUBMITTING_FLAG_display"),"")
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

