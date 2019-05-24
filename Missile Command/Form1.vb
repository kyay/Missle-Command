Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Xml
Imports MaterialSkin
Imports MaterialSkin.Controls
Imports Svg

Public Class Form1
	Public Sub New()
		MyBase.New()
		InitializeComponent()

		Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
		SkinManager.AddFormToManage(Me)
		SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
		SkinManager.ColorScheme = New ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE)
		'mnuAppBarMenuItems.Add(MaterialMenuItem1)
	End Sub

	Public Overrides ReadOnly Property cntComponents As IContainer
		Get
			Dim cntContainer = MyBase.cntComponents
			For Each cmpComponent In components.Components
				cntContainer.Add(cmpComponent)
			Next
			cntContainer.Add(MaterialMenuItem1)
			Return cntContainer
		End Get
	End Property
End Class
