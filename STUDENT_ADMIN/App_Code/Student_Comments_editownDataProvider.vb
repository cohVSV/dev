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

Namespace DECV_PROD2007.Student_Comments_editown 'Namespace @1-0A43FC7B

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

'Record EditComments Item Class @5-072D43B4
Public Class EditCommentsItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public COMMENT As TextField
    Public hidden_LAST_ALTERED_BY As TextField
    Public hidden_LAST_ALTERED_DATE As DateField
    Public ACTIVE_STATUS As TextField
    Public COMMENT_TYPE As TextField
    Public STUDENT_ID As FloatField
    Public lblSTUDENT_ID As TextField
    Public lblCommentType As TextField
    Public lbSpecialCommentType As TextField
    Public lbSpecialCommentTypeItems As ItemCollection
    Public Sub New()
    COMMENT = New TextField("", Nothing)
    hidden_LAST_ALTERED_BY = New TextField("", "unknown")
    hidden_LAST_ALTERED_DATE = New DateField("yyyy-MM-dd H\:mm", DateTime.Now)
    ACTIVE_STATUS = New TextField("", "A")
    COMMENT_TYPE = New TextField("", "REGULAR")
    STUDENT_ID = New FloatField("", Nothing)
    lblSTUDENT_ID = New TextField("", Nothing)
    lblCommentType = New TextField("", "SPECIAL COMMENT TYPE")
    lbSpecialCommentType = New TextField("", "0")
    lbSpecialCommentTypeItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As EditCommentsItem
        Dim item As EditCommentsItem = New EditCommentsItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COMMENT")) Then
        item.COMMENT.SetValue(DBUtility.GetInitialValue("COMMENT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY")) Then
        item.hidden_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LAST_ALTERED_DATE")) Then
        item.hidden_LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("hidden_LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ACTIVE_STATUS")) Then
        item.ACTIVE_STATUS.SetValue(DBUtility.GetInitialValue("ACTIVE_STATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COMMENT_TYPE")) Then
        item.COMMENT_TYPE.SetValue(DBUtility.GetInitialValue("COMMENT_TYPE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblSTUDENT_ID")) Then
        item.lblSTUDENT_ID.SetValue(DBUtility.GetInitialValue("lblSTUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblCommentType")) Then
        item.lblCommentType.SetValue(DBUtility.GetInitialValue("lblCommentType"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbSpecialCommentType")) Then
        item.lbSpecialCommentType.SetValue(DBUtility.GetInitialValue("lbSpecialCommentType"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "COMMENT"
                    Return COMMENT
                Case "hidden_LAST_ALTERED_BY"
                    Return hidden_LAST_ALTERED_BY
                Case "hidden_LAST_ALTERED_DATE"
                    Return hidden_LAST_ALTERED_DATE
                Case "ACTIVE_STATUS"
                    Return ACTIVE_STATUS
                Case "COMMENT_TYPE"
                    Return COMMENT_TYPE
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "lblSTUDENT_ID"
                    Return lblSTUDENT_ID
                Case "lblCommentType"
                    Return lblCommentType
                Case "lbSpecialCommentType"
                    Return lbSpecialCommentType
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "COMMENT"
                    COMMENT = CType(value, TextField)
                Case "hidden_LAST_ALTERED_BY"
                    hidden_LAST_ALTERED_BY = CType(value, TextField)
                Case "hidden_LAST_ALTERED_DATE"
                    hidden_LAST_ALTERED_DATE = CType(value, DateField)
                Case "ACTIVE_STATUS"
                    ACTIVE_STATUS = CType(value, TextField)
                Case "COMMENT_TYPE"
                    COMMENT_TYPE = CType(value, TextField)
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, FloatField)
                Case "lblSTUDENT_ID"
                    lblSTUDENT_ID = CType(value, TextField)
                Case "lblCommentType"
                    lblCommentType = CType(value, TextField)
                Case "lbSpecialCommentType"
                    lbSpecialCommentType = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As EditCommentsDataProvider)
'End Record EditComments Item Class

'COMMENT validate @11-AF76D6FB
        If IsNothing(COMMENT.Value) OrElse COMMENT.Value.ToString() ="" Then
            errors.Add("COMMENT",String.Format(Resources.strings.CCS_RequiredField,"COMMENT"))
        End If
'End COMMENT validate

'hidden_LAST_ALTERED_BY validate @12-2CCEA0B2
        If IsNothing(hidden_LAST_ALTERED_BY.Value) OrElse hidden_LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("hidden_LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End hidden_LAST_ALTERED_BY validate

'hidden_LAST_ALTERED_DATE validate @13-121294E0
        If IsNothing(hidden_LAST_ALTERED_DATE.Value) OrElse hidden_LAST_ALTERED_DATE.Value.ToString() ="" Then
            errors.Add("hidden_LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED DATE"))
        End If
'End hidden_LAST_ALTERED_DATE validate

'ACTIVE_STATUS validate @14-918FB9D0
        If IsNothing(ACTIVE_STATUS.Value) OrElse ACTIVE_STATUS.Value.ToString() ="" Then
            errors.Add("ACTIVE_STATUS",String.Format(Resources.strings.CCS_RequiredField,"ACTIVE STATUS"))
        End If
'End ACTIVE_STATUS validate

'STUDENT_ID validate @16-6D9CF271
        If IsNothing(STUDENT_ID.Value) OrElse STUDENT_ID.Value.ToString() ="" Then
            errors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_RequiredField,"STUDENT ID"))
        End If
