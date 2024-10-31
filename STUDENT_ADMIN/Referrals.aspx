<!--ASPX page @1-302467B5-->
    <%@ Page language="vb" CodeFile="Referrals.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.Referrals.ReferralsPage"  ResponseEncoding ="windows-1252"%>
	
	<%@ Import namespace="DECV_PROD2007.Referrals" %>
    <%@ Import namespace="DECV_PROD2007.Configuration" %>
    <%@ Import namespace="DECV_PROD2007.Data" %>
    
    <%@ Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx" %>

    <%@Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
<meta name="GENERATOR" content="CodeCharge Studio 5.1.1.18992"><meta http-equiv="content-type" content="text/html; charset=windows-1252">

<title>Referrals</title>


<link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
<link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>
    <style type="text/css">
        
      .MainTable
      {
         margin: 0 auto;
         margin-top: 30px;
         margin-bottom: 100px;
         width: 950px;
         border-radius: 20px 0px 0px 0px;
         
      }


      .MainTable, .Header, .Grid
      {
         border-radius: 20px 0px 0px 0px;
         border-collapse: collapse;
         padding: 0px;
      }


      .MainTable td, .MainTable th
      {
         padding: 7px;
         padding-left: 14px;
      }


      td.HeaderLeft
      {
         padding: 0px;
      }


      tr.Row:nth-child(odd) td, option:nth-child(odd)
      {
         background-color: #ebf2f8;
      }

      .column-header 
      {
          font-weight: bold;
      }
     /* table {
          background: green;
      }*/

    </style>

</head>
<body>
<form runat="server">
    <p style="margin-top: 20px; margin-left: auto; margin-right: auto;">

    <asp:PlaceHolder id="Panel_MenuStudentMaintain" Visible="false" runat="server">
        <DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server"/>
    </asp:PlaceHolder>
    </p>
    <p style="width: 250px; margin-left: auto; margin-right: auto;"><a id="Link_Backtosummary" href="StudentSummary.aspx" class="Button" style="padding: 6px 8px 6px 8px;" runat="server">Back to Summary</a></p>
    <asp:Label visible="false" runat="server" ID="uuidLabel"/>
    <asp:TextBox ID="UuidTextBox" runat="server" Visible="false"/>
    <asp:Button OnClick="SaveUuidClicked" ID="SaveUuidButton" Text="Save Uuid" runat="server" Visible="false"/>
    <asp:Button OnClick="ImportReferralsClicked" ID="ImportReferralsButton" Text="Import Referrals from Funnel" runat="server" Visible="false"/>
    <%--<asp:Button OnClick="ShowHideClicked" Text="ShowHideTest" runat="server"/>--%>
    <asp:ListView ID="lvReferral" runat="server" >
        <LayoutTemplate>
            <table class="MainTable" runat="server" id="referralTable">
                <tr class="Header" runat="server">
                    <th colspan="2" class="Header" runat="server">School Referral Form</th>
                </tr>
                <tr class="controls column-header" runat="server">
                    <th runat="server"><strong>Question</strong></th>
                    <th runat="server"><strong>Answer</strong></th>
                </tr>
                <tr runat="server" id="itemPlaceholder"></tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr class="Controls" runat="server">
                <td runat="server">
                    <strong><asp:Label ID="Label1" runat="server" text='<%#Eval("Question") %>' /></strong>
                </td>
                <td runat="server">
                    <asp:Label ID="NameLabel" runat="server" text='<%#Eval("Answer") %>' />
                </td>
            </tr>
        </ItemTemplate>

    </asp:ListView>

    <asp:ListView ID="lvYARF" runat="server" >
        <LayoutTemplate>
            <table class="MainTable" runat="server" id="yarfTable">
                 <tr class="Header" runat="server">
                    <th colspan="2" class="Header" runat="server">Young Adult Referral Form</th>
                </tr>
                <tr runat="server" class="controls column-header">
                    <th runat="server"><strong>Question</strong></th>
                    <th runat="server"><strong>Answer</strong></th>
                </tr>
                <tr runat="server" id="itemPlaceholder"></tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr class="Controls" runat="server">
                <td runat="server">
                    <asp:Label ID="Label1" runat="server" text='<%#Eval("Question") %>' />
                </td>
                <td runat="server">
                    <asp:Label ID="NameLabel" runat="server" text='<%#Eval("Answer") %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <asp:ListView ID="lvPARF" runat="server" >
        <LayoutTemplate>
            <table class="MainTable" runat="server" id="parfTable">
                 <tr class="Header" runat="server">
                    <th colspan="2" class="Header" runat="server">Practitioner Agency Referral Form</th>
                </tr>
                <tr runat="server" class="controls column-header">
                    <th runat="server"><strong>Question</strong></th>
                    <th runat="server"><strong>Answer</strong></th>
                </tr>
                <tr runat="server" id="itemPlaceholder"></tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr class="Controls" runat="server">
                <td runat="server">
                    <asp:Label ID="Label1" runat="server" text='<%#Eval("Question") %>' />
                </td>
                <td runat="server">
                    <asp:Label ID="NameLabel" runat="server" text='<%#Eval("Answer") %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

    <asp:ListView ID="lvCoachSports" runat="server" >
        <LayoutTemplate>
            <table class="MainTable" runat="server" id="coachSportsTable">
                    <tr class="Header" runat="server">
                    <th colspan="2" class="Header" runat="server">Coach Sports Referral Form</th>
                </tr>
                <tr runat="server" class="controls column-header">
                    <th runat="server"><strong>Question</strong></th>
                    <th runat="server"><strong>Answer</strong></th>
                </tr>
                <tr runat="server" id="itemPlaceholder"></tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr class="Controls" runat="server">
                <td runat="server">
                    <asp:Label ID="Label1" runat="server" text='<%#Eval("Question") %>' />
                </td>
                <td runat="server">
                    <asp:Label ID="NameLabel" runat="server" text='<%#Eval("Answer") %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

    <asp:ListView ID="lvSportsSchool" runat="server" >
        <LayoutTemplate>
            <table class="MainTable" runat="server" id="sportsSchoolTable">
                    <tr class="Header" runat="server">
                    <th colspan="2" class="Header" runat="server">Sports School Referral Form</th>
                </tr>
                <tr runat="server" class="controls column-header">
                    <th runat="server"><strong>Question</strong></th>
                    <th runat="server"><strong>Answer</strong></th>
                </tr>
                <tr runat="server" id="itemPlaceholder"></tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr class="Controls" runat="server">
                <td runat="server">
                    <asp:Label ID="Label1" runat="server" text='<%#Eval("Question") %>' />
                </td>
                <td runat="server">
                    <asp:Label ID="NameLabel" runat="server" text='<%#Eval("Answer") %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

    <asp:ListView ID="lvTravelEmployer" runat="server" >
        <LayoutTemplate>
            <table class="MainTable" runat="server" id="travelTable">
                    <tr class="Header" runat="server">
                    <th colspan="2" class="Header" runat="server">Travel Employer Referral Form</th>
                </tr>
                <tr runat="server" class="controls column-header">
                    <th runat="server"><strong>Question</strong></th>
                    <th runat="server"><strong>Answer</strong></th>
                </tr>
                <tr runat="server" id="itemPlaceholder"></tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr class="Controls" runat="server">
                <td runat="server">
                    <asp:Label ID="Label1" runat="server" text='<%#Eval("Question") %>' />
                </td>
                <td runat="server">
                    <asp:Label ID="NameLabel" runat="server" text='<%#Eval("Answer") %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

</form>
</body>
</html>

<!--End ASPX page-->

