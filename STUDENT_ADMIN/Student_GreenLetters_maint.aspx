<!--ASPX page @1-3F0259A9-->
    <%@ Page language="vb" CodeFile="Student_GreenLetters_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_GreenLetters_maint.Student_GreenLetters_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_GreenLetters_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="description" content="Allows Coordinators etc to manage the F-10 'Green' (and Amber and Red) letters students.&#13;&#10;Likely that SST will also be allowed to change items too."><meta name="GENERATOR" content="CodeCharge Studio 5.1.0.18696"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Green Letters</title>



<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-092F8E28
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript" charset="utf-8" src='ClientI18N.aspx?file=DatePicker.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Date Picker Object Definitions @1-46D91441

var viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1 = new Object(); 
viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1.format           = "dd/mm/yyyy";
viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1.style            = "Styles/Blueprint/Style.css";
viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1.relativePathPart = "";
viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1.themeVersion     = "3.0";
var viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1 = new Object(); 
viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1.format           = "dd/mm/yyyy";
viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1.style            = "Styles/Blueprint/Style.css";
viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1.relativePathPart = "";
viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1.themeVersion     = "3.0";
var viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1 = new Object(); 
viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1.format           = "dd/mm/yyyy";
viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1.style            = "Styles/Blueprint/Style.css";
viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1.relativePathPart = "";
viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1.themeVersion     = "3.0";
var GREEN_AMBER_RED_LETTERSDatePicker_GREEN_LETTER_SENT_DATE1 = new Object(); 
GREEN_AMBER_RED_LETTERSDatePicker_GREEN_LETTER_SENT_DATE1.format           = "dd/mm/yyyy";
GREEN_AMBER_RED_LETTERSDatePicker_GREEN_LETTER_SENT_DATE1.style            = "Styles/Blueprint/Style.css";
GREEN_AMBER_RED_LETTERSDatePicker_GREEN_LETTER_SENT_DATE1.relativePathPart = "";
GREEN_AMBER_RED_LETTERSDatePicker_GREEN_LETTER_SENT_DATE1.themeVersion     = "3.0";
//End Date Picker Object Definitions

//page_viewMaintainSearchRequest_Cancel_OnClick @52-874AE381
function page_viewMaintainSearchRequest_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_viewMaintainSearchRequest_Cancel_OnClick

//page_GREEN_AMBER_RED_LETTERS_Button_Cancel_OnClick @180-5974A060
function page_GREEN_AMBER_RED_LETTERS_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_GREEN_AMBER_RED_LETTERS_Button_Cancel_OnClick

