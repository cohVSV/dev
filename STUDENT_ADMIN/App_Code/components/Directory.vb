'Directory Control @0-893FD103
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Collections
Imports System.Diagnostics
Imports System.Web.UI
Imports System.Web.UI.WebControls


Namespace DECV_PROD2007.Controls

   Public Enum CCDirectoryItemType
      Header
      Footer
      CategoryHeader
      CategoryFooter
      CategorySeparator
      Subcategory
      SubcategorySeparator
      SubcategoriesTail
      ColumnSeparator
      NoRecords
   End Enum 'CCDirectoryItemType
    _
   Public Class CCDirectoryItem
      Inherits Control
      Implements INamingContainer 
      Private _itemIndex As Integer
      Private _itemType As CCDirectoryItemType
      Private _dataItem As ICCDirectoryDataItem
      
      
      Public Sub New(itemIndex As Integer, itemType As CCDirectoryItemType)
         Me._itemIndex = itemIndex
         Me._itemType = itemType
      End Sub 'New
      
      
      Public Overridable Property DataItem() As ICCDirectoryDataItem
         Get
            Return _dataItem
         End Get
         Set
            _dataItem = value
         End Set
      End Property
      
      
      Public Overridable ReadOnly Property ItemIndex() As Integer
         Get
            Return _itemIndex
         End Get
      End Property
      
      
      Public Overridable ReadOnly Property ItemType() As CCDirectoryItemType
         Get
            Return _itemType
         End Get
      End Property
      
      
      Protected Overrides Function OnBubbleEvent([source] As Object, e As EventArgs) As Boolean
         If TypeOf e Is CommandEventArgs Then
            Dim args As New CCDirectoryCommandEventArgs(Me, [source], CType(e, CommandEventArgs))
            
            RaiseBubbleEvent(Me, args)
            Return True
         End If
         Return False
      End Function 'OnBubbleEvent
      
      
      Friend Sub SetItemType(itemType As CCDirectoryItemType)
         Me._itemType = itemType
      End Sub 'SetItemType
   End Class 'CCDirectoryItem

   <DefaultProperty("DataSource")>  _
   Public Class CCDirectory
      Inherits WebControl
      Implements INamingContainer

	  <Serializable()>  _
      Private Class DummySource
         Implements ICCDirectoryDataItem 
         Private m_categoryID As String
         Private m_subcatID As String
         
         
         Public Property CategoryId() As String Implements ICCDirectoryDataItem.CategoryId
            Get
               Return m_categoryID
            End Get
            Set
               m_categoryID = value
            End Set
         End Property
         
         
         Public Property SubcategoryId() As String Implements ICCDirectoryDataItem.SubcategoryId
            Get
               Return m_subcatID
            End Get
            Set
               m_subcatID = value
            End Set
         End Property
      End Class 'DummySource
      
      
      Private Shared EventItemCreated As New Object()
      Private Shared EventItemDataBound As New Object() 
      Private Shared EventItemCommand As New Object()
      Private _dataSource As IEnumerable
      Private _footerTemplate As ITemplate 
      Private _headerTemplate As ITemplate
      Private _categoryHeaderTemplate As ITemplate
      Private _categoryFooterTemplate As ITemplate
      Private _categorySeparatorTemplate As ITemplate
      Private _subcategoryTemplate As ITemplate
      Private _subcategorySeparatorTemplate As ITemplate
      Private _subcategoriesTailTemplate As ITemplate
      Private _columnSeparatorTemplate As ITemplate
      Private _noRecordsTemplate As ITemplate
	  
	  <Bindable(True), Category("Data"),  Description("The data source used to build up the control."), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>  _
      Public Property DataSource() As IEnumerable
         Get
            Return _dataSource
         End Get
         Set
            _dataSource = value
         End Set
      End Property
	  
	  <Bindable(True), Category("Data"),  Description("The No. of colums"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>  _
      Public Property NumberOfColumns() As Integer
         Get
            If ViewState("columnCount") Is Nothing Then
               Return 1
            End If
            Return CInt(ViewState("columnCount"))
         End Get
         Set
            ViewState("columnCount") = value
         End Set
      End Property
	  
	  <Bindable(True), Category("Data"),  Description("The No. of subcategories"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>  _
      Public Property NumberOfSubCategories() As Integer
         Get
            If ViewState("subcategoryCount") Is Nothing Then
               Return -1
            End If
            Return CInt(ViewState("subcategoryCount"))
         End Get
         Set
            ViewState("subcategoryCount") = value
         End Set
      End Property
	  
	  <Browsable(False),  PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCDirectoryItem))>  _
      Public Overridable Property HeaderTemplate() As ITemplate
         Get
            Return _headerTemplate
         End Get
         Set
            _headerTemplate = value
         End Set
      End Property
	  
	  <Browsable(False),  PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCDirectoryItem))>  _
      Public Overridable Property FooterTemplate() As ITemplate
         Get
            Return _footerTemplate
         End Get
         Set
            _footerTemplate = value
         End Set
      End Property
	  
	  <Browsable(False),  PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCDirectoryItem))>  _
      Public Overridable Property CategoryHeaderTemplate() As ITemplate
         Get
            Return _categoryHeaderTemplate
         End Get
         Set
            _categoryHeaderTemplate = value
         End Set
      End Property
	  
	  <Browsable(False),  PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCDirectoryItem))>  _
      Public Overridable Property CategoryFooterTemplate() As ITemplate
         Get
            Return _categoryFooterTemplate
         End Get
         Set
            _categoryFooterTemplate = value
         End Set
      End Property
	  
	  <Browsable(False),  PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCDirectoryItem))>  _
      Public Overridable Property CategorySeparatorTemplate() As ITemplate
         Get
            Return _categorySeparatorTemplate
         End Get
         Set
            _categorySeparatorTemplate = value
         End Set
      End Property
	  
	  <Browsable(False),  PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCDirectoryItem))>  _
      Public Overridable Property SubcategoryTemplate() As ITemplate
         Get
            Return _subcategoryTemplate
         End Get
         Set
            _subcategoryTemplate = value
         End Set
      End Property
	  
	  <Browsable(False),  PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCDirectoryItem))>  _
      Public Overridable Property SubcategorySeparatorTemplate() As ITemplate
         Get
            Return _subcategorySeparatorTemplate
         End Get
         Set
            _subcategorySeparatorTemplate = value
         End Set
      End Property
	  
	  <Browsable(False),  PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCDirectoryItem))>  _
      Public Overridable Property SubcategoriesTailTemplate() As ITemplate
         Get
            Return _subcategoriesTailTemplate
         End Get
         Set
            _subcategoriesTailTemplate = value
         End Set
      End Property
	  
	  <Browsable(False),  PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCDirectoryItem))>  _
      Public Overridable Property ColumnSeparatorTemplate() As ITemplate
         Get
            Return _columnSeparatorTemplate
         End Get
         Set
            _columnSeparatorTemplate = value
         End Set
      End Property
	  
	  <Browsable(False),  PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(CCDirectoryItem))>  _
      Public Overridable Property NoRecordsTemplate() As ITemplate
         Get
            Return _noRecordsTemplate
         End Get
         Set
            _noRecordsTemplate = value
         End Set
      End Property
      
     Protected Overridable Sub OnItemCommand(e As CCDirectoryCommandEventArgs)
			RaiseEvent ItemCommand(Me ,e)
	 End Sub 'OnItemCommand
	 
	 Protected Overridable Sub OnItemCreated(e As CCDirectoryItemEventArgs)
			RaiseEvent ItemCreated(Me ,e)
     End Sub 'OnItemCreated
	 Protected Overridable Sub OnItemDataBound(e As CCDirectoryItemEventArgs)
			RaiseEvent ItemDataBound(Me ,e)
     End Sub 'OnItemDataBound


	  <Category("Action"), Description("Raised when a CommandEvent occurs within an item.")>  _
      Public Event ItemCommand As CCDirectoryCommandEventHandler
      
      <Category("Behavior"), Description("Raised when an item is created and is ready for customization.")>  _
      Public Event ItemCreated As CCDirectoryItemEventHandler
      
      <Category("Behavior"), Description("Raised when an item is data-bound.")>  _
      Public Event ItemDataBound As CCDirectoryItemEventHandler

	  Protected Overrides Sub CreateChildControls()
         Controls.Clear()
         
         If Not (ViewState("ItemCount") Is Nothing) Then
            CreateControlHierarchy(False)
         End If
      End Sub 'CreateChildControls
      
      
      Private Sub CreateControlHierarchy(useDataSource As Boolean)
         Dim dataSource As IEnumerable = Nothing
         Dim categories As ArrayList = Nothing
         Dim subindex As Integer = 0
         Dim count As Integer = - 1
         Dim elementCount As Integer = 1
         Dim columnElements As Integer = 0
         
         If useDataSource = False Then
            count = CInt(ViewState("ItemCount"))
            If count <> - 1 Then
               dataSource = CType(ViewState("Categories"), ArrayList)
            End If
         Else
            dataSource = Me.dataSource
            categories = New ArrayList()
         End If
         
         Dim index As Integer = 0
         Dim _dataItem As ICCDirectoryDataItem = Nothing
         Dim previousDataItem As ICCDirectoryDataItem = Nothing
         CreateItem(index, CCDirectoryItemType.Header, False, Nothing)
         If Not (dataSource Is Nothing) Then
            count = 0
            Dim subcatCount As Integer = 1
            Dim CreateCategory As Boolean = True
            For Each _dataItem In  dataSource
               If count <> 0 AndAlso previousDataItem.CategoryId <> _dataItem.CategoryId Then
                  elementCount += 1
               End If
               previousDataItem = _dataItem
               count += 1
            Next 
            columnElements = CInt(Math.Ceiling((CDbl(elementCount) / CDbl(NumberOfColumns))))
            
            previousDataItem = Nothing
            count = 0
            elementCount = 0
            For Each _dataItem In  dataSource
               If count <> 0 AndAlso previousDataItem.CategoryId <> _dataItem.CategoryId Then
                  CreateItem(index, CCDirectoryItemType.CategoryFooter, useDataSource, previousDataItem)
                  If count = 0 Or elementCount < columnElements Then
                     CreateItem(index, CCDirectoryItemType.CategorySeparator, useDataSource, Nothing)
                  End If
                  CreateCategory = True
               Else
                  If count <> 0 AndAlso (NumberOfSubCategories <> 0 And subcatCount <= NumberOfSubCategories + 1 Or NumberOfSubCategories = - 1) Then
                     CreateItem(index, CCDirectoryItemType.SubcategorySeparator, useDataSource, Nothing)
                  End If 
               End If
               If CreateCategory Then
                  If count <> 0 AndAlso elementCount >= columnElements Then
                     CreateItem(index, CCDirectoryItemType.ColumnSeparator, useDataSource, Nothing)
                     elementCount = 0
                  End If
                  CreateItem(index, CCDirectoryItemType.CategoryHeader, useDataSource, _dataItem)
                  CreateCategory = False
                  subcatCount = 1
                  elementCount += 1
               End If
               If (NumberOfSubCategories = - 1 Or subcatCount <= NumberOfSubCategories) And Not (_dataItem.SubcategoryId Is Nothing) Then
                  CreateItem(index, CCDirectoryItemType.Subcategory, useDataSource, _dataItem)
               End If
               If NumberOfSubCategories <> 0 AndAlso subcatCount = NumberOfSubCategories + 1 And Not (_dataItem.SubcategoryId Is Nothing) Then
                  CreateItem(index, CCDirectoryItemType.SubcategoriesTail, useDataSource, _dataItem)
               End If
               previousDataItem = _dataItem
               count += 1
               subcatCount += 1
               If useDataSource Then
                  Dim ds As New DummySource()
                  ds.CategoryId = _dataItem.CategoryId
                  ds.SubcategoryId = _dataItem.SubcategoryId
                  categories.Add(ds)
               End If
            Next 
            subindex += 1
         End If
         If count <= 0 Then
            CreateItem(index, CCDirectoryItemType.NoRecords, False, Nothing)
         Else
            CreateItem(index, CCDirectoryItemType.CategoryFooter, useDataSource, previousDataItem)
         End If
         CreateItem(index, CCDirectoryItemType.Footer, False, Nothing)
         If useDataSource Then
            ViewState("ItemCount") =IIf(Not (dataSource Is Nothing),count,- 1)
            ViewState("Categories") = categories
         End If
      End Sub 'CreateControlHierarchy
      
      
      Private Function CreateItem(ByRef itemIndex As Integer, itemType As CCDirectoryItemType, dataBind As Boolean, dataItem As Object) As CCDirectoryItem
         Dim item As New CCDirectoryItem(itemIndex, itemType)
         Dim e As New CCDirectoryItemEventArgs(item)
         Select Case itemType
            Case CCDirectoryItemType.CategoryFooter
               If Not (categoryFooterTemplate Is Nothing) Then
                  CategoryFooterTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCDirectoryItemType.CategoryHeader
               If Not (CategoryHeaderTemplate Is Nothing) Then
                  CategoryHeaderTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCDirectoryItemType.CategorySeparator
               If Not (CategorySeparatorTemplate Is Nothing) Then
                  CategorySeparatorTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCDirectoryItemType.Footer
               If Not (FooterTemplate Is Nothing) Then
                  FooterTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCDirectoryItemType.Header
               If Not (HeaderTemplate Is Nothing) Then
                  HeaderTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCDirectoryItemType.NoRecords
               If Not (NoRecordsTemplate Is Nothing) Then
                  NoRecordsTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCDirectoryItemType.Subcategory
               If Not (SubcategoryTemplate Is Nothing) Then
                  SubcategoryTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCDirectoryItemType.SubcategorySeparator
               If Not (SubcategorySeparatorTemplate Is Nothing) Then
                  SubcategorySeparatorTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCDirectoryItemType.SubcategoriesTail
               If Not (SubcategoriesTailTemplate Is Nothing) Then
                  SubcategoriesTailTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
            Case CCDirectoryItemType.ColumnSeparator
               If Not (ColumnSeparatorTemplate Is Nothing) Then
                  ColumnSeparatorTemplate.InstantiateIn(item)
                  itemIndex += 1
               End If
         End Select
         If dataBind Then
            item.DataItem = CType(dataItem, ICCDirectoryDataItem)
         End If
         OnItemCreated(e)
         Controls.Add(item)
         
         If dataBind Then
            item.DataBind()
            OnItemDataBound(e)
            
            item.DataItem = Nothing
         End If
         
         Return item
      End Function 'CreateItem
      
      
      Public Overrides Sub DataBind()
         MyBase.OnDataBinding(EventArgs.Empty)
         
         Controls.Clear()
         If HasChildViewState Then
            ClearChildViewState()
         End If 

         CreateControlHierarchy(True)
         ChildControlsCreated = True
      End Sub 'DataBind
      
      
      Protected Overrides Function OnBubbleEvent([source] As Object, e As EventArgs) As Boolean
         Dim handled As Boolean = False
         
         If TypeOf e Is CCDirectoryCommandEventArgs Then
            Dim ce As CCDirectoryCommandEventArgs = CType(e, CCDirectoryCommandEventArgs)
            
            OnItemCommand(ce)
            handled = True
         End If 
         
         Return handled
      End Function 'OnBubbleEvent
   End Class 'CCDirectory
   
   NotInheritable Public Class CCDirectoryCommandEventArgs
      Inherits CommandEventArgs
      
      Private _item As CCDirectoryItem
      Private _commandSource As Object
      
      
      Public Sub New(item As CCDirectoryItem, commandSource As Object, originalArgs As CommandEventArgs)
         MyBase.New(originalArgs)
         Me._item = item
         Me._commandSource = commandSource
      End Sub 'New
      
      
      Public ReadOnly Property Item() As CCDirectoryItem
         Get
            Return _item
         End Get
      End Property
      
      
      Public ReadOnly Property CommandSource() As Object
         Get
            Return _commandSource
         End Get
      End Property
   End Class 'CCDirectoryCommandEventArgs
   
   
   Public Delegate Sub CCDirectoryCommandEventHandler(sender As Object, e As CCDirectoryCommandEventArgs)
   
   NotInheritable Public Class CCDirectoryItemEventArgs
      Inherits EventArgs
      
      Private _item As CCDirectoryItem
      
      
      Public Sub New(item As CCDirectoryItem)
         Me._item = item
      End Sub 'New
      
      
      Public ReadOnly Property Item() As CCDirectoryItem
         Get
            Return _item
         End Get
      End Property
   End Class 'CCDirectoryItemEventArgs
   
   
   Public Delegate Sub CCDirectoryItemEventHandler(sender As Object, e As CCDirectoryItemEventArgs)
 
   
   Public Interface ICCDirectoryDataItem
      
      Property CategoryId() As String
      
      Property SubcategoryId() As String

   End Interface 'ICCDirectoryDataItem
End Namespace 


'End Directory Control

