Imports System.Threading.Tasks
Public Class Form1
    Shared flag As Integer = 0
    Shared i As Integer = 65

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim taskA = Task.Factory.StartNew(AddressOf metodoA)
        Dim taskB = Task.Factory.StartNew(AddressOf metodoB)
    End Sub
    Private Shared Sub metodoA()
        While i < 91

            If (i Mod 2) = 1 AndAlso flag = 0 Then
                MsgBox(Convert.ToChar(i) & " " & System.Threading.Thread.CurrentThread.ManagedThreadId)
                flag = 1
                i += 1
            End If
        End While
    End Sub

    Private Shared Sub metodoB()
        While i < 91

            If (i Mod 2) = 0 AndAlso flag = 1 Then
                MsgBox(Convert.ToChar(i) & " " & System.Threading.Thread.CurrentThread.ManagedThreadId)
                flag = 0
                i += 1
            End If
        End While
    End Sub
End Class
