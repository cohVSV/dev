<!--ASPX page @1-7C7C1E18-->
    <%@ Page language="vb" CodeFile="Menu.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Menu.MenuPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Menu" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Menu</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<style type="text/css">
<!--
A:HOVER  { background-color: #DADADA; }
-->
</style>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_MenuSearch_OnLoad @75-9E80A8FC
function page_MenuSearch_OnLoad(form)
{
    var result;
//End page_MenuSearch_OnLoad

//Set Focus @85-3CF9F55F
    if (theForm.MenuSearchSTUDENT_ID) theForm.MenuSearchSTUDENT_ID.focus();
//End Set Focus

//Close page_MenuSearch_OnLoad @75-BC33A33A
    return result;
}
//End Close page_MenuSearch_OnLoad

//bind_events @1-7907F0B3
function bind_events() {
    if(document.getElementById("MenuSearchHolder"))
    addEventHandler("MenuSearch","load",page_MenuSearch_OnLoad);
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

window.onload = bind_events;

//End CCS script
</script>

</head>
<body>
<form runat="server">


<DECV_PROD2007:Header id="Header" runat="server"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
<table cellspacing="7" cellpadding="2" width="60%" align="center" bgcolor="#ffffff" border="0">
    <tr bgcolor="#ffffff" valign="top">
        <td colspan="3">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                    <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                    <th>APPLICATION MENU</th>
 
                    <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                </tr>
            </table>
        </td>
    </tr>
 
    <tr>
        <td>&nbsp; 
            
  <span id="MenuSearchHolder" runat="server">
    
            

                <table>
                    
  <asp:PlaceHolder id="MenuSearchError" visible="False" runat="server">
  
                    <tr>
                        <td colspan="2"><font color="#ff0000"><asp:Label ID="MenuSearchErrorLabel" runat="server"/></font></td>
  </asp:PlaceHolder>
  
                        <tr>
                            <th>Student ID</th>
 
                            <td><asp:TextBox id="MenuSearchSTUDENT_ID" onfocus="this.select();" maxlength="6" Columns="6"	runat="server"/>
                                <input id='MenuSearchButton_DoSearch' type="submit" class="Button" value="Show Summary" OnServerClick='MenuSearch_Search' runat="server"/><asp:TextBox id="MenuSearchENROLMENT_YEAR" style="DISPLAY: none" Columns="4"	runat="server"/></td>
                        </tr>
                    </table>
                

                
  </span>
  </td> 
            <td>&nbsp;</td> 
            <td>
                <p align="right"><a href="OnlineHelp/index.html" title="show help" target="_blank"><img border="0" alt="show help" src="images/help.png" align="left"></a>&nbsp;&nbsp;User Login: <asp:Literal id="lblUserID" runat="server"/> </p>
 
                <p align="right">Group:&nbsp;<asp:Literal id="lblUserLevel" runat="server"/>&nbsp;<asp:Literal id="lblAccessGroups" runat="server"/></p>
            </td>
        </tr>
 
        <tr>
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>
                <p align="right">&nbsp;</p>
            </td>
        </tr>
 
        <tr>
            <td>&nbsp;<strong><font size="2" face="Verdana"><asp:Literal id="lblHeadingEnrolment" runat="server"/></font></strong></td> 
            <td>&nbsp;</td> 
            <td><strong><font size="2" face="Verdana"><asp:Literal id="lblHeadingDespatch" runat="server"/></font></strong></td>
        </tr>
 
        <tr>
            <td>&nbsp;<a id="link_EnrolNewStudent" href="" runat="server"  >Add New Enrolment</a></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<a id="linkdespatch_1" href="" runat="server"  >Assignment Receipts</a></td>
        </tr>
 
        <tr>
            <td>&nbsp;<a id="link_ModifyEnrolmentDetails" href="" runat="server"  >Modify/View Enrolment Details</a></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<a id="linkdespatch_2" href="" runat="server"  >Assignment Returns</a></td>
        </tr>
 
        <tr>
            <td>&nbsp;<a id="link_TeleformsEnrolments" href="" runat="server"  >Online Enrolments Status</a></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<a id="linkdespatch_3" href="" runat="server"  >Despatch Run Update by Year Level</a></td>
        </tr>
 
        <tr>
            <td>&nbsp;<a id="link_VSREnrolments" href="" runat="server"  >VSR Enrolments</a></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<a id="linkdespatch_4" href="" runat="server"  >Despatch Run Update by Enrolment Date</a></td>
        </tr>
 
        <tr>
            <td>&nbsp;<a id="link_ModifyEnrolmentDetails_AddressSearch" href="" runat="server"  >Contact Details Search</a></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<a id="linkdespatch_5" href="" runat="server"  >Despatch Assignment Maintenance</a></td>
        </tr>
 
        <tr>
            <td>&nbsp;<a id="link_SchoolEdit" href="" runat="server"  >Update School Address</a></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<a id="linkdespatch_6" href="" runat="server"  >Student Exit Tracking</a></td>
        </tr>
 
        <tr>
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
        </tr>
 
        <tr>
            <td><strong><font size="2" face="Verdana"><asp:Literal id="lblHeadingTeachers" runat="server"/></font></strong></td> 
            <td><strong><font size="2" face="Verdana"><asp:Literal id="lblHeadingCoords" runat="server"/></font></strong></td> 
            <td>&nbsp;</td>
        </tr>
 
        <tr>
            <td>&nbsp;<a id="link_TeacgerAllocations" href="" runat="server"  >Teacher Allocations</a></td> 
            <td nowrap>&nbsp;<a id="link_GreenLetters" href="" runat="server"  >Manage Green Letters</a></td> 
            <td>&nbsp;<a id="link_ViewStaffInductions" href="" runat="server"  >Modify / View Induction Attendance</a></td>
        </tr>
 
        <tr>
            <td>&nbsp;<a id="link_SubjectWithdrawals" href="" runat="server"  >Subject Withdrawals</a></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<a id="link_ManageStaffInductions1" href="" runat="server"  >Manage Staff Inductions</a></td>
        </tr>
 
        <tr>
            <td>&nbsp;<a id="link_StudentAmendments" href="" runat="server"  >Student Amendments</a></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
        </tr>
 
        <tr>
            <td>&nbsp;<a id="link_TeacherMyPastoral" href="" runat="server"  >My Advisory Group</a></td> 
            <td>&nbsp;<strong><font size="2" face="Verdana">LMS Management</font></strong></td> 
            <td>&nbsp;<a id="link_ManageSubjectTeacherAllocations" href="" runat="server"  >Manage Subject Teacher Allocations</a></td>
        </tr>
 
        <tr>
            <td>&nbsp;<a id="link_TeacherMyClassLists" href="" runat="server"  >My Class Lists</a></td> 
            <td>&nbsp;<a id="link_ManageSubjectTeacherCourseDevs" href="" runat="server"  >Manage Course Devs</a></td> 
            <td>&nbsp;<a id="link_ManageSubjectTeacherCRT" href="" runat="server"  >Manage CRT Subject Teachers</a></td>
        </tr>
 
        <tr>
            <td>&nbsp;<a id="link_TeacherMyClassListsExtender" href="" runat="server"  >Class List - Extender</a> </td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<a id="link_UnallocatedStudentTeachers" href="" runat="server"  >Unallocated Students</a></td>
        </tr>
 
        <tr>
            <td>&nbsp; 
                <a id="link_TeacherMyDefaulting" href="" runat="server"   Visible="False">My Defaulting Students</a></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<a id="Link_ManageLAd" href="" runat="server"  >Manage LAd Allocations</a></td>
        </tr>
 
        <tr>
            <td>&nbsp;<a id="link_TeacherMyCommentSearch" href="" title="search Comments I have made" runat="server"  >My Comment Search</a></td> 
            <td>&nbsp;</td> 
            <td>&nbsp; 
                <a id="link_ManageAssignmentDescriptions" href="" runat="server"   Visible="False">Manage Assignment Descriptions</a></td>
        </tr>
 
        <tr>
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp; 
                <a id="link_TimetableIntegration" href="" runat="server"   Visible="False">Manage Timetable Integration</a></td>
        </tr>
 
        <tr>
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>
                <div align="right">
                    &nbsp;
                </div>
            </td>
        </tr>
    </table>
    &nbsp; 
    <p>
    
	<asp:PlaceHolder id="Panel_controltables" Visible="true" runat="server">
	&nbsp; 
    <table cellpadding="5" width="60%" align="center" bgcolor="#ffffff" border="0">
        <tr bgcolor="#4060a0">
            <td colspan="5">&nbsp;<strong><font color="#ffffff">Control Table List</font></strong>&nbsp; &nbsp; </td>
        </tr>
 
        <tr>
            <td width="30%"><a id="SCHOOL_list" href="" runat="server"  >School</a></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<a id="ASSIGNMENT_link" href="" runat="server"  >Assignment</a></td> 
            <td>&nbsp;<a id="COUNTRY_OF_BIRT_list" href="" runat="server"  >Country of Birth</a></td> 
            <td>&nbsp;<a id="COMMENT_TYPE_maint" href="" runat="server"  >Comment Types</a></td>
        </tr>
 
        <tr>
            <td><a id="STAFF_list" href="" runat="server"  >Staff</a></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<a id="CONTRIBUTION_list" href="" runat="server"  >Contribution</a></td> 
            <td>&nbsp;<a id="GOVERNMENT_ALLO_list" href="" runat="server"  >Government Allowance</a></td> 
            <td>&nbsp;</td>
        </tr>
 
        <tr>
            <td><a id="Link5" href="" runat="server"  >Subject</a>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<a id="ENROLMENT_CATEG_list" href="" runat="server"  >Enrolment Category</a></td> 
            <td>&nbsp;<a id="KEY_LEARNING_AR_list" href="" runat="server"  >Key Learning Area</a></td> 
            <td>&nbsp;</td>
        </tr>
 
        <tr>
            <td></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<a id="PROGRESS_CODE_list" href="" runat="server"  >Progress Code</a></td> 
            <td>&nbsp;<a id="LANGUAGE_list" href="" runat="server"  >Language</a></td> 
            <td>&nbsp;</td>
        </tr>
 
        <tr>
            <td><a id="STAFF_STUDENT_SUPERVISORS_link" href="" title="aka Year Level Coordinators" runat="server"  >Student Supervisors</a>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<a id="REGION_list" href="" runat="server"  >Region</a></td> 
            <td>&nbsp;<a id="SCHOOL_TYPE_list" href="" runat="server"  >School Type</a></td> 
            <td>&nbsp;</td>
        </tr>
 
        <tr>
            <td><a id="link_ManageStaffInductions" href="" runat="server"  >Manage Staff Inductions</a></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<a id="TXN_CODE_list" href="" runat="server"  >Transaction Code</a></td> 
            <td>&nbsp;<a id="FTE_RULES_list" href="" runat="server"  >FTE Rules</a></td> 
            <td>&nbsp;</td>
        </tr>
 
        <tr>
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<a id="WITHDRAWAL_REAS_list" href="" runat="server"  >Withdrawal Reason</a></td> 
            <td>&nbsp;<a id="WITHDRAWAL_EXIT_list" href="" runat="server"  >Withdrawal Exit Destination</a></td> 
            <td>&nbsp;</td>
        </tr>
 
        <tr>
            <td>&nbsp;<asp:Literal id="lblLastLogin" runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<a id="MODULES_REF_link" href="" runat="server"  >Module Codes</a></td> 
            <td>&nbsp;</td>
        </tr>
 
        <tr>
            <td>&nbsp;<a id="Link4" href="" style="COLOR: rgb(240,160,32)" runat="server"  >Update&nbsp;Utilities</a></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;<asp:Literal id="lblSMTP_Server" runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
        </tr>
    </table>
    
	</asp:PlaceHolder>
	</p>
    <p><DECV_PROD2007:Footer id="Footer" runat="server"/> </p>
    
</form>
</body>
</html>

<!--End ASPX page-->

