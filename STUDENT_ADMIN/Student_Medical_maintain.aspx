<!--ASPX page @1-3B4A8744-->
    <%@ Page language="vb" CodeFile="Student_Medical_maintain.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_Medical_maintain.Student_Medical_maintainPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_Medical_maintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta http-equiv="content-type" content="text/html; charset=windows-1252"><meta http-equiv="X-UA-Compatible" content="IE=edge">


<title>Student Medical Maintain</title>


<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//DEL      // -------------------------
//DEL   // Just to double up on New Records
//DEL          result = true;
//DEL      if(theForm.STUDENT_MEDICAL_DETAILSANAPHYLAXIS_FLAG[0].checked ==true) {
//DEL          alert("Please ensure the Student Anaphylaxis Plan \n is in the Student Folder.")
//DEL          return true;
//DEL      }
//DEL      // -------------------------

//page_STUDENT_MEDICAL_DETAILS_ANAPHYLAXIS_FLAG_OnClick @22-2F3B2B28
function page_STUDENT_MEDICAL_DETAILS_ANAPHYLAXIS_FLAG_OnClick()
{
    var result;
//End page_STUDENT_MEDICAL_DETAILS_ANAPHYLAXIS_FLAG_OnClick

//Custom Code @30-2A29BDB7
    // -------------------------
    //9-Oct-2014|EA| unfuddle #666 add reminder when selecting "Y" for Anaphylaxis
    // needed to do '[0].checked ==true' instead of '.value == "Y"' as stupid IE wasn't returning 'Y'. Stupid IE.
    result = true;
    if(theForm.STUDENT_MEDICAL_DETAILSANAPHYLAXIS_FLAG[0].checked ==true) {
        alert("Please remember to scan the Student Anaphylaxis Plan \n and Save it to the Student Folder.")
        return true;
    }
    // -------------------------
//End Custom Code

//Close page_STUDENT_MEDICAL_DETAILS_ANAPHYLAXIS_FLAG_OnClick @22-BC33A33A
    return result;
}
//End Close page_STUDENT_MEDICAL_DETAILS_ANAPHYLAXIS_FLAG_OnClick

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//Custom Code @214-2A29BDB7
   // Set up the mechanism to clear selected radio buttons when clicked
   var radioButtonElements = document.querySelectorAll("input[type='radio']");
   for (var elementIndex = 0; elementIndex < radioButtonElements.length; elementIndex ++)
   {
      var element = radioButtonElements[elementIndex];
      if (element.checked)
         element.setAttribute("data-checked", "true");

      element.addEventListener("click", resetRadioButton, false);
   }
//End Custom Code

//Close page_OnLoad @1-BC33A33A
    return result;
}
//End Close page_OnLoad

//page_STUDENT_MEDICAL_DETAILS_Button_Cancel_OnClick @122-B5D387DF
function page_STUDENT_MEDICAL_DETAILS_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_MEDICAL_DETAILS_Button_Cancel_OnClick

//page_STUDENT_MEDICAL_DETAILS1_Button_Cancel_OnClick @58-FAADD279
function page_STUDENT_MEDICAL_DETAILS1_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_MEDICAL_DETAILS1_Button_Cancel_OnClick

