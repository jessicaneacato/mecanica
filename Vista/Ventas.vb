Imports System
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Ventas
    Dim conexion As SqlConnection
    Dim sentencia As SqlCommand
    Dim leer As SqlDataReader
    Dim contenedor As DataSet
    Dim bindingSource As BindingSource

    Dim idVenta As Integer
    Private Sub Ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'MecanicaDataSet.ventas' Puede moverla o quitarla según sea necesario.
        'Me.VentasTableAdapter.Fill(Me.MecanicaDataSet.ventas)
        conexion = New SqlConnection("Data Source=LAPTOP-A9Q4NKMU\SQLEXPRESS;Initial Catalog=mecanica;Integrated Security=True")
        idVenta = 0
        Cargar_DGVVentas()
        Cargar_Clientes()
    End Sub


    Public Sub Cargar_DGVVentas()
        conexion.Open()
        sentencia = New SqlCommand("SELECT v.id_venta,v.fecha,c.cedula+' - '+nombres+' '+c.apellidos cliente,SUM(p.precio*d.cantidad) total FROM ventas v INNER JOIN clientes c ON c.id_cliente = v.cliente_id INNER JOIN detalles d ON d.venta_id=v.id_venta INNER JOIN productos p ON p.id_producto=d.producto_id GROUP BY v.id_venta,v.fecha,c.cedula, c.nombres,c.apellidos ORDER BY v.id_venta DESC", conexion)

        leer = sentencia.ExecuteReader

        dgvVentas.ColumnCount = 4
        dgvVentas.Columns(0).Name = "Nro"
        dgvVentas.Columns(1).Name = "Fecha"
        dgvVentas.Columns(2).Name = "Cliente"
        dgvVentas.Columns(3).Name = "Total"
        dgvVentas.Columns(2).Width = 250
        dgvVentas.Rows.Clear()
        While leer.Read
            'MsgBox(r.ToString)
            Dim fila(5) As String
            fila = New String() {leer("id_venta"), leer("fecha"), leer("cliente"), leer("total")}
            dgvVentas.Rows.Add(fila)
        End While
        conexion.Close()
    End Sub

    Private Sub Buscar_venta()
        conexion.Open()
        sentencia = New SqlCommand("SELECT v.id_venta,v.fecha,c.cedula+' - '+nombres+' '+c.apellidos cliente,SUM(p.precio*d.cantidad) total FROM ventas v INNER JOIN clientes c ON c.id_cliente = v.cliente_id INNER JOIN detalles d ON d.venta_id=v.id_venta INNER JOIN productos p ON p.id_producto=d.producto_id WHERE v.id_venta=@idVenta OR c.cedula LIKE @buscar OR c.nombres LIKE @buscar OR c.apellidos LIKE @buscar GROUP BY v.id_venta,v.fecha,c.cedula, c.nombres,c.apellidos ORDER BY v.id_venta DESC", conexion)

        sentencia.Parameters.Add("@buscar", SqlDbType.VarChar, 250)
        sentencia.Parameters.Add("@idVenta", SqlDbType.Int)
        sentencia.Parameters("@buscar").Value = "%" + txtBuscar.Text + "%"
        If IsNumeric(txtBuscar.Text) Then
            sentencia.Parameters("@idVenta").Value = txtBuscar.Text
        Else
            sentencia.Parameters("@idVenta").Value = 0
        End If

        leer = sentencia.ExecuteReader

        dgvVentas.ColumnCount = 4
        dgvVentas.Columns(0).Name = "Nro"
        dgvVentas.Columns(1).Name = "Fecha"
        dgvVentas.Columns(2).Name = "Cliente"
        dgvVentas.Columns(3).Name = "Total"
        dgvVentas.Columns(2).Width = 250
        dgvVentas.Rows.Clear()
        While leer.Read
            'MsgBox(r.ToString)
            Dim fila(5) As String
            fila = New String() {leer("id_venta"), leer("fecha"), leer("cliente"), leer("total")}
            dgvVentas.Rows.Add(fila)
        End While
        conexion.Close()
    End Sub
    Private Sub Limpiar()
        idVenta = 0
        txtNumero.Text = ""
        txtTotal.Text = ""
        txtFecha.Text = ""
        txtBuscar.Text = ""
        cbxCliente.SelectedValue = 0
        Cargar_DGVVentas()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub
    Private Function Validar()
        Dim valido = True
        Dim msg = "No deje en blanco:"
        If (txtNumero.Text.Trim = "") Then
            valido = False
            msg += " Marca,"
        End If
        If (txtTotal.Text.Trim = "") Then
            valido = False
            msg += " Modelo,"
        End If
        If (txtFecha.Text.Trim = "") Then
            valido = False
            msg += " Placa."
        End If
        If (cbxCliente.SelectedValue = 0) Then
            valido = False
            msg += " Cliente."
        End If

        If (Not valido) Then
            MsgBox(msg)
        End If
        Return valido
    End Function

    Private Sub dgvVentas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVentas.CellContentClick

        Try
            idVenta = dgvVentas.Rows(e.RowIndex).Cells(0).Value
            conexion.Open()
            sentencia = New SqlCommand("SELECT v.id_venta,v.fecha,c.id_cliente,SUM(p.precio*d.cantidad) total FROM ventas v INNER JOIN clientes c ON c.id_cliente = v.cliente_id INNER JOIN detalles d ON d.venta_id=v.id_venta INNER JOIN productos p ON p.id_producto=d.producto_id WHERE id_venta = @idVenta GROUP BY v.id_venta,v.fecha,c.id_cliente", conexion)
            sentencia.Parameters.Add("@idVenta", SqlDbType.Int)

            sentencia.Parameters("@idVenta").Value = idVenta

            leer = sentencia.ExecuteReader
            If leer.Read Then
                txtNumero.Text = leer("id_venta")
                txtTotal.Text = leer("total")
                txtFecha.Text = leer("fecha")
                cbxCliente.SelectedValue = leer("id_cliente")
            Else
                MsgBox("Hubo un error al obtener venta")
            End If

            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Buscar_venta()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            conexion.Open()
            sentencia = New SqlCommand("DELETE FROM ventas WHERE id_venta = @idVenta", conexion)
            sentencia.Parameters.Add("@idVenta", SqlDbType.Int)

            sentencia.Parameters("@idVenta").Value = idVenta

            sentencia.ExecuteNonQuery()

            conexion.Close()
            MsgBox("Se ha eliminado correctamente")
            Cargar_DGVVentas()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        MenuEmpleado.Show()
        Me.Close()
    End Sub
    Private Sub Cargar_Clientes()
        Dim da As New SqlClient.SqlDataAdapter("select id_cliente, cedula+' - '+nombres+' '+apellidos info from clientes", conexion)
        Dim ds As New DataSet()
        da.Fill(ds)

        Dim dr As DataRow
        dr = ds.Tables(0).NewRow
        dr("info") = "Seleccione"
        dr("id_cliente") = 0
        ds.Tables(0).Rows.Add(dr)

        cbxCliente.DisplayMember = "info"

        cbxCliente.ValueMember = "id_cliente"

        cbxCliente.DataSource = ds.Tables(0)
        cbxCliente.SelectedValue = 0
        conexion.Close()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Detalles.Show()
        Detalles.idVenta = 0
        Me.Hide()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Detalles.Show()
        Detalles.idVenta = idVenta
        Detalles.Cargar_Venta()
        Me.Hide()
    End Sub
End Class
