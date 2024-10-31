<!--ASPX page @1-841672BE-->
    <%@ Page language="vb" CodeFile="SUBJECT_maint_bak.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.SUBJECT_maint_bak.SUBJECT_maint_bakPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.SUBJECT_maint_bak" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>SUBJECT</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p align="center"><a id="Link1" href="" class="Button" runat="server"  >Return to Subject Search</a></p>

  <span id="SUBJECTHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Add/Edit SUBJECT </th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="SUBJECTError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="4"><asp:Label ID="SUBJECTErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>SUBJECT ID</th>
 
            <td>
              <asp:TextBox id="SUBJECTtxtNewSubjectID" maxlength="6" Columns="6"	runat="server"/><asp:Literal id="SUBJECTlblSubjectID" runat="server"/>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>SUBJECT ABBREVIATION</th>
 
            <td><asp:TextBox id="SUBJECTSUBJECT_ABBREV" maxlength="6" Columns="6"	runat="server"/></td> 
            <td>&nbsp;SUBJECT TITLE</td> 
            <td>&nbsp;<asp:TextBox id="SUBJECTSUBJECT_TITLE" maxlength="37" Columns="37"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>CAMPUS CODE</th>
 
            <td>
              <select id="SUBJECTCAMPUS_CODE"  runat="server"></select>
 </td> 
            <td>&nbsp;YEAR LEVEL</td> 
            <td>&nbsp;<asp:TextBox id="SUBJECTYEAR_LEVEL" maxlength="5" Columns="5"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>DEFAULT SEMESTER</th>
 
            <td><asp:TextBox id="SUBJECTDEFAULT_SEMESTER" maxlength="1" Columns="1"	runat="server"/></td> 
            <td>&nbsp;DEFAULT TEACHER ID</td> 
            <td>&nbsp; 
              <select id="SUBJECTDEFAULT_TEACHER_ID"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th>SUB SCHOOL</th>
 
            <td><asp:TextBox id="SUBJECTSUB_SCHOOL" maxlength="10" Columns="10"	runat="server"/></td> 
            <td>&nbsp;KEY LEARNING AREA</td> 
            <td>&nbsp; 
              <select id="SUBJECTKLA_ID"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th>CSF CLASS LEVEL</th>
 
            <td><asp:TextBox id="SUBJECTCSF_CLASS_LEVEL" maxlength="5" Columns="5"	runat="server"/></td> 
            <td>&nbsp;MAX NO. OF BOOKS</td> 
            <td>&nbsp;<asp:TextBox id="SUBJECTMAX_BOOKS" maxlength="3" Columns="3"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>VALID COURSE DISTRIBUTION</th>
 
            <td colspan="3">
              <asp:CheckBoxList id="SUBJECTVALID_COURSE_DISTRIBUTION" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>DESCRIPTION LINE 1</th>
 
            <td colspan="3">
<asp:TextBox id="SUBJECTDESCRIPTION_LINE1" rows="3" Columns="50" TextMode="MultiLine"	runat="server"/>
&nbsp;&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>DESCRIPTION LINE 2</th>
 
            <td colspan="3">
<asp:TextBox id="SUBJECTDESCRIPTION_LINE2" rows="3" Columns="50" TextMode="MultiLine"	runat="server"/>
&nbsp;&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>STATUS</th>
 
            <td>
              <asp:RadioButtonList id="SUBJECTSTATUS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY / DATE</th>
 
            <td><asp:Literal id="SUBJECTLAST_ALTERED_BY" runat="server"/></td> 
            <td>&nbsp;<asp:Literal id="SUBJECTLAST_ALTERED_DATE" runat="server"/></td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="4">
              <input id='SUBJECTButton_Insert' class="Button" type="submit" value="Add new" OnServerClick='SUBJECT_Insert' runat="server"/>
              <input id='SUBJECTButton_Update' class="Button" type="submit" value="Update" OnServerClick='SUBJECT_Update' runat="server"/>
              <input id='SUBJECTButton_Delete' class="Button" type="submit" value="Delete" OnServerClick='SUBJECT_Delete' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  <br>

</form>
</body>
</html>

<!--End ASPX page-->

