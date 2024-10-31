<!--ASPX page @1-AB1078B1-->
    <%@ Page language="vb" CodeFile="StudentEnrolment_AddTXN.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.StudentEnrolment_AddTXN.StudentEnrolment_AddTXNPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.StudentEnrolment_AddTXN" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>StudentEnrolment_AddTXN</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p align="center"><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p align="center">&nbsp;

<asp:repeater id="Grid_TransactionsRepeater" OnItemCommand="Grid_TransactionsItemCommand" OnItemDataBound="Grid_TransactionsItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" width="70%" align="center" border="0">
  <tr>
    <td valign="top">
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>
          <p align="center">Transaction Date</p>
          </th>
 
          <div align="center">
          </div>
 
          <th>
          <p align="center">Transaction Code</p>
          </th>
 
          <div align="center">
            <div>
            </div>
 
            <div align="center">
            </div>
          </div>
 
          <div align="center">
          </div>
 
          <th>
          <p align="center">Amount</p>
          </th>
 
          <div>
          </div>
 
          <div align="center">
            <div>
            </div>
 
            <div align="center">
            </div>
          </div>
 
          <div align="center">
          </div>
 
          <th>
          <p align="center">DR/CR</p>
          </th>
 
          <div>
          </div>
 
          <div align="center">
            <div>
            </div>
 
            <div align="center">
            </div>
          </div>
 
          <th>
          <p align="center">Comments</p>
          </th>
 
          <div>
          </div>
 
          <th>
          <p align="center">Receipt #</p>
          </th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr  <CC:AttributeBinder runat="server" Name="rowStyle" ContainerId="Grid_TransactionsRepeater"/>>
          <td>
            <div align="center">
<asp:Literal id="Grid_Transactionslink_TRANS_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_TransactionsItem)).link_TRANS_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/> 
            </div>
          </td> 
          <td>
            <div align="right">
              
  <input id="Grid_TransactionsTXN_ID"  value='<%# (CType(Container.DataItem,Grid_TransactionsItem)).TXN_ID.GetFormattedValue() %>' type="hidden" size="8"  runat="server"/>
  <asp:Literal id="Grid_TransactionsTRANS_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_TransactionsItem)).TRANS_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/> 
            </div>
          </td> 
          <td style="TEXT-ALIGN: right">
            <div align="right">
              <asp:Literal id="Grid_TransactionsAMOUNT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_TransactionsItem)).AMOUNT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;&nbsp; 
            </div>
          </td> 
          <td>
            <div align="center">
              <asp:Literal id="Grid_TransactionsCR_DR_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_TransactionsItem)).CR_DR_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/> 
            </div>
          </td> 
          <td><asp:Literal id="Grid_TransactionsCOMMENTS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_TransactionsItem)).COMMENTS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="Grid_TransactionsRECEIPT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_TransactionsItem)).RECEIPT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        <tr class="Bottom">
          <td align="right" colspan="2">
            <p align="right"><strong>Account Balance:</strong></p>
          </td> 
          <td align="right">$<asp:Literal id="Grid_TransactionslblAcctBalance" runat="server"/>&nbsp;&nbsp;</td> 
          <td>
            <div align="center">
              <asp:Literal id="Grid_TransactionslblCRDRFlag" runat="server"/> 
            </div>
          </td> 
          <td align="left" colspan="2"></td>
        </tr>
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="6">No Transactions found for this Student + Year</td>
        </tr>
        
  </asp:PlaceHolder>

      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
</p>
 

  <span id="txnHolder" runat="server">
    


  
  <input id="txnSTUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="txnENROLMENT_YEAR" type="hidden"  runat="server"/>
  
  <input id="txnLAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="txnCAMPUS_CODE" type="hidden"  runat="server"/>
  
  <input id="txnLAST_ALTERED_DATE" type="hidden"  runat="server"/>
  
  <div align="center">
    <table cellspacing="0" cellpadding="0" width="70%" align="center" border="0">
      <tr>
        <td valign="top">
          <table class="Header" cellspacing="0" cellpadding="0" border="0">
            <tr>
              <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
              <th>Add Transaction</th>
 
              <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
            </tr>
          </table>
 
          <table class="Record" cellspacing="0" cellpadding="0">
            
  <asp:PlaceHolder id="txnError" visible="False" runat="server">
  
            <tr class="Error">
              <td colspan="6"><asp:Label ID="txnErrorLabel" runat="server"/></td>
            </tr>
            
  </asp:PlaceHolder>
  
            <tr class="Controls">
              <th>
              <p align="center"><strong>Transaction<br>
              Date</strong></p>
              </th>
 
              <td><strong>Transaction Code</strong></td> 
              <td>
                <p align="center"><strong>Amount</strong></p>
              </td> 
              <td>
                <p align="center"><strong>DR/CR</strong></p>
              </td> 
              <td>
                <p align="center"><strong>Comments&nbsp;</strong></p>
              </td> 
              <td>
                <p align="center"><strong>Receipt</strong></p>
              </td>
            </tr>
 
            <tr class="Controls">
              <th>
              <p align="center"><asp:TextBox id="txnTXN_DATE" maxlength="12" Columns="10"	runat="server"/></p>
              </th>
 
              <td>
                <select id="txnTXN_CODE"  runat="server"></select>
 </td> 
              <td align="center"><asp:TextBox id="txnAMOUNT" maxlength="15" Columns="10"	runat="server"/></td> 
              <td>
                <select id="txnCR_DR_FLAG"  runat="server"></select>
 </td> 
              <td>
<asp:TextBox id="txnCOMMENTS" Columns="15" TextMode="MultiLine"	runat="server"/>
</td> 
              <td><asp:TextBox id="txnRECEIPT_NO" maxlength="10" Columns="10"	runat="server"/></td>
            </tr>
 
            <tr class="Bottom">
              <td align="right" colspan="6">
                <input id='txnButton_Insert' class="Button" type="submit" value="Add" OnServerClick='txn_Insert' runat="server"/></td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  </div>



  </span>
  

</form>
</body>
</html>

<!--End ASPX page-->

