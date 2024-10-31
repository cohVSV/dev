<!--ASPX page @1-E0B22416-->
    <%@ Page language="vb" CodeFile="StudentEnrolment_AddNewYear.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.StudentEnrolment_AddNewYear.StudentEnrolment_AddNewYearPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.StudentEnrolment_AddNewYear" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Details - Add New Enrolment Year</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//DEL  </script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">

//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_STUDENT_Button_Update_OnClick @3-DB04562F
function page_STUDENT_Button_Update_OnClick()
{
    var result;
//End page_STUDENT_Button_Update_OnClick

//Confirmation Message @85-DABCB649
    return confirm('Are you sure you want to add a new Enrolment Year?');
//End Confirmation Message

//Close page_STUDENT_Button_Update_OnClick @3-BC33A33A
    return result;
}
//End Close page_STUDENT_Button_Update_OnClick

//page_STUDENT_Button_Cancel_OnClick @5-AF0AE409
function page_STUDENT_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_Button_Cancel_OnClick

//bind_events @1-597438F4
function bind_events() {
    addEventHandler("STUDENTButton_Update","click",page_STUDENT_Button_Update_OnClick);
    addEventHandler("STUDENTButton_Cancel","click",page_STUDENT_Button_Cancel_OnClick);
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649
//End Assign bind_events
window.onload = bind_events; 

//End CCS script
</script>
<script language="JavaScript" type="text/javascript">
/*
    Date Modified : 12 Nov 2009
    Modified by : Eric Affleck
    Ref: Unfuddle Ticket No: #182, 184
    Task: Region Approval display - this hides it if 'not this student?' is clicked.
*/

function clearRegionID(){
    $('STUDENTinputREgionID').value='0';
    $('STUDENTinputREgionID').focus();
        $('region_approvalHolder').style.display = "none";
    return true;
}

</script>
<link rel="stylesheet" type="text/css" href="Styles/Fresh/Style_Components.css">

</head>
<body>
<form runat="server">


<div align="center">
    &nbsp;<DECV_PROD2007:Header id="Header" runat="server"/>&nbsp; 
</div>

  <span id="STUDENTHolder" runat="server">
    
<p>
<p>


    <table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Add New Year for a Student</th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
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
 
                        <td><asp:Literal id="STUDENTlblStudentID" runat="server"/>&nbsp; </td> 
                        <td>ENROLMENT DATE</td> 
                        <td>&nbsp;<asp:TextBox id="STUDENTEnrolDate" ReadOnly="True" maxlength="12" Columns="10"	runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>SURNAME</th>
 
                        <td><asp:Literal id="STUDENTSURNAME" runat="server"/>&nbsp;</td> 
                        <td>FIRST NAME</td> 
                        <td>&nbsp;<asp:Literal id="STUDENTFIRST_NAME" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>MIDDLE NAME</th>
 
                        <td><asp:Literal id="STUDENTMIDDLE_NAME" runat="server"/>&nbsp;</td> 
                        <td>DATE OF BIRTH (DD/MM/YYYY):</td> 
                        <td>&nbsp;<asp:Literal id="STUDENTBIRTH_DATE" runat="server"/> </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>GENDER</th>
 
                        <td style="pointer-events: none">
                            <asp:RadioButtonList id="STUDENTSEX"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp; <asp:TextBox id="STUDENTSEX_SELF_DESCRIBED" ReadOnly="True"	runat="server"/></td> 
                        <td>&nbsp;</td> 
                        <td></td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>YEAR LEVEL</strong></th>
 
                        <td>
                            <select id="STUDENTlistYearLevel" tabindex="1"  runat="server"></select>
 &nbsp;</td> 
                        <td><strong>ENROLMENT YEAR</strong></td> 
                        <td>&nbsp;<asp:TextBox id="STUDENTEnrolYear" tabindex="2" maxlength="4" Columns="4"	runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th></th>
 
                        <td>
                            <p>&nbsp;</p>
                        </td> 
                        <td><strong>PRIVACY PERMISSION GIVEN?</strong>&nbsp;<img onclick="javascript:alert('Privacy Permission Given?, Dec 2011');return false;" id="privacy_permission_icon" title="Permission VSV to access and share any existing relevant personal or health information with specialist practitioners or agencies that have been listed in this enrolment application." border="0" name="privacy_permission_icon" alt="Permission VSV to access and share any existing relevant personal or health information with specialist practitioners or agencies that have been listed in this enrolment application." src="images/icon_info.gif"></td> 
                        <td>
                            <p>&nbsp; 
                            <asp:RadioButtonList id="STUDENTPRIVACY_PERMISSION"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><br>
                            <em>Mandatory 2020 Onwards</em></p>
                        </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>CATEGORY / SUBCATEGORY</th>
 
                        <td colspan="3"><asp:Literal id="STUDENTcategory" runat="server"/>&nbsp;/ <asp:Literal id="STUDENTsubcategory" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>ATTENDING SCHOOL ID</th>
 
                        <td colspan="3"><asp:Literal id="STUDENTATTENDING_SCHOOL_ID" runat="server"/>&nbsp;&nbsp;<asp:Literal id="STUDENTlblAttendingSchoolName" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>HOME SCHOOL ID</th>
 
                        <td colspan="3"><asp:Literal id="STUDENTHOME_SCHOOL_ID" runat="server"/>&nbsp;&nbsp;<asp:Literal id="STUDENTlblHomeSchoolName" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="4" align="right">
                            <input id='STUDENTButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_Cancel' runat="server"/>
                            <input id='STUDENTButton_Update' type="submit" class="Button" value="Add New Year" OnServerClick='STUDENT_Update' runat="server"/></td>
                    </tr>
                </table>
                
  <input id="STUDENThidden_STUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="STUDENThidden_LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="STUDENTinputREgionID" type="hidden"  runat="server"/>
  </td>
        </tr>
    </table>


<p align="center">&nbsp;<asp:Literal id="STUDENTlblErrorMessages" runat="server"/></p>

  </span>
  
<p>&nbsp;</p>

</form>
</body>
</html>

<!--End ASPX page-->

