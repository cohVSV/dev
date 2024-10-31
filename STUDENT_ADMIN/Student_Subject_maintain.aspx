<!--ASPX page @1-8CD833C4-->
    <%@ Page language="vb" CodeFile="Student_Subject_maintain.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_Subject_maintain.Student_Subject_maintainPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_Subject_maintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Subject - Maintain</title>


<script language="JavaScript" type="text/javascript">
//Begin CCS script
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Include User Scripts @1-51F273ED
</script>
<script language="JavaScript" src="js/pt/prototype.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/pt/prototype_ccs.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include User Scripts

//page_button_PopupSubjectList_OnClick @42-59DB2511
function page_button_PopupSubjectList_OnClick()
{
    var result;
//End page_button_PopupSubjectList_OnClick

//Custom Code @23-2A29BDB7
    // -------------------------
    // ERA: same OpenPopupList code
    var FieldName;
    FieldName = "AddSubjectsubject_id";       // return field name
    var objYearLevel; var intYearLevel;
        objYearLevel = document.getElementById('AddSubjecthidden_ENROLMENT_YEAR');
        if (objYearLevel){intYearLevel = objYearLevel.value;} else{intYearLevel=-1};
    var win=window.open("popup_SubjectList.aspx?returncontrol="+FieldName+"&s_YEAR_LEVEL="+intYearLevel, "SubjectList", "left=40,top=10,width=380,height=480,status=no,toolbar=no,menubar=no,location=no,scrollbars=yes");
    win.focus();
    // -------------------------
//End Custom Code

//Close page_button_PopupSubjectList_OnClick @42-BC33A33A
    return result;
}
//End Close page_button_PopupSubjectList_OnClick

//page_AddSubject_ListBox_Subject_OnChange @116-1E3BF551
function page_AddSubject_ListBox_Subject_OnChange()
{
    var result;
//End page_AddSubject_ListBox_Subject_OnChange

//Custom Code @131-2A29BDB7
    // -------------------------
    // ERA: 2-Sept-2010|EA| when the drop-down list changes and not blank then set the Subject id

        if ((this.value > 0) && (this.selectedIndex > 0)) {
                //alert(this.value);
                document.getElementById('AddSubjectsubject_id').value = (this.value);
        }
        result = true;
    // -------------------------
//End Custom Code

//Close page_AddSubject_ListBox_Subject_OnChange @116-BC33A33A
    return result;
}
//End Close page_AddSubject_ListBox_Subject_OnChange

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//DEL      // -------------------------
//DEL      // manually hide the spinner
//DEL   AddSubjectListBox_SubjectHideShow1_hide(sender);
//DEL      // -------------------------


//Set Focus @35-9E9C8BE5
    if (theForm.AddSubjectsubject_id) theForm.AddSubjectsubject_id.focus();
//End Set Focus

//Close page_OnLoad @1-BC33A33A
    return result;
}
//End Close page_OnLoad

//AddSubjectListBox_SubjectPTDependentListBox1 Start @130-5351CF2B
function AddSubjectListBox_SubjectPTDependentListBox1_start(sender) {
AddSubjectListBox_SubjectHideShow1_show(sender);
    if (!sender || sender === window) return;
    var dependentElement = $("AddSubjectListBox_Subject" + sender.id.substring(34));
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
    new Ajax.Request("services/Student_Subject_maintain_AddSubject_ListBox_Subject_PTDependentListBox1.aspx?keyword=" + sender.value, {
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
        }, 
        onFailure: function(transport) {
            alert(transport.responseText);
        }
    });
AddSubjectListBox_SubjectHideShow1_hide(sender);
}
//End AddSubjectListBox_SubjectPTDependentListBox1 Start

//HideShow1 Loading @136-42B8D856
function AddSubjectListBox_SubjectHideShow1_show(sender) {
    var control = getSameLevelCtl("AddSubjectprogress", sender);
    if (control != null) {
            control.style.display = "";
    } else {
            addProgress();
    }
}
function AddSubjectListBox_SubjectHideShow1_hide(sender) {
    var control = getSameLevelCtl("AddSubjectprogress", sender);
    if (control != null) {
            control.style.display = "none";
    } else {
            removeProgress();
    }
}
//End HideShow1 Loading

