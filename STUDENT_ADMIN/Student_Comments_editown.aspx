<!--ASPX page @1-B8B68D6B-->
    <%@ Page language="vb" CodeFile="Student_Comments_editown.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_Comments_editown.Student_Comments_editownPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_Comments_editown" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 4.1.00.032" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student_Comments_editown</title>


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
<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-12DCE9BA
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_EditComments_Button_Delete_OnClick @7-7AC0F529
function page_EditComments_Button_Delete_OnClick()
{
    var result;
//End page_EditComments_Button_Delete_OnClick

//Confirmation Message @8-4F6CD15C
    return confirm('Delete Comment? \n(this cannot be recovered)');
//End Confirmation Message

//Close page_EditComments_Button_Delete_OnClick @7-BC33A33A
    return result;
}
//End Close page_EditComments_Button_Delete_OnClick

//page_EditComments_OnSubmit @5-78241B10
function page_EditComments_OnSubmit()
{
    var result;
//End page_EditComments_OnSubmit

//Custom Code @32-2A29BDB7
    // -------------------------
    //15-Sept-2016|EA| check for RESTRICTED Comment and alert to change portal access if needed (unfuddle #707)
  	if (theForm.EditCommentslbSpecialCommentType.value =='RESTRICTED') {
alert('For a RESTRICTED comment, manually update Portal access to [No] if necessary.');
}
result = true;
    // -------------------------
//End Custom Code

//Close page_EditComments_OnSubmit @5-BC33A33A
    return result;
}
//End Close page_EditComments_OnSubmit

//page_EditComments_Button_Cancel_OnClick @9-E1E8FB6B
function page_EditComments_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_EditComments_Button_Cancel_OnClick

//bind_events @1-61717E13
function bind_events() {
    addEventHandler("<%= Page.Form.ClientID %>","submit",page_EditComments_OnSubmit);
    addEventHandler("EditCommentsButton_Delete","click",page_EditComments_Button_Delete_OnClick);
    addEventHandler("EditCommentsButton_Cancel","click",page_EditComments_Button_Cancel_OnClick);
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


<p align="center"><a id="Link_Backtosummary" href="" class="Button" runat="server"  >Back to Summary</a>|&nbsp;&nbsp;<a id="Link_BacktoPastoralList" href="" class="Button" runat="server"  >Back to Pastoral Students List</a> </p>
<p align="center">

  <span id="EditCommentsHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Edit Comment </th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="EditCommentsError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="EditCommentsErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>STUDENT ID</th>
 
            <td><asp:Literal id="EditCommentslblSTUDENT_ID" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>COMMENT 
            <div id="maxchar_comment">
              500 characters allowed 
            </div>
            </th>
 
            <td>
<asp:TextBox id="EditCommentsCOMMENT" onkeyup="limitMaxLength(this,500,'maxchar_comment');" rows="5" Columns="50" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Controls">
            <th><asp:Literal id="EditCommentslblCommentType" runat="server"/>&nbsp;</th>
 
            <td>
              
              <select id="EditCommentslbSpecialCommentType"  Visible="False" runat="server"></select>
 &nbsp;&nbsp;</td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='EditCommentsButton_Update' class="Button" type="submit" value="Save Comment" OnServerClick='EditComments_Update' runat="server"/>
              <input id='EditCommentsButton_Delete' class="Button" type="submit" value="Delete Comment" OnServerClick='EditComments_Delete' runat="server"/>
              <input id='EditCommentsButton_Cancel' class="Button" type="submit" value="Cancel" OnServerClick='EditComments_Cancel' runat="server"/></td>
          </tr>
        </table>
        
  <input id="EditCommentshidden_LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="EditCommentshidden_LAST_ALTERED_DATE" type="hidden"  runat="server"/>
  
  <input id="EditCommentsACTIVE_STATUS" type="hidden"  runat="server"/>
  
  <input id="EditCommentsCOMMENT_TYPE" type="hidden"  runat="server"/>
  
  <input id="EditCommentsSTUDENT_ID" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>



  </span>
  <br>
</p>

</form>
</body>
</html>

<!--End ASPX page-->

