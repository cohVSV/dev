<!--ASPX page @1-128162F1-->
    <%@ Page language="vb" CodeFile="StudentSummary.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.StudentSummary.StudentSummaryPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.StudentSummary" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Summary</title>


<style type="text/css">
<!--
.AlertRed td   { font-weight: bold; background-color: #FF6666; vertical-align: left; text-align: left; border-top-width: 1px; border-top-color: #3D84CC; border-top-style: solid; border-right-width: 1px; border-right-color: #3D84CC; border-right-style: solid; padding-top: 4px; padding-right: 4px; padding-bottom: 4px; padding-left: 4px; }
.AlertGreen td   { font-weight: bold; background-color: #66CC33; vertical-align: left; text-align: left; border-top-width: 1px; border-top-color: #3D84CC; border-top-style: solid; border-right-width: 1px; border-right-color: #3D84CC; border-right-style: solid; padding-top: 4px; padding-right: 4px; padding-bottom: 4px; padding-left: 4px; }
a.StrongBold  { font-weight: bold; PADDING: 6px 8px 6px 8px;}
a.StrongSad  {PADDING: 6px 8px 6px 8px;}
A:HOVER  { background-color: #D0D0D0; }
.AlertRedText  { font-weight: bold; color: #FF0000; }
.EnrolStatus_E { font-weight: bold; color: #006400; }
.EnrolStatus_N { font-weight: bold; color: #FF0000; }
.EnrolStatus_B { font-weight: bold; background-color: #0000FF; color: white; padding-left: 5px; padding-right: 5px}
.EnrolStatus_F { font-weight: bold; background-color: #0000FF; color: white; padding-left: 5px; padding-right: 5px}
.LearningPlan_PLP { font-weight: bold; color: #006400; }
.LearningPlan_PLSP { font-weight: bold; color: #FF8C00; }
-->
</style>
<link rel="stylesheet" type="text/css" href="Styles/Tile/Style_Components.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<div align="center">
  &nbsp;Back to:&nbsp; <a id="link_Menu" href="" class="Button StrongBold" runat="server"  >Main Menu</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a id="Link_SearchRequest" href="" title="Search and Lookup Student" class="Button StrongSad" runat="server"  >Search Request</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a id="link_Assignments" href="" class="Button StrongBold" runat="server"  >Assignments</a>&nbsp;&nbsp;| <a id="Link10" href="" class="Button StrongSad" runat="server"  >SMS</a>&nbsp; |&nbsp;<a id="Link6" href="" class="Button StrongSad" runat="server"  >Future Intentions</a> | &nbsp;<a id="Link5" href="" class="Button StrongBold" runat="server"  >Comments</a>&nbsp;|&nbsp;&nbsp; <a id="Link8" href="" title="Student Profile" class="Button StrongBold" runat="server"  >Student Profile</a>&nbsp;| &nbsp; <a id="Link7" href="" title="Student Learning and Support Plan" class="Button StrongBold" runat="server"  >Early Assessment Checklist</a>&nbsp;| <a id="Link9" href="" title="Student Learning and Support Plan" class="Button StrongBold" runat="server"  >Referral Forms</a><br>
  <br>
</div>
<div align="center">
  
	<asp:PlaceHolder id="Panel_MaintainMenu" Visible="false" runat="server">
	
  <p><span align="center">Maintain: <a id="Link1" href="" class="Button StrongBold" runat="server"  >Student Details</a>&nbsp; | <a id="Link3" href="" class="Button StrongBold" runat="server"  >Subjects</a>|&nbsp;<a id="Link2" href="" class="Button StrongBold" runat="server"  >Other Details</a>&nbsp;|&nbsp;<a id="Link4" href="" class="Button StrongSad" runat="server"  >VSV Financials</a></span><br>
  &nbsp;&nbsp;&nbsp;</p>
  
	</asp:PlaceHolder>
	
</div>
<div align="center">
  
<asp:repeater id="view_StudentSummary_AlertRepeater" OnItemCommand="view_StudentSummary_AlertItemCommand" OnItemDataBound="view_StudentSummary_AlertItemDataBound" runat="server">
  <HeaderTemplate>
	
  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="HeaderTile" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeftTile">&nbsp;</td> 
            <th>Student Alerts</th>
 
            <td class="HeaderRightTile">&nbsp;</td>
          </tr>
        </table>
 
        <table class="GridTile" cellspacing="0" cellpadding="0">
          
  </HeaderTemplate>
  <ItemTemplate>
          
	<asp:PlaceHolder id="view_StudentSummary_AlertRowOpenTag" Visible="true" runat="server">
	
          <tr class="RowTile">
            
	</asp:PlaceHolder>
	
            <td>
              
	<asp:PlaceHolder id="view_StudentSummary_AlertRowComponents" Visible="true" runat="server">
	<strong><asp:Literal id="view_StudentSummary_AlertCOMMENT_TYPE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,view_StudentSummary_AlertItem)).COMMENT_TYPE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></strong><br>
              <asp:Literal id="view_StudentSummary_AlertComment" Text='<%# Server.HtmlEncode((CType(Container.DataItem,view_StudentSummary_AlertItem)).Comment.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<br>
              <em><asp:Literal id="view_StudentSummary_AlertlblDate_Updated" Text='<%# Server.HtmlEncode((CType(Container.DataItem,view_StudentSummary_AlertItem)).lblDate_Updated.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></em>
	</asp:PlaceHolder>
	&nbsp;</td> 
            
	<asp:PlaceHolder id="view_StudentSummary_AlertRowCloseTag" Visible="true" runat="server">
	
          </tr>
 
	</asp:PlaceHolder>
	
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
          
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
          <tr class="NoRecordsTile">
            <td colspan="<CC:AttributeBinder runat='server' Name='numberOfColumns' ContainerId='view_StudentSummary_AlertRepeater'/>">No Alerts found</td>
          </tr>
          
  </asp:PlaceHolder>

        </table>
      </td>
    </tr>
  </table>
  
  </FooterTemplate>
</asp:repeater>
<br>
</div>
<div align="center">
  
  <span id="viewStudentSummary_DetailHolder" runat="server">
    
  <div align="center">
    

      <table cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
        <tr>
          <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                <th>Student&nbsp;Details </th>
 
                <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
              </tr>
            </table>
 
            <table class="Record" cellspacing="0" cellpadding="0">
              
  <asp:PlaceHolder id="viewStudentSummary_DetailError" visible="False" runat="server">
  
              <tr class="Error">
                <td colspan="4"><asp:Label ID="viewStudentSummary_DetailErrorLabel" runat="server"/></td>
              </tr>
              
  </asp:PlaceHolder>
  
              <tr class="Controls">
                <th><strong>Student ID</strong></th>
 
                <td>
                  <h2><asp:Literal id="viewStudentSummary_DetailStudent_id" runat="server"/></h2>
                </td> 
                <td><strong>&nbsp;Enrolment Date</strong></td> 
                <td><asp:Literal id="viewStudentSummary_Detailenrolment_date" runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Controls">
                <th><strong>End / Withdrawal Date</strong></th>
 
                <td><asp:Literal id="viewStudentSummary_Detailwithdrawal_date" runat="server"/>&nbsp;</td> 
                <td><strong>&nbsp;Enrolment Status</strong></td> 
                <td>&nbsp;<span class="EnrolStatus_<asp:Literal id="viewStudentSummary_DetaillblEnrolStatus" runat="server"/>"><asp:Literal id="viewStudentSummary_DetailENROLMENT_STATUS" runat="server"/></span></td>
              </tr>
 
              <tr class="Controls">
                <th><strong>Withdrawal Reason / Destination</strong></th>
 
                <td colspan="3"><asp:Literal id="viewStudentSummary_DetailWithdrawalReason" runat="server"/>&nbsp;&nbsp;<asp:Literal id="viewStudentSummary_DetailWITHDRAWAL_REASON_ID" runat="server"/>&nbsp;&nbsp;/&nbsp;&nbsp;<asp:Literal id="viewStudentSummary_DetaillblWd_Exit_Destination" runat="server"/>&nbsp;&nbsp;<asp:Literal id="viewStudentSummary_DetailWD_EXIT_DESTINATION" runat="server"/></td>
              </tr>
 
              <tr class="Controls">
                <th><strong>VSN</strong>&nbsp;<img onclick="javascript:alert('Victorian Student Number Aug 2009');return false;" id="vsn_icon" title="Victorian Student Number Aug 2009" border="0" name="VSNIcon" alt="Victorian Student Number" src="images/icon_info.gif"></th>
 
                <td><asp:Literal id="viewStudentSummary_DetailVSN" runat="server"/>&nbsp;</td> 
                <td><strong>VSR Enrolled</strong>&nbsp;&nbsp;<img onclick="javascript:alert('Student registered with Victorian Student Registry for VSN Aug 2009');return false;" id="vsr_enrolled_icon" title="Student registered with Victorian Student Registry for VSN Aug 2009" border="0" name="VSR_EnrolledIcon" alt="Student registered with Victorian Student Registry for VSN" src="images/icon_info.gif"></td> 
                <td>&nbsp;<asp:Literal id="viewStudentSummary_DetailVSR_Enrolled" runat="server"/></td>
              </tr>
 
              <tr class="Controls">
                <th>&nbsp;</th>
 
                <td>&nbsp;</td> 
                <td>&nbsp;</td> 
                <td>&nbsp;</td>
              </tr>
 
              <tr class="Controls">
                <th><strong>Surname</strong></th>
 
                <td>
                  <h2><asp:Literal id="viewStudentSummary_Detailsurname" runat="server"/></h2>
                </td> 
                <td><strong>First Name</strong></td> 
                <td><asp:Literal id="viewStudentSummary_Detailfirst_name" runat="server"/></td>
              </tr>
 
              <tr class="Controls">
                <th><strong>Middle Name</strong></th>
 
                <td><asp:Literal id="viewStudentSummary_Detailmiddle_name" runat="server"/></td> 
                <td><strong>Preferred Name</strong></td> 
                <td><asp:Literal id="viewStudentSummary_Detailpreferred_name" runat="server"/></td>
              </tr>
 
              <tr class="Controls">
                <th>&nbsp;</th>
 
                <td>&nbsp;</td> 
                <td>&nbsp;</td> 
                <td>&nbsp;</td>
              </tr>
 
              <tr class="Controls">
                <th><strong>Gender</strong></th>
 
                <td><asp:Literal id="viewStudentSummary_DetailSEX" runat="server"/></td> 
                <td>&nbsp;<strong>Birth Date&nbsp;</strong><em>Current Age</em></td> 
                <td>&nbsp;<asp:Literal id="viewStudentSummary_Detailbirth_date" runat="server"/>&nbsp;&nbsp;&nbsp;<em><asp:Literal id="viewStudentSummary_Detaillabel_Age" runat="server"/></em>&nbsp;<asp:Literal id="viewStudentSummary_Detailcake" runat="server"/></td>
              </tr>
 
              <tr class="Controls">
                <th><strong>Pronouns</strong></th>
 
                <td><asp:Literal id="viewStudentSummary_DetailPronouns" runat="server"/></td> 
                <td>&nbsp;</td> 
                <td>&nbsp;</td>
              </tr>
 
              <tr class="Controls">
                <th><strong>Year Level</strong></th>
 
                <td><asp:Literal id="viewStudentSummary_DetailYEAR_LEVEL" runat="server"/>&nbsp;&nbsp;&nbsp;<asp:Literal id="viewStudentSummary_DetaillblHomeSchooled" runat="server"/>&nbsp;&nbsp;&nbsp;</td> 
                <td><strong>&nbsp;Enrolment Year</strong></td> 
                <td>&nbsp;<asp:Literal id="viewStudentSummary_DetailEnrolmentYear" runat="server"/></td>
              </tr>
 
              <tr class="Controls">
                <th><strong>ATAR Required?</strong>&nbsp;&nbsp;(Year 12 only)</th>
 
                <td><asp:Literal id="viewStudentSummary_DetailATAR_REQUIRED" runat="server"/>&nbsp;&nbsp;<asp:Literal id="viewStudentSummary_DetaillblATARNotRequired" runat="server"/></td> 
                <td><strong>&nbsp;Portal Access</strong></td> 
                <td>&nbsp;<asp:Literal id="viewStudentSummary_DetailPORTAL_ACCESS" runat="server"/>&nbsp;&nbsp;<asp:Literal id="viewStudentSummary_DetaillblPortalAccessRestricted" runat="server"/></td>
              </tr>
 
              <tr class="Controls">
                <th>&nbsp;</th>
 
                <td>&nbsp;</td> 
                <td>&nbsp;</td> 
                <td>&nbsp;</td>
              </tr>
 
              <tr class="Controls">
                <th><strong>Category / Sub Category</strong></th>
 
                <td><asp:Literal id="viewStudentSummary_Detailsubcategory_full_title" runat="server"/>&nbsp;</td> 
                <td>&nbsp;<strong>Learning Advisor ID</strong></td> 
                <td>&nbsp;<a id="viewStudentSummary_DetailLinkLearningAdvisorEmail" href="" title="Create an email to this student's Learning Advisor" runat="server"  ></a><asp:Literal id="viewStudentSummary_DetailPASTORAL_CARE_ID" runat="server"/></td>
              </tr>
 
              <tr class="Controls">
                <th><strong>Attending School</strong> </th>
 
                <td><asp:Literal id="viewStudentSummary_Detailattending_school_name" runat="server"/>&nbsp; (<asp:Literal id="viewStudentSummary_DetailATTENDING_SCHOOL_ID" runat="server"/>)</td> 
                <td>&nbsp;<strong>Learning Plan</strong></td> 
                <td>&nbsp;<span class="LearningPlan_<asp:Literal id="viewStudentSummary_DetaillblPLP" runat="server"/>"><asp:Literal id="viewStudentSummary_DetailLEARNING_PROGRAM_text" runat="server"/></span></td>
              </tr>
 
              <tr class="Controls">
                <th><strong>Home School</strong> <asp:Literal id="viewStudentSummary_DetaillblSharedEnrolment" runat="server"/></th>
 
                <td><asp:Literal id="viewStudentSummary_Detailhome_school_name" runat="server"/>&nbsp;&nbsp;(<asp:Literal id="viewStudentSummary_DetailHOME_SCHOOL_ID" runat="server"/>)</td> 
                <td>&nbsp;<strong>SSG Facilitator ID</strong></td> 
                <td>&nbsp;<asp:Literal id="viewStudentSummary_DetailSSG_FACILITATOR_ID" runat="server"/></td>
              </tr>
 
              <tr class="Controls">
                <th><strong>Extra Organisation</strong>&nbsp;</th>
 
                <td><asp:Literal id="viewStudentSummary_Detailorg_school_name" runat="server"/>&nbsp;&nbsp;(<asp:Literal id="viewStudentSummary_DetailORGANISATION_SCHOOL_ID" runat="server"/>)&nbsp;</td> 
                <td>&nbsp;<strong>Student Folder </strong><img onclick="javascript:alert('Student Work Folder Feb 2010');return false;" id="studentfolder_icon" title="Student Work Folder Feb 2010" border="0" name="studentfolderIcon" alt="Student Work Folder" src="images/icon_info.gif"></td> 
                <td>&nbsp; 
                  <a id="viewStudentSummary_Detaillink_showstudentfolder" href="" target="_blank" runat="server"   Visible="False">Show Student Folder</a>&nbsp;<asp:Literal id="viewStudentSummary_DetaillabelContactWho" runat="server"/><br>
                  <span id="lblStudentFolderBrowserNotice" style="MARGIN-TOP: 5px; FONT-STYLE: italic; DISPLAY: none">Please try using the Microsoft Edge browser if the folder link doesn't work</span> </td>
              </tr>
 
              <tr class="Controls">
                <th><strong>Files and Forms </strong></th>
 
                <td>&nbsp; <a id="viewStudentSummary_DetailFunnelLink" href="" runat="server"  >Transit Lounge</a>&nbsp; <a id="viewStudentSummary_DetailFilesLink" href="" runat="server"  >Files</a>&nbsp; <asp:Literal id="viewStudentSummary_DetailFunnelUUID" runat="server"/>&nbsp;<a id="viewStudentSummary_DetailReferralsLink" href="" runat="server"  >Referral Forms</a></td> 
                <td>&nbsp;<strong>Student Reports </strong><img onclick="javascript:alert('Student Report Folder Aug 2013');return false;" id="studentfolder_icon" title="Student Reports Folder Aug 2013" border="0" name="studentfolderIcon" alt="Student Work Folder" src="images/icon_info.gif"></td> 
                <td>&nbsp; 
                  <a id="viewStudentSummary_Detaillink_showstudentreports" href="" target="_blank" runat="server"   Visible="False">Show Reports</a>&nbsp;<asp:Literal id="viewStudentSummary_DetaillabelContactWho1" runat="server"/></td>
              </tr>
 
              <tr class="Controls">
                <th>&nbsp;</th>
 
                <td>&nbsp;</td> 
                <td>&nbsp;</td> 
                <td>&nbsp;</td>
              </tr>
 
              <tr class="Controls">
                <th><strong>Email Virtual School Victoria Teachers</strong></th>
 
                <td><a id="viewStudentSummary_Detaillink_create_teacheremails" href="" runat="server"  >Email Virtual School Victoria Teachers</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td> 
                <td><strong>Region</strong> <a href="https://www.education.vic.gov.au/about/department/structure/Pages/regions.aspx" title="open Department Region page" target="_blank">info</a></td> 
                <td>&nbsp;<asp:Literal id="viewStudentSummary_DetaillblRegionDisplay" runat="server"/></td>
              </tr>
 
              <tr class="Controls">
                <th><strong>Email Student &amp; Parents &amp; Supervisors</strong>&nbsp;</th>
 
                <td><a id="viewStudentSummary_Detaillink_create_parentemails" href="" title="create an email to Student & Parents & Supervisors" runat="server"  >Email Student &amp; Parents &amp; Supervisors</a></td> 
                <td><strong>Area</strong></td> 
                <td>&nbsp;<asp:Literal id="viewStudentSummary_DetaillblAreaDisplay" runat="server"/></td>
              </tr>
 
              <tr class="Controls">
                <th>&nbsp;</th>
 
                <td>&nbsp;</td> 
                <td>&nbsp;</td> 
                <td>&nbsp;</td>
              </tr>
 
              <tr class="Controls">
                <th><strong>Student Email / Mobile</strong></th>
 
                <td colspan="3"><a id="viewStudentSummary_DetailSTUDENT_EMAIL" href="" title="create an email to this Student." runat="server"  ></a>&nbsp;&nbsp; <asp:Literal id="viewStudentSummary_DetailSTUDENT_MOBILE" runat="server"/>&nbsp;&nbsp;</td>
              </tr>
 
              <tr class="Controls">
                <th><strong></strong></th>
 
                <td></td> 
                <td><strong>&nbsp;Receipt No</strong></td> 
                <td>&nbsp;<asp:Literal id="viewStudentSummary_Detailreceipt_no" runat="server"/></td>
              </tr>
 
              <tr class="Controls">
                <th><strong>POSTAL/RESID/ORIG ADDRESS ID</strong></th>
 
                <td colspan="3"><asp:Literal id="viewStudentSummary_DetailPOSTAL_ADDRESS_ID" runat="server"/>&nbsp;/ <asp:Literal id="viewStudentSummary_DetailCURR_RESID_ADDRESS_ID" runat="server"/>&nbsp;/ <asp:Literal id="viewStudentSummary_DetailORIG_RESID_ADDRESS_ID" runat="server"/>&nbsp;&nbsp; 
                  <div style="FLOAT: right">
                    <script type="text/javascript">
                            function ResetScaffoldPassword() {
                                if (confirm("Please confirm you want to reset this student's Scaffold password?")) {
                                    var xhttp = new XMLHttpRequest();
                                    xhttp.open("GET", "ResetScaffoldPassword.aspx?STUDENT_ID=<%=Request.QueryString("STUDENT_ID")%>", false);
                                    xhttp.send();
                                    alert(xhttp.responseText);
                                }
                            }
                        </script>
                    <!-- <input type="button" onclick="javascript:ResetScaffoldPassword()" value="Reset Scaffold Password"/> //-->
                    No password reset - send <a id="viewStudentSummary_DetailLink1" href="" target="_blank" runat="server"  >Confirmation of Enrolment Email</a> (formerly known as the Welcome Letter) instead 
                  </div>
                </td>
              </tr>
 
              <tr class="Bottom">
                <th colspan="4" align="right"></th>
              </tr>
            </table>
            
  <input id="viewStudentSummary_Detailhidden_DATE_STUDENTFOLDER_CREATED" type="hidden"  runat="server"/>
  
  <input id="viewStudentSummary_Detailhidden_SEX_SELF_DESCRIBED" type="hidden"  runat="server"/>
  </td>
        </tr>
      </table>
    

  </div>
  
  </span>
  
</div>
<div align="center">
</div>
&nbsp; 

<asp:repeater id="viewStudentSummary_SubjectListRepeater" OnItemCommand="viewStudentSummary_SubjectListItemCommand" OnItemDataBound="viewStudentSummary_SubjectListItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>Subject List</th>
 
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table id="SubjectList" class="Grid tablesorter" cellspacing="0" cellpadding="0">
        <thead>
          <tr class="Caption">
            <th>Subj ID</th>
 
            <th>Abbrev</th>
 
            <th>Subject Title</th>
 
            <th>Sem.</th>
 
            <th>Status (Extending)</th>
 
            <th>Standard<br>
            Learning Program&nbsp;</th>
 
            <th>Enrol. Date </th>
 
            <th>End Date </th>
 
            <th>Asst.</th>
 
            <th>Teacher </th>
 
            <th>Class Code</th>
 
            <th>Interim<br>
            Result</th>
 
            <th>Final<br>
            Result</th>
          </tr>
 
        </thead>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="TEXT-ALIGN: right"><asp:Literal id="viewStudentSummary_SubjectListSUBJECT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewStudentSummary_SubjectListItem)).SUBJECT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewStudentSummary_SubjectListSUBJECT_ABBREV" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewStudentSummary_SubjectListItem)).SUBJECT_ABBREV.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td nowrap><asp:Literal id="viewStudentSummary_SubjectListSUBJECT_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewStudentSummary_SubjectListItem)).SUBJECT_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewStudentSummary_SubjectListSEMESTER" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewStudentSummary_SubjectListItem)).SEMESTER.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td nowrap><asp:Literal id="viewStudentSummary_SubjectListSUBJ_ENROL_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewStudentSummary_SubjectListItem)).SUBJ_ENROL_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="viewStudentSummary_SubjectListEXTENSION_OF_VCE_UNIT_display" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewStudentSummary_SubjectListItem)).EXTENSION_OF_VCE_UNIT_display.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<font color="red"><asp:Literal id="viewStudentSummary_SubjectListNON_SUBMITTING_FLAG_display" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewStudentSummary_SubjectListItem)).NON_SUBMITTING_FLAG_display.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></font></td> 
          <td><asp:Literal id="viewStudentSummary_SubjectListCUSTOM_LP_display" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewStudentSummary_SubjectListItem)).CUSTOM_LP_display.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td><asp:Literal id="viewStudentSummary_SubjectListenrolment_date" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewStudentSummary_SubjectListItem)).enrolment_date.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td><asp:Literal id="viewStudentSummary_SubjectListwithdrawal_date" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewStudentSummary_SubjectListItem)).withdrawal_date.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="viewStudentSummary_SubjectListNUM_ASSMT_SUBMISSIONS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewStudentSummary_SubjectListItem)).NUM_ASSMT_SUBMISSIONS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewStudentSummary_SubjectListSTAFF_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewStudentSummary_SubjectListItem)).STAFF_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td><asp:Literal id="viewStudentSummary_SubjectListCLASS_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewStudentSummary_SubjectListItem)).CLASS_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td><asp:Literal id="viewStudentSummary_SubjectListINTERIM_PROGRESS_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewStudentSummary_SubjectListItem)).INTERIM_PROGRESS_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewStudentSummary_SubjectListFINAL_PROGRESS_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewStudentSummary_SubjectListItem)).FINAL_PROGRESS_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <SeparatorTemplate>
	
  </SeparatorTemplate>
  <FooterTemplate>
	
        
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="13">No Subjects </td>
        </tr>
        
  </asp:PlaceHolder>

      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>