//bind_events @1-3B05F01A
function bind_events() {
    addEventHandler("AddSubjectListBox_SubjectYearLevel", "change", AddSubjectListBox_SubjectPTDependentListBox1_start);
    addEventHandler("AddSubjectListBox_Subject","change",page_AddSubject_ListBox_Subject_OnChange);
    addEventHandler("button_PopupSubjectList","click",page_button_PopupSubjectList_OnClick);
    page_OnLoad();
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events
window.onload = bind_events;

//End CCS script
</script>
<style type="text/css">
<!--
#PrimarySubjectM3Grade1 td  { border-top-style: none; border-right-style: none; }
#PrimarySubjectM3Grade2 td  { border-top-style: none; border-right-style: none; }
#PrimarySubjectM3Grade3 td  { border-top-style: none; border-right-style: none; }
#PrimarySubjectM3Grade4 td  { border-top-style: none; border-right-style: none; }
#PrimarySubjectM3Grade5 td  { border-top-style: none; border-right-style: none; white-space: nowrap; vertical-align: top; }
#PrimarySubjectM3Grade6 td  { border-top-style: none; border-right-style: none; white-space: nowrap; vertical-align: top; }
#PrimarySubjectM3Grade7 td  { border-top-style: none; border-right-style: none; white-space: nowrap; vertical-align: top; }
#PrimarySubjectM3Grade8 td  { border-top-style: none; border-right-style: none; white-space: nowrap; vertical-align: top; }
#PrimarySubjectM3Grade9 td  { border-top-style: none; border-right-style: none; white-space: nowrap; vertical-align: top; }
#PrimarySubjectM3Grade10 td  { border-top-style: none; border-right-style: none; white-space: nowrap; vertical-align: top; }
#PrimarySubjectM3Grade11 td  { border-top-style: none; border-right-style: none; white-space: nowrap; vertical-align: top; }
#PrimarySubjectM3Grade12 td  { border-top-style: none; border-right-style: none; white-space: nowrap; vertical-align: top; }
#PrimarySubjectM3Grade7  { padding-top: 75px; }
#PrimarySubjectM3Grade8  { padding-top: 75px; }
#PrimarySubjectM3Grade9  { padding-top: 75px; }
#PrimarySubjectM3Grade10  { padding-top: 75px; }
#PrimarySubjectM3Grade11  { padding-top: 75px; }
#PrimarySubjectM3Grade12  { padding-top: 75px; }
.tdcenter  { text-align: center; }


/*
21-Nov-2018|EA| Full Year subject addition to shift the Row/Altrow text slightly, so it can be applied to both
*/
.GroupParent {
        font-weight: bold;
}
.GroupChild {
        font-style: italic; text-indent:10px;
}
.GroupChild a:before {
        /* show a 'sub-arrow' before link */
        content: "\21B3";
}

-->
</style>
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">

</head>
<body>
<form runat="server">


<p align="center"><DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/></p>
<p align="center">
<asp:Button id="button_PopupSubjectList" CssClass="Button" Text="Select via Popup List" OnClick="button_PopupSubjectList_OnClick" runat="server"/><br>
<br>
</p>
<p align="center">&nbsp;</p>
<p align="center">

<asp:repeater id="NewGrid1Repeater" OnItemCommand="NewGrid1ItemCommand" OnItemDataBound="NewGrid1ItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" width="85%" border="0">
    <tr>
        <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                    <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                    <th>List of Subjects</th>
 
                    <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
                <tr class="Row">
                    <td colspan="4">&nbsp;Student ID:&nbsp;<asp:Literal id="NewGrid1lblSTUDENT_ID" runat="server"/></td> 
                    <td colspan="6">&nbsp;Enrolment Year:&nbsp;<asp:Literal id="NewGrid1lblENROLMENT_YEAR" runat="server"/></td>
                </tr>
 
                <tr class="Row">
                    <td colspan="10">Subject Count:&nbsp;<asp:Literal id="NewGrid1NewGrid1_TotalRecords" runat="server"/></td>
                </tr>
 
                <tr class="Caption">
                    <th>
                    <p align="center">SUBJ ID</p>
                    </th>
 
                    <th>&nbsp;ABBREV</th>
 
                    <th>SUBJECT TITLE</th>
 
                    <th>
                    <p align="center">Delivery</p>
                    </th>
 
                    <th>&nbsp;Teacher ID</th>
 
                    <th>SEMESTER</th>
 
                    <th>
                    <CC:Sorter id="Sorter_SUBJ_ENROL_STATUSSorter" field="Sorter_SUBJ_ENROL_STATUS" OwnerState="<%# NewGrid1Data.SortField.ToString()%>" OwnerDir="<%# NewGrid1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBJ_ENROL_STATUSSort" runat="server">Status</asp:LinkButton> 
                    <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                    <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                    <th>
                    <CC:Sorter id="Sorter_Enrolment_DateSorter" field="Sorter_Enrolment_Date" OwnerState="<%# NewGrid1Data.SortField.ToString()%>" OwnerDir="<%# NewGrid1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_Enrolment_DateSort" runat="server">Enrolment Date</asp:LinkButton> 
                    <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                    <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                    <th>
                    <p align="center">
                    <CC:Sorter id="Sorter_End_DateSorter" field="Sorter_End_Date" OwnerState="<%# NewGrid1Data.SortField.ToString()%>" OwnerDir="<%# NewGrid1Data.SortDir%>" runat="server"><asp:LinkButton id="Sorter_End_DateSort" runat="server">End Date</asp:LinkButton> 
                    <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                    <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></p>
                    </th>
 
                    <th>&nbsp;Standard<br>
                    &nbsp;Learning Program - Next Module</th>
                </tr>
 
                
  </HeaderTemplate>
  <ItemTemplate>
                <tr class="<asp:Literal id="NewGrid1lblClass" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewGrid1Item)).lblClass.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>">
                    <td style="TEXT-ALIGN: right">
                        <div align="center">
<a id="NewGrid1SUBJECT_ID" href="" runat="server"  ><%#(CType(Container.DataItem,NewGrid1Item)).SUBJECT_ID.GetFormattedValue()%></a>&nbsp; 
                        </div>
                    </td> 
                    <td>&nbsp;<asp:Literal id="NewGrid1SUBJECT_ABBREV" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewGrid1Item)).SUBJECT_ABBREV.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
                    <td><asp:Literal id="NewGrid1SUBJECT_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewGrid1Item)).SUBJECT_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                    <td>
                        <p align="center"><asp:Literal id="NewGrid1Course_Distribution" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewGrid1Item)).Course_Distribution.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</p>
                    </td> 
                    <td>&nbsp;<asp:Literal id="NewGrid1TeacherID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewGrid1Item)).TeacherID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
                    <td>
                        <p align="center"><asp:Literal id="NewGrid1SEMESTER" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewGrid1Item)).SEMESTER.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</p>
                    </td> 
                    <td>
                        <p align="center"><asp:Literal id="NewGrid1SUBJ_ENROL_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewGrid1Item)).SUBJ_ENROL_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<font color="red"><asp:Literal id="NewGrid1NON_SUBMITTING_FLAG_display" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewGrid1Item)).NON_SUBMITTING_FLAG_display.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></font>&nbsp;</p>
                    </td> 
                    <td>
                        <p align="center"><asp:Literal id="NewGrid1Enrolment_Date" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewGrid1Item)).Enrolment_Date.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</p>
                    </td> 
                    <td>
                        <p align="center"><asp:Literal id="NewGrid1End_Date" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewGrid1Item)).End_Date.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</p>
                    </td> 
                    <td><asp:Literal id="NewGrid1CUSTOM_LP_display" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewGrid1Item)).CUSTOM_LP_display.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;&nbsp;<asp:Literal id="NewGrid1NEXT_MODULE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,NewGrid1Item)).NEXT_MODULE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
                </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
                
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
                <tr class="NoRecords">
                    <td colspan="10">No Subjects found for this Student and Enrolment Year</td>
                </tr>
                
  </asp:PlaceHolder>

                <tr class="Footer">
                    <td colspan="9">&nbsp;</td> 
                    <td></td>
                </tr>
            </table>
        </td>
    </tr>
