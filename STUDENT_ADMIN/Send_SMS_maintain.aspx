<!--ASPX page @1-7700EF44-->
    <%@ Page language="vb" CodeFile="Send_SMS_maintain.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Send_SMS_maintain.Send_SMS_maintainPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Send_SMS_maintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 4.1.00.032"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Student Send SMS</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css" />
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Include User Scripts @1-2F0138A6
</script>
<script language="JavaScript" src="js/pt/prototype_ccs.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include User Scripts

//page_NewSMSRecord_Button_Cancel_OnClick @35-D3E6A0D3
function page_NewSMSRecord_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_NewSMSRecord_Button_Cancel_OnClick

//HideShow_ajaxBusy Loading @56-F7D4BEBD
function NewSMSRecordHideShow_ajaxBusy_show(sender) {
    var control = getSameLevelCtl("NewSMSRecordajaxBusy", sender);
    if (control != null) {
            control.style.display = "";
    } else {
            addProgress();
    }
}
function NewSMSRecordHideShow_ajaxBusy_hide(sender) {
    var control = getSameLevelCtl("NewSMSRecordajaxBusy", sender);
    if (control != null) {
            control.style.display = "none";
    } else {
            removeProgress();
    }
}
//End HideShow_ajaxBusy Loading

//bind_events @1-CAA259E6
function bind_events() {
    addEventHandler("NewSMSRecord", "submit", NewSMSRecordHideShow_ajaxBusy_show);
    addEventHandler("NewSMSRecord", "load", NewSMSRecordHideShow_ajaxBusy_hide);
    addEventHandler("NewSMSRecordButton_Cancel","click",page_NewSMSRecord_Button_Cancel_OnClick);
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
.warnMaxChars  { font-weight: bold; color: #FFFFFF; background-color: #FF0000; padding-top: 10px; padding-bottom: 10px; }
.normalSMSCharacters  { font-weight: normal; color: #00FF00; }
-->
</style>

</head>
<body>
<form runat="server">


<p align="center">

	<asp:PlaceHolder id="Panel_MenuStudentMaintain" Visible="false" runat="server">
	<DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/>
	</asp:PlaceHolder>
	</p>
<p>&nbsp; <a href="OnlineHelp/SMS_FromDatabase/SMS_FromDatabase.html" title="show help for this page" target="_blank"><img border="0" alt="show help for this page" align="right" src="images/help.png"></a> 
<p align="center"><a id="Link_Backtosummary" href="" class="Button" runat="server"  >Back to Summary</a><font color="#ff0000"></font></p>
<p>

  <span id="NewSMSRecordHolder" runat="server">
    


  <table border="0" cellspacing="0" cellpadding="0" align="center">
    <tr>
      <td valign="top">
        <table class="Header" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
            <th>Send SMS</th>
 
            <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
          </tr>
 
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="NewSMSRecordError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="NewSMSRecordErrorLabel" runat="server"/></td> 
          </tr>
 
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>Student ID</th>
 
            <td><asp:Literal id="NewSMSRecordlblStudentID" runat="server"/>&nbsp;</td> 
          </tr>
 
          <tr class="Controls">
            <th>Send to Number</th>
 
            <td>
              <asp:RadioButtonList id="NewSMSRecordmobileno_sendto"  RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"/><asp:Literal id="NewSMSRecordlblNoSMSNumbers" runat="server"/></td> 
          </tr>
 
          <tr class="Controls">
            <th>SMS Message to send 
            <div id="maxchar_sms">
              140 characters allowed 
            </div>
 </th>
 
            <td>
<asp:TextBox id="NewSMSRecordsms_text" onkeyup="warnMaxLength(this,140,'maxchar_sms');" Columns="50" rows="3" TextMode="MultiLine"	runat="server"/>
</td> 
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right"><asp:Image id="NewSMSRecordajaxBusy"  style="DISPLAY: none" AlternateText="updating" ImageUrl="images/ajax_loader.gif" runat="server"/>
              <input id='NewSMSRecordButton_Insert' type="submit" class="Button" value="Send SMS" OnServerClick='NewSMSRecord_Insert' runat="server"/>
              <input id='NewSMSRecordButton_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='NewSMSRecord_Cancel' runat="server"/>
  <input id="NewSMSRecordsms_status" type="hidden"  runat="server"/>
  
  <input id="NewSMSRecordsent_by" type="hidden"  runat="server"/>
  
  <input id="NewSMSRecordstudent_id" type="hidden"  runat="server"/>
  </td> 
          </tr>
 
        </table>
 <em>Note: SMS will be sent immediately. SMS Failures will be automatically notified to PC Support for follow-up.</em></td> 
    </tr>
 
  </table>



  </span>
  </p>
<p>
<p></p>

<asp:repeater id="STUDENT_SMS_LOGRepeater" OnItemCommand="STUDENT_SMS_LOGItemCommand" OnItemDataBound="STUDENT_SMS_LOGItemDataBound" runat="server">
  <HeaderTemplate>
	
<table border="0" cellspacing="0" cellpadding="0" width="80%" align="center">
  <tr>
    <td valign="top">
      <table class="Header" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>3 Month SMS&nbsp;History</th>
 
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
        </tr>
 
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>
          <CC:Sorter id="Sorter_mobileno_sendtoSorter" field="Sorter_mobileno_sendto" OwnerState="<%# STUDENT_SMS_LOGData.SortField.ToString()%>" OwnerDir="<%# STUDENT_SMS_LOGData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_mobileno_sendtoSort" runat="server">Number Sent To</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_sms_textSorter" field="Sorter_sms_text" OwnerState="<%# STUDENT_SMS_LOGData.SortField.ToString()%>" OwnerDir="<%# STUDENT_SMS_LOGData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_sms_textSort" runat="server">SMS Message</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_datetime_createdSorter" field="Sorter_datetime_created" OwnerState="<%# STUDENT_SMS_LOGData.SortField.ToString()%>" OwnerDir="<%# STUDENT_SMS_LOGData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_datetime_createdSort" runat="server">Date/time Created</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
          <th>
          <CC:Sorter id="Sorter_sent_bySorter" field="Sorter_sent_by" OwnerState="<%# STUDENT_SMS_LOGData.SortField.ToString()%>" OwnerDir="<%# STUDENT_SMS_LOGData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_sent_bySort" runat="server">Sent By</asp:LinkButton> 
          <CC:SorterItem type="AscOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Asc.gif"></CC:SorterItem>
          <CC:SorterItem type="DescOn" runat="server"><img border="0" src="Styles/Blueprint/Images/Desc.gif"></CC:SorterItem></CC:Sorter></th>
 
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td><asp:Literal id="STUDENT_SMS_LOGmobileno_sendto" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_SMS_LOGItem)).mobileno_sendto.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_SMS_LOGsms_text" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_SMS_LOGItem)).sms_text.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_SMS_LOGdatetime_created" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_SMS_LOGItem)).datetime_created.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="STUDENT_SMS_LOGsent_by" Text='<%# Server.HtmlEncode((CType(Container.DataItem,STUDENT_SMS_LOGItem)).sent_by.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="4">No SMS Messsages found in previous 3 months. Check the student's <a id="STUDENT_SMS_LOGLink1" href="" runat="server"  >Comments page</a></td> 
        </tr>
 
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="4">&nbsp; 
            
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# STUDENT_SMS_LOGData.PagesCount%>" PageSize="<%# STUDENT_SMS_LOGData.RecordsPerPage%>" PageNumber="<%# STUDENT_SMS_LOGData.PageNumber%>" runat="server">
            <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img border="0" src="Styles/Blueprint/Images/First.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="FirstOff" runat="server"><img border="0" src="Styles/Blueprint/Images/FirstOff.gif"></CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img border="0" src="Styles/Blueprint/Images/Prev.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="PrevOff" runat="server"><img border="0" src="Styles/Blueprint/Images/PrevOff.gif"></CC:NavigatorItem>&nbsp;<%# (CType(Container,Navigator)).PageNumber.ToString() %> of&nbsp;<%# (CType(Container,Navigator)).MaxPage.ToString() %>&nbsp; 
            <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img border="0" src="Styles/Blueprint/Images/Next.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="NextOff" runat="server"><img border="0" src="Styles/Blueprint/Images/NextOff.gif"></CC:NavigatorItem>
            <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img border="0" src="Styles/Blueprint/Images/Last.gif"></asp:LinkButton> </CC:NavigatorItem>
            <CC:NavigatorItem type="LastOff" runat="server"><img border="0" src="Styles/Blueprint/Images/LastOff.gif"></CC:NavigatorItem></CC:Navigator>
