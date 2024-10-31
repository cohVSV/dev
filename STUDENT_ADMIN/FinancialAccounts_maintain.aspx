<!--ASPX page @1-663BD7A7-->
    <%@ Page language="vb" CodeFile="FinancialAccounts_maintain.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.FinancialAccounts_maintain.FinancialAccounts_maintainPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.FinancialAccounts_maintain" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4"><meta http-equiv="Content-Type" content="text/html; charset=windows-1252">

<title>Financial Accounts maintain</title>



</head>
<body>
<form runat="server">


<script language="JavaScript" type="text/javascript">
//Begin CCS script
//DEL  </script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//DEL    

//Include Common JSFunctions @1-092F8E28
</script>
<script language="JavaScript" type="text/javascript" charset="windows-1252" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript" charset="utf-8" src='ClientI18N.aspx?file=DatePicker.js&locale=<%=Resources.strings.CCS_LocaleID%>'></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//Include User Scripts @1-4C4A65A2
</script>
<script language="JavaScript" src="js/pt/prototype.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/yui/build/yahoo-dom-event/yahoo-dom-event.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/yui/build/animation/animation-min.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/yui/build/dragdrop/dragdrop-min.js" type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" src="js/yui/build/container/container-min.js" type="text/javascript" charset="windows-1252"></script>
<link rel="stylesheet" type="text/css" href="js/yui/build/container/assets/skins/sam/container.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/ccs-yui-container.css">
<script language="JavaScript" type="text/javascript">
//End Include User Scripts

//Date Picker Object Definitions @1-7992B6B6

var TXN1DatePicker_TXN_DATE = new Object(); 
TXN1DatePicker_TXN_DATE.format           = "dd/mm/yyyy";
TXN1DatePicker_TXN_DATE.style            = "Styles/Blueprint/Style.css";
TXN1DatePicker_TXN_DATE.relativePathPart = "";
TXN1DatePicker_TXN_DATE.themeVersion     = "3.0";
//End Date Picker Object Definitions

//DEL  </script>
//DEL
<script language="JavaScript" src="js/pt/prototype.js" type="text/javascript" charset="windows-1252"></script>
//DEL
<script language="JavaScript" src="js/yui/build/yahoo-dom-event/yahoo-dom-event.js" type="text/javascript" charset="windows-1252"></script>
//DEL
<script language="JavaScript" src="js/yui/build/animation/animation-min.js" type="text/javascript" charset="windows-1252"></script>
//DEL
<script language="JavaScript" src="js/yui/build/dragdrop/dragdrop-min.js" type="text/javascript" charset="windows-1252"></script>
//DEL
<script language="JavaScript" src="js/yui/build/container/container-min.js" type="text/javascript" charset="windows-1252"></script>
//DEL 
<link rel="stylesheet" type="text/css" href="js/yui/build/container/assets/skins/sam/container.css">
//DEL 
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/ccs-yui-container.css">
//DEL
<script language="JavaScript" type="text/javascript">

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//Set Focus @43-9AD6E82B
    if (theForm.txnAMOUNT) theForm.txnAMOUNT.focus();
//End Set Focus

//Close page_OnLoad @1-BC33A33A
    return result;
}
//End Close page_OnLoad

//page_TXN1_Button_Insert_Payment_OnClick @74-91DDF109
function page_TXN1_Button_Insert_Payment_OnClick()
{
    disableValidation = true;
}
//End page_TXN1_Button_Insert_Payment_OnClick

//page_TXN1_Button_Insert_FullPayment_OnClick @86-39DCDC95
function page_TXN1_Button_Insert_FullPayment_OnClick()
{
    disableValidation = true;
}
//End page_TXN1_Button_Insert_FullPayment_OnClick

//page_TXN1_Button_Cancel_OnClick @87-880D32F8
function page_TXN1_Button_Cancel_OnClick()
{
    disableValidation = true;
}
//End page_TXN1_Button_Cancel_OnClick

