<!--ASPX page @1-F87A98E1-->
    <%@ Page language="vb" CodeFile="Student_Address_panels_maintain.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_Address_panels_maintain.Student_Address_panels_maintainPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_Address_panels_maintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 4.1.00.032"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Address maintain (panels)</title>


<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
//End Include Common JSFunctions
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" src="js/pt/prototype.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/pt/prototype_ccs.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">


//page_EditAddress2_Button_Delete_OnClick @244-32CFEB0A
function page_EditAddress2_Button_Delete_OnClick()
{
    var result;
//End page_EditAddress2_Button_Delete_OnClick

//Confirmation Message @468-E0062B4F
    return confirm('This will Remove this address from this Student.\n\n A New Address may be added if needed.');
//End Confirmation Message

//Close page_EditAddress2_Button_Delete_OnClick @244-BC33A33A
    return result;
}
//End Close page_EditAddress2_Button_Delete_OnClick

//page_EditAddress_cbox_same_as_school_OnClick @323-072727D0
function page_EditAddress_cbox_same_as_school_OnClick()
{
    var result;
//End page_EditAddress_cbox_same_as_school_OnClick

//Custom Code @343-2A29BDB7
    // -------------------------
    // ERA: when loading, if the checkbox for 'Same as School' is ticked then disable all the postal fields
    // and we copy the School's PostalAddress ID into PostalAddress as the user has ticked or unticked it
    var tmpPostalIDorig = document.getElementById('EditAddresshidden_ADDRESS_ID').value;
    var tmpSchoolAddreID = document.getElementById('EditAddresshidden_SCHOOL_ADDRESS_ID').value;
   var tmpformname = "EditAddress";
   if (this.checked) {
                //checked then collect School details and update/lock form fields
             Address_PTAutoFill_start(this.form, tmpSchoolAddreID,tmpformname);
                         // added as the checkbox wasn't going to database
             document.getElementById(tmpformname+'hidden_flag_same_as').value="1";
   } else {
         // untick then check what was there prviously and change accordingly
        if (tmpSchoolAddreID==tmpPostalIDorig) {
            // then WAS the same so clear the Postal Address so it can be entered
                        //Address_PTAutoFill_start(this.form, 0,tmpformname);
                        clearAddressForSameAs(this, tmpformname);
                                                // added as the checkbox wasn't going to database
             document.getElementById(tmpformname+'hidden_flag_same_as').value="0";
        } else {
            //was different so copy the original Postal Address ID back in          
            Address_PTAutoFill_start(this.form, tmpPostalIDorig,tmpformname);
                        // added as the checkbox wasn't going to database
             document.getElementById(tmpformname+'hidden_flag_same_as').value="0";
        }
        }
    toggleAddressForSameAs(this, tmpformname);    // lock/unlock the fields based on tickbox
    result=true;
    // -------------------------
//End Custom Code

//Close page_EditAddress_cbox_same_as_school_OnClick @323-BC33A33A
    return result;
}
//End Close page_EditAddress_cbox_same_as_school_OnClick


//page_EditAddress_OnLoad @10-8714AF74
function page_EditAddress_OnLoad(form)
{
    var result;
//End page_EditAddress_OnLoad

//Custom Code @339-2A29BDB7
    // -------------------------
    // ERA: when loading, if the checkbox for 'Same as School' is ticked then disable all the postal fields
        var checkbox = document.getElementById('EditAddresscbox_same_as_school');
        toggleAddressForSameAs(checkbox,"EditAddress");
        result=true;
    // -------------------------
//End Custom Code

//Close page_EditAddress_OnLoad @10-BC33A33A
    return result;
}
//End Close page_EditAddress_OnLoad

//page_EditAddress1_cbox_same_as_postal_OnClick @330-FB433D70
function page_EditAddress1_cbox_same_as_postal_OnClick()
{
    var result;
//End page_EditAddress1_cbox_same_as_postal_OnClick

//Custom Code @338-2A29BDB7
    // -------------------------
    // ERA: when loading, if the checkbox for 'Same as Postal' is ticked then disable all the Current fields
    // and we copy the pages PostalAddress ID into PostalAddress as the user has ticked or unticked it
        // 7-Mar-2011|EA| to allow 'New Address' when the 'Same as Postal' is unticked, then show the new button (unfuddle 349 + 365)

    var tmpThisIDorig = document.getElementById('EditAddress1hidden_ADDRESS_ID').value;
    var tmpPostalAddreID = document.getElementById('EditAddress1hidden_postal_ADDRESS_ID').value;
   var tmpformname = "EditAddress1";
   if (this.checked) {
                //checked then collect Postal details and update/lock form fields
             Address_PTAutoFill_start(this.form, tmpPostalAddreID,tmpformname);
                         // added as the checkbox wasn't going to database
             document.getElementById(tmpformname+'hidden_flag_same_as').value="1";
                         //7-Mar-11|EA| show the New Address button
                         document.getElementById('EditAddress1Button_NewCurrentAddress').style.display = "none";

   } else {
         // untick then check what was there prviously and change accordingly
        if (tmpPostalAddreID==tmpThisIDorig) {
                // then WAS the same so clear the Postal Address so it can be entered
                //Address_PTAutoFill_start(this.form, -1,tmpformname);
                clearAddressForSameAs(this, tmpformname);
                                // added as the checkbox wasn't going to database
             document.getElementById(tmpformname+'hidden_flag_same_as').value="0";
        } else {
                //was different so copy the original Postal Address ID back in          
             Address_PTAutoFill_start(this.form, tmpThisIDorig,tmpformname);
                         // added as the checkbox wasn't going to database
             document.getElementById(tmpformname+'hidden_flag_same_as').value="0";
        }
                        //7-Mar-11|EA| hide the New Address button
                        document.getElementById('EditAddress1Button_NewCurrentAddress').style.display = "";
        }
    toggleAddressForSameAs(this, tmpformname);    // lock/unlock the fields based on tickbox
    result=true;
    // -------------------------
//End Custom Code

//Close page_EditAddress1_cbox_same_as_postal_OnClick @330-BC33A33A
    return result;
}
//End Close page_EditAddress1_cbox_same_as_postal_OnClick