<p>
<div align="center">
  &nbsp;
</div>
<br>
<div align="center">
  
<asp:repeater id="STUDENT_COMMENT1Repeater" OnItemCommand="STUDENT_COMMENT1ItemCommand" OnItemDataBound="STUDENT_COMMENT1ItemDataBound" runat="server">
  <HeaderTemplate>
	
  <table id="STUDENT_COMMENT1" class="MainTable" cellspacing="0" cellpadding="0" width="90%" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th><font color="#ff9900">Reasonable Adjustment/Modification</font></th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Grid" cellspacing="0" cellpadding="0">
          <tr class="Caption">
            <th>COMMENT</th>
 
            <th>COMMENT TYPE</th>
 
            <th>LAST ALTERED BY</th>
 
            <th>LAST ALTERED DATE</th>
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
          <tr class="Row">
            <td><asp:Literal id="STUDENT_COMMENT1COMMENT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_COMMENT1Item)).COMMENT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="STUDENT_COMMENT1COMMENT_TYPE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_COMMENT1Item)).COMMENT_TYPE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="STUDENT_COMMENT1LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_COMMENT1Item)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="STUDENT_COMMENT1LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_COMMENT1Item)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
          
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
          <tr class="NoRecords">
            <td colspan="4">No Student Details found!</td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Footer">
            <td colspan="4">
              
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# STUDENT_COMMENT1Data.PagesCount%>" PageSize="<%# STUDENT_COMMENT1Data.RecordsPerPage%>" PageNumber="<%# STUDENT_COMMENT1Data.PageNumber%>" runat="server"><span class="Navigator">Records per page 
              <CC:PageSizer AutoPostBack="true" runat="server" />
 
              <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server">First</asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="FirstOff" runat="server">First </CC:NavigatorItem>
              <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server">Prev</asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="PrevOff" runat="server">Prev </CC:NavigatorItem>&nbsp; 
              
