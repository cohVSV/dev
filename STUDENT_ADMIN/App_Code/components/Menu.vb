'Menu Control @0-5E6842D1
'Target Framework version is 3.5
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Collections
Imports System.Collections.Specialized
Imports DECV_PROD2007.Data
Imports DECV_PROD2007.Configuration


Namespace DECV_PROD2007.Controls

	Public Class CCMenuItem
	    Inherits Control
	    Implements INamingContainer
	    Private _itemLevel As Integer
	    Private _dataItem As ICCMenuDataItem
	    Public hasChildren As Boolean
	    
	    Public Sub New()
	        Me._itemLevel = 1
	    End Sub
	    Public Sub New(ByVal level As Integer)
	        _itemLevel = level
	    End Sub

	    Public Property ItemLevel() As Integer
	        Get
	            Return _itemLevel
	        End Get
	        Set
	            _itemLevel = Value
	        End Set
	    End Property

	    Public Property DataItem() As ICCMenuDataItem
	        Get
	            Return _dataItem
	        End Get
	        Set
	            _dataItem = Value
	        End Set
	    End Property
	End Class

	Public NotInheritable Class CCMenuItemEventArgs
	    Inherits EventArgs
	    Public Item As CCMenuItem
	    Public Sub New(ByVal data As CCMenuItem)
	        Me.Item = data
	    End Sub
	End Class

	<PersistChildren(True)> _ 
	Public Class CCMenu
	    Inherits WebControl
	    Implements INamingContainer
	    <Serializable()> _ 
	    Private Class MenuDataSource
	        Implements ICCMenuDataItem
	        Private m_itemID As String
	        Private m_itemParentID As String
	        
	        Public Property ItemId() As String Implements ICCMenuDataItem.itemId
	            Get
	                Return m_itemID
	            End Get
	            Set
	                m_itemID = Value
	            End Set
	        End Property
	        
	        Public Property ParentItemId() As String Implements ICCMenuDataItem.parentItemId
	            Get
	                Return m_itemParentID
	            End Get
	            Set
	                m_itemParentID = Value
	            End Set
	        End Property
	    End Class
	    
	    Private _dataSource As IEnumerable
	    Private menuArray As New ArrayList()
	    Private _rootId As String
	    
	    Public Property RootId() As String
	        Get
	            Return _rootId
	        End Get
	        Set
	            _rootId = Value
	        End Set
	    End Property

	    Public Property DataSource() As IEnumerable
	        Get
	            Return _dataSource
	        End Get
	        Set
	            _dataSource = Value
	        End Set
	    End Property

	    
	    Protected Overloads Overrides ReadOnly Property TagKey() As HtmlTextWriterTag
	        Get
	            Return HtmlTextWriterTag.Div
	        End Get
	    End Property

	    #Region "Templates"
	    Private _itemtemplate As ITemplate
	    Private _itemclosetemplate As ITemplate
	    Private _headertemplate As ITemplate
	    Private _levelopentemplate As ITemplate
	    Private _levelclosetemplate As ITemplate
	    Private _footertemplate As ITemplate
	    
	    <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCMenuItem))> _ 
	    Public Property ItemTemplate() As ITemplate
	        Get
	            Return _itemtemplate
	        End Get
	        Set
	            _itemtemplate = Value
	        End Set
	    End Property
	    
	    <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCMenuItem))> _ 
	    Public Property ItemCloseTemplate() As ITemplate
	        Get
	            Return _itemclosetemplate
	        End Get
	        Set
	            _itemclosetemplate = Value
	        End Set
	    End Property
	    
	    <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCMenuItem))> _ 
	    Public Property HeaderTemplate() As ITemplate
	        Get
	            Return _headertemplate
	        End Get
	        Set
	            _headertemplate = Value
	        End Set
	    End Property
	    
	    <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCMenuItem))> _ 
	    Public Property LevelOpenTemplate() As ITemplate
	        Get
	            Return _levelopentemplate
	        End Get
	        Set
	            _levelopentemplate = Value
	        End Set
	    End Property
	    
	    
	    <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCMenuItem))> _ 
	    Public Property LevelCloseTemplate() As ITemplate
	        Get
	            Return _levelclosetemplate
	        End Get
	        Set
	            _levelclosetemplate = Value
	        End Set
	    End Property
	    
	    <Browsable(False), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCMenuItem))> _ 
	    Public Property FooterTemplate() As ITemplate
	        Get
	            Return _footertemplate
	        End Get
	        Set
	            _footertemplate = Value
	        End Set
	    End Property
	    
	    #End Region
	    
	    Public Event ItemDataBound As CCMenuItemEventHandler
	    
	    Private Function IsTopLevelNode(ByVal mi As ICCMenuDataItem) As Boolean
	        If mi.ParentItemId Is Nothing OrElse mi.ParentItemId = "" OrElse mi.ParentItemId = _rootId Then
	            Return True
	        Else
	            Return False
	        End If
	    End Function
	    
	    Private Function GetChildren(ByVal mi As ICCMenuDataItem) As ArrayList
	        Dim result As New ArrayList()
	        Dim dataSource As IEnumerable = Nothing
	        If Not (_dataSource Is Nothing) Then
	            dataSource = _dataSource
	        Else
	            dataSource = CType(ViewState("MenuItems"), ArrayList)
	        End If
	        For Each item As ICCMenuDataItem In dataSource
	            If item.ParentItemId = mi.ItemId Then
	                result.Add(item)
	            End If
	        Next
	        Return result
	    End Function
	    
	    Private Sub AddItem(ByVal item As ICCMenuDataItem, ByVal level As Integer)
	        Dim mi As New CCMenuItem(level)
	        mi.DataItem = item
	        menuArray.Add(mi)
	        If GetChildren(item).Count > 0 Then
	            For Each children As ICCMenuDataItem In GetChildren(item)
	                AddItem(children, level + 1)
	            Next
	        End If
	    End Sub

	    Private Sub InstantiateArray(ByVal dataBind As Boolean)
	        For Each mi As CCMenuItem In menuArray
	            Dim e As New CCMenuItemEventArgs(mi)
	            Dim index As Integer = menuArray.IndexOf(mi)
	            Dim nextlevel As Integer = -1
	            If index <> menuArray.Count - 1 Then
	                nextlevel = DirectCast(menuArray(index + 1), CCMenuItem).ItemLevel
	            End If
	            If mi.ItemLevel = nextlevel OrElse (mi.ItemLevel = 1 AndAlso nextlevel = -1) Then
	                _itemtemplate.InstantiateIn(mi)
	                _itemclosetemplate.InstantiateIn(mi)
	            End If
	            If mi.ItemLevel < nextlevel Then
			mi.hasChildren = True
	                _itemtemplate.InstantiateIn(mi)
	                _levelopentemplate.InstantiateIn(mi)
	            End If
	            If mi.ItemLevel > nextlevel AndAlso nextlevel <> -1 Then
	                _itemtemplate.InstantiateIn(mi)
	                _itemclosetemplate.InstantiateIn(mi)
	                For i As Integer = mi.ItemLevel To nextlevel + 1 Step -1
	                    _levelclosetemplate.InstantiateIn(mi)
	                Next
	            End If
	            If mi.ItemLevel <> 1 AndAlso nextlevel = -1 Then
	                _itemtemplate.InstantiateIn(mi)
	                _itemclosetemplate.InstantiateIn(mi)
	                For i As Integer = mi.ItemLevel To 2 Step -1
	                    _levelclosetemplate.InstantiateIn(mi)
	                Next
	            End If
	            Controls.Add(mi)
	            
	            If dataBind Then
	                mi.DataBind()
	                RaiseEvent ItemDataBound(Me, New CCMenuItemEventArgs(mi))
	                mi.DataItem = Nothing
	            End If
	        Next
	    End Sub
	    
	    Private Sub CreateItemsHierarchy(ByVal useDataSource As Boolean)
	        Dim dataSource As IEnumerable = Nothing
	        Dim items As ArrayList = Nothing
	        
	        If useDataSource Then
	            dataSource = Me._dataSource
	            items = New ArrayList()
	        Else
	            dataSource = DirectCast(ViewState("MenuItems"), ArrayList)
	        End If

		If Not (dataSource Is Nothing) Then
		    If Not (_headertemplate Is Nothing) Then
			Dim header As New CCMenuItem()
			_headertemplate.InstantiateIn(header)
			Controls.Add(header)
	            End If
	            For Each item As ICCMenuDataItem In dataSource
			If useDataSource Then
				Dim ms As New MenuDataSource()
	                        ms.ItemId = item.ItemId
	                        ms.ParentItemId = item.ParentItemId
	                        items.Add(ms)
	                    End If
	                    If IsTopLevelNode(item) Then
	                        AddItem(item, 1)
			End If
		    Next

		    InstantiateArray(useDataSource)

		    If Not (_footertemplate Is Nothing) Then
			Dim footer As New CCMenuItem()
			_footertemplate.InstantiateIn(footer)
			Controls.Add(footer)
		    End If
		Else
		    Me.Visible = False
		End If	       
 
	        If useDataSource Then
	            ViewState("MenuItems") = items
	        End If
	    End Sub
	    
	    Protected Overrides Sub OnPreRender(e As EventArgs)
	        MyBase.OnPreRender(e)
	        Me.Attributes.Remove("MenuType")
	    End Sub
	    

	    Protected Overloads Overrides Sub CreateChildControls()
	        Controls.Clear()
	        CreateItemsHierarchy(False)
	    End Sub

	    Public Overloads Overrides Sub DataBind()
	        ClearChildViewState()
	        Controls.Clear()
	        menuArray.Clear()
	        CreateItemsHierarchy(True)
	        ChildControlsCreated = True
	    End Sub
	End Class

	Public Delegate Sub CCMenuItemEventHandler(ByVal sender As Object, ByVal e As CCMenuItemEventArgs)

	Public Interface ICCMenuDataItem
	    Property ItemId() As String
	    Property ParentItemId() As String
	End Interface
End Namespace                              

'End Menu Control

