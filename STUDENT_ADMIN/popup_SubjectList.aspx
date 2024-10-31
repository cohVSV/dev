<!--ASPX page @1-5B65F06C-->
    <%@ Page language="vb" CodeFile="popup_SubjectList.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.popup_SubjectList.popup_SubjectListPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.popup_SubjectList" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>popup_SubjectList</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript">

function gup( name )
{
        // used to read values from Querystring
  name = name.replace(/[\[]/,"\\\[").replace(/[\]]/,"\\\]");
  var regexS = "[\\?&]"+name+"=([^&#]*)";
  var regex = new RegExp( regexS );
  var results = regex.exec( window.location.href );
  if( results == null )
    return "";
  else
    return results[1];
}


// known, expected values are from the Teacher allocations, or Subject list
var retFieldName = gup('returncontrol');
//var retFieldName = 'TeacherAllocations_Searchs_SUBJECT_ID';


function SetOpenerValue(currentObj)
{
        var IE  = (document.all) ? 1 : 0;
        if(IE) {
                var selVal = currentObj.innerText; 
        } else {
                var selVal = currentObj.text;  
        }
        window.opener.document.getElementById(retFieldName).value = selVal;
        window.opener.focus();
        window.close();
}
</script>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<div align="right">
<a href="#" onclick="window.close();">close window</a> 
</div>

  <span id="SUBJECTSearchHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" width="60%" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Filter Subjects</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="SUBJECTSearchError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="SUBJECTSearchErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>YEAR LEVEL</th>
 
            <td>
              <select id="SUBJECTSearchs_YEAR_LEVEL"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='SUBJECTSearchButton_DoSearch' class="Button" type="submit" value="Search" OnServerClick='SUBJECTSearch_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>

<asp:repeater id="SUBJECTRepeater" OnItemCommand="SUBJECTItemCommand" OnItemDataBound="SUBJECTItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" width="80%" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
          <th>List of Subjects</th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_SUBJECT_IDSorter" field="Sorter_SUBJECT_ID" OwnerState="<%# SUBJECTData.SortField.ToString()%>" OwnerDir="<%# SUBJECTData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBJECT_IDSort" runat="server">ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SUBJECT_TITLESorter" field="Sorter_SUBJECT_TITLE" OwnerState="<%# SUBJECTData.SortField.ToString()%>" OwnerDir="<%# SUBJECTData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBJECT_TITLESort" runat="server">TITLE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td style="TEXT-ALIGN: right"><a id="SUBJECTSUBJECT_ID" href="" onclick="SetOpenerValue(this);return false;" runat="server"  ><%#(CType(Container.DataItem,SUBJECTItem)).SUBJECT_ID.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="SUBJECTSUBJECT_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECTItem)).SUBJECT_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <SeparatorTemplate>
	
        <tr class="Separator">
          <td colspan="2"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
        </tr>
        
  </SeparatorTemplate>
  <FooterTemplate>
	
        
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="2">No Subjects found</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="2">
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# SUBJECTData.PagesCount%>" PageSize="<%# SUBJECTData.RecordsPerPage%>" PageNumber="<%# SUBJECTData.PageNumber%>" runat="server">
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

</form>
</body>
</html>

<!--End ASPX page-->

