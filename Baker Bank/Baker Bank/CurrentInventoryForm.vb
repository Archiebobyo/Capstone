Imports MySql.Data.MySqlClient

Public Class currentInventoryForm
    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim StoreID As Integer
    Dim UpdatedInventory(0) As Integer
    Dim UpdatedInventoryQuant(0) As Integer
    Dim IDRow As Integer

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
        load_table("SELECT Store.StoreID StoreID, Store.Name StoreName, Store.Address Address, Store.City, Store.State, Store.Zip, Employee.Name EmployeeName, Store.ContactPhone EmployeePhone, Store.ContactEmail EmployeeEmail FROM Store INNER JOIN Employee On Store.ContactEmployeeID = Employee.EmployeeID;")

        load_inventory()

    End Sub
    Private Sub cmb_Table_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Table.SelectedIndexChanged
        loadData()
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

        FillListBox()

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

        For i As Integer = Me.Panel1.Controls.Count - 1 To 0 Step -1
            If TypeOf Me.Panel1.Controls(i) Is Button Then
                Continue For
            End If
            Me.Panel1.Controls.RemoveAt(i)
        Next


        For j As Integer = 0 To numRows - 1
            Dim lb_Changes As Label
            lb_Changes = New Label With {
                .Text = dgv_Inventory.Rows(j).Cells(4).Value(),
                .Location = New Point(100, 59 + ((j + 1) * 26)),
                .Name = "lb" + (j.ToString)
            }
            Panel1.Controls.Add(lb_Changes)
            ReDim Preserve UpdatedInventory(j)
            UpdatedInventory(j) = dgv_Inventory.Rows(j).Cells(2).Value()

            Dim tb_Changes As NumericUpDown
            tb_Changes = New NumericUpDown With {
                .Value = dgv_Inventory.Rows(j).Cells(5).Value(),
                .Location = New Point(200, 59 + ((j + 1) * 26)),
                .Name = "tb" + (j.ToString)
            }
            Panel1.Controls.Add(tb_Changes)
            'AddHandler tb_Changes.ValueChanged, AddressOf numericUpDown_valueChanged
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
        loadData()
    End Sub
    ' Copy and paste from other function when done

    Private Sub btn_Insert_Click(sender As Object, e As EventArgs) Handles btn_Insert.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim READER As MySqlDataReader
        Dim StoreID As Integer
        Dim EmployeeID As Integer
        Dim EmployeeEmail As String
        Dim EmployeePhone As Integer
        Dim EmployeeAddress As String
        Dim EmployeeCity As String
        Dim EmployeeState As String
        Dim EmployeeZip As Integer
        Dim SelectedItem As String
        SelectedItem = cmb_Table.SelectedItem
        Dim InventoryOrderProductID As Integer
        Dim InventoryOrderID As Integer
        Dim ProductID As Integer
        Dim StoreProductID As Integer
        Dim StoreProduct_StoreID As Integer
        Dim StoreProduct_ProductID As Integer
        Dim WarehouseID As Integer
        Dim WarehouseProductID As Integer



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
                    'EmployeeAddress = READER(2)
                    'EmployeeCity = READER(3)
                    'EmployeeState = READER(4)
                    'EmployeeZip = READER(5)
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
                query = "insert into mydb.Store (storeid, name, contactphone, contactemail, contactemployeeid, address, city, state, zip) values ('" & StoreID & "', '" & input2.Text & "', '" & EmployeePhone & "', '" & EmployeeEmail & "', '" & EmployeeID & "', '" & input7.Text & "', '" & input8.Text & "', '" & input9.Text & "', '" & input10.Text & "')"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader
                Dim count As Integer

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            load_table("SELECT Store.StoreID StoreID, Store.Name StoreName, Store.Address Address, Store.City, Store.State, Store.Zip, Employee.Name EmployeeName, Store.ContactPhone EmployeePhone, Store.ContactEmail EmployeeEmail FROM Store INNER JOIN Employee On Store.ContactEmployeeID = Employee.EmployeeID;")
            load_inventory()
        ElseIf (SelectedItem = "Warehouse") Then
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "select MAX(Warehouse.WarehouseID) from mydb.Warehouse"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                If COMMAND.ExecuteScalar Is DBNull.Value Then
                    WarehouseID = 0
                Else
                    WarehouseID = COMMAND.ExecuteScalar
                    WarehouseID += 1
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
                    'EmployeeAddress = READER(2)
                    'EmployeeCity = READER(3)
                    'EmployeeState = READER(4)
                    'EmployeeZip = READER(5)
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
                query = "insert into mydb.Warehouse (WarehouseID, Name, Address, City, State, Zip, ContactPhone, ContactEmail, ContactEmployeeID) values ('" & WarehouseID & "', '" & input2.Text & "', '" & input7.Text & "', '" & input8.Text & "', '" & input9.Text & "', '" & input10.Text & "', '" & EmployeePhone & "', '" & EmployeeEmail & "', '" & EmployeeID & " ')"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader
                Dim count As Integer

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            load_table("SELECT * from Warehouse")
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

        ElseIf (SelectedItem = "Employee") Then
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "select MAX(Employee.EmployeeID) from mydb.Employee"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                If COMMAND.ExecuteScalar Is DBNull.Value Then
                    EmployeeID = 0
                Else
                    EmployeeID = COMMAND.ExecuteScalar
                    EmployeeID += 1
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
                query = "insert into mydb.Employee (EmployeeID, Name, EmployeeType, Phone, Email, Password, Address, City, State, Zip) values ('" & EmployeeID & "', '" & input2.Text & "', '" & input3.Text & "', '" & input4.Text & "', '" & input5.Text & "', '" & input6.Text & ", '" & input7.Text & "', '" & "', '" & input8.Text & "', '" & input9.text & "')"
                MessageBox.Show(query)
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader
                Dim count As Integer

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            load_table("select * from Employee;")
        ElseIf (SelectedItem = "InventoryOrder") Then
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "select MAX(InventoryOrder.InventoryOrderID) from mydb.InventoryOrder"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                If COMMAND.ExecuteScalar Is DBNull.Value Then
                    InventoryOrderID = 0
                Else
                    InventoryOrderID = COMMAND.ExecuteScalar
                    InventoryOrderID += 1
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
                query = "insert into mydb.InventoryOrder (InventoryOrderID, EmployeeID, StoreID, WarehouseID, DateofOrder, ManagerApporval) values ('" & InventoryOrderID & "', '" & input2.Text & "', '" & input3.Text & "', '" & input4.Text & "', '" & input5.Text & "', '" & input6.Text & "')"
                MessageBox.Show(query)
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader
                Dim count As Integer

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            load_table("select * from InventoryOrder;")
        ElseIf (SelectedItem = "Products") Then
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "select MAX(Products.ProductID) from mydb.Products"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                If COMMAND.ExecuteScalar Is DBNull.Value Then
                    ProductID = 0
                Else
                    ProductID = COMMAND.ExecuteScalar
                    ProductID += 1
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
                query = "insert into mydb.Products (ProductID, Name, Price) values ('" & ProductID & "', '" & input2.Text & "', '" & input3.Text & "')"
                MessageBox.Show(query)
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader
                Dim count As Integer

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            load_table("select * from Products;")
        ElseIf (SelectedItem = "StoreProduct") Then
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "select MAX(StoreProduct.StoreProductID) from mydb.StoreProduct"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                READER = COMMAND.ExecuteReader

                While READER.Read()
                    StoreProductID = READER(0) + 1
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
                query = "insert into mydb.StoreProduct (StoreProductID, StoreID, ProductID, CountOnHand) values ('" & StoreProductID & "', '" & input2.Text & "', '" & input3.Text & "', '" & input4.Text & "')"
                MessageBox.Show(query)
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader
                Dim count As Integer

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            load_table("select * from StoreProduct;")
        ElseIf (SelectedItem = "WarehouseProduct") Then
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "select MAX(WarehouseProduct.WarehouseProductID) from mydb.WarehouseProduct"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                READER = COMMAND.ExecuteReader

                While READER.Read()
                    WarehouseProductID = READER(0) + 1
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
                query = "insert into mydb.WarehouseProduct (WarehouseProductID, WarehouseID, ProductID, CountOnHand) values ('" & WarehouseProductID & "', '" & input2.Text & "', '" & input3.Text & "', '" & input4.Text & "')"
                MessageBox.Show(query)
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader
                Dim count As Integer

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            load_table("select * from WarehouseProduct;")
        End If




    End Sub

    Private Sub btn_Update_Click(sender As Object, e As EventArgs) Handles btn_Update.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim READER As MySqlDataReader
        Dim EmployeeID As Integer
        Dim EmployeeEmail As String
        Dim EmployeePhone As Integer
        Dim EmployeeAddress As String
        Dim EmployeeCity As String
        Dim EmployeeState As String
        Dim EmployeeZip As Integer

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
        ElseIf (SelectedItem = "Employee") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "update Employee set Name = '" & input2.Text & "', EmployeeType = '" & input3.Text & "', Phone = '" & input4.Text & "', Email = '" & input5.Text & "', Password = '" & input6.Text & "', Address = '" & input7.Text & "', City = '" & input8.Text & "', State = '" & input9.Text & "', Zipcode = '" & input10.Text & "' WHERE EmployeeID = '" & IDRow & "'"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            load_table("select * from Employee")
        ElseIf (SelectedItem = "InventoryOrder") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "update InventoryOrder set EmployeeID = '" & input2.Text & "', StoreID = '" & input3.Text & "', WarehouseID = '" & input4.Text & "', DateofOrder = '" & input5.Text & "', ManagerApporval = '" & input6.Text & "' WHERE InventoryOrderID = '" & IDRow & "'"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            load_table("select * from InventoryOrder")
        ElseIf (SelectedItem = "Products") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "update Products set Name = '" & input2.Text & "', Price = '" & input3.Text & "' WHERE ProductID = '" & IDRow & "'"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            load_table("select * from Products")
        ElseIf (SelectedItem = "StoreProduct") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "update StoreProduct set StoreID = '" & input2.Text & "', ProductID = '" & input3.Text & "', CountOnHand = '" & input4.Text & "' WHERE StoreProductID = '" & IDRow & "'"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            load_table("select * from StoreProduct")
        ElseIf (SelectedItem = "WarehouseProduct") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "update WarehouseProduct set WarehouseID = '" & input2.Text & "', ProductID = '" & input3.Text & "', CountOnHand = '" & input4.Text & "' WHERE WarehouseProductID = '" & IDRow & "'"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            load_table("select * from WarehouseProduct")
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
                query = "update Store set Name = '" & input2.Text & "', ContactPhone = '" & EmployeePhone & "', ContactEmail = '" & EmployeeEmail & "', ContactEmployeeID = '" & EmployeeID & "', Address = '" & input7.Text & "', City = '" & input8.Text & "', State = '" & input9.Text & "', Zip = '" & input10.Text & "' WHERE StoreID = '" & StoreID & "'"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            load_table("SELECT Store.StoreID StoreID, Store.Name StoreName, Store.Address Address, Store.City, Store.State, Store.Zip, Employee.Name EmployeeName, Store.ContactPhone EmployeePhone, Store.ContactEmail EmployeeEmail FROM Store INNER JOIN Employee On Store.ContactEmployeeID = Employee.EmployeeID;")
        ElseIf (SelectedItem = "Warehouse") Then
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
                query = "update Warehouse set Name = '" & input2.Text & "', ContactPhone = '" & EmployeePhone & "', ContactEmail = '" & EmployeeEmail & "', ContactEmployeeID = '" & EmployeeID & "', Address = '" & input7.Text & "', City = '" & input8.Text & "', State = '" & input9.Text & "', Zip = '" & input10.Text & "' WHERE WarehouseID = '" & IDRow & "'"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            load_table("select * from Warehouse")

        End If



    End Sub

    Private Sub dgvStores_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Stores.CellClick
        Dim SelectedItem As String
        SelectedItem = cmb_Table.SelectedItem


        Dim selectedRow As DataGridViewRow
        If (e.ColumnIndex = -1 Or e.RowIndex = -1) Then
            Return
        Else
            selectedRow = dgv_Stores.Rows(e.RowIndex)
            IDRow = selectedRow.Cells(0).Value()
            ' MessageBox.Show("ID is " + IDRow.ToString)
        End If




        input1.Text = ""
        input2.Text = ""
        input3.Text = ""
        input4.Text = ""
        input5.Text = ""
        input6.Text = ""
        input7.Text = ""
        input8.Text = ""
        input9.Text = ""
        input10.Text = ""

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim READER As MySqlDataReader

        If (SelectedItem = "Employee") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "SELECT * from Employee WHERE EmployeeID = '" & IDRow & "'"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                While READER.Read()
                    input1.Text = READER(0)
                    input2.Text = READER(3)
                    input3.Text = READER(4)
                    input4.Text = READER(5)
                    input5.Text = READER(6)
                    input6.Text = READER(8)
                    input7.Text = READER(9)
                    input8.Text = READER(10)
                    input9.Text = READER(11)
                    input10.Text = READER(12)
                    input4.Visible = True
                    input5.Visible = True
                    input6.Visible = True
                    field4.Visible = True
                    field5.Visible = True
                    field6.Visible = True
                    field7.Visible = True
                    field8.Visible = True
                    field9.Visible = True
                    field10.Visible = True
                    input7.Visible = True
                    input8.Visible = True
                    input9.Visible = True
                    input10.Visible = True
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
            If (e.ColumnIndex = -1) Then
                Return
            End If
        ElseIf (SelectedItem = "InventoryOrder") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "SELECT * from InventoryOrder WHERE InventoryOrderID = '" & IDRow & "'"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                While READER.Read()
                    input1.Text = READER(0)
                    input2.Text = READER(1)
                    input3.Text = READER(2)
                    input4.Text = READER(3)
                    input5.Text = READER(4)
                    input6.Text = READER(6)
                    input4.Visible = True
                    input5.Visible = True
                    input6.Visible = True
                    field4.Visible = True
                    field5.Visible = True
                    field6.Visible = True
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

            If (e.ColumnIndex = -1) Then
                Return
            End If
        ElseIf (SelectedItem = "StoreProduct") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "SELECT * from StoreProduct WHERE StoreProductID = '" & IDRow & "'"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                While READER.Read()
                    input1.Text = READER(0)
                    input2.Text = READER(1)
                    input3.Text = READER(2)
                    input4.Text = READER(3)
                    input4.Visible = True
                    field4.Visible = True

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

            If (e.ColumnIndex = -1) Then
                Return
            End If
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
            If (e.ColumnIndex = -1) Then
                Return
            End If

        ElseIf (SelectedItem = "Products") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "SELECT * from Products WHERE ProductID = '" & IDRow & "'"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                While READER.Read()
                    input1.Text = READER(0)
                    input2.Text = READER(1)
                    input3.Text = READER(2)
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
            If (e.ColumnIndex = -1) Then
                Return
            End If



        ElseIf (SelectedItem = "Products") Then
            load_table("SELECT * from Products")
            Panel1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False



        ElseIf (SelectedItem = "Store") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "SELECT Store.StoreID StoreID, Store.Name StoreName, Store.Address Address, Store.City, Store.State, Store.Zip, Employee.Name EmployeeName FROM Store INNER JOIN Employee On Store.ContactEmployeeID = Employee.EmployeeID WHERE Store.StoreID = '" & IDRow & "';"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                While READER.Read()
                    StoreID = READER(0).ToString
                    input1.Text = READER(0).ToString
                    input2.Text = READER(1).ToString
                    input7.Text = READER(2).ToString
                    input8.Text = READER(3).ToString
                    input9.Text = READER(4).ToString
                    input10.Text = READER(5).ToString
                    lb_EmployeeRep.SelectedItem = READER(6).ToString
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
            If (e.ColumnIndex = -1) Then
                Return
            End If


            load_inventory()

        ElseIf (SelectedItem = "WarehouseProduct") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "SELECT * from WarehouseProduct WHERE WarehouseProduct.WarehouseProductID = '" & IDRow & "';"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                While READER.Read()
                    StoreID = READER(0)
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
            If (e.ColumnIndex = -1) Then
                Return
            End If


        ElseIf (SelectedItem = "Warehouse") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "SELECT * from Warehouse WHERE Warehouse.WarehouseID = '" & IDRow & "';"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                While READER.Read()
                    StoreID = READER(0)
                    input1.Text = READER(0)
                    input2.Text = READER(1)
                    input7.Text = READER(2)
                    input8.Text = READER(3)
                    input9.Text = READER(4)
                    input10.Text = READER(5)
                    lb_EmployeeRep.SelectedItem = READER(6)
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
            If (e.ColumnIndex = -1) Then
                Return
            End If



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

        Dim SelectedItem As String
        SelectedItem = cmb_Table.SelectedItem

        If (SelectedItem = "Store") Then
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
            load_table("SELECT Store.StoreID StoreID, Store.Name StoreName, Store.Address Address, Store.City, Store.State, Employee.Name EmployeeName, Store.ContactPhone EmployeePhone, Store.ContactEmail EmployeeEmail FROM Store INNER JOIN Employee On Store.ContactEmployeeID = Employee.EmployeeID;")
            load_inventory()
        ElseIf (SelectedItem = "Warehouse") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "delete from Warehouse where WarehouseID = '" & IDRow & "';"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try
            load_table("select * from Warehouse;")
        ElseIf (SelectedItem = "InventoryOrderProduct") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "delete from InventoryOrderProduct where InventoryOrderProductID = '" & IDRow & "';"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try
            load_table("select * from InventoryOrderProduct")
        ElseIf (SelectedItem = "Products") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "delete from Products where ProductID = '" & IDRow & "';"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try
            load_table("select * from Products")
        ElseIf (SelectedItem = "StoreProduct") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "delete from StoreProduct where StoreProductID = '" & IDRow & "';"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try
            load_table("select * from StoreProduct")
        ElseIf (SelectedItem = "WarehouseProduct") Then
            Try
                MysqlConn.Open()
                Dim query As String
                query = "delete from WarehouseProduct where WarehouseProductID = '" & IDRow & "';"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try
            load_table("select * from WarehouseProduct")
        ElseIf (SelectedItem = "Employee") Then
                Try
                    MysqlConn.Open()
                    Dim query As String
                    query = "delete from Employee where EmployeeID = '" & IDRow & "';"
                    COMMAND = New MySqlCommand(query, MysqlConn)
                    READER = COMMAND.ExecuteReader

                    MysqlConn.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    MysqlConn.Dispose()
                End Try
                load_table("select * from Employee")
            ElseIf (SelectedItem = "InventoryOrder") Then
                Try
                MysqlConn.Open()
                Dim query As String
                query = "delete from InventoryOrder where InventoryOrderID = '" & IDRow & "';"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try
            load_table("select * from InventoryOrder")
        End If





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

    Public Sub loadData()
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
            Panel1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False
            field1.Text = "Employee ID"
            field2.Text = "Name"
            field3.Text = "EmployeeType"
            field4.Text = "Phone"
            field4.Visible = True
            input4.Visible = True
            field5.Visible = True
            input5.Visible = True
            field5.Text = "Email"
            field6.Visible = True
            input6.Visible = True
            field6.Text = "Password"
            input6.UseSystemPasswordChar = True
            input7.Visible = True
            field7.Visible = True
            input8.Visible = True
            field8.Visible = True
            field9.Visible = True
            field10.Visible = True
            input9.Visible = True
            input10.Visible = True
            field7.Text = "Address"
            field8.Text = "City"
            field9.Text = "State"
            field10.Text = "Zipcode"
            field3.Visible = True
            input3.Visible = True



        ElseIf (SelectedItem = "InventoryOrder") Then
            load_table("select * from InventoryOrder")
            Panel1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False
            field1.Text = "Inventory Order ID"
            field2.Text = "EmployeeID"
            field3.Text = "StoreID"
            field4.Text = "WarehouseID"
            field5.Text = "DateOfOrder"
            field6.Text = "Manager Approval"
            field4.Visible = True
            input4.Visible = True
            field5.Visible = True
            input5.Visible = True
            field4.Visible = True
            field5.Visible = True
            field6.Visible = True
            input6.Visible = True
            input6.UseSystemPasswordChar = False
            input7.Visible = False
            field7.Visible = False
            input8.Visible = False
            field8.Visible = False
            field9.Visible = False
            field10.Visible = False
            input9.Visible = False
            input10.Visible = False
            field3.Visible = True
            input3.Visible = True




        ElseIf (SelectedItem = "InventoryOrderProduct") Then
            load_table("select * from InventoryOrderProduct")
            Panel1.Visible = False
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
            input6.Visible = False
            field6.Visible = False
            field5.Visible = False
            input5.Visible = False
            input7.Visible = False
            field7.Visible = False
            input8.Visible = False
            field8.Visible = False
            field9.Visible = False
            field10.Visible = False
            input9.Visible = False
            input10.Visible = False
            field3.Visible = True
            input3.Visible = True



        ElseIf (SelectedItem = "Products") Then
            load_table("SELECT * from Products")
            Panel1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False
            input4.Visible = False
            input5.Visible = False
            input6.Visible = False
            input7.Visible = False
            input8.Visible = False
            field4.Visible = False
            field5.Visible = False
            field6.Visible = False
            field7.Visible = False
            field8.Visible = False
            field1.Text = "Product ID"
            field2.Text = "Name"
            field3.Text = "Price"
            field3.Visible = True
            input3.Visible = True
            field9.Visible = False
            field10.Visible = False
            input9.Visible = False
            input10.Visible = False


        ElseIf (SelectedItem = "StoreProduct") Then
            load_table("SELECT * from StoreProduct")
            Panel1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False
            input5.Visible = False
            input6.Visible = False
            input7.Visible = False
            input8.Visible = False
            field5.Visible = False
            field6.Visible = False
            field7.Visible = False
            field8.Visible = False
            field1.Text = "Store Product ID"
            field2.Text = "Store ID"
            field3.Text = "Product ID"
            field3.Visible = True
            input3.Visible = True
            field4.Visible = True
            input4.Visible = True
            field4.Text = "Count On Hand"
            field9.Visible = False
            field10.Visible = False
            input9.Visible = False
            input10.Visible = False




        ElseIf (SelectedItem = "Store") Then
            load_table("SELECT Store.StoreID StoreID, Store.Name StoreName, Store.Address Address, Employee.Name EmployeeName, Store.ContactPhone EmployeePhone, Store.ContactEmail EmployeeEmail FROM Store INNER JOIN Employee On Store.ContactEmployeeID = Employee.EmployeeID;")
            Panel1.Visible = True
            dgv_Inventory.Visible = True
            dgv_Stores.Location = New Point(12, 464)
            lb_EmployeeRep.Visible = True
            field_cmb.Visible = True
            field_cmb.Text = "Employee Rep."
            field1.Text = "Store ID"
            field2.Text = "Store Name"
            field3.Text = "Store Address"
            field3.Visible = False
            input3.Visible = False
            field4.Visible = False
            field5.Visible = False
            field6.Visible = False
            field7.Visible = True
            field8.Visible = True
            input4.Visible = False
            input5.Visible = False
            input6.Visible = False
            input7.Visible = True
            input8.Visible = True
            field9.Visible = True
            field10.Visible = True
            input9.Visible = True
            input10.Visible = True
            field7.Text = "Address"
            field8.Text = "City"
            field9.Text = "State"
            field10.Text = "Zipcode"



        ElseIf (SelectedItem = "Warehouse") Then
            load_table("select * from Warehouse")
            Panel1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            field_cmb.Visible = True
            lb_EmployeeRep.Visible = True
            field3.Visible = False
            input3.Visible = False
            field4.Visible = False
            input4.Visible = False
            field5.Visible = False
            input5.Visible = False
            field4.Visible = False
            field5.Visible = False
            field6.Visible = False
            input6.Visible = False
            field7.Visible = True
            field8.Visible = True
            input7.Visible = False
            input8.Visible = False
            input6.UseSystemPasswordChar = False
            field1.Text = "Warehouse ID"
            field2.Text = "Name"
            input7.Visible = True
            input8.Visible = True
            field9.Visible = True
            field10.Visible = True
            input9.Visible = True
            input10.Visible = True
            field7.Text = "Address"
            field8.Text = "City"
            field9.Text = "State"
            field10.Text = "Zipcode"



        ElseIf (SelectedItem = "WarehouseProduct") Then
            load_table("SELECT * from WarehouseProduct")
            Panel1.Visible = False
            dgv_Inventory.Visible = False
            dgv_Stores.Location = New Point(602, 22)
            lb_EmployeeRep.Visible = False
            field_cmb.Visible = False
            input4.Visible = True
            input5.Visible = False
            input6.Visible = False
            input7.Visible = False
            input8.Visible = False
            field4.Visible = True
            field5.Visible = False
            field6.Visible = False
            field7.Visible = False
            field8.Visible = False
            field1.Text = "Warehouse Product ID"
            field2.Text = "Warehouse ID"
            field3.Text = "Product ID"
            field3.Visible = True
            input3.Visible = True
            field9.Visible = False
            field10.Visible = False
            input9.Visible = False
            input10.Visible = False
            field4.Text = "Count On Hand"



        End If
    End Sub

    Private Sub PlaceOrderBtn_Click(sender As Object, e As EventArgs) Handles PlaceOrderBtn.Click
        Dim InventoryOrderForm As New InventoryOrderForm
        InventoryOrderForm.Show()
    End Sub
End Class