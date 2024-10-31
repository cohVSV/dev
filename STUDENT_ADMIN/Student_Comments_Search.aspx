<!--ASPX page @1-8AFBD0B0-->
    <%@ Page language="vb" CodeFile="Student_Comments_Search.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_Comments_Search.Student_Comments_SearchPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_Comments_Search" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 4.1.00.032"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Comments Search</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
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

//Set Focus @29-1B707007
    if (theForm.Search_Commentss_keywords) theForm.Search_Commentss_keywords.focus();
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
<p align="center">

  <span id="Search_CommentsHolder" runat="server">
    


  <table border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td valign="top">
        <table class="Header" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Search My Comments</th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <div align="center">
          <table class="Record" cellspacing="0" cellpadding="0" align="center">
            
  <asp:PlaceHolder id="Search_CommentsError" visible="False" runat="server">
  
            <tr class="Error">
              <td colspan="2"><asp:Label ID="Search_CommentsErrorLabel" runat="server"/></td>
            </tr>
            
  </asp:PlaceHolder>
  
            <tr class="Controls">
              <th>Keyword</th>
 
              <td><asp:TextBox id="Search_Commentss_keywords" maxlength="250" Columns="50"	runat="server"/></td>
            </tr>
 
            <tr class="Controls">
              <th>Starting</th>
 
              <td>
                <select id="Search_Commentss_monthsago"  runat="server"></select>
 &nbsp;</td>
            </tr>
 
            <tr class="Bottom">
              <td colspan="2" align="right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a id="Search_CommentsClearParameters" href="" runat="server"  >Clear</a>&nbsp;&nbsp;&nbsp;&nbsp; 
                <input id='Search_CommentsButton_DoSearch' type="submit" class="Button" value="Search" OnServerClick='Search_Comments_Search' runat="server"/></td>
            </tr>
 
            <tr class="Bottom">
              <td colspan="2" align="right">
                <p align="left">&nbsp;&nbsp;<a id="Search_CommentslinkAirHead" href="" class="Button" title="show Recent 50 comments" runat="server"  >&nbsp;Recent&nbsp;50&nbsp;</a></p>
              </td>
            </tr>
          </table>
        </div>
      </td>
    </tr>
  </table>



  </span>
  
<p></p>

<asp:repeater id="Grid_CommentsResultsRepeater" OnItemCommand="Grid_CommentsResultsItemCommand" OnItemDataBound="Grid_CommentsResultsItemDataBound" runat="server">
  <HeaderTemplate>
	
<table border="0" cellspacing="0" cellpadding="0" width="80%" align="center">
  <tr>
    <td valign="top">
      <table class="Header" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>Comments found <asp:Literal id="Grid_CommentsResultslblMostRecent50" runat="server"/></th>
 
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0" align="center">
        <tr class="Row">
          <td colspan="5">Total Records:&nbsp;<asp:Literal id="Grid_CommentsResultsGrid1_TotalRecords" runat="server"/></td>
        </tr>
 
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_STUDENT_IDSorter" field="Sorter_STUDENT_ID" OwnerState="<%# Grid_CommentsResultsData.SortField.ToString()%>" OwnerDir="<%# Grid_CommentsResultsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STUDENT_IDSort" runat="server">STUDENT ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_COMMENTSorter" field="Sorter_COMMENT" OwnerState="<%# Grid_CommentsResultsData.SortField.ToString()%>" OwnerDir="<%# Grid_CommentsResultsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_COMMENTSort" runat="server">COMMENT</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_COMMENT_TYPESorter" field="Sorter_COMMENT_TYPE" OwnerState="<%# Grid_CommentsResultsData.SortField.ToString()%>" OwnerDir="<%# Grid_CommentsResultsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_COMMENT_TYPESort" runat="server">COMMENT TYPE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# Grid_CommentsResultsData.SortField.ToString()%>" OwnerDir="<%# Grid_CommentsResultsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# Grid_CommentsResultsData.SortField.ToString()%>" OwnerDir="<%# Grid_CommentsResultsData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="TEXT-ALIGN: right"><a id="Grid_CommentsResultsSTUDENT_ID" href="" runat="server"  ><%#(CType(Container.DataItem,Grid_CommentsResultsItem)).STUDENT_ID.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="Grid_CommentsResultsCOMMENT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_CommentsResultsItem)).COMMENT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="Grid_CommentsResultsCOMMENT_TYPE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_CommentsResultsItem)).COMMENT_TYPE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="Grid_CommentsResultsLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_CommentsResultsItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="Grid_CommentsResultsLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_CommentsResultsItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="5">No Comments found!</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="5">
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# Grid_CommentsResultsData.PagesCount%>" PageSize="<%# Grid_CommentsResultsData.RecordsPerPage%>" PageNumber="<%# Grid_CommentsResultsData.PageNumber%>" runat="server">
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img border="0" src="Styles/Blueprint/Images/First.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="FirstOff" runat="server"><img border="0" src="Styles/Blueprint/Images/FirstOff.gif"></CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img border="0" src="Styles/Blueprint/Images/Prev.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOff" runat="server"><img border="0" src="Styles/Blueprint/Images/PrevOff.gif"></CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %> of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img border="0" src="Styles/Blueprint/Images/Next.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="NextOff" runat="server"><img border="0" src="Styles/Blueprint/Images/NextOff.gif"></CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img border="0" src="Styles/Blueprint/Images/Last.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOff" runat="server"><img border="0" src="Styles/Blueprint/Images/LastOff.gif"></CC:NavigatorItem></CC:Navigator>
&nbsp;</td>
        </tr>
      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>


