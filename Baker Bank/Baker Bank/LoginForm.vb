Imports MySql.Data.MySqlClient

Public Class LoginForm
    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"

        Try
            MysqlConn.Open()
            MessageBox.Show("Connection Successful")
            MysqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim READER As MySqlDataReader
        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "select * from mydb.Employee where email='" & TextBox1.Text & "' and password='" & TextBox2.Text & "' "
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count = count + 1
            End While

            If count = 1 Then
                MessageBox.Show("UserName And Password are correct")
                Dim MainMenu As New MainMenuForm
                MainMenu.Show()
                Me.Close()
            ElseIf count > 1 Then
                MessageBox.Show("UserName And Password are Duplicate")
            Else
                MessageBox.Show("UserName And Password are not correct")
            End If


            MysqlConn.Close()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.UseSystemPasswordChar = True
    End Sub
End Class
