<!--ASPX page @1-21A428A6-->
    <%@ Page language="vb" CodeFile="StudentEnrolmentDetails_maintain_backup.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.StudentEnrolmentDetails_maintain_backup.StudentEnrolmentDetails_maintain_backupPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.StudentEnrolmentDetails_maintain_backup" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Enrolment Details - Maintain</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-B52976BB
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src='ClientI18N.aspx?file=DatePicker.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="utf-8"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Date Picker Object Definitions @1-FE63B364

var STUDENT_ENROLMENTDatePicker_ENROLMENT_DATE = new Object(); 
STUDENT_ENROLMENTDatePicker_ENROLMENT_DATE.format           = "dd/mm/yy";
STUDENT_ENROLMENTDatePicker_ENROLMENT_DATE.style            = "Styles/Blueprint/Style.css";
STUDENT_ENROLMENTDatePicker_ENROLMENT_DATE.relativePathPart = "";
STUDENT_ENROLMENTDatePicker_ENROLMENT_DATE.themeVersion     = "3.0";
var STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATE = new Object(); 
STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATE.format           = "dd/mm/yy";
STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATE.style            = "Styles/Blueprint/Style.css";
STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATE.relativePathPart = "";
STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATE.themeVersion     = "3.0";
//End Date Picker Object Definitions

//page_STUDENT_ENROLMENT_Button_Cancel_OnClick @5-287A9D41
function page_STUDENT_ENROLMENT_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_ENROLMENT_Button_Cancel_OnClick