//PTAutoFill1 Loading @119-15A6A863
function txnTXN_CODEPTAutoFill1_start(sender) {
    new Ajax.Request("services/FinancialAccounts_maintain_txn_TXN_CODE_PTAutoFill1.aspx?keyword=" + encodeURI($("txnTXN_CODE").value), {
        method: "get",
        requestHeaders: ['If-Modified-Since', new Date(0)],
        onSuccess: function(transport) {
            var valuesRow = eval(transport.responseText)[0];
            //ERA: 10-April-2010 - not simply filling label, now back using drop-down list and setting disabled unless certain codes
                        //$("txnLabel_CR_DR_FLAG").innerHTML = valuesRow["CR_DR_FLAG"]; // for debug
                        var txncode = $("txnTXN_CODE").value;

                        if ((txncode=='R') || (txncode=='T') || (txncode == 'W') || (txncode == '')) {
                                // leave buttons unselected
                $("txnCR_DR_FLAG").value = ""
                                $("txnCR_DR_FLAG").enable();
                        } else {
                                // select the value and then disable
                                $("txnCR_DR_FLAG").value = valuesRow["CR_DR_FLAG"];
                        //      $("txnCR_DR_FLAG").disable();
                        }

        }, 
        onFailure: function(transport) {
            alert(transport.responseText);
        }
    });
}
//End PTAutoFill1 Loading

//Initialize ShowModal_AutoTXN @103-CDAB369E
function ShowModal_AutoTXN_init() {
    var panel = document.getElementById('Panel_Auto1');
    if (!panel) return;
    window.ShowModal_AutoTXN_Panel = new YAHOO.widget.Panel('ShowModal_AutoTXN_Panel',  { 
        modal: false,
        fixedcenter: true,
        visible: false,
        zIndex: 111,
        constraintoviewport: false,
        width: '300px',
        close: false
    });
    panel.style.position = "absolute";
    //panel.style.float = "left";
    panel.style.visibility = "hidden";
    if (panel) { 
        var html = panel.innerHTML;
        panel.parentNode.removeChild(panel);
        window.ShowModal_AutoTXN_Panel.setHeader('');
        window.ShowModal_AutoTXN_Panel.appendToBody(panel);
        window.ShowModal_AutoTXN_Panel.render(document.body);
        window.ShowModal_AutoTXN_Panel.hide();
        panel.style.visibility = "";
        panel.style.position = "";
        window.ShowModal_AutoTXN_Panel.body.overflow = 'auto';
        var css = document.body.className;
        if (css.toLowerCase().indexOf('yui-skin-sam') == -1) css += " yui-skin-sam";
        document.body.className = css.replace(/^[\s]*/m, "");
        var panelHeader = document.getElementById('ShowModal_AutoTXN_Panel_h');
        if (panelHeader)
            panelHeader.style.display = 'none';
        window.ShowModal_AutoTXN_Panel.body.style.backgroundColor = "#BDCDDB";
        window.ShowModal_AutoTXN_Panel.cfg.setProperty("height", '200px');
    } else { delete window.ShowModal_AutoTXN_Panel; }
}
function ShowModal_AutoTXN_show() {
    if (!window.ShowModal_AutoTXN_Panel)
        ShowModal_AutoTXN_init();
    window.ShowModal_AutoTXN_Panel.show();
    return false;
}
function ShowModal_AutoTXN_hide() {
    if (!window.ShowModal_AutoTXN_Panel)
        ShowModal_AutoTXN_init();
    window.ShowModal_AutoTXN_Panel.hide();
    return false;
}
//End Initialize ShowModal_AutoTXN

//DEL  function txnTXN_CODEPTAutoFill1_start(sender) {
//DEL      new Ajax.Request("services/FinancialAccounts_maintain_txn_TXN_CODE_PTAutoFill1.aspx?keyword=" + encodeURI($("txnTXN_CODE").value), {
//DEL          method: "get",
//DEL          requestHeaders: ['If-Modified-Since', new Date(0)],
//DEL          onSuccess: function(transport) {
//DEL              var valuesRow = eval(transport.responseText)[0];
//DEL              //ERA: 10-April-2010 - not simply filling label, now back using drop-down list and setting disabled unless certain codes
//DEL                          //$("txnLabel_CR_DR_FLAG").innerHTML = valuesRow["CR_DR_FLAG"]; // for debug
//DEL                          var txncode = $("txnTXN_CODE").value;
//DEL  
//DEL                          if ((txncode=='R') || (txncode=='T') || (txncode == 'W') || (txncode == '')) {
//DEL                                  // leave buttons unselected
//DEL                  $("txnCR_DR_FLAG").value = ""
//DEL                                  $("txnCR_DR_FLAG").enable();
//DEL                          } else {
//DEL                                  // select the value and then disable
//DEL                                  $("txnCR_DR_FLAG").value = valuesRow["CR_DR_FLAG"];
//DEL                          //      $("txnCR_DR_FLAG").disable();
//DEL                          }
//DEL  
//DEL          }, 
//DEL          onFailure: function(transport) {
//DEL              alert(transport.responseText);
//DEL          }
//DEL      });
//DEL  }


