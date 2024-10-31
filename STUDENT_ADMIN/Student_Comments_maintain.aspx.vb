
'Using Statements @1-82FB19C3
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Diagnostics
Imports System.Web
Imports System.IO
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Web.Security
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports DECV_PROD2007
Imports DECV_PROD2007.Data
Imports DECV_PROD2007.Security
Imports DECV_PROD2007.Configuration
Imports DECV_PROD2007.Controls
'End Using Statements

'ERA: 14-May-2014|EA| additional to handle SMTP or such.
Imports System.Configuration
Imports System.Web.Configuration
Imports DECV_PROD2007.Menu


Namespace DECV_PROD2007.Student_Comments_maintain 'Namespace @1-C4AA6A30

'Forms Definition @1-D612E6EA
Public Class [Student_Comments_maintainPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-71B894A5
    Protected STUDENT_COMMENTData As STUDENT_COMMENTDataProvider
    Protected STUDENT_COMMENTErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_COMMENTOperations As FormSupportedOperations
    Protected STUDENT_COMMENTIsSubmitted As Boolean = False
    Protected Grid_DisplayCommentsData As Grid_DisplayCommentsDataProvider
    Protected Grid_DisplayCommentsOperations As FormSupportedOperations
    Protected Grid_DisplayCommentsCurrentRowNumber As Integer
    Protected ProfilesPanelData As ProfilesPanelDataProvider
    Protected ProfilesPanelErrors As NameValueCollection = New NameValueCollection()
    Protected ProfilesPanelOperations As FormSupportedOperations
    Protected ProfilesPanelIsSubmitted As Boolean = False
    Protected Grid_DisplayComments_MyCommentsData As Grid_DisplayComments_MyCommentsDataProvider
    Protected Grid_DisplayComments_MyCommentsOperations As FormSupportedOperations
    Protected Grid_DisplayComments_MyCommentsCurrentRowNumber As Integer
    Protected Student_Comments_maintainContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-67CEE7C4
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link_BacktosummaryHref = "StudentSummary.aspx"
            item.Link_BacktoPastoralListHref = "PastoralTeacher_StudentList.aspx"
            PageData.FillItem(item)
            Link_Backtosummary.InnerText += item.Link_Backtosummary.GetFormattedValue().Replace(vbCrLf,"")
            Link_Backtosummary.HRef = item.Link_BacktosummaryHref+item.Link_BacktosummaryHrefParameters.ToString("GET","", ViewState)
            Link_Backtosummary.DataBind()
            Link_BacktoPastoralList.InnerText += item.Link_BacktoPastoralList.GetFormattedValue().Replace(vbCrLf,"")
            Link_BacktoPastoralList.HRef = item.Link_BacktoPastoralListHref+item.Link_BacktoPastoralListHrefParameters.ToString("None","", ViewState)
            Link_BacktoPastoralList.DataBind()
            STUDENT_COMMENTShow()
            Grid_DisplayCommentsBind
            ProfilesPanelShow()
            Grid_DisplayComments_MyCommentsBind
    End If
'End Page_Load Event BeforeIsPostBack

 

            'Panel Panel_MenuStudentMaintain Event BeforeShow. Action Custom Code @42-73254650
            ' -------------------------
               'ERA: if in the proper groups then display Maintain panel (eg: 8 doesn't see it but 9 does.
    			'23-July-2015|EA| convert to global setting incase we need to add a new group in future
				dim strHigherGroups as String = System.Configuration.ConfigurationManager.AppSettings("strHigherSecurityGroups") 
			    dim arrHigherGroups as String() = strHigherGroups.split(",")
				 'If (DBUtility.AuthorizeUser(New String(){"2","3","4","5","6","7","9","12"})) Then
				 If (DBUtility.AuthorizeUser(arrHigherGroups)) Then
			            Panel_MenuStudentMaintain.visible = true
			     End If
            ' -------------------------
            'End Panel Panel_MenuStudentMaintain Event BeforeShow. Action Custom Code

            'Page Student_Comments_maintain Event BeforeShow. Action Custom Code @33-73254650
            ' -------------------------
            ' ERA: Collect this user's list of Access Groups and put into Session Var "AccessGroups", if not there already
            ' ERA: 5/Sept/2008|EA| added extra link to Pastoral Care list Link_BacktoPastoralList
            ' ERA: 19/Feb/2010|EA| show the ProfilePanel if Student SupportTeacher
            If String.IsNullOrEmpty(Session("AccessGroups")) Then
                Session("AccessGroups") = Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("exec sps_GetUserAccessFunctions " & Settings.connDECVPRODSQL2005DataAccessObject.ToSql(Session("UserID").ToString(), FieldType._Text, True))
            End If

            Dim boolAccessGroupM As Boolean = Session("AccessGroups").ToString.Contains("M")
            ' 24 Mar 2021|RW| Allow access for tutors, who are not currently assigned explicitly to any students on the database but need to add comments
            Dim accessGroupU = Session("AccessGroups").ToString.Contains("U")

            'ERA: 21-Aug-2009|EA| kinda duplicate above to check if the User is one of the Student's current Teachers, and allow Add as well, per DB meeting 17 Aug 2009
            Dim tmpTeacherID As Integer = -1
            tmpTeacherID = Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(STAFF_ID) FROM STUDENT_SUBJECT WHERE STAFF_ID <> 'N-A' AND enrolment_year = " & Settings.connDECVPRODSQL2005DataAccessObject.ToSql(System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR"), FieldType._Integer, True) & " AND STUDENT_ID = " & Settings.connDECVPRODSQL2005DataAccessObject.ToSql(System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"), FieldType._Text, True) & " AND STAFF_ID = '" & (DBUtility.UserId.ToString.ToUpper()) & "'")

            'ERA: original Pastoral care check - this will be used if the Teacher is also the Pastoral care teacher
            ' 5 Mar 2021|RW| Allow access for the SSG Facilitator
            Dim tmpAuthIDs As String = ""
            tmpAuthIDs = Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT concat(rtrim(isnull(pastoral_care_id,'N-A')), ',', rtrim(isnull(SSG_FACILITATOR_ID, 'N-A'))) FROM student_enrolment WHERE enrolment_year = " & Settings.connDECVPRODSQL2005DataAccessObject.ToSql(System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR"), FieldType._Integer, True) & " AND STUDENT_ID = " & Settings.connDECVPRODSQL2005DataAccessObject.ToSql(System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"), FieldType._Text, True))
            Dim authIDs = tmpAuthIDs.ToString().ToUpper().Split({","c}, StringSplitOptions.RemoveEmptyEntries)
            Dim dbUser = DBUtility.UserId.ToString.ToUpper().Trim()

            'if the user is in the correct access group, or they are the Pastoral Care teacher or SSG Facilitator for this year, then allow Adding
            ' 21-Aug-2009|EA| and check the Teacher ID, rest of code is the same
            ' 5 Mar 2021|RW| Allow access for the SSG Facilitator
            ' 24 Mar 2021|RW| Allow access for tutors, who are not currently assigned explicitly to any students on the database but need to add comments
            If (boolAccessGroupM) OrElse authIDs.Contains(dbUser) OrElse (tmpTeacherID > 0) OrElse accessGroupU Then
                STUDENT_COMMENTHolder.Visible = True
                'Panel_MenuStudentMaintain.visible = true
                Link_BacktoSummary.visible = (Not Panel_MenuStudentMaintain.visible)    ' show the plain link if the menu isn't there
                'Link_BacktoPastoralList.visible = (not Panel_MenuStudentMaintain.visible)	' show the plain link if the menu isn't there 5-Sept-2008
                Link_BacktoPastoralList.visible = True  ' show the plain link if SS Teacher - 2013-03-14
                ProfilesPanelHolder.Visible = True      ' ERA: 19/Feb/2010|EA| show the ProfilePanel if Student SupportTeacher
            Else
                STUDENT_COMMENTHolder.Visible = False
                'Panel_MenuStudentMaintain.visible = false
                Link_BacktoSummary.visible = (Not Panel_MenuStudentMaintain.visible)    ' show the plain link if the menu isn't there
                Link_BacktoPastoralList.visible = (Not Panel_MenuStudentMaintain.visible)   ' show the plain link if the menu isn't there 5-Sept-2008
                ProfilesPanelHolder.Visible = False     ' ERA: 19/Feb/2010|EA| show the ProfilePanel if Student SupportTeacher
            End If

            ' -------------------------
            'End Page Student_Comments_maintain Event BeforeShow. Action Custom Code

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form STUDENT_COMMENT Parameters @13-B04480C4

    Protected Sub STUDENT_COMMENTParameters()
        Dim item As new STUDENT_COMMENTItem
        Try
            STUDENT_COMMENTData.UrlCOMMENT_ID = IntegerParameter.GetParam("COMMENT_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_COMMENTData.CtrlSTUDENT_ID = TextParameter.GetParam(item.STUDENT_ID.Value, ParameterSourceType.Control, "", "", false)
            STUDENT_COMMENTData.CtrlCOMMENT = TextParameter.GetParam(item.COMMENT.Value, ParameterSourceType.Control, "", "", false)
            STUDENT_COMMENTData.Expr32 = TextParameter.GetParam(DBUtility.UserLogin.ToUpper, ParameterSourceType.Expression, "", "", false)
            STUDENT_COMMENTData.CtrlHidden_CommentType = TextParameter.GetParam(item.Hidden_CommentType.Value, ParameterSourceType.Control, "", "REGULAR", false)
        Catch e As Exception
            STUDENT_COMMENTErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_COMMENT Parameters

'Record Form STUDENT_COMMENT Show method @13-E9AA1622
    Protected Sub STUDENT_COMMENTShow()
        If STUDENT_COMMENTOperations.None Then
            STUDENT_COMMENTHolder.Visible = False
            Return
        End If
        Dim item As STUDENT_COMMENTItem = STUDENT_COMMENTItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_COMMENTOperations.AllowRead
        STUDENT_COMMENTErrors.Add(item.errors)
        If STUDENT_COMMENTErrors.Count > 0 Then
            STUDENT_COMMENTShowErrors()
            Return
        End If
'End Record Form STUDENT_COMMENT Show method

'Record Form STUDENT_COMMENT BeforeShow tail @13-D5834965
        STUDENT_COMMENTParameters()
        STUDENT_COMMENTData.FillItem(item, IsInsertMode)
        STUDENT_COMMENTHolder.DataBind()
        STUDENT_COMMENTButton_Insert.Visible=IsInsertMode AndAlso STUDENT_COMMENTOperations.AllowInsert
        STUDENT_COMMENTlblSTUDENT_ID.Text = Server.HtmlEncode(item.lblSTUDENT_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_COMMENTCOMMENT.Text=item.COMMENT.GetFormattedValue()
        STUDENT_COMMENTSTUDENT_ID.Value = item.STUDENT_ID.GetFormattedValue()
        STUDENT_COMMENThidden_STATUS.Value = item.hidden_STATUS.GetFormattedValue()
        STUDENT_COMMENTHidden_CommentType.Value = item.Hidden_CommentType.GetFormattedValue()
        STUDENT_COMMENTlblCommentType.Text = Server.HtmlEncode(item.lblCommentType.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_COMMENTlbSpecialCommentType.Items.Add(new ListItem("Select Value",""))
        STUDENT_COMMENTlbSpecialCommentType.Items(0).Selected = True
        item.lbSpecialCommentTypeItems.SetSelection(item.lbSpecialCommentType.GetFormattedValue())
        If Not item.lbSpecialCommentTypeItems.GetSelectedItem() Is Nothing Then
            STUDENT_COMMENTlbSpecialCommentType.SelectedIndex = -1
        End If
        item.lbSpecialCommentTypeItems.CopyTo(STUDENT_COMMENTlbSpecialCommentType.Items)
        STUDENT_COMMENTlbSpecialCommentType1.Items.Add(new ListItem("Select Value",""))
        STUDENT_COMMENTlbSpecialCommentType1.Items(0).Selected = True
        item.lbSpecialCommentType1Items.SetSelection(item.lbSpecialCommentType1.GetFormattedValue())
        If Not item.lbSpecialCommentType1Items.GetSelectedItem() Is Nothing Then
            STUDENT_COMMENTlbSpecialCommentType1.SelectedIndex = -1
        End If
        item.lbSpecialCommentType1Items.CopyTo(STUDENT_COMMENTlbSpecialCommentType1.Items)
        STUDENT_COMMENTlbCannedResponses.Items.Add(new ListItem("Select Value",""))
        STUDENT_COMMENTlbCannedResponses.Items(0).Selected = True
        item.lbCannedResponsesItems.SetSelection(item.lbCannedResponses.GetFormattedValue())
        If Not item.lbCannedResponsesItems.GetSelectedItem() Is Nothing Then
            STUDENT_COMMENTlbCannedResponses.SelectedIndex = -1
        End If
        item.lbCannedResponsesItems.CopyTo(STUDENT_COMMENTlbCannedResponses.Items)
'End Record Form STUDENT_COMMENT BeforeShow tail

'ListBox lbCannedResponses Event BeforeShow. Action Custom Code @100-73254650
    ' -------------------------
      'ERA: June-2012|EA| essentially redo above fill of dropdown, as want to change the default set value and display
            STUDENT_COMMENTlbCannedResponses.Items.Clear()
            STUDENT_COMMENTlbCannedResponses.Items.Add(New ListItem("Comment Bank > add to Comment", ""))
            STUDENT_COMMENTlbCannedResponses.Items(0).Selected = True
            item.lbCannedResponsesItems.SetSelection(item.lbCannedResponses.GetFormattedValue())
            If Not item.lbCannedResponsesItems.GetSelectedItem() Is Nothing Then
                STUDENT_COMMENTlbCannedResponses.SelectedIndex = -1
            End If
            item.lbCannedResponsesItems.CopyTo(STUDENT_COMMENTlbCannedResponses.Items)
    ' -------------------------
'End ListBox lbCannedResponses Event BeforeShow. Action Custom Code

      

           

            'Record STUDENT_COMMENT Event BeforeShow. Action Retrieve Value for Control @26-50767707
            STUDENT_COMMENTSTUDENT_ID.Value = (New FloatField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
            'End Record STUDENT_COMMENT Event BeforeShow. Action Retrieve Value for Control

            'Record STUDENT_COMMENT Event BeforeShow. Action Retrieve Value for Control @27-A6DAAB77
            STUDENT_COMMENTlblSTUDENT_ID.Text = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
            'End Record STUDENT_COMMENT Event BeforeShow. Action Retrieve Value for Control

            'Record STUDENT_COMMENT Event BeforeShow. Action Custom Code @64-73254650
            ' -------------------------
            ' ERA: 13-Aug-2010|EA| check if special groups of users and if so then show the Special Comment Type Label and drop-down
            ' currently these groups: 2:PRINCIPALS; 3:ADMINISTRATORS; 6:ENROLMENT OFFICERS; 7:LEADING TEACHERS;9:SYSTEM;
            '	(unfuddle #200)
            ' ERA: 28-Jan-2011|EA| added new drop-down for regular teachers etc, to allow adding of Contact Types.
            '	(unfuddle #356)
            '23-July-2015|EA| added Wellbeing to the Power Groups!
            '27-Aug-2015|EA| convert to global setting incase we need to add a new group in future
			dim strHigherGroups as String = System.Configuration.ConfigurationManager.AppSettings("strHigherSecurityGroups") 
			dim arrHigherGroups as String() = strHigherGroups.split(",")
			If (DBUtility.AuthorizeUser(arrHigherGroups)) Then
            'If (DBUtility.AuthorizeUser(New String() {"2", "3", "6", "7", "9","12"})) Then
                STUDENT_COMMENTlblCommentType.visible = True
                STUDENT_COMMENTlbSpecialCommentType.visible = True
                STUDENT_COMMENTlbSpecialCommentType1.visible = False    '28-Jan

            Else
                STUDENT_COMMENTlblCommentType.visible = False
                STUDENT_COMMENTlbSpecialCommentType.visible = False
                STUDENT_COMMENTlbSpecialCommentType1.visible = True     '28-Jan
            End If
            ' -------------------------
            'End Record STUDENT_COMMENT Event BeforeShow. Action Custom Code

            'Record Form STUDENT_COMMENT Show method tail @13-D9280E89
		  If STUDENT_COMMENTErrors.Count > 0 Then
                STUDENT_COMMENTShowErrors()
            End If
        End Sub
        'End Record Form STUDENT_COMMENT Show method tail

'Record Form STUDENT_COMMENT LoadItemFromRequest method @13-9AA4E5E4

    Protected Sub STUDENT_COMMENTLoadItemFromRequest(item As STUDENT_COMMENTItem, ByVal EnableValidation As Boolean)
        item.COMMENT.IsEmpty = IsNothing(Request.Form(STUDENT_COMMENTCOMMENT.UniqueID))
        If ControlCustomValues("STUDENT_COMMENTCOMMENT") Is Nothing Then
            item.COMMENT.SetValue(STUDENT_COMMENTCOMMENT.Text)
        Else
            item.COMMENT.SetValue(ControlCustomValues("STUDENT_COMMENTCOMMENT"))
        End If
        Try
        item.STUDENT_ID.IsEmpty = IsNothing(Request.Form(STUDENT_COMMENTSTUDENT_ID.UniqueID))
        item.STUDENT_ID.SetValue(STUDENT_COMMENTSTUDENT_ID.Value)
        Catch ae As ArgumentException
            STUDENT_COMMENTErrors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"STUDENT ID"))
        End Try
        item.hidden_STATUS.IsEmpty = IsNothing(Request.Form(STUDENT_COMMENThidden_STATUS.UniqueID))
        item.hidden_STATUS.SetValue(STUDENT_COMMENThidden_STATUS.Value)
        item.Hidden_CommentType.IsEmpty = IsNothing(Request.Form(STUDENT_COMMENTHidden_CommentType.UniqueID))
        item.Hidden_CommentType.SetValue(STUDENT_COMMENTHidden_CommentType.Value)
        item.lbSpecialCommentType.IsEmpty = IsNothing(Request.Form(STUDENT_COMMENTlbSpecialCommentType.UniqueID))
        item.lbSpecialCommentType.SetValue(STUDENT_COMMENTlbSpecialCommentType.Value)
        item.lbSpecialCommentTypeItems.CopyFrom(STUDENT_COMMENTlbSpecialCommentType.Items)
        item.lbSpecialCommentType1.IsEmpty = IsNothing(Request.Form(STUDENT_COMMENTlbSpecialCommentType1.UniqueID))
        item.lbSpecialCommentType1.SetValue(STUDENT_COMMENTlbSpecialCommentType1.Value)
        item.lbSpecialCommentType1Items.CopyFrom(STUDENT_COMMENTlbSpecialCommentType1.Items)
        item.lbCannedResponses.IsEmpty = IsNothing(Request.Form(STUDENT_COMMENTlbCannedResponses.UniqueID))
        item.lbCannedResponses.SetValue(STUDENT_COMMENTlbCannedResponses.Value)
        item.lbCannedResponsesItems.CopyFrom(STUDENT_COMMENTlbCannedResponses.Items)
        If EnableValidation Then
            item.Validate(STUDENT_COMMENTData)
        End If
        STUDENT_COMMENTErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT_COMMENT LoadItemFromRequest method

'Record Form STUDENT_COMMENT GetRedirectUrl method @13-86827CC1

    Protected Function GetSTUDENT_COMMENTRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_COMMENT GetRedirectUrl method

'Record Form STUDENT_COMMENT ShowErrors method @13-C5038092

    Protected Sub STUDENT_COMMENTShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_COMMENTErrors.Count - 1
        Select Case STUDENT_COMMENTErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_COMMENTErrors(i)
        End Select
        Next i
        STUDENT_COMMENTError.Visible = True
        STUDENT_COMMENTErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_COMMENT ShowErrors method

        'Record Form STUDENT_COMMENT Insert Operation @13-56B36828

        Protected Sub STUDENT_COMMENT_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim item As STUDENT_COMMENTItem = New STUDENT_COMMENTItem()
            Dim ExecuteFlag As Boolean = True
            STUDENT_COMMENTIsSubmitted = True
            Dim ErrorFlag As Boolean = False
            Dim RedirectUrl As String = ""
            Dim EnableValidation As Boolean = False
            'End Record Form STUDENT_COMMENT Insert Operation

            'Button Button_Insert OnClick. @14-454288B2
            If CType(sender, Control).ID = "STUDENT_COMMENTButton_Insert" Then
                RedirectUrl = GetSTUDENT_COMMENTRedirectUrl("", "")
                EnableValidation = True
                'End Button Button_Insert OnClick.

                'Button Button_Insert OnClick tail. @14-477CF3C9
            End If
            'End Button Button_Insert OnClick tail.

            'Record STUDENT_COMMENT Event BeforeInsert. Action Custom Code @67-73254650
            ' -------------------------
            ' ERA: check for lbSpecialCommentType - if '0' then no change to hidden_COMMENT_TYPE, else then use lbSpecialCommentType
            ' 	and set ALERT_TYPE to '1'
            ' Also will need to change the Edit own comment page to allow reset/change of comment type from Alert etc to Regular

            ' ERA: 28-Jan-2011|EA| added selection of new drop-down for regular teachers etc, to allow adding of Contact Types.
            '	(unfuddle #356)
            '27-Aug-2015|EA| convert to global setting incase we need to add a new group in future
			dim strHigherGroups as String = System.Configuration.ConfigurationManager.AppSettings("strHigherSecurityGroups") 
			dim arrHigherGroups as String() = strHigherGroups.split(",")
			If (DBUtility.AuthorizeUser(arrHigherGroups)) Then
            'If (DBUtility.AuthorizeUser(New String() {"2", "3", "6", "7", "9"})) Then
                ' update the form objects so they will be loaded in the STUDENT_COMMENTLoadItemFromRequest below.
                If (Not String.Equals(STUDENT_COMMENTlbSpecialCommentType.Value, "")) Then
                    STUDENT_COMMENTHidden_CommentType.Value = STUDENT_COMMENTlbSpecialCommentType.Value
                End If
            Else
                'regular teachers
                If (Not String.Equals(STUDENT_COMMENTlbSpecialCommentType1.Value, "")) Then
                    STUDENT_COMMENTHidden_CommentType.Value = STUDENT_COMMENTlbSpecialCommentType1.Value
                End If
            End If  'end 28-Jan

            '2-3-2011|EA| put in a failsafe that if comment type is not set, then make it 'REGULAR' 
            ' 27 Jul 2021|RW| And also set to REGULAR if "0" is selected, now that some of the comment type logic has been tweaked to be more explicit.
            ' The COMMENT_TYPE table has regular comments listed with code "0", but the STUDENT_COMMENT data table uses "REGULAR"
            If ((STUDENT_COMMENTHidden_CommentType.Value = "") OrElse (STUDENT_COMMENTHidden_CommentType.Value = "0")) Then
                STUDENT_COMMENTHidden_CommentType.Value = "REGULAR"
            End If

            ' -------------------------

            'End Record STUDENT_COMMENT Event BeforeInsert. Action Custom Code

            'Record Form STUDENT_COMMENT BeforeInsert tail @13-425B34D4
            STUDENT_COMMENTParameters()
            STUDENT_COMMENTLoadItemFromRequest(item, EnableValidation)
            If STUDENT_COMMENTOperations.AllowInsert Then
                ErrorFlag = (STUDENT_COMMENTErrors.Count > 0)
                If ExecuteFlag And (Not ErrorFlag) Then
                    Try
                        STUDENT_COMMENTData.InsertItem(item)
                    Catch ex As Exception
                        STUDENT_COMMENTErrors.Add("DataProvider", ex.Message)
                        ErrorFlag = True
                    End Try
                End If
                'End Record Form STUDENT_COMMENT BeforeInsert tail

                'Record STUDENT_COMMENT Event AfterInsert. Action Declare Variable @92-D68AD760
                Dim tmpStudentName As String = ""
                'End Record STUDENT_COMMENT Event AfterInsert. Action Declare Variable

                'Record STUDENT_COMMENT Event AfterInsert. Action DLookup @93-6A383C08
                tmpStudentName = CType((New TextField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "RTRIM(first_name) + ' ' + RTRIM(surname)" & " FROM " & "STUDENT" & " WHERE " & "STUDENT_ID=" & item.STUDENT_ID.Value))).Value, String)
                'End Record STUDENT_COMMENT Event AfterInsert. Action DLookup

                'Record STUDENT_COMMENT Event AfterInsert. Action Custom Code @91-73254650
                ' -------------------------
                '7-Apr-2011|EA| (unfuddle #386) if there comment type is 'ALERT' or 'RESTRICTED' then email the associated teachers 
                Dim alertTypes() As String = {"ALERT", "RESTRICTED", "anothertype"}
                If Array.IndexOf(alertTypes, (item.Hidden_CommentType.Value)) <> -1 Then
                    Dim strTeacherStaffIDList As String = ""
                    Dim strStudentCommentLink As String = ""

                    ' get list of Teachers and current user and add to Select
                    Dim tmpENROLYEAR As String = ""
                    tmpENROLYEAR = Convert.ToString(Year(Now()))

                    strTeacherStaffIDList = CType((New TextField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("declare @sCsv2 varchar(1000); set @sCsv2 = '';select @sCsv2 = @sCsv2 + T1.email+',' from (select distinct rtrim(staff_id)+'@vsv.vic.edu.au' as email from STUDENT_SUBJECT where ENROLMENT_YEAR = " & tmpENROLYEAR & " and STUDENT_ID = " & item.STUDENT_ID.GetFormattedValue() & "and staff_id not like 'nsubmit%' and STAFF_ID not in ('N-A','NA')) as T1; select @sCsv2;"))).Value, String)
                    ' add in Pastoral Care Teacher 
                    'ERA: 2013-09-18|EA|exclude any non-SST codes like 'N-A' and 'NO_SST' as they are not real (unfuddle #552)
                    'strTeacherStaffIDList += CType((New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("select rtrim(isnull(PASTORAL_CARE_ID,'N-A'))+'@distance.vic.edu.au,' from STUDENT_ENROLMENT where ENROLMENT_YEAR = " & tmpENROLYEAR & " and STUDENT_ID = " & item.STUDENT_ID.GetFormattedValue() & " "))).Value, String)
                    strTeacherStaffIDList += CType((New TextField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("select rtrim(PASTORAL_CARE_ID)+'@vsv.vic.edu.au' from STUDENT_ENROLMENT where PASTORAL_CARE_ID is not null AND PASTORAL_CARE_ID not in ('N-A','NA','NO_SST') and ENROLMENT_YEAR = " & tmpENROLYEAR & " and STUDENT_ID = " & item.STUDENT_ID.GetFormattedValue() & " and PASTORAL_CARE_ID not like 'nsubmit%' "))).Value, String)

                    'DEBUG - Remove after testing
                    'strTeacherStaffIDList = "'eaffleck@gmail.com','pcsupport@distance.vic.edu.au'"
                    'strTeacherStaffIDList = "lnigro@yahoo.com,lnigro@distance.vic.edu.au,pcsupport@distance.vic.edu.au"


                    If (strTeacherStaffIDList.Length() > 5) Then
                        Dim strMessageBody As String = ""
                        strMessageBody += "<h2 color='red'>Alert/Restricted Comment Added for Student</h2> <em>" & item.COMMENT.GetFormattedValue() & "</em>"
                        strMessageBody += "<p>Added by Staff ID: " & DBUtility.UserLogin.ToUpper & "</p>"

                        'work out the link to the student comment page	
                        ' get from web.config settings - ServerUrl
                        strStudentCommentLink = Settings.ServerURL & "Student_Comments_maintain.aspx?STUDENT_ID=" & Server.UrlEncode(item.STUDENT_ID.Value) & "&ENROLMENT_YEAR=" & Server.UrlEncode(tmpENROLYEAR)

                        strMessageBody += "<p><a href='" & strStudentCommentLink & "'>go to Comments for <b>" & tmpStudentName & "</b></a></p>"

                        '    Dim message As System.Web.Mail.MailMessage = New System.Web.Mail.MailMessage()
                        '    message.From = "PCSupport@distance.vic.edu.au"
                        '	message.To = strTeacherStaffIDList
                        '	message.Subject = item.hidden_commenttype.value & " Comment Added for Student " & tmpStudentName & " (Student ID: " & item.student_id.value & ")"
                        '   message.Body = strMessageBody
                        '   message.BodyFormat = System.Web.Mail.MailFormat.HTML
                        '	'ERA: 7-May-2012|EA| fix Mail server to use configuration- missed in April Generic changes.
                        '    'System.Web.Mail.SmtpMail.SmtpServer = "decv-ex1.distance.vic.edu.au"
                        '	System.Web.Mail.SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings("smtp_servername")
                        '    System.Web.Mail.SmtpMail.Send(message)
						
                        ' ERA: 31-Oct-2013|LN| Assign From and To from the MailMessage contructor.
                        Dim config As System.Configuration.Configuration = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath)
                        Dim mailSettings As System.Net.Configuration.MailSettingsSectionGroup = CType(config.GetSectionGroup("system.net/mailSettings"), System.Net.Configuration.MailSettingsSectionGroup)
                        Dim fromString As String = mailSettings.Smtp.From

                        'ERA: 4-Oct-2013|EA| fix Mail server to use web.config System.Net.Mail configuration.
                        'Dim message As New System.Net.Mail.MailMessage(fromString, strTeacherStaffIDList)
                        Dim message As New System.Net.Mail.MailMessage()
                        
                        Dim mailaddr As New System.Net.Mail.MailAddress(fromString, fromString)

						message.From = mailaddr

                        Dim recipients as string() = strTeacherStaffIDList.Split(",")
                        Dim recipient as String
                        '23-July-2015|EA| fix if no email addressess (unfuddle #721)
                        If recipients.length > 0 then
	                        For Each recipient in recipients
	                        	message.To.Add(recipient)
	                        Next
	                        
	                        'Dim recipients As New System.Net.Mail.MailAddressCollection  '(strTeacherStaffIDList)   // Commented by ERA: 31-Oct-2013|LN|
	                        'recipients.Add(strTeacherStaffIDList)                                                  // Commented by ERA: 31-Oct-2013|LN|
	                        'message.From = "PCSupport@distance.vic.edu.au"	' in web.config
	
	                        'message.To.Add(recipients)  // Commented by ERA: 31-Oct-2013|LN|
	                        message.Subject = item.Hidden_CommentType.Value & " Comment Added for Student " & tmpStudentName & " (Student ID: " & item.STUDENT_ID.Value & ")"
	                        message.Body = strMessageBody
	                        message.IsBodyHtml = True
	                        Dim mailclient As New System.Net.Mail.SmtpClient()
                        mailclient.Send(message)
                        End If
                    End If

                End If
                ' -------------------------
                'End Record STUDENT_COMMENT Event AfterInsert. Action Custom Code

