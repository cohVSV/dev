<!--ASPX page @1-D9ECC572-->
    <%@ Page language="vb" CodeFile="ASSIGNMENT_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.ASSIGNMENT_maint.ASSIGNMENT_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.ASSIGNMENT_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>ASSIGNMENT</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p align="center"><a id="Link1" href="" class="Button" runat="server"  >back to Assignment List</a></p>
<p>

  <span id="Assignment_maintHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" width="60%" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Add/Edit Assignment</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
          </tr>
 
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="Assignment_maintError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="Assignment_maintErrorLabel" runat="server"/></td> 
          </tr>
 
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th colspan="2">Subject: <asp:Literal id="Assignment_maintlblSubjectID" runat="server"/>&nbsp;: <asp:Literal id="Assignment_maintlblSubjectName" runat="server"/></th>
 
          </tr>
 
          <tr class="Controls">
            <th>Assignment ID:</th>
 
            <td><asp:TextBox id="Assignment_mainttxtASSIGNMENT_ID" maxlength="4" Columns="4"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>Assignment Description:</th>
 
            <td><asp:TextBox id="Assignment_mainttxtASSIGNMENT_DESCRIPTION" maxlength="60" Columns="60"	runat="server"/><br>
              <em>(max. 60 chars.)</em></td> 
          </tr>
 
          <tr class="Controls">
            <th>Status:</th>
 
            <td>
              <asp:RadioButtonList id="Assignment_maintradioSTATUS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY / DATE</th>
 
            <td><asp:Literal id="Assignment_maintlblLAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="Assignment_maintlblLAST_ALTERED_DATE" runat="server"/></td> 
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='Assignment_maintButton_Insert' class="Button" type="submit" value="Add" OnServerClick='Assignment_maint_Insert' runat="server"/>
              <input id='Assignment_maintButton_Update' class="Button" type="submit" value="Update" OnServerClick='Assignment_maint_Update' runat="server"/>
              <input id='Assignment_maintButton_Cancel' class="Button" type="submit" value="Cancel" OnServerClick='Assignment_maint_Cancel' runat="server"/></td> 
          </tr>
 
        </table>
 
  <input id="Assignment_mainthidden_SUBJECT_ID" type="hidden"  runat="server"/>
  
  <input id="Assignment_mainthidden_LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="Assignment_mainthidden_LAST_ALTERED_DATE" type="hidden"  runat="server"/>
  </td> 
    </tr>
 
  </table>



  </span>
  </p>

</form>
</body>
</html>

<!--End ASPX page-->

