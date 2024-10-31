<!--ASPX page @1-DB131897-->
    <%@ Page language="vb" CodeFile="LANGUAGE_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.LANGUAGE_maint.LANGUAGE_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.LANGUAGE_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>LANGUAGE</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<DECV_PROD2007:Header id="Header" runat="server"/> 

  <span id="LANGUAGEHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Add/Edit LANGUAGE </th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="LANGUAGEError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="LANGUAGEErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td>&nbsp;Both fields mandatory and to match Department values</td>
          </tr>
 
          <tr class="Controls">
            <th>Language Code</th>
 
            <td><asp:TextBox id="LANGUAGELANG_CODE" maxlength="6" Columns="6"	runat="server"/><br>
              <em>unique ID, and match Department Codes</em></td>
          </tr>
 
          <tr class="Controls">
            <th>Language Description</th>
 
            <td><asp:TextBox id="LANGUAGELANG_DESCRIPTION" maxlength="30" Columns="30"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td>&nbsp;<asp:Literal id="LANGUAGElabel_Last_altered_by" runat="server"/>&nbsp;/ <asp:Literal id="LANGUAGElabel_last_altered_date" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">
              <input id='LANGUAGEButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='LANGUAGE_Cancel' runat="server"/>&nbsp;&nbsp;&nbsp;&nbsp;
              <input id='LANGUAGEButton_Insert' type="submit" class="Button" value="Add" OnServerClick='LANGUAGE_Insert' runat="server"/>
              <input id='LANGUAGEButton_Update' type="submit" class="Button" value="Submit" OnServerClick='LANGUAGE_Update' runat="server"/>
              <input id='LANGUAGEButton_Delete' type="submit" class="Button" value="Delete" OnServerClick='LANGUAGE_Delete' runat="server"/></td>
          </tr>
        </table>
        
  <input id="LANGUAGELAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="LANGUAGELAST_ALTERED_DATE" type="hidden"  runat="server"/>
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

