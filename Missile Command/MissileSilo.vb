Public Class MissileSilo
	Private picMissiles() As PictureBox
	Private _intMissileCount As Integer = 5
	Public Property intMissileCount() As Integer
		Get
			Return _intMissileCount
		End Get
		Set(ByVal value As Integer)
			_intMissileCount = value
			For i = 0 To picMissiles.Length - 1
				picMissiles(i).Visible = If(i < value, True, False)
			Next
			Invalidate()
		End Set
	End Property

	Public Sub New()
		MyBase.New()
		InitializeComponent()
		picMissiles = {picMissile1, picMissile2, picMissile3, picMissile4, picMissile5, picMissile6, picMissile7, picMissile8, picMissile9, picMissile10}
	End Sub
	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		MyBase.OnPaint(e)
		For Each cntControl As Control In Controls
			If TypeOf cntControl Is IDrawsOnParent AndAlso cntControl.Visible Then
				Dim g As Graphics = e.Graphics
				g.TranslateTransform(cntControl.Left, cntControl.Top)
				CType(cntControl, IDrawsOnParent).ActualOnPaint(New PaintEventArgs(g, cntControl.DisplayRectangle))
				g.TranslateTransform(-cntControl.Left, -cntControl.Top)
			End If
		Next
	End Sub
End Class
