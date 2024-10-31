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

Namespace DECV_PROD2007.Student_Exit_Track 'Namespace @1-4B73CE90

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

'Record Student_Exit Item Class @2-0505CE2C
Public Class Student_ExitItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public Lbl_Name As TextField
    Public Lbl_StudentID As TextField
    Public Lbl_WithDrawnReason As TextField
    Public Lbl_WithDrawnDate As DateField
    Public lbEXIT_DESTINATION As FloatField
    Public lbEXIT_DESTINATIONItems As ItemCollection
    Public TextAreaComments As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public TXT_LastAlteredBy As TextField
    Public Hidden_CommentID As TextField
    Public Sub New()
    Lbl_Name = New TextField("", Nothing)
    Lbl_StudentID = New TextField("", Nothing)
    Lbl_WithDrawnReason = New TextField("", "not completed")
    Lbl_WithDrawnDate = New DateField("dd\/MM\/yyyy", Nothing)
    lbEXIT_DESTINATION = New FloatField("", Nothing)
    lbEXIT_DESTINATIONItems = New ItemCollection()
    TextAreaComments = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    TXT_LastAlteredBy = New TextField("", DBUTILITY.USERID)
    Hidden_CommentID = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As Student_ExitItem
        Dim item As Student_ExitItem = New Student_ExitItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Lbl_Name")) Then
        item.Lbl_Name.SetValue(DBUtility.GetInitialValue("Lbl_Name"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Lbl_StudentID")) Then
        item.Lbl_StudentID.SetValue(DBUtility.GetInitialValue("Lbl_StudentID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Lbl_WithDrawnReason")) Then
        item.Lbl_WithDrawnReason.SetValue(DBUtility.GetInitialValue("Lbl_WithDrawnReason"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Lbl_WithDrawnDate")) Then
        item.Lbl_WithDrawnDate.SetValue(DBUtility.GetInitialValue("Lbl_WithDrawnDate"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lbEXIT_DESTINATION")) Then
        item.lbEXIT_DESTINATION.SetValue(DBUtility.GetInitialValue("lbEXIT_DESTINATION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("TextAreaComments")) Then
        item.TextAreaComments.SetValue(DBUtility.GetInitialValue("TextAreaComments"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("TXT_LastAlteredBy")) Then
        item.TXT_LastAlteredBy.SetValue(DBUtility.GetInitialValue("TXT_LastAlteredBy"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_CommentID")) Then
        item.Hidden_CommentID.SetValue(DBUtility.GetInitialValue("Hidden_CommentID"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Lbl_Name"
                    Return Lbl_Name
                Case "Lbl_StudentID"
                    Return Lbl_StudentID
                Case "Lbl_WithDrawnReason"
                    Return Lbl_WithDrawnReason
                Case "Lbl_WithDrawnDate"
                    Return Lbl_WithDrawnDate
                Case "lbEXIT_DESTINATION"
                    Return lbEXIT_DESTINATION
                Case "TextAreaComments"
                    Return TextAreaComments
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "TXT_LastAlteredBy"
                    Return TXT_LastAlteredBy
                Case "Hidden_CommentID"
                    Return Hidden_CommentID
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Lbl_Name"
                    Lbl_Name = CType(value, TextField)
                Case "Lbl_StudentID"
                    Lbl_StudentID = CType(value, TextField)
                Case "Lbl_WithDrawnReason"
                    Lbl_WithDrawnReason = CType(value, TextField)
                Case "Lbl_WithDrawnDate"
                    Lbl_WithDrawnDate = CType(value, DateField)
                Case "lbEXIT_DESTINATION"
                    lbEXIT_DESTINATION = CType(value, FloatField)
                Case "TextAreaComments"
                    TextAreaComments = CType(value, TextField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "TXT_LastAlteredBy"
                    TXT_LastAlteredBy = CType(value, TextField)
                Case "Hidden_CommentID"
                    Hidden_CommentID = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As Student_ExitDataProvider)
'End Record Student_Exit Item Class

'lbEXIT_DESTINATION validate @17-8D62A429
        If IsNothing(lbEXIT_DESTINATION.Value) OrElse lbEXIT_DESTINATION.Value.ToString() ="" Then
            errors.Add("lbEXIT_DESTINATION",String.Format(Resources.strings.CCS_RequiredField,"EXIT DESTINATION"))
        End If
'End lbEXIT_DESTINATION validate

'TextAreaComments validate @24-F41A49DF
        If IsNothing(TextAreaComments.Value) OrElse TextAreaComments.Value.ToString() ="" Then
            errors.Add("TextAreaComments",String.Format(Resources.strings.CCS_RequiredField,"COMMENTS"))
        End If
'End TextAreaComments validate

'Record Student_Exit Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record Student_Exit Item Class tail

'Record Student_Exit Data Provider Class @2-9F826EB2
Public Class Student_ExitDataProvider
Inherits RecordDataProviderBase
'End Record Student_Exit Data Provider Class

'Record Student_Exit Data Provider Class Variables @2-C59BB0E0
    Protected lbEXIT_DESTINATIONDataCommand As DataCommand=new TableCommand("SELECT WD_DEST_ID, " & vbCrLf & _
          "EXIT_DESTINATION_DESCRIPTION " & vbCrLf & _
          "FROM WITHDRAWAL_EXIT_DESTINATION {SQL_Where} {SQL_OrderBy}", New String(){"expr18"},Settings.connDECVPRODSQL2005DataAccessObject )
    Public UrlRETURN_VALUE As IntegerParameter
    Public CtrlHidden_CommentID As FloatParameter
    Public Urls_STUDENT_ID As FloatParameter
    Public Urls_ENROLMENT_YEAR As FloatParameter
    Public CtrllbEXIT_DESTINATION As IntegerParameter
    Public CtrlTextAreaComments As TextParameter
    Public CtrlTXT_LastAlteredBy As TextParameter
    Protected item As Student_ExitItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record Student_Exit Data Provider Class Variables

'Record Student_Exit Data Provider Class Constructor @2-33F3AFA6

    Public Sub New()
        Select_=new SqlCommand("SELECT TOP 1 STUDENT_ID, Name, WITHDRAWAL_DATE, WITHDRAWAL_REASON_ID, Reason, ENROLMENT_ST" & _
          "ATUS, WITHDRAWAL_EXIT_DESTINATION, COMMENT, LAST_ALTERED_BY," & vbCrLf & _
          "LAST_ALTERED_DATE, ENROLMENT_YEAR, COMMENT_TYPE, COMMENT_ID " & vbCrLf & _
          "FROM View_StudentExitTRack" & vbCrLf & _
          "WHERE ENROLMENT_YEAR = {s_ENROLMENT_YEAR}" & vbCrLf & _
          "AND STUDENT_ID = {s_STUDENT_ID}" & vbCrLf & _
          "AND ( ENROLMENT_STATUS ='N' )" & vbCrLf & _
          "AND ( COMMENT_TYPE LIKE '%{s_ENROLMENT_YEAR}'" & vbCrLf & _
          "OR COMMENT_TYPE IS NULL )  {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
        Update=new SpCommand("USP_StudentExitTrack;1",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record Student_Exit Data Provider Class Constructor

'Record Student_Exit Data Provider Class LoadParams Method @2-B45586B2

    Protected Function LoadParams() As Boolean
        Return True
    End Function
'End Record Student_Exit Data Provider Class LoadParams Method

'Record Student_Exit Data Provider Class CheckUnique Method @2-C1C82179

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As Student_ExitItem) As Boolean
        Return True
    End Function
'End Record Student_Exit Data Provider Class CheckUnique Method

'Record Student_Exit Data Provider Class PrepareUpdate Method @2-0A131024

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
'End Record Student_Exit Data Provider Class PrepareUpdate Method

'Record Student_Exit Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record Student_Exit Data Provider Class PrepareUpdate Method tail

'Record Student_Exit Data Provider Class Update Method @2-EFBDEFCC

    Public Function UpdateItem(ByVal item As Student_ExitItem) As Integer
        Me.item = item
'End Record Student_Exit Data Provider Class Update Method

'Record Student_Exit BeforeBuildUpdate @2-B1BAB3F9
        Update.Parameters.Clear()
        CType(Update,SpCommand).AddParameter("@RETURN_VALUE",UrlRETURN_VALUE,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
        CType(Update,SpCommand).AddParameter("@CommentID",item.Hidden_CommentID,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Update,SpCommand).AddParameter("@Student_id",Urls_STUDENT_ID,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Update,SpCommand).AddParameter("@EnrolmentYear",Urls_ENROLMENT_YEAR,ParameterType._Numeric,ParameterDirection.Input,0,0,18)
        CType(Update,SpCommand).AddParameter("@ExitDestination",item.lbEXIT_DESTINATION,ParameterType._Int,ParameterDirection.Input,0,0,10)
        CType(Update,SpCommand).AddParameter("@Comment",item.TextAreaComments,ParameterType._VarChar,ParameterDirection.Input,500,0,10)
        CType(Update,SpCommand).AddParameter("@LastAlteredBy",item.TXT_LastAlteredBy,ParameterType._Char,ParameterDirection.Input,8,0,10)
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
            result = ExecuteUpdate()
            UrlRETURN_VALUE = IntegerParameter.GetParam(CType(Update.Parameters("@RETURN_VALUE"),IDataParameter).Value)
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record Student_Exit BeforeBuildUpdate

'Record Student_Exit AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record Student_Exit AfterExecuteUpdate

'Record Student_Exit Data Provider Class GetResultSet Method @2-8221D9FA

    Public Sub FillItem(ByVal item As Student_ExitItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record Student_Exit Data Provider Class GetResultSet Method

'Record Student_Exit BeforeBuildSelect @2-1DC4B1EE
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("s_ENROLMENT_YEAR",Urls_ENROLMENT_YEAR, "")
        CType(Select_,SqlCommand).AddParameter("s_STUDENT_ID",Urls_STUDENT_ID, "")
        IsInsertMode = (IsNothing(Urls_ENROLMENT_YEAR) Or IsNothing(Urls_STUDENT_ID))
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record Student_Exit BeforeBuildSelect

'Record Student_Exit BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record Student_Exit BeforeExecuteSelect

'Record Student_Exit AfterExecuteSelect @2-7C6CD025
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.Lbl_Name.SetValue(dr(i)("Name"),"")
            item.Lbl_StudentID.SetValue(dr(i)("STUDENT_ID"),"")
            item.Lbl_WithDrawnReason.SetValue(dr(i)("Reason"),"")
            item.Lbl_WithDrawnDate.SetValue(dr(i)("WITHDRAWAL_DATE"),Select_.DateFormat)
            item.lbEXIT_DESTINATION.SetValue(dr(i)("WITHDRAWAL_EXIT_DESTINATION"),"")
            item.TextAreaComments.SetValue(dr(i)("COMMENT"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.Hidden_CommentID.SetValue(dr(i)("COMMENT_ID"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record Student_Exit AfterExecuteSelect

'ListBox lbEXIT_DESTINATION Initialize Data Source @17-37D4B801
        lbEXIT_DESTINATIONDataCommand.Dao._optimized = False
        Dim lbEXIT_DESTINATIONtableIndex As Integer = 0
        lbEXIT_DESTINATIONDataCommand.OrderBy = "DISPLAY_ORDER"
        lbEXIT_DESTINATIONDataCommand.Parameters.Clear()
        lbEXIT_DESTINATIONDataCommand.Parameters.Add("expr18","(DISPLAY_ORDER > 0)")
'End ListBox lbEXIT_DESTINATION Initialize Data Source

'ListBox lbEXIT_DESTINATION BeforeExecuteSelect @17-A836CBCE
        Try
            ListBoxSource=lbEXIT_DESTINATIONDataCommand.Execute().Tables(lbEXIT_DESTINATIONtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox lbEXIT_DESTINATION BeforeExecuteSelect

'ListBox lbEXIT_DESTINATION AfterExecuteSelect @17-12F2372D
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New FloatField("", ListBoxSource(j)("WD_DEST_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("EXIT_DESTINATION_DESCRIPTION")
            item.lbEXIT_DESTINATIONItems.Add(Key, Val)
        Next
'End ListBox lbEXIT_DESTINATION AfterExecuteSelect

'Record Student_Exit AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record Student_Exit AfterExecuteSelect tail

'Record Student_Exit Data Provider Class @2-A61BA892
End Class

'End Record Student_Exit Data Provider Class

'Record viewMaintainSearchRequest Item Class @59-169FBB96
Public Class viewMaintainSearchRequestItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public s_STUDENT_ID As FloatField
    Public s_ENROLMENT_YEAR As IntegerField
    Public Sub New()
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    s_STUDENT_ID = New FloatField("", Nothing)
    s_ENROLMENT_YEAR = New IntegerField("", Year(Today()))
    End Sub

    Public Shared Function CreateFromHttpRequest() As viewMaintainSearchRequestItem
        Dim item As viewMaintainSearchRequestItem = New viewMaintainSearchRequestItem()
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_STUDENT_ID")) Then
        item.s_STUDENT_ID.SetValue(DBUtility.GetInitialValue("s_STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_ENROLMENT_YEAR")) Then
        item.s_ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("s_ENROLMENT_YEAR"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "ClearParameters"
                    Return ClearParameters
                Case "s_STUDENT_ID"
                    Return s_STUDENT_ID
                Case "s_ENROLMENT_YEAR"
                    Return s_ENROLMENT_YEAR
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ClearParameters"
                    ClearParameters = CType(value, TextField)
                Case "s_STUDENT_ID"
                    s_STUDENT_ID = CType(value, FloatField)
                Case "s_ENROLMENT_YEAR"
                    s_ENROLMENT_YEAR = CType(value, IntegerField)
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

    Public Sub Validate(ByVal provider As viewMaintainSearchRequestDataProvider)
'End Record viewMaintainSearchRequest Item Class

's_STUDENT_ID validate @62-D3277739
        If IsNothing(s_STUDENT_ID.Value) OrElse s_STUDENT_ID.Value.ToString() ="" Then
            errors.Add("s_STUDENT_ID",String.Format(Resources.strings.CCS_RequiredField,"STUDENT ID"))
        End If
'End s_STUDENT_ID validate

's_ENROLMENT_YEAR validate @63-F3E9BDCA
        If IsNothing(s_ENROLMENT_YEAR.Value) OrElse s_ENROLMENT_YEAR.Value.ToString() ="" Then
            errors.Add("s_ENROLMENT_YEAR",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT YEAR"))
        End If
        If (Not IsNothing(s_ENROLMENT_YEAR.Value)) And (Not s_ENROLMENT_YEAR.Value >= (Year(Today())-2)) Then
            errors.Add("s_ENROLMENT_YEAR","Please, something recent, like in the last 3 years?")
        End If
'End s_ENROLMENT_YEAR validate

'Record viewMaintainSearchRequest Item Class tail @59-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record viewMaintainSearchRequest Item Class tail

'Record viewMaintainSearchRequest Data Provider Class @59-77F14331
Public Class viewMaintainSearchRequestDataProvider
Inherits RecordDataProviderBase
'End Record viewMaintainSearchRequest Data Provider Class

'Record viewMaintainSearchRequest Data Provider Class Variables @59-5C619156
    Protected item As viewMaintainSearchRequestItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record viewMaintainSearchRequest Data Provider Class Variables

'Record viewMaintainSearchRequest Data Provider Class GetResultSet Method @59-D5AB571D

    Public Sub FillItem(ByVal item As viewMaintainSearchRequestItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record viewMaintainSearchRequest Data Provider Class GetResultSet Method

'Record viewMaintainSearchRequest BeforeBuildSelect @59-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record viewMaintainSearchRequest BeforeBuildSelect

'Record viewMaintainSearchRequest AfterExecuteSelect @59-79426A21
        End If
            IsInsertMode = True
'End Record viewMaintainSearchRequest AfterExecuteSelect

'Record viewMaintainSearchRequest AfterExecuteSelect tail @59-E31F8E2A
    End Sub
'End Record viewMaintainSearchRequest AfterExecuteSelect tail

'Record viewMaintainSearchRequest Data Provider Class @59-A61BA892
End Class

'End Record viewMaintainSearchRequest Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

