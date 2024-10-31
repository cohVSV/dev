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

Namespace DECV_PROD2007.ENROLMENT_CATEG_maint 'Namespace @1-9FDAD2BE

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

'Record ENROLMENT_CATEGORY Item Class @2-040E89D7
Public Class ENROLMENT_CATEGORYItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public CATEGORY_CODE As TextField
    Public SUBCATEGORY_FULL_TITLE As TextField
    Public STATUS As BooleanField
    Public STATUSCheckedValue As BooleanField
    Public STATUSUncheckedValue As BooleanField
    Public SUBCATEGORY_CODE As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public lblLAST_ALTERED_BY As TextField
    Public lblLAST_ALTERED_DATE As DateField
    Public Sub New()
    CATEGORY_CODE = New TextField("", Nothing)
    SUBCATEGORY_FULL_TITLE = New TextField("", Nothing)
    STATUS = New BooleanField(Settings.BoolFormat, False)
    STATUSCheckedValue = New BooleanField(Settings.BoolFormat, True)
    STATUSUncheckedValue = New BooleanField(Settings.BoolFormat, False)
    SUBCATEGORY_CODE = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", DBUtility.UserId.ToUpper())
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    lblLAST_ALTERED_BY = New TextField("", DBUtility.UserId.ToUpper())
    lblLAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    End Sub

    Public Shared Function CreateFromHttpRequest() As ENROLMENT_CATEGORYItem
        Dim item As ENROLMENT_CATEGORYItem = New ENROLMENT_CATEGORYItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CATEGORY_CODE")) Then
        item.CATEGORY_CODE.SetValue(DBUtility.GetInitialValue("CATEGORY_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUBCATEGORY_FULL_TITLE")) Then
        item.SUBCATEGORY_FULL_TITLE.SetValue(DBUtility.GetInitialValue("SUBCATEGORY_FULL_TITLE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STATUS")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("STATUS")) Then
            item.STATUS.Value = item.STATUSCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUBCATEGORY_CODE")) Then
        item.SUBCATEGORY_CODE.SetValue(DBUtility.GetInitialValue("SUBCATEGORY_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblLAST_ALTERED_BY")) Then
        item.lblLAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("lblLAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblLAST_ALTERED_DATE")) Then
        item.lblLAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("lblLAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "CATEGORY_CODE"
                    Return CATEGORY_CODE
                Case "SUBCATEGORY_FULL_TITLE"
                    Return SUBCATEGORY_FULL_TITLE
                Case "STATUS"
                    Return STATUS
                Case "SUBCATEGORY_CODE"
                    Return SUBCATEGORY_CODE
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "lblLAST_ALTERED_BY"
                    Return lblLAST_ALTERED_BY
                Case "lblLAST_ALTERED_DATE"
                    Return lblLAST_ALTERED_DATE
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "CATEGORY_CODE"
                    CATEGORY_CODE = CType(value, TextField)
                Case "SUBCATEGORY_FULL_TITLE"
                    SUBCATEGORY_FULL_TITLE = CType(value, TextField)
                Case "STATUS"
                    STATUS = CType(value, BooleanField)
                Case "SUBCATEGORY_CODE"
                    SUBCATEGORY_CODE = CType(value, TextField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "lblLAST_ALTERED_BY"
                    lblLAST_ALTERED_BY = CType(value, TextField)
                Case "lblLAST_ALTERED_DATE"
                    lblLAST_ALTERED_DATE = CType(value, DateField)
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

    Public Sub Validate(ByVal provider As ENROLMENT_CATEGORYDataProvider)
'End Record ENROLMENT_CATEGORY Item Class

'CATEGORY_CODE validate @7-73AA61E2
        If IsNothing(CATEGORY_CODE.Value) OrElse CATEGORY_CODE.Value.ToString() ="" Then
            errors.Add("CATEGORY_CODE",String.Format(Resources.strings.CCS_RequiredField,"CATEGORY CODE"))
        End If
'End CATEGORY_CODE validate

'SUBCATEGORY_FULL_TITLE validate @8-BAEDF7B0
        If IsNothing(SUBCATEGORY_FULL_TITLE.Value) OrElse SUBCATEGORY_FULL_TITLE.Value.ToString() ="" Then
            errors.Add("SUBCATEGORY_FULL_TITLE",String.Format(Resources.strings.CCS_RequiredField,"SUBCATEGORY FULL TITLE"))
        End If
'End SUBCATEGORY_FULL_TITLE validate

'STATUS validate @9-73C7378E
        If IsNothing(STATUS.Value) OrElse STATUS.Value.ToString() ="" Then
            errors.Add("STATUS",String.Format(Resources.strings.CCS_RequiredField,"STATUS"))
        End If
'End STATUS validate

'SUBCATEGORY_CODE validate @14-B3C76F7B
        If IsNothing(SUBCATEGORY_CODE.Value) OrElse SUBCATEGORY_CODE.Value.ToString() ="" Then
            errors.Add("SUBCATEGORY_CODE",String.Format(Resources.strings.CCS_RequiredField,"SUBCATEGORY CODE"))
        End If
        If (Not IsNothing(SUBCATEGORY_CODE)) And (Not provider.CheckUnique("SUBCATEGORY_CODE",Me)) Then
                errors.Add("SUBCATEGORY_CODE", String.Format(Resources.strings.CCS_UniqueValue,"SUBCATEGORY CODE"))
        End If
'End SUBCATEGORY_CODE validate

'LAST_ALTERED_BY validate @10-256A6854
        If IsNothing(LAST_ALTERED_BY.Value) OrElse LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End LAST_ALTERED_BY validate

'LAST_ALTERED_DATE validate @11-C5989D76
        If IsNothing(LAST_ALTERED_DATE.Value) OrElse LAST_ALTERED_DATE.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED DATE"))
        End If
'End LAST_ALTERED_DATE validate

'Record ENROLMENT_CATEGORY Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record ENROLMENT_CATEGORY Item Class tail

'Record ENROLMENT_CATEGORY Data Provider Class @2-C1A9D3A1
Public Class ENROLMENT_CATEGORYDataProvider
Inherits RecordDataProviderBase
'End Record ENROLMENT_CATEGORY Data Provider Class

'Record ENROLMENT_CATEGORY Data Provider Class Variables @2-6E8A0312
    Public UrlSUBCATEGORY_CODE As TextParameter
    Public UrlCATEGORY_CODE As TextParameter
    Protected item As ENROLMENT_CATEGORYItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record ENROLMENT_CATEGORY Data Provider Class Variables

'Record ENROLMENT_CATEGORY Data Provider Class Constructor @2-40054575

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM ENROLMENT_CATEGORY {SQL_Where} {SQL_OrderBy}", New String(){"SUBCATEGORY_CODE6","And","CATEGORY_CODE27"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record ENROLMENT_CATEGORY Data Provider Class Constructor

'Record ENROLMENT_CATEGORY Data Provider Class LoadParams Method @2-BB6EDEDE

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSUBCATEGORY_CODE) Or IsNothing(UrlCATEGORY_CODE))
    End Function
