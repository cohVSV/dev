<!--ASPX page @1-3504B0E8-->
    <%@ Page language="vb" CodeFile="CONTRIBUTION_list.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.CONTRIBUTION_list.CONTRIBUTION_listPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.CONTRIBUTION_list" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.1.1.0" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>CONTRIBUTION</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/> </p>
<p>

  <span id="CONTRIBUTION1Holder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Search CONTRIBUTION </th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="CONTRIBUTION1Error" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="CONTRIBUTION1ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>CATEGORY CODE</th>
 
            <td><asp:TextBox id="CONTRIBUTION1s_CATEGORY_CODE" maxlength="10" Columns="10"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>CAMPUS CODE</th>
 
            <td>
              <asp:RadioButtonList id="CONTRIBUTION1s_CAMPUS_CODE"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='CONTRIBUTION1Button_DoSearch' class="Button" type="submit" value="Search" OnServerClick='CONTRIBUTION1_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  </p>
<p align="center"><a id="Contrib_insert" href="" runat="server"  >Add New</a></p>
<p><br>
</p>

<asp:repeater id="CONTRIBUTIONRepeater" OnItemCommand="CONTRIBUTIONItemCommand" OnItemDataBound="CONTRIBUTIONItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" align="left" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
          <th>List of CONTRIBUTION </th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
        </tr>
      </table>
 
      <div align="left">
        <table class="Grid" cellspacing="0" cellpadding="0" align="left">
          <tr class="Caption">
            <th>
            <CC:Sorter id="Sorter_CATEGORY_CODESorter" field="Sorter_CATEGORY_CODE" OwnerState="<%# CONTRIBUTIONData.SortField.ToString()%>" OwnerDir="<%# CONTRIBUTIONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_CATEGORY_CODESort" runat="server">CATEGORY CODE</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_SCHOOL_TYPE_CODE1Sorter" field="Sorter_SCHOOL_TYPE_CODE1" OwnerState="<%# CONTRIBUTIONData.SortField.ToString()%>" OwnerDir="<%# CONTRIBUTIONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SCHOOL_TYPE_CODE1Sort" runat="server">SCHOOL TYPE CODE</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_CAMPUS_CODE1Sorter" field="Sorter_CAMPUS_CODE1" OwnerState="<%# CONTRIBUTIONData.SortField.ToString()%>" OwnerDir="<%# CONTRIBUTIONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_CAMPUS_CODE1Sort" runat="server">CAMPUS CODE</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_FROM_YEAR_LEVELSorter" field="Sorter_FROM_YEAR_LEVEL" OwnerState="<%# CONTRIBUTIONData.SortField.ToString()%>" OwnerDir="<%# CONTRIBUTIONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FROM_YEAR_LEVELSort" runat="server">FROM YEAR LEVEL</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_TO_YEAR_LEVELSorter" field="Sorter_TO_YEAR_LEVEL" OwnerState="<%# CONTRIBUTIONData.SortField.ToString()%>" OwnerDir="<%# CONTRIBUTIONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_TO_YEAR_LEVELSort" runat="server">TO YEAR LEVEL</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_PER_SUBJECT_FLAGSorter" field="Sorter_PER_SUBJECT_FLAG" OwnerState="<%# CONTRIBUTIONData.SortField.ToString()%>" OwnerDir="<%# CONTRIBUTIONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_PER_SUBJECT_FLAGSort" runat="server">PER SUBJECT FLAG</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_DEFAULT_CONTRIBUTIONSorter" field="Sorter_DEFAULT_CONTRIBUTION" OwnerState="<%# CONTRIBUTIONData.SortField.ToString()%>" OwnerDir="<%# CONTRIBUTIONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_DEFAULT_CONTRIBUTIONSort" runat="server">DEFAULT CONTRIBUTION</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_DISCOUNT_AMOUNTSorter" field="Sorter_DISCOUNT_AMOUNT" OwnerState="<%# CONTRIBUTIONData.SortField.ToString()%>" OwnerDir="<%# CONTRIBUTIONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_DISCOUNT_AMOUNTSort" runat="server">DISCOUNT AMOUNT</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# CONTRIBUTIONData.SortField.ToString()%>" OwnerDir="<%# CONTRIBUTIONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# CONTRIBUTIONData.SortField.ToString()%>" OwnerDir="<%# CONTRIBUTIONData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
          <tr class="Row">
            <td><a id="CONTRIBUTIONCATEGORY_CODE" href="" runat="server"  ><%#(CType(Container.DataItem,CONTRIBUTIONItem)).CATEGORY_CODE.GetFormattedValue()%></a>&nbsp;</td> 
            <td><asp:Literal id="CONTRIBUTIONSCHOOL_TYPE_CODE1" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CONTRIBUTIONItem)).SCHOOL_TYPE_CODE1.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="CONTRIBUTIONCAMPUS_CODE1" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CONTRIBUTIONItem)).CAMPUS_CODE1.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td style="TEXT-ALIGN: right"><asp:Literal id="CONTRIBUTIONFROM_YEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CONTRIBUTIONItem)).FROM_YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td style="TEXT-ALIGN: right"><asp:Literal id="CONTRIBUTIONTO_YEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CONTRIBUTIONItem)).TO_YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="CONTRIBUTIONPER_SUBJECT_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CONTRIBUTIONItem)).PER_SUBJECT_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td style="TEXT-ALIGN: right"><asp:Literal id="CONTRIBUTIONDEFAULT_CONTRIBUTION" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CONTRIBUTIONItem)).DEFAULT_CONTRIBUTION.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td style="TEXT-ALIGN: right"><asp:Literal id="CONTRIBUTIONDISCOUNT_AMOUNT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CONTRIBUTIONItem)).DISCOUNT_AMOUNT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="CONTRIBUTIONLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CONTRIBUTIONItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="CONTRIBUTIONLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CONTRIBUTIONItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <AlternatingItemTemplate>
	
          <tr class="AltRow">
            <td><a id="CONTRIBUTIONAlt_CATEGORY_CODE" href="" runat="server"  ><%#(CType(Container.DataItem,CONTRIBUTIONItem)).Alt_CATEGORY_CODE.GetFormattedValue()%></a>&nbsp;</td> 
            <td><asp:Literal id="CONTRIBUTIONAlt_SCHOOL_TYPE_CODE1" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CONTRIBUTIONItem)).Alt_SCHOOL_TYPE_CODE1.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="CONTRIBUTIONAlt_CAMPUS_CODE1" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CONTRIBUTIONItem)).Alt_CAMPUS_CODE1.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td style="TEXT-ALIGN: right"><asp:Literal id="CONTRIBUTIONAlt_FROM_YEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CONTRIBUTIONItem)).Alt_FROM_YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td style="TEXT-ALIGN: right"><asp:Literal id="CONTRIBUTIONAlt_TO_YEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CONTRIBUTIONItem)).Alt_TO_YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="CONTRIBUTIONAlt_PER_SUBJECT_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CONTRIBUTIONItem)).Alt_PER_SUBJECT_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td style="TEXT-ALIGN: right"><asp:Literal id="CONTRIBUTIONAlt_DEFAULT_CONTRIBUTION" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CONTRIBUTIONItem)).Alt_DEFAULT_CONTRIBUTION.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td style="TEXT-ALIGN: right"><asp:Literal id="CONTRIBUTIONAlt_DISCOUNT_AMOUNT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CONTRIBUTIONItem)).Alt_DISCOUNT_AMOUNT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="CONTRIBUTIONAlt_LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CONTRIBUTIONItem)).Alt_LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="CONTRIBUTIONAlt_LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CONTRIBUTIONItem)).Alt_LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          </tr>
 
	<asp:PlaceHolder id="AltIterationContainer" runat="server"/>
  </AlternatingItemTemplate>
  <FooterTemplate>
	
          
          
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
          <tr class="NoRecords">
            <td colspan="10">No records</td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Footer">
            <td colspan="10"><a id="CONTRIBUTIONCONTRIBUTION_Insert" href="" runat="server"  >Add New</a>&nbsp; 
              
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# CONTRIBUTIONData.PagesCount%>" PageSize="<%# CONTRIBUTIONData.RecordsPerPage%>" PageNumber="<%# CONTRIBUTIONData.PageNumber%>" runat="server">
              <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server">|&lt;</asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server">&lt;&lt;</asp:LinkButton> </CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %> of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
              <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server">&gt;&gt;</asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server">&gt;|</asp:LinkButton> </CC:NavigatorItem></CC:Navigator>
</td>
          </tr>
        </table>
      </div>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>

<p>&nbsp;</p>
<p><br>
<DECV_PROD2007:Footer id="Footer" runat="server"/> </p>

</form>
</body>
</html>

<!--End ASPX page-->

