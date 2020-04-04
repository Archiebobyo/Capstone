<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenuForm
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
        Me.currentInventoryBtn = New System.Windows.Forms.Button()
        Me.orderFormBtn = New System.Windows.Forms.Button()
        Me.customerOrderBtn = New System.Windows.Forms.Button()
        Me.logoutBtn = New System.Windows.Forms.Button()
        Me.adminBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'currentInventoryBtn
        '
        Me.currentInventoryBtn.Location = New System.Drawing.Point(105, 12)
        Me.currentInventoryBtn.Name = "currentInventoryBtn"
        Me.currentInventoryBtn.Size = New System.Drawing.Size(95, 39)
        Me.currentInventoryBtn.TabIndex = 0
        Me.currentInventoryBtn.Text = "Display Current Inventory"
        Me.currentInventoryBtn.UseVisualStyleBackColor = True
        '
        'orderFormBtn
        '
        Me.orderFormBtn.Location = New System.Drawing.Point(105, 73)
        Me.orderFormBtn.Name = "orderFormBtn"
        Me.orderFormBtn.Size = New System.Drawing.Size(95, 51)
        Me.orderFormBtn.TabIndex = 1
        Me.orderFormBtn.Text = "Order Inventory From Warehouse"
        Me.orderFormBtn.UseVisualStyleBackColor = True
        '
        'customerOrderBtn
        '
        Me.customerOrderBtn.Location = New System.Drawing.Point(105, 145)
        Me.customerOrderBtn.Name = "customerOrderBtn"
        Me.customerOrderBtn.Size = New System.Drawing.Size(95, 39)
        Me.customerOrderBtn.TabIndex = 2
        Me.customerOrderBtn.Text = "Create Customer Order"
        Me.customerOrderBtn.UseVisualStyleBackColor = True
        '
        'logoutBtn
        '
        Me.logoutBtn.Location = New System.Drawing.Point(105, 203)
        Me.logoutBtn.Name = "logoutBtn"
        Me.logoutBtn.Size = New System.Drawing.Size(95, 23)
        Me.logoutBtn.TabIndex = 3
        Me.logoutBtn.Text = "Logout"
        Me.logoutBtn.UseVisualStyleBackColor = True
        '
        'adminBtn
        '
        Me.adminBtn.Location = New System.Drawing.Point(12, 12)
        Me.adminBtn.Name = "adminBtn"
        Me.adminBtn.Size = New System.Drawing.Size(67, 39)
        Me.adminBtn.TabIndex = 4
        Me.adminBtn.Text = "Admin Control"
        Me.adminBtn.UseVisualStyleBackColor = True
        '
        'MainMenuForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 238)
        Me.Controls.Add(Me.adminBtn)
        Me.Controls.Add(Me.logoutBtn)
        Me.Controls.Add(Me.customerOrderBtn)
        Me.Controls.Add(Me.orderFormBtn)
        Me.Controls.Add(Me.currentInventoryBtn)
        Me.Name = "MainMenuForm"
        Me.Text = "Main Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents currentInventoryBtn As Button
    Friend WithEvents orderFormBtn As Button
    Friend WithEvents customerOrderBtn As Button
    Friend WithEvents logoutBtn As Button
    Friend WithEvents adminBtn As Button
End Class
