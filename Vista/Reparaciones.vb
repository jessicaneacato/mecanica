Imports System
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Reparaciones
    Dim conexion As SqlConnection
    Dim sentencia As SqlCommand
    Dim leer As SqlDataReader
    Dim contenedor As DataSet
    Dim bindingSource As BindingSource
    Dim idReparacion As Integer
    Private Sub Reparaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'MecanicaDataSet.ventas' Puede moverla o quitarla según sea necesario.
        'Me.VentasTableAdapter.Fill(Me.MecanicaDataSet.ventas)
        conexion = New SqlConnection("Data Source=LAPTOP-A9Q4NKMU\SQLEXPRESS;Initial Catalog=mecanica;Integrated Security=True")
        idReparacion = 0
        Cargar_DGVReparaciones()
        Cargar_Vehiculos()
        Cargar_Empleados()
        Cargar_Servicios()
        Cargar_Estados()
        txtValor.ReadOnly = True
    End Sub


    Private Sub Cargar_DGVReparaciones()
        conexion.Open()
        sentencia = New SqlCommand("select * from reparaciones r INNER JOIN vehiculos v ON v.id_vehiculo=r.vehiculo_id INNER JOIN empleados e ON e.id_empleado=r.empleado_id INNER JOIN servicios s ON s.id_servicio=r.servicio_id INNER JOIN estados es ON es.id_estado=r.estado_id", conexion)

        leer = sentencia.ExecuteReader

        dgvReparaciones.ColumnCount = 8
        dgvReparaciones.Columns(0).Name = "ID"
        dgvReparaciones.Columns(1).Name = "Vehículo"
        dgvReparaciones.Columns(2).Name = "Empleado"
        dgvReparaciones.Columns(3).Name = "Servicio"
        dgvReparaciones.Columns(4).Name = "Valor"
        dgvReparaciones.Columns(5).Name = "Fecha Recepción"
        dgvReparaciones.Columns(6).Name = "Fecha Entrega"
        dgvReparaciones.Columns(7).Name = "Estado"
        dgvReparaciones.Rows.Clear()
        While leer.Read
            'MsgBox(r.ToString)
            Dim fila(8) As String
            Dim fecha_entrega As String
            If (IsDBNull(leer("fecha_entrega"))) Then
                fecha_entrega = ""
            Else
                fecha_entrega = leer("fecha_entrega")
            End If
            fila = New String() {leer("id_reparacion"), leer("placa"), leer("nombres") + " " + leer("apellidos"), leer("descripcion"), leer("valor"), leer("fecha_recepcion"), fecha_entrega, leer("estado")}
            dgvReparaciones.Rows.Add(fila)
        End While
        conexion.Close()
    End Sub

    Private Sub Buscar_reparacion()
        conexion.Open()
        sentencia = New SqlCommand("select * from reparaciones r INNER JOIN vehiculos v ON v.id_vehiculo=r.vehiculo_id INNER JOIN empleados e ON e.id_empleado=r.empleado_id INNER JOIN servicios s ON s.id_servicio=r.servicio_id INNER JOIN estados es ON es.id_estado=r.estado_id WHERE r.id_reparacion = @idReparacion OR v.placa LIKE @buscar OR e.nombres LIKE @buscar OR e.apellidos LIKE @buscar OR s.descripcion LIKE @buscar OR es.estado LIKE @buscar", conexion)

        sentencia.Parameters.Add("@buscar", SqlDbType.VarChar, 250)
        sentencia.Parameters.Add("@idReparacion", SqlDbType.Int)
        sentencia.Parameters("@buscar").Value = "%" + txtBuscar.Text + "%"
        If IsNumeric(txtBuscar.Text) Then
            sentencia.Parameters("@idReparacion").Value = txtBuscar.Text
        Else
            sentencia.Parameters("@idReparacion").Value = 0
        End If


        leer = sentencia.ExecuteReader

        dgvReparaciones.ColumnCount = 8
        dgvReparaciones.Columns(0).Name = "ID"
        dgvReparaciones.Columns(1).Name = "Vehículo"
        dgvReparaciones.Columns(2).Name = "Empleado"
        dgvReparaciones.Columns(3).Name = "Servicio"
        dgvReparaciones.Columns(4).Name = "Valor"
        dgvReparaciones.Columns(5).Name = "Fecha Recepción"
        dgvReparaciones.Columns(6).Name = "Fecha Entrega"
        dgvReparaciones.Columns(7).Name = "Estado"
        dgvReparaciones.Rows.Clear()
        While leer.Read
            'MsgBox(r.ToString)
            Dim fila(8) As String
            fila = New String() {leer("id_reparacion"), leer("placa"), leer("nombres") + " " + leer("apellidos"), leer("descripcion"), leer("valor"), leer("fecha_recepcion"), leer("fecha_entrega"), leer("estado")}
            dgvReparaciones.Rows.Add(fila)
        End While
        conexion.Close()
    End Sub
    Private Sub Limpiar()
        idReparacion = 0
        txtValor.Text = ""
        txtBuscar.Text = ""
        dtpFechaRecepcion.Text = ""
        dtpFechaEntrega.Text = ""
        cbxVehiculo.SelectedValue = 0
        cbxEmpleado.SelectedValue = 0
        cbxServicio.SelectedValue = 0
        cbxEstado.SelectedValue = 0
        Cargar_DGVReparaciones()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim sql As String
        Try
            conexion.Open()
            If (Validar()) Then
                If (idReparacion = 0) Then

                    'sentencia.ExecuteNonQuery()
                    sql = "INSERT INTO reparaciones(vehiculo_id,empleado_id,servicio_id,valor,fecha_recepcion,fecha_entrega,estado_id) VALUES(@vehiculo_id,@empleado_id,@servicio_id,@valor,@fecha_recepcion,@fecha_entrega,@estado_id)"
                    sentencia = New SqlCommand(sql, conexion)

                    sentencia.Parameters.Add("@vehiculo_id", SqlDbType.Int)
                    sentencia.Parameters.Add("@empleado_id", SqlDbType.Int)
                    sentencia.Parameters.Add("@servicio_id", SqlDbType.Int)
                    sentencia.Parameters.Add("@valor", SqlDbType.Float)
                    sentencia.Parameters.Add("@fecha_recepcion", SqlDbType.Date)
                    sentencia.Parameters.Add("@fecha_entrega", SqlDbType.Date)
                    sentencia.Parameters.Add("@estado_id", SqlDbType.Int)

                    sentencia.Parameters("@vehiculo_id").Value = cbxVehiculo.SelectedValue
                    sentencia.Parameters("@empleado_id").Value = cbxEmpleado.SelectedValue
                    sentencia.Parameters("@servicio_id").Value = cbxServicio.SelectedValue
                    sentencia.Parameters("@valor").Value = txtValor.Text
                    sentencia.Parameters("@fecha_recepcion").Value = dtpFechaRecepcion.Text
                    sentencia.Parameters("@fecha_entrega").Value = dtpFechaEntrega.Text
                    sentencia.Parameters("@estado_id").Value = cbxEstado.SelectedValue

                    sentencia.ExecuteNonQuery()
                    MsgBox("Se ha guardado con éxito")
                    Limpiar()
                Else
                    sql = "UPDATE reparaciones SET vehiculo_id=@vehiculo_id,empleado_id=@empleado_id,servicio_id=@servicio_id,valor=@valor,fecha_recepcion=@fecha_recepcion,fecha_entrega=@fecha_entrega,estado_id=@estado_id WHERE id_reparacion=@idReparacion"
                    sentencia = New SqlCommand(sql, conexion)

                    sentencia.Parameters.Add("@idReparacion", SqlDbType.Int)
                    sentencia.Parameters.Add("@vehiculo_id", SqlDbType.Int)
                    sentencia.Parameters.Add("@empleado_id", SqlDbType.Int)
                    sentencia.Parameters.Add("@servicio_id", SqlDbType.Int)
                    sentencia.Parameters.Add("@valor", SqlDbType.Float)
                    sentencia.Parameters.Add("@fecha_recepcion", SqlDbType.Date)
                    sentencia.Parameters.Add("@fecha_entrega", SqlDbType.Date)
                    sentencia.Parameters.Add("@estado_id", SqlDbType.Int)

                    sentencia.Parameters("@idReparacion").Value = idReparacion
                    sentencia.Parameters("@vehiculo_id").Value = cbxVehiculo.SelectedValue
                    sentencia.Parameters("@empleado_id").Value = cbxEmpleado.SelectedValue
                    sentencia.Parameters("@servicio_id").Value = cbxServicio.SelectedValue
                    sentencia.Parameters("@valor").Value = txtValor.Text
                    sentencia.Parameters("@fecha_recepcion").Value = dtpFechaRecepcion.Text
                    sentencia.Parameters("@fecha_entrega").Value = dtpFechaEntrega.Text
                    sentencia.Parameters("@estado_id").Value = cbxEstado.SelectedValue

                    sentencia.ExecuteNonQuery()
                    MsgBox("Se ha guardado con éxito")
                    Limpiar()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
            'Recargo la lista de reparaciones
            Cargar_DGVReparaciones()
        End Try

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub
    Private Function Validar()
        Dim valido = True
        Dim msg = "No deje en blanco o seleccione una opción:"
        If (txtValor.Text.Trim = "") Then
            valido = False
            msg += " Valor,"
        End If
        If (dtpFechaRecepcion.Text.Trim = "") Then
            valido = False
            msg += " Fecha,"
        End If
        If (cbxVehiculo.SelectedValue = 0) Then
            valido = False
            msg += " Vehículo,"
        End If
        If (cbxEmpleado.SelectedValue = 0) Then
            valido = False
            msg += " Empleado,"
        End If
        If (cbxServicio.SelectedValue = 0) Then
            valido = False
            msg += " Servicio,"
        End If
        If (cbxEstado.SelectedValue = 0) Then
            valido = False
            msg += " Estado."
        End If

        If (Not valido) Then
            MsgBox(msg)
        End If
        Return valido
    End Function

    Private Sub dgvReparaciones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReparaciones.CellContentClick, dgvReparaciones.CellClick

        Try
            idReparacion = dgvReparaciones.Rows(e.RowIndex).Cells(0).Value
            If (conexion.State = ConnectionState.Closed) Then
                conexion.Open()
            End If
            sentencia = New SqlCommand("SELECT * FROM reparaciones WHERE id_reparacion = @idReparacion", conexion)
            sentencia.Parameters.Add("@idReparacion", SqlDbType.Int)

            sentencia.Parameters("@idReparacion").Value = idReparacion
            Dim servicio As Integer
            leer = sentencia.ExecuteReader
            If leer.Read Then
                cbxVehiculo.SelectedValue = leer("vehiculo_id")
                cbxEmpleado.SelectedValue = leer("empleado_id")
                servicio = leer("servicio_id")
                txtValor.Text = leer("valor")
                dtpFechaRecepcion.Text = leer("fecha_recepcion")
                If IsDBNull(("fecha_entrega")) Then
                    dtpFechaEntrega.Text = ""
                Else
                    dtpFechaEntrega.Text = leer("fecha_entrega")
                End If
                cbxEstado.SelectedValue = leer("estado_id")
                conexion.Close()
                cbxServicio.SelectedValue = servicio
            Else
                MsgBox("Hubo un error al obtener reparacion")
                conexion.Close()
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Buscar_reparacion()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            conexion.Open()
            sentencia = New SqlCommand("DELETE FROM reparaciones WHERE id_reparacion = @idReparacion", conexion)
            sentencia.Parameters.Add("@idReparacion", SqlDbType.Int)

            sentencia.Parameters("@idReparacion").Value = idReparacion

            sentencia.ExecuteNonQuery()

            conexion.Close()
            MsgBox("Se ha eliminado correctamente")
            Cargar_DGVReparaciones()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        MenuEmpleado.Show()
        Me.Close()
    End Sub

    Private Sub Cargar_Vehiculos()

        Dim da As New SqlClient.SqlDataAdapter("select id_vehiculo,placa from vehiculos", conexion)
        Dim ds As New DataSet()
        da.Fill(ds)
        Dim dr As DataRow
        dr = ds.Tables(0).NewRow
        dr("placa") = "Seleccione"
        dr("id_vehiculo") = 0
        ds.Tables(0).Rows.Add(dr)
        cbxVehiculo.DisplayMember = "placa"

        cbxVehiculo.ValueMember = "id_vehiculo"

        cbxVehiculo.DataSource = ds.Tables(0)

        cbxVehiculo.SelectedValue = 0

        conexion.Close()

    End Sub
    Private Sub Cargar_Empleados()

        Dim da As New SqlClient.SqlDataAdapter("select id_empleado,nombres+' '+apellidos info from empleados", conexion)
        Dim ds As New DataSet()
        da.Fill(ds)
        Dim dr As DataRow
        dr = ds.Tables(0).NewRow
        dr("info") = "Seleccione"
        dr("id_empleado") = 0
        ds.Tables(0).Rows.Add(dr)
        cbxEmpleado.DisplayMember = "info"

        cbxEmpleado.ValueMember = "id_empleado"

        cbxEmpleado.DataSource = ds.Tables(0)
        cbxEmpleado.SelectedValue = 0

        conexion.Close()

    End Sub
    Private Sub Cargar_Servicios()

        Dim da As New SqlClient.SqlDataAdapter("select * from servicios", conexion)
        Dim ds As New DataSet()
        da.Fill(ds)
        Dim dr As DataRow
        dr = ds.Tables(0).NewRow
        dr("descripcion") = "Seleccione"
        dr("id_servicio") = 0
        ds.Tables(0).Rows.Add(dr)
        cbxServicio.DisplayMember = "descripcion"

        cbxServicio.ValueMember = "id_servicio"

        cbxServicio.DataSource = ds.Tables(0)
        cbxServicio.SelectedValue = 0

        conexion.Close()

    End Sub
    Private Sub Cargar_Estados()

        Dim da As New SqlClient.SqlDataAdapter("select * from estados", conexion)
        Dim ds As New DataSet()
        da.Fill(ds)
        Dim dr As DataRow
        dr = ds.Tables(0).NewRow
        dr("estado") = "Seleccione"
        dr("id_estado") = 0
        ds.Tables(0).Rows.Add(dr)
        cbxEstado.DisplayMember = "estado"

        cbxEstado.ValueMember = "id_estado"

        cbxEstado.DataSource = ds.Tables(0)
        cbxEstado.SelectedValue = 0

        conexion.Close()

    End Sub

    Private Sub cbxServicio_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxServicio.SelectedValueChanged
        Try
            If (cbxServicio.SelectedValue > 0) Then
                If (conexion.State = ConnectionState.Closed) Then
                    conexion.Open()
                End If
                sentencia = New SqlCommand("SELECT * FROM servicios WHERE id_servicio = @idServicio", conexion)
                sentencia.Parameters.Add("@idServicio", SqlDbType.Int)

                sentencia.Parameters("@idServicio").Value = cbxServicio.SelectedValue

                leer = sentencia.ExecuteReader
                If leer.Read Then
                    txtValor.Text = leer("precio")
                Else
                    MsgBox("Hubo un error al obtener servicio")
                End If
                conexion.Close()
            Else
                txtValor.Text = 0
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class