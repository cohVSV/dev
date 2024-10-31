<!--ASPX page @1-FAA61875-->
    <%@ Page language="vb" CodeFile="Student_Equipment_maintain.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_Equipment_maintain.Student_Equipment_maintainPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_Equipment_maintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Equipment Maintain</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/></p>
<p>

  <span id="STUDENT_EQUIPMENTHolder" runat="server">
    


    <table cellspacing="0" cellpadding="0" width="70%" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Edit Student Equipment </th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="STUDENT_EQUIPMENTError" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="2"><asp:Label ID="STUDENT_EQUIPMENTErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Controls">
                        <th><strong>&nbsp;STUDENT ID</strong></th>
 
                        <td><asp:Literal id="STUDENT_EQUIPMENTlblStudentNo" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;Permission for teachers to access Student WORK EXAMPLES</th>
 
                        <td>
                            <p>
                            <asp:RadioButtonList id="STUDENT_EQUIPMENTACCESS_WORKEXAMPLES_radio"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;&nbsp;<em>(added 2009, modified June 2010)</em></p>
                        </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;Receive&nbsp;VSV Newsletter by POST ONLY:</th>
 
                        <td><asp:CheckBox id="STUDENT_EQUIPMENTNEWSLETTER_BYMAIL" runat="server"/>&nbsp;&nbsp;<em>(added 2009)</em></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;Student&nbsp;has Access to a COMPUTER:</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_EQUIPMENTACCESS_COMPUTER"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;<br>
                            <em>(new for 2010)</em>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;Student&nbsp;has Access to the INTERNET:</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_EQUIPMENTACCESS_INTERNET"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;<br>
                            <em>(new for 2010)</em></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;Student has Digital Education Revolution PC:</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_EQUIPMENTHAS_DER_PC"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;&nbsp;<br>
                            <em>(added 2009)</em>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th><em><strong>&nbsp;No longer Used for 2010 Enrolments</strong></em></th>
 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;Student&nbsp;has Access to their OWN&nbsp;COMPUTER:</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_EQUIPMENTHAS_COMPUTER"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;Student has Shared Access to a COMPUTER:</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_EQUIPMENTSHARES_COMPUTER"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;&nbsp;<em>(added 2009)</em>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;Student has&nbsp;ACCESS to the Internet:</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_EQUIPMENTHAS_INTERNET_ACCESS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;Student has&nbsp;LIMITED access to the Internet:</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_EQUIPMENTLIMITED_INTERNET_ACCESS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;<em>(added 2009)</em>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;Student has Access to CABLE BROADBAND or better:</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_EQUIPMENTHAS_BROADBAND"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;&nbsp;<em>(added 2009)</em>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;Student Owns a&nbsp;DVD Player:</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_EQUIPMENTHAS_DVD"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;&nbsp;<em>(unused&nbsp;after 2008)</em>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;Student Owns a&nbsp;VCR:</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_EQUIPMENTHAS_VCR"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;&nbsp;<em>(unused&nbsp;after 2008)</em>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>LAST ALTERED BY / DATE</th>
 
                        <td><asp:Literal id="STUDENT_EQUIPMENTLAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_EQUIPMENTLAST_ALTERED_DATE" runat="server"/></td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="2" align="right">
                            <input id='STUDENT_EQUIPMENTButton_Update' type="submit" class="Button" value="Update" OnServerClick='STUDENT_EQUIPMENT_Update' runat="server"/>
                            <input id='STUDENT_EQUIPMENTButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_EQUIPMENT_Cancel' runat="server"/></td>
                    </tr>
                </table>
                
  <input id="STUDENT_EQUIPMENTHidden_lastalteredby" type="hidden"  runat="server"/>
  
  <input id="STUDENT_EQUIPMENTHidden_lastaltereddate" type="hidden"  runat="server"/>
  </td>
        </tr>
    </table>



  </span>
  <br>
</p>

</form>
</body>
</html>

<!--End ASPX page-->

