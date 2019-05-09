Imports System.Collections.ObjectModel
Imports System.Drawing.Drawing2D
Imports MaterialSkin.Controls

Public Class TitleShowingOnHoverMaterialForm
	Private blnAdd As Boolean = False
	Private intTitleOffset = -40
	Private rectTitle As Rectangle = New Rectangle(0, 24, 0, 40)
	Private dblTitleTransitionRate60FPS As Double
	Public ReadOnly arrAppBarButtons As ObservableCollection(Of PictureBox) = New ObservableCollection(Of PictureBox)

	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		Dim g = e.Graphics
		g.ExcludeClip(rectTitle)
		MyBase.OnPaint(e)
		g.SetClip(rectTitle)
		g.TranslateTransform(0, intTitleOffset)
		MyBase.OnPaint(e)
	End Sub

	Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
		MyBase.OnMouseMove(e)
		If e.Y > 24 AndAlso e.Y <= 24 + 40 Then
			blnAdd = True
		Else
			blnAdd = False
		End If
	End Sub
	Protected Overrides Sub OnSizeChanged(e As EventArgs)
		MyBase.OnSizeChanged(e)
		rectTitle.Width = Me.Width
	End Sub
	Private Sub tmrDisplaceTitle_Tick(sender As Object, e As EventArgs) Handles tmrDisplaceTitle.Tick
		Dim intOffsetChange = 0
		If blnAdd AndAlso intTitleOffset < 0 Then
			intOffsetChange = Math.Min(0 - intTitleOffset, dblTitleTransitionRate60FPS)
			intTitleOffset += intOffsetChange
			Invalidate(rectTitle)
		ElseIf Not blnAdd AndAlso intTitleOffset > -40 Then
			intOffsetChange = -Math.Min(intTitleOffset + 40, dblTitleTransitionRate60FPS)
			intTitleOffset += intOffsetChange
			Invalidate(rectTitle)
		End If
		If intOffsetChange <> 0 Then
			For Each picButton In arrAppBarButtons
				picButton.Top += intOffsetChange
			Next
		End If
	End Sub

	Protected Overrides Sub OnLoad(e As EventArgs)
		MyBase.OnLoad(e)
		tmrDisplaceTitle.Start()
		dblTitleTransitionRate60FPS = 40 / (100 / tmrDisplaceTitle.Interval)
	End Sub
End Class
