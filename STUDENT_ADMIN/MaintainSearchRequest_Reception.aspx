<!--ASPX page @1-63A2A723-->
    <%@ Page language="vb" CodeFile="MaintainSearchRequest_Reception.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.MaintainSearchRequest_Reception.MaintainSearchRequest_ReceptionPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.MaintainSearchRequest_Reception" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 4.1.00.032"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Reception Contact Search</title>


<script language="JavaScript" type="text/javascript">
//Begin CCS script
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

//Set Focus @71-4DC35A02
    if (theForm.viewMaintainSearchRequests_FIRST_NAME) theForm.viewMaintainSearchRequests_FIRST_NAME.focus();
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
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">

</head>
<body>
<form runat="server">


<DECV_PROD2007:Header id="Header" runat="server"/><font size="2">
<p>

  <span id="viewMaintainSearchRequestHolder" runat="server">
    


  <table border="0" cellspacing="0" cellpadding="0" align="center">
    <tr>
      <td valign="top">
        <table class="Header" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Search Contact Details</th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="viewMaintainSearchRequestError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="viewMaintainSearchRequestErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>FIRST NAME like..</th>
 
            <td><asp:TextBox id="viewMaintainSearchRequests_FIRST_NAME" maxlength="30" Columns="30"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>ADDRESS like...</th>
 
            <td><asp:TextBox id="viewMaintainSearchRequests_Postal_ADDR1" maxlength="50" Columns="50"	runat="server"/><br>
              <em>searches all Address and Suburb fields, <u>not</u> Postcode</em>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>PHONE NUMBER like...</th>
 
            <td><asp:TextBox id="viewMaintainSearchRequests_Postal_PHONE_A" maxlength="15" Columns="15"	runat="server"/><br>
              <em>either <u>include spaces</u>, or enter parts of phone numbers</em>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>EMAIL ADDRESS like...</th>
 
            <td><asp:TextBox id="viewMaintainSearchRequests_Postal_EMAIL_ADDRESS" maxlength="50" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td>
              <div align="left">
<a id="viewMaintainSearchRequestLink1" href="" runat="server"  >Simple Search</a> 
              </div>
            </td> 
            <td align="right"><a id="viewMaintainSearchRequestClearParameters" href="" runat="server"  >Clear</a>&nbsp;&nbsp; 
              <input id='viewMaintainSearchRequestButton_DoSearch' type="submit" class="Button" value="Search" OnServerClick='viewMaintainSearchRequest_Search' runat="server"/></td>
          </tr>
        </table>
        <em>Note:&nbsp; Carer/Supervisor Search results are shown below Address Results</em></td>
    </tr>
  </table>



  </span>
  <br>

<asp:repeater id="viewMaintainSearchRequest1Repeater" OnItemCommand="viewMaintainSearchRequest1ItemCommand" OnItemDataBound="viewMaintainSearchRequest1ItemDataBound" runat="server">
  <HeaderTemplate>
	
