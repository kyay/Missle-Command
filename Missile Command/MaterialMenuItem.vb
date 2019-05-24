Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.IO
Imports System.Xml
Imports Svg

Public Class MaterialMenuItem
	Public Enum MouseState
		Down
		Up
		Hover
	End Enum
	Public Property pdgPadding As Padding
	<DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)>
	<Browsable(False)>
	Public Property svgImage As SvgDocument
	Public Event Click()

	<Browsable(True)>
	<Editor(GetType(ResourceFileDropDownListPropertyEditor), GetType(Drawing.Design.UITypeEditor))>
	<Description("Resource name of the SVG image that you want to use")>
	Public Property svgImageFileName() As String

	Private _mstMouseState As MouseState = MouseState.Up
	<Browsable(False)>
	Public Property mstMouseState() As MouseState
		Get
			Return _mstMouseState
		End Get
		Set(ByVal value As MouseState)
			Dim mstPreviousMouseState = mstMouseState
			_mstMouseState = value
			If mstPreviousMouseState = MouseState.Down AndAlso mstMouseState = MouseState.Up Then
				RaiseEvent Click()
			End If
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
	<Browsable(False)>
	Public Property intTop() As Integer
		Get
			Return _rctbounds.Y
		End Get
		Set(ByVal value As Integer)
			_rctbounds.Y = value
		End Set
	End Property
	<Browsable(False)>
	Public Property intLeft() As Integer
		Get
			Return _rctbounds.X
		End Get
		Set(ByVal value As Integer)
			_rctbounds.X = value
		End Set
	End Property
	<Browsable(False)>
	Public Property intWidth() As Integer
		Get
			Return _rctbounds.Width
		End Get
		Set(ByVal value As Integer)
			_rctbounds.Width = value
		End Set
	End Property
	<Browsable(False)>
	Public Property intHeight() As Integer
		Get
			Return _rctbounds.Height
		End Get
		Set(ByVal value As Integer)
			_rctbounds.Height = value
		End Set
	End Property

	Public Overrides Property Site As ISite
		Get
			Return MyBase.Site
		End Get
		Set(value As ISite)
			MyBase.Site = value
			If DesignMode AndAlso value IsNot Nothing Then
				Dim dshHost As IDesignerHost = value.GetService(GetType(IDesignerHost))
				If dshHost IsNot Nothing Then
					If dshHost.RootComponent.GetType.IsAssignableFrom(GetType(TitleShowingOnHoverMaterialForm)) Then
						CType(dshHost.RootComponent, TitleShowingOnHoverMaterialForm).mnuAppBarMenuItems.Add(Me)
					End If
				End If
			End If
		End Set
	End Property

	Public Sub Draw(ByRef g As Graphics)
		Dim SkinManager = MaterialSkin.MaterialSkinManager.Instance
		If Not String.IsNullOrEmpty(svgImageFileName) AndAlso svgImage Is Nothing Then
			Dim runTimeResourceSet As Resources.ResourceSet = My.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, True, True)
			Dim svgImageFile As Byte() = runTimeResourceSet.GetObject(svgImageFileName)
			Using srmImage = New MemoryStream(svgImageFile)
				Dim xmlDoc = New XmlDocument()
				xmlDoc.Load(srmImage)
				svgImage = SvgDocument.Open(xmlDoc)

				Dim clrTextColor = SkinManager.ColorScheme.TextColor
				Dim clrIconColor = DirectCast(svgImage.Color, SvgColourServer).Colour
				Dim intAlpha = 0.5

				DirectCast(svgImage.Color, SvgColourServer).Colour = Color.FromArgb(
					  (clrIconColor.R * intAlpha) + clrTextColor.R * (1 - intAlpha),
					(clrIconColor.G * intAlpha) + clrTextColor.G * (1 - intAlpha),
					(clrIconColor.B * intAlpha) + clrTextColor.B * (1 - intAlpha))
			End Using
		End If
		Dim rctOut As Rectangle = rctBounds
		rctOut.X += pdgPadding.Left
		rctOut.Y += pdgPadding.Top
		rctOut.Width -= pdgPadding.Horizontal
		rctOut.Height -= pdgPadding.Vertical

		Dim btmImage = svgImage.Draw(rctOut.Width, rctOut.Height)
		If btmImage IsNot Nothing Then
			g.DrawImage(btmImage, rctOut)
		End If
		If mstMouseState = MouseState.Hover Then
			g.FillRectangle(SkinManager.GetFlatButtonHoverBackgroundBrush(), rctBounds)
		ElseIf mstMouseState = MouseState.Down Then
			g.FillRectangle(SkinManager.GetFlatButtonPressedBackgroundBrush(), rctBounds)
		End If
	End Sub
End Class
