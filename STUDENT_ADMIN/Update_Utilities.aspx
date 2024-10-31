<!--ASPX page @1-968A3398-->
    <%@ Page language="vb" CodeFile="Update_Utilities.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Update_Utilities.Update_UtilitiesPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Update_Utilities" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Despatch Update by Year</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script

//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_UpdateForm_Button_DoUpdate1_OnClick @75-F5F6E886
function page_UpdateForm_Button_DoUpdate1_OnClick()
{
    var result;
//End page_UpdateForm_Button_DoUpdate1_OnClick

//Validate Required Value @82-784DAF30
    if(theForm.UpdateFormtxtEnrolYear1.value == "") {
        alert("The [Enrolment Year] is required.")
        theForm.UpdateFormtxtEnrolYear1.focus();
        return false;
    }
//End Validate Required Value

//Close page_UpdateForm_Button_DoUpdate1_OnClick @75-BC33A33A
    return result;
}
//End Close page_UpdateForm_Button_DoUpdate1_OnClick

//page_UpdateForm_Button_DoUpdate3_OnClick @79-DBA62106
function page_UpdateForm_Button_DoUpdate3_OnClick()
{
    var result;
//End page_UpdateForm_Button_DoUpdate3_OnClick

//Confirmation Message @80-A250FB48
    return confirm('Are you SURE you wish to run the Update Time Fraction?');
//End Confirmation Message

//Close page_UpdateForm_Button_DoUpdate3_OnClick @79-BC33A33A
    return result;
}
//End Close page_UpdateForm_Button_DoUpdate3_OnClick

//page_UpdateForm_Button_DoUpdate2_OnClick @45-CC8E45C6
function page_UpdateForm_Button_DoUpdate2_OnClick()
{
    var result;
//End page_UpdateForm_Button_DoUpdate2_OnClick

//Validate Required Value @83-1B6BD73A
    if(theForm.UpdateFormtxtEnrolYear2.value == "") {
        alert("The [Enrolment Year] is required.")
        theForm.UpdateFormtxtEnrolYear2.focus();
        return false;
    }
//End Validate Required Value

//Validate Required Value @84-C983D5C6
    if(theForm.UpdateFormtxtGrace.value == "") {
        alert("The [Grace Period] is required.")
        theForm.UpdateFormtxtGrace.focus();
        return false;
    }
//End Validate Required Value

//Close page_UpdateForm_Button_DoUpdate2_OnClick @45-BC33A33A
    return result;
}
//End Close page_UpdateForm_Button_DoUpdate2_OnClick

