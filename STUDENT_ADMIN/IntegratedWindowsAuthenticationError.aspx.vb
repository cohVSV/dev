
Partial Class IntegratedWindowsAuthenticationError
   Inherits System.Web.UI.Page

   Private Const ErrorParameterName = "errorCode"
   Private Const ErrorWindowsAccountNotFoundParameterValue = "WindowsAccountNotFound"
   Private Const ErrorSDBAccountNotFoundParameterValue = "SDBAccountNotFound"
   Private Const ErrorSDBAccountInactiveParameterValue = "SDBAccountInactive"
   Private Const ErrorSDBAccountValidationFailedParameterValue = "SDBAccountValidationFailed"


   Private Sub IntegratedWindowsAuthenticationError_Load(sender As Object, e As EventArgs) Handles Me.Load
      If (Not Page.IsPostBack) Then
         Dim errorCode = Request(ErrorParameterName)
         Dim errorMessage As String
         Select Case errorCode
            Case ErrorWindowsAccountNotFoundParameterValue
               errorMessage = "Your Windows login account details could not be identified."
            Case ErrorSDBAccountNotFoundParameterValue
               errorMessage = "A student database account could not be found for your Windows login."
            Case ErrorSDBAccountInactiveParameterValue
               errorMessage = "Your student database account is currently inactive."
            Case ErrorSDBAccountValidationFailedParameterValue
               errorMessage = "Failed to authenticate your student database account."
            Case Else
               errorMessage = "An unknown error has occurred."
         End Select

         litErrorMessage.Text = errorMessage
      End If
   End Sub
End Class
