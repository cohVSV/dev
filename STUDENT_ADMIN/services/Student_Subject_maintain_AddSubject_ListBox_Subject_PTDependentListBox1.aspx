<%@ Page language="vb" CodeFile="Student_Subject_maintain_AddSubject_ListBox_Subject_PTDependentListBox1.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.services.Student_Subject_maintain_AddSubject_ListBox_Subject_PTDependentListBox1.Student_Subject_maintain_AddSubject_ListBox_Subject_PTDependentListBox1Page" %>
	
	<%@ Import namespace="DECV_PROD2007.services.Student_Subject_maintain_AddSubject_ListBox_Subject_PTDependentListBox1" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>


<asp:repeater id="SUBJECTRepeater" OnItemCommand="SUBJECTItemCommand" OnItemDataBound="SUBJECTItemDataBound" runat="server">
  <HeaderTemplate>
	[
  </HeaderTemplate>
  <ItemTemplate>
[
"<asp:Literal id="SUBJECTSUBJECT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).SUBJECT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"<asp:Literal id="SUBJECTsubject_displaytext" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).subject_displaytext.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>"
]

	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <SeparatorTemplate>
	,
  </SeparatorTemplate>
  <FooterTemplate>
	]
  </FooterTemplate>
</asp:repeater>