&nbsp;</td> 
        </tr>
 
      </table>
 </td> 
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
<br>
<br>
<script language="JavaScript" type="text/javascript">
function limitMaxLength(formitem,maxlength,displaydivname) {
        // handle longer messages by cutting out dodgy chars and limiting to 140 char.
        if (isNaN(maxlength)) {
          return false;
        } else {
                //replace any non-approved chars with blank
        var typedStuff = formitem.value;
        typedStuff = typedStuff.replace(/[^0-9a-zA-Z\s\.\!\@\(\)\+\?\-]/g,"");
        var outputdiv = document.getElementById(displaydivname)
        outputdiv.innerHTML = (maxlength-typedStuff.length) + ' characters allowed';
        if (typedStuff.length+1>maxlength) {
                formitem.value=typedStuff.substring(0,maxlength);
        }
        }
}
function warnMaxLength(formitem,maxlength,displaydivname) {
        // handle longer messages by showing coloured warning but not cut.
        if (isNaN(maxlength)) {
          return false;
        } else {
        var typedStuff = formitem.value;
        //typedStuff = typedStuff.replace(/[^0-9a-zA-Z\s\.\!\@\(\)\+\?\-]/g,"");
        var outputdiv = document.getElementById(displaydivname)
       
        if (typedStuff.length>maxlength) {
                        outputdiv.className = 'warnMaxChars';        
                        outputdiv.innerHTML = (typedStuff.length-maxlength) + ' too many character(s)!';
                } else {
                        outputdiv.className = 'normalSMSCharacters';
                        outputdiv.innerHTML = (maxlength-typedStuff.length) + ' characters remaining';
        }
        }
}
</script>

</form>
</body>
</html>

<!--End ASPX page-->