</table>

  </FooterTemplate>
</asp:repeater>
</p>
<p align="center">

  <span id="STUDENTHolder" runat="server">
    


    <table class="MainTable" cellspacing="0" cellpadding="0" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Update to Standard Learning Program</th>
 
                        <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="STUDENTError" visible="False" runat="server">
  
                    <tr id="ErrorBlock" class="Error">
                        <td colspan="2"><asp:Label ID="STUDENTErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Controls">
                        <th>Student Name</th>
 
                        <td><asp:Literal id="STUDENTFIRST_NAME" runat="server"/>&nbsp;<asp:Literal id="STUDENTSURNAME" runat="server"/></td>
                    </tr>
 
                    <tr class="Controls">
                        <th colspan="2">This student has some subjects with their Learning Program not decided. <br>
                        Click on the button below to <u>update all</u> the [unknown] to [Standard Learning Program]</th>
                    </tr>
 
                    <tr class="Bottom">
                        <td style="TEXT-ALIGN: right" colspan="2">
                            <input id='STUDENTButton_Update' type="submit" class="Button" value="update all [unknown] to [Standard Learning Program]" OnServerClick='STUDENT_Update' runat="server"/></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>



  </span>
  </p>
<p align="center">

<asp:repeater id="CORESUBJECTSRepeater" OnItemCommand="CORESUBJECTSItemCommand" OnItemDataBound="CORESUBJECTSItemDataBound" runat="server">
  <HeaderTemplate>
  


    
	<script language="JavaScript" >
	var CORESUBJECTSElements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initCORESUBJECTSElements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
    <table class="MainTable" cellspacing="0" cellpadding="0" width="80%" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Add Core and Elective Subjects (7-10 only)</th>
 
                        <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Grid" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="CORESUBJECTSError" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="7"><asp:Label ID="ErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Caption">
                        <th>SUBJECT ID</th>
 
                        <th>ABBREV</th>
 
                        <th>SUBJECT TITLE</th>
 
                        <th>YEAR LEVEL</th>
 
                        <th>CORE YEAR LEVELS</th>
 
                        <th>SEMESTER</th>
 
                        <th>Enrol</th>
                    </tr>
 
                    
  </HeaderTemplate>
  <ItemTemplate>
    
                    
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
                    <tr class="Error">
                        <td colspan="7"><asp:Label ID="ErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>

                    <tr class="<asp:Literal id="CORESUBJECTSlblClass" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CORESUBJECTSItem)).lblClass.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>">
                        <td><asp:Literal id="CORESUBJECTSSUBJECT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CORESUBJECTSItem)).SUBJECT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
                        <td><asp:Literal id="CORESUBJECTSSUBJECT_ABBREV" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CORESUBJECTSItem)).SUBJECT_ABBREV.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
                        <td><asp:Literal id="CORESUBJECTSSUBJECT_TITLE" Text='<%# (CType(Container.DataItem,CORESUBJECTSItem)).SUBJECT_TITLE.GetFormattedValue() %>' runat="server"/></td> 
                        <td><asp:Literal id="CORESUBJECTSYEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CORESUBJECTSItem)).YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
                        <td><asp:Literal id="CORESUBJECTSCORE_YEARLEVELS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,CORESUBJECTSItem)).CORE_YEARLEVELS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
                        <td nowrap>
                            <asp:RadioButtonList id="CORESUBJECTSDEFAULT_SEMESTER"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
                        <td>
                            <asp:CheckBox id="CORESUBJECTSCheckBox_Delete" Visible = "<%# (CType(Container.DataItem,CORESUBJECTSItem)).IsDeleteAllowed %>" runat="server"/>&nbsp;</td>
                    </tr>
 
  </ItemTemplate>

  <FooterTemplate>
	
                    
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
                    <tr class="NoRecords">
                        <td colspan="7">No Subjects found for this Students Year Level. Please add manually (below)</td>
                    </tr>
                    
  </asp:PlaceHolder>

                    <tr class="Footer">
                        <td style="TEXT-ALIGN: right" colspan="7"><input type="button" onclick="SelectDeselectAllElectives_OnClick();" id="SelectDeselectAllElectives" class="Button" style="MARGIN-RIGHT: 20px" value="Select/Deselect All Electives" name='<%#PageVariables.Get("Button_Name")%>'/>
                            <asp:Button id="CORESUBJECTSButton_Submit" CssClass="Button" Text="Add Ticked Subjects" CommandName="Submit" runat="server"/></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>



  </FooterTemplate>
