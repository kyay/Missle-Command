Imports MaterialSkin.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
	Inherits TitleShowingOnHoverMaterialForm

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Me.PictureBox1 = New Missile_Command.MaterialPictureButton()
		Me.MaterialMenuItem1 = New Missile_Command.MaterialMenuItem(Me.components)
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'PictureBox1
		'
		Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
		Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.PictureBox1.Location = New System.Drawing.Point(764, 24)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
		Me.PictureBox1.Size = New System.Drawing.Size(24, 30)
		Me.PictureBox1.TabIndex = 0
		Me.PictureBox1.TabStop = False
		Me.PictureBox1.TranslationX = 0
		Me.PictureBox1.TranslationY = 0
		'
		'MaterialMenuItem1
		'
		Me.MaterialMenuItem1.intHeight = 0
		Me.MaterialMenuItem1.intLeft = 0
		Me.MaterialMenuItem1.intTop = 0
		Me.MaterialMenuItem1.intWidth = 0
		Me.MaterialMenuItem1.mstMouseState = Missile_Command.MaterialMenuItem.MouseState.Down
		Me.MaterialMenuItem1.pdgPadding = New System.Windows.Forms.Padding(0, 0, 0, 0)
		Me.MaterialMenuItem1.rctBounds = New System.Drawing.Rectangle(0, 0, 0, 0)
		Me.MaterialMenuItem1.svgImage = Nothing
		Me.MaterialMenuItem1.svgImageFile = Nothing
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.Black
		Me.ClientSize = New System.Drawing.Size(800, 450)
		Me.Controls.Add(Me.PictureBox1)
		Me.Name = "Form1"
		Me.Text = "Test"
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents PictureBox1 As MaterialPictureButton
	Friend WithEvents MaterialMenuItem1 As MaterialMenuItem
End Class
