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
		Me.MaterialMenuItem1 = New Missile_Command.MaterialMenuItem(Me.components)
		Me.SuspendLayout()
		'
		'MaterialMenuItem1
		'
		Me.MaterialMenuItem1.intHeight = 40
		Me.MaterialMenuItem1.intLeft = 0
		Me.MaterialMenuItem1.intTop = 0
		Me.MaterialMenuItem1.intWidth = 40
		Me.MaterialMenuItem1.mstMouseState = Missile_Command.MaterialMenuItem.MouseState.Up
		Me.MaterialMenuItem1.pdgPadding = New System.Windows.Forms.Padding(8)
		Me.MaterialMenuItem1.rctBounds = New System.Drawing.Rectangle(0, 0, 40, 40)
		Me.MaterialMenuItem1.svgImage = Nothing
		Me.MaterialMenuItem1.svgImageFileName = "baseline_settings_20px"
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.Black
		Me.ClientSize = New System.Drawing.Size(800, 450)
		Me.Name = "Form1"
		Me.Text = "Test"
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents MaterialMenuItem1 As MaterialMenuItem
End Class