</asp:repeater>
<br>
</p>
<p align="center">

  <span id="AddSubjectHolder" runat="server">
    


    <table cellspacing="0" cellpadding="0" width="80%" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Add Subject - All Year Levels</th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="AddSubjectError" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="6"><asp:Label ID="AddSubjectErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Caption">
                        <th>&nbsp;Filter by Year Level, then select Subject</th>
 
                        <th>
                        <p align="center">Subject ID</p>
                        </th>
 
                        <th>
                        <p align="center">Semester</p>
                        </th>
 
                        <th>
                        <p align="center">Enrolment Date</p>
                        </th>
 
                        <th colspan="2">&nbsp;</th>
                    </tr>
 
                    <tr class="Controls" bgcolor="#ffe0d0">
                        <td>
                            <select id="AddSubjectListBox_SubjectYearLevel"  runat="server"></select>
 &nbsp;&nbsp;<img id="AddSubjectprogress" style="DISPLAY: none" alt="" src="images/ajax-loader_small.gif"><br>
                            
                            <select id="AddSubjectListBox_Subject"  runat="server"></select>
 </td> 
                        <td>
                            <p align="center"><asp:TextBox id="AddSubjectsubject_id" maxlength="8" Columns="6"	runat="server"/>&nbsp;</p>
                        </td> 
                        <td>
                            <p align="left">
                            <select id="AddSubjectsemester"  runat="server"></select>
 </p>
                        </td> 
                        <td>
                            <p align="center"><asp:TextBox id="AddSubjectsubj_enrol_date" maxlength="12" Columns="10"	runat="server"/></p>
                        </td> 
                        <td colspan="2">&nbsp; 
                            <input id='AddSubjectButtonAdd' type="submit" class="Button" value="Add" OnServerClick='AddSubject_ButtonAdd_OnClick' runat="server"/></td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="6" align="right"></td>
                    </tr>
                </table>
                
  <input id="AddSubjecthidden_STUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="AddSubjecthidden_ENROLMENT_YEAR" type="hidden"  runat="server"/>
  
  <input id="AddSubjectcourse_distribution" type="hidden"  runat="server"/>
  
  <input id="AddSubjectHidden_CustomProgram" type="hidden"  runat="server"/>
  </td>
        </tr>
    </table>


