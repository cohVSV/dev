<!--ASPX page @1-0217E7C1-->
    <%@ Page language="vb" CodeFile="REGION_list.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.REGION_list.REGION_listPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.REGION_list" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>REGION</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<DECV_PROD2007:Header id="Header" runat="server"/> 
<div align="center">
  
<asp:repeater id="REGIONRepeater" OnItemCommand="REGIONItemCommand" OnItemDataBound="REGIONItemDataBound" runat="server">
  <HeaderTemplate>
	
  <div align="left">
    <table border="0" cellspacing="0" cellpadding="0" align="center">
      <tr>
        <td valign="top">
          <table class="Header" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
              <th>List of REGIONS </th>
 
              <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
            </tr>
          </table>
 
          <table class="Grid" cellspacing="0" cellpadding="0">
            <tr class="Caption">
              <th>&nbsp;</th>
 
              <th>
              <CC:Sorter id="Sorter_REGION_IDSorter" field="Sorter_REGION_ID" OwnerState="<%# REGIONData.SortField.ToString()%>" OwnerDir="<%# REGIONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_REGION_IDSort" runat="server">ID</asp:LinkButton> 
              <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
              <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
              <th>
              <CC:Sorter id="Sorter_REGION_NAMESorter" field="Sorter_REGION_NAME" OwnerState="<%# REGIONData.SortField.ToString()%>" OwnerDir="<%# REGIONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_REGION_NAMESort" runat="server">NAME</asp:LinkButton> 
              <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
              <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
              <th>
              <CC:Sorter id="Sorter_PHONESorter" field="Sorter_PHONE" OwnerState="<%# REGIONData.SortField.ToString()%>" OwnerDir="<%# REGIONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_PHONESort" runat="server">PHONE</asp:LinkButton> 
              <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
              <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
              <th>
              <CC:Sorter id="Sorter_FAXSorter" field="Sorter_FAX" OwnerState="<%# REGIONData.SortField.ToString()%>" OwnerDir="<%# REGIONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FAXSort" runat="server">FAX</asp:LinkButton> 
              <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
              <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
              <th>
              <CC:Sorter id="Sorter_EMAIL_ADDRESSSorter" field="Sorter_EMAIL_ADDRESS" OwnerState="<%# REGIONData.SortField.ToString()%>" OwnerDir="<%# REGIONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_EMAIL_ADDRESSSort" runat="server">EMAIL ADDRESS</asp:LinkButton> 
              <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
              <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
              <th>
              <CC:Sorter id="Sorter_SUBURB_TOWNSorter" field="Sorter_SUBURB_TOWN" OwnerState="<%# REGIONData.SortField.ToString()%>" OwnerDir="<%# REGIONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBURB_TOWNSort" runat="server">SUBURB TOWN</asp:LinkButton> 
              <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
              <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
              <th>Status (1=Active)&nbsp;</th>
            </tr>
 
            
  </HeaderTemplate>
  <ItemTemplate>
            <tr class="Row">
              <td style="TEXT-ALIGN: right"><a id="REGIONREGION_ID" href="" runat="server"  >view/edit</a>&nbsp;</td> 
              <td style="TEXT-ALIGN: right"><asp:Literal id="REGIONID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REGIONItem)).ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
              <td><asp:Literal id="REGIONREGION_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REGIONItem)).REGION_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
              <td><asp:Literal id="REGIONPHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REGIONItem)).PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
              <td><asp:Literal id="REGIONFAX" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REGIONItem)).FAX.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
              <td><asp:Literal id="REGIONEMAIL_ADDRESS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REGIONItem)).EMAIL_ADDRESS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
              <td><asp:Literal id="REGIONSUBURB_TOWN" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REGIONItem)).SUBURB_TOWN.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
              <td>&nbsp;<asp:Literal id="REGIONSTATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REGIONItem)).STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
            </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <AlternatingItemTemplate>
	
            <tr class="AltRow">
              <td style="TEXT-ALIGN: right"><a id="REGIONAlt_REGION_ID" href="" runat="server"  >view/edit</a>&nbsp;</td> 
              <td style="TEXT-ALIGN: right"><asp:Literal id="REGIONID1" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REGIONItem)).ID1.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
              <td><asp:Literal id="REGIONAlt_REGION_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REGIONItem)).Alt_REGION_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
              <td><asp:Literal id="REGIONAlt_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REGIONItem)).Alt_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
              <td><asp:Literal id="REGIONAlt_FAX" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REGIONItem)).Alt_FAX.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
              <td><asp:Literal id="REGIONAlt_EMAIL_ADDRESS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REGIONItem)).Alt_EMAIL_ADDRESS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
              <td><asp:Literal id="REGIONAlt_SUBURB_TOWN" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REGIONItem)).Alt_SUBURB_TOWN.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
              <td>&nbsp;<asp:Literal id="REGIONSTATUS1" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REGIONItem)).STATUS1.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
            </tr>
 
	<asp:PlaceHolder id="AltIterationContainer" runat="server"/>
  </AlternatingItemTemplate>
  <FooterTemplate>
	
            
            
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
            <tr class="NoRecords">
              <td colspan="8">No records</td>
            </tr>
            
  </asp:PlaceHolder>

            <tr class="Footer">
              <td colspan="8"><a id="REGIONREGION_Insert" href="" runat="server"  >Add New</a>&nbsp; 
                
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# REGIONData.PagesCount%>" PageSize="<%# REGIONData.RecordsPerPage%>" PageNumber="<%# REGIONData.PageNumber%>" runat="server">
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
  </div>
  <div align="left">
  </div>
  
  </FooterTemplate>
</asp:repeater>

</div>
<br>
<DECV_PROD2007:Footer id="Footer" runat="server"/> 

</form>
</body>
</html>

<!--End ASPX page-->

