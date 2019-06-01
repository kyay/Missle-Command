Public Interface IDrawsOnParent
	Property blnShouldLetParentDraw As Boolean
	Sub ActualOnPaint(p As PaintEventArgs)
End Interface
