Imports System.Data
Imports System.Data.SqlClient
Partial Class services_StudentEnrolmentDetails_maintain_ajax
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request.QueryString("supervisor") Is Nothing Then
            GetSuperVisorDetails(Request.QueryString("supervisor").ToString)
        Else
            Response.Write("")
        End If

    End Sub
    Protected Sub GetSuperVisorDetails(ByVal SuperVisor As String)
        Dim sResponse As String = ""
        Dim sQuery As String = "SELECT DISTINCT UPPER(LTRIM(RTRIM(SCHOOL_SUPERVISOR_NAME))) [SUPERVISOR_NAME]," _
                        & " LTRIM(RTRIM(ISNULL(SCHOOL_SUPERVISOR_PHONE,''))) [SUPERVISOR_PHONE]," _
                        & " UPPER(Ltrim(Rtrim(ISNULL(SCHOOL_SUPERVISOR_EMAIL,'')))) [SUPERVISOR_EMAIL] " _
                        & " from STUDENT_ENROLMENT where " _
                        & " SCHOOL_SUPERVISOR_NAME!='' and " _
                        & " SCHOOL_SUPERVISOR_NAME is not null and" _
                        & " ENROLMENT_YEAR=" & DateTime.Today.Year.ToString & "" _
                        & " AND SCHOOL_SUPERVISOR_NAME like '" & SuperVisor.Replace("'", "''") & "%'"
        Dim sqlcon As SqlConnection = New SqlConnection(ConfigurationManager.AppSettings("connDECVPRODSQL2005String").ToString)
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(sQuery, sqlcon)
        Dim dataset As New DataSet
        adapter.Fill(dataset)
        If Not dataset Is Nothing Then
            If dataset.Tables(0).Rows.Count > 0 Then
                ''Response.Write(dataset.GetXml)
                For i As Integer = 0 To dataset.Tables(0).Rows.Count - 1
                    sResponse = sResponse + dataset.Tables(0).Rows(i)("SUPERVISOR_NAME") & "|" & dataset.Tables(0).Rows(i)("SUPERVISOR_PHONE") & "|" & dataset.Tables(0).Rows(i)("SUPERVISOR_EMAIL") & "~"
                Next
                sResponse = Left(sResponse, sResponse.Length - 1)
                Response.Write(sResponse)
            End If
        Else
            Response.Write("")
        End If
    End Sub
End Class
