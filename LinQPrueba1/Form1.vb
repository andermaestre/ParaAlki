Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'DataGridView1.DataSource
        Dim res As Object = (From empleado In modeloDatos.Employees
                             Order By empleado.City
                             Group By EmpleadosCiudad = empleado.City
                                       Into GrupoEmpleados = Group, Count()
                             Select EmpleadosCiudad, GrupoEmpleados, GrupoEmpleados.Count).ToList
        DataGridView1.DataSource = res(1).GrupoEmpleados
        ComboBox1.DataSource = res
        ComboBox1.DisplayMember = "EmpleadosCiudad"
        ComboBox1.ValueMember = "GrupoEmpleados"
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        DataGridView1.DataSource = ComboBox1.SelectedValue
    End Sub
End Class
