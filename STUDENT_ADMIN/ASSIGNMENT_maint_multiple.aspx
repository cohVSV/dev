<!--ASPX page @1-95BF57BF-->
    <%@ Page language="vb" CodeFile="ASSIGNMENT_maint_multiple.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.ASSIGNMENT_maint_multiple.ASSIGNMENT_maint_multiplePage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.ASSIGNMENT_maint_multiple" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 5.1.0.18696"><meta name="description" content="Added 8-May-2014|EA| per unfuddle #581 to allow non-SysAdmin staff to edit the descriptions of Assignments."><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>ASSIGNMENT Maintain (Multiple)</title>



<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_ASSIGNMENTSearch_OnLoad @37-51605ABA
function page_ASSIGNMENTSearch_OnLoad(form)
{
    var result;
//End page_ASSIGNMENTSearch_OnLoad

//Set Focus @109-8B2229BF
    if (theForm.ASSIGNMENTSearchs_SUBJECT_ID) theForm.ASSIGNMENTSearchs_SUBJECT_ID.focus();
//End Set Focus

//Close page_ASSIGNMENTSearch_OnLoad @37-BC33A33A
    return result;
}
//End Close page_ASSIGNMENTSearch_OnLoad

//page_ASSIGNMENT_Cancel_OnClick @36-A63A9862
function page_ASSIGNMENT_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_ASSIGNMENT_Cancel_OnClick

