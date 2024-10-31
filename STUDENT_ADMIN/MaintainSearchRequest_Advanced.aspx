<!--ASPX page @1-D90E43B0-->
    <%@ Page language="vb" CodeFile="MaintainSearchRequest_Advanced.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.MaintainSearchRequest_Advanced.MaintainSearchRequest_AdvancedPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.MaintainSearchRequest_Advanced" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 4.1.00.032" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Maintain Search Request - Advanced</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Include User Scripts @1-76783C91
</script>
<script language="JavaScript" src="js/pt/prototype.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/pt/scriptaculous.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/pt/controls.js" type="text/javascript" charset="windows-1252"></script>
<link rel="stylesheet" type="text/css" href="MaintainSearchRequest_Advanced_style.css">
<script language="JavaScript" type="text/javascript">
//End Include User Scripts

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//Set Focus @62-719C21AF
    if (theForm.viewMaintainSearchRequests_SCHOOLNAME) theForm.viewMaintainSearchRequests_SCHOOLNAME.focus();
//End Set Focus
        result = true;  // ERA
//Close page_OnLoad @1-BC33A33A
    return result;
}
//End Close page_OnLoad

//Initialize viewMaintainSearchRequests_SCHOOLNAMEPTAutocomplete1 @60-5D949568
function viewMaintainSearchRequests_SCHOOLNAMEPTAutocomplete1_start() {
    if ($("viewMaintainSearchRequests_SCHOOLNAME"))
        new Ajax.Autocompleter("viewMaintainSearchRequests_SCHOOLNAME", "viewMaintainSearchRequests_SCHOOLNAME_choices", "services/MaintainSearchRequest_Advanced_viewMaintainSearchRequest_s_SCHOOLNAME_PTAutocomplete1.aspx", {});
}
//End Initialize viewMaintainSearchRequests_SCHOOLNAMEPTAutocomplete1

//Handle viewMaintainSearchRequestCondition1 @48-22A3BE89
function viewMaintainSearchRequestCondition1_start(sender) {
//End Handle viewMaintainSearchRequestCondition1

//Custom viewMaintainSearchRequestCondition1 @48-84D3DE00
        // ERA: kooky JS created from Wizard. Fixed by Eric
    if ($("viewMaintainSearchRequests_SCHOOLNAME").value != "")
    {
        viewMaintainSearchRequestPTAutoFill1_start(sender);
    } else {
    }
//End Custom viewMaintainSearchRequestCondition1

//viewMaintainSearchRequestCondition1 Tail @48-FCB6E20C
}
//End viewMaintainSearchRequestCondition1 Tail

//PTAutoFill1 Loading @54-613F2F45
function viewMaintainSearchRequestPTAutoFill1_start(sender) {
        // ERA fixing keyword selection as it grabbed the form, not the field
    new Ajax.Request("services/MaintainSearchRequest_Advanced_viewMaintainSearchRequest_s_SCHOOLNAME_PTAutoFill1.aspx?keyword=" + encodeURI($("viewMaintainSearchRequests_SCHOOLNAME").value), {
        method: "get",
        requestHeaders: ['If-Modified-Since', new Date(0)],
        onSuccess: function(transport) {
            var valuesRow = eval(transport.responseText)[0];
            $("viewMaintainSearchRequests_HOME_SCHOOL_ID").value = valuesRow["SCHOOL_ID"];
        }, 
        onFailure: function(transport) {
            alert(transport.responseText);
        }
    });
}
//End PTAutoFill1 Loading

