Public Class MenuEmpleado

    Private Sub btnEmpleados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleados.Click
        Empleados.Show()
        Me.Hide()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Login.Show()
        Me.Close()
    End Sub

    Private Sub btnClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClientes.Click
        Clientes.Show()
        Me.Hide()
    End Sub

    Private Sub btnProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProductos.Click
        Productos.Show()
        Me.Hide()
    End Sub

    Private Sub btnServicios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnServicios.Click
        Servicios.Show()
        Me.Hide()
    End Sub

    Private Sub btnVehiculos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehiculos.Click
        Vehiculos.Show()
        Me.Hide()
    End Sub

    Private Sub btnReparaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReparaciones.Click
        Reparaciones.Show()
        Me.Hide()
    End Sub

    Private Sub btnVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVentas.Click
        Ventas.Show()
        Me.Hide()
    End Sub
End Class