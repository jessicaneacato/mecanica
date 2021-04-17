Imports System
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Vehiculos
    Dim conexion As SqlConnection
    Dim sentencia As SqlCommand
    Dim leer As SqlDataReader
    Dim contenedor As DataSet
    Dim bindingSource As BindingSource
    
    Dim idVehiculo As Integer
    Private Sub Vehiculos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'MecanicaDataSet.ventas' Puede moverla o quitarla según sea necesario.
        'Me.VentasTableAdapter.Fill(Me.MecanicaDataSet.ventas)
        conexion = New SqlConnection("Data Source=LAPTOP-A9Q4NKMU\SQLEXPRESS;Initial Catalog=mecanica;Integrated Security=True")
        idVehiculo = 0
        Cargar_DGVVehiculos()
        Cargar_Clientes()
    End Sub


    Private Sub Cargar_DGVVehiculos()
        conexion.Open()
        sentencia = New SqlCommand("select * from vehiculos v INNER JOIN clientes c ON c.id_cliente=v.cliente_id", conexion)

        leer = sentencia.ExecuteReader

        dgvVehiculos.ColumnCount = 5
        dgvVehiculos.Columns(0).Name = "ID"
        dgvVehiculos.Columns(1).Name = "Marca"
        dgvVehiculos.Columns(2).Name = "Modelo"
        dgvVehiculos.Columns(3).Name = "Placa"
        dgvVehiculos.Columns(4).Name = "Cliente"
        dgvVehiculos.Columns(4).Width = 200
        dgvVehiculos.Rows.Clear()
        While leer.Read
            'MsgBox(r.ToString)
            Dim fila(5) As String
            fila = New String() {leer("id_vehiculo"), leer("marca"), leer("modelo"), leer("placa"), leer("nombres") + " " + leer("apellidos")}
            dgvVehiculos.Rows.Add(fila)
        End While
        conexion.Close()
    End Sub

    Private Sub Buscar_vehiculo()
        conexion.Open()
        sentencia = New SqlCommand("select * from vehiculos v INNER JOIN clientes c ON c.id_cliente=v.cliente_id WHERE v.placa LIKE @buscar OR v.marca LIKE @buscar OR v.modelo LIKE @buscar OR c.nombres LIKE @buscar OR c.apellidos LIKE @buscar", conexion)

        sentencia.Parameters.Add("@buscar", SqlDbType.VarChar, 50)
        sentencia.Parameters("@buscar").Value = "%" + txtBuscar.Text + "%"

        leer = sentencia.ExecuteReader

        dgvVehiculos.ColumnCount = 5
        dgvVehiculos.Columns(0).Name = "ID"
        dgvVehiculos.Columns(1).Name = "Marca"
        dgvVehiculos.Columns(2).Name = "Modelo"
        dgvVehiculos.Columns(3).Name = "Placa"
        dgvVehiculos.Columns(4).Name = "Cliente"
        dgvVehiculos.Columns(4).Width = 200
        dgvVehiculos.Rows.Clear()
        While leer.Read
            'MsgBox(r.ToString)
            Dim fila(5) As String
            fila = New String() {leer("id_vehiculo"), leer("marca"), leer("modelo"), leer("placa"), leer("nombres") + " " + leer("apellidos")}
            dgvVehiculos.Rows.Add(fila)
        End While
        conexion.Close()
    End Sub
    Private Sub Limpiar()
        idVehiculo = 0
        txtMarca.Text = ""
        txtModelo.Text = ""
        txtPlaca.Text = ""
        Cargar_DGVVehiculos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim sql As String
        Try
            conexion.Open()
            If (Validar()) Then
                If (idVehiculo = 0) Then

                    'sentencia.ExecuteNonQuery()
                    sql = "INSERT INTO vehiculos(marca,modelo,placa,cliente_id) VALUES(@marca,@modelo,@placa,@cliente_id)"
                    sentencia = New SqlCommand(sql, conexion)

                    sentencia.Parameters.Add("@marca", SqlDbType.VarChar, 20)
                    sentencia.Parameters.Add("@modelo", SqlDbType.VarChar, 20)
                    sentencia.Parameters.Add("@placa", SqlDbType.VarChar, 7)
                    sentencia.Parameters.Add("@cliente_id", SqlDbType.Int)

                    sentencia.Parameters("@marca").Value = txtMarca.Text
                    sentencia.Parameters("@modelo").Value = txtModelo.Text
                    sentencia.Parameters("@placa").Value = txtPlaca.Text
                    sentencia.Parameters("@cliente_id").Value = cbxCliente.SelectedValue

                    sentencia.ExecuteNonQuery()
                    MsgBox("Se ha guardado con éxito")
                    Limpiar()
                Else
                    sql = "UPDATE vehiculos SET marca=@marca,modelo=@modelo,placa=@placa,cliente_id=@cliente_id WHERE id_vehiculo=@idVehiculo"
                    sentencia = New SqlCommand(sql, conexion)

                    sentencia.Parameters.Add("@idVehiculo", SqlDbType.Int)
                    sentencia.Parameters.Add("@marca", SqlDbType.VarChar, 20)
                    sentencia.Parameters.Add("@modelo", SqlDbType.VarChar, 20)
                    sentencia.Parameters.Add("@placa", SqlDbType.VarChar, 7)
                    sentencia.Parameters.Add("@cliente_id", SqlDbType.Int)

                    sentencia.Parameters("@idVehiculo").Value = idVehiculo
                    sentencia.Parameters("@marca").Value = txtMarca.Text
                    sentencia.Parameters("@modelo").Value = txtModelo.Text
                    sentencia.Parameters("@placa").Value = txtPlaca.Text
                    sentencia.Parameters("@cliente_id").Value = cbxCliente.SelectedValue

                    sentencia.ExecuteNonQuery()
                    MsgBox("Se ha guardado con éxito")
                    Limpiar()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
            'Recargo la lista de vehiculos
            Cargar_DGVVehiculos()
            Limpiar()
        End Try

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub
    Private Function Validar()
        Dim valido = True
        Dim msg = "No deje en blanco:"
        If (txtMarca.Text.Trim = "") Then
            valido = False
            msg += " Marca,"
        End If
        If (txtModelo.Text.Trim = "") Then
            valido = False
            msg += " Modelo,"
        End If
        If (txtPlaca.Text.Trim = "") Then
            valido = False
            msg += " Placa."
        End If

        If (Not valido) Then
            MsgBox(msg)
        End If
        Return valido
    End Function

    Private Sub dgvVehiculos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVehiculos.CellContentClick, dgvVehiculos.CellClick

        Try
            idVehiculo = dgvVehiculos.Rows(e.RowIndex).Cells(0).Value
            conexion.Open()
            sentencia = New SqlCommand("SELECT * FROM vehiculos v INNER JOIN clientes c ON c.id_cliente=v.cliente_id WHERE id_vehiculo = @idVehiculo", conexion)
            sentencia.Parameters.Add("@idVehiculo", SqlDbType.Int)

            sentencia.Parameters("@idVehiculo").Value = idVehiculo

            leer = sentencia.ExecuteReader
            If leer.Read Then
                txtMarca.Text = leer("marca")
                txtModelo.Text = leer("modelo")
                txtPlaca.Text = leer("placa")
                cbxCliente.SelectedValue = leer("cliente_id")
            Else
                MsgBox("Hubo un error al obtener vehiculo")
            End If

            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Buscar_vehiculo()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            conexion.Open()
            sentencia = New SqlCommand("DELETE FROM vehiculos WHERE id_vehiculo = @idVehiculo", conexion)
            sentencia.Parameters.Add("@idVehiculo", SqlDbType.Int)

            sentencia.Parameters("@idVehiculo").Value = idVehiculo

            sentencia.ExecuteNonQuery()

            conexion.Close()
            MsgBox("Se ha eliminado correctamente")
            Cargar_DGVVehiculos()
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


        cbxCliente.DisplayMember = "info"

        cbxCliente.ValueMember = "id_cliente"

        cbxCliente.DataSource = ds.Tables(0)

        conexion.Close()


    End Sub
End Class
