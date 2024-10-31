<!--ASPX page @1-6C5D9934-->
    <%@ Page language="vb" CodeFile="Staff_LAdAllocation_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Staff_LAdAllocation_maint.Staff_LAdAllocation_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Staff_LAdAllocation_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 5.1.0.18696"><meta name="description" content="Page to allow AP or similar to manage the Teaching Learning Advisors Allocations from a single page instead of checking each separately. The data is stored with the STAFF_LAD_ALLOCATION table for simplicity."><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Learning Advisor Allocations maintain</title>



<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_SUBJECT_SUBJECT_TEACHER_ButtonResetLAdsMax_OnClick @120-61EE171D
function page_SUBJECT_SUBJECT_TEACHER_ButtonResetLAdsMax_OnClick()
{
    var result;
//End page_SUBJECT_SUBJECT_TEACHER_ButtonResetLAdsMax_OnClick

//Confirmation Message @122-4BFC1CBF
    return confirm('This will reset ALL LAds in the table to the entered Max Students?\n(you must also select 'Yes' on Confirm Reset first)');
//End Confirmation Message

//Close page_SUBJECT_SUBJECT_TEACHER_ButtonResetLAdsMax_OnClick @120-BC33A33A
    return result;
}
//End Close page_SUBJECT_SUBJECT_TEACHER_ButtonResetLAdsMax_OnClick

//page_ManageLADs_buttonCancel_OnClick @558-C5A6467B
function page_ManageLADs_buttonCancel_OnClick()
{
    disableValidation = true;
}
//End page_ManageLADs_buttonCancel_OnClick

//page_SUBJECT_SUBJECT_TEACHER_Button_DoSearch_OnClick @42-C422020E
function page_SUBJECT_SUBJECT_TEACHER_Button_DoSearch_OnClick()
{
    disableValidation = true;
}
//End page_SUBJECT_SUBJECT_TEACHER_Button_DoSearch_OnClick

