﻿Public Class MaterialPictureButton
	Public ReadOnly Property OriginalTop As Integer
		Get
			Return Top - TranslationY
		End Get
	End Property
	Public ReadOnly Property OriginalLeft As Integer
		Get
			Return Left - TranslationX
		End Get
	End Property
	Private _translationX As Integer
	Public Property TranslationX As Integer
		Get
			Return _translationX
		End Get
		Set(ByVal value As Integer)
			_translationX = value
			Invalidate(True)
		End Set
	End Property
	Private _translationY As Integer

	Public Sub New()
		MyBase.New()
		InitializeComponent()
	End Sub

	Public Property TranslationY As Integer
		Get
			Return _translationY
		End Get
		Set(ByVal value As Integer)
			_translationY = value
			Invalidate(True)
		End Set
	End Property

	Protected Overrides Sub OnPaint(pe As PaintEventArgs)
		pe.Graphics.TranslateClip(TranslationX, TranslationY)
		MyBase.OnPaint(pe)
	End Sub

	'Protected Overrides Sub WndProc(ByRef m As Message)
	'	If m.Msg = &H14 Then 'WM_ERASEBKGND
	'		m.Result = 0
	'	Else
	'		MyBase.WndProc(m)
	'	End If
	'End Sub
End Class
