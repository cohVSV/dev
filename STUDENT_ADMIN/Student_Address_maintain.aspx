<!--ASPX page @1-EB157B89-->
    <%@ Page language="vb" CodeFile="Student_Address_maintain.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_Address_maintain.Student_Address_maintainPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_Address_maintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Address Maintain</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
</script>
<script language="JavaScript" type="text/javascript">

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


function togglePostalForSchool(cbox) {
  // ERA: Feb-2009|EA| gets value of 'Same as School' checkbox and toggles the Postal Address appropriately
  //    cannot edit the fields without toggling off the checkbox first
        //visible fields
                //TODO: check disabled vs readonly for locking out fields and then allowing them to be updated by
                document.getElementById('viewStudentMaintain_AddrePostal_ADDRESSEE').disabled=(cbox.checked);
                document.getElementById('viewStudentMaintain_AddrePostal_AGENT').disabled=(cbox.checked);
                document.getElementById('viewStudentMaintain_AddrePostal_ADDR1').disabled=(cbox.checked);
                document.getElementById('viewStudentMaintain_AddrePostal_ADDR2').disabled=(cbox.checked);
                document.getElementById('viewStudentMaintain_AddrePostal_SUBURB_TOWN').disabled=(cbox.checked);
                document.getElementById('viewStudentMaintain_AddrePostal_STATE').disabled=(cbox.checked);
                document.getElementById('viewStudentMaintain_AddrePostal_POSTCODE').disabled=(cbox.checked);
                document.getElementById('viewStudentMaintain_AddrePostal_COUNTRY').disabled=(cbox.checked);
                document.getElementById('viewStudentMaintain_AddrePostal_PHONE_A').disabled=(cbox.checked);
                document.getElementById('viewStudentMaintain_AddrePostal_PHONE_B').disabled=(cbox.checked);
                document.getElementById('viewStudentMaintain_AddrePostal_FAX').disabled=(cbox.checked);
                document.getElementById('viewStudentMaintain_AddrePostal_EMAIL_ADDRESS').disabled=(cbox.checked);
                document.getElementById('viewStudentMaintain_AddrePostal_EMAIL_ADDRESS2').disabled=(cbox.checked);
                return true;
}


//Include Common JSFunctions @1-12DCE9BA
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Include User Scripts @1-51F273ED
</script>
<script language="JavaScript" src="js/pt/prototype.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/pt/prototype_ccs.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include User Scripts

//page_viewStudentMaintain_Addre_cbox_same_as_school_OnClick @112-46B84AD8
function page_viewStudentMaintain_Addre_cbox_same_as_school_OnClick()
{
    var result;
//End page_viewStudentMaintain_Addre_cbox_same_as_school_OnClick

//Custom Code @133-2A29BDB7
    // -------------------------
    // ERA: when loading, if the checkbox for 'Same as School' is ticked then disable all the postal fields
    // and we copy the School's PostalAddress ID into PostalAddress as the user has ticked or unticked it
                var tmpPostalIDorig = document.getElementById('viewStudentMaintain_AddrePostAdd_ADDRESS_ID_orig').value;
                var tmpSchoolAddreID = document.getElementById('viewStudentMaintain_AddrePostAdd_SCHOOL_ADDRESS_ID_ifknown').value;

        if (this.checked) {
                        // if checked then always set Postal Address to School's Address ID
   //                             document.getElementById('viewStudentMaintain_AddrePostAdd_ADDRESS_ID').value=tmpSchoolAddreID;
   //                             document.getElementById('viewStudentMaintain_AddrePOSTAL_ADDRESS_ID').value=tmpSchoolAddreID;
                                viewStudentMaintain_AddrePostAdd_SCHOOL_ADDRESS_ID_ifknownPTAutoFill1_start(this.form, tmpSchoolAddreID);
                                document.getElementById('viewStudentMaintain_Addreflag_same_as_school').value='1';
                } else {
                        // untick then check what was there prviously and change accordingly
                        if (tmpSchoolAddreID==tmpPostalIDorig) {
                                // then WAS the same so clear the Postal Address so it can be entered
     //                                         document.getElementById('viewStudentMaintain_AddrePostAdd_ADDRESS_ID').value='';
     //                           document.getElementById('viewStudentMaintain_AddrePOSTAL_ADDRESS_ID').value='';
                                document.getElementById('viewStudentMaintain_Addreflag_same_as_school').value='0';
                        } else {
                                //was different so copy the original Postal Address ID back in          
     //                           document.getElementById('viewStudentMaintain_AddrePostAdd_ADDRESS_ID').value = tmpPostalIDorig;
     //                           document.getElementById('viewStudentMaintain_AddrePOSTAL_ADDRESS_ID').value=tmpPostalIDorig;
                                viewStudentMaintain_AddrePostAdd_SCHOOL_ADDRESS_ID_ifknownPTAutoFill1_start(this.form, tmpPostalIDorig);
                                document.getElementById('viewStudentMaintain_Addreflag_same_as_school').value='0';
                                }
                }
                togglePostalForSchool(this);    // lock/unlock the fields based on tickbox
        result=true;
 
    // -------------------------
//End Custom Code

//Close page_viewStudentMaintain_Addre_cbox_same_as_school_OnClick @112-BC33A33A
    return result;
}
//End Close page_viewStudentMaintain_Addre_cbox_same_as_school_OnClick

