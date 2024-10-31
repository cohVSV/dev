<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Despatch_AssignmentReturn_simple.aspx.vb" Inherits="Despatch_AssignmentReturn_simple" %>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header_prod" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head id="Head1" runat="server">
	<meta http-equiv="content-type" content="text/html; charset=windows-1252">
    <title>Despatch - Assignment Return - Simple</title>
    <link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
function OpenPopUpList()
{
        // default popup - using no initial params and single field return
        var FieldName;
        FieldName = "AssignmentReturnstudentid";
        var win=window.open("popup_StudentSearch.aspx?returncontrol="+FieldName, "StudentSearch", "left=40,top=10,width=500,height=480,status=no,toolbar=no,menubar=no,location=no,scrollbars=yes");
        win.focus();
}

function OpenPopUpList_SubjectSearch()
{
        var retFieldName;
        retFieldName = "AssignmentReturnsubjectid";
        var tmpSearchField;
        tmpSearchField = document.getElementById('AssignmentReturnstudentid').value
        var win=window.open("popup_StudentSubjectSearch.aspx?returncontrol="+retFieldName+"&p_STUDENTID="+tmpSearchField, "SubjectSearch", "left=40,top=10,width=500,height=480,status=no,toolbar=no,menubar=no,location=no,scrollbars=yes");
        win.focus();
}

</script>

</head>
<body>
    <form  runat="server" id="Form1">
 
<p><DECV_PROD2007:Header_prod id="Header" runat="server"/></p>
<p/>

  <div id="AssignmentReturnHolder" runat="server">
    
  <table cellspacing="0" cellpadding="0" width="50%" align="center" border="0">
    <tr>
      <td valign="top" style="height: 224px; text-align: center">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Assignment Returns</th>
 
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
                <asp:TextBox ID="AssignmentReturnStaffID" runat="server" onfocus="this.select();" tabindex="1" Columns="16"	></asp:TextBox>
                </td> 
            <td>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">Student ID</p></th>
 
            <td><asp:TextBox id="AssignmentReturnstudentid" style="BACKGROUND-COLOR: #cccccc; TEXT-ALIGN: right" onfocus="this.select();" tabindex="2" Columns="16"	runat="server" /></td> 
            <td><a id="AssignmentReturnlink_popupStudentSearch" href="" class="Button" onclick="OpenPopUpList();" runat="server"  >Student Search</a>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">Subject Id + Assignment ID</p>
 </th>
 
            <td><asp:TextBox id="AssignmentReturnsubjectid" style="BACKGROUND-COLOR: #cccccc" onfocus="this.select();" tabindex="3" maxlength="8" Columns="12"	runat="server" AutoPostBack="True"/>&nbsp;</td> 
            <td><a id="AssignmentReturnlink_popupStudentSubjectSearch" href="" class="Button" onclick="OpenPopUpList_SubjectSearch();" runat="server"  >Subject Search</a></td> 
          </tr>
            <tr class="Controls">
                <th style="text-align: right">
                    Marker ID</th>
                <td><asp:TextBox ID="AssignmentReturnMarkerID" runat="server" Columns="16" style="BACKGROUND-COLOR: #cccccc" onfocus="this.select();" TabIndex="4" MaxLength=8></asp:TextBox></td>
                <td>&nbsp;</td> 
            </tr>
 
           <tr class="Controls">
            <th>
            <p align="right">Receipt Date</p> </th>
            <td><asp:Literal id="AssignmentReturnreceiptdate" runat="server"/></td> 
            <td>&nbsp;</td>
          </tr>
          
          <tr class="Controls">
            <th>
            <p align="right">Insert Return if not Receipted?</p> </th>
            <td><asp:CheckBox ID="hidden_AddNewReturn_flag" runat="server"/></td> 
            <td>&nbsp;</td> 
          </tr>

 
          <tr class="Bottom">
            <td align="right" colspan="3"><a href="Despatch_AssignmentReturn_simple.aspx" title="clear">clear</a>&nbsp;&nbsp;&nbsp;
                <asp:Button ID="AssignmentReturnButton_Insert" cssclass="Button" TabIndex="5" runat="server" Text="Do Return" />
              </td> 
          </tr>
           
        </table>
          <asp:Literal ID="ltlMessage" runat="server"></asp:Literal></td> 
    </tr>
 
  </table>
    </div>
        &nbsp;
    </form>
</body>
</html>
