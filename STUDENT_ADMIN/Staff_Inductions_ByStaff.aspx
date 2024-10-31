<!--ASPX page @1-5BD7FED0-->
    <%@ Page language="vb" CodeFile="Staff_Inductions_ByStaff.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Staff_Inductions_ByStaff.Staff_Inductions_ByStaffPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Staff_Inductions_ByStaff" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 4.1.00.032" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Staff Inductions - By Staff</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<style media="print">
#STAFF_INDUCTIONS_COURSESHolder{display:none;} 
#STAFF_INDUCTIONS_COURSES1Repeater {width: 100%; margin: 0; float: none;}
.noprint{display:none;}
a:link, a:visited {color: #781351}
</style>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p>

  <span id="STAFF_INDUCTIONS_COURSESHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Search Staff Inductions</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="STAFF_INDUCTIONS_COURSESError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="STAFF_INDUCTIONS_COURSESErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>Staff ID</th>
 
            <td>
              <select id="STAFF_INDUCTIONS_COURSESs_View_StaffList_Active_Inactive_staff_ID"  runat="server"></select>
 <asp:Literal id="STAFF_INDUCTIONS_COURSESlabel_TeacherID" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td><a id="STAFF_INDUCTIONS_COURSESClearParameters" href="" runat="server"  >Clear</a></td> 
            <td align="right">
              <input id='STAFF_INDUCTIONS_COURSESButton_DoSearch' class="Button" type="submit" value="Search" OnServerClick='STAFF_INDUCTIONS_COURSES_Search' runat="server"/></td>
          </tr>
        </table>
 
        <p align="center"><em><strong>Try Clicking 'Search'</strong></em></p>
      </td>
    </tr>
  </table>



  </span>
  <br>

<asp:repeater id="STAFF_INDUCTIONS_COURSES1Repeater" OnItemCommand="STAFF_INDUCTIONS_COURSES1ItemCommand" OnItemDataBound="STAFF_INDUCTIONS_COURSES1ItemDataBound" runat="server">
  <HeaderTemplate>
	
<p align="right"><a id="STAFF_INDUCTIONS_COURSES1linkNewInduction1" href="" class="Button noprint" runat="server"  >Add new</a></p>
<table cellspacing="0" cellpadding="0" align="center" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
          <th>List of Staff Inductions</th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          
	<asp:PlaceHolder id="STAFF_INDUCTIONS_COURSES1Panel_header_editbutton" Visible="true" runat="server">
	
          <th></th>
 
	</asp:PlaceHolder>
	
          <th>
          <CC:Sorter id="Sorter_staffnameSorter" field="Sorter_staffname" OwnerState="<%# STAFF_INDUCTIONS_COURSES1Data.SortField.ToString()%>" OwnerDir="<%# STAFF_INDUCTIONS_COURSES1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_staffnameSort" runat="server">Staff Name</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_STAFF_INDUCTIONS_PROGRESS_STATUSSorter" field="Sorter_STAFF_INDUCTIONS_PROGRESS_STATUS" OwnerState="<%# STAFF_INDUCTIONS_COURSES1Data.SortField.ToString()%>" OwnerDir="<%# STAFF_INDUCTIONS_COURSES1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STAFF_INDUCTIONS_PROGRESS_STATUSSort" runat="server">Status</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_DATE_COMPLETEDSorter" field="Sorter_DATE_COMPLETED" OwnerState="<%# STAFF_INDUCTIONS_COURSES1Data.SortField.ToString()%>" OwnerDir="<%# STAFF_INDUCTIONS_COURSES1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_DATE_COMPLETEDSort" runat="server">Date Completed</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_INDUCTION_TITLESorter" field="Sorter_INDUCTION_TITLE" OwnerState="<%# STAFF_INDUCTIONS_COURSES1Data.SortField.ToString()%>" OwnerDir="<%# STAFF_INDUCTIONS_COURSES1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_INDUCTION_TITLESort" runat="server">Induction Title</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          
	<asp:PlaceHolder id="STAFF_INDUCTIONS_COURSES1Panel_data_editbutton" Visible="false" runat="server">
	
          <td><a id="STAFF_INDUCTIONS_COURSES1Link1" href="" runat="server"  >edit</a>&nbsp;</td> 
	</asp:PlaceHolder>
	
          <td><asp:Literal id="STAFF_INDUCTIONS_COURSES1staffname" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_INDUCTIONS_COURSES1Item)).staffname.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFF_INDUCTIONS_COURSES1STAFF_INDUCTIONS_PROGRESS_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_INDUCTIONS_COURSES1Item)).STAFF_INDUCTIONS_PROGRESS_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFF_INDUCTIONS_COURSES1DATE_COMPLETED" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_INDUCTIONS_COURSES1Item)).DATE_COMPLETED.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFF_INDUCTIONS_COURSES1INDUCTION_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_INDUCTIONS_COURSES1Item)).INDUCTION_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="5">No Staff Inductions found - <a id="STAFF_INDUCTIONS_COURSES1linkNewInduction" href="" class="Button" runat="server"  >Add new</a></td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="5">&nbsp; 
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# STAFF_INDUCTIONS_COURSES1Data.PagesCount%>" PageSize="<%# STAFF_INDUCTIONS_COURSES1Data.RecordsPerPage%>" PageNumber="<%# STAFF_INDUCTIONS_COURSES1Data.PageNumber%>" runat="server">
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img src="Styles/Blueprint/Images/First.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="FirstOff" runat="server"><img src="Styles/Blueprint/Images/FirstOff.gif" border="0"></CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img src="Styles/Blueprint/Images/Prev.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOff" runat="server"><img src="Styles/Blueprint/Images/PrevOff.gif" border="0"></CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %> of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img src="Styles/Blueprint/Images/Next.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="NextOff" runat="server"><img src="Styles/Blueprint/Images/NextOff.gif" border="0"></CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img src="Styles/Blueprint/Images/Last.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOff" runat="server"><img src="Styles/Blueprint/Images/LastOff.gif" border="0"></CC:NavigatorItem></CC:Navigator>
&nbsp;</td>
        </tr>
      </table>
    </td>
  </tr>
</table>
&nbsp;
  </FooterTemplate>
</asp:repeater>
<br>
<br>
<br>
<p></p>

</form>
</body>
</html>

<!--End ASPX page-->

