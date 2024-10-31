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

Namespace DECV_PROD2007.Student_Comments_maintain 'Namespace @1-C4AA6A30

'Page Data Class @1-C7555605
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Link_Backtosummary As TextField
    Public Link_BacktosummaryHref As Object
    Public Link_BacktosummaryHrefParameters As LinkParameterCollection
    Public Link_BacktoPastoralList As TextField
    Public Link_BacktoPastoralListHref As Object
    Public Link_BacktoPastoralListHrefParameters As LinkParameterCollection
    Public Sub New()
        Link_Backtosummary = New TextField("",Nothing)
        Link_BacktosummaryHrefParameters = New LinkParameterCollection()
        Link_BacktoPastoralList = New TextField("",Nothing)
        Link_BacktoPastoralListHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Link_Backtosummary.SetValue(DBUtility.GetInitialValue("Link_Backtosummary"))
        item.Link_BacktoPastoralList.SetValue(DBUtility.GetInitialValue("Link_BacktoPastoralList"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Link_Backtosummary"
                    Return Link_Backtosummary
                Case "Link_BacktoPastoralList"
                    Return Link_BacktoPastoralList
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link_Backtosummary"
                    Link_Backtosummary = CType(value, TextField)
                Case "Link_BacktoPastoralList"
                    Link_BacktoPastoralList = CType(value, TextField)
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

'Record STUDENT_COMMENT Item Class @13-D56C8965
Public Class STUDENT_COMMENTItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public lblSTUDENT_ID As TextField
    Public COMMENT As TextField
    Public STUDENT_ID As FloatField
    Public hidden_STATUS As TextField
    Public Hidden_CommentType As TextField
    Public lblCommentType As TextField
    Public lbSpecialCommentType As TextField
    Public lbSpecialCommentTypeItems As ItemCollection
    Public lbSpecialCommentType1 As TextField
    Public lbSpecialCommentType1Items As ItemCollection
    Public lbCannedResponses As TextField
    Public lbCannedResponsesItems As ItemCollection
    Public Sub New()
    lblSTUDENT_ID = New TextField("", Nothing)
    COMMENT = New TextField("", Nothing)
    STUDENT_ID = New FloatField("", Nothing)
    hidden_STATUS = New TextField("", "A")
    Hidden_CommentType = New TextField("", "REGULAR")
    lblCommentType = New TextField("", "SPECIAL COMMENT TYPE")
    lbSpecialCommentType = New TextField("", "0")
    lbSpecialCommentTypeItems = New ItemCollection()
    lbSpecialCommentType1 = New TextField("", "0")
    lbSpecialCommentType1Items = New ItemCollection()
    lbCannedResponses = New TextField("", Nothing)
    lbCannedResponsesItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_COMMENTItem
        Dim item As STUDENT_COMMENTItem = New STUDENT_COMMENTItem()
        If Not IsNothing(DBUtility.GetInitialValue("lblSTUDENT_ID")) Then
        item.lblSTUDENT_ID.SetValue(DBUtility.GetInitialValue("lblSTUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COMMENT")) Then
        item.COMMENT.SetValue(DBUtility.GetInitialValue("COMMENT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_STATUS")) Then
        item.hidden_STATUS.SetValue(DBUtility.GetInitialValue("hidden_STATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_CommentType")) Then
        item.Hidden_CommentType.SetValue(DBUtility.GetInitialValue("Hidden_CommentType"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblCommentType")) Then
        item.lblCommentType.SetValue(DBUtility.GetInitialValue("lblCommentType"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbSpecialCommentType")) Then
        item.lbSpecialCommentType.SetValue(DBUtility.GetInitialValue("lbSpecialCommentType"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbSpecialCommentType1")) Then
        item.lbSpecialCommentType1.SetValue(DBUtility.GetInitialValue("lbSpecialCommentType1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbCannedResponses")) Then
        item.lbCannedResponses.SetValue(DBUtility.GetInitialValue("lbCannedResponses"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "lblSTUDENT_ID"
                    Return lblSTUDENT_ID
                Case "COMMENT"
                    Return COMMENT
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "hidden_STATUS"
                    Return hidden_STATUS
                Case "Hidden_CommentType"
                    Return Hidden_CommentType
                Case "lblCommentType"
                    Return lblCommentType
                Case "lbSpecialCommentType"
                    Return lbSpecialCommentType
                Case "lbSpecialCommentType1"
                    Return lbSpecialCommentType1
                Case "lbCannedResponses"
                    Return lbCannedResponses
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblSTUDENT_ID"
                    lblSTUDENT_ID = CType(value, TextField)
                Case "COMMENT"
                    COMMENT = CType(value, TextField)
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, FloatField)
                Case "hidden_STATUS"
                    hidden_STATUS = CType(value, TextField)
                Case "Hidden_CommentType"
                    Hidden_CommentType = CType(value, TextField)
                Case "lblCommentType"
                    lblCommentType = CType(value, TextField)
                Case "lbSpecialCommentType"
                    lbSpecialCommentType = CType(value, TextField)
                Case "lbSpecialCommentType1"
                    lbSpecialCommentType1 = CType(value, TextField)
                Case "lbCannedResponses"
                    lbCannedResponses = CType(value, TextField)
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

'STUDENT_ID validate @17-6D9CF271
        If IsNothing(STUDENT_ID.Value) OrElse STUDENT_ID.Value.ToString() ="" Then
            errors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_RequiredField,"STUDENT ID"))
        End If
'End STUDENT_ID validate

'lbSpecialCommentType validate @63-056A8F1B
        If IsNothing(lbSpecialCommentType.Value) OrElse lbSpecialCommentType.Value.ToString() ="" Then
            errors.Add("lbSpecialCommentType",String.Format(Resources.strings.CCS_RequiredField,"Special Comment Type"))
        End If
'End lbSpecialCommentType validate

'lbSpecialCommentType1 validate @68-54AE4A18
        If IsNothing(lbSpecialCommentType1.Value) OrElse lbSpecialCommentType1.Value.ToString() ="" Then
            errors.Add("lbSpecialCommentType1",String.Format(Resources.strings.CCS_RequiredField,"Contact Type"))
        End If
'End lbSpecialCommentType1 validate

'Record STUDENT_COMMENT Event OnValidate. Action Custom Code @96-73254650
    ' -------------------------
    ' 9-June-2011|EA| Try to handle both Listboxes of CommentTypes, depending on if they are visible
	'					as regular validation isn't working if either is not visible (they fire regardless)
	' so if BOTH are blank then show common error
 	If (IsNothing(lbSpecialCommentType.Value) OrElse lbSpecialCommentType.Value.ToString() ="") AND (IsNothing(lbSpecialCommentType1.Value) OrElse lbSpecialCommentType1.Value.ToString() ="") Then
            errors.Add("lbSpecialCommentType","The CONTACT TYPE is required.")
    End If
    ' -------------------------
'End Record STUDENT_COMMENT Event OnValidate. Action Custom Code

'Record STUDENT_COMMENT Item Class tail @13-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_COMMENT Item Class tail

'Record STUDENT_COMMENT Data Provider Class @13-16077315
Public Class STUDENT_COMMENTDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_COMMENT Data Provider Class

'Record STUDENT_COMMENT Data Provider Class Variables @13-9BB8DCD6
    Protected lbSpecialCommentTypeDataCommand As DataCommand=new TableCommand("SELECT SPECIAL_FLAG, PUBLIC_FLAG, COMMENT_DESCRIPTION, " & vbCrLf & _
          "COMMENT_TYPE " & vbCrLf & _
          "FROM COMMENT_TYPE {SQL_Where} {SQL_OrderBy}", New String(){"expr144"},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected lbSpecialCommentType1DataCommand As DataCommand=new TableCommand("SELECT SPECIAL_FLAG, PUBLIC_FLAG, COMMENT_DESCRIPTION, " & vbCrLf & _
          "COMMENT_TYPE " & vbCrLf & _
          "FROM COMMENT_TYPE {SQL_Where} {SQL_OrderBy}", New String(){"expr151","And","expr152"},Settings.connDECVPRODSQL2005DataAccessObject )
    Public UrlCOMMENT_ID As IntegerParameter
    Public CtrlSTUDENT_ID As TextParameter
    Public CtrlCOMMENT As TextParameter
    Public Expr32 As TextParameter
    Public CtrlHidden_CommentType As TextParameter
    Protected item As STUDENT_COMMENTItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_COMMENT Data Provider Class Variables

'Record STUDENT_COMMENT Data Provider Class Constructor @13-DDC9E28C

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_COMMENT {SQL_Where} {SQL_OrderBy}", New String(){"COMMENT_ID16"},Settings.connDECVPRODSQL2005DataAccessObject )
        Insert=new SqlCommand("insert into STUDENT_COMMENT ([COMMENT_ID],[STUDENT_ID],[COMMENT],[LAST_ALTERED_BY],[LAST_A" & _
          "LTERED_DATE],[ACTIVE_STATUS],[COMMENT_TYPE]) " & vbCrLf & _
          "select (select (max(COMMENT_ID+1)) from STUDENT_COMMENT) , {STUDENT_ID},'{COMMENTTEXT}',UP" & _
          "PER('{LAST_ALTERED_BY}'), getdate(),'A','{COMMENT_TYPE}'",Settings.connDECVPRODSQL2005DataAccessObject)
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

'Record STUDENT_COMMENT Build insert @13-03BB867A
        Insert.Parameters.Clear()
        CType(Insert,SqlCommand).AddParameter("STUDENT_ID",item.STUDENT_ID, "")
        CType(Insert,SqlCommand).AddParameter("COMMENTTEXT",item.COMMENT, "")
        CType(Insert,SqlCommand).AddParameter("LAST_ALTERED_BY",Expr32, "")
        CType(Insert,SqlCommand).AddParameter("COMMENT_TYPE",item.Hidden_CommentType, "")
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
            result = ExecuteInsert()
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

'Record STUDENT_COMMENT AfterExecuteSelect @13-F41E81CB
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.lblSTUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.COMMENT.SetValue(dr(i)("COMMENT"),"")
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.hidden_STATUS.SetValue(dr(i)("ACTIVE_STATUS"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record STUDENT_COMMENT AfterExecuteSelect

'ListBox lbSpecialCommentType Initialize Data Source @63-04A48990
        lbSpecialCommentTypeDataCommand.Dao._optimized = False
        Dim lbSpecialCommentTypetableIndex As Integer = 0
        lbSpecialCommentTypeDataCommand.OrderBy = "SORT_ORDER, PUBLIC_FLAG desc, COMMENT_TYPE_ID"
        lbSpecialCommentTypeDataCommand.Parameters.Clear()
        lbSpecialCommentTypeDataCommand.Parameters.Add("expr144","(STATUS = 1)")
'End ListBox lbSpecialCommentType Initialize Data Source

'ListBox lbSpecialCommentType BeforeExecuteSelect @63-39A15467
        Try
            ListBoxSource=lbSpecialCommentTypeDataCommand.Execute().Tables(lbSpecialCommentTypetableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox lbSpecialCommentType BeforeExecuteSelect

'ListBox lbSpecialCommentType Event AfterExecuteSelect. Action Custom Code @157-73254650
    ' -------------------------
     ' 27 Jul 2021|RW| Replicate the functionality for the contact type dropdown (further below), for the special comment type:
     ' If the current user is the Learning Advisor or SSG Facilitator of the student, those options should be explicitly added to the dropdown.
     ' They should also be preselected.
     Dim tmpAuthIDsSCT = Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT concat(rtrim(isnull(pastoral_care_id, 'N-A')), ',', rtrim(isnull(SSG_FACILITATOR_ID, 'N-A'))) FROM student_enrolment WHERE enrolment_year = " & Settings.connDECVPRODSQL2005DataAccessObject.ToSql(System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR"), FieldType._Integer, True) & " AND STUDENT_ID = " & Settings.connDECVPRODSQL2005DataAccessObject.ToSql(System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"), FieldType._Text, True))
     Dim authIDsSCT = tmpAuthIDsSCT.ToString().ToUpper().Split({","c}, StringSplitOptions.RemoveEmptyEntries)
     Dim dbUserSCT = DBUtility.UserId.ToString.ToUpper().Trim()

     If ((authIDsSCT.Length > 1) AndAlso authIDsSCT(1).Equals(dbUserSCT)) Then
        item.lbSpecialCommentTypeItems.Add("SSG_FACILITATOR", "SSG Facilitator (Public Comment)")
        item.lbSpecialCommentType.SetValue("SSG_FACILITATOR")
     End If
     If ((authIDsSCT.Length > 0) AndAlso authIDsSCT(0).Equals(dbUserSCT)) Then
        item.lbSpecialCommentTypeItems.Add("PASTORAL", "Student Support (Public Comment)")
        item.lbSpecialCommentType.SetValue("PASTORAL")
     End If
    ' -------------------------
'End ListBox lbSpecialCommentType Event AfterExecuteSelect. Action Custom Code

'ListBox lbSpecialCommentType AfterExecuteSelect @63-3ABAE121
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("COMMENT_TYPE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("COMMENT_DESCRIPTION")
            item.lbSpecialCommentTypeItems.Add(Key, Val)
        Next
'End ListBox lbSpecialCommentType AfterExecuteSelect

'ListBox lbSpecialCommentType1 Initialize Data Source @68-08F8B9EC
        lbSpecialCommentType1DataCommand.Dao._optimized = False
        Dim lbSpecialCommentType1tableIndex As Integer = 0
        lbSpecialCommentType1DataCommand.OrderBy = "SORT_ORDER, PUBLIC_FLAG desc, COMMENT_TYPE_ID"
        lbSpecialCommentType1DataCommand.Parameters.Clear()
        lbSpecialCommentType1DataCommand.Parameters.Add("expr151","(SPECIAL_FLAG = 0)")
        lbSpecialCommentType1DataCommand.Parameters.Add("expr152","(STATUS = 1)")
'End ListBox lbSpecialCommentType1 Initialize Data Source

'ListBox lbSpecialCommentType1 BeforeExecuteSelect @68-E6D2AD27
        Try
            ListBoxSource=lbSpecialCommentType1DataCommand.Execute().Tables(lbSpecialCommentType1tableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox lbSpecialCommentType1 BeforeExecuteSelect

'ListBox lbSpecialCommentType1 Event AfterExecuteSelect. Action Custom Code @94-73254650
    ' -------------------------
    '27-May-2011|EA| put the pastoral option in place
		'ERA: original Pastoral care check - this will be used if the Teacher is also the Pastoral care teacher
   '31 Mar 2021|RW| Added SSG Facilitator
   '27 Jul 2021|RW| Reworked this logic so that if applicable the Learning Advisor and SSG Facilitator comments are visibly selected, rather than defaulted to as the
   '   comment type at the time of inserting the record.
   Dim tmpAuthIDs = Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT concat(rtrim(isnull(pastoral_care_id, 'N-A')), ',', rtrim(isnull(SSG_FACILITATOR_ID, 'N-A'))) FROM student_enrolment WHERE enrolment_year = " & Settings.connDECVPRODSQL2005DataAccessObject.ToSql(System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR"), FieldType._Integer, True) & " AND STUDENT_ID = " & Settings.connDECVPRODSQL2005DataAccessObject.ToSql(System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"), FieldType._Text, True))
   Dim authIDs = tmpAuthIDs.ToString().ToUpper().Split({","c}, StringSplitOptions.RemoveEmptyEntries)
   Dim dbUser = DBUtility.UserId.ToString.ToUpper().Trim()

   If ((authIDs.Length > 1) AndAlso authIDs(1).Equals(dbUser)) Then
		item.lbSpecialCommentType1Items.Add("SSG_FACILITATOR", "SSG Facilitator (Public Comment)")
		item.lbSpecialCommentType1.SetValue("SSG_FACILITATOR")
	end if
   If ((authIDs.Length > 0) AndAlso authIDs(0).Equals(dbUser)) Then
		item.lbSpecialCommentType1Items.Add("PASTORAL", "Student Support (Public Comment)")
		item.lbSpecialCommentType1.SetValue("PASTORAL")
   End If
    ' -------------------------
'End ListBox lbSpecialCommentType1 Event AfterExecuteSelect. Action Custom Code

'ListBox lbSpecialCommentType1 AfterExecuteSelect @68-8F28B43F
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("COMMENT_TYPE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("COMMENT_DESCRIPTION")
            item.lbSpecialCommentType1Items.Add(Key, Val)
        Next
'End ListBox lbSpecialCommentType1 AfterExecuteSelect

'ListBox lbCannedResponses AfterExecuteSelect @97-8A69D4D7
        
item.lbCannedResponsesItems.Add("Message Left","Message Left")
item.lbCannedResponsesItems.Add("Emailed about outstanding work","Emailed about outstanding work")
item.lbCannedResponsesItems.Add("Tried calling, No answer","Tried calling, No answer")
item.lbCannedResponsesItems.Add("Email bounced back","Email bounced back")
item.lbCannedResponsesItems.Add("Lack of submissions discussed","Lack of submissions discussed")
item.lbCannedResponsesItems.Add("Work issues discussed","Work issues discussed")
item.lbCannedResponsesItems.Add("Change of subjects","Change of subjects")
item.lbCannedResponsesItems.Add("Amber letter sent","Amber letter sent")
item.lbCannedResponsesItems.Add("Red letter sent","Red letter sent")
item.lbCannedResponsesItems.Add("Student Contact Hour","Student Contact Hour")
'End ListBox lbCannedResponses AfterExecuteSelect

'Record STUDENT_COMMENT AfterExecuteSelect tail @13-E31F8E2A
    End Sub
'End Record STUDENT_COMMENT AfterExecuteSelect tail

'Record STUDENT_COMMENT Data Provider Class @13-A61BA892
End Class

'End Record STUDENT_COMMENT Data Provider Class

'Grid Grid_DisplayComments Item Class @4-3F7F2E3A
Public Class Grid_DisplayCommentsItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public COMMENT As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public COMMENT_TYPE As TextField
    Public link_editcomment As TextField
    Public link_editcommentHref As Object
    Public link_editcommentHrefParameters As LinkParameterCollection
    Public Sub New()
    COMMENT = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    COMMENT_TYPE = New TextField("", Nothing)
    link_editcomment = New TextField("",Nothing)
    link_editcommentHrefParameters = New LinkParameterCollection()
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "COMMENT"
                    Return Me.COMMENT
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "COMMENT_TYPE"
                    Return Me.COMMENT_TYPE
                Case "link_editcomment"
                    Return Me.link_editcomment
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "COMMENT"
                    Me.COMMENT = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "COMMENT_TYPE"
                    Me.COMMENT_TYPE = CType(Value,TextField)
                Case "link_editcomment"
                    Me.link_editcomment = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid Grid_DisplayComments Item Class

'Grid Grid_DisplayComments Data Provider Class Header @4-CB75F408
Public Class Grid_DisplayCommentsDataProvider
Inherits GridDataProviderBase
'End Grid Grid_DisplayComments Data Provider Class Header

'Grid Grid_DisplayComments Data Provider Class Variables @4-9DBBBA2D

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {"LAST_ALTERED_DATE desc"}
    Private SortFieldsNamesDesc As String() = New string() {"LAST_ALTERED_DATE desc"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 30
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As FloatParameter
'End Grid Grid_DisplayComments Data Provider Class Variables

'Grid Grid_DisplayComments Data Provider Class GetResultSet Method @4-2DF6C10C

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} * " & vbCrLf & _
          "FROM STUDENT_COMMENT {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID6","And","expr28","And","expr81"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STUDENT_COMMENT", New String(){"STUDENT_ID6","And","expr28","And","expr81"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid Grid_DisplayComments Data Provider Class GetResultSet Method

'Grid Grid_DisplayComments Data Provider Class GetResultSet Method @4-522E69D9
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As Grid_DisplayCommentsItem()
'End Grid Grid_DisplayComments Data Provider Class GetResultSet Method

'Before build Select @4-42E99E68
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID6",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        Select_.Parameters.Add("expr28","(ACTIVE_STATUS = 'A')")
        Select_.Parameters.Add("expr81","(COMMENT_TYPE not like 'CONTACT%')")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @4-D27BF5A3
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As Grid_DisplayCommentsItem
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

'After execute Select @4-DF0D8388
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New Grid_DisplayCommentsItem(dr.Count-1) {}
'End After execute Select

'After execute Select @4-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @4-814327D3
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as Grid_DisplayCommentsItem = New Grid_DisplayCommentsItem()
                item.COMMENT.SetValue(dr(i)("COMMENT"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.COMMENT_TYPE.SetValue(dr(i)("COMMENT_TYPE"),"")
                item.link_editcommentHref = "Student_Comments_editown.aspx"
                item.link_editcommentHrefParameters.Add("COMMENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("COMMENT_ID").ToString()))
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

'Record ProfilesPanel Item Class @47-7063F9B0
Public Class ProfilesPanelItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public radio_PathwaysProfile As BooleanField
    Public radio_PathwaysProfileItems As ItemCollection
    Public radio_IntakeInterview As BooleanField
    Public radio_IntakeInterviewItems As ItemCollection
    Public label_EnrolYear As TextField
    Public Sub New()
    radio_PathwaysProfile = New BooleanField(Settings.BoolFormat, "No")
    radio_PathwaysProfileItems = New ItemCollection()
    radio_IntakeInterview = New BooleanField(Settings.BoolFormat, "No")
    radio_IntakeInterviewItems = New ItemCollection()
    label_EnrolYear = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As ProfilesPanelItem
        Dim item As ProfilesPanelItem = New ProfilesPanelItem()
        If Not IsNothing(DBUtility.GetInitialValue("radio_PathwaysProfile")) Then
        item.radio_PathwaysProfile.SetValue(DBUtility.GetInitialValue("radio_PathwaysProfile"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("radio_IntakeInterview")) Then
        item.radio_IntakeInterview.SetValue(DBUtility.GetInitialValue("radio_IntakeInterview"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("label_EnrolYear")) Then
        item.label_EnrolYear.SetValue(DBUtility.GetInitialValue("label_EnrolYear"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "radio_PathwaysProfile"
                    Return radio_PathwaysProfile
                Case "radio_IntakeInterview"
                    Return radio_IntakeInterview
                Case "label_EnrolYear"
                    Return label_EnrolYear
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "radio_PathwaysProfile"
                    radio_PathwaysProfile = CType(value, BooleanField)
                Case "radio_IntakeInterview"
                    radio_IntakeInterview = CType(value, BooleanField)
                Case "label_EnrolYear"
                    label_EnrolYear = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As ProfilesPanelDataProvider)
'End Record ProfilesPanel Item Class

'radio_PathwaysProfile validate @48-F78FBE27
        If IsNothing(radio_PathwaysProfile.Value) OrElse radio_PathwaysProfile.Value.ToString() ="" Then
            errors.Add("radio_PathwaysProfile",String.Format(Resources.strings.CCS_RequiredField,"Pathways Profile"))
        End If
'End radio_PathwaysProfile validate

'radio_IntakeInterview validate @51-01F830AC
        If IsNothing(radio_IntakeInterview.Value) OrElse radio_IntakeInterview.Value.ToString() ="" Then
            errors.Add("radio_IntakeInterview",String.Format(Resources.strings.CCS_RequiredField,"Student Profile"))
        End If
'End radio_IntakeInterview validate

'Record ProfilesPanel Item Class tail @47-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record ProfilesPanel Item Class tail

'Record ProfilesPanel Data Provider Class @47-937172B7
Public Class ProfilesPanelDataProvider
Inherits RecordDataProviderBase
'End Record ProfilesPanel Data Provider Class

'Record ProfilesPanel Data Provider Class Variables @47-C17571A7
    Public UrlSTUDENT_ID As FloatParameter
    Public UrlENROLMENT_YEAR As FloatParameter
    Protected item As ProfilesPanelItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record ProfilesPanel Data Provider Class Variables

'Record ProfilesPanel Data Provider Class Constructor @47-02FC6BEB

    Public Sub New()
        Select_=new TableCommand("SELECT STUDENT_ID, ENROLMENT_YEAR, INTAKE_INTERVIEW_DONE, " & vbCrLf & _
          "PATHWAY_PROFILE_DONE " & vbCrLf & _
          "FROM STUDENT_ENROLMENT {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID58","And","ENROLMENT_YEAR59"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record ProfilesPanel Data Provider Class Constructor

'Record ProfilesPanel Data Provider Class LoadParams Method @47-79390024

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID) Or IsNothing(UrlENROLMENT_YEAR))
    End Function
'End Record ProfilesPanel Data Provider Class LoadParams Method

'Record ProfilesPanel Data Provider Class CheckUnique Method @47-70962517

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As ProfilesPanelItem) As Boolean
        Return True
    End Function
'End Record ProfilesPanel Data Provider Class CheckUnique Method

'Record ProfilesPanel Data Provider Class PrepareUpdate Method @47-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record ProfilesPanel Data Provider Class PrepareUpdate Method

'Record ProfilesPanel Data Provider Class PrepareUpdate Method tail @47-E31F8E2A
    End Sub
'End Record ProfilesPanel Data Provider Class PrepareUpdate Method tail

'Record ProfilesPanel Data Provider Class Update Method @47-805CD442

    Public Function UpdateItem(ByVal item As ProfilesPanelItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT_ENROLMENT SET {Values}", New String(){"STUDENT_ID58","And","ENROLMENT_YEAR59"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record ProfilesPanel Data Provider Class Update Method

'Record ProfilesPanel BeforeBuildUpdate @47-4ACA18A3
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID58",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ENROLMENT_YEAR59",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        If Not item.radio_PathwaysProfile.IsEmpty Then
        allEmptyFlag = item.radio_PathwaysProfile.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PATHWAY_PROFILE_DONE=" + Update.Dao.ToSql(item.radio_PathwaysProfile.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.radio_IntakeInterview.IsEmpty Then
        allEmptyFlag = item.radio_IntakeInterview.IsEmpty And allEmptyFlag
        valuesList = valuesList & "INTAKE_INTERVIEW_DONE=" + Update.Dao.ToSql(item.radio_IntakeInterview.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
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
'End Record ProfilesPanel BeforeBuildUpdate

'Record ProfilesPanel AfterExecuteUpdate @47-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record ProfilesPanel AfterExecuteUpdate

'Record ProfilesPanel Data Provider Class GetResultSet Method @47-E9F95351

    Public Sub FillItem(ByVal item As ProfilesPanelItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record ProfilesPanel Data Provider Class GetResultSet Method

'Record ProfilesPanel BeforeBuildSelect @47-56F99F55
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID58",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("ENROLMENT_YEAR59",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record ProfilesPanel BeforeBuildSelect

'Record ProfilesPanel BeforeExecuteSelect @47-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record ProfilesPanel BeforeExecuteSelect

'Record ProfilesPanel AfterExecuteSelect @47-58D91745
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.radio_PathwaysProfile.SetValue(dr(i)("PATHWAY_PROFILE_DONE"),Select_.BoolFormat)
            item.radio_IntakeInterview.SetValue(dr(i)("INTAKE_INTERVIEW_DONE"),Select_.BoolFormat)
        Else
            IsInsertMode = True
        End If
'End Record ProfilesPanel AfterExecuteSelect

'ListBox radio_PathwaysProfile AfterExecuteSelect @48-C23A755D
        
item.radio_PathwaysProfileItems.Add("Yes","Yes")
item.radio_PathwaysProfileItems.Add("No","No")
'End ListBox radio_PathwaysProfile AfterExecuteSelect

'ListBox radio_IntakeInterview AfterExecuteSelect @51-0AFD5555
        
item.radio_IntakeInterviewItems.Add("Yes","Yes")
item.radio_IntakeInterviewItems.Add("No","No")
'End ListBox radio_IntakeInterview AfterExecuteSelect

'Record ProfilesPanel AfterExecuteSelect tail @47-E31F8E2A
    End Sub
'End Record ProfilesPanel AfterExecuteSelect tail

'Record ProfilesPanel Data Provider Class @47-A61BA892
End Class

'End Record ProfilesPanel Data Provider Class

'Grid Grid_DisplayComments_MyComments Item Class @69-A30FD80D
Public Class Grid_DisplayComments_MyCommentsItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public COMMENT As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public COMMENT_TYPE As TextField
    Public link_editcomment As TextField
    Public link_editcommentHref As Object
    Public link_editcommentHrefParameters As LinkParameterCollection
    Public Label_LogType As TextField
    Public Sub New()
    COMMENT = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    COMMENT_TYPE = New TextField("", Nothing)
    link_editcomment = New TextField("",Nothing)
    link_editcommentHrefParameters = New LinkParameterCollection()
    Label_LogType = New TextField("", "All Teacher's")
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "COMMENT"
                    Return Me.COMMENT
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "COMMENT_TYPE"
                    Return Me.COMMENT_TYPE
                Case "link_editcomment"
                    Return Me.link_editcomment
                Case "Label_LogType"
                    Return Me.Label_LogType
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "COMMENT"
                    Me.COMMENT = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "COMMENT_TYPE"
                    Me.COMMENT_TYPE = CType(Value,TextField)
                Case "link_editcomment"
                    Me.link_editcomment = CType(Value,TextField)
                Case "Label_LogType"
                    Me.Label_LogType = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid Grid_DisplayComments_MyComments Item Class

'Grid Grid_DisplayComments_MyComments Data Provider Class Header @69-E1851E26
Public Class Grid_DisplayComments_MyCommentsDataProvider
Inherits GridDataProviderBase
'End Grid Grid_DisplayComments_MyComments Data Provider Class Header

'Grid Grid_DisplayComments_MyComments Data Provider Class Variables @69-AD757834

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 200
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As FloatParameter
'End Grid Grid_DisplayComments_MyComments Data Provider Class Variables

'Grid Grid_DisplayComments_MyComments Data Provider Class GetResultSet Method @69-311750B6

    Public Sub New()
        Select_=new SqlCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_COMMENT" & vbCrLf & _
          "WHERE STUDENT_ID = {STUDENT_ID}" & vbCrLf & _
          "AND ( ACTIVE_STATUS = 'A' )" & vbCrLf & _
          "AND ( COMMENT_TYPE  like 'CONTACT%' )" & vbCrLf & _
          "",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (SELECT * " & vbCrLf & _
          "FROM STUDENT_COMMENT" & vbCrLf & _
          "WHERE STUDENT_ID = {STUDENT_ID}" & vbCrLf & _
          "AND ( ACTIVE_STATUS = 'A' )" & vbCrLf & _
          "AND ( COMMENT_TYPE  like 'CONTACT%' )" & vbCrLf & _
          ") cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid Grid_DisplayComments_MyComments Data Provider Class GetResultSet Method

'Grid Grid_DisplayComments_MyComments Data Provider Class GetResultSet Method @69-BD0AEFEB
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As Grid_DisplayComments_MyCommentsItem()
'End Grid Grid_DisplayComments_MyComments Data Provider Class GetResultSet Method

'Grid Grid_DisplayComments_MyComments Event BeforeBuildSelect. Action Custom Code @87-73254650
    ' -------------------------
 	Dim strStaffIDSelect As String = " AND LAST_ALTERED_BY IN ('noaccess') and 1=2"	' default to no access for teacher
	Dim strTeacherStaffIDList As String = ""

	
    '23-July-2015|EA| convert to global setting incase we need to add a new group in future
	dim strHigherGroups as String = System.Configuration.ConfigurationManager.AppSettings("strHigherSecurityGroups") 
    dim arrHigherGroups as String() = strHigherGroups.split(",")

    '24 Mar 2021|RW| Allow comment access for tutors, who have no explicit allotment against the student
    Dim dbUser = DBUtility.UserId.ToString.ToUpper().Trim()
    If String.IsNullOrEmpty(HttpContext.Current.Session("AccessGroups")) Then
        HttpContext.Current.Session("AccessGroups") = Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("exec sps_GetUserAccessFunctions " & Settings.connDECVPRODSQL2005DataAccessObject.ToSql(dbUser, FieldType._Text, True))
    End If
    Dim accessGroupU = HttpContext.Current.Session("AccessGroups").ToString.Contains("U")

	'If (DBUtility.AuthorizeUser(New String(){"2","3","4","5","6","7","9"})) Then
	 If (DBUtility.AuthorizeUser(arrHigherGroups) OrElse accessGroupU) Then
		'just get the comments 
		strStaffIDSelect = " AND LAST_ALTERED_BY NOT IN ('noaccess')"
	 else
		' get list of Teachers and current user and add to Select
		dim tmpENROLYEAR as string = ""
		tmpENROLYEAR = Convert.ToString(Year(Now()))

		strTeacherStaffIDList = CType((New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("declare @sCsv2 varchar(1000); set @sCsv2 = '';select @sCsv2 = @sCsv2 + T1.email+',' from (select distinct rtrim(staff_id) as email from STUDENT_SUBJECT where ENROLMENT_YEAR = " & tmpENROLYEAR & " and STUDENT_ID = " & UrlSTUDENT_ID.tostring & " and STAFF_ID !='N-A') as T1; select @sCsv2;"))).Value, String)
		' add in Pastoral Care Teacher 
        ' 5 Mar 2021|RW| Add SSG Facilitator to the comma delimited string
        '                Switch to a HashSet for a safer way of checking IDs
        strTeacherStaffIDList += CType((New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("select concat(rtrim(isnull(pastoral_care_id,'')), ',', rtrim(isnull(SSG_FACILITATOR_ID, ''))) from STUDENT_ENROLMENT where ENROLMENT_YEAR = " & tmpENROLYEAR & " and STUDENT_ID = " & UrlSTUDENT_ID.tostring & " "))).Value, String)
        Dim authIDs = strTeacherStaffIDList.ToUpper().Split({","c}, StringSplitOptions.RemoveEmptyEntries).ToHashSet()

		'strTeacherStaffIDList="BGALLOWA,EAFFLECK,MRYAN,NA,NA,"

		' now, only retreive if this teacher is in the list
		
		if (authIDs.Contains(dbUser)) then
				'if the last char is a comma then remove it
				'Dim chArr1() As Char = {" ", ","}
				'strTeacherStaffIDList = strTeacherStaffIDList.TrimEnd(chArr1)
				' and replace all the commas with quote-comma-quote
				'strTeacherStaffIDList = strTeacherStaffIDList.Replace("," , "','")
				
				' retreive only teacher comments
				'strStaffIDSelect = " AND LAST_ALTERED_BY IN ('" & strTeacherStaffIDList & "')"
				
				' if a teacher of the student, then show
				strStaffIDSelect = " AND LAST_ALTERED_BY NOT IN ('noaccess')"
		else
				' only get this user's comments
				strStaffIDSelect = " AND LAST_ALTERED_BY = ('" & DBUtility.UserId.ToString() & "')"
				'strStaffIDSelect = " AND LAST_ALTERED_BY = 'BGALLOWA'"
		end if

     End If
	'strStaffIDSelect = " AND LAST_ALTERED_BY IN ('BGALLOWA','EAFFLECK','MRYAN','NA')"
	strStaffIDSelect += " ORDER BY LAST_ALTERED_DATE desc"
    ' -------------------------
'End Grid Grid_DisplayComments_MyComments Event BeforeBuildSelect. Action Custom Code

'Before build Select @69-29E282D2
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

'Grid Grid_DisplayComments_MyComments Event BeforeExecuteSelect. Action Custom Code @88-73254650
    ' -------------------------
    '7-Mar-2011|EA add the parameter in

	Select_.sqlquery.Append(strStaffIDSelect) 

	Count.Parameters = Select_.Parameters	' set it again for fun
    ' -------------------------
'End Grid Grid_DisplayComments_MyComments Event BeforeExecuteSelect. Action Custom Code



'Execute Select @69-D0193619
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As Grid_DisplayComments_MyCommentsItem
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

'After execute Select @69-BF97ED43
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New Grid_DisplayComments_MyCommentsItem(dr.Count-1) {}
'End After execute Select

'After execute Select @69-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @69-BA85936D
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as Grid_DisplayComments_MyCommentsItem = New Grid_DisplayComments_MyCommentsItem()
                item.COMMENT.SetValue(dr(i)("COMMENT"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.COMMENT_TYPE.SetValue(dr(i)("COMMENT_TYPE"),"")
                item.link_editcommentHref = "Student_Comments_editown.aspx"
                item.link_editcommentHrefParameters.Add("COMMENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("COMMENT_ID").ToString()))
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @69-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

