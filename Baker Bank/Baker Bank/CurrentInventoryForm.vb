Imports MySql.Data.MySqlClient

Public Class currentInventoryForm
    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim StoreID As Integer
    Dim UpdatedInventory(0) As Integer
    Dim UpdatedInventoryQuant(0) As Integer
    Dim IDRow As Integer

    Private Sub cmb_Table_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Table.SelectedIndexChanged
        Dim SelectedItem As String
        SelectedItem = cmb_Table.SelectedItem

        input1.Text = ""
        input2.Text = ""
        input3.Text = ""
        input4.Text = ""
        input5.Text = ""
        input6.Text = ""
        input7.Text = ""
        input8.Text = ""

        If (SelectedItem = "Employee") Then
            load_table("select * from Employee")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False


        ElseIf (SelectedItem = "InventoryOrder") Then
            load_table("select * from InventoryOrder")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False




        ElseIf (SelectedItem = "InventoryOrderProduct") Then
            load_table("select * from InventoryOrderProduct")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False
            field1.Text = "Inventory Order Product ID"
            field2.Text = "Inventory Order ID"
            field3.Text = "Product ID"
            field4.Text = "Order Quantity"
            input1.Location = New Point(336, 39)
            input4.Visible = True
            field4.Visible = True



        ElseIf (SelectedItem = "Products") Then
            load_table("SELECT * from Products")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False



        ElseIf (SelectedItem = "Store") Then
            load_table("SELECT Store.StoreID StoreID, Store.Name StoreName, Store.Address Address, Employee.Name EmployeeName, Store.ContactPhone EmployeePhone, Store.ContactEmail EmployeeEmail FROM Store INNER JOIN Employee On Store.ContactEmployeeID = Employee.EmployeeID;")
            GroupBox1.Visible = True
            dgv_Inventory.Visible = True
            dgv_Stores.Location = New Point(12, 464)
            lb_EmployeeRep.Visible = True
            field_cmb.Visible = True
            field_cmb.Text = "Employee Rep."
            field2.Text = "Store Name"
            field3.Text = "Store Address"
            field4.Visible = False
            field5.Visible = False
            field6.Visible = False
            field7.Visible = False
            field8.Visible = False
            input4.Visible = False
            input5.Visible = False
            input6.Visible = False
            input7.Visible = False
            input8.Visible = False

        ElseIf (SelectedItem = "StoreProduct") Then
            load_table("select * from StoreProduct")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False


        ElseIf (SelectedItem = "Warehouse") Then
            load_table("select * from Warehouse")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False



        ElseIf (SelectedItem = "WarehouseProduct") Then
            load_table("select * from WarehouseProduct")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False



        End If
    End Sub

    Private Sub currentInventoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (User.EmployeeType = 0) Then
            ' Everything is fair game
            Me.Text = "Store Manager -- Admin View"
        ElseIf (User.EmployeeType = 1) Then
            ' Can't delete or create stores, but can modify them
            Me.Text = "Store Manager -- Store Manager View"
            Button1.Visible = False
            btn_Insert.Visible = False
        ElseIf (User.EmployeeType = 2) Then
            ' Can't delete, create, or modify stores, but can view them
            Me.Text = "Store Manager -- Store Employee View"
            Button1.Visible = False
            btn_Insert.Visible = False
            btn_Update.Visible = False
        ElseIf (User.EmployeeType = 3) Then
            ' Can't delete, create, or modify stores, but can view them
            Me.Text = "Store Manager -- Warehouse Employee View"
            Button1.Visible = False
            btn_Insert.Visible = False
            btn_Update.Visible = False
        End If

        cmb_Table.SelectedItem = "Store"

        FillListBox()
        load_table("SELECT Store.StoreID StoreID, Store.Name StoreName, Store.Address Address, Employee.Name EmployeeName, Store.ContactPhone EmployeePhone, Store.ContactEmail EmployeeEmail FROM Store INNER JOIN Employee On Store.ContactEmployeeID = Employee.EmployeeID;")

    End Sub

    Private Sub load_table(ByVal query As String)
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource

        Try
            MysqlConn.Open()
            COMMAND = New MySqlCommand(query, MysqlConn)
            SDA.SelectCommand = COMMAND
            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            dgv_Stores.DataSource = bSource
            SDA.Update(dbDataSet)

            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub

    Private Sub load_inventory()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource
        Dim numRows As Integer

        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "SELECT Store.StoreID StoreID, Store.Name StoreName, StoreProduct.StoreProductID, StoreProduct.ProductID, Products.Name Product, StoreProduct.CountOnHand Quantity FROM Store INNER JOIN StoreProduct On StoreProduct.StoreID = Store.StoreID INNER JOIN Products ON Products.ProductID = StoreProduct.ProductID WHERE Store.StoreID = '" & StoreID & "';"
            COMMAND = New MySqlCommand(Query, MysqlConn)
            SDA.SelectCommand = COMMAND
            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            dgv_Inventory.DataSource = bSource
            SDA.Update(dbDataSet)

            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try


        numRows = dgv_Inventory.Rows.Count

        For i As Integer = Me.GroupBox1.Controls.Count - 1 To 0 Step -1
            If TypeOf Me.GroupBox1.Controls(i) Is Button Then
                Continue For
            End If
            Me.GroupBox1.Controls.RemoveAt(i)
        Next


        For j As Integer = 0 To numRows - 1
            Dim lb_Changes As Label
            lb_Changes = New Label With {
                .Text = dgv_Inventory.Rows(j).Cells(4).Value(),
                .Location = New Point(100, 59 + ((j + 1) * 26)),
                .Name = "lb" + (j.ToString)
            }
            GroupBox1.Controls.Add(lb_Changes)
            ReDim Preserve UpdatedInventory(j)
            UpdatedInventory(j) = dgv_Inventory.Rows(j).Cells(2).Value()

            Dim tb_Changes As NumericUpDown
            tb_Changes = New NumericUpDown With {
                .Value = dgv_Inventory.Rows(j).Cells(5).Value(),
                .Location = New Point(200, 59 + ((j + 1) * 26)),
                .Name = "tb" + (j.ToString)
            }
            GroupBox1.Controls.Add(tb_Changes)
            AddHandler tb_Changes.ValueChanged, AddressOf numericUpDown_valueChanged
        Next



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
        Dim SelectedItem As String
        SelectedItem = cmb_Table.SelectedItem


        If (SelectedItem = "Employee") Then
            load_table("select * from Employee")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False


        ElseIf (SelectedItem = "InventoryOrder") Then
            load_table("select * from InventoryOrder")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False



        ElseIf (SelectedItem = "InventoryOrderProduct") Then
            load_table("select * from InventoryOrderProduct")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False
            field1.Text = "Inventory Order Product ID"
            field2.Text = "Inventory Order ID"
            field3.Text = "Product ID"
            field4.Text = "Order Quantity"



        ElseIf (SelectedItem = "Products") Then
            load_table("SELECT * from Products")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False



        ElseIf (SelectedItem = "Store") Then
            load_table("SELECT Store.StoreID StoreID, Store.Name StoreName, Store.Address Address, Employee.Name EmployeeName, Store.ContactPhone EmployeePhone, Store.ContactEmail EmployeeEmail FROM Store INNER JOIN Employee On Store.ContactEmployeeID = Employee.EmployeeID;")
            load_inventory()
            GroupBox1.Visible = True
            dgv_Inventory.Visible = True
            dgv_Stores.Location = New Point(12, 464)
            lb_EmployeeRep.Visible = True
            field_cmb.Visible = True
            field_cmb.Text = "Employee Rep."
            field5.Visible = False
            field6.Visible = False
            field7.Visible = False
            field8.Visible = False
            input5.Visible = False
            input6.Visible = False
            input7.Visible = False
            input8.Visible = False

        ElseIf (SelectedItem = "StoreProduct") Then
            load_table("select * from StoreProduct")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False


        ElseIf (SelectedItem = "Warehouse") Then
            load_table("select * from Warehouse")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False



        ElseIf (SelectedItem = "WarehouseProduct") Then
            load_table("select * from WarehouseProduct")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False



        End If
    End Sub

    Private Sub btn_Insert_Click(sender As Object, e As EventArgs) Handles btn_Insert.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim READER As MySqlDataReader
        Dim StoreID As Integer
        Dim EmployeeID As Integer
        Dim EmployeeEmail As String
        Dim EmployeePhone As Integer
        Dim SelectedItem As String
        SelectedItem = cmb_Table.SelectedItem
        Dim InventoryOrderProductID As Integer


        If (SelectedItem = "Store") Then
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "select MAX(Store.storeid) from mydb.Store"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                If COMMAND.ExecuteScalar Is DBNull.Value Then
                    StoreID = 0
                Else
                    StoreID = COMMAND.ExecuteScalar
                    StoreID += 1
                End If
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
                query = "insert into mydb.Store (storeid, name, address, contactphone, contactemail, contactemployeeid) values ('" & StoreID & "', '" & input2.Text & "', '" & input3.Text & "', '" & EmployeePhone & "', '" & EmployeeEmail & "', '" & EmployeeID & "')"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader
                Dim count As Integer

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            load_table("SELECT Store.StoreID StoreID, Store.Name StoreName, Store.Address Address, Employee.Name EmployeeName, Store.ContactPhone EmployeePhone, Store.ContactEmail EmployeeEmail FROM Store INNER JOIN Employee On Store.ContactEmployeeID = Employee.EmployeeID;")
        ElseIf (SelectedItem = "InventoryOrderProduct") Then
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "select MAX(InventoryOrderProduct.InventoryOrderProductID) from mydb.InventoryOrderProduct"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                If COMMAND.ExecuteScalar Is DBNull.Value Then
                    InventoryOrderProductID = 0
                Else
                    InventoryOrderProductID = COMMAND.ExecuteScalar
                    InventoryOrderProductID += 1
                End If
                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try
            Try
                MysqlConn.Open()
                Dim query As String
                query = "insert into mydb.InventoryOrderProduct (InventoryOrderProductID, InventoryOrderID, ProductID, OrderQuantity) values ('" & InventoryOrderProductID & "', '" & input2.Text & "', '" & input3.Text & "', '" & input4.Text & "')"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader
                Dim count As Integer

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            load_table("select * from InventoryOrderProduct;")

        End If




    End Sub

    Private Sub btn_Update_Click(sender As Object, e As EventArgs) Handles btn_Update.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim READER As MySqlDataReader
        Dim EmployeeID As Integer
        Dim EmployeeEmail As String
        Dim EmployeePhone As Integer

        Dim SelectedItem As String
        SelectedItem = cmb_Table.SelectedItem

        If (SelectedItem = "InventoryOrderProduct") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "update InventoryOrderProduct set InventoryOrderID = '" & input2.Text & "', ProductID = '" & input3.Text & "', OrderQuantity = '" & input4.Text & "' WHERE InventoryOrderProductID = '" & IDRow & "'"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            load_table("select * from InventoryOrderProduct")
        ElseIf (SelectedItem = "Store") Then
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
                query = "update Store set Name = '" & input2.Text & "', Address = '" & input3.Text & "', ContactPhone = '" & EmployeePhone & "', ContactEmail = '" & EmployeeEmail & "', ContactEmployeeID = '" & EmployeeID & "' WHERE StoreID = '" & StoreID & "'"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            load_table("SELECT Store.StoreID StoreID, Store.Name StoreName, Store.Address Address, Employee.Name EmployeeName, Store.ContactPhone EmployeePhone, Store.ContactEmail EmployeeEmail FROM Store INNER JOIN Employee On Store.ContactEmployeeID = Employee.EmployeeID;")

        End If



    End Sub

    Private Sub dgvStores_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Stores.CellClick
        Dim SelectedItem As String
        SelectedItem = cmb_Table.SelectedItem

        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = dgv_Stores.Rows(index)

        IDRow = selectedRow.Cells(0).Value()

        input1.Text = ""
        input2.Text = ""
        input3.Text = ""
        input4.Text = ""
        input5.Text = ""
        input6.Text = ""
        input7.Text = ""
        input8.Text = ""

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim READER As MySqlDataReader

        If (SelectedItem = "Employee") Then
            load_table("select * from Employee")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False


        ElseIf (SelectedItem = "InventoryOrder") Then
            load_table("select * from InventoryOrder")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False



        ElseIf (SelectedItem = "InventoryOrderProduct") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "SELECT * from InventoryOrderProduct WHERE InventoryOrderProductID = '" & IDRow & "'"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                While READER.Read()
                    input1.Text = READER(0)
                    input2.Text = READER(1)
                    input3.Text = READER(2)
                    input4.Text = READER(3)
                End While

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            If (e.RowIndex = -1) Then
                Return
            End If



        ElseIf (SelectedItem = "Products") Then
            load_table("SELECT * from Products")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False



        ElseIf (SelectedItem = "Store") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "SELECT Store.StoreID StoreID, Store.Name StoreName, Store.Address Address, Employee.Name EmployeeName FROM Store INNER JOIN Employee On Store.ContactEmployeeID = Employee.EmployeeID WHERE Store.StoreID = '" & IDRow & "';"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                While READER.Read()
                    input1.Text = READER(0)
                    input2.Text = READER(1)
                    input3.Text = READER(2)
                    lb_EmployeeRep.SelectedItem = READER(3)
                End While

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            If (e.RowIndex = -1) Then
                Return
            End If


            load_inventory()

        ElseIf (SelectedItem = "StoreProduct") Then
            load_table("select * from StoreProduct")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False


        ElseIf (SelectedItem = "Warehouse") Then
            load_table("select * from Warehouse")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False



        ElseIf (SelectedItem = "WarehouseProduct") Then
            load_table("select * from WarehouseProduct")
            GroupBox1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False



        End If

        'Try
        '    MysqlConn.Open()
        '    Dim query As String
        '    query = "SELECT Store.StoreID StoreID, Store.Name StoreName, Store.Address Address, Employee.Name EmployeeName FROM Store INNER JOIN Employee On Store.ContactEmployeeID = Employee.EmployeeID WHERE Store.StoreID = '" & IDRow & "';"
        '    COMMAND = New MySqlCommand(query, MysqlConn)
        '    READER = COMMAND.ExecuteReader

        '    While READER.Read()
        '        input1.Text = READER(0)
        '        input2.Text = READER(1)
        '        input3.Text = READER(2)
        '        lb_EmployeeRep.SelectedItem = READER(3)
        '    End While

        '    MysqlConn.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'Finally
        '    MysqlConn.Dispose()
        'End Try

        If (e.RowIndex = -1) Then
            Return
        End If


        load_inventory()

    End Sub

    Private Sub foreach(dataGridViewRow As DataGridViewRow)
        Throw New NotImplementedException()
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

        load_table("SELECT Store.StoreID StoreID, Store.Name StoreName, Store.Address Address, Employee.Name EmployeeName, Store.ContactPhone EmployeePhone, Store.ContactEmail EmployeeEmail FROM Store INNER JOIN Employee On Store.ContactEmployeeID = Employee.EmployeeID;")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim i As Integer
        i = 0
        For Each ctl As Control In Me.Controls
            For Each nud As NumericUpDown In ctl.Controls.OfType(Of NumericUpDown)()
                ReDim Preserve UpdatedInventoryQuant(i)
                UpdatedInventoryQuant(i) = nud.Value

                i += 1
            Next
        Next

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim READER As MySqlDataReader
        Dim StoreProductID As Integer

        Dim k As Integer
        k = 0
        For Each value In UpdatedInventory
            Try
                ' MessageBox.Show("update StoreProduct set CountOnHand = '" & UpdatedInventoryQuant(k).ToString & "' where StoreProductID = '" & value.ToString)
                MysqlConn.Open()
                Dim query As String
                query = "update StoreProduct set CountOnHand = '" & UpdatedInventoryQuant(k) & "' where StoreProductID = '" & value & "'"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            k += 1
        Next

        Erase UpdatedInventory
        Erase UpdatedInventoryQuant

        load_table("SELECT Store.StoreID StoreID, Store.Name StoreName, Store.Address Address, Employee.Name EmployeeName, Store.ContactPhone EmployeePhone, Store.ContactEmail EmployeeEmail FROM Store INNER JOIN Employee On Store.ContactEmployeeID = Employee.EmployeeID;")
        load_inventory()
    End Sub


    Private Sub numericUpDown_valueChanged(sender As Object, e As EventArgs)
        'MessageBox.Show("value changed")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        ' Dim Form As New InventoryOrderForm
        ' Form.Show()
    End Sub


End Class