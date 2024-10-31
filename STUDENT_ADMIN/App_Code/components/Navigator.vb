'Navigator Class @0-B8CC0627
 'Navigator Class @0-15763942
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.ComponentModel

Namespace DECV_PROD2007.Controls

   Public Enum NavigatorItemType
      FirstOn
      FirstOff
      PrevOn
      PrevOff
      PageOn
      PageOff
      NextOn
      NextOff
      LastOn
      LastOff
      Manual
   End Enum 'NavigatorItemType
  


   Public Enum PagerStyle
      Centered
      Moving
   End Enum 'PagerStyle
  


   Public Class PagerItem
      Inherits Control
      Implements INamingContainer 'ToDo: Add Implements Clauses for implementation methods of these interface(s)
  

      
      Public Sub New(page As Integer)
         PageNumber = page
      End Sub 'New
  

      
      Public Property PageNumber() As Integer
         Get
            If Not (ViewState("PageNumber") Is Nothing) Then
               Return CInt(ViewState("PageNumber"))
            Else
               Return 1
            End If
         End Get
         Set
            ViewState("PageNumber") = value
         End Set
      End Property
  

       
      Protected Overrides Function OnBubbleEvent([source] As Object, e As EventArgs) As Boolean
         Dim args As New CommandEventArgs("Navigate", PageNumber)
         RaiseBubbleEvent(Me, args)
         Return True
      End Function 'OnBubbleEvent
   End Class 'PagerItem
  


   <ParseChildren(True)>  _
   Public Class Pager
      Inherits Control
      Implements INamingContainer 'ToDo: Add Implements Clauses for implementation methods of these interface(s)
      
      Private _pageOnTemplate As ITemplate = Nothing
      Private _pageOffTemplate As ITemplate = Nothing
      Private _style As PagerStyle = PagerStyle.Centered
      Private _pagerSize As Integer = 10
  

      
      Public Property Style() As PagerStyle
         Get
            Return _style
         End Get
         Set
            _style = value
         End Set
      End Property 
  

      
      Public Property PagerSize() As Integer
         Get
            Return _pagerSize
         End Get
         Set
            _pagerSize = value
         End Set
      End Property 
  

      

      Public Property PageNumber() As Integer
         Get
            If Not (ViewState("PageNumber") Is Nothing) Then
               Return CInt(ViewState("PageNumber"))
            Else
               Return 1
            End If
         End Get
         Set
            ViewState("PageNumber") = value
         End Set
      End Property 
  

      
      Public Property MaxPage() As Integer
         Get
            If Not (ViewState("MaxPage") Is Nothing) Then
               Return CInt(ViewState("MaxPage"))
            Else
               Return 1
            End If
         End Get
         Set
            ViewState("MaxPage") = value
         End Set
      End Property
  


      <PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(PagerItem))>  _
      Public Property PageOnTemplate() As ITemplate
         Get
            Return _pageOnTemplate
         End Get
         Set
            _pageOnTemplate = value
         End Set
      End Property
  

      
      Public Property PageOffTemplate() As ITemplate
         Get
            Return _pageOffTemplate
         End Get
         Set
            _pageOffTemplate = value
         End Set
      End Property
  

      
      Public Overrides Sub DataBind()
         EnsureChildControls()
         CreateChildControls()
         MyBase.DataBind()
      End Sub 'DataBind
  

      
      Protected Overrides Function OnBubbleEvent([source] As Object, e As EventArgs) As Boolean
         RaiseBubbleEvent(Me, e)
         Return True
      End Function 'OnBubbleEvent
  

      
      Protected Overrides Sub CreateChildControls()
         If (Not IsNothing(PageOnTemplate)) And (Not IsNothing(PageOffTemplate)) Then
            Controls.Clear()
            Dim [end] As Integer = 0
            Dim start As Integer
            If Style = PagerStyle.Moving Then
               start = System.Convert.ToInt32((PageNumber - 1) / PagerSize * PagerSize + 1)
               If start <> 1 Then
                  start -= 1
                  [end] += 1
               End If
               [end] += start + PagerSize
            Else
               start = System.Convert.ToInt32(PageNumber - PagerSize / 2)
			   If start + PagerSize > MaxPage Then
				  start = MaxPage - PagerSize + 1
			   End If
			   If start < 1 Then
                  start = 1
               End If
               [end] = start + PagerSize - 1
            End If 
            
            While start <= [end] And start <= MaxPage
               Dim i As New PagerItem(start)
               If start = PageNumber Then
                  PageOffTemplate.InstantiateIn(i)
               Else
                  PageOnTemplate.InstantiateIn(i)
               End If
               Controls.Add(i)
               start += 1
            End While
         Else
            Me.Controls.Add(New LiteralControl())
         End If
      End Sub 'CreateChildControls
   End Class 'Pager
  

    _ 
   
   Public Class NavigatorItem
      Inherits Control
      Implements INamingContainer 'ToDo: Add Implements Clauses for implementation methods of these interface(s)
      Private itemType As NavigatorItemType
  

      
      Public Property Type() As NavigatorItemType
         Get
            Return itemType
         End Get
         Set
            itemType = value
         End Set
      End Property
  

       
      Protected Overrides Sub AddParsedSubObject(obj As [Object])
         Controls.Add(CType(obj, Control))
      End Sub 'AddParsedSubObject
  

      
      Protected Overrides Function OnBubbleEvent([source] As Object, e As EventArgs) As Boolean
         Dim args As New CommandEventArgs("Navigate", Type.ToString())
         RaiseBubbleEvent(Me, args)
         Return True
      End Function 'OnBubbleEvent
   End Class 'NavigatorItem
  

   Public Class PageSizer
      Inherits DropDownList
      Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
         MyBase.OnSelectedIndexChanged(e)
         Dim args As New CommandEventArgs("ChangePageSize", Int32.Parse(Me.SelectedValue))
         RaiseBubbleEvent(Me,args)
      End Sub 'OnSelectedIndexChanged
   End Class 'PageSizer
  


   <ParseChildren(False)>  _
   Public Class Navigator
      Inherits Control
      Implements INamingContainer 'ToDo: Add Implements Clauses for implementation methods of these interface(s)
      Private FirstOn, FirstOff, PrevOn, PrevOff, NextOn, NextOff, LastOn, LastOff, Manual As NavigatorItem
      Private pager As Pager
      Private pagesizer As PageSizer
  

      
      Public Property PageNumber() As Integer
         Get
            If Not (ViewState("PageNumber") Is Nothing) Then
               Return CInt(ViewState("PageNumber"))
            Else
               Return 1
            End If
         End Get
         Set
            If value <> 0 Then
               ViewState("PageNumber") = value
            Else
               ViewState("PageNumber") = 1
            End If
         End Set
      End Property 
  

      
      Public Property MaxPage() As Integer
         Get
            If Not (ViewState("MaxPage") Is Nothing) Then
               Return CInt(ViewState("MaxPage"))
            Else
               Return 1
            End If
         End Get
         Set
            If value <> 0 Then
               ViewState("MaxPage") = value
            Else
               ViewState("MaxPage") = 1
            End If
         End Set
      End Property
  


      Public Property PageSize() As Integer
         Get
            If Not (ViewState("PageSize") Is Nothing) Then
               Return CInt(ViewState("PageSize"))
            Else
               Return 10
            End If
         End Get
         Set
            If value <> 0 Then
               ViewState("PageSize") = value
            Else
               ViewState("PageSize") = 10
            End If
         End Set
      End Property
  


      Public Property PageSizes() As Integer()
            Get
               Return CType(ViewState("PageSizes"),Integer())
            End Get
            Set(ByVal value As Integer())
               ViewState("PageSizes") = value
            End Set
      End Property
  

       
      Protected Overrides Function OnBubbleEvent([source] As Object, e As EventArgs) As Boolean
         If TypeOf [source] Is PageSizer Then
            PageSize = CInt(CType(e, CommandEventArgs).CommandArgument)
            If Not (Manual Is Nothing) Then 
               Try
                  PageNumber = Int32.Parse(CType(Manual.Controls(0),HtmlInputText).Value)
               Catch ex As FormatException
                  PageNumber = 1
               End Try
            Else
               PageNumber = 1
            End If
            Dim psArgs As New CommandEventArgs("ChangePageSize", New Integer() {PageSize,PageNumber})
            RaiseBubbleEvent(Me, psArgs)
            Return True
         End If                       
         If TypeOf [source] Is NavigatorItem Then
            If CStr(CType(e, CommandEventArgs).CommandArgument) = "FirstOn" Then
               PageNumber = 1
            End If
            If CStr(CType(e, CommandEventArgs).CommandArgument) = "PrevOn" Then
               PageNumber -= 1
            End If
            If CStr(CType(e, CommandEventArgs).CommandArgument) = "NextOn" Then
               PageNumber += 1
            End If
            If CStr(CType(e, CommandEventArgs).CommandArgument) = "LastOn" Then
               PageNumber = MaxPage
            End If
            If CStr(CType(e, CommandEventArgs).CommandArgument) = "Manual" Then
               Try
                  PageNumber = Int32.Parse(CType(Manual.Controls(0),HtmlInputText).Value)
               Catch ex As FormatException
                  PageNumber = 1
               End Try
            End If
         Else
            If TypeOf [source] Is Pager Then
               PageNumber = CInt(CType(e, CommandEventArgs).CommandArgument)
            Else
               PageNumber = 1
            End If
         End If
         Dim args As New CommandEventArgs("Navigate", PageNumber)
         RaiseBubbleEvent(Me, args)
         Return True
      End Function 
  

      
      Protected Overrides Sub AddParsedSubObject(obj As [Object])
         If TypeOf obj Is NavigatorItem Then
            Dim item As NavigatorItem = CType(obj, NavigatorItem)
            If item.Type = NavigatorItemType.FirstOn Then
               FirstOn = item
            End If
            If item.Type = NavigatorItemType.FirstOff Then
               FirstOff = item
            End If
            If item.Type = NavigatorItemType.PrevOn Then
               PrevOn = item
            End If
            If item.Type = NavigatorItemType.PrevOff Then
               PrevOff = item
            End If
            If item.Type = NavigatorItemType.NextOn Then
               NextOn = item
            End If
            If item.Type = NavigatorItemType.NextOff Then
               NextOff = item
            End If
            If item.Type = NavigatorItemType.LastOn Then
               LastOn = item
            End If
            If item.Type = NavigatorItemType.LastOff Then
               LastOff = item
            End If
            If item.Type = NavigatorItemType.Manual Then
               Manual = item
            End If
         End If
         If TypeOf obj Is Pager Then
            pager = CType(obj, Pager)
         End If
         If TypeOf obj Is PageSizer Then
            pagesizer = CType(obj, PageSizer)
         End If
         If TypeOf obj Is LiteralControl Then
            CType(obj, LiteralControl).Text = CType(obj, LiteralControl).Text.Replace(Chr(13)," "c).Replace(Chr(10)," "c)
         End If
         Controls.Add(CType(obj, Control))
      End Sub 
  

      
      Protected Overrides Sub OnPreRender(e As EventArgs)
         If Not (FirstOn Is Nothing) Then
            FirstOn.Visible = PageNumber > 1
         End If
         If Not (FirstOff Is Nothing) Then
            FirstOff.Visible = PageNumber = 1
         End If
         If Not (PrevOn Is Nothing) Then
            PrevOn.Visible = PageNumber > 1
         End If
         If Not (PrevOff Is Nothing) Then
            PrevOff.Visible = PageNumber = 1
         End If
         If Not (NextOn Is Nothing) Then
            NextOn.Visible = PageNumber < MaxPage And MaxPage <> 1
         End If
         If Not (NextOff Is Nothing) Then
            NextOff.Visible = PageNumber = MaxPage
         End If
         If Not (LastOn Is Nothing) Then
            LastOn.Visible = PageNumber < MaxPage And MaxPage <> 1
         End If
         If Not (LastOff Is Nothing) Then
            LastOff.Visible = PageNumber = MaxPage
         End If
         If Not (pager Is Nothing) Then
            pager.MaxPage = MaxPage
            pager.PageNumber = PageNumber
            pager.DataBind()
         End If
         If Not (pagesizer Is Nothing) Then
            pagesizer.Items.Clear()
            pagesizer.Items.Add(new ListItem(" - ","0"))
            For Each item As Integer In PageSizes
               pagesizer.Items.Add(item.ToString(""))
            Next item
            If Not IsNothing(pagesizer.Items.FindByValue(PageSize.ToString(""))) Then
               pagesizer.Items.FindByValue(PageSize.ToString("")).Selected = True
            Else
               pagesizer.Items(0).Selected = True
            End If
         End If
         MyBase.OnPreRender(e)
      End Sub 
   End Class 
End Namespace 

'End Navigator Class

