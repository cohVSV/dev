<!--ASPX page @1-75DB4837-->
    <%@ Page language="vb" CodeFile="SUBJECT_maint.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.SUBJECT_maint.SUBJECT_maintPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.SUBJECT_maint" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>SUBJECT</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_SUBJECT_TEACHER_Button_Submit_OnClick @117-8A44DC84
function page_SUBJECT_TEACHER_Button_Submit_OnClick()
{
    var result;
//End page_SUBJECT_TEACHER_Button_Submit_OnClick

//Confirmation Message @118-257FDD03
    return confirm('Submit records?');
//End Confirmation Message

//Close page_SUBJECT_TEACHER_Button_Submit_OnClick @117-BC33A33A
    return result;
}
//End Close page_SUBJECT_TEACHER_Button_Submit_OnClick

//page_NewRecord1_Button_Cancel_OnClick @32-E10D8BD9
function page_NewRecord1_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_NewRecord1_Button_Cancel_OnClick

//page_SUBJECT_TEACHER_Cancel_OnClick @119-6DE00F65
function page_SUBJECT_TEACHER_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_SUBJECT_TEACHER_Cancel_OnClick

//bind_events @1-3B599B1E
function bind_events() {
    if(typeof(initSUBJECT_TEACHERElements) == "function")
        initSUBJECT_TEACHERElements();
    if(typeof(SUBJECT_TEACHERStaticElementsID) == "object" && typeof(SUBJECT_TEACHERStaticElementsID[SUBJECT_TEACHERButton_SubmitID]) == "object" && SUBJECT_TEACHERStaticElementsID[SUBJECT_TEACHERButton_SubmitID]!=null)
        addEventHandler(SUBJECT_TEACHERStaticElementsID[SUBJECT_TEACHERButton_SubmitID].id, "click", page_SUBJECT_TEACHER_Button_Submit_OnClick);
    addEventHandler("NewRecord1Button_Cancel","click",page_NewRecord1_Button_Cancel_OnClick);
    addEventHandler("SUBJECT_TEACHERCancel","click",page_SUBJECT_TEACHER_Cancel_OnClick);
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
<p align="center"><a id="Link1" href="" class="Button" runat="server"  >Return to Subject Search</a></p>

  <span id="NewRecord1Holder" runat="server">
    


  <table cellspacing="0" cellpadding="0" width="80%" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Add/Edit SUBJECT </th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="NewRecord1Error" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="4"><asp:Label ID="NewRecord1ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>SUBJECT ID</th>
 
            <td><asp:TextBox id="NewRecord1SUBJECT_ID" maxlength="10" Columns="10"	runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>SUBJECT ABBREV</th>
 
            <td><asp:TextBox id="NewRecord1SUBJECT_ABBREV" maxlength="6" Columns="6"	runat="server"/></td> 
            <td>&nbsp;SUBJECT TITLE</td> 
            <td>&nbsp;<asp:TextBox id="NewRecord1SUBJECT_TITLE" maxlength="37" Columns="40"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td> 
            <td nowrap>&nbsp;<em>New Title (for next year)</em></td> 
            <td>&nbsp;<asp:TextBox id="NewRecord1SUBJECT_TITLE_NEW" maxlength="37" Columns="40"	runat="server"/><br>
              <em>2016 Enrolments onwards, if supplied, then some Enrolment areas will use this Title</em></td>
          </tr>
 
          <tr class="Controls">
            <th>CORE FOR YEAR LEVEL (7-10)</th>
 
            <td>
              <select id="NewRecord1CORE_YEARLEVELS"  runat="server"></select>
 &nbsp;</td> 
            <td>&nbsp;YEAR LEVEL</td> 
            <td>&nbsp;<asp:TextBox id="NewRecord1YEAR_LEVEL" maxlength="5" Columns="5"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>CORE / NON-CORE SUBJECT</th>
 
            <td>
              <asp:RadioButtonList id="NewRecord1rbCORE_SUBJECT_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td> 
            <td>LINKED SUBJECT ID</td> 
            <td>&nbsp;<asp:TextBox id="NewRecord1LINKED_SUBJECT_ID" maxlength="10" Columns="10"	runat="server"/><em>&nbsp;(subsequent subject id, else 0)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>MAX STUDENT ALLOCATION&nbsp;</th>
 
            <td><asp:TextBox id="NewRecord1ALLOCATE_STUDENTS_MAX" maxlength="3" Columns="4"	runat="server"/>&nbsp;</td> 
            <td>EXTENDABLE SUBJECT?&nbsp;</td> 
            <td>&nbsp;<asp:CheckBox id="NewRecord1checkEXTENDABLE_SUBJECT" runat="server"/>&nbsp;<em>(tick for Extending&nbsp;allowed)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>Parent / Full Year Grouping&nbsp;</th>
 
            <td colspan="2">
              <select id="NewRecord1listParentGroupSubject"  runat="server"></select>
 &nbsp;</td> 
            <td><em>(create Parent Subject first if not shown)</em>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>DEFAULT SEMESTER</th>
 
            <td>
              <select id="NewRecord1DEFAULT_SEMESTER"  runat="server"></select>
 </td> 
            <td>&nbsp;DEFAULT TEACHER ID</td> 
            <td>&nbsp; 
              <select id="NewRecord1DEFAULT_TEACHER_ID"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th>&nbsp;</th>
 
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>SUB SCHOOL</th>
 
            <td><asp:TextBox id="NewRecord1SUB_SCHOOL" maxlength="10" Columns="6"	runat="server"/>&nbsp;<em>(used if Core 'Elective')</em></td> 
            <td>&nbsp;KEY LEARNING AREA</td> 
            <td>&nbsp; 
              <select id="NewRecord1KLA_ID"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th>CSF CLASS LEVEL</th>
 
            <td><asp:TextBox id="NewRecord1CSF_CLASS_LEVEL" maxlength="5" Columns="6"	runat="server"/></td> 
            <td>&nbsp;MAX NO OF BOOKS</td> 
            <td>&nbsp;<asp:TextBox id="NewRecord1MAX_BOOKS" maxlength="3" Columns="3"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>CAMPUS CODE</th>
 
            <td colspan="2">
              <select id="NewRecord1CAMPUS_CODE"  runat="server"></select>
 </td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>VALID COURSE DISTRIBUTION</th>
 
            <td colspan="2">Book:<asp:CheckBox id="NewRecord1cbx_COURSE_B" runat="server"/>&nbsp;&nbsp; CD:<asp:CheckBox id="NewRecord1cbx_COURSE_C" runat="server"/>&nbsp;&nbsp; Email:<asp:CheckBox id="NewRecord1cbx_COURSE_E" runat="server"/>&nbsp;&nbsp; Internet:<asp:CheckBox id="NewRecord1cbx_COURSE_I" runat="server"/>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>DESCRIPTION LINE 1</th>
 
            <td colspan="2">
<asp:TextBox id="NewRecord1DESCRIPTION_LINE1" rows="3" Columns="50" TextMode="MultiLine"	runat="server"/>
&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>DESCRIPTION LINE 2</th>
 
            <td colspan="2">
<asp:TextBox id="NewRecord1DESCRIPTION_LINE2" rows="3" Columns="50" TextMode="MultiLine"	runat="server"/>
&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>STATUS</th>
 
            <td>
              <asp:RadioButtonList id="NewRecord1STATUS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY</th>
 
            <td><asp:Literal id="NewRecord1LAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="NewRecord1LAST_ALTERED_DATE" runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="4" align="right">
              <input id='NewRecord1Button_Insert' type="submit" class="Button" value="Add new" OnServerClick='NewRecord1_Insert' runat="server"/>
              <input id='NewRecord1Button_Update' type="submit" class="Button" value="Update" OnServerClick='NewRecord1_Update' runat="server"/>
              <input id='NewRecord1Button_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='NewRecord1_Cancel' runat="server"/></td>
          </tr>
        </table>
        
  <input id="NewRecord1hidden_VALID_COURSE_DISTRIBUTION" type="hidden"  runat="server"/>
  
  <input id="NewRecord1hidden_LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="NewRecord1hidden_LAST_ALTERED_DATE" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>



  </span>
  <br>
<br>
<div align="center">
  
<asp:repeater id="SUBJECT_TEACHERRepeater" OnItemCommand="SUBJECT_TEACHERItemCommand" OnItemDataBound="SUBJECT_TEACHERItemDataBound" runat="server">
  <HeaderTemplate>
  
  

    
	<script language="JavaScript" >
	var SUBJECT_TEACHERElements;
	<asp:Literal ID="ElementsID" runat="server"/>
	function initSUBJECT_TEACHERElements(){
	<asp:Literal ID="FormScript" runat="server"/>
	}
	</script>
	 
    <table cellspacing="0" cellpadding="0" border="0">
      <tr>
        <td valign="top">
          <table class="Header" cellspacing="0" cellpadding="0" border="0">
            <tr>
              <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
              <th>List of Subject Teachers for Automatic Allocations&nbsp;<em><font color="#800000">only used if DEFAULT TEACHER ID ='NA' or 'N-A'</font></em></th>
 
              <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
            </tr>
          </table>
 
          <table class="Grid" cellspacing="0" cellpadding="0" width="80%" align="center">
            
  <asp:PlaceHolder id="SUBJECT_TEACHERError" visible="False" runat="server">
  
            <tr class="Error">
              <td colspan="5"><asp:Label ID="ErrorLabel" runat="server"/></td>
            </tr>
            
  </asp:PlaceHolder>
  
            <tr class="Caption">
              <th>TEACHER</th>
 
              <th>SUBJECT TIME FRACTION</th>
 
              <th>ALLOCATE TO?</th>
 
              <th>LAST ALTERED BY / DATE</th>
 
              <th>Delete?</th>
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
                <select id="SUBJECT_TEACHERSTAFF_ID"  runat="server"></select>
 
  <input id="SUBJECT_TEACHERSUBJECT_ID"  value='<%# (CType(Container.DataItem,SUBJECT_TEACHERItem)).SUBJECT_ID.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td> 
              <td><asp:TextBox id="SUBJECT_TEACHERSUBJECT_TIMEFRACTION" Text='<%# (CType(Container.DataItem,SUBJECT_TEACHERItem)).SUBJECT_TIMEFRACTION.GetFormattedValue() %>' maxlength="4" Columns="5"	runat="server"/></td> 
              <td>
                <asp:RadioButtonList id="SUBJECT_TEACHERALLOCATABLE_FLAG"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
              <td><asp:Literal id="SUBJECT_TEACHERlblLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECT_TEACHERItem)).lblLAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ <asp:Literal id="SUBJECT_TEACHERlblLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,SUBJECT_TEACHERItem)).lblLAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>
  <input id="SUBJECT_TEACHERLAST_ALTERED_BY"  value='<%# (CType(Container.DataItem,SUBJECT_TEACHERItem)).LAST_ALTERED_BY.GetFormattedValue() %>' type="hidden"  runat="server"/>
  
  <input id="SUBJECT_TEACHERLAST_ALTERED_DATE"  value='<%# (CType(Container.DataItem,SUBJECT_TEACHERItem)).LAST_ALTERED_DATE.GetFormattedValue() %>' type="hidden"  runat="server"/>
  </td> 
              <td>
                <asp:CheckBox id="SUBJECT_TEACHERCheckBox_Delete" Visible = "<%# (CType(Container.DataItem,SUBJECT_TEACHERItem)).IsDeleteAllowed %>" runat="server"/>&nbsp;</td>
            </tr>
 
  </ItemTemplate>

  <FooterTemplate>
	
            
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
            <tr class="NoRecords">
              <td colspan="5">No Subject Teachers found!</td>
            </tr>
            
  </asp:PlaceHolder>

            <tr class="Footer">
              <td style="TEXT-ALIGN: right" colspan="5">
                <asp:Button id="SUBJECT_TEACHERButton_Submit" CssClass="Button" Text="Save changes" CommandName="Submit" runat="server"/>
                <asp:Button id="SUBJECT_TEACHERCancel" CssClass="Button" Text="Cancel" runat="server"/></td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  

  
  </FooterTemplate>
</asp:repeater>

</div>
<br>

</form>
</body>
</html>

<!--End ASPX page-->

