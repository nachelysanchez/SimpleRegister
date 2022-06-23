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
    public partial class cClientes : Form
    {
        SqlConnection cmd;
        public cClientes()
        {
            cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
            InitializeComponent();
            BusquedaClientes();
        }
        private void BusquedaClientes()
        {
            string[] filtro = { "ClienteId", "Nombres" };
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
                        string query = $"SELECT ClienteId AS Id, Nombres, Telefono, Celular, s.Nombre AS Sexo FROM Clientes AS c INNER JOIN Sexos AS s on s.SexoId = c.SexoId WHERE {comboFiltro.Text} like '%{txtCriterio.Text}%'";

                        SqlCommand command = new SqlCommand(query, cmd);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(dt);
                    }
                    clientesdtg.DataSource = dt;

                }
                else
                {
                    using (cmd)
                    {
                        string query = $"SELECT ClienteId AS Id, Nombres, Telefono, Celular, s.Nombre AS Sexo FROM Clientes AS c INNER JOIN Sexos AS s on s.SexoId = c.SexoId WHERE {comboFiltro.Text} = {txtCriterio.Text}";

                        SqlCommand command = new SqlCommand(query, cmd);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(dt);
                    }
                    clientesdtg.DataSource = dt;

                }
            }
            else
            {
                using (cmd)
                {
                    string query = $"SELECT ClienteId AS Id, Nombres, Telefono, Celular, s.Nombre AS Sexo FROM Clientes AS c INNER JOIN Sexos AS s on s.SexoId = c.SexoId";

                    SqlCommand command = new SqlCommand(query, cmd);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
                clientesdtg.DataSource = dt;
            }
        }
    }
}
