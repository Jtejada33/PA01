Imports System.Data.SqlClient
Public Class ventana
    Public Sub mostrar()
        Dim da As SqlDataAdapter
        Dim datosTabla As DataSet
        Dim consulta As String = "select idUsuario as ID, nombre as NOMBRE, telefono as TELEFONO, direccion as DIREECIÓN, observaciones as OBSERVACIÓN from usuario"
        'Dim consulta As String = "SELECT * FROM usuario"

        Try
            abrirConexion()

            da = New SqlDataAdapter(consulta, conexion)
            datosTabla = New DataSet
            da.Fill(datosTabla, "usuario")
            datos_01.DataSource = datosTabla
            datos_01.DataMember = "usuario"
            'Return dt
            cerrarConexion()
            'MsgBox("Conectadooo")
        Catch ex As Exception
            MsgBox("No conectado " + ex.ToString)
        End Try
    End Sub

    Private Sub ventana_Load(sender As Object, e As EventArgs) Handles Me.Load
        mostrar()
    End Sub
End Class