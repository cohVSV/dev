<%@ Page language="vb" CodeFile="StudentEnrolmentDetails_maintain_STUDENT_ENROLMENT_txtSchool_Super_Name_PTAutocomplete1.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.services.StudentEnrolmentDetails_maintain_STUDENT_ENROLMENT_txtSchool_Super_Name_PTAutocomplete1.StudentEnrolmentDetails_maintain_STUDENT_ENROLMENT_txtSchool_Super_Name_PTAutocomplete1Page" %>
	
	<%@ Import namespace="DECV_PROD2007.services.StudentEnrolmentDetails_maintain_STUDENT_ENROLMENT_txtSchool_Super_Name_PTAutocomplete1" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>


<asp:repeater id="STUDENT_ENROLMENT1Repeater" OnItemCommand="STUDENT_ENROLMENT1ItemCommand" OnItemDataBound="STUDENT_ENROLMENT1ItemDataBound" runat="server">
  <HeaderTemplate>
	<ul>
  </HeaderTemplate>
  <ItemTemplate><li><asp:Literal id="STUDENT_ENROLMENT1SCHOOL_SUPERVISOR_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_ENROLMENT1Item)).SCHOOL_SUPERVISOR_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></li>
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	</ul>
  </FooterTemplate>
</asp:repeater>