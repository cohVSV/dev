<!--ASPX page @1-17BB52DC-->
    <%@ Page language="vb" CodeFile="StudentEnrolment_DetailsWizard.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.StudentEnrolment_DetailsWizard.StudentEnrolment_DetailsWizardPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.StudentEnrolment_DetailsWizard" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
	<html>
<head>
<meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Enrolment - Details Wizard</title>

<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR">
<script language="JavaScript" src="Functions.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
 /*'******************************
''******************************
        'Date Modified : 21 July 2009
        'Modified by : Vikas
        'Ref: Unfuddle Ticket No: 57
        'Task: School Address on New Enrolments
        '******************Code Starts Here******************
*/
function getSchoolAddress()
{

var tmpformname='Wizard_AddStudent_';
var cbox=document.getElementById(tmpformname + 'chkbox_same_as_attending');
var tmpSchoolAddreID=document.getElementById('txtSchoolAddressId_hidden').value;

if (cbox.checked==true)
    {
      if (tmpSchoolAddreID!="")
       {
           Address_PTAutoFill_start(this.form, tmpSchoolAddreID, tmpformname);
           //tmpSchoolAddreID.value = tmpSchoolAddreID.value.replace(/&#39;/g, "'");
             //EnableDisableContols(cbox,tmpformname)
       }
    }
else
   {
   ClearPostalAddressControls(cbox,tmpformname);
   //EnableDisableContols(cbox,tmpformname)
   } 
}

function ClearPostalAddressControls(cbox,formname)
{
if (!cbox.checked) {
                document.getElementById(formname+'txtaddressee_1').value = "";
                document.getElementById(formname+'txtagent_1').value = "";
                document.getElementById(formname+'txtaddr1_1').value = "";
                document.getElementById(formname+'txtaddr2_1').value = "";
                document.getElementById(formname+'txtsuburb_town_1').value = "";
                document.getElementById(formname+'txtstate_1').value = "";
                document.getElementById(formname+'txtpostcode_1').value = "";
                document.getElementById(formname+'txtcountry_1').value = "";
                document.getElementById(formname+'txtphonea_1').value = "";
                document.getElementById(formname+'txtphoneb_1').value = "";
                document.getElementById(formname+'txtfax_1').value = "";
                document.getElementById(formname+'txtemail_address_1').value = "";
                document.getElementById(formname+'txtemail_address_1b').value = "";
                }
                return true;
}

function EnableDisableContols(cbox,formname)
{
    if (!cbox.checked)
    {
        document.getElementById(formname+'txtaddressee_1').disabled=false;
        document.getElementById(formname+'txtagent_1').disabled=false;
        document.getElementById(formname+'txtaddr1_1').disabled=false;
        document.getElementById(formname+'txtaddr2_1').disabled=false;
        document.getElementById(formname+'txtsuburb_town_1').disabled=false;
        document.getElementById(formname+'txtstate_1').disabled=false;
        document.getElementById(formname+'txtpostcode_1').disabled=false;
        document.getElementById(formname+'txtcountry_1').disabled=false;
        document.getElementById(formname+'txtphonea_1').disabled=false;
        document.getElementById(formname+'txtphoneb_1').disabled=false;
        document.getElementById(formname+'txtfax_1').disabled=false;
        document.getElementById(formname+'txtemail_address_1').disabled=false;
        document.getElementById(formname+'txtemail_address_1b').disabled=false;
    }
    else if (cbox.checked)
    {
        document.getElementById(formname+'txtaddressee_1').disabled=true;
        document.getElementById(formname+'txtagent_1').disabled=true;
        document.getElementById(formname+'txtaddr1_1').disabled=true;
        document.getElementById(formname+'txtaddr2_1').disabled=true;
        document.getElementById(formname+'txtsuburb_town_1').disabled=true;
        document.getElementById(formname+'txtstate_1').disabled=true;
        document.getElementById(formname+'txtpostcode_1').disabled=true;
        document.getElementById(formname+'txtcountry_1').disabled=true;
        document.getElementById(formname+'txtphonea_1').disabled=true;
        document.getElementById(formname+'txtphoneb_1').disabled=true;
        document.getElementById(formname+'txtfax_1').disabled=true;
        document.getElementById(formname+'txtemail_address_1').disabled=true;
        document.getElementById(formname+'txtemail_address_1b').disabled=true;
    }
   
  }

