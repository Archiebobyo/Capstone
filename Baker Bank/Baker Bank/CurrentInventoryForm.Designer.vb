<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class currentInventoryForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btn_LoadData = New System.Windows.Forms.Button()
        Me.dgv_Stores = New System.Windows.Forms.DataGridView()
        Me.btn_Insert = New System.Windows.Forms.Button()
        Me.field1 = New System.Windows.Forms.Label()
        Me.input1 = New System.Windows.Forms.TextBox()
        Me.input2 = New System.Windows.Forms.TextBox()
        Me.field2 = New System.Windows.Forms.Label()
        Me.input3 = New System.Windows.Forms.TextBox()
        Me.field3 = New System.Windows.Forms.Label()
        Me.field_cmb = New System.Windows.Forms.Label()
        Me.btn_Update = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgv_Inventory = New System.Windows.Forms.DataGridView()
        Me.cmb_Table = New System.Windows.Forms.ComboBox()
        Me.lb_EmployeeRep = New System.Windows.Forms.ComboBox()
        Me.field4 = New System.Windows.Forms.Label()
        Me.field5 = New System.Windows.Forms.Label()
        Me.field6 = New System.Windows.Forms.Label()
        Me.field7 = New System.Windows.Forms.Label()
        Me.field8 = New System.Windows.Forms.Label()
        Me.input4 = New System.Windows.Forms.TextBox()
        Me.input5 = New System.Windows.Forms.TextBox()
        Me.input6 = New System.Windows.Forms.TextBox()
        Me.input7 = New System.Windows.Forms.TextBox()
        Me.input8 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.field9 = New System.Windows.Forms.Label()
        Me.input9 = New System.Windows.Forms.TextBox()
        Me.input10 = New System.Windows.Forms.TextBox()
        Me.field10 = New System.Windows.Forms.Label()
        Me.PlaceOrderBtn = New System.Windows.Forms.Button()
        CType(Me.dgv_Stores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Inventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_LoadData
        '
        Me.btn_LoadData.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_LoadData.Location = New System.Drawing.Point(172, 417)
        Me.btn_LoadData.Name = "btn_LoadData"
        Me.btn_LoadData.Size = New System.Drawing.Size(157, 41)
        Me.btn_LoadData.TabIndex = 13
        Me.btn_LoadData.Text = "Refresh"
        Me.btn_LoadData.UseVisualStyleBackColor = True
        '
        'dgv_Stores
        '
        Me.dgv_Stores.AllowUserToAddRows = False
        Me.dgv_Stores.AllowUserToDeleteRows = False
        Me.dgv_Stores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_Stores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_Stores.ColumnHeadersHeight = 30
        Me.dgv_Stores.EnableHeadersVisualStyles = False
        Me.dgv_Stores.Location = New System.Drawing.Point(12, 464)
        Me.dgv_Stores.Name = "dgv_Stores"
        Me.dgv_Stores.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dgv_Stores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Stores.Size = New System.Drawing.Size(600, 185)
        Me.dgv_Stores.TabIndex = 14
        '
        'btn_Insert
        '
        Me.btn_Insert.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Insert.Location = New System.Drawing.Point(9, 370)
        Me.btn_Insert.Name = "btn_Insert"
        Me.btn_Insert.Size = New System.Drawing.Size(157, 41)
        Me.btn_Insert.TabIndex = 10
        Me.btn_Insert.Text = "Insert"
        Me.btn_Insert.UseVisualStyleBackColor = True
        '
        'field1
        '
        Me.field1.AutoSize = True
        Me.field1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.field1.Location = New System.Drawing.Point(12, 37)
        Me.field1.Name = "field1"
        Me.field1.Size = New System.Drawing.Size(82, 20)
        Me.field1.TabIndex = 3
        Me.field1.Text = "Store ID:"
        '
        'input1
        '
        Me.input1.Enabled = False
        Me.input1.Location = New System.Drawing.Point(201, 37)
        Me.input1.Name = "input1"
        Me.input1.Size = New System.Drawing.Size(47, 20)
        Me.input1.TabIndex = 1
        '
        'input2
        '
        Me.input2.Location = New System.Drawing.Point(201, 74)
        Me.input2.Name = "input2"
        Me.input2.Size = New System.Drawing.Size(193, 20)
        Me.input2.TabIndex = 2
        '
        'field2
        '
        Me.field2.AutoSize = True
        Me.field2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.field2.Location = New System.Drawing.Point(12, 72)
        Me.field2.Name = "field2"
        Me.field2.Size = New System.Drawing.Size(109, 20)
        Me.field2.TabIndex = 5
        Me.field2.Text = "Store Name:"
        '
        'input3
        '
        Me.input3.Location = New System.Drawing.Point(201, 112)
        Me.input3.Name = "input3"
        Me.input3.Size = New System.Drawing.Size(193, 20)
        Me.input3.TabIndex = 3
        '
        'field3
        '
        Me.field3.AutoSize = True
        Me.field3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.field3.Location = New System.Drawing.Point(12, 110)
        Me.field3.Name = "field3"
        Me.field3.Size = New System.Drawing.Size(80, 20)
        Me.field3.TabIndex = 7
        Me.field3.Text = "Address:"
        '
        'field_cmb
        '
        Me.field_cmb.AutoSize = True
        Me.field_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.field_cmb.Location = New System.Drawing.Point(14, 325)
        Me.field_cmb.Name = "field_cmb"
        Me.field_cmb.Size = New System.Drawing.Size(135, 20)
        Me.field_cmb.TabIndex = 9
        Me.field_cmb.Text = "Employee Rep.:"
        '
        'btn_Update
        '
        Me.btn_Update.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Update.Location = New System.Drawing.Point(9, 417)
        Me.btn_Update.Name = "btn_Update"
        Me.btn_Update.Size = New System.Drawing.Size(157, 41)
        Me.btn_Update.TabIndex = 12
        Me.btn_Update.Text = "Update"
        Me.btn_Update.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(172, 370)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(157, 41)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Delete"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgv_Inventory
        '
        Me.dgv_Inventory.AllowUserToAddRows = False
        Me.dgv_Inventory.AllowUserToDeleteRows = False
        Me.dgv_Inventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_Inventory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_Inventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Inventory.Location = New System.Drawing.Point(635, 22)
        Me.dgv_Inventory.Name = "dgv_Inventory"
        Me.dgv_Inventory.Size = New System.Drawing.Size(632, 267)
        Me.dgv_Inventory.TabIndex = 15
        '
        'cmb_Table
        '
        Me.cmb_Table.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Table.FormattingEnabled = True
        Me.cmb_Table.Location = New System.Drawing.Point(12, 12)
        Me.cmb_Table.Name = "cmb_Table"
        Me.cmb_Table.Size = New System.Drawing.Size(121, 21)
        Me.cmb_Table.TabIndex = 0
        '
        'lb_EmployeeRep
        '
        Me.lb_EmployeeRep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lb_EmployeeRep.FormattingEnabled = True
        Me.lb_EmployeeRep.Items.AddRange(New Object() {"Employee", "InventoryOrder", "InventoryOrderProduct", "Products", "Store", "StoreProduct", "Warehouse", "WarehouseProduct"})
        Me.lb_EmployeeRep.Location = New System.Drawing.Point(201, 327)
        Me.lb_EmployeeRep.Name = "lb_EmployeeRep"
        Me.lb_EmployeeRep.Size = New System.Drawing.Size(121, 21)
        Me.lb_EmployeeRep.TabIndex = 9
        '
        'field4
        '
        Me.field4.AutoSize = True
        Me.field4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.field4.Location = New System.Drawing.Point(14, 144)
        Me.field4.Name = "field4"
        Me.field4.Size = New System.Drawing.Size(0, 20)
        Me.field4.TabIndex = 18
        '
        'field5
        '
        Me.field5.AutoSize = True
        Me.field5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.field5.Location = New System.Drawing.Point(12, 181)
        Me.field5.Name = "field5"
        Me.field5.Size = New System.Drawing.Size(0, 20)
        Me.field5.TabIndex = 19
        '
        'field6
        '
        Me.field6.AutoSize = True
        Me.field6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.field6.Location = New System.Drawing.Point(12, 215)
        Me.field6.Name = "field6"
        Me.field6.Size = New System.Drawing.Size(0, 20)
        Me.field6.TabIndex = 20
        '
        'field7
        '
        Me.field7.AutoSize = True
        Me.field7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.field7.Location = New System.Drawing.Point(14, 250)
        Me.field7.Name = "field7"
        Me.field7.Size = New System.Drawing.Size(0, 20)
        Me.field7.TabIndex = 21
        '
        'field8
        '
        Me.field8.AutoSize = True
        Me.field8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.field8.Location = New System.Drawing.Point(14, 288)
        Me.field8.Name = "field8"
        Me.field8.Size = New System.Drawing.Size(0, 20)
        Me.field8.TabIndex = 22
        '
        'input4
        '
        Me.input4.Location = New System.Drawing.Point(201, 148)
        Me.input4.Name = "input4"
        Me.input4.Size = New System.Drawing.Size(193, 20)
        Me.input4.TabIndex = 4
        Me.input4.Visible = False
        '
        'input5
        '
        Me.input5.Location = New System.Drawing.Point(201, 183)
        Me.input5.Name = "input5"
        Me.input5.Size = New System.Drawing.Size(193, 20)
        Me.input5.TabIndex = 5
        Me.input5.Visible = False
        '
        'input6
        '
        Me.input6.Location = New System.Drawing.Point(201, 219)
        Me.input6.Name = "input6"
        Me.input6.Size = New System.Drawing.Size(193, 20)
        Me.input6.TabIndex = 6
        Me.input6.Visible = False
        '
        'input7
        '
        Me.input7.Location = New System.Drawing.Point(201, 254)
        Me.input7.Name = "input7"
        Me.input7.Size = New System.Drawing.Size(193, 20)
        Me.input7.TabIndex = 7
        Me.input7.Visible = False
        '
        'input8
        '
        Me.input8.Location = New System.Drawing.Point(201, 290)
        Me.input8.Name = "input8"
        Me.input8.Size = New System.Drawing.Size(193, 20)
        Me.input8.TabIndex = 8
        Me.input8.Visible = False
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(250, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(157, 41)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Save Changes"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Location = New System.Drawing.Point(635, 311)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(632, 338)
        Me.Panel1.TabIndex = 16
        '
        'field9
        '
        Me.field9.AutoSize = True
        Me.field9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.field9.Location = New System.Drawing.Point(447, 288)
        Me.field9.Name = "field9"
        Me.field9.Size = New System.Drawing.Size(0, 20)
        Me.field9.TabIndex = 23
        '
        'input9
        '
        Me.input9.Location = New System.Drawing.Point(529, 290)
        Me.input9.Name = "input9"
        Me.input9.Size = New System.Drawing.Size(86, 20)
        Me.input9.TabIndex = 24
        Me.input9.Visible = False
        '
        'input10
        '
        Me.input10.Location = New System.Drawing.Point(529, 330)
        Me.input10.Name = "input10"
        Me.input10.Size = New System.Drawing.Size(86, 20)
        Me.input10.TabIndex = 26
        Me.input10.Visible = False
        '
        'field10
        '
        Me.field10.AutoSize = True
        Me.field10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.field10.Location = New System.Drawing.Point(447, 328)
        Me.field10.Name = "field10"
        Me.field10.Size = New System.Drawing.Size(0, 20)
        Me.field10.TabIndex = 25
        '
        'PlaceOrderBtn
        '
        Me.PlaceOrderBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlaceOrderBtn.Location = New System.Drawing.Point(489, 370)
        Me.PlaceOrderBtn.Name = "PlaceOrderBtn"
        Me.PlaceOrderBtn.Size = New System.Drawing.Size(126, 41)
        Me.PlaceOrderBtn.TabIndex = 27
        Me.PlaceOrderBtn.Text = "Orders"
        Me.PlaceOrderBtn.UseVisualStyleBackColor = True
        '
        'currentInventoryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1279, 661)
        Me.Controls.Add(Me.PlaceOrderBtn)
        Me.Controls.Add(Me.input10)
        Me.Controls.Add(Me.field10)
        Me.Controls.Add(Me.input9)
        Me.Controls.Add(Me.field9)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.input8)
        Me.Controls.Add(Me.input7)
        Me.Controls.Add(Me.input6)
        Me.Controls.Add(Me.input5)
        Me.Controls.Add(Me.input4)
        Me.Controls.Add(Me.field8)
        Me.Controls.Add(Me.field7)
        Me.Controls.Add(Me.field6)
        Me.Controls.Add(Me.field5)
        Me.Controls.Add(Me.field4)
        Me.Controls.Add(Me.lb_EmployeeRep)
        Me.Controls.Add(Me.cmb_Table)
        Me.Controls.Add(Me.dgv_Inventory)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_Update)
        Me.Controls.Add(Me.field_cmb)
        Me.Controls.Add(Me.input3)
        Me.Controls.Add(Me.field3)
        Me.Controls.Add(Me.input2)
        Me.Controls.Add(Me.field2)
        Me.Controls.Add(Me.input1)
        Me.Controls.Add(Me.field1)
        Me.Controls.Add(Me.btn_Insert)
        Me.Controls.Add(Me.dgv_Stores)
        Me.Controls.Add(Me.btn_LoadData)
        Me.Name = "currentInventoryForm"
        Me.Text = "currentInventoryForm"
        CType(Me.dgv_Stores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Inventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_LoadData As Button
    Friend WithEvents dgv_Stores As DataGridView
    Friend WithEvents btn_Insert As Button
    Friend WithEvents field1 As Label
    Friend WithEvents input1 As TextBox
    Friend WithEvents input2 As TextBox
    Friend WithEvents field2 As Label
    Friend WithEvents input3 As TextBox
    Friend WithEvents field3 As Label
    Friend WithEvents field_cmb As Label
    Friend WithEvents btn_Update As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents dgv_Inventory As DataGridView
    Friend WithEvents cmb_Table As ComboBox
    Friend WithEvents lb_EmployeeRep As ComboBox
    Friend WithEvents field4 As Label
    Friend WithEvents field5 As Label
    Friend WithEvents field6 As Label
    Friend WithEvents field7 As Label
    Friend WithEvents field8 As Label
    Friend WithEvents input4 As TextBox
    Friend WithEvents input5 As TextBox
    Friend WithEvents input6 As TextBox
    Friend WithEvents input7 As TextBox
    Friend WithEvents input8 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents field9 As Label
    Friend WithEvents input9 As TextBox
    Friend WithEvents input10 As TextBox
    Friend WithEvents field10 As Label
    Friend WithEvents PlaceOrderBtn As Button
End Class
