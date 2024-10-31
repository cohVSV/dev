'FlashChart class @0-AAFF92FA
'Target Framework version is 3.5
Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Collections
Imports DECV_PROD2007.Data
Imports DECV_PROD2007.Configuration

Namespace DECV_PROD2007.Controls

    Public Class Captcha 
        Inherits Control
        Private m_width As Integer
        Private m_height As Integer
        Private m_servicePath As String
        Private m_length As Integer
        Private m_rotation As Integer
        Private m_broke As Integer
        Private m_vAmplitude As Double
        Private m_hAmplitude As Double
        Private m_noise As Integer
        Private m_bColor As String
        Private m_fColor As String
        Private m_restrictedSequences As String = "|cp|cb|ck|c6|c9|rn|rm|mm|co|do|cl|db|qp|qb|dp|"

        Public Property Width() As Integer
            Get
                Return m_width
            End Get
            Set
                m_width = value
            End Set
        End Property

        Public Property Height() As Integer
            Get
                Return m_height
            End Get
            Set
                m_height = value
            End Set
        End Property

        Public Property ServicePath() As String
            Get
                Return m_servicePath
            End Get
            Set
                m_servicePath = value
            End Set
        End Property

        Public Property Length() As Integer
            Get 
                Return m_length
            End Get
            Set 
                m_length = value
            End Set
        End Property

        Public Property Rotation() As Integer
            Get 
                Return m_rotation 
            End Get
            Set 
                m_rotation = value
            End Set
        End Property

        Public Property Broke() As Integer
            Get 
                Return m_broke
            End Get
            Set 
                m_broke = value
            End Set
        End Property

        Public Property VAmplitude() As Double
            Get 
                Return m_vAmplitude 
            End Get
            Set 
                m_vAmplitude = value
            End Set
        End Property

        Public Property HAmplitude() As Double
            Get 
                Return m_hAmplitude
            End Get
            Set 
                m_hAmplitude = value
            End Set
        End Property

        Public Property Noise() As Integer
            Get 
                Return m_noise
            End Get
            Set 
                m_noise = value
            End Set
        End Property

        Public Property BColor() As String
            Get 
                Return m_bColor
            End Get
            Set 
                m_bColor = value
            End Set
        End Property

        Public Property FColor() As String
            Get 
                Return m_fColor
            End Get
            Set 
                m_fColor = value
            End Set
        End Property

        Public Property RestrictedSequences() As String
            Get 
                Return m_restrictedSequences
            End Get
            Set 
                m_restrictedSequences = value
            End Set
        End Property

        Protected Overrides Sub OnDataBinding(ByVal e As EventArgs)
            MyBase.OnDataBinding(e)
            If Page.Request("callbackControl") = ID Then
                GenerateCaptchaCode()
            End If
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
            Page.Response.AddHeader("X-UA-Compatible", "IE=7")
            writer.AddAttribute(HtmlTextWriterAttribute.Width, m_width.ToString())
            writer.AddAttribute(HtmlTextWriterAttribute.Height, m_height.ToString())
            writer.AddAttribute(HtmlTextWriterAttribute.Id, ID & "Picture")
            writer.RenderBeginTag("canvas")
            writer.RenderEndTag()
            writer.AddAttribute(HtmlTextWriterAttribute.Id, ClientID)
            writer.AddAttribute(HtmlTextWriterAttribute.Name, UniqueID)
            writer.RenderBeginTag(HtmlTextWriterTag.Input)
            writer.RenderEndTag()
        End Sub

        Protected Function ValidateCaptchaString(ByVal text As String) As Boolean
            Dim seqs As String() = m_restrictedSequences.Split(New Char() { "|"c }, StringSplitOptions.RemoveEmptyEntries)
            For Each seq As String In seqs
                If text.IndexOf(seq) <> -1 Then Return False
            Next seq
            Return True
        End Function

        Protected Sub GenerateCaptchaCode()
            Dim letters As String() = File.ReadAllLines(Path.Combine(Path.Combine(Page.Request.PhysicalApplicationPath, AppRelativeTemplateSourceDirectory.Substring(2).Replace("/", "\\")), m_servicePath))          
            Dim res As QuadraticPaths = New QuadraticPaths()
            Dim t As QuadraticPaths
            Dim code As String = String.Empty
            Dim i, r As Integer
            Dim rand As Random = New Random()

            For i = 0 To m_length - 1
                r = rand.Next(0, letters.Length)
                While Not(ValidateCaptchaString(code & letters(r)(0)))
                    r = rand.Next(0, letters.Length)
                End While
                code += letters(r)(0)
                t = New QuadraticPaths()
                t.LoadFromString(letters(r))
                t.Wave(2 * m_vAmplitude * rand.NextDouble() - m_vAmplitude)
                t.Rotate(rand.Next(-m_rotation, m_rotation))
                t.Normalize(0, 100)
                If t.MaxX - t.MinX > 100 Then
                    t.Normalize(100, 100)
                End If
                t.Addition((i) * t.MaxY, 0)
                res.Add(t)
            Next i
            
            res.Rotate(90)
            res.Wave(2 * m_hAmplitude * rand.NextDouble() - m_hAmplitude)
            res.Rotate(-90)
            res.Broke(m_broke, m_broke)
            res.Normalize(m_width - 12, m_height - 12)
            res.Addition(6, 6)
            res.AddNoise(m_noise)
            res.Mix()
            HttpContext.Current.Session("Captcha" + ID) = code
            Page.Response.Clear()
            Page.Response.Write(res.ToString())
            Page.Response.[End]()
        End Sub
    End Class
End Namespace

'End FlashChart class

