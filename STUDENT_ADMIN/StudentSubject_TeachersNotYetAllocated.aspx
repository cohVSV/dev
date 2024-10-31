<!--ASPX page @1-747F4A06-->
    <%@ Page language="vb" CodeFile="StudentSubject_TeachersNotYetAllocated.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.StudentSubject_TeachersNotYetAllocated.StudentSubject_TeachersNotYetAllocatedPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.StudentSubject_TeachersNotYetAllocated" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 4.1.00.032"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Subject Teacher Allocations</title>


<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_ForceRun_Button_Update_OnClick @166-1BAF1854
function page_ForceRun_Button_Update_OnClick()
{
    var result;
//End page_ForceRun_Button_Update_OnClick

//Custom Code @168-2A29BDB7
        result = confirm("Are you sure that you wish to run the process to auto-allocate teachers to students in subjects?");
//End Custom Code

//Close page_ForceRun_Button_Update_OnClick @166-BC33A33A
    return result;
}
//End Close page_ForceRun_Button_Update_OnClick

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//Set Focus @67-25F0BFE1
    if (theForm.view_Class_ListSearchs_SURNAME) theForm.view_Class_ListSearchs_SURNAME.focus();
//End Set Focus

//Custom Code @133-2A29BDB7
    // -------------------------
    //ERA: force hide of modal
    //ShowModal1_hide();
    // ERA: set up the 'current' links to open the Modal popup to show the current enrolments
    //$$('.show_enrolments').each(function (el) {
    //            return $(el).observe('click', function() {
    //                                                            ShowModal1_show();
    //                                                            return false;
    //                                                    });
    //    });
    result = true;
    // -------------------------
//End Custom Code

//Close page_OnLoad @1-BC33A33A
    return result;
}
//End Close page_OnLoad

//page_view_Class_List_Cancel_OnClick @138-8C9DC0EF
function page_view_Class_List_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_view_Class_List_Cancel_OnClick

//bind_events @1-36DEB597
function bind_events() {
    addEventHandler("ForceRunButton_Update","click",page_ForceRun_Button_Update_OnClick);
    addEventHandler("view_Class_ListCancel","click",page_view_Class_List_Cancel_OnClick);
    page_OnLoad();
    forms_onload();
}
//End bind_events


//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

window.onload = bind_events;

