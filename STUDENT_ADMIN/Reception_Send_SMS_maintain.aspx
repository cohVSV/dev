<!--ASPX page @1-575089DF-->
    <%@ Page language="vb" CodeFile="Reception_Send_SMS_maintain.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Reception_Send_SMS_maintain.Reception_Send_SMS_maintainPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Reception_Send_SMS_maintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="text/html; charset=windows-1252" http-equiv="content-type">

<title>Reception Send SMS</title>

<meta name="GENERATOR" content="CodeCharge Studio 4.1.00.032">
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
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//Include Common JSFunctions @1-6208A745
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Include User Scripts @1-2F0138A6
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src="js/pt/prototype_ccs.js"></script>
<script language="JavaScript" type="text/javascript">
//End Include User Scripts

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//Set Focus @80-4A2B4B44
    if (theForm.NewSMSRecordmobileno_sendto) theForm.NewSMSRecordmobileno_sendto.focus();
//End Set Focus

//Close page_OnLoad @1-BC33A33A
    return result;
}
//End Close page_OnLoad

//page_NewSMSRecord_Button_Cancel_OnClick @35-D3E6A0D3
function page_NewSMSRecord_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_NewSMSRecord_Button_Cancel_OnClick

//HideShow1 Loading @56-7F43A763
function NewSMSRecordHideShow1_show(sender) {
    var control = getSameLevelCtl("NewSMSRecordajaxBusy", sender);
    if (control != null) {
            control.style.display = "";
    } else {
            addProgress();
    }
}
function NewSMSRecordHideShow1_hide(sender) {
    var control = getSameLevelCtl("NewSMSRecordajaxBusy", sender);
    if (control != null) {
            control.style.display = "none";
    } else {
            removeProgress();
    }
}
//End HideShow1 Loading

//bind_events @1-877A8604
function bind_events() {
    addEventHandler("NewSMSRecordButton_Insert", "click", NewSMSRecordHideShow1_show);
    addEventHandler("NewSMSRecord", "load", NewSMSRecordHideShow1_hide);
    addEventHandler("NewSMSRecordButton_Cancel","click",page_NewSMSRecord_Button_Cancel_OnClick);
    page_OnLoad();
    forms_onload();
}
//End bind_events

window.onload = bind_events; //Assign bind_events @1-19F7B649

//End CCS script
</script>
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">

</head>
<body>
<form runat="server">


<p align="center"><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p align="center">

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
            <th>Send to Number</th>
 
            <td><asp:TextBox id="NewSMSRecordmobileno_sendto" maxlength="20" Columns="20"	runat="server"/><font color="#ff0000">&nbsp;<asp:Literal id="NewSMSRecordlblMobileError" runat="server"/></font></td>
          </tr>
 
          <tr class="Controls">
            <th>SMS Message to send 
            <div id="maxchar_sms">
              140 characters allowed 
            </div>
            </th>
 
            <td>
<asp:TextBox id="NewSMSRecordsms_text" onkeyup="limitMaxLength(this,140,'maxchar_sms');" rows="3" Columns="50" TextMode="MultiLine"	runat="server"/>
</td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right"><asp:Image id="NewSMSRecordajaxBusy"  style="DISPLAY: none" AlternateText="updating" ImageUrl="images/ajax_loader.gif" runat="server"/>
              <input id='NewSMSRecordButton_Insert' class="Button" value="Send SMS" type="submit" OnServerClick='NewSMSRecord_Insert' runat="server"/>
              <input id='NewSMSRecordButton_Cancel' class="Button" value="Cancel" type="submit" OnServerClick='NewSMSRecord_Cancel' runat="server"/>
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
<p><br>
</p>

<asp:repeater id="STUDENT_SMS_LOGRepeater" OnItemCommand="STUDENT_SMS_LOGItemCommand" OnItemDataBound="STUDENT_SMS_LOGItemDataBound" runat="server">
  <HeaderTemplate>
	
<table border="0" cellspacing="0" cellpadding="0" align="center">
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
          <td colspan="4">No SMS Messsages found in previous 3 months</td>
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

</form>
</body>
</html>

<!--End ASPX page-->

