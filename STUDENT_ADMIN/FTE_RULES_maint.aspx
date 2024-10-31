<!--ASPX page @1-C3944D1E-->
    <%@ Page language="vb" CodeFile="FTE_RULES_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.FTE_RULES_maint.FTE_RULES_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.FTE_RULES_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
	<html>
<head>
<meta http-equiv="content-type" content="text/html; charset=windows-1252">
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0">

<title>FTE RULES</title>

<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<DECV_PROD2007:Header id="Header" runat="server"/>


  <span id="FTE_RULESHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table cellspacing="0" cellpadding="0" border="0" class="Header">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
            <th>Add/Edit FTE RULES </th>
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="FTE_RULESError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="FTE_RULESErrorLabel" runat="server"/></td> 
          </tr>
 
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>FROM YEAR LEVEL</th>
 
            <td><asp:TextBox id="FTE_RULESFROM_YEAR_LEVEL" maxlength="5" Columns="5"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>TO YEAR LEVEL</th>
 
            <td><asp:TextBox id="FTE_RULESTO_YEAR_LEVEL" maxlength="5" Columns="5"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>FTE</th>
 
            <td><asp:TextBox id="FTE_RULESFTE" maxlength="12" Columns="12"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>FULLTIME FLAG</th>
 
            <td><asp:CheckBox id="FTE_RULESFULLTIME_FLAG" runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY</th>
 
            <td><asp:TextBox id="FTE_RULESLAST_ALTERED_BY" maxlength="8" Columns="8"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED DATE</th>
 
            <td><asp:TextBox id="FTE_RULESLAST_ALTERED_DATE" maxlength="100" Columns="10"	runat="server"/></td> 
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">
              <input id='FTE_RULESButton_Insert' type="submit" value="Add" class="Button" OnServerClick='FTE_RULES_Insert' runat="server"/>
              <input id='FTE_RULESButton_Update' type="submit" value="Submit" class="Button" OnServerClick='FTE_RULES_Update' runat="server"/>
              <input id='FTE_RULESButton_Delete' type="submit" value="Delete" class="Button" OnServerClick='FTE_RULES_Delete' runat="server"/></td> 
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

