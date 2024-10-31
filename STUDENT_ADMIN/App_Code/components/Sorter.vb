'Sorter Class @0-07F2C4FF
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports DECV_PROD2007.Data
Namespace DECV_PROD2007.Controls
    Public Enum SorterItemTypes
        AscOn
        AscOff
        DescOn
        DescOff
    End Enum

    Public Enum SorterState
        Ascending
        Descending
        None
    End Enum

    Public Class SorterItem
        Inherits Control
        Implements INamingContainer
        Private m_type As SorterItemTypes

        Public Property Type As SorterItemTypes
            Get
            Return m_type
            End Get
            Set
            m_type = value
            End Set
        End Property

        Protected Overrides Sub AddParsedSubObject(ByVal obj As Object)
            Controls.Add(CType(obj, Control))
        End Sub
    End Class

    Public Class SortEventArgs
        Inherits CommandEventArgs
        Public Field As String
        Public State As SorterState

        Public Sub New(ByVal commandName As String, ByVal state As SorterState, ByVal field As String)
            MyBase.New(commandName,state)
            Me.Field = field
            Me.State = state
        End Sub
    End Class

    <ParseChildren(False)> _
    Public Class Sorter
        Inherits Control
        Implements INamingContainer
        Private AscOn,AscOff,DescOn,DescOff As SorterItem
        Private m_state As SorterState = SorterState.None
        Private m_field As String = ""
        Private m_ownerID As String = ""
        Private m_ownerState As String = ""
        Private m_ownerDir As SortDirections = SortDirections._Asc

        Public Property State As SorterState
            Get
                Return m_state
            End Get
            Set
                m_state = value
            End Set
        End Property

        Public Property Field As String
            Get
                Return m_field
            End Get
            Set
                m_field = value
            End Set
        End Property

        Public Property OwnerID As String
            Get
                Return m_ownerID
            End Get
            Set
                m_ownerID = value
            End Set
        End Property

        Public Property OwnerState As String
            Get
                Return m_ownerState
            End Get
            Set
                m_ownerState = value
            End Set
        End Property

        Public Property OwnerDir As SortDirections
            Get
                Return m_ownerDir
            End Get
            Set
                m_ownerDir = value
            End Set
        End Property

        Protected Overrides Function OnBubbleEvent(ByVal source As Object, ByVal e As EventArgs) As Boolean
            If TypeOf source Is SorterItem Then
                If CType(CType(e,CommandEventArgs).CommandArgument,String) = "AscOff" Then State = SorterState.Ascending
                If CType(CType(e,CommandEventArgs).CommandArgument,String) = "DescOff" Then State = SorterState.Descending
            Else
                State = SorterState.None
            End If
            Dim args As SortEventArgs = New SortEventArgs("Sort",State,Field)
            RaiseBubbleEvent(Me, args)
            Return True
        End Function

        Protected Overrides Sub AddParsedSubObject(ByVal obj AS Object)
            Controls.Add(CType(obj,Control))
            If TypeOf obj Is SorterItem Then
                If CType(obj, SorterItem).Type = SorterItemTypes.AscOn Then AscOn = CType(obj, SorterItem)
                If CType(obj, SorterItem).Type = SorterItemTypes.AscOff Then AscOff = CType(obj, SorterItem)
                If CType(obj, SorterItem).Type = SorterItemTypes.DescOn Then DescOn = CType(obj, SorterItem)
                If CType(obj, SorterItem).Type = SorterItemTypes.DescOff Then DescOff = CType(obj, SorterItem)
            End If
        End Sub

        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
            If Not OwnerState ="" And OwnerState =Field Then
                State = CType(IIf(OwnerDir = SortDirections._Asc, SorterState.Ascending, SorterState.Descending),SorterState)
            End If
            If Not IsNothing(AscOn) Then AscOn.Visible = (State = SorterState.Ascending)
            If Not IsNothing(AscOff) Then AscOff.Visible = (State = SorterState.Descending Or State = SorterState.None)
            If Not IsNothing(DescOn) Then DescOn.Visible = (State = SorterState.Descending)
            If Not IsNothing(DescOff) Then DescOff.Visible = (State = SorterState.Ascending Or State = SorterState.None)
            MyBase.OnPreRender(e)
        End Sub
    End Class
End Namespace
'End Sorter Class

