<!--ASPX page @1-46BCB634-->
    <%@ Page language="vb" CodeFile="Student_Carer_maintainext.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_Carer_maintainext.Student_Carer_maintainextPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_Carer_maintainext" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="StudentNamePlate" Src="StudentNamePlate.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 4.1.00.032"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Carer Contact Details maintain</title>


<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" src="js/pt/prototype.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/pt/scriptaculous.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/pt/controls.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/pt/ajaxpanel.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/Services.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">


//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_STUDENT_CARER_CONTACT3_Button_Delete_OnClick @36-8C11914C
function page_STUDENT_CARER_CONTACT3_Button_Delete_OnClick()
{
    var result;
//End page_STUDENT_CARER_CONTACT3_Button_Delete_OnClick

//Confirmation Message @37-37FDFDD0
    return confirm('Unlink Carer (B) from this Student only?');
//End Confirmation Message

//Close page_STUDENT_CARER_CONTACT3_Button_Delete_OnClick @36-BC33A33A
    return result;
}
//End Close page_STUDENT_CARER_CONTACT3_Button_Delete_OnClick

//page_STUDENT_CARER_CONTACT4_Button_Update_OnClick @105-C28F64E8
function page_STUDENT_CARER_CONTACT4_Button_Update_OnClick()
{
    var result;
//End page_STUDENT_CARER_CONTACT4_Button_Update_OnClick

//Confirmation Message @201-E0E3F04D
    return confirm('NOTE: This will update this Supervisors details for ALL Students they are linked to, not only for this student.');
//End Confirmation Message

//Close page_STUDENT_CARER_CONTACT4_Button_Update_OnClick @105-BC33A33A
    return result;
}
//End Close page_STUDENT_CARER_CONTACT4_Button_Update_OnClick

//page_STUDENT_CARER_CONTACT4_Button_Delete_OnClick @106-D0A1B225
function page_STUDENT_CARER_CONTACT4_Button_Delete_OnClick()
{
    var result;
//End page_STUDENT_CARER_CONTACT4_Button_Delete_OnClick

//Confirmation Message @107-8243B274
    return confirm('Delete record?');
//End Confirmation Message

//Close page_STUDENT_CARER_CONTACT4_Button_Delete_OnClick @106-BC33A33A
    return result;
}
//End Close page_STUDENT_CARER_CONTACT4_Button_Delete_OnClick

//page_STUDENT_CARER_CONTACT4_OnLoad @103-A13616D9
function page_STUDENT_CARER_CONTACT4_OnLoad(form)
{
    var result;
//End page_STUDENT_CARER_CONTACT4_OnLoad

//Set Focus @234-ADA893AC
    if (theForm.STUDENT_CARER_CONTACT4SURNAME) theForm.STUDENT_CARER_CONTACT4SURNAME.focus();
//End Set Focus

//Close page_STUDENT_CARER_CONTACT4_OnLoad @103-BC33A33A
    return result;
}
//End Close page_STUDENT_CARER_CONTACT4_OnLoad

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//Set Focus @76-6330F697
    if (theForm.STUDENT_CARER_CONTACT3SURNAME) theForm.STUDENT_CARER_CONTACT3SURNAME.focus();
//End Set Focus

//Close page_OnLoad @1-BC33A33A
    return result;
}
//End Close page_OnLoad

//page_STUDENT_CARER_CONTACT3_Button_Cancel_OnClick @38-81B37E4B
function page_STUDENT_CARER_CONTACT3_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_CARER_CONTACT3_Button_Cancel_OnClick

//page_STUDENT_CARER_CONTACT4_Button_Cancel_OnClick @108-ABC63F1E
function page_STUDENT_CARER_CONTACT4_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_CARER_CONTACT4_Button_Cancel_OnClick

//page_STUDENT_CARER_CONTACT6_Button_Update_OnClick @443-27D0595C
function page_STUDENT_CARER_CONTACT6_Button_Update_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_CARER_CONTACT6_Button_Update_OnClick

//page_STUDENT_CARER_CONTACT6_Button_Cancel_OnClick @445-78D50ABD
function page_STUDENT_CARER_CONTACT6_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_CARER_CONTACT6_Button_Cancel_OnClick

//page_STUDENT_CARER_CONTACT_EMERGENCY_EDIT_Button_Delete_OnClick @658-8ED12345
function page_STUDENT_CARER_CONTACT_EMERGENCY_EDIT_Button_Delete_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_CARER_CONTACT_EMERGENCY_EDIT_Button_Delete_OnClick

//page_STUDENT_CARER_CONTACT_EMERGENCY_EDIT_Button_Cancel_OnClick @659-AA7BA0BB
function page_STUDENT_CARER_CONTACT_EMERGENCY_EDIT_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_CARER_CONTACT_EMERGENCY_EDIT_Button_Cancel_OnClick

//Handle Condition1 @471-02594818
function Condition1_start(sender) {
//End Handle Condition1

//Custom Condition1 @471-67288CCD
    if (true==(params["click"] == "link"))
    {
    } else {
    }
//End Custom Condition1

//Condition1 Tail @471-FCB6E20C
}
//End Condition1 Tail

//Handle Condition2 @477-2B91FCEA
function Condition2_start(sender) {
//End Handle Condition2

//Custom Condition2 @477-D34BA941
    if (true==(params["click"] == "submit" && $("#ErrorBlock").length == 0))
    {
    } else {
    }
//End Custom Condition2

//Condition2 Tail @477-FCB6E20C
}
//End Condition2 Tail