<table border="0" cellspacing="0" cellpadding="0" align="center">
  <tr>
    <td valign="top">
      <table class="Header" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>Address Results (for current Year)</th>
 
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Row">
          <td colspan="17">Total Records:&nbsp;<asp:Literal id="viewMaintainSearchRequest1viewMaintainSearchRequest1_TotalRecords" runat="server"/></td>
        </tr>
 
        <tr class="Caption">
          <th colspan="7">&nbsp;Student Details &gt;&gt;&gt;&gt;&nbsp;&nbsp;&nbsp;&nbsp;</th>
 
          <th colspan="5">&nbsp;POSTAL ADDRESS DETAILS&nbsp;&nbsp;&nbsp;&nbsp;&gt;&gt;&gt;&gt;&gt;</th>
 
          <th colspan="5">CURRENT ADDRESS DETAILS&nbsp;&nbsp;&gt;&gt;&gt;&gt;&gt;&nbsp;&nbsp;&nbsp;</th>
        </tr>
 
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_STUDENT_IDSorter" field="Sorter_STUDENT_ID" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STUDENT_IDSort" runat="server">STUDENT ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">SURNAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_FIRST_NAMESorter" field="Sorter_FIRST_NAME" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FIRST_NAMESort" runat="server">FIRST NAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>ENROL <br>
          STATUS</th>
 
          <th>YEAR <br>
          LEVEL</th>
 
          <th>Mobile Phone&nbsp;</th>
 
          <th>Student Email&nbsp;</th>
 
          <th>&nbsp;</th>
 
          <th>
          <CC:Sorter id="Sorter_Postal_ADDR1Sorter" field="Sorter_Postal_ADDR1" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_Postal_ADDR1Sort" runat="server">ADDRESS</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_Postal_SUBURB_TOWNSorter" field="Sorter_Postal_SUBURB_TOWN" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_Postal_SUBURB_TOWNSort" runat="server">SUBURB TOWN</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_Postal_PHONE_ASorter" field="Sorter_Postal_PHONE_A" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_Postal_PHONE_ASort" runat="server">PHONE NUMBER(S)</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_Postal_EMAIL_ADDRESSSorter" field="Sorter_Postal_EMAIL_ADDRESS" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_Postal_EMAIL_ADDRESSSort" runat="server">EMAIL ADDRESS</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>&nbsp;</th>
 
          <th>
          <CC:Sorter id="Sorter_Curr_ADDR1Sorter" field="Sorter_Curr_ADDR1" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_Curr_ADDR1Sort" runat="server">ADDRESS</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_Curr_SUBURB_TOWNSorter" field="Sorter_Curr_SUBURB_TOWN" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_Curr_SUBURB_TOWNSort" runat="server">SUBURB TOWN</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_Curr_PHONE_ASorter" field="Sorter_Curr_PHONE_A" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_Curr_PHONE_ASort" runat="server">PHONE NUMBER(S)</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_Curr_EMAIL_ADDRESSSorter" field="Sorter_Curr_EMAIL_ADDRESS" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_Curr_EMAIL_ADDRESSSort" runat="server">EMAIL ADDRESS</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="TEXT-ALIGN: right"><a id="viewMaintainSearchRequest1STUDENT_ID" href="" runat="server"  ><%#(CType(Container.DataItem,viewMaintainSearchRequest1Item)).STUDENT_ID.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="viewMaintainSearchRequest1SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewMaintainSearchRequest1FIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td>&nbsp;<asp:Literal id="viewMaintainSearchRequest1ENROLMENT_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).ENROLMENT_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="viewMaintainSearchRequest1YEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="viewMaintainSearchRequest1STUDENT_MOBILE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).STUDENT_MOBILE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td nowrap>&nbsp;<asp:Literal id="viewMaintainSearchRequest1STUDENT_EMAIL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).STUDENT_EMAIL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td style="BACKGROUND-COLOR: #dfdfdf">&nbsp;</td> 
          <td><asp:Literal id="viewMaintainSearchRequest1Postal_ADDR1" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).Postal_ADDR1.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/><br>
            <asp:Literal id="viewMaintainSearchRequest1Postal_ADDR2" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).Postal_ADDR2.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td><asp:Literal id="viewMaintainSearchRequest1Postal_SUBURB_TOWN" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).Postal_SUBURB_TOWN.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/><br>
            <asp:Literal id="viewMaintainSearchRequest1Postal_POSTCODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).Postal_POSTCODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td nowrap><asp:Literal id="viewMaintainSearchRequest1Postal_PHONE_A" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).Postal_PHONE_A.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/><br>
            <asp:Literal id="viewMaintainSearchRequest1Postal_PHONE_B" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).Postal_PHONE_B.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td nowrap><asp:Literal id="viewMaintainSearchRequest1Postal_EMAIL_ADDRESS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).Postal_EMAIL_ADDRESS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/><br>
            <asp:Literal id="viewMaintainSearchRequest1Postal_EMAIL_ADDRESS2" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).Postal_EMAIL_ADDRESS2.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td style="BACKGROUND-COLOR: #dfdfdf">&nbsp;</td> 
          <td><asp:Literal id="viewMaintainSearchRequest1Curr_ADDR1" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).Curr_ADDR1.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/><br>
            <asp:Literal id="viewMaintainSearchRequest1Curr_ADDR2" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).Curr_ADDR2.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td><asp:Literal id="viewMaintainSearchRequest1Curr_SUBURB_TOWN" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).Curr_SUBURB_TOWN.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/><br>
            <asp:Literal id="viewMaintainSearchRequest1Curr_POSTCODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).Curr_POSTCODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td nowrap><asp:Literal id="viewMaintainSearchRequest1Curr_PHONE_A" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).Curr_PHONE_A.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/><br>
            <asp:Literal id="viewMaintainSearchRequest1Curr_PHONE_B" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).Curr_PHONE_B.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td nowrap><asp:Literal id="viewMaintainSearchRequest1Curr_EMAIL_ADDRESS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).Curr_EMAIL_ADDRESS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/><br>
            <asp:Literal id="viewMaintainSearchRequest1Curr_EMAIL_ADDRESS2" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).Curr_EMAIL_ADDRESS2.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="17">No results found - <strong>Try entering fewer fields or only parts of address for better results</strong>.</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="17">
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# viewMaintainSearchRequest1Data.PagesCount%>" PageSize="<%# viewMaintainSearchRequest1Data.RecordsPerPage%>" PageNumber="<%# viewMaintainSearchRequest1Data.PageNumber%>" runat="server">
            Per page: 
            <CC:PageSizer AutoPostBack="true" runat="server" />
 
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server">First</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="FirstOff" runat="server">First </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server">Prev</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOff" runat="server">Prev </CC:NavigatorItem>&nbsp; 
            
