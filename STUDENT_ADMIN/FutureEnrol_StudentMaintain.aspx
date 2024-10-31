<!--ASPX page @1-6DF6A368-->
    <%@ Page language="vb" CodeFile="FutureEnrol_StudentMaintain.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.FutureEnrol_StudentMaintain.FutureEnrol_StudentMaintainPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.FutureEnrol_StudentMaintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="description" content="Student Maintenance page Future enrolments to enter student details and Enrol checklist items. Nov 2018"><meta name="GENERATOR" content="CodeCharge Studio 5.1.0.18696"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Future Enrol - Student Maintain</title>



<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-092F8E28
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript" charset="utf-8" src='ClientI18N.aspx?file=DatePicker.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

</script>
<script language="JavaScript" src="js/pt/prototype_ccs.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/yui/build/yahoo-dom-event/yahoo-dom-event.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/yui/build/calendar/calendar-min.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/yui/datepicker-commons.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">


//Date Picker Object Definitions @1-E768D9C8

var STUDENTDatePicker_BIRTH_DATE = new Object(); 
STUDENTDatePicker_BIRTH_DATE.format           = "dd/mm/yyyy";
STUDENTDatePicker_BIRTH_DATE.style            = "Styles/Blueprint/Style.css";
STUDENTDatePicker_BIRTH_DATE.relativePathPart = "";
STUDENTDatePicker_BIRTH_DATE.themeVersion     = "3.0";
//End Date Picker Object Definitions

//page_STUDENT_Button_Update_OnClick @26-DB04562F
function page_STUDENT_Button_Update_OnClick()
{
    var result;
//End page_STUDENT_Button_Update_OnClick

//Custom Code @27-2A29BDB7
    // -------------------------
    // Write your own code here.
        ValidateVSN();
    // -------------------------
//End Custom Code

//Custom Code @28-2A29BDB7
    // -------------------------
    result = true;
    // -------------------------
//End Custom Code

//Close page_STUDENT_Button_Update_OnClick @26-BC33A33A
    return result;
}
//End Close page_STUDENT_Button_Update_OnClick

//page_STUDENT_ENROLMENT_ENROLMENT_STATUS_OnChange @139-211BF260
function page_STUDENT_ENROLMENT_ENROLMENT_STATUS_OnChange()
{
    var result;
//End page_STUDENT_ENROLMENT_ENROLMENT_STATUS_OnChange

//Confirmation Message @287-FF4980BC
    return confirm('Add a comment for why the Status is changing');
//End Confirmation Message

//Close page_STUDENT_ENROLMENT_ENROLMENT_STATUS_OnChange @139-BC33A33A
    return result;
}
//End Close page_STUDENT_ENROLMENT_ENROLMENT_STATUS_OnChange

//page_STUDENT_COMMENT_lbCannedResponses_OnChange @97-947644D6
function page_STUDENT_COMMENT_lbCannedResponses_OnChange()
{
    var result;
//End page_STUDENT_COMMENT_lbCannedResponses_OnChange

//Custom Code @98-2A29BDB7
    // -------------------------
     //      If Comment already has something then append to end (leading space) otherwise trailing space
        if (theForm.STUDENT_COMMENTlbCannedResponses.value !='') {
                if(theForm.STUDENT_COMMENTCOMMENT.value.length > 0) {
                theForm.STUDENT_COMMENTCOMMENT.value = theForm.STUDENT_COMMENTCOMMENT.value + ' ' + theForm.STUDENT_COMMENTlbCannedResponses.value;
        } else {
                        theForm.STUDENT_COMMENTCOMMENT.value = theForm.STUDENT_COMMENTlbCannedResponses.value + ' ';
                }
                theForm.STUDENT_COMMENTCOMMENT.focus();
    }
    // -------------------------
//End Custom Code

//Set Focus @99-AB2838AB
    if (theForm.STUDENT_COMMENTCOMMENT) theForm.STUDENT_COMMENTCOMMENT.focus();
//End Set Focus

//Close page_STUDENT_COMMENT_lbCannedResponses_OnChange @97-BC33A33A
    return result;
}
//End Close page_STUDENT_COMMENT_lbCannedResponses_OnChange