//bind_events @1-7E64AEB0
function bind_events() {
    addEventHandler("STUDENT_ENROLMENTButton_Cancel","click",page_STUDENT_ENROLMENT_Button_Cancel_OnClick);
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

//End CCS script
</script>

</head>
<body>
<form runat="server">


<div align="center">
  <DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/> 
</div>
<div align="center">
</div>
<div align="center">
</div>

  <span id="STUDENT_ENROLMENTHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Edit Student Enrolment</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="STUDENT_ENROLMENTError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="4"><asp:Label ID="STUDENT_ENROLMENTErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>&nbsp;<strong><font size="3">Enrolment Details</font></strong></th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><strong>STUDENT ID</strong></th>
 
            <td>&nbsp;<asp:Literal id="STUDENT_ENROLMENTSTUDENT_ID" runat="server"/></td> 
            <td>&nbsp;<strong>ENROLMENT DATE</strong></td> 
            <td>&nbsp;<asp:TextBox id="STUDENT_ENROLMENTENROLMENT_DATE" maxlength="100" Columns="8"	runat="server"/>
              <asp:PlaceHolder id="STUDENT_ENROLMENTDatePicker_ENROLMENT_DATE" runat="server"><a href="javascript:showDatePicker('<%#STUDENT_ENROLMENTDatePicker_ENROLMENT_DATEName%>','forms[\''+theForm.id+'\']','<%#STUDENT_ENROLMENTDatePicker_ENROLMENT_DATEDateControl%>');" id="STUDENT_ENROLMENTDatePicker_ENROLMENT_DATE_Link"  ><img alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" border="0" />&nbsp;</a></asp:PlaceHolder>
  &nbsp;&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><strong>END DATE</strong></th>
 
            <td><asp:TextBox id="STUDENT_ENROLMENTWITHDRAWAL_DATE" maxlength="100" Columns="8"	runat="server"/>
              <asp:PlaceHolder id="STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATE" runat="server"><a href="javascript:showDatePicker('<%#STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATEName%>','forms[\''+theForm.id+'\']','<%#STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATEDateControl%>');" id="STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATE_Link"  ><img alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" border="0" /></a></asp:PlaceHolder>
  </td> 
            <td>&nbsp;<strong>ENROLMENT STATUS</strong></td> 
            <td>&nbsp;
              <select id="STUDENT_ENROLMENTENROLMENT_STATUS"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th><strong>WITHDRAWAL REASON</strong></th>
 
            <td colspan="3">
              <select id="STUDENT_ENROLMENTWITHDRAWAL_REASON_ID"  runat="server"></select>
 &nbsp;&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><strong>YEAR LEVEL</strong></th>
 
            <td>
              <select id="STUDENT_ENROLMENTYEAR_LEVEL"  runat="server"></select>
 </td> 
            <td>&nbsp;<strong>ENROLMENT YEAR</strong></td> 
            <td>&nbsp;<asp:Literal id="STUDENT_ENROLMENTENROLMENT_YEAR" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th><strong>CAMPUS</strong></th>
 
            <td>
              <asp:RadioButtonList id="STUDENT_ENROLMENTCAMPUS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
            <td>&nbsp;<strong>RECEIPT NO</strong></td> 
            <td>&nbsp;<asp:TextBox id="STUDENT_ENROLMENTRECEIPT_NO" maxlength="10" Columns="10"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;<strong><font size="3">Enrolment (Misc.)</font></strong></th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;<strong>ELIGIBLE FOR DISCOUNT</strong></th>
 
            <td>&nbsp;
              <asp:RadioButtonList id="STUDENT_ENROLMENTELIGIBLE_FOR_DISCOUNT"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
            <td>&nbsp;<strong>PAID ON ENROLMENT</strong></td> 
            <td>&nbsp;
              <asp:RadioButtonList id="STUDENT_ENROLMENTPAID_ON_ENROLMENT"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;<strong>FULL TIME STUDENT</strong></th>
 
            <td>&nbsp;
              <asp:RadioButtonList id="STUDENT_ENROLMENTFULL_TIME_STUDENT"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
            <td><strong>&nbsp;OVERSEAS FULL FEE PAYING</strong></td> 
            <td>&nbsp;
              <asp:RadioButtonList id="STUDENT_ENROLMENTOS_FULL_FEE_PAYING"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;<strong>ADDRESS NEEDS REVIEWING</strong></th>
 
            <td>&nbsp;
              <asp:RadioButtonList id="STUDENT_ENROLMENTADDRESS_REVIEW_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
            <td>&nbsp;<strong>ELIGIBLE FOR FUNDING</strong></td> 
            <td>&nbsp;
              <asp:RadioButtonList id="STUDENT_ENROLMENTELIGIBLE_FOR_FUNDING"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;<strong>VCE CANDIDATE NO</strong></th>
 
            <td>&nbsp;<asp:TextBox id="STUDENT_ENROLMENTVCE_CANDIDATE_NO" maxlength="10" Columns="10"	runat="server"/></td> 
            <td>&nbsp;<strong>BULLETIN NUMBER</strong></td> 
            <td>&nbsp;<asp:TextBox id="STUDENT_ENROLMENTBULLETIN_NO" maxlength="5" Columns="5"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;<strong>SUB SCHOOL</strong></th>
 
            <td>&nbsp;<asp:TextBox id="STUDENT_ENROLMENTSUB_SCHOOL" maxlength="10" Columns="10"	runat="server"/></td> 
            <td>&nbsp;<strong>PASTORAL CARE ID</strong></td> 
            <td>&nbsp;
              <select id="STUDENT_ENROLMENTPASTORAL_CARE_ID"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;<strong>DOCUMENTS LAST REVIEWED DATE</strong></th>
 
            <td>&nbsp;<asp:TextBox id="STUDENT_ENROLMENTDOCS_LAST_REVIEWED_DATE" maxlength="8" Columns="8"	runat="server"/></td> 
            <td><strong>&nbsp;NEW DOCUMENTS REQUIRED</strong></td> 
            <td>&nbsp;
              <asp:RadioButtonList id="STUDENT_ENROLMENTNEW_DOCS_REQUIRED"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;<strong>COMMENTS</strong></th>
 
            <td colspan="3"><em>&nbsp;(Comments entered below will appear on the [Student&nbsp;Summary] screen, under [Student Comments])</em>&nbsp;&nbsp; </td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td colspan="3">
<asp:TextBox id="STUDENT_ENROLMENTENROLMENT_COMMENTS" rows="5" Columns="45" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;LAST ALTERED BY / DATE</th>
 
            <td>&nbsp;<asp:Literal id="STUDENT_ENROLMENTLAST_ALTERED_BY" runat="server"/></td> 
            <td>&nbsp;<asp:Literal id="STUDENT_ENROLMENTLAST_ALTERED_DATE" runat="server"/></td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="4">
              <input id='STUDENT_ENROLMENTButton_Insert' class="Button" type="submit" value="Add" OnServerClick='STUDENT_ENROLMENT_Insert' runat="server"/>
              <input id='STUDENT_ENROLMENTButton_Update' class="Button" type="submit" value="Update" OnServerClick='STUDENT_ENROLMENT_Update' runat="server"/>
              <input id='STUDENT_ENROLMENTButton_Cancel' class="Button" type="submit" value="Cancel" OnServerClick='STUDENT_ENROLMENT_Cancel' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>

</form>
</body>
</html>

<!--End ASPX page-->

