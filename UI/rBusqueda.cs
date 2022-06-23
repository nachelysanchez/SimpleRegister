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
        private rProductos RProductos;
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

        //BUSQUEDA PRODUCTOS
        public rBusqueda(rProductos rProductos)
        {
            InitializeComponent();

            modelo = "productos";
            RProductos = rProductos;
            BusquedaProductos();
        }

        private void BusquedaProductos()
        {
            string[] filtro = { "ProductoId", "Nombre" };
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
                        if (filtroCombo.SelectedIndex == 1)
                        {
                            using (cmd)
                            {
                                string query = $"SELECT UsuarioId AS Id, Nombres, NombreUsuario AS 'Nombre de Usuario', r.Nombre AS Rol FROM Usuarios AS u INNER JOIN Roles AS r on r.RolId = u.RolId WHERE {filtroCombo.Text} like '%{txtCriterio.Text}%' ";

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
                                string query = $"SELECT UsuarioId AS Id, Nombres, NombreUsuario AS 'Nombre de Usuario', r.Nombre AS Rol FROM Usuarios AS u INNER JOIN Roles AS r on r.RolId = u.RolId WHERE {filtroCombo.Text} = {txtCriterio.Text}";

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
                            string query = $"SELECT UsuarioId AS Id, Nombres, NombreUsuario AS 'Nombre de Usuario', r.Nombre AS Rol FROM Usuarios AS u INNER JOIN Roles AS r on r.RolId = u.RolId";

                            SqlCommand command = new SqlCommand(query, cmd);
                            SqlDataAdapter da = new SqlDataAdapter(command);
                            da.Fill(dt);
                        }
                        busquedadtg.DataSource = dt;
                    }
                    if (dt == null)
                    {
                        MessageBox.Show($"No existen {modelo}");
                    }
                    break;
                case "suplidores":
                    if (txtCriterio.Text.Trim().Length > 0)
                    {
                        if (filtroCombo.SelectedIndex == 1)
                        {
                            using (cmd)
                            {
                                string query = $"SELECT SuplidorId AS Id, Nombres, Telefono, Cedula, e.Nombre AS Empresa FROM Suplidores AS s INNER JOIN Empresas AS e on e.EmpresaId = s.EmpresaId WHERE {filtroCombo.Text} like '%{txtCriterio.Text}%'";

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
                                string query = $"SELECT SuplidorId AS Id, Nombres, Telefono, Cedula, e.Nombre AS Empresa FROM Suplidores AS s INNER JOIN Empresas AS e on e.EmpresaId = s.EmpresaId WHERE {filtroCombo.Text} = {txtCriterio.Text}";

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
                            string query = $"SELECT SuplidorId AS Id, Nombres, Telefono, Cedula, e.Nombre AS Empresa FROM Suplidores AS s INNER JOIN Empresas AS e on e.EmpresaId = s.EmpresaId";

                            SqlCommand command = new SqlCommand(query, cmd);
                            SqlDataAdapter da = new SqlDataAdapter(command);
                            da.Fill(dt);
                        }
                        busquedadtg.DataSource = dt;
                    }
                    if (dt == null)
                    {
                        MessageBox.Show($"No existen {modelo}");
                    }
                    break;
                case "clientes":
                    if (txtCriterio.Text.Trim().Length > 0)
                    {
                        if (filtroCombo.SelectedIndex == 1)
                        {
                            using (cmd)
                            {
                                string query = $"SELECT UsuarioId AS Id, Nombres, NombreUsuario AS 'Nombre de Usuario', r.Nombre AS Rol FROM Usuarios AS u INNER JOIN Roles AS r on r.RolId = u.RolId WHERE {filtroCombo.Text} like '%{txtCriterio.Text}%' ";

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
                                string query = $"SELECT ClienteId AS Id, Nombres, Telefono, Celular, s.Nombre AS Sexo FROM Clientes AS c INNER JOIN Sexos AS s on s.SexoId = c.SexoId WHERE {filtroCombo.Text} = {txtCriterio.Text}";

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
                            string query = $"SELECT ClienteId AS Id, Nombres, Telefono, Celular, s.Nombre AS Sexo FROM Clientes AS c INNER JOIN Sexos AS s on s.SexoId = c.SexoId";

                            SqlCommand command = new SqlCommand(query, cmd);
                            SqlDataAdapter da = new SqlDataAdapter(command);
                            da.Fill(dt);
                        }
                        busquedadtg.DataSource = dt;
                    }
                    if (dt == null)
                    {
                        MessageBox.Show($"No existen {modelo}");
                    }
                    break;
                case "productos":
                    if (txtCriterio.Text.Trim().Length > 0)
                    {
                        if (filtroCombo.SelectedIndex == 1)
                        {
                            using (cmd)
                            {
                                string query = $"SELECT * FROM Productos WHERE {filtroCombo.Text} like '%{txtCriterio.Text}%'";

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
                                string query = $"SELECT * FROM Productos WHERE {filtroCombo.Text} = {txtCriterio.Text}";

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
                            string query = $"SELECT * FROM Productos";

                            SqlCommand command = new SqlCommand(query, cmd);
                            SqlDataAdapter da = new SqlDataAdapter(command);
                            da.Fill(dt);
                        }
                        busquedadtg.DataSource = dt;
                    }
                    if (dt == null)
                    {
                        MessageBox.Show($"No existen {modelo}");
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
                    case "clientes":
                        int idC = int.Parse(busquedadtg.Rows[rowindex].Cells[0].Value.ToString());
                        string nombreC = busquedadtg.Rows[rowindex].Cells[1].Value.ToString();
                        string telefonoC = busquedadtg.Rows[rowindex].Cells[2].Value.ToString();
                        string CelularC = busquedadtg.Rows[rowindex].Cells[3].Value.ToString();
                        string Correo = busquedadtg.Rows[rowindex].Cells[4].Value.ToString();
                        int sexo = int.Parse(busquedadtg.Rows[rowindex].Cells[5].Value.ToString());

                        RClientes.RecibirDatos(idC, nombreC, telefonoC, CelularC, Correo, sexo);
                        RClientes.Focus();
                        this.Close();
                        break;
                    case "productos":
                        int idP = int.Parse(busquedadtg.Rows[rowindex].Cells[0].Value.ToString());
                        string nombreP = busquedadtg.Rows[rowindex].Cells[1].Value.ToString();
                        float precioC = float.Parse(busquedadtg.Rows[rowindex].Cells[2].Value.ToString());
                        float precioV = float.Parse(busquedadtg.Rows[rowindex].Cells[3].Value.ToString());
                        int Existencia = int.Parse(busquedadtg.Rows[rowindex].Cells[4].Value.ToString());
                        int marca = int.Parse(busquedadtg.Rows[rowindex].Cells[5].Value.ToString());

                        RProductos.RecibirDatos(idP, nombreP, precioC, precioV, Existencia, marca);
                        RProductos.Focus();
                        this.Close();
                        break;
                }
            }
        }
    }
}
