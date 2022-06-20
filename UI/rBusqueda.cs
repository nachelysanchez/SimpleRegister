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
    public partial class rBusqueda : Form
    {
        SqlConnection cmd;
        private rUsuarios Rusuarios;
        string modelo;
        public rBusqueda()
        {
            cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
            InitializeComponent();
        }

        //BUSQUEDA Usuarios
        public rBusqueda(rUsuarios rusuarios)
        {
            InitializeComponent();

            modelo = "usuarios";
            Rusuarios = rusuarios;
            BusquedaUsuarios();
        }

        private void BusquedaUsuarios()
        {
            string[] filtro = { "Id", "Nombres" };
            filtroCombo.DataSource = filtro;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
            DataTable dt = new DataTable();
            if (txtCriterio.Text.Trim().Length > 0)
            {
                if (filtroCombo.SelectedIndex == 0 || filtroCombo.SelectedIndex == 1)
                {
                    using (cmd)
                    {
                        string query = $"SELECT * FROM Usuarios WHERE UsuarioId = {txtCriterio.Text}";

                        SqlCommand command = new SqlCommand(query, cmd);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(dt);
                    }
                    busquedadtg.DataSource = dt;
                    
                }
            }
            else
            {
                using (cmd)
                {
                    string query = $"SELECT * FROM Usuarios";

                    SqlCommand command = new SqlCommand(query, cmd);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
                busquedadtg.DataSource = dt;
            }
        }

        private void busquedadtg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                int rowindex = busquedadtg.CurrentCell.RowIndex-1;

                switch (modelo)
                {
                    case "usuarios":
                        int id = int.Parse(busquedadtg.Rows[rowindex].Cells[0].Value.ToString());
                        string nombre = busquedadtg.Rows[rowindex].Cells[1].Value.ToString();
                        string user = busquedadtg.Rows[rowindex].Cells[2].Value.ToString();
                        int rol = int.Parse(busquedadtg.Rows[rowindex].Cells[4].Value.ToString());
                        Rusuarios.RecibirDatos(id, nombre, user, rol);
                        Rusuarios.Focus();
                        this.Close();
                        break;
                }
            }
        }
    }
}