//bind_events @1-EDEBB42E
function bind_events() {
    viewMaintainSearchRequests_SCHOOLNAMEPTAutocomplete1_start();       //ERA
    addEventHandler("viewMaintainSearchRequests_SCHOOLNAME", "focus", viewMaintainSearchRequestCondition1_start);//ERA
        addEventHandler("viewMaintainSearchRequests_SCHOOLNAME", "keyup", viewMaintainSearchRequestCondition1_start);//ERA
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

  <span id="viewMaintainSearchRequestHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Search&nbsp;Schools </th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="viewMaintainSearchRequestError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="viewMaintainSearchRequestErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>SCHOOL NAME&nbsp;</th>
 
            <td>
              <asp:TextBox id="viewMaintainSearchRequests_SCHOOLNAME" Columns="40" autocomplete="off"	runat="server"/>
              <!-- BEGINF PTAutocomplete PTAutocomplete1 -->
              <div id="viewMaintainSearchRequests_SCHOOLNAME_choices">
              </div>
              <!-- ENDF PTAutocomplete PTAutocomplete1 -->&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>ATTENDING SCHOOL ID *</th>
 
            <td><asp:TextBox id="viewMaintainSearchRequests_HOME_SCHOOL_ID" maxlength="8" Columns="8"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>ENROLMENT YEAR</th>
 
            <td><asp:TextBox id="viewMaintainSearchRequests_ENROLMENT_YEAR" maxlength="8" Columns="8"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td>
              <p align="left"><a id="viewMaintainSearchRequestLink1" href="" runat="server"  >Simple Search</a>&nbsp;</p>
            </td> 
            <td align="right"><a id="viewMaintainSearchRequestClearParameters" href="" runat="server"  >Clear</a> 
              <input id='viewMaintainSearchRequestButton_DoSearch' class="Button" type="submit" value="Search" OnServerClick='viewMaintainSearchRequest_Search' runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td>&nbsp;</td> 
            <td align="right">&nbsp;</td>
          </tr>
        </table>
        
  <input id="viewMaintainSearchRequesthidden_auto" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>



  </span>
  
<p><a id="LinkExportToExcel" href="" runat="server"  >Export to Excel</a> 
<p>
<p>

<asp:repeater id="viewMaintainSearchRequest1Repeater" OnItemCommand="viewMaintainSearchRequest1ItemCommand" OnItemDataBound="viewMaintainSearchRequest1ItemDataBound" runat="server">
  <HeaderTemplate>
	
<div align="right">
  <p><br>
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
          <tr class="Row">
            <td colspan="9">Total Records:&nbsp;<asp:Literal id="viewMaintainSearchRequest1viewMaintainSearchRequest1_TotalRecords" runat="server"/></td>
          </tr>
 
          <tr class="Caption">
            <th>
            <CC:Sorter id="Sorter_STUDENT_IDSorter" field="Sorter_STUDENT_ID" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STUDENT_IDSort" runat="server">STUDENT ID</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">SURNAME</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_FIRST_NAMESorter" field="Sorter_FIRST_NAME" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FIRST_NAMESort" runat="server">FIRST NAME</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_YEAR_LEVELSorter" field="Sorter_YEAR_LEVEL" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_YEAR_LEVELSort" runat="server">YEAR LEVEL</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_ENROLMENT_STATUSSorter" field="Sorter_ENROLMENT_STATUS" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ENROLMENT_STATUSSort" runat="server">ENROLMENT STATUS</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_ENROLMENT_DATESorter" field="Sorter_ENROLMENT_DATE" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ENROLMENT_DATESort" runat="server">ENROLMENT DATE</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_HOME_SCHOOL_IDSorter" field="Sorter_HOME_SCHOOL_ID" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_HOME_SCHOOL_IDSort" runat="server">HOME SCHOOL ID</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_ATTENDING_SCHOOL_IDSorter" field="Sorter_ATTENDING_SCHOOL_ID" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ATTENDING_SCHOOL_IDSort" runat="server">ATTENDING SCHOOL ID</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_ENROLMENT_YEARSorter" field="Sorter_ENROLMENT_YEAR" OwnerState="<%# viewMaintainSearchRequest1Data.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequest1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ENROLMENT_YEARSort" runat="server">ENROLMENT YEAR</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif" border="0"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif" border="0"></CC:SorterItem></CC:Sorter></th>
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
          <tr class="Row">
            <td style="TEXT-ALIGN: right"><a id="viewMaintainSearchRequest1STUDENT_ID" href="" runat="server"  ><%#(CType(Container.DataItem,viewMaintainSearchRequest1Item)).STUDENT_ID.GetFormattedValue()%></a>&nbsp;</td> 
            <td><asp:Literal id="viewMaintainSearchRequest1SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="viewMaintainSearchRequest1FIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td style="TEXT-ALIGN: right"><asp:Literal id="viewMaintainSearchRequest1YEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="viewMaintainSearchRequest1ENROLMENT_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).ENROLMENT_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="viewMaintainSearchRequest1ENROLMENT_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).ENROLMENT_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="viewMaintainSearchRequest1HOME_SCHOOL_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).HOME_SCHOOL_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="viewMaintainSearchRequest1ATTENDING_SCHOOL_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).ATTENDING_SCHOOL_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td style="TEXT-ALIGN: right"><asp:Literal id="viewMaintainSearchRequest1ENROLMENT_YEAR" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequest1Item)).ENROLMENT_YEAR.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
          </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
          
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
          <tr class="NoRecords">
            <td colspan="9">No Students found</td>
          </tr>
          
  </asp:PlaceHolder>

        </table>
      </td>
    </tr>
  </table>
  &nbsp; </p>
</div>

  </FooterTemplate>
</asp:repeater>
<br>
<br>
<p></p>

</form>
</body>
</html>

<!--End ASPX page-->

