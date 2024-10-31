<!--ASPX page @1-4D4556C2-->

<%@ Page Language="vb" CodeFile="AssignmentSubmissionList.aspx.vb" AutoEventWireup="false" Inherits="DECV_PROD2007.AssignmentSubmissionList.AssignmentSubmissionListPage" ResponseEncoding="windows-1252" %>

<%@ Import Namespace="DECV_PROD2007.AssignmentSubmissionList" %>
<%@ Import Namespace="DECV_PROD2007.Configuration" %>
<%@ Import Namespace="DECV_PROD2007.Data" %>

<%@ Register TagPrefix="DECV_PROD2007" TagName="Menu_Student_maintain" Src="Menu_Student_maintain.ascx" %>
<%@ Register TagPrefix="CC" Namespace="DECV_PROD2007.Controls" %>
<html>
<head>
   <meta http-equiv="X-UA-Compatible" content="IE=edge">
   <meta name="GENERATOR" content="CodeCharge Studio 3.2.0.4">
   <meta http-equiv="content-type" content="text/html; charset=windows-1252">

   <title><asp:Literal runat="server" ID="litPageTitle"></asp:Literal></title>


   <link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style_Components.css">
   <link rel="stylesheet" type="text/css" href="Styles/Blueprint/Style.css">
   <link rel="stylesheet" type="text/css" href="Styles/Blueprint/jquery-ui.css">
   <script type="text/javascript" src="js/jquery_min.js"></script>
   <script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
   </script>

   <style type="text/css">
      .Button
      {
         padding: 6px 8px 6px 8px;
      }

      .MainTable
      {
         margin: 0 auto;
      }

      .MainTable, .Header, .Grid
      {
         border-collapse: collapse;
         padding: 0px;
      }

      td.HeaderLeft
      {
         padding: 0px;
      }

      tr.Row:nth-child(odd)
      {
         background-color: #ebf2f8;
      }

      tr.Row:nth-child(odd) td
      {
         background-color: #ebf2f8;
      }

      .LoginActivity
      {
         display: none;
      }

      .ToggleLoginActivity
      {
         font-size: small;
         text-decoration: underline;
         cursor: pointer;
      }

      img.ActivityIcon
      {
         width: 16px;
         height: 16px;
         margin-top: 1px;
         margin-right: 4px;
         vertical-align: top;
      }
   </style>
