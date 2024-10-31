<%@ Page language="vb" CodeFile="Student_Carer_maintainext_STUDENT_CARER_CONTACT4_SURNAME_PTAutoFill1.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.services.Student_Carer_maintainext_STUDENT_CARER_CONTACT4_SURNAME_PTAutoFill1.Student_Carer_maintainext_STUDENT_CARER_CONTACT4_SURNAME_PTAutoFill1Page" %>
	
	<%@ Import namespace="DECV_PROD2007.services.Student_Carer_maintainext_STUDENT_CARER_CONTACT4_SURNAME_PTAutoFill1" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>

<asp:repeater id="STUDENT_CARER_CONTACT5Repeater" OnItemCommand="STUDENT_CARER_CONTACT5ItemCommand" OnItemDataBound="STUDENT_CARER_CONTACT5ItemDataBound" runat="server">
  <HeaderTemplate>
	[
  </HeaderTemplate>
  <ItemTemplate>
{
"CARER_ID" : "<asp:Literal id="STUDENT_CARER_CONTACT5CARER_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).CARER_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"TITLE" : "<asp:Literal id="STUDENT_CARER_CONTACT5TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"SURNAME" : "<asp:Literal id="STUDENT_CARER_CONTACT5SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"FIRST_NAME" : "<asp:Literal id="STUDENT_CARER_CONTACT5FIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"RELATIONSHIP" : "<asp:Literal id="STUDENT_CARER_CONTACT5RELATIONSHIP" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).RELATIONSHIP.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"HOME_PHONE" : "<asp:Literal id="STUDENT_CARER_CONTACT5HOME_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).HOME_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"WORK_PHONE" : "<asp:Literal id="STUDENT_CARER_CONTACT5WORK_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).WORK_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"MOBILE" : "<asp:Literal id="STUDENT_CARER_CONTACT5MOBILE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).MOBILE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"EMAIL" : "<asp:Literal id="STUDENT_CARER_CONTACT5EMAIL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).EMAIL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"LAST_ALTERED_BY" : "<asp:Literal id="STUDENT_CARER_CONTACT5LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"LAST_ALTERED_DATE" : "<asp:Literal id="STUDENT_CARER_CONTACT5LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>"
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