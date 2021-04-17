Imports System
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Empleados
    Dim conexion As SqlConnection
    Dim sentencia As SqlCommand
    Dim leer As SqlDataReader
    Dim contenedor As DataSet
    Dim bindingSource As BindingSource
    Dim idEmpleado As Integer
    Private Sub Empleados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'MecanicaDataSet.ventas' Puede moverla o quitarla según sea necesario.
        'Me.VentasTableAdapter.Fill(Me.MecanicaDataSet.ventas)
        conexion = New SqlConnection("Data Source=LAPTOP-A9Q4NKMU\SQLEXPRESS;Initial Catalog=mecanica;Integrated Security=True")
        idEmpleado = 0
        Cargar_DGVEmpleados()
        Cargar_Tipo_Usuarios()
    End Sub

  
    Private Sub Cargar_DGVEmpleados()
        conexion.Open()
        sentencia = New SqlCommand("select c.*,u.id_usuario,u.usuario,tu.tipo from empleados c inner join usuarios u ON u.id_usuario=c.usuario_id INNER JOIN tipo_usuarios tu ON tu.id_tipo_usuario=u.tipo_usuario_id", conexion)

        leer = sentencia.ExecuteReader

        dgvEmpleados.ColumnCount = 8
        dgvEmpleados.Columns(0).Name = "ID"
        dgvEmpleados.Columns(1).Name = "Cédula"
        dgvEmpleados.Columns(2).Name = "Nombre"
        dgvEmpleados.Columns(3).Name = "Apellido"
        dgvEmpleados.Columns(4).Name = "Teléfono"
        dgvEmpleados.Columns(5).Name = "Dirección"
        dgvEmpleados.Columns(6).Name = "Usuario"
        dgvEmpleados.Columns(7).Name = "Tipo"
        dgvEmpleados.Rows.Clear()
        While leer.Read
            'MsgBox(r.ToString)
            Dim fila(8) As String
            fila = New String() {leer("id_empleado"), leer("cedula"), leer("nombres"), leer("apellidos"), leer("telefono"), leer("direccion"), leer("usuario"), leer("tipo")}
            dgvEmpleados.Rows.Add(fila)
        End While
        conexion.Close()
    End Sub

    Private Sub Buscar_empleado()
        conexion.Open()
        sentencia = New SqlCommand("select c.*,u.id_usuario,u.usuario,tu.tipo from empleados c inner join usuarios u ON u.id_usuario=c.usuario_id INNER JOIN tipo_usuarios tu ON tu.id_tipo_usuario=u.tipo_usuario_id WHERE c.nombres LIKE @buscar OR c.apellidos LIKE @buscar OR cedula LIKE @buscar OR tu.tipo LIKE @buscar", conexion)

        sentencia.Parameters.Add("@buscar", SqlDbType.VarChar, 50)
        sentencia.Parameters("@buscar").Value = "%" + txtBuscar.Text + "%"

        leer = sentencia.ExecuteReader

        dgvEmpleados.ColumnCount = 8
        dgvEmpleados.Columns(0).Name = "ID"
        dgvEmpleados.Columns(1).Name = "Cédula"
        dgvEmpleados.Columns(2).Name = "Nombre"
        dgvEmpleados.Columns(3).Name = "Apellido"
        dgvEmpleados.Columns(4).Name = "Teléfono"
        dgvEmpleados.Columns(5).Name = "Dirección"
        dgvEmpleados.Columns(6).Name = "Usuario"
        dgvEmpleados.Columns(7).Name = "Tipo"
        dgvEmpleados.Rows.Clear()
        While leer.Read
            'MsgBox(r.ToString)
            Dim fila(8) As String
            fila = New String() {leer("id_empleado"), leer("cedula"), leer("nombres"), leer("apellidos"), leer("telefono"), leer("direccion"), leer("usuario"), leer("tipo")}
            dgvEmpleados.Rows.Add(fila)
        End While
        conexion.Close()
    End Sub
    Private Sub Limpiar()
        idEmpleado = 0
        txtCedula.Text = ""
        txtTelefono.Text = ""
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtDireccion.Text = ""
        txtBuscar.Text = ""
        txtUsuario.Text = ""
        txtClave.Text = ""
        txtUsuario.Enabled = True
        cbxTipoUsuario.SelectedValue = 0
        Cargar_DGVEmpleados()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim sql As String
        Try
            conexion.Open()
            If (Validar()) Then
                If (idEmpleado = 0) Then
                    sql = "INSERT INTO usuarios(usuario,clave,tipo_usuario_id) OUTPUT INSERTED.id_usuario VALUES(@usuario,@clave,@tipo_usuario)"

                    sentencia = New SqlCommand(sql, conexion)
                    sentencia.Parameters.Add("@usuario", SqlDbType.VarChar, 20)
                    sentencia.Parameters.Add("@clave", SqlDbType.VarChar, 20)
                    sentencia.Parameters.Add("@tipo_usuario", SqlDbType.Int)

                    sentencia.Parameters("@usuario").Value = txtUsuario.Text
                    sentencia.Parameters("@clave").Value = txtClave.Text
                    sentencia.Parameters("@tipo_usuario").Value = cbxTipoUsuario.SelectedValue
                    'Devuelve la id del último usuario ingresado
                    Dim idUsuario As Integer
                    idUsuario = sentencia.ExecuteScalar()

                    'sentencia.ExecuteNonQuery()
                    sql = "INSERT INTO empleados([cedula],[nombres],[apellidos],[telefono],[direccion],[usuario_id]) VALUES(@cedula,@nombres,@apellidos,@telefono,@direccion,@usuario_id)"
                    sentencia = New SqlCommand(sql, conexion)

                    sentencia.Parameters.Add("@cedula", SqlDbType.VarChar, 10)
                    sentencia.Parameters.Add("@nombres", SqlDbType.VarChar, 50)
                    sentencia.Parameters.Add("@apellidos", SqlDbType.VarChar, 50)
                    sentencia.Parameters.Add("@telefono", SqlDbType.VarChar, 10)
                    sentencia.Parameters.Add("@direccion", SqlDbType.VarChar, 50)
                    sentencia.Parameters.Add("@usuario_id", SqlDbType.Int)

                    sentencia.Parameters("@cedula").Value = txtCedula.Text
                    sentencia.Parameters("@nombres").Value = txtNombre.Text
                    sentencia.Parameters("@apellidos").Value = txtApellido.Text
                    sentencia.Parameters("@telefono").Value = txtTelefono.Text
                    sentencia.Parameters("@direccion").Value = txtDireccion.Text
                    sentencia.Parameters("@usuario_id").Value = idUsuario

                    sentencia.ExecuteNonQuery()
                    MsgBox("Se ha guardado con éxito")
                    Limpiar()
                Else
                    sql = "UPDATE usuarios SET clave=@clave,tipo_usuario_id=@tipo_usuario_id WHERE usuario=@usuario"

                    sentencia = New SqlCommand(sql, conexion)
                    sentencia.Parameters.Add("@usuario", SqlDbType.VarChar, 20)
                    sentencia.Parameters.Add("@clave", SqlDbType.VarChar, 20)
                    sentencia.Parameters.Add("@tipo_usuario_id", SqlDbType.Int)

                    sentencia.Parameters("@usuario").Value = txtUsuario.Text
                    sentencia.Parameters("@clave").Value = txtClave.Text
                    sentencia.Parameters("@tipo_usuario_id").Value = cbxTipoUsuario.SelectedValue
                    'Devuelve la id del último usuario ingresado
                    sentencia.ExecuteNonQuery()

                    'sentencia.ExecuteNonQuery()
                    sql = "UPDATE empleados SET cedula=@cedula,nombres=@nombres,apellidos=@apellidos,telefono=@telefono,direccion=@direccion WHERE id_empleado=@idEmpleado"
                    sentencia = New SqlCommand(sql, conexion)

                    sentencia.Parameters.Add("@idEmpleado", SqlDbType.Int)
                    sentencia.Parameters.Add("@cedula", SqlDbType.VarChar, 10)
                    sentencia.Parameters.Add("@nombres", SqlDbType.VarChar, 50)
                    sentencia.Parameters.Add("@apellidos", SqlDbType.VarChar, 50)
                    sentencia.Parameters.Add("@telefono", SqlDbType.VarChar, 10)
                    sentencia.Parameters.Add("@direccion", SqlDbType.VarChar, 50)

                    sentencia.Parameters("@idEmpleado").Value = idEmpleado
                    sentencia.Parameters("@cedula").Value = txtCedula.Text
                    sentencia.Parameters("@nombres").Value = txtNombre.Text
                    sentencia.Parameters("@apellidos").Value = txtApellido.Text
                    sentencia.Parameters("@telefono").Value = txtTelefono.Text
                    sentencia.Parameters("@direccion").Value = txtDireccion.Text

                    sentencia.ExecuteNonQuery()
                    MsgBox("Se ha guardado con éxito")
                    Limpiar()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
            'Recargo la lista de empleados
            Cargar_DGVEmpleados()
        End Try

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub
    Private Function Validar()
        Dim valido = True
        Dim msg = "No deje en blanco:"
        If (txtCedula.Text.Trim = "") Then
            valido = False
            msg += " Cédula,"
        End If
        If (txtTelefono.Text.Trim = "") Then
            valido = False
            msg += " Teléfono,"
        End If
        If (txtNombre.Text.Trim = "") Then
            valido = False
            msg += " Nombre,"
        End If
        If (txtApellido.Text.Trim = "") Then
            valido = False
            msg += " Apellido,"
        End If
        If (txtDireccion.Text.Trim = "") Then
            valido = False
            msg += " Dirección,"
        End If
        If (txtUsuario.Text.Trim = "") Then
            valido = False
            msg += " Usuario,"
        End If
        If (txtClave.Text.Trim = "") Then
            valido = False
            msg += " Contraseña."
        End If
        If (cbxTipoUsuario.SelectedValue = 0) Then
            valido = False
            msg += " Tipo Usuario."
        End If

        If (Not valido) Then
            MsgBox(msg)
        End If
        Return valido
    End Function

    Private Sub dgvEmpleados_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEmpleados.CellContentClick, dgvEmpleados.CellClick
        idEmpleado = dgvEmpleados.Rows(e.RowIndex).Cells(0).Value

        Try
            conexion.Open()
            sentencia = New SqlCommand("SELECT * FROM empleados c INNER JOIN usuarios u ON c.usuario_id=u.id_usuario INNER JOIN tipo_usuarios tu ON tu.id_tipo_usuario=u.tipo_usuario_id WHERE c.id_empleado = @idEmpleado", conexion)
            sentencia.Parameters.Add("@idEmpleado", SqlDbType.Int)

            sentencia.Parameters("@idEmpleado").Value = idEmpleado

            leer = sentencia.ExecuteReader
            If leer.Read Then
                txtCedula.Text = leer("cedula")
                txtTelefono.Text = leer("telefono")
                txtNombre.Text = leer("nombres")
                txtApellido.Text = leer("apellidos")
                txtDireccion.Text = leer("direccion")
                txtUsuario.Text = leer("usuario")
                txtClave.Text = leer("clave")
                cbxTipoUsuario.SelectedValue = leer("id_tipo_usuario")
                txtUsuario.Enabled = False
            Else
                MsgBox("Hubo un error al obtener empleado")
            End If

            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Buscar_empleado()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            conexion.Open()
            sentencia = New SqlCommand("DELETE FROM empleados WHERE id_empleado = @idEmpleado", conexion)
            sentencia.Parameters.Add("@idEmpleado", SqlDbType.Int)

            sentencia.Parameters("@idEmpleado").Value = idEmpleado

            sentencia.ExecuteNonQuery()

            sentencia = New SqlCommand("DELETE FROM usuarios WHERE usuario = @usuario", conexion)
            sentencia.Parameters.Add("@usuario", SqlDbType.VarChar, 20)

            sentencia.Parameters("@usuario").Value = txtUsuario.Text

            sentencia.ExecuteNonQuery()

            conexion.Close()
            MsgBox("Se ha eliminado correctamente")
            Cargar_DGVEmpleados()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtCedula_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCedula.KeyPress
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        MenuEmpleado.Show()
        Me.Close()
    End Sub

    Private Sub Cargar_Tipo_Usuarios()
        Dim da As New SqlClient.SqlDataAdapter("select * from tipo_usuarios", conexion)
        Dim ds As New DataSet()
        da.Fill(ds)

        Dim dr As DataRow
        dr = ds.Tables(0).NewRow
        dr("tipo") = "Seleccione"
        dr("id_tipo_usuario") = 0
        ds.Tables(0).Rows.Add(dr)

        cbxTipoUsuario.DisplayMember = "tipo"

        cbxTipoUsuario.ValueMember = "id_tipo_usuario"

        cbxTipoUsuario.DataSource = ds.Tables(0)
        cbxTipoUsuario.SelectedValue = 0
        conexion.Close()
    End Sub
End Class