</head>
<body>
   <form runat="server">


      <p align="center">
         Back to:&nbsp; <a id="link_Menu" href="" class="Button" runat="server">Main Menu</a> |&nbsp;<a id="Link_SearchRequest" href="" class="Button" runat="server">Search Request</a> |&nbsp;<a id="link_Assignments" href="" class="Button" runat="server">Assignments</a> | <a id="Link10" href="" class="Button" runat="server">SMS</a> |&nbsp;<a id="Link6" href="" class="Button" runat="server">Future Intentions</a> |&nbsp;<a id="Link5" href="" class="Button" runat="server">Comments</a><br>
         <br>
         <p>
            &nbsp; <a href="OnlineHelp/Assignment%20Edit%20Return%20Details/Assignment_EditReturnDetails.html" title="show help for this page" target="_blank">
               <img border="0" alt="show help for this page" src="images/help.png" align="right"></a>

            <asp:PlaceHolder ID="Panel_MenuStudentMaintain" Visible="false" runat="server">
               <DECV_PROD2007:Menu_Student_maintain id="Menu_Student_maintain" runat="server" />
               &nbsp;&nbsp;
            </asp:PlaceHolder>
         </p>
      <p align="center"><a id="Link_Backtosummary" href="" class="Button" runat="server">Back to Summary</a> |&nbsp;<a id="Link_BacktoPastoralList" href="" class="Button" runat="server">Back to Student Support Group List</a></p>
      <p align="center">&nbsp;</p>


      <asp:ScriptManager runat="server" ID="smStudentActivity">
      </asp:ScriptManager>

      <asp:UpdatePanel runat="server" ID="upStudentActivity" UpdateMode="Conditional">
         <ContentTemplate>

            <table class="MainTable" border="0" style="min-width: 1250px; margin-bottom: 100px;">
               <tr>
                  <td>
                     <table class="Header" border="0">
                        <tr>
                           <td class="HeaderLeft">
                              <img src="Styles/Blueprint/Images/Spacer.gif"></td>
                           <th>Student Details</th>
                           <th class="HeaderRight">
                              <img src="Styles/Blueprint/Images/Spacer.gif"></th>
                        </tr>
                     </table>
                     <table class="Grid">
                        <tr class="Controls">
                           <td colspan="2">
                              <strong>Student</strong>
                           </td>
                           <td colspan="5">
                              <asp:Literal runat="server" ID="litStudentName"></asp:Literal> - <%: StudentID %>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td colspan="2">
                              <strong>Enrolment year</strong>
                           </td>
                           <td colspan="5">
                              <%: EnrolmentYear %>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td colspan="2">
                              <strong>My subjects</strong><br />
                              <em>Includes withdrawn and completed subjects</em>
                           </td>
                           <td colspan="5">
                              <asp:Literal runat="server" ID="litMySubjectNames"></asp:Literal>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td colspan="2">
                              <strong>Learning Advisor</strong>
                           </td>
                           <td colspan="5">
                              <asp:Literal runat="server" ID="litLearningAdvisorName"></asp:Literal>
                           </td>
                        </tr>
                        <tr class="Footer">
                           <td colspan="7">
                              &nbsp;
                           </td>
                        </tr>

                        <tr class="Header">
                           <th colspan="7">
                               <span style="padding-left: 15px;">VSV Online Activity Summary</span> <span class="ToggleLoginActivity" onclick="toggleLoginActivity();">(Click to show/hide subject login activity)</span>
                           </th>
                        </tr>
                        <tr class="Controls">
                           <td colspan="2">
                              Last VSV Online login
                           </td>
                           <td colspan="5">
                              <asp:Literal runat="server" ID="litLastLMSLogin"></asp:Literal>
                           </td>
                        </tr>

                        <tr class="Row LoginActivity">
                           <td colspan="7">
                           </td>
                        </tr>

                        <tr class="Caption LoginActivity">
                           <td colspan="2">
                              Subject
                           </td>
                           <td>
                              Last Login
                           </td>
                           <td colspan="4">
                              Status
                           </td>
                        </tr>

                        <asp:ListView runat="server" ID="lvSubjectLastLogin" ItemType="StudentSubject">
                           <LayoutTemplate>
                              <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                           </LayoutTemplate>
                           <ItemTemplate>
                              <tr class="Row LoginActivity">
                                 <td colspan="2">
                                    <%# Item.SubjectTitle %>
                                 </td>
                                 <td>
                                    <%# If(Item.LastLoginDate.HasValue(), Common.GetDateTimeDisplay(Item.LastLoginDate), "") %>
                                 </td>
                                 <td colspan="4">
                                    <%# GenerateSubjectEnrolmentStatus(Item) %>
                                 </td>
                              </tr>
                           </ItemTemplate>
                           <EmptyDataTemplate>
                              <tr class="NoRecords LoginActivity">
                                 <td colspan="7">
                                    No subject login activity found
                                 </td>
                              </tr>
                           </EmptyDataTemplate>
                        </asp:ListView>

                        <tr class="Footer">
                           <td colspan="7">
                              &nbsp;
                           </td>
                        </tr>

                        <tr class="Header">
                           <th colspan="7">
                               <span style="padding-left: 15px;">VSV Online Activities</span> <span style="font-size: small">(View the old submissions page <a href="AssignmentSubmissionListOld.aspx<%: Request.Url.Query %>">here</a>)</span>
                           </th>
                        </tr>

                        <tr class="Controls">
                           <td colspan="2">Subjects</td>
                           <td colspan="5">
                              <asp:DropDownList runat="server" ID="ddlSubjects" AutoPostBack="true">
                                 <asp:ListItem Value="" Text="All subjects"></asp:ListItem>
                                 <asp:ListItem Value="AS" Text="Active subjects only"></asp:ListItem>
                                 <asp:ListItem Value="MS" Text="My subjects only"></asp:ListItem>
                                 <asp:ListItem Value="MAS" Text="My active subjects only"></asp:ListItem>
                                 <asp:ListItem Value="-" Text="------------------------------"></asp:ListItem>
                                 <%--Individual subjects to be added here--%>
                              </asp:DropDownList>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td colspan="2">Activity</td>
                           <td colspan="5">
                              <asp:DropDownList runat="server" ID="ddlActivity" AutoPostBack="true">
                                 <asp:ListItem Value="" Text="All activity"></asp:ListItem>
                                 <asp:ListItem Value="assign" Text="Assignments"></asp:ListItem>
                                 <asp:ListItem Value="attendance" Text="Attendance"></asp:ListItem>
                                 <asp:ListItem Value="oublog" Text="Blogs"></asp:ListItem>
                                 <asp:ListItem Value="forum" Text="Forums"></asp:ListItem>
                                 <asp:ListItem Value="glossary" Text="Glossaries"></asp:ListItem>
                                 <asp:ListItem Value="hvp" Text="Interactive Content"></asp:ListItem>
                                 <asp:ListItem Value="book" Text="Learning Activity"></asp:ListItem>
                                 <asp:ListItem Value="lesson" Text="Lessons"></asp:ListItem>
                                 <asp:ListItem Value="questionnaire" Text="Questionnaires"></asp:ListItem>
                                 <asp:ListItem Value="quiz" Text="Quizzes"></asp:ListItem>
                                 <asp:ListItem Value="scorm" Text="SCORM Packages"></asp:ListItem>
                                 <asp:ListItem Value="workshop" Text="Workshops"></asp:ListItem>

                                 <%--These activities are less common and/or non-applicable as graded submissions but keep them here just in case--%>
                                 <%--<asp:ListItem Value="book" Text="Books"></asp:ListItem>
                                 <asp:ListItem Value="chat" Text="Chats"></asp:ListItem>
                                 <asp:ListItem Value="choice" Text="Choices"></asp:ListItem>
                                 <asp:ListItem Value="feedback" Text="Feedback"></asp:ListItem>
                                 <asp:ListItem Value="folder" Text="Folders"></asp:ListItem>
                                 <asp:ListItem Value="data" Text="Data"></asp:ListItem>
                                 <asp:ListItem Value="facetoface" Text="Face to face"></asp:ListItem>
                                 <asp:ListItem Value="geogebra" Text="Geogebra"></asp:ListItem>
                                 <asp:ListItem Value="label" Text="Labels"></asp:ListItem>
                                 <asp:ListItem Value="lightboxgallery" Text="Lightbox Gallery"></asp:ListItem>
                                 <asp:ListItem Value="page" Text="Page"></asp:ListItem>
                                 <asp:ListItem Value="resource" Text="Resources"></asp:ListItem>
                                 <asp:ListItem Value="subpage" Text="Subpage"></asp:ListItem>
                                 <asp:ListItem Value="url" Text="URL"></asp:ListItem>
                                 <asp:ListItem Value="wiki" Text="Wiki"></asp:ListItem>--%>
                              </asp:DropDownList>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td colspan="2">Submissions</td>
                           <td colspan="5">
                              <asp:DropDownList runat="server" ID="ddlSubmissions" AutoPostBack="true">
                                 <asp:ListItem Value="" Text="All items"></asp:ListItem>
                                 <asp:ListItem Value="RO" Text="Returned items only"></asp:ListItem>
                                 <asp:ListItem Value="UR" Text="Unreturned items only"></asp:ListItem>
                              </asp:DropDownList>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td colspan="2">Time frame</td>
                           <td colspan="5">
                              <asp:DropDownList runat="server" ID="ddlTimeFrame" AutoPostBack="true">
                                 <asp:ListItem Value="" Text="All time"></asp:ListItem>
                                 <asp:ListItem Value="LF" Text="Last two weeks only"></asp:ListItem>
                                 <asp:ListItem Value="LM" Text="Last month only"></asp:ListItem>
                              </asp:DropDownList>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td colspan="2">Sort by</td>
                           <td colspan="5">
                              <asp:DropDownList runat="server" ID="ddlSortBy" AutoPostBack="true">
                                 <asp:ListItem Value="SBJDRCV" Text="Subject and date received"></asp:ListItem>
                                 <asp:ListItem Value="DRCV" Text="Date received"></asp:ListItem>
                                 <asp:ListItem Value="DRTN" Text="Date returned"></asp:ListItem>
                              </asp:DropDownList>
                           </td>
                        </tr>
                        <tr class="Controls">
                           <td colspan="2">
                              Matching activities
                           </td>
                           <td colspan="5">
                              <%= dpStudentActivity.TotalRowCount  %>
                           </td>
                        </tr>

                        <tr class="Row">
                           <td colspan="7">
                           </td>
                        </tr>

                        <tr class="Caption">
                           <td>
                              Subject ID
                           </td>
                           <td>
                              Subject
                           </td>
                           <td>
                              Activity Type
                           </td>
                           <td>
                              Activity
                           </td>
                           <td>
                              Last Received
                           </td>
                           <td>
                              Last Returned
                           </td>
                           <td>
                              Returned By
                           </td>
                        </tr>

                        <asp:ListView runat="server" ID="lvStudentActivity" DataSourceID="sqldsStudentActivity">
                           <LayoutTemplate>
                              <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                           </LayoutTemplate>
                           <ItemTemplate>
                              <tr class="Row">
                                 <td>
                                    <%# Eval("SubjectID") %>
                                 </td>
                                 <td>
                                    <%# Eval("Subject") %>
                                 </td>
                                 <td>
                                    <%# GetLMSActivityTypeDisplayName(Eval("ActivityType").ToString()) %>
                                 </td>
                                 <td>
                                    <p>
                                       <%# GenerateLMSActivityHTML(Eval("ActivityId").ToString(), Eval("ActivityType").ToString(), Eval("Activity").ToString()) %>
                                    </p>
                                 </td>
                                 <td>
                                    <%# Common.GetDateDisplay(Eval("LastReceived")) %>
                                 </td>
                                 <td>
                                    <%# GetReturnedDisplayDate(Eval("ActivityType").ToString(), Common.GetDateDisplay(Eval("LastReturned"))) %>
                                 </td>
                                 <td>
                                    <%# GetReturnedByID(Eval("ReturnedBy").ToString()) %>
                                 </td>
                              </tr>
                           </ItemTemplate>
                           <EmptyDataTemplate>
                              <tr class="NoRecords">
                                 <td colspan="7">
                                    No matching activity found
                                 </td>
                              </tr>
                           </EmptyDataTemplate>
                        </asp:ListView>

                        <tr class="Footer">
                           <td colspan="7">
                              <asp:DataPager runat="server" ID="dpStudentActivity" PagedControlID="lvStudentActivity" PageSize="50">
                                 <Fields>
                                    <asp:NextPreviousPagerField ShowFirstPageButton="true" FirstPageText="First" ShowNextPageButton="false" />
                                    <asp:NumericPagerField  />
                                    <asp:TemplatePagerField>
                                       <PagerTemplate>
                                          of <%# (Container.TotalRowCount + Container.PageSize) \ Container.PageSize %>
                                       </PagerTemplate>
                                    </asp:TemplatePagerField>
                                    <asp:NextPreviousPagerField ShowLastPageButton="true" LastPageText="Last" ShowPreviousPageButton="false" />
                                 </Fields>
                              </asp:DataPager>
                           </td>
                        </tr>

                     </table>
                  </td>
               </tr>
            </table>

            <asp:SqlDataSource runat="server" ID="sqldsStudentActivity" ConnectionString="<%$ appSettings:connDECVAPIPRODString %>"
               CancelSelectOnNullParameter="false" SelectCommand="">
               <SelectParameters>
                  <asp:QueryStringParameter DbType="Decimal" Name="studentID" QueryStringField="STUDENT_ID" />
                  <asp:QueryStringParameter DbType="Int32" Name="enrolmentYear" QueryStringField="ENROLMENT_YEAR" />
                  <asp:ControlParameter DbType="String" Name="activityType" ControlID="ddlActivity" PropertyName="SelectedValue" />
               </SelectParameters>
            </asp:SqlDataSource>

         </ContentTemplate>
      </asp:UpdatePanel>

      <script type="text/javascript">
         function toggleLoginActivity()
         {
            jQuery(".LoginActivity").toggle();
         }
      </script>
   </form>
</body>
</html>

<!--End ASPX page-->

