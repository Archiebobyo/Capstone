Public Class MainMenuForm
    Private Sub currentInventoryBtn_Click(sender As Object, e As EventArgs) Handles currentInventoryBtn.Click
        Dim Form As New currentInventoryForm
        Form.Show()
    End Sub

    Private Sub orderFormBtn_Click(sender As Object, e As EventArgs) Handles orderFormBtn.Click
        Dim Form As New OrderForm
        Form.Show()
    End Sub

    Private Sub customerOrderBtn_Click(sender As Object, e As EventArgs) Handles customerOrderBtn.Click
        Dim Form As New CustomerOrderForm
        Form.Show()
    End Sub

    Private Sub logoutBtn_Click(sender As Object, e As EventArgs) Handles logoutBtn.Click
        Dim Form As New LoginForm
        Form.Show()
        Me.Close()
    End Sub
End Class