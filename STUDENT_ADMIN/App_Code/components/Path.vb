'Path Class @0-97DE8896
'Target Framework version is 3.5
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Collections
Imports System.Diagnostics
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace DECV_PROD2007.Controls
    Public Enum CCPathItemType
        Header
        Footer
        PathComponent
        CurrentCategory
    End Enum 'CCPathItemType

    Public Class CCPathItem
        Inherits Control
        Implements INamingContainer
        Private m_itemIndex As Integer
        Private m_itemType As CCPathItemType
        Private m_dataItem As Object

        Public Sub New(itemIndex As Integer, itemType As CCPathItemType)
            Me.m_itemIndex = itemIndex
            Me.m_itemType = itemType
        End Sub 'New

        Public Overridable Property DataItem() As Object
            Get
                Return m_dataItem
            End Get
            Set
                m_dataItem = value
            End Set
        End Property

        Public Overridable ReadOnly Property ItemIndex() As Integer
            Get
                Return m_itemIndex
            End Get
        End Property

        Public Overridable ReadOnly Property ItemType() As CCPathItemType
            Get
                Return m_itemType
            End Get
        End Property

        Protected Overrides Function OnBubbleEvent([source] As Object, e As EventArgs) As Boolean
            If TypeOf e Is CommandEventArgs Then
                ' Add the information about Item to CommandEvent.
                Dim args As New CCPathCommandEventArgs(Me, [source], CType(e, CommandEventArgs))

                RaiseBubbleEvent(Me, args)
                Return True
            End If
            Return False
        End Function 'OnBubbleEvent

        Friend Sub SetItemType(itemType As CCPathItemType)
            Me.m_itemType = itemType
        End Sub 'SetItemType
    End Class 'CCPathItem

    <DefaultProperty("DataSource")>  _
    Public Class CCPath
        Inherits WebControl
        Implements INamingContainer 

        Private Shared EventItemCreated As New Object()
        Private Shared EventItemDataBound As New Object()
        Private Shared EventItemCommand As New Object()

        Private m_dataSource As IEnumerable
        Private m_footerTemplate As ITemplate
        Private m_headerTemplate As ITemplate
        Private m_pathComponentTemplate As ITemplate
        Private m_currentCategoryTemplate As ITemplate

        <Bindable(True), _
            Category("Data"), _
            Description("The data source used to build up the control."), _
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>  _
        Public Property DataSource() As IEnumerable
            Get
                Return m_dataSource
            End Get
            Set
                m_dataSource = value
            End Set
        End Property

        <Browsable(False), _
            PersistenceMode(PersistenceMode.InnerProperty), _
            TemplateContainer(GetType(CCPathItem))> _
        Public Overridable Property HeaderTemplate() As ITemplate
            Get
                Return m_headerTemplate
            End Get
            Set
                m_headerTemplate = value
            End Set
        End Property

        <Browsable(False), _
            PersistenceMode(PersistenceMode.InnerProperty), _
            TemplateContainer(GetType(CCPathItem))> _
        Public Overridable Property FooterTemplate() As ITemplate
            Get
                Return m_footerTemplate
            End Get
            Set
                m_footerTemplate = value
            End Set
        End Property

        <Browsable(False), _
            PersistenceMode(PersistenceMode.InnerProperty), _
            TemplateContainer(GetType(CCPathItem))> _
        Public Overridable Property PathComponentTemplate() As ITemplate
            Get
                Return m_pathComponentTemplate
            End Get
            Set
                m_pathComponentTemplate = value
            End Set
        End Property

        <Browsable(False), _
            PersistenceMode(PersistenceMode.InnerProperty), _
            TemplateContainer(GetType(CCPathItem))> _
        Public Overridable Property CurrentCategoryTemplate() As ITemplate
            Get
                Return m_currentCategoryTemplate
            End Get
            Set
                m_currentCategoryTemplate = value
            End Set
        End Property

        Protected Overridable Sub OnItemCommand(e As CCPathCommandEventArgs)
            RaiseEvent ItemCommand(Me ,e)
        End Sub 'OnItemCommand
        
        Protected Overridable Sub OnItemCreated(e As CCPathItemEventArgs)
            RaiseEvent ItemCreated(Me ,e)
        End Sub 'OnItemCreated
        
        Protected Overridable Sub OnItemDataBound(e As CCPathItemEventArgs)
            RaiseEvent ItemDataBound(Me ,e)
        End Sub 'OnItemDataBound 

        <Category("Action"), _
            Description("Raised when a CommandEvent occurs within an item.")> _
        Public Event ItemCommand As CCPathCommandEventHandler
        <Category("Behavior"), _
            Description("Raised when an item is created and is ready for customization.")> _
        Public Event ItemCreated As CCPathItemEventHandler

        <Category("Behavior"), _
            Description("Raised when an item is data-bound.")> _
        Public Event ItemDataBound As CCPathItemEventHandler

        Protected Overrides Sub CreateChildControls()
            Controls.Clear()

            If Not (ViewState("ItemCount") Is Nothing) Then
                ' Create the control hierarchy using the view state, 
                ' not the data source.
                CreateControlHierarchy(False)
            End If
        End Sub 'CreateChildControls

        Private Sub CreateControlHierarchy(useDataSource As Boolean)
            Dim dataSource As IEnumerable = Nothing
            Dim count As Integer = - 1

            If useDataSource = False Then
                ' ViewState must have a non-null value for ItemCount because this is checked 
                '  by CreateChildControls.
                count = CInt(ViewState("ItemCount"))
                If count <> - 1 Then
                    dataSource = CType(ViewState("Categories"), ArrayList)
                End If
            Else
                dataSource = Me.dataSource
            End If

            Dim index As Integer = 0
            Dim categories As New ArrayList()
            CreateItem(index, CCPathItemType.Header, useDataSource, Nothing)
            If Not (dataSource Is Nothing) Then
                count = 0
                Dim lastDataItem As Object = Nothing
                Dim dataItem As Object
                For Each dataItem In  dataSource
                    If count <> 0 Then
                        CreateItem(index, CCPathItemType.PathComponent, useDataSource, lastDataItem)
                    End If
                    lastDataItem = dataItem
                    count += 1
                    If useDataSource Then
                        categories.Add("")
                    End If
                Next dataItem
                If Not (lastDataItem Is Nothing) Then
                    index -= 1
                    CreateItem(index, CCPathItemType.CurrentCategory, useDataSource, lastDataItem)
                End If
            End If
            CreateItem(index, CCPathItemType.Footer, useDataSource, Nothing)

            If useDataSource Then
                ' Save the number of items contained for use in round trips.
                ViewState("ItemCount") = CType(Iif( Not (dataSource Is Nothing) ,count, - 1),Integer)
                ViewState("Categories") = categories
            End If
        End Sub 'CreateControlHierarchy

        Private Function CreateItem(ByRef itemIndex As Integer, itemType As CCPathItemType, dataBind As Boolean, dataItem As Object) As CCPathItem
            Dim item As New CCPathItem(itemIndex, itemType)
            Dim e As New CCPathItemEventArgs(item)
            Select Case itemType
                Case CCPathItemType.Footer
                    If Not (FooterTemplate Is Nothing) Then
                        FooterTemplate.InstantiateIn(item)
                    End If
                Case CCPathItemType.Header
                    If Not (HeaderTemplate Is Nothing) Then
                        HeaderTemplate.InstantiateIn(item)
                    End If
                Case CCPathItemType.CurrentCategory
                    If Not (CurrentCategoryTemplate Is Nothing) Then
                        CurrentCategoryTemplate.InstantiateIn(item)
                    End If
                Case CCPathItemType.PathComponent
                    If Not (PathComponentTemplate Is Nothing) Then
                        PathComponentTemplate.InstantiateIn(item)
                    End If
            End Select
            If dataBind Then
                item.DataItem = dataItem
            End If
            OnItemCreated(e)
            Controls.Add(item)

            If dataBind Then
                item.DataBind()
                OnItemDataBound(e)

                item.DataItem = Nothing
            End If
            itemIndex += 1
            Return item
        End Function 'CreateItem

        Public Overrides Sub DataBind()
            ' Controls with a data-source property perform their custom data binding
            ' by overriding DataBind.
            ' Evaluate any data-binding expressions on the control itself.
            MyBase.OnDataBinding(EventArgs.Empty)

            ' Reset the control state.
            Controls.Clear()
            If HasChildViewState Then
                ClearChildViewState()
            End If 

            '  Create the control hierarchy using the data source.
            CreateControlHierarchy(True)
            ChildControlsCreated = True
        End Sub 'DataBind

        Protected Overrides Function OnBubbleEvent([source] As Object, e As EventArgs) As Boolean
            ' Handle events raised by children by overriding OnBubbleEvent.
            Dim handled As Boolean = False

            If TypeOf e Is CCPathCommandEventArgs Then
                Dim ce As CCPathCommandEventArgs = CType(e, CCPathCommandEventArgs)

                OnItemCommand(ce)
                handled = True
            End If

            Return handled
        End Function 'OnBubbleEvent
    End Class 'CCPath

    NotInheritable Public Class CCPathCommandEventArgs
        Inherits CommandEventArgs

        Private m_item As CCPathItem
        Private m_commandSource As Object

        Public Sub New(item As CCPathItem, commandSource As Object, originalArgs As CommandEventArgs)
            MyBase.New(originalArgs)
            Me.m_item = item
            Me.m_commandSource = commandSource
        End Sub 'New

        Public ReadOnly Property Item() As CCPathItem
            Get
                Return m_item
            End Get
        End Property

        Public ReadOnly Property CommandSource() As Object
            Get
                Return m_commandSource
            End Get
        End Property
    End Class 'CCPathCommandEventArgs

    Public Delegate Sub CCPathCommandEventHandler([source] As Object, e As CCPathCommandEventArgs)

    NotInheritable Public Class CCPathItemEventArgs
        Inherits EventArgs

        Private m_item As CCPathItem


        Public Sub New(item As CCPathItem)
            Me.m_item = item
        End Sub 'New

        Public ReadOnly Property Item() As CCPathItem
            Get
                Return m_item
            End Get
        End Property
    End Class 'CCPathItemEventArgs

    Public Delegate Sub CCPathItemEventHandler(sender As Object, e As CCPathItemEventArgs)
End Namespace 

'End Path Class

