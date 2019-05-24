Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.Drawing.Drawing2D
Imports System.Reflection
Imports MaterialSkin.Controls

Public Class TitleShowingOnHoverMaterialForm
	Private blnAdd As Boolean = False
	Private intTitleOffset = -40
	Private rectTitle As Rectangle = New Rectangle(0, 24, 0, 40)
	Private dblTitleTransitionRate60FPS As Double
	Public WithEvents mnuAppBarMenuItems As ObservableCollection(Of MaterialMenuItem) = New ObservableCollection(Of MaterialMenuItem)

	Public Sub New()
		MyBase.New()
		InitializeComponent()
	End Sub

	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		'Dim g = e.Graphics
		'Dim test As Bitmap = New Bitmap(Width, Height)
		'Dim g2 = Graphics.FromImage(test)
		'Dim e2 = New PaintEventArgs(g2, e.ClipRectangle)
		'g2.ExcludeClip(rectTitle)
		'MyBase.OnPaint(e2)
		'g2.SetClip(rectTitle)
		'g2.TranslateTransform(0, intTitleOffset)
		'MyBase.OnPaint(e2)

		Dim g = e.Graphics
		g.ExcludeClip(rectTitle)
		MyBase.OnPaint(e)
		g.SetClip(rectTitle)
		g.TranslateTransform(0, intTitleOffset)
		MyBase.OnPaint(e)
		For Each mnuItem In mnuAppBarMenuItems
			mnuItem.Draw(g)
		Next

		'g.ExcludeClip(rectTitle)
		'MyBase.OnPaint(e)
		'g.SetClip(rectTitle)
		'g.TranslateTransform(0, intTitleOffset)
		'MyBase.OnPaint(e)
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
		ElseIf Not blnAdd AndAlso intTitleOffset > -40 Then
			intOffsetChange = -Math.Min(intTitleOffset + 40, dblTitleTransitionRate60FPS)
		End If

		If intOffsetChange <> 0 Then
			intTitleOffset += intOffsetChange
			Refresh()
		End If
	End Sub

	Protected Overrides Sub OnLoad(e As EventArgs)
		MyBase.OnLoad(e)
		dblTitleTransitionRate60FPS = 40 / (100 / tmrDisplaceTitle.Interval)
		tmrDisplaceTitle.Start()
	End Sub

	Protected Overrides Sub OnResize(e As EventArgs)
		MyBase.OnResize(e)
		RelayoutAppBarMenuItems()
	End Sub

	Private Sub mnuAppBarMenuItems_CollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs) Handles mnuAppBarMenuItems.CollectionChanged
		RelayoutAppBarMenuItems()
	End Sub

	Private Sub RelayoutAppBarMenuItems()
		Dim intLastUsedLeft = Width - SkinManager.FORM_PADDING
		For Each mnuItem As MaterialMenuItem In mnuAppBarMenuItems
			mnuItem.intLeft = intLastUsedLeft - mnuItem.intWidth
			intLastUsedLeft = mnuItem.intLeft
			mnuItem.intTop = 24 + ((40 - mnuItem.intHeight) / 2)
		Next
		Invalidate()
	End Sub

	Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
		MyBase.OnMouseDown(e)
	End Sub

	Protected Overrides Sub OnMouseLeave(e As EventArgs)
		MyBase.OnMouseLeave(e)
	End Sub

	Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
		MyBase.OnMouseUp(e)
	End Sub
End Class
