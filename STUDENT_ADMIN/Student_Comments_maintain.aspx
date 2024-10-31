<!--ASPX page @1-31A55275-->
    <%@ Page language="vb" CodeFile="Student_Comments_maintain.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Student_Comments_maintain.Student_Comments_maintainPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Student_Comments_maintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="StudentNamePlate" Src="StudentNamePlate.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Comments - Maintain</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
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
<style type="text/css">
<!--
.AlertRed       td  { font-weight: bold; background-color: #FF6666; vertical-align: left; text-align: left; border-top-width: 1px; border-top-color: #3D84CC; border-top-style: solid; border-right-width: 1px; border-right-color: #3D84CC; border-right-style: solid; padding-top: 4px; padding-right: 4px; padding-bottom: 4px; padding-left: 4px; }
.AlertGreen     td  { font-weight: bold; background-color: #66CC33; vertical-align: left; text-align: left; border-top-width: 1px; border-top-color: #3D84CC; border-top-style: solid; border-right-width: 1px; border-right-color: #3D84CC; border-right-style: solid; padding-top: 4px; padding-right: 4px; padding-bottom: 4px; padding-left: 4px; }
.CoordAmber     td  { font-weight: bold; background-color: #FF9933; vertical-align: left; text-align: left; border-top-width: 1px; border-top-color: #3D84CC; border-top-style: solid; border-right-width: 1px; border-right-color: #3D84CC; border-right-style: solid; padding-top: 4px; padding-right: 4px; padding-bottom: 4px; padding-left: 4px; }
.LightMauve     td  { font-weight: bold; background-color: #B3B3D7; vertical-align: left; text-align: left; border-top-width: 1px; border-top-color: #3D84CC; border-top-style: solid; border-right-width: 1px; border-right-color: #3D84CC; border-right-style: solid; padding-top: 4px; padding-right: 4px; padding-bottom: 4px; padding-left: 4px; }
.Pathways       td  { font-weight: bold; background-color: #038C9A; vertical-align: left; text-align: left; border-top-width: 1px; border-top-color: #3D84CC; border-top-style: solid; border-right-width: 1px; border-right-color: #3D84CC; border-right-style: solid; padding-top: 4px; padding-right: 4px; padding-bottom: 4px; padding-left: 4px; }
.Rollover       td  { font-weight: bold; background-color: #FF69B4; vertical-align: left; text-align: left; border-top-width: 1px; border-top-color: #3D84CC; border-top-style: solid; border-right-width: 1px; border-right-color: #3D84CC; border-right-style: solid; padding-top: 4px; padding-right: 4px; padding-bottom: 4px; padding-left: 4px; }
.Offshore       td  { font-weight: bold; background-color: #c4bc96; vertical-align: left; text-align: left; border-top-width: 1px; border-top-color: #3D84CC; border-top-style: solid; border-right-width: 1px; border-right-color: #3D84CC; border-right-style: solid; padding-top: 4px; padding-right: 4px; padding-bottom: 4px; padding-left: 4px; }
.autosave_saving  { font-weight: bold; color: #66CC33; }
-->
</style>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//page_STUDENT_COMMENT_lbCannedResponses_OnChange @97-947644D6
function page_STUDENT_COMMENT_lbCannedResponses_OnChange()
{
    var result;
//End page_STUDENT_COMMENT_lbCannedResponses_OnChange

//Custom Code @98-2A29BDB7
    // -------------------------
    // ERA: 21-June-2012|EA| add the selected comment to the COMMENT field.
        //      If Comment already has something then append to end (leading space) otherwise trailing space
        if (theForm.STUDENT_COMMENTlbCannedResponses.value !='') {
                if(theForm.STUDENT_COMMENTCOMMENT.value.length > 0) {
                theForm.STUDENT_COMMENTCOMMENT.value = theForm.STUDENT_COMMENTCOMMENT.value + ' ' + theForm.STUDENT_COMMENTlbCannedResponses.value;
        } else {
                        theForm.STUDENT_COMMENTCOMMENT.value = theForm.STUDENT_COMMENTlbCannedResponses.value + ' ';
                }
                theForm.STUDENT_COMMENTCOMMENT.focus();
    }
    // -------------------------
//End Custom Code

//Set Focus @99-AB2838AB
    if (theForm.STUDENT_COMMENTCOMMENT) theForm.STUDENT_COMMENTCOMMENT.focus();
//End Set Focus

//Close page_STUDENT_COMMENT_lbCannedResponses_OnChange @97-BC33A33A
    return result;
}
//End Close page_STUDENT_COMMENT_lbCannedResponses_OnChange

//page_STUDENT_COMMENT_OnSubmit @13-2C355D69
function page_STUDENT_COMMENT_OnSubmit()
{
    var result;
//End page_STUDENT_COMMENT_OnSubmit

//Custom Code @142-2A29BDB7
    // -------------------------
    //15-Sept-2016|EA| check for RESTRICTED Comment and alert to change portal access if needed (unfuddle #707)
        if (theForm.STUDENT_COMMENTlbSpecialCommentType.value =='RESTRICTED') {
alert('For a RESTRICTED comment, manually update Portal access to [No] if necessary.');
}
result = true;
    // -------------------------
//End Custom Code

//Close page_STUDENT_COMMENT_OnSubmit @13-BC33A33A
    return result;
}
//End Close page_STUDENT_COMMENT_OnSubmit

//page_STUDENT_COMMENT_Button_Cancel_OnClick @15-3BF1766F
function page_STUDENT_COMMENT_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_STUDENT_COMMENT_Button_Cancel_OnClick

//page_ProfilesPanel_Button_Cancel_OnClick @50-9F68870E
function page_ProfilesPanel_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_ProfilesPanel_Button_Cancel_OnClick

//bind_events @1-985E51AF
function bind_events() {
    addEventHandler("<%= Page.Form.ClientID %>","submit",page_STUDENT_COMMENT_OnSubmit);
    addEventHandler("STUDENT_COMMENTlbCannedResponses","change",page_STUDENT_COMMENT_lbCannedResponses_OnChange);
    addEventHandler("STUDENT_COMMENTButton_Cancel","click",page_STUDENT_COMMENT_Button_Cancel_OnClick);
    addEventHandler("ProfilesPanelButton_Cancel","click",page_ProfilesPanel_Button_Cancel_OnClick);
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


<p align="center">

	<asp:PlaceHolder id="Panel_MenuStudentMaintain" Visible="false" runat="server">
	<DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/>
	</asp:PlaceHolder>
	<a id="Link_Backtosummary" href="" class="Button" runat="server"  >Back to Summary</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a id="Link_BacktoPastoralList" href="" class="Button" runat="server"  >Back to Student Support Group List</a></p>
<p align="center"><DECV_PROD2007:StudentNamePlate id="StudentNamePlate" runat="server"/></p>
<p align="center">

  <span id="STUDENT_COMMENTHolder" runat="server">
    


    &nbsp; 
    <table cellspacing="0" cellpadding="0" width="70%" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Add Comment</th>
 
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
                        <th>STUDENT ID </th>
 
                        <td><asp:Literal id="STUDENT_COMMENTlblSTUDENT_ID" runat="server"/>&nbsp;<span class="autosave_saving">Saving…</span></td>
                    </tr>
 
                    <tr class="Controls">
                        <th>COMMENT 
                        <div id="maxchar_comment">
                            500 characters allowed 
                        </div>
                        <br>
                        <button class="autosave_restore">Retrieve Comment</button> <br>
                        <br>
                        <select id="STUDENT_COMMENTlbCannedResponses"  runat="server"></select>
 </th>
 
                        <td>
<asp:TextBox id="STUDENT_COMMENTCOMMENT" onkeyup="limitMaxLength(this,500,'maxchar_comment');" rows="5" Columns="50" TextMode="MultiLine"	runat="server"/>
</td>
                    </tr>
 
                    <tr class="Controls">
                        <th><asp:Literal id="STUDENT_COMMENTlblCommentType" runat="server"/></th>
 
                        <td>
                            
                            <select id="STUDENT_COMMENTlbSpecialCommentType"  runat="server"></select>
 &nbsp;&nbsp; 
                            
                            <select id="STUDENT_COMMENTlbSpecialCommentType1"  runat="server"></select>
 </td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="2" align="right">
                            <input id='STUDENT_COMMENTButton_Insert' type="submit" class="Button" value="Add Comment" OnServerClick='STUDENT_COMMENT_Insert' runat="server"/>
                            <input id='STUDENT_COMMENTButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='STUDENT_COMMENT_Cancel' runat="server"/></td>
                    </tr>
                </table>
                
  <input id="STUDENT_COMMENTSTUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="STUDENT_COMMENThidden_STATUS" type="hidden"  runat="server"/>
  
  <input id="STUDENT_COMMENTHidden_CommentType" type="hidden"  runat="server"/>
  </td>
        </tr>
    </table>



  </span>
  </p>
<p align="center">

  <span id="ProfilesPanelHolder" runat="server">
    


    <table cellspacing="0" cellpadding="0" width="70%" border="0">
        <tr>
            <td valign="top">
                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                        <th>Update Profiles for&nbsp;<asp:Literal id="ProfilesPanellabel_EnrolYear" runat="server"/></th>
 
                        <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                    </tr>
                </table>
 
                <table class="Record" cellspacing="0" cellpadding="0">
                    
  <asp:PlaceHolder id="ProfilesPanelError" visible="False" runat="server">
  
                    <tr class="Error">
                        <td colspan="5"><asp:Label ID="ProfilesPanelErrorLabel" runat="server"/></td>
                    </tr>
                    
  </asp:PlaceHolder>
  
                    <tr class="Controls">
                        <th>Student Profile Done?&nbsp;</th>
 
                        <th>&nbsp; 
                        <asp:RadioButtonList id="ProfilesPanelradio_IntakeInterview"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></th>
 
                        <th>&nbsp;</th>
 
                        <th>Pathways Profile Done?</th>
 
                        <td>
                            <asp:RadioButtonList id="ProfilesPanelradio_PathwaysProfile"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/></td>
                    </tr>
 
                    <tr class="Bottom">
                        <td colspan="5" align="right">
                            <input id='ProfilesPanelButton_Update' type="submit" class="Button" value="Update" OnServerClick='ProfilesPanel_Update' runat="server"/>
                            <input id='ProfilesPanelButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='ProfilesPanel_Cancel' runat="server"/></td>
                    </tr>
                </table>
                <em>Only change when Profiles are complete and put in Student Folder. Updating will add a Comment </em></td>
        </tr>
    </table>



  </span>
  </p>
<p align="center">

<asp:repeater id="Grid_DisplayComments_MyCommentsRepeater" OnItemCommand="Grid_DisplayComments_MyCommentsItemCommand" OnItemDataBound="Grid_DisplayComments_MyCommentsItemDataBound" runat="server">
  <HeaderTemplate>
	
<table id="Table_MyComments" cellspacing="0" cellpadding="0" width="70%" border="0">
    <tr>
        <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                    <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                    <th><asp:Literal id="Grid_DisplayComments_MyCommentsLabel_LogType" runat="server"/></th>
 
                    <th style="WIDTH: 400px; TEXT-ALIGN: right" nowrap align="right">
                    <div style="WIDTH: 380px; MARGIN: 9px" align="right">
                        Click to filter:&nbsp; <img id="CONTACT_PHONE" title="show Phone comments" class="filter_icon" name="CONTACT_PHONE" alt="show Phone comments" src="images/telephone.png">&nbsp;&nbsp; <img id="CONTACT_EMAIL" title="show Email comments" class="filter_icon" name="CONTACT_EMAIL" alt="show Email comments" src="images/email.png">&nbsp;&nbsp; <img id="CONTACT_POST" title="show Post comments" class="filter_icon" name="CONTACT_POST" alt="show Post comments" src="images/report.png">&nbsp;&nbsp; <img id="CONTACT_VISITED" title="show Visited comments" class="filter_icon" name="CONTACT_VISITED" alt="show Visited comments" src="images/user_suit.png">&nbsp;&nbsp; <img id="CONTACT_SMS" title="show SMS comments" class="filter_icon" name="CONTACT_SMS" alt="show SMS comments" src="images/phone_sound.png">&nbsp;&nbsp; <img id="CONTACT_OTHER" title="show Other comments" class="filter_icon" name="CONTACT_OTHER" alt="show Other comments" src="images/cup.png">&nbsp;&nbsp;<img id="toggle_Comments_All" title="show All comments" class="filter_icon" name="toggle_Comments_All" alt="show All comments" src="images/asterisk_yellow.png">
                    </div>
                    </th>
 
                    <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                </tr>
            </table>
 
            <div align="center">
                <table id="STUDENT_COMMENTS_table" class="Grid" cellspacing="0" cellpadding="0">
                    <tr class="Caption">
                        <th></th>
 
                        <th>COMMENT</th>
 
                        <th class="filter-column">TYPE</th>
 
                        <th>
                        <p align="center">LAST ALTERED BY</p>
                        </th>
 
                        <th>
                        <p align="center">LAST ALTERED DATE</p>
                        </th>
                    </tr>
 
                    
  </HeaderTemplate>
  <ItemTemplate>
                    <tr id="displaycomments_row" runat="server">
                        <td><a id="Grid_DisplayComments_MyCommentslink_editcomment" href="" runat="server"  >edit</a></td> 
                        <td><asp:Literal id="Grid_DisplayComments_MyCommentsCOMMENT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_DisplayComments_MyCommentsItem)).COMMENT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                        <td><asp:Literal id="Grid_DisplayComments_MyCommentsCOMMENT_TYPE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_DisplayComments_MyCommentsItem)).COMMENT_TYPE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
                        <td>
                            <div align="center">
                                <asp:Literal id="Grid_DisplayComments_MyCommentsLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_DisplayComments_MyCommentsItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp; 
                            </div>
                        </td> 
                        <td nowrap>
                            <div align="center">
                                <asp:Literal id="Grid_DisplayComments_MyCommentsLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_DisplayComments_MyCommentsItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;&nbsp; 
                            </div>
                        </td>
                    </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
                    
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
                    <tr class="NoRecords">
                        <td colspan="5">No Communications found.</td>
                    </tr>
                    
  </asp:PlaceHolder>

                </table>
            </div>
        </td>
    </tr>
</table>

  </FooterTemplate>
</asp:repeater>
</p>
<p align="center">

<asp:repeater id="Grid_DisplayCommentsRepeater" OnItemCommand="Grid_DisplayCommentsItemCommand" OnItemDataBound="Grid_DisplayCommentsItemDataBound" runat="server">
  <HeaderTemplate>
	
<table id="Table_PublicComments" cellspacing="0" cellpadding="0" width="70%" border="0">
    <tr>
        <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                    <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
                    <th>Public Comments</th>
 
                    <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
                </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
                <tr class="Caption">
                    <th>&nbsp;</th>
 
                    <th>COMMENT</th>
 
                    <th>&nbsp;TYPE</th>
 
                    <th>
                    <p align="center">LAST ALTERED BY</p>
                    </th>
 
                    <th>
                    <p align="center">LAST ALTERED DATE</p>
                    </th>
                </tr>
 
                
  </HeaderTemplate>
  <ItemTemplate>
                <tr id="displaycomments_row" runat="server">
                    <td>&nbsp;<a id="Grid_DisplayCommentslink_editcomment" href="" runat="server"  >edit</a></td> 
                    <td><asp:Literal id="Grid_DisplayCommentsCOMMENT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_DisplayCommentsItem)).COMMENT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
                    <td>&nbsp;<asp:Literal id="Grid_DisplayCommentsCOMMENT_TYPE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_DisplayCommentsItem)).COMMENT_TYPE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/></td> 
                    <td>
                        <div align="center">
                            <asp:Literal id="Grid_DisplayCommentsLAST_ALTERED_BY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_DisplayCommentsItem)).LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp; 
                        </div>
                    </td> 
                    <td nowrap>
                        <div align="center">
                            <asp:Literal id="Grid_DisplayCommentsLAST_ALTERED_DATE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_DisplayCommentsItem)).LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;&nbsp; 
                        </div>
                    </td>
                </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
                
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
                <tr class="NoRecords">
                    <td colspan="5">No Comments found.</td>
                </tr>
                
  </asp:PlaceHolder>

                <tr class="Footer">
                    <td colspan="5">
                        
<CC:Navigator id="Navigator1Navigator" MaxPage="<%# Grid_DisplayCommentsData.PagesCount%>" PageSize="<%# Grid_DisplayCommentsData.RecordsPerPage%>" PageNumber="<%# Grid_DisplayCommentsData.PageNumber%>" runat="server">&nbsp; 
                        Per page: 
                        <CC:PageSizer AutoPostBack="true" runat="server" />
 
                        <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="Navigator1First" runat="server"><img border="0" src="Styles/Blueprint/Images/en/ButtonFirst.gif"></asp:LinkButton> </CC:NavigatorItem>
                        <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="Navigator1Prev" runat="server"><img border="0" src="Styles/Blueprint/Images/en/ButtonPrev.gif"></asp:LinkButton> </CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %>&nbsp;of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
                        <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="Navigator1Next" runat="server"><img border="0" src="Styles/Blueprint/Images/en/ButtonNext.gif"></asp:LinkButton> </CC:NavigatorItem>
                        <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="Navigator1Last" runat="server"><img border="0" src="Styles/Blueprint/Images/en/ButtonLast.gif"></asp:LinkButton> </CC:NavigatorItem></CC:Navigator>
</td>
                </tr>
            </table>
        </td>
    </tr>
</table>

  </FooterTemplate>
</asp:repeater>
<br>
<br>
</p>
<script language="JavaScript" src="js/jquery_min.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/jquery.cookie.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/jquery.autosave.pack.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
    // -------------------------
    //9-June-2011|EA| added autosave option
        $('textarea#STUDENT_COMMENTCOMMENT').autosave({'cookieCharMaxSize': 550, 'cookieExpiryLength':10});
        
         // hide some of the Contact comments (unfuddle #638 and other requests)
                // using same code as StudentSummary let's show/hide all comments after first 5
        var numShown = 16; // Initial rows shown & index
        var numMore = 10; // Increment
        var numRows = $('#STUDENT_COMMENTS_table').find('tr').length; // Total # rows

        // Hide rows and add clickable div
        $('#STUDENT_COMMENTS_table')
              .find('tr:gt(' + (numShown - 1) + ')').hide().end()
              .after('<div id="more" class="Button"><br>Show <span>' + numMore + '</span> More Comments<br></div>');

        $('#more').click(function(){
              numShown = numShown + numMore;
              // no more show more if done
              if ( numShown >= numRows ) $('#more').remove();
              // change rows remaining if less than increment
              if ( numRows - numShown < numMore ) $('#more span').html(numRows - numShown);
                 $('#STUDENT_COMMENTS_table').find('tr:lt('+numShown+')').show();
        })
        // doing the above to hide for 'all' comments, and then the filters below will show all of the comments
        // for the selected type otherwise we might accidently hide some rows if filters are clicked.
        

        // ERA: using jquery, attach the toggles to the toggle_Census and toggle_Equipment links
        $('img#toggle_Comments_All').click(function() {
            $('table#Table_MyComments').find('tr.Row').show();
        });


        $('img#CONTACT_PHONE').click(function() {
                        $('table#Table_MyComments').find('tr.Row').hide();
                        $('tr.CONTACT_PHONE').show();
                       // $('#more').html('<br>All [Phone] shown. Click to show some more <strong>ALL Contact</strong> Comments<br>');
        });

        $('img#CONTACT_EMAIL').click(function() {
                        $('table#Table_MyComments').find('tr.Row').hide();
                        $('tr.CONTACT_EMAIL').show();
                        //$('#more').html('<br>All [Email] shown. Click to show some more <strong>ALL Contact</strong> Comments<br>');
        });

        $('img#CONTACT_POST').click(function() {
                        $('table#Table_MyComments').find('tr.Row').hide();
                        $('tr.CONTACT_POST').show();
                        //$('#more').html('<br>All [Postal] shown. Click to show some more <strong>ALL Contact</strong> Comments<br>');
        });

        $('img#CONTACT_VISITED').click(function() {
                        $('table#Table_MyComments').find('tr.Row').hide();
                        $('tr.CONTACT_VISITED').show();
                        //$('#more').html('<br>All [Visits] shown. Click to show some more <strong>ALL Contact</strong> Comments<br>');
        });
                // 2-3-2011|EA| added
        $('img#CONTACT_OTHER').click(function() {
                        $('table#Table_MyComments').find('tr.Row').hide();
                        $('tr.CONTACT_OTHER').show();
                        //$('#more').html('<br>All [Other] shown. Click to show some more <strong>ALL Contact</strong> Comments<br>');
        });

         // 7-Apr-2011|EA| added SMS
        $('img#CONTACT_SMS').click(function() {
                        $('table#Table_MyComments').find('tr.Row').hide();
                        $('tr.CONTACT_SMS').show();
                        //$('#more').html('<br>All [SMS] shown. Click to show some more <strong>ALL Contact</strong> Comments<br>');
        });
       

       
    // -------------------------
</script>

</form>
</body>
</html>

<!--End ASPX page-->

