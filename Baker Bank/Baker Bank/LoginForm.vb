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
        Dim newPassword As String
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
                'MessageBox.Show("UserName And Password are correct")

                User.EmployeeID = READER(0)
                If Not IsDBNull(READER(1)) Then
                    User.StoreID = READER(1)
                End If
                If Not IsDBNull(READER(2)) Then
                    User.WarehouseID = READER(2)
                End If

                User.Name = READER(3)
                User.EmployeeType = READER(4)
                User.Phone = READER(5)
                User.Email = READER(6)

                If Not IsDBNull(READER(7)) Then
                    User.Address = READER(7)
                End If

                User.ManagerID = READER(7)

                If Not IsDBNull(READER(8)) Then
                    User.Password = READER(8)
                Else
                    MessageBox.Show("Request your Manager to give you a Password.")
                    Me.Close()
                End If
                User.Password = READER(8)




                'MessageBox.Show(User.Email)
                'Dim MainMenu As New MainMenuForm
                'MainMenu.Show()
                Dim CurrentInventoryForm As New currentInventoryForm
                CurrentInventoryForm.Show()
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
