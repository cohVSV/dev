<!--ASPX page @1-256F775C-->
    <%@ Page language="vb" CodeFile="Login.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Login.LoginPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Login" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge"><meta name="description" content="DECV Student Admin DB 2008 SQL re-write
- updated Oct-Dec 2019 for VSV branding
Eric Affleck ERA Technology
0412 039 611"><meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>VSV Student Database - Login</title>




<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<DECV_PROD2007:Header id="Header" runat="server"/>&nbsp; 

  <span id="LoginHolder" runat="server">
    


    <div align="center">
        <table cellspacing="0" cellpadding="0" align="center" border="0">
            <tr>
                <td valign="top">
                    <table class="Header" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                            <th>Login </th>
 
                            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                        </tr>
                    </table>
 
                    <table class="Record" cellspacing="0" cellpadding="0">
                        
  <asp:PlaceHolder id="LoginError" visible="False" runat="server">
  
                        <tr class="Error">
                            <td colspan="2"><asp:Label ID="LoginErrorLabel" runat="server"/></td>
                        </tr>
                        
  </asp:PlaceHolder>
  
                        <tr class="Controls">
                            <th>Login</th>
 
                            <td><asp:TextBox id="Loginlogin" maxlength="100" Columns="20"	runat="server"/></td>
                        </tr>
 
                        <tr class="Controls">
                            <th>Password</th>
 
                            <td><asp:TextBox id="Loginpassword" TextMode="Password" maxlength="100" Columns="20"	runat="server"/></td>
                        </tr>
 
                        <tr class="Controls">
                            <th>&nbsp;</th>
 
                            <td><asp:CheckBox id="Logincb_rememberme" runat="server"/>&nbsp;<em>remember me today</em></td>
                        </tr>
 
                        <tr class="Bottom">
                            <td colspan="2" align="right">
                                <input id='LoginButton_DoLogin' type="submit" class="Button" value="Login" OnServerClick='Login_Button_DoLogin_OnClick' runat="server"/></td>
                        </tr>
                    </table>
                    <em>Use your usual Student Database Password</em></td>
            </tr>
        </table>
    </div>


<p align="left">&nbsp;&nbsp;</p>

  </span>
  <DECV_PROD2007:Footer id="Footer" runat="server"/> 

</form>
</body>
</html>

<!--End ASPX page-->

