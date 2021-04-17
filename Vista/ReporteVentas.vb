﻿Imports System
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class ReporteVentas
    Public idCliente
    Dim conexion As SqlConnection
    Dim sentencia As SqlCommand
    Dim leer As SqlDataReader
    Dim contenedor As DataSet
    Dim bindingSource As BindingSource
    Private Sub ReporteVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conexion = New SqlConnection("Data Source=LAPTOP-A9Q4NKMU\SQLEXPRESS;Initial Catalog=mecanica;Integrated Security=True")
        Cargar_Datos()
    End Sub

    Public Sub Cargar_Datos()
        Try
            conexion.Open()
            Dim da As New SqlClient.SqlDataAdapter("SELECT * FROM V_Ventas", conexion)

            'Dim cid As New SqlParameter("@cliente_id", SqlDbType.Int)
            'cid.Value = idCliente
            'da.SelectCommand.Parameters.Add(cid)
            Dim ds As New DataSet()
            da.Fill(ds)

            Dim rpt As New CRVentas()
            rpt.SetDataSource(ds.Tables(0))
            CrystalReportViewer1.ReportSource = rpt

            conexion.Close()
            conexion.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class