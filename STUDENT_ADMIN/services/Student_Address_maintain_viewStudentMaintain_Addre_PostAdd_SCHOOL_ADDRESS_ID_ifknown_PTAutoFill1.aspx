<%@ Page language="vb" CodeFile="Student_Address_maintain_viewStudentMaintain_Addre_PostAdd_SCHOOL_ADDRESS_ID_ifknown_PTAutoFill1.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.services.Student_Address_maintain_viewStudentMaintain_Addre_PostAdd_SCHOOL_ADDRESS_ID_ifknown_PTAutoFill1.Student_Address_maintain_viewStudentMaintain_Addre_PostAdd_SCHOOL_ADDRESS_ID_ifknown_PTAutoFill1Page" %>
	
	<%@ Import namespace="DECV_PROD2007.services.Student_Address_maintain_viewStudentMaintain_Addre_PostAdd_SCHOOL_ADDRESS_ID_ifknown_PTAutoFill1" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>


<asp:repeater id="ADDRESSRepeater" OnItemCommand="ADDRESSItemCommand" OnItemDataBound="ADDRESSItemDataBound" runat="server">
  <HeaderTemplate>
	[
  </HeaderTemplate>
  <ItemTemplate>
{
"ADDRESS_ID" : "<asp:Literal id="ADDRESSADDRESS_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).ADDRESS_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"ADDRESSEE" : "<asp:Literal id="ADDRESSADDRESSEE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).ADDRESSEE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"AGENT" : "<asp:Literal id="ADDRESSAGENT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).AGENT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"ADDR1" : "<asp:Literal id="ADDRESSADDR1" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).ADDR1.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"ADDR2" : "<asp:Literal id="ADDRESSADDR2" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).ADDR2.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"SUBURB_TOWN" : "<asp:Literal id="ADDRESSSUBURB_TOWN" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).SUBURB_TOWN.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"POSTCODE" : "<asp:Literal id="ADDRESSPOSTCODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).POSTCODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"STATE" : "<asp:Literal id="ADDRESSSTATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).STATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"COUNTRY" : "<asp:Literal id="ADDRESSCOUNTRY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).COUNTRY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"PHONE_A" : "<asp:Literal id="ADDRESSPHONE_A" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).PHONE_A.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"PHONE_B" : "<asp:Literal id="ADDRESSPHONE_B" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).PHONE_B.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"FAX" : "<asp:Literal id="ADDRESSFAX" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).FAX.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"EMAIL_ADDRESS" : "<asp:Literal id="ADDRESSEMAIL_ADDRESS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).EMAIL_ADDRESS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"LAST_ALTERED_BY" : "<asp:Literal id="ADDRESSLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"LAST_ALTERED_DATE" : "<asp:Literal id="ADDRESSLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"EMAIL_ADDRESS2" : "<asp:Literal id="ADDRESSEMAIL_ADDRESS2" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ADDRESSItem)).EMAIL_ADDRESS2.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>"
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