<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryOrderForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgv_Warehouse = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgv_Inventory = New System.Windows.Forms.DataGridView()
        Me.placeOrderBtn = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CurrentDateLbl = New System.Windows.Forms.Label()
        Me.CurrentStoreNameLbl = New System.Windows.Forms.Label()
        Me.CurrentWarehouseNameLbl = New System.Windows.Forms.Label()
        Me.ApprovalBtn = New System.Windows.Forms.Button()
        Me.OrderReciviedBtn = New System.Windows.Forms.Button()
        Me.ShipOrderBtn = New System.Windows.Forms.Button()
        Me.cmb_Order = New System.Windows.Forms.ComboBox()
        Me.deleteOrderBtn = New System.Windows.Forms.Button()
        CType(Me.dgv_Warehouse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Inventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_Warehouse
        '
        Me.dgv_Warehouse.AllowUserToAddRows = False
        Me.dgv_Warehouse.AllowUserToDeleteRows = False
        Me.dgv_Warehouse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_Warehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Warehouse.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgv_Warehouse.Location = New System.Drawing.Point(8, 481)
        Me.dgv_Warehouse.Name = "dgv_Warehouse"
        Me.dgv_Warehouse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Warehouse.Size = New System.Drawing.Size(465, 150)
        Me.dgv_Warehouse.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 20)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Store Name:"
        '
        'dgv_Inventory
        '
        Me.dgv_Inventory.AllowUserToAddRows = False
        Me.dgv_Inventory.AllowUserToDeleteRows = False
        Me.dgv_Inventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_Inventory.ColumnHeadersHeight = 30
        Me.dgv_Inventory.EnableHeadersVisualStyles = False
        Me.dgv_Inventory.Location = New System.Drawing.Point(349, 19)
        Me.dgv_Inventory.Name = "dgv_Inventory"
        Me.dgv_Inventory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dgv_Inventory.Size = New System.Drawing.Size(516, 407)
        Me.dgv_Inventory.TabIndex = 15
        '
        'placeOrderBtn
        '
        Me.placeOrderBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.placeOrderBtn.Location = New System.Drawing.Point(479, 430)
        Me.placeOrderBtn.Name = "placeOrderBtn"
        Me.placeOrderBtn.Size = New System.Drawing.Size(169, 75)
        Me.placeOrderBtn.TabIndex = 14
        Me.placeOrderBtn.Text = "Save Order"
        Me.placeOrderBtn.UseVisualStyleBackColor = True
        Me.placeOrderBtn.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(156, 20)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Warehouse Name:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(4, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 20)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Date of Order:"
        '
        'CurrentDateLbl
        '
        Me.CurrentDateLbl.AutoSize = True
        Me.CurrentDateLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentDateLbl.Location = New System.Drawing.Point(134, 88)
        Me.CurrentDateLbl.Name = "CurrentDateLbl"
        Me.CurrentDateLbl.Size = New System.Drawing.Size(108, 20)
        Me.CurrentDateLbl.TabIndex = 33
        Me.CurrentDateLbl.Text = "CurrentDate"
        '
        'CurrentStoreNameLbl
        '
        Me.CurrentStoreNameLbl.AutoSize = True
        Me.CurrentStoreNameLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentStoreNameLbl.Location = New System.Drawing.Point(166, 20)
        Me.CurrentStoreNameLbl.Name = "CurrentStoreNameLbl"
        Me.CurrentStoreNameLbl.Size = New System.Drawing.Size(19, 20)
        Me.CurrentStoreNameLbl.TabIndex = 36
        Me.CurrentStoreNameLbl.Text = "0"
        '
        'CurrentWarehouseNameLbl
        '
        Me.CurrentWarehouseNameLbl.AutoSize = True
        Me.CurrentWarehouseNameLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentWarehouseNameLbl.Location = New System.Drawing.Point(166, 46)
        Me.CurrentWarehouseNameLbl.Name = "CurrentWarehouseNameLbl"
        Me.CurrentWarehouseNameLbl.Size = New System.Drawing.Size(19, 20)
        Me.CurrentWarehouseNameLbl.TabIndex = 37
        Me.CurrentWarehouseNameLbl.Text = "0"
        '
        'ApprovalBtn
        '
        Me.ApprovalBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApprovalBtn.Location = New System.Drawing.Point(479, 511)
        Me.ApprovalBtn.Name = "ApprovalBtn"
        Me.ApprovalBtn.Size = New System.Drawing.Size(169, 75)
        Me.ApprovalBtn.TabIndex = 38
        Me.ApprovalBtn.Text = "Approve Order"
        Me.ApprovalBtn.UseVisualStyleBackColor = True
        Me.ApprovalBtn.Visible = False
        '
        'OrderReciviedBtn
        '
        Me.OrderReciviedBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OrderReciviedBtn.Location = New System.Drawing.Point(696, 511)
        Me.OrderReciviedBtn.Name = "OrderReciviedBtn"
        Me.OrderReciviedBtn.Size = New System.Drawing.Size(169, 75)
        Me.OrderReciviedBtn.TabIndex = 39
        Me.OrderReciviedBtn.Text = "Order Recivied"
        Me.OrderReciviedBtn.UseVisualStyleBackColor = True
        Me.OrderReciviedBtn.Visible = False
        '
        'ShipOrderBtn
        '
        Me.ShipOrderBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShipOrderBtn.Location = New System.Drawing.Point(696, 430)
        Me.ShipOrderBtn.Name = "ShipOrderBtn"
        Me.ShipOrderBtn.Size = New System.Drawing.Size(169, 75)
        Me.ShipOrderBtn.TabIndex = 40
        Me.ShipOrderBtn.Text = "Ship Order"
        Me.ShipOrderBtn.UseVisualStyleBackColor = True
        Me.ShipOrderBtn.Visible = False
        '
        'cmb_Order
        '
        Me.cmb_Order.FormattingEnabled = True
        Me.cmb_Order.Location = New System.Drawing.Point(8, 120)
        Me.cmb_Order.Name = "cmb_Order"
        Me.cmb_Order.Size = New System.Drawing.Size(121, 21)
        Me.cmb_Order.TabIndex = 41
        Me.cmb_Order.Visible = False
        '
        'deleteOrderBtn
        '
        Me.deleteOrderBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deleteOrderBtn.Location = New System.Drawing.Point(174, 351)
        Me.deleteOrderBtn.Name = "deleteOrderBtn"
        Me.deleteOrderBtn.Size = New System.Drawing.Size(169, 75)
        Me.deleteOrderBtn.TabIndex = 42
        Me.deleteOrderBtn.Text = "Delete Order"
        Me.deleteOrderBtn.UseVisualStyleBackColor = True
        Me.deleteOrderBtn.Visible = False
        '
        'InventoryOrderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(879, 650)
        Me.Controls.Add(Me.deleteOrderBtn)
        Me.Controls.Add(Me.cmb_Order)
        Me.Controls.Add(Me.ShipOrderBtn)
        Me.Controls.Add(Me.OrderReciviedBtn)
        Me.Controls.Add(Me.ApprovalBtn)
        Me.Controls.Add(Me.CurrentWarehouseNameLbl)
        Me.Controls.Add(Me.CurrentStoreNameLbl)
        Me.Controls.Add(Me.CurrentDateLbl)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgv_Warehouse)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgv_Inventory)
        Me.Controls.Add(Me.placeOrderBtn)
        Me.Name = "InventoryOrderForm"
        Me.Text = "InventoryOrderForm"
        CType(Me.dgv_Warehouse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Inventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv_Warehouse As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents dgv_Inventory As DataGridView
    Friend WithEvents placeOrderBtn As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CurrentDateLbl As Label
    Friend WithEvents CurrentStoreNameLbl As Label
    Friend WithEvents CurrentWarehouseNameLbl As Label
    Friend WithEvents ApprovalBtn As Button
    Friend WithEvents OrderReciviedBtn As Button
    Friend WithEvents ShipOrderBtn As Button
    Friend WithEvents cmb_Order As ComboBox
    Friend WithEvents deleteOrderBtn As Button
End Class
