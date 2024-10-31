<!--ASPX page @1-D4300957-->
    <%@ Page language="vb" CodeFile="StudentSubject_TeacherStats.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.StudentSubject_TeacherStats.StudentSubject_TeacherStatsPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.StudentSubject_TeacherStats" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 4.1.00.032"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>StudentSubject_TeacherStats</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
<style type="text/css">
      tr.highAllocation td
      {
         background-color: khaki;
      }


      tr.maxAllocation td
      {
         background-color: lightsalmon;
      }
   </style>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">



<CC:Report id="rptTeacherAllocation" WebPageSize="40" PageSizeLimit="100" runat="server">
  <LayoutHeaderTemplate>
<table class="MainTable" cellspacing="0" cellpadding="0" border="0">
    <tr>
        <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                    <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
                    <th>Current Active Subject Enrolments (Excludes Non-Submits)</th>
 
                    <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
                </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
                </LayoutHeaderTemplate>
  <Section name="Report_Header" Visible="True" Height="0"><Template>
                <tr class="Controls">
                    <td colspan="6">
                        <h2 style="MARGIN-TOP: 5px">Enrolment Year: <CC:ReportLabel id="rptTeacherAllocationlblEnrolmentYear" DataType="_Text" SourceType="DBColumn" runat="server"/></h2>
 
                        <h2>Subject Abbrev: <CC:ReportLabel id="rptTeacherAllocationlblSubjectAbbreviation" DataType="_Text" SourceType="DBColumn" runat="server"/></h2>
                    </td>
                </tr>
 </Template></Section>
<Section name="Page_Header" Visible="True" Height="1"><Template>
                <tr class="Caption">
                    <th>Semester&nbsp;</th>
 
                    <th>Staff ID</th>
 
                    <th>Subj. Time Frac.</th>
 
                    <th>FTE Student Max</th>
 
                    <th>Current Students</th>
 
                    <th>Percentage</th>
                </tr>
 </Template></Section>
<Section name="Page_Footer" Visible="True" Height="0"><Template></Template></Section>
<Section name="SEMESTER_Header" Visible="True" Height="1"><Template>
                <tr class="GroupCaption">
                    <th><CC:ReportLabel id="rptTeacherAllocationSEMESTER" DataType="_Text" SourceType="DBColumn" Source="SEMESTER" runat="server"/> </th>
 
                    <th>&nbsp; </th>
 
                    <th>&nbsp; </th>
 
                    <th>&nbsp; </th>
 
                    <th>&nbsp; </th>
 
                    <th>&nbsp; </th>
                </tr>
 </Template></Section>
<Section name="Detail" Visible="True" Height="1"><Template>
                <tr class="Row">
                    <td>&nbsp; </td> 
                    <td><CC:ReportLabel id="rptTeacherAllocationSTAFF_ID" DataType="_Text" SourceType="DBColumn" Source="STAFF_ID" runat="server"/> </td> 
                    <td><CC:ReportLabel id="rptTeacherAllocationSUBJECT_TIMEFRACTION" Format="0.00" DataType="_Float" SourceType="DBColumn" Source="SUBJECT_TIMEFRACTION" runat="server"/> </td> 
                    <td><CC:ReportLabel id="rptTeacherAllocationFTE_StudentMax" Format="0" DataType="_Float" SourceType="DBColumn" Source="FTE_StudentMax" runat="server"/> </td> 
                    <td style="TEXT-ALIGN: right"><CC:ReportLabel id="rptTeacherAllocationCurrent_Student_Count" DataType="_Integer" SourceType="DBColumn" Source="Current_Student_Count" runat="server"/> </td> 
                    <td><CC:ReportLabel id="rptTeacherAllocationPercentage" Format="0%" DataType="_Float" SourceType="DBColumn" Source="Percentage" runat="server"/> </td>
                </tr>
 </Template></Section>
<Section name="SEMESTER_Footer" Visible="True" Height="1"><Template></Template></Section>
<Section name="Report_Footer" Visible="True" Height="1"><Template>
                
	<asp:PlaceHolder id="rptTeacherAllocationNoRecords" Visible="true" runat="server">
	
                <tr class="NoRecords">
                    <td colspan="6">No Student Details found!</td>
                </tr>
 
	</asp:PlaceHolder>
	
                <tr class="Total">
                    <td valign="baseline">Total </td> 
                    <td>&nbsp; </td> 
                    <td style="TEXT-ALIGN: right" valign="baseline"><CC:ReportLabel id="rptTeacherAllocationTotalSum_SUBJECT_TIMEFRACTION" DataType="_Float" SourceType="DBColumn" Source="TotalSum_SUBJECT_TIMEFRACTION" Function="Sum" ResetAt="Report" runat="server"/> </td> 
                    <td style="TEXT-ALIGN: right" valign="baseline"><CC:ReportLabel id="rptTeacherAllocationTotalSum_FTE_StudentMax" DataType="_Float" SourceType="DBColumn" Source="TotalSum_FTE_StudentMax" Function="Sum" ResetAt="Report" runat="server"/> </td> 
                    <td style="TEXT-ALIGN: right" valign="baseline"><CC:ReportLabel id="rptTeacherAllocationTotalSum_Current_Student_Count" DataType="_Integer" SourceType="DBColumn" Source="TotalSum_Current_Student_Count" Function="Sum" ResetAt="Report" runat="server"/> </td> 
                    <td><CC:ReportLabel id="rptTeacherAllocationlblTotalAllocationPercentage" DataType="_Text" SourceType="DBColumn" runat="server"/>&nbsp; </td>
                </tr>
 </Template></Section>

  <LayoutFooterTemplate>
            </table>
        </td>
    </tr>
</table>
</LayoutFooterTemplate>
</CC:Report>
<br>
<br>
<br>
&nbsp;
<script type="text/javascript">
      function highlightHighAllocations()
      {
         var rowElements = document.querySelectorAll("#rptTeacherAllocation .MainTable .Grid tr.Row, #rptTeacherAllocation .MainTable .Grid tr.Total");
         for (var rowIndex = 0; rowIndex < rowElements.length; rowIndex++)
         {
            var rowElement = rowElements[rowIndex];
            var percentageElement = rowElement.querySelector("td:nth-child(6)");
            if (percentageElement !== null)
            {
               var percentage = parseFloat(percentageElement.textContent);
               if (!isNaN(percentage))
               {
                  if (percentage >= 100)
                     rowElement.classList.add("maxAllocation");
                  else if (percentage >= 95)
                     rowElement.classList.add("highAllocation");
               }
            }
         }
      }

      highlightHighAllocations();
   </script>

</form>
</body>
</html>

<!--End ASPX page-->

