<!--ASPX page @1-EF6D7908-->
    <%@ Page language="vb" CodeFile="Despatch_AssignmentMaintain.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Despatch_AssignmentMaintain.Despatch_AssignmentMaintainPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Despatch_AssignmentMaintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 4.01.00.06"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Despatch_AssignmentMaintain</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-092F8E28
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript" charset="utf-8" src='ClientI18N.aspx?file=DatePicker.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Date Picker Object Definitions @1-6A27B1C8

var ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATE = new Object(); 
ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATE.format           = "dd/mm/yy";
ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATE.style            = "Styles/Blueprint/Style.css";
ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATE.relativePathPart = "";
ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATE.themeVersion     = "3.0";
var ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATE = new Object(); 
ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATE.format           = "dd/mm/yy";
ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATE.style            = "Styles/Blueprint/Style.css";
ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATE.relativePathPart = "";
ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATE.themeVersion     = "3.0";
//End Date Picker Object Definitions

//page_ASSIGNMENT_SUBMISSION_STU1_Button_Submit_OnClick @73-5E224502
function page_ASSIGNMENT_SUBMISSION_STU1_Button_Submit_OnClick()
{
    var result;
//End page_ASSIGNMENT_SUBMISSION_STU1_Button_Submit_OnClick

//Confirmation Message @74-257FDD03
    return confirm('Submit records?');
//End Confirmation Message

//Close page_ASSIGNMENT_SUBMISSION_STU1_Button_Submit_OnClick @73-BC33A33A
    return result;
}
//End Close page_ASSIGNMENT_SUBMISSION_STU1_Button_Submit_OnClick

//page_ASSIGNMENT_SUBMISSION_STU1_checkboxDelete_OnClick @95-C696B2B4
function page_ASSIGNMENT_SUBMISSION_STU1_checkboxDelete_OnClick()
{
    var result;
//End page_ASSIGNMENT_SUBMISSION_STU1_checkboxDelete_OnClick

//Confirmation Message @107-7D05CDD7
    return confirm('You Really Want to Delete this Assignment? \nIt cannot come back if you change your mind.');
//End Confirmation Message

//Close page_ASSIGNMENT_SUBMISSION_STU1_checkboxDelete_OnClick @95-BC33A33A
    return result;
}
//End Close page_ASSIGNMENT_SUBMISSION_STU1_checkboxDelete_OnClick

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//Set Focus @82-05A8BD1A
    if (theForm.ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_STUDENT_ID) theForm.ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_STUDENT_ID.focus();
//End Set Focus

//Close page_OnLoad @1-BC33A33A
    return result;
}
//End Close page_OnLoad

//page_ASSIGNMENT_SUBMISSION_STU1_Cancel_OnClick @75-030B3B05
function page_ASSIGNMENT_SUBMISSION_STU1_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_ASSIGNMENT_SUBMISSION_STU1_Cancel_OnClick

