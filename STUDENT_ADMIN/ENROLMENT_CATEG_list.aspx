<!--ASPX page @1-95BDBBB2-->
    <%@ Page language="vb" CodeFile="ENROLMENT_CATEG_list.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.ENROLMENT_CATEG_list.ENROLMENT_CATEG_listPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.ENROLMENT_CATEG_list" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0"><meta content="text/html; charset=windows-1252" http-equiv="content-type">

<title>ENROLMENT CATEGORY</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/> </p>
<p align="right"><a id="link_addnewsubcategory" href="" class="Button" runat="server"  >Add New</a></p>

<asp:repeater id="ENROLMENT_CATEGORYRepeater" OnItemCommand="ENROLMENT_CATEGORYItemCommand" OnItemDataBound="ENROLMENT_CATEGORYItemDataBound" runat="server">
  <HeaderTemplate>
	
<table border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
      <table class="Header" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>List of ENROLMENT CATEGORY </th>
 
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_CATEGORY_CODESorter" field="Sorter_CATEGORY_CODE" OwnerState="<%# ENROLMENT_CATEGORYData.SortField.ToString()%>" OwnerDir="<%# ENROLMENT_CATEGORYData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_CATEGORY_CODESort" runat="server">CATEGORY CODE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SUBCATEGORY_CODESorter" field="Sorter_SUBCATEGORY_CODE" OwnerState="<%# ENROLMENT_CATEGORYData.SortField.ToString()%>" OwnerDir="<%# ENROLMENT_CATEGORYData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBCATEGORY_CODESort" runat="server">SUBCATEGORY CODE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SUBCATEGORY_FULL_TITLESorter" field="Sorter_SUBCATEGORY_FULL_TITLE" OwnerState="<%# ENROLMENT_CATEGORYData.SortField.ToString()%>" OwnerDir="<%# ENROLMENT_CATEGORYData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBCATEGORY_FULL_TITLESort" runat="server">SUBCATEGORY FULL TITLE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_STATUSSorter" field="Sorter_STATUS" OwnerState="<%# ENROLMENT_CATEGORYData.SortField.ToString()%>" OwnerDir="<%# ENROLMENT_CATEGORYData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STATUSSort" runat="server">STATUS</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# ENROLMENT_CATEGORYData.SortField.ToString()%>" OwnerDir="<%# ENROLMENT_CATEGORYData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# ENROLMENT_CATEGORYData.SortField.ToString()%>" OwnerDir="<%# ENROLMENT_CATEGORYData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td><a id="ENROLMENT_CATEGORYCATEGORY_CODE" href="" runat="server"  ><%#(CType(Container.DataItem,ENROLMENT_CATEGORYItem)).CATEGORY_CODE.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="ENROLMENT_CATEGORYSUBCATEGORY_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ENROLMENT_CATEGORYItem)).SUBCATEGORY_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="ENROLMENT_CATEGORYSUBCATEGORY_FULL_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ENROLMENT_CATEGORYItem)).SUBCATEGORY_FULL_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="ENROLMENT_CATEGORYSTATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ENROLMENT_CATEGORYItem)).STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="ENROLMENT_CATEGORYLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ENROLMENT_CATEGORYItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="ENROLMENT_CATEGORYLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ENROLMENT_CATEGORYItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <AlternatingItemTemplate>
	
        <tr class="AltRow">
          <td><a id="ENROLMENT_CATEGORYAlt_CATEGORY_CODE" href="" runat="server"  ><%#(CType(Container.DataItem,ENROLMENT_CATEGORYItem)).Alt_CATEGORY_CODE.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="ENROLMENT_CATEGORYAlt_SUBCATEGORY_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ENROLMENT_CATEGORYItem)).Alt_SUBCATEGORY_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="ENROLMENT_CATEGORYAlt_SUBCATEGORY_FULL_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ENROLMENT_CATEGORYItem)).Alt_SUBCATEGORY_FULL_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="ENROLMENT_CATEGORYAlt_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ENROLMENT_CATEGORYItem)).Alt_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="ENROLMENT_CATEGORYAlt_LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ENROLMENT_CATEGORYItem)).Alt_LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="ENROLMENT_CATEGORYAlt_LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ENROLMENT_CATEGORYItem)).Alt_LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="AltIterationContainer" runat="server"/>
  </AlternatingItemTemplate>
  <FooterTemplate>
	
        
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="6">No records for Enrolment Category. So please go away and find something else to do.</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="6"><a id="ENROLMENT_CATEGORYENROLMENT_CATEGORY_Insert" href="" runat="server"  >Add New</a>&nbsp; 
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# ENROLMENT_CATEGORYData.PagesCount%>" PageSize="<%# ENROLMENT_CATEGORYData.RecordsPerPage%>" PageNumber="<%# ENROLMENT_CATEGORYData.PageNumber%>" runat="server">
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server">|&lt;</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server">&lt;&lt;</asp:LinkButton> </CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %> of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server">&gt;&gt;</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server">&gt;|</asp:LinkButton> </CC:NavigatorItem></CC:Navigator>
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

