<!--ASPX page @1-3D9DDF1A-->
    <%@ Page language="vb" CodeFile="StudentDetails_maintain.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.StudentDetails_maintain.StudentDetails_maintainPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.StudentDetails_maintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Details - Maintain</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-092F8E28
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript" charset="utf-8" src='ClientI18N.aspx?file=DatePicker.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Date Picker Object Definitions @1-E768D9C8

var STUDENTDatePicker_BIRTH_DATE = new Object(); 
STUDENTDatePicker_BIRTH_DATE.format           = "dd/mm/yyyy";
STUDENTDatePicker_BIRTH_DATE.style            = "Styles/Blueprint/Style.css";
STUDENTDatePicker_BIRTH_DATE.relativePathPart = "";
STUDENTDatePicker_BIRTH_DATE.themeVersion     = "3.0";
//End Date Picker Object Definitions

//page_STUDENT_Button_Update_OnClick @4-DB04562F
function page_STUDENT_Button_Update_OnClick()
{
    var result;
//End page_STUDENT_Button_Update_OnClick

//Custom Code @87-2A29BDB7
    // -------------------------
    // Write your own code here.
        result = ValidateVSN();
    // -------------------------
//End Custom Code

//Close page_STUDENT_Button_Update_OnClick @4-BC33A33A
    return result;
}
//End Close page_STUDENT_Button_Update_OnClick

//page_STUDENT_cbPORTAL_ACCESS_OnClick @255-EFA8E618
function page_STUDENT_cbPORTAL_ACCESS_OnClick()
{
    var result;
//End page_STUDENT_cbPORTAL_ACCESS_OnClick

//Custom Code @256-2A29BDB7
    // -------------------------
    // 18-Aug-2017|EA|(unfuddle #707) 
    // If clicking it ON (Yes) from OFF (No) then popup message to confirm
        result = true;
    var portal = $F('STUDENTcbPORTAL_ACCESS');

        if (portal =='on'){
                alert('Obtain an undertaking not to provide information (username and password) to the individual being restricted that would enable him or her to breach the Portal security system.\n\nRecord undertaking in comments on database.');
        }
    // -------------------------
//End Custom Code

//Close page_STUDENT_cbPORTAL_ACCESS_OnClick @255-BC33A33A
    return result;
}
//End Close page_STUDENT_cbPORTAL_ACCESS_OnClick

//page_STUDENT_list_Pronoun_OnChange @357-E34A3199
function page_STUDENT_list_Pronoun_OnChange()
{
    var result;
//End page_STUDENT_list_Pronoun_OnChange
        //Show/Hide Other field depending if Other is selected
        var sel = document.getElementById('STUDENTlist_Pronoun');
        var text = document.getElementById('STUDENTPRONOUN_OTHER');
        if(sel.options[sel.selectedIndex].innerHTML === 'Other')
            text.style.display = 'unset';
        else
            text.style.display = 'none';
//Custom Code @391-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Custom Code

//Close page_STUDENT_list_Pronoun_OnChange @357-BC33A33A
    return result;
}
//End Close page_STUDENT_list_Pronoun_OnChange

//page_STUDENT_Button_Cancel_OnClick @5-AF0AE409
function page_STUDENT_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_Button_Cancel_OnClick