//Handle Condition3 @483-85F96D7B
function Condition3_start(sender) {
//End Handle Condition3

//Custom Condition3 @483-3ACAA933
    if (true==(params["click"] = "link"))
    {
    } else {
    }
//End Custom Condition3

//Condition3 Tail @483-FCB6E20C
}
//End Condition3 Tail

//Handle Condition4 @496-7800950E
function Condition4_start(sender) {
//End Handle Condition4

//Custom Condition4 @496-3B4E074B
    if (true==(params["click"] = "submit"))
    {
    } else {
    }
//End Custom Condition4

//Condition4 Tail @496-FCB6E20C
}
//End Condition4 Tail

//Handle Condition5 @503-D668049F
function Condition5_start(sender) {
//End Handle Condition5

//Custom Condition5 @503-CECB318E
    if (true==(params["click"] = ""))
    {
    } else {
    }
//End Custom Condition5

//Condition5 Tail @503-FCB6E20C
}
//End Condition5 Tail

//bind_events @1-717AA5E8
function bind_events() {
    addEventHandler("STUDENT_CARER_CONTACT5Detail", "click", Condition3_start);
    addEventHandler("STUDENT_CARER_CONTACT6", "submit", Condition4_start);
    if(document.getElementById("STUDENT_CARER_CONTACT4Holder"))
    addEventHandler("STUDENT_CARER_CONTACT4","load",page_STUDENT_CARER_CONTACT4_OnLoad);
    addEventHandler("STUDENT_CARER_CONTACT4Button_Delete","click",page_STUDENT_CARER_CONTACT4_Button_Delete_OnClick);
    addEventHandler("STUDENT_CARER_CONTACT4Button_Update","click",page_STUDENT_CARER_CONTACT4_Button_Update_OnClick);
    addEventHandler("STUDENT_CARER_CONTACT3Button_Delete","click",page_STUDENT_CARER_CONTACT3_Button_Delete_OnClick);
    addEventHandler("STUDENT_CARER_CONTACT3Button_Cancel","click",page_STUDENT_CARER_CONTACT3_Button_Cancel_OnClick);
    addEventHandler("STUDENT_CARER_CONTACT4Button_Cancel","click",page_STUDENT_CARER_CONTACT4_Button_Cancel_OnClick);
    addEventHandler("STUDENT_CARER_CONTACT6Button_Update","click",page_STUDENT_CARER_CONTACT6_Button_Update_OnClick);
    addEventHandler("STUDENT_CARER_CONTACT6Button_Cancel","click",page_STUDENT_CARER_CONTACT6_Button_Cancel_OnClick);
    addEventHandler("STUDENT_CARER_CONTACT_EMERGENCY_EDITButton_Delete","click",page_STUDENT_CARER_CONTACT_EMERGENCY_EDIT_Button_Delete_OnClick);
    addEventHandler("STUDENT_CARER_CONTACT_EMERGENCY_EDITButton_Cancel","click",page_STUDENT_CARER_CONTACT_EMERGENCY_EDIT_Button_Cancel_OnClick);
    page_OnLoad();
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

window.onload = bind_events;

//End CCS script

/* 9 Jun 2021|RW| Adding convenience button to copy across searched fields, at Ria's request (#32591)
 */
function CopyToAddEdit_OnClick()
{
   var sourceSurname = document.getElementById("STUDENT_CARER_CONTACTSearchs_SURNAME").value;
   var sourceFirstName = document.getElementById("STUDENT_CARER_CONTACTSearchs_FIRST_NAME").value;
   var sourceEmail = document.getElementById("STUDENT_CARER_CONTACTSearchs_EMAIL").value;

   sourceSurname = sourceSurname.charAt(0).toUpperCase() + sourceSurname.slice(1);
   sourceFirstName = sourceFirstName.charAt(0).toUpperCase() + sourceFirstName.slice(1);

   var destinationSurnameElement = document.getElementById("STUDENT_CARER_CONTACT3SURNAME");
   var destinationFirstNameElement = document.getElementById("STUDENT_CARER_CONTACT3FIRST_NAME");
   var destinationEmailElement = document.getElementById("STUDENT_CARER_CONTACT3EMAIL");

   destinationSurnameElement.value = sourceSurname;
   destinationFirstNameElement.value = sourceFirstName;
   destinationEmailElement.value = sourceEmail;
}

</script>
<style type="text/css">
<!--
.radio-supervisors .radioLabel span {
  display: inline-block;
  width: 12%;
  padding-left: 2px;
}
.radio-supervisors .radioLabel span.wide {
  white-space:nowrap;
  width: 20%;
}
.radio-supervisors .radioLabel span.fullwidth {
  white-space:nowrap;
  width: 88%;
}
.radioLabel:hover>span {
background-color: gray;
color: white;
}
-->
</style>
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">

</head>
<body>
<form runat="server">


<p width="90%"><DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/></p>
<p><DECV_PROD2007:StudentNamePlate id="StudentNamePlate" runat="server"/></p>
<table width="80%" align="center" border="0">
  <tr>
    <td style="WIDTH: 30%" valign="top">&nbsp; 
      
<asp:repeater id="STUDENT_CARER_CONTACTRepeater" OnItemCommand="STUDENT_CARER_CONTACTItemCommand" OnItemDataBound="STUDENT_CARER_CONTACTItemDataBound" runat="server">
  <HeaderTemplate>
	
      <table cellspacing="0" cellpadding="0" width="300" border="0">
        <tr>
          <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                <th>Parent A /&nbsp;<font color="#ffff00">Primary Carer</font></th>
 
                <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
              </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
              
  </HeaderTemplate>
  <ItemTemplate>
              <tr class="Row">
                <th>Name</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACTTITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACTFIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACTSURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
              </tr>
 
              <tr class="Row">
                <th>Relationship</th>
 
                <td>
                  <select id="STUDENT_CARER_CONTACTRELATIONSHIP" disabled  runat="server"></select>
 &nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>Home Phone</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACTHOME_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).HOME_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>Work Phone</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACTWORK_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).WORK_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>Mobile</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACTMOBILE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).MOBILE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>Email Address</th>
 
                <td><a id="STUDENT_CARER_CONTACTEMAIL" href="" runat="server"  ><%#(CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).EMAIL.GetFormattedValue()%></a>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>Last Portal Login&nbsp;&nbsp;</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACTPORTAL_LAST_LOGIN_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).PORTAL_LAST_LOGIN_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>Last Altered By / Date / ID</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACTLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_CARER_CONTACTLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_CARER_CONTACTCARER_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACTItem)).CARER_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Bottom">
                <td colspan="2" align="right"><a id="STUDENT_CARER_CONTACTLink_EditParentA" href="" class="Button" style="HEIGHT: 16px; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 4px; PADDING-RIGHT: 4px" runat="server"  >Edit Parent A</a></td>
              </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
              
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
              <tr class="NoRecords">
                <td colspan="2">
                  <p>No Contact Details for Parent A.&nbsp;</p>
 
                  <p>Have you checked the <a id="STUDENT_CARER_CONTACTlinkFamilyGroup" href="" class="Button" style="HEIGHT: 12px; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 4px; PADDING-RIGHT: 4px" runat="server"  >Family Group</a>&nbsp;for existing Carers?<br>
                  <br>
