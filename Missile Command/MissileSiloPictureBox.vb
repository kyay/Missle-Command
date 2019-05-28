Public Class MissileSiloPictureBox
	Public Property intMissileCount As Integer = 10
	Public Property blnIsOut As Boolean = False

	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		MyBase.OnPaint(e)
	End Sub
End Class