'End Record ENROLMENT_CATEGORY Data Provider Class LoadParams Method

'Record ENROLMENT_CATEGORY Data Provider Class CheckUnique Method @2-192B3A6C

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As ENROLMENT_CATEGORYItem) As Boolean
        Dim Check As TableCommand = New TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM ENROLMENT_CATEGORY",New String(){"SUBCATEGORY_CODE6","And","CATEGORY_CODE27"},Settings.connDECVPRODSQL2005DataAccessObject)
        Dim CheckWhere As String = ""
        Select Case ControlName
        Case "SUBCATEGORY_CODE"
            CheckWhere = "SUBCATEGORY_CODE=" & Check.Dao.ToSql(item.SUBCATEGORY_CODE.GetFormattedValue(""),FieldType._Text)
        End Select
        Check.Where = CheckWhere
        Check.Operation = "AND NOT"
        Check.Parameters.Clear()
        CType(Check,TableCommand).AddParameter("SUBCATEGORY_CODE6",UrlSUBCATEGORY_CODE, "","SUBCATEGORY_CODE",Condition.Equal,False)
        CType(Check,TableCommand).AddParameter("CATEGORY_CODE27",UrlCATEGORY_CODE, "","CATEGORY_CODE",Condition.Equal,False)
        If Convert.ToInt32(Check.ExecuteScalar()) > 0 Then
            Return False
        End If
        Return True
    End Function
'End Record ENROLMENT_CATEGORY Data Provider Class CheckUnique Method

'Record ENROLMENT_CATEGORY Data Provider Class PrepareInsert Method @2-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record ENROLMENT_CATEGORY Data Provider Class PrepareInsert Method

'Record ENROLMENT_CATEGORY Data Provider Class PrepareInsert Method tail @2-E31F8E2A
    End Sub
'End Record ENROLMENT_CATEGORY Data Provider Class PrepareInsert Method tail