//bind_events @1-EB16992C
function bind_events() {
    if(document.getElementById("ASSIGNMENTSearchHolder"))
    addEventHandler("ASSIGNMENTSearch","load",page_ASSIGNMENTSearch_OnLoad);
    addEventHandler("ASSIGNMENTCancel","click",page_ASSIGNMENT_Cancel_OnClick);
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

  <span id="ASSIGNMENTSearchHolder" runat="server">
    


  <table class="MainTable" cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Search </th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="ASSIGNMENTSearchError" visible="False" runat="server">
  
          <tr id="<%=PageVariables.Get("@error-block")%>" class="Error">
            <td colspan="2"><asp:Label ID="ASSIGNMENTSearchErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>Subject &nbsp;</th>
 
            <td>
              <select id="ASSIGNMENTSearchs_SUBJECT_ID_list"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th>SUBJECT ID</th>
 
            <td>
              <asp:TextBox id="ASSIGNMENTSearchs_SUBJECT_ID" maxlength="10" Columns="6"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>DESCRIPTION</th>
 
            <td>
              <asp:TextBox id="ASSIGNMENTSearchs_DESCRIPTION" maxlength="60" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td style="TEXT-ALIGN: right" colspan="2">
              <input id='ASSIGNMENTSearchButton_DoSearch' type="submit" class="Button" value="Search" OnServerClick='ASSIGNMENTSearch_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>

<asp:repeater id="ASSIGNMENTRepeater" OnItemCommand="ASSIGNMENTItemCommand" OnItemDataBound="ASSIGNMENTItemDataBound" runat="server">
  <HeaderTemplate>
  


  
	<script language="JavaScript" >
	var ASSIGNMENTElements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initASSIGNMENTElements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
  <table class="MainTable" cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Edit Assignments</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Grid" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="ASSIGNMENTError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="6"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Row">
            <td colspan="6">Total Records:&nbsp;<asp:Literal id="ASSIGNMENTASSIGNMENT_TotalRecords" runat="server"/></td>
          </tr>
 
          <tr class="Caption">
            <th>
            <CC:Sorter id="Sorter_SUBJECT_IDSorter" field="Sorter_SUBJECT_ID" OwnerState="<%# ASSIGNMENTData.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_SUBJECT_IDSort" runat="server">SUBJECT ID</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_ASSIGNMENT_IDSorter" field="Sorter_ASSIGNMENT_ID" OwnerState="<%# ASSIGNMENTData.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_ASSIGNMENT_IDSort" runat="server">ASSIGNMENT ID</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_DESCRIPTIONSorter" field="Sorter_DESCRIPTION" OwnerState="<%# ASSIGNMENTData.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_DESCRIPTIONSort" runat="server">DESCRIPTION</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_STATUSSorter" field="Sorter_STATUS" OwnerState="<%# ASSIGNMENTData.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_STATUSSort" runat="server">STATUS</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_SpecialTypeSorter" field="Sorter_SpecialType" OwnerState="<%# ASSIGNMENTData.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_SpecialTypeSort" runat="server">ASSESSMENT</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter>&nbsp;</th>
 
            <th>
            <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# ASSIGNMENTData.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENTData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
    
          
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
          <tr class="Error">
            <td colspan="6"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Row">
            <td style="TEXT-ALIGN: center"><asp:Literal id="ASSIGNMENTSUBJECT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENTItem)).SUBJECT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td style="TEXT-ALIGN: center"><asp:Literal id="ASSIGNMENTASSIGNMENT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENTItem)).ASSIGNMENT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td><asp:TextBox id="ASSIGNMENTDESCRIPTION" Text='<%# (CType(Container.DataItem,ASSIGNMENTItem)).DESCRIPTION.GetFormattedValue() %>' maxlength="60" Columns="50"	runat="server"/></td> 
            <td>
              <asp:RadioButtonList id="ASSIGNMENTSTATUS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
            <td>&nbsp; 
              <asp:RadioButtonList id="ASSIGNMENTRadioButtonSpecialType"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
            <td><asp:Literal id="ASSIGNMENTLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENTItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ <asp:Literal id="ASSIGNMENTLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENTItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>
  <input id="ASSIGNMENTHidden_LAST_ALTERED_BY"  value='<%# (CType(Container.DataItem,ASSIGNMENTItem)).Hidden_LAST_ALTERED_BY.GetFormattedValue() %>' type="hidden"  runat="server"/>
  
  <input id="ASSIGNMENTHidden_LAST_ALTERED_DATE"  value='<%# (CType(Container.DataItem,ASSIGNMENTItem)).Hidden_LAST_ALTERED_DATE.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td>
          </tr>
 
  </ItemTemplate>

  <FooterTemplate>
	
          
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
          <tr class="NoRecords">
            <td colspan="6">No Assignments found for this Subject!</td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Footer">
            <td style="TEXT-ALIGN: right" colspan="6">
              
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# ASSIGNMENTData.PagesCount%>" PageSize="<%# ASSIGNMENTData.RecordsPerPage%>" PageNumber="<%# ASSIGNMENTData.PageNumber%>" runat="server"><span class="Navigator">Records per page 
              <CC:PageSizer AutoPostBack="true" runat="server" />
 
              <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server">First</asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="FirstOff" runat="server">First </CC:NavigatorItem>
              <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server">Prev</asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="PrevOff" runat="server">Prev </CC:NavigatorItem>&nbsp; 
              
<CC:Pager id="NavigatorPager" Style="Centered" PagerSize="10" runat="server">
              <PageOnTemplate><asp:LinkButton runat="server"><%# (CType(Container,PagerItem)).PageNumber.ToString() %></asp:LinkButton>&nbsp;</PageOnTemplate>
              <PageOffTemplate><%# (CType(Container,PagerItem)).PageNumber.ToString() %>&nbsp;</PageOffTemplate></CC:Pager>of &nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
              <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server">Next</asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="NextOff" runat="server">Next </CC:NavigatorItem>
              <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server">Last</asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="LastOff" runat="server">Last </CC:NavigatorItem></span></CC:Navigator>

              <asp:Button id="ASSIGNMENTButton_Submit" CssClass="Button" Text="Update" CommandName="Submit" runat="server"/>
              <asp:Button id="ASSIGNMENTCancel" CssClass="Button" Text="Cancel" runat="server"/></td>
          </tr>
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

