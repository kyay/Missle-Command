Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms.Design

Public Class ResourceFileDropDownListPropertyEditor
	Inherits UITypeEditor
	Dim _service As IWindowsFormsEditorService

	' <summary>
	' Gets the editing style of the <see cref="EditValue"/> method.
	' </summary>
	' <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
	' <returns>Returns the DropDown style, since this editor uses a drop down list.</returns>
	Public Overrides Function GetEditStyle(context As ITypeDescriptorContext) As UITypeEditorEditStyle
		' We're using a drop down style UITypeEditor.
		Return UITypeEditorEditStyle.DropDown
	End Function

	' <summary>
	' Displays a list of available values for the specified component than sets the value.
	' </summary>
	' <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
	' <param name="provider">A service provider object through which editing services may be obtained.</param>
	' <param name="value">An instance of the value being edited.</param>
	' <returns>The New value of the object. If the value of the object hasn't changed, this method should return the same object it was passed.</returns>
	Public Overrides Function EditValue(context As ITypeDescriptorContext, provider As IServiceProvider, value As Object) As Object
		If provider IsNot Nothing Then
			' This service Is in charge of popping our ListBox.
			_service = DirectCast(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

			If _service IsNot Nothing Then
				Dim strItemsList As List(Of String) = New List(Of String)
				Dim runTimeResourceSet As Resources.ResourceSet

				runTimeResourceSet = My.Resources.ResourceManager.GetResourceSet(Globalization.CultureInfo.CurrentCulture, True, True)
				For Each dictEntry As DictionaryEntry In runTimeResourceSet
					If (dictEntry.Value.GetType() Is GetType(Byte())) Then
						strItemsList.Add(dictEntry.Key)
					End If
				Next

				Dim lstList = New ListBox()
				AddHandler lstList.Click, AddressOf ListBox_Click

				For Each strItem In strItemsList
					lstList.Items.Add(strItem)
				Next
				If value IsNot Nothing Then
					lstList.SelectedValue = value
				End If

				' Drop the list control.
				_service.DropDownControl(lstList)

				If lstList.SelectedItem IsNot Nothing AndAlso lstList.SelectedIndices.Count = 1 Then
					lstList.SelectedItem = lstList.SelectedItem.ToString()
					value = lstList.SelectedItem.ToString()
				End If

				RemoveHandler lstList.Click, AddressOf ListBox_Click
			End If
		End If

		Return value
	End Function

	Private Sub ListBox_Click(sender As Object, e As System.EventArgs)
		If _service IsNot Nothing Then
			_service.CloseDropDown()
		End If
	End Sub
End Class
