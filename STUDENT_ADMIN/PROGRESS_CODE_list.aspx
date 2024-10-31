<!--ASPX page @1-2B2FF1D2-->
    <%@ Page language="vb" CodeFile="PROGRESS_CODE_list.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.PROGRESS_CODE_list.PROGRESS_CODE_listPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.PROGRESS_CODE_list" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="text/html; charset=windows-1252">
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0">

<title>PROGRESS CODE</title>

<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<DECV_PROD2007:Header id="Header" runat="server"/>


<asp:repeater id="PROGRESS_CODERepeater" OnItemCommand="PROGRESS_CODEItemCommand" OnItemDataBound="PROGRESS_CODEItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      <table cellspacing="0" cellpadding="0" border="0" class="Header">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          <th>List of PROGRESS CODE </th>
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_PROGRESS_CODESorter" field="Sorter_PROGRESS_CODE" OwnerState="<%# PROGRESS_CODEData.SortField.ToString()%>" OwnerDir="<%# PROGRESS_CODEData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_PROGRESS_CODESort" runat="server">PROGRESS CODE</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_PROGRESS_CODE_TITLESorter" field="Sorter_PROGRESS_CODE_TITLE" OwnerState="<%# PROGRESS_CODEData.SortField.ToString()%>" OwnerDir="<%# PROGRESS_CODEData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_PROGRESS_CODE_TITLESort" runat="server">TITLE</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_STATUSSorter" field="Sorter_STATUS" OwnerState="<%# PROGRESS_CODEData.SortField.ToString()%>" OwnerDir="<%# PROGRESS_CODEData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STATUSSort" runat="server">STATUS</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# PROGRESS_CODEData.SortField.ToString()%>" OwnerDir="<%# PROGRESS_CODEData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# PROGRESS_CODEData.SortField.ToString()%>" OwnerDir="<%# PROGRESS_CODEData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
        </tr>
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td><a id="PROGRESS_CODEPROGRESS_CODE" href="" runat="server"  ><%#(CType(Container.DataItem,PROGRESS_CODEItem)).PROGRESS_CODE.GetFormattedValue()%></a>&nbsp;</td>
          <td><asp:Literal id="PROGRESS_CODEPROGRESS_CODE_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,PROGRESS_CODEItem)).PROGRESS_CODE_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="PROGRESS_CODESTATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,PROGRESS_CODEItem)).STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="PROGRESS_CODELAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,PROGRESS_CODEItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="PROGRESS_CODELAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,PROGRESS_CODEItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
        
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <AlternatingItemTemplate>
	
        <tr class="AltRow">
          <td><a id="PROGRESS_CODEAlt_PROGRESS_CODE" href="" runat="server"  ><%#(CType(Container.DataItem,PROGRESS_CODEItem)).Alt_PROGRESS_CODE.GetFormattedValue()%></a>&nbsp;</td>
          <td><asp:Literal id="PROGRESS_CODEAlt_PROGRESS_CODE_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,PROGRESS_CODEItem)).Alt_PROGRESS_CODE_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="PROGRESS_CODEAlt_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,PROGRESS_CODEItem)).Alt_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="PROGRESS_CODEAlt_LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,PROGRESS_CODEItem)).Alt_LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="PROGRESS_CODEAlt_LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,PROGRESS_CODEItem)).Alt_LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
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
          <td colspan="5"><a id="PROGRESS_CODEPROGRESS_CODE_Insert" href="" runat="server"  >Add New</a>&nbsp;
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# PROGRESS_CODEData.PagesCount%>" PageSize="<%# PROGRESS_CODEData.RecordsPerPage%>" PageNumber="<%# PROGRESS_CODEData.PageNumber%>" runat="server">
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

