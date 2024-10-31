<!--ASPX page @1-73F287C0-->
    <%@ Page language="vb" CodeFile="Student_ClassList_Reports.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_ClassList_Reports.Student_ClassList_ReportsPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_ClassList_Reports" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 4.1.00.032"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Class List Reports</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_CLASS_LIST_Panel_Button_DoSearch_OnClick @80-645F28F1
function page_CLASS_LIST_Panel_Button_DoSearch_OnClick()
{
    var result;
//End page_CLASS_LIST_Panel_Button_DoSearch_OnClick

//Custom Code @90-2A29BDB7
    // -------------------------
    if (document.getElementById('CLASS_LIST_PanelList_SUBJECT_ID').value=='')
        {
                alert('Select Subject');
                return false;
        }
        else if (document.getElementById('CLASS_LIST_PanelList_SUBJECT_ENROL_STATUS').value=='')
        {
                alert('Select Subject Enrolment Status');
                return false;
}
    // -------------------------
//End Custom Code

//Close page_CLASS_LIST_Panel_Button_DoSearch_OnClick @80-BC33A33A
    return result;
}
//End Close page_CLASS_LIST_Panel_Button_DoSearch_OnClick

//page_STUDENT_COMMENT_Button_Cancel_OnClick @15-3BF1766F
function page_STUDENT_COMMENT_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_COMMENT_Button_Cancel_OnClick

