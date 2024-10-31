<!--ASPX page @1-3D1174AB-->
    <%@ Page language="vb" CodeFile="Despatch_UpdatebyEnrolDate.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Despatch_UpdatebyEnrolDate.Despatch_UpdatebyEnrolDatePage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Despatch_UpdatebyEnrolDate" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Despatch Update by Year</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p>&nbsp;</p>
<p>

  <span id="UpdateFormHolder" runat="server">
    


  <div align="center">
    <table cellspacing="0" cellpadding="0" align="center" border="0">
      <tr>
        <td valign="top">
          <table class="Header" cellspacing="0" cellpadding="0" border="0">
            <tr>
              <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
              <th>Despatch Run Update By Enrolment Date Range</th>
 
              <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
            </tr>
          </table>
 
          <table class="Record" cellspacing="0" cellpadding="0">
            
  <asp:PlaceHolder id="UpdateFormError" visible="False" runat="server">
  
            <tr class="Error">
              <td colspan="4"><asp:Label ID="UpdateFormErrorLabel" runat="server"/></td>
            </tr>
            
  </asp:PlaceHolder>
  
            <tr class="Controls">
              <th>
              <p align="right">Despatch Dates for students enrolled between:</p>
              </th>
 
              <td><asp:TextBox id="UpdateFormstudentdatefrom" maxlength="10" Columns="10"	runat="server"/>&nbsp;</td> 
              <td>
                <p align="center">&nbsp;to</p>
              </td> 
              <td>&nbsp;<asp:TextBox id="UpdateFormstudentdateto" maxlength="10" Columns="10"	runat="server"/></td>
            </tr>
 
            <tr class="Controls">
              <th>
              <p align="right">&nbsp;Semester</p>
              </th>
 
              <td>1 <asp:CheckBox id="UpdateFormsemester_1" runat="server"/>2<asp:CheckBox id="UpdateFormsemester_2" runat="server"/>Both<asp:CheckBox id="UpdateFormsemester_both" runat="server"/>&nbsp;</td> 
              <td>&nbsp;Despatch Date</td> 
              <td>&nbsp;<asp:TextBox id="UpdateFormdespatchdate" maxlength="10" Columns="10"	runat="server"/></td>
            </tr>
 
            <tr class="Controls">
              <th>
              <p align="right">Campus</p>
              </th>
 
              <td><em>VSV</em></td> 
              <td>
                <p align="right">&nbsp; Book Range</p>
              </td> 
              <td>&nbsp;<asp:TextBox id="UpdateFormbook_range_from" maxlength="2" Columns="2"	runat="server"/>&nbsp;to <asp:TextBox id="UpdateFormbook_range_to" maxlength="2" Columns="2"	runat="server"/></td>
            </tr>
 
            <tr class="Controls">
              <th>
              <p align="right">&nbsp;Year Level</p>
              </th>
 
              <td colspan="3">
                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="1">
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
                  </tr>
 
                  <tr>
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
                  </tr>
                </table>
              </td>
            </tr>
 
            <tr class="Bottom">
              <td align="right" colspan="4">
                <input id='UpdateFormButton_DoUpdate' class="Button" type="submit" value="Update" OnServerClick='UpdateForm_Button_DoUpdate_OnClick' runat="server"/></td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  </div>
  <p>


<div align="center">
  <asp:Literal id="UpdateFormlblSelections" runat="server"/> 
</div>

  </span>
  &nbsp; 
<p></p>
<p><br>
&nbsp;</p>

</form>
</body>
</html>

<!--End ASPX page-->

