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
        private rSuplidores RSuplidores;
        private rClientes RClientes;
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
            string[] filtro = { "UsuarioId", "Nombres" };
            filtroCombo.DataSource = filtro;
        }

        //BUSQUEDA Suplidores
        public rBusqueda(rSuplidores rSuplidores)
        {
            InitializeComponent();

            modelo = "suplidores";
            RSuplidores = rSuplidores;
            BusquedaSuplidores();
        }

        private void BusquedaSuplidores()
        {
            string[] filtro = { "SuplidorId", "Nombres" };
            filtroCombo.DataSource = filtro;
        }

        //BUSQUEDA CLIENTES
        public rBusqueda(rClientes rClientes)
        {
            InitializeComponent();

            modelo = "clientes";
            RClientes = rClientes;
            BusquedaClientes();
        }

        private void BusquedaClientes()
        {
            string[] filtro = { "ClienteId", "Nombres" };
            filtroCombo.DataSource = filtro;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
            DataTable dt = new DataTable();
            switch (modelo)
            {
                case "usuarios":
                    if (txtCriterio.Text.Trim().Length > 0)
                    {
                        if (filtroCombo.SelectedIndex == 0 || filtroCombo.SelectedIndex == 1)
                        {
                            using (cmd)
                            {
                                string query = $"SELECT * FROM Usuarios WHERE {filtroCombo.Text} like '%{txtCriterio.Text}%'";

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
                    break;
                case "suplidores":
                    if (txtCriterio.Text.Trim().Length > 0)
                    {
                        if (filtroCombo.SelectedIndex == 1)
                        {
                            using (cmd)
                            {
                                string query = $"SELECT * FROM Suplidores WHERE {filtroCombo.Text} like '%{txtCriterio.Text}%'";

                                SqlCommand command = new SqlCommand(query, cmd);
                                SqlDataAdapter da = new SqlDataAdapter(command);
                                da.Fill(dt);
                            }
                            busquedadtg.DataSource = dt;

                        }
                        else
                        {
                            using (cmd)
                            {
                                string query = $"SELECT * FROM Suplidores WHERE {filtroCombo.Text} = {txtCriterio.Text}";

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
                            string query = $"SELECT * FROM Suplidores";

                            SqlCommand command = new SqlCommand(query, cmd);
                            SqlDataAdapter da = new SqlDataAdapter(command);
                            da.Fill(dt);
                        }
                        busquedadtg.DataSource = dt;
                    }
                    break;
                case "clientes":
                    if (txtCriterio.Text.Trim().Length > 0)
                    {
                        if (filtroCombo.SelectedIndex == 1)
                        {
                            using (cmd)
                            {
                                string query = $"SELECT * FROM Clientes WHERE {filtroCombo.Text} like '%{txtCriterio.Text}%'";

                                SqlCommand command = new SqlCommand(query, cmd);
                                SqlDataAdapter da = new SqlDataAdapter(command);
                                da.Fill(dt);
                            }
                            busquedadtg.DataSource = dt;

                        }
                        else
                        {
                            using (cmd)
                            {
                                string query = $"SELECT * FROM Clientes WHERE {filtroCombo.Text} = {txtCriterio.Text}";

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
                            string query = $"SELECT * FROM Clientes";

                            SqlCommand command = new SqlCommand(query, cmd);
                            SqlDataAdapter da = new SqlDataAdapter(command);
                            da.Fill(dt);
                        }
                        busquedadtg.DataSource = dt;
                    }
                    break;
                default:
                    break;

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
                    case "suplidores":
                        int idS = int.Parse(busquedadtg.Rows[rowindex].Cells[0].Value.ToString());
                        string nombreS = busquedadtg.Rows[rowindex].Cells[1].Value.ToString();
                        string telefono = busquedadtg.Rows[rowindex].Cells[2].Value.ToString();
                        string Cedula = busquedadtg.Rows[rowindex].Cells[3].Value.ToString();
                        int empresaS = int.Parse(busquedadtg.Rows[rowindex].Cells[4].Value.ToString());
                        RSuplidores.RecibirDatos(idS,nombreS,telefono,Cedula,empresaS);
                        RSuplidores.Focus();
                        this.Close();
                        break;
                }
            }
        }
    }
}
