<%@ Page language="vb" CodeFile="getRegionStudentDetails.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.services.getRegionStudentDetails.getRegionStudentDetailsPage" %>
	
	<%@ Import namespace="DECV_PROD2007.services.getRegionStudentDetails" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>



<asp:repeater id="tblRegionEnrolmentsRepeater" OnItemCommand="tblRegionEnrolmentsItemCommand" OnItemDataBound="tblRegionEnrolmentsItemDataBound" runat="server">
  <HeaderTemplate>
	
<table>
  
  </HeaderTemplate>
  <ItemTemplate>
<tr><td>Approval&nbsp;Code:</td><td>&nbsp;<asp:Literal id="tblRegionEnrolmentslookupid" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).lookupid.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
  <tr><td>Semesters:</td><td>&nbsp;<asp:Literal id="tblRegionEnrolmentsApprovalPeriod" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).ApprovalPeriod.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
  <tr><td>Student&nbsp;Name:</td><td>&nbsp;<asp:Literal id="tblRegionEnrolmentsFirstName" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).FirstName.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="tblRegionEnrolmentsSurname" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).Surname.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/><br>
  <tr><td>Birth Date:</td><td>&nbsp;<asp:Literal id="tblRegionEnrolmentsDateBirth" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).DateBirth.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
  <tr><td>Gender:</td><td>&nbsp;<asp:Literal id="tblRegionEnrolmentsSex" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).Sex.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
  <tr><td>Expected&nbsp;Year&nbsp;Level:</td><td>&nbsp;<asp:Literal id="tblRegionEnrolmentsYearLevel" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).YearLevel.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
  <tr><td>Enrolment&nbsp;Category:</td><td>&nbsp;<asp:Literal id="tblRegionEnrolmentsEnrolCategory" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).EnrolCategory.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
  <tr><td>Enrolment&nbsp;Notes:</td><td>[<asp:Literal id="tblRegionEnrolmentsNotes" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).Notes.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>]&nbsp;</td>
  </tr>
  
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
</table>

  </FooterTemplate>
</asp:repeater>