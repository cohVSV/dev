<!--ASPX page @1-B9760BE3-->
    <%@ Page language="vb" CodeFile="Staff_Inductions_ByStaff_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Staff_Inductions_ByStaff_maint.Staff_Inductions_ByStaff_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Staff_Inductions_ByStaff_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 4.1.00.032" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Staff Inductions - By Staff</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-B52976BB
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src='ClientI18N.aspx?file=DatePicker.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="utf-8"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Date Picker Object Definitions @1-3A4616CF

var STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED = new Object(); 
STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED.format           = "dd/mm/yyyy";
STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED.style            = "Styles/Blueprint/Style.css";
STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED.relativePathPart = "";
STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED.themeVersion     = "3.0";
//End Date Picker Object Definitions

//page_STAFF_INDUCTIONS_PROGRESS_Button_Delete_OnClick @38-B22C9A81
function page_STAFF_INDUCTIONS_PROGRESS_Button_Delete_OnClick()
{
    var result;
//End page_STAFF_INDUCTIONS_PROGRESS_Button_Delete_OnClick

//Confirmation Message @39-8243B274
    return confirm('Delete record?');
//End Confirmation Message

//Close page_STAFF_INDUCTIONS_PROGRESS_Button_Delete_OnClick @38-BC33A33A
    return result;
}
//End Close page_STAFF_INDUCTIONS_PROGRESS_Button_Delete_OnClick

//page_STAFF_INDUCTIONS_PROGRESS_Button_Cancel_OnClick @40-E3D0FE50
function page_STAFF_INDUCTIONS_PROGRESS_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STAFF_INDUCTIONS_PROGRESS_Button_Cancel_OnClick

//bind_events @1-3DC41C24
function bind_events() {
    addEventHandler("STAFF_INDUCTIONS_PROGRESSButton_Delete","click",page_STAFF_INDUCTIONS_PROGRESS_Button_Delete_OnClick);
    addEventHandler("STAFF_INDUCTIONS_PROGRESSButton_Cancel","click",page_STAFF_INDUCTIONS_PROGRESS_Button_Cancel_OnClick);
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

window.onload = bind_events; 

//End CCS script
</script>
<script type="text/javascript">
 function toggle_hide(divID) {
 var item = document.getElementById(divID);
 if (item) {
        item.style.display = (item.style.display=='none')?'block':'none';}
 }
 </script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p><a id="link_backtolist" href="" class="Button" runat="server"  >back to list</a><br>

  <span id="STAFF_INDUCTIONS_PROGRESSHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Add/Edit Staff Inductions</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="STAFF_INDUCTIONS_PROGRESSError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="STAFF_INDUCTIONS_PROGRESSErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>STAFF&nbsp;ID&nbsp;</th>
 
            <td><asp:Literal id="STAFF_INDUCTIONS_PROGRESSlbl_STAFF_ID" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>INDUCTION&nbsp;</th>
 
            <td>
              <select id="STAFF_INDUCTIONS_PROGRESSlistbox_InductionCourses"  runat="server"></select>
 &nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>STATUS</th>
 
            <td>
              <select id="STAFF_INDUCTIONS_PROGRESSSTAFF_INDUCTIONS_PROGRESS_STATUS"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th>DATE COMPLETED</th>
 
            <td><asp:TextBox id="STAFF_INDUCTIONS_PROGRESSDATE_COMPLETED" maxlength="100" Columns="10"	runat="server"/>
              <asp:PlaceHolder id="STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED" runat="server"><a href="javascript:showDatePicker('<%#STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETEDName%>','forms[\''+theForm.id+'\']','<%#STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETEDDateControl%>');" id="STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED_Link"  ><img id="STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED_Image" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" border="0" />&nbsp;&nbsp;</a></asp:PlaceHolder>
  </td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY / DATE&nbsp;</th>
 
            <td><asp:Literal id="STAFF_INDUCTIONS_PROGRESSLAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="STAFF_INDUCTIONS_PROGRESSLAST_ALTERED_DATE" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='STAFF_INDUCTIONS_PROGRESSButton_Insert' class="Button" type="submit" value="Add" OnServerClick='STAFF_INDUCTIONS_PROGRESS_Insert' runat="server"/>
              <input id='STAFF_INDUCTIONS_PROGRESSButton_Update' class="Button" type="submit" value="Save" OnServerClick='STAFF_INDUCTIONS_PROGRESS_Update' runat="server"/>
              <input id='STAFF_INDUCTIONS_PROGRESSButton_Delete' class="Button" type="submit" value="Delete" OnServerClick='STAFF_INDUCTIONS_PROGRESS_Delete' runat="server"/>
              <input id='STAFF_INDUCTIONS_PROGRESSButton_Cancel' class="Button" type="submit" value="Cancel" OnServerClick='STAFF_INDUCTIONS_PROGRESS_Cancel' runat="server"/></td>
          </tr>
        </table>
        
  <input id="STAFF_INDUCTIONS_PROGRESSHidden_last_altered_by" type="hidden"  runat="server"/>
  
  <input id="STAFF_INDUCTIONS_PROGRESSHidden_last_altered_date" type="hidden"  runat="server"/>
  
  <input id="STAFF_INDUCTIONS_PROGRESSHidden_STAFF_ID" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>


&nbsp;<a id="STAFF_INDUCTIONS_PROGRESSLink1_David" href="" onclick="toggle_hide('unic');" runat="server"   Visible="False">David? Is that you?</a>
  </span>
  <br>
<br>
<br>
<p><img id="unic" style="DISPLAY: none; MARGIN: auto; cursor: hand; cursor: pointer;" onclick="toggle_hide('unic');" src="images/unic.jpg" name="unic"></p>

</form>
</body>
</html>

<!--End ASPX page-->