<a id="STUDENT_CARER_CONTACTlink_AddParent" href="" class="Button" style="HEIGHT: 12px; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 4px; PADDING-RIGHT: 4px" runat="server"  >Add Parent</a></p>
                </td>
              </tr>
              
  </asp:PlaceHolder>

            </table>
          </td>
        </tr>
      </table>
      &nbsp;
  </FooterTemplate>
</asp:repeater>
</td> 
    <td style="WIDTH: 30%" valign="top">&nbsp; 
      
<asp:repeater id="STUDENT_CARER_CONTACT1Repeater" OnItemCommand="STUDENT_CARER_CONTACT1ItemCommand" OnItemDataBound="STUDENT_CARER_CONTACT1ItemDataBound" runat="server">
  <HeaderTemplate>
	
      <table cellspacing="0" cellpadding="0" width="300" border="0">
        <tr>
          <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                <th>Parent&nbsp;B</th>
 
                <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
              </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
              
  </HeaderTemplate>
  <ItemTemplate>
              <tr class="Row">
                <th>Name</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT1TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACT1FIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACT1SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
              </tr>
 
              <tr class="Row">
                <th>Relationship</th>
 
                <td>
                  <select id="STUDENT_CARER_CONTACT1RELATIONSHIP" disabled  runat="server"></select>
 </td>
              </tr>
 
              <tr class="Row">
                <th>Home Phone</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT1HOME_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).HOME_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>Work Phone</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT1WORK_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).WORK_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>Mobile</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT1MOBILE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).MOBILE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>Email Address</th>
 
                <td><a id="STUDENT_CARER_CONTACT1EMAIL" href="" runat="server"  ><%#(CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).EMAIL.GetFormattedValue()%></a>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>Last Portal Login&nbsp;&nbsp;</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT1PORTAL_LAST_LOGIN_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).PORTAL_LAST_LOGIN_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>Last Altered By / Date / ID</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT1LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_CARER_CONTACT1LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_CARER_CONTACT1CARER_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT1Item)).CARER_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Bottom">
                <td colspan="2" align="right"><a id="STUDENT_CARER_CONTACT1Link1" href="" class="Button" style="HEIGHT: 16px; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 4px; PADDING-RIGHT: 4px" runat="server"  >Edit Parent B</a></td>
              </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
              
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
              <tr class="NoRecords">
                <td colspan="2">No Contact Details for Parent B.<br>
                  <br>
<a id="STUDENT_CARER_CONTACT1link_AddParent" href="" class="Button" style="HEIGHT: 12px; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 4px; PADDING-RIGHT: 4px" runat="server"  >Add Parent</a></td>
              </tr>
              
  </asp:PlaceHolder>

            </table>
          </td>
        </tr>
      </table>
      &nbsp;
  </FooterTemplate>
</asp:repeater>
</td> 
    <td style="WIDTH: 30%" valign="top">&nbsp; 
      