<CC:Pager id="NavigatorPager" Style="Centered" PagerSize="10" runat="server">
            <PageOnTemplate><asp:LinkButton runat="server"><%# (CType(Container,PagerItem)).PageNumber.ToString() %></asp:LinkButton>&nbsp;</PageOnTemplate>
            <PageOffTemplate><%# (CType(Container,PagerItem)).PageNumber.ToString() %>&nbsp;</PageOffTemplate></CC:Pager>of &nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server">Next</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="NextOff" runat="server">Next </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server">Last</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOff" runat="server">Last </CC:NavigatorItem></CC:Navigator>
&nbsp;</td>
        </tr>
      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
<br>

<asp:repeater id="viewMaintainSearchRequest2Repeater" OnItemCommand="viewMaintainSearchRequest2ItemCommand" OnItemDataBound="viewMaintainSearchRequest2ItemDataBound" runat="server">
  <HeaderTemplate>
	
<table border="0" cellspacing="0" cellpadding="0" align="center">
  <tr>
    <td valign="top">
      <table class="Header" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>Carers / School Supervisors (for Current Year, Enrolled Students)</th>
 
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_STUDENT_IDSorter" field="Sorter_STUDENT_ID" OwnerState="<%# viewMaintainSearchRequest2Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest2Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STUDENT_IDSort" runat="server">STUDENT ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# viewMaintainSearchRequest2Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest2Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">SURNAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_FIRST_NAMESorter" field="Sorter_FIRST_NAME" OwnerState="<%# viewMaintainSearchRequest2Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest2Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FIRST_NAMESort" runat="server">FIRST NAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_RELATIONSHIPSorter" field="Sorter_RELATIONSHIP" OwnerState="<%# viewMaintainSearchRequest2Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest2Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_RELATIONSHIPSort" runat="server">RELATIONSHIP</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_HOME_PHONESorter" field="Sorter_HOME_PHONE" OwnerState="<%# viewMaintainSearchRequest2Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest2Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_HOME_PHONESort" runat="server">HOME PHONE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_WORK_PHONESorter" field="Sorter_WORK_PHONE" OwnerState="<%# viewMaintainSearchRequest2Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest2Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_WORK_PHONESort" runat="server">WORK PHONE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_MOBILESorter" field="Sorter_MOBILE" OwnerState="<%# viewMaintainSearchRequest2Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest2Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_MOBILESort" runat="server">MOBILE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_EMAILSorter" field="Sorter_EMAIL" OwnerState="<%# viewMaintainSearchRequest2Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest2Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_EMAILSort" runat="server">EMAIL</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="TEXT-ALIGN: right"><a id="viewMaintainSearchRequest2STUDENT_ID" href="" runat="server"  ><%#(CType(Container.DataItem,viewMaintainSearchRequest2Item)).STUDENT_ID.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="viewMaintainSearchRequest2SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewMaintainSearchRequest2FIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewMaintainSearchRequest2RELATIONSHIP" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).RELATIONSHIP.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewMaintainSearchRequest2HOME_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).HOME_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewMaintainSearchRequest2WORK_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).WORK_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewMaintainSearchRequest2MOBILE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).MOBILE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewMaintainSearchRequest2EMAIL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest2Item)).EMAIL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="8">No Carer/Supervisor Details found! <strong>Try entering fewer fields or only parts of address for better results</strong></td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="8">
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# viewMaintainSearchRequest2Data.PagesCount%>" PageSize="<%# viewMaintainSearchRequest2Data.RecordsPerPage%>" PageNumber="<%# viewMaintainSearchRequest2Data.PageNumber%>" runat="server">
            Per page: 
            <CC:PageSizer AutoPostBack="true" runat="server" />
 
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server">First</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="FirstOff" runat="server">First </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server">Prev</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOff" runat="server">Prev </CC:NavigatorItem>&nbsp; 
            
<CC:Pager id="NavigatorPager" Style="Centered" PagerSize="10" runat="server">
            <PageOnTemplate><asp:LinkButton runat="server"><%# (CType(Container,PagerItem)).PageNumber.ToString() %></asp:LinkButton>&nbsp;</PageOnTemplate>
            <PageOffTemplate><%# (CType(Container,PagerItem)).PageNumber.ToString() %>&nbsp;</PageOffTemplate></CC:Pager>of &nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server">Next</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="NextOff" runat="server">Next </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server">Last</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOff" runat="server">Last </CC:NavigatorItem></CC:Navigator>
&nbsp;</td>
        </tr>
      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
<br>
</p>
</font>

</form>
</body>
</html>

<!--End ASPX page-->

