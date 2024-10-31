<!--ASPX page @1-3F9D8C7A-->
    <%@ Page language="vb" CodeFile="popup_StudentSearch.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.popup_StudentSearch.popup_StudentSearchPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.popup_StudentSearch" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>popup_StudentSearch</title>


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
//DEL  </script>
//DEL  <script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
//DEL  <script language="JavaScript" type="text/javascript">
//DEL    

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

//Set Focus @32-3C03DA85
    if (theForm.STUDENT_STUDENT_ENROLMENTs_SURNAME) theForm.STUDENT_STUDENT_ENROLMENTs_SURNAME.focus();
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


<div align="right">
<a href="#" onclick="window.close();">close window</a> 
</div>
<br>

  <span id="STUDENT_STUDENT_ENROLMENTHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Search for Student by Surname</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="STUDENT_STUDENT_ENROLMENTError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="STUDENT_STUDENT_ENROLMENTErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>SURNAME</th>
 
            <td><asp:TextBox id="STUDENT_STUDENT_ENROLMENTs_SURNAME" maxlength="30" Columns="30"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='STUDENT_STUDENT_ENROLMENTButton_DoSearch' class="Button" type="submit" value="Search" OnServerClick='STUDENT_STUDENT_ENROLMENT_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>

<asp:repeater id="STUDENT_STUDENT_ENROLMENT1Repeater" OnItemCommand="STUDENT_STUDENT_ENROLMENT1ItemCommand" OnItemDataBound="STUDENT_STUDENT_ENROLMENT1ItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
          <th>List of Students</th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_STUDENT_STUDENT_IDSorter" field="Sorter_STUDENT_STUDENT_ID" OwnerState="<%# STUDENT_STUDENT_ENROLMENT1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_STUDENT_ENROLMENT1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STUDENT_STUDENT_IDSort" runat="server">STUDENT ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# STUDENT_STUDENT_ENROLMENT1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_STUDENT_ENROLMENT1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">SURNAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_FIRST_NAMESorter" field="Sorter_FIRST_NAME" OwnerState="<%# STUDENT_STUDENT_ENROLMENT1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_STUDENT_ENROLMENT1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FIRST_NAMESort" runat="server">FIRST NAME</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_YEAR_LEVELSorter" field="Sorter_YEAR_LEVEL" OwnerState="<%# STUDENT_STUDENT_ENROLMENT1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_STUDENT_ENROLMENT1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_YEAR_LEVELSort" runat="server">YEAR LEVEL</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SEXSorter" field="Sorter_SEX" OwnerState="<%# STUDENT_STUDENT_ENROLMENT1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_STUDENT_ENROLMENT1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SEXSort" runat="server">SEX</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_ENROLMENT_YEARSorter" field="Sorter_ENROLMENT_YEAR" OwnerState="<%# STUDENT_STUDENT_ENROLMENT1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_STUDENT_ENROLMENT1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ENROLMENT_YEARSort" runat="server">ENROLMENT YEAR</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr  <CC:AttributeBinder runat="server" Name="rowStyle" ContainerId="STUDENT_STUDENT_ENROLMENT1Repeater"/>>
          <td style="TEXT-ALIGN: right"><a id="STUDENT_STUDENT_ENROLMENT1STUDENT_STUDENT_ID" href="" onclick="SetOpenerValue(this);return false;" runat="server"  ><%#(CType(Container.DataItem,STUDENT_STUDENT_ENROLMENT1Item)).STUDENT_STUDENT_ID.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_STUDENT_ENROLMENT1SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_STUDENT_ENROLMENT1Item)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_STUDENT_ENROLMENT1FIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_STUDENT_ENROLMENT1Item)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="STUDENT_STUDENT_ENROLMENT1YEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_STUDENT_ENROLMENT1Item)).YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_STUDENT_ENROLMENT1SEX" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_STUDENT_ENROLMENT1Item)).SEX.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="STUDENT_STUDENT_ENROLMENT1ENROLMENT_YEAR" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_STUDENT_ENROLMENT1Item)).ENROLMENT_YEAR.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="6">No Student Details found</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="6">
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# STUDENT_STUDENT_ENROLMENT1Data.PagesCount%>" PageSize="<%# STUDENT_STUDENT_ENROLMENT1Data.RecordsPerPage%>" PageNumber="<%# STUDENT_STUDENT_ENROLMENT1Data.PageNumber%>" runat="server">
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img src="Styles/Blueprint/Images/en/ButtonPrev.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOff" runat="server"><img src="Styles/Blueprint/Images/en/ButtonPrevOff.gif" border="0"></CC:NavigatorItem>
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img src="Styles/Blueprint/Images/en/ButtonNext.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="NextOff" runat="server"><img src="Styles/Blueprint/Images/en/ButtonNextOff.gif" border="0"></CC:NavigatorItem></CC:Navigator>
</td>
        </tr>
      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
<br>
<br>
<br>
<p></p>

</form>
</body>
</html>

<!--End ASPX page-->

