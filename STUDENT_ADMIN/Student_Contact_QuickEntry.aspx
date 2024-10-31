<!--ASPX page @1-50F4A670-->
    <%@ Page language="vb" CodeFile="Student_Contact_QuickEntry.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_Contact_QuickEntry.Student_Contact_QuickEntryPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_Contact_QuickEntry" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 4.1.00.032" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title></title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-12DCE9BA
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_QuickEnterForm_Button_Insert_OnClick @5-4FBE80E1
function page_QuickEnterForm_Button_Insert_OnClick()
{
    var result;
//End page_QuickEnterForm_Button_Insert_OnClick

//Custom Code @16-2A29BDB7
// -------------------------
    // ERA: nice animations on load and save
                $('<div class="overlay"></div>')
                        .appendTo('#QuickEnterFormHolder')
                        .fadeIn(1000)
                        .delay(1000)
                        .queue(function () {
                                $(this).css('background-image','url(images/success.png)');
                                $(this).dequeue();})
                        .delay(400)
                        .fadeOut(800);
        result = true; 
    // -------------------------
//End Custom Code

//Close page_QuickEnterForm_Button_Insert_OnClick @5-BC33A33A
    return result;
}
//End Close page_QuickEnterForm_Button_Insert_OnClick

//page_QuickEnterForm_text_Who_OnKeyPress @14-5D33E8AE
function page_QuickEnterForm_text_Who_OnKeyPress()
{
    var result;
//End page_QuickEnterForm_text_Who_OnKeyPress

//Custom Code @18-2A29BDB7
    // -------------------------
    // check first character and handle autocomplete and other bits

        // get first char in string - stripping out anything not alpha, number, or space, colon

        // if first char=":" then ignore others, as will be special

        // if first char is number then source is getStudentContacts_ByStudentID

        // otherwise assume it is character and source is getStudentContacts_ByFirstName

    // -------------------------
//End Custom Code

//Close page_QuickEnterForm_text_Who_OnKeyPress @14-BC33A33A
    return result;
}
//End Close page_QuickEnterForm_text_Who_OnKeyPress

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//Custom Code @17-2A29BDB7
    // -------------------------
    // change to small window

        if (this.name!='QuickEntry'){ 
                //var myWin = window.open(location.href,'QuickEntry','fullscreen,scrollbars') 
                var myWin = window.open(location.href, 'QuickEntry', 'location=no,toolbar=no,menubar=no,directories=no,status=no,resizable=yes,scrollbars=no', false);
        }
        var w = 460; var h = 310;
        if (myWin) {
                myWin.moveTo((screen.width-w), (screen.height-h)); 
                myWin.resizeTo(w,h);
                window.opener='x';
                window.open('', '_self', '');
                window.close();
                //self.close();
        }
        result = true;
    // -------------------------
//End Custom Code

//Set Focus @15-4AD5711B
    if (theForm.QuickEnterFormtext_Who) theForm.QuickEnterFormtext_Who.focus();
//End Set Focus

//Close page_OnLoad @1-BC33A33A
    return result;
}
//End Close page_OnLoad

//page_QuickEnterForm_Button_Cancel_OnClick @6-78AAF03B
function page_QuickEnterForm_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_QuickEnterForm_Button_Cancel_OnClick

//bind_events @1-D96F4D66
function bind_events() {
    addEventHandler("QuickEnterFormtext_Who","keypress",page_QuickEnterForm_text_Who_OnKeyPress);
    addEventHandler("QuickEnterFormButton_Insert","click",page_QuickEnterForm_Button_Insert_OnClick);
    addEventHandler("QuickEnterFormButton_Cancel","click",page_QuickEnterForm_Button_Cancel_OnClick);
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

</head>
<body>
<form runat="server">



  <span id="QuickEnterFormHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Quick Enter Student Contact</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="QuickEnterFormError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="QuickEnterFormErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>Who?</th>
 
            <td><asp:TextBox id="QuickEnterFormtext_Who" Columns="40"	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>How?</th>
 
            <td>
              <asp:RadioButtonList id="QuickEnterFormCOMMENT_TYPE"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
          </tr>
 
          <tr class="Controls">
            <th>Why?</th>
 
            <td>
<asp:TextBox id="QuickEnterFormCOMMENT" rows="4" Columns="30" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2"><input id="Button1" onclick="testSubmit();" type="button" value="Demo Save" name="Button1"/>&nbsp; 
              <input id='QuickEnterFormButton_Cancel' class="Button" type="submit" value="Cancel" OnServerClick='QuickEnterForm_Cancel' runat="server"/>
              <input id='QuickEnterFormButton_Insert' class="Button" type="submit" value="Add Comment" OnServerClick='QuickEnterForm_Insert' runat="server"/></td>
          </tr>
        </table>
        
  <input id="QuickEnterFormSTUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="QuickEnterFormLAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="QuickEnterFormLAST_ALTERED_DATE" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>



  </span>
  <br>
<script src="js/jquery_min.js" type="text/javascript" charset="utf-8"></script>
<script type="text/javascript">
function testSubmit() {
        $('<div class="overlay"></div>')
                        .appendTo('#QuickEnterFormHolder')
                        .fadeIn(1000)
                        .delay(2000)
                        .queue(function () {
                                $(this).css('background-image','url(images/success.png)');
                                $(this).dequeue();})
                        .delay(400)
                        .fadeOut(1000);
        // and reset field
        $('QuickEnterFormtext_Who').val('').focus();
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

