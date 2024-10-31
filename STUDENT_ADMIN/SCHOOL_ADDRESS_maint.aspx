<!--ASPX page @1-02E75E79-->
    <%@ Page language="vb" CodeFile="SCHOOL_ADDRESS_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.SCHOOL_ADDRESS_maint.SCHOOL_ADDRESS_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.SCHOOL_ADDRESS_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 4.01.00.06"><meta name="description" content="Add or Edit School address (only accessable from School Maint page)"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>SCHOOL - Address Maintain</title>



<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_SCHOOLADDRESS_Button_Delete_OnClick @6-DB0D54F8
function page_SCHOOLADDRESS_Button_Delete_OnClick()
{
    var result;
//End page_SCHOOLADDRESS_Button_Delete_OnClick

//Confirmation Message @7-8243B274
    return confirm('Delete record?');
//End Confirmation Message

//Close page_SCHOOLADDRESS_Button_Delete_OnClick @6-BC33A33A
    return result;
}
//End Close page_SCHOOLADDRESS_Button_Delete_OnClick

//page_SCHOOLADDRESS_Button_Cancel_OnClick @8-E8E53573
function page_SCHOOLADDRESS_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_SCHOOLADDRESS_Button_Cancel_OnClick

//bind_events @1-76035F58
function bind_events() {
    addEventHandler("SCHOOLADDRESSButton_Delete","click",page_SCHOOLADDRESS_Button_Delete_OnClick);
    addEventHandler("SCHOOLADDRESSButton_Cancel","click",page_SCHOOLADDRESS_Button_Cancel_OnClick);
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

window.onload = bind_events; 

//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>

  <span id="SCHOOLADDRESSHolder" runat="server">
    


  <p><a id="SCHOOLADDRESSlinkSchoolMaint" href="" class="Button" runat="server"  >Back to School Page</a></p>
  <table cellspacing="0" cellpadding="0" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Add/Edit ADDRESS </th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="SCHOOLADDRESSError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="4"><asp:Label ID="SCHOOLADDRESSErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>SCHOOL&nbsp;</th>
 
            <td><asp:Literal id="SCHOOLADDRESSlblSCHOOLNO" runat="server"/>&nbsp; <asp:Literal id="SCHOOLADDRESSlblSCHOOLNAME" runat="server"/></td> 
            <td>&nbsp;Address ID</td> 
            <td><asp:Literal id="SCHOOLADDRESSlblADDRESS_ID" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>ADDRESSEE</th>
 
            <td><asp:TextBox id="SCHOOLADDRESSADDRESSEE" maxlength="60" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>AGENT</th>
 
            <td><asp:TextBox id="SCHOOLADDRESSAGENT" maxlength="60" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>ADDRESS</th>
 
            <td><asp:TextBox id="SCHOOLADDRESSADDR1" maxlength="50" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td><asp:TextBox id="SCHOOLADDRESSADDR2" maxlength="50" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>SUBURB /&nbsp;TOWN</th>
 
            <td><asp:TextBox id="SCHOOLADDRESSSUBURB_TOWN" maxlength="30" Columns="30"	runat="server"/></td> 
            <td>STATE&nbsp;</td> 
            <td><asp:TextBox id="SCHOOLADDRESSSTATE" maxlength="20" Columns="20"	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>POSTCODE</th>
 
            <td><asp:TextBox id="SCHOOLADDRESSPOSTCODE" maxlength="10" Columns="10"	runat="server"/></td> 
            <td>COUNTRY&nbsp;</td> 
            <td><asp:TextBox id="SCHOOLADDRESSCOUNTRY" maxlength="20" Columns="20"	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>PHONE 1</th>
 
            <td><asp:TextBox id="SCHOOLADDRESSPHONE_A" maxlength="15" Columns="15"	runat="server"/></td> 
            <td>PHONE 2&nbsp;</td> 
            <td><asp:TextBox id="SCHOOLADDRESSPHONE_B" maxlength="15" Columns="15"	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>FAX</th>
 
            <td><asp:TextBox id="SCHOOLADDRESSFAX" maxlength="15" Columns="15"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>EMAIL ADDRESS</th>
 
            <td><asp:TextBox id="SCHOOLADDRESSEMAIL_ADDRESS" maxlength="50" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><strong>Billing / Accounts Email</strong></th>
 
            <td><asp:TextBox id="SCHOOLADDRESSEMAIL_ADDRESS2" maxlength="50" Columns="50"	runat="server"/></td> 
            <td>&nbsp;<em>Only for Invoices / Accounts</em></td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY / DATE</th>
 
            <td><asp:Literal id="SCHOOLADDRESSLAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="SCHOOLADDRESSLAST_ALTERED_DATE" runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="4" align="right">
              <input id='SCHOOLADDRESSButton_Insert' type="submit" class="Button" value="Add" OnServerClick='SCHOOLADDRESS_Insert' runat="server"/>
              <input id='SCHOOLADDRESSButton_Update' type="submit" class="Button" value="Update" OnServerClick='SCHOOLADDRESS_Update' runat="server"/>
              <input id='SCHOOLADDRESSButton_Delete' type="submit" class="Button" value="Delete" OnServerClick='SCHOOLADDRESS_Delete' runat="server"/>
              <input id='SCHOOLADDRESSButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='SCHOOLADDRESS_Cancel' runat="server"/></td>
          </tr>
        </table>
        
  <input id="SCHOOLADDRESSHidden_LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="SCHOOLADDRESSHidden_LAST_ALTERED_DATE" type="hidden"  runat="server"/>
  
  <input id="SCHOOLADDRESSHiddenSCHOOLNO" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>


&nbsp;<asp:Literal id="SCHOOLADDRESSlblDebug" runat="server"/>
  </span>
  <br>

</form>
</body>
</html>

<!--End ASPX page-->

