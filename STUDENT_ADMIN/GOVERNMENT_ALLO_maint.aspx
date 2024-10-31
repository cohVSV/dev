<!--ASPX page @1-14FD8DF8-->
    <%@ Page language="vb" CodeFile="GOVERNMENT_ALLO_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.GOVERNMENT_ALLO_maint.GOVERNMENT_ALLO_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.GOVERNMENT_ALLO_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
	<html>
<head>
<meta http-equiv="content-type" content="text/html; charset=windows-1252">
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0">

<title>GOVERNMENT ALLOWANCE</title>

<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<DECV_PROD2007:Header id="Header" runat="server"/>


  <span id="GOVERNMENT_ALLOWANCEHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table cellspacing="0" cellpadding="0" border="0" class="Header">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
            <th>Add/Edit GOVERNMENT ALLOWANCE </th>
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="GOVERNMENT_ALLOWANCEError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="GOVERNMENT_ALLOWANCEErrorLabel" runat="server"/></td> 
          </tr>
 
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>ALLOWANCE TITLE</th>
 
            <td><asp:TextBox id="GOVERNMENT_ALLOWANCEALLOWANCE_TITLE" maxlength="10" Columns="10"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>ALLOWANCE DESCRIPTION</th>
 
            <td><asp:TextBox id="GOVERNMENT_ALLOWANCEALLOWANCE_DESCRIPTION" maxlength="60" Columns="50"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY</th>
 
            <td><asp:TextBox id="GOVERNMENT_ALLOWANCELAST_ALTERED_BY" maxlength="8" Columns="8"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED DATE</th>
 
            <td><asp:TextBox id="GOVERNMENT_ALLOWANCELAST_ALTERED_DATE" maxlength="100" Columns="10"	runat="server"/></td> 
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">
              <input id='GOVERNMENT_ALLOWANCEButton_Insert' type="submit" value="Add" class="Button" OnServerClick='GOVERNMENT_ALLOWANCE_Insert' runat="server"/>
              <input id='GOVERNMENT_ALLOWANCEButton_Update' type="submit" value="Submit" class="Button" OnServerClick='GOVERNMENT_ALLOWANCE_Update' runat="server"/>
              <input id='GOVERNMENT_ALLOWANCEButton_Delete' type="submit" value="Delete" class="Button" OnServerClick='GOVERNMENT_ALLOWANCE_Delete' runat="server"/></td> 
          </tr>
        </table>
 </td> 
    </tr>
  </table>



  </span>
  <br>
<DECV_PROD2007:Footer id="Footer" runat="server"/>

</form>
</body>
</html>

<!--End ASPX page-->

