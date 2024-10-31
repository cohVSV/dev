<!--ASPX page @1-966DE37C-->
    <%@ Page language="vb" CodeFile="Student_VSN_History.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_VSN_History.Student_VSN_HistoryPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_VSN_History" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student_VSN_History</title>

<meta content="CodeCharge Studio 4.1.00.032" name="GENERATOR">
<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-12DCE9BA
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_viewSearchVSNHistory_OnLoad @2-98239CDC
function page_viewSearchVSNHistory_OnLoad(form)
{
    var result;
//End page_viewSearchVSNHistory_OnLoad

//Set Focus @10-72094828
    if (theForm.viewSearchVSNHistorys_SURNAME) theForm.viewSearchVSNHistorys_SURNAME.focus();
//End Set Focus

//Close page_viewSearchVSNHistory_OnLoad @2-BC33A33A
    return result;
}
//End Close page_viewSearchVSNHistory_OnLoad

//bind_events @1-40850066
function bind_events() {
    if(document.getElementById("viewSearchVSNHistoryHolder"))
    addEventHandler("viewSearchVSNHistory","load",page_viewSearchVSNHistory_OnLoad);
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

  <span id="viewSearchVSNHistoryHolder" runat="server">
    


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
          
  <asp:PlaceHolder id="viewSearchVSNHistoryError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="viewSearchVSNHistoryErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>SURNAME*</th>
 
            <td><asp:TextBox id="viewSearchVSNHistorys_SURNAME" tabindex="1" maxlength="30"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>STUDENT ID</th>
 
            <td><asp:TextBox id="viewSearchVSNHistorys_STUDENT_ID" tabindex="2" maxlength="12"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>VSN</th>
 
            <td><asp:TextBox id="viewSearchVSNHistorys_STUDENT_VSN" tabindex="2" maxlength="12"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>ENROLMENT YEAR</th>
 
            <td><asp:TextBox id="viewSearchVSNHistorys_ENROLMENT_YEAR" tabindex="4" maxlength="12" Columns="5"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td></td> 
            <td align="right"><a id="viewSearchVSNHistoryClearParameters" href="" tabindex="6" runat="server"  >Clear</a> 
              <input id='viewSearchVSNHistoryButton_DoSearch' class="Button" tabindex="5" type="submit" value="Search" OnServerClick='viewSearchVSNHistory_Search' runat="server"/></td>
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

<asp:repeater id="viewVSNTransactionsRepeater" OnItemCommand="viewVSNTransactionsItemCommand" OnItemDataBound="viewVSNTransactionsItemDataBound" runat="server">
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
          <CC:Sorter id="Sorter_STUDENT_IDSorter" field="Sorter_STUDENT_ID" OwnerState="<%# viewVSNTransactionsData.SortField.ToString()%>" OwnerDir="<%# viewVSNTransactionsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STUDENT_IDSort" runat="server">STUDENT ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LastNameSorter" field="Sorter_LastName" OwnerState="<%# viewVSNTransactionsData.SortField.ToString()%>" OwnerDir="<%# viewVSNTransactionsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LastNameSort" runat="server">SURNAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_FIRSTNAMESorter" field="Sorter_FIRSTNAME" OwnerState="<%# viewVSNTransactionsData.SortField.ToString()%>" OwnerDir="<%# viewVSNTransactionsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FIRSTNAMESort" runat="server">FIRST NAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_MiddleNameSorter" field="Sorter_MiddleName" OwnerState="<%# viewVSNTransactionsData.SortField.ToString()%>" OwnerDir="<%# viewVSNTransactionsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_MiddleNameSort" runat="server">MiddleName</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_BirthDateSorter" field="Sorter_BirthDate" OwnerState="<%# viewVSNTransactionsData.SortField.ToString()%>" OwnerDir="<%# viewVSNTransactionsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_BirthDateSort" runat="server">BirthDate</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_GenderSorter" field="Sorter_Gender" OwnerState="<%# viewVSNTransactionsData.SortField.ToString()%>" OwnerDir="<%# viewVSNTransactionsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_GenderSort" runat="server">Sex</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_VSN1Sorter" field="Sorter_VSN1" OwnerState="<%# viewVSNTransactionsData.SortField.ToString()%>" OwnerDir="<%# viewVSNTransactionsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_VSN1Sort" runat="server">VSN</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_BatchIDSorter" field="Sorter_BatchID" OwnerState="<%# viewVSNTransactionsData.SortField.ToString()%>" OwnerDir="<%# viewVSNTransactionsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_BatchIDSort" runat="server">BatchID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>&nbsp; 
          <CC:Sorter id="Sorter_SequenceNoSorter" field="Sorter_SequenceNo" OwnerState="<%# viewVSNTransactionsData.SortField.ToString()%>" OwnerDir="<%# viewVSNTransactionsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SequenceNoSort" runat="server">SeqNum</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>&nbsp; 
          <CC:Sorter id="Sorter_TypeSorter" field="Sorter_Type" OwnerState="<%# viewVSNTransactionsData.SortField.ToString()%>" OwnerDir="<%# viewVSNTransactionsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_TypeSort" runat="server">Type</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>&nbsp; 
          <CC:Sorter id="Sorter_MessageSorter" field="Sorter_Message" OwnerState="<%# viewVSNTransactionsData.SortField.ToString()%>" OwnerDir="<%# viewVSNTransactionsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_MessageSort" runat="server">Message</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
          <th>&nbsp; 
          <CC:Sorter id="Sorter_ExceptionIDSorter" field="Sorter_ExceptionID" OwnerState="<%# viewVSNTransactionsData.SortField.ToString()%>" OwnerDir="<%# viewVSNTransactionsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ExceptionIDSort" runat="server">VSRRegDate</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
          <th>&nbsp; 
          <CC:Sorter id="Sorter_VSRRegisterrationDateSorter" field="Sorter_VSRRegisterrationDate" OwnerState="<%# viewVSNTransactionsData.SortField.ToString()%>" OwnerDir="<%# viewVSNTransactionsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_VSRRegisterrationDateSort" runat="server">ExceptionID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="TEXT-ALIGN: right"><a id="viewVSNTransactionsSTUDENT_ID" href="" runat="server"  ><%#(CType(Container.DataItem,viewVSNTransactionsItem)).STUDENT_ID.GetFormattedValue()%></a></td> 
          <td><asp:Literal id="viewVSNTransactionsLastName" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNTransactionsItem)).LastName.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td><asp:Literal id="viewVSNTransactionsFIRSTNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNTransactionsItem)).FIRSTNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td><asp:Literal id="viewVSNTransactionsMiddleName" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNTransactionsItem)).MiddleName.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="viewVSNTransactionsBirthDate" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNTransactionsItem)).BirthDate.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewVSNTransactionsSex" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNTransactionsItem)).Sex.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td ><asp:Literal id="viewVSNTransactionsVSN" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNTransactionsItem)).VSN.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="viewVSNTransactionsBatchID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNTransactionsItem)).BatchID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="viewVSNTransactionsSeqNum" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNTransactionsItem)).SeqNum.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewVSNTransactionsType" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNTransactionsItem)).Type.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewVSNTransactionsMessage" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNTransactionsItem)).Message.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="viewVSNTransactionsVSRRegisterrationDate" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNTransactionsItem)).VSRRegisterrationDate.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="viewVSNTransactionsExceptionID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewVSNTransactionsItem)).ExceptionID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <SeparatorTemplate>
	
        <tr class="Separator">
          <td colspan="13"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
        </tr>
        
  </SeparatorTemplate>
  <FooterTemplate>
	
        
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="13">No records - try changing the search criteria </td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="13">
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# viewVSNTransactionsData.PagesCount%>" PageSize="<%# viewVSNTransactionsData.RecordsPerPage%>" PageNumber="<%# viewVSNTransactionsData.PageNumber%>" runat="server">
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

