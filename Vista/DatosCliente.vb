Imports System
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class DatosClientes
    Dim conexion As SqlConnection
    Dim sentencia As SqlCommand
    Dim leer As SqlDataReader
    Dim contenedor As DataSet
    Dim bindingSource As BindingSource
    Public idCliente As Integer
    Private Sub DatosClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'MecanicaDataSet.ventas' Puede moverla o quitarla según sea necesario.
        'Me.VentasTableAdapter.Fill(Me.MecanicaDataSet.ventas)
        conexion = New SqlConnection("Data Source=LAPTOP-A9Q4NKMU\SQLEXPRESS;Initial Catalog=mecanica;Integrated Security=True")
        'Cargar_DatosCliente()
    End Sub

    Private Sub Limpiar()
        idCliente = 0
        txtCedula.Text = ""
        txtTelefono.Text = ""
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtDireccion.Text = ""
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
                    sql = "INSERT INTO clientes([cedula],[nombres],[apellidos],[telefono],[direccion],) VALUES(@cedula,@nombres,@apellidos,@telefono,@direccion)"
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
                    'Limpiar()
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
                    'Limpiar()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try

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

    Public Sub Cargar_DatosCliente()
        Try
            conexion.Open()
            sentencia = New SqlCommand("SELECT * FROM clientes c  WHERE c.id_cliente = @idCliente", conexion)
            sentencia.Parameters.Add("@idCliente", SqlDbType.Int)

            sentencia.Parameters("@idCliente").Value = idCliente

            leer = sentencia.ExecuteReader
            If leer.Read Then
                txtCedula.Text = leer("cedula")
                txtTelefono.Text = leer("telefono")
                txtNombre.Text = leer("nombres")
                txtApellido.Text = leer("apellidos")
                txtDireccion.Text = leer("direccion")
                txtCedula.Enabled = False
            Else
                MsgBox("Hubo un error al obtener cliente")
            End If

            conexion.Close()
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
        MenuCliente.Show()
        Me.Close()
    End Sub

    Private Sub btnReestablecer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReestablecer.Click
        Cargar_DatosCliente()
    End Sub

End Class