<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Despatch_AssignmentReceipt_simple.aspx.vb" Inherits="Despatch_AssignmentReceipt_simple" %>

	<%@ Import namespace="DECV_PROD2007.Despatch_AssignmentReceipt_simple" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>

    <%@Register TagPrefix="DECV_PROD2007" TagName="Header_prod" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>

<html>
<head runat="server">
<meta http-equiv="content-type" content="text/html; charset=windows-1252">
    <title>Despatch - Assignment Receipt - Simple</title>
    <link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
function OpenPopUpList()
{
        // default popup - using no initial params and single field return
        var FieldName;
        FieldName = "AssignmentReceiptstudentid";
        var win=window.open("popup_StudentSearch.aspx?returncontrol="+FieldName, "StudentSearch", "left=40,top=10,width=500,height=480,status=no,toolbar=no,menubar=no,location=no,scrollbars=yes");
        win.focus();
}

function OpenPopUpList_SubjectSearch()
{
        var retFieldName;
        retFieldName = "AssignmentReceiptsubjectid";
        var tmpSearchField;
        tmpSearchField = document.getElementById('AssignmentReceiptstudentid').value
        var win=window.open("popup_StudentSubjectSearch.aspx?returncontrol="+retFieldName+"&p_STUDENTID="+tmpSearchField, "SubjectSearch", "left=40,top=10,width=500,height=480,status=no,toolbar=no,menubar=no,location=no,scrollbars=yes");
        win.focus();
}

// set up Audio for F-6 error unfuddle #810
var audio = new Audio('images/man-scream-01.mp3');
function showAlert() {alert(msgalert)}
audio.addEventListener('ended', showAlert);

</script>

</head>
<body>
    <form  runat="server" id="Form1">
 
<p><DECV_PROD2007:Header_prod id="Header" runat="server"/></p>
<p/>

  <div id="AssignmentReceiptHolder" runat="server">
    
  <table cellspacing="0" cellpadding="0" width="50%" align="center" border="0">
    <tr>
      <td valign="top" style="height: 224px; text-align: center">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Assignment Receipts</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
          </tr>
 
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
           <tr class="Error">
            <td colspan="3"> 
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </td> 
          </tr>
  
          <tr class="Controls">
            <th>
            <p align="right">Staff ID</p></th>
 
            <td>
               <asp:TextBox ID="AssignmentReceiptStaffID" runat="server" onfocus="this.select();" tabindex="1" Columns="16"	></asp:TextBox></td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">Student ID</p></th>
 
            <td><asp:TextBox id="AssignmentReceiptstudentid" style="BACKGROUND-COLOR: #cccccc; TEXT-ALIGN: right" onfocus="this.select();" tabindex="2" Columns="16"	runat="server" /></td> 
            <td><a id="AssignmentReceiptlink_popupStudentSearch" href="" class="Button" onclick="OpenPopUpList();" runat="server"  >Student Search</a>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">Subject Id + Assignment ID</p>
 </th>
 
            <td><asp:TextBox id="AssignmentReceiptsubjectid" style="BACKGROUND-COLOR: #cccccc" onfocus="this.select();" tabindex="3" maxlength="8" Columns="12"	runat="server" AutoPostBack="True"/>&nbsp;</td> 
            <td><a id="AssignmentReceiptlink_popupStudentSubjectSearch" href="" class="Button" onclick="OpenPopUpList_SubjectSearch();" runat="server"  >Subject Search</a></td> 
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">Receipt Date</p>
 </th>
 
            <td><asp:Literal id="AssignmentReceiptreceiptdate" runat="server"/></td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="3"><a href="Despatch_AssignmentReceipt_simple.aspx" title="clear">clear</a>&nbsp;&nbsp;&nbsp;
                <asp:Button ID="AssignmentReceiptButton_Insert" class="Button" TabIndex="5" runat="server" Text="Add Receipt" />
              </td> 
          </tr>
           
        </table>
          <asp:Literal ID="ltlMessage" runat="server"></asp:Literal></td> 
    </tr>
 
  </table>
    </div>
        
    </form>
</body>
</html>
