<!--ASPX page @1-DD22AE02-->
    <%@ Page language="vb" CodeFile="StudentEnrolmentDetails_maintain.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.StudentEnrolmentDetails_maintain.StudentEnrolmentDetails_maintainPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.StudentEnrolmentDetails_maintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Enrolment Details - Maintain</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-092F8E28
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript" charset="utf-8" src='ClientI18N.aspx?file=DatePicker.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Include User Scripts @1-2F0138A6
</script>
<script language="JavaScript" src="js/pt/prototype.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/pt/prototype_ccs.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include User Scripts

//Date Picker Object Definitions @1-3BE1D1E7

var STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATE = new Object(); 
STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATE.format           = "dd/mm/yy";
STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATE.style            = "Styles/Blueprint/Style.css";
STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATE.relativePathPart = "";
STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATE.themeVersion     = "3.0";
var STUDENT_ENROLMENTDatePicker_ENROLMENT_DATE = new Object(); 
STUDENT_ENROLMENTDatePicker_ENROLMENT_DATE.format           = "dd/mm/yy";
STUDENT_ENROLMENTDatePicker_ENROLMENT_DATE.style            = "Styles/Blueprint/Style.css";
STUDENT_ENROLMENTDatePicker_ENROLMENT_DATE.relativePathPart = "";
STUDENT_ENROLMENTDatePicker_ENROLMENT_DATE.themeVersion     = "3.0";
//End Date Picker Object Definitions

