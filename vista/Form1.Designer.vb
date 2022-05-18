<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.datos_01 = New System.Windows.Forms.DataGridView()
        Me.datos_02 = New System.Windows.Forms.DataGridView()
        CType(Me.datos_01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datos_02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'datos_01
        '
        Me.datos_01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datos_01.Location = New System.Drawing.Point(118, 12)
        Me.datos_01.Name = "datos_01"
        Me.datos_01.Size = New System.Drawing.Size(240, 138)
        Me.datos_01.TabIndex = 0
        '
        'datos_02
        '
        Me.datos_02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datos_02.Location = New System.Drawing.Point(118, 169)
        Me.datos_02.Name = "datos_02"
        Me.datos_02.Size = New System.Drawing.Size(240, 150)
        Me.datos_02.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 331)
        Me.Controls.Add(Me.datos_02)
        Me.Controls.Add(Me.datos_01)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.datos_01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datos_02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents datos_01 As DataGridView
    Friend WithEvents datos_02 As DataGridView
End Class
