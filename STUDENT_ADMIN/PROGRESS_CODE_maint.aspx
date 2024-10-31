<!--ASPX page @1-F197B151-->
    <%@ Page language="vb" CodeFile="PROGRESS_CODE_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.PROGRESS_CODE_maint.PROGRESS_CODE_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.PROGRESS_CODE_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
	<html>
<head>
<meta http-equiv="content-type" content="text/html; charset=windows-1252">
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0">

<title>PROGRESS CODE</title>

<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<DECV_PROD2007:Header id="Header" runat="server"/>


  <span id="PROGRESS_CODEHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table cellspacing="0" cellpadding="0" border="0" class="Header">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
            <th>Add/Edit PROGRESS CODE </th>
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="PROGRESS_CODEError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="PROGRESS_CODEErrorLabel" runat="server"/></td> 
          </tr>
 
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>TITLE</th>
 
            <td><asp:TextBox id="PROGRESS_CODEPROGRESS_CODE_TITLE" maxlength="30" Columns="30"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>STATUS</th>
 
            <td><asp:CheckBox id="PROGRESS_CODESTATUS" runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY</th>
 
            <td><asp:TextBox id="PROGRESS_CODELAST_ALTERED_BY" maxlength="8" Columns="8"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED DATE</th>
 
            <td><asp:TextBox id="PROGRESS_CODELAST_ALTERED_DATE" maxlength="100" Columns="10"	runat="server"/></td> 
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">
              <input id='PROGRESS_CODEButton_Insert' type="submit" value="Add" class="Button" OnServerClick='PROGRESS_CODE_Insert' runat="server"/>
              <input id='PROGRESS_CODEButton_Update' type="submit" value="Submit" class="Button" OnServerClick='PROGRESS_CODE_Update' runat="server"/>
              <input id='PROGRESS_CODEButton_Delete' type="submit" value="Delete" class="Button" OnServerClick='PROGRESS_CODE_Delete' runat="server"/></td> 
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

