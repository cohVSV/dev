<%@ Page language="vb" CodeFile="getStudentQuickContactDetails.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.services.getStudentQuickContactDetails.getStudentQuickContactDetailsPage" %>
	
	<%@ Import namespace="DECV_PROD2007.services.getStudentQuickContactDetails" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>



<asp:repeater id="sps_StudentQuickContactLoRepeater" OnItemCommand="sps_StudentQuickContactLoItemCommand" OnItemDataBound="sps_StudentQuickContactLoItemDataBound" runat="server">
  <HeaderTemplate>
	[

  </HeaderTemplate>
  <ItemTemplate>{ "id":"<asp:Literal id="sps_StudentQuickContactLostudent_id" Text='<%# Server.HtmlEncode((CType(Container.DataItem,sps_StudentQuickContactLoItem)).student_id.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",  "value": "<asp:Literal id="sps_StudentQuickContactLoStudentName1" Text='<%# Server.HtmlEncode((CType(Container.DataItem,sps_StudentQuickContactLoItem)).StudentName1.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>" }
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <SeparatorTemplate>
	,
  </SeparatorTemplate>
  <FooterTemplate>
	
]
  </FooterTemplate>
</asp:repeater>