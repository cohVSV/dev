<!--ASPX page @1-A57B0271-->
    <%@ Page language="vb" CodeFile="Despatch_AssignmentReceipt.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Despatch_AssignmentReceipt.Despatch_AssignmentReceiptPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Despatch_AssignmentReceipt" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Despatch - Assignment Receipt</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
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
function disableEnterKey(e)
{
     var key;
     if(window.event) {
          key = window.event.keyCode; //IE
         }
     else {
          key = e.which; //firefox     
         }
     return (key != 13);
}

</script>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p>

  <span id="AssignmentReceiptHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" width="50%" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Assignment Receipts</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="AssignmentReceiptError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="3"><asp:Label ID="AssignmentReceiptErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>
            <p align="right">Staff ID</p>
            </th>
 
            <td>
              <select id="AssignmentReceiptStaffID" tabindex="1"  runat="server"></select>
 </td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">Student ID</p>
            </th>
 
            <td><asp:TextBox id="AssignmentReceiptstudentid" style="BACKGROUND-COLOR: #cccccc; TEXT-ALIGN: right" onfocus="this.select();" tabindex="2" Columns="16"	runat="server"/></td> 
            <td><a id="AssignmentReceiptlink_popupStudentSearch" href="" class="Button" onclick="OpenPopUpList();" runat="server"  >Student Search</a>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">Subject Id + Assignment ID</p>
            </th>
 
            <td><asp:TextBox id="AssignmentReceiptsubjectid" style="BACKGROUND-COLOR: #cccccc" onfocus="this.select();" tabindex="3" maxlength="8" Columns="12"	runat="server"/>&nbsp;</td> 
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
            <td align="right" colspan="3"><a id="AssignmentReceiptLink1" href="" runat="server"  >Clear</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
              <input id='AssignmentReceiptButton_Insert' class="Button" tabindex="5" type="submit" value="Add Receipt" OnServerClick='AssignmentReceipt_Insert' runat="server"/></td>
          </tr>
        </table>
        
  <input id="AssignmentReceiptENrolmentYear" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>



  </span>
  </p>

</form>
</body>
</html>

<!--End ASPX page-->