//bind_events @1-06607318
function bind_events() {
    addEventHandler("UpdateFormButton_DoUpdate2","click",page_UpdateForm_Button_DoUpdate2_OnClick);
    addEventHandler("UpdateFormButton_DoUpdate3","click",page_UpdateForm_Button_DoUpdate3_OnClick);
    addEventHandler("UpdateFormButton_DoUpdate1","click",page_UpdateForm_Button_DoUpdate1_OnClick);
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

//End CCS script

window.onload = bind_events;

</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p>&nbsp;</p>
<p>

  <span id="UpdateFormHolder" runat="server">
    


  <div align="center">
    <table border="0" cellspacing="0" cellpadding="0" align="center">
      <tr>
        <td valign="top">
          <table class="Header" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
              <th>Update Utilities</th>
 
              <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            </tr>
 
          </table>
 
          <table class="Record" cellspacing="0" cellpadding="0">
            
  <asp:PlaceHolder id="UpdateFormError" visible="False" runat="server">
  
            <tr class="Error">
              <td colspan="6"><asp:Label ID="UpdateFormErrorLabel" runat="server"/></td> 
            </tr>
 
  </asp:PlaceHolder>
  
            <tr class="Controls">
              <th><strong>&nbsp;Update Finished Students</strong></th>
 
              <td>&nbsp;Enrolment Year</td> 
              <td><asp:TextBox id="UpdateFormtxtEnrolYear1" maxlength="4" Columns="5"	runat="server"/></td> 
              <td>
                <p align="right">&nbsp;Campus</p>
 </td> 
              <td>&nbsp;<em>VSV</em></td> 
              <td>&nbsp; 
                <input id='UpdateFormButton_DoUpdate1' type="submit" class="Button" value="Run" OnServerClick='UpdateForm_Button_DoUpdate1_OnClick' runat="server"/></td> 
            </tr>
 
            <tr class="Bottom" height="15">
              <td colspan="6"></td> 
            </tr>
 
            <tr class="Controls">
              <th><strong>&nbsp;Update Time Fraction</strong></th>
 
              <td>&nbsp;N/A</td> 
              <td>&nbsp;</td> 
              <td>&nbsp;</td> 
              <td>&nbsp;</td> 
              <td>&nbsp; 
                <input id='UpdateFormButton_DoUpdate3' type="submit" class="Button" value="Run" OnServerClick='UpdateForm_Button_DoUpdate3_OnClick' runat="server"/></td> 
            </tr>
 
            <tr class="Bottom" height="15">
              <td colspan="6"></td> 
            </tr>
 
            <tr class="Controls">
              <th><strong>&nbsp;Update Submission Status</strong></th>
 
              <td>
                <p align="right">Enrolment Year&nbsp;</p>
 </td> 
              <td><asp:TextBox id="UpdateFormtxtEnrolYear2" maxlength="4" Columns="5"	runat="server"/>&nbsp;</td> 
              <td>
                <p align="right">&nbsp;Campus</p>
 </td> 
              <td>&nbsp;<em>VSV</em></td> 
              <td>&nbsp;</td> 
            </tr>
 
            <tr class="Controls">
              <th>
              <p align="right">&nbsp;</p>
 </th>
 
              <td>
                <p align="right">Semester</p>
 </td> 
              <td>1 <asp:CheckBox id="UpdateFormsemester_1" runat="server"/>2<asp:CheckBox id="UpdateFormsemester_2" runat="server"/>Both<asp:CheckBox id="UpdateFormsemester_both" runat="server"/>&nbsp;</td> 
              <td>
                <p align="right">&nbsp;Grace Period</p>
 </td> 
              <td>&nbsp;<asp:TextBox id="UpdateFormtxtGrace" maxlength="3" Columns="3"	runat="server"/></td> 
              <td>&nbsp; 
                <input id='UpdateFormButton_DoUpdate2' type="submit" class="Button" value="Run" OnServerClick='UpdateForm_Button_DoUpdate2_OnClick' runat="server"/></td> 
            </tr>
 
            <tr class="Controls">
              <th>
              <p align="right">&nbsp;Year Level</p>
 </th>
 
              <td colspan="5">
                <table border="1" cellspacing="0" cellpadding="0" width="100%" align="center">
                  <tr bgcolor="#aaaaaa">
                    <td>&nbsp;<asp:CheckBox id="UpdateFormCheckBox0" runat="server"/></td> 
                    <td>&nbsp;<asp:CheckBox id="UpdateFormCheckBox1" runat="server"/></td> 
                    <td>&nbsp;<asp:CheckBox id="UpdateFormCheckBox2" runat="server"/></td> 
                    <td>&nbsp;<asp:CheckBox id="UpdateFormCheckBox3" runat="server"/></td> 
                    <td>&nbsp;<asp:CheckBox id="UpdateFormCheckBox4" runat="server"/></td> 
                    <td>&nbsp;<asp:CheckBox id="UpdateFormCheckBox5" runat="server"/></td> 
                    <td>&nbsp;<asp:CheckBox id="UpdateFormCheckBox6" runat="server"/></td> 
                    <td>&nbsp;<asp:CheckBox id="UpdateFormCheckBox7" runat="server"/></td> 
                    <td>&nbsp;<asp:CheckBox id="UpdateFormCheckBox8" runat="server"/></td> 
                    <td>&nbsp;<asp:CheckBox id="UpdateFormCheckBox9" runat="server"/></td> 
                    <td>&nbsp;<asp:CheckBox id="UpdateFormCheckBox10" runat="server"/></td> 
                    <td>&nbsp;<asp:CheckBox id="UpdateFormCheckBox11" runat="server"/></td> 
                    <td bgcolor="#aaaaaa">&nbsp;<asp:CheckBox id="UpdateFormCheckBox12" runat="server"/></td> 
                    <td bgcolor="#ffc060"><asp:CheckBox id="UpdateFormCheckBox_All" onclick="runCheckAll();" runat="server"/></td> 
                  </tr>
 
                  <tr bgcolor="#cc0033">
                    <td>
                      <p align="center">&nbsp;0</p>
 </td> 
                    <td>
                      <p align="center">1</p>
 </td> 
                    <td>
                      <p align="center">2</p>
 </td> 
                    <td>
                      <p align="center">3</p>
 </td> 
                    <td>
                      <p align="center">4</p>
 </td> 
                    <td>
                      <p align="center">5</p>
 </td> 
                    <td>
                      <p align="center">6</p>
 </td> 
                    <td>
                      <p align="center">7</p>
 </td> 
                    <td>
                      <p align="center">8</p>
 </td> 
                    <td>
                      <p align="center">9</p>
 </td> 
                    <td>
                      <p align="center">10</p>
 </td> 
                    <td>
                      <p align="center">11</p>
 </td> 
                    <td>
                      <p align="center">12</p>
 </td> 
                    <td bgcolor="#ffc060">
                      <p align="center"><strong>ALL</strong></p>
 </td> 
                  </tr>
 
                </table>
 </td> 
            </tr>
 
            <tr class="Bottom">
              <td colspan="6" align="right">&nbsp;</td> 
            </tr>
 
          </table>
 </td> 
      </tr>
 
    </table>
 
  </div>
 
  <p>
  <script language="Javascript">
        function runCheckAll()
        {
        var thisform=document.forms[0];
        var current=thisform.UpdateFormCheckBox_All.checked;
                thisform.UpdateFormCheckBox0.checked=current;
        thisform.UpdateFormCheckBox1.checked=current;
        thisform.UpdateFormCheckBox2.checked=current;
                thisform.UpdateFormCheckBox3.checked=current;
                thisform.UpdateFormCheckBox4.checked=current;
                thisform.UpdateFormCheckBox5.checked=current;
                thisform.UpdateFormCheckBox6.checked=current;
                thisform.UpdateFormCheckBox7.checked=current;
                thisform.UpdateFormCheckBox8.checked=current;
                thisform.UpdateFormCheckBox9.checked=current;
                thisform.UpdateFormCheckBox10.checked=current;
                thisform.UpdateFormCheckBox11.checked=current;
                thisform.UpdateFormCheckBox12.checked=current;
        }
</script>


<div align="center">
  <asp:Literal id="UpdateFormlblSelections" runat="server"/> 
</div>

  </span>
  &nbsp; 
<p></p>
<p><asp:Literal id="lblModified" runat="server"/><br>
&nbsp;</p>

</form>
</body>
</html>

<!--End ASPX page-->