<CC:Pager id="NavigatorPager" Style="Centered" PagerSize="10" runat="server">
              <PageOnTemplate><asp:LinkButton runat="server"><%# (CType(Container,PagerItem)).PageNumber.ToString() %></asp:LinkButton>&nbsp;</PageOnTemplate>
              <PageOffTemplate><%# (CType(Container,PagerItem)).PageNumber.ToString() %>&nbsp;</PageOffTemplate></CC:Pager>of &nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
              <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server">Next</asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="NextOff" runat="server">Next </CC:NavigatorItem>
              <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server">Last</asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="LastOff" runat="server">Last </CC:NavigatorItem></span></CC:Navigator>
&nbsp;</td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
  
  </FooterTemplate>
</asp:repeater>
<br>
</div>
<br>
<div align="center">
  
<asp:repeater id="STUDENT_COMMENTRepeater" OnItemCommand="STUDENT_COMMENTItemCommand" OnItemDataBound="STUDENT_COMMENTItemDataBound" runat="server">
  <HeaderTemplate>
	
  <div align="center">
    <table cellspacing="0" cellpadding="0" width="90%" border="0">
      <tr>
        <td valign="top" align="center">
          <table class="Header" cellspacing="0" cellpadding="0" border="0">
            <tr>
              <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
              <th>Public Comments</th>
 
              <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
            </tr>
          </table>
 
          <div align="center">
            <table id="STUDENT_COMMENTS_table" class="Grid" cellspacing="0" cellpadding="0">
              <tr class="Caption">
                <th>Comment</th>
 
                <th>&nbsp;Type</th>
 
                <th>Entered By</th>
 
                <th>Date Entered</th>
              </tr>
 
              
  </HeaderTemplate>
  <ItemTemplate>
              <tr class="Row">
                <td><asp:Literal id="STUDENT_COMMENTCOMMENT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_COMMENTItem)).COMMENT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                <td>&nbsp;<asp:Literal id="STUDENT_COMMENTCOMMENT_TYPE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_COMMENTItem)).COMMENT_TYPE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
                <td><asp:Literal id="STUDENT_COMMENTLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_COMMENTItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                <td><asp:Literal id="STUDENT_COMMENTLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_COMMENTItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <SeparatorTemplate>
	
  </SeparatorTemplate>
  <FooterTemplate>
	
              
              
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
              <tr class="NoRecords">
                <td colspan="4">No Comments found.</td>
              </tr>
              
  </asp:PlaceHolder>

            </table>
          </div>
        </td>
      </tr>
    </table>
  </div>
  <div align="left">
  </div>
  
  </FooterTemplate>
</asp:repeater>

</div>
<br>
<div align="center">
  
<CC:Report id="viewStudentSummary_Enrolm" WebPageSize="40" PageSizeLimit="100" runat="server">
  <LayoutHeaderTemplate>
  <table cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Student Enrolment (Misc)</th>
 
            <th width="150">
            <div id="toggle_Enrolment_Misc" class="Button" style="WIDTH: 130px; MARGIN: 5px" align="right">
              show/hide Enrolment 
            </div>
            </th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table id="viewStudentSummary_Enrolm_table" class="Grid" cellspacing="0" cellpadding="0">
          </LayoutHeaderTemplate>
  <Section name="Report_Header" Visible="True" Height="0"><Template></Template></Section>
