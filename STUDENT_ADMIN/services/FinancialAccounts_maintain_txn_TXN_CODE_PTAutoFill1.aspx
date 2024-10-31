<%@ Page language="vb" CodeFile="FinancialAccounts_maintain_txn_TXN_CODE_PTAutoFill1.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.services.FinancialAccounts_maintain_txn_TXN_CODE_PTAutoFill1.FinancialAccounts_maintain_txn_TXN_CODE_PTAutoFill1Page" %>
	
	<%@ Import namespace="DECV_PROD2007.services.FinancialAccounts_maintain_txn_TXN_CODE_PTAutoFill1" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>


<asp:repeater id="TXN_CODERepeater" OnItemCommand="TXN_CODEItemCommand" OnItemDataBound="TXN_CODEItemDataBound" runat="server">
  <HeaderTemplate>
	[
  </HeaderTemplate>
  <ItemTemplate>
{
"TXN_CODE" : "<asp:Literal id="TXN_CODETXN_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,TXN_CODEItem)).TXN_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"CR_DR_FLAG" : "<asp:Literal id="TXN_CODECR_DR_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,TXN_CODEItem)).CR_DR_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>"
}

	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <SeparatorTemplate>
	,
  </SeparatorTemplate>
  <FooterTemplate>
	]
  </FooterTemplate>
</asp:repeater>