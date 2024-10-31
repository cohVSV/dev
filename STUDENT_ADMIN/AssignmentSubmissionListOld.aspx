<!--ASPX page @1-9B36E66A-->
    <%@ Page language="vb" CodeFile="AssignmentSubmissionListOld.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.AssignmentSubmissionListOld.AssignmentSubmissionListOldPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.AssignmentSubmissionListOld" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student <%=PageVariables.Get("STUDENT_ID")%> - Assignment Submission List</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-092F8E28
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript" charset="utf-8" src='ClientI18N.aspx?file=DatePicker.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Include User Scripts @1-51F273ED
</script>
<script language="JavaScript" src="js/pt/prototype.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/pt/prototype_ccs.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include User Scripts

//Date Picker Object Definitions @1-C9A0546B

var ASSIGNMENT_SUBMISSIONDatePicker_RETURNED_DATE = new Object(); 
ASSIGNMENT_SUBMISSIONDatePicker_RETURNED_DATE.format           = "dd/mm/yyyy";
ASSIGNMENT_SUBMISSIONDatePicker_RETURNED_DATE.style            = "Styles/Blueprint/Style.css";
ASSIGNMENT_SUBMISSIONDatePicker_RETURNED_DATE.relativePathPart = "";
ASSIGNMENT_SUBMISSIONDatePicker_RETURNED_DATE.themeVersion     = "3.0";
//End Date Picker Object Definitions

//page_ASSIGNMENT_SUBMISSION_Button_Cancel_OnClick @68-CDE02F5A
function page_ASSIGNMENT_SUBMISSION_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_ASSIGNMENT_SUBMISSION_Button_Cancel_OnClick

//page_RECEIVE_ASSIGNMENT_Button_Cancel_OnClick @194-53A5AF6B
function page_RECEIVE_ASSIGNMENT_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_RECEIVE_ASSIGNMENT_Button_Cancel_OnClick

//RECEIVE_ASSIGNMENTlistASSIGNMENTSPTDependentListBox1 Start @247-FBB7D16B
function RECEIVE_ASSIGNMENTlistASSIGNMENTSPTDependentListBox1_start(sender) {
    if (!sender || sender === window) return;
    var dependentElement = $("RECEIVE_ASSIGNMENTlistASSIGNMENTS" + sender.id.substring(30));
    if (!dependentElement) return;
    var selected = null;
    if (addEventHandler.isOnLoad) {
        if (dependentElement.multiple) {
            selected = [];
            for (var i = 0; i < dependentElement.options.length; i++)
                if (dependentElement.options[i].selected)
                    selected[dependentElement.options[i].value] = true;
        }
        else
            selected = dependentElement.value;
    }
    new Ajax.Request("services/AssignmentSubmissionList_RECEIVE_ASSIGNMENT_listASSIGNMENTS_PTDependentListBox1.aspx?keyword=" + sender.value, {
        method: "get",
        requestHeaders: ['If-Modified-Since', new Date(0)],
        onSuccess: function(transport) {
            for (var i = dependentElement.options.length - 1; i >= 0; i--) {
                var currentOption = dependentElement.options.item(i);
                if (currentOption.value != "") {
                    dependentElement.remove(i);
                }
            }
            var valueRows = eval(transport.responseText);
            for (var i = 0; i < valueRows.length; i++) {
                var newOption = new Option(valueRows[i]["1"], valueRows[i]["0"]);
                dependentElement.options[dependentElement.options.length] = newOption;
            } 
            if (CCGetParam(sender.name) == sender.value) {
                dependentElement.value = CCGetParam(dependentElement.name);
            }
            if (selected) {
                if (dependentElement.multiple) {
                    for (var i = 0; i < dependentElement.options.length; i++)
                        if (selected[dependentElement.options[i].value])
                            dependentElement.options[i].selected = true;
                }
                else
                    dependentElement.value = selected;
            }
            RECEIVE_ASSIGNMENTHideShow_ajaxbusy_hide(sender);
        }, 
        onFailure: function(transport) {
            alert(transport.responseText);
        }
    });
}
//End RECEIVE_ASSIGNMENTlistASSIGNMENTSPTDependentListBox1 Start

