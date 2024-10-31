<%@ Page language="vb" CodeFile="StudentEnrolmentDetails_maintain_STUDENT_ENROLMENT_txtSchool_Super_Name_PTAutoFill1.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.services.StudentEnrolmentDetails_maintain_STUDENT_ENROLMENT_txtSchool_Super_Name_PTAutoFill1.StudentEnrolmentDetails_maintain_STUDENT_ENROLMENT_txtSchool_Super_Name_PTAutoFill1Page" %>
	
	<%@ Import namespace="DECV_PROD2007.services.StudentEnrolmentDetails_maintain_STUDENT_ENROLMENT_txtSchool_Super_Name_PTAutoFill1" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>


<asp:repeater id="SELECT_distinct_SCHOOL_SURepeater" OnItemCommand="SELECT_distinct_SCHOOL_SUItemCommand" OnItemDataBound="SELECT_distinct_SCHOOL_SUItemDataBound" runat="server">
  <HeaderTemplate>
	[
  </HeaderTemplate>
  <ItemTemplate>
{
"SCHOOL_SUPERVISOR_NAME" : "<asp:Literal id="SELECT_distinct_SCHOOL_SUSCHOOL_SUPERVISOR_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SELECT_distinct_SCHOOL_SUItem)).SCHOOL_SUPERVISOR_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"SCHOOL_SUPERVISOR_PHONE" : "<asp:Literal id="SELECT_distinct_SCHOOL_SUSCHOOL_SUPERVISOR_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SELECT_distinct_SCHOOL_SUItem)).SCHOOL_SUPERVISOR_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"SCHOOL_SUPERVISOR_EMAIL" : "<asp:Literal id="SELECT_distinct_SCHOOL_SUSCHOOL_SUPERVISOR_EMAIL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SELECT_distinct_SCHOOL_SUItem)).SCHOOL_SUPERVISOR_EMAIL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>"
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