//bind_events @1-D2ED962C
function bind_events() {
    addEventHandler("STUDENT_MEDICAL_DETAILSANAPHYLAXIS_FLAG","click",page_STUDENT_MEDICAL_DETAILS_ANAPHYLAXIS_FLAG_OnClick);
    addEventHandler("STUDENT_MEDICAL_DETAILSButton_Cancel","click",page_STUDENT_MEDICAL_DETAILS_Button_Cancel_OnClick);
    addEventHandler("STUDENT_MEDICAL_DETAILS1Button_Cancel","click",page_STUDENT_MEDICAL_DETAILS1_Button_Cancel_OnClick);
    page_OnLoad();
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
window.onload = bind_events;
//End Assign bind_events

//End CCS script
</script>
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/></p>
<p>

  <span id="STUDENT_MEDICAL_DETAILSHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Edit Student Medical Details </th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="STUDENT_MEDICAL_DETAILSError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="3"><asp:Label ID="STUDENT_MEDICAL_DETAILSErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th width="10%">&nbsp;</th>
 
            <th width="10%"><strong>STUDENT ID</strong></th>
 
            <td><asp:Literal id="STUDENT_MEDICAL_DETAILSSTUDENT_ID" runat="server"/> 
              <a id="STUDENT_MEDICAL_DETAILSLink_DiagnosisConfirmed" href="" title="open Diagnosis Confirmed" class="Button StrongBold" runat="server"  >Wellbeing Information</a></td>
          </tr>
 
          <tr class="Controls">
            <td colspan="3">
              <h2>&nbsp;Student Medical Information</h2>
              <em>&nbsp;(2016 Enrolments onwards)</em></td>
          </tr>
 
          <tr class="Controls">
            <td nowrap>&nbsp;</td> 
            <td nowrap><strong>Deaf or hearing Impaired?</strong></td> 
            <td>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSHEARING"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>Blind or Vision Impaired?</strong></td> 
            <td>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSVISION"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>Diagnosed with ASD/Aspergers?</strong></td> 
            <td>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSASDASPERGERS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>Intellectual Disability?</strong></td> 
            <td>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSINTELLECTUAL"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>Physical Disability?</strong></td> 
            <td>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSPHYSICAL"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>Severe Behavioural Disorder?</strong></td> 
            <td>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSBEHAVIOURAL"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>Severe Language Disorder?</strong></td> 
            <td>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSLANGUAGE"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>Mental Health Condition?</strong></td> 
            <td nowrap>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSMENTALHEALTH"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><br>
              &nbsp;If&nbsp;Yes:&nbsp;<asp:TextBox id="STUDENT_MEDICAL_DETAILSMENTALHEALTH_HISTORY" Columns="40"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>History of Allergies?</strong></td> 
            <td nowrap>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSHASALLERGYHISTORY"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><br>
              &nbsp;If&nbsp;Yes:&nbsp;<asp:TextBox id="STUDENT_MEDICAL_DETAILSALLERGYHISTORY" Columns="40"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>Diagnosed as at Risk of Anaphylaxis?</strong></td> 
            <td>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSANAPHYLAXIS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><br>
              <em>if Yes - load Individual Anaphylaxis Management Plan to Student Folder</em></td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>Student Diagnosed with Asthma?</strong> <em>(2020)</em><br>
              <em>If Yes - get copy of Medical Management Plan</em></td> 
            <td>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSDIAGNOSED_ASTHMA"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><br>
              <em>Management Plan loaded to student folder? 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSMANAGE_PLAN_ASTHMA"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></em> </td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>Student Diagnosed with Diabetes?</strong> <em>(2020)</em><br>
              <em>If Yes - get copy of Medical Management Plan</em></td> 
            <td>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSDIAGNOSED_DIABETES"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><br>
              <em>Management Plan loaded to student folder? 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSMANAGE_PLAN_DIABETES"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></em> </td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>Student Diagnosed with Epilepsy?</strong> <em>(2020)</em><br>
              <em>If Yes - get copy of Medical Management Plan</em></td> 
            <td>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSDIAGNOSED_EPILEPSY"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><br>
              <em>Management Plan loaded to student folder? 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSMANAGE_PLAN_EPILEPSY"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></em> </td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>Diagnosed with any other condition?</strong></td> 
            <td nowrap>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSHASOTHERCONDITIONS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><br>
              &nbsp;If&nbsp;Yes:&nbsp;<asp:TextBox id="STUDENT_MEDICAL_DETAILSOTHERCONDITIONS" Columns="40"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>Other Medical Issues VSV should be aware of?</strong></td> 
            <td>&nbsp; 
<asp:TextBox id="STUDENT_MEDICAL_DETAILSOTHERMEDICALISSUES" rows="3" Columns="40" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
            <td colspan="3">
              <h2>&nbsp;Student (Parent) Assessment</h2>
            </td>
          </tr>
 
          <tr class="Controls">
            <td colspan="3"><strong>Received Support from these Programs or Services?</strong> <em>(2018)</em></td>
          </tr>
 
          <tr class="Controls">
            <td colspan="3">
              <asp:CheckBoxList id="STUDENT_MEDICAL_DETAILScbRECEIVED_SUPPORT_PROGRAMS_SERVICES" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td>If Other Support Program:</td> 
            <td><asp:TextBox id="STUDENT_MEDICAL_DETAILSRECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER" maxlength="50" Columns="35"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td colspan="3">
              <h2>&nbsp;School Referral</h2>
            </td>
          </tr>
 
          <tr class="Controls">
            <td colspan="3"><strong>DI (Disability Inclusion)</strong></td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>Assessed</strong> for DI (Disability Inclusion) Funding</td> 
            <td>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSDI_ASSESSED"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>Approved for DI (Disability Inclusion) Funding</strong></td> 
            <td>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSDI_APPROVED"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td colspan="3"><strong>PSD Eligibility</strong></td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>Assessed</strong> for funding through DET Program for Students with Disabilities?</td> 
            <td>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSPSD_FUNDING_ASSESSED"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>Approved</strong> for funding through DET Program for Students with Disabilities?</td> 
            <td>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSPSD_FUNDING_ELIGIBLE"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td colspan="3"><strong>PSD Category</strong> <em>(may select more than one) (2019)</em></td>
          </tr>
 
          <tr class="Controls">
            <td colspan="3">
              <asp:CheckBoxList id="STUDENT_MEDICAL_DETAILScbPSD_FUNDING_CATEGORY" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>Level of PSD funding approved:</strong> <em>(2020)</em></td> 
            <td>
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSPSD_FUNDING_LEVEL"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td>&nbsp;</td> 
            <td><strong>PSD Details / level of funding if approved?</strong></td> 
            <td>&nbsp; 
<asp:TextBox id="STUDENT_MEDICAL_DETAILSPSD_FUNDING_OTHER" rows="3" Columns="30" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
            <th colspan="3"><strong>NCCD Eligibility</strong></th>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <th>
            <p>Approved for funding through the Commonwealth<br>
            NCCD?</p>
            </th>
 
            <td>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSNCCD_FUNDING_ELIGIBLE"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <th>NCCD Category</th>
 
            <td>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSNCCD_FUNDING_CATEGORY"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <th>Level of NCCD funding approved</th>
 
            <td>&nbsp; 
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSNCCD_FUNDING_LEVEL"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th colspan="3"><br>
            <strong>Below - Not used 2016 Onwards - kept for history</strong></th>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <th><em>Allergies?</em></th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSALLERGIES_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;<em>(new for 2010 enrolments; if Yes, check Enrolment form)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <th><em>Anaphylaxis?</em></th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILSANAPHYLAXIS_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;<em>(If 'Yes', scan Anaphylaxis Plan to Student Folder)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <th><em>Diagnosed Condition </em><br>
            <em>use 'ASD/Aspergers' for any new Autism Spectrum <br>
            Disorder or Aspergers diagnosed conditions</em></th>
 
            <td>&nbsp; 
              <select id="STUDENT_MEDICAL_DETAILSlbDiagnosedConditions"  runat="server"></select>
 <br>
              <em>(updated for 2014&nbsp;enrolments;)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <th>&nbsp;</th>
 
            <th>&nbsp;</th>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <th>LAST ALTERED BY / DATE</th>
 
            <td><asp:Literal id="STUDENT_MEDICAL_DETAILSLAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_MEDICAL_DETAILSLAST_ALTERED_DATE" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="3" align="right">
              <input id='STUDENT_MEDICAL_DETAILSButton_Update' type="submit" class="Button" value="Update" OnServerClick='STUDENT_MEDICAL_DETAILS_Update' runat="server"/>&nbsp; &nbsp;&nbsp; &nbsp; 
              <input id='STUDENT_MEDICAL_DETAILSButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_MEDICAL_DETAILS_Cancel' runat="server"/></td>
          </tr>
        </table>
        
  <input id="STUDENT_MEDICAL_DETAILShidden_LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="STUDENT_MEDICAL_DETAILShidden_LAST_ALTERED_DATE" type="hidden"  runat="server"/>
  
  <input id="STUDENT_MEDICAL_DETAILShidden_STUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="STUDENT_MEDICAL_DETAILShidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES" type="hidden"  runat="server"/>
  
  <input id="STUDENT_MEDICAL_DETAILShidden_PSD_FUNDING_CATEGORY" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>



  </span>
  </p>
<p>

  <span id="STUDENT_MEDICAL_DETAILS1Holder" runat="server">
    


  <table class="MainTable" cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Edit Practitioner Referral</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="STUDENT_MEDICAL_DETAILS1Error" visible="False" runat="server">
  
          <tr id="ErrorBlock" class="Error">
            <td colspan="2"><asp:Label ID="STUDENT_MEDICAL_DETAILS1ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>Class attendance recommendation</th>
 
            <td>
              <asp:CheckBoxList id="STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_CLASS_ATTENDANCE" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Workload recommendation</th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_WORKLOAD"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Practitioner organisation</th>
 
            <td><asp:TextBox id="STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGANISATION" maxlength="50" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Discipline</th>
 
            <td>
              <select id="STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISCIPLINE"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th>Discipline if Other</th>
 
            <td><asp:TextBox id="STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISCIPLINE_OTHER" maxlength="50" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Organisation type</th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGTYPE"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>If 'Other': <asp:TextBox id="STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGTYPE_OTHER" maxlength="50" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Primary presenting issues</th>
 
            <td>
              <asp:CheckBoxList id="STUDENT_MEDICAL_DETAILS1PRACTITIONER_PRIMARY_ISSUES" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Primary pres. issues if Other</th>
 
            <td><asp:TextBox id="STUDENT_MEDICAL_DETAILS1PRACTITIONER_PRIMARY_OTHER" maxlength="50" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Disabilities</th>
 
            <td>
              <asp:CheckBoxList id="STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISABILITIES" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Disability details</th>
 
            <td>
<asp:TextBox id="STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISABILITY_DETAILS" rows="3" Columns="40" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
            <th>Parent/carer capable of meeting<br>
            supervisor requirements</th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_CARER_AS_SUPERVISOR"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Last altered by / date</th>
 
            <td><asp:Literal id="STUDENT_MEDICAL_DETAILS1lblLAST_MODIFIED_BY" runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_MEDICAL_DETAILS1lblLAST_MODIFIED_DATE" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td style="TEXT-ALIGN: right" colspan="2">
              <input id='STUDENT_MEDICAL_DETAILS1Button_Update' type="submit" class="Button" value="Update" OnServerClick='STUDENT_MEDICAL_DETAILS1_Update' runat="server"/>
              <input id='STUDENT_MEDICAL_DETAILS1Button_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_MEDICAL_DETAILS1_Cancel' runat="server"/>
  <input id="STUDENT_MEDICAL_DETAILS1PRACTITIONER_LAST_MODIFIED_BY" type="hidden"  runat="server"/>
  
  <input id="STUDENT_MEDICAL_DETAILS1PRACTITIONER_LAST_MODIFIED_DATE" type="hidden"  runat="server"/>
  </td>
          </tr>
        </table>
        
  <input id="STUDENT_MEDICAL_DETAILS1Hidden_PRIMARY_ISSUES" type="hidden"  runat="server"/>
  
  <input id="STUDENT_MEDICAL_DETAILS1Hidden_DISABILITIES" type="hidden"  runat="server"/>
  
  <input id="STUDENT_MEDICAL_DETAILS1Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>
  <script type="text/javascript">

   function resetRadioButton(event)
   {
       var buttons = document.getElementsByName(event.currentTarget.name);
       for (var elementIndex = 0; elementIndex < buttons.length; elementIndex ++)
       {
           if (buttons[elementIndex].checked)
           {
               if (buttons[elementIndex].getAttribute("data-checked") === "true")
               {
                   buttons[elementIndex].checked = false;
                   buttons[elementIndex].removeAttribute("data-checked");
                   break;
               }
               else
                   buttons[elementIndex].setAttribute("data-checked", "true");
           }
           else
               buttons[elementIndex].removeAttribute("data-checked");
       }
   }

</script>



  </span>
  <br>
</p>
<p><br>
</p>

</form>
</body>
</html>

<!--End ASPX page-->

