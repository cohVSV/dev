<!--ASPX page @1-35EA7787-->
    <%@ Page language="vb" CodeFile="FileUpload.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.FileUpload.FileUploadPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.FileUpload" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>FileUpload</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">



  <span id="UploadRecordHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>File Upload</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="UploadRecordError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="UploadRecordErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>File Upload</th>
 
            <td>
              
  <CC:FileUploadControl id="UploadRecordFileUpload1" DeleteCaption='Delete' runat="server"/>
  </td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='UploadRecordButton_Insert' class="Button" type="submit" value="Add" OnServerClick='UploadRecord_Insert' runat="server"/>
              <input id='UploadRecordButton_Update' class="Button" type="submit" value="Submit" OnServerClick='UploadRecord_Update' runat="server"/>
              <input id='UploadRecordButton_Delete' class="Button" type="submit" value="Delete" OnServerClick='UploadRecord_Delete' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  
<p><strong>Filename:</strong> <asp:Literal id="lblFilename" runat="server"/>&nbsp; </p>

<asp:repeater id="DataGrid1Repeater" OnItemCommand="DataGrid1ItemCommand" OnItemDataBound="DataGrid1ItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
          <th>DataGrid1</th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Row">
          <td colspan="2">Total Records:&nbsp;<asp:Literal id="DataGrid1DataGrid1_TotalRecords" runat="server"/></td>
        </tr>
 
        <tr class="Caption">
          <th>Label1</th>
 
          <th>Label2</th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td><asp:Literal id="DataGrid1Label1" runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="DataGrid1Label2" runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="2">No Enrolment Details found</td>
        </tr>
        
  </asp:PlaceHolder>

      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>


</form>
</body>
</html>

<!--End ASPX page-->

