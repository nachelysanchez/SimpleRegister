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
    public partial class Login : Form
    {
        SqlConnection cmd;
        Principal principal = new Principal();
        public Login()
        {
            InitializeComponent();
            cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");

        }
        private bool Validar()
        {
            bool esValido = true;
            if (txtusername.Text.Length == 0 || txtpassword.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("No puede Ddejar campos vacios", "Fallo", MessageBoxButtons.OK);
            }
            return esValido;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
            DataTable dt = new DataTable();
            using (cmd)
            {
                string query = $"SELECT top(1) UsuarioId FROM Usuarios WHERE NombreUsuario = '{txtusername.Text}' AND Contrasena = '{txtpassword.Text}'";

                SqlCommand command = new SqlCommand(query, cmd);
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrecta");
            }
            else
            {
                this.Hide();
                principal.Show();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
