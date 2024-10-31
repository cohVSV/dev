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

'Record QuickEnterForm Item Class @4-D9FFF9A2
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
    Public LAST_ALTERED_DATE As DateField
    Public text_Who As TextField
    Public Sub New()
    COMMENT_TYPE = New TextField("", Nothing)
    COMMENT_TYPEItems = New ItemCollection()
    COMMENT = New TextField("", Nothing)
    STUDENT_ID = New FloatField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    text_Who = New TextField("", Nothing)
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
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("text_Who")) Then
        item.text_Who.SetValue(DBUtility.GetInitialValue("text_Who"))
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
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "text_Who"
                    Return text_Who
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
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "text_Who"
                    text_Who = CType(value, TextField)
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

'COMMENT validate @9-AF76D6FB
        If IsNothing(COMMENT.Value) OrElse COMMENT.Value.ToString() ="" Then
            errors.Add("COMMENT",String.Format(Resources.strings.CCS_RequiredField,"COMMENT"))
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

'LAST_ALTERED_DATE validate @12-C5989D76
        If IsNothing(LAST_ALTERED_DATE.Value) OrElse LAST_ALTERED_DATE.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED DATE"))
        End If
'End LAST_ALTERED_DATE validate

'text_Who validate @14-7FE13663
        If IsNothing(text_Who.Value) OrElse text_Who.Value.ToString() ="" Then
            errors.Add("text_Who",String.Format(Resources.strings.CCS_RequiredField,"text_Who"))
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

'Record QuickEnterForm Data Provider Class Variables @4-61EB96A2
    Public UrlCOMMENT_ID As IntegerParameter
    Protected item As QuickEnterFormItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record QuickEnterForm Data Provider Class Variables

'Record QuickEnterForm Data Provider Class Constructor @4-54AE00DC

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_COMMENT {SQL_Where} {SQL_OrderBy}", New String(){"COMMENT_ID7"},Settings.connDECVPRODSQL2005DataAccessObject )
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

'Record QuickEnterForm Data Provider Class Insert Method @4-02866F3A

    Public Function InsertItem(ByVal item As QuickEnterFormItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO STUDENT_COMMENT({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record QuickEnterForm Data Provider Class Insert Method

'Record QuickEnterForm Build insert @4-79AC6CF0
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.COMMENT_TYPE.IsEmpty Then
        allEmptyFlag = item.COMMENT_TYPE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "COMMENT_TYPE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.COMMENT_TYPE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.COMMENT.IsEmpty Then
        allEmptyFlag = item.COMMENT.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "COMMENT,"
        valuesList = valuesList & Insert.Dao.ToSql(item.COMMENT.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STUDENT_ID.IsEmpty Then
        allEmptyFlag = item.STUDENT_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STUDENT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STUDENT_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
		Insert.SqlQuery.Replace("{Fields}", fieldsList.TrimEnd(","C))
		Insert.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
             If Not allEmptyFlag Then result = ExecuteInsert()
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

'Record QuickEnterForm AfterExecuteSelect @4-57619E88
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
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
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

