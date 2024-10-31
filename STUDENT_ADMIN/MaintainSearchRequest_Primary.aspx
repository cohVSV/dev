<!--ASPX page @1-C2285531-->
    <%@ Page language="vb" CodeFile="MaintainSearchRequest_Primary.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.MaintainSearchRequest_Primary.MaintainSearchRequest_PrimaryPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.MaintainSearchRequest_Primary" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 4.1.00.032" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>MaintainSearchRequest_Primary</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-12DCE9BA
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//Set Focus @29-9A52F8DE
    if (theForm.viewPrimaryTeacherSearchRs_SURNAME) theForm.viewPrimaryTeacherSearchRs_SURNAME.focus();
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


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p>

  <span id="viewPrimaryTeacherSearchRHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" width="30%" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Primary Teacher Search</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="viewPrimaryTeacherSearchRError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="viewPrimaryTeacherSearchRErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>SURNAME*</th>
 
            <td><asp:TextBox id="viewPrimaryTeacherSearchRs_SURNAME" tabindex="1" maxlength="30"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>STUDENT ID</th>
 
            <td><asp:TextBox id="viewPrimaryTeacherSearchRs_STUDENT_ID" tabindex="2" maxlength="12"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>ENROLMENT YEAR</th>
 
            <td><asp:TextBox id="viewPrimaryTeacherSearchRs_ENROLMENT_YEAR" tabindex="3" maxlength="12" Columns="5"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td>
              <div align="left">
<a id="viewPrimaryTeacherSearchRLink1" href="" runat="server"  >Simple Search</a>
              </div>
            </td> 
            <td align="right"><a id="viewPrimaryTeacherSearchRClearParameters" href="" tabindex="5" runat="server"  >Clear</a>&nbsp;&nbsp; 
              <input id='viewPrimaryTeacherSearchRButton_DoSearch' class="Button" tabindex="4" type="submit" value="Search" OnServerClick='viewPrimaryTeacherSearchR_Search' runat="server"/></td>
          </tr>
        </table>
        <em>SURNAME is an automatic wildcard search</em></td>
    </tr>
  </table>



  </span>
  <br>

<asp:repeater id="viewPrimaryTeacherSearchR1Repeater" OnItemCommand="viewPrimaryTeacherSearchR1ItemCommand" OnItemDataBound="viewPrimaryTeacherSearchR1ItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" width="60%" align="center" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
          <th>Search Results - Prep to 6 only</th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_STUDENT_IDSorter" field="Sorter_STUDENT_ID" OwnerState="<%# viewPrimaryTeacherSearchR1Data.SortField.ToString()%>" OwnerDir="<%# viewPrimaryTeacherSearchR1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STUDENT_IDSort" runat="server">STUDENT ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# viewPrimaryTeacherSearchR1Data.SortField.ToString()%>" OwnerDir="<%# viewPrimaryTeacherSearchR1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">SURNAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_FIRST_NAMESorter" field="Sorter_FIRST_NAME" OwnerState="<%# viewPrimaryTeacherSearchR1Data.SortField.ToString()%>" OwnerDir="<%# viewPrimaryTeacherSearchR1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FIRST_NAMESort" runat="server">FIRST NAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_YEAR_LEVELSorter" field="Sorter_YEAR_LEVEL" OwnerState="<%# viewPrimaryTeacherSearchR1Data.SortField.ToString()%>" OwnerDir="<%# viewPrimaryTeacherSearchR1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_YEAR_LEVELSort" runat="server">YEAR LEVEL</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_ENROLMENT_STATUSSorter" field="Sorter_ENROLMENT_STATUS" OwnerState="<%# viewPrimaryTeacherSearchR1Data.SortField.ToString()%>" OwnerDir="<%# viewPrimaryTeacherSearchR1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ENROLMENT_STATUSSort" runat="server">ENROL STATUS</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_STAFF_IDSorter" field="Sorter_STAFF_ID" OwnerState="<%# viewPrimaryTeacherSearchR1Data.SortField.ToString()%>" OwnerDir="<%# viewPrimaryTeacherSearchR1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STAFF_IDSort" runat="server">TEACHER</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_PASTORAL_CARE_IDSorter" field="Sorter_PASTORAL_CARE_ID" OwnerState="<%# viewPrimaryTeacherSearchR1Data.SortField.ToString()%>" OwnerDir="<%# viewPrimaryTeacherSearchR1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_PASTORAL_CARE_IDSort" runat="server">STUDENT SUPPORT</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_ENROLMENT_YEARSorter" field="Sorter_ENROLMENT_YEAR" OwnerState="<%# viewPrimaryTeacherSearchR1Data.SortField.ToString()%>" OwnerDir="<%# viewPrimaryTeacherSearchR1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ENROLMENT_YEARSort" runat="server">ENROLMENT YEAR</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="TEXT-ALIGN: right"><asp:Literal id="viewPrimaryTeacherSearchR1STUDENT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewPrimaryTeacherSearchR1Item)).STUDENT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewPrimaryTeacherSearchR1SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewPrimaryTeacherSearchR1Item)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewPrimaryTeacherSearchR1FIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewPrimaryTeacherSearchR1Item)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="viewPrimaryTeacherSearchR1YEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewPrimaryTeacherSearchR1Item)).YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewPrimaryTeacherSearchR1ENROLMENT_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewPrimaryTeacherSearchR1Item)).ENROLMENT_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewPrimaryTeacherSearchR1STAFF_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewPrimaryTeacherSearchR1Item)).STAFF_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewPrimaryTeacherSearchR1PASTORAL_CARE_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewPrimaryTeacherSearchR1Item)).PASTORAL_CARE_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="viewPrimaryTeacherSearchR1ENROLMENT_YEAR" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewPrimaryTeacherSearchR1Item)).ENROLMENT_YEAR.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="8">No records - try changing the search criteria</td>
        </tr>
        
  </asp:PlaceHolder>

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

