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

Namespace DECV_PROD2007.StudentEnrolmentDetails_maintain_backup 'Namespace @1-6D4DF947

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

'Record STUDENT_ENROLMENT Item Class @2-D2D473EF
Public Class STUDENT_ENROLMENTItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public STUDENT_ID As FloatField
    Public ENROLMENT_DATE As DateField
    Public WITHDRAWAL_DATE As DateField
    Public ENROLMENT_STATUS As TextField
    Public ENROLMENT_STATUSItems As ItemCollection
    Public WITHDRAWAL_REASON_ID As FloatField
    Public WITHDRAWAL_REASON_IDItems As ItemCollection
    Public YEAR_LEVEL As IntegerField
    Public YEAR_LEVELItems As ItemCollection
    Public ENROLMENT_YEAR As TextField
    Public CAMPUS As TextField
    Public CAMPUSItems As ItemCollection
    Public RECEIPT_NO As TextField
    Public ELIGIBLE_FOR_DISCOUNT As BooleanField
    Public ELIGIBLE_FOR_DISCOUNTItems As ItemCollection
    Public PAID_ON_ENROLMENT As BooleanField
    Public PAID_ON_ENROLMENTItems As ItemCollection
    Public FULL_TIME_STUDENT As BooleanField
    Public FULL_TIME_STUDENTItems As ItemCollection
    Public OS_FULL_FEE_PAYING As BooleanField
    Public OS_FULL_FEE_PAYINGItems As ItemCollection
    Public ADDRESS_REVIEW_FLAG As BooleanField
    Public ADDRESS_REVIEW_FLAGItems As ItemCollection
    Public ELIGIBLE_FOR_FUNDING As BooleanField
    Public ELIGIBLE_FOR_FUNDINGItems As ItemCollection
    Public VCE_CANDIDATE_NO As TextField
    Public BULLETIN_NO As TextField
    Public SUB_SCHOOL As TextField
    Public PASTORAL_CARE_ID As TextField
    Public PASTORAL_CARE_IDItems As ItemCollection
    Public DOCS_LAST_REVIEWED_DATE As DateField
    Public NEW_DOCS_REQUIRED As BooleanField
    Public NEW_DOCS_REQUIREDItems As ItemCollection
    Public ENROLMENT_COMMENTS As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    STUDENT_ID = New FloatField("", Nothing)
    ENROLMENT_DATE = New DateField("dd\/MM\/yy", Nothing)
    WITHDRAWAL_DATE = New DateField("dd\/MM\/yy", Nothing)
    ENROLMENT_STATUS = New TextField("", Nothing)
    ENROLMENT_STATUSItems = New ItemCollection()
    WITHDRAWAL_REASON_ID = New FloatField("", Nothing)
    WITHDRAWAL_REASON_IDItems = New ItemCollection()
    YEAR_LEVEL = New IntegerField("", Nothing)
    YEAR_LEVELItems = New ItemCollection()
    ENROLMENT_YEAR = New TextField("", Nothing)
    CAMPUS = New TextField("", Nothing)
    CAMPUSItems = New ItemCollection()
    RECEIPT_NO = New TextField("", Nothing)
    ELIGIBLE_FOR_DISCOUNT = New BooleanField(Settings.BoolFormat, Nothing)
    ELIGIBLE_FOR_DISCOUNTItems = New ItemCollection()
    PAID_ON_ENROLMENT = New BooleanField(Settings.BoolFormat, Nothing)
    PAID_ON_ENROLMENTItems = New ItemCollection()
    FULL_TIME_STUDENT = New BooleanField(Settings.BoolFormat, Nothing)
    FULL_TIME_STUDENTItems = New ItemCollection()
    OS_FULL_FEE_PAYING = New BooleanField(Settings.BoolFormat, Nothing)
    OS_FULL_FEE_PAYINGItems = New ItemCollection()
    ADDRESS_REVIEW_FLAG = New BooleanField(Settings.BoolFormat, Nothing)
    ADDRESS_REVIEW_FLAGItems = New ItemCollection()
    ELIGIBLE_FOR_FUNDING = New BooleanField(Settings.BoolFormat, Nothing)
    ELIGIBLE_FOR_FUNDINGItems = New ItemCollection()
    VCE_CANDIDATE_NO = New TextField("", Nothing)
    BULLETIN_NO = New TextField("", Nothing)
    SUB_SCHOOL = New TextField("", Nothing)
    PASTORAL_CARE_ID = New TextField("", Nothing)
    PASTORAL_CARE_IDItems = New ItemCollection()
    DOCS_LAST_REVIEWED_DATE = New DateField("dd\/MM\/yy", Nothing)
    NEW_DOCS_REQUIRED = New BooleanField(Settings.BoolFormat, Nothing)
    NEW_DOCS_REQUIREDItems = New ItemCollection()
    ENROLMENT_COMMENTS = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_ENROLMENTItem
        Dim item As STUDENT_ENROLMENTItem = New STUDENT_ENROLMENTItem()
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_DATE")) Then
        item.ENROLMENT_DATE.SetValue(DBUtility.GetInitialValue("ENROLMENT_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DatePicker_ENROLMENT_DATE")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("WITHDRAWAL_DATE")) Then
        item.WITHDRAWAL_DATE.SetValue(DBUtility.GetInitialValue("WITHDRAWAL_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DatePicker_WITHDRAWAL_DATE")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_STATUS")) Then
        item.ENROLMENT_STATUS.SetValue(DBUtility.GetInitialValue("ENROLMENT_STATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("WITHDRAWAL_REASON_ID")) Then
        item.WITHDRAWAL_REASON_ID.SetValue(DBUtility.GetInitialValue("WITHDRAWAL_REASON_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("YEAR_LEVEL")) Then
        item.YEAR_LEVEL.SetValue(DBUtility.GetInitialValue("YEAR_LEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_YEAR")) Then
        item.ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CAMPUS")) Then
        item.CAMPUS.SetValue(DBUtility.GetInitialValue("CAMPUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RECEIPT_NO")) Then
        item.RECEIPT_NO.SetValue(DBUtility.GetInitialValue("RECEIPT_NO"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ELIGIBLE_FOR_DISCOUNT")) Then
        item.ELIGIBLE_FOR_DISCOUNT.SetValue(DBUtility.GetInitialValue("ELIGIBLE_FOR_DISCOUNT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PAID_ON_ENROLMENT")) Then
        item.PAID_ON_ENROLMENT.SetValue(DBUtility.GetInitialValue("PAID_ON_ENROLMENT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FULL_TIME_STUDENT")) Then
        item.FULL_TIME_STUDENT.SetValue(DBUtility.GetInitialValue("FULL_TIME_STUDENT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("OS_FULL_FEE_PAYING")) Then
        item.OS_FULL_FEE_PAYING.SetValue(DBUtility.GetInitialValue("OS_FULL_FEE_PAYING"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ADDRESS_REVIEW_FLAG")) Then
        item.ADDRESS_REVIEW_FLAG.SetValue(DBUtility.GetInitialValue("ADDRESS_REVIEW_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ELIGIBLE_FOR_FUNDING")) Then
        item.ELIGIBLE_FOR_FUNDING.SetValue(DBUtility.GetInitialValue("ELIGIBLE_FOR_FUNDING"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("VCE_CANDIDATE_NO")) Then
        item.VCE_CANDIDATE_NO.SetValue(DBUtility.GetInitialValue("VCE_CANDIDATE_NO"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("BULLETIN_NO")) Then
        item.BULLETIN_NO.SetValue(DBUtility.GetInitialValue("BULLETIN_NO"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUB_SCHOOL")) Then
        item.SUB_SCHOOL.SetValue(DBUtility.GetInitialValue("SUB_SCHOOL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PASTORAL_CARE_ID")) Then
        item.PASTORAL_CARE_ID.SetValue(DBUtility.GetInitialValue("PASTORAL_CARE_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DOCS_LAST_REVIEWED_DATE")) Then
        item.DOCS_LAST_REVIEWED_DATE.SetValue(DBUtility.GetInitialValue("DOCS_LAST_REVIEWED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("NEW_DOCS_REQUIRED")) Then
        item.NEW_DOCS_REQUIRED.SetValue(DBUtility.GetInitialValue("NEW_DOCS_REQUIRED"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_COMMENTS")) Then
        item.ENROLMENT_COMMENTS.SetValue(DBUtility.GetInitialValue("ENROLMENT_COMMENTS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "ENROLMENT_DATE"
                    Return ENROLMENT_DATE
                Case "WITHDRAWAL_DATE"
                    Return WITHDRAWAL_DATE
                Case "ENROLMENT_STATUS"
                    Return ENROLMENT_STATUS
                Case "WITHDRAWAL_REASON_ID"
                    Return WITHDRAWAL_REASON_ID
                Case "YEAR_LEVEL"
                    Return YEAR_LEVEL
                Case "ENROLMENT_YEAR"
                    Return ENROLMENT_YEAR
                Case "CAMPUS"
                    Return CAMPUS
                Case "RECEIPT_NO"
                    Return RECEIPT_NO
                Case "ELIGIBLE_FOR_DISCOUNT"
                    Return ELIGIBLE_FOR_DISCOUNT
                Case "PAID_ON_ENROLMENT"
                    Return PAID_ON_ENROLMENT
                Case "FULL_TIME_STUDENT"
                    Return FULL_TIME_STUDENT
                Case "OS_FULL_FEE_PAYING"
                    Return OS_FULL_FEE_PAYING
                Case "ADDRESS_REVIEW_FLAG"
                    Return ADDRESS_REVIEW_FLAG
                Case "ELIGIBLE_FOR_FUNDING"
                    Return ELIGIBLE_FOR_FUNDING
                Case "VCE_CANDIDATE_NO"
                    Return VCE_CANDIDATE_NO
                Case "BULLETIN_NO"
                    Return BULLETIN_NO
                Case "SUB_SCHOOL"
                    Return SUB_SCHOOL
                Case "PASTORAL_CARE_ID"
                    Return PASTORAL_CARE_ID
                Case "DOCS_LAST_REVIEWED_DATE"
                    Return DOCS_LAST_REVIEWED_DATE
                Case "NEW_DOCS_REQUIRED"
                    Return NEW_DOCS_REQUIRED
                Case "ENROLMENT_COMMENTS"
                    Return ENROLMENT_COMMENTS
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
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, FloatField)
                Case "ENROLMENT_DATE"
                    ENROLMENT_DATE = CType(value, DateField)
                Case "WITHDRAWAL_DATE"
                    WITHDRAWAL_DATE = CType(value, DateField)
                Case "ENROLMENT_STATUS"
                    ENROLMENT_STATUS = CType(value, TextField)
                Case "WITHDRAWAL_REASON_ID"
                    WITHDRAWAL_REASON_ID = CType(value, FloatField)
                Case "YEAR_LEVEL"
                    YEAR_LEVEL = CType(value, IntegerField)
                Case "ENROLMENT_YEAR"
                    ENROLMENT_YEAR = CType(value, TextField)
                Case "CAMPUS"
                    CAMPUS = CType(value, TextField)
                Case "RECEIPT_NO"
                    RECEIPT_NO = CType(value, TextField)
                Case "ELIGIBLE_FOR_DISCOUNT"
                    ELIGIBLE_FOR_DISCOUNT = CType(value, BooleanField)
                Case "PAID_ON_ENROLMENT"
                    PAID_ON_ENROLMENT = CType(value, BooleanField)
                Case "FULL_TIME_STUDENT"
                    FULL_TIME_STUDENT = CType(value, BooleanField)
                Case "OS_FULL_FEE_PAYING"
                    OS_FULL_FEE_PAYING = CType(value, BooleanField)
                Case "ADDRESS_REVIEW_FLAG"
                    ADDRESS_REVIEW_FLAG = CType(value, BooleanField)
                Case "ELIGIBLE_FOR_FUNDING"
                    ELIGIBLE_FOR_FUNDING = CType(value, BooleanField)
                Case "VCE_CANDIDATE_NO"
                    VCE_CANDIDATE_NO = CType(value, TextField)
                Case "BULLETIN_NO"
                    BULLETIN_NO = CType(value, TextField)
                Case "SUB_SCHOOL"
                    SUB_SCHOOL = CType(value, TextField)
                Case "PASTORAL_CARE_ID"
                    PASTORAL_CARE_ID = CType(value, TextField)
                Case "DOCS_LAST_REVIEWED_DATE"
                    DOCS_LAST_REVIEWED_DATE = CType(value, DateField)
                Case "NEW_DOCS_REQUIRED"
                    NEW_DOCS_REQUIRED = CType(value, BooleanField)
                Case "ENROLMENT_COMMENTS"
                    ENROLMENT_COMMENTS = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STUDENT_ENROLMENTDataProvider)
'End Record STUDENT_ENROLMENT Item Class

'ENROLMENT_DATE validate @8-F0770BE0
        If IsNothing(ENROLMENT_DATE.Value) OrElse ENROLMENT_DATE.Value.ToString() ="" Then
            errors.Add("ENROLMENT_DATE",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT DATE"))
        End If
'End ENROLMENT_DATE validate

'ENROLMENT_STATUS validate @12-5B7051E5
        If IsNothing(ENROLMENT_STATUS.Value) OrElse ENROLMENT_STATUS.Value.ToString() ="" Then
            errors.Add("ENROLMENT_STATUS",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT STATUS"))
        End If
'End ENROLMENT_STATUS validate

'YEAR_LEVEL validate @14-30512612
        If IsNothing(YEAR_LEVEL.Value) OrElse YEAR_LEVEL.Value.ToString() ="" Then
            errors.Add("YEAR_LEVEL",String.Format(Resources.strings.CCS_RequiredField,"YEAR LEVEL"))
        End If
'End YEAR_LEVEL validate

'CAMPUS validate @15-FDE75F2D
        If IsNothing(CAMPUS.Value) OrElse CAMPUS.Value.ToString() ="" Then
            errors.Add("CAMPUS",String.Format(Resources.strings.CCS_RequiredField,"CAMPUS"))
        End If
'End CAMPUS validate

'Record STUDENT_ENROLMENT Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_ENROLMENT Item Class tail

'Record STUDENT_ENROLMENT Data Provider Class @2-55469C34
Public Class STUDENT_ENROLMENTDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_ENROLMENT Data Provider Class

'Record STUDENT_ENROLMENT Data Provider Class Variables @2-FDB0DF1E
    Protected WITHDRAWAL_REASON_IDDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM WITHDRAWAL_REASON {SQL_Where} {SQL_OrderBy}", New String(){"expr19"},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected PASTORAL_CARE_IDDataCommand As DataCommand=new TableCommand("SELECT STAFF_ID " & vbCrLf & _
          "FROM STAFF {SQL_Where} {SQL_OrderBy}", New String(){"expr56","And","expr57"},Settings.connDECVPRODSQL2005DataAccessObject )
    Public UrlSTUDENT_ID As FloatParameter
    Public UrlENROLMENT_YEAR As FloatParameter
    Public CtrlENROLMENT_DATE As DateParameter
    Public CtrlWITHDRAWAL_DATE As DateParameter
    Public CtrlENROLMENT_STATUS As TextParameter
    Public CtrlWITHDRAWAL_REASON_ID As FloatParameter
    Public CtrlYEAR_LEVEL As IntegerParameter
    Public CtrlCAMPUS As TextParameter
    Public CtrlRECEIPT_NO As TextParameter
    Public CtrlELIGIBLE_FOR_DISCOUNT As TextParameter
    Public CtrlPAID_ON_ENROLMENT As TextParameter
    Public CtrlFULL_TIME_STUDENT As TextParameter
    Public CtrlOS_FULL_FEE_PAYING As TextParameter
    Public CtrlADDRESS_REVIEW_FLAG As TextParameter
    Public CtrlELIGIBLE_FOR_FUNDING As TextParameter
    Public CtrlVCE_CANDIDATE_NO As TextParameter
    Public CtrlBULLETIN_NO As TextParameter
    Public CtrlSUB_SCHOOL As TextParameter
    Public CtrlPASTORAL_CARE_ID As TextParameter
    Public CtrlDOCS_LAST_REVIEWED_DATE As DateParameter
    Public CtrlNEW_DOCS_REQUIRED As TextParameter
    Public CtrlENROLMENT_COMMENTS As TextParameter
    Protected item As STUDENT_ENROLMENTItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_ENROLMENT Data Provider Class Variables

'Record STUDENT_ENROLMENT Data Provider Class Constructor @2-451A6D3A

    Public Sub New()
        Select_=new TableCommand("SELECT STUDENT_ENROLMENT.STUDENT_ID AS STUDENT_ENROLMENT_STUDENT_ID, " & vbCrLf & _
          "ENROLMENT_YEAR, CAMPUS, YEAR_LEVEL, RECEIPT_NO, ENROLMENT_DATE," & vbCrLf & _
          "WITHDRAWAL_DATE, " & vbCrLf & _
          "ENROLMENT_STATUS, WITHDRAWAL_REASON_ID, ELIGIBLE_FOR_DISCOUNT, PAID_ON_ENROLMENT, " & vbCrLf & _
          "SUB_SCHOOL, ELIGIBLE_FOR_FUNDING," & vbCrLf & _
          "DECV_BALANCE, VSL_BALANCE, DOCS_LAST_REVIEWED_DATE, " & vbCrLf & _
          "NEW_DOCS_REQUIRED, " & vbCrLf & _
          "STUDENT_ENROLMENT.LAST_ALTERED_BY AS STUDENT_ENROLMENT_LAST_ALTERED_BY," & vbCrLf & _
          "STUDENT_ENROLMENT.LAST_ALTERED_DATE AS STUDENT_ENROLMENT_LAST_ALTERED_DATE, PASTORAL_CARE_" & _
          "ID, FULL_TIME, BULLETIN_NUMBER," & vbCrLf & _
          "OS_FULL_FEE_PAYING, ENROLMENT_COMMENTS, VCE_CANDIDATE_NUMBER, ADDRESS_REVIEW_FLAG, STUDENT" & _
          ".STUDENT_ID AS STUDENT_STUDENT_ID " & vbCrLf & _
          "FROM STUDENT_ENROLMENT INNER JOIN STUDENT ON" & vbCrLf & _
          "STUDENT_ENROLMENT.STUDENT_ID = STUDENT.STUDENT_ID {SQL_Where} {SQL_OrderBy}", New String(){"expr70","And","STUDENT_ID28","And","ENROLMENT_YEAR6"},Settings.connDECVPRODSQL2005DataAccessObject )
        Update=new TableCommand("UPDATE  SET ENROLMENT_DATE={ENROLMENT_DATE}, WITHDRAWAL_DATE={WITHDRAWAL_DATE}, " & vbCrLf & _
          "ENROLMENT_STATUS={ENROLMENT_STATUS}, WITHDRAWAL_REASON_ID={WITHDRAWAL_REASON_ID}, " & vbCrLf & _
          "YEAR_LEVEL={YEAR_LEVEL}, CAMPUS={CAMPUS}, RECEIPT_NO={RECEIPT_NO}, " & vbCrLf & _
          "ELIGIBLE_FOR_DISCOUNT={ELIGIBLE_FOR_DISCOUNT}, PAID_ON_ENROLMENT={PAID_ON_ENROLMENT}, " & vbCrLf & _
          "FULL_TIME={FULL_TIME}, OS_FULL_FEE_PAYING={OS_FULL_FEE_PAYING}, " & vbCrLf & _
          "ADDRESS_REVIEW_FLAG={ADDRESS_REVIEW_FLAG}, ELIGIBLE_FOR_FUNDING={ELIGIBLE_FOR_FUNDING}, " & vbCrLf & _
          "VCE_CANDIDATE_NUMBER={VCE_CANDIDATE_NUMBER}, BULLETIN_NUMBER={BULLETIN_NUMBER}, " & vbCrLf & _
          "SUB_SCHOOL={SUB_SCHOOL}, PASTORAL_CARE_ID={PASTORAL_CARE_ID}, " & vbCrLf & _
          "DOCS_LAST_REVIEWED_DATE={DOCS_LAST_REVIEWED_DATE}, NEW_DOCS_REQUIRED={NEW_DOCS_REQUIRED}, " & vbCrLf & _
          "ENROLMENT_COMMENTS={ENROLMENT_COMMENTS}", New String(){"expr101","And","STUDENT_ID102","And","ENROLMENT_YEAR103"},Settings.connDECVPRODSQL2005DataAccessObject , true)
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_ENROLMENT Data Provider Class Constructor

'Record STUDENT_ENROLMENT Data Provider Class LoadParams Method @2-881E766D

    Protected Function LoadParams() As Boolean
    CommonParameters.Add("expr70","STUDENT.STUDENT_ID = STUDENT_ENROLMENT.STUDENT_ID")
        Return Not (IsNothing(UrlSTUDENT_ID) Or IsNothing(UrlENROLMENT_YEAR))
    End Function
'End Record STUDENT_ENROLMENT Data Provider Class LoadParams Method

'Record STUDENT_ENROLMENT Data Provider Class CheckUnique Method @2-BF72701B

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_ENROLMENTItem) As Boolean
        Return True
    End Function
'End Record STUDENT_ENROLMENT Data Provider Class CheckUnique Method

'Record STUDENT_ENROLMENT Data Provider Class PrepareUpdate Method @2-823EF5BA

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = Not(IsNothing(UrlSTUDENT_ID) Or IsNothing(UrlENROLMENT_YEAR))
'End Record STUDENT_ENROLMENT Data Provider Class PrepareUpdate Method

'Record STUDENT_ENROLMENT Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record STUDENT_ENROLMENT Data Provider Class PrepareUpdate Method tail

'Record STUDENT_ENROLMENT Data Provider Class Update Method @2-B4A39D12

    Public Function UpdateItem(ByVal item As STUDENT_ENROLMENTItem) As Integer
        Me.item = item
'End Record STUDENT_ENROLMENT Data Provider Class Update Method

'Record STUDENT_ENROLMENT BeforeBuildUpdate @2-01BBF8D9
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID102",UrlSTUDENT_ID, "","STUDENT_ENROLMENT.STUDENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ENROLMENT_YEAR103",UrlENROLMENT_YEAR, "","STUDENT_ENROLMENT.ENROLMENT_YEAR",Condition.Equal,False)
        Update.Parameters.Add("expr101","(STUDENT.STUDENT_ID = STUDENT_ENROLMENT.STUDENT_ID)")
        If item.ENROLMENT_DATE.Value Is Nothing Then
            Update.SqlQuery.Replace("{ENROLMENT_DATE}",Update.Dao.ToSql(Nothing,FieldType._Date))
        Else
            Update.SqlQuery.Replace("{ENROLMENT_DATE}",Update.Dao.ToSql(item.ENROLMENT_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date))
        End If
        If item.WITHDRAWAL_DATE.Value Is Nothing Then
            Update.SqlQuery.Replace("{WITHDRAWAL_DATE}",Update.Dao.ToSql(Nothing,FieldType._Date))
        Else
            Update.SqlQuery.Replace("{WITHDRAWAL_DATE}",Update.Dao.ToSql(item.WITHDRAWAL_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date))
        End If
        If item.ENROLMENT_STATUS.Value Is Nothing Then
            Update.SqlQuery.Replace("{ENROLMENT_STATUS}",Update.Dao.ToSql(Nothing,FieldType._Text))
        Else
            Update.SqlQuery.Replace("{ENROLMENT_STATUS}",Update.Dao.ToSql(item.ENROLMENT_STATUS.GetFormattedValue(""),FieldType._Text))
        End If
        If item.WITHDRAWAL_REASON_ID.Value Is Nothing Then
            Update.SqlQuery.Replace("{WITHDRAWAL_REASON_ID}",Update.Dao.ToSql(Nothing,FieldType._Float))
        Else
            Update.SqlQuery.Replace("{WITHDRAWAL_REASON_ID}",Update.Dao.ToSql(item.WITHDRAWAL_REASON_ID.GetFormattedValue(""),FieldType._Float))
        End If
        If item.YEAR_LEVEL.Value Is Nothing Then
            Update.SqlQuery.Replace("{YEAR_LEVEL}",Update.Dao.ToSql(Nothing,FieldType._Integer))
        Else
            Update.SqlQuery.Replace("{YEAR_LEVEL}",Update.Dao.ToSql(item.YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer))
        End If
        If item.CAMPUS.Value Is Nothing Then
            Update.SqlQuery.Replace("{CAMPUS}",Update.Dao.ToSql(Nothing,FieldType._Text))
        Else
            Update.SqlQuery.Replace("{CAMPUS}",Update.Dao.ToSql(item.CAMPUS.GetFormattedValue(""),FieldType._Text))
        End If
        If item.RECEIPT_NO.Value Is Nothing Then
            Update.SqlQuery.Replace("{RECEIPT_NO}",Update.Dao.ToSql(Nothing,FieldType._Text))
        Else
            Update.SqlQuery.Replace("{RECEIPT_NO}",Update.Dao.ToSql(item.RECEIPT_NO.GetFormattedValue(""),FieldType._Text))
        End If
        If item.ELIGIBLE_FOR_DISCOUNT.Value Is Nothing Then
            Update.SqlQuery.Replace("{ELIGIBLE_FOR_DISCOUNT}",Update.Dao.ToSql(Nothing,FieldType._Text))
        Else
            Update.SqlQuery.Replace("{ELIGIBLE_FOR_DISCOUNT}",Update.Dao.ToSql(item.ELIGIBLE_FOR_DISCOUNT.GetFormattedValue(""),FieldType._Text))
        End If
        If item.PAID_ON_ENROLMENT.Value Is Nothing Then
            Update.SqlQuery.Replace("{PAID_ON_ENROLMENT}",Update.Dao.ToSql(Nothing,FieldType._Text))
        Else
            Update.SqlQuery.Replace("{PAID_ON_ENROLMENT}",Update.Dao.ToSql(item.PAID_ON_ENROLMENT.GetFormattedValue(""),FieldType._Text))
        End If
        If item.FULL_TIME_STUDENT.Value Is Nothing Then
            Update.SqlQuery.Replace("{FULL_TIME}",Update.Dao.ToSql(Nothing,FieldType._Text))
        Else
            Update.SqlQuery.Replace("{FULL_TIME}",Update.Dao.ToSql(item.FULL_TIME_STUDENT.GetFormattedValue(""),FieldType._Text))
        End If
        If item.OS_FULL_FEE_PAYING.Value Is Nothing Then
            Update.SqlQuery.Replace("{OS_FULL_FEE_PAYING}",Update.Dao.ToSql(Nothing,FieldType._Text))
        Else
            Update.SqlQuery.Replace("{OS_FULL_FEE_PAYING}",Update.Dao.ToSql(item.OS_FULL_FEE_PAYING.GetFormattedValue(""),FieldType._Text))
        End If
        If item.ADDRESS_REVIEW_FLAG.Value Is Nothing Then
            Update.SqlQuery.Replace("{ADDRESS_REVIEW_FLAG}",Update.Dao.ToSql(Nothing,FieldType._Text))
        Else
            Update.SqlQuery.Replace("{ADDRESS_REVIEW_FLAG}",Update.Dao.ToSql(item.ADDRESS_REVIEW_FLAG.GetFormattedValue(""),FieldType._Text))
        End If
        If item.ELIGIBLE_FOR_FUNDING.Value Is Nothing Then
            Update.SqlQuery.Replace("{ELIGIBLE_FOR_FUNDING}",Update.Dao.ToSql(Nothing,FieldType._Text))
        Else
            Update.SqlQuery.Replace("{ELIGIBLE_FOR_FUNDING}",Update.Dao.ToSql(item.ELIGIBLE_FOR_FUNDING.GetFormattedValue(""),FieldType._Text))
        End If
        If item.VCE_CANDIDATE_NO.Value Is Nothing Then
            Update.SqlQuery.Replace("{VCE_CANDIDATE_NUMBER}",Update.Dao.ToSql(Nothing,FieldType._Text))
        Else
            Update.SqlQuery.Replace("{VCE_CANDIDATE_NUMBER}",Update.Dao.ToSql(item.VCE_CANDIDATE_NO.GetFormattedValue(""),FieldType._Text))
        End If
        If item.BULLETIN_NO.Value Is Nothing Then
            Update.SqlQuery.Replace("{BULLETIN_NUMBER}",Update.Dao.ToSql(Nothing,FieldType._Text))
        Else
            Update.SqlQuery.Replace("{BULLETIN_NUMBER}",Update.Dao.ToSql(item.BULLETIN_NO.GetFormattedValue(""),FieldType._Text))
        End If
        If item.SUB_SCHOOL.Value Is Nothing Then
            Update.SqlQuery.Replace("{SUB_SCHOOL}",Update.Dao.ToSql(Nothing,FieldType._Text))
        Else
            Update.SqlQuery.Replace("{SUB_SCHOOL}",Update.Dao.ToSql(item.SUB_SCHOOL.GetFormattedValue(""),FieldType._Text))
        End If
        If item.PASTORAL_CARE_ID.Value Is Nothing Then
            Update.SqlQuery.Replace("{PASTORAL_CARE_ID}",Update.Dao.ToSql(Nothing,FieldType._Text))
        Else
            Update.SqlQuery.Replace("{PASTORAL_CARE_ID}",Update.Dao.ToSql(item.PASTORAL_CARE_ID.GetFormattedValue(""),FieldType._Text))
        End If
        If item.DOCS_LAST_REVIEWED_DATE.Value Is Nothing Then
            Update.SqlQuery.Replace("{DOCS_LAST_REVIEWED_DATE}",Update.Dao.ToSql(Nothing,FieldType._Date))
        Else
            Update.SqlQuery.Replace("{DOCS_LAST_REVIEWED_DATE}",Update.Dao.ToSql(item.DOCS_LAST_REVIEWED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date))
        End If
        If item.NEW_DOCS_REQUIRED.Value Is Nothing Then
            Update.SqlQuery.Replace("{NEW_DOCS_REQUIRED}",Update.Dao.ToSql(Nothing,FieldType._Text))
        Else
            Update.SqlQuery.Replace("{NEW_DOCS_REQUIRED}",Update.Dao.ToSql(item.NEW_DOCS_REQUIRED.GetFormattedValue(""),FieldType._Text))
        End If
        If item.ENROLMENT_COMMENTS.Value Is Nothing Then
            Update.SqlQuery.Replace("{ENROLMENT_COMMENTS}",Update.Dao.ToSql(Nothing,FieldType._Text))
        Else
            Update.SqlQuery.Replace("{ENROLMENT_COMMENTS}",Update.Dao.ToSql(item.ENROLMENT_COMMENTS.GetFormattedValue(""),FieldType._Text))
        End If
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
'End Record STUDENT_ENROLMENT BeforeBuildUpdate

'Record STUDENT_ENROLMENT AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_ENROLMENT AfterExecuteUpdate

'Record STUDENT_ENROLMENT Data Provider Class GetResultSet Method @2-6E5BBB74

    Public Sub FillItem(ByVal item As STUDENT_ENROLMENTItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_ENROLMENT Data Provider Class GetResultSet Method

'Record STUDENT_ENROLMENT BeforeBuildSelect @2-88D47D3D
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID28",UrlSTUDENT_ID, "","STUDENT_ENROLMENT.STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("ENROLMENT_YEAR6",UrlENROLMENT_YEAR, "","STUDENT_ENROLMENT.ENROLMENT_YEAR",Condition.Equal,False)
        Select_.Parameters.Add("expr70","(STUDENT.STUDENT_ID = STUDENT_ENROLMENT.STUDENT_ID)")
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_ENROLMENT BeforeBuildSelect

'Record STUDENT_ENROLMENT BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_ENROLMENT BeforeExecuteSelect

'Record STUDENT_ENROLMENT AfterExecuteSelect @2-6EBBBE5C
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_STUDENT_ID"),"")
            item.ENROLMENT_DATE.SetValue(dr(i)("ENROLMENT_DATE"),Select_.DateFormat)
            item.WITHDRAWAL_DATE.SetValue(dr(i)("WITHDRAWAL_DATE"),Select_.DateFormat)
            item.ENROLMENT_STATUS.SetValue(dr(i)("ENROLMENT_STATUS"),"")
            item.WITHDRAWAL_REASON_ID.SetValue(dr(i)("WITHDRAWAL_REASON_ID"),"")
            item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
            item.ENROLMENT_YEAR.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.CAMPUS.SetValue(dr(i)("CAMPUS"),"")
            item.RECEIPT_NO.SetValue(dr(i)("RECEIPT_NO"),"")
            item.ELIGIBLE_FOR_DISCOUNT.SetValue(dr(i)("ELIGIBLE_FOR_DISCOUNT"),Select_.BoolFormat)
            item.PAID_ON_ENROLMENT.SetValue(dr(i)("PAID_ON_ENROLMENT"),Select_.BoolFormat)
            item.FULL_TIME_STUDENT.SetValue(dr(i)("FULL_TIME"),Select_.BoolFormat)
            item.OS_FULL_FEE_PAYING.SetValue(dr(i)("OS_FULL_FEE_PAYING"),Select_.BoolFormat)
            item.ADDRESS_REVIEW_FLAG.SetValue(dr(i)("ADDRESS_REVIEW_FLAG"),Select_.BoolFormat)
            item.ELIGIBLE_FOR_FUNDING.SetValue(dr(i)("ELIGIBLE_FOR_FUNDING"),Select_.BoolFormat)
            item.VCE_CANDIDATE_NO.SetValue(dr(i)("VCE_CANDIDATE_NUMBER"),"")
            item.BULLETIN_NO.SetValue(dr(i)("BULLETIN_NUMBER"),"")
            item.SUB_SCHOOL.SetValue(dr(i)("SUB_SCHOOL"),"")
            item.PASTORAL_CARE_ID.SetValue(dr(i)("PASTORAL_CARE_ID"),"")
            item.DOCS_LAST_REVIEWED_DATE.SetValue(dr(i)("DOCS_LAST_REVIEWED_DATE"),Select_.DateFormat)
            item.NEW_DOCS_REQUIRED.SetValue(dr(i)("NEW_DOCS_REQUIRED"),Select_.BoolFormat)
            item.ENROLMENT_COMMENTS.SetValue(dr(i)("ENROLMENT_COMMENTS"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("STUDENT_ENROLMENT_LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("STUDENT_ENROLMENT_LAST_ALTERED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record STUDENT_ENROLMENT AfterExecuteSelect

'ListBox ENROLMENT_STATUS AfterExecuteSelect @12-492375C2
        
item.ENROLMENT_STATUSItems.Add("E","Enrolled")
item.ENROLMENT_STATUSItems.Add("N","Not Enrolled")
'End ListBox ENROLMENT_STATUS AfterExecuteSelect

'ListBox WITHDRAWAL_REASON_ID Initialize Data Source @13-3EC84AF0
        WITHDRAWAL_REASON_IDDataCommand.Dao._optimized = False
        Dim WITHDRAWAL_REASON_IDtableIndex As Integer = 0
        WITHDRAWAL_REASON_IDDataCommand.OrderBy = ""
        WITHDRAWAL_REASON_IDDataCommand.Parameters.Clear()
        WITHDRAWAL_REASON_IDDataCommand.Parameters.Add("expr19","(STATUS = 1)")
'End ListBox WITHDRAWAL_REASON_ID Initialize Data Source

'ListBox WITHDRAWAL_REASON_ID BeforeExecuteSelect @13-AAF6FC16
        Try
            ListBoxSource=WITHDRAWAL_REASON_IDDataCommand.Execute().Tables(WITHDRAWAL_REASON_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox WITHDRAWAL_REASON_ID BeforeExecuteSelect

'ListBox WITHDRAWAL_REASON_ID AfterExecuteSelect @13-84798B21
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New FloatField("", ListBoxSource(j)("WITHDRAWAL_REASON_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("WITHDRAWAL_REASON")
            item.WITHDRAWAL_REASON_IDItems.Add(Key, Val)
        Next
'End ListBox WITHDRAWAL_REASON_ID AfterExecuteSelect

'ListBox YEAR_LEVEL AfterExecuteSelect @14-E273DC42
        
item.YEAR_LEVELItems.Add("0","0 - Prep")
item.YEAR_LEVELItems.Add("1","1")
item.YEAR_LEVELItems.Add("2","2")
item.YEAR_LEVELItems.Add("3","3")
item.YEAR_LEVELItems.Add("4","4")
item.YEAR_LEVELItems.Add("5","5")
item.YEAR_LEVELItems.Add("6","6")
item.YEAR_LEVELItems.Add("7","7")
item.YEAR_LEVELItems.Add("8","8")
item.YEAR_LEVELItems.Add("9","9")
item.YEAR_LEVELItems.Add("10","10")
item.YEAR_LEVELItems.Add("11","11")
item.YEAR_LEVELItems.Add("12","12")
'End ListBox YEAR_LEVEL AfterExecuteSelect

'ListBox CAMPUS AfterExecuteSelect @15-65D7B240
        
item.CAMPUSItems.Add("D","DECV")
'End ListBox CAMPUS AfterExecuteSelect

'ListBox ELIGIBLE_FOR_DISCOUNT AfterExecuteSelect @59-B80B8A7D
        
item.ELIGIBLE_FOR_DISCOUNTItems.Add("Yes","Yes")
item.ELIGIBLE_FOR_DISCOUNTItems.Add("No","No")
'End ListBox ELIGIBLE_FOR_DISCOUNT AfterExecuteSelect

'ListBox PAID_ON_ENROLMENT AfterExecuteSelect @62-C642CB4D
        
item.PAID_ON_ENROLMENTItems.Add("Yes","Yes")
item.PAID_ON_ENROLMENTItems.Add("No","No")
'End ListBox PAID_ON_ENROLMENT AfterExecuteSelect

'ListBox FULL_TIME_STUDENT AfterExecuteSelect @60-1E0CDEDD
        
item.FULL_TIME_STUDENTItems.Add("Yes","Yes")
item.FULL_TIME_STUDENTItems.Add("No","No")
'End ListBox FULL_TIME_STUDENT AfterExecuteSelect

'ListBox OS_FULL_FEE_PAYING AfterExecuteSelect @63-99B2EF6D
        
item.OS_FULL_FEE_PAYINGItems.Add("Yes","Yes")
item.OS_FULL_FEE_PAYINGItems.Add("No","No")
'End ListBox OS_FULL_FEE_PAYING AfterExecuteSelect

'ListBox ADDRESS_REVIEW_FLAG AfterExecuteSelect @61-FC861F1E
        
item.ADDRESS_REVIEW_FLAGItems.Add("Yes","Yes")
item.ADDRESS_REVIEW_FLAGItems.Add("No","No")
'End ListBox ADDRESS_REVIEW_FLAG AfterExecuteSelect

'ListBox ELIGIBLE_FOR_FUNDING AfterExecuteSelect @64-37B981B2
        
item.ELIGIBLE_FOR_FUNDINGItems.Add("Yes","Yes")
item.ELIGIBLE_FOR_FUNDINGItems.Add("No","No")
'End ListBox ELIGIBLE_FOR_FUNDING AfterExecuteSelect

'ListBox PASTORAL_CARE_ID Initialize Data Source @54-01ABB756
        PASTORAL_CARE_IDDataCommand.Dao._optimized = False
        Dim PASTORAL_CARE_IDtableIndex As Integer = 0
        PASTORAL_CARE_IDDataCommand.OrderBy = "STAFF_ID"
        PASTORAL_CARE_IDDataCommand.Parameters.Clear()
        PASTORAL_CARE_IDDataCommand.Parameters.Add("expr56","(STATUS = 1)")
        PASTORAL_CARE_IDDataCommand.Parameters.Add("expr57","(TEACHER_FLAG = 1)")
'End ListBox PASTORAL_CARE_ID Initialize Data Source

'ListBox PASTORAL_CARE_ID BeforeExecuteSelect @54-94F2041D
        Try
            ListBoxSource=PASTORAL_CARE_IDDataCommand.Execute().Tables(PASTORAL_CARE_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox PASTORAL_CARE_ID BeforeExecuteSelect

'ListBox PASTORAL_CARE_ID AfterExecuteSelect @54-FF907F0B
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("STAFF_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("STAFF_ID")
            item.PASTORAL_CARE_IDItems.Add(Key, Val)
        Next
'End ListBox PASTORAL_CARE_ID AfterExecuteSelect

'ListBox NEW_DOCS_REQUIRED AfterExecuteSelect @65-166C6FEE
        
item.NEW_DOCS_REQUIREDItems.Add("Yes","Yes")
item.NEW_DOCS_REQUIREDItems.Add("No","No")
'End ListBox NEW_DOCS_REQUIRED AfterExecuteSelect

'Record STUDENT_ENROLMENT AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record STUDENT_ENROLMENT AfterExecuteSelect tail

'Record STUDENT_ENROLMENT Data Provider Class @2-A61BA892
End Class

'End Record STUDENT_ENROLMENT Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

