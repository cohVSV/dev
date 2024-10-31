<!--ASPX page @1-8403C985-->
    <%@ Control language="vb" CodeFile="StudentNamePlate.ascx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.StudentNamePlate.StudentNamePlatePage" %>
	
	<%@ Import namespace="DECV_PROD2007.StudentNamePlate" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>

<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<meta name="GENERATOR" content="CodeCharge Studio 4.1.00.032">
<p>

<CC:Report id="viewStudentSummary_Detail" WebPageSize="1" PageSizeLimit="100" runat="server">
  <LayoutHeaderTemplate>
<table border="0" cellspacing="0" cellpadding="0" width="70%" align="center">
  <tr>
    <td valign="top">
      <table class="Header" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>Student Summary</th>
 
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
        </tr>
 
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        </LayoutHeaderTemplate>
  <Section name="Report_Header" Visible="True" Height="0"><Template></Template></Section>
<Section name="Page_Footer" Visible="True" Height="0"><Template></Template></Section>
<Section name="Detail" Visible="True" Height="1"><Template>
        <tr class="Row">
          <td style="TEXT-ALIGN: right">&nbsp;Student</td> 
          <td style="TEXT-ALIGN: left"><strong><CC:ReportLabel id="viewStudentSummary_Detailfirst_name" DataType="_Text" SourceType="DBColumn" Source="first_name" runat="server"/>&nbsp;<CC:ReportLabel id="viewStudentSummary_Detailsurname" DataType="_Text" SourceType="DBColumn" Source="surname" runat="server"/></strong> </td> 
          <td>&nbsp;<CC:ReportLabel id="viewStudentSummary_DetailSTUDENT_ID" DataType="_Float" SourceType="DBColumn" Source="STUDENT_ID" runat="server"/></td> 
          <td>Birth Date <em>Age</em></td> 
          <td><CC:ReportLabel id="viewStudentSummary_DetailBIRTH_DATE" Format="dd/mm/yyyy" DataType="_Text" SourceType="DBColumn" Source="BIRTH_DATE" runat="server"/>&nbsp; <em><CC:ReportLabel id="viewStudentSummary_DetailAGE" DataType="_Text" SourceType="DBColumn" Source="AGE" runat="server"/></em></td> 
          <td>&nbsp;Gender&nbsp;</td> 
          <td>&nbsp;<CC:ReportLabel id="viewStudentSummary_DetailGENDER" DataType="_Text" SourceType="DBColumn" Source="GENDER" runat="server"/></td> 
        </tr>
 
        <tr class="Row">
          <td style="TEXT-ALIGN: right">Category</td> 
          <td style="TEXT-ALIGN: left" colspan="2"><CC:ReportLabel id="viewStudentSummary_Detailsubcategory_full_title" DataType="_Text" SourceType="DBColumn" Source="subcategory_full_title" EmptyText="&quot;(unknown)&quot;" runat="server"/>&nbsp;&nbsp; </td> 
          <td>Year Level&nbsp;&nbsp;<em>ATAR</em></td> 
          <td><CC:ReportLabel id="viewStudentSummary_DetailYEAR_LEVEL" DataType="_Integer" SourceType="DBColumn" Source="YEAR_LEVEL" EmptyText="&quot;(??)&quot;" runat="server"/>&nbsp;&nbsp;<em><CC:ReportLabel id="viewStudentSummary_DetailATAR_REQUIRED" DataType="_Text" SourceType="DBColumn" Source="ATAR_REQUIRED" EmptyText="&quot;&quot;" runat="server"/></em>&nbsp;&nbsp;<CC:ReportLabel id="viewStudentSummary_DetaillblATAR_REQUIRED" DataType="_Text" SourceType="CodeExpression" Source="lblATAR_REQUIRED" ContentType="Html" EmptyText="&lt;b&gt;No ATAR&lt;/b&gt;" runat="server"/></td> 
          <td>&nbsp;Enrolled</td> 
          <td>&nbsp;<CC:ReportLabel id="viewStudentSummary_DetailENROLMENT_STATUS" DataType="_Text" SourceType="DBColumn" Source="ENROLMENT_STATUS" EmptyText="&quot;(unknown)&quot;" runat="server"/></td> 
        </tr>
 </Template></Section>
<Section name="Report_Footer" Visible="True" Height="0"><Template>
        
	<asp:PlaceHolder id="viewStudentSummary_DetailNoRecords" Visible="true" runat="server">
	
        <tr class="NoRecords">
          <td colspan="7">No Student Details found - Make sure you have selected a student!</td> 
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
</p>









<!--End ASPX page-->

