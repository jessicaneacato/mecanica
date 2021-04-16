Imports System
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Servicios
    Dim conexion As SqlConnection
    Dim sentencia As SqlCommand
    Dim leer As SqlDataReader
    Dim contenedor As DataSet
    Dim bindingSource As BindingSource
    Dim idServicio As Integer
    Private Sub Servicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'MecanicaDataSet.ventas' Puede moverla o quitarla según sea necesario.
        'Me.VentasTableAdapter.Fill(Me.MecanicaDataSet.ventas)
        conexion = New SqlConnection("Data Source=LAPTOP-A9Q4NKMU\SQLEXPRESS;Initial Catalog=mecanica;Integrated Security=True")
        idServicio = 0
        Cargar_DGVServicios()

    End Sub


    Private Sub Cargar_DGVServicios()
        conexion.Open()
        sentencia = New SqlCommand("select * from servicios", conexion)

        leer = sentencia.ExecuteReader

        dgvServicios.ColumnCount = 3
        dgvServicios.Columns(0).Name = "ID"
        dgvServicios.Columns(1).Name = "Descripción"
        dgvServicios.Columns(2).Name = "Precio"
        dgvServicios.Columns(1).Width = 450
        dgvServicios.Rows.Clear()
        While leer.Read
            'MsgBox(r.ToString)
            Dim fila(3) As String
            fila = New String() {leer("id_servicio"), leer("descripcion"), leer("precio")}
            dgvServicios.Rows.Add(fila)
        End While
        conexion.Close()
    End Sub

    Private Sub Buscar_servicio()
        conexion.Open()
        sentencia = New SqlCommand("select * from servicios WHERE descripcion LIKE @buscar OR id_servicio = @idServicio", conexion)

        sentencia.Parameters.Add("@buscar", SqlDbType.VarChar, 250)
        sentencia.Parameters.Add("@idServicio", SqlDbType.Int)
        sentencia.Parameters("@buscar").Value = "%" + txtBuscar.Text + "%"
        If IsNumeric(txtBuscar.Text) Then
            sentencia.Parameters("@idServicio").Value = txtBuscar.Text
        Else
            sentencia.Parameters("@idServicio").Value = 0
        End If


        leer = sentencia.ExecuteReader

        dgvServicios.ColumnCount = 3
        dgvServicios.Columns(0).Name = "ID"
        dgvServicios.Columns(1).Name = "Descripción"
        dgvServicios.Columns(2).Name = "Precio"
        dgvServicios.Columns(1).Width = 450
        dgvServicios.Rows.Clear()
        While leer.Read
            'MsgBox(r.ToString)
            Dim fila(3) As String
            fila = New String() {leer("id_servicio"), leer("descripcion"), leer("precio")}
            dgvServicios.Rows.Add(fila)
        End While
        conexion.Close()
    End Sub
    Private Sub Limpiar()
        idServicio = 0
        txtDescripcion.Text = ""
        txtPrecio.Text = ""
        Cargar_DGVServicios()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim sql As String
        Try
            conexion.Open()
            If (Validar()) Then
                If (idServicio = 0) Then

                    'sentencia.ExecuteNonQuery()
                    sql = "INSERT INTO servicios(descripcion,precio) VALUES(@descripcion,@precio)"
                    sentencia = New SqlCommand(sql, conexion)

                    sentencia.Parameters.Add("@descripcion", SqlDbType.VarChar, 250)
                    sentencia.Parameters.Add("@precio", SqlDbType.Money)

                    sentencia.Parameters("@descripcion").Value = txtDescripcion.Text
                    sentencia.Parameters("@precio").Value = txtPrecio.Text

                    sentencia.ExecuteNonQuery()
                    MsgBox("Se ha guardado con éxito")
                    Limpiar()
                Else
                    sql = "UPDATE servicios SET descripcion=@descripcion, precio=@precio WHERE id_servicio=@idServicio"
                    sentencia = New SqlCommand(sql, conexion)

                    sentencia.Parameters.Add("@idServicio", SqlDbType.Int)
                    sentencia.Parameters.Add("@descripcion", SqlDbType.VarChar, 250)
                    sentencia.Parameters.Add("@precio", SqlDbType.Money)

                    sentencia.Parameters("@idServicio").Value = idServicio
                    sentencia.Parameters("@descripcion").Value = txtDescripcion.Text
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
            'Recargo la lista de servicios
            Cargar_DGVServicios()
        End Try

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub
    Private Function Validar()
        Dim valido = True
        Dim msg = "No deje en blanco:"
        
        If (txtDescripcion.Text.Trim = "") Then
            valido = False
            msg += " Descripción."
        End If
        If (txtPrecio.Text.Trim = "" Or txtPrecio.Text = 0) Then
            valido = False
            msg += " Precio."
        End If

        If (Not valido) Then
            MsgBox(msg)
        End If
        Return valido
    End Function

    Private Sub dgvServicios_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvServicios.CellContentClick, dgvServicios.CellClick

        Try
            If (dgvServicios.Rows(e.RowIndex).Cells(0).Value > 0) Then
                idServicio = dgvServicios.Rows(e.RowIndex).Cells(0).Value
                conexion.Open()
                sentencia = New SqlCommand("SELECT * FROM servicios WHERE id_servicio = @idServicio", conexion)
                sentencia.Parameters.Add("@idServicio", SqlDbType.Int)

                sentencia.Parameters("@idServicio").Value = idServicio

                leer = sentencia.ExecuteReader
                If leer.Read Then
                    txtDescripcion.Text = leer("descripcion")
                    txtPrecio.Text = leer("precio")
                Else
                    MsgBox("Hubo un error al obtener servicio")
                End If
            End If
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Buscar_servicio()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            conexion.Open()
            sentencia = New SqlCommand("DELETE FROM servicios WHERE id_servicio = @idServicio", conexion)
            sentencia.Parameters.Add("@idServicio", SqlDbType.Int)

            sentencia.Parameters("@idServicio").Value = idServicio

            sentencia.ExecuteNonQuery()

            conexion.Close()
            MsgBox("Se ha eliminado correctamente")
            Cargar_DGVServicios()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        MenuEmpleado.Show()
        Me.Close()
    End Sub
End Class