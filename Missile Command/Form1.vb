Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Xml
Imports MaterialSkin
Imports MaterialSkin.Controls
Imports Svg

Public Class Form1
	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
		SkinManager.AddFormToManage(Me)
		SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
		SkinManager.ColorScheme = New ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE)
		SkinManager.FORM_PADDING = 8
		mnuAppBarMenuItems.Add(MaterialMenuItem1)
	End Sub
End Class