//page_viewStudentMaintain_Addre_cbox_same_as_postal_OnClick @113-D36B0504
function page_viewStudentMaintain_Addre_cbox_same_as_postal_OnClick()
{
    var result;
//End page_viewStudentMaintain_Addre_cbox_same_as_postal_OnClick

//Custom Code @125-2A29BDB7
    // -------------------------
    // ERA: if checked then copy POSTAL ADDRESS ID to CURR ADDRESS ID
        //1-Dec-2008|EA| and also copy the address values so the field validation doesn't fire off
        if (this.checked) {
                document.getElementById('viewStudentMaintain_AddreCurr_ADDRESS_ID').value=document.getElementById('viewStudentMaintain_AddrePostAdd_ADDRESS_ID').value;
                                //1-Dec-2008|EA| visible fields
                                document.getElementById('viewStudentMaintain_AddreCurr_ADDRESSEE').value=document.getElementById('viewStudentMaintain_AddrePostal_ADDRESSEE').value;
                                document.getElementById('viewStudentMaintain_AddreCurr_AGENT').value=document.getElementById('viewStudentMaintain_AddrePostal_AGENT').value;
                                document.getElementById('viewStudentMaintain_AddreCurr_ADDR1').value=document.getElementById('viewStudentMaintain_AddrePostal_ADDR1').value;
                                document.getElementById('viewStudentMaintain_AddreCurr_ADDR2').value=document.getElementById('viewStudentMaintain_AddrePostal_ADDR2').value;
                                document.getElementById('viewStudentMaintain_AddreCurr_SUBURB_TOWN').value=document.getElementById('viewStudentMaintain_AddrePostal_SUBURB_TOWN').value;
                                document.getElementById('viewStudentMaintain_AddreCurr_STATE').value=document.getElementById('viewStudentMaintain_AddrePostal_STATE').value;
                                document.getElementById('viewStudentMaintain_AddreCurr_POSTCODE').value=document.getElementById('viewStudentMaintain_AddrePostal_POSTCODE').value;
                                document.getElementById('viewStudentMaintain_AddreCurr_COUNTRY').value=document.getElementById('viewStudentMaintain_AddrePostal_COUNTRY').value;
                                document.getElementById('viewStudentMaintain_AddreCurr_PHONE_A').value=document.getElementById('viewStudentMaintain_AddrePostal_PHONE_A').value;
                                document.getElementById('viewStudentMaintain_AddreCurr_PHONE_B').value=document.getElementById('viewStudentMaintain_AddrePostal_PHONE_B').value;
                                document.getElementById('viewStudentMaintain_AddreCurr_FAX').value=document.getElementById('viewStudentMaintain_AddrePostal_FAX').value;
                                document.getElementById('viewStudentMaintain_AddreCurr_EMAIL_ADDRESS').value=document.getElementById('viewStudentMaintain_AddrePostal_EMAIL_ADDRESS').value;
                                document.getElementById('viewStudentMaintain_AddreCurr_EMAIL_ADDRESS2').value=document.getElementById('viewStudentMaintain_AddrePostal_EMAIL_ADDRESS2').value;
        } else {
                // clear out the address ID details
                                this.checked=false;
                document.getElementById('viewStudentMaintain_AddreCurr_ADDRESS_ID').value='';
                                //1-Dec-2008|EA| visible fields
                //                document.getElementById('viewStudentMaintain_AddreCurr_ADDRESSEE').value='';
                //                document.getElementById('viewStudentMaintain_AddreCurr_AGENT').value='';
                //                document.getElementById('viewStudentMaintain_AddreCurr_ADDR1').value='';
                //                document.getElementById('viewStudentMaintain_AddreCurr_ADDR2').value='';
                //                document.getElementById('viewStudentMaintain_AddreCurr_SUBURB_TOWN').value='';
                //                document.getElementById('viewStudentMaintain_AddreCurr_STATE').value='';
                //                document.getElementById('viewStudentMaintain_AddreCurr_POSTCODE').value='';
                //                document.getElementById('viewStudentMaintain_AddreCurr_COUNTRY').value='';
                //                document.getElementById('viewStudentMaintain_AddreCurr_PHONE_A').value='';
                //                document.getElementById('viewStudentMaintain_AddreCurr_PHONE_B').value='';
                //                document.getElementById('viewStudentMaintain_AddreCurr_FAX').value='';
                //                document.getElementById('viewStudentMaintain_AddreCurr_EMAIL_ADDRESS').value='';
                //                document.getElementById('viewStudentMaintain_AddreCurr_EMAIL_ADDRESS2').value='';
        }
                result = true;
    // -------------------------
//End Custom Code

//Close page_viewStudentMaintain_Addre_cbox_same_as_postal_OnClick @113-BC33A33A
    return result;
}
//End Close page_viewStudentMaintain_Addre_cbox_same_as_postal_OnClick

