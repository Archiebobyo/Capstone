Imports MySql.Data.MySqlClient

Public Class InventoryOrderForm
    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim WarehouseID As Integer
    Dim StoreID As Integer
    Dim InventoryOrderID As Integer
    Dim InventoryOrderProductID As Integer
    Dim OrderID As Integer
    Dim InventoryID As Integer

    Private Sub InventoryOrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'connectToDB()
        load_Warehouse()

        If IsDBNull(User.StoreID) Then
            StoreID = 0
        Else
            StoreID = User.StoreID
        End If

        CurrentStoreNameLbl.Text = User.Name
        'CurrentWarehouseIDlbl.Text = 0
        'CurrentWarehouseNameLbl.Text = User.StoreID

        Dim dt As Date = Date.Today
        CurrentDateLbl.Text = dt.ToString("dd'/'MM'/'yyyy")
        dgv_Warehouse.BackgroundColor = dgv_Warehouse.DefaultCellStyle.BackColor
        dgv_Inventory.BackgroundColor = dgv_Inventory.DefaultCellStyle.BackColor

        If User.EmployeeType = 0 Then
            cmb_Order.Items.Add("Warehouse Inventory")
            cmb_Order.Items.Add("Current Orders")
            cmb_Order.Visible = True

            deleteOrderBtn.Visible = True
            placeOrderBtn.Visible = True
            ApprovalBtn.Visible = True
            ShipOrderBtn.Visible = True
            OrderReciviedBtn.Visible = True
        ElseIf User.EmployeeType = 1 Then
            cmb_Order.Items.Add("InventoryOrderProduct")
            cmb_Order.Items.Add("Current Orders")
            cmb_Order.Visible = True

            deleteOrderBtn.Visible = True
            placeOrderBtn.Visible = True
            ApprovalBtn.Visible = True
            OrderReciviedBtn.Visible = True
        ElseIf User.EmployeeType = 2 Then
            placeOrderBtn.Visible = True
        Else
            ShipOrderBtn.Visible = True
        End If


    End Sub

    Private Sub ConnectToDB()
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

    Private Sub dgv_Warehouse_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_Warehouse.SelectionChanged
        Dim SelectedItem As String
        SelectedItem = cmb_Order.SelectedItem


        If (SelectedItem = "Current Orders") Then
            If dgv_Warehouse.CurrentCell Is Nothing Then
                Return
            Else
                OrderID = CInt(dgv_Warehouse.CurrentRow.Cells(0).Value)
            End If

            MysqlConn = New MySqlConnection
            MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
            Dim READER As MySqlDataReader

            Try
                MysqlConn.Open()
                Dim query As String
                query = "SELECT Products.Name Name, InventoryOrderProduct.OrderQuantity OrderQuantity, Store.StoreID FROM InventoryOrder INNER JOIN InventoryOrderProduct On InventoryOrder.InventoryOrderID = InventoryOrderProduct.InventoryOrderID INNER JOIN Products On InventoryOrderProduct.ProductID = Products.ProductID INNER JOIN Warehouse On InventoryOrder.WarehouseID = Warehouse.WarehouseID INNER JOIN WarehouseProduct On Warehouse.WarehouseID = WarehouseProduct.WarehouseID INNER JOIN Store On InventoryOrder.StoreID = Store.StoreID WHERE InventoryOrder.InventoryOrderID = '" & OrderID & "' AND Products.ProductID = WarehouseProduct.ProductID;"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                'While READER.Read()
                'WarehouseID = READER(0)
                'CurrentWarehouseNameLbl.Text = READER(1)
                'End While

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try
        Else
            If dgv_Warehouse.CurrentCell Is Nothing Then
                Return
            Else
                WarehouseID = CInt(dgv_Warehouse.CurrentCell.RowIndex)
            End If


            MysqlConn = New MySqlConnection
            MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
            Dim READER As MySqlDataReader

            Try
                MysqlConn.Open()
                Dim query As String
                query = "SELECT Warehouse.WarehouseID WarehouseID, Warehouse.Name WarehouseName, Warehouse.Address Address, Employee.Name EmployeeName FROM Warehouse INNER JOIN Employee On Warehouse.ContactEmployeeID = Employee.EmployeeID WHERE Warehouse.WarehouseID = '" & WarehouseID & "';"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                While READER.Read()
                    WarehouseID = READER(0)
                    CurrentWarehouseNameLbl.Text = READER(1)
                End While

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try
        End If


        load_inventory()

    End Sub



    Private Sub load_Warehouse()
        Dim SelectedItem As String
        SelectedItem = cmb_Order.SelectedItem

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource

        If (SelectedItem = "Current Orders") Then
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "SELECT InventoryOrder.InventoryOrderID InventoryOrderID, InventoryOrder.DateOfOrder DateOfOrder, Employee.Name EmployeeName, Warehouse.Name WarehouseName,  InventoryOrder.InventoryOrderState StateOfOrder FROM InventoryOrder INNER JOIN Warehouse On InventoryOrder.WarehouseID = Warehouse.WarehouseID INNER JOIN Employee On InventoryOrder.EmployeeID = Employee.EmployeeID INNER Join Store On InventoryOrder.StoreID = Store.StoreID WHERE Store.StoreID = '" & User.StoreID & "';"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                SDA.SelectCommand = COMMAND
                SDA.Fill(dbDataSet)
                bSource.DataSource = dbDataSet
                dgv_Warehouse.DataSource = bSource
                dgv_Warehouse.Columns(0).Visible = False

                SDA.Update(dbDataSet)

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try
        Else
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "SELECT Warehouse.WarehouseID WarehouseID, Warehouse.Name WarehouseName, Warehouse.Address Address, Employee.Name EmployeeName, Warehouse.ContactPhone EmployeePhone, Warehouse.ContactEmail EmployeeEmail FROM Warehouse INNER JOIN Employee On Warehouse.ContactEmployeeID = Employee.EmployeeID;"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                SDA.SelectCommand = COMMAND
                SDA.Fill(dbDataSet)
                bSource.DataSource = dbDataSet
                dgv_Warehouse.DataSource = bSource
                dgv_Warehouse.Columns(0).Visible = False

                SDA.Update(dbDataSet)

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try
        End If

    End Sub

    Private Sub load_inventory()
        Dim SelectedItem As String
        SelectedItem = cmb_Order.SelectedItem

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource
        Dim x As New Int16

        If dgv_Warehouse.CurrentCell Is Nothing Then
            Return
        Else
            OrderID = CInt(dgv_Warehouse.CurrentRow.Cells(0).Value)
        End If

        If (SelectedItem = "Current Orders") Then
            Try

                MysqlConn.Open()
                Dim Query As String
                Query = "SELECT Products.ProductID, Products.Name Name, InventoryOrderProduct.OrderQuantity OrderQuantity, Store.StoreID FROM InventoryOrder INNER JOIN InventoryOrderProduct On InventoryOrder.InventoryOrderID = InventoryOrderProduct.InventoryOrderID INNER JOIN Products On InventoryOrderProduct.ProductID = Products.ProductID INNER JOIN Warehouse On InventoryOrder.WarehouseID = Warehouse.WarehouseID INNER JOIN WarehouseProduct On Warehouse.WarehouseID = WarehouseProduct.WarehouseID INNER JOIN Store On InventoryOrder.StoreID = Store.StoreID WHERE InventoryOrder.InventoryOrderID = '" & OrderID & "' AND Products.ProductID = WarehouseProduct.ProductID;"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                SDA.SelectCommand = COMMAND
                SDA.Fill(dbDataSet)
                bSource.DataSource = dbDataSet
                dgv_Inventory.DataSource = bSource

                Try
                    dgv_Inventory.Columns.Remove("Order Quantity")
                    dejaVu = 1 
                Catch ex As Exception

                End Try


                SDA.Update(dbDataSet)

                MysqlConn.Close()



            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try
        Else
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "SELECT Warehouse.WarehouseID WarehouseID, Warehouse.Name WarehouseName, Products.ProductID ProductID, Products.Name Product, WarehouseProduct.CountOnHand Quantity FROM Warehouse INNER JOIN WarehouseProduct On WarehouseProduct.WarehouseID = Warehouse.WarehouseID INNER JOIN Products ON Products.ProductID = WarehouseProduct.ProductID WHERE Warehouse.WarehouseID = '" & WarehouseID & "';"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                SDA.SelectCommand = COMMAND
                SDA.Fill(dbDataSet)
                bSource.DataSource = dbDataSet
                dgv_Inventory.DataSource = bSource

                Dim orderColumn As New DataGridViewColumn()
                orderColumn.Name = "Order Quantity"
                orderColumn.HeaderText = "Order Quantity"
                orderColumn.CellTemplate = New DataGridViewTextBoxCell()

                If Not dejaVu = 0 Then
                    dejaVu = dejaVu - 1
                    dgv_Inventory.Columns.Insert(1, orderColumn)
                End If

                dgv_Inventory.Columns("ProductID").Visible = False
                dgv_Inventory.Columns("WarehouseID").Visible = False
                dgv_Inventory.Columns("WarehouseName").Visible = False

                dgv_Inventory.Columns("ProductID").ReadOnly = True
                dgv_Inventory.Columns("WarehouseID").ReadOnly = True
                dgv_Inventory.Columns("WarehouseName").ReadOnly = True
                dgv_Inventory.Columns("Order Quantity").ReadOnly = False
                dgv_Inventory.Columns("Product").ReadOnly = True
                dgv_Inventory.Columns("Quantity").ReadOnly = True


                SDA.Update(dbDataSet)

                MysqlConn.Close()



            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try
        End If

    End Sub
    Dim dejaVu As Int32 = 1
    Private Sub placeOrderBtn_Click(sender As Object, e As EventArgs) Handles placeOrderBtn.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim READER As MySqlDataReader
        CurrentDateLbl.Text.Replace("'", "")
        CurrentDateLbl.Text.Replace("""", "")

        Try
            MysqlConn.Open()
            Dim query As String
            query = "select max(InventoryOrder.InventoryOrderID) from mydb.InventoryOrder"
            COMMAND = New MySqlCommand(query, MysqlConn)
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
            query = "select max(InventoryOrder.InventoryOrderID) from mydb.InventoryOrder"
            COMMAND = New MySqlCommand(query, MysqlConn)
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


            query = "insert into mydb.InventoryOrder (InventoryOrderID, EmployeeID, StoreID, WarehouseID, DateOfOrder, InventoryOrderState) values ('" & InventoryOrderID & "','" & User.EmployeeID & "', '" & StoreID & "', '" & WarehouseID & "', '" & CurrentDateLbl.Text & "', '0')"
            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader

            MysqlConn.Close()
            MysqlConn.Open()

            query = "select MAX(InventoryOrder.InventoryOrderID) from mydb.InventoryOrder"
            COMMAND = New MySqlCommand(query, MysqlConn)
            InventoryOrderID = COMMAND.ExecuteScalar

            MysqlConn.Close()

            For Each row As DataGridViewRow In dgv_Inventory.Rows
                If Not row.Cells("Order Quantity").Value Is Nothing AndAlso Not row.Cells("Order Quantity").Value Is DBNull.Value Then
                    MysqlConn.Open()
                    query = "insert into mydb.InventoryOrderProduct (InventoryOrderProductID, InventoryOrderID, ProductID, OrderQuantity) values ('" & InventoryOrderProductID & "','" & InventoryOrderID & "', '" & row.Cells("ProductID").Value & "', '" & row.Cells("Order Quantity").Value & "')"
                    COMMAND = New MySqlCommand(query, MysqlConn)
                    READER = COMMAND.ExecuteReader
                    MysqlConn.Close()
                    InventoryOrderProductID += 1
                End If
            Next



            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try

    End Sub

    Private Sub ApprovalBtn_Click(sender As Object, e As EventArgs) Handles ApprovalBtn.Click
        If dgv_Warehouse.CurrentCell Is Nothing Then
            Return
        Else
            InventoryOrderID = CInt(dgv_Warehouse.CurrentRow.Cells(0).Value)
        End If

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim READER As MySqlDataReader

        Try
            MysqlConn.Open()
            Dim query As String


            query = "UPDATE InventoryOrder SET InventoryOrderState = 1 WHERE InventoryOrderID = '" & InventoryOrderID & "'"
            MessageBox.Show(query)

            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader

            MysqlConn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
        load_Warehouse()
        load_inventory()
    End Sub
    Private Sub ShipOrderBtn_Click(sender As Object, e As EventArgs) Handles ShipOrderBtn.Click
        If dgv_Warehouse.CurrentCell Is Nothing Then
            Return
        Else
            InventoryOrderID = CInt(dgv_Warehouse.CurrentRow.Cells(0).Value)
        End If

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim READER As MySqlDataReader

        Try
            MysqlConn.Open()
            Dim query As String


            query = "UPDATE InventoryOrder SET InventoryOrderState = 2 WHERE InventoryOrderID = '" & InventoryOrderID & "'"
            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader

            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
        load_Warehouse()
        load_inventory()
    End Sub

    Private Sub OrderReciviedBtn_Click(sender As Object, e As EventArgs) Handles OrderReciviedBtn.Click
        Dim StoreID As Integer
        Dim ProductID As Integer
        Dim StoreProductID As Integer
        Dim CountOnHand As Integer
        Dim Quantity As Integer

        If dgv_Warehouse.CurrentCell Is Nothing Then
            Return
        Else
            InventoryOrderID = CInt(dgv_Warehouse.CurrentRow.Cells(0).Value)
        End If

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim READER As MySqlDataReader



        Try
            MysqlConn.Open()
            Dim query As String


            query = "UPDATE InventoryOrder SET InventoryOrderState = 3 WHERE InventoryOrderID = '" & InventoryOrderID & "'"
            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader

            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try

        Dim counter As Integer
        counter = 1

        For Each row As DataGridViewRow In dgv_Inventory.Rows
            InventoryID = CInt(dgv_Inventory.Rows(counter - 1).Cells(0).Value)
            CountOnHand = 0
            Try
                MysqlConn.Open()
                Dim query As String

                query = "SELECT Products.ProductID ProductID, Products.Name Name, InventoryOrderProduct.OrderQuantity OrderQuantity, Store.StoreID FROM InventoryOrder INNER JOIN InventoryOrderProduct On InventoryOrder.InventoryOrderID = InventoryOrderProduct.InventoryOrderID INNER JOIN Products On InventoryOrderProduct.ProductID = Products.ProductID INNER JOIN Store On InventoryOrder.StoreID = Store.StoreID WHERE InventoryOrder.InventoryOrderID = '" & OrderID & "' AND Products.ProductID = '" & InventoryID & "';"
                MessageBox.Show(query)
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                While READER.Read
                    ProductID = READER(0)
                    Quantity = READER(2)
                    StoreID = READER(3)
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

                ' josh
                query = "Select * from StoreProduct where ProductID = '" & ProductID & "' and StoreID = '" & StoreID & "'"
                COMMAND = New MySqlCommand(query, MysqlConn)
                READER = COMMAND.ExecuteReader

                While READER.Read
                    CountOnHand = READER(3)
                End While

                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            CountOnHand += Quantity

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
                Dim Query As String
                Query = "insert into StoreProduct values ('" & StoreProductID & "', '" & StoreID & "', '" & ProductID & "', '" & CountOnHand & "');"
                MessageBox.Show(Query)
                COMMAND = New MySqlCommand(Query, MysqlConn)
                READER = COMMAND.ExecuteReader
                MysqlConn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try

            counter += 1
        Next









        'Try (IDK why this try-block is here - Josh)
        '    MysqlConn.Open()
        '    Dim query As String


        '    query = "SELECT * FROM StoreProduct WHERE StoreProduct.StoreProductID = '" & InventoryOrderID & "' AND StoreProduct.StoreID = InventoryOrder.StoreID'"
        '    COMMAND = New MySqlCommand(query, MysqlConn)
        '    READER = COMMAND.ExecuteReader

        '    MysqlConn.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'Finally
        '    MysqlConn.Dispose()
        'End Try
        load_Warehouse()
        load_inventory()
    End Sub
    Private Sub deleteOrderBtn_Click(sender As Object, e As EventArgs) Handles deleteOrderBtn.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim READER As MySqlDataReader
        Dim query As String

        If dgv_Warehouse.CurrentRow Is Nothing Then
            MysqlConn.Open()

            query = "select Min(InventoryOrder.InventoryOrderID) from mydb.InventoryOrder"
            COMMAND = New MySqlCommand(query, MysqlConn)
            InventoryOrderID = COMMAND.ExecuteScalar

            MysqlConn.Close()
        Else
            InventoryOrderID = dgv_Warehouse.CurrentRow.Cells(0).Value
        End If



        Try
            MysqlConn.Open()



            query = "DELETE FROM InventoryOrderProduct WHERE InventoryOrderID = '" & InventoryOrderID & "'"
            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader

            MysqlConn.Close()
            MysqlConn.Open()

            query = "DELETE FROM InventoryOrder WHERE InventoryOrderID = '" & InventoryOrderID & "'"
            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader

            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
        load_Warehouse()
        load_inventory()

    End Sub
    Private Sub cmb_Order_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Order.SelectedIndexChanged
        Dim SelectedItem As String
        SelectedItem = cmb_Order.SelectedItem


        load_Warehouse()
        load_inventory()
        'dgv_Warehouse.Rows(0).Selected = True
    End Sub


End Class