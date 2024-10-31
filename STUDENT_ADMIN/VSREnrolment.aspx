<!--ASPX page @1-AC2589DC-->
    <%@ Page language="vb" CodeFile="VSREnrolment.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.VSREnrolment.VSREnrolmentPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.VSREnrolment" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 4.1.00.032" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>VSREnrolment</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-12DCE9BA
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_viewVSNSearch_OnLoad @2-83139F8C
function page_viewVSNSearch_OnLoad(form)
{
    var result;
//End page_viewVSNSearch_OnLoad

//Set Focus @13-4A088FA4
    if (theForm.viewVSNSearchs_SURNAME) theForm.viewVSNSearchs_SURNAME.focus();
//End Set Focus

//Close page_viewVSNSearch_OnLoad @2-BC33A33A
    return result;
}
//End Close page_viewVSNSearch_OnLoad

//bind_events @1-54C6763B
function bind_events() {
    if(document.getElementById("viewVSNSearchHolder"))
    addEventHandler("viewVSNSearch","load",page_viewVSNSearch_OnLoad);
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


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>

  <span id="viewVSNSearchHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Search&nbsp;Student VSN</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="viewVSNSearchError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="viewVSNSearchErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>SURNAME*</th>
 
            <td><asp:TextBox id="viewVSNSearchs_SURNAME" tabindex="1" maxlength="30"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>STUDENT ID</th>
 
            <td><asp:TextBox id="viewVSNSearchs_STUDENT_ID" tabindex="2" maxlength="12"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>VSN</th>
 
            <td><asp:TextBox id="viewVSNSearchs_STUDENT_VSN" tabindex="2" maxlength="12"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>ENROLMENT YEAR</th>
 
            <td><asp:TextBox id="viewVSNSearchs_ENROLMENT_YEAR" tabindex="4" maxlength="12" Columns="5"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td></td> 
            <td align="right"><a id="viewVSNSearchClearParameters" href="" tabindex="6" runat="server"  >Clear</a> 
              <input id='viewVSNSearchButton_DoSearch' class="Button" tabindex="5" type="submit" value="Search" OnServerClick='viewVSNSearch_Search' runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td></td> 
            <td align="right"></td>
          </tr>
        </table>
        <em>SURNAME&nbsp;is automatic wildcard searches</em></td>
    </tr>
  </table>



  </span>
  &nbsp; 

<asp:repeater id="viewVSNRepeater" OnItemCommand="viewVSNItemCommand" OnItemDataBound="viewVSNItemDataBound" runat="server">
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
          <CC:Sorter id="Sorter_STUDENT_IDSorter" field="Sorter_STUDENT_ID" OwnerState="<%# viewVSNData.SortField.ToString()%>" OwnerDir="<%# viewVSNData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STUDENT_IDSort" runat="server">STUDENT ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# viewVSNData.SortField.ToString()%>" OwnerDir="<%# viewVSNData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">SURNAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem>&nbsp;</CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_FIRST_NAMESorter" field="Sorter_FIRST_NAME" OwnerState="<%# viewVSNData.SortField.ToString()%>" OwnerDir="<%# viewVSNData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FIRST_NAMESort" runat="server">FIRST NAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem>&nbsp;</CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_YEAR_LEVELSorter" field="Sorter_YEAR_LEVEL" OwnerState="<%# viewVSNData.SortField.ToString()%>" OwnerDir="<%# viewVSNData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_YEAR_LEVELSort" runat="server">YEAR LEVEL</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem>&nbsp;</CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_ENROLMENT_STATUSSorter" field="Sorter_ENROLMENT_STATUS" OwnerState="<%# viewVSNData.SortField.ToString()%>" OwnerDir="<%# viewVSNData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ENROLMENT_STATUSSort" runat="server">ENROLMENT STATUS</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem>&nbsp;</CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_ENROLMENT_YEARSorter" field="Sorter_ENROLMENT_YEAR" OwnerState="<%# viewVSNData.SortField.ToString()%>" OwnerDir="<%# viewVSNData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ENROLMENT_YEARSort" runat="server">ENROLMENT YEAR</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem>&nbsp;</CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_VSN1Sorter" field="Sorter_VSN1" OwnerState="<%# viewVSNData.SortField.ToString()%>" OwnerDir="<%# viewVSNData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_VSN1Sort" runat="server">VSN</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem>&nbsp;</CC:Sorter>&nbsp;&nbsp;</th>
 
          <th>&nbsp; 
          <CC:Sorter id="Sorter_VSREnrolledSorter" field="Sorter_VSREnrolled" OwnerState="<%# viewVSNData.SortField.ToString()%>" OwnerDir="<%# viewVSNData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_VSREnrolledSort" runat="server">VSR Enrolled</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem>&nbsp;</CC:Sorter></th>
 
          <th>&nbsp; 
          <CC:Sorter id="Sorter_VSRVerifiedSorter" field="Sorter_VSRVerified" OwnerState="<%# viewVSNData.SortField.ToString()%>" OwnerDir="<%# viewVSNData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_VSRVerifiedSort" runat="server">VSR Verified</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="TEXT-ALIGN: right"><a id="viewVSNSTUDENT_ID" href="" runat="server"  ><%#(CType(Container.DataItem,viewVSNItem)).STUDENT_ID.GetFormattedValue()%></a></td> 
          <td>&nbsp;<asp:Literal id="viewVSNSURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNItem)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="viewVSNFIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNItem)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="viewVSNYEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNItem)).YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="viewVSNENROLMENT_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNItem)).ENROLMENT_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td>&nbsp;<asp:Literal id="viewVSNENROLMENT_YEAR" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNItem)).ENROLMENT_YEAR.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="viewVSNVSN" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNItem)).VSN.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="viewVSNVSREnrolled" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNItem)).VSREnrolled.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="viewVSNVSRVerified" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNItem)).VSRVerified.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <SeparatorTemplate>
	
        <tr class="Separator">
          <td colspan="9"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
        </tr>
        
  </SeparatorTemplate>
  <FooterTemplate>
	
        
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="9">No records - try changing the search criteria </td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="9">
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# viewVSNData.PagesCount%>" PageSize="<%# viewVSNData.RecordsPerPage%>" PageNumber="<%# viewVSNData.PageNumber%>" runat="server">
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server">First</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="FirstOff" runat="server">First </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server">Prev</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOff" runat="server">Prev </CC:NavigatorItem>
            
<CC:Pager id="NavigatorPager" Style="Centered" PagerSize="10" runat="server">
            <PageOnTemplate><asp:LinkButton runat="server"><%# (CType(Container,PagerItem)).PageNumber.ToString() %></asp:LinkButton></PageOnTemplate>
            <PageOffTemplate><%# (CType(Container,PagerItem)).PageNumber.ToString() %></PageOffTemplate></CC:Pager>of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
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


</form>
</body>
</html>

<!--End ASPX page-->

