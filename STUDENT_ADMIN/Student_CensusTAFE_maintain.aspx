<!--ASPX page @1-F38BFD41-->
    <%@ Page language="vb" CodeFile="Student_CensusTAFE_maintain.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_CensusTAFE_maintain.Student_CensusTAFE_maintainPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_CensusTAFE_maintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Census TAFE Maintain</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Include User Scripts @1-59AE36A3
</script>
<script language="JavaScript" src="js/pt/prototype.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/pt/scriptaculous.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/pt/controls.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/Services.js" type="text/javascript" charset="windows-1252"></script>
<link rel="stylesheet" type="text/css" href="Student_CensusTAFE_maintainSTUDENT_CENSUS_DATASCHOOL_NAME_style.css">
<script language="JavaScript" type="text/javascript">
//End Include User Scripts

//page_STUDENT_CENSUS_DATA_Button_Cancel_OnClick @4-C43C1CAE
function page_STUDENT_CENSUS_DATA_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_CENSUS_DATA_Button_Cancel_OnClick

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

  <span id="STUDENT_CENSUS_DATAHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" width="70%" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Edit Student TAFE Details</th>
 
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
              &nbsp;<asp:Literal id="STUDENT_CENSUS_DATASTUDENT_ID" runat="server"/>&nbsp;&nbsp; go to <a id="STUDENT_CENSUS_DATALink_gotoCensusPage" href="" class="Button" style="PADDING-BOTTOM: 10px; PADDING-TOP: 10px; PADDING-LEFT: 10px; PADDING-RIGHT: 10px" runat="server"  >Normal Census page</a></td>
          </tr>
 
          <tr class="Controls">
            <th>ENGLISH PROFICIENCY&nbsp;</th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_CENSUS_DATARadioButton_EnglishProficiency"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><strong>Disability</strong></th>
 
            <td>
              <asp:CheckBoxList id="STUDENT_CENSUS_DATACheckBoxList_Disability" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Disability 'Other' description&nbsp;</th>
 
            <td><asp:TextBox id="STUDENT_CENSUS_DATADISABILITY_OTHER_TEXT" maxlength="50" Columns="40"	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>DISABILITY ID</th>
 
            <td><asp:TextBox id="STUDENT_CENSUS_DATADISABILITY_ID" maxlength="6" Columns="6"	runat="server"/>&nbsp;<asp:Literal id="STUDENT_CENSUS_DATAlblCheckDisability" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th colspan="2">
            <p><strong></strong>&nbsp;</p>
 
            <p><strong>Schooling </strong></p>
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
            <th>PREVIOUS SCHOOL ID</th>
 
            <td><asp:TextBox id="STUDENT_CENSUS_DATAPREVIOUS_SCHOOL_ID" maxlength="10" Columns="9"	runat="server"/>&nbsp;<asp:Literal id="STUDENT_CENSUS_DATAlblPREVIOUS_SCHOOL_NAME" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>DATE LAST ATTENDED SCHOOL&nbsp;</th>
 
            <td><asp:TextBox id="STUDENT_CENSUS_DATADATE_LAST_ATTENDED_SCHOOL" maxlength="10" Columns="12"	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>Level of <em>highest</em>&nbsp;COMPLETED school level</th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_CENSUS_DATAHIGHEST_SCHOOL_LEVEL"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th colspan="2">
            <p><strong></strong>&nbsp;</p>
 
            <p><strong>Prior Qualifications&nbsp;</strong></p>
            </th>
          </tr>
 
          <tr class="Controls">
            <th>Successfully completed any of the following</th>
 
            <td>
              <asp:CheckBoxList id="STUDENT_CENSUS_DATACheckBoxList_PriorQualifications" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>Prior Qualifications 'Other' description&nbsp;&nbsp;</th>
 
            <td><asp:TextBox id="STUDENT_CENSUS_DATAPRIORQUALIFICATIONS_OTHER_TEXT" maxlength="50" Columns="40"	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><strong>Current Employment Status</strong>&nbsp;&nbsp;</th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_CENSUS_DATARadioButton_Employment_Status"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th colspan="2">
            <p>&nbsp;</p>
            </th>
          </tr>
 
          <tr class="Controls">
            <th><strong>Reason for Study</strong>&nbsp;&nbsp;</th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_CENSUS_DATARadioButton_Reason_for_Study"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY / DATE (entire form)</th>
 
            <td><asp:Literal id="STUDENT_CENSUS_DATALAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_CENSUS_DATALAST_ALTERED_DATE" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">
              <input id='STUDENT_CENSUS_DATAButton_Update' type="submit" class="Button" value="Update" OnServerClick='STUDENT_CENSUS_DATA_Update' runat="server"/>
              <input id='STUDENT_CENSUS_DATAButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_CENSUS_DATA_Cancel' runat="server"/></td>
          </tr>
        </table>
        
  <input id="STUDENT_CENSUS_DATAHidden_last_altered_by" type="hidden"  runat="server"/>
  
  <input id="STUDENT_CENSUS_DATAHidden_last_altered_date" type="hidden"  runat="server"/>
  
  <input id="STUDENT_CENSUS_DATAHidden_DisabilityList" type="hidden"  runat="server"/>
  
  <input id="STUDENT_CENSUS_DATAHidden_PriorQualificationsList" type="hidden"  runat="server"/>
  
        <p></p>
      </td>
    </tr>
  </table>



  </span>
  <br>

</form>
</body>
</html>

<!--End ASPX page-->

