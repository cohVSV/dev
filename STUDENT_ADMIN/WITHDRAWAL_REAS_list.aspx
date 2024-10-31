<!--ASPX page @1-D0552493-->
    <%@ Page language="vb" CodeFile="WITHDRAWAL_REAS_list.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.WITHDRAWAL_REAS_list.WITHDRAWAL_REAS_listPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.WITHDRAWAL_REAS_list" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="text/html; charset=windows-1252">
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0">

<title>WITHDRAWAL REASON</title>

<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<DECV_PROD2007:Header id="Header" runat="server"/>


<asp:repeater id="WITHDRAWAL_REASONRepeater" OnItemCommand="WITHDRAWAL_REASONItemCommand" OnItemDataBound="WITHDRAWAL_REASONItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      <table cellspacing="0" cellpadding="0" border="0" class="Header">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          <th>List of WITHDRAWAL REASON </th>
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_WITHDRAWAL_REASON_IDSorter" field="Sorter_WITHDRAWAL_REASON_ID" OwnerState="<%# WITHDRAWAL_REASONData.SortField.ToString()%>" OwnerDir="<%# WITHDRAWAL_REASONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_WITHDRAWAL_REASON_IDSort" runat="server">ID</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_WITHDRAWAL_REASONSorter" field="Sorter_WITHDRAWAL_REASON" OwnerState="<%# WITHDRAWAL_REASONData.SortField.ToString()%>" OwnerDir="<%# WITHDRAWAL_REASONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_WITHDRAWAL_REASONSort" runat="server">WITHDRAWAL REASON</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_STATUSSorter" field="Sorter_STATUS" OwnerState="<%# WITHDRAWAL_REASONData.SortField.ToString()%>" OwnerDir="<%# WITHDRAWAL_REASONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STATUSSort" runat="server">STATUS</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# WITHDRAWAL_REASONData.SortField.ToString()%>" OwnerDir="<%# WITHDRAWAL_REASONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# WITHDRAWAL_REASONData.SortField.ToString()%>" OwnerDir="<%# WITHDRAWAL_REASONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
        </tr>
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="text-align:right;"><a id="WITHDRAWAL_REASONWITHDRAWAL_REASON_ID" href="" runat="server"  ><%#(CType(Container.DataItem,WITHDRAWAL_REASONItem)).WITHDRAWAL_REASON_ID.GetFormattedValue()%></a>&nbsp;</td>
          <td><asp:Literal id="WITHDRAWAL_REASONWITHDRAWAL_REASON" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_REASONItem)).WITHDRAWAL_REASON.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="WITHDRAWAL_REASONSTATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_REASONItem)).STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="WITHDRAWAL_REASONLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_REASONItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="WITHDRAWAL_REASONLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_REASONItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
        
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <AlternatingItemTemplate>
	
        <tr class="AltRow">
          <td style="text-align:right;"><a id="WITHDRAWAL_REASONAlt_WITHDRAWAL_REASON_ID" href="" runat="server"  ><%#(CType(Container.DataItem,WITHDRAWAL_REASONItem)).Alt_WITHDRAWAL_REASON_ID.GetFormattedValue()%></a>&nbsp;</td>
          <td><asp:Literal id="WITHDRAWAL_REASONAlt_WITHDRAWAL_REASON" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_REASONItem)).Alt_WITHDRAWAL_REASON.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="WITHDRAWAL_REASONAlt_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_REASONItem)).Alt_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="WITHDRAWAL_REASONAlt_LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_REASONItem)).Alt_LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="WITHDRAWAL_REASONAlt_LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_REASONItem)).Alt_LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
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
          <td colspan="5"><a id="WITHDRAWAL_REASONWITHDRAWAL_REASON_Insert" href="" runat="server"  >Add New</a>&nbsp;
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# WITHDRAWAL_REASONData.PagesCount%>" PageSize="<%# WITHDRAWAL_REASONData.RecordsPerPage%>" PageNumber="<%# WITHDRAWAL_REASONData.PageNumber%>" runat="server">
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