//bind_events @1-C76B5D5E
function bind_events() {
    ShowModal_AutoTXN_init();
    addEventHandler("txnTXN_CODE", "change", txnTXN_CODEPTAutoFill1_start);
    addEventHandler("txn", "load", ShowModal_AutoTXN_hide);
    addEventHandler("TXN1Button_Insert_Payment","click",page_TXN1_Button_Insert_Payment_OnClick);
    addEventHandler("TXN1Button_Insert_FullPayment","click",page_TXN1_Button_Insert_FullPayment_OnClick);
    addEventHandler("TXN1Button_Cancel","click",page_TXN1_Button_Cancel_OnClick);
    page_OnLoad();
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

window.onload = bind_events;

//End CCS script
</script>
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<DECV_PROD2007:Header id="Header" runat="server"/> <DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/> 
<h1>Financial Accounts - VSV</h1>
<a href="OnlineHelp/Auto Transactions/Auto Transactions.html" title="show help for this page" target="_blank"><img border="0" alt="Online Help" align="right" src="images/help.png"></a> 
<p>
<div align="center">
  <strong>Student ID: </strong><asp:Literal id="lblStudentID" runat="server"/>&nbsp;&nbsp;&nbsp;&nbsp;<strong>Enrolment Year: </strong><asp:Literal id="lblEnrolmentYear" runat="server"/> 
</div>
<br>

<asp:repeater id="Grid_TransactionsRepeater" OnItemCommand="Grid_TransactionsItemCommand" OnItemDataBound="Grid_TransactionsItemDataBound" runat="server">
  <HeaderTemplate>
	
<table border="0" cellspacing="0" cellpadding="0" width="70%" align="center">
  <tr>
    <td valign="top">
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>
          <p align="center">Transaction Date</p>
          </th>
 
          <th>
          <p align="center">Transaction Code</p>
          </th>
 
          <th>
          <p align="center">Amount</p>
          </th>
 
          <th>
          <p align="center">DR/CR</p>
          </th>
 
          <th>
          <p align="center">Comments</p>
          </th>
 
          <th>
          <p align="center">Receipt #</p>
          </th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr  <CC:AttributeBinder runat="server" Name="rowStyle" ContainerId="Grid_TransactionsRepeater"/>>
          <td>
            <div align="center">
<a id="Grid_Transactionslink_TRANS_DATE" href="" title="edit Comment / Receipt #" runat="server"  ><%#(CType(Container.DataItem,Grid_TransactionsItem)).link_TRANS_DATE.GetFormattedValue()%></a> 
            </div>
          </td> 
          <td>
            <div align="right">
              
  <input id="Grid_TransactionsTXN_ID"  value='<%# (CType(Container.DataItem,Grid_TransactionsItem)).TXN_ID.GetFormattedValue() %>' type="hidden" size="8"  runat="server"/>
  <asp:Literal id="Grid_TransactionsTRANS_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_TransactionsItem)).TRANS_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/> 
            </div>
          </td> 
          <td style="TEXT-ALIGN: right">
            <div align="right">
              <asp:Literal id="Grid_TransactionsAMOUNT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_TransactionsItem)).AMOUNT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;&nbsp; 
            </div>
          </td> 
          <td>
            <div align="center">
              <asp:Literal id="Grid_TransactionsCR_DR_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_TransactionsItem)).CR_DR_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/> 
            </div>
          </td> 
          <td><asp:Literal id="Grid_TransactionsCOMMENTS" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_TransactionsItem)).COMMENTS.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="Grid_TransactionsRECEIPT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid_TransactionsItem)).RECEIPT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        <tr class="Bottom">
          <td colspan="2" align="right">
            <p align="right"><strong>Account Balance:</strong></p>
          </td> 
          <td align="right">$<asp:Literal id="Grid_TransactionslblAcctBalance" runat="server"/>&nbsp;&nbsp;</td> 
          <td>
            <div align="center">
              <asp:Literal id="Grid_TransactionslblCRDRFlag" runat="server"/> 
            </div>
          </td> 
          <td colspan="2" align="left">&nbsp;</td>
        </tr>
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="6">No Transactions found for this Student + Year&nbsp;&nbsp;&nbsp;&nbsp;<input type="button" id="Button_TXNTest" class="Button" onclick="ShowModal_AutoTXN_show();" name="Button_TXNTest" value="Try Auto Transactions"/>&nbsp;</td>
        </tr>
        
  </asp:PlaceHolder>

      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
