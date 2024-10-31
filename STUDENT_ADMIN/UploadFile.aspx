<!--ASPX page @1-8762FDE0-->
    <%@ Page language="vb" CodeFile="UploadFile.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.UploadFile.UploadFilePage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.UploadFile" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>NewPage1</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">



  <span id="NewRecord1Holder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>File Upload</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="NewRecord1Error" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="NewRecord1ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>
            <p>Upload File:</p>
            </th>
 
            <td>
              
  <CC:FileUploadControl id="NewRecord1upload1" DeleteCaption='Delete' runat="server"/>
  </td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='NewRecord1Button_Insert' class="Button" type="submit" value="Add" OnServerClick='NewRecord1_Insert' runat="server"/>
              <input id='NewRecord1Button_Update' class="Button" type="submit" value="Submit" OnServerClick='NewRecord1_Update' runat="server"/>
              <input id='NewRecord1Button_Delete' class="Button" type="submit" value="Delete" OnServerClick='NewRecord1_Delete' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  

</form>
</body>
</html>

<!--End ASPX page-->

