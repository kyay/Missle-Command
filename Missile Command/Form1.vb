Imports System.ComponentModel
Imports MaterialSkin
Imports MaterialSkin.Controls

Public Class Form1
	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
		SkinManager.AddFormToManage(Me)
		SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
		SkinManager.ColorScheme = New ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE)
		'image = New Imaging.Metafile(New System.IO.MemoryStream(My.Resources.baseline_settings_20px))
	End Sub

	Private image As Imaging.Metafile
End Class
