Public Class DrawingOnParentPictureBox

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim frmParent As Form = FindForm()
        Dim g As Graphics = frmParent.CreateGraphics()
        Dim p As Control = Me
        Do While p IsNot frmParent
            g.TranslateTransform(p.Left - 20, p.Top - 20)
            p = p.Parent
        Loop
        Dim pe As PaintEventArgs = New PaintEventArgs(g, Rectangle.Round(g.VisibleClipBounds))
        MyBase.OnPaint(pe)
    End Sub
End Class
