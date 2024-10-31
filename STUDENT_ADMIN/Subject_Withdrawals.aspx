<!--ASPX page @1-E3AF985B-->
    <%@ Page language="vb" CodeFile="Subject_Withdrawals.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Subject_Withdrawals.Subject_WithdrawalsPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Subject_Withdrawals" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta name="description" content="Forms for Coordinators to quickly perform several steps when withdrawing or changing a Student to non-submitting status."><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Subject Withdrawals and Non-Submitting</title>



<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script

//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_UpdateForm_Button_DoUpdate_OnClick @45-E80F442D
function page_UpdateForm_Button_DoUpdate_OnClick()
{
    var result;
//End page_UpdateForm_Button_DoUpdate_OnClick

//Confirmation Message @72-4B071AFB
    return confirm('Withdraw Students from the selected subject(s) ?');
//End Confirmation Message

//Close page_UpdateForm_Button_DoUpdate_OnClick @45-BC33A33A
    return result;
}
//End Close page_UpdateForm_Button_DoUpdate_OnClick

//page_UpdateForm_Button_DoUpdate1_OnClick @76-F5F6E886
function page_UpdateForm_Button_DoUpdate1_OnClick()
{
    var result;
//End page_UpdateForm_Button_DoUpdate1_OnClick

//Confirmation Message @78-AA53280A
    return confirm('Are you sure you want to NON SUBMIT the selected subject(s) ?');
//End Confirmation Message

//Close page_UpdateForm_Button_DoUpdate1_OnClick @76-BC33A33A
    return result;
}
//End Close page_UpdateForm_Button_DoUpdate1_OnClick

//page_UpdateForm_listNonSubmitReason_OnChange @82-15C53023
function page_UpdateForm_listNonSubmitReason_OnChange()
{
    var result;
//End page_UpdateForm_listNonSubmitReason_OnChange

//Custom Code @89-2A29BDB7
    // -------------------------
    //ERA: Mar-2014|EA| put value from listbox into UpdateFormcoord_comment field
    var dpt=document.getElementById("UpdateFormlistNonSubmitReason");
        //alert(dpt.options[dpt.selectedIndex].value);
document.getElementById("UpdateFormcoord_comment").value =dpt.options[dpt.selectedIndex].value;
        result = true;
    
    // -------------------------
//End Custom Code

//Close page_UpdateForm_listNonSubmitReason_OnChange @82-BC33A33A
    return result;
}
//End Close page_UpdateForm_listNonSubmitReason_OnChange

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//Set Focus @60-2E9CFD24
    if (theForm.SUBJECTSearchs_STUDENT_ID) theForm.SUBJECTSearchs_STUDENT_ID.focus();
//End Set Focus

//Close page_OnLoad @1-BC33A33A
    return result;
}
//End Close page_OnLoad

