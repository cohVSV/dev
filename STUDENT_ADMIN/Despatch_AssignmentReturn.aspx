<!--ASPX page @1-282FD477-->
    <%@ Page language="vb" CodeFile="Despatch_AssignmentReturn.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Despatch_AssignmentReturn.Despatch_AssignmentReturnPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Despatch_AssignmentReturn" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@Register TagPrefix="DECV_PROD2007" TagName="Header" Src="Header.ascx"%>
    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta content="CodeCharge Studio 3.2.0.4" name="GENERATOR"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Despatch - Assignment Return</title>


<link href="Styles/Blueprint/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//DEL  </script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//DEL    

//Include Common JSFunctions @1-12DCE9BA
</script>
<script language="JavaScript" src='ClientI18N.aspx?file=Functions.js&locale=<%=Resources.strings.CCS_LocaleID%>' type="text/javascript" charset="windows-1252"></script>
<script language="JavaScript" type="text/javascript">
//End Include Common JSFunctions

//DEL      // -------------------------
//DEL      // ERA: if the Subject+Assignment ID value is <=3 then assume subject only entered/selected and wait for assignment to be added
//DEL          if (theForm.AssignmentReturnssubjectid.value.length >= 4) {
//DEL                  if (theForm.AssignmentReturnsmarkerid) theForm.AssignmentReturnsmarkerid.focus();
//DEL          }
//DEL      // -------------------------

//page_OnLoad @1-D0F4E1D3
function page_OnLoad()
{
    var result;
//End page_OnLoad

//Set Focus @13-DF7072F9
    if (theForm.AssignmentReturnsstaffid) theForm.AssignmentReturnsstaffid.focus();
//End Set Focus

//Close page_OnLoad @1-BC33A33A
    return result;
}
//End Close page_OnLoad

//bind_events @1-B716D3FC
function bind_events() {
    page_OnLoad();
    forms_onload();
}
//End bind_events

//Assign bind_events @1-19F7B649window.onload = bind_events;
//End Assign bind_events

window.onload = bind_events; 

//End CCS script
</script>
<script language="JavaScript" type="text/javascript">
function OpenPopUpList()
{
                // default popup - using no initial params and single field return
        var FieldName;
        FieldName = "AssignmentReturnsstudentid";
        var win=window.open("popup_StudentSearch.aspx?returncontrol="+FieldName, "StudentSearch", "left=40,top=10,width=500,height=480,status=no,toolbar=no,menubar=no,location=no,scrollbars=yes");
        win.focus();
}

function OpenPopUpList_SubjectSearch()
{
        var retFieldName;
        retFieldName = "AssignmentReturnssubjectid";
        var tmpSearchField;
        tmpSearchField = document.getElementById('AssignmentReturnsstudentid').value
        var win=window.open("popup_StudentSubjectSearch.aspx?returncontrol="+retFieldName+"&p_STUDENTID="+tmpSearchField, "SubjectSearch", "left=40,top=10,width=500,height=480,status=no,toolbar=no,menubar=no,location=no,scrollbars=yes");
        win.focus();
}
function disableEnterKey(e)
{
     var key;     
     if(window.event)
          key = window.event.keyCode; //IE
     else
          key = e.which; //firefox     

     return (key != 13);
}
</script>

</head>
<body>
<form runat="server">


<p><DECV_PROD2007:Header id="Header" runat="server"/></p>
<p>

  <span id="AssignmentReturnsHolder" runat="server">
    


  <table cellspacing="0" cellpadding="0" width="50%" align="center" border="0">
    <tr>
      <td valign="top">
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td> 
            <th>Assignment Returns</th>
 
            <td class="HeaderRight"><img src="Styles/Blueprint/Images/Spacer.gif" border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="AssignmentReturnsError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="3"><asp:Label ID="AssignmentReturnsErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th>
            <p align="right">Staff ID</p>
            </th>
 
            <td><asp:TextBox id="AssignmentReturnsstaffid" onkeydown='<%#"if (event.keyCode==13) " + PageVariables.Get("event.keyCode=9; return event.keyCode ") + ";"%>' onfocus="this.select();" tabindex="1" Columns="16"	runat="server"/></td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">Student ID</p>
            </th>
 
            <td><asp:TextBox id="AssignmentReturnsstudentid" onkeydown='<%#"if (event.keyCode==13) " + PageVariables.Get("event.keyCode=9; return event.keyCode ") + ";"%>' style="TEXT-ALIGN: right" onfocus="this.select();" tabindex="2" Columns="16"	runat="server"/></td> 
            <td>&nbsp;<a id="AssignmentReturnslink_popupStudentSearch" href="" class="Button" onclick="OpenPopUpList();" runat="server"  >Student Search</a></td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">Subject ID + Assignment ID</p>
            </th>
 
            <td><asp:TextBox id="AssignmentReturnssubjectid" onkeydown='<%#"if (event.keyCode==13) " + PageVariables.Get("event.keyCode=9; return event.keyCode ") + ";"%>' style="BACKGROUND-COLOR: #cccccc; TEXT-ALIGN: right" onfocus="this.select();" tabindex="3" maxlength="8" Columns="12"	runat="server"/></td> 
            <td>&nbsp;<a id="AssignmentReturnslink_popupStudentSubjectSearch" href="" class="Button" onclick="OpenPopUpList_SubjectSearch();" runat="server"  >Subject Search</a></td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">Marker ID</p>
            </th>
 
            <td><asp:TextBox id="AssignmentReturnsmarkerid" style="BACKGROUND-COLOR: #cccccc" onfocus="this.select();" tabindex="5" Columns="16"	runat="server"/></td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th>
            <p align="right">Receipt Date</p>
            </th>
 
            <td><asp:Literal id="AssignmentReturnslblReceiptDate" runat="server"/></td> 
            <td>&nbsp;</td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="3"><a id="AssignmentReturnsLink_Clear" href="" runat="server"  >Clear</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
              <input id='AssignmentReturnsButton_Insert' class="Button" tabindex="6" type="submit" value="Do Return" OnServerClick='AssignmentReturns_Insert' runat="server"/></td>
          </tr>
        </table>
        
  <input id="AssignmentReturnsENrolmentYear" type="hidden"  runat="server"/>
  </td>
    </tr>
  </table>


<p></p>
<p align="center">&nbsp;</p>

  </span>
  
<p></p>
<p></p>

</form>
</body>
</html>

<!--End ASPX page-->

