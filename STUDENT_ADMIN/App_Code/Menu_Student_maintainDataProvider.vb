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

Namespace DECV_PROD2007.Menu_Student_maintain 'Namespace @1-457F377F

'Page Data Class @1-C6E56D30
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public Link2 As TextField
    Public Link2Href As Object
    Public Link2HrefParameters As LinkParameterCollection
    Public Link3 As TextField
    Public Link3Href As Object
    Public Link3HrefParameters As LinkParameterCollection
    Public Link4 As TextField
    Public Link4Href As Object
    Public Link4HrefParameters As LinkParameterCollection
    Public Link5 As TextField
    Public Link5Href As Object
    Public Link5HrefParameters As LinkParameterCollection
    Public Link6 As TextField
    Public Link6Href As Object
    Public Link6HrefParameters As LinkParameterCollection
    Public Link7 As TextField
    Public Link7Href As Object
    Public Link7HrefParameters As LinkParameterCollection
    Public Link8 As TextField
    Public Link8Href As Object
    Public Link8HrefParameters As LinkParameterCollection
    Public Link9 As TextField
    Public Link9Href As Object
    Public Link9HrefParameters As LinkParameterCollection
    Public Link10 As TextField
    Public Link10Href As Object
    Public Link10HrefParameters As LinkParameterCollection
    Public Link11 As TextField
    Public Link11Href As Object
    Public Link11HrefParameters As LinkParameterCollection
    Public LinkMenu As TextField
    Public LinkMenuHref As Object
    Public LinkMenuHrefParameters As LinkParameterCollection
    Public Link12 As TextField
    Public Link12Href As Object
    Public Link12HrefParameters As LinkParameterCollection
    Public lblnotifymessage As TextField
    Public Sub New()
        Link1 = New TextField("",Nothing)
        Link1HrefParameters = New LinkParameterCollection()
        Link2 = New TextField("",Nothing)
        Link2HrefParameters = New LinkParameterCollection()
        Link3 = New TextField("",Nothing)
        Link3HrefParameters = New LinkParameterCollection()
        Link4 = New TextField("",Nothing)
        Link4HrefParameters = New LinkParameterCollection()
        Link5 = New TextField("",Nothing)
        Link5HrefParameters = New LinkParameterCollection()
        Link6 = New TextField("",Nothing)
        Link6HrefParameters = New LinkParameterCollection()
        Link7 = New TextField("",Nothing)
        Link7HrefParameters = New LinkParameterCollection()
        Link8 = New TextField("",Nothing)
        Link8HrefParameters = New LinkParameterCollection()
        Link9 = New TextField("",Nothing)
        Link9HrefParameters = New LinkParameterCollection()
        Link10 = New TextField("",Nothing)
        Link10HrefParameters = New LinkParameterCollection()
        Link11 = New TextField("",Nothing)
        Link11HrefParameters = New LinkParameterCollection()
        LinkMenu = New TextField("",Nothing)
        LinkMenuHrefParameters = New LinkParameterCollection()
        Link12 = New TextField("",Nothing)
        Link12HrefParameters = New LinkParameterCollection()
        lblnotifymessage = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Link1.SetValue(DBUtility.GetInitialValue("Link1"))
        item.Link2.SetValue(DBUtility.GetInitialValue("Link2"))
        item.Link3.SetValue(DBUtility.GetInitialValue("Link3"))
        item.Link4.SetValue(DBUtility.GetInitialValue("Link4"))
        item.Link5.SetValue(DBUtility.GetInitialValue("Link5"))
        item.Link6.SetValue(DBUtility.GetInitialValue("Link6"))
        item.Link7.SetValue(DBUtility.GetInitialValue("Link7"))
        item.Link8.SetValue(DBUtility.GetInitialValue("Link8"))
        item.Link9.SetValue(DBUtility.GetInitialValue("Link9"))
        item.Link10.SetValue(DBUtility.GetInitialValue("Link10"))
        item.Link11.SetValue(DBUtility.GetInitialValue("Link11"))
        item.LinkMenu.SetValue(DBUtility.GetInitialValue("LinkMenu"))
        item.Link12.SetValue(DBUtility.GetInitialValue("Link12"))
        item.lblnotifymessage.SetValue(DBUtility.GetInitialValue("lblnotifymessage"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Link1"
                    Return Link1
                Case "Link2"
                    Return Link2
                Case "Link3"
                    Return Link3
                Case "Link4"
                    Return Link4
                Case "Link5"
                    Return Link5
                Case "Link6"
                    Return Link6
                Case "Link7"
                    Return Link7
                Case "Link8"
                    Return Link8
                Case "Link9"
                    Return Link9
                Case "Link10"
                    Return Link10
                Case "Link11"
                    Return Link11
                Case "LinkMenu"
                    Return LinkMenu
                Case "Link12"
                    Return Link12
                Case "lblnotifymessage"
                    Return lblnotifymessage
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link1"
                    Link1 = CType(value, TextField)
                Case "Link2"
                    Link2 = CType(value, TextField)
                Case "Link3"
                    Link3 = CType(value, TextField)
                Case "Link4"
                    Link4 = CType(value, TextField)
                Case "Link5"
                    Link5 = CType(value, TextField)
                Case "Link6"
                    Link6 = CType(value, TextField)
                Case "Link7"
                    Link7 = CType(value, TextField)
                Case "Link8"
                    Link8 = CType(value, TextField)
                Case "Link9"
                    Link9 = CType(value, TextField)
                Case "Link10"
                    Link10 = CType(value, TextField)
                Case "Link11"
                    Link11 = CType(value, TextField)
                Case "LinkMenu"
                    LinkMenu = CType(value, TextField)
                Case "Link12"
                    Link12 = CType(value, TextField)
                Case "lblnotifymessage"
                    lblnotifymessage = CType(value, TextField)
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