&nbsp;<asp:Literal id="AddSubjectlblMessage" runat="server"/>
  </span>
  </p>
<p>

  <span id="PrimarySubjectM3Holder" runat="server">
    


    <table cellspacing="0" cellpadding="0" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Add Subjects - Primary Only</th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
            </td>
        </tr>
 
        <tr>
            <td valign="top" nowrap>
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="PrimarySubjectM3Error" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="14"><asp:Label ID="PrimarySubjectM3ErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Controls">
                        <th>&nbsp;</th>
 
                        <th colspan="2">
                        <p align="center"><b>English</b></p>
                        </th>
 
                        <th colspan="2">
                        <p align="center"><b>Maths</b></p>
                        </th>
 
                        <th colspan="2">
                        <p align="center"><b>Integrated</b></p>
                        </th>
 
                        <th colspan="2">
                        <p align="center"><b>Humanities / Arts</b></p>
                        </th>
 
                        <th colspan="2">
                        <p align="center"><b>Science / Design<br>
                        &amp; Technology</b></p>
                        </th>
 
                        <th colspan="2">
                        <p align="center"><b>Health &amp; PE</b></p>
                        </th>
 
                        <th>
                        <p align="center"><b>Primary Year</b></p>
                        </th>
                    </tr>
 
                    <tr class="Controls">
                        <th>Semester</th>
 
                        <th>
                        <p align="center">Sem 1</p>
                        </th>
 
                        <th>
                        <p align="center">Sem 2</p>
                        </th>
 
                        <th>
                        <p align="center">Sem 1</p>
                        </th>
 
                        <th>
                        <p align="center">Sem 2</p>
                        </th>
 
                        <th>
                        <p align="center">Sem 1</p>
                        </th>
 
                        <th>
                        <p align="center">Sem 2</p>
                        </th>
 
                        <th>
                        <p align="center">Sem 1</p>
                        </th>
 
                        <th>
                        <p align="center">Sem 2</p>
                        </th>
 
                        <th>
                        <p align="center">Sem 1</p>
                        </th>
 
                        <th>
                        <p align="center">Sem 2</p>
                        </th>
 
                        <th>
                        <p align="center">Sem 1</p>
                        </th>
 
                        <th>
                        <p align="center">Sem 2</p>
                        </th>
 
                        <th>
                        <p align="center">Both.</p>
                        </th>
                    </tr>
 
                    <tr class="Controls">
                        <th>
                        <p align="center">Grade <br>
                        Levels</p>
                        </th>
 
                        <td nowrap>&nbsp; 
                            <asp:RadioButtonList id="PrimarySubjectM3Grade1"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td> 
                        <td nowrap>&nbsp; 
                            <asp:RadioButtonList id="PrimarySubjectM3Grade2"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td> 
                        <td nowrap>&nbsp; 
                            <asp:RadioButtonList id="PrimarySubjectM3Grade3"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td> 
                        <td nowrap>&nbsp; 
                            <asp:RadioButtonList id="PrimarySubjectM3Grade4"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td> 
                        <td nowrap>&nbsp; 
                            <asp:RadioButtonList id="PrimarySubjectM3Grade5"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td> 
                        <td nowrap>&nbsp; 
                            <asp:RadioButtonList id="PrimarySubjectM3Grade6"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td> 
                        <td nowrap>&nbsp; 
                            <asp:RadioButtonList id="PrimarySubjectM3Grade7"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td> 
                        <td nowrap>&nbsp; 
                            <asp:RadioButtonList id="PrimarySubjectM3Grade8"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td> 
                        <td nowrap>&nbsp; 
                            <asp:RadioButtonList id="PrimarySubjectM3Grade9"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td> 
                        <td nowrap>&nbsp; 
                            <asp:RadioButtonList id="PrimarySubjectM3Grade10"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td> 
                        <td nowrap>&nbsp; 
                            <asp:RadioButtonList id="PrimarySubjectM3Grade11"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td> 
                        <td nowrap>&nbsp; 
                            <asp:RadioButtonList id="PrimarySubjectM3Grade12"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td> 
                        <td>
                            <p>
                            <select id="PrimarySubjectM3Grade"  runat="server"></select>
 </p>
                        </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>Enrol Date</th>
 
                        <th><asp:TextBox id="PrimarySubjectM3EnrolDate1" Columns="10"	runat="server"/>&nbsp;</th>
 
                        <th><asp:TextBox id="PrimarySubjectM3EnrolDate2" Columns="10"	runat="server"/>&nbsp;</th>
 
                        <th><asp:TextBox id="PrimarySubjectM3EnrolDate3" Columns="10"	runat="server"/>&nbsp;</th>
 
                        <th><asp:TextBox id="PrimarySubjectM3EnrolDate4" Columns="10"	runat="server"/>&nbsp;</th>
 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td> 
                        <td><asp:TextBox id="PrimarySubjectM3EnrolDate" Columns="10"	runat="server"/></td>
                    </tr>
 
                    <tr class="Bottom">
                        <td height="40" colspan="14" align="right">
                            <input id='PrimarySubjectM3Button_Insert' type="submit" class="Button" value="Add All Subjects" OnServerClick='PrimarySubjectM3_Insert' runat="server"/></td>
                    </tr>
                </table>
                
  <input id="PrimarySubjectM3hidden_STUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="PrimarySubjectM3hidden_ENROLMENT_YEAR" type="hidden"  runat="server"/>
  </td>
        </tr>
    </table>


