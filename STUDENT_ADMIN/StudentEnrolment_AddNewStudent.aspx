<!--ASPX page @1-AFC8C7AC-->
    <%@ Page language="vb" CodeFile="StudentEnrolment_AddNewStudent.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.StudentEnrolment_AddNewStudent.StudentEnrolment_AddNewStudentPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.StudentEnrolment_AddNewStudent" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>StudentDetails_maintain</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//DEL  </script>
//DEL  <script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
//DEL  <script language="JavaScript" type="text/javascript">
//DEL    


//Include Common JSFunctions @1-B52976BB
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src='ClientI18N.aspx?file=DatePicker.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="utf-8"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Date Picker Object Definitions @1-E768D9C8

var STUDENTDatePicker_BIRTH_DATE = new Object(); 
STUDENTDatePicker_BIRTH_DATE.format           = "dd/mm/yyyy";
STUDENTDatePicker_BIRTH_DATE.style            = "Styles/Blueprint/Style.css";
STUDENTDatePicker_BIRTH_DATE.relativePathPart = "";
STUDENTDatePicker_BIRTH_DATE.themeVersion     = "3.0";
//End Date Picker Object Definitions

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//Set Focus @81-75AA6DF1
    if (theForm.STUDENTSURNAME) theForm.STUDENTSURNAME.focus();
//End Set Focus

//Close page_OnLoad @1-BC33A33A
    return result;
}
//End Close page_OnLoad

//page_STUDENT_Button_Cancel_OnClick @5-AF0AE409
function page_STUDENT_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_Button_Cancel_OnClick

//bind_events @1-87B4F6FC
function bind_events() {
    addEventHandler("STUDENTButton_Cancel","click",page_STUDENT_Button_Cancel_OnClick);
    page_OnLoad();
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


<div align="center">
  &nbsp;<DECV_PROD2007:Header id="Header" runat="server"/> 
</div>
<div align="center">
</div>

  <span id="STUDENTHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Add New Student Details</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="STUDENTError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="4"><asp:Label ID="STUDENTErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>STUDENT ID</th>
 
            <td>&nbsp;<asp:Literal id="STUDENTlblStudentID" runat="server"/>&nbsp; <input id="btnRegionCheck" onclick="javascript:window.open('http://intranet.distance.vic.edu.au/regionpopup/popup_DECVConfirmEnrolment.asp', 'popupRegionCheck','location=0,status=1,scrollbars=1,resizable=1,width=600,height=600');" type="button" value="Region Check" name="btnRegionCheck"/></td> 
            <td>&nbsp;ENROLMENT DATE</td> 
            <td>&nbsp;<asp:TextBox id="STUDENTEnrolDate" maxlength="12" Columns="10"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>SURNAME</th>
 
            <td><asp:TextBox id="STUDENTSURNAME" tabindex="3" maxlength="30" Columns="30"	runat="server"/></td> 
            <td>&nbsp;FIRST NAME</td> 
            <td>&nbsp;<asp:TextBox id="STUDENTFIRST_NAME" tabindex="4" maxlength="30" Columns="30"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>MIDDLE NAME</th>
 
            <td><asp:TextBox id="STUDENTMIDDLE_NAME" tabindex="5" maxlength="30" Columns="30"	runat="server"/></td> 
            <td>DATE OF BIRTH (DD/MM/YYYY):</td> 
            <td>&nbsp;<asp:TextBox id="STUDENTBIRTH_DATE" tabindex="6" maxlength="12" Columns="10"	runat="server"/>
              <asp:PlaceHolder id="STUDENTDatePicker_BIRTH_DATE" runat="server"><a href="javascript:showDatePicker('<%#STUDENTDatePicker_BIRTH_DATEName%>','forms[\''+theForm.id+'\']','<%#STUDENTDatePicker_BIRTH_DATEDateControl%>');" tabindex="7" id="STUDENTDatePicker_BIRTH_DATE_Link"  ><img alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" border="0" />&nbsp;</a></asp:PlaceHolder>
  </td>
          </tr>
 
          <tr class="Controls">
            <th>GENDER</th>
 
            <td>
              <asp:RadioButtonList id="STUDENTSEX"  tabindex="8" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>YEAR LEVEL</th>
 
            <td>
              <select id="STUDENTlistYearLevel" tabindex="9"  runat="server"></select>
 &nbsp;</td> 
            <td>&nbsp;ENROLMENT YEAR</td> 
            <td>&nbsp;<asp:TextBox id="STUDENTEnrolYear" maxlength="4" Columns="4"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>CATEGORY / SUBCATEGORY</th>
 
            <td colspan="3">
              <select id="STUDENTListBox_SubCategory" tabindex="10"  runat="server"></select>
 &nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>ATTENDING SCHOOL ID</th>
 
            <td colspan="3"><asp:TextBox id="STUDENTATTENDING_SCHOOL_ID" tabindex="11" maxlength="12" Columns="12"	runat="server"/>&nbsp;&nbsp;<asp:Literal id="STUDENTlblAttendingSchoolName" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>HOME SCHOOL ID</th>
 
            <td colspan="3"><asp:TextBox id="STUDENTHOME_SCHOOL_ID" tabindex="12" maxlength="12" Columns="12"	runat="server"/>&nbsp;&nbsp;<asp:Literal id="STUDENTlblHomeSchoolName" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="4">
              <input id='STUDENTButton_Cancel' class="Button" type="submit" value="Cancel" OnServerClick='STUDENT_Cancel' runat="server"/>
              <input id='STUDENTButton_Insert' class="Button" tabindex="13" type="submit" value="NEXT" OnServerClick='STUDENT_Insert' runat="server"/>
              <input id='STUDENTButton_Update' class="Button" type="submit" value="NEXT" OnServerClick='STUDENT_Update' runat="server"/></td>
          </tr>
        </table>
        <asp:TextBox id="STUDENTCATEGORY_CODE"	runat="server"/><asp:TextBox id="STUDENTSUBCATEGORY_CODE"	runat="server"/><asp:TextBox id="STUDENTEnrolmentCategoryTemp"	runat="server"/></td>
    </tr>
  </table>


<p align="center">&nbsp;<asp:Literal id="STUDENTlblErrorMessages" runat="server"/></p>

  </span>
  <br>

</form>
</body>
</html>

<!--End ASPX page-->

