<!--ASPX page @1-97119DCD-->
    <%@ Page language="vb" CodeFile="REGION_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.REGION_maint.REGION_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.REGION_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>REGION</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/> </p>
<p><a id="Link1" href="" runat="server"  >back to list</a></p>

  <span id="REGIONHolder" runat="server">
    


  <table border="0" cellspacing="0" cellpadding="0" align="center">
    <tr>
      <td valign="top">
        <table class="Header" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Add/Edit REGION </th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
          </tr>
 
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="REGIONError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="REGIONErrorLabel" runat="server"/></td> 
          </tr>
 
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>'Parent' Region&nbsp;<font color="red">*</font></th>
 
            <td>
              <select id="REGIONPARENT_REGION_ID"  runat="server"></select>
 </td> 
          </tr>
 
          <tr class="Controls">
            <th colspan="2"><em>'Parent' Region&nbsp;is the New Region that this region is part of, for reporting mainly)</em></th>
 
          </tr>
 
          <tr class="Controls">
            <th>Region ID&nbsp;<font color="red">*</font></th>
 
            <td>&nbsp;<asp:TextBox id="REGIONREGION_ID" maxlength="2" Columns="4"	runat="server"/><asp:Literal id="REGIONlblREGION_ID" runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>NAME&nbsp;<font color="red">*</font></th>
 
            <td><asp:TextBox id="REGIONREGION_NAME" maxlength="40" Columns="40"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>PHONE&nbsp;<font color="red">*</font></th>
 
            <td><asp:TextBox id="REGIONPHONE" maxlength="15" Columns="15"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>FAX</th>
 
            <td><asp:TextBox id="REGIONFAX" maxlength="15" Columns="15"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>EMAIL ADDRESS</th>
 
            <td><asp:TextBox id="REGIONEMAIL_ADDRESS" maxlength="50" Columns="50"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>ADDRESS 1&nbsp;<font color="red">*</font></th>
 
            <td><asp:TextBox id="REGIONADDR1" maxlength="50" Columns="50"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>ADDRESS 2</th>
 
            <td><asp:TextBox id="REGIONADDR2" maxlength="50" Columns="50"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>SUBURB / TOWN&nbsp;<font color="red">*</font></th>
 
            <td><asp:TextBox id="REGIONSUBURB_TOWN" maxlength="30" Columns="30"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>POSTCODE</th>
 
            <td><asp:TextBox id="REGIONPOSTCODE" maxlength="10" Columns="10"	runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>STATUS&nbsp;</th>
 
            <td>
              <asp:RadioButtonList id="REGIONRadioButtonStatus"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY / DATE</th>
 
            <td><asp:Literal id="REGIONlabel_Last_altered_by" runat="server"/>&nbsp;/ <asp:Literal id="REGIONlabel_last_altered_date" runat="server"/>&nbsp;
  <input id="REGIONLAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="REGIONLAST_ALTERED_DATE" type="hidden"  runat="server"/>
  </td> 
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">
              <input id='REGIONButton_Insert' type="submit" class="Button" value="Add" OnServerClick='REGION_Insert' runat="server"/>
              <input id='REGIONButton_Update' type="submit" class="Button" value="Save" OnServerClick='REGION_Update' runat="server"/>
              <input id='REGIONButton_Delete' type="submit" class="Button" value="Delete" OnServerClick='REGION_Delete' runat="server"/></td> 
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

