<!--ASPX page @1-6268E4E0-->
    <%@ Page language="vb" CodeFile="MaintainSearchRequest.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.MaintainSearchRequest.MaintainSearchRequestPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.MaintainSearchRequest" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.1.1.0" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Maintain Search Request</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">

//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" src='<%="ClientI18N.aspx?file=Functions.js&locale=" + Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_viewMaintainSearchRequestSearch_OnLoad @5-E7220BE6
function page_viewMaintainSearchRequestSearch_OnLoad(form)
{
    var result;
//End page_viewMaintainSearchRequestSearch_OnLoad

//Set Focus @34-85170611
    if (theForm.viewMaintainSearchRequestSearchs_SURNAME) theForm.viewMaintainSearchRequestSearchs_SURNAME.focus();
//End Set Focus

//Close page_viewMaintainSearchRequestSearch_OnLoad @5-BC33A33A
    return result;
}
//End Close page_viewMaintainSearchRequestSearch_OnLoad

//bind_events @1-B3697BA1
function bind_events() {
    if(document.getElementById("viewMaintainSearchRequestSearchHolder"))
    addEventHandler("viewMaintainSearchRequestSearch","load",page_viewMaintainSearchRequestSearch_OnLoad);
    forms_onload();
}
//End bind_events

window.onload = bind_events; //Assign bind_events @1-19F7B649

//End CCS script
</script>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_viewMaintainSearchRequestSearch_OnLoad @5-E7220BE6
function page_viewMaintainSearchRequestSearch_OnLoad(form)
{
    var result;
//End page_viewMaintainSearchRequestSearch_OnLoad

//Set Focus @34-85170611
    if (theForm.viewMaintainSearchRequestSearchs_SURNAME) theForm.viewMaintainSearchRequestSearchs_SURNAME.focus();
//End Set Focus

//Close page_viewMaintainSearchRequestSearch_OnLoad @5-BC33A33A
    return result;
}
//End Close page_viewMaintainSearchRequestSearch_OnLoad

//bind_events @1-B3697BA1
function bind_events() {
    if(document.getElementById("viewMaintainSearchRequestSearchHolder"))
    addEventHandler("viewMaintainSearchRequestSearch","load",page_viewMaintainSearchRequestSearch_OnLoad);
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p>

  <span id="viewMaintainSearchRequestSearchHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" width="30%" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Search&nbsp;Students</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="viewMaintainSearchRequestSearchError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="viewMaintainSearchRequestSearchErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>SURNAME*</th>
 
            <td><asp:TextBox id="viewMaintainSearchRequestSearchs_SURNAME" tabindex="1" maxlength="30"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>STUDENT ID</th>
 
            <td><asp:TextBox id="viewMaintainSearchRequestSearchs_STUDENT_ID" tabindex="2" maxlength="12"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>ENROLMENT YEAR</th>
 
            <td><asp:TextBox id="viewMaintainSearchRequestSearchs_ENROLMENT_YEAR" tabindex="4" maxlength="12" Columns="5"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td>
              <p align="left"><a id="viewMaintainSearchRequestSearchLink1" href="" runat="server"  >Advanced Search</a>&nbsp; <a id="viewMaintainSearchRequestSearchLink2" href="" runat="server"  >Primary Search</a></p>
            </td> 
            <td align="right"><a id="viewMaintainSearchRequestSearchClearParameters" href="" tabindex="6" runat="server"  >Clear</a>&nbsp;&nbsp;&nbsp; 
              <input id='viewMaintainSearchRequestSearchButton_DoSearch' class="Button" tabindex="5" type="submit" value="Search" OnServerClick='viewMaintainSearchRequestSearch_Search' runat="server"/>&nbsp;&nbsp;</td>
          </tr>
 
          <tr class="Bottom">
            <td>
              <input id='viewMaintainSearchRequestSearchButton_DoAddEnrolYearSearch' class="Button" tabindex="7" type="submit" size="15" value="Add New Enrolment Year" OnServerClick='viewMaintainSearchRequestSearch_Search' runat="server"/>&nbsp;</td> 
            <td align="right">&nbsp;</td>
          </tr>
        </table>
        <em>SURNAME is an automatic wildcard search</em></td>
    </tr>
  </table>



  </span>
  <br>

<asp:repeater id="viewMaintainSearchRequestRepeater" OnItemCommand="viewMaintainSearchRequestItemCommand" OnItemDataBound="viewMaintainSearchRequestItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" align="center" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
          <th>Search Results</th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_STUDENT_IDSorter" field="Sorter_STUDENT_ID" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STUDENT_IDSort" runat="server">STUDENT ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_RECEIPT_NOSorter" field="Sorter_RECEIPT_NO" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_RECEIPT_NOSort" runat="server">RECEIPT NO</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">SURNAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_FIRST_NAMESorter" field="Sorter_FIRST_NAME" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FIRST_NAMESort" runat="server">FIRST NAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_YEAR_LEVELSorter" field="Sorter_YEAR_LEVEL" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_YEAR_LEVELSort" runat="server">YEAR LEVEL</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_ENROLMENT_STATUSSorter" field="Sorter_ENROLMENT_STATUS" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ENROLMENT_STATUSSort" runat="server">ENROLMENT STATUS</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_ENROLMENT_YEARSorter" field="Sorter_ENROLMENT_YEAR" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ENROLMENT_YEARSort" runat="server">ENROLMENT YEAR</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="TEXT-ALIGN: right"><a id="viewMaintainSearchRequestSTUDENT_ID" href="" runat="server"  ><%#(CType(Container.DataItem,viewMaintainSearchRequestItem)).STUDENT_ID.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="viewMaintainSearchRequestRECEIPT_NO" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequestItem)).RECEIPT_NO.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewMaintainSearchRequestSURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequestItem)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewMaintainSearchRequestFIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequestItem)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="viewMaintainSearchRequestYEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequestItem)).YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewMaintainSearchRequestENROLMENT_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequestItem)).ENROLMENT_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="viewMaintainSearchRequestENROLMENT_YEAR" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequestItem)).ENROLMENT_YEAR.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <SeparatorTemplate>
	
        <tr class="Separator">
          <td colspan="7"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
        </tr>
        
  </SeparatorTemplate>
  <FooterTemplate>
	
        
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="7">No records - try changing the search criteria </td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="7">
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# viewMaintainSearchRequestData.PagesCount%>" PageSize="<%# viewMaintainSearchRequestData.RecordsPerPage%>" PageNumber="<%# viewMaintainSearchRequestData.PageNumber%>" runat="server">
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

  </FooterTemplate>
</asp:repeater>
<br>
</p>

</form>
</body>
</html>

<!--End ASPX page-->

