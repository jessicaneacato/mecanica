Imports System
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Detalles
    Dim conexion As SqlConnection
    Dim sentencia As SqlCommand
    Dim leer As SqlDataReader
    Dim contenedor As DataSet
    Dim bindingSource As BindingSource
    Public idVenta As Integer
    Dim idDetalle As Integer
    Private Sub Detalles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'MecanicaDataSet.ventas' Puede moverla o quitarla según sea necesario.
        'Me.VentasTableAdapter.Fill(Me.MecanicaDataSet.ventas)
        conexion = New SqlConnection("Data Source=LAPTOP-A9Q4NKMU\SQLEXPRESS;Initial Catalog=mecanica;Integrated Security=True")
        idDetalle = 0
        Cargar_DGVDetalles()
        Cargar_Clientes()
        Cargar_Productos()
    End Sub
    Public Sub Cargar_Venta()
        Try
            conexion.Open()
            sentencia = New SqlCommand("SELECT v.id_venta,v.cliente_id,v.fecha,SUM(d.total) total FROM ventas v INNER JOIN detalles d ON d.venta_id=v.id_venta INNER JOIN productos p ON p.id_producto=d.producto_id WHERE v.id_venta=@idVenta GROUP BY v.id_venta,v.cliente_id,v.fecha", conexion)

            sentencia.Parameters.Add("@idVenta", SqlDbType.Int)
            sentencia.Parameters("@idVenta").Value = idVenta

            leer = sentencia.ExecuteReader

            If (leer.Read) Then
                cbxCliente.SelectedValue = leer("cliente_id")
                dtpFecha.Text = leer("fecha")
                txtTotal.Text = leer("total")
            End If

            conexion.Close()
            Cargar_DGVDetalles()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Cargar_DGVDetalles()
        conexion.Open()
        Dim total As Decimal
        total = 0.0
        sentencia = New SqlCommand("SELECT d.id_detalle,p.id_producto,p.nombre,p.precio,d.cantidad,(d.cantidad*p.precio) vtotal from detalles d INNER JOIN ventas v ON v.id_venta=d.venta_id INNER JOIN productos p ON p.id_producto=d.producto_id WHERE v.id_venta=@idVenta", conexion)

        sentencia.Parameters.Add("@idVenta", SqlDbType.Int)
        sentencia.Parameters("@idVenta").Value = idVenta

        leer = sentencia.ExecuteReader

        dgvDetalles.ColumnCount = 6
        dgvDetalles.Columns(0).Name = "IdD"
        dgvDetalles.Columns(1).Name = "Id Pro"
        dgvDetalles.Columns(2).Name = "Cantidad"
        dgvDetalles.Columns(3).Name = "Detalle"
        dgvDetalles.Columns(4).Name = "V. Unit"
        dgvDetalles.Columns(5).Name = "V. Total"
        dgvDetalles.Columns(0).Width = 0
        dgvDetalles.Columns(3).Width = 250
        dgvDetalles.Rows.Clear()
        While leer.Read
            'MsgBox(r.ToString)
            Dim fila(6) As String
            fila = New String() {leer("id_detalle"), leer("id_producto"), leer("cantidad"), leer("nombre"), leer("precio"), leer("vtotal")}
            total += leer("vtotal")
            dgvDetalles.Rows.Add(fila)
        End While
        txtTotal.Text = total
        conexion.Close()
    End Sub

    Private Sub Limpiar()
        idDetalle = 0
        cbxCliente.SelectedValue = 0
        txtTotal.Text = ""
        dtpFecha.Text = ""
        cbxProductos.SelectedValue = 0
        Cargar_DGVDetalles()
    End Sub

    Private Sub Generar_Venta()
        Dim sql As String
        Try
            conexion.Open()
            If (idVenta = 0) Then
                sql = "INSERT INTO ventas(cliente_id,fecha) OUTPUT INSERTED.id_venta VALUES(@cliente_id,@fecha)"
                sentencia = New SqlCommand(sql, conexion)

                sentencia.Parameters.Add("@cliente_id", SqlDbType.Int)
                sentencia.Parameters.Add("@fecha", SqlDbType.Date)

                sentencia.Parameters("@cliente_id").Value = cbxCliente.SelectedValue
                sentencia.Parameters("@fecha").Value = dtpFecha.Text

                'Devuelve la id del último usuario ingresado
                idVenta = sentencia.ExecuteScalar()

                MsgBox("Se ha generado la venta, puede almacenar el detalle")
            Else
                sql = "UPDATE ventas SET cliente_id=@cliente_id,fecha=@fecha WHERE id_venta=@idVenta"
                sentencia = New SqlCommand(sql, conexion)

                sentencia.Parameters.Add("@cliente_id", SqlDbType.Int)
                sentencia.Parameters.Add("@fecha", SqlDbType.Date)
                sentencia.Parameters.Add("@idVenta", SqlDbType.Int)

                sentencia.Parameters("@cliente_id").Value = cbxCliente.SelectedValue
                sentencia.Parameters("@fecha").Value = dtpFecha.Text
                sentencia.Parameters("@idVenta").Value = idVenta

                sentencia.ExecuteNonQuery()
                MsgBox("Se ha guardado con éxito")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
            cbxCliente.Enabled = False
            dtpFecha.Enabled = False
            'Recargo la lista de detalles
            Cargar_DGVDetalles()
        End Try
    End Sub

    Private Sub Agregar_Detalle()
        Dim sql As String
        Try
            conexion.Open()
            If (ValidarDetalle()) Then
                If (idDetalle = 0) Then

                    'sentencia.ExecuteNonQuery()
                    sql = "INSERT INTO detalles(producto_id,venta_id,cantidad,total) VALUES(@producto_id,@venta_id,@cantidad,(SELECT precio FROM productos WHERE id_producto=@producto_id)*@cantidad)"
                    sentencia = New SqlCommand(sql, conexion)

                    sentencia.Parameters.Add("@producto_id", SqlDbType.Int)
                    sentencia.Parameters.Add("@venta_id", SqlDbType.Int)
                    sentencia.Parameters.Add("@cantidad", SqlDbType.Int)

                    sentencia.Parameters("@producto_id").Value = cbxProductos.SelectedValue
                    sentencia.Parameters("@venta_id").Value = idVenta
                    sentencia.Parameters("@cantidad").Value = txtCantidad.Text

                    sentencia.ExecuteNonQuery()
                    MsgBox("Se ha guardado con éxito")
                    'Limpiar()
                Else
                    sql = "UPDATE detalles SET cantidad=@cantidad,producto_id=@producto_id,total=(SELECT precio FROM productos WHERE id_producto=@producto_id)*@cantidad WHERE id_detalle=@idDetalle"
                    sentencia = New SqlCommand(sql, conexion)

                    sentencia.Parameters.Add("@idDetalle", SqlDbType.Int)
                    sentencia.Parameters.Add("@producto_id", SqlDbType.Int)
                    sentencia.Parameters.Add("@cantidad", SqlDbType.Int)

                    sentencia.Parameters("@idDetalle").Value = idDetalle
                    sentencia.Parameters("@producto_id").Value = cbxProductos.SelectedValue
                    sentencia.Parameters("@cantidad").Value = txtCantidad.Text

                    sentencia.ExecuteNonQuery()
                    MsgBox("Se ha guardado con éxito")
                    'Limpiar()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
            'Recargo la lista de detalles
            Cargar_DGVDetalles()
        End Try
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub
    Private Function Validar()
        Dim valido = True
        Dim msg = "No deje en blanco o seleccione una opción:"

        If (dtpFecha.Text.Trim = "") Then
            valido = False
            msg += " Fecha,"
        End If

        If (cbxCliente.SelectedValue = 0) Then
            valido = False
            msg += " Cliente,"
        End If

        If (Not valido) Then
            MsgBox(msg)
        End If
        Return valido
    End Function

    Private Function ValidarDetalle()
        Dim valido = True
        Dim msg = "No deje en blanco o seleccione una opción:"

        If (txtCantidad.Text.Trim = "") Then
            valido = False
            msg += " Cantidad,"
        End If

        If (cbxProductos.SelectedValue = 0) Then
            valido = False
            msg += " Producto."
        End If

        If (Not valido) Then
            MsgBox(msg)
        End If
        Return valido
    End Function

    Private Sub dgvDetalles_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalles.CellContentClick, dgvDetalles.CellClick

        Try
            idDetalle = dgvDetalles.Rows(e.RowIndex).Cells(0).Value
            conexion.Open()
            sentencia = New SqlCommand("SELECT * FROM detalles WHERE id_detalle = @idDetalle", conexion)
            sentencia.Parameters.Add("@idDetalle", SqlDbType.Int)

            sentencia.Parameters("@idDetalle").Value = idDetalle

            leer = sentencia.ExecuteReader
            If leer.Read Then
                cbxProductos.SelectedValue = leer("producto_id")
                txtCantidad.Text = leer("cantidad")
            Else
                MsgBox("Hubo un error al obtener detalle")
            End If

            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            conexion.Open()
            sentencia = New SqlCommand("DELETE FROM detalles WHERE id_detalle = @idDetalle", conexion)
            sentencia.Parameters.Add("@idDetalle", SqlDbType.Int)

            sentencia.Parameters("@idDetalle").Value = idDetalle

            sentencia.ExecuteNonQuery()

            conexion.Close()
            MsgBox("Se ha eliminado correctamente")
            Cargar_DGVDetalles()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Ventas.Show()
        Ventas.Cargar_DGVVentas()
        Me.Close()
    End Sub

    Private Sub Cargar_Productos()

        Dim da As New SqlClient.SqlDataAdapter("select * from productos", conexion)
        Dim ds As New DataSet()
        da.Fill(ds)
        Dim dr As DataRow
        dr = ds.Tables(0).NewRow
        dr("nombre") = "Seleccione"
        dr("id_producto") = 0
        ds.Tables(0).Rows.Add(dr)
        cbxProductos.DisplayMember = "nombre"

        cbxProductos.ValueMember = "id_producto"

        cbxProductos.DataSource = ds.Tables(0)

        cbxProductos.SelectedValue = 0

        conexion.Close()

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

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Agregar_Detalle()
        cbxProductos.SelectedValue = 0
        txtCantidad.Text = ""
        idDetalle = 0
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Generar_Venta()
    End Sub
End Class