//page_STUDENT_Button_Cancel_OnClick @29-AF0AE409
function page_STUDENT_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_Button_Cancel_OnClick

//page_EditableGrid1_Cancel_OnClick @195-35441E36
function page_EditableGrid1_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_EditableGrid1_Cancel_OnClick

//page_EditableGrid1_Button_LoadChecklist_OnClick @253-21EAD36E
function page_EditableGrid1_Button_LoadChecklist_OnClick()
{
    disableValidation = true;
}
//End page_EditableGrid1_Button_LoadChecklist_OnClick

//page_STUDENT_COMMENT_Button_Cancel_OnClick @259-3BF1766F
function page_STUDENT_COMMENT_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_COMMENT_Button_Cancel_OnClick

//bind_events @1-50F77868
function bind_events() {
    addEventHandler("STUDENT_COMMENTlbCannedResponses","change",page_STUDENT_COMMENT_lbCannedResponses_OnChange);
    addEventHandler("STUDENT_ENROLMENTENROLMENT_STATUS","change",page_STUDENT_ENROLMENT_ENROLMENT_STATUS_OnChange);
    addEventHandler("STUDENTButton_Update","click",page_STUDENT_Button_Update_OnClick);
    addEventHandler("STUDENTButton_Cancel","click",page_STUDENT_Button_Cancel_OnClick);
    addEventHandler("EditableGrid1Cancel","click",page_EditableGrid1_Cancel_OnClick);
    addEventHandler("EditableGrid1Button_LoadChecklist","click",page_EditableGrid1_Button_LoadChecklist_OnClick);
    addEventHandler("STUDENT_COMMENTButton_Cancel","click",page_STUDENT_COMMENT_Button_Cancel_OnClick);
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events
window.onload = bind_events;

//End CCS script
</script>
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
<script language="JavaScript" type="text/javascript">
function limitMaxLength(formitem,maxlength,displaydivname) {
        if (isNaN(maxlength)) {
                return false;
        } else {
                var outputdiv = document.getElementById(displaydivname)
                outputdiv.innerHTML = (maxlength-formitem.value.length) + ' characters allowed';
                if (formitem.value.length+1>maxlength) {
                        formitem.value=formitem.value.substring(0,maxlength);
                }
        }
}
</script>
<style type="text/css">
<!--
.AlertRed       td  { font-weight: bold; background-color: #FF6666; vertical-align: left; text-align: left; border-top-width: 1px; border-top-color: #3D84CC; border-top-style: solid; border-right-width: 1px; border-right-color: #3D84CC; border-right-style: solid; padding-top: 4px; padding-right: 4px; padding-bottom: 4px; padding-left: 4px; }
.AlertGreen     td  { font-weight: bold; background-color: #66CC33; vertical-align: left; text-align: left; border-top-width: 1px; border-top-color: #3D84CC; border-top-style: solid; border-right-width: 1px; border-right-color: #3D84CC; border-right-style: solid; padding-top: 4px; padding-right: 4px; padding-bottom: 4px; padding-left: 4px; }
.CoordAmber     td  { font-weight: bold; background-color: #FF9933; vertical-align: left; text-align: left; border-top-width: 1px; border-top-color: #3D84CC; border-top-style: solid; border-right-width: 1px; border-right-color: #3D84CC; border-right-style: solid; padding-top: 4px; padding-right: 4px; padding-bottom: 4px; padding-left: 4px; }
.LightMauve     td  { font-weight: bold; background-color: #B3B3D7; vertical-align: left; text-align: left; border-top-width: 1px; border-top-color: #3D84CC; border-top-style: solid; border-right-width: 1px; border-right-color: #3D84CC; border-right-style: solid; padding-top: 4px; padding-right: 4px; padding-bottom: 4px; padding-left: 4px; }
.Pathways       td  { font-weight: bold; background-color: #038C9A; vertical-align: left; text-align: left; border-top-width: 1px; border-top-color: #3D84CC; border-top-style: solid; border-right-width: 1px; border-right-color: #3D84CC; border-right-style: solid; padding-top: 4px; padding-right: 4px; padding-bottom: 4px; padding-left: 4px; }
.autosave_saving  { font-weight: bold; color: #66CC33; }
-->
</style>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p>&nbsp;</p>
<p align="center">

  <span id="STUDENTHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" width="85%" align="center" border="0">
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
 
            <td><asp:Literal id="STUDENTlblStudentID" runat="server"/></td> 
            <td><strong>VSN</strong></td> 
            <td><asp:TextBox id="STUDENTVSN" onblur="javascript: return ValidateVSN();" maxlength="9" Columns="10"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th><strong>SURNAME</strong></th>
 
            <td><asp:TextBox id="STUDENTSURNAME" maxlength="30" Columns="30"	runat="server"/></td> 
            <td><strong>FIRST NAME</strong></td> 
            <td><asp:TextBox id="STUDENTFIRST_NAME" maxlength="30" Columns="30"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th colspan="2"><em></em></th>
 
            <td><strong>PREFERRED NAME</strong></td> 
            <td><asp:TextBox id="STUDENTPREFERRED_NAME" maxlength="30" Columns="30"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th><strong>MIDDLE NAME</strong></th>
 
            <td><asp:TextBox id="STUDENTMIDDLE_NAME" maxlength="30" Columns="30"	runat="server"/></td> 
            <td><strong>DATE OF BIRTH (DD/MM/YY)</strong></td> 
            <td><asp:TextBox id="STUDENTBIRTH_DATE" maxlength="100" Columns="8"	runat="server"/>
              <asp:PlaceHolder id="STUDENTDatePicker_BIRTH_DATE" runat="server"><a href="javascript:showDatePicker('<%#STUDENTDatePicker_BIRTH_DATEName%>','forms[\''+theForm.id+'\']','<%#STUDENTDatePicker_BIRTH_DATEDateControl%>');" id="STUDENTDatePicker_BIRTH_DATE_Link"  ><img border="0" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" /></a></asp:PlaceHolder>
  </td>
          </tr>
 
          <tr class="Controls">
            <th></th>
 
            <td></td> 
            <td></td> 
            <td></td>
          </tr>
 
          <tr class="Controls">
            <th><strong>GENDER</strong></th>
 
            <td>
              <asp:RadioButtonList id="STUDENTSEX"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
            <td><strong>VCE CANDIDATE NUMBER&nbsp;(12345678A)</strong></td> 
            <td><asp:TextBox id="STUDENTVCE_CANDIDATE_NUMBER" maxlength="10" Columns="12"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th></th>
 
            <td></td> 
            <td></td> 
            <td></td>
          </tr>
 
          <tr class="Controls">
            <th><strong>Student Email Address</strong></th>
 
            <td><asp:TextBox id="STUDENTSTUDENT_EMAIL" maxlength="250" Columns="40"	runat="server"/></td> 
            <td></td> 
            <td></td>
          </tr>
 
          <tr class="Controls">
            <th><strong>Student Mobile</strong></th>
 
            <td><asp:TextBox id="STUDENTSTUDENT_MOBILE" maxlength="20"	runat="server"/></td> 
            <td><em></em></td> 
            <td></td>
          </tr>
 
          <tr class="Controls">
            <th></th>
 
            <td></td> 
            <td></td> 
            <td></td>
          </tr>
 
          <tr class="Controls">
            <th><strong>CATEGORY / SUBCATEGORY</strong></th>
 
            <td colspan="3">
              <select id="STUDENTListBox_SubCategory"  runat="server"></select>
 &nbsp; </td>
          </tr>
 
          <tr class="Controls">
            <th><a href="#" onclick="OpenPopUpList_School('STUDENTATTENDING_SCHOOL_ID');">Attending School ID</a></th>
 
            <td colspan="3"><asp:TextBox id="STUDENTATTENDING_SCHOOL_ID" maxlength="12" Columns="12"	runat="server"/><asp:Literal id="STUDENTlblAttendingSchoolName" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th><a href="#" onclick="OpenPopUpList_School('STUDENTHOME_SCHOOL_ID');">Home School ID</a></th>
 
            <td colspan="3"><asp:TextBox id="STUDENTHOME_SCHOOL_ID" maxlength="12" Columns="12"	runat="server"/><asp:Literal id="STUDENTlblHomeSchoolName" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th><strong>Extra Organisation</strong></th>
 
            <td colspan="3">
              <select id="STUDENTlistORG_SCHOOL_ID"  runat="server"></select>
 <em>(ie: Sports or Drama organisations)</em></td>
          </tr>
 
          <tr class="Controls">
            <th></th>
 
            <td colspan="3"></td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY / DATE&nbsp;</th>
 
            <td colspan="3"><asp:Literal id="STUDENTLAST_ALTERED_BY" runat="server"/>&nbsp; / <asp:Literal id="STUDENTLAST_ALTERED_DATE" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="4" align="right"><asp:Image id="STUDENTajaxBusy"  style="DISPLAY: none" AlternateText="updating" ImageUrl="images/ajax_loader.gif" runat="server"/>
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



  <input id="STUDENTHidden_CURR_RESID_ADDRESS_ID" type="hidden"  runat="server"/>
  
  </span>
  </p>
<p align="center">

  <span id="STUDENT_ENROLMENTHolder" runat="server">
    


  <table class="MainTable" cellspacing="0" cellpadding="0" width="85%" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft">&nbsp;</td> 
            <td class="th"><strong>Edit STUDENT ENROLMENT </strong></td> 
            <td class="HeaderRight">&nbsp;</td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="STUDENT_ENROLMENTError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="10"><span id="ErrorBlock"><asp:Label ID="STUDENT_ENROLMENTErrorLabel" runat="server"/></span></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <td><asp:Literal id="STUDENT_ENROLMENTlblENROLMENT_YEAR" runat="server"/></td> 
            <td class="th"><label>ENROLMENT STATUS</label></td> 
            <td>
              <select id="STUDENT_ENROLMENTENROLMENT_STATUS"  runat="server"></select>
 </td> 
            <td class="th"><label>ENROLMENT DATE</label></td> 
            <td><asp:TextBox id="STUDENT_ENROLMENTENROLMENT_DATE" maxlength="100" Columns="10"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <td class="th">&nbsp;</td> 
            <td class="th"><label>YEAR LEVEL</label></td> 
            <td>
              <select id="STUDENT_ENROLMENTYEAR_LEVEL"  runat="server"></select>
 </td> 
            <td class="th">&nbsp;LAST ALTERED BY / WHEN</td> 
            <td><asp:Literal id="STUDENT_ENROLMENTLAST_ALTERED_BY1" runat="server"/>&nbsp;/&nbsp;&nbsp;<asp:Literal id="STUDENT_ENROLMENTLAST_ALTERED_DATE1" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td style="TEXT-ALIGN: right" colspan="10">
              <input id='STUDENT_ENROLMENTButton_Add' type="submit" class="Button" value="Add Year" OnServerClick='STUDENT_ENROLMENT_Insert' runat="server"/>
              <input id='STUDENT_ENROLMENTButton_Update' type="submit" class="Button" value="Update" OnServerClick='STUDENT_ENROLMENT_Update' runat="server"/></td>
          </tr>
        </table>
        
  <input id="STUDENT_ENROLMENTLAST_ALTERED_DATE" type="hidden"  runat="server"/>
  
  <input id="STUDENT_ENROLMENTLAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="STUDENT_ENROLMENTSTUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="STUDENT_ENROLMENTENROLMENT_YEAR" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>



  </span>
  </p>
<p align="center">

  <span id="STUDENT_COMMENTHolder" runat="server">
    


  &nbsp; 
  <table cellspacing="0" cellpadding="0" width="85%" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Add Comment</th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="STUDENT_COMMENTError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="STUDENT_COMMENTErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>STUDENT ID </th>
 
            <td><asp:Literal id="STUDENT_COMMENTlblSTUDENT_ID" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>COMMENT 
            <div id="maxchar_comment">
              500 characters allowed 
            </div>
            <br>
            <select id="STUDENT_COMMENTlbCannedResponses"  runat="server"></select>
 </th>
 
            <td>
<asp:TextBox id="STUDENT_COMMENTCOMMENT" onkeyup="limitMaxLength(this,500,'maxchar_comment');" rows="3" Columns="70" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
            <th><asp:Literal id="STUDENT_COMMENTlblCommentType" runat="server"/></th>
 
            <td>
              
              <select id="STUDENT_COMMENTlbSpecialCommentType"  runat="server"></select>
 &nbsp;&nbsp; 
              
              <select id="STUDENT_COMMENTlbSpecialCommentType1"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">
              <input id='STUDENT_COMMENTButton_Insert' type="submit" class="Button" value="Add Comment" OnServerClick='STUDENT_COMMENT_Insert' runat="server"/>
              <input id='STUDENT_COMMENTButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_COMMENT_Cancel' runat="server"/></td>
          </tr>
        </table>
        
  <input id="STUDENT_COMMENTSTUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="STUDENT_COMMENThidden_STATUS" type="hidden"  runat="server"/>
  
  <input id="STUDENT_COMMENTHidden_CommentType" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>



  </span>
  </p>
<p align="center">

<asp:repeater id="Grid_DisplayCommentsRepeater" OnItemCommand="Grid_DisplayCommentsItemCommand" OnItemDataBound="Grid_DisplayCommentsItemDataBound" runat="server">
  <HeaderTemplate>
	
<table id="Table_PublicComments" cellspacing="0" cellpadding="0" width="85%" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>Future Enrolment Comments</th>
 
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>&nbsp;</th>
 
          <th>COMMENT</th>
 
          <th>&nbsp;TYPE</th>
 
          <th>
          <p align="center">LAST ALTERED BY</p>
          </th>
 
          <th>
          <p align="center">LAST ALTERED DATE</p>
          </th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr id="displaycomments_row" runat="server">
          <td>&nbsp;<a id="Grid_DisplayCommentslink_editcomment" href="" runat="server"  >edit</a></td> 
          <td><asp:Literal id="Grid_DisplayCommentsCOMMENT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_DisplayCommentsItem)).COMMENT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td>&nbsp;<asp:Literal id="Grid_DisplayCommentsCOMMENT_TYPE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_DisplayCommentsItem)).COMMENT_TYPE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>
            <div align="center">
              <asp:Literal id="Grid_DisplayCommentsLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_DisplayCommentsItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp; 
            </div>
          </td> 
          <td nowrap>
            <div align="center">
              <asp:Literal id="Grid_DisplayCommentsLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_DisplayCommentsItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;&nbsp; 
            </div>
          </td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="5">No Comments found.</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="5">
            
<CC:Navigator id="Navigator1Navigator" MaxPage="<%# Grid_DisplayCommentsData.PagesCount%>" PageSize="<%# Grid_DisplayCommentsData.RecordsPerPage%>" PageNumber="<%# Grid_DisplayCommentsData.PageNumber%>" runat="server">&nbsp; 
            Per page: 
            <CC:PageSizer AutoPostBack="true" runat="server" />
 
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="Navigator1First" runat="server"><img border="0" src="Styles/Blueprint/Images/en/ButtonFirst.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="Navigator1Prev" runat="server"><img border="0" src="Styles/Blueprint/Images/en/ButtonPrev.gif"></asp:LinkButton> </CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %>&nbsp;of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="Navigator1Next" runat="server"><img border="0" src="Styles/Blueprint/Images/en/ButtonNext.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="Navigator1Last" runat="server"><img border="0" src="Styles/Blueprint/Images/en/ButtonLast.gif"></asp:LinkButton> </CC:NavigatorItem></CC:Navigator>
</td>
        </tr>
      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
</p>
<p align="center">

<asp:repeater id="EditableGrid1Repeater" OnItemCommand="EditableGrid1ItemCommand" OnItemDataBound="EditableGrid1ItemDataBound" runat="server">
  <HeaderTemplate>
  


  
	<script language="JavaScript" >
	var EditableGrid1Elements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initEditableGrid1Elements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
  <table class="MainTable" cellspacing="0" cellpadding="0" width="85%" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Student Enrolment Checklist</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Grid" cellspacing="0" cellpadding="0">
          <tr class="Error">
            <td colspan="6">Make sure you check for any Errors in each row after Updates</td>
          </tr>
          
  <asp:PlaceHolder id="EditableGrid1Error" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="6"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Caption">
            <th>Id</th>
 
            <th>Item Description</th>
 
            <th>Item Received?</th>
 
            <th>Notes (Public!)</th>
 
            <th>Last Altered By / When</th>
 
            <th>Delete</th>
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
    
          
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
          <tr class="Error">
            <td colspan="6"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Row">
            <td><asp:Literal id="EditableGrid1id" Text='<%# Server.HtmlEncode((CType(Container.DataItem,EditableGrid1Item)).id.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td nowrap><asp:Literal id="EditableGrid1description" Text='<%# Server.HtmlEncode((CType(Container.DataItem,EditableGrid1Item)).description.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td nowrap>
              <asp:RadioButtonList id="EditableGrid1option_received"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
            <td><asp:TextBox id="EditableGrid1notes_public" Text='<%# (CType(Container.DataItem,EditableGrid1Item)).notes_public.GetFormattedValue() %>' maxlength="200" Columns="35"	runat="server"/></td> 
            <td><asp:Literal id="EditableGrid1lblWho" Text='<%# Server.HtmlEncode((CType(Container.DataItem,EditableGrid1Item)).lblWho.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ <asp:Literal id="EditableGrid1lblWhen" Text='<%# Server.HtmlEncode((CType(Container.DataItem,EditableGrid1Item)).lblWhen.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>
  <input id="EditableGrid1last_altered_when"  value='<%# (CType(Container.DataItem,EditableGrid1Item)).last_altered_when.GetFormattedValue() %>' type="hidden"  runat="server"/>
  
  <input id="EditableGrid1last_altered_by"  value='<%# (CType(Container.DataItem,EditableGrid1Item)).last_altered_by.GetFormattedValue() %>' type="hidden"  runat="server"/>
  
  <input id="EditableGrid1hidden_hashchanges"  value='<%# (CType(Container.DataItem,EditableGrid1Item)).hidden_hashchanges.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td> 
            <td>
              <asp:CheckBox id="EditableGrid1CheckBox_Delete" Visible = "<%# (CType(Container.DataItem,EditableGrid1Item)).IsDeleteAllowed %>" runat="server"/>&nbsp;</td>
          </tr>
 
  </ItemTemplate>

  <FooterTemplate>
	
          
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
          <tr class="NoRecords">
            <td colspan="6">No Student Enrolment items found! - Update Student Enrolment Category then click 
              <asp:Button id="EditableGrid1Button_LoadChecklist" CssClass="Button" Text="Load Checklist" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Footer">
            <td style="TEXT-ALIGN: right" colspan="6">
              <asp:Button id="EditableGrid1Button_Submit" CssClass="Button" Text="Update Changes" CommandName="Submit" runat="server"/>
              <asp:Button id="EditableGrid1Cancel" CssClass="Button" Text="Cancel" runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </FooterTemplate>
</asp:repeater>
<br>
</p>
<p align="center">&nbsp;</p>

</form>
</body>
</html>

<!--End ASPX page-->

