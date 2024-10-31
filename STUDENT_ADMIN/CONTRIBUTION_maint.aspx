<!--ASPX page @1-79AFFA7F-->
    <%@ Page language="vb" CodeFile="CONTRIBUTION_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.CONTRIBUTION_maint.CONTRIBUTION_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.CONTRIBUTION_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.1.1.0" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>CONTRIBUTION</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/> </p>
<p><a id="Link1" href="" runat="server"  >back to list</a></p>

  <span id="CONTRIBUTIONHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Add/Edit CONTRIBUTION </th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="CONTRIBUTIONError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="CONTRIBUTIONErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>CATEGORY&nbsp;CODE</th>
 
            <td><asp:TextBox id="CONTRIBUTIONCATEGORY"	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>SCHOOL TYPE CODE</th>
 
            <td>
              <select id="CONTRIBUTIONSCHOOL_TYPE_CODE"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th>CAMPUS CODE</th>
 
            <td>
              <asp:RadioButtonList id="CONTRIBUTIONCAMPUS_CODE"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>FROM YEAR LEVEL</th>
 
            <td><asp:TextBox id="CONTRIBUTIONFROM_YEAR_LEVEL" maxlength="5" Columns="5"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>TO YEAR LEVEL</th>
 
            <td><asp:TextBox id="CONTRIBUTIONTO_YEAR_LEVEL" maxlength="5" Columns="5"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>PER SUBJECT FLAG</th>
 
            <td><asp:CheckBox id="CONTRIBUTIONPER_SUBJECT_FLAG" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>DEFAULT CONTRIBUTION</th>
 
            <td><asp:TextBox id="CONTRIBUTIONDEFAULT_CONTRIBUTION" maxlength="15" Columns="15"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>DISCOUNT AMOUNT</th>
 
            <td><asp:TextBox id="CONTRIBUTIONDISCOUNT_AMOUNT" maxlength="15" Columns="15"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY</th>
 
            <td><asp:TextBox id="CONTRIBUTIONLAST_ALTERED_BY" maxlength="8" Columns="8"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED DATE</th>
 
            <td><asp:TextBox id="CONTRIBUTIONLAST_ALTERED_DATE" maxlength="100" Columns="10"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='CONTRIBUTIONButton_Insert' class="Button" type="submit" value="Add" OnServerClick='CONTRIBUTION_Insert' runat="server"/>
              <input id='CONTRIBUTIONButton_Update' class="Button" type="submit" value="Submit" OnServerClick='CONTRIBUTION_Update' runat="server"/>
              <input id='CONTRIBUTIONButton_Delete' class="Button" type="submit" value="Delete" OnServerClick='CONTRIBUTION_Delete' runat="server"/>
              <input id='CONTRIBUTIONButtoncancel' class="Button" type="submit" value="Cancel" OnServerClick='CONTRIBUTION_Cancel' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>
<DECV_PROD2007:Footer id="Footer" runat="server"/> 

</form>
</body>
</html>

<!--End ASPX page-->