<Section name="Page_Header" Visible="True" Height="0"><Template>
          <tr class="Row">
            <th style="COLOR: orange" colspan="4"><strong>This panel has been updated mid-2018 to remove old fields</strong></th>
          </tr>
 
          <tr class="Row">
            <th colspan="4"><em>If you use specific fields that&nbsp;have disappeared, please lodge a service desk ticket, tagged to [Database] and let us know</em></th>
          </tr>
 </Template></Section>
<Section name="Detail" Visible="True" Height="12"><Template>
          <tr class="Row">
            <th><strong>Eligible for Discount</strong></th>
 
            <td>&nbsp;<CC:ReportLabel id="viewStudentSummary_Enrolmeligible_for_discount_desc" DataType="_Text" SourceType="DBColumn" Source="eligible_for_discount_desc" runat="server"/> </td> 
            <td><strong>Paid on Enrolment</strong></td> 
            <td>&nbsp;<CC:ReportLabel id="viewStudentSummary_Enrolmpaid_on_enrolment_desc" DataType="_Text" SourceType="DBColumn" Source="paid_on_enrolment_desc" runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th><strong>Full Time Student</strong></th>
 
            <td>&nbsp;<CC:ReportLabel id="viewStudentSummary_Enrolmfull_time_desc" DataType="_Text" SourceType="DBColumn" Source="full_time_desc" runat="server"/> </td> 
            <td><strong>Overseas Full Fee Paying</strong></td> 
            <td>&nbsp;<CC:ReportLabel id="viewStudentSummary_Enrolmos_full_fee_paying_desc" DataType="_Text" SourceType="DBColumn" Source="os_full_fee_paying_desc" runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th>
            <p><strong>Address needs Reviewing</strong></p>
            </th>
 
            <td>&nbsp;<CC:ReportLabel id="viewStudentSummary_Enrolmaddress_review_flag_desc" DataType="_Text" SourceType="DBColumn" Source="address_review_flag_desc" runat="server"/> </td> 
            <td><strong>Eligible for Funding</strong></td> 
            <td>&nbsp;<CC:ReportLabel id="viewStudentSummary_Enrolmeligible_for_funding_desc" DataType="_Text" SourceType="DBColumn" Source="eligible_for_funding_desc" runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th><strong>VCE Candidate Number</strong> </th>
 
            <td>&nbsp;<CC:ReportLabel id="viewStudentSummary_Enrolmvce_candidate_number" DataType="_Text" SourceType="DBColumn" Source="vce_candidate_number" runat="server"/> </td> 
            <td><strong>Bulletin Number</strong> </td> 
            <td>&nbsp;<CC:ReportLabel id="viewStudentSummary_Enrolmbulletin_number" DataType="_Text" SourceType="DBColumn" Source="bulletin_number" runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th><strong>Last Reviewed Date</strong> </th>
 
            <td>&nbsp;<CC:ReportLabel id="viewStudentSummary_Enrolmlast_reviewed_date" DataType="_Text" SourceType="DBColumn" Source="last_reviewed_date" runat="server"/> </td> 
            <td><strong>New Documents Required</strong></td> 
            <td>&nbsp;<CC:ReportLabel id="viewStudentSummary_Enrolmnew_docs_required_desc" DataType="_Text" SourceType="DBColumn" Source="new_docs_required_desc" runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th colspan="4"><strong>Enrolment Comments</strong> &nbsp;<CC:ReportLabel id="viewStudentSummary_Enrolmenrolment_comments" DataType="_Text" SourceType="DBColumn" Source="enrolment_comments" runat="server"/>&nbsp;&nbsp;</th>
          </tr>
 </Template></Section>
<Section name="Report_Footer" Visible="True" Height="0"><Template>
          
	<asp:PlaceHolder id="viewStudentSummary_EnrolmNoRecords" Visible="true" runat="server">
	
          <tr class="NoRecords">
            <td colspan="4">No Enrolment Details found</td>
          </tr>
 
	</asp:PlaceHolder>
	</Template></Section>
<Section name="Page_Footer" Visible="True" Height="0"><Template></Template></Section>

  <LayoutFooterTemplate>
        </table>
      </td>
    </tr>
  </table>
  &nbsp;</LayoutFooterTemplate>
</CC:Report>
<br>
</div>
<div align="center">
  <hr>
</div>
<div align="center">
  &nbsp; 
  <table width="90%" border="0">
    <tr>
      <td valign="top">&nbsp; 
        
<asp:repeater id="Grid_FamilyGroupRepeater" OnItemCommand="Grid_FamilyGroupItemCommand" OnItemDataBound="Grid_FamilyGroupItemDataBound" runat="server">
  <HeaderTemplate>
	
        <table id="Grid_FamilyGroup" class="MainTable" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td valign="top">
              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
                  <th>Family Group</th>
 
                  <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
                </tr>
              </table>
 
              <table class="Grid" cellspacing="0" cellpadding="0">
                
  </HeaderTemplate>
  <ItemTemplate>
                
	<asp:PlaceHolder id="Grid_FamilyGroupRowOpenTag" Visible="true" runat="server">
	
                <tr class="Row">
                  
	</asp:PlaceHolder>
	
                  <td nowrap>
                    
	<asp:PlaceHolder id="Grid_FamilyGroupRowComponents" Visible="true" runat="server">
	<a id="Grid_FamilyGroupSTUDENT_ID" href="" title="show Student Summary" runat="server"  ><%#(CType(Container.DataItem,Grid_FamilyGroupItem)).STUDENT_ID.GetFormattedValue()%></a>&nbsp;&nbsp;&nbsp;&nbsp;<em><asp:Literal id="Grid_FamilyGrouplast_enrol_year" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_FamilyGroupItem)).last_enrol_year.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></em><br>
                    <asp:Literal id="Grid_FamilyGroupfirst_name" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_FamilyGroupItem)).first_name.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="Grid_FamilyGroupsurname" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_FamilyGroupItem)).surname.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/> 
	</asp:PlaceHolder>
	</td> 
                  
	<asp:PlaceHolder id="Grid_FamilyGroupRowCloseTag" Visible="true" runat="server">
	
                </tr>
 
	</asp:PlaceHolder>
	
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
                
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
                <tr class="NoRecords">
                  <td colspan="<CC:AttributeBinder runat='server' Name='numberOfColumns' ContainerId='Grid_FamilyGroupRepeater'/>">No other Students in this Family Group</td>
                </tr>
                
  </asp:PlaceHolder>

              </table>
            </td>
          </tr>
        </table>
        
  </FooterTemplate>
</asp:repeater>
&nbsp;</td> 
      <td valign="top">&nbsp; 
        
<asp:repeater id="STUDENT_CARER_CONTACTRepeater" OnItemCommand="STUDENT_CARER_CONTACTItemCommand" OnItemDataBound="STUDENT_CARER_CONTACTItemDataBound" runat="server">
  <HeaderTemplate>
	
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
          <tr>
            <td valign="top">
              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                  <th>Parent A /&nbsp;<font color="#ffff00">Primary Carer</font></th>
 
                  <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                </tr>
              </table>
 
              <table class="Grid" cellspacing="0" cellpadding="0">
                
  </HeaderTemplate>
  <ItemTemplate>
                <tr class="Row">
                  <th>Name</th>
 
                  <td><asp:Literal id="STUDENT_CARER_CONTACTTITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACTFIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACTSURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
                </tr>
 
                <tr class="Row">
                  <th>Relationship</th>
 
                  <td>
                    <select id="STUDENT_CARER_CONTACTRELATIONSHIP" disabled  runat="server"></select>
 &nbsp; </td>
                </tr>
 
                <tr class="Row">
                  <th>Home Phone</th>
 
                  <td><asp:Literal id="STUDENT_CARER_CONTACTHOME_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).HOME_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Row">
                  <th>Work Phone</th>
 
                  <td><asp:Literal id="STUDENT_CARER_CONTACTWORK_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).WORK_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Row">
                  <th>Mobile</th>
 
                  <td><asp:Literal id="STUDENT_CARER_CONTACTMOBILE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).MOBILE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Row">
                  <th>Email Address</th>
 
                  <td><a id="STUDENT_CARER_CONTACTEMAIL" href="" runat="server"  ><%#(CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).EMAIL.GetFormattedValue()%></a></td>
                </tr>
 
                <tr class="Row">
                  <th>Last Portal Login&nbsp;&nbsp;</th>
 
                  <td><asp:Literal id="STUDENT_CARER_CONTACTPORTAL_LAST_LOGIN_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).PORTAL_LAST_LOGIN_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Row">
                  <th>Last Altered By / Date / ID</th>
 
                  <td><asp:Literal id="STUDENT_CARER_CONTACTLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_CARER_CONTACTLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_CARER_CONTACTCARER_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).CARER_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Bottom">
                  <td colspan="2" align="right"></td>
                </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
                
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
                <tr class="NoRecords">
                  <td colspan="2">No Contact Details for Parent A.&nbsp;<br>
                  </td>
                </tr>
                
  </asp:PlaceHolder>

              </table>
            </td>
          </tr>
        </table>
        
  </FooterTemplate>
</asp:repeater>
</td> 
      <td valign="top">&nbsp; 
        