<br>

  <span id="txnHolder" runat="server">
    


  
  <input id="txnSTUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="txnENROLMENT_YEAR" type="hidden"  runat="server"/>
  
  <input id="txnLAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="txnCAMPUS_CODE" type="hidden"  runat="server"/>
  
  <input id="txnLAST_ALTERED_DATE" type="hidden"  runat="server"/>
  
  <div align="center">
    <table border="0" cellspacing="0" cellpadding="0" width="70%" align="center">
      <tr>
        <td valign="top">
          <table class="Header" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
              <th>Add Transaction</th>
 
              <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
            </tr>
          </table>
 
          <table class="Record" cellspacing="0" cellpadding="0">
            
  <asp:PlaceHolder id="txnError" visible="False" runat="server">
  
            <tr class="Error">
              <td colspan="6"><asp:Label ID="txnErrorLabel" runat="server"/></td>
            </tr>
            
  </asp:PlaceHolder>
  
            <tr class="Controls">
              <th>
              <p align="center">&nbsp;<strong>Transaction<br>
              </strong><strong>Date</strong></p>
              </th>
 
              <td><strong>&nbsp;Transaction Code</strong></td> 
              <td>
                <p align="center"><strong>&nbsp;Amount</strong></p>
              </td> 
              <td>
                <p align="center"><strong>&nbsp;DR/CR</strong></p>
              </td> 
              <td>
                <p align="center"><strong>Comments&nbsp;</strong></p>
              </td> 
              <td>
                <p align="center"><strong>Receipt</strong>&nbsp;</p>
              </td>
            </tr>
 
            <tr class="Controls">
              <th>
              <p align="center"><asp:TextBox id="txnTXN_DATE" maxlength="12" Columns="10"	runat="server"/></p>
              </th>
 
              <td>&nbsp; 
                
                <select id="txnTXN_CODE"  runat="server"></select>
 </td> 
              <td align="center">&nbsp;<asp:TextBox id="txnAMOUNT" maxlength="15" Columns="10"	runat="server"/></td> 
              <td align="center">
                <div id="txnLabel_CR_DR_FLAG" name="txnLabel_CR_DR_FLAG">
                </div>
                <select id="txnCR_DR_FLAG"  runat="server"></select>
 </td> 
              <td>&nbsp; 
<asp:TextBox id="txnCOMMENTS" Columns="15" TextMode="MultiLine"	runat="server"/>
</td> 
              <td>&nbsp;<asp:TextBox id="txnRECEIPT_NO" maxlength="10" Columns="10"	runat="server"/></td>
            </tr>
 
            <tr class="Bottom">
              <td colspan="6" align="right">
                <input id='txnButton_Insert' type="submit" class="Button" value="Add" OnServerClick='txn_Insert' runat="server"/></td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  </div>



  </span>
  
<p>&nbsp; 
<div id="Panel_Auto1">
	<asp:PlaceHolder id="Panel_Auto1" Visible="true" runat="server">
	&nbsp; 

<asp:repeater id="Grid1Repeater" OnItemCommand="Grid1ItemCommand" OnItemDataBound="Grid1ItemDataBound" runat="server">
  <HeaderTemplate>
	
