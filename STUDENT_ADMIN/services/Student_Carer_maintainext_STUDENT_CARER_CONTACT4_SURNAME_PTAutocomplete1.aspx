<%@ Page language="vb" CodeFile="Student_Carer_maintainext_STUDENT_CARER_CONTACT4_SURNAME_PTAutocomplete1.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.services.Student_Carer_maintainext_STUDENT_CARER_CONTACT4_SURNAME_PTAutocomplete1.Student_Carer_maintainext_STUDENT_CARER_CONTACT4_SURNAME_PTAutocomplete1Page" %>
	
	<%@ Import namespace="DECV_PROD2007.services.Student_Carer_maintainext_STUDENT_CARER_CONTACT4_SURNAME_PTAutocomplete1" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>

<asp:repeater id="STUDENT_CARER_CONTACT5Repeater" OnItemCommand="STUDENT_CARER_CONTACT5ItemCommand" OnItemDataBound="STUDENT_CARER_CONTACT5ItemDataBound" runat="server">
  <HeaderTemplate>
	<ul>
  </HeaderTemplate>
  <ItemTemplate><li><asp:Literal id="STUDENT_CARER_CONTACT5super_name" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).super_name.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></li>
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	</ul>
  </FooterTemplate>
</asp:repeater>