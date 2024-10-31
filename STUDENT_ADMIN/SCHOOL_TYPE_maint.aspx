<!--ASPX page @1-8CDD3B4E-->
    <%@ Page language="vb" CodeFile="SCHOOL_TYPE_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.SCHOOL_TYPE_maint.SCHOOL_TYPE_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.SCHOOL_TYPE_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.1.1.0" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>SCHOOL TYPE</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/> </p>
<p><a id="Link1" href="" class="Button" runat="server"  >Back to School Type List</a></p>

  <span id="SCHOOL_TYPEHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Add/Edit SCHOOL TYPE </th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="SCHOOL_TYPEError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="SCHOOL_TYPEErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>TYPE CODE&nbsp;</th>
 
            <td><asp:TextBox id="SCHOOL_TYPESCHOOL_TYPE_CODE" maxlength="1" Columns="2"	runat="server"/><asp:Literal id="SCHOOL_TYPElbl_SchoolTypeCode" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>DESCRIPTION</th>
 
            <td><asp:TextBox id="SCHOOL_TYPESCHOOL_TYPE_DESCRIPTION" maxlength="10" Columns="10"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY</th>
 
            <td><asp:Literal id="SCHOOL_TYPElbl_LAST_ALTERED_BY" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED DATE</th>
 
            <td><asp:Literal id="SCHOOL_TYPElbl_LAST_ALTERED_DATE" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='SCHOOL_TYPEButton_Insert' class="Button" type="submit" value="Add" OnServerClick='SCHOOL_TYPE_Insert' runat="server"/>
              <input id='SCHOOL_TYPEButton_Update' class="Button" type="submit" value="Submit" OnServerClick='SCHOOL_TYPE_Update' runat="server"/>
              <input id='SCHOOL_TYPEButton_Delete' class="Button" type="submit" value="Delete" OnServerClick='SCHOOL_TYPE_Delete' runat="server"/>&nbsp; 
              <input id='SCHOOL_TYPEButton_Cancel' class="Button" type="submit" value="Cancel" OnServerClick='SCHOOL_TYPE_Cancel' runat="server"/></td>
          </tr>
        </table>
        
  <input id="SCHOOL_TYPELAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="SCHOOL_TYPELAST_ALTERED_DATE" type="hidden"  runat="server"/>
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

