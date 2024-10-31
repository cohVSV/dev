<!--ASPX page @1-D947E876-->
    <%@ Page language="vb" CodeFile="SCHOOL_list.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.SCHOOL_list.SCHOOL_listPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.SCHOOL_list" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>SCHOOL</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<DECV_PROD2007:Header id="Header" runat="server"/> <br>
<br>

  <span id="SCHOOLSearchHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Search SCHOOL </th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="SCHOOLSearchError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="SCHOOLSearchErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>Keyword</th>
 
            <td><asp:TextBox id="SCHOOLSearchs_keyword" maxlength="20"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th colspan="2"><em>(wildcard of School ID, Name or Region ID)</em>&nbsp;&nbsp;</th>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;School Type</th>
 
            <td>
              <select id="SCHOOLSearchlbSCHOOL_TYPE"  runat="server"></select>
 &nbsp;&nbsp;<em>(optional)</em></td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">
              <input id='SCHOOLSearchButton_DoSearch' type="submit" class="Button" value="Search" OnServerClick='SCHOOLSearch_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  
<div align="center">
  
<asp:repeater id="SCHOOLRepeater" OnItemCommand="SCHOOLItemCommand" OnItemDataBound="SCHOOLItemDataBound" runat="server">
  <HeaderTemplate>
	
  <p align="right"><a id="SCHOOLlink_NewSchool" href="" class="Button" runat="server"  >Add new</a><br>
  </p>
  <div align="left">
    <table cellspacing="0" cellpadding="0" align="center" border="0">
      <tr>
        <td valign="top">
          <table class="Header" cellspacing="0" cellpadding="0" border="0">
            <tr>
              <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
              <th>List of SCHOOLS </th>
 
              <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
            </tr>
          </table>
 
          <table class="Grid" cellspacing="0" cellpadding="0">
            <tr class="Caption">
              <th>
              <CC:Sorter id="Sorter_SCHOOL_IDSorter" field="Sorter_SCHOOL_ID" OwnerState="<%# SCHOOLData.SortField.ToString()%>" OwnerDir="<%# SCHOOLData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SCHOOL_IDSort" runat="server">SCHOOL ID</asp:LinkButton> 
              <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
              <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
              <th>
              <CC:Sorter id="Sorter_SCHOOL_NAMESorter" field="Sorter_SCHOOL_NAME" OwnerState="<%# SCHOOLData.SortField.ToString()%>" OwnerDir="<%# SCHOOLData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SCHOOL_NAMESort" runat="server">NAME</asp:LinkButton> 
              <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
              <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
              <th>&nbsp;Type</th>
 
              <th>
              <CC:Sorter id="Sorter_REGION_IDSorter" field="Sorter_REGION_ID" OwnerState="<%# SCHOOLData.SortField.ToString()%>" OwnerDir="<%# SCHOOLData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_REGION_IDSort" runat="server">REGION ID</asp:LinkButton> 
              <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
              <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
              <th>
              <CC:Sorter id="Sorter_METRO_CATEGORYSorter" field="Sorter_METRO_CATEGORY" OwnerState="<%# SCHOOLData.SortField.ToString()%>" OwnerDir="<%# SCHOOLData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_METRO_CATEGORYSort" runat="server">METRO CATEGORY</asp:LinkButton> 
              <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
              <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
              <th>
              <CC:Sorter id="Sorter_STATUSSorter" field="Sorter_STATUS" OwnerState="<%# SCHOOLData.SortField.ToString()%>" OwnerDir="<%# SCHOOLData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STATUSSort" runat="server">Active?</asp:LinkButton> 
              <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
              <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
              <th>
              <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# SCHOOLData.SortField.ToString()%>" OwnerDir="<%# SCHOOLData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton> 
              <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
              <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
              <th>
              <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# SCHOOLData.SortField.ToString()%>" OwnerDir="<%# SCHOOLData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton> 
              <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
              <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
            </tr>
 
            
  </HeaderTemplate>
  <ItemTemplate>
            <tr class="Row">
              <td style="TEXT-ALIGN: right"><a id="SCHOOLSCHOOL_ID" href="" runat="server"  ><%#(CType(Container.DataItem,SCHOOLItem)).SCHOOL_ID.GetFormattedValue()%></a>&nbsp;</td> 
              <td><asp:Literal id="SCHOOLSCHOOL_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SCHOOLItem)).SCHOOL_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
              <td>&nbsp;<asp:Literal id="SCHOOLSCHOOL_TYPE_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SCHOOLItem)).SCHOOL_TYPE_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
              <td style="TEXT-ALIGN: right"><asp:Literal id="SCHOOLREGION_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SCHOOLItem)).REGION_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
              <td><asp:Literal id="SCHOOLMETRO_CATEGORY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SCHOOLItem)).METRO_CATEGORY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
              <td><asp:Literal id="SCHOOLSTATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SCHOOLItem)).STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
              <td><asp:Literal id="SCHOOLLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SCHOOLItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
              <td><asp:Literal id="SCHOOLLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SCHOOLItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
            </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <SeparatorTemplate>
	
            <tr class="Separator">
              <td colspan="8"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
            </tr>
            
  </SeparatorTemplate>
  <FooterTemplate>
	
            
            
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
            <tr class="NoRecords">
              <td colspan="8">No records found. </td>
            </tr>
            
  </asp:PlaceHolder>

            <tr class="Footer">
              <td colspan="8"><a id="SCHOOLlink_AnotherNewSchool" href="" runat="server"  >Add new</a>&nbsp;&nbsp;&nbsp; 
                
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# SCHOOLData.PagesCount%>" PageSize="<%# SCHOOLData.RecordsPerPage%>" PageNumber="<%# SCHOOLData.PageNumber%>" runat="server">
                <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server">First</asp:LinkButton> </CC:NavigatorItem>
                <CC:NavigatorItem type="FirstOff" runat="server">First </CC:NavigatorItem>
                <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server">Prev</asp:LinkButton> </CC:NavigatorItem>
                <CC:NavigatorItem type="PrevOff" runat="server">Prev </CC:NavigatorItem>&nbsp; 
                
<CC:Pager id="NavigatorPager" Style="Centered" PagerSize="10" runat="server">
                <PageOnTemplate><asp:LinkButton runat="server"><%# (CType(Container,PagerItem)).PageNumber.ToString() %></asp:LinkButton>&nbsp;</PageOnTemplate>
                <PageOffTemplate><%# (CType(Container,PagerItem)).PageNumber.ToString() %>&nbsp;</PageOffTemplate></CC:Pager>of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
                <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server">Next</asp:LinkButton> </CC:NavigatorItem>
                <CC:NavigatorItem type="NextOff" runat="server">Next </CC:NavigatorItem>
                <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server">Last</asp:LinkButton> </CC:NavigatorItem>
                <CC:NavigatorItem type="LastOff" runat="server">Last </CC:NavigatorItem></CC:Navigator>
</td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  </div>
  <div align="left">
  </div>
  
  </FooterTemplate>
</asp:repeater>

</div>
<div align="center">
</div>
<br>
<br>
&nbsp;

</form>
</body>
</html>

<!--End ASPX page-->

