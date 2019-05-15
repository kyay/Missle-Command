Public Class MaterialPictureButton
	Public ReadOnly Property OriginalTop() As Integer
		Get
			Return Top - TranslationY
		End Get
	End Property
	Public ReadOnly Property OriginalLeft() As Integer
		Get
			Return Left - TranslationX
		End Get
	End Property
	Private _translationX As Integer
	Public Property TranslationX() As Integer
		Get
			Return _translationX
		End Get
		Set(ByVal value As Integer)
			Left = OriginalLeft + value
			_translationX = value
			Invalidate()
		End Set
	End Property
	Private _translationY As Integer
	Public Property TranslationY() As Integer
		Get
			Return _translationY
		End Get
		Set(ByVal value As Integer)
			Top = OriginalTop + value
			_translationY = value
			Invalidate()
		End Set
	End Property

	Protected Overrides Sub OnPaint(pe As PaintEventArgs)
		pe.Graphics.TranslateClip(-TranslationX, -TranslationY)
		MyBase.OnPaint(pe)
	End Sub
End Class
