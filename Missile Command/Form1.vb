Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Xml
Imports MaterialSkin
Imports MaterialSkin.Controls
Imports Svg

Public Class Form1
	Private Const CROSSHAIR_DIMEN As Integer = 24

	Public Sub New()
		MyBase.New()
		Cursor = Nothing
		InitializeComponent()
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
        Me.Cursor = New Cursor(Cursor.Current.Handle)
        Select Case e.KeyCode
            Case Keys.Up
                Cursor.Position = New Point(MousePosition.X, MousePosition.Y - 5)
            Case Keys.Down
                Cursor.Position = New Point(MousePosition.X, MousePosition.Y + 5)
            Case Keys.Left
                Cursor.Position = New Point(MousePosition.X - 5, MousePosition.Y)
            Case Keys.Right
                Cursor.Position = New Point(MousePosition.X + 5, MousePosition.Y)
        End Select
        Refresh()
    End Sub
    Protected Overrides Function IsInputKey(keyData As Keys) As Boolean
        Return MyBase.IsInputKey(keyData) Or keyData = Keys.Up Or keyData = Keys.Down Or keyData = Keys.Right Or keyData = Keys.Left
    End Function
End Class