<asp:repeater id="STUDENT_CARER_CONTACT1Repeater" OnItemCommand="STUDENT_CARER_CONTACT1ItemCommand" OnItemDataBound="STUDENT_CARER_CONTACT1ItemDataBound" runat="server">
  <HeaderTemplate>
	
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
          <tr>
            <td valign="top">
              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                  <th>Parent&nbsp;B</th>
 
                  <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                </tr>
              </table>
 
              <table class="Grid" cellspacing="0" cellpadding="0">
                
  </HeaderTemplate>
  <ItemTemplate>
                <tr class="Row">
                  <th>Name</th>
 
                  <td><asp:Literal id="STUDENT_CARER_CONTACT1TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACT1FIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACT1SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
                </tr>
 
                <tr class="Row">
                  <th>Relationship</th>
 
                  <td>
                    <select id="STUDENT_CARER_CONTACT1RELATIONSHIP" disabled  runat="server"></select>
 </td>
                </tr>
 
                <tr class="Row">
                  <th>Home Phone</th>
 
                  <td><asp:Literal id="STUDENT_CARER_CONTACT1HOME_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).HOME_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Row">
                  <th>Work Phone</th>
 
                  <td><asp:Literal id="STUDENT_CARER_CONTACT1WORK_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).WORK_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Row">
                  <th>Mobile</th>
 
                  <td><asp:Literal id="STUDENT_CARER_CONTACT1MOBILE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).MOBILE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Row">
                  <th>Email Address</th>
 
                  <td><a id="STUDENT_CARER_CONTACT1EMAIL" href="" runat="server"  ><%#(CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).EMAIL.GetFormattedValue()%></a>&nbsp;</td>
                </tr>
 
                <tr class="Row">
                  <th>Last Portal Login&nbsp;</th>
 
                  <td><asp:Literal id="STUDENT_CARER_CONTACT1PORTAL_LAST_LOGIN_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).PORTAL_LAST_LOGIN_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Row">
                  <th>Last Altered By / Date / ID</th>
 
                  <td><asp:Literal id="STUDENT_CARER_CONTACT1LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_CARER_CONTACT1LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_CARER_CONTACT1CARER_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).CARER_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Bottom">
                  <td colspan="2" align="right"></td>
                </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
                
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
                <tr class="NoRecords">
                  <td colspan="2">No Contact Details for Parent B.<br>
                  </td>
                </tr>
                
  </asp:PlaceHolder>

              </table>
            </td>
          </tr>
        </table>
        &nbsp;
  </FooterTemplate>
</asp:repeater>
</td> 
      <td valign="top">&nbsp; 
        
<asp:repeater id="STUDENT_CARER_CONTACT2Repeater" OnItemCommand="STUDENT_CARER_CONTACT2ItemCommand" OnItemDataBound="STUDENT_CARER_CONTACT2ItemDataBound" runat="server">
  <HeaderTemplate>
	
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
          <tr>
            <td valign="top">
              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                  <th>Supervisor <em>(if any)</em></th>
 
                  <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                </tr>
              </table>
 
              <table class="Grid" cellspacing="0" cellpadding="0">
                
  </HeaderTemplate>
  <ItemTemplate>
                <tr class="Row">
                  <th colspan="2"><strong><asp:Literal id="STUDENT_CARER_CONTACT2Supervisortype" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).Supervisortype.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></strong>&nbsp;</th>
                </tr>
 
                <tr class="Row">
                  <th>Name</th>
 
                  <td><asp:Literal id="STUDENT_CARER_CONTACT2TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACT2FIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACT2SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
                </tr>
 
                <tr class="Row">
                  <th>Position&nbsp;</th>
 
                  <td><asp:Literal id="STUDENT_CARER_CONTACT2SUPERVISOR_POSITION" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).SUPERVISOR_POSITION.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACT2SUPERVISOR_POSITION_OTHER" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).SUPERVISOR_POSITION_OTHER.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
                </tr>
 
                <tr class="Row">
                  <th>Work Phone</th>
 
                  <td><asp:Literal id="STUDENT_CARER_CONTACT2WORK_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).WORK_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Row">
                  <th>Mobile</th>
 
                  <td><asp:Literal id="STUDENT_CARER_CONTACT2MOBILE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).MOBILE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Row">
                  <th>Email Address</th>
 
                  <td><a id="STUDENT_CARER_CONTACT2EMAIL" href="" runat="server"  ><%#(CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).EMAIL.GetFormattedValue()%></a>&nbsp;</td>
                </tr>
 
                <tr class="Row">
                  <th>Last Portal Login&nbsp;</th>
 
                  <td><asp:Literal id="STUDENT_CARER_CONTACT2PORTAL_LAST_LOGIN_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).PORTAL_LAST_LOGIN_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Row">
                  <th>Last Altered By / Date / ID</th>
 
                  <td><asp:Literal id="STUDENT_CARER_CONTACT2LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_CARER_CONTACT2LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_CARER_CONTACT2CARER_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).CARER_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Bottom">
                  <td colspan="2" align="right"></td>
                </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
                
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
                <tr class="NoRecords">
                  <td colspan="2">No Contact Details for School Supervisor. <br>
                  </td>
                </tr>
                
  </asp:PlaceHolder>

              </table>
            </td>
          </tr>
        </table>
        &nbsp;
  </FooterTemplate>
</asp:repeater>
</td>
    </tr>
  </table>
</div>
<div align="center">
  <hr>
</div>
<div align="center">
  
<CC:Report id="ADDRESS_Postal" WebPageSize="40" PageSizeLimit="100" runat="server">
  <LayoutHeaderTemplate>
  <table cellspacing="0" cellpadding="0" width="90%" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Address</th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Grid" cellspacing="0" cellpadding="0">
          </LayoutHeaderTemplate>
  <Section name="Report_Header" Visible="True" Height="0"><Template></Template></Section>
<Section name="Page_Header" Visible="True" Height="0"><Template></Template></Section>
<Section name="Detail" Visible="True" Height="16"><Template>
          <tr class="Row">
            <th>
            <h4>&nbsp;Postal Address:</h4>
            </th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>
              <p align="right">&nbsp;<asp:HyperLink id="ADDRESS_PostalImageLink_GoogleMaps_postal"  ToolTip="open address in new map window" target="_blank" style="BORDER-LEFT-WIDTH: 0px; BORDER-RIGHT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-TOP-WIDTH: 0px" Text="google maps icon" ImageUrl='images/google_maps48.png' runat="server"/></p>
            </td>
          </tr>
 
          <tr class="Row">
            <th><strong>ADDRESSEE </strong></th>
 
            <td colspan="2">&nbsp;<CC:ReportLabel id="ADDRESS_PostalADDRESSEE" DataType="_Text" SourceType="DBColumn" Source="ADDRESSEE" runat="server"/> &nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th><strong>AGENT</strong> </th>
 
            <td colspan="2">&nbsp;<CC:ReportLabel id="ADDRESS_PostalAGENT" DataType="_Text" SourceType="DBColumn" Source="AGENT" runat="server"/> &nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th><strong>ADDRESS</strong> </th>
 
            <td colspan="2">&nbsp;<CC:ReportLabel id="ADDRESS_PostalADDR1" DataType="_Text" SourceType="DBColumn" Source="ADDR1" runat="server"/> &nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th>&nbsp;</th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_PostalADDR2" DataType="_Text" SourceType="DBColumn" Source="ADDR2" runat="server"/> </td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th><strong>SUBURB/TOWN</strong> </th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_PostalSUBURB_TOWN" DataType="_Text" SourceType="DBColumn" Source="SUBURB_TOWN" runat="server"/> </td> 
            <td>&nbsp;<strong>STATE </strong></td> 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_PostalSTATE" DataType="_Text" SourceType="DBColumn" Source="STATE" runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th><strong>POSTCODE</strong> </th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_PostalPOSTCODE" DataType="_Text" SourceType="DBColumn" Source="POSTCODE" runat="server"/></td> 
            <td>&nbsp;<strong>COUNTRY</strong> </td> 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_PostalCOUNTRY" DataType="_Text" SourceType="DBColumn" Source="COUNTRY" runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th><strong>HOME PHONE</strong></th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_PostalPHONE_A" DataType="_Text" SourceType="DBColumn" Source="PHONE_A" runat="server"/> </td> 
            <td>&nbsp;<strong>MOBILE/PHONE 2</strong></td> 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_PostalPHONE_B" DataType="_Text" SourceType="DBColumn" Source="PHONE_B" runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th><strong>FAX</strong> </th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_PostalFAX" DataType="_Text" SourceType="DBColumn" Source="FAX" runat="server"/> </td> 
            <td>&nbsp;<strong>EMAIL ADDRESS</strong> </td> 
            <td>&nbsp;<a id="ADDRESS_PostalEMAIL_ADDRESS" href="" runat="server"  ><%#(CType(Container.DataItem,ADDRESS_PostalItem)).EMAIL_ADDRESS.GetFormattedValue()%></a></td>
          </tr>
 
          <tr class="Row">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th>LAST_ALTERED_BY / DATE</th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_PostalLAST_ALTERED_BY" DataType="_Text" SourceType="DBColumn" Source="LAST_ALTERED_BY" runat="server"/> / <CC:ReportLabel id="ADDRESS_PostalLAST_ALTERED_DATE" Format="dd/mm/yyyy H:nn" DataType="_Date" SourceType="DBColumn" Source="LAST_ALTERED_DATE" runat="server"/></td> 
            <td>ADDRESS_ID</td> 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_PostalADDRESS_ID" DataType="_Float" SourceType="DBColumn" Source="ADDRESS_ID" runat="server"/></td>
          </tr>
 </Template></Section>
<Section name="Report_Footer" Visible="True" Height="0"><Template>
          
	<asp:PlaceHolder id="ADDRESS_PostalNoRecords" Visible="true" runat="server">
	
          <tr class="NoRecords">
            <td colspan="4">No Postal Address Record for this Student</td>
          </tr>
 
	</asp:PlaceHolder>
	</Template></Section>
<Section name="Page_Footer" Visible="True" Height="0"><Template></Template></Section>

  <LayoutFooterTemplate>
        </table>
      </td>
    </tr>
  </table>
  </LayoutFooterTemplate>
</CC:Report>

</div>
<div align="center">
  <br>
  
<CC:Report id="ADDRESS_Current" WebPageSize="40" PageSizeLimit="100" runat="server">
  <LayoutHeaderTemplate>
  <table cellspacing="0" cellpadding="0" width="90%" border="0">
    <tr>
      <td valign="top">
        <table class="Grid" cellspacing="0" cellpadding="0">
          </LayoutHeaderTemplate>
  <Section name="Report_Header" Visible="True" Height="0"><Template></Template></Section>
