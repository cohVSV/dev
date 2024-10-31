'Imports statements @1-1C356245
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports DECV_PROD2007.Data
Imports DECV_PROD2007.Configuration

Namespace DECV_PROD2007.Security

'End Imports statements

'MembershipProvider class @2b-53E8065D

'ERA: 26-Mar-2012|EA| ValidateUser added 'STATUS=1 AND' to lookup to ensure only active are looked at

Public Class CCSMembershipProvider
   Inherits MembershipProvider
   Private connName As String
   Private tableName As String
   Private userIdField As String
   Private userLoginField As String
   Private userPasswordField As String
   Private userGroupField As String
   Private userIdSessionVariable As String
   Private userGroupSessionVariable As String
   Private userLoginSessionVariable As String
   Public Sub New()
   End Sub
   
   
   Public Overrides Sub Initialize(name As String, config As System.Collections.Specialized.NameValueCollection)
      connName = config("connectionString")
      tableName = config("tableName")
      userIdField = config("userIdField")
      userLoginField = config("userLoginField")
      userPasswordField = config("userPasswordField")
      userGroupField = config("userGroupField")
	  userIdSessionVariable = config("userIdSessionVariable")
	  userGroupSessionVariable = config("userGroupSessionVariable")
	  userLoginSessionVariable = config("userLoginSessionVariable")      
      MyBase.Initialize(name, config)
   End Sub
   
   
   Public Overrides Property ApplicationName() As String
      Get
         Return HttpContext.Current.Request.ApplicationPath
      End Get
      Set
         Dim a As String = value
      End Set
   End Property
   
   
   Public Overrides Function ChangePassword(username As String, oldPassword As String, newPassword As String) As Boolean
      Throw New Exception("The method or operation is not implemented.")
   End Function
   
   
   Public Overrides Function ChangePasswordQuestionAndAnswer(username As String, password As String, newPasswordQuestion As String, newPasswordAnswer As String) As Boolean
      Throw New Exception("The method or operation is not implemented.")
   End Function
   
   
   Public Overrides Function CreateUser(username As String, password As String, email As String, passwordQuestion As String, passwordAnswer As String, isApproved As Boolean, providerUserKey As Object, ByRef status As MembershipCreateStatus) As MembershipUser
      
      Dim dao As DataAccessObject = Settings.GetConnection(connName)
      Dim Sql As String = "insert into " + tableName + " (" + userLoginField + "," + userPasswordField + ") values(" + dao.ToSql(username, FieldType._Text) + "," + dao.ToSql(password, FieldType._Text) + ")"
      dao.ExecuteNonQuery(Sql)
      Sql = "SELECT " + userIdField + " FROM " + tableName + " WHERE " + userLoginField + "=" + dao.ToSql(username, FieldType._Text) + " AND " + userPasswordField + "=" + dao.ToSql(password, FieldType._Text)
      Dim id As Integer = CInt(dao.ExecuteScalar(Sql))
      Dim user As New MembershipUser("CCSMembershipProvider", username, id, Nothing, Nothing, Nothing, True, False, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
      status = MembershipCreateStatus.Success
      Return user
   End Function
   
   
   Public Overrides Function DeleteUser(username As String, deleteAllRelatedData As Boolean) As Boolean
      Dim dao As DataAccessObject = Settings.GetConnection(connName)
      Dim Sql As String = "delete from " + tableName + " where " + userLoginField + " = " + dao.ToSql(username, FieldType._Text)
      dao.ExecuteNonQuery(Sql)
      Return True
   End Function
   
   
   Public Overrides ReadOnly Property EnablePasswordReset() As Boolean
      Get
         Return False
      End Get
   End Property 
   
   Public Overrides ReadOnly Property EnablePasswordRetrieval() As Boolean
      Get
         Return False
      End Get
   End Property
    
   Public Overrides Function FindUsersByEmail(emailToMatch As String, pageIndex As Integer, pageSize As Integer, ByRef totalRecords As Integer) As MembershipUserCollection
      Throw New Exception("The method or operation is not implemented.")
   End Function
   
   
   Public Overrides Function FindUsersByName(usernameToMatch As String, pageIndex As Integer, pageSize As Integer, ByRef totalRecords As Integer) As MembershipUserCollection
      Throw New Exception("The method or operation is not implemented.")
   End Function
   
   
   Public Overrides Function GetAllUsers(pageIndex As Integer, pageSize As Integer, ByRef totalRecords As Integer) As MembershipUserCollection
      Dim dao As DataAccessObject = Settings.GetConnection(connName)
      Dim Sql As String = "SELECT * FROM " + tableName
      Dim col As New MembershipUserCollection()
      
      Dim ds As DataSet = dao.RunSql(Sql, pageIndex * pageSize, pageSize)
      totalRecords = ds.Tables(0).Rows.Count
      Dim i As Integer
      For i = 0 To (ds.Tables(0).Rows.Count) - 1
         Dim user As New MembershipUser("CCSMembershipProvider", ds.Tables(0).Rows(i)(userLoginField).ToString(), ds.Tables(0).Rows(0)(userIdField).ToString(), Nothing, Nothing, Nothing, True, False, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
         col.Add(user)
      Next i
      Return col
   End Function
   
   
   Public Overrides Function GetNumberOfUsersOnline() As Integer
      Throw New Exception("The method or operation is not implemented.")
   End Function
   
   
   Public Overrides Function GetPassword(username As String, answer As String) As String
      Throw New Exception("The method or operation is not implemented.")
   End Function
   
   
   Overloads Public Overrides Function GetUser(username As String, userIsOnline As Boolean) As MembershipUser
      Throw New Exception("The method or operation is not implemented.")
   End Function
   
   
   Overloads Public Overrides Function GetUser(providerUserKey As Object, userIsOnline As Boolean) As MembershipUser
      Throw New Exception("The method or operation is not implemented.")
   End Function
   
   
   Public Overrides Function GetUserNameByEmail(email As String) As String
      Throw New Exception("The method or operation is not implemented.")
   End Function
   
   
   Public Overrides ReadOnly Property MaxInvalidPasswordAttempts() As Integer
      Get
         Throw New Exception("The method or operation is not implemented.")
      End Get
   End Property 
   
   Public Overrides ReadOnly Property MinRequiredNonAlphanumericCharacters() As Integer
      Get
         Throw New Exception("The method or operation is not implemented.")
      End Get
   End Property 
   
   Public Overrides ReadOnly Property MinRequiredPasswordLength() As Integer
      Get
         Throw New Exception("The method or operation is not implemented.")
      End Get
   End Property 
   
   Public Overrides ReadOnly Property PasswordAttemptWindow() As Integer
      Get
         Throw New Exception("The method or operation is not implemented.")
      End Get
   End Property 
   
   Public Overrides ReadOnly Property PasswordFormat() As MembershipPasswordFormat
      Get
         Throw New Exception("The method or operation is not implemented.")
      End Get
   End Property 
   
   Public Overrides ReadOnly Property PasswordStrengthRegularExpression() As String
      Get
         Throw New Exception("The method or operation is not implemented.")
      End Get
   End Property 
   
   Public Overrides ReadOnly Property RequiresQuestionAndAnswer() As Boolean
      Get
         Throw New Exception("The method or operation is not implemented.")
      End Get
   End Property 
   
   Public Overrides ReadOnly Property RequiresUniqueEmail() As Boolean
      Get
         Throw New Exception("The method or operation is not implemented.")
      End Get
   End Property
    
   Public Overrides Function ResetPassword(username As String, answer As String) As String
      Throw New Exception("The method or operation is not implemented.")
   End Function 'ResetPassword
   
   
   Public Overrides Function UnlockUser(userName As String) As Boolean
      Throw New Exception("The method or operation is not implemented.")
   End Function 'UnlockUser
   
   
   Public Overrides Sub UpdateUser(user As MembershipUser)
      Dim dao As DataAccessObject = Settings.GetConnection(connName)
      Dim Sql As String = "UPDATE " + tableName + " SET " + userLoginField + " = " + dao.ToSql(user.UserName, FieldType._Text) + ")"
      
      dao.ExecuteNonQuery(Sql)
   End Sub 'UpdateUser
   
   
   Public Overrides Function ValidateUser(username As String, password As String) As Boolean
      Dim dao As DataAccessObject = Settings.GetConnection(connName)
		Dim encpassword As String = ""
		If ConfigurationManager.AppSettings("ProtectPasswordsMethod") = "DBFunction" Then
		
		encpassword = String.Format("{0}({1})", ConfigurationManager.AppSettings("ProtectPasswordsExpression"), dao.ToSql(password,FieldType._Text))

		Else
		   If ConfigurationManager.AppSettings("ProtectPasswordsMethod") = "CodeExpression" Then
			  encpassword = dao.ToSql(password, FieldType._Text)
		   Else
			  encpassword = dao.ToSql(password, FieldType._Text)
		   End If
		End If 
		'ERA: 26-Mar-2012|EA| added 'STATUS=1 AND' to lookup to ensure only active are looked at
		'ERA: 13-Mar-2018|EA| revisit autologin using /WinLogin/autologin.aspx and validate using Authenticated user id, no password
		'Dim Sql As String = "SELECT * FROM " + tableName + " WHERE STATUS=1 AND " + userLoginField + "=" + dao.ToSql(username, FieldType._Text) + " AND " + userPasswordField + "= (case when '" + encpassword + "'='DUMMyPWd@ut0Log!n12^#' then " + userPasswordField + " else " + encpassword + " end)"
		Dim Sql As String = "SELECT * FROM " + tableName + " WHERE STATUS=1 AND " + userLoginField + "=" + dao.ToSql(username, FieldType._Text) + " AND " + userPasswordField + "=" + encpassword 
      
      Dim ds As DataSet = dao.RunSql(Sql)
      
      If ds.Tables(0).Rows.Count > 0 Then
         HttpContext.Current.Session(userIdSessionVariable) = ds.Tables(0).Rows(0)(userIdField)
         If Not (userGroupField Is Nothing) And userGroupField <> "" Then
            HttpContext.Current.Session(userGroupSessionVariable) = ds.Tables(0).Rows(0)(userGroupField).ToString()
         End If
         HttpContext.Current.Session(userLoginSessionVariable) = username
         Return True
      End If
      
      
      Return False
   End Function


'End MembershipProvider class

End Class 'End MembershipProvider class @1a-A61BA892

End Namespace 'End namespace @1b-5EA2E2E0