//bind_events @1-93E27E5D
function bind_events() {
    if(typeof(initASSIGNMENT_SUBMISSION_STU1Elements) == "function")
        initASSIGNMENT_SUBMISSION_STU1Elements();
    if(typeof(initASSIGNMENT_SUBMISSION_STU1Elements) == "function"){
        for(var i = 0; i < ASSIGNMENT_SUBMISSION_STU1Elements.length; i++){
            addEventHandler(ASSIGNMENT_SUBMISSION_STU1Elements[i][ASSIGNMENT_SUBMISSION_STU1DeleteControl].id, "click", page_ASSIGNMENT_SUBMISSION_STU1_checkboxDelete_OnClick);
        }
    }
    if(typeof(ASSIGNMENT_SUBMISSION_STU1StaticElementsID) == "object" && typeof(ASSIGNMENT_SUBMISSION_STU1StaticElementsID[ASSIGNMENT_SUBMISSION_STU1Button_SubmitID]) == "object" && ASSIGNMENT_SUBMISSION_STU1StaticElementsID[ASSIGNMENT_SUBMISSION_STU1Button_SubmitID]!=null)
        addEventHandler(ASSIGNMENT_SUBMISSION_STU1StaticElementsID[ASSIGNMENT_SUBMISSION_STU1Button_SubmitID].id, "click", page_ASSIGNMENT_SUBMISSION_STU1_Button_Submit_OnClick);
    addEventHandler("ASSIGNMENT_SUBMISSION_STU1Cancel","click",page_ASSIGNMENT_SUBMISSION_STU1_Cancel_OnClick);
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


<p align="center"><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p>

  <span id="ASSIGNMENT_SUBMISSION_STUHolder" runat="server">
    


  <table border="0" cellspacing="0" cellpadding="0" align="center">
    <tr>
      <td valign="top">
        <table class="Header" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Search Assignment Submissions</th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="ASSIGNMENT_SUBMISSION_STUError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="ASSIGNMENT_SUBMISSION_STUErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>STUDENT ID</th>
 
            <td><asp:TextBox id="ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_STUDENT_ID" maxlength="12" Columns="12"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>SUBJECT ID</th>
 
            <td><asp:TextBox id="ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_SUBJECT_ID" maxlength="10" Columns="10"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>STAFF NAME</th>
 
            <td>
              <select id="ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_STAFF_ID"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Bottom">
            <td><a id="ASSIGNMENT_SUBMISSION_STUClearParameters" href="" runat="server"  >Clear</a></td> 
            <td align="right">
              <input id='ASSIGNMENT_SUBMISSION_STUButton_DoSearch' type="submit" class="Button" value="Search" OnServerClick='ASSIGNMENT_SUBMISSION_STU_Search' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>

<asp:repeater id="ASSIGNMENT_SUBMISSION_STU1Repeater" OnItemCommand="ASSIGNMENT_SUBMISSION_STU1ItemCommand" OnItemDataBound="ASSIGNMENT_SUBMISSION_STU1ItemDataBound" runat="server">
  <HeaderTemplate>
  


  
	<script language="JavaScript" >
	var ASSIGNMENT_SUBMISSION_STU1Elements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initASSIGNMENT_SUBMISSION_STU1Elements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
  <table border="0" cellspacing="0" cellpadding="0" align="center">
    <tr>
      <td valign="top">
        <table class="Header" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Assignments Submitted for Staff/Student/Subject </th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Grid" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="ASSIGNMENT_SUBMISSION_STU1Error" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="13"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Row">
            <td colspan="13">Total Records:&nbsp;<asp:Literal id="ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STU1_TotalRecords" runat="server"/></td>
          </tr>
 
          <tr class="Caption">
            <th>Delete?&nbsp;</th>
 
            <th>
            <CC:Sorter id="Sorter_ASSIGNMENT_SUBMISSION_SUBJECT_IDSorter" field="Sorter_ASSIGNMENT_SUBMISSION_SUBJECT_ID" OwnerState="<%# ASSIGNMENT_SUBMISSION_STU1Data.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENT_SUBMISSION_STU1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ASSIGNMENT_SUBMISSION_SUBJECT_IDSort" runat="server">Subject ID</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_ASSIGNMENT_SUBMISSION_STUDENT_IDSorter" field="Sorter_ASSIGNMENT_SUBMISSION_STUDENT_ID" OwnerState="<%# ASSIGNMENT_SUBMISSION_STU1Data.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENT_SUBMISSION_STU1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ASSIGNMENT_SUBMISSION_STUDENT_IDSort" runat="server">Student ID</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_ASSIGNMENT_IDSorter" field="Sorter_ASSIGNMENT_ID" OwnerState="<%# ASSIGNMENT_SUBMISSION_STU1Data.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENT_SUBMISSION_STU1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ASSIGNMENT_IDSort" runat="server">Assignment No.</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_SUBMISSION_IDSorter" field="Sorter_SUBMISSION_ID" OwnerState="<%# ASSIGNMENT_SUBMISSION_STU1Data.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENT_SUBMISSION_STU1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBMISSION_IDSort" runat="server">Submission No.</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_RECEIVED_DATESorter" field="Sorter_RECEIVED_DATE" OwnerState="<%# ASSIGNMENT_SUBMISSION_STU1Data.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENT_SUBMISSION_STU1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_RECEIVED_DATESort" runat="server">Received Date</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_RETURNED_DATESorter" field="Sorter_RETURNED_DATE" OwnerState="<%# ASSIGNMENT_SUBMISSION_STU1Data.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENT_SUBMISSION_STU1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_RETURNED_DATESort" runat="server">Returned Date</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_ASSIGNMENT_SUBMISSION_STAFF_IDSorter" field="Sorter_ASSIGNMENT_SUBMISSION_STAFF_ID" OwnerState="<%# ASSIGNMENT_SUBMISSION_STU1Data.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENT_SUBMISSION_STU1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ASSIGNMENT_SUBMISSION_STAFF_IDSort" runat="server">Marker ID</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
            <th colspan="5">
            <CC:Sorter id="Sorter_COMMENTSSorter" field="Sorter_COMMENTS" OwnerState="<%# ASSIGNMENT_SUBMISSION_STU1Data.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENT_SUBMISSION_STU1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_COMMENTSSort" runat="server">Comments</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
    
          
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
          <tr class="Error">
            <td colspan="13"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Row">
            <td>&nbsp;<asp:CheckBox id="ASSIGNMENT_SUBMISSION_STU1checkboxDelete" Visible = "<%# (CType(Container.DataItem,ASSIGNMENT_SUBMISSION_STU1Item)).IsDeleteAllowed %>" runat="server"/></td> 
            <td><asp:Literal id="ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_SUBJECT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSION_STU1Item)).ASSIGNMENT_SUBMISSION_SUBJECT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STUDENT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSION_STU1Item)).ASSIGNMENT_SUBMISSION_STUDENT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSION_STU1Item)).ASSIGNMENT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="ASSIGNMENT_SUBMISSION_STU1SUBMISSION_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSION_STU1Item)).SUBMISSION_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:TextBox id="ASSIGNMENT_SUBMISSION_STU1RECEIVED_DATE" Text='<%# (CType(Container.DataItem,ASSIGNMENT_SUBMISSION_STU1Item)).RECEIVED_DATE.GetFormattedValue() %>' maxlength="100" Columns="10"	runat="server"/>
              <asp:PlaceHolder id="ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATE" runat="server"><a href="javascript:showDatePicker('<%#ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATEName%>','forms[\''+theForm.id+'\']','<%#ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATEDateControl%>');" id="ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATE_Link"  ><img id="ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATE_Image" border="0" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" /></a></asp:PlaceHolder>
  </td> 
            <td><asp:TextBox id="ASSIGNMENT_SUBMISSION_STU1RETURNED_DATE" Text='<%# (CType(Container.DataItem,ASSIGNMENT_SUBMISSION_STU1Item)).RETURNED_DATE.GetFormattedValue() %>' maxlength="100" Columns="10"	runat="server"/>
              <asp:PlaceHolder id="ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATE" runat="server"><a href="javascript:showDatePicker('<%#ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATEName%>','forms[\''+theForm.id+'\']','<%#ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATEDateControl%>');" id="ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATE_Link"  ><img id="ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATE_Image" border="0" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" /></a></asp:PlaceHolder>
  </td> 
            <td>
              <select id="ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STAFF_ID"  runat="server"></select>
 </td> 
            <td colspan="5"><asp:TextBox id="ASSIGNMENT_SUBMISSION_STU1COMMENTS" Text='<%# (CType(Container.DataItem,ASSIGNMENT_SUBMISSION_STU1Item)).COMMENTS.GetFormattedValue() %>' maxlength="60" Columns="30"	runat="server"/></td>
          </tr>
 
  </ItemTemplate>

  <FooterTemplate>
	
          
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
          <tr class="NoRecords">
            <td colspan="13">No Assignment Details found for this Student/Subject/Staff.</td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Footer">
            <td style="TEXT-ALIGN: right" colspan="13">
              
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# ASSIGNMENT_SUBMISSION_STU1Data.PagesCount%>" PageSize="<%# ASSIGNMENT_SUBMISSION_STU1Data.RecordsPerPage%>" PageNumber="<%# ASSIGNMENT_SUBMISSION_STU1Data.PageNumber%>" runat="server">
              Per page: 
              <CC:PageSizer AutoPostBack="true" runat="server" />
 
              <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img border="0" src="Styles/Blueprint/Images/First.gif"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="FirstOff" runat="server"><img border="0" src="Styles/Blueprint/Images/FirstOff.gif"></CC:NavigatorItem>
              <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img border="0" src="Styles/Blueprint/Images/Prev.gif"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="PrevOff" runat="server"><img border="0" src="Styles/Blueprint/Images/PrevOff.gif"></CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %> of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
              <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img border="0" src="Styles/Blueprint/Images/Next.gif"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="NextOff" runat="server"><img border="0" src="Styles/Blueprint/Images/NextOff.gif"></CC:NavigatorItem>
              <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img border="0" src="Styles/Blueprint/Images/Last.gif"></asp:LinkButton> </CC:NavigatorItem>
              <CC:NavigatorItem type="LastOff" runat="server"><img border="0" src="Styles/Blueprint/Images/LastOff.gif"></CC:NavigatorItem></CC:Navigator>

              <asp:Button id="ASSIGNMENT_SUBMISSION_STU1Button_Submit" CssClass="Button" Text="Submit" CommandName="Submit" runat="server"/>
              <asp:Button id="ASSIGNMENT_SUBMISSION_STU1Cancel" CssClass="Button" Text="Cancel" runat="server"/></td>
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

