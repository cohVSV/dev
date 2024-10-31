<!--ASPX page @1-8B7A8FE9-->
    <%@ Page language="vb" CodeFile="COUNTRY_OF_BIRT_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.COUNTRY_OF_BIRT_maint.COUNTRY_OF_BIRT_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.COUNTRY_OF_BIRT_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
	<html>
<head>
<meta http-equiv="content-type" content="text/html; charset=windows-1252">
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0">

<title>COUNTRY OF BIRTH</title>

<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<DECV_PROD2007:Header id="Header" runat="server"/>


  <span id="COUNTRY_OF_BIRTHHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table cellspacing="0" cellpadding="0" border="0" class="Header">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
            <th>Add/Edit COUNTRY OF BIRTH </th>
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="COUNTRY_OF_BIRTHError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="COUNTRY_OF_BIRTHErrorLabel" runat="server"/></td> 
          </tr>
 
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>COUNTRY NAME</th>
 
            <td><asp:TextBox id="COUNTRY_OF_BIRTHCOUNTRY_NAME" maxlength="20" Columns="20"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY</th>
 
            <td><asp:TextBox id="COUNTRY_OF_BIRTHLAST_ALTERED_BY" maxlength="8" Columns="8"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED DATE</th>
 
            <td><asp:TextBox id="COUNTRY_OF_BIRTHLAST_ALTERED_DATE" maxlength="100" Columns="10"	runat="server"/></td> 
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">
              <input id='COUNTRY_OF_BIRTHButton_Insert' type="submit" value="Add" class="Button" OnServerClick='COUNTRY_OF_BIRTH_Insert' runat="server"/>
              <input id='COUNTRY_OF_BIRTHButton_Update' type="submit" value="Submit" class="Button" OnServerClick='COUNTRY_OF_BIRTH_Update' runat="server"/>
              <input id='COUNTRY_OF_BIRTHButton_Delete' type="submit" value="Delete" class="Button" OnServerClick='COUNTRY_OF_BIRTH_Delete' runat="server"/></td> 
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