//End CCS script
</script>
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p>
<table style="WIDTH: 95%" cellspacing="0" cellpadding="0" border="0">
    <tr>
        <td valign="top">
            
  <span id="view_Class_ListSearchHolder" runat="server">
    
            

                <table cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td valign="top">
                            <table class="Header" cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                                    <th>Search </th>
 
                                    <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                                </tr>
                            </table>
 
                            <table class="Record" cellspacing="0" cellpadding="0">
                                
  <asp:PlaceHolder id="view_Class_ListSearchError" visible="False" runat="server">
  
                                <tr class="Error">
                                    <td colspan="2"><asp:Label ID="view_Class_ListSearchErrorLabel" runat="server"/></td>
                                </tr>
                                
  </asp:PlaceHolder>
  
                                <tr class="Controls">
                                    <th>Search for</th>
 
                                    <td>
                                        <asp:RadioButtonList id="view_Class_ListSearchrbSearchType"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                                </tr>
 
                                <tr class="Controls">
                                    <th>Semester<br>
                                    <br>
                                    <em>Full year/B subjects are always included</em></th>
 
                                    <td>
                                        <asp:RadioButtonList id="view_Class_ListSearchs_SEMESTER"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                                </tr>
 
                                <tr class="Controls">
                                    <th>Subject</th>
 
                                    <td>
                                        <select id="view_Class_ListSearchddlSubject"  runat="server"></select>
 </td>
                                </tr>
 
                                <tr class="Controls">
                                    <th>Student first name, surname, or school name</th>
 
                                    <td><asp:TextBox id="view_Class_ListSearchs_SURNAME" maxlength="40" Columns="40"	runat="server"/></td>
                                </tr>
 
                                <tr class="Controls">
                                    <th>Student year level</th>
 
                                    <td>
                                        <select id="view_Class_ListSearchradioYearLevel"  runat="server"></select>
 </td>
                                </tr>
 
                                <tr class="Bottom">
                                    <td><a id="view_Class_ListSearchClearParameters" href="" runat="server"  >Clear</a></td> 
                                    <td align="right">
                                        <input id='view_Class_ListSearchButton_DoSearch' type="submit" class="Button" value="Search" OnServerClick='view_Class_ListSearch_Search' runat="server"/></td>
                                </tr>
                            </table>
                            <em>Shows Next Enrolment Year from 1 Dec; Excludes LP/DL Subjects;</em></td>
                    </tr>
                </table>
            

            &nbsp;&nbsp;
  </span>
  
            <p></p>
        </td> 
        <td valign="top"></td> 
        <td valign="top">
            
  <span id="ForceRunHolder" runat="server">
    
            

                <table class="MainTable" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td valign="top">
                            <table class="Header" cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
                                    <th>Force Allocation&nbsp;Run</th>
 
                                    <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
                                </tr>
                            </table>
 
                            <table class="Record" cellspacing="0" cellpadding="0">
                                
  <asp:PlaceHolder id="ForceRunError" visible="False" runat="server">
  
                                <tr id="ForceRunErrorBlock" class="Error">
                                    <td colspan="2"><asp:Label ID="ForceRunErrorLabel" runat="server"/></td>
                                </tr>
                                
  </asp:PlaceHolder>
  
                                <tr class="Controls">
                                    <th colspan="2"><u>If allocations 'stalled' try running and increase batch size</u></th>
                                </tr>
 
                                <tr class="Controls">
                                    <th>Batch Size</th>
 
                                    <td>
                                        <select id="ForceRunlistBatchSize"  runat="server"></select>
 students </td>
                                </tr>
 
                                <tr class="Controls">
                                    <th>VCE Only</th>
 
                                    <td><asp:CheckBox id="ForceRuncheckVCEOnly" runat="server"/>&nbsp;<em>(leave blank for all Years)</em></td>
                                </tr>
 
                                <tr class="Bottom">
                                    <td style="TEXT-ALIGN: right" colspan="2">
                                        <input id='ForceRunButton_Update' type="submit" class="Button" value="Run Batch" OnServerClick='ForceRun_Update' runat="server"/></td>
                                </tr>
                            </table>
                            <em>
                            <ul>
                                <li>may take 1-2 minutes to run 
                                <li>if no change, increase batch size and Run Batch 
                                <li>after 500 then must add Teachers or manually allocate </li>
                            </ul>
                            </em></td>
                    </tr>
                </table>
            

            
  </span>
  </td>
    </tr>
</table>
<p><br>
</p>

