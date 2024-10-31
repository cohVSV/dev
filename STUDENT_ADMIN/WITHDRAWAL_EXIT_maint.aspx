<!--ASPX page @1-9EBCD658-->
    <%@ Page language="vb" CodeFile="WITHDRAWAL_EXIT_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.WITHDRAWAL_EXIT_maint.WITHDRAWAL_EXIT_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.WITHDRAWAL_EXIT_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 4.1.00.032" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>WITHDRAWAL EXIT DESTINATION</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p><a id="Link1" href="" class="Button" runat="server"  >Back to Exit Destination List</a></p>

  <span id="WITHDRAWAL_EXIT_DESTINATIHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Add/Edit WITHDRAWAL EXIT DESTINATION </th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="WITHDRAWAL_EXIT_DESTINATIError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="WITHDRAWAL_EXIT_DESTINATIErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>EXIT DESTINATION DESCRIPTION</th>
 
            <td><asp:TextBox id="WITHDRAWAL_EXIT_DESTINATIEXIT_DESTINATION_DESCRIPTION" maxlength="30" Columns="30"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>DISPLAY ORDER</th>
 
            <td><asp:TextBox id="WITHDRAWAL_EXIT_DESTINATIDISPLAY_ORDER" maxlength="4" Columns="5"	runat="server"/>&nbsp;<em>(number to sort Descriptions in lists)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>GROUPING</th>
 
            <td>
              <select id="WITHDRAWAL_EXIT_DESTINATIGROUPING"  runat="server"></select>
 &nbsp; <em>(for Reports and selections)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY / DATE&nbsp;</th>
 
            <td><asp:Literal id="WITHDRAWAL_EXIT_DESTINATIlblLAST_ALTERED_BY" runat="server"/>&nbsp; / <asp:Literal id="WITHDRAWAL_EXIT_DESTINATIlblLAST_ALTERED_DATE" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='WITHDRAWAL_EXIT_DESTINATIButton_Insert' class="Button" type="submit" value="Add" OnServerClick='WITHDRAWAL_EXIT_DESTINATI_Insert' runat="server"/>
              <input id='WITHDRAWAL_EXIT_DESTINATIButton_Update' class="Button" type="submit" value="Submit" OnServerClick='WITHDRAWAL_EXIT_DESTINATI_Update' runat="server"/>
              <input id='WITHDRAWAL_EXIT_DESTINATIButton_Delete' class="Button" type="submit" value="Delete" OnServerClick='WITHDRAWAL_EXIT_DESTINATI_Delete' runat="server"/></td>
          </tr>
        </table>
        
  <input id="WITHDRAWAL_EXIT_DESTINATILAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="WITHDRAWAL_EXIT_DESTINATILAST_ALTERED_DATE" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>



  </span>
  <br>

</form>
</body>
</html>

<!--End ASPX page-->