&nbsp;&nbsp;
  </span>
  </p>
<p><asp:Literal id="lblModified" runat="server"/></p>
<p><br>
&nbsp;</p>
<script language="JavaScript" src="js/jquery_min.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
$.noConflict();
jQuery( document ).ready(function( $ ) {
    // -------------------------
    //18 Nov 2013|EA| Primary on load and when the Year Level (Grade) drop-down changes
    // ERA: using jquery, attach the toggles to the toggle_Census and toggle_Equipment links
        // and include the extra _ to stop all being toggled on if no Year selected
        $('#PrimarySubjectM3Grade').change(function() {
            var yearid = 'PrimarySubjectM3cbExtra_'+$(this).val();
            $('input[id^="PrimarySubjectM3cbExtra_"]').removeAttr('checked');
            $('input[id^="'+yearid+'_"]').attr('checked','checked');
        });

        // force on load
        $('#PrimarySubjectM3Grade').change();
    // -------------------------
 });
</script>
<script language="JavaScript" type="text/javascript">
// 16-Dec-2016|EA| (unfuddle #776) if year level of subject and student don't match 
// then show message and confirm. If Yes (custom) then change hidden_CustomProgram => 1
function confirmCustomProgram() {
    var x;
    if (confirm("Please confirm this student is in a CLP?") == true) {
        x = "You pressed OK!";
    } else {
        x = "You pressed Cancel!";
    }
    document.getElementById("demo").innerHTML = "1";
}


   /* 16 Nov 2021|RW| Adding convenience button to toggle selection/deselection of all elective subjects (#35423)
                      Not explicitly mentioned in that request, but it's there in the original email suggestion from Jordan.
    */
   function SelectDeselectAllElectives_OnClick()
   {
      var electiveCheckboxElements = document.querySelectorAll(".MainTable td span[coreyearlevels='Elective'] input[type='checkbox']");
      var selectedElectiveCheckboxElements = document.querySelectorAll(".MainTable td span[coreyearlevels='Elective'] input[type='checkbox']:checked");
      var itemCount = electiveCheckboxElements.length;
      var selectedCount = selectedElectiveCheckboxElements.length;
      var targetCheckState = (itemCount !== selectedCount);

      for (var itemIndex = 0; itemIndex < itemCount; itemIndex++)
      {
         var checkBoxElement = electiveCheckboxElements[itemIndex];
         checkBoxElement.checked = targetCheckState;
      }
   }

   /*  16 Nov 2021|RW| Hide the select/deselect all button for now, as I'm not sure how useful or appropriate it is for different year levels.
    */
//   var electiveCheckboxElements = document.querySelectorAll(".MainTable td span[coreyearlevels='Elective']");
//   if (electiveCheckboxElements.length == 0)
//   {
      var toggleButton = document.getElementById("SelectDeselectAllElectives");
      toggleButton.style["display"] = "none";
//   }

</script>

</form>
</body>
</html>

<!--End ASPX page-->

