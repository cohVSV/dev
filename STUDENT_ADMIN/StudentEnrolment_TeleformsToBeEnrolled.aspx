<!--ASPX page @1-890865F5-->
    <%@ Page language="vb" CodeFile="StudentEnrolment_TeleformsToBeEnrolled.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.StudentEnrolment_TeleformsToBeEnrolled.StudentEnrolment_TeleformsToBeEnrolledPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.StudentEnrolment_TeleformsToBeEnrolled" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 4.01.00.06" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>StudentEnrolment_TeleformsToBeEnrolled</title>


<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-12DCE9BA
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Include User Scripts @1-DBA5BC7A
</script>
<script language="JavaScript" src="js/pt/prototype.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/pt/ajaxpanel.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include User Scripts

//Start Panel1 @3-C2C50D0F
function Panel1_start(sender) {
    var panel = $("Panel1");
    panel.onrefresh = function() {
    };
    AjaxPanel.init(panel);
    AjaxPanel._bind(panel);
    Panel1_bind(sender);
}
//End Start Panel1

//Refresh Panel1 @3-D0523501
function Panel1_bind(sender) {
}
//End Refresh Panel1

//Refresh UpdatePanel @4-3FE35307
function UpdatePanel_refresh(sender) {
    AjaxPanel.reload($("Panel1"));
}
//End Refresh UpdatePanel

//bind_events @1-A5AC7A5B
function bind_events() {
    Panel1_start(window);
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

window.onload = bind_events; 

//End CCS script
</script>
<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">

</head>
<body>
<form runat="server">


<p align="center"><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p>
<div id="Panel1">
	<asp:PlaceHolder id="Panel1" Visible="true" runat="server">
	&nbsp;&nbsp; 

  <span id="TMP_STUDENTSearchHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Search Teleforms Students</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="TMP_STUDENTSearchError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="TMP_STUDENTSearchErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>Surname or First Name</th>
 
            <td><asp:TextBox id="TMP_STUDENTSearchs_keyword" maxlength="30" Columns="30"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='TMP_STUDENTSearchButton_DoSearch' class="Button" type="submit" value="Search" OnServerClick='TMP_STUDENTSearch_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>

<asp:repeater id="NewEditableGrid1Repeater" OnItemCommand="NewEditableGrid1ItemCommand" OnItemDataBound="NewEditableGrid1ItemDataBound" runat="server">
  <HeaderTemplate>
  


  
	<script language="JavaScript" >
	var NewEditableGrid1Elements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initNewEditableGrid1Elements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	&nbsp; 
  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>List of Teleforms Students</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Grid" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="NewEditableGrid1Error" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="8"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Row">
            <td colspan="8">Total Records:&nbsp;<asp:Literal id="NewEditableGrid1NewEditableGrid1_TotalRecords" runat="server"/></td>
          </tr>
 
          <tr class="Caption">
            <th>STUDENT ID</th>
 
            <th>SURNAME</th>
 
            <th>FIRST NAME</th>
 
            <th>BIRTH DATE</th>
 
            <th>CATEGORY CODE</th>
 
            <th>LAST ALTERED DATE</th>
 
            <th>TELEFORM STATUS</th>
 
            <th></th>
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
    
          
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
          <tr class="Error">
            <td colspan="8"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Row">
            <td><asp:Literal id="NewEditableGrid1STUDENT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewEditableGrid1Item)).STUDENT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="NewEditableGrid1SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewEditableGrid1Item)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="NewEditableGrid1FIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewEditableGrid1Item)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="NewEditableGrid1BIRTH_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewEditableGrid1Item)).BIRTH_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="NewEditableGrid1CATEGORY_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewEditableGrid1Item)).CATEGORY_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ &nbsp;<asp:Literal id="NewEditableGrid1SUBCATEGORY_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewEditableGrid1Item)).SUBCATEGORY_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td><asp:Literal id="NewEditableGrid1LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewEditableGrid1Item)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="NewEditableGrid1TELEFORM_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewEditableGrid1Item)).TELEFORM_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td>
  <input id="NewEditableGrid1TMP_STUDENT_ID"  value='<%# (CType(Container.DataItem,NewEditableGrid1Item)).TMP_STUDENT_ID.GetFormattedValue() %>' type="hidden"  runat="server"/>
  &nbsp;&nbsp;
              <asp:Button id="NewEditableGrid1Button1" CssClass="Button" Text="Button1" runat="server"/>&nbsp; </td>
          </tr>
 
  </ItemTemplate>

  <FooterTemplate>
	
          
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
          <tr class="NoRecords">
            <td colspan="8">No Teleforms Details found</td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Footer">
            <td style="TEXT-ALIGN: right" colspan="8">
              
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# NewEditableGrid1Data.PagesCount%>" PageSize="<%# NewEditableGrid1Data.RecordsPerPage%>" PageNumber="<%# NewEditableGrid1Data.PageNumber%>" runat="server">
              <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img src="Styles/Blueprint/Images/First.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="FirstOff" runat="server"><img src="Styles/Blueprint/Images/FirstOff.gif" border="0"></CC:NavigatorItem>
              <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img src="Styles/Blueprint/Images/Prev.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="PrevOff" runat="server"><img src="Styles/Blueprint/Images/PrevOff.gif" border="0"></CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %> of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
              <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img src="Styles/Blueprint/Images/Next.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="NextOff" runat="server"><img src="Styles/Blueprint/Images/NextOff.gif" border="0"></CC:NavigatorItem>
              <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img src="Styles/Blueprint/Images/Last.gif" border="0"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="LastOff" runat="server"><img src="Styles/Blueprint/Images/LastOff.gif" border="0"></CC:NavigatorItem></CC:Navigator>
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

	</asp:PlaceHolder>
	</div></p>
<p>&nbsp;</p>
<p>&nbsp;</p>

</form>
</body>
</html>

<!--End ASPX page-->