//bind_events @1-85F41300
function bind_events() {
    addEventHandler("STUDENTcbPORTAL_ACCESS","click",page_STUDENT_cbPORTAL_ACCESS_OnClick);
    addEventHandler("STUDENTButton_Update","click",page_STUDENT_Button_Update_OnClick);
    addEventHandler("STUDENTButton_Cancel","click",page_STUDENT_Button_Cancel_OnClick);
    
    document.getElementById('STUDENTlist_Pronoun').onchange = page_STUDENT_list_Pronoun_OnChange
        page_STUDENT_list_Pronoun_OnChange();//Call Onchange on load to show/hide the other box.
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

window.onload = bind_events; 

//End CCS script
</script>
<script language="JavaScript" type="text/javascript">
function OpenPopUpList_School(FieldName)
{
        //FieldName = "txtAttendingSchoolID";FieldName = "txtHomeSchoolID";
        if (!FieldName==''){
            var win=window.open("popup_SchoolList.aspx?returncontrol="+FieldName, "SchoolList", "left=40,top=10,width=380,height=480,status=no,toolbar=no,menubar=no,location=no,scrollbars=yes");
            win.focus();
        }
}
function OpenPopUpList_Subjects()
{
        var win=window.open("StudentEnrolment_AddSubject.aspx?STUDENT_ID="+FieldName, "AddSubject", "left=40,top=10,width=380,height=480,status=no,toolbar=no,menubar=no,location=no,scrollbars=yes");
        win.focus();
}
</script>
<script language="JavaScript" type="text/javascript">
/*
'******************************
        'Date Modified : 24 July 2009
        'Modified by : Vikas
        'Task: VSN implementation
        '******************Code Starts Here******************
*/

   function ValidateVSN()
    {
    var tmpformname='';
    var VSN=document.getElementById(tmpformname + 'STUDENTVSN');
    
    if (VSN.value!='')
    {
        if (VSN.value.length!=9)
            {
                alert('VSN should be 9 digits');
                return false;
            }
        else
            {
            var strVSN=VSN.value;
            
            //Use weight factor- 1, 4, 3, 7, 5, 8, 6, 9, 10
            var Weightfactor=new Array("1", "4", "3", "7","5", "8", "6", "9", "10");
            var bitsVSR=new Array(9);
            var i=0;
            var totalVSN=0;
            
            for (i = 0; i < 9 ; i++)
                {
                    bitsVSR[i]=strVSN.substring(i,i+1);
                }
                       
            for (i = 0; i < 9 ; i++)
                {
                    totalVSN = totalVSN + (bitsVSR[i] * Weightfactor[i]);
                }
            
            var outVSN=totalVSN%11;
            
            if (outVSN!=0)
                {
                    alert('Invalid VSN Number');
                    VSN.value='';
                    return false;
                }
            else
                {      
                    return true;
                }
            } 
        }  
       else
       {
            return true;
       } 
    }
    /*
'******************************
        'Date Modified : 24 July 2009
        'Modified by : Vikas
        'Task: VSN implementation
        '******************Code Ends Here******************
*/
</script>

</head>
<body>
<form runat="server">


<div style="DISPLAY: none" align="center">
  &nbsp;<DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/> 
</div>
<div align="center">
</div>
<div align="center">
</div>

  <span id="STUDENTHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Edit Student Details</th>
 
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
            <th><strong>STUDENT ID</strong></th>
 
            <td>&nbsp;<asp:Literal id="STUDENTlblStudentID" runat="server"/></td> 
            <td><strong>VSN</strong></td> 
            <td>&nbsp;<asp:TextBox id="STUDENTVSN" onblur="javascript: return ValidateVSN();" maxlength="9" Columns="10"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th><strong>SURNAME</strong></th>
 
            <td><asp:TextBox id="STUDENTSURNAME" maxlength="30" Columns="30"	runat="server"/></td> 
            <td><strong>FIRST NAME</strong></td> 
            <td>&nbsp;<asp:TextBox id="STUDENTFIRST_NAME" maxlength="30" Columns="30"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th colspan="2">&nbsp;<em>NOTE: First, Preferred, Middle, and Surname will NOT be changed to Upper Case when 'Updated' (Nov 2011)</em></th>
 
            <td><strong>PREFERRED NAME</strong></td> 
            <td>&nbsp;<asp:TextBox id="STUDENTPREFERRED_NAME" maxlength="30" Columns="30"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th><strong>MIDDLE NAME</strong></th>
 
            <td><asp:TextBox id="STUDENTMIDDLE_NAME" maxlength="30" Columns="30"	runat="server"/></td> 
            <td><strong>DATE OF BIRTH (DD/MM/YY)</strong></td> 
            <td>&nbsp;<asp:TextBox id="STUDENTBIRTH_DATE" maxlength="100" Columns="8"	runat="server"/>
              <asp:PlaceHolder id="STUDENTDatePicker_BIRTH_DATE" runat="server"><a href="javascript:showDatePicker('<%#STUDENTDatePicker_BIRTH_DATEName%>','forms[\''+theForm.id+'\']','<%#STUDENTDatePicker_BIRTH_DATEDateControl%>');" id="STUDENTDatePicker_BIRTH_DATE_Link"  ><img border="0" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" />&nbsp;</a></asp:PlaceHolder>
  </td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><strong>GENDER</strong></th>
 
            <td>
              <asp:RadioButtonList id="STUDENTSEX"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;<asp:TextBox id="STUDENTSEX_SELF_DESCRIBED" style="MARGIN-LEFT: 10px" maxlength="30" Columns="30"	runat="server"/></td> 
            <td><strong>REGION</strong>&nbsp;</td> 
            <td>
              <select id="STUDENTlist_REGION"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th><strong>BIRTH SEX</strong></th>
 
            <td>
              <asp:RadioButtonList id="STUDENTSEX_BIRTH"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
            <td><strong>VCE CANDIDATE NUMBER&nbsp;(12345678A)<img onclick="javascript:alert('VCE / VASS Candidate Number April 2011');return false;" id="vce_candidate_icon" title="VCE / VASS Candidate Number April 2011" border="0" name="vce_candidate_icon" alt="VCE / VASS Candidate Number" src="images/icon_info.gif"></strong></td> 
            <td><asp:TextBox id="STUDENTVCE_CANDIDATE_NUMBER" maxlength="10" Columns="12"	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><strong>PRONOUNS</strong></th>
 
            <td>
              
              <select id="STUDENTlist_Pronoun"  runat="server"></select>
              &nbsp;<asp:TextBox id="STUDENTPRONOUN_OTHER"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><strong>Student Email Address</strong>&nbsp;<img onclick="javascript:alert('Student Email Address\n\nChanging this will Update the Student Current Address\n\nadded May 2011');return false;" id="studentemail_icon" title="Student Email Address - Changing this will Update the Student Current Address -added May 2011" border="0" name="studentemailIcon" alt="Student Email Address" src="images/icon_info.gif"></th>
 
            <td><asp:TextBox id="STUDENTSTUDENT_EMAIL" maxlength="250" Columns="45"	runat="server"/>&nbsp; <br>
              <em>Updates to Student Email will automatically update Current Address email</em></td> 
            <td>&nbsp;<strong>STUDENT ACCESSIBLE ON&nbsp;PORTAL</strong>&nbsp;<img onclick="javascript:alert('Untick to remove student from Portal\n at next update (added Aug 2016)');return false;" id="studentemail_icon" title="Untick to remove student from Portal at next update (added Aug 2016)" border="0" name="studentemailIcon" alt="Student Access on Portal" src="images/icon_info.gif"></td> 
            <td><asp:CheckBox id="STUDENTcbPORTAL_ACCESS" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><strong>Student Mobile</strong></th>
 
            <td><asp:TextBox id="STUDENTSTUDENT_MOBILE" maxlength="20"	runat="server"/>&nbsp;</td> 
            <td><em></em></td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><strong>&nbsp;</strong></th>
 
            <td>
              <p>&nbsp;&nbsp; </p>
            </td> 
            <td>&nbsp;</td> 
            <td>&nbsp;&nbsp; </td>
          </tr>
 
          <tr class="Controls">
            <th><strong>CATEGORY / SUBCATEGORY</strong></th>
 
            <td colspan="3">
              <select id="STUDENTListBox_SubCategory"  runat="server"></select>
 &nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><a href="#" onclick="OpenPopUpList_School('STUDENTATTENDING_SCHOOL_ID');">Attending School ID</a></th>
 
            <td colspan="3"><asp:TextBox id="STUDENTATTENDING_SCHOOL_ID" maxlength="12" Columns="12"	runat="server"/>&nbsp;&nbsp;<asp:Literal id="STUDENTlblAttendingSchoolName" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th><a href="#" onclick="OpenPopUpList_School('STUDENTHOME_SCHOOL_ID');">Home School ID</a></th>
 
            <td colspan="3"><asp:TextBox id="STUDENTHOME_SCHOOL_ID" maxlength="12" Columns="12"	runat="server"/>&nbsp;&nbsp;<asp:Literal id="STUDENTlblHomeSchoolName" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th><strong>Extra Organisation</strong>&nbsp;</th>
 
            <td colspan="3">
              <select id="STUDENTlistORG_SCHOOL_ID"  runat="server"></select>
 <em>&nbsp;(ie: Sports or Drama organisations)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td colspan="3">&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><strong>STUDENT FILES </strong><img onclick="javascript:alert('Student Work Folder Feb 2010');return false;" id="studentfolder_icon" title="Student Work Folder Feb 2010" border="0" name="studentfolderIcon" alt="Student Work Folder" src="images/icon_info.gif"></th>
 
            <td colspan="3">
              <a id="STUDENTlink_showstudentfolder" href="" target="_blank" runat="server"   Visible="False">Show Student Files</a>&nbsp; <asp:Literal id="STUDENTlabelContactPCSupport" runat="server"/>&nbsp; 
              <input id='STUDENTButton_CreateStudentWorkFolder' type="submit" class="Button" value="Create Folder" OnServerClick='STUDENT_Update' runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY / DATE&nbsp;</th>
 
            <td colspan="3"><asp:Literal id="STUDENTLAST_ALTERED_BY" runat="server"/>&nbsp; / <asp:Literal id="STUDENTLAST_ALTERED_DATE" runat="server"/>&nbsp;/ <asp:Literal id="STUDENTlabel_StudentFilesCreated" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="4" align="right">&nbsp; 
              <input id='STUDENTButton_Insert' type="submit" class="Button" value="Add" OnServerClick='STUDENT_Insert' runat="server"/>
              <input id='STUDENTButton_Update' type="submit" class="Button" value="Update" OnServerClick='STUDENT_Update' runat="server"/>
              <input id='STUDENTButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_Cancel' runat="server"/></td>
          </tr>
        </table>
        
  <input id="STUDENTCATEGORY_CODE" type="hidden"  runat="server"/>
  
  <input id="STUDENTSUBCATEGORY_CODE" type="hidden"  runat="server"/>
  
  <input id="STUDENTEnrolmentCategoryTemp" type="hidden"  runat="server"/>
  
  <input id="STUDENThidden_old_ATTENDING_SCHOOL_ID" type="hidden"  runat="server"/>
  
  <input id="STUDENTENROLLEDBEFORE" type="hidden"  runat="server"/>
  
  <input id="STUDENThidden_DATE_STUDENTFOLDER_CREATED" type="hidden"  runat="server"/>
  
  <input id="STUDENThidden_LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="STUDENThidden_LAST_ALTERED_DATE" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>


&nbsp;
  <input id="STUDENTHidden_CURR_RESID_ADDRESS_ID" type="hidden"  runat="server"/>
  
  </span>
  
<p><br>
&nbsp;</p>
<p>&nbsp;</p>

</form>
</body>
</html>

<!--End ASPX page-->

