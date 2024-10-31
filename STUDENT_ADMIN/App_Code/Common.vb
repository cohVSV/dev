Option Strict On
Option Explicit On


Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DECV_PROD2007.Configuration
Imports System.DirectoryServices.AccountManagement
Imports System.DirectoryServices
Imports System.Threading


Public Module Extensions

   <Extension()>
   Function AddWithNull(parameter As SqlParameterCollection, fieldName As String, value As String) As SqlParameter
      If (Not String.IsNullOrEmpty(value)) Then
         Return parameter.AddWithValue(fieldName, value)
      Else
         Return parameter.AddWithValue(fieldName, SqlString.Null)
      End If
   End Function


   <Extension()>
   Function AddWithNull(parameter As SqlParameterCollection, fieldName As String, value As Integer?) As SqlParameter
      If (value.HasValue) Then
         Return parameter.AddWithValue(fieldName, value)
      Else
         Return parameter.AddWithValue(fieldName, SqlInt32.Null)
      End If
   End Function


   <Extension()>
   Function AddWithNull(parameter As SqlParameterCollection, fieldName As String, value As Date?) As SqlParameter
      If (value.HasValue) Then
         Return parameter.AddWithValue(fieldName, value)
      Else
         Return parameter.AddWithValue(fieldName, SqlDateTime.Null)
      End If
   End Function


   <Extension()>
   Function AddWithNull(parameter As SqlParameterCollection, fieldName As String, value As Decimal?) As SqlParameter
      If (value.HasValue) Then
         Return parameter.AddWithValue(fieldName, value)
      Else
         Return parameter.AddWithValue(fieldName, SqlDecimal.Null)
      End If
   End Function


   <Extension()>
   Function AddWithNull(parameter As SqlParameterCollection, fieldName As String, value As Short?) As SqlParameter
      If (value.HasValue) Then
         Return parameter.AddWithValue(fieldName, value)
      Else
         Return parameter.AddWithValue(fieldName, SqlInt16.Null)
      End If
   End Function


   <Extension()>
   Function Value(Of T)(dataReader As SqlDataReader, fieldName As String) As T
      Return Common.Value(Of T)(dataReader(fieldName))
   End Function

End Module