'End STUDENT_ID validate

'lbSpecialCommentType validate @26-056A8F1B
        If IsNothing(lbSpecialCommentType.Value) OrElse lbSpecialCommentType.Value.ToString() ="" Then
            errors.Add("lbSpecialCommentType",String.Format(Resources.strings.CCS_RequiredField,"Special Comment Type"))
        End If
'End lbSpecialCommentType validate

'Record EditComments Item Class tail @5-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record EditComments Item Class tail

'Record EditComments Data Provider Class @5-675B24F1
Public Class EditCommentsDataProvider
Inherits RecordDataProviderBase
'End Record EditComments Data Provider Class

'Record EditComments Data Provider Class Variables @5-8CC79E06
    Public UrlCOMMENT_ID As IntegerParameter
    Public UrlSTUDENT_ID As FloatParameter
    Protected item As EditCommentsItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record EditComments Data Provider Class Variables

'Record EditComments Data Provider Class Constructor @5-BCCFEE1E

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_COMMENT {SQL_Where} {SQL_OrderBy}", New String(){"COMMENT_ID10","And","STUDENT_ID23"},Settings.connDECVPRODSQL2005DataAccessObject )
        Delete=new TableCommand("DELETE FROM STUDENT_COMMENT", New String(){"COMMENT_ID10","And","STUDENT_ID23"},Settings.connDECVPRODSQL2005DataAccessObject , true)
        Select_.OrderBy=""
    End Sub
'End Record EditComments Data Provider Class Constructor

'Record EditComments Data Provider Class LoadParams Method @5-5B95C6C8

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlCOMMENT_ID) Or IsNothing(UrlSTUDENT_ID))
    End Function
'End Record EditComments Data Provider Class LoadParams Method

'Record EditComments Data Provider Class CheckUnique Method @5-2AFDAC9A

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As EditCommentsItem) As Boolean
        Return True
    End Function
'End Record EditComments Data Provider Class CheckUnique Method

'Record EditComments Data Provider Class PrepareUpdate Method @5-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record EditComments Data Provider Class PrepareUpdate Method

'Record EditComments Data Provider Class PrepareUpdate Method tail @5-E31F8E2A
    End Sub
'End Record EditComments Data Provider Class PrepareUpdate Method tail

