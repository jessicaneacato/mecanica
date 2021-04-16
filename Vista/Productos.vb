Imports System
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Productos
    Dim conexion As SqlConnection
    Dim sentencia As SqlCommand
    Dim leer As SqlDataReader
    Dim contenedor As DataSet
    Dim bindingSource As BindingSource
    Dim idProducto As Integer
    Private Sub Productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'MecanicaDataSet.ventas' Puede moverla o quitarla según sea necesario.
        'Me.VentasTableAdapter.Fill(Me.MecanicaDataSet.ventas)
        conexion = New SqlConnection("Data Source=LAPTOP-A9Q4NKMU\SQLEXPRESS;Initial Catalog=mecanica;Integrated Security=True")
        idProducto = 0
        Cargar_DGVProductos()

    End Sub


    Private Sub Cargar_DGVProductos()
        conexion.Open()
        sentencia = New SqlCommand("select * from productos", conexion)

        leer = sentencia.ExecuteReader

        dgvProductos.ColumnCount = 4
        dgvProductos.Columns(0).Name = "ID"
        dgvProductos.Columns(1).Name = "Nombre"
        dgvProductos.Columns(2).Name = "Detalle"
        dgvProductos.Columns(3).Name = "Precio"
        dgvProductos.Rows.Clear()
        While leer.Read
            'MsgBox(r.ToString)
            Dim fila(7) As String
            fila = New String() {leer("id_producto"), leer("nombre"), leer("detalle"), leer("precio")}
            dgvProductos.Rows.Add(fila)
        End While
        conexion.Close()
    End Sub

    Private Sub Buscar_producto()
        conexion.Open()
        sentencia = New SqlCommand("select * from productos WHERE nombre LIKE @buscar OR detalle LIKE @buscar OR id_producto = @idProducto", conexion)

        sentencia.Parameters.Add("@buscar", SqlDbType.VarChar, 50)
        sentencia.Parameters.Add("@idProducto", SqlDbType.Int)
        sentencia.Parameters("@buscar").Value = "%" + txtBuscar.Text + "%"
        If IsNumeric(txtBuscar.Text) Then
            sentencia.Parameters("@idProducto").Value = txtBuscar.Text
        Else
            sentencia.Parameters("@idProducto").Value = 0
        End If


        leer = sentencia.ExecuteReader

        dgvProductos.ColumnCount = 4
        dgvProductos.Columns(0).Name = "ID"
        dgvProductos.Columns(1).Name = "Nombre"
        dgvProductos.Columns(2).Name = "Detalle"
        dgvProductos.Columns(3).Name = "Precio"
        dgvProductos.Rows.Clear()
        While leer.Read
            'MsgBox(r.ToString)
            Dim fila(7) As String
            fila = New String() {leer("id_producto"), leer("nombre"), leer("detalle"), leer("precio")}
            dgvProductos.Rows.Add(fila)
        End While
        conexion.Close()
    End Sub
    Private Sub Limpiar()
        idProducto = 0
        txtNombre.Text = ""
        txtPrecio.Text = ""
        txtDetalle.Text = ""
        Cargar_DGVProductos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim sql As String
        Try
            conexion.Open()
            If (Validar()) Then
                If (idProducto = 0) Then

                    'sentencia.ExecuteNonQuery()
                    sql = "INSERT INTO productos(nombre,detalle,precio) VALUES(@nombre,@detalle,@precio)"
                    sentencia = New SqlCommand(sql, conexion)

                    sentencia.Parameters.Add("@nombre", SqlDbType.VarChar, 30)
                    sentencia.Parameters.Add("@detalle", SqlDbType.VarChar, 250)
                    sentencia.Parameters.Add("@precio", SqlDbType.Float)

                    sentencia.Parameters("@nombre").Value = txtNombre.Text
                    sentencia.Parameters("@detalle").Value = txtDetalle.Text
                    sentencia.Parameters("@precio").Value = txtPrecio.Text

                    sentencia.ExecuteNonQuery()
                    MsgBox("Se ha guardado con éxito")
                    Limpiar()
                Else
                    sql = "UPDATE productos SET nombre=@nombre,detalle=@detalle,precio=@precio WHERE id_producto=@idProducto"
                    sentencia = New SqlCommand(sql, conexion)

                    sentencia.Parameters.Add("@idProducto", SqlDbType.Int)
                    sentencia.Parameters.Add("@nombre", SqlDbType.VarChar, 30)
                    sentencia.Parameters.Add("@detalle", SqlDbType.VarChar, 250)
                    sentencia.Parameters.Add("@precio", SqlDbType.Float)

                    sentencia.Parameters("@idProducto").Value = idProducto
                    sentencia.Parameters("@nombre").Value = txtNombre.Text
                    sentencia.Parameters("@detalle").Value = txtDetalle.Text
                    sentencia.Parameters("@precio").Value = txtPrecio.Text

                    sentencia.ExecuteNonQuery()
                    MsgBox("Se ha guardado con éxito")
                    Limpiar()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
            'Recargo la lista de productos
            Cargar_DGVProductos()
        End Try

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub
    Private Function Validar()
        Dim valido = True
        Dim msg = "No deje en blanco:"
        If (txtNombre.Text.Trim = "") Then
            valido = False
            msg += " Nombre,"
        End If
        If (txtPrecio.Text.Trim = "") Then
            valido = False
            msg += " Precio,"
        End If
        If (txtDetalle.Text.Trim = "") Then
            valido = False
            msg += " Detalle."
        End If

        If (Not valido) Then
            MsgBox(msg)
        End If
        Return valido
    End Function

    Private Sub dgvProductos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellContentClick

        Try
            idProducto = dgvProductos.Rows(e.RowIndex).Cells(0).Value
            conexion.Open()
            sentencia = New SqlCommand("SELECT * FROM productos WHERE id_producto = @idProducto", conexion)
            sentencia.Parameters.Add("@idProducto", SqlDbType.Int)

            sentencia.Parameters("@idProducto").Value = idProducto

            leer = sentencia.ExecuteReader
            If leer.Read Then
                txtNombre.Text = leer("nombre")
                txtPrecio.Text = leer("precio")
                txtDetalle.Text = leer("detalle")
            Else
                MsgBox("Hubo un error al obtener producto")
            End If

            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Buscar_producto()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            conexion.Open()
            sentencia = New SqlCommand("DELETE FROM productos WHERE id_producto = @idProducto", conexion)
            sentencia.Parameters.Add("@idProducto", SqlDbType.Int)

            sentencia.Parameters("@idProducto").Value = idProducto

            sentencia.ExecuteNonQuery()

            conexion.Close()
            MsgBox("Se ha eliminado correctamente")
            Cargar_DGVProductos()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        MenuEmpleado.Show()
        Me.Close()
    End Sub
End Class