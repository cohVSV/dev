<%@ Page language="vb" CodeFile="StudentEnrolment_AddNewYear_STUDENT_inputREgionID_PTAutoFill1.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.services.StudentEnrolment_AddNewYear_STUDENT_inputREgionID_PTAutoFill1.StudentEnrolment_AddNewYear_STUDENT_inputREgionID_PTAutoFill1Page" %>
	
	<%@ Import namespace="DECV_PROD2007.services.StudentEnrolment_AddNewYear_STUDENT_inputREgionID_PTAutoFill1" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>


<asp:repeater id="tblRegionEnrolmentsRepeater" OnItemCommand="tblRegionEnrolmentsItemCommand" OnItemDataBound="tblRegionEnrolmentsItemDataBound" runat="server">
  <HeaderTemplate>
	[
  </HeaderTemplate>
  <ItemTemplate>
{
"id" : "<asp:Literal id="tblRegionEnrolmentsid" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).id.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"FirstName" : "<asp:Literal id="tblRegionEnrolmentsFirstName" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).FirstName.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"Surname" : "<asp:Literal id="tblRegionEnrolmentsSurname" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).Surname.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"DateBirth" : "<asp:Literal id="tblRegionEnrolmentsDateBirth" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).DateBirth.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"Sex" : "<asp:Literal id="tblRegionEnrolmentsSex" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).Sex.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"YearLevel" : "<asp:Literal id="tblRegionEnrolmentsYearLevel" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).YearLevel.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"lookupid" : "<asp:Literal id="tblRegionEnrolmentslookupid" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).lookupid.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"EnrolNotes" : "<asp:Literal id="tblRegionEnrolmentsEnrolNotes" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).EnrolNotes.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"EnrolCategory" : "<asp:Literal id="tblRegionEnrolmentsEnrolCategory" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).EnrolCategory.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"ApprovalPeriod" : "<asp:Literal id="tblRegionEnrolmentsApprovalPeriod" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).ApprovalPeriod.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>",
"SchoolID" : "<asp:Literal id="tblRegionEnrolmentsSchoolID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,tblRegionEnrolmentsItem)).SchoolID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>"
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