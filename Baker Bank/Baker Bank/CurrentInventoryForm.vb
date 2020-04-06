Imports MySql.Data.MySqlClient

Public Class currentInventoryForm
    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim StoreID As Integer


    Private Sub currentInventoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connectToDB() ' so we can connect to our DB without tying this to a button
        FillListBox()
        load_table()
    End Sub

    Private Sub connectToDB()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"

        Try
            MysqlConn.Open()
            MysqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try

    End Sub




    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub load_table()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource

        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "SELECT Store.StoreID StoreID, Store.Name StoreName, Store.Address Address, Employee.Name EmployeeName, Store.ContactPhone EmployeePhone, Store.ContactEmail EmployeeEmail FROM Store INNER JOIN Employee On Store.ContactEmployeeID = Employee.EmployeeID;"
            COMMAND = New MySqlCommand(Query, MysqlConn)
            SDA.SelectCommand = COMMAND
            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet)

            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub

    Private Sub FillListBox()
        Dim stringCmd As String
        Dim myCmd As MySqlCommand

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"

        'Frame your query here.
        stringCmd = "SELECT Name, EmployeeID FROM mydb.Employee"

        'Get a command by using your connection and query.
        myCmd = New MySqlCommand(stringCmd, MysqlConn)

        'Open the connection.
        MysqlConn.Open()

        'create a reader to store the datum which will be returned from the DB
        Dim myReader As MySqlDataReader

        'Execute your query using .ExecuteReader()
        myReader = myCmd.ExecuteReader()

        'Reset your List box here.
        lb_EmployeeRep.Items.Clear()

        While (myReader.Read())
            'Add the items from db one by one into the list box.
            lb_EmployeeRep.Items.Add(myReader.GetString(0))
        End While

        'Close the reader and the connection.
        myReader.Close()
        MysqlConn.Close()

    End Sub

    Private Sub btn_LoadData_Click(sender As Object, e As EventArgs) Handles btn_LoadData.Click
        load_table()
    End Sub

    Private Sub btn_Insert_Click(sender As Object, e As EventArgs) Handles btn_Insert.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim READER As MySqlDataReader
        Dim StoreID As Integer
        Dim EmployeeID As Integer
        Dim EmployeeEmail As String
        Dim EmployeePhone As Integer

        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "select MAX(Store.storeid) from mydb.Store"
            COMMAND = New MySqlCommand(Query, MysqlConn)
            StoreID = COMMAND.ExecuteScalar
            StoreID += 1
            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try


        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "select Employee.EmployeeID from mydb.Employee where Employee.Name = '" & lb_EmployeeRep.SelectedItem & "'"
            COMMAND = New MySqlCommand(Query, MysqlConn)
            EmployeeID = COMMAND.ExecuteScalar

            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try


        Try
            MysqlConn.Open()
            Dim query As String
            query = "select Employee.Phone, Employee.Email from mydb.Employee where Employee.EmployeeId = '" & EmployeeID & "'"
            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader

            While READER.Read()
                EmployeePhone = READER(0)
                EmployeeEmail = READER(1)
            End While

            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try



        Try
            MysqlConn.Open()
            Dim query As String
            query = "insert into mydb.Store (storeid, name, address, contactphone, contactemail, contactemployeeid) values ('" & StoreID & "', '" & tb_StoreName.Text & "', '" & tb_StoreAddress.Text & "', '" & EmployeePhone & "', '" & EmployeeEmail & "', '" & EmployeeID & "')"
            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader
            Dim count As Integer

            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try

        load_table()

    End Sub

    Private Sub btn_Update_Click(sender As Object, e As EventArgs) Handles btn_Update.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim READER As MySqlDataReader
        Dim EmployeeID As Integer
        Dim EmployeeEmail As String
        Dim EmployeePhone As Integer

        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "select Employee.EmployeeID from mydb.Employee where Employee.Name = '" & lb_EmployeeRep.SelectedItem & "'"
            COMMAND = New MySqlCommand(Query, MysqlConn)
            EmployeeID = COMMAND.ExecuteScalar

            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try


        Try
            MysqlConn.Open()
            Dim query As String
            query = "select Employee.Phone, Employee.Email from mydb.Employee where Employee.EmployeeId = '" & EmployeeID & "'"
            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader

            While READER.Read()
                EmployeePhone = READER(0)
                EmployeeEmail = READER(1)
            End While

            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try

        Try
            MysqlConn.Open()
            Dim query As String
            query = "update Store set Name = '" & tb_StoreName.Text & "', Address = '" & tb_StoreAddress.Text & "', ContactPhone = '" & EmployeePhone & "', ContactEmail = '" & EmployeeEmail & "', ContactEmployeeID = '" & EmployeeID & "' WHERE StoreID = '" & StoreID & "'"
            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader

            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try

        load_table()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        StoreID = DataGridView1.CurrentCell.RowIndex

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim READER As MySqlDataReader

        Try
            MysqlConn.Open()
            Dim query As String
            query = "SELECT Store.StoreID StoreID, Store.Name StoreName, Store.Address Address, Employee.Name EmployeeName FROM Store INNER JOIN Employee On Store.ContactEmployeeID = Employee.EmployeeID WHERE Store.StoreID = '" & StoreID & "';"
            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader

            While READER.Read()
                tb_StoreID.Text = READER(0)
                tb_StoreName.Text = READER(1)
                tb_StoreAddress.Text = READER(2)
                lb_EmployeeRep.SelectedItem = READER(3)
            End While

            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim READER As MySqlDataReader
        Dim EmployeeID As Integer
        Dim EmployeeEmail As String
        Dim EmployeePhone As Integer

        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "select Employee.EmployeeID from mydb.Employee where Employee.Name = '" & lb_EmployeeRep.SelectedItem & "'"
            COMMAND = New MySqlCommand(Query, MysqlConn)
            EmployeeID = COMMAND.ExecuteScalar

            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try


        Try
            MysqlConn.Open()
            Dim query As String
            query = "select Employee.Phone, Employee.Email from mydb.Employee where Employee.EmployeeId = '" & EmployeeID & "'"
            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader

            While READER.Read()
                EmployeePhone = READER(0)
                EmployeeEmail = READER(1)
            End While

            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try

        Try
            MysqlConn.Open()
            Dim query As String
            query = "delete from Store where StoreID = '" & StoreID & "';"
            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader

            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try

        load_table()
    End Sub
End Class