//bind_events @1-BF2C88A7
function bind_events() {
    addEventHandler("CLASS_LIST_PanelButton_DoSearch","click",page_CLASS_LIST_Panel_Button_DoSearch_OnClick);
    addEventHandler("STUDENT_COMMENTButton_Cancel","click",page_STUDENT_COMMENT_Button_Cancel_OnClick);
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
&nbsp;&nbsp; 

  <span id="CLASS_LIST_PanelHolder" runat="server">
    


    <table cellspacing="0" cellpadding="0" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Search My Classes</th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="CLASS_LIST_PanelError" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="2"><asp:Label ID="CLASS_LIST_PanelErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Controls">
                        <th>&nbsp;Subject: </th>
 
                        <td>&nbsp; 
                            <select id="CLASS_LIST_PanelList_Subject_id" style="WIDTH: 313px"  runat="server"></select>
 &nbsp;&nbsp; </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;<span style="FONT-SIZE: 9pt; FONT-FAMILY: 'Verdana','sans-serif'; mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">Subject Enrolment Status:</span></th>
 
                        <td>&nbsp; 
                            <select id="CLASS_LIST_PanelList_SUBJECT_ENROL_STATUS" style="WIDTH: 313px"  runat="server"></select>
 </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>&nbsp;Semester:</th>
 
                        <td>&nbsp; 
                            <select id="CLASS_LIST_PanelList_SEMESTER"  runat="server"></select>
 &nbsp;&nbsp;&nbsp; </td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="2" align="right"><a id="CLASS_LIST_PanelClearParameters" href="" runat="server"  >Clear</a>&nbsp;&nbsp;&nbsp;&nbsp; 
                            <input id='CLASS_LIST_PanelButton_DoSearch' type="submit" class="Button" value="Show My Students" OnServerClick='CLASS_LIST_Panel_Search' runat="server"/></td>
                    </tr>
                </table>
                <em>(only your subjects are shown - Use 'Teacher Allocations' to view other Subjects)</em></td>
        </tr>
    </table>


&nbsp;&nbsp;&nbsp;
  </span>
  
<p></p>
<p><a id="LinkExportToExcel" href="" title="Export list to Excel" class="Button" style="BORDER-LEFT-WIDTH: 2px; BORDER-RIGHT-WIDTH: 2px; BORDER-BOTTOM-WIDTH: 2px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; BORDER-TOP-WIDTH: 2px" runat="server"  >Export to Excel</a>&nbsp;&nbsp; 
<a id="Link_ShowBulkComment" href="" title="show Class Comment entry form" class="Button" style="BORDER-LEFT-WIDTH: 2px; BORDER-RIGHT-WIDTH: 2px; BORDER-BOTTOM-WIDTH: 2px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; BORDER-TOP-WIDTH: 2px" runat="server"  >Add Class Comment</a></p>
<p>

  <span id="STUDENT_COMMENTHolder" runat="server">
    


    &nbsp; 
    <table cellspacing="0" cellpadding="0" width="70%" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Add Comment to ALL Students on this Class List</th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="STUDENT_COMMENTError" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="2"><asp:Label ID="STUDENT_COMMENTErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Controls">
                        <th>COMMENT 
                        <div id="maxchar_comment">
                            255 characters allowed 
                        </div>
                        </th>
 
                        <td>
<asp:TextBox id="STUDENT_COMMENTCOMMENT" onkeyup="limitMaxLength(this,255,'maxchar_comment');" rows="3" Columns="60" TextMode="MultiLine"	runat="server"/>
</td>
                    </tr>
 
                    <tr class="Controls">
                        <th>Contact Type</th>
 
                        <td>
                            <asp:RadioButtonList id="STUDENT_COMMENTlbSpecialCommentType1"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="2" align="right">&nbsp; 
                            <input id='STUDENT_COMMENTButton_Insert' type="submit" class="Button" value="Add Class Comment" OnServerClick='STUDENT_COMMENT_Insert' runat="server"/>
                            <input id='STUDENT_COMMENTButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_COMMENT_Cancel' runat="server"/></td>
                    </tr>
                </table>
                
  <input id="STUDENT_COMMENThidden_SUBJECT_ID" type="hidden"  runat="server"/>
  
  <input id="STUDENT_COMMENThidden_ENROLSTATUS" type="hidden"  runat="server"/>
  
  <input id="STUDENT_COMMENTHidden_SEMESTER" type="hidden"  runat="server"/>
  </td>
        </tr>
    </table>



  </span>
  </p>

<asp:repeater id="Students_GridRepeater" OnItemCommand="Students_GridItemCommand" OnItemDataBound="Students_GridItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" align="center" border="0">
    <tr>
        <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                    <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                    <th>Class List </th>
 
                    <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
                <tr class="Row">
                    <td colspan="16">Total Student Count:&nbsp;<asp:Literal id="Students_GridSTUDENT_ClassList_TotalRecords" runat="server"/></td>
                </tr>
 
                <tr class="Caption">
                    <th>&nbsp;#</th>
 
                    <th>
                    <CC:Sorter id="Sorter_STUDENT_IDSorter" field="Sorter_STUDENT_ID" OwnerState="<%# Students_GridData.SortField.ToString()%>" OwnerDir="<%# Students_GridData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STUDENT_IDSort" runat="server">STUDENT ID</asp:LinkButton> 
                    <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                    <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem>&nbsp;</CC:Sorter></th>
 
                    <th>&nbsp;Actions</th>
 
                    <th>Standard Learning Program</th>
 
                    <th>
                    <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# Students_GridData.SortField.ToString()%>" OwnerDir="<%# Students_GridData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">SURNAME</asp:LinkButton> 
                    <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                    <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem>&nbsp;</CC:Sorter></th>
 
                    <th>
                    <CC:Sorter id="Sorter_FIRST_NAMESorter" field="Sorter_FIRST_NAME" OwnerState="<%# Students_GridData.SortField.ToString()%>" OwnerDir="<%# Students_GridData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_FIRST_NAMESort" runat="server">FIRST NAME</asp:LinkButton> 
                    <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                    <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem>&nbsp;</CC:Sorter></th>
 
                    <th>
                    <CC:Sorter id="Sorter_SCHOOL_NAMESorter" field="Sorter_SCHOOL_NAME" OwnerState="<%# Students_GridData.SortField.ToString()%>" OwnerDir="<%# Students_GridData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SCHOOL_NAMESort" runat="server">SCHOOL NAME</asp:LinkButton> 
                    <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                    <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem>&nbsp;</CC:Sorter></th>
 
                    <th>
                    <CC:Sorter id="Sorter_ATTENDING_SCHOOL_IDSorter" field="Sorter_ATTENDING_SCHOOL_ID" OwnerState="<%# Students_GridData.SortField.ToString()%>" OwnerDir="<%# Students_GridData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ATTENDING_SCHOOL_IDSort" runat="server">ATTENDING SCHOOL ID</asp:LinkButton> 
                    <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                    <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem>&nbsp;</CC:Sorter></th>
 
                    <th>
                    <CC:Sorter id="Sorter_STAFF_IDSorter" field="Sorter_STAFF_ID" OwnerState="<%# Students_GridData.SortField.ToString()%>" OwnerDir="<%# Students_GridData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STAFF_IDSort" runat="server">STAFF ID</asp:LinkButton> 
                    <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                    <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem>&nbsp;</CC:Sorter></th>
 
                    <th>
                    <CC:Sorter id="Sorter_CLASS_CODESorter" field="Sorter_CLASS_CODE" OwnerState="<%# Students_GridData.SortField.ToString()%>" OwnerDir="<%# Students_GridData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_CLASS_CODESort" runat="server">CLASS CODE</asp:LinkButton> 
                    <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                    <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
                    <th>
                    <CC:Sorter id="Sorter_SUBJECT_ABBREVSorter" field="Sorter_SUBJECT_ABBREV" OwnerState="<%# Students_GridData.SortField.ToString()%>" OwnerDir="<%# Students_GridData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBJECT_ABBREVSort" runat="server">SUBJECT ABBREV</asp:LinkButton> 
                    <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                    <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem>&nbsp;</CC:Sorter></th>
 
                    <th>
                    <CC:Sorter id="Sorter_SUBJECT_IDSorter" field="Sorter_SUBJECT_ID" OwnerState="<%# Students_GridData.SortField.ToString()%>" OwnerDir="<%# Students_GridData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBJECT_IDSort" runat="server">SUBJECT ID</asp:LinkButton> 
                    <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                    <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem>&nbsp;</CC:Sorter></th>
 
                    <th>
                    <CC:Sorter id="Sorter_SUBJ_ENROL_STATUSSorter" field="Sorter_SUBJ_ENROL_STATUS" OwnerState="<%# Students_GridData.SortField.ToString()%>" OwnerDir="<%# Students_GridData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBJ_ENROL_STATUSSort" runat="server">SUBJ ENROL STATUS</asp:LinkButton> 
                    <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                    <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem>&nbsp;</CC:Sorter></th>
 
                    <th>
                    <CC:Sorter id="Sorter_SEMESTERSorter" field="Sorter_SEMESTER" OwnerState="<%# Students_GridData.SortField.ToString()%>" OwnerDir="<%# Students_GridData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SEMESTERSort" runat="server">SEMESTER</asp:LinkButton> 
                    <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                    <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem>&nbsp;</CC:Sorter></th>
 
                    <th colspan="2">
                    <CC:Sorter id="Sorter_ENROLMENT_DATESorter" field="Sorter_ENROLMENT_DATE" OwnerState="<%# Students_GridData.SortField.ToString()%>" OwnerDir="<%# Students_GridData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ENROLMENT_DATESort" runat="server">ENROLMENT DATE</asp:LinkButton> 
                    <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                    <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter>&nbsp;</th>
                </tr>
 
                
  </HeaderTemplate>
  <ItemTemplate>
                <tr class="Row">
                    <td style="TEXT-ALIGN: right"><asp:Literal id="Students_GridlblCnt" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).lblCnt.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                    <td style="TEXT-ALIGN: right"><a id="Students_GridSTUDENT_ID" href="" runat="server"  ><%#(CType(Container.DataItem,Students_GridItem)).STUDENT_ID.GetFormattedValue()%></a>&nbsp; <asp:Literal id="Students_Gridlabel_ALERTS" runat="server"/></td> 
                    <td>&nbsp;<a id="Students_GridLink1" href="" runat="server"  >Comments</a> 
                        <asp:HyperLink id="Students_GridClippyLink1"  Visible="False"  ToolTip="copy this student" style="BORDER-TOP: 0px; BORDER-RIGHT: 0px; BORDER-BOTTOM: 0px; BORDER-LEFT: 0px" ImageUrl='images/page_white_excel.png' runat="server"/>&nbsp;
  <input id="Students_GridHidden_clipboardtext"  value='<%# (CType(Container.DataItem,Students_GridItem)).Hidden_clipboardtext.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td> 
                    <td>&nbsp;&nbsp;<asp:Literal id="Students_GridStandardLearningProgram" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).StandardLearningProgram.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
                    <td><asp:Literal id="Students_GridSURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;&nbsp;</td> 
                    <td><asp:Literal id="Students_GridFIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                    <td><asp:Literal id="Students_GridSCHOOL_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).SCHOOL_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                    <td><asp:Literal id="Students_GridATTENDING_SCHOOL_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).ATTENDING_SCHOOL_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                    <td><asp:Literal id="Students_GridSTAFF_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).STAFF_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                    <td><asp:Literal id="Students_GridCLASS_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).CLASS_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
                    <td><asp:Literal id="Students_GridSUBJECT_ABBREV" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).SUBJECT_ABBREV.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                    <td style="TEXT-ALIGN: right"><asp:Literal id="Students_GridSUBJECT_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).SUBJECT_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                    <td><asp:Literal id="Students_GridSUBJ_ENROL_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).SUBJ_ENROL_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                    <td><asp:Literal id="Students_GridSEMESTER" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).SEMESTER.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                    <td colspan="2"><asp:Literal id="Students_GridENROLMENT_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Students_GridItem)).ENROLMENT_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
                </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
                
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
                <tr class="NoRecords">
                    <td colspan="16">No Students found for this Teacher and Subject.</td>
                </tr>
                
  </asp:PlaceHolder>

                <tr class="Footer">
                    <td colspan="16">
                        
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# Students_GridData.PagesCount%>" PageSize="<%# Students_GridData.RecordsPerPage%>" PageNumber="<%# Students_GridData.PageNumber%>" runat="server">
                        Per page: 
                        <CC:PageSizer AutoPostBack="true" runat="server" />
 
                        <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server">First</asp:LinkButton> </CC:NavigatorItem>
                        <CC:NavigatorItem type="FirstOff" runat="server">First </CC:NavigatorItem>
                        <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server">Prev</asp:LinkButton> </CC:NavigatorItem>
                        <CC:NavigatorItem type="PrevOff" runat="server">Prev </CC:NavigatorItem>&nbsp; 
                        