'Record ENROLMENT_CATEGORY Data Provider Class Insert Method @2-06F0D0F2

    Public Function InsertItem(ByVal item As ENROLMENT_CATEGORYItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO ENROLMENT_CATEGORY({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record ENROLMENT_CATEGORY Data Provider Class Insert Method

'Record ENROLMENT_CATEGORY Build insert @2-B3D2FE63
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.CATEGORY_CODE.IsEmpty Then
        allEmptyFlag = item.CATEGORY_CODE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CATEGORY_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CATEGORY_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUBCATEGORY_FULL_TITLE.IsEmpty Then
        allEmptyFlag = item.SUBCATEGORY_FULL_TITLE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUBCATEGORY_FULL_TITLE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUBCATEGORY_FULL_TITLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STATUS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STATUS.GetFormattedValue(Insert.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.SUBCATEGORY_CODE.IsEmpty Then
        allEmptyFlag = item.SUBCATEGORY_CODE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUBCATEGORY_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUBCATEGORY_CODE.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record ENROLMENT_CATEGORY Build insert

'Record ENROLMENT_CATEGORY AfterExecuteInsert @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record ENROLMENT_CATEGORY AfterExecuteInsert

'Record ENROLMENT_CATEGORY Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record ENROLMENT_CATEGORY Data Provider Class PrepareUpdate Method

'Record ENROLMENT_CATEGORY Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record ENROLMENT_CATEGORY Data Provider Class PrepareUpdate Method tail

'Record ENROLMENT_CATEGORY Data Provider Class Update Method @2-599380D9

    Public Function UpdateItem(ByVal item As ENROLMENT_CATEGORYItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE ENROLMENT_CATEGORY SET {Values}", New String(){"SUBCATEGORY_CODE6","And","CATEGORY_CODE27"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record ENROLMENT_CATEGORY Data Provider Class Update Method

'Record ENROLMENT_CATEGORY BeforeBuildUpdate @2-977165FE
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("SUBCATEGORY_CODE6",UrlSUBCATEGORY_CODE, "","SUBCATEGORY_CODE",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("CATEGORY_CODE27",UrlCATEGORY_CODE, "","CATEGORY_CODE",Condition.Equal,False)
        If Not item.CATEGORY_CODE.IsEmpty Then
        allEmptyFlag = item.CATEGORY_CODE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CATEGORY_CODE=" + Update.Dao.ToSql(item.CATEGORY_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUBCATEGORY_FULL_TITLE.IsEmpty Then
        allEmptyFlag = item.SUBCATEGORY_FULL_TITLE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUBCATEGORY_FULL_TITLE=" + Update.Dao.ToSql(item.SUBCATEGORY_FULL_TITLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.STATUS.IsEmpty Then
        allEmptyFlag = item.STATUS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STATUS=" + Update.Dao.ToSql(item.STATUS.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.SUBCATEGORY_CODE.IsEmpty Then
        allEmptyFlag = item.SUBCATEGORY_CODE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUBCATEGORY_CODE=" + Update.Dao.ToSql(item.SUBCATEGORY_CODE.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record ENROLMENT_CATEGORY BeforeBuildUpdate

'Record ENROLMENT_CATEGORY AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record ENROLMENT_CATEGORY AfterExecuteUpdate

'Record ENROLMENT_CATEGORY Data Provider Class GetResultSet Method @2-9BB8BD0D

    Public Sub FillItem(ByVal item As ENROLMENT_CATEGORYItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record ENROLMENT_CATEGORY Data Provider Class GetResultSet Method

'Record ENROLMENT_CATEGORY BeforeBuildSelect @2-56BE89EB
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("SUBCATEGORY_CODE6",UrlSUBCATEGORY_CODE, "","SUBCATEGORY_CODE",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("CATEGORY_CODE27",UrlCATEGORY_CODE, "","CATEGORY_CODE",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record ENROLMENT_CATEGORY BeforeBuildSelect

'Record ENROLMENT_CATEGORY BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record ENROLMENT_CATEGORY BeforeExecuteSelect

'Record ENROLMENT_CATEGORY AfterExecuteSelect @2-0B543983
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.CATEGORY_CODE.SetValue(dr(i)("CATEGORY_CODE"),"")
            item.SUBCATEGORY_FULL_TITLE.SetValue(dr(i)("SUBCATEGORY_FULL_TITLE"),"")
            item.STATUS.SetValue(dr(i)("STATUS"),Select_.BoolFormat)
            item.SUBCATEGORY_CODE.SetValue(dr(i)("SUBCATEGORY_CODE"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.lblLAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.lblLAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
'End Record ENROLMENT_CATEGORY AfterExecuteSelect

'Record ENROLMENT_CATEGORY AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record ENROLMENT_CATEGORY AfterExecuteSelect tail

'Record ENROLMENT_CATEGORY Data Provider Class @2-A61BA892
End Class

'End Record ENROLMENT_CATEGORY Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