<asp:repeater id="view_Class_ListRepeater" OnItemCommand="view_Class_ListItemCommand" OnItemDataBound="view_Class_ListItemDataBound" runat="server">
  <HeaderTemplate>
  


    
	<script language="JavaScript" >
	var view_Class_ListElements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initview_Class_ListElements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
    <table cellspacing="0" cellpadding="0" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th><asp:Literal id="view_Class_ListlblStudentSubjectTeacherListHeading" runat="server"/></th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Grid" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="view_Class_ListError" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="10"><asp:Label ID="ErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Row">
                        <td colspan="10">Total Records:&nbsp;<asp:Literal id="view_Class_Listview_Class_List_TotalRecords" runat="server"/></td>
                    </tr>
 
                    <tr class="Caption">
                        <th>
                        <CC:Sorter id="Sorter_STUDENT_IDSorter" field="Sorter_STUDENT_ID" OwnerState="<%# view_Class_ListData.SortField.ToString()%>" OwnerDir="<%# view_Class_ListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_STUDENT_IDSort" runat="server">STUDENT ID</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                        <th>
                        <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# view_Class_ListData.SortField.ToString()%>" OwnerDir="<%# view_Class_ListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">STUDENT NAME</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                        <th>
                        <CC:Sorter id="SorterYEAR_LEVELSorter" field="SorterYEAR_LEVEL" OwnerState="<%# view_Class_ListData.SortField.ToString()%>" OwnerDir="<%# view_Class_ListData.SortDir%>" runat="server"><asp:LinkButton id="SorterYEAR_LEVELSort" runat="server">YEAR LEVEL</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
                        <th>
                        <CC:Sorter id="Sorter_SCHOOL_NAMESorter" field="Sorter_SCHOOL_NAME" OwnerState="<%# view_Class_ListData.SortField.ToString()%>" OwnerDir="<%# view_Class_ListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SCHOOL_NAMESort" runat="server">SCHOOL NAME</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                        <th>
                        <CC:Sorter id="Sorter_SEMESTERSorter" field="Sorter_SEMESTER" OwnerState="<%# view_Class_ListData.SortField.ToString()%>" OwnerDir="<%# view_Class_ListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SEMESTERSort" runat="server">SEMESTER</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                        <th>STAFF ID (Choose!)</th>
 
                        <th>&nbsp;</th>
 
                        <th>
                        <CC:Sorter id="Sorter_SUBJECT_TITLESorter" field="Sorter_SUBJECT_TITLE" OwnerState="<%# view_Class_ListData.SortField.ToString()%>" OwnerDir="<%# view_Class_ListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBJECT_TITLESort" runat="server">SUBJECT TITLE</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                        <th>
                        <CC:Sorter id="Sorter_SUBJ_ENROL_STATUSSorter" field="Sorter_SUBJ_ENROL_STATUS" OwnerState="<%# view_Class_ListData.SortField.ToString()%>" OwnerDir="<%# view_Class_ListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_SUBJ_ENROL_STATUSSort" runat="server">Enrol Status</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
                        <th>
                        <CC:Sorter id="Sorter_ENROLMENT_DATESorter" field="Sorter_ENROLMENT_DATE" OwnerState="<%# view_Class_ListData.SortField.ToString()%>" OwnerDir="<%# view_Class_ListData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_ENROLMENT_DATESort" runat="server">Last Altered Date</asp:LinkButton> 
                        <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
                        <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
                    </tr>
 
                    
  </HeaderTemplate>
  <ItemTemplate>
    
                    
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
                    <tr class="Error">
                        <td colspan="10"><asp:Label ID="ErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>

                    <tr class="Row">
                        <td><a id="view_Class_ListSTUDENT_ID" href="" runat="server"  ><%#(CType(Container.DataItem,view_Class_ListItem)).STUDENT_ID.GetFormattedValue()%></a>&nbsp;</td> 
                        <td><asp:Literal id="view_Class_ListFIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,view_Class_ListItem)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="view_Class_ListSURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,view_Class_ListItem)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
                        <td>
                            <div align="center">
                                <asp:Literal id="view_Class_ListYEAR_LEVEL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,view_Class_ListItem)).YEAR_LEVEL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp; 
                            </div>
                        </td> 
                        <td><asp:Literal id="view_Class_ListSCHOOL_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,view_Class_ListItem)).SCHOOL_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                        <td>
                            <div align="center">
                                <asp:Literal id="view_Class_ListSEMESTER" Text='<%# Server.HtmlEncode((CType(Container.DataItem,view_Class_ListItem)).SEMESTER.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/> 
                            </div>
                        </td> 
                        <td>
                            <select id="view_Class_ListSTAFF_ID"  runat="server"></select>
 
  <input id="view_Class_ListhidPreviousStaffID"  value='<%# (CType(Container.DataItem,view_Class_ListItem)).hidPreviousStaffID.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td> 
                        <td><a id="view_Class_Listlink_ShowCurrentEnrolment" href="" onmouseover="initialiseTeacherAllocationPopup(this);" onmouseout="cancelTeacherAllocationPopup();" class="show_enrolments" runat="server"  >current</a>&nbsp;<asp:Literal id="view_Class_ListlblWarnFull" runat="server"/></td> 
                        <td><a id="view_Class_ListSUBJECT_ABBREV" href="" runat="server"  ><%#(CType(Container.DataItem,view_Class_ListItem)).SUBJECT_ABBREV.GetFormattedValue()%></a>&nbsp;:&nbsp;<asp:Literal id="view_Class_ListSUBJECT_TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,view_Class_ListItem)).SUBJECT_TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                        <td>
                            <div align="center">
                                <asp:Literal id="view_Class_ListSUBJ_ENROL_STATUS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,view_Class_ListItem)).SUBJ_ENROL_STATUS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/> 
                            </div>
                        </td> 
                        <td><asp:Literal id="view_Class_ListENROLMENT_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,view_Class_ListItem)).ENROLMENT_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
                    </tr>
 
  </ItemTemplate>

  <FooterTemplate>
	
                    
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
                    <tr class="NoRecords">
                        <td colspan="10"><font color="#800000">No students found! Check search settings then click [Search].</font></td>
                    </tr>
                    
  </asp:PlaceHolder>

                    <tr class="Footer">
                        <td style="TEXT-ALIGN: right" colspan="10">
                            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# view_Class_ListData.PagesCount%>" PageSize="<%# view_Class_ListData.RecordsPerPage%>" PageNumber="<%# view_Class_ListData.PageNumber%>" runat="server"><span class="Navigator">
                            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img src="Styles/Blueprint/Images/First.gif"></asp:LinkButton> </CC:NavigatorItem>
                            <CC:NavigatorItem type="FirstOff" runat="server"><img src="Styles/Blueprint/Images/FirstOff.gif"></CC:NavigatorItem>
                            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img src="Styles/Blueprint/Images/Prev.gif"></asp:LinkButton> </CC:NavigatorItem>
                            <CC:NavigatorItem type="PrevOff" runat="server"><img src="Styles/Blueprint/Images/PrevOff.gif"></CC:NavigatorItem>&nbsp; 
                            
