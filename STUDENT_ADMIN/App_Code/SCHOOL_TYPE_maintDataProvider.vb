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

Namespace DECV_PROD2007.SCHOOL_TYPE_maint 'Namespace @1-EB2F49B1

'Page Data Class @1-1CA1EF9E
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public Sub New()
        Link1 = New TextField("",Nothing)
        Link1HrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Link1.SetValue(DBUtility.GetInitialValue("Link1"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Link1"
                    Return Link1
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link1"
                    Link1 = CType(value, TextField)
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

'Record SCHOOL_TYPE Item Class @2-5C633893
Public Class SCHOOL_TYPEItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public SCHOOL_TYPE_DESCRIPTION As TextField
    Public lbl_SchoolTypeCode As TextField
    Public SCHOOL_TYPE_CODE As TextField
    Public lbl_LAST_ALTERED_BY As TextField
    Public lbl_LAST_ALTERED_DATE As DateField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    SCHOOL_TYPE_DESCRIPTION = New TextField("", Nothing)
    lbl_SchoolTypeCode = New TextField("", Nothing)
    SCHOOL_TYPE_CODE = New TextField("", Nothing)
    lbl_LAST_ALTERED_BY = New TextField("", DBUtility.UserId.ToString())
    lbl_LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    LAST_ALTERED_BY = New TextField("", DBUtility.UserId.ToString())
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    End Sub

    Public Shared Function CreateFromHttpRequest() As SCHOOL_TYPEItem
        Dim item As SCHOOL_TYPEItem = New SCHOOL_TYPEItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SCHOOL_TYPE_DESCRIPTION")) Then
        item.SCHOOL_TYPE_DESCRIPTION.SetValue(DBUtility.GetInitialValue("SCHOOL_TYPE_DESCRIPTION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbl_SchoolTypeCode")) Then
        item.lbl_SchoolTypeCode.SetValue(DBUtility.GetInitialValue("lbl_SchoolTypeCode"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SCHOOL_TYPE_CODE")) Then
        item.SCHOOL_TYPE_CODE.SetValue(DBUtility.GetInitialValue("SCHOOL_TYPE_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbl_LAST_ALTERED_BY")) Then
        item.lbl_LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("lbl_LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbl_LAST_ALTERED_DATE")) Then
        item.lbl_LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("lbl_LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "SCHOOL_TYPE_DESCRIPTION"
                    Return SCHOOL_TYPE_DESCRIPTION
                Case "lbl_SchoolTypeCode"
                    Return lbl_SchoolTypeCode
                Case "SCHOOL_TYPE_CODE"
                    Return SCHOOL_TYPE_CODE
                Case "lbl_LAST_ALTERED_BY"
                    Return lbl_LAST_ALTERED_BY
                Case "lbl_LAST_ALTERED_DATE"
                    Return lbl_LAST_ALTERED_DATE
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SCHOOL_TYPE_DESCRIPTION"
                    SCHOOL_TYPE_DESCRIPTION = CType(value, TextField)
                Case "lbl_SchoolTypeCode"
                    lbl_SchoolTypeCode = CType(value, TextField)
                Case "SCHOOL_TYPE_CODE"
                    SCHOOL_TYPE_CODE = CType(value, TextField)
                Case "lbl_LAST_ALTERED_BY"
                    lbl_LAST_ALTERED_BY = CType(value, TextField)
                Case "lbl_LAST_ALTERED_DATE"
                    lbl_LAST_ALTERED_DATE = CType(value, DateField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
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

    Public Sub Validate(ByVal provider As SCHOOL_TYPEDataProvider)
'End Record SCHOOL_TYPE Item Class

'SCHOOL_TYPE_DESCRIPTION validate @7-714137A9
        If IsNothing(SCHOOL_TYPE_DESCRIPTION.Value) OrElse SCHOOL_TYPE_DESCRIPTION.Value.ToString() ="" Then
            errors.Add("SCHOOL_TYPE_DESCRIPTION",String.Format(Resources.strings.CCS_RequiredField,"DESCRIPTION"))
        End If
'End SCHOOL_TYPE_DESCRIPTION validate

'SCHOOL_TYPE_CODE validate @15-6FAE77E7
        If IsNothing(SCHOOL_TYPE_CODE.Value) OrElse SCHOOL_TYPE_CODE.Value.ToString() ="" Then
            errors.Add("SCHOOL_TYPE_CODE",String.Format(Resources.strings.CCS_RequiredField,"Type Code"))
        End If
        If (Not IsNothing(SCHOOL_TYPE_CODE)) And (Not provider.CheckUnique("SCHOOL_TYPE_CODE",Me)) Then
                errors.Add("SCHOOL_TYPE_CODE", String.Format(Resources.strings.CCS_UniqueValue,"Type Code"))
        End If
'End SCHOOL_TYPE_CODE validate

'LAST_ALTERED_BY validate @8-256A6854
        If IsNothing(LAST_ALTERED_BY.Value) OrElse LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End LAST_ALTERED_BY validate

'LAST_ALTERED_DATE validate @9-C5989D76
        If IsNothing(LAST_ALTERED_DATE.Value) OrElse LAST_ALTERED_DATE.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED DATE"))
        End If
'End LAST_ALTERED_DATE validate

'Record SCHOOL_TYPE Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record SCHOOL_TYPE Item Class tail

'Record SCHOOL_TYPE Data Provider Class @2-C74A2C69
Public Class SCHOOL_TYPEDataProvider
Inherits RecordDataProviderBase
'End Record SCHOOL_TYPE Data Provider Class

'Record SCHOOL_TYPE Data Provider Class Variables @2-74FF1E74
    Public UrlSCHOOL_TYPE_CODE As TextParameter
    Protected item As SCHOOL_TYPEItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record SCHOOL_TYPE Data Provider Class Variables

'Record SCHOOL_TYPE Data Provider Class Constructor @2-8AB77E28

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM SCHOOL_TYPE {SQL_Where} {SQL_OrderBy}", New String(){"SCHOOL_TYPE_CODE6"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record SCHOOL_TYPE Data Provider Class Constructor

'Record SCHOOL_TYPE Data Provider Class LoadParams Method @2-D70D160A

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSCHOOL_TYPE_CODE))
    End Function
'End Record SCHOOL_TYPE Data Provider Class LoadParams Method

'Record SCHOOL_TYPE Data Provider Class CheckUnique Method @2-85C2A249

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As SCHOOL_TYPEItem) As Boolean
        Dim Check As TableCommand = New TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM SCHOOL_TYPE",New String(){"SCHOOL_TYPE_CODE6"},Settings.connDECVPRODSQL2005DataAccessObject)
        Dim CheckWhere As String = ""
        Select Case ControlName
        End Select
        Check.Where = CheckWhere
        Check.Operation = "AND NOT"
        Check.Parameters.Clear()
        CType(Check,TableCommand).AddParameter("SCHOOL_TYPE_CODE6",UrlSCHOOL_TYPE_CODE, "","SCHOOL_TYPE_CODE",Condition.Equal,False)
        If Convert.ToInt32(Check.ExecuteScalar()) > 0 Then
            Return False
        End If
        Return True
    End Function
'End Record SCHOOL_TYPE Data Provider Class CheckUnique Method

'Record SCHOOL_TYPE Data Provider Class PrepareInsert Method @2-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record SCHOOL_TYPE Data Provider Class PrepareInsert Method

'Record SCHOOL_TYPE Data Provider Class PrepareInsert Method tail @2-E31F8E2A
    End Sub
'End Record SCHOOL_TYPE Data Provider Class PrepareInsert Method tail

'Record SCHOOL_TYPE Data Provider Class Insert Method @2-92E08544

    Public Function InsertItem(ByVal item As SCHOOL_TYPEItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO SCHOOL_TYPE({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record SCHOOL_TYPE Data Provider Class Insert Method

'Record SCHOOL_TYPE Build insert @2-6CC1F8FB
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.SCHOOL_TYPE_DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.SCHOOL_TYPE_DESCRIPTION.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SCHOOL_TYPE_DESCRIPTION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SCHOOL_TYPE_DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SCHOOL_TYPE_CODE.IsEmpty Then
        allEmptyFlag = item.SCHOOL_TYPE_CODE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SCHOOL_TYPE_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SCHOOL_TYPE_CODE.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record SCHOOL_TYPE Build insert

'Record SCHOOL_TYPE AfterExecuteInsert @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record SCHOOL_TYPE AfterExecuteInsert

'Record SCHOOL_TYPE Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record SCHOOL_TYPE Data Provider Class PrepareUpdate Method

'Record SCHOOL_TYPE Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record SCHOOL_TYPE Data Provider Class PrepareUpdate Method tail

'Record SCHOOL_TYPE Data Provider Class Update Method @2-BF0E9DA5

    Public Function UpdateItem(ByVal item As SCHOOL_TYPEItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE SCHOOL_TYPE SET {Values}", New String(){"SCHOOL_TYPE_CODE6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record SCHOOL_TYPE Data Provider Class Update Method

'Record SCHOOL_TYPE BeforeBuildUpdate @2-6BA5A595
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("SCHOOL_TYPE_CODE6",UrlSCHOOL_TYPE_CODE, "","SCHOOL_TYPE_CODE",Condition.Equal,False)
        If Not item.SCHOOL_TYPE_DESCRIPTION.IsEmpty Then
        allEmptyFlag = item.SCHOOL_TYPE_DESCRIPTION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SCHOOL_TYPE_DESCRIPTION=" + Update.Dao.ToSql(item.SCHOOL_TYPE_DESCRIPTION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SCHOOL_TYPE_CODE.IsEmpty Then
        allEmptyFlag = item.SCHOOL_TYPE_CODE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SCHOOL_TYPE_CODE=" + Update.Dao.ToSql(item.SCHOOL_TYPE_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
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
'End Record SCHOOL_TYPE BeforeBuildUpdate

'Record SCHOOL_TYPE AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record SCHOOL_TYPE AfterExecuteUpdate

'Record SCHOOL_TYPE Data Provider Class GetResultSet Method @2-8DC30324

    Public Sub FillItem(ByVal item As SCHOOL_TYPEItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record SCHOOL_TYPE Data Provider Class GetResultSet Method

'Record SCHOOL_TYPE BeforeBuildSelect @2-7D16686B
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("SCHOOL_TYPE_CODE6",UrlSCHOOL_TYPE_CODE, "","SCHOOL_TYPE_CODE",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record SCHOOL_TYPE BeforeBuildSelect

'Record SCHOOL_TYPE BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record SCHOOL_TYPE BeforeExecuteSelect

'Record SCHOOL_TYPE AfterExecuteSelect @2-7374EF04
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.SCHOOL_TYPE_DESCRIPTION.SetValue(dr(i)("SCHOOL_TYPE_DESCRIPTION"),"")
            item.lbl_SchoolTypeCode.SetValue(dr(i)("SCHOOL_TYPE_CODE"),"")
            item.SCHOOL_TYPE_CODE.SetValue(dr(i)("SCHOOL_TYPE_CODE"),"")
            item.lbl_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.lbl_LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
'End Record SCHOOL_TYPE AfterExecuteSelect

'Record SCHOOL_TYPE AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record SCHOOL_TYPE AfterExecuteSelect tail

'Record SCHOOL_TYPE Data Provider Class @2-A61BA892
End Class

'End Record SCHOOL_TYPE Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

