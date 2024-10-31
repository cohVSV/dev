<!--ASPX page @1-BD6B3E6E-->
    <%@ Page language="vb" CodeFile="GOVERNMENT_ALLO_list.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.GOVERNMENT_ALLO_list.GOVERNMENT_ALLO_listPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.GOVERNMENT_ALLO_list" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="text/html; charset=windows-1252">
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0">

<title>GOVERNMENT ALLOWANCE</title>

<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<DECV_PROD2007:Header id="Header" runat="server"/>


<asp:repeater id="GOVERNMENT_ALLOWANCERepeater" OnItemCommand="GOVERNMENT_ALLOWANCEItemCommand" OnItemDataBound="GOVERNMENT_ALLOWANCEItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      <table cellspacing="0" cellpadding="0" border="0" class="Header">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          <th>List of GOVERNMENT ALLOWANCE </th>
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_ALLOWANCE_CODESorter" field="Sorter_ALLOWANCE_CODE" OwnerState="<%# GOVERNMENT_ALLOWANCEData.SortField.ToString()%>" OwnerDir="<%# GOVERNMENT_ALLOWANCEData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ALLOWANCE_CODESort" runat="server">ALLOWANCE CODE</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_ALLOWANCE_TITLESorter" field="Sorter_ALLOWANCE_TITLE" OwnerState="<%# GOVERNMENT_ALLOWANCEData.SortField.ToString()%>" OwnerDir="<%# GOVERNMENT_ALLOWANCEData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ALLOWANCE_TITLESort" runat="server">ALLOWANCE TITLE</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_ALLOWANCE_DESCRIPTIONSorter" field="Sorter_ALLOWANCE_DESCRIPTION" OwnerState="<%# GOVERNMENT_ALLOWANCEData.SortField.ToString()%>" OwnerDir="<%# GOVERNMENT_ALLOWANCEData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ALLOWANCE_DESCRIPTIONSort" runat="server">ALLOWANCE DESCRIPTION</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# GOVERNMENT_ALLOWANCEData.SortField.ToString()%>" OwnerDir="<%# GOVERNMENT_ALLOWANCEData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# GOVERNMENT_ALLOWANCEData.SortField.ToString()%>" OwnerDir="<%# GOVERNMENT_ALLOWANCEData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
        </tr>
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="text-align:right;"><a id="GOVERNMENT_ALLOWANCEALLOWANCE_CODE" href="" runat="server"  ><%#(CType(Container.DataItem,GOVERNMENT_ALLOWANCEItem)).ALLOWANCE_CODE.GetFormattedValue()%></a>&nbsp;</td>
          <td><asp:Literal id="GOVERNMENT_ALLOWANCEALLOWANCE_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GOVERNMENT_ALLOWANCEItem)).ALLOWANCE_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="GOVERNMENT_ALLOWANCEALLOWANCE_DESCRIPTION" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GOVERNMENT_ALLOWANCEItem)).ALLOWANCE_DESCRIPTION.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="GOVERNMENT_ALLOWANCELAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GOVERNMENT_ALLOWANCEItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="GOVERNMENT_ALLOWANCELAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GOVERNMENT_ALLOWANCEItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
        
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <AlternatingItemTemplate>
	
        <tr class="AltRow">
          <td style="text-align:right;"><a id="GOVERNMENT_ALLOWANCEAlt_ALLOWANCE_CODE" href="" runat="server"  ><%#(CType(Container.DataItem,GOVERNMENT_ALLOWANCEItem)).Alt_ALLOWANCE_CODE.GetFormattedValue()%></a>&nbsp;</td>
          <td><asp:Literal id="GOVERNMENT_ALLOWANCEAlt_ALLOWANCE_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GOVERNMENT_ALLOWANCEItem)).Alt_ALLOWANCE_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="GOVERNMENT_ALLOWANCEAlt_ALLOWANCE_DESCRIPTION" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GOVERNMENT_ALLOWANCEItem)).Alt_ALLOWANCE_DESCRIPTION.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="GOVERNMENT_ALLOWANCEAlt_LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GOVERNMENT_ALLOWANCEItem)).Alt_LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="GOVERNMENT_ALLOWANCEAlt_LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,GOVERNMENT_ALLOWANCEItem)).Alt_LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
        
	<asp:PlaceHolder id="AltIterationContainer" runat="server"/>
  </AlternatingItemTemplate>
  <FooterTemplate>
	
        
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="5">No records</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="5"><a id="GOVERNMENT_ALLOWANCEGOVERNMENT_ALLOWANCE_Insert" href="" runat="server"  >Add New</a>&nbsp;
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# GOVERNMENT_ALLOWANCEData.PagesCount%>" PageSize="<%# GOVERNMENT_ALLOWANCEData.RecordsPerPage%>" PageNumber="<%# GOVERNMENT_ALLOWANCEData.PageNumber%>" runat="server">
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server">|&lt; </asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server">&lt;&lt; </asp:LinkButton> </CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %> of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server">&gt;&gt; </asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server">&gt;| </asp:LinkButton> </CC:NavigatorItem></CC:Navigator>
</td>
        </tr>
      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
<br>
<DECV_PROD2007:Footer id="Footer" runat="server"/>

</form>
</body>
</html>

<!--End ASPX page-->

