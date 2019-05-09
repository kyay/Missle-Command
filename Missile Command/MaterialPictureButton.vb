Public Class MaterialPictureButton
	Private _originalDisplayRectangle As Rectangle
	Public ReadOnly Property OriginalDisplayRectangle() As Rectangle
		Get
			Return _originalDisplayRectangle
		End Get
	End Property
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
			_translationX = value
			Left += TranslationX
			Dim pntLocation = _originalDisplayRectangle.Location
			pntLocation.X = OriginalLeft
            _originalDisplayRectangle.Location = pntLocation
            Me.Invalidate()
        End Set
	End Property
	Private _translationY As Integer
	Public Property TranslationY() As Integer
		Get
			Return _translationY
		End Get
		Set(ByVal value As Integer)
			_translationY = value
			Top += TranslationY
			Dim pntLocation = _originalDisplayRectangle.Location
			pntLocation.Y = OriginalTop
            _originalDisplayRectangle.Location = pntLocation
            Me.Invalidate()
        End Set
	End Property
	Protected Overrides Sub OnPaint(pe As PaintEventArgs)
		pe.Graphics.SetClip(OriginalDisplayRectangle)
        MyBase.OnPaint(pe)
    End Sub
End Class
