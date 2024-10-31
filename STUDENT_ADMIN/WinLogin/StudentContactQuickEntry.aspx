<%@ Page language="vb" ResponseEncoding ="windows-1252"%>
<%@Import Namespace="System.Web.Security" %>
<script language="vb" runat="server">

Sub Page_Load()
' add user to label, Hidden_STAFF_ID, and LAST_ALTERED_BY
	dim username as string = User.Identity.Name.Replace("DECV\", "").ToUpper
'debug
if (username="DECV_DEVELOPMENT") then
	username = "EAFFLECK"
end if
	Me.QuickEnterFormLabel1.Text = username
	Me.QuickEnterFormhidden_STAFFID.Value = username 
	Me.QuickEnterFormLAST_ALTERED_BY.Value = username 
End Sub
</script>

<html>
<head>
<meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title></title>

<meta content="CodeCharge Studio 4.1.00.032" name="GENERATOR">
<link href="../Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">

<script language="JavaScript" type="text/javascript">

function page_OnLoad()
{
    var result;
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

    return result;
}


// do the page resizing
page_OnLoad(); 

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
        <tr class="Error"> 
            <td colspan="2"><div id="QuickEnterFormError" class="Error" style="display:none"></div></td> 
          </tr>

  
          <tr class="Controls">
            <th>Who?</th>
 
            <td><asp:TextBox id="QuickEnterFormtext_Who" Columns="40"	runat="server"/>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>How?</th>
 
            <td>
              <asp:RadioButtonList id="QuickEnterFormCOMMENT_TYPE"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server">
		<asp:ListItem Value="CONTACT_PHONE">Phone</asp:ListItem>
		<asp:ListItem Value="CONTACT_EMAIL">Email</asp:ListItem>
		<asp:ListItem Value="CONTACT_POST">Paper/Post</asp:ListItem>
		<asp:ListItem Value="CONTACT_VISITED">Visited / In person</asp:ListItem>
	      </asp:RadioButtonList></td> 
          </tr>
 
          <tr class="Controls">
            <th>Why?</th>
 
            <td>
<asp:TextBox id="QuickEnterFormCOMMENT_TEXT" rows="4" Columns="30" TextMode="MultiLine"	runat="server"/>
</td> 
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">&nbsp; 
              <input id='QuickEnterFormButton_Insert' class="Button" type="button" value="Add Comment"></td> 
          </tr>
 
        </table>
 
  <input id="QuickEnterFormSTUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="QuickEnterFormLAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="QuickEnterFormHidden_STAFFID" type="hidden"  runat="server"/>
  </td> 
    </tr>
 
  </table>

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
                                $(this).css('background-image','url(../images/success.png)');
                                $(this).dequeue();})
                        .delay(200)
                        .fadeOut(500);
        // and reset field
        $('QuickEnterFormtext_Who').val('').focus();
        return true;
}


 // ERA: nice animations on save
//        $('<div class="overlay"></div>').appendTo('#QuickEnterFormHolder').show();
//        window.setTimeout("result = true;",4000);
//

jQuery(document).ready(function () {
            $('#QuickEnterFormtext_Who').val('').focus();
            $('#QuickEnterFormtext_Who').autocomplete({
                    minLength:3
                    , source: "../services/getStudentQuickContactDetails.aspx"
                    , select: function(event, ui) {
                            if(ui.item) {
                                    $("#QuickEnterFormSTUDENT_ID").val(ui.item.id.toString());
                            }
                    }
            });
	    //apply the AJAX to the Insert button
            $("#QuickEnterFormButton_Insert").click(function() {
                var errormsg = "";
                var errorflag = 0;
                if ($("#QuickEnterFormSTUDENT_ID").val() == "") {
                    errorflag += 1;
                    errormsg += "Enter a Student ID (WHO?)<br/>";
                }
                if ($("[name='QuickEnterFormCOMMENT_TYPE']:checked").val() == undefined) {
                    errorflag += 1;
                    errormsg += "Select a Comment Type (HOW?)<br>";
                }
                if ($("#QuickEnterFormCOMMENT_TEXT").val() == "") {
                    errorflag += 1;
                    errormsg += "Enter a comment (WHY?)<br>";
                }
                if ($("#QuickEnterFormLAST_ALTERED_BY").val() == "") {
                    errorflag += 1;
                    errormsg += "Teacher is blank?<br>";
                }
                if (errorflag == 0) {
                    // submit via ajax function
		    $('<div class="overlay"></div>').appendTo('#QuickEnterFormHolder').fadeIn(300).delay(1000).queue(function () {
                                $(this).css('background-image','url(../images/success.png)');
                                $(this).dequeue();}).delay(500).fadeOut(500);
                    //$("#QuickEnterFormError").text("Sending!").show();
                    // do the form submission to the insert to db service
                    //serialize the form controls ready for AJAX sending pg 263

                    $('#QuickEnterFormError').load('insertQuickFormComment.ashx'
                            , $("#QuickEnterFormSTUDENT_ID, [name='QuickEnterFormCOMMENT_TYPE']:checked, #QuickEnterFormCOMMENT_TEXT, #QuickEnterFormLAST_ALTERED_BY").serialize()
			// callbacks to clear fields and put focus back in WHO
				, function() {
					$('#QuickEnterFormSTUDENT_ID').val('');
					$('#QuickEnterFormtext_Who').val('').focus();
				}
                            );

		    
                    return true;
                } else {
                    $("#QuickEnterFormError").html(errormsg).fadeIn(500);
                    return false;
                }
            });

        });    // end of jQuery function

    
</script>


</form>
</body>
</html>