Public Class Common
   Public Const EnvironmentSettingName = "Environment"
   Public Const DevelopmentEnvironmentName = "Development"
   Public Const StagingEnvironmentName = "Staging"
   Public Const ProductionEnvironmentName = "Production"
   Public Const WindowsDomain = "DECV"
   Public Const UserIDSessionID = "UserID"
   Public Const GroupIDSessionID = "GroupID"
   Public Const UserLoginSessionID = "UserLogin"
   Public Const AccessGroupsSessionID = "AccessGroups"
   Public Const ActiveDirectoryGroupsSessionID = "ActiveDirectoryGroups"
   Public Const PermissionsLastRefreshTimeSessionID = "AuthenticationLastRefreshTime"
   Public Const PermissionsMaximumRefreshFrequencyMinutes = 5


   Public Class UserCredentials
      Public GroupID As Decimal?
      Public SecurityFunctions As String
      Public Password As String
      Public Status As Boolean?
   End Class


   Shared Function Value(Of T)(theValue As Object) As T
      If (theValue Is DBNull.Value) Then
         Return CType(Nothing, T)
      Else
         Return DirectCast(theValue, T)
      End If
   End Function


   Shared Function GetDateDisplay(value As Object, Optional startWithLowerCase As Boolean = False) As String
      If (TypeOf value IsNot Date) Then
         Return ""
      Else
         Dim dateValue = DirectCast(value, Date)

         If (dateValue.Date = Date.Now.Date) Then
            Return If(startWithLowerCase, "today", "Today")
         ElseIf (dateValue.Date.AddDays(1) = Date.Now.Date) Then
            Return If(startWithLowerCase, "yesterday", "Yesterday")
         Else
            Return dateValue.ToString("d MMM yyyy")
         End If
      End If
   End Function


   Shared Function GetDateTimeDisplay(value As Object, Optional startWithLowerCase As Boolean = False) As String
      If (TypeOf value IsNot Date) Then
         Return ""
      Else
         Dim dateValue = DirectCast(value, Date)
         Dim timeString = dateValue.ToString("h:mm tt")

         If (dateValue.Date = Date.Now.Date) Then
            Return If(startWithLowerCase, "today", "Today") & " at " & timeString
         ElseIf (dateValue.Date.AddDays(1) = Date.Now.Date) Then
            Return If(startWithLowerCase, "yesterday", "Yesterday") & " at " & timeString
         Else
            Return dateValue.ToString("d MMM yyyy") & " at " & timeString
         End If
      End If
   End Function


   Shared Function GetDurationDisplay(durationMinutes As Object) As String
      If (TypeOf durationMinutes IsNot Integer) Then
         Return ""
      End If

      Dim span = TimeSpan.FromMinutes(DirectCast(durationMinutes, Integer))
      Dim stringBuilder = New StringBuilder()
      Dim minutesToGo As Integer = CType(span.TotalMinutes(), Integer)
      If (minutesToGo < 60) Then
         stringBuilder.Append(minutesToGo)
         stringBuilder.Append(" minute")
         If (minutesToGo > 1) Then stringBuilder.Append("s")
      Else
         Dim hours = (minutesToGo \ 60)
         Dim minutes = (minutesToGo Mod 60)
         stringBuilder.Append(hours)
         stringBuilder.Append(" hour")
         If (hours > 1) Then stringBuilder.Append("s")
         If (minutes > 0) Then
            stringBuilder.Append(" and ")
            stringBuilder.Append(minutes)
            stringBuilder.Append(" minute")
            If (minutes > 1) Then stringBuilder.Append("s")
         End If
      End If

      Return stringBuilder.ToString()
   End Function


   Shared Function GetQueryResults(commandText As String, parameters As Dictionary(Of String, Object)) As DataTable
      Dim dataTable As New DataTable()

      Using connection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
         connection.Open()
         Using command = connection.CreateCommand()
            With command
               .CommandType = CommandType.Text
               .CommandText = commandText

               For Each entry As KeyValuePair(Of String, Object) In parameters
                  .Parameters.AddWithValue(entry.Key, If(entry.Value Is Nothing, DBNull.Value, entry.Value))
               Next

               dataTable.Load(.ExecuteReader())
            End With
         End Using
      End Using

      Return dataTable
   End Function


   Shared Function GetStudentDatabaseUserCredentials(staffID As String) As UserCredentials
      Using connection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
         connection.Open()
         Using command = connection.CreateCommand()
            With command
               .CommandType = CommandType.Text
               .CommandText = "with
                                 GroupSecurityFunctions (GroupSecurityFunctions) as
                                    (
                                       select
                                          concat(sga.FUNCTION_ID, ',')
                                        from
                                          dbo.STAFF as stf
                                          inner join dbo.SECURITY_GROUP as sg
                                             on (sg.GROUP_ID = stf.GROUP_ID)
                                          inner join dbo.SECURITY_GROUP_ACCESS as sga
                                             on (sga.GROUP_ID = sg.GROUP_ID)
                                        where
                                          (stf.STAFF_ID = @staffID)
                                       for xml path('')
                                    )
                               select
                                  stf.GROUP_ID as GroupID,
                                  (
                                     select gsf.GroupSecurityFunctions from GroupSecurityFunctions as gsf
                                  ) as GroupSecurityFunctions,
                                  stf.SECURITY_FUNCTIONS as UserSecurityFunctions,
                                  stf.PASSWORD_EXTENDED as Password,
                                  stf.STATUS as Status
                                from
                                  dbo.STAFF as stf
                                where
                                  stf.STAFF_ID = @staffID;"

               .Parameters.AddWithValue("staffID", staffID)

               Using reader = command.ExecuteReader()
                  If (reader.Read()) Then
                     Dim credentials As New UserCredentials()
                     With credentials
                        .GroupID = reader.Value(Of Decimal?)("GroupID")

                        Dim groupSecurityFunctions = If(reader.Value(Of String)("GroupSecurityFunctions"), "")
                        Dim userSecurityFunctions = If(reader.Value(Of String)("UserSecurityFunctions"), "")
                        userSecurityFunctions = String.Join(Of Char)(",", userSecurityFunctions)

                        .SecurityFunctions = groupSecurityFunctions & userSecurityFunctions

                        .Password = reader.Value(Of String)("Password")
                        .Status = reader.Value(Of Boolean?)("Status")
                     End With

                     Return credentials
                  End If
               End Using
            End With
         End Using
      End Using

      Return Nothing
   End Function


   Shared Function GetUserSecurityGroups(username As String) As List(Of Principal)
      ' GetAuthorizationGroups() sporadically causes a "Attempted to access an unloaded appdomain" exception, which is apparently a known issue:
      ' See https://stackoverflow.com/questions/5895128/attempted-to-access-an-unloaded-appdomain-when-using-system-directoryservices:
      ' The most successful workaround seems to be to explicitly add the domain name as a 2nd parameter: done.
      ' A fallback also used with success on that same page is to loop with a short sleep in between. Yuck, but if that's what it takes...
      Using principalContext = New PrincipalContext(ContextType.Domain, WindowsDomain)
         Using user = UserPrincipal.FindByIdentity(principalContext, IdentityType.SamAccountName, username)
            If (user IsNot Nothing) Then
               For attempts As Integer = 1 To 5
                  Try
                     Return user.GetAuthorizationGroups().ToList()
                  Catch ex As Exception
                     Thread.Sleep(1000)
                  End Try
               Next

               Throw New Exception("Could not retrieve the user's Active Directory groups.")
            End If
         End Using
      End Using

      Return New List(Of Principal)()
   End Function


   Shared Sub GetControlList(Of T As Control)(controlCollection As ControlCollection, resultCollection As List(Of T), Optional targetID As String = Nothing)
      For Each control As Control In controlCollection
         If ((TypeOf control Is T) AndAlso ((targetID Is Nothing) OrElse control.ID.Equals(targetID))) Then resultCollection.Add(CType(control, T))
         If (control.HasControls()) Then GetControlList(control.Controls, resultCollection)
      Next
   End Sub


   Shared Sub SetChildControlsEnabled(controlCollection As ControlCollection, enabled As Boolean)
      Dim control As Control
      For controlIndex = 0 To controlCollection.Count - 1
         control = controlCollection(controlIndex)

         If (TypeOf control Is WebControl) Then
            DirectCast(control, WebControl).Enabled = enabled
         End If

         If control.Controls.Count > 0 Then
            SetChildControlsEnabled(control.Controls, enabled)
         End If
      Next
   End Sub


   Shared Sub ClearChildControls(controlCollection As ControlCollection)
      Dim control As Control
      For controlIndex = 0 To controlCollection.Count - 1
         control = controlCollection(controlIndex)

         If (TypeOf control Is TextBox) Then
            DirectCast(control, TextBox).Text = ""
         ElseIf (TypeOf control Is DropDownList) Then
            DirectCast(control, DropDownList).ClearSelection()
         ElseIf (TypeOf control Is RadioButtonList) Then
            DirectCast(control, RadioButtonList).ClearSelection()
         End If

         If control.Controls.Count > 0 Then
            ClearChildControls(control.Controls)
         End If
      Next
   End Sub


   Shared Function GenerateStudentSummaryPageLink(studentID As String, enrolmentYear As String) As String
      Return GenerateStudentPageLink("StudentSummary.aspx", studentID, enrolmentYear)
   End Function


   Shared Function GenerateStudentMedicalPageLink(studentID As String, enrolmentYear As String) As String
      Return GenerateStudentPageLink("Student_Medical_maintain.aspx", studentID, enrolmentYear)
   End Function


   Shared Function GenerateStudentCensusPageLink(studentID As String, enrolmentYear As String) As String
      Return GenerateStudentPageLink("Student_Census_maintain.aspx", studentID, enrolmentYear)
   End Function


   Private Shared Function GenerateStudentPageLink(page As String, studentID As String, enrolmentYear As String) As String
      Dim serverURL = ConfigurationManager.AppSettings("ServerUrl")
      Return $"{serverURL}{page}?STUDENT_ID={studentID}&ENROLMENT_YEAR={enrolmentYear}"
   End Function
End Class