<asp:repeater id="STUDENT_CARER_CONTACT2Repeater" OnItemCommand="STUDENT_CARER_CONTACT2ItemCommand" OnItemDataBound="STUDENT_CARER_CONTACT2ItemDataBound" runat="server">
  <HeaderTemplate>
	
      <table cellspacing="0" cellpadding="0" width="300" border="0">
        <tr>
          <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                <th><asp:Literal id="STUDENT_CARER_CONTACT2lblSupervisor" runat="server"/><em>&nbsp;(if any)</em></th>
 
                <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
              </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
              
  </HeaderTemplate>
  <ItemTemplate>
              <tr class="Row">
                <th>Name</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT2TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACT2FIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACT2SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
              </tr>
 
              <tr class="Row">
                <th>Position&nbsp;</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT2SUPERVISOR_POSITION" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).SUPERVISOR_POSITION.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/> <asp:Literal id="STUDENT_CARER_CONTACT2SUPERVISOR_POSITION_OTHER" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).SUPERVISOR_POSITION_OTHER.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
              </tr>
 
              <tr class="Row">
                <th>&nbsp;</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT2Supervisortype" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).Supervisortype.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td>
              </tr>
 
              <tr class="Row">
                <th>Work Phone</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT2WORK_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).WORK_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>Mobile</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT2MOBILE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).MOBILE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>Email Address</th>
 
                <td><a id="STUDENT_CARER_CONTACT2EMAIL" href="" runat="server"  ><%#(CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).EMAIL.GetFormattedValue()%></a>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>Last Portal Login&nbsp;&nbsp;</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT2PORTAL_LAST_LOGIN_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).PORTAL_LAST_LOGIN_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>Last Altered By / Date / ID</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT2LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_CARER_CONTACT2LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_CARER_CONTACT2CARER_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT2Item)).CARER_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Bottom">
                <td colspan="2" align="right"><a id="STUDENT_CARER_CONTACT2LinkAddSupervisor2" href="" class="Button" style="HEIGHT: 12px; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 4px; PADDING-RIGHT: 4px" runat="server"  >Add New Supervisor</a>&nbsp; <a id="STUDENT_CARER_CONTACT2Link_EditSupervisor" href="" class="Button" style="HEIGHT: 16px; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 4px; PADDING-RIGHT: 4px" runat="server"  >Edit Supervisor</a></td>
              </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
              
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
              <tr class="NoRecords">
                <td colspan="2">No Contact Details for Supervisor. <br>
                  <br>
<a id="STUDENT_CARER_CONTACT2link_AddParent" href="" class="Button" style="HEIGHT: 12px; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 4px; PADDING-RIGHT: 4px" runat="server"  >Add Supervisor details</a></td>
              </tr>
              
  </asp:PlaceHolder>

            </table>
          </td>
        </tr>
      </table>
      &nbsp;
  </FooterTemplate>
</asp:repeater>
</td>
  </tr>
 
  <tr>
    <td colspan="3">
      <h2>Please include two emergency contacts who are <strong>NOT</strong> the Parent / Carer(s) nominated in this form.</h2>
 
      <h2>We CAN NOT accept parent/carers as emergency contacts.</h2>
    </td>
  </tr>
 
  <tr>
    <td style="WIDTH: 30%">
      
<asp:repeater id="STUDENT_CARER_CONTACT7Repeater" OnItemCommand="STUDENT_CARER_CONTACT7ItemCommand" OnItemDataBound="STUDENT_CARER_CONTACT7ItemDataBound" runat="server">
  <HeaderTemplate>
	
      <table id="STUDENT_CARER_CONTACT7" class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
          <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
                <th width="100%">Emergency Contact 1</th>
 
                <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
              </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
              
  </HeaderTemplate>
  <ItemTemplate>
              <tr class="Row">
                <th>CARER ID</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT7CARER_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT7Item)).CARER_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>NAME</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT7FIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT7Item)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACT7SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT7Item)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>HOME PHONE</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT7HOME_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT7Item)).HOME_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>MOBILE</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT7MOBILE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT7Item)).MOBILE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>LAST ALTERED BY</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT7LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT7Item)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>LAST ALTERED DATE</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT7LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT7Item)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>Relationship</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT7SUPERVISOR_POSITION_OTHER" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT7Item)).SUPERVISOR_POSITION_OTHER.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="NoRecords">
                <td colspan="2">&nbsp;<a id="STUDENT_CARER_CONTACT7Link2" href="" runat="server"  >Edit Emergency Contact</a></td>
              </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
              
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
              <tr class="NoRecords">
                <td colspan="2">
                  <p>Add Emergency Contact</p>
 
                  <p><a id="STUDENT_CARER_CONTACT7Link1" href="" runat="server"  >Add Emergency Contact</a></p>
                </td>
              </tr>
              
  </asp:PlaceHolder>

            </table>
          </td>
        </tr>
      </table>
      
  </FooterTemplate>
</asp:repeater>
<br>
    </td> 
    <td style="WIDTH: 30%">
      
<asp:repeater id="STUDENT_CARER_CONTACT8Repeater" OnItemCommand="STUDENT_CARER_CONTACT8ItemCommand" OnItemDataBound="STUDENT_CARER_CONTACT8ItemDataBound" runat="server">
  <HeaderTemplate>
	
      <table id="STUDENT_CARER_CONTACT8" class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
          <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
                <th width="100%">Emergency Contact 2</th>
 
                <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
              </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
              
  </HeaderTemplate>
  <ItemTemplate>
              <tr class="Row">
                <th>CARER ID</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT8CARER_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT8Item)).CARER_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>NAME</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT8FIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT8Item)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACT8SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT8Item)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>HOME PHONE</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT8HOME_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT8Item)).HOME_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>MOBILE</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT8MOBILE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT8Item)).MOBILE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>LAST ALTERED BY</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT8LAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT8Item)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>LAST ALTERED DATE</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT8LAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT8Item)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <th>Relationship</th>
 
                <td><asp:Literal id="STUDENT_CARER_CONTACT8SUPERVISOR_POSITION_OTHER" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT8Item)).SUPERVISOR_POSITION_OTHER.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="NoRecords">
                <td colspan="2">&nbsp;<a id="STUDENT_CARER_CONTACT8Link1" href="" runat="server"  >Edit Emergency Contact</a></td>
              </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
              
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
              <tr class="NoRecords">
                <td colspan="2">
                  <p>Add Emergency Contact</p>
 
                  <p><a id="STUDENT_CARER_CONTACT8Link2" href="" runat="server"  >Add Emergency Contact</a></p>
                </td>
              </tr>
              
  </asp:PlaceHolder>

            </table>
          </td>
        </tr>
      </table>
      
  </FooterTemplate>