//page_viewStudentMaintain_Addre_OnLoad @5-98E477E0
function page_viewStudentMaintain_Addre_OnLoad(form)
{
    var result;
//End page_viewStudentMaintain_Addre_OnLoad

//Custom Code @134-2A29BDB7
    // -------------------------
    // ERA: when loading, if the checkbox for 'Same as School' is ticked then disable all the postal fields
                var checkbox = document.getElementById('viewStudentMaintain_Addrecbox_same_as_school');
        togglePostalForSchool(checkbox);
        result=true;
    // -------------------------
//End Custom Code

//Close page_viewStudentMaintain_Addre_OnLoad @5-BC33A33A
    return result;
}
//End Close page_viewStudentMaintain_Addre_OnLoad

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//Custom Code @130-2A29BDB7
    // -------------------------
    // ERA: check pagelevel value tmpattendschoolid <>"" and popup alert depending on value
        if (tmpattendschool.length>0){
                alert('If the Attending School has CHANGED then the Postal Address for this student needs to be reviewed:\n\n- if moving TO the DECV then enter new Postal Address\n- if moving to another school, check the Postal Address is correct');
        }
    // -------------------------
//End Custom Code

//Close page_OnLoad @1-BC33A33A
    return result;
}
//End Close page_OnLoad

//page_viewStudentMaintain_Addre_Button_Cancel1_OnClick @63-A215F9E4
function page_viewStudentMaintain_Addre_Button_Cancel1_OnClick()
{
    disableValidation = true;
}
//End page_viewStudentMaintain_Addre_Button_Cancel1_OnClick

//page_viewStudentMaintain_Addre_Button_Cancel_OnClick @7-FEE9D04A
function page_viewStudentMaintain_Addre_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_viewStudentMaintain_Addre_Button_Cancel_OnClick

//PTAutoFill1 Loading @136-C78B4C11
function viewStudentMaintain_AddrePostAdd_SCHOOL_ADDRESS_ID_ifknownPTAutoFill1_start(sender, addressid) {
    new Ajax.Request("services/Student_Address_maintain_viewStudentMaintain_Addre_PostAdd_SCHOOL_ADDRESS_ID_ifknown_PTAutoFill1.aspx?keyword=" + addressid, {
        method: "get",
        requestHeaders: ['If-Modified-Since', new Date(0)],
        onSuccess: function(transport) {
            var valuesRow = eval(transport.responseText)[0];
            getSameLevelCtl("viewStudentMaintain_AddrePostal_ADDRESSEE", sender).value = valuesRow["ADDRESSEE"];
            getSameLevelCtl("viewStudentMaintain_AddrePostal_AGENT", sender).value = valuesRow["AGENT"];
            getSameLevelCtl("viewStudentMaintain_AddrePostal_ADDR1", sender).value = valuesRow["ADDR1"];
            getSameLevelCtl("viewStudentMaintain_AddrePostal_ADDR2", sender).value = valuesRow["ADDR2"];
            getSameLevelCtl("viewStudentMaintain_AddrePostal_SUBURB_TOWN", sender).value = valuesRow["SUBURB_TOWN"];
            getSameLevelCtl("viewStudentMaintain_AddrePostal_STATE", sender).value = valuesRow["STATE"];
            getSameLevelCtl("viewStudentMaintain_AddrePostal_POSTCODE", sender).value = valuesRow["POSTCODE"];
            getSameLevelCtl("viewStudentMaintain_AddrePostal_COUNTRY", sender).value = valuesRow["COUNTRY"];
            getSameLevelCtl("viewStudentMaintain_AddrePostal_PHONE_A", sender).value = valuesRow["PHONE_A"];
            getSameLevelCtl("viewStudentMaintain_AddrePostal_PHONE_B", sender).value = valuesRow["PHONE_B"];
            getSameLevelCtl("viewStudentMaintain_AddrePostal_FAX", sender).value = valuesRow["FAX"];
            getSameLevelCtl("viewStudentMaintain_AddrePostal_EMAIL_ADDRESS", sender).value = valuesRow["EMAIL_ADDRESS"];
            getSameLevelCtl("viewStudentMaintain_AddrePostal_EMAIL_ADDRESS2", sender).value = valuesRow["EMAIL_ADDRESS2"];
        }, 
        onFailure: function(transport) {
            alert(transport.responseText);
        }
    });
}
//End PTAutoFill1 Loading