<Section name="Page_Header" Visible="True" Height="0"><Template></Template></Section>
<Section name="Detail" Visible="True" Height="16"><Template>
          <tr class="Row">
            <th>
            <h4>Current Address:</h4>
            </th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>
              <p align="right"><asp:HyperLink id="ADDRESS_CurrentImageLink_GoogleMaps_current"  ToolTip="open address in new map window" target="_blank" style="BORDER-LEFT-WIDTH: 0px; BORDER-RIGHT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-TOP-WIDTH: 0px" Text="google maps icon" ImageUrl='images/google_maps48.png' runat="server"/>&nbsp;</p>
            </td>
          </tr>
 
          <tr class="Row">
            <th><strong>ADDRESSEE</strong> </th>
 
            <td colspan="2">&nbsp;<CC:ReportLabel id="ADDRESS_CurrentADDRESSEE" DataType="_Text" SourceType="DBColumn" Source="ADDRESSEE" runat="server"/> &nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th><strong>AGENT</strong> </th>
 
            <td colspan="2">&nbsp;<CC:ReportLabel id="ADDRESS_CurrentAGENT" DataType="_Text" SourceType="DBColumn" Source="AGENT" runat="server"/> &nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th><strong>ADDRESS</strong> </th>
 
            <td colspan="2">&nbsp;<CC:ReportLabel id="ADDRESS_CurrentADDR1" DataType="_Text" SourceType="DBColumn" Source="ADDR1" runat="server"/> &nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th>&nbsp;</th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_CurrentADDR2" DataType="_Text" SourceType="DBColumn" Source="ADDR2" runat="server"/> </td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th><strong>SUBURB/TOWN</strong> </th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_CurrentSUBURB_TOWN" DataType="_Text" SourceType="DBColumn" Source="SUBURB_TOWN" runat="server"/> </td> 
            <td><strong>STATE</strong> </td> 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_CurrentSTATE" DataType="_Text" SourceType="DBColumn" Source="STATE" runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th><strong>POSTCODE</strong> </th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_CurrentPOSTCODE" DataType="_Text" SourceType="DBColumn" Source="POSTCODE" runat="server"/></td> 
            <td><strong>COUNTRY</strong> </td> 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_CurrentCOUNTRY" DataType="_Text" SourceType="DBColumn" Source="COUNTRY" runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th><strong>HOME PHONE</strong></th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_CurrentPHONE_A" DataType="_Text" SourceType="DBColumn" Source="PHONE_A" runat="server"/> </td> 
            <td><strong>MOBILE/PHONE 2</strong></td> 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_CurrentPHONE_B" DataType="_Text" SourceType="DBColumn" Source="PHONE_B" runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th><strong>FAX</strong> </th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_CurrentFAX" DataType="_Text" SourceType="DBColumn" Source="FAX" runat="server"/> </td> 
            <td><strong>STUDENT EMAIL ADDRESS</strong> </td> 
            <td>&nbsp;<a id="ADDRESS_CurrentEMAIL_ADDRESS" href="" runat="server"  ><%#(CType(Container.DataItem,ADDRESS_CurrentItem)).EMAIL_ADDRESS.GetFormattedValue()%></a></td>
          </tr>
 
          <tr class="Row">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th>LAST_ALTERED_BY / DATE</th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_CurrentLAST_ALTERED_BY" DataType="_Text" SourceType="DBColumn" Source="LAST_ALTERED_BY" runat="server"/> / <CC:ReportLabel id="ADDRESS_CurrentLAST_ALTERED_DATE" Format="dd/mm/yyyy H:nn" DataType="_Date" SourceType="DBColumn" Source="LAST_ALTERED_DATE" runat="server"/></td> 
            <td>ADDRESS_ID </td> 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_CurrentADDRESS_ID" DataType="_Float" SourceType="DBColumn" Source="ADDRESS_ID" runat="server"/></td>
          </tr>
 </Template></Section>
<Section name="Report_Footer" Visible="True" Height="0"><Template>
          
	<asp:PlaceHolder id="ADDRESS_CurrentNoRecords" Visible="true" runat="server">
	
          <tr class="NoRecords">
            <td colspan="4">No Current Address Record for this Student</td>
          </tr>
 
	</asp:PlaceHolder>
	</Template></Section>
<Section name="Page_Footer" Visible="True" Height="0"><Template></Template></Section>

  <LayoutFooterTemplate>
        </table>
      </td>
    </tr>
  </table>
  </LayoutFooterTemplate>
</CC:Report>

</div>
<br>
<div align="center">
  
<CC:Report id="ADDRESS_Original" WebPageSize="40" PageSizeLimit="100" runat="server">
  <LayoutHeaderTemplate>
  <table cellspacing="0" cellpadding="0" width="90%" border="0">
    <tr>
      <td valign="top">
        <table class="Grid" cellspacing="0" cellpadding="0">
          </LayoutHeaderTemplate>
  <Section name="Report_Header" Visible="True" Height="0"><Template></Template></Section>
<Section name="Page_Header" Visible="True" Height="0"><Template></Template></Section>
<Section name="Detail" Visible="True" Height="16"><Template>
          <tr class="Row">
            <th>
            <h4>S.A.C. Address:</h4>
            </th>
 
            <td>&nbsp;<em>(added May-2009, changed to SAC Address July 2014 - in rare cases the 'Original Address' may be displayed. Read and interpret appropriately)</em></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th><strong>ADDRESSEE</strong> </th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_OriginalADDRESSEE" DataType="_Text" SourceType="DBColumn" Source="ADDRESSEE" runat="server"/> </td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th><strong>AGENT</strong> </th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_OriginalAGENT" DataType="_Text" SourceType="DBColumn" Source="AGENT" runat="server"/> </td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th><strong>ADDRESS</strong> </th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_OriginalADDR1" DataType="_Text" SourceType="DBColumn" Source="ADDR1" runat="server"/> </td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th>&nbsp;</th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_OriginalADDR2" DataType="_Text" SourceType="DBColumn" Source="ADDR2" runat="server"/> </td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th><strong>SUBURB/TOWN</strong> </th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_OriginalSUBURB_TOWN" DataType="_Text" SourceType="DBColumn" Source="SUBURB_TOWN" runat="server"/> </td> 
            <td><strong>STATE</strong> </td> 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_OriginalSTATE" DataType="_Text" SourceType="DBColumn" Source="STATE" runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th><strong>POSTCODE</strong> </th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_OriginalPOSTCODE" DataType="_Text" SourceType="DBColumn" Source="POSTCODE" runat="server"/></td> 
            <td><strong>COUNTRY</strong> </td> 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_OriginalCOUNTRY" DataType="_Text" SourceType="DBColumn" Source="COUNTRY" runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th><strong>HOME PHONE</strong></th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_OriginalPHONE_A" DataType="_Text" SourceType="DBColumn" Source="PHONE_A" runat="server"/> </td> 
            <td><strong>MOBILE/PHONE 2</strong></td> 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_OriginalPHONE_B" DataType="_Text" SourceType="DBColumn" Source="PHONE_B" runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th><strong>FAX</strong> </th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_OriginalFAX" DataType="_Text" SourceType="DBColumn" Source="FAX" runat="server"/> </td> 
            <td><strong>EMAIL ADDRESS</strong> </td> 
            <td>&nbsp;<a id="ADDRESS_OriginalEMAIL_ADDRESS" href="" runat="server"  ><%#(CType(Container.DataItem,ADDRESS_OriginalItem)).EMAIL_ADDRESS.GetFormattedValue()%></a></td>
          </tr>
 
          <tr class="Row">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<a id="ADDRESS_OriginalEMAIL_ADDRESS2" href="" runat="server"  ><%#(CType(Container.DataItem,ADDRESS_OriginalItem)).EMAIL_ADDRESS2.GetFormattedValue()%></a></td>
          </tr>
 
          <tr class="Row">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th>LAST_ALTERED_BY / DATE</th>
 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_OriginalLAST_ALTERED_BY" DataType="_Text" SourceType="DBColumn" Source="LAST_ALTERED_BY" runat="server"/> / <CC:ReportLabel id="ADDRESS_OriginalLAST_ALTERED_DATE" Format="dd/mm/yyyy H:nn" DataType="_Date" SourceType="DBColumn" Source="LAST_ALTERED_DATE" runat="server"/></td> 
            <td>ADDRESS_ID </td> 
            <td>&nbsp;<CC:ReportLabel id="ADDRESS_OriginalADDRESS_ID" DataType="_Float" SourceType="DBColumn" Source="ADDRESS_ID" runat="server"/></td>
          </tr>
 </Template></Section>
<Section name="Report_Footer" Visible="True" Height="0"><Template>
          
	<asp:PlaceHolder id="ADDRESS_OriginalNoRecords" Visible="true" runat="server">
	
          <tr class="NoRecords">
            <td colspan="4">No S.A.C. Address / Original Address Record for this Student</td>
          </tr>
 
	</asp:PlaceHolder>
	</Template></Section>
<Section name="Page_Footer" Visible="True" Height="0"><Template></Template></Section>

  <LayoutFooterTemplate>
        </table>
      </td>
    </tr>
  </table>
  </LayoutFooterTemplate>
</CC:Report>

</div>
<p>
<div align="center">
  
<CC:Report id="STUDENT_CENSUS_DATA" WebPageSize="40" PageSizeLimit="100" runat="server">
  <LayoutHeaderTemplate>
  <table cellspacing="0" cellpadding="0" width="90%" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Census</th>
 
            <th width="150">
            <div id="toggle_Census" class="Button" style="WIDTH: 130px; MARGIN: 5px" align="right">
              show/hide Census 
            </div>
            </th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table id="STUDENT_CENSUS_DATA_table" class="Grid" cellspacing="0" cellpadding="0">
          </LayoutHeaderTemplate>
  <Section name="Report_Header" Visible="True" Height="0"><Template></Template></Section>