//page_STUDENT_ENROLMENT_ATAR_REQUIRED_OnChange @223-8DB3C914
function page_STUDENT_ENROLMENT_ATAR_REQUIRED_OnChange()
{
    var result;
//End page_STUDENT_ENROLMENT_ATAR_REQUIRED_OnChange

//Confirmation Message @282-5FD8CAF2
    return confirm('NOTE: Written advice MUST be received from Student when changing to [No - ATAR Not Required]

(Nothing needed for [Yes - ATAR Required])');
//End Confirmation Message

//Close page_STUDENT_ENROLMENT_ATAR_REQUIRED_OnChange @223-BC33A33A
    return result;
}
//End Close page_STUDENT_ENROLMENT_ATAR_REQUIRED_OnChange
//page_STUDENT_ENROLMENT_Button_Cancel_OnClick @5-287A9D41
function page_STUDENT_ENROLMENT_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_ENROLMENT_Button_Cancel_OnClick

//PTAutoFill2 Loading @201-1E5467D7
function STUDENT_ENROLMENTPTAutoFill2_start(sender) {
    if (!sender || sender === window) return;
    new Ajax.Request("services/StudentEnrolmentDetails_maintain_STUDENT_ENROLMENT_txtSchool_Super_Name_PTAutoFill1.aspx?keyword=" + encodeURIComponent(sender.value).replace(/'/g, "%27"), {
        method: "get",
        requestHeaders: ['If-Modified-Since', new Date(0)],
        onSuccess: function(transport) {
            var valuesRow = eval(transport.responseText)[0];
            if (typeof(valuesRow) != "undefined") {
                $("txtSchool_Super_Phone").value = valuesRow["SCHOOL_SUPERVISOR_PHONE"];
                $("txtSchool_Super_Email").value = valuesRow["SCHOOL_SUPERVISOR_EMAIL"];
            } else {
                $("txtSchool_Super_Phone").value = "";
                $("txtSchool_Super_Email").value = "";
            }
        }, 
        onFailure: function(transport) {
            alert(transport.responseText);
        }
    });
}
//End PTAutoFill2 Loading

//bind_events @1-1449D011
function bind_events() {
    addEventHandler("STUDENT_ENROLMENTATAR_REQUIRED","change",page_STUDENT_ENROLMENT_ATAR_REQUIRED_OnChange);
    addEventHandler("STUDENT_ENROLMENTButton_Cancel","click",page_STUDENT_ENROLMENT_Button_Cancel_OnClick);
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

window.onload = bind_events; 

//End CCS script
</script>
<!--Style sheet to be used by Supervisor ajax div controls-->
<style type="text/css">
<!--
A:link  { text-decoration: none; }
A:visited  { text-decoration: none; }
A:active  { text-decoration: none; }
A:hover  { text-decoration: underline; cursor: hand; font-weight: bold; }
.divClose  { background-color: Gray; cursor: hand; color: white; font-size: 10px; }
.strikethrough  { text-decoration: line-through; }
-->
</style>
<script language="JavaScript" type="text/javascript">
/*
created by : Vikas Baweja 
Creation date: 08-02-2010
Ticket : #232
Code Starts here 
*/
var xmlhttp;
/* - removed as School Super now on Carer page - EA 13-May-2011
//Get data from the service 
function fill_SuperVisorDetails()
{
    if (document.getElementById('STUDENT_ENROLMENTtxtSchool_Super_Name').value!="")
        {
        if(document.getElementById('STUDENT_ENROLMENTtxtSchool_Super_Name').value.length>=2)
            {
                setXMLHttpobject();   
                var url="services/StudentEnrolmentDetails_maintain_ajax.aspx?supervisor="+document.getElementById('STUDENT_ENROLMENTtxtSchool_Super_Name').value;
                xmlhttp.onreadystatechange=state_Change;
                xmlhttp.open("GET",url,true);
                xmlhttp.send(null);
            }
         }
}

///Create browser object
function setXMLHttpobject()
{
        xmlhttp=null;
        try
        {
            xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
        }
        catch(e)
        {
                try
                {
                xmlhttp=new ActiveXObject("Msxml2.XMLHTTP");
                }
                catch(e)
                {
                           xmlhttp=new XMLHttpRequest();
                }
        }        
}

//Receive data from the service
function state_Change()
{
if (xmlhttp.readyState==4)
  {// 4 = "loaded"
  if (xmlhttp.status==200)
    {// 200 = "OK"
        Design_SuperVisor_Popup(xmlhttp.responseText);
    }
  else
    {
        alert("Problem retrieving data:" + xmlhttp.statusText);
    }
  }
}

//design the div control based on the data recived from the service
function Design_SuperVisor_Popup(SuperVisorList)
{
    var sSuperVisor= new Array();
    sSuperVisor=SuperVisorList.split('~');
    //alert(sSuperVisor.length);
    var Counter=0;
    var sHtml="<div style='overflow:scroll; overflow-x:hidden; width:145px; height:150px;'> ";
    var aHtml="";
    for(Counter=0; Counter<parseInt(sSuperVisor.length); Counter++)
    {
        var sSuperVisorDetails=new Array();
        sSuperVisorDetails=sSuperVisor[Counter].split('|');
        var paramString="'" + sSuperVisorDetails[0] + "','" + sSuperVisorDetails[1] + "','" + sSuperVisorDetails[2] + "'";   
        aHtml=aHtml + '<A href="javascript:void(0);" style="color:Black;padding:5px;" onClick="javascript:PopulteServerControls(' + paramString + ');" >' + sSuperVisorDetails[0] + '</A><br>';            
        }
        if (aHtml!='')
        {
            sHtml=sHtml + aHtml + '</div><div style="background-color:Gray; height:12px;"><table><tr><td width="80%">&nbsp;</td><td class="divClose" width="20%" align="Right" onClick="javascript:ClosePopupSuperVisor();"> CLOSE</td></tr></table><div>';            
            document.getElementById('STUDENT_ENROLMENTtxtSchool_Super_Name_choices').style.visibility='visible';
            document.getElementById('STUDENT_ENROLMENTtxtSchool_Super_Name_choices').innerHTML=sHtml;
            getPos(document.getElementById('STUDENT_ENROLMENTtxtSchool_Super_Name'));
        }
}

//Populate the server controls with the details 
function PopulteServerControls(Name,phone,email)
{
    document.getElementById('STUDENT_ENROLMENTtxtSchool_Super_Name').value=Name;
    document.getElementById('STUDENT_ENROLMENTtxtSchool_Super_Phone').value=phone;
    document.getElementById('STUDENT_ENROLMENTtxtSchool_Super_Email').value=email;
    document.getElementById('STUDENT_ENROLMENTtxtSchool_Super_Name_choices').style.visibility='hidden';
}

//Close/hide the Supervisor selection div
function ClosePopupSuperVisor()
{
    document.getElementById('STUDENT_ENROLMENTtxtSchool_Super_Name_choices').style.visibility='hidden';
}
*/
/*
Code ends here 
*/

</script>

</head>
<body>
<form runat="server">


<div align="center">
    <DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/> 
</div>
<div align="center">
</div>
<div align="center">
</div>

  <span id="STUDENT_ENROLMENTHolder" runat="server">
    


    <table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Edit Student Enrolment</th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="STUDENT_ENROLMENTError" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="4"><asp:Label ID="STUDENT_ENROLMENTErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Controls">
                        <th>&nbsp;<strong><font size="3">Enrolment Details</font></strong></th>
 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>STUDENT ID</strong></th>
 
                        <td>&nbsp;<asp:Literal id="STUDENT_ENROLMENTSTUDENT_ID" runat="server"/></td> 
                        <td>&nbsp;<strong>ENROLMENT DATE</strong> <em>dd/mm/yy</em></td> 
                        <td>&nbsp;<asp:TextBox id="STUDENT_ENROLMENTENROLMENT_DATE" maxlength="100" Columns="8"	runat="server"/>
                            <asp:PlaceHolder id="STUDENT_ENROLMENTDatePicker_ENROLMENT_DATE" runat="server"><a href="javascript:showDatePicker('<%#STUDENT_ENROLMENTDatePicker_ENROLMENT_DATEName%>','forms[\''+theForm.id+'\']','<%#STUDENT_ENROLMENTDatePicker_ENROLMENT_DATEDateControl%>');" id="STUDENT_ENROLMENTDatePicker_ENROLMENT_DATE_Link"  ><img border="0" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" />&nbsp;</a></asp:PlaceHolder>
  &nbsp;&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>END DATE</strong> <em>dd/mm/yy</em></th>
 
                        <td><asp:TextBox id="STUDENT_ENROLMENTWITHDRAWAL_DATE" maxlength="100" Columns="8"	runat="server"/>
                            <asp:PlaceHolder id="STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATE" runat="server"><a href="javascript:showDatePicker('<%#STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATEName%>','forms[\''+theForm.id+'\']','<%#STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATEDateControl%>');" id="STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATE_Link"  ><img border="0" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" /></a></asp:PlaceHolder>
  </td> 
                        <td>&nbsp;<strong>ENROLMENT STATUS</strong></td> 
                        <td>&nbsp; 
                            <select id="STUDENT_ENROLMENTENROLMENT_STATUS"  runat="server"></select>
 
  <input id="STUDENT_ENROLMENTHidden_EnrolmentStatus" type="hidden"  runat="server"/>
  </td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>WITHDRAWAL REASON</strong>&nbsp;</th>
 
                        <td>
                            <select id="STUDENT_ENROLMENTWITHDRAWAL_REASON_ID"  runat="server"></select>
 &nbsp;</td> 
                        <td><strong>&nbsp;EXIT DESTINATION</strong>&nbsp;<img onclick="javascript:alert('Exit Destination after WD, per Ian Varley, Dec 2009');return false;" id="exit_destination_icon" title="Exit Destination, Dec 2009" border="0" name="EXIT_WDIcon" alt="Exit Destination Dec 2009" src="images/icon_info.gif"></td> 
                        <td>&nbsp; 
                            <select id="STUDENT_ENROLMENTlbEXIT_DESTINATION"  runat="server"></select>
 </td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>YEAR LEVEL</strong></th>
 
                        <td>
                            <select id="STUDENT_ENROLMENTYEAR_LEVEL"  runat="server"></select>
 </td> 
                        <td>&nbsp;<strong>ENROLMENT YEAR</strong></td> 
                        <td>&nbsp;<asp:Literal id="STUDENT_ENROLMENTENROLMENT_YEAR" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>ATAR Required?</strong>&nbsp;<img onclick="javascript:alert('ATAR Score Required?, Jun 2012');return false;" id="atar_required_icon" title="ATAR Score Required?, Jun 2012" border="0" name="atar_requiredIcon" alt="ATAR Score Required?, Jun 2012" src="images/icon_info.gif"><br>
                        <em>Needed for Year 12 only</em></th>
 
                        <td>
                            <select id="STUDENT_ENROLMENTATAR_REQUIRED"  runat="server"></select>
 </td> 
                        <td>&nbsp;<strong>INTAKE INTERVIEW DONE?</strong>&nbsp;<img onclick="javascript:alert('Intake Interview Done?, per Mal McIvor, Jan 2010');return false;" id="intake_interview_icon" title="Intake Interview Done?, Jan 2010" border="0" name="intake_interviewIcon" alt="Intake Interview Done?, Jan 2010" src="images/icon_info.gif"></td> 
                        <td>&nbsp; 
                            <asp:RadioButtonList id="STUDENT_ENROLMENTINTERVIEW_INTAKE_DONE"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td> 
                        <td>&nbsp;<strong>PRIVACY PERMISSION GIVEN?</strong>&nbsp;<img onclick="javascript:alert('Permission VSV to access and share any existing relevant personal or health information with specialist practitioners or agencies that have been listed in this enrolment application.');return false;" id="privacy_permission_icon" title="Permission VSV to access and share any existing relevant personal or health information with specialist practitioners or agencies that have been listed in this enrolment application." border="0" name="privacy_permission_icon" alt="Permission VSV to access and share any existing relevant personal or health information with specialist practitioners or agencies that have been listed in this enrolment application." src="images/icon_info.gif"></td> 
                        <td>&nbsp; 
                            <asp:RadioButtonList id="STUDENT_ENROLMENTPRIVACY_PERMISSION"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><br>
                            <em>Mandatory 2020 Onwards</em> 
  <input id="STUDENT_ENROLMENTHidden_Privacy" type="hidden"  runat="server"/>
  </td></td>
                </tr>
 
                <tr class="Controls">
                    <th>&nbsp;</th>
 
                    <td>&nbsp;</td> 
                    <td>&nbsp;</td> 
                    <td>&nbsp;</td>
                </tr>
 
                <tr class="Controls">
                    <th>&nbsp;</th>
 
                    <td>&nbsp;</td> 
                    <td><strong>Personal Learning Plan</strong>&nbsp;<img onclick="javascript:alert('Personal Learning Plan or Personal Learning and Support Plan (2020)');return false;" id="personal_learning_icon" title="Personal Learning Plan or Mandated IEP" border="0" name="personal_learning_icon" alt="Personal Learning Plan or Mandated IEP" src="images/icon_info.gif">&nbsp;</td> 
                    <td>
                        <asp:RadioButtonList id="STUDENT_ENROLMENTPERSONAL_LEARNING_PLAN"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>
  <input id="STUDENT_ENROLMENTHidden_LearningPlan" type="hidden"  runat="server"/>
  </td>
                </tr>
 
                <tr class="Controls">
                    <th>&nbsp;</th>
 
                    <td>&nbsp;</td> 
                    <td><strong>Learning Advisor (LAd)</strong></td> 
                    <td>
                        <select id="STUDENT_ENROLMENTPASTORAL_CARE_ID"  runat="server"></select>
 </td>
                </tr>
 
                <tr class="Controls">
                    <th>&nbsp;</th>
 
                    <td>&nbsp;</td> 
                    <td>LAd Altered By / Date&nbsp;</td> 
                    <td><asp:Literal id="STUDENT_ENROLMENTLAd_ALLOC_BY" runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_ENROLMENTLAd_ALLOC_DATE" runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                    <th>&nbsp;</th>
 
                    <td>&nbsp;</td> 
                    <td><strong>SSG Facilitator</strong></td> 
                    <td>
                        <select id="STUDENT_ENROLMENTSSG_FACILITATOR_ID"  runat="server"></select>
 </td>
                </tr>
 
                <tr class="Controls">
                    <th>&nbsp;<strong><font size="3">Enrolment (Misc.)</font></strong></th>
 
                    <td>&nbsp;</td> 
                    <td>&nbsp;</td> 
                    <td>&nbsp;</td>
                </tr>
 
                <tr class="Controls">
                    <th><strong>Region</strong>&nbsp;</th>
 
                    <td colspan="3">
                        <select id="STUDENT_ENROLMENTlist_Region"  runat="server"></select>
 &nbsp;&nbsp;&nbsp;<em>(change only if necessary)</em>&nbsp;</td>
                </tr>
 
                <tr class="Controls">
                    <th><strike><strong>Region Approval Number</strong></strike></th>
 
                    <td><asp:TextBox id="STUDENT_ENROLMENTregion_approval_number" Columns="18"	runat="server"/></td> 
                    <td><strike><strong>iAchieve&nbsp;Username / Password </strong></strike></td> 
                    <td><input id="STUDENT_ENROLMENTlblACERUserName" readonly size="8" value='<%#PageVariables.Get("lblACERUserName")%>' name='<%#PageVariables.Get("lblACERUserName_Name")%>'/>/<input id="STUDENT_ENROLMENTlblACERPassword" readonly size="8" value='<%#PageVariables.Get("lblACERPassword")%>' name='<%#PageVariables.Get("lblACERPassword_Name")%>'/></td>
                </tr>
 
                <tr class="Controls">
                    <th>&nbsp;<strong>ELIGIBLE FOR DISCOUNT</strong></th>
 
                    <td>&nbsp; 
                        <asp:RadioButtonList id="STUDENT_ENROLMENTELIGIBLE_FOR_DISCOUNT"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
                    <td>&nbsp;<strong>PAID ON ENROLMENT</strong></td> 
                    <td>&nbsp; 
                        <asp:RadioButtonList id="STUDENT_ENROLMENTPAID_ON_ENROLMENT"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                    <th>&nbsp;<strong>RECEIPT NO</strong></th>
 
                    <td>&nbsp;<asp:TextBox id="STUDENT_ENROLMENTRECEIPT_NO" maxlength="10" Columns="10"	runat="server"/><em>Online Enrol Reference</em></td> 
                    <td>&nbsp;<strong>ELIGIBLE FOR FUNDING</strong></td> 
                    <td>&nbsp; 
                        <asp:RadioButtonList id="STUDENT_ENROLMENTELIGIBLE_FOR_FUNDING"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                    <th>&nbsp;<strong>DOCUMENTS LAST REVIEWED DATE</strong></th>
 
                    <td>&nbsp;<asp:TextBox id="STUDENT_ENROLMENTDOCS_LAST_REVIEWED_DATE" maxlength="8" Columns="8"	runat="server"/></td> 
                    <td><strong>&nbsp;NEW DOCUMENTS REQUIRED</strong></td> 
                    <td>&nbsp; 
                        <asp:RadioButtonList id="STUDENT_ENROLMENTNEW_DOCS_REQUIRED"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                    <th>&nbsp;</th>
 
                    <td>&nbsp;</td> 
                    <td><strong>&nbsp;REPORTING YEAR LEVEL</strong></td> 
                    <td>&nbsp; 
                        <select id="STUDENT_ENROLMENTYEAR_LEVEL_REPORTING"  runat="server"></select>
 </td>
                </tr>
 
                <tr class="Controls">
                    <th>&nbsp;LAST ALTERED BY / DATE</th>
 
                    <td>&nbsp;<asp:Literal id="STUDENT_ENROLMENTLAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_ENROLMENTLAST_ALTERED_DATE" runat="server"/></td> 
                    <td>&nbsp;</td> 
                    <td>&nbsp;</td>
                </tr>
 
                <tr class="Bottom">
                    <td colspan="4" align="right">&nbsp;<asp:Image id="STUDENT_ENROLMENTajaxBusy"  style="DISPLAY: none" AlternateText="updating" ImageUrl="images/ajax_loader.gif" runat="server"/>&nbsp;&nbsp; 
                        <input id='STUDENT_ENROLMENTButton_Insert' type="submit" class="Button" value="Add" OnServerClick='STUDENT_ENROLMENT_Insert' runat="server"/>
                        <input id='STUDENT_ENROLMENTButton_Update' type="submit" class="Button" value="Update" OnServerClick='STUDENT_ENROLMENT_Update' runat="server"/>
                        <input id='STUDENT_ENROLMENTButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_ENROLMENT_Cancel' runat="server"/></td>
                </tr>
            </table>
            
  <input id="STUDENT_ENROLMENTHidden_last_altered_by" type="hidden"  runat="server"/>
  
  <input id="STUDENT_ENROLMENTHidden_last_altered_date" type="hidden"  runat="server"/>
  
  <input id="STUDENT_ENROLMENThidden_yearlevel_original" type="hidden"  runat="server"/>
  
  <input id="STUDENT_ENROLMENThidden_yearlevel_original1" type="hidden"  runat="server"/>
  
  <input id="STUDENT_ENROLMENTHidden_PASTORAL_CARE_ID" type="hidden"  runat="server"/>
  
  <input id="STUDENT_ENROLMENTPASTORAL_ALLOC_BY" type="hidden"  runat="server"/>
  
  <input id="STUDENT_ENROLMENTPASTORAL_ALLOC_DATE" type="hidden"  runat="server"/>
  </td>
    </tr>
</table>
<!-- BEGINF PTAutocomplete PTAutocomplete1 
 Ticket : #232 --><!-- ENDF PTAutocomplete PTAutocomplete1 overflow-x:hidden; width:145px; height:150px;-->
<script type="text/javascript">
/*
created by : Vikas Baweja 
Creation date: 08-02-2010
Ticket : #232
Code Starts here 
*/
/* - removed as School Super now on Carer page - EA 13-May-2011
document.getElementById('STUDENT_ENROLMENTtxtSchool_Super_Name_choices').style.visibility='hidden';

function getPos (obj) {
        var output = document.getElementById('STUDENT_ENROLMENTtxtSchool_Super_Name_choices');
        var mytop=0, myleft=0;
        while( obj) {
                mytop+= obj.offsetTop;
                myleft+= obj.offsetLeft;
                obj= obj.offsetParent;
        }
        output.style.left = myleft;
        output.style.top = mytop+22;    
}
*/
/*

Code ends here 
*/
</script>



  </span>
  <br>

</form>
</body>
</html>

<!--End ASPX page-->

