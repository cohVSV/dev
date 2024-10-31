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

Namespace DECV_PROD2007.Student_Equipment_maintain 'Namespace @1-76AAA24A

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

'Record STUDENT_EQUIPMENT Item Class @2-4147D899
Public Class STUDENT_EQUIPMENTItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public HAS_COMPUTER As TextField
    Public HAS_COMPUTERItems As ItemCollection
    Public HAS_VCR As TextField
    Public HAS_VCRItems As ItemCollection
    Public HAS_DVD As TextField
    Public HAS_DVDItems As ItemCollection
    Public HAS_INTERNET_ACCESS As TextField
    Public HAS_INTERNET_ACCESSItems As ItemCollection
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public HAS_BROADBAND As TextField
    Public HAS_BROADBANDItems As ItemCollection
    Public NEWSLETTER_BYMAIL As TextField
    Public NEWSLETTER_BYMAILCheckedValue As TextField
    Public NEWSLETTER_BYMAILUncheckedValue As TextField
    Public Hidden_lastalteredby As TextField
    Public Hidden_lastaltereddate As DateField
    Public SHARES_COMPUTER As TextField
    Public SHARES_COMPUTERItems As ItemCollection
    Public LIMITED_INTERNET_ACCESS As TextField
    Public LIMITED_INTERNET_ACCESSItems As ItemCollection
    Public HAS_DER_PC As TextField
    Public HAS_DER_PCItems As ItemCollection
    Public lblStudentNo As TextField
    Public ACCESS_COMPUTER As TextField
    Public ACCESS_COMPUTERItems As ItemCollection
    Public ACCESS_INTERNET As TextField
    Public ACCESS_INTERNETItems As ItemCollection
    Public ACCESS_WORKEXAMPLES_radio As TextField
    Public ACCESS_WORKEXAMPLES_radioItems As ItemCollection
    Public Sub New()
    HAS_COMPUTER = New TextField("", "U")
    HAS_COMPUTERItems = New ItemCollection()
    HAS_VCR = New TextField("", "U")
    HAS_VCRItems = New ItemCollection()
    HAS_DVD = New TextField("", "U")
    HAS_DVDItems = New ItemCollection()
    HAS_INTERNET_ACCESS = New TextField("", "U")
    HAS_INTERNET_ACCESSItems = New ItemCollection()
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    HAS_BROADBAND = New TextField("", "U")
    HAS_BROADBANDItems = New ItemCollection()
    NEWSLETTER_BYMAIL = New TextField("", "N")
    NEWSLETTER_BYMAILCheckedValue = New TextField("", "Y")
    NEWSLETTER_BYMAILUncheckedValue = New TextField("", "N")
    Hidden_lastalteredby = New TextField("", DBUtility.UserLogin.ToUpper)
    Hidden_lastaltereddate = New DateField("yyyy-MM-dd H\:mm", DateTime.Now)
    SHARES_COMPUTER = New TextField("", "U")
    SHARES_COMPUTERItems = New ItemCollection()
    LIMITED_INTERNET_ACCESS = New TextField("", "U")
    LIMITED_INTERNET_ACCESSItems = New ItemCollection()
    HAS_DER_PC = New TextField("", "ZZ")
    HAS_DER_PCItems = New ItemCollection()
    lblStudentNo = New TextField("", Nothing)
    ACCESS_COMPUTER = New TextField("", "U")
    ACCESS_COMPUTERItems = New ItemCollection()
    ACCESS_INTERNET = New TextField("", "U")
    ACCESS_INTERNETItems = New ItemCollection()
    ACCESS_WORKEXAMPLES_radio = New TextField("", Nothing)
    ACCESS_WORKEXAMPLES_radioItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_EQUIPMENTItem
        Dim item As STUDENT_EQUIPMENTItem = New STUDENT_EQUIPMENTItem()
        If Not IsNothing(DBUtility.GetInitialValue("HAS_COMPUTER")) Then
        item.HAS_COMPUTER.SetValue(DBUtility.GetInitialValue("HAS_COMPUTER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("HAS_VCR")) Then
        item.HAS_VCR.SetValue(DBUtility.GetInitialValue("HAS_VCR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("HAS_DVD")) Then
        item.HAS_DVD.SetValue(DBUtility.GetInitialValue("HAS_DVD"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("HAS_INTERNET_ACCESS")) Then
        item.HAS_INTERNET_ACCESS.SetValue(DBUtility.GetInitialValue("HAS_INTERNET_ACCESS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("HAS_BROADBAND")) Then
        item.HAS_BROADBAND.SetValue(DBUtility.GetInitialValue("HAS_BROADBAND"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("NEWSLETTER_BYMAIL")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("NEWSLETTER_BYMAIL")) Then
            item.NEWSLETTER_BYMAIL.Value = item.NEWSLETTER_BYMAILCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_lastalteredby")) Then
        item.Hidden_lastalteredby.SetValue(DBUtility.GetInitialValue("Hidden_lastalteredby"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_lastaltereddate")) Then
        item.Hidden_lastaltereddate.SetValue(DBUtility.GetInitialValue("Hidden_lastaltereddate"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SHARES_COMPUTER")) Then
        item.SHARES_COMPUTER.SetValue(DBUtility.GetInitialValue("SHARES_COMPUTER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LIMITED_INTERNET_ACCESS")) Then
        item.LIMITED_INTERNET_ACCESS.SetValue(DBUtility.GetInitialValue("LIMITED_INTERNET_ACCESS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("HAS_DER_PC")) Then
        item.HAS_DER_PC.SetValue(DBUtility.GetInitialValue("HAS_DER_PC"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblStudentNo")) Then
        item.lblStudentNo.SetValue(DBUtility.GetInitialValue("lblStudentNo"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ACCESS_COMPUTER")) Then
        item.ACCESS_COMPUTER.SetValue(DBUtility.GetInitialValue("ACCESS_COMPUTER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ACCESS_INTERNET")) Then
        item.ACCESS_INTERNET.SetValue(DBUtility.GetInitialValue("ACCESS_INTERNET"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ACCESS_WORKEXAMPLES_radio")) Then
        item.ACCESS_WORKEXAMPLES_radio.SetValue(DBUtility.GetInitialValue("ACCESS_WORKEXAMPLES_radio"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "HAS_COMPUTER"
                    Return HAS_COMPUTER
                Case "HAS_VCR"
                    Return HAS_VCR
                Case "HAS_DVD"
                    Return HAS_DVD
                Case "HAS_INTERNET_ACCESS"
                    Return HAS_INTERNET_ACCESS
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "HAS_BROADBAND"
                    Return HAS_BROADBAND
                Case "NEWSLETTER_BYMAIL"
                    Return NEWSLETTER_BYMAIL
                Case "Hidden_lastalteredby"
                    Return Hidden_lastalteredby
                Case "Hidden_lastaltereddate"
                    Return Hidden_lastaltereddate
                Case "SHARES_COMPUTER"
                    Return SHARES_COMPUTER
                Case "LIMITED_INTERNET_ACCESS"
                    Return LIMITED_INTERNET_ACCESS
                Case "HAS_DER_PC"
                    Return HAS_DER_PC
                Case "lblStudentNo"
                    Return lblStudentNo
                Case "ACCESS_COMPUTER"
                    Return ACCESS_COMPUTER
                Case "ACCESS_INTERNET"
                    Return ACCESS_INTERNET
                Case "ACCESS_WORKEXAMPLES_radio"
                    Return ACCESS_WORKEXAMPLES_radio
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "HAS_COMPUTER"
                    HAS_COMPUTER = CType(value, TextField)
                Case "HAS_VCR"
                    HAS_VCR = CType(value, TextField)
                Case "HAS_DVD"
                    HAS_DVD = CType(value, TextField)
                Case "HAS_INTERNET_ACCESS"
                    HAS_INTERNET_ACCESS = CType(value, TextField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "HAS_BROADBAND"
                    HAS_BROADBAND = CType(value, TextField)
                Case "NEWSLETTER_BYMAIL"
                    NEWSLETTER_BYMAIL = CType(value, TextField)
                Case "Hidden_lastalteredby"
                    Hidden_lastalteredby = CType(value, TextField)
                Case "Hidden_lastaltereddate"
                    Hidden_lastaltereddate = CType(value, DateField)
                Case "SHARES_COMPUTER"
                    SHARES_COMPUTER = CType(value, TextField)
                Case "LIMITED_INTERNET_ACCESS"
                    LIMITED_INTERNET_ACCESS = CType(value, TextField)
                Case "HAS_DER_PC"
                    HAS_DER_PC = CType(value, TextField)
                Case "lblStudentNo"
                    lblStudentNo = CType(value, TextField)
                Case "ACCESS_COMPUTER"
                    ACCESS_COMPUTER = CType(value, TextField)
                Case "ACCESS_INTERNET"
                    ACCESS_INTERNET = CType(value, TextField)
                Case "ACCESS_WORKEXAMPLES_radio"
                    ACCESS_WORKEXAMPLES_radio = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STUDENT_EQUIPMENTDataProvider)
'End Record STUDENT_EQUIPMENT Item Class

'NEWSLETTER_BYMAIL validate @15-CF97FE76
        If IsNothing(NEWSLETTER_BYMAIL.Value) OrElse NEWSLETTER_BYMAIL.Value.ToString() ="" Then
            errors.Add("NEWSLETTER_BYMAIL",String.Format(Resources.strings.CCS_RequiredField,"Newsletter by POST ONLY"))
        End If
'End NEWSLETTER_BYMAIL validate

'ACCESS_COMPUTER validate @24-201D7F49
        If IsNothing(ACCESS_COMPUTER.Value) OrElse ACCESS_COMPUTER.Value.ToString() ="" Then
            errors.Add("ACCESS_COMPUTER",String.Format(Resources.strings.CCS_RequiredField,"Access to a COMPUTER"))
        End If
'End ACCESS_COMPUTER validate

'ACCESS_INTERNET validate @25-02449F5A
        If IsNothing(ACCESS_INTERNET.Value) OrElse ACCESS_INTERNET.Value.ToString() ="" Then
            errors.Add("ACCESS_INTERNET",String.Format(Resources.strings.CCS_RequiredField,"Access to the INTERNET"))
        End If
'End ACCESS_INTERNET validate

'ACCESS_WORKEXAMPLES_radio validate @26-C289A971
        If IsNothing(ACCESS_WORKEXAMPLES_radio.Value) OrElse ACCESS_WORKEXAMPLES_radio.Value.ToString() ="" Then
            errors.Add("ACCESS_WORKEXAMPLES_radio",String.Format(Resources.strings.CCS_RequiredField,"Permission to access Student WORK EXAMPLES"))
        End If
'End ACCESS_WORKEXAMPLES_radio validate

'Record STUDENT_EQUIPMENT Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_EQUIPMENT Item Class tail

'Record STUDENT_EQUIPMENT Data Provider Class @2-9EE5CB6B
Public Class STUDENT_EQUIPMENTDataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_EQUIPMENT Data Provider Class

'Record STUDENT_EQUIPMENT Data Provider Class Variables @2-B3743E4D
    Public UrlSTUDENT_ID As FloatParameter
    Protected item As STUDENT_EQUIPMENTItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_EQUIPMENT Data Provider Class Variables

'Record STUDENT_EQUIPMENT Data Provider Class Constructor @2-42B81CCD

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_EQUIPMENT {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID5"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_EQUIPMENT Data Provider Class Constructor

'Record STUDENT_EQUIPMENT Data Provider Class LoadParams Method @2-A977A0E9

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID))
    End Function
'End Record STUDENT_EQUIPMENT Data Provider Class LoadParams Method

'Record STUDENT_EQUIPMENT Data Provider Class CheckUnique Method @2-DCD44B45

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_EQUIPMENTItem) As Boolean
        Return True
    End Function
'End Record STUDENT_EQUIPMENT Data Provider Class CheckUnique Method

'Record STUDENT_EQUIPMENT Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STUDENT_EQUIPMENT Data Provider Class PrepareUpdate Method

'Record STUDENT_EQUIPMENT Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record STUDENT_EQUIPMENT Data Provider Class PrepareUpdate Method tail

'Record STUDENT_EQUIPMENT Data Provider Class Update Method @2-50A0A31B

    Public Function UpdateItem(ByVal item As STUDENT_EQUIPMENTItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT_EQUIPMENT SET {Values}", New String(){"STUDENT_ID5"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_EQUIPMENT Data Provider Class Update Method

'Record STUDENT_EQUIPMENT BeforeBuildUpdate @2-1C5440D9
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID5",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        If Not item.HAS_COMPUTER.IsEmpty Then
        allEmptyFlag = item.HAS_COMPUTER.IsEmpty And allEmptyFlag
        valuesList = valuesList & "HAS_COMPUTER=" + Update.Dao.ToSql(item.HAS_COMPUTER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.HAS_VCR.IsEmpty Then
        allEmptyFlag = item.HAS_VCR.IsEmpty And allEmptyFlag
        valuesList = valuesList & "HAS_VCR=" + Update.Dao.ToSql(item.HAS_VCR.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.HAS_DVD.IsEmpty Then
        allEmptyFlag = item.HAS_DVD.IsEmpty And allEmptyFlag
        valuesList = valuesList & "HAS_DVD=" + Update.Dao.ToSql(item.HAS_DVD.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.HAS_INTERNET_ACCESS.IsEmpty Then
        allEmptyFlag = item.HAS_INTERNET_ACCESS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "HAS_INTERNET_ACCESS=" + Update.Dao.ToSql(item.HAS_INTERNET_ACCESS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.HAS_BROADBAND.IsEmpty Then
        allEmptyFlag = item.HAS_BROADBAND.IsEmpty And allEmptyFlag
        valuesList = valuesList & "HAS_BROADBAND=" + Update.Dao.ToSql(item.HAS_BROADBAND.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.NEWSLETTER_BYMAIL.IsEmpty Then
        allEmptyFlag = item.NEWSLETTER_BYMAIL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "NEWSLETTER_BYMAIL=" + Update.Dao.ToSql(item.NEWSLETTER_BYMAIL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_lastalteredby.IsEmpty Then
        allEmptyFlag = item.Hidden_lastalteredby.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.Hidden_lastalteredby.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_lastaltereddate.IsEmpty Then
        allEmptyFlag = item.Hidden_lastaltereddate.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.Hidden_lastaltereddate.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.SHARES_COMPUTER.IsEmpty Then
        allEmptyFlag = item.SHARES_COMPUTER.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SHARES_COMPUTER=" + Update.Dao.ToSql(item.SHARES_COMPUTER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LIMITED_INTERNET_ACCESS.IsEmpty Then
        allEmptyFlag = item.LIMITED_INTERNET_ACCESS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LIMITED_INTERNET_ACCESS=" + Update.Dao.ToSql(item.LIMITED_INTERNET_ACCESS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.HAS_DER_PC.IsEmpty Then
        allEmptyFlag = item.HAS_DER_PC.IsEmpty And allEmptyFlag
        valuesList = valuesList & "HAS_DER_PC=" + Update.Dao.ToSql(item.HAS_DER_PC.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ACCESS_COMPUTER.IsEmpty Then
        allEmptyFlag = item.ACCESS_COMPUTER.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ACCESS_COMPUTER_2010=" + Update.Dao.ToSql(item.ACCESS_COMPUTER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ACCESS_INTERNET.IsEmpty Then
        allEmptyFlag = item.ACCESS_INTERNET.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ACCESS_INTERNET_2010=" + Update.Dao.ToSql(item.ACCESS_INTERNET.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ACCESS_WORKEXAMPLES_radio.IsEmpty Then
        allEmptyFlag = item.ACCESS_WORKEXAMPLES_radio.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ACCESS_WORKEXAMPLES=" + Update.Dao.ToSql(item.ACCESS_WORKEXAMPLES_radio.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record STUDENT_EQUIPMENT BeforeBuildUpdate

'Record STUDENT_EQUIPMENT AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_EQUIPMENT AfterExecuteUpdate

'Record STUDENT_EQUIPMENT Data Provider Class GetResultSet Method @2-85EDFD1D

    Public Sub FillItem(ByVal item As STUDENT_EQUIPMENTItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_EQUIPMENT Data Provider Class GetResultSet Method

'Record STUDENT_EQUIPMENT BeforeBuildSelect @2-21BE94D9
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID5",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_EQUIPMENT BeforeBuildSelect

'Record STUDENT_EQUIPMENT BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_EQUIPMENT BeforeExecuteSelect

'Record STUDENT_EQUIPMENT AfterExecuteSelect @2-2DD4A7FD
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.HAS_COMPUTER.SetValue(dr(i)("HAS_COMPUTER"),"")
            item.HAS_VCR.SetValue(dr(i)("HAS_VCR"),"")
            item.HAS_DVD.SetValue(dr(i)("HAS_DVD"),"")
            item.HAS_INTERNET_ACCESS.SetValue(dr(i)("HAS_INTERNET_ACCESS"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.HAS_BROADBAND.SetValue(dr(i)("HAS_BROADBAND"),"")
            item.NEWSLETTER_BYMAIL.SetValue(dr(i)("NEWSLETTER_BYMAIL"),"")
            item.Hidden_lastalteredby.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.Hidden_lastaltereddate.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.SHARES_COMPUTER.SetValue(dr(i)("SHARES_COMPUTER"),"")
            item.LIMITED_INTERNET_ACCESS.SetValue(dr(i)("LIMITED_INTERNET_ACCESS"),"")
            item.HAS_DER_PC.SetValue(dr(i)("HAS_DER_PC"),"")
            item.lblStudentNo.SetValue(dr(i)("STUDENT_ID"),"")
            item.ACCESS_COMPUTER.SetValue(dr(i)("ACCESS_COMPUTER_2010"),"")
            item.ACCESS_INTERNET.SetValue(dr(i)("ACCESS_INTERNET_2010"),"")
            item.ACCESS_WORKEXAMPLES_radio.SetValue(dr(i)("ACCESS_WORKEXAMPLES"),"")
        Else
            IsInsertMode = True
        End If
'End Record STUDENT_EQUIPMENT AfterExecuteSelect

'ListBox HAS_COMPUTER AfterExecuteSelect @6-18B7A30B
        
item.HAS_COMPUTERItems.Add("Y","Yes")
item.HAS_COMPUTERItems.Add("N","No")
item.HAS_COMPUTERItems.Add("U","Unknown")
'End ListBox HAS_COMPUTER AfterExecuteSelect

'ListBox HAS_VCR AfterExecuteSelect @7-C0C9B3E7
        
item.HAS_VCRItems.Add("Y","Yes")
item.HAS_VCRItems.Add("N","No")
item.HAS_VCRItems.Add("U","Unknown")
'End ListBox HAS_VCR AfterExecuteSelect

'ListBox HAS_DVD AfterExecuteSelect @8-EA4F0644
        
item.HAS_DVDItems.Add("Y","Yes")
item.HAS_DVDItems.Add("N","No")
item.HAS_DVDItems.Add("U","Unknown")
'End ListBox HAS_DVD AfterExecuteSelect

'ListBox HAS_INTERNET_ACCESS AfterExecuteSelect @9-64B15192
        
item.HAS_INTERNET_ACCESSItems.Add("Y","Yes")
item.HAS_INTERNET_ACCESSItems.Add("N","No")
item.HAS_INTERNET_ACCESSItems.Add("U","Unknown")
'End ListBox HAS_INTERNET_ACCESS AfterExecuteSelect

'ListBox HAS_BROADBAND AfterExecuteSelect @13-A22C7527
        
item.HAS_BROADBANDItems.Add("Y","Yes")
item.HAS_BROADBANDItems.Add("N","No")
item.HAS_BROADBANDItems.Add("U","Unknown")
'End ListBox HAS_BROADBAND AfterExecuteSelect

'ListBox SHARES_COMPUTER AfterExecuteSelect @20-E86268FA
        
item.SHARES_COMPUTERItems.Add("Y","Yes")
item.SHARES_COMPUTERItems.Add("N","No")
item.SHARES_COMPUTERItems.Add("U","Unknown")
'End ListBox SHARES_COMPUTER AfterExecuteSelect

'ListBox LIMITED_INTERNET_ACCESS AfterExecuteSelect @21-1225DA5E
        
item.LIMITED_INTERNET_ACCESSItems.Add("Y","Yes")
item.LIMITED_INTERNET_ACCESSItems.Add("N","No")
item.LIMITED_INTERNET_ACCESSItems.Add("U","Unknown")
'End ListBox LIMITED_INTERNET_ACCESS AfterExecuteSelect

'ListBox HAS_DER_PC AfterExecuteSelect @22-6689B6F5
        
item.HAS_DER_PCItems.Add("KD1","DER Desktop")
item.HAS_DER_PCItems.Add("KN1","DER Notebook")
item.HAS_DER_PCItems.Add("DN1","VSV Notebook")
item.HAS_DER_PCItems.Add("RTN","Returned to VSV")
item.HAS_DER_PCItems.Add("ZZ","None")
'End ListBox HAS_DER_PC AfterExecuteSelect

'ListBox ACCESS_COMPUTER AfterExecuteSelect @24-CFDD4018
        
item.ACCESS_COMPUTERItems.Add("N","No")
item.ACCESS_COMPUTERItems.Add("Y","Yes, my own")
item.ACCESS_COMPUTERItems.Add("L","Yes, Limited or shared")
item.ACCESS_COMPUTERItems.Add("U","Unknown")
'End ListBox ACCESS_COMPUTER AfterExecuteSelect

'ListBox ACCESS_INTERNET AfterExecuteSelect @25-2D164A59
        
item.ACCESS_INTERNETItems.Add("N","No")
item.ACCESS_INTERNETItems.Add("Y","Yes (Full: ADSL at home, Cable)")
item.ACCESS_INTERNETItems.Add("L","Yes (Limited: dial-up, 3G, Library, etc)")
item.ACCESS_INTERNETItems.Add("U","Unknown")
'End ListBox ACCESS_INTERNET AfterExecuteSelect

'ListBox ACCESS_WORKEXAMPLES_radio AfterExecuteSelect @26-AA121EC2
        
item.ACCESS_WORKEXAMPLES_radioItems.Add("Y","Yes")
item.ACCESS_WORKEXAMPLES_radioItems.Add("N","No")
'End ListBox ACCESS_WORKEXAMPLES_radio AfterExecuteSelect

'Record STUDENT_EQUIPMENT AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record STUDENT_EQUIPMENT AfterExecuteSelect tail

'Record STUDENT_EQUIPMENT Data Provider Class @2-A61BA892
End Class

'End Record STUDENT_EQUIPMENT Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

