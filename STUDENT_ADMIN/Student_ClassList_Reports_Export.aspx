<!--ASPX page @1-8C0B5E72-->
    <%@ Page language="vb" CodeFile="Student_ClassList_Reports_Export.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_ClassList_Reports_Export.Student_ClassList_Reports_ExportPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_ClassList_Reports_Export" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 4.1.00.032"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Class List Reports</title>


<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">



<asp:repeater id="Students_GridRepeater" OnItemCommand="Students_GridItemCommand" OnItemDataBound="Students_GridItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" align="center" border="0">
  <tr>
    <td valign="top">
      <table class="Grid" cellspacing="0" cellpadding="0" border="0">
        <tr class="Caption">
          <th>STUDENT ID</th>
 
          <th>&nbsp;</th>
 
          <th>&nbsp;</th>
 
          <th>SURNAME</th>
 
          <th>FIRST NAME</th>
 
          <th>Current&nbsp;Phone Number </th>
 
          <th>Current Email Address&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</th>
 
          <th>&nbsp;Postal Phone Number</th>
 
          <th>Postal&nbsp;Email Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
 
          <th>&nbsp;Subject Abbrev</th>
 
          <th>Class Code</th>
 
          <th>Subject Enrol Date&nbsp;</th>
 
          <th>HOME SCHOOL</th>
 
          <th>Supervisor Name&nbsp;</th>
 
          <th>Supervisor Phone&nbsp;</th>
 
          <th>Supervisor Email&nbsp;</th>
 
          <th>Staff ID&nbsp;</th>
 
          <th>Parent Name&nbsp;</th>
 
          <th>Parent Mobile&nbsp;</th>
 
          <th>Parent Home Phone&nbsp;</th>
 
          <th>Parent Email&nbsp;</th>
 
          <th>Learning Advisor&nbsp;</th>
 
          <th>Learning Advisor Email&nbsp;</th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="TEXT-ALIGN: right"><a id="Students_GridSTUDENT_ID" href="" runat="server"  ><%#(CType(Container.DataItem,Students_GridItem)).STUDENT_ID.GetFormattedValue()%></a>&nbsp;<asp:Literal id="Students_Gridlabel_ALERTS" runat="server"/></td> 
          <td><a id="Students_GridContacts" href="" runat="server"  >Comments</a></td> 
          <td>
            <a id="Students_GridQuickContact" href="" runat="server"   Visible="False">Quick Comment</a></td> 
          <td><asp:Literal id="Students_GridSURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="Students_GridFIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td>&nbsp;<asp:Literal id="Students_GridPHONE1" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).PHONE1.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td><a id="Students_GridEMAIL1" href="" runat="server"  ><%#(CType(Container.DataItem,Students_GridItem)).EMAIL1.GetFormattedValue()%></a></td> 
          <td>&nbsp;<asp:Literal id="Students_GridPHONE2" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).PHONE2.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td><a id="Students_GridEMAIL2" href="" runat="server"  ><%#(CType(Container.DataItem,Students_GridItem)).EMAIL2.GetFormattedValue()%></a></td> 
          <td>&nbsp;<asp:Literal id="Students_GridSUBJECT_ABBREV" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).SUBJECT_ABBREV.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="Students_GridCLASS_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).CLASS_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="Students_GridENROLMENT_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).ENROLMENT_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td><asp:Literal id="Students_GridSCHOOL_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).SCHOOL_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td>&nbsp;<asp:Literal id="Students_GridSCHOOL_SUPER_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).SCHOOL_SUPER_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="Students_GridSCHOOL_SUPER_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).SCHOOL_SUPER_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<a id="Students_GridSCHOOL_SUPER_EMAIL" href="" runat="server"  ><%#(CType(Container.DataItem,Students_GridItem)).SCHOOL_SUPER_EMAIL.GetFormattedValue()%></a></td> 
          <td>&nbsp;<asp:Literal id="Students_GridSTAFF_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).STAFF_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="Students_GridPARENT_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).PARENT_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="Students_GridPARENT_MOBILE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).PARENT_MOBILE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="Students_GridPARENT_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).PARENT_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<a id="Students_GridPARENT_EMAIL" href="" runat="server"  ><%#(CType(Container.DataItem,Students_GridItem)).PARENT_EMAIL.GetFormattedValue()%></a></td> 
          <td>&nbsp;<asp:Literal id="Students_GridLAD" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).LAD.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<a id="Students_GridLearningAdvisorEmail" href="" runat="server"  ><%#(CType(Container.DataItem,Students_GridItem)).LearningAdvisorEmail.GetFormattedValue()%></a></td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="23">No Students found for this Teacher and Subject.</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td></td> 
          <td></td> 
          <td></td> 
          <td></td> 
          <td></td> 
          <td>&nbsp;</td> 
          <td></td> 
          <td></td> 
          <td></td> 
          <td></td> 
          <td>&nbsp;</td> 
          <td></td> 
          <td>&nbsp;</td> 
          <td></td> 
          <td>&nbsp;</td> 
          <td>&nbsp;</td> 
          <td>&nbsp;</td> 
          <td></td> 
          <td>&nbsp;</td> 
          <td>&nbsp;</td> 
          <td>&nbsp;</td> 
          <td>&nbsp;</td> 
          <td>&nbsp;</td>
        </tr>
      </table>
    </td>
  </tr>
</table>
&nbsp;
  </FooterTemplate>
</asp:repeater>
&nbsp;&nbsp; 

</form>
</body>
</html>

<!--End ASPX page-->

