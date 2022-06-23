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
    public partial class cSuplidores : Form
    {
        SqlConnection cmd;
        public cSuplidores()
        {
            cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
            InitializeComponent();
            BusquedaSuplidores();
        }

        private void BusquedaSuplidores()
        {
            string[] filtro = { "SuplidorId", "Nombres" };
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
                        string query = $"SELECT SuplidorId AS Id, Nombres, Telefono, Cedula, e.Nombre AS Empresa FROM Suplidores AS s INNER JOIN Empresas AS e on e.EmpresaId = s.EmpresaId WHERE {comboFiltro.Text} like '%{txtCriterio.Text}%'";

                        SqlCommand command = new SqlCommand(query, cmd);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(dt);
                    }
                    suplidoresdtg.DataSource = dt;

                }
                else
                {
                    using (cmd)
                    {
                        string query = $"SELECT SuplidorId AS Id, Nombres, Telefono, Cedula, e.Nombre AS Empresa FROM Suplidores AS s INNER JOIN Empresas AS e on e.EmpresaId = s.EmpresaId WHERE {comboFiltro.Text} = {txtCriterio.Text}";

                        SqlCommand command = new SqlCommand(query, cmd);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(dt);
                    }
                    suplidoresdtg.DataSource = dt;
                }
            }
            else
            {
                using (cmd)
                {
                    string query = $"SELECT SuplidorId AS Id, Nombres, Telefono, Cedula, e.Nombre AS Empresa FROM Suplidores AS s INNER JOIN Empresas AS e on e.EmpresaId = s.EmpresaId";

                    SqlCommand command = new SqlCommand(query, cmd);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
                suplidoresdtg.DataSource = dt;
            }
        }
    }
}
