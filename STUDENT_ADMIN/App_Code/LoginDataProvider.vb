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

Namespace DECV_PROD2007.Login 'Namespace @1-46F8C514

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

'Record Login Item Class @2-F39FEB18
Public Class LoginItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public login As TextField
    Public password As TextField
    Public cb_rememberme As BooleanField
    Public cb_remembermeCheckedValue As BooleanField
    Public cb_remembermeUncheckedValue As BooleanField
    Public Sub New()
    login = New TextField("", Nothing)
    password = New TextField("", Nothing)
    cb_rememberme = New BooleanField(Settings.BoolFormat, True)
    cb_remembermeCheckedValue = New BooleanField(Settings.BoolFormat, True)
    cb_remembermeUncheckedValue = New BooleanField(Settings.BoolFormat, False)
    End Sub

    Public Shared Function CreateFromHttpRequest() As LoginItem
        Dim item As LoginItem = New LoginItem()
        If Not IsNothing(DBUtility.GetInitialValue("login")) Then
        item.login.SetValue(DBUtility.GetInitialValue("login"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("password")) Then
        item.password.SetValue(DBUtility.GetInitialValue("password"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoLogin")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("cb_rememberme")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("cb_rememberme")) Then
            item.cb_rememberme.Value = item.cb_remembermeCheckedValue.Value
        End If
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "login"
                    Return login
                Case "password"
                    Return password
                Case "cb_rememberme"
                    Return cb_rememberme
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "login"
                    login = CType(value, TextField)
                Case "password"
                    password = CType(value, TextField)
                Case "cb_rememberme"
                    cb_rememberme = CType(value, BooleanField)
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

    Public Sub Validate(ByVal provider As LoginDataProvider)
'End Record Login Item Class

'login validate @5-9408DD0A
        If IsNothing(login.Value) OrElse login.Value.ToString() ="" Then
            errors.Add("login",String.Format(Resources.strings.CCS_RequiredField,"Login"))
        End If
'End login validate

'password validate @6-9C15B085
        If IsNothing(password.Value) OrElse password.Value.ToString() ="" Then
            errors.Add("password",String.Format(Resources.strings.CCS_RequiredField,"Password"))
        End If
'End password validate

'Record Login Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record Login Item Class tail

'Record Login Data Provider Class @2-F8165A93
Public Class LoginDataProvider
Inherits RecordDataProviderBase
'End Record Login Data Provider Class

'Record Login Data Provider Class Variables @2-01744C2B
    Protected item As LoginItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record Login Data Provider Class Variables

'Record Login Data Provider Class GetResultSet Method @2-14E73F82

    Public Sub FillItem(ByVal item As LoginItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record Login Data Provider Class GetResultSet Method

'Record Login BeforeBuildSelect @2-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record Login BeforeBuildSelect

'Record Login AfterExecuteSelect @2-79426A21
        End If
            IsInsertMode = True
'End Record Login AfterExecuteSelect

'Record Login AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record Login AfterExecuteSelect tail

'Record Login Data Provider Class @2-A61BA892
End Class

'End Record Login Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

