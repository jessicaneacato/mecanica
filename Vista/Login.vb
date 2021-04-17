Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Login
    Dim conexion As SqlConnection
    Dim sentencia As SqlCommand
    Dim leer As SqlDataReader
    Dim contenedor As DataSet
    Dim tipo As Integer
    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conexion = New SqlConnection("Data Source=LAPTOP-A9Q4NKMU\SQLEXPRESS;Initial Catalog=mecanica;Integrated Security=True")
        'MsgBox("conexion Realizada")
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        conexion.Open()
        sentencia = New SqlCommand("SELECT * FROM usuarios WHERE usuario = @usuario AND clave = @clave", conexion)
        sentencia.Parameters.Add("@clave", SqlDbType.VarChar, 20)
        sentencia.Parameters.Add("@usuario", SqlDbType.VarChar, 20)
        sentencia.Parameters("@usuario").Value = txtUsuario.Text
        sentencia.Parameters("@clave").Value = txtClave.Text

        leer = sentencia.ExecuteReader
        If leer.Read Then
            tipo = leer("tipo_usuario_id")
            MsgBox("Bienvenido/a " + leer("usuario"))
            If (tipo = 1) Then
                MenuEmpleado.Show()
            ElseIf (tipo = 2) Then
                MenuSecretaria.Show()
            ElseIf (tipo = 3) Then
                MenuSecretaria.Show()
            End If
            Me.Hide()
        Else
            MsgBox("Usuario y/o contraseña incorrecto")
        End If
        txtUsuario.Text = ""
        txtClave.Text = ""

        conexion.Close()
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
