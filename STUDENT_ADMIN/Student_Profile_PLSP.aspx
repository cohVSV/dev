<!--ASPX page @1-2BE2334B-->
    <%@ Page language="vb" CodeFile="Student_Profile_PLSP.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_Profile_PLSP.Student_Profile_PLSPPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_Profile_PLSP" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="StudentNamePlate" Src="StudentNamePlate.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 5.1.0.18696"><meta name="description" content="for 202 Enrolments, spin off parts of Student Profile into the Personal Learning Plan (PLP) and the Personal Learning and Support Plan (PLSP). Everyone gets the PLP and the Support page is only for certain categories of students."><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Personal Learning and Support Plan</title>



<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
<style type="text/css">
<!--
.instructions   { font-size: 12px; font-style: italic; }
.processtips   { display: none; }
.processtips::before  { content: "Tip!"; }
.processtips:hover   { display: block; }
.errormsg   { font-size: 120%; background-color: #F00; color: #FFF; font-weight: bold; margin: 2px; }
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
            <th>Add/Edit STUDENT&nbsp;PERSONAL LEARNING PLAN&nbsp;</th>
 
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
            <th>&nbsp;Somthing&nbsp;something manual&nbsp;Checked?</th>
 
            <td>&nbsp;<asp:CheckBox id="STUDENT_PROFILE1cbENROL_FILE_CHECKED" runat="server"/>&nbsp;<em>(enrol file to be checked annually for returning students)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>
            <h4>&nbsp;PERSONAL INFORMATION</h4>
            </th>
 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp; Something might go here </th>
 
            <td>&nbsp; 
              <p><em>(the PLP and other stuff might be at the top)</em></p>
            </td>
          </tr>
 
          <tr class="Controls">
            <td style="TEXT-ALIGN: right" colspan="2">
              <input id='STUDENT_PROFILE1Button_Insert2' type="submit" class="Button" value="Add Learning Plan" OnServerClick='STUDENT_PROFILE1_Insert' runat="server"/>
              <input id='STUDENT_PROFILE1Button_Update2' type="submit" class="Button" value="Update" OnServerClick='STUDENT_PROFILE1_Update' runat="server"/>
              <input id='STUDENT_PROFILE1Button_Cancel2' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_PROFILE1_Cancel' runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp; 
            <h4>LAUNCHPAD / ASSESSMENT</h4>
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
 
          <tr class="Controls">
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
 
          <tr class="Controls">
            <th>Standard or Customised</th>
 
            <td>
  <input id="STUDENT_PROFILE1LEARNING_PROGRAM" type="hidden"  runat="server"/>
  <asp:Literal id="STUDENT_PROFILE1lblLearningProgram" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>ADDITIONAL DETAILS 
            <div class="instructions">
              eg: reduced subject load, modified subjects 
            </div>
 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_LearnDetails" runat="server"/> 
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1LEARNING_PROGRAM_DETAILS" rows="3" Columns="50" maxysize="200" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
            <th>LEARNING PROGRAM CONSULTATION</th>
 
            <td>
              <asp:CheckBoxList id="STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>LEARNING GOALS 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_LearnGoals" runat="server"/> 
            </div>
            </th>
 
            <td><strong>this will be on another page of Goals</strong></td>
          </tr>
 
          <tr class="Controls">
            <th>SPECIAL PROVISION? 
            <div class="instructions">
              see F-10 Special Provision Policy. Prior discussion<br>
              with LT Engagement and/or Year Level coordinator required 
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
            <h4>REVIEW OF PROGRESS - here or Profile??</h4>
            </th>
 
            <td>&nbsp; 
              <div class="instructions">
                Learning Programs and Career Action Plans should be monitored<br>
                and reviewed once per semester 
              </div>
            </td>
          </tr>
 
          <tr class="Controls">
            <th>END OF SEMESTER 1 
            <div class="errormsg">
              <asp:Literal id="STUDENT_PROFILE1error_ProgressSem1" runat="server"/> 
            </div>
            </th>
 
            <td>
<asp:TextBox id="STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM1" rows="3" Columns="50" maxysize="400" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
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
              <input id='STUDENT_PROFILE1Button_Insert' type="submit" class="Button" value="Add Learning Plan" OnServerClick='STUDENT_PROFILE1_Insert' runat="server"/>
              <input id='STUDENT_PROFILE1Button_Update' type="submit" class="Button" value="Update" OnServerClick='STUDENT_PROFILE1_Update' runat="server"/>
              <input id='STUDENT_PROFILE1Button_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_PROFILE1_Cancel' runat="server"/></td>
          </tr>
        </table>
        
  <input id="STUDENT_PROFILE1Hidden_LEARNING_PROGRAM_CONSULT" type="hidden"  runat="server"/>
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
  <!-- Place at bottom of page -->
</div>

</form>
</body>
</html>

<!--End ASPX page-->