//DEL      // -------------------------
//DEL      //7-Mar-2011|EA| clear out the Current address form if New Address button clicked
//DEL          var currtickbox = document.getElementById('EditAddress1cbox_same_as_postal');
//DEL          if (currtickbox) {
//DEL                  clearAddressForSameAs(currtickbox, "EditAddress1");
//DEL          }
//DEL      result=true;
//DEL      // -------------------------

//page_EditAddress1_OnLoad @195-9A284831
function page_EditAddress1_OnLoad(form)
{
    var result;
//End page_EditAddress1_OnLoad

//Custom Code @340-2A29BDB7
    // -------------------------
     // ERA: when loading, if the checkbox for 'Same as Postal' is ticked then disable all the postal fields
        var checkbox = document.getElementById('EditAddress1cbox_same_as_postal');
        toggleAddressForSameAs(checkbox,"EditAddress1");
                //7-Mar-11|EA| hide the New Address button
                document.getElementById('EditAddress1Button_NewCurrentAddress').style.display = "none";
        result=true;
    // -------------------------
//End Custom Code

//Close page_EditAddress1_OnLoad @195-BC33A33A
    return result;
}
//End Close page_EditAddress1_OnLoad

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//Custom Code @460-2A29BDB7
    // -------------------------
      if (tmpattendschool.length>0){
                alert('If the Attending School has CHANGED then the Postal Address for this student needs to be reviewed:\n\n- if moving TO VSV then enter new Postal Address\n- if moving to another school, check the Postal Address is correct');
        }
    // -------------------------
//End Custom Code

//Close page_OnLoad @1-BC33A33A
    return result;
}
//End Close page_OnLoad

//page_EditAddress2_Button_Cancel_OnClick @245-00136BD9
function page_EditAddress2_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_EditAddress2_Button_Cancel_OnClick

//page_EditAddress_Button_Delete_OnClick @13-6A64B04B
function page_EditAddress_Button_Delete_OnClick()
{
    disableValidation = true;
}
//End page_EditAddress_Button_Delete_OnClick

//page_EditAddress_Button_Cancel_OnClick @14-4ECE33B5
function page_EditAddress_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_EditAddress_Button_Cancel_OnClick

//page_EditAddress1_Button_Delete_OnClick @198-739BC475
function page_EditAddress1_Button_Delete_OnClick()
{
    disableValidation = true;
}
//End page_EditAddress1_Button_Delete_OnClick

//page_EditAddress1_Button_Cancel_OnClick @199-5731478B
function page_EditAddress1_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_EditAddress1_Button_Cancel_OnClick

