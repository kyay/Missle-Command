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
		Me.mmiSettings = New Missile_Command.MaterialMenuItem(Me.components)
		Me.MissileSilo1 = New Missile_Command.MissileSilo()
		Me.SuspendLayout()
		'
		'mmiSettings
		'
		Me.mmiSettings.intHeight = 40
		Me.mmiSettings.intLeft = 760
		Me.mmiSettings.intTop = 24
		Me.mmiSettings.intWidth = 40
		Me.mmiSettings.mstMouseState = Missile_Command.MaterialMenuItem.MouseState.Up
		Me.mmiSettings.pdgPadding = New System.Windows.Forms.Padding(8)
		Me.mmiSettings.rctBounds = New System.Drawing.Rectangle(760, 24, 40, 40)
		Me.mmiSettings.svgImageFileName = "baseline_settings_20px"
		'
		'MissileSilo1
		'
		Me.MissileSilo1.BackColor = System.Drawing.Color.Transparent
		Me.MissileSilo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.MissileSilo1.intMissileCount = 5
		Me.MissileSilo1.Location = New System.Drawing.Point(12, 374)
		Me.MissileSilo1.Name = "MissileSilo1"
		Me.MissileSilo1.Size = New System.Drawing.Size(89, 64)
		Me.MissileSilo1.TabIndex = 0
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.Black
		Me.ClientSize = New System.Drawing.Size(800, 450)
		Me.Controls.Add(Me.MissileSilo1)
		Me.Name = "Form1"
		Me.Text = "Missile Command"
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents mmiSettings As MaterialMenuItem
    Friend WithEvents MissileSilo1 As MissileSilo
End Class