<CC:Pager id="NavigatorPager" Style="Centered" PagerSize="10" runat="server">
                        <PageOnTemplate>&nbsp;<asp:LinkButton runat="server"><%# (CType(Container,PagerItem)).PageNumber.ToString() %></asp:LinkButton>&nbsp;</PageOnTemplate>
                        <PageOffTemplate><%# (CType(Container,PagerItem)).PageNumber.ToString() %></PageOffTemplate></CC:Pager>&nbsp;of &nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
                        <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server">Next</asp:LinkButton> </CC:NavigatorItem>
                        <CC:NavigatorItem type="NextOff" runat="server">Next </CC:NavigatorItem>
                        <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server">Last</asp:LinkButton> </CC:NavigatorItem>
                        <CC:NavigatorItem type="LastOff" runat="server">Last </CC:NavigatorItem>&nbsp;</CC:Navigator>
&nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
</table>
&nbsp;
  </FooterTemplate>
</asp:repeater>
&nbsp;&nbsp;
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
<link rel="stylesheet" type="text/css" href="js/css/ui-lightness/jquery-ui-1.8.8.custom.css">
<script src="js/jquery_min.js" type="text/javascript" charset="utf-8"></script>
<script src="js/jquery-ui-1.8.8.custom.min.js" type="text/javascript" charset="utf-8"></script>
<script type="text/javascript">
function animateClick() {
        $('<div class="overlay"></div>')
                        .appendTo('span#STUDENT_COMMENTHolder')
                        .fadeIn(1500)
                        .delay(1000)
                        .fadeOut(500);
        return true;
};

$('a#Link_ShowBulkComment').click(function() {
        $('span#STUDENT_COMMENTHolder').slideToggle('slow');
                $('textarea#STUDENT_COMMENTCOMMENT').focus();
});

// check if any errors and show, otherwise hide
if ( ($('span#STUDENT_COMMENTErrorLabel').text().length) != 0) {
        $('span#STUDENT_COMMENTHolder').toggle(true);
} else {
        $('span#STUDENT_COMMENTHolder').toggle(false);
}

</script>
<style type="text/css">
<!--
.overlay {
        background: black no-repeat 50% 50%;
                background-image: url(images/ajax_loader_bigwhite.gif);
        display: none;
        height: 100%;
        left: 0;
        opacity: .9;
        position: absolute;
        top: 0;
        width: 100%;
    }
-->
</style>

</form>
</body>
</html>

<!--End ASPX page-->