//bind_events @1-00E315B9
function bind_events() {
    if(document.getElementById("EditAddress1Holder"))
    addEventHandler("EditAddress1","load",page_EditAddress1_OnLoad);
    addEventHandler("EditAddress1cbox_same_as_postal","click",page_EditAddress1_cbox_same_as_postal_OnClick);
    if(document.getElementById("EditAddressHolder"))
    addEventHandler("EditAddress","load",page_EditAddress_OnLoad);
    addEventHandler("EditAddresscbox_same_as_school","click",page_EditAddress_cbox_same_as_school_OnClick);
    addEventHandler("EditAddress2Button_Delete","click",page_EditAddress2_Button_Delete_OnClick);
    addEventHandler("EditAddress2Button_Cancel","click",page_EditAddress2_Button_Cancel_OnClick);
    addEventHandler("EditAddressButton_Delete","click",page_EditAddress_Button_Delete_OnClick);
    addEventHandler("EditAddressButton_Cancel","click",page_EditAddress_Button_Cancel_OnClick);
    addEventHandler("EditAddress1Button_Delete","click",page_EditAddress1_Button_Delete_OnClick);
    addEventHandler("EditAddress1Button_Cancel","click",page_EditAddress1_Button_Cancel_OnClick);
    page_OnLoad();
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

window.onload = bind_events; 

//Include User Scripts @1-5978D29F
</script>
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script



//End CCS script
</script>

</head>
<body>
<form runat="server">


<p align="center"><DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/></p>
<p style="BORDER-TOP: 1px solid; BORDER-RIGHT: 1px solid; BORDER-BOTTOM: 1px solid; COLOR: #4f8a10; PADDING-BOTTOM: 8px; PADDING-TOP: 8px; PADDING-LEFT: 5px; BORDER-LEFT: 1px solid; MARGIN: 10px 0px; PADDING-RIGHT: 5px; BACKGROUND-COLOR: #dff2bf" align="center"><em>To Change an Address, click the 'Edit Address' button next to the address, make changes, then click 'Update'</em></p>
<p align="center">

  <span id="ADDRESSHolder" runat="server">
    


    <table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Postal&nbsp;Address</th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="ADDRESSError" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="4"><asp:Label ID="ADDRESSErrorLabel" runat="server"/>&nbsp;</td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Bottom">
                        <td colspan="4" align="right"><a id="ADDRESSLink_EditPostal" href="" class="Button" style="HEIGHT: 20px; WIDTH: 90px; PADDING-BOTTOM: 7px; PADDING-TOP: 7px; PADDING-LEFT: 7px; PADDING-RIGHT: 7px" runat="server"  >Edit address</a></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>ADDRESSEE</th>
 
                        <td><asp:Literal id="ADDRESSADDRESSEE" runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>AGENT</th>
 
                        <td><asp:Literal id="ADDRESSAGENT" runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>ADDRESS</th>
 
                        <td><asp:Literal id="ADDRESSADDR1" runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td><asp:Literal id="ADDRESSADDR2" runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>SUBURB / TOWN</th>
 
                        <td><asp:Literal id="ADDRESSSUBURB_TOWN" runat="server"/>&nbsp;</td> 
                        <td>STATE</td> 
                        <td><asp:Literal id="ADDRESSSTATE" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>POSTCODE</th>
 
                        <td><asp:Literal id="ADDRESSPOSTCODE" runat="server"/>&nbsp;</td> 
                        <td>COUNTRY</td> 
                        <td><asp:Literal id="ADDRESSCOUNTRY" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>HOME PHONE</th>
 
                        <td><asp:Literal id="ADDRESSPHONE_A" runat="server"/>&nbsp;</td> 
                        <td>PHONE2/MOBILE</td> 
                        <td><asp:Literal id="ADDRESSPHONE_B" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>FAX</th>
 
                        <td><asp:Literal id="ADDRESSFAX" runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th><asp:Literal id="ADDRESSlblEmailType" runat="server"/>&nbsp;EMAIL ADDRESS</th>
 
                        <td colspan="3"><a id="ADDRESSEMAIL_ADDRESS" href="" runat="server"  ></a>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th><em>EMAIL ADDRESS 2</em></th>
 
                        <td colspan="3">
                            <a id="ADDRESSEMAIL_ADDRESS2" href="" runat="server"   Visible="False"></a>&nbsp;<em>(use&nbsp;<a id="ADDRESSLink_carer1" href="" class="Button" runat="server"  >Carer</a> for Parent or Supervisor email address - Jan 2011)</em></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>LAST ALTERED BY / DATE</th>
 
                        <td colspan="3"><asp:Literal id="ADDRESSLAST_ALTERED_BY" runat="server"/> / <asp:Literal id="ADDRESSLAST_ALTERED_DATE" runat="server"/>&nbsp;/ <asp:Literal id="ADDRESSlblAddressID" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="4" align="right"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>


&nbsp;
  </span>
  </p>
<p></p>
<p></p>
<p>

  <span id="EditAddressHolder" runat="server">
    


    <table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Postal&nbsp;Address</th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="EditAddressError" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="4"><asp:Label ID="EditAddressErrorLabel" runat="server"/>&nbsp;</td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>Check box if same as Attending School: <asp:CheckBox id="EditAddresscbox_same_as_school" runat="server"/></td> 
                        <td>&nbsp;<asp:Literal id="EditAddresslblChangeAttendingSchool" runat="server"/></td> 
                        <td>&nbsp;<input type="button" onclick="clickCopyFromCurrentAddressButton();" id="EditAddressButtonCopyFromCurrent" class="Button" value="Copy from Current Address" name="EditAddressButtonCopyFromCurrent"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>ADDRESSEE</strong></th>
 
                        <td><asp:TextBox id="EditAddressADDRESSEE" maxlength="60" Columns="50"	runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;
  <input id="EditAddresshidden_SCHOOL_ADDRESS_ID" type="hidden"  runat="server"/>
  </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>AGENT</th>
 
                        <td><asp:TextBox id="EditAddressAGENT" maxlength="60" Columns="50"	runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;
  <input id="EditAddresshidden_flag_same_as" type="hidden"  runat="server"/>
  </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>ADDRESS</th>
 
                        <td><asp:TextBox id="EditAddressADDR1" maxlength="50" Columns="50"	runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;
  <input id="EditAddresshidden_ADDRESS_ID" type="hidden"  runat="server"/>
  </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td><asp:TextBox id="EditAddressADDR2" maxlength="50" Columns="50"	runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;
  <input id="EditAddresshidden_CURRENT_ADDRESS_ID" type="hidden"  runat="server"/>
  </td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>SUBURB / TOWN</strong></th>
 
                        <td><asp:TextBox id="EditAddressSUBURB_TOWN" maxlength="30" Columns="30"	runat="server"/>&nbsp;</td> 
                        <td>STATE</td> 
                        <td><asp:TextBox id="EditAddressSTATE" maxlength="20" Columns="20"	runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>POSTCODE</th>
 
                        <td><asp:TextBox id="EditAddressPOSTCODE" maxlength="10" Columns="10"	runat="server"/>&nbsp;</td> 
                        <td><strong>COUNTRY</strong></td> 
                        <td><asp:TextBox id="EditAddressCOUNTRY" maxlength="20" Columns="20"	runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>HOME PHONE</th>
 
                        <td><asp:TextBox id="EditAddressPHONE_A" maxlength="15" Columns="15"	runat="server"/>&nbsp;</td> 
                        <td>PHONE2/MOBILE</td> 
                        <td><asp:TextBox id="EditAddressPHONE_B" maxlength="15" Columns="15"	runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>FAX</th>
 
                        <td><asp:TextBox id="EditAddressFAX" maxlength="15" Columns="15"	runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>EMAIL ADDRESS</th>
 
                        <td><asp:TextBox id="EditAddressEMAIL_ADDRESS" maxlength="50" Columns="50"	runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th><em>EMAIL ADDRESS 2</em></th>
 
                        <td>
                            <asp:TextBox id="EditAddressEMAIL_ADDRESS2" maxlength="50" Columns="50" Visible="False"	runat="server"/>&nbsp;<em>(use&nbsp;<a id="EditAddressLink_carer1" href="" class="Button" runat="server"  >Carer</a> or Parent or Supervisor email address - Jan 2011)</em></td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>LAST ALTERED BY / DATE</th>
 
                        <td colspan="3"><asp:Literal id="EditAddressLAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="EditAddressLAST_ALTERED_DATE" runat="server"/>&nbsp;/ <asp:Literal id="EditAddresslblAddressID" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="4" align="right">&nbsp; 
                            <input id='EditAddressButton_Insert' type="submit" class="Button" value="Add" OnServerClick='EditAddress_Insert' runat="server"/>
                            <input id='EditAddressButton_Update' type="submit" class="Button" value="Update" OnServerClick='EditAddress_Update' runat="server"/>
                            <input id='EditAddressButton_Delete' type="submit" class="Button" value="Delete" OnServerClick='EditAddress_Delete' runat="server"/>
                            <input id='EditAddressButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='EditAddress_Cancel' runat="server"/></td>
                    </tr>
                </table>
                
  <input id="EditAddressHidden_AddressHash" type="hidden"  runat="server"/>
  </td>
        </tr>
    </table>


&nbsp;
  </span>
  </p>
<p></p>
<p></p>
<p>

  <span id="ADDRESS1Holder" runat="server">
    


    <table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Current&nbsp;Address</th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="ADDRESS1Error" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="4"><asp:Label ID="ADDRESS1ErrorLabel" runat="server"/>&nbsp;</td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Bottom">
                        <td colspan="4" align="right"><a id="ADDRESS1Link_EditCurrent" href="" class="Button" style="HEIGHT: 20px; WIDTH: 90px; PADDING-BOTTOM: 7px; PADDING-TOP: 7px; PADDING-LEFT: 7px; PADDING-RIGHT: 7px" runat="server"  >Edit address</a></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>ADDRESSEE</th>
 
                        <td><asp:Literal id="ADDRESS1ADDRESSEE" runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>AGENT</th>
 
                        <td><asp:Literal id="ADDRESS1AGENT" runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>ADDRESS</th>
 
                        <td><asp:Literal id="ADDRESS1ADDR1" runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td><asp:Literal id="ADDRESS1ADDR2" runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>SUBURB / TOWN</th>
 
                        <td><asp:Literal id="ADDRESS1SUBURB_TOWN" runat="server"/>&nbsp;</td> 
                        <td>STATE</td> 
                        <td><asp:Literal id="ADDRESS1STATE" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>POSTCODE</th>
 
                        <td><asp:Literal id="ADDRESS1POSTCODE" runat="server"/>&nbsp;</td> 
                        <td>COUNTRY</td> 
                        <td><asp:Literal id="ADDRESS1COUNTRY" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>HOME PHONE</th>
 
                        <td><asp:Literal id="ADDRESS1PHONE_A" runat="server"/>&nbsp;</td> 
                        <td>PHONE2/MOBILE</td> 
                        <td><asp:Literal id="ADDRESS1PHONE_B" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>FAX</th>
 
                        <td><asp:Literal id="ADDRESS1FAX" runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>STUDENT EMAIL ADDRESS</strong></th>
 
                        <td colspan="3"><a id="ADDRESS1EMAIL_ADDRESS" href="" runat="server"  ></a>&nbsp; <em>(update through <a id="ADDRESS1Link_carer2" href="" class="Button" runat="server"  >Student Details</a>&nbsp;- May 2011)</em></td>
                    </tr>
 
                    <tr class="Controls">
                        <th><em>EMAIL ADDRESS 2</em></th>
 
                        <td colspan="3">
                            <a id="ADDRESS1EMAIL_ADDRESS2" href="" runat="server"   Visible="False"></a>&nbsp;<em>(use&nbsp;<a id="ADDRESS1Link_carer1" href="" class="Button" runat="server"  >Carer</a> or Parent or Supervisor email address - Jan 2011)</em></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>LAST ALTERED BY / DATE</th>
 
                        <td colspan="3"><asp:Literal id="ADDRESS1LAST_ALTERED_BY" runat="server"/> / <asp:Literal id="ADDRESS1LAST_ALTERED_DATE" runat="server"/>&nbsp;/ <asp:Literal id="ADDRESS1lblAddressID" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="4" align="right"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>



  </span>
  

  <span id="EditAddress1Holder" runat="server">
    


    <table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Current Address</th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="EditAddress1Error" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="4"><asp:Label ID="EditAddress1ErrorLabel" runat="server"/>&nbsp;</td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>Check box if same as Postal: <asp:CheckBox id="EditAddress1cbox_same_as_postal" runat="server"/>&nbsp;</td> 
                        <td colspan="2"><input type="button" onclick="clickNewAddressButton('EditAddress1cbox_same_as_postal','EditAddress1');" id="EditAddress1Button_NewCurrentAddress" class="Button" value="New Current Address" name="EditAddress1Button_NewCurrentAddress"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>ADDRESSEE</strong></th>
 
                        <td><asp:TextBox id="EditAddress1ADDRESSEE" maxlength="60" Columns="50"	runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;
  <input id="EditAddress1hidden_postal_ADDRESS_ID" type="hidden"  runat="server"/>
  </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>AGENT</th>
 
                        <td><asp:TextBox id="EditAddress1AGENT" maxlength="60" Columns="50"	runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;
  <input id="EditAddress1hidden_ADDRESS_ID" type="hidden"  runat="server"/>
  </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>ADDRESS</th>
 
                        <td><asp:TextBox id="EditAddress1ADDR1" maxlength="50" Columns="50"	runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;
  <input id="EditAddress1hidden_flag_same_as" type="hidden"  runat="server"/>
  </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td><asp:TextBox id="EditAddress1ADDR2" maxlength="50" Columns="50"	runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>SUBURB / TOWN</strong></th>
 
                        <td><asp:TextBox id="EditAddress1SUBURB_TOWN" maxlength="30" Columns="30"	runat="server"/>&nbsp;</td> 
                        <td>&nbsp;STATE</td> 
                        <td><asp:TextBox id="EditAddress1STATE" maxlength="20" Columns="20"	runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>POSTCODE</th>
 
                        <td><asp:TextBox id="EditAddress1POSTCODE" maxlength="10" Columns="10"	runat="server"/>&nbsp;</td> 
                        <td>&nbsp;<strong>COUNTRY</strong></td> 
                        <td><asp:TextBox id="EditAddress1COUNTRY" maxlength="20" Columns="20"	runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>HOME PHONE</th>
 
                        <td><asp:TextBox id="EditAddress1PHONE_A" maxlength="15" Columns="15"	runat="server"/>&nbsp;</td> 
                        <td>&nbsp;PHONE2/MOBILE</td> 
                        <td><asp:TextBox id="EditAddress1PHONE_B" maxlength="15" Columns="15"	runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>FAX</th>
 
                        <td><asp:TextBox id="EditAddress1FAX" maxlength="15" Columns="15"	runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>STUDENT EMAIL ADDRESS</strong></th>
 
                        <td>
  <input id="EditAddress1EMAIL_ADDRESS" type="hidden"  runat="server"/>
  &nbsp;<em>(update through <a id="EditAddress1Link_carer2" href="" class="Button" runat="server"  >Student Details</a>&nbsp; - May 2011)</em></td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th><em>EMAIL ADDRESS 2</em></th>
 
                        <td>
                            <asp:TextBox id="EditAddress1EMAIL_ADDRESS2" maxlength="50" Columns="50" Visible="False"	runat="server"/>&nbsp;<em>(use&nbsp;<a id="EditAddress1Link_carer1" href="" class="Button" runat="server"  >Carer</a> or Parent or Supervisor email address - Jan 2011)</em></td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>LAST ALTERED BY / DATE</th>
 
                        <td colspan="3"><asp:Literal id="EditAddress1LAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="EditAddress1LAST_ALTERED_DATE" runat="server"/>&nbsp;/ <asp:Literal id="EditAddress1lblAddressID" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="4" align="right">&nbsp; 
                            <input id='EditAddress1Button_Insert' type="submit" class="Button" value="Add" OnServerClick='EditAddress1_Insert' runat="server"/>
                            <input id='EditAddress1Button_Update' type="submit" class="Button" value="Update" OnServerClick='EditAddress1_Update' runat="server"/>
                            <input id='EditAddress1Button_Delete' type="submit" class="Button" value="Delete" OnServerClick='EditAddress1_Delete' runat="server"/>
                            <input id='EditAddress1Button_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='EditAddress1_Cancel' runat="server"/></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>


&nbsp;&nbsp;
  </span>
  
<p>
<p></p>
<p>

  <span id="ADDRESS2Holder" runat="server">
    


    <table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>S.A.C. Address</th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="ADDRESS2Error" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="4"><asp:Label ID="ADDRESS2ErrorLabel" runat="server"/>&nbsp;</td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Bottom">
                        <td colspan="4" align="right"><em>NOTE: Email and Phone numbers for School Supervisors should be added to Carer page </em><a id="ADDRESS2Link_EditOrigSAC" href="" class="Button" style="HEIGHT: 20px; WIDTH: 90px; PADDING-BOTTOM: 7px; PADDING-TOP: 7px; PADDING-LEFT: 7px; PADDING-RIGHT: 7px" runat="server"  >Edit address</a></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>ADDRESSEE</th>
 
                        <td><asp:Literal id="ADDRESS2ADDRESSEE" runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>AGENT</th>
 
                        <td><asp:Literal id="ADDRESS2AGENT" runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>ADDRESS</th>
 
                        <td><asp:Literal id="ADDRESS2ADDR1" runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td><asp:Literal id="ADDRESS2ADDR2" runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>SUBURB / TOWN</th>
 
                        <td><asp:Literal id="ADDRESS2SUBURB_TOWN" runat="server"/>&nbsp;</td> 
                        <td>STATE</td> 
                        <td><asp:Literal id="ADDRESS2STATE" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>POSTCODE</th>
 
                        <td><asp:Literal id="ADDRESS2POSTCODE" runat="server"/>&nbsp;</td> 
                        <td>COUNTRY</td> 
                        <td><asp:Literal id="ADDRESS2COUNTRY" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>HOME PHONE</th>
 
                        <td><asp:Literal id="ADDRESS2PHONE_A" runat="server"/>&nbsp;</td> 
                        <td>PHONE2/MOBILE</td> 
                        <td><asp:Literal id="ADDRESS2PHONE_B" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>FAX</th>
 
                        <td><asp:Literal id="ADDRESS2FAX" runat="server"/>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>EMAIL ADDRESS</th>
 
                        <td colspan="3"><a id="ADDRESS2EMAIL_ADDRESS" href="" runat="server"  ></a>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th><em>EMAIL ADDRESS 2</em></th>
 
                        <td colspan="3">
                            <a id="ADDRESS2EMAIL_ADDRESS2" href="" runat="server"   Visible="False"></a>&nbsp;<em>(use&nbsp;<a id="ADDRESS2Link_carer1" href="" class="Button" runat="server"  >Carer</a> or Parent or Supervisor email address - Jan 2011)</em></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>LAST ALTERED BY / DATE</th>
 
                        <td colspan="3"><asp:Literal id="ADDRESS2LAST_ALTERED_BY" runat="server"/> / <asp:Literal id="ADDRESS2LAST_ALTERED_DATE" runat="server"/>&nbsp; / <asp:Literal id="ADDRESS2lblAddressID" runat="server"/></td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="4" align="right"><em>(changed to from 'Original/S.A.C. Address' to 'SAC Address' July 2014 - in rare cases the 'Original Address' may be displayed. Read and interpret appropriately)</em></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>


&nbsp;
  </span>
  </p>
<p>

  <span id="EditAddress2Holder" runat="server">
    


    <table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>S.A.C. Address</th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="EditAddress2Error" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="4"><asp:Label ID="EditAddress2ErrorLabel" runat="server"/>&nbsp;</td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Controls">
                        <th><strong>ADDRESSEE</strong></th>
 
                        <td><asp:TextBox id="EditAddress2ADDRESSEE" maxlength="60" Columns="50"	runat="server"/></td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;
  <input id="EditAddress2hidden_ADDRESS_ID" type="hidden"  runat="server"/>
  </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>AGENT</th>
 
                        <td><asp:TextBox id="EditAddress2AGENT" maxlength="60" Columns="50"	runat="server"/></td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>ADDRESS</th>
 
                        <td><asp:TextBox id="EditAddress2ADDR1" maxlength="50" Columns="50"	runat="server"/></td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td><asp:TextBox id="EditAddress2ADDR2" maxlength="50" Columns="50"	runat="server"/></td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>SUBURB / TOWN</strong></th>
 
                        <td><asp:TextBox id="EditAddress2SUBURB_TOWN" maxlength="30" Columns="30"	runat="server"/></td> 
                        <td>STATE</td> 
                        <td><asp:TextBox id="EditAddress2STATE" maxlength="20" Columns="20"	runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>POSTCODE</th>
 
                        <td><asp:TextBox id="EditAddress2POSTCODE" maxlength="10" Columns="10"	runat="server"/></td> 
                        <td><strong>COUNTRY</strong></td> 
                        <td><asp:TextBox id="EditAddress2COUNTRY" maxlength="20" Columns="20"	runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>HOME PHONE</th>
 
                        <td><asp:TextBox id="EditAddress2PHONE_A" maxlength="15" Columns="15"	runat="server"/></td> 
                        <td>PHONE2/MOBILE</td> 
                        <td><asp:TextBox id="EditAddress2PHONE_B" maxlength="15" Columns="15"	runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>FAX</th>
 
                        <td><asp:TextBox id="EditAddress2FAX" maxlength="15" Columns="15"	runat="server"/></td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th><em>EMAIL ADDRESS</em></th>
 
                        <td><asp:TextBox id="EditAddress2EMAIL_ADDRESS" maxlength="50" Columns="50"	runat="server"/>&nbsp;<em>(use&nbsp;<a id="EditAddress2Link_carer1" href="" class="Button" runat="server"  >Carer</a> or Parent or Supervisor email address - Jan 2011)</em></td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th><em>EMAIL ADDRESS 2</em></th>
 
                        <td>
                            <asp:TextBox id="EditAddress2EMAIL_ADDRESS2" maxlength="50" Columns="50" Visible="False"	runat="server"/>&nbsp;<em>(use&nbsp;<a id="EditAddress2Link_carer2" href="" class="Button" runat="server"  >Carer</a> or Parent or Supervisor email address - Jan 2011)</em></td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>LAST ALTERED BY / DATE</th>
 
                        <td colspan="3"><asp:Literal id="EditAddress2LAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="EditAddress2LAST_ALTERED_DATE" runat="server"/>&nbsp;/ <asp:Literal id="EditAddress2lblAddressID" runat="server"/></td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="4" align="right"><em>(changed to from 'Original/S.A.C. Address' to 'SAC Address' July 2014 - in rare cases the 'Original Address' may be displayed. Read and interpret appropriately)</em>&nbsp;</td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="4" align="right">&nbsp; 
                            <input id='EditAddress2Button_Delete' type="submit" class="Button" value="Remove from Student" OnServerClick='EditAddress2_Delete' runat="server"/>
                            <input id='EditAddress2Button_Insert' type="submit" class="Button" value="Add" OnServerClick='EditAddress2_Insert' runat="server"/>
                            <input id='EditAddress2Button_Update' type="submit" class="Button" value="Update" OnServerClick='EditAddress2_Update' runat="server"/>
                            <input id='EditAddress2Button_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='EditAddress2_Cancel' runat="server"/></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>



  </span>
  </p>
<script language="JavaScript" type="text/javascript">
// ERA: All the custom scripts will be down here to get them out of the way of the top scripts from CCS

function gup( name )
{
  // used to read values from Querystring
  name = name.replace(/[\[]/,"\\\[").replace(/[\]]/,"\\\]");
  var regexS = "[\\?&]"+name+"=([^&#]*)";
  var regex = new RegExp( regexS );
  var results = regex.exec( window.location.href );
  if( results == null )
    return "";
  else
    return results[1];
}

// get a flag of Attending School ID changed on Student Details Maintain for popup
var tmpattendschool = gup('flagattendingschool');


function Address_PTAutoFill_start(sender, addressid, formname) {
        if (addressid!="") {
    new Ajax.Request("services/getAddressDetailsForAutoFill.aspx?keyword=" + addressid, {
        method: "get",
        requestHeaders: ['If-Modified-Since', new Date(0)],
        onSuccess: function(transport) {
            var valuesRow = eval(transport.responseText)[0];
            getSameLevelCtl(formname+"ADDRESSEE", sender).value = rtrim(valuesRow["ADDRESSEE"]);
            getSameLevelCtl(formname+"AGENT", sender).value = rtrim(valuesRow["AGENT"]);
            getSameLevelCtl(formname+"ADDR1", sender).value = rtrim(valuesRow["ADDR1"]);
            getSameLevelCtl(formname+"ADDR2", sender).value = rtrim(valuesRow["ADDR2"]);
            getSameLevelCtl(formname+"SUBURB_TOWN", sender).value = rtrim(valuesRow["SUBURB_TOWN"]);
            getSameLevelCtl(formname+"STATE", sender).value = rtrim(valuesRow["STATE"]);
            getSameLevelCtl(formname+"POSTCODE", sender).value = rtrim(valuesRow["POSTCODE"]);
            getSameLevelCtl(formname+"COUNTRY", sender).value = rtrim(valuesRow["COUNTRY"]);
            getSameLevelCtl(formname+"PHONE_A", sender).value = rtrim(valuesRow["PHONE_A"]);
            getSameLevelCtl(formname+"PHONE_B", sender).value = rtrim(valuesRow["PHONE_B"]);
            getSameLevelCtl(formname+"FAX", sender).value = rtrim(valuesRow["FAX"]);
            getSameLevelCtl(formname+"EMAIL_ADDRESS", sender).value = rtrim(valuesRow["EMAIL_ADDRESS"]);
            getSameLevelCtl(formname+"EMAIL_ADDRESS2", sender).value = rtrim(valuesRow["EMAIL_ADDRESS2"]);
        }, 
        onFailure: function(transport) {
            alert(transport.responseText);
        }
    });
        }
}


function toggleAddressForSameAs(cbox, formname) {
  // ERA: Feb-2009|EA| gets value of 'Same as School' checkbox and toggles the Postal Address appropriately
  //    cannot edit the fields without toggling off the checkbox first
        //visible fields
                document.getElementById(formname+'ADDRESSEE').disabled=(cbox.checked);
                document.getElementById(formname+'AGENT').disabled=(cbox.checked);
                document.getElementById(formname+'ADDR1').disabled=(cbox.checked);
                document.getElementById(formname+'ADDR2').disabled=(cbox.checked);
                document.getElementById(formname+'SUBURB_TOWN').disabled=(cbox.checked);
                document.getElementById(formname+'STATE').disabled=(cbox.checked);
                document.getElementById(formname+'POSTCODE').disabled=(cbox.checked);
                document.getElementById(formname+'COUNTRY').disabled=(cbox.checked);
                document.getElementById(formname+'PHONE_A').disabled=(cbox.checked);
                document.getElementById(formname+'PHONE_B').disabled=(cbox.checked);
                document.getElementById(formname+'FAX').disabled=(cbox.checked);
                                if (formname!='EditAddress1') {
                                        // 5-May-2011|EA| ignore if Current address - unfuddle #365
                        document.getElementById(formname+'EMAIL_ADDRESS').disabled=(cbox.checked);
                                }
                //document.getElementById(formname+'EMAIL_ADDRESS2').disabled=(cbox.checked);   //25-Feb-2011|EA| unfuddle #373
                return true;
}


function clearAddressForSameAs(cbox, formname) {
  // ERA: Feb-2009|EA| gets value of 'Same as School' checkbox and toggles the Postal Address appropriately
  //    cannot edit the fields without toggling off the checkbox first
        //visible fields
                if (!cbox.checked) {
                //document.getElementById(formname+'hidden_ADDRESS_ID').value = "";
                document.getElementById(formname+'ADDRESSEE').value = "";
                document.getElementById(formname+'AGENT').value = "";
                document.getElementById(formname+'ADDR1').value = "";
                document.getElementById(formname+'ADDR2').value = "";
                document.getElementById(formname+'SUBURB_TOWN').value = "";
                document.getElementById(formname+'STATE').value = "";
                document.getElementById(formname+'POSTCODE').value = "";
                document.getElementById(formname+'COUNTRY').value = "";
                document.getElementById(formname+'PHONE_A').value = "";
                document.getElementById(formname+'PHONE_B').value = "";
                document.getElementById(formname+'FAX').value = "";
                                if (formname!='EditAddress1') {
                                        // 5-May-2011|EA| ignore if Current address - unfuddle #365
                        document.getElementById(formname+'EMAIL_ADDRESS').value = "";
                                } 
                //document.getElementById(formname+'EMAIL_ADDRESS2').value = "";
                }
                return true;
}

function clickNewAddressButton(cbox, formname) {
        //7-Mar-2011|EA| clear out the Current address form if New Address button clicked
        //var currtickbox = document.getElementById('EditAddress1cbox_same_as_postal');
        var currtickbox = document.getElementById(cbox);
        if (currtickbox) {
                clearAddressForSameAs(currtickbox, formname);
        }
}


function trim(stringToTrim) {
        return stringToTrim.replace(/^\s+|\s+$/g,"");
}
function ltrim(stringToTrim) {
        return stringToTrim.replace(/^\s+/,"");
}
function rtrim(stringToTrim) {
        return stringToTrim.replace(/\s+$/,"");
}

function clickCopyFromCurrentAddressButton() {
  //26-Nov-2015|EA| when student changes from School based to non-school then should allow copy of Current address
  //  into the Postal address. Adding button instead of checkbox (unfuddle #478)
  // based in part on the checkbox code to fill the input boxes using the address id from the Current (EditAddress1) form
  var tmpCurrentID = document.getElementById('EditAddresshidden_CURRENT_ADDRESS_ID').value;
  var tmpformname = "EditAddress";
      if (tmpCurrentID > 0) {
                        // uncheck the box for same as school if it's checked
                        document.getElementById('EditAddresscbox_same_as_school').checked = false;
                        document.getElementById('EditAddresshidden_flag_same_as').value="0";
           //checked then collect Postal details and update/lock form fields
                        Address_PTAutoFill_start(this.form, tmpCurrentID,tmpformname);
                        document.getElementById('EditAddresshidden_ADDRESS_ID').value=tmpCurrentID;
           document.getElementById('EditAddressButtonCopyFromCurrent').style.display = "none";
    }
}

// 25 Jan 2021|RW| Perform a null check here, as sometimes the parent panel (a server component) isn't sent to the client.
if (document.getElementById('EditAddressButtonCopyFromCurrent') !== null)
{
   if (tmpattendschool == "")
   {
      document.getElementById('EditAddressButtonCopyFromCurrent').style.display = "none";
   } else
   {
      document.getElementById('EditAddressButtonCopyFromCurrent').style.display = "";
   }
}



</script>

</form>
</body>
</html>

<!--End ASPX page-->