//bind_events @1-8AA7463B
function bind_events() {
    addEventHandler("viewMaintainSearchRequestCancel","click",page_viewMaintainSearchRequest_Cancel_OnClick);
    addEventHandler("GREEN_AMBER_RED_LETTERSButton_Cancel","click",page_GREEN_AMBER_RED_LETTERS_Button_Cancel_OnClick);
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

//End CCS script
</script>
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">

</head>
<body>
<form runat="server">


<p align="center"><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p align="center">
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      
  <span id="GREEN_AMBER_RED_LETTERS_vHolder" runat="server">
    
      

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
                
  <asp:PlaceHolder id="GREEN_AMBER_RED_LETTERS_vError" visible="False" runat="server">
  
                <tr id="<%=PageVariables.Get("@error-block")%>" class="Error">
                  <td colspan="2"><asp:Label ID="GREEN_AMBER_RED_LETTERS_vErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th>Support Teacher</th>
 
                  <td>
                    <select id="GREEN_AMBER_RED_LETTERS_vs_STAFF_ID"  runat="server"></select>
 </td>
                </tr>
 
                <tr class="Controls">
                  <th>STUDENT ID</th>
 
                  <td><asp:TextBox id="GREEN_AMBER_RED_LETTERS_vs_STUDENT_ID" maxlength="12" Columns="12"	runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th>Sub School&nbsp;</th>
 
                  <td>
                    <asp:RadioButtonList id="GREEN_AMBER_RED_LETTERS_vs_SUBSCHOOL"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Bottom">
                  <td style="TEXT-ALIGN: right" colspan="2">
                    <input id='GREEN_AMBER_RED_LETTERS_vButton_DoSearch' type="submit" class="Button" value="Search" OnServerClick='GREEN_AMBER_RED_LETTERS_v_Search' runat="server"/></td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
      

      
  </span>
  </td> 
    <td valign="top">&nbsp; &nbsp; &nbsp;&nbsp;</td> 
    <td valign="top">
      
  <span id="GREEN_AMBER_RED_LETTERSHolder" runat="server">
    
      

        <table class="MainTable" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td valign="top">
              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
                  <th>Add Green Letter Student</th>
 
                  <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
                </tr>
              </table>
 
              <table class="Record" cellspacing="0" cellpadding="0">
                
  <asp:PlaceHolder id="GREEN_AMBER_RED_LETTERSError" visible="False" runat="server">
  
                <tr id="ErrorBlock" class="Error">
                  <td colspan="2"><asp:Label ID="GREEN_AMBER_RED_LETTERSErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th>STUDENT ID</th>
 
                  <td><asp:TextBox id="GREEN_AMBER_RED_LETTERSSTUDENT_ID" maxlength="12" Columns="12"	runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th>GREEN LETTER SEND?</th>
 
                  <td>
                    <asp:RadioButtonList id="GREEN_AMBER_RED_LETTERSGREEN_LETTER_SENT_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th>GREEN LETTER SENT DATE<br>
                  <span style="FONT-SIZE: 10px">leave blank to auto-email</span> </th>
 
                  <td>
                    <asp:TextBox id="GREEN_AMBER_RED_LETTERSGREEN_LETTER_SENT_DATE" maxlength="100" Columns="10"	runat="server"/>
                    <asp:PlaceHolder id="GREEN_AMBER_RED_LETTERSDatePicker_GREEN_LETTER_SENT_DATE1" runat="server"><a href="javascript:showDatePicker('<%#GREEN_AMBER_RED_LETTERSDatePicker_GREEN_LETTER_SENT_DATE1Name%>','forms[\''+theForm.id+'\']','<%#GREEN_AMBER_RED_LETTERSDatePicker_GREEN_LETTER_SENT_DATE1DateControl%>');" id="GREEN_AMBER_RED_LETTERSDatePicker_GREEN_LETTER_SENT_DATE1_Link"  ><img id="GREEN_AMBER_RED_LETTERSDatePicker_GREEN_LETTER_SENT_DATE1_Image" border="0" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" />&nbsp;</a></asp:PlaceHolder>
  </td>
                </tr>
 
                <tr class="Bottom">
                  <td style="TEXT-ALIGN: right" colspan="2">
                    <input id='GREEN_AMBER_RED_LETTERSButton_Insert' type="submit" class="Button" value="Add Student" OnServerClick='GREEN_AMBER_RED_LETTERS_Insert' runat="server"/>
                    <input id='GREEN_AMBER_RED_LETTERSButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='GREEN_AMBER_RED_LETTERS_Cancel' runat="server"/>
  <input id="GREEN_AMBER_RED_LETTERSLAST_ALTERED_BY" type="hidden"  runat="server"/>
  </td>
                </tr>
              </table>
 
              <p><em>Student must be:<br>
              - Currently Enrolled AND <br>
              - Not already on the list</em></p>
            </td>
          </tr>
        </table>
      

      
  </span>
  </td>
  </tr>
</table>
<br>

<asp:repeater id="viewMaintainSearchRequestRepeater" OnItemCommand="viewMaintainSearchRequestItemCommand" OnItemDataBound="viewMaintainSearchRequestItemDataBound" runat="server">
  <HeaderTemplate>
  


  
	<script language="JavaScript" >
	var viewMaintainSearchRequestElements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initviewMaintainSearchRequestElements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
  <table class="MainTable" cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Maintain Amber / Red Letters - Current Enrolment Year</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Grid" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="viewMaintainSearchRequestError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="15"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Row">
            <td colspan="15">Total Records:&nbsp;<asp:Literal id="viewMaintainSearchRequestviewMaintainSearchRequest_TotalRecords" runat="server"/></td>
          </tr>
 
          <tr>
            <th colspan="6">&nbsp;&nbsp;</th>
 
            <th style="BACKGROUND-COLOR: lightgreen" colspan="2">GREEN LETTER&nbsp;&nbsp;<br>
            <span style="FONT-SIZE: 10px">'Y' and blank date to auto-email</span> </th>
 
            <th style="BACKGROUND-COLOR: orange" colspan="2">AMBER LETTER&nbsp;&nbsp;<br>
            <span style="FONT-SIZE: 10px">Sent manually</span> <img onclick="javascript:alert(this.getAttribute('title'));" title="Requires Green Letter to be SENT AND Green Sent Date over 10 days ago" src="images/icon_info.gif"></th>
 
            <th style="BACKGROUND-COLOR: firebrick" colspan="2">RED LETTER&nbsp;&nbsp;<br>
            <span style="FONT-SIZE: 10px">Sent manually</span> <img onclick="javascript:alert(this.getAttribute('title'));" title="Requires Green AND Amber Letters to be SENT AND Amber Sent Date over 10 days ago" src="images/icon_info.gif"></th>
 
            <th>&nbsp;</th>
 
            <th>&nbsp;</th>
 
            <th>&nbsp;</th>
          </tr>
 
          <tr class="Caption">
            <th>
            <CC:Sorter id="Sorter_STUDENT_IDSorter" field="Sorter_STUDENT_ID" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_STUDENT_IDSort" runat="server">STUDENT ID</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">SURNAME</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_FIRST_NAMESorter" field="Sorter_FIRST_NAME" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_FIRST_NAMESort" runat="server">FIRST NAME</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_YEAR_LEVELSorter" field="Sorter_YEAR_LEVEL" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_YEAR_LEVELSort" runat="server">YEAR</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_PASTORAL_CARE_IDSorter" field="Sorter_PASTORAL_CARE_ID" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_PASTORAL_CARE_IDSort" runat="server">LAd</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_FIRST_ADDED_DATESorter" field="Sorter_FIRST_ADDED_DATE" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_FIRST_ADDED_DATESort" runat="server">FIRST ADDED DATE</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_GREEN_LETTER_SENT_FLAGSorter" field="Sorter_GREEN_LETTER_SENT_FLAG" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_GREEN_LETTER_SENT_FLAGSort" runat="server">GREEN SEND?</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_GREEN_LETTER_SENT_DATESorter" field="Sorter_GREEN_LETTER_SENT_DATE" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_GREEN_LETTER_SENT_DATESort" runat="server">GREEN SENT DATE</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_AMBER_LETTER_SENT_FLAGSorter" field="Sorter_AMBER_LETTER_SENT_FLAG" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_AMBER_LETTER_SENT_FLAGSort" runat="server">AMBER SENT?</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_AMBER_LETTER_SENT_DATESorter" field="Sorter_AMBER_LETTER_SENT_DATE" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_AMBER_LETTER_SENT_DATESort" runat="server">AMBER SENT DATE</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_RED_LETTER_SENT_FLAGSorter" field="Sorter_RED_LETTER_SENT_FLAG" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_RED_LETTER_SENT_FLAGSort" runat="server">RED SENT?</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_RED_LETTER_SENT_DATESorter" field="Sorter_RED_LETTER_SENT_DATE" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_RED_LETTER_SENT_DATESort" runat="server">RED SENT DATE</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_LAST_ALTERED_BYSorter" field="Sorter_LAST_ALTERED_BY" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_LAST_ALTERED_BYSort" runat="server">LAST ALTERED BY</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter>/ 
            <CC:Sorter id="Sorter_LAST_ALTERED_DATE1Sorter" field="Sorter_LAST_ALTERED_DATE1" OwnerState="<%# viewMaintainSearchRequestData.SortField.ToString()%>" OwnerDir="<%# viewMaintainSearchRequestData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_LAST_ALTERED_DATE1Sort" runat="server">DATE</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th></th>
 
            <th></th>
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
    
          
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
          <tr class="Error">
            <td colspan="15"><asp:Label ID="ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Row">
            <td><a id="viewMaintainSearchRequestSTUDENT_ID" href="" title="open Summary in new tab" target="_blank" runat="server"  ><%#(CType(Container.DataItem,viewMaintainSearchRequestItem)).STUDENT_ID.GetFormattedValue()%></a></td> 
            <td><asp:Literal id="viewMaintainSearchRequestSURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequestItem)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td><asp:Literal id="viewMaintainSearchRequestFIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequestItem)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td><asp:Literal id="viewMaintainSearchRequestYEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequestItem)).YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td><asp:Literal id="viewMaintainSearchRequestPASTORAL_CARE_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequestItem)).PASTORAL_CARE_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td><asp:Literal id="viewMaintainSearchRequestFIRST_ADDED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequestItem)).FIRST_ADDED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td>
              <asp:RadioButtonList id="viewMaintainSearchRequestGREEN_LETTER_SENT_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
            <td>
              <asp:TextBox id="viewMaintainSearchRequestGREEN_LETTER_SENT_DATE" Text='<%# (CType(Container.DataItem,viewMaintainSearchRequestItem)).GREEN_LETTER_SENT_DATE.GetFormattedValue() %>' onfocus="this.select();" maxlength="100" Columns="10"	runat="server"/>&nbsp; 
              <asp:PlaceHolder id="viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1" runat="server"><a href="javascript:showDatePicker('<%#viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1Name%>','forms[\''+theForm.id+'\']','<%#viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1DateControl%>');" id="viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1_Link"  ><img id="viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1_Image" border="0" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" /></a></asp:PlaceHolder>
  </td> 
            <td>
              <asp:RadioButtonList id="viewMaintainSearchRequestAMBER_LETTER_SENT_FLAG"  onclick="javascript:getStatus_SetDate(this.id);" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
            <td>
              <asp:TextBox id="viewMaintainSearchRequestAMBER_LETTER_SENT_DATE" Text='<%# (CType(Container.DataItem,viewMaintainSearchRequestItem)).AMBER_LETTER_SENT_DATE.GetFormattedValue() %>' onfocus="this.select();" maxlength="100" Columns="10"	runat="server"/>&nbsp; 
              <asp:PlaceHolder id="viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1" runat="server"><a href="javascript:showDatePicker('<%#viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1Name%>','forms[\''+theForm.id+'\']','<%#viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1DateControl%>');" id="viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1_Link"  ><img id="viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1_Image" border="0" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" /></a></asp:PlaceHolder>
  
  <input id="viewMaintainSearchRequesthidden_DaysSince_Green"  value='<%# (CType(Container.DataItem,viewMaintainSearchRequestItem)).hidden_DaysSince_Green.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td> 
            <td>
              <asp:RadioButtonList id="viewMaintainSearchRequestRED_LETTER_SENT_FLAG"  onclick="javascript:getStatus_SetDate(this.id);" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
            <td>
              <asp:TextBox id="viewMaintainSearchRequestRED_LETTER_SENT_DATE" Text='<%# (CType(Container.DataItem,viewMaintainSearchRequestItem)).RED_LETTER_SENT_DATE.GetFormattedValue() %>' onfocus="this.select();" maxlength="100" Columns="10"	runat="server"/>&nbsp; 
              <asp:PlaceHolder id="viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1" runat="server"><a href="javascript:showDatePicker('<%#viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1Name%>','forms[\''+theForm.id+'\']','<%#viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1DateControl%>');" id="viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1_Link"  ><img id="viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1_Image" border="0" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" /></a></asp:PlaceHolder>
  
  <input id="viewMaintainSearchRequesthidden_DaysSince_Amber"  value='<%# (CType(Container.DataItem,viewMaintainSearchRequestItem)).hidden_DaysSince_Amber.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td> 
            <td><asp:Literal id="viewMaintainSearchRequestLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequestItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ <asp:Literal id="viewMaintainSearchRequestLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,viewMaintainSearchRequestItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td></td> 
            <td>
              <asp:CheckBox id="viewMaintainSearchRequestCheckBox_Delete" Visible = "<%# (CType(Container.DataItem,viewMaintainSearchRequestItem)).IsDeleteAllowed %>" runat="server"/>&nbsp;</td>
          </tr>
 
  </ItemTemplate>

  <FooterTemplate>
	
          
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
          <tr class="NoRecords">
            <td colspan="15">No Students with Green Letters found for that Student ID or Support Teacher!</td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Footer">
            <td style="TEXT-ALIGN: right" colspan="15">
              
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# viewMaintainSearchRequestData.PagesCount%>" PageSize="<%# viewMaintainSearchRequestData.RecordsPerPage%>" PageNumber="<%# viewMaintainSearchRequestData.PageNumber%>" runat="server"><span class="Navigator">Records per page 
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

              <asp:Button id="viewMaintainSearchRequestButton_Submit" CssClass="Button" Text="Submit" CommandName="Submit" runat="server"/>
              <asp:Button id="viewMaintainSearchRequestCancel" CssClass="Button" Text="Cancel" runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </FooterTemplate>
