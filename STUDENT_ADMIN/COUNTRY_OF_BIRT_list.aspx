<!--ASPX page @1-04511B20-->
    <%@ Page language="vb" CodeFile="COUNTRY_OF_BIRT_list.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.COUNTRY_OF_BIRT_list.COUNTRY_OF_BIRT_listPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.COUNTRY_OF_BIRT_list" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="text/html; charset=windows-1252">
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0">

<title>COUNTRY OF BIRTH</title>

<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<DECV_PROD2007:Header id="Header" runat="server"/>


  <span id="COUNTRY_OF_BIRTHSearchHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table cellspacing="0" cellpadding="0" border="0" class="Header">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
            <th>Search COUNTRY OF BIRTH </th>
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="COUNTRY_OF_BIRTHSearchError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="COUNTRY_OF_BIRTHSearchErrorLabel" runat="server"/></td> 
          </tr>
 
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>Keyword</th>
 
            <td><asp:TextBox id="COUNTRY_OF_BIRTHSearchs_keyword" maxlength="20" Columns="20"	runat="server"/></td> 
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">
              <input id='COUNTRY_OF_BIRTHSearchButton_DoSearch' type="submit" value="Search" class="Button" OnServerClick='COUNTRY_OF_BIRTHSearch_Search' runat="server"/></td> 
          </tr>
        </table>
 </td> 
    </tr>
  </table>



  </span>
  <br>

<asp:repeater id="COUNTRY_OF_BIRTHRepeater" OnItemCommand="COUNTRY_OF_BIRTHItemCommand" OnItemDataBound="COUNTRY_OF_BIRTHItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      <table cellspacing="0" cellpadding="0" border="0" class="Header">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          <th>List of COUNTRY OF BIRTH </th>
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_COUNTRY_IDSorter" field="Sorter_COUNTRY_ID" OwnerState="<%# COUNTRY_OF_BIRTHData.SortField.ToString()%>" OwnerDir="<%# COUNTRY_OF_BIRTHData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_COUNTRY_IDSort" runat="server">COUNTRY ID</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_COUNTRY_NAMESorter" field="Sorter_COUNTRY_NAME" OwnerState="<%# COUNTRY_OF_BIRTHData.SortField.ToString()%>" OwnerDir="<%# COUNTRY_OF_BIRTHData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_COUNTRY_NAMESort" runat="server">COUNTRY NAME</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# COUNTRY_OF_BIRTHData.SortField.ToString()%>" OwnerDir="<%# COUNTRY_OF_BIRTHData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# COUNTRY_OF_BIRTHData.SortField.ToString()%>" OwnerDir="<%# COUNTRY_OF_BIRTHData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton>
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
        </tr>
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="text-align:right;"><a id="COUNTRY_OF_BIRTHCOUNTRY_ID" href="" runat="server"  ><%#(CType(Container.DataItem,COUNTRY_OF_BIRTHItem)).COUNTRY_ID.GetFormattedValue()%></a>&nbsp;</td>
          <td><asp:Literal id="COUNTRY_OF_BIRTHCOUNTRY_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,COUNTRY_OF_BIRTHItem)).COUNTRY_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="COUNTRY_OF_BIRTHLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,COUNTRY_OF_BIRTHItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="COUNTRY_OF_BIRTHLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,COUNTRY_OF_BIRTHItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
        
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <AlternatingItemTemplate>
	
        <tr class="AltRow">
          <td style="text-align:right;"><a id="COUNTRY_OF_BIRTHAlt_COUNTRY_ID" href="" runat="server"  ><%#(CType(Container.DataItem,COUNTRY_OF_BIRTHItem)).Alt_COUNTRY_ID.GetFormattedValue()%></a>&nbsp;</td>
          <td><asp:Literal id="COUNTRY_OF_BIRTHAlt_COUNTRY_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,COUNTRY_OF_BIRTHItem)).Alt_COUNTRY_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="COUNTRY_OF_BIRTHAlt_LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,COUNTRY_OF_BIRTHItem)).Alt_LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          <td><asp:Literal id="COUNTRY_OF_BIRTHAlt_LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,COUNTRY_OF_BIRTHItem)).Alt_LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
        
	<asp:PlaceHolder id="AltIterationContainer" runat="server"/>
  </AlternatingItemTemplate>
  <FooterTemplate>
	
        
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="4">No records</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="4"><a id="COUNTRY_OF_BIRTHCOUNTRY_OF_BIRTH_Insert" href="" runat="server"  >Add New</a>&nbsp;
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# COUNTRY_OF_BIRTHData.PagesCount%>" PageSize="<%# COUNTRY_OF_BIRTHData.RecordsPerPage%>" PageNumber="<%# COUNTRY_OF_BIRTHData.PageNumber%>" runat="server">
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

