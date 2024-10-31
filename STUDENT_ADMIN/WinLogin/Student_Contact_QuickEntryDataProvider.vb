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

Namespace DECV_PROD2007.Student_Contact_QuickEntry 'Namespace @1-0C3A9BF8

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

'Record QuickEnterForm Item Class @4-ABA04D29
Public Class QuickEnterFormItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public COMMENT_TYPE As TextField
    Public COMMENT_TYPEItems As ItemCollection
    Public COMMENT As TextField
    Public STUDENT_ID As FloatField
    Public LAST_ALTERED_BY As TextField
    Public text_Who As TextField
    Public Label1 As TextField
    Public Hidden_STAFFID As TextField
    Public Sub New()
    COMMENT_TYPE = New TextField("", Nothing)
    COMMENT_TYPEItems = New ItemCollection()
    COMMENT = New TextField("", Nothing)
    STUDENT_ID = New FloatField("", Nothing)
    LAST_ALTERED_BY = New TextField("", "eaffleck")
    text_Who = New TextField("", Nothing)
    Label1 = New TextField("", "unknown")
    Hidden_STAFFID = New TextField("", "unknown")
    End Sub

    Public Shared Function CreateFromHttpRequest() As QuickEnterFormItem
        Dim item As QuickEnterFormItem = New QuickEnterFormItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COMMENT_TYPE")) Then
        item.COMMENT_TYPE.SetValue(DBUtility.GetInitialValue("COMMENT_TYPE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COMMENT")) Then
        item.COMMENT.SetValue(DBUtility.GetInitialValue("COMMENT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("text_Who")) Then
        item.text_Who.SetValue(DBUtility.GetInitialValue("text_Who"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Label1")) Then
        item.Label1.SetValue(DBUtility.GetInitialValue("Label1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_STAFFID")) Then
        item.Hidden_STAFFID.SetValue(DBUtility.GetInitialValue("Hidden_STAFFID"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "COMMENT_TYPE"
                    Return COMMENT_TYPE
                Case "COMMENT"
                    Return COMMENT
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "text_Who"
                    Return text_Who
                Case "Label1"
                    Return Label1
                Case "Hidden_STAFFID"
                    Return Hidden_STAFFID
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "COMMENT_TYPE"
                    COMMENT_TYPE = CType(value, TextField)
                Case "COMMENT"
                    COMMENT = CType(value, TextField)
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, FloatField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "text_Who"
                    text_Who = CType(value, TextField)
                Case "Label1"
                    Label1 = CType(value, TextField)
                Case "Hidden_STAFFID"
                    Hidden_STAFFID = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As QuickEnterFormDataProvider)
'End Record QuickEnterForm Item Class

'COMMENT_TYPE validate @8-A301C60B
        If IsNothing(COMMENT_TYPE.Value) OrElse COMMENT_TYPE.Value.ToString() ="" Then
            errors.Add("COMMENT_TYPE",String.Format(Resources.strings.CCS_RequiredField,"HOW?"))
        End If
'End COMMENT_TYPE validate

'COMMENT validate @9-07E9DCA2
        If IsNothing(COMMENT.Value) OrElse COMMENT.Value.ToString() ="" Then
            errors.Add("COMMENT",String.Format(Resources.strings.CCS_RequiredField,"WHY?"))
        End If
'End COMMENT validate

'STUDENT_ID validate @10-6D9CF271
        If IsNothing(STUDENT_ID.Value) OrElse STUDENT_ID.Value.ToString() ="" Then
            errors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_RequiredField,"STUDENT ID"))
        End If
'End STUDENT_ID validate

'LAST_ALTERED_BY validate @11-256A6854
        If IsNothing(LAST_ALTERED_BY.Value) OrElse LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End LAST_ALTERED_BY validate

'text_Who validate @14-C367C2EF
        If IsNothing(text_Who.Value) OrElse text_Who.Value.ToString() ="" Then
            errors.Add("text_Who",String.Format(Resources.strings.CCS_RequiredField,"WHO?"))
        End If
'End text_Who validate

'Record QuickEnterForm Item Class tail @4-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record QuickEnterForm Item Class tail

'Record QuickEnterForm Data Provider Class @4-8389A858
Public Class QuickEnterFormDataProvider
Inherits RecordDataProviderBase
'End Record QuickEnterForm Data Provider Class

'Record QuickEnterForm Data Provider Class Variables @4-97AF1947
    Public UrlCOMMENT_ID As IntegerParameter
    Public CtrlCOMMENT As TextParameter
    Public CtrlSTUDENT_ID As TextParameter
    Public CtrlLAST_ALTERED_BY As TextParameter
    Public CtrlCOMMENT_TYPE As TextParameter
    Protected item As QuickEnterFormItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record QuickEnterForm Data Provider Class Variables

'Record QuickEnterForm Data Provider Class Constructor @4-81E0542F

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_COMMENT {SQL_Where} {SQL_OrderBy}", New String(){"COMMENT_ID7"},Settings.connDECVPRODSQL2005DataAccessObject )
        Insert=new SqlCommand("insert into STUDENT_COMMENT ([COMMENT_ID],[STUDENT_ID],[COMMENT],[LAST_ALTERED_BY],[LAST_A" & _
          "LTERED_DATE],[ACTIVE_STATUS],[COMMENT_TYPE]) " & vbCrLf & _
          "select (select (max(COMMENT_ID+1)) from STUDENT_COMMENT) , {STUDENT_ID},'{COMMENT}',UPPER(" & _
          "'{LAST_ALTERED_BY}'), getdate(),'A','{COMMENT_TYPE}'",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record QuickEnterForm Data Provider Class Constructor

'Record QuickEnterForm Data Provider Class LoadParams Method @4-176311CA

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlCOMMENT_ID))
    End Function
'End Record QuickEnterForm Data Provider Class LoadParams Method

'Record QuickEnterForm Data Provider Class CheckUnique Method @4-A4C2A881

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As QuickEnterFormItem) As Boolean
        Return True
    End Function
'End Record QuickEnterForm Data Provider Class CheckUnique Method

'Record QuickEnterForm Data Provider Class PrepareInsert Method @4-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record QuickEnterForm Data Provider Class PrepareInsert Method

'Record QuickEnterForm Data Provider Class PrepareInsert Method tail @4-E31F8E2A
    End Sub
'End Record QuickEnterForm Data Provider Class PrepareInsert Method tail

'Record QuickEnterForm Data Provider Class Insert Method @4-BB8B8397

    Public Function InsertItem(ByVal item As QuickEnterFormItem) As Integer
        Me.item = item
'End Record QuickEnterForm Data Provider Class Insert Method

'Record QuickEnterForm Build insert @4-9512C7CA
        Insert.Parameters.Clear()
        CType(Insert,SqlCommand).AddParameter("COMMENT",item.COMMENT, "")
        CType(Insert,SqlCommand).AddParameter("STUDENT_ID",item.STUDENT_ID, "")
        CType(Insert,SqlCommand).AddParameter("LAST_ALTERED_BY",item.LAST_ALTERED_BY, "")
        CType(Insert,SqlCommand).AddParameter("COMMENT_TYPE",item.COMMENT_TYPE, "")
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
            result = ExecuteInsert()
        Catch ee As Exception
            E = ee
        Finally
'End Record QuickEnterForm Build insert

'Record QuickEnterForm AfterExecuteInsert @4-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record QuickEnterForm AfterExecuteInsert

'Record QuickEnterForm Data Provider Class GetResultSet Method @4-FF17888F

    Public Sub FillItem(ByVal item As QuickEnterFormItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record QuickEnterForm Data Provider Class GetResultSet Method

'Record QuickEnterForm BeforeBuildSelect @4-7FE1FF32
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("COMMENT_ID7",UrlCOMMENT_ID, "","COMMENT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record QuickEnterForm BeforeBuildSelect

'Record QuickEnterForm BeforeExecuteSelect @4-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record QuickEnterForm BeforeExecuteSelect

'Record QuickEnterForm AfterExecuteSelect @4-5BD552D8
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.COMMENT_TYPE.SetValue(dr(i)("COMMENT_TYPE"),"")
            item.COMMENT.SetValue(dr(i)("COMMENT"),"")
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
        Else
            IsInsertMode = True
        End If
'End Record QuickEnterForm AfterExecuteSelect

'ListBox COMMENT_TYPE AfterExecuteSelect @8-409B1BBE
        
item.COMMENT_TYPEItems.Add("CONTACT_PHONE","<b>T</b>elephone")
item.COMMENT_TYPEItems.Add("CONTACT_EMAIL","<b>E</b>mail")
item.COMMENT_TYPEItems.Add("CONTACT_POST","<b>P</b>aper/Post")
item.COMMENT_TYPEItems.Add("CONTACT_VISIT","<b>V</b>isit to/by Student")
'End ListBox COMMENT_TYPE AfterExecuteSelect

'Record QuickEnterForm AfterExecuteSelect tail @4-E31F8E2A
    End Sub
'End Record QuickEnterForm AfterExecuteSelect tail

'Record QuickEnterForm Data Provider Class @4-A61BA892
End Class

'End Record QuickEnterForm Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

