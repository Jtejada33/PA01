
Imports System.Data.SqlClient

Module conexionM
    'Public conexion As New SqlConnection("DESKTOP-A8CTHIV\SQL_2019; Database= crud01; Integrated Security=True")
    Public conexion As New SqlConnection("Data Source=DESKTOP-A8CTHIV\SQL_2019;Initial Catalog=crud01;Integrated Security=True")
    Sub abrirConexion()
        If conexion.State = 0 Then
            conexion.Open()
        End If
    End Sub

    Sub cerrarConexion()
        If conexion.State = 1 Then
            conexion.Close()
        End If
    End Sub
End Module