//bind_events @1-B50DC282
function bind_events() {
    addEventHandler("SUBJECT_SUBJECT_TEACHERButtonResetLAdsMax","click",page_SUBJECT_SUBJECT_TEACHER_ButtonResetLAdsMax_OnClick);
    addEventHandler("ManageLADsbuttonCancel","click",page_ManageLADs_buttonCancel_OnClick);
    addEventHandler("SUBJECT_SUBJECT_TEACHERButton_DoSearch","click",page_SUBJECT_SUBJECT_TEACHER_Button_DoSearch_OnClick);
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

  <span id="SUBJECT_SUBJECT_TEACHERHolder" runat="server">
    


  <table class="MainTable" cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Search Learning Advisor</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="SUBJECT_SUBJECT_TEACHERError" visible="False" runat="server">
  
          <tr id="<%=PageVariables.Get("@error-block")%>" class="Error">
            <td colspan="2"><asp:Label ID="SUBJECT_SUBJECT_TEACHERErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>Search for...</th>
 
            <td><asp:TextBox id="SUBJECT_SUBJECT_TEACHERs_keyword" maxlength="30" Columns="40"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th colspan="2"><em>(searches on&nbsp;Staff Firstname, Staff Lastname, Staff login)</em></th>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;Show...</th>
 
            <td>&nbsp; 
              <asp:RadioButtonList id="SUBJECT_SUBJECT_TEACHERrbShow"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td><a id="SUBJECT_SUBJECT_TEACHERClearParameters" href="" runat="server"  >Clear</a></td> 
            <td style="TEXT-ALIGN: right">
              <input id='SUBJECT_SUBJECT_TEACHERButton_DoSearch' type="submit" class="Button" value="Search" OnServerClick='SUBJECT_SUBJECT_TEACHER_Search' runat="server"/></td>
          </tr>
        </table>
      </td> 
      <td valign="top">&nbsp;</td> 
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Bulk Changes</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          <tr class="Controls">
            <th>&nbsp;Handy for start of Semester or Year resets</th>
 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p>Set ALL LAds to __ students?</p>
 
            <p>Confirm Reset:&nbsp;&nbsp; 
            <asp:RadioButtonList id="SUBJECT_SUBJECT_TEACHERrbConfirm"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></p>
            </th>
 
            <td><asp:TextBox id="SUBJECT_SUBJECT_TEACHERmaxstudents" style="TEXT-ALIGN: right" maxlength="2" Columns="4"	runat="server"/>
              <input id='SUBJECT_SUBJECT_TEACHERButtonResetLAdsMax' type="submit" class="Button" value="Reset LAds" OnServerClick='SUBJECT_SUBJECT_TEACHER_Delete' runat="server"/></td>
          </tr>
 
          <tr class="Error">
            <td colspan="2">&nbsp;<asp:Literal id="SUBJECT_SUBJECT_TEACHERlblConfirmError" runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>
&nbsp; 

  <span id="SUBJECT_TEACHERHolder" runat="server">
    


  <table class="MainTable" cellspacing="0" cellpadding="0" width="30%" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"></td> 
            <td class="th"><strong>Add Learning Advisor</strong></td> 
            <td class="HeaderRight">&nbsp;</td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="SUBJECT_TEACHERError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="3"><span id="SUBJECT_TEACHERErrorBlock"><asp:Label ID="SUBJECT_TEACHERErrorLabel" runat="server"/></span></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Caption">
            <th>Learning Advisor&nbsp;Name</th>
 
            <th>Year Level&nbsp;</th>
 
            <th>&nbsp;Max Students</th>
          </tr>
 
          <tr class="Controls">
            <td>
              <select id="SUBJECT_TEACHERSTAFF_ID"  runat="server"></select>
 </td> 
            <td nowrap>&nbsp; 
              <asp:RadioButtonList id="SUBJECT_TEACHERradioYEAR_LEVEL"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
            <td>&nbsp;<asp:TextBox id="SUBJECT_TEACHERLAD_MAX_ALLOC" style="TEXT-ALIGN: right" maxlength="2" Columns="4"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td style="TEXT-ALIGN: right" colspan="3">
              <input id='SUBJECT_TEACHERbuttonAdd' type="submit" class="Button" value="Add New LAd" OnServerClick='SUBJECT_TEACHER_Insert' runat="server"/>&nbsp;&nbsp; </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>

<asp:repeater id="ManageLADsRepeater" OnItemCommand="ManageLADsItemCommand" OnItemDataBound="ManageLADsItemDataBound" runat="server">
  <HeaderTemplate>
  


  
	<script language="JavaScript" >
	var ManageLADsElements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initManageLADsElements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
  <table class="MainTable" cellspacing="0" cellpadding="0" width="50%" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Manage Learning Advisors</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Grid" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="ManageLADsError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="5"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Row">
            <td colspan="5">Total Records:&nbsp;<asp:Literal id="ManageLADsTotalRecords" runat="server"/></td>
          </tr>
 
          <tr class="Caption">
            <th>Learning Advisor Name (Staff ID)</th>
 
            <th>Year Level&nbsp;</th>
 
            <th>&nbsp;Max. Students</th>
 
            <th>
            <CC:Sorter id="Sorter_SCAFFOLD_COURSEDEV_UPDATEDSorter" field="Sorter_SCAFFOLD_COURSEDEV_UPDATED" OwnerState="<%# ManageLADsData.SortField.ToString()%>" OwnerDir="<%# ManageLADsData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_SCAFFOLD_COURSEDEV_UPDATEDSort" runat="server">Allocations Updated</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>&nbsp;<font color="#c0504d">Delete!</font></th>
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
    
          
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
          <tr class="Error">
            <td colspan="5"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Row">
            <td>
              <p><asp:Literal id="ManageLADsFIRSTNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ManageLADsItem)).FIRSTNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="ManageLADsSURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ManageLADsItem)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;(<asp:Literal id="ManageLADslblStaffID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ManageLADsItem)).lblStaffID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>)</p>
            </td> 
            <td nowrap>&nbsp; 
              <asp:RadioButtonList id="ManageLADsradioYEAR_LEVEL"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
            <td>&nbsp;<asp:TextBox id="ManageLADsLAD_MAX_ALLOC" Text='<%# (CType(Container.DataItem,ManageLADsItem)).LAD_MAX_ALLOC.GetFormattedValue() %>' style="TEXT-ALIGN: right" maxlength="2" Columns="4"	runat="server"/></td> 
            <td nowrap>&nbsp;<asp:Literal id="ManageLADslblLastUpdated" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ManageLADsItem)).lblLastUpdated.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td nowrap>&nbsp;<asp:CheckBox id="ManageLADscheckDelete" Visible = "<%# (CType(Container.DataItem,ManageLADsItem)).IsDeleteAllowed %>" runat="server"/>&nbsp;Delete</td>
          </tr>
 
  </ItemTemplate>

  <FooterTemplate>
	
          
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
          <tr class="NoRecords">
            <td colspan="5">No Staff or LAds Found!</td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Footer">
            <td style="TEXT-ALIGN: right" colspan="5">
              <asp:Button id="ManageLADsbuttonUpdate" CssClass="Button" Text="Save Changes" CommandName="Submit" runat="server"/>&nbsp;&nbsp; 
              <asp:Button id="ManageLADsbuttonCancel" CssClass="Button" Text="Cancel" runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>


&nbsp;
  </FooterTemplate>
</asp:repeater>
<br>
<br>
<br>
</p>

</form>
</body>
</html>

<!--End ASPX page-->

