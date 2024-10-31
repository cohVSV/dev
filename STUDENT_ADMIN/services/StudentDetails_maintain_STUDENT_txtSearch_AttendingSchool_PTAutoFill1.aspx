<%@ Page language="vb" CodeFile="StudentDetails_maintain_STUDENT_txtSearch_AttendingSchool_PTAutoFill1.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.services.StudentDetails_maintain_STUDENT_txtSearch_AttendingSchool_PTAutoFill1.StudentDetails_maintain_STUDENT_txtSearch_AttendingSchool_PTAutoFill1Page" %>
	
	<%@ Import namespace="DECV_PROD2007.services.StudentDetails_maintain_STUDENT_txtSearch_AttendingSchool_PTAutoFill1" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>


<asp:repeater id="SCHOOLRepeater" OnItemCommand="SCHOOLItemCommand" OnItemDataBound="SCHOOLItemDataBound" runat="server">
  <HeaderTemplate>
	[
  </HeaderTemplate>
  <ItemTemplate>
{
"SCHOOL_ID" : "<asp:Literal id="SCHOOLSCHOOL_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SCHOOLItem)).SCHOOL_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"SCHOOL_NAME" : "<asp:Literal id="SCHOOLSCHOOL_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SCHOOLItem)).SCHOOL_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>"
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