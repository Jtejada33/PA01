Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class vistaUsuario
    Dim x, y As Integer
    Dim mover As Boolean
    Dim id As String

    Private Sub limpiar()
        txt_nombre.Clear()
        txt_telefono.Clear()
        txt_direccion.Clear()
        txt_observacion.Clear()
        txt_buscar.Clear()
        cbx_nacion.SelectedIndex = -1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        x = e.X
        y = e.Y
        mover = True
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If (mover = True) Then
            Me.Location = Me.PointToScreen(New Point(vistaUsuario.MousePosition.X - Me.Location.X - x, vistaUsuario.MousePosition.Y - Me.Location.Y - y))
        End If
    End Sub

    Private Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        panel_agregar.Visible = True
        txt_nombre.Focus()
        btn_modificar.Enabled = False
        btn_guardar.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        panel_agregar.Visible = False
        limpiar()
    End Sub

    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        guardar()
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        mover = False
    End Sub

    Private Sub mostrar()
        Dim da As SqlDataAdapter
        Dim datosTabla As DataSet
        'Dim consulta As String = "SELECT idUsuario as ID, nombre as NOMBRE, telefono as TELEFONO, direccion as DIREECIÓN, observaciones as OBSERVACIÓN, idNacion as NACIÓN FROM usuario"
        Dim consulta As String = "SELECT u.idUsuario as ID, u.nombre as NOMBRE, u.telefono as TELEFONO, u.direccion as DIREECIÓN, u.observaciones as OBSERVACIÓN, n.nombre as NACION  FROM usuario u inner join nacion n on u.idNacion=n.id"

        Try
            abrirConexion()

            da = New SqlDataAdapter(consulta, conexion)
            datosTabla = New DataSet
            da.Fill(datosTabla, "usuario")
            datosLector.DataSource = datosTabla
            datosLector.DataMember = "usuario"
            cerrarConexion()

            'Ancho columnas
            datosLector.Columns(0).Width = 30
            datosLector.Columns(1).Width = 30
            datosLector.Columns(2).Width = 100
            datosLector.Columns(3).Width = 80
            datosLector.Columns(4).Width = 120
            datosLector.Columns(5).Width = 150
            datosLector.Columns(6).Width = 100

            'Encabezado
            datosLector.EnableHeadersVisualStyles = False
            Dim estilo As DataGridViewCellStyle = New DataGridViewCellStyle
            estilo.BackColor = Color.White
            estilo.ForeColor = Color.Black
            estilo.Font = New Font("Segoe UI", 10, FontStyle.Regular Or FontStyle.Bold)
            datosLector.ColumnHeadersDefaultCellStyle = estilo
        Catch ex As Exception
            MsgBox("No conectado " + ex.ToString)
        End Try
    End Sub

    Private Sub buscar(busqueda As String)
        Dim da As SqlDataAdapter
        Dim datosTabla As DataSet
        Dim consulta As String = "SELECT idUsuario as ID, nombre as NOMBRE, telefono as TELEFONO, direccion as DIREECIÓN, observaciones as OBSERVACIÓN, idNacion as NACIÓN from usuario WHERE nombre LIKE '%" + busqueda + "%'"
        'Dim consulta As String = "SELECT * FROM usuario"

        Try
            abrirConexion()

            da = New SqlDataAdapter(consulta, conexion)
            datosTabla = New DataSet
            da.Fill(datosTabla, "usuario")
            datosLector.DataSource = datosTabla
            datosLector.DataMember = "usuario"
            cerrarConexion()

            'Ancho columnas
            datosLector.Columns(0).Width = 30
            datosLector.Columns(1).Width = 30
            datosLector.Columns(2).Width = 100
            datosLector.Columns(3).Width = 80
            datosLector.Columns(4).Width = 120
            datosLector.Columns(5).Width = 150
            datosLector.Columns(6).Width = 100

            'Encabezado
            datosLector.EnableHeadersVisualStyles = False
            Dim estilo As DataGridViewCellStyle = New DataGridViewCellStyle
            estilo.BackColor = Color.White
            estilo.ForeColor = Color.Black
            estilo.Font = New Font("Segoe UI", 10, FontStyle.Regular Or FontStyle.Bold)
            datosLector.ColumnHeadersDefaultCellStyle = estilo
        Catch ex As Exception
            MsgBox("No conectado " + ex.ToString)
        End Try
    End Sub

    Private Sub guardar()
        Dim sql As New SqlCommand
        Dim consulta As String = "INSERT INTO usuario VALUES(@NOMBRE,@TELEFONO,@DIRECCION,@DESCRIPCION,@NACION)"
        If txt_nombre.Text <> String.Empty And txt_telefono.Text <> String.Empty Then
            Try
                abrirConexion()
                sql = New SqlCommand(consulta, conexion)
                sql.Parameters.AddWithValue("@NOMBRE", txt_nombre.Text.ToString)
                sql.Parameters.AddWithValue("@TELEFONO", txt_telefono.Text)
                sql.Parameters.AddWithValue("@DIRECCION", txt_direccion.Text.ToString)
                sql.Parameters.AddWithValue("@DESCRIPCION", txt_observacion.Text.ToString)
                sql.Parameters.AddWithValue("@NACION", cbx_nacion.SelectedValue)
                sql.ExecuteNonQuery()
                MsgBox("DATOS INSERTADOS CORRECTAMENTE", vbOKOnly)
                limpiar()
                mostrar()
                panel_agregar.Visible = False
            Catch ex As Exception
                MsgBox("Error: " + ex.ToString)
            End Try
        Else
            MessageBox.Show("INSERTE DATOS OBLIGATORIOS", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub actualizar()
        Dim consulta As String
        'consulta = "UPDATE usuario SET nombre=" + txt_nombre.Text.ToString + ",telefono=" + txt_telefono.Text + ",direccion=" + txt_direccion.Text.ToString + ",observacion=" + txt_observacion.Text.ToString + " WHERE idUsuario="
        Dim sql As New SqlCommand
        consulta = "UPDATE usuario SET nombre=@NOMBRE, telefono=@TELEFONO, direccion=@DIRECCION, observaciones=@DESCRIPCION, idNacion=@NACION WHERE idUsuario=@ID"
        If txt_nombre.Text <> String.Empty And txt_telefono.Text <> String.Empty Then
            Try
                abrirConexion()
                sql = New SqlCommand(consulta, conexion)
                sql.Parameters.AddWithValue("@NOMBRE", txt_nombre.Text.ToString)
                sql.Parameters.AddWithValue("@TELEFONO", txt_telefono.Text)
                sql.Parameters.AddWithValue("@DIRECCION", txt_direccion.Text.ToString)
                sql.Parameters.AddWithValue("@DESCRIPCION", txt_observacion.Text.ToString)
                sql.Parameters.AddWithValue("@NACION", cbx_nacion.SelectedValue)
                sql.Parameters.AddWithValue("@ID", id)
                sql.ExecuteNonQuery()
                MsgBox("Datos actualizados correctamente", vbOKOnly)
                limpiar()
                mostrar()
                panel_agregar.Visible = False
            Catch ex As Exception
                MsgBox("Error: " + ex.ToString)
            End Try
        Else
            MessageBox.Show("INSERTE DATOS OBLIGATORIOS", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub eliminar()
        Dim consulta As String
        Dim sql As New SqlCommand
        consulta = " DELETE FROM usuario WHERE idUsuario=@ID"
        Try
            abrirConexion()
            sql = New SqlCommand(consulta, conexion)
            sql.Parameters.AddWithValue("@ID", id)
            sql.ExecuteNonQuery()
            limpiar()
            mostrar()
        Catch ex As Exception
            MsgBox("Error: " + ex.ToString)
        End Try
    End Sub

    Private Sub comboNacion()
        Dim consulta As String = "SELECT * FROM nacion"
        Dim sql As SqlCommand = New SqlCommand
        Dim adapter As SqlDataAdapter
        Dim tabla As DataTable = New DataTable

        abrirConexion()
        sql.Connection = conexion
        sql.CommandType = CommandType.Text
        sql.CommandText = consulta
        adapter = New SqlDataAdapter(sql)
        adapter.Fill(tabla)

        cbx_nacion.DataSource = tabla
        cbx_nacion.DisplayMember = "nombre"
        cbx_nacion.ValueMember = "id"
        cbx_nacion.SelectedIndex = -1

    End Sub

    Private Sub txt_nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nombre.KeyPress
        'If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
        'txt_telefono.Focus()
        'End If

        If Asc(e.KeyChar) = 13 Then
            txt_telefono.Focus()
        End If

    End Sub

    Private Sub txt_telefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_telefono.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            txt_direccion.Focus()
        End If
    End Sub

    Private Sub txt_direccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_direccion.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            txt_observacion.Focus()
        End If
    End Sub

    Private Sub txt_buscar_TextChanged(sender As Object, e As EventArgs) Handles txt_buscar.TextChanged
        buscar(txt_buscar.Text.ToString)
    End Sub

    Private Sub vistaUsuario_Load(sender As Object, e As EventArgs) Handles Me.Load
        mostrar()
        comboNacion()
    End Sub

    Private Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        actualizar()
    End Sub

    Private Sub datosLector_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles datosLector.CellContentDoubleClick
        panel_agregar.Visible = True
        txt_buscar.Clear()
        Try
            id = datosLector.SelectedCells.Item(1).Value
            txt_nombre.Text = datosLector.SelectedCells.Item(2).Value
            txt_telefono.Text = datosLector.SelectedCells.Item(3).Value
            txt_direccion.Text = datosLector.SelectedCells.Item(4).Value
            txt_observacion.Text = datosLector.SelectedCells.Item(5).Value
            cbx_nacion.Text = datosLector.SelectedCells.Item(6).Value

            btn_guardar.Enabled = False
            btn_modificar.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbx_nacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_nacion.SelectedIndexChanged

    End Sub

    Private Sub datosLector_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datosLector.CellContentClick
        id = datosLector.SelectedCells.Item(1).Value
        If e.ColumnIndex = datosLector.Columns.Item("Delete").Index Then
            Dim rpt = DialogResult
            rpt = MsgBox("¿Desea eliminar este registro?", vbQuestion + vbOKCancel, "")
            If rpt = DialogResult.OK Then
                eliminar()
            Else

            End If
        End If
    End Sub
End Class
