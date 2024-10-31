<!--ASPX page @1-CD9B2492-->
    <%@ Page language="vb" CodeFile="Student_Census_maintain.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_Census_maintain.Student_Census_maintainPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_Census_maintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Census Maintain</title>


<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-092F8E28
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript" charset="utf-8" src='ClientI18N.aspx?file=DatePicker.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Include User Scripts @1-2F156497
</script>
<script language="JavaScript" src="js/pt/prototype.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/pt/scriptaculous.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/pt/controls.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/Services.js" type="text/javascript" charset="windows-1252"></script>
<link rel="stylesheet" type="text/css" href="Student_Census_maintainSTUDENT_CENSUS_DATASCHOOL_NAME_style.css">
<script language="JavaScript" type="text/javascript">
//End Include User Scripts

//Date Picker Object Definitions @1-6A2D0D98

var STUDENT_CENSUS_DATADatePicker_DATE_STARTED_IN_AUST = new Object(); 
STUDENT_CENSUS_DATADatePicker_DATE_STARTED_IN_AUST.format           = "d/m/yyyy";
STUDENT_CENSUS_DATADatePicker_DATE_STARTED_IN_AUST.style            = "Styles/Blueprint/Style.css";
STUDENT_CENSUS_DATADatePicker_DATE_STARTED_IN_AUST.relativePathPart = "";
STUDENT_CENSUS_DATADatePicker_DATE_STARTED_IN_AUST.themeVersion     = "3.0";
var STUDENT_CENSUS_DATADatePicker_DATE_ARRIVED_IN_AUST = new Object(); 
STUDENT_CENSUS_DATADatePicker_DATE_ARRIVED_IN_AUST.format           = "d/m/yyyy";
STUDENT_CENSUS_DATADatePicker_DATE_ARRIVED_IN_AUST.style            = "Styles/Blueprint/Style.css";
STUDENT_CENSUS_DATADatePicker_DATE_ARRIVED_IN_AUST.relativePathPart = "";
STUDENT_CENSUS_DATADatePicker_DATE_ARRIVED_IN_AUST.themeVersion     = "3.0";
//End Date Picker Object Definitions

//page_STUDENT_CENSUS_DATA_Button_Cancel_OnClick @4-C43C1CAE
function page_STUDENT_CENSUS_DATA_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_CENSUS_DATA_Button_Cancel_OnClick

//page_STUDENT_CENSUS_DATA1_Button_Cancel_OnClick @136-DDDE7C48
function page_STUDENT_CENSUS_DATA1_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_CENSUS_DATA1_Button_Cancel_OnClick

//Initialize STUDENT_CENSUS_DATASCHOOL_NAMEPTAutocomplete2 @87-6FD6389E
function STUDENT_CENSUS_DATASCHOOL_NAMEPTAutocomplete2_start() {
    if ($("STUDENT_CENSUS_DATASCHOOL_NAME"))
        new Ajax.Autocompleter("STUDENT_CENSUS_DATASCHOOL_NAME", "STUDENT_CENSUS_DATASCHOOL_NAME_choices", "services/MaintainSearchRequest_Advanced_viewMaintainSearchRequest_s_SCHOOLNAME_PTAutocomplete1.aspx", {indicator:'STUDENT_CENSUS_DATAajaxBusy'});
}
//End Initialize STUDENT_CENSUS_DATASCHOOL_NAMEPTAutocomplete2

//Handle STUDENT_CENSUS_DATACondition1 @70-460C4752
function STUDENT_CENSUS_DATACondition1_start(sender) {
//End Handle STUDENT_CENSUS_DATACondition1

//Custom STUDENT_CENSUS_DATACondition1 @70-A8225497
        // ERA: kooky JS created from Wizard. Fixed by Eric
    if ($("STUDENT_CENSUS_DATASCHOOL_NAME").value != "")
    {
        STUDENT_CENSUS_DATAPTAutoFill1_start(sender);
    } else {
    }
//End Custom STUDENT_CENSUS_DATACondition1

//STUDENT_CENSUS_DATACondition1 Tail @70-FCB6E20C
}
//End STUDENT_CENSUS_DATACondition1 Tail

