Imports System
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Clientes
    Dim conexion As SqlConnection
    Dim sentencia As SqlCommand
    Dim leer As SqlDataReader
    Dim contenedor As DataSet
    Dim bindingSource As BindingSource
    Dim idCliente As Integer
    Private Sub Clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'MecanicaDataSet.ventas' Puede moverla o quitarla según sea necesario.
        'Me.VentasTableAdapter.Fill(Me.MecanicaDataSet.ventas)
        conexion = New SqlConnection("Data Source=LAPTOP-A9Q4NKMU\SQLEXPRESS;Initial Catalog=mecanica;Integrated Security=True")
        idCliente = 0
        Cargar_DGVClientes()
        btnInfo.Enabled = False
    End Sub

   
    Private Sub Cargar_DGVClientes()
        conexion.Open()
        sentencia = New SqlCommand("select * from clientes", conexion)

        leer = sentencia.ExecuteReader

        dgvClientes.ColumnCount = 6
        dgvClientes.Columns(0).Name = "ID"
        dgvClientes.Columns(1).Name = "Cédula"
        dgvClientes.Columns(2).Name = "Nombre"
        dgvClientes.Columns(3).Name = "Apellido"
        dgvClientes.Columns(4).Name = "Teléfono"
        dgvClientes.Columns(5).Name = "Dirección"
        dgvClientes.Rows.Clear()
        While leer.Read
            'MsgBox(r.ToString)
            Dim fila(6) As String
            fila = New String() {leer("id_cliente"), leer("cedula"), leer("nombres"), leer("apellidos"), leer("telefono"), leer("direccion")}
            dgvClientes.Rows.Add(fila)
        End While
        conexion.Close()
    End Sub

    Private Sub Buscar_cliente()
        conexion.Open()
        sentencia = New SqlCommand("select * from clientes c  WHERE c.nombres LIKE @buscar OR c.apellidos LIKE @buscar OR cedula LIKE @buscar", conexion)

        sentencia.Parameters.Add("@buscar", SqlDbType.VarChar, 50)
        sentencia.Parameters("@buscar").Value = "%" + txtBuscar.Text + "%"

        leer = sentencia.ExecuteReader

        dgvClientes.ColumnCount = 6
        dgvClientes.Columns(0).Name = "ID"
        dgvClientes.Columns(1).Name = "Cédula"
        dgvClientes.Columns(2).Name = "Nombre"
        dgvClientes.Columns(3).Name = "Apellido"
        dgvClientes.Columns(4).Name = "Teléfono"
        dgvClientes.Columns(5).Name = "Dirección"
        dgvClientes.Rows.Clear()
        While leer.Read
            'MsgBox(r.ToString)
            Dim fila(6) As String
            fila = New String() {leer("id_cliente"), leer("cedula"), leer("nombres"), leer("apellidos"), leer("telefono"), leer("direccion")}
            dgvClientes.Rows.Add(fila)
        End While
        conexion.Close()
    End Sub
    Private Sub Limpiar()
        idCliente = 0
        txtCedula.Text = ""
        txtTelefono.Text = ""
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtDireccion.Text = ""
        txtBuscar.Text = ""
        btnInfo.Enabled = False
        Cargar_DGVClientes()
    End Sub
 
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim sql As String
        Try
            conexion.Open()
            If (Validar()) Then
                If (idCliente = 0) Then
                    'sql = "INSERT INTO usuarios(usuario,clave,tipo_usuario_id) OUTPUT INSERTED.id_usuario VALUES(@usuario,@clave,2)"

                    'sentencia = New SqlCommand(sql, conexion)
                    'sentencia.Parameters.Add("@usuario", SqlDbType.VarChar, 20)
                    'sentencia.Parameters.Add("@clave", SqlDbType.VarChar, 20)

                    'sentencia.Parameters("@usuario").Value = txtUsuario.Text
                    'sentencia.Parameters("@clave").Value = txtClave.Text
                    ''Devuelve la id del último usuario ingresado
                    'Dim idUsuario As Integer
                    'idUsuario = sentencia.ExecuteScalar()

                    'sentencia.ExecuteNonQuery()
                    sql = "INSERT INTO clientes([cedula],[nombres],[apellidos],[telefono],[direccion]) VALUES(@cedula,@nombres,@apellidos,@telefono,@direccion)"
                    sentencia = New SqlCommand(sql, conexion)

                    sentencia.Parameters.Add("@cedula", SqlDbType.VarChar, 10)
                    sentencia.Parameters.Add("@nombres", SqlDbType.VarChar, 50)
                    sentencia.Parameters.Add("@apellidos", SqlDbType.VarChar, 50)
                    sentencia.Parameters.Add("@telefono", SqlDbType.VarChar, 10)
                    sentencia.Parameters.Add("@direccion", SqlDbType.VarChar, 50)

                    sentencia.Parameters("@cedula").Value = txtCedula.Text
                    sentencia.Parameters("@nombres").Value = txtNombre.Text
                    sentencia.Parameters("@apellidos").Value = txtApellido.Text
                    sentencia.Parameters("@telefono").Value = txtTelefono.Text
                    sentencia.Parameters("@direccion").Value = txtDireccion.Text

                    sentencia.ExecuteNonQuery()
                    MsgBox("Se ha guardado con éxito")
                    Limpiar()
                Else
                    'sql = "UPDATE usuarios SET clave=@clave WHERE usuario=@usuario"

                    'sentencia = New SqlCommand(sql, conexion)
                    'sentencia.Parameters.Add("@usuario", SqlDbType.VarChar, 20)
                    'sentencia.Parameters.Add("@clave", SqlDbType.VarChar, 20)

                    'sentencia.Parameters("@usuario").Value = txtUsuario.Text
                    'sentencia.Parameters("@clave").Value = txtClave.Text
                    ''Devuelve la id del último usuario ingresado
                    'sentencia.ExecuteNonQuery()

                    'sentencia.ExecuteNonQuery()
                    sql = "UPDATE clientes SET cedula=@cedula,nombres=@nombres,apellidos=@apellidos,telefono=@telefono,direccion=@direccion WHERE id_cliente=@idCliente"
                    sentencia = New SqlCommand(sql, conexion)

                    sentencia.Parameters.Add("@idCliente", SqlDbType.Int)
                    sentencia.Parameters.Add("@cedula", SqlDbType.VarChar, 10)
                    sentencia.Parameters.Add("@nombres", SqlDbType.VarChar, 50)
                    sentencia.Parameters.Add("@apellidos", SqlDbType.VarChar, 50)
                    sentencia.Parameters.Add("@telefono", SqlDbType.VarChar, 10)
                    sentencia.Parameters.Add("@direccion", SqlDbType.VarChar, 50)

                    sentencia.Parameters("@idCliente").Value = idCliente
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
            'Recargo la lista de clientes
            Cargar_DGVClientes()
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

        If (Not valido) Then
            MsgBox(msg)
        End If
        Return valido
    End Function

    Private Sub dgvClientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClientes.CellContentClick, dgvClientes.CellClick
        idCliente = dgvClientes.Rows(e.RowIndex).Cells(0).Value

        Try
            conexion.Open()
            sentencia = New SqlCommand("SELECT * FROM clientes c WHERE c.id_cliente = @idCliente", conexion)
            sentencia.Parameters.Add("@idCliente", SqlDbType.Int)

            sentencia.Parameters("@idCliente").Value = idCliente

            leer = sentencia.ExecuteReader
            If leer.Read Then
                txtCedula.Text = leer("cedula")
                txtTelefono.Text = leer("telefono")
                txtNombre.Text = leer("nombres")
                txtApellido.Text = leer("apellidos")
                txtDireccion.Text = leer("direccion")
                btnInfo.Enabled = True
            Else
                MsgBox("Hubo un error al obtener cliente")
            End If

            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Buscar_cliente()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            conexion.Open()
            sentencia = New SqlCommand("DELETE FROM clientes WHERE id_cliente = @idCliente", conexion)
            sentencia.Parameters.Add("@idCliente", SqlDbType.Int)

            sentencia.Parameters("@idCliente").Value = idCliente

            sentencia.ExecuteNonQuery()

            'sentencia = New SqlCommand("DELETE FROM usuarios WHERE usuario = @usuario", conexion)
            'sentencia.Parameters.Add("@usuario", SqlDbType.VarChar, 20)

            'sentencia.Parameters("@usuario").Value = txtUsuario.Text

            sentencia.ExecuteNonQuery()

            conexion.Close()
            MsgBox("Se ha eliminado correctamente")
            Cargar_DGVClientes()
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

    Private Sub btnInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfo.Click
        MenuCliente.Show()
        MenuCliente.idCliente = idCliente
        Me.Hide()
    End Sub
End Class