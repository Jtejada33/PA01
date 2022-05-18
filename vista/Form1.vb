Imports System.Data.SqlClient
Public Class Form1
    Private Sub mostrar()
        Dim dt As DataTable
        Dim da As SqlDataAdapter
        Dim consulta As String = "select idUsuario as ID, nombre as NOMBRE, telefono as TELEFONO, direccion as DIREECIÓN, observaciones as OBSERVACIÓN from usuario"

        Try
            abrirConexion()
            da = New SqlDataAdapter("mostrar_datos", conexion)
            da.Fill(dt)
            datos_01.DataSource = dt
            'Return dt
            cerrarConexion()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        mostrar()
    End Sub
End Class