//PTAutoFill1 Loading @75-0D9C8967
function STUDENT_CENSUS_DATAPTAutoFill1_start(sender) {
        // ERA fixing keyword selection as it grabbed the form, not the field
    new Ajax.Request("services/MaintainSearchRequest_Advanced_viewMaintainSearchRequest_s_SCHOOLNAME_PTAutoFill1.aspx?keyword=" + encodeURI($("STUDENT_CENSUS_DATASCHOOL_NAME").value), {
        method: "get",
        requestHeaders: ['If-Modified-Since', new Date(0)],
        onSuccess: function(transport) {
            var valuesRow = eval(transport.responseText)[0];
            $("STUDENT_CENSUS_DATAPREVIOUS_SCHOOL_ID").value = valuesRow["SCHOOL_ID"];
        }, 
        onFailure: function(transport) {
            alert(transport.responseText);
        }
    });
}
//End PTAutoFill1 Loading

//bind_events @1-65B4BE36
function bind_events() {
    STUDENT_CENSUS_DATASCHOOL_NAMEPTAutocomplete2_start();
        addEventHandler("STUDENT_CENSUS_DATASCHOOL_NAME", "focus", STUDENT_CENSUS_DATACondition1_start);   //ERA: add to 'focus' to ensure firing
    addEventHandler("STUDENT_CENSUS_DATASCHOOL_NAME", "keyup", STUDENT_CENSUS_DATACondition1_start);   //ERA: change event from 'keypress' to 'keyup' (better browser support)
    addEventHandler("STUDENT_CENSUS_DATAButton_Cancel","click",page_STUDENT_CENSUS_DATA_Button_Cancel_OnClick);

    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

window.onload = bind_events; 

//End CCS script
</script>
<style type="text/css">
<!--
#STUDENT_CENSUS_DATAHIGHEST_SCHOOL_LEVEL td  { border-top-style: none; border-right-style: none; }
#STUDENT_CENSUS_DATARadioButton_Employment_Status td  { border-top-style: none; border-right-style: none; }
#STUDENT_CENSUS_DATARadioButton_Reason_for_Study td  { border-top-style: none; border-right-style: none; }
#STUDENT_CENSUS_DATACheckBoxList_Disability td  { border-top-style: none; border-right-style: none; }
#STUDENT_CENSUS_DATACheckBoxList_PriorQualifications td  { border-top-style: none; border-right-style: none; }
-->
</style>
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">

</head>
<body>
<form runat="server">


<div align="center">
</div>
<div align="left">
    <DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/> 
</div>
<div align="left">
</div>

  <span id="STUDENT_CENSUS_DATA1Holder" runat="server">
    


    <table class="MainTable" style="WIDTH: 80%" cellspacing="0" cellpadding="0" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Edit STUDENT Access / Alert</th>
 
                        <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="STUDENT_CENSUS_DATA1Error" visible="False" runat="server">
  
                    <tr id="STUDENT_CENSUS_DATA1ErrorBlock" class="Error">
                        <td colspan="2"><asp:Label ID="STUDENT_CENSUS_DATA1ErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Controls">
                        <th>STUDENT ID</th>
 
                        <td><asp:Literal id="STUDENT_CENSUS_DATA1STUDENT_ID" runat="server"/> </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>Is the Student AT RISK?</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ATRISK"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>If Yes - briefly describe AT RISK Restrictions</th>
 
                        <td>
<asp:TextBox id="STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ATRISK_DESCRIPTION" rows="3" Columns="70" TextMode="MultiLine"	runat="server"/>
</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>Is there an ACCESS ALERT for the student?</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ALERT"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;<u>If Yes - has ACCESS ALERT been RECEIVED?</u></th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ALERT_RECEIVED"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><em>(VSV Use)</em></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>ACCESS TYPE</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_CENSUS_DATA1RESTRICT_ACCESS_TYPE"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>Briefly describe any ACCESS Restrictions</th>
 
                        <td>
<asp:TextBox id="STUDENT_CENSUS_DATA1RESTRICT_ACCESS_DESCRIPTION" rows="3" Columns="70" TextMode="MultiLine"	runat="server"/>
</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>Is there an ACTIVITY ALERT for the Student?</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_CENSUS_DATA1RESTRICT_ACTIVITY_ALERT"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>If Yes - briefly describe any ACTIVITY Restrictions</th>
 
                        <td>
<asp:TextBox id="STUDENT_CENSUS_DATA1RESTRICT_ACTIVITY_DESCRIPTION" rows="3" Columns="70" TextMode="MultiLine"	runat="server"/>
</td>
                    </tr>
 
                    <tr class="Bottom">
                        <td style="TEXT-ALIGN: right" colspan="2">
                            <input id='STUDENT_CENSUS_DATA1Button_Update' type="submit" class="Button" value="Update" OnServerClick='STUDENT_CENSUS_DATA1_Update' runat="server"/>
                            <input id='STUDENT_CENSUS_DATA1Button_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_CENSUS_DATA1_Cancel' runat="server"/></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>



  </span>
  <br>
<br>

  <span id="STUDENT_CENSUS_DATAHolder" runat="server">
    


    <table class="MainTable" style="WIDTH: 80%" cellspacing="0" cellpadding="0" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Edit Student Census Data</th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="STUDENT_CENSUS_DATAError" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="2"><asp:Label ID="STUDENT_CENSUS_DATAErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Controls">
                        <th><strong>STUDENT ID:</strong>&nbsp;<br>
                        <br>
                        <br>
                        </th>
 
                        <td><br>
                            &nbsp;<asp:Literal id="STUDENT_CENSUS_DATASTUDENT_ID" runat="server"/>&nbsp;&nbsp;&nbsp; 
                            <a id="STUDENT_CENSUS_DATALink_gotoTAFECensusPage" href="" class="Button" style="PADDING-BOTTOM: 10px; PADDING-TOP: 10px; PADDING-LEFT: 10px; PADDING-RIGHT: 10px" runat="server"   Visible="False">TAFE Census page</a></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>In which COUNTRY was the student BORN (COUNTRY OF BIRTH)</th>
 
                        <td>
                            <select id="STUDENT_CENSUS_DATACOUNTRY_OF_BIRTH"  runat="server"></select>
 </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>RESIDENTIAL STATUS (in Australia)</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_CENSUS_DATARESIDENTIAL_STATUS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Error">
                        <td colspan="2"><em>&nbsp;If Residential status is "Temporary" then:</em>&nbsp; <strong><asp:Literal id="STUDENT_CENSUS_DATAResidentialStatusErrormessage" runat="server"/></strong> </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>VISA SUB CLASS (eg: 457, 309, 672)</th>
 
                        <td><asp:TextBox id="STUDENT_CENSUS_DATAVISA_SUB_CLASS" maxlength="3" Columns="4"	runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>VISA STATISTICAL CODE</th>
 
                        <td><asp:TextBox id="STUDENT_CENSUS_DATAVISA_STATISTICAL_CODE" maxlength="4" Columns="4"	runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>DATE STARTED IN AUST <em>(d/m/yyyy)</em></th>
 
                        <td><asp:TextBox id="STUDENT_CENSUS_DATADATE_STARTED_IN_AUST" maxlength="12" Columns="12"	runat="server"/>
                            <asp:PlaceHolder id="STUDENT_CENSUS_DATADatePicker_DATE_STARTED_IN_AUST" runat="server"><a href="javascript:showDatePicker('<%#STUDENT_CENSUS_DATADatePicker_DATE_STARTED_IN_AUSTName%>','forms[\''+theForm.id+'\']','<%#STUDENT_CENSUS_DATADatePicker_DATE_STARTED_IN_AUSTDateControl%>');" id="STUDENT_CENSUS_DATADatePicker_DATE_STARTED_IN_AUST_Link"  ><img border="0" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" /></a></asp:PlaceHolder>
  </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>DATE ARRIVED IN AUST<em>(d/m/yyyy)</em></th>
 
                        <td><asp:TextBox id="STUDENT_CENSUS_DATADATE_ARRIVED_IN_AUST" maxlength="12" Columns="12"	runat="server"/>
                            <asp:PlaceHolder id="STUDENT_CENSUS_DATADatePicker_DATE_ARRIVED_IN_AUST" runat="server"><a href="javascript:showDatePicker('<%#STUDENT_CENSUS_DATADatePicker_DATE_ARRIVED_IN_AUSTName%>','forms[\''+theForm.id+'\']','<%#STUDENT_CENSUS_DATADatePicker_DATE_ARRIVED_IN_AUSTDateControl%>');" id="STUDENT_CENSUS_DATADatePicker_DATE_ARRIVED_IN_AUST_Link"  ><img border="0" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" /></a></asp:PlaceHolder>
  </td>
                    </tr>
 
                    <tr class="Controls">
                        <th colspan="2">
                        <p><strong></strong>&nbsp;</p>
 
                        <p><strong>&nbsp;All Students</strong>&nbsp;</p>
                        </th>
                    </tr>
 
                    <tr class="Controls">
                        <th>FIRST LANGUAGE (Student speaks this&nbsp;language at home, or English)</th>
 
                        <td>
                            <select id="STUDENT_CENSUS_DATAFIRST_HOME_LANGUAGE"  runat="server"></select>
 </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>OTHER LANGUAGE (use 'English' if student speaks English <br>
                        AND a&nbsp;non-English First Language, otherwise leave blank)</th>
 
                        <td>
                            <select id="STUDENT_CENSUS_DATAOTHER_HOME_LANGUAGE"  runat="server"></select>
 </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>Is the student of ABORIGINAL / KOORI / TORRES STRAIT origin?
  <input id="STUDENT_CENSUS_DATAHidden_KoorieTorresFlag" type="hidden"  runat="server"/>
  </th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_CENSUS_DATAKOORITORRESFLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>Is the student currently involved with Youth Justice<br>
                        (in custody, remand or sentence, or in community)?
  <input id="STUDENT_CENSUS_DATAHidden_YouthJusticeInvolvementFlag" type="hidden"  runat="server"/>
  </th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_CENSUS_DATAYOUTH_JUSTICE_INVOLVEMENT"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><br>
                            <asp:TextBox id="STUDENT_CENSUS_DATAYOUTH_JUSTICE_INVOLVEMENT_DETAILS" maxlength="50"	runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>What are the Student's LIVING ARRANGEMENTS? (HOUSEHOLD STATUS)
  <input id="STUDENT_CENSUS_DATAHidden_household_status" type="hidden"  runat="server"/>
  </th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_CENSUS_DATAHOUSEHOLD_STATUS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>CRIS ID <em>(Statutory/Court-ordered Out of Home Care only)</em></th>
 
                        <td><asp:TextBox id="STUDENT_CENSUS_DATACRIS_ID" maxlength="20"	runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th colspan="2">
                        <p><strong></strong>&nbsp;</p>
 
                        <p><strong>&nbsp;Non-Enrollment form items</strong>&nbsp;</p>
                        </th>
                    </tr>
 
                    <tr class="Controls">
                        <th>
                        <p align="right">&nbsp;<em>Type School Name to automatically fill in Previous School ID</em></p>
                        </th>
 
                        <td id="ajax_busy">
                            <asp:TextBox id="STUDENT_CENSUS_DATASCHOOL_NAME" Columns="50" autocomplete="off"	runat="server"/>
                            <!-- BEGINF PTAutocomplete PTAutocomplete1 -->
                            <div id="STUDENT_CENSUS_DATASCHOOL_NAME_choices">
                            </div>
                            <!-- ENDF PTAutocomplete PTAutocomplete1 -->&nbsp; 
                            <!-- BEGINF PTAutocomplete PTAutocomplete2 -->
                            <div id="STUDENT_CENSUS_DATASCHOOL_NAME_choices">
                            </div>
                            <!-- ENDF PTAutocomplete PTAutocomplete2 --><asp:Image id="STUDENT_CENSUS_DATAajaxBusy"  style="DISPLAY: none" AlternateText="looking..." ImageUrl="images/ajax-loader_small.gif" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>PREVIOUS SCHOOL ID <em>(Mandatory 2020+, <u>cannot be VSV</u>)</em></th>
 
                        <td><asp:TextBox id="STUDENT_CENSUS_DATAPREVIOUS_SCHOOL_ID" maxlength="10" Columns="9"	runat="server"/>&nbsp;<asp:Literal id="STUDENT_CENSUS_DATAlblPREVIOUS_SCHOOL_NAME" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>DATE LAST ATTENDED SCHOOL &nbsp;</th>
 
                        <td><asp:TextBox id="STUDENT_CENSUS_DATADATE_LAST_ATTENDED_SCHOOL" Columns="12"	runat="server"/>&nbsp;<em>(added April 2011)</em></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>ALLOWANCE CODE (ie: receives AUSTUDY; ABSTUDY; EMA)</th>
 
                        <td>
                            <select id="STUDENT_CENSUS_DATAALLOWANCE_CODE"  runat="server"></select>
 </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>FAMILY OCCUPATION GROUP</th>
 
                        <td>
                            <select id="STUDENT_CENSUS_DATAFAMILY_OSG"  runat="server"></select>
 </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>DISABILITY ID</th>
 
                        <td><asp:TextBox id="STUDENT_CENSUS_DATADISABILITY_ID" maxlength="6" Columns="6"	runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>REPEATING YEAR</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_CENSUS_DATAREPEATING_YEAR"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>OTHER SCHOOL TIME FRACTION</th>
 
                        <td><asp:TextBox id="STUDENT_CENSUS_DATAOTHER_SCHOOL_TF" maxlength="3" Columns="3"	runat="server"/>&nbsp;</td>
                    </tr>
                </table>
 
                <p>
                <table class="Record" cellspacing="0" cellpadding="0">
                    <tr class="Controls">
                        <th colspan="3"><strong><em>Additional Family details (Parent Census)</em></strong></th>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td><strong><em>Mother&nbsp; /&nbsp;Parent 1 /&nbsp;Guardian 1</em></strong></td> 
                        <td><strong><em>Father /&nbsp;Parent&nbsp;2 /&nbsp;Guardian 2</em></strong></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>In which COUNTRY were they BORN (COUNTRY OF BIRTH)</th>
 
                        <td>
                            <select id="STUDENT_CENSUS_DATAMOTHERS_COB"  runat="server"></select>
 </td> 
                        <td>&nbsp; 
                            <select id="STUDENT_CENSUS_DATAFATHERS_COB"  runat="server"></select>
 </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>Speak a language other than English at home? (MAIN LANGUAGE)</th>
 
                        <td>
                            <select id="STUDENT_CENSUS_DATAMOTHER_LANGUAGE"  runat="server"></select>
 </td> 
                        <td>&nbsp; 
                            <select id="STUDENT_CENSUS_DATAFATHER_LANGUAGE"  runat="server"></select>
 </td>
                    </tr>
 
                    <tr class="Controls">
                        <th><em>Highest</em> year of Primary-Secondary school <br>
                        (SCHOOL EDUCATION)</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_CENSUS_DATAMOTHER_EDUCATION_SCHOOL"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
                        <td>&nbsp; 
                            <asp:RadioButtonList id="STUDENT_CENSUS_DATAFATHER_EDUCATION_SCHOOL"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>Level of <em>highest</em>&nbsp; qualification <br>
                        (POST-SCHOOL EDUCATION) </th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_CENSUS_DATAMOTHER_EDUCATION_NONSCHOOL"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
                        <td>&nbsp; 
                            <asp:RadioButtonList id="STUDENT_CENSUS_DATAFATHER_EDUCATION_NONSCHOOL"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>OCCUPATION GROUP</th>
 
                        <td>
                            <select id="STUDENT_CENSUS_DATAMOTHER_OCCUPATIONGROUP"  runat="server"></select>
 </td> 
                        <td>&nbsp; 
                            <select id="STUDENT_CENSUS_DATAFATHER_OCCUPATIONGROUP"  runat="server"></select>
 </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>LAST ALTERED BY / DATE (entire form)</th>
 
                        <td><asp:Literal id="STUDENT_CENSUS_DATALAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_CENSUS_DATALAST_ALTERED_DATE" runat="server"/></td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="3" align="right">
                            <input id='STUDENT_CENSUS_DATAButton_Update' type="submit" class="Button" value="Update" OnServerClick='STUDENT_CENSUS_DATA_Update' runat="server"/>
                            <input id='STUDENT_CENSUS_DATAButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_CENSUS_DATA_Cancel' runat="server"/></td>
                    </tr>
                </table>
                
  <input id="STUDENT_CENSUS_DATAHidden_last_altered_by" type="hidden"  runat="server"/>
  
  <input id="STUDENT_CENSUS_DATAHidden_last_altered_date" type="hidden"  runat="server"/>
  </p>
            </td>
        </tr>
    </table>



  </span>
  <br>

</form>
</body>
</html>

<!--End ASPX page-->

