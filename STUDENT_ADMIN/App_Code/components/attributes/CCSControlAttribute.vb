'CCSControlAttribute class @0-9B56964C
'Target Framework version is 3.5
Imports System
Imports System.Collections
Imports System.Web.UI
Imports DECV_PROD2007.Data

Namespace DECV_PROD2007.Controls

   Public Class CCSControlAttribute
      
      Public Sub New()
      End Sub 'New
      
      
      Public Sub New(name As String, dataType As FieldType, val As Object)
         MyClass.New(name, dataType, val, "")
      End Sub 'New
      
      
      Public Sub New(name As String, dataType As FieldType, val As Object, format As String)
         Me.Name = name
         Me.DataType = dataType
         Me.Value = val
         Me.Format = format
      End Sub 'New
      
      
      Private m_Name As String
      
      Public Property Name() As String
         Get
            Return m_Name
         End Get
         Set
            m_Name = value
         End Set
      End Property
      Private m_Value As Object
      
      Public Overridable Property Value() As Object
         Get
            Return m_Value
         End Get
         Set
            m_Value = value
         End Set
      End Property
      Private m_DataType As FieldType
      
      Public Property DataType() As FieldType
         Get
            Return m_DataType
         End Get
         Set
            m_DataType = value
         End Set
      End Property
      Private m_Format As String
      
      Public Property Format() As String
         Get
            Return m_Format
         End Get
         Set
            m_Format = value
         End Set
      End Property
      
      
      Public Overrides Function ToString() As String
         If Value Is Nothing Then
            Return ""
         End If
         If Format Is Nothing Or Format = "" Then
            Return Value.ToString()
         End If 
         If TypeOf Value Is FieldBase Then
            Return CType(Value, FieldBase).GetFormattedValue()
         Else
            Return Value.ToString()
         End If
      End Function 'ToString
   End Class 'CCSControlAttribute

   
   Public Class CCSControlSpecialAttribute
      Inherits CCSControlAttribute
      Private _Container As Control
      
      Public Property Container() As Control
         Get
            Return _Container
         End Get
         Set
            _Container = value
         End Set
      End Property
      
      
      Public Sub New(container As Control)
         Me.Container = container
      End Sub 'New
      
      
      Public Sub New(container As Control, value As CCSControlAttribute)
         MyClass.New(container)
         Me.Name = value.Name
         Me.Format = value.Format
         Me.DataType = value.DataType
         Me.Value = value.Value
      End Sub 'New
      
      Private _IsSpecialAttribute As Object = Nothing
      
      Public ReadOnly Property IsSpecialAttribute() As Boolean
         Get
            Return Not (Me.Value Is Nothing)
         End Get
      End Property
      
      
      Public Overrides Property Value() As Object
         Get
            If Name.ToLower() = "checked" And TypeOf Container Is System.Web.UI.WebControls.CheckBox Then
               Return CType(Container, System.Web.UI.WebControls.CheckBox).Checked
            End If
            If Name.ToLower() = "readonly" And TypeOf Container Is System.Web.UI.WebControls.TextBox Then
               Return CType(Container, System.Web.UI.WebControls.TextBox).ReadOnly
            End If
            If Name.ToLower() = "disabled" And TypeOf Container Is System.Web.UI.WebControls.WebControl Then
               Return CType(Container, System.Web.UI.WebControls.WebControl).Enabled
            End If
            If Name.ToLower() = "disabled" And TypeOf Container Is System.Web.UI.HtmlControls.HtmlControl Then
               Return CType(Container, System.Web.UI.HtmlControls.HtmlControl).Disabled
            End If
            If Name.ToLower() = "multiple" And TypeOf Container Is System.Web.UI.HtmlControls.HtmlSelect Then
               Return CType(Container, System.Web.UI.HtmlControls.HtmlSelect).Multiple
            End If 
            Return Nothing
         End Get
         Set
            _IsSpecialAttribute = True
            If Name.ToLower() = "checked" And TypeOf Container Is System.Web.UI.WebControls.CheckBox Then
               CType(Container, System.Web.UI.WebControls.CheckBox).Checked = Convert.ToBoolean(value.ToString())
            End If
            If Name.ToLower() = "readonly" And TypeOf Container Is System.Web.UI.WebControls.TextBox Then
               CType(Container, System.Web.UI.WebControls.TextBox).ReadOnly = Convert.ToBoolean(value.ToString())
            Else
               If Name.ToLower() = "disabled" And TypeOf Container Is System.Web.UI.WebControls.WebControl Then
                  CType(Container, System.Web.UI.WebControls.WebControl).Enabled = Not Convert.ToBoolean(value.ToString())
               Else
                  If Name.ToLower() = "disabled" And TypeOf Container Is System.Web.UI.HtmlControls.HtmlControl Then
                     CType(Container, System.Web.UI.HtmlControls.HtmlControl).Disabled = Convert.ToBoolean(value.ToString())
                  Else
                     If Name.ToLower() = "multiple" And TypeOf Container Is System.Web.UI.HtmlControls.HtmlSelect Then
                        CType(Container, System.Web.UI.HtmlControls.HtmlSelect).Multiple = Convert.ToBoolean(value.ToString())
                     Else
                        _IsSpecialAttribute = False
                     End If
                  End If
               End If
            End If
         End Set 
      End Property 
   End Class 

End Namespace 

'End CCSControlAttribute class

