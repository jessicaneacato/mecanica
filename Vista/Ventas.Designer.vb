<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ventas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnModificar = New System.Windows.Forms.Button
        Me.cbxCliente = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.btnLimpiar = New System.Windows.Forms.Button
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.txtFecha = New System.Windows.Forms.TextBox
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.txtNumero = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvVentas = New System.Windows.Forms.DataGridView
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.txtBuscar = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnSalir = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnModificar)
        Me.GroupBox1.Controls.Add(Me.cbxCliente)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.btnLimpiar)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Controls.Add(Me.txtFecha)
        Me.GroupBox1.Controls.Add(Me.txtTotal)
        Me.GroupBox1.Controls.Add(Me.txtNumero)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(715, 139)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Venta"
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(499, 89)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(95, 33)
        Me.btnModificar.TabIndex = 14
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'cbxCliente
        '
        Me.cbxCliente.Enabled = False
        Me.cbxCliente.FormattingEnabled = True
        Me.cbxCliente.Location = New System.Drawing.Point(113, 57)
        Me.cbxCliente.Name = "cbxCliente"
        Me.cbxCliente.Size = New System.Drawing.Size(335, 26)
        Me.cbxCliente.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 18)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Cliente"
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(297, 89)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(95, 33)
        Me.btnEliminar.TabIndex = 11
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(398, 89)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(95, 33)
        Me.btnLimpiar.TabIndex = 10
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(600, 89)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(95, 33)
        Me.btnNuevo.TabIndex = 9
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(557, 55)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(138, 26)
        Me.txtFecha.TabIndex = 8
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(557, 23)
        Me.txtTotal.MaxLength = 10
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(138, 26)
        Me.txtTotal.TabIndex = 6
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(113, 25)
        Me.txtNumero.MaxLength = 100
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(242, 26)
        Me.txtNumero.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(496, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 18)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Fecha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(496, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 18)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Total"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Número"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvVentas)
        Me.GroupBox2.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 197)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(718, 377)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lista Ventas"
        '
        'dgvVentas
        '
        Me.dgvVentas.AllowUserToAddRows = False
        Me.dgvVentas.AllowUserToDeleteRows = False
        Me.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVentas.Location = New System.Drawing.Point(20, 25)
        Me.dgvVentas.MultiSelect = False
        Me.dgvVentas.Name = "dgvVentas"
        Me.dgvVentas.ReadOnly = True
        Me.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVentas.Size = New System.Drawing.Size(675, 332)
        Me.dgvVentas.TabIndex = 3
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(534, 162)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(95, 26)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(177, 162)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(351, 26)
        Me.txtBuscar.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 18)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Ventas a buscar"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(635, 162)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(95, 26)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Ventas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 586)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Ventas"
        Me.Text = "Ventas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgvVentas As System.Windows.Forms.DataGridView
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents cbxCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnModificar As System.Windows.Forms.Button
End Class
