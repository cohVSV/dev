<!--ASPX page @1-D0D2A2E0-->
    <%@ Page language="vb" CodeFile="STAFF_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.STAFF_maint.STAFF_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.STAFF_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>STAFF</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/> </p>
<p><a id="Link1" href="" class="Button" runat="server"  >Back to Staff List</a></p>

  <span id="STAFFHolder" runat="server">
    


    <table cellspacing="0" cellpadding="0" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Add/Edit STAFF </th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="STAFFError" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="4"><asp:Label ID="STAFFErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Controls">
                        <th>STAFF ID:</th>
 
                        <td>
                            <asp:TextBox id="STAFFStaffID" tabindex="1"	runat="server"/>
                            <asp:Literal id="STAFFStaffID_view" runat="server"/> </td> 
                        <td>&nbsp;<asp:Literal id="STAFFlblLoginID" runat="server"/></td> 
                        <td><asp:TextBox id="STAFFLoginID"	runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>TITLE</th>
 
                        <td><asp:TextBox id="STAFFSALUTATION" tabindex="2" maxlength="20" Columns="20"	runat="server"/></td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>SURNAME</th>
 
                        <td><asp:TextBox id="STAFFSURNAME" tabindex="3" maxlength="30" Columns="30"	runat="server"/></td> 
                        <td>&nbsp;FIRSTNAME</td> 
                        <td>&nbsp;<asp:TextBox id="STAFFFIRSTNAME" tabindex="4" ToolTip="" maxlength="30" Columns="30"	runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>MIDDLENAME</th>
 
                        <td><asp:TextBox id="STAFFMIDDLENAME" tabindex="5" maxlength="30" Columns="30"	runat="server"/></td> 
                        <td></td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>TEACHER FLAG</th>
 
                        <td><asp:CheckBox id="STAFFTEACHER_FLAG" tabindex="7" runat="server"/></td> 
                        <td>&nbsp;ACTIVE?</td> 
                        <td>&nbsp; <asp:CheckBox id="STAFFSTATUS" tabindex="8" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>SECURITY GROUP NAME</th>
 
                        <td>
                            <select id="STAFFGROUP_ID" tabindex="9"  runat="server"></select>
 </td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>SECURITY Additional&nbsp;</th>
 
                        <td colspan="3">
                            <asp:CheckBoxList id="STAFFCheckboxList_SECURITY_FUNCTIONS" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>LAST ALTERED BY</th>
 
                        <td><asp:Literal id="STAFFlblLAST_ALTERED_BY" runat="server"/></td> 
                        <td>&nbsp;LAST ALTERED DATE</td> 
                        <td>&nbsp;<asp:Literal id="STAFFlblLAST_ALTERED_DATE" runat="server"/></td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="4" align="right">
                            <input id='STAFFButton_Insert' type="submit" tabindex="10" class="Button" value="Add" OnServerClick='STAFF_Insert' runat="server"/>
                            <input id='STAFFButton_Update' type="submit" tabindex="11" class="Button" value="Submit" OnServerClick='STAFF_Update' runat="server"/>
                            <input id='STAFFButton_Delete' type="submit" tabindex="12" class="Button" value="Delete" OnServerClick='STAFF_Delete' runat="server"/></td>
                    </tr>
                </table>
                
  <input id="STAFFCAMPUS_CODE" type="hidden"  runat="server"/>
  
  <input id="STAFFhidden_LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="STAFFhidden_LAST_ALTERED_DATE" type="hidden"  runat="server"/>
  
  <input id="STAFFHidden_LOGIN_ID" type="hidden"  runat="server"/>
  
  <input id="STAFFHidden_SECURITY_FUNCTIONS" type="hidden"  runat="server"/>
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