'Record EditComments Data Provider Class Update Method @5-126954A1

    Public Function UpdateItem(ByVal item As EditCommentsItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT_COMMENT SET {Values}", New String(){"COMMENT_ID10","And","STUDENT_ID23"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record EditComments Data Provider Class Update Method

'Record EditComments BeforeBuildUpdate @5-D02E6866
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("COMMENT_ID10",UrlCOMMENT_ID, "","COMMENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("STUDENT_ID23",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        If Not item.COMMENT.IsEmpty Then
        allEmptyFlag = item.COMMENT.IsEmpty And allEmptyFlag
        valuesList = valuesList & "COMMENT=" + Update.Dao.ToSql(item.COMMENT.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.hidden_LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.hidden_LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.hidden_LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.hidden_LAST_ALTERED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.ACTIVE_STATUS.IsEmpty Then
        allEmptyFlag = item.ACTIVE_STATUS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ACTIVE_STATUS=" + Update.Dao.ToSql(item.ACTIVE_STATUS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.COMMENT_TYPE.IsEmpty Then
        allEmptyFlag = item.COMMENT_TYPE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "COMMENT_TYPE=" + Update.Dao.ToSql(item.COMMENT_TYPE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STUDENT_ID.IsEmpty Then
        allEmptyFlag = item.STUDENT_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STUDENT_ID=" + Update.Dao.ToSql(item.STUDENT_ID.GetFormattedValue(""),FieldType._Float) & ","
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
'End Record EditComments BeforeBuildUpdate

'Record EditComments AfterExecuteUpdate @5-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record EditComments AfterExecuteUpdate

'Record EditComments Data Provider Class PrepareDelete Method @5-F7361E57

    Protected Overrides Sub PrepareDelete()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record EditComments Data Provider Class PrepareDelete Method

'Record EditComments Data Provider Class PrepareDelete Method tail @5-E31F8E2A
    End Sub
'End Record EditComments Data Provider Class PrepareDelete Method tail

'Record EditComments Data Provider Class Delete Method @5-902FB3A8
    Public Function DeleteItem(ByVal item As EditCommentsItem) As Integer
        Me.item = item
'End Record EditComments Data Provider Class Delete Method

'Record EditComments BeforeBuildDelete @5-5B802DA7
        Delete.Parameters.Clear()
        CType(Delete,TableCommand).AddParameter("COMMENT_ID10",UrlCOMMENT_ID, "","COMMENT_ID",Condition.Equal,False)
        CType(Delete,TableCommand).AddParameter("STUDENT_ID23",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        Delete.SqlQuery.Replace("{COMMENT}",Delete.Dao.ToSql(item.COMMENT.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{hidden_LAST_ALTERED_BY}",Delete.Dao.ToSql(item.hidden_LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{hidden_LAST_ALTERED_DATE}",Delete.Dao.ToSql(item.hidden_LAST_ALTERED_DATE.GetFormattedValue(Delete.DateFormat),FieldType._Date))
        Delete.SqlQuery.Replace("{ACTIVE_STATUS}",Delete.Dao.ToSql(item.ACTIVE_STATUS.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{COMMENT_TYPE}",Delete.Dao.ToSql(item.COMMENT_TYPE.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{STUDENT_ID}",Delete.Dao.ToSql(item.STUDENT_ID.GetFormattedValue(""),FieldType._Float))
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
'End Record EditComments BeforeBuildDelete

'Record EditComments BeforeBuildDelete @5-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record EditComments BeforeBuildDelete

'Record EditComments Data Provider Class GetResultSet Method @5-135E9C44

    Public Sub FillItem(ByVal item As EditCommentsItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record EditComments Data Provider Class GetResultSet Method

'Record EditComments BeforeBuildSelect @5-1ED82408
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("COMMENT_ID10",UrlCOMMENT_ID, "","COMMENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("STUDENT_ID23",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record EditComments BeforeBuildSelect

'Record EditComments BeforeExecuteSelect @5-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record EditComments BeforeExecuteSelect

'Record EditComments AfterExecuteSelect @5-CD579E23
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.COMMENT.SetValue(dr(i)("COMMENT"),"")
            item.hidden_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.hidden_LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.ACTIVE_STATUS.SetValue(dr(i)("ACTIVE_STATUS"),"")
            item.COMMENT_TYPE.SetValue(dr(i)("COMMENT_TYPE"),"")
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.lblSTUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
        Else
            IsInsertMode = True
        End If
'End Record EditComments AfterExecuteSelect

'ListBox lbSpecialCommentType AfterExecuteSelect @26-6B06ABEB
        
item.lbSpecialCommentTypeItems.Add("0","No change to comment type")
item.lbSpecialCommentTypeItems.Add("REGULAR","Remove Alert/ Make Regular comment")
item.lbSpecialCommentTypeItems.Add("ALERT","Alert - general alert")
item.lbSpecialCommentTypeItems.Add("RESTRICTED","Restricted Access / Court Order")
item.lbSpecialCommentTypeItems.Add("WELLBEING","Wellbeing Comment")
'End ListBox lbSpecialCommentType AfterExecuteSelect

'Record EditComments AfterExecuteSelect tail @5-E31F8E2A
    End Sub
'End Record EditComments AfterExecuteSelect tail

'Record EditComments Data Provider Class @5-A61BA892
End Class

'End Record EditComments Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

