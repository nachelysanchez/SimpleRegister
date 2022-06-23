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
    public partial class cProductos : Form
    {
        SqlConnection cmd;
        public cProductos()
        {
            cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
            InitializeComponent();
            BusquedaProductos();
        }

        private void BusquedaProductos()
        {
            string[] filtro = { "ProductoId", "Nombres" };
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
                        string query = $"SELECT ProductoId AS Id, p.Nombre, PrecioCompra AS 'Precio de compra', PrecioVenta AS 'Precio de venta', Existencia, m.Nombre AS Marca FROM Productos AS p INNER JOIN Marcas AS m on m.MarcarId = p.MarcaId WHERE {comboFiltro.Text} like '%{txtCriterio.Text}%'";

                        SqlCommand command = new SqlCommand(query, cmd);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(dt);
                    }
                    productosdtg.DataSource = dt;

                }
                else
                {
                    using (cmd)
                    {
                        string query = $"SELECT ProductoId AS Id, p.Nombre, PrecioCompra AS 'Precio de compra', PrecioVenta AS 'Precio de venta', Existencia, m.Nombre AS Marca FROM Productos AS p INNER JOIN Marcas AS m on m.MarcarId = p.MarcaId  WHERE {comboFiltro.Text} = {txtCriterio.Text}";

                        SqlCommand command = new SqlCommand(query, cmd);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(dt);
                    }
                    productosdtg.DataSource = dt;

                }
            }
            else
            {
                using (cmd)
                {
                    string query = $"SELECT ProductoId AS Id, p.Nombre, PrecioCompra AS 'Precio de compra', PrecioVenta AS 'Precio de venta', Existencia, m.Nombre AS 'Nombre de la Marca' FROM Productos AS p INNER JOIN Marcas AS m on m.MarcaId = p.MarcaId";

                    SqlCommand command = new SqlCommand(query, cmd);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
                productosdtg.DataSource = dt;
            }
        }
    }
}
