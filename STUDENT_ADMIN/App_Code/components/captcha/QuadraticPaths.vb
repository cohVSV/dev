'QuadraticPath Class @0-6C37122B
'Target Framework version is 3.5
Imports System
Imports System.Collections

Namespace DECV_PROD2007.Controls

    Public Class QuadraticPaths 
       Inherits CollectionBase

        Private m_maxX As Integer
        Private m_maxY As Integer
        Private m_minX As Integer
        Private m_minY As Integer

        Private m_needNewMetrics As Boolean

        Public Class QuadraticPath
            Private m_x1 As Integer
            Private m_y1 As Integer
            Private m_x2 As Integer
            Private m_y2 As Integer
            Private m_x3 As Integer
            Private m_y3 As Integer

            Public Property X1() As Integer
                Get 
                    Return m_x1 
                End Get
                Set 
                    m_x1 = value 
                End Set
            End Property

            Public Property Y1() As Integer
                Get 
                    Return m_y1 
                End Get
                Set 
                    m_y1 = value 
                End Set
            End Property

            Public Property X2() As Integer
                Get 
                    Return m_x2 
                End Get
                Set 
                    m_x2 = value 
                End Set
            End Property

            Public Property Y2() As Integer
                Get 
                    Return m_y2 
                End Get
                Set 
                    m_y2 = value 
                End Set
            End Property

            Public Property X3() As Integer
                Get 
                    Return m_x3 
                End Get
                Set 
                    m_x3 = value 
                End Set
            End Property

            Public Property Y3() As Integer
                Get 
                    Return m_y3 
                End Get
                Set 
                    m_y3 = value 
                End Set
            End Property

            Public Sub New(x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer, x3 As Integer, y3 As Integer)
                m_x1 = x1
                m_y1 = y1
                m_x2 = x2
                m_y2 = y2
                m_x3 = x3
                m_y3 = y3
            End Sub

            Public Overrides Function ToString() As String
                Return String.Format("{0},{1},{2},{3},{4},{5}", m_x1, m_y1, m_x2, m_y2, m_x3, m_y3)
            End Function            
        End Class
        
        Public Property MaxX() As Integer
            Get 
                Return m_maxX 
            End Get
            Set 
                m_maxX = value 
            End Set
        End Property

        Public Property MaxY() As Integer
            Get 
                Return m_maxY 
            End Get
            Set 
                m_maxY = value 
            End Set
        End Property

        Public Property MinX() As Integer
            Get 
                Return m_minX 
            End Get
            Set 
                m_minX = value 
            End Set
        End Property

        Public Property MinY() As Integer
            Get 
                Return m_minY 
            End Get
            Set 
                m_minY = value 
            End Set
        End Property

        Public Sub New()
            m_needNewMetrics = true
        End Sub

        Public Sub Add(path As QuadraticPath)
            Me.InnerList.Add(path)

            If m_needNewMetrics Then
                m_maxX = Math.Max(path.X1, path.X3)
                m_maxY = Math.Max(path.Y1, path.Y3)
                m_minX = Math.Min(path.X1, path.X3)
                m_minY = Math.Min(path.Y1, path.Y3)
                m_needNewMetrics = False
            Else
                m_maxX = Math.Max(path.X1, Math.Max(path.X3, m_maxX))
                m_maxY = Math.Max(path.Y1, Math.Max(path.Y3, m_maxY))
                m_minX = Math.Min(path.X1, Math.Min(path.X3, m_minX))
                m_minY = Math.Min(path.Y1, Math.Min(path.Y3, m_minY))
            End If
        End Sub

        Public Sub Add(paths As QuadraticPaths)
            For Each path As QuadraticPath In paths
                Me.Add(path)
            Next path
        End Sub

        Public Default ReadOnly Property Qpath(index As Integer) As QuadraticPath
            Get
                Return CType(Me.InnerList(index), QuadraticPath)
            End Get
        End Property

        Public Sub LoadFromString(str As String)
            Dim c As string() = str.Split(","c)
            Dim i As Integer
            For i = 1 To c.Length - 5 Step 6
                Me.Add(New QuadraticPath(Int32.Parse(c(i)), Int32.Parse(c(i + 1)), Int32.Parse(c(i + 2)), Int32.Parse(c(i + 3)), Int32.Parse(c(i + 4)), Int32.Parse(c(i + 5))))
            Next i
        End Sub

        Public Overrides Function ToString() As String
            Dim i As Integer
            Dim res As String = String.Empty
            For i = 0 To Me.InnerList.Count - 1
                res = res & Me(i).ToString() & ","
            Next i
            Return res.Substring(0, res.Length - 1)
        End Function

        Public Sub Normalize(mx As Integer, my As Integer)
            Dim mix As Integer = m_minX
            Dim miy As Integer = m_minY
            Dim kx As Single = CType(mx / (m_maxX - m_minX), Single)
            Dim ky As Single = CType(my / (m_maxY - m_minY), Single)
            If mx = 0 Then kx = ky
            If my = 0 Then ky = kx
            m_needNewMetrics = True
            Dim i As Integer
            For i = 0 To Me.Count - 1
                Me(i).X1 = ((Me(i).X1 - mix) * kx)
                Me(i).Y1 = ((Me(i).Y1 - miy) * ky)
                Me(i).X2 = ((Me(i).X2 - mix) * kx)
                Me(i).Y2 = ((Me(i).Y2 - miy) * ky)
                Me(i).X3 = ((Me(i).X3 - mix) * kx)
                Me(i).Y3 = ((Me(i).Y3 - miy) * ky)

                If m_needNewMetrics
                    MaxX = Math.Max(Me(i).X1, Me(i).X3)
                    MaxY = Math.Max(Me(i).Y1, Me(i).Y3)
                    MinX = Math.Min(Me(i).X1, Me(i).X3)
                    MinY = Math.Min(Me(i).Y1, Me(i).Y3)
                    m_needNewMetrics = False
                Else
                    MaxX = Math.Max(Me(i).X1, Math.Max(Me(i).X3, MaxX))
                    MaxY = Math.Max(Me(i).Y1, Math.Max(Me(i).Y3, MaxY))
                    MinX = Math.Min(Me(i).X1, Math.Min(Me(i).X3, MinX))
                    MinY = Math.Min(Me(i).Y1, Math.Min(Me(i).Y3, MinY))
                End If
            Next i
        End Sub

        Public Sub Multiply(mx As Integer, my As Integer)
            Dim t, i As Integer
            For i = 0 To Me.Count - 1
                Me(i).X1 = Me(i).X1 * mx
                Me(i).Y1 = Me(i).Y1 * my
                Me(i).X2 = Me(i).X2 * mx
                Me(i).Y2 = Me(i).Y2 * my
                Me(i).X3 = Me(i).X3 * mx
                Me(i).Y3 = Me(i).Y3 * my
            Next i
            m_maxX = m_maxX * mx
            m_maxY = m_maxY * my
            m_minX = m_minX * mx
            m_minY = m_minY * my
            If m_maxX < m_minX Then
                t = m_maxX
                m_maxX = m_minX
                m_minX = t
            End If
            If m_maxY < m_minY Then
                t = m_maxY
                m_maxY = m_minY
                m_minY = t
            End If
        End Sub

        Public Sub Rotate(gr As Integer)
            m_needNewMetrics = True
            Dim ang As Double = gr * Math.PI / 180
            Dim i, tx, ty As Integer
            For i = 0 To Me.Count - 1
                tx = (Me(i).X1 * Math.Cos(ang) - Me(i).Y1 * Math.Sin(ang))
                ty = (Me(i).X1 * Math.Sin(ang) + Me(i).Y1 * Math.Cos(ang))
                Me(i).X1 = tx
                Me(i).Y1 = ty
                tx = (Me(i).X2 * Math.Cos(ang) - Me(i).Y2 * Math.Sin(ang))
                ty = (Me(i).X2 * Math.Sin(ang) + Me(i).Y2 * Math.Cos(ang))
                Me(i).X2 = tx
                Me(i).Y2 = ty
                tx = (Me(i).X3 * Math.Cos(ang) - Me(i).Y3 * Math.Sin(ang))
                ty = (Me(i).X3 * Math.Sin(ang) + Me(i).Y3 * Math.Cos(ang))
                Me(i).X3 = tx
                Me(i).Y3 = ty

                If m_needNewMetrics Then
                    m_maxX = Math.Max(Me(i).X1, Me(i).X3)
                    m_maxY = Math.Max(Me(i).Y1, Me(i).Y3)
                    m_minX = Math.Min(Me(i).X1, Me(i).X3)
                    m_minY = Math.Min(Me(i).Y1, Me(i).Y3)
                    m_needNewMetrics = False
                Else
                    m_maxX = Math.Max(Me(i).X1, Math.Max(Me(i).X3, m_maxX))
                    m_maxY = Math.Max(Me(i).Y1, Math.Max(Me(i).Y3, m_maxY))
                    m_minX = Math.Min(Me(i).X1, Math.Min(Me(i).X3, m_minX))
                    m_minY = Math.Min(Me(i).Y1, Math.Min(Me(i).Y3, m_minY))
                End If
            Next i
        End Sub

        Public Sub Wave(w As Double)
            Dim i As Integer
            Dim dx As Double = (m_maxX - m_minX) * w
            Dim dy As Double = (m_maxY - m_minY) / 1
            Dim omega As Double = m_minX
            m_needNewMetrics = False
            For i = 0 To Me.InnerList.Count - 1
                Me(i).X1 += (dx * Math.Cos(Math.PI * (Me(i).Y1 - omega) / dy))
                Me(i).X2 += (dx * Math.Cos(Math.PI * (Me(i).Y2 - omega) / dy))
                Me(i).X3 += (dx * Math.Cos(Math.PI * (Me(i).Y3 - omega) / dy))
                If m_needNewMetrics
                    m_maxX = Math.Max(Me(i).X1, Me(i).X3)
                    m_maxY = Math.Max(Me(i).Y1, Me(i).Y3)
                    m_minX = Math.Min(Me(i).X1, Me(i).X3)
                    m_minY = Math.Min(Me(i).Y1, Me(i).Y3)
                    m_needNewMetrics = False
                Else
                    m_maxX = Math.Max(Me(i).X1, Math.Max(Me(i).X3, m_maxX))
                    m_maxY = Math.Max(Me(i).Y1, Math.Max(Me(i).Y3, m_maxY))
                    m_minX = Math.Min(Me(i).X1, Math.Min(Me(i).X3, m_minX))
                    m_minY = Math.Min(Me(i).Y1, Math.Min(Me(i).Y3, m_minY))
                End If
            Next i
        End Sub

        Public Sub Centralize()
            Dim cx, cy, i As Integer
            cx = (m_minX + m_maxX) / 2
            cy = (m_minY + m_maxY) / 2
            For i = 0 To Me.Count - 1
                Me(i).X1 = Me(i).X1 - cx
                Me(i).Y1 = Me(i).Y1 - cy
                Me(i).X2 = Me(i).X2 - cx
                Me(i).Y2 = Me(i).Y2 - cy
                Me(i).X3 = Me(i).X3 - cx
                Me(i).Y3 = Me(i).Y3 - cy
            Next i
            m_maxX -= cx
            m_maxY -= cy
            m_minX -= cx
            m_minY -= cy
        End Sub

        Public Sub Addition(cx As Integer, cy As Integer)
            Dim i As Integer
            For i = 0 To Me.InnerList.Count - 1
                Me(i).X1 += cx
                Me(i).Y1 += cy
                Me(i).X2 += cx
                Me(i).Y2 += cy
                Me(i).X3 += cx
                Me(i).Y3 += cy
            Next i
            m_maxX += cx
            m_maxY += cy
            m_minX += cx
            m_minY += cy
        End Sub    

        Public Sub Broke(dx As Integer, dy As Integer)
            m_needNewMetrics = True
            Dim r As Random = New Random()
            Dim rx, ry, i As Integer
            For i = 0 To Me.InnerList.Count - 1
                rx = r.Next(-dx, dx)
                ry = r.Next(-dy, dy)
                Me(i).X1 += rx
                Me(i).Y1 += ry
                rx = r.Next(-dx, dx)
                ry = r.Next(-dy, dy)
                Me(i).X3 += rx
                Me(i).Y3 += ry
                If m_needNewMetrics Then
                    MaxX = Math.Max(Me(i).X1, Me(i).X3)
                    MaxY = Math.Max(Me(i).Y1, Me(i).Y3)
                    MinX = Math.Min(Me(i).X1, Me(i).X3)
                    MinY = Math.Min(Me(i).Y1, Me(i).Y3)
                    m_needNewMetrics = false
                Else
                    MaxX = Math.Max(Me(i).X1, Math.Max(Me(i).X3, MaxX))
                    MaxY = Math.Max(Me(i).Y1, Math.Max(Me(i).Y3, MaxY))
                    MinX = Math.Min(Me(i).X1, Math.Min(Me(i).X3, MinX))
                    MinY = Math.Min(Me(i).Y1, Math.Min(Me(i).Y3, MinY))
                End If
            Next i
        End Sub

        Public Sub AddNoise(quontity As Integer)
            Dim i As Integer
            Dim r As Random = new Random()
            Dim x1, y1, x2, y2, x3, y3 As Integer
            For i = 0 To quontity - 1
                x1 = r.Next(m_minX, m_maxX)
                y1 = r.Next(m_minY, m_maxY)
                x3 = r.Next(m_minX, m_maxX)
                y3 = r.Next(m_minY, m_maxY)
                x2 = r.Next(Math.Min(x1, x3), Math.Max(x1, x3))
                y2 = r.Next(Math.Min(y1, y3), Math.Max(y1, y3))
                Me.InnerList.Add(New QuadraticPath(x1, y1, x2, y2, x3, y3))
            Next i
        End Sub

        Public Sub Mix()
            Dim r As Random = new Random()
            Dim i, j As Integer
            Dim t As QuadraticPath
            For i = 0 To Me.InnerList.Count - 1
                j = r.Next(Me.InnerList.Count)
                t = Me(i)
                Me.InnerList(i) = Me(j)
                Me.InnerList(j) = t
            Next i
        End Sub
    End Class
End Namespace

'End QuadraticPath Class

