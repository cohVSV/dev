<!--ASPX page @1-D2B144CE-->
    <%@ Page language="vb" CodeFile="Student_ModuleReporting.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_ModuleReporting.Student_ModuleReportingPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_ModuleReporting" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 5.1.0.18696"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Module Reports</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
<style type="text/css">
<!--
SPAN.ungraded  { font-weight: bold; color: #FFFFFF; background-color: #FF0000; }
-->
</style>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p align="center">Back to:&nbsp; <a id="link_Menu" href="" class="Button" runat="server"  >Main Menu</a>|&nbsp;&nbsp;<a id="Link_SearchRequest" href="" class="Button" runat="server"  >Search Request</a>|&nbsp;&nbsp;<a id="link_Assignments" href="" class="Button" runat="server"  >Assignments</a>| <a id="Link10" href="" class="Button" runat="server"  >SMS</a> |&nbsp;<a id="Link6" href="" class="Button" runat="server"  >Future Intentions</a> | &nbsp; <a id="Link5" href="" class="Button" runat="server"  >Comments</a><br>
<br>
<p><a href="OnlineHelp/Assignment%20Edit%20Return%20Details/Assignment_EditReturnDetails.html" title="show help for this page" target="_blank"><strong></strong></a>&nbsp; 

	<asp:PlaceHolder id="Panel_MenuStudentMaintain" Visible="false" runat="server">
	<DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/>&nbsp;&nbsp;&nbsp;
	</asp:PlaceHolder>
	</p>
<p align="center"><a id="Link_Backtosummary" href="" class="Button" runat="server"  >Back to Summary</a>|&nbsp;&nbsp;<a id="Link_BacktoPastoralList" href="" class="Button" runat="server"  >Back to Student Support Group List</a></p>
<p align="right"><strong>Looking for Previous Years? </strong><a id="linkExternalReport" href="" title="open in new window" class="Button" target="_blank" runat="server"  >click here</a> <br>

<CC:Report id="SCAFFOLD_MODULE_GRADE_SCA" WebPageSize="200" PageSizeLimit="200" runat="server">
  <LayoutHeaderTemplate>
<table class="MainTable" cellspacing="0" cellpadding="0" width="90%" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>Module Reports (Current Enrolment Year)</th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        </LayoutHeaderTemplate>
  <Section name="Report_Header" Visible="True" Height="0"><Template></Template></Section>
<Section name="Page_Header" Visible="True" Height="0"><Template></Template></Section>
<Section name="Page_Footer" Visible="True" Height="1"><Template>
        <tr class="Footer">
          <td colspan="5">
            
<CC:Navigator id="NavigatorNavigator"  runat="server"><span class="Navigator">
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img src="Styles/Blueprint/Images/First.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="FirstOff" runat="server"><img src="Styles/Blueprint/Images/FirstOff.gif"></CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img src="Styles/Blueprint/Images/Prev.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOff" runat="server"><img src="Styles/Blueprint/Images/PrevOff.gif"></CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %> of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img src="Styles/Blueprint/Images/Next.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="NextOff" runat="server"><img src="Styles/Blueprint/Images/NextOff.gif"></CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img src="Styles/Blueprint/Images/Last.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOff" runat="server"><img src="Styles/Blueprint/Images/LastOff.gif"></CC:NavigatorItem></span></CC:Navigator>
</td>
        </tr>
 </Template></Section>
<Section name="SCAFFOLD_USER_student_id_Header" Visible="True" Height="1"><Template>
        <tr class="GroupCaption">
          <th colspan="5">Student Id: <CC:ReportLabel id="SCAFFOLD_MODULE_GRADE_SCASCAFFOLD_USER_student_firstname" DataType="_Text" SourceType="DBColumn" Source="SCAFFOLD_USER_student_firstname" runat="server"/>&nbsp;<CC:ReportLabel id="SCAFFOLD_MODULE_GRADE_SCASCAFFOLD_USER_student_lastname" DataType="_Text" SourceType="DBColumn" Source="SCAFFOLD_USER_student_lastname" runat="server"/>&nbsp;<CC:ReportLabel id="SCAFFOLD_MODULE_GRADE_SCASCAFFOLD_USER_student_id" DataType="_Text" SourceType="DBColumn" Source="SCAFFOLD_USER_student_id" runat="server"/> </th>
        </tr>
 </Template></Section>
<Section name="shortname_Header" Visible="True" Height="2"><Template>
        <tr class="GroupCaption">
          <th colspan="5">Subject:&nbsp;<CC:ReportLabel id="SCAFFOLD_MODULE_GRADE_SCAfullname" DataType="_Text" SourceType="DBColumn" Source="fullname" ContentType="Html" runat="server"/>&nbsp;&nbsp;(<CC:ReportLabel id="SCAFFOLD_MODULE_GRADE_SCAshortname" DataType="_Text" SourceType="DBColumn" Source="shortname" runat="server"/>)</th>
        </tr>
 
        <tr class="Caption">
          <th>Module Name </th>
 
          <th>Grade </th>
 
          <th>Feedback </th>
 
          <th>Teacher</th>
 
          <th>Date Graded</th>
        </tr>
 </Template></Section>
<Section name="Detail" Visible="True" Height="1"><Template>
        <tr class="Row">
          <td><a id="SCAFFOLD_MODULE_GRADE_SCAname" href="" title="open Scaffold Module Report page" target="_blank" runat="server"  ><%#(CType(Container.DataItem,SCAFFOLD_MODULE_GRADE_SCAItem)).name.GetFormattedValue()%></a> </td> 
          <td><span class="<CC:ReportLabel id="SCAFFOLD_MODULE_GRADE_SCAlblgradestyle" DataType="_Text" SourceType="DBColumn" Source="lblgradestyle" EmptyText="ungraded" runat="server"/>"><CC:ReportLabel id="SCAFFOLD_MODULE_GRADE_SCAstr_long_grade" DataType="_Text" SourceType="DBColumn" Source="str_long_grade" EmptyText="=Ungraded=" runat="server"/></span> </td> 
          <td><strong><CC:ReportLabel id="SCAFFOLD_MODULE_GRADE_SCAessentialquestion" DataType="_Text" SourceType="DBColumn" Source="essentialquestion" ContentType="Html" runat="server"/></strong><br>
            <CC:ReportLabel id="SCAFFOLD_MODULE_GRADE_SCAstr_feedback" DataType="_Text" SourceType="DBColumn" Source="str_feedback" ContentType="Html" runat="server"/> </td> 
          <td><CC:ReportLabel id="SCAFFOLD_MODULE_GRADE_SCAfirstname" DataType="_Text" SourceType="DBColumn" Source="firstname" runat="server"/>&nbsp; <CC:ReportLabel id="SCAFFOLD_MODULE_GRADE_SCAlastname" DataType="_Text" SourceType="DBColumn" Source="lastname" runat="server"/></td> 
          <td><CC:ReportLabel id="SCAFFOLD_MODULE_GRADE_SCAdategraded" Format="d/mm/yyyy h:nn AM/PM" DataType="_Date" SourceType="DBColumn" Source="dategraded" runat="server"/> </td>
        </tr>
 </Template></Section>
<Section name="shortname_Footer" Visible="True" Height="0"><Template></Template></Section>
<Section name="SCAFFOLD_USER_student_id_Footer" Visible="True" Height="0"><Template></Template></Section>
<Section name="Report_Footer" Visible="True" Height="0"><Template>
        
	<asp:PlaceHolder id="SCAFFOLD_MODULE_GRADE_SCANoRecords" Visible="true" runat="server">
	
        <tr class="NoRecords">
          <td colspan="5">No Student Reporting found! <strong><em>Looking for Previous Years? </em></strong><a id="SCAFFOLD_MODULE_GRADE_SCAlinkExternalReport" href="" title="open in new window" class="Button" target="_blank" runat="server"  >click here</a> </td>
        </tr>
 
	</asp:PlaceHolder>
	</Template></Section>

  <LayoutFooterTemplate>
      </table>
    </td>
  </tr>
</table>
</LayoutFooterTemplate>
</CC:Report>
<br>
</p>
<script src="https://cdn.mathjax.org/mathjax/latest/MathJax.js?config=TeX-AMS-MML_HTMLorMML"></script>

</form>
</body>
</html>

<!--End ASPX page-->

