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

Namespace DECV_PROD2007.Header 'Namespace @1-69F39CD6

'Page Data Class @1-1B321010
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public LinkMenu As TextField
    Public LinkMenuHref As Object
    Public LinkMenuHrefParameters As LinkParameterCollection
    Public ImageLink1 As TextField
    Public ImageLink1Href As Object
    Public ImageLink1HrefParameters As LinkParameterCollection
    Public ImageLink2 As TextField
    Public ImageLink2Href As Object
    Public ImageLink2HrefParameters As LinkParameterCollection
    Public lblnotifymessage As TextField
    Public Sub New()
        LinkMenu = New TextField("",Nothing)
        LinkMenuHrefParameters = New LinkParameterCollection()
        ImageLink1 = New TextField("",Nothing)
        ImageLink1HrefParameters = New LinkParameterCollection()
        ImageLink2 = New TextField("",Nothing)
        ImageLink2HrefParameters = New LinkParameterCollection()
        lblnotifymessage = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.LinkMenu.SetValue(DBUtility.GetInitialValue("LinkMenu"))
        item.ImageLink1.SetValue(DBUtility.GetInitialValue("ImageLink1"))
        item.ImageLink2.SetValue(DBUtility.GetInitialValue("ImageLink2"))
        item.lblnotifymessage.SetValue(DBUtility.GetInitialValue("lblnotifymessage"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "LinkMenu"
                    Return LinkMenu
                Case "ImageLink1"
                    Return ImageLink1
                Case "ImageLink2"
                    Return ImageLink2
                Case "lblnotifymessage"
                    Return lblnotifymessage
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "LinkMenu"
                    LinkMenu = CType(value, TextField)
                Case "ImageLink1"
                    ImageLink1 = CType(value, TextField)
                Case "ImageLink2"
                    ImageLink2 = CType(value, TextField)
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

