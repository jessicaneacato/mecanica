<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuEmpleado
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
        Me.btnEmpleados = New System.Windows.Forms.Button
        Me.btnServicios = New System.Windows.Forms.Button
        Me.btnProductos = New System.Windows.Forms.Button
        Me.btnVehiculos = New System.Windows.Forms.Button
        Me.btnVentas = New System.Windows.Forms.Button
        Me.btnReparaciones = New System.Windows.Forms.Button
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
        Me.btnClientes.Text = "Clientes"
        Me.btnClientes.UseVisualStyleBackColor = True
        '
        'btnEmpleados
        '
        Me.btnEmpleados.Font = New System.Drawing.Font("Lucida Sans", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleados.Location = New System.Drawing.Point(78, 95)
        Me.btnEmpleados.Name = "btnEmpleados"
        Me.btnEmpleados.Size = New System.Drawing.Size(179, 48)
        Me.btnEmpleados.TabIndex = 1
        Me.btnEmpleados.Text = "Empleados"
        Me.btnEmpleados.UseVisualStyleBackColor = True
        '
        'btnServicios
        '
        Me.btnServicios.Font = New System.Drawing.Font("Lucida Sans", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnServicios.Location = New System.Drawing.Point(78, 221)
        Me.btnServicios.Name = "btnServicios"
        Me.btnServicios.Size = New System.Drawing.Size(179, 48)
        Me.btnServicios.TabIndex = 2
        Me.btnServicios.Text = "Servicios"
        Me.btnServicios.UseVisualStyleBackColor = True
        '
        'btnProductos
        '
        Me.btnProductos.Font = New System.Drawing.Font("Lucida Sans", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProductos.Location = New System.Drawing.Point(78, 158)
        Me.btnProductos.Name = "btnProductos"
        Me.btnProductos.Size = New System.Drawing.Size(179, 48)
        Me.btnProductos.TabIndex = 3
        Me.btnProductos.Text = "Productos"
        Me.btnProductos.UseVisualStyleBackColor = True
        '
        'btnVehiculos
        '
        Me.btnVehiculos.Font = New System.Drawing.Font("Lucida Sans", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVehiculos.Location = New System.Drawing.Point(310, 95)
        Me.btnVehiculos.Name = "btnVehiculos"
        Me.btnVehiculos.Size = New System.Drawing.Size(179, 48)
        Me.btnVehiculos.TabIndex = 7
        Me.btnVehiculos.Text = "Vehículos"
        Me.btnVehiculos.UseVisualStyleBackColor = True
        '
        'btnVentas
        '
        Me.btnVentas.Font = New System.Drawing.Font("Lucida Sans", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVentas.Location = New System.Drawing.Point(310, 158)
        Me.btnVentas.Name = "btnVentas"
        Me.btnVentas.Size = New System.Drawing.Size(179, 48)
        Me.btnVentas.TabIndex = 6
        Me.btnVentas.Text = "Ventas"
        Me.btnVentas.UseVisualStyleBackColor = True
        '
        'btnReparaciones
        '
        Me.btnReparaciones.Font = New System.Drawing.Font("Lucida Sans", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReparaciones.Location = New System.Drawing.Point(310, 31)
        Me.btnReparaciones.Name = "btnReparaciones"
        Me.btnReparaciones.Size = New System.Drawing.Size(179, 48)
        Me.btnReparaciones.TabIndex = 4
        Me.btnReparaciones.Text = "Reparaciones"
        Me.btnReparaciones.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Lucida Sans", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(310, 221)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(179, 48)
        Me.btnSalir.TabIndex = 8
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'MenuEmpleado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 304)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnVehiculos)
        Me.Controls.Add(Me.btnVentas)
        Me.Controls.Add(Me.btnReparaciones)
        Me.Controls.Add(Me.btnProductos)
        Me.Controls.Add(Me.btnServicios)
        Me.Controls.Add(Me.btnEmpleados)
        Me.Controls.Add(Me.btnClientes)
        Me.Name = "MenuEmpleado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Empleado"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClientes As System.Windows.Forms.Button
    Friend WithEvents btnEmpleados As System.Windows.Forms.Button
    Friend WithEvents btnServicios As System.Windows.Forms.Button
    Friend WithEvents btnProductos As System.Windows.Forms.Button
    Friend WithEvents btnVehiculos As System.Windows.Forms.Button
    Friend WithEvents btnVentas As System.Windows.Forms.Button
    Friend WithEvents btnReparaciones As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
End Class
