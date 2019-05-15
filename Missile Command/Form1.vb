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
		Dim srmSettings As Stream = New IO.MemoryStream(My.Resources.baseline_settings_20px)
		Dim xmlDoc = New XmlDocument()
		xmlDoc.Load(srmSettings)
		image = SvgDocument.Open(xmlDoc)
		srmSettings.Close()
		arrAppBarButtons.Add(PictureBox1)
	End Sub
	Private Sub PictureBox1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
		Dim ClientRect As Rectangle = PictureBox1.ClientRectangle
		ClientRect.X += PictureBox1.Padding.Left
		ClientRect.Y += PictureBox1.Padding.Top
		ClientRect.Width -= PictureBox1.Padding.Horizontal
		ClientRect.Height -= PictureBox1.Padding.Vertical
		Dim renderer = SvgRenderer.FromGraphics(e.Graphics)
		renderer.DrawImage(image, ClientRect)
	End Sub

	Private Sub PictureBox1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Resize
		PictureBox1.Invalidate()
	End Sub
	Private image As SvgDocument
End Class
