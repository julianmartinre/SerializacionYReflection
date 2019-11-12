Public Class Form1

    Private Shared Sub TareaA()
        For i = 1 To 10
            MsgBox(i + i * 10)
        Next
    End Sub

    Private Shared Sub TareaB()
        For i = 1 To 10
            MsgBox(i - i * 10)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim taskA As Task = Task.Factory.StartNew(AddressOf TareaA)
        Dim taskB As Task = Task.Factory.StartNew(AddressOf TareaB)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TareaA()
        TareaB()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim taskA As Task = Task.Factory.StartNew(AddressOf TareaA)
        Dim taskB As Task = Task.Factory.StartNew(AddressOf TareaB)
        Dim taskC As Task = Task.Factory.StartNew(AddressOf TareaA)
        Dim taskD As Task = Task.Factory.StartNew(AddressOf TareaB)
    End Sub
End Class
