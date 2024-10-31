<!--ASPX page @1-39860A92-->
    <%@ Page language="vb" CodeFile="Student_DiagnosisConfirmed_maintain.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_DiagnosisConfirmed_maintain.Student_DiagnosisConfirmed_maintainPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_DiagnosisConfirmed_maintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="description" content="Special form for Wellbeing officers to access the information of students. This is a private function for Wellbeing Officers and Principals only.
Requested by Jo Miller May 2015"><meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Wellbeing Information Maintain</title>



<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<style type="text/css">
<!--
/* July-2016|EA| add highlighting to old categories in checkbox lists */
.deprecated::after { 
    content: " deprecated";
    background-color: yellow;
    color: red;
    font-weight: bold;
}
-->
</style>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

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

  <span id="STUDENT_DIAGNOSIS_DATAHolder" runat="server">
    


    <table cellspacing="0" cellpadding="0" width="70%" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Edit Student Wellbeing Information</th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="STUDENT_DIAGNOSIS_DATAError" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="2"><asp:Label ID="STUDENT_DIAGNOSIS_DATAErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Controls">
                        <th><strong>STUDENT ID:</strong>&nbsp;</th>
 
                        <td><asp:Literal id="STUDENT_DIAGNOSIS_DATASTUDENT_ID" runat="server"/>&nbsp;for <asp:Literal id="STUDENT_DIAGNOSIS_DATAENROLMENT_YEAR" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;<strong>Student Wellbeing</strong></th>
 
                        <td>Known?&nbsp; 
                            <asp:RadioButtonList id="STUDENT_DIAGNOSIS_DATARadioButton_Wellbeing"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>
                            <asp:CheckBoxList id="STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>'Other' - please specify</th>
 
                        <td><asp:TextBox id="STUDENT_DIAGNOSIS_DATASTUDENT_WELLBEING_OTHER" maxlength="50" Columns="50"	runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>Student Inclusion</strong></th>
 
                        <td>Known?&nbsp; 
                            <asp:RadioButtonList id="STUDENT_DIAGNOSIS_DATARadioButton_Inclusion"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>
                            <asp:CheckBoxList id="STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>'Other' - please specify</th>
 
                        <td><asp:TextBox id="STUDENT_DIAGNOSIS_DATASTUDENT_INCLUSION_OTHER" maxlength="50" Columns="50"	runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th colspan="2">
                        <p></p>
 
                        <p><strong>Referral Information</strong></p>
                        </th>
                    </tr>
 
                    <tr class="Controls">
                        <th>Region</th>
 
                        <td>
                            <select id="STUDENT_DIAGNOSIS_DATAlist_REGION"  runat="server"></select>
 &nbsp;&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>Previously Enrolled at&nbsp;VSV</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_DIAGNOSIS_DATARadioButton_Previous_Enrol"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>Reactivation</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_DIAGNOSIS_DATARadioButton_Reactivation"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>Referral made at time of enrolment&nbsp;</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_DIAGNOSIS_DATARadioButton_Referral"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>Referred By</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_DIAGNOSIS_DATARadioButton_ReferredBy"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>Supports in Place at time of Referral</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_DIAGNOSIS_DATARadioButton_Support"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>Types of Support in place at time of Referral</th>
 
                        <td>
                            <asp:CheckBoxList id="STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>
                        <p>Wellbeing Comments</p>
 
                        <p><em>Record information as: agency, location, profession<br>
                        Eg; headspace, Melton, Psychologist</em></p>
                        </th>
 
                        <td>
<asp:TextBox id="STUDENT_DIAGNOSIS_DATAWELLBEING_COMMENTS" rows="8" Columns="50" TextMode="MultiLine"	runat="server"/>
&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th></th>
 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>LAST ALTERED BY / DATE (entire form)</th>
 
                        <td><asp:Literal id="STUDENT_DIAGNOSIS_DATALAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_DIAGNOSIS_DATALAST_ALTERED_DATE" runat="server"/></td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="2" align="right">&nbsp;&nbsp; 
                            <input id='STUDENT_DIAGNOSIS_DATAButton_Insert' type="submit" class="Button" value="Add Wellbeing" OnServerClick='STUDENT_DIAGNOSIS_DATA_Insert' runat="server"/>&nbsp;&nbsp; 
                            <input id='STUDENT_DIAGNOSIS_DATAButton_Update' type="submit" class="Button" value="Update" OnServerClick='STUDENT_DIAGNOSIS_DATA_Update' runat="server"/>
                            <input id='STUDENT_DIAGNOSIS_DATAButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_DIAGNOSIS_DATA_Cancel' runat="server"/></td>
                    </tr>
                </table>
                
  <input id="STUDENT_DIAGNOSIS_DATAHidden_last_altered_date" type="hidden"  runat="server"/>
  
  <input id="STUDENT_DIAGNOSIS_DATAHidden_WellbeingList" type="hidden"  runat="server"/>
  
  <input id="STUDENT_DIAGNOSIS_DATAHidden_InclusionList" type="hidden"  runat="server"/>
  
  <input id="STUDENT_DIAGNOSIS_DATAHidden_SupportList" type="hidden"  runat="server"/>
  
  <input id="STUDENT_DIAGNOSIS_DATAHidden_enrolyear" type="hidden"  runat="server"/>
  
  <input id="STUDENT_DIAGNOSIS_DATAHidden_StudentId" type="hidden"  runat="server"/>
  
  <input id="STUDENT_DIAGNOSIS_DATAHidden_last_altered_by" type="hidden"  runat="server"/>
  </td>
        </tr>
    </table>



  </span>
  

</form>
</body>
</html>

<!--End ASPX page-->

