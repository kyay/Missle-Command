Imports Missile_Command

Public Class DrawingOnParentPictureBox
	Implements IDrawsOnParent

	Private _blnShouldLetParentDraw As Boolean = True
	Public Property blnShouldLetParentDraw As Boolean Implements IDrawsOnParent.blnShouldLetParentDraw
		Get
			Return _blnShouldLetParentDraw
		End Get
		Set(value As Boolean)
			_blnShouldLetParentDraw = value
		End Set
	End Property

	Public Sub ActualOnPaint(pe As PaintEventArgs) Implements IDrawsOnParent.ActualOnPaint
		MyBase.OnPaint(pe)
	End Sub

	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		If Not blnShouldLetParentDraw OrElse DesignMode Then
			ActualOnPaint(e)
		End If
	End Sub
End Class
