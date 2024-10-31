using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using DECV_PROD2007.Security;
using DECV_PROD2007.Data;
using System.Diagnostics;

public partial class _Default : System.Web.UI.Page
{
    const string NO_DO_NOT_SEND = "No. Do not send";
    const string YES_SEND_WARNING = "Yes. Send Warning";

    const string NO_DO_NOT_CANCEL = "No. Do not cancel";
    const string YES_CANCEL = "Yes - Cancel";

    const string gsHeadingsNonVCE = "|Subject ID|Subject|Student ID|Name|Subject Status|Assignments Submitted|";
    const string gsHeadingsVCE = "|Subject ID|Subject|Student ID|Name|Subject Status|Assignments Submitted|Send Warning Choice|Warning Choice Date|Warning Sent Date|Cancellation Sent Date|Cancellation Choice|Cancellation Choice Date|";

    string SQL_YEAR = "2014"; // "year(getdate())";
    string SearchDefaultingOnly = "";
    string SearchCurrentAndDefaulting = "";
    string Semester = "1";

    DateTime currentDateTime = new DateTime(2015, 8, 25);
    string qDate = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Page.IsPostBack == false)
        //{
        SQL_YEAR = DateTime.Now.Year.ToString();
        string login = DBUtility.UserLogin.ToString().ToUpper();
        string staffID = DBUtility.UserLogin.ToString().ToUpper();
        //string staffID = "CEWING";
        //string staffID = "LEKING";
        //string login = "LDAGOSTI";
        //string login = "LMANOV";
        //string staffID = "LDAGOSTI";
        //string staffID = "LMANOV";
        //Response.Redirect("login.aspx");
        if (staffID == "") Response.Redirect("login.aspx?ReturnUrl=SMAP.aspx");

        string r = "";

        if (Request.Form["STAFF_ID"] != null)
        {
            staffID = Request.Form["STAFF_ID"].ToString().Trim();
        }

        //Response.Write(SQL_YEAR);


        if (DateTime.Now.Month > 5) Semester = "2";

        string SetDateButton = Request.Form["SetDateButton"];
        string SetWarningDateButton = Request.Form["SetWarningDateButton"];
        string SetCancellationButton = Request.Form["SetCancellationButton"];

        if (SetDateButton != null || SetWarningDateButton != null || SetCancellationButton != null)
            qDate = Request.Form["Date"];
        else
            qDate = Request.QueryString["Date"];

        //bool validQDate = false;
        DateTime inputDate = new DateTime();
        if (DateTime.TryParse(qDate, out inputDate))
        {
            currentDateTime = inputDate;

            string subjectID = Request.Form["SUBJECT_ID"];
            string studentID = Request.Form["STUDENT_ID"];

            string ClearAllWarningsButton = Request.Form["ClearAllWarningsButton"];


            if (SetWarningDateButton != null && subjectID != null && studentID != null) SetWarningForTesting(subjectID, studentID, staffID);
            if (SetCancellationButton != null && subjectID != null && studentID != null) SetCancellationForTesting(subjectID, studentID, staffID);

        }
        else
        {
            currentDateTime = DateTime.Now;
        }

        //Response.Write("Staff Login: " + staffID + "<br/>");
        //Response.Write("Today's date: " + currentDateTime.ToShortDateString());


        //if (Request.Form["SearchOptions"] == "SearchDefaultingOnly") SearchDefaultingOnly = "CHECKED";
        if (Request.Form["SearchOptions"] == "SearchCurrentAndDefaulting")
        {
            SearchDefaultingOnly = "";
            SearchCurrentAndDefaulting = "CHECKED";
        }
        else
        {
            SearchDefaultingOnly = "CHECKED";
            SearchCurrentAndDefaulting = "";
        }


        Stopwatch stopwatch = Stopwatch.StartNew();
        foreach (string key in Request.Form)
        {
            if (key.IndexOf("Warn_") > -1 || key.IndexOf("Cancel_") > -1)
            {
                //Response.Write(key + "=" + Request.Form[key]);
                string[] keys = key.Split('_');

                string type = keys[0].ToString();
                string subjectID = keys[1].ToString();
                string studentID = keys[2].ToString();
                string status = Request.Form[key];

                if (status != "NULL")
                {
                    if (type == "Warn")
                    {
                        SetWarningChoice(subjectID, studentID, status, staffID, login);
                    }
                    else if (type == "Cancel")
                    {
                        SetCancellationChoice(subjectID, studentID, status, staffID, login);
                    }
                }
            }

        }
        stopwatch.Stop();
        //Response.Write("<br/>Update Time: " + stopwatch.Elapsed.Seconds.ToString() + " seconds&nbsp;&nbsp;&nbsp;&nbsp;");


        bool searchVisible = (login.Contains("LDAGOSTI") || login.Contains("LNIGRO")) ? true : false;
        r += RenderSearch(searchVisible, staffID);

        r += "  <form method='POST' name='data' action='SMAP.aspx?Date=" + qDate + "'>";

        DataTable dtLoginSMAP = GetStudentData(staffID, SearchCurrentAndDefaulting);
        if (dtLoginSMAP != null) r += RenderTable(dtLoginSMAP, "", staffID);

        r += "  </form>";

        r += "<br/><br/>";

        //DataTable dtSMAP = GetStudentData("", SearchCurrentAndDefaulting);
        //r += RenderTable(dtSMAP, "CAULD");
        Response.Write(r);

    }

    private bool SetWarningChoice(string subjectID, string studentID, string status, string staffID, string login)
    {
        if(staffID != "" && login != ""){
            string sql = "";
            sql += "  INSERT INTO STUDENT_SUBJECT_SMAP_STATUS ";
            sql += "  SELECT " + studentID + "," + SQL_YEAR + "," + subjectID + ",'" + status + "','" + staffID + "','" + login + "','" + DataAccess.DateToSQL(currentDateTime) + "'";
            sql += "  WHERE 0 = ";
            sql += " (";
            sql += "  SELECT count(*) ";
            sql += "  FROM STUDENT_SUBJECT_SMAP_STATUS ";
            sql += "  WHERE ENROLMENT_YEAR = " + SQL_YEAR;
            sql += "  AND SUBJECT_ID = " + subjectID;
            sql += "  AND STUDENT_ID = " + studentID;
            sql += "  AND STATUS_CHANGE IN ('A','I') ";
            sql += "  AND STAFF_ID = '" + staffID + "'";
            sql += " )";
            DataAccess.ExecuteNonQuery(sql);

            sql = "  UPDATE STUDENT_SUBJECT_SMAP_STATUS SET STATUS_CHANGE = '" + status + "', LAST_ALTERED_DATE = '" + DataAccess.DateToSQL(currentDateTime) + "' ";
            sql += "  WHERE ENROLMENT_YEAR = " + SQL_YEAR;
            sql += "  AND SUBJECT_ID = " + subjectID;
            sql += "  AND STUDENT_ID = " + studentID;
            sql += "  AND STATUS_CHANGE IN ('A','I') ";
            sql += "  AND STAFF_ID = '" + staffID + "'";
            DataAccess.ExecuteNonQuery(sql);

            sql = "  INSERT INTO STUDENT_SUBJECT_SMAP_LOG ";
            sql += " SELECT " + studentID + "," + SQL_YEAR + "," + subjectID + ",'" + status + "','" + staffID + "','" + login + "','" + DataAccess.DateToSQL(currentDateTime) + "'";
            DataAccess.ExecuteNonQuery(sql);

            // Need to also set DEFAULTING_STATUS status and DEFAULTING_STATUS_DATE on student_subject record.
            sql = "   UPDATE STUDENT_SUBJECT ";
            sql += "  SET DEFAULTING_STATUS = '" + status + "', DEFAULTING_STATUS_DATE = '" + DataAccess.DateToSQL(currentDateTime) + "'";
            sql += "  WHERE ENROLMENT_YEAR = " + SQL_YEAR;
            sql += "  AND SUBJECT_ID = " + subjectID;
            sql += "  AND STUDENT_ID = " + studentID;
            sql += "  AND STAFF_ID = '" + staffID + "'";
            sql += "  AND SEMESTER IN ('B','" + Semester + "')";

            DataAccess.ExecuteNonQuery(sql);

            return true;
        }

        Response.Write("<br/>An error occurred.<br/>");
        return false;

    }

    private bool SetWarningForTesting(string subjectID, string studentID, string staffID)
    {
        string sql = "";

        sql = "   UPDATE STUDENT_SUBJECT ";
        sql += "  SET WARNING_SENT_DATE = '" + DataAccess.DateToSQL(currentDateTime) + "', WARNING_LETTER = 'Y' ";
        sql += "  WHERE ENROLMENT_YEAR = " + SQL_YEAR;
        sql += "  AND SUBJECT_ID = " + subjectID;
        sql += "  AND STUDENT_ID = " + studentID;
        sql += "  AND STAFF_ID = '" + staffID + "'";
        sql += "  AND SEMESTER IN ('B','" + Semester + "')";

        DataAccess.ExecuteNonQuery(sql);

        return true;
    }

    private bool SetCancellationForTesting(string subjectID, string studentID, string staffID)
    {
        string sql = "";

        sql = "   INSERT INTO STUDENT_SUBJECT_SMAP_CANCELLATION ";
        sql += "  SELECT " + studentID + " AS STUDENT_ID, ";
        sql += "  " + SQL_YEAR + " AS ENROLMENT_YEAR, ";
        sql += "  " + subjectID + " AS SUBJECT_ID, ";
        sql += "  '" + DataAccess.DateToSQL(currentDateTime) + "' AS CancellationDate, ";
        sql += "  '" + staffID + "' AS LAST_ALTERED_BY, ";
        sql += "  '" + DataAccess.DateToSQL(DateTime.Now) + "' AS LAST_ALTERED_DATE";

        DataAccess.ExecuteNonQuery(sql);

        return true;
    }


    private bool SetCancellationChoice(string subjectID, string studentID, string status, string staffID, string login)
    {
        if (staffID != "" && login != "")
        {
            string sql = "";
            sql += "  INSERT INTO STUDENT_SUBJECT_SMAP_STATUS ";
            sql += "  SELECT " + studentID + "," + SQL_YEAR + "," + subjectID + ",'" + status + "','" + staffID + "','" + login + "','" + DataAccess.DateToSQL(currentDateTime) + "'";
            sql += "  WHERE 0 = ";
            sql += "  (";
            sql += "  SELECT count(*) ";
            sql += "  FROM STUDENT_SUBJECT_SMAP_STATUS ";
            sql += "  WHERE ENROLMENT_YEAR = " + SQL_YEAR;
            sql += "  AND SUBJECT_ID = " + subjectID;
            sql += "  AND STUDENT_ID = " + studentID;
            sql += "  AND STATUS_CHANGE IN ('C','N') ";
            sql += "  AND STAFF_ID = '" + staffID + "'";
            sql += "  )";
            DataAccess.ExecuteNonQuery(sql);

            sql = "  UPDATE STUDENT_SUBJECT_SMAP_STATUS SET STATUS_CHANGE = '" + status + "', LAST_ALTERED_DATE = '" + DataAccess.DateToSQL(currentDateTime) + "' ";
            sql += "  WHERE ENROLMENT_YEAR = " + SQL_YEAR;
            sql += "  AND SUBJECT_ID = " + subjectID;
            sql += "  AND STUDENT_ID = " + studentID;
            sql += "  AND STATUS_CHANGE IN ('C','N') ";
            sql += "  AND STAFF_ID = '" + staffID + "'";
            DataAccess.ExecuteNonQuery(sql);

            sql = "  INSERT INTO STUDENT_SUBJECT_SMAP_LOG ";
            sql += "  SELECT " + studentID + "," + SQL_YEAR + "," + subjectID + ",'" + status + "','" + staffID + "','" + login + "','" + DataAccess.DateToSQL(currentDateTime) + "'";
            DataAccess.ExecuteNonQuery(sql);
            return true;
        }

        Response.Write("<br/>An error occurred.<br/>");
        return false;
    }

    private string RenderSearch(bool FilterVisible, string StaffID)
    {
        string r = "";


        r += "<p align='center'><strong><a href='Menu.aspx' id='Header_LinkMenu' title='go to Main Menu'>Back to Main Menu</a></strong>&nbsp;&nbsp;<img id='ImageLogo' border='0' name='ImageLogo' alt='DECV Logo' src='images/logosm.gif'>&nbsp;LIVE&nbsp;<strong><a href='Login.aspx?Logout=True' id='Header_linkLogout'>Logout</a></strong></p>";

        r += "  <table border='0' cellspacing='0' cellpadding='0' align='center'>";
        r += "    <tr>";
        r += "      <td valign='top'>";

        r += " <form method='POST' name='search' id='search' action='SMAP.aspx?Date=" + qDate + "'>";
        r += "  <table border='0' cellspacing='0' cellpadding='0' align='center'";
        if (!FilterVisible) r += " style='display:none;'";
        r += ">";
        r += "    <tr>";
        r += "      <td valign='top'>";
        r += "        <table class='Header' border='0' cellspacing='0' cellpadding='0'>";
        r += "          <tr>";
        r += "            <td class='HeaderLeft'><img border='0' src='Styles/Blueprint/Images/Spacer.gif'></td> ";
        r += "            <th>Search Students Subject Filter</th>";
        r += "            <td class='HeaderRight'><img border='0' src='Styles/Blueprint/Images/Spacer.gif'></td>";
        r += "          </tr>";
        r += "        </table>";
        r += "          <table class='Record' cellspacing='0' cellpadding='0'>";
        r += "          <tr class='Controls'>";
        r += "            <th><nobr>Defaulting Status&nbsp;</nobr></th>";
        r += "            <td>";
        r += "              <span id='Student_SubjectStatus_searchs_DefaultingFlag'>";
        r += "                  <input id='SearchDefaultingOnly' type='radio' name='SearchOptions' value='SearchDefaultingOnly' " + SearchDefaultingOnly + " />";
        r += "                  <label for='SearchDefaultingOnly'><strong>Defaulting Only</strong></label>";
        r += "                  <input id='SearchCurrentAndDefaulting' type='radio' name='SearchOptions' value='SearchCurrentAndDefaulting' " + SearchCurrentAndDefaulting + " />";
        r += "                  <label for='SearchCurrentAndDefaulting'>Current, Defaulting AND Withdrawn</label>";
        //r += "                  <input id='Student_SubjectStatus_searchs_DefaultingFlag_2' type='radio' name='Student_SubjectStatus_searchs_DefaultingFlag' value='[CD]' />";
        //r += "                  <label for='Student_SubjectStatus_searchs_DefaultingFlag_2'>All Subject Statuses</label>";
        r += "              </span>&nbsp;";
        r += "            </td>";
        r += "          </tr>";

        r += "          <tr class='Controls'>";
        r += "            <th>Teacher&nbsp;</th>";
        r += "            <td>";
        r += "                <SELECT id='TeacherSelection' name='STAFF_ID'>";

        DataTable dtTeachers = DataAccess.GetTable("SELECT rtrim(STAFF_ID) AS Value, dbo.ProperCase(rtrim(SURNAME)) + ', ' + dbo.ProperCase(rtrim(FIRSTNAME)) AS Display FROM STAFF WHERE TEACHER_FLAG = 1 AND STATUS = 1 ORDER BY SURNAME");
        foreach (DataRow drTeacher in dtTeachers.Rows)
        {
            r += "<option value='" + drTeacher["Value"].ToString() + "'";
            if (drTeacher["Value"].ToString().ToLower() == StaffID.ToLower()) r += " SELECTED ";
            r += ">" + drTeacher["Display"].ToString() + "</option>";
        }

        r += "                </SELECT>";
                    
        r += "            </td>";
        r += "          </tr>";


        r += "          <tr class='Bottom'>";
        r += "            <td></td> ";
        r += "            <td align='right'>";
        r += "              <div id='divSearchingMessage' style='display:none;float:right;'>Searching....</div>";
        r += "              <input name='Student_SubjectStatus_searchButton_DoSearch' type='submit' id='Student_SubjectStatus_searchButton_DoSearch' class='Button' value='Search' onclick=\"javascript:this.style.display = 'none';document.getElementById('divSearchingMessage').style.display = 'block';\" /></td>";
        r += "          </tr>";
        r += "        </table>";
        r += "</form>";
        r += "      </td>";

        r += "    </tr>";
        r += "  </table>";

        r += "      </td>";

        //r += "      <td width='5%'>";
        //r += "      </td>";

        //r += "      <td valign='top'>";

        //r += "          <table class='Record' cellspacing='0' cellpadding='0'>";
        //r += "          <tr class='Controls'>";
        //r += "            <td>";
        //r += " Warning e-mails will be sent on Thursday 23/4/2015. <br/>";
        //r += " Student submissions will be required by Monday 4/5/2015. <br/>";
        //r += " Cancellation e-mails will be sent on Tuesday 28/4/2015. <br/>";
        //r += " Cancellation will occur on Thursday 30/4/2015. <br/>";

        //r += "            </td>";
        //r += "          </tr>";
        //r += "        </table>";

        //r += "      </td>";
        r += "    </tr>";
        r += "  </table>";


        r += "  <br/>";
        r += "  <br/>";

        return r;
    }


    private DataTable GetStudentData(string StaffID, string SearchCurrentAndDefaulting = "")
    {
        if (SearchCurrentAndDefaulting == "CHECKED") SearchCurrentAndDefaulting = ",'C','W'";

        string sql = "SELECT DISTINCT * FROM (";
        sql += " SELECT ";
        sql += "     ss.SUBJECT_ID AS [Subject ID],";
        sql += "     rtrim(su.SUBJECT_ABBREV) + ' - ' + dbo.ProperCase(rtrim(su.SUBJECT_Title)) AS Subject,";
        sql += "     st.STUDENT_ID AS [Student ID],";
        //sql += "     rtrim(st.FIRST_NAME) + ' ' + rtrim(st.SURNAME) + '<br/><a href=''''''>' + lower(st.STUDENT_EMAIL) + '</a>' AS Name,";
        sql += "     rtrim(st.FIRST_NAME) + ' ' + rtrim(st.SURNAME) AS Name,";
        //sql += "     rtrim(su.SUBJECT_ABBREV) AS Code,";
        sql += "     (CASE WHEN ss.SUBJ_ENROL_STATUS = 'W' THEN 'W</br>' + cast(day(ss.WITHDRAWAL_DATE) as nvarchar(12)) + '/' + cast(month(ss.WITHDRAWAL_DATE) as nvarchar(12)) + '/' + cast(year(ss.WITHDRAWAL_DATE) as nvarchar(12)) ELSE ss.SUBJ_ENROL_STATUS END) AS [Subject<br/>Status],";
        sql += "     cast(NUM_ASSMT_SUBMISSIONS as nvarchar(2)) + '<br/>' + replace(replace(dbo.AssignmentSubmissionList(st.STUDENT_ID, ss.SUBJECT_ID), '[', '<del>'),']','</del>') AS [Assignments Submitted],";
        sql += "     CASE ss.DEFAULTING_STATUS WHEN 'I' THEN 'Yes. Send Warning' ";     // I
        sql += "         WHEN 'A' THEN 'No. Do not send' ";                             // A
        sql += "         ELSE ss.DEFAULTING_STATUS";
        sql += "     END AS [Send Warning Choice],";
        //sql += "     CASE WHEN ss.DEFAULTING_STATUS_DATE IS NULL THEN '' ELSE CAST(Day(ss.DEFAULTING_STATUS_DATE) as nvarchar(4)) + '/' + CAST(month(ss.DEFAULTING_STATUS_DATE) as nvarchar(4)) + '/' + CAST(year(ss.DEFAULTING_STATUS_DATE) as nvarchar(4)) END AS [Warning<br/>Choice Date],";
        //sql += "     (SELECT TOP 1 CAST(day(LAST_ALTERED_DATE) AS nvarchar(2)) + '/' + CAST(month(LAST_ALTERED_DATE) AS nvarchar(2)) + '/' + CAST(year(LAST_ALTERED_DATE) AS nvarchar(4)) FROM STUDENT_SUBJECT_SMAP_STATUS WHERE STUDENT_ID = st.STUDENT_ID AND SUBJECT_ID = ss.SUBJECT_ID AND ENROLMENT_YEAR = " + SQL_YEAR + " AND STATUS_CHANGE IN ('I','A') ORDER BY LAST_ALTERED_DATE DESC) AS [Warning<br/>Choice Date],";
        sql += "     CAST(day(ss.DEFAULTING_STATUS_DATE) AS nvarchar(2)) + '/' + CAST(month(ss.DEFAULTING_STATUS_DATE) AS nvarchar(2)) + '/' + CAST(year(ss.DEFAULTING_STATUS_DATE) AS nvarchar(4)) AS [Warning<br/>Choice Date],";

        //sql += "     CASE WHEN ss.WARNING_LETTER = 'Y' THEN 'Yes' ELSE '' END AS [Warning Letter Sent],";
        sql += "     CAST(day(ss.WARNING_SENT_DATE) AS nvarchar(2)) + '/' + CAST(month(ss.WARNING_SENT_DATE) AS nvarchar(2)) + '/' + CAST(year(ss.WARNING_SENT_DATE) AS nvarchar(4)) AS [Warning<br/>Sent Date],";
        sql += "     dbo.ProperCase(rtrim(sf.FIRSTNAME) + ' ' + rtrim(sf.Surname)) AS Teacher,";
        sql += "     rtrim(sf.STAFF_ID) AS STAFF_ID,";
        sql += "     (SELECT TOP 1 CAST(Day(CancellationDate) as nvarchar(4)) + '/' + CAST(month(CancellationDate) as nvarchar(4)) + '/' + CAST(year(CancellationDate) as nvarchar(4)) FROM STUDENT_SUBJECT_SMAP_CANCELLATION WHERE STUDENT_ID = st.STUDENT_ID AND ENROLMENT_YEAR = " + SQL_YEAR + " AND SUBJECT_ID = ss.SUBJECT_ID ORDER BY CancellationDate DESC) AS [Cancellation<br/>Sent Date],";

        sql += "     CASE WHEN (SELECT TOP 1 STATUS_CHANGE FROM STUDENT_SUBJECT_SMAP_STATUS WHERE STATUS_CHANGE IN ('C','N') AND ENROLMENT_YEAR = " + SQL_YEAR + " AND STUDENT_ID = st.STUDENT_ID AND SUBJECT_ID = su.SUBJECT_ID ORDER BY LAST_ALTERED_DATE DESC) = 'N' THEN '" + NO_DO_NOT_CANCEL + "' ";
        sql += "          WHEN (SELECT TOP 1 STATUS_CHANGE FROM STUDENT_SUBJECT_SMAP_STATUS WHERE STATUS_CHANGE IN ('C','N') AND ENROLMENT_YEAR = " + SQL_YEAR + " AND STUDENT_ID = st.STUDENT_ID AND SUBJECT_ID = su.SUBJECT_ID ORDER BY LAST_ALTERED_DATE DESC) = 'C' THEN '" + YES_CANCEL + "' ";
        sql += "          ELSE NULL END AS [Cancellation Choice],";

        sql += "     (SELECT TOP 1 CAST(Day(LAST_ALTERED_DATE) as nvarchar(4)) + '/' + CAST(month(LAST_ALTERED_DATE) as nvarchar(4)) + '/' + CAST(year(LAST_ALTERED_DATE) as nvarchar(4)) FROM STUDENT_SUBJECT_SMAP_STATUS WHERE STATUS_CHANGE IN ('C','N') AND ENROLMENT_YEAR = " + SQL_YEAR + " AND STUDENT_ID = st.STUDENT_ID AND SUBJECT_ID = su.SUBJECT_ID ORDER BY LAST_ALTERED_DATE DESC) AS [Cancellation<br/>Choice Date],";
        //sql += "     '' AS [Cancellation<br/>Choice Date],";
        sql += "     CASE WHEN ss.WITHDRAWAL_DATE IS NULL THEN '' ELSE CAST(Day(ss.WITHDRAWAL_DATE) as nvarchar(4)) + '/' + CAST(month(ss.WITHDRAWAL_DATE) as nvarchar(4)) + '/' + CAST(year(ss.WITHDRAWAL_DATE) as nvarchar(4)) END AS [Withdrawal<br/>Date],";
        //sql += "     ss.WITHDRAWAL_DATE AS [Withdrawal<br/>Date]";
        sql += "     su.YEAR_LEVEL,";
        sql += "     lower(st.STUDENT_EMAIL) AS STUDENT_EMAIL,";
        sql += "     rtrim(sf.SURNAME) AS StaffSurname";
        sql += " FROM STUDENT st ";
        sql += " LEFT JOIN STUDENT_ENROLMENT se ON st.STUDENT_ID = se.STUDENT_ID";
        sql += " LEFT JOIN STUDENT_SUBJECT ss ON se.STUDENT_ID = ss.STUDENT_ID";
        sql += " LEFT JOIN SUBJECT su ON ss.SUBJECT_ID = su.SUBJECT_ID";
        sql += " LEFT JOIN STAFF sf ON sf.STAFF_ID = ss.STAFF_ID";
        sql += " WHERE se.ENROLMENT_YEAR = " + SQL_YEAR + "";
        sql += " AND ss.ENROLMENT_YEAR = " + SQL_YEAR + "";
        sql += " AND se.ENROLMENT_STATUS = 'E'";
        sql += " AND ss.SUBJ_ENROL_STATUS IN ('D'" + SearchCurrentAndDefaulting + ") ";
        //sql += " AND ss.DEFAULTING_STATUS = 'I'";
        //sql += " AND ss.WARNING_LETTER = 'Y'";
        //sql += " AND su.YEAR_LEVEL > 10";
        sql += " AND ss.SEMESTER IN ('B','" + Semester + "')";
        if (StaffID != "") sql += " AND rtrim(ss.STAFF_ID) = '" + StaffID + "' ";

        // This provides an override to display students with a current status on a defaulting only search, if "Yes - Cancel" had been selected.
        if(SearchCurrentAndDefaulting == ""){
            sql += "  OR (ss.WARNING_SENT_DATE IS NOT NULL AND 0 < ";
            sql += "  (";
            sql += "  SELECT count(*) ";
            sql += "  FROM STUDENT_SUBJECT_SMAP_STATUS sss LEFT JOIN STUDENT_SUBJECT sts ON sts.SUBJECT_ID = sss.SUBJECT_ID AND sts.STUDENT_ID = sss.STUDENT_ID AND sts.ENROLMENT_YEAR = sts.ENROLMENT_YEAR ";
            sql += "  WHERE sss.ENROLMENT_YEAR = " + SQL_YEAR;
            sql += "  AND sss.STUDENT_ID = ss.STUDENT_ID";
            sql += "  AND sss.SUBJECT_ID = ss.SUBJECT_ID";
            sql += "  AND sss.STATUS_CHANGE IN ('C') ";
            sql += "  AND sss.STAFF_ID = '" + StaffID + "'";
            sql += "  AND sts.STAFF_ID = '" + StaffID + "'";
            sql += "  AND ss.STAFF_ID = '" + StaffID + "'";
            sql += "  AND sts.ENROLMENT_YEAR = " + SQL_YEAR + "";
            sql += "  AND ss.ENROLMENT_YEAR = " + SQL_YEAR + "";
            sql += "  AND sts.SEMESTER = '" + Semester + "'";
            sql += "  AND ss.SEMESTER = '" + Semester + "'";
            sql += "  AND sts.SUBJ_ENROL_STATUS IN ('C')";
            sql += "  AND ss.SUBJ_ENROL_STATUS IN ('C')";
            sql += "  )) ";
        }

        sql += ") k ";


        //sql += " ORDER BY sf.SURNAME ASC, ss.SUBJ_ENROL_STATUS DESC ";
        sql += " ORDER BY StaffSurname ASC, Subject, [Subject<br/>Status] DESC ";

        //Response.Write(SQL_YEAR);

        //Response.Write("<br/>" + sql);
        Stopwatch stopwatch = Stopwatch.StartNew();
        DataTable dtSMAP = DataAccess.GetTable(sql);
        stopwatch.Stop();
        //Response.Write("Query Time: " + stopwatch.Elapsed.Seconds.ToString() + " seconds");

        return dtSMAP;
    }

    private bool AllNonVCE(DataTable dtSMAP)
    {
        //bool allNonVCE = false;

        foreach (DataRow dr in dtSMAP.Rows)
        {
            if (Convert.ToInt32(dr["YEAR_LEVEL"].ToString()) > 10)
            {
                return false;
            }
        }

        return true;
    }

    private string RenderTable(DataTable dtSMAP, string LeaveOutStaffID = "", string EnableForStaffID = "")
    {
        bool allNonVCE = AllNonVCE(dtSMAP);

        string r = "";
        string lastTeacher = "";
        int i = 0;
        string eol = Environment.NewLine;
        string lastSubject = "";
        string lastSubjectID = "";
        string headings = gsHeadingsVCE;

        if (allNonVCE)
        {
            headings = gsHeadingsNonVCE;
        }

        // Write data.
        foreach (DataRow drSMAP in dtSMAP.Rows)
        {
            string objectString = drSMAP["Subject ID"].ToString() + "_" + drSMAP["Student ID"].ToString();

            if (LeaveOutStaffID != drSMAP["STAFF_ID"].ToString())
            {
                if (lastTeacher != drSMAP["Teacher"].ToString())
                {
                    if (lastTeacher != "")
                    {
                        r += "<td/></tr></table>" + eol;
                        r += "</table>" + eol;
                        r += "<br/>" + eol;
                        r += "<br/>" + eol;
                    }

                    lastTeacher = drSMAP["Teacher"].ToString();
                    // Write headings.
                    //r += "<table width='100%'>" + eol;
                    //r += "<tr>" + eol;
                    //r += "<td colspan='" + (dtSMAP.Columns.Count - 1).ToString() + "'>" + eol;

                    r += "<table border='0' cellspacing='0' cellpadding='0' width='100%'><tr><td>" + eol;
                    // TEACHER heading
                    r += "<table class='Header' border='0' cellspacing='0' cellpadding='0' width='100%'>" + eol;
                    r += "<tr>" + eol;
                    r += "<td class='HeaderLeft'>" + eol;
                    r += "<img border='0' src='Styles/Blueprint/Images/Spacer.gif'>" + eol;
                    r += "</td><th>" + eol;
                    r += drSMAP["Teacher"].ToString() + eol;
                    r += "</th>" + eol;
                    r += "<td class='HeaderRight'><img border='0' src='Styles/Blueprint/Images/Spacer.gif'/></td>" + eol;
                    r += "</tr>" + eol;
                    r += "</table>" + eol;


                    r += "</td>" + eol;
                    r += "</tr>" + eol;
                    r += "<tr>" + eol;
                    r += "<td>" + eol;



                    r += "<table class='Grid' cellspacing='0' cellpadding='0' width='100%'>" + eol;
                    r += "<tr class='Caption'>" + eol;
                    //r += "<td>" + eol;

                    //// Headings.
                    foreach (DataColumn dcSMAP in dtSMAP.Columns)
                    {
                        //if (dcSMAP.ColumnName != "Teacher" && dcSMAP.ColumnName != "STAFF_ID" && dcSMAP.ColumnName != "Withdrawal<br/>Date") // && dcSMAP.ColumnName != "YEAR_LEVEL")
                        if (headings.IndexOf("|" + dcSMAP.ColumnName.Replace("<br/>", " ") + "|") >= 0)
                        {
                            r += "<th>" + eol;
                            r += dcSMAP.ColumnName + eol;
                            r += "</th>" + eol;
                        }
                    }
                    r += "</tr>" + eol;
                }

                //// Data
                r += "<tr class='Row'>" + eol;

                foreach (DataColumn dcSMAP in dtSMAP.Columns)
                {
                    //if (dcSMAP.ColumnName != "Teacher" && dcSMAP.ColumnName != "STAFF_ID" && dcSMAP.ColumnName != "Withdrawal<br/>Date") // && dcSMAP.ColumnName != "YEAR_LEVEL")  // Fields to leave out of the table.
                    if (headings.IndexOf("|" + dcSMAP.ColumnName.Replace("<br/>", " ") + "|") >= 0)
                    {

                        bool validWarningChoiceDate = false;
                        DateTime WarningChoiceDate = new DateTime();
                        validWarningChoiceDate = DateTime.TryParse(drSMAP["Warning<br/>Choice Date"].ToString(), out WarningChoiceDate);

                        bool validWarningSentDate = false;
                        DateTime WarningSentDate = new DateTime();
                        validWarningSentDate = DateTime.TryParse(drSMAP["Warning<br/>Sent Date"].ToString(), out WarningSentDate);

                        bool validCancellationChoiceDate = false;
                        DateTime CancellationChoiceDate = new DateTime();
                        validCancellationChoiceDate = DateTime.TryParse(drSMAP["Cancellation<br/>Choice Date"].ToString(), out CancellationChoiceDate);

                        bool validWithdrawalDate = false;
                        DateTime WithdrawalDate = new DateTime();
                        validWithdrawalDate = DateTime.TryParse(drSMAP["Withdrawal<br/>Date"].ToString(), out WithdrawalDate);

                        bool validCancellationSentDate = false;
                        DateTime CancellationSentDate = new DateTime();
                        validCancellationSentDate = DateTime.TryParse(drSMAP["Cancellation<br/>Sent Date"].ToString(), out CancellationSentDate);


                        if (dcSMAP.ColumnName == "Send Warning Choice" && EnableForStaffID == drSMAP["STAFF_ID"].ToString())
                        {
                            r += "<td class='c'>" + eol;

                            string ASelected = "";  // A = Active (Warning Letter set to 'No - Do not Send'. SST initiated.) 
                            string ISelected = "";  // I = Inactive (Warning Letter set to 'Yes - Send Warning'. SST initiated)

                            if (!(validCancellationSentDate && validWarningChoiceDate && (WarningChoiceDate < CancellationSentDate)))
                            {
                                if (drSMAP["Send Warning Choice"].ToString() == NO_DO_NOT_SEND) ASelected = "SELECTED";
                                if (drSMAP["Send Warning Choice"].ToString() == YES_SEND_WARNING) ISelected = "SELECTED";
                            }


                            // if warning choice date is less then 5 days old 
                            // or there is a warning sent date in the past.                         
                            // do not allow editing.
                            if (
                                (
                                //(validWarningChoiceDate && (WarningChoiceDate.AddDays(5) > currentDateTime))
                                    (validWarningChoiceDate && (WarningChoiceDate.AddDays(0) > currentDateTime))
                                    || validCancellationChoiceDate
                                    || validWithdrawalDate
                                    || (validWarningSentDate && (WarningSentDate >= WarningChoiceDate))
                                )
                                    && !(validWithdrawalDate == false && validCancellationSentDate
                                          && (CancellationSentDate.AddDays(5) > currentDateTime))
                                    && ((validCancellationChoiceDate && (CancellationChoiceDate.AddDays(18) > currentDateTime))
                                            || validWarningChoiceDate && (WarningChoiceDate > CancellationChoiceDate)
                                       )
                                || ((validCancellationSentDate && validCancellationChoiceDate) && (CancellationSentDate.AddDays(2) >= currentDateTime)) // That would have displayed the Cancellation Choice.

                               )
                            {
                                if (drSMAP[dcSMAP.ColumnName].ToString() == "") r += "&nbsp;";
                                r += drSMAP[dcSMAP.ColumnName].ToString();
                            }
                            else
                            {

                                if (Convert.ToInt32(drSMAP["YEAR_LEVEL"].ToString()) > 10 && drSMAP["Subject<br/>Status"].ToString().Substring(0,1) != "W")
                                {
                                    r += "<select id='Warn_" + objectString + "' name='Warn_" + objectString + "'>" + eol;
                                    r += "<option value='NULL'>Select Value</option>" + eol;
                                    r += "<option value='A' " + ASelected + ">No - Do Not Send</option>" + eol;
                                    r += "<option value='I' " + ISelected + ">Yes - Send Warning</option>" + eol;
                                    r += "</select>" + eol;
                                }
                                else
                                {
                                    r += "&nbsp;" + eol;
                                }

                            }
                            r += "</td>" + eol;
                        }
                        else if (dcSMAP.ColumnName == "Cancellation Choice" && EnableForStaffID == drSMAP["STAFF_ID"].ToString())
                        {
                            r += "<td class='c'>" + eol;

                            string NSelected = "";  // N = No. Do not cancel.
                            string CSelected = "";  // C = Yes. Cancel.
                            if (drSMAP["Cancellation Choice"].ToString() == NO_DO_NOT_CANCEL) NSelected = "SELECTED";
                            if (drSMAP["Cancellation Choice"].ToString() == YES_CANCEL) CSelected = "SELECTED";

                            // This is conditional on "Warning Sent Date"
                            if ((validWarningSentDate && (WarningSentDate >= WarningChoiceDate))
                                 && !(validCancellationSentDate && (CancellationChoiceDate <= CancellationSentDate) )
                                || (
                                        (validCancellationChoiceDate && validWarningChoiceDate && (CancellationChoiceDate < WarningChoiceDate))
                                        && (validWarningSentDate && (WarningSentDate >= WarningChoiceDate))
                                    )
                                || ((validCancellationSentDate && validCancellationChoiceDate) && (CancellationSentDate.AddDays(2) >= currentDateTime))
                              )
                            {

                                if (Convert.ToInt32(drSMAP["YEAR_LEVEL"].ToString()) > 10 && drSMAP["Subject<br/>Status"].ToString().Substring(0, 1) != "W")
                                {
                                    r += "<select id='Cancel_" + objectString + "' name='Cancel_" + objectString + "'>" + eol;
                                    r += "<option value='NULL'>Select Value</option>" + eol;
                                    r += "<option value='N' " + NSelected + ">No - Do Not Cancel</option>" + eol;
                                    r += "<option value='C' " + CSelected + ">Yes - Cancel</option>" + eol;
                                    r += "</select>" + eol;
                                    //r += "Cancel_" + objectString;
                                }
                                else
                                {
                                    r += "&nbsp;" + eol;
                                }
                            }
                            else
                            {
                                if (drSMAP[dcSMAP.ColumnName].ToString() == "") r += "&nbsp;";
                                r += drSMAP[dcSMAP.ColumnName].ToString();
                            }

                            r += "</td>" + eol;
                        }
                        else if (dcSMAP.ColumnName == "Subject")
                        {

                            if (drSMAP[dcSMAP.ColumnName].ToString() != lastSubject)
                            {
                                r += "<td style='border-top: solid 1px; border-right: solid 1px; border-bottom: solid 0px;border-left: solid 0px;'>" + eol;
                                r += "<nobr>" + drSMAP[dcSMAP.ColumnName].ToString() + "</nobr>";
                            }
                            else
                            {
                                r += "<td style='border-top: solid 0px; border-right: solid 1px; border-bottom: solid 0px;border-left: solid 0px;'>" + eol;
                                r += "&nbsp;";
                            }
                            lastSubject = drSMAP[dcSMAP.ColumnName].ToString();
                            r += "</td>" + eol;


                        }
                        else if (dcSMAP.ColumnName == "Subject ID")
                        {

                            if (drSMAP[dcSMAP.ColumnName].ToString() != lastSubjectID)
                            {
                                r += "<td style='border-top: solid 1px; border-right: solid 1px; border-bottom: solid 0px;border-left: solid 0px;'>" + eol;
                                r += "" + drSMAP[dcSMAP.ColumnName].ToString() + "";
                            }
                            else
                            {
                                r += "<td style='border-top: solid 0px; border-right: solid 1px; border-bottom: solid 0px;border-left: solid 0px;'>" + eol;
                                r += "&nbsp;";
                            }
                            lastSubjectID = drSMAP[dcSMAP.ColumnName].ToString();
                            r += "</td>" + eol;


                        }
                        else if (dcSMAP.ColumnName == "Assignments Submitted")
                        {
                            r += "<td class='c'>" + eol;

                            if (drSMAP[dcSMAP.ColumnName].ToString().Length > 0)
                            {
                                r += "<p style='text-align:center'>" + drSMAP[dcSMAP.ColumnName].ToString() + "</p>";
                            }
                            else
                            {
                                r += "&nbsp;";
                            }
                            r += "</td>" + eol;

                        }
                        else if (dcSMAP.ColumnName == "Name")
                        {
                            r += "<td class='c'>" + eol;

                            if (drSMAP[dcSMAP.ColumnName].ToString() != lastSubjectID)
                            {
                                r += drSMAP[dcSMAP.ColumnName].ToString();
                                r += @"<br/><a href='mailto:" + drSMAP["STUDENT_EMAIL"].ToString() + "'>" + drSMAP["STUDENT_EMAIL"].ToString() + "</a>";
                            }
                            else
                            {
                                r += "&nbsp;";
                            }

                            r += "</td>" + eol;
                        }
                        else if (dcSMAP.ColumnName == "Student ID")
                        {
                            r += "<td class='c'>" + eol;

                            r += @"<a href='StudentSummary.aspx?STUDENT_ID=" + drSMAP["Student ID"].ToString() + "&ENROLMENT_YEAR=" + SQL_YEAR + "'>" + drSMAP["Student ID"].ToString() + "</a>";

                            r += "</td>" + eol;
                        }
                        else
                        {
                            r += "<td class='c'>" + eol;
                            if (drSMAP[dcSMAP.ColumnName].ToString() == "") r += "&nbsp;";
                            r += drSMAP[dcSMAP.ColumnName].ToString();
                            r += "</td>" + eol;
                        }

                    }
                }
                r += "</tr>" + eol;
            }
        }

        if (dtSMAP.Rows.Count > 0)
        {
            r += "<tr class='Footer'><td colspan='12' style='text-align:right;'>";
            r += "<div id='divSubmittingMessage' style='display:none;float:right;'>Submitting....</div>";
            r += "<div id='divReloadingMessage' style='display:none;float:right;'>Reloading....</div>";
            r += "<input type='submit' id='btnSubmit' value='Submit' name='' class='Button' onclick=\"javascript:this.style.display = 'none';document.getElementById('btnCancel').style.display = 'none';document.getElementById('divSubmittingMessage').style.display = 'block';document.data.submit();\" />";
            r += "<input type='button' id='btnCancel' value='Cancel' name='' class='Button' onclick=\"javascript:this.style.display = 'none';document.getElementById('btnSubmit').style.display = 'none';document.getElementById('divReloadingMessage').style.display = 'block';document.getElementById('search').submit();\"/>";
            r += "</td></tr>";
        }
        r += "</table>" + eol;

        r += "<p style='text-align:center;'><em>Warning and Cancellation e-mails can only be nominated for VCE students.</em></p>";

        r += "<div style='visibility: hidden;'>";
        r += "<input id='SearchDefaultingOnly' type='radio' name='SearchOptions' value='SearchDefaultingOnly' " + SearchDefaultingOnly + " />";
        r += "<input id='SearchCurrentAndDefaulting' type='radio' name='SearchOptions' value='SearchCurrentAndDefaulting' " + SearchCurrentAndDefaulting + " />";
        r += "<SELECT id='TeacherSelection' name='STAFF_ID'><OPTION value='" + EnableForStaffID + "'/></SELECT>";
        r += "</div>";

        r += "<br/>" + eol;
        r += "<br/>" + eol;

        return r;
    }



}

