<!--ASPX page @1-7D426B1B-->
    <%@ Page language="vb" CodeFile="REF_MODULE_CODES.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.REF_MODULE_CODES.REF_MODULE_CODESPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.REF_MODULE_CODES" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Footer" Src="Footer.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 5.1.0.18696"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>MODULE CODES</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_REF_MODULE_CODES2_Button_Cancel_OnClick @48-3581936B
function page_REF_MODULE_CODES2_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_REF_MODULE_CODES2_Button_Cancel_OnClick

//Handle Condition1 @74-02594818
function Condition1_start(sender) {
//End Handle Condition1

//Custom Condition1 @74-67288CCD
    if (true==(params["click"] == "link"))
    {
    } else {
    }
//End Custom Condition1

//Condition1 Tail @74-FCB6E20C
}
//End Condition1 Tail

//Handle Condition2 @79-2B91FCEA
function Condition2_start(sender) {
//End Handle Condition2

//Custom Condition2 @79-D34BA941
    if (true==(params["click"] == "submit" && $("#ErrorBlock").length == 0))
    {
    } else {
    }
//End Custom Condition2

//Condition2 Tail @79-FCB6E20C
}
//End Condition2 Tail

//Handle Condition3 @84-85F96D7B
function Condition3_start(sender) {
//End Handle Condition3

//Custom Condition3 @84-3ACAA933
    if (true==(params["click"] = "link"))
    {
    } else {
    }
//End Custom Condition3

//Condition3 Tail @84-FCB6E20C
}
//End Condition3 Tail

//Handle Condition4 @95-7800950E
function Condition4_start(sender) {
//End Handle Condition4

//Custom Condition4 @95-3B4E074B
    if (true==(params["click"] = "submit"))
    {
    } else {
    }
//End Custom Condition4

//Condition4 Tail @95-FCB6E20C
}
//End Condition4 Tail

//Handle Condition5 @101-D668049F
function Condition5_start(sender) {
//End Handle Condition5

//Custom Condition5 @101-CECB318E
    if (true==(params["click"] = ""))
    {
    } else {
    }
//End Custom Condition5

//Condition5 Tail @101-FCB6E20C
}
//End Condition5 Tail

