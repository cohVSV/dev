<!--ASPX page @1-95EA4391-->
    <%@ Page language="vb" CodeFile="WITHDRAWAL_EXIT_list.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.WITHDRAWAL_EXIT_list.WITHDRAWAL_EXIT_listPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.WITHDRAWAL_EXIT_list" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 4.1.00.032" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>WITHDRAWAL EXIT DESTINATION</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p align="center"><a id="Link_AddNew" href="" class="Button" runat="server"  >Add New</a></p>

<asp:repeater id="WITHDRAWAL_EXIT_DESTINATIRepeater" OnItemCommand="WITHDRAWAL_EXIT_DESTINATIItemCommand" OnItemDataBound="WITHDRAWAL_EXIT_DESTINATIItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
          <th>List of WITHDRAWAL EXIT DESTINATION</th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>Detail</th>
 
          <th>
          <CC:Sorter id="Sorter_WD_DEST_IDSorter" field="Sorter_WD_DEST_ID" OwnerState="<%# WITHDRAWAL_EXIT_DESTINATIData.SortField.ToString()%>" OwnerDir="<%# WITHDRAWAL_EXIT_DESTINATIData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_WD_DEST_IDSort" runat="server">WD DEST ID</asp:LinkButton></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_EXIT_DESTINATION_DESCRIPTIONSorter" field="Sorter_EXIT_DESTINATION_DESCRIPTION" OwnerState="<%# WITHDRAWAL_EXIT_DESTINATIData.SortField.ToString()%>" OwnerDir="<%# WITHDRAWAL_EXIT_DESTINATIData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_EXIT_DESTINATION_DESCRIPTIONSort" runat="server">EXIT DESTINATION DESCRIPTION</asp:LinkButton></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_DISPLAY_ORDERSorter" field="Sorter_DISPLAY_ORDER" OwnerState="<%# WITHDRAWAL_EXIT_DESTINATIData.SortField.ToString()%>" OwnerDir="<%# WITHDRAWAL_EXIT_DESTINATIData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_DISPLAY_ORDERSort" runat="server">DISPLAY ORDER</asp:LinkButton></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_GROUPINGSorter" field="Sorter_GROUPING" OwnerState="<%# WITHDRAWAL_EXIT_DESTINATIData.SortField.ToString()%>" OwnerDir="<%# WITHDRAWAL_EXIT_DESTINATIData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_GROUPINGSort" runat="server">GROUPING</asp:LinkButton></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# WITHDRAWAL_EXIT_DESTINATIData.SortField.ToString()%>" OwnerDir="<%# WITHDRAWAL_EXIT_DESTINATIData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# WITHDRAWAL_EXIT_DESTINATIData.SortField.ToString()%>" OwnerDir="<%# WITHDRAWAL_EXIT_DESTINATIData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td><a id="WITHDRAWAL_EXIT_DESTINATIDetail" href="" runat="server"  >edit</a>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="WITHDRAWAL_EXIT_DESTINATIWD_DEST_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_EXIT_DESTINATIItem)).WD_DEST_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="WITHDRAWAL_EXIT_DESTINATIEXIT_DESTINATION_DESCRIPTION" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_EXIT_DESTINATIItem)).EXIT_DESTINATION_DESCRIPTION.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="WITHDRAWAL_EXIT_DESTINATIDISPLAY_ORDER" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_EXIT_DESTINATIItem)).DISPLAY_ORDER.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="WITHDRAWAL_EXIT_DESTINATIGROUPING" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_EXIT_DESTINATIItem)).GROUPING.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="WITHDRAWAL_EXIT_DESTINATILAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_EXIT_DESTINATIItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="WITHDRAWAL_EXIT_DESTINATILAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_EXIT_DESTINATIItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <AlternatingItemTemplate>
	
        <tr class="AltRow">
          <td><a id="WITHDRAWAL_EXIT_DESTINATIAlt_Detail" href="" runat="server"  >edit</a>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="WITHDRAWAL_EXIT_DESTINATIAlt_WD_DEST_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_EXIT_DESTINATIItem)).Alt_WD_DEST_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="WITHDRAWAL_EXIT_DESTINATIAlt_EXIT_DESTINATION_DESCRIPTION" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_EXIT_DESTINATIItem)).Alt_EXIT_DESTINATION_DESCRIPTION.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="WITHDRAWAL_EXIT_DESTINATIAlt_DISPLAY_ORDER" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_EXIT_DESTINATIItem)).Alt_DISPLAY_ORDER.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="WITHDRAWAL_EXIT_DESTINATIAlt_GROUPING" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_EXIT_DESTINATIItem)).Alt_GROUPING.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="WITHDRAWAL_EXIT_DESTINATIAlt_LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_EXIT_DESTINATIItem)).Alt_LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="WITHDRAWAL_EXIT_DESTINATIAlt_LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,WITHDRAWAL_EXIT_DESTINATIItem)).Alt_LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="AltIterationContainer" runat="server"/>
  </AlternatingItemTemplate>
  <FooterTemplate>
	
        
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="7">No Withdrawal Exit Destination Details found</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="7"><a id="WITHDRAWAL_EXIT_DESTINATIWITHDRAWAL_EXIT_DESTINATI_Insert" href="" runat="server"  >Add New</a>&nbsp; 
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# WITHDRAWAL_EXIT_DESTINATIData.PagesCount%>" PageSize="<%# WITHDRAWAL_EXIT_DESTINATIData.RecordsPerPage%>" PageNumber="<%# WITHDRAWAL_EXIT_DESTINATIData.PageNumber%>" runat="server">
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server">|&lt;</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server">&lt;&lt;</asp:LinkButton> </CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %> of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server">&gt;&gt;</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server">&gt;|</asp:LinkButton> </CC:NavigatorItem></CC:Navigator>
&nbsp;</td>
        </tr>
      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
<br>

</form>
</body>
</html>

<!--End ASPX page-->

