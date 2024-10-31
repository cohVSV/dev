<!--ASPX page @1-A64DE86C-->
    <%@ Page language="vb" CodeFile="Staff_Inductions_ByCourse_list.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Staff_Inductions_ByCourse_list.Staff_Inductions_ByCourse_listPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Staff_Inductions_ByCourse_list" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 4.1.00.032" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Staff Inductions - By Course List</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<style media="print">
#STAFF_INDUCTIONS_COURSESSearch .noprint{display:none;} 
#STAFF_INDUCTIONS_COURSESRepeater {width: 100%; margin: 0; float: none;}
a:link, a:visited {color: #781351}
</style>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p class="noprint"><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p>

  <span id="STAFF_INDUCTIONS_COURSESSearchHolder" runat="server">
    


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
          
  <asp:PlaceHolder id="STAFF_INDUCTIONS_COURSESSearchError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="STAFF_INDUCTIONS_COURSESSearchErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>Keyword</th>
 
            <td><asp:TextBox id="STAFF_INDUCTIONS_COURSESSearchs_INDUCTION_TITLE" maxlength="50" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Status</th>
 
            <td>
              <asp:RadioButtonList id="STAFF_INDUCTIONS_COURSESSearchs_STATUS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td><a id="STAFF_INDUCTIONS_COURSESSearchClearParameters" href="" runat="server"  >Clear</a></td> 
            <td align="right">
              <input id='STAFF_INDUCTIONS_COURSESSearchButton_DoSearch' class="Button" type="submit" value="Search" OnServerClick='STAFF_INDUCTIONS_COURSESSearch_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  </p>
<p align="right"><a id="Link_AddNEw" href="" class="Button noprint" runat="server"  >Add New</a></p>
<p><br>
</p>
<p>

<asp:repeater id="STAFF_INDUCTIONS_COURSESRepeater" OnItemCommand="STAFF_INDUCTIONS_COURSESItemCommand" OnItemDataBound="STAFF_INDUCTIONS_COURSESItemDataBound" runat="server">
  <HeaderTemplate>
	
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
        <tr class="Row">
          <td colspan="6">Total Records:&nbsp;<asp:Literal id="STAFF_INDUCTIONS_COURSESSTAFF_INDUCTIONS_COURSES_TotalRecords" runat="server"/></td>
        </tr>
 
        <tr class="Caption">
          <th></th>
 
          <th>
          <CC:Sorter id="Sorter_INDUCTION_TITLESorter" field="Sorter_INDUCTION_TITLE" OwnerState="<%# STAFF_INDUCTIONS_COURSESData.SortField.ToString()%>" OwnerDir="<%# STAFF_INDUCTIONS_COURSESData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_INDUCTION_TITLESort" runat="server">INDUCTION TITLE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_INDUCTION_DESCRIPTIONSorter" field="Sorter_INDUCTION_DESCRIPTION" OwnerState="<%# STAFF_INDUCTIONS_COURSESData.SortField.ToString()%>" OwnerDir="<%# STAFF_INDUCTIONS_COURSESData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_INDUCTION_DESCRIPTIONSort" runat="server">INDUCTION DESCRIPTION</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_STATUSSorter" field="Sorter_STATUS" OwnerState="<%# STAFF_INDUCTIONS_COURSESData.SortField.ToString()%>" OwnerDir="<%# STAFF_INDUCTIONS_COURSESData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STATUSSort" runat="server">STATUS</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# STAFF_INDUCTIONS_COURSESData.SortField.ToString()%>" OwnerDir="<%# STAFF_INDUCTIONS_COURSESData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# STAFF_INDUCTIONS_COURSESData.SortField.ToString()%>" OwnerDir="<%# STAFF_INDUCTIONS_COURSESData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="TEXT-ALIGN: right"><a id="STAFF_INDUCTIONS_COURSESid" href="" runat="server"  >edit</a>&nbsp;</td> 
          <td><a id="STAFF_INDUCTIONS_COURSESINDUCTION_TITLE" href="" runat="server"  ><%#(CType(Container.DataItem,STAFF_INDUCTIONS_COURSESItem)).INDUCTION_TITLE.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="STAFF_INDUCTIONS_COURSESINDUCTION_DESCRIPTION" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_INDUCTIONS_COURSESItem)).INDUCTION_DESCRIPTION.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="STAFF_INDUCTIONS_COURSESSTATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_INDUCTIONS_COURSESItem)).STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFF_INDUCTIONS_COURSESLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_INDUCTIONS_COURSESItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFF_INDUCTIONS_COURSESLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFF_INDUCTIONS_COURSESItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="6">No Inductions found.</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="6">
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# STAFF_INDUCTIONS_COURSESData.PagesCount%>" PageSize="<%# STAFF_INDUCTIONS_COURSESData.RecordsPerPage%>" PageNumber="<%# STAFF_INDUCTIONS_COURSESData.PageNumber%>" runat="server">
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

  </FooterTemplate>
</asp:repeater>
</p>
<p><br>
</p>

</form>
</body>
</html>

<!--End ASPX page-->

