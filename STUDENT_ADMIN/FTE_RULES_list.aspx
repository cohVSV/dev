<!--ASPX page @1-D4E67A4D-->
    <%@ Page language="vb" CodeFile="FTE_RULES_list.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.FTE_RULES_list.FTE_RULES_listPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.FTE_RULES_list" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="text/html; charset=windows-1252">
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0">

<title>FTE RULES</title>

<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<DECV_PROD2007:Header id="Header" runat="server"/>


<asp:repeater id="FTE_RULESRepeater" OnItemCommand="FTE_RULESItemCommand" OnItemDataBound="FTE_RULESItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      <table cellspacing="0" cellpadding="0" border="0" class="Header">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          <th>List of FTE RULES </th>
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_FROM_YEAR_LEVELSorter" field="Sorter_FROM_YEAR_LEVEL" OwnerState="<%# FTE_RULESData.SortField.ToString()%>" OwnerDir="<%# FTE_RULESData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FROM_YEAR_LEVELSort" runat="server">FROM YEAR LEVEL</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_TO_YEAR_LEVELSorter" field="Sorter_TO_YEAR_LEVEL" OwnerState="<%# FTE_RULESData.SortField.ToString()%>" OwnerDir="<%# FTE_RULESData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_TO_YEAR_LEVELSort" runat="server">TO YEAR LEVEL</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_UNITSorter" field="Sorter_UNIT" OwnerState="<%# FTE_RULESData.SortField.ToString()%>" OwnerDir="<%# FTE_RULESData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_UNITSort" runat="server">UNIT</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_FTESorter" field="Sorter_FTE" OwnerState="<%# FTE_RULESData.SortField.ToString()%>" OwnerDir="<%# FTE_RULESData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FTESort" runat="server">FTE</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_FULLTIME_FLAGSorter" field="Sorter_FULLTIME_FLAG" OwnerState="<%# FTE_RULESData.SortField.ToString()%>" OwnerDir="<%# FTE_RULESData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FULLTIME_FLAGSort" runat="server">FULLTIME FLAG</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# FTE_RULESData.SortField.ToString()%>" OwnerDir="<%# FTE_RULESData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# FTE_RULESData.SortField.ToString()%>" OwnerDir="<%# FTE_RULESData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
        </tr>
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="text-align:right;"><a id="FTE_RULESFROM_YEAR_LEVEL" href="" runat="server"  ><%#(CType(Container.DataItem,FTE_RULESItem)).FROM_YEAR_LEVEL.GetFormattedValue()%></a>&nbsp;</td>
          <td style="text-align:right;"><asp:Literal id="FTE_RULESTO_YEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,FTE_RULESItem)).TO_YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td style="text-align:right;"><asp:Literal id="FTE_RULESUNIT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,FTE_RULESItem)).UNIT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td style="text-align:right;"><asp:Literal id="FTE_RULESFTE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,FTE_RULESItem)).FTE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="FTE_RULESFULLTIME_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,FTE_RULESItem)).FULLTIME_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="FTE_RULESLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,FTE_RULESItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="FTE_RULESLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,FTE_RULESItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
        
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <AlternatingItemTemplate>
	
        <tr class="AltRow">
          <td style="text-align:right;"><a id="FTE_RULESAlt_FROM_YEAR_LEVEL" href="" runat="server"  ><%#(CType(Container.DataItem,FTE_RULESItem)).Alt_FROM_YEAR_LEVEL.GetFormattedValue()%></a>&nbsp;</td>
          <td style="text-align:right;"><asp:Literal id="FTE_RULESAlt_TO_YEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,FTE_RULESItem)).Alt_TO_YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td style="text-align:right;"><asp:Literal id="FTE_RULESAlt_UNIT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,FTE_RULESItem)).Alt_UNIT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td style="text-align:right;"><asp:Literal id="FTE_RULESAlt_FTE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,FTE_RULESItem)).Alt_FTE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="FTE_RULESAlt_FULLTIME_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,FTE_RULESItem)).Alt_FULLTIME_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="FTE_RULESAlt_LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,FTE_RULESItem)).Alt_LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="FTE_RULESAlt_LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,FTE_RULESItem)).Alt_LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
        
	<asp:PlaceHolder id="AltIterationContainer" runat="server"/>
  </AlternatingItemTemplate>
  <FooterTemplate>
	
        
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="7">No records</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="7"><a id="FTE_RULESFTE_RULES_Insert" href="" runat="server"  >Add New</a>&nbsp;
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# FTE_RULESData.PagesCount%>" PageSize="<%# FTE_RULESData.RecordsPerPage%>" PageNumber="<%# FTE_RULESData.PageNumber%>" runat="server">
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

