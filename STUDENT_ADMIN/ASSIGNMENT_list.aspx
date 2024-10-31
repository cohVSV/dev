<!--ASPX page @1-3CCA6C8D-->
    <%@ Page language="vb" CodeFile="ASSIGNMENT_list.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.ASSIGNMENT_list.ASSIGNMENT_listPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.ASSIGNMENT_list" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>ASSIGNMENT</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
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

//Set Focus @18-8B2229BF
    if (theForm.ASSIGNMENTSearchs_SUBJECT_ID) theForm.ASSIGNMENTSearchs_SUBJECT_ID.focus();
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
<p align="right"><a id="Link1" href="" class="Button" runat="server"  >Add New Assignment</a></p>
<p>

  <span id="ASSIGNMENTSearchHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Search ASSIGNMENTS</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="ASSIGNMENTSearchError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="ASSIGNMENTSearchErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>SUBJECT ID</th>
 
            <td><asp:TextBox id="ASSIGNMENTSearchs_SUBJECT_ID" maxlength="10" Columns="10"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='ASSIGNMENTSearchButton_DoSearch' class="Button" type="submit" value="Search" OnServerClick='ASSIGNMENTSearch_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>

<asp:repeater id="ASSIGNMENTRepeater" OnItemCommand="ASSIGNMENTItemCommand" OnItemDataBound="ASSIGNMENTItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" align="center" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
          <th>List of ASSIGNMENTS for Subject&nbsp;</th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Row">
          <td colspan="6">Total Records:&nbsp;<asp:Literal id="ASSIGNMENTASSIGNMENT_TotalRecords" runat="server"/>&nbsp;&nbsp; Subject: <asp:Literal id="ASSIGNMENTlblSubjectID" runat="server"/>&nbsp;: <asp:Literal id="ASSIGNMENTlblSubjectName" runat="server"/></td>
        </tr>
 
        <tr class="Caption">
          <th>ASSIGNMENT ID</th>
 
          <th>DESCRIPTION</th>
 
          <th>ACTIVE</th>
 
          <th>LAST ALTERED BY</th>
 
          <th>LAST ALTERED DATE</th>
 
          <th>ARCHIVE</th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr  <CC:AttributeBinder runat="server" Name="rowStyle" ContainerId="ASSIGNMENTRepeater"/>>
          <td style="TEXT-ALIGN: right"><a id="ASSIGNMENTASSIGNMENT_ID" href="" runat="server"  ><%#(CType(Container.DataItem,ASSIGNMENTItem)).ASSIGNMENT_ID.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="ASSIGNMENTDESCRIPTION" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENTItem)).DESCRIPTION.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="ASSIGNMENTSTATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENTItem)).STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="ASSIGNMENTLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENTItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="ASSIGNMENTLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENTItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="ASSIGNMENTARCHIVE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENTItem)).ARCHIVE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="6">No Assignments found for this Subject</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="6">
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# ASSIGNMENTData.PagesCount%>" PageSize="<%# ASSIGNMENTData.RecordsPerPage%>" PageNumber="<%# ASSIGNMENTData.PageNumber%>" runat="server">
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
</p>
<p>&nbsp;</p>

</form>
</body>
</html>

<!--End ASPX page-->

