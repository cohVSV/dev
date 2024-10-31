<%@ Page language="vb" CodeFile="Student_Carer_Maint_STUDENT_CARER_CONTACT_SURNAME_PTAutocomplete1.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.services.Student_Carer_Maint_STUDENT_CARER_CONTACT_SURNAME_PTAutocomplete1.Student_Carer_Maint_STUDENT_CARER_CONTACT_SURNAME_PTAutocomplete1Page" %>
	
	<%@ Import namespace="DECV_PROD2007.services.Student_Carer_Maint_STUDENT_CARER_CONTACT_SURNAME_PTAutocomplete1" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>



<asp:repeater id="STUDENT_CARER_CONTACT1Repeater" OnItemCommand="STUDENT_CARER_CONTACT1ItemCommand" OnItemDataBound="STUDENT_CARER_CONTACT1ItemDataBound" runat="server">
  <HeaderTemplate>
	
<ul>
  
  </HeaderTemplate>
  <ItemTemplate>
  <li><asp:Literal id="STUDENT_CARER_CONTACT1SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACT1FIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACT1EMAIL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).EMAIL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>~ <font color="white"><asp:Literal id="STUDENT_CARER_CONTACT1CARER_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).CARER_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></font> <%=PageVariables.Get("")%> 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	</li>
</ul>

  </FooterTemplate>
</asp:repeater>