<asp:repeater id="Grid_CommentsResults1Repeater" OnItemCommand="Grid_CommentsResults1ItemCommand" OnItemDataBound="Grid_CommentsResults1ItemDataBound" runat="server">
  <HeaderTemplate>
	
<table border="0" cellspacing="0" cellpadding="0" width="80%" align="center">
  <tr>
    <td valign="top">
      <table class="Header" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>Comments found for your keyword search </th>
 
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0" align="center">
        <tr class="Row">
          <td colspan="5">Total Records: <asp:Literal id="Grid_CommentsResults1Grid1_TotalRecords" runat="server"/></td>
        </tr>
 
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_STUDENT_IDSorter" field="Sorter_STUDENT_ID" OwnerState="<%# Grid_CommentsResults1Data.SortField.ToString()%>" OwnerDir="<%# Grid_CommentsResults1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STUDENT_IDSort" runat="server">STUDENT ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_COMMENTSorter" field="Sorter_COMMENT" OwnerState="<%# Grid_CommentsResults1Data.SortField.ToString()%>" OwnerDir="<%# Grid_CommentsResults1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_COMMENTSort" runat="server">COMMENT</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_COMMENT_TYPESorter" field="Sorter_COMMENT_TYPE" OwnerState="<%# Grid_CommentsResults1Data.SortField.ToString()%>" OwnerDir="<%# Grid_CommentsResults1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_COMMENT_TYPESort" runat="server">COMMENT TYPE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# Grid_CommentsResults1Data.SortField.ToString()%>" OwnerDir="<%# Grid_CommentsResults1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# Grid_CommentsResults1Data.SortField.ToString()%>" OwnerDir="<%# Grid_CommentsResults1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="TEXT-ALIGN: right"><a id="Grid_CommentsResults1STUDENT_ID" href="" runat="server"  ><%#(CType(Container.DataItem,Grid_CommentsResults1Item)).STUDENT_ID.GetFormattedValue()%></a> </td> 
          <td><asp:Literal id="Grid_CommentsResults1COMMENT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_CommentsResults1Item)).COMMENT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/> </td> 
          <td><asp:Literal id="Grid_CommentsResults1COMMENT_TYPE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_CommentsResults1Item)).COMMENT_TYPE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/> </td> 
          <td><asp:Literal id="Grid_CommentsResults1LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_CommentsResults1Item)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/> </td> 
          <td><asp:Literal id="Grid_CommentsResults1LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_CommentsResults1Item)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/> </td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="5">No Comments found!</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="5">
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# Grid_CommentsResults1Data.PagesCount%>" PageSize="<%# Grid_CommentsResults1Data.RecordsPerPage%>" PageNumber="<%# Grid_CommentsResults1Data.PageNumber%>" runat="server">
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img border="0" src="Styles/Blueprint/Images/First.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="FirstOff" runat="server"><img border="0" src="Styles/Blueprint/Images/FirstOff.gif"></CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img border="0" src="Styles/Blueprint/Images/Prev.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOff" runat="server"><img border="0" src="Styles/Blueprint/Images/PrevOff.gif"></CC:NavigatorItem><%# (CType(Container,Navigator)).PageNumber.ToString() %> of <%# (CType(Container,Navigator)).MaxPage.ToString() %> 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img border="0" src="Styles/Blueprint/Images/Next.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="NextOff" runat="server"><img border="0" src="Styles/Blueprint/Images/NextOff.gif"></CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img border="0" src="Styles/Blueprint/Images/Last.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOff" runat="server"><img border="0" src="Styles/Blueprint/Images/LastOff.gif"></CC:NavigatorItem></CC:Navigator>
</td>
        </tr>
      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
<br>

</form>
</body>
</html>

<!--End ASPX page-->

