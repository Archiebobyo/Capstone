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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btn_Insert = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_StoreID = New System.Windows.Forms.TextBox()
        Me.tb_StoreName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_StoreAddress = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lb_EmployeeRep = New System.Windows.Forms.ListBox()
        Me.btn_Update = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_LoadData
        '
        Me.btn_LoadData.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_LoadData.Location = New System.Drawing.Point(714, 399)
        Me.btn_LoadData.Name = "btn_LoadData"
        Me.btn_LoadData.Size = New System.Drawing.Size(157, 41)
        Me.btn_LoadData.TabIndex = 0
        Me.btn_LoadData.Text = "Refresh"
        Me.btn_LoadData.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeight = 30
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(353, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.DataGridView1.Size = New System.Drawing.Size(791, 381)
        Me.DataGridView1.TabIndex = 1
        '
        'btn_Insert
        '
        Me.btn_Insert.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Insert.Location = New System.Drawing.Point(12, 266)
        Me.btn_Insert.Name = "btn_Insert"
        Me.btn_Insert.Size = New System.Drawing.Size(157, 41)
        Me.btn_Insert.TabIndex = 2
        Me.btn_Insert.Text = "Insert"
        Me.btn_Insert.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Store ID:"
        '
        'tb_StoreID
        '
        Me.tb_StoreID.Enabled = False
        Me.tb_StoreID.Location = New System.Drawing.Point(136, 39)
        Me.tb_StoreID.Name = "tb_StoreID"
        Me.tb_StoreID.Size = New System.Drawing.Size(47, 20)
        Me.tb_StoreID.TabIndex = 4
        '
        'tb_StoreName
        '
        Me.tb_StoreName.Location = New System.Drawing.Point(136, 72)
        Me.tb_StoreName.Name = "tb_StoreName"
        Me.tb_StoreName.Size = New System.Drawing.Size(193, 20)
        Me.tb_StoreName.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Store Name:"
        '
        'tb_StoreAddress
        '
        Me.tb_StoreAddress.Location = New System.Drawing.Point(136, 110)
        Me.tb_StoreAddress.Name = "tb_StoreAddress"
        Me.tb_StoreAddress.Size = New System.Drawing.Size(193, 20)
        Me.tb_StoreAddress.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Address:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Employee Rep.:"
        '
        'lb_EmployeeRep
        '
        Me.lb_EmployeeRep.FormattingEnabled = True
        Me.lb_EmployeeRep.Location = New System.Drawing.Point(153, 152)
        Me.lb_EmployeeRep.Name = "lb_EmployeeRep"
        Me.lb_EmployeeRep.Size = New System.Drawing.Size(153, 95)
        Me.lb_EmployeeRep.TabIndex = 10
        '
        'btn_Update
        '
        Me.btn_Update.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Update.Location = New System.Drawing.Point(190, 266)
        Me.btn_Update.Name = "btn_Update"
        Me.btn_Update.Size = New System.Drawing.Size(157, 41)
        Me.btn_Update.TabIndex = 11
        Me.btn_Update.Text = "Update"
        Me.btn_Update.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(190, 313)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(157, 41)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Delete"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'currentInventoryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1165, 519)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_Update)
        Me.Controls.Add(Me.lb_EmployeeRep)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tb_StoreAddress)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tb_StoreName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tb_StoreID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Insert)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btn_LoadData)
        Me.Name = "currentInventoryForm"
        Me.Text = "currentInventoryForm"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_LoadData As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btn_Insert As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents tb_StoreID As TextBox
    Friend WithEvents tb_StoreName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tb_StoreAddress As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lb_EmployeeRep As ListBox
    Friend WithEvents btn_Update As Button
    Friend WithEvents Button1 As Button
End Class
