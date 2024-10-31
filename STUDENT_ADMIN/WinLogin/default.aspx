<%@Page Language="VB" %>
<%@Import Namespace="System.Web.Security" %>
<script language="vb" runat="server">
Sub Page_Load()
dim thisuser as string 
thisuser = User.Identity.Name.replace("DECV\", "")
if (thisuser <> "") then

If User.Identity.IsAuthenticated Then
	'User.Identity.Name
	'User.Identity.AuthenticationType
	FormsAuthentication.RedirectFromLoginPage(thisuser, false)
Else
    'redirect to normal login
	response.redirect("../Login.aspx")
End If
else
response.redirect("../Login.aspx")
end if

End Sub
</script>