</asp:repeater>
<br>
</p>
<script type="text/javascript">
function getStatus_SetDate(ctlid)
{
// 9-Mar-2015|EA| re-use code from StudentSubject_Details-maintain Runs Taken
// originally from Vikas 1-Feb-2010 for unfuddle ticket #210 to auto fill date to today when Runs Taken set to 'Sent' and date is blank
//alert(ctlid);
 if (ctlid)
 {
    var YESRadiobuttonid = ctlid + "_0";
    var NORadiobuttonid = ctlid + "_1";
    var dateSentTextBox = ctlid.replace("FLAG","DATE");
    var TodayDate=new Date();
    var tdate = TodayDate.getDate();
    var month = TodayDate.getMonth()+1;
    var yr = TodayDate.getFullYear().toString();
    
    if (tdate<10)
        tdate = "0" + tdate;
    if (month<10)
        month = "0" + month;
    //yr= yr.substring(2,4);
        
    var setDateFormat= tdate + "/" +  month + "/" + yr ;
    if (document.getElementById(YESRadiobuttonid).checked==true)
    {
       document.getElementById(dateSentTextBox).value=setDateFormat;
    }
    else if (document.getElementById(NORadiobuttonid).checked==true)
    {
        document.getElementById(dateSentTextBox).value="";    
    }    
 }
}
</script>

</form>
</body>
</html>

<!--End ASPX page-->

