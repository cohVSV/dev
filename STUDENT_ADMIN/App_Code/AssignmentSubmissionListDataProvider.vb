'Using Statements @1-ECBA6F53
Imports System
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Data
Imports DECV_PROD2007
Imports DECV_PROD2007.Data
Imports DECV_PROD2007.Controls
Imports DECV_PROD2007.Security
Imports DECV_PROD2007.Configuration
'End Using Statements

Namespace DECV_PROD2007.AssignmentSubmissionList 'Namespace @1-3B38056F

'Page Data Class @1-00D755AD
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Link_Backtosummary As TextField
    Public Link_BacktosummaryHref As Object
    Public Link_BacktosummaryHrefParameters As LinkParameterCollection
    Public Link_BacktoPastoralList As TextField
    Public Link_BacktoPastoralListHref As Object
    Public Link_BacktoPastoralListHrefParameters As LinkParameterCollection
    Public link_Menu As TextField
    Public link_MenuHref As Object
    Public link_MenuHrefParameters As LinkParameterCollection
    Public Link_SearchRequest As TextField
    Public Link_SearchRequestHref As Object
    Public Link_SearchRequestHrefParameters As LinkParameterCollection
    Public link_Assignments As TextField
    Public link_AssignmentsHref As Object
    Public link_AssignmentsHrefParameters As LinkParameterCollection
    Public Link10 As TextField
    Public Link10Href As Object
    Public Link10HrefParameters As LinkParameterCollection
    Public Link6 As TextField
    Public Link6Href As Object
    Public Link6HrefParameters As LinkParameterCollection
    Public Link5 As TextField
    Public Link5Href As Object
    Public Link5HrefParameters As LinkParameterCollection
    Public Sub New()
        Link_Backtosummary = New TextField("",Nothing)
        Link_BacktosummaryHrefParameters = New LinkParameterCollection()
        Link_BacktoPastoralList = New TextField("",Nothing)
        Link_BacktoPastoralListHrefParameters = New LinkParameterCollection()
        link_Menu = New TextField("",Nothing)
        link_MenuHrefParameters = New LinkParameterCollection()
        Link_SearchRequest = New TextField("",Nothing)
        Link_SearchRequestHrefParameters = New LinkParameterCollection()
        link_Assignments = New TextField("",Nothing)
        link_AssignmentsHrefParameters = New LinkParameterCollection()
        Link10 = New TextField("",Nothing)
        Link10HrefParameters = New LinkParameterCollection()
        Link6 = New TextField("",Nothing)
        Link6HrefParameters = New LinkParameterCollection()
        Link5 = New TextField("",Nothing)
        Link5HrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Link_Backtosummary.SetValue(DBUtility.GetInitialValue("Link_Backtosummary"))
        item.Link_BacktoPastoralList.SetValue(DBUtility.GetInitialValue("Link_BacktoPastoralList"))
        item.link_Menu.SetValue(DBUtility.GetInitialValue("link_Menu"))
        item.Link_SearchRequest.SetValue(DBUtility.GetInitialValue("Link_SearchRequest"))
        item.link_Assignments.SetValue(DBUtility.GetInitialValue("link_Assignments"))
        item.Link10.SetValue(DBUtility.GetInitialValue("Link10"))
        item.Link6.SetValue(DBUtility.GetInitialValue("Link6"))
        item.Link5.SetValue(DBUtility.GetInitialValue("Link5"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Link_Backtosummary"
                    Return Link_Backtosummary
                Case "Link_BacktoPastoralList"
                    Return Link_BacktoPastoralList
                Case "link_Menu"
                    Return link_Menu
                Case "Link_SearchRequest"
                    Return Link_SearchRequest
                Case "link_Assignments"
                    Return link_Assignments
                Case "Link10"
                    Return Link10
                Case "Link6"
                    Return Link6
                Case "Link5"
                    Return Link5
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link_Backtosummary"
                    Link_Backtosummary = CType(value, TextField)
                Case "Link_BacktoPastoralList"
                    Link_BacktoPastoralList = CType(value, TextField)
                Case "link_Menu"
                    link_Menu = CType(value, TextField)
                Case "Link_SearchRequest"
                    Link_SearchRequest = CType(value, TextField)
                Case "link_Assignments"
                    link_Assignments = CType(value, TextField)
                Case "Link10"
                    Link10 = CType(value, TextField)
                Case "Link6"
                    Link6 = CType(value, TextField)
                Case "Link5"
                    Link5 = CType(value, TextField)
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Set
    End Property

End Class
'End Page Data Class

'Page Data Provider Class @1-E3544B64
Public Class PageDataProvider
Dim j As Integer
'End Page Data Provider Class

'Page Data Provider Class Constructor @1-12B526DF
    Public Sub New()
    End Sub
'End Page Data Provider Class Constructor

'Page Data Provider Class GetResultSet Method @1-F73C4626
    Public Sub FillItem(ByVal item As PageItem)
'End Page Data Provider Class GetResultSet Method

'Page Data Provider Class GetResultSet Method tail @1-E31F8E2A
    End Sub
'End Page Data Provider Class GetResultSet Method tail

'Page Data Provider class Tail @1-A61BA892
End Class
'End Page Data Provider class Tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

