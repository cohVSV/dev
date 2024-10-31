<!--ASPX page @1-AF193234-->
    <%@ Page language="vb" CodeFile="Student_Future_Intentions.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_Future_Intentions.Student_Future_IntentionsPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_Future_Intentions" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 4.1.00.032"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Enrolment Intentions</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p align="center">

	<asp:PlaceHolder id="Panel_MenuStudentMaintain" Visible="false" runat="server">
	<DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/>&nbsp;
	</asp:PlaceHolder>
	</p>
<p align="center"><a id="Link_Backtosummary" href="" class="Button" runat="server"  >Back to Summary</a>|&nbsp;&nbsp;<a id="Link_BacktoPastoralList" href="" class="Button" runat="server"  >Back to Student Support Group List</a></p>
<p align="center">

  <span id="STUDENT_FUTURE_INTENTIONSHolder" runat="server">
    


    <table cellspacing="0" cellpadding="0" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Add/Edit STUDENT FUTURE INTENTIONS </th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="STUDENT_FUTURE_INTENTIONSError" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="2"><asp:Label ID="STUDENT_FUTURE_INTENTIONSErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Controls">
                        <th><strong>STUDENT ID</strong></th>
 
                        <td><asp:Literal id="STUDENT_FUTURE_INTENTIONSSTUDENT_ID" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>ENROLMENT YEAR</strong></th>
 
                        <td><asp:Literal id="STUDENT_FUTURE_INTENTIONSENROLMENT_YEAR" runat="server"/>&nbsp;<em>(questions relate to next year)</em></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>Will you be seeking re-enrolment at the VSV <u>next year</u>?</strong></th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_FUTURE_INTENTIONSRE_ENROLMENT_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>Will you be enrolling in another school/institution <u>next year</u>?</strong></th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_FUTURE_INTENTIONSNEW_SCHOOL_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>
                        <p align="right"><em>If Yes, what School or Institution?</em></p>
                        </th>
 
                        <td><asp:TextBox id="STUDENT_FUTURE_INTENTIONSSCHOOL_NAME" maxlength="200" Columns="50"	runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>Will you be leaving schooling altogether <u>next year</u>?</strong></th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_FUTURE_INTENTIONSLEAVING_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>Will you be seeking full time work?</strong></th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_FUTURE_INTENTIONSSEEKING_WORK_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>Will you be engaged in full employment <u>next year</u>?</strong></th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_FUTURE_INTENTIONSEMPLOYMENT_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>
                        <p align="right"><em>If Yes, what Employer or Company (or type 'Unknown')?</em></p>
                        </th>
 
                        <td><asp:TextBox id="STUDENT_FUTURE_INTENTIONSEMPLOYER_DETAIL" maxlength="200" Columns="50"	runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>LAST ALTERED BY / LAST ALTERED DATE </th>
 
                        <td>&nbsp;<asp:Literal id="STUDENT_FUTURE_INTENTIONSLAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_FUTURE_INTENTIONSLAST_ALTERED_DATE" runat="server"/></td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="2" align="right">
                            <input id='STUDENT_FUTURE_INTENTIONSButton_Insert' type="submit" class="Button" value="Add" OnServerClick='STUDENT_FUTURE_INTENTIONS_Insert' runat="server"/>
                            <input id='STUDENT_FUTURE_INTENTIONSButton_Update' type="submit" class="Button" value="Update" OnServerClick='STUDENT_FUTURE_INTENTIONS_Update' runat="server"/>&nbsp; 
                            <input id='STUDENT_FUTURE_INTENTIONSButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_FUTURE_INTENTIONS_Cancel' runat="server"/></td>
                    </tr>
                </table>
                
  <input id="STUDENT_FUTURE_INTENTIONSHidden_lastalteredby" type="hidden"  runat="server"/>
  
  <input id="STUDENT_FUTURE_INTENTIONSHidden_lastaltered_date" type="hidden"  runat="server"/>
  
  <input id="STUDENT_FUTURE_INTENTIONSHidden_student_id" type="hidden"  runat="server"/>
  
  <input id="STUDENT_FUTURE_INTENTIONSHidden_enrolmentyear" type="hidden"  runat="server"/>
  </td>
        </tr>
    </table>



  </span>
  </p>
<p align="center"><br>
</p>

</form>
</body>
</html>

<!--End ASPX page-->

