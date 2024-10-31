<!--ASPX page @1-E6F7BFB1-->
    <%@ Page language="vb" CodeFile="Student_Profile.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_Profile.Student_ProfilePage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_Profile" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="StudentNamePlate" Src="StudentNamePlate.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 5.1.0.18696"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Profile</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
<style type="text/css">
<!--
.instructions  { font-size: 12px; font-style: italic; }
.processtips  { display:none; }
.processtips::before { content: "Tip!"; }
.processtips:hover  { display:block; }
.errormsg  { font-size: 120%; background-color: #F00; color:#FFF; font-weight: bold ;margin: 2px }

-->
</style>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p align="center">

	<asp:PlaceHolder id="Panel_MenuStudentMaintain" Visible="false" runat="server">
	<DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/>
	</asp:PlaceHolder>
	</p>
<p align="center"><a id="Link_Backtosummary" href="" class="Button" runat="server"  >Back to Summary</a></p>
<p align="center"><DECV_PROD2007:StudentNamePlate id="StudentNamePlate" runat="server"/></p>
<p align="center">

  <span id="STUDENT_PROFILE1Holder" runat="server">
    


  <table class="MainTable" cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Add/Edit STUDENT PROFILE </th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="STUDENT_PROFILE1Error" visible="False" runat="server">
  
          <tr id="STUDENT_PROFILE1ErrorBlock" class="Error">
            <td colspan="2"><asp:Label ID="STUDENT_PROFILE1ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>STUDENT ID / ENROL YEAR</th>
 
            <td>
  <input id="STUDENT_PROFILE1STUDENT_ID" type="hidden"  runat="server"/>
  <asp:Literal id="STUDENT_PROFILE1lblStudentID" runat="server"/> / 
  <input id="STUDENT_PROFILE1ENROLMENT_YEAR" type="hidden"  runat="server"/>
  <asp:Literal id="STUDENT_PROFILE1lblEnrolYear" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY / WHEN</th>
 
            <td><asp:Literal id="STUDENT_PROFILE1LAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_PROFILE1LAST_ALTERED_DATE" runat="server"/>
  <input id="STUDENT_PROFILE1hidden_LastUpdatedBy" type="hidden"  runat="server"/>
  
  <input id="STUDENT_PROFILE1hidden_LastUpdatedWhen" type="hidden"  runat="server"/>
  </td>
          </tr>
 
          <tr class="Controls">
            <th><input type="button" onclick="restore_last_saved_values('form');" id="btnRestore" value="Retrieve Saved Data" name="btnRestore"/><span style="COLOR: #fff; DISPLAY: none; BACKGROUND-COLOR: #468847">Data saved</span> </th>
 
            <td></td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p><a id="STUDENT_PROFILE1Link1" href="" runat="server"  >Early Assessment Checklist</a></p>
            </th>
 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;Risk Factors and Actions on Early Assessment Checklist Checked?</th>
 
            <td>&nbsp;<asp:CheckBox id="STUDENT_PROFILE1cbRiskFactors" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;VSV Enrolment File Checked?</th>
 
            <td>&nbsp;<asp:CheckBox id="STUDENT_PROFILE1cbENROL_FILE_CHECKED" runat="server"/>&nbsp;<em>(files to be checked annually for returning students)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;Confidential Documents Checked?</th>
 
            <td>&nbsp;<asp:CheckBox id="STUDENT_PROFILE1cbConfidentialDocuments" runat="server"/>&nbsp;(consult with wellbeing or inclusion)</td>
          </tr>
 
          <tr class="Controls">
            <th>Check Class Attendance Recommendation and Worload Recommendation on&nbsp;<a id="STUDENT_PROFILE1Link2" href="" runat="server"  >Student Medical Details</a></th>
 
            <td></td>
          </tr>
 
          <tr class="Controls">
            <th>
            <h4>&nbsp;PERSONAL INFORMATION</h4>
            </th>
 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>BACKGROUND INFORMATION - REASON FOR REFERRAL&nbsp; 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_BackgroundInfo" runat="server"/> 
            </div>
 
            <div class="instructions">
              Include information from Enrolment Application forms,<br>
              Intake Interview and Ongoing Contact.<br>
            </div>
 
            <div class="processtips">
              Other relevant information including family structure <br>
              (siblings at VSV), health status, social supports etc 
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1BACKGROUND_INFO" rows="5" Columns="50" maxysize="400" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls" style="DISPLAY: none">
            <!-- Reason has been removed from student profile. We might need it back this year so I've just hidden it. -->
            <th>REASONS FOR ENROLLING AT VSV 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_ReasonsEnrol" runat="server"/> 
            </div>
 
            <div class="instructions">
              Please use Enrolment Application forms <br>
              &amp;/or information from student and parent/carer.<br>
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1ENROL_REASONS" rows="5" Columns="50" maxysize="400" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
            <th>STUDENT WELLBEING &amp; INCLUSION 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_StudentWellbeing" runat="server"/> 
            </div>
 
            <div class="instructions">
              Refer to database comments and recommendations for this year.<br>
            </div>
 
            <div class="processtips">
              Detail main factors relating to mental health<br>
              ,wellbeing and inclusion concerns (main issues; <br>
              home supports, professional supports, changes<br>
              in circumstances 
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1WELLBEING_INCLUSION_CONCERNS" rows="3" Columns="50" maxysize="400" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
            <th>EXPECTATIONS TO RETURN TO MAINSTREAM SCHOOL 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_ReturnMainstream" runat="server"/> 
            </div>
 
            <div class="instructions">
              Details of help required 
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1EXPECT_RETURN_TO_SCHOOL" rows="3" Columns="50" maxysize="400" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
            <th>RETURNING STUDENT? 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_ReturningStudent" runat="server"/> 
            </div>
            </th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_PROFILE1RETURN_STUDENT"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Previously known to Student Wellbeing? * 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_StudentWellbeing2" runat="server"/> 
            </div>
            </th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_PROFILE1KNOWN_WELLBEING"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Previously known to Student Inclusion? * 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_StudentInclusion" runat="server"/> 
            </div>
            </th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_PROFILE1KNOWN_INCLUSION"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Previously known to Engagement? * 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_PrevPathways" runat="server"/> 
            </div>
            </th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_PROFILE1KNOWN_PATHWAYS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp; </th>
 
            <td>&nbsp; 
              <div class="instructions">
                *If answered Yes to Wellbeing, Inclusion or Engagement, consult with personnel from relevant area<br>
              </div>
            </td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p>SUPPORTING DOCUMENTS CHECKED 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_SupportDocs" runat="server"/> 
            </div>
 
            <p></p>
 
            <p><em>(complete annually for returning students)</em></p>
            </th>
 
            <td>
              <p><asp:CheckBox id="STUDENT_PROFILE1SUPPORT_DOCS_AGENCY_REFERRAL" runat="server"/>&nbsp;Practitioner Agency Referral Form<br>
              <br>
              <asp:CheckBox id="STUDENT_PROFILE1SUPPORT_DOCS_SCHOOL_REFERRAL" runat="server"/>&nbsp;School Referral Form (new students only)&nbsp;<br>
              <br>
              <asp:CheckBox id="STUDENT_PROFILE1SUPPORT_DOCS_YOUNG_ADULT" runat="server"/>&nbsp;Young Adult Referral Form </p>
 
              <p><asp:CheckBox id="STUDENT_PROFILE1SUPPORT_DOCS_YOUNG_ADULT1" runat="server"/>&nbsp;Sports/Performance Form<br>
              <br>
              Other <asp:TextBox id="STUDENT_PROFILE1SUPPORT_DOCS_OTHER" maxlength="50" Columns="35"	runat="server"/></p>
            </td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p>KEY PROFESSIONAL SUPPORTS<br>
            NAME and CONTACT DETAILS 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_KeyProfSupports" runat="server"/> 
            </div>
 
            <p></p>
 
            <p><em>(complete annually for returning students)</em></p>
            </th>
 
            <td>
              <p><strong>Support 1</strong><br>
              NAME <asp:TextBox id="STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_NAME" maxlength="50" Columns="50"	runat="server"/></p>
 
              <p>Role<asp:TextBox id="STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_ROLE" maxlength="50" Columns="50"	runat="server"/><br>
              CONTACT <asp:TextBox id="STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_CONTACT" maxlength="50" Columns="50"	runat="server"/><br>
              <strong>Support 2</strong><br>
              NAME <asp:TextBox id="STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_NAME2" maxlength="50" Columns="50"	runat="server"/>&nbsp;</p>
 
              <p>Role<asp:TextBox id="STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_ROLE2" maxlength="50" Columns="50"	runat="server"/><br>
              CONTACT <asp:TextBox id="STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_CONTACT2" maxlength="50" Columns="50"	runat="server"/></p>
 
              <p><strong>Support 3</strong><br>
              NAME <asp:TextBox id="STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_NAME3" maxlength="50" Columns="50"	runat="server"/></p>
 
              <p>Role<asp:TextBox id="STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_ROLE3" maxlength="50" Columns="50"	runat="server"/><br>
              CONTACT <asp:TextBox id="STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_CONTACT3" maxlength="50" Columns="50"	runat="server"/></p>
            </td>
          </tr>
 
          <tr class="Controls">
            <td style="TEXT-ALIGN: right" colspan="2">
              <input id='STUDENT_PROFILE1Button_Insert1' type="submit" class="Button" value="Add Profile" OnServerClick='STUDENT_PROFILE1_Insert' runat="server"/>
              <input id='STUDENT_PROFILE1Button_Update1' type="submit" class="Button" value="Update" OnServerClick='STUDENT_PROFILE1_Update' runat="server"/>
              <input id='STUDENT_PROFILE1Button_Cancel1' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_PROFILE1_Cancel' runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>
            <h4>ENGAGEMENT</h4>
            <br>
            HOBBIES/INTERESTS 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_HobbiesInterests" runat="server"/> 
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1ENGAGEMENT_HOBBIES_INTERESTS" rows="3" Columns="50" maxysize="400" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
            <th>
            <h4>&nbsp;COMMUNICATION</h4>
            </th>
 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p>An Intake Interview&nbsp;has been undertaken? 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_CommsVisit" runat="server"/> 
            </div>
 
            <p></p>
 
            <p><em>(complete annually for returning students)</em></p>
            </th>
 
            <td>
              <p>
              <asp:RadioButtonList id="STUDENT_PROFILE1COMM_VISIT_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><br>
              <br>
              Visit Date (if done): <asp:TextBox id="STUDENT_PROFILE1COMM_VISIT_DATE" maxlength="10" Columns="10"	runat="server"/>&nbsp;<em>dd/mm/yyyy format</em></p>
 
              <p>&nbsp; 
              <asp:CheckBoxList id="STUDENT_PROFILE1COMM_INTAKE_CONTACT_TYPE_MULTI" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></p>
            </td>
          </tr>
 
          <tr class="Controls">
            <th>COMMUNICATION PLAN 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_ContactType" runat="server"/> 
            </div>
 
            <p><em>(Note any specific communication issues)</em></p>
            </th>
 
            <td>
              <div class="instructions">
                Frequency, timing and method of contact negotiated with student and parent/carer (fortnightly minimum requirement) and documented 
              </div>
              <asp:CheckBoxList id="STUDENT_PROFILE1COMM_CONTACT_TYPE" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><br>
              <br>
              Other Details 
<asp:TextBox id="STUDENT_PROFILE1COMM_CONTACT_TYPE_OTHER" rows="5" Columns="50" maxysize="200" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
            <th>Student willing to communicate over phone<br>
            with teachers?</th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_PROFILE1COMM_PHONE_CONTACT"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>
            <h4>&nbsp;PARENT / CARER /&nbsp;SUPERVISOR&nbsp;INSIGHTS</h4>
            </th>
 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>Is there any critical information a teacher should know before contacting a parent, carer or supervisor 
             
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_CarerContactMethod" runat="server"/> 
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1CARER_CONTACT_METHOD" Columns="50" maxysize="400" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls" style="display: none;">
            <th>Who will be supervising the student during the day? 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_SupervisorName" runat="server"/> 
            </div>
            </th>
 
            <td><asp:TextBox id="STUDENT_PROFILE1CARER_SUPERVISOR_NAME" maxlength="50" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Controls" style="display: none;">
            <th>Are they aware of the role of the supervisor? 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_SupervisorRole" runat="server"/> 
            </div>
            </th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_PROFILE1CARER_SUPERVISOR_ROLE"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls" style="display: none;">
            <th>ADDITIONAL CARER INFORMATION 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_AddCarerInfo" runat="server"/> 
            </div>
            </th>
 
            <td><asp:TextBox id="STUDENT_PROFILE1CARER_ADDITIONAL" maxlength="100" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>
            <h4>&nbsp;ORGANISATION</h4>
            </th>
 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>Workspace 
            <div class="instructions">
              Where/When does the student usually complete their VSV learning program? 
            </div>
 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_Workspace" runat="server"/> 
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1ORGANISATION_WHENWHERE" Columns="50" maxysize="200" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
            <th>Timetable in Student Folder?</th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_PROFILE1ORGANISATION_TIMETABLE"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Hardware to do school work 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_OrgHardware" runat="server"/> 
            </div>
            </th>
 
            <td>
              <select id="STUDENT_PROFILE1ORGANISATION_HARDWARE"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th>Access to Internet? 
            <div class="instructions">
              How/where will the student access the internet 
            </div>
 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_OrgInternet" runat="server"/> 
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1ORGANISATION_ACCESS_INTERNET" Columns="50" maxysize="200" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
            <th>PREVIOUS SCHOOLS 
            <div class="instructions">
              include information regarding school history, <br>
              previous schools including VSV 
            </div>
 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_OrgPrevSchools" runat="server"/> 
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1ORGANISATION_PREVIOUS_SCHOOL" rows="4" Columns="50" maxysize="200" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
            <th>ACADEMIC HISTORY 
            <div class="instructions">
              strengths/weaknesses, academic progress including <br>
              teacher judgement, PAT assessments, NAPLAN data if available 
            </div>
 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_OrgAcademic" runat="server"/> 
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1ORGANISATION_ACADEMIC_HISTORY" rows="5" Columns="50" maxysize="400" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls" style="display: none;">
            <th>Copy of most recent report added to Student Folder?</th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_PROFILE1ORGANISATION_RECENTREPORT_FILED"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td style="TEXT-ALIGN: right" colspan="2">
              <input id='STUDENT_PROFILE1Button_Insert2' type="submit" class="Button" value="Add Profile" OnServerClick='STUDENT_PROFILE1_Insert' runat="server"/>
              <input id='STUDENT_PROFILE1Button_Update2' type="submit" class="Button" value="Update" OnServerClick='STUDENT_PROFILE1_Update' runat="server"/>
              <input id='STUDENT_PROFILE1Button_Cancel2' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_PROFILE1_Cancel' runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp; 
            <h4>LAUNCHPAD</h4>
            </th>
 
            <td>&nbsp; 
              <p><em>(Rest of Profile - complete annually for returning students)</em></p>
            </td>
          </tr>
 
          <tr class="Controls">
            <th>LAUNCH PAD COMPLETED (Years 3 - 10) 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_LPDone" runat="server"/> 
            </div>
            </th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_PROFILE1LAUNCH_PAD_DONE"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><br>
              <br>
              COMPLETED DATE <asp:TextBox id="STUDENT_PROFILE1LAUNCH_PAD_DONE_DATE" maxlength="10" Columns="10"	runat="server"/>&nbsp;<em>dd/mm/yyyy</em></td>
          </tr>
 
          <tr class="Controls" style="DISPLAY: none">
            <th colspan="2">STUDENT ASSESSMENT DATA <br>
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_AssessData" runat="server"/> 
            </div>
 
            <table class="Record" cellspacing="0" cellpadding="0" width="100%">
              <tr>
                <td>&nbsp;</td> 
                <td>&nbsp;<strong>Launch Pad</strong></td> 
                <td><strong>&nbsp;ReLaunch</strong></td>
              </tr>
 
              <tr>
                <td>&nbsp;English</td> 
                <td>&nbsp;<asp:TextBox id="STUDENT_PROFILE1ASSESS_ENGLANG_LP" maxlength="10" Columns="5"	runat="server"/></td> 
                <td>&nbsp;<asp:TextBox id="STUDENT_PROFILE1ASSESS_ENGLANG_RL" maxlength="10" Columns="5"	runat="server"/></td>
              </tr>
 
              <tr>
                <td>&nbsp;Mathematics</td> 
                <td>&nbsp;<asp:TextBox id="STUDENT_PROFILE1ASSESS_MATH_LP" maxlength="10" Columns="5"	runat="server"/></td> 
                <td>&nbsp;<asp:TextBox id="STUDENT_PROFILE1ASSESS_MATH_RL" maxlength="10" Columns="5"	runat="server"/></td>
              </tr>
 
              <tr>
                <td>&nbsp;PAT&nbsp;Science</td> 
                <td>&nbsp;<asp:TextBox id="STUDENT_PROFILE1ASSESS_PATSCIENCE_LP" maxlength="10" Columns="5"	runat="server"/></td> 
                <td>&nbsp;<asp:TextBox id="STUDENT_PROFILE1ASSESS_PATSCIENCE_RL" maxlength="10" Columns="5"	runat="server"/></td>
              </tr>
            </table>
            </th>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp; 
            <h4>VSV LEARNING PROGRAM</h4>
            </th>
 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls" style="display: none;">
            <th>PLP OR MANDATED IEP</th>
 
            <td>
  <input id="STUDENT_PROFILE1LEARNING_PROGRAM" type="hidden"  runat="server"/>
  <asp:Literal id="STUDENT_PROFILE1lblLearningProgram" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>ADDITIONAL DETAILS 
            <div class="instructions">
              eg: reduced subject load, Literacy and Numeracy Support, other reasonable adjustments. 
            </div>
 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_LearnDetails" runat="server"/> 
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1LEARNING_PROGRAM_DETAILS" rows="3" Columns="50" maxysize="200" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls" style="DISPLAY: none">
            <th>LEARNING PROGRAM CONSULTATION</th>
 
            <td>
              <asp:CheckBoxList id="STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>LEARNING AND/OR ENGAGEMENT GOALS 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_LearnGoals" runat="server"/> 
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1LEARNING_GOALS" rows="5" Columns="50" maxysize="800" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
            <th>SPECIAL PROVISION? 
            <div class="instructions">
              See special Provision Policy. Prior discussion<br>
              with LT Engagement and/or Student Coordinator required 
            </div>
            </th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_PROFILE1SPECIAL_PROVISION_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>SPECIAL PROVISION DETAILS 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_SpecialProvision" runat="server"/> 
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1SPECIAL_PROVISION_DETAILS" rows="3" Columns="50" maxysize="400" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp; 
            <h4>PATHWAYS</h4>
            </th>
 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>CAREER ACTION PLAN (7-12) * 
            <div class="instructions">
              Student has a Career Action Plan (obtain copy)<br>
              if No then start Career Action Plan 
            </div>
            </th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_PROFILE1PATHWAYS_CAREER_PLAN_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>PATHWAYS INFORMATION 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_Goals" runat="server"/> 
            </div>
 
            <div class="instructions">
              Includes information related to work experience, VET and part time employment. 
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1PATHWAYS_CAREER_GOALS" rows="3" Columns="50" maxysize="800" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls" style="DISPLAY: none">
            <th>Future Career Goals discussed (Mid-year) 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_GoalsMidyear" runat="server"/> 
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1PATHWAYS_CAREER_GOALS_MIDYEAR" rows="3" Columns="50" maxysize="400" TextMode="MultiLine"	runat="server"/>
<br>
              <br>
              Date: <asp:TextBox id="STUDENT_PROFILE1PATHWAYS_CAREER_GOALS_MIDYEAR_DATE" maxlength="10" Columns="10"	runat="server"/>&nbsp;<em>dd/mm/yyyy</em></td>
          </tr>
 
          <tr class="Controls" style="DISPLAY: none">
            <th>Student Interested in Work Experience (Year 9/10) 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_WorkExp910" runat="server"/> 
            </div>
            </th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_PROFILE1PATHWAYS_WORKEXP_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><br>
              <br>
              If Yes, record details:<br>
              
<asp:TextBox id="STUDENT_PROFILE1PATHWAYS_WORKEXP_DETAILS" rows="3" Columns="50" maxysize="400" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls" style="DISPLAY: none">
            <th>Details of Part Time job/s: 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_PartTimeJobs" runat="server"/> 
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1PATHWAYS_PARTTIMEJOBS" rows="3" Columns="50" maxysize="400" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls" style="DISPLAY: none">
            <th>End of Year Future Intentions Discussion (all Students) 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_EndYearDisc" runat="server"/> 
            </div>
            </th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><br>
              <br>
              Date:<asp:TextBox id="STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_DATE" maxlength="10" Columns="10"	runat="server"/>&nbsp;<em>dd/mm/yyyy</em></td>
          </tr>
 
          <tr class="Controls" style="DISPLAY: none">
            <th>End of Year Future Intentions Discussion logged in Database 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_EndYearLogged" runat="server"/> 
            </div>
            </th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><br>
              <br>
              Date:<asp:TextBox id="STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE" maxlength="10" Columns="10"	runat="server"/>&nbsp;<em>dd/mm/yyyy</em></td>
          </tr>
 
          <tr class="Controls" style="DISPLAY: none">
            <th>&nbsp; 
            <h4>REVIEW OF PROGRESS</h4>
            </th>
 
            <td>&nbsp; 
              <div class="instructions">
                Learning Programs and Career Action Plans should be monitored<br>
                and reviewed once per semester 
              </div>
            </td>
          </tr>
 
          <tr class="Controls" style="DISPLAY: none">
            <th>END OF SEMESTER 1 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_ProgressSem1" runat="server"/> 
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM1" rows="3" Columns="50" maxysize="400" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls" style="DISPLAY: none">
            <th>END OF SEMESTER 2 
            <div class="instructions">
              include recommendations for next year 
            </div>
 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_ProgressSem2" runat="server"/> 
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM2" rows="3" Columns="50" maxysize="400" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY / WHEN</th>
 
            <td><asp:Literal id="STUDENT_PROFILE1LAST_ALTERED_BY1" runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_PROFILE1LAST_ALTERED_DATE1" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td style="TEXT-ALIGN: right" colspan="2">
              <input id='STUDENT_PROFILE1Button_Insert' type="submit" class="Button" value="Add Profile" OnServerClick='STUDENT_PROFILE1_Insert' runat="server"/>
              <input id='STUDENT_PROFILE1Button_Update' type="submit" class="Button" value="Update" OnServerClick='STUDENT_PROFILE1_Update' runat="server"/>
              <input id='STUDENT_PROFILE1Button_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_PROFILE1_Cancel' runat="server"/></td>
          </tr>
        </table>
        
  <input id="STUDENT_PROFILE1Hidden_LEARNING_PROGRAM_CONSULT" type="hidden"  runat="server"/>
  
  <input id="STUDENT_PROFILE1Hidden_COMM_CONTACT_TYPE_MULTI" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>



  </span>
  </p>
<script src="js/sisyphus.min.js" type="text/javascript"></script>
<script src="js/sisyphus-ondemand.js" type="text/javascript"></script>
<script src="js/jquery.maxlength.min.js" type="text/javascript"></script>
<script type="text/javascript">
       /*
        $(window).load(function() {
                // Animate loader off screen
                $(".modal").fadeOut("slow");
        });
                */
                jQuery.noConflict();
        jQuery(function(){
             //attachSisyphus('form')
             // $('form').sisyphus({timeout: 10, autoRelease: true})
        });  

</script>
<script language="javascript" type="text/javascript">
      jQuery(function(){
                // due to stupid ASP.NET not allowing maxlength attribute on textarea
                // , use 'maxysize' and convert on load to maxlength
                // and attach to textarea now, when the attr exists
                jQuery('textarea').attr('maxlength', function() {
                                        return jQuery(this).attr('maxysize');
                                 }).maxlength(); 
                                        
                        // jQuery("input").maxlength();
        });
</script>
<div class="modal">
  <!-- BEGIN Panel Panel1 --><!-- END Panel Panel1 -->
  <!-- Place at bottom of page -->
</div>

</form>
</body>
</html>

<!--End ASPX page-->

