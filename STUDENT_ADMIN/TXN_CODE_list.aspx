<!--ASPX page @1-6ABE3E55-->
    <%@ Page language="vb" CodeFile="TXN_CODE_list.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.TXN_CODE_list.TXN_CODE_listPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.TXN_CODE_list" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0"><meta name="description" content="Finance Transactions Codes - rebuilt with single page and some nicer bits Oct 2018"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>TXN CODE</title>



<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<DECV_PROD2007:Header id="Header" runat="server"/> 
<p>

<asp:repeater id="TXN_CODERepeater" OnItemCommand="TXN_CODEItemCommand" OnItemDataBound="TXN_CODEItemDataBound" runat="server">
  <HeaderTemplate>
	
<table id="TXN_CODE" class="MainTable" cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>List of Transactions Codes </th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>&nbsp;</th>
 
          <th>
          <CC:Sorter id="Sorter_TXN_CODESorter" field="Sorter_TXN_CODE" OwnerState="<%# TXN_CODEData.SortField.ToString()%>" OwnerDir="<%# TXN_CODEData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_TXN_CODESort" runat="server">TXN CODE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_TXN_TYPESorter" field="Sorter_TXN_TYPE" OwnerState="<%# TXN_CODEData.SortField.ToString()%>" OwnerDir="<%# TXN_CODEData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_TXN_TYPESort" runat="server">TXN TYPE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_CR_DR_FLAGSorter" field="Sorter_CR_DR_FLAG" OwnerState="<%# TXN_CODEData.SortField.ToString()%>" OwnerDir="<%# TXN_CODEData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_CR_DR_FLAGSort" runat="server">CR DR FLAG</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_DESCRIPTIONSorter" field="Sorter_DESCRIPTION" OwnerState="<%# TXN_CODEData.SortField.ToString()%>" OwnerDir="<%# TXN_CODEData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_DESCRIPTIONSort" runat="server">DESCRIPTION</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# TXN_CODEData.SortField.ToString()%>" OwnerDir="<%# TXN_CODEData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# TXN_CODEData.SortField.ToString()%>" OwnerDir="<%# TXN_CODEData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td><a id="TXN_CODEDetail" href="" runat="server"  >edit</a>&nbsp;</td> 
          <td><asp:Literal id="TXN_CODETXN_CODE1" Text='<%# Server.HtmlEncode((CType(Container.DataItem,TXN_CODEItem)).TXN_CODE1.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="TXN_CODETXN_TYPE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,TXN_CODEItem)).TXN_TYPE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="TXN_CODECR_DR_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,TXN_CODEItem)).CR_DR_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="TXN_CODEDESCRIPTION" Text='<%# Server.HtmlEncode((CType(Container.DataItem,TXN_CODEItem)).DESCRIPTION.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="TXN_CODELAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,TXN_CODEItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="TXN_CODELAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,TXN_CODEItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="7">No Transaction Codes found!</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="7"><a id="TXN_CODETXN_CODE_Insert" href="" runat="server"  >Add New</a>&nbsp; 
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# TXN_CODEData.PagesCount%>" PageSize="<%# TXN_CODEData.RecordsPerPage%>" PageNumber="<%# TXN_CODEData.PageNumber%>" runat="server"><span class="Navigator">
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img src="Styles/Blueprint/Images/First.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="FirstOff" runat="server"><img src="Styles/Blueprint/Images/FirstOff.gif"></CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img src="Styles/Blueprint/Images/Prev.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOff" runat="server"><img src="Styles/Blueprint/Images/PrevOff.gif"></CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %> of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img src="Styles/Blueprint/Images/Next.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="NextOff" runat="server"><img src="Styles/Blueprint/Images/NextOff.gif"></CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img src="Styles/Blueprint/Images/Last.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOff" runat="server"><img src="Styles/Blueprint/Images/LastOff.gif"></CC:NavigatorItem></span></CC:Navigator>
&nbsp;</td>
        </tr>
      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
<br>

  <span id="TXN_CODE1Holder" runat="server">
    


  <table class="MainTable" cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Add/Edit Transaction Code</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="TXN_CODE1Error" visible="False" runat="server">
  
          <tr id="ErrorBlock" class="Error">
            <td colspan="2"><asp:Label ID="TXN_CODE1ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>TXN CODE</th>
 
            <td><asp:TextBox id="TXN_CODE1TXN_CODE" maxlength="1" Columns="1"	runat="server"/>&nbsp;<em>(single character, unique)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>TXN TYPE</th>
 
            <td><asp:TextBox id="TXN_CODE1TXN_TYPE" maxlength="20" Columns="20"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>CR DR FLAG</th>
 
            <td>
              <asp:RadioButtonList id="TXN_CODE1CR_DR_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>DESCRIPTION</th>
 
            <td><asp:TextBox id="TXN_CODE1DESCRIPTION" maxlength="60" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td style="TEXT-ALIGN: right" colspan="2">
              <input id='TXN_CODE1Button_Insert' type="submit" class="Button" value="Add Code" OnServerClick='TXN_CODE1_Insert' runat="server"/>
              <input id='TXN_CODE1Button_Update' type="submit" class="Button" value="Update" OnServerClick='TXN_CODE1_Update' runat="server"/>
              <input id='TXN_CODE1Button_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='TXN_CODE1_Cancel' runat="server"/>
  <input id="TXN_CODE1LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="TXN_CODE1LAST_ALTERED_DATE" type="hidden"  runat="server"/>
  </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>
</p>
<p><br>
<DECV_PROD2007:Footer id="Footer" runat="server"/> </p>

</form>
</body>
</html>

<!--End ASPX page-->

