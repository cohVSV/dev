<!--ASPX page @1-DD99A0F9-->
    <%@ Page language="vb" CodeFile="STAFF_list.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.STAFF_list.STAFF_listPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.STAFF_list" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.1.1.0"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>STAFF</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//DEL    </script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">

//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//Set Focus @68-D55FD018
    if (theForm.STAFFSearchs_keyword) theForm.STAFFSearchs_keyword.focus();
//End Set Focus

//Close page_OnLoad @1-BC33A33A
    return result;
}
//End Close page_OnLoad

//bind_events @1-B716D3FC
function bind_events() {
    page_OnLoad();
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

window.onload = bind_events; 

//End CCS script
</script>

</head>
<body>
<form runat="server">


<DECV_PROD2007:Header id="Header" runat="server"/> 

  <span id="STAFFSearchHolder" runat="server">
    


  <table border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td valign="top">
        <table class="Header" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Search STAFF </th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="STAFFSearchError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="STAFFSearchErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>Keyword</th>
 
            <td><asp:TextBox id="STAFFSearchs_keyword" maxlength="20"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Active?</th>
 
            <td>
              <asp:RadioButtonList id="STAFFSearchrbStatus"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">
              <input id='STAFFSearchButton_DoSearch' type="submit" class="Button" value="Search" OnServerClick='STAFFSearch_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  
<div align="center">
<a id="Link_AddNew" href="" class="Button" runat="server"  >Add New</a> 
</div>
<div align="right">
</div>
<br>

<asp:repeater id="STAFFRepeater" OnItemCommand="STAFFItemCommand" OnItemDataBound="STAFFItemDataBound" runat="server">
  <HeaderTemplate>
	
<table border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
      <table class="Header" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>List of STAFF </th>
 
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_STAFF_IDSorter" field="Sorter_STAFF_ID" OwnerState="<%# STAFFData.SortField.ToString()%>" OwnerDir="<%# STAFFData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STAFF_IDSort" runat="server">ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# STAFFData.SortField.ToString()%>" OwnerDir="<%# STAFFData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">SURNAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_FIRSTNAMESorter" field="Sorter_FIRSTNAME" OwnerState="<%# STAFFData.SortField.ToString()%>" OwnerDir="<%# STAFFData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FIRSTNAMESort" runat="server">FIRSTNAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_TEACHER_FLAGSorter" field="Sorter_TEACHER_FLAG" OwnerState="<%# STAFFData.SortField.ToString()%>" OwnerDir="<%# STAFFData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_TEACHER_FLAGSort" runat="server">TEACHER FLAG</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_GROUP_NAMESorter" field="Sorter_GROUP_NAME" OwnerState="<%# STAFFData.SortField.ToString()%>" OwnerDir="<%# STAFFData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_GROUP_NAMESort" runat="server">GROUP NAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_STATUSSorter" field="Sorter_STATUS" OwnerState="<%# STAFFData.SortField.ToString()%>" OwnerDir="<%# STAFFData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STATUSSort" runat="server">ACTIVE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# STAFFData.SortField.ToString()%>" OwnerDir="<%# STAFFData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# STAFFData.SortField.ToString()%>" OwnerDir="<%# STAFFData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td><a id="STAFFSTAFF_ID" href="" runat="server"  ><%#(CType(Container.DataItem,STAFFItem)).STAFF_ID.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="STAFFSURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFFItem)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFFFIRSTNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFFItem)).FIRSTNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFFTEACHER_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFFItem)).TEACHER_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFFGROUP_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFFItem)).GROUP_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFFSTATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFFItem)).STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFFLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFFItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFFLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFFItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <AlternatingItemTemplate>
	
        <tr class="AltRow">
          <td><a id="STAFFAlt_STAFF_ID" href="" runat="server"  ><%#(CType(Container.DataItem,STAFFItem)).Alt_STAFF_ID.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="STAFFAlt_SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFFItem)).Alt_SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFFAlt_FIRSTNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFFItem)).Alt_FIRSTNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFFAlt_TEACHER_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFFItem)).Alt_TEACHER_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFFAlt_GROUP_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFFItem)).Alt_GROUP_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFFAlt_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFFItem)).Alt_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFFAlt_LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFFItem)).Alt_LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STAFFAlt_LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STAFFItem)).Alt_LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
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
          <td colspan="8"><a id="STAFFSTAFF_Insert" href="" runat="server"  >Add New</a>&nbsp; 
            
<CC:Navigator id="Navigator1Navigator" MaxPage="<%# STAFFData.PagesCount%>" PageSize="<%# STAFFData.RecordsPerPage%>" PageNumber="<%# STAFFData.PageNumber%>" runat="server"><span class="Navigator">Records per page 
            <CC:PageSizer AutoPostBack="true" runat="server" />
 
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="Navigator1First" runat="server"><img src="Styles/Blueprint/Images/First.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="FirstOff" runat="server"><img src="Styles/Blueprint/Images/FirstOff.gif"></CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="Navigator1Prev" runat="server"><img src="Styles/Blueprint/Images/Prev.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOff" runat="server"><img src="Styles/Blueprint/Images/PrevOff.gif"></CC:NavigatorItem>
            
<CC:Pager id="Navigator1Pager" Style="Centered" PagerSize="6" runat="server">
            <PageOnTemplate><asp:LinkButton runat="server"><%# (CType(Container,PagerItem)).PageNumber.ToString() %></asp:LinkButton> </PageOnTemplate>
            <PageOffTemplate><%# (CType(Container,PagerItem)).PageNumber.ToString() %> </PageOffTemplate></CC:Pager>of <%# (CType(Container,Navigator)).MaxPage.ToString() %> 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="Navigator1Next" runat="server"><img src="Styles/Blueprint/Images/Next.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="NextOff" runat="server"><img src="Styles/Blueprint/Images/NextOff.gif"></CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="Navigator1Last" runat="server"><img src="Styles/Blueprint/Images/Last.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOff" runat="server"><img src="Styles/Blueprint/Images/LastOff.gif"></CC:NavigatorItem></span> </CC:Navigator>
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

