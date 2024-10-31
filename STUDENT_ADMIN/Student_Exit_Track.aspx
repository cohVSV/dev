<!--ASPX page @1-65D85A0D-->
    <%@ Page language="vb" CodeFile="Student_Exit_Track.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_Exit_Track.Student_Exit_TrackPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_Exit_Track" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 4.1.00.032"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Exit Tracking</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//Set Focus @64-FA107954
    if (theForm.viewMaintainSearchRequests_STUDENT_ID) theForm.viewMaintainSearchRequests_STUDENT_ID.focus();
//End Set Focus

//Close page_OnLoad @1-BC33A33A
    return result;
}
//End Close page_OnLoad

//page_Student_Exit_Button_Cancel_OnClick @7-FDFF9EE5
function page_Student_Exit_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_Student_Exit_Button_Cancel_OnClick

//bind_events @1-C9BB64C9
function bind_events() {
    addEventHandler("Student_ExitButton_Cancel","click",page_Student_Exit_Button_Cancel_OnClick);
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


<DECV_PROD2007:Header id="Header" runat="server"/> 
<p align="center">

  <span id="viewMaintainSearchRequestHolder" runat="server">
    


  <table border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td valign="top">
        <table class="Header" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Search Exited Students</th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="viewMaintainSearchRequestError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="viewMaintainSearchRequestErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>STUDENT ID</th>
 
            <td><asp:TextBox id="viewMaintainSearchRequests_STUDENT_ID" maxlength="12" Columns="12"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>ENROLMENT YEAR</th>
 
            <td><asp:TextBox id="viewMaintainSearchRequests_ENROLMENT_YEAR" maxlength="12" Columns="12"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td>&nbsp;<a id="viewMaintainSearchRequestClearParameters" href="" runat="server"  >Clear</a></td> 
            <td align="right">
              <input id='viewMaintainSearchRequestButton_DoSearch' type="submit" class="Button" value="Search" OnServerClick='viewMaintainSearchRequest_Search' runat="server"/></td>
          </tr>
        </table>
        <em><strong>Currently Enrolled Students will NOT be found</strong></em></td>
    </tr>
  </table>



  </span>
  <br>
</p>

  <span id="Student_ExitHolder" runat="server">
    


  <table style="WIDTH: 696px; HEIGHT: 368px" border="0" cellspacing="0" cellpadding="0" align="center">
    <tr>
      <td valign="top">
        <table class="Header" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Student Tracking </th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="Student_ExitError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="4"><asp:Label ID="Student_ExitErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th><strong>Name</strong>&nbsp;</th>
 
            <td><asp:Literal id="Student_ExitLbl_Name" runat="server"/>&nbsp;</td> 
            <td>&nbsp;<strong>Student ID</strong></td> 
            <td><asp:Literal id="Student_ExitLbl_StudentID" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><strong>Withdrawal Reason</strong></th>
 
            <td><asp:Literal id="Student_ExitLbl_WithDrawnReason" runat="server"/>&nbsp;</td> 
            <td>&nbsp;<strong>Withdrawal Date</strong></td> 
            <td><asp:Literal id="Student_ExitLbl_WithDrawnDate" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th><strong></strong></th>
 
            <td>&nbsp;&nbsp; </td> 
            <td><strong>&nbsp;</strong></td> 
            <td>&nbsp; </td>
          </tr>
 
          <tr class="Controls">
            <th><strong>Exit Destination</strong></th>
 
            <td>
              <select id="Student_ExitlbEXIT_DESTINATION"  runat="server"></select>
 </td> 
            <td><strong>&nbsp; 
  <input id="Student_ExitHidden_CommentID" type="hidden"  runat="server"/>
  </strong></td> 
            <td>&nbsp; </td>
          </tr>
 
          <tr class="Controls">
            <th><strong>Comments</strong></th>
 
            <td colspan="3">
<asp:TextBox id="Student_ExitTextAreaComments" style="WIDTH: 406px; HEIGHT: 54px" Columns="39" rows="3" TextMode="MultiLine"	runat="server"/>
&nbsp; </td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp; </td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY / DATE</th>
 
            <td>&nbsp;<asp:Literal id="Student_ExitLAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="Student_ExitLAST_ALTERED_DATE" runat="server"/></td> 
            <td>&nbsp;
  <input id="Student_ExitTXT_LastAlteredBy" type="hidden"  runat="server"/>
  </td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="4" align="right">&nbsp; 
              <input id='Student_ExitButton_Update' type="submit" class="Button" value="Save" OnServerClick='Student_Exit_Update' runat="server"/>
              <input id='Student_ExitButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='Student_Exit_Cancel' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  &nbsp; 

</form>
</body>
</html>

<!--End ASPX page-->