</asp:repeater>
<br>
    </td> 
    <td></td>
  </tr>
</table>
<p>
<div align="center">
  
	<asp:PlaceHolder id="Panel1" Visible="true" runat="server">
	
  
  <span id="STUDENT_CARER_CONTACTSearchHolder" runat="server">
    
  

    <table class="MainTable" cellspacing="0" cellpadding="0" border="0">
      <tr>
        <td valign="top">
          <table class="Header" cellspacing="0" cellpadding="0" border="0">
            <tr>
              <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
              <th>Search first</th>
 
              <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
            </tr>
          </table>
 
          <table class="Record" cellspacing="0" cellpadding="0">
            
  <asp:PlaceHolder id="STUDENT_CARER_CONTACTSearchError" visible="False" runat="server">
  
            <tr id="<%=PageVariables.Get("@error-block")%>" class="Error">
              <td colspan="2"><asp:Label ID="STUDENT_CARER_CONTACTSearchErrorLabel" runat="server"/></td>
            </tr>
            
  </asp:PlaceHolder>
  
            <tr class="Controls">
              <th>SURNAME</th>
 
              <td><asp:TextBox id="STUDENT_CARER_CONTACTSearchs_SURNAME" maxlength="30" Columns="30"	runat="server"/><em>&nbsp;(any part)</em></td>
            </tr>
 
            <tr class="Controls">
              <th>FIRST NAME</th>
 
              <td><asp:TextBox id="STUDENT_CARER_CONTACTSearchs_FIRST_NAME" maxlength="30" Columns="30"	runat="server"/><em>&nbsp;</em><em>(any part)</em></td>
            </tr>
 
            <tr class="Controls">
              <th>EMAIL</th>
 
              <td><asp:TextBox id="STUDENT_CARER_CONTACTSearchs_EMAIL" maxlength="50" Columns="30"	runat="server"/>&nbsp;<em>(any part)</em></td>
            </tr>
 
            <tr class="Bottom">
              <td><a id="STUDENT_CARER_CONTACTSearchClearParameters" href="" runat="server"  >Clear</a></td> 
              <td style="TEXT-ALIGN: right">&nbsp; <input type="button" onclick="CopyToAddEdit_OnClick();" id="CopyToAddEdit" class="Button" value="Copy to Add/Edit"/>
                <input id='STUDENT_CARER_CONTACTSearchButton_DoSearch' type="submit" class="Button" value="Search" OnServerClick='STUDENT_CARER_CONTACTSearch_Search' runat="server"/></td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  

  
  </span>
  <br>
  