//HideShow_ajaxBusy Loading @163-A4324C82
function viewStudentMaintain_AddreHideShow_ajaxBusy_show(sender) {
    var control = getSameLevelCtl("Student_Address_maintainajaxBusy", sender);
    if (control != null) {
            control.style.display = "";
    } else {
            addProgress();
    }
}
function viewStudentMaintain_AddreHideShow_ajaxBusy_hide(sender) {
    var control = getSameLevelCtl("Student_Address_maintainajaxBusy", sender);
    if (control != null) {
            control.style.display = "none";
    } else {
            removeProgress();
    }
}
//End HideShow_ajaxBusy Loading

//bind_events @1-D5B12825
function bind_events() {
    //addEventHandler("viewStudentMaintain_Addrecbox_same_as_school", "click", viewStudentMaintain_AddrePostAdd_SCHOOL_ADDRESS_ID_ifknownPTAutoFill1_start);    // put it in the click handler directly so it only works when needed
    if(document.getElementById("viewStudentMaintain_AddreHolder"))
    addEventHandler("viewStudentMaintain_Addre","load",page_viewStudentMaintain_Addre_OnLoad);
    addEventHandler("viewStudentMaintain_Addrecbox_same_as_postal","click",page_viewStudentMaintain_Addre_cbox_same_as_postal_OnClick);
    addEventHandler("viewStudentMaintain_Addrecbox_same_as_school","click",page_viewStudentMaintain_Addre_cbox_same_as_school_OnClick);
    addEventHandler("viewStudentMaintain_AddreButton_Cancel1","click",page_viewStudentMaintain_Addre_Button_Cancel1_OnClick);
    addEventHandler("viewStudentMaintain_AddreButton_Cancel","click",page_viewStudentMaintain_Addre_Button_Cancel_OnClick);
    page_OnLoad();
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

//End CCS script
</script>

</head>
<body>
<form runat="server">


<p align="center"><DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/></p>
<p>

  <span id="viewStudentMaintain_AddreHolder" runat="server">
    


  <p align="center"><asp:Literal id="viewStudentMaintain_AddrelblMessage" runat="server"/></p>
 
  <table cellspacing="0" cellpadding="0" width="70%" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Add/Edit Student Address </th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
          </tr>
 
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="viewStudentMaintain_AddreError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="4"><asp:Label ID="viewStudentMaintain_AddreErrorLabel" runat="server"/></td> 
          </tr>
 
  </asp:PlaceHolder>
  
          <tr class="Bottom">
            <td align="right" colspan="4"><asp:Image id="viewStudentMaintain_AddreajaxBusy"  style="DISPLAY: none" AlternateText="updating" ImageUrl="images/ajax_loader.gif" runat="server"/>&nbsp;&nbsp; 
              <input id='viewStudentMaintain_AddreButton_Update1' class="Button" type="submit" value="Update" OnServerClick='viewStudentMaintain_Addre_Update' runat="server"/>
              <input id='viewStudentMaintain_AddreButton_Cancel1' class="Button" type="submit" value="Cancel" OnServerClick='viewStudentMaintain_Addre_Cancel' runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>STUDENT ID</th>
 
            <td><asp:Literal id="viewStudentMaintain_AddreSTUDENT_ID" runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<asp:TextBox id="viewStudentMaintain_Addreflag_same_as_school"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<asp:TextBox id="viewStudentMaintain_Addreflag_same_as_school_old"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th><strong>Postal Address</strong>:</th>
 
            <td>Check box if same as Attending School: <asp:CheckBox id="viewStudentMaintain_Addrecbox_same_as_school" runat="server"/>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;&nbsp;<asp:TextBox id="viewStudentMaintain_AddrePostAdd_ADDRESS_ID" maxlength="12" Columns="12"	runat="server"/>Postal</td> 
          </tr>
 
          <tr class="Controls">
            <th>ADDRESSEE</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddrePostal_ADDRESSEE" maxlength="60" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;&nbsp;<asp:TextBox id="viewStudentMaintain_AddrePostAdd_ADDRESS_ID_orig" maxlength="12" Columns="12"	runat="server"/>Postal Orig</td> 
          </tr>
 
          <tr class="Controls">
            <th>AGENT</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddrePostal_AGENT" maxlength="60" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp; 
              <asp:TextBox id="viewStudentMaintain_AddrePostAdd_SCHOOL_ADDRESS_ID_ifknown" maxlength="12" Columns="12"	runat="server"/>School Addr</td> 
          </tr>
 
          <tr class="Controls">
            <th>ADDRESS</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddrePostal_ADDR1" maxlength="50" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;&nbsp;<asp:TextBox id="viewStudentMaintain_AddrePOSTAL_ADDRESS_ID" maxlength="12" Columns="12"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddrePostal_ADDR2" maxlength="50" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>SUBURB / TOWN</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddrePostal_SUBURB_TOWN" maxlength="30" Columns="30"	runat="server"/></td> 
            <td>&nbsp;STATE</td> 
            <td><asp:TextBox id="viewStudentMaintain_AddrePostal_STATE" maxlength="20" Columns="20"	runat="server"/>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>POSTCODE</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddrePostal_POSTCODE" maxlength="10" Columns="10"	runat="server"/></td> 
            <td>&nbsp;COUNTRY</td> 
            <td><asp:TextBox id="viewStudentMaintain_AddrePostal_COUNTRY" maxlength="20" Columns="20"	runat="server"/>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>HOME PHONE</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddrePostal_PHONE_A" maxlength="15" Columns="15"	runat="server"/></td> 
            <td>&nbsp;PHONE2/MOBILE</td> 
            <td><asp:TextBox id="viewStudentMaintain_AddrePostal_PHONE_B" maxlength="15" Columns="15"	runat="server"/>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>FAX</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddrePostal_FAX" maxlength="15" Columns="15"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>EMAIL ADDRESS</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddrePostal_EMAIL_ADDRESS" maxlength="50" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>EMAIL ADDRESS2</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddrePostal_EMAIL_ADDRESS2" maxlength="50" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY / DATE</th>
 
            <td><asp:Literal id="viewStudentMaintain_AddrePostal_LAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="viewStudentMaintain_AddrePostal_LAST_ALTERED_DATE" runat="server"/></td> 
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
            <th><strong>Current Address:</strong></th>
 
            <td>Check box if same as above: <asp:CheckBox id="viewStudentMaintain_Addrecbox_same_as_postal" runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;
  <input id="viewStudentMaintain_AddreCurr_ADDRESS_ID" type="hidden"  runat="server"/>
  </td> 
          </tr>
 
          <tr class="Controls">
            <th>ADDRESSEE</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreCurr_ADDRESSEE" maxlength="60" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;
  <input id="viewStudentMaintain_AddreCurr_ADDRESS_ID_orig" type="hidden"  runat="server"/>
  </td> 
          </tr>
 
          <tr class="Controls">
            <th>AGENT</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreCurr_AGENT" maxlength="60" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>ADDRESS</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreCurr_ADDR1" maxlength="50" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreCurr_ADDR2" maxlength="50" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>SUBURB / TOWN</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreCurr_SUBURB_TOWN" maxlength="30" Columns="30"	runat="server"/></td> 
            <td>&nbsp;STATE&nbsp;</td> 
            <td><asp:TextBox id="viewStudentMaintain_AddreCurr_STATE" maxlength="20" Columns="20"	runat="server"/>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>POSTCODE</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreCurr_POSTCODE" maxlength="10" Columns="10"	runat="server"/></td> 
            <td>&nbsp;COUNTRY</td> 
            <td><asp:TextBox id="viewStudentMaintain_AddreCurr_COUNTRY" maxlength="20" Columns="20"	runat="server"/>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>HOME PHONE</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreCurr_PHONE_A" maxlength="15" Columns="15"	runat="server"/></td> 
            <td>&nbsp;PHONE2/MOBILE</td> 
            <td><asp:TextBox id="viewStudentMaintain_AddreCurr_PHONE_B" maxlength="15" Columns="15"	runat="server"/>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>FAX</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreCurr_FAX" maxlength="15" Columns="15"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>EMAIL ADDRESS</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreCurr_EMAIL_ADDRESS" maxlength="50" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>EMAIL ADDRESS2</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreCurr_EMAIL_ADDRESS2" maxlength="50" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY / DATE</th>
 
            <td><asp:Literal id="viewStudentMaintain_AddreCurr_LAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="viewStudentMaintain_AddreCurr_LAST_ALTERED_DATE" runat="server"/></td> 
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
            <th><strong>Original Address:</strong></th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;
  <input id="viewStudentMaintain_AddreOrig_ADDRESS_ID" type="hidden"  runat="server"/>
  </td> 
          </tr>
 
          <tr class="Controls">
            <th>ADDRESSEE</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreOrig_ADDRESSEE" maxlength="60" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;
  <input id="viewStudentMaintain_AddreOrig_ADDRESS_ID_orig" type="hidden"  runat="server"/>
  </td> 
          </tr>
 
          <tr class="Controls">
            <th>AGENT</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreOrig_AGENT" maxlength="60" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>ADDRESS</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreOrig_ADDR1" maxlength="50" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreOrig_ADDR2" maxlength="50" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>SUBURB / TOWN</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreOrig_SUBURB_TOWN" maxlength="30" Columns="30"	runat="server"/></td> 
            <td>&nbsp;STATE</td> 
            <td><asp:TextBox id="viewStudentMaintain_AddreOrig_STATE" maxlength="20" Columns="20"	runat="server"/>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>POSTCODE</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreOrig_POSTCODE" maxlength="10" Columns="10"	runat="server"/></td> 
            <td>&nbsp;COUNTRY</td> 
            <td><asp:TextBox id="viewStudentMaintain_AddreOrig_COUNTRY" maxlength="20" Columns="20"	runat="server"/>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>PHONE1</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreOrig_PHONE_A" maxlength="15" Columns="15"	runat="server"/></td> 
            <td>&nbsp;PHONE2/MOBILE</td> 
            <td><asp:TextBox id="viewStudentMaintain_AddreOrig_PHONE_B" maxlength="15" Columns="15"	runat="server"/>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>FAX</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreOrig_FAX" maxlength="15" Columns="15"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>EMAIL ADDRESS</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreOrig_EMAIL_ADDRESS" maxlength="50" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>EMAIL ADDRESS2</th>
 
            <td><asp:TextBox id="viewStudentMaintain_AddreOrig_EMAIL_ADDRESS2" maxlength="50" Columns="50"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY / DATE</th>
 
            <td><asp:Literal id="viewStudentMaintain_AddreOrig_LAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="viewStudentMaintain_AddreOrig_LAST_ALTERED_DATE" runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>THIS UPDATE BY&nbsp;</th>
 
            <td>&nbsp;<asp:Literal id="viewStudentMaintain_Addrethis_LAST_ALTERED_BY" runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="4">
              <input id='viewStudentMaintain_AddreButton_Update' class="Button" type="submit" value="Update" OnServerClick='viewStudentMaintain_Addre_Update' runat="server"/>
              <input id='viewStudentMaintain_AddreButton_Cancel' class="Button" type="submit" value="Cancel" OnServerClick='viewStudentMaintain_Addre_Cancel' runat="server"/></td> 
          </tr>
 
        </table>
 </td> 
    </tr>
 
  </table>
 
  <input id="viewStudentMaintain_AddreATTENDING_SCHOOL_ID" type="hidden"  runat="server"/>
  
  <input id="viewStudentMaintain_AddreCURR_RESID_ADDRESS_ID" type="hidden"  runat="server"/>
  
  <input id="viewStudentMaintain_AddreORIG_RESID_ADDRESS_ID" type="hidden"  runat="server"/>
  



  </span>
  <br>
<br>
<br>
<p></p>

</form>
</body>
</html>

<!--End ASPX page-->