<Section name="Page_Header" Visible="True" Height="0"><Template></Template></Section>
<Section name="Detail" Visible="True" Height="29"><Template>
          <tr class="Row">
            <th>&nbsp;<strong>Country of Birth:</strong></th>
 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATACOUNTRY_OF_BIRTH" DataType="_Text" SourceType="DBColumn" Source="COUNTRY_OF_BIRTH" runat="server"/> </td> 
            <td>&nbsp;<strong>Date Started in Aust:</strong></td> 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATADATE_STARTED_IN_AUST" Format="dd/mm/yyyy" DataType="_Date" SourceType="DBColumn" Source="DATE_STARTED_IN_AUST" runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th>&nbsp;<strong>Main&nbsp;Language spoken at Home:</strong></th>
 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAFIRST_HOME_LANGUAGE" DataType="_Text" SourceType="DBColumn" Source="FIRST_HOME_LANGUAGE" runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th>&nbsp;<strong>Other Home Language:</strong>&nbsp;</th>
 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAOTHER_HOME_LANGUAGE" DataType="_Text" SourceType="DBColumn" Source="OTHER_HOME_LANGUAGE" runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th>&nbsp;</th>
 
            <td>&nbsp;<strong><u>Mother</u></strong></td> 
            <td>&nbsp;<strong><u>Father</u></strong></td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th><strong>Country of Birth:</strong></th>
 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAMOTHERS_COB" DataType="_Text" SourceType="DBColumn" Source="MOTHERS_COB" EmptyText="Unknown" runat="server"/> </td> 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAFATHERS_COB" DataType="_Text" SourceType="DBColumn" Source="FATHERS_COB" EmptyText="Unknown" runat="server"/></td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th><strong>Main Language:</strong></th>
 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAMOTHER_LANGUAGE" DataType="_Text" SourceType="DBColumn" Source="MOTHER_LANGUAGE" EmptyText="Unknown" runat="server"/> </td> 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAFATHER_LANGUAGE" DataType="_Text" SourceType="DBColumn" Source="FATHER_LANGUAGE" EmptyText="Unknown" runat="server"/></td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th><strong>School Education</strong></th>
 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAMOTHER_EDUCATION_SCHOOL" DataType="_Text" SourceType="DBColumn" Source="MOTHER_EDUCATION_SCHOOL" EmptyText="Unknown" runat="server"/> </td> 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAFATHER_EDUCATION_SCHOOL" DataType="_Text" SourceType="DBColumn" Source="FATHER_EDUCATION_SCHOOL" EmptyText="Unknown" runat="server"/></td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th><strong>Post-School Education:</strong></th>
 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAMOTHER_EDUCATION_NONSCHOOL" DataType="_Text" SourceType="DBColumn" Source="MOTHER_EDUCATION_NONSCHOOL" EmptyText="Unknown" runat="server"/> </td> 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAFATHER_EDUCATION_NONSCHOOL" DataType="_Text" SourceType="DBColumn" Source="FATHER_EDUCATION_NONSCHOOL" EmptyText="Unknown" runat="server"/></td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th>
            <p><strong>Occupation Group:</strong></p>
            </th>
 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAMOTHER_OCCUPATIONGROUP" DataType="_Text" SourceType="DBColumn" Source="MOTHER_OCCUPATIONGROUP" EmptyText="Unknown" runat="server"/> </td> 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAFATHER_OCCUPATIONGROUP" DataType="_Text" SourceType="DBColumn" Source="FATHER_OCCUPATIONGROUP" EmptyText="Unknown" runat="server"/></td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th><strong>Allowance Code:</strong></th>
 
            <td><CC:ReportLabel id="STUDENT_CENSUS_DATAALLOWANCE_TITLE" DataType="_Text" SourceType="DBColumn" Source="ALLOWANCE_TITLE" runat="server"/> </td> 
            <td>
              <p>&nbsp;<strong>Koori/Torres:</strong></p>
            </td> 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAKOORITORRESFLAG" DataType="_Text" SourceType="DBColumn" Source="KOORITORRESFLAG" runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th><strong>Residential Status:</strong></th>
 
            <td><CC:ReportLabel id="STUDENT_CENSUS_DATARESIDENTIAL_STATUS" DataType="_Text" SourceType="DBColumn" Source="RESIDENTIAL_STATUS" runat="server"/> </td> 
            <td>&nbsp;<strong>Date Arrived in Aust:</strong></td> 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATADATE_ARRIVED_IN_AUST" Format="dd/mm/yyyy" DataType="_Date" SourceType="DBColumn" Source="DATE_ARRIVED_IN_AUST" runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th><strong>Visa Sub Class:</strong></th>
 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAVISA_SUB_CLASS" DataType="_Float" SourceType="DBColumn" Source="VISA_SUB_CLASS" runat="server"/> </td> 
            <td>&nbsp;<strong>Visa Stat Code:</strong></td> 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAVISA_STATISTICAL_CODE" DataType="_Text" SourceType="DBColumn" Source="VISA_STATISTICAL_CODE" runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th><strong>Previous School:</strong>&nbsp;</th>
 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAPREVIOUS_SCHOOL_ID" DataType="_Float" SourceType="DBColumn" Source="PREVIOUS_SCHOOL_ID" runat="server"/> </td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th>
            <p><strong>Family Occupation Group:</strong></p>
            </th>
 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAFAMILY_OSG" DataType="_Float" SourceType="DBColumn" Source="FAMILY_OSG" runat="server"/> </td> 
            <td>&nbsp;<strong>Household Status:</strong></td> 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAHOUSEHOLD_STATUS" DataType="_Text" SourceType="DBColumn" Source="HOUSEHOLD_STATUS" runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th><strong>Disability ID:</strong></th>
 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATADISABILITY_ID" DataType="_Float" SourceType="DBColumn" Source="DISABILITY_ID" runat="server"/> </td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th><strong>Repeating Year:</strong></th>
 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAREPEATING_YEAR" DataType="_Text" SourceType="DBColumn" Source="REPEATING_YEAR" runat="server"/> </td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th>
            <p><strong>Other School Time Fraction:</strong></p>
            </th>
 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATAOTHER_SCHOOL_TF" DataType="_Float" SourceType="DBColumn" Source="OTHER_SCHOOL_TF" runat="server"/> </td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th>LAST_ALTERED_BY / DATE</th>
 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_CENSUS_DATALAST_ALTERED_BY" DataType="_Text" SourceType="DBColumn" Source="LAST_ALTERED_BY" runat="server"/> / <CC:ReportLabel id="STUDENT_CENSUS_DATALAST_ALTERED_DATE" Format="dd/mm/yyyy H:nn" DataType="_Date" SourceType="DBColumn" Source="LAST_ALTERED_DATE" runat="server"/></td> 
            <td><CC:ReportLabel id="STUDENT_CENSUS_DATASTUDENT_ID" DataType="_Float" SourceType="DBColumn" Source="STUDENT_ID" runat="server"/></td> 
            <td>&nbsp;</td>
          </tr>
 </Template></Section>
<Section name="Report_Footer" Visible="True" Height="0"><Template>
          
	<asp:PlaceHolder id="STUDENT_CENSUS_DATANoRecords" Visible="true" runat="server">
	
          <tr class="NoRecords">
            <td colspan="4">No Census Data Record</td>
          </tr>
 
	</asp:PlaceHolder>
	</Template></Section>
<Section name="Page_Footer" Visible="True" Height="0"><Template></Template></Section>

  <LayoutFooterTemplate>
        </table>
      </td>
    </tr>
  </table>
  </LayoutFooterTemplate>
</CC:Report>

</div>
<p>
<div align="center">
  
<CC:Report id="STUDENT_EQUIPMENT" WebPageSize="40" PageSizeLimit="100" runat="server">
  <LayoutHeaderTemplate>
  <table cellspacing="0" cellpadding="0" width="90%" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Equipment </th>
 
            <th width="150">
            <div id="toggle_Equipment" class="Button" style="WIDTH: 130px; MARGIN: 5px" align="right">
              show/hide Equipment 
            </div>
            </th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table id="STUDENT_EQUIPMENT_table" class="Grid" cellspacing="0" cellpadding="0">
          </LayoutHeaderTemplate>
  <Section name="Report_Header" Visible="True" Height="0"><Template></Template></Section>
<Section name="Page_Header" Visible="True" Height="0"><Template></Template></Section>
<Section name="Detail" Visible="True" Height="7"><Template>
          <tr class="Row">
            <th>Permission for teachers to access Student WORK EXAMPLES&nbsp;</th>
 
            <td>&nbsp;<asp:Literal id="STUDENT_EQUIPMENTACCESS_WORKEXAMPLES" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_EQUIPMENTItem)).ACCESS_WORKEXAMPLES.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
          </tr>
 
          <tr class="Row">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th>Student&nbsp;has Access to a COMPUTER:&nbsp;</th>
 
            <td>&nbsp;<asp:Literal id="STUDENT_EQUIPMENTACCESS_COMPUTER" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_EQUIPMENTItem)).ACCESS_COMPUTER.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<em>(new for 2010)</em>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th>Student&nbsp;has Access to&nbsp;the INTERNET:&nbsp;</th>
 
            <td>&nbsp;<asp:Literal id="STUDENT_EQUIPMENTACCESS_INTERNET" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_EQUIPMENTItem)).ACCESS_INTERNET.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/><em>&nbsp;(new for 2010)</em>&nbsp;</td>
          </tr>
 
          <tr class="Row">
            <th>Student has Digitial Education Revolution PC?&nbsp;<img onclick="javascript:alert('Student has DER or DECV Computer (See PC Support for details)');return false;" id="has_der_pc_info_icon" title="Student has DER or DECV Computer (See PC Support) April 2009" border="0" name="DERPCInfoIcon" alt="DER Computer type" src="images/icon_info.gif"></th>
 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_EQUIPMENTHAS_DER_PC" DataType="_Text" SourceType="DBColumn" Source="HAS_DER_PC" runat="server"/> </td>
          </tr>
 
          <tr class="Row">
            <th>&nbsp;</th>
 
            <td><em>&nbsp;N:None; Y:Yes (Own or Full access); L:Limited (Shared or restricted); U:Unknown (default)</em></td>
          </tr>
 
          <tr class="Row">
            <th>LAST_ALTERED_BY / DATE</th>
 
            <td>&nbsp;<CC:ReportLabel id="STUDENT_EQUIPMENTLAST_ALTERED_BY" DataType="_Text" SourceType="DBColumn" Source="LAST_ALTERED_BY" runat="server"/>&nbsp;/ <CC:ReportLabel id="STUDENT_EQUIPMENTLAST_ALTERED_DATE" Format="dd/mm/yyyy H:nn" DataType="_Date" SourceType="DBColumn" Source="LAST_ALTERED_DATE" runat="server"/>&nbsp;<CC:ReportLabel id="STUDENT_EQUIPMENTSTUDENT_ID" DataType="_Float" SourceType="DBColumn" Source="STUDENT_ID" runat="server"/></td>
          </tr>
 </Template></Section>
