<!--ASPX page @1-B8B96EF6-->
    <%@ Page language="vb" CodeFile="popup_StudentSubjectSearch.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.popup_StudentSubjectSearch.popup_StudentSubjectSearchPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.popup_StudentSubjectSearch" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>popup_StudentSubjectSearch</title>


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


// name of return field
var retFieldName = gup('returncontrol');
var getSearchValue = gup('p_STUDENTID');


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

//Set Focus @46-74631056
    if (theForm.STUDENT_SUBJECT_SUBJECTs_STUDENT_ID) theForm.STUDENT_SUBJECT_SUBJECTs_STUDENT_ID.focus();
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


<p>&nbsp;</p>
<div align="right">
<a href="#" onclick="window.close();">close window</a> 
</div>
<br>

  <span id="STUDENT_SUBJECT_SUBJECTHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Search for Subjects by Student ID</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="STUDENT_SUBJECT_SUBJECTError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="STUDENT_SUBJECT_SUBJECTErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>STUDENT ID</th>
 
            <td><asp:TextBox id="STUDENT_SUBJECT_SUBJECTs_STUDENT_ID" maxlength="12" Columns="12"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='STUDENT_SUBJECT_SUBJECTButton_DoSearch' class="Button" type="submit" value="Search" OnServerClick='STUDENT_SUBJECT_SUBJECT_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>

<asp:repeater id="STUDENT_SUBJECT_SUBJECT1Repeater" OnItemCommand="STUDENT_SUBJECT_SUBJECT1ItemCommand" OnItemDataBound="STUDENT_SUBJECT_SUBJECT1ItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
          <th>List of Subjects for Student</th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_STUDENT_SUBJECT_SUBJECT_IDSorter" field="Sorter_STUDENT_SUBJECT_SUBJECT_ID" OwnerState="<%# STUDENT_SUBJECT_SUBJECT1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_SUBJECT_SUBJECT1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STUDENT_SUBJECT_SUBJECT_IDSort" runat="server">SUBJECT ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SUBJECT_ABBREVSorter" field="Sorter_SUBJECT_ABBREV" OwnerState="<%# STUDENT_SUBJECT_SUBJECT1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_SUBJECT_SUBJECT1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBJECT_ABBREVSort" runat="server">ABBREV</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SUBJECT_TITLESorter" field="Sorter_SUBJECT_TITLE" OwnerState="<%# STUDENT_SUBJECT_SUBJECT1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_SUBJECT_SUBJECT1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBJECT_TITLESort" runat="server">TITLE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SEMESTERSorter" field="Sorter_SEMESTER" OwnerState="<%# STUDENT_SUBJECT_SUBJECT1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_SUBJECT_SUBJECT1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SEMESTERSort" runat="server">SEMESTER</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_YEAR_LEVELSorter" field="Sorter_YEAR_LEVEL" OwnerState="<%# STUDENT_SUBJECT_SUBJECT1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_SUBJECT_SUBJECT1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_YEAR_LEVELSort" runat="server">YEAR LEVEL</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SUBJ_ENROL_STATUSSorter" field="Sorter_SUBJ_ENROL_STATUS" OwnerState="<%# STUDENT_SUBJECT_SUBJECT1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_SUBJECT_SUBJECT1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBJ_ENROL_STATUSSort" runat="server">SUBJ ENROL STATUS</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_STAFF_IDSorter" field="Sorter_STAFF_ID" OwnerState="<%# STUDENT_SUBJECT_SUBJECT1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_SUBJECT_SUBJECT1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STAFF_IDSort" runat="server">STAFF ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_ENROLMENT_DATESorter" field="Sorter_ENROLMENT_DATE" OwnerState="<%# STUDENT_SUBJECT_SUBJECT1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_SUBJECT_SUBJECT1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ENROLMENT_DATESort" runat="server">ENROLMENT DATE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_WITHDRAWAL_DATESorter" field="Sorter_WITHDRAWAL_DATE" OwnerState="<%# STUDENT_SUBJECT_SUBJECT1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_SUBJECT_SUBJECT1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_WITHDRAWAL_DATESort" runat="server">WITHDRAWAL DATE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_ENROLMENT_YEARSorter" field="Sorter_ENROLMENT_YEAR" OwnerState="<%# STUDENT_SUBJECT_SUBJECT1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_SUBJECT_SUBJECT1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ENROLMENT_YEARSort" runat="server">ENROLMENT YEAR</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr  <CC:AttributeBinder runat="server" Name="rowStyle" ContainerId="STUDENT_SUBJECT_SUBJECT1Repeater"/>>
          <td style="TEXT-ALIGN: right"><a id="STUDENT_SUBJECT_SUBJECT1STUDENT_SUBJECT_SUBJECT_ID" href="" onclick="SetOpenerValue(this);return false;" runat="server"  ><%#(CType(Container.DataItem,STUDENT_SUBJECT_SUBJECT1Item)).STUDENT_SUBJECT_SUBJECT_ID.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_SUBJECT_SUBJECT1SUBJECT_ABBREV" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_SUBJECT_SUBJECT1Item)).SUBJECT_ABBREV.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_SUBJECT_SUBJECT1SUBJECT_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_SUBJECT_SUBJECT1Item)).SUBJECT_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_SUBJECT_SUBJECT1SEMESTER" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_SUBJECT_SUBJECT1Item)).SEMESTER.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="STUDENT_SUBJECT_SUBJECT1YEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_SUBJECT_SUBJECT1Item)).YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_SUBJECT_SUBJECT1SUBJ_ENROL_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_SUBJECT_SUBJECT1Item)).SUBJ_ENROL_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_SUBJECT_SUBJECT1STAFF_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_SUBJECT_SUBJECT1Item)).STAFF_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_SUBJECT_SUBJECT1ENROLMENT_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_SUBJECT_SUBJECT1Item)).ENROLMENT_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_SUBJECT_SUBJECT1WITHDRAWAL_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_SUBJECT_SUBJECT1Item)).WITHDRAWAL_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="STUDENT_SUBJECT_SUBJECT1ENROLMENT_YEAR" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_SUBJECT_SUBJECT1Item)).ENROLMENT_YEAR.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="10">No Subjects found</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="10">
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# STUDENT_SUBJECT_SUBJECT1Data.PagesCount%>" PageSize="<%# STUDENT_SUBJECT_SUBJECT1Data.RecordsPerPage%>" PageNumber="<%# STUDENT_SUBJECT_SUBJECT1Data.PageNumber%>" runat="server">
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
<p></p>

</form>
</body>
</html>

<!--End ASPX page-->