//bind_events @1-92FEABDB
function bind_events() {
    addEventHandler("REF_MODULE_CODES1REF_MODULE_CODES1_Insert", "click", Condition3_start);
    addEventHandler("REF_MODULE_CODES1Detail", "click", Condition3_start);
    addEventHandler("REF_MODULE_CODES2", "submit", Condition4_start);
    addEventHandler("REF_MODULE_CODES2Button_Cancel","click",page_REF_MODULE_CODES2_Button_Cancel_OnClick);
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

	<asp:PlaceHolder id="Panel1" Visible="true" runat="server">
	

  <span id="REF_MODULE_CODESSearchHolder" runat="server">
    


  <table class="MainTable" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td valign="top">
        <table class="Header" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Search </th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="REF_MODULE_CODESSearchError" visible="False" runat="server">
  
          <tr id="<%=PageVariables.Get("@error-block")%>" class="Error">
            <td colspan="2"><asp:Label ID="REF_MODULE_CODESSearchErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>Keyword</th>
 
            <td><asp:TextBox id="REF_MODULE_CODESSearchs_keyword" maxlength="50" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td><a id="REF_MODULE_CODESSearchClearParameters" href="" runat="server"  >Clear</a></td> 
            <td style="TEXT-ALIGN: right">
              <input id='REF_MODULE_CODESSearchButton_DoSearch' type="submit" class="Button" value="Search" OnServerClick='REF_MODULE_CODESSearch_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  
<p><a id="REF_MODULE_CODES1_Insert" href="" runat="server"  >Add New</a></p>

<asp:repeater id="REF_MODULE_CODES1Repeater" OnItemCommand="REF_MODULE_CODES1ItemCommand" OnItemDataBound="REF_MODULE_CODES1ItemDataBound" runat="server">
  <HeaderTemplate>
	
<table id="Panel1REF_MODULE_CODES1" class="MainTable" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
      <table class="Header" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>MODULE CODES </th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Row">
          <td colspan="8">Total Records:&nbsp;<asp:Literal id="REF_MODULE_CODES1REF_MODULE_CODES1_TotalRecords" runat="server"/></td>
        </tr>
 
        <tr class="Caption">
          <th>&nbsp;</th>
 
          <th>
          <CC:Sorter id="Sorter_MODULE_CODESorter" field="Sorter_MODULE_CODE" OwnerState="<%# REF_MODULE_CODES1Data.SortField.ToString()%>" OwnerDir="<%# REF_MODULE_CODES1Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_MODULE_CODESort" runat="server">MODULE CODE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_MODULE_LABELSorter" field="Sorter_MODULE_LABEL" OwnerState="<%# REF_MODULE_CODES1Data.SortField.ToString()%>" OwnerDir="<%# REF_MODULE_CODES1Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_MODULE_LABELSort" runat="server">MODULE LABEL</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SEMESTERSorter" field="Sorter_SEMESTER" OwnerState="<%# REF_MODULE_CODES1Data.SortField.ToString()%>" OwnerDir="<%# REF_MODULE_CODES1Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_SEMESTERSort" runat="server">SEMESTER</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_PRIMARY_FLAGSorter" field="Sorter_PRIMARY_FLAG" OwnerState="<%# REF_MODULE_CODES1Data.SortField.ToString()%>" OwnerDir="<%# REF_MODULE_CODES1Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_PRIMARY_FLAGSort" runat="server">PRIMARY FLAG</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_STATUSSorter" field="Sorter_STATUS" OwnerState="<%# REF_MODULE_CODES1Data.SortField.ToString()%>" OwnerDir="<%# REF_MODULE_CODES1Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_STATUSSort" runat="server">STATUS</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# REF_MODULE_CODES1Data.SortField.ToString()%>" OwnerDir="<%# REF_MODULE_CODES1Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# REF_MODULE_CODES1Data.SortField.ToString()%>" OwnerDir="<%# REF_MODULE_CODES1Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td><a id="REF_MODULE_CODES1Detail" href="" runat="server"  >Detail</a>&nbsp;</td> 
          <td><asp:Literal id="REF_MODULE_CODES1MODULE_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REF_MODULE_CODES1Item)).MODULE_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="REF_MODULE_CODES1MODULE_LABEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REF_MODULE_CODES1Item)).MODULE_LABEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="REF_MODULE_CODES1SEMESTER" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REF_MODULE_CODES1Item)).SEMESTER.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="REF_MODULE_CODES1PRIMARY_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REF_MODULE_CODES1Item)).PRIMARY_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="REF_MODULE_CODES1STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REF_MODULE_CODES1Item)).STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="REF_MODULE_CODES1LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REF_MODULE_CODES1Item)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="REF_MODULE_CODES1LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,REF_MODULE_CODES1Item)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="8">No Modules found!</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="8"><a id="REF_MODULE_CODES1REF_MODULE_CODES1_Insert" href="" runat="server"  >Add New</a>&nbsp; 
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# REF_MODULE_CODES1Data.PagesCount%>" PageSize="<%# REF_MODULE_CODES1Data.RecordsPerPage%>" PageNumber="<%# REF_MODULE_CODES1Data.PageNumber%>" runat="server"><span class="Navigator">Records per page 
            <CC:PageSizer AutoPostBack="true" runat="server" />
 
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img src="Styles/Blueprint/Images/First.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="FirstOff" runat="server"><img src="Styles/Blueprint/Images/FirstOff.gif"></CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img src="Styles/Blueprint/Images/Prev.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOff" runat="server"><img src="Styles/Blueprint/Images/PrevOff.gif"></CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %> of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img src="Styles/Blueprint/Images/Next.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="NextOff" runat="server"><img src="Styles/Blueprint/Images/NextOff.gif"></CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img src="Styles/Blueprint/Images/Last.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOff" runat="server"><img src="Styles/Blueprint/Images/LastOff.gif"></CC:NavigatorItem></span></CC:Navigator>
&nbsp;</td>
        </tr>
      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
<br>

	<asp:PlaceHolder id="Panel2" Visible="true" runat="server">
	

  <span id="REF_MODULE_CODES2Holder" runat="server">
    


  <table class="MainTable" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td valign="top">
        <table class="Header" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Add/Edit MODULE CODES </th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="REF_MODULE_CODES2Error" visible="False" runat="server">
  
          <tr id="ErrorBlock" class="Error">
            <td colspan="2"><asp:Label ID="REF_MODULE_CODES2ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>Module Code</th>
 
            <td><asp:TextBox id="REF_MODULE_CODES2MODULE_CODE" maxlength="50" Columns="50"	runat="server"/><asp:Literal id="REF_MODULE_CODES2lblMODULE_CODE" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Module Label</th>
 
            <td><asp:TextBox id="REF_MODULE_CODES2MODULE_LABEL" maxlength="50" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Sub school?</th>
 
            <td>
              <asp:RadioButtonList id="REF_MODULE_CODES2PRIMARY_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Status</th>
 
            <td>
              <asp:RadioButtonList id="REF_MODULE_CODES2STATUS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td style="TEXT-ALIGN: right" colspan="2">
              <input id='REF_MODULE_CODES2Button_Insert' type="submit" class="Button" value="Add" OnServerClick='REF_MODULE_CODES2_Insert' runat="server"/>
              <input id='REF_MODULE_CODES2Button_Update' type="submit" class="Button" value="Save" OnServerClick='REF_MODULE_CODES2_Update' runat="server"/>
              <input id='REF_MODULE_CODES2Button_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='REF_MODULE_CODES2_Cancel' runat="server"/>
  <input id="REF_MODULE_CODES2SEMESTER" type="hidden"  runat="server"/>
  
  <input id="REF_MODULE_CODES2LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="REF_MODULE_CODES2LAST_ALTERED_DATE" type="hidden"  runat="server"/>
  </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  
	</asp:PlaceHolder>
	<br>

	</asp:PlaceHolder>
	
<p></p>
<p><DECV_PROD2007:Footer id="Footer" runat="server"/></p>

</form>
</body>
</html>

<!--End ASPX page-->

