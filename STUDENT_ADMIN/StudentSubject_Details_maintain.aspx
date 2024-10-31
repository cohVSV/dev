<!--ASPX page @1-F3BE4A57-->
    <%@ Page language="vb" CodeFile="StudentSubject_Details_maintain.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.StudentSubject_Details_maintain.StudentSubject_Details_maintainPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.StudentSubject_Details_maintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Subject Details maintain</title>


<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_viewStudentSummary_Subjec_Button_Update_OnClick @5-D2C6C036
function page_viewStudentSummary_Subjec_Button_Update_OnClick()
{
    var result;
//End page_viewStudentSummary_Subjec_Button_Update_OnClick

//Confirmation Message @97-D47BE4F7
    return confirm('Are you sure you want to update the Subject Details?');
//End Confirmation Message

//Close page_viewStudentSummary_Subjec_Button_Update_OnClick @5-BC33A33A
    return result;
}
//End Close page_viewStudentSummary_Subjec_Button_Update_OnClick

//page_viewStudentSummary_Subjec_Button_Extend_OnClick @301-13FF8DAD
function page_viewStudentSummary_Subjec_Button_Extend_OnClick()
{
    var result;
//End page_viewStudentSummary_Subjec_Button_Extend_OnClick

//Confirmation Message @302-083FF648
    return confirm('Extend Subject into Semester 2?\n(can be manually changed back)');
//End Confirmation Message

//Close page_viewStudentSummary_Subjec_Button_Extend_OnClick @301-BC33A33A
    return result;
}
//End Close page_viewStudentSummary_Subjec_Button_Extend_OnClick

//page_viewStudentSummary_Subjec_Button_Cancel_OnClick @6-14B4033F
function page_viewStudentSummary_Subjec_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_viewStudentSummary_Subjec_Button_Cancel_OnClick

//page_STUDENT_SUBJECT_Button_Cancel_OnClick @130-E2583AC8
function page_STUDENT_SUBJECT_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_SUBJECT_Button_Cancel_OnClick

