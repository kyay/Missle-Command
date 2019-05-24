Imports System.ComponentModel

Public Class ComponentExposingMaterialForm
	Public Overridable ReadOnly Property cntComponents() As IContainer
		Get
			Dim cntContainer = New Container()
			For Each cmpComponent In components.Components
				cntContainer.Add(cmpComponent)
			Next
			Return cntContainer
		End Get
	End Property
End Class