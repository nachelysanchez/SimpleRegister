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
        }

        private void rUsuarios_Load(object sender, EventArgs e)
        {

            //SqlCommand comando = new SqlCommand($"INSERT INTO Usuarios VALUES ()")
        }

        private void CargarComboBox()
        {
            DataTable dt = new DataTable();
            using (cmd)
            {
                string query = "SELECT * FROM Roles";

                SqlCommand command = new SqlCommand(query, cmd);
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }

            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "RolId";
            comboBox1.DataSource = dt;
        }
    }
}
