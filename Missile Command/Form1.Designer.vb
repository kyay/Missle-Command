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
        Me.MissileSilo2 = New Missile_Command.MissileSilo()
        Me.MissileSilo3 = New Missile_Command.MissileSilo()
        Me.tmrMissileMover = New System.Windows.Forms.Timer(Me.components)
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
        Me.MissileSilo1.intMissileCount = 10
        Me.MissileSilo1.Location = New System.Drawing.Point(12, 374)
        Me.MissileSilo1.Name = "MissileSilo1"
        Me.MissileSilo1.Size = New System.Drawing.Size(89, 64)
        Me.MissileSilo1.TabIndex = 0
        Me.MissileSilo1.TabStop = False
        '
        'MissileSilo2
        '
        Me.MissileSilo2.BackColor = System.Drawing.Color.Transparent
        Me.MissileSilo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MissileSilo2.intMissileCount = 10
        Me.MissileSilo2.Location = New System.Drawing.Point(375, 374)
        Me.MissileSilo2.Name = "MissileSilo2"
        Me.MissileSilo2.Size = New System.Drawing.Size(89, 64)
        Me.MissileSilo2.TabIndex = 1
        Me.MissileSilo2.TabStop = False
        '
        'MissileSilo3
        '
        Me.MissileSilo3.BackColor = System.Drawing.Color.Transparent
        Me.MissileSilo3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MissileSilo3.Cursor = System.Windows.Forms.Cursors.Cross
        Me.MissileSilo3.intMissileCount = 10
        Me.MissileSilo3.Location = New System.Drawing.Point(699, 374)
        Me.MissileSilo3.Name = "MissileSilo3"
        Me.MissileSilo3.Size = New System.Drawing.Size(89, 64)
        Me.MissileSilo3.TabIndex = 2
        Me.MissileSilo3.TabStop = False
        '
        'tmrMissileMover
        '
        Me.tmrMissileMover.Enabled = True
        Me.tmrMissileMover.Interval = 32
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MissileSilo3)
        Me.Controls.Add(Me.MissileSilo2)
        Me.Controls.Add(Me.MissileSilo1)
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.Text = "Missile Command"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mmiSettings As MaterialMenuItem
    Friend WithEvents MissileSilo1 As MissileSilo
    Friend WithEvents MissileSilo2 As MissileSilo
    Friend WithEvents MissileSilo3 As MissileSilo
    Friend WithEvents tmrMissileMover As Timer
    Friend WithEvents Missile1 As Missile
    Friend WithEvents PictureBox1 As PictureBox
End Class
