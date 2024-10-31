<%@ Page language="vb" CodeFile="MaintainSearchRequest_Advanced_viewMaintainSearchRequest_s_SCHOOLNAME_PTAutocomplete1.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.services.MaintainSearchRequest_Advanced_viewMaintainSearchRequest_s_SCHOOLNAME_PTAutocomplete1.MaintainSearchRequest_Advanced_viewMaintainSearchRequest_s_SCHOOLNAME_PTAutocomplete1Page" %>
	
	<%@ Import namespace="DECV_PROD2007.services.MaintainSearchRequest_Advanced_viewMaintainSearchRequest_s_SCHOOLNAME_PTAutocomplete1" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>


<asp:repeater id="SCHOOLRepeater" OnItemCommand="SCHOOLItemCommand" OnItemDataBound="SCHOOLItemDataBound" runat="server">
  <HeaderTemplate>
	<ul>
  </HeaderTemplate>
  <ItemTemplate><li><asp:Literal id="SCHOOLschool_name" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SCHOOLItem)).school_name.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></li>
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	</ul>
  </FooterTemplate>
</asp:repeater>