//HideShow_ajaxbusy Loading @249-95E8A243
function RECEIVE_ASSIGNMENTHideShow_ajaxbusy_show(sender) {
    var control = getSameLevelCtl("RECEIVE_ASSIGNMENTajaxBusy", sender);
    if (control != null) {
            control.style.display = "";
    } else {
            addProgress();
    }
}
function RECEIVE_ASSIGNMENTHideShow_ajaxbusy_hide(sender) {
    var control = getSameLevelCtl("RECEIVE_ASSIGNMENTajaxBusy", sender);
    if (control != null) {
            control.style.display = "none";
    } else {
            removeProgress();
    }
}
//End HideShow_ajaxbusy Loading

//bind_events @1-9B88786D
function bind_events() {
    addEventHandler("RECEIVE_ASSIGNMENTlistSUBJECTS", "change", RECEIVE_ASSIGNMENTlistASSIGNMENTSPTDependentListBox1_start);
    addEventHandler("RECEIVE_ASSIGNMENTlistSUBJECTS", "change", RECEIVE_ASSIGNMENTHideShow_ajaxbusy_show);
    addEventHandler("RECEIVE_ASSIGNMENT", "load", RECEIVE_ASSIGNMENTHideShow_ajaxbusy_hide);
    addEventHandler("ASSIGNMENT_SUBMISSIONButton_Cancel","click",page_ASSIGNMENT_SUBMISSION_Button_Cancel_OnClick);
    addEventHandler("RECEIVE_ASSIGNMENTButton_Cancel","click",page_RECEIVE_ASSIGNMENT_Button_Cancel_OnClick);
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


<p align="center">Back to:&nbsp; <a id="link_Menu" href="" class="Button" runat="server"  >Main Menu</a>|&nbsp;&nbsp;<a id="Link_SearchRequest" href="" class="Button" runat="server"  >Search Request</a>|&nbsp;&nbsp;<a id="link_Assignments" href="" class="Button" runat="server"  >Assignments</a>| <a id="Link10" href="" class="Button" runat="server"  >SMS</a> |&nbsp;<a id="Link6" href="" class="Button" runat="server"  >Future Intentions</a> | &nbsp; <a id="Link5" href="" class="Button" runat="server"  >Comments</a><br>
<br>
<p>&nbsp; <a href="OnlineHelp/Assignment%20Edit%20Return%20Details/Assignment_EditReturnDetails.html" title="show help for this page" target="_blank"><img border="0" alt="show help for this page" src="images/help.png" align="right"></a> 

	<asp:PlaceHolder id="Panel_MenuStudentMaintain" Visible="false" runat="server">
	<DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/>&nbsp;&nbsp;
	</asp:PlaceHolder>
	</p>
<p align="center"><a id="Link_Backtosummary" href="" class="Button" runat="server"  >Back to Summary</a>|&nbsp;&nbsp;<a id="Link_BacktoPastoralList" href="" class="Button" runat="server"  >Back to Student Support Group List</a></p>
<p align="center">
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      
  <span id="RECEIVE_ASSIGNMENTHolder" runat="server">
    
      

        <table cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td valign="top">
              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                  <th>Receive Assignment</th>
 
                  <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                </tr>
              </table>
 
              <table class="Record" cellspacing="0" cellpadding="0">
                
  <asp:PlaceHolder id="RECEIVE_ASSIGNMENTError" visible="False" runat="server">
  
                <tr class="Error">
                  <td colspan="2"><asp:Label ID="RECEIVE_ASSIGNMENTErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th>Student's Subject</th>
 
                  <td>
                    <select id="RECEIVE_ASSIGNMENTlistSUBJECTS"  runat="server"></select>
 </td>
                </tr>
 
                <tr class="Controls">
                  <th>Assignment <asp:Image id="RECEIVE_ASSIGNMENTajaxBusy"  style="DISPLAY: none" AlternateText="updating" ImageUrl="images/ajax_loader_smallblue.gif" runat="server"/></th>
 
                  <td>
                    <select id="RECEIVE_ASSIGNMENTlistASSIGNMENTS"  runat="server"></select>
 </td>
                </tr>
 
                <tr class="Bottom">
                  <td colspan="2" align="right">
                    <input id='RECEIVE_ASSIGNMENTButton_Insert' type="submit" class="Button" value="Add Assignment" OnServerClick='RECEIVE_ASSIGNMENT_Insert' runat="server"/>
                    <input id='RECEIVE_ASSIGNMENTButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='RECEIVE_ASSIGNMENT_Cancel' runat="server"/>
  <input id="RECEIVE_ASSIGNMENTSTUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="RECEIVE_ASSIGNMENTENROLMENT_YEAR" type="hidden"  runat="server"/>
  
  <input id="RECEIVE_ASSIGNMENTLAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="RECEIVE_ASSIGNMENTLAST_ALTERED_DATE" type="hidden"  runat="server"/>
  </td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
      

      
  </span>
  
      <p></p>
    </td> 
    <td valign="top">&nbsp;</td> 
    <td valign="top">
      
  <span id="ASSIGNMENT_SUBMISSIONHolder" runat="server">
    
      

        <table cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td valign="top">
              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                  <th>Return Assignment</th>
 
                  <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                </tr>
              </table>
 
              <table class="Record" cellspacing="0" cellpadding="0">
                
  <asp:PlaceHolder id="ASSIGNMENT_SUBMISSIONError" visible="False" runat="server">
  
                <tr class="Error">
                  <td colspan="2"><asp:Label ID="ASSIGNMENT_SUBMISSIONErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th>Assignment&nbsp; / Submission</th>
 
                  <td><asp:Literal id="ASSIGNMENT_SUBMISSIONlblAssignment" runat="server"/>&nbsp; / <asp:Literal id="ASSIGNMENT_SUBMISSIONlblSubmission" runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th>RECEIVED DATE <em>from Student</em></th>
 
                  <td><asp:Literal id="ASSIGNMENT_SUBMISSIONlblRECEIVED_DATE" runat="server"/>
  <input id="ASSIGNMENT_SUBMISSIONRECEIVED_DATE" type="hidden"  runat="server"/>
  </td>
                </tr>
 
                <tr class="Controls">
                  <th>RETURNED DATE <em>from VSV</em></th>
 
                  <td><asp:TextBox id="ASSIGNMENT_SUBMISSIONRETURNED_DATE" maxlength="100" Columns="10"	runat="server"/>
                    <asp:PlaceHolder id="ASSIGNMENT_SUBMISSIONDatePicker_RETURNED_DATE" runat="server"><a href="javascript:showDatePicker('<%#ASSIGNMENT_SUBMISSIONDatePicker_RETURNED_DATEName%>','forms[\''+theForm.id+'\']','<%#ASSIGNMENT_SUBMISSIONDatePicker_RETURNED_DATEDateControl%>');" id="ASSIGNMENT_SUBMISSIONDatePicker_RETURNED_DATE_Link"  ><img id="ASSIGNMENT_SUBMISSIONDatePicker_RETURNED_DATE_Image" border="0" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" /></a></asp:PlaceHolder>
  <asp:Literal id="ASSIGNMENT_SUBMISSIONlblDefaulted_Returned" runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th>MARKER ID</th>
 
                  <td>
                    <select id="ASSIGNMENT_SUBMISSIONSTAFF_ID"  runat="server"></select>
 <asp:Literal id="ASSIGNMENT_SUBMISSIONlblDefaulted_Marker" runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th>COMMENT 
                  <div id="maxchar_comment">
                    60 characters allowed 
                  </div>
                  </th>
 
                  <td>
<asp:TextBox id="ASSIGNMENT_SUBMISSIONCOMMENTS" onkeyup="limitMaxLength(this,60,'maxchar_comment');" rows="4" Columns="45" TextMode="MultiLine"	runat="server"/>
</td>
                </tr>
 
                <tr class="Bottom">
                  <td colspan="2" align="right">
                    <input id='ASSIGNMENT_SUBMISSIONButton_Update' type="submit" class="Button" value="Update" OnServerClick='ASSIGNMENT_SUBMISSION_Update' runat="server"/>
                    <input id='ASSIGNMENT_SUBMISSIONButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='ASSIGNMENT_SUBMISSION_Cancel' runat="server"/>
  <input id="ASSIGNMENT_SUBMISSIONSTUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="ASSIGNMENT_SUBMISSIONENROLMENT_YEAR" type="hidden"  runat="server"/>
  
  <input id="ASSIGNMENT_SUBMISSIONSUBJECT_ID" type="hidden"  runat="server"/>
  
  <input id="ASSIGNMENT_SUBMISSIONASSIGNMENT_ID" type="hidden"  runat="server"/>
  
  <input id="ASSIGNMENT_SUBMISSIONLAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="ASSIGNMENT_SUBMISSIONLAST_ALTERED_DATE" type="hidden"  runat="server"/>
  </td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
      

      
  </span>
  </td>
  </tr>
</table>
</p>

<asp:repeater id="ASSIGNMENT_SUBMISSION_SUBRepeater" OnItemCommand="ASSIGNMENT_SUBMISSION_SUBItemCommand" OnItemDataBound="ASSIGNMENT_SUBMISSION_SUBItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" align="center" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>Assignments Submitted <span style="font-size: small">(Return to the student VSV Online activity page <a href="AssignmentSubmissionList.aspx<%: Request.Url.Query %>">here</a>)</th>
 
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Row">
          <td colspan="5">&nbsp;<strong>Student ID:</strong> <asp:Literal id="ASSIGNMENT_SUBMISSION_SUBlblStudent" runat="server"/></td> 
          <td colspan="6">&nbsp;&nbsp;&nbsp;&nbsp;<strong>Enrolment Year: </strong><asp:Literal id="ASSIGNMENT_SUBMISSION_SUBlblYear" runat="server"/></td>
        </tr>
 
        <tr class="Row">
          <td colspan="11">Total Records:&nbsp;<asp:Literal id="ASSIGNMENT_SUBMISSION_SUBASSIGNMENT_SUBMISSION_SUB_TotalRecords" runat="server"/>&nbsp;&nbsp;&nbsp;&nbsp;<a id="ASSIGNMENT_SUBMISSION_SUBlinkAddAssignment" href="" class="Button" style="HEIGHT: 10px; PADDING-BOTTOM: 2px; PADDING-TOP: 2px; PADDING-LEFT: 4px; PADDING-RIGHT: 4px" runat="server"  >Add Assignment</a></td>
        </tr>
 
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_ASSIGNMENT_SUBMISSION_SUBJECT_IDSorter" field="Sorter_ASSIGNMENT_SUBMISSION_SUBJECT_ID" OwnerState="<%# ASSIGNMENT_SUBMISSION_SUBData.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENT_SUBMISSION_SUBData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ASSIGNMENT_SUBMISSION_SUBJECT_IDSort" runat="server">Subject ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SUBJECT_TITLESorter" field="Sorter_SUBJECT_TITLE" OwnerState="<%# ASSIGNMENT_SUBMISSION_SUBData.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENT_SUBMISSION_SUBData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBJECT_TITLESort" runat="server">Subject Title</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_ASSIGNMENT_IDSorter" field="Sorter_ASSIGNMENT_ID" OwnerState="<%# ASSIGNMENT_SUBMISSION_SUBData.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENT_SUBMISSION_SUBData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ASSIGNMENT_IDSort" runat="server">Assignment No.</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_SUBMISSION_IDSorter" field="Sorter_SUBMISSION_ID" OwnerState="<%# ASSIGNMENT_SUBMISSION_SUBData.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENT_SUBMISSION_SUBData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBMISSION_IDSort" runat="server">Submission No.</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_DESCRIPTIONSorter" field="Sorter_DESCRIPTION" OwnerState="<%# ASSIGNMENT_SUBMISSION_SUBData.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENT_SUBMISSION_SUBData.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_DESCRIPTIONSort" runat="server">Description</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
          <th>&nbsp;</th>
 
          <th>
          <CC:Sorter id="Sorter_received_dateSorter" field="Sorter_received_date" OwnerState="<%# ASSIGNMENT_SUBMISSION_SUBData.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENT_SUBMISSION_SUBData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_received_dateSort" runat="server">Received Date</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_returned_dateSorter" field="Sorter_returned_date" OwnerState="<%# ASSIGNMENT_SUBMISSION_SUBData.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENT_SUBMISSION_SUBData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_returned_dateSort" runat="server">Returned Date</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_STAFF_IDSorter" field="Sorter_STAFF_ID" OwnerState="<%# ASSIGNMENT_SUBMISSION_SUBData.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENT_SUBMISSION_SUBData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STAFF_IDSort" runat="server">Marker ID</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>&nbsp;Last Altered By / Date</th>
 
          <th>
          <CC:Sorter id="Sorter_COMMENTSSorter" field="Sorter_COMMENTS" OwnerState="<%# ASSIGNMENT_SUBMISSION_SUBData.SortField.ToString()%>" OwnerDir="<%# ASSIGNMENT_SUBMISSION_SUBData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_COMMENTSSort" runat="server">Comments</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr  <CC:AttributeBinder runat="server" Name="rowStyle" ContainerId="ASSIGNMENT_SUBMISSION_SUBRepeater"/>>
          <td style="TEXT-ALIGN: right"><asp:Literal id="ASSIGNMENT_SUBMISSION_SUBASSIGNMENT_SUBMISSION_SUBJECT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSION_SUBItem)).ASSIGNMENT_SUBMISSION_SUBJECT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="ASSIGNMENT_SUBMISSION_SUBSUBJECT_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSION_SUBItem)).SUBJECT_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="ASSIGNMENT_SUBMISSION_SUBASSIGNMENT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSION_SUBItem)).ASSIGNMENT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="ASSIGNMENT_SUBMISSION_SUBSUBMISSION_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSION_SUBItem)).SUBMISSION_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="ASSIGNMENT_SUBMISSION_SUBDESCRIPTION" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSION_SUBItem)).DESCRIPTION.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>
            <a id="ASSIGNMENT_SUBMISSION_SUBLink_ReturnAssignment" href="" class="Button" style="HEIGHT: 10px; PADDING-BOTTOM: 2px; PADDING-TOP: 2px; PADDING-LEFT: 4px; PADDING-RIGHT: 4px" runat="server"  >edit</a></td> 
          <td>&nbsp;<asp:Literal id="ASSIGNMENT_SUBMISSION_SUBreceived_date" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSION_SUBItem)).received_date.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="ASSIGNMENT_SUBMISSION_SUBreturned_date" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSION_SUBItem)).returned_date.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td>&nbsp;<asp:Literal id="ASSIGNMENT_SUBMISSION_SUBSTAFF_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSION_SUBItem)).STAFF_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td><asp:Literal id="ASSIGNMENT_SUBMISSION_SUBLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSION_SUBItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ <asp:Literal id="ASSIGNMENT_SUBMISSION_SUBLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSION_SUBItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
          <td>&nbsp;<asp:Literal id="ASSIGNMENT_SUBMISSION_SUBCOMMENTS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,ASSIGNMENT_SUBMISSION_SUBItem)).COMMENTS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <SeparatorTemplate>
	
        <tr class="Separator">
          <td colspan="11"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
        
  </SeparatorTemplate>
  <FooterTemplate>
	
        
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="11">No Assignments found</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="11">
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# ASSIGNMENT_SUBMISSION_SUBData.PagesCount%>" PageSize="<%# ASSIGNMENT_SUBMISSION_SUBData.RecordsPerPage%>" PageNumber="<%# ASSIGNMENT_SUBMISSION_SUBData.PageNumber%>" runat="server">
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server">First</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="FirstOff" runat="server">First </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server">Prev</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOff" runat="server">Prev </CC:NavigatorItem>&nbsp; 
            
<CC:Pager id="NavigatorPager" Style="Centered" PagerSize="10" runat="server">
            <PageOnTemplate><asp:LinkButton runat="server"><%# (CType(Container,PagerItem)).PageNumber.ToString() %></asp:LinkButton>&nbsp;</PageOnTemplate>
            <PageOffTemplate><%# (CType(Container,PagerItem)).PageNumber.ToString() %>&nbsp;</PageOffTemplate></CC:Pager>of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server">Next</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="NextOff" runat="server">Next </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server">Last</asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOff" runat="server">Last </CC:NavigatorItem></CC:Navigator>
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
<script language="JavaScript" type="text/javascript">
function limitMaxLength(formitem,maxlength,displaydivname) {
        if (isNaN(maxlength)) {
                return false;
        } else {
                var outputdiv = document.getElementById(displaydivname)
                outputdiv.innerHTML = (maxlength-formitem.value.length) + ' characters allowed';
                if (formitem.value.length+1>maxlength) {
                        formitem.value=formitem.value.substring(0,maxlength);
                }
        }
}
</script>

</form>
</body>
</html>

<!--End ASPX page-->