'Record Form STUDENT_COMMENT AfterInsert tail  @13-A6CFA8F7
        End If
        ErrorFlag=(STUDENT_COMMENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_COMMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_COMMENT AfterInsert tail 

'Record Form STUDENT_COMMENT Update Operation @13-A7C84435

    Protected Sub STUDENT_COMMENT_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_COMMENTItem = New STUDENT_COMMENTItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        STUDENT_COMMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_COMMENT Update Operation

'Record Form STUDENT_COMMENT Before Update tail @13-EF4B79F8
        STUDENT_COMMENTParameters()
        STUDENT_COMMENTLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_COMMENT Before Update tail

'Record Form STUDENT_COMMENT Update Operation tail @13-5A342A24
        ErrorFlag=(STUDENT_COMMENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_COMMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_COMMENT Update Operation tail

'Record Form STUDENT_COMMENT Delete Operation @13-11975DEB
    Protected Sub STUDENT_COMMENT_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_COMMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_COMMENTItem = New STUDENT_COMMENTItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_COMMENT Delete Operation

'Record Form BeforeDelete tail @13-EF4B79F8
        STUDENT_COMMENTParameters()
        STUDENT_COMMENTLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @13-A1B786F7
        If ErrorFlag Then
            STUDENT_COMMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_COMMENT Cancel Operation @13-CE7ECF6B

    Protected Sub STUDENT_COMMENT_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_COMMENTItem = New STUDENT_COMMENTItem()
        STUDENT_COMMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_COMMENTLoadItemFromRequest(item, False)
'End Record Form STUDENT_COMMENT Cancel Operation

'Button Button_Cancel OnClick. @15-318107BC
    If CType(sender,Control).ID = "STUDENT_COMMENTButton_Cancel" Then
        RedirectUrl = GetSTUDENT_COMMENTRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @15-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT_COMMENT Cancel Operation tail @13-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_COMMENT Cancel Operation tail

'Grid Grid_DisplayComments Bind @4-6B7945D8

    Protected Sub Grid_DisplayCommentsBind()
        If Not Grid_DisplayCommentsOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"Grid_DisplayComments",GetType(Grid_DisplayCommentsDataProvider.SortFields), 30, 100)
        End If
'End Grid Grid_DisplayComments Bind

'Grid Form Grid_DisplayComments BeforeShow tail @4-BA5BFEF1
        Grid_DisplayCommentsParameters()
        Grid_DisplayCommentsData.SortField = CType(ViewState("Grid_DisplayCommentsSortField"),Grid_DisplayCommentsDataProvider.SortFields)
        Grid_DisplayCommentsData.SortDir = CType(ViewState("Grid_DisplayCommentsSortDir"),SortDirections)
        Grid_DisplayCommentsData.PageNumber = CInt(ViewState("Grid_DisplayCommentsPageNumber"))
        Grid_DisplayCommentsData.RecordsPerPage = CInt(ViewState("Grid_DisplayCommentsPageSize"))
        Grid_DisplayCommentsRepeater.DataSource = Grid_DisplayCommentsData.GetResultSet(PagesCount, Grid_DisplayCommentsOperations)
        ViewState("Grid_DisplayCommentsPagesCount") = PagesCount
        Dim item As Grid_DisplayCommentsItem = New Grid_DisplayCommentsItem()
        Grid_DisplayCommentsRepeater.DataBind
        FooterIndex = Grid_DisplayCommentsRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            Grid_DisplayCommentsRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Navigator1Navigator As DECV_PROD2007.Controls.Navigator = DirectCast(Grid_DisplayCommentsRepeater.Controls(FooterIndex).FindControl("Navigator1Navigator"),DECV_PROD2007.Controls.Navigator)
        Navigator1Navigator.PageSizes = new Integer() {10,30,100,500}
        If PagesCount < 2 Then Navigator1Navigator.Visible = False

'End Grid Form Grid_DisplayComments BeforeShow tail

'Grid Grid_DisplayComments Bind tail @4-E31F8E2A
    End Sub
'End Grid Grid_DisplayComments Bind tail

'Grid Grid_DisplayComments Table Parameters @4-D58083C3

    Protected Sub Grid_DisplayCommentsParameters()
        Try
            Grid_DisplayCommentsData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", 0, false)

        Catch
            Dim ParentControls As ControlCollection=Grid_DisplayCommentsRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(Grid_DisplayCommentsRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid Grid_DisplayComments: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid Grid_DisplayComments Table Parameters
          

'Grid Grid_DisplayComments ItemDataBound event @4-F373FC94

        Protected Sub Grid_DisplayCommentsItemDataBound(Sender As Object, e As RepeaterItemEventArgs)
            Dim DataItem As Grid_DisplayCommentsItem = CType(e.Item.DataItem, Grid_DisplayCommentsItem)
            Dim Item As Grid_DisplayCommentsItem = DataItem
            Dim FormDataSource As Grid_DisplayCommentsItem() = CType(Grid_DisplayCommentsRepeater.DataSource, Grid_DisplayCommentsItem())
            Dim Grid_DisplayCommentsDataRows As Integer = FormDataSource.Length
            Dim Grid_DisplayCommentsIsForceIteration As Boolean = False
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Grid_DisplayCommentsCurrentRowNumber += 1
                CType(Page, CCPage).ControlAttributes.Add(Grid_DisplayCommentsRepeater, New CCSControlAttribute("rowNumber", FieldType._Integer, Grid_DisplayCommentsCurrentRowNumber), AttributeOption.Multiple)
            End If
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim Grid_DisplayCommentsCOMMENT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_DisplayCommentsCOMMENT"), System.Web.UI.WebControls.Literal)
                Dim Grid_DisplayCommentsLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_DisplayCommentsLAST_ALTERED_BY"), System.Web.UI.WebControls.Literal)
                Dim Grid_DisplayCommentsLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_DisplayCommentsLAST_ALTERED_DATE"), System.Web.UI.WebControls.Literal)
                Dim Grid_DisplayCommentsCOMMENT_TYPE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_DisplayCommentsCOMMENT_TYPE"), System.Web.UI.WebControls.Literal)
                Dim Grid_DisplayCommentslink_editcomment As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Grid_DisplayCommentslink_editcomment"), System.Web.UI.HtmlControls.HtmlAnchor)
                DataItem.link_editcommentHref = "Student_Comments_editown.aspx"
                Grid_DisplayCommentslink_editcomment.HRef = DataItem.link_editcommentHref & DataItem.link_editcommentHrefParameters.ToString("GET", "", ViewState)
            End If
            'End Grid Grid_DisplayComments ItemDataBound event

            'Grid Grid_DisplayComments BeforeShowRow event @4-67518FFB
            If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
                'End Grid Grid_DisplayComments BeforeShowRow event

                'Grid Grid_DisplayComments Event BeforeShowRow. Action Custom Code @43-73254650
                ' -------------------------
                'ERA: change colour of row depending on comment type

                Dim comment_row As System.Web.UI.HtmlControls.HtmlTableRow = DirectCast(e.Item.FindControl("displaycomments_row"), System.Web.UI.HtmlControls.HtmlTableRow)

                If (DataItem.COMMENT_TYPE.Value = "REGULAR") Then
                    comment_row.Attributes("Class") = "Row"

                ElseIf (DataItem.COMMENT_TYPE.Value = "PASTORAL") Then
                    comment_row.Attributes("Class") = "AltRow"
                    'ERA: 13-Aug-2010|EA new *page based* styles for highlighting special comments
                ElseIf (DataItem.COMMENT_TYPE.Value = "ALERT") Then
                    comment_row.Attributes("Class") = "AlertRed"

                ElseIf (DataItem.COMMENT_TYPE.Value = "RESTRICTED") Then
                    comment_row.Attributes("Class") = "AlertRed"

                ElseIf (DataItem.COMMENT_TYPE.Value = "WELLBEING") Then
                    comment_row.Attributes("Class") = "AlertGreen"

                ElseIf (DataItem.COMMENT_TYPE.Value = "COORD_DECISION") Then
                    '10-Aug-2012|EA| added for Coordinator Decisions
                    comment_row.Attributes("Class") = "CoordAmber"

                ElseIf (DataItem.COMMENT_TYPE.Value = "MODIFIED_SUBJECT") Then
                    '14-Feb-2013|EA| added for Modified Subject
                    comment_row.Attributes("Class") = "CoordAmber"

                ElseIf (DataItem.COMMENT_TYPE.Value = "ENROLMENT") Then
                    '31-Oct-2013|LN| added for Enrolment
                    comment_row.Attributes("Class") = "LightMauve"
                    
                ElseIf (DataItem.COMMENT_TYPE.Value = "PATHWAYS") Then
                    '14-May-2014|EA| added for Pathways Decision (unfuddle #638)
                    comment_row.Attributes("Class") = "Pathways"
                    
                ElseIf (DataItem.COMMENT_TYPE.Value = "ENROLMENT_ROLLOVER") Then
                    '1 Nov 2020|RW| added hot pink colouring to rollover comment at the request of enrolments
                    comment_row.Attributes("Class") = "Rollover"
                    
                ElseIf (DataItem.COMMENT_TYPE.Value = "OFFSHORE_STUDENT") Then
                    '1 Nov 2020|RW| added colouring to offshore comment type; comment type requested by Naomi Wong
                    comment_row.Attributes("Class") = "Offshore"
                    
                Else
                    comment_row.Attributes("Class") = "Row"
                End If

                'ERA: Aug 2009 - and display the 'edit' link only if the current user is the LAST_ALTERED_BY field
                Dim Grid_DisplayCommentslink_editcomment As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Grid_DisplayCommentslink_editcomment"), System.Web.UI.HtmlControls.HtmlAnchor)

                If (DataItem.LAST_ALTERED_BY.Value.ToUpper() = DBUtility.UserId.ToString.ToUpper()) Then
                    Grid_DisplayCommentslink_editcomment.Visible = True
                Else
                    Grid_DisplayCommentslink_editcomment.Visible = False
                End If

                '11-Feb-2013|EA| display 'edit' on Public comments if user is in special groups (ADMINISTRATORS:3; ENROLMENT OFFICERS:6; SYSTEM:9)
                ' But not overriding next exclusion for certain possibleTypes (as might want certain types locked)
                If (DBUtility.AuthorizeUser(New String() {"3", "6", "9"})) Then
                    Grid_DisplayCommentslink_editcomment.Visible = True
                End If

                '19-Feb-2010|EA| additional turn off Edit for general Comment Types - add more as needed
                Dim asPossibleTypes() As String = {"PROFILE", "anothertype"}
                If Array.IndexOf(asPossibleTypes, (DataItem.COMMENT_TYPE.Value.toupper())) <> -1 Then
                    Grid_DisplayCommentslink_editcomment.Visible = False
                End If

                ' -------------------------
                'End Grid Grid_DisplayComments Event BeforeShowRow. Action Custom Code

                'Grid Grid_DisplayComments BeforeShowRow event tail @4-477CF3C9
            End If
            'End Grid Grid_DisplayComments BeforeShowRow event tail
 		 If Grid_DisplayCommentsIsForceIteration Then
                Dim ri As RepeaterItem = Nothing
                ri = New RepeaterItem(Grid_DisplayCommentsCurrentRowNumber, ListItemType.Item)
                Grid_DisplayCommentsRepeater.ItemTemplate.InstantiateIn(ri)
                ri.DataItem = DataItem
                ri.DataBind()
                e.Item.FindControl("IterationContainer").Controls.Add(ri)
                Grid_DisplayCommentsItemDataBound(Sender, New RepeaterItemEventArgs(ri))
                ri.DataItem = Nothing
            End If
        End Sub
        'End Grid Grid_DisplayComments ItemDataBound event tail

       

            'Grid Grid_DisplayComments ItemDataBound event tail @4-BFD38A06

'Grid Grid_DisplayComments ItemCommand event @4-9F92F65C

    Protected Sub Grid_DisplayCommentsItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= Grid_DisplayCommentsRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("Grid_DisplayCommentsSortDir"),SortDirections) = SortDirections._Asc And ViewState("Grid_DisplayCommentsSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("Grid_DisplayCommentsSortDir")=SortDirections._Desc
                Else
                    ViewState("Grid_DisplayCommentsSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("Grid_DisplayCommentsSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As Grid_DisplayCommentsDataProvider.SortFields = 0
            ViewState("Grid_DisplayCommentsSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("Grid_DisplayCommentsPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("Grid_DisplayCommentsPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("Grid_DisplayCommentsPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("Grid_DisplayCommentsPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            Grid_DisplayCommentsBind
        End If
    End Sub
'End Grid Grid_DisplayComments ItemCommand event

'Record Form ProfilesPanel Parameters @47-F86CBCD7

    Protected Sub ProfilesPanelParameters()
        Dim item As new ProfilesPanelItem
        Try
            ProfilesPanelData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            ProfilesPanelData.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            ProfilesPanelErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form ProfilesPanel Parameters

'Record Form ProfilesPanel Show method @47-CC5FC5AB
    Protected Sub ProfilesPanelShow()
        If ProfilesPanelOperations.None Then
            ProfilesPanelHolder.Visible = False
            Return
        End If
        Dim item As ProfilesPanelItem = ProfilesPanelItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not ProfilesPanelOperations.AllowRead
        ProfilesPanelErrors.Add(item.errors)
        If ProfilesPanelErrors.Count > 0 Then
            ProfilesPanelShowErrors()
            Return
        End If
'End Record Form ProfilesPanel Show method

'Record Form ProfilesPanel BeforeShow tail @47-08D46A33
        ProfilesPanelParameters()
        ProfilesPanelData.FillItem(item, IsInsertMode)
        ProfilesPanelHolder.DataBind()
        ProfilesPanelButton_Update.Visible=Not (IsInsertMode) AndAlso ProfilesPanelOperations.AllowUpdate
        item.radio_PathwaysProfileItems.SetSelection(item.radio_PathwaysProfile.GetFormattedValue())
        ProfilesPanelradio_PathwaysProfile.SelectedIndex = -1
        item.radio_PathwaysProfileItems.CopyTo(ProfilesPanelradio_PathwaysProfile.Items)
        item.radio_IntakeInterviewItems.SetSelection(item.radio_IntakeInterview.GetFormattedValue())
        ProfilesPanelradio_IntakeInterview.SelectedIndex = -1
        item.radio_IntakeInterviewItems.CopyTo(ProfilesPanelradio_IntakeInterview.Items)
        ProfilesPanellabel_EnrolYear.Text = Server.HtmlEncode(item.label_EnrolYear.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form ProfilesPanel BeforeShow tail

'Record ProfilesPanel Event BeforeShow. Action Retrieve Value for Control @61-980766B6
            ProfilesPanellabel_EnrolYear.Text = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR"))).GetFormattedValue()
'End Record ProfilesPanel Event BeforeShow. Action Retrieve Value for Control

'Record Form ProfilesPanel Show method tail @47-B519C8C2
        If ProfilesPanelErrors.Count > 0 Then
            ProfilesPanelShowErrors()
        End If
    End Sub
'End Record Form ProfilesPanel Show method tail

'Record Form ProfilesPanel LoadItemFromRequest method @47-E3D4E3CC

    Protected Sub ProfilesPanelLoadItemFromRequest(item As ProfilesPanelItem, ByVal EnableValidation As Boolean)
        Try
        item.radio_PathwaysProfile.IsEmpty = IsNothing(Request.Form(ProfilesPanelradio_PathwaysProfile.UniqueID))
        If Not IsNothing(ProfilesPanelradio_PathwaysProfile.SelectedItem) Then
            item.radio_PathwaysProfile.SetValue(ProfilesPanelradio_PathwaysProfile.SelectedItem.Value)
        Else
            item.radio_PathwaysProfile.Value = Nothing
        End If
        item.radio_PathwaysProfileItems.CopyFrom(ProfilesPanelradio_PathwaysProfile.Items)
        Catch ae As ArgumentException
            ProfilesPanelErrors.Add("radio_PathwaysProfile",String.Format(Resources.strings.CCS_IncorrectValue,"Pathways Profile"))
        End Try
        Try
        item.radio_IntakeInterview.IsEmpty = IsNothing(Request.Form(ProfilesPanelradio_IntakeInterview.UniqueID))
        If Not IsNothing(ProfilesPanelradio_IntakeInterview.SelectedItem) Then
            item.radio_IntakeInterview.SetValue(ProfilesPanelradio_IntakeInterview.SelectedItem.Value)
        Else
            item.radio_IntakeInterview.Value = Nothing
        End If
        item.radio_IntakeInterviewItems.CopyFrom(ProfilesPanelradio_IntakeInterview.Items)
        Catch ae As ArgumentException
            ProfilesPanelErrors.Add("radio_IntakeInterview",String.Format(Resources.strings.CCS_IncorrectValue,"Student Profile"))
        End Try
        If EnableValidation Then
            item.Validate(ProfilesPanelData)
        End If
        ProfilesPanelErrors.Add(item.errors)
    End Sub
'End Record Form ProfilesPanel LoadItemFromRequest method

'Record Form ProfilesPanel GetRedirectUrl method @47-72D437EC

    Protected Function GetProfilesPanelRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form ProfilesPanel GetRedirectUrl method

'Record Form ProfilesPanel ShowErrors method @47-951FA954

    Protected Sub ProfilesPanelShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To ProfilesPanelErrors.Count - 1
        Select Case ProfilesPanelErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & ProfilesPanelErrors(i)
        End Select
        Next i
        ProfilesPanelError.Visible = True
        ProfilesPanelErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form ProfilesPanel ShowErrors method

'Record Form ProfilesPanel Insert Operation @47-CAD74593

    Protected Sub ProfilesPanel_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ProfilesPanelItem = New ProfilesPanelItem()
        ProfilesPanelIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ProfilesPanel Insert Operation

'Record Form ProfilesPanel BeforeInsert tail @47-3D3E37A1
    ProfilesPanelParameters()
    ProfilesPanelLoadItemFromRequest(item, EnableValidation)
'End Record Form ProfilesPanel BeforeInsert tail

'Record Form ProfilesPanel AfterInsert tail  @47-7B2DA3D6
        ErrorFlag=(ProfilesPanelErrors.Count > 0)
        If ErrorFlag Then
            ProfilesPanelShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ProfilesPanel AfterInsert tail 
          

        'Record Form ProfilesPanel Update Operation @47-153BC780

        Protected Sub ProfilesPanel_Update(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim item As ProfilesPanelItem = New ProfilesPanelItem()
            item.IsNew = False
            Dim ExecuteFlag As Boolean = True
            Dim ErrorFlag As Boolean = False
            ProfilesPanelIsSubmitted = True
            Dim RedirectUrl As String = ""
            Dim EnableValidation As Boolean = False
            'End Record Form ProfilesPanel Update Operation

            'Button Button_Update OnClick. @49-03DD4403
            If CType(sender, Control).ID = "ProfilesPanelButton_Update" Then
                RedirectUrl = GetProfilesPanelRedirectUrl("", "")
                EnableValidation = True
                'End Button Button_Update OnClick.

                'Button Button_Update OnClick tail. @49-477CF3C9
            End If
            'End Button Button_Update OnClick tail.

            'Record Form ProfilesPanel Before Update tail @47-3F3BAF91
            ProfilesPanelParameters()
            ProfilesPanelLoadItemFromRequest(item, EnableValidation)
            If ProfilesPanelOperations.AllowUpdate Then
                ErrorFlag = (ProfilesPanelErrors.Count > 0)
                If ExecuteFlag And (Not ErrorFlag) Then
                    Try
                        ProfilesPanelData.UpdateItem(item)
                    Catch ex As Exception
                        ProfilesPanelErrors.Add("DataProvider", ex.Message)
                        ErrorFlag = True
                    End Try
                End If
                'End Record Form ProfilesPanel Before Update tail

                'Record ProfilesPanel Event AfterUpdate. Action Custom Code @60-73254650

                ' -------------------------
                'ERA: After the update to the STUDENT_ENROLMENT, also put a comment reflecting fact by Teacher
                ' similar to [insert into STUDENT_COMMENT select (select (max(COMMENT_ID+1)) from STUDENT_COMMENT) , {STUDENT_ID},'{COMMENTTEXT}',UPPER('{LAST_ALTERED_BY}'), getdate(),'A','{COMMENT_TYPE}']
                Dim Request As HttpRequest = HttpContext.Current.Request
                Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
                'Dim Sql As String = "INSERT INTO report (report_task_id,report_creator) " & _ 
                '"VALUES  ("& NewDao.ToSql(Request.QueryString("task_id"),FieldType._Integer) &","& _
                '	NewDao.ToSql(DBUtility.UserId.ToString(),FieldType._Integer) &")"
                'NewDao.RunSql(Sql)
                'tmpTeacherID = enrolment_year = " & Settings.connDECVPRODSQL2005DataAccessObject.ToSql(System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR"), FieldType._Integer, True) & " AND STUDENT_ID = " & Settings.connDECVPRODSQL2005DataAccessObject.ToSql(System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"), FieldType._Text, True)  & " AND STAFF_ID = '" & (DBUtility.UserId.ToString.ToUpper()) & "'")
                Dim Sql As String = "insert into STUDENT_COMMENT ([COMMENT_ID] ,[STUDENT_ID] ,[COMMENT] ,[LAST_ALTERED_BY] ,[LAST_ALTERED_DATE] ,[ACTIVE_STATUS] ,[COMMENT_TYPE]) "
                Sql = Sql & " select (select (max(COMMENT_ID+1)) from STUDENT_COMMENT) , " & NewDao.ToSql(Request.QueryString("STUDENT_ID"), FieldType._Text, True) & ""
                Sql = Sql & ", 'Profiles Updated to: Student Profile (" & item.radio_IntakeInterview.GetFormattedValue & ") and Pathways Profile (" & item.radio_PathwaysProfile.GetFormattedValue & ") for Enrolment Year " & Request.QueryString("ENROLMENT_YEAR") & "'"
                Sql = Sql & ", UPPER('" & (DBUtility.UserId.ToString.ToUpper()) & "'), getdate(),'A','PROFILE'"
                'response.write(Sql)
                'response.end
                NewDao.RunSql(Sql)
                ' -------------------------
                'End Record ProfilesPanel Event AfterUpdate. Action Custom Code



                'Record Form ProfilesPanel Update Operation tail @47-8CC278CD
		  End If
            ErrorFlag = (ProfilesPanelErrors.Count > 0)
            If ErrorFlag Then
                ProfilesPanelShowErrors()
            Else
                Response.Redirect(RedirectUrl)
            End If
        End Sub
        'End Record Form ProfilesPanel Update Operation tail

'Record Form ProfilesPanel Delete Operation @47-100BF9DD
    Protected Sub ProfilesPanel_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        ProfilesPanelIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As ProfilesPanelItem = New ProfilesPanelItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form ProfilesPanel Delete Operation

'Record Form BeforeDelete tail @47-3D3E37A1
        ProfilesPanelParameters()
        ProfilesPanelLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @47-5D29F986
        If ErrorFlag Then
            ProfilesPanelShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form ProfilesPanel Cancel Operation @47-C07137BA

    Protected Sub ProfilesPanel_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ProfilesPanelItem = New ProfilesPanelItem()
        ProfilesPanelIsSubmitted = True
        Dim RedirectUrl As String = ""
        ProfilesPanelLoadItemFromRequest(item, False)
'End Record Form ProfilesPanel Cancel Operation

'Button Button_Cancel OnClick. @50-7316DE2E
    If CType(sender,Control).ID = "ProfilesPanelButton_Cancel" Then
        RedirectUrl = GetProfilesPanelRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @50-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form ProfilesPanel Cancel Operation tail @47-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form ProfilesPanel Cancel Operation tail

'Grid Grid_DisplayComments_MyComments Bind @69-F873419D

    Protected Sub Grid_DisplayComments_MyCommentsBind()
        If Not Grid_DisplayComments_MyCommentsOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"Grid_DisplayComments_MyComments",GetType(Grid_DisplayComments_MyCommentsDataProvider.SortFields), 200, 200)
        End If
'End Grid Grid_DisplayComments_MyComments Bind

'Grid Form Grid_DisplayComments_MyComments BeforeShow tail @69-07A93DC4
        Grid_DisplayComments_MyCommentsParameters()
        Grid_DisplayComments_MyCommentsData.SortField = CType(ViewState("Grid_DisplayComments_MyCommentsSortField"),Grid_DisplayComments_MyCommentsDataProvider.SortFields)
        Grid_DisplayComments_MyCommentsData.SortDir = CType(ViewState("Grid_DisplayComments_MyCommentsSortDir"),SortDirections)
        Grid_DisplayComments_MyCommentsData.PageNumber = CInt(ViewState("Grid_DisplayComments_MyCommentsPageNumber"))
        Grid_DisplayComments_MyCommentsData.RecordsPerPage = CInt(ViewState("Grid_DisplayComments_MyCommentsPageSize"))
        Grid_DisplayComments_MyCommentsRepeater.DataSource = Grid_DisplayComments_MyCommentsData.GetResultSet(PagesCount, Grid_DisplayComments_MyCommentsOperations)
        ViewState("Grid_DisplayComments_MyCommentsPagesCount") = PagesCount
        Dim item As Grid_DisplayComments_MyCommentsItem = New Grid_DisplayComments_MyCommentsItem()
        Grid_DisplayComments_MyCommentsRepeater.DataBind
        FooterIndex = Grid_DisplayComments_MyCommentsRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            Grid_DisplayComments_MyCommentsRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Grid_DisplayComments_MyCommentsLabel_LogType As System.Web.UI.WebControls.Literal = DirectCast(Grid_DisplayComments_MyCommentsRepeater.Controls(0).FindControl("Grid_DisplayComments_MyCommentsLabel_LogType"),System.Web.UI.WebControls.Literal)

        Grid_DisplayComments_MyCommentsLabel_LogType.Text = Server.HtmlEncode(item.Label_LogType.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form Grid_DisplayComments_MyComments BeforeShow tail

            'Grid Grid_DisplayComments_MyComments Event BeforeShow. Action Custom Code @86-73254650
            ' -------------------------
            '7-Mar-2011|EA| if in the proper groups then change/display Label_LogType to suit
            '27-Aug-2015|EA| added '12' for Wellbeing officers
            If (DBUtility.AuthorizeUser(New String() {"2", "3", "4", "5", "6", "7", "9", "12"})) Then
                Grid_DisplayComments_MyCommentsLabel_LogType.Text = "All Communications with Student"
            Else
                Grid_DisplayComments_MyCommentsLabel_LogType.Text = "Teacher Communications"
            End If
            ' -------------------------
            'End Grid Grid_DisplayComments_MyComments Event BeforeShow. Action Custom Code

            'Grid Grid_DisplayComments_MyComments Bind tail @69-E31F8E2A
        End Sub
        'End Grid Grid_DisplayComments_MyComments Bind tail

        'Grid Grid_DisplayComments_MyComments Table Parameters @69-AB7771AB

        Protected Sub Grid_DisplayComments_MyCommentsParameters()
            Try
                Grid_DisplayComments_MyCommentsData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", 0, False)

            Catch
                Dim ParentControls As ControlCollection = Grid_DisplayComments_MyCommentsRepeater.Parent.Controls
                Dim RepeaterIndex As Integer = ParentControls.IndexOf(Grid_DisplayComments_MyCommentsRepeater)
                ParentControls.RemoveAt(RepeaterIndex)
                Dim ErrorMessage As Literal = New Literal()
                ErrorMessage.Text = "Error in Grid Grid_DisplayComments_MyComments: Invalid parameter"
                ParentControls.AddAt(RepeaterIndex, ErrorMessage)
            End Try
        End Sub
        'End Grid Grid_DisplayComments_MyComments Table Parameters

        'Grid Grid_DisplayComments_MyComments ItemDataBound event @69-4EA965C7

        Protected Sub Grid_DisplayComments_MyCommentsItemDataBound(Sender As Object, e As RepeaterItemEventArgs)
            Dim DataItem As Grid_DisplayComments_MyCommentsItem = CType(e.Item.DataItem, Grid_DisplayComments_MyCommentsItem)
            Dim Item As Grid_DisplayComments_MyCommentsItem = DataItem
            Dim FormDataSource As Grid_DisplayComments_MyCommentsItem() = CType(Grid_DisplayComments_MyCommentsRepeater.DataSource, Grid_DisplayComments_MyCommentsItem())
            Dim Grid_DisplayComments_MyCommentsDataRows As Integer = FormDataSource.Length
            Dim Grid_DisplayComments_MyCommentsIsForceIteration As Boolean = False
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Grid_DisplayComments_MyCommentsCurrentRowNumber += 1
                CType(Page, CCPage).ControlAttributes.Add(Grid_DisplayComments_MyCommentsRepeater, New CCSControlAttribute("rowNumber", FieldType._Integer, Grid_DisplayComments_MyCommentsCurrentRowNumber), AttributeOption.Multiple)
            End If
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim Grid_DisplayComments_MyCommentsCOMMENT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_DisplayComments_MyCommentsCOMMENT"), System.Web.UI.WebControls.Literal)
                Dim Grid_DisplayComments_MyCommentsLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_DisplayComments_MyCommentsLAST_ALTERED_BY"), System.Web.UI.WebControls.Literal)
                Dim Grid_DisplayComments_MyCommentsLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_DisplayComments_MyCommentsLAST_ALTERED_DATE"), System.Web.UI.WebControls.Literal)
                Dim Grid_DisplayComments_MyCommentsCOMMENT_TYPE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_DisplayComments_MyCommentsCOMMENT_TYPE"), System.Web.UI.WebControls.Literal)
                Dim Grid_DisplayComments_MyCommentslink_editcomment As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Grid_DisplayComments_MyCommentslink_editcomment"), System.Web.UI.HtmlControls.HtmlAnchor)
                DataItem.link_editcommentHref = "Student_Comments_editown.aspx"
                Grid_DisplayComments_MyCommentslink_editcomment.HRef = DataItem.link_editcommentHref & DataItem.link_editcommentHrefParameters.ToString("GET", "", ViewState)
            End If
            'End Grid Grid_DisplayComments_MyComments ItemDataBound event

            'Grid Grid_DisplayComments_MyComments BeforeShowRow event @69-67518FFB
            If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
                'End Grid Grid_DisplayComments_MyComments BeforeShowRow event

                'Grid Grid_DisplayComments_MyComments Event BeforeShowRow. Action Custom Code @77-73254650
                ' -------------------------
                'ERA: change colour of row depending on comment type
                ' 2-Feb-2011|EA| add comment type into class for filtering later

                Dim comment_row As System.Web.UI.HtmlControls.HtmlTableRow = DirectCast(e.Item.FindControl("displaycomments_row"), System.Web.UI.HtmlControls.HtmlTableRow)
                comment_row.Attributes("Class") = "Row " + DataItem.COMMENT_TYPE.Value
                '	if (DataItem.comment_type.value = "REGULAR") Then
                '      comment_row.Attributes("Class") = "Row"
                '
                '	elseif (DataItem.comment_type.value="PASTORAL") Then
                '      comment_row.Attributes("Class") = "AltRow"
                '	'ERA: 13-Aug-2010|EA new *page based* styles for highlighting special comments
                '	elseif (DataItem.comment_type.value="ALERT") Then
                '      comment_row.Attributes("Class") = "AlertRed"
                '
                '	elseif (DataItem.comment_type.value="RESTRICTED") Then
                '      comment_row.Attributes("Class") = "AlertRed"
                '
                '	elseif (DataItem.comment_type.value="WELLBEING") Then
                '      comment_row.Attributes("Class") = "AlertGreen"
                '
                '    Else
                '      comment_row.Attributes("Class") = "Row"
                '    End if 

                'ERA: Aug 2009 - and display the 'edit' link only if the current user is the LAST_ALTERED_BY field
                Dim Grid_DisplayComments_MyCommentslink_editcomment As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Grid_DisplayComments_MyCommentslink_editcomment"), System.Web.UI.HtmlControls.HtmlAnchor)

                If (DataItem.LAST_ALTERED_BY.Value.ToUpper() = DBUtility.UserId.ToString.ToUpper()) Then
                    Grid_DisplayComments_MyCommentslink_editcomment.Visible = True
                Else
                    Grid_DisplayComments_MyCommentslink_editcomment.Visible = False
                End If

                '19-Feb-2010|EA| additional turn off Edit for general Comment Types - add more as needed
                Dim asPossibleTypes() As String = {"PROFILE", "anothertype"}
                If Array.IndexOf(asPossibleTypes, (DataItem.COMMENT_TYPE.Value.toupper())) <> -1 Then
                    Grid_DisplayComments_MyCommentslink_editcomment.Visible = False
                End If

                ' -------------------------
                'End Grid Grid_DisplayComments_MyComments Event BeforeShowRow. Action Custom Code

                'Grid Grid_DisplayComments_MyComments BeforeShowRow event tail @69-477CF3C9
            End If
            'End Grid Grid_DisplayComments_MyComments BeforeShowRow event tail
 			If Grid_DisplayComments_MyCommentsIsForceIteration Then
                Dim ri As RepeaterItem = Nothing
                ri = New RepeaterItem(Grid_DisplayComments_MyCommentsCurrentRowNumber, ListItemType.Item)
                Grid_DisplayComments_MyCommentsRepeater.ItemTemplate.InstantiateIn(ri)
                ri.DataItem = DataItem
                ri.DataBind()
                e.Item.FindControl("IterationContainer").Controls.Add(ri)
                Grid_DisplayComments_MyCommentsItemDataBound(Sender, New RepeaterItemEventArgs(ri))
                ri.DataItem = Nothing
            End If
        End Sub
        'End Grid Grid_DisplayComments_MyComments ItemDataBound event tail

            'Grid Grid_DisplayComments_MyComments ItemDataBound event tail @69-EBCAE0A8

'Grid Grid_DisplayComments_MyComments ItemCommand event @69-7F79F1CD

    Protected Sub Grid_DisplayComments_MyCommentsItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= Grid_DisplayComments_MyCommentsRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("Grid_DisplayComments_MyCommentsSortDir"),SortDirections) = SortDirections._Asc And ViewState("Grid_DisplayComments_MyCommentsSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("Grid_DisplayComments_MyCommentsSortDir")=SortDirections._Desc
                Else
                    ViewState("Grid_DisplayComments_MyCommentsSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("Grid_DisplayComments_MyCommentsSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As Grid_DisplayComments_MyCommentsDataProvider.SortFields = 0
            ViewState("Grid_DisplayComments_MyCommentsSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("Grid_DisplayComments_MyCommentsPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("Grid_DisplayComments_MyCommentsPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("Grid_DisplayComments_MyCommentsPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("Grid_DisplayComments_MyCommentsPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            Grid_DisplayComments_MyCommentsBind
        End If
    End Sub
'End Grid Grid_DisplayComments_MyComments ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-554ED521
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Comments_maintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_COMMENTData = New STUDENT_COMMENTDataProvider()
        STUDENT_COMMENTOperations = New FormSupportedOperations(False, False, True, False, False)
        Grid_DisplayCommentsData = New Grid_DisplayCommentsDataProvider()
        Grid_DisplayCommentsOperations = New FormSupportedOperations(False, True, False, False, False)
        ProfilesPanelData = New ProfilesPanelDataProvider()
        ProfilesPanelOperations = New FormSupportedOperations(False, True, False, True, False)
        Grid_DisplayComments_MyCommentsData = New Grid_DisplayComments_MyCommentsDataProvider()
        Grid_DisplayComments_MyCommentsOperations = New FormSupportedOperations(True, True, False, False, False)
        If Not(User.Identity.IsAuthenticated) Then
            Response.Redirect(Settings.AccessDeniedUrl & "?ret_link=" & Server.UrlEncode(Request("SCRIPT_NAME") & "?" & Request("QUERY_STRING")))
        End If
'End OnInit Event Body

'OnInit Event tail @1-BB95D25C
    PageStyleName = Server.UrlEncode(PageStyleName)
    End Sub
'End OnInit Event tail

'InitializeComponent Event @1-EA5E2628
    ' <summary>
    ' Required method for Designer support - do not modify
    ' the contents of this method with the code editor.
    ' </summary>
    Private Sub InitializeComponent()
    End Sub
    #End Region
'End InitializeComponent Event

'Page class tail @1-DD082417
End Class
End Namespace
'End Page class tail
           
       