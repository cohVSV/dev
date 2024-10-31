<%@ Page language="vb" CodeFile="CollectAddressDetails.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.services.CollectAddressDetails.CollectAddressDetailsPage" %>
	
	<%@ Import namespace="DECV_PROD2007.services.CollectAddressDetails" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>



<asp:repeater id="ADDRESSRepeater" OnItemCommand="ADDRESSItemCommand" OnItemDataBound="ADDRESSItemDataBound" runat="server">
  <HeaderTemplate>
	[

  </HeaderTemplate>
  <ItemTemplate>[ "<asp:Literal id="ADDRESSADDRESS_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).ADDRESS_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ADDRESSADDRESSEE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).ADDRESSEE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ADDRESSAGENT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).AGENT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ADDRESSADDR1" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).ADDR1.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ADDRESSADDR2" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).ADDR2.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ADDRESSSUBURB_TOWN" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).SUBURB_TOWN.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ADDRESSPOSTCODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).POSTCODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ADDRESSSTATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).STATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ADDRESSCOUNTRY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).COUNTRY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ADDRESSPHONE_A" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).PHONE_A.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ADDRESSPHONE_B" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).PHONE_B.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ADDRESSFAX" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).FAX.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ADDRESSEMAIL_ADDRESS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).EMAIL_ADDRESS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ADDRESSLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ADDRESSLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ADDRESSEMAIL_ADDRESS2" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).EMAIL_ADDRESS2.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>" ]
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <SeparatorTemplate>
	,
  </SeparatorTemplate>
  <FooterTemplate>
	
]
  </FooterTemplate>
</asp:repeater>