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
        Me.Label2.Location = New System.Drawing.Point(12, 19)
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
        Me.dgv_Inventory.Size = New System.Drawing.Size(887, 407)
        Me.dgv_Inventory.TabIndex = 15
        '
        'placeOrderBtn
        '
        Me.placeOrderBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.placeOrderBtn.Location = New System.Drawing.Point(729, 432)
        Me.placeOrderBtn.Name = "placeOrderBtn"
        Me.placeOrderBtn.Size = New System.Drawing.Size(169, 75)
        Me.placeOrderBtn.TabIndex = 14
        Me.placeOrderBtn.Text = "Place Your Order"
        Me.placeOrderBtn.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(156, 20)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Warehouse Name:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 20)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Date of Order:"
        '
        'CurrentDateLbl
        '
        Me.CurrentDateLbl.AutoSize = True
        Me.CurrentDateLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentDateLbl.Location = New System.Drawing.Point(142, 87)
        Me.CurrentDateLbl.Name = "CurrentDateLbl"
        Me.CurrentDateLbl.Size = New System.Drawing.Size(108, 20)
        Me.CurrentDateLbl.TabIndex = 33
        Me.CurrentDateLbl.Text = "CurrentDate"
        '
        'CurrentStoreNameLbl
        '
        Me.CurrentStoreNameLbl.AutoSize = True
        Me.CurrentStoreNameLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentStoreNameLbl.Location = New System.Drawing.Point(174, 19)
        Me.CurrentStoreNameLbl.Name = "CurrentStoreNameLbl"
        Me.CurrentStoreNameLbl.Size = New System.Drawing.Size(19, 20)
        Me.CurrentStoreNameLbl.TabIndex = 36
        Me.CurrentStoreNameLbl.Text = "0"
        '
        'CurrentWarehouseNameLbl
        '
        Me.CurrentWarehouseNameLbl.AutoSize = True
        Me.CurrentWarehouseNameLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentWarehouseNameLbl.Location = New System.Drawing.Point(174, 45)
        Me.CurrentWarehouseNameLbl.Name = "CurrentWarehouseNameLbl"
        Me.CurrentWarehouseNameLbl.Size = New System.Drawing.Size(19, 20)
        Me.CurrentWarehouseNameLbl.TabIndex = 37
        Me.CurrentWarehouseNameLbl.Text = "0"
        '
        'InventoryOrderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1245, 650)
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
End Class