public static class DataAccess
{

    public static bool IsTrue(string BoolValue)
    {
        if (BoolValue == null) return false;
        BoolValue = BoolValue.ToLower();
        if (BoolValue.IndexOf("f") >= 0 || BoolValue.IndexOf("0") >= 0) return false;
        if (BoolValue.IndexOf("t") >= 0 || BoolValue.IndexOf("1") >= 0) return true;
        if (BoolValue.IndexOf("n") >= 0 || BoolValue.IndexOf("0") >= 0) return false;
        if (BoolValue.IndexOf("y") >= 0 || BoolValue.IndexOf("1") >= 0) return true;
        if (BoolValue.ToLower() == "on") return true;
        if (BoolValue.ToLower() == "off") return false;
        return false;
    }

    public static DataTable GetTable(string sql)
    {
        SqlConnection conn = null;
        try
        {

            conn = new SqlConnection(ConfigurationManager.AppSettings["connDECVPRODSQL2005String"]);
            conn.Open();

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, conn);
            cmd.CommandTimeout = 180;  // 3 mins.
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(ds);

            return ds.Tables[0];
        }
        catch (Exception ex)
        {
            Log(ex.ToString());
            //writeSQLException(ex, sql);
            return null;
        }
        finally
        {
            conn.Close();
        }
    }

    public static string GetValue(string sql, string fieldName)
    {
        DataTable tbl = GetTable(sql);
        string result = "";

        try
        {
            if (tbl.Rows.Count == 0) result = "";
            else result = tbl.Rows[0][fieldName].ToString();
        }
        catch (Exception ex)
        {
            Log(ex.ToString());
            //writeSQLException(ex, sql);
            return null;
        }

        return result;

    }

    public static bool ExecuteNonQuery(string sql)
    {
        SqlConnection conn = null;

        try
        {
            conn = new SqlConnection(ConfigurationManager.AppSettings["connDECVPRODSQL2005String"]);
            conn.Open();

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, conn);
            cmd.CommandTimeout = 420;  // 3 mins.
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Log(ex.ToString());
            //writeSQLException(ex, sql);
            return false;
        }
        finally
        {
            conn.Close();
        }

        return true;
    }

    public static string BoolToSQL(bool value)
    {
        if (value) { return "1"; } else { return "0"; };
    }

    public static string DateToSQL(DateTime value)
    {
        return value.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public static string SQLStringFormat(string value)
    {
        return value.Replace("'", "''");
    }

    public static void Log(string logMessage)
    {
        return;
        //string logfile = ConfigurationManager.AppSettings["LogFile"].ToString();
        //string ext = Path.GetExtension(logfile);
        //logfile = logfile.Replace(ext, "");
        //logfile += "_" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Day.ToString().PadLeft(2, '0') + ext;

        //using (StreamWriter w = File.AppendText(logfile))
        //{
        //    w.WriteLine("---- {0} {1} -------------------------------------------------------------------------", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
        //    w.WriteLine("{0}", logMessage);
        //}
    }

    //private static void writeSQLException(Exception ex, string sqlCommand)
    //{
    //    try
    //    {
    //        string method = "SQL";

    //        if (sqlCommand.Length > 2000) sqlCommand = sqlCommand.Substring(0, 1998);
    //        string parameters = SQLStringFormat(sqlCommand);
    //        string exception = SQLStringFormat(ex.Message);
    //        string errorcode = SQLStringFormat(ex.Source);
    //        string message = SQLStringFormat(ex.Message);

    //        string sql = "INSERT INTO SCAFFOLD_EXCEPTION (method, parameters, exception, errorcode, message) ";
    //        sql += "VALUES ('" + method + "', '" + parameters + "','" + exception + "','" + errorcode + "','" + message + "')";
    //        Log(sql);
    //        DataAccess.ExecuteNonQuery(sql);
    //    }
    //    catch (Exception ex2)
    //    {
    //        Log("EXCEPTION!!!!!!!!!! " + ex2.ToString());
    //    }

    //}

}