<CC:Pager id="NavigatorPager" Style="Moving" PagerSize="4" runat="server">
                            <PageOnTemplate><asp:LinkButton runat="server"><%# (CType(Container,PagerItem)).PageNumber.ToString() %></asp:LinkButton>&nbsp;</PageOnTemplate>
                            <PageOffTemplate><%# (CType(Container,PagerItem)).PageNumber.ToString() %>&nbsp;</PageOffTemplate></CC:Pager>of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
                            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img src="Styles/Blueprint/Images/Next.gif"></asp:LinkButton> </CC:NavigatorItem>
                            <CC:NavigatorItem type="NextOff" runat="server"><img src="Styles/Blueprint/Images/NextOff.gif"></CC:NavigatorItem>
                            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img src="Styles/Blueprint/Images/Last.gif"></asp:LinkButton> </CC:NavigatorItem>
                            <CC:NavigatorItem type="LastOff" runat="server"><img src="Styles/Blueprint/Images/LastOff.gif"></CC:NavigatorItem></span></CC:Navigator>

                            <asp:Button id="view_Class_ListButton_Submit" CssClass="Button" Text="Submit" CommandName="Submit" runat="server"/>&nbsp; 
                            <asp:Button id="view_Class_ListCancel" CssClass="Button" Text="Cancel" runat="server"/></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <iframe id="teacherSubjectAllocationsPopup" onload="refreshTeacherAllocationPopupPosition(this);" style="WIDTH: 680px; POSITION: fixed; DISPLAY: none; box-shadow: 0px 0px 5px 7px rgb(124, 124, 124)"></iframe>



  </FooterTemplate>
</asp:repeater>

<p></p>
<script type="text/javascript">

      var popupTask = null;
      var hoverElementPosition = { left: 0, top: 0 };


      function initialiseTeacherAllocationPopup(hoverElement)
      {
         popupTask = setTimeout(showTeacherAllocationPopup, 300, hoverElement);
      }


      function showTeacherAllocationPopup(hoverElement)
      {
         var hoverElementViewportOffset = hoverElement.getBoundingClientRect();
         hoverElementPosition = { left: hoverElementViewportOffset.left, top: hoverElementViewportOffset.top };

         var popupElement = document.getElementById("teacherSubjectAllocationsPopup");
         if (popupElement.src === hoverElement.href)
         {
            // The popup content hasn't changed, we just need to reposition and reopen it.
            refreshTeacherAllocationPopupPosition(popupElement);
         }
         else
         {
            // Update the popup content, and allow the iframe's load event to update the size and positioning.
            popupElement.src = hoverElement.href;
         }

         popupElement.style.display = "block";
      }


      function cancelTeacherAllocationPopup()
      {
         if (popupTask !== null)
            clearTimeout(popupTask);

         var popupElement = document.getElementById("teacherSubjectAllocationsPopup");
         popupElement.style.display = "none";
      }


      function refreshTeacherAllocationPopupPosition(popupElement)
      {
         // The iframe height needs to be cleared otherwise it will only continue to grow.
         popupElement.style.height = "0px";
         var popupContentHeight = (popupElement.contentWindow.document.body.scrollHeight) || 400;
         popupElement.style.height = popupContentHeight + "px";

         var popupTargetOffsetLeft = 150;
         var popupTargetOffsetTop = -200;
         var minBottomMargin = 50;

         popupElement.style.left = hoverElementPosition.left + popupTargetOffsetLeft;

         var viewportHeight = window.innerHeight;
         if ((hoverElementPosition.top + popupTargetOffsetTop) <= (viewportHeight - popupContentHeight - minBottomMargin))
            popupElement.style.top = (hoverElementPosition.top + popupTargetOffsetTop);
         else
            popupElement.style.top = (viewportHeight - popupContentHeight - minBottomMargin);
      }
</script>

</form>
</body>
</html>

<!--End ASPX page-->

