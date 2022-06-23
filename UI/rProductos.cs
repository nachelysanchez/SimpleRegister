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
    public partial class rProductos : Form
    {
        SqlConnection cmd;
        public rProductos()
        {
            InitializeComponent();
            cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
            CargarComboBox();
            Nuevo();
        }
        private void getUltimoProducto()
        {
            try
            {
                cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
                DataTable dt = new DataTable();
                using (cmd)
                {
                    string query = "SELECT top(1) ProductoId FROM Productos Order by ProductoId desc";

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
                    int id = int.Parse(dt.Rows[0]["ProductoId"].ToString());
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
            getUltimoProducto();
            Idtxt.ReadOnly = true;

            txtNombre.Text = string.Empty;
            txtPrecioCompra.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;
            txtExistencia.Text = string.Empty;
            comboMarca.SelectedIndex = 0;
        }
        public void RecibirDatos(int id, string nombre, float precioC, float precioV, int existencia, int marca)
        {
            Idtxt.Text = id.ToString();
            txtNombre.Text = nombre;
            txtExistencia.Text = existencia.ToString();
            txtPrecioCompra.Text = precioC.ToString("N2");
            txtPrecioVenta.Text = precioV.ToString("N2");
            comboMarca.SelectedIndex = marca - 1;

        }
        private void CargarComboBox()
        {
            try
            {
                DataTable dt = new DataTable();
                using (cmd)
                {
                    string query = "SELECT * FROM Marcas";

                    SqlCommand command = new SqlCommand(query, cmd);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }

                comboMarca.DisplayMember = "Nombre";
                comboMarca.ValueMember = "MarcaId";
                comboMarca.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido una excepción: ");
                throw;
            }

        }

        private bool Validar()
        {
            bool paso = true;
            if (MessageBox.Show("¿Estás seguro de querer guardar este producto?", "Observación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtNombre.Text == "")
                {
                    paso = false;
                    MessageBox.Show("Debe de llevar el campo nombre");
                    txtNombre.Focus();
                }
                else if (txtNombre.Text == "")
                {
                    paso = false;
                    MessageBox.Show("Debe de llevar el campo Nombre");
                    txtNombre.Focus();
                }
                else if (txtPrecioCompra.Text == "")
                {
                    paso = false;
                    MessageBox.Show("Debe de llevar el campo Precio de Compra");
                    txtPrecioCompra.Focus();
                }
                else if (txtPrecioVenta.Text == "")
                {
                    paso = false;
                    MessageBox.Show("Debe de llevar el campo Precio de Venta");
                    txtPrecioVenta.Focus();
                }
                else if (txtExistencia.Text == "")
                {
                    paso = false;
                    MessageBox.Show("Debe de llevar el campo Existencia");
                    txtExistencia.Focus();
                }
            }
            return paso;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            rBusqueda busqueda = new rBusqueda(this);
            busqueda.Show();
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
                    string query = $"INSERT INTO Productos VALUES ({int.Parse(Idtxt.Text)},'{txtNombre.Text}', {txtPrecioCompra.Text}, {txtPrecioVenta.Text}, {txtExistencia.Text}, {comboMarca.SelectedIndex + 1})";

                    SqlCommand command = new SqlCommand(query, cmd);
                    int i = command.ExecuteNonQuery();
                    cmd.Close();
                    if (i > 0)
                    {
                        MessageBox.Show("El producto fue guardado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (MessageBox.Show("¿Estás seguro de querer eliminar este producto?", "Observación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlConnection(@"Data Source = DESKTOP-K8OJCDL\SQLEXPRESS ; Initial Catalog = ProyectoDb ; Integrated Security = True");
                    cmd.Open();
                    using (cmd)
                    {
                        string query = $"DELETE FROM Productos WHERE ProductoId = {int.Parse(Idtxt.Text)}";

                        SqlCommand command = new SqlCommand(query, cmd);
                        int i = command.ExecuteNonQuery();
                        cmd.Close();
                        if (i > 0)
                        {
                            MessageBox.Show("El producto fue eliminado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Nuevo();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error al eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido una excepción: ");
            }
        }
    }
}