<asp:repeater id="STUDENT_CARER_CONTACT5Repeater" OnItemCommand="STUDENT_CARER_CONTACT5ItemCommand" OnItemDataBound="STUDENT_CARER_CONTACT5ItemDataBound" runat="server">
  <HeaderTemplate>
	
  <table id="Panel1STUDENT_CARER_CONTACT5" class="MainTable" cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>List of Carers </th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Grid" cellspacing="0" cellpadding="0">
          <tr class="Caption">
            <th>
            <CC:Sorter id="Sorter_CARER_IDSorter" field="Sorter_CARER_ID" OwnerState="<%# STUDENT_CARER_CONTACT5Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_CARER_CONTACT5Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_CARER_IDSort" runat="server">CARER ID</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_TITLESorter" field="Sorter_TITLE" OwnerState="<%# STUDENT_CARER_CONTACT5Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_CARER_CONTACT5Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_TITLESort" runat="server">TITLE</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_SURNAMESorter" field="Sorter_SURNAME" OwnerState="<%# STUDENT_CARER_CONTACT5Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_CARER_CONTACT5Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_SURNAMESort" runat="server">SURNAME</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_FIRST_NAMESorter" field="Sorter_FIRST_NAME" OwnerState="<%# STUDENT_CARER_CONTACT5Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_CARER_CONTACT5Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_FIRST_NAMESort" runat="server">FIRST NAME</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_HOME_PHONESorter" field="Sorter_HOME_PHONE" OwnerState="<%# STUDENT_CARER_CONTACT5Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_CARER_CONTACT5Data.SortDir%>" runat="server"><span class="Sorter">Phone (Home / Work)</span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_MOBILESorter" field="Sorter_MOBILE" OwnerState="<%# STUDENT_CARER_CONTACT5Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_CARER_CONTACT5Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_MOBILESort" runat="server">MOBILE</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>
            <CC:Sorter id="Sorter_EMAILSorter" field="Sorter_EMAIL" OwnerState="<%# STUDENT_CARER_CONTACT5Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_CARER_CONTACT5Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_EMAILSort" runat="server">EMAIL</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>Relation</th>
 
            <th>
            <CC:Sorter id="Sorter_PORTAL_LAST_LOGIN_DATESorter" field="Sorter_PORTAL_LAST_LOGIN_DATE" OwnerState="<%# STUDENT_CARER_CONTACT5Data.SortField.ToString()%>" OwnerDir="<%# STUDENT_CARER_CONTACT5Data.SortDir%>" runat="server"><span class="Sorter"><asp:LinkButton id="Sorter_PORTAL_LAST_LOGIN_DATESort" runat="server">PORTAL LAST LOGIN</asp:LinkButton> 
            <CC:SorterItem type="AscOn" runat="server"><img src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
            <CC:SorterItem type="DescOn" runat="server"><img src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></span></CC:Sorter></th>
 
            <th>&nbsp;Link Carer <br>
            (not Supervisor)</th>
          </tr>
 
          
  </HeaderTemplate>
  <ItemTemplate>
          <tr class="Row">
            <td><asp:Literal id="STUDENT_CARER_CONTACT5CARER_ID" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).CARER_ID.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="STUDENT_CARER_CONTACT5TITLE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).TITLE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="STUDENT_CARER_CONTACT5SURNAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).SURNAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="STUDENT_CARER_CONTACT5FIRST_NAME" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).FIRST_NAME.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="STUDENT_CARER_CONTACT5HOME_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).HOME_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_CARER_CONTACT5WORK_PHONE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).WORK_PHONE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td><asp:Literal id="STUDENT_CARER_CONTACT5MOBILE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).MOBILE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="STUDENT_CARER_CONTACT5EMAIL" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).EMAIL.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><asp:Literal id="STUDENT_CARER_CONTACT5RELATIONSHIP" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).RELATIONSHIP.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
            <td><asp:Literal id="STUDENT_CARER_CONTACT5PORTAL_LAST_LOGIN_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_CARER_CONTACT5Item)).PORTAL_LAST_LOGIN_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
            <td><a id="STUDENT_CARER_CONTACT5Detail" href="" runat="server"  >Link Carer</a></td>
          </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
          
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
          <tr class="NoRecords">
            <td colspan="10">No Carers found! Try changing the Search terms</td>
          </tr>
          
  </asp:PlaceHolder>

          <tr class="Footer">
            <td colspan="10">&nbsp; 
              
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# STUDENT_CARER_CONTACT5Data.PagesCount%>" PageSize="<%# STUDENT_CARER_CONTACT5Data.RecordsPerPage%>" PageNumber="<%# STUDENT_CARER_CONTACT5Data.PageNumber%>" runat="server"><span class="Navigator">
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
	
  
  <span id="STUDENT_CARER_CONTACT6Holder" runat="server">
    
  

    <table class="MainTable" cellspacing="0" cellpadding="0" border="0">
      <tr>
        <td valign="top">
          <table class="Header" cellspacing="0" cellpadding="0" border="0">
            <tr>
              <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
              <th>Link Carer to Student </th>
 
              <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
            </tr>
          </table>
 
          <table class="Record" cellspacing="0" cellpadding="0">
            
  <asp:PlaceHolder id="STUDENT_CARER_CONTACT6Error" visible="False" runat="server">
  
            <tr id="ErrorBlock" class="Error">
              <td colspan="2"><asp:Label ID="STUDENT_CARER_CONTACT6ErrorLabel" runat="server"/></td>
            </tr>
            
  </asp:PlaceHolder>
  
            <tr class="Controls">
              <th>CARER NAME</th>
 
              <td><asp:Literal id="STUDENT_CARER_CONTACT6FIRST_NAME" runat="server"/>&nbsp;<asp:Literal id="STUDENT_CARER_CONTACT6SURNAME" runat="server"/>&nbsp;</td>
            </tr>
 
            <tr class="Controls">
              <th><strong>EMAIL</strong></th>
 
              <td><asp:TextBox id="STUDENT_CARER_CONTACT6EMAIL" maxlength="250" Columns="40"	runat="server"/></td>
            </tr>
 
            <tr class="Controls">
              <th>Link to Carer&nbsp;</th>
 
              <td>
                <asp:RadioButtonList id="STUDENT_CARER_CONTACT6radioCarerType"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>&nbsp;</td>
            </tr>
 
            <tr class="Bottom">
              <td style="TEXT-ALIGN: right" colspan="2">&nbsp; 
                <input id='STUDENT_CARER_CONTACT6Button_Update' type="submit" class="Button" value="Update Email (only)" OnServerClick='STUDENT_CARER_CONTACT6_Update' runat="server"/>&nbsp; &nbsp; 
                <input id='STUDENT_CARER_CONTACT6Button_LinkParent' type="submit" class="Button" value="Link to Selected Carer" OnServerClick='STUDENT_CARER_CONTACT6_Delete' runat="server"/>&nbsp; &nbsp; 
                <input id='STUDENT_CARER_CONTACT6Button_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_CARER_CONTACT6_Cancel' runat="server"/></td>
            </tr>
 
            <tr class="Bottom">
              <td style="TEXT-ALIGN: center" colspan="2"></td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  

  
  </span>
  
	</asp:PlaceHolder>
	<br>
  
	</asp:PlaceHolder>
	
