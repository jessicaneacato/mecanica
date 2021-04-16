Imports System
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class MenuCliente
    Dim conexion As SqlConnection
    Dim sentencia As SqlCommand
    Dim leer As SqlDataReader
    Dim contenedor As DataSet
    Dim bindingSource As BindingSource
    Public idCliente As Integer

    Private Sub MenuCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conexion = New SqlConnection("Data Source=LAPTOP-A9Q4NKMU\SQLEXPRESS;Initial Catalog=mecanica;Integrated Security=True")
        'Cargar_DatosCliente()
    End Sub

    Private Sub btnClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClientes.Click
        DatosClientes.Show()
        DatosClientes.idCliente = idCliente
        DatosClientes.Cargar_DatosCliente()
        Me.Hide()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Clientes.Show()
        Me.Close()
    End Sub

    Private Sub btnVehiculos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehiculos.Click
        ClientesVehiculos.Show()
        ClientesVehiculos.idCliente = idCliente
        ClientesVehiculos.Cargar_Datos()
    End Sub

    Private Sub btnReparaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReparaciones.Click
        ClientesReparaciones.Show()
        ClientesReparaciones.idCliente = idCliente
        ClientesReparaciones.Cargar_Datos()
    End Sub

    Private Sub btnCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompras.Click
        ClientesCompras.Show()
        ClientesCompras.idCliente = idCliente
        ClientesCompras.Cargar_Datos()
    End Sub
End Class