//bind_events @1-7E05A984
function bind_events() {
    addEventHandler("UpdateFormlistNonSubmitReason","change",page_UpdateForm_listNonSubmitReason_OnChange);
    addEventHandler("UpdateFormButton_DoUpdate1","click",page_UpdateForm_Button_DoUpdate1_OnClick);
    addEventHandler("UpdateFormButton_DoUpdate","click",page_UpdateForm_Button_DoUpdate_OnClick);
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


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p align="center">

  <span id="SUBJECTSearchHolder" runat="server">
    


  <table border="0" cellspacing="0" cellpadding="0" width="50%" align="center">
    <tr>
      <td valign="top">
        <table class="Header" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Subject Withdrawals and Non-Submitting</th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="SUBJECTSearchError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="SUBJECTSearchErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>
            <p align="right">Enter a Student ID</p>
            </th>
 
            <td><asp:TextBox id="SUBJECTSearchs_STUDENT_ID" maxlength="8" Columns="10"	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">Enrol Year&nbsp;</p>
            </th>
 
            <td><asp:TextBox id="SUBJECTSearchs_ENROL_YEAR" maxlength="4" Columns="6"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">
              <input id='SUBJECTSearchButton_DoSearch' type="submit" class="Button" value="Search" OnServerClick='SUBJECTSearch_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  
<p>
<p>

  <span id="UpdateFormHolder" runat="server">
    </p>
<div style="BACKGROUND-COLOR: #ffffff; WIDTH: 60%; MARGIN-LEFT: auto; MARGIN-RIGHT: auto" align="center">
  <asp:Literal id="UpdateFormlblSelections" runat="server"/> 
</div>


  <table border="0" cellspacing="0" cellpadding="0" width="50%" align="center">
    <tr>
      <td valign="top">
        <table class="Header" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Update Form</th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="UpdateFormError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="UpdateFormErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>
            <p align="right">&nbsp;Student ID</p>
            </th>
 
            <td><asp:Literal id="UpdateFormlblStudentID" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">&nbsp;Student Name</p>
            </th>
 
            <td><asp:Literal id="UpdateFormlblFirstname" runat="server"/>&nbsp;<asp:Literal id="UpdateFormlblSurname" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">Enrolment Year</p>
            </th>
 
            <td><asp:Literal id="UpdateFormlblEnrolYear" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">&nbsp;Year Level</p>
            </th>
 
            <td><asp:Literal id="UpdateFormlblYearLevel" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">SS Teacher ID</p>
            </th>
 
            <td><asp:Literal id="UpdateFormlblSSTeacherID" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Bottom" height="5">
            <td colspan="2"></td>
          </tr>
 
          <tr class="Controls">
            <th>
            <h2>&nbsp;</h2>
            </th>
 
            <td>
              <h2>Process Withdrawals</h2>
            </td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">Withdrawal&nbsp;Date</p>
            </th>
 
            <td><asp:TextBox id="UpdateFormwithdrawaldate" maxlength="10" Columns="10"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">&nbsp;Reason Off</p>
            </th>
 
            <td>
              <select id="UpdateFormlistReasonOff"  runat="server"></select>
 &nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">Enrolment Status</p>
            </th>
 
            <td>
              <select id="UpdateFormlistSub_Enrol_Status"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">Early Exit Email</p>
            </th>
 
            <td>&nbsp;<a id="UpdateFormlinkEarlyExit" href="" title="open Early Exit Email" runat="server"  >Open Early Exit Email</a></td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">&nbsp; 
              <input id='UpdateFormButton_DoUpdate' type="submit" class="Button" value="Process Withdrawals and Return" OnServerClick='UpdateForm_Button_DoUpdate_OnClick' runat="server"/>
              <p align="left">&nbsp;<em>Makes ticked 'Process' subjects 'W' at Today; May change Student Enrolment Status to 'N' if all subjects WD</em> </p>
            </td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td>
              <h2>Process Non-Submitting</h2>
            </td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">Reason Non-Submitting</p>
            </th>
 
            <td>
              <select id="UpdateFormlistNonSubmitReason"  runat="server"></select>
 &nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">Coordinator Comment</p>
 
            <p align="right"><em>select [Reason Non-submitting] to pre-fill<br>
            comment which you can then edit</em></p>
            </th>
 
            <td>
<asp:TextBox id="UpdateFormcoord_comment" Columns="50" rows="7" TextMode="MultiLine"	runat="server"/>
&nbsp;</td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">
              <input id='UpdateFormButton_DoUpdate1' type="submit" class="Button" value="Process NON SUBMIT and Return" OnServerClick='UpdateForm_Button_DoUpdate1_OnClick' runat="server"/>&nbsp; 
              <p align="left">&nbsp;<em>Makes ticked 'Process' subjects 'Non Submitting' flag to 'Yes';&nbsp;add 'Coordinator' Comment with above text</em> </p>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>


<p></p>

  </span>
  
<p></p>
<p></p>

<asp:repeater id="SUBJECTRepeater" OnItemCommand="SUBJECTItemCommand" OnItemDataBound="SUBJECTItemDataBound" runat="server">
  <HeaderTemplate>
	
<p>&nbsp;</p>
<table border="0" cellspacing="0" cellpadding="0" width="50%" align="center">
  <tr>
    <td valign="top">
      <table class="Grid" border="0" cellspacing="0" cellpadding="0">
        <tr class="Row">
          <td><em>&nbsp;Rows with 'Process' box ticked will be processed</em></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Row">
          <td colspan="7">Total Records:&nbsp;<asp:Literal id="SUBJECTSUBJECT_TotalRecords" runat="server"/></td>
        </tr>
 
        <tr class="Caption">
          <th>
          <p align="center">&nbsp;Process</p>
          </th>
 
          <th>
          <p align="center">Subject ID</p>
          </th>
 
          <th>
          <p align="center">Subject Status&nbsp;</p>
          </th>
 
          <th>
          <p align="center">Non-Submit&nbsp;</p>
          </th>
 
          <th>Subject Title</th>
 
          <th>
          <p align="center">Semester</p>
          </th>
 
          <th>Teacher&nbsp;</th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr id="displaysubjects_row" runat="server">
          <td style="TEXT-ALIGN: right">
            <p align="center">&nbsp;<asp:CheckBox id="SUBJECTcbox" runat="server"/></p>
          </td> 
          <td>
            <p align="center">&nbsp;<asp:Literal id="SUBJECTSUBJECT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).SUBJECT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></p>
          </td> 
          <td>
            <p align="center">&nbsp;<asp:Literal id="SUBJECTSTATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></p>
          </td> 
          <td>
            <p align="center">&nbsp;<asp:Literal id="SUBJECTNON_SUBMIT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).NON_SUBMIT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></p>
          </td> 
          <td>
            <p align="left"><asp:Literal id="SUBJECTSUBJECT_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).SUBJECT_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></p>
          </td> 
          <td>
            <p align="center">&nbsp;<asp:Literal id="SUBJECTSEMESTER" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).SEMESTER.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></p>
          </td> 
          <td>&nbsp;<asp:Literal id="SUBJECTSTAFF_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).STAFF_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="7">No Subjects Found for selected&nbsp;Student, for selected Enrolment Year</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="7"></td>
        </tr>
      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>

<p></p>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

function makeEarlyExitEmail(emailaddress) {
        //var sMailBody = "&body=Dear Teacher/s%0A%0AThis student meets the criteria for an Early Exit Report, i.e. he/she is a non-school-based (DECV) student who has completed the equivalent of four weeks (one module) of work since the last interim or mid-year reporting cycle. The [Early Exit Report] fillable PDF template can be accessed at http%3A%2F%2Fintranet%2FIntranet%2Fpages%2FForms%2520and%2520Files.aspx. %0A%0APlease complete the [Early Exit Report] Fillable PDF and email it as an attachment to Kathryn Allen within three (3) working days of receiving this email so it can be collated and despatched.%0A%0A%0A%0AThank You.";
        var sMailBody = "&body=Dear Teacher/s%0A%0AThis student meets the criteria for an Early Exit Report.%0A%0APlease complete the [Early Exit Report] fillable PDF at http%3A%2F%2Fintranet%2FIntranet%2Fpages%2FForms%2520and%2520Files.aspx.%0A%0AThank You.";
      document.location.href = 'mailto:'+emailaddress+sMailBody;
}
</script>

</form>
</body>
</html>

<!--End ASPX page-->

