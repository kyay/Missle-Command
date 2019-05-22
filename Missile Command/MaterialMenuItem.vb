Imports System.ComponentModel
Imports System.IO
Imports System.Xml
Imports Svg

Public Class MaterialMenuItem
	Public Enum MouseState
		Down
		Up
	End Enum
	Public Property pdgPadding As Padding
	Public Property svgImage As SvgDocument
	Private _svgImageFile As Stream
	Public Property svgImageFile() As 
		Get
			Return _svgImageFile
		End Get
		Set(ByVal value As Stream)
			_svgImageFile = value
			If svgImageFile IsNot Nothing Then
				Dim xmlDoc = New XmlDocument()
				xmlDoc.Load(svgImageFile)
				svgImage = SvgDocument.Open(xmlDoc)
			End If
		End Set
	End Property
	Private _mstMouseState As MouseState
	Public Property mstMouseState() As MouseState
		Get
			Return _mstMouseState
		End Get
		Set(ByVal value As MouseState)
			Dim mstPreviousMouseState = mstMouseState
			_mstMouseState = value

		End Set
	End Property
	Private _rctbounds As Rectangle
	Public Property rctBounds() As Rectangle
		Get
			Return _rctbounds
		End Get
		Set(value As Rectangle)
			_rctbounds.X = value.X
			_rctbounds.Y = value.Y
			_rctbounds.Width = value.Width
			_rctbounds.Height = value.Height
		End Set
	End Property
	Public Property intTop() As Integer
		Get
			Return _rctbounds.Y
		End Get
		Set(ByVal value As Integer)
			_rctbounds.Y = value
		End Set
	End Property
	Public Property intLeft() As Integer
		Get
			Return _rctbounds.X
		End Get
		Set(ByVal value As Integer)
			_rctbounds.X = value
		End Set
	End Property
	Public Property intWidth() As Integer
		Get
			Return _rctbounds.Width
		End Get
		Set(ByVal value As Integer)
			_rctbounds.Width = value
		End Set
	End Property
	Public Property intHeight() As Integer
		Get
			Return _rctbounds.Height
		End Get
		Set(ByVal value As Integer)
			_rctbounds.Height = value
		End Set
	End Property
	Public Sub Draw(ByRef g As Graphics)
		Dim rctOut As Rectangle = rctBounds
		rctOut.X += pdgPadding.Left
		rctOut.Y += pdgPadding.Top
		rctOut.Width -= pdgPadding.Horizontal
		rctOut.Height -= pdgPadding.Vertical
		Dim btmImage = svgImage.Draw(rctOut.Width, rctOut.Height)
		btmImage.MakeTransparent()
		g.DrawImage(btmImage, rctOut)
	End Sub
End Class
