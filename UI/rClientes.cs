using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleRegister.UI
{
    public partial class rClientes : Form
    {
        SqlConnection cmd;
        public rClientes()
        {
            InitializeComponent();
            cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
            CargarComboBox();
            Nuevo();
        }

        private void getUltimoCliente()
        {
            try
            {
                cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
                DataTable dt = new DataTable();
                using (cmd)
                {
                    string query = "SELECT top(1) ClienteId FROM Clientes Order by ClienteId desc";

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
                    int id = int.Parse(dt.Rows[0]["ClienteId"].ToString());
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
            getUltimoCliente();
            Idtxt.ReadOnly = true;

            txtNombre.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            comboSexos.SelectedIndex = 0;
        }

        private void CargarComboBox()
        {
            try
            {
                DataTable dt = new DataTable();
                using (cmd)
                {
                    string query = "SELECT * FROM Sexos";

                    SqlCommand command = new SqlCommand(query, cmd);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }

                comboSexos.DisplayMember = "Nombre";
                comboSexos.ValueMember = "SexoId";
                comboSexos.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido una excepción: ");
                throw;
            }

        }

        public void RecibirDatos(int id, string nombre, string telefono, string celular, string correo, int sexos)
        {
            Idtxt.Text = id.ToString();
            txtNombre.Text = nombre;
            txtCelular.Text = celular;
            txtTelefono.Text = telefono;
            txtCorreo.Text = correo;
            comboSexos.SelectedIndex = sexos - 1;

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            rBusqueda busqueda = new rBusqueda(this);
            busqueda.Show();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Nuevo();
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
                else if (txtCelular.Text == "")
                {
                    paso = false;
                    MessageBox.Show("Debe de llevar el campo Celular");
                    txtCelular.Focus();
                }
                else if (txtTelefono.Text == "")
                {
                    paso = false;
                    MessageBox.Show("Debe de llevar el campo Telefono");
                    txtTelefono.Focus();
                }
                else if (txtCorreo.Text == "")
                {
                    paso = false;
                    MessageBox.Show("Debe de llevar el campo Correo");
                    txtCorreo.Focus();
                }

            }
            return paso;
        }
        private bool VerificarEmail(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validar())
                {
                    return;
                }
                if (!VerificarEmail(txtCorreo.Text))
                {
                    MessageBox.Show("Correo invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCorreo.Focus();
                    return;
                }
                cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
                cmd.Open();
                using (cmd)
                {
                    string query = $"INSERT INTO Clientes VALUES ({int.Parse(Idtxt.Text)},'{txtNombre.Text}', '{txtTelefono.Text}', '{txtCelular.Text}', '{txtCorreo.Text}', {comboSexos.SelectedIndex + 1})";

                    SqlCommand command = new SqlCommand(query, cmd);
                    int i = command.ExecuteNonQuery();
                    cmd.Close();
                    if (i > 0)
                    {
                        MessageBox.Show("El cliente fue guardado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Nuevo();
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

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Estás seguro de querer eliminar este cliente?", "Observación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
                    cmd.Open();
                    using (cmd)
                    {
                        string query = $"DELETE FROM Clientes WHERE ClienteId = {int.Parse(Idtxt.Text)}";

                        SqlCommand command = new SqlCommand(query, cmd);
                        int i = command.ExecuteNonQuery();
                        cmd.Close();
                        if (i > 0)
                        {
                            MessageBox.Show("El cliente fue eliminado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Nuevo();
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
