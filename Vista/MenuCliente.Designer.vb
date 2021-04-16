<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuCliente
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
        Me.btnClientes = New System.Windows.Forms.Button
        Me.btnReparaciones = New System.Windows.Forms.Button
        Me.btnVehiculos = New System.Windows.Forms.Button
        Me.btnCompras = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnClientes
        '
        Me.btnClientes.Font = New System.Drawing.Font("Lucida Sans", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClientes.Location = New System.Drawing.Point(78, 31)
        Me.btnClientes.Name = "btnClientes"
        Me.btnClientes.Size = New System.Drawing.Size(179, 48)
        Me.btnClientes.TabIndex = 0
        Me.btnClientes.Text = "Mis Datos"
        Me.btnClientes.UseVisualStyleBackColor = True
        '
        'btnReparaciones
        '
        Me.btnReparaciones.Font = New System.Drawing.Font("Lucida Sans", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReparaciones.Location = New System.Drawing.Point(78, 168)
        Me.btnReparaciones.Name = "btnReparaciones"
        Me.btnReparaciones.Size = New System.Drawing.Size(179, 48)
        Me.btnReparaciones.TabIndex = 4
        Me.btnReparaciones.Text = "Reparaciones"
        Me.btnReparaciones.UseVisualStyleBackColor = True
        '
        'btnVehiculos
        '
        Me.btnVehiculos.Font = New System.Drawing.Font("Lucida Sans", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVehiculos.Location = New System.Drawing.Point(78, 101)
        Me.btnVehiculos.Name = "btnVehiculos"
        Me.btnVehiculos.Size = New System.Drawing.Size(179, 48)
        Me.btnVehiculos.TabIndex = 7
        Me.btnVehiculos.Text = "Vehículos"
        Me.btnVehiculos.UseVisualStyleBackColor = True
        '
        'btnCompras
        '
        Me.btnCompras.Font = New System.Drawing.Font("Lucida Sans", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCompras.Location = New System.Drawing.Point(78, 240)
        Me.btnCompras.Name = "btnCompras"
        Me.btnCompras.Size = New System.Drawing.Size(179, 48)
        Me.btnCompras.TabIndex = 6
        Me.btnCompras.Text = "Compras"
        Me.btnCompras.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Lucida Sans", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(78, 305)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(179, 48)
        Me.btnSalir.TabIndex = 8
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'MenuCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 372)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnVehiculos)
        Me.Controls.Add(Me.btnCompras)
        Me.Controls.Add(Me.btnReparaciones)
        Me.Controls.Add(Me.btnClientes)
        Me.Name = "MenuCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Cliente"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClientes As System.Windows.Forms.Button
    Friend WithEvents btnReparaciones As System.Windows.Forms.Button
    Friend WithEvents btnVehiculos As System.Windows.Forms.Button
    Friend WithEvents btnCompras As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
End Class