<table border="0" cellspacing="0" cellpadding="0" width="85%" align="center">
  <tr>
    <td valign="top">
      <table class="Header" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td class="HeaderLeft"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td> 
          <th>Auto-Calculated Fees</th>
 
          <td class="HeaderRight"><img border="0" src="Styles/Blueprint/Images/Spacer.gif"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th>
          <p align="center">Date</p>
          </th>
 
          <th>Code</th>
 
          <th>
          <p align="center">Amount</p>
          </th>
 
          <th>
          <p align="center">DR/CR</p>
          </th>
 
          <th>
          <p align="center">Comments</p>
          </th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td><asp:Literal id="Grid1TODAY" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid1Item)).TODAY.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="Grid1TXN_CODE" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid1Item)).TXN_CODE.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td style="TEXT-ALIGN: right"><asp:Literal id="Grid1AMOUNT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid1Item)).AMOUNT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td> 
          <td>
            <div align="center">
              <asp:Literal id="Grid1CR_DR_FLAG" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid1Item)).CR_DR_FLAG.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/> 
            </div>
          </td> 
          <td><asp:Literal id="Grid1COMMENT" Text='<%# Server.HtmlEncode((CType(Container.DataItem,Grid1Item)).COMMENT.GetFormattedValue()).Replace(vbCr,"").Replace(vbLf,"<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
	<asp:PlaceHolder id="IterationContainer" runat="server"/>
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="5">No Transactions calculated.</td>
        </tr>
        
  </asp:PlaceHolder>

      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
&nbsp;&nbsp; 

  <span id="TXN1Holder" runat="server">
    


  <table border="0" cellspacing="0" cellpadding="0" width="85%" align="center">
    <tr>
      <td valign="top">
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="TXN1Error" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="TXN1ErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th><strong>Payment Date</strong></th>
 
            <th><strong>Payment $</strong></th>
          </tr>
 
          <tr class="Controls">
            <td><asp:TextBox id="TXN1TXN_DATE" maxlength="100" Columns="10"	runat="server"/>
              <asp:PlaceHolder id="TXN1DatePicker_TXN_DATE" runat="server"><a href="javascript:showDatePicker('<%#TXN1DatePicker_TXN_DATEName%>','forms[\''+theForm.id+'\']','<%#TXN1DatePicker_TXN_DATEDateControl%>');" id="TXN1DatePicker_TXN_DATE_Link"  ><img id="TXN1DatePicker_TXN_DATE_Image" border="0" alt="Show Date Picker" src="Styles/Blueprint/Images/DatePicker.gif" /></a></asp:PlaceHolder>
  </td> 
            <td><asp:TextBox id="TXN1AMOUNT" maxlength="15" Columns="6"	runat="server"/></td>
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">
  <input id="TXN1TXN_CODE" type="hidden"  runat="server"/>
  
  <input id="TXN1CR_DR_FLAG" type="hidden"  runat="server"/>
  
  <input id="TXN1ENROLMENT_YEAR" type="hidden"  runat="server"/>
  
  <input id="TXN1STUDENT_ID" type="hidden"  runat="server"/>
  
  <input id="TXN1COMMENTS" type="hidden"  runat="server"/>
  
  <input id="TXN1CAMPUS_CODE" type="hidden"  runat="server"/>
  
  <input id="TXN1LAST_ALTERED_BY" type="hidden"  runat="server"/>
  
  <input id="TXN1LAST_ALTERED_DATE" type="hidden"  runat="server"/>
  
              <input id='TXN1Button_Insert_FullPayment' type="submit" class="Button" value="Save - Full Payment" OnServerClick='TXN1_Insert' runat="server"/>
              <input id='TXN1Button_Insert_Payment' type="submit" class="Button" value="Save Payment" OnServerClick='TXN1_Insert' runat="server"/>
              <input id='TXN1Button_Cancel' type="submit" class="Button" value="Cancel" OnServerClick='TXN1_Cancel' runat="server"/></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>



  </span>
  
	</asp:PlaceHolder>
	</div>
<p>&nbsp;</p>
<div align="center">
</div>
<p><br>
&nbsp;</p>

</form>
</body>
</html>

<!--End ASPX page-->

