Imports MaterialSkin.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TitleShowingOnHoverMaterialForm
	Inherits ComponentExposingMaterialForm

	'UserControl overrides dispose to clean up the component list.
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
		Me.tmrDisplaceTitle = New System.Windows.Forms.Timer(Me.components)
		Me.SuspendLayout()
		'
		'tmrDisplaceTitle
		'
		Me.tmrDisplaceTitle.Enabled = True
		Me.tmrDisplaceTitle.Interval = 16
		'
		'TitleShowingOnHoverMaterialForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(300, 300)
		Me.Name = "TitleShowingOnHoverMaterialForm"
		Me.ResumeLayout(False)

	End Sub

	Private WithEvents tmrDisplaceTitle As Timer
End Class
