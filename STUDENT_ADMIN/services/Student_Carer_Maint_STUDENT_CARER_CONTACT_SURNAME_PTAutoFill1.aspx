<%@ Page language="vb" CodeFile="Student_Carer_Maint_STUDENT_CARER_CONTACT_SURNAME_PTAutoFill1.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.services.Student_Carer_Maint_STUDENT_CARER_CONTACT_SURNAME_PTAutoFill1.Student_Carer_Maint_STUDENT_CARER_CONTACT_SURNAME_PTAutoFill1Page" %>
	
	<%@ Import namespace="DECV_PROD2007.services.Student_Carer_Maint_STUDENT_CARER_CONTACT_SURNAME_PTAutoFill1" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>


<asp:repeater id="STUDENT_CARER_CONTACT1Repeater" OnItemCommand="STUDENT_CARER_CONTACT1ItemCommand" OnItemDataBound="STUDENT_CARER_CONTACT1ItemDataBound" runat="server">
  <HeaderTemplate>
	[
  </HeaderTemplate>
  <ItemTemplate>
{
"CARER_ID" : "<asp:Literal id="STUDENT_CARER_CONTACT1CARER_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).CARER_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"TITLE" : "<asp:Literal id="STUDENT_CARER_CONTACT1TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"SURNAME" : "<asp:Literal id="STUDENT_CARER_CONTACT1SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"FIRST_NAME" : "<asp:Literal id="STUDENT_CARER_CONTACT1FIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"RELATIONSHIP" : "<asp:Literal id="STUDENT_CARER_CONTACT1RELATIONSHIP" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).RELATIONSHIP.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"HOME_PHONE" : "<asp:Literal id="STUDENT_CARER_CONTACT1HOME_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).HOME_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"WORK_PHONE" : "<asp:Literal id="STUDENT_CARER_CONTACT1WORK_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).WORK_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"MOBILE" : "<asp:Literal id="STUDENT_CARER_CONTACT1MOBILE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).MOBILE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"EMAIL" : "<asp:Literal id="STUDENT_CARER_CONTACT1EMAIL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).EMAIL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>"
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