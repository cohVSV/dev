<%@ Page language="vb" CodeFile="CountAssignmentsPending.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.services.CountAssignmentsPending.CountAssignmentsPendingPage" %>
	
	<%@ Import namespace="DECV_PROD2007.services.CountAssignmentsPending" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>



<asp:repeater id="ASSIGNMENT_SUBMISSIONRepeater" OnItemCommand="ASSIGNMENT_SUBMISSIONItemCommand" OnItemDataBound="ASSIGNMENT_SUBMISSIONItemDataBound" runat="server">
  <HeaderTemplate>
	[

  </HeaderTemplate>
  <ItemTemplate>[ "<asp:Literal id="ASSIGNMENT_SUBMISSIONSTUDENT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSIONItem)).STUDENT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ASSIGNMENT_SUBMISSIONENROLMENT_YEAR" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSIONItem)).ENROLMENT_YEAR.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ASSIGNMENT_SUBMISSIONSUBJECT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSIONItem)).SUBJECT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ASSIGNMENT_SUBMISSIONASSIGNMENT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSIONItem)).ASSIGNMENT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ASSIGNMENT_SUBMISSIONSUBMISSION_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSIONItem)).SUBMISSION_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ASSIGNMENT_SUBMISSIONRECEIVED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSIONItem)).RECEIVED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ASSIGNMENT_SUBMISSIONRETURNED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSIONItem)).RETURNED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ASSIGNMENT_SUBMISSIONSTAFF_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSIONItem)).STAFF_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ASSIGNMENT_SUBMISSIONLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSIONItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>", "<asp:Literal id="ASSIGNMENT_SUBMISSIONLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSIONItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>" ]
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <SeparatorTemplate>
	,
  </SeparatorTemplate>
  <FooterTemplate>
	
]
  </FooterTemplate>
</asp:repeater>