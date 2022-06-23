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

namespace SimpleRegister.UI.Consultas
{
    public partial class cUsuarios : Form
    {
        SqlConnection cmd;
        public cUsuarios()
        {
            cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
            InitializeComponent();
            BusquedaUsuarios();
        }

        private void BusquedaUsuarios()
        {
            string[] filtro = { "UsuarioId", "Nombres" };
            comboFiltro.DataSource = filtro;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
            DataTable dt = new DataTable();

            if (txtCriterio.Text.Trim().Length > 0)
            {
                if (comboFiltro.SelectedIndex == 1)
                {
                    using (cmd)
                    {
                        string query = $"SELECT UsuarioId AS Id, Nombres, NombreUsuario AS 'Nombre de Usuario', r.Nombre AS Rol FROM Usuarios AS u INNER JOIN Roles AS r on r.RolId = u.RolId WHERE {comboFiltro.Text} like '%{txtCriterio.Text}%' ";

                        SqlCommand command = new SqlCommand(query, cmd);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(dt);
                    }
                    usuariosdtg.DataSource = dt;

                }
                else
                {
                    using (cmd)
                    {
                        string query = $"SELECT UsuarioId AS Id, Nombres, NombreUsuario AS Nombre de Usuario, r.Nombre AS Rol FROM Usuarios AS u INNER JOIN Roles AS r on r.RolId = u.RolId WHERE {comboFiltro.Text} = {txtCriterio.Text}";

                        SqlCommand command = new SqlCommand(query, cmd);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(dt);
                    }
                    usuariosdtg.DataSource = dt;
                }
            }
            else
            {
                using (cmd)
                {
                    string query = $"SELECT UsuarioId AS Id, Nombres, NombreUsuario AS 'Nombre de Usuario', r.Nombre AS Rol FROM Usuarios AS u INNER JOIN Roles AS r on r.RolId = u.RolId";

                    SqlCommand command = new SqlCommand(query, cmd);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
                usuariosdtg.DataSource = dt;
            }
            
        }
    }
}
