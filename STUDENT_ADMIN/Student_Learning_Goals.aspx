<!--ASPX page @1-761BC79F-->
    <%@ Page language="vb" CodeFile="Student_Learning_Goals.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_Learning_Goals.Student_Learning_GoalsPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_Learning_Goals" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="StudentNamePlate" Src="StudentNamePlate.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta name="description" content="Special form for Student Learning Goals to be reviewd and added. For all staff, as requested for 202 Enrolments."><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Learning Goals</title>



<style type="text/css">
<!--
.deprecated::after  { content: " deprecated"; background-color: yellow; color: red; font-weight: bold; }
.Controls th.shiftright  { margin-right: 1em; text-align: right; }
.instructions   { font-size: 12px; font-style: italic; }
.processtips   { display: none; }
.processtips::before  { content: "Tip!"; }
.processtips:hover   { display: block; }
.errormsg   { font-size: 120%; background-color: #F00; color: #FFF; font-weight: bold; margin: 2px; }
-->
</style>
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_STUDENT_LEARNING_GOALS2_Button_Delete_OnClick @213-FBD2AF28
function page_STUDENT_LEARNING_GOALS2_Button_Delete_OnClick()
{
    var result;
//End page_STUDENT_LEARNING_GOALS2_Button_Delete_OnClick

//Confirmation Message @214-249B1D32
    return confirm('Permanently Delete Goal?');
//End Confirmation Message

//Close page_STUDENT_LEARNING_GOALS2_Button_Delete_OnClick @213-BC33A33A
    return result;
}
//End Close page_STUDENT_LEARNING_GOALS2_Button_Delete_OnClick

//page_STUDENT_LEARNING_GOALS2_Button_Cancel_OnClick @215-197ED276
function page_STUDENT_LEARNING_GOALS2_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_LEARNING_GOALS2_Button_Cancel_OnClick

//Handle condition_for_show @230-043B8DF0
function condition_for_show_start(sender) {
//End Handle condition_for_show

//Custom condition_for_show @230-D1791465
    if (true==(params["click"] == "link"))
    {
        DialogPanel1_show(sender);
    } else {
    }
//End Custom condition_for_show

//condition_for_show Tail @230-FCB6E20C
}
//End condition_for_show Tail

//Handle condition_for_hide @235-86D194D0
function condition_for_hide_start(sender) {
//End Handle condition_for_hide

//Custom condition_for_hide @235-A1BE8D38
    if (true==(params["click"] == "submit" && $("#ErrorBlock").length == 0))
    {
        DialogPanel1_hide(sender);
    } else {
    }
//End Custom condition_for_hide

//condition_for_hide Tail @235-FCB6E20C
}
//End condition_for_hide Tail

//Handle ccc_link_Condition @240-BC7B1F19
function ccc_link_Condition_start(sender) {
//End Handle ccc_link_Condition

//Custom ccc_link_Condition @240-3ACAA933
    if (true==(params["click"] = "link"))
    {
    } else {
    }
//End Custom ccc_link_Condition

//ccc_link_Condition Tail @240-FCB6E20C
}
//End ccc_link_Condition Tail

//Handle ccc_submit_Condition @251-D19B1E57
function ccc_submit_Condition_start(sender) {
//End Handle ccc_submit_Condition

//Custom ccc_submit_Condition @251-3B4E074B
    if (true==(params["click"] = "submit"))
    {
    } else {
    }
//End Custom ccc_submit_Condition

//ccc_submit_Condition Tail @251-FCB6E20C
}
//End ccc_submit_Condition Tail

//Handle ccc_others_Condition @266-DDF821BB
function ccc_others_Condition_start(sender) {
//End Handle ccc_others_Condition

//Custom ccc_others_Condition @266-CECB318E
    if (true==(params["click"] = ""))
    {
    } else {
    }
//End Custom ccc_others_Condition

//ccc_others_Condition Tail @266-FCB6E20C
}
//End ccc_others_Condition Tail

//bind_events @1-02A6C4FD
function bind_events() {
    addEventHandler("STUDENT_LEARNING_GOALS1STUDENT_LEARNING_GOALS1_Insert", "click", ccc_link_Condition_start);
    addEventHandler("STUDENT_LEARNING_GOALS1Detail", "click", ccc_link_Condition_start);
    addEventHandler("STUDENT_LEARNING_GOALS2", "submit", ccc_submit_Condition_start);
    addEventHandler("STUDENT_LEARNING_GOALS2Button_Delete","click",page_STUDENT_LEARNING_GOALS2_Button_Delete_OnClick);
    addEventHandler("STUDENT_LEARNING_GOALS2Button_Cancel","click",page_STUDENT_LEARNING_GOALS2_Button_Cancel_OnClick);
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


<p align="center">

	<asp:PlaceHolder id="Panel_MenuStudentMaintain" Visible="false" runat="server">
	<DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/>
	</asp:PlaceHolder>
	</p>

<div align="left">
  <p align="center"><a id="Link_Backtosummary" href="" class="Button" runat="server"  >Back to Summary</a></p>
  <p align="center"><DECV_PROD2007:StudentNamePlate id="StudentNamePlate" runat="server"/></p>
</div>
<div align="left">
</div>

	<asp:PlaceHolder id="Panel1" Visible="true" runat="server">
	

<asp:repeater id="STUDENT_LEARNING_GOALS1Repeater" OnItemCommand="STUDENT_LEARNING_GOALS1ItemCommand" OnItemDataBound="STUDENT_LEARNING_GOALS1ItemDataBound" runat="server">
  <HeaderTemplate>
	
<table id="Panel1STUDENT_LEARNING_GOALS1" class="MainTable" cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>Student Learning Goals </th>
 
          <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>&nbsp;</th>
 
          <th>
          <CC:Sorter id="Sorter_GOAL_TITLESorter" field="Sorter_GOAL_TITLE" OwnerState="<%# STUDENT_LEARNING_GOALS1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_LEARNING_GOALS1Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_GOAL_TITLESort" runat="server">GOAL TITLE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_GOAL_CATEGORYSorter" field="Sorter_GOAL_CATEGORY" OwnerState="<%# STUDENT_LEARNING_GOALS1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_LEARNING_GOALS1Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_GOAL_CATEGORYSort" runat="server">GOAL CATEGORY</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_GOAL_BY_DATESorter" field="Sorter_GOAL_BY_DATE" OwnerState="<%# STUDENT_LEARNING_GOALS1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_LEARNING_GOALS1Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_GOAL_BY_DATESort" runat="server">GOAL BY DATE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_GOAL_RESULTSorter" field="Sorter_GOAL_RESULT" OwnerState="<%# STUDENT_LEARNING_GOALS1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_LEARNING_GOALS1Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_GOAL_RESULTSort" runat="server">GOAL RESULT</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_CREATED_DATETIMESorter" field="Sorter_CREATED_DATETIME" OwnerState="<%# STUDENT_LEARNING_GOALS1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_LEARNING_GOALS1Data.SortDir%>" runat="server"><span class="Sorter">CREATED</span></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_LAST_ALTERED_DATESorter" field="Sorter_LAST_ALTERED_DATE" OwnerState="<%# STUDENT_LEARNING_GOALS1Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_LEARNING_GOALS1Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_LAST_ALTERED_DATESort" runat="server">LAST ALTERED DATE</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td><a id="STUDENT_LEARNING_GOALS1Detail" href="" runat="server"  >Detail</a>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_LEARNING_GOALS1GOAL_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_LEARNING_GOALS1Item)).GOAL_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/><strong>&nbsp;</strong></td> 
          <td><asp:Literal id="STUDENT_LEARNING_GOALS1GOAL_CATEGORY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_LEARNING_GOALS1Item)).GOAL_CATEGORY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_LEARNING_GOALS1GOAL_BY_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_LEARNING_GOALS1Item)).GOAL_BY_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_LEARNING_GOALS1GOAL_RESULT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_LEARNING_GOALS1Item)).GOAL_RESULT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_LEARNING_GOALS1CREATED_DATETIME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_LEARNING_GOALS1Item)).CREATED_DATETIME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_LEARNING_GOALS1LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_LEARNING_GOALS1Item)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_LEARNING_GOALS1LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_LEARNING_GOALS1Item)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
        </tr>
 
        <tr class="Row">
          <td>&nbsp;</td> 
          <td colspan="5">Detail: <em><asp:Literal id="STUDENT_LEARNING_GOALS1GOAL_DETAIL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_LEARNING_GOALS1Item)).GOAL_DETAIL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></em></td> 
          <td>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="7">No Learning Goals found!</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="7"><a id="STUDENT_LEARNING_GOALS1STUDENT_LEARNING_GOALS1_Insert" href="" runat="server"  >Add New</a>&nbsp; 
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# STUDENT_LEARNING_GOALS1Data.PagesCount%>" PageSize="<%# STUDENT_LEARNING_GOALS1Data.RecordsPerPage%>" PageNumber="<%# STUDENT_LEARNING_GOALS1Data.PageNumber%>" runat="server"><span class="Navigator">
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
	

  <span id="STUDENT_LEARNING_GOALS2Holder" runat="server">
    


  <table class="MainTable" cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft">&nbsp;</td> 
            <td class="th"><strong>Add/Edit Student Learning Goals</strong></td> 
            <td class="HeaderRight">&nbsp;</td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="STUDENT_LEARNING_GOALS2Error" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="4"><span id="ErrorBlock"><asp:Label ID="STUDENT_LEARNING_GOALS2ErrorLabel" runat="server"/></span></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <td class="th"><label>GOAL TITLE</label></td> 
            <td><asp:TextBox id="STUDENT_LEARNING_GOALS2GOAL_TITLE" maxlength="100" Columns="90"	runat="server"/></td> 
            <td class="th">&nbsp;</td> 
            <td class="th">&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <td class="th"><label>CATEGORY</label></td> 
            <td>
              <select id="STUDENT_LEARNING_GOALS2GOAL_CATEGORY"  runat="server"></select>
 </td> 
            <td class="th"><label>BY DATE</label></td> 
            <td><asp:TextBox id="STUDENT_LEARNING_GOALS2GOAL_BY_DATE" style="TEXT-ALIGN: right" maxlength="100" Columns="10"	runat="server"/>&nbsp;<em>(dd/mm/yyyy)</em></td>
          </tr>
 
          <tr class="Controls">
            <td class="th"><label>DETAIL</label></td> 
            <td>
<asp:TextBox id="STUDENT_LEARNING_GOALS2GOAL_DETAIL" rows="5" Columns="70" TextMode="MultiLine"	runat="server"/>
</td> 
            <td class="th" colspan="2">
              <p>SMART Goal principles:<br>
              <ul>
                <li>Specific - what exactly is it? 
                <li>Measurable - how will you know it is done? 
                <li>Actionable - can you really do this? 
                <li>Relevant - is it related to the student? 
                <li>Time-bounded - by when? </li>
              </ul>
 
              <p></p>
            </td>
          </tr>
 
          <tr class="Controls">
            <td class="th"><label>GOAL RESULT</label></td> 
            <td>
              <select id="STUDENT_LEARNING_GOALS2GOAL_RESULT"  runat="server"></select>
 </td> 
            <td class="th" colspan="2">&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <td class="th"><label>RESULT NOTES</label></td> 
            <td>
              <p>
<asp:TextBox id="STUDENT_LEARNING_GOALS2RESULT_NOTES" rows="3" Columns="70" TextMode="MultiLine"	runat="server"/>
</p>
 
              <p>
  <input id="STUDENT_LEARNING_GOALS2STUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="STUDENT_LEARNING_GOALS2ENROLMENT_YEAR" type="hidden"  runat="server"/>
  
  <input id="STUDENT_LEARNING_GOALS2CREATED_DATETIME" type="hidden"  runat="server"/>
  
  <input id="STUDENT_LEARNING_GOALS2LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="STUDENT_LEARNING_GOALS2LAST_ALTERED_DATE" type="hidden"  runat="server"/>
  </p>
            </td> 
            <td class="th" colspan="2">&nbsp;Last Updated By / Date (this Goal only)<br>
              <asp:Literal id="STUDENT_LEARNING_GOALS2lblLAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_LEARNING_GOALS2lblLAST_ALTERED_DATE" runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td style="TEXT-ALIGN: right" colspan="4">
              <input id='STUDENT_LEARNING_GOALS2Button_Insert' type="submit" class="Button" value="Add Goal" OnServerClick='STUDENT_LEARNING_GOALS2_Insert' runat="server"/>
              <input id='STUDENT_LEARNING_GOALS2Button_Update' type="submit" class="Button" value="Update Goal" OnServerClick='STUDENT_LEARNING_GOALS2_Update' runat="server"/>
              <input id='STUDENT_LEARNING_GOALS2Button_Delete' type="submit" class="Button" value="Delete" OnServerClick='STUDENT_LEARNING_GOALS2_Delete' runat="server"/>
              <input id='STUDENT_LEARNING_GOALS2Button_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_LEARNING_GOALS2_Cancel' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  
	</asp:PlaceHolder>
	<br>

	</asp:PlaceHolder>
	

</form>
</body>
</html>

<!--End ASPX page-->

