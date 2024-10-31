'ReportLabel Control @0-B164E322
'Target Framework version is 3.5
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports DECV_PROD2007.Data


Namespace DECV_PROD2007.Controls
 _
Public Enum ReportLabelSourceType
   DBColumn
   CodeExpression
   SpecialValue
End Enum 'ReportLabelSourceType
 _
Public Enum ContentType
   [Text]
   HTML
End Enum 'ContentType
 _
Public Enum TotalFunction
   None
   Sum
   Count
   Min
   Max
   Avg
End Enum 'TotalFunction
<DefaultProperty("Text")>  _ 
Public Class ReportLabel
   Inherits System.Web.UI.WebControls.Literal
   Private _type As FieldType
   Private _format As String = ""
   Private _sourceType As ReportLabelSourceType
   Private _source As String = ""
   Private _emptyText As String
   Private _contentType As ContentType = ContentType.Text
   Private _hideDuplicates As Boolean
   Private _function As TotalFunction = TotalFunction.None
   Private _percentOf As String = ""
   Private _resetAt As String = "Report"
   
   Public Property SourceType() As ReportLabelSourceType
      Get
         Return _sourceType
      End Get
      Set
         _sourceType = value
      End Set
   End Property
   
   Public Property DataType() As FieldType
      Get
         Return _type
      End Get
      Set
         _type = value
      End Set
   End Property
   
   Public Property Format() As String
      Get
         Return _format
      End Get
      Set
         _format = value
      End Set
   End Property

   Public Property [Source]() As String
      Get
         Return _source
      End Get
      Set
         _source = value
      End Set
   End Property
   
   Public Property EmptyText() As String
      Get
         Return _emptyText
      End Get
      Set
         _emptyText = value
      End Set
   End Property
   
   Public Property ContentType() As ContentType
      Get
         Return _contentType
      End Get
      Set
         _contentType = value
      End Set
   End Property
   
   Public Property HideDuplicates() As Boolean
      Get
         Return _hideDuplicates
      End Get
      Set
         _hideDuplicates = value
      End Set
   End Property
   
   Public Property [Function]() As TotalFunction
      Get
         Return _function
      End Get
      Set
         _function = value
      End Set
   End Property
   
   Public Property PercentOf() As String
      Get
         Return _percentOf
      End Get
      Set
         _percentOf = value
      End Set
   End Property
   
   Public Property ResetAt() As String
      Get
         Return _resetAt
      End Get
      Set
         _resetAt = value
      End Set
   End Property
   
   Protected Overrides Sub Render(writer As HtmlTextWriter) 
      Dim oldValue As String = Text
      If [Text] Is Nothing Or [Text] = "" Then
         [Text] = EmptyText
      End If
      If ContentType.Text = Me.ContentType Then
         [Text] = Page.Server.HtmlEncode([Text])
      End If
	  MyBase.Render(writer)
	  Text = oldValue
   End Sub 

   Protected Overrides Function SaveViewState() As Object
 	  ViewState.SetItemDirty("Text",True)
	  Return MyBase.SaveViewState ()
   End Function
End Class 'ReportLabel
	

End Namespace
'End ReportLabel Control

