<!--ASPX page @1-0641B415-->
    <%@ Page language="vb" CodeFile="ENROLMENT_CATEG_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.ENROLMENT_CATEG_maint.ENROLMENT_CATEG_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.ENROLMENT_CATEG_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0"><meta content="text/html; charset=windows-1252" http-equiv="content-type">

<title>ENROLMENT CATEGORY</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/> </p>
<p><a id="Link1" href="" class="Button" runat="server"  >back to Category List</a></p>

  <span id="ENROLMENT_CATEGORYHolder" runat="server">
    


  <table border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td valign="top">
        <table class="Header" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Add/Edit ENROLMENT CATEGORY </th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="ENROLMENT_CATEGORYError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="ENROLMENT_CATEGORYErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>CATEGORY CODE</th>
 
            <td><asp:TextBox id="ENROLMENT_CATEGORYCATEGORY_CODE" maxlength="10" Columns="10"	runat="server"/><em>&nbsp;(max. 10 characters, UPPER CASE)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>SUB CATEGORY&nbsp;CODE</th>
 
            <td><asp:TextBox id="ENROLMENT_CATEGORYSUBCATEGORY_CODE" maxlength="10" Columns="10"	runat="server"/><em>&nbsp;(max. 10 characters, UPPER CASE)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>SUBCATEGORY FULL TITLE</th>
 
            <td><asp:TextBox id="ENROLMENT_CATEGORYSUBCATEGORY_FULL_TITLE" maxlength="50" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>STATUS</th>
 
            <td><asp:CheckBox id="ENROLMENT_CATEGORYSTATUS" runat="server"/>&nbsp;<em>(Tick if Active)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY</th>
 
            <td><asp:Literal id="ENROLMENT_CATEGORYlblLAST_ALTERED_BY" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED DATE</th>
 
            <td><asp:Literal id="ENROLMENT_CATEGORYlblLAST_ALTERED_DATE" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">
              <input id='ENROLMENT_CATEGORYButton_Insert' class="Button" value="Add" type="submit" OnServerClick='ENROLMENT_CATEGORY_Insert' runat="server"/>
              <input id='ENROLMENT_CATEGORYButton_Update' class="Button" value="Update" type="submit" OnServerClick='ENROLMENT_CATEGORY_Update' runat="server"/>
              <input id='ENROLMENT_CATEGORYButton_Delete' class="Button" value="Delete" type="submit" OnServerClick='ENROLMENT_CATEGORY_Delete' runat="server"/>&nbsp; 
              <input id='ENROLMENT_CATEGORYButton_Cancel' class="Button" value="Cancel" type="submit" OnServerClick='ENROLMENT_CATEGORY_Cancel' runat="server"/></td>
          </tr>
        </table>
        
  <input id="ENROLMENT_CATEGORYLAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="ENROLMENT_CATEGORYLAST_ALTERED_DATE" type="hidden"  runat="server"/>
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

