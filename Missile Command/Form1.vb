Imports System.ComponentModel
Imports MaterialSkin
Imports MaterialSkin.Controls

Public Class Form1
	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
		SkinManager.AddFormToManage(Me)
		SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
		SkinManager.ColorScheme = New ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE)
		Dim srmSettings = New IO.MemoryStream(My.Resources.baseline_settings_20px)
		image = New Imaging.Metafile(srmSettings)
		srmSettings.Close()
		arrAppBarButtons.Add(PictureBox1)
	End Sub
	Private Sub PictureBox1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
		e.Graphics.DrawImage(image, New Rectangle(Point.Empty, PictureBox1.ClientSize))
	End Sub

	Private Sub PictureBox1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Resize
		PictureBox1.Invalidate()
	End Sub
	Private image As Imaging.Metafile
End Class
