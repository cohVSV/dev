<!--ASPX page @1-9823B592-->
    <%@ Page language="vb" CodeFile="Student_Contact_QuickEntry.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.WinLogin.Student_Contact_QuickEntry.Student_Contact_QuickEntryPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.WinLogin.Student_Contact_QuickEntry" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 4.1.00.032" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title></title>


<link href="../Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-F2AF7622
</script>
<script language="JavaScript" src='../ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Include User Scripts @1-E631D979
</script>
<script language="JavaScript" src="../js/pt/prototype.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include User Scripts

//page_QuickEnterForm_Button_Insert_OnClick @5-4FBE80E1
function page_QuickEnterForm_Button_Insert_OnClick()
{
    var result;
//End page_QuickEnterForm_Button_Insert_OnClick

//Custom Code @33-2A29BDB7
    // -------------------------
        // ERA: nice animations on save
        $('<div class="overlay"></div>').appendTo('#QuickEnterFormHolder').show();
        window.setTimeout("result = true;",4000);
        
    // -------------------------
//End Custom Code

//Close page_QuickEnterForm_Button_Insert_OnClick @5-BC33A33A
    return result;
}
//End Close page_QuickEnterForm_Button_Insert_OnClick

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
          var w = 480; var h = 370;
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

//Initialize QuickEnterFormUpdateDB1_insertCommentQuickEntry @34-68D7C9A7
function QuickEnterFormUpdateDB1_insertCommentQuickEntry_start(sender) {
    var reqBody = "";
    var toSend = new Object();
    if ($("QuickEnterForm") && $("QuickEnterForm").ccsQuickEnterFormUpdateDB1_insertCommentQuickEntryData) {
        toSend = $("QuickEnterForm").ccsQuickEnterFormUpdateDB1_insertCommentQuickEntryData;
    }
    toSend["CtrlCOMMENT"] = getSameLevelCtl("QuickEnterFormCOMMENT", sender).value;
    toSend["CtrlSTUDENT_ID"] = getSameLevelCtl("QuickEnterFormSTUDENT_ID", sender).value;
    toSend["CtrlLAST_ALTERED_BY"] = getSameLevelCtl("QuickEnterFormLAST_ALTERED_BY", sender).value;
    toSend["CtrlCOMMENT_TYPE"] = getSameLevelCtl("QuickEnterFormCOMMENT_TYPE", sender).value;
    reqBody = Object.toQueryString(toSend);
    url = "?callbackControl=QuickEnterFormUpdateDB1_insertCommentQuickEntry";
    new Ajax.Request(url, {
        method: 'post',
        postBody: reqBody,
        onSuccess: function(transport) {
        }, 
        onFailure: function(transport) {
        }
    });
}
//End Initialize QuickEnterFormUpdateDB1_insertCommentQuickEntry

//bind_events @1-7911A88C
function bind_events() {
    addEventHandler("QuickEnterForm", "submit", QuickEnterFormUpdateDB1_insertCommentQuickEntry_start);
    addEventHandler("QuickEnterFormButton_Insert","click",page_QuickEnterForm_Button_Insert_OnClick);
    addEventHandler("QuickEnterFormButton_Cancel","click",page_QuickEnterForm_Button_Cancel_OnClick);
    page_OnLoad();
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

//End CCS script
</script>
<style type="text/css">
<!--
.overlay {
        background: black no-repeat 50% 50%;
                background-image: url(../images/ajax_loader_bigwhite.gif);
        display: none;
        height: 100%;
        left: 0;
        opacity: .9;
        position: absolute;
        top: 0;
        width: 100%;
    }
.ui-autocomplete-loading {
        background: white url('../images/ajax_loader_smallblue.gif') right center no-repeat;
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
            <td class="HeaderLeft"><img src="../Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Quick Enter Student Contact&nbsp; &nbsp;<asp:Literal id="QuickEnterFormLabel1" runat="server"/></th>
 
            <td class="HeaderRight"><img src="../Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
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
            <td align="right" colspan="2">&nbsp; 
              <input id='QuickEnterFormButton_Cancel' class="Button" type="submit" value="Cancel" OnServerClick='QuickEnterForm_Cancel' runat="server"/>
              <input id='QuickEnterFormButton_Insert' class="Button" type="submit" value="Add Comment" OnServerClick='QuickEnterForm_Insert' runat="server"/></td> 
          </tr>
 
        </table>
 
  <input id="QuickEnterFormSTUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="QuickEnterFormLAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="QuickEnterFormHidden_STAFFID" type="hidden"  runat="server"/>
  </td> 
    </tr>
 
  </table>


<!-- BEGINF UpdateDB UpdateDB1_insertCommentQuickEntry --><CC:AttributeBinder runat="server" Name="postSnippet" ContainerId="QuickEnterFormHolder"/><!-- ENDF UpdateDB UpdateDB1_insertCommentQuickEntry -->
  </span>
  <br>
<link href="../js/css/ui-lightness/jquery-ui-1.8.8.custom.css" type="text/css" rel="stylesheet">
<script src="../js/jquery_min.js" type="text/javascript" charset="utf-8"></script>
<script src="../js/jquery-ui-1.8.8.custom.min.js" type="text/javascript" charset="utf-8"></script>
<script type="text/javascript">
function animateClick() {
        $('<div class="overlay"></div>')
                        .appendTo('#QuickEnterFormHolder')
                        .fadeIn(1500)
                        .delay(1000)
                        .queue(function () {
                                $(this).css('background-image','url(images/success.png)');
                                $(this).dequeue();})
                        .delay(200)
                        .fadeOut(500);
        // and reset field
        $('QuickEnterFormtext_Who').val('').focus();
        return true;
}

jQuery(document).ready(function () {
                                $('QuickEnterFormtext_Who').val('').focus();
                $('#QuickEnterFormtext_Who').autocomplete({
                        minLength:3
                        , source: "../services/getStudentQuickContactDetails.aspx"
                        , select: function(event, ui) {
                                if(ui.item) {
                                        $("#QuickEnterFormSTUDENT_ID").val(ui.item.id.toString());
                                }
                        }
                });


});

</script>
<style type="text/css">
<!--
.overlay {
        background: black no-repeat 50% 50%;
                background-image: url(../images/ajax_loader_bigwhite.gif);
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