</div>

  <span id="STUDENT_CARER_CONTACT3Holder" runat="server">
    


  <div align="center">
    <table cellspacing="0" cellpadding="0" width="50%" align="center" border="0">
      <tr>
        <td valign="top">
          <table class="Header" cellspacing="0" cellpadding="0" border="0">
            <tr>
              <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
              <th>Add/Edit Carer and&nbsp;Parents</th>
 
              <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
            </tr>
          </table>
 
          <table class="Record" cellspacing="0" cellpadding="0">
            
  <asp:PlaceHolder id="STUDENT_CARER_CONTACT3Error" visible="False" runat="server">
  
            <tr class="Error">
              <td colspan="2"><asp:Label ID="STUDENT_CARER_CONTACT3ErrorLabel" runat="server"/></td>
            </tr>
            
  </asp:PlaceHolder>
  
            <tr class="Controls">
              <th>TITLE</th>
 
              <td>
                <select id="STUDENT_CARER_CONTACT3TITLE"  runat="server"></select>
 </td>
            </tr>
 
            <tr class="Controls">
              <th><strong>SURNAME / FAMILY</strong></th>
 
              <td><asp:TextBox id="STUDENT_CARER_CONTACT3SURNAME" maxlength="30" Columns="30"	runat="server"/>&nbsp;<em>(required)</em></td>
            </tr>
 
            <tr class="Controls">
              <th><strong>FIRST NAME</strong></th>
 
              <td><asp:TextBox id="STUDENT_CARER_CONTACT3FIRST_NAME" maxlength="30" Columns="30"	runat="server"/>&nbsp;<em>(required)</em></td>
            </tr>
 
            <tr class="Controls">
              <th><strong>RELATIONSHIP</strong></th>
 
              <td>
                <select id="STUDENT_CARER_CONTACT3RELATIONSHIP"  runat="server"></select>
 <em>(required)</em></td>
            </tr>
 
            <tr class="Controls">
              <th>HOME PHONE</th>
 
              <td><asp:TextBox id="STUDENT_CARER_CONTACT3HOME_PHONE" maxlength="20" Columns="20"	runat="server"/>&nbsp;<em>(at least one phone is required)</em></td>
            </tr>
 
            <tr class="Controls">
              <th>WORK PHONE</th>
 
              <td><asp:TextBox id="STUDENT_CARER_CONTACT3WORK_PHONE" maxlength="20" Columns="20"	runat="server"/></td>
            </tr>
 
            <tr class="Controls">
              <th>MOBILE</th>
 
              <td><asp:TextBox id="STUDENT_CARER_CONTACT3MOBILE" maxlength="20" Columns="20"	runat="server"/></td>
            </tr>
 
            <tr class="Controls">
              <th><strong>EMAIL ADDRESS</strong></th>
 
              <td><asp:TextBox id="STUDENT_CARER_CONTACT3EMAIL" maxlength="250" Columns="45"	runat="server"/>&nbsp;&nbsp;<em>(required to access Portal)</em></td>
            </tr>
 
            <tr class="Controls">
              <th>LAST ALTERED BY</th>
 
              <td><asp:Literal id="STUDENT_CARER_CONTACT3LAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_CARER_CONTACT3LAST_ALTERED_DATE" runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_CARER_CONTACT3lblCARER_ID" runat="server"/></td>
            </tr>
 
            <tr class="Bottom">
              <td colspan="2" align="right">
                <input id='STUDENT_CARER_CONTACT3Button_Insert' type="submit" class="Button" value="Add Carer" OnServerClick='STUDENT_CARER_CONTACT3_Insert' runat="server"/>
                <input id='STUDENT_CARER_CONTACT3Button_Update' type="submit" class="Button" value="Update" OnServerClick='STUDENT_CARER_CONTACT3_Update' runat="server"/>
                <input id='STUDENT_CARER_CONTACT3Button_Delete' type="submit" class="Button" value="Unlink Carer B from this Student" OnServerClick='STUDENT_CARER_CONTACT3_Delete' runat="server"/>
                <input id='STUDENT_CARER_CONTACT3Button_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_CARER_CONTACT3_Cancel' runat="server"/></td>
            </tr>
          </table>
          
  <input id="STUDENT_CARER_CONTACT3Hidden_STUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="STUDENT_CARER_CONTACT3Hidden_LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="STUDENT_CARER_CONTACT3Hidden_CarerId" type="hidden"  runat="server"/>
  
  <input id="STUDENT_CARER_CONTACT3Hidden_DuperCarer" type="hidden"  runat="server"/>
  </td>
      </tr>
    </table>
  </div>



  </span>
  <br>

  <span id="ListSchoolSupervisorsHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>List of Supervisors for this Student's School / Group</th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="ListSchoolSupervisorsError" visible="False" runat="server">
  
          <tr class="Error">
            <td><asp:Label ID="ListSchoolSupervisorsErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <td>
              <div class="radio-supervisors">
                <asp:RadioButtonList id="ListSchoolSupervisorscarer_id_SS"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/>
              </div>
            </td>
          </tr>
 
          <tr class="Bottom">
            <td align="right">
              <p>&nbsp; 
              <input id='ListSchoolSupervisorsButton_Update' type="submit" class="Button" value="Use Selected Supervisor" OnServerClick='ListSchoolSupervisors_Update' runat="server"/>&nbsp; 
              <input id='ListSchoolSupervisorsButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='ListSchoolSupervisors_Cancel' runat="server"/></p>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  

  <span id="STUDENT_CARER_CONTACT4Holder" runat="server">
    


  <table cellspacing="0" cellpadding="0" width="50%" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Add/Edit Supervisor</th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="STUDENT_CARER_CONTACT4Error" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="STUDENT_CARER_CONTACT4ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>TITLE</th>
 
            <td>
              <select id="STUDENT_CARER_CONTACT4TITLE"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th><strong>SURNAME</strong></th>
 
            <td><asp:TextBox id="STUDENT_CARER_CONTACT4SURNAME" maxlength="30" Columns="30" autocomplete="off"	runat="server"/>&nbsp;<em>(required)&nbsp;</em> 
              <div id="STUDENT_CARER_CONTACT4SURNAME_choices" style="DISPLAY: none">
              </div>
            </td>
          </tr>
 
          <tr class="Controls">
            <th><strong>FIRST NAME</strong></th>
 
            <td><asp:TextBox id="STUDENT_CARER_CONTACT4FIRST_NAME" maxlength="30" Columns="30"	runat="server"/>&nbsp;<em>(required)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>POSITION&nbsp;</th>
 
            <td>
              <select id="STUDENT_CARER_CONTACT4SUPERVISOR_POSITION"  runat="server"></select>
 &nbsp;&nbsp;<br>
              <asp:TextBox id="STUDENT_CARER_CONTACT4SUPERVISOR_POSITION_OTHER" maxlength="50" Columns="30"	runat="server"/>&nbsp;<em>(if 'Other')</em></td>
          </tr>
 
          <tr class="Controls">
            <th>WORK PHONE</th>
 
            <td><asp:TextBox id="STUDENT_CARER_CONTACT4WORK_PHONE" maxlength="20" Columns="20"	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>MOBILE</th>
 
            <td><asp:TextBox id="STUDENT_CARER_CONTACT4MOBILE" maxlength="20" Columns="20"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th><strong>EMAIL</strong></th>
 
            <td><asp:TextBox id="STUDENT_CARER_CONTACT4EMAIL" maxlength="250" Columns="45"	runat="server"/>&nbsp;<em>(required to access Portal)</em></td>
          </tr>
 
          <tr class="Controls">
            <th>LAST ALTERED BY</th>
 
            <td><asp:Literal id="STUDENT_CARER_CONTACT4LAST_ALTERED_BY" runat="server"/>&nbsp;/ <asp:Literal id="STUDENT_CARER_CONTACT4LAST_ALTERED_DATE" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Supervisor Type&nbsp;</th>
 
            <td>&nbsp; 
              <select id="STUDENT_CARER_CONTACT4RELATIONSHIP"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">
              <input id='STUDENT_CARER_CONTACT4Button_Insert' type="submit" class="Button" value="Add Supervisor" OnServerClick='STUDENT_CARER_CONTACT4_Insert' runat="server"/>
              <input id='STUDENT_CARER_CONTACT4Button_Update' type="submit" class="Button" value="Update" OnServerClick='STUDENT_CARER_CONTACT4_Update' runat="server"/>
              <input id='STUDENT_CARER_CONTACT4Button_Delete' type="submit" class="Button" value="Delete" OnServerClick='STUDENT_CARER_CONTACT4_Delete' runat="server"/>
              <input id='STUDENT_CARER_CONTACT4Button_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_CARER_CONTACT4_Cancel' runat="server"/></td>
          </tr>
        </table>
        
  <input id="STUDENT_CARER_CONTACT4Hidden_LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="STUDENT_CARER_CONTACT4Hidden_NewCarerID" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>



  </span>
  &nbsp;<br>
