<!--ASPX page @1-A699FA4F-->
    <%@ Page language="vb" CodeFile="TXN_CODE_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.TXN_CODE_maint.TXN_CODE_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.TXN_CODE_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
	<html>
<head>
<meta http-equiv="content-type" content="text/html; charset=windows-1252">
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0">

<title>TXN CODE</title>

<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<DECV_PROD2007:Header id="Header" runat="server"/>


  <span id="TXN_CODEHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table cellspacing="0" cellpadding="0" border="0" class="Header">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
            <th>Add/Edit TXN CODE </th>
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="TXN_CODEError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="TXN_CODEErrorLabel" runat="server"/></td> 
          </tr>
 
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>TXN TYPE</th>
 
            <td><asp:TextBox id="TXN_CODETXN_TYPE" maxlength="20" Columns="20"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>CR DR FLAG</th>
 
            <td><asp:TextBox id="TXN_CODECR_DR_FLAG" maxlength="1" Columns="1"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>DESCRIPTION</th>
 
            <td><asp:TextBox id="TXN_CODEDESCRIPTION" maxlength="60" Columns="50"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY</th>
 
            <td><asp:TextBox id="TXN_CODELAST_ALTERED_BY" maxlength="8" Columns="8"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED DATE</th>
 
            <td><asp:TextBox id="TXN_CODELAST_ALTERED_DATE" maxlength="100" Columns="10"	runat="server"/></td> 
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">
              <input id='TXN_CODEButton_Insert' type="submit" value="Add" class="Button" OnServerClick='TXN_CODE_Insert' runat="server"/>
              <input id='TXN_CODEButton_Update' type="submit" value="Submit" class="Button" OnServerClick='TXN_CODE_Update' runat="server"/>
              <input id='TXN_CODEButton_Delete' type="submit" value="Delete" class="Button" OnServerClick='TXN_CODE_Delete' runat="server"/></td> 
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

