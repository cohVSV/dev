'Security Class @0-BCD674C7
'Target Framework version is 3.5
Imports System
Imports System.Data
Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Web
Imports DECV_PROD2007.Configuration
Imports DECV_PROD2007.Data
Namespace DECV_PROD2007.Security
    Public Structure GroupRight
        Public GroupId As String
        Public Read As Boolean
        Public Insert As Boolean
        Public Update As Boolean
        Public Delete As Boolean

        Public Sub New(ByVal _GroupId As String, ByVal _Read As Boolean)
            MyClass.New(_GroupId, _Read, False, False, False)
        End Sub 'New

        Public Sub New(ByVal _GroupId As String, ByVal _Read As Boolean, ByVal _Insert As Boolean, ByVal _Update As Boolean, ByVal _Delete As Boolean)
            GroupId = _GroupId
            Read = _Read
            Insert = _Insert
            Update = _Update
            Delete = _Delete
        End Sub 'New
    End Structure 'GroupRight

Public Class SecurityUtility
   
   Public Shared Sub SetSecurityCookies(login As String, password As String, createPersistentCookie As Boolean)
		Dim timeout As DateTime = DateTime.Now
		If System.Configuration.ConfigurationManager.AppSettings("LoginCookieExpiration") Is Nothing Then
			timeout = timeout.AddMinutes(HttpContext.Current.Session.Timeout)
		Else
			timeout = timeout.AddDays(Int32.Parse(System.Configuration.ConfigurationManager.AppSettings("LoginCookieExpiration")))
		End If
	  Dim ticket As New System.Web.Security.FormsAuthenticationTicket(1, login, DateTime.Now, timeout, createPersistentCookie, password, System.Web.Security.FormsAuthentication.FormsCookiePath)
      Dim encTicket As String = System.Web.Security.FormsAuthentication.Encrypt(ticket)
      Dim c As New HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, encTicket)
	  
      c.HttpOnly = True
	  
      c.Path = ticket.CookiePath
      If ticket.IsPersistent Then
         c.Expires = ticket.Expiration
      End If
      HttpContext.Current.Response.Cookies.Add(c)
   End Sub
   
   
   Public Shared Sub ClearSecurityCookies()
      System.Web.Security.FormsAuthentication.SignOut()
   End Sub

	Public Shared Function EncryptPassword(password As String) As String
		If ConfigurationManager.AppSettings("ProtectPasswordsMethod")="DBFunction" Then
			Return password
		ElseIf ConfigurationManager.AppSettings("ProtectPasswordsMethod")="CodeExpression" Then
			Return password
		Else
			Return password
		End If
	End Function

	Public Shared Function GetDBPasswordExpression(password As String) As String
		If ConfigurationManager.AppSettings("ProtectPasswordsMethod")="DBFunction" Then
			
            Return String.Format("{0}({1})",ConfigurationManager.AppSettings("ProtectPasswordsExpression"), password,FieldType._Text)
		End If
		Return password
	End Function

	Public Shared Function MD5(password As String) As String
            Dim source(255) As Byte
            Dim hash(255) As Byte
            source = System.Text.ASCIIEncoding.ASCII.GetBytes(password)
            hash = New System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(source)
            Dim output As System.Text.StringBuilder = New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To hash.Length - 1
                output.Append(hash(i).ToString("x2"))
            Next i
            Return output.ToString()
        End Function          

End Class


    Public Class FormSupportedOperations
        Private _isSecured As Boolean = False
        Private _rights() As GroupRight

        Private Enum AccessIdentifier
            Read
            Insert
            Update
            Delete
        End Enum 'AccessIdentifier

        Private _AllowRead As Boolean = False
        Private _AllowInsert As Boolean = False
        Private _AllowUpdate As Boolean = False
        Private _AllowDelete As Boolean = False

        Private Function AllowCheck(ByVal ai As AccessIdentifier) As Boolean
            If Not IsNothing(_rights) Then
                Dim id(_rights.Length - 1) As String
                Dim i As Integer
                For i = 0 To _rights.Length - 1
                    id(i) = _rights(i).GroupId
                Next i
                If Not DBUtility.AuthorizeUser(id) Then Return False
                For i = _rights.Length - 1 To 0 Step -1
                If DBUtility.IsGroupsNested And Int32.Parse(DBUtility.UserGroup) >= Int32.Parse(_rights(i).GroupId) Or (Not DBUtility.IsGroupsNested And DBUtility.UserGroup = _rights(i).GroupId) Then
                    If _rights(i).Read Then
                        _AllowRead = True
                    End If
                    If _rights(i).Insert Then
                        _AllowInsert = True
                    End If
                    If _rights(i).Update Then
                        _AllowUpdate = True
                    End If
                    If _rights(i).Delete Then
                        _AllowDelete = True
                    End If
                End If
                Next i
            Else
                If _isSecured And Not DBUtility.AuthorizeUser() Then
                    Return False
                End If
            End If
            Select Case ai
                Case AccessIdentifier.Read
                    Return _AllowRead
                Case AccessIdentifier.Insert
                    Return _AllowInsert
                Case AccessIdentifier.Update
                    Return _AllowUpdate
                Case AccessIdentifier.Delete
                    Return _AllowDelete
                Case Else
                    Return False
            End Select
        End Function 'AllowCheck

        Public Sub New(ByVal ParamArray rights() As GroupRight)
            _rights = rights
        End Sub 'New

        Public Sub New(ByVal isSecured As Boolean, ByVal read As Boolean, ByVal insert As Boolean, ByVal update As Boolean, ByVal delete As Boolean)
            _rights = Nothing
            _isSecured = isSecured
            _AllowRead = read
            _AllowInsert = insert
            _AllowUpdate = update
            _AllowDelete = delete
        End Sub 'New

        Public Property AllowRead() As Boolean
            Get
                Return AllowCheck(AccessIdentifier.Read)
            End Get
            Set(ByVal Value As Boolean)
                _AllowRead = Value
            End Set
        End Property

        Public Property AllowInsert() As Boolean
            Get
                Return AllowCheck(AccessIdentifier.Insert)
            End Get
            Set(ByVal Value As Boolean)
                _AllowInsert = Value
            End Set
        End Property

        Public Property AllowUpdate() As Boolean
            Get
                Return AllowCheck(AccessIdentifier.Update)
            End Get
            Set(ByVal Value As Boolean)
                _AllowUpdate = Value
            End Set
        End Property

        Public Property AllowDelete() As Boolean
            Get
                Return AllowCheck(AccessIdentifier.Delete)
            End Get
            Set(ByVal Value As Boolean)
                _AllowDelete = Value
            End Set
        End Property

        Public Property FullControl() As Boolean
            Get
                Return AllowRead And _AllowInsert And _AllowUpdate And _AllowDelete
            End Get
            Set(ByVal Value As Boolean)
                _AllowRead = True
                _AllowInsert = True
                _AllowUpdate = True
                _AllowDelete = True
            End Set
        End Property

        Public Property None() As Boolean
            Get
                Return Not (AllowRead Or _AllowInsert Or _AllowUpdate Or _AllowDelete)
            End Get
            Set(ByVal Value As Boolean)
                _AllowRead = False
                _AllowInsert = False
                _AllowUpdate = False
                _AllowDelete = False
            End Set
        End Property

        Public ReadOnly Property Editable() As Boolean
            Get
                Return AllowInsert Or _AllowUpdate Or _AllowDelete
            End Get
        End Property
    End Class 'FormSupportedOperations
End Namespace
'End Security Class