&nbsp;<br>
<br>

  <span id="STUDENT_CARER_CONTACT_EMERGENCY_EDITHolder" runat="server">
    


  <table class="MainTable" cellspacing="0" cellpadding="0" width="50%" border="0" allign="center">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Add/Edit EMERGENCY&nbsp; CONTACT </th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="STUDENT_CARER_CONTACT_EMERGENCY_EDITError" visible="False" runat="server">
  
          <tr id="STUDENT_CARER_CONTACT_EMERGENCY_EDITErrorBlock" class="Error">
            <td colspan="2"><asp:Label ID="STUDENT_CARER_CONTACT_EMERGENCY_EDITErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>FIRST NAME</th>
 
            <td><asp:TextBox id="STUDENT_CARER_CONTACT_EMERGENCY_EDITFIRST_NAME" maxlength="30" Columns="30"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>SURNAME</th>
 
            <td><asp:TextBox id="STUDENT_CARER_CONTACT_EMERGENCY_EDITSURNAME" maxlength="30" Columns="30"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>HOME PHONE</th>
 
            <td><asp:TextBox id="STUDENT_CARER_CONTACT_EMERGENCY_EDITHOME_PHONE" maxlength="20" Columns="20"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>MOBILE</th>
 
            <td><asp:TextBox id="STUDENT_CARER_CONTACT_EMERGENCY_EDITMOBILE" maxlength="20" Columns="20"	runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>RELATIONSHIP</th>
 
            <td><asp:TextBox id="STUDENT_CARER_CONTACT_EMERGENCY_EDITSUPERVISOR_POSITION_OTHER" maxlength="50" Columns="50"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td style="TEXT-ALIGN: right" colspan="2">
              <input id='STUDENT_CARER_CONTACT_EMERGENCY_EDITButton_Insert' type="submit" class="Button" value="Add" OnServerClick='STUDENT_CARER_CONTACT_EMERGENCY_EDIT_Insert' runat="server"/>
              <input id='STUDENT_CARER_CONTACT_EMERGENCY_EDITButton_Update' type="submit" title="test" class="Button" value="Update" OnServerClick='STUDENT_CARER_CONTACT_EMERGENCY_EDIT_Update' runat="server"/>
              <input id='STUDENT_CARER_CONTACT_EMERGENCY_EDITButton_Delete' type="submit" class="Button" value="Delete" OnServerClick='STUDENT_CARER_CONTACT_EMERGENCY_EDIT_Delete' runat="server"/>
              <input id='STUDENT_CARER_CONTACT_EMERGENCY_EDITButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_CARER_CONTACT_EMERGENCY_EDIT_Cancel' runat="server"/></td>
          </tr>
        </table>
        
  <input id="STUDENT_CARER_CONTACT_EMERGENCY_EDITHidden_LAST_ALTERED_BY" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>



  </span>
  <br>

</form>
</body>
</html>

<!--End ASPX page-->

