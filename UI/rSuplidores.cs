using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleRegister.UI
{
    public partial class rSuplidores : Form
    {
        SqlConnection cmd;
        public rSuplidores()
        {
            InitializeComponent();
            cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
            CargarComboBox();
            Nuevo();
        }

        private void getUltimoSuplidor()
        {
            try
            {
                cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
                DataTable dt = new DataTable();
                using (cmd)
                {
                    string query = "SELECT top(1) SuplidorId FROM Suplidores Order by SuplidorId desc";

                    SqlCommand command = new SqlCommand(query, cmd);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
                if (dt.Rows.Count == 0)
                {
                    Idtxt.Text = "1";
                }
                else
                {
                    int id = int.Parse(dt.Rows[0]["SuplidorId"].ToString());
                    Idtxt.Text = (id++).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido una excepción: ");
            }


        }

        private void Nuevo()
        {
            getUltimoSuplidor();
            Idtxt.ReadOnly = true;

            txtNombre.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            comboEmpresa.SelectedIndex = 0;
        }

        private void CargarComboBox()
        {
            try
            {
                DataTable dt = new DataTable();
                using (cmd)
                {
                    string query = "SELECT * FROM Empresas";

                    SqlCommand command = new SqlCommand(query, cmd);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }

                comboEmpresa.DisplayMember = "Nombre";
                comboEmpresa.ValueMember = "EmpresaId";
                comboEmpresa.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido una excepción: ");
                throw;
            }

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            rBusqueda rBusqueda = new rBusqueda(this);
            rBusqueda.Show();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        public void RecibirDatos(int id, string nombre, string telefono, string cedula, int empresa)
        {
            Idtxt.Text = id.ToString();
            txtNombre.Text = nombre;
            txtCedula.Text = cedula;
            txtTelefono.Text = telefono;
            comboEmpresa.SelectedIndex = empresa - 1;

        }

        private bool ValidarCedula()
        {
            bool paso = false;
            try
            {
                cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
                DataTable dt = new DataTable();
                using (cmd)
                {
                    string query = $"SELECT * FROM Suplidores WHERE Cedula = '{txtCedula.Text}'";

                    SqlCommand command = new SqlCommand(query, cmd);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
                if (dt.Rows.Count == 0)
                {
                    paso = true;
                }
                else
                {
                    MessageBox.Show("La cedula existe. No puedes tener dos cedulas iguales");
                    txtCedula.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido una excepción: ");
            }
            return paso;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validar())
                {
                    return;
                }
                if (!ValidarCedula())
                {
                    return;
                }
                cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
                cmd.Open();
                using (cmd)
                {
                    string query = $"INSERT INTO Suplidores VALUES ({int.Parse(Idtxt.Text)},'{txtNombre.Text}', '{txtTelefono.Text}', '{txtCedula.Text}', {comboEmpresa.SelectedIndex + 1})";

                    SqlCommand command = new SqlCommand(query, cmd);
                    int i = command.ExecuteNonQuery();
                    cmd.Close();
                    if (i > 0)
                    {
                        MessageBox.Show("El suplidor fue guardado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ha ocurrido una excepción: ");
            }
        }

        private bool Validar()
        {
            bool paso = true;
            if (MessageBox.Show("¿Estás seguro de querer guardar este suplidor?", "Observación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtNombre.Text == "")
                {
                    paso = false;
                    MessageBox.Show("Debe de llevar el campo nombre");
                    txtNombre.Focus();
                }
                else if (txtCedula.Text == "")
                {
                    paso = false;
                    MessageBox.Show("Debe de llevar el campo Cedula");
                    txtCedula.Focus();
                }
                else if (txtTelefono.Text == "")
                {
                    paso = false;
                    MessageBox.Show("Debe de llevar el campo Telefono");
                    txtTelefono.Focus();
                }
            }
            return paso;
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Estás seguro de querer eliminar este suplidor?", "Observación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
                    cmd.Open();
                    using (cmd)
                    {
                        string query = $"DELETE FROM Suplidores WHERE SuplidorId = {int.Parse(Idtxt.Text)}";

                        SqlCommand command = new SqlCommand(query, cmd);
                        int i = command.ExecuteNonQuery();
                        cmd.Close();
                        if (i > 0)
                        {
                            MessageBox.Show("El suplidor fue eliminado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error al guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido una excepción: ");
            }
        }
    }
}
