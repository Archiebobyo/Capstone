Imports MySql.Data.MySqlClient


Public Class AdminForm
    Dim COMMAND As MySqlCommand
    Private Sub AdminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MysqlConn As New MySqlConnection("server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
)
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("SELECT * FROM mydb.Employee", MysqlConn)

        adapter.Fill(table)

        DataGridView1.DataSource = table
    End Sub

    Private Sub MainMenuBtn_Click(sender As Object, e As EventArgs) Handles MainMenuBtn.Click
        Dim MainMenu As New MainMenuForm
        MainMenu.Show()
        Me.Close()
    End Sub

End Class