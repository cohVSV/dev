<!--ASPX page @1-A26CC727-->
    <%@ Page language="vb" CodeFile="FinancialAccounts_comments_maintain.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.FinancialAccounts_comments_maintain.FinancialAccounts_comments_maintainPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.FinancialAccounts_comments_maintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Financial Accounts Comments maintain</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p align="center"><a id="Link_Back" href="" class="Button" runat="server"  >Back to Financials</a></p>
<h1>Financial Accounts - VSV</h1>
<p>

  <span id="txnHolder" runat="server">
    


    
  <input id="txnTXN_ID" type="hidden"  runat="server"/>
  
    <table cellspacing="0" cellpadding="0" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Modify Comments/Receipt #</th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="txnError" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="4"><asp:Label ID="txnErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Controls">
                        <th><strong>STUDENT ID</strong></th>
 
                        <td><asp:Literal id="txnSTUDENT_ID" runat="server"/></td> 
                        <td><strong>ENROLMENT YEAR</strong>&nbsp;</td> 
                        <td><asp:Literal id="txnENROLMENT_YEAR" runat="server"/>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>TRANSACTION DATE</strong></th>
 
                        <td><strong>TRANSACTION CODE</strong></td> 
                        <td><strong>AMOUNT</strong></td> 
                        <td><strong>DR/CR</strong></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>
                        <div align="center">
                            <asp:Literal id="txnTRANS_DATE" runat="server"/> 
                        </div>
                        </th>
 
                        <td><asp:Literal id="txnTRANS_CODE" runat="server"/></td> 
                        <td><asp:Literal id="txnAMOUNT" runat="server"/></td> 
                        <td><asp:Literal id="txnCR_DR_FLAG" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Controls">
                        <th><strong>COMMENT</strong><br>
                        <em>(max. 60 chars)</em></th>
 
                        <td>
<asp:TextBox id="txnCOMMENTS" Columns="30" TextMode="MultiLine"	runat="server"/>
</td> 
                        <td>&nbsp;<strong>RECEIPT #</strong></td> 
                        <td><asp:TextBox id="txnRECEIPT_NO" maxlength="10" Columns="10"	runat="server"/></td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="4" align="right">
                            <input id='txnButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='txn_Cancel' runat="server"/>&nbsp;&nbsp;&nbsp; 
                            <input id='txnButton_Update' type="submit" class="Button" value="Update" OnServerClick='txn_Update' runat="server"/></td>
                    </tr>
                </table>
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

