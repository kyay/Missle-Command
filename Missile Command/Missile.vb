
Imports System.ComponentModel

Public Class Missile
    Public Property intRotation As Integer
    <Browsable(False)>
    Public Property pntDestination As Point
    <Browsable(False)>
    Public Property vctSpeed As Windows.Vector
    Public Overrides Sub ActualOnPaint(pe As PaintEventArgs)
        pe.Graphics.RotateTransform(intRotation)
        MyBase.ActualOnPaint(pe)
        pe.Graphics.RotateTransform(-intRotation)
    End Sub
End Class
