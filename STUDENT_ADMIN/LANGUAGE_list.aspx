<!--ASPX page @1-19497DD7-->
    <%@ Page language="vb" CodeFile="LANGUAGE_list.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.LANGUAGE_list.LANGUAGE_listPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.LANGUAGE_list" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>LANGUAGE</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/> </p>
<p>

  <span id="LANGUAGE1Holder" runat="server">
    


  <table class="MainTable" cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>
            <p>Search&nbsp; Description</p>
            </th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="LANGUAGE1Error" visible="False" runat="server">
  
          <tr id="<%=PageVariables.Get("@error-block")%>" class="Error">
            <td colspan="2"><asp:Label ID="LANGUAGE1ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>Description</th>
 
            <td><asp:TextBox id="LANGUAGE1s_keyword" maxlength="20"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td><a id="LANGUAGE1ClearParameters" href="" runat="server"  >Clear</a></td> 
            <td style="TEXT-ALIGN: right">
              <input id='LANGUAGE1Button_DoSearch' type="submit" class="Button" value="Search" OnServerClick='LANGUAGE1_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>
</p>

<asp:repeater id="LANGUAGERepeater" OnItemCommand="LANGUAGEItemCommand" OnItemDataBound="LANGUAGEItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>List of LANGUAGE </th>
 
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>&nbsp;</th>
 
          <th>&nbsp;<a id="LANGUAGELANGUAGE_Insert" href="" runat="server"  >Add New</a></th>
 
          <th>&nbsp;</th>
 
          <th>&nbsp;</th>
        </tr>
 
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_LANG_CODESorter" field="Sorter_LANG_CODE" OwnerState="<%# LANGUAGEData.SortField.ToString()%>" OwnerDir="<%# LANGUAGEData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LANG_CODESort" runat="server">LANG CODE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LANG_DESCRIPTIONSorter" field="Sorter_LANG_DESCRIPTION" OwnerState="<%# LANGUAGEData.SortField.ToString()%>" OwnerDir="<%# LANGUAGEData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LANG_DESCRIPTIONSort" runat="server">LANG DESCRIPTION</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# LANGUAGEData.SortField.ToString()%>" OwnerDir="<%# LANGUAGEData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# LANGUAGEData.SortField.ToString()%>" OwnerDir="<%# LANGUAGEData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="TEXT-ALIGN: right"><a id="LANGUAGELANG_CODE" href="" runat="server"  ><%#(CType(Container.DataItem,LANGUAGEItem)).LANG_CODE.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="LANGUAGELANG_DESCRIPTION" Text='<%# Server.HtmlEncode((CType(Container.DataItem,LANGUAGEItem)).LANG_DESCRIPTION.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="LANGUAGELAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,LANGUAGEItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="LANGUAGELAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,LANGUAGEItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <AlternatingItemTemplate>
	
        <tr class="AltRow">
          <td style="TEXT-ALIGN: right"><a id="LANGUAGEAlt_LANG_CODE" href="" runat="server"  ><%#(CType(Container.DataItem,LANGUAGEItem)).Alt_LANG_CODE.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="LANGUAGEAlt_LANG_DESCRIPTION" Text='<%# Server.HtmlEncode((CType(Container.DataItem,LANGUAGEItem)).Alt_LANG_DESCRIPTION.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="LANGUAGEAlt_LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,LANGUAGEItem)).Alt_LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="LANGUAGEAlt_LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,LANGUAGEItem)).Alt_LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
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
          <td colspan="4">
            
<CC:Navigator id="Navigator1Navigator" MaxPage="<%# LANGUAGEData.PagesCount%>" PageSize="<%# LANGUAGEData.RecordsPerPage%>" PageNumber="<%# LANGUAGEData.PageNumber%>" runat="server"><span class="Navigator">Records per page 
            <CC:PageSizer AutoPostBack="true" runat="server" />
 
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="Navigator1First" runat="server">First</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="FirstOff" runat="server">First </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="Navigator1Prev" runat="server">Prev</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOff" runat="server">Prev </CC:NavigatorItem>&nbsp; 
            
<CC:Pager id="Navigator1Pager" Style="Centered" PagerSize="8" runat="server">
            <PageOnTemplate><asp:LinkButton runat="server"><%# (CType(Container,PagerItem)).PageNumber.ToString() %></asp:LinkButton>&nbsp;</PageOnTemplate>
            <PageOffTemplate><%# (CType(Container,PagerItem)).PageNumber.ToString() %>&nbsp;</PageOffTemplate></CC:Pager>of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="Navigator1Next" runat="server">Next</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="NextOff" runat="server">Next </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="Navigator1Last" runat="server">Last</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOff" runat="server">Last </CC:NavigatorItem></span></CC:Navigator>
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