//bind_events @1-5CCEB78F
function bind_events() {
    addEventHandler("viewStudentSummary_SubjecButton_Extend","click",page_viewStudentSummary_Subjec_Button_Extend_OnClick);
    addEventHandler("viewStudentSummary_SubjecButton_Update","click",page_viewStudentSummary_Subjec_Button_Update_OnClick);
    addEventHandler("viewStudentSummary_SubjecButton_Cancel","click",page_viewStudentSummary_Subjec_Button_Cancel_OnClick);
    addEventHandler("STUDENT_SUBJECTButton_Cancel","click",page_STUDENT_SUBJECT_Button_Cancel_OnClick);
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

window.onload = bind_events; 

//End CCS script
</script>
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p align="center"><a id="linkSubjectList" href="" class="Button" runat="server"  >Back to Subject List</a></p>
<p><br>

  <span id="viewStudentSummary_SubjecHolder" runat="server">
    


    <div align="center">
        <table cellspacing="0" cellpadding="0" width="70%" align="center" border="0">
            <tr>
                <td valign="top">
                    <table class="Header" cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                            <th>Edit Subject Details </th>
 
                            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                        </tr>
                    </table>
 
                    <table class="Record" cellspacing="0" cellpadding="0">
                        
  <asp:PlaceHolder id="viewStudentSummary_SubjecError" visible="False" runat="server">
  
                        <tr class="Error">
                            <td colspan="4"><asp:Label ID="viewStudentSummary_SubjecErrorLabel" runat="server"/></td>
                        </tr>
                        
  </asp:PlaceHolder>
  
                        <tr class="Controls">
                            <th>STUDENT ID</th>
 
                            <td><asp:Literal id="viewStudentSummary_Subjecstudent_id" runat="server"/>&nbsp;</td> 
                            <td>&nbsp;ENROLMENT YEAR</td> 
                            <td><asp:Literal id="viewStudentSummary_Subjecenrolment_year" runat="server"/>&nbsp;</td>
                        </tr>
 
                        <tr class="Controls">
                            <th>SUBJECT ID</th>
 
                            <td><asp:Literal id="viewStudentSummary_SubjecSUBJECT_ID" runat="server"/>&nbsp;</td> 
                            <td>&nbsp;SUBJECT TITLE</td> 
                            <td><asp:Literal id="viewStudentSummary_SubjecSUBJECT_TITLE" runat="server"/>&nbsp;</td>
                        </tr>
 
                        <tr class="Controls">
                            <th>SEMESTER</th>
 
                            <td>
                                <select id="viewStudentSummary_SubjecSEMESTER"  runat="server"></select>
 </td> 
                            <td>&nbsp;COURSE DISTRIBUTION</td> 
                            <td><asp:Literal id="viewStudentSummary_SubjecCOURSE_DISTRIBUTION" runat="server"/> &nbsp;</td>
                        </tr>
 
                        <tr class="Controls">
                            <th>&nbsp;</th>
 
                            <td>&nbsp;</td> 
                            <td>&nbsp;</td> 
                            <td>&nbsp;</td>
                        </tr>
 
                        <tr class="Controls">
                            <th>ENROLMENT STATUS</th>
 
                            <td>
                                <select id="viewStudentSummary_SubjecSUBJ_ENROL_STATUS"  runat="server"></select>
 </td> 
                            <td>&nbsp;ENROLMENT DATE</td> 
                            <td><asp:TextBox id="viewStudentSummary_Subjecenrolment_date" onfocus="this.select();" maxlength="10" Columns="10"	runat="server"/>&nbsp;<em>eg:31/05/08</em></td>
                        </tr>
 
                        <tr class="Controls">
                            <th>EXTENDING IN SUBJECT</th>
 
                            <td>
                                <asp:RadioButtonList id="viewStudentSummary_SubjecEXTENSION_OF_VCE_UNIT"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
                            <td>&nbsp;END DATE</td> 
                            <td><asp:TextBox id="viewStudentSummary_Subjecwithdrawal_date" onfocus="this.select();" maxlength="10" Columns="10"	runat="server"/>&nbsp;<em>eg:31/05/08</em></td>
                        </tr>
 
                        <tr class="Controls">
                            <th>WITHDRAWAL REASON</th>
 
                            <td colspan="2">
                                <select id="viewStudentSummary_SubjecWITHDRAWAL_REASON_ID"  runat="server"></select>
 &nbsp;</td> 
                            <td class="Error"><asp:Literal id="viewStudentSummary_SubjeclabelErrorStaffID" runat="server"/>&nbsp;</td>
                        </tr>
 
                        <tr class="Controls">
                            <th>No of ASSIGNMENT&nbsp;SUBMISSIONS</th>
 
                            <td><asp:Literal id="viewStudentSummary_SubjecNUM_ASSMT_SUBMISSIONS" runat="server"/>&nbsp;</td> 
                            <td>&nbsp;TEACHER</td> 
                            <td>
                                <select id="viewStudentSummary_SubjecSTAFF_ID"  runat="server"></select>
 &nbsp;&nbsp;<asp:Literal id="viewStudentSummary_SubjeclblSTAFF_ID" runat="server"/></td>
                        </tr>
 
                        <tr class="Controls">
                            <th>INTERIM PROGRESS CODE&nbsp;<img onclick="javascript:alert('Interim Result Changes Nov 2010, per VCE Reporting Team');return false;" id="interim_result_icon" title="Interim Result Changes Nov 2010, per VCE Reporting Team" border="0" name="Interim_ResultIcon" alt="Interim Result Changes" src="images/icon_info.gif"></th>
 
                            <td>
                                <select id="viewStudentSummary_SubjecINTERIM_PROGRESS_CODE"  runat="server"></select>
 </td> 
                            <td>&nbsp;FINAL PROGRESS CODE</td> 
                            <td>
                                <select id="viewStudentSummary_SubjecFINAL_PROGRESS_CODE"  runat="server"></select>
 &nbsp;</td>
                        </tr>
 
                        <tr class="Controls">
                            <th>&nbsp;</th>
 
                            <td>&nbsp;</td> 
                            <td>&nbsp;</td> 
                            <td>&nbsp;</td>
                        </tr>
 
                        <tr class="Controls">
                            <th>VBOS REGISTERED</th>
 
                            <td>
                                <asp:RadioButtonList id="viewStudentSummary_SubjecVBOS_REGISTERED"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
                            <td>NON SUBMITTING?&nbsp;<img onclick="javascript:alert('Non-Submitting Flag (replaces NSUBMIT Teacher) March 2015');return false;" id="nsubmit_icon" title="Non-Submitting Flag (replaces NSUBMIT Teacher) March 2015" border="0" name="nsubmit_icon" alt="Non-Submitting Flag" src="images/icon_info.gif"></td> 
                            <td>
                                <asp:RadioButtonList id="viewStudentSummary_SubjecNON_SUBMITTING_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                        </tr>
 
                        <tr class="Controls">
                            <th>APPEARS ON VASS</th>
 
                            <td>
                                <asp:RadioButtonList id="viewStudentSummary_SubjecAPPEARS_ON_VASS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
                            <td>&nbsp;</td> 
                            <td>&nbsp;&nbsp;&nbsp;</td>
                        </tr>
 
                        <tr class="Controls">
                            <th>&nbsp;</th>
 
                            <td>&nbsp;</td> 
                            <td>&nbsp;</td> 
                            <td>&nbsp;</td>
                        </tr>
 
                        <tr class="Controls">
                            <th>LAST ALTERED BY / DATE</th>
 
                            <td><asp:Literal id="viewStudentSummary_SubjecLAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="viewStudentSummary_SubjecLAST_ALTERED_DATE" runat="server"/></td> 
                            <td>&nbsp;</td> 
                            <td>&nbsp;</td>
                        </tr>
 
                        <tr class="Bottom">
                            <td colspan="4" align="right">
                                <input id='viewStudentSummary_SubjecButton_Extend' type="submit" class="Button" style="BACKGROUND-COLOR: orange" value="Extend Subject" OnServerClick='viewStudentSummary_Subjec_Insert' runat="server"/>&nbsp;&nbsp;&nbsp;&nbsp; 
                                <input id='viewStudentSummary_SubjecButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='viewStudentSummary_Subjec_Cancel' runat="server"/>
                                <input id='viewStudentSummary_SubjecButton_Update' type="submit" class="Button" value="Update Subject" OnServerClick='viewStudentSummary_Subjec_Update' runat="server"/></td>
                        </tr>
                    </table>
                    
  <input id="viewStudentSummary_Subjechidden_STUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="viewStudentSummary_Subjechidden_ENROLMENT_YEAR" type="hidden"  runat="server"/>
  
  <input id="viewStudentSummary_Subjechidden_SUBJECT_ID" type="hidden"  runat="server"/>
  
  <input id="viewStudentSummary_Subjechidden_LAST_ALTERED_DATE" type="hidden"  runat="server"/>
  
  <input id="viewStudentSummary_Subjechidden_LAST_ALTERED_BY" type="hidden"  runat="server"/>
  </td>
            </tr>
        </table>
        <asp:Literal id="viewStudentSummary_SubjeclblDebug2" runat="server"/> 
    </div>



  </span>
  
<p align="center">&nbsp; 

  <span id="STUDENT_SUBJECTHolder" runat="server">
    


    <table cellspacing="0" cellpadding="0" width="70%" align="center" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Edit Individual Learning Plan</th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="STUDENT_SUBJECTError" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="4"><asp:Label ID="STUDENT_SUBJECTErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Controls">
                        <th colspan="4"><em>Note: This should only be altered by Co-ordinators&nbsp;after consultation with Subject Teacher(s). In most cases a 'MODIFIED_SUBJECT'&nbsp; comment is appropriate</em>&nbsp;.&nbsp;&nbsp;</th>
                    </tr>
 
                    <tr class="Controls">
                        <th>Individual Education Plan&nbsp;<img onclick="javascript:alert('Individual Education Plan, Apr 2021');return false;" id="customlearningprogram_result_icon" title="Individual Education Plan, Apr 2021" border="0" name="CustomLearningProgram_ResultIcon" alt="Individual Education Plan" src="images/icon_info.gif"></th>
 
                        <td>&nbsp; 
                            <asp:RadioButtonList id="STUDENT_SUBJECTMODULE_CUSTOMPROGRAM"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
                        <td>Next Module&nbsp;<img onclick="javascript:alert('Individual Education Plan - Next modules, Apr 2021');return false;" id="customlearningprogram_result_icon" title="Individual Education Plan - next modules, Apr 2021" border="0" name="CustomLearningProgram_modules_ResultIcon" alt="Individual Education Plan - Next Modules" src="images/icon_info.gif"></td> 
                        <td>
                            <select id="STUDENT_SUBJECTMODULE_NEXTMODULE"  runat="server"></select>
 </td>
                    </tr>
 
                    <tr class="Controls">
                        <th>MODULE LAST ALTERED BY / DATE</th>
 
                        <td>&nbsp;<asp:Literal id="STUDENT_SUBJECTMODULE_LAST_ALTERED_BY1" runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_SUBJECTMODULE_LAST_ALTERED_DATE1" runat="server"/></td> 
                        <td>&nbsp;</td> 
                        <td>&nbsp;</td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="4" align="right">
                            <input id='STUDENT_SUBJECTButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_SUBJECT_Cancel' runat="server"/>
                            <input id='STUDENT_SUBJECTButton_Update' type="submit" class="Button" value="Update Module only" OnServerClick='STUDENT_SUBJECT_Update' runat="server"/>
  <input id="STUDENT_SUBJECTENROLMENT_YEAR" type="hidden"  runat="server"/>
  
  <input id="STUDENT_SUBJECTSUBJECT_ID" type="hidden"  runat="server"/>
  
  <input id="STUDENT_SUBJECTSEMESTER" type="hidden"  runat="server"/>
  
  <input id="STUDENT_SUBJECTMODULE_LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="STUDENT_SUBJECTMODULE_LAST_ALTERED_DATE" type="hidden"  runat="server"/>
  </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>



  </span>
  <br>
</p>
<p align="center"><asp:Literal id="lblSelections" runat="server"/></p>

<asp:repeater id="BOOK_DESPATCHRepeater" OnItemCommand="BOOK_DESPATCHItemCommand" OnItemDataBound="BOOK_DESPATCHItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" width="70%" align="center" border="0">
    <tr>
        <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                    <td class="HeaderLeft">
                        <p align="center"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></p>
                    </td> 
                    <th>Runs Taken</th>
 
                    <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
                <tr class="Caption">
                    <th>
                    <p align="center">BOOK NO (Module)</p>
                    </th>
 
                    <div align="center">
                    </div>
 
                    <th>DESPATCH STATUS</th>
 
                    <div>
                    </div>
 
                    <th>
                    <p align="center">DESPATCH DATE</p>
                    </th>
                </tr>
 
                
  </HeaderTemplate>
  <ItemTemplate>
                <tr  <CC:AttributeBinder runat="server" Name="rowStyle" ContainerId="BOOK_DESPATCHRepeater"/>>
                    <td style="TEXT-ALIGN: right">
                        <p align="center"><asp:Literal id="BOOK_DESPATCHBOOK_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,BOOK_DESPATCHItem)).BOOK_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;&nbsp;<asp:Literal id="BOOK_DESPATCHlblModule" Text='<%# Server.HtmlEncode((CType(Container.DataItem,BOOK_DESPATCHItem)).lblModule.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></p>
                    </td> 
                    <td>
                        <p align="center">
                        <asp:RadioButtonList id="BOOK_DESPATCHDESPATCH_STATUS"  onclick="javascript:getStatus_SetDate(this.id);" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</p>
                    </td> 
                    <td>
                        <p align="center"><asp:TextBox id="BOOK_DESPATCHDESPATCH_DATE" Text='<%# (CType(Container.DataItem,BOOK_DESPATCHItem)).DESPATCH_DATE.GetFormattedValue() %>' onfocus="this.select();" maxlength="100" Columns="8"	runat="server"/>&nbsp;</p>
                    </td>
                </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
                
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
                <tr class="NoRecords">
                    <td colspan="3">No Books found for this Subject</td>
                </tr>
                
  </asp:PlaceHolder>

            </table>
        </td>
    </tr>
</table>

  </FooterTemplate>
</asp:repeater>

<p></p>
<p></p>
<p>
<table cellspacing="0" cellpadding="0" width="70%" align="center" border="0">
    <tr>
        <td valign="top">
            <table class="Grid" cellspacing="0" cellpadding="0">
                <tr class="Bottom">
                    <td align="right"><em>Only 'Runs Taken' will be updated:</em> 
                        <asp:button id="BOOK_DESPATCHButton_UpdateRuns" runat="server" text="Update" cssclass="Button" />&nbsp;&nbsp; </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</p>
<p></p>
<p align="center">

<asp:repeater id="EditableGrid1Repeater" OnItemCommand="EditableGrid1ItemCommand" OnItemDataBound="EditableGrid1ItemDataBound" runat="server">
  <HeaderTemplate>
  


    
	<script language="JavaScript" >
	var EditableGrid1Elements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initEditableGrid1Elements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
    <table class="MainTable" cellspacing="0" cellpadding="0" width="70%" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Runs Taken - What Modules to Send</th>
 
                        <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Grid" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="EditableGrid1Error" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="3"><asp:Label ID="ErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Caption">
                        <th>
                        <p align="center">BOOK ID (Module)</p>
                        </th>
 
                        <th>
                        <p align="center">DESPATCH STATUS</p>
                        </th>
 
                        <th>
                        <p align="center">DESPATCH DATE</p>
                        </th>
                    </tr>
 
                    
  </HeaderTemplate>
  <ItemTemplate>
    
                    
  <asp:PlaceHolder id="RowError" visible="False" runat="server">
    
                    <tr class="Error">
                        <td colspan="3"><asp:Label ID="ErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>

                    <tr class="Row">
                        <td>
                            <p align="center">
  <input id="EditableGrid1BOOK_ID"  value='<%# (CType(Container.DataItem,EditableGrid1Item)).BOOK_ID.GetFormattedValue() %>' type="hidden"  runat="server"/>
  <asp:Literal id="EditableGrid1lblBookID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,EditableGrid1Item)).lblBookID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;&nbsp;<asp:Literal id="EditableGrid1module_display" Text='<%# Server.HtmlEncode((CType(Container.DataItem,EditableGrid1Item)).module_display.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></p>
                        </td> 
                        <td>
                            <p align="center">
                            <asp:RadioButtonList id="EditableGrid1DESPATCH_STATUS"  onclick="javascript:getStatus_SetDate(this.id);" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></p>
                        </td> 
                        <td>
                            <p align="center">
                            <asp:TextBox id="EditableGrid1DESPATCH_DATE" Text='<%# (CType(Container.DataItem,EditableGrid1Item)).DESPATCH_DATE.GetFormattedValue() %>' onfocus="this.select();" maxlength="12" Columns="8"	runat="server"/></p>
                        </td>
                    </tr>
 
  </ItemTemplate>

  <FooterTemplate>
	
                    
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
                    <tr class="NoRecords">
                        <td colspan="3">No Books found for this Subject!</td>
                    </tr>
                    
  </asp:PlaceHolder>

                    <tr class="Footer">
                        <td style="TEXT-ALIGN: right" colspan="3"><em>Only 'Runs Taken' will be updated:</em>&nbsp;</td>
                    </tr>
 
                    <tr class="Footer">
                        <td style="TEXT-ALIGN: right" colspan="3">
                            <asp:Button id="EditableGrid1Button_Submit" CssClass="Button" Text="Update" CommandName="Submit" runat="server"/></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>



  </FooterTemplate>
</asp:repeater>
<br>
<br>
&nbsp;</p>
<script type="text/javascript">
function getStatus_SetDate(ctlid)
{
// Coded by Vikas 1-Feb-2010 for unfuddle ticket #210 to auto fill date to today when Runs Taken set to 'Sent' and date is blank
//alert(ctlid);
 if (ctlid)
 {
    var sendRadiobuttonid = ctlid + "_0";
    var NRRadiobuttonid = ctlid + "_1";
    var ToBesendRadiobuttonid = ctlid + "_2";
    var dateSentTextBox = ctlid.replace("STATUS","DATE");
    var TodayDate=new Date();
    var tdate = TodayDate.getDate();
    var month = TodayDate.getMonth()+1;
    var yr = TodayDate.getFullYear().toString();
    
    if (tdate<10)
        tdate = "0" + tdate;
    if (month<10)
        month = "0" + month;
    yr= yr.substring(2,4);
        
    var setDateFormat= tdate + "/" +  month + "/" + yr ;
    if (document.getElementById(sendRadiobuttonid).checked==true)
    {
       document.getElementById(dateSentTextBox).value=setDateFormat;
    }
    else if (document.getElementById(NRRadiobuttonid).checked==true)
    {
        document.getElementById(dateSentTextBox).value="";    
    }    
    else if (document.getElementById(ToBesendRadiobuttonid).checked==true)
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