function Address_PTAutoFill_start(sender, addressid, formname) {
        if (addressid!="") {

    new Ajax.Request("services/getAddressDetailsForAutoFill.aspx?keyword=" + addressid, {
        method: "get",
        requestHeaders: ['If-Modified-Since', new Date(0)],
        onSuccess: function(transport) {
            var valuesRow = eval(transport.responseText)[0];
             try{
                document.getElementById(formname+'txtaddressee_1').value=rtrim(valuesRow["ADDRESSEE"]);
                document.getElementById(formname + 'txtagent_1').value = rtrim(valuesRow["AGENT"]).replace(/&#39;/g, "'"); // LN: 4/12/2013 replace with character code for apostrophe.
                document.getElementById(formname+'txtaddr1_1').value = rtrim(valuesRow["ADDR1"]);
                document.getElementById(formname+'txtaddr2_1').value = rtrim(valuesRow["ADDR2"]);
                document.getElementById(formname+'txtsuburb_town_1').value = rtrim(valuesRow["SUBURB_TOWN"]);
                document.getElementById(formname+'txtstate_1').value =  rtrim(valuesRow["STATE"]);
                document.getElementById(formname+'txtpostcode_1').value = rtrim(valuesRow["POSTCODE"]);
                document.getElementById(formname+'txtcountry_1').value = rtrim(valuesRow["COUNTRY"]);
                document.getElementById(formname+'txtphonea_1').value = rtrim(valuesRow["PHONE_A"]);
                document.getElementById(formname+'txtphoneb_1').value = rtrim(valuesRow["PHONE_B"]);
                document.getElementById(formname+'txtfax_1').value = rtrim(valuesRow["FAX"]);
                document.getElementById(formname+'txtemail_address_1').value = rtrim(valuesRow["EMAIL_ADDRESS"]);
                document.getElementById(formname+'txtemail_address_1b').value = rtrim(valuesRow["EMAIL_ADDRESS2"]);
                }
                catch (err)
                {
                alert(err.description);
                //alert('Error occured! Please fill manually')
                }
        }, 
        onFailure: function(transport) {
            alert(transport.responseText);
            } });}
}

function rtrim(stringToTrim) {
            return stringToTrim.replace(/\s+$/,"");
}

/*'******************************
'Date Modified : 21 July 2009
'Modified by : Vikas
'Ref: Unfuddle Ticket No: 57
'Task: School Address on New Enrolments
Code Ends Here
*/

</script>

<script language="JavaScript" type="text/javascript">
/*
'******************************
        'Date Modified : 21 July 2009
        'Modified by : Vikas
        'Ref: Unfuddle Ticket No: 57
        'Task: VSN implementation
        '******************Code Starts Here******************
*/

   function ValidateVSN()
    {
    var tmpformname='Wizard_AddStudent_';
    var VSN=document.getElementById(tmpformname + 'txtVSN');
    var VSREnrolled= document.getElementById(tmpformname + 'chkbox_EnrolledBefore');
    if (VSN.value!='')
    {
        if (VSN.value.length!=9)
            {
                alert('VSN should be 9 digits');
                VSN.focus();
                return false;
            }
        else
            {
            var strVSN=VSN.value;
            
            //Use weight factor- 1, 4, 3, 7, 5, 8, 6, 9, 10
            var Weightfactor=new Array("1", "4", "3", "7","5", "8", "6", "9", "10");
            var bitsVSR=new Array(9);
            var i=0;
            var totalVSN=0;
            
            for (i = 0; i < 9 ; i++)
                {
                    bitsVSR[i]=strVSN.substring(i,i+1);
                }
                       
            for (i = 0; i < 9 ; i++)
                {
                    totalVSN = totalVSN + (bitsVSR[i] * Weightfactor[i]);
                }
            
            var outVSN=totalVSN%11;
            
            if (outVSN!=0)
                {
                    alert('Invalid VSN Number');
                    VSN.value='';
                    VSN.focus();
                    return false;
                }
            else
                {      
                    VSREnrolled.checked=true;       
                    return true;
                }
            } 
        }  
       else
       {
            return true;
       } 
    }
    /*
'******************************
        'Date Modified : 21 July 2009
        'Modified by : Vikas
        'Ref: Unfuddle Ticket No: 57
        'Task: VSN implementation
        '******************Code Ends Here******************
*/
</script>

<script language="JavaScript" type="text/javascript">
function OpenPopUpList_School(FieldName)
{
        //FieldName = "txtAttendingSchoolID";FieldName = "txtHomeSchoolID";
        if (!FieldName==''){
            var win=window.open("popup_SchoolList.aspx?returncontrol="+FieldName, "SchoolList", "left=40,top=10,width=380,height=480,status=no,toolbar=no,menubar=no,location=no,scrollbars=yes");
            win.focus();
        }
}
function OpenPopUpList_Subjects()
{
        var win=window.open("StudentEnrolment_AddSubject.aspx?STUDENT_ID="+FieldName, "AddSubject", "left=40,top=10,width=380,height=480,status=no,toolbar=no,menubar=no,location=no,scrollbars=yes");
        win.focus();
}
function copyPostalToCurrent(thisbox) 
{
    // ERA: if checked then copy POSTAL ADDRESS ID to CURR ADDRESS ID
        //1-Dec-2008|EA| and also copy the address values so the field validation doesn't fire off
        if (thisbox.checked) {
            //document.getElementById('Wizard_AddStudent_txtaddressee_1').value=document.getElementById('Wizard_AddStudent_txtaddressee_1').value;
            //1-Dec-2008|EA| visible fields
            document.getElementById('Wizard_AddStudent_txtaddressee_2').value=document.getElementById('Wizard_AddStudent_txtaddressee_1').value;
            document.getElementById('Wizard_AddStudent_txtagent_2').value=document.getElementById('Wizard_AddStudent_txtagent_1').value;
            document.getElementById('Wizard_AddStudent_txtaddr1_2').value=document.getElementById('Wizard_AddStudent_txtaddr1_1').value;
            document.getElementById('Wizard_AddStudent_txtaddr2_2').value=document.getElementById('Wizard_AddStudent_txtaddr2_1').value;
            document.getElementById('Wizard_AddStudent_txtsuburb_town_2').value=document.getElementById('Wizard_AddStudent_txtsuburb_town_1').value;
            document.getElementById('Wizard_AddStudent_txtstate_2').value=document.getElementById('Wizard_AddStudent_txtstate_1').value;
            document.getElementById('Wizard_AddStudent_txtpostcode_2').value=document.getElementById('Wizard_AddStudent_txtpostcode_1').value;
            document.getElementById('Wizard_AddStudent_txtcountry_2').value=document.getElementById('Wizard_AddStudent_txtcountry_1').value;
            document.getElementById('Wizard_AddStudent_txtphonea_2').value=document.getElementById('Wizard_AddStudent_txtphonea_1').value;
            document.getElementById('Wizard_AddStudent_txtphoneb_2').value=document.getElementById('Wizard_AddStudent_txtphoneb_1').value;
            document.getElementById('Wizard_AddStudent_txtfax_2').value=document.getElementById('Wizard_AddStudent_txtfax_1').value;
            //document.getElementById('Wizard_AddStudent_txtaddressee_1').value=document.getElementById('viewStudentMaintain_AddrePostal_EMAIL_ADDRESS').value;
            //document.getElementById('Wizard_AddStudent_txtemail_address_2').value=document.getElementById('Wizard_AddStudent_txtemail_address_1').value;
            document.getElementById('Wizard_AddStudent_txtemail_address_2b').value=document.getElementById('Wizard_AddStudent_txtemail_address_1b').value;
        } else {
            // clear out the address ID details
    		this.checked=false;
            //     document.getElementById('viewStudentMaintain_AddreCurr_ADDRESS_ID').value='';
        }
		return true;
    // -------------------------
}

function clearCurrent() {
    // ERA:4-Dec-2008|EA| when clicked it clears the Current Address
    if (confirm('You want to clear the Current Address details on screen?')) {
        document.getElementById('Wizard_AddStudent_txtaddressee_2').value='';
        document.getElementById('Wizard_AddStudent_txtagent_2').value='';
        document.getElementById('Wizard_AddStudent_txtaddr1_2').value='';
        document.getElementById('Wizard_AddStudent_txtaddr2_2').value='';
        document.getElementById('Wizard_AddStudent_txtsuburb_town_2').value='';
        document.getElementById('Wizard_AddStudent_txtstate_2').value='';
        document.getElementById('Wizard_AddStudent_txtpostcode_2').value='';
        document.getElementById('Wizard_AddStudent_txtcountry_2').value='';
        document.getElementById('Wizard_AddStudent_txtphonea_2').value='';
        document.getElementById('Wizard_AddStudent_txtphoneb_2').value='';
        document.getElementById('Wizard_AddStudent_txtfax_2').value='';
        //document.getElementById('Wizard_AddStudent_txtaddressee_1').value='';
        //document.getElementById('Wizard_AddStudent_txtemail_address_2').value='';
        document.getElementById('Wizard_AddStudent_txtemail_address_2b').value='';
        document.getElementById('Wizard_AddStudent_chkbox_same_as_postal').checked=false;
    }
	return true;
}

</script>

<script language="JavaScript" type="text/javascript">
/*
    Date Modified : 30 Oct 2009
    Modified by : Eric Affleck
    Ref: Unfuddle Ticket No: #182
    Task: Region Approval display
*/

function getStudentRegionDetails(thistextbox) {
    if (!thistextbox.value=='') {
        // stick a 'not this student?' link to clear the results if wrong, and append the details after it
        $('divRegionDetails').innerHTML ='<a href="#" onclick="javascript:clearRegionID();">not this student?</a>';
        // get the id entered and pass it to the service
        var url='services/getRegionStudentDetails.aspx?racid='+thistextbox.value;
        new Ajax.Updater('divRegionDetails', url, { method: 'get', insertion: 'bottom' });
        $('divRegionDetails').className='highlight';
    } else {
        $('divRegionDetails').innerHTML ='';
        $('divRegionDetails').className='';
    }
    return true;
}

function clearRegionID(){
    $('Wizard_AddStudent_txtRegionCode').value='';
    $('divRegionDetails').innerHTML ='';
    $('divRegionDetails').className='';
    $('Wizard_AddStudent_listRegion').focus();
    return true;
}


</script>
<script type="text/javascript">
    /*20-Oct-2011|EA| added length checker for comments unfuddle #405 */
    function limitMaxLength(formitem, maxlength, displaydivname) {
        if (isNaN(maxlength)) {
            return false;
        } else {
            var outputdiv = document.getElementById(displaydivname)
            outputdiv.innerHTML = (maxlength - formitem.value.length) + ' characters allowed';
            if (formitem.value.length + 1 > maxlength) {
                formitem.value = formitem.value.substring(0, maxlength);
            }
        }
    }

    function StudentMessage()
    {
     //   alert('hi');
     try{ 
       document.getElementById("div_StudentExist").style.display="none";
       }
      catch(e)
      {
        document.getElementById("div_StudentExist").style.display="none";
      }
   
   }


   function validateGender(source, arguments)
   {
      var birthSexElement = document.querySelector("#<%= radioBirthSex.ClientID %> input:checked");
      var birthSexValue = (birthSexElement !== null) ? birthSexElement.value : "";
      var preferredGenderElement = document.querySelector("#<%= radioPreferredGender.ClientID %> input:checked");
      var preferredGenderValue = (preferredGenderElement !== null) ? preferredGenderElement.value : "";
      var selfDescribedGenderValue = document.getElementById("<%= txtGenderSelfDescribed.ClientID %>").value.trim();

      /* Valid if:
       * - A preferred gender has been provided, and: it's either M-F, or it's X and both birth sex and self-described gender have also been provided
       * - Or, a (M-F) birth sex has been provided, and both preferred gender and self-described gender have been left blank
       * 
       * Amongst other things, the logic guards against the case where a self-described gender is specified without a preferred gender.
       */
      arguments.IsValid = ((preferredGenderValue !== "") && ((preferredGenderValue !== "X") || ((birthSexValue !== "") && (selfDescribedGenderValue !== "")))) ||
         ((birthSexValue !== "") && (preferredGenderValue === "") && (selfDescribedGenderValue === ""));
   }


   function genderSelfDescribedChanged()
   {
      /* Force the selection of preferred gender "Other" when a self-described gender is specified.
       * Added as a data entry convenience since the source form (Direct enrolment application) only has a free text area for preferred gender.
       */
      var selfDescribedGenderValue = document.getElementById("<%= txtGenderSelfDescribed.ClientID %>").value.trim();
      var preferredGenderOtherElement = document.querySelector("#<%= radioPreferredGender.ClientID %> input[value='X']");
      if (selfDescribedGenderValue.length > 0)
         preferredGenderOtherElement.checked = true;
   }
</script>

    <link href="Styles/Blueprint/Style.css" rel="stylesheet" type="text/css" />
	<style>
		/*
        Date Modified : 30 Oct 2009
        Modified by : Eric Affleck
        Task: Updates to highlight mandatory fields on load; also to lookup and display
            Region Approval details. unfuddle #173 and #182
        */
		.required {
			color: #000;
			font-weight: bold;
		}
		.required:first-letter {
		    color: red;
		    font-weight:bold;
		}
	    .highlight {
            background-color:#11ff00;
	        border: 2px solid green;
	        color: #000;
	        height: auto; min-height:200px;
            width: 420px;
        }
	</style>
</head>
<body> 
<form runat="server">

<p align="center"><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p align="center">
    <asp:Wizard ID="Wizard_AddStudent" runat="server" ActiveStepIndex="0" Width="60%" Font-Bold="False"  FinishCompleteButtonText="Commit Enrolment" CellPadding="2">
        <WizardSteps>
            <asp:WizardStep runat="server" Title="Student Details">
                <strong>Student Details<br />
                </strong>
                <br />
                <table width="100%" cellpadding="2">
                    <tr>
                        <td style="width: 165px;text-align: right; height: 26px">
                        <strong>Email:</strong></td>
                        <td style="HEIGHT: 26px;" >
                            <asp:TextBox ID="txtStudentEmail" runat="server" Columns="20"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtStudentEmail" runat="server" ErrorMessage="Student Contact E-mail is required"
                                Font-Bold="True" ControlToValidate="txtStudentEmail">Required</asp:RequiredFieldValidator>
                            
                           <%-- 2 Dec 2020|RW| Removed previous validation expression, which was too strict in flagging some legit emails as invalid
                                               Replaced it with the very same one used on the student details maintenance page
                                               The previous expression was "^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" --%>

                            <%--<asp:TextBox ID="StudentEmailNew" runat="server" Columns="40" OnTextChanged="StudentEmailNew_TextChanged"></asp:TextBox>--%>
                        </td>
                        <td style="text-align: right; width: 199px; height: 26px;">
                            <strong> Enrolment Date:</strong></td>
                        <td style="HEIGHT: 26px">
                            <asp:TextBox ID="txtEnrolmentDate" runat="server" Columns="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RequiredFieldValidatortxtStudentEmail2" runat="server" ErrorMessage="Student Contact E-mail is not a valid email"
                                Font-Bold="True" ControlToValidate="txtStudentEmail" ValidationExpression="^[\w\.\+-]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]+$" />
                            <asp:CustomValidator Font-Bold="True" ID="EmailValidator" ControlToValidate="txtStudentEmail" ErrorMessage="Email address is already in DB" OnServerValidate="Unnamed_ServerValidate" runat="server"><asp:Label runat="server" id="EmailValidationMessage">EMAIL ERROR LABEL</asp:Label></asp:CustomValidator>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <!-- '******************************
                            'Date Modified : 21 July 2009
                            'Modified by : Vikas
                            'Task: VSN implementation
                            '******************Code Starts Here******************-->
                    <tr>
                        <td style="width: 165px;text-align: right; height: 26px">
                        <strong> VSR Enrolled:</strong></td>
                        <td style="HEIGHT: 26px; width: 180px;">
                        <asp:CheckBox ID="chkbox_EnrolledBefore" runat="server" TabIndex="1" /> 
                        </td>
                        <td style="text-align: right; width: 199px; height: 26px;">
                            <strong>VSN:</strong></td>
                        <td style="HEIGHT: 26px">
                            <asp:TextBox ID="txtVSN" onFocusOut="javascript:return ValidateVSN()" MaxLength="9" TabIndex="2" runat="server" Columns="10"></asp:TextBox>
                        </td>
                    </tr>
                    <!-- '******************************
                            'Date Modified : 21 July 2009
                            'Modified by : Vikas
                            'Task: VSN implementation
                            '******************Code Ends Here******************-->
                    <tr>
                        <td style="height: 18px; text-align: right; width: 165px;">
                            <div class="required">* Surname:</div></td>
                        <td colspan="3">
                            <asp:TextBox ID="txtSurname" runat="server" TabIndex="3" MaxLength="30"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="requiredSurname" runat="server" ControlToValidate="txtSurname"
                                ErrorMessage="Surname is Required" Font-Bold="True">Required</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 165px;">
                            <div class="required">* First Name:</div></td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtFirstName" runat="server" TabIndex="4" MaxLength="30"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName"
                                ErrorMessage="First Name is Required" Font-Bold="True">Required</asp:RequiredFieldValidator>
                        </td>
                        <td style="text-align: right; width: 199px;">
                            <span style="font-weight: bold; white-space: nowrap;">Preferred Name (if different):</span>
                        </td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtPreferredName" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" style="height: 18px; text-align: right; width: 165px;">
                            <strong>Middle&nbsp;Name:</strong></td>
                        <td>
                            <asp:TextBox ID="txtMiddleName" runat="server" TabIndex="5" MaxLength="30"></asp:TextBox>
                        </td>
                        <td style="height: 18px; text-align: right;">
                            <div class="required">* Date of Birth:</div>
                                <em>(dd/mm/yyyy)</em></td>
                        <td>
                            <asp:TextBox ID="txtDateOfBirth" runat="server" Columns="10" TabIndex="6"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDateOfBirth"
                                ErrorMessage="Date of Birth is Required" Font-Bold="True">Required</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right; width: 165px;">
                            <strong>Birth Sex:</strong>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="radioBirthSex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" TabIndex="7">
                                <asp:ListItem Value="F">Female</asp:ListItem>
                                <asp:ListItem Value="M">Male</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td style="text-align: right; width: 199px;">
                            <span style="font-weight: bold; white-space: nowrap;">Preferred Gender (if different):</span>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="radioPreferredGender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                <asp:ListItem Value="F">Female</asp:ListItem>
                                <asp:ListItem Value="M">Male</asp:ListItem>
                                <asp:ListItem Value="X">Other</asp:ListItem>
                            </asp:RadioButtonList>
                           <asp:TextBox runat="server" ID="txtGenderSelfDescribed" MaxLength="30" placeholder="Specify if other" style="margin-left: 5px;" onchange="genderSelfDescribedChanged();"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                           <asp:CustomValidator runat="server" ID="cvGender"
                               ValidateEmptyText="True" ClientValidationFunction="validateGender" ErrorMessage="Either Birth Sex or Preferred Gender must be provided. If Preferred Gender is Other, the gender description and Birth Sex must also be provided." style="font-weight: bold;" ></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right; width: 165px;">
                            <div class="required">* Year Level:</div></td>
                        <td>
                            <asp:DropDownList ID="listYearLevel" runat="server" TabIndex="8">
                                <asp:ListItem Selected="True"></asp:ListItem>
                                <asp:ListItem Value="0">0 - Prep</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                <asp:ListItem Value="30">Home Schooled</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="listYearLevel"
                                ErrorMessage="Select a Year Level from the list" Font-Bold="True">Required</asp:RequiredFieldValidator>
                        </td>
                        <td style="height: 18px; text-align: right; width: 199px;">
                            <div class="required">* Enrolment Year:</div></td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtEnrolmentYear" runat="server" Columns="5"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEnrolmentYear"
                                ErrorMessage="Enrolment Year is Required" Font-Bold="True">Required</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; width: 165px; text-align: right;">
                            <strong>Region Approval Code</strong>&nbsp;</td>
                        <td style="height: 18px;" colspan="2">
                            <asp:TextBox ID="txtRegionCode" runat="server" Columns="6" TabIndex="9" onblur="javascript:getStudentRegionDetails(this);" ></asp:TextBox>
                            &nbsp; &nbsp;<em>(only the last number eg: METRO-2010-<strong>12345</strong>)</em></td>
                        <td style="height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 165px; height: 18px; text-align: right">
                            <div class="required">* Region</div>&nbsp;</td>
                        <td style="height: 18px;" colspan="1">
                            <asp:DropDownList ID="listRegion" runat="server" DataSourceID="SqlDataSource_Regions" DataTextField="region_name_display" DataValueField="REGION_ID" TabIndex="10" AppendDataBoundItems="True">
                                <asp:ListItem Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="listRegion"
                                ErrorMessage="Select a Region from the list" Font-Bold="True">Required</asp:RequiredFieldValidator>
                        </td>
                        <td></td>
                        <td></td>

<%--
LN: 25/11/2013
                        <td style="height: 18px;text-align: right;"><div class="required">*Eligible For Discount:</div></td>
                        <td style="height: 18px"><asp:RadioButtonList ID="RB_Discount" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" TabIndex="12">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="RB_Discount"
                                ErrorMessage="Select Eligible For Discount" Font-Bold="True">Required</asp:RequiredFieldValidator>
                        </td>--%>
                    </tr>
                    <tr>
                        <td style="width: 165px; height: 18px; text-align: right">
                        </td>
                        <td style="width: 180px; height: 18px">
                        </td>
                         <!-- '******************************
                            'Date Modified : 18 Mar 2010
                            'Modified by : Vikas
                            'Task: #37
                            '******************Code Starts Here******************-->
                        <td style="height: 18px;">
                           </td>
                        <td style="height: 18px">
                        
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; width: 165px; text-align: right;">
                            <div class="required">* Category /
                                <br />
                                Sub Category:</div></td>
                        <td style="height: 18px; width: 180px;">
                            <asp:DropDownList ID="listCategory" runat="server" DataSourceID="SqlDataSource_Category"
                                DataTextField="SUBCATEGORY_FULL_TITLE" DataValueField="CATSUBCAT_VALUE" TabIndex="11" AppendDataBoundItems="True">
                                <asp:ListItem Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="height: 18px; width: 199px;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="listCategory"
                                ErrorMessage="Select a Category from the list" Font-Bold="True">Required</asp:RequiredFieldValidator>
                        </td>
                        <td style="height: 18px">
                            <asp:SqlDataSource ID="SqlDataSource_Category" runat="server"></asp:SqlDataSource><asp:SqlDataSource ID="SqlDataSource_Regions" runat="server"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 165px; height: 18px">
                        </td>
                        <td style="height: 18px; width: 180px;">
                        </td>
                        <td style="width: 199px; height: 18px">
                        </td>
                        <td style="height: 18px">
                        </td>
                    </tr>
                </table>
                <br />
                <div id="divRegionDetails"></div>
            </asp:WizardStep>
            <asp:WizardStep runat="server" Title="School Selection">
                <strong>School Selection</strong><br />
                <br />
                <table width="100%" cellpadding="2">
                    <tr>
                        <td style="text-align: right; width: 114px;">
                            <strong>
                                <asp:LinkButton ID="linkbutton_popupAttending" runat="server" OnClientClick="OpenPopUpList_School('Wizard_AddStudent_txtAttendingSchoolID');">Attending School:</asp:LinkButton>
                            </strong></td>
                        <td width="5%">
                            <asp:TextBox ID="txtAttendingSchoolID" runat="server" Columns="10">16261.00</asp:TextBox>
                        </td>
                        <td style="width: 524px">
                            <asp:TextBox ID="txtAttendingSchoolName" runat="server" Columns="50">VIRTUAL SCHOOL VICTORIA</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 26px; width: 114px;">
                            <strong>
                                <asp:LinkButton ID="linkbutton_popupHome" runat="server" OnClientClick="OpenPopUpList_School('Wizard_AddStudent_txtHomeSchoolID');">Home School:</asp:LinkButton>
                            </strong></td>
                        <td style="height: 26px">
                            <asp:TextBox ID="txtHomeSchoolID" runat="server" Columns="10">16261.00</asp:TextBox>
                        </td>
                        <td style="height: 26px; width: 524px;">
                            <asp:TextBox ID="txtHomeSchoolName" runat="server" Columns="50">VIRTUAL SCHOOL VICTORIA</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; width: 114px;">
                        </td>
                        <td style="height: 18px">
                            <asp:Button ID="btnCheckSchools" runat="server" Text="Check Schools" />
                        </td>
                        <td style="width: 524px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; width: 114px;">
                        </td>
                        <td style="height: 18px">
                            </td>
                        <td style="width: 524px; height: 18px">
                            </td>
                    </tr>
                </table>
            </asp:WizardStep>
            <asp:WizardStep runat="server" Title="Address">
                <strong>Address<br />
                </strong>
                <br />
                <table width="100%">
					<!-- 2-Dec-2011|EA| add this row for consistency with 2012 enrolment forms. 
                    LN: 25/11/2013 re-added Student E-mail and Mobile fields from live. -->
					<tr>
                        <td style="text-align: right">
                            <div class="required">* Student Contact E-mail address:</div></td>
                        <td>
                            <p>EMAIL FIELD MOVED TO FIRST PAGE</p>
                            <%--<asp:TextBox ID="txtStudentEmail" runat="server" Columns="40"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtStudentEmail" runat="server" ErrorMessage="Student Contact E-mail is required"
                                Font-Bold="True" ControlToValidate="txtStudentEmail">Required</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RequiredFieldValidatortxtStudentEmail2" runat="server" ErrorMessage="Student Contact E-mail is not a valid email"
                                Font-Bold="True" ControlToValidate="txtStudentEmail" ValidationExpression="^[\w\.\+-]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]+$" />--%>
                           <%-- 2 Dec 2020|RW| Removed previous validation expression, which was too strict in flagging some legit emails as invalid
                                               Replaced it with the very same one used on the student details maintenance page
                                               The previous expression was "^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" --%>
                        </td>
                        <td>
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                        </td>
                    </tr>
					<tr>
                        <td style="text-align: right">
                            <strong>Student Mobile phone number:</strong></td>
                        <td style="width: 5px">
                            <asp:TextBox ID="txtStudentMobile" runat="server" Columns="15"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <strong><span style="font-size: 12pt; text-decoration: underline">Postal Address:</span></strong></td>
                        <td>
                            &nbsp;<asp:CheckBox ID="chkbox_same_as_attending" runat="server" Text="Check box if same as Attending School:" onClick="javascript:return getSchoolAddress();"
                                TextAlign="Left" />
                        </td>
                        <td>
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right">
                            <div class="required">* Addressee:</div></td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtaddressee_1" runat="server" Columns="40"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Addressee is Required"
                                Font-Bold="True" ControlToValidate="txtaddressee_1">Required</asp:RequiredFieldValidator>
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right">
                            <strong>Agent:</strong></td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtagent_1" runat="server" Columns="40"></asp:TextBox>
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <div class="required">* Address:</div></td>
                        <td>
                            <asp:TextBox ID="txtaddr1_1" runat="server" Columns="40"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Address is Required"
                                Font-Bold="True" ControlToValidate="txtaddr1_1">Required</asp:RequiredFieldValidator>
                        </td>
                        <td>
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px">
                        </td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtaddr2_1" runat="server" Columns="40"></asp:TextBox>
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <div class="required">* Suburb / Town:</div></td>
                        <td>
                            <asp:TextBox ID="txtsuburb_town_1" runat="server" Columns="30"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Suburb / Town is Required"
                                Font-Bold="True" ControlToValidate="txtsuburb_town_1">Required</asp:RequiredFieldValidator>
                        </td>
                        <td style="text-align: right">
                            <strong>State:</strong></td>
                        <td style="width: 5px">
                            <asp:TextBox ID="txtstate_1" runat="server" Columns="15"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right">
                            <div class="required">* Postcode:</div></td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtpostcode_1" runat="server" Columns="6"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Postcode is Required"
                                Font-Bold="True" ControlToValidate="txtpostcode_1">Required</asp:RequiredFieldValidator>
                        </td>
                        <td style="height: 18px; text-align: right">
                            <strong>Country:</strong></td>
                        <td style="width: 5px; height: 18px">
                            <asp:TextBox ID="txtcountry_1" runat="server" Columns="15">AUSTRALIA</asp:TextBox>
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right">
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <strong>Home Phone:</strong></td>
                        <td>
                            <asp:TextBox ID="txtphonea_1" runat="server" Columns="15"></asp:TextBox>
                        </td>
                        <td style="text-align: right">
                            <strong>Mobile/Phone 2:</strong></td>
                        <td style="width: 5px">
                            <asp:TextBox ID="txtphoneb_1" runat="server" Columns="15"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right">
                            <strong>Fax:</strong></td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtfax_1" runat="server" Columns="15"></asp:TextBox>
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 26px;">
                            <strong>Student/School Email Address:</strong></td>
                        <td style="height: 26px">
                            <asp:TextBox ID="txtemail_address_1" runat="server" Columns="50"></asp:TextBox>
                        </td>
                        <td style="height: 26px">
                        </td>
                        <td style="width: 5px; height: 26px;">
                        </td>
                        <td style="height: 26px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right">
                            <strong>Parent/Carer Email Address:</strong></td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtemail_address_1b" runat="server" Columns="50"></asp:TextBox>
                            &nbsp;</td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px">
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                </table>
                <br />
                <table width="100%">
                    <tr>
                        <td>
                            <strong><span style="font-size: 12pt; text-decoration: underline">Current Address:</span></strong></td>
                        <td>
                            &nbsp;<asp:CheckBox ID="chkbox_same_as_postal" runat="server" Text="Check box if same as above:" TextAlign="Left" onclick="javascript:copyPostalToCurrent(this);" />
                        </td>
                        <td style="font-weight: bold">
                            &nbsp;</td>
                        <td style="font-weight: bold"><a href="#" class="Button" id="linkClearCurrent" onclick="javascript:clearCurrent();">Clear this Address</a>
                            &nbsp;</td>
                        <td style="font-weight: bold; width: 3px">
                        </td>
                    </tr>
                    <tr style="font-weight: bold">
                        <td style="height: 18px; text-align: right">
                            Addressee:</td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtaddressee_2" runat="server" Columns="40"></asp:TextBox>
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right">
                            <strong>Agent:</strong></td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtagent_2" runat="server" Columns="40"></asp:TextBox>
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <strong>Address:</strong></td>
                        <td>
                            <asp:TextBox ID="txtaddr1_2" runat="server" Columns="40"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px">
                        </td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtaddr2_2" runat="server" Columns="40"></asp:TextBox>
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <strong>Suburb / Town:</strong></td>
                        <td>
                            <asp:TextBox ID="txtsuburb_town_2" runat="server" Columns="30"></asp:TextBox>
                        </td>
                        <td style="text-align: right">
                            <strong>State:</strong></td>
                        <td style="width: 5px">
                            <asp:TextBox ID="txtstate_2" runat="server" Columns="15"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right">
                            <strong>Postcode:</strong></td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtpostcode_2" runat="server" Columns="6"></asp:TextBox>
                        </td>
                        <td style="height: 18px; text-align: right">
                            <strong>Country:</strong></td>
                        <td style="width: 5px; height: 18px">
                            <asp:TextBox ID="txtcountry_2" runat="server" Columns="15">AUSTRALIA</asp:TextBox>
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <strong>Home Phone:</strong></td>
                        <td>
                            <asp:TextBox ID="txtphonea_2" runat="server" Columns="15"></asp:TextBox>
                        </td>
                        <td style="text-align: right">
                            <strong>Mobile/Phone 2:</strong></td>
                        <td style="width: 5px">
                            <asp:TextBox ID="txtphoneb_2" runat="server" Columns="15"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right">
                            <strong>Fax:</strong></td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtfax_2" runat="server" Columns="15"></asp:TextBox>
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
<%-- ' LN: 28/11/2013                   <tr>
                        <td style="text-align: right">
                            <strong>Student Email Address:</strong></td>
                        <td>
                            <asp:TextBox ID="txtemail_address_2" runat="server" Columns="50"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                        </td>
                    </tr>
--%>                    <tr>
                        <td style="text-align: right">
                            <strong>Parent/Carer Email Address:</strong></td>
                        <td>
                            <asp:TextBox ID="txtemail_address_2b" runat="server" Columns="50"></asp:TextBox>
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px">
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                </table>

                <br />
                <table width="100%">
                    <tr>
                        <td>
                            <strong><span style="font-size: 12pt; text-decoration: underline">Original Address:</span></strong></td>
                        <td>
                            &nbsp;(or S.A.C. address)</td>
                        <td style="font-weight: bold">
                        </td>
                        <td style="font-weight: bold; width: 5px">
                        </td>
                        <td style="font-weight: bold; width: 3px">
                        </td>
                    </tr>
                    <tr style="font-weight: bold">
                        <td style="height: 18px; text-align: right">
                            Addressee:</td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtaddressee_3" runat="server" Columns="40"></asp:TextBox>
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right">
                            <strong>Agent:</strong></td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtagent_3" runat="server" Columns="40"></asp:TextBox>
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <strong>Address:</strong></td>
                        <td>
                            <asp:TextBox ID="txtaddr1_3" runat="server" Columns="40"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px">
                        </td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtaddr2_3" runat="server" Columns="40"></asp:TextBox>
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <strong>Suburb / Town:</strong></td>
                        <td>
                            <asp:TextBox ID="txtsuburb_town_3" runat="server" Columns="30"></asp:TextBox>
                        </td>
                        <td style="text-align: right">
                            <strong>State:</strong></td>
                        <td style="width: 5px">
                            <asp:TextBox ID="txtstate_3" runat="server" Columns="15"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right">
                            <strong>Postcode:</strong></td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtpostcode_3" runat="server" Columns="6"></asp:TextBox>
                        </td>
                        <td style="height: 18px; text-align: right">
                            <strong>Country:</strong></td>
                        <td style="width: 5px; height: 18px">
                            <asp:TextBox ID="txtcountry_3" runat="server" Columns="15">AUSTRALIA</asp:TextBox>
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <strong>Home Phone:</strong></td>
                        <td>
                            <asp:TextBox ID="txtphonea_3" runat="server" Columns="15"></asp:TextBox>
                        </td>
                        <td style="text-align: right">
                            <strong>Mobile/Phone 2:</strong></td>
                        <td style="width: 5px">
                            <asp:TextBox ID="txtphoneb_3" runat="server" Columns="15"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right">
                            <strong>Fax:</strong></td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtfax_3" runat="server" Columns="15"></asp:TextBox>
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <strong>Email Address:</strong></td>
                        <td>
                            <asp:TextBox ID="txtemail_address_3" runat="server" Columns="50"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <strong>Email Address 2:</strong></td>
                        <td>
                            <asp:TextBox ID="txtemail_address_3b" runat="server" Columns="50"></asp:TextBox>
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px">
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                </table>

            </asp:WizardStep>
            <asp:WizardStep runat="server" Title="Comment">
                <strong>Add Enrolments Comments<br />
                </strong>
                <asp:TextBox ID="txtareacomments" runat="server" Columns="40" Rows="8" TextMode="MultiLine" onkeyup="limitMaxLength(this,250,'maxchar_comment');"></asp:TextBox>
                <div id="maxchar_comment"></div>
                <p><em>Region Enrolment Notes will be added to Student Comments automatically when Student Enrolment is finished.</em></p>
                <input type="button" value="Subject not available at school." title="Subject not available at school." onclick="javascript:document.getElementById('<%=txtareacomments.ClientID%>').value += 'Subject not available at school.';" />
            </asp:WizardStep>
            <asp:WizardStep runat="server" StepType="Finish" Title="Confirm Details">
                <strong>Confirmation - Student Details</strong><br />
                
                <table width="100%">
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td style="text-align: right;" nowrap="noWrap">
                            <strong>Enrolment Year:&nbsp;</strong></td>
                        <td>
                            &nbsp;<asp:Label ID="conf_lblEnrolmentYear" runat="server" Text="enrolmentyear"></asp:Label>
                        </td>
                    </tr>
                    <!-- '******************************
                            'Date Modified : 21 July 2009
                            'Modified by : Vikas
                            'Task: VSN implementation
                            '******************Code Starts Here******************-->
                    <tr>
                        <td style="text-align: right;" nowrap="nowrap"><strong>VSR Enrolled:</strong>
                        </td>
                        <td><asp:Label ID="conf_EnrolledBefore" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: right;" nowrap="noWrap">
                            <strong>VSN:&nbsp;</strong></td>
                        <td>
                            &nbsp;<asp:Label ID="conf_VSN" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <!-- '******************************
                            'Date Modified : 21 July 2009
                            'Modified by : Vikas
                            'Task: VSN implementation
                            '******************Code Ends Here******************-->
                    <tr>
                        <td style="text-align: right;" nowrap=nowrap><strong>Surname:</strong></td>
                        <td colspan="3">
                            <asp:Label ID="conf_lblSurname" runat="server" Text="surname"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;" nowrap="noWrap">
                           <span style="font-weight: bold;">First Name:</span>
                        </td>
                        <td>
                            <asp:Label ID="conf_lblFirstName" runat="server" Text="firstname"></asp:Label>
                        </td>
                        <td style="text-align: right; white-space: nowrap;">
                           <span style="font-weight: bold;">Preferred Name:</span>
                        </td>
                        <td>
                            <asp:Label ID="conf_lblPreferredName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;" nowrap="noWrap">
                            <strong>&nbsp;Middle Name:</strong></td>
                        <td>
                            <asp:Label ID="conf_lblMiddleName" runat="server" Text="middle"></asp:Label>
                        </td>
                        <td style="height: 18px; text-align: right;" nowrap="noWrap">
                            <strong>&nbsp;Date of Birth:</strong></td>
                        <td>
                            &nbsp;<asp:Label ID="conf_lblDOB" runat="server" Text="dateofbirth"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right;">
                            <strong>Gender:</strong></td>
                        <td>
                            <asp:Label ID="conf_lblSex" runat="server" Text="sex"></asp:Label>
                        </td>
                           <!-- '******************************
                            'Date Modified : 21 July 2009
                            'Modified by : Vikas
                            'Task: #37
                            '******************Code Starts Here******************-->
<%--
                        LN: 25/11/2013 This never made it live.

                        <td style="height: 18px; text-align: right;">
                             <strong>Eligible For Funding: </strong>
                        </td>
                        <td>
                             &nbsp;<asp:Label ID="conf_lblFunded" runat="server" Text="Funded" ></asp:Label>   
                        </td>
                        '
--%>                           <!-- '******************************
                            'Date Modified : 21 July 2009
                            'Modified by : Vikas
                            'Task: #37
                            '******************Code Starts Here******************-->
                            <td></td>
                            <td></td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <strong>Year Level:</strong></td>
                        <td>
                            <asp:Label ID="conf_lblyearlevel" runat="server" Text="yearlevel"></asp:Label>
                        </td>
                        <td nowrap="noWrap">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right;">
                            <strong>Category /<br />
                                Subcategory:</strong></td>
                        <td style="height: 18px" colspan="2">
                            <asp:Label ID="conf_lblCategory" runat="server" Text="category"></asp:Label>
                            /
                            <asp:Label ID="conf_lblSubCategory" runat="server" Text="subcategory"></asp:Label>
                        </td>
                        <td style="height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px">
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td nowrap="nowrap" style="height: 18px">
                        </td>
                        <td style="height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <strong>Attending School:</strong></td>
                        <td>
                            <asp:Label ID="conf_lblAttendingID" runat="server" Text="attendingID"></asp:Label>
                        </td>
                        <td nowrap="nowrap" colspan="2">
                            <asp:Label ID="conf_lblAttendingSchoolName" runat="server" Text="attendingschoolname"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right">
                            <strong>Home School:</strong></td>
                        <td style="height: 18px">
                            <asp:Label ID="conf_lblHomeID" runat="server" Text="homeID"></asp:Label>
                        </td>
                        <td nowrap="nowrap" style="height: 18px" colspan="2">
                            <asp:Label ID="conf_lblHomeSchoolName" runat="server" Text="homeschoolname"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <hr />
                <br />
                <strong>Confirmation - Enrolment Comments<br />
                </strong>
                <asp:Label ID="conf_lblComments" runat="server" BorderStyle="None"
                    Text="comments" Width="90%"></asp:Label>
                <br />
				<strong>Confirmation - Privacy Permission: </strong><asp:Label ID="conf_lblPrivacyPermission" runat="server" BorderStyle="None" Text="" Width="90%"></asp:Label>
                <br />
                <hr />
                <br />
                <strong>Confirmation - Postal Address</strong><br /><table width="100%" cellpadding="2">

                    <tr>
                        <td style="text-align: right; height: 20px;">
                            <strong>Student Contact Email Address:</strong></td>
                        <td style="height: 20px">
                            <asp:label ID="conf_lblStudentEmail" runat="server"  Text="emailaddress" />

                        </td>
                        <td><td><td style="width: 5px"></td><td></td>
                    </tr>
						<tr>
                        <td style="height: 18px; text-align: right">
                            <strong>Student Mobile Number:</strong></td>
                        <td style="height: 18px">
                            <asp:label ID="conf_lblStudentMobile" runat="server" Text="mobile" />
                        </td>
                       <td><td><td style="width: 5px"></td><td></td>
                    </tr>


                    <tr>
                        <td>
                            <strong><span style="font-size: 12pt; text-decoration: underline">Postal Address:</span></strong></td>
                        <td>
                            &nbsp;<asp:CheckBox ID="chkbox_same_as_attending_confirm" runat="server" Text="Checked if same as Attending School:"
                                TextAlign="Left" />
                        </td>
                        <td>
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right">
                            <strong>Addressee:</strong></td>
                        <td style="height: 18px">
                            <asp:label ID="conf_lbladdressee_1" runat="server" Text="addressee" />
                            
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right">
                            <strong>Agent:</strong></td>
                        <td style="height: 18px">
                            <asp:label ID="conf_lblagent_1" runat="server" Text="agent" />
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <strong>Address:</strong></td>
                        <td>
                            <asp:label ID="conf_lbladdr1_1" runat="server" text="address1" />
                        </td>
                        <td>
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px">
                        </td>
                        <td style="height: 18px">
                            <asp:label ID="conf_lbladdr2_1" runat="server" Text="address2" />
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <strong>Suburb / Town:</strong></td>
                        <td>
                            <asp:label ID="conf_lblsuburb_town_1" runat="server" Text="suburbtown" />
                            
                        </td>
                        <td style="text-align: right">
                            <strong>State:</strong></td>
                        <td style="width: 5px">
                            <asp:label ID="conf_lblstate_1" runat="server" Text="state" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right">
                            <strong>Postcode:</strong></td>
                        <td style="height: 18px">
                            <asp:label ID="conf_lblpostcode_1" runat="server" text="postcode" />
                            
                        </td>
                        <td style="height: 18px; text-align: right">
                            <strong>Country:</strong></td>
                        <td style="width: 5px; height: 18px">
                            <asp:label ID="conf_lblcountry_1" runat="server"  Text="country" />
                        </td>
                        <td >
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right">
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <strong>Home Phone:</strong></td>
                        <td>
                            <asp:label ID="conf_lblphonea_1" runat="server" Text="phoneA" />
                        </td>
                        <td style="text-align: right">
                            <strong>Mobile/Phone:</strong></td>
                        <td style="width: 5px">
                            <asp:label ID="conf_lblphoneb_1" runat="server" Text="phoneB" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 18px; text-align: right">
                            <strong>Fax:</strong></td>
                        <td style="height: 18px">
                            <asp:label ID="conf_lblfax_1" runat="server" Text="fax" />
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 20px;">
                            <strong>Student/School Email Address:</strong></td>
                        <td style="height: 20px">
                            <asp:label ID="conf_lblemail_address_1" runat="server"  Text="emailaddress" />
                        </td>
                        <td style="height: 20px">
                        </td>
                        <td style="width: 5px; height: 20px;">
                        </td>
                        <td style="height: 20px">
                        </td>
                    </tr>
                    <tr><td style="text-align: right; height: 20px;">
                        <strong>Parent/Carer Email Address:</strong></td>
                        <td style="height: 20px">
                            <asp:label ID="conf_lblemail_address_1b" runat="server"  Text="emailaddress2" />
                        </td>
                        <td style="height: 18px">
                        </td>
                        <td style="width: 5px; height: 18px">
                        </td>
                        <td style="width: 3px; height: 18px">
                        </td>
                    </tr>
                </table>
                <br />
                
            </asp:WizardStep>
            <asp:WizardStep runat="server" StepType="Complete" Title="Finished!">
                <p align=center>
                <asp:Image ID="biggreentick" runat="server" ImageUrl="~/images/biggreentick.gif" />
                <br />
                <br />
                Enrolment for Student
                <asp:Label ID="lblNewStudentName" runat="server" Font-Bold="True" Text="newstudentname"></asp:Label>
                &nbsp;has been <strong>Saved</strong><br />
                <br />
                with <strong>Student Id :</strong>
                <asp:Label ID="lblNewStudentID" runat="server" Font-Bold="True" Text="Error - Call Support" Font-Size="X-Large" ForeColor="Red"></asp:Label>
                &nbsp;&nbsp;</p>
                <p align="center">
                <br />
                for Enrolment Year :<asp:Label ID="lblNewEnrolmentYear" runat="server" Font-Bold="True"
                    Text="enrolmentyear"></asp:Label>
                &nbsp;&nbsp;&nbsp;<br />
                <br />
                <br />
                    <asp:HyperLink ID="HyperLink_AddSubjects" runat="server" BorderStyle="None" NavigateUrl="~/Student_Subject_maintain.aspx" CssClass="Button">Add Subjects</asp:HyperLink>
                    | &nbsp;<asp:HyperLink ID="HyperLink_AddFinancials" runat="server" BorderStyle="None"
                        CssClass="Button" NavigateUrl="~/FinancialAccounts_maintain.aspx">Add Financials</asp:HyperLink>
                    &nbsp; |
                    <asp:HyperLink ID="HyperLink_AddCensus" runat="server" BorderStyle="None" CssClass="Button"
                        NavigateUrl="~/Student_Census_maintain.aspx">Add Census</asp:HyperLink>
                    <br />
                </p>
                <p align="center">
                <br />
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/StudentEnrolment_InitialCheck.aspx" BorderStyle="None" CssClass="Button">add a new student</asp:HyperLink>
                </p>
                <p>
                    <asp:HiddenField ID="hidden_StudentEnrolled" runat="server" Value="0" />
                    &nbsp;</p>
            </asp:WizardStep>
        </WizardSteps>
        <StepStyle VerticalAlign="Top" />
        <SideBarStyle VerticalAlign="Top" />
    </asp:Wizard>
    &nbsp;
    <asp:Label ID="STUDENTlblErrorMessages" runat="server" Visible="False"></asp:Label></p>
  <!--'******************************
        'Date Modified : 21 July 2009
        'Modified by : Vikas
        'Ref: Unfuddle Ticket No: 57
        'Task: School Address on New Enrolments
        '******************Code Starts Here******************
        -->
    <asp:HiddenField ID="txtAttendingSchoolID_hidden" runat="server" />
    <asp:HiddenField ID="txtSchoolAddressId_hidden" runat="server" />
    <div id="div_StudentExist" runat="server" style="display: none; position: absolute; border: solid black 0px; padding: 0px; text-align: justify; font-size: 12px; width:100%; height:100%; z-index:100;top:0px; left:0px;">
    <table id="fullscreentable" style="width:100%; height:100%; border:0px; color:AntiqueWhite; " runat="server">
    <tr><td style="text-align:center;">
            <table id="Childscreentable" style="width:30%; border:0px; color:AntiqueWhite;" cellpadding="0" cellspacing="0" runat=server>
            <tr><td>
                    <table id="TitleTable" style="width:100%; border:0px; background-color:#5298ED; color:AntiqueWhite;" runat="server"><tr><td width="90%"><strong>Student Found with same detail</strong></td><td style="width:10%; text-align:center;"><!--<img src="images/cross.gif" />-->&nbsp;</td></tr></table>
            </td></tr>
            <tr><td>
                    <div id="innerDiv_StudentExist2" style="width:100%; border:0px; background-color:#FFFFFF;  text-align: justify; font-size: 12px; color:Black; font-family:Verdana,Arial; padding: 10px;" runat="server">asdaads</div> 
            </td></tr>
            <tr><td>
                    <table id="FooterTable" style="width:100%; border:0px; background-color:#FFFFFF; " runat="server"><tr><td width="30%">&nbsp;</td><td style="width:70%; text-align:center;"><div onClick="javascript:StudentMessage();" style="color:Blue; cursor:pointer;"> Not This Student</div></td></tr></table>
            </td></tr>
            </table>
    </td></tr></table>
    </div>
    <script language="JavaScript" src="js/pt/prototype.js" type="text/javascript"></script>
<script language="JavaScript" src="js/pt/prototype_ccs.js" type="text/javascript"></script>
<!--******************************
           Code Ends Here
        -->
        
</form>
</body>
</html>

<!--End ASPX page-->

