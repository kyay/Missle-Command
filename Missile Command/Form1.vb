Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Xml
Imports MaterialSkin
Imports MaterialSkin.Control

Public Class Form1
    Private Const CROSSHAIR_DIMEN As Integer = 24
    Private Const MISSILE_SPEED_PER_SEC As Integer = 240

    Private MISSILE_SILOS() As MissileSilo
    Private mslLaunchedMissiles As New List(Of Missile)

    Public Sub New()
        MyBase.New()
        Cursor = Nothing
        InitializeComponent()
        MISSILE_SILOS = {MissileSilo1, MissileSilo2, MissileSilo3}
        Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
        SkinManager.AddFormToManage(Me)
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        SkinManager.ColorScheme = New ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE)
    End Sub

    Public Overrides ReadOnly Property cntComponents As IContainer
        Get
            Dim cntContainer = MyBase.cntComponents
            For Each cmpComponent In components.Components
                cntContainer.Add(cmpComponent)
            Next
            cntContainer.Add(mmiSettings)
            Return cntContainer
        End Get
    End Property

    Public Overrides Property Cursor As Cursor
        Get
            Return MyBase.Cursor
        End Get
        Set(value As Cursor)
            'Force the cursor to be the crosshair
            'MyBase.Cursor = value
            MyBase.Cursor = New Cursor(New Bitmap(My.Resources.Crosshair, CROSSHAIR_DIMEN, CROSSHAIR_DIMEN).GetHicon())
        End Set
    End Property

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                Me.Cursor = New Cursor(Cursor.Current.Handle)
                Cursor.Position = New Point(MousePosition.X, MousePosition.Y - 5)
            Case Keys.Down
                Me.Cursor = New Cursor(Cursor.Current.Handle)
                Cursor.Position = New Point(MousePosition.X, MousePosition.Y + 5)
            Case Keys.Left
                Me.Cursor = New Cursor(Cursor.Current.Handle)
                Cursor.Position = New Point(MousePosition.X - 5, MousePosition.Y)
            Case Keys.Right
                Me.Cursor = New Cursor(Cursor.Current.Handle)
                Cursor.Position = New Point(MousePosition.X + 5, MousePosition.Y)
        End Select
    End Sub
    Protected Overrides Function IsInputKey(keyData As Keys) As Boolean
        Return MyBase.IsInputKey(keyData) Or keyData = Keys.Up Or keyData = Keys.Down Or keyData = Keys.Right Or keyData = Keys.Left
    End Function

    Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        Dim pntMousePositionRelative As Point = PointToClient(MousePosition)
        Dim dblDistanceForSilos(2) As Double
        Dim pntSilosCenter(2) As Point
        For i = 0 To MISSILE_SILOS.Length - 1
            Dim mssMissileSilo As MissileSilo = MISSILE_SILOS(i)
            pntSilosCenter(i) = New Point(mssMissileSilo.Left + mssMissileSilo.Width / 2, mssMissileSilo.Top + mssMissileSilo.Height / 2)
            dblDistanceForSilos(i) = Math.Sqrt(Math.Pow(pntSilosCenter(i).X - pntMousePositionRelative.X, 2) + Math.Pow(pntSilosCenter(i).Y - pntMousePositionRelative.Y, 2))
        Next
        'Dim pntSilo1Center As Point = New Point(MissileSilo1.Left - MissileSilo1.Width / 2, MissileSilo1.Top + MissileSilo1.Height / 2)
        'Dim pntSilo2Center As Point = New Point(MissileSilo2.Left - MissileSilo2.Width / 2, MissileSilo2.Top + MissileSilo2.Height / 2)
        'Dim pntSilo3Center As Point = New Point(MissileSilo3.Left - MissileSilo3.Width / 2, MissileSilo3.Top + MissileSilo3.Height / 2)
        'Dim dblDistanceForSilo1 As Double = Math.Sqrt(Math.Pow(pntSilo1Center.X - pntMousePositionRelative.X, 2) + Math.Pow(pntSilo1Center.Y - pntMousePositionRelative.Y, 2))
        'Dim dblDistanceForSilo2 As Double = Math.Sqrt(Math.Pow(pntSilo2Center.X - pntMousePositionRelative.X, 2) + Math.Pow(pntSilo2Center.Y - pntMousePositionRelative.Y, 2))
        'Dim dblDistanceForSilo3 As Double = Math.Sqrt(Math.Pow(pntSilo3Center.X - pntMousePositionRelative.X, 2) + Math.Pow(pntSilo3Center.Y - pntMousePositionRelative.Y, 2))
        Dim intSiloIndex = Array.IndexOf(dblDistanceForSilos, dblDistanceForSilos.Min)
        LaunchMissile(pntSilosCenter(intSiloIndex), pntMousePositionRelative)
        MISSILE_SILOS(intSiloIndex).intMissileCount -= 1
    End Sub

    Private Sub LaunchMissile(pntSiloCenter As Point, pntMousePositionRelative As Point)
        Dim mslMissile As New Missile
        mslMissile.intRotation = 0
        Dim vctSpeed = New Windows.Vector(pntMousePositionRelative.X - pntSiloCenter.X, pntMousePositionRelative.Y - pntSiloCenter.Y)
        mslMissile.intRotation = Math.Atan2(vctSpeed.Y, vctSpeed.X) * 180.0 / Math.PI + 90
        vctSpeed.Normalize()
        '                              speed per sec for missile / FPS of timer
        mslMissile.vctSpeed = vctSpeed * (MISSILE_SPEED_PER_SEC / (1000 / tmrMissileMover.Interval))
        mslMissile.Location = New Point(pntSiloCenter.X - mslMissile.Width / 2, pntSiloCenter.Y - mslMissile.Height / 2)
        Controls.Add(mslMissile)
        mslLaunchedMissiles.Add(mslMissile)
        'Dim dPoint = pntMousePositionRelative - pntSiloCenter
        'Dim l = Math.Sqrt(dPoint.X * dPoint.X + dPoint.Y * dPoint.Y)
        'Dim dx As Double = dPoint.X / l
        'Dim dy As Double = dPoint.Y / l
        'mslMissile.pnt New Point(4 * dx, 4 * dy)

    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        For Each cntControl As Control In Controls
            If TypeOf cntControl Is IDrawsOnParent AndAlso cntControl.Visible AndAlso CType(cntControl, IDrawsOnParent).blnShouldLetParentDraw Then
                Dim g As Graphics = e.Graphics
                g.TranslateTransform(cntControl.Left, cntControl.Top)
                CType(cntControl, IDrawsOnParent).ActualOnPaint(New PaintEventArgs(g, cntControl.DisplayRectangle))
                g.TranslateTransform(-cntControl.Left, -cntControl.Top)
            End If
        Next
        'MyBase.OnPaint(e)
        'Static b As Bitmap = New Bitmap(1000, 1000)
        'Dim g As Graphics = Graphics.FromImage(b)
        'For Each cntControl As Control In Controls
        '    If TypeOf cntControl Is IDrawsOnParent AndAlso cntControl.Visible Then
        '        g.TranslateTransform(cntControl.Left, cntControl.Top)
        '        CType(cntControl, IDrawsOnParent).ActualOnPaint(New PaintEventArgs(g, cntControl.DisplayRectangle))
        '        g.TranslateTransform(-cntControl.Left, -cntControl.Top)
        '    End If
        'Next
    End Sub

    Private Sub tmrMissileMover_Tick(sender As Object, e As EventArgs) Handles tmrMissileMover.Tick
        For Each mslMissile In mslLaunchedMissiles
            mslMissile.Left += mslMissile.vctSpeed.X
            mslMissile.Top += mslMissile.vctSpeed.Y
            If mslMissile.Top <= mslMissile.pntDestination.Y Then
                'mslMissile.Location = mslMissile.pntDestination
                'TODO: Explode!!
            End If
        Next
    End Sub
End Class