<Section name="Report_Footer" Visible="True" Height="0"><Template>
          
	<asp:PlaceHolder id="STUDENT_EQUIPMENTNoRecords" Visible="true" runat="server">
	
          <tr class="NoRecords">
            <td colspan="2">No Student Equipment found</td>
          </tr>
 
	</asp:PlaceHolder>
	</Template></Section>
<Section name="Page_Footer" Visible="True" Height="0"><Template></Template></Section>

  <LayoutFooterTemplate>
        </table>
      </td>
    </tr>
  </table>
  </LayoutFooterTemplate>
</CC:Report>

</div>
<br>
<div align="center">
  
<CC:Report id="viewStudentSummary_Medica" WebPageSize="40" PageSizeLimit="100" runat="server">
  <LayoutHeaderTemplate>
  <div align="left">
    <table cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
      <tr>
        <td valign="top">
          <table class="Header" cellspacing="0" cellpadding="0" border="0">
            <tr>
              <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
              <th>Medical</th>
 
              <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
            </tr>
          </table>
 
          <table class="Grid" cellspacing="0" cellpadding="0">
            </LayoutHeaderTemplate>
  <Section name="Report_Header" Visible="True" Height="0"><Template></Template></Section>
<Section name="Page_Header" Visible="True" Height="0"><Template></Template></Section>
<Section name="Detail" Visible="True" Height="9"><Template>
            <tr class="Row">
              <th><strong>Immunisation Certificate</strong> </th>
 
              <td>&nbsp;<CC:ReportLabel id="viewStudentSummary_Medicaimmun_certificate_desc" DataType="_Text" SourceType="DBColumn" Source="immun_certificate_desc" runat="server"/> </td>
            </tr>
 
            <tr class="Row">
              <th><strong>Immunisations</strong> </th>
 
              <td>&nbsp;Diptheria:&nbsp;<CC:ReportLabel id="viewStudentSummary_Medicaimmun_diptheria_desc" DataType="_Text" SourceType="DBColumn" Source="immun_diptheria_desc" runat="server"/>&nbsp; Tetanus: <CC:ReportLabel id="viewStudentSummary_Medicaimmun_tetanus_desc" DataType="_Text" SourceType="DBColumn" Source="immun_tetanus_desc" runat="server"/>&nbsp;&nbsp; Polio:&nbsp;<CC:ReportLabel id="viewStudentSummary_Medicaimmun_polio_desc" DataType="_Text" SourceType="DBColumn" Source="immun_polio_desc" runat="server"/>&nbsp;Measles:&nbsp;<CC:ReportLabel id="viewStudentSummary_Medicaimmun_measles_desc" DataType="_Text" SourceType="DBColumn" Source="immun_measles_desc" runat="server"/>&nbsp; Mumps:<CC:ReportLabel id="viewStudentSummary_Medicaimmun_mumps_desc" DataType="_Text" SourceType="DBColumn" Source="immun_mumps_desc" runat="server"/></td>
            </tr>
 
            <tr class="Row">
              <th>&nbsp;</th>
 
              <td>&nbsp;</td>
            </tr>
 
            <tr class="Row">
              <th><strong>Allergies?</strong>&nbsp;</th>
 
              <td>&nbsp;<CC:ReportLabel id="viewStudentSummary_Medicaallergies_flag_desc" DataType="_Text" SourceType="DBColumn" Source="allergies_flag_desc" runat="server"/><em>&nbsp;(if Yes, check Enrolment form)</em></td>
            </tr>
 
            <tr class="Row">
              <th><strong>Anaphylaxis?</strong>&nbsp;</th>
 
              <td>&nbsp;<CC:ReportLabel id="viewStudentSummary_Medicaanaphylaxis_flag_desc" DataType="_Text" SourceType="DBColumn" Source="anaphylaxis_flag_desc" runat="server"/> <asp:Image id="viewStudentSummary_Medicaanaphylaxis_warning"  AlternateText="Anaphylaxis warning icon" runat="server"/><em>&nbsp;(if Yes, check Enrolment form)</em></td>
            </tr>
 
            <tr class="Row">
              <th><strong>Diagnosed Condition?</strong>&nbsp;</th>
 
              <td>&nbsp;<CC:ReportLabel id="viewStudentSummary_MedicaHASOTHERCONDITIONS_desc" DataType="_Text" SourceType="DBColumn" Source="HASOTHERCONDITIONS_desc" runat="server"/>&nbsp;<CC:ReportLabel id="viewStudentSummary_MedicaOTHERCONDITIONS" DataType="_Text" SourceType="DBColumn" Source="OTHERCONDITIONS" ContentType="Html" EmptyText="&lt;em&gt;none provided&lt;/em&gt;" runat="server"/>&nbsp;<CC:ReportLabel id="viewStudentSummary_MedicaDIAGNOSED_CONDITION" DataType="_Text" SourceType="DBColumn" Source="DIAGNOSED_CONDITION" EmptyText="None" runat="server"/>&nbsp;</td>
            </tr>
 
            <tr class="Row">
              <th>Medical Conditions, if any&nbsp;(self-diagnosed)&nbsp;</th>
 
              <td><CC:ReportLabel id="viewStudentSummary_Medicaall_medical_conditions_desc" DataType="_Text" SourceType="DBColumn" Source="all_medical_conditions_desc" ContentType="Html" EmptyText="&lt;em&gt;none&lt;/em&gt;" runat="server"/></td>
            </tr>
 
            <tr class="Row">
              <th>&nbsp;</th>
 
              <td>&nbsp;</td>
            </tr>
 
            <tr class="Row">
              <th>LAST_ALTERED_BY / DATE</th>
 
              <td>&nbsp;<CC:ReportLabel id="viewStudentSummary_MedicaLAST_ALTERED_BY" DataType="_Text" SourceType="DBColumn" Source="LAST_ALTERED_BY" runat="server"/>&nbsp;/ &nbsp;<CC:ReportLabel id="viewStudentSummary_MedicaLAST_ALTERED_DATE" Format="dd/mm/yyyy H:nn" DataType="_Date" SourceType="DBColumn" Source="LAST_ALTERED_DATE" runat="server"/>&nbsp; <CC:ReportLabel id="viewStudentSummary_MedicaSTUDENT_ID" DataType="_Float" SourceType="DBColumn" Source="STUDENT_ID" runat="server"/></td>
            </tr>
 </Template></Section>
<Section name="Report_Footer" Visible="True" Height="0"><Template>
            
	<asp:PlaceHolder id="viewStudentSummary_MedicaNoRecords" Visible="true" runat="server">
	
            <tr class="NoRecords">
              <td colspan="2">No Medical Details found</td>
            </tr>
 
	</asp:PlaceHolder>
	</Template></Section>
<Section name="Page_Footer" Visible="True" Height="0"><Template></Template></Section>

  <LayoutFooterTemplate>
          </table>
        </td>
      </tr>
    </table>
  </div>
  <div align="left">
  </div>
  </LayoutFooterTemplate>
</CC:Report>

</div>
<br>
<br>
<br>
<script language="JavaScript" src="js/jquery_min.js" type="text/javascript" charset="windows-1252"></script>
<asp:Literal id="lblModified" runat="server"/>
<script language="JavaScript" src="js/jquery.tablesorter.min.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
    // -------------------------
    // ERA: using jquery, attach the toggles to the toggle_Census and toggle_Equipment links
                $('div#toggle_Enrolment_Misc').click(function() {
                $('table#viewStudentSummary_Enrolm_table').slideToggle('slow');
        });
        $('div#toggle_Census').click(function() {
                $('table#STUDENT_CENSUS_DATA_table').slideToggle('slow');
        });
        $('div#toggle_Equipment').click(function() {
                $('table#STUDENT_EQUIPMENT_table').slideToggle('slow');
        });

                $('table#viewStudentSummary_Enrolm_table').toggle(false);
        $('table#STUDENT_CENSUS_DATA_table').toggle(false);
        $('table#STUDENT_EQUIPMENT_table').toggle(false);

        // and let's show/hide all comments after first 5
        var numShown = 6; // Initial rows shown & index
        var numMore = 10; // Increment
        var numRows = $('#STUDENT_COMMENTS_table').find('tr').length; // Total # rows

                // Hide rows and add clickable div
                $('#STUDENT_COMMENTS_table')
                        .find('tr:gt(' + (numShown - 1) + ')').hide().end()
                        .after('<div id="more" class="Button"><br>Show <span>' + numMore + '</span> More Comments<br></div>');

                $('#more').click(function(){
                        numShown = numShown + numMore;
                        // no more show more if done
                        if ( numShown >= numRows ) $('#more').remove();
                        // change rows remaining if less than increment
                        if ( numRows - numShown < numMore ) $('#more span').html(numRows - numShown);
                        $('#STUDENT_COMMENTS_table').find('tr:lt('+numShown+')').show();
                })

    // -------------------------
    // -------------------------
    // Oct-2018|EA| add table sorting on subjects
    $("table#SubjectList").tablesorter({cssHeader:"ts_header", dateFormat: "uk"}); 
    
    // -------------------------
</script>
<script type="text/javascript">
      if (window.navigator.userAgent.indexOf("Edg/") === -1)
      {
         var element = document.getElementById("lblStudentFolderBrowserNotice");
         element.style.display = "inline-block";
      }
   </script>

</form>
</body>
</html>

<!--End ASPX page-->

