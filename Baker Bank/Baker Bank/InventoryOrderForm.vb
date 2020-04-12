Imports MySql.Data.MySqlClient

Public Class InventoryOrderForm
    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim WarehouseID As Integer
    Dim StoreID As Integer
    Dim InventoryOrderID As Integer
    Dim InventoryOrderProductID As Integer

    Private Sub InventoryOrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connectToDB()
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

    Private Sub dgv_Warehouse_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_Warehouse.SelectionChanged
        WarehouseID = dgv_Warehouse.CurrentCell.RowIndex

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

        load_inventory()

    End Sub

    Private Sub load_Warehouse()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource

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
    End Sub

    Private Sub load_inventory()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource
        Dim x As New Int16


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

            dgv_Inventory.Columns(0).Visible = False
            dgv_Inventory.Columns(3).Visible = False

            dgv_Inventory.Columns(0).ReadOnly = True
            dgv_Inventory.Columns(1).ReadOnly = False
            dgv_Inventory.Columns(2).ReadOnly = True
            dgv_Inventory.Columns(3).ReadOnly = True
            dgv_Inventory.Columns(4).ReadOnly = True
            dgv_Inventory.Columns(5).ReadOnly = True


            SDA.Update(dbDataSet)

            MysqlConn.Close()



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub
    Dim dejaVu As Int32 = 2
    Private Sub placeOrderBtn_Click(sender As Object, e As EventArgs) Handles placeOrderBtn.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim READER As MySqlDataReader

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


            query = "insert into mydb.InventoryOrder (InventoryOrderID, EmployeeID, StoreID, WarehouseID, DateOfOrder, ManagerApporval) values ('" & InventoryOrderID & "','" & User.EmployeeID & "', '" & StoreID & "', '" & WarehouseID & "', '" & CurrentDateLbl.Text & "', 'Pending')"
            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader

            MysqlConn.Close()
            MysqlConn.Open()

            query = "select MAX(InventoryOrder.InventoryOrderID) from mydb.InventoryOrder"
            COMMAND = New MySqlCommand(query, MysqlConn)
            InventoryOrderID = COMMAND.ExecuteScalar

            MysqlConn.Close()
            Dim x As Integer
            x = dgv_Inventory.Rows.Count - 1
            Dim y As Integer
            y = 0

            For Each row As DataGridViewRow In dgv_Inventory.Rows
                If Not row.Cells(1).Value Is Nothing AndAlso Not row.Cells(1).Value Is DBNull.Value AndAlso y <= x Then
                    MysqlConn.Open()
                    Dim ProductID As Integer
                    ProductID = row.Cells(3).Value
                    Dim OrderQuantity As Integer
                    OrderQuantity = row.Cells(1).Value
                    query = "insert into mydb.InventoryOrderProduct (InventoryOrderProductID, InventoryOrderID, ProductID, OrderQuantity) values ('" & InventoryOrderProductID & "','" & InventoryOrderID & "', '" & ProductID & "', '" & OrderQuantity & "')"
                    COMMAND = New MySqlCommand(query, MysqlConn)
                    READER = COMMAND.ExecuteReader
                    MysqlConn.Close()
                    InventoryOrderProductID += 1
                    y += 1
                End If
            Next



            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub

End Class