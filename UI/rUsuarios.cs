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
    public partial class rUsuarios : Form
    {
        SqlConnection cmd;
        public rUsuarios()
        {
            InitializeComponent();
            cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
            CargarComboBox();
            Nuevo();
        }

        private void rUsuarios_Load(object sender, EventArgs e)
        {

            //SqlCommand comando = new SqlCommand($"INSERT INTO Usuarios VALUES ()")
        }

        private void CargarComboBox()
        {
            try
            {
                DataTable dt = new DataTable();
                using (cmd)
                {
                    string query = "SELECT * FROM Roles";

                    SqlCommand command = new SqlCommand(query, cmd);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }

                comboRol.DisplayMember = "Nombre";
                comboRol.ValueMember = "RolId";
                comboRol.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido una excepción: ");
                throw;
            }

        }

        private void getUltimoUsuario()
        {
            try
            {
                cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
                DataTable dt = new DataTable();
                using (cmd)
                {
                    string query = "SELECT top(1) UsuarioId FROM Usuarios Order by UsuarioId desc";

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
                    int id = int.Parse(dt.Rows[0]["UsuarioId"].ToString());
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
            getUltimoUsuario();
            Idtxt.ReadOnly = true;

            txtNombre.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUser.Text = string.Empty;
            comboRol.SelectedIndex = 0;
        }

        private bool Validar()
        {
            bool paso = true;
            if (MessageBox.Show("¿Estás seguro de querer guardar este usuario?", "Observación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtNombre.Text == "")
                {
                    paso = false;
                    MessageBox.Show("Debe de llevar el campo nombre");
                    txtNombre.Focus();
                }
                else if (txtPassword.Text == "")
                {
                    paso = false;
                    MessageBox.Show("Debe de llevar el campo Contraseña");
                    txtPassword.Focus();
                }
                else if (txtUser.Text == "")
                {
                    paso = false;
                    MessageBox.Show("Debe de llevar el campo Nombre de usuario");
                    txtUser.Focus();
                }
            }
            return paso;
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validar())
                {
                    return;
                }
                cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
                cmd.Open();
                using (cmd)
                {
                    string query = $"INSERT INTO Usuarios VALUES ({int.Parse(Idtxt.Text)},'{txtNombre.Text}', '{txtUser.Text}', '{txtPassword.Text}', {comboRol.SelectedIndex + 1})";

                    SqlCommand command = new SqlCommand(query, cmd);
                    int i = command.ExecuteNonQuery();
                    cmd.Close();
                    if (i > 0)
                    {
                        MessageBox.Show("El usuario fue guardado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (MessageBox.Show("¿Estás seguro de querer eliminar este usuario?", "Observación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
                    cmd.Open();
                    using (cmd)
                    {
                        string query = $"DELETE FROM Usuarios WHERE UsuarioId = {int.Parse(Idtxt.Text)}";

                        SqlCommand command = new SqlCommand(query, cmd);
                        int i = command.ExecuteNonQuery();
                        cmd.Close();
                        if (i > 0)
                        {
                            MessageBox.Show("El usuario fue eliminado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            rBusqueda rBusqueda = new rBusqueda(this);
            rBusqueda.Show();
        }

        public void RecibirDatos(int id, string nombre, string user, int rol)
        {
            Idtxt.Text = id.ToString();
            txtNombre.Text = nombre;
            txtUser.Text = user;
            comboRol.SelectedIndex = rol - 1;

        }
    }
}
